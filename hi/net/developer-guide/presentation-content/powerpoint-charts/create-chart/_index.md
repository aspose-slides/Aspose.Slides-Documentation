---
title: PowerPoint प्रस्तुति चार्ट को .NET में बनाएँ या अपडेट करें
linktitle: चार्ट बनाएं या अपडेट करें
type: docs
weight: 10
url: /hi/net/create-chart/
keywords:
- चार्ट जोड़ें
- चार्ट बनाएं
- चार्ट संपादित करें
- चार्ट बदलें
- चार्ट अपडेट करें
- स्कैटर चार्ट
- पाई चार्ट
- लाइन चार्ट
- ट्री मैप चार्ट
- स्टॉक चार्ट
- बॉक्स एंड विस्कर चार्ट
- फ़नल चार्ट
- सनबर्स्ट चार्ट
- हिस्टोग्राम चार्ट
- रेडार चार्ट
- मल्टीकैटेगरी चार्ट
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट बनाएं और अनुकूलित करें। C# में व्यावहारिक कोड उदाहरणों के साथ चार्ट जोड़ें, फ़ॉर्मेट करें और संपादित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for .NET का उपयोग करके चार्ट बनाने और अनुकूलित करने पर एक व्यापक गाइड प्रदान करता है। आप सीखेंगे कि प्रोग्रामेटिक रूप से स्लाइड में चार्ट कैसे जोड़ें, उसे डेटा से भरें, और आपके विशिष्ट डिज़ाइन आवश्यकताओं के अनुरूप विभिन्न फॉर्मेटिंग विकल्प कैसे लागू करें। लेख में विस्तृत कोड उदाहरण प्रत्येक चरण को स्पष्ट करते हैं, प्रस्तुति और चार्ट ऑब्जेक्ट को इनिशियलाइज़ करने से लेकर सीरीज़, अक्ष और लेजेंड को कॉन्फ़िगर करने तक। इस गाइड को अनुसरण करके आप अपने .NET अनुप्रयोगों में डायनामिक चार्ट जनरेशन को एकीकृत करने की ठोस समझ प्राप्त करेंगे, जिससे डेटा‑ड्रिवेन प्रस्तुतियों को बनाना सरल हो जाएगा।

## **एक चार्ट बनाएं**

चार्ट लोगों को डेटा को शीघ्रता से दृश्य रूप में प्रस्तुत करने और उन अंतर्दृष्टियों को प्राप्त करने में मदद करते हैं जो तालिका या स्प्रेडशीट से तुरंत स्पष्ट नहीं हो सकतीं।

**चार्ट क्यों बनाएं?**

चार्ट का उपयोग करके आप:

* बड़े डेटा सेट को एक ही स्लाइड में संक्षिप्त या सारांशित कर सकते हैं;
* डेटा में पैटर्न और रुझान उजागर कर सकते हैं;
* समय के साथ या किसी विशिष्ट माप इकाई के सापेक्ष डेटा की दिशा और गति का अनुमान लगा सकते हैं;
* आउट्लायर, विचलन, त्रुटियां और असंगत डेटा पहचान सकते हैं;
* जटिल डेटा को प्रभावी रूप से संप्रेषित या प्रस्तुत कर सकते हैं।

PowerPoint में आप *Insert* फ़ंक्शन के माध्यम से कई प्रकार के चार्ट टेम्प्लेट का उपयोग करके चार्ट बना सकते हैं। Aspose.Slides का उपयोग करके आप नियमित चार्ट (प्रचलित चार्ट प्रकारों पर आधारित) और कस्टम चार्ट दोनों बना सकते हैं।

{{% alert color="info" title="Note" %}}
Use the [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) enumeration under the [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/) namespace. The values in this enumeration correspond to different chart types.
{{% /alert %}}

### **क्लस्टर्ड कॉलम चार्ट बनाएं**

यह उदाहरण दो सीरीज़ को तीन श्रेणियों में तुलना करने वाला क्लस्टर्ड कॉलम चार्ट बनाने के लिए [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) का उपयोग करता है। सीरीज़ लाल और हरे फ़िल्स का उपयोग करती हैं, तथा व्यक्तिगत लेबल श्रेणी नाम, सीरीज़ नाम और मान प्रदर्शित करते हैं। वर्कशीट इंडेक्स 0 एम्बेडेड चार्ट वर्कबुक की पहले शीट को दर्शाता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series[0];

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

series = chart.ChartData.Series[1];

