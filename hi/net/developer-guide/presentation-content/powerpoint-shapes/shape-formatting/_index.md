---
title: .NET में PowerPoint आकृतियों को स्वरूपित करें
linktitle: आकृति स्वरूपण
type: docs
weight: 20
url: /hi/net/shape-formatting/
keywords:
- आकृति स्वरूपण
- रेखा स्वरूपण
- स्केच प्रभाव
- आकृति रेखा स्केच
- जॉइन शैली स्वरूपण
- ग्रेडिएंट फ़िल
- पैटर्न फ़िल
- चित्र फ़िल
- टेक्सचर फ़िल
- सॉलिड रंग फ़िल
- आकृति पारदर्शिता
- काली-सफ़ेद आकृति रेंडरिंग
- ग्रेस्केल आकृति रेंडरिंग
- आकृति घुमाएँ
- 3D बिवेल प्रभाव
- 3D घुमाव प्रभाव
- स्वरूपण रीसेट करें
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके C# में PowerPoint आकृतियों को स्वरूपित करना सीखें—PPT और PPTX फ़ाइलों के लिए भराव, रेखा और प्रभाव शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में आप स्लाइड्स में आकृतियाँ (shapes) जोड़ सकते हैं। चूँकि आकृतियाँ रेखाओं से बनी होती हैं, आप उनकी रूपरेखा (outline) को संशोधित या प्रभाव (effects) लागू करके स्वरूपित कर सकते हैं। अतिरिक्त रूप से, आप आकृति के अंदर के भाग को भरने के विकल्पों को निर्दिष्ट करके स्वरूपित कर सकते हैं।

![फ़ॉर्मेट‑शेप‑पॉवरपॉइंट](format-shape-powerpoint.png)

Aspose.Slides for .NET में ऐसी इंटरफ़ेस और गुण (properties) उपलब्ध हैं जो आपको PowerPoint में उपलब्ध समान विकल्पों का उपयोग करके आकृतियों को स्वरूपित करने की अनुमति देते हैं।

## **लाइन स्वरूपण**

Aspose.Slides का उपयोग करके आप किसी आकृति के लिए कस्टम लाइन शैली निर्दिष्ट कर सकते हैं। नीचे दिए गए चरण इस प्रक्रिया को दर्शाते हैं:

1. एक instance बनाएं [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास का।
1. उसके इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) जोड़ें।
1. आकृति की [line style](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) सेट करें।
1. लाइन की चौड़ाई सेट करें।
1. लाइन की [dash style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) सेट करें।
1. आकृति के लिए लाइन रंग सेट करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्न C# कोड दर्शाता है कि कैसे एक आयताकार `AutoShape` की लाइन स्वरूपित की जाती है:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का एक उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // Rectangle प्रकार की एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Rectangle आकृति के लिए भराव रंग सेट करें।
    shape.FillFormat.FillType = FillType.NoFill;

    // Rectangle की लाइनों पर स्वरूपण लागू करें।
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Rectangle की लाइन के लिए रंग सेट करें।
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![प्रेज़ेंटेशन में स्वरूपित रेखाएँ](formatted-lines.png)

## **आकृति लाइनों पर स्केच प्रभाव लागू करें**

स्केच प्रभाव से आकृति की लाइन हाथ से लिखी हुई दिखती है। [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) का उपयोग करके लाइन सेटिंग्स तक पहुंचें, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) द्वारा स्केच सेटिंग्स तक पहुंचें, और [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) का प्रयोग करके [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) enumeration से एक मान चुनें।

निम्न C# कोड दिखाता है कि कैसे एक [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) प्रभाव लागू किया जाता है, स्पष्ट रूप से असाइन किया गया मान पढ़ा जाता है, और [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) द्वारा प्रभाव हटाया जाता है:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

`ISketchFormat.SketchType` द्वारा वापस किया गया मान सीधे आकृति पर सेट किया गया मान दर्शाता है। यदि लाइन स्वरूपण थीम, मास्टर स्लाइड या लेआउट स्लाइड से विरासत में मिल सकता है, तो [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/) का उपयोग करें, [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/) तक पहुंचें, और [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/) पढ़ें। प्रभावी मान वास्तव में विरासत समाधान के बाद लागू स्वरूपण को दर्शाता है:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **जॉइन शैली स्वरूपण**

तीन जॉइन प्रकार विकल्प हैं:

