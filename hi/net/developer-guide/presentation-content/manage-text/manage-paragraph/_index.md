---
title: ".NET में PowerPoint टेक्स्ट पैराग्राफ़ प्रबंधित करें"
linktitle: "पैराग्राफ़ प्रबंधित करें"
type: docs
weight: 40
url: /hi/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
  - टेक्स्ट जोड़ें
  - पैराग्राफ़ जोड़ें
  - टेक्स्ट प्रबंधित करें
  - पैराग्राफ़ प्रबंधित करें
  - बुलेट प्रबंधित करें
  - पैराग्राफ़ इन्डेंट
  - हैंगिंग इन्डेंट
  - पैराग्राफ़ बुलेट
  - नंबरित सूची
  - बुलेटेड सूची
  - पैराग्राफ़ गुण
  - HTML आयात करें
  - टेक्स्ट से HTML
  - पैराग्राफ़ से HTML
  - पैराग्राफ़ से छवि
  - टेक्स्ट से छवि
  - पैराग्राफ़ निर्यात करें
  - PowerPoint
  - प्रस्तुति
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides for .NET के साथ पैराग्राफ़, पोर्शन, बुलेट, नंबरित सूचियाँ, इन्डेंट, HTML सामग्री और पैराग्राफ़ छवियाँ बनाना और फ़ॉर्मेट करना सीखें।"
---
## **समीक्षा**

Aspose.Slides for .NET टेक्स्ट को टेक्स्ट फ़्रेम, पैराग्राफ़ और पोर्शन की पदानुक्रम में प्रस्तुत करता है:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) एक आकार में टेक्स्ट कंटेनर का प्रतिनिधित्व करता है और इसके पैराग्राफ़ संग्रह तक पहुँच प्रदान करता है।
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) टेक्स्ट फ़्रेम में एक पैराग्राफ़ का प्रतिनिधित्व करता है और इसके पोर्शन और पैराग्राफ‑स्तरीय फ़ॉर्मेटिंग तक पहुँच प्रदान करता है।
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) पैराग्राफ़ के भीतर एक टेक्स्ट रन का प्रतिनिधित्व करता है। प्रत्येक पोर्शन का अपना टेक्स्ट और कैरेक्टर‑स्तर फ़ॉर्मेटिंग हो सकता है।

इस प्रकार एक पैराग्राफ़ विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फ़ॉर्मेटिंग वाले टेक्स्ट को कई पोर्शन का उपयोग करके रख सकता है।

## **पैराग्राफ़ बनाना और फ़ॉर्मेट करना**

एक आकार के टेक्स्ट फ़्रेम में पैराग्राफ़ बनाएँ और व्यक्तिगत टेक्स्ट रन को फ़ॉर्मेट करने के लिए पोर्शन का उपयोग करें। यह अनुभाग दिखाता है कि कैसे प्रत्येक पैराग्राफ़ में कई पोर्शन को जोड़ें और विभिन्न रंग, फ़ॉन्ट आकार और शैलियाँ लागू करें।

### **कई पोर्शन के साथ पैराग्राफ़ बनाना**

निम्न C# उदाहरण three पैराग्राफ़ बनाता है, प्रत्येक में अपने [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/) संग्रह में तीन टेक्स्ट रन होते हैं। यह डिफ़ॉल्ट पैराग्राफ़ और उसकी खाली पोर्शन को पुनः उपयोग करता है, फिर शेष पैराग्राफ़ और पोर्शन जोड़ता है। फ़ॉर्मेटिंग [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/) के माध्यम से लागू की जाती है: प्रत्येक पैराग्राफ़ में पहली पोर्शन लाल, बोल्ड और 15 पॉइंट है; दूसरी नीली, इटैलिक और 18 पॉइंट है। तीसरी पोर्शन अपनी डिफ़ॉल्ट फ़ॉर्मेटिंग रखती है:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **बुलेटेड और नंबरित सूचियाँ बनाना**

