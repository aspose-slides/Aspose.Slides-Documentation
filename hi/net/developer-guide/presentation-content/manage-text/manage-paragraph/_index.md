---
title: PowerPoint टेक्स्ट पैराग्राफ़ को .NET में प्रबंधित करें
linktitle: पैराग्राफ़ प्रबंधित करें
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
- बुलट प्रबंधित करें
- पैराग्राफ़ इंडेंट
- हैंगिंग इंडेंट
- पैराग्राफ़ बुलट
- नंबर्ड सूची
- बुलेटेड सूची
- पैराग्राफ़ गुण
- HTML आयात करें
- टेक्स्ट को HTML में
- पैराग्राफ़ को HTML में
- पैराग्राफ़ को इमेज में
- टेक्स्ट को इमेज में
- पैराग्राफ़ निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ पैराग्राफ़, पोर्शन, बुलट, नंबर्ड सूचियाँ, इंडेंट, HTML सामग्री, और पैराग्राफ़ इमेज बनाना और फ़ॉर्मेट करना सीखें।"
---
## **समीक्षा**

Aspose.Slides for .NET टेक्स्ट को टेक्स्ट फ़्रेम, पैराग्राफ और पोर्शन की पदानुक्रमिक संरचना में दर्शाता है:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) शेप में टेक्स्ट कंटेनर का प्रतिनिधित्व करता है और इसके पैराग्राफ संग्रह तक पहुँच प्रदान करता है।
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) टेक्स्ट फ़्रेम में एक पैराग्राफ का प्रतिनिधित्व करता है और इसके पोर्शन और पैराग्राफ‑स्तर फ़ॉर्मेटिंग तक पहुँच प्रदान करता है।
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) पैराग्राफ के भीतर एक टेक्स्ट रन का प्रतिनिधित्व करता है। प्रत्येक पोर्शन का अपना टेक्स्ट और कैरेक्टर‑स्तर फ़ॉर्मेटिंग हो सकता है।

इस प्रकार एक पैराग्राफ विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फ़ॉर्मेटिंग वाले टेक्स्ट को कई पोर्शन का उपयोग करके रख सकता है।

## **पैराग्राफ बनाना और स्वरूपित करना**

शेप के टेक्स्ट फ़्रेम में पैराग्राफ बनाएं और व्यक्तिगत टेक्स्ट रन को स्वरूपित करने के लिए पोर्शन का उपयोग करें। यह अनुभाग दिखाता है कि प्रत्येक पैराग्राफ में कई पोर्शन को कैसे मिलाकर विभिन्न रंग, फ़ॉन्ट आकार और शैली लागू की जा सकती है।

### **कई पोर्शन के साथ पैराग्राफ बनाना**

निम्न C# उदाहरण तीन पैराग्राफ बनाता है, प्रत्येक में अपने [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/) संग्रह में तीन टेक्स्ट रन होते हैं। यह डिफ़ॉल्ट पैराग्राफ और उसकी खाली पोर्शन को पुनः उपयोग करता है, फिर शेष पैराग्राफ और पोर्शन जोड़ता है। फ़ॉर्मेटिंग [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/) के माध्यम से लागू की जाती है: प्रत्येक पैराग्राफ में पहली पोर्शन लाल, बोल्ड और 15 पॉइंट है; दूसरी नीली, इटैलिक और 18 पॉइंट है। तीसरी पोर्शन अपनी डिफ़ॉल्ट फ़ॉर्मेटिंग रखती है:

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

## **बुलटेड और नंबरड सूचियाँ बनाना**

पैराग्राफ टेक्स्ट को चिन्हों, संख्याओं या कस्टम इमेज़ के साथ सूचियों में व्यवस्थित करें। इस अनुभाग में बुलट फ़ॉर्मेटिंग, मल्टी‑लेवल सूचियों और कस्टम प्रारम्भिक संख्याओं के उदाहरण शामिल हैं।

### **बुलटेड या नंबरड सूची बनाना**

बुलट और नंबरिंग संबंधित आइटमों को स्कैन करना आसान बनाते हैं। Aspose.Slides में, सूची सेटिंग्स [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) के माध्यम से परिभाषित होती हैं।

यह C# उदाहरण समान टेक्स्ट फ़्रेम में एक प्रतीक बुलट और एक नंबरड आइटम जोड़ता है। [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) बुलट प्रकार चुनता है, जबकि [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) प्रतीक को प्रदान करता है और [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) क्रमांकन शैली चुनता है। दोनों आइटम काले बुलट के साथ 100 % ऊँचाई और 25 पॉइंट पैराग्राफ इंडेंट के साथ हैं:

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

