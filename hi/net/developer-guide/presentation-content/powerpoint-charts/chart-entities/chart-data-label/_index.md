---
title: .NET में प्रस्तुति में चार्ट डेटा लेबल को प्रबंधित करें
linktitle: डेटा लेबल
type: docs
url: /hi/net/chart-data-label/
keywords:
- चार्ट
- डेटा लेबल
- डेटा सटीकता
- प्रतिशत
- लेबल दूरी
- लेबल स्थान
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों में Aspose.Slides for .NET का उपयोग करके चार्ट डेटा लेबल जोड़ने और स्वरूपित करने के बारे में जानें ताकि अधिक आकर्षक स्लाइड्स बनाई जा सकें।"
---
## **परिचय**

डेटा लेबल चार्ट सीरीज़ और व्यक्तिगत डेटा बिंदुओं के बारे में जानकारी प्रदर्शित करते हैं, जिससे पाठकों को मान पहचानने और चार्ट को समझने में मदद मिलती है। यह लेख बताता है कि मानों को कैसे स्वरूपित करें, प्रतिशत कैसे दिखाएँ, लेबल टेक्स्ट कैसे पढ़ें, अक्ष अधिकतम से परे लेबल को कैसे नियंत्रित करें, श्रेणी अक्ष लेबल अंतराल को कैसे समायोजित करें, और पाई चार्ट लेबल को कैसे स्थित करें।

## **Count Visible Data Labels**

प्रेसेंटेशन प्रकाशित करने से पहले कितने डेटा लेबल प्रदर्शित होने के लिए सक्षम हैं, यह जांचने के लिए [CountOfVisibleDataLabels](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/countofvisibledatalabels/) का उपयोग करें। यह [Count](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/count/) से अलग है, जो संग्रह में कुल लेबलों की संख्या लौटाता है; यह सीरीज़ डिफ़ॉल्ट्स और व्यक्तिगत लेबल सेटिंग्स को ध्यान में रखता है।

यह उदाहरण एक कॉलम चार्ट बनाता है जिसमें एक सीरीज़ और तीन डेटा बिंदु होते हैं। यह सीरीज़ की [Labels](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/labels/) संग्रह तक पहुँचता है और सेटिंग बदलने पर दिखाई देने वाली गिनती को प्रिंट करता है: **0, 3, 2, 3**। कुल गिनती **3** ही बनी रहती है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesCell = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

for (int i = 0; i < 3; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, (i + 1) * 10);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var labels = series.Labels;
Console.WriteLine($"Total: {labels.Count}; visible: {labels.CountOfVisibleDataLabels}"); // कुल: 3; दृश्य: 0

labels.DefaultDataLabelFormat.ShowValue = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // दृश्य: 3

labels[1].DataLabelFormat.ShowValue = false;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // दृश्य: 2

labels[1].DataLabelFormat.ShowLegendKey = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // दृश्य: 3
```

सीरीज़ की [DefaultDataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultdatalabelformat/) डिफ़ॉल्ट सेटिंग्स प्रदान करती है। वहाँ [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) को सक्षम करने से सभी तीन लेबलों के लिए मान प्रदर्शित होते हैं। इसे `false` पर सेट करने से एक लेबल की [DataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/datalabelformat/) के माध्यम से वह सेटिंग ओवरराइड हो जाती है। [ShowLegendKey](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showlegendkey/) को सक्षम करने से वह लेबल फिर से दृश्य माना जाता है, जबकि उसका मान अभी भी छुपा रहता है।

दिखाई देने वाली गिनती दृश्यता सेटिंग्स को दर्शाती है। यह यह माप नहीं करती कि लेबल ओवरलैप हो रहे हैं, कटे हुए हैं या रेंडर किए गए चार्ट में पढ़ने योग्य हैं।

## **Set Data Precision in Chart Data Labels**

सीरीज़ मानों को स्वरूपित करने के लिए [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, उसका डेटा तालिका दर्शाता है, और पहली सीरीज़ के लिए मान लेबल सक्षम करता है। स्वरूप `#,##0.00` हज़ारों विभाजक और दो दशमलव अंकों को दिखाता है बिना मूल मानों को बदले।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
chart.HasDataTable = true;

