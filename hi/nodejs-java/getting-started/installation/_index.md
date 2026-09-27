---
title: स्थापना
type: docs
weight: 70
url: /hi/nodejs-java/installation/
keywords:
- Aspose.Slides स्थापित करें
- Aspose.Slides डाउनलोड करें
- Aspose.Slides उपयोग करें
- Aspose.Slides स्थापना
- विंडोज
- लिनक्स
- macOS
- पॉवरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "npm से विंडोज, लिनक्स और macOS पर Java के माध्यम से Node.js के लिए Aspose.Slides स्थापित करें: आवश्यक JDK, Python, और C++ बिल्ड टूल, npm कमांड, तथा स्थापना की जाँच के लिए पहला स्क्रिप्ट।"
---
## **सारांश**

यह लेख Windows, Linux और macOS पर Java के माध्यम से Aspose.Slides for Node.js को कैसे स्थापित करें और यह जांचें कि स्थापना सही ढंग से काम कर रही है, यह समझाता है।

Aspose.Slides for Node.js via Java npm पर `aspose.slides.via.java` पैकेज के रूप में वितरित किया जाता है। यह [`java`](https://github.com/joeferner/node-java) पैकेज के माध्यम से एक Java वर्चुअल मशीन में Aspose.Slides चलाता है, जो एक नेटिव Node.js ऐडऑन है जिसे npm स्थापना के दौरान आपके कंप्यूटर पर कम्पाइल करता है। इसलिए स्थापना को, Node.js के अलावा, निम्न की आवश्यकता होती है:

- **Java Development Kit (JDK) 8 या बाद का**। केवल Java रनटाइम पर्याप्त नहीं है: निर्माण को JDK की हेडर फ़ाइलों की आवश्यकता होती है।
- **Python 3**, जिसका उपयोग निर्माण टूल [node-gyp](https://github.com/nodejs/node-gyp) करता है।
- **आपके ऑपरेटिंग सिस्टम के लिए C++ बिल्ड टूलचेन**।

## **पूर्वापेक्षाएँ स्थापित करें**

### **Windows**

1. [Node.js](https://nodejs.org/en/download) संस्करण 20 या बाद का स्थापित करें।
2. एक JDK स्थापित करें, उदाहरण के लिए [Eclipse Temurin](https://adoptium.net/), और `JAVA_HOME` पर्यावरण वेरिएबल को उसकी इंस्टॉल फ़ोल्डर पर सेट करें। निर्माण `JAVA_HOME` द्वारा संकेतित JDK का उपयोग करता है।
3. [Python 3](https://www.python.org/downloads/) स्थापित करें।
4. **Desktop development with C++** वर्कलोड के साथ [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) स्थापित करें। वर्कलोड के डिफ़ॉल्ट घटकों को रखें, जिसमें **MSVC v143 - VS 2022 C++ x64/x86 build tools** और **Windows 11 SDK** शामिल हैं। Visual Studio 2026 काम नहीं करता: `java` पैकेज के साथ कम्पाइल करने वाला node-gyp संस्करण इसे पहचानता नहीं है।

### **Linux**

Node.js संस्करण 20 या बाद का [nodejs.org](https://nodejs.org/en/download) या आपके वितरण के पैकेज स्रोत से स्थापित करें। फिर एक JDK, Python 3, और C++ बिल्ड टूल स्थापित करें। Debian और Ubuntu पर:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

Linux पर, निर्माण अतिरिक्त कॉन्फ़िगरेशन के बिना स्थापित JDK को खोज लेता है। यदि कई JDK स्थापित हैं, तो उपयोग करने वाले JDK को `JAVA_HOME` पर सेट करें।

### **macOS**

Node.js संस्करण 20 या बाद का, एक JDK, और Xcode Command Line Tools स्थापित करें, जिसमें Python 3 और C++ कंपाइलर शामिल हैं। macOS-विशिष्ट नोट्स के लिए [Troubleshooting Installation](/slides/hi/nodejs-java/troubleshooting-installation/) देखें।

## **npm से स्थापित करें**

एक प्रोजेक्ट फ़ोल्डर बनाएं और पैकेज स्थापित करें:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm Aspose.Slides को डाउनलोड करता है और `java` ब्रिज को कम्पाइल करता है, जिसमें कुछ मिनट लग सकते हैं। यदि कम्पाइल विफल हो जाता है, तो [Troubleshooting Installation](/slides/hi/nodejs-java/troubleshooting-installation/) देखें।

## **स्थापना की जाँच करें**

प्रोजेक्ट फ़ोल्डर में *hello.js* नाम की फ़ाइल नीचे दिए गए कोड के साथ बनाएं। यह एक प्रस्तुति बनाता है, उसकी पहली स्लाइड में एक टेक्स्ट बॉक्स जोड़ता है, और परिणाम को *hello.pptx* के रूप में सहेजता है:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides एक Java वर्चुअल मशीन में चलती है जो Node.js को चलाते रहती है, इसलिए प्रक्रिया को स्पष्ट रूप से समाप्त करें।
process.exit(0);
```

स्क्रिप्ट चलाएँ:

```bash
node hello.js
```

यदि प्रोजेक्ट फ़ोल्डर में *hello.pptx* दिखाई देता है, तो स्थापना काम कर रही है। Java वर्चुअल मशीन जो Aspose.Slides चलाती है, Node.js को अपने आप समाप्त होने से रोकती है, इसलिए स्क्रिप्ट `process.exit(0)` के साथ समाप्त होती है। कोड को समझाने के लिए देखें [Create Presentations](/slides/hi/nodejs-java/create-presentation/)।

## **ZIP संग्रह से स्थापित करें**

पैकेज npm पैकेज के समान सामग्री के साथ एक ZIP संग्रह के रूप में भी उपलब्ध है। इसे संग्रह से स्थापित करने के लिए:

1. ऊपर वर्णित अनुसार अपने ऑपरेटिंग सिस्टम के लिए पूर्वापेक्षाएँ स्थापित करें।
2. [Aspose.Slides for Node.js via Java डाउनलोड पृष्ठ](https://releases.aspose.com/slides/nodejs-java/) से संग्रह डाउनलोड करें।
3. एक प्रोजेक्ट फ़ोल्डर बनाएं:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

4. संग्रह को प्रोजेक्ट फ़ोल्डर के अंदर *aspose.slides.via.java* नामक सबफ़ोल्डर में निकालें, ताकि संग्रह की *package.json* *hello-slides/aspose.slides.via.java/package.json* पर स्थित हो।
5. उस फ़ोल्डर से पैकेज स्थापित करें:

    ```bash
    npm install ./aspose.slides.via.java
    ```

    npm पैकेज पर निर्भर `java` ब्रिज को इंस्टॉल करता है और उसे कम्पाइल करता है, जैसे वह npm पैकेज के लिए करता है।

6. [Check the Installation](#check-the-installation) में वर्णित अनुसार स्थापना की जाँच करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुफ्त संस्करण या ट्रायल प्रतिबंध है?**

हाँ। बिना लाइसेंस के, Aspose.Slides मूल्यांकन मोड में चलता है: यह प्रत्येक सहेजी गई स्लाइड पर एक मूल्यांकन वॉटरमार्क जोड़ता है और प्रस्तुतियों से पढ़ा गया टेक्स्ट काट देता है। इन प्रतिबंधों को हटाने के लिए, एक वैध [license](/slides/hi/nodejs-java/licensing/) लागू करें।

**मेरी स्क्रिप्ट समाप्त होने के बाद क्यों नहीं बंद होती?**

`java` पैकेज Node.js प्रक्रिया के भीतर एक Java वर्चुअल मशीन शुरू करता है, और वह वर्चुअल मशीन प्रक्रिया को चलाता रखती है। जब आपकी स्क्रिप्ट अपना कार्य समाप्त कर ले, तो `process.exit` को कॉल करें।