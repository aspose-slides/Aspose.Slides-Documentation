---
title: आउटपुट मेटाडेटा प्रतिबंध
type: docs
weight: 320
url: /hi/net/api-limitations/
keywords:
- API प्रतिबंध
- निर्यात प्रारूप
- एप्लिकेशन
- उत्पादक
- दस्तावेज़ गुण
- मेटाडेटा
- जनरेटर
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET सहेजी गई PPTX, PDF और ODP फ़ाइलों में स्थिर एप्लिकेशन, निर्माता और प्रोड्यूसर मेटाडेटा लिखता है, चाहे आप जो भी एप्लिकेशन नाम सेट करें।"
---
## **परिचय**

जब Aspose.Slides के साथ प्रस्तुतियों को बनाया या निर्यात किया जाता है, तो कुछ तकनीकी मेटाडेटा आउटपुट फ़ाइल में लिखा जाता है। यह लेख PPTX, PDF और ODP फ़ाइलों में `Application`, `Creator`, `Producer` और generator मेटाडेटा फ़ील्ड्स से संबंधित प्रतिबंधों की व्याख्या करता है।

## **Application और Producer**

जब आप Aspose.Slides for .NET के साथ प्रस्तुतियों को बनाते या निर्यात करते हैं, तो कुछ तकनीकी मेटाडेटा फ़ाइल में लिखा जाता है। दो फ़ील्ड अक्सर प्रश्न उठाते हैं:

**Application** उस प्रोग्राम की पहचान करता है जिसने **PPTX** प्रस्तुति बनाई या अंतिम बार संग्रहीत की। Aspose.Slides for .NET में, यह मान स्थिर है और आपके ऐप के नाम की बजाय लाइब्रेरी नाम दिखाता है, भले ही आप [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) सेट करें।

**Producer** उस रेंडरिंग इंजन की पहचान करता है जिसने निर्यात के दौरान अंतिम फ़ाइल उत्पन्न की। **PDF** निर्यात में, मेटाडेटा **Creator** और **Producer** फ़ील्ड्स का उपयोग करता है। Aspose.Slides for .NET में, इन दोनों का मान स्थिर है और लाइब्रेरी और उसके संस्करण को दर्शाता है।

**क्या प्रतिबंधित है**

आप उपरोक्त प्रारूपों के लिए API के माध्यम से इन फ़ील्ड्स को ओवरराइड नहीं कर सकते। **PPTX** के लिए, Application प्रॉपर्टी को "Aspose.Slides for .NET" लिखा जाता है। **PDF** के लिए, Creator और Producer प्रॉपर्टी को "Aspose.Slides for .NET" के बाद लाइब्रेरी संस्करण लिखा जाता है। **ODP** के लिए, generator फ़ील्ड को "Aspose.Slides for .NET" के बाद लाइब्रेरी संस्करण लिखा जाता है। यह व्यवहार डिज़ाइन के अनुसार है और फ़ाइल को लोड या सेव करने के तरीके या [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) को असाइन किए गए मानों से स्वतंत्र रूप से लागू होता है।

यह प्रतिबंध **PPT** फ़ाइलों पर लागू नहीं होता: PPT फ़ाइल में, आप द्वारा [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) में सेट किया गया एप्लिकेशन नाम संचित रहता है।