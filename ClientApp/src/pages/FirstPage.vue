<template>
 
    <carosel/>

</template>

<script>
import carosel from '@/components/carousel'
export default {
  components: {
  'carosel':carosel
  }
}
</script>

<style>
.carosel {
  padding-top:-3px; 
}
/* #app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
} */
</style>
