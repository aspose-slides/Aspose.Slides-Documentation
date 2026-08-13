---
title: PowerPoint प्रस्तुति चार्ट को .NET में बनाएं या अपडेट करें
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
- बॉक्स एंड व्हिस्कर चार्ट
- फ़नल चार्ट
- सनबर्स्ट चार्ट
- हिस्टोग्राम चार्ट
- रेडार कार्ड
- मल्टीकैटेगरी चार्ट
- PowerPoint
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट बनाएं और अनुकूलित करें। C# में व्यावहारिक कोड उदाहरणों के साथ चार्ट जोड़ें, फ़ॉर्मेट करें और संपादित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for .NET का उपयोग करके चार्ट बनाने और अनुकूलित करने के लिए एक व्यापक मार्गदर्शिका प्रदान करता है। आप सीखेंगे कि कैसे प्रोग्रामेटिक रूप से एक स्लाइड में चार्ट जोड़ा जाए, उसे डेटा से भरें, और आपके विशेष डिज़ाइन आवश्यकताओं के अनुरूप विभिन्न फ़ॉर्मेटिंग विकल्प लागू करें। लेख में विस्तृत कोड उदाहरण प्रत्येक चरण को दर्शाते हैं, प्रस्तुतिकरण और चार्ट ऑब्जेक्ट को प्रारंभ करने से लेकर सीरीज, अक्ष और लेजेंड को कॉन्फ़िगर करने तक। इस मार्गदर्शिका का पालन करके आप गतिशील चार्ट निर्माण को अपने .NET एप्लिकेशन में एकीकृत करने की ठोस समझ प्राप्त करेंगे, जिससे डेटा‑चालित प्रस्तुतियों का निर्माण सहज हो जाएगा।

## **चार्ट बनाना**

चार्ट मदद करता है लोगों को डेटा को जल्दी से दृश्यीकृत करने और ऐसे अंतर्दृष्टि प्राप्त करने में जो तालिका या स्प्रेडशीट से तुरंत स्पष्ट नहीं होते।

**चार्ट क्यों बनाएं?**

चार्ट का उपयोग करके आप:
* एक ही स्लाइड में बड़ी मात्रा में डेटा को सारांशित, संक्षिप्त या संकलित कर सकते हैं;
* डेटा में पैटर्न और रुझान उजागर कर सकते हैं;
* समय के साथ या किसी विशिष्ट माप इकाई के संदर्भ में डेटा की दिशा और गति का अनुमान लगा सकते हैं;
* अपवाद, विचलन, त्रुटियों और असंगत डेटा की पहचान कर सकते हैं;
* जटिल डेटा को प्रभावी रूप से संप्रेषित या प्रस्तुत कर सकते हैं।

PowerPoint में आप *Insert* फ़ंक्शन के माध्यम से कई प्रकार के चार्ट टेम्पलेट उपलब्ध कराते हुए चार्ट बना सकते हैं। Aspose.Slides का उपयोग करके आप सामान्य चार्ट (लोकप्रिय चार्ट प्रकारों पर आधारित) तथा कस्टम चार्ट दोनों बना सकते हैं।

{{% alert color="info" %}} 
[ChartType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/charttype/) enumeration का उपयोग [Aspose.Slides.Charts](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/) नेमस्पेस में करें। इस enumeration के मान विभिन्न चार्ट प्रकारों के अनुरूप होते हैं।
{{% /alert %}} 

### **क्लस्टर्ड कॉलम चार्ट बनाना**

