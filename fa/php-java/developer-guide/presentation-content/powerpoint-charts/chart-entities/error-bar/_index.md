---
title: سفارشی‌سازی نوارهای خطا در نمودارهای ارائه با استفاده از PHP
linktitle: نوار خطا
type: docs
url: /fa/php-java/error-bar/
keywords:
- نوار خطا
- مقدار سفارشی
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه نوارهای خطا را در نمودارها با Aspose.Slides برای PHP از طریق Java اضافه و سفارشی کنید — نمایش داده‌ها را در ارائه‌های پاورپوینت بهینه کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با استفاده از Aspose.Slides در نمودارهای ارائه با نوارهای خطا کار کنید. این مقاله نشان می‌دهد چگونه نوارهای خطا را به یک سری نمودار اضافه کنید، تنظیمات نوارهای خطای X و Y را پیکربندی کنید و انواع مختلف مقادیر مانند مقدار ثابت، درصدی و سفارشی را اعمال کنید.

همچنین نحوه اختصاص مقادیر سفارشی نوار خطا برای نقاط دادهٔ فردی در یک سری با استفاده از مجموعهٔ نقاط دادهٔ مربوطه را نشان می‌دهد. علاوه بر این، مقاله نکات کوتاهی دربارهٔ رفتار نوارهای خطا در زمان خروجی‌گیری، سازگاری آن‌ها با نشانگرها و برچسب‌های داده، و مکان یافتن کلاس‌ها و شمارنده‌های مربوط به مرجع API ارائه می‌کند.

## **افزودن نوارهای خطا**
Aspose.Slides برای PHP از طریق Java یک API ساده برای مدیریت مقادیر نوارهای خطا ارائه می‌دهد. کد نمونه زمانی اعمال می‌شود که از نوع مقدار سفارشی استفاده شود. برای تعیین یک مقدار، از ویژگی **ErrorBarCustomValues** یک نقطه دادهٔ خاص در مجموعهٔ [**نقاط داده**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriescollection/) سری استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
2. یک نمودار حبابی در اسلاید موردنظر اضافه کنید.
3. به اولین سری نمودار دسترسی پیدا کنید و قالب نوار خطای X را تنظیم کنید.
4. به اولین سری نمودار دسترسی پیدا کنید و قالب نوار خطای Y را تنظیم کنید.
5. تنظیم مقادیر و قالب نوارها.
6. ارائهٔ تغییر یافته را به یک فایل PPTX بنویسید.

```php
  # یک نمونه از کلاس Presentation ایجاد کنید
  $pres = new Presentation();
  try {
    # ایجاد یک نمودار حبابی
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # افزودن نوارهای خطا و تنظیم قالب آن‌ها
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # ذخیره‌سازی ارائه
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **افزودن مقادیر سفارشی نوار خطا**
Aspose.Slides برای PHP از طریق Java یک API ساده برای مدیریت مقادیر سفارشی نوار خطا ارائه می‌دهد. کد نمونه زمانی اعمال می‌شود که متد [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/errorbarsformat/#getValueType) مقدار **Custom** را برگرداند. برای تعیین یک مقدار، از ویژگی **ErrorBarCustomValues** یک نقطه دادهٔ خاص در مجموعهٔ [**نقاط داده**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriescollection/) سری استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
2. یک نمودار حبابی در اسلاید موردنظر اضافه کنید.
3. به اولین سری نمودار دسترسی پیدا کنید و قالب نوار خطای X را تنظیم کنید.
4. به اولین سری نمودار دسترسی پیدا کنید و قالب نوار خطای Y را تنظیم کنید.
5. به نقاط دادهٔ فردی سری نمودار دسترسی پیدا کنید و مقادیر نوار خطا را برای هر نقطه دادهٔ سری به طور جداگانه تنظیم کنید.
6. تنظیم مقادیر و قالب نوارها.
7. ارائهٔ تغییر یافته را به یک فایل PPTX بنویسید.

```php
  # یک نمونه از کلاس Presentation ایجاد کنید
  $pres = new Presentation();
  try {
    # ایجاد یک نمودار حبابی
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # افزودن نوارهای خطای سفارشی و تنظیم قالب آن
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # دسترسی به نقطه دادهٔ سری نمودار و تنظیم مقادیر نوارهای خطا برای
    # نقطهٔ فردی
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # تنظیم نوارهای خطا برای نقاط سری نمودار
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # ذخیره‌سازی ارائه
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**هنگام خروجی‌گیری ارائه به PDF یا تصویر، چه اتفاقی برای نوارهای خطا می‌افتد؟**

آن‌ها به عنوان بخشی از نمودار رندر می‌شوند و در هنگام تبدیل به همراه بقیه قالب‌بندی نمودار حفظ می‌شوند، مشروط بر این‌که نسخه یا رندرر سازگار باشد.

**آیا می‌توان نوارهای خطا را با نشانگرها و برچسب‌های داده ترکیب کرد؟**

بله. نوارهای خطا یک عنصر جداگانه هستند و با نشانگرها و برچسب‌های داده سازگارند؛ اگر عناصر همپوشانی داشته باشند، ممکن است نیاز به تنظیم قالب‌بندی داشته باشید.

**کجا می‌توانم لیست ویژگی‌ها و کلاس‌های مربوط به کار با نوارهای خطا را در API پیدا کنم؟**

در مرجع API: کلاس [ErrorBarsFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/errorbarsformat/) و کلاس‌های مرتبط [ErrorBarType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/errorbartype/) و [ErrorBarValueType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/errorbarvaluetype/).