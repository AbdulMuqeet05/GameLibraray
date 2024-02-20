<template>
<div>
    <div  class="column">
      <table class="my-table" id="customer">
        <thead>
  <tr>
    <th>Name</th>
    <th>Platform</th>
    <th>Genre</th>
    <th>Release Date</th>
    <th>No of Players</th>
    <th>Publisher</th>
    <th>Box Art</th>
    <th>Action</th>
  </tr>
  </thead>
  <tbody>
  <tr v-for="(game,index) in games" :key="index">
    <td>{{game.name}}</td>
    <td>{{game.platform}}</td>
    <td>{{game.genre}}</td>
    <td>{{game.release_date}}</td>
    <td>{{game.no_of_player}}</td>
    <td>{{game.publisher}}</td>
    <td><img :src="game.file" class="img"  /></td>
    <td><b-button class="button is-primary" size="is-small" @click="deleteGame(game)">Delete</b-button></td>
  </tr>
  </tbody>
</table>
  </div>
</div>
</template>
<script>
import api from "@/api.js"
export default {

  props: {
    games:{
      type:Array
    }
  },
  data(){
    return {
     
  }
  },
  methods: {
    deleteGame(game){
      let api_obj=new api()
      
      api_obj.delete('api/games/delete',JSON.stringify(game)).then(result=> {
        
        this.$swal(result.data.developerMessage);
        this.$forceUpdate()
      }).catch(err=> {
        console.log(err)
      })

    }
  },
}
</script>
<style scoped>
.is-primary{
  background-color:  #003791
}
#customers td, #customers th {
  border: 1px solid #ddd;
  padding: 8px;
}
tr:hover {background-color: #ddd;}


table,
td,
th {
  font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}
th{
    padding-top: 12px;
  padding-bottom: 12px;
  text-align: left;
  background-color: #003791;
  color: white;
}
th,
td {
  border: 1px solid #ddd;
  padding: 8px;
}
.my-table {
table-layout: fixed;
  border-spacing: 5px;
  width: 100%;
  margin: 20px auto;
  table-layout: auto;
}
.img {
    height: 200px;
    max-width: 200px;
}
</style>