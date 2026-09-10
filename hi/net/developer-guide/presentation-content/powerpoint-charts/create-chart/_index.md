---
title: .NET में PowerPoint प्रस्तुति चार्ट बनाएं या अपडेट करें
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
- बॉक्स और व्हिस्कर चार्ट
- फ़नल चार्ट
- सुनबर्स्ट चार्ट
- हिस्टोग्राम चार्ट
- रेडार चार्ट
- मल्टीकैटेगिरी चार्ट
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट बनाएं और अनुकूलित करें। C# में व्यावहारिक कोड उदाहरणों के साथ चार्ट जोड़ें, फ़ॉर्मेट करें और संपादित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for .NET का उपयोग करके चार्ट बनाना और अनुकूलित करना सीखने के लिए एक विस्तृत मार्गदर्शिका प्रदान करता है। आप प्रोग्रामेटिक रूप से स्लाइड में चार्ट जोड़ना, डेटा से भरना, और अपने विशिष्ट डिज़ाइन आवश्यकताओं के अनुसार विभिन्न फॉर्मेटिंग विकल्प लागू करना सीखेंगे। लेख में विस्तृत कोड उदाहरण प्रत्येक चरण को दर्शाते हैं, प्रस्तुति और चार्ट ऑब्जेक्ट को प्रारंभ करने से लेकर सीरीज़, एक्सिस और लेजेंड को कॉन्फ़िगर करने तक। इस मार्गदर्शिका का पालन करके आप .NET अनुप्रयोगों में डायनेमिक चार्ट जेनरेशन को एकीकृत करने की ठोस समझ प्राप्त करेंगे, जिससे डेटा‑ड्रिवेन प्रस्तुतियों का निर्माण सुगम हो जाएगा।

## **एक चार्ट बनाएं**

चार्ट लोगों को डेटा को जल्दी से दृश्य रूप में प्रस्तुत करने और ऐसी अंतर्दृष्टि प्राप्त करने में मदद करते हैं जो तालिका या स्प्रेडशीट से तुरंत स्पष्ट नहीं होती।

**चार्ट क्यों बनाएं?**

चार्ट का उपयोग करके आप:

* बड़े पैमाने पर डेटा को एक स्लाइड में संक्षिप्त कर सकते हैं;
* डेटा में पैटर्न और रुझान उजागर कर सकते हैं;
* समय के साथ या किसी विशिष्ट माप इकाई के सापेक्ष डेटा की दिशा और गति निकाल सकते हैं;
* अपवर्तन, विसंगतियां, त्रुटियां और असंगत डेटा पहचान सकते हैं;
* जटिल डेटा को प्रभावी रूप से संप्रेषित या प्रस्तुत कर सकते हैं।

PowerPoint में आप *Insert* फ़ंक्शन के माध्यम से चार्ट बना सकते हैं, जो विभिन्न प्रकार के चार्ट डिज़ाइन करने के लिए टेम्पलेट प्रदान करता है। Aspose.Slides का उपयोग करके आप नियमित चार्ट (लोकप्रिय चार्ट प्रकारों पर आधारित) और कस्टम चार्ट दोनों बना सकते हैं।

{{% alert color="info" %}} 
Use the [ChartType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/charttype/) enumeration under the [Aspose.Slides.Charts](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/) namespace. The values in this enumeration correspond to different chart types.
{{% /alert %}} 

### **क्लस्टर्ड कॉलम चार्ट बनाएं**

यह अनुभाग Aspose.Slides for .NET का उपयोग करके क्लस्टर्ड कॉलम चार्ट बनाने की प्रक्रिया बताता है। आप प्रस्तुति को प्रारंभ करना, एक चार्ट जोड़ना, और शीर्षक, डेटा, सीरीज़, श्रेणियां और स्टाइलिंग जैसे तत्वों को अनुकूलित करना सीखेंगे। नीचे दिए गए चरणों का पालन करके देखें कि एक मानक क्लस्टर्ड कॉलम चार्ट कैसे उत्पन्न होता है:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class.
1. Get a reference to a slide using its index.
1. Add a chart with some data and specify the `ChartType.ClusteredColumn` type.
1. Add a title to the chart.
1. Access the chart's data worksheet.
1. Clear all the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Apply a fill color to the chart series.
1. Add labels to the chart series.
1. Save the modified presentation as a PPTX file.

