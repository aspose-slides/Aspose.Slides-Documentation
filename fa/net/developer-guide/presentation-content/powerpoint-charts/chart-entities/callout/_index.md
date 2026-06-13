---
title: مدیریت Calloutها در نمودارهای ارائه در .NET
linktitle: فراخوان
type: docs
url: /fa/net/callout/
keywords:
- فراخوان نمودار
- استفاده از فراخوان
- برچسب داده
- قالب برچسب
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ایجاد و استایل‌دهی به فراخوان‌ها در Aspose.Slides برای .NET با مثال‌های کد مختصر C#، سازگار با PPT و PPTX برای خودکارسازی جریان کارهای ارائه."
---
## **مرور کلی**

این مقاله نحوه کار با Calloutها برای برچسب‌های دادهٔ نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه از ویژگی `ShowLabelAsDataCallout` برای نمایش برچسب‌ها به صورت Callout استفاده شود، چگونه تنظیمات مرتبط با Callout برای یک نمودار دونات پیکربندی شود و اینکه Calloutها و ظاهر آن‌ها هنگام استخراج ارائه‌ها به PDF، HTML5، SVG و فرمت‌های تصویر رستر حفظ می‌شوند.

## **استفاده از Calloutها**
ویژگی جدید **ShowLabelAsDataCallout** به کلاس **DataLabelFormat** و اینترفیس **IDataLabelFormat** اضافه شده است که تعیین می‌کند برچسب دادهٔ نمودار مشخص شده به صورت Callout یا به صورت برچسب داده نمایش داده شود. در مثال زیر Calloutها تنظیم شده‌اند.

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



## **تنظیم Callout برای نمودار دونات**
Aspose.Slides for .NET امکان تنظیم شکل Callout برچسب دادهٔ سری برای یک نمودار دونات را فراهم می‌کند. نمونهٔ کد زیر آورده شده است.

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

## **سوالات متداول**

**آیا Calloutها هنگام تبدیل یک ارائه به PDF، HTML5، SVG یا تصاویر حفظ می‌شوند؟**

بله. Calloutها جزئی از رندر نمودار هستند، بنابراین هنگام استخراج به [PDF](/slides/fa/net/convert-powerpoint-to-pdf/)، [HTML5](/slides/fa/net/export-to-html5/)، [SVG](/slides/fa/net/render-a-slide-as-an-svg-image/) یا [تصاویر رستر](/slides/fa/net/convert-powerpoint-to-png/)، همراه با قالب‌بندی اسلاید حفظ می‌شوند.

**آیا قلم‌های سفارشی در Calloutها کار می‌کنند و آیا ظاهر آن‌ها می‌تواند هنگام استخراج حفظ شود؟**

بله. Aspose.Slides از [جاسازی قلم](/slides/fa/net/embedded-font/) در ارائه پشتیبانی می‌کند و در طول استخراج‌ها مانند [PDF](/slides/fa/net/convert-powerpoint-to-pdf/) کنترل می‌کند که Calloutها در سیستم‌های مختلف یک شکل باقی بمانند.