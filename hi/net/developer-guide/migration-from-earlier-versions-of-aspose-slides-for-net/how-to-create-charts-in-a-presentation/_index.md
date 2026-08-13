---
title: .NET में प्रस्तुतियों में चार्ट बनाने का तरीका
linktitle: चार्ट बनाएं
type: docs
weight: 30
url: /hi/net/how-to-create-charts-in-a-presentation/
keywords:
- माइग्रेशन
- चार्ट बनाना
- पुराने कोड
- आधुनिक कोड
- पुरानी पद्धति
- आधुनिक पद्धति
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके .NET में PowerPoint PPT, PPTX और ODP प्रस्तुतियों में दोनों पुराने और आधुनिक चार्ट APIs के साथ चार्ट कैसे बनाएं, सीखें।"
---
{{% alert color="info" %}} 

एक नया [Aspose.Slides for .NET API](/slides/hi/net/) जारी किया गया है और अब यह एकल उत्पाद स्क्रैच से PowerPoint दस्तावेज़ बनाने तथा मौजूदा दस्तावेज़ों को संपादित करने की क्षमता प्रदान करता है।

{{% /alert %}} 
## **Support for Legacy Code**
पूर्व में Aspose.Slides for .NET के 13.x से पहले के संस्करणों में विकसित किए गए लिगेसी कोड को उपयोग करने के लिए आपको अपने कोड में कुछ छोटे परिवर्तन करने होंगे और कोड पहले की तरह काम करेगा। पुराने Aspose.Slides for .NET में Aspose.Slide और Aspose.Slides.Pptx नेमस्पेसेज़ के तहत मौजूद सभी क्लासेस अब एकल Aspose.Slides नेमस्पेस में मिश्रित हो गई हैं। कृपया नीचे दिया गया साधारण कोड स्निपेट देखें जिसका उपयोग लिगेसी Aspose.Slides API के साथ स्क्रैच से सामान्य चार्ट बनाने के लिए किया जाता है और नई मिश्रित API में माइग्रेट करने के चरणों का अनुसरण करें।
## **Legacy Aspose.Slides for .NET Approach**
```c#
using System.Drawing;

//PPTX फ़ाइल का प्रतिनिधित्व करने वाली PresentationEx क्लास को उदाहरणित करें
using (PresentationEx pres = new PresentationEx())
{
	//पहली स्लाइड तक पहुँचें
	SlideEx sld = pres.Slides[0];

	// डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//चार्ट शीर्षक सेट करना
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//पहले सीरीज़ को मान दिखाने के लिए सेट करें
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//चार्ट डेटा शीट का इंडेक्स सेट करना 
	int defaultWorksheetIndex = 0;

	//चार्ट डेटा वर्कशीट प्राप्त कर रहे हैं
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//डिफ़ॉल्ट जेनरेटेड सीरीज़ और श्रेणियां हटाएँ
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//नई सीरीज़ जोड़ें
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//नई श्रेणियां जोड़ें
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//पहली चार्ट सीरीज़ लें
	ChartSeriesEx series = chart.ChartData.Series[0];

	//अब सीरीज़ डेटा पॉपुलेट कर रहे हैं
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//सीरीज़ के लिए Fill रंग सेट करना
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//दूसरी चार्ट सीरीज़ लें
	series = chart.ChartData.Series[1];

	//अब सीरीज़ डेटा पॉपुलेट कर रहे हैं
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//सीरीज़ के लिए Fill रंग सेट करना
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//नई सीरीज़ के लिए प्रत्येक श्रेणी के कस्टम लेबल बनाएं

	//पहला लेबल श्रेणी का नाम दिखाएगा
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//दूसरे लेबल के लिए सीरीज़ का नाम दिखाएँ
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//तीसरे लेबल के लिए मान दिखाएँ
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//मान और कस्टम टेक्स्ट दिखाएँ
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//चार्ट के साथ प्रस्तुति सहेजें
	pres.Write(@"D:\AsposeChart.pptx");
}
```



## **New Aspose.Slides for .NET 13.x Approach**
``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

//PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को उदाहरणित करें//PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को उदाहरणित करें
Presentation pres = new Presentation();

