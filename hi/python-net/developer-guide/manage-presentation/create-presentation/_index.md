---
title: Python में प्रस्तुतियों का निर्माण
linktitle: प्रस्तुति बनाएं
type: docs
weight: 10
url: /hi/python-net/create-presentation/
keywords:
- प्रस्तुति बनाएं
- नई प्रस्तुति
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
description: "Aspose.Slides के साथ Python में PowerPoint प्रस्तुतियों का निर्माण—PPT, PPTX और ODP फ़ाइलें बनाएं, OpenDocument समर्थन का लाभ उठाएं, और विश्वसनीय परिणामों के लिए उन्हें प्रोग्रामेटिक रूप से सहेजें।"
---
## **परिचय**

यह लेख दिखाता है कि Aspose.Slides for Python via .NET का उपयोग करके प्रस्तुति कैसे बनाएं, उसकी पहली स्लाइड में टेक्स्ट वाला आकार (shape) कैसे जोड़ें, और परिणाम को PPTX फ़ाइल के रूप में सहेजें। वही API प्रस्तुतियों को PPT और ODP के रूप में भी सहेजता है, इसलिए आप एक ही कोड बेस से PowerPoint और OpenDocument दोनों फ़ॉर्मेट को लक्षित कर सकते हैं, बिना Microsoft Office के। अंत में एक संक्षिप्त FAQ सामान्य प्रश्नों को कवर करता है, जैसे फ़ॉर्मेट, टेम्प्लेट, स्लाइड आकार, इकाइयाँ, मेमोरी उपयोग, थ्रेडिंग, लाइसेंसिंग, डिजिटल हस्ताक्षर, और VBA समर्थन।

शुरू करने से पहले, PyPI से पैकेज `pip install aspose.slides` कमांड से स्थापित करें। Linux और macOS को भी जिन लाइब्रेरीज़ की आवश्यकता होती है, तथा Debian और Ubuntu के सिस्टम Python को आवश्यक वर्चुअल एनवायरनमेंट के बारे में जानने के लिए [स्थापना](/slides/hi/python-net/installation/) देखें।

## **एक प्रस्तुति बनाएं**

प्रस्तुति बनाने और उसकी पहली स्लाइड में टेक्स्ट वाला आकार (shape) रखने के लिए, निम्नलिखित चरणों का पालन करें:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएं। नई प्रस्तुति में पहले से ही एक खाली स्लाइड होती है।
2. उस स्लाइड को उसके इंडेक्स 0 द्वारा [slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/slides/hi/) संग्रह से प्राप्त करें।
3. स्लाइड की [shapes](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/shapes/) संग्रह की [add_auto_shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_auto_shape/) विधि से एक बादल-आकृति वाला [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें, और उसका [text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/text/) सेट करें।
4. प्रस्तुति को [save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) विधि से PPTX फ़ाइल के रूप में सहेजें।

```py
import aspose.slides as slides

# एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation() as presentation:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # CLOUD प्रकार का ऑटो-शेप जोड़ें।
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

बादल के बाएँ-ऊपरी कोने की स्थिति स्लाइड के बाएँ किनारे से 20 पॉइंट और शीर्ष किनारे से 20 पॉइंट है, और बादल की चौड़ाई 200 पॉइंट तथा ऊँचाई 80 पॉइंट है। `with` स्टेटमेंट ब्लॉक समाप्त होने पर प्रस्तुति के संसाधनों को मुक्त कर देता है। स्क्रिप्ट *new_presentation.pptx* को वर्तमान फोल्डर में सहेजती है, जिसमें एक स्लाइड होती है जो बादल और उसका टेक्स्ट रखती है। लाइसेंस के बिना, Aspose.Slides प्रत्येक सहेजी गई स्लाइड में एक मूल्यांकन वाटरमार्क भी जोड़ता है; विवरण के लिए [लाइसेंसिंग](/slides/hi/python-net/licensing/) देखें।

परिणाम:

![नई प्रस्तुति](new_presentation.png)

## **अक्सर पूछे जाने वाले प्रश्न**

### मैं नई प्रस्तुति को कौन‑से फ़ॉर्मेट में सहेज सकता हूँ?

आपको [PPTX, PPT, और ODP](/slides/hi/python-net/save-presentation/) में सहेज सकते हैं, तथा [PDF](/slides/hi/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/hi/python-net/convert-powerpoint-to-xps/), [HTML](/slides/hi/python-net/convert-powerpoint-to-html/), [SVG](/slides/hi/python-net/render-a-slide-as-an-svg-image/), और [छवियां](/slides/hi/python-net/convert-powerpoint-to-png/) आदि में निर्यात कर सकते हैं।

### क्या मैं टेम्प्लेट (POTX/POTM) से शुरू करके नियमित PPTX के रूप में सहेज सकता हूँ?

हाँ। टेम्प्लेट लोड करें और इच्छित फ़ॉर्मेट में सहेजें; POTX/POTM/PPTM और समान फ़ॉर्मेट [समर्थित](/slides/hi/python-net/supported-file-formats/) हैं।

### प्रस्तुति बनाते समय स्लाइड आकार/आस्पेक्ट रेशियो कैसे नियंत्रित करूँ?

[स्लाइड आकार](/slides/hi/python-net/slide-size/) सेट करें (जैसे 4:3 और 16:9 जैसे प्रीसेट या कस्टम आयाम) और तय करें कि सामग्री कैसे स्केल होनी चाहिए।

### आकार और निर्देशांक किस इकाई में मापे जाते हैं?

पॉइंट में: 1 इंच बराबर 72 इकाई होती है।

### बहुत बड़ी प्रस्तुतियों (कई मीडिया फ़ाइलों के साथ) को मेमोरी उपयोग कम करने के लिए कैसे संभालूँ?

[BLOB प्रबंधन रणनीतियाँ](/slides/hi/python-net/manage-blob/) का उपयोग करें, अस्थायी फ़ाइलों के माध्यम से इन‑मेमोरी स्टोरेज को सीमित करें, और केवल इन‑मेमोरी स्ट्रीम की बजाय फ़ाइल‑आधारित वर्कफ़्लो को प्राथमिकता दें।

### क्या मैं प्रस्तुतियों को समानांतर में बना/सहेज सकता हूँ?

आप उसी [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस पर [एकाधिक थ्रेड](/slides/hi/python-net/multithreading/) से संचालन नहीं कर सकते। प्रत्येक थ्रेड या प्रोसेस के लिए अलग, अलगाव वाले इंस्टेंस चलाएँ।

### परीक्षण वाटरमार्क और सीमाओं को कैसे हटाऊँ?

प्रति प्रोसेस एक बार [लाइसेंस लागू करें](/slides/hi/python-net/licensing/) करें। लाइसेंस XML को अपरिवर्तित रखना चाहिए, और यदि कई थ्रेड शामिल हों तो लाइसेंस सेटअप को सिंक्रोनाइज़ करना चाहिए।

### क्या मैं बनाई गई PPTX को डिजिटल रूप से साइन कर सकता हूँ?

हाँ। [डिजिटल हस्ताक्षर](/slides/hi/python-net/digital-signature-in-powerpoint/) (जोड़ना और सत्यापित करना) प्रस्तुतियों के लिए समर्थित हैं।

### क्या बनाई गई प्रस्तुतियों में मैक्रो (VBA) समर्थित हैं?

हाँ। आप [VBA प्रोजेक्ट बनाएं/संपादित करें](/slides/hi/python-net/presentation-via-vba/) और PPTM/PPSM जैसे मैक्रो‑सक्षम फ़ाइलें सहेज सकते हैं।