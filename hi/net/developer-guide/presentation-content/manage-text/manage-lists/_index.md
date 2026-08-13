---
title: .NET में प्रस्तुतियों में बुलेटेड और क्रमांकित सूचियों को प्रबंधित करें
linktitle: सूचियों का प्रबंधन
type: docs
weight: 70
url: /hi/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
  - बुलेट
  - बुलेटेड सूची
  - क्रमांकित सूची
  - प्रतीक बुलेट
  - चित्र बुलेट
  - कस्टम बुलेट
  - मल्टीलेवल सूची
  - बुलेट बनाएं
  - बुलेट जोड़ें
  - सूची जोड़ें
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड, चित्र, मल्टीलेवल, और क्रमांकित सूचियाँ बनाना और स्वरूपित करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for .NET आपको PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड तथा क्रमांकित सूचियाँ बनाने और फ़ॉर्मेट करने की अनुमति देता है। एक सूची आइटम वह पैराग्राफ होता है जिसका बुलेट सेटिंग पैराग्राफ फ़ॉर्मेट के माध्यम से नियंत्रित किया जाता है।

पैराग्राफ‑स्तर की सूची सेटिंग तक पहुँचने के लिए [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/paragraphformat/) प्रॉपर्टी का उपयोग करें। मुख्य प्रवेश बिंदु है [IParagraphFormat.Bullet](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/bullet/), जो एक [IBulletFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/) ऑब्जेक्ट लौटाता है। इस ऑब्जेक्ट के साथ आप बुलेट प्रकार, प्रतीक, चित्र, रंग, आकार, क्रमांक शैली, और प्रारम्भिक संख्या सेट कर सकते हैं।

यह लेख दर्शाता है कि कैसे:

- कस्टम प्रतीक के साथ बुलेटेड सूची बनाएं
- चित्र बुलेट बनाएं
- पैराग्राफ गहराई सेट करके मल्टी‑लेवल सूची बनाएं
- क्रमांकित सूची बनाएं
- मौजूदा प्रस्तुति में सूची फ़ॉर्मेट की जाँच और परिवर्तन करें

## **बुलेटेड सूची बनाएं**

