---
title: ".NET में प्रस्तुतियों में चार्ट डेटा लेबल प्रबंधित करें"
linktitle: "डेटा लेबल"
type: docs
url: /hi/net/chart-data-label/
keywords:
- "चार्ट"
- "डेटा लेबल"
- "डेटा सटीकता"
- "प्रतिशत"
- "लेबल दूरी"
- "लेबल स्थान"
- "PowerPoint"
- "प्रेजेंटेशन"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा लेबल जोड़ना और फ़ॉर्मेट करना सीखें ताकि स्लाइड अधिक आकर्षक बनें।"
---
## **परिचय**

डेटा लेबल चार्ट सीरीज़ और व्यक्तिगत डेटा पॉइंट्स के बारे में जानकारी प्रदर्शित करते हैं, जिससे पाठकों को मान पहचानने और चार्ट समझने में मदद मिलती है। यह लेख बताता है कि मानों को कैसे फ़ॉर्मेट करें, प्रतिशत कैसे प्रदर्शित करें, लेबल टेक्स्ट पढ़ें, अक्ष अधिकतम से परे लेबल को नियंत्रित करें, कैटेगरी एक्सिस लेबल के अंतराल को समायोजित करें, और पाई चार्ट लेबल को कैसे स्थित करें।

## **चार्ट डेटा लेबल में डेटा सटीकता सेट करें**