var series = chart.ChartData.Series[0];
series.NumberFormatOfValues = "#,##0.00";
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
```

चार्ट की एम्बेडेड वर्कबुक में संख्यात्मक सेल को स्वरूपित करने के लिए देखें [Set Custom Number Formats for Workbook Cells](/slides/hi/net/chart-workbook/#set-custom-number-formats-for-workbook-cells)। वह उदाहरण दिखाता है कि स्रोत सेल स्वरूपों के साथ लेबल मान कैसे दिखते हैं जबकि संग्रहीत संख्यात्मक मान बरकरार रहते हैं।

## **Display Percentage as Labels**

स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल का प्रतिशत गणना करें और पाठ को [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) में असाइन करें। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8 पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत दिखाता है। शून्य कुल वाली श्रेणियों को शून्य से भाग देना बचने के लिए छोड़ा जाता है। चार्ट डेटा बदलने पर कस्टम लेबल टेक्स्ट को पुनः गणना करें।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);

var categoryTotals = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        var series = chart.ChartData.Series[i];
        var pointValue = Convert.ToDouble(series.DataPoints[k].Value.Data);
        categoryTotals[k] += pointValue;
    }
}

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    var series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        var label = series.DataPoints[j].Label;
        if (categoryTotals[j] == 0)
        {
            continue;
        }

        var pointValue = Convert.ToDouble(series.DataPoints[j].Value.Data);
        var dataPointPercent = (pointValue / categoryTotals[j]) * 100;

        var portion = new Portion();
        portion.Text = string.Format("{0:F2} %", dataPointPercent);
        portion.PortionFormat.FontHeight = 8f;

        label.TextFrameForOverriding.Text = "";

        var paragraph = label.TextFrameForOverriding.Paragraphs[0];
        paragraph.Portions.Add(portion);

        label.DataLabelFormat.ShowValue = true;
        label.DataLabelFormat.ShowSeriesName = false;
        label.DataLabelFormat.ShowPercentage = false;
        label.DataLabelFormat.ShowLegendKey = false;
        label.DataLabelFormat.ShowCategoryName = false;
        label.DataLabelFormat.ShowBubbleSize = false;
    }
}

presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **Set Percentage Sign with Chart Data Labels**

जब मान अंश के रूप में संग्रहीत हों, तो प्रतिशत प्रदर्शित करने के लिए [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) का उपयोग करें। लेबल स्वरूप को स्रोत सेल से स्वतंत्र रूप से लागू करने के लिए [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) को `false` सेट करें।

यह उदाहरण चार श्रेणियों में लाल और नीली सीरीज़ के साथ 100% स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मान जोड़ी का योग 1 होता है। लेबल स्वरूप `0.0%` 0.30 को 30.0% के रूप में दिखाता है, जबकि वर्टिकल अक्ष दो दशमलव स्थान उपयोग करता है। दोनों सीरीज़ की लेबल टेक्स्ट सफेद, 10 पॉइंट की है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
int worksheetIndex = 0;
for (int i = 0; i < 4; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

string[] seriesNames = { "Reds", "Blues" };
Color[] seriesColors = { Color.Red, Color.Blue };
double[,] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

for (int i = 0; i < seriesNames.Length; i++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, i + 1, seriesNames[i]);
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);
    for (int j = 0; j < 4; j++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, j + 1, i + 1, values[i, j]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColors[i];

    var labelFormat = series.Labels.DefaultDataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = false;
    labelFormat.NumberFormat = "0.0%";
    labelFormat.TextFormat.PortionFormat.FontHeight = 10;
    labelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
}

presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **Read the Actual Text of Data Labels**

डेटा लेबल की सेटिंग्स द्वारा उत्पन्न टेक्स्ट को प्राप्त करने के लिए [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) का उपयोग करें। यह रिपोर्ट के लिए लेबल निकालते समय, प्रस्तुति सामग्री खोजते समय, या उत्पन्न चार्ट की वैधता जाँचते समय उपयोगी है। नीचे के उदाहरण में, डिफ़ॉल्ट [data label format](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) प्रत्येक श्रेणी नाम, सीरीज़ नाम और मान को संयोजित करता है। एक बिंदु अपना मान प्रतिशत के रूप में स्वरूपित करता है, और दूसरा [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) से कस्टम टेक्स्ट उपयोग करता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));

var north = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "North"), chart.Type);
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 0.25));
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 0.75));

var south = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "South"), chart.Type);
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 0.40));
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 0.60));

foreach (var series in chart.ChartData.Series)
{
    var format = series.Labels.DefaultDataLabelFormat;
    format.ShowCategoryName = true;
    format.ShowSeriesName = true;
    format.ShowValue = true;
}

north.Labels[1].DataLabelFormat.IsNumberFormatLinkedToSource = false;
north.Labels[1].DataLabelFormat.NumberFormat = "0%";
south.Labels[0].TextFrameForOverriding.Text = "Reviewed";

foreach (var series in chart.ChartData.Series)
{
    foreach (var point in series.DataPoints)
    {
        var label = point.Label;
        if (!label.IsVisible)
        {
            continue;
        }

        Console.WriteLine($"Value: {point.Value.Data}; label: {label.GetActualLabelText()}");
    }
}
```

