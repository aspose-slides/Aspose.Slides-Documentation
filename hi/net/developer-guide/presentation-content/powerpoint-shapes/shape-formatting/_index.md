---
title: PowerPoint आकारों को .NET में फ़ॉर्मेट करें
linktitle: आकार फ़ॉर्मेटिंग
type: docs
weight: 20
url: /hi/net/shape-formatting/
keywords:
- आकार फ़ॉर्मेट
- लाइन फ़ॉर्मेट
- स्केच प्रभाव
- स्केच आकार लाइन
- जॉइन शैली फ़ॉर्मेट
- ग्रेडिएंट फ़िल
- पैटर्न फ़िल
- पिक्चर फ़िल
- टेक्सचर फ़िल
- सॉलिड रंग फ़िल
- आकार पारदर्शिता
- आकार घुमाएँ
- 3D बीवल प्रभाव
- 3D घुमाव प्रभाव
- फ़ॉर्मेट रीसेट करें
- पावरपॉइंट
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके C# में PowerPoint आकारों को फ़ॉर्मेट करना सीखें—PPT और PPTX फाइलों के लिए फ़िल, लाइन और इफ़ेक्ट शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड्स में आकार (शेप) जोड़ सकते हैं। चूंकि आकार रेखाओं से बनते हैं, आप उनके रूपरेखा को संशोधित करके या प्रभाव लागू करके उनका स्वरूप बदल सकते हैं। इसके अतिरिक्त, आप आकारों को उनके अंदरूनी भाग को भरने वाले सेटिंग्स निर्दिष्ट करके स्वरूपित कर सकते हैं।

![फ़ॉर्मेट-शेप-पॉवरपॉइंट](format-shape-powerpoint.png)

Aspose.Slides for .NET ऐसे इंटरफ़ेसेस और प्रॉपर्टीज़ प्रदान करता है जो आपको PowerPoint में उपलब्ध समान विकल्पों का उपयोग करके आकारों को स्वरूपित करने की अनुमति देती हैं।

## **लाइन फ़ॉर्मेट करें**