valueCell = workbook.GetCell(worksheetIndex, 1, 2, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 2, 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 2, 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;

var label = series.DataPoints[0].Label;
label.DataLabelFormat.ShowCategoryName = true;

label = series.DataPoints[1].Label;
label.DataLabelFormat.ShowSeriesName = true;

label = series.DataPoints[2].Label;
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.ShowSeriesName = true;
label.DataLabelFormat.Separator = "/";

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

परिणाम:

![क्लस्टर्ड कॉलम चार्ट](clustered_column_chart.png)

### **स्कैटर चार्ट बनाएं**

स्कैटर चार्ट (जिसे स्कैटर प्लॉट या x‑y ग्राफ भी कहा जाता है) अक्सर दो चर के बीच के पैटर्न या सहसंबंध की जाँच के लिए उपयोग किए जाते हैं।

स्कैटर चार्ट का उपयोग तब करें जब:

* आपके पास जोड़ीदार संख्यात्मक डेटा हो;
* आपके पास दो चर हों जो आपस में संगत हों;
* आप तय करना चाहते हों कि दो चर संबंधित हैं या नहीं;
* आपके पास एक स्वतंत्र चर हो जिसके लिए निर्भर चर के कई मान हों।

यह उदाहरण दो सेट के x‑y मानों को प्लॉट करता है। पहली सीरीज़ सीधे रेखाओं के साथ स्टार मार्कर उपयोग करती है, जबकि दूसरी स्मूथ रेखाओं के साथ सर्कल मार्कर; दोनों का [Size](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/size/) 10 है। [Symbol](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/symbol/) प्रॉपर्टी मार्कर के आकार को नियंत्रित करती है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 1, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 1, 3, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var series = chart.ChartData.Series[0];

var xValueCell = workbook.GetCell(worksheetIndex, 2, 1, 1);
var yValueCell = workbook.GetCell(worksheetIndex, 2, 2, 3);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 1, 2);
yValueCell = workbook.GetCell(worksheetIndex, 3, 2, 10);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

series = chart.ChartData.Series[1];

