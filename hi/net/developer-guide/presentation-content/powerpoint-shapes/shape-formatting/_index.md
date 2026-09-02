---
title: PowerPoint आकारों को .NET में स्वरूपित करें
linktitle: आकार स्वरूपण
type: docs
weight: 20
url: /hi/net/shape-formatting/
keywords:
  - आकार स्वरूपित करें
  - रेखा स्वरूपित करें
  - स्केच प्रभाव
  - स्केच आकार रेखा
  - जॉइन शैली स्वरूपित करें
  - ग्रेडिएंट फ़िल
  - पैटर्न फ़िल
  - चित्र फ़िल
  - टेक्सचर फ़िल
  - सॉलिड कलर फ़िल
  - आकार पारदर्शिता
  - काला-सफ़ेद आकार रेंडरिंग
  - ग्रेस्केल आकार रेंडरिंग
  - आकार घुमाएँ
  - 3D बिवेल प्रभाव
  - 3D घुमाव प्रभाव
  - फ़ॉर्मेट रीसेट करें
  - PowerPoint
  - प्रस्तुति
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides का उपयोग करके C# में PowerPoint आकारों को कैसे स्वरूपित करें सीखें—PPT और PPTX फ़ाइलों के लिए भराव, रेखा और प्रभाव शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड्स पर आकार जोड़ सकते हैं। चूंकि आकार लाइनों से बने होते हैं, आप उनकी रूपरेखा को संशोधित करके या प्रभाव लागू करके उन्हें स्वरूपित कर सकते हैं। अतिरिक्त रूप से, आप आकार के अंदरूनी हिस्से को कैसे भरा जाए, इसे नियंत्रित करने वाली सेटिंग्स निर्दिष्ट करके भी स्वरूपित कर सकते हैं।

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET इंटरफ़ेस और प्रॉपर्टीज़ प्रदान करता है जो आपको PowerPoint में उपलब्ध समान विकल्पों का उपयोग करके आकारों को स्वरूपित करने की अनुमति देता है।

## **रेखा फ़ॉर्मेट**

