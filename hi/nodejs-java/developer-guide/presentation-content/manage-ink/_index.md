---
title: जावास्क्रिप्ट में प्रेज़ेंटेशन इंक ऑब्जेक्ट्स प्रबंधित करें
linktitle: इंक प्रबंधित करें
type: docs
weight: 95
url: /hi/nodejs-java/manage-ink/
keywords:
- इंक
- इंक ऑब्जेक्ट
- इंक ट्रेस
- इंक प्रबंधित करें
- इंक बनाएं
- ड्राइंग
- PowerPoint
- प्रेज़ेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint इंक ऑब्जेक्ट्स को प्रबंधित करें—डिजिटल इंक को बनाएं, संपादित करें और शैली दें Aspose.Slides for Node.js के साथ। ट्रेसेज़, ब्रश रंग और आकार के लिए JavaScript कोड उदाहरण प्राप्त करें।"
---
## **परिचय**

PowerPoint इनक फ़ंक्शन प्रदान करता है जिससे आप गैर‑मानक आकृतियाँ बना सकते हैं, जिसे अन्य वस्तुओं को उजागर करने, कनेक्शन और प्रक्रियाएँ दिखाने, और स्लाइड पर विशिष्ट आइटम्स पर ध्यान आकर्षित करने के लिए उपयोग किया जा सकता है।

Aspose.Slides सभी Ink प्रकार (जैसे [Ink](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ink/) क्लास) प्रदान करता है जो आपको इनक ऑब्जेक्ट्स को बनाने और प्रबंधित करने के लिए आवश्यक हैं।

## **सामान्य ऑब्जेक्ट और इनक ऑब्जेक्ट्स के बीच अंतर**

PowerPoint स्लाइड पर ऑब्जेक्ट्स आमतौर पर शैप ऑब्जेक्ट्स के रूप में दर्शाए जाते हैं। एक शैप ऑब्जेक्ट, अपने सबसे सरल रूप में, एक कंटेनर होता है जो ऑब्जेक्ट के स्वयं के क्षेत्र (उसका फ्रेम) तथा उसकी गुणधर्मों को परिभाषित करता है। बाद वाला कंटेनर का आकार, कंटेनर का आकार, कंटेनर की पृष्ठभूमि आदि को शामिल करता है। विस्तृत जानकारी के लिए देखें [Shape Layout Format](https://docs.aspose.com/slides/hi/nodejs-java/shape-manipulations/#access-layout-formats-for-shape)।

हालाँकि, जब PowerPoint इनक ऑब्जेक्ट से निपटता है, तो यह ऑब्जेक्ट फ्रेम (कंटेनर) की सभी गुणधर्मों को आकार को छोड़कर अनदेखा करता है। कंटेनर क्षेत्र का आकार मानक `width` और `height` मानों द्वारा निर्धारित होता है:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape ट्रेसेज़**

ट्रेस एक बुनियादी तत्व या मानक है जिसका उपयोग पेन की गति को रिकॉर्ड करने के लिए किया जाता है जब उपयोगकर्ता डिजिटल इनक लिखता है। ट्रेसेस रिकॉर्डिंग होते हैं जो जुड़े हुए बिंदुओं की क्रमिकता का वर्णन करते हैं।

एन्कोडिंग का सबसे सरल रूप प्रत्येक नमूना बिंदु के X और Y निर्देशांक निर्दिष्ट करता है। जब सभी जुड़े हुए बिंदुओं को रेंडर किया जाता है, तो वे इस प्रकार की छवि उत्पन्न करते हैं:

![ink_powerpoint2](ink_powerpoint2.png)

## ड्राइंग के लिए ब्रश गुणधर्म

आप एक ब्रश का उपयोग करके ट्रेस तत्वों के बिंदुओं को जोड़ने वाली रेखाएँ बना सकते हैं। ब्रश का अपना रंग और आकार होता है, जो `Brush.setColor` और `Brush.setSize` मेथड्स के अनुरूप होता है।

### **Ink ब्रश रंग सेट करें**

यह JavaScript कोड दिखाता है कि आप ब्रश का रंग कैसे सेट कर सकते हैं:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ink ब्रश आकार सेट करें**

यह JavaScript कोड दिखाता है कि आप ब्रश का आकार कैसे सेट कर सकते हैं:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

सामान्यतः, ब्रश की चौड़ाई और ऊँचाई मेल नहीं खाती, इसलिए PowerPoint ब्रश का आकार नहीं दिखाता (डेटा सेक्शन ग्रेेड आउट रहता है)। लेकिन जब ब्रश की चौड़ाई और ऊँचाई समान होती है, तो PowerPoint अपने आकार को इस प्रकार दिखाता है:

![ink_powerpoint3](ink_powerpoint3.png)

स्पष्टता के लिये, चलिए इनक ऑब्जेक्ट की ऊँचाई बढ़ाते हैं और महत्वपूर्ण आयामों की समीक्षा करते हैं:

![ink_powerpoint4](ink_powerpoint4.png)

कंटेनर (फ़्रेम) ब्रश के आकार को नहीं मानता — यह हमेशा मानता है कि रेखा की मोटाई शून्य है (अंतिम छवि देखें)।

इसलिए, पूरे इनक ऑब्जेक्ट के दृश्यमान क्षेत्र को निर्धारित करने के लिये, हमें ट्रेस ऑब्जेक्ट्स के ब्रश आकार को ध्यान में रखना पड़ता है। यहाँ, लक्ष्य ऑब्जेक्ट (हैंडराइटन टेक्स्ट ट्रेस ऑब्जेक्ट) को कंटेनर (फ़्रेम) आकार के अनुसार स्केल किया गया है। जब कंटेनर (फ़्रेम) का आकार बदलता है, तो ब्रश का आकार स्थिर रहता है और इसके विपरीत।

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint टेक्स्ट्स से निपटते समय भी वही व्यवहार प्रदर्शित करता है:

![ink_powerpoint6](ink_powerpoint6.png)

**आगे पढ़ें**

* शैप्स के बारे में सामान्य जानकारी के लिये, देखें [PowerPoint Shapes](https://docs.aspose.com/slides/hi/nodejs-java/powerpoint-shapes/) अनुभाग।
* प्रभावी मानों के बारे में अधिक जानकारी के लिये, देखें [Shape Effective Properties](https://docs.aspose.com/slides/hi/nodejs-java/shape-effective-properties/#getting-effective-font-height-value)।