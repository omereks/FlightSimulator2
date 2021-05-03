#pragma once

#include <napi.h>

class Flightgearwebapp : public Napi::ObjectWrap<Flightgearwebapp>
{
public:
    Flightgearwebapp(const Napi::CallbackInfo&);
    Napi::Value Greet(const Napi::CallbackInfo&);

    static Napi::Function GetClass(Napi::Env);

private:
    std::string _greeterName;
};
