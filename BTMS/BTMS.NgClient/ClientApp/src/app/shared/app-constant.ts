export const apiBaseUrl = 'http://localhost:5159';
export enum BusType {
  Ac = 1,
  NonAc,
  Sleeper,
  DoubleDecker,
  Luxury,
}
export enum SeatStatus {
  Available = 1,
  Booked,
  Selected,
}
export enum PaymentStatus {
  Pending = 1,
  Completed,
  Failed,
  Cancelled,
  Refunded,
}
export enum FareType {
  Regular,
  PickSeason,
  Special,
}

export const navItems = [
  {
    label: 'Bus',
    imageIcon: '/assets/logoo.ico',
    link: '/bus-list',
  },
  {
    label: 'busRoute',
    link: '/busRoute-list',
    icon: 'map',
  },
  {
    label: 'Fare',
    icon: 'attach_money',
    link: '/fare-list',
  },
];