डेटा बिंदु में संग्रहीत संख्या `0.75` बनी रहती है, भले ही उसका लेबल `75%` दिखाए साथ में श्रेणी और सीरीज़ नाम। कस्टम टेक्स्ट उत्पन्न लेबल टेक्स्ट को प्रतिस्थापित करता है। दोनों मामलों में [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) परिणामी लेबल स्ट्रिंग लौटाता है। जैसा कि ऊपर दिखाया गया है, लेबल केवल दृश्य होने पर निकालने के लिए [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) को अलग से जांचें।

## **Control Data Labels Beyond the Axis Maximum**

जब आप मैन्युअली एक अक्ष सीमा सीमित करते हैं, तो कुछ डेटा बिंदु उसकी अधिकतम सीमा से अधिक हो सकते हैं। क्या लेबल दिखाए जाएँ, यह नियंत्रित करने के लिए [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) का उपयोग करें। यह सेटिंग लेबल दृश्यता को बदलती है; यह अक्ष सीमा या मूल डेटा मानों को नहीं बदलती।

नीचे का उदाहरण 60 और 120 मूल्यों के साथ एक 2D क्लस्टर्ड कॉलम चार्ट बनाता है। यह वर्टिकल अक्ष पर [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) को `false` और [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) को 100 पर सेट करता है। पहली स्लाइड अधिकतम से परे लेबल की अनुमति देती है; उसकी एक कॉपी इन लेबल को निष्क्रिय करती है। दोनों स्लाइड `DataLabelsOverMaximum.pptx` में सहेजी जाती हैं।

[ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) के साथ मान लेबल सक्षम करें। चार्ट-स्तर की सेटिंग स्वयं मान प्रदर्शित नहीं करती या व्यक्तिगत लेबल की निष्क्रिय मान प्रदर्शनी को ओवरराइड नहीं करती। यह उदाहरण पूरी सीरीज़ के लिए मान सक्षम करता है और [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) का उपयोग करके प्रत्येक कॉलम के बाहरी सिरे पर लेबल रखता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var firstCategory = workbook.GetCell(0, 1, 0, "Within range");
var secondCategory = workbook.GetCell(0, 2, 0, "Above maximum");

chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);

var seriesName = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);

var firstValue = workbook.GetCell(0, 1, 1, 60);
var secondValue = workbook.GetCell(0, 2, 1, 120);

series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;

chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 100;
chart.ShowDataLabelsOverMaximum = true;

var secondSlide = presentation.Slides.AddClone(slide);
var secondChart = (IChart)secondSlide.Shapes[0];
secondChart.ShowDataLabelsOverMaximum = false;

