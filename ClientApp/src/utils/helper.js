import api from "@/api.js"

function helper() {

    

    this.get_publishers_array = function ()
        {
            var apis=new api();
            apis.get('api/publisher/view').then(result=> {
                return result.data;
            }).catch((err)=> {
                console.log(err);
            });

        }       

}

export default helper;