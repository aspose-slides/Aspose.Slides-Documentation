---
title: जावा में प्रस्तुतियों का निर्माण
linktitle: प्रस्तुति बनाएँ
type: docs
weight: 10
url: /hi/java/create-presentation/
keywords:
- प्रस्तुति बनाएं
- नया प्रस्तुति
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
description: "Aspose.Slides के साथ जावा में प्रस्तुतियों का निर्माण करें—PPT, PPTX और ODP फ़ाइलें बनाएँ, OpenDocument समर्थन से लाभ उठाएँ, और विश्वसनीय परिणामों के लिए उन्हें प्रोग्रामेटिक रूप से सहेजें।"
---
## **समीक्षा**

यह लेख दिखाता है कि Aspose.Slides में एक प्रस्तुति कैसे बनाई जाए, उसकी पहली स्लाइड में टेक्स्ट वाला एक आकार (shape) कैसे जोड़ा जाए, और परिणाम को PPTX फ़ाइल के रूप में कैसे सहेजा जाए। मौजूदा प्रस्तुति खोलने और इसे दूसरे फॉर्मेट में सहेजने के लिए, देखें [Open Presentations](/slides/hi/java/open-presentation/) और [Save Presentations](/slides/hi/java/save-presentation/)। अंत में एक छोटा FAQ सामान्य प्रश्नों को कवर करता है, जैसे फॉर्मेट, टेम्प्लेट, स्लाइड साइज, यूनिट, मेमोरी उपयोग, थ्रेडिंग, लाइसेंसिंग, डिजिटल सिग्नेचर, और VBA सपोर्ट।

शुरू करने से पहले, Aspose की Maven रिपॉज़िटरी से अपने प्रोजेक्ट में Aspose.Slides for Java जोड़ें। Maven सेटअप और Linux से जुड़ी अतिरिक्त आवश्यकताओं के लिए देखें [Installation](/slides/hi/java/installation/)।

## **प्रस्तुति बनाएँ**

