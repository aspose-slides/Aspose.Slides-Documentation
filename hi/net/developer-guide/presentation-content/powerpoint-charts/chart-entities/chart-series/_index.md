---
title: .NET में प्रस्तुतियों में चार्ट डेटा श्रृंखलाएँ प्रबंधित करें
linktitle: डेटा श्रृंखला
type: docs
url: /hi/net/chart-series/
keywords:
- चार्ट श्रृंखला
- श्रृंखला ओवरलैप
- श्रृंखला रंग
- श्रेणी रंग
- श्रृंखला नाम
- डेटा बिंदु
- श्रृंखला गैप
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "C# के साथ प्रस्तुतियों में चार्ट श्रृंखला, डेटा बिंदु, वर्कबुक कोशिकाएँ, स्वरूपण, ओवरलैप, गैप चौड़ाई और नकारात्मक मानों को कैसे प्रबंधित किया जाए, सीखें।"
---
## **सारांश**

एक चार्ट अपने प्लॉट किए गए डेटा को एक चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और श्रृंखला में प्रत्येक [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) एक या अधिक वर्कबुक सेल्स को संदर्भित करता है। [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) ऑब्जेक्ट्स वह लेबल या समूह मान प्रदान करते हैं जिन्हें श्रृंखला साझा करती है। इसलिए श्रृंखला का नाम, श्रेणियाँ, और बिंदु मान [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) ऑब्जेक्ट्स से जुड़ते हैं न कि केवल प्रदर्शित पाठ के रूप में संग्रहीत होते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक पंक्ति 0 को श्रृंखला नामों के लिए, स्तंभ 0 को श्रेणी नामों के लिए, और शेष सेल्स को श्रृंखला मानों के लिए उपयोग करती है। [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) को पास किए जाने वाले वर्कशीट, पंक्ति, और स्तंभ इंडेक्स शून्य‑आधारित होते हैं। यह लेआउट तब उपयोगी होता है जब आप डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाते हैं, लेकिन यह मानना सही नहीं है कि हर मौजूदा चार्ट इसका उपयोग करता है। लोड की गई प्रस्तुति के लिए, श्रृंखला, श्रेणियाँ, और डेटा बिंदुओं द्वारा उल्लेखित सेल्स को बदलने से पहले जाँचें।

चार्ट सेटिंग्स के तीन अलग-अलग क्षेत्र होते हैं:

- श्रृंखला‑स्तर की सेटिंग्स, जैसे [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/), एक ही श्रृंखला में सभी बिंदुओं के लिए डिफ़ॉल्ट स्वरूप प्रदान करती हैं।
- डेटा‑बिंदु सेटिंग्स, जैसे [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/), एक बिंदु के लिए श्रृंखला स्वरूप को ओवरराइड करती हैं।
- समूह सेटिंग्स उन संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) की सदस्य होती हैं। जब आपको ओवरलैप या गैप विथ जैसी विकल्प सेट करने की आवश्यकता हो तो [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) के माध्यम से समूह तक पहुँचें।

जब कोई स्पष्ट बिंदु या श्रृंखला भराव सेट नहीं किया जाता, तो चार्ट शैली और थीम स्वचालित रूप से स्वरूप निर्धारित करती हैं। जब दोनों श्रृंखला और बिंदु का स्वरूप मौजूद होता है, तो बिंदु का स्वरूप उस बिंदु के लिए प्रधान होता है।

![चार्ट‑श्रृंखला‑पावरपॉइंट](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) 2D चार्ट में बार या कॉलमों के ओवरलैप प्रतिशत को –100 से 100 % तक दर्शाता है। यह पैरेंट श्रृंखला समूह पर सेटिंग का एक केवल‑पढ़ने‑के‑लिए प्रोजेक्शन है। सभी संगत श्रृंखलाओं को अपडेट करने के लिए [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) सेट करें। यह विकल्प समूहित बार या कॉलम प्रदर्शित करने वाले चार्ट प्रकारों पर लागू होता है; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

पहली श्रृंखला वाले समूह के लिए ओवरलैप सेट करने का निम्न उदाहरण है:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// नया चार्ट नमूना श्रृंखलाएँ, श्रेणियाँ और मान रखता है।
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

परिणाम:

![श्रृंखला ओवरलैप](series_overlap.png)

## **श्रृंखला भराव रंग बदलें**

पूरी श्रृंखला के लिए डिफ़ॉल्ट भराव सेट करने हेतु [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) का उपयोग करें। यदि किसी बिंदु का पहले से स्पष्ट भराव सेट है, तो उसकी [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) सेटिंग उस बिंदु के लिए श्रृंखला भराव को ओवरराइड करती है।

पहली श्रृंखला पर ठोस नीला भराव लागू करने का निम्न उदाहरण है:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

परिणाम:

