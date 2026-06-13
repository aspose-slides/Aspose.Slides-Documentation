---
title: سفارشی‌سازی نوارهای خطا در نمودارهای ارائه با استفاده از Java
linktitle: نوار خطا
type: docs
url: /fa/java/error-bar/
keywords:
- نوار خطا
- مقدار سفارشی
- پاورپوینت
- ارائه
- Java
- Aspose.Slides
description: "بیاموزید چگونه نوارهای خطا را در نمودارها با Aspose.Slides برای Java اضافه و سفارشی کنید—نمایش‌های داده‌ای در ارائه‌های پاورپوینت را بهینه کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه با استفاده از Aspose.Slides در نمودارهای ارائه با نوارهای خطا کار کنیم. این مقاله نشان می‌دهد چگونه نوارهای خطا را به یک سری نمودار اضافه کنید، تنظیمات نوارهای خطای X و Y را پیکربندی کنید، و انواع مقدار مختلف مانند ثابت، درصدی و مقدار سفارشی را اعمال کنید.

همچنین نحوه اختصاص مقادیر سفارشی نوار خطا به نقاط دادهٔ فردی در یک سری را با استفاده از مجموعهٔ نقاط دادهٔ متناظر نشان می‌دهد. علاوه بر این، مقاله شامل نکات کوتاهی دربارهٔ رفتار نوارهای خطا هنگام خروجی‌گیری، سازگاری آن‌ها با مارکرها و برچسب‌های داده، و محل یافتن کلاس‌ها و enumهای مرتبط در مرجع API است.

## **افزودن نوارهای خطا**
Aspose.Slides for Java یک API ساده برای مدیریت مقادیر نوار خطا فراهم می‌کند. کد نمونه زمانی اعمال می‌شود که از نوع مقدار سفارشی استفاده شود. برای تعیین مقدار، از خصوصیت **ErrorBarCustomValues** یک نقطه داده خاص در مجموعه [**DataPoints**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartSeriesCollection) سری استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
1. یک نمودار حبابی در اسلاید موردنظر اضافه کنید.
1. سری اول نمودار را دسترسی پیدا کنید و قالب نوار خطای X را تنظیم کنید.
1. سری اول نمودار را دسترسی پیدا کنید و قالب نوار خطای Y را تنظیم کنید.
1. مقادیر و قالب نوارها را تنظیم کنید.
1. ارائه تغییر یافته را در یک فایل PPTX بنویسید.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    // ایجاد نمودار حبابی
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // افزودن نوارهای خطا و تنظیم قالب آن
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
Aspose.Slides for Java یک API ساده برای مدیریت مقادیر سفارشی نوار خطا فراهم می‌کند. کد نمونه زمانی اعمال می‌شود که خصوصیت [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IErrorBarsFormat#getValue--) برابر با **Custom** باشد. برای تعیین مقدار، از خصوصیت **ErrorBarCustomValues** یک نقطه داده خاص در مجموعه [**DataPoints**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartSeriesCollection) سری استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
1. یک نمودار حبابی در اسلاید موردنظر اضافه کنید.
1. سری اول نمودار را دسترسی پیدا کنید و قالب نوار خطای X را تنظیم کنید.
1. سری اول نمودار را دسترسی پیدا کنید و قالب نوار خطای Y را تنظیم کنید.
1. نقاط دادهٔ فردی سری نمودار را دسترسی پیدا کنید و مقادیر نوار خطا را برای نقطه دادهٔ فردی سری تنظیم کنید.
1. مقادیر و قالب نوارها را تنظیم کنید.
1. ارائه تغییر یافته را در یک فایل PPTX بنویسید.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    // ایجاد نمودار حبابی
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // افزودن نوارهای خطای سفارشی و تنظیم قالب آن
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

## **سوالات متداول**

**در هنگام صادرات ارائه به PDF یا تصویر، چه اتفاقی برای نوارهای خطا می‌افتد؟**

آن‌ها به عنوان بخشی از نمودار رندر می‌شوند و در زمان تبدیل به همراه بقیه قالب‌بندی نمودار نگهداری می‌شوند، به شرطی که نسخه یا رندرر سازگار باشد.

**آیا نوارهای خطا می‌توانند با مارکرها و برچسب‌های داده ترکیب شوند؟**

بله. نوارهای خطا یک عنصر جداگانه هستند و با مارکرها و برچسب‌های داده سازگارند؛ اگر عناصر روی هم قرار گیرند، ممکن است نیاز به تنظیم قالب‌بندی داشته باشید.

**در کجا می‌توانم فهرست خصوصیات و کلاس‌های مربوط به کار با نوارهای خطا در API را پیدا کنم؟**

در مرجع API: کلاس [ErrorBarsFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/errorbarsformat/) و کلاس‌های مرتبط [ErrorBarType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/errorbartype/) و [ErrorBarValueType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/errorbarvaluetype/).