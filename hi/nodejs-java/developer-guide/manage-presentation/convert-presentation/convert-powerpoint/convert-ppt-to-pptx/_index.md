---
title: Node.js में PPT को PPTX में बदलें
linktitle: PPT से PPTX
type: docs
weight: 20
url: /hi/nodejs-java/convert-ppt-to-pptx/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPT से PPTX
- PPT को PPTX के रूप में सहेजें
- PPT को PPTX में निर्यात करें
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides के साथ Node.js में पुरानी PPT फ़ाइलों को PPTX में बदलें। एकल फ़ाइल और बैच रूपांतरण, त्रुटि संभालना, और सटीकता नोट्स के लिए JavaScript उदाहरण शामिल हैं।"
---
## **सारांश**

PPT पुरानी बाइनरी PowerPoint फॉर्मेट है, जबकि PPTX नया Open XML फॉर्मेट है। Aspose.Slides for Node.js via Java Microsoft PowerPoint के बिना PPT फ़ाइल को लोड कर सकता है और उसे PPTX के रूप में सहेज सकता है। यह लेख दिखाता है कि एक फ़ाइल या फ़ाइलों की निर्देशिका को कैसे परिवर्तित किया जाए और परिवर्तन के बाद क्या सत्यापित करना है।

## **PPT फ़ाइल को PPTX में परिवर्तित करें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास से लोड करें, फिर [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveformat/) के साथ कॉल करें। `finally` ब्लॉक प्रस्तुति को समाप्त करता है और उसके संसाधनों को रिलीज़ करता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// पुरानी PPT प्रस्तुति लोड करें।
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें।
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

फ़ाइल एक्सटेंशन स्वयं आउटपुट फ़ॉर्मेट का चयन नहीं करता; यह [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveformat/) तर्क करता है। यदि आपको मूल PPT फ़ाइल को बनाए रखना है तो इनपुट और आउटपुट पाथ अलग रखें।

## **कई PPT फ़ाइलों को परिवर्तित करें**

निम्नलिखित उदाहरण एक निर्देशिका में सभी `.ppt` फ़ाइलों को परिवर्तित करता है। प्रत्येक फ़ाइल स्वतंत्र रूप से प्रोसेस होती है, इसलिए एक विफल परिवर्तन बाकी बैच को नहीं रोकता।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

प्रोडक्शन वर्कलोड्स के लिए, पूर्ण त्रुटि को लॉग करें, तय करें कि मौजूदा आउटपुट फ़ाइल को ओवरराइट किया जा सकता है या नहीं, और विफल फ़ाइल नामों को पुनः प्रयास या समीक्षा कतार में लिखें। भ्रष्ट फ़ाइलें, पासवर्ड‑सुरक्षित फ़ाइलें बिना आवश्यक पासवर्ड के खोली गईं, अभिगम्य पाथ, और असमर्थित कंटेंट सभी परिवर्तन को विफल बना सकते हैं। एन्क्रिप्टेड फ़ाइलों को लोड करने के लिए [Password-Protected Presentations](/slides/hi/nodejs-java/password-protected-presentation/) देखें।

## **सटीकता और लेगेसी फीचर्स**

परिवर्तन सामान्यतः स्लाइड्स, मास्टर्स, लेआउट्स, टेक्स्ट, शैलियों, चित्रों, तालिकाओं और चार्ट्स को संरक्षित करता है। हालांकि, PPT और PPTX हर फीचर को बिल्कुल समान रूप से प्रदर्शित नहीं करते। कोई लेगेसी फीचर जिसके लिए PPTX में समकक्ष नहीं है, या लाइब्रेरी द्वारा समर्थित नहीं है, उसे सामान्यीकृत, छोड़ा जा सकता है, या अलग तरीके से दिखाया जा सकता है।

परिवर्तित फ़ाइल की जाँच करें जब इसमें एनीमेशन, ट्रांज़ीशन, एम्बेडेड या लिंक्ड OLE ऑब्जेक्ट्स, ActiveX कंट्रोल्स, एम्बेडेड मीडिया, दुर्लभ फ़ॉन्ट्स, या VBA मैक्रोज़ हों। एक साधारण PPTX फ़ाइल मैक्रो‑सक्षम फ़ॉर्मेट नहीं है, इसलिए जब VBA उपलब्ध रहना आवश्यक हो तो उपयुक्त मैक्रो‑सक्षम वर्कफ़्लो का उपयोग करें। यह भी सत्यापित करें कि आवश्यक फ़ॉन्ट्स और बाहरी संसाधन उस वातावरण में मौजूद हैं जहाँ परिवर्तित प्रस्तुति को खोला या रेंडर किया जाएगा।

