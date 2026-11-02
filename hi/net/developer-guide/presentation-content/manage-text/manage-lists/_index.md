---
title: ".NET में प्रस्तुतियों में बुलेटेड और नंबरड सूचियों का प्रबंधन"
linktitle: "सूचियों का प्रबंधन"
type: docs
weight: 70
url: /hi/net/manage-lists/
aliases:
  - "/net/बुलेट-और-नंबरड-सूचियों-को-प्रबंधित-करें/"
keywords:
  - बुलेट
  - बुलेटेड सूची
  - नंबरड सूची
  - प्रतीक बुलेट
  - चित्र बुलेट
  - कस्टम बुलेट
  - बहुस्तरीय सूची
  - बुलेट बनाएं
  - बुलेट जोड़ें
  - सूची जोड़ें
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड, चित्र, बहुस्तरीय, और नंबरड सूचियों को बनाने और स्वरूपित करने के बारे में जानें।"
---
## **अवलोकन**

Aspose.Slides for .NET आपको PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड और नंबरड सूचियों को बनाने और स्वरूपित करने की अनुमति देता है। एक सूची आइटम एक पैराग्राफ है जिसका बुलेट सेटिंग उसके पैराग्राफ फ़ॉर्मेट के माध्यम से नियंत्रित की जाती है।

पैराग्राफ-स्तर की सूची सेटिंग्स तक पहुंचने के लिए [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) प्रॉपर्टी का उपयोग करें। मुख्य प्रवेश बिंदु है [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/), जो एक [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) ऑब्जेक्ट लौटाता है। इस ऑब्जेक्ट के साथ, आप बुलेट प्रकार, प्रतीक, चित्र, रंग, आकार, क्रमांक शैली, और प्रारंभिक संख्या सेट कर सकते हैं।

यह लेख दर्शाता है कि कैसे:

- कस्टम प्रतीक के साथ बुलेटेड सूची बनाएं
- चित्र बुलेट बनाएं
- पैराग्राफ गहराई सेट करके मल्टीलेवल सूची बनाएं
- नंबरड सूची बनाएं
- मौजूदा प्रस्तुति में सूची स्वरूपण का निरीक्षण और परिवर्तन करें
- पैराग्राफ टेक्स्ट के साथ वास्तविक सूची मार्कर और संख्याएँ पढ़ें

## **बुलेटेड सूची बनाएं**

बुलेटेड सूची बनाने के लिए, एक [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) ऑब्जेक्ट को एक [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) में जोड़ें और [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) को [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) पर सेट करें। आप फिर बुलेट appearance को नियंत्रित करने के लिए [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/color/), और [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) सेट कर सकते हैं।

निम्नलिखित C# कोड एक स्लाइड में बुलेटेड सूची बनाने का प्रदर्शन करता है:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

परिणाम:

![प्रतीक बुलेट्स](symbol_bullets.png)

## **नंबरड सूची बनाएं**

जब आइटमों का क्रम महत्वपूर्ण हो तो नंबरड सूचियों का उपयोग करें। [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) को [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) पर सेट करें। आप [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) से एक क्रमांकन प्रारूप चुन सकते हैं या जब सूची को 1 के अलावा किसी मान से शुरू करना हो तो [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) सेट कर सकते हैं।

निम्नलिखित C# कोड एक स्लाइड में नंबरड सूची बनाने को दर्शाता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

परिणाम:

![नंबरड बुलेट्स](numbered_bullets.png)

## **चित्र बुलेट बनाएं**

Aspose.Slides आपको एक सामान्य बुलेट प्रतीक को छवि से बदलने की अनुमति देता है। चित्र बुलेट सबसे अच्छा सरल छवियों के साथ काम करता है जो छोटे आकार पर भी पठनीय रहती हैं, जैसे आइकन या छोटे पारदर्शी PNG फ़ाइलें।

{{% alert color="info" title="Note" %}}
यदि आप सामान्य बुलेट प्रतीक को छवि से बदलने की योजना बना रहे हैं, तो पारदर्शी पृष्ठभूमि वाली एक सरल ग्राफिक चुनना सबसे अच्छा है। ऐसी छवियाँ कस्टम बुलेट प्रतीकों के रूप में अच्छी तरह काम करती हैं।

