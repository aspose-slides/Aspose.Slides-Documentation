---
title: ".NET में प्रस्तुति चार्ट में कॉलआउट प्रबंधन करें"
linktitle: "कॉलआउट"
type: docs
url: /hi/net/callout/
keywords:
- "चार्ट कॉलआउट"
- "कॉलआउट उपयोग"
- "डेटा लेबल"
- "लेबल फ़ॉर्मेट"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET में संक्षिप्त C# कोड उदाहरणों के साथ कॉलआउट बनाएं और स्टाइल करें, PPT और PPTX के साथ संगत, जिससे प्रस्तुति वर्कफ़्लो को स्वचालित किया जा सके।"
---
## **सारांश**

यह लेख Aspose.Slides में चार्ट डेटा लेबल के लिए कॉलआउट के साथ काम करने का तरीका समझाता है। यह `ShowLabelAsDataCallout` प्रॉपर्टी का उपयोग करके लेबल को कॉलआउट के रूप में प्रदर्शित करने, डोनट चार्ट के लिए कॉलआउट‑संबंधी लेबल सेटिंग्स को कॉन्फ़िगर करने, और यह नोट करता है कि प्रस्तुतीकरण को PDF, HTML5, SVG, और रास्टर इमेज फ़ॉर्मेट्स में निर्यात करने पर कॉलआउट और उनकी उपस्थिति संरक्षित रहती है।

## **कॉलआउट का उपयोग**
नया प्रॉपर्टी **ShowLabelAsDataCallout** **DataLabelFormat** क्लास और **IDataLabelFormat** इंटरफ़ेस में जोड़ा गया है, जो यह निर्धारित करता है कि निर्दिष्ट चार्ट का डेटा लेबल डेटा कॉलआउट के रूप में प्रदर्शित होगा या डेटा लेबल के रूप में। नीचे दिए गए उदाहरण में, हमने कॉलआउट सेट किए हैं।

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
    chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;
    presentation.Save("DisplayChartLabels_out.pptx", SaveFormat.Pptx);
}
```

## **डोनट चार्ट के लिए कॉलआउट सेट करें**
Aspose.Slides for .NET डोनट चार्ट के लिए सीरीज़ डेटा लेबल कॉलआउट आकार सेट करने का समर्थन प्रदान करता है। नीचे एक नमूना उदाहरण दिया गया है।  

```c#
Presentation pres = new Presentation("testc.pptx");
ISlide slide = pres.Slides[0];
IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 10, 10, 500, 500, false);
IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = false;
int seriesIndex = 0;
while (seriesIndex < 15)
{
	IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.Type);
	series.Explosion = 0;
	series.ParentSeriesGroup.DoughnutHoleSize = (byte)20;
	series.ParentSeriesGroup.FirstSliceAngle = 351;
	seriesIndex++;
}
int categoryIndex = 0;
while (categoryIndex < 15)
{
	chart.ChartData.Categories.Add(workBook.GetCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
	int i = 0;
	while (i < chart.ChartData.Series.Count)
	{
		IChartSeries iCS = chart.ChartData.Series[i];
		IChartDataPoint dataPoint = iCS.DataPoints.AddDataPointForDoughnutSeries(workBook.GetCell(0, categoryIndex + 1, i + 1, 1));
		dataPoint.Format.Fill.FillType = FillType.Solid;
		dataPoint.Format.Line.FillFormat.FillType = FillType.Solid;
		dataPoint.Format.Line.FillFormat.SolidFillColor.Color = Color.White;
		dataPoint.Format.Line.Width = 1;
		dataPoint.Format.Line.Style = LineStyle.Single;
		dataPoint.Format.Line.DashStyle = LineDashStyle.Solid;
		if (i == chart.ChartData.Series.Count - 1)
		{
			IDataLabel lbl = dataPoint.Label;
			lbl.TextFormat.TextBlockFormat.AutofitType = TextAutofitType.Shape;
			lbl.DataLabelFormat.TextFormat.PortionFormat.FontBold = NullableBool.True;
			lbl.DataLabelFormat.TextFormat.PortionFormat.LatinFont = new FontData("DINPro-Bold");
			lbl.DataLabelFormat.TextFormat.PortionFormat.FontHeight = 12;
			lbl.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
			lbl.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.LightGray;
			lbl.DataLabelFormat.Format.Line.FillFormat.SolidFillColor.Color = Color.White;
			lbl.DataLabelFormat.ShowValue = false;
			lbl.DataLabelFormat.ShowCategoryName = true;
			lbl.DataLabelFormat.ShowSeriesName = false;
			//lbl.DataLabelFormat.ShowLabelAsDataCallout = true;
			lbl.DataLabelFormat.ShowLeaderLines = true;
			lbl.DataLabelFormat.ShowLabelAsDataCallout = false;
			chart.ValidateChartLayout();
			lbl.AsILayoutable.X = (float)lbl.AsILayoutable.X + (float)0.5;
			lbl.AsILayoutable.Y = (float)lbl.AsILayoutable.Y + (float)0.5;
		}
		i++;
	}
	categoryIndex++;
}
pres.Save("chart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या प्रस्तुतिकरण को PDF, HTML5, SVG या इमेजेस में परिवर्तित करने पर कॉलआउट संरक्षित रहते हैं?**

हां। कॉलआउट चार्ट रेंडरिंग का हिस्सा हैं, इसलिए जब आप इसे [PDF](/slides/hi/net/convert-powerpoint-to-pdf/), [HTML5](/slides/hi/net/export-to-html5/), [SVG](/slides/hi/net/render-a-slide-as-an-svg-image/), या [raster images](/slides/hi/net/convert-powerpoint-to-png/) में निर्यात करते हैं, तो वे स्लाइड के फ़ॉर्मेटिंग के साथ संरक्षित रहते हैं।

**क्या कस्टम फ़ॉन्ट कॉलआउट में काम करते हैं, और क्या उनका स्वरूप निर्यात पर संरक्षित रह सकता है?**

हां। Aspose.Slides प्रस्तुति में [फ़ॉन्ट एम्बेडिंग](/slides/hi/net/embedded-font/) का समर्थन करता है और निर्यात (जैसे कि [PDF](/slides/hi/net/convert-powerpoint-to-pdf/)) के दौरान फ़ॉन्ट एम्बेडिंग को नियंत्रित करता है, जिससे कॉलआउट विभिन्न सिस्टमों पर समान दिखते हैं।