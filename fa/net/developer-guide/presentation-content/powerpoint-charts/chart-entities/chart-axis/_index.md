---
title: سفارشی‌سازی محورها در نمودارها در ارائه‌های .NET
linktitle: محور نمودار
type: docs
url: /fa/net/chart-axis/
keywords:
- محور نمودار
- محور عمودی
- محور افقی
- سفارشی‌سازی محور
- دستکاری محور
- مدیریت محور
- ویژگی‌های محور
- مقدار حداکثر
- مقدار حداقل
- خط محور
- فرمت تاریخ
- عنوان محور
- موقعیت محور
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کشف کنید چگونه از Aspose.Slides برای .NET برای سفارشی‌سازی محورها در نمودارها در ارائه‌های PowerPoint برای گزارش‌ها و تجسم‌ها استفاده کنید."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه محورها را در نمودارهای Aspose.Slides سفارشی کنید. این مقاله نشان می‌دهد چگونه مقادیر واقعی محورها را دریافت کنید، داده‌ها را بین محورها جابجا کنید، محور عمودی یا افقی را برای نمودارهای خطی مخفی کنید، نوع محور دسته‌بندی را تغییر دهید، فرمت تاریخ برای مقادیر محور دسته‌بندی را تنظیم کنید، عنوان محور را چرخانده، موقعیت محور را تنظیم کنید و برچسب واحد را بر روی محور مقدار نمایش دهید.

## **دریافت مقادیر حداکثر بر محور عمودی در نمودارها**
Aspose.Slides برای .NET به شما امکان می‌دهد مقادیر حداقل و حداکثر را بر روی یک محور عمودی به‌دست آورید. این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. به اسلاید اول دسترسی پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید.
4. مقدار حداکثر واقعی محور را دریافت کنید.
5. مقدار حداقل واقعی محور را دریافت کنید.
6. واحد اصلی واقعی محور را دریافت کنید.
7. واحد فرعی واقعی محور را دریافت کنید.
8. مقیاس واحد اصلی واقعی محور را دریافت کنید.
9. مقیاس واحد فرعی واقعی محور را دریافت کنید.

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// ارائه را ذخیره می‌کند
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **جابه‌جایی داده‌ها بین محورها**
Aspose.Slides به شما امکان می‌دهد به‌سرعت داده‌ها را بین محورها جابجا کنید — داده‌های نمایش‌داده‌شده بر روی محور عمودی (y-axis) به محور افقی (x-axis) منتقل می‌شوند و برعکس.

```c#
	// ایجاد ارائه خالی
	using (Presentation pres = new Presentation())
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

		//سطرها و ستون‌ها را جابجا می‌کند
		chart.ChartData.SwitchRowColumn();
		   
		// ارائه را ذخیره می‌کند
		 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
	 }
```

## **غیرفعال کردن محور عمودی برای نمودارهای خطی**

این کد C# نشان می‌دهد چگونه محور عمودی یک نمودار خطی را مخفی کنید:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **غیرفعال کردن محور افقی برای نمودارهای خطی**

این کد نشان می‌دهد چگونه محور افقی یک نمودار خطی را مخفی کنید:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **تغییر محور دسته‌بندی**

با استفاده از ویژگی **CategoryAxisType** می‌توانید نوع محور دسته‌بندی مورد نظر خود (**date** یا **text**) را مشخص کنید. این کد در C# عملیات را نشان می‌دهد:

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

## **تنظیم فرمت تاریخ برای مقادیر محور دسته‌بندی**
Aspose.Slides برای .NET به شما امکان می‌دهد فرمت تاریخ را برای یک مقدار محور دسته‌بندی تنظیم کنید. این عملیات در کد C# زیر نشان داده شده است:

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

## **تنظیم زاویه چرخش برای عنوان محور نمودار**
Aspose.Slides برای .NET به شما امکان می‌دهد زاویه چرخش عنوان محور یک نمودار را تنظیم کنید. این کد C# این عملیات را نشان می‌دهد:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **تنظیم موقعیت محور در محور دسته‌بندی یا مقدار**
Aspose.Slides برای .NET به شما امکان می‌دهد موقعیت محور را در یک محور دسته‌بندی یا مقدار تنظیم کنید. این کد C# نشان می‌دهد چگونه این کار را انجام دهید:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **فعال‌سازی نمایش برچسب واحد بر روی محور مقدار نمودار**
Aspose.Slides برای .NET به شما امکان می‌دهد یک نمودار را طوری تنظیم کنید که برچسب واحد را بر روی محور مقدار آن نمایش دهد. این کد C# این عملیات را نشان می‌دهد:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **پرسش‌های متداول**

**چگونه مقدار تقاطع یک محور با محور دیگر (axis crossing) را تنظیم کنم؟**

محورها یک [تنظیم تقاطع](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/axis/crosstype/) را ارائه می‌دهند: می‌توانید انتخاب کنید که تقاطع در صفر، در حداکثر دسته/مقدار، یا در یک مقدار عددی خاص باشد. این برای جابجایی محور X به بالا یا پایین یا برای تأکید بر یک خط پایه مفید است.

**چگونه برچسب‌های تیک را نسبت به محور (کنار، خارج، داخل) موقعیت‌گذاری کنم؟**

موقعیت برچسب‌های تیک را نسبت به محور با استفاده از [label position](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/axis/majortickmark/) به «cross»، «outside» یا «inside» تنظیم کنید. این بر خوانایی تأثیر می‌گذارد و به بهینه‌سازی فضا، به‌ویژه در نمودارهای کوچک، کمک می‌کند.