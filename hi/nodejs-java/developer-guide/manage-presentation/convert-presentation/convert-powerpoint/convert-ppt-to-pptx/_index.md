---
title: Node.js में PPT को PPTX में परिवर्तित करें
linktitle: PPT से PPTX
type: docs
weight: 20
url: /hi/nodejs-java/convert-ppt-to-pptx/
keywords:
- PowerPoint परिवर्तित करें
- प्रेजेंटेशन परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPT से PPTX
- PPT को PPTX के रूप में सहेजें
- PPT को PPTX में निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides के साथ Node.js में लेगेसी PPT फ़ाइलों को PPTX में परिवर्तित करें। एकल फ़ाइल और बैच रूपांतरण, त्रुटि प्रबंधन, और फ़िडेलिटी नोट्स के लिए JavaScript उदाहरण शामिल हैं।"
---
## **सारांश**

PPT लेगेसी बाइनरी PowerPoint फ़ॉर्मेट है, जबकि PPTX नया Open XML फ़ॉर्मेट है। Aspose.Slides for Node.js via Java Microsoft PowerPoint के बिना PPT फ़ाइल को लोड कर सकता है और उसे PPTX में सहेज सकता है। यह लेख एक फ़ाइल या फ़ाइलों की डायरेक्ट्री को परिवर्तित करने का तरीका दिखाता है और परिवर्तन के बाद क्या सत्यापित करना है, इसे समझाता है।

## **PPT फ़ाइल को PPTX में परिवर्तित करें**

स्रोत फ़ाइल को [Presentation] क्लास का उपयोग करके लोड करें, फिर [Presentation.save] को [SaveFormat.Pptx] के साथ कॉल करें। `finally` ब्लॉक प्रस्तुति को डिस्पोज़ करता है और उसके संसाधनों को मुक्त करता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// लेगेसी PPT प्रस्तुति को लोड करें।
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें।
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

फ़ाइल एक्सटेंशन स्वयं आउटपुट फ़ॉर्मेट का चयन नहीं करता; यह [SaveFormat.Pptx] तर्क करता है। यदि आपको मूल PPT फ़ाइल को बनाए रखना है तो इनपुट और आउटपुट पाथ अलग रखें।

## **कई PPT फ़ाइलों को परिवर्तित करें**

निम्नलिखित उदाहरण एक डायरेक्ट्री में सभी `.ppt` फ़ाइलों को परिवर्तित करता है। प्रत्येक फ़ाइल को स्वतंत्र रूप से प्रोसेस किया जाता है, इसलिए एक विफल परिवर्तन बाकी बैच को रोकता नहीं है।

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

प्रोडक्शन वर्कलोड्स के लिए, पूरी त्रुटि को लॉग करें, तय करें कि मौजूदा आउटपुट फ़ाइल को ओवरराइट किया जा सकता है या नहीं, और विफल फ़ाइल नामों को रीट्राई या रिव्यू कतार में लिखें। खराब फ़ाइलें, बिना आवश्यक पासवर्ड के खोली गई पासवर्ड‑प्रोटेक्टेड फ़ाइलें, पहुँचा न जा सकने वाले पाथ, और असमर्थित कंटेंट सभी परिवर्तन को विफल कर सकते हैं। एन्क्रिप्टेड फ़ाइलों को लोड करने के लिए देखें [पासवर्ड‑सुरक्षित प्रस्तुतियां](/nodejs-java/password-protected-presentation/)।

## **विश्वसनीयता और लेगेसी विशेषताएँ**

परिवर्तन सामान्यतः स्लाइड्स, मास्टर, लेआउट, टेक्स्ट, शैलियाँ, चित्र, तालिकाएँ और चार्ट को संरक्षित रखता है। हालांकि, PPT और PPTX हर विशेषता को बिल्कुल एक ही तरीके से नहीं दर्शाते। ऐसी लेगेसी विशेषता जिसका PPTX में समकक्ष नहीं है, या जिसे लाइब्रेरी समर्थन नहीं करती, उसे सामान्यीकृत, हटाया या अलग तरह से प्रदर्शित किया जा सकता है।

जब परिवर्तित फ़ाइल में एनीमेशन, ट्रांज़िशन, एम्बेडेड या लिंक्ड OLE ऑब्जेक्ट, ActiveX कंट्रोल, एम्बेडेड मीडिया, अनदेखे फ़ॉन्ट, या VBA मैक्रो हों तो फ़ाइल की जाँच करें। एक साधारण PPTX फ़ाइल मैक्रो‑समर्थित फ़ॉर्मेट नहीं है, इसलिए जब VBA उपलब्ध रहना आवश्यक हो तो उचित मैक्रो‑समर्थित वर्कफ़्लो का उपयोग करें। यह भी सुनिश्चित करें कि आवश्यक फ़ॉन्ट और बाहरी संसाधन उस पर्यावरण में मौजूद हैं जहाँ परिवर्तित प्रस्तुति को खोला या रेंडर किया जाएगा।

