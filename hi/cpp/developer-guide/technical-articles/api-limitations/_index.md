---
title: API सीमाएँ
type: docs
weight: 320
url: /hi/cpp/api-limitations/
keywords:
- API सीमाएँ
- निर्यात प्रारूप
- एप्लिकेशन
- प्रोड्यूसर
- दस्तावेज़ गुण
- मेटाडेटा
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ की सीमाओं को जानें: निर्यात PPT, PPTX, ODP, और PDF में स्थिर Application/Producer मेटाडेटा सेट करता है—जिससे आप एकीकरण की योजना बिना अचम्भे के बना सकते हैं।"
---
## **अवलोकन**

जब Aspose.Slides के साथ प्रस्तुतियों को बनाया या निर्यात किया जाता है, तो कुछ तकनीकी मेटाडेटा आउटपुट फ़ाइल में लिखा जाता है। यह लेख PPTX और PDF फ़ाइलों में `Application`, `Creator`, और `Producer` मेटाडेटा फ़ील्ड्स से संबंधित सीमाओं को समझाता है।

## **एप्लिकेशन और प्रोड्यूसर**

जब आप Aspose.Slides for C++ के साथ प्रस्तुतियों को बनाते या निर्यात करते हैं, तो कुछ तकनीकी मेटाडेटा फ़ाइल में लिखा जाता है। दो फ़ील्ड अक्सर सवाल उठाते हैं:

**Application** उस प्रोग्राम की पहचान करता है जिसने **PPTX** प्रस्तुति को बनाया या अंतिम बार सहेजा। Aspose.Slides for C++ में, यह मान स्थिर है और आपके ऐप के नाम के बजाय लाइब्रेरी विक्रेता को दिखाता है, भले ही आप [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/hi/cpp/aspose.slides/documentproperties/set_nameofapplication/) का उपयोग करें।

**Producer** उस रेंडरिंग इंजन की पहचान करता है जिसने निर्यात के दौरान अंतिम फ़ाइल उत्पन्न की। **PDF** निर्यात में, मेटाडेटा **Creator** और **Producer** फ़ील्ड का उपयोग करता है। Aspose.Slides for C++ के साथ, इन दोनों का मान स्थिर है और लाइब्रेरी एवं उसके संस्करण को दर्शाता है।

**क्या प्रतिबंधित है**

आप ऊपर बताए गए फ़ॉर्मेट्स के लिए इन फ़ील्ड्स को API के माध्यम से ओवरराइड नहीं कर सकते। **PPTX** के लिए, Application प्रॉपर्टी को "Aspose.Slides for C++" लिखा जाता है। **PDF** के लिए, Creator और Producer प्रॉपर्टी को "Aspose.Slides for C++ x.x.x" लिखा जाता है। यह व्यवहार डिज़ाइन द्वारा निर्धारित है और यह फ़ाइल को लोड या सहेजने के तरीके या [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/hi/cpp/aspose.slides/documentproperties/set_nameofapplication/) द्वारा सेट किए गए मानों से स्वतंत्र है।