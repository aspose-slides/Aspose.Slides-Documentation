---
title: ".NET में प्रस्तुतियों में तालिका कोशिकाओं का प्रबंधन"
linktitle: "कोशिकाओं का प्रबंधन"
type: docs
weight: 30
url: /hi/net/manage-cells/
keywords:
- "तालिका कोशिका"
- "कोशिकाएँ मिलाएँ"
- "सीमा हटाएँ"
- "कोशिका विभाजित करें"
- "कोशिका में छवि"
- "पृष्ठभूमि रंग"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "C# में PowerPoint तालिका कोशिकाओं का प्रबंधन: मर्ज की गई कोशिकाओं की पहचान करें, सीमाओं को हटाएँ, कोशिकाओं को विभाजित करें, और Aspose.Slides for .NET के साथ पृष्ठभूमि रंग तथा छवियों को सेट करें।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका कोशिकाओं तक पहुँचने और उन्हें संशोधित करने की सुविधा देता है। यह लेख समझाता है कि कैसे मर्ज की गई तालिका कोशिकाओं की पहचान करें, कोशिका की सीमाओं को हटाएँ, मर्ज या स्प्लिट करने के बाद कोशिका क्रमांक के साथ काम करें, कोशिका की पृष्ठभूमि रंग बदलें, और तालिका कोशिका के भीतर एक छवि जोड़ें। उदाहरण दिखाते हैं कि कैसे प्रस्तुति बनाएँ या खोलें, स्लाइड से तालिका प्राप्त करें, कोशिका गुणों के माध्यम से कोशिका फ़ॉर्मेटिंग अपडेट करें, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

Aspose.Slides शून्य-आधारित सूचकांक का उपयोग करता है तालिका कोशिकाओं तक पहुँचने के लिए क्रम `(column, row)` में।

## **एक मर्ज की गई तालिका कोशिका की पहचान करें**

यह उदाहरण एक मौजूदा प्रस्तुति खोलता है और पहले स्लाइड पर पहली शेप को तालिका के रूप में पहुँचता है। यह मानता है कि स्लाइड और शेप मौजूद हैं और शेप एक तालिका है। फिर यह सभी पंक्तियों और कॉलमों में इटररेट करता है और मर्ज की गई क्षेत्रों में कोशिकाओं की पहचान के लिए [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) का उपयोग करता है। प्रत्येक मिलान के लिए, यह कोशिका के निर्देशांक `row;column` क्रम में, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), और क्षेत्र की प्रारम्भिक निर्देशांक, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) और [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) को प्रिंट करता है।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **तालिका कोशिका की सीमाओं को हटाएँ**

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) बनाएँ और उसके पहले स्लाइड पर [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) का उपयोग करके एक तालिका जोड़ें। कॉलम चौड़ाई, पंक्ति ऊँचाई, और तालिका का स्थान पॉइंट्स में निर्दिष्ट होते हैं। यह उदाहरण सभी चार कोशिका सीमाओं को [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/) सेट करता है, जिससे वे अदृश्य हो जाती हैं।

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **तालिका कोशिकाओं का मर्ज करें**

[MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) का उपयोग करके तालिका कोशिकाओं की आयताकार रेंज को एक कोशिका में मिलाएँ। रेंज के ऊपरी-बाएँ और निचले-दाएँ कोने की कोशिकाओं को निर्दिष्ट करें। अंतिम आर्ग्यूमेंट यह नियंत्रित करता है कि क्या मर्ज निर्दिष्ट रेंज के बाहर की कोशिकाओं को शामिल कर सकता है; `false` मर्ज को उसी रेंज में रखता है।

यह उदाहरण 70 पॉइंट कॉलम और पंक्तियों के साथ 4x4 तालिका बनाता है, फिर चार मध्यवर्ती कोशिकाओं को `(1, 1)` से `(2, 2)` तक मर्ज करता है। परिणामी कोशिका दो कॉलम और दो पंक्तियों को कवर करती है, जबकि तालिका की मूल ग्रिड में चार कॉलम और चार पंक्तियां बनी रहती हैं। मर्ज की गई कोशिका की सामग्री या फ़ॉर्मेटिंग तक पहुँचने के लिए, उसके ऊपरी-बाएँ स्थिति का उपयोग करें: इस उदाहरण में `table[1, 1]`। मर्ज रेंज में अन्य स्थितियाँ तालिका ग्रिड का हिस्सा बनी रहती हैं, इसलिए रेंज के बाहर की कोशिकाओं के अनुक्रमांक नहीं बदलते।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **तालिका कोशिकाओं को विभाजित करें**

पिछले उदाहरण में कोशिकाओं को मर्ज करने से तालिका की ग्रिड बनी रहती है। एक कोशिका को विभाजित करने से नया ग्रिड कॉलम बन सकता है और उसके दाएँ स्थित कोशिकाओं के कॉलम अनुक्रमांक बदल सकते हैं। Aspose.Slides PowerPoint की तालिका ग्रिड मॉडल का पालन करता है।

यह उदाहरण 70 पॉइंट कॉलम और पंक्तियों के साथ 4x4 तालिका बनाता है और `(1, 1)` कोशिका पर [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) को कॉल करता है। कोशिका की 70 पॉइंट चौड़ाई के आधे भाग को दो समान-चौड़ाई वाली कोशिकाएँ बनाने के लिए पास किया जाता है।

इस विभाजन के बाद, दोनों हिस्सों तक `table[1, 1]` और `table[2, 1]` के रूप में पहुँचा जाता है। तालिका ग्रिड अब पाँच कॉलम रखती है: मूल रूप से कॉलम 2 और 3 में थीं वे क्रमशः कॉलम 3 और 4 में चली जाती हैं। पंक्ति अनुक्रमांक अपरिवर्तित रहते हैं। विभाजन के बाद कोशिकाओं तक पहुँचते समय इन अद्यतन कॉलम अनुक्रमांक का उपयोग करें।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **पंक्ति या कॉलम स्पैन के अनुसार मर्ज की गई कोशिकाओं को विभाजित करें**