ध्यान रखें कि छवि को बहुत छोटे आकार में स्केल किया जाएगा। इसलिए हम दृढ़ता से सलाह देते हैं कि ऐसा चित्र चुनें जो सूची में बुलेट के रूप में उपयोग किए जाने पर भी स्पष्ट और दृश्य रूप से प्रभावी बना रहे।
{{% /alert %}}

चित्र बुलेट बनाने के लिए, एक छवि को [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/images/) में जोड़ें और लौटाई गई छवि ऑब्जेक्ट को [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) को असाइन करें। असाइन करने से पहले [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) को [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) पर सेट करें।

मान लीजिए हमारे पास एक "image.png" है:

![बुलेट्स के लिए चित्र](picture_for_bullets.png)

निम्नलिखित C# कोड स्लाइड में चित्र बुलेट बनाने को दर्शाता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

परिणाम:

![चित्र बुलेट्स](picture_bullets.png)

## **मल्टीलेवल सूची बनाएं**

सूची आइटमों को विभिन्न स्तरों पर रखने के लिए [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) का उपयोग करें। स्तर 0 शीर्ष स्तर है, स्तर 1 इसके नीचे नेस्टेड है, आदि।

निम्नलिखित C# कोड मल्टीलेवल बुलेटेड सूची बनाने को दर्शाता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

परिणाम:

![मल्टीलेवल सूची](multilevel_list.png)

## **मौजूदा सूची बदलें**

मौजूदा प्रस्तुति में सूची स्वरूपण को बदलने के लिए, लक्षित पैराग्राफ तक पहुंचें और उसके [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) सेटिंग्स को अपडेट करें। सूची बनाने के लिए उपयोग किए गए वही प्रॉपर्टीज़ PPT, PPTX, या ODP फ़ाइल से लोड की गई सूचियों को निरीक्षण या संशोधित करने के लिए भी उपयोग की जा सकती हैं।

निम्नलिखित C# कोड एक टेक्स्ट फ्रेम में पहले पैराग्राफ को नंबरड सूची शैली के साथ उपयोग करने के लिए बदलता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **वास्तविक बुलेट मान पढ़ें**

प्रस्तुति सामग्री निकालते समय, सूची मार्कर को पैराग्राफ टेक्स्ट के साथ रखें। [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/) को कॉल करें और प्रभावी बुलेट फ़ॉर्मेट प्राप्त करने के लिए [IParagraphFormatEffectiveData.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformateffectivedata/bullet/) तक पहुंचें। पढ़ने से पहले उसके [Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/type/) की जाँच करें और फिर [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) पढ़ें।

नंबरड सूचियों के लिए, इन तीन मानों में अंतर करें:

- [NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstyle/) फ़ॉर्मेट निर्धारित करता है, जैसे अवधि के साथ अरबी अंक या अवधि के साथ लोअरकेस अक्षर।
- [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstartwith/) एक समूह के नंबरड पैराग्राफों के लिये प्रारंभिक संख्या निर्दिष्ट करता है।
- [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) किसी विशेष पैराग्राफ के लिये स्वरूपित मार्कर 반환 करता है। उदाहरण के लिये, 5 से शुरू होने वाली सूची में दूसरा आइटम `6.` लौटाएगा।

प्रत्येक पैराग्राफ के साथ [Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) को संरक्षित रखें ताकि उसकी नेस्टिंग स्तर बनी रहे। वास्तविक मार्कर पूर्ण पदानुक्रम को एन्कोड नहीं करता: एक नेस्टेड आइटम `c.` लौटा सकता है न कि `6.c.` जैसी संयुक्त लेबल।

