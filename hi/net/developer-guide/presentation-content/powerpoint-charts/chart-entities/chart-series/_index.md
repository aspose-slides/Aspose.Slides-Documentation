---
title: .NET में प्रस्तुतियों में चार्ट डेटा श्रृंखला का प्रबंधन
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
description: "C# के साथ प्रस्तुतियों में चार्ट श्रृंखला, डेटा बिंदु, वर्कबुक कोशिकाएँ, स्वरूपण, ओवरलैप, गैप चौड़ाई और नकारात्मक मानों को कैसे प्रबंधित करें, सीखें।"
---
## **परिचय**

एक चार्ट अपने प्लॉट किए गए डेटा को चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [IChartSeries](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और श्रृंखला में प्रत्येक [IChartDataPoint](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/) एक या अधिक वर्कबुक कोशिकाओं को संदर्भित करता है। [IChartCategory](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartcategory/) वस्तुएँ लेबल या समूहित मान प्रदान करती हैं जो श्रृंखला द्वारा साझा किए जाते हैं। इसलिए श्रृंखला का नाम, श्रेणियाँ, और बिंदु मान [IChartDataCell](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/) वस्तुओं से जुड़े होते हैं, न कि केवल प्रदर्शित पाठ के रूप में संग्रहीत।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक में श्रृंखला नामों के लिए पंक्ति 0, श्रेणी नामों के लिए कॉलम 0, और शेष कोशिकाएँ श्रृंखला मूल्यों के लिए उपयोग की जाती हैं। वर्कशीट, पंक्ति, और कॉलम सूचकांक जो [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/getcell/) को पास किए जाते हैं, शून्य‑आधारित होते हैं। यह लेआउट डिफ़ॉल्ट डेटा के साथ चार्ट बनाते समय उपयोगी है, लेकिन यह मान लेना सही नहीं है कि हर मौजूदा चार्ट इसका उपयोग करता है। लोड की गई प्रस्तुति के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियाँ और डेटा बिंदुओं द्वारा संदर्भित कोशिकाओं की जाँच करें।

चार्ट सेटिंग्स के तीन अलग-अलग स्तर होते हैं:

- Series-level सेटिंग्स, जैसे कि [IChartSeries.Format](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/format/), एक श्रृंखला के सभी बिंदुओं के लिए डिफ़ॉल्ट रूप प्रदान करती हैं।
- Data-point सेटिंग्स, जैसे कि [IChartDataPoint.Format](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/format/), एक बिंदु के लिए श्रृंखला की उपस्थिति को अधिरोहित करती हैं।
- Group सेटिंग्स, संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [IChartSeriesGroup](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseriesgroup/) से संबंधित होती हैं। समूह तक पहुंचें [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/parentseriesgroup/) के माध्यम से जब आपको ओवरलैप या गैप चौड़ाई जैसे विकल्प सेट करने हों।

जब कोई स्पष्ट बिंदु या श्रृंखला भराव सेट नहीं किया जाता, तो चार्ट स्टाइल और थीम स्वचालित रूप से स्वरूप निर्धारित करती है। जब श्रृंखला और बिंदु दोनों का स्वरूप मौजूद होता है, तो बिंदु का स्वरूप उस बिंदु के लिए प्राथमिकता लेता है।

![चार्ट श्रृंखला (PowerPoint)](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[IChartSeries.Overlap](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/overlap/) एक 2D चार्ट में बार या कॉलम के ओवरलैप प्रतिशत को -100 से 100 तक दर्शाता है। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल‑पढ़ने‑योग्य प्रक्षेपण है। समूह में सभी संगत श्रृंखलाओं को अपडेट करने के लिए [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseriesgroup/overlap/) सेट करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम प्रदर्शित करते हैं; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

निम्न उदाहरण पहले श्रृंखला को शामिल करने वाले समूह के लिए ओवरलैप सेट करता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// नया चार्ट नमूना श्रृंखलाएँ, श्रेणियाँ और मान शामिल करता है।
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

परिणाम:

![श्रृंखला ओवरलैप](series_overlap.png)

## **श्रृंखला भरने का रंग बदलें**

[IChartSeries.Format](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/format/) का उपयोग करके पूरी श्रृंखला के लिए डिफ़ॉल्ट भराव सेट करें। यदि किसी बिंदु का स्पष्ट भराव पहले से परिभाषित है, तो उसका [IChartDataPoint.Format](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/format/) सेटिंग उस बिंदु के लिए श्रृंखला भराव को अधिरोहित करती है।

निम्न उदाहरण पहली श्रृंखला पर ठोस नीला भराव लागू करता है:

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

![श्रृंखला का रंग](series_color.png)

## **श्रृंखला का नाम बदलें**

एक श्रृंखला का नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लेजेंड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के लिए बनाए गए डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, कॉलम 1 पर स्थित होता है और पहली श्रृंखला का नाम रखता है। निम्न उदाहरण में नामित स्थिरांक इस संरचना को स्पष्ट रूप से दर्शाते हैं:

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

आप [IChartSeries.Name](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/name/) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह तरीका मौजूदा चार्ट में किसी विशिष्ट पंक्ति या कॉलम को मानते हुए त्रुटि से बचाता है:

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

![श्रृंखला का नाम](series_name.png)

## **स्वचालित श्रृंखला भरने का रंग प्राप्त करें**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) श्रृंखला सूचकांक और चार्ट स्टाइल के आधार पर गणना किया गया रंग लौटाता है। यह वह रंग है जो तब उपयोग होता है जब श्रृंखला भराव स्पष्ट रूप से परिभाषित नहीं किया गया हो। मेथड को कॉल करने से गणना किया गया रंग पढ़ा जाता है; यह नया भराव नहीं बनाता।

निम्न उदाहरण प्रत्येक डिफ़ॉल्ट श्रृंखला का स्वचालित रंग प्रदर्शित करता है:

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

डिफ़ॉल्ट चार्ट स्टाइल के लिए उदाहरण आउटपुट:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

सटीक रंग चार्ट शैली और थीम पर निर्भर करते हैं।

## **चार्ट श्रृंखला के लिए उलटा भरने का रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिए, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/invertifnegative/) नकारात्मक मानों को अलग भराव के साथ दिखा सकता है। नियमित श्रृंखला भराव को ठोस सेट करें, उलटा रंग सक्षम करें, और नकारात्मक‑मान रंग को [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) के माध्यम से असाइन करें। नकारात्मक संख्याओं का वर्कबुक में मान नहीं बदलता; केवल उनका प्रदर्शन रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, कॉलम 0 में श्रेणी नाम, और कॉलम 1 में मान होते हैं:

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

![उलटा ठोस भरने का रंग](inverted_solid_fill_color.png)

आप एक बिंदु के लिए [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) के माध्यम से उलटा सक्षम कर सकते हैं। निम्न उदाहरण में, श्रृंखला के लिए उलटा अक्षम किया गया है और केवल चयनित बिंदु के लिए सक्षम किया गया है। बिंदु को नकारात्मक मान भी असाइन किया गया है ताकि प्रभाव दिखाई दे:

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

## **किसी विशिष्ट डेटा बिंदु का मान साफ़ करें**

एक बिंदु को खाली करने के लिए, उसके पीछे की वर्कबुक कोशिका को `null` सेट करें, जबकि अन्य बिंदुओं को नहीं हटाते। कॉलम चार्ट के लिए, प्लॉटेड मान [IChartDataPoint.YValue](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/yvalue/) के माध्यम से उपलब्ध है। डेटा बिंदु उसी श्रेणी स्थिति पर बना रहता है, लेकिन चार्ट उसके मान को खाली मान सेटिंग के अनुसार मानता है।

निम्न उदाहरण पहली श्रृंखला में केवल दूसरे बिंदु को साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y कोशिकाओं का उपयोग करते हैं, और बबल चार्ट एक आकार कोशिका भी उपयोग करता है। केवल उस कोशिका को साफ़ करें जो हटाए जाने वाले मान को दर्शाती है। जब आप अन्य बिंदुओं को बनाए रखना चाहते हैं तो [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapointcollection/clear/) को न कॉल करें, क्योंकि यह विधि संग्रह से सभी डेटा बिंदुओं को हटा देती है।

## **खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें**

एक खाली वर्कबुक कोशिका लापता डेटा को दर्शाती है; `0` वाला कोशिका ज्ञात संख्यात्मक मान को दर्शाता है। किसी कोशिका को खाली बनाने के लिए [IChartDataCell.Value](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/value/) को `null` सेट करें। संख्या‑शून्य शून्य ही रहता है, चाहे खाली‑कोशिका सेटिंग कुछ भी हो।

खाली कोशिकाएँ कैसे दिखें, यह चुनने के लिए [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/displayblanksas/) का उपयोग करें। यह सेटिंग पूरे चार्ट पर लागू होती है। यह खाली मानों को प्लॉट करने के तरीके को बदलती है, बिना खाली वर्कबुक कोशिका को शून्य या अंतर्वर्ती मान से भरने के।

निम्न स्वतंत्र उदाहरण एक लाइन चार्ट एक श्रृंखला के साथ बनाता है, दिन 3 का मान खाली करता है, और प्रत्येक मोड के साथ वही चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/) वर्कशीट 0, कॉलम 0 को श्रेणी लेबल के लिए और कॉलम 1 को मानों के लिए उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रहता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

प्रत्येक आउटपुट फ़ाइल सहेजने से पहले असाइन किए गए मोड को संग्रहीत करती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए, इच्छित मोड असाइन करें और प्रस्तुति को एक बार सहेजें, सभी मोडों पर पुनरावृत्ति करने के बजाय।

नीचे तुलना दिखाती है कि सभी तीन फ़ाइलों में समान डेटा कैसे दिखता है। प्रत्येक मामले में कार्यपुस्तिका में दिन 3 खाली है:

![खाली कोशिकाओं को प्रदर्शित करने के साथ लाइन चार्ट: गैप, ज़ीरो, स्पैन](display_blanks_as.png)

दिखाई देने वाला प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोडों को आसानी से तुलना करने योग्य बनाता है। बार और कॉलम चार्ट में लापता श्रेणी केAcross कोई लाइन नहीं होती, इसलिए `Span` ऊपर दिखाए गए कनेक्टिंग सेगमेंट को उत्पन्न नहीं कर सकता; एक लापता कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी प्रकार, केवल मार्कर वाले स्कैटर चार्ट में कोई कनेक्टिंग लाइन नहीं होती। हर चार्ट प्रकार के लिए तीन अलग‑अलग परिणाम की अपेक्षा न करें; आप जिस प्रकार का उपयोग कर रहे हैं, उसके आउटपुट को जाँचें।

## **श्रृंखला गैप चौड़ाई सेट करें**

गैप चौड़ाई समीपस्थ बार या कॉलम क्लस्टर के बीच की दूरी है, जो बार या कॉलम चौड़ाई के प्रतिशत के रूप में व्यक्त की जाती है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित है, न कि किसी एकल श्रृंखला से। समूह के लिए एक बार [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) सेट करें। बड़ी मान क्लस्टर के बीच अधिक जगह बनाता है; छोटी मान उन्हें अधिक घना बनाती है।

निम्न उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रस्तुति सहेजता है:

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

![गैप चौड़ाई](gap_width.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन से चार्ट प्रकार डेटा श्रृंखलाओं को समर्थन देते हैं?**

[ChartType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/charttype/) एन्यूमरेशन द्वारा प्रतिनिधित्व किए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं का मान संरचना या सेटिंग समान नहीं होती। उदाहरण के लिए, श्रेणी चार्ट श्रेणियाँ और मान उपयोग करते हैं, स्कैटर चार्ट X और Y मान, और बबल चार्ट बबल आकार जोड़ते हैं। श्रृंखला प्रकार से मेल खाती डेटा‑बिंदु निर्माण विधि का उपयोग करें। ओवरलैप और गैप चौड़ाई जैसे विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**एक चार्ट श्रृंखला समूह क्या है?**

[IChartSeriesGroup](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseriesgroup/) उस समूह को दर्शाता है जिसमें संगत श्रृंखलाएँ होती हैं जो समूह‑स्तरीय प्लॉटिंग सेटिंग्स साझा करती हैं। संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचा गया समूह बदलना आवश्यक नहीं कि चार्ट की सभी श्रृंखलाएँ बदल जाएँ।

**क्या नई बनाई गई चार्ट में डिफ़ॉल्ट डेटा होता है?**

हां। डिफ़ॉल्ट रूप से, [IShapeCollection.AddChart](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addchart/) नमूना श्रृंखलाएँ, श्रेणियाँ और मान बनाता है। आप उन कोशिकाओं को संपादित कर सकते हैं या पूरी तरह से कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह दोनों को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट वस्तुएँ वर्कबुक कोशिकाओं से कैसे जुड़ी होती हैं?**

श्रृंखला नाम, श्रेणी लेबल और डेटा‑बिंदु मान [IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/) में कोशिकाओं को संदर्भित करते हैं। संदर्भित कोशिका बदलने से संबंधित चार्ट तत्व अपडेट हो जाता है। जब आप कस्टम डेटा बनाते हैं, तो श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस प्रकार संरेखित रखें कि प्रत्येक बिंदु इच्छित श्रेणी के तहत प्लॉट हो।

**मैं पूरी श्रृंखला के बजाय केवल एक बिंदु कैसे साफ़ करूँ?**

बिंदु की संबंधित मान कोशिका को `null` सेट करें ताकि उसकी श्रेणी स्थिति खाली बिंदु के रूप में बनी रहे। केवल तब [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapointcollection/clear/) का उपयोग करें जब आप पूरी श्रृंखला के सभी बिंदुओं को हटाना चाहते हों। यदि आप श्रेणियों को भी हटाते हैं, तो सभी श्रृंखलाओं को अपडेट करें ताकि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली बिंदु कैसे दिखते हैं?**

परिणाम चार्ट प्रकार और [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/displayblanksas/) पर निर्भर करता है। समर्थित चार्ट खाली को गैप, शून्य मान या पड़ोसी बिंदुओं को जोड़कर दिखा सकते हैं। अपनी प्रस्तुति में लापता डेटा के अर्थ के अनुसार सेटिंग चुनें। पूर्ण उदाहरण और दृश्य तुलना के लिए देखें **[खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](#control-the-display-of-empty-cells)**।

**नकारात्मक मानों का स्वरूप क्या है?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिए, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/invertifnegative/) सक्षम करें और [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) के माध्यम से नकारात्मक‑मान रंग सेट करें। आप व्यक्तिगत बिंदु के लिए स्वरूप को [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) से अधिरोहित कर सकते हैं। ये प्रॉपर्टी स्वरूप को प्रभावित करती हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों का स्वरूप हो, तो कौन जीतेगा?**

स्पष्ट डेटा‑बिंदु स्वरूप उस बिंदु के लिए प्राथमिकता लेता है। अन्य बिंदु स्पष्ट श्रृंखला स्वरूप या, यदि श्रृंखला स्वरूप परिभाषित नहीं है, तो स्वचालित चार्ट स्टाइल और थीम का उपयोग जारी रखेंगे। समूह प्रॉपर्टी जैसे ओवरलैप और गैप चौड़ाई लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर के स्वरूप को अधिरोहित नहीं करतीं।

**क्या चार्ट में श्रृंखलाओं की संख्या पर कोई सीमा है?**

Aspose.Slides किसी अलग स्थिर श्रृंखला‑गणना सीमा नहीं लगाता। व्यावहारिक रूप से, प्रस्तुति फ़ाइल की सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय और चार्ट की पठनीयता उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत निकट या बहुत दूर हों, तो मुझे क्या बदलना चाहिए?**

उपयुक्त पैरेंट श्रृंखला समूह पर [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) सेट करें। मान बढ़ाने से क्लस्टर के बीच की जगह चौड़ी होगी, या मान घटाने से क्लस्टर अधिक करीब आ जाएंगे।