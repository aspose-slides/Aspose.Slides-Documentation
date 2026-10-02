---
title: .NET में PowerPoint टेक्स्ट पैराग्राफ प्रबंधित करें
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
- नंबरड सूची
- बुलेटेड सूची
- पैराग्राफ प्रॉपर्टीज़
- HTML आयात करें
- टेक्स्ट से HTML
- पैराग्राफ से HTML
- पैराग्राफ से इमेज
- टेक्स्ट से इमेज
- पैराग्राफ निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ पैराग्राफ, पोर्शन, बुलेट, नंबरड लिस्ट, इंडेंट, HTML सामग्री, और पैराग्राफ इमेज कैसे बनाएं और फ़ॉर्मेट करें, यह सीखें।"
---
## **अवलोकन**

Aspose.Slides for .NET टेक्स्ट को टेक्स्ट फ्रेम, पैराग्राफ और पोर्शन की पदानुक्रम के रूप में दर्शाता है:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) टेक्स्ट कंटेनर को एक आकार में दर्शाता है और इसके पैराग्राफ संग्रह तक पहुंच प्रदान करता है।
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) टेक्स्ट फ्रेम में एक पैराग्राफ को दर्शाता है और इसके पोर्शन और पैराग्राफ‑स्तरीय फ़ॉर्मेटिंग तक पहुंच प्रदान करता है।
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) पैराग्राफ के भीतर एक टेक्स्ट रन को दर्शाता है। प्रत्येक पोर्शन का अपना टेक्स्ट और कैरेक्टर‑स्तरीय फ़ॉर्मेटिंग हो सकता है।

इस प्रकार एक पैराग्राफ कई पोर्शन का उपयोग करके विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फ़ॉर्मेटिंग वाला टेक्स्ट रख सकता है।

## **पैराग्राफ बनाना और फ़ॉर्मेट करना**

### **कई पोर्शन वाले पैराग्राफ बनाना**

निम्नलिखित चरण एक टेक्स्ट फ्रेम बनाते हैं जिसमें तीन पैराग्राफ होते हैं, प्रत्येक में तीन पोर्शन होते हैं:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) जोड़ें।
4. शेप के [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) तक पहुंचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करें और टेक्स्ट फ्रेम में दो अतिरिक्त [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक पैराग्राफ के लिए पर्याप्त [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) ऑब्जेक्ट जोड़ें ताकि तीन पोर्शन हो सकें। डिफ़ॉल्ट पैराग्राफ में पहले से ही एक खाली पोर्शन होता है।
7. प्रत्येक पोर्शन का टेक्स्ट सेट करें।
8. [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/) के माध्यम से कैरेक्टर‑स्तरीय फ़ॉर्मेटिंग लागू करें।
9. संशोधित प्रेजेंटेशन सहेजें।

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

## **बुलेटेड और नंबरड लिस्ट बनाना**

### **बुलेटेड या नंबरड लिस्ट बनाना**

बुलेट और नंबरिंग संबंधित आइटम्स को स्कैन करना आसान बनाते हैं। Aspose.Slides में लिस्ट सेटिंग्स को [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) के माध्यम से परिभाषित किया जाता है।

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का संदर्भ प्राप्त करें।
3. चयनित स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) जोड़ें।
4. शेप के [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) तक पहुंचें।
5. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएं।
6. एक प्रतीक बुलेट के लिए एक [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) बनाएं।
7. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) को [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) पर सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
8. पैराग्राफ टेक्स्ट, इंडेंट, बुलेट रंग और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. दूसरा पैराग्राफ बनाएं और [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) को [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) पर सेट करें।
11. नंबरड बुलेट शैली को कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
12. प्रेजेंटेशन सहेजें।

यह C# उदाहरण एक प्रतीक बुलेट और एक नंबरड बुलेट बनाता है:

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

### **पिक्चर बुलेट का उपयोग करना**

पिक्चर बुलेट आपको एक कस्टम इमेज को प्रतीक या नंबर के बजाय इस्तेमाल करने देता है।

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का संदर्भ प्राप्त करें।
3. एक [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) जोड़ें और उसका [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) प्राप्त करें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएं।
5. बुलेट इमेज लोड करें और उसे प्रेजेंटेशन की इमेज कलेक्शन में एक [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) बनाएं और उसका टेक्स्ट सेट करें।
7. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) को [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) पर सेट करें।
8. [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) के माध्यम से इमेज असाइन करें और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. संशोधित प्रेजेंटेशन सहेजें।

यह C# उदाहरण एक पिक्चर बुलेट बनाता है:

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

### **मल्टीलेवल लिस्ट बनाना**

[IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) को सेट करके लिस्ट के विभिन्न स्तरों पर पैराग्राफ रख सकते हैं। शीर्ष स्तर की डिफ़ॉल्ट गहराई `0` होती है।

1. एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) बनाएं और एक स्लाइड तक पहुंचें।
2. एक [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) जोड़ें और उसके टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. चार पैराग्राफ बनाएं और उनके बुलेट प्रतीक कॉन्फ़़िगर करें।
4. उनके [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) मान को क्रमशः `0`, `1`, `2`, और `3` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रेजेंटेशन सहेजें।

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

### **कस्टम मानों से नंबरड लिस्ट आइटम शुरू करना**

[IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) का उपयोग करके नंबरड पैराग्राफ के प्रारंभिक नंबर को सेट किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) बनाएं और एक [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) स्लाइड में जोड़ें।
2. शेप के टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएं।
3. तीन नंबरड पैराग्राफ बनाएं।
4. प्रत्येक पैराग्राफ के लिए [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) को क्रमशः `2`, `3` और `7` पर सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रेजेंटेशन सहेजें।

यह C# उदाहरण प्रत्येक पैराग्राफ के लिए कस्टम प्रारंभिक नंबर सेट करता है:

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

## **पैराग्राफ लेआउट और एंड प्रॉपर्टीज़ नियंत्रित करना**

### **पहली‑लाइन इंडेंट सेट करना**

[IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) प्रॉपर्टी का उपयोग करके पैराग्राफ की पहली‑लाइन इंडेंट को नियंत्रित किया जाता है। यह प्रॉपर्टी केवल पहली लाइन को पैराग्राफ के बाएँ मार्जिन के सापेक्ष ले जाती है। सकारात्मक मान पहली लाइन को दाएँ शिफ्ट करता है, जबकि बाकी लाइनों को पैराग्राफ बॉडी के साथ संरेखित रहता है।

पूरे पैराग्राफ को स्थानांतरित करने के लिए [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) का उपयोग करें। केवल पहली लाइन को स्थानांतरित करने के लिए [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) का उपयोग करें।

