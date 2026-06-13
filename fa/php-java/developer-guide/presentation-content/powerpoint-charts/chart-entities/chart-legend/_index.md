---
title: سفارشی‌سازی افسانه‌های نمودار در ارائه‌ها با استفاده از PHP
linktitle: افسانه نمودار
type: docs
url: /fa/php-java/chart-legend/
keywords:
- افسانه نمودار
- موقعیت افسانه
- اندازه قلم
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "افسانه‌های نمودار را با Aspose.Slides برای PHP از طریق Java سفارشی کنید تا ارائه‌های PowerPoint را با قالب‌بندی ویژه افسانه بهینه کنید."
---
## **بررسی کلی**

Aspose.Slides گزینه‌هایی برای سفارشی‌سازی افسانه نمودارها در ارائه‌های PowerPoint فراهم می‌کند. این مقاله نشان می‌دهد چگونه موقعیت و اندازهٔ یک افسانه را تنظیم کنید، اندازهٔ قلم را برای کل افسانه تعیین کنید و قالب‌بندی را برای یک ورودی افسانهٔ منفرد اعمال کنید.

همچنین رفتارهای مرتبط متعددی را در بخش پرسش‌های متداول پوشش می‌دهد، از جمله استفاده از حالت غیرپوششی تا ناحیهٔ نمودار برای افسانه جای باز کند، اجازه دادن به طولانی شدن برچسب‌های افسانه برای بسته شدن یا استفاده از شکست‌های خطی، و اجازه دادن به ارث‌بری قالب افسانه از تم ارائه هنگامی که تنظیمات صریح متن و پر کردن اعمال نشده‌اند.

## **موقعیت‌یابی افسانه**
برای تنظیم ویژگی‌های افسانه. لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
- ارجاع اسلاید را دریافت کنید.
- یک نمودار به اسلاید اضافه کنید.
- تنظیم ویژگی‌های افسانه.
- ارائه را به‌صورت فایل PPTX بنویسید.

در مثال زیر، موقعیت و اندازهٔ افسانهٔ نمودار را تنظیم کرده‌ایم.

```php
  # یک نمونه از کلاس Presentation ایجاد کنید
  $pres = new Presentation();
  try {
    # ارجاع اسلاید را دریافت کنید
    $slide = $pres->getSlides()->get_Item(0);
    # یک نمودار ستونی خوشه‌ای را به اسلاید اضافه کنید
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # تنظیم ویژگی‌های افسانه
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # ارائه را روی دیسک بنویسید
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم اندازهٔ قلم یک افسانه**
Aspose.Slides برای PHP از طریق Java به توسعه‌دهندگان اجازه می‌دهد اندازهٔ قلم افسانه را تنظیم کنند. لطفاً مراحل زیر را دنبال کنید:

- نمونه‌ای از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
- نمودار پیش‌فرض را ایجاد کنید.
- اندازهٔ قلم را تنظیم کنید.
- حداقل مقدار محور را تنظیم کنید.
- حداکثر مقدار محور را تنظیم کنید.
- ارائه را روی دیسک بنویسید.

```php
  # یک نمونه از کلاس Presentation ایجاد کنید
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم اندازهٔ قلم یک افسانهٔ منفرد**
Aspose.Slides برای PHP از طریق Java به توسعه‌دهندگان اجازه می‌دهد اندازهٔ قلم ورودی‌های منفرد افسانه را تنظیم کنند. لطفاً مراحل زیر را دنبال کنید:

- نمونه‌ای از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
- نمودار پیش‌فرض را ایجاد کنید.
- به ورودی افسانه دسترسی پیدا کنید.
- اندازهٔ قلم را تنظیم کنید.
- حداقل مقدار محور را تنظیم کنید.
- حداکثر مقدار محور را تنظیم کنید.
- ارائه را روی دیسک بنویسید.

```php
  # یک نمونه از کلاس Presentation ایجاد کنید
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پرسش‌های متداول**

**آیا می‌توانم افسانه را فعال کنم تا نمودار به‌صورت خودکار برای آن فضا اختصاص دهد و نه پوشش آن؟**

بله. از حالت غیرپوششی استفاده کنید ([setOverlay(false)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/legend/setoverlay/)); در این حالت، ناحیهٔ رسم کاهش می‌یابد تا جایی برای افسانه فراهم شود.

**آیا می‌توانم برچسب‌های افسانه چندخطی ایجاد کنم؟**

بله. برچسب‌های طولانی به‌صورت خودکار بسته می‌شوند زمانی که فضا کافی نباشد؛ شکست خط اجباری از طریق کاراکترهای خط جدید در نام سری پشتیبانی می‌شود.

**چگونه می‌توانم افسانه را به‌گونه‌ای تنظیم کنم که از طرح رنگی تم ارائه پیروی کند؟**

رنگ‌ها/پرکننده‌ها/قلم‌های صریح را برای افسانه یا متن آن تنظیم نکنید. در این صورت، آنها از تم ارث می‌برند و هنگام تغییر طرح به‌درستی به‌روز می‌شوند.