---
title: Java में प्रेज़ेंटेशन में दीर्घवृत्त जोड़ें
linktitle: दीर्घवृत्त
type: docs
weight: 30
url: /hi/java/ellipse/
keywords:
- दीर्घवृत्त
- आकार
- दीर्घवृत्त जोड़ें
- दीर्घवृत्त बनाएं
- दीर्घवृत्त खींचें
- स्वरूपित दीर्घवृत्त
- PowerPoint
- प्रेज़ेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में PPT और PPTX प्रेज़ेंटेशन के लिए दीर्घवृत्त आकार बनाना, स्वरूपित करना और उनका संचालन सीखें—Java कोड उदाहरण शामिल हैं।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint स्लाइड्स में दीर्घवृत्त आकार जोड़ने का तरीका दिखाता है। यह एक सरल दीर्घवृत्त बनाने, एक स्वरूपित दीर्घवृत्त बनाने, और अपडेटेड प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजने को कवर करता है। यह दीर्घवृत्त की स्थिति और आकार के साथ काम करना, स्टैकिंग क्रम को नियंत्रित करना, और एनीमेशन प्रभाव लागू करना जैसे संबंधित प्रश्नों को भी छूता है।

## **एक दीर्घवृत्त बनाएं**
एक चयनित स्लाइड में सरल दीर्घवृत्त जोड़ने के लिए नीचे दिए गए चरणों का पालन करें:

- Presentation क्लास का एक इंस्टेंस बनाएं।
- इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
- Ellipse प्रकार का AutoShape जोड़ने के लिए [addAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करें, जो [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection) ऑब्जेक्ट द्वारा एक्सपोज़ किया गया है।
- संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने पहली स्लाइड में एक दीर्घवृत्त जोड़ा है

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);
    
    // ellipse प्रकार का AutoShape जोड़ें
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // PPTX फ़ाइल को डिस्क पर सहेजें
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **एक स्वरूपित दीर्घवृत्त बनाएं**
एक बेहतर स्वरूपित दीर्घवृत्त स्लाइड में जोड़ने के लिए नीचे दिए गए चरणों का पालन करें:

- Presentation क्लास का एक इंस्टेंस बनाएं।
- इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
- Ellipse प्रकार का AutoShape जोड़ने के लिए [addAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करें, जो [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection) ऑब्जेक्ट द्वारा एक्सपोज़ किया गया है।
- दीर्घवृत्त का Fill Type सॉलिड सेट करें।
- दीर्घवृत्त का रंग SolidFillColor.Color प्रॉपर्टी का उपयोग करके सेट करें, जो [FillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IFillFormat) ऑब्जेक्ट द्वारा एक्सपोज़ किया गया है और [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape) ऑब्जेक्ट से जुड़ा है।
- दीर्घवृत्त की लाइनों का रंग सेट करें।
- दीर्घवृत्त की लाइनों की चौड़ाई सेट करें।
- संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रेज़ेंटेशन की पहली स्लाइड में एक स्वरूपित दीर्घवृत्त जोड़ा है।

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);

    // ellipse प्रकार का AutoShape जोड़ें
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // ellipse आकार पर कुछ स्वरूपण लागू करें
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // ellipse की रेखा पर कुछ स्वरूपण लागू करें
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // PPTX फ़ाइल को डिस्क पर सहेजें
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं स्लाइड की इकाइयों के संदर्भ में दीर्घवृत्त की सटीक स्थिति और आकार कैसे सेट करूँ?**

निर्देशांक और आकार आमतौर पर **पॉइंट्स** में निर्दिष्ट किए जाते हैं। पूर्वानुमानित परिणामों के लिए, अपने गणनाओं को स्लाइड के आकार पर आधारित रखें और मान असाइन करने से पहले आवश्यक मिलीमीटर या इंच को पॉइंट्स में बदलें।

**मैं दीर्घवृत्त को अन्य वस्तुओं के ऊपर या नीचे कैसे रख सकता हूँ (स्टैकिंग क्रम नियंत्रित करना)?**

ऑब्जेक्ट के ड्रॉइंग क्रम को समायोजित करके उसे आगे ले जाएँ या पीछे भेजें। इससे दीर्घवृत्त अन्य वस्तुओं को ओवरलैप कर सकेगा या उनके नीचे की वस्तुओं को प्रकट कर सकेगा।

**मैं दीर्घवृत्त की उपस्थिति या ज़ोर देने को कैसे एनीमेट करूँ?**

[Apply](/slides/hi/java/shape-animation/) एंट्रेंस, इम्पेरेसिस, या एग्ज़िट इफ़ेक्ट्स आकार पर लागू करें, और ट्रिगर्स व टाइमिंग कॉन्फ़िगर करें ताकि एनीमेशन कब और कैसे चले, इसे नियंत्रित किया जा सके।