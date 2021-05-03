const addon = require('../build/Release/flightgearwebapp-native');

interface IFlightgearwebappNative
{
    greet(strName: string): string;
};

class Flightgearwebapp {
    constructor(name: string) {
        this._addonInstance = new addon.Flightgearwebapp(name)
    }

    greet (strName: string) {
        return this._addonInstance.greet(strName);
    }

    // private members
    private _addonInstance: IFlightgearwebappNative;
}

export = Flightgearwebapp;
