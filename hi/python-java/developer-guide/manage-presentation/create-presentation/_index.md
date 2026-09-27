---
title: Python के माध्यम से Java में प्रस्तुतियों का निर्माण
linktitle: प्रस्तुति बनाएँ
type: docs
weight: 10
url: /hi/python-java/create-presentation/
keywords:
- प्रस्तुति बनाएँ
- नई प्रस्तुति
- PPT बनाएँ
- नया PPT
- PPTX बनाएँ
- नया PPTX
- ODP बनाएँ
- नया ODP
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Python के माध्यम से Java में प्रस्तुतियाँ बनाएँ—PPT, PPTX और ODP फ़ाइलें उत्पन्न करें, OpenDocument समर्थन का लाभ उठाएँ, और विश्वसनीय परिणामों के लिए प्रोग्रामेटिक रूप से सहेँ।"
---
## **अवलोकन**

यह लेख दिखाता है कि Aspose.Slides for Python via Java के साथ प्रस्तुति कैसे बनाएँ, पहले स्लाइड में टेक्स्ट वाला आकार जोड़ें, और परिणाम को PPTX फ़ाइल के रूप में सहेजें। FAQ में आउटपुट फ़ॉर्मेट, टेम्प्लेट, स्लाइड आकार, मेमोरी उपयोग, थ्रेडिंग, लाइसेंसिंग, डिजिटल हस्ताक्षर और VBA समर्थन के बारे में जानकारी है।

शुरू करने से पहले, Python, JDK, JPype, और Aspose.Slides for Python via Java स्थापित करें। Windows, Linux, और macOS पर चरणों के लिए [स्थापना](/slides/hi/python-java/installation/) देखें।

## **प्रस्तुति बनाएं**