बुलेटेड सूची बनाने के लिए, एक [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) में [IParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/) ऑब्जेक्ट जोड़ें और [IBulletFormat.Type](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/type/) को [BulletType.Symbol](https://reference.aspose.com/slides/hi/net/aspose.slides/bullettype/) पर सेट करें। फिर आप बुलेट स्वरूप को नियंत्रित करने के लिये [IBulletFormat.Char](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/color/), और [IBulletFormat.Height](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/height/) सेट कर सकते हैं।

निम्नलिखित C# कोड एक स्लाइड में बुलेटेड सूची बनाने का उदाहरण दर्शाता है:

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

## **क्रमांकित सूची बनाएं**

जब आइटम्स का क्रम महत्वपूर्ण हो तो क्रमांकित सूचियों का उपयोग करें। [IBulletFormat.Type](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/type/) को [BulletType.Numbered](https://reference.aspose.com/slides/hi/net/aspose.slides/bullettype/) पर सेट करें। आप [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/numberedbulletstyle/) से क्रमांक शैली चुन सकते हैं या जब सूची 1 से नहीं बल्कि किसी अन्य मान से शुरू होनी चाहिए तो [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/numberedbulletstartwith/) सेट कर सकते हैं।

निम्नलिखित C# कोड एक स्लाइड में क्रमांकित सूची बनाने का उदाहरण है:

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

![क्रमांकित बुलेट्स](numbered_bullets.png)

## **चित्र बुलेट बनाएं**

Aspose.Slides आपको सामान्य बुलेट प्रतीक को चित्र से बदलने की सुविधा देता है। चित्र बुलेट्स उन साधारण छवियों के साथ बेहतर काम करते हैं जो छोटे आकार में भी पठनीय रहें, जैसे कि आइकन या छोटे पारदर्शी PNG फ़ाइलें।

{{% alert color="info" %}}
यदि आप सामान्य बुलेट प्रतीक को चित्र से बदलने की योजना बनाते हैं, तो पारदर्शी पृष्ठभूमि वाली साधारण ग्राफ़िक चुनना सबसे अच्छा है। ऐसी छवियां कस्टम बुलेट प्रतीकों के रूप में अच्छी तरह काम करती हैं।

ध्यान रखें कि चित्र बहुत छोटे आकार में स्केल किया जाएगा। इसलिए हम दृढ़ता से अनुशंसा करते हैं कि आप ऐसी छवि चुनें जो सूची में बुलेट के रूप में उपयोग किए जाने पर भी स्पष्ट और दृश्य रूप से प्रभावी बनी रहे।
{{% /alert %}}

चित्र बुलेट बनाने के लिए, चित्र को [Presentation.Images](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/images/) में जोड़ें और लौटाए गए इमेज ऑब्जेक्ट को [IBulletFormat.Picture](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/picture/) को असाइन करें। असाइन करने से पहले [IBulletFormat.Type](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/type/) को [BulletType.Picture](https://reference.aspose.com/slides/hi/net/aspose.slides/bullettype/) पर सेट करें।

मान लीजिए हमारे पास "image.png" है:

![बुलेट्स के लिये चित्र](picture_for_bullets.png)

निम्नलिखित C# कोड एक स्लाइड में चित्र बुलेट बनाने का उदाहरण है:

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

## **मल्टी‑लेवल सूची बनाएं**

सूची आइटम्स को विभिन्न स्तरों पर रखने के लिये [IParagraphFormat.Depth](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/depth/) का उपयोग करें। स्तर 0 सबसे ऊपर का स्तर है, स्तर 1 उसके नीचे नेस्ट किया गया स्तर है, और इसी प्रकार आगे।

निम्नलिखित C# कोड मल्टी‑लेवल बुलेटेड सूची बनाने का उदाहरण है:

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

![मल्टी‑लेवल सूची](multilevel_list.png)

## **मौजूदा सूची बदलें**

मौजूदा प्रस्तुति में सूची फ़ॉर्मेट बदलने के लिये लक्ष्य पैराग्राफ तक पहुँचें और उसके [IParagraphFormat.Bullet](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/bullet/) सेटिंग्स को अपडेट करें। सूची बनाने के लिये उपयोग की गई वही प्रॉपर्टीज़ PPT, PPTX, या ODP फ़ाइल से लोड की गई सूचियों को जांचने या संशोधित करने के लिये भी इस्तेमाल की जा सकती हैं।

निम्नलिखित C# कोड टेक्स्ट फ़्रेम के पहले पैराग्राफ को क्रमांकित सूची शैली में बदलता है:

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

## **FAQ**

### क्या बुलेटेड और क्रमांकित सूचियों को PDF या चित्रों में निर्यात किया जा सकता है?

हां। Aspose.Slides सूची फ़ॉर्मेट को बरकरार रखता है जब लक्ष्य फ़ॉर्मेट संबंधित टेक्स्ट लेआउट और बुलेट सुविधाएँ सपोर्ट करता है।

### क्या मैं मौजूदा प्रस्तुतियों में सूचियों को संपादित कर सकता हूँ?

हां। प्रस्तुति लोड करें, लक्ष्य पैराग्राफ तक पहुँचें, उसके [IParagraphFormat.Bullet](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/bullet/) सेटिंग्स की जाँच या अपडेट करें, और प्रस्तुति को सेव करें।

### क्या सूचियों में गैर‑लैटिन टेक्स्ट हो सकता है?

हां। सूची आइटम टेक्स्ट Unicode कैरेक्टर्स रख सकता है, इसलिए आप बहुभाषी प्रस्तुतियों में सूचियाँ बना सकते हैं। सुनिश्चित करें कि प्रस्तुति में उपयोग किए गए फ़ॉन्ट्स उन कैरेक्टरों को सपोर्ट करते हैं जिनकी आपको आवश्यकता है।