Aspose.Slides का उपयोग करके, आप किसी आकार के लिए कस्टम लाइन शैली निर्दिष्ट कर सकते हैं। नीचे दिए गए चरण प्रक्रिया का विवरण देते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [लाइन शैली](https://reference.aspose.com/slides/hi/net/aspose.slides/linestyle/) सेट करें।
1. लाइन की चौड़ाई सेट करें।
1. लाइन का [डैश स्टाइल](https://reference.aspose.com/slides/hi/net/aspose.slides/linedashstyle/) सेट करें।
1. आकार के लिए लाइन का रंग सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```c#
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // आयत आकार के लिए फ़िल रंग सेट करें।
    shape.FillFormat.FillType = FillType.NoFill;

    // आयत की लाइनों पर फ़ॉर्मेटिंग लागू करें।
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // आयत की लाइन का रंग सेट करें।
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![प्रस्तुति में स्वरूपित लाइन्स](formatted-lines.png)

## **आकार लाइनों पर स्केच प्रभाव लागू करें**

स्केच प्रभाव आकार की लाइन को हाथ से लिखी हुई जैसा बनाता है। [IShape.LineFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/lineformat/) का उपयोग करके लाइन सेटिंग्स तक पहुंचें, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ilineformat/sketchformat/) का उपयोग करके स्केच सेटिंग्स तक पहुंचें, और [ISketchFormat.SketchType](https://reference.aspose.com/slides/hi/net/aspose.slides/isketchformat/sketchtype/) का उपयोग करके [LineSketchType](https://reference.aspose.com/slides/hi/net/aspose.slides/linesketchtype/) एनीमरेशन से मान चुनें।

निम्नलिखित C# कोड दिखाता है कि कैसे [LineSketchType.Curved](https://reference.aspose.com/slides/hi/net/aspose.slides/linesketchtype/) प्रभाव लागू करें, स्पष्ट रूप से असाइन किया गया मान पढ़ें, और प्रभाव को [LineSketchType.None](https://reference.aspose.com/slides/hi/net/aspose.slides/linesketchtype/) के साथ हटाएं:

```csharp
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

`ISketchFormat.SketchType` द्वारा लौटाया गया मान आकार को सीधे असाइन किए गए सेटिंग का प्रतिनिधित्व करता है। यदि लाइन फ़ॉर्मेटिंग थीम, मास्टर स्लाइड, या लेआउट स्लाइड से विरासत हो सकती है, तो [ILineFormat.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/ilineformat/geteffective/) का उपयोग करें, [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ilineformateffectivedata/sketchformat/) तक पहुंचें, और [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/hi/net/aspose.slides/isketchformateffectivedata/sketchtype/) पढ़ें। प्रभावी मान विरासत समाधान के बाद वास्तविक लागू फ़ॉर्मेटिंग को दर्शाता है:

```csharp
using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **जॉइन शैली फ़ॉर्मेट करें**

तीन जॉइन प्रकार विकल्प यहां हैं:

* गोल
* मिटर
* बिवेल

डिफ़ॉल्ट रूप से, जब PowerPoint दो लाइनों को कोण पर जोड़ता है (जैसे आकार के कोने पर), यह **गोल** सेटिंग उपयोग करता है। हालांकि, यदि आप तीखे कोणों वाला आकार बना रहे हैं, तो आप **मिटर** विकल्प पसंद कर सकते हैं।

![प्रस्तुति में जॉइन शैली](join-style-powerpoint.png)

निम्नलिखित C# कोड दर्शाता है कि ऊपर की छवि में दिखाए गए तीन आयतों को मिटर, बिवेल, और गोल जॉइन प्रकार सेटिंग्स का उपयोग करके कैसे बनाया गया:

```c#
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // Rectangle प्रकार के तीन ऑटो शैप जोड़ें।
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // प्रत्येक आयत आकार के लिए फ़िल रंग सेट करें।
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // लाइन की चौड़ाई सेट करें।
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // प्रत्येक आयत की लाइन का रंग सेट करें।
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

PowerPoint में, ग्रेडिएंट फ़िल एक फ़ॉर्मेटिंग विकल्प है जो आपको आकार पर लगातार रंगों का मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिए, आप दो या अधिक रंग इस तरह लागू कर सकते हैं कि एक धीरे-धीरे दूसरे में मिल जाए।

यहां Aspose.Slides का उपयोग करके आकार पर ग्रेडिएंट फ़िल लागू करने का तरीका दिया गया है:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) को `Gradient` सेट करें।
1. ग्रेडिएंट स्टॉप कलेक्शन के `Add` मेथड्स का उपयोग करके दो पसंदीदा रंगों को परिभाषित स्थितियों के साथ जोड़ें, जिसे [IGradientFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/igradientformat/) इंटरफ़ेस द्वारा उजागर किया गया है।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```c#
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // Ellipse प्रकार का एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // एलिप्स पर ग्रेडिएंट फ़ॉर्मेटिंग लागू करें।
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

PowerPoint में, पैटर्न फ़िल एक फ़ॉर्मेटिंग विकल्प है जो आपको आकार पर दो‑रंग की डिज़ाइन—जैसे डॉट, स्ट्राइप, क्रॉसहैच या चेक—लगाने की सुविधा देता है। आप पैटर्न की अग्रभूमि और पृष्ठभूमि के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वनिर्धारित पैटर्न शैलियाँ प्रदान करता है जिन्हें आप अपनी प्रस्तुतियों की दृश्य अपील बढ़ाने के लिए आकारों पर लागू कर सकते हैं। पूर्वनिर्धारित पैटर्न चुनने के बाद भी, आप अभी भी वही सटीक रंग निर्धारित कर सकते हैं जो इसे उपयोग करना चाहिए।

यहां Aspose.Slides का उपयोग करके आकार पर पैटर्न फ़िल लागू करने का तरीका दिया गया है:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) को `Pattern` सेट करें।
1. पूर्वनिर्धारित विकल्पों में से एक पैटर्न शैली चुनें।
1. पैटर्न का [Background Color](https://reference.aspose.com/slides/hi/net/aspose.slides/ipatternformat/backcolor/) सेट करें।
1. पैटर्न का [Foreground Color](https://reference.aspose.com/slides/hi/net/aspose.slides/ipatternformat/forecolor/) सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```c#
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // फ़िल प्रकार को Pattern पर सेट करें।
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

PowerPoint में, पिक्चर फ़िल एक फ़ॉर्मेटिंग विकल्प है जो आपको आकार के भीतर एक छवि डालने की अनुमति देता है—जिससे छवि प्रभावी रूप से आकार की पृष्ठभूमि बन जाती है।

यहां Aspose.Slides का उपयोग करके आकार पर पिक्चर फ़िल लागू करने का तरीका दिया गया है:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) को `Picture` सेट करें।
1. पिक्चर फ़िल मोड को `Tile` (या कोई अन्य इच्छित मोड) सेट करें।
1. [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) ऑब्जेक्ट को उस छवि से बनाएं जिसे आप उपयोग करना चाहते हैं।
1. इस छवि को आकार के `PictureFillFormat` की `Picture.Image` प्रॉपर्टी में असाइन करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