presentation.Save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
```

निम्न छवियाँ Microsoft PowerPoint द्वारा रेंडर किए गए सहेजे गए स्लाइड दिखाती हैं। `true` के साथ लेबल **120** ऊपर की सीमा पर दिखाई देता है; `false` के साथ वह छिपा रहता है। लेबल **60** दिखाई रहता है, अक्ष अधिकतम **100** पर बना रहता है, और दूसरा डेटा बिंदु दोनों मामलों में **120** ही रहता है।

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}

This example uses a 2D column chart with a value axis. Charts without a value axis, such as pie and doughnut charts, do not have an axis maximum to limit in this way.

{{% /alert %}}

## **Set Label Distance from an Axis**

श्रेणी अक्ष लेबल और अक्ष के बीच की दूरी नियंत्रित करने के लिए [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) का उपयोग करें। यह मान अक्ष लेबलों के अधिकतम फ़ॉन्ट आकार का प्रतिशत होता है। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और हॉरिज़ेंटल अक्ष लेबल ऑफ़सेट को 500 पर सेट करता है। यह सेटिंग व्यक्तिगत डेटा बिंदुओं से जुड़े लेबलों के बजाय श्रेणी अक्ष लेबलों को प्रभावित करती है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
chart.Axes.HorizontalAxis.LabelOffset = 500;

presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **Adjust Label Location**

पाई चार्ट पर, डेटा लेबल की स्थितियों को समायोजित करके स्पेसिंग बेहतर करें और लीडर लाइनों के लिए जगह बनाएं।

यह उदाहरण पहले डेटा बिंदु का मान दर्शाता है, उसका लेबल स्लाइस के बाहर रखता है, और उसके [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) तथा [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) ऑफ़सेट को समायोजित करता है। ये ऑफ़सेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के सापेक्ष होते हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);
var series = chart.ChartData.Series;

var label = series[0].Labels[0];
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
label.X = 0.71f;
label.Y = 0.04f;

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **Format Leader Lines**

जब पाई चार्ट लेबल अपने स्लाइस के बाहर स्थित होते हैं, तो लीडर लाइन्स प्रत्येक मान को सही स्लाइस से मिलाने में मदद करती हैं। कंट्रास्टिंग रंग और थोड़ी मोटी लाइन इन कनेक्शनों को पढ़ने में आसान बनाती है, जबकि ट्रांसपेरेंसी और डैश्ड स्टाइल लाइनों को दिखने में कम बाधा बनाते हैं।

सीरीज़ के डेटा लेबल संग्रह स्तर पर लीडर लाइन्स को स्वरूपित करने के लिए [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) का उपयोग करें। `series.Labels.LeaderLinesFormat.Line` में सेटिंग्स संग्रह पर लागू होती हैं, व्यक्तिगत लेबल पर नहीं।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है, स्लाइस के बाहर मान दिखाता है, और [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/) को सक्षम करता है। यह दो लेबल को उनके स्लाइस से अधिक दूर ले जाने के लिए [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) और [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) ऑफ़सेट का उपयोग करता है, जो चार्ट की चौड़ाई और ऊँचाई के अनुपात में होते हैं। कोई इनपुट प्रस्तुति आवश्यक नहीं है।

लाइन का [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) एक ठोस नीला रंग सेट करता है जिसमें 255 में से 191 का अल्फा मान है, जो लगभग 25% ट्रांसपेरेंसी देता है। [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) मोटाई को 2 पॉइंट सेट करता है, और [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) लाइन को डैश्ड बनाता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 80, 50, 560, 400);
chart.HasLegend = false;

var series = chart.ChartData.Series[0];

var labelFormat = series.Labels.DefaultDataLabelFormat;
labelFormat.ShowValue = true;
labelFormat.Position = LegendDataLabelPosition.OutsideEnd;
labelFormat.ShowLeaderLines = true;

// दो लेबलों को उनके स्लाइस से अधिक दूर ले जाएँ।
series.Labels[0].X = 0.10f;
series.Labels[0].Y = -0.05f;
series.Labels[1].X = -0.10f;
series.Labels[1].Y = 0.05f;

var line = series.Labels.LeaderLinesFormat.Line;
line.FillFormat.FillType = FillType.Solid;
line.FillFormat.SolidFillColor.Color = Color.FromArgb(191, 30, 90, 160);
line.Width = 2;
line.DashStyle = LineDashStyle.Dash;

presentation.Save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
```

लीडर लाइन्स को सक्षम करना यह गारंटी नहीं देता कि हर लेबल के लिए लाइन दिखाई देगी। दृश्यता लेबल की स्थितियों और चार्ट के लेआउट व्यवहार पर निर्भर करती है। इस उदाहरण में, दो विस्थापित लेबल के लिए दृश्य लीडर लाइन्स हैं; जो लेबल अपने स्लाइस के पास रहते हैं, उनके लिए लाइन्स आवश्यक नहीं होतीं।

निम्न छवि में `FormattedLeaderLines.pptx` को Aspose.Slides द्वारा रेंडर किया गया दिखाया गया है:

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **Add Multiple Rows of Data Labels Above a Column Chart**