This C# code demonstrates how to create a clustered column chart:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

//    Instantiate the Presentation class.
using (Presentation presentation = new Presentation())
{
    //    Access the first slide.
    ISlide slide = presentation.Slides[0];

    //    Add a clustered column chart with its default data.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    //    Set the chart title.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    //    Set the index of the chart data sheet.
    int worksheetIndex = 0;

    //    Get the chart data workbook.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    //    Delete the default generated series and categories.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    //    Add new series.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    //    Add new categories.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    //    Get the first chart series.
    IChartSeries series = chart.ChartData.Series[0];

    //    Populate the series data.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    //    Set the fill color for the series.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    //    Get the second chart series.
    series = chart.ChartData.Series[1];

    //    Populate the series data.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    //    Set the fill color for the series.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    //    Set the first label to show the category name.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    //    Set the series to show the value for the third label.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    //    Save the presentation to disk as a PPTX file.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

The result:

![क्लस्टर्ड कॉलम चार्ट](clustered_column_chart.png)

### **स्कैटर चार्ट बनाएं**

स्कैटर चार्ट (जिसे स्कैटर प्लॉट या X‑Y ग्राफ भी कहा जाता है) का उपयोग दो चर के बीच पैटर्न या सहसंबंध जाँचने के लिए किया जाता है।

जब आप स्कैटर चार्ट का उपयोग करें:

* आपके पास जोड़ीबद्ध संख्यात्मक डेटा हो।
* दो चर परस्पर संबंध रखते हों।
* आप निर्धारित करना चाहते हों कि क्या दोनों चर संबंधित हैं।
* आपके पास एक स्वतंत्र चर हो जिसके कई मान निर्भर चर के लिए हों।

This C# code shows you how to create a scatter chart with a different series of markers:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

//    Presentation क्लास का उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    //    पहली स्लाइड तक पहुंचें।
    ISlide slide = presentation.Slides[0];

    //    डिफ़ॉल्ट स्कैटर चार्ट बनाएं।
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    //    चार्ट डेटा शीट का इंडेक्स सेट करें।
    int worksheetIndex = 0;

    //    चार्ट डेटा वर्कबुक प्राप्त करें।
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    //    डिफ़ॉल्ट सीरीज़ को हटाएं।
    chart.ChartData.Series.Clear();

    //    नई सीरीज़ जोड़ें।
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    //    पहली चार्ट सीरीज़ प्राप्त करें।
    IChartSeries series = chart.ChartData.Series[0];

    //    सीरीज़ में नया बिंदु (1:3) जोड़ें।
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    //    नया बिंदु (2:10) जोड़ें।
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    //    सीरीज़ का प्रकार बदलें।
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    //    चार्ट सीरीज़ मार्कर बदलें।
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    //    दूसरी चार्ट सीरीज़ प्राप्त करें।
    series = chart.ChartData.Series[1];

    //    चार्ट सीरीज़ में नया बिंदु (5:2) जोड़ें।
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    //    नया बिंदु (3:1) जोड़ें।
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    //    नया बिंदु (2:2) जोड़ें।
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    //    नया बिंदु (5:1) जोड़ें।
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    //    चार्ट सीरीज़ मार्कर बदलें।
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    //    प्रेजेंटेशन को डिस्क पर PPTX फ़ाइल के रूप में सहेजें।
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

The result:

![स्कैटर चार्ट](scatter_chart.png)

### **पाई चार्ट बनाएं**

पाई चार्ट डेटा में भाग‑से‑सम्पूर्ण संबंध दिखाने के लिए सबसे उपयुक्त हैं, विशेषकर जब डेटा में श्रेणीबद्ध लेबल के साथ संख्यात्मक मान हों। हालांकि, यदि आपके डेटा में बहुत सारी भाग या लेबल हों, तो आप बार चार्ट का उपयोग करने पर विचार कर सकते हैं।

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class.
1. Get a reference to a slide using its index.
1. Add a chart with default data and specify the `ChartType.Pie` type.
1. Access the chart's data workbook ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)).
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Add new points for the chart and apply custom colors to the pie chart's sectors.
1. Set labels for the series.
1. Enable leader lines for the series labels.
1. Set the rotation angle for the pie chart.
1. Save the modified presentation as a PPTX file.

This C# code shows you how to create a pie chart:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

//    Presentation क्लास का उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    //    पहली स्लाइड तक पहुंचें।
    ISlide slide = presentation.Slides[0];

    //    डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    //    चार्ट शीर्षक सेट करें।
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    //    पहली सीरीज़ को मान दिखाने के लिए सेट करें।
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    //    चार्ट डेटा शीट का इंडेक्स सेट करें।
    int worksheetIndex = 0;

    //    चार्ट डेटा वर्कबुक प्राप्त करें।
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    //    डिफ़ॉल्ट उत्पन्न सीरीज़ और श्रेणियों को हटाएं।
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    //    नई श्रेणियां जोड़ें।
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    //    नई सीरीज़ जोड़ें।
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    //    सीरीज़ डेटा भरें।
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    //    सेक्टर का रंग सेट करें।
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    //    सेक्टर की सीमा सेट करें।
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    //    सेक्टर की सीमा सेट करें।
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    //    सेक्टर की सीमा सेट करें।
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    //    नई सीरीज़ में प्रत्येक श्रेणी के लिए कस्टम लेबल बनाएं।
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    //    चार्ट के लिए सीरीज़ को लीडर लाइन्स दिखाने के लिए सेट करें।
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    //    पाई चार्ट सेक्टरों के लिए घूर्णन कोण सेट करें।
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    //    प्रेजेंटेशन को डिस्क पर PPTX फ़ाइल के रूप में सहेजें।
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

The result:

![पाई चार्ट](pie_chart.png)

### **लाइन चार्ट बनाएं**

लाइन चार्ट (जिसे लाइन ग्राफ भी कहा जाता है) उन स्थितियों में सबसे उपयुक्त होते हैं जहाँ आप समय के साथ मान में परिवर्तन दिखाना चाहते हैं। लाइन चार्ट के साथ आप कई डेटा को एक साथ तुलना कर सकते हैं, समय के साथ परिवर्तन और प्रवृत्तियों को ट्रैक कर सकते हैं, डेटा सीरीज़ में विसंगतियों को उजागर कर सकते हैं, आदि।

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class.
1. Get a reference to a slide using its index.
1. Add a chart with default data and specify the `ChartType.Line` type.
1. Access the chart's data workbook ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)).
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Save the modified presentation as a PPTX file.

This C# code shows you how to create a line chart:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

By default, points on a line chart are joined by straight continuous lines. If you want the points to be joined by dashes instead, you can specify your preferred dash type as follows:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    foreach (IChartSeries series in lineChart.ChartData.Series)
    {
        series.Format.Line.DashStyle = LineDashStyle.Dash;
    }
}
```

The result:

![लाइन चार्ट](line_chart.png)

### **ट्री मैप चार्ट बनाएं**

ट्री मैप चार्ट उन स्थितियों में सबसे उपयुक्त होते हैं जहाँ आप बिक्री डेटा के विभिन्न वर्गों के सापेक्ष आकार को दिखाना और प्रत्येक वर्ग में बड़े योगदान देने वाले आइटम पर जल्दी ध्यान आकर्षित करना चाहते हैं।

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class.
1. Get a reference to a slide using its index.
1. Add a chart with default data and specify the `ChartType.Treemap` type.
1. Access the chart's data workbook ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)).
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Save the modified presentation as a PPTX file.

This C# code shows you how to create a tree map chart:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // शाखा 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // शाखा 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D8", 3));

    series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

    presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

The result:

![ट्री मैप चार्ट](treemap_chart.png)

### **स्टॉक चार्ट बनाएं**

स्टॉक चार्ट का उपयोग ओपन, हाई, लो और क्लोज़ कीमतों जैसे वित्तीय डेटा को प्रदर्शित करने के लिए किया जाता है, जिससे बाजार रुझानों और अस्थिरता का विश्लेषण आसान हो जाता है। ये चार्ट शेयर प्रदर्शन पर महत्वपूर्ण अंतर्दृष्टि प्रदान करते हैं, जिससे निवेशकों और विश्लेषकों को सूचित निर्णय लेने में मदद मिलती है।

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class.
1. Get a reference to a slide using its index.
1. Add a chart with default data and specify the `ChartType.OpenHighLowClose` type.
1. Access the chart's data workbook ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)).
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Specify the HiLowLines format.
1. Save the modified presentation as a PPTX file.

This C# code shows you how to create a stock chart:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "A"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "B"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C"));

    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Open"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "High"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 3, "Low"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 4, "Close"), chart.Type);

    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 72));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 38));

    series = chart.ChartData.Series[1];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 172));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 57));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 57));

    series = chart.ChartData.Series[2];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 13));

    series = chart.ChartData.Series[3];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 4, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 4, 38));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 4, 50));

    chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
    chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

    foreach (IChartSeries ser in chart.ChartData.Series)
    {
        ser.Format.Line.FillFormat.FillType = FillType.NoFill;
    }

    chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```