तुरंत से शुरू करके Aspose.Slides for Python via Java में PowerPoint फ़ाइल बनाना [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास को इंस्टैंशिएट करने जितना सरल है। कंस्ट्रक्टर स्वचालित रूप से एक खाली डेक जिसमें एक ही स्लाइड होती है, प्रदान करता है, जिससे आपको आकार, टेक्स्ट, चार्ट या आपके एप्लिकेशन को आवश्यक कोई भी सामग्री के लिए तुरंत कैनवस मिल जाता है। एक बार जब आप उस स्लाइड को संशोधित कर लेते हैं—या नई स्लाइड जोड़ते हैं—तो आप परिणाम को PPTX, लेगेसी PPT, या यहाँ तक कि OpenDocument फ़ॉर्मेट में सहेज सकते हैं। नीचे दिया गया छोटा कोड स्निपेट इस वर्कफ़्लो को दर्शाता है जिसमें पहले स्लाइड में एक सरल आकार जोड़ा जाता है।

1. [Presentation] क्लास का एक इंस्टेंस बनाएँ।
2. इंडेक्स 0 के द्वारा पहली स्लाइड प्राप्त करें।
3. [ShapeCollection.addAutoShape] का उपयोग करके प्रकार [ShapeType.Cloud] का एक [AutoShape] जोड़ें।
4. [TextFrame.setText] का उपयोग करके आकार के टेक्स्ट को सेट करें।
5. [Presentation.save] का उपयोग करके प्रस्तुति को [SaveFormat.Pptx] के साथ सहेजें।

निम्न उदाहरण जावा वर्चुअल मशीन (JVM) को शुरू करता है यदि वह पहले से चल नहीं रही है, पहले स्लाइड में टेक्स्ट के साथ एक क्लाउड आकार जोड़ता है, और प्रस्तुति को सहेजता है। इसे *create_presentation.py* के रूप में सहेजें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# एक खाली स्लाइड के साथ प्रस्तुति बनाएँ।
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

पैकेज स्थापित किए हुए वातावरण में स्क्रिप्ट चलाएँ:

```sh
python create_presentation.py
```

क्लाउड का शीर्ष-बायां कोना स्लाइड के बाएँ और ऊपर किनारों से 20 पॉइंट दूर है, और क्लाउड की चौड़ाई 200 पॉइंट और ऊँचाई 80 पॉइंट है। स्क्रिप्ट *new_presentation.pptx* को वर्तमान कार्य निर्देशिका में सहेजती है, जिसमें एक स्लाइड है जो क्लाउड और उसका टेक्स्ट रखती है। JVM तब तक चलती रहती है जब तक Python प्रक्रिया समाप्त नहीं होती; अधिक जानकारी के लिए [सीमाएँ और API अंतर](/slides/hi/python-java/limitations-and-api-differences/#import-the-library) देखें। बिना लाइसेंस के, Aspose.Slides प्रत्येक सहेजी गई स्लाइड में एक मूल्यांकन वाटरमार्क टेक्स्ट बॉक्स भी जोड़ता है; अधिक जानकारी के लिए [लाइसेंसिंग](/slides/hi/python-java/licensing/) देखें।

परिणाम:

![नया प्रस्तुति](new_presentation.png)

## **FAQ**

**मैं नई प्रस्तुति को किन फ़ॉर्मेट में सहेज सकता हूँ?**

आप [PPTX, PPT, and ODP](/slides/hi/python-java/save-presentation/) में सहेज सकते हैं, और [PDF](/slides/hi/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/hi/python-java/convert-powerpoint-to-xps/), [HTML](/slides/hi/python-java/convert-powerpoint-to-html/), [SVG](/slides/hi/python-java/render-a-slide-as-an-svg-image/), और [images](/slides/hi/python-java/convert-powerpoint-to-png/) सहित अन्य फ़ॉर्मेट में निर्यात कर सकते हैं।

**क्या मैं टेम्प्लेट (POTX/POTM) से शुरू कर सकता हूँ और इसे सामान्य PPTX के रूप में सहेज सकता हूँ?**

हां। टेम्प्लेट लोड करें और इच्छित फ़ॉर्मेट में सहेजें; POTX/POTM/PPTM और समान फ़ॉर्मेट [समर्थित हैं](/slides/hi/python-java/supported-file-formats/)।

**प्रस्तुति बनाते समय स्लाइड आकार/आस्पेक्ट रेशियो को कैसे नियंत्रित करूँ?**

स्लाइड का आकार सेट करें [स्लाइड आकार](/slides/hi/python-java/slide-size/) (जैसे 4:3 और 16:9 जैसे प्रीसेट या कस्टम आयाम) और चुनें कि सामग्री कैसे स्केल होनी चाहिए।

**आकार और निर्देशांक किस इकाई में मापे जाते हैं?**

पॉइंट में: 1 इंच बराबर 72 यूनिट्स।

**बहुत बड़ी प्रस्तुतियों (कई मीडिया फ़ाइलों के साथ) को मेमोरी उपयोग कम करने के लिए कैसे संभालूँ?**

[BLOB management strategies] को उपयोग करें, टेम्पररी फ़ाइलों के माध्यम से इन‑मेमाय़ स्टोरेज को सीमित करें, और शुद्ध इन‑मेमाय़ स्ट्रीम्स के बदले फ़ाइल‑आधारित वर्कफ़्लो को प्राथमिकता दें।

**क्या मैं समानांतर में प्रस्तुतियों को बना/सहेज सकता हूँ?**

आप एक ही [Presentation] इंस्टेंस को [multiple threads](/slides/hi/python-java/multithreading/) से संचालित नहीं कर सकते। प्रत्येक थ्रेड या प्रोसेस के लिए अलग, पृथक इंस्टेंस चलाएँ।

**ट्रायल वाटरमार्क और सीमाएँ कैसे हटाएँ?**

[लाइसेंस लागू करें](/slides/hi/python-java/licensing/) को प्रत्येक प्रक्रिया में एक बार लागू करें। लाइसेंस XML अपरिवर्तित रहना चाहिए, और कई थ्रेड्स के शामिल होने पर लाइसेंस सेटअप को समन्वित करना चाहिए।

**क्या मैं बनाई गई PPTX को डिजिटल रूप से साइन कर सकता हूँ?**

हां। [डिजिटल हस्ताक्षर](/slides/hi/python-java/digital-signature-in-powerpoint/) (जोड़ना और सत्यापित करना) प्रस्तुतियों के लिए समर्थित हैं।

**क्या बनाए गए प्रस्तुतियों में मैक्रो (VBA) समर्थित हैं?**

हां। आप [VBA प्रोजेक्ट बनाना/संपादित करना](/slides/hi/python-java/presentation-via-vba/) कर सकते हैं और PPTM/PPSM जैसे मैक्रो‑सक्षम फ़ाइलें सहेज सकते हैं।