![श्रृंखला रंग](series_color.png)

## **श्रृंखला नाम बदलें**

श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लेजेन्ड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के लिए डिफ़ॉल्ट वर्कबुक में, कोशिका B1 पंक्ति 0, स्तम्भ 1 पर स्थित है और पहली श्रृंखला का नाम रखती है। निम्न उदाहरण में नामित स्थिरांक इस संरचना को स्पष्ट रूप से दर्शाते हैं:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

आप [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/) द्वारा पहले से संदर्भित कोशिका को भी अपडेट कर सकते हैं। यह दृष्टिकोण मौजूदा चार्ट में किसी विशेष पंक्ति या स्तम्भ को मानने से बचता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

परिणाम:

![श्रृंखला नाम](series_name.png)

### **कई कोशिकाओं से नाम के साथ श्रृंखला बनाएं**

जब उत्पाद नाम और रिपोर्टिंग अवधि अलग-अलग वर्कबुक कोशिकाओं में संग्रहीत होती हैं, तो एक संयुक्त श्रृंखला नाम उपयोगी होता है। उदाहरण के लिए, आप `Product A` को B1 और `2026` को C1 में संयोजित करके एकल श्रृंखला नाम बना सकते हैं, जबकि दोनों भागों को उनके स्रोत कोशिकाओं से लिंकेड रख सकते हैं।

[IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) का उपयोग करके नाम रेंज प्राप्त करें, फिर उस संग्रह को [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/) को पास करें। `skipHiddenCells` तर्क यह नियंत्रित करता है कि छिपी हुई कोशिकाएँ शामिल हों या नहीं: `true` उन्हें बाहर रखता है, जबकि `false` शामिल करता है। यह उदाहरण नाम रेंज में सभी कोशिकाओं को शामिल करने के लिए `false` उपयोग करता है।

निम्न उदाहरण एक प्रस्तुति बनाता है जिसमें एक श्रृंखला और दो डेटा बिंदु होते हैं। कोशिकाएँ B1:C1 केवल श्रृंखला नाम प्रदान करती हैं; A2:A3 श्रेणी लेबल देती हैं, और B2:B3 संख्यात्मक मान देती हैं।

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = true;

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// इन दो कोशिकाओं से श्रृंखला का नाम प्राप्त होता है।
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// Separate cells supply the categories and numeric data points.
var northCategory = workbook.GetCell(0, 1, 0, "North");
var southCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(northCategory);
chart.ChartData.Categories.Add(southCategory);
var northValue = workbook.GetCell(0, 1, 1, 120);
var southValue = workbook.GetCell(0, 2, 1, 150);
series.DataPoints.AddDataPointForBarSeries(northValue);
series.DataPoints.AddDataPointForBarSeries(southValue);