निम्न उदाहरण कई पैराग्राफ बनाता है और विभिन्न [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) मान लागू करता है ताकि दिखाया जा सके कि पहली‑लाइन इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. लक्ष्य स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) जोड़ें।
4. शेप के [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ हटाएं।
5. कई पैराग्राफ बनाएं और उनके लिए विभिन्न [Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रेजेंटेशन सहेजें।

यह कोड पैराग्राफ इंडेंट सेट करने का तरीका दिखाता है:

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

![पैराग्राफ की पहली‑लाइन इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करना**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली लाइन बाकी लाइनों के बाएँ शुरू होती है। Aspose.Slides में यह प्रभाव [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) प्रॉपर्टी से बनाया जाता है। `Indent` को नकारात्मक मान पर सेट करने से पहली लाइन पैराग्राफ बॉडी के सापेक्ष बाएँ शिफ्ट हो जाती है।

व्यावहारिक रूप से, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) पैराग्राफ बॉडी की बायीं स्थिति निर्धारित करता है, और [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) पहली लाइन की स्थिति को उस मार्जिन के सापेक्ष तय करता है। हैंगिंग इंडेंट बनाने के लिए सकारात्मक `MarginLeft` मान और नकारात्मक `Indent` मान सेट करें।

यह फ़ॉर्मेटिंग बाइबिलियोग्राफी, रेफ़रेंसेज़, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ के लिए उपयोगी है जहाँ रैप्ड लाइन्स पैराग्राफ बॉडी के तहत संरेखित होनी चाहिए, न कि पहली लाइन के पहले अक्षर के तहत।

1. एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. लक्ष्य स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) जोड़ें।
4. शेप के [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ हटाएं।
5. प्रत्येक पैराग्राफ के लिए सकारात्मक [MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) मान सेट करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए नकारात्मक [Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) मान सेट करें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रेजेंटेशन सहेजें।

यह कोड हैंगिंग इंडेंट सेट करने का तरीका दिखाता है:

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

![पैराग्राफ की हैंगिंग इंडेंट](hanging_indent.png)

### **एंड पैराग्राफ रन प्रॉपर्टीज़ सेट करना**

[IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) प्रॉपर्टी पैराग्राफ के एंड मार्क की फ़ॉर्मेटिंग को नियंत्रित करती है। निम्न उदाहरण दूसरे पैराग्राफ के एंड मार्क को फ़ॉन्ट साइज और लैटिन फ़ॉन्ट असाइन करता है:

1. एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) लोड करें और एक स्लाइड तक पहुंचें।
2. एक [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. दो पैराग्राफ बनाएं और उनमें टेक्स्ट पोर्शन जोड़ें।
4. दूसरे पैराग्राफ के एंड मार्क के लिए एक [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) बनाएं।
5. [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) और [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) सेट करें।
6. फ़ॉर्मेट को [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) में असाइन करें और प्रेजेंटेशन सहेजें।

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

पैराग्राफ नियम जो स्वतः रैपिंग और लाइन‑एंड पंक्‍टुएशन को प्रभावित करते हैं, उन्हें देखें: [Control Line Breaking](/slides/hi/net/text-formatting/#control-line-breaking) और [Control Hanging Punctuation](/slides/hi/net/text-formatting/#control-hanging-punctuation)।

[IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) का उपयोग करके टेक्स्ट लेआउट के बाद एक पैराग्राफ द्वारा औकात ली गई लाइनों की संख्या गिनी जा सकती है, जिसमें स्वतः रैपिंग भी शामिल है। यह प्रेजेंटेशन टेम्प्लेट में टेक्स्ट लंबाई और लेआउट को जांचने में उपयोगी है।

एक पैराग्राफ [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/) में एक आइटम है, और यह कई रेंडर की गई लाइनों को घेर सकता है। पैराग्राफ के भीतर एक स्पष्ट लाइन‑ब्रेक नई लाइन बनाता है बिना नया पैराग्राफ बनाए। स्वतः रैपिंग उपलब्ध चौड़ाई के आधार पर लाइनों का निर्माण करती है, बिना टेक्स्ट में स्पष्ट लाइन‑ब्रेक डाले। इसलिए पैराग्राफ या लाइन‑ब्रेक कैरेक्टर गिनना रेंडर की गई लाइन‑काउंट नहीं देता।

निम्न उदाहरण एक टेक्स्ट शेप बनाता है, उसकी लाइनों की गिनती करता है, शेप को संकुचित करता है, और फिर टेक्स्ट को छोटा स्ट्रिंग से बदलता है। रैपिंग सक्षम है और ऑटो‑फ़िट बंद है ताकि शेप की चौड़ाई रैपिंग को नियंत्रित करे बिना टेक्स्ट को स्वतः छोटा या शेप को रिसाइज़ किए। शेप की डाइमेंशन पॉइंट्स में हैं। अंत में उदाहरण एक और पैराग्राफ जोड़ता है और टेक्स्ट फ्रेम में सभी लाइन‑काउंट का योग करता है।

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

इन टेक्स्ट और डाइमेंशन के साथ, शेप को संकुचित करने से लाइन‑काउंट बढ़ता है, जबकि छोटा स्ट्रिंग रखने से घटता है। सटीक गिनती फ़ॉन्ट उपलब्धता, प्रतिस्थापन, फ़ॉन्ट साइज, मार्जिन, इंडेंटेशन, रैपिंग और ऑटो‑फ़िट सेटिंग्स पर निर्भर करती है। टेम्प्लेट जांचते समय लक्ष्य वातावरण के लिए निर्धारित फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

केवल लाइन‑काउंट यह निर्धारित नहीं करता कि टेक्स्ट कंटेनर से बाहर जा रहा है या नहीं। उपलब्ध ऊँचाई, लाइन‑हाइट, पैराग्राफ और लाइन स्पेसिंग, तथा ऑटो‑फ़िट व्यवहार भी महत्वपूर्ण हैं; यहां तक कि एक ही लाइन भी जब रैपिंग बंद हो तो उपलब्ध चौड़ाई से अधिक हो सकती है।

## **पैराग्राफ कंटेंट आयात और निर्यात करना**

### **HTML टेक्स्ट को पैराग्राफ में आयात करना**

[ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) का उपयोग करके HTML मार्कअप को टेक्स्ट फ्रेम में पैराग्राफ और पोर्शन में बदल सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. एक स्लाइड तक पहुंचें और एक [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) जोड़ें।
3. शेप के [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ साफ़ करें।
4. स्रोत HTML फ़ाइल पढ़ें।
5. HTML स्ट्रिंग को [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) में पास करें।
6. संशोधित प्रेजेंटेशन सहेजें।

यह C# उदाहरण HTML को टेक्स्ट फ्रेम में आयात करता है:

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

[ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं और इच्छित प्रेजेंटेशन लोड करें।
2. स्लाइड तक पहुंचें और वह [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) खोजें जिसमें टेक्स्ट है।
3. शेप के [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) तक पहुंचें।
4. प्रारम्भ पैराग्राफ इंडेक्स और निर्यात करने वाले पैराग्राफ की संख्या के साथ [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) को कॉल करें।
5. लौटाए गए HTML स्ट्रिंग को फ़ाइल में लिखें।

यह C# उदाहरण पहले टेक्स्ट शेप के सभी पैराग्राफ निर्यात करता है:

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

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) लौटाता है। परिणाम को [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) से फ़ाइल या स्ट्रीम में सहेजा जा सकता है। शेप को रेंडर करने या बिटमैप को मैन्युअली काटने की आवश्यकता नहीं है।

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) `null` भी लौटाता है यदि पैराग्राफ उसका पैरेंट संग्रह में नहीं मिलता, कोई वैध रेंडर बाउंड नहीं है, या रेंडर नहीं किया जा सकता। सहेजने से पहले परिणाम जाँचें और उपयोग के बाद लौटाई गई इमेज को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करना**

मान लीजिए हमारे पास `sample.pptx` नामक प्रेजेंटेशन फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला शेप तीन पैराग्राफ वाला टेक्स्ट बॉक्स है।

![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न उदाहरण नियमित टेक्स्ट शेप में दूसरे पैराग्राफ को डिफ़ॉल्ट स्केल पर रेंडर करता है और PNG फ़ॉर्मेट में लौटाई गई इमेज सहेजता है। `using` घोषणा सुनिश्चित करती है कि इमेज सही ढंग से डिस्पोज़ हो जाए।

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

#### **टेबल सेल में स्केलिंग के साथ पैराग्राफ रेंडर करना**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) के ओवरलोड का उपयोग करें जो `float scaleX` और `float scaleY` पैरामीटर लेता है ताकि हॉरिज़ोंटल और वर्टिकल स्केल फैक्टर सेट किए जा सकें। नीचे का उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई के दो गुना पर रेंडर करता है, और परिणाम को PNG इमेज के रूप में सहेजता है।

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

`1` के स्केल फैक्टर से उस अक्ष की डिफ़ॉल्ट पिक्सेल साइज बरकरार रहती है। उदाहरण के लिए, दोनों फ़ैक्टर को `2` करने से इमेज की चौड़ाई और ऊँचाई लगभग डिफ़ॉल्ट के दो गुना हो जाती है, जिससे चार गुना पिक्सेल मिलते हैं। बड़े फैक्टर ज़ूम या हाई‑रिज़ॉल्यूशन आउटपुट के लिए तेज़ टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार बढ़ाते हैं। `1` से कम फैक्टर छोटे इमेज बनाते हैं जिसमें कम डिटेल होती है। इमेज की अनुपातिक आकृति रखने के लिए बराबर फैक्टर उपयोग करें; अलग‑अलग हॉरिज़ोंटल और वर्टिकल फैक्टर आउटपुट को स्वतंत्र रूप से स्ट्रेच करेंगे।

[IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) के साथ पूरा शेप रेंडर करना उपयोगी रहता है जब आउटपुट में शेप का फ़िल, बॉर्डर या अन्य विज़ुअल कॉन्टेक्स्ट शामिल होना आवश्यक हो। केवल पैराग्राफ‑इमेज के लिए [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) का उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन रैपिंग को पूरी तरह बंद कर सकता हूँ?**

हाँ। [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) को `false` सेट करके रैपिंग बंद कर सकते हैं जिससे लाइनों का ब्रेक टेक्स्ट फ्रेम के किनारों पर नहीं होता।

**मैं किसी विशेष पैराग्राफ की ऑन‑स्लाइड बाउंड्स कैसे प्राप्त कर सकता हूँ?**

[IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) का उपयोग करके पैराग्राफ का बाउंडिंग रेक्टैंगल प्राप्त करें। [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) एक व्यक्तिगत पोर्शन की बाउंड्स देती है।

**पैराग्राफ एलाइनमेंट (बायाँ, दायाँ, केंद्र, या जस्टिफ़ाइ) कहाँ नियंत्रित होता है?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) एक पैराग्राफ‑स्तर की सेटिंग है और पूरे पैराग्राफ पर लागू होती है, चाहे व्यक्तिगत पोर्शन का फ़ॉर्मेटिंग कुछ भी हो।

विभिन्न फ़ॉन्ट साइज वाले पोर्शन को प्रत्येक लाइन में वर्टिकली एलाइन करने के लिए देखें: [Align Fonts Within a Line](/slides/hi/net/text-formatting/#align-fonts-within-a-line)।

**क्या मैं पैराग्राफ के हिस्से के लिए प्रूफ़िंग भाषा सेट कर सकता हूँ?**

हाँ। व्यक्तिगत पोर्शन के लिए [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) सेट करें, जिससे एक पैराग्राफ में कई भाषाओं का टेक्स्ट हो सकता है।