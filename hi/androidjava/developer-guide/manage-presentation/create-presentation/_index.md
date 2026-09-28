---
title: Android पर प्रस्तुतियों का निर्माण
linktitle: प्रेज़ेंटेशन बनाएं
type: docs
weight: 10
url: /hi/androidjava/create-presentation/
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
- प्रेज़ेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ Java में प्रेज़ेंटेशन बनाएं—PPT, PPTX और ODP फ़ाइलें उत्पन्न करें, OpenDocument समर्थन का लाभ उठाएँ, और विश्वसनीय परिणामों के लिए प्रोग्रामैटिक रूप से उन्हें सहेजें।"
---
## **अवलोकन**

यह लेख दिखाता है कि Aspose.Slides for Android को Java के माध्यम से कैसे उपयोग करके एक प्रेज़ेंटेशन बनाया जाए, उसकी पहली स्लाइड में एक टेक्स्ट बॉक्स जोड़ा जाए, और परिणाम को आपके ऐप के स्टोरेज में फ़ाइल के रूप में सहेजा जाए। मौजूदा प्रेज़ेंटेशन खोलने या उसे किसी अन्य फ़ॉर्मेट में सहेजने के लिए, देखें [प्रेज़ेंटेशन खोलें](/slides/hi/androidjava/open-presentation/) और [प्रेज़ेंटेशन सहेजें](/slides/hi/androidjava/save-presentation/)। अंत में एक छोटा FAQ सामान्य प्रश्नों को कवर करता है जैसे फ़ॉर्मेट्स, टेम्प्लेट्स, स्लाइड आकार, इकाइयाँ, मेमोरी उपयोग, थ्रेडिंग, लाइसेंसिंग, डिजिटल सिग्नेचर, और VBA समर्थन।

शुरू करने से पहले, Aspose के Maven रिपोज़िटरी से Aspose.Slides को अपने Android प्रोजेक्ट में जोड़ें। देखें [Installation](/slides/hi/androidjava/install-aspose-slides-for-android-via-java/)।

## **PowerPoint प्रेज़ेंटेशन बनाएं**

एक प्रेज़ेंटेशन बनाने और उसकी पहली स्लाइड पर एक टेक्स्ट बॉक्स रखने के लिए, इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) क्लास का एक instance बनाएँ। एक नया प्रेज़ेंटेशन पहले से ही एक खाली स्लाइड रखता है।
2. उस स्लाइड को उसके इंडेक्स, 0 द्वारा, [स्लाइड संग्रह](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) से प्राप्त करें।
3. [shape संग्रह](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) की [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) मेथड से एक आयत जोड़ें और उसके [text frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) के टेक्स्ट को [setText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-) मेथड से सेट करें।
4. प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड से सहेजें, [SaveFormat.Pptx](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/) फ़ॉर्मेट में।

यह कोड `Activity` के अंदर चलता है, उदाहरण के लिए उसके `onCreate` मेथड में। यह फ़ाइल को उस डायरेक्टरी में सहेजता है जो [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) मेथड द्वारा लौटाई जाती है: आपके ऐप का प्राइवेट स्टोरेज, जहाँ इसे किसी अनुमति के बिना लिखा जा सकता है।

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

आयत का ऊपर‑बाएँ कोना स्लाइड के बाएँ किनारे से 50 पॉइंट और ऊपर के किनारे से 50 पॉइंट पर है, और आयत की चौड़ाई 400 पॉइंट तथा ऊँचाई 100 पॉइंट है। सहेजी गई फ़ाइल में उस आयत और उसके टेक्स्ट के साथ एक स्लाइड होती है। बिना लाइसेंस के, Aspose.Slides हर सहेजी गई स्लाइड पर एक evaluation वाटरमार्क भी जोड़ देता है; देखें [Licensing](/slides/hi/androidjava/licensing/)।