मान लेते हैं कि हमारे पास एक "lotus.png" फ़ाइल है जिसमें निम्नलिखित चित्र है:

![लोटस चित्र](lotus.png)

```c#
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें.
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें.
    ISlide slide = presentation.Slides[0];

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // फ़िल प्रकार को Picture पर सेट करें.
    shape.FillFormat.FillType = FillType.Picture;

    // पिक्चर फ़िल मोड सेट करें.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // एक छवि लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // पिक्चर सेट करें.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // PPTX फ़ाइल को डिस्क पर सहेजें.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![पिक्चर फ़िल के साथ आकार](picture-fill.png)

### **टाइल पिक्चर को टेक्सचर के रूप में**

यदि आप टाइल्ड पिक्चर को टेक्सचर के रूप में सेट करना चाहते हैं और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप [IPictureFillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillformat/) क्लास की निम्नलिखित प्रॉपर्टीज़ का उपयोग कर सकते हैं:

- [PictureFillMode](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/picturefillmode/): सेट करता है पिक्चर फ़िल मोड—`Tile` या `Stretch`।
- [TileAlignment](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/tilealignment/): आकार के भीतर टाइलों की संरेखण निर्धारित करता है।
- [TileFlip](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/tileflip/): नियंत्रित करता है कि टाइल क्षैतिज, लंबवत या दोनों दिशा में फ़्लिप हो।
- [TileOffsetX](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/tileoffsetx/): टाइल का क्षैतिज ऑफ़सेट (पॉइंट में) आकार की मूल बिंदु से सेट करता है।
- [TileOffsetY](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/tileoffsety/): टाइल का लंबवत ऑफ़सेट (पॉइंट में) आकार की मूल बिंदु से सेट करता है।
- [TileScaleX](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/tilescalex/): टाइल के क्षैतिज स्केल को प्रतिशत के रूप में परिभाषित करता है।
- [TileScaleY](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/tilescaley/): टाइल के लंबवत स्केल को प्रतिशत के रूप में परिभाषित करता है।

```c#
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें.
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें.
    ISlide firstSlide = presentation.Slides[0];

    // एक आयत ऑटो शैप जोड़ें.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // आकार के फ़िल प्रकार को Picture पर सेट करें.
    shape.FillFormat.FillType = FillType.Picture;

    // छवि लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // छवि को आकार को असाइन करें.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // पिक्चर फ़िल मोड और टाइलिंग गुणों को कॉन्फ़िगर करें.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // PPTX फ़ाइल को डिस्क पर सहेजें.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![टाइल विकल्प](tile-options.png)

## **सॉलिड कलर फ़िल**

PowerPoint में, सॉलिड कलर फ़िल एक फ़ॉर्मेटिंग विकल्प है जो आकार को एक ही, समान रंग से भरता है। यह सादा पृष्ठभूमि रंग कोई ग्रेडिएंट, टेक्सचर या पैटर्न के बिना लागू किया जाता है।

आकार पर सॉलिड कलर फ़िल लागू करने के लिए निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) को `Solid` सेट करें।
1. आवश्यक फ़िल रंग को आकार को असाइन करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```c#
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें.
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें.
    ISlide slide = presentation.Slides[0];

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // फ़िल प्रकार को Solid पर सेट करें.
    shape.FillFormat.FillType = FillType.Solid;

    // फ़िल रंग सेट करें.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // PPTX फ़ाइल को डिस्क पर सहेजें.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![सॉलिड कलर फ़िल के साथ आकार](solid-color-fill.png)

## **पारदर्शिता सेट करें**

PowerPoint में, जब आप आकारों पर सॉलिड कलर, ग्रेडिएंट, पिक्चर या टेक्सचर फ़िल लागू करते हैं, तो आप पारदर्शिता स्तर भी सेट कर सकते हैं जो फ़िल की अपारदर्शिता को नियंत्रित करता है। उच्च पारदर्शिता मान आकार को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे के ऑब्जेक्ट्स आंशिक रूप से दिखाई देते हैं।

Aspose.Slides आपको फ़िल के लिए उपयोग किए गए रंग में अल्फा मान को समायोजित करके पारदर्शिता स्तर सेट करने की सुविधा देता है। इसे करने का तरीका इस प्रकार है:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) को `Solid` सेट करें।
1. `Color.FromArgb(alpha, baseColor)` का उपयोग करके पारदर्शी रंग परिभाषित करें (`alpha` घटक पारदर्शिता को नियंत्रित करता है)।
1. प्रस्तुति सहेजें।

```c#
const int alpha = 128;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें.
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें.
    ISlide slide = presentation.Slides[0];

    // एक ठोस आयत ऑटो शैप जोड़ें.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ठोस आकार के ऊपर एक पारदर्शी आयत ऑटो शैप जोड़ें.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // PPTX फ़ाइल को डिस्क पर सहेजें.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![पारदर्शी आकार](shape-transparency.png)

