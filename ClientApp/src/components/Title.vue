<template>
<div id="sony-bar" class="sony-bar" >
   
      <span class="sr-only">SONY</span>
   </div>
    
</template>
<script>
export default {
    
}
</script>

<style scoped>
a:-webkit-any-link {
    color: -webkit-link;
    cursor: pointer;
    text-decoration: underline;
}
.sony-bar {
    text-align: right;
}

#sony-bar {
    text-align: right;
    color: whitesmoke;
    background-color: black;
    top: 0;
    bottom: auto;
    bottom: 0;
    font-size: 20px;
    font-weight: bolder;
    height: 36px;
    position: absolute;
    width: 100%;
    z-index: 9999;
    font-family: initial;
}
</style>