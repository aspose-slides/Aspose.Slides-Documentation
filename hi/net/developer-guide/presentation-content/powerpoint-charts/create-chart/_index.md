---
title: PowerPoint प्रस्तुति चार्ट बनाएँ या अपडेट करें .NET में
linktitle: चार्ट बनाएँ या अपडेट करें
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
- बॉक्स और व्हिस्कर चार्ट
- फ़नल चार्ट
- सनबर्स्ट चार्ट
- हिस्टोग्राम चार्ट
- रेडार चार्ट
- बहु-श्रेणी चार्ट
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट बनाएं और अनुकूलित करें। C# में व्यावहारिक कोड उदाहरणों के साथ चार्ट जोड़ें, फ़ॉर्मेट करें और संपादित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for .NET का उपयोग करके चार्ट बनाने और अनुकूलित करने के बारे में एक व्यापक गाइड प्रदान करता है। आप सीखेंगे कि प्रोग्रामेटिक रूप से स्लाइड में चार्ट कैसे जोड़ें, उसे डेटा से भरें, और विभिन्न फ़ॉर्मेटिंग विकल्प लागू करके अपने विशिष्ट डिज़ाइन आवश्यकताओं से मेल करें। लेख के दौरान विस्तृत कोड उदाहरण प्रत्येक चरण को दर्शाते हैं, प्रस्तुति और चार्ट ऑब्जेक्ट को प्रारंभ करने से लेकर सीरीज़, अक्ष और लेजेंड को कॉन्फ़िगर करने तक। इस गाइड का पालन करके, आप अपने .NET अनुप्रयोगों में डायनेमिक चार्ट जनरेशन को एकीकृत करने की ठोस समझ प्राप्त करेंगे, जिससे डेटा‑ड्रिवन प्रस्तुतियों का निर्माण सरल हो जाएगा।

## **चार्ट बनाएं**

चार्ट लोगों को डेटा को जल्दी से विज़ुअलाइज़ करने और ऐसे अंतर्दृष्टि प्राप्त करने में मदद करते हैं जो तालिका या स्प्रेडशीट से तुरंत स्पष्ट नहीं होते।

**चार्ट क्यों बनाएं?**

चार्ट का उपयोग करके आप:

* एक ही स्लाइड में बड़ी मात्रा में डेटा को संक्षिप्त, समेकित या सारांशित कर सकते हैं;
* डेटा में पैटर्न और रुझान उजागर कर सकते हैं;
* समय या विशिष्ट माप इकाई के संदर्भ में डेटा की दिशा और गति निर्धारित कर सकते हैं;
* अपवाद, विचलन, त्रुटियाँ और असंगत डेटा को पहचान सकते हैं;
* जटिल डेटा को प्रभावी ढंग से संप्रेषित या प्रस्तुत कर सकते हैं।

PowerPoint में, आप *Insert* फ़ंक्शन के माध्यम से चार्ट बना सकते हैं, जो कई प्रकार के चार्ट डिज़ाइन करने के लिए टेम्पलेट प्रदान करता है। Aspose.Slides का उपयोग करके आप सामान्य चार्ट (लोकप्रिय चार्ट प्रकारों पर आधारित) और कस्टम चार्ट दोनों बना सकते हैं।

{{% alert color="info" title="Note" %}}

[Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/) नेमस्पेस के तहत [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) एनेमरेशन का उपयोग करें। इस एनेमरेशन के मान विभिन्न चार्ट प्रकारों के अनुरूप होते हैं।

{{% /alert %}}

### **क्लस्टर्ड कॉलम चार्ट बनाएं**

यह उदाहरण [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) का उपयोग करके एक क्लस्टर्ड कॉलम चार्ट बनाता है जो तीन श्रेणियों में दो सीरीज़ की तुलना करता है। सीरीज़ में लाल और हरे फ़िल होते हैं, और व्यक्तिगत लेबल श्रेणी के नाम, सीरीज़ के नाम और मान प्रदर्शित करते हैं। वर्कशीट इंडेक्स 0 एम्बेडेड चार्ट वर्कबुक की पहली शीट को दर्शाता है।

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

स्कैटर चार्ट (जिसे स्कैटर प्लॉट या x‑y ग्राफ़ भी कहा जाता है) अक्सर दो वेरिएबल्स के बीच पैटर्न या सहसंबंध जांचने के लिए उपयोग किए जाते हैं।

स्कैटर चार्ट का उपयोग तब करें जब:

* आपके पास जोड़ी गई संख्यात्मक डेटा हो।
* दो वेरिएबल्स एक साथ अच्छी तरह फिट हों।
* आप यह निर्धारित करना चाहते हों कि दोनों वेरिएबल्स संबंधित हैं या नहीं।
* आपके पास एक स्वतंत्र वेरिएबल हो जिसके लिए आश्रित वेरिएबल के कई मान हों।

यह उदाहरण दो सेट x‑y मान प्लॉट करता है। पहली सीरीज़ में तारों के साथ सीधी रेखाएँ हैं, जबकि दूसरी में गोलाकार मार्कर के साथ स्मूद रेखाएँ; दोनों का [Size](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/size/) 10 है। मार्कर का आकार [Symbol](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/symbol/) प्रॉपर्टी द्वारा नियंत्रित होता है।

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

पाई चार्ट डेटा में भाग‑से‑सम्पूर्ण संबंध दिखाने के लिए सबसे उपयुक्त होते हैं, विशेषकर जब डेटा में श्रेणीबद्ध लेबल संख्यात्मक मानों के साथ हों। हालांकि, यदि आपके डेटा में कई भाग या लेबल हों, तो आप बार चार्ट का उपयोग करने पर विचार कर सकते हैं।

यह उदाहरण तीन तिमाही मानों के साथ एक पाई चार्ट बनाता है। प्रत्येक स्लाइस का कस्टम फ़िल और बॉर्डर होता है, और लेबल विभिन्न संयोजन (मान, प्रतिशत, सीरीज़ जानकारी) दिखाते हैं। [FirstSliceAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/firstsliceangle/) प्रॉपर्टी पहले स्लाइस को 180 डिग्री पर शुरू करती है।

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