यह उदाहरण दो पंक्तियों के डेटा लेबल के साथ एक कॉलम चार्ट बनाता है, जो प्लॉट एरिया के ऊपर स्थित होते हैं। सीरीज़ A दिखाई देने वाले कॉलम दिखाता है, जबकि सीरीज़ B और सीरीज़ C अतिरिक्त लेबल प्रदान करती हैं। उनके कॉलम को फिल और आउटलाइन हटाकर छुपा दिया जाता है। सभी तीन सीरीज़ को समान श्रेणी केंद्रों के साथ संरेखित करने के लिए [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) प्रॉपर्टी का उपयोग किया गया है।

[PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) सेटिंग्स लेबल पंक्तियों के लिए स्थान आरक्षित करती हैं। [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) डिफ़ॉल्ट स्थितियों की गणना करने के बाद, [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) और [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) क्षैतिज संरेखण को बरकरार रखते हुए ऊर्ध्वाधर ऑफ़सेट लागू करते हैं ताकि लेबल दो पंक्तियों में व्यवस्थित हो सकें। संख्याएँ सीरीज़ मानों से जुड़ी डेटा लेबल बनी रहती हैं; केवल पंक्ति शीर्षक अलग टेक्स्ट शेप होते हैं।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
chart.HasTitle = false;
chart.HasLegend = false;
chart.TextFormat.PortionFormat.FontHeight = 12;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

string[] categories = { "North", "South", "East", "West" };
string[] seriesNames = { "Series A", "Series B", "Series C" };
double[,] seriesValues = {
    { 35, 42, 28, 47 },
    { 22, 31, 19, 26 },
    { 12, 16, 14, 18 }
};

for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
{
    var categoryCell = workbook.GetCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
    chart.ChartData.Categories.Add(categoryCell);
}

for (int seriesIndex = 0; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var seriesCell = workbook.GetCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
    var series = chart.ChartData.Series.Add(seriesCell, ChartType.ClusteredColumn);

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var valueCell = workbook.GetCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    if (seriesIndex > 0)
    {
        // B और C की कॉलम को छुपाएँ, लेकिन उनके डेटा लेबल रखें।
        series.Format.Fill.FillType = FillType.NoFill;
        series.Format.Line.FillFormat.FillType = FillType.NoFill;
        var labelFormat = series.Labels.DefaultDataLabelFormat;
        labelFormat.ShowValue = true;
        labelFormat.TextFormat.PortionFormat.FontHeight = 12;
        var labelFill = labelFormat.TextFormat.PortionFormat.FillFormat;
        labelFill.FillType = FillType.Solid;
        labelFill.SolidFillColor.Color = Color.Black;
        labelFormat.Position = LegendDataLabelPosition.InsideBase;
    }
}

// तीनों सीरीज़ को समान श्रेणी केंद्रों के साथ संरेखित करें।
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// इस संक्षिप्त उदाहरण के लिए कम ग्रिडलाइन उपयोग करें।
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// डेटा लेबल की दो पंक्तियों के लिए प्लॉट के ऊपर स्थान आरक्षित करें।
chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
chart.PlotArea.X = 0.15f;
chart.PlotArea.Y = 0.32f;
chart.PlotArea.Width = 0.80f;
chart.PlotArea.Height = 0.48f;
chart.ValidateChartLayout();

for (int seriesIndex = 1; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var dataLabel = series.DataPoints[categoryIndex].Label;
        // डिफ़ॉल्ट क्षैतिज स्थिति रखें। Y एक ऑफ़सेट है
        // डिफ़ॉल्ट लेबल स्थिति से, जिसे चार्ट-ऊँचाई के अंश के रूप में व्यक्त किया गया है।
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // केवल पंक्ति शीर्षक एक अलग टेक्स्ट आकार है।
    var rowHeading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, chart.X, chart.Y + rowTop * chart.Height, 85, 18);
    rowHeading.FillFormat.FillType = FillType.NoFill;
    rowHeading.LineFormat.FillFormat.FillType = FillType.NoFill;
    rowHeading.AddTextFrame(seriesNames[seriesIndex]);
    rowHeading.TextFrame.TextFrameFormat.MarginTop = 0;
    rowHeading.TextFrame.TextFrameFormat.MarginBottom = 0;
    var headingFormat = rowHeading.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    headingFormat.FontHeight = 12;
    headingFormat.FillFormat.FillType = FillType.Solid;
    headingFormat.FillFormat.SolidFillColor.Color = Color.Black;
}