The result:

![स्टॉक चार्ट](stock_chart.png)

### **बॉक्स एंड व्हिस्कर चार्ट बनाएं**

बॉक्स एंड व्हिस्कर चार्ट डेटा वितरण को प्रमुख सांख्यिकीय मापदंडों—जैसे माध्यिका, क्वारटाइल और संभावित अपवर्तन—का सारांश प्रस्तुत करके दिखाते हैं। ये विशेष रूप से एक्सप्लोरेटरी डेटा एनालिसिस और सांख्यिकीय अध्ययनों में उपयोगी होते हैं, जिससे डेटा में विविधता और विसंगतियों को जल्दी समझा जा सकता है।

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class.
1. Get a reference to a slide using its index.
1. Add a chart with default data and specify the `ChartType.BoxAndWhisker` type.
1. Access the chart's data workbook ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)).
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Save the modified presentation as a PPTX file.

This C# code shows you how to create a box and whisker chart:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

    series.QuartileMethod = QuartileMethodType.Exclusive;
    series.ShowMeanLine = true;
    series.ShowMeanMarkers = true;
    series.ShowInnerPoints = true;
    series.ShowOutlierPoints = true;

    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 15));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 41));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 16));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 10));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 23));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 16));

    presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
```

### **फ़नल चार्ट बनाएं**

फ़नल चार्ट उन प्रक्रियाओं को दृश्य रूप में प्रस्तुत करने के लिए उपयोग किए जाते हैं जिनमें क्रमिक चरण होते हैं, जहाँ डेटा की मात्रा प्रत्येक चरण के साथ घटती जाती है। ये रूपांतरण दर का विश्लेषण, बाधाओं की पहचान और बिक्री या मार्केटिंग प्रक्रियाओं की दक्षता को ट्रैक करने में विशेष रूप से सहायक होते हैं।

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class.
1. Get a reference to a slide using its index.
1. Add a chart with default data and specify the `ChartType.Funnel` type.
1. Save the modified presentation as a PPTX file.

This C# code shows you how to create a funnel chart:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("test.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 50));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 200));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 300));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 400));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 500));

    presentation.Save("Funnel.pptx", SaveFormat.Pptx);
}
```

