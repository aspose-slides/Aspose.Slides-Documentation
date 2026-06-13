---
title: .NET में प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करें
linktitle: चार्ट अक्ष
type: docs
url: /hi/net/chart-axis/
keywords:
- चार्ट अक्ष
- ऊर्ध्वाधर अक्ष
- क्षैतिज अक्ष
- अक्ष को अनुकूलित करें
- अक्ष को संशोधित करें
- अक्ष को प्रबंधित करें
- अक्ष गुण
- अधिकतम मान
- न्यूनतम मान
- अक्ष रेखा
- तिथि स्वरूप
- अक्ष शीर्षक
- अक्ष स्थिति
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "रिपोर्ट और विज़ुअलाइज़ेशन के लिए PowerPoint प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करने हेतु .NET के लिए Aspose.Slides का उपयोग कैसे करें, जानें।"
---
## **समीक्षा**

यह लेख Aspose.Slides में चार्ट की अक्षों को अनुकूलित करने के तरीकों को समझाता है। यह वास्तविक अक्ष मान प्राप्त करने, अक्षों के बीच डेटा स्वैप करने, रेखा चार्ट के लिए ऊर्ध्वाधर या क्षैतिज अक्ष को छिपाने, श्रेणी अक्ष के प्रकार को बदलने, श्रेणी अक्ष मानों के लिए तिथि स्वरूप सेट करने, अक्ष शीर्षक को घुमाने, अक्ष की स्थिति निर्धारित करने, और मान अक्ष पर इकाई लेबल प्रदर्शित करने को दर्शाता है।

## **चार्ट में ऊर्ध्वाधर अक्ष के अधिकतम मान प्राप्त करें**
Aspose.Slides for .NET आपको ऊर्ध्वाधर अक्ष पर न्यूनतम और अधिकतम मान प्राप्त करने की अनुमति देता है। इन चरणों का पालन करें:

1.  [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
1. पहला स्लाइड एक्सेस करें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
1. अक्ष पर वास्तविक अधिकतम मान प्राप्त करें।
1. अक्ष पर वास्तविक न्यूनतम मान प्राप्त करें।
1. अक्ष की वास्तविक प्रमुख इकाई प्राप्त करें।
1. अक्ष की वास्तविक उप-इकाई प्राप्त करें।
1. अक्ष का वास्तविक प्रमुख इकाई स्केल प्राप्त करें।
1. अक्ष का वास्तविक उप-इकाई स्केल प्राप्त करें।

ऊपर वर्णित चरणों की कार्यान्वयन वाला नमूना कोड आपको C# में आवश्यक मान प्राप्त करने का तरीका दिखाता है:

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// प्रस्तुति को सहेजता है
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **अक्षों के बीच डेटा स्वैप करें**
Aspose.Slides आपको जल्दी से अक्षों के बीच डेटा स्वैप करने की सुविधा देता है—ऊर्ध्वाधर अक्ष (y‑axis) पर दिखाया गया डेटा क्षैतिज अक्ष (x‑axis) में चला जाता है और इसके विपरीत।

चार्ट में अक्षों के बीच डेटा स्वैप कार्य को करने के लिए यह C# कोड है:

```c#
// खाली प्रस्तुति बनाता है
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//पंक्तियों और स्तंभों की अदला-बदली करता है
	chart.ChartData.SwitchRowColumn();
		   
	 // प्रस्तुति सहेजता है
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **रेखा चार्ट के लिए ऊर्ध्वाधर अक्ष को अक्षम करें**

रेखा चार्ट के लिए ऊर्ध्वाधर अक्ष को छिपाने के लिए यह C# कोड है:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **रेखा चार्ट के लिए क्षैतिज अक्ष को अक्षम करें**

यह कोड दिखाता है कि रेखा चार्ट के लिए क्षैतिज अक्ष को कैसे छिपाया जाए:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **श्रेणी अक्ष बदलें**

**CategoryAxisType** प्रॉपर्टी का उपयोग करके आप अपना पसंदीदा श्रेणी अक्ष प्रकार (**date** या **text**) निर्दिष्ट कर सकते हैं। यह C# कोड इस संचालन को दर्शाता है:

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```

## **श्रेणी अक्ष मानों के लिए तिथि स्वरूप सेट करें**
Aspose.Slides for .NET आपको श्रेणी अक्ष मान के लिए तिथि स्वरूप सेट करने की सुविधा देता है। यह C# कोड इस संचालन को प्रदर्शित करता है:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50, 50, 450, 300);

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Add(wb.GetCell(0, "A2", new DateTime(2015, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A3", new DateTime(2016, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A4", new DateTime(2017, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A5", new DateTime(2018, 1, 1).ToOADate()));

	IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 1));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 2));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 3));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 4));
	chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
	chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
	chart.Axes.HorizontalAxis.NumberFormat = "yyyy";
	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **चार्ट अक्ष शीर्षक के लिए घूर्णन कोण सेट करें**
Aspose.Slides for .NET आपको चार्ट अक्ष शीर्षक के लिए घूर्णन कोण सेट करने की अनुमति देता है। यह C# कोड इस संचालन को दर्शाता है:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **श्रेणी या मान अक्ष पर अक्ष की स्थिति सेट करें**
Aspose.Slides for .NET आपको श्रेणी या मान अक्ष में अक्ष की स्थिति सेट करने की सुविधा देता है। यह C# कोड इस कार्य को करने का तरीका दिखाता है:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **चार्ट मान अक्ष पर इकाई लेबल प्रदर्शित करना सक्षम करें**
Aspose.Slides for .NET आपको चार्ट के मान अक्ष पर इकाई लेबल दिखाने के लिए कॉन्फ़िगर करने की अनुमति देता है। यह C# कोड इस संचालन को प्रदर्शित करता है:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**मैं अक्ष के वह बिंदु जहाँ एक अक्ष दूसरे को काटता है (axis crossing) को कैसे सेट करूं?**

अक्ष एक [crossing setting](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/axis/crosstype/) प्रदान करता है: आप इसे शून्य पर, अधिकतम श्रेणी/मान पर, या किसी विशिष्ट संख्यात्मक मान पर सेट कर सकते हैं। यह X‑axis को ऊपर या नीचे शिफ्ट करने या बेसलाइन को उजागर करने में सहायक होता है।

**मैं टिक लेबल को अक्ष के सापेक्ष (साथ में, बाहर, अंदर) कैसे स्थित करूँ?**

[label position](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/axis/majortickmark/) को "cross", "outside", या "inside" पर सेट करें। यह पठनीयता को प्रभावित करता है और छोटे चार्ट में स्थान बचाने में मदद करता है।