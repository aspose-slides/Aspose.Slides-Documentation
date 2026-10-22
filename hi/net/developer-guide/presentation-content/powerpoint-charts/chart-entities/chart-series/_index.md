---
title: प्रेजेंटेशन्स में .NET में चार्ट डेटा श्रृंखला प्रबंधित करें
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
- श्रृंखला अंतराल
- PowerPoint
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "C# के साथ प्रेजेंटेशनों में चार्ट श्रृंखलाओं, डेटा बिंदुओं, वर्कबुक सेल्स, फॉर्मेटिंग, ओवरलैप, गैप विड्थ और नकारात्मक मानों को कैसे प्रबंधित करें जानें।"
---
## **समीक्षा**

एक चार्ट अपने प्लॉटेड मानों को वर्कबुक सेल्स में या सीधे संख्यात्मक लिटरल्स के रूप में संग्रहीत कर सकता है। एक [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) संबंधित मानों के एक सेट का प्रतिनिधित्व करता है, और प्रत्येक [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) उस श्रृंखला में एक बिंदु का प्रतिनिधित्व करता है। [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) ऑब्जेक्ट श्रृंखलाओं द्वारा साझा किए गए लेबल या समूह मान प्रदान करते हैं। डिफॉल्ट डेटा के साथ बनाए गए चार्ट्स में, श्रृंखला नाम, श्रेणियां, और बिंदु मान चार्ट वर्कबुक से [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) ऑब्जेक्ट्स का उपयोग करते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफॉल्ट वर्कबुक श्रृंखला नामों के लिए पंक्ति 0, श्रेणी नामों के लिए कॉलम 0, और शेष सेल्स को श्रृंखला मानों के लिए उपयोग करता है। [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) को पास किए गए वर्कशीट, पंक्ति, और कॉलम सूचकांक शून्य‑आधारित होते हैं। यह लेआउट डिफॉल्ट डेटा के साथ चार्ट बनाने पर उपयोगी है, लेकिन यह मान लेना ठीक नहीं है कि हर मौजूदा चार्ट इसे उपयोग करता है। किसी लोडेड प्रेजेंटेशन में, श्रृंखला, श्रेणियों और डेटा पॉइंट्स द्वारा संदर्भित सेल्स की जाँच करें इससे पहले कि आप वर्कबुक मान बदलें।

चार्ट सेटिंग्स के तीन अलग‑अलग स्कोप होते हैं:

- श्रृंखला‑स्तर की सेटिंग्स, जैसे [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/), एक श्रृंखला के सभी बिंदुओं के लिए डिफॉल्ट रूप प्रदान करती हैं।
- डेटा‑पॉइंट सेटिंग्स, जैसे [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/), एक बिंदु के लिए श्रृंखला रूप को ओवरराइड करती हैं।
- समूह सेटिंग्स संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) से संबंधित होती हैं। जब आपको ओवरलैप या गैप विड्थ जैसी विकल्प सेट करने की जरूरत हो, तो [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) के माध्यम से समूह तक पहुँचें।

जब कोई स्पष्ट बिंदु या श्रृंखला फ़िल सेट नहीं किया जाता, तो चार्ट स्टाइल और थीम स्वचालित रूप से उपस्थिति निर्धारित करती हैं। जब दोनों श्रृंखला और बिंदु फॉर्मेट मौजूद होते हैं, तो बिंदु फॉर्मेट उस बिंदु के लिए प्राथमिकता लेता है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **संख्यात्मक लिटरल्स का उपयोग करके श्रृंखला मान सेट करें**

जब श्रृंखला मान एप्लिकेशन डेटा या गणनाओं से आते हैं और वर्कशीट सेल रेफ़रेंसेस की ज़रूरत नहीं होती, तो संख्यात्मक लिटरल्स का उपयोग करें। प्रत्येक बिंदु के [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) को असाइन करने से पहले [DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) को [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) पर सेट करें और फिर [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/) का उपयोग करें।

