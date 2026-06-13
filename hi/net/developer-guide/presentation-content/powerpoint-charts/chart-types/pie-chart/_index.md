---
title: .NET में प्रस्तुतियों में पाई चार्ट को अनुकूलित करें
linktitle: पाई चार्ट
type: docs
url: /hi/net/pie-chart/
keywords:
- पाई चार्ट
- चार्ट प्रबंधित करें
- चार्ट को अनुकूलित करें
- चार्ट विकल्प
- चार्ट सेटिंग्स
- प्लॉट विकल्प
- स्लाइस रंग
- पावरपॉइंट
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides के साथ .NET में पाई चार्ट बनाना और अनुकूलित करना सीखें, जिन्हें PowerPoint में निर्यात किया जा सकता है, जिससे आपके डेटा कहानी को सेकंड में बढ़ावा मिले।"
---
## **सारांश**

यह लेख Aspose.Slides में पाई चार्ट के साथ काम करने का तरीका समझाता है। यह पाई ऑफ पाई और बार ऑफ पाई चार्ट्स के लिए द्वितीयक प्लॉट विकल्प कैसे कॉन्फ़िगर करें, और मानक पाई चार्ट के लिए स्वतः स्लाइस रंगीकरण कैसे सक्षम करें, यह दिखाता है।

उदाहरण व्यावहारिक चार्ट कस्टमाइज़ेशन चरणों पर केंद्रित हैं, जैसे स्लाइड में चार्ट जोड़ना, श्रृंखला और लेबल सेटिंग्स को समायोजित करना, डिफ़ॉल्ट चार्ट डेटा को कस्टम श्रेणियों और मानों से बदलना, और अपडेटेड प्रस्तुति को सहेजना।

## **पाई ऑफ पाई और बार ऑफ पाई चार्ट्स के दूसरे प्लॉट विकल्प**

Aspose.Slides for .NET अब पाई ऑफ पाई या बार ऑफ पाई चार्ट के लिए द्वितीयक प्लॉट विकल्पों को समर्थन देता है। इस विषय में, हम Aspose.Slides का उपयोग करके इन विकल्पों को निर्दिष्ट करने का उदाहरण देखेंगे। इन प्रॉपर्टीज़ को निर्दिष्ट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. एक नया [प्रेजेंटेशन](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास ऑब्जेक्ट बनाएं।  
2. स्लाइड पर चार्ट जोड़ें।  
3. चार्ट के द्वितीयक प्लॉट विकल्प निर्दिष्ट करें।  
4. प्रस्तुति को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में हमने पाई ऑफ पाई चार्ट की विभिन्न प्रॉपर्टीज़ सेट की हैं।

```c#
// Presentation क्लास का एक इंस्टेंस बनाएं
Presentation presentation = new Presentation();

// स्लाइड पर चार्ट जोड़ें
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// विभिन्न प्रॉपर्टीज़ सेट करें
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// प्रस्तुति को डिस्क पर लिखें
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```

## **स्वचालित पाई चार्ट स्लाइस रंग सेट करें**

Aspose.Slides for .NET पाई चार्ट स्लाइस के स्वचालित रंग सेट करने के लिए एक सरल API प्रदान करता है। नीचे दिया गया नमूना कोड उपरोक्त प्रॉपर्टीज़ को सेट करता है।

1. Presentation क्लास का एक इंस्टेंस बनाएं।  
2. पहले स्लाइड तक पहुंचें।  
3. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।  
4. चार्ट का शीर्षक सेट करें।  
5. पहली श्रृंखला को मान प्रदर्शित करने के लिए सेट करें।  
6. चार्ट डेटा शीट का इंडेक्स सेट करें।  
7. चार्ट डेटा कार्यपत्र प्राप्त करें।  
8. डिफ़ॉल्ट जेनरेट की गई श्रृंखला और श्रेणियों को हटाएँ।  
9. नई श्रेणियाँ जोड़ें।  
10. नई श्रृंखला जोड़ें।

परिवर्तित प्रस्तुति को PPTX फ़ाइल में लिखें।

```c#
// PPTX फ़ाइल को दर्शाने वाली Presentation क्लास का एक इंस्टेंस बनाएं
using (Presentation presentation = new Presentation())
{
	// PPTX फ़ाइल को दर्शाने वाली Presentation क्लास का एक इंस्टेंस बनाएं
	Presentation presentation = new Presentation();

	// पहले स्लाइड तक पहुंचें
	ISlide slides = presentation.Slides[0];

	// डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// चार्ट शीर्षक सेट करना
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// पहली श्रृंखला को मान दिखाने के लिए सेट करें
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// चार्ट डेटा शीट का इंडेक्स सेट करना
	int defaultWorksheetIndex = 0;

	// चार्ट डेटा कार्यपत्र प्राप्त करना
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// डिफ़ॉल्ट जेनरेट की गई श्रृंखलाएँ और श्रेणियाँ हटाएँ
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// नई श्रेणियाँ जोड़ना
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// नई श्रृंखला जोड़ना
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// अब श्रृंखला डेटा भर रहे हैं
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या 'पाई ऑफ पाई' और 'बार ऑफ पाई' वैरिएंट्स समर्थित हैं?**

हाँ, लाइब्रेरी [द्वितीयक प्लॉट](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/charttype/) को पाई चार्ट के लिए समर्थन करती है, जिसमें 'पाई ऑफ पाई' और 'बार ऑफ पाई' प्रकार शामिल हैं।

**क्या मैं केवल चार्ट को इमेज (जैसे PNG) के रूप में एक्सपोर्ट कर सकता हूँ?**

हाँ, आप पूरे प्रस्तुति को बिना एक्सपोर्ट किए केवल [चार्ट को इमेज के रूप में एक्सपोर्ट](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/getimage/) कर सकते हैं।