---
title: .NET में प्रस्तुति चार्ट स्वरूपित करें
linktitle: चार्ट स्वरूपण
type: docs
weight: 60
url: /hi/net/chart-formatting/
keywords:
- चार्ट स्वरूप
- चार्ट स्वरूपण
- चार्ट इकाई
- चार्ट गुण
- चार्ट सेटिंग्स
- चार्ट विकल्प
- फ़ॉन्ट गुण
- गोल किनारा
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में चार्ट स्वरूपण सीखें और कस्टम अक्ष, फ़ॉन्ट, संख्यात्मक फ़ॉर्मेट और गोल चार्ट किनारों के साथ अपनी PowerPoint प्रस्तुति को उन्नत बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट को फ़ॉर्मेट करने की विधि समझाता है। यह दिखाता है कि अक्ष, ग्रिड रेखाएँ, शीर्षक, लीजेंड, प्लॉट एरिया और दीवार भराव जैसे प्रमुख चार्ट तत्वों को कैसे अनुकूलित किया जाए ताकि चार्ट डेटा की उपस्थिति और पठनीयता में सुधार हो सके।

यह यह भी दर्शाता है कि चार्ट टेक्स्ट के लिए फ़ॉन्ट गुण कैसे सेट करें, चार्ट डेटा पर पूर्वनिर्धारित संख्यात्मक फ़ॉर्मेट लागू करें, और चार्ट एरिया के लिए गोल कोने सक्षम करें। इन उदाहरणों के माध्यम से आप प्रस्तुति में चार्ट की दृश्य शैली और डेटा प्रस्तुति दोनों को नियंत्रित कर सकते हैं।

