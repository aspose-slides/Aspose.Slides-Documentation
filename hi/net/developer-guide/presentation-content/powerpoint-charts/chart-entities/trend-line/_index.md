---
title: .NET में प्रस्तुति चार्ट में ट्रेंड लाइनों को जोड़ें
linktitle: ट्रेंड लाइन
type: docs
url: /hi/net/trend-line/
keywords:
- चार्ट
- ट्रेंड लाइन
- एक्सपोनेंशियल ट्रेंड लाइन
- रैखिक ट्रेंड लाइन
- लॉगरिदमिक ट्रेंड लाइन
- मूविंग एवरेज ट्रेंड लाइन
- पॉलीनॉमियल ट्रेंड लाइन
- पावर ट्रेंड लाइन
- कस्टम ट्रेंड लाइन
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "PowerPoint चार्ट में Aspose.Slides for .NET के साथ जल्दी से ट्रेंड लाइनों को जोड़ें और अनुकूलित करें — अपने दर्शकों को आकर्षित करने के लिए एक व्यावहारिक मार्गदर्शिका।"
---
## **समीक्षा**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति चार्ट में ट्रेंड लाइनों को जोड़ने के बारे में समझाता है। यह चार्ट बनाने, चार्ट सीरीज़ में ट्रेंड लाइनों को जोड़ने, और कई ट्रेंड लाइन प्रकारों के साथ काम करने को दिखाता है, जिसमें एक्सपोनेंशियल, रैखिक, लॉगरिदमिक, मूविंग एवरेज, पॉलीनॉमियल और पावर शामिल हैं।

यह भी वर्णन करता है कि लाइन शेप डालकर चार्ट में एक कस्टम लाइन कैसे जोड़ें, और आगे और पीछे ट्रेंड लाइन प्रोजेक्शन मानों के बारे में एक छोटा FAQ शामिल करता है तथा क्या ट्रेंड लाइनों को PDF या SVG में निर्यात करते समय और चार्ट को छवि के रूप में रेंडर करते समय संरक्षित रखा जाता है।

## **ट्रेंड लाइन जोड़ें**

एक चार्ट सीरीज़ में ट्रेंड लाइन जोड़ने के लिए [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) का उपयोग करें, और उसका प्रकार [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/) के साथ चुनें। उदाहरण एक डिफ़ॉल्ट डेटा के साथ क्लस्टर्ड कॉलम चार्ट बनाता है और प्रत्येक तीन सीरीज़ में दो ट्रेंड लाइनों को जोड़ता है।

एक्सपोनेंशियल ट्रेंड लाइन अपनी समीकरण और R-squared मान को [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) और [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/) के माध्यम से छिपाता है, जबकि रैखिक ट्रेंड लाइन लाल है। लॉगरिदमिक ट्रेंड लाइन एक कस्टम लेबल के लिए [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) का उपयोग करता है। मूविंग एवरेज तीन डेटा पॉइंट्स के [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) और कस्टम [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/) का उपयोग करता है।