### **चित्र बुलट का उपयोग करना**

चित्र बुलट आपको प्रतीक या संख्या के बजाय कस्टम इमेज़ उपयोग करने की अनुमति देता है।

यह C# उदाहरण प्रस्तुति की इमेज कलेक्शन में एक [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) जोड़ता है और इसे पैराग्राफ बुलट के रूप में उपयोग करता है। यह [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) को चित्र बुलट उपयोग करने के लिए सेट करता है और इमेज को [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) के माध्यम से असाइन करता है। [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) को 100 % पर सेट किया जाता है ताकि बुलट का आकार पैराग्राफ टेक्स्ट के सापेक्ष हो:

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

[IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) को सेट करके पैराग्राफ को सूची के विभिन्न स्तरों पर रख सकते हैं। शीर्ष स्तर की गहराई `0` है।

यह C# उदाहरण चार पैराग्राफ को 0 से 3 तक की [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) मान देता है, जिससे एक ही टेक्स्ट फ़्रेम में पदानुक्रम बनता है। प्रत्येक पैराग्राफ एक प्रतीक बुलट उपयोग करता है, जहाँ [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) गोल बुलट और हाइफ़न के बीच बदलता रहता है जिससे क्रमिक स्तरों में अंतर दिखे:

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

### **कस्टम मूल्यों पर नंबरड सूची आइटम शुरू करना**

[IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) का उपयोग करके नंबरड पैराग्राफ के प्रारम्भिक नंबर को सेट किया जाता है।

यह C# उदाहरण तीन पैराग्राफ के लिए [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) को नंबरिंग उपयोग करने के लिए सेट करता है और [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) के मान क्रमशः 2, 3 और 7 रखता है। प्रत्येक पैराग्राफ के लिए प्रारम्भिक मान अलग‑अलग कॉन्फ़िगर किया जाता है, जिससे प्रदर्शित संख्याएँ मानों को छोड़ सकती हैं:

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

## **पैराग्राफ लेआउट और एंड प्रॉपर्टी को नियंत्रित करना**

पैराग्राफ मार्जिन और इंडेंट को समायोजित करके पहली पंक्ति और रैप्ड लाइनों की स्थिति को नियंत्रित करें। आप पैराग्राफ एंड मार्क को दृश्यमान टेक्स्ट पोर्शन से अलग भी स्वरूपित कर सकते हैं।

### **पहली‑पंक्ति इंडेंट सेट करना**

[IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) प्रॉपर्टी का उपयोग करके पैराग्राफ की पहली‑पंक्ति इंडेंट को नियंत्रित करें। यह प्रॉपर्टी केवल पहली पंक्ति को पैराग्राफ के बाएँ मार्जिन की तुलना में ले जाती है। सकारात्मक मान पहली पंक्ति को दाएँ शिफ्ट करता है, जबकि शेष पंक्तियाँ पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

यदि आपको पूरी पैराग्राफ को ले जाना है तो [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) का उपयोग करें। यदि आपको केवल पहली पंक्ति को ले जाना है तो [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) का उपयोग करें।

निम्न उदाहरण तीन पैराग्राफ को समान [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) 20 पॉइंट और [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) मान 0, 20 और 40 पॉइंट देता है। पहली पंक्तियों का एफ़ेक्ट क्रमशः अधिक पदचिन्हों पर शुरू होता है, जबकि रैप्ड लाइनों का बायाँ मार्जिन समान रहता है:

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

![पैराग्राफ़ की पहली‑पंक्ति इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करना**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली पंक्ति शेष लाइनों से बाईं ओर शुरू होती है। Aspose.Slides में आप इसे [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) प्रॉपर्टी से बना सकते हैं। `Indent` को नकारात्मक मान पर सेट करने से पहली पंक्ति पैराग्राफ बॉडी के सापेक्ष बाएँ शिफ्ट होती है।

व्यावहारिक रूप से, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) पैराग्राफ बॉडी की बायीं स्थिति निर्धारित करता है, और [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) पहली पंक्ति की स्थिति को उस मार्जिन के सापेक्ष निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए सकारात्मक `MarginLeft` और नकारात्मक `Indent` मान सेट करें।

यह स्वरूपण ग्रंथसूचियों, संदर्भों, शब्दकोश प्रविष्टियों आदि के लिए उपयोगी है जहाँ रैप्ड लाइनों को पैराग्राफ बॉडी के नीचे संरेखित होना चाहिए, न कि पहली पंक्ति के पहले अक्षर के नीचे।

