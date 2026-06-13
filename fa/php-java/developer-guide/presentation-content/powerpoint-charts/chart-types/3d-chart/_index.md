---
title: سفارشی‌سازی نمودارهای سه‌بعدی در ارائه‌ها با استفاده از PHP
linktitle: نمودار 3D
type: docs
url: /fa/php-java/3d-chart/
keywords:
- نمودار سه‌بعدی
- چرخش
- عمق
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه نمودارهای سه‌بعدی را در Aspose.Slides برای PHP از طریق Java ایجاد و سفارشی کنید، با پشتیبانی از فایل‌های PPT و PPTX — امروز ارائه‌های خود را ارتقا دهید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه می‌توانید یک نمودار 3D را در Aspose.Slides با تنظیمات `Rotation3D` مانند `RotationX`، `RotationY`، `DepthPercents` و `RightAngleAxes` سفارشی کنید. این مقاله گام به گام ایجاد یک ارائه، افزودن یک نمودار 3D با داده‌های پیش‌فرض، اعمال تنظیمات نمای 3D مورد نیاز و ذخیرهٔ ارائهٔ اصلاح‌شده به‌صورت فایل PPTX را شرح می‌دهد.

## **تنظیم ویژگی‌های RotationX، RotationY و DepthPercents یک نمودار 3D**

Aspose.Slides for PHP via Java یک API ساده برای تنظیم این ویژگی‌ها فراهم می‌کند. مقالهٔ زیر به شما کمک می‌کند تا ویژگی‌های مختلفی مانند **چرخش X,Y، DepthPercents** و غیره را تنظیم کنید. کد نمونه تنظیم ویژگی‌های مذکور را اعمال می‌کند.

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.  
2. به اسلاید اول دسترسی پیدا کنید.  
3. نمودار را با داده‌های پیش‌فرض اضافه کنید.  
4. ویژگی‌های Rotation3D را تنظیم کنید.  
5. ارائهٔ تغییر یافته را به یک فایل PPTX بنویسید.

```php
  $pres = new Presentation();
  try {
    # دسترسی به اسلاید اول
    $slide = $pres->getSlides()->get_Item(0);
    # افزودن نمودار با داده‌های پیش‌فرض
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # تنظیم ایندکس برگه داده‌های نمودار
    $defaultWorksheetIndex = 0;
    # دریافت برگه کاری داده‌های نمودار
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # افزودن سری‌ها
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # افزودن دسته‌ها
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # تنظیم ویژگی‌های Rotation3D
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # دریافت سری دوم نمودار
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # اکنون پر کردن داده‌های سری
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # تنظیم مقدار OverLap
    $series->getParentSeriesGroup()->setOverlap(100);
    # نوشتن ارائه در دیسک
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پرسش‌های متداول**

**کدام انواع نمودار در Aspose.Slides حالت 3D را پشتیبانی می‌کنند؟**

Aspose.Slides انواع 3D نمودارهای ستونی را پشتیبانی می‌کند، از جمله Column 3D، Clustered Column 3D، Stacked Column 3D و 100% Stacked Column 3D، به‌همراه انواع 3D مرتبط که از طریق کلاس [ChartType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/) در دسترس هستند. برای دریافت فهرست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/) را در مستندات API نسخه نصب شده‌تان بررسی کنید.

**آیا می‌توانم تصویر رستر یک نمودار 3D برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید یک نمودار را از طریق [API نمودار](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getImage) به یک تصویر خروجی دهید یا کل اسلاید را به فرمت‌هایی مانند PNG یا JPEG رندر کنید. این کار زمانی مفید است که به پیش‌نمایش دقیق پیکسلی نیاز دارید یا می‌خواهید نمودار را بدون نیاز به PowerPoint در اسناد، داشبوردها یا صفحات وب جاسازی کنید.

**عملکرد ساخت و رندر نمودارهای بزرگ 3D چطور است؟**

کارایی به حجم داده‌ها و پیچیدگی بصری بستگی دارد. برای بهینه‌ترین نتایج، افکت‌های 3D را به حداقل برسانید، از بافت‌های سنگین روی دیوارها و نواحی نمودار پرهیز کنید، در صورت امکان تعداد نقاط داده در هر سری را محدود کنید و رندر را به خروجی با اندازه مناسب (رزولوشن و ابعاد) انجام دهید تا با نمایش یا چاپ هدف هماهنگ باشد.