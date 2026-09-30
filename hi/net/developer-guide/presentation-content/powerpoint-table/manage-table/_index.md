---
title: .NET में प्रस्तुति तालिकाओं का प्रबंधन
linktitle: तालिका प्रबंधन
type: docs
weight: 10
url: /hi/net/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएं
- तालिका तक पहुँचें
- आस्पेक्ट अनुपात
- पाठ संरेखित करें
- पाठ स्वरूपण
- तालिका शैली
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint स्लाइड्स में तालिकाएँ बनाएं और संपादित करें। अपने तालिका कार्यप्रवाह को सरल बनाने के लिए सरल C# कोड उदाहरण खोजें।"
---
## **परिचय**

PowerPoint में तालिकाएँ जानकारी को पंक्तियों और स्तंभों में व्यवस्थित करती हैं, जिससे मानों को पढ़ना और उनकी तुलना करना आसान हो जाता है।

Aspose.Slides एक [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) क्लास, [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) इंटरफ़ेस, [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) क्लास, [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) इंटरफ़ेस, तथा अन्य प्रकार प्रदान करता है जिससे आप प्रस्तुतियों में तालिकाएँ बना, अपडेट और प्रबंधित कर सकते हैं।

## **शुरू से तालिका बनाएं**

स्थिति, स्तंभ की चौड़ाइयों और पंक्तियों की ऊँचाइयों को निर्दिष्ट करके तालिका बनाएं। स्लाइड में जोड़ने के बाद आप सेल सीमाओं को स्वरूपित कर सकते हैं, सेल्स को मिलाने और टेक्स्ट सम्मिलित कर सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास का इनस्टैंस बनाएं।
2. इंडेक्स के आधार पर स्लाइड का संदर्भ प्राप्त करें।
3. पॉइंट्स में स्तंभ चौड़ाइयों की एक ऐरे परिभाषित करें।
4. पॉइंट्स में पंक्ति ऊँचाइयों की एक ऐरे परिभाषित करें।
5. स्लाइड में [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) मेथड के माध्यम से एक [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) को क्रमबद्ध करके शीर्ष, नीचे, दाएँ और बाएँ सीमाओं पर स्वरूपण लागू करें।
7. तालिका की पहली पंक्ति के पहले दो सेल्स को मिलाएँ।
8. मिलाए गए सेल तक उसकी [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) संपत्ति के माध्यम से पहुँचें।
9. मिलाए गए सेल में टेक्स्ट सेट करें।
10. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया उदाहरण 100, 50 पॉइंट्स पर तीन स्तंभ और पांच पंक्तियों वाली तालिका बनाता है। यह 5 पॉइंट्स की चौड़ाई वाले लाल सीमाएँ लागू करता है, पहली पंक्ति के पहले दो सेल्स को मिलाता है, और परिणाम को `table.pptx` के रूप में सहेजता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **मानक तालिका में क्रमांकन**

एक मानक तालिका में, सेल सूचकांक शून्य‑आधारित होते हैं और (स्तंभ, पंक्ति) क्रम का उपयोग करते हैं। पहला सेल (0, 0) के रूप में सूचित किया जाता है।

उदाहरण के लिए, 4 स्तंभ और 4 पंक्तियों वाली तालिका में सेल्स इस प्रकार क्रमांकित होते हैं:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

यह उदाहरण उपरोक्त दिखाए गए 4 × 4 तालिका को बनाता है, जिसमें स्तंभ चौड़ाइयाँ और पंक्ति ऊँचाइयाँ 70 पॉइंट्स हैं और 5 पॉइंट्स की चौड़ाई वाले लाल सेल सीमाएँ हैं। निर्देशांक सेल सूचकांक दर्शाते हैं; उदाहरण सेल्स को खाली छोड़ता है और तालिका को `StandardTables_out.pptx` के रूप में सहेजता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **मौजूदा तालिका तक पहुँचें**

तालिकाएँ स्लाइड के शेप कलेक्शन में संग्रहित होती हैं। शेप्स के माध्यम से इटररेट करके तालिका खोजें, फिर उसके सेल्स को पढ़ने या अपडेट करने के लिए [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) इंटरफ़ेस का उपयोग करें।