* Round
* Miter
* Bevel

डिफ़ॉल्ट रूप से, जब PowerPoint दो लाइनों को किसी कोण पर जोड़ता है (जैसे आकृति के कोने पर), तो यह **Round** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीखे कोण वाली आकृति बना रहे हैं, तो आप **Miter** विकल्प को प्राथमिकता दे सकते हैं।

![प्रेज़ेंटेशन में जॉइन शैली](join-style-powerpoint.png)

निम्न C# कोड दर्शाता है कि ऊपर दिखाए गए चित्र में तीन आयतें Miter, Bevel, और Round जॉइन प्रकार सेटिंग्स का उपयोग करके कैसे बनाई गईं:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का एक उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // Rectangle प्रकार की तीन ऑटो शैप जोड़ें।
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // प्रत्येक आयत आकृति के लिए भराव रंग सेट करें।
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // रेखा की चौड़ाई सेट करें।
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // प्रत्येक आयत की रेखा के लिए रंग सेट करें।
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // जॉइन शैली सेट करें।
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // प्रत्येक आयत में पाठ जोड़ें।
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **ग्रेडिएंट फ़िल**

PowerPoint में Gradient Fill एक स्वरूपण विकल्प है जो आपको आकृति पर निरंतर रंग मिश्रण लागू करने देता है। उदाहरण के लिए, आप दो या अधिक रंग इस तरह लागू कर सकते हैं कि एक क्रमशः दूसरे में मिल जाता है।

Aspose.Slides का उपयोग करके आकृति पर ग्रेडिएंट फ़िल लागू करने के चरण:

1. एक instance बनाएं [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास का।
1. उसके इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) को `Gradient` सेट करें।
1. ग्रेडिएंट स्टॉप संग्रह के `Add` मेथड्स का उपयोग करके दो पसंदीदा रंगों को परिभाषित स्थितियों के साथ जोड़ें, जैसा कि [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/) इंटरफ़ेस द्वारा प्रदर्शित किया गया है।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्न C# कोड दर्शाता है कि कैसे एक दीर्घवृत्त (ellipse) पर ग्रेडिएंट फ़िल प्रभाव लागू किया जाता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // Ellipse प्रकार की एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // दीर्घवृत्त पर ग्रेडिएंट स्वरूपण लागू करें।
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // ग्रेडिएंट की दिशा सेट करें।
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // दो ग्रेडिएंट स्टॉप जोड़ें।
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![ग्रेडिएंट फ़िल वाला दीर्घवृत्त](gradient-fill.png)

यदि ग्रेडिएंट निर्यात किए गए चित्र में PowerPoint की तुलना में अलग दिखता है, तो देखें [Choose a Gradient Rendering Style](/slides/hi/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)। आप प्रस्तुति में संग्रहित ग्रेडिएंट फ़िल को बदले बिना रेंडरिंग शैली चुन सकते हैं।

## **पैटर्न फ़िल**

PowerPoint में Pattern Fill एक स्वरूपण विकल्प है जो आपको दो‑रंगीय डिजाइन—जैसे बिंदु, धारी, क्रॉसहैच या चेक—आकृति पर लागू करने देता है। आप पैटर्न के अग्रभूमि और पृष्ठभूमि रंगों के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides में 45 से अधिक पूर्वपरिभाषित पैटर्न शैलियाँ उपलब्ध हैं जिन्हें आप आकृतियों पर लागू कर अपनी प्रस्तुतियों की दृश्य अपील बढ़ा सकते हैं। पूर्वपरिभाषित पैटर्न चुनने के बाद भी आप वह सटीक रंग निर्दिष्ट कर सकते हैं जिसका उपयोग वह करनी चाहिए।

Aspose.Slides का उपयोग करके आकृति पर पैटर्न फ़िल लागू करने के चरण:

1. एक instance बनाएं [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास का।
1. उसके इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) को `Pattern` सेट करें।
1. पूर्वपरिभाषित विकल्पों में से एक पैटर्न शैली चुनें।
1. पैटर्न के [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) को सेट करें।
1. पैटर्न के [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) को सेट करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्न C# कोड दर्शाता है कि कैसे एक आयत पर पैटर्न फ़िल लागू किया जाता है:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // Rectangle प्रकार की एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // भराव प्रकार को Pattern पर सेट करें।
    shape.FillFormat.FillType = FillType.Pattern;

    // पैटर्न शैली सेट करें।
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // पैटर्न पृष्ठभूमि और अग्रभूमि रंग सेट करें।
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![पैटर्न फ़िल वाला आयत](pattern-fill.png)

