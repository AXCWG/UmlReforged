import type { Component } from 'solid-js';
import {External} from "./index";

const App: Component = () => {
  return (
      <>
        <p class="text-4xl text-green-700 text-center py-20">Hello tailwind!</p>
        <button class={"btn btn-primary"} onClick={()=>{
          External.sendMessage("Hi")
        }}>Command Send</button>
      </>
    
  );
};
const Playset = ()=>{
    return <>Playlist</>
}
const Setting = ()=>{
    return <>Setting</>
}
export default App;
export {Playset, Setting}
