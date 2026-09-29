---
title: ".NET में प्रस्तुतियों में चार्ट डेटा श्रृंखलाओं का प्रबंधन"
linktitle: "डेटा श्रृंखला"
type: docs
url: /hi/net/chart-series/
keywords:
- "चार्ट श्रृंखला"
- "श्रृंखला ओवरलैप"
- "श्रृंखला रंग"
- "श्रेणी रंग"
- "श्रृंखला नाम"
- "डेटा बिंदु"
- "श्रृंखला गैप"
- "PowerPoint"
- "प्रेजेंटेशन"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "C# के साथ प्रस्तुतियों में चार्ट श्रृंखलाओं, डेटा बिंदुओं, वर्कबुक कोशिकाओं, फ़ॉर्मेटिंग, ओवरलैप, गैप चौड़ाई और नकारात्मक मानों का प्रबंधन कैसे करें।"
---
## **अवलोकन**

एक चार्ट अपने प्लॉटेड डेटा को एक चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [IChartSeries](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/) एक संबंधित मानों का सेट दर्शाता है, और श्रृंखला में प्रत्येक [IChartDataPoint](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/) एक या अधिक वर्कबुक सेल्स को संदर्भित करता है। [IChartCategory](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartcategory/) ऑब्जेक्ट्स श्रृंखला द्वारा साझा किए गए लेबल या समूहण मान प्रदान करते हैं। इसलिए श्रृंखला का नाम, वर्गीकरण और बिंदु मान [IChartDataCell](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/) ऑब्जेक्ट्स से जुड़े होते हैं, न कि केवल प्रदर्शित पाठ के रूप में संग्रहीत।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक पंक्ति 0 को श्रृंखला नामों के लिए, स्तंभ 0 को श्रेणी नामों के लिए, और शेष कोशिकाओं को श्रृंखला मानों के लिए प्रयोग करता है। [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/getcell/) को पास किए गए वर्कशीट, पंक्ति और स्तंभ सूचकांक शून्य‑आधारित होते हैं। यह लेआउट डिफ़ॉल्ट डेटा के साथ चार्ट बनाते समय उपयोगी है, लेकिन यह मानना उचित नहीं है कि प्रत्येक मौजूदा चार्ट इसे उपयोग करता है। लोडेड प्रेजेंटेशन के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियों और डेटा बिंदुओं द्वारा संदर्भित कोशिकाओं का निरीक्षण करें।

चार्ट सेटिंग्स के तीन अलग‑अलग स्कोप होते हैं:

- श्रृंखला‑स्तर सेटिंग्स, जैसे [IChartSeries.Format](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/format/), एक श्रृंखला के सभी बिंदुओं के लिए डिफ़ॉल्ट रूप प्रदान करती हैं।
- डेटा‑बिंदु सेटिंग्स, जैसे [IChartDataPoint.Format](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/format/), एक बिंदु के लिए श्रृंखला रूप को ओवरराइड करती हैं।
- समूह सेटिंग्स उन संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [IChartSeriesGroup](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseriesgroup/) की सदस्य होती हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसी विकल्प सेट करने की आवश्यकता हो, तो [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/parentseriesgroup/) के माध्यम से समूह तक पहुँचें।

जब कोई स्पष्ट बिंदु या श्रृंखला फ़िल सेट नहीं होता, तो चार्ट शैली और थीम स्वचालित रूप से उपस्थिति निर्धारित करती हैं। जब दोनों, श्रृंखला और बिंदु फ़ॉर्मेटिंग मौजूद हो, तो बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[IChartSeries.Overlap](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/overlap/) रिपोर्ट करता है कि 2D चार्ट में बार या कॉलम कितनी ओवरलैप होते हैं, -100 से 100 प्रतिशत तक। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल‑पढ़ने‑योग्य प्रक्षेपण है। सभी संगत श्रृंखलाओं को अपडेट करने के लिए [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseriesgroup/overlap/) को सेट करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम प्रदर्शित करते हैं; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