यह भाग Aspose.Slides for .NET का उपयोग करके क्लस्टर्ड कॉलम चार्ट बनाने की विधि समझाता है। आप प्रस्तुति को प्रारंभ करना, चार्ट जोड़ना, और शीर्षक, डेटा, सीरीज़, श्रेणियां और शैली जैसी तत्वों को अनुकूलित करना सीखेंगे। नीचे दिए गए चरणों का अनुसरण करें ताकि देखें कि एक मानक क्लस्टर्ड कॉलम चार्ट कैसे उत्पन्न होता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का उदाहरण बनाएं।  
1. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।  
1. कुछ डेटा के साथ चार्ट जोड़ें और `ChartType.ClusteredColumn` प्रकार निर्दिष्ट करें।  
1. चार्ट में एक शीर्षक जोड़ें।  
1. चार्ट के डेटा वर्कशीट तक पहुँचें।  
1. सभी डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।  
1. नई सीरीज़ और श्रेणियां जोड़ें।  
1. चार्ट सीरीज़ के लिए नया चार्ट डेटा जोड़ें।  
1. चार्ट सीरीज़ पर एक भराव रंग लागू करें।  
1. चार्ट सीरीज़ में लेबल जोड़ें।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड क्लस्टर्ड कॉलम चार्ट बनाता है:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Instantiate the Presentation class.
using (Presentation presentation = new Presentation())
{
    // Access the first slide.
    ISlide slide = presentation.Slides[0];

    // Add a clustered column chart with its default data.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // Set the chart title.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Set the index of the chart data sheet.
    int worksheetIndex = 0;

    // Get the chart data workbook.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Delete the default generated series and categories.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Add new series.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // Add new categories.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // Get the first chart series.
    IChartSeries series = chart.ChartData.Series[0];

    // Populate the series data.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Set the fill color for the series.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // Get the second chart series.
    series = chart.ChartData.Series[1];

    // Populate the series data.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // Set the fill color for the series.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // Set the first label to show the category name.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // Set the series to show the value for the third label.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // Save the presentation to disk as a PPTX file.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![क्लस्टर्ड कॉलम चार्ट](clustered_column_chart.png)

### **स्कैटर चार्ट बनाना**

स्कैटर चार्ट (जिन्हें स्कैटर प्लॉट या X‑Y ग्राफ़ भी कहा जाता है) अक्सर दो चर के बीच पैटर्न या सहसंबंध जाँचने के लिये उपयोग किए जाते हैं।

स्कैटर चार्ट का उपयोग तब करें जब:
* आपके पास युग्मित संख्यात्मक डेटा हो।  
* दो चर एक साथ अच्छी तरह से जुड़े हों।  
* आप निर्धारित करना चाहते हों कि दो चर संबंधित हैं या नहीं।  
* आपके पास एक स्वतंत्र चर हो जिसके कई मान निर्भरशील चर के लिए हों।

यह C# कोड विभिन्न मार्कर सीरीज़ के साथ एक स्कैटर चार्ट बनाता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Presentation क्लास का इंस्टेंस बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड तक पहुँचें।
    ISlide slide = presentation.Slides[0];

    // डिफ़ॉल्ट स्कैटर चार्ट बनाएं।
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // चार्ट डेटा शीट का इंडेक्स सेट करें।
    int worksheetIndex = 0;

    // चार्ट डेटा वर्कबुक प्राप्त करें।
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // डिफ़ॉल्ट सीरीज़ हटाएं।
    chart.ChartData.Series.Clear();

    // नई सीरीज़ जोड़ें।
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // पहला चार्ट सीरीज़ प्राप्त करें।
    IChartSeries series = chart.ChartData.Series[0];

    // सीरीज़ में नया बिंदु (1:3) जोड़ें।
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // नया बिंदु (2:10) जोड़ें।
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // सीरीज़ प्रकार बदलें।
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // चार्ट सीरीज़ मार्कर बदलें।
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // दूसरा चार्ट सीरीज़ प्राप्त करें।
    series = chart.ChartData.Series[1];

    // चार्ट सीरीज़ में नया बिंदु (5:2) जोड़ें।
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // नया बिंदु (3:1) जोड़ें।
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // नया बिंदु (2:2) जोड़ें।
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // नया बिंदु (5:1) जोड़ें।
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // चार्ट सीरीज़ मार्कर बदलें।
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // प्रेजेंटेशन को डिस्क पर PPTX फ़ाइल के रूप में सहेजें।
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![स्कैटर चार्ट](scatter_chart.png)

### **पाई चार्ट बनाना**

पाई चार्ट डेटा में भाग‑से‑सम्पूर्ण संबंध दिखाने के लिये उपयुक्त होते हैं, विशेषकर जब डेटा में श्रेणीबद्ध लेबल के साथ संख्यात्मक मान हों। यदि आपके डेटा में बहुत अधिक भाग या लेबल हों तो बार चार्ट का उपयोग करने पर विचार करें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का उदाहरण बनाएं।  
1. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।  
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और `ChartType.Pie` प्रकार निर्दिष्ट करें।  
1. चार्ट के डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)) तक पहुँचें।  
1. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।  
1. नई सीरीज़ और श्रेणियां जोड़ें।  
1. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।  
1. पाई चार्ट के सेक्टरों के लिये कस्टम रंग लागू करें।  
1. सीरीज़ के लेबल सेट करें।  
1. लेबल के लिये लीडर लाइन सक्षम करें।  
1. पाई चार्ट का घूर्णन कोण सेट करें।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड पाई चार्ट बनाता है:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Presentation क्लास का इंस्टेंस बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड तक पहुँचें।
    ISlide slide = presentation.Slides[0];

    // डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // चार्ट शीर्षक सेट करें।
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // पहली सीरीज़ को मान दिखाने के लिए सेट करें।
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // चार्ट डेटा शीट का इंडेक्स सेट करें।
    int worksheetIndex = 0;

    // चार्ट डेटा वर्कबुक प्राप्त करें।
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // डिफ़ॉल्ट जेनरेटेड सीरीज़ और श्रेणियों को हटाएं।
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // नई श्रेणियां जोड़ें।
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // नई सीरीज़ जोड़ें।
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // सीरीज़ डेटा भरें।
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // सेक्टर का रंग सेट करें।
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // सेक्टर की बॉर्डर सेट करें।
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // सेक्टर की बॉर्डर सेट करें।
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // सेक्टर की बॉर्डर सेट करें।
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // नई सीरीज़ में प्रत्येक श्रेणी के लिए कस्टम लेबल बनाएं।
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // चार्ट के लिये सीरीज़ को लीडर लाइन्स दिखाने के लिए सेट करें।
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // पाई चार्ट सेक्टरों के लिए घूर्णन कोण सेट करें।
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // प्रेजेंटेशन को डिस्क पर PPTX फ़ाइल के रूप में सहेजें।
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![पाई चार्ट](pie_chart.png)

