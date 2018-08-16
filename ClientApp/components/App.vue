<template>
	<div>
		<product-list />
	</div>
</template>

<script>
import ProductList from './products/List.vue';

export default {
	name: 'app',
	components: {
		ProductList
	},
	data() {
		return {
			time: new Date().toString(),
			users: []
		}
	},
	mounted() {
		fetch('/api/users')
			.then(response => {
				return response.json()
			})
			.then(data => {
				this.users = data
			})
	}
}
</script>
