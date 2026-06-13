---
title: Java में प्रस्तुतियाँ बनाएं
linktitle: प्रेज़ेंटेशन बनाएं
type: docs
weight: 10
url: /hi/java/create-presentation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Java में प्रस्तुतियाँ बनाएँ—PPT, PPTX और ODP फ़ाइलें उत्पन्न करें, OpenDocument समर्थन का लाभ उठाएँ, और विश्वसनीय परिणामों के लिए उन्हें प्रोग्रामेटिक रूप से सहेजें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में एक प्रस्तुति बनाने, स्लाइड में सरल सामग्री जोड़ने, और परिणाम को फ़ाइल के रूप में सहेजने का तरीका दिखाता है। यह एक नई प्रस्तुति बनाकर उसे सहेजने, समर्थित फ़ॉर्मेट में मौजूदा प्रस्तुति खोलने, और उसे किसी अन्य फ़ॉर्मेट में सहेजने को भी दर्शाता है। अतिरिक्त रूप से, लेख में फ़ॉर्मेट, टेम्प्लेट, स्लाइड आकार, इकाइयाँ, मेमोरी उपयोग, थ्रेडिंग, लाइसेंसिंग, डिजिटल हस्ताक्षर, और VBA समर्थन से संबंधित सामान्य प्रश्नों को शामिल करते हुए एक छोटा FAQ दिया गया है।

## **एक प्रस्तुति बनाना**

Aspose.Slides for Java में शून्य से PowerPoint फ़ाइल बनाना उतना ही सीधा है जितना कि [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाना। कंस्ट्रक्टर स्वतः एक खाली डेक के साथ एक स्लाइड प्रदान करता है, जिससे आप तुरंत शेप्स, टेक्स्ट, चार्ट या किसी भी अन्य सामग्री को जोड़ सकते हैं जिसकी आपके एप्लिकेशन को आवश्यकता है। एक बार जब आप उस स्लाइड को संशोधित कर लेते हैं—या नई स्लाइड जोड़ लेते हैं—तो आप परिणाम को PPTX, पुराना PPT, या यहां तक कि OpenDocument फ़ॉर्मेट में भी सहेज सकते हैं। नीचे दिया गया संक्षिप्त कोड उदाहरण इस कार्यप्रवाह को दर्शाता है, जिसमें पहली स्लाइड पर एक सरल शेप जोड़ा गया है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. इसका स्लाइड इंडेक्स द्वारा संदर्भ प्राप्त करें।
3. `Shapes` कलेक्शन द्वारा प्रदान किए गए `addAutoShape` मेथड का उपयोग करके `Cloud` प्रकार का एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) ऑब्जेक्ट जोड़ें।
4. ऑटो‑शेप में टेक्स्ट जोड़ें।
5. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे के उदाहरण में प्रस्तुति की पहली स्लाइड में एक क्लाउड शेप जोड़ी गई है।

```java
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // Cloud प्रकार का एक ऑटो-शेप जोड़ें।
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    // प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("new_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![नई प्रस्तुति](new_presentation.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं नई प्रस्तुति को किन फ़ॉर्मेट में सहेज सकता हूँ?**

आप [PPTX, PPT, और ODP](/slides/hi/java/save-presentation/) में सहेज सकते हैं, तथा [PDF](/slides/hi/java/convert-powerpoint-to-pdf/), [XPS](/slides/hi/java/convert-powerpoint-to-xps/), [HTML](/slides/hi/java/convert-powerpoint-to-html/), [SVG](/slides/hi/java/convert-powerpoint-to-png/), और [इमेज](/slides/hi/java/convert-powerpoint-to-png/) जैसे अन्य फ़ॉर्मेट में निर्यात कर सकते हैं।

**क्या मैं टेम्प्लेट (POTX/POTM) से शुरू करके सामान्य PPTX के रूप में सहेज सकता हूँ?**

हां। टेम्प्लेट लोड करें और इच्छित फ़ॉर्मेट में सहेजें; POTX/POTM/PPTM और समान फ़ॉर्मेट [समर्थित](/slides/hi/java/supported-file-formats/) हैं।

**प्रस्तुति बनाते समय स्लाइड आकार/आस्पेक्ट रेशियो कैसे नियंत्रित करें?**

[स्लाइड आकार](/slides/hi/java/slide-size/) सेट करें (जैसे 4:3, 16:9 या कस्टम माप) और तय करें कि सामग्री कैसे स्केल होनी चाहिए।

**आकार और निर्देशांक किस इकाइयों में मापे जाते हैं?**

पॉइंट्स में: 1 इंच में 72 यूनिट होते हैं।

**बहुत बड़ी प्रस्तुतियों (कई मीडिया फ़ाइलों के साथ) को मेमोरी उपयोग कम करने के लिए कैसे संभालें?**

[BLOB प्रबंधन रणनीतियों](/slides/hi/java/manage-blob/) का उपयोग करें, अस्थायी फ़ाइलों के माध्यम से इन‑मेमोरी स्टोरेज को सीमित करें, और शुद्ध इन‑मेमोरी स्ट्रीम के बजाय फ़ाइल‑आधारित वर्कफ़्लो को प्राथमिकता दें।

**क्या मैं प्रस्तुतियों को समानांतर में बना/सहेज सकता हूँ?**

आप एक ही [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस को [कई थ्रेड](/slides/hi/java/multithreading/) से संचालित नहीं कर सकते। प्रत्येक थ्रेड या प्रक्रिया के लिए अलग, स्वतंत्र इंस्टेंस चलाएँ।

**ट्रायल वाटरमार्क और सीमाओं को कैसे हटाएँ?**

प्रोसेस में एक बार [लाइसेंस लागू](/slides/hi/java/licensing/) करें। लाइसेंस XML को अपरिवर्तित रखें, और यदि कई थ्रेड शामिल हों तो लाइसेंस सेटअप को समन्वित करें।

**क्या मैं निर्मित PPTX को डिजिटल साइन कर सकता हूँ?**

हां। प्रस्तुतियों के लिए [डिजिटल हस्ताक्षर](/slides/hi/java/digital-signature-in-powerpoint/) (जोड़ना और सत्यापित करना) समर्थित है।

**क्या निर्मित प्रस्तुतियों में मैक्रो (VBA) समर्थित है?**

हां। आप [VBA प्रोजेक्ट बनाना/संपादित करना](/slides/hi/java/presentation-via-vba/) कर सकते हैं और PPTM/PPSM जैसे मैक्रो‑सक्षम फ़ाइलें सहेज सकते हैं।