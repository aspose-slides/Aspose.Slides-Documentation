---
title: JavaScript में प्रस्तुतियों में रेखा शैप जोड़ें
linktitle: रेखा
type: docs
weight: 50
url: /hi/nodejs-java/line/
keywords:
- रेखा
- रेखा बनाएँ
- रेखा जोड़ें
- साधारण रेखा
- रेखा कॉन्फ़िगर करें
- रेखा अनुकूलित करें
- डैश शैली
- तीर सिरा
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript और Aspose.Slides for Node.js के साथ PowerPoint प्रस्तुतियों में रेखा फ़ॉर्मेटिंग को नियंत्रित करना सीखें। गुण, विधियाँ, और उदाहरणों की खोज करें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रोग्रामेटिक रूप से PowerPoint स्लाइड्स में लाइन शैप जोड़ने की सुविधा देता है। यह लेख दिखाता है कि एक साधारण लाइन कैसे बनाई जाए और उसे तीर के रूप में दिखाने के लिए कैसे अनुकूलित किया जाए।

आप सीखेंगे कि स्लाइड में लाइन शैप कैसे जोड़ी जाए, उसकी दृश्य उपस्थिति कैसे समायोजित की जाए, और अपडेटेड प्रेजेंटेशन को कैसे सेव किया जाए। उदाहरण व्यावहारिक लाइन फ़ॉर्मेटिंग सेटिंग्स जैसे शैली, चौड़ाई, डैश पैटर्न, एरोहेड विकल्प, और भराव रंग पर केंद्रित हैं।

## **साधारण लाइन बनाएं**

प्रेजेंटेशन की चयनित स्लाइड में एक साधारण सीधी लाइन जोड़ने के लिए नीचे दिए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
- स्लाइड का संदर्भ उसके Index का उपयोग करके प्राप्त करें।
- [ShapeCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection) ऑब्जेक्ट द्वारा उजागर [addAutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करके Line प्रकार का AutoShape जोड़ें।
- संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए उदाहरण में हमने प्रेजेंटेशन की पहली स्लाइड में एक लाइन जोड़ दी है।

```javascript
// PresentationEx क्लास को इन्स्टैंशिएट करें जो PPTX फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    var sld = pres.getSlides().get_Item(0);
    // लाइन प्रकार का AutoShape जोड़ें
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // PPTX को डिस्क पर लिखें
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **तीर के आकार की लाइन बनाएं**

Aspose.Slides for Node.js via Java डेवलपर्स को कुछ गुणों को कॉन्फ़िगर करने की अनुमति भी देता है ताकि लाइन अधिक आकर्षक दिखे। आइए कुछ गुणों को इस प्रकार कॉन्फ़िगर करें कि वह तीर जैसा दिखे। इसके लिए नीचे दिए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
- स्लाइड का संदर्भ उसके Index का उपयोग करके प्राप्त करें।
- [ShapeCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection) ऑब्जेक्ट द्वारा उजागर [addAutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करके Line प्रकार का AutoShape जोड़ें।
- Aspose.Slides for Node.js via Java द्वारा प्रदान किए गए शैलियों में से एक को चुनकर [Line Style](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/LineStyle) सेट करें।
- लाइन की चौड़ाई सेट करें।
- Aspose.Slides for Node.js via Java द्वारा प्रदान किए गए शैलियों में से एक को चुनकर लाइन का [Dash Style](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/LineDashStyle) सेट करें।
- लाइन के प्रारंभ बिंदु के लिए [Arrow Head Style](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/LineArrowheadStyle) और [Length](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/LineArrowheadLength) सेट करें।
- लाइन के अंत बिंदु के लिए [Arrow Head Style](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/LineArrowheadStyle) और [Length](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/LineArrowheadLength) सेट करें।
- संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

```javascript
// PresentationEx क्लास को इन्स्टैंशिएट करें जो PPTX फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    var sld = pres.getSlides().get_Item(0);
    // लाइन प्रकार का AutoShape जोड़ें
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // रेखा पर कुछ फ़ॉर्मेटिंग लागू करें
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // PPTX को डिस्क पर लिखें
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं सामान्य लाइन को कनेक्टर में बदल सकता हूँ ताकि वह आकृतियों से “जुड़” सके?**

नहीं। एक सामान्य लाइन (जो type [Line](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapetype/) की [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) है) स्वचालित रूप से कनेक्टर नहीं बनती। इसे आकृतियों से जुड़ाने के लिए विशेष [Connector](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/connector/) प्रकार और कनेक्शन के लिए [corresponding APIs](/slides/hi/nodejs-java/connector/) का उपयोग करें।

**यदि किसी लाइन की गुणधर्म थीम से विरासत में मिले हों और अंतिम मान निर्धारित करना कठिन हो तो मैं क्या करूँ?**

`ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` क्लासेस के माध्यम से [Read the effective properties](/slides/hi/nodejs-java/shape-effective-properties/) पढ़ें—ये पहले से ही विरासत और थीम शैलियों को ध्यान में रखते हैं।

**क्या मैं लाइन को संपादन (हिलाने, आकार बदलने) से लॉक कर सकता हूँ?**

हां। शैप्स [lock objects](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/getautoshapelock/) प्रदान करते हैं जो आपको संपादन ऑपरेशन्स को रोकने की अनुमति देते हैं।