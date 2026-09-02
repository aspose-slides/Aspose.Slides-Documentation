---
title: Java में PPT को PPTX में बदलें
linktitle: PPT से PPTX
type: docs
weight: 20
url: /hi/java/convert-ppt-to-pptx/
keywords:
- PowerPoint को परिवर्तित करें
- प्रजेंटेशन को परिवर्तित करें
- स्लाइड को परिवर्तित करें
- PPT को परिवर्तित करें
- PPT से PPTX
- PPT को PPTX के रूप में सहेजें
- PPT को PPTX में निर्यात करें
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Java में लेगेसी PPT फ़ाइलों को PPTX में बदलें। इसमें एकल फ़ाइल और बैच रूपांतरण, त्रुटि संभालना, और सटीकता नोट्स के लिए Java उदाहरण शामिल हैं।"
---
## **अवलोकन**

PPT एक पुराना बाइनरी PowerPoint फ़ॉर्मैट है, जबकि PPTX नया Open XML फ़ॉर्मैट है। Aspose.Slides for Java Microsoft PowerPoint के बिना PPT फ़ाइल को लोड कर सकता है और उसे PPTX के रूप में सहेज सकता है। यह लेख एक फ़ाइल या फ़ाइलों की डायरेक्टरी को कैसे परिवर्तित किया जाए दिखाता है और रूपांतरण के बाद क्या सत्यापित करना है, इसे समझाता है।

## **PPT फ़ाइल को PPTX में परिवर्तित करें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास से लोड करें, फिर [Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveformat/#Pptx) के साथ कॉल करें। `finally` ब्लॉक प्रस्तुति को डिस्पोज़ करता है और उसके संसाधनों को रिलीज़ करता है।

