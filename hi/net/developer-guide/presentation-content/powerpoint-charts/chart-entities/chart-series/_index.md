---
title: .NET में प्रस्तुतियों में चार्ट डेटा श्रृंखला प्रबंधन
linktitle: डेटा श्रृंखला
type: docs
url: /hi/net/chart-series/
keywords:
- चार्ट श्रृंखला
- श्रृंखला ओवरलैप
- श्रृंखला रंग
- श्रेणी रंग
- श्रृंखला नाम
- डेटा पॉइंट
- श्रृंखला गैप
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "C# के साथ प्रस्तुतियों में चार्ट श्रृंखला, डेटा पॉइंट, वर्कबुक कोशिकाएँ, फ़ॉर्मेटिंग, ओवरलैप, गैप चौड़ाई और नकारात्मक मानों को कैसे प्रबंधित करें सीखें।"
---
## **अवलोकन**

एक चार्ट अपने प्लॉट किए गए डेटा को एक चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [IChartSeries](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/) एक संबंधित मानों के सेट को दर्शाता है, और श्रृंखला में प्रत्येक [IChartDataPoint](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/) एक या अधिक वर्कबुक सेल्स की ओर इशारा करता है। [IChartCategory](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartcategory/) वस्तुएँ श्रेणी के लेबल या समूह मान प्रदान करती हैं जो श्रृंखला द्वारा साझा किए जाते हैं। इसलिए श्रृंखला का नाम, श्रेणियाँ, और पॉइंट मान [IChartDataCell](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/) वस्तुओं से जुड़ते हैं न कि केवल प्रदर्शित टेक्स्ट के रूप में संग्रहीत होते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक पंक्ति 0 को श्रृंखला नामों के लिए, स्तम्भ 0 को श्रेणी नामों के लिए, और शेष कोशिकाओं को श्रृंखला मानों के लिए उपयोग करती है। वर्कशीट, पंक्ति, और स्तम्भ अनुक्रमणांक जो [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/getcell/) को पास किए जाते हैं, शून्य‑आधारित होते हैं। यह लेआउट डिफ़ॉल्ट डेटा के साथ चार्ट बनाते समय उपयोगी है, लेकिन यह मानना नहीं चाहिए कि प्रत्येक मौजूदा चार्ट इसका उपयोग करता है। लोडेड प्रस्तुति के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियाँ और डेटा पॉइंट्स द्वारा संदर्भित कोशिकाओं का निरीक्षण करें।

चार्ट सेटिंग्स के तीन अलग-अलग दायरे होते हैं:

- श्रृंखला‑स्तरीय सेटिंग्स, जैसे [IChartSeries.Format](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/format/), सभी पॉइंट्स के लिए डिफ़ॉल्ट स्वरूप प्रदान करती हैं।
- डेटा‑पॉइंट सेटिंग्स, जैसे [IChartDataPoint.Format](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/format/), एक पॉइंट के लिए श्रृंखला के स्वरूप को ओवरराइट करती हैं।
- समूह सेटिंग्स समान [IChartSeriesGroup](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseriesgroup/) की संगत श्रृंखलाओं पर लागू होती हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसी विकल्प सेट करने की आवश्यकता हो, तो [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/parentseriesgroup/) के माध्यम से समूह तक पहुँचें।

जब कोई स्पष्ट पॉइंट या श्रृंखला फ़िल नहीं निर्धारित किया गया हो, तो चार्ट शैली और थीम स्वचालित रूप से स्वरूप तय करती हैं। जब दोनों श्रृंखला और पॉइंट फ़ॉर्मेटिंग मौजूद हो, तो पॉइंट फ़ॉर्मेटिंग उस पॉइंट के लिए प्राथमिकता लेती है।