कलेक्शन सेटिंग उस श्रृंखला की सभी बिंदु मानों के स्रोत प्रकार को नियंत्रित करती है। प्रत्येक बिंदु का [Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/) चयनित प्रकार को दर्शाता है; इसे कलेक्शन सेटिंग के माध्यम से बदलें। `Worksheet` के साथ, संदर्भित सेल तक पहुँचने के लिए [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/) का उपयोग करें। `DoubleLiterals` के साथ, संख्या को सीधे पढ़ने या लिखने के लिए `AsLiteralDouble` का उपयोग करें।

निम्न उदाहरण डिफॉल्ट श्रृंखला और श्रेणियों के साथ एक कॉलम चार्ट बनाता है, फिर उसके पहले श्रृंखला के मौजूदा बिंदुओं को क्रमशः 10, 20, इत्यादि गणना किए गए मान असाइन करता है। यह प्रेजेंटेशन को सहेजता है, पुनः खोलता है, और संग्रहीत मानों को प्रिंट करता है।

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;
for (var i = 0; i < series.DataPoints.Count; i++)
{
    series.DataPoints[i].Value.AsLiteralDouble = (i + 1) * 10;
}

presentation.Save("numeric_literals.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("numeric_literals.pptx");
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedChart = (IChart)reopenedSlide.Shapes[0];
var reopenedSeries = reopenedChart.ChartData.Series[0];
foreach (var point in reopenedSeries.DataPoints)
{
    Console.WriteLine(point.Value.AsLiteralDouble);
}
```

बिंदु मान स्रोत प्रकार [IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/) से अलग है, जो चार्ट के आंतरिक या बाहरी वर्कबुक कॉन्‍फ़िगरेशन को पहचानता है। संख्यात्मक लिटरल्स का उपयोग करने से एम्बेडेड वर्कबुक हटता नहीं है। इस उदाहरण में, वर्कबुक श्रेणी लेबल, श्रृंखला नाम, और अन्य श्रृंखला के लिए उपलब्ध रहता है। वर्कबुक प्रबंधन के लिए देखें [Chart Workbook](/slides/hi/net/chart-workbook/)।

स्कैटर और बबल चार्ट्स के लिए, [DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) और [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) को सेट करके क्रमशः [XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) और [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) के स्रोत चुनें। बबल चार्ट्स [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) को भी [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/) के लिए उपयोग करते हैं। प्रत्येक लागू स्रोत को `DoubleLiterals` पर सेट करें और फिर उस मान की `AsLiteralDouble` प्रॉपर्टी के माध्यम से संख्या असाइन करें।

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) 2D चार्ट में बार या कॉलम के ओवरलैप प्रतिशत को -100 से 100 तक दर्शाता है। यह पैरेंट सीरीज ग्रुप पर सेटिंग का पढ़ने‑के‑लिए प्रोजेक्शन है। सभी संगत श्रृंखलाओं को अपडेट करने के लिए [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) को सेट करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; यह कॉम्बिनेशन चार्ट में असंबंधित श्रृंखला ग्रुप्स को प्रभावित नहीं करता।

निम्न उदाहरण पहले श्रृंखला को शामिल करने वाले ग्रुप के ओवरलैप को सेट करता है:

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

पूरा श्रृंखला के डिफॉल्ट फ़िल को सेट करने के लिए [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) का उपयोग करें। यदि कोई बिंदु पहले से ही स्पष्ट फ़िल रखता है, तो उसका [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) सेटिंग उस बिंदु के लिए श्रृंखला फ़िल को ओवरराइड करती है।

निम्न उदाहरण पहली श्रृंखला पर ठोस नीला फ़िल लागू करता है:

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

## **श्रृंखला नाम बदलें**

श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लेजेंड में प्रदर्शित होता है। क्लस्टर्ड कॉलम चार्ट के डिफॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, कॉलम 1 पर स्थित है और पहला श्रृंखला नाम रखता है। नीचे के उदाहरण में नामांकित स्थिरांक इस संरचना को स्पष्ट रूप से दर्शाते हैं:

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

आप [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह तरीका मौजूदा चार्ट में किसी विशेष पंक्ति और कॉलम का अनुमान लगाने से बचता है:

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

### **कई सेल्स से नाम के साथ श्रृंखला बनाएं**

जब प्रोडक्ट नाम और रिपोर्टिंग अवधि अलग‑अलग वर्कबुक सेल्स में संग्रहीत हों, तो एक मिश्रित श्रृंखला नाम उपयोगी होता है। उदाहरण के लिए, आप `Product A` (B1) और `2026` (C1) को एक ही श्रृंखला नाम में जोड़ सकते हैं जबकि दोनों भागों को उनके स्रोत सेल से लिंक रख सकते हैं।

[IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) का उपयोग करके नाम रेंज प्राप्त करें, फिर उसे [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/) को पास करें। `skipHiddenCells` आर्ग्यूमेंट नियंत्रित करता है कि छुपे हुए सेल्स शामिल हों या नहीं: `true` उन्हें बाहर रखता है, जबकि `false` शामिल करता है। यह उदाहरण `false` का उपयोग करके नाम रेंज में हर सेल को शामिल करता है।

निम्न उदाहरण एक प्रेजेंटेशन बनाता है जिसमें एक श्रृंखला और दो डेटा पॉइंट्स हैं। सेल B1:C1 केवल श्रृंखला नाम प्रदान करते हैं; A2:A3 श्रेणी लेबल्स, और B2:B3 संख्यात्मक मान देती हैं।

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

// ये दो सेल्स श्रृंखला का नाम प्रदान करती हैं।
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

परिणामी श्रृंखला नाम `Product A 2026` है, दो सेल मानों के बीच एक स्पेस के साथ। लेजेंड इसे दोनों कॉलमों के लिए एक प्रविष्टि के रूप में दिखाता है। नीचे की छवि सहेजे गये प्रेजेंटेशन से रेंडर की गई है:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **स्वचालित श्रृंखला फ़िल रंग प्राप्त करें**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) श्रृंखला इंडेक्स और चार्ट स्टाइल से गणना किया गया रंग वापस करता है। यह वह रंग है जो तब उपयोग किया जाता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं हो। इस मेथड को कॉल करने से केवल गणना किया गया रंग पढ़ा जाता है; यह नया फ़िल असाइन नहीं करता।

निम्न उदाहरण प्रत्येक डिफॉल्ट श्रृंखला का स्वचालित रंग प्रिंट करता है:

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

डिफॉल्ट चार्ट स्टाइल के लिए उदाहरण आउटपुट:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

सटीक रंग चार्ट स्टाइल और थीम पर निर्भर करते हैं।

## **एक चार्ट श्रृंखला के लिए इनवर्ट फ़िल रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिए, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) नकारात्मक मानों को अलग फ़िल के साथ दिखा सकता है। नियमित श्रृंखला फ़िल को ठोस सेट करें, इनवर्शन सक्षम करें, और नकारात्मक‑मान रंग को [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शन रंग बदलता है।

निम्न उदाहरण डिफॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, कॉलम 0 में श्रेणी नाम, और कॉलम 1 में मान होते हैं:

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

आप किसी एक बिंदु के लिए [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) के माध्यम से इनवर्शन सक्षम कर सकते हैं। नीचे के उदाहरण में श्रृंखला के लिए इनवर्शन निष्क्रिय है और केवल चयनित बिंदु के लिए सक्रिय किया गया है। बिंदु को नकारात्मक मान भी असाइन किया गया है ताकि प्रभाव दिखाई दे:

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

एक बिंदु को खाली करने के लिए, लेकिन अन्य बिंदुओं को नहीं हटाने के लिए, उसके बैकिंग वर्कबुक सेल को `null` सेट करें। कॉलम चार्ट में, प्लॉटेड मान [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) से प्राप्त किया जा सकता है। डेटा पॉइंट वही श्रेणी स्थिति पर रहता है, परंतु चार्ट उसकी मान को खाली मानता है जैसा कि चार्ट की खाली‑मान सेटिंग्स में निर्धारित है।

निम्न उदाहरण पहले श्रृंखला के केवल दूसरे बिंदु को साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y सेल्स का उपयोग करते हैं, और बबल चार्ट एक आकार सेल भी उपयोग करता है। केवल उस सेल को साफ़ करें जो वह मान दर्शाता है जिसे आप हटाना चाहते हैं। जब आप अन्य बिंदु रखना चाहते हैं, तो [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) न कॉल करें, क्योंकि यह मेथड संग्रह से सभी डेटा पॉइंट्स हटा देता है।

## **खाली सेल्स के प्रदर्शन को नियंत्रित करें**

छिपे हुए सेल्स जिनमें मान हैं, वे खाली सेल्स से अलग होते हैं। छिपी हुई वर्कशीट पंक्तियों और कॉलमों से डेटा को शामिल या बाहर करने के लिए देखें [Include Data from Hidden Rows and Columns](/slides/hi/net/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक सेल अनुपस्थित डेटा दर्शाता है; `0` वाला सेल ज्ञात संख्यात्मक मान दर्शाता है। सेल को खाली करने के लिए [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) को `null` सेट करें। संख्यात्मक शून्य सेटिंग से प्रभावित नहीं होता।

खाली सेल्स को कैसे दिखाना है, चुनने के लिए [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) का उपयोग करें। यह सेटिंग पूरे चार्ट पर लागू होती है और ब्लैंक्स के प्लॉटिंग तरीके को बदलती है, बिना खाली वर्कबुक सेल को शून्य या इंटरपोलेटेड मान से भरने के।

निम्न स्वतंत्र उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला है, दिन 3 का मान साफ़ करता है, और प्रत्येक मोड के साथ एक ही चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) वर्कशीट 0, कॉलम 0 को श्रेणी लेबल्स के लिए, और कॉलम 1 को मानों के लिए उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रहता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

// Day 3 को वास्तव में खाली छोड़ें, जबकि उसकी श्रेणी और डेटा पॉइंट को बनाए रखें।
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

प्रत्येक आउटपुट फ़ाइल उस मोड को सहेजती है जो सहेजने से पहले सेट किया गया था: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए, इच्छित मोड असाइन करें और प्रस्तुति को एक बार सहेजें, मोड पर इटररेट न करें।

नीचे तुलना में सभी तीन फ़ाइलों में समान डेटा दिखाया गया है। दिन 3 हर मामले में वर्कबुक में खाली है:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

दृश्य प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड को आसानी से तुलना करने देता है। बार और कॉलम चार्ट्स के पास कोई लाइन नहीं होती जिससे खोई हुई श्रेणी के ऊपर कनेक्ट किया जा सके, इसलिए `Span` ऊपर दिखाए गए कनेक्टिंग सेगमेंट को नहीं बना पाता; एक गायब कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी तरह, केवल मार्कर्स वाले स्कैटर चार्ट में कोई कनेक्टिंग लाइन नहीं होती। सभी चार्ट प्रकारों के लिए तीन स्पष्ट परिणामों की उम्मीद न करें; अपने उपयोग किए गए प्रकार के लिए आउटपुट जाँचें।

## **श्रृंखला गैप विड्थ सेट करें**

गैप विड्थ आसन्न बार या कॉलम क्लस्टर्स के बीच की जगह है, जिसे बार या कॉलम की चौड़ाई के प्रतिशत में व्यक्त किया जाता है। ओवरलैप की तरह, यह व्यक्तिगत श्रृंखला की बजाय पैरेंट श्रृंखला ग्रुप से जुड़ी होती है। ग्रुप के लिए एक बार [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) सेट करें। बड़ा मान क्लस्टर्स के बीच अधिक जगह बनाता है; छोटा मान उन्हें सघन बनाता है।

निम्न उदाहरण गैप विड्थ बदलता है और केवल अंतिम प्रेजेंटेशन सहेजता है:

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

[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) एनोमरेशन द्वारा प्रदर्शित सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की वैल्यू स्ट्रक्चर या सेटिंग्स समान नहीं होतीं। उदाहरण के लिए, श्रेणी चार्ट्स में श्रेणियां और मान होते हैं, स्कैटर चार्ट्स में X और Y मान होते हैं, और बबल चार्ट्स में बबल साइजेज़ जोड़ती हैं। श्रृंखला प्रकार से मेल खाने वाला डेटा‑पॉइंट निर्माण मेथड प्रयोग करें। ओवरलैप और गैप विड्थ जैसी विकल्प केवल संगत बार या कॉलम ग्रुप्स पर लागू होते हैं।

**चार्ट श्रृंखला ग्रुप क्या है?**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) वह समूह है जिसमें संगत श्रृंखलाएं होती हैं जो ग्रुप‑लेवल प्लॉटिंग सेटिंग्स साझा करती हैं। एक कॉम्बिनेशन चार्ट में एक से अधिक ग्रुप हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचा गया ग्रुप बदलने से आवश्यक नहीं कि चार्ट की सभी श्रृंखलाएं बदलें।

**क्या नई बनाई गई चार्ट में डिफॉल्ट डेटा होता है?**

हाँ। डिफॉल्ट रूप से, [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) नमूना श्रृंखलाएं, श्रेणियां और मान बनाता है। आप उन सेल्स को एडिट कर सकते हैं या पूरी तरह से कस्टम डेटा सेट जोड़ने से पहले दोनों श्रृंखला और श्रेणी कलेक्शन को साफ़ कर सकते हैं। एक ओवरलोड भी डिफॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक सेल्स से कैसे जुड़े हैं?**

श्रृंखला नाम, श्रेणी लेबल और डेटा‑पॉइंट मान एक [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) में सेल्स को संदर्भित करते हैं। संदर्भित सेल को बदलने से संबंधित चार्ट एलिमेंट अपडेट होता है। जब आप कस्टम डेटा बनाते हैं, तो श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस तरह संरेखित रखें कि प्रत्येक बिंदु इच्छित श्रेणी के तहत प्लॉट हो।

**मैं पूरे श्रृंखला के बजाय एक बिंदु कैसे साफ़ करूँ?**

संबंधित वैल्यू सेल को `null` सेट करें ताकि बिंदु की श्रेणी स्थिति खाली बिंदु के रूप में बनी रहे। केवल तब [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) का उपयोग करें जब आप पूरे श्रृंखला के सभी बिंदु हटाना चाहते हों। यदि आप श्रेणियों को भी हटाते हैं, तो सभी श्रृंखलाओं को अपडेट करें ताकि उनके मान श्रेणी कलेक्शन के साथ संरेखित रहें।

**खाली बिंदु कैसे दिखाए जाते हैं?**

परिणाम चार्ट प्रकार और [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) पर निर्भर करता है। समर्थित चार्ट्स ब्लैंक्स को गैप, शून्य मान, या पड़ोसी बिंदुओं को जोड़कर दिखा सकते हैं। अपनी प्रस्तुति में गुम डेटा के अर्थ के अनुरूप सेटिंग चुनें। पूर्ण उदाहरण और दृश्य तुलना के लिए देखें [Control the Display of Empty Cells](#control-the-display-of-empty-cells)।

**नकारात्मक मानों को कैसे फॉर्मेट करें?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिए, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) सक्षम करें और [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) सेट करें। आप व्यक्तिगत बिंदु के लिए [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) के माध्यम से व्यवहार ओवरराइड कर सकते हैं। ये प्रॉपर्टी फॉर्मेटिंग को प्रभावित करती हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों फॉर्मेट हों तो कौन जीतेगा?**

स्पष्ट डेटा‑पॉइंट फॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मेट या, जब श्रृंखला फ़ॉर्मेट परिभाषित नहीं है, तो स्वचालित चार्ट स्टाइल और थीम का उपयोग जारी रखते हैं। ओवरलैप और गैप विड्थ जैसी समूह प्रॉपर्टी लेआउट नियंत्रित करती हैं और बिंदु‑स्तर फॉर्मेट ओवरराइड नहीं होतीं।

**क्या किसी चार्ट में शामिल की जा सकने वाली श्रृंखलाओं की संख्या पर कोई सीमा है?**

Aspose.Slides कोई अलग‑थलग निर्धारित श्रृंखला‑गिनती सीमा नहीं लगाता। व्यावहारिक रूप से, प्रस्तुति फ़ाइल प्रतिबंध, उपलब्ध मेमोरी, रेंडरिंग समय और चार्ट की पठनीयता उपयोगी सीमा तय करती है।

**जब कॉलम बहुत निकट या बहुत दूर हों तो मुझे क्या बदलना चाहिए?**

उपयुक्त पैरेंट श्रृंखला ग्रुप पर [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) सेट करें। क्लस्टर्स के बीच का अंतराल बढ़ाने के लिए मान बढ़ाएँ, या करीब लाने के लिए मान घटाएँ।