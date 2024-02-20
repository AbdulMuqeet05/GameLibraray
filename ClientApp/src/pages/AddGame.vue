<template>
 <div class="column is-four-fifths align-center">
    <section >
        <b-field label="Name" :type="{ 'is-danger': hasError }"
            :message="{ 'Username is not available': hasError } ">
            <b-input v-model="model.name" maxlength="100" ></b-input>
        </b-field>
         <b-field label="Platform">
            <b-input v-model="model.platform"></b-input>
        </b-field>
         <b-field  label="Genre"
            >
            <b-select  v-model="model.genre"  placeholder="Select a Genre">

                <option v-for="(item,index) in genre_array"  :key="index" :value="item.id">{{item.name}}</option>

                <!-- <option value="2">Option 2</option> -->
            </b-select>
        </b-field>
        <b-field label="Select a date">
            <b-datepicker
                v-model="model.release_date"
                placeholder="Click to select date..."
                icon="calendar-today">
            </b-datepicker>
        </b-field>
         <b-field label="No of players">
            <b-input type="number" v-model="model.no_of_player"></b-input>
        </b-field>
        <b-field  label="Publiser"
            >
            <b-select  v-model="model.publisher"  placeholder="Select a Publisher">

                <option v-for="(item,index) in publisher_array"  :key="index" :value="item.id">{{item.name}}</option>

                <!-- <option value="2">Option 2</option> -->
            </b-select>
        </b-field>




    <label>File
        <input class="inputfile" type="file" id="file" ref="file" v-on:change="handleFileUpload()"/> 
        
      </label>
            <!-- <b-upload v-model="model.file" 
                drag-drop>
                <section class="section">
                    <div class="content has-text-centered">
                        <p>
                            <b-icon
                                icon="upload"
                                size="is-large">
                            </b-icon>
                        </p>
                        <p>Drop your file here or click to upload</p>
                    </div>
                </section>
            </b-upload>
            <span class="file-name" v-if="model.file" add_photo_change >
            {{ model.file.name }}
        </span> -->




        <b-button class="button is-primary" size="is-large" @click="save_game(model)">Save</b-button>
        </section>
        </div>
</template>
<script>
import api from '@/api.js'
import querystring from 'querystring'
export default {

    data() {
        return {
            file:null,
            publisher_array:[],
            genre_array:[],
            apis : new api(),
            hasError:false,
            model: {
            file:null,
            name:"",
            platform:"",
            genre:"",
            release_date:new Date(),
            no_of_player:"",
            publisher:"",
            photos:"",
            imageUrl:""
            }


        }
    },

    mounted() {
        new api().get('api/publisher/view').then(result=> {
          this.publisher_array=result.data;
      }).catch((err)=> {
          console.log(err);
      });
      new api().get('api/genre/view').then(result=> {
          this.genre_array=result.data;
      }).catch((err)=> {
          console.log(err);
      });
    },
    methods: {
       check_model_value(){

       },
       
    handleFileUpload() {
        
        var reader = new FileReader()
        reader.readAsDataURL(this.$refs.file.files[0])
        reader.onload = ()=> {
        this.model.file=reader.result;
        };
        // // this.model.file=this.$ref.file.files[0];
        // const fileReader = new FileReader();
        // fileReader.addEventListener("load", () => {
        // var image = new Image();
        // this.imageUrl = fileReader.result;
        // image.src = fileReader.result;
        // console.log(image)
        // });
    //   this.$refs.file.click();
      
    },
    clear_model() {
        this.file=null
            this.model.file=null
            this.model.filename=""
            this.model.fileplatform=""
            this.model.filegenre=""
            this.model.filerelease_date=new Date()
            this.model.fileno_of_player=""
            this.model.filepublisher=""
            this.model.filephotos=""
            this.model.fileimageUrl=""
            
    },
        save_game(entity) {
            
            let toSend =JSON.stringify({
                name:entity.name,
                platform:entity.platform,
                genre:entity.genre,
                release_date:entity.release_date,
                no_of_player:entity.no_of_player,
                publisher:entity.publisher,
                file:entity.file
            });
            console.log(toSend);
            this.apis.save('api/games/add',toSend).then(result=> {
          this.$swal("Game saved in game library");
          this.clear_model();
      }).catch((err)=> {
          console.log(err);
      });
        }
    },
}
</script>
<style scoped>
.button {
    background-color: #0275d8;

}


</style>