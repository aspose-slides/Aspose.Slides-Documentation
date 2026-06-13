---
title: Aspose.Slides को Docker का उपयोग करके Java के माध्यम से Node.js के लिए इंस्टॉल करें
type: docs
weight: 75
url: /hi/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- Aspose.Slides डाउनलोड करें
- Aspose.Slides इंस्टॉल करें
- Aspose.Slides इंस्टॉलेशन
- Docker
- Windows
- macOS
- Linux
- क्रॉस-प्लैटफ़ॉर्म संगतता
- निर्भरताओं का अलगाव
- सरलीकृत परिनियोजन
- प्रोजेक्ट सेटअप
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Docker कंटेनरों में Aspose.Slides चलाएँ: इमेज, निर्भरताएँ, फ़ॉन्ट और लाइसेंसिंग को कॉन्फ़िगर करें ताकि स्केलेबल सेवाएँ बनाएं जो PowerPoint और OpenDocument को प्रोसेस करें।"
---
## आवश्यकताएँ:
* अपने मशीन पर Docker स्थापित करें। आप आधिकारिक स्थापना गाइड [यहाँ](https://docs.docker.com/get-docker/) का अनुसरण कर सकते हैं।

## चरण:

### 1. **Create Dockerfile** 
   अपने प्रोजेक्ट डायरेक्टरी में Dockerfile नामक नई फ़ाइल नीचे दिए गए सामग्री के साथ बनाएं:
   ```
   # Ubuntu 20.04 को बेस इमेज के रूप में उपयोग करें
   FROM ubuntu:20.04

   # पैकेज सूची को अपडेट करें और रिपोजिटरी जोड़ने व फ़ाइलें डाउनलोड करने के लिए आवश्यक पैकेज स्थापित करें
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # Nodesource रिपोजिटरी से Node.js संस्करण 18.x स्थापित करें
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # Python 2.x स्थापित करें, जो कुछ npm पैकेज जैसे node-gyp के लिए आवश्यक है
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # OpenJDK 11 स्थापित करें, जो Aspose.Slides के जावा निर्भरताओं के लिए आवश्यक है
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # build-essential पैकेज स्थापित करें, जिसमें 'make' जैसे उपकरण शामिल हैं जो नेटिव मॉड्यूल बनाने के लिए आवश्यक हैं
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # node-gyp को ग्लोबली स्थापित करें, एक टूल जो Node.js के लिए नेटिव ऐड-ऑन कंपाइल करने में उपयोग होता है
   RUN npm install -g node-gyp

   # कंटेनर के अंदर कार्य निर्देशिका को /app पर सेट करें
   WORKDIR /app

   # आवश्यक विवरण और निर्भरताओं के साथ package.json फ़ाइल बनाएं
   RUN echo '{\n\
     "name": "aspose-slides-app",\n\
     "version": "1.0.0",\n\
     "main": "index.js",\n\
     "scripts": {\n\
      "start": "node index.js"\n\
     },\n\
     "dependencies": {\n\
      "aspose.slides.via.java": "^25.12.0"\n\
     }\n\
   }' > package.json

   # Aspose.Slides का उपयोग करके एक प्रस्तुति बनाने के लिए नमूना कोड के साथ index.js फ़ाइल बनाएं
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # package.json में निर्दिष्ट Aspose.Slides via Java पैकेज स्थापित करें
   RUN npm install aspose.slides.via.java

   # कंटेनर शुरू होने पर एप्लिकेशन चलाने के लिए डिफॉल्ट कमांड सेट करें
   CMD ["node", "index.js"]
   ```


### 2. **Build Docker Image**
   Docker इमेज बनाने के लिए अपने Dockerfile वाले डायरेक्टरी में निम्न कमांड चलाएँ:
   ```bash
   docker build -t aspose-slides-nodejs .
   ```

### 3. **Run Docker Container**
   कंटेनर चलाएँ और उसका ID सहेजें:
   ```bash
   CONTAINER_ID=$(docker create aspose-slides-nodejs)
   docker start -a $CONTAINER_ID
   ```

### 4. **Access Aspose.Slides in Docker** 
   कंटेनर शुरू करने के बाद, स्क्रिप्ट एक PPTX फ़ाइल उत्पन्न करेगी। आप जेनरेट की गई आउटपुट फ़ाइल `NewPresentation.pptx` को कंटेनर के अंदर `/app` फ़ोल्डर में पा सकते हैं:
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```
   अस्थायी कंटेनर को हटाएँ:
   ```bash
   docker rm $CONTAINER_ID
   ```