Aspose.Slides for Java में शून्य से PowerPoint फ़ाइल बनाना [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस से शुरू होता है। कंस्ट्रक्टर एक खाली प्रस्तुति प्रदान करता है जिसमें एक ही स्लाइड होती है, जो आकार, टेक्स्ट, चार्ट या आपके एप्लिकेशन की किसी भी अन्य सामग्री के लिए तैयार होती है। एक बार जब आप उस स्लाइड को संशोधित कर लें, या नई स्लाइडें जोड़ दें, तो आप परिणाम को PPTX, लेगेसी PPT, या OpenDocument फॉर्मेट में सहेज सकते हैं।

एक प्रस्तुति बनाने और उसकी पहली स्लाइड पर टेक्स्ट वाला एक आकार रखने के लिए, निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएँ। नई प्रस्तुति में पहले से ही एक खाली स्लाइड होती है।  
2. उस स्लाइड को उसकी इंडेक्स 0 से प्राप्त करें, जो [getSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSlides--) द्वारा लौटाए गए कलेक्शन से मिलता है।  
3. `Cloud` प्रकार का एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) [addAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) मेथड से जोड़ें, और उसका टेक्स्ट [setText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#setText-java.lang.String-) मेथड से सेट करें।  
4. [save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड से प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्न उदाहरण एक पूर्ण प्रोग्राम है। [Installation](/slides/hi/java/installation/) में दिए गए Maven प्रोजेक्ट में इसे *src/main/java/HelloSlides.java* के रूप में सहेजें और `mvn compile exec:java` चलाएँ।

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // एक प्रस्तुति बनाएं। इसमें पहले से ही एक खाली स्लाइड है।
        Presentation presentation = new Presentation();
        try {
            // पहली स्लाइड प्राप्त करें।
            ISlide slide = presentation.getSlides().get_Item(0);

            // एक क्लाउड आकार जोड़ें और उसमें पाठ रखें।
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

क्लाउड का शीर्ष-बायाँ कोना स्लाइड के बाएँ किनारे से 20 पॉइंट और शीर्ष किनारे से 20 पॉइंट पर है, और आकार की चौड़ाई 200 पॉइंट तथा ऊँचाई 80 पॉइंट है। प्रोग्राम *new_presentation.pptx* को सहेजता है जिसमें एक स्लाइड होती है जिसमें क्लाउड और उसका टेक्स्ट होता है। बिना लाइसेंस के, Aspose.Slides प्रत्येक सहेजी गई स्लाइड में एक एवाल्यूएशन वॉटरमार्क भी जोड़ता है; देखें [Licensing](/slides/hi/java/licensing/)।

परिणाम:

![नई प्रस्तुति](new_presentation.png)

## **FAQ**

### मैं नई प्रस्तुति को किन फॉर्मेटों में सहेज सकता हूँ?

आप [PPTX, PPT, और ODP](/slides/hi/java/save-presentation/) में सहेज सकते हैं, और [PDF](/slides/hi/java/convert-powerpoint-to-pdf/), [XPS](/slides/hi/java/convert-powerpoint-to-xps/), [HTML](/slides/hi/java/convert-powerpoint-to-html/), [SVG](/slides/hi/java/render-a-slide-as-an-svg-image/), तथा [images](/slides/hi/java/convert-powerpoint-to-png/) आदि में निर्यात कर सकते हैं।

### क्या मैं टेम्प्लेट (POTX/POTM) से शुरू करके सामान्य PPTX के रूप में सहेज सकता हूँ?

हाँ। टेम्प्लेट लोड करें और इच्छित फॉर्मेट में सहेजें; POTX/POTM/PPTM और समान फॉर्मेट [समर्थित](/slides/hi/java/supported-file-formats/) हैं।

### प्रस्तुति बनाते समय स्लाइड आकार/आस्पेक्ट अनुपात कैसे नियंत्रित करूँ?

[slide size](/slides/hi/java/slide-size/) सेट करें (जैसे 4:3, 16:9 प्रीसेट या कस्टम आयाम) और तय करें कि सामग्री कैसे स्केल होनी चाहिए।

### आकार और निर्देशांक किन इकाइयों में मापे जाते हैं?

पॉइंट में: 1 इंच बराबर 72 यूनिट।

### बहुत बड़ी प्रस्तुतियों (कई मीडिया फ़ाइलों के साथ) को मेमोरी उपयोग कम करने के लिए कैसे संभालूँ?

[BLOB management strategies](/slides/hi/java/manage-blob/) का उपयोग करें, अस्थायी फ़ाइलों के माध्यम से इन‑मेमाॎरी स्टोरेज को सीमित करें, और पूरी‑इन‑मेमाॎरी स्ट्रीम्स की बजाय फ़ाइल‑आधारित वर्कफ़्लो पसंद करें।

### क्या मैं प्रस्तुतियों को समानांतर में बना/सेव कर सकता हूँ?

आप समान [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस को [multiple threads](/slides/hi/java/multithreading/) से नहीं चला सकते। प्रत्येक थ्रेड या प्रोसेस के लिए अलग‑अलग इंस्टेंस चलाएँ।

### ट्रायल वॉटरमार्क और सीमाओं को कैसे हटाऊँ?

प्रोसेस में एक बार [Apply a license](/slides/hi/java/licensing/) लागू करें। लाइसेंस XML को अपरिवर्तित रखें, और यदि कई थ्रेड शामिल हों तो लाइसेंस सेटअप को सिंक्रनाइज़ करें।

### क्या मैं बनायी गयी PPTX को डिजिटल साइन कर सकता हूँ?

हाँ। [Digital signatures](/slides/hi/java/digital-signature-in-powerpoint/) (जोड़ना और सत्यापित करना) प्रस्तुतियों के लिए समर्थित हैं।

### क्या बनायी गयी प्रस्तुतियों में मैक्रो (VBA) समर्थित हैं?

हाँ। आप [create/edit VBA projects](/slides/hi/java/presentation-via-vba/) कर सकते हैं और PPTM/PPSM जैसे मैक्रो‑सक्षम फ़ाइलें सहेज सकते हैं।