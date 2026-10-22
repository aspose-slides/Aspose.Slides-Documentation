---
title: .NET में प्रस्तुति चार्ट को फ़ॉर्मेट करें
linktitle: चार्ट फ़ॉर्मेटिंग
type: docs
weight: 60
url: /hi/net/chart-formatting/
keywords:
- चार्ट फ़ॉर्मेट
- चार्ट फ़ॉर्मेटिंग
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
description: "Aspose.Slides for .NET में चार्ट फ़ॉर्मेटिंग सीखें और कस्टम अक्षों, फ़ॉन्ट्स, संख्या फ़ॉर्मेट्स और गोल चार्ट किनारों के साथ अपनी PowerPoint प्रस्तुति को उन्नत बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट को फ़ॉर्मेट करने के तरीके को समझाता है। यह अक्ष, ग्रिड लाइनों, शीर्षक, लीजेंड, प्लॉट एरिया, और वॉल फ़िल्स जैसे मुख्य चार्ट तत्वों को अनुकूलित करके चार्ट डेटा की उपस्थिति और पठनीयता को सुधारने का प्रदर्शन करता है।

यह साथ ही चार्ट टेक्स्ट के लिए फ़ॉन्ट गुण सेट करने, चार्ट डेटा पर पूर्वनिर्धारित संख्यात्मक फ़ॉर्मेट लागू करने, और चार्ट एरिया के कोनों को गोल करने का भी उदाहरण दिखाता है। ये सभी उदाहरण प्रस्तुतिकरण में चार्ट की दृश्य शैली और डेटा प्रस्तुति दोनों को नियंत्रित करने में मदद करते हैं।

## **चार्ट इकाइयों को फ़ॉर्मेट करें**

[IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) का उपयोग करके चार्ट शीर्षक, अक्ष, ग्रिड लाइनों, लीजेंड और प्लॉट एरिया को फ़ॉर्मेट करें। यह उदाहरण मार्कर वाला एक लाइन चार्ट बनाता है और उसके मान और वर्गीकरण अक्षों पर अलग‑अलग टेक्स्ट और लाइन शैलियाँ लागू करता है। फ़ॉन्ट आकार और लाइन चौड़ाई पॉइंट्स में निर्दिष्ट की गई हैं; वर्गीकरण लेबल 45 डिग्री से घुमाए गए हैं।

मान अक्ष [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) का उपयोग करता है, चाहे स्रोत सेल्स कुछ भी हों। इसका स्केल -2 से 15 तक है, मुख्य अंतराल 2 और गौण अंतराल 0.5 है। यह उदाहरण प्रतिशत फ़ॉर्मेट को [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) के साथ हजारों पर सेट करने को भी दिखाता है, इसलिए इन सेटिंग्स को अपने डेटा के अर्थ और परिमाण के अनुसार समायोजित करें। लीजेंड प्लॉट एरिया के बाहर रहता है क्योंकि [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) निष्क्रिय है। बैक‑वाल और फ़्लोर फ़िल्स को [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) और [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/) के माध्यम से कॉन्फ़िगर किया जाता है, लेकिन ये सतहें केवल 3D चार्ट में दिखाई देती हैं।

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

## **एक चार्ट के लिए फ़ॉन्ट गुण सेट करें**

[Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/) के माध्यम से चार्ट टेक्स्ट के लिए डिफॉल्ट फ़ॉन्ट आकार सेट करें। यह उदाहरण 20‑पॉइंट फ़ॉन्ट के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और प्रथम सीरीज़ के लिए [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) के जरिए मान लेबल सक्षम करता है। अपने स्पष्ट फ़ॉन्ट सेटिंग वाले टेक्स्ट तत्व चार्ट के डिफॉल्ट को ओवरराइड कर सकते हैं।

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

## **संख्यात्मक फ़ॉर्मेट सेट करें**

[IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) का उपयोग करके चार्ट वर्कबुक सेल्स पर निर्मित संख्या फ़ॉर्मेट लागू करें। यह उदाहरण डिफॉल्ट, सेल‑बैक्ड डेटा वाला एक क्लस्टर्ड कॉलम चार्ट बनाता है और प्रत्येक सीरीज़ मान सेल पर फ़ॉर्मेट इंडेक्स 10 (`0.00%`) लागू करता है। यह वर्कबुक में मानों को बदले बिना उनके प्रदर्शन को बदलता है; उदाहरण के लिए, 0.25 को 25.00% दिखाया जाता है। अक्ष और डेटा‑लेबल फ़ॉर्मेट को अलग‑अलग कॉन्फ़िगर किया जा सकता है।

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

