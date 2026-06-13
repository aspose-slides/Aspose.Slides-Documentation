---
title: Python में प्रेज़ेंटेशन बनाएं
linktitle: प्रेज़ेंटेशन बनाएं
type: docs
weight: 10
url: /hi/python-net/create-presentation/
keywords:
- प्रेज़ेंटेशन बनाएं
- नया प्रेज़ेंटेशन
- PPT बनाएं
- नया PPT
- PPTX बनाएं
- नया PPTX
- ODP बनाएं
- नया ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में PowerPoint प्रेज़ेंटेशन बनाएं—PPT, PPTX, और ODP फ़ाइलें उत्पन्न करें, OpenDocument समर्थन का लाभ उठाएं, और विश्वसनीय परिणामों के लिये उन्हें प्रोग्रामेटिक रूप से सहेजें।"
---
## **अवलोकन**

Aspose.Slides for Python आपको पूरी‑तरह कोड में एक नई प्रेज़ेंटेशन फ़ाइल बनाने की अनुमति देता है। यह लेख मुख्य कार्य‑प्रवाह दिखाता है—एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) ऑब्जेक्ट बनाना, पहली स्लाइड प्राप्त करना, एक साधारण शAPE जोड़ना, और परिणाम को सहेजना—ताकि आप देख सकें कि Microsoft Office के बिना प्रेज़ेंटेशन उत्पन्न करने के लिए कितना कम सेट‑अप चाहिए। क्योंकि वही API PPT, PPTX, और ODP फ़ाइलें लिखता है, आप एक ही कोड बेस से पारंपरिक PowerPoint और OpenDocument दोनों फ़ॉर्मेट टारगेट कर सकते हैं। Aspose.Slides डेस्कटॉप, वेब, या सर्वर पर्यावरण के लिए उपयुक्त है, जिससे आपका Python एप्लिकेशन शुरुआती बिंदु प्राप्त करता है जिससे आप टेक्स्ट, इमेज या चार्ट जैसी अधिक समृद्ध सामग्री जोड़ सकें जब प्रारंभिक स्लाइड डेक तैयार हो जाये।

## **एक प्रेज़ेंटेशन बनाएं**

Aspose.Slides for Python में स्क्रैच से PowerPoint फ़ाइल बनाना उतना ही सीधा है जितना कि [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास को इंस्टैंसिएट करना। कंस्ट्रक्टर स्वतः एक खाली डेक एक ही स्लाइड के साथ प्रदान करता है, जिससे शAPE, टेक्स्ट, चार्ट या कोई भी अन्य कंटेंट के लिये तत्काल कैनवस मिल जाता है। एक बार जब आप उस स्लाइड को बदल देते हैं—या नई स्लाइडें जोड़ते हैं—तो आप परिणाम को PPTX, लेगेसी PPT, या यहाँ तक कि OpenDocument फ़ॉर्मेट में सहेज सकते हैं। नीचे दिया गया छोटा कोड उदाहरण इस वर्कफ़्लो को दर्शाता है जिसमें पहली स्लाइड पर एक साधारण शAPE जोड़ा गया है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।  
2. स्लाइड को उसके इंडेक्स से प्राप्त करें।  
3. `shapes` कलेक्शन द्वारा उजागर `add_auto_shape` मेथड का उपयोग करके `CLOUD` प्रकार की एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) ऑब्जेक्ट जोड़ें।  
4. ऑटो‑शAPE में टेक्स्ट जोड़ें।  
5. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिए उदाहरण में प्रेज़ेंटेशन की पहली स्लाइड पर एक क्लाउड शAPE जोड़ा गया है।

```py
import aspose.slides as slides

# प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation वर्ग को इनस्टैंशिएट करें।
with slides.Presentation() as presentation:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # CLOUD प्रकार का ऑटो‑शAPE जोड़ें।
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![नई प्रेज़ेंटेशन](new_presentation.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं नई प्रेज़ेंटेशन को किन फ़ॉर्मेट में सहेज सकता हूँ?**

आप [PPTX, PPT, और ODP](/slides/hi/python-net/save-presentation/) में सहेज सकते हैं, तथा [PDF](/slides/hi/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/hi/python-net/convert-powerpoint-to-xps/), [HTML](/slides/hi/python-net/convert-powerpoint-to-html/), [SVG](/slides/hi/python-net/convert-powerpoint-to-png/), और [images](/slides/hi/python-net/convert-powerpoint-to-png/) सहित कई अन्य फ़ॉर्मेट में निर्यात कर सकते हैं।

**क्या मैं टेम्प्लेट (POTX/POTM) से शुरू करके सामान्य PPTX के रूप में सहेज सकता हूँ?**

हां। टेम्प्लेट लोड करें और इच्छित फ़ॉर्मेट में सहेजें; POTX/POTM/PPTM और समान फ़ॉर्मेट [समर्थित](/slides/hi/python-net/supported-file-formats/) हैं।

**प्रेज़ेंटेशन बनाते समय स्लाइड आकार/अस्पेक्ट रेशियो कैसे नियंत्रित करूँ?**

[स्लाइड आकार](/slides/hi/python-net/slide-size/) सेट करें (जैसे 4:3, 16:9 या कस्टम डाइमेंशन) और तय करें कि कंटेंट कैसे स्केल होना चाहिए।

**आकार और कोऑर्डिनेट किस यूनिट में मापे जाते हैं?**

पॉइंट्स में: 1 इंच बराबर 72 यूनिट।

**बहुत बड़ी प्रेज़ेंटेशन (बहुत सारी मीडिया फ़ाइलों) को मेमोरी उपयोग कम करने के लिए कैसे संभालूँ?**

[BLOB प्रबंधन रणनीतियों](/slides/hi/python-net/manage-blob/) का उपयोग करें, टेम्पररी फ़ाइलों द्वारा इन‑मेमोरी स्टोरेज को सीमित करें, और केवल इन‑मेमोरी स्ट्रीम के बजाय फ़ाइल‑आधारित वर्कफ़्लो को प्राथमिकता दें।

**क्या मैं समानांतर में प्रेज़ेंटेशन बना/सहेज सकता हूँ?**

आप एक ही [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस को [एकाधिक थ्रेड](/slides/hi/python-net/multithreading/) से ऑपरेट नहीं कर सकते। प्रत्येक थ्रेड या प्रोसेस के लिये अलग, पृथक इंस्टेंस चलाएँ।

**ट्राइल वाटरमार्क और सीमाओं को कैसे हटाऊँ?**

प्रति प्रोसेस एक बार [लाइसेंस लागू](/slides/hi/python-net/licensing/) करें। लाइसेंस XML को अपरिवर्तित रखा जाना चाहिए, और यदि कई थ्रेड शामिल हों तो लाइसेंस सेटअप को समन्वित करना चाहिए।

**क्या मैं बनाए गए PPTX को डिजिटल रूप से साइन कर सकता हूँ?**

हां। [डिजिटल सिग्नेचर](/slides/hi/python-net/digital-signature-in-powerpoint/) (जोड़ना और सत्यापित करना) प्रेज़ेंटेशन के लिये समर्थित हैं।

**क्या बनाई गई प्रेज़ेंटेशन में मैक्रो (VBA) समर्थित हैं?**

हां। आप [VBA प्रोजेक्ट बन/संपादित](/slides/hi/python-net/presentation-via-vba/) कर सकते हैं और मैक्रो‑सक्षम फ़ाइलें जैसे PPTM/PPSM को सहेज सकते हैं।