1. प्रस्तुति को [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास का उपयोग करके लोड करें।
2. इंडेक्स द्वारा तालिका वाले स्लाइड का संदर्भ प्राप्त करें।
3. [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) ऑब्जेक्ट्स के माध्यम से इटररेट करें और जब तालिका मिले तो रुकें। यदि स्लाइड में कई तालिकाएँ हों, तो आवश्यक तालिका को पहचानने के लिए [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) का उपयोग करें।
4. लक्षित सेल में टेक्स्ट अपडेट करें।
5. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया उदाहरण `UpdateExistingTable.pptx` खोलता है और पहली स्लाइड पर पहली तालिका खोजता है। यह स्तंभ 0, पंक्ति 1 के सेल को `New` सेट करता है और परिणाम को `table1_out.pptx` के रूप में सहेजता है। इनपुट में कम से कम एक स्लाइड होनी चाहिए, और उस स्लाइड की पहली तालिका में कम से कम एक स्तंभ और दो पंक्तियाँ होनी चाहिए।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

To resize a row in an existing table and understand why its actual height can exceed the requested minimum, see [Control Row Height](/slides/hi/net/manage-rows-and-columns/#control-row-height).

## **टेक्स्ट फ्रेम वाला सेल खोजें**

जब सामान्य टेक्स्ट‑प्रोसेसिंग कोड एक तालिका से [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) प्राप्त करता है, तो संबंधित [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) को प्राप्त करने के लिए [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) संपत्ति का उपयोग करें। तालिका‑सेल टेक्स्ट फ्रेम के लिए, [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) सेट होता है और [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) `null` होता है, जबकि तालिका स्वयं एक शेप होती है।

सेल निर्देशांक पढ़ने‑के‑लिए केवल [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) और [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) गुणों के माध्यम से उपलब्ध होते हैं। [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) भी केवल‑पढ़ने‑योग्य है: यह मालिक तक नेविगेशन प्रदान करता है लेकिन स्वामित्व नहीं बदलता। उपयोग करने से पहले हमेशा लौटाए गए सेल को `null` के लिए जांचें।

एक पूर्ण उदाहरण के लिए जो तालिका‑सेल और शेप मालिकों की पहचान करता है, जिसमें SmartArt नोड्स से जुड़े शेप्स भी शामिल हैं, देखें [Search and Replace Text](/slides/hi/net/search-and-replace-text/)।

## **तालिका में टेक्स्ट संरेखित करें**

आप व्यक्तिगत तालिका सेल्स की vertical एंकरिंग और टेक्स्ट दिशा को नियंत्रित कर सकते हैं। इस खंड में दिया गया उदाहरण पहले सेल में टेक्स्ट को केंद्रित करता है और उसे 270 डिग्री घुमाता है।

1. एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. इंडेक्स के आधार पर स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) ऑब्जेक्ट जोड़ें।
4. तालिका से एक [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) ऑब्जेक्ट तक पहुंचें।
5. पहले [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) तक पहुंचें और उसका टेक्स्ट व रंग सेट करें।
6. सेल की [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) और [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/) सेट करें।
7. संशोधित प्रस्तुति को सहेजें।

यह उदाहरण 120 पॉइंट्स की स्तंभ चौड़ाइयों और 100 पॉइंट्स की पंक्ति ऊँचाइयों वाली 4 × 4 तालिका बनाता है। यह सेल (0, 0) में टेक्स्ट को स्वरूपित करता है, पहली पंक्ति के शेष सेल्स में मान जोड़ता है, और परिणाम को `Vertical_Align_Text_out.pptx` के रूप में सहेजता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **तालिका स्तर पर टेक्स्ट स्वरूपण सेट करें**

[SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) का उपयोग करके आप तालिका के सभी सेल्स पर टेक्स्ट स्वरूपण लागू कर सकते हैं। इसके ओवरलोड्स भाग, पैराग्राफ और टेक्स्ट फ्रेम स्वरूपण को स्वीकार करते हैं, जिससे आप व्यक्तिगत सेल्स के माध्यम से इटररेट किए बिना इन गुणों को सेट कर सकते हैं।

1. प्रस्तुति को [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास का उपयोग करके लोड करें।
2. इंडेक्स के आधार पर स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड से एक [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) ऑब्जेक्ट तक पहुंचें।
4. टेक्स्ट के लिए [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) सेट करें।
5. [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) और [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) सेट करें।
6. [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) सेट करें।
7. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया उदाहरण `table.pptx` खोलता है, जिसमें कम से कम एक स्लाइड होनी चाहिए जिसमें पहला शेप एक तालिका हो। यह फ़ॉन्ट आकार को 25 पॉइंट्स सेट करता है, पैराग्राफ को 20 पॉइंट्स के दायें मार्जिन के साथ दायें‑समरूप करता है, और टेक्स्ट को वर्टिकल बनाता है। स्वरूपित प्रस्तुति को `result.pptx` के रूप में सहेजा जाता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **तालिका शैली गुण प्राप्त करें**

[StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) का उपयोग करके आप तालिका की प्रीसेट शैली पढ़ या असाइन कर सकते हैं। यह उदाहरण एक तालिका पर [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) लागू करता है, प्रीसेट नाम प्रिंट करता है, और उसी प्रीसेट को दूसरी तालिका को असाइन करता है। दोनों तालिकाएँ `table-style.pptx` में सहेजी जाती हैं।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **तालिका के पहलू अनुपात को लॉक करें**

एक तालिका का पहलू अनुपात उसकी चौड़ाई और ऊँचाई का अनुपात है। तालिका के लिए इस अनुपात को लॉक करने के लिए [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) का उपयोग करें।

यह उदाहरण `pres.pptx` खोलता है, जिसमें कम से कम एक स्लाइड होनी चाहिए जिसमें पहला शेप एक तालिका हो। यह वर्तमान लॉक स्थिति को प्रिंट करता है, पहलू अनुपात लॉक को सक्षम करता है, अद्यतित स्थिति (`True`) को प्रिंट करता है, और परिणाम को `pres-out.pptx` के रूप में सहेजता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**क्या मैं पूरी तालिका और उसकी सेल्स के टेक्स्ट के लिए दाएँ‑से‑बाएँ (RTL) पढ़ने की दिशा सक्षम कर सकता हूँ?**

हां। तालिका एक [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) गुण प्रदान करती है, और पैराग्राफ में [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/) उपलब्ध है। दोनों का उपयोग करने से सेल्स के अंदर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।

**मैं उपयोगकर्ताओं को अंतिम फ़ाइल में तालिका को स्थानांतरित या आकार बदलने से कैसे रोक सकता हूँ?**

[shape locks](/slides/hi/net/applying-protection-to-presentation/) का उपयोग करके आप स्थानांतरित करना, आकार बदलना, चयन आदि को निष्क्रिय कर सकते हैं। ये लॉक तालिकाओं पर भी लागू होते हैं।

**क्या सेल के भीतर एक छवि को बैकग्राउंड के रूप में डालना समर्थित है?**

हां। आप एक सेल के लिए [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) सेट कर सकते हैं; चयनित मोड (स्ट्रैच या टाइल) के अनुसार छवि सेल क्षेत्र को कवर करेगी।