## **चित्र फ़िल**

PowerPoint में Picture Fill एक स्वरूपण विकल्प है जो आपको आकृति के भीतर एक चित्र सम्मिलित करने देता है—वास्तव में चित्र को आकृति की पृष्ठभूमि के रूप में उपयोग किया जाता है।

Aspose.Slides का उपयोग करके आकृति पर चित्र फ़िल लागू करने के चरण:

1. एक instance बनाएं [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास का।
1. उसके इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) को `Picture` सेट करें।
1. चित्र फ़िल मोड को `Tile` (या कोई अन्य पसंदीदा मोड) सेट करें।
1. इच्छित चित्र से एक [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) ऑब्जेक्ट बनाएं।
1. इस चित्र को आकृति के `Picture.Image` प्रॉपर्टी के माध्यम से `PictureFillFormat` को असाइन करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

मान लें कि हमारे पास "lotus.png" नामक फ़ाइल है, जिसमें यह चित्र है:

![लोटस चित्र](lotus.png)

निम्न C# कोड दर्शाता है कि कैसे आकृति को चित्र से भरते हैं:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का एक उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // Rectangle प्रकार की एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // भराव प्रकार को Picture पर सेट करें।
    shape.FillFormat.FillType = FillType.Picture;

    // चित्र भराव मोड सेट करें।
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // एक चित्र लोड करें और उसे प्रेजेंटेशन संसाधनों में जोड़ें।
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // चित्र सेट करें।
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![चित्र फ़िल वाली आकृति](picture-fill.png)

### **टाइल चित्र को बनावट के रूप में उपयोग करें**

यदि आप एक टाइल किए हुए चित्र को बनावट के रूप में सेट करना चाहते हैं और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप निम्न गुणों का उपयोग कर सकते हैं: [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) क्लास में:

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): चित्र फ़िल मोड सेट करता है—`Tile` या `Stretch`।
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): आकृति के भीतर टाइलों की संरेक्षण निर्दिष्ट करता है।
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): टाइल को क्षैतिज, ऊर्ध्वाधर या दोनों दिशा में फ्लिप करने को नियंत्रित करता है।
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): आकृति के मूल बिंदु से टाइल का क्षैतिज ऑफ़सेट (पॉइंट में) सेट करता है।
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): आकृति के मूल बिंदु से टाइल का ऊर्ध्वाधर ऑफ़सेट (पॉइंट में) सेट करता है।
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): टाइल का क्षैतिज स्केल प्रतिशत में परिभाषित करता है।
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): टाइल का ऊर्ध्वाधर स्केल प्रतिशत में परिभाषित करता है।

निम्न कोड नमूना दिखाता है कि कैसे एक आयताकार आकृति को टाइल किए हुए चित्र फ़िल के साथ जोड़कर टाइल विकल्प कॉन्फ़िगर किए जाते हैं:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का एक उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide firstSlide = presentation.Slides[0];

    // Rectangle प्रकार की एक ऑटो शैप जोड़ें।
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // आकृति के भराव प्रकार को Picture पर सेट करें।
    shape.FillFormat.FillType = FillType.Picture;

    // छवि लोड करें और उसे प्रेजेंटेशन संसाधनों में जोड़ें।
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // छवि को आकृति को असाइन करें।
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // चित्र भराव मोड और टाइलिंग गुणों को कॉन्फ़िगर करें।
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![टाइल विकल्प](tile-options.png)

## **सॉलिड रंग फ़िल**

PowerPoint में Solid Color Fill एक स्वरूपण विकल्प है जो आकृति को एकल, समान रंग से भरता है। यह साधारण पृष्ठभूमि रंग बिना किसी ग्रेडिएंट, टेक्सचर या पैटर्न के लागू किया जाता है।

Aspose.Slides का उपयोग करके आकृति पर सॉलिड रंग फ़िल लागू करने के चरण:

