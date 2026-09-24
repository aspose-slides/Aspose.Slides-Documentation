---
title: سفارشی‌سازی جداول داده نمودار در ارائه‌ها با استفاده از PHP
linktitle: جدول داده
type: docs
url: /fa/php-java/chart-data-table/
keywords:
- داده نمودار
- جدول داده
- ویژگی‌های قلم
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "سفارشی‌سازی قلم‌های جدول داده نمودار، حاشیه‌ها و کلیدهای لگن در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای PHP از طریق Java."
---
## **نمای کلی**

Aspose.Slides for PHP via Java به شما امکان می‌دهد جدول داده‌های یک نمودار را نمایش دهید و قالب‌بندی متن، حاشیه‌ها و کلیدهای لگن آن را سفارشی کنید. این مقاله توضیح می‌دهد چگونه جدول را فعال کنید، متن آن را قالب‌بندی کنید، هر نوع حاشیه را به‌صورت جداگانه کنترل کنید و کلیدهای لگن را نشان یا پنهان کنید. مثال‌ها نمودارهای پیکربندی‌شده را در فایل‌های PPTX ذخیره می‌کنند.

## **تنظیم ویژگی‌های قلم**

برای نمایش جدول داده‌های یک نمودار، `true` را به [setDataTable](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/setdatatable/) بدهید. برای دسترسی به جدول و پیکربندی قالب‌بندی متن از [getChartDataTable](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/getchartdatatable/) استفاده کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) بارگذاری کنید.
1. یک نمودار ستونی خوشه‌ای به اسلاید اول اضافه کنید.
1. جدول داده‌های نمودار را فعال کنید.
1. با [setFontBold](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setFontBold) متن را بولد کنید و `20` را به [setFontHeight](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setFontHeight) بدهید تا متن 20 پوینت باشد.
1. ارائه تغییر یافته را ذخیره کنید.

مثال زیر به `test.pptx` در پوشه کاری که حداقل یک اسلاید دارد، نیاز دارد. این مثال نموداری با داده‌های پیش‌فرض در موقعیت (50, 50) با عرض 600 پوینت و ارتفاع 400 پوینت اضافه می‌کند. فایل `output.pptx` ذخیره‌شده حاوی نمودار با جدول داده فعال و تنظیمات قلم مشخص‌شده است.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **سفارشی‌سازی حاشیه‌های جدول داده**

جدول را با [Chart::setDataTable](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/setdatatable/) فعال کنید و از طریق [Chart::getChartDataTable](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/getchartdatatable/) به آن دسترسی پیدا کنید. می‌توانید سه نوع حاشیه را به‌صورت مستقل کنترل کنید:

- [setBorderHorizontal](https://reference.aspose.com/slides/fa/php-java/aspose.slides/datatable/setborderhorizontal/) حاشیه‌های افقی سلول‌ها را کنترل می‌کند.
- [setBorderVertical](https://reference.aspose.com/slides/fa/php-java/aspose.slides/datatable/setbordervertical/) حاشیه‌های عمودی سلول‌ها را کنترل می‌کند.
- [setBorderOutline](https://reference.aspose.com/slides/fa/php-java/aspose.slides/datatable/setborderoutline/) حاشیه بیرونی جدول را کنترل می‌کند.

`true` را به هر متد بدهید تا حاشیه آن نمایش یابد یا `false` برای پنهان کردن. مثال زیر یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض ایجاد می‌کند، حاشیه‌های افقی و بیرونی را نمایش می‌دهد و حاشیه‌های عمودی را پنهان می‌کند. نیازی به فایل ورودی ندارد. موقعیت و اندازه نمودار بر حسب پوینت مشخص می‌شود.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

مقایسه زیر از همان داده‌های نمودار و تنظیمات کلید لگن در چهار حالت استفاده می‌کند. با فعال بودن تمام حاشیه‌ها شروع می‌شود و هر واریانت باقی‌مانده تنها یک تنظیم حاشیه را غیرفعال می‌کند. واریانت پایین‑چپ تنظیمات حاشیه مثال را مطابقت می‌دهد.

![جداول داده نمودار با تمام حاشیه‌ها فعال، بدون حاشیه افقی، بدون حاشیه عمودی، و بدون حاشیه بیرونی](data-table-borders.png)

## **نمایش یا پنهان کردن کلیدهای لگن**

کلیدهای لگن نشانگرهای رنگی کوچکی هستند که در کنار نام سری‌ها در جدول داده قرار می‌گیرند. این کلیدها به خواننده کمک می‌کنند هر سطر جدول را به یک سری نمودار مرتبط کند. `true` را به [setShowLegendKey](https://reference.aspose.com/slides/fa/php-java/aspose.slides/datatable/setshowlegendkey/) بدهید تا این نشانگرها نمایش داده شوند یا `false` برای پنهان کردن.

لگن جداگانه نمودار توسط [Chart::setLegend](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/setlegend/) کنترل می‌شود. این تنظیمات مستقل هستند: پنهان کردن لگن جداگانه، کلیدهای داخل جدول داده را مخفی نمی‌کند و پنهان کردن کلیدهای جدول، لگن جداگانه را مخفی نمی‌کند.

مثال زیر یک نمودار با داده‌های پیش‌فرض ایجاد می‌کند، جدول داده آن را فعال می‌کند و در همان جدول کلیدهای لگن را نشان می‌دهد در حالی که لگن جداگانه مخفی می‌شود. تمام حاشیه‌های جدول به‌صورت صریح فعال هستند. نیازی به ارائه ورودی نیست. برای پنهان کردن فقط کلیدهای جدول، `false` را به [setShowLegendKey](https://reference.aspose.com/slides/fa/php-java/aspose.slides/datatable/setshowlegendkey/) بدهید.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

مقایسه زیر همان جدول را با کلیدهای لگن فعال و غیرفعال نشان می‌دهد. تمام حاشیه‌ها فعال می‌مانند و لگن جداگانه نمودار در هر دو حالت مخفی است.

![جداول داده نمودار با کلیدهای لگن نمایش داده‌شده در سمت چپ و مخفی‌شده در سمت راست](data-table-legend-keys.png)

## **پرسش‌های متداول**

**آیا می‌توانم کلیدهای لگن را در جدول داده‌های نمودار نمایش دهم؟**

بله. `true` را به [setShowLegendKey](https://reference.aspose.com/slides/fa/php-java/aspose.slides/datatable/setshowlegendkey/) بدهید تا کلیدهای لگن نمایش داده شوند یا `false` برای پنهان کردن.

**آیا جدول داده هنگام صادر کردن ارائه به PDF، HTML یا تصاویر حفظ می‌شود؟**

بله. Aspose.Slides هنگام صادر کردن به [PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/)، [HTML](/slides/fa/php-java/convert-powerpoint-to-html/) یا [images](/slides/fa/php-java/convert-powerpoint-to-png/) نمودار و جدول دادهٔ نمایش‌داده‌شده را به‌عنوان بخشی از اسلاید رندر می‌کند.

**آیا می‌توانم با جدول‌های داده در نمودارهای بارگذاری‌شده از قالب کار کنم؟**

بله. برای نموداری که از یک ارائه یا قالب موجود بارگذاری شده است، از [hasDataTable](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/hasdatatable/) و [setDataTable](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/setdatatable/) استفاده کنید تا بررسی یا تغییر نمایش جدول داده را انجام دهید.

**چگونه می‌توانم نمودارهایی که جدول داده‌شان فعال است را پیدا کنم؟**

در هر اسلاید بر روی اشکال پیمایش کنید، نمودارها را شناسایی کنید و متد [hasDataTable](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/hasdatatable/) آنها را فراخوانی کنید. مقدار `true` نشان می‌دهد جدول داده فعال است.