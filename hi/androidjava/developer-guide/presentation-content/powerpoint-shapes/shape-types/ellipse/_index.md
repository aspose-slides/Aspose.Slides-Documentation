---
title: Android पर प्रस्तुतियों में अण्डाकार जोड़ें
linktitle: अण्डाकार
type: docs
weight: 30
url: /hi/androidjava/ellipse/
keywords:
- अण्डाकार
- आकार
- अण्डाकार जोड़ें
- अण्डाकार बनाएं
- अण्डाकार बनाएं
- स्वरूपित अण्डाकार
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में PPT और PPTX प्रस्तुतियों के लिए अण्डाकार आकृतियों को बनाने, स्वरूपित करने और संचालित करने का तरीका सीखें—Java कोड उदाहरण शामिल हैं।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint स्लाइड्स में अण्डाकार आकृतियों को जोड़ने का तरीका दर्शाता है। यह एक साधारण अण्डाकार बनाने, स्वरूपित अण्डाकार बनाने, और अपडेट किए गए प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजने को कवर करता है। इसमें अण्डाकार की स्थिति और आकार, स्टैकिंग क्रम को नियंत्रित करने, और एनिमेशन इफ़ेक्ट्स लागू करने जैसे संबंधित प्रश्नों पर भी चर्चा की गई है।

## **एक अण्डाकार बनाएँ**
एक चयनित स्लाइड में सरल अण्डाकार जोड़ने के लिए नीचे दिए गए चरणों का पालन करें:

- Presentation क्लास का एक इंस्टेंस बनाएं।[Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation)
- स्लाइड को उसके Index से प्राप्त करें।
- IShapeCollection ऑब्जेक्ट द्वारा प्रदान किए गए [addAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करके Ellipse प्रकार का AutoShape जोड़ें।[IShapeCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection)
- संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में हमने पहले स्लाइड में एक अण्डाकार जोड़ा है

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं
Presentation pres = new Presentation();
try {
    // पहले स्लाइड को प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);
    
    // अण्डाकार प्रकार का AutoShape जोड़ें
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // PPTX फ़ाइल को डिस्क पर सहेजें
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **स्वरूपित अण्डाकार बनाएँ**
एक बेहतर स्वरूपित अण्डाकार स्लाइड में जोड़ने के लिए नीचे दिए गए चरणों का पालन करें:

- Presentation क्लास का एक इंस्टेंस बनाएं।[Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation)
- स्लाइड को उसके Index से प्राप्त करें।
- IShapeCollection ऑब्जेक्ट द्वारा प्रदान किए गए [addAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करके Ellipse प्रकार का AutoShape जोड़ें।[IShapeCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection)
- अण्डाकार का Fill Type Solid सेट करें।
- FillFormat ऑब्जेक्ट द्वारा प्रदान किए गए SolidFillColor.Color प्रॉपर्टी का उपयोग करके अण्डाकार का रंग सेट करें।[FillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IFillFormat)
- अण्डाकार की रेखाओं का रंग सेट करें।
- अण्डाकार की रेखाओं की चौड़ाई सेट करें।
- संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में हमने प्रेज़ेंटेशन की पहली स्लाइड में एक स्वरूपित अण्डाकार जोड़ा है।

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं
Presentation pres = new Presentation();
try {
    // पहली स्लाइड को प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);

    // अण्डाकार प्रकार का AutoShape जोड़ें
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // अण्डाकार आकार पर कुछ फ़ॉर्मेटिंग लागू करें
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // अण्डाकार की रेखा पर कुछ फ़ॉर्मेटिंग लागू करें
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

**मैं अण्डाकार की सटीक स्थिति और आकार स्लाइड की इकाइयों के सापेक्ष कैसे सेट करूँ?**

निर्देशांक और आकार आमतौर पर **पॉइंट्स** में निर्दिष्ट किए जाते हैं। सटीक परिणामों के लिए स्लाइड के आकार को आधार बनाकर गणनाएँ करें और मान असाइन करने से पहले आवश्यक मिलीमीटर या इंच को पॉइंट्स में परिवर्तित करें।

**मैं अण्डाकार को अन्य ऑब्जेक्ट्स के ऊपर या नीचे कैसे रखूँ (स्टैकिंग क्रम नियंत्रित करूँ)?**

ऑब्जेक्ट के ड्रॉइंग क्रम को आगे लाकर या पीछे भेजकर समायोजित करें। इससे अण्डाकार अन्य ऑब्जेक्ट्स के ऊपर ओवरलैप कर सकता है या उनके नीचे के हिस्से को दर्शा सकता है।

**मैं अण्डाकार की उपस्थिति या इम्प्रेस को कैसे एनिमेट करूँ?**

[Apply](/slides/hi/androidjava/shape-animation/) प्रवेश, इम्प्रेस या निकास इफ़ेक्ट्स को शैप पर लागू करें, और ट्रिगर एवं टाइमिंग को कॉन्फ़िगर करें ताकि एनीमेशन कब और कैसे चलाए जाएँ।