ऊँची और गिरती अंतरालों पर अलग-अलग भराव और रूपरेखा के लिए देखें [stock chart example](/slides/hi/net/create-chart/#create-stock-charts)।

## **चार्ट इकाइयों को फ़ॉर्मेट करें**

चार्ट शीर्षक, अक्ष, ग्रिड रेखाएँ, लीजेंड और प्लॉट एरिया को फ़ॉर्मेट करने के लिए [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) का उपयोग करें। यह उदाहरण एक लाइन चार्ट को मार्कर और डिफ़ॉल्ट डेटा के साथ बनाता है, फिर इसके मान और श्रेणी अक्षों पर अलग-अलग टेक्स्ट और रेखा शैलियों को लागू करता है। फ़ॉन्ट आकार और रेखा चौड़ाई पॉइंट में निर्दिष्ट हैं; श्रेणी लेबल 45 डिग्री घुमाए गए हैं।

मान अक्ष [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) को स्रोत कोशिकाओं से स्वतंत्र रूप से उपयोग करता है। इसका स्केल -2 से 15 तक है, प्रमुख अंतराल 2 और मौलिक अंतराल 0.5 है। यह उदाहरण प्रतिशत फ़ॉर्मेट को [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) के हजार सेट के साथ संयोजित करता है, इसलिए इन सेटिंग्स को अपने डेटा के अर्थ और परिमाण के अनुसार अनुकूलित करें। लीजेंड प्लॉट एरिया के बाहर रहता है क्योंकि [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) निष्क्रिय है। बैक‑वॉल और फ़्लोर भराव को [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) और [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/) के माध्यम से कॉन्फ़िगर किया गया है, लेकिन ये सतहें केवल 3D चार्ट में ही दिखाई देती हैं।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
var chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

var valueAxisText = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
valueAxisText.FontBold = NullableBool.True;
valueAxisText.FontHeight = 16;
valueAxisText.FontItalic = NullableBool.True;
valueAxisText.FillFormat.FillType = FillType.Solid;
valueAxisText.FillFormat.SolidFillColor.Color = Color.DarkGreen;
valueAxisText.LatinFont = new FontData("Times New Roman");

chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
var valueAxisTitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valueAxisTitle.Text = "Primary Axis";
valueAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valueAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valueAxisTitle.PortionFormat.FontHeight = 20;
valueAxisTitle.PortionFormat.FontBold = NullableBool.True;
valueAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

var categoryAxisText = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
categoryAxisText.FontBold = NullableBool.True;
categoryAxisText.FontHeight = 16;
categoryAxisText.FontItalic = NullableBool.True;
categoryAxisText.FillFormat.FillType = FillType.Solid;
categoryAxisText.FillFormat.SolidFillColor.Color = Color.Blue;
categoryAxisText.LatinFont = new FontData("Arial");

chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

var categoryAxisTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
categoryAxisTitle.Text = "Sample Category";
categoryAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
categoryAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
categoryAxisTitle.PortionFormat.FontHeight = 20;
categoryAxisTitle.PortionFormat.FontBold = NullableBool.True;
categoryAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

var legendText = chart.Legend.TextFormat.PortionFormat;
legendText.FontBold = NullableBool.True;
legendText.FontHeight = 16;
legendText.FontItalic = NullableBool.True;
legendText.FillFormat.FillType = FillType.Solid;
legendText.FillFormat.SolidFillColor.Color = Color.DarkRed;

chart.Legend.Overlay = false;

chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;

chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

presentation.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **चार्ट के लिए फ़ॉन्ट गुण सेट करें**

चार्ट टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट आकार को [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/) के माध्यम से सेट करें। यह उदाहरण 20‑पॉइंट फ़ॉन्ट के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और पहले श्रृंखला के लिए [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) के माध्यम से मान लेबल सक्षम करता है। अपने स्वयं के स्पष्ट फ़ॉन्ट सेटिंग वाले टेक्स्ट तत्व चार्ट डिफ़ॉल्ट को ओवरराइड कर सकते हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
chart.TextFormat.PortionFormat.FontHeight = 20;
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
```

## **चार्ट लीजेंड के लिए टेक्स्ट फ्रेम फ़ॉर्मेटिंग को पुन: प्रयुक्त करें**

लीजेंड को स्लाइड शीर्षक से मिलाने के लिए पहले पैराग्राफ के [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) में फ़ॉन्ट सेट करें। लीजेंड के [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformattedtextcontainer/textformat/) पर [CopyFrom](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyfrom/) कॉल करें। यह टेक्स्ट फ्रेम सेटिंग्स, पहले पैराग्राफ का फ़ॉर्मेट, और उस पैराग्राफ के डिफ़ॉल्ट फ़ॉन्ट गुण पढ़ता है। व्यक्तिगत भागों या बाद के पैराग्राफों पर सीधे लागू फ़ॉर्मेटिंग स्रोत तक ही सीमित रहती है।

उदाहरण में नेवी रंग में 26‑पॉइंट कैलिब्री बोल्ड शीर्षक को टेम्पलेट के रूप में उपयोग किया गया है। लीजेंड को स्टाइल करने के बाद, वही फ़ॉर्मेटिंग एक अलग कैप्शन पर लागू करने के लिए [CopyTo](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyto/) का उपयोग किया जाता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var heading = shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
var sourceTextFrame = heading.AddTextFrame("Quarterly sales");
var font = sourceTextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
font.LatinFont = new FontData("Calibri");
font.FontHeight = 26;
font.FontBold = NullableBool.True;
font.FillFormat.FillType = FillType.Solid;
font.FillFormat.SolidFillColor.Color = Color.FromArgb(32, 64, 96);

var chart = shapes.AddChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
chart.Style = StyleType.Style3;
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.GetCell(0, 0, 1).Value = "Retail";
workbook.GetCell(0, 0, 2).Value = "Online";
workbook.GetCell(0, 0, 3).Value = "Wholesale";
for (var quarter = 1; quarter <= 4; quarter++)
    workbook.GetCell(0, quarter, 0).Value = $"Q{quarter}";

chart.HasLegend = true;
chart.Legend.Position = LegendPositionType.Bottom;
chart.Legend.TextFormat.CopyFrom(sourceTextFrame);

var caption = shapes.AddAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
var captionTextFrame = caption.AddTextFrame("Sales in millions of dollars");
chart.Legend.TextFormat.CopyTo(captionTextFrame);

presentation.Save("legend-formatting.pptx", SaveFormat.Pptx);
```

सहेजे गए प्रस्तुतीकरण में, लीजेंड और कैप्शन आकार, भार और रंग में शीर्षक से मेल खाते हैं। लीजेंड अभी भी श्रृंखला नाम दिखाता है, और कैप्शन अपना स्वयं का टेक्स्ट रखता है। यदि कैप्शन में किसी भाग का स्पष्ट फ़ॉन्ट आकार पहले से निर्धारित है, तो वह आकार कॉपी किए गए पैराग्राफ डिफ़ॉल्ट पर प्राथमिकता रखता है।

| कॉपी करने से पहले | कॉपी करने के बाद |
| --- | --- |
| ![Quarterly sales chart with regular black legend labels and a black caption](legend-formatting-before.png) | ![The same chart with larger, bold navy legend labels and a matching caption](legend-formatting.png) |

## **संख्यात्मक फ़ॉर्मेट सेट करें**

चार्ट वर्कबुक कोशिकाओं पर निर्मित संख्या फ़ॉर्मेट लागू करने के लिए [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट, सेल‑बैक्ड डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और प्रत्येक श्रृंखला मान कोशिका पर फ़ॉर्मेट इंडेक्स 10 (`0.00%`) लागू करता है। इससे वर्कबुक में मानों का प्रदर्शन बदलता है बिना मूल संख्याओं को बदले; उदाहरण के लिए, 0.25 को 25.00% दिखाया जाता है। अक्ष और डेटा‑लेबल फ़ॉर्मेट को अलग‑अलग कॉन्फ़िगर किया जा सकता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
var series = chart.ChartData.Series;

foreach (var chartSeries in series)
{
    foreach (var dataPoint in chartSeries.DataPoints)
    {
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

निम्न तालिका में इंग्लिश (United States) लोक्यल के लिए प्रतिनिधि Excel फ़ॉर्मेट के साथ निर्मित संख्या फ़ॉर्मेट इंडेक्स सूचीबद्ध हैं। सटीक फ़ॉर्मेट स्ट्रिंग और उनका प्रदर्शन एप्लिकेशन और लोक्यल के अनुसार बदल सकता है, विशेष रूप से मुद्रा और तिथियों के लिए। कुछ Excel फ़ॉर्मेट OOXML मानक के डिफ़ॉल्ट से भी भिन्न होते हैं, जैसा कि [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) में वर्णित है।

| Index | Format |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **चार्ट एरिया के गोल कोने सेट करें**

[ IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) को सक्षम करके चार्ट एरिया के कोनों को गोल किया जा सकता है। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) का उपयोग करके उसकी रूपरेखा को ठोस ग्रे रंग और सिंगल‑लाइन शैली देता है, फिर प्रस्तुति सहेजी जाती है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
chart.LineFormat.FillFormat.FillType = FillType.Solid;
chart.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chart.LineFormat.Style = LineStyle.Single;
chart.HasRoundedCorners = true;

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **मौजूदा चार्ट एनोटेशन संपादित करें**

एक चार्ट में कस्टम आकार हो सकते हैं, जैसे कि रिपोर्ट की स्थिति समझाने वाला टेक्स्ट एनोटेशन। इन आकारों तक पहुंचने के लिए [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/) का प्रयोग करें, जिसे चार्ट API रेफ़रेंस में [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) के अंतर्गत भी सूचीबद्ध किया गया है। इसका [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) संग्रह चार्ट‑स्वामित्व वाले आकारों को रखता है।

एक साधारण टेक्स्ट बॉक्स जो चार्ट के ऊपर रखा गया है, स्लाइड का हिस्सा होता है, भले ही वह चार्ट जैसा दिखे। [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) के माध्यम से इटरिंग करके चार्ट और सामान्य स्लाइड आकारों को पाया जाता है, लेकिन चार्ट के भीतर व्यक्तिगत आकारों को नहीं enumerated किया जाता। चार्ट शीर्षक और डेटा लेबल अलग‑अलग चार्ट तत्व होते हैं, न कि इस संग्रह में कस्टम एनोटेशन।

[chart-annotations.pptx](chart-annotations.pptx) डाउनलोड करके इसे एप्लिकेशन की कार्यशील डायरेक्ट्री में रखें। इसकी पहली स्लाइड में एक चार्ट है जिसमें अनग्रुप्ड एनोटेशन "Preliminary results", चार्ट‑स्वामित्व वाली रेखा, और एक सामान्य स्लाइड टेक्स्ट बॉक्स "Slide overlay" है। उदाहरण उस स्लाइड पर पहला चार्ट खोजता है और रिपोर्ट तैयार होने पर एनोटेशन को "Final results" में बदल देता है। यह खाली संग्रह की जांच करता है और केवल उन [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) को संपादित करता है जिनका [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) non‑null है और अपेक्षित टेक्स्ट है।

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-annotations.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.OfType<IChart>().FirstOrDefault();

if (chart == null || chart.UserShapes.Shapes.Count == 0)
{
    Console.WriteLine("No chart or chart-owned shapes found.");
    return;
}

var updated = false;
foreach (var shape in chart.UserShapes.Shapes)
{
    if (shape is IAutoShape annotation && 
        annotation.TextFrame != null && 
        annotation.TextFrame.Text == "Preliminary results")
    {
        annotation.TextFrame.Text = "Final results";
        updated = true;
        break;
    }
}

if (updated)
{
    presentation.Save("chart-annotations-updated.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No matching text annotation found.");
}
```

रेखा और स्लाइड टेक्स्ट बॉक्स अपरिवर्तित रहते हैं। निम्न छवियों में इनपुट और सहेजे गए, फिर से खोलने के परिणाम दिखाए गए हैं:

| संपादन से पहले | संपादन के बाद |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}

उदाहरण केवल शीर्ष‑स्तर के चार्ट‑स्वामित्व आकारों की जाँच करता है। यदि कोई एनोटेशन [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/) के अंदर है, तो उस समूह की [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) संग्रह की भी जाँच करें। नेस्टेड समूहों के लिए इस प्रक्रिया को पुनरावर्ती रूप से दोहराएँ, उनके चाइल्ड आकारों पर समान टेक्स्ट जांच लागू करें। एक समूह स्वयं एक कंटेनर है; इसे टेक्स्ट बॉक्स के रूप में न मानें।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कॉलम/एरिया के लिए अर्ध‑पारदर्शी भराव सेट कर सकता हूँ जबकि बॉर्डर अपारदर्शी रहे?**

हाँ। भराव की पारदर्शिता और रूपरेखा को अलग‑अलग कॉन्फ़िगर किया जाता है। यह घनी दृश्यांकन में ग्रिड और डेटा की पठनीयता बेहतर बनाने में उपयोगी है।

**डेटा लेबल ओवरलैप होने पर मैं कैसे निपटूँ?**

फ़ॉन्ट आकार घटाएँ, गैर‑आवश्यक लेबल घटकों (जैसे श्रेणियाँ) को निष्क्रिय करें, लेबल स्थिति समायोजित करें, आवश्यकता पड़ने पर केवल चयनित बिंदुओं के लिए लेबल दिखाएँ, या फ़ॉर्मेट को "value + legend" में बदलें।

**क्या मैं सीरीज़ पर ग्रेडिएंट या पैटर्न भराव लागू कर सकता हूँ?**

हाँ। सीरीज़ ठोस, ग्रेडिएंट और पैटर्न भराव का समर्थन करती है। व्यवहार में, ग्रेडिएंट का उपयोग सावधानी से करें और ऐसे संयोजनों से बचें जो ग्रिड और टेक्स्ट के बीच कंट्रास्ट कम कर दें।