The result:

![फ़नल चार्ट](funnel_chart.png)

### **सुनबर्स्ट चार्ट बनाएं**

सुनबर्स्ट चार्ट पदानुक्रमित डेटा को दृश्य रूप में प्रस्तुत करने के लिए उपयोग किए जाते हैं, जहाँ स्तरों को समानांतर रिंग के रूप में दर्शाया जाता है। ये भाग‑से‑सम्पूर्ण संबंधों को स्पष्ट और संक्षिप्त रूप में दिखाते हैं, जिससे नेस्टेड श्रेणियों को समझना आसान हो जाता है।

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class.
1. Get a reference to a slide using its index.
1. Add a chart with default data and specify the `ChartType.Sunburst` type.
1. Save the modified presentation as a PPTX file.

This C# code shows you how to create a sunburst chart:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // शाखा 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // शाखा 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D8", 3));

    presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
}
```

The result:

![सुनबर्स्ट चार्ट](sunburst_chart.png)

### **हिस्टोग्राम चार्ट बनाएं**

हिस्टोग्राम चार्ट संख्यात्मक डेटा के वितरण को रेंज या बिन में समूहित करके प्रदर्शित करते हैं। ये डेटा पैटर्न जैसे आवृत्ति, विकृति और प्रसार की पहचान करने तथा डेटा सेट में अपवर्तनों का पता लगाने में विशेष रूप से उपयोगी होते हैं।

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class.
1. Get a reference to a slide using its index.
1. Add a chart with some data and specify the `ChartType.Histogram` type.
1. Access the chart data workbook ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)).
1. Clear the default series and categories.
1. Add new series and categories.
1. Save the modified presentation as a PPTX file.

This C# code shows you how to create a histogram chart:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A1", 15));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A2", -41));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A3", 16));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A4", 10));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A5", -23));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A6", 16));

    chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

    presentation.Save("Histogram.pptx", SaveFormat.Pptx);
}
```