### **लाइन चार्ट बनाना**

लाइन चार्ट (जिन्हें लाइन ग्राफ़ भी कहा जाता है) उन स्थितियों में उपयोगी होते हैं जहाँ आप समय के साथ मानों में परिवर्तन दिखाना चाहते हैं। लाइन चार्ट के माध्यम से आप बड़ी मात्रा में डेटा की तुलना, समय‑क्रम में प्रवृत्तियों का ट्रैक, और डेटा सीरीज़ में विसंगतियों को उजागर कर सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का उदाहरण बनाएं।  
1. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।  
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और `ChartType.Line` प्रकार निर्दिष्ट करें।  
1. चार्ट के डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)) तक पहुँचें।  
1. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।  
1. नई सीरीज़ और श्रेणियां जोड़ें।  
1. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड लाइन चार्ट बनाता है:

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

डिफ़ॉल्ट रूप से, लाइन चार्ट के बिंदु सीधे निरंतर रेखाओं से जुड़े होते हैं। यदि आप बिंदुओं को डैश द्वारा जोड़ना चाहते हैं, तो नीचे दिखाए अनुसार डैश प्रकार निर्दिष्ट करें:

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

परिणाम:

![लाइन चार्ट](line_chart.png)

### **ट्री मैप चार्ट बनाना**

ट्री मैप चार्ट उन बिक्री डेटा के लिये उपयुक्त होते हैं जहाँ आप श्रेणी‑स्तर के सापेक्ष आकार दिखाना चाहते हैं और प्रत्येक श्रेणी में बड़े योगदानकर्ता आइटम्स पर जल्दी ध्यान आकर्षित करना चाहते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का उदाहरण बनाएं।  
1. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।  
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और `ChartType.Treemap` प्रकार निर्दिष्ट करें।  
1. चार्ट के डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)) तक पहुँचें।  
1. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।  
1. नई सीरीज़ और श्रेणियां जोड़ें।  
1. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड ट्री मैप चार्ट बनाता है:

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

परिणाम:

![ट्री मैप चार्ट](treemap_chart.png)

### **स्टॉक चार्ट बनाना**

स्टॉक चार्ट वित्तीय डेटा जैसे ओपन, हाई, लो, और क्लोज़ मूल्यों को प्रदर्शित करने के लिये उपयोग किए जाते हैं, जिससे बाजार रुझान और अस्थिरता का विश्लेषण आसान हो जाता है। ये चार्ट स्टॉक प्रदर्शन पर महत्वपूर्ण अंतर्दृष्टि प्रदान करते हैं, जिससे निवेशकों और विश्लेषकों को सूचित निर्णय लेने में सहायता मिलती है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का उदाहरण बनाएं।  
1. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।  
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और `ChartType.OpenHighLowClose` प्रकार निर्दिष्ट करें।  
1. चार्ट के डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)) तक पहुँचें।  
1. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।  
1. नई सीरीज़ और श्रेणियां जोड़ें।  
1. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।  
1. HiLowLines फ़ॉर्मेट निर्धारित करें।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड स्टॉक चार्ट बनाता है:

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

