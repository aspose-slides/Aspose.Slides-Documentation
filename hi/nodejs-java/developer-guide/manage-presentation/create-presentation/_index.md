---
title: जावास्क्रिप्ट में प्रस्तुतियां बनाएं
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
description: "Aspose.Slides के साथ प्रस्तुतियां बनाएं—PPT, PPTX और ODP फ़ाइलें बनाएं, OpenDocument समर्थन का लाभ उठाएं, और विश्वसनीय परिणामों के लिए उन्हें प्रोग्रामेटिक रूप से सहेजें।"
---
## **सारांश**

यह लेख दर्शाता है कि Aspose.Slides में प्रस्तुति कैसे बनाई जाए, उसकी पहली स्लाइड में एक टेक्स्ट बॉक्स जोड़ा जाए, और परिणाम को फ़ाइल के रूप में सहेजा जाए।  
शुरू करने से पहले, npm से `aspose.slides.via.java` पैकेज स्थापित करें, साथ ही आवश्यक JDK, Python, और C++ बिल्ड टूल्स भी। देखें [स्थापना](/slides/hi/nodejs-java/installation/)।

## **PowerPoint प्रस्तुति बनाएं**

प्रस्तुति बनाने और उसकी पहली स्लाइड पर एक टेक्स्ट बॉक्स रखने के लिए, इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की एक इंस्टैंस बनाएं। एक नई प्रस्तुति में पहले से ही एक खाली स्लाइड होती है।
2. [slide collection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getslides/) से उसकी इंडेक्स 0 द्वारा स्लाइड प्राप्त करें।
3. [addAutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/addautoshape/) मेथड से एक आयत जोड़ें और [setText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/settext/) से उसका टेक्स्ट सेट करें।
4. [save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/save/) मेथड से प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
5. [dispose](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/dispose/) मेथड से प्रस्तुति को रिलीज़ करें, और प्रक्रिया समाप्त करें।

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides एक Java वर्चुअल मशीन में चलता है जो Node.js को चलाए रखता है, इसलिए प्रक्रिया को स्पष्ट रूप से समाप्त करें।
process.exit(0);
```

आयत का बाएँ‑ऊपर कोना स्लाइड के बाएँ किनारे से 50 पॉइंट और ऊपर किनारे से 50 पॉइंट दूर है, और आयत की चौड़ाई 400 पॉइंट और ऊँचाई 100 पॉइंट है। कोड को *hello.js* के रूप में अपने प्रोजेक्ट फ़ोल्डर में सहेजें और `node hello.js` चलाएँ: यह *hello.pptx* सहेजता है, जिसमें एक स्लाइड में वह आयत और उसका टेक्स्ट होता है, वर्तमान फ़ोल्डर में।

Aspose.Slides एक Java वर्चुअल मशीन में चलती है जिसे `java` पैकेज Node.js प्रक्रिया के भीतर शुरू करता है। यह वर्चुअल मशीन स्क्रिप्ट समाप्त होने के बाद Node.js को अपने आप बंद होने से रोकती है, इसलिए उदाहरण `process.exit(0)` के साथ समाप्त होता है।

लाइसेंस के बिना, Aspose.Slides प्रत्येक सहेजी गई स्लाइड में एक मूल्यांकन वाटरमार्क जोड़ता है; देखें [लाइसेंसिंग](/slides/hi/nodejs-java/licensing/)।

## **अक्सर पूछे जाने वाले प्रश्न**

### मैं नई प्रस्तुति को किन फ़ॉर्मैट में सहेज सकता हूँ?

आप [PPTX, PPT, और ODP](/slides/hi/nodejs-java/save-presentation/) में सहेज सकते हैं, और [PDF](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/hi/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/hi/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/hi/nodejs-java/render-a-slide-as-an-svg-image/), और [images](/slides/hi/nodejs-java/convert-powerpoint-to-png/) जैसे अन्य फॉर्मैट में निर्यात कर सकते हैं।

### क्या मैं एक टेम्प्लेट (POTX/POTM) से शुरू करके सामान्य PPTX के रूप में सहेज सकता हूँ?

हाँ। टेम्प्लेट को लोड करें और इच्छित फ़ॉर्मैट में सहेजें; POTX/POTM/PPTM और समान फ़ॉर्मैट [समर्थित](/slides/hi/nodejs-java/supported-file-formats/) हैं।

### प्रस्तुति बनाते समय स्लाइड आकार/आस्पेक्ट अनुपात को कैसे नियंत्रित करूँ?

[स्लाइड आकार](/slides/hi/nodejs-java/slide-size/) सेट करें (जैसे 4:3, 16:9 जैसी प्रीसेट या कस्टम आयाम) और तय करें कि सामग्री कैसे स्केल होनी चाहिए।

### आकार और निर्देशांक किस इकाइयों में मापे जाते हैं?

पॉइंट्स में: 1 इंच बराबर 72 इकाइयों के।

### बहुत बड़ी प्रस्तुतियों (कई मीडिया फ़ाइलों के साथ) को मेमोरी उपयोग कम करने के लिए कैसे संभालूँ?

[BLOB प्रबंधन रणनीतियाँ](/slides/hi/nodejs-java/manage-blob/) का उपयोग करें, अस्थायी फ़ाइलों के माध्यम से इन‑मेमारी स्टोरेज को सीमित करें, और केवल इन‑मेमारी स्ट्रीम की बजाय फ़ाइल‑आधारित वर्कफ़्लो को प्राथमिकता दें।

### क्या मैं समानांतर रूप से प्रस्तुतियों को बना/सहेज सकता हूँ?

आप एक ही [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) को [एकाधिक थ्रेड्स](/slides/hi/nodejs-java/multithreading/) से ऑपरेट नहीं कर सकते। प्रत्येक थ्रेड या प्रक्रिया के लिए अलग, अलग-अलग इंस्टैंस चलाएँ।

### ट्रायल वाटरमार्क और सीमाएँ कैसे हटाऊँ?

[एक लाइसेंस लागू करें](/slides/hi/nodejs-java/licensing/) प्रक्रिया में एक बार लागू करें। लाइसेंस XML अपरिवर्तित रहना चाहिए, और यदि कई थ्रेड्स शामिल हों तो लाइसेंस सेटअप को सिंक्रनाइज़ किया जाना चाहिए।

### क्या मैं बनाई गई PPTX को डिजिटल रूप से साइन कर सकता हूँ?

हाँ। प्रस्तुतियों के लिए [डिजिटल हस्ताक्षर](/slides/hi/nodejs-java/digital-signature-in-powerpoint/) (जोड़ना और सत्यापित करना) समर्थित हैं।

### बनायी गई प्रस्तुतियों में मैक्रो (VBA) समर्थित हैं?

हाँ। आप [VBA प्रोजेक्ट बनाएं/संपादित करें](/slides/hi/nodejs-java/presentation-via-vba/) कर सकते हैं और PPTM/PPSM जैसी मैक्रो‑सक्षम फ़ाइलें सहेज सकते हैं।