The result:

![हिस्टोग्राम चार्ट](histogram_chart.png)

### **रेडार चार्ट बनाएं**

रेडार चार्ट दो‑आयामी प्रारूप में बहुवैधीय डेटा को प्रदर्शित करते हैं, जिससे कई वेरिएबल्स की एक साथ आसान तुलना संभव होती है। ये कई प्रदर्शन मीट्रिक्स या गुणों में पैटर्न, ताकत और कमजोरियों की पहचान करने में विशेष रूप से उपयोगी होते हैं।

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class.
1. Get a reference to a slide using its index.
1. Add a chart with some data and specify the `ChartType.Radar` type.
1. Save the modified presentation as a PPTX file.

This C# code shows you how to create a radar chart:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

The result:

![रेडार चार्ट](radar_chart.png)

### **मल्टी‑कैटेगिरी चार्ट बनाएं**

मल्टी‑कैटेगिरी चार्ट उन डेटा को प्रदर्शित करने के लिए उपयोग किए जाते हैं जिनमें एक से अधिक श्रेणीबद्ध समूह होते हैं, जिससे आप कई आयामों में मानों की तुलना एक साथ कर सकते हैं। ये जटिल, बहु‑स्तरीय डेटा सेट में रुझानों और संबंधों का विश्लेषण करने में विशेष रूप से सहायक होते हैं।

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class.
1. Get a reference to a slide using its index.
1. Add a chart with default data and specify the `ChartType.ClusteredColumn` type.
1. Access the chart's data workbook ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)).
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Save the modified presentation as a PPTX file.

This C# code shows you how to create a multicategory chart:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    int worksheetIndex = 0;

    IChartCategory category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c2", "A"));
    category.GroupingLevels.SetGroupingItem(1, "Group1");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c3", "B"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c4", "C"));
    category.GroupingLevels.SetGroupingItem(1, "Group2");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c5", "D"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c6", "E"));
    category.GroupingLevels.SetGroupingItem(1, "Group3");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c7", "F"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c8", "G"));
    category.GroupingLevels.SetGroupingItem(1, "Group4");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c9", "H"));

    // एक सीरीज़ जोड़ें।
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // चार्ट के साथ प्रस्तुति को सहेजें।
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

The result:

![मल्टि‑कैटेगिरी चार्ट](multi_category_chart.png)

### **मैप चार्ट बनाएं**

मैप चार्ट भौगोलिक डेटा को देशों, राज्यों या शहरों जैसी विशिष्ट स्थानों पर मानचित्रित करके दृश्य रूप में प्रस्तुत करते हैं। ये क्षेत्रीय रुझानों, जनसांख्यिकीय डेटा और स्थानिक वितरण का विश्लेषण स्पष्ट और आकर्षक तरीके से करने में विशेष रूप से उपयोगी होते हैं।

This C# code shows you how to create a map chart:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

