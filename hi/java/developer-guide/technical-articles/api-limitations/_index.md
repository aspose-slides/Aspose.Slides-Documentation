---
title: आउटपुट मेटाडाटा सीमाएँ
type: docs
weight: 320
url: /hi/java/api-limitations/
keywords:
- API सीमाएँ
- निर्यात स्वरूप
- एप्लिकेशन
- प्रोड्यूसर
- दस्तावेज़ गुण
- मेटाडाटा
- जनरेटर
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java सहेजे गए PPTX, PDF और ODP फ़ाइलों में स्थिर एप्लिकेशन, निर्माता और प्रोड्यूसर मेटाडाटा लिखता है, चाहे आप जो भी एप्लिकेशन नाम सेट करें।"
---
## **समीक्षा**

जब Aspose.Slides के साथ प्रस्तुतियाँ बनाई या निर्यात की जाती हैं, तो कुछ तकनीकी मेटाडाटा आउटपुट फ़ाइल में लिखा जाता है। यह लेख PPTX, PDF और ODP फ़ाइलों में `Application`, `Creator`, `Producer` और generator मेटाडाटा फ़ील्ड्स से संबंधित सीमाओं को समझाता है।

## **एप्लिकेशन और प्रोड्यूसर**

जब आप Aspose.Slides for Java के साथ प्रस्तुतियाँ बनाते या निर्यात करते हैं, तो कुछ तकनीकी मेटाडाटा फ़ाइल में लिखा जाता है। दो फ़ील्ड अक्सर प्रश्न उठाते हैं:

**Application** उस प्रोग्राम की पहचान करता है जिसने **PPTX** प्रस्तुति बनाई या अंतिम बार सहेजी। Aspose.Slides for Java में, यह मान स्थिर होता है और आपके ऐप के नाम के बजाय लाइब्रेरी का नाम दिखाता है, चाहे आप [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hi/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) का उपयोग करें।

**Producer** रेंडरिंग इंजन की पहचान करता है जिसने निर्यात के दौरान अंतिम फ़ाइल उत्पन्न की। **PDF** निर्यात में, मेटाडाटा **Creator** और **Producer** फ़ील्ड का उपयोग करता है। Aspose.Slides for Java के साथ, दोनों फ़ील्ड स्थिर होते हैं और लाइब्रेरी तथा उसके संस्करण को दर्शाते हैं।

**सीमाएँ**

आप इन फ़ील्ड्स को API के माध्यम से उपर्युक्त फ़ॉर्मैट्स में ओवरराइड नहीं कर सकते। **PPTX** के लिए, Application प्रॉपर्टी को "Aspose.Slides for Java" के रूप में लिखा जाता है। **PDF** के लिए, Creator और Producer प्रॉपर्टी को "Aspose.Slides for Java" के साथ लाइब्रेरी संस्करण के रूप में लिखा जाता है। **ODP** के लिए, generator फ़ील्ड को "Aspose.Slides for Java" के साथ लाइब्रेरी संस्करण के रूप में लिखा जाता है। यह व्यवहार डिज़ाइन द्वारा निर्धारित है और फ़ाइल को लोड या सहेजने के तरीके से, और [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hi/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) के द्वारा निर्धारित मानों से स्वतंत्र होता है।

यह प्रतिबंध **PPT** फ़ाइलों पर लागू नहीं होता: PPT फ़ाइल में, वह एप्लिकेशन नाम जो आप [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hi/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) के साथ सेट करते हैं, सहेजा जाता है।