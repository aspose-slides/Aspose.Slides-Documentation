---
title: API सीमाएँ
type: docs
weight: 320
url: /hi/net/api-limitations/
keywords:
- API सीमाएँ
- निर्यात स्वरूप
- अनुप्रयोग
- उत्पादक
- दस्तावेज़ गुण
- मेटाडेटा
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET की सीमाओं को जानें: निर्यात में PPT, PPTX, ODP, और PDF में स्थिर Application/Producer मेटाडेटा सेट किया जाता है—जिससे आप बिना आश्चर्य के एकीकरण की योजना बना सकते हैं।"
---
## **अवलोकन**

जब Aspose.Slides के साथ प्रस्तुतियों को बनाया या निर्यात किया जाता है, तो कुछ तकनीकी मेटाडाटा आउटपुट फ़ाइल में लिखा जाता है। यह लेख PPTX और PDF फ़ाइलों में `Application`, `Creator`, और `Producer` मेटाडाटा फ़ील्ड से संबंधित प्रतिबंधों को समझाता है।

## **एप्लिकेशन और प्रोड्यूसर**

जब आप Aspose.Slides for .NET के साथ प्रस्तुतियों को बनाते या निर्यात करते हैं, तो फ़ाइल में कुछ तकनीकी मेटाडाटा लिखा जाता है। दो फ़ील्ड अक्सर प्रश्न उठाते हैं:

**Application** उस प्रोग्राम को पहचानता है जिसने **PPTX** प्रस्तुति को बनाया या आखिरी बार सहेजा। Aspose.Slides for .NET में, यह मान स्थिर होता है और आपके एप्लिकेशन के नाम के बजाय लाइब्रेरी विक्रेता को दिखाता है, भले ही आप [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/hi/net/aspose.slides/documentproperties/nameofapplication/) सेट करें।

**Producer** उस रेंडरिंग इंजन को पहचानता है जिसने निर्यात के दौरान अंतिम फ़ाइल उत्पन्न की। **PDF** निर्यात में, मेटाडाटा **Creator** और **Producer** फ़ील्ड का उपयोग करता है। Aspose.Slides for .NET के साथ, इन दोनों को स्थिर रखा गया है और यह लाइब्रेरी तथा उसके संस्करण को दर्शाते हैं।

**क्या प्रतिबंधित है**

आप उपरोक्त फ़ॉर्मैट्स के लिए API के माध्यम से इन फ़ील्ड्स को ओवरराइड नहीं कर सकते। **PPTX** के लिए, Application प्रॉपर्टी को "Aspose.Slides for .NET" के रूप में लिखा जाता है। **PDF** के लिए, Creator और Producer प्रॉपर्टी को "Aspose.Slides for .NET x.x.x" के रूप में लिखा जाता है। यह व्यवहार डिजाइन द्वारा निर्धारित है और फ़ाइल को लोड या सेव करने के तरीके या [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/hi/net/aspose.slides/documentproperties/nameofapplication/) में सेट किए गए मानों से परे लागू होता है।