परिणाम:

![स्टॉक चार्ट](stock_chart.png)

### **बॉक्स एंड व्हिस्कर चार्ट बनाना**

बॉक्स एंड व्हिस्कर चार्ट डेटा वितरण को प्रमुख सांख्यिकीय माप जैसे मध्यक, क्वार्टाइल, और संभावित अपवादों को संक्षेपित करके प्रदर्शित करते हैं। ये अन्वेषणात्मक डेटा विश्लेषण और सांख्यिकीय अध्ययनों में डेटा परिवर्तनशीलता को शीघ्र समझने और विसंगतियों की पहचान करने में सहायक होते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का उदाहरण बनाएं।  
1. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।  
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और `ChartType.BoxAndWhisker` प्रकार निर्दिष्ट करें।  
1. चार्ट के डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)) तक पहुँचें।  
1. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।  
1. नई सीरीज़ और श्रेणियां जोड़ें।  
1. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड बॉक्स एंड व्हिस्कर चार्ट बनाता है:

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

### **फ़नल चार्ट बनाना**

फ़नल चार्ट क्रमिक चरणों वाले प्रक्रियाओं को दृश्यात्मक बनाते हैं, जहाँ डेटा की मात्रा अगले चरण में जाने पर घटती है। ये परिवर्तन दरों का विश्लेषण, बाधाओं की पहचान, और बिक्री या मार्केटिंग प्रक्रियाओं की दक्षता ट्रैक करने में विशेष रूप से उपयोगी होते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का उदाहरण बनाएं।  
1. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।  
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और `ChartType.Funnel` प्रकार निर्दिष्ट करें।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड फ़नल चार्ट बनाता है:

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

परिणाम:

![फ़नल चार्ट](funnel_chart.png)

### **सनबर्स्ट चार्ट बनाना**

सनबर्स्ट चार्ट पदानुक्रमित डेटा को समकेंद्रित वृत्तों के रूप में दर्शाते हैं। ये भाग‑से‑सम्पूर्ण संबंध को स्पष्ट एवं संक्षिप्त रूप में दिखाते हैं और नेस्टेड श्रेणियों को प्रस्तुत करने के लिए आदर्श होते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का उदाहरण बनाएं।  
1. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।  
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और `ChartType.Sunburst` प्रकार निर्दिष्ट करें।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड सनबर्स्ट चार्ट बनाता है:

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

परिणाम:

![सनबर्स्ट चार्ट](sunburst_chart.png)

### **हिस्टोग्राम चार्ट बनाना**

हिस्टोग्राम चार्ट संख्यात्मक डेटा के वितरण को रेंज या बिन में समूहित करके दर्शाते हैं। ये आवृत्ति, स्क्यूनेस, प्रसार जैसी पैटर्न की पहचान और डेटासेट में अपवादों का पता लगाने में विशेष रूप से सहायक होते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का उदाहरण बनाएं।  
1. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।  
1. कुछ डेटा के साथ एक चार्ट जोड़ें और `ChartType.Histogram` प्रकार निर्दिष्ट करें।  
1. चार्ट डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)) तक पहुँचें।  
1. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।  
1. नई सीरीज़ और श्रेणियां जोड़ें।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड हिस्टोग्राम चार्ट बनाता है:

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

परिणाम:

![हिस्टोग्राम चार्ट](histogram_chart.png)

### **रेडार चार्ट बनाना**

रेडार चार्ट बहुवैध डेटा को दो‑आयामी प्रारूप में प्रदर्शित करते हैं, जिससे कई चर को एक साथ आसानी से तुलना किया जा सकता है। ये कई प्रदर्शन मीट्रिक या गुणों में पैटर्न, ताकत और कमजोरियों की पहचान के लिये विशेष रूप से उपयोगी होते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का उदाहरण बनाएं।  
1. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।  
1. कुछ डेटा के साथ एक चार्ट जोड़ें और `ChartType.Radar` प्रकार निर्दिष्ट करें।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड रेडार चार्ट बनाता है:

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

परिणाम:

![रेडार चार्ट](radar_chart.png)

### **मल्टी‑कैटेगरी चार्ट बनाना**