//पहली स्लाइड तक पहुँचें
ISlide sld = pres.Slides[0];

// डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//चार्ट शीर्षक सेट करना
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//चार्ट डेटा शीट का इंडेक्स सेट करना
int defaultWorksheetIndex = 0;

//चार्ट डेटा वर्कशीट प्राप्त कर रहे हैं
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//डिफ़ॉल्ट जेनरेटेड सीरीज़ और श्रेणियां हटाएँ
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//नई सीरीज़ जोड़ें
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//पहले सीरीज़ को मान दिखाने के लिए सेट करें
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//नई श्रेणियां जोड़ें
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//पहली चार्ट सीरीज़ लें
IChartSeries series = chart.ChartData.Series[0];

//अब सीरीज़ डेटा पॉपुलेट कर रहे हैं

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//सीरीज़ के लिए Fill रंग सेट करना
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//दूसरी चार्ट सीरीज़ लें
series = chart.ChartData.Series[1];

//अब सीरीज़ डेटा पॉपुलेट कर रहे हैं
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//सीरीज़ के लिए Fill रंग सेट करना
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//नई सीरीज़ के लिए प्रत्येक श्रेणी के कस्टम लेबल बनाएं

//पहला लेबल श्रेणी का नाम दिखाएगा
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//तीसरे लेबल के लिए मान दिखाएँ
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//चार्ट के साथ प्रस्तुति सहेजें
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

कृपया नीचे दिया गया साधारण कोड स्निपेट देखें जिसका उपयोग लिगेसी Aspose.Slides API के साथ स्क्रैच से स्कैटरड चार्ट बनाने के लिए किया जाता है और नई मिश्रित API के साथ इसे कैसे प्राप्त किया जाता है।

## **Legacy Aspose.Slides for .NET Approach**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //डिफ़ॉल्ट चार्ट बनाना
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //डिफ़ॉल्ट चार्ट डेटा वर्कशीट इंडेक्स प्राप्त करना
    int defaultWorksheetIndex = 0;

    //चार्ट डेटा वर्कशीट तक पहुँचना
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //डेमो सीरीज़ हटाएँ
    chart.ChartData.Series.Clear();

    //नई सीरीज़ जोड़ें
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //पहली चार्ट सीरीज़ लें
    ChartSeriesEx series = chart.ChartData.Series[0];

    //वहाँ नया बिंदु (1:3) जोड़ें।
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //नया बिंदु (2:10) जोड़ें
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //सीरीज़ का प्रकार संपादित करें
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //चार्ट सीरीज़ मार्कर बदल रहे हैं
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //दूसरी चार्ट सीरीज़ लें
    series = chart.ChartData.Series[1];

    //वहाँ नया बिंदु (5:2) जोड़ें।
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //नया बिंदु (3:1) जोड़ें
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //नया बिंदु (2:2) जोड़ें
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //नया बिंदु (5:1) जोड़ें
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //चार्ट सीरीज़ मार्कर बदल रहे हैं
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **New Aspose.Slides for .NET 13.x Approach**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//डिफ़ॉल्ट चार्ट बनाना
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//डिफ़ॉल्ट चार्ट डेटा वर्कशीट इंडेक्स प्राप्त करना
int defaultWorksheetIndex = 0;

//चार्ट डेटा वर्कशीट तक पहुँच रहे हैं
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//डेमो सीरीज़ हटाएँ
chart.ChartData.Series.Clear();

//नई सीरीज़ जोड़ें
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//पहली चार्ट सीरीज़ लें
IChartSeries series = chart.ChartData.Series[0];

//वहाँ नया बिंदु (1:3) जोड़ें।
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//नया बिंदु (2:10) जोड़ें
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//सीरीज़ का प्रकार संपादित करें
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//चार्ट सीरीज़ मार्कर बदल रहे हैं
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//दूसरी चार्ट सीरीज़ लें
series = chart.ChartData.Series[1];

//वहाँ नया बिंदु (5:2) जोड़ें।
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//नया बिंदु (3:1) जोड़ें
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//नया बिंदु (2:2) जोड़ें
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//नया बिंदु (5:1) जोड़ें
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//चार्ट सीरीज़ मार्कर बदल रहे हैं
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```