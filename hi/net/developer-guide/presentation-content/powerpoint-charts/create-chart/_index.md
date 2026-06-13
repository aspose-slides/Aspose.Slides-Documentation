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
- सनबर्स्ट चार्ट
- हिस्टोग्राम चार्ट
- रेडार चार्ट
- मल्टीकैटेगरी चार्ट
- पावरपॉइंट
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट बनाएं और अनुकूलित करें। C# में व्यावहारिक कोड उदाहरणों के साथ चार्ट जोड़ें, फ़ॉर्मेट करें और संपादित करें।"
---
## **परिचय**

यह लेख Aspose.Slides for .NET का उपयोग करके चार्ट बनाने और अनुकूलित करने पर एक व्यापक मार्गदर्शन प्रदान करता है। आप सीखेंगे कि प्रोग्रामेटिक रूप से स्लाइड में चार्ट कैसे जोड़ें, डेटा से भरें, और विभिन्न स्वरूपण विकल्प लागू करें ताकि आपकी विशिष्ट डिज़ाइन आवश्यकताओं के साथ मेल खा सकें। लेख भर में विस्तृत कोड उदाहरण प्रत्येक चरण को दर्शाते हैं, प्रस्तुति और चार्ट ऑब्जेक्ट को इनिशियलाइज़ करने से लेकर सीरीज़, एक्सिस और लेजेंड को कॉन्फ़िगर करने तक। इस मार्गदर्शिका का पालन करके आप अपने .NET अनुप्रयोगों में डायनेमिक चार्ट जेनरेशन को एकीकृत करने की ठोस समझ प्राप्त करेंगे, जिससे डेटा-ड्रिवेन प्रस्तुतियों का निर्माण सुगम हो जाता है।

## **एक चार्ट बनाएँ**

चार्ट लोगों को डेटा को शीघ्रता से दृश्य रूप में समझने और उन अंतर्दृष्टियों को प्राप्त करने में मदद करते हैं जो टेबल या स्प्रेडशीट से तुरंत स्पष्ट नहीं होतीं।

**चार्ट क्यों बनाएं?**

चार्ट का उपयोग करके आप:

* एक ही स्लाइड पर बड़ी मात्रा में डेटा को समेट सकते हैं या सारांशित कर सकते हैं;
* डेटा में पैटर्न और रुझान उजागर कर सकते हैं;
* समय के साथ या किसी विशिष्ट माप इकाई के संबंध में डेटा की दिशा और गति को निर्धारित कर सकते हैं;
* अपवाद, विचलन, त्रुटियां और अनर्थक डेटा को पहचान सकते हैं;
* जटिल डेटा को प्रभावी ढंग से संवाद या प्रस्तुत कर सकते हैं।

PowerPoint में, आप *Insert* फ़ंक्शन के माध्यम से कई प्रकार के चार्ट टेम्पलेट के साथ चार्ट बना सकते हैं। Aspose.Slides का उपयोग करके आप नियमित चार्ट (प्रसिद्ध चार्ट प्रकारों पर आधारित) और कस्टम चार्ट दोनों बना सकते हैं।

{{% alert color="primary" %}} 
[ChartType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/charttype/) एन्हुमरेशन का उपयोग [Aspose.Slides.Charts](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/) नेमस्पेस के तहत करें। इस एन्हुमरेशन के मान विभिन्न चार्ट प्रकारों के अनुरूप होते हैं।
{{% /alert %}} 

### **क्लस्टरड कॉलम चार्ट बनाएं**

यह भाग Aspose.Slides for .NET का उपयोग करके क्लस्टरड कॉलम चार्ट बनाने की विधि समझाता है। आप सीखेंगे कि प्रस्तुति को इनिशियलाइज़ करें, चार्ट जोड़ें, और शीर्षक, डेटा, सीरीज़, श्रेणियाँ तथा स्टाइलिंग जैसे तत्वों को अनुकूलित करें। नीचे दिए चरणों का पालन करके देखें कि एक सामान्य क्लस्टरड कॉलम चार्ट कैसे जनरेट किया जाता है:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
1. अपने इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. कुछ डेटा के साथ चार्ट जोड़ें और `ChartType.ClusteredColumn` प्रकार निर्दिष्ट करें।
1. चार्ट में एक शीर्षक जोड़ें।
1. चार्ट की डेटा वर्कशीट तक पहुँचें।
1. सभी डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
1. नई सीरीज़ और श्रेणियाँ जोड़ें।
1. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
1. चार्ट सीरीज़ पर फ़िल रंग लागू करें।
1. चार्ट सीरीज़ में लेबल जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड क्लस्टरड कॉलम चार्ट बनाने को प्रदर्शित करता है:

```c#
// Presentation क्लास का इंस्टेंस बनाएँ।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड तक पहुंचें।
    ISlide slide = presentation.Slides[0];

    // डिफ़ॉल्ट डेटा के साथ क्लस्टरड कॉलम चार्ट जोड़ें।
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // चार्ट शीर्षक सेट करें।
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // पहला सीरीज़ मान दिखाने के लिए सेट करें।
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // चार्ट डेटा शीट का इंडेक्स सेट करें।
    int worksheetIndex = 0;

    // चार्ट डेटा वर्कबुक प्राप्त करें।
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // डिफ़ॉल्ट जेनरेटेड सीरीज़ और श्रेणियों को हटाएँ।
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // नई सीरीज़ जोड़ें।
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // नई श्रेणियाँ जोड़ें।
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // पहला चार्ट सीरीज़ प्राप्त करें।
    IChartSeries series = chart.ChartData.Series[0];

    // सीरीज़ डेटा भरें।
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // सीरीज़ के लिए भराव रंग सेट करें।
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // दूसरा चार्ट सीरीज़ प्राप्त करें।
    series = chart.ChartData.Series[1];

    // सीरीज़ डेटा भरें।
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // सीरीज़ के लिए भराव रंग सेट करें।
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // पहला लेबल श्रेणी नाम दिखाने के लिए सेट करें।
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // तीसरे लेबल के लिए मान दिखाने हेतु सीरीज़ सेट करें।
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // प्रस्तुतिकरण को डिस्क पर PPTX फ़ाइल के रूप में सहेजें।
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![The Clustered Column chart](clustered_column_chart.png)

### **स्कैटर चार्ट बनाएं**

स्कैटर चार्ट (जिसे स्कैटर प्लॉट या x‑y ग्राफ़ भी कहा जाता है) अक्सर दो चर के बीच पैटर्न की जाँच या सहसंबंध दर्शाने के लिए उपयोग किए जाते हैं।

स्कैटर चार्ट तब उपयोग करें जब:

* आपके पास युग्मित संख्यात्मक डेटा हो।
* दो चर एक साथ अच्छी तरह से मेल खाते हों।
* आप यह निर्धारित करना चाहते हों कि दो चर संबंधित हैं या नहीं।
* आपके पास एक स्वतंत्र चर हो जिसके कई मान निर्भरशील चर के लिए हों।

यह C# कोड विभिन्न मार्कर सीरीज़ के साथ स्कैटर चार्ट बनाने को दर्शाता है:

```c#
// Presentation क्लास का इंस्टेंस बनाएँ।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड तक पहुंचें।
    ISlide slide = presentation.Slides[0];

    // डिफ़ॉल्ट स्कैटर चार्ट बनाएं।
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // चार्ट डेटा शीट का इंडेक्स सेट करें।
    int worksheetIndex = 0;

    // चार्ट डेटा वर्कबुक प्राप्त करें।
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // डिफ़ॉल्ट सीरीज़ हटाएँ।
    chart.ChartData.Series.Clear();

    // नई सीरीज़ जोड़ें।
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // पहला चार्ट सीरीज़ प्राप्त करें।
    IChartSeries series = chart.ChartData.Series[0];

    // सीरीज़ में नया पॉइंट (1:3) जोड़ें।
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // नया पॉइंट (2:10) जोड़ें।
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // सीरीज़ प्रकार बदलें।
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // चार्ट सीरीज़ मार्कर बदलें।
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // दूसरा चार्ट सीरीज़ प्राप्त करें।
    series = chart.ChartData.Series[1];

    // चार्ट सीरीज़ में नया पॉइंट (5:2) जोड़ें।
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // नया पॉइंट (3:1) जोड़ें।
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // नया पॉइंट (2:2) जोड़ें।
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // नया पॉइंट (5:1) जोड़ें।
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // चार्ट सीरीज़ मार्कर बदलें।
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // प्रस्तुतिकरण को डिस्क पर PPTX फ़ाइल के रूप में सहेजें।
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![The Scatter chart](scatter_chart.png)

