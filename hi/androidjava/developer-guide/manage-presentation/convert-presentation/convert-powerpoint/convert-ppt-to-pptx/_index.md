---
title: Android पर PPT को PPTX में बदलें
linktitle: PPT से PPTX
type: docs
weight: 20
url: /hi/androidjava/convert-ppt-to-pptx/
keywords:
- PowerPoint को बदलें
- प्रस्तुति को बदलें
- स्लाइड को बदलें
- PPT को बदलें
- PPT से PPTX
- PPT को PPTX के रूप में सहेजें
- PPT को PPTX में निर्यात करें
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Android पर पुराने PPT फ़ाइलों को PPTX में बदलें। इसमें एकल फ़ाइल और बैच रूपांतरण के लिए Java उदाहरण, त्रुटि हैंडलिंग, और सटीकता नोट्स शामिल हैं।"
---
## **अवलोकन**

PPT पुराना बाइनरी PowerPoint प्रारूप है, जबकि PPTX नया Open XML प्रारूप है। Aspose.Slides for Android via Java Microsoft PowerPoint के बिना PPT फ़ाइल को लोड कर सकते हैं और उसे PPTX के रूप में सहेज सकते हैं। यह लेख दिखाता है कि एक फ़ाइल या फ़ाइलों की डायरेक्टरी को कैसे परिवर्तित करें और परिवर्तन के बाद क्या सत्यापित करना है उसका विवरण देता है।

## **PPT फ़ाइल को PPTX में बदलें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास के साथ लोड करें, फिर [Presentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveformat/#Pptx) के साथ कॉल करें। `finally` ब्लॉक प्रस्तुति को डिस्पोज़ करता है और उसके संसाधनों को मुक्त करता है।

