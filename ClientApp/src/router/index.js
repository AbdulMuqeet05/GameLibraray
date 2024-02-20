import Vue from 'vue'
import Router from 'vue-router'
import Navbar from '@/components/Navbar'
import AddGame from '@/pages/AddGame'
import FirstPage from '@/pages/FirstPage'
import ViewGame from '@/pages/ViewGame'
Vue.use(Router)


export default new Router({
  routes : [
    {
      path: '/',
      name: 'FirstPage',
      component: FirstPage
    },
    // {
    //   path: '/',
    //   name: 'addGame',
    //   redirect:'/addGame'
    // },
    {
      path:'/addGame',
      name:'addGame',
      component:AddGame
    },
    {
      path:'/viewGame',
      name:'ViewGame',
      component:ViewGame
    }
  ]

})
  