## **आकार घुमाएँ**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में आकार घुमाने की अनुमति देता है। यह विशेष संरेखण या डिज़ाइन आवश्यकताओं वाले दृश्य तत्वों को स्थिति देने में उपयोगी हो सकता है।

आकार को स्लाइड पर घुमाने के लिए इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
1. आकार की `Rotation` प्रॉपर्टी को वांछित कोण पर सेट करें।
1. प्रस्तुति सहेजें।

```c#
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें.
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें.
    ISlide slide = presentation.Slides[0];

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // आकार को 5 डिग्री घुमाएँ.
    shape.Rotation = 5;

    // PPTX फ़ाइल को डिस्क पर सहेजें.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![आकार घुमाव](shape-rotation.png)

## **3D बीवल प्रभाव जोड़ें**

Aspose.Slides आपको आकारों पर उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करके 3D बीवल प्रभाव लागू करने की अनुमति देता है।

3D बीवल प्रभाव जोड़ने के लिए इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
1. आकार के [ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/threedformat/) को कॉन्फ़िगर करके बीवल सेटिंग्स निर्धारित करें।
1. प्रस्तुति सहेजें।

```c#
// Presentation क्लास का एक इंस्टेंस बनाएं.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // स्लाइड में एक आकार जोड़ें.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // आकार की ThreeDFormat प्रॉपर्टीज़ सेट करें.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![3D बीवल प्रभाव](3D-bevel-effect.png)

## **3D घुमाव प्रभाव जोड़ें**

Aspose.Slides आपको आकारों पर उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करके 3D घुमाव प्रभाव लागू करने की अनुमति देता है।

3D घुमाव लागू करने के लिए इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
1. आकार के [CameraType](https://reference.aspose.com/slides/hi/net/aspose.slides/icamera/cameratype/) और [LightType](https://reference.aspose.com/slides/hi/net/aspose.slides/ilightrig/lighttype/) को सेट करके 3D घुमाव परिभाषित करें।
1. प्रस्तुति सहेजें।

```c#
// Presentation क्लास का एक इंस्टेंस बनाएं.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![3D घुमाव प्रभाव](3D-rotation-effect.png)

## **फ़ॉर्मेट रीसेट करें**

निम्नलिखित C# कोड दिखाता है कि कैसे स्लाइड के फ़ॉर्मेट को रीसेट किया जाए और [LayoutSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutslide/) पर प्लेसहोल्डर वाले सभी आकारों की स्थिति, आकार और फ़ॉर्मेट को उनके डिफ़ॉल्ट सेटिंग्स पर लौटाया जाए:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // लेआउट पर प्लेसहोल्डर वाले स्लाइड पर प्रत्येक आकार को रीसेट करें.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या आकार का फ़ॉर्मेटिंग अंतिम प्रस्तुति फ़ाइल आकार को प्रभावित करता है?**

केवल न्यूनतम रूप से। एम्बेडेड छवियां और मीडिया फ़ाइलें अधिकांश फ़ाइल स्थान लेती हैं, जबकि आकार के पैरामीटर जैसे रंग, प्रभाव और ग्रेडिएंट मेटाडाटा के रूप में संग्रहीत होते हैं और लगभग अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे पहचान सकता हूँ कि स्लाइड पर कौन से आकार समान फ़ॉर्मेटिंग साझा करते हैं ताकि मैं उन्हें समूहित कर सकूं?**

प्रत्येक आकार की प्रमुख फ़ॉर्मेटिंग प्रॉपर्टीज़—फ़िल, लाइन और इफ़ेक्ट सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनकी शैलियों को समान मानें और उन आकारों को तार्किक रूप से समूहित करें, जिससे बाद में शैली प्रबंधन आसान हो जाता है।

**क्या मैं कस्टम आकार शैलियों का सेट एक अलग फ़ाइल में सहेज कर अन्य प्रस्तुतियों में पुनः उपयोग कर सकता हूँ?**

हां। वांछित शैलियों वाले नमूना आकारों को एक टेम्पलेट स्लाइड डेक या .POTX टेम्पलेट फ़ाइल में सहेजें। जब नई प्रस्तुति बनाते हैं, तो टेम्पलेट खोलें, आवश्यक शैली वाले आकारों को क्लोन करें, और जहाँ भी आवश्यक हो, उनकी फ़ॉर्मेटिंग दोबारा लागू करें।