import { Fare } from "./fare";

export interface BusRoute {
    busRouteId?: number;
    from?: string;
    to?: string;
    fare?:Fare;
}
