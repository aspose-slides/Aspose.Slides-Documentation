---
title: API सीमाएं
type: docs
weight: 320
url: /hi/androidjava/api-limitations/
keywords:
- API सीमाएं
- निर्यात स्वरूप
- एप्लिकेशन
- प्रोड्यूसर
- दस्तावेज़ गुण
- मेटाडाटा
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "Aspose.Slides for Android की सीमाओं को जानें: निर्यात PPT, PPTX, ODP, और PDF में स्थिर Application/Producer मेटाडाटा सेट करते हैं—आपको सहज एकीकरण के लिये बिना आश्चर्य के योजना बनाने में मदद करता है।"
---
## **परिचय**

जब प्रस्तुतियों को Aspose.Slides के साथ बनाया या निर्यात किया जाता है, तो कुछ तकनीकी मेटाडाटा आउटपुट फ़ाइल में लिखा जाता है। यह लेख PPTX और PDF फ़ाइलों में `Application`, `Creator`, और `Producer` मेटाडाटा फ़ील्ड्स से संबंधित सीमाओं की व्याख्या करता है।

## **एप्लिकेशन और प्रोड्यूसर**

जब आप Aspose.Slides for Android via Java के साथ प्रस्तुतियों को बनाते या निर्यात करते हैं, तो कुछ तकनीकी मेटाडाटा फ़ाइल में लिखा जाता है। दो फ़ील्ड अक्सर प्रश्न उठाते हैं:

**Application** यह पहचानता है कि कौन सा प्रोग्राम एक **PPTX** प्रस्तुति को बनाया या अंतिम बार सहेजा गया। Aspose.Slides for Android via Java में, यह मान स्थिर रहता है और आपके ऐप का नाम नहीं, बल्कि लाइब्रेरी विक्रेता को दर्शाता है, भले ही आप [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) का उपयोग करें।

**Producer** वह रेंडरिंग इंजन पहचानता है जिसने निर्याण के दौरान अंतिम फ़ाइल तैयार की। **PDF** निर्यात में, मेटाडाटा **Creator** और **Producer** फ़ील्ड्स का उपयोग करता है। Aspose.Slides for Android via Java के साथ, दोनों फ़ील्ड्स स्थिर होते हैं और लाइब्रेरी तथा उसके संस्करण को दर्शाते हैं।

**क्या प्रतिबंधित है**

आप इन फ़ील्ड्स को API के माध्यम से ऊपर बताई गई फ़ॉर्मैट्स के लिए ओवरराइड नहीं कर सकते। **PPTX** के लिए, Application प्रॉपर्टी "Aspose.Slides for Android via Java" के रूप में लिखी जाती है। **PDF** के लिए, Creator और Producer प्रॉपर्टी "Aspose.Slides for Android via Java x.x.x." के रूप में लिखी जाती हैं। यह व्यवहार डिज़ाइन द्वारा निर्धारित है और फ़ाइल को लोड या सहेजने के तरीके या [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) द्वारा निर्धारित मानों से स्वतंत्र रहता है।