/* @refresh reload */
import './index.css';
import { render } from 'solid-js/web';
import 'solid-devtools';
import {A, Route, Router} from '@solidjs/router';

import App, {Playset, Setting} from './App';

const root = document.getElementById('root');

if (import.meta.env.DEV && !(root instanceof HTMLElement)) {
  throw new Error(
    'Root element not found. Did you forget to add it to your index.html? Or maybe the id attribute got misspelled?',
  );
}
const Shell = (props: any)=>{
    
    return <>
        
        <div class={"flex flex-col justify-center"}>
                <div role="tablist" class="tabs tabs-sm tabs-box w-fit mx-auto bg-base-200 mt-3">
                    <A role="tab" class="tab"  href={"/"}>Home</A>
                    <A role="tab" class="tab " href={"playset"}>Playset</A>
                    <A role="tab" class="tab" href={"setting"}>Setting</A>
                </div>
            
            <div class={"grow"}>
                {props.children}

            </div>
        </div>
        
    </>
};
render(() => <Router root={Shell}>
    <Route component={App} path={"/"}/>
    <Route component={Playset} path={"/playset"} />
    <Route component={Setting} path={"/setting"} />
</Router>, root!);

export const External = window.external as any;
