<template>
	<product-details :product="product" />
</template>



<script>

import ProductDetails from '../components/product/Details.vue';

export default {
	name: 'product',
	components: {
		ProductDetails
	},
	data() {
		return {
			product: {
				name: "Samsung Galaxy S8",
        		slug: "samsung-galaxy-s8",
				thumbnail: "http://placehold.it/200x300",
				shortDescription: "Samsung Galaxy S8 Android with true edge to edge display",
				price: 499.99,
				description: "Something goes here"
			}
		}
	}
}
</script>
