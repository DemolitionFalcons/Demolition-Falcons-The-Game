import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import * as Raphael from 'raphael/raphael.js';
import { PlayerService } from './player.service';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class HeroesService {

    private heroesSource = new BehaviorSubject<any>({});
    public heroesRecieved$ = this.heroesSource.asObservable();

    constructor() { }


    updateHeroes(heroes) {
        this.heroesSource.next(heroes);
    }
}