पाई के बाहर लेबल की पठनीयता सुधारने के लिए, [Format Leader Lines](/slides/hi/net/chart-data-label/#format-leader-lines) देखें ताकि लेबल को स्थित किया जा सके और लाइन की रंग, चौड़ाई, पारदर्शिता और डैश शैली को अनुकूलित किया जा सके।

### **लाइन चार्ट बनाएं**

लाइन चार्ट (जिसे लाइन ग्राफ़ भी कहा जाता है) उन स्थितियों में सबसे उपयुक्त होते हैं जहाँ आप समय के साथ मान में परिवर्तन दिखाना चाहते हैं। लाइन चार्ट का उपयोग करके आप बड़ी मात्रा में डेटा की तुलना कर सकते हैं, समय के साथ परिवर्तन और रुझान ट्रैक कर सकते हैं, डेटा सीरीज़ में विसंगतियों को उजागर कर सकते हैं, आदि।

यह उदाहरण [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) का उपयोग करके डिफ़ॉल्ट सीरीज़ और श्रेणियों के साथ एक लाइन चार्ट बनाता है, फिर प्रस्तुतिकरण को PPTX के रूप में सहेजता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

presentation.Save("lineChart.pptx", SaveFormat.Pptx);
```

डिफ़ॉल्ट रूप से, लाइन चार्ट में बिंदु सीधे निरन्तर रेखाओं से जुड़े होते हैं। यदि आप बिंदुओं को डैश से जोड़ना चाहते हैं, तो [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) को [LineDashStyle](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) के मान से सेट करें:

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

ट्री मैप चार्ट बिक्री डेटा के लिए सबसे उपयुक्त होते हैं जब आप डेटा श्रेणियों के सापेक्ष आकार दिखाना चाहते हैं और प्रत्येक श्रेणी में बड़े योगदानकर्ता आइटम पर जल्दी से ध्यान आकर्षित करना चाहते हैं।

यह उदाहरण आठ पत्तियों को चार स्टेम और दो ब्रांच में समूहित करके एक ट्री मैप बनाता है। [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) मेथड स्टेम को समूह स्तर 1 और ब्रांच को स्तर 2 पर असाइन करता है। मान सापेक्ष आयत आकार निर्धारित करते हैं, जबकि श्रेणी लेबल और ओवरलैपिंग पेरेंट लेबल पदानुक्रम पहचानते हैं।

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

### **वॉटरफॉल चार्ट बनाएं**

वॉटरफॉल चार्ट दिखाता है कि सकारात्मक और नकारात्मक परिवर्तन अंतिम मान में कैसे योगदान देते हैं। उदाहरण के लिए, लाभ विभाजन राजस्व से शुरू हो सकता है, लागत घटा सकते हैं, और अन्य आय जोड़ सकते हैं। परिवर्तन कॉलम पिछले और नए चल रहे मान के बीच तैरते हैं, जबकि कुल कॉलम शून्य से संचित मान तक विस्तार करता है।

निम्नलिखित उदाहरण हजारों अमेरिकी डॉलर में राशियों का उपयोग करता है:

| श्रेणी | वर्कबुक मान | कॉलम प्रकार |
| --- | ---: | --- |
| राजस्व | 1000 | वृद्धि |
| बिक्री लागत | -400 | घटाव |
| सकल लाभ | 600 | मध्यवर्ती कुल |
| परिचालन खर्च | -200 | घटाव |
| अन्य आय | 50 | वृद्धि |
| शुद्ध लाभ | 450 | अंतिम कुल |

किसी बिंदु को मध्यवर्ती या अंतिम कुल के रूप में चिह्नित करने के लिए, उसके [SetAsTotal](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatapoint/setastotal/) प्रॉपर्टी को `true` सेट करें। उस बिंदु के वर्कबुक सेल में वास्तविक संचित राशि प्रदान करें: सकल लाभ के लिए `600` (`1000 - 400`) और शुद्ध लाभ के लिए `450` (`600 - 200 + 50`)। यह प्रॉपर्टी कॉलम को कुल के रूप में चिन्हित करती है; यह सेल मान की गणना या भराव नहीं करती। शून्य को प्लेसहोल्डर के रूप में उपयोग न करें या कुल बिंदु के लिए कोई अतिरिक्त परिवर्तन न दें। कुल कॉलम संचित मान को बिना दोबारा जोड़ने के दिखाता है।

यह पूर्ण C# उदाहरण [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) के `Waterfall` सदस्य का उपयोग करके चार्ट बनाता है, डिफ़ॉल्ट डेटा साफ़ करता है, और एम्बेडेड वर्कबुक को भरता है। वर्कशीट इंडेक्स `0` पहली वर्कशीट चयन करता है; कॉलम A श्रेणी नाम रखता है और कॉलम B मान रखता है। प्रत्येक मान सेल को [AddDataPointForWaterfallSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/adddatapointforwaterfallseries/) से जोड़ा जाता है। शून्य‑आधारित बिंदु इंडेक्स `2` और `5` क्रमशः मध्यवर्ती और अंतिम कुल पहचानते हैं। [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) को सक्षम करने से कॉलम पर राशि दिखती है। इनपुट प्रस्तुति या वर्कबुक की आवश्यकता नहीं है।

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

// तीसरे और छठे बिंदु कुल को दर्शाते हैं, अतिरिक्त परिवर्तन नहीं।
series.DataPoints[2].SetAsTotal = true;
series.DataPoints[5].SetAsTotal = true;
series.ShowConnectorLines = true;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("WaterfallChart.pptx", SaveFormat.Pptx);
```

सीरीज़‑लेवल [ShowConnectorLines](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/showconnectorlines/) प्रॉपर्टी को `true` सेट करके क्रमिक कॉलम को जोड़ने वाली रेखाएँ दिखाएँ और चलती हुई मान को अधिक स्पष्ट बनाएं। इन रेखियों को छिपाने के लिए, उदाहरण में असाइनमेंट को `series.ShowConnectorLines = false;` से बदलें, फिर सहेजें। यह केवल रेखा की दृश्यता को बदलता है, न कि डेटा या कुल को।

सहेजा गया प्रस्तुति राजस्व 600 और शुद्ध लाभ 450 दिखाता है, दोनों कुल शून्य से शुरू होते हैं:

![वॉटरफॉल चार्ट जिसमें राजस्व, लागत, 600 का सकल लाभ और 450 का शुद्ध लाभ दिखाया गया है, मूल्य लेबल और कनेक्टर लाइनों के साथ](waterfall_chart.png)

### **स्टॉक चार्ट बनाएं**

स्टॉक चार्ट खुले, उच्च, निम्न और बंद कीमतों जैसे वित्तीय डेटा को प्रदर्शित करने के लिए उपयोग किए जाते हैं, जिससे बाजार रुझान और अस्थिरता का विश्लेषण किया जा सके। वे स्टॉक प्रदर्शन पर महत्वपूर्ण अंतर्दृष्टि प्रदान करते हैं, जिससे निवेशकों और विश्लेषकों को सूचित निर्णय लेने में मदद मिलती है।

यह उदाहरण चार श्रृंखलाएँ (क्रमशः Open‑High‑Low‑Close) और तीन श्रेणियों के साथ एक ओपन‑हाई‑लो‑क्लोज़ चार्ट बनाता है। [HasUpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/hasupdownbars/) प्रॉपर्टी अप/डाउन बार को सक्षम करती है, और [HiLowLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hilowlinesformat/) उच्च‑निम्न रेखाओं को नियंत्रित करती है जो मूल्य रेंज दिखाती हैं, जबकि व्यक्तिगत श्रृंखला रेखाएँ और छोटे क्षैतिज ग्रिडलाइन छिपे हुए हैं।

[UpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/updownbars/) मैनेजर अलग‑अलग [UpBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/upbarsformat/) और [DownBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/downbarsformat/) ऑब्जेक्ट्स प्रदान करता है। प्रत्येक ऑब्जेक्ट की [Fill](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/fill/) और [Line](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/line/) प्रॉपर्टी का उपयोग करके उसका फ़िल और आउटलाइन स्वतंत्र रूप से सेट करें। यह उदाहरण वृद्धि अवधि के लिए गहरे‑हरे आउटलाइन वाले हरे बार और गिरावट अवधि के लिए गहरे‑लाल आउटलाइन वाले नारंगी‑लाल बार उपयोग करता है।

सभी चार श्रृंखलाओं के लिए प्रत्येक श्रेणी पर संख्यात्मक मान प्रदान करें, जहाँ High और Low, Open और Close को घेरते हैं। बार उसी श्रेणी में Close को Open के साथ तुलना करते हैं, न कि पिछली श्रेणी से: A 72 से 25 तक गिरता है, जबकि B 25 से 38 तक बढ़ता है और C 38 से 50 तक बढ़ता है। समान Open और Close मान कोई दर्शनीय फ़िल्ड अंतराल नहीं बनाते। अप/डाउन बार Open‑Close को कवर करते हैं; हाई‑लो रेखाएँ Low‑High को। ये बार श्रृंखला समूह से संबंधित हैं, सामान्य बार‑चार्ट श्रृंखला नहीं।

यह फ़ॉर्मेटिंग उन [Line और LineWithMarkers](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) चार्टों में भी काम करती है जिनमें समान समूह में कम से कम दो श्रृंखलाएँ और प्रत्येक श्रेणी के लिए संख्यात्मक मान हों। इन गैर‑स्टैक्ड लाइन चार्टों के लिए, अप/डाउन बार पहली और अंतिम श्रृंखला की तुलना करते हैं: अधिक अंतिम मान एक अप‑बार बनाता है, और कम अंतिम मान एक डाउन्‑बार बनाता है। श्रृंखलाओं को उल्टा करने से वर्गीकरण उलट जाता है। नीचे दिया गया उदाहरण [OpenHighLowClose](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) का प्रयोग करता है; यह मानना न रखें कि अन्य स्टॉक, स्टैक्ड‑लाइन या 3D वेरिएंट समान डेटा व्यवस्था या अंतराल व्याख्या का उपयोग करते हैं।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 150, false);

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