मल्टी‑कैटेगरी चार्ट उन डेटा को प्रदर्शित करते हैं जिनमें एक से अधिक श्रेणी समूह शामिल होते हैं, जिससे आप कई आयामों में मानों की एक साथ तुलना कर सकते हैं। ये जटिल, बहु‑स्तरीय डेटासेट में रुझान और संबंध विश्लेषण के लिये विशेष रूप से सहायक होते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का उदाहरण बनाएं।  
1. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।  
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और `ChartType.ClusteredColumn` प्रकार निर्दिष्ट करें।  
1. चार्ट के डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)) तक पहुँचें।  
1. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।  
1. नई सीरीज़ और श्रेणियां जोड़ें।  
1. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड मल्टी‑कैटेगरी चार्ट बनाता है:

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

    // एक सीरीज़ जोड़ें.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // Save the presentation with the chart.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![मल्टी‑कैटेगरी चार्ट](multi_category_chart.png)

### **मैप चार्ट बनाना**

मैप चार्ट भौगोलिक डेटा को देशों, राज्यों या शहरों जैसे विशिष्ट स्थानों पर मैप करके दर्शाते हैं। ये क्षेत्रीय रुझान, जनसांख्यिकीय डेटा और स्थानिक वितरण को स्पष्ट व दृश्यात्मक रूप में विश्लेषण करने के लिये उपयोगी होते हैं।

यह C# कोड मैप चार्ट बनाता है:

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

परिणाम:

![मैप चार्ट](map_chart.png)

{{% alert color="info" %}} 
ऊपर दिखाया गया चित्र PowerPoint में खोले गये सहेजे गए प्रस्तुति को दर्शाता है। Aspose.Slides मैप चार्ट और उसके डेटा को सही तौर पर लिखता है, लेकिन स्वयं मैप चार्ट नहीं बनाता: जब किसी स्लाइड को छवि में रेंडर किया जाता है या PDF या SVG में परिवर्तित किया जाता है, तो चार्ट क्षेत्र खाली दिखता है। उसी स्लाइड के अन्य आकार अप्रभावित रहते हैं।
{{% /alert %}} 

### **कम्बिनेशन चार्ट बनाना**

कम्बिनेशन (या कॉम्बो) चार्ट दो या अधिक चार्ट प्रकारों को एक ही ग्राफ़ में संयोजित करता है। यह चार्ट आपको दो या अधिक डेटा सेटों के बीच अंतर को उजागर, तुलना या जांचने की अनुमति देता है, जिससे उनके बीच संबंध समझने में मदद मिलती है।

![कम्बिनेशन चार्ट](combination_chart.png)

नीचे दिया गया C# कोड ऊपर दिखाए गये कॉम्बिनेशन चार्ट को PowerPoint प्रस्तुति में बनाता है:

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

    // चार्ट लेजेंड सेट करता है
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // डिफ़ॉल्ट जेनरेटेड सीरीज़ और श्रेणियों को हटाता है
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

## **चार्ट अपडेट करना**

Aspose.Slides for .NET आपको चार्ट डेटा, फ़ॉर्मेटिंग और शैली को संशोधित करके PowerPoint चार्ट को अपडेट करने की अनुमति देता है। यह कार्यक्षमता प्रस्तुतियों को गतिशील सामग्री के साथ अद्यतन रखने की प्रक्रिया को सरल बनाती है और यह सुनिश्चित करती है कि चार्ट वर्तमान डेटा और दृश्य मानकों को सही रूप से प्रतिबिंबित करें।