```java
// लिगेसी PPT प्रस्तुति को लोड करें।
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // प्रस्तुति को PPTX प्रारूप में सहेजें।
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

फ़ाइल एक्सटेंशन स्वयं आउटपुट फ़ॉर्मेट का चयन नहीं करता; यह [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveformat/#Pptx) आर्ग्यूमेंट करता है। यदि आपको मूल PPT फ़ाइल को बनाए रखना है तो इनपुट और आउटपुट पाथ अलग रखें।

## **एकाधिक PPT फ़ाइलों को बदलें**

निम्न उदाहरण एक डायरेक्टरी में सभी `.ppt` फ़ाइलों को बदलता है। प्रत्येक फ़ाइल स्वतंत्र रूप से प्रोसेस की जाती है, इसलिए एक असफल परिवर्तन पूरे बैच को रोकता नहीं है।

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

प्रोडक्शन वर्कलोड के लिए, पूरी एक्सेप्शन को लॉग करें, तय करें कि मौजूदा आउटपुट फ़ाइल को ओवरराइट किया जा सकता है या नहीं, और असफल फ़ाइल नामों को रीट्राई या रिव्यू क्यू में लिखें। भ्रष्ट फ़ाइलें, पासवर्ड‑प्रोटेक्टेड फ़ाइलें जो आवश्यक पासवर्ड के बिना खोली गई हैं, असुलभ पाथ और असमर्थित कंटेंट सभी परिवर्तन को विफल कर सकते हैं। एन्क्रिप्टेड फ़ाइलें लोड करने के लिए [पासवर्ड‑सुरक्षित प्रस्तुतियाँ](/androidjava/password-protected-presentation/) देखें।

## **सटीकता और विरासत फीचर्स**

परिवर्तन सामान्यतः स्लाइड्स, मास्टर्स, लेआउट्स, टेक्स्ट, शैप्स, इमेजेज, टेबल्स और चार्ट्स को संरक्षित रखता है। लेकिन PPT और PPTX हर फीचर को बिल्कुल समान रूप में प्रस्तुत नहीं करते। कोई लेगेसी फीचर जिसके पास PPTX में समतुल्य नहीं है, या लाइब्रेरी द्वारा समर्थित नहीं है, उसे सामान्यीकृत, हटाया या अलग तरीके से दिखाया जा सकता है।

जब बदल गई फ़ाइल में एनिमेशन, ट्रांज़िशन, एम्बेडेड या लिंक्ड OLE ऑब्जेक्ट्स, ActiveX कंट्रोल्स, एम्बेडेड मीडिया, दुर्लभ फ़ॉन्ट्स, या VBA मैक्रो शामिल हों तो उसे जांचें। साधारण PPTX फ़ाइल मैक्रो‑सक्षम फ़ॉर्मेट नहीं है, इसलिए जब VBA उपलब्ध रहना आवश्यक हो तो उपयुक्त मैक्रो‑सक्षम वर्कफ़्लो उपयोग करें। साथ ही यह सुनिश्चित करें कि आवश्यक फ़ॉन्ट्स और बाहरी संसाधन उस वातावरण में मौजूद हों जहाँ बदल गई प्रस्तुति खोली या रेंडर की जाएगी।

महत्वपूर्ण दस्तावेज़ों के लिए, उत्पन्न PPTX को प्रोग्रामेटिकली फिर से खोलें और मुख्य स्लाइड काउंट और कंटेंट का निरीक्षण करें, फिर इच्छित व्यूअर में उसकी उपस्थिति और स्लाइड‑शो व्यवहार की तुलना करें। सफल [Presentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) कॉल को यह साक्ष्य न मानें कि हर लेगेसी फीचर का बिल्कुल सटीक PPTX प्रतिनिधित्व है।

## **जब PPTX का उपयोग करना चाहिए**

PPTX का उपयोग तब करें जब प्रस्तुति को वर्तमान PowerPoint संस्करणों में संपादित किया जाएगा, Open XML पैकेजों के साथ काम करने वाले सिस्टमों के साथ แลँद‑बदल किया जाएगा, या ऐसे फ़ॉर्मेट में संग्रहीत किया जाएगा जो लेगेसी बाइनरी PPT की तुलना में जांचने और पुनर्प्राप्त करने में आसान हो। मूल PPT को एक अभिलेखीय या रोलबैक कॉपी के रूप में रखें जब तक कि बदल गई प्रस्तुति आपके सटीकता जाँचों को पास न कर ले।

यदि आपको PDF, HTML, इमेजेज, XPS, या कोई अन्य आउटपुट प्रकार चाहिए, तो सभी लक्ष्यों के संपादनीय PowerPoint फीचर्स को संरक्षित रखने का अनुमान लगाने के बजाय [Convert Presentations to Multiple Formats](/androidjava/convert-presentation/) में दी गई फ़ॉर्मेट‑विशिष्ट गाइडेंस का उपयोग करें।

## **ऑनलाइन कनवर्टर**

कभी‑कभी फ़ाइल या त्वरित तुलना के लिए, आप [online PPT to PPTX converter](https://products.aspose.app/slides/hi/conversion/ppt-to-pptx) का उपयोग कर सकते हैं। दोहराने योग्य परिवर्तनों, बैच प्रोसेसिंग, या एप्लिकेशन‑लेवल एरर हैंडलिंग के लिए, Android via Java API का उपयोग करें।

## **संबंधित लेख**

- [PPT बनाम PPTX](/androidjava/ppt-vs-pptx/)
- [Android पर प्रस्तुतियों को सहेजें](/androidjava/save-presentation/)
- [समर्थित फ़ाइल फ़ॉर्मेट्स](/androidjava/supported-file-formats/)
- [Android पर प्रस्तुतियों को खोलें](/androidjava/open-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Microsoft PowerPoint स्थापित किए बिना PPT को PPTX में बदल सकता हूँ?**

हां। Aspose.Slides for Android via Java Microsoft PowerPoint की आवश्यकता के बिना प्रस्तुति फ़ाइलों को लोड और सहेजता है।

**क्या PPT‑to‑PPTX परिवर्तन सभी कंटेंट को बिल्कुल संरक्षित रखेगा?**

यह सामान्य प्रस्तुति कंटेंट को संरक्षित रखता है, लेकिन हर लेगेसी या असमर्थित फीचर के लिए सटीक सटीकता की गारंटी नहीं है। जब उत्पन्न फ़ाइल में मैक्रो, OLE या ActiveX ऑब्जेक्ट्स, मीडिया, विशिष्ट एनीमेशन्स, या दुर्लभ फ़ॉन्ट्स हों तो उसे समीक्षा करें।

**क्या मैं पासवर्ड‑सुरक्षित PPT फ़ाइल को बदल सकता हूँ?**

हां, यदि आप फ़ाइल लोड करते समय सही पासवर्ड प्रदान करते हैं। अनुपलब्ध या गलत पासवर्ड के कारण लोड ऑपरेशन विफल हो जाता है।

**क्या परिवर्तन के बाद मुझे PPT फ़ाइल को हटाना चाहिए?**

मूल फ़ाइल को तब तक रखें जब तक आप अपने लिए महत्वपूर्ण व्यूअर्स और वर्कफ़्लो में PPTX की जाँच न कर लें। यदि कोई लेगेसी फीचर अलग तरीके से बदलता है तो यह एक रोलबैक कॉपी प्रदान करता है।