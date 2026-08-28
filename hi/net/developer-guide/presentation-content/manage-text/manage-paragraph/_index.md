---
title: .NET में PowerPoint टेक्स्ट पैराग्राफ को प्रबंधित करें
linktitle: पैराग्राफ प्रबंधित करें
type: docs
weight: 40
url: /hi/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- पाठ जोड़ें
- पैराग्राफ जोड़ें
- पाठ प्रबंधित करें
- पैराग्राफ प्रबंधित करें
- बुलेट प्रबंधित करें
- पैराग्राफ इंडेंट
- हैंगिंग इंडेंट
- पैराग्राफ बुलेट
- क्रमांकित सूची
- बुलेट वाली सूची
- पैराग्राफ गुण
- HTML आयात
- टेक्स्ट को HTML में
- पैराग्राफ को HTML में
- पैराग्राफ को इमेज में
- टेक्स्ट को इमेज में
- पैराग्राफ निर्यात
- PowerPoint
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ पैराग्राफ, भाग, बुलेट, क्रमांकित सूचियाँ, इंडेंट, HTML सामग्री, और पैराग्राफ इमेज बनाना और फ़ॉर्मेट करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for .NET टेक्स्ट को टेक्स्ट फ़्रेम, पैराग्राफ और भागों की पदानुक्रम में प्रस्तुत करता है:

* [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) एक शेप में टेक्स्ट कंटेनर को दर्शाता है और उसके पैराग्राफ संग्रह तक पहुँच प्रदान करता है।
* [IParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/) एक टेक्स्ट फ़्रेम में एक पैराग्राफ का प्रतिनिधित्व करता है और उसके भागों तथा पैराग्राफ‑स्तर फ़ॉर्मेटिंग तक पहुँच प्रदान करता है।
* [IPortion](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/) एक पैराग्राफ के भीतर टेक्स्ट रन को दर्शाता है। प्रत्येक भाग का अपना टेक्स्ट और अक्षर‑स्तर फ़ॉर्मेटिंग हो सकता है।

इसलिए एक पैराग्राफ कई भागों का उपयोग करके विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फ़ॉर्मेटिंग वाला टेक्स्ट रख सकता है।

## **पैराग्राफ बनाएं और फ़ॉर्मेट करें**

### **एकाधिक भागों के साथ पैराग्राफ बनाएं**