निम्न तालिका में इंग्लिश (United States) लोकैल के लिए प्रतिनिधि Excel फ़ॉर्मेट्स के साथ अंतर्निहित संख्या फ़ॉर्मेट इंडेक्स दर्शाए गए हैं। वास्तविक फ़ॉर्मेट स्ट्रिंग्स और उनका प्रदर्शन आवेदन और लोकैल के अनुसार बदल सकता है, विशेष रूप से मुद्रा और तिथियों के लिए। कुछ Excel फ़ॉर्मेट्स OOXML मानक के डिफॉल्ट से भी भिन्न होते हैं, जैसा कि [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) में वर्णित है।

| सूचकांक | फ़ॉर्मेट |
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

## **चार्ट क्षेत्र में गोल किनारे सेट करें**

[IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) को सक्षम करके चार्ट क्षेत्र के कोनों को गोल बनाएं। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) का उपयोग करके उसकी रूपरेखा को ठोस ग्रे रंग और एकल‑लाइन शैली देता है, फिर प्रस्तुतिकरण को सहेजता है।

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

एक चार्ट में कस्टम श Shapes जैसे टेक्स्ट एनोटेशन हो सकते हैं, जो रिपोर्ट की स्थिति समझाते हैं। इन्हें आप [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/) के माध्यम से प्राप्त कर सकते हैं, जो [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) में भी सूचीबद्ध है। इसका [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) संग्रह चार्ट‑स्वामित्व वाले Shapes को रखता है।

एक सामान्य टेक्स्ट बॉक्स जो चार्ट के ऊपर रखा हो, वह स्लाइड का हिस्सा होता है, भले ही वह चार्ट का हिस्सा दिखे। [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) के माध्यम से इटरेट करने पर चार्ट और सामान्य स्लाइड श Shapes मिलते हैं, लेकिन चार्ट के भीतर की व्यक्तिगत श Shapes नहीं मिलतीं। चार्ट शीर्षक और डेटा लेबल अलग‑अलग चार्ट तत्व होते हैं, न कि इस संग्रह में कस्टम एनोटेशन।

डाउनलोड [chart-annotations.pptx](chart-annotations.pptx) और इसे एप्लिकेशन की कार्य निर्देशिका में रखें। इसकी पहली स्लाइड में एक चार्ट है जिसमें "Preliminary results" लिखा अनग्रुप्ड एनोटेशन, चार्ट‑स्वामित्व वाली एक लाइन, और "Slide overlay" लिखा सामान्य स्लाइड टेक्स्ट बॉक्स है। उदाहरण पहले चार्ट को खोजता है और रिपोर्ट तैयार होने पर एनोटेशन को "Final results" में बदल देता है। यह खाली संग्रह की जांच करता है और केवल उस [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) को संपादित करता है जिसके पास गैर‑null [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) और अपेक्षित टेक्स्ट हो।

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

लाइन और स्लाइड टेक्स्ट बॉक्स अपरिवर्तित रहते हैं। नीचे इनपुट और सहेजे हुए पुनःเปิดे गये परिणाम की छवियाँ दी गई हैं:

| संपादन से पहले | संपादन के बाद |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
उदाहरण केवल शीर्ष‑स्तर के चार्ट‑स्वामित्व वाले Shapes की जाँच करता है। यदि कोई एनोटेशन [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/) के भीतर है, तो उस समूह की [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) संग्रह को भी निरीक्षित करें। नेस्टेड समूहों के लिये इसे पुनरावृत्त रूप से करें, और उनके चाइल्ड श Shapes पर समान टेक्स्ट जाँच लागू करें। एक समूह स्वयं एक कंटेनर है; इसे टेक्स्ट बॉक्स के रूप में न मानें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कॉलम/एरिया के लिए अर्ध‑पारदर्शी फ़िल्स सेट कर सकता हूँ जबकि बॉर्डर अपरदर्शी बना रहे?**

हाँ। फ़िल ट्रांसपेरेंसी और आउटलाइन को अलग‑अलग कॉन्फ़िगर किया जाता है। यह ग्रिड और डेटा की पठनीयता को बढ़ाने में उपयोगी है।

**डेटा लेबल्स ओवरलैप होने पर मैं क्या करूँ?**

फ़ॉन्ट आकार कम करें, गैर‑आवश्यक लेबल घटकों को अक्षम करें (जैसे श्रेणियाँ), लेबल की स्थिति समायोजित करें, आवश्यक होने पर केवल चयनित बिंदुओं के लिए लेबल दिखाएँ, या फ़ॉर्मेट को “value + legend” में बदलें।

**क्या मैं सीरीज़ पर ग्रेडिएंट या पैटर्न फ़िल्स लागू कर सकता हूँ?**

हाँ। सीरीज़ ठोस, ग्रेडिएंट और पैटर्न फ़िल्स को सपोर्ट करती हैं। व्यावहारिक रूप से ग्रेडिएंट का प्रयोग कम करें और उन संयोजनों से बचें जो ग्रिड और टेक्स्ट के बीच कंट्रास्ट घटाते हैं।