xValueCell = workbook.GetCell(worksheetIndex, 2, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 2, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 3, 3);
yValueCell = workbook.GetCell(worksheetIndex, 3, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 4, 3, 2);
yValueCell = workbook.GetCell(worksheetIndex, 4, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 5, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 5, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

परिणाम:

![स्कैटर चार्ट](scatter_chart.png)

### **पाई चार्ट बनाएं**

पाई चार्ट डेटा में भाग‑से‑सम्पूर्ण संबंध दिखाने के लिए सबसे उपयुक्त होते हैं, विशेषकर जब डेटा में श्रेणी लेबल के साथ संख्यात्मक मान हों। हालांकि, यदि आपके डेटा में कई भाग या लेबल हों, तो आप बार चार्ट का उपयोग करने पर विचार कर सकते हैं।

यह उदाहरण तीन त्रैमासिक मानों के साथ एक पाई चार्ट बनाता है। प्रत्येक स्लाइस का अपना कस्टम फ़िल और बॉर्डर है, और लेबल विभिन्न संयोजनों में मान, प्रतिशत और सीरीज़ जानकारी दिखाते हैं। [FirstSliceAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/firstsliceangle/) प्रॉपर्टी पहला स्लाइस 180 डिग्री से शुरू करती है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var categoryCell = workbook.GetCell(0, 1, 0, "1st Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "2nd Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "3rd Qtr");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForPieSeries(valueCell);

chart.ChartData.SeriesGroups[0].IsColorVaried = true;

var firstSlice = series.DataPoints[0];
firstSlice.Format.Fill.FillType = FillType.Solid;
firstSlice.Format.Fill.SolidFillColor.Color = Color.Cyan;

firstSlice.Format.Line.FillFormat.FillType = FillType.Solid;
firstSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
firstSlice.Format.Line.Width = 3.0;
firstSlice.Format.Line.Style = LineStyle.ThinThick;
firstSlice.Format.Line.DashStyle = LineDashStyle.LargeDash;

var secondSlice = series.DataPoints[1];
secondSlice.Format.Fill.FillType = FillType.Solid;
secondSlice.Format.Fill.SolidFillColor.Color = Color.Brown;

secondSlice.Format.Line.FillFormat.FillType = FillType.Solid;
secondSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
secondSlice.Format.Line.Width = 3.0;
secondSlice.Format.Line.Style = LineStyle.Single;
secondSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

var thirdSlice = series.DataPoints[2];
thirdSlice.Format.Fill.FillType = FillType.Solid;
thirdSlice.Format.Fill.SolidFillColor.Color = Color.Coral;

thirdSlice.Format.Line.FillFormat.FillType = FillType.Solid;
thirdSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
thirdSlice.Format.Line.Width = 2.0;
thirdSlice.Format.Line.Style = LineStyle.ThinThin;
thirdSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

var firstLabel = series.DataPoints[0].Label;
firstLabel.DataLabelFormat.ShowValue = true;

var secondLabel = series.DataPoints[1].Label;
secondLabel.DataLabelFormat.ShowValue = true;
secondLabel.DataLabelFormat.ShowLegendKey = true;
secondLabel.DataLabelFormat.ShowPercentage = true;

var thirdLabel = series.DataPoints[2].Label;
thirdLabel.DataLabelFormat.ShowSeriesName = true;
thirdLabel.DataLabelFormat.ShowPercentage = true;

series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

presentation.Save("PieChart.pptx", SaveFormat.Pptx);
```

परिणाम:

![पाई चार्ट](pie_chart.png)

### **लाइन चार्ट बनाएं**

लाइन चार्ट (जिसे लाइन ग्राफ भी कहा जाता है) उन स्थितियों में सबसे उपयुक्त होते हैं जहां आप समय के साथ मान में बदलाव दिखाना चाहते हैं। लाइन चार्ट के माध्यम से आप एक साथ बड़ी मात्रा में डेटा की तुलना कर सकते हैं, समय के साथ बदलाव और रुझानों को ट्रैक कर सकते हैं, डेटा सीरीज़ में विसंगतियों को उजागर कर सकते हैं, आदि।

यह उदाहरण [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) का उपयोग करके डिफ़ॉल्ट सीरीज़ और श्रेणियों के साथ एक लाइन चार्ट बनाता है, फिर प्रस्तुति को PPTX के रूप में सहेजता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

presentation.Save("lineChart.pptx", SaveFormat.Pptx);
```

डिफ़ॉल्ट रूप से, लाइन चार्ट में बिंदु सीधे सतत रेखाओं से जुड़े होते हैं। यदि आप बिंदुओं को डैश द्वारा जोड़ना चाहते हैं, तो [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) को [LineDashStyle](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) में से किसी मान पर सेट करें:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

foreach (var series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

परिणाम:

![लाइन चार्ट](line_chart.png)

### **ट्री मैप चार्ट बनाएं**

ट्री मैप चार्ट बिक्री डेटा के लिए सबसे उपयुक्त होते हैं जब आप डेटा श्रेणियों के सापेक्ष आकार दिखाना चाहते हैं और प्रत्येक श्रेणी के भीतर बड़े योगदानकर्ताओं पर जल्दी से ध्यान केंद्रित करना चाहते हैं।

यह उदाहरण आठ लीफ़ को चार स्टेम और दो ब्रांच में समूहित करके एक ट्री मैप बनाता है। [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) मेथड स्टेम को समूह स्तर 1 और ब्रांच को स्तर 2 पर असाइन करता है। मान संबंधित आयताकार आकार निर्धारित करते हैं, जबकि श्रेणी लेबल और ओवरलैपिंग पैरेंट लेबल पदानुक्रम दर्शाते हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// शाखा 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// शाखा 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Treemap);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);

series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

presentation.Save("Treemap.pptx", SaveFormat.Pptx);
```

परिणाम:

![ट्रीमैप चार्ट](treemap_chart.png)

### **वॉटरफ़ॉल चार्ट बनाएं**

वॉटरफ़ॉल चार्ट यह दिखाता है कि सकारात्मक और नकारात्मक परिवर्तन अंतिम मान में कैसे योगदान देते हैं। उदाहरण के लिए, एक लाभ विभाजन राजस्व से शुरू हो सकता है, लागत घटा सकता है, और अन्य आय जोड़ सकता है। परिवर्तन कॉलम पूर्व और नवीन चल रहे मानों के बीच तैरते हैं, जबकि कुल कॉलम शून्य से संचयी मान तक विस्तारित होते हैं।

निम्न उदाहरण में राशि हजारों अमेरिकी डॉलर में दी गई हैं:

| श्रेणी | वर्कबुक मान | कॉलम प्रकार |
| --- | ---: | --- |
| राजस्व | 1000 | वृद्धि |
| बिक्री लागत | -400 | कमी |
| सकल लाभ | 600 | मध्यवर्ती कुल |
| संचालन व्यय | -200 | कमी |
| अन्य आय | 50 | वृद्धि |
| शुद्ध लाभ | 450 | अंतिम कुल |

किसी बिंदु को मध्यवर्ती या अंतिम कुल के रूप में चिन्हित करने के लिए, उसके [SetAsTotal](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatapoint/setastotal/) प्रॉपर्टी को `true` सेट करें। उस बिंदु की वर्कबुक सेल में वास्तविक संचयी राशि प्रदान करें: सकल लाभ के लिए `600` (`1000 - 400`) और शुद्ध लाभ के लिए `450` (`600 - 200 + 50`)। यह प्रॉपर्टी कॉलम को कुल के रूप में चिन्हित करती है; यह सेल मान की गणना या पूर्ति नहीं करती। शून्य को प्लेसहोल्डर के रूप में उपयोग न करें या कुल बिंदु के लिए कोई अन्य परिवर्तन न दें। कुल कॉलम बिना दोबारा जोड़ने के संचयी मान दिखाता है।

यह पूरा C# उदाहरण [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) के `Waterfall` सदस्य का उपयोग करके एक चार्ट बनाता है, डिफ़ॉल्ट डेटा को साफ़ करता है, और एम्बेडेड वर्कबुक को भरता है। वर्कशीट इंडेक्स `0` पहली शीट चुनता है; कॉलम A श्रेणी नाम रखता है और कॉलम B मान। प्रत्येक मान सेल को [AddDataPointForWaterfallSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/adddatapointforwaterfallseries/) से जोड़ा जाता है। शून्य‑आधारित बिंदु इंडेक्स `2` और `5` क्रमशः मध्यवर्ती और अंतिम कुल को दर्शाते हैं। [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) सक्षम करने से कॉलम पर राशि दिखती है। कोई इनपुट प्रस्तुति या वर्कबुक आवश्यक नहीं है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Waterfall, 20, 20, 680, 200);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Profit breakdown (USD thousands)");
chart.ChartTitle.Overlay = false;
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

workbook.Clear(worksheetIndex);

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Profit");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Waterfall);
var categories = new[] { "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" };
var values = new double[] { 1000, -400, 600, -200, 50, 450 };

for (var i = 0; i < categories.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categories[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForWaterfallSeries(valueCell);
}

// तीसरा और छठा बिंदु कुल को दर्शाते हैं, अतिरिक्त परिवर्तन नहीं।
series.DataPoints[2].SetAsTotal = true;
series.DataPoints[5].SetAsTotal = true;
series.ShowConnectorLines = true;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("WaterfallChart.pptx", SaveFormat.Pptx);
```

सीरीज़‑स्तर का [ShowConnectorLines](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/showconnectorlines/) प्रॉपर्टी `true` सेट करने से क्रमागत कॉलम को जोड़ने वाली रेखाएँ दिखती हैं और चल रहे मान को समझना आसान हो जाता है। इन रेखियों को छिपाने के लिए, उदाहरण में असाइनमेंट को `series.ShowConnectorLines = false;` में बदल दें और फिर सहेजें। यह केवल रेखा की दृश्यता बदलता है, डेटा या कुलों को नहीं।

सहेजी गई प्रस्तुति में 600 का सकल लाभ और 450 का शुद्ध लाभ दिखता है, दोनों कुल शून्य से शुरू होते हैं:

![वॉटरफ़ॉल चार्ट जिसमें राजस्व, लागत, 600 का सकल लाभ, और 450 का शुद्ध लाभ, मान लेबल और कनेक्टर लाइन्स के साथ दिखाया गया है](waterfall_chart.png)

### **स्टॉक चार्ट बनाएं**

स्टॉक चार्ट का उपयोग खुले, उच्च, निम्न, और बंद मूल्य जैसे वित्तीय डेटा को प्रदर्शित करने के लिए किया जाता है, जिससे बाजार रुझानों और अस्थिरता का विश्लेषण संभव होता है। ये चार्ट स्टॉक प्रदर्शन पर महत्वपूर्ण अंतर्दृष्टि प्रदान करते हैं, जिससे निवेशकों और विश्लेषकों को सूचित निर्णय लेने में मदद मिलती है।

यह उदाहरण चार श्रृंखलाओं (ओपन‑हाई‑लो‑क्लोज) के क्रम में और तीन श्रेणियों के साथ एक स्टॉक चार्ट बनाता है। [HasUpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/hasupdownbars/) प्रॉपर्टी अप/डाउन बार सक्षम करती है, और [HiLowLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hilowlinesformat/) हाई‑लो लाइन्स को नियंत्रित करती है जो मूल्य रेंज दिखाती हैं, जबकि व्यक्तिगत श्रृंखला रेखाएँ और मामूली क्षैतिज ग्रिडलाइन छिपी रहती हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

var workbook = chart.ChartData.ChartDataWorkbook;

var categoryCell = workbook.GetCell(0, 1, 0, "A");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "B");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "C");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Open");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 2, "High");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 3, "Low");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 4, "Close");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);

