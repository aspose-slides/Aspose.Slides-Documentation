---
title: Java में PPT को PPTX में बदलें
linktitle: PPT से PPTX
type: docs
weight: 20
url: /hi/java/convert-ppt-to-pptx/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
- स्लाइड बदलें
- PPT बदलें
- PPT से PPTX
- PPT को PPTX के रूप में सहेजें
- PPT को PPTX में निर्यात करें
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Java में लेगेसी PPT फाइलों को PPTX में बदलें। इसमें एकल फ़ाइल और बैच परिवर्तन के लिए Java उदाहरण, त्रुटि हैंडलिंग, और सटीकता नोट्स शामिल हैं।"
---
## **अवलोकन**

PPT एक लेगेसी बाइनरी PowerPoint फ़ॉर्मेट है, जबकि PPTX नया Open XML फ़ॉर्मेट है। Aspose.Slides for Java Microsoft PowerPoint के बिना PPT फ़ाइल को लोड कर सकता है और उसे PPTX के रूप में सहेज सकता है। यह लेख दिखाता है कि एक फ़ाइल या फ़ाइलों की डायरेक्टरी को कैसे बदलें और परिवर्तन के बाद क्या सत्यापित किया जाए।

## **PPT फ़ाइल को PPTX में बदलें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास से लोड करें, फिर [Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveformat/#Pptx) के साथ कॉल करें। `finally` ब्लॉक प्रस्तुति को डिस्पोज़ करता है और उसके संसाधनों को रिलीज़ करता है।

