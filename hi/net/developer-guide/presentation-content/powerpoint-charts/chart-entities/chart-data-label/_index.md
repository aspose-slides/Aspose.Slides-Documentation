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
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा लेबल जोड़ना और फ़ॉर्मेट करना सीखें ताकि स्लाइड्स अधिक आकर्षक हों।"
---
## **परिचय**

डेटा लेबल चार्ट श्रृंखला और व्यक्तिगत डेटा बिंदुओं के बारे में जानकारी प्रदर्शित करते हैं, जिससे पाठकों को मानों की पहचान करने और चार्ट को समझने में मदद मिलती है। यह लेख मानों को फ़ॉर्मेट करने, प्रतिशत प्रदर्शित करने, लेबल टेक्स्ट पढ़ने, श्रेणी अक्ष लेबल स्पेसिंग समायोजित करने, और पाई चार्ट लेबल की स्थिति निर्धारित करने के तरीकों को समझाता है।

## **चार्ट डेटा लेबल में डेटा प्रेसिशन सेट करें**

सीरीज़ मानों को फ़ॉर्मेट करने के लिए [NumberFormatOfValues](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/numberformatofvalues/) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, इसकी डेटा टेबल प्रदर्शित करता है, और पहली सीरीज़ के लिए वैल्यू लेबल सक्रिय करता है। फ़ॉर्मेट `#,##0.00` हज़ार विभाजक और दो दशमलव स्थान प्रदर्शित करता है बिना मूल मानों को बदले।

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

स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल का प्रतिशत गणना करें और टेक्स्ट को [TextFrameForOverriding](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) को असाइन करें। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8 पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत दिखाता है। शून्य कुल वाली श्रेणियों को शून्य से विभाजन से बचने के लिए छोड़ दिया जाता है। यदि चार्ट डेटा बदलता है तो कस्टम लेबल टेक्स्ट को पुनः गणना करें।

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

## **चार्ट डेटा लेबल के साथ प्रतिशत चिन्ह सेट करें**

जब मान अंश के रूप में संग्रहित होते हैं, तो प्रतिशत दिखाने के लिए [NumberFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/idatalabelformat/numberformat/) का उपयोग करें। लेबल फ़ॉर्मेट को स्रोत कोशिकाओं से स्वतंत्र रूप से लागू करने के लिए [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) को `false` सेट करें। यह उदाहरण चार श्रेणियों में लाल और नीली सीरीज़ के साथ 100% स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मान जोड़ी का योग 1 होता है। लेबल फ़ॉर्मेट `0.0%` 0.30 को 30.0% के रूप में दिखाता है, जबकि ऊर्ध्वाधर अक्ष दो दशमलव स्थान उपयोग करता है। दोनों सीरीज़ सफेद, 10 पॉइंट लेबल टेक्स्ट उपयोग करती हैं।

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

## **डेटा लेबल के वास्तविक टेक्स्ट को पढ़ें**

डेटा लेबल की सेटिंग्स द्वारा उत्पन्न टेक्स्ट को प्राप्त करने के लिए [GetActualLabelText](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/idatalabel/getactuallabeltext/) का उपयोग करें। यह रिपोर्टों के लिए लेबल निकालते समय, प्रस्तुति सामग्री खोजते समय, या उत्पन्न चार्ट की वैधता जांचते समय उपयोगी है। नीचे के उदाहरण में, डिफ़ॉल्ट [data label format](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/idatalabelformat/) प्रत्येक श्रेणी नाम, सीरीज़ नाम, और मान को जोड़ता है। एक बिंदु अपना मान प्रतिशत के रूप में फ़ॉर्मेट करता है, और दूसरा [TextFrameForOverriding](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) से कस्टम टेक्स्ट उपयोग करता है।

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

डेटा बिंदु में संग्रहीत संख्या `0.75` बनी रहती है, भले ही उसका लेबल `75%` को श्रेणी और सीरीज़ नामों के साथ दिखाए। कस्टम टेक्स्ट उत्पन्न लेबल टेक्स्ट को बदल देता है। [GetActualLabelText](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/idatalabel/getactuallabeltext/) दोनों स्थितियों में परिणामस्वरूप लेबल स्ट्रिंग लौटाता है। जब आप केवल दृश्यमान लेबल निकालना चाहते हैं, तो ऊपर दिखाए अनुसार [IsVisible](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/idatalabel/isvisible/) को अलग से जांचें।

## **अक्ष से लेबल दूरी सेट करें**

[LabelOffset](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/iaxis/labeloffset/) का उपयोग करके श्रेणी अक्ष लेबल और अक्ष के बीच की दूरी नियंत्रित करें। यह मान अक्ष लेबल के अधिकतम फ़ॉन्ट आकार का प्रतिशत होता है। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफ़सेट को 500 सेट करता है। यह सेटिंग व्यक्तिगत डेटा बिंदुओं से जुड़े लेबलों के बजाय श्रेणी अक्ष लेबलों को प्रभावित करती है।

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

पाई चार्ट पर, डेटा लेबल की स्थितियों को समायोजित करके स्पेसिंग में सुधार करें और लीडर लाइनों के लिए जगह बनाएं।

यह उदाहरण पहले डेटा बिंदु का मान प्रदर्शित करता है, उसका लेबल स्लाइस के बाहर रखता है, और उसके [X](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ilayoutable/x/) और [Y](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ilayoutable/y/) ऑफ़सेट को समायोजित करता है। ये ऑफ़सेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के अनुपात में होते हैं।

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

## **अक्सर पूछे जाने वाले प्रश्न**

**डेंस चार्ट्स पर डेटा लेबल के ओवरलैप को कैसे रोक सकता हूँ?**  
ऑटोमैटिक लेबल प्लेसमेंट, लीडर लाइनों और छोटे फ़ॉन्ट आकार को मिलाएं; यदि आवश्यक हो तो कुछ फ़ील्ड छिपाएँ (उदाहरण के लिए, श्रेणी) या केवल तीव्र मानों या प्रमुख बिंदुओं के लिए लेबल दिखाएँ।

**शून्य, नकारात्मक, या खाली मानों के लिए लेबल केवल कैसे अक्षम करूँ?**  
लेबल सक्षम करने से पहले डेटा बिंदुओं को फ़िल्टर करें और परिभाषित नियम के अनुसार 0, नकारात्मक या अनुपलब्ध मानों के लिए डिस्प्ले बंद कर दें।

**PDF/इमेज में एक्सपोर्ट करते समय स्थायी लेबल शैली कैसे सुनिश्चित करूँ?**  
फ़ॉन्ट फ़ैमिली और आकार को स्पष्ट रूप से सेट करें और फ़ॉन्ट रेंडरिंग पर्यावरण में उपलब्ध है यह सत्यापित करें ताकि फ़ॉलबैक न हो।