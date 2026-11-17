---
title: .NET में प्रस्तुतियों में तालिका कोशिकाओं का प्रबंधन
linktitle: कोशिकाओं का प्रबंधन
type: docs
weight: 30
url: /hi/net/manage-cells/
keywords:
- तालिका कोशिका
- कोशिकाओं का विलय
- सीमा हटाएँ
- कोशिका विभाजन
- कोशिका में चित्र
- पृष्ठभूमि रंग
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "C# में PowerPoint तालिका कोशिकाओं को प्रबंधित करें: मर्ज की गई कोशिकाओं की पहचान करें, सीमाएँ हटाएँ, कोशिकाओं को विभाजित करें, और Aspose.Slides for .NET के साथ पृष्ठभूमि रंग और छवियाँ सेट करें।"
---
## **समीक्षा**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका कोशिकाओं तक पहुंचने और उन्हें संशोधित करने की अनुमति देता है। यह लेख बताता है कि कैसे जुड़ी हुई तालिका कोशिकाओं की पहचान करें, कोशिका की सीमाओं (बॉर्डर) को हटाएँ, कोशिका संख्या को मर्ज या स्प्लिट करने के बाद कैसे काम करें, कोशिका की पृष्ठभूमि रंग बदलें, और तालिका कोशिका के भीतर एक छवि जोड़ें। उदाहरण दिखाते हैं कि प्रस्तुति कैसे बनाएं या खोलें, स्लाइड से तालिका प्राप्त करें, कोशिका गुणों के माध्यम से कोशिका स्वरूपण अपडेट करें, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

Aspose.Slides शून्य-आधारित संकेतकों का उपयोग करके तालिका कोशिकाओं तक क्रम `(column, row)` में पहुंचता है।

## **मर्ज की गई तालिका कोशिका की पहचान**

यह उदाहरण मौजूदा प्रस्तुति खोलता है और पहले स्लाइड पर पहले आकार (शेप) को तालिका के रूप में पहुंचता है। यह मानता है कि स्लाइड और आकार मौजूद हैं और आकार एक तालिका है। फिर यह सभी पंक्तियों और स्तंभों पर इटररेट करता है और [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) का उपयोग करके मर्ज किए गए क्षेत्रों में कोशिकाओं की पहचान करता है। प्रत्येक मेल के लिए, यह कोशिका के निर्देशांक को `row;column` क्रम में, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), और क्षेत्र की प्रारंभिक निर्देशांक, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) और [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) के रूप में प्रिंट करता है।

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

## **तालिका कोशिका सीमाओं को हटाएँ**

एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) बनाएं और उसके पहले स्लाइड में [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) का उपयोग करके एक तालिका जोड़ें। कॉलम की चौड़ाई, पंक्ति की ऊँचाई, और तालिका स्थिति बिंदुओं में निर्दिष्ट हैं। उदाहरण सभी चार कोशिका सीमाओं को [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/) पर सेट करता है, जिससे वे अदृश्य हो जाते हैं।

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

## **तिरछी कोशिका सीमाएँ जोड़ें**

[BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) का उपयोग करके शीर्ष-बाएँ कोने से नीचे-दाएँ कोने तक एक रेखा खींचें, और [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) का उपयोग करके नीचे-बाएँ कोने से शीर्ष-दाएँ कोने तक रेखा खींचें। एक तिरछी रेखा कोने हेडर को चिह्नित कर सकती है; दोनों तिरछी रेखाएँ एक X बना सकती हैं जिससे कोशिका को लागू नहीं माना जाता।

प्रत्येक तिरछी रेखा एक [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/) है। उसके [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) में, [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) को [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) पर सेट करें और एक [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) चुनें। रेखा की [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) को बिंदुओं में सेट करें।

उदाहरण एक पंक्ति में तीन कोशिकाएँ बनाता है: एक लाल नीचे‑तिरछी रेखा, एक नीली ऊपर‑तिरछी रेखा, और दोनों तिरछी रेखाएँ। यह ऊपर, नीचे, बाएँ और दाएँ कोशिका सीमाओं को अपरिवर्तित रखता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

एक तिरछी रेखा एक स्वरूपण गुण है, न कि कोशिका विभाजन। प्रत्येक कोशिका एकल [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) बनाए रखती है; तिरछी रेखा के दोनों पक्षों के क्षेत्र स्वतंत्र रूप से संपादित नहीं किए जा सकते।

सहेजे गए तालिका, Microsoft PowerPoint में रेंडर किया गया:

![तीन तालिका कोशिकाएँ दर्शाती हैं एक लाल तिरछी रेखा शीर्ष-बाएँ से नीचे-दाएँ, एक नीली तिरछी रेखा नीचे-बाएँ से शीर्ष-दाएँ, और दोनों रेखाएँ एक X बनाती हैं।](diagonal-cell-borders.png)

*बाएँ से दाएँ: नीचे‑तिरछी रेखा (लाल, 3 pt), ऊपर‑तिरछी रेखा (नीला, 5 pt), और दोनों तिरछी रेखाएँ।*

