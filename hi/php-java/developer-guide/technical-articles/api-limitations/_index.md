---
title: API सीमाएँ
type: docs
weight: 320
url: /hi/php-java/api-limitations/
keywords:
- API सीमाएँ
- निर्यात प्रारूप
- एप्लिकेशन
- प्रोड्यूसर
- दस्तावेज़ प्रॉपर्टीज़
- मेटाडाटा
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP की सीमाओं को जानें: निर्यात PPT, PPTX, ODP, और PDF में स्थिर Application/Producer मेटाडाटा सेट करते हैं—ताकि आप बिना आश्चर्य के इंटीग्रेशन की योजना बना सकें।"
---
## **अवलोकन**

जब प्रस्तुतियों को Aspose.Slides के साथ बनाया या निर्यात किया जाता है, तो कुछ तकनीकी मेटाडाटा आउटपुट फ़ाइल में लिखा जाता है। यह लेख PPTX और PDF फ़ाइलों में `Application`, `Creator`, और `Producer` मेटाडाटा फ़ील्ड से संबंधित सीमाओं को समझाता है।

## **एप्लिकेशन और प्रोड्यूसर**

जब आप Aspose.Slides for PHP via Java के साथ प्रस्तुतियों को बनाते या निर्यात करते हैं, तो कुछ तकनीकी मेटाडाटा फ़ाइल में लिखा जाता है। दो फ़ील्ड अक्सर प्रश्न उठाते हैं:

**Application** उस प्रोग्राम की पहचान करता है जिसने **PPTX** प्रस्तुति बनाई या अंतिम बार सहेजी। Aspose.Slides for PHP via Java में, यह मान स्थिर होता है और लाइब्रेरी विक्रेता को दिखाता है न कि आपके ऐप का नाम, चाहे आप[DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/setnameofapplication/) का उपयोग करें।

**Producer** उस रेंडरिंग इंजन की पहचान करता है जो निर्यात के दौरान अंतिम फ़ाइल बनाता है। **PDF** निर्यात में, मेटाडाटा **Creator** और **Producer** फ़ील्ड्स का उपयोग करता है। Aspose.Slides for PHP via Java के साथ, इन दोनों को स्थिर रखा गया है और वे लाइब्रेरी तथा उसके संस्करण को दर्शाते हैं।

## **क्या प्रतिबंधित है**

आप इन फ़ील्ड्स को ऊपर बताए गए फ़ॉर्मैट्स के लिए API के माध्यम से ओवरराइड नहीं कर सकते। **PPTX** के लिए, Application प्रॉपर्टी को "Aspose.Slides for PHP via Java" के रूप में लिखा जाता है। **PDF** के लिए, Creator और Producer प्रॉपर्टी को "Aspose.Slides for PHP via Java x.x.x." के रूप में लिखा जाता है। यह व्यवहार डिज़ाइन के अनुसार है और फ़ाइल को लोड या सहेजने के तरीके से स्वतंत्र है, तथा[DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/setnameofapplication/) का उपयोग करके सेट किए गए मानों से भी मुक्त है।