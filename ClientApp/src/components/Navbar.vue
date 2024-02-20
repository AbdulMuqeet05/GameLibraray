<template>

  <nav class="navbar" role="navigation" aria-label="dropdown navigation">
            <div class="navbar-brand">
                <a class="navbar-item not-affect" href="/" >
                     <img :src="logo" alt="Book Reads" width="112" height="28">
                    <span><i class="mdi mdi-24px mdi-home"></i> Home</span>
                </a>
                <!-- <div class="navbar-burger burger" v-on:click="showNav = !showNav" v-bind:class="{ 'is-active' : showNav }" data-target="navbarExampleTransparentExample">
                    <span></span>
                    <span></span>
                    <span></span>
                </div> -->
            </div>
            <div class="navbar-menu">
                <div class="navbar-start">
                   
                    <a class="navbar-item" href="#/addGame">
                        <span><i class="mdi mdi-24px mdi-comment-text-outline"></i>Add Game to library</span>
                    </a>
                      <a class="navbar-item" href="#/viewGame">
                        <span><i class="mdi mdi-24px mdi-comment-text-outline"></i>View Games in Library</span>
                    </a>
                    
                    
                </div>
                
                <div class="navbar-end">
                    <!-- <a v-if="navLogin" class="navbar-item" @click="openLogin()">
                        Login
                    </a>
                    <router-link v-if="navLogin" class="navbar-item" to="/register">Signup!</router-link> -->
                    <!-- <div class="navbar-item ">
                        <div class="field is-grouped">
                            <p class="control">
                                <router-link class="button is-outlined" to="/add-book">
                                    <span>Add New Book</span>
                                </router-link>
                            </p>
                        </div>
                    </div> -->
                </div>
            </div>
        </nav>
</template>
<script>

import Ps_logo from '@/assets/psLogo.png'

export default {
  component: {
  },
  data() {
    return {
      logo:Ps_logo
    }
  }
}
</script>
<style scoped>
.navbar {
  padding-top:36px; 
}
.navbar-item img {
    padding-right: 42px;
}
</style>