```java
// लेगेसी PPT प्रेजेंटेशन लोड करें।
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // प्रेजेंटेशन को PPTX फ़ॉर्मैट में सहेजें।
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

फ़ाइल एक्सटेंशन स्वयं आउटपुट फ़ॉर्मैट को नहीं चुनता; यह [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveformat/#Pptx) तर्क करता है। यदि आपको मूल PPT फ़ाइल को बरकरार रखना है तो इनपुट और आउटपुट पाथ अलग रखें।

## **एकाधिक PPT फ़ाइलों को परिवर्तित करें**

निम्नलिखित उदाहरण एक डायरेक्टरी में सभी `.ppt` फ़ाइलों को परिवर्तित करता है। प्रत्येक फ़ाइल को स्वतंत्र रूप से प्रोसेस किया जाता है, इसलिए एक विफल रूपांतरण बाकी बैच को नहीं रोकता।

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

प्रोडक्शन कार्यभार के लिए, पूरी एक्सेप्शन को लॉग करें, तय करें कि मौजूदा आउटपुट फ़ाइल को ओवरराइट किया जा सकता है या नहीं, और विफल फ़ाइल नामों को रिट्राई या रिव्यू क्यू में लिखें। भ्रष्ट फ़ाइलें, पासवर्ड‑सुरक्षित फ़ाइलें जिन्हें आवश्यक पासवर्ड के बिना खोल लिया गया है, अभिगम्य पाथ, और असमर्थित सामग्री सभी रूपांतरण को असफल बना सकते हैं। एन्क्रिप्टेड फ़ाइलों को लोड करने के लिए [Password-Protected Presentations](/slides/hi/java/password-protected-presentation/) देखें।

## **सटीकता और लेगेसी फीचर्स**

रूपांतरण सामान्यतः स्लाइड्स, मास्टर्स, लेआउट्स, टेक्स्ट, शेप्स, इमेजेज, टेबल्स और चार्ट्स को संरक्षित रखता है। हालांकि, PPT और PPTX हर फीचर को बिल्कुल समान ढंग से नहीं दर्शाते। एक लेगेसी फीचर जिसका PPTX में समतुल्य नहीं है, या जो लाइब्रेरी द्वारा समर्थित नहीं है, उसे सामान्यीकृत, छोड़ा या अलग ढंग से प्रदर्शित किया जा सकता है।

परिवर्तित फ़ाइल की जाँच करें जब उसमें एनीमेशन, ट्रांज़िशन, एम्बेडेड या लिंक्ड OLE ऑब्जेक्ट्स, ActiveX कंट्रोल्स, एम्बेडेड मीडिया, अनोखे फ़ॉन्ट्स, या VBA मैक्रो हो। एक साधारण PPTX फ़ाइल मैक्रो‑सक्षम फ़ॉर्मैट नहीं है, इसलिए जब VBA उपलब्ध रहना आवश्यक हो तो उपयुक्त मैक्रो‑सक्षम वर्कफ़्लो उपयोग करें। साथ ही यह भी सत्यापित करें कि आवश्यक फ़ॉन्ट्स और बाहरी संसाधन उस वातावरण में मौजूद हों जहाँ परिवर्तित प्रस्तुति को खोला या रेंडर किया जाएगा।

महत्वपूर्ण दस्तावेज़ों के लिए, उत्पन्न PPTX को प्रोग्रामैटिकली पुनः खोलें और प्रमुख स्लाइड काउंट और सामग्री की जांच करें, फिर इच्छित दर्शक में उसकी उपस्थिति और स्लाइड‑शो व्यवहार की तुलना करें। एक सफल [Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) कॉल को इस प्रमाण के रूप में न लें कि हर लेगेसी फीचर का सटीक PPTX प्रतिनिधित्व है।

## **PPTX कब उपयोग करें**

PPTX का उपयोग तब करें जब प्रस्तुति को वर्तमान PowerPoint संस्करणों में संपादित किया जाएगा, Open XML पैकेजों के साथ काम करने वाले सिस्टमों में आदान‑प्रदान किया जाएगा, या इसे ऐसे फ़ॉर्मैट में संग्रहीत किया जाए जो लेगेसी बाइनरी PPT की तुलना में निरीक्षण और पुनर्प्राप्ति में आसान हो। परिवर्तित प्रस्तुति आपके सटीकता जाँच पास करने तक मूल PPT को अभिलेखी या रोलबैक कॉपी के रूप में रखें।

यदि आपको PDF, HTML, इमेजेज, XPS, या कोई अन्य आउटपुट प्रकार चाहिए, तो सभी लक्ष्य संपादन योग्य PowerPoint फीचर्स को संरक्षित रखेंगे, इस अनुमान के बजाय [Convert Presentations to Multiple Formats](/slides/hi/java/convert-presentation/) में फ़ॉर्मेट‑विशिष्ट मार्गदर्शन का उपयोग करें।

## **ऑनलाइन कनवर्टर**

कभी‑कभी की फ़ाइल या तेज़ तुलना के लिए, आप [online PPT to PPTX converter](https://products.aspose.app/slides/hi/conversion/ppt-to-pptx) का उपयोग कर सकते हैं। दोहराने योग्य रूपांतरण, बैच प्रोसेसिंग, या एप्लिकेशन‑लेवल एरर हैंडलिंग के लिए, Java API का उपयोग करें।

## **संबंधित लेख**

- [PPT बनाम PPTX](/slides/hi/java/ppt-vs-pptx/)
- [जावा में प्रस्तुतियों को सहेजें](/slides/hi/java/save-presentation/)
- [समर्थित फ़ाइल फ़ॉर्मैट्स](/slides/hi/java/supported-file-formats/)
- [जावा में प्रस्तुतियों को खोलें](/slides/hi/java/open-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Microsoft PowerPoint इंस्टॉल किए बिना PPT को PPTX में परिवर्तित कर सकता हूँ?**

हां। Aspose.Slides for Java Microsoft PowerPoint की आवश्यकता के बिना प्रस्तुति फ़ाइलों को लोड और सहेजता है।

**क्या PPT‑to‑PPTX रूपांतरण सभी सामग्री को बिल्कुल समान रूप से संरक्षित रखता है?**

यह सामान्य प्रस्तुति सामग्री को संरक्षित रखता है, लेकिन हर लेगेसी या असमर्थित फीचर के लिए सटीक सटीकता की गारंटी नहीं है। जब इसमें मैक्रो, OLE या ActiveX ऑब्जेक्ट्स, मीडिया, विशेष एनीमेशन, या अनोखे फ़ॉन्ट्स हों तो निर्मित फ़ाइल की समीक्षा करें।

**क्या मैं पासवर्ड‑सुरक्षित PPT फ़ाइल को परिवर्तित कर सकता हूँ?**

हां, यदि आप फ़ाइल लोड करते समय सही पासवर्ड प्रदान करते हैं। एक गुम या गलत पासवर्ड लोड ऑपरेशन को असफल कर देगा।

**क्या मुझे रूपांतरण के बाद PPT फ़ाइल को हटाना चाहिए?**

मूल को तब तक रखें जब तक आप PPTX को उन दर्शकों और वर्कफ़्लो में सत्यापित नहीं कर लेते जो आपके लिए महत्वपूर्ण हैं। यह एक रोलबैक कॉपी प्रदान करता है यदि लेगेसी फीचर अलग रूप से परिवर्तित होता है।