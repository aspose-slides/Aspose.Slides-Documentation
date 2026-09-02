---
title: Android पर PPT को PPTX में बदलें
linktitle: PPT से PPTX
type: docs
weight: 20
url: /hi/androidjava/convert-ppt-to-pptx/
keywords:
- PowerPoint बदलें
- प्रेज़ेंटेशन बदलें
- स्लाइड बदलें
- PPT बदलें
- PPT से PPTX
- PPT को PPTX के रूप में सहेजें
- PPT को PPTX में निर्यात करें
- PowerPoint
- प्रेज़ेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Android पर लेगेसी PPT फ़ाइलों को PPTX में बदलें। इसमें सिंगल‑फ़ाइल और बैच रूपांतरण, त्रुटि संभालना, और सटीकता नोट्स के लिए Java उदाहरण शामिल हैं।"
---
## **सारांश**

PPT लेगेसी बाइनरी PowerPoint फ़ॉर्मेट है, जबकि PPTX नया Open XML फ़ॉर्मेट है। Aspose.Slides for Android via Java PPT फ़ाइल को लोड कर सकता है और उसे Microsoft PowerPoint के बिना PPTX के रूप में सहेज सकता है। यह लेख दिखाता है कि कैसे एक फ़ाइल या फ़ाइलों की डायरेक्टरी को बदलें और परिवर्तन के बाद क्या सत्यापित करना है।

## **PPT फ़ाइल को PPTX में बदलें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास से लोड करें, फिर [Presentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveformat/#Pptx) के साथ कॉल करें। `finally` ब्लॉक प्रेज़ेंटेशन को डिस्पोज़ करता है और उसके संसाधनों को मुक्त करता है।

