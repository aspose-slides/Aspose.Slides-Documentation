---
title: PowerPoint टेक्स्ट पैराग्राफ को .NET में प्रबंधित करें
linktitle: पैराग्राफ प्रबंधित करें
type: docs
weight: 40
url: /hi/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- टेक्स्ट जोड़ें
- पैराग्राफ जोड़ें
- टेक्स्ट प्रबंधित करें
- पैराग्राफ प्रबंधित करें
- बुलेट प्रबंधित करें
- पैराग्राफ इंडेंट
- हैंगिंग इंडेंट
- पैराग्राफ बुलेट
- नंबर्ड लिस्ट
- बुलेटेड लिस्ट
- पैराग्राफ प्रॉपर्टीज़
- HTML आयात करें
- टेक्स्ट को HTML में
- पैराग्राफ को HTML में
- पैराग्राफ को इमेज में
- टेक्स्ट को इमेज में
- पैराग्राफ निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ पैराग्राफ, पोर्शन, बुलेट, नंबर्ड लिस्ट, इंडेंट, HTML सामग्री, और पैराग्राफ इमेज कैसे बनाएं और फ़ॉर्मेट करें, सीखें।"
---
## **परिचय**

Aspose.Slides for .NET पाठ को टेक्स्ट फ्रेम, पैराग्राफ और पोर्शन की पदानुक्रम के रूप में दर्शाता है:

* [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) आकार के भीतर टेक्स्ट कंटेनर को दर्शाता है और उसके पैराग्राफ संग्रह तक पहुँच प्रदान करता है।
* [IParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/) टेक्स्ट फ्रेम में एक पैराग्राफ को दर्शाता है और उसके पोर्शन तथा पैराग्राफ‑स्तर के फ़ॉर्मेटिंग तक पहुँच प्रदान करता है।
* [IPortion](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/) पैराग्राफ के भीतर टेक्स्ट रन को दर्शाता है। प्रत्येक पोर्शन का अपना टेक्स्ट और कैरेक्टर‑स्तर का फ़ॉर्मेट हो सकता है।

एक पैराग्राफ therefore विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फ़ॉर्मेटिंग के साथ कई पोर्शन का उपयोग करके टेक्स्ट रख सकता है।

## **पैराग्राफ बनाना और फ़ॉर्मेट करना**

### **कई पोर्शन के साथ पैराग्राफ बनाना**