1. एक instance बनाएं [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास का।
1. उसके इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) को `Solid` सेट करें।
1. अपनी पसंदीदा फ़िल रंग को आकृति को असाइन करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्न C# कोड दर्शाता है कि कैसे एक आयत में सॉलिड रंग फ़िल लागू किया जाता है:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का एक उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // Rectangle प्रकार की एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // भराव प्रकार को Solid पर सेट करें।
    shape.FillFormat.FillType = FillType.Solid;

    // भराव रंग सेट करें।
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![सॉलिड रंग फ़िल वाली आकृति](solid-color-fill.png)

## **पारदर्शिता सेट करें**

PowerPoint में, जब आप आकृति पर सॉलिड रंग, ग्रेडिएंट, चित्र या टेक्सचर फ़िल लागू करते हैं, तो आप पारदर्शिता स्तर निर्धारित करके फ़िल की अपारदर्शिता नियंत्रित कर सकते हैं। अधिक पारदर्शिता मान आकृति को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे स्थित वस्तुएँ भागिक रूप से दिखाई देती हैं।

Aspose.Slides आपको फ़िल के लिए उपयोग किए गए रंग के अल्फा मान को समायोजित करके पारदर्शिता स्तर सेट करने देता है। इसे करने का तरीका:

1. एक instance बनाएं [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास का।
1. उसके इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) को `Solid` सेट करें।
1. `Color.FromArgb(alpha, baseColor)` का उपयोग करके पारदर्शी रंग परिभाषित करें (जहाँ `alpha` घटक पारदर्शिता नियंत्रित करता है)।
1. प्रेज़ेंटेशन को सहेजें।

निम्न C# कोड दर्शाता है कि कैसे एक आयत पर पारदर्शी फ़िल रंग लागू किया जाता है:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // एक ठोस आयताकार ऑटो शैप जोड़ें।
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ठोस आकृति के ऊपर एक पारदर्शी आयताकार ऑटो शैप जोड़ें।
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![पारदर्शी आकृति](shape-transparency.png)

## **आकृतियों को घुमाएँ**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में आकृतियों को घुमाने की क्षमता देता है। यह विशेष संरेखण या डिज़ाइन आवश्यकताओं के साथ दृश्य तत्वों को स्थिति देने में उपयोगी हो सकता है।

स्लाइड पर किसी आकृति को घुमाने के चरण:

1. एक instance बनाएं [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास का।
1. उसके इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) जोड़ें।
1. आकृति की `Rotation` प्रॉपर्टी को इच्छित कोण पर सेट करें।
1. प्रेज़ेंटेशन को सहेजें।

निम्न C# कोड दर्शाता है कि कैसे आकृति को 5 डिग्री घुमाया जाता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का एक उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // Rectangle प्रकार की एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // आकृति को 5 डिग्री घुमाएँ।
    shape.Rotation = 5;

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![आकृति घूर्णन](shape-rotation.png)

## **3D बिवेल प्रभाव जोड़ें**

Aspose.Slides आपको आकारों पर 3D बिवेल प्रभाव लागू करने की अनुमति देता है, जिसे आप उनकी [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) गुणों को कॉन्फ़िगर करके कर सकते हैं।

3D बिवेल प्रभाव जोड़ने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास का instance बनाएं।
1. उसके इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) जोड़ें।
1. आकृति की [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) को कॉन्फ़िगर करके बिवेल सेटिंग्स निर्धारित करें।
1. प्रेज़ेंटेशन को सहेजें।

निम्न C# कोड दर्शाता है कि कैसे एक आकृति पर 3D बिवेल प्रभाव लागू किया जाता है:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation क्लास का एक उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // स्लाइड में एक आकृति जोड़ें।
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // आकृति की ThreeDFormat प्रॉपर्टीज़ सेट करें।
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![3D बिवेल प्रभाव](3D-bevel-effect.png)

## **3D घुमाव प्रभाव जोड़ें**

Aspose.Slides आपको आकारों पर 3D घुमाव प्रभाव लागू करने की अनुमति देता है, जिसे आप उनकी [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) गुणों को कॉन्फ़िगर करके कर सकते हैं।

3D घुमाव लागू करने के चरण:

1. एक instance बनाएं [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास का।
1. उसके इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) जोड़ें।
1. आकृति के [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) और [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) को सेट करके 3D घुमाव परिभाषित करें।
1. प्रेज़ेंटेशन को सहेजें।

