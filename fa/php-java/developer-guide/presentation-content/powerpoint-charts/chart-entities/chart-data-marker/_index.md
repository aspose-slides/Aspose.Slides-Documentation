---
title: مدیریت نشانگرهای دادهٔ نمودار در ارائه‌ها با استفاده از PHP
linktitle: نشانگر داده
type: docs
url: /fa/php-java/chart-data-marker/
keywords:
- نمودار
- نقطه داده
- نشانگر
- گزینه‌های نشانگر
- اندازهٔ نشانگر
- نوع پرکردن
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه نشانگرهای دادهٔ نمودار را در Aspose.Slides برای PHP سفارشی کنید و با مثال‌های واضح کد، تأثیر ارائه را در فرمت‌های PPT و PPTX افزایش دهید."
---
## **نمایش کلی**

این مقاله توضیح می‌دهد که چگونه با نشانگرهای دادهٔ نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه یک نمودار ایجاد شود، یک سری و نقاط دادهٔ آن را دسترسی پیدا کنید، پرکردن تصویر را بر روی نشانگرها در سطح نقطهٔ داده اعمال کنید، اندازهٔ نشانگر را تنظیم کنید و ارائهٔ به‌روز شده را ذخیره کنید. همچنین اشاره می‌کند که شکل‌های استاندارد نشانگر از طریق شمارش `MarkerStyleType` در دسترس هستند و ظاهر نشانگر هنگام استخراج نمودارها به فرمت‌های رستری یا SVG حفظ می‌شود.

## **تنظیم گزینه‌های نشانگر نمودار**
نشانگرها می‌توانند بر روی نقاط دادهٔ نمودار درون سری‌های خاص تنظیم شوند. برای تنظیم گزینه‌های نشانگر نمودار، لطفاً مراحل زیر را دنبال کنید:

- نمونه‌سازی [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) کلاس.
- ایجاد نمودار پیش‌فرض.
- تنظیم تصویر.
- دریافت اولین سری نمودار.
- افزودن نقطه داده جدید.
- نوشتن ارائه به دیسک.

در مثال زیر، ما گزینه‌های نشانگر نمودار را در سطح نقاط داده تنظیم کرده‌ایم.

```php
  # ایجاد ارائه خالی
  $pres = new Presentation();
  try {
    # دسترسی به اولین اسلاید
    $slide = $pres->getSlides()->get_Item(0);
    # ایجاد نمودار پیش‌فرض
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # دریافت شاخص کاربرگ دادهٔ پیش‌فرض نمودار
    $defaultWorksheetIndex = 0;
    # دریافت کاربرگ دادهٔ نمودار
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # حذف سری نمونه
    $chart->getChartData()->getSeries()->clear();
    # افزودن سری جدید
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # بارگذاری تصویر ۱
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # بارگذاری تصویر ۲
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # دریافت اولین سری نمودار
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # افزودن نقطهٔ جدید (۱:۳) آنجا.
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # تغییر نشانگر سری نمودار
    $series->getMarker()->setSize(15);
    # ذخیرهٔ ارائه همراه با نمودار
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پرسش‌های متداول**

**کدام شکل‌های نشانگر به‌صورت پیش‌فرض موجود هستند؟**

شکل‌های استاندارد موجود هستند (دایره، مربع، لوزی، مثلث و غیره)؛ لیست توسط کلاس [MarkerStyleType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/markerstyletype/) تعریف می‌شود. اگر به شکل غیر استاندارد نیاز دارید، از نشانگری با پرکردن تصویر استفاده کنید تا تصاویر سفارشی را شبیه‌سازی کنید.

**آیا نشانگرها هنگام استخراج نمودار به تصویر یا SVG حفظ می‌شوند؟**

بله. هنگام رندر نمودارها به [فرمت‌های رستری](/slides/fa/php-java/convert-powerpoint-to-png/) یا ذخیرهٔ [اشکال به عنوان SVG](/slides/fa/php-java/render-a-slide-as-an-svg-image/)، نشانگرها ظاهر و تنظیمات خود را شامل اندازه، پرکننده و خط‌مرز حفظ می‌کنند.