### **पाई चार्ट बनाएं**

पाई चार्ट डेटा में भाग‑से‑पूरे संबंध दिखाने के लिए सबसे उपयुक्त होते हैं, विशेषकर जब डेटा में श्रेणीय लेबल के साथ संख्यात्मक मान हों। यदि आपके डेटा में बहुत अधिक भाग या लेबल हों, तो बार चार्ट का उपयोग करने पर विचार करें।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
1. अपने इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें और `ChartType.Pie` प्रकार निर्दिष्ट करें।
1. चार्ट की डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)) तक पहुँचें।
1. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
1. नई सीरीज़ और श्रेणियाँ जोड़ें।
1. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
1. चार्ट में नई पॉइंट्स जोड़ें और पाई चार्ट के सेक्टरों के लिए कस्टम रंग लागू करें।
1. सीरीज़ के लेबल सेट करें।
1. सीरीज़ लेबल के लिए लीडर लाइन सक्रिय करें।
1. पाई चार्ट का रोटेशन एंगल सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड पाई चार्ट बनाने को दिखाता है:

```c#
// Presentation क्लास का इंस्टेंस बनाएँ।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड तक पहुंचें।
    ISlide slide = presentation.Slides[0];

    // डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // चार्ट शीर्षक सेट करें।
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // पहले सीरीज़ को मान दिखाने के लिए सेट करें।
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // चार्ट डेटा शीट का इंडेक्स सेट करें।
    int worksheetIndex = 0;

    // चार्ट डेटा वर्कबुक प्राप्त करें।
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // डिफ़ॉल्ट जेनरेटेड सीरीज़ और श्रेणियों को हटाएँ।
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // नई श्रेणियाँ जोड़ें।
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

    // चार्ट के लिए सीरीज़ को लीडर लाइन्स दिखाने के लिए सेट करें।
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // पाई चार्ट के सेक्टरों के लिए घूर्णन कोण सेट करें।
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // प्रस्तुतिकरण को डिस्क पर PPTX फ़ाइल के रूप में सहेजें।
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![The Pie chart](pie_chart.png)

### **लाइन चार्ट बनाएं**

लाइन चार्ट (जिसे लाइन ग्राफ़ भी कहा जाता है) उन स्थितियों में सबसे उपयुक्त होते हैं जहाँ आप समय के साथ मानों में परिवर्तन प्रदर्शित करना चाहते हैं। लाइन चार्ट का उपयोग करके आप बड़ी मात्रा में डेटा की तुलना, समय के साथ रुझानों को ट्रैक, डेटा सीरीज़ में असामान्यताओं को उजागर आदि कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
1. अपने इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें और `ChartType.Line` प्रकार निर्दिष्ट करें।
1. चार्ट की डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)) तक पहुँचें।
1. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
1. नई सीरीज़ और श्रेणियाँ जोड़ें।
1. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड लाइन चार्ट बनाने को दर्शाता है:

```c#
using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

डिफ़ॉल्ट रूप से, लाइन चार्ट पर बिंदुओं को सीधी लगातार रेखाओं से जोड़ा जाता है। यदि आप बिंदुओं को डैश के रूप में जोड़ना चाहते हैं, तो नीचे दर्शाए अनुसार डैश प्रकार निर्दिष्ट करें:

```c#
foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

परिणाम:

![The Line chart](line_chart.png)

### **ट्री मैप चार्ट बनाएं**

ट्री मैप चार्ट बिक्री डेटा के लिए उपयुक्त होते हैं जब आप डेटा श्रेणियों के सापेक्ष आकार दिखाना चाहते हैं और प्रत्येक श्रेणी में बड़े योगदानकारियों पर जल्दी ध्यान आकर्षित करना चाहते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
1. अपने इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें और `ChartType.Treemap` प्रकार निर्दिष्ट करें।
1. चार्ट की डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)) तक पहुँचें।
1. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
1. नई सीरीज़ और श्रेणियाँ जोड़ें।
1. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड ट्री मैप चार्ट बनाने को दिखाता है:

```c#
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

![The Treemap chart](treemap_chart.png)

### **स्टॉक चार्ट बनाएं**