## **तालिका कोशिकाओं का मर्ज करें**

[MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) का उपयोग करके तालिका कोशिकाओं की आयताकार रेंज को एक कोशिका में मिलाएँ। रेंज के शीर्ष‑बाएँ और नीचे‑दाएँ कोनों की कोशिकाओं को निर्दिष्ट करें। अंतिम तर्क नियंत्रित करता है कि क्या मर्ज निर्दिष्ट रेंज के बाहर की कोशिकाओं को शामिल कर सकता है; `false` मर्ज को उसी रेंज में रखता है।

उदाहरण 70‑पॉइंट कॉलम और पंक्तियों के साथ 4‑बाय‑4 तालिका बनाता है, फिर `(1, 1)` से `(2, 2)` तक के चार केंद्रित कोशिकाओं को मर्ज करता है। परिणामी कोशिका दो कॉलम और दो पंक्तियों को घेरती है, जबकि तालिका की मूल ग्रिड चार कॉलम और चार पंक्तियों को बनाए रखती है। मर्ज की गई कोशिका की सामग्री या स्वरूपण तक पहुंचने के लिए, उसके शीर्ष‑बाएँ स्थान का उपयोग करें: इस उदाहरण में `table[1, 1]`। मर्ज रेंज में अन्य स्थान तालिका ग्रिड का हिस्सा रहते हैं, इसलिए रेंज के बाहर की कोशिकाओं के संकेतक नहीं बदलते।

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

पिछले उदाहरण में कोशिकाओं को मर्ज करने से तालिका की ग्रिड बनी रहती है। एक कोशिका को विभाजित करना नई ग्रिड कॉलम जोड़ सकता है और दाईं ओर की कोशिकाओं के कॉलम संकेतकों को बदल सकता है। Aspose.Slides PowerPoint की तालिका ग्रिड मॉडल का पालन करता है।

यह उदाहरण 70‑पॉइंट कॉलम और पंक्तियों के साथ 4‑बाय‑4 तालिका बनाता है और कोशिका `(1, 1)` पर [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) को कॉल करता है। कोशिका की 70‑पॉइंट चौड़ाई का आधा दो समान‑चौड़ाई वाली कोशिकाएँ बनाने के लिए पास किया जाता है।

इस विभाजन के बाद, दो हिस्सों को `table[1, 1]` और `table[2, 1]` के रूप में पहुंचा जाता है। तालिका ग्रिड अब पाँच कॉलम रखती है: मूल रूप से कॉलम 2 और 3 में थीं वह क्रमशः कॉलम 3 और 4 में चली गईं। पंक्ति संकेतक अपरिवर्तित रहते हैं। विभाजन के बाद कोशिकाओं तक पहुंचते समय इन अपडेटेड कॉलम संकेतकों का उपयोग करें।

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

### **पंक्ति या कॉलम स्पैन द्वारा मर्ज की गई कोशिकाओं को विभाजित करें**

डेटा पोप्युलेशन के लिए मर्ज किए गए टेम्प्लेट कोशिकाओं को तैयार करने के लिए, मौजूदा पंक्तियों की सीमा के साथ विभाजित करने के लिए [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) का उपयोग करें, या कॉलम की सीमा के साथ विभाजित करने के लिए [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) का उपयोग करें।

`index` तर्क विभाजन के ऊपरी भाग में पंक्तियों या बाएँ भाग में कॉलमों की गिनती करता है; यह मर्ज क्षेत्र के सापेक्ष है:

- पंक्ति विभाजन: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/)।
- कॉलम विभाजन: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/)।

उदाहरण में यह अपेक्षित है कि प्रस्तुति की पहली स्लाइड पर पहला आकार एक तालिका हो, जिसमें `(1, 2)` और `(1, 3)` ऊर्ध्वाधर रूप से मर्ज हों। नीचे से शुरू करते हुए, यह [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) और [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) का उपयोग करके मूल स्थान ढूँढता है और दोनों स्पैन की जाँच करता है। `SplitByRowSpan(1)` फिर उत्पाद नामों के लिए पंक्तियों 2 और 3 को अलग करता है। क्षैतिज दो‑कॉलम मर्ज के लिए, `SplitByColSpan(1)` उपयोग करें।

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

    // विभाजन के बाद तालिका से प्राप्त कोशिकाओं को प्राप्त करें।
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

तालिका ग्रिड और आसपास की कोशिका संकेतक अपरिवर्तित रहते हैं। परिणामस्वरूप कोशिकाओं को उनके निर्देशांक से प्राप्त करें; यहाँ, दोनों की स्पैन 1 है और [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) `False` प्रिंट करता है। बड़े क्षेत्रों को एक विभाजन के बाद भी आंशिक रूप से मर्ज रखा जा सकता है।

मूल पाठ और उसका स्वरूपण ऊपर (या बाएँ) कोशिका में रहता है; नई कोशिका खाली है लेकिन भराव, सीमाएँ और मार्जिन जैसी कोशिका स्वरूपण को विरासत में लेती है। विभाजन के बाद कोशिकाओं को भरें और आवश्यक टेक्स्ट स्वरूपण स्पष्ट रूप से सेट करें।