निम्नलिखित उदाहरण पहले श्रृंखला को सम्मिलित करने वाले समूह के लिए ओवरलैप सेट करता है:

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

![The series overlap](series_overlap.png)

## **श्रृंखला फ़िल रंग बदलें**

पूरी श्रृंखला के लिए डिफ़ॉल्ट फ़िल सेट करने के लिए [IChartSeries.Format](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/format/) का उपयोग करें। यदि किसी बिंदु का पहले से स्पष्ट फ़िल है, तो उसका [IChartDataPoint.Format](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/format/) सेटिंग उस बिंदु के लिए श्रृंखला फ़िल को ओवरराइड कर देती है।

निम्न उदाहरण पहले श्रृंखला पर ठोस नीला फ़िल लागू करता है:

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

![The color of the series](series_color.png)

## **श्रृंखला का नाम बदलें**

एक श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लेजेंड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के लिए बनाई गई डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, स्तंभ 1 पर स्थित है और पहला श्रृंखला नाम रखता है। नीचे के उदाहरण में नामित स्थिरांक उस संरचना को स्पष्ट करते हैं:

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

आप [IChartSeries.Name](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/name/) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह दृष्टिकोण किसी विशिष्ट पंक्ति और स्तंभ को मानने से बचाता है:

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

![The series name](series_name.png)

## **स्वचालित श्रृंखला फ़िल रंग प्राप्त करें**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) श्रृंखला सूचकांक और चार्ट शैली से गणना किया गया रंग लौटाता है। यह वह रंग है जो तब उपयोग किया जाता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं किया गया हो। मेथड कॉल गणना किया गया रंग पढ़ता है; यह नया फ़िल असाइन नहीं करता।

निम्नलिखित उदाहरण प्रत्येक डिफ़ॉल्ट श्रृंखला का स्वचालित रंग प्रिंट करता है:

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

## **एक चार्ट श्रृंखला के लिए रिवर्स फ़िल रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिए, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/invertifnegative/) नकारात्मक मानों को अलग फ़िल के साथ प्रदर्शित कर सकता है। नियमित श्रृंखला फ़िल को ठोस सेट करें, रिवर्सल सक्षम करें, और नकारात्मक‑मान रंग को [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) के माध्यम से असाइन करें। वर्कबुक में नकारात्मक संख्याएँ अपरिवर्तित रहती हैं; केवल उनका प्रदर्शन रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, स्तंभ 0 में श्रेणी नाम, और स्तंभ 1 में मान होते हैं:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

आप [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) द्वारा एक बिंदु के लिए रिवर्सल सक्षम कर सकते हैं। नीचे के उदाहरण में श्रृंखला के लिए रिवर्सल निष्क्रिय है और केवल चयनित बिंदु के लिए सक्षम किया गया है। प्रभाव देखाने के लिए बिंदु को नकारात्मक मान भी असाइन किया गया है:

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

## **विशिष्ट डेटा बिंदु मान साफ़ करें**

एक बिंदु को खाली बनाने के लिए, उसके बैकिंग वर्कबुक सेल को `null` सेट करें, बाकी बिंदुओं को हटाए बिना। कॉलम चार्ट के लिए, प्लॉटेड मान [IChartDataPoint.YValue](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/yvalue/) के माध्यम से उपलब्ध होता है। डेटा बिंदु वही श्रेणी स्थिति बनाए रखता है, लेकिन चार्ट उसकी मान को खाली मानता है, जैसा कि चार्ट की खाली‑मान सेटिंग्स में निर्धारित है।

निम्न उदाहरण पहली श्रृंखला के केवल दूसरे बिंदु को साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y कोशिकाओं का उपयोग करते हैं, और बबल चार्ट में आकार सेल भी होता है। केवल उस सेल को साफ़ करें जो वह मान दर्शाता है जिसे आप हटाना चाहते हैं। जब आप अन्य बिंदु बरकरार रखना चाहते हैं, तो [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapointcollection/clear/) न कॉल करें, क्योंकि यह विधि संग्रह से सभी डेटा बिंदु हटा देती है।

