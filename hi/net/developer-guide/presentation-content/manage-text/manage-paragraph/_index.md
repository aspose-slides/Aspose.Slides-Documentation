---
title: ".NET में PowerPoint टेक्स्ट पैराग्राफ प्रबंधित करें"
linktitle: "पैराग्राफ प्रबंधित करें"
type: docs
weight: 40
url: /hi/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- "टेक्स्ट जोड़ें"
- "पैराग्राफ जोड़ें"
- "टेक्स्ट प्रबंधित करें"
- "पैराग्राफ प्रबंधित करें"
- "बुल्लेट प्रबंधित करें"
- "पैराग्राफ इंडेंट"
- "हैंगिंग इंडेंट"
- "पैराग्राफ बुल्लेट"
- "नंबरित सूची"
- "बुलेटेड सूची"
- "पैराग्राफ गुण"
- "HTML आयात करें"
- "टेक्स्ट को HTML में"
- "पैराग्राफ को HTML में"
- "पैराग्राफ को इमेज में"
- "टेक्स्ट को इमेज में"
- "पैराग्राफ निर्यात करें"
- "PowerPoint"
- "प्रेजेंटेशन"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET के साथ पैराग्राफ, पोर्शन, बुल्लेट, नंबरित सूचियों, इंडेंट, HTML सामग्री, और पैराग्राफ इमेज कैसे बनाएं और स्वरूपित करें, यह सीखें."
---
## **अवलोकन**

Aspose.Slides for .NET पाठ को टेक्स्ट फ्रेम, पैराग्राफ और पोर्शन के पदानुक्रम के रूप में प्रस्तुत करता है:

* [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) shape में टेक्स्ट कंटेनर को दर्शाता है और इसके पैराग्राफ संग्रह तक पहुँच प्रदान करता है।
* [IParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/) टेक्स्ट फ्रेम में एक पैराग्राफ को दर्शाता है और इसके पोर्शन तथा पैराग्राफ-स्तर फ़ॉर्मेटिंग तक पहुँच प्रदान करता है।
* [IPortion](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/) पैराग्राफ के भीतर एक टेक्स्ट रन को दर्शाता है। प्रत्येक पोर्शन अपना टेक्स्ट और कैरेक्टर-स्तर फ़ॉर्मेटिंग रख सकता है।

इसलिए एक पैराग्राफ कई पोर्शन का उपयोग करके विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फ़ॉर्मेटिंग वाला टेक्स्ट रख सकता है।

## **पैराग्राफ बनाना और स्वरूपित करना**

### **एकाधिक पोर्शन के साथ पैराग्राफ बनाना**

