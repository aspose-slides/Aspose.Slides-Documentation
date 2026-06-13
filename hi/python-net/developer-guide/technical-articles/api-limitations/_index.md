---
title: API सीमाएँ
type: docs
weight: 210
url: /hi/python-net/api-limitations/
keywords:
- API सीमाएँ
- निर्यात प्रारूप
- एप्लिकेशन
- प्रोड्यूसर
- दस्तावेज़ गुण
- मेटाडाटा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python की सीमाओं को जानें: निर्यात में PPT, PPTX, ODP, और PDF में स्थिर Application/Producer मेटाडाटा सेट किया जाता है—जिससे आप बिना आश्चर्य के एकीकरण की योजना बना सकें।"
---
## **अवलोकन**

जब Aspose.Slides के साथ प्रस्तुतीकरण बनाए या निर्यात किए जाते हैं, तो कुछ तकनीकी मेटाडाटा आउटपुट फ़ाइल में लिखा जाता है। यह लेख PPTX और PDF फ़ाइलों में `Application`, `Creator`, और `Producer` मेटाडाटा फ़ील्ड्स से संबंधित सीमाओं को समझाता है।

## **एप्लिकेशन और प्रोड्यूसर**

जब आप Aspose.Slides for Python via .NET के साथ प्रस्तुतीकरण बनाते या निर्यात करते हैं, तो फ़ाइल में कुछ तकनीकी मेटाडाटा लिखा जाता है। दो फ़ील्ड अक्सर प्रश्न उठाते हैं:

**Application** वह प्रोग्राम पहचानता है जिसने **PPTX** प्रस्तुतीकरण बनाया या आख़िरी बार सहेजा। Aspose.Slides for Python via .NET में, यह मान स्थिर रहता है और लाइब्रेरी विक्रेता को दर्शाता है न कि आपके ऐप का नाम, चाहे आप [DocumentProperties.name_of_application](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/name_of_application/) सेट करें।

**Producer** वह रेंडरिंग इंजन पहचानता है जिसने निर्यात के दौरान अंतिम फ़ाइल बनाई। **PDF** निर्यात में, मेटाडाटा **Creator** और **Producer** फ़ील्ड्स का उपयोग करता है। Aspose.Slides for Python via .NET के साथ, दोनों फ़ील्ड स्थिर होते हैं और लाइब्रेरी तथा उसके संस्करण को दर्शाते हैं।

**क्या प्रतिबंधित है**

आप इन फ़ील्ड्स को API के माध्यम से ऊपर उल्लेखित फ़ॉर्मैट्स में ओवरराइड नहीं कर सकते। **PPTX** के लिए, Application प्रॉपर्टी को "Aspose.Slides for Python via .NET" के रूप में लिखा जाता है। **PDF** के लिए, Creator और Producer प्रॉपर्टी को "Aspose.Slides for Python via .NET x.x.x" के रूप में लिखा जाता है। यह व्यवहार डिज़ाइन के अनुसार है और इस बात से स्वतंत्र है कि आप फ़ाइल को कैसे लोड या सहेजते हैं, और चाहे आपने [DocumentProperties.name_of_application](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/name_of_application/) को कोई मान दिया हो या नहीं।