---
title: سفارشی‌سازی افسانه‌های نمودار در ارائه‌ها با PHP
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
description: "افسانه‌های نمودار را با Aspose.Slides برای PHP از طریق Java سفارشی کنید تا ارائه‌های PowerPoint را با قالب‌بندی منطبق بر افسانه بهینه کنید."
---
## **مرور کلی**

Aspose.Slides for PHP via Java گزینه‌هایی برای سفارشی‌سازی افسانه‌های نمودار در ارائه‌های PowerPoint فراهم می‌کند. این مقاله نشان می‌دهد چگونه موقعیت و اندازه یک افسانه را تنظیم کنیم، اندازه قلم کل افسانه را تنظیم کنیم، یک ورودی افسانه را به صورت فردی فرمت کنیم، و ورودی‌های انتخابی را مخفی یا بازگردانیم.

سوالات متداول رفتارهای مرتبط را پوشش می‌دهد، از جمله رزرو فضای برای افسانه، نمایش برچسب‌های چند خطی، و ارث‌بری فرمت از تم ارائه.

## **موقعیت افسانه**

برای تعیین موقعیت و اندازه افسانه به‌عنوان کسری از ابعاد نمودار، از متدهای [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/), و [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) افسانه استفاده کنید.

این مثال یک ارائه ایجاد می‌کند و یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض به اسلاید اول اضافه می‌کند. تقسیم افست‌ها و ابعاد موردنظر افسانه بر عرض و ارتفاع نمودار، آنها را به مقادیر نسبی تبدیل می‌کند: افسانه ۵۰ نقطه از گوشه بالایی‌چپ نمودار جابجا شده و به اندازه ۱۰۰ در ۱۰۰ نقطه تنظیم می‌شود. این مثال از java_values برای تبدیل ابعاد نمودار برگشتی از PHP/Java Bridge به اعداد PHP قبل از تقسیم استفاده می‌کند.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // موقعیت و اندازه افسانه را نسبت به نمودار بیان کنید.
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم اندازه قلم افسانه**

از [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/) افسانه برای دسترسی به قالب‌بندی متن آن استفاده کنید و با [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) اندازه قلم را بر حسب نقطه تنظیم کنید.

این مثال یک نمودار با داده‌های پیش‌فرض ایجاد می‌کند و متن افسانه را به ۲۰ نقطه تنظیم می‌نماید. همچنین حدود خودکار برای محور عمودی را غیرفعال کرده و بازه آن را از -5 تا 10 تنظیم می‌کند.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم اندازه قلم ورودی افسانه فردی**

از مجموعه‌ای که توسط متد [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) افسانه برگردانده می‌شود برای دسترسی به قالب‌بندی یک ورودی خاص استفاده کنید. ایندکس‌های ورودی صفر‑مبنا هستند، بنابراین ایندکس `1` به ورودی دوم اشاره دارد.

این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند که داده‌های پیش‌فرض آن حداقل دو سری را شامل می‌شود. ورودی دوم افسانه را با فونت ضخیم، ایتالیک و متن آبی ۲۰ نقطه‌ای فرمت می‌کند.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **پنهان‌کردن ورودی‌های افسانه فردی**

برای حذف یک سری کمکی از افسانه در حالی که داده‌های آن قابل مشاهده باقی می‌مانند، از [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) با مقدار `true` از طریق [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/) فراخوانی کنید. این فقط ورودی انتخاب‌شده افسانه را مخفی می‌کند؛ سری یا نقاط داده آن حذف نمی‌شوند. در مقابل، فراخوانی [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) با مقدار `false` تمام افسانه را مخفی می‌کند.

مثال زیر یک نمودار ستونی خوشه‌ای با چندین سری با استفاده از داده‌های پیش‌فرض ایجاد می‌کند. ورودی افسانه سری دوم (ایندکس `1`) را مخفی می‌کند و ارائه را ذخیره می‌نماید. سپس با فراخوانی [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) با مقدار `false` ورودی را بازمی‌گرداند و یک نسخه دوم ذخیره می‌کند. ستون‌ها در هر دو فایل قابل مشاهده باقی می‌مانند.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // بازیابی همان ورودی بدون تغییر داده‌های نمودار.
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

مقایسه زیر همان نمودار را با تمام ورودی‌های افسانه قابل مشاهده و با ورودی دوم مخفی نمایش می‌دهد. ستون‌های سری دوم بدون تغییر باقی می‌مانند.

![مقایسه نمودار با تمام ورودی‌های افسانه قابل مشاهده و با مخفی شدن سری ۲ از افسانه؛ تمام ستون‌ها قابل مشاهده هستند.](hide-legend-entry.png)

در نمودارهای ستونی، میله‌ای و خطی، ورودی‌های افسانه شناسایی‌کننده سری‌ها هستند. برای نمودارهای دایره‌ای، آنها نقاط دادهٔ فردی (قاشق‌ها) را شناسایی می‌کنند، بنابراین به‌جای آن از [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) بر روی قاشق انتخاب‌شده استفاده کنید. API این متد نقطه‌داده را برای انواع نمودار `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, و `BarOfPie` مستند کرده است. فرض نکنید که برای نمودارهای دونات نیز اعمال می‌شود؛ این نوع در آن فهرست گنجانده نشده است.

## **سوالات متداول**

**آیا می‌توانم از نمودار بخواهم به‌جای پوشاندن افسانه، فضایی برای آن اختصاص دهد؟**  
بله. با فراخوانی [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) با مقدار `false` می‌توانید به‌جای اجازهٔ هم‌پوشانی با ناحیهٔ نمودار، فضای موردنیاز افسانه را رزرو کنید.

**آیا می‌توانم برچسب‌های افسانه چندخطی داشته باشم؟**  
بله. برچسب‌های طولانی می‌توانند هنگام عدم کافی بودن عرض موجود به‌صورت خط به خط بشکنند. همچنین می‌توانید از کاراکترهای جدید خط در نام‌های سری برای درخواست شکست خط استفاده کنید.

**چگونه می‌توانم افسانه را مطابق طرح رنگی تم ارائه تنظیم کنم؟**  
رنگ‌ها، پرکننده‌ها و قلم‌های افسانه را تنظیم نکنید تا بتواند قالب‌بندی تم را به ارث ببرد. قالب‌بندی صریح تنظیمات مربوط به تم را نادیده می‌گیرد.