![चार्ट-सीरीज़-पावरपॉइंट](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[IChartSeries.Overlap](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/overlap/) रिपोर्ट करता है कि 2D चार्ट में बार या कॉलम कितने प्रतिशत ओवरलैप करते हैं, -100 से 100 प्रतिशत तक। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल‑पढ़ने‑योग्य प्रक्षेपण है। सभी संगत श्रृंखलाओं को अपडेट करने के लिए [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseriesgroup/overlap/) सेट करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम प्रदर्शित करते हैं; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

निम्नलिखित उदाहरण पहले श्रृंखला वाले समूह के लिए ओवरलैप सेट करता है:

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

![श्रेणी ओवरलैप](series_overlap.png)

## **श्रृंखला फ़िल रंग बदलें**

पूरा श्रृंखला का डिफ़ॉल्ट फ़िल सेट करने के लिए [IChartSeries.Format](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/format/) का उपयोग करें। यदि किसी पॉइंट का फ़िल पहले से स्पष्ट रूप से निर्धारित है, तो उसके [IChartDataPoint.Format](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/format/) सेटिंग उस पॉइंट के लिए श्रृंखला फ़िल को ओवरराइड करती है।

निम्नलिखित उदाहरण पहले श्रृंखला पर ठोस नीला फ़िल लागू करता है:

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

## **श्रृंखला नाम बदलें**

एक श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लीजेंड में दिखाया जाता है। क्लस्टर कॉलम चार्ट के लिए बनाई गई डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, स्तम्भ 1 पर स्थित है और पहले श्रृंखला का नाम रखती है। निम्नलिखित उदाहरण में नामित स्थिरांक उस संरचना को स्पष्ट रूप से दर्शाते हैं:

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

आप [IChartSeries.Name](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/name/) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह दृष्टिकोण मौजूदा चार्ट में किसी विशिष्ट पंक्ति या स्तम्भ को मानने से बचाता है:

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

## **स्वतः उत्पन्न श्रृंखला फ़िल रंग प्राप्त करें**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) श्रृंखला सूचकांक और चार्ट शैली से गणना किया गया रंग लौटाता है। यह वह रंग है जो तब उपयोग होता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं किया गया हो। यह विधि गणना किया गया रंग पढ़ती है; यह नया फ़िल असाइन नहीं करती।

निम्नलिखित उदाहरण डिफ़ॉल्ट प्रत्येक श्रृंखला के स्वतः रंग को प्रिंट करता है:

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

## **एक चार्ट श्रृंखला के लिए इनवर्ट फ़िल रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिए, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/invertifnegative/) नकारात्मक मानों को भिन्न फ़िल के साथ दिखा सकता है। सामान्य श्रृंखला फ़िल को ठोस सेट करें, इनवर्शन सक्षम करें, और नकारात्मक‑मान रंग को [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) द्वारा असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शित रंग बदलता है।

निम्नलिखित उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, स्तम्भ 0 में श्रेणी नाम, और स्तम्भ 1 में मान होते हैं:

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

![इनवर्टेड ठोस फ़िल रंग](inverted_solid_fill_color.png)

आप एक पॉइंट के लिए इनवर्शन को [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) से सक्षम कर सकते हैं। निम्नलिखित उदाहरण में, श्रृंखला के लिए इनवर्शन अक्षम है और केवल चयनित पॉइंट के लिए सक्षम है। प्रभाव दिखाने के लिए पॉइंट को नकारात्मक मान भी असाइन किया गया है:

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

## **विशिष्ट डेटा पॉइंट मान साफ़ करें**

एक पॉइंट को खाली बनाने के लिए, जबकि अन्य पॉइंट्स को न हटाने के लिए, उसकी बैकिंग वर्कबुक सेल को `null` सेट करें। कॉलम चार्ट के लिए, प्लॉट किया गया मान [IChartDataPoint.YValue](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/yvalue/) के माध्यम से उपलब्ध होता है। डेटा पॉइंट वही श्रेणी स्थिति में रहता है, लेकिन चार्ट उसकी मान को खाली मानता है, चार्ट की खाली‑मान सेटिंग्स के अनुसार।

निम्नलिखित उदाहरण पहले श्रृंखला में केवल दूसरे पॉइंट को साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y कोशिकाओं का उपयोग करते हैं, और बबल चार्ट एक आकार कोशिका भी उपयोग करता है। केवल उस सेल को साफ़ करें जो आप हटाना चाहते हैं। यदि आप अन्य पॉइंट्स को बनाए रखना चाहते हैं, तो [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapointcollection/clear/) न बुलाएँ, क्योंकि वह सभी डेटा पॉइंट्स को संग्रह से हटा देता है।

## **श्रृंखला गैप चौड़ाई सेट करें**

गैप चौड़ाई पास‑पास के बार या कॉलम क्लस्टर के बीच का अंतराल है, जिसे बार या कॉलम चौड़ाई के प्रतिशत में व्यक्त किया जाता है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित है, न कि किसी एकल श्रृंखला से। समूह के लिए एक बार [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) सेट करें। बड़ा मान क्लस्टर के बीच अधिक जगह बनाता है; छोटा मान उन्हें सघन करता है।

निम्नलिखित उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रस्तुति को सहेजता है:

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

**कौन से चार्ट प्रकार डेटा श्रृंखला का समर्थन करते हैं?**

[ChartType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/charttype/) गणना द्वारा प्रतिनिधित्व किए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं में मान संरचना या सेटिंग्स समान नहीं होतीं। उदाहरण के लिए, श्रेणी चार्ट में श्रेणियों और मानों का उपयोग होता है, स्कैटर चार्ट में X और Y मान, और बबल चार्ट में बबल आकार भी जोड़ता है। डेटा‑पॉइंट निर्माण विधि का चयन श्रृंखला प्रकार के अनुसार करें। ओवरलैप और गैप चौड़ाई जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**एक चार्ट श्रृंखला समूह क्या है?**

[IChartSeriesGroup](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseriesgroup/) समान सेटिंग्स साझा करने वाली संगत श्रृंखलाओं को रखता है। एक संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचे समूह को बदलने से आवश्यक नहीं कि चार्ट की सभी श्रृंखलाएँ बदलें।

**क्या नए बनाए गए चार्ट में डिफ़ॉल्ट डेटा शामिल होता है?**

हां। डिफ़ॉल्ट रूप से, [IShapeCollection.AddChart](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addchart/) नमूना श्रृंखलाएँ, श्रेणियाँ और मान बनाता है। आप उन कोशिकाओं को संपादित कर सकते हैं या पूर्णतः कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक कोशिकाओं से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल और डेटा‑पॉइंट मान एक [IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/) की कोशिकाओं से संदर्भित होते हैं। संदर्भित सेल को बदलने से संबंधित चार्ट तत्व अपडेट हो जाता है। जब आप कस्टम डेटा बनाते हैं, तो श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस प्रकार संरेखित रखें कि प्रत्येक पॉइंट इच्छित श्रेणी के अन्तर्गत प्लॉट हो।

**मैं पूरे श्रृंखला के बजाय एक पॉइंट कैसे साफ़ करूँ?**

संबंधित मान सेल को `null` सेट करें ताकि पॉइंट का श्रेणी स्थान खाली पॉइंट के रूप में बना रहे। केवल तभी [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapointcollection/clear/) का उपयोग करें जब आप पूरी श्रृंखला के सभी पॉइंट्स हटाना चाहते हों। यदि आप श्रेणियों को भी हटाते हैं, तो प्रत्येक श्रृंखला को अपडेट करें ताकि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली पॉइंट्स कैसे दिखाए जाते हैं?**

परिणाम चार्ट प्रकार और [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/displayblanksas/) पर निर्भर करता है। समर्थित चार्ट खाली पॉइंट्स को गैप, शून्य मान, या पड़ोसी पॉइंट्स को जोड़कर दिखा सकते हैं। वह सेटिंग चुनें जो आपके प्रस्तुति में अनुपस्थित डेटा के अर्थ से मेल खाती हो।

**नकारात्मक मान कैसे स्वरूपित होते हैं?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिए, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/invertifnegative/) सक्षम करें और [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) सेट करें। आप एक व्यक्तिगत पॉइंट के लिए [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) के साथ व्यवहार ओवरराइड कर सकते हैं। ये प्रॉपर्टी फ़ॉर्मेटिंग को प्रभावित करती हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब दोनों श्रृंखला और पॉइंट फ़ॉर्मेट किए जाते हैं तो कौन सा फ़ॉर्मेट जीतता है?**

स्पष्ट डेटा‑पॉइंट फ़ॉर्मेटिंग उस पॉइंट के लिए प्राथमिकता लेती है। अन्य पॉइंट्स स्पष्ट श्रृंखला फ़ॉर्मेट या, जब श्रृंखला फ़ॉर्मेट परिभाषित नहीं है, तो स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। समूह गुण जैसे ओवरलैप और गैप चौड़ाई लेआउट को नियंत्रित करते हैं और पॉइंट‑स्तर फ़ॉर्मेटिंग ओवरराइड नहीं होते।

**क्या चार्ट में अधिकतम कितनी श्रृंखलाएँ हो सकती हैं?**

Aspose.Slides कोई अलग फ़िक्स्ड श्रृंखला‑गणना सीमा नहीं लगाता। व्यवहार में, प्रस्तुति फ़ाइल सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट की पढ़ने‑योग्यता उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत करीब या बहुत दूर हों तो क्या बदलना चाहिए?**

उपयुक्त पैरेंट श्रृंखला समूह पर [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) सेट करें। क्लस्टरों के बीच स्थान बढ़ाने के लिए मान बढ़ाएँ, या उन्हें करीब लाने के लिए मान घटाएँ।