निम्नलिखित स्वनिर्भर उदाहरण सूचियों को बनाता है, उन्हें एक प्रस्तुति में सहेजता है, और प्रस्तुति को पुनः लोड करके प्रत्येक पैराग्राफ का टेक्स्ट, गहराई, बुलेट प्रकार और वास्तविक मान रिपोर्ट करता है। छोटा नीला चित्र मार्कर इनलाइन SVG से बनाया गया है।

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    presentation.SlideSize.SetSize(720, 440, SlideSizeScaleType.DoNotScale);
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // बिना बाहरी छवि फ़ाइल के चित्र मार्कर बनाएं।
    var svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    var bulletImage = presentation.Images.AddImage(svg);

    void AddParagraph(string text, short depth, BulletType type, short start = 1, NumberedBulletStyle style = NumberedBulletStyle.BulletArabicPeriod)
    {
        var paragraph = new Paragraph { Text = text };

        var format = paragraph.ParagraphFormat;
        format.Depth = depth;
        format.MarginLeft = 30 + depth * 40;
        format.Indent = -28;
        format.SpaceAfter = 8;
        format.DefaultPortionFormat.FontHeight = 22;
        format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
        format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        format.Bullet.Type = type;
        format.Bullet.IsBulletHardColor = NullableBool.True;
        format.Bullet.Color.Color = Color.Black;
        if (type == BulletType.Numbered)
        {
            format.Bullet.NumberedBulletStyle = style;
            format.Bullet.NumberedBulletStartWith = start;
        }
        else if (type == BulletType.Symbol)
        {
            format.Bullet.Char = '\u2022';
        }
        else if (type == BulletType.Picture)
        {
            format.Bullet.Picture.Image = bulletImage;
        }

        textFrame.Paragraphs.Add(paragraph);
    }

    AddParagraph("First item", 0, BulletType.Numbered, 5);
    AddParagraph("Second item", 0, BulletType.Numbered, 5);
    AddParagraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod);
    AddParagraph("Back to top level", 0, BulletType.Numbered, 5);
    AddParagraph("Symbol marker", 0, BulletType.Symbol);
    AddParagraph("No bullet", 0, BulletType.None);
    AddParagraph("Picture marker", 0, BulletType.Picture);
    presentation.Save("actual_bullet_values.pptx", SaveFormat.Pptx);
}

using var loadedPresentation = new Presentation("actual_bullet_values.pptx");
var loadedShape = (IAutoShape)loadedPresentation.Slides[0].Shapes[0];
Console.WriteLine("Text | Depth | Type | Actual value");
foreach (var paragraph in loadedShape.TextFrame.Paragraphs)
{
    var bullet = paragraph.ParagraphFormat.GetEffective().Bullet;
    string marker;
    switch (bullet.Type)
    {
        case BulletType.Numbered:
        case BulletType.Symbol:
            marker = bullet.ActualBulletValue;
            break;
        case BulletType.None:
            marker = $"{bullet.ActualBulletValue ?? "null"} (no bullet)";
            break;
        case BulletType.Picture:
            marker = $"{bullet.ActualBulletValue ?? "null"} (image required)";
            break;
        default:
            marker = "unsupported bullet type";
            break;
    }
    Console.WriteLine($"{paragraph.Text} | {paragraph.ParagraphFormat.Depth} | {bullet.Type} | {marker}");
}
```

स्रोत सूचियां नीचे दिखायी गई हैं।

![5 से शुरू होने वाली सूचियाँ, नेस्टेड लेटर और रोमन-नंबर आइटम, प्रतीक मार्कर, बुलेट बिना पैराग्राफ, और नीला चित्र मार्कर](actual_bullet_values.png)

रिपोर्ट PowerPoint में दिखाए गए मार्करों से मेल खाती है:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

[BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) के लिये, [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) `null` लौटाता है, खाली स्ट्रिंग नहीं। इन प्रकारों को अलग‑अलग संभालें: पहला कोई मार्कर नहीं रखता, जबकि दूसरा बुलेट छवि को अलग से निकालने की आवश्यकता होती है। एक चित्र बुलेट केवल टेक्स्ट मार्कर निकालकर पुनः निर्मित नहीं किया जा सकता।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बुलेटेड और नंबरड सूचियों को PDF या इमेज में निर्यात किया जा सकता है?**

हाँ। Aspose.Slides सूची स्वरूपण को संरक्षित रखता है जब लक्ष्य फ़ॉर्मेट संबंधित टेक्स्ट लेआउट और बुलेट विशेषताएँ समर्थित करता है।

**क्या मैं मौजूदा प्रस्तुतियों में सूचियों को संपादित कर सकता हूँ?**

हाँ। प्रस्तुति लोड करें, लक्षित पैराग्राफ तक पहुँचें, उसके [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) सेटिंग्स को निरीक्षण या अपडेट करें, और प्रस्तुति सहेजें।

**क्या सूचियों में गैर‑लैटिन टेक्स्ट हो सकता है?**

हाँ। सूची आइटम टेक्स्ट Unicode अक्षर रख सकता है, इसलिए आप बहुभाषी प्रस्तुतियों में सूचियाँ बना सकते हैं। सुनिश्चित करें कि प्रस्तुति में उपयोग किए गए फ़ॉन्ट आवश्यक अक्षरों को समर्थन करते हों।