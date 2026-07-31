---
title: .NET में प्रस्तुतियों में लाइन शैप जोड़ें
linktitle: लाइन
type: docs
weight: 50
url: /hi/net/line/
keywords:
- लाइन
- लाइन बनाएं
- लाइन जोड़ें
- सादा लाइन
- लाइन कॉन्फ़िगर करें
- लाइन को अनुकूलित करें
- डैश स्टाइल
- एरो हेड
- PowerPoint
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint प्रस्तुतियों में लाइन फ़ॉर्मेटिंग को नियंत्रित करना सीखें। प्रॉपर्टीज़, मेथड्स और उदाहरणों की खोज करें।"
---
## **Overview**

Aspose.Slides आपको प्रोग्रामेटिक रूप से PowerPoint स्लाइड्स में लाइन शैप जोड़ने की अनुमति देता है। यह लेख दिखाता है कि कैसे एक साधारण लाइन बनाएं और कैसे लाइन को एरो के रूप में कस्टमाइज़ करें।

आप सीखेंगे कि स्लाइड में लाइन शैप कैसे जोड़ें, उसकी दृश्य उपस्थिति को कैसे समायोजित करें, और अपडेटेड प्रेजेंटेशन को कैसे सेव करें। उदाहरण व्यावहारिक लाइन फ़ॉर्मेटिंग सेटिंग्स जैसे कि स्टाइल, चौड़ाई, डैश पैटर्न, एरोहेड विकल्प, और फ़िल रंग पर केंद्रित हैं।

## **Create a Plain Line**
प्रेजेंटेशन की चयनित स्लाइड में एक साधारण प्लेन लाइन जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

- [Presentation ](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation)class की एक इंस्टेंस बनाएं।
- उसके Index का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
- Shapes ऑब्जेक्ट द्वारा प्रदान किए गए [AddAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/methods/addautoshape/index) मेथड का उपयोग करके लाइन प्रकार की AutoShape जोड़ें।
- संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रेजेंटेशन की पहली स्लाइड में एक लाइन जोड़ी है।

```c#
 // Instantiate PresentationEx class that represents the PPTX file
using (Presentation pres = new Presentation())
{
    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Add an autoshape of type line
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Write the PPTX to Disk
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **Create an Arrow-Shaped Line**
Aspose.Slides for .NET डेवलपर्स को लाइन की कुछ प्रॉपर्टीज़ को कॉन्फ़िगर करने की भी अनुमति देता है ताकि वह अधिक आकर्षक दिखे। चलिए लाइन की कुछ प्रॉपर्टीज़ को एरो के रूप में दिखाने के लिए कॉन्फ़िगर करते हैं। इसके लिए नीचे दिए गए चरणों का पालन करें:

- [Presentation ](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/hi/aspose.slides/)[](http://www.aspose.com/api/net/slides/hi/aspose.slides/) की एक इंस्टेंस बनाएं।
- उसके Index का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
- Shapes ऑब्जेक्ट द्वारा प्रदान किए गए AddAutoShape मेथड का उपयोग करके लाइन प्रकार की AutoShape जोड़ें।
- Aspose.Slides for .NET द्वारा प्रदान किए गए स्टाइल्स में से एक को Line Style के रूप में सेट करें।
- लाइन की Width सेट करें।
- Aspose.Slides for .NET द्वारा प्रदान किए गए स्टाइल्स में से एक को लाइन की [Dash Style](https://reference.aspose.com/slides/hi/net/aspose.slides/linedashstyle) के रूप में सेट करें।
- लाइन के प्रारंभ बिंदु की [Arrow Head Style](https://reference.aspose.com/slides/hi/net/aspose.slides/linearrowheadstyle) और Length सेट करें।
- लाइन के अंत बिंदु की Arrow Head Style और Length सेट करें।
- संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

```c#
 // PPTX फ़ाइल का प्रतिनिधित्व करने वाली PresentationEx क्लास को इंस्टैंसिएट करें
using (Presentation pres = new Presentation())
{

    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.Slides[0];

    // लाइन प्रकार की ऑटोशेप जोड़ें
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // लाइन पर कुछ फ़ॉर्मेटिंग लागू करें
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

**Can I convert a regular line into a connector so it "snaps" to shapes?**

No. A regular line (an [AutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/) of type [Line](https://reference.aspose.com/slides/hi/net/aspose.slides/shapetype/)) does not automatically become a connector. To make it snap to shapes, use the dedicated [Connector](https://reference.aspose.com/slides/hi/net/aspose.slides/connector/) type and the [corresponding APIs](/slides/hi/net/connector/) for connections.

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

[Read the effective properties](/slides/hi/net/shape-effective-properties/) through the [ILineFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ilinefillformateffectivedata/) interfaces—these already account for inheritance and theme styles.

**Can I lock a line against editing (moving, resizing)?**

Yes. Shapes provide [lock objects](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/autoshapelock/) that let you [disallow editing operations](/slides/hi/net/applying-protection-to-presentation/).