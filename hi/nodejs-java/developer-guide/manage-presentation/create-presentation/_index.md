---
title: जावास्क्रिप्ट में प्रस्तुतियाँ बनाएं
linktitle: प्रस्तुति बनाएं
type: docs
weight: 10
url: /hi/nodejs-java/create-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides के साथ प्रस्तुतियाँ बनाएं—PPT, PPTX, और ODP फ़ाइलें बनाएं, OpenDocument समर्थन का लाभ उठाएँ, और विश्वसनीय परिणामों के लिए उन्हें प्रोग्रामेटिक रूप से सहेजें।"
---
## **अवलोकन**

यह लेख दर्शाता है कि Aspose.Slides में प्रस्तुति कैसे बनाएँ, स्लाइड में सरल सामग्री कैसे जोड़ें, और परिणाम को फ़ाइल के रूप में सहेजें।

## **PowerPoint प्रस्तुति बनाएँ**

प्रस्तुति की चयनित स्लाइड में एक साधा सीधी रेखा जोड़ने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. Presentation class की एक instance बनाएँ।
1. स्लाइड का संदर्भ उसके Index का उपयोग करके प्राप्त करें।
1. Shapes ऑब्जेक्ट द्वारा प्रदान किए गए addAutoShape मेथड का उपयोग करके Line प्रकार की एक AutoShape जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति की पहली स्लाइड में एक रेखा जोड़ी है।

```javascript
// एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    var slide = pres.getSlides().get_Item(0);
    // लाइन प्रकार की ऑटोशेप जोड़ें
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं नई प्रस्तुति को किस स्वरूप में सहेज सकता हूँ?**

आप इसे [PPTX, PPT, and ODP](/slides/hi/nodejs-java/save-presentation/) में सहेज सकते हैं, और इसे [PDF](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/hi/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/hi/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/hi/nodejs-java/convert-powerpoint-to-png/), और [images](/slides/hi/nodejs-java/convert-powerpoint-to-png/) जैसे अन्य स्वरूपों में निर्यात कर सकते हैं।

**क्या मैं एक टेम्पलेट (POTX/POTM) से शुरू कर सकता हूँ और नियमित PPTX के रूप में सहेज सकता हूँ?**

हाँ। टेम्पलेट लोड करें और इच्छित स्वरूप में सहेजें; POTX/POTM/PPTM और समान स्वरूपों को [समर्थित हैं](/slides/hi/nodejs-java/supported-file-formats/) किया जाता है।

**प्रस्तुति बनाते समय मैं स्लाइड का आकार/आस्पेक्ट अनुपात कैसे नियंत्रित करूँ?**

स्लाइड का आकार सेट करें [स्लाइड आकार](/slides/hi/nodejs-java/slide-size/) (जैसे 4:3 और 16:9 जैसे प्रीसैट या कस्टम आयाम) और तय करें कि सामग्री कैसे स्केल होनी चाहिए।

**आकार और निर्देशांक किस इकाइयों में मापे जाते हैं?**

पॉइंट में: 1 इंच बराबर 72 यूनिट्स।

**बड़ी प्रस्तुती (बहुत सारी मीडिया फ़ाइलों के साथ) को मेमोरी उपयोग कम करने के लिए मैं कैसे संभालूँ?**

[BLOB प्रबंधन रणनीतियाँ](/slides/hi/nodejs-java/manage-blob/) को उपयोग करें, अस्थायी फ़ाइलों का उपयोग करके इन‑मेमोरी स्टोरेज को सीमित करें, और केवल इन‑मेमोरी स्ट्रीम्स के बजाय फ़ाइल‑आधारित वर्कफ़्लो को प्राथमिकता दें।

**क्या मैं प्रत्‍येक समानांतर में प्रस्तुति बना/सहेज सकता हूँ?**

आप समान [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) instance को [एकाधिक थ्रेड्स](/slides/hi/nodejs-java/multithreading/) से ऑपरेट नहीं कर सकते। प्रत्येक थ्रेड या प्रोसेस के लिए अलग, पृथक instance चलाएँ।

**ट्रायल वाटरमार्क और सीमाओं को मैं कैसे हटाऊँ?**

[लाइसेंस लागू करें](/slides/hi/nodejs-java/licensing/) को प्रति प्रोसेस एक बार लागू करें। लाइसेंस XML को अपरिवर्तित रखना आवश्यक है, और यदि कई थ्रेड्स शामिल हों तो लाइसेंस सेटअप को सिंक्रनाइज़ किया जाना चाहिए।

**क्या मैं अपने द्वारा बनाई गई PPTX को डिजिटल रूप से साइन कर सकता हूँ?**

हाँ। प्रस्तुतियों के लिए [डिजिटल हस्ताक्षर](/slides/hi/nodejs-java/digital-signature-in-powerpoint/) (जोड़ना और सत्यापित करना) समर्थन किया जाता है।

**क्या बनायी गई प्रस्तुतियों में मैक्रो (VBA) समर्थित हैं?**

हाँ। आप [VBA प्रोजेक्ट बनाना/संपादित करना](/slides/hi/nodejs-java/presentation-via-vba/) कर सकते हैं और PPTM/PPSM जैसे मैक्रो‑सक्षम फ़ाइलें सहेज सकते हैं।