पैराग्राफ़ टेक्स्ट को प्रतीकों, संख्याओं या कस्टम चित्रों के साथ सूचियों में व्यवस्थित करें। इस अनुभाग में बुलेट फ़ॉर्मेटिंग, मल्टी‑लेवल सूचियाँ और कस्टम प्रारम्भिक संख्याएँ दर्शाई गई हैं।

### **बुलेटेड या नंबरित सूची बनाना**

बुलेट और नंबरिंग संबंधित आइटम्स को स्कैन करना आसान बनाते हैं। Aspose.Slides में सूची सेटिंग्स [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) के माध्यम से परिभाषित की जाती हैं।

यह C# उदाहरण एक ही टेक्स्ट फ़्रेम में एक प्रतीक बुलेट और एक नंबरित आइटम जोड़ता है। [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) बुलेट प्रकार चुनता है, जबकि [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) प्रतीक प्रदान करता है और [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) नंबरिंग शैली चुनता है। दोनों आइटम काले बुलेट 100 % ऊँचाई और पैराग्राफ़ इन्डेंट 25 पॉइंट के साथ उपयोग करते हैं:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **चित्र बुलेट्स का उपयोग करना**

चित्र बुलेट्स आपको प्रतीक या संख्या के बजाय कस्टम चित्र उपयोग करने की अनुमति देती हैं।

यह C# उदाहरण प्रस्तुति की इमेज कलेक्शन में एक [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) जोड़ता है और उसे पैराग्राफ़ बुलेट के रूप में उपयोग करता है। यह [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) को चित्र बुलेट उपयोग करने के लिए सेट करता है और चित्र को [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) के माध्यम से असाइन करता है। [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) को 100 % पर सेट किया जाता है ताकि बुलेट पैराग्राफ़ टेक्स्ट के अनुपात में आकार ले:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **मल्टी‑लेवल सूची बनाना**

[IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) को सेट करके पैराग्राफ़ को सूची के विभिन्न स्तरों पर रखें। शीर्ष स्तर की गहराई `0` होती है।

यह C# उदाहरण चार पैराग्राफ़ को 0 से 3 तक की [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) मान असाइन करता है, जिससे एक ही टेक्स्ट फ़्रेम में पदानुक्रम बनता है। प्रत्येक पैराग्राफ़ प्रतीक बुलेट का उपयोग करता है, जहाँ [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) गोल बुलेट और हाइफ़न के बीच बदलता रहता है ताकि निकटवर्ती स्तरों को अलग किया जा सके:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **कस्टम मानों से नंबरित सूची आइटम शुरू करना**

[IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) का उपयोग करके नंबरित पैराग्राफ़ के प्रारम्भिक नंबर को सेट करें।

यह C# उदाहरण तीन पैराग्राफ़ के लिए नंबरिंग उपयोग करने हेतु [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) सेट करता है और क्रमशः 2, 3, 7 के [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) मान असाइन करता है। प्रारम्भिक मान प्रत्येक पैराग्राफ़ के लिये अलग‑अलग कॉन्फ़िगर किया जाता है, जिससे दिखाए गए नंबर मान छोड़ सकते हैं:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **पैराग्राफ़ लेआउट और अंत गुण नियंत्रित करना**

पहली पंक्ति और रैप्ड लाइनों की स्थिति को नियंत्रित करने के लिये पैराग्राफ़ मार्जिन और इन्डेंट समायोजित करें। आप पैराग्राफ़ अंत चिह्न को दृश्यमान टेक्स्ट पोर्शन से अलग फ़ॉर्मेट भी कर सकते हैं।

### **पहली‑लाइन इन्डेंट सेट करना**

[IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) प्रॉपर्टी का उपयोग करके पैराग्राफ़ की पहली‑लाइन इन्डेंट नियंत्रित करें। यह प्रॉपर्टी केवल पहली पंक्ति को पैराग्राफ़ के बाएँ मार्जिन के सापेक्ष ले जाती है। सकारात्मक मान पहली पंक्ति को दाएँ शिफ्ट करता है, जबकि शेष पंक्तियाँ पैराग्राफ़ बॉडी के साथ संरेखित रहती हैं।

पूरा पैराग्राफ़ ले जाने के लिये [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) उपयोग करें। केवल पहली पंक्ति ले जाने के लिये [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) उपयोग करें।

निम्न उदाहरण तीन पैराग्राफ़ को समान [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) 20 पॉइंट और [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) 0, 20, 40 पॉइंट मान देता है। पहली पंक्तियाँ क्रमशः बड़े ऑफ़सेट पर शुरू होती हैं, जबकि रैप्ड लाइनों की बाएँ मार्जिन समान रहती है:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

परिणाम:

![पैराग्राफ़ की पहली‑लाइन इन्डेंट](first_line_indent.png)

### **हैंगिंग इन्डेंट सेट करना**

हैंगिंग इन्डेंट वह पैराग्राफ़ लेआउट है जिसमें पहली पंक्ति शेष लाइनों से बाईं ओर शुरू होती है। Aspose.Slides में यह प्रभाव [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) प्रॉपर्टी से बनाते हैं। `Indent` को नकारात्मक मान पर सेट करने से पहली पंक्ति पैराग्राफ़ बॉडी के सापेक्ष बाएँ शिफ्ट होती है।

व्यावहारिक रूप से, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) पैराग्राफ़ बॉडी की बाएँ स्थिति निर्धारित करता है, और [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) पहली पंक्ति की स्थिति उस मार्जिन के सापेक्ष तय करता है। हैंगिंग इन्डेंट बनाने के लिये सकारात्मक `MarginLeft` मान और नकारात्मक `Indent` मान सेट करें।

यह फ़ॉर्मेटिंग ग्रंथसूची, संदर्भ, शब्दकोश प्रविष्टियों आदि में उपयोगी है जहाँ रैप्ड लाइनों को पैराग्राफ़ बॉडी के नीचे संगत रूप से संरेखित करना आवश्यक होता है, न कि पहली पंक्ति के पहले अक्षर के नीचे।

निम्न C# उदाहरण में [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) को क्रमशः 40 और 60 पॉइंट तथा [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) को –20 और –30 पॉइंट दिया गया है। प्रत्येक पैराग्राफ़ में पहली पंक्ति रैप्ड लाइनों से बाएँ शुरू होती है; दूसरे पैराग्राफ़ में हैंगिंग इन्डेंट अधिक गहरा है:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

परिणाम:

![पैराग्राफ़ की हैंगिंग इन्डेंट](hanging_indent.png)

### **अंत पैराग्राफ़ रन गुण सेट करना**

[IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) प्रॉपर्टी पैराग्राफ़ अंत चिह्न के फ़ॉर्मेट को नियंत्रित करती है। निम्न उदाहरण एक [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) बनाता है जिसमें [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) 48 पॉइंट और [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) Times New Roman पर सेट है। यह फ़ॉर्मेट दूसरे पैराग्राफ़ के अंत चिह्न पर लागू किया जाता है, जबकि दृश्यमान टेक्स्ट पोर्शन अपरिवर्तित रहते हैं:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **रेंडर की गई लाइनों की गणना करना**