var upDownBars = chart.ChartData.SeriesGroups[0].UpDownBars;
upDownBars.HasUpDownBars = true;

upDownBars.UpBarsFormat.Fill.FillType = FillType.Solid;
upDownBars.UpBarsFormat.Fill.SolidFillColor.Color = Color.LimeGreen;
upDownBars.UpBarsFormat.Line.FillFormat.FillType = FillType.Solid;
upDownBars.UpBarsFormat.Line.FillFormat.SolidFillColor.Color = Color.DarkGreen;
upDownBars.UpBarsFormat.Line.Width = 2;

upDownBars.DownBarsFormat.Fill.FillType = FillType.Solid;
upDownBars.DownBarsFormat.Fill.SolidFillColor.Color = Color.OrangeRed;
upDownBars.DownBarsFormat.Line.FillFormat.FillType = FillType.Solid;
upDownBars.DownBarsFormat.Line.FillFormat.SolidFillColor.Color = Color.DarkRed;
upDownBars.DownBarsFormat.Line.Width = 2;

chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

foreach (var stockSeries in chart.ChartData.Series)
{
    stockSeries.Format.Line.FillFormat.FillType = FillType.NoFill;
}

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
```

परिणाम, PowerPoint से निर्यात किया गया:

![स्टॉक चार्ट जिसमें A के लिए नारंगी‑लाल गिरते अंतराल और B तथा C के लिए हरे उठते अंतराल हैं](stock_chart.png)

### **बॉक्स और व्हिस्कर चार्ट बनाएं**

बॉक्स और व्हिस्कर चार्ट डेटा वितरण को मुख्य सांख्यिकीय माप (जैसे माध्यिका, क्वार्टाइल और संभावित आउट्लायर) का सारांश लेकर प्रदर्शित करते हैं। ये अन्वेषी डेटा विश्लेषण और सांख्यिकीय अध्ययन में डेटा वैरिएशन को जल्दी समझने और किसी भी विसंगति की पहचान करने में विशेष रूप से उपयोगी होते हैं।

यह उदाहरण छह मानों से एक बॉक्स और व्हिस्कर चार्ट बनाता है। [QuartileMethod](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/quartilemethod/) प्रॉपर्टी विशेष क्वार्टाइल गणना का चयन करती है। उदाहरण में औसत रेखाएँ, औसत मार्कर, आंतरिक बिंदु और आउट्लायर बिंदु भी सक्षम किए गए हैं।

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

### **फ़नल चार्ट बनाएं**

फ़नल चार्ट उन प्रक्रियाओं को विज़ुअलाइज़ करने के लिए उपयोग किए जाते हैं जिनमें क्रमिक चरण होते हैं, जहाँ डेटा मात्रा प्रत्येक चरण के साथ घटती जाती है। ये परिवर्तन दरों का विश्लेषण, बाधाओं की पहचान और बिक्री या मार्केटिंग प्रक्रियाओं की दक्षता को ट्रैक करने में विशेष रूप से सहायक होते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड में एक फ़नल चार्ट जोड़ने के लिए [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) का उपयोग करता है। यह डिफ़ॉल्ट डेटा को छह श्रेणियों और 50 से 500 तक के मानों से बदलता है, फिर अद्यतन प्रस्तुति को सहेजता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड होना आवश्यक है।

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

![फ़नल चार्ट](funnel_chart.png)

### **सनबर्स्ट चार्ट बनाएं**

सनबर्स्ट चार्ट पदानुक्रमिक डेटा को समकेंद्रित रिंग्स के रूप में दर्शाते हैं। ये भाग‑से‑सम्पूर्ण संबंधों को स्पष्ट रूप से दिखाते हैं और नेस्टेड श्रेणियों और उप‑श्रेणियों को संक्षिप्त रूप में प्रस्तुत करने के लिए आदर्श होते हैं।

यह उदाहरण आठ पत्तियों को चार स्टेम और दो ब्रांच में समूहित करके एक सनबर्स्ट चार्ट बनाता है। [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) मेथड स्टेम को समूह स्तर 1 और ब्राच को स्तर 2 पर असाइन करता है। श्रेणी लेबल खंडों की पहचान करते हैं, और मान उनका सापेक्ष आकार निर्धारित करते हैं।

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

हिस्टोग्राम चार्ट दिखाते हैं कि संख्यात्मक मान अंतराल (बिन) में कैसे वितरित होते हैं। मासिक रिपोर्ट में ऑर्डर प्रोसेसिंग टाइम के लिए समान बिन चौड़ाई और थ्रेशहोल्ड रखें ताकि अंतराल स्थिर रहें और वितरण की तुलना आसान हो।

क्षैतिज अक्ष [AggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/aggregationtype/) को [AxisAggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axisaggregationtype/) के मोड से सेट करें। [BinWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/binwidth/) केवल `ByBinWidth` में लागू होता है; [NumberOfBins](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberofbins/) केवल `ByNumberOfBins` में। बिन चुनने के लिए `Automatic` उपयोग करें।

#### **स्थिर बिन चौड़ाई का उपयोग करें**

यह उदाहरण प्रोसेसिंग टाइम को 10‑मिनट अंतराल में समूहित करता है, जहाँ 10 मिनट या उससे कम और 40 मिनट से अधिक मानों के लिए अलग बिन होते हैं। इन बिन को [IsUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isunderflowbin/) और [IsOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isoverflowbin/) से सक्रिय करें। स्पष्ट [UnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/underflowbin/) और [OverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/overflowbin/) थ्रेशहोल्ड सेट करने पर, [IsAutomaticUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticunderflowbin/) और [IsAutomaticOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticoverflowbin/) को `false` सेट करें।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByBinWidth;
axis.BinWidth = 10;
axis.IsUnderflowBin = true;
axis.IsAutomaticUnderflowBin = false;
axis.UnderflowBin = 10;
axis.IsOverflowBin = true;
axis.IsAutomaticOverflowBin = false;
axis.OverflowBin = 40;

presentation.Save("Histogram-bin-width.pptx", SaveFormat.Pptx);
```

