---
title: JavaScript में PowerPoint प्रस्तुतियों को XML में परिवर्तित करें
linktitle: PowerPoint से XML
type: docs
weight: 145
url: /hi/nodejs-java/convert-powerpoint-to-xml/
keywords:
- PowerPoint को XML में परिवर्तित करें
- प्रेजेंटेशन को XML में परिवर्तित करें
- PPT को XML में
- PPTX को XML में
- ODP को XML में
- PowerPoint XML प्रस्तुति
- SaveFormat.Xml
- प्रेजेंटेशन को XML के रूप में सहेजें
- प्रेजेंटेशन को XML में निर्यात करें
- XML स्ट्रीम
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके JavaScript में PowerPoint और OpenDocument प्रस्तुतियों को PowerPoint XML फ़ाइलों या स्ट्रीम में परिवर्तित करें।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java PowerPoint प्रस्तुतियों को PowerPoint XML Presentation फ़ॉर्मेट में बदल सकता है। XML आउटपुट उन स्थितियों में उपयोगी है जब आपको प्रस्तुति संरचना का निरीक्षण करने, उत्पन्न दस्तावेज़ों की समस्या निवारण करने, स्वचालित परीक्षणों में आउटपुट की तुलना करने, या ऐसी कार्यप्रवाह के साथ एकीकृत करने की आवश्यकता होती है जो प्रस्तुति पैकेज की बजाय XML का उपयोग करता है।

[Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) मेथड का उपयोग करें, जिसमें [SaveFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveformat/) enumeration से `Xml` मान पास किया जाता है। आप परिणाम को सीधे फ़ाइल या स्ट्रीम में लिख सकते हैं।

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` एक PowerPoint XML Presentation बनाता है। यह PPTX पैकेज के भीतर संग्रहीत व्यक्तिगत Office Open XML भागों को निकालता नहीं है। यदि आपको सटीक PPTX पैकेज भागों की आवश्यकता है, जैसे `ppt/presentation.xml` या व्यक्तिगत स्लाइड XML फ़ाइलें, तो सीधे PPTX पैकेज की जाँच करें।
{{% /alert %}}

## **एक प्रस्तुति को XML फ़ाइल में परिवर्तित करें**

[Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उपयोग करके एक स्रोत प्रस्तुति लोड करें, और फिर आउटपुट पथ और `SaveFormat.Xml` को [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) को पास करें। स्रोत कोई भी प्रस्तुति फ़ॉर्मेट हो सकता है जो लोडिंग के लिए समर्थित है, जैसे PPT, PPTX, या ODP।

निम्नलिखित उदाहरण PPTX प्रस्तुति को XML फ़ाइल में परिवर्तित करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **XML आउटपुट को स्ट्रीम में लिखें**

जब XML को स्मृति में रखना हो या किसी अन्य घटक को पास करना हो, जैसे वेब सेवा, स्टोरेज प्रोवाइडर, या XML प्रोसेसिंग पाइपलाइन, तो [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) के स्ट्रीम ओवरलोड का उपयोग करें। निम्नलिखित उदाहरण परिणाम को Java `ByteArrayOutputStream` में लिखता है और उत्पन्न डेटा को Node.js `Buffer` में कॉपी करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // वर्कफ़्लो में अगली घटक को xmlBuffer पास करें।
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **XML की तुलना प्रस्तुति और निर्यात फ़ॉर्मेट्स से करें**

परिणाम के उपयोग के आधार पर आउटपुट फ़ॉर्मेट चुनें:

| फ़ॉर्मेट | आउटपुट | सामान्य उपयोग |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | एक PowerPoint XML Presentation | संरचना का निरीक्षण, समस्या निवारण, उत्पन्न आउटपुट की तुलना, और XML-आधारित एकीकरण |
| PPT (`.ppt`) | एक पुरानी बाइनरी प्रस्तुति फ़ाइल | पुराने PowerPoint कार्यप्रवाहों के साथ संगतता |
| PPTX (`.pptx`) | एक Office Open XML पैकेज जिसमें कई भाग होते हैं | सामान्य PowerPoint संपादन और प्रस्तुति का आदान‑प्रदान |
| PDF or TIFF | स्थिर‑लेआउट पृष्ठ या बहु‑पृष्ठ छवि | देखना, प्रिंट करना, और संग्रहण |
| PNG, JPEG, or SVG | एक व्यक्तिगत स्लाइड का रेंडर किया हुआ प्रतिनिधित्व | थंबनेल, पूर्वावलोकन, और छवि संपत्ति |
| HTML or HTML5 | वेब‑उन्मुख प्रस्तुति आउटपुट | ब्राउज़र में देखना और वेब प्रकाशन |

PPT और PPTX के विपरीत, XML आउटपुट मुख्य रूप से निरीक्षण और डेटा‑उन्मुख कार्यप्रवाहों के लिए अभिप्रेत है। PDF, TIFF, HTML और स्लाइड इमेज फ़ॉर्मेट्स के विपरीत, यह स्लाइड्स को पृष्ठों या दृश्य संपत्तियों के रूप में रेंडर करने के बजाय प्रस्तुति डेटा का प्रतिनिधित्व करता है। [समर्थित फ़ाइल फ़ॉर्मेट](/slides/hi/nodejs-java/supported-file-formats/) तालिका PowerPoint XML Presentation को केवल‑सहेजने वाले फ़ॉर्मेट के रूप में सूचीबद्ध करती है, इसलिए जब कोई कार्यप्रवाह निर्यातित फ़ाइल को फिर से Aspose.Slides में लोड करके आगे संपादन करना चाहता है, तो इसका उपयोग न करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**`SaveFormat.Xml` PPTX फ़ाइल को सहेजने के समान है क्या?**

नहीं। PPTX कई Office Open XML हिस्सों वाला पैकेज है, जबकि `SaveFormat.Xml` एक PowerPoint XML Presentation फ़ाइल बनाता है।

**क्या मैं XML आउटपुट को डिस्क पर फ़ाइल बनाए बिना सहेज सकता हूँ?**

हाँ। [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) को एक लिखने योग्य स्ट्रीम पास करें। उदाहरण के लिए, एक Java `ByteArrayOutputStream` का उपयोग करें और उसकी डेटा को Node.js `Buffer` में कॉपी करें ताकि मेमोरी में प्रोसेस किया जा सके।

**क्या Aspose.Slides निर्यातित XML फ़ाइल को फिर से लोड कर सकता है?**

नहीं। PowerPoint XML Presentation वर्तमान में केवल सहेजने के लिए समर्थित है, लोड करने के लिए नहीं। जब राउंड‑ट्रिप संपादन आवश्यक हो, तो PPTX या कोई अन्य समर्थित प्रस्तुति फ़ॉर्मेट उपयोग करें।

**क्या XML रूपांतरण प्रत्येक स्लाइड को पृष्ठ या छवि के रूप में रेंडर करता है?**

नहीं। XML रूपांतरण संरचित प्रस्तुति डेटा लिखता है। पृष्ठ‑उन्मुख आउटपुट के लिए PDF या TIFF का उपयोग करें, या व्यक्तिगत स्लाइड छवियों के लिए PNG, JPEG, और SVG का उपयोग करें।