लाइन‑ब्रेकिंग और लाइन‑एंड पंक्चुएशन से संबंधित पैराग्राफ़ नियमों के लिये देखें [Control Line Breaking](/slides/hi/net/text-formatting/#control-line-breaking) और [Control Hanging Punctuation](/slides/hi/net/text-formatting/#control-hanging-punctuation)।

[IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) का उपयोग करके टेक्स्ट लेआउट के बाद किसी पैराग्राफ़ द्वारा ली गई लाइनों की संख्या गिनें, जिसमें ऑटो‑रैपिंग सम्मिलित है। यह प्रस्तुति टेम्पलेट में टेक्स्ट की लंबाई और लेआउट जाँचने में उपयोगी है।

पैराग्राफ़ एक आइटम है [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/) में, और यह कई रेंडर की गई लाइनों पर कब्ज़ा कर सकता है। पैराग्राफ़ के भीतर स्पष्ट लाइन ब्रेक नई पंक्ति बनाता है बिना नया पैराग्राफ़ बनाए। ऑटो‑रैपिंग उपलब्ध चौड़ाई के आधार पर लाइनों का निर्माण करता है, बिना टेक्स्ट में स्पष्ट लाइन‑ब्रेक कैरेक्टर डाले। इसलिए पैराग्राफ़ या लाइन‑ब्रेक कैरेक्टर गिनने से रेंडर की गई लाइनों की संख्या नहीं मिलती।

निम्न उदाहरण एक टेक्स्ट आकार बनाता है, उसकी लाइनों की गिनती करता है, आकार को संकीर्ण करता है, फिर टेक्स्ट को छोटा स्ट्रिंग से बदलता है। उदाहरण [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) को सक्षम करता है और [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) को निष्क्रिय करता है ताकि आकार की चौड़ाई रैपिंग को नियंत्रित करे, बिना टेक्स्ट को स्वतः छोटा किए या आकार को पुनः आकारित किए। प्रत्येक माप [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) का उपयोग करता है। आकार माप पॉइंट में हैं। अंत में, उदाहरण एक अतिरिक्त पैराग्राफ़ जोड़ता है और टेक्स्ट फ़्रेम में सभी लाइन गणनाएँ जोड़ता है।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;

var paragraph = textFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
paragraph.Text = "This text demonstrates how automatic wrapping changes the number of rendered lines.";
Console.WriteLine($"Original width: {paragraph.GetLinesCount()}");

shape.Width = 150;
Console.WriteLine($"Narrower shape: {paragraph.GetLinesCount()}");

paragraph.Text = "Short text.";
Console.WriteLine($"Shorter text: {paragraph.GetLinesCount()}");

var secondParagraph = new Paragraph { Text = "Another paragraph." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
textFrame.Paragraphs.Add(secondParagraph);

var totalLineCount = 0;
foreach (var currentParagraph in textFrame.Paragraphs)
{
    totalLineCount += currentParagraph.GetLinesCount();
}
Console.WriteLine($"Total lines in the text frame: {totalLineCount}");
```

इन टेक्स्ट और मापों के साथ, आकार को संकीर्ण करने से लाइन गणना बढ़ती है, जबकि छोटा स्ट्रिंग डालने से घटती है। सटीक गणना फ़ॉन्ट उपलब्धता, फ़ॉन्ट प्रतिस्थापन, फ़ॉन्ट आकार, मार्जिन, इन्डेंट, रैपिंग और ऑटो‑फिट सेटिंग्स पर निर्भर करती है। टेम्पलेट जाँचते समय लक्षित पर्यावरण के लिये नियत फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

केवल लाइन गणना यह निर्धारित नहीं करती कि टेक्स्ट कंटेनर से बाहर निकलता है या नहीं। उपलब्ध ऊँचाई, लाइन‑हाइट, पैराग्राफ़ और लाइन स्पेसिंग, तथा ऑटो‑फिट व्यवहार भी महत्त्वपूर्ण हैं; यहाँ तक कि एक ही लाइन भी उपलब्ध चौड़ाई से अधिक हो सकती है जब रैपिंग निष्क्रिय हो।

## **पैराग्राफ़ सामग्री आयात और निर्यात करना**

HTML का उपयोग करके टेक्स्ट को प्रस्तुति में लाएँ या मौजूदा पैराग्राफ़ को बाहरी उपयोग के लिये निर्यात करें। यह अनुभाग दिखाता है कि कैसे व्यक्तिगत पैराग्राफ़ को छवि के रूप में रेंडर करें, जिसमें तालिका कोशिकाओं में पैराग्राफ़ भी शामिल हैं।

### **HTML टेक्स्ट को पैराग्राफ़ में आयात करना**

[ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) का उपयोग करके HTML मार्कअप को टेक्स्ट फ़्रेम में पैराग्राफ़ और पोर्शन में परिवर्तित करें।

यह C# उदाहरण फ़ाइल से HTML पढ़ता है और मार्कअप को [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) को पास करता है। यह टेक्स्ट फ़्रेम के डिफ़ॉल्ट पैराग्राफ़ को हटाता है ताकि फ़्रेम में केवल आयातित सामग्री हो। आयताकार आकार प्रत्येक स्लाइड किनारे से 10‑पॉइंट मार्जिन छोड़ता है:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **पैराग्राफ़ टेक्स्ट को HTML में निर्यात करना**

[ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) का उपयोग करके चयनित पैराग्राफ़ रेंज को HTML में निर्यात करें। जब प्रस्तुति का टेक्स्ट वेबसाइट पर पुन: उपयोग किया जाता है, तो आप स्थानीय फ़ॉर्मेटिंग को फ़ॉन्ट, आकार या टेक्स्ट बॉक्स शैलियों को लेकर बिना ले जाएँ। [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) को सेट करके निर्यातकर्ता कितनी दूर फ़ॉर्मेटिंग विरासत का अनुसरण करता है, नियंत्रित करें।

[उदाहरण प्रस्तुति](text-inheritance.pptx) डाउनलोड करें और इसे एप्लिकेशन की वर्किंग डायरेक्टरी में रखें। इसकी पहली स्लाइड में एक टेक्स्ट आकार है जिसमें टेक्स्ट "Inherited text; explicit red 18pt" है। इनपुट जानबूझकर कई फ़ॉर्मेटिंग स्तरों का उपयोग करता है:

- प्रस्तुति की डिफ़ॉल्ट टेक्स्ट शैली Calibri और 28 pt आकार प्रदान करती है।
- टेक्स्ट फ़्रेम की प्रथम‑स्तर शैली नीला टेक्स्ट और इटैलिक्स प्रदान करती है।
- पैराग्राफ़ स्पष्ट रूप से बोल्ड टेक्स्ट सेट करता है।
- दूसरा पोर्शन, "explicit red 18pt", स्पष्ट रूप से लाल टेक्स्ट और 18 pt आकार सेट करता है।

निम्न पूर्ण उदाहरण वही पैराग्राफ़ तीन बार निर्यात करता है। यह निर्यात विधि को [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) पास करता है और प्रत्येक परिणाम को अलग‑अलग UTF‑8 HTML फ़ाइल में लिखता है:

```csharp
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("text-inheritance.pptx");
var textShape = (IAutoShape)presentation.Slides[0].Shapes[0];

var paragraphs = textShape.TextFrame.Paragraphs;
var modes = new[] { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };

foreach (var mode in modes)
{
    var options = new TextToHtmlConversionOptions { TextInheritanceLimit = mode };

    var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
    File.WriteAllText($"{mode}.html", html, Encoding.UTF8);
}
```

उत्पन्न HTML पहले पोर्शन "Inherited text; " के लिये निम्न CSS रखती है। तालिका संबंधित घोषणाओं को सूचीबद्ध करती है; अन्य उत्पन्न प्रॉपर्टी स्पष्टता के लिये छोड़ी गई हैं।

| आउटपुट | प्रथम पोर्शन के लिये संबंधित CSS | दिखावट |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | यदि फ़ॉन्ट उपलब्ध हो तो Calibri में 28 pt पर नीला, बोल्ड, इटैलिक टेक्स्ट। |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | नीला, बोल्ड, इटैलिक टेक्स्ट; आसपास का पेज या ब्राउज़र फ़ॉन्ट परिवार और आकार प्रदान करता है। |
| `ParagraphOnly.html` | `font-weight:bold` | बोल्ड टेक्स्ट; आसपास का पेज या ब्राउज़र फ़ॉन्ट परिवार, आकार, रंग और इटैलिक शैली प्रदान करता है। |

दूसरा पोर्शन सभी तीन आउटपुट में `color:#ff0000`, `font-size:18pt` और `font-weight:bold` बनाये रखता है। यह `All` और `TextBox` में इटैलिक भी रखता है, लेकिन `ParagraphOnly` में नहीं। विरासत को सीमित करने से पैराग्राफ़ या पोर्शन पर स्पष्ट रूप से असाइन किए गए फ़ॉर्मेटिंग को हटाया नहीं जाता।

फ़ाइलों को समान ब्राउज़र में खोलें और तुलना करें। दो सीमित मोड में, छोड़ दी गई CSS प्रॉपर्टी लक्षित पेज की शैलियों या ब्राउज़र डिफ़ॉल्ट द्वारा लागू होती है, इसलिए अंतिम दिखावट HTML के उपयोग स्थान पर निर्भर करती है।

### **HTML क्लिपबोर्ड फ्रैगमेंट जनरेट करना**

[AddClipboardFragmentHeader](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/addclipboardfragmentheader/) को `false` सेट करने पर सामान्य HTML या `true` पर क्लिपबोर्ड हेडर शामिल होता है। दोनों कॉल स्ट्रिंग लौटाते हैं। हेडर आसपास के HTML (`StartHTML` और `EndHTML`) और चिपकाने योग्य सामग्री (`StartFragment` और `EndFragment`) के UTF‑8 बाइट ऑफ़सेट देता है।

यह उदाहरण दो फ़ॉर्मेटेड पैराग्राफ़ को सामान्य HTML (`html`) और HTML क्लिपबोर्ड फ्रैगमेंट (`clipboardHtml`) के रूप में निर्यात करता है। फ्रैगमेंट को सिस्टम क्लिपबोर्ड में लिखना एक अलग एप्लिकेशन चरण है। UTF‑8 बिना BOM के कच्चा HTML क्लिपबोर्ड बाइट्स स्वीकार करने वाले क्लिपबोर्ड API को आवश्यक है।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 400, 100);
var paragraphs = shape.TextFrame.Paragraphs;
paragraphs.Clear();
paragraphs.AddFromHtml("<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>");

var options = new TextToHtmlConversionOptions { AddClipboardFragmentHeader = false };
var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);

