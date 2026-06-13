---
title: .NET में प्रस्तुतियों में बुलेटेड और नंबरेड सूचियों का प्रबंधन
linktitle: सूचियों का प्रबंधन
type: docs
weight: 70
url: /hi/net/manage-lists/
keywords:
- बुलेट
- बुलेटेड सूची
- नंबरेड सूची
- सिंबल बुलेट
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
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड, चित्र, मल्टीलेवल और नंबरेड सूचियों को बनाना और फ़ॉर्मेट करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for .NET आपको PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड और नंबरेड सूचियाँ बनाने और फ़ॉर्मेट करने की सुविधा देता है। एक सूची आइटम एक पैराग्राफ होता है जिसका बुलेट सेटिंग उसके पैराग्राफ फॉर्मेट के माध्यम से नियंत्रित होता है।

पैराग्राफ-स्तर की सूची सेटिंग्स तक पहुंचने के लिए आप [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/paragraphformat/) प्रॉपर्टी का उपयोग कर सकते हैं। मुख्य प्रवेश बिंदु [IParagraphFormat.Bullet](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/bullet/) है, जो एक [IBulletFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/) ऑब्जेक्ट लौटाता है। इस ऑब्जेक्ट के साथ आप बुलेट का प्रकार, सिंबल, चित्र, रंग, आकार, क्रमांक शैली और प्रारंभिक संख्या सेट कर सकते हैं।

यह लेख दिखाता है कि कैसे:

- कस्टम सिंबल के साथ बुलेटेड सूची बनाना
- चित्र बुलेट बनाना
- पैराग्राफ गहराई सेट करके मल्टीलेवल सूची बनाना
- नंबरेड सूची बनाना
- मौजूदा प्रस्तुति में सूची फ़ॉर्मेटिंग का निरीक्षण और परिवर्तन करना

## **बुलेटेड सूची बनाना**

बुलेटेड सूची बनाने के लिए, आप [IParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/) ऑब्जेक्ट को [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) में जोड़ें और [IBulletFormat.Type](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/type/) को [BulletType.Symbol](https://reference.aspose.com/slides/hi/net/aspose.slides/bullettype/) पर सेट करें। इसके बाद आप [IBulletFormat.Char](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/color/), और [IBulletFormat.Height](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/height/) सेट करके बुलेट की उपस्थिति को नियंत्रित कर सकते हैं।

नीचे दिया गया C# कोड एक स्लाइड में बुलेटेड सूची बनाने का प्रदर्शन करता है:

```csharp
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

![सिंबल बुलेट्स](symbol_bullets.png)

## **नंबरेड सूची बनाना**

आइटम के क्रम का महत्व होने पर नंबरेड सूचियों का उपयोग करें। [IBulletFormat.Type](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/type/) को [BulletType.Numbered](https://reference.aspose.com/slides/hi/net/aspose.slides/bullettype/) पर सेट करें। आप [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/numberedbulletstyle/) के साथ क्रमांक शैली चुन सकते हैं या जब सूची 1 से अलग मान से शुरू होनी चाहिए तो [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/numberedbulletstartwith/) सेट कर सकते हैं।

नीचे दिया गया C# कोड एक स्लाइड में नंबरेड सूची बनाने का प्रदर्शन करता है:

```csharp
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

![नंबरेड बुलेट्स](numbered_bullets.png)

## **चित्र बुलेट बनाना**

Aspose.Slides आपको नियमित बुलेट सिंबल को छवि से बदलने की अनुमति देता है। चित्र बुलेट सबसे बेहतर होते हैं जब वे सरल छवियों से बने हों जो छोटा आकार में भी पठनीय रहें, जैसे कि आइकॉन या छोटे ट्रांसपरेंट PNG फाइलें।

{{% alert color="primary" %}}
आदर्श रूप में, यदि आप नियमित बुलेट सिंबल को छवि से बदलने की योजना बनाते हैं, तो पारदर्शी पृष्ठभूमि वाले सरल ग्राफिक का चयन करना सर्वोत्तम होता है। ऐसी छवियां कस्टम बुलेट सिंबल के रूप में अच्छी तरह काम करती हैं।
{{% /alert %}}

चित्र बुलेट बनाने के लिए, एक छवि को [Presentation.Images](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/images/) में जोड़ें और प्राप्त हुए इमेज ऑब्जेक्ट को [IBulletFormat.Picture](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/picture/) को असाइन करें। छवि असाइन करने से पहले, [IBulletFormat.Type](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/type/) को [BulletType.Picture](https://reference.aspose.com/slides/hi/net/aspose.slides/bullettype/) पर सेट करें।

मान लीजिए हमारे पास एक "image.png" है:

![बुलेट्स के लिए चित्र](picture_for_bullets.png)

नीचे दिया गया C# कोड एक स्लाइड में चित्र बुलेट बनाने का प्रदर्शन करता है:

```csharp
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

## **मल्टीलेवल सूची बनाना**

विभिन्न स्तरों पर सूची आइटम रखने के लिए [IParagraphFormat.Depth](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/depth/) का उपयोग करें। स्तर 0 शीर्ष स्तर है, स्तर 1 उसके नीचे नेस्टेड है, आदि।

नीचे दिया गया C# कोड मल्टीलेवल बुलेटेड सूची बनाने का प्रदर्शन करता है:

```csharp
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

मौजूदा प्रस्तुति में सूची फ़ॉर्मेटिंग बदलने के लिए, लक्षित पैराग्राफ तक पहुंचें और उसके [IParagraphFormat.Bullet](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/bullet/) सेटिंग्स को अपडेट करें। सूचियों को बनाने के लिए उपयोग की गई वही प्रॉपर्टीज़ PPT, PPTX या ODP फ़ाइल से लोड की गई सूचियों को निरीक्षण या संशोधित करने के लिए भी इस्तेमाल की जा सकती हैं।

नीचे दिया गया C# कोड टेक्स्ट फ्रेम में पहले पैराग्राफ को नंबरेड सूची शैली में बदलता है:

```csharp
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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बुलेटेड और नंबरेड सूचियों को PDF या छवियों में निर्यात किया जा सकता है?**

हाँ। Aspose.Slides सूची फ़ॉर्मेटिंग को बरकरार रखता है जब लक्ष्य फ़ॉर्मेट संबंधित टेक्स्ट लेआउट और बुलेट सुविधाओं का समर्थन करता है।

**क्या मैं मौजूदा प्रस्तुतियों में सूचियों को संपादित कर सकता हूँ?**

हाँ। प्रस्तुति लोड करें, लक्षित पैराग्राफ तक पहुंचें, उसके [IParagraphFormat.Bullet](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/bullet/) सेटिंग्स का निरीक्षण या अपडेट करें, और प्रस्तुति सहेजें।

**क्या सूचियों में गैर-लैटिन टेक्स्ट हो सकता है?**

हाँ। सूची आइटम टेक्स्ट यूनिकोड अक्षर रख सकता है, इसलिए आप बहुभाषी प्रस्तुतियों में सूचियाँ बना सकते हैं। सुनिश्चित करें कि प्रस्तुति में उपयोग किए गए फ़ॉन्ट आवश्यक अक्षरों का समर्थन करते हैं।