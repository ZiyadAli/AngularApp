import { Photo } from "./photo";


export interface Member {
    id: number;
    userName: string;
    age: number;
    knownAs: string;
    photoUrl: string;
    created: Date;
    lastActive: Date;
    gender: string;
    interests:string;
    introduction: string;
    lookingFor: string;
    city: string;
    country: string;
    photo: Photo[];
  }
  
