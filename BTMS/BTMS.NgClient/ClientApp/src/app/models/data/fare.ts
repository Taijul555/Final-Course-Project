import { BusType, FareType } from "src/app/shared/app-constant";

export interface Fare {
    fareId?:number;
    seatFare?:number;
    busRouteId?: number;
    busType?:BusType;
    fareType?:FareType;
}
