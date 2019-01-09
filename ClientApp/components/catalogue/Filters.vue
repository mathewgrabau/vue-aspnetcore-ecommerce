<template>
	<div class="fitlers mb-4">
		<h5 class="mt-4">Filters</h5>
		<b-btn variant="outline-secondary" @click.prevent="reset">
			<i class="fas fa-sync mr-2"></i> Reset</b-btn>
		<b-list-group class="mt-4">
			<filter-accordian>
				<span slot="header">Brand</span>
				<b-row slot="body">
					<b-col cols="6">
						<div :class="{ 'filter-item': true, 'active': brands.length === 0 }" @click="clearBrands">All</div>
					</b-col>
					<b-col cols="6" v-for="item in filters.brands" :key="item">
						<div :class="{ 'filter-item': true, 'active': brands.indexOf(item) > -1 }" @click="filterBrand(item)">{{ item }}</div>
					</b-col>
				</b-row>
			</filter-accordian>

			<filter-accordian>
				<span slot="header">Price</span>
				<div class="slider" slot="body">
					<vue-slider :value="price"
						formatter="${value}"
						:min=0
						:max=1000
						:interval=50
						:lazy=true
						width="90%"
						@callback="filterPrice">
					</vue-slider>
				</div>
			</filter-accordian>

			<!-- screen size filter -->
			<filter-accordian>
				<span slot="header">Screen Size</span>
				<div class="slider" slot="body">
					<vue-slider :value="screenSize"
						formatter="{value} in"
						:min=0
						:max=7
						:lazy=true
						width="90%"
						@callback="filterScreenSize">
					</vue-slider>
				</div>
			</filter-accordian>

			<!-- Colour filter -->
			<filter-accordian>
				<span slot="header">Colour</span>
				<b-row slot="body">
					<b-col cols="6">
						<div :class="{ 'filter-item': true, 'active': colours.length === 0 }" @click="clearColours">All</div>
					</b-col>
					<b-col cols="6" v-for="item in filters.colours" :key="item">
						<div :class="{ 'filter-item': true, 'active': colours.indexOf(item) > -1 }" @click="filterColour(item)">{{ item }}</div>
					</b-col>
				</b-row>
			</filter-accordian>

			<!-- Operating system filter -->
			<filter-accordian>
				<span slot="header">Operating system</span>
				<b-row slot="body">
					<b-col cols="6">
						<div :class="{ 'filter-item': true, 'active': os.length === 0 }" @click="clearOS">All</div>
					</b-col>
					<b-col cols="6" v-for="item in filters.os" :key="item">
						<div :class="{ 'filter-item': true, 'active': os.indexOf(item) > -1 }" @click="filterOS(item)">{{ item }}</div>
					</b-col>
				</b-row>
			</filter-accordian>

			<filter-accordian>
				<span slot="header">Features</span>
				<b-row slot="body">
					<b-col cols="6">
						<div :class="{ 'filter-item': true, 'active': features.length === 0 }" @click="clearFeatures">All</div>
					</b-col>
					<b-col cols="6" v-for="item in filters.features" :key="item">
						<div :class="{ 'filter-item': true, 'active': features.indexOf(item) > -1 }" @click="filterFeature(item)">{{ item }}</div>
					</b-col>
				</b-row>
			</filter-accordian>
		</b-list-group>
	</div>
</template>

<script>
import FilterAccordian from "./FilterAccordian.vue";
import vueSlider from "vue-slider-component";
export default {
	name: "filters",
	props: {
		filters: {
			type: Object,
			required: true
		}
	},
	components: {
		FilterAccordian,
		vueSlider
	},
	computed: {
		brands() {
			return this.$route.query.brands || "";
		},
		price() {
			return [
				this.$route.query.minPrice || 0,
				this.$route.query.maxPrice || 1000
			];
		},
		screenSize() {
			return [
				this.$route.query.minScreen || 0,
				this.$route.query.maxScreen || 7
			]
		},
		capacity() {
			return this.$route.query.capacity || "";
		},
		colours() {
			return this.$route.query.colours || "";
		},
		os() {
			return this.$route.query.os || "";
		},
		features() {
			return this.$route.query.features || "";
		}
	},
	methods: {
		reset() {
			this.$router.push({ query: {} });
		},
		clearBrands() {
			if (this.brands.length) {
				let query = Object.assign({}, this.$route.query);
				delete query.brands;

				this.$router.push({ query: query });
			}
		},
		filterBrand(brand) {
			let query = Object.assign({}, this.$route.query);
			let split = query.brands ? query.brands.split("|") : [];

			if (split.indexOf(brand) > -1) {
				let index = split.indexOf(brand);
				split.splice(index, 1);
			} else {
				split.push(brand);
			}
		},
		filterPrice(prices) {
			let query = Object.assign({}, this.$route.query);
			query.minPrice = prices[0];
			query.maxPrice = prices[1];

			this.$router.push({ query: query });
		},
		filterScreenSize(sizes) {
			let query = Object.assign({}, this.$route.query);
			query.minScreen = sizes[0];
			query.maxScreen = sizes[1];

			this.$router.push({ query: query });
		}
	}
}
</script>

<style>

</style>
