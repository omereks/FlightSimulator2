  {
    "targets": [
      {
        "target_name": "anomaly_algorithms",
        "sources": [ "SimpleAnomalyDetector.cc", "HybridAnomalyDetector.cc", "minCircle.cc" ],
        "include_dirs" : [
          "<!(node -e \"require('nan')\")"
        ]
      }
    ]
  }