सीरीज़ मानों को फ़ॉर्मेट करने के लिए [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, उसका डेटा टेबल प्रदर्शित करता है, और पहली सीरीज़ के लिए वैल्यू लेबल सक्षम करता है। फ़ॉर्मेट `#,##0.00` हजारों विभाजक और दो दशमलव स्थान दिखाता है बिना मूल मानों बदले।

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

## **लेबल के रूप में प्रतिशत दिखाएँ**

स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसके कैटेगरी कुल के प्रतिशत के रूप में गणना करें और टेक्स्ट को [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) में असाइन करें। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8‑पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत दिखाता है। शून्य कुल वाले कैटेगरी को शून्य से भाग देने से बचने के लिए छोड़ दिया जाता है। यदि चार्ट डेटा बदलता है तो कस्टम लेबल टेक्स्ट को पुनः गणना करें।

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

## **चार्ट डेटा लेबल में प्रतिशत चिह्न सेट करें**

जब मान भिन्नों के रूप में संग्रहीत होते हैं, तो प्रतिशत दिखाने के लिए [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) का उपयोग करें। लेबल फ़ॉर्मेट को स्रोत सेल्स से स्वतंत्र रूप से लागू करने के लिए [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) को `false` सेट करें।

यह उदाहरण चार कैटेगरी में लाल और नीले सीरीज़ के साथ 100 % स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मान की जोड़ी का योग 1 है। लेबल फ़ॉर्मेट `0.0%` 0.30 को 30.0 % के रूप में दिखाता है, जबकि वर्टिकल एक्सिस दो दशमलव स्थान उपयोग करता है। दोनों सीरीज़ सफ़ेद, 10‑पॉइंट लेबल टेक्स्ट का उपयोग करती हैं।

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

## **डेटा लेबल का वास्तविक टेक्स्ट पढ़ें**

डेटा लेबल की सेटिंग्स द्वारा उत्पन्न टेक्स्ट प्राप्त करने के लिए [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) का उपयोग करें। यह रिपोर्ट के लिए लेबल निकालने, प्रेजेंटेशन सामग्री खोजने, या उत्पन्न चार्ट सत्यापित करने में उपयोगी है। नीचे के उदाहरण में, डिफ़ॉल्ट [डेटा लेबल फ़ॉर्मेट](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) प्रत्येक कैटेगरी नाम, सीरीज़ नाम, और मान को संयोजित करता है। एक पॉइंट अपने मान को प्रतिशत के रूप में फ़ॉर्मेट करता है, और दूसरा [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) से कस्टम टेक्स्ट का उपयोग करता है।

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

डेटा पॉइंट में संग्रहीत संख्या `0.75` रहती है, भले ही उसका लेबल `75%` के साथ कैटेगरी और सीरीज़ नाम दिखाए। कस्टम टेक्स्ट उत्पन्न लेबल टेक्स्ट को बदल देता है। [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) दोनों मामलों में परिणामी लेबल स्ट्रिंग लौटाता है। जैसा कि ऊपर दिखाया गया है, केवल दृश्यमान लेबल निकालने के लिए [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) को अलग से जांचें।

## **अधिशेष अक्ष अधिकतम से परे डेटा लेबल नियंत्रित करें**

जब आप अक्ष रेंज को मैन्युअली सीमित करते हैं, तो कुछ डेटा पॉइंट्स उसकी अधिकतम से अधिक हो सकते हैं। यह तय करने के लिए कि उनके डेटा लेबल दिखाए जाएँ या नहीं, [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) का उपयोग करें। यह सेटिंग लेबल की दृश्यता बदलती है; यह अक्ष रेंज या मूल डेटा मानों को नहीं बदलती।

नीचे का उदाहरण 60 और 120 मानों के साथ 2D क्लस्टर्ड कॉलम चार्ट बनाता है। यह वर्टिकल अक्ष पर [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) को `false` और [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) को 100 सेट करता है। पहला स्लाइड अधिकतम से परे लेबल की अनुमति देता है; उस स्लाइड की एक कॉपी में उन्हें अक्षम किया गया है। दोनों स्लाइड `DataLabelsOverMaximum.pptx` में सहेजे गए हैं।

[ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) के साथ वैल्यू लेबल सक्षम करें। चार्ट‑स्तर की यह सेटिंग स्वयं वैल्यू डिस्प्ले को सक्षम नहीं करती या व्यक्तिगत लेबल के अक्षम वैल्यू डिस्प्ले को ओवरराइड नहीं करती। यह उदाहरण पूरी सीरीज़ के लिए वैल्यू सक्षम करता है और [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) का उपयोग करके प्रत्येक कॉलम के बाहर के अंत में लेबल रखता है।

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

निम्न छवियाँ Microsoft PowerPoint द्वारा रेंडर किए गए सहेजे गए स्लाइड्स दिखाती हैं। `true` होने पर लेबल **120** ऊपरी सीमा पर दिखाई देता है; `false` होने पर यह छिपा रहता है। लेबल **60** दृश्यमान रहता है, अक्ष अधिकतम **100** पर बना रहता है, और दूसरा डेटा पॉइंट दोनों मामलों में **120** ही रहता है।

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![अधिकतम 100 वाले अक्ष के साथ मान लेबल 120 दिखाने वाला PowerPoint चार्ट](data-labels-over-maximum-true.png) | ![अधिकतम 100 वाले अक्ष के साथ मान लेबल 120 को छिपाने वाला PowerPoint चार्ट](data-labels-over-maximum-false.png) |

{{% alert color="info" title="चार्ट प्रकार" %}}
यह उदाहरण मान अक्ष वाले 2D कॉलम चार्ट का उपयोग करता है। मान अक्ष वाले नहीं वाले चार्ट, जैसे पाई और डोनट चार्ट, इस प्रकार की सीमा के लिए अक्ष अधिकतम नहीं रखते हैं।
{{% /alert %}}

## **अक्ष से लेबल की दूरी सेट करें**

कैटेगरी एक्सिस लेबल और अक्ष के बीच की दूरी को नियंत्रित करने के लिए [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) का उपयोग करें। यह मान अक्ष लेबल के अधिकतम फ़ॉन्ट आकार के प्रतिशत के रूप में होता है। यह उदाहरण क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफ़सेट को 500 सेट करता है। यह सेटिंग व्यक्तिगत डेटा पॉइंट्स से जुड़े लेबल के बजाय कैटेगरी एक्सिस लेबल को प्रभावित करती है।

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

## **लेबल स्थान समायोजित करें**

पाई चार्ट पर, डेटा लेबल की स्थिति को समायोजित करके अंतराल बेहतर बनाएं और लीडर लाइनों के लिए जगह बनाएं।

यह उदाहरण पहले डेटा पॉइंट का मान प्रदर्शित करता है, उसका लेबल स्लाइस के बाहर रखता है, और उसके [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) और [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) ऑफ़सेट को समायोजित करता है। ये ऑफ़सेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के सापेक्ष होते हैं।

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

![समायोजित डेटा लेबल स्थिति वाला पाई चार्ट](pie-chart-adjusted-label.png)

## **कॉलम चार्ट के ऊपर कई पंक्तियों के डेटा लेबल जोड़ें**

यह उदाहरण दो पंक्तियों के डेटा लेबल के साथ कॉलम चार्ट बनाता है, जिसे प्लॉट क्षेत्र के ऊपर रखा गया है। सीरीज़ A दृश्यमान कॉलम दिखाती है, जबकि सीरीज़ B और सीरीज़ C अतिरिक्त लेबल प्रदान करती हैं। उनकी कॉलम को फाइल और आउटलाइन हटाकर छिपाया गया है। सभी तीन सीरीज़ को समान कैटेगरी केंद्रों पर संरेखित करने के लिए [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) गुण का उपयोग किया गया है।

[PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) सेटिंग्स लेबल पंक्तियों के लिए स्थान आरक्षित करती हैं। [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) द्वारा डिफ़ॉल्ट स्थितियों की गणना के बाद, [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) और [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) क्षैतिज संरेखण को बनाए रखते हैं और दो पंक्तियों में लेबल व्यवस्थित करने के लिए लंबवत ऑफ़सेट लागू करते हैं। संख्याएँ सीरीज़ मानों से जुड़ी डेटा लेबल बनी रहती हैं; केवल पंक्ति शीर्षक अलग टेक्स्ट शेड्स होते हैं।

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
        // B और C के कॉलम छिपाएँ, लेकिन उनके डेटा लेबल बनाए रखें।
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

// तीनों सीरीज़ को समान कैटेगरी केंद्रों के साथ संरेखित करें।
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// इस कॉम्पैक्ट उदाहरण के लिए कम ग्रिडलाइन उपयोग करें।
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
        // डिफ़ॉल्ट क्षैतिज स्थिति रखें। Y डिफ़ॉल्ट लेबल स्थिति से,
        // चार्ट-ऊँचाई अंश के रूप में व्यक्त।
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // केवल पंक्ति शीर्षक एक अलग टेक्स्ट शेप है।
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

![प्लॉट क्षेत्र के ऊपर दो पंक्तियों के डेटा लेबल वाला कॉलम चार्ट](multiple-rows-of-labels.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं घने चार्ट पर डेटा लेबल के ओवरलैप को कैसे रोकूँ?**

स्वचालित लेबल प्लेसमेंट, लीडर लाइनों और छोटे फ़ॉन्ट आकार को संयोजित करें; आवश्यकता पड़ने पर कुछ फ़ील्ड (जैसे कैटेगरी) को छिपाएँ या केवल अत्यधिक मानों या प्रमुख पॉइंट्स के लिए लेबल दिखाएँ।

**मैं केवल शून्य, नकारात्मक या खाली मानों के लिए लेबल कैसे अक्षम करूँ?**

लेबल सक्षम करने से पहले डेटा पॉइंट को फ़िल्टर करें और 0, नकारात्मक मान या अनुपलब्ध मानों के लिए डिस्प्ले बंद करें, एक निर्धारित नियम के अनुसार।

**PDF/छवियों में निर्यात करते समय लेबल शैली को सुसंगत कैसे रखें?**

फ़ॉन्ट परिवार और आकार को स्पष्ट रूप से सेट करें और रेंडरिंग पर्यावरण में फ़ॉन्ट उपलब्ध हो, यह सुनिश्चित करें ताकि फ़ॉलबैक न हो।