1. उस प्रस्तुति को प्रतिबिंबित करने वाली [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं जिसमें चार्ट हो।  
1. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।  
1. सभी आकारों में से चार्ट खोजने हेतु उन्हें क्रमिक रूप से जांचें।  
1. चार्ट की डेटा वर्कशीट तक पहुँचें।  
1. सीरीज़ मान बदलकर चार्ट डेटा सीरीज़ को संशोधित करें।  
1. एक नई सीरीज़ जोड़ें और उसके डेटा को भरें।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड चार्ट को अपडेट करता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// Presentation क्लास का इंस्टेंस बनाएं जो PPTX फ़ाइल का प्रतिनिधित्व करता है।
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // पहली स्लाइड तक पहुँचें।
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // चार्ट डेटा शीट का इंडेक्स सेट करें।
            int worksheetIndex = 0;

            // चार्ट डेटा वर्कबुक प्राप्त करें।
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // चार्ट श्रेणी नाम बदलें।
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // पहला चार्ट सीरीज़ प्राप्त करें।
            IChartSeries series = chart.ChartData.Series[0];

            // सीरीज़ डेटा अपडेट करें।
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // सीरीज़ नाम संशोधित कर रहा है।
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // दूसरा चार्ट सीरीज़ प्राप्त करें।
            series = chart.ChartData.Series[1];

            // सीरीज़ डेटा अपडेट करें।
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // सीरीज़ नाम संशोधित कर रहा है।
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // नई सीरीज़ जोड़ें।
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

## **चार्ट के लिये डेटा रेंज सेट करना**

Aspose.Slides for .NET आपको वर्कशीट से एक विशिष्ट डेटा रेंज को चार्ट के डेटा स्रोत के रूप में परिभाषित करने की लचीलापन प्रदान करता है। इससे आप वर्कशीट के किसी हिस्से को सीधे चार्ट से जोड़ सकते हैं, जिससे आप नियंत्रण कर सकते हैं कि कौन‑से सेल्स चार्ट की सीरीज़ और श्रेणियों में योगदान देते हैं। परिणामस्वरूप, आप अपने चार्ट को आसानी से अपडेट और वर्कशीट में नवीनतम डेटा परिवर्तन के साथ सिंक्रनाइज़ रख सकते हैं, जिससे आपके PowerPoint प्रस्तुतियों में सटीक जानकारी बनी रहे।

1. उस प्रस्तुति को प्रतिबिंबित करने वाली [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं जिसमें चार्ट हो।  
1. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।  
1. सभी आकारों में से चार्ट खोजें।  
1. चार्ट डेटा तक पहुँचें और रेंज निर्धारित करें।  
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड चार्ट की डेटा रेंज सेट करता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का इंस्टेंस बनाएं।
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // पहली स्लाइड तक पहुँचें.
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

## **चार्ट में डिफ़ॉल्ट मार्कर का उपयोग करना**

जब आप चार्ट में डिफ़ॉल्ट मार्कर का उपयोग करते हैं, तो प्रत्येक चार्ट सीरीज़ को स्वचालित रूप से एक अलग डिफ़ॉल्ट मार्कर चिह्न मिल जाता है।

यह C# कोड एक चार्ट सीरीज़ मार्कर को स्वचालित रूप से सेट करता है:

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

    // श्रृंखला डेटा भरें.
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

### Aspose.Slides for .NET द्वारा कौन‑से चार्ट प्रकार समर्थित हैं?

Aspose.Slides for .NET बार, लाइन, पाई, एरिया, स्कैटर, हिस्टोग्राम, रेडार आदि सहित कई प्रकार के चार्ट प्रकारों का समर्थन करता है। यह लचीलापन आपको डेटा विज़ुअलाइज़ेशन की आवश्यकताओं के अनुसार सबसे उपयुक्त चार्ट प्रकार चुनने की अनुमति देता है।

### स्लाइड में नया चार्ट कैसे जोड़ें?

चार्ट जोड़ने के लिये पहले आप एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का उदाहरण बनाते हैं, इच्छित स्लाइड को उसके इंडेक्स से प्राप्त करते हैं, और फिर चार्ट जोड़ने की मेथड को कॉल करके चार्ट प्रकार और प्रारंभिक डेटा निर्दिष्ट करते हैं। यह प्रक्रिया चार्ट को सीधे आपकी प्रस्तुति में एकीकृत करती है।

### चार्ट में प्रदर्शित डेटा को कैसे अपडेट करें?

आप चार्ट का डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)) तक पहुँचकर, डिफ़ॉल्ट सीरीज़ और श्रेणियां साफ़ करके, और फिर अपना कस्टम डेटा जोड़कर अपडेट कर सकते हैं। इस प्रकार आप प्रोग्रामेटिक रूप से चार्ट को नवीनतम डेटा के अनुसार ताज़ा कर सकते हैं।

### क्या चार्ट की उपस्थिति को अनुकूलित किया जा सकता है?

हाँ, Aspose.Slides for .NET व्यापक अनुकूलन विकल्प प्रदान करता है। आप रंग, फ़ॉन्ट, लेबल, लेजेंड और अन्य फ़ॉर्मेटिंग तत्वों को बदलकर चार्ट की उपस्थिति को अपनी विशिष्ट डिज़ाइन आवश्यकताओं के अनुरूप बना सकते हैं।