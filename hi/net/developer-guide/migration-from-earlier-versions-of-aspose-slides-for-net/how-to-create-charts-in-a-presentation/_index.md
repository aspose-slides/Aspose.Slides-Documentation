---
title: .NET में प्रस्तुतियों में चार्ट कैसे बनाएं
linktitle: चार्ट बनाएं
type: docs
weight: 30
url: /hi/net/how-to-create-charts-in-a-presentation/
keywords:
- माइग्रेशन
- चार्ट बनाएं
- लेगेसी कोड
- आधुनिक कोड
- लेगेसी दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides के साथ .NET में PowerPoint PPT, PPTX और ODP प्रस्तुतियों में चार्ट बनाने के लिए लेगेसी और आधुनिक चार्ट APIs दोनों का उपयोग करके सीखें।"
---
{{% alert color="primary" %}} 

एक नया [Aspose.Slides for .NET API](/slides/hi/net/) जारी किया गया है और अब यह एकल उत्पाद स्क्रैच से PowerPoint दस्तावेज़ बनाने और मौजूदा को संपादित करने की क्षमता का समर्थन करता है।

{{% /alert %}} 
## **Legacy कोड के लिए समर्थन**
Aspose.Slides for .NET के 13.x से पहले के संस्करणों के साथ विकसित किए गए लेगेसी कोड का उपयोग करने के लिए, आपको अपने कोड में कुछ छोटे परिवर्तन करने होंगे और कोड पहले की तरह काम करेगा। Aspose.Slide और Aspose.Slides.Pptx नेमस्पेसेस में पुराने Aspose.Slides for .NET में मौजूद सभी क्लासेज अब एकल Aspose.Slides नेमस्पेस में मिल गई हैं। कृपया लेगेसी Aspose.Slides API का उपयोग करके प्रस्तुति में स्क्रैच से सामान्य चार्ट बनाने के लिए नीचे दिया गया सरल कोड स्निपेट देखें और नई संयुक्त API में माइग्रेट करने के चरणों का पालन करें।

## **Legacy Aspose.Slides for .NET दृष्टिकोण**
```c#
//PPTX फ़ाइल का प्रतिनिधित्व करने वाली PresentationEx क्लास को इंस्टैंटिएट करें
using (PresentationEx pres = new PresentationEx())
{
	//पहली स्लाइड तक पहुँचें
	SlideEx sld = pres.Slides[0];

	// डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//चार्ट शीर्षक सेट कर रहे हैं
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//पहली श्रृंखला के लिए मान दिखाने के लिए सेट करें
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//चार्ट डेटा शीट का इंडेक्स सेट कर रहे हैं 
	int defaultWorksheetIndex = 0;

	//चार्ट डेटा वर्कशीट प्राप्त कर रहे हैं
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//डिफ़ॉल्ट जेनरेटेड श्रृंखलाओं और श्रेणियों को हटाएँ
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//नई श्रृंखला जोड़ रहे हैं
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//नई श्रेणियां जोड़ रहे हैं
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//पहली चार्ट श्रृंखला लें
	ChartSeriesEx series = chart.ChartData.Series[0];

	//अब श्रृंखला डेटा को भर रहे हैं
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//श्रृंखला के लिए फ़िल रंग सेट कर रहे हैं
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//दूसरी चार्ट श्रृंखला लें
	series = chart.ChartData.Series[1];

	//अब श्रृंखला डेटा को भर रहे हैं
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//श्रृंखला के लिए फ़िल रंग सेट कर रहे हैं
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//नई श्रृंखला के लिए प्रत्येक श्रेणी के कस्टम लेबल बनाएं

	//पहला लेबल श्रेणी का नाम दिखाएगा
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//दूसरे लेबल के लिए श्रृंखला का नाम दिखाएँ
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

## **नया Aspose.Slides for .NET 13.x दृष्टिकोण**
``` csharp
 //PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें//PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें
Presentation pres = new Presentation();

 //पहली स्लाइड तक पहुँचें