पॉलीनॉमियल ट्रेंड लाइन का [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) तीन है और [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/) के माध्यम से एक श्रेणी आगे बढ़ती है। पावर ट्रेंड लाइन [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/) के माध्यम से एक श्रेणी पीछे तक बढ़ती है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```

## **ट्रेंड लाइन इंटरसेप्ट निर्धारित करें**

[Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) का उपयोग करके X = 0 पर ट्रेंड लाइन के Y मान को फिक्स करें। यह सेटिंग रैखिक, एक्सपोनेंशियल, और पॉलीनॉमियल ट्रेंड लाइनों के लिए समर्थित है।

उदाहरण के तौर पर, एक उत्पादन लागत मॉडल को ज्ञात स्थिर लागत 100 से शुरू होना पड़ सकता है, भले ही शून्य से अलग उत्पादन मात्रा पर माप अलग बेसलाइन सुझाते हों। रैखिक ट्रेंड लाइन के लिए, इंटरसेप्ट को फिक्स करने से समीकरण `y = ax + b` को `b = 100` तक सीमित किया जाता है; ढाल इस बाधा के तहत डेटा के अनुसार फिट की जाती है। यह केवल पहले से फ़िट की गई लाइन को स्थानांतरित नहीं करता। अक्ष क्रॉसिंग सेटिंग्स निर्धारित करती हैं कि चार्ट अक्ष कहाँ मिलते हैं, न कि फ़िट की गई ट्रेंड लाइन के गुणांक।

नीचे दिया गया उदाहरण 1 से 4 तक के उत्पादन मात्रा और 170, 200, 230, और 260 की लागत के साथ एक स्कैटर (XY) चार्ट बनाता है। यह डिफ़ॉल्ट ऑटोमैटिक इंटरसेप्ट के साथ चार्ट को सहेजता है, इंटरसेप्ट को 100 पर सेट करता है, और दूसरा PPTX सहेजता है। दोनों फ़ाइलें केवल इंटरसेप्ट सेटिंग में अंतर रखती हैं। ट्रेंड लाइन अपना समीकरण दिखाती है और X = 0 तक वापस विस्तारित होती है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

ऑटोमैटिक कैलकुलेशन के साथ, ये डेटा `y = 30x + 140` उत्पन्न करते हैं। इंटरसेप्ट को 100 पर सेट करने से लगभग `y = 43.33x + 100` प्राप्त होता है: शून्य पर फिट हुआ मान ज्ञात बेसलाइन से मेल खाता है, जबकि लाइन अब हर डेटा पॉइंट के माध्यम से नहीं जाती।

| ऑटोमैटिक इंटरसेप्ट | 100 का फिक्स्ड इंटरसेप्ट |
| --- | --- |
| ![140 का ऑटोमैटिक गणना किया गया इंटरसेप्ट वाला रैखिक ट्रेंड लाइन](intercept-automatic.png) | ![100 का फिक्स्ड इंटरसेप्ट वाला रैखिक ट्रेंड लाइन](intercept-fixed.png) |

दोनों चित्र समान डेटा और अक्ष स्केल का उपयोग करते हैं। ट्रेंड लाइनों को X = 0 तक वापस विस्तारित किया गया है ताकि उनका इंटरसेप्ट दिखाया जा सके।

डिफ़ॉल्ट रूप से, प्रॉपर्टी में `double.NaN` होता है, जो शून्य के बजाय एक अनिर्दिष्ट इंटरसेप्ट दर्शाता है। इंटरसेप्ट फिर डेटा से ऑटोमैटिक रूप से गणना किया जाता है।

## **कस्टम लाइन जोड़ें**

कस्टम लाइन एक ऐसी शेप है जो चार्ट के ऊपर खींची जाती है, न कि सीरीज़ डेटा से गणना की गई ट्रेंड लाइन। यह उदाहरण [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) का उपयोग करके चार्ट के ऊपर स्लाइड में एक हॉरिज़ॉन्टल लाइन जोड़ता है। लाइन की स्थिति स्लाइड कॉर्डिनेट्स में पॉइंट्स में दी गई है, इसलिए यह चार्ट के बाएँ किनारे से शुरू होती है और चार्ट के मध्य में बैठती है। इसकी चौड़ाई चार्ट की चौड़ाई के समान है। [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) लाइन को सॉलिड रेड रंग देता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**ट्रेंड लाइन के लिए 'forward' और 'backward' का क्या अर्थ है?**

ये ट्रेंड लाइन की आगे/पीछे प्रोजेक्ट की गई लंबाइयाँ हैं: स्कैटर (XY) चार्ट के लिए — अक्ष इकाइयों में; गैर-स्कैटर चार्ट के लिए — श्रेणियों की संख्या में। केवल गैर-नकारात्मक मानों की अनुमति है।

**क्या प्रस्तुति को PDF या SVG में निर्यात करने या स्लाइड को छवि के रूप में रेंडर करने पर ट्रेंड लाइन संरक्षित रहती है?**

हाँ। Aspose.Slides प्रस्तुतियों को [PDF](/slides/hi/net/convert-powerpoint-to-pdf/) या [SVG](/slides/hi/net/render-a-slide-as-an-svg-image/) में परिवर्तित करता है और चार्ट को छवियों में रेंडर करता है; ट्रेंड लाइनों को, चार्ट का हिस्सा होने के नाते, इन ऑपरेशनों के दौरान संरक्षित रखा जाता है। एक मेथड भी उपलब्ध है जो स्वयं [चार्ट की छवि निर्यात करें](/slides/hi/net/create-shape-thumbnails/)।