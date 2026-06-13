---
title: Android पर प्रस्तुति इंक ऑब्जेक्ट्स को प्रबंधित करें
linktitle: इंक प्रबंधित करें
type: docs
weight: 95
url: /hi/androidjava/manage-ink/
keywords:
- इंक
- इंक ऑब्जेक्ट
- इंक ट्रेस
- इंक प्रबंधित करें
- इंक ड्रॉ करें
- ड्रॉइंग
- PowerPoint
- प्रेज़ेंटेशन
- Android
- Java
- Aspose.Slides
description: "PowerPoint इंक ऑब्जेक्ट्स को प्रबंधित करें—Aspose.Slides for Android के साथ डिजिटल इंक बनाएं, संपादित करें और शैलीबद्ध करें। ट्रेसेस, ब्रश रंग और आकार के लिए Java कोड नमूने प्राप्त करें।"
---
## **परिचय**

PowerPoint इंक फ़ंक्शन प्रदान करता है जिससे आप गैर‑मानक आकृतियों को बना सकते हैं, जिसका उपयोग अन्य वस्तुओं को हाइलाइट करने, कनेक्शन और प्रक्रियाओं को दिखाने, और स्लाइड पर विशिष्ट आइटम्स का ध्यान आकर्षित करने के लिए किया जा सकता है।

Aspose.Slides सभी Ink प्रकार (उदाहरण के लिए [Ink](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ink/) क्लास) प्रदान करता है, जिनकी आपको इंक ऑब्जेक्ट बनाने और प्रबंधित करने की आवश्यकता है।

## **सामान्य वस्तुओं और इंक वस्तुओं के बीच अंतर**

PowerPoint स्लाइड पर वस्तुएँ आमतौर पर shape ऑब्जेक्ट्स द्वारा प्रतिनिधित्व की जाती हैं। एक shape ऑब्जेक्ट, अपने सबसे सरल रूप में, एक कंटेनर होता है जो स्वयं वस्तु (उसका फ्रेम) के क्षेत्र को उसकी विशेषताओं के साथ परिभाषित करता है। बाद में कंटेनर के क्षेत्र का आकार, कंटेनर का आकार, कंटेनर की पृष्ठभूमि आदि शामिल हैं। अधिक जानकारी के लिए, देखें [Shape Layout Format](https://docs.aspose.com/slides/hi/androidjava/shape-manipulations/#access-layout-formats-for-shape)।

हालाँकि, जब PowerPoint एक इंक ऑब्जेक्ट के साथ काम करता है, तो यह ऑब्जेक्ट फ्रेम (कंटेनर) की सभी विशेषताओं को उसके आकार को छोड़कर अनदेखा कर देता है। कंटेनर क्षेत्र का आकार मानक `width` और `height` मानों द्वारा निर्धारित होता है:

![ink_powerpoint1](ink_powerpoint1.png)

## **इंकशेप ट्रेस**

ट्रेस एक बुनियादी तत्व या मानक है जिसका उपयोग पेन की गति को रिकॉर्ड करने के लिए किया जाता है जब उपयोगकर्ता डिजिटल इंक लिखता है। ट्रेस उन रिकॉर्डिंग्स को दर्शाते हैं जो जुड़े हुए बिंदुओं की श्रृंखलाओं का वर्णन करती हैं।

एन्कोडिंग का सबसे सरल रूप प्रत्येक सैंपल बिंदु के X और Y निर्देशांक निर्दिष्ट करता है। जब सभी जुड़े हुए बिंदुओं को रेंडर किया जाता है, तो यह इस प्रकार की छवि बनाती है:

![ink_powerpoint2](ink_powerpoint2.png)

## **ड्रॉइंग के लिए ब्रश प्रॉपर्टीज़**

आप ट्रेस तत्वों के बिंदुओं को जोड़ने वाली रेखाएँ खींचने के लिए ब्रश का उपयोग कर सकते हैं। ब्रश का अपना रंग और आकार होता है, जो `Brush.Color` और `Brush.Size` प्रॉपर्टीज़ से मेल खाता है।

### **इंक ब्रश रंग सेट करें**

यह Java कोड दिखाता है कि ब्रश का रंग कैसे सेट करें:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

### **इंक ब्रश आकार सेट करें**

यह Java कोड दिखाता है कि ब्रश का आकार कैसे सेट करें:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```

आम तौर पर, ब्रश की चौड़ाई और ऊँचाई मेल नहीं खाती, इसलिए PowerPoint ब्रश का आकार प्रदर्शित नहीं करता (डेटा सेक्शन ग्रे आउट हो जाता है)। लेकिन जब ब्रश की चौड़ाई और ऊँचाई मेल खाती है, तो PowerPoint अपने आकार को इस प्रकार दिखाता है:

![ink_powerpoint3](ink_powerpoint3.png)

स्पष्टता के लिए, आइए इंक ऑब्जेक्ट की ऊँचाई बढ़ाएँ और महत्वपूर्ण आयामों की समीक्षा करें:

![ink_powerpoint4](ink_powerpoint4.png)

कंटेनर (फ्रेम) ब्रश के आकार को नहीं मानता—यह हमेशा मान लेता है कि रेखा की मोटाई शून्य है (अंतिम छवि देखें)।

इसलिए, पूरे इंक ऑब्जेक्ट का दृश्यमान क्षेत्र निर्धारित करने के लिए, हमें ट्रेस ऑब्जेक्ट्स के ब्रश आकार को विचार करना होगा। यहाँ, लक्ष्य ऑब्जेक्ट (हैंडरिटन टेक्स्ट ट्रेस ऑब्जेक्ट) को कंटेनर (फ्रेम) के आकार में स्केल किया गया है। जब कंटेनर (फ्रेम) का आकार बदलता है, तो ब्रश का आकार स्थिर रहता है और इसके विपरीत भी।

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint टेक्स्ट के साथ काम करते समय भी यही व्यवहार दिखाता है:

![ink_powerpoint6](ink_powerpoint6.png)

**अधिक पढ़ें**

* सामान्य रूप से शैप्स के बारे में पढ़ने के लिए, देखें [PowerPoint Shapes](https://docs.aspose.com/slides/hi/androidjava/powerpoint-shapes/) सेक्शन।
* प्रभावी मानों के बारे में अधिक जानकारी के लिए, देखें [Shape Effective Properties](https://docs.aspose.com/slides/hi/androidjava/shape-effective-properties/#getting-effective-font-height-value)।