निम्न C# उदाहरण में [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) के मान 40 और 60 पॉइंट को [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) के मान -20 और -30 पॉइंट के साथ जोड़ा गया है। प्रत्येक पैराग्राफ में पहली पंक्ति रैप्ड लाइनों से बाईं ओर शुरू होती है; दूसरे पैराग्राफ में अधिक गहरा हैंगिंग इंडेंट है:

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

![पैराग्राफ़ की हैंगिंग इंडेंट](hanging_indent.png)

### **एंड पैराग्राफ़ रन प्रॉपर्टी सेट करना**

[IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) प्रॉपर्टी पैराग्राफ एंड मार्क के फ़ॉर्मेट को नियंत्रित करती है। नीचे दिया गया उदाहरण एक [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) बनाता है जिसमें [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) को 48 पॉइंट और [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) को Times New Roman पर सेट किया गया है। यह फ़ॉर्मेट दूसरे पैराग्राफ के एंड मार्क को असाइन किया जाता है, जबकि दृश्यमान टेक्स्ट पोर्शन अपरिवर्तित रहते हैं:

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

## **रेंडर की गई लाइनों की गिनती करना**

लाइन‑ब्रेकिंग और लाइन‑एंड पर विराम चिह्नों को नियंत्रित करने वाले पैराग्राफ नियमों के लिए देखें [Control Line Breaking](/slides/hi/net/text-formatting/#control-line-breaking) और [Control Hanging Punctuation](/slides/hi/net/text-formatting/#control-hanging-punctuation)।

[IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) का उपयोग करके टेक्स्ट लेआउट के बाद पैराग्राफ द्वारा ली गई लाइनों की संख्या गिनी जा सकती है, जिसमें ऑटॉमैटिक रैपिंग भी शामिल है। यह प्रस्तुति टेम्पलेट में टेक्स्ट लंबाई और लेआउट की जाँच के लिए उपयोगी है।

पैराग्राफ एक आइटम है [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/) में, और यह कई रेंडर की गई लाइनों को कवर कर सकता है। पैराग्राफ के भीतर स्पष्ट लाइन‑ब्रेक एक नई पंक्ति बनाता है बिना नया पैराग्राफ बनाए। ऑटॉमैटिक रैपिंग उपलब्ध चौड़ाई के आधार पर लाइनों को बनाता है, बिना स्पष्ट लाइन‑ब्रेक डालते। इसलिए पैराग्राफ या लाइन‑ब्रेक कैरेक्टर की गिनती रेंडर की गई लाइन‑गिनती नहीं देती।

निम्न उदाहरण एक टेक्स्ट शेप बनाता है, उसकी लाइनों की गिनती करता है, शेप को संकीर्ण करता है, फिर टेक्स्ट को छोटे स्ट्रिंग से बदलता है। उदाहरण [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) को सक्षम करता है और [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) को अक्षम करता है ताकि शेप की चौड़ाई रैपिंग को नियंत्रित करे बिना टेक्स्ट को स्वतः छोटा किए या शेप का आकार बदले। प्रत्येक माप [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) का उपयोग करता है। शेप आयाम पॉइंट में हैं। अंत में उदाहरण एक और पैराग्राफ जोड़ता है और टेक्स्ट फ़्रेम में सभी लाइन‑गिनतियों को जोड़ता है।

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

इन टेक्स्ट और आयामों के साथ, शेप को संकीर्ण करने से लाइन‑गिनती बढ़ती है, जबकि छोटे स्ट्रिंग से बदलने पर कम होती है। सटीक गिनती फ़ॉन्ट उपलब्धता, फ़ॉन्ट आकार, मार्जिन, इंडेंट, रैपिंग और ऑटो‑फ़िट सेटिंग्स के अनुसार भिन्न हो सकती है। टेम्पलेट की जाँच करते समय लक्ष्य वातावरण के लिए उपयुक्त फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

केवल लाइन‑गिनती यह निर्धारित नहीं करती कि टेक्स्ट कंटेनर को ओवरफ़्लो करता है या नहीं। उपलब्ध ऊँचाई, लाइन‑हाइट, पैराग्राफ और लाइन स्पेसिंग, तथा ऑटो‑फ़िट व्यवहार भी महत्वपूर्ण हैं; भले ही एक लाइन ही हो, यदि रैपिंग अक्षम है तो वह उपलब्ध चौड़ाई से अधिक हो सकती है।

## **पैराग्राफ सामग्री आयात और निर्यात करना**

HTML का उपयोग करके टेक्स्ट को प्रस्तुति में लाया जा सकता है या मौजूदा पैराग्राफ को बाहरी उपयोग के लिए निर्यात किया जा सकता है। यह अनुभाग दिखाता है कि कैसे व्यक्तिगत पैराग्राफ को इमेज़ के रूप में रेंडर किया जाए, जिसमें तालिका कोशिकाओं में पैराग्राफ भी शामिल हैं।

### **HTML टेक्स्ट को पैराग्राफ में आयात करना**

[ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) का उपयोग करके HTML मार्कअप को टेक्स्ट फ़्रेम में पैराग्राफ और पोर्शन में परिवर्तित किया जा सकता है।

यह C# उदाहरण फ़ाइल से HTML पढ़ता है और मार्कअप को [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) को पास करता है। यह टेक्स्ट फ़्रेम के डिफ़ॉल्ट पैराग्राफ को साफ़ करता है ताकि फ़्रेम में केवल आयातित सामग्री हो। आयताकार शेप स्लाइड के प्रत्येक किनारे पर 10‑पॉइंट मार्जिन छोड़ता है:

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

### **पैराग्राफ टेक्स्ट को HTML में निर्यात करना**

[ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात किया जा सकता है। जब प्रस्तुति टेक्स्ट को वेबसाइट पर पुनः उपयोग किया जाता है, तो आप स्थानीय जोर को फ़ॉन्ट, आकार या टेक्स्ट बॉक्स शैलियों को ले जाए बिना संरक्षित रखना चाह सकते हैं। फ़ॉर्मेटिंग इनहेरिटेंस को नियंत्रित करने के लिए [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) सेट करें।

[sample presentation](text-inheritance.pptx) को डाउनलोड करें और इसे एप्लिकेशन की कार्यशील निर्देशिका में रखें। इसकी पहली स्लाइड में एक टेक्स्ट शेप है जिसमें टेक्स्ट "Inherited text; explicit red 18pt" है। इनपुट जानबूझकर कई फ़ॉर्मेटिंग स्तरों का उपयोग करता है:

- प्रस्तुति की डिफ़ॉल्ट टेक्स्ट शैली Calibri और 28 pt आकार प्रदान करती है।
- टेक्स्ट फ़्रेम की प्रथम‑स्तर की शैली नीले टेक्स्ट और इटैलिक प्रदान करती है।
- पैराग्राफ स्पष्ट रूप से बोल्ड टेक्स्ट सेट करता है।
- दूसरा पोर्शन, "explicit red 18pt", स्पष्ट रूप से लाल टेक्स्ट और 18 pt आकार सेट करता है।

निम्न पूर्ण उदाहरण एक ही पैराग्राफ को तीन बार निर्यात करता है। यह [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) को निर्यात मेथड में पास करता है और प्रत्येक परिणाम को अलग‑अलग UTF‑8 HTML फ़ाइल में लिखता है:

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

जेनरेट किया गया HTML पहली पोर्शन, "Inherited text; ", के लिए निम्न CSS रखता है। तालिका संबंधित घोषणाओं को दिखाती है; अन्य उत्पन्न प्रॉपर्टी स्पष्टता के लिए छोड़ दी गई हैं।

| आउटपुट | पहली पोर्शन के लिए संबंधित CSS | स्वरूप |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | नीला, बोल्ड, इटैलिक टेक्स्ट 28 pt Calibri में, यदि वह फ़ॉन्ट उपलब्ध हो। |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | नीला, बोल्ड, इटैलिक टेक्स्ट; आसपास का पेज या ब्राउज़र फ़ॉन्ट परिवार और आकार प्रदान करता है। |
| `ParagraphOnly.html` | `font-weight:bold` | बोल्ड टेक्स्ट; आसपास का पेज या ब्राउज़र फ़ॉन्ट परिवार, आकार, रंग और इटैलिक शैली प्रदान करता है। |

दूसरी पोर्शन सभी तीन आउटपुट में `color:#ff0000`, `font-size:18pt` और `font-weight:bold` रखती है। यह इटैलिक `All` और `TextBox` में भी रहता है, लेकिन `ParagraphOnly` में नहीं। इनहेरिटेंस को सीमित करने से पैराग्राफ या पोर्शन को स्पष्ट रूप से असाइन किए गए फ़ॉर्मेटिंग को नहीं हटाया जाता।

फ़ाइलें समान ब्राउज़र में खोलें और तुलना करें। प्रतिबंधित मोड में छोड़ें गए CSS प्रॉपर्टी लक्ष्य पेज की शैलियों या ब्राउज़र डिफ़ॉल्ट द्वारा हल होते हैं, इसलिए अंतिम स्वरूप उपयोग की गई HTML स्थान के आधार पर बदल सकता है।

### **पैराग्राफ को इमेज़ के रूप में रेंडर करना**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) लौटाता है। आप परिणाम को फ़ाइल या स्ट्रीम में [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) के साथ सहेज सकते हैं। कंटेनिंग शेप को रेंडर करने या बिटमैप को मैन्युअल रूप से क्रॉप करने की आवश्यकता नहीं होती।

यदि पैराग्राफ नहीं मिला, मान्य रेंडर बाउंड नहीं है, या रेंडर नहीं किया जा सकता तो [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) `null` लौटा सकता है। उपयोग से पहले परिणाम जाँचें और लौटाई गई इमेज को डिस्पोज़ करें।

#### **डिफॉल्ट स्केले पर पैराग्राफ रेंडर करना**

उदाहरण एक प्रस्तुति उपयोग करता है जिसमें एक स्लाइड है और उसकी पहली शेप तीन पैराग्राफ वाली टेक्स्ट बॉक्स है।

![तीन पैराग्राफ वाली टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न उदाहरण इंडेक्स 1 पर दूसरा पैराग्राफ चुनता है और स्केल पैरामीटर के बिना [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) को कॉल करता है। यह जांचता है कि शेप में आवश्यक पैराग्राफ मौजूद है और रेंडरिंग इमेज लौटाती है, फिर [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) से PNG प्रारूप में सहेजता है। `using` घोषणा उपयोग के बाद इमेज को डिस्पोज़ कर देती है।

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

![पैराग्राफ़ इमेज़](paragraph_to_image_output.png)

#### **टेबल सेल में स्केलिंग के साथ पैराग्राफ रेंडर करना**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) ओवरलोड का उपयोग करें जो `float scaleX` और `float scaleY` पैरामीटर लेता है ताकि क्षैतिज और लंबवत स्केल फैक्टर सेट हों। निम्न उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को डिफॉल्ट चौड़ाई और ऊँचाई के दो गुणा पर रेंडर करता है, और PNG इमेज के रूप में सहेजता है।

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

स्केल फैक्टर `1` अक्ष को डिफॉल्ट पिक्सेल आकार पर रखता है। उदाहरण के लिए, दोनों फैक्टर 2 रखने से इमेज की चौड़ाई और ऊँचाई लगभग दो गुना हो जाती है, जिससे चार गुना पिक्सेल बनते हैं। बड़े फैक्टर ज़ूम या हाई‑रिज़ॉल्यूशन आउटपुट के लिए अधिक स्पष्ट टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार भी बढ़ाते हैं। `1` से नीचे के फैक्टर छोटे इमेज कम विवरण के साथ बनाते हैं। समान फैक्टर रखकर पैराग्राफ का अनुपात बनाए रखें; अलग‑अलग क्षैतिज‑लंबवत फैक्टर आउटपुट को अलग‑अलग खींचते हैं।

जब आउटपुट में शेप की फ़िल, बॉर्डर या अन्य दृश्य संदर्भ शामिल करने की आवश्यकता हो तो [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) से पूरी शेप रेंडर करना उपयोगी रहता है। केवल पैराग्राफ‑इमेज के लिए, [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) का उपयोग करें।

## **FAQ**

**क्या मैं टेक्स्ट फ़्रेम के भीतर लाइन रैपिंग को पूरी तरह बंद कर सकता हूँ?**

हां। [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) को बंद करके रैपिंग निष्क्रिय करें ताकि लाइनों का ब्रेक टेक्स्ट फ़्रेम के किनारों पर न हो।

**मैं किसी विशिष्ट पैराग्राफ की स्लाइड पर सटीक बाउंड्स कैसे प्राप्त करूँ?**

[IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) का उपयोग करके पैराग्राफ का बाउंडिंग रेक्टैंगल प्राप्त करें। [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) व्यक्तिगत पोर्शन की बाउंड्स देता है।

**पैराग्राफ एलाइन्मेंट (left, right, center, या justify) कहाँ नियंत्रित होता है?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) पैराग्राफ‑स्तर सेटिंग है और यह पूरी पैराग्राफ पर लागू होती है, चाहे व्यक्तिगत पोर्शन फ़ॉर्मेटिंग कोई भी हो।

विभिन्न फ़ॉन्ट आकारों वाले पोर्शन को प्रत्येक लाइन में वर्टिकली संरेखित करने के लिए देखें [Align Fonts Within a Line](/slides/hi/net/text-formatting/#align-fonts-within-a-line)।

**क्या मैं पैराग्राफ के भाग के लिए प्रूफिंग भाषा सेट कर सकता हूँ?**

हां। [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) को व्यक्तिगत पोर्शन के लिए सेट करें, ताकि एक पैराग्राफ में कई भाषाओं का टेक्स्ट रख सकें।