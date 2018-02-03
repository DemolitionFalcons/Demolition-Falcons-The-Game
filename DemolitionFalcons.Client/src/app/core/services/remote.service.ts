import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { BehaviorSubject } from 'rxjs/BehaviorSubject'
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http'


import { environment } from '../../../environments/environment';

@Injectable()
export class RemoteService {

    constructor(
        private router: Router,
        private http: HttpClient
    ) { }

    sendGameObject(gameObj): Observable<any> {
        return this.http.post<any>("http://localhost:49994/api/game", {
            headers: {
                'Content-Type': 'application/json',
                'Allow-cross-platform-origin': 'true'
            },
            body: JSON.stringify(gameObj)
        })
    }


    getHeroList(): Observable<any> {
        return this.http.get(
            "http://localhost:49994/api/characters",
        );
    }

    // sendGameObject(gameObj): Observable<any>{
    //     return this.http.post("http://localhost:49994/api/characters", gameObj)
    // }

}


