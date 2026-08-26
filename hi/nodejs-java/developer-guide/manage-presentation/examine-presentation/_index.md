---
title: JavaScript में प्रस्तुति जानकारी प्राप्त करना और अद्यतन करना
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/nodejs-java/examine-presentation/
keywords:
- प्रस्तुति फ़ॉर्मेट
- प्रस्तुति गुण
- दस्तावेज़ गुण
- गुण प्राप्त करें
- गुण पढ़ें
- गुण बदलें
- गुण संशोधित करें
- गुण अद्यतन करें
- PPTX जांचें
- PPT जांचें
- ODP जांचें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडेटा का अन्वेषण करें, जिससे तेज़ अंतर्दृष्टि और अधिक बुद्धिमान सामग्री ऑडिट प्राप्त हों।"
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रस्तुति जानकारी की जाँच करने का तरीका दिखाता है। यह समझाता है कि पूरी फ़ाइल को लोड किए बिना प्रस्तुति के वर्तमान फ़ॉर्मेट को कैसे निर्धारित किया जाए, उसके दस्तावेज़ गुणों को पढ़ा जाए, और आवश्यकता पड़ने पर उन गुणों को अपडेट किया जाए।

उदाहरण [PresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/) और [DocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/) API पर आधारित हैं और प्रस्तुति मेटाडेटा के साथ कार्य करने के सामान्य संचालन प्रदर्शित करते हैं।

## **प्रेजेंटेशन फ़ॉर्मेट जांचें**

प्रेजेंटेशन पर काम करने से पहले आप यह जानना चाह सकते हैं कि वर्तमान में प्रस्तुति किस फ़ॉर्मेट (PPT, PPTX, ODP, आदि) में है।

आप प्रस्तुति को लोड किए बिना उसके फ़ॉर्मेट की जाँच कर सकते हैं। इस JavaScript कोड को देखें:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **प्रेजेंटेशन प्रॉपर्टीज़ प्राप्त करें**

यह JavaScript कोड आपको दिखाता है कि प्रेजेंटेशन प्रॉपर्टीज़ (प्रेजेंटेशन के बारे में जानकारी) कैसे प्राप्त की जाए:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

आप [DocumentProperties वर्ग के अंतर्गत प्रॉपर्टीज़](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) देखना चाह सकते हैं।

## **प्रेजेंटेशन प्रॉपर्टीज़ अपडेट करें**

Aspose.Slides [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) विधि प्रदान करता है जो आपको प्रेजेंटेशन प्रॉपर्टीज़ में परिवर्तन करने की अनुमति देती है।

मान लीजिए हमारे पास नीचे दिखाए गए दस्तावेज़ प्रॉपर्टीज़ वाली एक PowerPoint प्रेजेंटेशन है।

![PowerPoint प्रस्तुति की मूल दस्तावेज़ प्रॉपर्टीज़](input_properties.png)

यह कोड उदाहरण दिखाता है कि कुछ प्रेजेंटेशन प्रॉपर्टीज़ को कैसे संपादित किया जाए:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

दस्तावेज़ प्रॉपर्टीज़ बदलने के परिणाम नीचे दिखाए गए हैं।

![PowerPoint प्रस्तुति की बदली हुई दस्तावेज़ प्रॉपर्टीज़](output_properties.png)

## **उपयोगी लिंक**

प्रेजेंटेशन और उसकी सुरक्षा विशेषताओं के बारे में अधिक जानकारी प्राप्त करने के लिए आप इन लिंक को उपयोगी पा सकते हैं:

- [प्रेजेंटेशन्स को पासवर्ड से सुरक्षित करें](/slides/hi/nodejs-java/password-protected-presentation/)
- [प्रेजेंटेशन्स को लिखित रूप से सुरक्षित रखें](/slides/hi/nodejs-java/write-protected-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जाँच सकता हूँ कि फ़ॉन्ट एम्बेडेड हैं और कौन से हैं?**

प्रेजेंटेशन स्तर पर [एम्बेडेड फ़ॉन्ट जानकारी](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) देखें, फिर उन प्रविष्टियों की तुलना [वास्तविक रूप से सामग्री में उपयोग किए गए फ़ॉन्ट्स](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/getfonts/) के सेट से करें ताकि यह पहचाना जा सके कि कौन से फ़ॉन्ट रेंडरिंग के लिये महत्वपूर्ण हैं।

**मैं जल्दी से कैसे पता कर सकता हूँ कि फ़ाइल में छिपी हुई स्लाइड्स हैं और कितनी?**

[स्लाइड कलेक्शन](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/) के माध्यम से इटरेट करें और प्रत्येक स्लाइड के [विज़िबिलिटी फ़्लैग](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/gethidden/) की जाँच करें।

**क्या मैं कस्टम स्लाइड आकार और अभिविन्यास का पता लगा सकता हूँ, और क्या वे डिफॉल्ट से अलग हैं?**

हाँ। वर्तमान [स्लाइड आकार](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getslidesize/) और अभिविन्यास की मानक प्रीसेट्स से तुलना करें; यह प्रिंटिंग और एक्सपोर्ट के लिए व्यवहार का पूर्वानुमान लगाने में मदद करता है।

**क्या चार्ट्स के बाहरी डेटा स्रोतों की जाँच का कोई तेज़ तरीका है?**

हाँ। सभी [चार्ट्स](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/) को ट्रैवर्स करें, उनके [डेटा स्रोत](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) की जाँच करें, और नोट करें कि डेटा आंतरिक है या लिंक‑आधारित, जिसमें टूटे हुए लिंक भी शामिल हैं।

**मैं 'हेवी' स्लाइड्स का मूल्यांकन कैसे कर सकता हूँ जो रेंडरिंग या PDF एक्सपोर्ट को धीमा कर सकती हैं?**

प्रत्येक स्लाइड के लिए ऑब्जेक्ट काउंट का कुल जोड़ें और बड़े चित्र, ट्रांसपरेंसी, शैडो, एनीमेशन, और मल्टीमीडिया की तलाश करें; संभावित परफॉर्मेंस हॉटस्पॉट्स को दर्शाने के लिये एक मोटा जटिलता स्कोर असाइन करें।