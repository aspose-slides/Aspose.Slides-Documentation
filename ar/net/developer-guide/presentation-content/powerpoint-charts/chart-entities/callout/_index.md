---
title: ملاحظة توضيحية
type: docs
url: /ar/net/callout/
keywords: "ملاحظة توضيحية للمخطط, تسمية بيانات المخطط, C#, Csharp, Aspose.Slides for .NET"
description: "ملاحظات توضيحية للمخططات وتسمية البيانات في PowerPoint باستخدام C# أو .NET"
---

## **استخدام الملاحظات التوضيحية**
تمت إضافة الخاصية الجديدة **ShowLabelAsDataCallout** إلى الفئة **DataLabelFormat** والواجهة **IDataLabelFormat**، والتي تحدد ما إذا كان سيتم عرض تسمية البيانات للمخطط المحدد كملاحظة توضيحية أو كتسمية بيانات. في المثال المذكور أدناه، قمنا بتعيين الملاحظات التوضيحية.
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


## **تعيين ملاحظة توضيحية لمخطط الدونات**
توفر Aspose.Slides for .NET دعمًا لتعيين شكل ملاحظة توضيحية لتسمية بيانات السلسلة لمخطط الدونات. يُعطى المثال التالي.
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


## **الأسئلة المتكررة**

**هل يتم الحفاظ على الملاحظات التوضيحية عند تحويل العرض التقديمي إلى PDF أو HTML5 أو SVG أو صور؟**

نعم. الملاحظات التوضيحية هي جزء من عرض المخطط، لذلك عند تصدير إلى [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، [HTML5](/slides/ar/net/export-to-html5/)، [SVG](/slides/ar/net/render-a-slide-as-an-svg-image/)، أو [raster images](/slides/ar/net/convert-powerpoint-to-png/)، يتم الحفاظ عليها مع تنسيق الشريحة.

**هل تعمل الخطوط المخصصة في الملاحظات التوضيحية، وهل يمكن الحفاظ على مظهرها عند التصدير؟**

نعم. تدعم Aspose.Slides [embedding fonts](/slides/ar/net/embedded-font/) في العرض وتتحكم في تضمين الخطوط أثناء التصدير مثل [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، مما يضمن أن تبدو الملاحظات التوضيحية نفسها عبر الأنظمة المختلفة.