---
title: .NET में प्रस्तुतियों में रेखा आकृतियों को जोड़ें
linktitle: रेखा
type: docs
weight: 50
url: /hi/net/Line/
keywords:
- रेखा
- रेखा बनाएं
- रेखा जोड़ें
- सादी रेखा
- रेखा कॉन्फ़िगर करें
- रेखा को अनुकूलित करें
- डैश शैली
- तीर सिर
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint प्रस्तुतियों में रेखा स्वरूपण को संचालित करना सीखें। गुण, मेथड और उदाहरणों का पता लगाएँ।"
---
## **परिचय**

Aspose.Slides आपको प्रोग्रामेटिक रूप से PowerPoint स्लाइड्स में रेखा आकृतियां जोड़ने की अनुमति देता है। यह लेख दर्शाता है कि कैसे एक साधारण रेखा बनाएं और कैसे एक रेखा को अनुकूलित करें ताकि वह तीर के रूप में दिखे।

आप सीखेंगे कि कैसे एक स्लाइड में रेखा आकृति जोड़ें, उसकी दृश्य उपस्थिति समायोजित करें, और अद्यतन प्रस्तुति को सहेजें। उदाहरण व्यावहारिक रेखा स्वरूपण सेटिंग्स पर केंद्रित हैं, जैसे शैली, चौड़ाई, डैश पैटर्न, एरोहेड विकल्प, और भरने का रंग।

## **साधारण रेखा बनाएं**
प्रस्तुति की चयनित स्लाइड में एक सरल साधारण रेखा जोड़ने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- एक [Presentation ](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation)class का एक उदाहरण बनाएं।
- उसके Index का उपयोग करके स्लाइड का संदर्भ प्राप्त करें.
- Shapes ऑब्जेक्ट द्वारा प्रदर्शित [AddAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/methods/addautoshape/index) मेथड का उपयोग करके Line प्रकार की AutoShape जोड़ें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति की पहली स्लाइड में एक रेखा जोड़ी है।

```c#
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली PresentationEx क्लास का उदाहरण बनाएं
using (Presentation pres = new Presentation())
{
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.Slides[0];

    // लाइन प्रकार की ऑटोशेप जोड़ें
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //PPTX को डिस्क पर लिखें
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **तीर के आकार वाली रेखा बनाएं**
Aspose.Slides for .NET भी डेवलपर्स को रेखा की कुछ गुणों को कॉन्फ़िगर करने की अनुमति देता है ताकि वह अधिक आकर्षक दिखे। चलिए रेखा को तीर जैसा बनाने के लिए कुछ गुण कॉन्फ़िगर करने की कोशिश करते हैं। इसे करने के लिए कृपया नीचे दिए गए चरणों का पालन करें:

- एक [Presentation ](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/hi/aspose.slides/)[](http://www.aspose.com/api/net/slides/hi/aspose.slides/) का उदाहरण बनाएं।
- उसके Index का उपयोग करके स्लाइड का संदर्भ प्राप्त करें.
- Shapes ऑब्जेक्ट द्वारा प्रदर्शित AddAutoShape मेथड का उपयोग करके Line प्रकार की AutoShape जोड़ें।
- Line Style को Aspose.Slides for .NET द्वारा प्रदान की गई शैलियों में से एक पर सेट करें।
- रेखा की चौड़ाई सेट करें।
- रेखा के [Dash Style](https://reference.aspose.com/slides/hi/net/aspose.slides/linedashstyle) को Aspose.Slides for .NET द्वारा प्रदान की गई शैलियों में से एक पर सेट करें।
- रेखा की प्रारंभ बिंदु के [Arrow Head Style](https://reference.aspose.com/slides/hi/net/aspose.slides/linearrowheadstyle) और लंबाई सेट करें।
- रेखा के समाप्ति बिंदु के Arrow Head Style और लंबाई सेट करें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```c#
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली PresentationEx क्लास का उदाहरण बनाएं
using (Presentation pres = new Presentation())
{

    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.Slides[0];

    // लाइन प्रकार की ऑटोशेप जोड़ें
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // रेखा पर कुछ स्वरूपण लागू करें
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //PPTX को डिस्क पर लिखें
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**क्या मैं एक सामान्य रेखा को कनेक्टर में बदल सकता हूँ ताकि वह आकारों से "स्नैप" हो जाए?**

नहीं। एक सामान्य रेखा (एक [AutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/) प्रकार की [Line](https://reference.aspose.com/slides/hi/net/aspose.slides/shapetype/)) स्वचालित रूप से कनेक्टर नहीं बनती। इसे आकारों से स्नैप करने के लिए, समर्पित [Connector](https://reference.aspose.com/slides/hi/net/aspose.slides/connector/) प्रकार और कनेक्शनों के लिए [corresponding APIs](/slides/hi/net/connector/) का उपयोग करें।

**यदि रेखा की गुणावली थीम से विरासत में मिली हो और अंतिम मान निर्धारित करना कठिन हो तो मैं क्या करूँ?**

[Read the effective properties](/slides/hi/net/shape-effective-properties/) के माध्यम से [ILineFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ilinefillformateffectivedata/) इंटरफ़ेस—ये पहले ही विरासत और थीम शैलियों को ध्यान में रखते हैं।

**क्या मैं एक रेखा को संपादन (हिलाने, आकार बदलने) से लॉक कर सकता हूँ?**

हाँ। Shapes [lock objects](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/autoshapelock/) प्रदान करते हैं जो आपको [disallow editing operations](/slides/hi/net/applying-protection-to-presentation/) करने देते हैं।