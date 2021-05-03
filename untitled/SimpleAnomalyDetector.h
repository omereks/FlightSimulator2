#pragma once
#include <napi.h>
using namespace Napi;

struct correlatedFeatures{
       	string feature1,feature2;  // names of the correlated features
       	float correlation;
       	Line lin_reg;
       	float threshold;
       	//Point* center;
       	//Circle circ;
       	float x;
       	float y;
       	//float radius;
       };

class SimpleAnomalyDetector : public AsyncWorker {

    private:
    	vector<correlatedFeatures> cf;
    	float threshold;

    public:
        SimpleAnomalyDetector(Function& callback);
        virtual ~SimpleAnomalyDetector();

        void Execute();
        void OnOk();
}