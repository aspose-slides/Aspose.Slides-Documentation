---
title: Android पर प्रस्तुतियों में लाइन आकार जोड़ें
linktitle: लाइन
type: docs
weight: 50
url: /hi/androidjava/line/
keywords:
- लाइन
- लाइन बनाएं
- लाइन जोड़ें
- साधारण लाइन
- लाइन कॉन्फ़िगर करें
- लाइन कस्टमाइज़ करें
- डैश शैली
- तीर सिरा
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ PowerPoint प्रस्तुतियों में लाइन फ़ॉर्मेटिंग को नियंत्रित करना सीखें। गुण, मेथड और Java उदाहरणों की खोज करें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रोग्रामेटिक रूप से PowerPoint स्लाइड्स में लाइन आकार जोड़ने की अनुमति देता है। यह लेख दिखाता है कि सरल रेखा कैसे बनाएं और रेखा को कैसे कस्टमाइज़ करें ताकि वह तीर के रूप में दिखाई दे।

आप सीखेंगे कि स्लाइड में लाइन आकार कैसे जोड़ें, उसकी दृश्य उपस्थिति को कैसे समायोजित करें, और अपडेटेड प्रस्तुति को कैसे सहेजें। उदाहरण व्यावहारिक लाइन फॉर्मेटिंग सेटिंग्स जैसे शैली, चौड़ाई, डैश पैटर्न, तीर सिरा विकल्प, और भराव रंग पर केंद्रित हैं।

## **साधारण रेखा बनाएं**

एक चयनित स्लाइड में सरल साधारण रेखा जोड़ने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- एक [प्रस्तुति](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) वर्ग का उदाहरण बनाएँ।
- उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
- उस [IShapeCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection) ऑब्जेक्ट द्वारा प्रदान किए गए [addAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करके, लाइन प्रकार का एक AutoShape जोड़ें।
- परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति की पहली स्लाइड में एक रेखा जोड़ी है।

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली PresentationEx क्लास को इंस्टैंसिएट करें
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);
    
    // लाइन प्रकार का AutoShape जोड़ें
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // PPTX को डिस्क पर लिखें
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **तीर-आकार वाली रेखा बनाएं**

Aspose.Slides for Android via Java डेवलपर्स को लाइन की कुछ विशेषताओं को कॉन्फ़िगर करने की अनुमति भी देता है ताकि वह अधिक आकर्षक दिखे। चलिए कुछ विशेषताओं को इस प्रकार कॉन्फ़िगर करते हैं कि रेखा एक तीर जैसा लगे। इसे करने के लिए नीचे दिए गए चरणों का पालन करें:

- एक [प्रस्तुति](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) वर्ग का उदाहरण बनाएँ।
- उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
- उस [IShapeCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection) ऑब्जेक्ट द्वारा प्रदान किए गए [addAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करके, लाइन प्रकार का एक AutoShape जोड़ें।
- [लाइन शैली](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/LineStyle) को Aspose.Slides for Android via Java द्वारा प्रदान किए गए शैलियों में से एक पर सेट करें।
- रेखा की चौड़ाई सेट करें।
- [डैश शैली](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/LineDashStyle) को Aspose.Slides for Android via Java द्वारा प्रदान किए गए शैलियों में से एक पर सेट करें।
- रेखा के प्रारम्भ बिंदु के [तीर सिरा शैली](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/LineArrowheadStyle) और [लंबाई](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/LineArrowheadLength) को सेट करें।
- रेखा के अंत बिंदु के [तीर सिरा शैली](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/LineArrowheadStyle) और [लंबाई](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/LineArrowheadLength) को सेट करें।
- परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली PresentationEx क्लास को इंस्टैंसिएट करें
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);

    // लाइन प्रकार का AutoShape जोड़ें
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // लाइन पर कुछ फ़ॉर्मेटिंग लागू करें
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // PPTX को डिस्क पर लिखें
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक सामान्य रेखा को कनेक्टर में बदल सकता हूँ ताकि वह आकारों से “जुड़” सके?**

नहीं। एक सामान्य रेखा (एक [AutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/autoshape/) जिसका प्रकार [Line](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shapetype/)) स्वतः कनेक्टर नहीं बनती। इसे आकारों से जुड़वाने के लिए, विशेष [Connector](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/connector/) प्रकार और कनेक्शनों के लिए [संबंधित API](/slides/hi/androidjava/connector/) का उपयोग करें।

**यदि किसी रेखा की विशेषताएँ थीम से विरासत में मिली हों और अंतिम मान निर्धारित करना कठिन हो तो मुझे क्या करना चाहिए?**

[प्रभावी विशेषताओं को पढ़ें](/slides/hi/androidjava/shape-effective-properties/) और [ILineFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilinefillformateffectivedata/) इंटरफ़ेस के माध्यम से—ये पहले से ही विरासत और थीम शैलियों को ध्यान में रखते हैं।

**क्या मैं एक रेखा को संपादन (हिलाना, आकार बदलना) से रोक सकता हूँ?**

हाँ। आकार [लॉक ऑब्जेक्ट्स](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) प्रदान करते हैं जो आपको संपादन क्रियाओं को अस्वीकार करने की अनुमति देते हैं।