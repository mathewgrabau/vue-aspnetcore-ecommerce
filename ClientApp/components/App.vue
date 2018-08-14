<template>
	<div>
		<h1>Welcome to Hands on Vue.js with ASP.NET Core!</h1>
		<p>
			The time is: {{ time }}
		</p>
		There is something else here.
	</div>
</template>

<script>
export default {
	name: 'app',
	data() {
		return {
			time: new Date().toString()
		}
	}
}
</script>