स्टॉक चार्ट वित्तीय डेटा (ओपन, हाई, लो, क्लोज कीमतें) को प्रदर्शित करने के लिए उपयोग किए जाते हैं, जिससे बाजार रुझान और अस्थिरता का विश्लेषण संभव होता है। ये चार्ट स्टॉक प्रदर्शन पर महत्वपूर्ण अंतर्दृष्टि प्रदान करते हैं, जिससे निवेशकों और विश्लेषकों को सूचित निर्णय लेने में मदद मिलती है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
1. अपने इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें और `ChartType.OpenHighLowClose` प्रकार निर्दिष्ट करें।
1. चार्ट की डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)) तक पहुँचें।
1. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
1. नई सीरीज़ और श्रेणियाँ जोड़ें।
1. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
1. HiLowLines फ़ॉर्मेट निर्दिष्ट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड स्टॉक चार्ट बनाने को दर्शाता है:

```c#
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

![The Stock chart](stock_chart.png)

### **बॉक्स और व्हिस्कर चार्ट बनाएं**

बॉक्स और व्हिस्कर चार्ट डेटा वितरण को मध्य मान, क्वारटाइल और संभावित आउटलेयर्स जैसे मुख्य सांख्यिकीय मापों के साथ संक्षिप्त रूप में प्रदर्शित करते हैं। ये विश्लेषणात्मक डेटा अध्ययन और अन्वेषणात्मक डेटा विश्लेषण में डेटा परिवर्तनशीलता को जल्दी समझने और किसी भी असामान्यता की पहचान करने में सहायक होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
1. अपने इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें और `ChartType.BoxAndWhisker` प्रकार निर्दिष्ट करें।
1. चार्ट की डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)) तक पहुँचें।
1. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
1. नई सीरीज़ और श्रेणियाँ जोड़ें।
1. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड बॉक्स और व्हिस्कर चार्ट बनाने को दर्शाता है:

```c#
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

फ़नल चार्ट उन प्रक्रियाओं को दृश्य रूप में प्रस्तुत करने के लिए उपयोग होते हैं जिनमें क्रमिक चरण होते हैं, जहाँ डेटा की मात्रा प्रत्येक चरण के बाद घटती है। ये रूपांतरण दरों का विश्लेषण, बाधाओं की पहचान, और बिक्री या मार्केटिंग प्रक्रिया की दक्षता को ट्रैक करने में विशेष रूप से मददगार होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
1. अपने इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें और `ChartType.Funnel` प्रकार निर्दिष्ट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड फ़नल चार्ट बनाने को दर्शाता है:

```c#
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

![The Funnel chart](funnel_chart.png)

### **सनबर्स्ट चार्ट बनाएं**

सनबर्स्ट चार्ट पदानुक्रमित डेटा को प्रदर्शित करने के लिए उपयोग होते हैं, जहाँ स्तरों को सम्मिलित रिंग्स के रूप में दिखाया जाता है। ये भाग‑से‑पूरा संबंधों को स्पष्ट रूप से दिखाते हैं और नेस्टेड श्रेणियों को संक्षिप्त प्रारूप में प्रस्तुत करने के लिए आदर्श हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
1. अपने इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें और `ChartType.Sunburst` प्रकार निर्दिष्ट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड सनबर्स्ट चार्ट बनाने को दिखाता है:

```c#
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

![The Sunburst chart](sunburst_chart.png)

### **हिस्टोग्राम चार्ट बनाएं**

हिस्टोग्राम चार्ट संख्यात्मक डेटा के वितरण को रेंज या बिन्स में समूहित करके दर्शाते हैं। ये आवृत्ति, स्क्यूनेस और प्रसार जैसे पैटर्न की पहचान और डेटा सेट में आउटलेयर्स का पता लगाने में विशेष रूप से उपयोगी होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
1. अपने इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. कुछ डेटा के साथ चार्ट जोड़ें और `ChartType.Histogram` प्रकार निर्दिष्ट करें।
1. चार्ट की डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)) तक पहुँचें।
1. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
1. नई सीरीज़ और श्रेणियाँ जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड हिस्टोग्राम चार्ट बनाने को दर्शाता है:

