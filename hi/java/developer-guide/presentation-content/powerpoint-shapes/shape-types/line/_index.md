---
title: जावा में प्रस्तुतियों में लाइन आकार जोड़ें
linktitle: लाइन
type: docs
weight: 50
url: /hi/java/line/
keywords:
- रेखा
- रेखा बनाएं
- रेखा जोड़ें
- सादा रेखा
- रेखा कॉन्फ़िगर करें
- रेखा अनुकूलित करें
- डैश शैली
- तीर सिर
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint प्रस्तुतियों में लाइन फॉर्मेटिंग को नियंत्रित करना सीखें। गुण, मेथड और उदाहरणों की खोज करें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रोग्रामेटिक रूप से PowerPoint स्लाइड्स में लाइन आकार जोड़ने की अनुमति देता है। यह लेख सरल रेखा बनाने और रेखा को इस तरह अनुकूलित करने को दर्शाता है कि वह तीर की तरह दिखे।

आप सीखेंगे कि स्लाइड में लाइन आकार कैसे जोड़ें, उसकी दिखावट को कैसे समायोजित करें, और अपडेटेड प्रस्तुति को कैसे सहेजें। उदाहरण व्यावहारिक लाइन फॉर्मेटिंग सेटिंग्स जैसे शैली, चौड़ाई, डैश पैटर्न, एरोहेड विकल्प, और भराव रंग पर केंद्रित हैं।

## **सरल रेखा बनाना**

एक चयनित स्लाइड में सरल साधारण रेखा जोड़ने के लिए नीचे दिए गए चरणों का पालन करें:

- Create an instance of [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) class.
- स्लाइड का संदर्भ उसके Index का उपयोग करके प्राप्त करें।
- [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection) ऑब्जेक्ट द्वारा प्रदान किए गए [addAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करके Line प्रकार की AutoShape जोड़ें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति की पहली स्लाइड में एक लाइन जोड़ी है।

```java
// PPTX फ़ाइल को प्रतिनिधित्व करने वाली PresentationEx क्लास का उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);
    
    // लाइन प्रकार की AutoShape जोड़ें
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // PPTX को डिस्क पर लिखें
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **तीर-आकार वाली लाइन बनाना**

Aspose.Slides for Java भी डेवलपर्स को लाइन की कुछ विशेषताएँ कॉन्फ़िगर करने की अनुमति देता है ताकि वह अधिक आकर्षक दिखे। चलिए लाइन के कुछ गुण कॉन्फ़िगर करते हैं ताकि वह तीर जैसा दिखे। इसके लिए नीचे दिए गए चरणों का पालन करें:

- Create an instance of [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) class.
- स्लाइड का संदर्भ उसके Index के द्वारा प्राप्त करें।
- [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection) ऑब्जेक्ट द्वारा प्रदान किए गए [addAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करके Line प्रकार की AutoShape जोड़ें।
- Aspose.Slides for Java द्वारा प्रदान की गई शैलियों में से एक को चुनते हुए [Line Style](https://reference.aspose.com/slides/hi/java/com.aspose.slides/LineStyle) सेट करें।
- लाइन की Width सेट करें।
- Aspose.Slides for Java द्वारा प्रदान की गई शैलियों में से एक को चुनते हुए लाइन का [Dash Style](https://reference.aspose.com/slides/hi/java/com.aspose.slides/LineDashStyle) सेट करें।
- लाइन की प्रारंभ बिंदु के लिए [Arrow Head Style](https://reference.aspose.com/slides/hi/java/com.aspose.slides/LineArrowheadStyle) और [Length](https://reference.aspose.com/slides/hi/java/com.aspose.slides/LineArrowheadLength) सेट करें।
- लाइन के अंत बिंदु के लिए [Arrow Head Style](https://reference.aspose.com/slides/hi/java/com.aspose.slides/LineArrowheadStyle) और [Length](https://reference.aspose.com/slides/hi/java/com.aspose.slides/LineArrowheadLength) सेट करें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```java
// PPTX फ़ाइल को दर्शाने वाली PresentationEx क्लास का उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);

    // लाइन प्रकार की AutoShape जोड़ें
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // लाइन पर कुछ फॉर्मेटिंग लागू करें
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // PPTX को डिस्क पर सहेजें
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं साधारण रेखा को कनेक्टर में बदल सकता हूँ ताकि वह आकृति के साथ "स्नैप" हो सके?**

नहीं। एक साधारण रेखा (एक [AutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/autoshape/) जिसका प्रकार [Line](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shapetype/)) स्वतः कनेक्टर नहीं बनती। इसे आकृति के साथ स्नैप करने के लिए, समर्पित [Connector](https://reference.aspose.com/slides/hi/java/com.aspose.slides/connector/) प्रकार और कनेक्शन के लिए [corresponding APIs](/slides/hi/java/connector/) का उपयोग करें।

**यदि लाइन के गुण थीम से विरासत में मिलते हैं और अंतिम मान निर्धारित करना कठिन है तो मुझे क्या करना चाहिए?**

[Read the effective properties](/slides/hi/java/shape-effective-properties/) को [ILineFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilinefillformateffectivedata/) इंटरफ़ेस के माध्यम से देखें—ये पहले से ही विरासत और थीम शैलियों को ध्यान में रखते हैं।

**क्या मैं लाइन को संपादन (स्थानांतरण, आकार बदलना) से रोक सकता हूँ?**

हां। आकारों में [lock objects](https://reference.aspose.com/slides/hi/java/com.aspose.slides/autoshape/#getAutoShapeLock--) होते हैं जो आपको [disallow editing operations](/slides/hi/java/applying-protection-to-presentation/) करने अनुमति देते हैं।