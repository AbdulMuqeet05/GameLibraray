
const axios=require('axios')


class API {
    
    constructor() {
        this.url = `http://localhost:5000/`;
        this.instance= axios.create({
            baseURL: this.url,
            timeout: 30000,
            headers:{
                'Content-Type': 'application/x-www-form-urlencoded'
            }
          });
    }
    get_header() {
        return {
            headers: {
                'Content-Type': 'application/json;charset=UTF-8',
              "Access-Control-Allow-Origin": "*",
            }
                }
    }
    
    get(url,id) {
        return this.instance.get(`/${url}`);
    }
    save(url,model) {
        return this.instance.post(`/${url}`,model,this.get_header());
        
    }
    delete(url,name) {
        return this.instance.post(`/${url}`,name,this.get_header());
    }
}
export default API;