निम्नलिखित चरण एक टेक्स्ट फ्रेम बनाते हैं जिसमें तीन पैराग्राफ होते हैं, प्रत्येक में तीन पोर्शन होते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. शेप के [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुँचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करें और टेक्स्ट फ्रेम में दो अतिरिक्त [IParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक पैराग्राफ में तीन पोर्शन रखने के लिए पर्याप्त [IPortion](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/) ऑब्जेक्ट जोड़ें। डिफ़ॉल्ट पैराग्राफ में पहले से ही एक खाली पोर्शन है।
7. प्रत्येक पोर्शन का टेक्स्ट सेट करें।
8. [IPortion.PortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/portionformat/) के माध्यम से कैरेक्टर-स्तर फ़ॉर्मेटिंग लागू करें।
9. परिवर्तित प्रस्तुति को सहेजें।

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

## **बुल्लेटेड और नंबरित सूचियाँ बनाना**

### **बुल्लेटेड या नंबरित सूची बनाना**

बुल्लेट और नंबरिंग संबंधित आइटम को स्कैन करना आसान बनाते हैं। Aspose.Slides में, सूची सेटिंग्स IBulletFormat के द्वारा परिभाषित की जाती हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का संदर्भ प्राप्त करें।
3. चयनित स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. शेप के [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुँचें।
5. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
6. एक सिम्बॉल बुल्लेट के लिए [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph/) बनाएं।
7. IBulletFormat.Type को [BulletType.Symbol](https://reference.aspose.com/slides/hi/net/aspose.slides/bullettype/) पर सेट करें और बुल्लेट अक्षर निर्दिष्ट करें।
8. पैराग्राफ टेक्स्ट, इंडेंट, बुल्लेट रंग और बुल्लेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. दूसरा पैराग्राफ बनाएं और IBulletFormat.Type को [BulletType.Numbered](https://reference.aspose.com/slides/hi/net/aspose.slides/bullettype/) पर सेट करें।
11. नंबरित बुल्लेट शैली को कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
12. प्रस्तुति को सहेजें।

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

### **चित्र बुल्लेट का उपयोग करें**

चित्र बुल्लेट आपको सिम्बॉल या नंबर की जगह कस्टम छवि उपयोग करने की अनुमति देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का संदर्भ प्राप्त करें।
3. एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें और उसके [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुँचें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. बुल्लेट छवि लोड करें और उसे प्रस्तुति की इमेज कलेक्शन में [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph/) बनाएं और उसका टेक्स्ट सेट करें।
7. IBulletFormat.Type को [BulletType.Picture](https://reference.aspose.com/slides/hi/net/aspose.slides/bullettype/) पर सेट करें।
8. IBulletFormat.Picture के माध्यम से छवि असाइन करें और बुल्लेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. परिवर्तित प्रस्तुति को सहेजें।

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

### **बहु-स्तरीय सूची बनाना**

[IParagraphFormat.Depth] सेट करें जिससे पैराग्राफ एक सूची के विभिन्न स्तरों पर रखे जा सकें। सर्वोच्च स्तर की गहराई `0` है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) बनाएं और स्लाइड तक पहुँचें।
2. एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें और उसके टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. चार पैराग्राफ बनाएं और उनके बुल्लेट सिंबल कॉन्फ़िगर करें।
4. उनके [IParagraphFormat.Depth](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/depth/) मान क्रमशः `0`, `1`, `2` और `3` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रस्तुति सहेजें।

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

IBulletFormat.NumberedBulletStartWith का उपयोग करके नंबरित पैराग्राफ के प्रारंभिक संख्या सेट करें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) बनाएं और एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) को स्लाइड में जोड़ें।
2. शेप के टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. तीन नंबरित पैराग्राफ बनाएं।
4. प्रत्येक पैराग्राफ के लिए IBulletFormat.NumberedBulletStartWith को क्रमशः `2`, `3` और `7` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रस्तुति सहेजें।

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

## **पैराग्राफ लेआउट और अंत गुणों को नियंत्रित करना**

### **पहले-पंक्ति इंडेंट सेट करें**

IParagraphFormat.Indent प्रॉपर्टी का उपयोग करके पैराग्राफ की पहली पंक्ति का इंडेंट नियंत्रित करें। यह प्रॉपर्टी केवल पहले पंक्ति को पैराग्राफ के बाएँ मार्जिन के सापेक्ष ले जाती है। सकारात्मक मान पहली पंक्ति को दाएँ खिसकाता है, जबकि बाकी पंक्तियाँ पैराग्राफ बॉडी के अनुसार रहती हैं।

पूरे पैराग्राफ को ले जाने के लिए IParagraphFormat.MarginLeft का उपयोग करें। केवल पहली पंक्ति को ले जाने के लिए IParagraphFormat.Indent का उपयोग करें।

नीचे का उदाहरण कई पैराग्राफ बनाता है और विभिन्न IParagraphFormat.Indent मान लागू करता है, यह दर्शाने के लिए कि पहले-पंक्ति इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. लक्ष्य स्लाइड तक पहुँचेँ।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. शेप के [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. कई पैराग्राफ बनाएं और उनके लिए विभिन्न Indent मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. परिवर्तित प्रस्तुति को सहेजें।

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

The result:

![The first-line indent of the paragraphs](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली पंक्ति शेष पंक्तियों से बाएँ शुरू होती है। Aspose.Slides में, आप यह प्रभाव IParagraphFormat.Indent प्रॉपर्टी से बनाते हैं। पहली पंक्ति को पैराग्राफ बॉडी के सापेक्ष बाएँ ले जाने के लिए Indent को नकारात्मक मान पर सेट करें।

व्यावहारिक रूप से, IParagraphFormat.MarginLeft पैराग्राफ बॉडी की बायीं स्थिति निर्धारित करता है, और IParagraphFormat.Indent उस मार्जिन के सापेक्ष पहली पंक्ति की स्थिति निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए, एक सकारात्मक MarginLeft मान और नकारात्मक Indent मान सेट करें।

यह फ़ॉर्मेटिंग ग्रंथसूची, संदर्भ, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ़ों के लिए उपयोगी है जहाँ लिपटे हुए पंक्तियों को पैराग्राफ बॉडी के अंतर्गत संरेखित करना आवश्यक होता है, न कि पहली पंक्ति के पहले अक्षर के अंतर्गत।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. लक्ष्य स्लाइड तक पहुँचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. शेप के [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. पैराग्राफ बनाएं और प्रत्येक पैराग्राफ के लिए एक सकारात्मक MarginLeft मान सेट करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए एक नकारात्मक Indent मान सेट करें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. परिवर्तित प्रस्तुति को सहेजें।

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

The result:

![The hanging indent of the paragraphs](hanging_indent.png)

### **अंत पैराग्राफ रन गुण सेट करें**

[IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/endparagraphportionformat/) प्रॉपर्टी पैराग्राफ अंत चिन्ह के फ़ॉर्मेट को नियंत्रित करती है। निम्न उदाहरण दूसरे पैराग्राफ के अंत चिन्ह को फ़ॉन्ट आकार और लैटिन फ़ॉन्ट असाइन करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) लोड करें और स्लाइड तक पहुँचें।
2. IAutoShape जोड़ें और उसके डिफ़ॉल्ट पैराग्राफ को साफ़ करें।
3. दो पैराग्राफ बनाएं और उनमें टेक्स्ट पोर्शन जोड़ें।
4. दूसरे पैराग्राफ के अंत चिन्ह के लिए [PortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/portionformat/) बनाएं।
5. IBasePortionFormat.FontHeight और IBasePortionFormat.LatinFont सेट करें।
6. फ़ॉर्मेट को IParagraph.EndParagraphPortionFormat को असाइन करें और प्रस्तुति सहेजें।

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

## **रेंडर की गई लाइनों की गिनती**

एक पैराग्राफ द्वारा टेक्स्ट लेआउट के बाद घेर ली गई लाइनों की संख्या गिनने के लिए IParagraph.GetLinesCount का उपयोग करें, जिसमें स्वतः रैपिंग भी शामिल है। यह प्रस्तुतियों के टेम्पलेट में टेक्स्ट की लंबाई और लेआउट जाँचने में उपयोगी है।

एक पैराग्राफ ITextFrame.Paragraphs में एक आइटम है, और यह कई रेंडर लाइनों को घेर सकता है। पैराग्राफ के भीतर स्पष्ट लाइन ब्रेक नई लाइन बनाता है बिना नया पैराग्राफ बनाए। स्वतः रैपिंग उपलब्ध चौड़ाई के आधार पर लाइनों को बनाता है बिना टेक्स्ट में स्पष्ट लाइन ब्रेक डाले। इसलिए पैराग्राफ या लाइन-ब्रेक अक्षरों को गिनना रेंडर लाइनों की गिनती नहीं देता।

निम्न उदाहरण एक टेक्स्ट शेप बनाता है, उसकी लाइनों की गिनती करता है, शेप को संकुचित करता है, और फिर टेक्स्ट को छोटा स्ट्रिंग से बदलता है। रैपिंग सक्षम है और ऑटोफिट अक्षम है ताकि शेप की चौड़ाई रैपिंग को नियंत्रित करे बिना टेक्स्ट को स्वतः छोटा किए या शेप को री-साइज़ किए। शेप आयाम पॉइंट में हैं। अंत में, उदाहरण एक और पैराग्राफ जोड़ता है और टेक्स्ट फ्रेम में सभी लाइन गिनती को जोड़ता है।

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

इस टेक्स्ट और इन आयामों के साथ, शेप को संकुचित करने से लाइन गिनती बढ़ती है, जबकि छोटे स्ट्रिंग से बदलने से कम होती है। सटीक गिनती फ़ॉन्ट उपलब्धता, प्रतिस्थापन, फ़ॉन्ट आकार, मार्जिन, इंडेंट, रैपिंग और ऑटोफिट सेटिंग्स पर निर्भर करती है। टेम्पलेट जाँचते समय लक्ष्य वातावरण के लिए इच्छित फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

केवल लाइन गिनती यह निर्धारित नहीं करती कि टेक्स्ट कंटेनर से बाहर निकलता है या नहीं। उपलब्ध ऊँचाई, लाइन ऊँचाई, पैराग्राफ और लाइन स्पेसिंग, और ऑटोफिट व्यवहार भी महत्वपूर्ण हैं; यहां तक कि एक ही लाइन भी उपलब्ध चौड़ाई से अधिक हो सकती है जब रैपिंग अक्षम हो।

## **पैराग्राफ सामग्री का आयात और निर्यात**

### **HTML टेक्स्ट को पैराग्राफ में आयात करना**

ParagraphCollection.AddFromHtml का उपयोग करके HTML मार्कअप को टेक्स्ट फ्रेम में पैराग्राफ और पोर्शन में परिवर्तित करें।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. एक स्लाइड तक पहुँचें और IAutoShape जोड़ें।
3. शेप के [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुँचें और डिफ़ॉल्ट पैराग्राफ साफ़ करें।
4. स्रोत HTML फ़ाइल पढ़ें।
5. HTML स्ट्रिंग को ParagraphCollection.AddFromHtml में पास करें।
6. परिवर्तित प्रस्तुति को सहेजें।

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

ParagraphCollection.ExportToHtml का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात करें।

1. Presentation क्लास का एक उदाहरण बनाएं और इच्छित प्रस्तुति लोड करें।
2. स्लाइड तक पहुँचें और वह IAutoShape खोजें जिसमें टेक्स्ट हो।
3. शेप के [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुँचें।
4. ParagraphCollection.ExportToHtml को शुरूआती पैराग्राफ इंडेक्स और निर्यात करने वाले पैराग्राफ की संख्या के साथ कॉल करें।
5. वापसी में मिले HTML स्ट्रिंग को फ़ाइल में लिखें।

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

### **पैराग्राफ को छवि के रूप में रेंडर करना**

[IParagraph.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/getimage/) व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) लौटाता है। परिणाम को [IImage.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/save/) के साथ फ़ाइल या स्ट्रीम में सहेजें। आपको शेप को रेंडर करने या बिटमैप को मैन्युअली क्रॉप करने की आवश्यकता नहीं है।

[IParagraph.GetImage] `null` लौट सकता है यदि पैराग्राफ नहीं मिला, वैध रेंडर बाउंड नहीं है, या रेंडर नहीं किया जा सकता। सहेजने से पहले परिणाम जांचें और उपयोग के बाद लौटाए गए इमेज को डिस्पोज़ करें।

#### **डिफॉल्ट स्केल पर पैराग्राफ रेंडर करना**

मान लीजिए हमारे पास sample.pptx नामक एक प्रस्तुति फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला शेप तीन पैराग्राफ वाला टेक्स्ट बॉक्स है।

![The text box with three paragraphs](paragraph_to_image_input.png)

निम्न उदाहरण दूसरे पैराग्राफ को एक सामान्य टेक्स्ट शेप में डिफॉल्ट स्केल पर रेंडर करता है और परिणामस्वरूप PNG फ़ॉर्मेट में इमेज सहेजता है। `using` घोषणा सुनिश्चित करती है कि इमेज सही तरीके से डिस्पोज़ हो।

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

The result:

![The paragraph image](paragraph_to_image_output.png)

#### **टेबल सेल में स्केलिंग के साथ पैराग्राफ रेंडर करना**

ऐसे `float scaleX` और `float scaleY` पैरामीटर स्वीकार करने वाले IParagraph.GetImage ओवरलोड का उपयोग करें ताकि क्षैतिज और ऊर्ध्वाधर स्केल फ़ैक्टर सेट कर सकें। निम्न उदाहरण एक टेबल बनाता है, उसके पहले सेल में पैराग्राफ को डिफॉल्ट चौड़ाई और ऊंचाई से दो गुना स्केल पर रेंडर करता है, और परिणाम को PNG इमेज के रूप में सहेजता है।

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

`1` स्केल फ़ैक्टर उस अक्ष को डिफॉल्ट पिक्सेल आकार पर रखता है। उदाहरण के लिए, दोनों फ़ैक्टर के लिए `2` सेट करने से इमेज की चौड़ाई और ऊंचाई लगभग डिफॉल्ट आयामों से दो गुना हो जाती है, जिससे चार गुना पिक्सेल बनते हैं। बड़े फ़ैक्टर आमतौर पर ज़ूम या हाई-रेज़ोल्यूशन आउटपुट के लिए तेज़ टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार बढ़ाते हैं। `1` से कम फ़ैक्टर छोटे इमेज कम विवरण के साथ बनाते हैं। समान फ़ैक्टर रखकर पैराग्राफ का आस्पेक्ट रेशियो बना रहता है; अलग क्षैतिज और ऊर्ध्विक फ़ैक्टर आउटपुट को स्वतंत्र रूप से खींचते हैं।

[IShape.GetImage] के साथ पूरे शेप को रेंडर करना उपयोगी रहता है जब आउटपुट में शेप की भराव, बॉर्डर या अन्य दृश्य संदर्भ शामिल होना चाहिए। केवल पैराग्राफ-इमेज के लिए, IParagraph.GetImage का उपयोग करें।

## **FAQ**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन रैपिंग को पूरी तरह से अक्षम कर सकता हूँ?**

हाँ। ITextFrameFormat.WrapText को सेट करके रैपिंग अक्षम करें ताकि लाइनों को टेक्स्ट फ्रेम की किनारों पर नहीं तोड़ा जाए।

**मैं किसी विशिष्ट पैराग्राफ के स्लाइड पर सटीक बाउंड्स कैसे प्राप्त करूँ?**

[IParagraph.GetRect](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/getrect/) का उपयोग करके पैराग्राफ का बाउंडिंग रेक्टैंगल प्राप्त करें। [IPortion.GetRect](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/getrect/) व्यक्तिगत पोर्शन के बाउंड्स देता है।

**पैराग्राफ अलाइनमेंट (बाएँ, दाएँ, केंद्र, या जस्टिफ़ाई) कहाँ नियंत्रित होता है?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/alignment/) पैराग्राफ-स्तर सेटिंग है और यह पूरे पैराग्राफ पर लागू होती है, चाहे व्यक्तिगत पोर्शन का फ़ॉर्मेट कुछ भी हो।

**क्या मैं पैराग्राफ के हिस्से के लिए प्रूफ़िंग भाषा सेट कर सकता हूँ?**

हाँ। आप व्यक्तिगत पोर्शन के लिए IBasePortionFormat.LanguageId सेट कर सकते हैं, जिससे एक पैराग्राफ में कई भाषाओं का टेक्स्ट हो सकता है।