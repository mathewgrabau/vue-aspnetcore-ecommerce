<template>
  <b-container fluid class="page">
    <b-row>
      <b-col cols="3">
        <filters :filters="filters"/>
      </b-col>
      <b-col cols="9">
        <product-list :products="products"/>
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import axios from "axios";
import ProductList from "../components/catalogue/List.vue";
import Filters from "../components/catalogue/Filters.vue";

export default {
  name: "catalogue",
  components: {
    Filters,
    ProductList
  },
  data() {
    return {
      products: [],
      filters: {
        brands: [],
        capacity: [],
        colours: [],
        os: [],
        features: []
      }
    };
  },

  methods: {
    setData(products, filters) {
      console.log(products);
      console.log("Inside setData");
      this.products = products;
      this.filters = filters;
    }
  },

  beforeRouteEnter(to, from, next) {
    console.log("beforeRouteEnter");
    console.log(to.query);
    axios
      .all([
        axios.get("/api/products", { params: to.query }),
        axios.get("/api/filters")
      ])
      .then(
        axios.spread((products, filters) => {
          next(vm => vm.setData(products.data, filters.data));
        })
      );
  },
  beforeRouteUpdate(to, from, next) {
    console.log("beforeRouteUpdate");
    console.log(to);
    axios.get("/api/products", { params: to.query }).then(response=>{
      this.products = response.data;
      next();
    });
  }
};
</script>