The result:

![मैप चार्ट](map_chart.png)

{{% alert color="info" %}} 
The picture above shows the saved presentation opened in PowerPoint. Aspose.Slides writes the map chart and its data correctly, but it does not draw map charts itself: when a slide holding one is rendered to an image or converted to PDF or SVG, the chart area comes out blank. Other shapes on the same slide are unaffected.
{{% /alert %}} 

### **कंबिनेशन चार्ट बनाएं**

कंबिनेशन चार्ट (या कॉम्बो चार्ट) एक ही ग्राफ में दो या अधिक चार्ट प्रकारों को मिलाता है। यह चार्ट आपको दो या अधिक डेटा सेट्स के बीच अंतर को उजागर, तुलना या जांचने की अनुमति देता है, जिससे उनके बीच के संबंधों की पहचान आसान हो जाती है।

![कंबिनेशन चार्ट](combination_chart.png)

The following C# code shows how to create the combination chart shown above in a PowerPoint presentation:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

private static void CreateComboChart()
{
    using (Presentation presentation = new Presentation())
    {
        IChart chart = CreateChartWithFirstSeries(presentation.Slides[0]);

        AddSecondSeriesToChart(chart);
        AddThirdSeriesToChart(chart);

        SetPrimaryAxesFormat(chart);
        SetSecondaryAxesFormat(chart);

        presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChartWithFirstSeries(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // चार्ट शीर्षक सेट करता है
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // चार्ट लीजेंड सेट करता है
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // डिफ़ॉल्ट उत्पन्न सीरीज़ और श्रेणियों को हटाता है
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // नई श्रेणियां जोड़ता है
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // पहली सीरीज़ जोड़ें
    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 4.3));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 3.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 2.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 4.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 1.8));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 2, 2.8));
}

private static void AddThirdSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), ChartType.Line);

    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 1, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 2, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 3, 3, 3.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 4, 3, 5.0));

    series.PlotOnSecondAxis = true;
}