PowerPoint में प्रदर्शित प्रस्तुति में बिन काउंट **3, 4, 4, 4, और 2** हैं। अंडरफ़्लो बिन में `5, 10, 10` शामिल हैं, इसलिए इसका थ्रेशहोल्ड समावेशी है। ओवरफ़्लो बिन में केवल `41, 50` शामिल हैं, इसलिए इसका थ्रेशहोल्ड अपवर्जक है; दोनों `40` मान पूर्ववर्ती अंतराल में रहते हैं। भीतर के बिन अपने निचले सीमा से बड़े और ऊपर की सीमा के बराबर या छोटे मान रखते हैं।

![10‑मिनट बिन और स्पष्ट अंडरफ़्लो/ओवरफ़्लो थ्रेशहोल्ड के साथ हिस्टोग्राम](histogram_bin_width.png)

#### **बिन की संख्या निर्दिष्ट करें**

स्थिर अंतराल के बजाय स्थिर विवरण स्तर के लिए, समान डेटा पर पाँच बिन अनुरोध करें। यह उदाहरण अंडरफ़्लो और ओवरफ़्लो बिन को निष्क्रिय रखता है। चार्ट डेटा रेंज से चौड़ाई निर्धारित करता है, इसलिए सीमा रिपोर्टों के बीच बदल सकती है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByNumberOfBins;
axis.NumberOfBins = 5;

