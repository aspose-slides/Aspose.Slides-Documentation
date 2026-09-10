---
title: سفارشی‌سازی نوارهای خطا در نمودارهای ارائه با استفاده از پایتون
linktitle: نوار خطا
type: docs
url: /fa/python-java/error-bar/
keywords:
- نوار خطا
- مقدار سفارشی
- پاورپوینت
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "نحوه افزودن و سفارشی‌سازی نوارهای خطا در نمودارها با Aspose.Slides برای پایتون از طریق جاوا را بیاموزید—چند بعدی‌سازی داده‌ها را در ارائه‌های پاورپوینت بهینه کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با استفاده از Aspose.Slides با نوارهای خطا در نمودارهای ارائه کار کنیم. نشان می‌دهد چگونه نوارهای خطا را به یک سری نمودار اضافه کرده، تنظیمات نوارهای خطا X و Y را پیکربندی کرده و انواع متفاوت مقدار مانند ثابت، درصدی و سفارشی را اعمال کنیم.

همچنین نمایش می‌دهد چطور می‌توان مقادیر سفارشی نوار خطا را برای نقاط دادهٔ منفرد در یک سری با استفاده از مجموعهٔ نقاط دادهٔ مربوطه اختصاص داد. علاوه بر این، مقاله نکات مختصری دربارهٔ رفتار نوارهای خطا هنگام خروجی‌گیری، سازگاری آن‌ها با نشانگرها و برچسب‌های داده و مکان یافتن کلاس‌ها و enumهای مرتبط در API ارائه می‌دهد.

## **افزودن نوارهای خطا**

Aspose.Slides for Python via Java یک API ساده برای مدیریت مقادیر نوارهای خطا فراهم می‌کند. کد نمونهٔ زیر از انواع مقدار ثابت و درصدی استفاده می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک نمودار حبابی به اسلاید موردنظر اضافه کنید.
1. به اولین سری نمودار دسترسی پیدا کنید و قالب نوار خطای X را تنظیم کنید.
1. به اولین سری نمودار دسترسی پیدا کنید و قالب نوار خطای Y را تنظیم کنید.
1. مقادیر و قالب‌بندی نوارهای خطا را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را در یک فایل PPTX بنویسید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# یک نمونه از کلاس Presentation ایجاد کنید.
presentation = Presentation()
try:
    # یک نمودار حبابی ایجاد کنید.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # نوارهای خطا را اضافه کنید و قالب‌بندی آن‌ها را تنظیم کنید.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # ارائه را ذخیره کنید.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **افزودن مقادیر سفارشی نوار خطا**

Aspose.Slides for Python via Java یک API ساده برای مدیریت مقادیر سفارشی نوارهای خطا فراهم می‌کند. کد نمونهٔ زیر زمانی اعمال می‌شود که [getValueType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/errorbarsformat/#getValueType) مقدار [ErrorBarValueType.Custom](https://reference.aspose.com/slides/fa/python-java/aspose.slides/errorbarvaluetype/#Custom) را برگرداند. برای تعیین یک مقدار، برای یک نقطه دادهٔ خاص در مجموعه‌ای که توسط متد سری [getDataPoints](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getDataPoints) برگردانده می‌شود، از [getErrorBarsCustomValues](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک نمودار حبابی به اسلاید موردنظر اضافه کنید.
1. به اولین سری نمودار دسترسی پیدا کنید و قالب نوار خطای X را تنظیم کنید.
1. به اولین سری نمودار دسترسی پیدا کنید و قالب نوار خطای Y را تنظیم کنید.
1. به نقاط دادهٔ منفرد در سری نمودار دسترسی پیدا کنید و مقادیر نوارهای خطای آن‌ها را تنظیم کنید.
1. مقادیر و قالب‌بندی نوارهای خطا را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را در یک فایل PPTX بنویسید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# یک نمونه از کلاس Presentation ایجاد کنید.
presentation = Presentation()
try:
    # یک نمودار حبابی ایجاد کنید.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # نوارهای خطای سفارشی را اضافه کنید و قالب‌بندی آن‌ها را تنظیم کنید.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # به نقاط دادهٔ سری نمودار دسترسی پیدا کنید و منابع مقادیر نوار خطا آن‌ها را پیکربندی کنید.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # مقدارهای نوار خطا را برای نقاط دادهٔ سری نمودار تنظیم کنید.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # ارائه را ذخیره کنید.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **پرسش‌های متداول**

**هنگام صادرات ارائه به PDF یا تصاویر، چه اتفاقی برای نوارهای خطا می‌افتد؟**

آن‌ها به عنوان بخشی از نمودار رندر می‌شوند و در طول تبدیل همراه با بقیه قالب‌بندی نمودار حفظ می‌گردند، به شرط آن که نسخه یا رندر‌کنندهٔ سازگار باشد.

**آیا نوارهای خطا می‌توانند با نشانگرها و برچسب‌های داده ترکیب شوند؟**

بله. نوارهای خطا عنصر جداگانه‌ای هستند و با نشانگرها و برچسب‌های داده سازگارند؛ در صورتی که این عناصر هم‌پوشانی داشته باشند، ممکن است نیاز به تنظیم قالب‌بندی داشته باشید.

**کجا می‌توانم فهرست ویژگی‌ها و کلاس‌های مرتبط با کار با نوارهای خطا در API را پیدا کنم؟**

در مستندات API: کلاس [ErrorBarsFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/errorbarsformat/) و کلاس‌های مرتبط [ErrorBarType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/errorbartype/) و [ErrorBarValueType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/errorbarvaluetype/).