महत्वपूर्ण दस्तावेज़ों के लिए, उत्पन्न PPTX को प्रोग्रामेटिकली पुनः खोलें और मुख्य स्लाइड गिनती व सामग्री की जाँच करें, फिर इच्छित व्यूअर में उसकी उपस्थिति और स्लाइड‑शो व्यवहार की तुलना करें। यह न मानें कि सफल [Presentation.save] कॉल यह प्रमाण है कि हर लेगेसी विशेषता का सटीक PPTX प्रतिनिधित्व है।

## **जब PPTX का उपयोग करें**

PPTX का उपयोग करें जब प्रस्तुति को वर्तमान PowerPoint संस्करणों में संपादित किया जाएगा, Open XML पैकेजों के साथ काम करने वाले सिस्टमों के साथ आदान‑प्रदान किया जाएगा, या ऐसे फ़ॉर्मेट में संग्रहीत किया जाएगा जो लेगेसी बाइनरी PPT की तुलना में निरीक्षण व पुनर्प्राप्ति में आसान हो। परिवर्तित प्रस्तुति के आपके फ़िडेलिटी चेक पास होने तक मूल PPT को अभिलेखीय या रोलबैक कॉपी के रूप में रखें।

यदि आपको PDF, HTML, चित्र, XPS, या कोई अन्य आउटपुट टाइप चाहिए, तो सभी टार्गेट्स संपादन योग्य PowerPoint विशेषताओं को संरक्षित रखेंगे, ऐसी धारणाओं के बजाय [Convert Presentations to Multiple Formats](/nodejs-java/convert-presentation/) में निर्दिष्ट फ़ॉर्मेट‑विशिष्ट मार्गदर्शन का उपयोग करें।

## **ऑनलाइन कनवर्टर**

कभी‑कभी फ़ाइल या त्वरित तुलना के लिए, आप [ऑनलाइन PPT से PPTX कनवर्टर](https://products.aspose.app/slides/hi/conversion/ppt-to-pptx) का उपयोग कर सकते हैं। दोहराने योग्य परिवर्तनों, बैच प्रोसेसिंग, या एप्लीकेशन‑लेवल एरर हैंडलिंग के लिए, Node.js via Java API का उपयोग करें।

## **संबंधित लेख**

- [PPT बनाम PPTX](/nodejs-java/ppt-vs-pptx/)
- [Node.js में प्रेजेंटेशन सहेजें](/nodejs-java/save-presentation/)
- [समर्थित फ़ाइल फ़ॉर्मेट](/nodejs-java/supported-file-formats/)
- [Node.js में प्रेजेंटेशन खोलें](/nodejs-java/open-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Microsoft PowerPoint स्थापित किए बिना PPT को PPTX में परिवर्तित कर सकता हूँ?**

हाँ। Aspose.Slides for Node.js via Java Microsoft PowerPoint की आवश्यकता के बिना प्रस्तुति फ़ाइलों को लोड और सहेज सकता है।

**क्या PPT से PPTX परिवर्तन सभी सामग्री को ठीक‑ठीक संरक्षित रखेगा?**

यह सामान्य प्रस्तुति सामग्री को संरक्षित रखता है, लेकिन हर लेगेसी या असमर्थित विशेषता के लिए सटीक फ़िडेलिटी की गारंटी नहीं है। जब फ़ाइल में मैक्रो, OLE या ActiveX ऑब्जेक्ट, मीडिया, विशेष एनीमेशन, या अनदेखे फ़ॉन्ट हों तो उत्पन्न फ़ाइल की समीक्षा करें।

**क्या मैं पासवर्ड‑सुरक्षित PPT फ़ाइल को परिवर्तित कर सकता हूँ?**

हाँ, यदि आप फ़ाइल लोड करते समय सही पासवर्ड प्रदान करते हैं। गायब या गलत पासवर्ड लोड ऑपरेशन को विफल कर देगा।

**क्या मुझे परिवर्तन के बाद PPT फ़ाइल को हटाना चाहिए?**

मूल फ़ाइल को तब तक रखें जब तक आपने PPTX को उन व्यूअर्स और वर्कफ़्लोज़ में सत्यापित नहीं कर लिया जो आपके लिए महत्वपूर्ण हैं। यह एक रोलबैक कॉपी प्रदान करता है यदि कोई लेगेसी विशेषता अलग‑अलग रूप में परिवर्तित होती है।