var series = chart.ChartData.Series[0];
var valueCell = workbook.GetCell(0, 1, 1, 72);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 1, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 1, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[1];
valueCell = workbook.GetCell(0, 1, 2, 172);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[2];
valueCell = workbook.GetCell(0, 1, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 3, 13);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[3];
valueCell = workbook.GetCell(0, 1, 4, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 4, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 4, 50);
series.DataPoints.AddDataPointForStockSeries(valueCell);

chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

foreach (var stockSeries in chart.ChartData.Series)
{
    stockSeries.Format.Line.FillFormat.FillType = FillType.NoFill;
}

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
```

परिणाम:

![स्टॉक चार्ट](stock_chart.png)

### **बॉक्स एंड विस्कर चार्ट बनाएं**

बॉक्स एंड विस्कर चार्ट डेटा वितरण को प्रमुख सांख्यिकीय माप (मीडियन, क्वार्टाइल, संभावित आउट्लायर) का सारांश प्रस्तुत करके दर्शाते हैं। ये एक्सप्लोरेटरी डेटा विश्लेषण और सांख्यिकीय अध्ययनों में जल्दी से डेटा वैरिएबिलिटी समझने और असामान्यताओं की पहचान करने के लिए उपयोगी होते हैं।

यह उदाहरण छह मानों से बॉक्स एंड विस्कर चार्ट बनाता है। [QuartileMethod](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/quartilemethod/) प्रॉपर्टी विशेष क्वार्टाइल गणना चुनती है। उदाहरण में औसत रेखाएँ, औसत मार्कर, आंतरिक बिंदु, और आउट्लायर बिंदु भी सक्षम किए गए हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

series.QuartileMethod = QuartileMethodType.Exclusive;
series.ShowMeanLine = true;
series.ShowMeanMarkers = true;
series.ShowInnerPoints = true;
series.ShowOutlierPoints = true;

var valueCell = workbook.GetCell(0, "B1", 15);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 41);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 10);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 23);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);

presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
```