```java
// लेगेसी PPT प्रस्तुति लोड करें.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

फ़ाइल एक्सटेंशन स्वयं आउटपुट फ़ॉर्मेट नहीं चुनता; यह [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveformat/#Pptx) तर्क करता है। यदि आपको मूल PPT फ़ाइल को बनाए रखना है तो इनपुट और आउटपुट पाथ अलग रखें।

## **एकाधिक PPT फ़ाइलों को बदलें**

निम्नलिखित उदाहरण एक डायरेक्टरी में सभी `.ppt` फ़ाइलों को बदलता है। प्रत्येक फ़ाइल स्वतंत्र रूप से प्रोसेस की जाती है, इसलिए एक विफल परिवर्तन बाकी बैच को नहीं रोकता।

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

प्रोडक्शन वर्कलोड्स के लिए, पूर्ण अपवाद को लॉग करें, तय करें कि मौजूदा आउटपुट फ़ाइल को ओवरराइट किया जा सकता है या नहीं, और विफल फ़ाइलों के नाम को रीट्राई या रिव्यू क्यू में लिखें। क्षतिग्रस्त फ़ाइलें, पासवर्ड‑प्रोटेक्टेड फ़ाइलें जिनके पास सही पासवर्ड नहीं है, अप्राप्य पाथ, और असमर्थित कंटेंट सभी परिवर्तन को विफल कर सकते हैं। एन्क्रिप्टेड फ़ाइलों को लोड करने के लिए [पासवर्ड‑प्रोटेक्टेड प्रस्तुतियां](/java/password-protected-presentation/) देखें।

## **सटीकता और लेगेसी सुविधाएँ**

परिवर्तन सामान्यतः स्लाइड, मास्टर, लेआउट, टेक्स्ट, शैप, इमेज, टेबल और चार्ट को संरक्षित रखता है। हालांकि, PPT और PPTX प्रत्येक फीचर को बिल्कुल समान तरीके से प्रस्तुत नहीं करते। ऐसा लेगेसी फीचर जिसके कोई PPTX समकक्ष नहीं है, या लाइब्रेरी द्वारा समर्थित नहीं है, सामान्यीकृत, छोड़ा या अलग ढंग से प्रदर्शित हो सकता है।

परिवर्तित फ़ाइल की जाँच करें जब उसमें एनीमेशन, ट्रांज़िशन, एम्बेडेड या लिंक्ड OLE ऑब्जेक्ट्स, ActiveX कंट्रोल्स, एम्बेडेड मीडिया, दुर्लभ फॉन्ट्स, या VBA मैक्रो हों। साधारण PPTX फ़ाइल मैक्रो‑सक्षम फ़ॉर्मेट नहीं है, इसलिए जब VBA उपलब्ध रहना आवश्यक हो तो उपयुक्त मैक्रो‑सक्षम वर्कफ़्लो उपयोग करें। साथ ही यह सत्यापित करें कि आवश्यक फॉन्ट्स और बाहरी संसाधन उस वातावरण में मौजूद हैं जहाँ परिवर्तित प्रस्तुति को खोला या रेंडर किया जाएगा।

महत्वपूर्ण दस्तावेज़ों के लिए, जनरेटेड PPTX को प्रोग्रामेटिकली पुनः खोलें और प्रमुख स्लाइड काउंट और सामग्री की जाँच करें, फिर इच्छित व्यूअर में उसकी उपस्थिति और स्लाइड‑शो व्यवहार की तुलना करें। सफल [Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) कॉल को यह प्रमाण न मानें कि प्रत्येक लेगेसी फीचर का सटीक PPTX प्रतिनिधित्व है।

## **PPTX का उपयोग कब करें**

PPTX का उपयोग तब करें जब प्रस्तुति को वर्तमान PowerPoint संस्करणों में संपादित किया जाएगा, Open XML पैकेजों के साथ काम करने वाली प्रणालियों के साथ आदान‑प्रदान किया जाएगा, या इसे ऐसे फ़ॉर्मेट में संग्रहीत किया जाए जो लेगेसी बाइनरी PPT की तुलना में निरीक्षण और पुनर्प्राप्ति में आसान हो। मूल PPT को आर्काइव या रोलबैक कॉपी के रूप में रखें जब तक कि परिवर्तित प्रस्तुति आपके फ़िडेलिटी चेक पास न कर ले।

यदि आपको PDF, HTML, छवियों, XPS या किसी अन्य आउटपुट प्रकार की आवश्यकता है, तो सभी टार्गेट्स के संपादन योग्य PowerPoint फीचर्स को संरक्षित रखेंगे, यह मानने के बजाय [Convert Presentations to Multiple Formats](/java/convert-presentation/) में दिए गए फॉर्मेट‑विशिष्ट मार्गदर्शन का उपयोग करें।

## **ऑनलाइन कनवर्टर**

कभी‑कभार फ़ाइल या तेज़ तुलना के लिए, आप [online PPT to PPTX converter](https://products.aspose.app/slides/hi/conversion/ppt-to-pptx) का उपयोग कर सकते हैं। दोहराने योग्य रूपांतरण, बैच प्रोसेसिंग, या एप्लिकेशन‑लेवल एरर हैंडलिंग के लिए, Java API का उपयोग करें।

## **संबंधित लेख**

- [PPT बनाम PPTX](/java/ppt-vs-pptx/)
- [Java में प्रस्तुतियों को सहेजें](/java/save-presentation/)
- [समर्थित फ़ाइल फ़ॉर्मेट](/java/supported-file-formats/)
- [Java में प्रस्तुतियों को खोलें](/java/open-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Microsoft PowerPoint स्थापित किए बिना PPT को PPTX में बदल सकता हूँ?**

हाँ। Aspose.Slides for Java Microsoft PowerPoint की आवश्यकता के बिना प्रस्तुति फ़ाइलों को लोड और सहेजता है।

**क्या PPT‑to‑PPTX परिवर्तन सभी सामग्री को ठीक-ठीक संरक्षित रखेगा?**

यह सामान्य प्रस्तुति सामग्री को संरक्षित रखता है, लेकिन सभी लेगेसी या असमर्थित फीचर्स के लिए सटीक फ़िडेलिटी गारंटी नहीं दी जा सकती। जब फ़ाइल में मैक्रो, OLE या ActiveX ऑब्जेक्ट्स, मीडिया, विशेष एनीमेशन, या दुर्लभ फॉन्ट्स हों तो जनरेटेड फ़ाइल की समीक्षा करें।

**क्या मैं पासवर्ड‑प्रोटेक्टेड PPT फ़ाइल को बदल सकता हूँ?**

हाँ, यदि आप फ़ाइल लोड करते समय सही पासवर्ड प्रदान करते हैं। अनुपलब्ध या गलत पासवर्ड लोड ऑपरेशन को असफल कर देता है।

**क्या परिवर्तन के बाद मुझे PPT फ़ाइल को हटाना चाहिए?**

मूल फ़ाइल को तब तक रखें जब तक आप अपने लिए महत्वपूर्ण व्यूअर्स और वर्कफ़्लोज़ में PPTX को सत्यापित नहीं कर लेते। यदि कोई लेगेसी फीचर अलग तरीके से बदलता है तो यह एक रोलबैक कॉपी प्रदान करता है।