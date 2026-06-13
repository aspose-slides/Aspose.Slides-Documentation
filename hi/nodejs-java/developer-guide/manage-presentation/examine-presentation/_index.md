---
title: जावास्क्रिप्ट में प्रस्तुति जानकारी प्राप्त करें और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/nodejs-java/examine-presentation/
keywords:
- प्रस्तुति प्रारूप
- प्रस्तुति गुण
- दस्तावेज़ गुण
- गुण प्राप्त करें
- गुण पढ़ें
- गुण बदलें
- गुण संशोधित करें
- गुण अपडेट करें
- PPTX का परीक्षण
- PPT का परीक्षण
- ODP का परीक्षण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "जावास्क्रिप्ट का उपयोग करके पावरपॉइंट और ओपनडॉक्यूमेंट प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडेटा का पता लगाएँ, तेज़ अंतर्दृष्टि और अधिक समझदार सामग्री ऑडिट के लिए।"
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रस्तुति जानकारी की जांच कैसे की जाए, दर्शाता है। यह बताता है कि पूर्ण फ़ाइल लोड किए बिना प्रस्तुति का वर्तमान प्रारूप कैसे निर्धारित किया जाए, उसके दस्तावेज़ गुण पढ़ें, और आवश्यक होने पर उन गुणों को अपडेट करें।

उदाहरण [PresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/) और [DocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/) APIs पर आधारित हैं और प्रस्तुति मेटाडेटा के साथ काम करने के सामान्य संचालन को प्रदर्शित करते हैं।

## **प्रस्तुति प्रारूप जाँचें**

किसी प्रस्तुति पर काम करने से पहले, आप यह पता लगाना चाह सकते हैं कि वर्तमान में प्रस्तुति किस प्रारूप (PPT, PPTX, ODP, आदि) में है।

आप प्रस्तुति को लोड किए बिना उसके प्रारूप की जाँच कर सकते हैं। इस JavaScript कोड को देखें:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **प्रस्तुति गुण प्राप्त करें**

यह JavaScript कोड आपको दिखाता है कि प्रस्तुति गुण (प्रस्तुति के बारे में जानकारी) कैसे प्राप्त करें:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

आप [DocumentProperties वर्ग](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) के तहत गुण देखना चाह सकते हैं।

## **प्रस्तुति गुण अपडेट करें**

Aspose.Slides [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) मेथड प्रदान करता है जो प्रस्तुति गुणों में परिवर्तन करने की अनुमति देता है।

मान लीजिए हमारे पास नीचे दिखाए गए दस्तावेज़ गुणों वाला एक PowerPoint प्रस्तुति है।

![PowerPoint प्रस्तुति के मूल दस्तावेज़ गुण](input_properties.png)

यह कोड उदाहरण आपको कुछ प्रस्तुति गुणों को संपादित करने का तरीका दिखाता है:

```javascript
let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

दस्तावेज़ गुणों को बदलने के परिणाम नीचे दिखाए गए हैं।

![PowerPoint प्रस्तुति के बदले हुए दस्तावेज़ गुण](output_properties.png)

## **उपयोगी लिंक**

प्रस्तुति और उसकी सुरक्षा विशेषताओं के बारे में अधिक जानकारी प्राप्त करने के लिए, ये लिंक उपयोगी हो सकते हैं:

- [जाँचें कि क्या प्रस्तुति एन्क्रिप्टेड है](https://docs.aspose.com/slides/hi/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [जाँचें कि क्या प्रस्तुति लिखने से संरक्षित (केवल‑पढ़ने योग्य) है](https://docs.aspose.com/slides/hi/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [लोड करने से पहले जाँचें कि क्या प्रस्तुति पासवर्ड‑सुरक्षित है](https://docs.aspose.com/slides/hi/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [प्रस्तुति को सुरक्षित करने के लिए उपयोग किए गए पासवर्ड की पुष्टि करें](https://docs.aspose.com/slides/hi/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं यह कैसे जांच सकता हूँ कि फॉन्ट एंबेड हैं और कौन से हैं?**

प्रस्तुति स्तर पर [embedded-font जानकारी](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) देखें, फिर इन प्रविष्टियों की तुलना उस सेट से करें जो वास्तविक सामग्री में उपयोग किए गए फॉन्ट ([फ़ॉन्ट्स प्राप्त करें](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/getfonts/)) से है, ताकि यह पहचान सकें कि कौन से फॉन्ट रेंडरिंग के लिए महत्वपूर्ण हैं।

**मैं जल्दी से कैसे पता लगा सकता हूँ कि फ़ाइल में छिपी स्लाइड्स हैं और उनकी संख्या क्या है?**

[slide collection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/) के माध्यम से इटरेट करें और प्रत्येक स्लाइड के [visibility flag](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/gethidden/) की जाँच करें।

**क्या मैं कस्टम स्लाइड आकार और अभिविन्यास का पता लगा सकता हूँ, और क्या वे डिफ़ॉल्ट से अलग हैं?**

हाँ। वर्तमान [slide size](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getslidesize/) और अभिविन्यास की मानक प्रीसेट्स से तुलना करें; यह प्रिंटिंग और निर्यात के दौरान व्यवहार का अनुमान लगाने में मदद करता है।

**क्या कोई त्वरित तरीका है जिससे पता चल सके कि चार्ट बाहरी डेटा स्रोतों को संदर्भित करते हैं?**

हाँ। सभी [charts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/) को ट्रैवर्स करें, उनके [data source](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) की जाँच करें, और यह नोट करें कि डेटा आंतरिक है या लिंक‑आधारित, साथ ही टूटे हुए लिंक भी।

**मैं 'भारी' स्लाइड्स का मूल्यांकन कैसे करूं जो रेंडरिंग या PDF निर्यात को धीमा कर सकती हैं?**

प्रत्येक स्लाइड के लिए ऑब्जेक्ट काउंट गिनें और बड़े चित्र, ट्रांसपैरेंसी, शैडो, एनीमेशन, और मल्टीमीडिया की तलाश करें; संभावित प्रदर्शन मुद्दों को चिन्हित करने के लिए एक मोटा जटिलता स्कोर असाइन करें।