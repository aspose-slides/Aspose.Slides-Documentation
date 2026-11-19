---
title: ".NET में प्रस्तुतियों में चार्ट डेटा श्रृंखलाओं का प्रबंधन करें"
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
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "C# के साथ प्रस्तुतियों में चार्ट श्रृंखलाओं, डेटा बिंदुओं, वर्कबुक सेल्स, फ़ॉर्मेटिंग, ओवरलैप, गैप विथ और नकारात्मक मानों का प्रबंधन कैसे करें।"
---
## **अवलोकन**

एक चार्ट अपने प्लॉटेड मानों को वर्कबुक सेल में या सीधे संख्यात्मक लिटरल के रूप में संग्रहीत कर सकता है। एक [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और प्रत्येक [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) उस श्रृंखला में एक बिंदु का प्रतिनिधित्व करता है। [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) ऑब्जेक्ट्स लेबल या समूह मान प्रदान करते हैं जो श्रृंखला द्वारा साझा किए जाते हैं। डिफ़ॉल्ट डेटा के साथ बनाए गए चार्ट में, श्रृंखला नाम, श्रेणियाँ और बिंदु मान [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) ऑब्जेक्ट्स का उपयोग करते हैं जो चार्ट वर्कबुक से आते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक श्रृंखला नामों के लिए पंक्ति 0, श्रेणी नामों के लिए स्तंभ 0, और शेष सेल्स श्रृंखला मानों के लिए उपयोग करता है। [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) को पास किए जाने वाले वर्कशीट, पंक्ति और स्तंभ सूचक शून्य‑आधारित होते हैं। यह लेआउट तब उपयोगी होता है जब आप डिफ़ॉल्ट डेटा के साथ चार्ट बनाते हैं, लेकिन यह मान न करें कि प्रत्येक मौजूदा चार्ट इसका उपयोग करता है। लोड की गई प्रस्तुति के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियाँ और डेटा पॉइंट्स द्वारा संदर्भित सेल्स का निरीक्षण करें।

चार्ट सेटिंग्स के तीन अलग‑अलग स्कोप होते हैं:

- श्रृंखला‑स्तर सेटिंग्स, जैसे [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/), एक श्रृंखला के सभी बिंदुओं के लिए डिफ़ॉल्ट रूप प्रदान करती हैं।
- डेटा‑पॉइंट सेटिंग्स, जैसे [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/), एक बिंदु के लिए श्रृंखला रूप को अधिलिखित करती हैं।
- समूह सेटिंग्स संगत श्रृंखलाओं पर लागू होती हैं जो समान [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) से संबंधित हैं। जब आपको ओवरलैप या गैप विथ जैसे विकल्प सेट करने की आवश्यकता हो, तो [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) के माध्यम से समूह तक पहुँचें।

जब स्पष्ट बिंदु या श्रृंखला फ़िल नहीं सेट किया गया हो, तो चार्ट शैली और थीम स्वचालित रूप से उपस्थिति निर्धारित करती हैं। जब दोनों श्रृंखला और बिंदु फॉर्मेटिंग मौजूद हों, तो बिंदु फॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है।

![चार्ट‑श्रृंखला‑पावरपॉइंट](chart-series-powerpoint.png)

क्लस्टर्ड सिलेंडर चार्ट के लिए, देखें कि कैसे [3D श्रृंखला प्रकार या बार आकार बदलना](/slides/hi/net/3d-chart/#change-the-3d-series-type-and-bar-shape) पहले श्रृंखला को प्रभावित करता है।

## **संख्यात्मक लिटरल का उपयोग करके श्रृंखला मान सेट करें**

जब श्रृंखला मान एप्लिकेशन डेटा या गणनाओं से आते हैं और उन्हें वर्कशीट सेल रेफ़रेंसेज़ की आवश्यकता नहीं होती, तो संख्यात्मक लिटरल का उपयोग करें। प्रत्येक बिंदु के [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) को असाइन करने से पहले [DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) को [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) पर सेट करें और [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/) का प्रयोग करें।

कलेक्शन सेटिंग उस श्रृंखला में सभी बिंदु मानों की स्रोत प्रकार को नियंत्रित करती है। प्रत्येक बिंदु का [Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/) चयनित प्रकार को रिपोर्ट करता है; इसे कलेक्शन सेटिंग के माध्यम से बदलें। `Worksheet` के साथ, संदर्भित सेल तक पहुँचने के लिए [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/) का उपयोग करें। `DoubleLiterals` के साथ, संख्या को सीधे पढ़ने या लिखने के लिए `AsLiteralDouble` का उपयोग करें।

निम्न उदाहरण डिफ़ॉल्ट श्रृंखलाओं और श्रेणियों के साथ कॉलम चार्ट बनाता है, फिर पहले श्रृंखला के मौजूदा बिंदुओं को 10, 20 आदि जैसे गणना किए गए मान असाइन करता है। यह प्रस्तुति को सहेजता है, पुनः खोलता है, और संग्रहीत मानों को प्रिंट करता है।

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

बिंदु मान स्रोत प्रकार [IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/) से अलग है, जो चार्ट की आंतरिक या बाहरी वर्कबुक कॉन्फ़िगरेशन को पहचानता है। संख्यात्मक लिटरल का उपयोग स्वयं एंबेडेड वर्कबुक को नहीं हटाता। इस उदाहरण में, वर्कबुक श्रेणी लेबल, श्रृंखला नाम और अन्य श्रृंखलाओं के लिए उपलब्ध रहती है। वर्कबुक प्रबंधन के लिए देखें [Chart Workbook](/slides/hi/net/chart-workbook/)।

स्कैटर और बबल चार्ट के लिए, [DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) और [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) को सेट करके क्रमशः [XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) और [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) स्रोत चुनें। बबल चार्ट के लिए [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) का उपयोग करके [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/) सेट करें। प्रत्येक लागू स्रोत को `DoubleLiterals` पर सेट करें और फिर उस मान की `AsLiteralDouble` प्रॉपर्टी के माध्यम से संख्याएँ असाइन करें।

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) 2D चार्ट में बार या कॉलम के ओवरलैप प्रतिशत को –100 से 100 तक रिपोर्ट करता है। यह पैरेंट श्रृंखला समूह पर सेटिंग का पढ़‑के‑सिर्फ प्रोजेक्शन है। सभी संगत श्रृंखलाओं को अपडेट करने के लिए [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) सेट करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो ग्रुप्ड बार या कॉलम प्रदर्शित करते हैं; यह कॉम्बिनेशन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

निम्न उदाहरण पहले श्रृंखला वाली समूह के लिए ओवरलैप सेट करता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// नई चार्ट में नमूना श्रृंखलाएँ, श्रेणियाँ और मान होते हैं।
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

परिणाम:

![श्रृंखला ओवरलैप](series_overlap.png)

## **श्रृंखला फ़िल रंग बदलें**

पूरी श्रृंखला के लिए डिफ़ॉल्ट फ़िल सेट करने हेतु [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) का उपयोग करें। यदि किसी बिंदु के पास स्पष्ट फ़िल है, तो उसका [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) सेटिंग उस बिंदु के लिए श्रृंखला फ़िल को अधिलिखित करती है।

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

![श्रृंखला रंग](series_color.png)

## **श्रृंखला नाम बदलें**

श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहित होता है और सामान्यतः लेजेंड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के लिए निर्मित डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, स्तंभ 1 पर स्थित है और पहले श्रृंखला का नाम रखता है। नीचे के उदाहरण में नामित स्थिरांक इस संरचना को स्पष्ट करते हैं:

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

आप [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह विधि मौजूदा चार्ट में विशिष्ट पंक्ति‑स्तंभ मानते हुए त्रुटियों से बचती है:

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

### **कई सेल्स से नाम वाली श्रृंखला बनाएं**

जब उत्पाद नाम और रिपोर्टिंग अवधि अलग‑अलग वर्कबुक सेल में संग्रहीत हों, तो समग्र श्रृंखला नाम उपयोगी होता है। उदाहरण के रूप में, आप B1 में `Product A` और C1 में `2026` को मिलाकर एकल श्रृंखला नाम बना सकते हैं, जबकि दोनों भाग अपने स्रोत सेल्स से लिंक रहेंगे।

[IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) का प्रयोग करके नाम रेंज प्राप्त करें, फिर उस कलेक्शन को [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/) को पास करें। `skipHiddenCells` तर्क तय करता है कि छिपे हुए सेल्स शामिल हों या न हों: `true` उन्हें बाहर रखता है, `false` उन्हें शामिल करता है। यह उदाहरण `false` का उपयोग करके नाम रेंज में प्रत्येक सेल को शामिल करता है।

निम्न उदाहरण एक प्रस्तुति बनाता है जिसमें एक श्रृंखला और दो डेटा पॉइंट्स होते हैं। सेल B1:C1 केवल श्रृंखला नाम प्रदान करते हैं; A2:A3 श्रेणी लेबल; B2:B3 संख्यात्मक मान।

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

// इन दो सेल्स से श्रृंखला का नाम प्राप्त होता है।
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// अलग-अलग सेल्स श्रेणियाँ और संख्यात्मक डेटा पॉइंट्स प्रदान करते हैं।
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

परिणामी श्रृंखला नाम `Product A 2026` है, दो सेल मानों के बीच एक स्पेस के साथ। लेजेंड इसे दोनों कॉलम के लिए एक ही प्रविष्टि के रूप में दिखाता है। नीचे का चित्र सहेजी गई प्रस्तुति से रेंडर किया गया है:

![उत्तरी और दक्षिणी मानों के साथ कॉलम चार्ट और समग्र श्रृंखला नाम Product A 2026 लेजेंड में](composite_series_name.png)

## **स्वचालित श्रृंखला फ़िल रंग प्राप्त करें**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) वह रंग लौटाता है जो श्रृंखला इंडेक्स और चार्ट शैली से गणना किया जाता है। यह वही रंग है जो तब उपयोग होता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं है। इस मेथड को कॉल करने से गणना किया गया रंग पढ़ा जाता है; यह नया फ़िल असाइन नहीं करता।

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

सटीक रंग चार्ट शैली और थीम पर निर्भर करेंगे।

## **एक चार्ट श्रृंखला के लिए इनवर्ट फ़िल रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिए, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) नकारात्मक मानों को अलग फ़िल के साथ प्रदर्शित कर सकता है। नियमित श्रृंखला फ़िल को ठोस सेट करें, इनवर्ज़न सक्रिय करें, और नकारात्मक‑मान रंग को [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शित रंग बदलता है।

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

![इनवर्टेड ठोस फ़िल रंग](inverted_solid_fill_color.png)

आप एक बिंदु के लिए [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) के माध्यम से इनवर्ज़न सक्षम कर सकते हैं। नीचे के उदाहरण में श्रृंखला के लिए इनवर्ज़न अक्षम है और केवल चयनित बिंदु के लिए सक्षम है। बिंदु को एक नकारात्मक मान भी असाइन किया गया है ताकि प्रभाव दिखे:

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

## **विशिष्ट डेटा पॉइंट मान साफ करें**

एक बिंदु को खाली बनाने के लिए, उसके बैकिंग वर्कबुक सेल को `null` सेट करें, जबकि अन्य बिंदुओं को न हटाएँ। कॉलम चार्ट में, प्लॉटेड मान [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) के माध्यम से उपलब्ध होता है। डेटा पॉइंट वही श्रेणी स्थिति बनाए रखता है, लेकिन चार्ट उसके मान को खाली के रूप में मानता है, जैसा कि चार्ट के खाली‑मान सेटिंग्स में परिभाषित है।

निम्न उदाहरण पहले श्रृंखला के दूसरे बिंदु को ही साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y सेल्स का उपयोग करते हैं, और बबल चार्ट एक आकार सेल भी प्रयोग करता है। केवल उस सेल को साफ़ करें जो आप हटाना चाहते हैं। जब आप अन्य बिंदुओं को बनाए रखना चाहते हैं, तो [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) न कॉल करें, क्योंकि यह मेथड पूरी श्रृंखला के सभी बिंदुओं को हटा देता है।

## **खाली सेल प्रदर्शन को नियंत्रित करें**

छिपे हुए सेल्स जिनमें मान होते हैं, वे खाली सेल्स से अलग होते हैं। छिपी हुई पंक्तियों और स्तंभों से डेटा को शामिल या बाहर करने के लिए देखें [Include Data from Hidden Rows and Columns](/slides/hi/net/chart-workbook/#include-data-from-hidden-rows-and-columns)।

खाली वर्कबुक सेल अनुपलब्ध डेटा दर्शाता है; `0` वाला सेल ज्ञात संख्यात्मक मान दर्शाता है। सेल को खाली बनाने के लिए [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) को `null` सेट करें। संख्यात्मक शून्य हमेशा शून्य ही रहता है, चाहे खाली‑सेल सेटिंग कुछ भी हो।

खाली सेल्स को कैसे प्रदर्शित करें, यह चुनने के लिए [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) का उपयोग करें। यह सेटिंग पूरे चार्ट पर लागू होती है। यह खाली मानों को प्लॉट करने का तरीका बदलती है, बिना खाली वर्कबुक सेल को शून्य या इंटरपोलेटेड मान से भरते हुए।

निम्न स्वाधीन उदाहरण एक लाइन चार्ट एक श्रृंखला के साथ बनाता है, दिन 3 के मान को साफ़ करता है, और प्रत्येक मोड के साथ वही चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) वर्कशीट 0, श्रेणी लेबल के लिए स्तंभ 0, और मान के लिए स्तंभ 1 का उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रखता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

// Day 3 को वास्तव में खाली छोड़ें, जबकि उसकी श्रेणी और डेटा बिंदु को बनाए रखें।
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

प्रत्येक आउटपुट फ़ाइल उस मोड को संग्रहीत करती है जो सहेजने से पहले सेट किया गया था: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए इच्छित मोड असाइन करें और प्रस्तुति को एक बार सहेजें, बजाय मोड्स पर इटरेट करने के।

नीचे तुलना दिखाती है कि सभी तीन फ़ाइलों में डेटा समान है। दिन 3 प्रत्येक मामले में वर्कबुक में खाली है:

![लाइन चार्ट में समान डेटा: Gap दिन 3 पर लाइन को तोड़ता है, Zero लाइन को शून्य पर ढालता है, और Span दिन 2 को दिन 4 से जोड़ता है।](display_blanks_as.png)

दृश्यमान प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड की तुलना को आसान बनाता है। बार और कॉलम चार्ट में किसी गायब श्रेणी के ऊपर कनेक्ट करने वाली लाइन नहीं होती, इसलिए `Span` ऊपर दिखाए गए कनेक्टिंग सेगमेंट को उत्पन्न नहीं कर सकता; एक गायब कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी प्रकार, केवल मार्कर वाले स्कैटर चार्ट में भी कोई कनेक्टिंग लाइन नहीं होती। सभी चार्ट प्रकारों के लिए तीन विशिष्ट परिणामों की उम्मीद न रखें; उपयोग किए जा रहे प्रकार के लिए आउटपुट की जाँच करें।

## **श्रृंखला गैप विथ सेट करें**

गैप विथ समानांतर बार या कॉलम क्लस्टर्स के बीच का अंतराल है, जिसे बार या कॉलम की चौड़ाई के प्रतिशत के रूप में व्यक्त किया जाता है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से सम्बद्ध है, न कि किसी एकल श्रृंखला से। समूह के लिए एक बार [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) सेट करें। बड़ा मान क्लस्टर्स के बीच अधिक जगह बनाता है; छोटा मान उन्हें घना करता है।

निम्न उदाहरण गैप विथ बदलता है और केवल अंतिम प्रस्तुति सहेजता है:

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

## **श्रृंखला लाइनों को दिखाएँ या छिपाएँ**

श्रृंखला लाइनों से चार्ट के संबंधित भागों को दृश्य रूप से जोड़ा जाता है। समर्थित स्टैक्ड बार और ऑफ‑पाई चार्ट में इन्हें दिखाने या छिपाने के लिए [IChartSeriesGroup.HasSeriesLines](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hasserieslines/) का उपयोग करें। द्वि‑आयामी स्टैक्ड बार और कॉलम चार्ट में, वे श्रेणियों के बीच संबंधित स्टैक सीमाओं को जोड़ते हैं। पाई ऑफ़ पाई और बार ऑफ़ पाई चार्ट में, वे मुख्य प्लॉट को द्वितीयक प्लॉट से जोड़ते हैं। यह सेटिंग अन्य चार्ट प्रकारों के लिए सामान्य कनेक्टर नहीं है।

[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) के माध्यम से समूह तक पहुँचें। यह सेटिंग समूह की प्रत्येक श्रृंखला पर लागू होती है। [IChartSeries.HasSeriesLines](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/hasserieslines/) पढ़‑के‑सिर्फ है और पैरेंट समूह की सेटिंग को प्रतिबिंबित करता है; अपडेट के लिए समूह प्रॉपर्टी बदलें।

निम्न उदाहरण डिफ़ॉल्ट डेटा के साथ एक [PieOfPie](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) चार्ट बनाता है। यह श्रृंखला लाइनों को सक्षम और फिर अक्षम करके दो प्रस्तुति सहेजता है, जिससे तुलना संभव होती है।

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 400);
var series = chart.ChartData.Series[0];
var seriesGroup = series.ParentSeriesGroup;

seriesGroup.HasSeriesLines = true;
presentation.Save("series_lines_enabled.pptx", SaveFormat.Pptx);

seriesGroup.HasSeriesLines = false;
presentation.Save("series_lines_disabled.pptx", SaveFormat.Pptx);
```

| श्रृंखला लाइनों सक्रिय | श्रृंखला लाइनों निष्क्रिय |
| --- | --- |
| ![श्रृंखला लाइनों सह पाई ऑफ़ पाई चार्ट](series_lines_enabled.png) | ![श्रृंखला लाइनों बिना पाई ऑफ़ पाई चार्ट](series_lines_disabled.png) |
| दो लाइनों से मुख्य पाई को द्वितीयक पाई से जोड़ा जाता है। | दोनों पाई दिखते हैं, लेकिन कनेक्टिंग लाइनों को छिपाया गया है। |

श्रृंखला लाइनों का अंतर डेटा लेबल लीडर लाइनों, ग्रिडलाइन, या लाइन चार्ट की लाइनों से नहीं है; ये अलग‑अलग तत्व हैं। यह सेटिंग उन तत्वों को नियंत्रित नहीं करती।

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन‑से चार्ट प्रकार डेटा श्रृंखलाओं का समर्थन करते हैं?**

[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) enumeration से प्रतिनिधित्व किए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं का मूल्य संरचना या सेटिंग समान नहीं होती। उदाहरण के लिए, श्रेणी चार्ट में श्रेणियाँ और मान होते हैं, स्कैटर चार्ट में X और Y मान, तथा बबल चार्ट में बबल साइज़। श्रृंखला प्रकार से मेल खाने वाले डेटा‑पॉइंट निर्माण मेथड का उपयोग करें। ओवरलैप और गैप विथ जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**चार्ट श्रृंखला समूह क्या है?**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) में संगत श्रृंखलाएँ होती हैं जो समूह‑स्तर प्लॉटिंग सेटिंग्स साझा करती हैं। एक कॉम्बिनेशन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचा गया समूह सभी श्रृंखलाओं को अनिवार्य रूप से नहीं बदलता।

**क्या नव निर्मित चार्ट डिफ़ॉल्ट डेटा से भरा होता है?**

हाँ। डिफ़ॉल्ट रूप से, [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) नमूना श्रृंखलाएँ, श्रेणियाँ और मान बनाता है। आप इन सेल्स को संपादित कर सकते हैं या कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी कलेक्शन को साफ़ कर सकते हैं। ओवरलोड का उपयोग करके डिफ़ॉल्ट डेटा के बिना भी चार्ट बनाया जा सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक सेल्स से कैसे जुड़े हैं?**

श्रृंखला नाम, श्रेणी लेबल और डेटा‑पॉइंट मान [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) में सेल्स को संदर्भित करते हैं। संदर्भित सेल को बदलने से संबंधित चार्ट तत्व अपडेट हो जाता है। कस्टम डेटा बनाते समय, सुनिश्चित करें कि श्रेणी पंक्तियाँ और श्रृंखला‑मान पंक्तियाँ संरेखित हों ताकि प्रत्येक बिंदु इच्छित श्रेणी के तहत प्लॉट हो।

**मैं पूरी श्रृंखला के बजाए केवल एक बिंदु कैसे हटा सकता हूँ?**

बिंदु को खाली रखने के लिए संबंधित मान सेल को `null` सेट करें, जिससे बिंदु का श्रेणी स्थान बना रहे। अन्य बिंदुओं को बनाए रखने के लिये केवल यह कदम करें। सभी बिंदुओं को हटाने के लिये केवल तब [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) का उपयोग करें, क्योंकि यह मेथड श्रृंखला के सभी डेटा पॉइंट्स को हटा देता है।

**खाली बिंदुओं को कैसे प्रदर्शित किया जाता है?**

परिणाम चार्ट प्रकार और [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) पर निर्भर करता है। समर्थित चार्ट खाली को गैप, शून्य मान, या निकटस्थ बिंदुओं को जोड़कर प्रदर्शित कर सकते हैं। अपनी प्रस्तुति में डेटा की अनुपस्थिति के अर्थ के अनुसार सेटिंग चुनें। विस्तृत उदाहरण और दृश्य तुलना के लिये देखें **[खाली सेल प्रदर्शन को नियंत्रित करें](#control-the-display-of-empty-cells)**।

**नकारात्मक मानों का फ़ॉर्मेट कैसे है?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिए, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) सक्षम करें और [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) के माध्यम से नकारात्मक‑मान रंग सेट करें। आप व्यक्तिगत बिंदु के लिए [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) से व्यवहार को अधिलिखित कर सकते हैं। ये प्रॉपर्टी फ़ॉर्मेटिंग को प्रभावित करती हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों फ़ॉर्मेट हैं तो कौन जीतेगा?**

स्पष्ट डेटा‑पॉइंट फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मेट या, यदि श्रृंखला फ़ॉर्मेट परिभाषित नहीं है, तो स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। ओवरलैप और गैप विथ जैसी समूह गुण लेआउट को नियंत्रित करते हैं और बिंदु‑स्तर फ़ॉर्मेटिंग को अधिलिखित नहीं करते।

**क्या किसी चार्ट में श्रृंखलाओं की संख्या पर सीमा है?**

Aspose.Slides कोई अलग‑से स्थिर श्रृंखला‑गणना सीमा नहीं लगाता। व्यावहारिक रूप से, प्रस्तुति फ़ाइल सीमाएं, उपलब्ध मेमोरी, रेंडरिंग समय और चार्ट पठनीयता सीमित कर सकती हैं।

**जब कॉलम बहुत निकट या बहुत दूर हों तो क्या करना चाहिए?**

उक्त पैरेंट श्रृंखला समूह पर [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) सेट करें। मान बढ़ाने से क्लस्टर्स के बीच की जगह चौड़ी होगी, घटाने से वे निकट आएँगे।