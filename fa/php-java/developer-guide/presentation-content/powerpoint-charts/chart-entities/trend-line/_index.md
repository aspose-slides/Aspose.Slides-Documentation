---
title: افزودن خطوط روند به نمودارهای ارائه در PHP
linktitle: خط روند
type: docs
url: /fa/php-java/trend-line/
keywords:
- نمودار
- خط روند
- خط روند نمایی
- خط روند خطی
- خط روند لگاریتمی
- خط روند میانگین متحرک
- خط روند چندجمله‌ای
- خط روند توان
- خط روند سفارشی
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "به سرعت خطوط روند را در نمودارهای PowerPoint با Aspose.Slides برای PHP از طریق Java اضافه و سفارشی کنید — راهنمای عملی برای جذب مخاطبان شما."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه می‌توان خطوط روند را به نمودارهای ارائه با استفاده از Aspose.Slides اضافه کرد. این مقاله نشان می‌دهد چگونه یک نمودار ایجاد کنید، خطوط روند را به سری‌های نمودار اضافه کنید و با چندین نوع خط روند کار کنید، از جمله نمایی، خطی، لگاریتمی، میانگین متحرک، چندجمله‌ای و توان.

همچنین توضیح می‌دهد چگونه می‌توان یک خط سفارشی به نمودار اضافه کرد با وارد کردن یک شکل خطی، و شامل سؤالات متداول کوتاهی درباره مقادیر پیش‌بینی شده خط روند به سمت جلو و عقب و این که آیا خطوط روند هنگام صادرات به PDF یا SVG یا رندر نمودارها به عنوان تصویر حفظ می‌شوند یا نه.

## **افزودن خط روند**
Aspose.Slides برای PHP از طریق Java یک API ساده برای مدیریت خطوط روند نمودارهای مختلف ارائه می‌دهد:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را بر اساس اندیس آن به دست آورید.
3. یک نمودار با داده‌های پیش‌فرض به همراه هر نوع دلخواه (در این مثال از ChartType::ClusteredColumn استفاده می‌شود) اضافه کنید.
4. خط روند نمایی را برای سری 1 نمودار اضافه کنید.
5. خط روند خطی را برای سری 1 نمودار اضافه کنید.
6. خط روند لگاریتمی را برای سری 2 نمودار اضافه کنید.
7. خط روند میانگین متحرک را برای سری 2 نمودار اضافه کنید.
8. خط روند چندجمله‌ای را برای سری 3 نمودار اضافه کنید.
9. خط روند توان را برای سری 3 نمودار اضافه کنید.
10. نمایشنامه تغییر یافته را به یک فایل PPTX بنویسید.

کد زیر برای ایجاد یک نمودار با خطوط روند استفاده می‌شود.

```php
  # ایجاد یک نمونه از کلاس Presentation
  $pres = new Presentation();
  try {
    # ایجاد یک نمودار ستونی خوشه‌ای
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # افزودن خط روند نمایی برای سری 1 نمودار
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # افزودن خط روند خطی برای سری 1 نمودار
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # افزودن خط روند لگاریتمی برای سری 2 نمودار
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    # افزودن خط روند میانگین متحرک برای سری 2 نمودار
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    # افزودن خط روند چندجمله‌ای برای سری 3 نمودار
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # افزودن خط روند توان برای سری 3 نمودار
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # ذخیره‌سازی ارائه
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **افزودن خط سفارشی**
Aspose.Slides برای PHP از طریق Java یک API ساده برای افزودن خطوط سفارشی به یک نمودار فراهم می‌کند. برای افزودن یک خط ساده به اسلاید انتخابی ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید
- مرجع یک اسلاید را با استفاده از Index آن به دست آورید
- یک نمودار جدید با استفاده از متد AddChart که توسط شیء Shapes ارائه می‌شود ایجاد کنید
- یک AutoShape از نوع خط را با استفاده از متد AddAutoShape که توسط شیء Shapes ارائه می‌شود اضافه کنید
- رنگ خطوط شکل را تنظیم کنید.
- نمایشنامه تغییر یافته را به عنوان فایل PPTX بنویسید

کد زیر برای ایجاد یک نمودار با خطوط سفارشی استفاده می‌شود.

```php
  # ایجاد یک نمونه از کلاس Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $shape = $chart->getUserShapes()->getShapes()->addAutoShape(ShapeType::Line, 0, $chart->getHeight() / 2, $chart->getWidth(), 0);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("Presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سؤالات متداول**

**'forward' و 'backward' در رابطه با خط روند چه معنایی دارند؟**

اینها طول‌های خط روند هستند که به سمت جلو/عقب پیش‌بینی می‌شوند: برای نمودارهای پراکندگی (XY) — به واحدهای محور؛ برای نمودارهای غیرپراکندگی — به تعداد دسته‌ها. فقط مقادیر غیرمنفی مجاز هستند.

**آیا خط روند هنگام صادرات ارائه به PDF یا SVG، یا هنگام رندر یک اسلاید به تصویر حفظ می‌شود؟**

بله. Aspose.Slides ارائه‌ها را به [PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/)/[SVG](/slides/fa/php-java/render-a-slide-as-an-svg-image/) تبدیل می‌کند و نمودارها را به تصاویر رندر می‌کند؛ خطوط روند، به عنوان بخشی از نمودار، در طول این عملیات حفظ می‌شوند. همچنین روشی برای [export an image of the chart](/slides/fa/php-java/create-shape-thumbnails/) موجود است.