private static void SetPrimaryAxesFormat(IChart chart)
{
    // क्षैतिज अक्ष सेट करता है
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // लंबवत अक्ष सेट करता है
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // लंबवत प्रमुख ग्रिडलाइन रंग सेट करता है
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // द्वितीयक क्षैतिज अक्ष सेट करता है
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // द्वितीयक लंबवत अक्ष सेट करता है
    IAxis secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

private static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    IPortionFormat titlePortionFormat =
        axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **चार्ट अपडेट करें**

Aspose.Slides for .NET आपको PowerPoint चार्ट को डेटा, फॉर्मेटिंग और स्टाइलिंग को संशोधित करके अपडेट करने की सुविधा देता है। यह सुविधा डायनेमिक सामग्री के साथ प्रस्तुतियों को अद्यतन रखने की प्रक्रिया को सरल बनाती है और सुनिश्चित करती है कि चार्ट वर्तमान डेटा और दृश्य मानकों को सटीक रूप से दर्शाते रहें।

1. Instantiate the [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class that represents the presentation containing a chart.
1. Get a reference to a slide using its index.
1. Traverse through all shapes to find the chart.
1. Access the chart's data worksheet.
1. Modify the chart data series by changing the series values.
1. Add a new series and populate its data.
1. Save the modified presentation as a PPTX file.

This C# code shows you how to update a chart:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// एक PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // पहली स्लाइड तक पहुंचें।
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // चार्ट डेटा शीट का इंडेक्स सेट करें।
            int worksheetIndex = 0;

            // चार्ट डेटा वर्कबुक प्राप्त करें।
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // चार्ट कैटेगरी के नाम बदलें।
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // पहली चार्ट सीरीज़ प्राप्त करें।
            IChartSeries series = chart.ChartData.Series[0];

            // सीरीज़ डेटा अपडेट करें।
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // सीरीज़ का नाम संशोधित किया जा रहा है।
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // दूसरी चार्ट सीरीज़ प्राप्त करें।
            series = chart.ChartData.Series[1];

            // सीरीज़ डेटा अपडेट करें।
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // सीरीज़ का नाम संशोधित किया जा रहा है।
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // एक नई सीरीज़ जोड़ें।
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // सीरीज़ डेटा भरें।
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // चार्ट के साथ प्रस्तुति सहेजें।
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **चार्ट के लिए डेटा रेंज सेट करें**

Aspose.Slides for .NET आपको एक वर्कशीट से विशिष्ट डेटा रेंज को अपने चार्ट के डेटा स्रोत के रूप में परिभाषित करने की लचीलापन देता है। इसका अर्थ है कि आप वर्कशीट के केवल एक भाग को सीधे चार्ट से मैप कर सकते हैं, जिससे आप नियंत्रित कर सकते हैं कि कौन-सी कोशिकाएं चार्ट की सीरीज़ और श्रेणियों में योगदान देती हैं। परिणामस्वरूप, आप अपने चार्ट को वर्कशीट में नवीनतम डेटा परिवर्तनों के साथ आसानी से अपडेट और सिंक्रनाइज़ कर सकते हैं, जिससे आपके PowerPoint प्रस्तुतियों में सटीक और वर्तमान जानकारी बनी रहती है।

1. Instantiate the [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class that represents the presentation containing a chart.
1. Get a reference to a slide using its index.
1. Traverse through all shapes to find the chart.
1. Access the chart data and set the range.
1. Save the modified presentation as a PPTX file.

This C# code shows you how to set the data range for a chart:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // पहली स्लाइड तक पहुंचें।
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            chart.ChartData.SetRange("Sheet1!A1:B4");
        }
    }

    presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
}
```

## **चार्ट में डिफ़ॉल्ट मार्कर उपयोग करें**

जब आप चार्ट में डिफ़ॉल्ट मार्कर उपयोग करते हैं, तो प्रत्येक चार्ट सीरीज़ को स्वचालित रूप से एक अलग डिफ़ॉल्ट मार्कर सिम्बॉल मिलता है।

This C# code shows you how to set a chart series marker automatically:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 24));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 23));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, -10));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, null));

    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

    // सीरीज़ डेटा भरें।
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides for .NET कौन‑से चार्ट प्रकारों का समर्थन करता है?**

Aspose.Slides for .NET कई प्रकार के चार्ट समर्थन करता है, जिसमें बार, लाइन, पाई, एरिया, स्कैटर, हिस्टोग्राम, रेडार और कई अन्य शामिल हैं। यह लचीलापन आपको अपने डेटा विज़ुअलाइज़ेशन की आवश्यकताओं के लिए सबसे उपयुक्त चार्ट प्रकार चुनने की अनुमति देता है।

**मैं स्लाइड में नया चार्ट कैसे जोड़ सकता हूँ?**

चार्ट जोड़ने के लिए, पहले आप [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की एक इंस्टेंस बनाते हैं, इच्छित स्लाइड को उसके इंडेक्स से प्राप्त करते हैं, और फिर चार्ट जोड़ने के मेथड को कॉल करके चार्ट प्रकार और प्रारंभिक डेटा निर्दिष्ट करते हैं। यह प्रक्रिया चार्ट को सीधे आपकी प्रस्तुति में समाहित करती है।

**मैं चार्ट में प्रदर्शित डेटा कैसे अपडेट कर सकता हूँ?**

आप चार्ट के डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)) तक पहुंचकर, डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करके, और फिर अपना कस्टम डेटा जोड़कर चार्ट के डेटा को अपडेट कर सकते हैं। इससे आप प्रोग्रामेटिक रूप से चार्ट को नवीनतम डेटा के साथ पुनः रिफ़्रेश कर सकते हैं।

**क्या चार्ट की उपस्थिति को कस्टमाइज़ करना संभव है?**

हाँ, Aspose.Slides for .NET व्यापक कस्टमाइज़ेशन विकल्प प्रदान करता है। आप रंग, फ़ॉन्ट, लेबल, लेजेंड और अन्य फॉर्मेटिंग तत्वों को संशोधित करके चार्ट की उपस्थिति को अपनी विशिष्ट डिज़ाइन आवश्यकताओं के अनुसार अनुकूलित कर सकते हैं।