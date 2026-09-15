---
title: API सीमाएँ
type: docs
weight: 320
url: /hi/python-java/api-limitations/
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java की सीमाओं के बारे में जानें: PPTX और PDF फ़ाइलों में स्थिर Application, Creator और Producer मेटाडेटा।"
---
## **परिचय**

जब Aspose.Slides के साथ प्रस्तुतियों को बनाया या निर्यात किया जाता है, तो कुछ तकनीकी मेटाडेटा आउटपुट फ़ाइल में लिखा जाता है। यह लेख PPTX और PDF फ़ाइलों में `Application`, `Creator`, और `Producer` मेटाडेटा फ़ील्ड्स से संबंधित सीमाओं को समझाता है।

## **एप्लिकेशन और प्रोड्यूसर**

जब आप Aspose.Slides for Python via Java के साथ प्रस्तुतियों को बनाते या निर्यात करते हैं, तो कुछ तकनीकी मेटाडेटा फ़ाइल में लिखा जाता है। दो फ़ील्ड अक्सर प्रश्न उठाते हैं:

**Application** उस प्रोग्राम की पहचान करता है जिसने **PPTX** प्रस्तुति बनाई या अंतिम बार सहेजी। Aspose.Slides for Python via Java में, यह मान स्थिर है और आपके ऐप नाम के बजाय लाइब्रेरी विक्रेता को दर्शाता है, भले ही आप [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#setnameofapplication) का उपयोग करें।

**Producer** उस रेंडरिंग इंजन की पहचान करता है जिसने निर्यात के दौरान अंतिम फ़ाइल तैयार की। **PDF** निर्यातों में, मेटाडेटा **Creator** और **Producer** फ़ील्ड्स का उपयोग करता है। Aspose.Slides for Python via Java में, इन दोनों को भी स्थिर रखो गया है और यह लाइब्रेरी तथा उसके संस्करण को दर्शाता है।

**क्या प्रतिबंधित है**

आप इन फ़ील्ड्स को API के माध्यम से ओवरराइड नहीं कर सकते। **PPTX** के लिए, Application प्रॉपर्टी "Aspose.Slides for Java" के रूप में लिखी जाती है। **PDF** के लिए, Creator और Producer प्रॉपर्टी "Aspose.Slides for Java x.x.x." के रूप में लिखी जाती हैं। यह व्यवहार डिज़ाइन के अनुसार है और फ़ाइल को लोड या सहेजने के तरीके या [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#setnameofapplication) द्वारा सेट किए गए मानों से स्वतंत्र है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं PPTX फ़ाइल में Application मान को अपने ऐप नाम से बदल सकता हूँ?**

नहीं। यह मान स्थिर है, भले ही आप [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#setnameofapplication) का उपयोग करें।

**क्या मैं PDF निर्यात में Creator और Producer फ़ील्ड्स को ओवरराइड कर सकता हूँ?**

नहीं। दोनों फ़ील्ड्स स्थिर हैं और लाइब्रेरी तथा उसके संस्करण को दर्शाते हैं, चाहे आप प्रस्तुति को कैसे भी लोड या सहेजें।