presentation.Save("composite_series_name.pptx", SaveFormat.Pptx);
```

परिणामी श्रृंखला नाम `Product A 2026` है, दो कोशिका मानों के बीच एक स्पेस के साथ। लेजेन्ड इसे दोनों स्तम्भों के लिए एक प्रविष्टि के रूप में दिखाता है। नीचे की छवि सहेजी गई प्रस्तुति से रेंडर की गई है:

![उत्पाद‑A‑2026 के साथ संयुक्त श्रृंखला नाम वाला कॉलम चार्ट](composite_series_name.png)

## **स्वचालित श्रृंखला भराव रंग प्राप्त करें**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) श्रृंखला इंडेक्स और चार्ट शैली से गणना किया गया रंग लौटाता है। यह वह रंग है जिसका उपयोग तब किया जाता है जब श्रृंखला भराव स्पष्ट रूप से परिभाषित नहीं किया गया हो। इस विधि को कॉल करने से गणना किया गया रंग पढ़ा जाता है; यह नया भराव निर्धारित नहीं करता।

निम्न उदाहरण प्रत्येक डिफ़ॉल्ट श्रृंखला का स्वचालित रंग प्रिंट करता है:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

डिफ़ॉल्ट चार्ट शैली के लिए उदाहरण आउटपुट:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

सटीक रंग चार्ट शैली और थीम पर निर्भर करते हैं।

## **एक चार्ट श्रृंखला के लिए इनवर्ट भराव रंग सेट करें**

बार, कॉलम, और बबल श्रृंखलाओं के लिए, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) नकारात्मक मूल्यों को विभिन्न भराव के साथ दिखा सकता है। सामान्य श्रृंखला भराव को ठोस सेट करें, उलट को सक्षम करें, और नकारात्मक‑मूल्य रंग को [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शित रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, स्तम्भ 0 में श्रेणी नाम, और स्तम्भ 1 में मान होते हैं:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

परिणाम:

![इनवर्टेड ठोस भराव रंग](inverted_solid_fill_color.png)

आप एक बिंदु के लिए इनवर्ट को [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) से सक्षम कर सकते हैं। निम्न उदाहरण में श्रृंखला के लिए इनवर्ट अक्षम है और केवल चयनित बिंदु के लिए सक्षम है। बिंदु को नकारात्मक मान भी दिया गया है ताकि प्रभाव देखा जा सके:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **एक विशिष्ट डेटा बिंदु मान साफ़ करें**

एक बिंदु को खाली करने के लिए, लेकिन अन्य बिंदुओं को नहीं हटाने के लिए, उसकी सहायक वर्कबुक कोशिका को `null` सेट करें। कॉलम चार्ट के लिए, प्लॉट किया गया मान [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) के माध्यम से उपलब्ध होता है। डेटा बिंदु समान श्रेणी स्थिति पर रहता है, लेकिन चार्ट उस मान को खाली मानता है जैसा कि चार्ट के खाली‑मान सेटिंग्स में परिभाषित है।

निम्न उदाहरण पहली श्रृंखला के दूसरे बिंदु को ही साफ़ करता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

स्कैटर चार्ट अलग-अलग X और Y कोशिकाओं का उपयोग करते हैं, और बबल चार्ट आकार की कोशिका भी उपयोग करता है। केवल वह कोशिका साफ़ करें जो आप हटाना चाहते हैं। जब आप अन्य बिंदुओं को बरकरार रखना चाहते हैं, तब [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) न कॉल करें, क्योंकि यह विधि संग्रह से सभी बिंदु हटा देती है।

## **खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें**

छिपी हुई कोशिकाएँ जिनमें मान होते हैं, वे खाली कोशिकाओं से अलग स्थिति हैं। छिपी हुई वर्कशीट पंक्तियों और स्तम्भों से डेटा शामिल या बाहर करने के लिए देखें: [Include Data from Hidden Rows and Columns](/slides/hi/net/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक कोशिका अनुपस्थित डेटा को दर्शाती है; `0` वाले कोशिका एक ज्ञात संख्यात्मक मान को दर्शाते हैं। कोशिका को खाली बनाने हेतु [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) को `null` सेट करें। संख्यात्मक शून्य खाली‑कोशिका सेटिंग की परवाह किए बिना शून्य ही रहता है।

खाली कोशिकाओं के प्रदर्शन को चुनने के लिए [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) का उपयोग करें। यह सेटिंग पूरे चार्ट पर लागू होती है। यह खाली मानों को प्लॉट करने के तरीके को बदलती है, बिना खाली वर्कबुक कोशिका को शून्य या इंटरपोलेशन मान से भरने के।

निम्न स्वतंत्र उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला होती है, Day 3 के मान को साफ़ करता है, और प्रत्येक मोड के साथ वही चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) वर्कशीट 0, स्तम्भ 0 को श्रेणी लेबल्स के लिए, और स्तम्भ 1 को मानों के लिए उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रखा जाता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

प्रत्येक आउटपुट फ़ाइल सहेजने से पहले असाइन किए गए मोड को दर्शाती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। एक ही संस्करण सहेजने के लिए, इच्छित मोड असाइन करें और प्रस्तुति को केवल एक बार सहेँ, सभी मोडों पर इटरशन न करें।

नीचे तुलना दर्शाती है कि सभी तीन फ़ाइलों में समान डेटा कैसे दिखता है। Day 3 प्रत्येक मामले में वर्कबुक में खाली है:

![लाइन चार्ट में समान डेटा: गैप Day 3 पर रेखा को तोड़ता है, ज़ीरो रेखा को शून्य पर गिराता है, और स्पैन Day 2 को Day 4 से जोड़ता है।](display_blanks_as.png)

दृश्य प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड को आसानी से तुलना करने देता है। बार और कॉलम चार्ट में कोई रेखा नहीं होती जो गायब श्रेणी को जोड़ सके, इसलिए `Span` ऊपर दिखे हुए कनेक्टिंग सेगमेंट को उत्पन्न नहीं कर सकता; एक गायब कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी प्रकार, मार्कर‑केवल स्कैटर चार्ट में कोई कनेक्टिंग रेखा नहीं होती। सभी चार्ट प्रकारों के लिए तीन अलग-अलग परिणाम की आशा न रखें; अपने उपयोग किए जा रहे प्रकार के लिए आउटपुट जाँचें।

## **श्रृंखला गैप विथ सेट करें**

गैप विथ आसन्न बार या कॉलम क्लस्टर के बीच का अंतराल है, जिसे बार या कॉलम की चौड़ाई के प्रतिशत में व्यक्त किया जाता है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित होता है, न कि व्यक्तिगत श्रृंखला से। समूह के लिए एक बार [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) सेट करें। बड़ा मान क्लस्टरों के बीच अधिक स्थान बनाता है; छोटा मान उन्हें अधिक घना कर देता है।

निम्न उदाहरण गैप विथ को बदलकर केवल अंतिम प्रस्तुति को सहेजता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

परिणाम:

![गैप विथ](gap_width.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन‑से चार्ट प्रकार डेटा श्रृंखलाओं का समर्थन करते हैं?**

[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) enumeration द्वारा प्रतिनिधित्व किए गए सभी चार्ट प्रकार डेटा उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की मान संरचना या सेटिंग्स समान नहीं होती। उदाहरण के लिए, श्रेणी चार्ट श्रेणियों और मानों का उपयोग करते हैं, स्कैटर चार्ट X और Y मानों का, और बबल चार्ट बबल आकार जोड़ते हैं। डेटा‑बिंदु निर्माण विधि का चयन श्रृंखला प्रकार के अनुसार करें। ओवरलैप और गैप विथ जैसे विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**चार्ट श्रृंखला समूह क्या है?**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) उन संगत श्रेणियों को सम्मिलित करता है जो समूह‑स्तर की प्लॉटिंग सेटिंग्स साझा करती हैं। एक संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचा गया समूह सभी श्रृंखलाओं को अनिवार्य रूप से नहीं बदलता।

**क्या नयी बनाई गई चार्ट में डिफ़ॉल्ट डेटा होता है?**

हां। डिफ़ॉल्ट रूप से, [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) नमूना श्रृंखलाएँ, श्रेणियाँ, और मान बनाता है। आप उन कोशिकाओं को संपादित कर सकते हैं या पूरी तरह कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह दोनों को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट वर्कबुक कोशिकाओं से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल, और डेटा‑बिंदु मान उन कोशिकाओं को संदर्भित करते हैं जो एक [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) में स्थित हैं। संदर्भित कोशिका को बदलने से संबंधित चार्ट तत्व अपडेट होते हैं। जब आप कस्टम डेटा बनाते हैं, तो श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस तरह संरेखित रखें कि प्रत्येक बिंदु इच्छित श्रेणी के नीचे प्लॉट हो।

**मैं पूरी श्रृंखला के बजाय एक बिंदु कैसे साफ़ करूँ?**

संबंधित मान कोशिका को `null` सेट करें ताकि बिंदु की श्रेणी स्थिति बरकरार रहे लेकिन वह खाली बिंदु के रूप में दिखे। जब आप केवल एक बिंदु हटाना चाहते हैं, तो [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) का उपयोग न करें, क्योंकि यह पूरी श्रृंखला के सभी बिंदु हटा देता है।

**खाली बिंदु कैसे प्रदर्शित होते हैं?**

परिणाम चार्ट प्रकार और [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) पर निर्भर करता है। समर्थित चार्ट खाली को गैप, शून्य मान, या निकटवर्ती बिंदुओं को जोड़कर प्रदर्शित कर सकते हैं। अपनी प्रस्तुति में अनुपस्थित डेटा के अर्थ के अनुरूप सेटिंग चुनें। पूर्ण उदाहरण और दृश्य तुलना के लिए देखें: [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](#control-the-display-of-empty-cells)।

**नकारात्मक मान कैसे स्वरूपित होते हैं?**

समर्थित बार, कॉलम, और बबल श्रृंखलाओं के लिए, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) सक्षम करें और [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) के माध्यम से नकारात्मक‑मान रंग असाइन करें। आप व्यक्तिगत बिंदु के लिए [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) से व्यवहार ओवरराइड कर सकते हैं। ये गुण स्वरूपण को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों स्वरूपित हों तो कौन‑सा स्वरूप प्राथमिकता लेता है?**

स्पष्ट डेटा‑बिंदु स्वरूपण उस बिंदु के लिए प्रधान होता है। अन्य बिंदु स्पष्ट श्रृंखला स्वरूप या, यदि श्रृंखला स्वरूप परिभाषित नहीं है, तो स्वचालित चार्ट शैली एवं थीम का उपयोग जारी रखते हैं। ओवरलैप और गैप विथ जैसी समूह‑प्रॉपर्टी लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर के स्वरूप ओवरराइड नहीं होतीं।

**क्या चार्ट में श्रृंखलाओं की संख्या पर कोई सीमा है?**

Aspose.Slides कोई अलग‑अलग निश्चित श्रृंखला‑गिनती सीमा नहीं लगाता। व्यावहारिक रूप से, प्रस्तुति फ़ाइल सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट की पठनीयता उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत करीब या बहुत दूर हों तो मैं क्या बदलूँ?**

उपयुक्त पैरेंट श्रृंखला समूह पर [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) सेट करें। क्लस्टर के बीच स्थान को विस्तृत करने के लिए मान बढ़ाएँ, या क्लस्टर को करीब लाने के लिए घटाएँ।