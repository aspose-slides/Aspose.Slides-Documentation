---
title: जावास्क्रिप्ट में प्रस्तुतियों में आयतें जोड़ें
linktitle: आयत
type: docs
weight: 80
url: /hi/nodejs-java/rectangle/
keywords:
- आयत जोड़ें
- आयत बनाएँ
- आयत आकार
- सरल आयत
- स्वरूपित आयत
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript और Aspose.Slides for Node.js के साथ आयतें जोड़कर अपने PowerPoint प्रस्तुतियों को बढ़ाएँ—आकारों को आसानी से डिज़ाइन और संशोधित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint स्लाइड्स में आयत आकार जोड़ने का तरीका दिखाता है। यह एक साधारण आयत बनाने, एक स्वरूपित आयत बनाने, और अपडेटेड प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजने को कवर करता है।

आप यह भी देखेंगे कि कैसे बुनियादी आयत फ़ॉर्मेटिंग लागू की जाती है, जैसे सॉलिड फ़िल रंग, रेखा रंग, और रेखा चौड़ाई। अतिरिक्त रूप से, लेख का FAQ संबंधित आयत कार्यों की ओर इशारा करता है, जिसमें गोल किनारे, चित्र फ़िल, दृश्य प्रभाव, हाइपरलिंक्स, आकार लॉक, निर्यात विकल्प, और प्रभावी गुण शामिल हैं।

## **स्लाइड में आयत जोड़ें**

पिछले विषयों की तरह, यह भी एक आकार जोड़ने के बारे में है और इस बार हम जिस आकार पर चर्चा करेंगे वह आयत है। इस विषय में हमने वर्णन किया है कि डेवलपर्स Aspose.Slides का उपयोग करके अपनी स्लाइड्स में साधारण या स्वरूपित आयतें कैसे जोड़ सकते हैं।

किसी चयनित स्लाइड में एक साधारण आयत जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का इंस्टेंस बनाएं।
- उसके Index का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
- [ShapeCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection) ऑब्जेक्ट द्वारा प्रदान किए गए [addAutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करके Rectangle प्रकार की एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape) जोड़ें।
- संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रेजेंटेशन की पहली स्लाइड में एक साधारण आयत जोड़ी है।

```javascript
// PPTX का प्रतिनिधित्व करने वाली Prseetation क्लास का उदाहरण बनाएँ
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    var sld = pres.getSlides().get_Item(0);
    // ellipse प्रकार की AutoShape जोड़ें
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **स्लाइड में स्वरूपित आयत जोड़ें**
स्लाइड में एक स्वरूपित आयत जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का इंस्टेंस बनाएं।
- उसके Index का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
- [ShapeCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection) ऑब्जेक्ट द्वारा प्रदान किए गए [addAutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करके Rectangle प्रकार की एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape) जोड़ें।
- आयत का [Fill Type](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FillType) Solid पर सेट करें।
- [FillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FillFormat) ऑब्जेक्ट के माध्यम से प्रदान किए गए [SolidFillColor.setColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) मेथड का उपयोग करके आयत का रंग सेट करें।
- आयत की रेखाओं का रंग सेट करें।
- आयत की रेखाओं की चौड़ाई सेट करें।
- संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

ऊपर दिए गए चरणों को नीचे दिए गए उदाहरण में लागू किया गया है।

```javascript
// PPTX का प्रतिनिधित्व करने वाली Prseetation क्लास को बनाएं
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    var sld = pres.getSlides().get_Item(0);
    // ellipse प्रकार की AutoShape जोड़ें
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // ellipse आकार पर कुछ स्वरूपण लागू करें
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // ellipse की रेखा पर कुछ स्वरूपण लागू करें
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**गोल किनारों वाली आयत कैसे जोड़ूँ?**

गोल‑कोने वाले [shape type](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapetype/) का उपयोग करें और आकार की प्रॉपर्टीज़ में कोना त्रिज्या सेट करें; गोलाई को प्रत्येक कोने के लिए ज्यामिति समायोजन के माध्यम से भी लागू किया जा सकता है।

**चित्र (टेक्सचर) के साथ आयत कैसे भरूँ?**

पिक्चर [fill type](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/filltype/) चुनें, चित्र स्रोत प्रदान करें, और [stretching/tiling modes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillmode/) को कॉन्फ़िगर करें।

**क्या आयत में शैडो और ग्लो हो सकता है?**

हां। [Outer/inner shadow, glow, and soft edges](/slides/hi/nodejs-java/shape-effect/) उपलब्ध हैं और उनके पैरामीटर समायोजित किए जा सकते हैं।

**क्या आयत को हाइपरलिंक के साथ बटन बना सकता हूँ?**

हां। आकार पर क्लिक करने पर (स्लाइड, फ़ाइल, वेब एड्रेस, या ई‑मेल) जाने के लिए [Assign a hyperlink](/slides/hi/nodejs-java/manage-hyperlinks/) सेट करें।

**आयत को स्थानांतरण और बदलाव से कैसे संरक्षित करूँ?**

शेप लॉक उपयोग करें: आप लेआउट को संरक्षित रखने के लिए मूविंग, रिसाइज़िंग, सिलेक्शन या टेक्स्ट एडिटिंग को रोक सकते हैं।

**क्या आयत को रास्टर इमेज या SVG में बदल सकता हूँ?**

हां। आप निर्दिष्ट आकार/स्केल के साथ [render the shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getImage) कर सकते हैं या वेक्टर उपयोग के लिए इसे [export as SVG](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/writeassvg/) कर सकते हैं।

**थीम और इनहेरिटेंस को ध्यान में रखते हुए आयत के वास्तविक (effective) गुण कैसे जल्दी प्राप्त करूँ?**

[shape की effective properties](/slides/hi/nodejs-java/shape-effective-properties/) का उपयोग करें: API उन गणना किए गए मानों को लौटाता है जो थीम स्टाइल, लेआउट, और स्थानीय सेटिंग्स को ध्यान में रखते हैं, जिससे फ़ॉर्मेटिंग विश्लेषण सरल हो जाता है।