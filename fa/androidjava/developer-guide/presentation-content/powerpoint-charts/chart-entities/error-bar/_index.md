---
title: سفارشی‌سازی نوارهای خطا در نمودارهای ارائه در اندروید
linktitle: نوار خطا
type: docs
url: /fa/androidjava/error-bar/
keywords:
- نوار خطا
- مقدار سفارشی
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "بیاموزید چگونه نوارهای خطا را در نمودارها با Aspose.Slides برای اندروید از طریق جاوا اضافه و سفارشی کنید—تصاویر داده را در ارائه‌های PowerPoint بهینه کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با استفاده از Aspose.Slides با نوارهای خطا در نمودارهای ارائه کار کنید. نشان می‌دهد چگونه نوارهای خطا را به یک سری نمودار اضافه کنید، تنظیمات نوارهای خطای X و Y را پیکربندی کنید، و انواع مختلف مقدار مانند ثابت، درصدی و مقادیر سفارشی را اعمال کنید.

همچنین نشان می‌دهد چگونه مقادیر سفارشی نوار خطا را برای نقاط دادهٔ فردی در یک سری با استفاده از مجموعه نقاط دادهٔ مربوطه اختصاص دهید. علاوه بر این، مقاله نکات مختصری دربارهٔ رفتار نوارهای خطا در هنگام خروجی، سازگاری آنها با مارکرها و برچسب‌های داده، و محل یافتن کلاس‌ها و شمارشی‌های مرتبط در مرجع API ارائه می‌دهد.

## **افزودن نوارهای خطا**
Aspose.Slides for Android via Java یک API ساده برای مدیریت مقادیر نوار خطا فراهم می‌کند. کد نمونه زمانی اعمال می‌شود که از نوع مقدار سفارشی استفاده شود. برای تعیین مقدار، از ویژگی **ErrorBarCustomValues** یک نقطه دادهٔ خاص در مجموعهٔ [**DataPoints**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartSeriesCollection) سری استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
1. یک نمودار حبابی در اسلاید مورد نظر اضافه کنید.
1. سری نمودار اول را دسترسی پیدا کنید و قالب نوار خطای X را تنظیم کنید.
1. سری نمودار اول را دسترسی پیدا کنید و قالب نوار خطای Y را تنظیم کنید.
1. مقادیر و قالب نوارها را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به یک فایل PPTX بنویسید.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    // ایجاد یک نمودار حبابی
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // اضافه‌کردن نوارهای خطا و تنظیم قالب آن
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // ذخیرهٔ ارائه
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **افزودن مقادیر سفارشی نوار خطا**
Aspose.Slides for Android via Java یک API ساده برای مدیریت مقادیر سفارشی نوار خطا فراهم می‌کند. کد نمونه زمانی اعمال می‌شود که ویژگی [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) برابر با **Custom** باشد. برای تعیین مقدار، از ویژگی **ErrorBarCustomValues** یک نقطه دادهٔ خاص در مجموعهٔ [**DataPoints**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartSeriesCollection) سری استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
1. یک نمودار حبابی در اسلاید مورد نظر اضافه کنید.
1. سری نمودار اول را دسترسی پیدا کنید و قالب نوار خطای X را تنظیم کنید.
1. سری نمودار اول را دسترسی پیدا کنید و قالب نوار خطای Y را تنظیم کنید.
1. به نقاط دادهٔ فردی سری نمودار دسترسی پیدا کنید و مقادیر نوار خطا را برای هر نقطه دادهٔ سری به‌صورت جداگانه تنظیم کنید.
1. مقادیر و قالب نوارها را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به یک فایل PPTX بنویسید.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    // ایجاد یک نمودار حبابی
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // اضافه‌کردن نوارهای خطای سفارشی و تنظیم قالب آن
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // دسترسی به نقطه دادهٔ سری نمودار و تنظیم مقادیر نوارهای خطا برای
    // نقطهٔ فردی
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // تنظیم نوارهای خطا برای نقاط سری نمودار
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // ذخیرهٔ ارائه
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌وپاسخ**

**چه اتفاقی برای نوارهای خطا می‌افتد هنگام خروجی ارائه به PDF یا تصویرها؟**

آنها به‌عنوان بخشی از نمودار رندر می‌شوند و در حین تبدیل همراه با بقیه قالب‌بندی نمودار حفظ می‌شوند، به شرط اینکه نسخه یا رندرر سازگار باشد.

**آیا نوارهای خطا می‌توانند با مارکرها و برچسب‌های داده ترکیب شوند؟**

بله. نوارهای خطا عنصر جداگانه‌ای هستند و با مارکرها و برچسب‌های داده سازگارند؛ اگر عناصر همپوشانی داشته باشند، ممکن است نیاز به تنظیم قالب‌بندی داشته باشید.

**کجا می‌توانم فهرست ویژگی‌ها و کلاس‌های مربوط به کار با نوارهای خطا در API را پیدا کنم؟**

در مرجع API: کلاس [ErrorBarsFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/errorbarsformat/) و کلاس‌های مرتبط [ErrorBarType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/errorbartype/) و [ErrorBarValueType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/errorbarvaluetype/).