निम्न चरण एक टेक्स्ट फ़्रेम बनाते हैं जिसमें तीन पैराग्राफ होते हैं, प्रत्येक में तीन भाग होते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. शेप के [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुँचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करें और टेक्स्ट फ़्रेम में दो और [IParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक पैराग्राफ के लिए पर्याप्त [IPortion](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/) ऑब्जेक्ट जोड़ें ताकि तीन भाग हो सकें। डिफ़ॉल्ट पैराग्राफ में पहले से एक खाली भाग शामिल है।
7. प्रत्येक भाग का टेक्स्ट सेट करें।
8. [IPortion.PortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/portionformat/) के माध्यम से अक्षर‑स्तर फ़ॉर्मेटिंग लागू करें।
9. संशोधित प्रस्तुति सहेजें।

यह C# उदाहरण चरणों को लागू करता है:

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

## **बुलेटेड और क्रमांकित सूचियां बनाएं**

### **बुलेटेड या क्रमांकित सूची बनाएं**

बुलेट और क्रमांक संबंधित आइटम को जल्दी स्कैन करने में मदद करते हैं। Aspose.Slides में, सूची सेटिंग्स [IBulletFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/) के माध्यम से परिभाषित होती हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. चुनी गई स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. शेप के [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुँचें।
5. टेक्स्ट फ़्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
6. एक प्रतीक बुलेट के लिए एक [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph/) बनाएं।
7. [IBulletFormat.Type](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/type/) को [BulletType.Symbol](https://reference.aspose.com/slides/hi/net/aspose.slides/bullettype/) सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
8. पैराग्राफ टेक्स्ट, इंडेंट, बुलेट रंग और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
10. दूसरा पैराग्राफ बनाकर [IBulletFormat.Type](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/type/) को [BulletType.Numbered](https://reference.aspose.com/slides/hi/net/aspose.slides/bullettype/) सेट करें।
11. क्रमांकित बुलेट शैली को कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
12. प्रस्तुति सहेजें।

यह C# उदाहरण एक प्रतीक बुलेट और एक क्रमांकित बुलेट बनाता है:

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

### **चित्र बुलेट उपयोग करें**

चित्र बुलेट आपको प्रतीक या संख्या की बजाय एक कस्टम छवि उपयोग करने की अनुमति देते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें और उसके [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुँचें।
4. टेक्स्ट फ़्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. बुलेट छवि लोड करें और उसे प्रस्तुति की इमेज कलेक्शन में एक [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph/) बनाकर उसका टेक्स्ट सेट करें।
7. [IBulletFormat.Type](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/type/) को [BulletType.Picture](https://reference.aspose.com/slides/hi/net/aspose.slides/bullettype/) सेट करें।
8. [IBulletFormat.Picture](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/picture/) के माध्यम से छवि असाइन करें और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
10. संशोधित प्रस्तुति सहेजें।

यह C# उदाहरण एक चित्र बुलेट बनाता है:

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

### **बहु‑स्तरीय सूची बनाएं**

[IParagraphFormat.Depth](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/depth/) सेट करके पैराग्राफ को सूची के विभिन्न स्तरों पर रखा जा सकता है। शीर्ष स्तर की गहरायी `0` होती है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) बनाकर एक स्लाइड तक पहुँचें।
2. एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें और उसके टेक्स्ट फ़्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
3. चार पैराग्राफ बनाकर उनके बुलेट प्रतीकों को कॉन्फ़िगर करें।
4. उनके [IParagraphFormat.Depth](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/depth/) मान क्रमशः `0`, `1`, `2` और `3` सेट करें।
5. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें और प्रस्तुति सहेजें।

यह C# उदाहरण चार‑स्तरीय बुलेटेड सूची बनाता है:

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

### **कस्टम मानों से क्रमांकित सूची आइटम शुरू करें**

[IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/numberedbulletstartwith/) का उपयोग करके क्रमांकित पैराग्राफ के प्रारम्भिक नंबर को सेट किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) बनाकर एक स्लाइड में [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
2. शेप के टेक्स्ट फ़्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
3. तीन क्रमांकित पैराग्राफ बनाएं।
4. प्रत्येक पैराग्राफ के लिए [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/numberedbulletstartwith/) को क्रमशः `2`, `3` और `7` सेट करें।
5. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें और प्रस्तुति सहेजें।

यह C# उदाहरण प्रत्येक पैराग्राफ को एक कस्टम प्रारम्भिक संख्या असाइन करता है:

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

## **पैराग्राफ लेआउट और एंड प्रॉपर्टी नियंत्रण करें**

### **पहली‑लाइन इंडेंट सेट करें**

[IParagraphFormat.Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) प्रॉपर्टी का उपयोग पैराग्राफ की पहली लाइन के इंडेंट को नियंत्रित करने के लिए किया जाता है। यह प्रॉपर्टी केवल पहली लाइन को पैराग्राफ की बाएं मार्जिन के सापेक्ष स्थानांतरित करती है। सकारात्मक मान पहली लाइन को दाईं ओर शिफ्ट करता है, जबकि शेष लाइनों को पैराग्राफ बॉडी के साथ संरेखित रखता है।

यदि आपको पूरा पैराग्राफ स्थानांतरित करना हो तो [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/marginleft/) उपयोग करें। केवल पहली लाइन को स्थानांतरित करने के लिए [IParagraphFormat.Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) उपयोग करें।

निचे दिया गया उदाहरण कई पैराग्राफ बनाता है और विभिन्न [IParagraphFormat.Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) मान लागू करता है ताकि दिखाया जा सके कि पहली‑लाइन इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. शेप के [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. कई पैराग्राफ बनाकर उनके लिए विभिन्न [Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
7. संशोधित प्रस्तुति सहेजें।

यह कोड दर्शाता है कि कैसे पैराग्राफ इंडेंट सेट किया जाता है:

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

![पैराग्राफ की प्रथम‑लाइन इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली लाइन शेष लाइनों के बाईं ओर शुरू होती है। Aspose.Slides में, यह प्रभाव [IParagraphFormat.Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) प्रॉपर्टी से बनाया जाता है। `Indent` को नकारात्मक मान देकर पहली लाइन को पैराग्राफ बॉडी के सापेक्ष बाईं ओर ले जाएँ।

वास्तव में, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/marginleft/) पैराग्राफ बॉडी की बाईं स्थिति निर्धारित करता है, और [IParagraphFormat.Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) पहली लाइन की स्थिति को उस मार्जिन के सापेक्ष निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए एक सकारात्मक `MarginLeft` मान और नकारात्मक `Indent` मान सेट करें।

यह फ़ॉर्मेटिंग बिब्लियोग्राफ़ी, रेफरेंसेज़, शब्दकोश प्रविष्टियों आदि के लिए उपयोगी है जहाँ रैप्ड लाइनों को पैराग्राफ बॉडी के नीचे संरेखित होना चाहिए, न कि पहली लाइन के पहले अक्षर के नीचे।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. शेप के [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. प्रत्येक पैराग्राफ के लिए एक सकारात्मक [MarginLeft](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/marginleft/) मान बनाएं।
6. हैंगिंग इंडेंट प्रभाव के लिये नकारात्मक [Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) मान सेट करें।
7. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
8. संशोधित प्रस्तुति सहेजें।

यह कोड दर्शाता है कि कैसे पैराग्राफ के लिये हैंगिंग इंडेंट सेट किया जाता है:

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

![पैराग्राफ का हैंगिंग इंडेंट](hanging_indent.png)

### **एंड पैराग्राफ रन प्रॉपर्टीज़ सेट करें**

[IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/endparagraphportionformat/) प्रॉपर्टी पैराग्राफ अंत चिह्न के फ़ॉर्मेट को नियंत्रित करती है। निम्न उदाहरण दूसरे पैराग्राफ के अंत चिह्न के लिये फ़ॉन्ट आकार और लैटिन फ़ॉन्ट असाइन करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) लोड करें और एक स्लाइड तक पहुँचें।
2. एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. दो पैराग्राफ बनाकर उनमें टेक्स्ट भाग जोड़ें।
4. दूसरे पैराग्राफ के अंत चिह्न के लिये एक [PortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/portionformat/) बनाएं।
5. [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/fontheight/) और [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/latinfont/) सेट करें।
6. फ़ॉर्मेट को [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/endparagraphportionformat/) पर लागू करें और प्रस्तुति सहेजें।

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

## **पैराग्राफ कंटेंट आयात और निर्यात करें**

### **HTML टेक्स्ट को पैराग्राफ में आयात करें**

[ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraphcollection/addfromhtml/) का उपयोग करके HTML मार्कअप को टेक्स्ट फ़्रेम में पैराग्राफ और भागों में परिवर्तित किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का इंस्टेंस बनाएं।
2. एक स्लाइड तक पहुँचें और एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
3. शेप के [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुँचें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
4. स्रोत HTML फ़ाइल पढ़ें।
5. HTML स्ट्रिंग को [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraphcollection/addfromhtml/) को पास करें।
6. संशोधित प्रस्तुति सहेजें।

यह C# उदाहरण HTML को टेक्स्ट फ़्रेम में आयात करता है:

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

### **पैराग्राफ टेक्स्ट को HTML में निर्यात करें**

[ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraphcollection/exporttohtml/) का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का इंस्टेंस बनाकर वांछित प्रस्तुति लोड करें।
2. स्लाइड तक पहुँचें और वह [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) खोजें जिसमें टेक्स्ट है।
3. शेप के [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुँचें।
4. प्रारंभिक पैराग्राफ इंडेक्स और निर्यात करने वाले पैराग्राफों की संख्या के साथ [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraphcollection/exporttohtml/) को कॉल करें।
5. लौटाई गई HTML स्ट्रिंग को फ़ाइल में लिखें।

यह C# उदाहरण पहले टेक्स्ट शेप से सभी पैराग्राफ निर्यात करता है:

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **पैराग्राफ को इमेज के रूप में रेंडर करें**

[IParagraph.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/getimage/) एकल पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) लौटाता है। परिणाम को [IImage.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/save/) के साथ फ़ाइल या स्ट्रीम में सहेजा जा सकता है। आपको कंटेनिंग शेप को रेंडर करने या बिटमैप को मैन्युअल रूप से क्रॉप करने की आवश्यकता नहीं है।

[IParagraph.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/getimage/) `null` भी लौटा सकता है यदि पैराग्राफ पैरेंट कलेक्शन में नहीं मिला, वैध रेंडरिंग बाउंड्री नहीं है, या रेंडर नहीं किया जा सकता। सहेजने से पहले परिणाम की जाँच करें और उपयोग के बाद लौटाई गई इमेज को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करें**

मान लें कि हमारे पास `sample.pptx` नामक एक प्रस्तुति फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला शेप तीन पैराग्राफ वाला टेक्स्ट बॉक्स है।

![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न उदाहरण दूसरे पैराग्राफ को नियमित टेक्स्ट शेप में डिफ़ॉल्ट स्केल पर रेंडर करता है और PNG फ़ॉर्मेट में इमेज सहेजता है। `using` डिस्पोज़ल सुनिश्चित करता है कि इमेज सही ढंग से डिस्पोज़ हो।

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

![पैराग्राफ इमेज](paragraph_to_image_output.png)

#### **टेबल सेल में स्केलिंग के साथ पैराग्राफ रेंडर करें**

[IParagraph.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/getimage/) के उस ओवरलोड का उपयोग करें जो `float scaleX` और `float scaleY` पैरामीटर लेता है ताकि क्षैतिज और ऊर्ध्वाधर स्केल फैक्टर सेट किए जा सकें। निम्न उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई के दो गुना स्केल पर रेंडर करता है, और PNG इमेज के रूप में सहेजता है।

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

`1` का स्केल फैक्टर मान मूल पिक्सेल आकार को बनाए रखता है। उदाहरण के लिये, दोनों फ़ैक्टर `2` सेट करने से इमेज की चौड़ाई और ऊँचाई लगभग दो गुना हो जाती है, जिससे चार गुना पिक्सेल बनते हैं। बड़े फ़ैक्टर जूम या हाई‑रेज़ोल्यूशन आउटपुट के लिये अधिक तेज़ टेक्स्ट देते हैं, परंतु मेमोरी उपयोग और फ़ाइल आकार बढ़ाते हैं। `1` से कम फ़ैक्टर छोटे इमेज कम विवरण के साथ बनाते हैं। समान फ़ैक्टर रख कर पैराग्राफ का आस्पेक्ट रेशियो बनाये रखें; अलग‑अलग क्षैतिज‑ऊर्ध्वाधर फ़ैक्टर आउटपुट को स्वतंत्र रूप से स्ट्रेच करेंगे।

पूरा शेप रेंडर करने के लिये [IShape.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/getimage/) उपयोगी है जब आउटपुट में शेप का फ़िल, बॉर्डर या अन्य दृश्य संदर्भ शामिल होना चाहिए। केवल पैराग्राफ‑केवल इमेज के लिये [IParagraph.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/getimage/) उपयोग करें।

## **FAQ**

**क्या मैं टेक्स्ट फ़्रेम के अंदर लाइन रैपिंग को पूरी तरह निष्क्रिय कर सकता हूँ?**

हाँ। रैपिंग निष्क्रिय करने के लिये [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/wraptext/) को सेट करें ताकि लाइन्स फ़्रेम के किनारों पर न टूटें।

**मैं किसी विशिष्ट पैराग्राफ की स्लाइड पर सटीक सीमाएँ कैसे प्राप्त करूँ?**

पैराग्राफ की बॉन्डिंग रेक्टेंगल प्राप्त करने हेतु [IParagraph.GetRect](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/getrect/) का उपयोग करें। किसी व्यक्तिगत भाग की सीमाएँ प्राप्त करने के लिये [IPortion.GetRect](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/getrect/) उपयोग करें।

**पैराग्राफ एलाइनमेंट (बाएँ, दाएँ, मध्य या जस्टिफ़ाइ) कहाँ नियंत्रित होता है?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/alignment/) एक पैराग्राफ‑स्तर सेटिंग है और यह पूरे पैराग्राफ पर लागू होता है, चाहे व्यक्तिगत भागों का फ़ॉर्मेट कुछ भी हो।

**क्या मैं पैराग्राफ के कुछ भागों के लिये प्रूफिंग भाषा सेट कर सकता हूँ?**

हाँ। व्यक्तिगत भागों के लिये [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/languageid/) सेट करें, जिससे एक ही पैराग्राफ में कई भाषाओं का टेक्स्ट हो सकता है।