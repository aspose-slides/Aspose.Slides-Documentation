---
title: سفارشی‌سازی نوارهای خطا در نمودارهای ارائه با استفاده از جاوااسکریپت
linktitle: نوار خطا
type: docs
url: /fa/nodejs-java/error-bar/
keywords:
- نوار خطا
- مقدار سفارشی
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه نوارهای خطا را در نمودارها با استفاده از جاوااسکریپت و Aspose.Slides برای Node.js از طریق Java اضافه و سفارشی کنید — با بهینه‌سازی نمایش داده‌ها در ارائه‌های PowerPoint."
---
## **نمایش کلی**

این مقاله توضیح می‌دهد که چگونه با استفاده از Aspose.Slides می‌توان با نوارهای خطا در نمودارهای ارائه کار کرد. این مقاله نشان می‌دهد چگونه نوارهای خطا را به یک سری نمودار اضافه کرد، تنظیمات نوار خطای X و Y را پیکربندی کرد و انواع مقادیر مختلف مانند ثابت، درصدی و مقادیر سفارشی را اعمال کرد. همچنین نشان می‌دهد چگونه می‌توان مقادیر سفارشی نوار خطا را برای نقاط دادهٔ فردی در یک سری با استفاده از مجموعهٔ نقاط دادهٔ مربوطه اختصاص داد. علاوه بر این، مقاله نکات مختصری در مورد رفتار نوارهای خطا هنگام صادر کردن، سازگاری آن‌ها با نشانگرها و برچسب‌های داده، و مکان پیدا کردن کلاس‌ها و شمارش‌گرهای (enums) مرتبط در مرجع API را شامل می‌شود.

## **افزودن نوار خطا**

Aspose.Slides برای Node.js از طریق Java یک API ساده برای مدیریت مقادیر نوار خطا فراهم می‌کند. کد نمونه زمانی اعمال می‌شود که از نوع مقدار سفارشی استفاده شود. برای تعیین مقدار، از خصوصیت **ErrorBarCustomValues** یک نقطه دادهٔ خاص در مجموعهٔ [**DataPoints**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartSeriesCollection) سری استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
1. یک نمودار حبابی را در اسلاید موردنظر اضافه کنید.
1. سری اول نمودار را دسترسی پیدا کنید و قالب نوار خطای X را تنظیم کنید.
1. سری اول نمودار را دسترسی پیدا کنید و قالب نوار خطای Y را تنظیم کنید.
1. تنظیم مقادیر نوارها و قالب.
1. ارائهٔ تغییر یافته را در یک فایل PPTX بنویسید.

```javascript
// یک نمونه از کلاس Presentation ایجاد کنید
var pres = new aspose.slides.Presentation();
try {
    // ساختن یک نمودار حبابی
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // افزودن نوارهای خطا و تنظیم قالب آن
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0);
    errBarX.hasEndCap();
    // ذخیرهٔ ارائه
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **افزودن مقدار نوار خطای سفارشی**

Aspose.Slides برای Node.js از طریق Java یک API ساده برای مدیریت مقادیر سفارشی نوار خطا فراهم می‌کند. کد نمونه زمانی اعمال می‌شود که خصوصیت [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) برابر **Custom** باشد. برای تعیین مقدار، از خصوصیت **ErrorBarCustomValues** یک نقطه دادهٔ خاص در مجموعهٔ [**DataPoints**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartSeriesCollection) سری استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
1. یک نمودار حبابی را در اسلاید موردنظر اضافه کنید.
1. سری اول نمودار را دسترسی پیدا کنید و قالب نوار خطای X را تنظیم کنید.
1. سری اول نمودار را دسترسی پیدا کنید و قالب نوار خطای Y را تنظیم کنید.
1. نقاط دادهٔ فردی سری نمودار را دسترسی پیدا کنید و مقادیر نوار خطا را برای نقطه دادهٔ فردی سری تنظیم کنید.
1. تنظیم مقادیر نوارها و قالب.
1. ارائهٔ تغییر یافته را در یک فایل PPTX بنویسید.

```javascript
// یک نمونه از کلاس Presentation ایجاد کنید
var pres = new aspose.slides.Presentation();
try {
    // ساختن یک نمودار حبابی
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // افزودن نوارهای خطای سفارشی و تنظیم قالب آن
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // دسترسی به نقطه دادهٔ سری نمودار و تنظیم مقادیر نوارهای خطا برای
    // نقطهٔ منفرد
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // تنظیم نوارهای خطا برای نقاط سری نمودار
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // ذخیرهٔ ارائه
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**هنگام صادر کردن یک ارائه به PDF یا تصاویر، چه اتفاقی برای نوارهای خطا می‌افتد؟**

آن‌ها به‌عنوان بخشی از نمودار رندر می‌شوند و در هنگام تبدیل، به همراه بقیه قالب‌بندی‌های نمودار حفظ می‌گردند، به شرطی که نسخه یا رندرر سازگاری موجود باشد.

**آیا نوارهای خطا می‌توانند با نشانگرها و برچسب‌های داده ترکیب شوند؟**

بله. نوارهای خطا یک عنصر جداگانه هستند و با نشانگرها و برچسب‌های داده سازگاری دارند؛ اگر عناصر هم‌پوشانی داشته باشند، ممکن است نیاز به تنظیم قالب‌بندی داشته باشید.

**کجا می‌توانم فهرست خصوصیات و شمارش‌گرهای (enums) مربوط به کار با نوارهای خطا در API را پیدا کنم؟**

در مستندات API: کلاس [ErrorBarsFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/errorbarsformat/) و شمارش‌گرهای مرتبط [ErrorBarType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/errorbartype/) و [ErrorBarValueType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/errorbarvaluetype/).