फ़ाइल को देखने के लिए, Android Studio के [Device Explorer](https://developer.android.com/studio/debug/device-file-explorer) को खोलें और *data/data/* के तहत *files* फ़ोल्डर में *hello.pptx* खोजें। वास्तविक ऐप में, प्रेज़ेंटेशन को बैकग्राउंड थ्रेड पर प्रोसेस करें ताकि उपयोगकर्ता इंटरफ़ेस प्रतिक्रियाशील बना रहे।

## **अक्सर पूछे जाने वाले प्रश्न**

### नई प्रेज़ेंटेशन को किन फ़ॉर्मेट्स में सहेजा जा सकता है?

आप इसे [PPTX, PPT, और ODP](/slides/hi/androidjava/save-presentation/) में सहेज सकते हैं, और इसे [PDF](/slides/hi/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/hi/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/hi/androidjava/convert-powerpoint-to-html/), [SVG](/slides/hi/androidjava/render-a-slide-as-an-svg-image/), और [images](/slides/hi/androidjava/convert-powerpoint-to-png/) जैसे अन्य फ़ॉर्मेट में निर्यात कर सकते हैं।

### क्या मैं टेम्प्लेट (POTX/POTM) से शुरू करके सामान्य PPTX में सहेज सकता हूँ?

हाँ। टेम्प्लेट लोड करें और इच्छित फ़ॉर्मेट में सहेजें; POTX/POTM/PPTM और समान फ़ॉर्मेट्स [समर्थित](/slides/hi/androidjava/supported-file-formats/) हैं।

### प्रेज़ेंटेशन बनाते समय स्लाइड आकार/आस्पेक्ट रेशियो कैसे नियंत्रित करूँ?

[स्लाइड आकार](/slides/hi/androidjava/slide-size/) सेट करें (जैसे 4:3, 16:9 प्रीसेट या कस्टम डाइमेंशन) और तय करें कि कंटेंट कैसे स्केल होना चाहिए।

### आकार और निर्देशांक किन इकाइयों में मापे जाते हैं?

पॉइंट्स में: 1 इंच बराबर 72 यूनिट्स।

### बहुत बड़े प्रेज़ेंटेशन (बहुत सारे मीडिया फ़ाइलों के साथ) को मेमोरी उपयोग कम करने के लिए कैसे संभालूँ?

[BLOB प्रबंधन रणनीतियों](/slides/hi/androidjava/manage-blob/) का उपयोग करें, अस्थायी फ़ाइलों के माध्यम से इन‑मेमोरी स्टोरेज सीमित करें, और शुद्ध इन‑मेमोरी स्ट्रीम की बजाय फ़ाइल‑आधारित वर्कफ़्लो को प्राथमिकता दें।

### क्या मैं समानांतर में प्रेज़ेंटेशन बना/सहेज सकता हूँ?

आप एक ही [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) इन्स्टेंस को [कई थ्रेड्स](/slides/hi/androidjava/multithreading/) से ऑपरेट नहीं कर सकते। प्रत्येक थ्रेड या प्रोसेस के लिए अलग‑अलग इन्स्टेंस चलाएँ।

### ट्रायल वाटरमार्क और सीमाओं को कैसे हटाऊँ?

प्रति प्रोसेस एक बार [लाइसेंस लागू करें](/slides/hi/androidjava/licensing/)। लाइसेंस XML को अपरिवर्तित रखें, और यदि कई थ्रेड्स हैं तो लाइसेंस सेटअप को सिंक्रनाइज़ करें।

### क्या मैं बनाए गए PPTX को डिजिटल साइन कर सकता हूँ?

हाँ। प्रेज़ेंटेशन के लिए [डिजिटल सिग्नेचर](/slides/hi/androidjava/digital-signature-in-powerpoint/) (जोड़ना और सत्यापित करना) समर्थित हैं।

### क्या बनाए गए प्रेज़ेंटेशन में मैक्रो (VBA) समर्थित हैं?

हाँ। आप [VBA प्रोजेक्ट बन/संपादित](/slides/hi/androidjava/presentation-via-vba/) कर सकते हैं और PPTM/PPSM जैसे मैक्रो‑सक्षम फ़ाइलें सहेज सकते हैं।