presentation.Save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
```

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **Change Data Label Shapes**

Aspose.Slides for .NET 26.11 ने एक लेबल के लिए [IDataLabel.LabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/labelshapetype/) और सीरीज़ में सभी वर्तमान लेबलों के लिए [IDataLabelCollection.DefaultLabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultlabelshapetype/) जोड़ा है। ये लेबल की शंकु (shape) बदलते हैं, बिंदु मार्कर नहीं। अलग कॉलआउट सेटिंग के लिए देखें [Data Label Callouts](/slides/hi/net/callout/)।

संग्रह असाइनमेंट मौजूदा लेबलों को अपडेट करती है, इसलिए व्यक्तिगत ओवरराइड **संग्रह सेटिंग के बाद** लागू करें। यह पूरा उदाहरण [Aspose.Slides for .NET](/slides/hi/net/installation/) 26.11 या बाद के संस्करण की आवश्यकता रखता है। यह दृश्य मान लेबल बनाता है, पहली सीरीज़ के लिए एलिप्स चुनता है और फिर उसके पहले लेबल को आयताकार बनाता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var labels = chart.ChartData.Series[0].Labels;
labels.DefaultDataLabelFormat.ShowValue = true;
labels.DefaultLabelShapeType = ShapeType.Ellipse;
labels[0].LabelShapeType = ShapeType.Rectangle;

foreach (var label in labels)
{
    var format = label.DataLabelFormat.Format;
    format.Fill.FillType = FillType.Solid;
    format.Fill.SolidFillColor.Color = Color.LightYellow;
    format.Line.FillFormat.FillType = FillType.Solid;
    format.Line.FillFormat.SolidFillColor.Color = Color.DarkBlue;
}

presentation.Save("label-shapes.pptx", SaveFormat.Pptx);

// सभी वर्तमान लेबलों पर स्पष्ट रूप से निर्दिष्ट आकार विकल्प रीसेट करें।
labels.DefaultLabelShapeType = ShapeType.NotDefined;
presentation.Save("label-shapes-reset.pptx", SaveFormat.Pptx);
```

संग्रह आकार को फिर से असाइन करने से पहले के व्यक्तिगत आकार चयन भी बदल जाते हैं। [NotDefined](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) स्पष्ट आकार चयन को साफ़ करता है; यह लेबल को छुपाता नहीं है या अन्य स्वरूपण को नहीं हटाता। सीरीज़ को भरने के बाद वांछित आकार सेट करें, यह मानते हुए कि बाद में जोड़े गए बिंदु पहले के असाइनमेंट को विरासत में नहीं लेते। यहाँ आयत और एलिप्स उपयोग किए गए हैं; अन्य आकार प्रकार चुनते समय रेंडर परिणाम जांचें।

## **FAQ**

**मैं घनी चार्ट में डेटा लेबल के ओवरलैप को कैसे रोकूँ?**

ऑटोमैटिक लेबल प्लेसमेंट, लीडर लाइन्स, और छोटा फ़ॉन्ट आकार मिलाकर उपयोग करें; आवश्यक होने पर कुछ फ़ील्ड (जैसे श्रेणी) छिपाएँ या केवल चरम मान या मुख्य बिंदुओं के लिए लेबल दिखाएँ।

**मैं शून्य, नकारात्मक या खाली मानों के लिए लेबल केवल कैसे अक्षम करूँ?**

लेबल सक्षम करने से पहले डेटा बिंदुओं को फ़िल्टर करें और 0, नकारात्मक या अनुपलब्ध मानों के लिए डिस्प्ले बंद करें, एक परिभाषित नियम के अनुसार।

**PDF/इमेज एक्सपोर्ट पर लगातार लेबल स्टाइल कैसे सुनिश्चित करूँ?**

फ़ॉन्ट परिवार और आकार को स्पष्ट रूप से सेट करें और रेंडरिंग वातावरण में फ़ॉन्ट उपलब्धता जाँचें ताकि फ़ॉलबैक से बचा जा सके।