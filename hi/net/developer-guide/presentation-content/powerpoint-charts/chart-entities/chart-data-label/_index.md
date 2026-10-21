---
title: .NET में प्रस्तुतियों में चार्ट डेटा लेबल प्रबंधित करें
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
description: "PowerPoint प्रस्तुतियों में अधिक आकर्षक स्लाइड्स के लिए Aspose.Slides for .NET का उपयोग करके चार्ट डेटा लेबल जोड़ना और स्वरूपित करना सीखें."
---
## **परिचय**

डेटा लेबल चार्ट श्रृंखलाओं और व्यक्तिगत डेटा बिंदुओं के बारे में जानकारी प्रदर्शित करते हैं, जिससे पाठकों को मान पहचानने और चार्ट को समझने में मदद मिलती है। यह लेख बताता है कि मानों को कैसे स्वरूपित किया जाए, प्रतिशत कैसे दिखाए जाएँ, लेबल टेक्स्ट कैसे पढ़ें, अक्ष अधिकतम से परे लेबल को कैसे नियंत्रित करें, श्रेणी अक्ष लेबल रिक्ति को कैसे समायोजित करें, और पाई चार्ट लेबल को कैसे स्थित किया जाए।

## **चार्ट डेटा लेबल में डेटा सटीकता सेट करें**