## **खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें**

छिपी हुई कोशिकाएँ जिनमें मान होते हैं, वे खाली कोशिकाओं से अलग स्थिति बनाती हैं। छिपी हुई वर्कशीट पंक्तियों और स्तंभों से डेटा को शामिल या बाहर करने के लिए, देखें [Include Data from Hidden Rows and Columns](/slides/hi/net/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक सेल अनुपलब्ध डेटा दर्शाता है; `0` वाला सेल ज्ञात संख्यात्मक मान दर्शाता है। किसी सेल को खाली बनाने के लिए [IChartDataCell.Value](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/value/) को `null` सेट करें। अंकात्मक शून्य खाली‑सेल सेटिंग के बावजूद शून्य बना रहता है।

खाली कोशिकाओं को चार्ट कैसे दिखाता है, इसे चुनने के लिए [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/displayblanksas/) का प्रयोग करें। यह सेटिंग पूरे चार्ट पर लागू होती है और खाली मानों को बिना शून्य या इंटरपोलेटेड मान भरें प्लॉट करती है।

निम्न स्वनिहित उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला है, दिन 3 का मान साफ़ करता है, और प्रत्येक मोड के साथ समान चार्ट सहेजता है। इनपुट फ़ाइल की आवश्यकता नहीं है। [IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/) वर्कशीट 0, स्तंभ 0 को श्रेणी लेबल और स्तंभ 1 को मान के लिए उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रखा जाता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

प्रत्येक आउटपुट फ़ाइल मोड को सहेजने से पहले संचित करती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए, वांछित मोड असाइन करें और प्रस्तुति को एक बार सहेजें, सभी मोड्स पर इटरेट करने की बजाय।

नीचे तुलना में सभी तीन फ़ाइलों में समान डेटा दिखाया गया है। प्रत्येक मामले में दिन 3 वर्कबुक में खाली है:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड को तुलनात्मक रूप से दिखाता है। बार और कॉलम चार्ट में टुटे हुए वर्ग नहीं होते, इसलिए `Span` उपरोक्त जैसा कनेक्टिंग खंड नहीं बना सकता; एक गायब कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी तरह, केवल मार्कर वाले स्कैटर चार्ट में भी कनेक्टिंग लाइन नहीं होती। सभी चार्ट प्रकारों में तीन अलग‑अलग परिणाम मिलने की उम्मीद न रखें; अपने उपयोग किए गए प्रकार के आउटपुट की जाँच करें।

## **श्रृंखला गैप चौड़ाई सेट करें**

गैप चौड़ाई आसन्न बार या कॉलम क्लस्टर के बीच का अंतराल है, जिसे बार या कॉलम की चौड़ाई के प्रतिशत में व्यक्त किया जाता है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित है, न कि व्यक्तिगत श्रृंखला से। समूह के लिए एक बार [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) सेट करें। बड़ा मान क्लस्टर के बीच अधिक स्थान बनाता है; छोटा मान उन्हें सघन बनाता है।

निम्न उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रस्तुति को सहेजता है:

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

![The gap width](gap_width.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन से चार्ट प्रकार डेटा श्रृंखलाओं का समर्थन करते हैं?**

[ChartType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/charttype/) एन्‍युमरेशन द्वारा दर्शाए गये सभी चार्ट प्रकार डेटा उपयोग करते हैं, पर उनकी श्रृंखलाओं की मान संरचना या सेटिंग्स अलग‑अलग हो सकती हैं। उदाहरण के लिए, श्रेणी चार्ट में श्रेणियाँ और मान, स्कैटर चार्ट में X और Y मान, और बबल चार्ट में बबल का आकार होता है। श्रृंखला प्रकार से मेल खाने वाला डेटा‑बिंदु निर्माण विधि उपयोग करें। ओवरलैप और गैप‑चौड़ाई जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**चार्ट श्रृंखला समूह क्या है?**

[IChartSeriesGroup](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseriesgroup/) संगत श्रृंखलाओं को रखता है जो समूह‑स्तर प्लॉटिंग सेटिंग्स साझा करती हैं। एक संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला द्वारा पहुँचा गया समूह सभी श्रृंखलाओं को अनिवार्य रूप से बदल नहीं सकता।

**क्या नया बनाया गया चार्ट डिफ़ॉल्ट डेटा रखता है?**

हाँ। डिफ़ॉल्ट रूप से, [IShapeCollection.AddChart](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addchart/) नमूना श्रृंखलाएँ, श्रेणियाँ और मान बनाता है। आप उन कोशिकाओं को संपादित कर सकते हैं या पूरी तरह कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह को साफ़ कर सकते हैं। एक ओवरलोड डिफ़ॉल्ट डेटा के बिना भी चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक कोशिकाओं से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल और डेटा‑बिंदु मान एक [IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/) की कोशिकाओं को संदर्भित करते हैं। संदर्भित कोशिका बदलने से संबंधित चार्ट तत्व अपडेट होता है। कस्टम डेटा बनाते समय श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को संरेखित रखें ताकि प्रत्येक बिंदु इच्छित श्रेणी के अंतर्गत प्लॉट हो।

**मैं पूरी श्रृंखला की बजाय एक बिंदु कैसे साफ़ करूँ?**

`null` सेट करके संबंधित मान कोशिका को साफ़ करें, जिससे बिंदु की श्रेणी स्थिति बनी रहेगी। केवल तभी [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapointcollection/clear/) का प्रयोग करें जब आप उस श्रृंखला के सभी बिंदुओं को हटाना चाहते हों। यदि आप श्रेणियों को भी हटाते हैं, तो सभी श्रृंखलाओं को अपडेट करें ताकि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली बिंदु कैसे दिखाए जाते हैं?**

परिणाम चार्ट प्रकार और [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/displayblanksas/) पर निर्भर करता है। समर्थित चार्ट खाली मानों को गैप, शून्य मान या निकटवर्ती बिंदुओं को जोड़कर दिखा सकते हैं। अपने प्रस्तुति में अनुपलब्ध डेटा के अर्थ से मेल खाने वाली सेटिंग चुनें। पूर्ण उदाहरण और दृश्य तुलना के लिए देखें **[खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](#control-the-display-of-empty-cells)**।

**नकारात्मक मानों का फ़ॉर्मेट कैसे किया जाता है?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिए, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/invertifnegative/) को सक्षम करें और [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) सेट करें। आप व्यक्तिगत बिंदु के लिए व्यवहार को [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) से ओवरराइड कर सकते हैं। ये प्रॉपर्टीज़ फ़ॉर्मेटिंग को प्रभावित करती हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों फ़ॉर्मेटेड हों तो कौन जीतता है?**

विशिष्ट डेटा‑बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मेट या, यदि श्रृंखला फ़ॉर्मेट अपरिभाषित है, तो स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। समूह प्रॉपर्टीज़ जैसे ओवरलैप और गैप‑चौड़ाई लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर फ़ॉर्मेटिंग को ओवरराइड नहीं करतीं।

**क्या चार्ट में श्रृंखलाओं की संख्या पर कोई सीमा है?**

Aspose.Slides कोई अलग‑थलग निश्चित श्रृंखला‑संख्या सीमा नहीं लगाता। व्यावहारिक रूप से, प्रस्तुति फ़ाइल की सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय और चार्ट की पठनीयता उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत पास या बहुत दूर हों तो क्या बदलूँ?**

उचित पैरेंट श्रृंखला समूह पर [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) सेट करें। मान बढ़ाने से क्लस्टर के बीच का अंतराल विस्तृत होगा, घटाने से वे निकट आएँगे।