<template>
    <b-carousel :indicator-inside="false">
        <b-carousel-item v-for="(item, i) in 6" :key="i">
            <span class="image">
              <img :src="getImgUrl(i)">
            </span>
        </b-carousel-item>
        <template slot="indicators" slot-scope="props">
            <span class="al image">
                <img :src="getImgUrl(props.i)" :title="props.i">
            </span>
        </template>
    </b-carousel>
</template>

<script>

export default {
    data() {
        return {

        }
    },
    methods: {
      getImgUrl(value) {
          return require(`@/assets/${value}.jpeg`)
      }
    }
}
</script>

<style>
.is-active .al img {
    filter: grayscale(0%);
}
.al img {
    filter: grayscale(100%);
}
</style>