ISlide sld = pres.Slides[0];

 // डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

 //चार्ट शीर्षक सेट कर रहे हैं
 //chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

 //पहली श्रृंखला को मान दिखाने के लिए सेट करें
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

 //चार्ट डेटा शीट का इंडेक्स सेट कर रहे हैं
int defaultWorksheetIndex = 0;

 //चार्ट डेटा वर्कशीट प्राप्त कर रहे हैं
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

 //डिफ़ॉल्ट जेनरेटेड श्रृंखलाओं और श्रेणियों को हटाएँ
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

 //नई श्रृंखला जोड़ रहे हैं
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

 //नई श्रेणियां जोड़ रहे हैं
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

 //पहली चार्ट श्रृंखला लें
IChartSeries series = chart.ChartData.Series[0];

 //अब श्रृंखला डेटा भर रहे हैं

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

 //श्रृंखला के लिए फ़िल रंग सेट कर रहे हैं
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


 //दूसरी चार्ट श्रृंखला लें
series = chart.ChartData.Series[1];

 //अब श्रृंखला डेटा भर रहे हैं
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

 //श्रृंखला के लिए फ़िल रंग सेट कर रहे हैं
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


 //नई श्रृंखला के लिए प्रत्येक श्रेणी के लिए कस्टम लेबल बनाएं

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

कृपया लेगेसी Aspose.Slides API का उपयोग करके प्रस्तुति में स्क्रैच से स्कैटर्ड चार्ट बनाने के लिए नीचे दिया गया सरल कोड स्निपेट देखें और नई संयुक्त API के साथ इसे कैसे प्राप्त किया जाए।

## **Legacy Aspose.Slides for .NET दृष्टिकोण**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //डिफ़ॉल्ट चार्ट बना रहे हैं
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //डिफ़ॉल्ट चार्ट डेटा वर्कशीट इंडेक्स प्राप्त कर रहे हैं
    int defaultWorksheetIndex = 0;

    //चार्ट डेटा वर्कशीट तक पहुँच रहे हैं
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //डेमो श्रृंखला हटाएँ
    chart.ChartData.Series.Clear();

    //नई श्रृंखला जोड़ें
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //पहली चार्ट श्रृंखला लें
    ChartSeriesEx series = chart.ChartData.Series[0];

    //नई बिंदु (1:3) जोड़ें
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //नई बिंदु (2:10) जोड़ें
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //श्रृंखला का प्रकार संपादित करें
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //चार्ट श्रृंखला मार्कर बदल रहे हैं
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //दूसरी चार्ट श्रृंखला लें
    series = chart.ChartData.Series[1];

    //नई बिंदु (5:2) जोड़ें
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //नई बिंदु (3:1) जोड़ें
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //नई बिंदु (2:2) जोड़ें
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //नई बिंदु (5:1) जोड़ें
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //चार्ट श्रृंखला मार्कर बदल रहे हैं
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```

## **नया Aspose.Slides for .NET 13.x दृष्टिकोण**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//डिफ़ॉल्ट चार्ट बना रहे हैं
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//डिफ़ॉल्ट चार्ट डेटा वर्कशीट इंडेक्स प्राप्त कर रहे हैं
int defaultWorksheetIndex = 0;

//चार्ट डेटा वर्कशीट तक पहुँच रहे हैं
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//डेमो श्रृंखला हटाएँ
chart.ChartData.Series.Clear();

//नई श्रृंखला जोड़ें
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//पहली चार्ट श्रृंखला लें
IChartSeries series = chart.ChartData.Series[0];

//नई बिंदु (1:3) जोड़ें
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//नई बिंदु (2:10) जोड़ें
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//श्रृंखला का प्रकार संपादित करें
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//चार्ट श्रृंखला मार्कर बदल रहे हैं
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//दूसरी चार्ट श्रृंखला लें
series = chart.ChartData.Series[1];

//नई बिंदु (5:2) जोड़ें
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//नई बिंदु (3:1) जोड़ें
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//नई बिंदु (2:2) जोड़ें
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//नई बिंदु (5:1) जोड़ें
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//चार्ट श्रृंखला मार्कर बदल रहे हैं
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```