---
title: Android पर प्रस्तुतियों को बनाएं
linktitle: प्रस्तुति बनाएं
type: docs
weight: 10
url: /hi/androidjava/create-presentation/
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
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Android के लिए Aspose.Slides के साथ Java में प्रस्तुतियां बनाएं—PPT, PPTX और ODP फ़ाइलें उत्पन्न करें, OpenDocument समर्थन का लाभ उठाएं, और विश्वसनीय परिणामों के लिए उन्हें प्रोग्रामेटिक रूप से सहेजें।"
---
## **अवलोकन**

यह लेख दर्शाता है कि Aspose.Slides में प्रस्तुति कैसे बनायीं जाए, स्लाइड में सरल सामग्री कैसे जोड़ी जाए, और परिणाम को फ़ाइल के रूप में कैसे सहेजा जाए। यह यह भी दर्शाता है कि नई प्रस्तुति कैसे बनाई और सहेजी जाए, समर्थित फ़ॉर्मेट में मौजूदा प्रस्तुति को कैसे खोला जाए, और उसे किसी अन्य फ़ॉर्मेट में कैसे सहेजा जाए।

## **PowerPoint प्रस्तुति बनाएं**
चयनित स्लाइड में एक साधारण सीधी रेखा जोड़ने के लिए नीचे दिए गए चरणों का पालन करें:

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. उसकी Index का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. Shapes ऑब्जेक्ट द्वारा प्रदान किए गए addAutoShape मेथड का उपयोग करके लाइन टाइप की AutoShape जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिया गया उदाहरण प्रस्तुति की पहली स्लाइड में एक रेखा जोड़ता है।

```java
// एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);

    // लाइन प्रकार की ऑटوشेप जोड़ें
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं नई प्रस्तुति को किन फ़ॉर्मेट में सहेज सकता हूँ?**

आप [PPTX, PPT, and ODP](/slides/hi/androidjava/save-presentation/) में सहेज सकते हैं, और [PDF](/slides/hi/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/hi/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/hi/androidjava/convert-powerpoint-to-html/), [SVG](/slides/hi/androidjava/convert-powerpoint-to-png/), तथा [images](/slides/hi/androidjava/convert-powerpoint-to-png/) आदि में निर्यात कर सकते हैं।

**क्या मैं टेम्पलेट (POTX/POTM) से शुरू करके सामान्य PPTX के रूप में सहेज सकता हूँ?**

हां। टेम्पलेट लोड करें और इच्छित फ़ॉर्मेट में सहेजें; POTX/POTM/PPTM और समान फ़ॉर्मेट [समर्थित](/slides/hi/androidjava/supported-file-formats/) हैं।

**प्रस्तुति बनाते समय स्लाइड आकार/अस्पेक्ट रेशियो को मैं कैसे नियंत्रित करूं?**

[स्लाइड आकार](/slides/hi/androidjava/slide-size/) सेट करें (जैसे 4:3, 16:9 प्रीसेट या कस्टम डाइमेंशन) और तय करें कि सामग्री कैसे स्केल होनी चाहिए।

**आकार और निर्देशांक किस इकाई में मापे जाते हैं?**

पॉइंट्स में: 1 इंच = 72 इकाई।

**बहुत बड़ी प्रस्तुतियों (बहु मीडिया फ़ाइलों के साथ) को मेमोरी उपयोग कम करने के लिए मैं कैसे संभालूं?**

[BLOB प्रबंधन रणनीतियों](/slides/hi/androidjava/manage-blob/) का उपयोग करें, अस्थायी फ़ाइलों के माध्यम से इन‑मेमोरी स्टोरेज को सीमित करें, और शुद्ध इन‑मेमोरी स्ट्रीम के बजाय फ़ाइल‑आधारित वर्कफ़्लो को प्राथमिकता दें।

**क्या मैं प्रस्तुतियों को समानांतर में बना/सहेज सकता हूँ?**

आप समान [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस को [कई थ्रेड](/slides/hi/androidjava/multithreading/) से संचालित नहीं कर सकते। प्रत्येक थ्रेड या प्रोसेस के लिए अलग, अलग-अलग इंस्टेंस चलाएँ।

**ट्रायल वॉटरमार्क और सीमाओं को हटाने के लिए मुझे क्या करना चाहिए?**

प्रत्येक प्रोसेस में एक बार [लाइसेंस लागू](/slides/hi/androidjava/licensing/) करें। लाइसेंस XML को अपरिवर्तित रखना आवश्यक है, और यदि कई थ्रेड शामिल हों तो लाइसेंस सेटअप को समन्वयित करें।

**क्या मैं बनाई गई PPTX पर डिजिटल सिग्नेचर लगा सकता हूँ?**

हां। [डिजिटल हस्ताक्षर](/slides/hi/androidjava/digital-signature-in-powerpoint/) (जोड़ना और सत्यापित करना) प्रस्तुतियों के लिए समर्थित हैं।

**क्या निर्मित प्रस्तुतियों में मैक्रो (VBA) समर्थित हैं?**

हां। आप [VBA प्रोजेक्ट बना/संपादित](/slides/hi/androidjava/presentation-via-vba/) कर सकते हैं और PPTM/PPSM जैसे मैक्रो‑सक्षम फ़ाइलें सहेज सकते हैं।