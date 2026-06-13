---
title: "API सीमाएँ"
type: docs
weight: 320
url: /hi/java/api-limitations/
keywords:
- "API सीमाएँ"
- "निर्यात स्वरूप"
- "एप्लिकेशन"
- "उत्पादक"
- "दस्तावेज़ गुण"
- "मेटाडेटा"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुतीकरण"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Java की सीमाओं को जानें: निर्यात PPT, PPTX, ODP, और PDF में स्थिर Application/Producer मेटाडेटा सेट करते हैं—जो आपके एकीकरण योजना को बिना आश्चर्य के मदद करता है।"
---
## **अवलोकन**

जब Aspose.Slides के साथ प्रस्तुति बनाई या निर्यात की जाती है, तो कुछ तकनीकी मेटाडेटा आउटपुट फ़ाइल में लिखा जाता है। यह लेख PPTX और PDF फ़ाइलों में `Application`, `Creator`, और `Producer` मेटाडेटा फ़ील्ड्स से संबंधित प्रतिबंधों को समझाता है।

## **Application और Producer**

जब आप Aspose.Slides for Java के साथ प्रस्तुति बनाते या निर्यात करते हैं, तो कुछ तकनीकी मेटाडेटा फ़ाइल में लिखा जाता है। दो फ़ील्ड अक्सर प्रश्न उठाते हैं:

**Application** उस प्रोग्राम को पहचानता है जिसने **PPTX** प्रस्तुति बनाई या अंतिम बार सहेजी। Aspose.Slides for Java में, यह मान स्थिर है और लाइब्रेरी विक्रेता को दर्शाता है न कि आपके ऐप का नाम, भले ही आप [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hi/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) का प्रयोग करें।

**Producer** उस रेंडरिंग इंजन को पहचानता है जिसने निर्यात के दौरान अंतिम फ़ाइल उत्पन्न की। **PDF** निर्यात में, मेटाडेटा **Creator** और **Producer** फ़ील्ड्स का उपयोग करता है। Aspose.Slides for Java के साथ, ये दोनों स्थिर हैं और लाइब्रेरी और उसके संस्करण को दर्शाते हैं।

**क्या प्रतिबंधित है**

आप उपरोक्त फ़ॉर्मेट्स के लिए API के माध्यम से इन फ़ील्ड्स को ओवरराइड नहीं कर सकते। **PPTX** के लिए, Application प्रॉपर्टी "Aspose.Slides for Java" के रूप में लिखी जाती है। **PDF** के लिए, Creator और Producer प्रॉपर्टी "Aspose.Slides for Java x.x.x." के रूप में लिखी जाती हैं। यह व्यवहार डिज़ाइन के अनुसार है और इस बात से अप्रभावित रहता है कि आप फ़ाइल को कैसे लोड या सहेजते हैं, और चाहे आप [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hi/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) का उपयोग करके कौन से मान असाइन करें।