Aspose.Slides का उपयोग करके आप किसी आकार के लिए कस्टम लाइन स्टाइल निर्दिष्ट कर सकते हैं। नीचे चरणों में प्रक्रिया बताई गई है:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [line style](https://reference.aspose.com/slides/hi/net/aspose.slides/linestyle/) सेट करें।
1. लाइन की चौड़ाई सेट करें।
1. लाइन का [dash style](https://reference.aspose.com/slides/hi/net/aspose.slides/linedashstyle/) सेट करें।
1. आकार के लिए लाइन का रंग सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित C# कोड दिखाता है कि एक आयत `AutoShape` को कैसे फ़ॉर्मेट किया जाए:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // आयताकार आकार के लिए भराव रंग सेट करें।
    shape.FillFormat.FillType = FillType.NoFill;

    // आयत की रेखाओं पर फ़ॉर्मेटिंग लागू करें।
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // आयत की रेखा का रंग सेट करें।
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![प्रस्तुति में स्वरूपित रेखाएँ](formatted-lines.png)

## **आकार रेखाओं पर स्केच प्रभाव लागू करें**

स्केच प्रभाव आकार की रेखा को हाथ से ड्रॉ किया हुआ बनाता है। रेखा सेटिंग्स तक पहुँचने के लिए [IShape.LineFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/lineformat/) का उपयोग करें, स्केच सेटिंग्स तक पहुँचने के लिए [ILineFormat.SketchFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ilineformat/sketchformat/) और स्केच प्रकार चुनने के लिए [ISketchFormat.SketchType](https://reference.aspose.com/slides/hi/net/aspose.slides/isketchformat/sketchtype/) का उपयोग करें, जो कि [LineSketchType](https://reference.aspose.com/slides/hi/net/aspose.slides/linesketchtype/) एनेमरेशन से मान लेता है।

निम्नलिखित C# कोड दिखाता है कि कैसे [LineSketchType.Curved](https://reference.aspose.com/slides/hi/net/aspose.slides/linesketchtype/) प्रभाव लागू किया जाए, स्पष्ट रूप से असाइन किया गया मान पढ़ा जाए, और प्रभाव को [LineSketchType.None](https://reference.aspose.com/slides/hi/net/aspose.slides/linesketchtype/) से हटाया जाए:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// आकार की रेखा फ़ॉर्मेट और उसके स्केच फ़ॉर्मेट तक पहुँचें।
var sketchFormat = shape.LineFormat.SketchFormat;

// स्केच प्रभाव लागू करें।
sketchFormat.SketchType = LineSketchType.Curved;

// आकार को सीधे असाइन किया गया स्केच प्रभाव पढ़ें।
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// स्केच प्रभाव हटाएँ।
sketchFormat.SketchType = LineSketchType.None;
```

`ISketchFormat.SketchType` द्वारा वापस किया गया मान सीधे आकार पर असाइन की गई सेटिंग को दर्शाता है। यदि लाइन फ़ॉर्मेट थीम, मास्टर स्लाइड या लेआउट स्लाइड से विरासत में प्राप्त हो सकता है, तो [ILineFormat.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/ilineformat/geteffective/) का उपयोग करें, [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ilineformateffectivedata/sketchformat/) तक पहुंचें, और [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/hi/net/aspose.slides/isketchformateffectivedata/sketchtype/) पढ़ें। प्रभावी मान वह फ़ॉर्मेटिंग दर्शाता है जो विरासत समाधान के बाद वास्तव में लागू होती है:

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

## **जॉइन स्टाइल फ़ॉर्मेट करें**

तीन जॉइन प्रकार विकल्प हैं:

* Round
* Miter
* Bevel

डिफ़ॉल्ट रूप से, जब PowerPoint दो रेखाओं को कोण पर जोड़ता है (जैसे आकार के कोने पर), वह **Round** सेटिंग उपयोग करता है। हालांकि, यदि आप तीखे कोण वाले आकार को बना रहे हैं, तो आप **Miter** विकल्प को प्राथमिकता दे सकते हैं।

![प्रेजेंटेशन में जॉइन स्टाइल](join-style-powerpoint.png)

निम्नलिखित C# कोड दिखाता है कि कैसे तीन आयतें (उपर्युक्त छवि में दिखाए अनुसार) Miter, Bevel और Round जॉइन टाइप सेटिंग्स का उपयोग करके बनाई गईं:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // Rectangle प्रकार के तीन ऑटो शैप जोड़ें।
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // प्रत्येक आयताकार आकार के लिए भराव रंग सेट करें।
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

    // प्रत्येक आयत की रेखा का रंग सेट करें।
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

    // प्रत्येक आयत में टेक्स्ट जोड़ें।
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **ग्रेडिएंट फ़िल**

PowerPoint में, Gradient Fill एक फ़ॉर्मेटिंग विकल्प है जो आपको एक आकार पर निरंतर रंग मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिए, आप दो या अधिक रंगों को इस तरह लागू कर सकते हैं कि एक धीरे-धीरे दूसरे में मिल जाता है।

Aspose.Slides का उपयोग करके आकार पर ग्रेडिएंट फ़िल लागू करने के चरण:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) को `Gradient` सेट करें।
1. ग्रेडिएंट स्टॉप कलेक्शन के `Add` मेथड्स का उपयोग करके अपनी दो पसंदीदा रंगों को परिभाषित स्थितियों के साथ जोड़ें, जो कि [IGradientFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/igradientformat/) इंटरफ़ेस द्वारा प्रकट होते हैं।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित C# कोड दिखाता है कि एक दीर्घवृत्त पर ग्रेडिएंट फ़िल प्रभाव कैसे लागू किया जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // Ellipse प्रकार का एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // दीर्घवृत्त पर ग्रेडिएंट फ़ॉर्मेटिंग लागू करें।
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

![ग्रेडिएंट फ़िल के साथ दीर्घवृत्त](gradient-fill.png)

## **पैटर्न फ़िल**

PowerPoint में, Pattern Fill एक फ़ॉर्मेटिंग विकल्प है जो आपको दो‑रंगीय डिज़ाइन—जैसे बिंदु, धारियाँ, क्रॉसहैच या चेक्स—आकार पर लागू करने देता है। आप पैटर्न के फ़ोरग्राउंड और बैकग्राउंड के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वनिर्धारित पैटर्न शैलियाँ प्रदान करता है जिन्हें आप अपनी प्रस्तुतियों को बेहतर दृश्य रूप देने के लिए आकारों पर लागू कर सकते हैं। पूर्वनिर्धारित पैटर्न चुनने के बाद भी आप उपयोग किए जाने वाले सटीक रंग निर्दिष्ट कर सकते हैं।

Aspose.Slides का उपयोग करके आकार पर पैटर्न फ़िल लागू करने के चरण:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) को `Pattern` सेट करें।
1. पूर्वनिर्धारित विकल्पों में से एक पैटर्न स्टाइल चुनें।
1. पैटर्न की [Background Color](https://reference.aspose.com/slides/hi/net/aspose.slides/ipatternformat/backcolor/) सेट करें।
1. पैटर्न की [Foreground Color](https://reference.aspose.com/slides/hi/net/aspose.slides/ipatternformat/forecolor/) सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित C# कोड दिखाता है कि एक आयत पर पैटर्न फ़िल कैसे लागू किया जाए:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // भराव प्रकार को Pattern सेट करें।
    shape.FillFormat.FillType = FillType.Pattern;

    // पैटर्न शैली सेट करें।
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // पैटर्न की पृष्ठभूमि और अग्रभूमि रंग सेट करें।
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![पैटर्न फ़िल के साथ आयत](pattern-fill.png)

## **पिक्चर फ़िल**

PowerPoint में, Picture Fill एक फ़ॉर्मेटिंग विकल्प है जो आपको आकार के अंदर एक चित्र सम्मिलित करने देता है—प्रभावी रूप से चित्र को आकार की पृष्ठभूमि के रूप में उपयोग करता है।

Aspose.Slides का उपयोग करके आकार पर पिक्चर फ़िल लागू करने के चरण:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) को `Picture` सेट करें।
1. पिक्चर फ़िल मोड को `Tile` (या कोई अन्य पसंदीदा मोड) सेट करें।
1. इच्छित चित्र से एक [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) ऑब्जेक्ट बनाएँ।
1. इस चित्र को आकार के `PictureFillFormat` की `Picture.Image` प्रॉपर्टी में असाइन करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

मान लीजिए हमारे पास "lotus.png" नामक फ़ाइल है जिसमें निम्नलिखित चित्र है:

![लोटस चित्र](lotus.png)

निम्नलिखित C# कोड दिखाता है कि आकार को चित्र से कैसे भरा जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // भराव प्रकार को Picture सेट करें।
    shape.FillFormat.FillType = FillType.Picture;

    // चित्र भराव मोड सेट करें।
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // एक छवि लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें।
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

![पिक्चर फ़िल के साथ आकार](picture-fill.png)

### **टाइल चित्र को टेक्सचर के रूप में उपयोग करें**

यदि आप टाइल किए हुए चित्र को टेक्सचर के रूप में सेट करना चाहते हैं और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप [IPictureFillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillformat/) क्लास की निम्नलिखित प्रॉपर्टीज़ का उपयोग कर सकते हैं:

- [PictureFillMode](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/picturefillmode/): चित्र फ़िल मोड सेट करता है—`Tile` या `Stretch`।
- [TileAlignment](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/tilealignment/): आकार के भीतर टाइलों की संरेखण निर्दिष्ट करता है।
- [TileFlip](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/tileflip/): टाइल को क्षैतिज, लंबवत या दोनों दिशा में फ़्लिप करने को नियंत्रित करता है।
- [TileOffsetX](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/tileoffsetx/): आकार की मूल बिंदु से टाइल का क्षैतिज ऑफ़सेट (पॉइंट्स में) सेट करता है।
- [TileOffsetY](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/tileoffsety/): आकार की मूल बिंदु से टाइल का लंबवत ऑफ़सेट (पॉइंट्स में) सेट करता है।
- [TileScaleX](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/tilescalex/): टाइल की क्षैतिज स्केल को प्रतिशत में परिभाषित करता है।
- [TileScaleY](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/tilescaley/): टाइल की लंबवत स्केल को प्रतिशत में परिभाषित करता है।

निम्नलिखित कोड नमूना दिखाता है कि टाइल चित्र फ़िल के साथ एक आयत आकार कैसे जोड़ा जाए और टाइल विकल्प कैसे कॉन्फ़िगर किए जाएँ:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide firstSlide = presentation.Slides[0];

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // आकार का भराव प्रकार Picture सेट करें।
    shape.FillFormat.FillType = FillType.Picture;

    // छवि लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें।
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // छवि को आकार को असाइन करें।
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

## **सॉलिड कलर फ़िल**

PowerPoint में, Solid Color Fill एक फ़ॉर्मेटिंग विकल्प है जो आकार को एकसमान रंग से भरता है। यह साधारण पृष्ठभूमि रंग बिना किसी ग्रेडिएंट, टेक्सचर या पैटर्न के लागू किया जाता है।

Aspose.Slides का उपयोग करके आकार पर सॉलिड कलर फ़िल लागू करने के चरण:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) को `Solid` सेट करें।
1. इच्छित फ़िल रंग को आकार को असाइन करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित C# कोड दिखाता है कि PowerPoint स्लाइड में एक आयत पर सॉलिड कलर फ़िल कैसे लागू किया जाए:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // भराव प्रकार को Solid सेट करें।
    shape.FillFormat.FillType = FillType.Solid;

    // भराव रंग सेट करें।
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![सॉलिड कलर फ़िल के साथ आकार](solid-color-fill.png)

## **पारदर्शिता सेट करें**

PowerPoint में, जब आप आकार पर सॉलिड कलर, ग्रेडिएंट, पिक्चर या टेक्सचर फ़िल लागू करते हैं, तो आप फ़िल की अपारदर्शिता को नियंत्रित करने के लिए ट्रांसपरेंसी स्तर भी सेट कर सकते हैं। उच्च ट्रांसपरेंसी मान आकार को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे के वस्तुएँ आंशिक रूप से दिखती हैं।

Aspose.Slides आपको फ़िल के लिए उपयोग किए गए रंग के अल्फा मान को समायोजित करके ट्रांसपरेंसी स्तर सेट करने देता है। यह करने के चरण:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
1. [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) को `Solid` सेट करें।
1. `Color.FromArgb(alpha, baseColor)` का उपयोग करके ट्रांसपरेंसी वाला रंग परिभाषित करें (`alpha` घटक ट्रांसपरेंसी को नियंत्रित करता है)।
1. प्रस्तुति को सहेजें।

निम्नलिखित C# कोड दिखाता है कि एक आयत पर पारदर्शी फ़िल रंग कैसे लागू किया जाए:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // एक ठोस आयताकार ऑटो शैप जोड़ें।
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ठोस आकार के ऊपर एक पारदर्शी आयताकार ऑटो शैप जोड़ें।
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![पारदर्शी आकार](shape-transparency.png)

## **आकार घुमाएँ**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में आकार घुमाने की सुविधा देता है। यह विशिष्ट संरेखण या डिज़ाइन आवश्यकता वाले दृश्य तत्वों को स्थित करने में उपयोगी हो सकता है।

स्लाइड पर आकार घुमाने के चरण:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
1. आकार की `Rotation` प्रॉपर्टी को वांछित कोण पर सेट करें।
1. प्रस्तुति को सहेजें।

निम्नलिखित C# कोड दिखाता है कि आकार को 5 डिग्री से कैसे घुमाया जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // आकार को 5 डिग्री से घुमाएँ।
    shape.Rotation = 5;

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![आकार घुमाव](shape-rotation.png)

## **3D बिवेल प्रभाव जोड़ें**

Aspose.Slides आपको आकारों पर 3D बिवेल प्रभाव लागू करने की अनुमति देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करते हैं।

3D बिवेल प्रभाव जोड़ने के चरण:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
1. आकार के [ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/threedformat/) को कॉन्फ़िगर करके बिवेल सेटिंग्स परिभाषित करें।
1. प्रस्तुति को सहेजें।

निम्नलिखित C# कोड दिखाता है कि आकार पर 3D बिवेल प्रभाव कैसे लागू किया जाए:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation क्लास का एक इंस्टेंस बनाएं।
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // स्लाइड में एक आकार जोड़ें।
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // आकार की ThreeDFormat प्रॉपर्टीज़ सेट करें।
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![3D बिवेल प्रभाव](3D-bevel-effect.png)

## **3D घुमाव प्रभाव जोड़ें**

Aspose.Slides आपको आकारों पर 3D घुमाव प्रभाव लागू करने की अनुमति देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करते हैं।

3D घुमाव लागू करने के चरण:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
1. आकार के [CameraType](https://reference.aspose.com/slides/hi/net/aspose.slides/icamera/cameratype/) और [LightType](https://reference.aspose.com/slides/hi/net/aspose.slides/ilightrig/lighttype/) को सेट करके 3D घुमाव परिभाषित करें।
1. प्रस्तुति को सहेजें।

निम्नलिखित C# कोड दिखाता है कि आकार पर 3D घुमाव प्रभाव कैसे लागू किया जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation क्लास का एक इंस्टेंस बनाएं।
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![3D घुमाव प्रभाव](3D-rotation-effect.png)

## **आकारों के लिए ब्लैक‑एंड‑व्हाइट रेंडरिंग नियंत्रित करें**

[IShape.BlackWhiteMode](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/blackwhitemode/) प्रॉपर्टी यह निर्धारित करती है कि जब प्रस्तुति को ब्लैक‑एंड‑व्हाइट मोड में देखा या प्रोसेस किया जाता है, तो व्यक्तिगत आकार कैसे रेंडर किया जाएगा। यह स्वयं ब्लैक‑एंड‑व्हाइट डिस्प्ले सक्षम नहीं करता, न ही सामान्य रंग मोड में आकार के फ़िल, लाइन या अन्य फ़ॉर्मेटिंग को बदलता है।

इच्छित व्यवहार चुनने के लिए आप [BlackWhiteMode](https://reference.aspose.com/slides/hi/net/aspose.slides/blackwhitemode/) एनेमरेशन से कोई मान उपयोग कर सकते हैं। उदाहरण के लिए, `Automatic` रेंडरिंग एप्लिकेशन को रूपांतरण चुनने देता है, `Gray` और `LightGray` ग्रे रंग उपयोग करते हैं, `BlackWhite` केवल काली‑सफ़ेद उपयोग करता है, `Black` और `White` एकल रंग को बाध्य करते हैं, `Color` सामान्य रंग बनाए रखता है, `Hidden` ब्लैक‑एंड‑व्हाइट मोड में आकार को छोड़ देता है, और `NotDefined` का अर्थ है कि कोई आकार‑स्तर मोड असाइन नहीं किया गया है।

निम्नलिखित C# कोड एक रंगीन आकार बनाता है और उसे ब्लैक‑एंड‑व्हाइट डिस्प्ले मोड में ग्रे दिखाता है:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// रंग मोड में नारंगी भराव रखें, लेकिन ब्लैक-एंड-व्हाइट मोड में आकार को ग्रे रंग में रेंडर करें।
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

सामान्य रंग मोड में, आयत अपना नारंगी फ़िल रखता है। ब्लैक‑एंड‑व्हाइट डिस्प्ले वर्कफ़्लो में, उसका मोड `Gray` होने के कारण वह ग्रे रंग उपयोग करता है। यह आपको पूरी‑रंग वाली स्लाइड को बनाये रखने और प्रिंटिंग, प्रीव्यू या अन्य वर्कफ़्लो में अलग दिखावट निर्धारित करने की सुविधा देता है।

## **फ़ॉर्मेट रीसेट करें**

निम्नलिखित C# कोड दिखाता है कि कैसे एक स्लाइड की फ़ॉर्मेटिंग रीसेट की जाए और [LayoutSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutslide/) पर सभी प्लेसहोल्डर वाले आकारों की स्थिति, आकार और फ़ॉर्मेटिंग को उनके डिफ़ॉल्ट सेटिंग्स पर लाया जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // लेआउट में प्लेसहोल्डर वाले स्लाइड पर प्रत्येक आकार को रीसेट करें।
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**क्या आकार फ़ॉर्मेटिंग अंतिम प्रस्तुति फ़ाइल के आकार को प्रभावित करती है?**

केवल न्यूनतम रूप से। एम्बेडेड चित्र और मीडिया फ़ाइलें अधिकांश स्थान लेती हैं, जबकि रंग, प्रभाव और ग्रेडिएंट जैसी आकार पैरामीटर मेटाडेटा के रूप में संग्रहीत होते हैं और लगभग कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे पता करूँ कि कौन‑से आकार एक ही फ़ॉर्मेटिंग साझा करते हैं ताकि उन्हें समूहित किया जा सके?**

प्रत्येक आकार की मुख्य फ़ॉर्मेटिंग प्रॉपर्टीज़—फ़िल, लाइन और प्रभाव सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान समान हैं, तो उनके स्टाइल को समान मानकर उन आकारों को तार्किक रूप से समूहित करें, जिससे बाद में स्टाइल प्रबंधन सरल हो जाता है।

**क्या मैं कस्टम आकार शैली का सेट अलग फ़ाइल में सहेज कर अन्य प्रस्तुतियों में पुनः उपयोग कर सकता हूँ?**

हां। वांछित शैलियों वाले नमूना आकारों को टेम्पलेट स्लाइड डेक या .POTX टेम्पलेट फ़ाइल में संग्रहीत करें। नई प्रस्तुति बनाते समय टेम्पलेट खोलें, आवश्यक शैली वाले आकारों को क्लोन करें, और जहाँ आवश्यक हो फ़ॉर्मेटिंग को पुनः लागू करें।