presentation.Save("Histogram-bin-count.pptx", SaveFormat.Pptx);
```

पाँच बिन में काउंट **4, 4, 4, 4, और 1** हैं। इसे पिछले स्थिर‑चौड़ाई परिणाम से तुलना करें: इनपुट मान समान हैं, लेकिन सीमाएँ भिन्न हैं।

![समान डेटा से गणना किए गए पाँच बिन के साथ हिस्टोग्राम](histogram_bin_count.png)

### **रेडार चार्ट बनाएं**

रेडार चार्ट बहु‑चर डेटा को दो‑आयामी रूप में प्रदर्शित करते हैं, जिससे कई चर की एक साथ तुलना आसान हो जाती है। ये कई प्रदर्शन मीट्रिक्स या गुणों के बीच पैटर्न, ताकत और कमजोरियों की पहचान करने में विशेष रूप से उपयोगी होते हैं।

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

### **मल्टी‑कैटегरी चार्ट बनाएं**

मल्टी‑कैटегरी चार्ट उन डेटा को दर्शाते हैं जिनमें एक से अधिक श्रेणी समूह होते हैं, जिससे आप कई आयामों में मानों की तुलना एक साथ कर सकते हैं। ये जटिल, बहु‑परत डेटा सेट के प्रवृत्तियों और संबंधों का विश्लेषण करने में विशेष रूप से सहायक होते हैं।

यह उदाहरण चार जोड़ी में व्यवस्थित आठ श्रेणियों के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है। [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) मेथड प्रत्येक जोड़ी को समूह स्तर 1 पर साझा लेबल देता है, जिससे व्यक्तिगत और समूह दोनों लेबल वाला श्रेणी अक्ष बनता है।

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

![मल्टी‑कैटегरी चार्ट](multi_category_chart.png)

#### **एक क्वार्टर लेबल हटाएँ**

[quarters.pptx](quarters.pptx) डाउनलोड करें और इसे कार्य निर्देशिका में रखें। इसका चार्ट नौ महीने और 10‑18 तक के मानों वाले एकल बिक्री श्रृंखला को दर्शाता है। श्रेणी अक्ष में तीन क्वार्टर लेबल हैं: Q1 जनवरी‑मार्च, Q2 अप्रैल‑जून, Q3 जुलाई‑सितंबर को शामिल करता है।

अप्रैल चौथी श्रेणी है और वह जहाँ Q2 स्पष्ट रूप से सेट किया गया था। अप्रैल की [GroupingLevels](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/groupinglevels/) कलेक्शन पर [DeleteGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/deletegroupingitem/) कॉल करें। स्तर अप्रैल के सापेक्ष है: स्तर 1 उसका क्वार्टर है, और स्तर 0 महीना स्वयं। यह मेथड स्तर 0 पर पत्ती श्रेणी को नहीं हटा सकता।

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (var presentation = new Presentation("quarters.pptx"))
{
    var chart = (IChart)presentation.Slides[0].Shapes[0];
    var april = chart.ChartData.Categories[3];
    april.GroupingLevels.DeleteGroupingItem(1);

    presentation.Save("quarters-updated.pptx", SaveFormat.Pptx);
}

using var reopened = new Presentation("quarters-updated.pptx");
var updatedChart = (IChart)reopened.Slides[0].Shapes[0];
var data = updatedChart.ChartData;

Console.WriteLine(string.Join(", ", data.Categories.Select(month => month.AsCell.Value)));
Console.WriteLine(string.Join(", ", data.Series[0].DataPoints.Select(point => point.Value.Data)));
```