### **फनल चार्ट बनाएं**

फनल चार्ट उन क्रमिक चरणों को दृश्य रूप में प्रस्तुत करने के लिए उपयोग किए जाते हैं, जहां डेटा की मात्रा अगले चरण में प्रगति के साथ घटती है। ये विशेष रूप से रूपांतरण दरों का विश्लेषण करने, बाधाओं की पहचान करने, और बिक्री या मार्केटिंग प्रक्रियाओं की दक्षता को ट्रैक करने में सहायक होते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड में एक फनल चार्ट जोड़ने के लिए [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) का उपयोग करता है। यह डिफ़ॉल्ट डेटा को छह श्रेणियों और 50 से 500 तक के मानों से बदलता है, फिर अद्यतन प्रस्तुति को सहेजता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड होना आवश्यक है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Funnel);

var valueCell = workbook.GetCell(0, "B1", 50);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 100);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 200);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 300);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 400);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 500);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);

presentation.Save("Funnel.pptx", SaveFormat.Pptx);
```

परिणाम:

![फनल चार्ट](funnel_chart.png)

### **सनबर्स्ट चार्ट बनाएं**

सनबर्स्ट चार्ट पद‑से‑सम्पूर्ण संबंधों को दर्शाने के लिए階層िक डेटा को अधिवेशीय रिंग में प्रदर्शित करते हैं। ये नेस्टेड श्रेणियों और उप‑श्रेणियों को स्पष्ट, संकुचित रूप में प्रस्तुत करने के लिए आदर्श होते हैं।

यह उदाहरण आठ लीफ़ को चार स्टेम और दो ब्रांच में समूहित करके एक सनबर्स्ट चार्ट बनाता है। [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) मेथड स्टेम को समूह स्तर 1 और ब्रांच को स्तर 2 पर असाइन करता है। श्रेणी लेबल सेगमेंट पहचानते हैं, और मान उनके सापेक्ष आकार तय करते हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// शाखा 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// शाखा 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Sunburst);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);

presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
```

परिणाम:

![सनबर्स्ट चार्ट](sunburst_chart.png)

### **हिस्टोग्राम चार्ट बनाएं**

हिस्टोग्राम चार्ट संख्यात्मक डेटा के वितरण को रेंज या बिन में समूहित करके प्रदर्शित करते हैं। ये डेटा पैटर्न (आवृत्ति, झुकाव, प्रसार) की पहचान और डेटा सेट में आउट्लायर खोजने में विशेष रूप से उपयोगी होते हैं।

यह उदाहरण छह संख्यात्मक मानों (नकारात्मक मान सहित) से एक हिस्टोग्राम बनाता है। [AggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/aggregationtype/) को ऑटोमैटिक सेट करने से चार्ट डिस्ट्रिब्यूशन दिखाने के लिए उपयुक्त बिन निर्धारित करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
var valueCell = workbook.GetCell(0, "A1", 15);
series.DataPoints.AddDataPointForHistogramSeries(valueCell);
valueCell = workbook.GetCell(0, "A2", -41);
series.DataPoints.AddDataPointForHistogramSeries(valueCell);
valueCell = workbook.GetCell(0, "A3", 16);
series.DataPoints.AddDataPointForHistogramSeries(valueCell);
valueCell = workbook.GetCell(0, "A4", 10);
series.DataPoints.AddDataPointForHistogramSeries(valueCell);
valueCell = workbook.GetCell(0, "A5", -23);
series.DataPoints.AddDataPointForHistogramSeries(valueCell);
valueCell = workbook.GetCell(0, "A6", 16);
series.DataPoints.AddDataPointForHistogramSeries(valueCell);

chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

presentation.Save("Histogram.pptx", SaveFormat.Pptx);
```

परिणाम:

![हिस्टोग्राम चार्ट](histogram_chart.png)

### **रेडार चार्ट बनाएं**

रेडार चार्ट मल्टीवेरिएट डेटा को दो‑आयामी प्रारूप में प्रदर्शित करते हैं, जिससे कई मानकों की एक साथ आसान तुलना संभव होती है। ये कई प्रदर्शन मीट्रिक या गुणों में पैटर्न, शक्तियों और कमजोरियों की पहचान के लिए उपयोगी होते हैं।

यह उदाहरण [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) का उपयोग करके डिफ़ॉल्ट सीरीज़ और श्रेणियों के साथ एक रेडार चार्ट बनाता है, फिर प्रस्तुति को PPTX के रूप में सहेजता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);

presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
```

परिणाम:

![रेडार चार्ट](radar_chart.png)

### **मल्टी‑कैटेगरी चार्ट बनाएं**

मल्टी‑कैटेगरी चार्ट उन डेटा को प्रदर्शित करने के लिए उपयोग किए जाते हैं जिसमें एक से अधिक श्रेणी समूह शामिल होते हैं, जिससे आप कई आयामों में मानों की एक साथ तुलना कर सकते हैं। ये जटिल, बहु‑परत डेटा सेट में रुझान और संबंधों का विश्लेषण करने में विशेष रूप से मददगार होते हैं।

यह उदाहरण चार जोड़ों में व्यवस्थित आठ श्रेणियों के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है। [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) मेथड प्रत्येक जोड़े को समूह स्तर 1 पर साझा लेबल देता है, जिससे श्रेणी अक्ष में व्यक्तिगत और समूह दोनों लेबल दिखते हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var worksheetIndex = 0;

var categoryCell = workbook.GetCell(0, "c2", "A");
var category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group1");
categoryCell = workbook.GetCell(0, "c3", "B");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c4", "C");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group2");
categoryCell = workbook.GetCell(0, "c5", "D");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c6", "E");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group3");
categoryCell = workbook.GetCell(0, "c7", "F");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c8", "G");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group4");
categoryCell = workbook.GetCell(0, "c9", "H");
category = chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, "D1", "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

var valueCell = workbook.GetCell(worksheetIndex, "D2", 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D3", 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D4", 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D5", 40);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D6", 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D7", 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D8", 70);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D9", 80);
series.DataPoints.AddDataPointForBarSeries(valueCell);

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

परिणाम:

![मल्टि‑कैटेगरी चार्ट](multi_category_chart.png)

### **मैप चार्ट बनाएं**

मैप चार्ट भौगोलिक डेटा को देशों, प्रदेशों या शहरों जैसी विशिष्ट स्थानों पर मैप करके दृश्य रूप में प्रस्तुत करने के लिए उपयोग किए जाते हैं। ये क्षेत्रीय रुझानों, जनसांख्यिकीय डेटा, और स्थानिक वितरण का स्पष्ट, आकर्षक विश्लेषण करने में सहायक होते हैं।

यह उदाहरण [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) का उपयोग करके डिफ़ॉल्ट भौगोलिक डेटा के साथ एक मैप चार्ट बनाता है और उसे PowerPoint में देखने के लिए सहेजता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);

