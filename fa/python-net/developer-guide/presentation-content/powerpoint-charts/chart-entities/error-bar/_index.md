---
title: سفارشی‌سازی میله‌های خطا در نمودارهای ارائه با پایتون
linktitle: میله خطا
type: docs
url: /fa/python-net/error-bar/
keywords:
- میله خطا
- مقدار سفارشی
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه میله‌های خطا را در نمودارها با Aspose.Slides برای پایتون از طریق .NET اضافه و سفارشی کنید—نمایش‌های داده‌ای را در ارائه‌های PowerPoint و OpenDocument بهینه کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با استفاده از Aspose.Slides می‌توان با میله‌های خطا در نمودارهای ارائه کار کرد. این مقاله نشان می‌دهد چگونه میله‌های خطا را به یک سری نمودار اضافه کنید، تنظیمات میله‌های خطای X و Y را پیکربندی کنید و انواع مقادیر مختلف مانند ثابت، درصدی و مقادیر سفارشی را اعمال کنید.

همچنین نحوه اختصاص مقادیر سفارشی میله‌خطا برای نقاط دادهٔ فردی در یک سری را با استفاده از مجموعهٔ نقاط دادهٔ مربوطه نشان می‌دهد. علاوه بر این، مقاله نکات مختصری دربارهٔ رفتار میله‌های خطا هنگام خروجی‌گیری، سازگاری آن‌ها با نشانگرها و برچسب‌های داده و مکان یافتن کلاس‌ها و شمارنده‌های (enums) مرتبط در مستندات API ارائه می‌دهد.

## **افزودن میله خطا**
Aspose.Slides for Python via .NET یک API ساده برای مدیریت مقادیر میله خطا فراهم می‌کند. کد نمونه زمانی اعمال می‌شود که از نوع مقدار سفارشی استفاده شود. برای تعیین یک مقدار، از ویژگی **ErrorBarCustomValues** یک نقطهٔ دادهٔ خاص در مجموعهٔ **DataPoints** یک سری استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک نمودار حبابی روی اسلاید مورد نظر اضافه کنید.
1. دسترسی به اولین سری نمودار و تنظیم فرمت میله خطای X.
1. دسترسی به اولین سری نمودار و تنظیم فرمت میله خطای Y.
1. تنظیم مقادیر میله‌ها و فرمت آن‌ها.
1. ارائه اصلاح‌شده را در یک فایل PPTX بنویسید.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# ایجاد ارائه خالی
with slides.Presentation() as presentation:
    # ایجاد یک نمودار حبابی
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # افزودن میله‌های خطا و تنظیم قالب آن‌ها
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # ذخیره ارائه
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **افزودن مقدار سفارشی میله خطا**
Aspose.Slides for Python via .NET یک API ساده برای مدیریت مقادیر سفارشی میله خطا فراهم می‌کند. کد نمونه زمانی اعمال می‌شود که ویژگی **IErrorBarsFormat.ValueType** برابر با **Custom** باشد. برای تعیین یک مقدار، از ویژگی **ErrorBarCustomValues** یک نقطهٔ دادهٔ خاص در مجموعهٔ **DataPoints** یک سری استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک نمودار حبابی روی اسلاید مورد نظر اضافه کنید.
1. دسترسی به اولین سری نمودار و تنظیم فرمت میله خطای X.
1. دسترسی به اولین سری نمودار و تنظیم فرمت میله خطای Y.
1. به نقاط دادهٔ فردی سری نمودار دسترسی پیدا کنید و مقادیر میله خطا را برای هر نقطهٔ دادهٔ سری تنظیم کنید.
1. تنظیم مقادیر میله‌ها و فرمت آن‌ها.
1. ارائه اصلاح‌شده را در یک فایل PPTX بنویسید.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# ایجاد ارائه خالی
with slides.Presentation() as presentation:
    # ایجاد یک نمودار حبابی
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # افزودن میله‌های خطای سفارشی و تنظیم قالب آن
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # دسترسی به نقطه دادهٔ سری نمودار و تنظیم مقادیر میله‌های خطا برای نقطهٔ فردی
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # تنظیم میله‌های خطا برای نقاط سری نمودار
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # ذخیره ارائه
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**در هنگام خروجی‌گیری یک ارائه به PDF یا تصاویر، چه اتفاقی برای میله‌های خطا می‌افتد؟**

آن‌ها به عنوان بخشی از نمودار رندر می‌شوند و در طول تبدیل همراه با بقیهٔ قالب‌بندی نمودار حفظ می‌گردند، به شرطی که نسخه یا رندرری سازگار باشد.

**آیا میله‌های خطا می‌توانند با نشانگرها و برچسب‌های داده ترکیب شوند؟**

بله. میله‌های خطا عنصر جداگانه‌ای هستند و با نشانگرها و برچسب‌های داده سازگارند؛ اگر عناصر روی هم رفته باشند، ممکن است نیاز به تنظیم قالب‌بندی داشته باشید.

**کجا می‌توانم فهرست ویژگی‌ها و شمارنده‌های (enums) مربوط به کار با میله‌های خطا در API را پیدا کنم؟**

در مراجع API: کلاس [ErrorBarsFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/errorbarsformat/) و شمارنده‌های مرتبط [ErrorBarType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/errorbartype/) و [ErrorBarValueType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/errorbarvaluetype/).