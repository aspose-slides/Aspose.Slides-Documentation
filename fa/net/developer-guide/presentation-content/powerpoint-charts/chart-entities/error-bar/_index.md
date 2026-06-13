---
title: "سفارشی‌سازی نوارهای خطا در نمودارهای ارائه‌ای در .NET"
linktitle: "نوار خطا"
type: docs
url: /fa/net/error-bar/
keywords:
- "نوار خطا"
- "مقدار سفارشی"
- "پاورپوینت"
- "ارائه"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "یاد بگیرید چگونه نوارهای خطا را در نمودارها با Aspose.Slides برای .NET اضافه و سفارشی کنید—تصاویر داده‌ای را در ارائه‌های PowerPoint بهینه‌سازی کنید."
---
## **بررسی کلی**

این مقاله نحوه کار با نوارهای خطا در نمودارهای ارائه‌ای را با استفاده از Aspose.Slides توضیح می‌دهد. نشان می‌دهد چگونه نوارهای خطا را به یک سری نمودار اضافه کنید، تنظیمات نوار خطای X و Y را پیکربندی کنید و انواع مقدار مختلفی مانند مقدار ثابت، درصدی و سفارشی را اعمال کنید.

همچنین نشان می‌دهد چگونه مقادیر سفارشی نوار خطا را برای نقاط دادهٔ فردی در یک سری با استفاده از مجموعهٔ نقاط داده مربوطه اختصاص دهید. علاوه بر این، مقاله نکات مختصری دربارهٔ رفتار نوارهای خطا هنگام صادر کردن، سازگاری آن‌ها با نشانگرها و برچسب‌های داده، و مکان یافتن کلاس‌ها و شمارشگرهای مرتبط در مرجع API ارائه می‌کند.

## **افزودن نوارهای خطا**
Aspose.Slides for .NET یک API ساده برای مدیریت مقادیر نوارهای خطا فراهم می‌کند. کد نمونه زمانی اعمال می‌شود که از نوع مقدار سفارشی استفاده می‌شود. برای مشخص کردن مقدار، از ویژگی **ErrorBarCustomValues** یک نقطهٔ دادهٔ خاص در مجموعهٔ **DataPoints** یک سری استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. یک نمودار حبابی به اسلاید دلخواه اضافه کنید.
1. به سری اول نمودار دسترسی پیدا کنید و قالب نوار خطای X را تنظیم کنید.
1. به سری اول نمودار دسترسی پیدا کنید و قالب نوار خطای Y را تنظیم کنید.
1. مقادیر نوارها و قالب را تنظیم کنید.
1. ارائهٔ تغییر یافته را در یک فایل PPTX بنویسید.

```c#
 // ایجاد ارائه خالی
 using (Presentation presentation = new Presentation())
 {
     // ایجاد نمودار حبابی
     IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

     // افزودن نوارهای خطا و تنظیم قالب آن
     IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
     IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
     errBarX.IsVisible = true;
     errBarY.IsVisible = true;
     errBarX.ValueType = ErrorBarValueType.Fixed;
     errBarX.Value = 0.1f;
     errBarY.ValueType = ErrorBarValueType.Percentage;
     errBarY.Value = 5;
     errBarX.Type = ErrorBarType.Plus;
     errBarY.Format.Line.Width = 2;
     errBarX.HasEndCap = true;

     // ذخیرهٔ ارائه
     presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
 }
```

## **افزودن مقادیر سفارشی نوار خطا**
Aspose.Slides for .NET یک API ساده برای مدیریت مقادیر سفارشی نوارهای خطا فراهم می‌کند. کد نمونه زمانی اعمال می‌شود که ویژگی **IErrorBarsFormat.ValueType** برابر با **Custom** باشد. برای مشخص کردن مقدار، از ویژگی **ErrorBarCustomValues** یک نقطهٔ دادهٔ خاص در مجموعهٔ **DataPoints** یک سری استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. یک نمودار حبابی به اسلاید دلخواه اضافه کنید.
1. به سری اول نمودار دسترسی پیدا کنید و قالب نوار خطای X را تنظیم کنید.
1. به سری اول نمودار دسترسی پیدا کنید و قالب نوار خطای Y را تنظیم کنید.
1. به نقاط دادهٔ فردی سری نمودار دسترسی پیدا کنید و مقادیر نوار خطا را برای هر نقطهٔ دادهٔ سری تنظیم کنید.
1. مقادیر نوارها و قالب را تنظیم کنید.
1. ارائهٔ تغییر یافته را در یک فایل PPTX بنویسید.

```c#
 // ایجاد ارائه خالی
using (Presentation presentation = new Presentation())
{
    // ایجاد نمودار حبابی
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // افزودن نوارهای خطای سفارشی و تنظیم قالب آن
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // دسترسی به نقطه دادهٔ سری نمودار و تنظیم مقادیر نوارهای خطا برای نقطهٔ فردی
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // تنظیم نوارهای خطا برای نقاط سری نمودار
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // ذخیرهٔ ارائه
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```

## **سؤال‌های متداول**

**در هنگام صادر کردن ارائه به PDF یا تصویر، نوارهای خطا چه می‌شوند؟**

آن‌ها به‌عنوان بخشی از نمودار رندر می‌شوند و همراه با بقیهٔ قالب‌بندی نمودار در زمان تبدیل حفظ می‌شوند، به شرطی که نسخه یا رندر‌کننده‌ی سازگاری داشته باشد.

**آیا نوارهای خطا می‌توانند با نشانگرها و برچسب‌های داده ترکیب شوند؟**

بله. نوارهای خطا عنصر جداگانه‌ای هستند و با نشانگرها و برچسب‌های داده سازگارند؛ اگر عناصر همپوشانی داشته باشند ممکن است نیاز به تنظیم قالب‌بندی داشته باشید.

**فهرست ویژگی‌ها و شمارشگرهای مربوط به کار با نوارهای خطا در API را می‌توان در کجا یافت؟**

در مرجع API: کلاس [ErrorBarsFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/errorbarsformat/) و شمارشگرهای مرتبط [ErrorBarType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/errorbartype/) و [ErrorBarValueType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/errorbarvaluetype/).