डेटा प्रविष्टि के लिए मर्ज किए गए टेम्पलेट कोशिकाओं को तैयार करने हेतु, मौजूदा पंक्ति सीमा के साथ विभाजित करने के लिए [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) या कॉलम सीमा के साथ विभाजित करने के लिए [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) का उपयोग करें।

`index` आर्ग्यूमेंट विभाजन के ऊपर भाग में पंक्तियों या बाएँ भाग में कॉलमों की गिनती करता है; यह मर्ज किए गए क्षेत्र के सापेक्ष होता है:
- पंक्ति विभाजन: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- कॉलम विभाजन: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

यह उदाहरण अपेक्षा करता है कि एक प्रस्तुति में पहले स्लाइड पर पहली शेप एक तालिका है, जिसमें `(1, 2)` और `(1, 3)` लंबवत मर्ज होते हैं। नीचे की स्थिति से शुरू करते हुए, यह [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) और [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) का उपयोग करके मूल स्थान खोजता है और दोनों स्पैन की जाँच करता है। `SplitByRowSpan(1)` फिर उत्पाद नामों के लिए पंक्तियों 2 और 3 को अलग करता है। क्षैतिज दो-कॉलम मर्ज के लिए, `SplitByColSpan(1)` का उपयोग करें।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // विभाजन के बाद तालिका से प्राप्त हुई कोशिकाओं को प्राप्त करें।
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

तालिका ग्रिड और आस-पास की कोशिका अनुक्रमांक अपरिवर्तित रहते हैं। परिणामस्वरूप कोशिकाओं को उनके निर्देशांक से प्राप्त करें; यहाँ दोनों के स्पैन 1 हैं और [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) `False` प्रिंट करता है। बड़े क्षेत्रों को एक विभाजन के बाद भी आंशिक रूप से मर्ज रखा जा सकता है।

मूल पाठ और उसका फ़ॉर्मेटिंग ऊपर (या बाएँ) कोशिका में रहता है; नई कोशिका खाली होती है लेकिन फ़िल, सीमाओं और मार्जिन जैसे सेल फ़ॉर्मेट को विरासत में प्राप्त करती है। विभाजन के बाद कोशिकाओं को भरें और आवश्यक पाठ फ़ॉर्मेटिंग स्पष्ट रूप से सेट करें।

सहेजी गई प्रस्तुति में अलग-अलग "Product A" और "Product B" कोशिकाएँ होती हैं जिनमें टेम्पलेट की कोशिका फ़ॉर्मेटिंग बरकरार रहती है। विवरण के लिए [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) देखें।

## **तालिका कोशिका की पृष्ठभूमि रंग बदलें**

यह उदाहरण 150 पॉइंट कॉलम और 50 पॉइंट पंक्तियों वाली तालिका बनाता है। यह सेल `(2, 3)` (तीसरे कॉलम और चौथी पंक्ति) के लिए [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) को सॉलिड और [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) को लाल सेट करता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **तालिका कोशिका के भीतर छवि जोड़ें**

इस उदाहरण को चलाने से पहले इनपुट छवि को कार्य निर्देशिका में रखें। यह छवि को [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) के साथ लोड करता है और इसे प्रस्तुति की इमेज कलेक्शन में [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) के साथ जोड़ता है। फिर यह छवि को सेल `(0, 0)` (तालिका की पहली कोशिका) के चित्र फ़िल में असाइन करता है।

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) छवि को सेल में भरने के लिए खिंचाव करता है, जिससे इसका आस्पेक्ट रेशियो बदल सकता है। कॉलम चौड़ाई और पंक्ति ऊँचाई पॉइंट्स में हैं। लोड की गई छवि अपने using घोषणा द्वारा स्वचालित रूप से डिस्पोज़ हो जाती है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही कोशिका के विभिन्न पक्षों के लिए अलग-अलग रेखा मोटाई और शैली सेट कर सकता हूँ?**

हाँ। [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) सीमाओं में अलग-अलग प्रॉपर्टीज़ हैं, इसलिए प्रत्येक पक्ष की मोटाई और शैली अलग हो सकती है।

**यदि मैं तस्वीर को कोशिका की पृष्ठभूमि के रूप में सेट करने के बाद कॉलम/पंक्ति का आकार बदलूँ तो छवि के साथ क्या होता है?**

व्यवहार [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) पर निर्भर करता है (stretch/tile)। स्ट्रेचिंग के साथ, छवि नए सेल के अनुसार समायोजित हो जाती है; टाइलिंग के साथ, टाइलें पुनः गणना की जाती हैं।

**क्या मैं कोशिका की सभी सामग्री को एक हाइपरलिंक असाइन कर सकता हूँ?**

[Hyperlinks](/slides/hi/net/manage-hyperlinks/) को कोशिका के टेक्स्ट फ्रेम के भीतर टेक्स्ट (portion) स्तर पर या पूरे तालिका/shape स्तर पर सेट किया जाता है। व्यावहारिक रूप में, आप लिंक को एक हिस्से या पूरी कोशिका के सभी टेक्स्ट पर असाइन करते हैं।

**क्या मैं एक ही कोशिका के भीतर अलग-अलग फ़ॉन्ट सेट कर सकता हूँ?**

हाँ। कोशिका के टेक्स्ट फ्रेम में [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (रन) समर्थन करता है, जिनमें स्वतंत्र फ़ॉर्मेटिंग—फ़ॉन्ट फैमिली, शैली, आकार, और रंग—होता है।