निम्नलिखित चरण तीन पैराग्राफ वाले एक टेक्स्ट फ्रेम को बनाते हैं, प्रत्येक में तीन पोर्शन होते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
2. उसकी इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. आकार की [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुंचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करके टेक्स्ट फ्रेम में दो अतिरिक्त [IParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक पैराग्राफ के लिए पर्याप्त [IPortion](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/) ऑब्जेक्ट जोड़ें ताकि तीन पोर्शन हो सकें। डिफ़ॉल्ट पैराग्राफ में पहले से ही एक खाली पोर्शन होता है।
7. प्रत्येक पोर्शन का टेक्स्ट सेट करें।
8. [IPortion.PortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/portionformat/) के माध्यम से कैरेक्टर‑स्तर का फ़ॉर्मेट लागू करें।
9. संशोधित प्रस्तुति को सहेजें।

यह C# उदाहरण इन चरणों को लागू करता है:

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

## **बुलेटेड और नंबर्ड लिस्ट बनाना**

### **बुलेटेड या नंबर्ड लिस्ट बनाना**

बुलेट और नंबरिंग संबंधित आइटम्स को स्कैन करना आसान बनाते हैं। Aspose.Slides में लिस्ट सेटिंग्स को [IBulletFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/) द्वारा परिभाषित किया जाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
2. उसकी इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. चयनित स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. आकार की [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुंचें।
5. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. एक सिम्बॉल बुलेट के लिए [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph/) बनाएँ।
7. [IBulletFormat.Type](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/type/) को [BulletType.Symbol](https://reference.aspose.com/slides/hi/net/aspose.slides/bullettype/) पर सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
8. पैराग्राफ का टेक्स्ट, इंडेंट, बुलेट रंग और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. दूसरा पैराग्राफ बनाकर [IBulletFormat.Type](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/type/) को [BulletType.Numbered](https://reference.aspose.com/slides/hi/net/aspose.slides/bullettype/) पर सेट करें।
11. नंबर्ड बुलेट शैली को कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
12. प्रस्तुति को सहेजें।

यह C# उदाहरण एक सिम्बॉल बुलेट और एक नंबर्ड बुलेट बनाता है:

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

### **चित्र बुलेट का उपयोग करना**

चित्र बुलेट आपको सिम्बॉल या नंबर के बजाय एक कस्टम इमेज उपयोग करने की अनुमति देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
2. उसकी इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें और उसकी [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुंचें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. बुलेट इमेज लोड करें और उसे प्रस्तुति के इमेज कलेक्शन में [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph/) बनाकर उसका टेक्स्ट सेट करें।
7. [IBulletFormat.Type](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/type/) को [BulletType.Picture](https://reference.aspose.com/slides/hi/net/aspose.slides/bullettype/) पर सेट करें।
8. [IBulletFormat.Picture](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/picture/) के माध्यम से इमेज असाइन करें और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. संशोधित प्रस्तुति को सहेजें।

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

### **बहु‑स्तरीय लिस्ट बनाना**

[IParagraphFormat.Depth](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/depth/) को सेट करके पैराग्राफ को लिस्ट के विभिन्न स्तरों पर रखा जा सकता है। शीर्ष स्तर का डेप्थ `0` होता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) बनाएँ और एक स्लाइड तक पहुंचें।
2. एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें और उसके टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को साफ़ करें।
3. चार पैराग्राफ बनाकर उनके बुलेट सिम्बॉल कॉन्फ़िगर करें।
4. उनके [IParagraphFormat.Depth](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/depth/) मान क्रमशः `0`, `1`, `2`, और `3` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रस्तुति को सहेजें।

यह C# उदाहरण चार‑स्तरीय बुलेटेड लिस्ट बनाता है:

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

### **नंबर्ड लिस्ट आइटम को कस्टम मान से शुरू करना**

[IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/numberedbulletstartwith/) का उपयोग करके नंबर्ड पैराग्राफ के प्रारंभिक नंबर को सेट किया जाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) बनाकर एक स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
2. आकार के टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
3. तीन नंबर्ड पैराग्राफ बनाएँ।
4. संबंधित पैराग्राफ के लिए [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/numberedbulletstartwith/) को क्रमशः `2`, `3`, और `7` पर सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रस्तुति को सहेजें।

यह C# उदाहरण प्रत्येक पैराग्राफ को कस्टम प्रारंभिक नंबर असाइन करता है:

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

## **पैराग्राफ लेआउट और एंड प्रॉपर्टीज़ को नियंत्रित करना**

### **पहली‑लाइन इंडेंट सेट करना**

[IParagraphFormat.Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) प्रॉपर्टी का उपयोग करके पैराग्राफ की पहली लाइन की इंडेंट को नियंत्रित किया जाता है। यह प्रॉपर्टी केवल पहली लाइन को पैराग्राफ के बाएँ मार्जिन के सापेक्ष स्थानांतरित करती है। सकारात्मक मान पहली लाइन को दाएँ शिफ्ट करता है, जबकि अन्य लाइन्स पैराग्राफ बॉडी के अनुसार संरेखित रहती हैं।

पूर्ण पैराग्राफ को स्थानांतरित करने के लिए [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/marginleft/) उपयोग करें। केवल पहली लाइन को स्थानांतरित करने के लिए [IParagraphFormat.Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) उपयोग करें।

निम्न उदाहरण कई पैराग्राफ बनाता है और विभिन्न [IParagraphFormat.Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) मान लागू करता है ताकि दिखा सके कि पहली‑लाइन इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
2. लक्ष्य स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. आकार की [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. कई पैराग्राफ बनाकर उनके लिए विभिन्न [Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रस्तुति को सहेजें।

यह कोड पैराग्राफ इंडेंट सेट करने का तरीका दर्शाता है:

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

![The first-line indent of the paragraphs](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करना**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली लाइन बाकी लाइनों से बाएँ शुरू होती है। Aspose.Slides में यह प्रभाव [IParagraphFormat.Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) प्रॉपर्टी से बनाया जाता है। `Indent` को नकारात्मक मान पर सेट करके पहली लाइन को पैराग्राफ बॉडी के सापेक्ष बाएँ ले जाया जाता है।

व्यवहार में, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/marginleft/) पैराग्राफ बॉडी की बाईं स्थिति निर्धारित करता है, और [IParagraphFormat.Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) पहली लाइन की स्थिति को उस मार्जिन के सापेक्ष परिभाषित करता है। हैंगिंग इंडेंट बनाने के लिए सकारात्मक `MarginLeft` और नकारात्मक `Indent` सेट करें।

यह फ़ॉर्मेटिंग बाइबिलियोग्राफी, रिफ़रेंसेज़, शब्दकोश प्रविष्टियों आदि में उपयोगी है जहाँ रैप्ड लाइन्स को पैराग्राफ बॉडी के अंतर्गत संरेखित होना चाहिए, न कि पहली लाइन के पहले अक्षर के नीचे।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
2. लक्ष्य स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. आकार की [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. प्रत्येक पैराग्राफ के लिए सकारात्मक [MarginLeft](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/marginleft/) मान सेट करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए नकारात्मक [Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) मान सेट करें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रस्तुति को सहेजें।

यह कोड पैराग्राफ के लिए हैंगिंग इंडेंट सेट करने का तरीका दर्शाता है:

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

![The hanging indent of the paragraphs](hanging_indent.png)

### **एंड पैराग्राफ रन प्रॉपर्टीज़ सेट करना**

[IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/endparagraphportionformat/) प्रॉपर्टी पैराग्राफ अंत चिह्न के फ़ॉर्मेट को नियंत्रित करती है। निम्न उदाहरण दूसरे पैराग्राफ के अंत चिह्न को फ़ॉन्ट आकार और लैटिन फ़ॉन्ट असाइन करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) लोड करें और एक स्लाइड तक पहुंचें।
2. एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. दो पैराग्राफ बनाकर उनमें टेक्स्ट पोर्शन जोड़ें।
4. दूसरे पैराग्राफ के अंत चिह्न के लिए एक [PortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/portionformat/) बनाएं।
5. [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/fontheight/) और [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/latinfont/) सेट करें।
6. फ़ॉर्मेट को [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/endparagraphportionformat/) को असाइन करें और प्रस्तुति को सहेजें।

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

## **रेंडर्ड लाइनों की गिनती**

पैराग्राफ नियमों के बारे में जो स्वतः रैपिंग और लाइन एंड पर विराम चिह्न को प्रभावित करते हैं, उनके लिए देखें [Control Line Breaking](/slides/hi/net/text-formatting/#control-line-breaking) और [Control Hanging Punctuation](/slides/hi/net/text-formatting/#control-hanging-punctuation)।

[IParagraph.GetLinesCount](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/getlinescount/) का उपयोग करके टेक्स्ट लेआउट के बाद पैराग्राफ द्वारा कब्जा किए गए लाइनों की गिनती की जा सकती है, जिसमें स्वतः रैपिंग भी शामिल है। यह प्रस्तुति टेम्पलेट्स में टेक्स्ट लंबाई और लेआउट जाँचने में सहायक है।

एक पैराग्राफ [ITextFrame.Paragraphs](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/paragraphs/) में एक आइटम होता है, और वह कई रेंडर्ड लाइनों को ले सकता है। पैराग्राफ के भीतर एक स्पष्ट लाइन ब्रेक नया लाइन उत्पन्न करता है लेकिन नया पैराग्राफ नहीं बनाता। स्वतः रैपिंग उपलब्ध चौड़ाई के आधार पर लाइनों को बनाता है, बिना टेक्स्ट में स्पष्ट लाइन‑ब्रेक डालें। इसलिए पैराग्राफ या लाइन‑ब्रेक कैरेक्टर गिनना रेंडर्ड लाइन गिनती नहीं देता।

निम्न उदाहरण एक टेक्स्ट शैप बनाता है, उसकी लाइनों की गिनती करता है, शैप को संकरा करता है, और फिर टेक्स्ट को छोटी स्ट्रिंग से बदलता है। रैपिंग सक्षम है और ऑटोफ़िट अक्षम है ताकि शैप की चौड़ाई रैपिंग को नियंत्रित करे, बिना टेक्स्ट को स्वतः छोटा किए या शैप को री‑साइज़ किए। शैप आयाम पॉइंट्स में हैं। अंत में उदाहरण एक और पैराग्राफ जोड़ता है और टेक्स्ट फ्रेम में लाइनों की कुल गिनती करता है।

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

इन टेक्स्ट और आयामों के साथ, शैप को संकरा करने से लाइन गिनती बढ़ जाती है, जबकि छोटा स्ट्रिंग डालने से घटती है। सटीक गिनती फ़ॉन्ट उपलब्धता, फ़ॉन्ट आकार, मार्जिन, इंडेंटेशन, रैपिंग और ऑटोफ़िट सेटिंग्स के आधार पर बदल सकती है। टेम्पलेट जाँचते समय लक्ष्य वातावरण के फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

केवल लाइन गिनती यह निर्धारित नहीं करती कि टेक्स्ट अपने कंटेनर से बाहर निकलेगा या नहीं। उपलब्ध ऊँचाई, लाइन ऊँचाई, पैराग्राफ और लाइन स्पेसिंग, तथा ऑटोफ़िट व्यवहार भी महत्त्वपूर्ण होते हैं; रैपिंग बंद होने पर एक ही लाइन उपलब्ध चौड़ाई से अधिक हो सकती है।

## **पैराग्राफ कंटेंट का आयात और निर्यात**

### **HTML टेक्स्ट को पैराग्राफ में आयात करना**

[ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraphcollection/addfromhtml/) का उपयोग करके HTML मार्कअप को टेक्स्ट फ़्रेम में पैराग्राफ और पोर्शन में परिवर्तित किया जा सकता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
2. एक स्लाइड तक पहुंचें और एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
3. आकार की [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुंचें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
4. स्रोत HTML फ़ाइल पढ़ें।
5. HTML स्ट्रिंग को [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraphcollection/addfromhtml/) को पास करें।
6. संशोधित प्रस्तुति को सहेजें।

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

### **पैराग्राफ टेक्स्ट को HTML में निर्यात करना**

[ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraphcollection/exporttohtml/) का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात किया जा सकता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) का एक इंस्टेंस बनाकर इच्छित प्रस्तुति लोड करें।
2. स्लाइड तक पहुंचें और उस [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) को खोजें जिसमें टेक्स्ट है।
3. आकार की [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुंचें।
4. प्रारंभ पैराग्राफ इंडेक्स और निर्यात करने वाले पैराग्राफों की संख्या के साथ [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraphcollection/exporttohtml/) को कॉल करें।
5. प्राप्त HTML स्ट्रिंग को फ़ाइल में लिखें।

यह C# उदाहरण पहले टेक्स्ट शैप की सभी पैराग्राफ को निर्यात करता है:

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

### **पैराग्राफ को इमेज के रूप में रेंडर करना**

[IParagraph.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/getimage/) एक व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) लौटाता है। परिणाम को [IImage.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/save/) के साथ फ़ाइल या स्ट्रीम में सहेजा जा सकता है। आपको कंटेनर शैप को रेंडर करने या बिटमैप को मैन्युअली क्रॉप करने की आवश्यकता नहीं है।

यदि पैराग्राफ को उसके पैरेंट कलेक्शन में नहीं पाया जाता, वैध रेंडर बाउंड्स नहीं होते, या रेंडर नहीं किया जा सकता तो [IParagraph.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/getimage/) `null` लौटा सकता है। सहेजने से पहले परिणाम जाँचें और उपयोग के बाद लौटाई गई इमेज को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करना**

मान लीजिए हमारे पास `sample.pptx` नाम की एक प्रस्तुति फ़ाइल है जिसमें एक स्लाइड है, और पहला शैप तीन पैराग्राफ वाला टेक्स्ट बॉक्स है।

![The text box with three paragraphs](paragraph_to_image_input.png)

निम्न उदाहरण दूसरे पैराग्राफ को सामान्य टेक्स्ट शैप में डिफ़ॉल्ट स्केल पर रेंडर करता है और परिणाम को PNG फ़ॉर्मेट में सहेजता है। `using` घोषणा सुनिश्चित करती है कि इमेज सही तरीके से डिस्पोज़ हो।

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

![The paragraph image](paragraph_to_image_output.png)

#### **टेबल सेल में स्केलिंग के साथ पैराग्राफ रेंडर करना**

[IParagraph.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/getimage/) के उस ओवरलोड का उपयोग करें जो `float scaleX` और `float scaleY` पैरामीटर लेता है, ताकि क्षैतिज और ऊर्ध्वाधर स्केल फ़ैक्टर सेट किए जा सकें। निम्न उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई के दो गुना पर रेंडर करता है, और परिणाम को PNG इमेज के रूप में सहेजता है।

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

`1` का स्केल फ़ैक्टर उस अक्ष को डिफ़ॉल्ट पिक्सेल आकार पर रखता है। उदाहरण के लिए, दोनों फ़ैक्टर के लिए `2` सेट करने से इमेज का चौड़ाई और ऊँचाई लगभग दो गुना हो जाती है, जिससे चार गुना अधिक पिक्सेल मिलते हैं। बड़े फ़ैक्टर ज़ूम या हाई‑रिज़ॉल्यूशन आउटपुट के लिए टेक्स्ट को तेज़ बनाते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार भी बढ़ाते हैं। `1` से कम फ़ैक्टर छोटी इमेज बनाते हैं जिसमें कम विवरण होता है। पैराग्राफ का पहलू अनुपात बनाए रखने के लिए समान फ़ैक्टर उपयोग करें; अलग‑अलग क्षैतिज और ऊर्ध्वाधर फ़ैक्टर आउटपुट को स्वतंत्र रूप से स्ट्रेच करेंगे।

पूरा शैप रेंडर करने के लिए [IShape.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/getimage/) उपयोगी रहता है जब आउटपुट को शैप की फ़िल, बॉर्डर या अन्य दृश्य संदर्भ शामिल करना हो। केवल पैराग्राफ‑इमेज के लिए [IParagraph.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/getimage/) उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन रैपिंग को पूरी तरह निष्क्रिय कर सकता हूँ?**

हां। [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/wraptext/) को `false` सेट करने से रैपिंग निष्क्रिय हो जाती है और लाइन्स टेक्स्ट फ्रेम के किनारों पर नहीं टूटतीं।

**मैं किसी विशिष्ट पैराग्राफ की स्लाइड पर सटीक बॉन्ड्स कैसे प्राप्त करूँ?**

[IParagraph.GetRect](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/getrect/) का उपयोग करके पैराग्राफ का बाउंडिंग रेक्टेंगल प्राप्त करें। व्यक्तिगत पोर्शन के बॉन्ड्स के लिए [IPortion.GetRect](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/getrect/) उपयोग करें।

**पैराग्राफ अलाइनमेंट (बाएँ, दाएँ, केंद्र या जस्टिफ़ाइ) कहाँ नियंत्रित होता है?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/alignment/) एक पैराग्राफ‑स्तर की सेटिंग है और यह पूरे पैराग्राफ पर लागू होती है, चाहे व्यक्तिगत पोर्शन का फ़ॉर्मेट कुछ भी हो।

**क्या मैं पैराग्राफ के किसी भाग के लिए प्रूफ़िंग लैंग्वेज सेट कर सकता हूँ?**

हां। व्यक्तिगत पोर्शन के लिए [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/languageid/) सेट करें, जिससे एक पैराग्राफ में कई भाषाएँ हो सकती हैं।