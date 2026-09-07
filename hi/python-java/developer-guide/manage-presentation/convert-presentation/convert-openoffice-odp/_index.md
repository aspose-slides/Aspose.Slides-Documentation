---
title: Python में OpenDocument प्रस्तुतियों को बदलें
linktitle: OpenDocument बदलें
type: docs
weight: 10
url: /hi/python-java/convert-openoffice-odp/
keywords:
- ODP परिवर्तित करें
- ODP से PDF
- ODP से HTML
- ODP से TIFF
- ODP से PPT
- ODP से PPTX
- ODP से XPS
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ OpenDocument (ODP) प्रस्तुतियों को PDF, HTML और अन्य फ़ॉर्मेट में बदलें, बिना OpenOffice या LibreOffice स्थापित किए।"
---
## **परिचय**

Aspose.Slides for Python via Java आपको OpenDocument (ODP) प्रस्तुतियों को PDF, HTML, TIFF, XPS, PPT, और PPTX जैसे फ़ॉर्मेट में बदलने देता है। ODP रूपांतरण PowerPoint रूपांतरण के समान API का उपयोग करता है: स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) से लोड करें और आउटपुट फ़ॉर्मेट चुनें [SaveFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/) के साथ।

## **ODP को PDF में बदलें**

उदाहरण चलाने से पहले [स्थापना निर्देश](/slides/hi/python-java/installation/) का पालन करें। कार्य निर्देशिका में `pres.odp` नामक ODP प्रस्तुति रखें। नीचे दिया गया कोड आवश्यक होने पर JVM शुरू करता है, प्रस्तुति लोड करता है, और उसे `pres.pdf` के रूप में सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **विभिन्न अनुप्रयोगों में OpenDocument प्रस्तुति**

एक ODP प्रस्तुति PowerPoint और LibreOffice/OpenOffice Impress में अलग दिख सकती है क्योंकि ये अनुप्रयोग विभिन्न प्रस्तुति सुविधाएँ और रेंडरिंग व्यवहार का समर्थन करते हैं। जटिल स्वरूपण पर निर्भर लेआउट होने पर परिवर्तित प्रस्तुतियों की समीक्षा करें।

संगतता अंतर निम्नलिखित को प्रभावित कर सकते हैं:
- टेबल, जिसमें अन्य आकारों के सापेक्ष उनकी स्टैकिंग क्रम और चित्र भराव का समर्थन शामिल है।
- पाठ का घुमाव और संरेखण।
- पाठ पर लागू चित्र, ग्रेडिएंट, और पैटर्न भराव।
- क्रमांकित और बुलेटेड सूचियाँ।

नीचे की छवि LibreOffice Impress में बनाई गई एक सूची को दर्शाती है:
![LibreOffice Impress में ODP सूची उदाहरण](odp-list-example.png)

Aspose.Slides LibreOffice/OpenOffice Impress के साथ संगतता के लिए ODP सूचियों को सहेजता है।

विस्तार के लिए फीचर संगतता देखें [Microsoft का OpenDocument प्रस्तुति फ़ॉर्मेट गाइड](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0)।

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि मेरे ODP फ़ाइल का स्वरूपण रूपांतरण के बाद बदल जाता है तो क्या होगा?**

ODP और PowerPoint विभिन्न प्रस्तुति मॉडेल का उपयोग करते हैं। टेबल, फ़ॉन्ट, और भराव शैलियाँ अलग दिख सकती हैं। सुनिश्चित करें कि आवश्यक फ़ॉन्ट उपलब्ध हैं, आउटपुट की समीक्षा करें, और आवश्यक होने पर लेआउट या स्वरूपण को समायोजित करें।

**ODP फ़ाइलों को रूपांतरित करने के लिए क्या मुझे OpenOffice या LibreOffice इंस्टॉल करने की आवश्यकता है?**

नहीं। Aspose.Slides for Python via Java किसी भी अनुप्रयोग के बिना प्रस्तुतियों को प्रोसेस करता है। एक संगत Java रनटाइम और Python पैकेज आवश्यक हैं।

**क्या मैं ODP प्रस्तुति को रूपांतरित करते समय PDF आउटपुट को अनुकूलित कर सकता हूँ?**

हां। PDF निर्यात सेटिंग्स, जैसे छवि गुणवत्ता और संपीड़न, को कॉन्फ़िगर करने के लिए [PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/) का उपयोग करें।

**क्या मैं सर्वर या कंटेनर में ODP प्रस्तुतियों को रूपांतरित कर सकता हूँ?**

हां। लक्ष्य वातावरण में Python पैकेज, एक संगत Java रनटाइम, और आपकी प्रस्तुतियों के लिए आवश्यक फ़ॉन्ट इंस्टॉल करें। कोई ऑफिस अनुप्रयोग आवश्यक नहीं है।