presentation.Save("mapChart.pptx", SaveFormat.Pptx);
```

परिणाम:

![मैप चार्ट](map_chart.png)

{{% alert color="info" title="Note" %}}
उपरोक्त चित्र में सहेजी गई प्रस्तुति को PowerPoint में खोला गया दिखाया गया है। Aspose.Slides मैप चार्ट और उसके डेटा को सही ढंग से लिखता है, लेकिन स्वयं मैप चार्ट नहीं बनाता: जब कोई स्लाइड जिसमें मैप चार्ट हो, को छवि में रेंडर किया जाता है या PDF/SVG में परिवर्तित किया जाता है, तो चार्ट क्षेत्र खाली दिखाई देता है। उसी स्लाइड के अन्य आकार अप्रभावित रहते हैं।
{{% /alert %}}

### **कॉम्बिनेशन चार्ट बनाएं**

एक कॉम्बिनेशन (या कॉम्बो) चार्ट एक ही ग्राफ में दो या अधिक चार्ट प्रकारों को मिलाता है। यह चार्ट आपको दो या अधिक डेटा सेट के बीच अंतर उजागर, तुलना या जांचने की अनुमति देता है, जिससे आप उनके बीच के संबंधों को पहचान सकते हैं।

![कॉम्बिनेशन चार्ट](combination_chart.png)

यह उदाहरण चार क्लस्टर्ड कॉलम सीरीज़ को एक लाइन सीरीज़ के साथ चार श्रेणियों में संयोजित करता है। कॉलम प्राथमिक लंबवत अक्ष का उपयोग करते हैं, जबकि [PlotOnSecondAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/plotonsecondaxis/) लाइन को दाएँ पर द्वितीय लंबवत अक्ष पर रखता है। हेल्पर फ़ंक्शन शीर्षक, लेजेंड, अक्ष लेबल और ग्रिडलाइन को कॉन्फ़िगर करते हैं।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

CreateComboChart();

static void CreateComboChart()
{
    using var presentation = new Presentation();
    var chart = CreateChartWithFirstSeries(presentation.Slides[0]);

    AddSecondSeriesToChart(chart);
    AddThirdSeriesToChart(chart);

    SetPrimaryAxesFormat(chart);
    SetSecondaryAxesFormat(chart);

    presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
}

static IChart CreateChartWithFirstSeries(ISlide slide)
{
    var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    var portionFormat = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    var worksheetIndex = 0;

    var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 4, 0, "Category 4");
    chart.ChartData.Categories.Add(categoryCell);

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
    var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 4.3);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 1, 2.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 1, 3.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 1, 4.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);

    return chart;
}

static void AddSecondSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 2, 2.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 2, 4.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 2, 1.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 2, 2.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

static void AddThirdSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Line);

    var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 3, 3.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 3, 5.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);

    series.PlotOnSecondAxis = true;
}

static void SetPrimaryAxesFormat(IChart chart)
{
    var horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    var verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    var majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

static void SetSecondaryAxesFormat(IChart chart)
{
    var secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    var secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    var titlePortionFormat = axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **चार्ट अपडेट करें**

Aspose.Slides for .NET आपको PowerPoint चार्ट को डेटा, फॉर्मेटिंग और स्टाइलिंग में बदलाव करके अपडेट करने की सुविधा देता है। यह सुविधा प्रस्तुतियों को डायनामिक कंटेंट के साथ अद्यतन रखने को आसान बनाती है और यह सुनिश्चित करती है कि चार्ट वर्तमान डेटा और दृश्य मानकों को सही रूप से दर्शाते रहें।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड में "My chart" नामक चार्ट को अपडेट करता है। इसमें तीन डेटा पॉइंट वाले दो कॉलम सीरीज़ की आवश्यकता होती है, जिसमें श्रेणी लेबल कॉलम A में और सीरीज़ नाम पहली पंक्ति में होते हैं। उदाहरण [GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) का उपयोग करके वर्कबुक सेल बदलता है, सीरीज़ मान अपडेट करता है, तीसरी सीरीज़ जोड़ता है, और [Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/type/) के माध्यम से चार्ट को क्लस्टर्ड सिलिंडर में बदलता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        var worksheetIndex = 0;

        var workbook = chart.ChartData.ChartDataWorkbook;

        workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
        workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

        var series = chart.ChartData.Series[0];

        workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1");
        series.DataPoints[0].Value.Data = 90;
        series.DataPoints[1].Value.Data = 123;
        series.DataPoints[2].Value.Data = 44;

        series = chart.ChartData.Series[1];

        workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2");
        series.DataPoints[0].Value.Data = 23;
        series.DataPoints[1].Value.Data = 67;
        series.DataPoints[2].Value.Data = 99;

        var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
        series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

        var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 20);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 2, 3, 50);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 3, 3, 30);
        series.DataPoints.AddDataPointForBarSeries(valueCell);

        chart.Type = ChartType.ClusteredCylinder;
    }
}

presentation.Save("AsposeChartModified.pptx", SaveFormat.Pptx);
```

## **एक चार्ट के लिए डेटा रेंज सेट करें**

