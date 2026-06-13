---
title: Java में प्रस्तुतियों में लाइन आकृतियों को जोड़ें
linktitle: लाइन
type: docs
weight: 50
url: /hi/java/Line/
keywords:
- लाइन
- लाइन बनाएं
- लाइन जोड़ें
- साधारण लाइन
- लाइन कॉन्फ़िगर करें
- लाइन कस्टमाइज़ करें
- डैश शैली
- तीर सिरे
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint प्रस्तुतियों में लाइन फ़ॉर्मेटिंग को नियंत्रित करना सीखें। गुण, मेथड और उदाहरणों की खोज करें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रोग्रामैटिक रूप से PowerPoint स्लाइड्स में लाइन शेप जोड़ने की सुविधा देता है। यह लेख दर्शाता है कि सरल रेखा कैसे बनाएं और रेखा को कैसे अनुकूलित करें ताकि वह तीर के रूप में दिखाई दे।

आप सीखेंगे कि स्लाइड में लाइन शेप कैसे जोड़ें, उसकी दृश्य उपस्थिति को कैसे समायोजित करें, और अद्यतन प्रस्तुति को कैसे सहेजें। उदाहरण व्यावहारिक रेखा फ़ॉर्मेटिंग सेटिंग्स जैसे शैली, चौड़ाई, डैश पैटर्न, तीर सिरे के विकल्प और भराव रंग पर केंद्रित हैं।

## **साधारण रेखा बनाएँ**

किसी चयनित स्लाइड में एक साधारण रेखा जोड़ने के लिए नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
- उसके Index का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
- [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection) ऑब्जेक्ट द्वारा प्रदान किए गए [addAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करके Line प्रकार की AutoShape जोड़ें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में हमने प्रस्तुति की पहली स्लाइड में एक रेखा जोड़ी है।

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाले PresentationEx क्लास को स्थापित करें
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

## **तीर‑आकार की रेखा बनाएँ**

Aspose.Slides for Java भी डेवलपर्स को रेखा को अधिक आकर्षक बनाने के लिए कुछ गुण कॉन्फ़िगर करने की अनुमति देता है। चलिए रेखा के कुछ गुणों को इस तरह कॉन्फ़िगर करते हैं कि वह तीर जैसा दिखे। ऐसा करने के लिए नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
- उसके Index का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
- [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection) ऑब्जेक्ट द्वारा प्रदान किए गए [addAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करके Line प्रकार की AutoShape जोड़ें।
- लाइन की शैली को Aspose.Slides for Java द्वारा प्रदान की गई शैलियों में से एक पर सेट करें, यह [Line Style](https://reference.aspose.com/slides/hi/java/com.aspose.slides/LineStyle) के माध्यम से किया जाता है।
- रेखा की चौड़ाई निर्धारित करें।
- लाइन की डैश शैली को Aspose.Slides for Java द्वारा प्रदान की गई शैलियों में से एक पर सेट करें, यह [Dash Style](https://reference.aspose.com/slides/hi/java/com.aspose.slides/LineDashStyle) के माध्यम से किया जाता है।
- रेखा के प्रारंभ बिंदु के लिए [Arrow Head Style](https://reference.aspose.com/slides/hi/java/com.aspose.slides/LineArrowheadStyle) और [Length](https://reference.aspose.com/slides/hi/java/com.aspose.slides/LineArrowheadLength) सेट करें।
- रेखा के अंत बिंदु के लिए [Arrow Head Style](https://reference.aspose.com/slides/hi/java/com.aspose.slides/LineArrowheadStyle) और [Length](https://reference.aspose.com/slides/hi/java/com.aspose.slides/LineArrowheadLength) सेट करें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाले PresentationEx क्लास को इंस्टैंसिएट करें
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);

    // लाइन प्रकार की AutoShape जोड़ें
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

**क्या मैं सामान्य रेखा को कनेक्टर में बदल सकता हूँ ताकि वह "स्नैप" करे?**

नहीं। एक सामान्य रेखा (एक [AutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/autoshape/) जिसका प्रकार [Line](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shapetype/)) स्वतः कनेक्टर नहीं बनती। इसे आकारों से स्नैप करने के लिए, समर्पित [Connector](https://reference.aspose.com/slides/hi/java/com.aspose.slides/connector/) प्रकार और कनेक्शनों के लिए [corresponding APIs](/slides/hi/java/connector/) का उपयोग करें।

**यदि रेखा के गुण थीम से विरासत में मिले हों और अंतिम मान निर्धारित करना कठिन हो तो मैं क्या करूँ?**

[प्रभावी गुणधर्म पढ़ें](/slides/hi/java/shape-effective-properties/) [ILineFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilineformateffectivedata)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilinefillformateffectivedata) इंटरफेस के माध्यम से — ये पहले से ही विरासत और थीम शैलियों को ध्यान में रखते हैं।

**क्या मैं रेखा को संपादन (हिलाना, पुनः आकार देना) से लॉक कर सकता हूँ?**

हाँ। शैप्स में [lock objects](https://reference.aspose.com/slides/hi/java/com.aspose.slides/autoshape/#getAutoShapeLock--) उपलब्ध होते हैं जो आपको [disallow editing operations](/slides/hi/java/applying-protection-to-presentation/) करने से रोकते हैं।