सहेजी गई प्रस्तुति में अलग-अलग "Product A" और "Product B" कोशिकाएँ होती हैं, जिनमें टेम्प्लेट की कोशिका स्वरूपण बरकरार रहती है। विवरण के लिए [सेल API संदर्भ](https://reference.aspose.com/slides/net/aspose.slides/cell/) देखें.

<!-- visual-explanation:manage-cells:start -->
[![कॉलम 1, पंक्तियों 2 और 3 में मर्ज की गई कोशिका समान ग्रिड संकेतकों के साथ Product A और Product B में विभाजित होती है।](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*पंक्ति‑स्पैन विभाजन मौजूदा सीमा का उपयोग करता है। Product A और Product B क्रमशः (1, 2) और (1, 3) में स्थित होते हैं।*
<!-- visual-explanation:manage-cells:end -->

### **विशिष्ट ऊँचाई पर एक कोशिका को विभाजित करें**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) ऊपरी भाग की ऊँचाई बिंदुओं में लेता है। [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) ऊपरी भाग में मौजूदा ग्रिड पंक्तियों की संख्या लेता है। दाएँ कॉलम में 40‑पॉइंट कोशिका को केंद्रित करने के लिए, कोशिका की वास्तविक ऊँचाई से 40 घटाएँ और बचा हुआ स्थान बराबर ऊपर और नीचे विभाजित करें।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

पहला विभाजन एक ग्रिड पंक्ति जोड़ता है, जिससे नीचे की 90 पॉइंट `[1, 1]` पर रह जाती है। दूसरा विभाजन उस कोशिका को लक्षित करता है और उसके नीचे एक और पंक्ति जोड़ता है। दाएँ कॉलम में अब `[1, 0]` 50 पॉइंट (`margin`) पर, `[1, 1]` 40 पॉइंट पर, और `[1, 2]` 50 पॉइंट (`margin`) पर है। बाएँ कोशिका अपनी मूल 140 पॉइंट ऊँचाई पर सभी तीन पंक्तियों को घेरती है।

![बाएँ कोशिका पूरी तालिका की ऊँचाई को घेरती है, जबकि मध्य में तीन कोशिकाएँ हैं।](split-by-height.png)

## **तालिका कोशिका की पृष्ठभूमि रंग बदलें**

यह उदाहरण 150‑पॉइंट कॉलम और 50‑पॉइंट पंक्तियों वाली तालिका बनाता है। यह कोशिका `(2, 3)` (तीसरा कॉलम और चौथी पंक्ति) के लिए [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) को सॉलिड और [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) को लाल सेट करता है।

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

## **तालिका कोशिका के भीतर एक छवि जोड़ें**

इस उदाहरण को चलाने से पहले इनपुट छवि को कार्य निर्देशिका में रखें। यह छवि को [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) से लोड करता है और उसे प्रस्तुति की इमेज कलेक्शन में [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) के साथ जोड़ता है। फिर यह छवि को कोशिका `(0, 0)` (तालिका की पहली कोशिका) के पिक्चर फ़िल में असाइन करता है।

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) छवि को कोशिका भरने के लिए खींचता है, जिससे उसका अनुपात बदल सकता है। कॉलम की चौड़ाई और पंक्तियों की ऊँचाई बिंदुओं में हैं। लोड की गई छवि उसका उपयोग करने वाले अभिव्यक्ति द्वारा स्वतः नष्ट कर दी जाती है।

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

हाँ। [ऊपर](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[नीचे](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[बाएँ](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[दाएँ](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) सीमाओं की अलग‑अलग प्रॉपर्टी होती हैं, इसलिए प्रत्येक पक्ष की मोटाई और शैली भिन्न हो सकती है।

**यदि मैं कोशिका की पृष्ठभूमि में चित्र सेट करने के बाद कॉलम/पंक्ति का आकार बदलूँ तो छवि के साथ क्या होता है?**

व्यवहार [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेच करने पर, छवि नए कोशिका के अनुसार समायोजित होती है; टाइल करने पर, टाइलों की गणना पुनः की जाती है।

**क्या मैं कोशिका की सभी सामग्री को एक हायपरलिंक असाइन कर सकता हूँ?**

[Hyperlinks](/slides/hi/net/manage-hyperlinks/) को कोशिका के टेक्स्ट फ्रेम के भीतर टेक्स्ट (portion) स्तर या पूरी तालिका/आकार स्तर पर सेट किया जाता है। व्यवहार में, आप लिंक को किसी हिस्से या पूरी कोशिका के सभी टेक्स्ट को असाइन करते हैं।

**क्या मैं एक ही कोशिका में विभिन्न फ़ॉन्ट सेट कर सकता हूँ?**

हाँ। एक कोशिका का टेक्स्ट फ्रेम [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (रन) को स्वतंत्र स्वरूपण—फ़ॉन्ट परिवार, शैली, आकार, और रंग—के साथ समर्थन करता है।