```java
// लेगेसी PPT प्रेज़ेंटेशन लोड करें.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // प्रेज़ेंटेशन को PPTX फ़ॉर्मेट में सेव करें.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

फ़ाइल एक्सटेंशन स्वयं आउटपुट फ़ॉर्मेट नहीं चुनता; यह [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveformat/#Pptx) आर्ग्युमेंट करता है। यदि आपको मूल PPT फ़ाइल बनाए रखनी है तो इनपुट और आउटपुट पाथ अलग रखें।

## **कई PPT फ़ाइलों को बदलें**

निम्नलिखित उदाहरण एक डायरेक्टरी में सभी `.ppt` फ़ाइलों को बदलता है। प्रत्येक फ़ाइल स्वतंत्र रूप से प्रोसेस की जाती है, इसलिए एक फ़ेल हुई रूपांतरण बाकी बैच को नहीं रोकती।

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

प्रोडक्शन वर्कलोड के लिए, पूर्ण एक्ससेप्शन को लॉग करें, तय करें कि मौजूदा आउटपुट फ़ाइल को ओवरराइट किया जा सकता है या नहीं, और फ़ेल हुई फ़ाइल नामों को रीट्राई या रिव्यू क्यू में लिखें। भ्रष्ट फ़ाइलें, पासवर्ड-संरक्षित फ़ाइलें बिना आवश्यक पासवर्ड खोले जाने पर, पहुँच न होने वाले पाथ, और असमर्थित कंटेंट सभी रूपांतरण को विफल कर सकते हैं। एन्क्रिप्टेड फ़ाइलों को लोड करने के लिए [Password-Protected Presentations](/androidjava/password-protected-presentation/) देखें।

## **सटीकता और लेगेसी फीचर**

रूपांतरण सामान्यतः स्लाइड, मास्टर, लेआउट, टेक्स्ट, शेप, इमेज, टेबल और चार्ट को संरक्षित करता है। हालांकि, PPT और PPTX हर फीचर को बिल्कुल समान तरीके से नहीं दर्शाते। एक लेगेसी फीचर जिसका PPTX में समकक्ष नहीं है, या लाइब्रेरी द्वारा समर्थन नहीं किया जाता, उसे सामान्यीकृत, हटाया या अलग तरीके से दिखाया जा सकता है।

यदि परिवर्तित फ़ाइल में एनिमेशन, ट्रांज़िशन, एम्बेडेड या लिंक्ड OLE ऑब्जेक्ट्स, ActiveX कंट्रोल्स, एम्बेडेड मीडिया, असामान्य फ़ॉन्ट्स, या VBA मैक्रोज़ हैं तो जाँच करें। साधारण PPTX फ़ाइल मैक्रो-सक्षम फ़ॉर्मेट नहीं है, इसलिए जब VBA उपलब्ध रहना जरूरी हो तो उचित मैक्रो-सक्षम वर्कफ़्लो का उपयोग करें। साथ ही यह सत्यापित करें कि आवश्यक फ़ॉन्ट्स और बाहरी संसाधन उस वातावरण में मौजूद हैं जहाँ परिवर्तित प्रेज़ेंटेशन खोला या रेंडर किया जाएगा।

महत्वपूर्ण दस्तावेजों के लिए, जनरेटेड PPTX को प्रोग्रामेटिकली पुनः खोलें और प्रमुख स्लाइड काउंट और कंटेंट की जाँच करें, फिर इच्छित व्यूअर में उसकी उपस्थिति और स्लाइड-शो व्यवहार की तुलना करें। यह न मानें कि सफल [Presentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) कॉल यह प्रमाण है कि प्रत्येक लेगेसी फीचर का सटीक PPTX प्रतिनिधित्व है।

## **PPTX कब उपयोग करें**

PPTX का उपयोग तब करें जब प्रेज़ेंटेशन को वर्तमान PowerPoint संस्करणों में संपादित किया जाएगा, Open XML पैकेजों के साथ काम करने वाले सिस्टमों के साथ आदान-प्रदान किया जाएगा, या ऐसे फ़ॉर्मेट में संग्रहीत किया जाए जो लेगेसी बाइनरी PPT की तुलना में निरीक्षण और रिकवरी में आसान हो। मूल PPT को एक अभिलेखीय या रोलबैक कॉपी के रूप में रखें जब तक कि परिवर्तित प्रेज़ेंटेशन आपके सटीकता जांचों को पार न कर ले।

यदि आपको PDF, HTML, इमेज, XPS, या कोई अन्य आउटपुट प्रकार चाहिए, तो सभी टार्गेट्स संपादन योग्य PowerPoint फीचर को संरक्षित रखते हैं ऐसा मानने के बजाय [Convert Presentations to Multiple Formats](/slides/hi/androidjava/convert-presentation/) में फ़ॉर्मेट-विशिष्ट गाइडेंस का उपयोग करें।

## **ऑनलाइन कनवर्टर**

कभी-कभी फ़ाइल या त्वरित तुलना के लिए, आप [online PPT to PPTX converter](https://products.aspose.app/slides/hi/conversion/ppt-to-pptx) का उपयोग कर सकते हैं। दोहराने योग्य रूपांतरण, बैच प्रोसेसिंग, या एप्लीकेशन-लेवल एरर हैंडलिंग के लिए, Android via Java API का उपयोग करें।

## **संबंधित लेख**

- [PPT vs PPTX](/slides/hi/androidjava/ppt-vs-pptx/)
- [Save Presentations on Android](/slides/hi/androidjava/save-presentation/)
- [Supported File Formats](/slides/hi/androidjava/supported-file-formats/)
- [Open Presentations on Android](/slides/hi/androidjava/open-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Microsoft PowerPoint स्थापित किए बिना PPT को PPTX में बदल सकता हूँ?**

हाँ। Aspose.Slides for Android via Java प्रेज़ेंटेशन फ़ाइलों को लोड और सेव करता है बिना Microsoft PowerPoint की आवश्यकता के।

**क्या PPT से PPTX रूपांतरण सभी कंटेंट को बिल्कुल संरक्षित रखेगा?**

यह सामान्य प्रेज़ेंटेशन कंटेंट को संरक्षित करता है, परन्तु प्रत्येक लेगेसी या असमर्थित फीचर के लिए सटीक सटीकता गारंटीकृत नहीं है। जब जनरेटेड फ़ाइल में मैक्रो, OLE या ActiveX ऑब्जेक्ट्स, मीडिया, विशिष्ट एनिमेशन, या असामान्य फ़ॉन्ट्स हों तो फ़ाइल की समीक्षा करें।

**क्या मैं पासवर्ड-संरक्षित PPT फ़ाइल को बदल सकता हूँ?**

हाँ, यदि आप फ़ाइल लोड करते समय सही पासवर्ड प्रदान करते हैं। गलत या अनुपलब्ध पासवर्ड लोड ऑपरेशन को विफल कर देगा।

**क्या मैं रूपांतरण के बाद PPT फ़ाइल को हटाना चाहिए?**

मूल फ़ाइल को तब तक रखें जब तक आप अपने लिए महत्वपूर्ण व्यूअर्स और वर्कफ़्लो में PPTX को सत्यापित नहीं कर लेते। यह एक रोलबैक कॉपी प्रदान करता है यदि लेगेसी फीचर अलग तरह से बदलता है।