सीरीज़ मानों को स्वरूपित करने के लिए [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, इसकी डेटा तालिका दिखाता है, और पहली श्रृंखला के लिए वैल्यू लेबल सक्षम करता है। फॉर्मेट `#,##0.00` हजार विभाजक और दो दशमलव स्थान दिखाता है बिना मूल मानों को बदले।

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

एक चार्ट की एम्बेडेड वर्कबुक में संख्यात्मक कोशिकाओं को स्वरूपित करने के लिए, देखें [Set Custom Number Formats for Workbook Cells](/slides/hi/net/chart-workbook/#set-custom-number-formats-for-workbook-cells)। वह उदाहरण दिखाता है कि वैल्यू लेबल उनके स्रोत कोशिका फॉर्मेट का अनुसरण करते हैं जबकि संग्रहीत संख्यात्मक मानों को संरक्षित रखते हैं।

## **लेबल के रूप में प्रतिशत प्रदर्शित करें**

एक स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल का प्रतिशत गणना करें और टेक्स्ट को [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) में असाइन करें। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8-फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत दिखाता है। शून्य कुल वाली श्रेणियों को विभाजन शून्य से बचने के लिए छोड़ दिया जाता है। यदि चार्ट डेटा बदलता है तो कस्टम लेबल टेक्स्ट को पुनः गणना करें।

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

## **चार्ट डेटा लेबल के साथ प्रतिशत संकेत सेट करें**

जब मानों को अंश के रूप में संग्रहित किया जाता है, तो प्रतिशत दिखाने के लिए [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) का उपयोग करें। लेबल फ़ॉर्मेट को स्रोत कोशिकाओं से स्वतंत्र रूप से लागू करने के लिए [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) को `false` सेट करें।

यह उदाहरण चार श्रेणियों में लाल और नीली श्रृंखलाओं के साथ 100% स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मानों की जोड़ी का योग 1 होता है। लेबल फ़ॉर्मेट `0.0%` 0.30 को 30.0% के रूप में दिखाता है, जबकि वर्टिकल अक्ष दो दशमलव स्थान का उपयोग करता है। दोनों श्रृंखलाओं में सफ़ेद, 10-फ़ॉन्ट लेबल टेक्स्ट उपयोग किया गया है।

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

डेटा लेबल की सेटिंग्स द्वारा उत्पन्न टेक्स्ट को प्राप्त करने के लिए [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) का उपयोग करें। यह रिपोर्ट के लिए लेबल निकालने, प्रस्तुति सामग्री खोजने, या जनरेटेड चार्ट को वैध करने में उपयोगी है। नीचे दिए गए उदाहरण में, डिफ़ॉल्ट [data label format](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) प्रत्येक श्रेणी नाम, श्रृंखला नाम, और मान को संयोजित करता है। एक बिंदु अपने मान को प्रतिशत के रूप में स्वरूपित करता है, और दूसरा [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) से कस्टम टेक्स्ट उपयोग करता है।

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

डेटा बिंदु में संग्रहीत संख्या `0.75` बनी रहती है, भले ही उसका लेबल श्रेणी और श्रृंखला नाम के साथ `75%` दिखाए। कस्टम टेक्स्ट उत्पन्न लेबल टेक्स्ट को बदल देता है। [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) दोनों मामलों में परिणामस्वरूप लेबल स्ट्रिंग लौटाता है। जब आप केवल दृश्यमान लेबल निकालना चाहते हैं, तो ऊपर दिखाए अनुसार [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) को अलग से जांचें।

## **अक्ष अधिकतम से परे डेटा लेबल नियंत्रित करें**

जब आप मैन्युअली एक अक्ष रेंज को सीमित करते हैं, तो कुछ डेटा बिंदु उसके अधिकतम से अधिक हो सकते हैं। यह नियंत्रित करने के लिए कि उनके डेटा लेबल दिखें या नहीं, [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) का उपयोग करें। यह सेटिंग लेबल दृश्यता को बदलती है; यह अक्ष रेंज या मूल डेटा मानों को नहीं बदलती।

नीचे का उदाहरण 60 और 120 मानों के साथ एक 2D क्लस्टर्ड कॉलम चार्ट बनाता है। यह वर्टिकल अक्ष पर [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) को `false` और [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) को 100 सेट करता है। पहला स्लाइड अधिकतम से परे लेबल की अनुमति देता है; उस स्लाइड की एक कॉपी उन्हें निष्क्रिय करती है। दोनों स्लाइड `DataLabelsOverMaximum.pptx` में सहेजे गए हैं।

[ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) के साथ वैल्यू लेबल सक्षम करें। चार्ट-स्तर की सेटिंग स्वयं वैल्यू डिस्प्ले को सक्षम नहीं करती या किसी व्यक्तिगत लेबल के निष्क्रिय वैल्यू डिस्प्ले को ओवरराइड नहीं करती। यह उदाहरण पूरी श्रृंखला के लिए वैल्यू सक्षम करता है और प्रत्येक कॉलम के बाहरी सिरे पर लेबल रखने के लिए [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) का उपयोग करता है।

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

निम्न छवियां Microsoft PowerPoint द्वारा रेंडर किए गए सहेजे गए स्लाइड्स दिखाती हैं। `true` के साथ, लेबल **120** ऊपर की सीमा पर दृश्यमान होता है; `false` के साथ, यह छिपा होता है। लेबल **60** दृश्यमान रहता है, अक्ष अधिकतम **100** पर बना रहता है, और दूसरा डेटा बिंदु दोनों मामलों में **120** रहता है।

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
यह उदाहरण मान अक्ष के साथ एक 2D कॉलम चार्ट का उपयोग करता है। मान अक्ष के बिना चार्ट, जैसे पाई और डोनट चार्ट, इस प्रकार अक्ष अधिकतम को सीमित नहीं करते।
{{% /alert %}}

## **अक्ष से लेबल दूरी सेट करें**

[LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) का उपयोग करके श्रेणी अक्ष लेबल और अक्ष के बीच दूरी को नियंत्रित करें। मान अक्ष लेबल के अधिकतम फ़ॉन्ट आकार का प्रतिशत है। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफ़सेट को 500 सेट करता है। यह सेटिंग व्यक्तिगत डेटा बिंदुओं से जुड़े लेबल के बजाय श्रेणी अक्ष लेबल को प्रभावित करती है।

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

पाई चार्ट पर, स्पेसिंग सुधारने और लीडर लाइनों के लिए जगह बनाने हेतु डेटा लेबल स्थितियों को समायोजित करें।

यह उदाहरण पहले डेटा बिंदु का मान दिखाता है, उसका लेबल स्लाइस के बाहर रखता है, और इसके [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) और [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) ऑफ़सेट को समायोजित करता है। ये ऑफ़सेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के सापेक्ष हैं।

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

## **लीडर लाइनों का स्वरूपित करें**

जब पाई चार्ट लेबल अपने स्लाइस के बाहर होते हैं, तो लीडर लाइन्स पाठकों को प्रत्येक मान को सही स्लाइस से मिलाने में मदद करती हैं। एक विपरीत रंग और थोड़ा मोटी लाइन इन कनेक्शनों को अनुसरण करने में आसान बना सकती है, जबकि पारदर्शिता और डैश्ड शैली लाइनों को दृश्य रूप से कम बाधक बनाती है।

लीडर लाइनों को स्वरूपित करने के लिए [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) का उपयोग करें, जो श्रृंखला के डेटा लेबल संग्रह स्तर पर लागू होता है। `series.Labels.LeaderLinesFormat.Line` में सेटिंग्स संग्रह पर लागू होती हैं, व्यक्तिगत लेबल पर नहीं।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है, स्लाइस के बाहर मान दिखाता है, और [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/) को सक्षम करता है। यह दो लेबल को उनके स्लाइस से अधिक दूर ले जाता है, [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) और [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) ऑफ़सेट का उपयोग करके, जिन्हें चार्ट की चौड़ाई और ऊँचाई के अंश के रूप में व्यक्त किया गया है। इनपुट प्रस्तुति की आवश्यकता नहीं है।

लाइन के [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) से 255 में से 191 अल्फा मान के साथ ठोस नीला रंग सेट होता है, जो लगभग 25% पारदर्शिता देता है। [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) मोटाई को 2 पॉइंट सेट करता है, और [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) लाइन को डैश्ड बनाता है।

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

// दो लेबल्स को उनके स्लाइस से अधिक दूर ले जाएँ.
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

लीडर लाइनों को सक्षम करने से यह गारंटी नहीं मिलती कि हर लेबल के लिए लाइन दिखेगी। दृश्यता लेबल प्लेसमेंट और चार्ट के लेआउट व्यवहार पर निर्भर करती है। इस उदाहरण में, दो स्थानांतरित लेबलों के पास दृश्यमान लीडर लाइनें हैं; जो लेबल अपने स्लाइस के पास रहते हैं, उन्हें उनकी आवश्यकता नहीं होती।

निम्न छवि Aspose.Slides के साथ रेंडर किए गए सहेजे गए `FormattedLeaderLines.pptx` को दिखाती है:

![नीले, अर्धपारदर्शी डैश्ड लीडर लाइनों के साथ पाई चार्ट जो दो बाहर लेबल को उनके स्लाइस से जोड़ते हैं](formatted-leader-lines.png)

## **कॉलम चार्ट के ऊपर कई पंक्तियों के डेटा लेबल जोड़ें**

यह उदाहरण प्लॉट एरिया के ऊपर दो पंक्तियों के डेटा लेबल वाले कॉलम चार्ट बनाता है। सीरीज़ A दृश्यमान कॉलम दिखाती है, जबकि सीरीज़ B और सीरीज़ C अतिरिक्त लेबल प्रदान करते हैं। उनके कॉलम को फ़िल और आउटलाइन हटाकर छिपा दिया जाता है। [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) प्रॉपर्टी सभी तीन श्रृंखलाओं को समान श्रेणी केंद्रों के साथ संरेखित करती है।

[PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) सेटिंग्स लेबल पंक्तियों के लिए स्थान आरक्षित करती हैं। [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) द्वारा डिफ़ॉल्ट स्थितियों की गणना के बाद, [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) और [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) क्षैतिज संरेखण को बनाए रखते हैं और दो पंक्तियों में लेबल व्यवस्थित करने के लिए ऊर्ध्वकर ऑफ़सेट लागू करते हैं। संख्याएँ श्रृंखला मानों से जुड़ी डेटा लेबल बनी रहती हैं; केवल पंक्ति शीर्षक अलग टेक्स्ट आकार होते हैं।

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
        // B और C के कॉलम छिपाएँ, लेकिन उनके डेटा लेबल रखें।
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

// तीनों श्रृंखलाओं को समान श्रेणी केंद्रों के साथ संरेखित करें।
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// इस संक्षिप्त उदाहरण के लिए कम ग्रिडलाइन का उपयोग करें।
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// प्लॉट के ऊपर दो पंक्तियों के डेटा लेबल के लिए स्थान आरक्षित करें।
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
        // डिफ़ॉल्ट क्षैतिज स्थिति रखें। Y इस से एक ऑफ़सेट है
        // डिफ़ॉल्ट लेबल स्थिति से, जिसे चार्ट-ऊँचाई के अंश के रूप में व्यक्त किया गया है।
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

**सघन चार्ट पर डेटा लेबल के ओवरलैप को कैसे रोकें?**

ऑटोमैटिक लेबल प्लेसमेंट, लीडर लाइनों, और छोटे फ़ॉन्ट आकार को मिलाएँ; यदि आवश्यक हो तो कुछ फ़ील्ड (जैसे श्रेणी) को छिपाएँ या केवल अत्यधिक मानों या प्रमुख बिंदुओं के लिए लेबल दिखाएँ।

**शून्य, नकारात्मक, या खाली मानों के लिए केवल लेबल को कैसे निष्क्रिय करें?**

लेबल सक्षम करने से पहले डेटा बिंदुओं को फ़िल्टर करें और परिभाषित नियम के अनुसार 0, नकारात्मक मान, या गायब मानों के लिए डिस्प्ले बंद करें।

**PDF/छवियों में निर्यात करते समय लेबल शैली की निरंतरता कैसे सुनिश्चित करें?**

फ़ॉन्ट परिवार और आकार को स्पष्ट रूप से सेट करें और रेंडरिंग पर्यावरण में फ़ॉन्ट उपलब्ध है यह सत्यापित करें ताकि फ़ॉलबैक से बचा जा सके।