किसी मौजूदा चार्ट द्वारा पहले उपयोग किए गए रेंज को देखना है, तो देखें [Retrieve a Chart's Data Range](/slides/hi/net/chart-workbook/#retrieve-a-charts-data-range)।

Aspose.Slides for .NET आपके चार्ट के डेटा के लिए कार्यपत्रक से विशिष्ट डेटा रेंज को स्रोत के रूप में परिभाषित करने की लचीलापन प्रदान करता है। इसका मतलब है कि आप सीधे अपने कार्यपत्रक के एक भाग को चार्ट से मैप कर सकते हैं, जिससे आप नियंत्रित कर सकते हैं कि कौन से सेल चार्ट की सीरीज़ और श्रेणियों में योगदान देते हैं। परिणामस्वरूप, आप अपने चार्ट को आसानी से नवीनतम डेटा परिवर्तनों के साथ अद्यतन और सिंक्रोनाइज़ कर सकते हैं, यह सुनिश्चित करते हुए कि आपके PowerPoint प्रस्तुतियों में जानकारी सही और अद्यतन रहे।

यह उदाहरण [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) का उपयोग करके मौजूदा प्रस्तुति की पहली स्लाइड में "My chart" नामक चार्ट के डेटा स्रोत को `Sheet1!A1:B4` पर सेट करता है। चार्ट कार्यपत्रक में वह कार्यपत्रक और एक भरी हुई रेंज होना आवश्यक है, जिसमें पहली पंक्ति में सीरीज़ शीर्षक, कॉलम A में श्रेणी लेबल, और कॉलम B में तीन मान हों।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        chart.ChartData.SetRange("Sheet1!A1:B4");
    }
}

presentation.Save("SetDataRange.pptx", SaveFormat.Pptx);
```

## **चार्ट में डिफ़ॉल्ट मार्कर उपयोग करें**

जब आप चार्ट में डिफ़ॉल्ट मार्कर का उपयोग करते हैं, तो प्रत्येक चार्ट सीरीज़ को स्वचालित रूप से एक अलग डिफ़ॉल्ट मार्कर प्रतीक मिलता है।

यह उदाहरण [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) का उपयोग करके दो लाइन सीरीज़ और एक लेजेंड वाला चार्ट बनाता है। [Marker](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/marker/) सेटिंग्स स्वचालित रूप से असाइन किए गए मार्कर प्रतीकों को बरकरार रखती हैं। पहली सीरीज़ में एक नकारात्मक मान और एक गुम मान (`null`) है, जबकि दूसरी में प्रत्येक श्रेणी के लिए मान है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(0, 1, 0, "C1");
chart.ChartData.Categories.Add(categoryCell);
var valueCell = workbook.GetCell(0, 1, 1, 24);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 2, 0, "C2");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 2, 1, 23);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 3, 0, "C3");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 3, 1, -10);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 4, 0, "C4");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 4, 1, null);
series.DataPoints.AddDataPointForLineSeries(valueCell);

seriesNameCell = workbook.GetCell(0, 0, 2, "Series 2");
var secondSeries = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

valueCell = workbook.GetCell(0, 1, 2, 30);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 10);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 60);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 4, 2, 40);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);

chart.HasLegend = true;
chart.Legend.Overlay = false;

presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Aspose.Slides for .NET द्वारा कौन से चार्ट प्रकार समर्थित हैं?**

Aspose.Slides for .NET बार, लाइन, पाई, एरिया, स्कैटर, हिस्टोग्राम, रेडार और कई अन्य सहित विस्तृत चार्ट प्रकारों का समर्थन करता है। यह लचीलापन आपको डेटा विज़ुअलाइज़ेशन की आवश्यकताओं के अनुसार सबसे उपयुक्त चार्ट प्रकार चुनने की अनुमति देता है।

**मैं स्लाइड में नया चार्ट कैसे जोड़ूँ?**

चार्ट जोड़ने के लिए, आप पहले [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाते हैं, इच्छित स्लाइड को उसके इंडेक्स से प्राप्त करते हैं, और फिर चार्ट जोड़ने की मेथड को कॉल करके चार्ट प्रकार और प्रारंभिक डेटा निर्दिष्ट करते हैं। यह प्रक्रिया चार्ट को सीधे आपकी प्रस्तुति में सम्मिलित करती है।

**मैं चार्ट में प्रदर्शित डेटा को कैसे अपडेट करूँ?**

आप चार्ट के डेटा को उसके डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) तक पहुँच कर, किसी भी डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करके, और फिर अपनी कस्टम डेटा जोड़कर अपडेट कर सकते हैं। यह आपको प्रोग्रामेटिक रूप से चार्ट को नवीनतम डेटा के अनुरूप ताज़ा करने की सुविधा देता है।

**क्या चार्ट की उपस्थिति को अनुकूलित करना संभव है?**

हाँ, Aspose.Slides for .NET व्यापक अनुकूलन विकल्प प्रदान करता है। आप रंग, फ़ॉन्ट, लेबल, लेजेंड और अन्य फॉर्मेटिंग तत्वों को संशोधित करके चार्ट की उपस्थिति को अपनी विशिष्ट डिज़ाइन आवश्यकताओं के अनुसार ढाल सकते हैं।