महत्वपूर्ण दस्तावेज़ों के लिए, उत्पन्न PPTX को प्रोग्रामmatically पुनः खोलें और मुख्य स्लाइड गिनती व सामग्री का निरीक्षण करें, फिर इच्छित व्यूअर में उसके दिखावट और स्लाइड‑शो व्यवहार की तुलना करें। सफल [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) कॉल को यह सिद्ध न मानें कि हर लेगेसी फीचर का सटीक PPTX प्रतिनिधित्व है।

## **PPTX कब उपयोग करें**

PPTX का उपयोग तब करें जब प्रस्तुति को वर्तमान PowerPoint संस्करणों में संपादित किया जाएगा, Open XML पैकेजों के साथ काम करने वाले सिस्टमों के साथ विनिमय किया जाएगा, या ऐसे फ़ॉर्मेट में संग्रहीत किया जाएगा जिसे लेगेसी बाइनरी PPT की तुलना में जांचना और पुनर्प्राप्त करना आसान हो। परिवर्तित प्रस्तुति के आपके सटीकता परीक्षण पास होने तक मूल PPT को संग्रह या रोलबैक कॉपी के रूप में रखें।

यदि आपको PDF, HTML, चित्र, XPS, या कोई अन्य आउटपुट टाइप चाहिए, तो सभी लक्ष्यों को संपादन योग्य PowerPoint फीचर सुरक्षित रखने का मानने के बजाय [Convert Presentations to Multiple Formats](/slides/hi/nodejs-java/convert-presentation/) में दिए गए विशेष फ़ॉर्मेट गाइडेंस का उपयोग करें।

## **ऑनलाइन रूपांतरणक**

कभी‑कभी फ़ाइल या त्वरित तुलना के लिए, आप [online PPT to PPTX converter](https://products.aspose.app/slides/hi/conversion/ppt-to-pptx) का उपयोग कर सकते हैं। दोहराने योग्य रूपांतरण, बैच प्रोसेसिंग, या एप्लिकेशन‑स्तर त्रुटि हैंडलिंग के लिए, Node.js via Java API का उपयोग करें।

## **संबंधित लेख**

- [PPT बनाम PPTX](/slides/hi/nodejs-java/ppt-vs-pptx/)
- [Node.js में प्रस्तुतियों को सहेजें](/slides/hi/nodejs-java/save-presentation/)
- [समर्थित फ़ाइल फ़ॉर्मेट](/slides/hi/nodejs-java/supported-file-formats/)
- [Node.js में प्रस्तुतियों को खोलें](/slides/hi/nodejs-java/open-presentation/)

## **प्रश्नोत्तर**

**क्या मैं Microsoft PowerPoint स्थापित किए बिना PPT को PPTX में बदल सकता हूँ?**

हाँ। Aspose.Slides for Node.js via Java Microsoft PowerPoint की आवश्यकता के बिना प्रस्तुति फ़ाइलों को लोड और सहेजता है।

**क्या PPT‑to‑PPTX रूपांतरण सभी सामग्री को बिल्कुल सुरक्षित रखेगा?**

यह सामान्य प्रस्तुति सामग्री को सुरक्षित रखता है, लेकिन हर लेगेसी या असमर्थित फीचर के लिए सटीक सटीकता की गारंटी नहीं है। जब उत्पन्न फ़ाइल में मैक्रो, OLE या ActiveX ऑब्जेक्ट्स, मीडिया, विशिष्ट एनीमेशन, या दुर्लभ फ़ॉन्ट्स हों तो उसकी समीक्षा करें।

**क्या मैं पासवर्ड‑सुरक्षित PPT फ़ाइल को बदल सकता हूँ?**

हाँ, यदि फ़ाइल लोड करते समय आप सही पासवर्ड प्रदान करते हैं। कोई पासवर्ड न देना या गलत पासवर्ड देने से लोड ऑपरेशन विफल हो जाता है।

**क्या मुझे रूपांतरण के बाद PPT फ़ाइल को हटाना चाहिए?**

आप अपने लिए महत्वपूर्ण व्यूअर्स और वर्कफ़्लोज़ में PPTX को सत्यापित करने तक मूल फ़ाइल रखें। यदि कोई लेगेसी फीचर अलग तरह से बदलता है तो यह एक रोलबैक कॉपी प्रदान करता है।