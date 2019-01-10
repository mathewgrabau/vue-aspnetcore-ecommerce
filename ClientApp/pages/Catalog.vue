<template>
  <b-container fluid class="page">
    <b-row>
      <b-col cols="3">
        <filters :filters="filters" />
      </b-col>
      <b-col cols="9">
        <product-list :products="products" />
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import axios from "axois";
import ProductList from "../components/catalogue/List.vue";
import Filter from "../components/catalogue/Filters.vue";

export default {
  name: "catalogue",
  components: {
    Filter,
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
      this.products = products;
      this.filters = filters;
    }
  },

  beforeRouteEnter (to, from, next) {
    fetch("/api/products")
      .then(response => {
        return response.json();
      })
      .then(products => {
        next(vm => vm.setData(products))
      });
  }
};
</script>

