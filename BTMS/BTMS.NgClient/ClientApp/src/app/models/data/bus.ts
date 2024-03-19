import { BusType } from "src/app/shared/app-constant";

export interface Bus {
    busId?:number;
    name?:string;
    number?:number;
    busType?:BusType;
    capacity?:number;
}
