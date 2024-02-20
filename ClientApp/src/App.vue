<template>
  <div id='app'>

    <hero_title></hero_title>
    <navbar/>
    <body id="body">
      
    <section class="section">
    <div class="container">
    <router-view></router-view>
    </div>
</section>
</body>


  </div>
</template>
<script>
import navbar from '@/components/Navbar'
import hero_title from '@/components/Title'
export default {
  components: {
    'navbar':navbar,
    'hero_title':hero_title
  }
}
</script>