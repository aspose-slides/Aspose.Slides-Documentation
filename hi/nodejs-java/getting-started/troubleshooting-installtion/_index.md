---
title: "Aspose.Slides for Node.js via Java की स्थापना की समस्या निवारण"
linktitle: "स्थापना की समस्या निवारण"
type: docs
weight: 75
url: /hi/nodejs-java/troubleshooting-installation/
keywords:
- Aspose.Slides डाउनलोड
- Aspose.Slides स्थापित करें
- स्थापना समस्या निवारण
- संस्करण आवश्यकताएँ
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java की स्थापना समस्याओं को हल करें, सामान्य त्रुटियों और निर्भरताओं को ठीक करें, और PPT, PPTX और ODP के साथ सुगम कार्य सुनिश्चित करें।"
---
## **परिचय**

जब आप `npm` का उपयोग करते हुए [स्थापना](/slides/hi/nodejs-java/installation/) `aspose.slides.via.java` करते हैं, तो `java` और `node-gyp` मॉड्यूल के संकलन के दौरान त्रुटियाँ होने के कुछ मामले होते हैं। हमने इन त्रुटियों की अधिक विस्तृत जांच की है और स्थापित प्रोग्रामों और पैकेजों के संस्करणों के लिए विशिष्ट आवश्यकताओं की पहचान की है। 

## **संस्करण आवश्यकताएँ**

1. Node.js 12 और उसके पहले के संस्करणों के लिए:
   - Python 3.10 से अधिक नहीं।
   - Windows के लिए, Visual Studio Build Tools को 2017 या उससे पहले के संस्करण में स्थापित करने की सिफारिश की जाती है।
   - npm java पैकेज संस्करण: 0.12.1.

2. Node.js 13 के लिए:
   - Node.js 12 के समान आवश्यकताएँ।

3. Node.js 14 के लिए:
   - Python 3.10.
   - npm java पैकेज संस्करण: 0.14.0.

4. Node.js 15 के लिए:
   - Python 3.12.
   - npm java पैकेज संस्करण: 0.14.0.

5. Node.js 16 और उसके बाद के संस्करणों के लिए:
   - Python 3.12.
   - npm java पैकेज संस्करण: 0.14.0.

**नीचे दिए गए निर्देशों का पालन करके आवश्यक प्रोग्राम स्थापित करें।**

### **Unix पर स्थापना**

- स्थापित करें [Node.js](https://nodejs.org/en/download).
- स्थापित करें [Python](https://devguide.python.org/versions/).
- स्थापित करें Java (JDK 1.8).
- उचित C/C++ कंपाइलर टूलचेन स्थापित करें, जैसे कि [GCC](https://gcc.gnu.org).

### **macOS पर स्थापना**

- स्थापित करें [Node.js](https://nodejs.org/en/download).
- स्थापित करें [Python](https://devguide.python.org/versions/).
- Java (JDK 1.8) स्थापित करें और /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist में root अधिकार के साथ JVMCapabilities सेक्शन संशोधित करें। jdk1.8.x_xxx.jdk आपके JDK संस्करण पर निर्भर करता है। इसे इस प्रकार दिखना चाहिए: 
```
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
- `Xcode Command Line Tools` को स्वतंत्र रूप से स्थापित करने के लिए `xcode-select --install` चलाएँ। -- OR -- वैकल्पिक रूप से, यदि आपके पास पहले से ही [full Xcode installed](https://developer.apple.com/xcode/download/) है, तो आप मेन्यू `Xcode -> Open Developer Tool -> More Developer Tools...` के तहत Command Line Tools स्थापित कर सकते हैं।

### **Windows पर स्थापना**

- स्थापित करें [Node.js](https://nodejs.org/en/download).
- [Python](https://devguide.python.org/versions/) को [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation) से स्थापित करें।
- स्थापित करें Java (JDK 1.8).
- [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) स्थापित करें (यदि VS2019 से पुराने संस्करण का उपयोग कर रहे हैं तो "Visual C++ build tools" का उपयोग करें, अन्यथा "Desktop development with C++" वर्कलोड या [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) का उपयोग करके "Desktop development with C++" वर्कलोड का उपयोग करें)।

सुनिश्चित करें कि Node.js, Python और Java को PATH चर में जोड़ा गया है।

## **Node.js संस्करण 14 और उसके बाद के संस्करणों पर Java के माध्यम से Aspose.Slides for Node.js की स्थापना**

सिर्फ निम्न कमांड का प्रयोग करें:
```
npm i aspose.slides.via.java
```

## **Node.js संस्करण 12 या 13 पर Java के माध्यम से Aspose.Slides for Node.js की स्थापना**

Aspose.Slides for Node.js via Java को मैन्युअल रूप से स्थापित करना होगा। निम्न कमांड का उपयोग करें:

- Node.js 12 के लिए:
```
npm i java@0.12.1
```
- Node.js 13 के लिए: 
```
npm i java@0.13.0
```

इसके बाद, [aspose.slides.via.java](https://releases.aspose.com/slides/hi/nodejs-java/) डाउनलोड करें और इसे `node_modules/aspose.slides.via.java` फ़ोल्डर में निकालें।

## **स्थापना का सत्यापन**

स्थापना को वैध करने के लिए, अपने प्रोजेक्ट की मूल निर्देशिका में `index.js` फ़ाइल बनाएं जिसमें निम्न सामग्री हो:
```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

`node index.js` कमांड का उपयोग करके इस फ़ाइल को निष्पादित करें।

## **अतिरिक्त जानकारी**

इस लेख के दायरे में सभी संभावित समस्याओं को कवर करना संभव नहीं है। क्योंकि समस्याएँ `java` और `node-gyp` मॉड्यूल के संकलन के कारण उत्पन्न होती हैं, इसलिए निम्न लिंक भी उपयोगी होंगे:
- [java स्थापना](https://www.npmjs.com/package/java#installation) 
- [node-gyp स्थापना](https://www.npmjs.com/package/node-gyp#installation)