options.AddClipboardFragmentHeader = true;
var clipboardHtml = paragraphs.ExportToHtml(0, paragraphs.Count, options);
```

### **पैराग्राफ़ को छवि के रूप में रेंडर करना**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) व्यक्तिगत पैराग्राफ़ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) लौटाता है। परिणाम को फ़ाइल या स्ट्रीम में [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) से सुरक्षित करें। आपको पूरे आकार को रेंडर करने या बिटमैप को मैन्युअली क्रॉप करने की आवश्यकता नहीं है।

यदि पैराग्राफ़ अभिभावक संग्रह में नहीं मिलता, वैध रेंडर सीमा नहीं होती, या रेंडर नहीं किया जा सकता तो [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) `null` लौटाता है। सहेजने से पहले परिणाम की जाँच करें और उपयोग के बाद लौटाई गई छवि को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ़ रेंडर करना**

उदाहरण में एक प्रस्तुति है जिसमें एक स्लाइड है और उसकी प्रथम आकार एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ़ हैं।

![तीन पैराग्राफ़ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न उदाहरण इंडेक्स 1 पर दूसरे पैराग्राफ़ को चुनता है और [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) को बिना स्केल पैरामीटर के कॉल करता है। यह जांचता है कि आकार में आवश्यक पैराग्राफ़ है और रेंडरिंग एक छवि लौटाती है, फिर [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) से PNG में सहेजता है। `using` स्टेटमेंट उपयोग के बाद छवि को डिस्पोज़ करता है।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

परिणाम:

![पैराग्राफ़ छवि](paragraph_to_image_output.png)

#### **तालिका कोशिका में स्केल के साथ पैराग्राफ़ रेंडर करना**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) ओवरलोड का उपयोग करें जो `float scaleX` और `float scaleY` पैरामीटर स्वीकार करता है ताकि क्षैतिज और लंबवत स्केल फ़ैक्टर सेट हों। निम्न उदाहरण एक तालिका बनाता है, पहले कोशिका में पैराग्राफ़ को डिफ़ॉल्ट चौड़ाई और ऊँचाई के दो गुना पर रेंडर करता है, और परिणाम को PNG छवि के रूप में सहेजता है।

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

स्केल फ़ैक्टर `1` उस अक्ष को डिफ़ॉल्ट पिक्सेल आकार पर रखता है। उदाहरण हेतु, दोनों फ़ैक्टर `2` करने पर छवि की चौड़ाई और ऊँचाई लगभग दो गुना हो जाती है, जिससे चार गुना पिक्सल उत्पन्न होते हैं। बड़े फ़ैक्टर सामान्यतः ज़ूम या उच्च‑रिज़ॉल्यूशन आउटपुट के लिये तेज़ टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार भी बढ़ाते हैं। `1` से नीचे के फ़ैक्टर छोटे छवि और कम विवरण देते हैं। समान फ़ैक्टर उपयोग करने से पैराग्राफ़ का आस्पेक्ट रेशियो बना रहता है; अलग‑अलग क्षैतिज‑लंबवत फ़ैक्टर आउटपुट को स्वतंत्र रूप से स्ट्रेच करते हैं।

[IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) के साथ पूरा आकार रेंडर करना तब उपयोगी होता है जब आउटपुट को आकार की भराव, बॉर्डर या अन्य दृश्य संदर्भ शामिल करना हो। केवल पैराग्राफ़‑छवि के लिये, [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) प्रयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ़्रेम के भीतर लाइन रैपिंग को पूरी तरह निष्क्रिय कर सकता हूँ?**

हाँ। रैपिंग निष्क्रिय करने के लिये [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) को सेट करें ताकि लाइनें टेक्स्ट फ़्रेम की किनारों पर न टूटें।

**मैं किसी विशिष्ट पैराग्राफ़ की स्लाइड पर सटीक बाउंड्स कैसे प्राप्त करूँ?**

पैराग्राफ़ के बाउंडिंग रेक्टेंगल को पुनः प्राप्त करने के लिये [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) का उपयोग करें। व्यक्तिगत पोर्शन के बाउंड्री के लिये [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) प्रदान करता है।

**पैराग्राफ़ संरेखण (बायाँ, दायाँ, केंद्र या जस्टिफ़ाई) कहाँ नियंत्रित होता है?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) पैराग्राफ‑स्तर की सेटिंग है और यह पूरे पैराग्राफ़ पर लागू होती है, चाहे व्यक्तिगत पोर्शन का फ़ॉर्मेट कुछ भी हो।

प्रत्येक पंक्ति में विभिन्न फ़ॉन्ट आकार वाले पोर्शन को वर्टिकली ऐलाइन करने के लिये देखें [Align Fonts Within a Line](/slides/hi/net/text-formatting/#align-fonts-within-a-line)।

**क्या मैं पैराग्राफ़ के भाग के लिये प्रूफिंग भाषा सेट कर सकता हूँ?**

हाँ। व्यक्तिगत पोर्शन के लिये [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) सेट करें, ताकि एक पैराग्राफ़ में कई भाषाएँ उपयोग की जा सकें।