```c#
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

![The Histogram chart](histogram_chart.png)

### **रेडार चार्ट बनाएं**

रेडार चार्ट बहुवैध डेटा को दो‑आयामी प्रारूप में प्रदर्शित करते हैं, जिससे कई वेरिएबल को एक साथ आसानी से तुलना किया जा सके। ये कई प्रदर्शन मीट्रिक्स या गुणों में पैटर्न, ताकत और कमजोरियों की पहचान में सहायक होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
1. अपने इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. कुछ डेटा के साथ चार्ट जोड़ें और `ChartType.Radar` प्रकार निर्दिष्ट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड रेडार चार्ट बनाने को दिखाता है:

```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![The Radar chart](radar_chart.png)

### **मल्टी‑कैटेगरी चार्ट बनाएं**

मल्टी‑कैटेगरी चार्ट उन डेटा को प्रदर्शित करने के लिए उपयोग होते हैं जिनमें एक से अधिक श्रेणी समूह शामिल होते हैं, जिससे आप कई आयामों में मानों की एक साथ तुलना कर सकें। ये जटिल, बहु‑परत डेटा सेट में रुझानों और संबंधों का विश्लेषण करने में विशेष रूप से मददगार होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
1. अपने इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें और `ChartType.ClusteredColumn` प्रकार निर्दिष्ट करें।
1. चार्ट की डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)) तक पहुँचें।
1. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
1. नई सीरीज़ और श्रेणियाँ जोड़ें।
1. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड मल्टी‑कैटेगरी चार्ट बनाने को दिखाता है:

```c#
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

    // चार्ट के साथ प्रस्तुति सहेजें।
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![The multi category chart](multi_category_chart.png)

### **मैप चार्ट बनाएं**

मैप चार्ट भौगोलिक डेटा को देशों, राज्यों या शहरों जैसे विशिष्ट स्थानों पर मानचित्रित करके दृश्य रूप में प्रस्तुत करते हैं। ये क्षेत्रीय रुझानों, जनसांख्यिकीय डेटा और स्थानिक वितरण का स्पष्ट और आकर्षक रूप में विश्लेषण करने में अत्यंत उपयोगी होते हैं।

यह C# कोड मैप चार्ट बनाने को दर्शाता है:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![The Map chart](map_chart.png)

### **कंबीनेशन चार्ट बनाएं**

कंबीनेशन चार्ट (या कॉम्बो चार्ट) एक ही ग्राफ़ में दो या अधिक चार्ट प्रकारों को संयोजित करता है। यह चार्ट आपको दो या अधिक डेटा सेट के बीच अंतर को उजागर, तुलना या जांचने में सक्षम बनाता है, जिससे उनके बीच के संबंध स्पष्ट हो जाते हैं।

![The combination chart](combination_chart.png)

नीचे दिया गया C# कोड ऊपर दर्शाए गए कंबीनेशन चार्ट को PowerPoint प्रस्तुति में बनाने की विधि दिखाता है:

```c#
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

    // नई श्रेणियाँ जोड़ता है
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
    // हॉरिज़ॉन्टल अक्ष सेट करता है
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // वर्टिकल अक्ष सेट करता है
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // वर्टिकल प्रमुख ग्रिडलाइन का रंग सेट करता है
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // सेकेंडरी हॉरिज़ॉन्टल अक्ष सेट करता है
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // सेकेंडरी वर्टिकल अक्ष सेट करता है
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

Aspose.Slides for .NET आपको चार्ट डेटा, फ़ॉर्मेटिंग और स्टाइलिंग को संशोधित करके PowerPoint चार्ट अपडेट करने की सुविधा देता है। यह क्षमता प्रस्तुतियों को डायनेमिक कंटेंट के साथ अद्यतित रखने और यह सुनिश्चित करने में मदद करती है कि चार्ट वर्तमान डेटा और दृश्य मानकों को सही ढंग से प्रतिबिंबित करें।