पुनः खोला गया चार्ट मूल महीनों (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) और बिक्री मान (`10, 11, 12, 13, 14, 15, 16, 17, 18`) को वही क्रम में प्रिंट करता है। `quarters-updated.pptx` को PowerPoint में खोलें और अक्ष लेबल की तुलना करें। Q2 लेबल और अप्रैल से पहले का समूह सीमा हट गया है, इसलिए Q1 जनवरी से जून तक विस्तृत है। Q3 अभी भी जुलाई से शुरू होता है।

![लेबल हटाने से पहले और बाद की तुलना। बाएँ तरफ Q2 अप्रैल‑जून को कवर करता है, दायें तरफ Q1 जनवरी‑जून को कवर करता है।](quarter-label-comparison.png)

### **मैप चार्ट बनाएं**

मैप चार्ट भौगोलिक डेटा को देशों, राज्यों या शहरों जैसी विशिष्ट स्थानों पर मानचित्रित करके विज़ुअलाइज़ करने के लिए उपयोग होते हैं। ये क्षेत्रीय रुझानों, जनसांख्यिकीय डेटा और स्थानिक वितरण का स्पष्ट, आकर्षक दृश्य प्रदान करते हैं।

यह उदाहरण [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) का उपयोग करके डिफ़ॉल्ट भौगोलिक डेटा के साथ एक मैप चार्ट बनाता है और इसे PowerPoint में देखने के लिए सहेजता है।

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

ऊपर की तस्वीर सहेजे गए प्रस्तुति को PowerPoint में खोलकर दर्शाती है। Aspose.Slides मैप चार्ट और उसका डेटा सही ढंग से लिखता है, लेकिन स्वयं मैप चार्ट नहीं बनाता: जब कोई स्लाइड जिसमें मैप चार्ट हो, चित्र में रेंडर या PDF/SVG में परिवर्तित की जाती है, तो चार्ट क्षेत्र खाली दिखाई देता है। उसी स्लाइड के अन्य आकार प्रभावित नहीं होते।

{{% /alert %}}

### **कंबिनेशन चार्ट बनाएं**

कंबिनेशन चार्ट (या कॉम्बो चार्ट) एक ही ग्राफ़ में दो या अधिक चार्ट प्रकारों को मिलाता है। यह चार्ट आपको दो या अधिक डेटा सेट के बीच अंतर को उजागर, तुलना या जांचने में मदद करता है, जिससे आप उनके बीच संबंध पहचान सकते हैं।

![कंबिनेशन चार्ट](combination_chart.png)

यह उदाहरण चार क्लस्टर्ड कॉलम श्रृंखला को चार श्रेणियों के साथ एक लाइन श्रृंखला के साथ मिलाता है। कॉलम प्राथमिक वर्टिकल अक्ष का उपयोग करते हैं, जबकि [PlotOnSecondAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/plotonsecondaxis/) लाइन को दाएं द्वितीयक वर्टिकल अक्ष पर रखता है। हेल्पर फ़ंक्शन शीर्षक, लेजेंड, अक्ष लेबल और ग्रिडलाइन को कॉन्फ़िगर करते हैं।

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

Aspose.Slides for .NET आपको PowerPoint चार्ट को डेटा, फ़ॉर्मेट और स्टाइलिंग में परिवर्तन करके अपडेट करने की अनुमति देता है। यह कार्यक्षमता प्रस्तुतियों को डायनेमिक सामग्री के साथ अद्यतित रखने की प्रक्रिया को सरल बनाती है और सुनिश्चित करती है कि चार्ट वर्तमान डेटा और दृश्य मानकों को सटीक रूप से दर्शाते रहें।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड में "My chart" नामक चार्ट को अपडेट करता है। इसके लिए दो कॉलम श्रृंखला चाहिए जिनमें प्रत्येक में तीन डेटा बिंदु हों, श्रेणी लेबल कॉलम A में और श्रृंखला नाम पहले वर्कशीट की पहली पंक्ति में। उदाहरण [GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) का उपयोग करके वर्कबुक सेल बदलता है, श्रृंखला मान अपडेट करता है, तीसरी श्रृंखला जोड़ता है, और [Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/type/) के माध्यम से चार्ट को क्लस्टर्ड सिलेंडर में बदलता है।

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

