---
title: एंड्रॉइड पर प्रस्तुतियों में लाइन आकृतियों को जोड़ें
linktitle: लाइन
type: docs
weight: 50
url: /hi/androidjava/Line/
keywords:
- लाइन
- लाइन बनाएं
- लाइन जोड़ें
- साधारण लाइन
- लाइन कॉन्फ़िगर करें
- लाइन को अनुकूलित करें
- डैश शैली
- एरो हेड
- पावरपॉइंट
- प्रस्तुति
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "एंड्रॉइड के लिए Aspose.Slides के साथ पावरपॉइंट प्रस्तुतियों में लाइन फ़ॉर्मेटिंग को कैसे नियंत्रित करें, सीखें। गुण, मेथड और जावा उदाहरणों की जाँच करें।"
---
## **परिचय**

Aspose.Slides आपको प्रोग्रामेटिक रूप से PowerPoint स्लाइड्स में लाइन आकृतियाँ जोड़ने की अनुमति देता है। यह लेख सरल लाइन बनाने और लाइन को इस प्रकार कस्टमाइज़ करने के बारे में बताता है कि वह तीर जैसी दिखे।

आप सीखेंगे कि कैसे स्लाइड में लाइन आकृति जोड़ें, उसकी दृश्य उपस्थिति को समायोजित करें, और अद्यतन प्रस्तुतीकरण को सहेजें। उदाहरण व्यावहारिक लाइन फ़ॉर्मेटिंग सेटिंग्स जैसे शैली, चौड़ाई, डैश पैटर्न, एरोहेड विकल्प, और भराव रंग पर केंद्रित हैं।

## **एक साधारण लाइन बनाएं**

- [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
- स्लाइड का संदर्भ उसके Index का उपयोग करके प्राप्त करें.
- [IShapeCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection) ऑब्जेक्ट द्वारा प्रदान की गई [addAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करके Line प्रकार का AutoShape जोड़ें।
- संशोधित प्रस्तुतीकरण को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुतीकरण की पहली स्लाइड में एक लाइन जोड़ी है।

```java
// PPTX फ़ाइल को प्रतिनिधित्व करने वाली PresentationEx क्लास का उदाहरण बनायें
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


## **एक एरो-आकार की लाइन बनाएं**

- [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
- स्लाइड का संदर्भ उसके Index का उपयोग करके प्राप्त करें.
- [IShapeCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection) ऑब्जेक्ट द्वारा प्रदान की गई [addAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करके Line प्रकार का AutoShape जोड़ें।
- [Line Style](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/LineStyle) को Aspose.Slides for Android via Java द्वारा प्रदान की गई शैलियों में से एक पर सेट करें।
- लाइन की चौड़ाई सेट करें।
- लाइन के [Dash Style](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/LineDashStyle) को Aspose.Slides for Android via Java द्वारा प्रदान किए गए शैलियों में से एक पर सेट करें।
- लाइन के प्रारम्भ बिंदु के लिए [Arrow Head Style](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/LineArrowheadStyle) और [Length](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/LineArrowheadLength) सेट करें।
- लाइन के अंत बिंदु के लिए [Arrow Head Style](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/LineArrowheadStyle) और [Length](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/LineArrowheadLength) सेट करें।
- संशोधित प्रस्तुतीकरण को PPTX फ़ाइल के रूप में लिखें।

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली PresentationEx क्लास को इंस्टेंशिएट करें
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

**क्या मैं सामान्य लाइन को कनेक्टर में बदल सकता हूँ ताकि वह आकारों से 'स्नैप' हो सके?**

नहीं। एक सामान्य लाइन (एक [AutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/autoshape/) प्रकार की [Line](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shapetype/)) स्वचालित रूप से कनेक्टर नहीं बनती। इसे आकारों से स्नैप करने के लिए, समर्पित [Connector](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/connector/) प्रकार और कनेक्शन के लिए [corresponding APIs](/slides/hi/androidjava/connector/) का उपयोग करें।

**यदि लाइन की गुणधर्म थीम से विरासत में मिले हों और अंतिम मान तय करना कठिन हो तो मैं क्या करूँ?**

[प्रभावी गुण पढ़ें](/slides/hi/androidjava/shape-effective-properties/) के माध्यम से [ILineFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilinefillformateffectivedata/) इंटरफ़ेस—ये पहले से ही विरासत और थीम शैलियों को ध्यान में रखते हैं।

**क्या मैं एक लाइन को संपादन (हिलाने, आकार बदलने) से लॉक कर सकता हूँ?**

हां। शैलियां [lock objects](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) प्रदान करती हैं जो आपको संपादन कार्यों को अस्वीकार करने देती हैं।