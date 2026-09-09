---
title: Python के माध्यम से Java में प्रस्तुतियाँ बनाएं
linktitle: प्रस्तुति बनाएं
type: docs
weight: 10
url: /hi/python-java/create-presentation/
keywords:
- प्रस्तुति बनाना
- नई प्रस्तुति
- PPT बनाना
- नई PPT
- PPTX बनाना
- नई PPTX
- ODP बनाना
- नई ODP
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Python के माध्यम से Java में प्रस्तुतियाँ बनाएँ—PPT, PPTX और ODP फाइलें बनाएँ, OpenDocument समर्थन का लाभ उठाएँ, और विश्वसनीय परिणामों के लिए उन्हें प्रोग्रामेटिक रूप से सहेजें।"
---
## **परिचय**

यह लेख दिखाता है कि Aspose.Slides for Python via Java के साथ प्रस्तुति कैसे बनाई जाए, पहले स्लाइड में टेक्स्ट वाला एक आकार जोड़ा जाए, और परिणाम को PPTX फ़ाइल के रूप में सहेजा जाए। FAQ आउटपुट फ़ॉर्मेट, टेम्पलेट, स्लाइड आकार, मेमोरी उपयोग, थ्रेडिंग, लाइसेंसिंग, डिजिटल सिग्नेचर और VBA समर्थन को कवर करती है।

## **प्रेजेंटेशन बनाएं**

Aspose.Slides for Python via Java में स्क्रैच से PowerPoint फ़ाइल बनाना उतना ही सरल है जितना कि आप [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास को इंस्टैंशिएट करते हैं। कन्स्ट्रक्टर स्वचालित रूप से एक खाली डेक के साथ एक ही स्लाइड प्रदान करता है, जिससे आपको आकार, टेक्स्ट, चार्ट या आपके एप्लिकेशन की किसी भी अन्य सामग्री के लिए तुरंत कैनवस मिल जाता है। एक बार जब आप उस स्लाइड को संशोधित कर लेते हैं—या नई स्लाइड जोड़ते हैं—तो आप परिणाम को PPTX, लेगेसी PPT, या यहाँ तक कि OpenDocument फ़ॉर्मेट में भी सहेज सकते हैं। नीचे दिया गया छोटा कोड उदाहरण इस वर्कफ़्लो को दर्शाता है, जिसमें पहले स्लाइड पर एक सरल आकार जोड़ा गया है।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा पहली स्लाइड प्राप्त करें।
1. [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) को प्रकार [ShapeType.Cloud](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapetype/#Cloud) के साथ [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addAutoShape) का उपयोग करके जोड़ें।
1. आकार का टेक्स्ट [TextFrame.setText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/#setText) से सेट करें।
1. प्रस्तुति को [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) के साथ [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Pptx) उपयोग करके सहेजें।

निम्नलिखित उदाहरण को Aspose.Slides for Python via Java और एक संगत Java रनटाइम की आवश्यकता है। यह JVM को शुरू करता है यदि वह पहले से चल रहा नहीं है, पहले स्लाइड पर क्लाउड आकार जोड़ता है, और प्रस्तुति को सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# एक खाली स्लाइड के साथ प्रस्तुति बनाएं।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # एक क्लाउड आकार जोड़ें और उसका टेक्स्ट सेट करें।
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![नयी प्रस्तुति](new_presentation.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं नई प्रस्तुति को कौन से प्रारूपों में सहेज सकता हूँ?**

आप इसे [PPTX, PPT, और ODP](/slides/hi/python-java/save-presentation/) में सहेज सकते हैं, तथा इसे [PDF](/slides/hi/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/hi/python-java/convert-powerpoint-to-xps/), [HTML](/slides/hi/python-java/convert-powerpoint-to-html/), [SVG](/slides/hi/python-java/render-slide-as-svg/), और [images](/slides/hi/python-java/convert-powerpoint-to-png/) सहित कई अन्य फ़ॉर्मेट में निर्यात कर सकते हैं।

**क्या मैं टेम्प्लेट (POTX/POTM) से शुरू करके नियमित PPTX के रूप में सहेज सकता हूँ?**

हाँ। टेम्प्लेट लोड करें और वांछित फ़ॉर्मेट में सहेजें; POTX/POTM/PPTM और समान फ़ॉर्मेट [समर्थित](/slides/hi/python-java/supported-file-formats/) हैं।

**प्रेजेंटेशन बनाते समय स्लाइड का आकार/अस्पेक्ट रेशियो कैसे नियंत्रित करूँ?**

[slide size](/slides/hi/python-java/slide-size/) सेट करें (जैसे 4:3, 16:9 जैसे प्रीसेट या कस्टम डाइमेंशन) और तय करें कि सामग्री कैसे स्केल होनी चाहिए।

**आकार और कोऑर्डिनेट किस इकाई में मापे जाते हैं?**

पॉइंट्स में: 1 इंच बराबर 72 यूनिट्स है।

**बहुत बड़ी प्रस्तुतियों (कई मीडिया फ़ाइलों के साथ) को मेमोरी उपयोग कम करने के लिए कैसे संभालूँ?**

[Blob management strategies](/slides/hi/python-java/manage-blob/) का उपयोग करें, अस्थायी फ़ाइलों के माध्यम से इन‑मेमाॎ स्टोरेज को सीमित करें, और शुद्ध इन‑मेमाॎ स्ट्रीम के बजाय फ़ाइल‑आधारित वर्कफ़्लो को प्राथमिकता दें।

**क्या मैं समानांतर में प्रस्तुतियों को बना/सहेज सकता हूँ?**

आप एक ही [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस को [multiple threads](/slides/hi/python-java/multithreading/) से नहीं चला सकते। प्रत्येक थ्रेड या प्रोसेस के लिए अलग, अलग इंस्टेंस चलाएँ।

**ट्रायल वॉटरमार्क और प्रतिबंधों को कैसे हटाऊँ?**

प्रति प्रोसेस एक बार [लाइसेंस लागू](/slides/hi/python-java/licensing/) करें। लाइसेंस XML को अपरिवर्तित रखना आवश्यक है, और यदि कई थ्रेड शामिल हों तो लाइसेंस सेटअप को सिंक्रनाइज़ करना चाहिए।

**क्या मैं बनाई गई PPTX पर डिजिटल सिग्नेचर लगा सकता हूँ?**

हाँ। [Digital signatures](/slides/hi/python-java/digital-signature-in-powerpoint/) (जोड़ना और सत्यापित करना) प्रस्तुतियों के लिए समर्थित हैं।

**क्या बनाई गई प्रस्तुतियों में मैक्रो (VBA) समर्थित है?**

हाँ। आप [VBA प्रोजेक्ट बन/संपादित](/slides/hi/python-java/presentation-via-vba/) कर सकते हैं और PPTM/PPSM जैसे मैक्रो‑सक्षम फ़ाइलें सहेज सकते हैं।