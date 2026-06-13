---
title: जावा में प्रस्तुति इंक ऑब्जेक्ट का प्रबंधन
linktitle: इंक प्रबंधन
type: docs
weight: 95
url: /hi/java/manage-ink/
keywords:
- इंक
- इंक ऑब्जेक्ट
- इंक ट्रेस
- इंक प्रबंधित करें
- इंक बनाएं
- ड्राइंग
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "PowerPoint इंक ऑब्जेक्ट को प्रबंधित करें—Aspose.Slides for Java के साथ डिजिटल इंक बनाएं, संपादित करें और स्टाइल करें। ट्रेस, ब्रश रंग और आकार के कोड उदाहरण प्राप्त करें।"
---
## **परिचय**

PowerPoint इंक फ़ंक्शन प्रदान करता है जिससे आप गैर‑मानक आकृतियां बना सकते हैं, जिन्हें अन्य वस्तुओं को उजागर करने, कनेक्शन और प्रक्रियाएं दिखाने, और स्लाइड पर विशिष्ट आइटम पर ध्यान आकर्षित करने के लिए उपयोग किया जा सकता है।

Aspose.Slides सभी Ink प्रकार प्रदान करता है (जैसे कि [Ink](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ink/) क्लास) जो आपको इंक ऑब्जेक्ट बनाने और प्रबंधित करने की आवश्यकता है।

## **सामान्य वस्तुएँ और इंक वस्तुओं के बीच अंतर**

PowerPoint स्लाइड पर वस्तुएँ आम तौर पर shape ऑब्जेक्ट द्वारा दर्शाई जाती हैं। एक shape ऑब्जेक्ट, सबसे सरल रूप में, वह कंटेनर है जो स्वयं वस्तु (उसका फ्रेम) के क्षेत्र तथा उसकी गुणों को परिभाषित करता है। बाद वाले में कंटेनर के क्षेत्र का आकार, कंटेनर का आकार, बैकग्राउंड आदि शामिल होते हैं। अधिक जानकारी के लिए देखें [Shape Layout Format](https://docs.aspose.com/slides/hi/java/shape-manipulations/#access-layout-formats-for-shape)।

हालाँकि, जब PowerPoint इंक ऑब्जेक्ट के साथ काम करता है, तो वह ऑब्जेक्ट फ्रेम (कंटेनर) की सभी गुणों को, केवल आकार को छोड़कर, नज़रअंदाज़ कर देता है। कंटेनर क्षेत्र का आकार मानक `width` और `height` मानों द्वारा निर्धारित होता है:

![ink_powerpoint1](ink_powerpoint1.png)

## **इंकशेप ट्रेसेज़**

ट्रेस एक बुनियादी तत्व या मानक है जिसे डिजिटल इंक लिखते समय पेन की गति को रिकॉर्ड करने के लिए उपयोग किया जाता है। ट्रेसेज़ उन रिकॉर्डिंग्स को कहा जाता है जो जुड़े हुए बिंदुओं की क्रमिकता का वर्णन करती हैं।

सबसे सरल एन्कोडिंग रूप प्रत्येक सैंपल बिंदु के X और Y निर्देशांक को निर्दिष्ट करता है। जब सभी जुड़े बिंदुओं को रेंडर किया जाता है, तो यह इस प्रकार की छवि बनती है:

![ink_powerpoint2](ink_powerpoint2.png)

## **ड्रॉइंग के लिए ब्रश गुण**

आप ब्रश का उपयोग करके ट्रेस तत्वों के बिंदुओं को जोड़ती रेखाएँ बना सकते हैं। ब्रश का अपना रंग और आकार होता है, जो `Brush.Color` और `Brush.Size` गुणों के अनुरूप होते हैं।

### **इंक ब्रश का रंग सेट करें**

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

### **इंक ब्रश का आकार सेट करें**

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

आमतौर पर, ब्रश की चौड़ाई और ऊँचाई समान नहीं होती, इसलिए PowerPoint ब्रश आकार को प्रदर्शित नहीं करता (डेटा सेक्शन ग्रे हो जाता है)। लेकिन जब ब्रश की चौड़ाई और ऊँचाई समान होती है, तो PowerPoint इस प्रकार उसका आकार दिखाता है:

![ink_powerpoint3](ink_powerpoint3.png)

स्पष्टीकरण के लिए, आइए इंक ऑब्जेक्ट की ऊँचाई बढ़ाएँ और महत्वपूर्ण आयामों की समीक्षा करें:

![ink_powerpoint4](ink_powerpoint4.png)

कंटेनर (फ़्रेम) ब्रश के आकार को नहीं मानता—यह हमेशा मानता है कि रेखा की मोटाई शून्य है (अंतिम छवि देखें)।

इसलिए पूरे इंक ऑब्जेक्ट के दृश्य क्षेत्र को निर्धारित करने के लिए हमें ट्रेस ऑब्जेक्ट के ब्रश आकार को ध्यान में रखना होगा। यहाँ लक्ष्य ऑब्जेक्ट (हस्तलेख ट्रेस ऑब्जेक्ट) को कंटेनर (फ़्रेम) के आकार के अनुसार स्केल किया गया है। जब कंटेनर (फ़्रेम) का आकार बदलता है, तो ब्रश आकार स्थिर रहता है और इसके विपरीत भी यही सत्य है।

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint पाठ्य सामग्री के साथ भी यही व्यवहार दर्शाता है:

![ink_powerpoint6](ink_powerpoint6.png)

**आगे पढ़ें**

* आकृतियों के बारे में सामान्य जानकारी के लिए, [PowerPoint Shapes](https://docs.aspose.com/slides/hi/java/powerpoint-shapes/) अनुभाग देखें।  
* प्रभावी मानों के बारे में अधिक जानकारी के लिए, देखें [Shape Effective Properties](https://docs.aspose.com/slides/hi/java/shape-effective-properties/#getting-effective-font-height-value)।