निम्न C# कोड दर्शाता है कि कैसे एक आकृति पर 3D घुमाव प्रभाव लागू किया जाता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation क्लास का एक उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![3D घुमाव प्रभाव](3D-rotation-effect.png)

## **आकृतियों के लिए काली‑सफ़ेद रेंडरिंग नियंत्रित करें**

[IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) प्रॉपर्टी निर्धारित करती है कि जब प्रस्तुति को काली‑सफ़ेद मोड में देखा या प्रोसेस किया जाए तो व्यक्तिगत आकृति कैसे रेंडर होती है। यह स्वयं काली‑सफ़ेद प्रदर्शन सक्षम नहीं करता, न ही सामान्य रंग मोड में आकृति की फ़िल, लाइन या अन्य स्वरूपण को बदलता है।

[BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) enumeration से एक मान चुनें। उदाहरण के लिए, `Automatic` रेंडरिंग एप्लिकेशन को रूपांतरण चुनने देता है, `Gray` और `LightGray` ग्रे रंग उपयोग करते हैं, `BlackWhite` केवल काले‑सफ़ेद का उपयोग करता है, `Black` और `White` एकल रंग लागू करते हैं, `Color` सामान्य रंग बनाए रखता है, और `Hidden` काली‑सफ़ेद मोड में आकृति को बाहर रखता है। `NotDefined` का अर्थ है कि कोई आकृति‑स्तरीय मोड असाइन नहीं किया गया है।

निम्न C# कोड एक रंगीन आकृति बनाता है और काली‑सफ़ेद प्रदर्शन मोड में उसे ग्रे दिखाता है:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// रंग मोड में नारंगी भराव रखें, लेकिन काली-सफ़ेद मोड में आकृति को ग्रे रंग में रेंडर करें।
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

सामान्य रंग मोड में, आयत अपना नारंगी फ़िल बरकरार रखता है। काली‑सफ़ेद डिस्प्ले वर्कफ़्लो में, उसका मोड `Gray` होने के कारण ग्रे रंग में रेंडर होता है। यह आपको पूर्ण‑रंग स्लाइड को संरक्षित रखने और प्रिंटिंग, प्रीव्यू या अन्य वर्कफ़्लो में अलग दिखाने की अनुमति देता है जो प्रस्तुति की काली‑सफ़ेद डिस्प्ले सेटिंग्स को मानते हैं।

## **स्वरूपण रीसेट करें**

निम्न C# कोड दर्शाता है कि कैसे स्लाइड का स्वरूपण रीसेट किया जाता है और सभी प्लेसहोल्डर्स वाली आकृतियों की स्थिति, आकार और स्वरूपण को [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) पर उनकी डिफ़ॉल्ट सेटिंग्स पर लौटाया जाता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // लेआउट पर प्लेसहोल्डर वाले प्रत्येक आकार को स्लाइड पर रीसेट करें।
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**क्या आकृति स्वरूपण अंतिम प्रस्तुति फ़ाइल आकार को प्रभावित करता है?**

बहुत कम। एम्बेडेड चित्र और मीडिया फ़ाइलें अधिकांश स्थान लेती हैं, जबकि रंग, प्रभाव और ग्रेडिएंट जैसी आकृति पैरामीटर मेटाडेटा के रूप में संग्रहीत होते हैं और अतिरिक्त आकार लगभग नहीं जोड़ते।

**मैं कैसे उन आकृतियों का पता लगा सकता हूँ जो समान स्वरूपण साझा करती हैं ताकि उन्हें समूहित किया जा सके?**

प्रत्येक आकृति की प्रमुख स्वरूपण गुणों—फ़िल, लाइन और इफ़ेक्ट सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनके शैली को समान मानें और उन आकृतियों को तार्किक रूप से समूहित करें; यह बाद में शैली प्रबंधन को सरल बनाता है।

**क्या मैं कस्टम आकृति शैलियों का एक सेट अलग फ़ाइल में सहेज कर अन्य प्रस्तुतियों में पुनः उपयोग कर सकता हूँ?**

हां। इच्छित शैलियों वाले नमूना आकृतियों को एक टेम्पलेट स्लाइड डेक या .POTX टेम्पलेट फ़ाइल में सहेजें। नई प्रस्तुति बनाते समय टेम्पलेट खोलें, आवश्यक शैली वाली आकृतियों को क्लोन करें, और जहाँ‑जहाँ आवश्यक हो उनका स्वरूपण पुनः लागू करें।