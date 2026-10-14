---
title: .NET में प्रस्तुतियों में पाई चार्ट को अनुकूलित करें
linktitle: पाई चार्ट
type: docs
url: /hi/net/pie-chart/
keywords:
- पाई चार्ट
- चार्ट प्रबंधित करें
- चार्ट अनुकूलित करें
- चार्ट विकल्प
- चार्ट सेटिंग्स
- प्लॉट विकल्प
- स्लाइस रंग
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: ".NET में Aspose.Slides के साथ पाई चार्ट बनाएं और अनुकूलित करें। द्वितीयक प्लॉट्स को कॉन्फ़िगर करें, डेटा लेबल प्रदर्शित करें, और PowerPoint में स्वचालित स्लाइस रंग लागू करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में पाई चार्ट्स के साथ काम करने के तरीकों को समझाता है। यह Pie of Pie और Bar of Pie चार्ट्स के लिए द्वितीयक प्लॉट विकल्पों को कॉन्फ़िगर करने तथा मानक पाई चार्ट के लिए स्वचालित स्लाइस रंगकरण सक्षम करने को दिखाता है।

उदाहरणों में चार्ट को स्लाइड में जोड़ना, श्रृंखला और लेबल सेटिंग्स समायोजित करना, डिफ़ॉल्ट चार्ट डेटा को कस्टम श्रेणियों और मानों से बदलना, और अद्यतन प्रस्तुति को सहेजना जैसे चार्ट अनुकूलन कार्यों पर ध्यान केंद्रित किया गया है।

## **Pie of Pie और Bar of Pie चार्ट्स के लिए द्वितीयक प्लॉट विकल्प**

Aspose.Slides for .NET Pie of Pie और Bar of Pie चार्ट्स के लिए द्वितीयक प्लॉट विकल्पों को समर्थन देता है। ये विकल्प द्वितीयक प्लॉट का आकार और दो प्लॉट्स के बीच डेटा पॉइंट्स के विभाजन को नियंत्रित करते हैं।

निम्न उदाहरण एक नई प्रस्तुति में Pie of Pie चार्ट बनाता है और डेटा पॉइंट मानों को लेबल के रूप में प्रदर्शित करता है। [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) प्रॉपर्टी द्वितीयक प्लॉट का आकार मुख्य प्लॉट के 149% पर सेट करती है। [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) प्रतिशत‑आधारित विभाजन चुनती है, और [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) थ्रेशहोल्ड को 53% पर सेट करता है।

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Display values and configure the secondary plot.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```
### **द्वितीयक प्लॉट के लिए श्रेणियाँ चुनें**

जब आप विशिष्ट श्रेणियों को उनके प्रतिशत मानों की परवाह किए बिना द्वितीयक प्लॉट में समूहित करना चाहते हैं, तब कस्टम विभाजन का उपयोग करें। उदाहरण के लिए, एक बिक्री रिपोर्ट में ऑनलाइन और इवेंट्स को एक साथ दिखाया जा सकता है ताकि पाठक इन दो चैनलों की तुलना कर सकें, भले ही वे कुल बिक्री के 35% और 10% का योगदान देते हों।

द्वितीयक प्लॉट को कस्टम विभाजन के लिए सेट करने हेतु [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) को [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) पर सेट करें और बिंदुओं को [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/) के माध्यम से चुनें। संग्रह के [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) मेथड में श्रृंखला में शून्य‑आधारित इंडेक्स या डेटा पॉइंट ऑब्जेक्ट पास किया जा सकता है। इस उदाहरण में, इंडेक्स 1 ऑनलाइन को चुनता है, और इंडेक्स 3 इवेंट्स को। पार्टनर्स को भी अस्थायी रूप से जोड़ा गया, फिर [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/) का उपयोग करके बाहर किया गया।

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// डिफ़ॉल्ट डेटा को चैनल के अनुसार बिक्री से बदलें।
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// ऑनलाइन को उसके शून्य‑आधारित इंडेक्स से और इवेंट्स को उसके डेटा पॉइंट ऑब्जेक्ट से चुनें।
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// स्रोत डेटा को हटाए बिना चयन से पार्टनर्स को बाहर रखें।
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

ऑनलाइन (35) और इवेंट्स (10) द्वितीयक प्लॉट में अलग‑अलग स्लाइस के रूप में दिखते हैं। प्राथमिक प्लॉट में, वे 45 मान के साथ एक संयुक्त स्लाइस में दर्शाए जाते हैं, साथ ही रिटेल (40) और पार्टनर्स (15) भी। कस्टम चयन से पार्टनर्स को हटाने से वह प्राथमिक प्लॉट में रहता है; यह श्रेणी या उसका मान चार्ट के स्रोत डेटा से नहीं हटाता।

निम्न चित्र PowerPoint में सहेजी गई प्रस्तुति को दर्शाता है:
![द्वितीयक प्लॉट में Online और Events के साथ Pie of Pie चार्ट और प्राथमिक प्लॉट में उनका संयुक्त मान 45](pie_of_pie_custom.png)

## **स्वचालित पाई चार्ट स्लाइस रंग सेट करें**

Aspose.Slides for .NET पाई चार्ट स्लाइस को स्वचालित रूप से अलग‑अलग रंग असाइन कर सकता है। निम्न उदाहरण केंद्रित शीर्षक के साथ एक पाई चार्ट बनाता है और डिफ़ॉल्ट डेटा को तीन त्रैमासिक श्रेणियों और उनके मानों से बदलता है। [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) प्रॉपर्टी 20, 50, और 30 मानों को लेबल के रूप में दिखाती है, जबकि [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) प्रत्येक स्लाइस के लिए अलग रंग सक्षम करता है।

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// केन्द्रित चार्ट शीर्षक जोड़ें।
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// पहला कार्यपत्रक का उपयोग करके डिफ़ॉल्ट डेटा बदलें।
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// मान दिखाएँ और स्लाइसों को अलग‑अलग रंग असाइन करें।
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```
## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Pie of Pie और Bar of Pie वैरिएंट्स समर्थित हैं?**

हाँ, लाइब्रेरी पाई चार्ट्स के लिए द्वितीयक प्लॉट को [supports](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) समर्थन देती है, जिसमें Pie of Pie और Bar of Pie प्रकार शामिल हैं।

**क्या मैं केवल चार्ट को एक छवि (उदाहरण के लिए, PNG) के रूप में निर्यात कर सकता हूँ?**

हाँ, आप पूरी प्रस्तुति को निर्यात किए बिना [export the chart itself as an image](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (जैसे PNG) कर सकते हैं।