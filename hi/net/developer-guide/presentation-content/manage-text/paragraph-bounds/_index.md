---
title: .NET में प्रस्तुतियों से पैराग्राफ़ सीमाएँ प्राप्त करें
linktitle: पैराग्राफ़ सीमाएँ
type: docs
weight: 43
url: /hi/net/paragraph-bounds/
keywords:
- पैराग्राफ़ सीमाएँ
- पैराग्राफ़ निर्देशांक
- पैराग्राफ़ आकार
- टेक्स्ट फ्रेम
- PowerPoint
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में पैराग्राफ़ सीमाएँ कैसे प्राप्त करें, ताकि PowerPoint प्रस्तुतियों में टेक्स्ट की स्थिति को अनुकूलित किया जा सके।"
---
## **परिचय**

यह लेख Aspose.Slides में पैराग्राफ़ की सीमाएँ, आकार और निर्देशांक प्राप्त करने के तरीके को समझाता है। यह दिखाता है कि कैसे [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) का उपयोग करके [IParagraph.GetRect](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/getrect/) द्वारा पैराग्राफ़ आयत को प्राप्त करें, टेबल सेल टेक्स्ट फ़्रेम के अंदर पैराग्राफ़ के निर्देशांक कैसे प्राप्त करें, और मापन इकाइयों, टेक्स्ट रैपिंग के सीमाओं पर प्रभाव, पिक्सेल परिवर्तन, और प्रभावी पैराग्राफ़ फ़ॉर्मेटिंग मान जैसे महत्वपूर्ण विवरणों को उजागर करता है।

## **पैराग्राफ़ के आयताकार निर्देशांक प्राप्त करें**

पैराग्राफ़ का बाउंडिंग आयत प्राप्त करने के लिए [IParagraph.GetRect](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/getrect/) का उपयोग करें।

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **टेबल सेल टेक्स्टफ़्रेम के अंदर पैराग्राफ़ का आकार प्राप्त करें**

टेबल सेल टेक्स्टफ़्रेम में किसी [IParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/) का आकार और निर्देशांक प्राप्त करने के लिए, [IParagraph.GetRect](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/getrect/) का उपयोग करें। लौटाया गया आयत टेबल सेल टेक्स्टफ़्रेम के सापेक्ष होता है, इसलिए स्लाइड-स्तर के निर्देशांकों की आवश्यकता होने पर टेबल की स्थिति और सेल ऑफ़सेट जोड़ें।

निम्नलिखित उदाहरण टेबल सेल के अंदर पैराग्राफ़ की सीमाएँ प्राप्त करता है और स्लाइड पर आयतें बनाकर उन सीमाओं को दृश्य रूप में दिखाता है:

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**पैराग्राफ़ निर्देशांक किस इकाई में मापे जाते हैं?**

इन्हें पॉइंट्स में मापा जाता है, जहाँ 1 इंच बराबर 72 पॉइंट्स होता है। यह स्लाइड पर सभी निर्देशांक और आयामों पर लागू होता है।

**क्या शब्द रैपिंग पैराग्राफ़ की सीमाओं को प्रभावित करती है?**

हां। यदि [TextFrameFormat.WrapText](https://reference.aspose.com/slides/hi/net/aspose.slides/textframeformat/wraptext/) को [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) के लिए सक्षम किया गया है, तो टेक्स्ट क्षेत्र की चौड़ाई के अनुसार टुकड़े होकर रैप हो जाता है, जिससे पैराग्राफ़ की वास्तविक सीमाएँ बदल गई हैं।

**क्या पैराग्राफ़ निर्देशांक को निर्यात किए गए चित्र में पिक्सेल में विश्वसनीय रूप से मैप किया जा सकता है?**

हां। पॉइंट्स को पिक्सेल में बदलने के लिए इस सूत्र का उपयोग करें: pixels = points × (DPI / 72)। परिणाम रेंडरिंग या निर्यात के लिए चुने गए DPI पर निर्भर करता है।

**स्टाइल विरासत को ध्यान में रखते हुए "प्रभावी" पैराग्राफ़ फ़ॉर्मेटिंग पैरामीटर कैसे प्राप्त करें?**

इस [प्रभावी पैराग्राफ़ फ़ॉर्मेटिंग डेटा संरचना](/slides/hi/net/shape-effective-properties/) का उपयोग करें; यह इंडेंट, स्पेसिंग, रैपिंग, RTL आदि के लिए अंतिम समेकित मान लौटाती है।