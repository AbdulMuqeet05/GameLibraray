<template>
      <div class="columns is-multiline is-mobile is-0-tablet is-3-desktop is-8-widescreen is-2-fullhd">
  
  
  <mytable  v-bind:games="games"/>

  <!-- <div class="column">
    <b-button tag="router-link"
                to="/addGame"
                type="is-link">
                +
            </b-button>
  </div> -->
</div>
</template>

<script>
import mytable from '@/components/Table'
import api from '@/api.js'
export default {
    data() {
        return {
            games:[]
        }
    },
  components: {
    'mytable': mytable
  },
  mounted() {
      let apis=new api();
      apis.get('api/games/view').then(result=> {
          this.games=result.data;
      }).catch((err)=> {
          console.log(err);
      });

      
  },
}
</script>

<style>
.carosel {
  padding-top:-3px; 
}

</style>