1. उस प्रस्तुति को दर्शाने वाले [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का इंस्टेंस बनाएं जिसमें चार्ट हो।
1. अपने इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. सभी शैप्स को ट्रैवर्स करके चार्ट खोजें।
1. चार्ट की डेटा वर्कशीट तक पहुँचें।
1. सीरीज़ मान बदलकर चार्ट डेटा सीरीज़ संशोधित करें।
1. नई सीरीज़ जोड़ें और उसका डेटा भरें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड एक चार्ट को अपडेट करने को दर्शाता है:

```c#
const string chartName = "My chart";

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएँ।
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

            // चार्ट श्रेणी नाम बदलें।
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // पहला चार्ट सीरीज़ प्राप्त करें।
            IChartSeries series = chart.ChartData.Series[0];

            // सीरीज़ डेटा अपडेट करें।
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // सीरीज़ का नाम बदल रहा है।
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // दूसरा चार्ट सीरीज़ प्राप्त करें।
            series = chart.ChartData.Series[1];

            // सीरीज़ डेटा अपडेट करें।
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // सीरीज़ का नाम बदल रहा है।
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

## **एक चार्ट के लिए डेटा रेंज सेट करें**

Aspose.Slides for .NET आपको वर्कशीट से किसी विशिष्ट डेटा रेंज को चार्ट के डेटा स्रोत के रूप में परिभाषित करने की लचीलापन देता है। इसका अर्थ है कि आप सीधे वर्कशीट के एक हिस्से को चार्ट से जोड़ सकते हैं, जिससे आप यह नियंत्रित कर सकते हैं कि किस सेल का डेटा चार्ट की सीरीज़ और श्रेणियों में योगदान देगा। परिणामस्वरूप, आप अपने चार्ट को आसानी से अपडेट और आपके वर्कशीट में नवीनतम डेटा परिवर्तन के साथ सिंक्रनाइज़ कर सकते हैं, जिससे आपके PowerPoint प्रस्तुतियों में वर्तमान और सटीक जानकारी प्रतिबिंबित होती है।

1. उस प्रस्तुति को दर्शाने वाले [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का इंस्टेंस बनाएं जिसमें चार्ट हो।
1. अपने इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. सभी शैप्स को ट्रैवर्स करके चार्ट खोजें।
1. चार्ट डेटा तक पहुँचें और रेंज सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड एक चार्ट के लिए डेटा रेंज सेट करने को दर्शाता है:

```c#
const string chartName = "My chart";

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएँ।
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

## **चार्ट में डिफ़ॉल्ट मार्कर्स का उपयोग करें**

जब आप चार्ट में डिफ़ॉल्ट मार्कर्स का उपयोग करते हैं, तो प्रत्येक चार्ट सीरीज़ को स्वतः एक अलग डिफ़ॉल्ट मार्कर प्रतीक मिल जाता है।

यह C# कोड दशांतर रूप से चार्ट सीरीज़ मार्कर को स्वतः सेट करने को दर्शाता है:

```c#
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

**Aspose.Slides for .NET कौन-कौन से चार्ट प्रकारों का समर्थन करता है?**

Aspose.Slides for .NET बार, लाइन, पाई, एरिया, स्कैटर, हिस्टोग्राम, रेडार आदि सहित विभिन्न चार्ट प्रकारों का व्यापक समर्थन करता है। यह लचीलापन आपको अपने डेटा विज़ुअलाइज़ेशन की आवश्यकताओं के अनुसार सबसे उपयुक्त चार्ट प्रकार चुनने की अनुमति देता है।

**मैं स्लाइड में नया चार्ट कैसे जोड़ूँ?**

चार्ट जोड़ने के लिए आप सबसे पहले [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाते हैं, इच्छित स्लाइड को उसके इंडेक्स से प्राप्त करते हैं, फिर चार्ट जोड़ने के मेथड को कॉल करते हैं, जिसमें आप चार्ट प्रकार और प्रारंभिक डेटा निर्दिष्ट करते हैं। यह प्रक्रिया आपके प्रस्तुतिकरण में सीधे चार्ट को एकीकृत कर देती है।

**मैं चार्ट में दिखाए गए डेटा को कैसे अपडेट करूँ?**

आप चार्ट के डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/)) तक पहुँच कर, डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करके, फिर अपनी कस्टम डेटा जोड़कर चार्ट का डेटा अपडेट कर सकते हैं। इससे आप प्रोग्रामेटिक रूप से चार्ट को नवीनतम डेटा के अनुरूप रिफ्रेश कर सकते हैं।

**क्या मैं चार्ट की उपस्थिति को अनुकूलित कर सकता हूँ?**

हां, Aspose.Slides for .NET विस्तृत अनुकूलन विकल्प प्रदान करता है। आप रंग, फ़ॉन्ट, लेबल, लेजेंड और अन्य फ़ॉर्मेटिंग तत्वों को संशोधित करके चार्ट की उपस्थिति को अपनी विशिष्ट डिज़ाइन आवश्यकताओं के अनुसार ढाल सकते हैं।