## **चार्ट के लिए डेटा रेंज सेट करें**

किसी मौजूदा चार्ट द्वारा उपयोग किए गए रेंज को देखने के लिए, देखें [Retrieve a Chart's Data Range](/slides/hi/net/chart-workbook/#retrieve-a-charts-data-range)।

Aspose.Slides for .NET आपको वर्कशीट से विशिष्ट डेटा रेंज को अपने चार्ट के डेटा स्रोत के रूप में परिभाषित करने की लचीलापन देता है। इसका अर्थ है कि आप सीधे वर्कशीट का एक भाग चार्ट से मैप कर सकते हैं, जिससे आप नियंत्रित कर सकते हैं कि कौन‑से सेल्स चार्ट की सीरीज़ और श्रेणियों में योगदान करते हैं। परिणामस्वरूप, आप अपने चार्ट को शीट में नवीनतम डेटा परिवर्तन के साथ आसानी से अपडेट और सिंक्रनाइज़ कर सकते हैं, यह सुनिश्चित करते हुए कि आपकी PowerPoint प्रस्तुतियाँ वर्तमान और सटीक जानकारी को प्रतिबिंबित करें।

यह उदाहरण [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) का उपयोग करके पहले स्लाइड में "My chart" नामक चार्ट के डेटा स्रोत को `Sheet1!A1:B4` पर सेट करता है। चार्ट वर्कबुक में उस वर्कशीट और भरित रेंज होना चाहिए, जहाँ पहली पंक्ति में श्रृंखला शीर्षक, कॉलम A में श्रेणी लेबल और कॉलम B में तीन मान हों।

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

जब आप चार्ट में डिफ़ॉल्ट मार्कर उपयोग करते हैं, तो प्रत्येक चार्ट श्रृंखला को स्वतः एक अलग डिफ़ॉल्ट मार्कर प्रतीक सौंपा जाता है।

यह उदाहरण [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) का उपयोग करके दो लाइन श्रृंखला और एक लेजेंड वाला चार्ट बनाता है। [Marker](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/marker/) सेटिंग्स स्वचालित रूप से सौंपे गए मार्कर प्रतीकों को बनाए रखती हैं। पहली श्रृंखला में एक नकारात्मक मान और एक गायब मान (`null`) है, जबकि दूसरी में प्रत्येक श्रेणी के लिए मान है।

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

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides for .NET द्वारा कौन‑से चार्ट प्रकार समर्थित हैं?**

Aspose.Slides for .NET बार, लाइन, पाई, एरिया, स्कैटर, हिस्टोग्राम, रेडार और कई अन्य सहित विस्तृत चार्ट प्रकारों का समर्थन करता है। यह लचीलापन आपको डेटा विज़ुअलाइज़ेशन आवश्यकताओं के लिए सबसे उपयुक्त चार्ट प्रकार चुनने की सुविधा देता है।

**स्लाइड में नया चार्ट कैसे जोड़ें?**

चार्ट जोड़ने के लिए, पहले आप [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) क्लास की एक इंस्टेंस बनाते हैं, इच्छित स्लाइड को उसके इंडेक्स से प्राप्त करते हैं, और फिर चार्ट जोड़ने की मेथड को कॉल करके चार्ट प्रकार और प्रारंभिक डेटा निर्दिष्ट करते हैं। यह प्रक्रिया चार्ट को सीधे आपकी प्रस्तुति में एकीकृत करती है।

**चार्ट में प्रदर्शित डेटा को कैसे अपडेट करें?**

आप चार्ट के डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) तक पहुंच कर किसी भी डिफ़ॉल्ट श्रृंखला और श्रेणियों को साफ़ कर सकते हैं, और फिर अपनी कस्टम डेटा जोड़ सकते हैं। इससे आप प्रोग्रामेटिक रूप से चार्ट को नवीनतम डेटा के साथ रीफ़्रेश कर सकते हैं।

**क्या चार्ट की उपस्थिति को अनुकूलित करना संभव है?**

हां, Aspose.Slides for .NET व्यापक अनुकूलन विकल्प प्रदान करता है। आप रंग, फ़ॉन्ट, लेबल, लेजेंड और अन्य फ़ॉर्मेटिंग तत्वों को संशोधित करके चार्ट की उपस्थिति को अपने विशिष्ट डिज़ाइन आवश्यकताओं के अनुसार ढाल सकते हैं।

संबंधित सुविधा: [Create editable charts](/slides/hi/features/create-charts/).