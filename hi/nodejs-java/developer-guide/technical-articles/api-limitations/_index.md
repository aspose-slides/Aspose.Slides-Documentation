---
title: API सीमाएँ
type: docs
weight: 320
url: /hi/nodejs-java/api-limitations/
keywords:
- API सीमाएँ
- निर्यात स्वरूप
- अनुप्रयोग
- उत्पादक
- दस्तावेज़ गुण
- मेटाडाटा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js की सीमाओं को जानें: निर्यात PPT, PPTX, ODP, और PDF में नियत Application/Producer मेटाडाटा सेट करते हैं—जिससे आप बिना आश्चर्य के एकीकरण की योजना बना सकते हैं।"
---
## **समालोचना**

जब Aspose.Slides के साथ प्रस्तुतियों को बनाया या निर्यात किया जाता है, कुछ तकनीकी मेटाडाटा आउटपुट फ़ाइल में लिखा जाता है। यह लेख PPTX और PDF फ़ाइलों में `Application`, `Creator`, और `Producer` मेटाडाटा फ़ील्ड्स से संबंधित सीमाओं को समझाता है।

## **Application और Producer**

जब आप Aspose.Slides for Node.js via Java के साथ प्रस्तुतियों को बनाते या निर्यात करते हैं, कुछ तकनीकी मेटाडाटा फ़ाइल में लिखा जाता है। दो फ़ील्ड अक्सर प्रश्न उत्पन्न करती हैं:

**Application** वह प्रोग्राम पहचानता है जिसने **PPTX** प्रस्तुति को बनाया या अंतिम बार सेव किया। Aspose.Slides for Node.js via Java में यह मान स्थिर होता है और लाइब्रेरी विक्रेता को दिखाता है, न कि आपके ऐप का नाम, भले ही आप [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/setnameofapplication/) का उपयोग करें।

**Producer** वह रेंडरिंग इंजन पहचानता है जिसने निर्यात के दौरान अंतिम फ़ाइल उत्पन्न की। **PDF** निर्यात में, मेटाडाटा **Creator** और **Producer** फ़ील्ड्स का उपयोग करता है। Aspose.Slides for Node.js via Java के साथ, दोनों फ़ील्ड्स स्थिर होते हैं और लाइब्रेरी तथा उसके संस्करण को प्रतिबिंबित करते हैं।

**क्या प्रतिबंधित है**

आप इन फ़ील्ड्स को ऊपर निर्दिष्ट फ़ॉर्मेट्स के लिए API के माध्यम से ओवरराइड नहीं कर सकते। **PPTX** के लिए, Application प्रॉपर्टी को "Aspose.Slides for Node.js via Java" के रूप में लिखा जाता है। **PDF** के लिए, Creator और Producer प्रॉपर्टी को "Aspose.Slides for Node.js via Java x.x.x." के रूप में लिखा जाता है। यह व्यवहार डिज़ाइन के अनुसार है और फ़ाइल को लोड या सेव करने के तरीके या [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/setnameofapplication/) के उपयोग से असाइन किए गए मानों के बावजूद लागू होता है।