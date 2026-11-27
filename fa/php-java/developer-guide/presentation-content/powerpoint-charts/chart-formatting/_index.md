---
title: قالب‌بندی نمودارهای ارائه در PHP
linktitle: قالب‌بندی نمودار
type: docs
weight: 60
url: /fa/php-java/chart-formatting/
keywords:
- قالب‌بندی نمودار
- قالب‌بندی نمودار
- موجودیت نمودار
- ویژگی‌های نمودار
- تنظیمات نمودار
- گزینه‌های نمودار
- ویژگی‌های قلم
- لبه‌های گرد
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یادگیری قالب‌بندی نمودارها در Aspose.Slides برای PHP از طریق Java و ارتقاء ارائه PowerPoint شما با محورها، قلم‌ها، قالب‌های عددی سفارشی و لبه‌های گرد نمودار."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان نمودارها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides قالب‌بندی کرد. در آن نشان داده می‌شود که چگونه عناصر کلیدی نمودار مانند محورها، خطوط شبکه، عناوین، توضیح‌نامه‌ها، ناحیه‌نقاشی و پرکردن دیوارها را سفارشی‌سازی کرد تا ظاهر و خوانایی داده‌های نمودار بهبود یابد.

همچنین نحوه تنظیم ویژگی‌های قلم برای متن نمودار، اعمال قالب‌های عددی پیش‌فرض به داده‌های نمودار و فعال‌سازی گوشه‌های گرد برای ناحیه نمودار نشان داده می‌شود. این مثال‌ها نشان می‌دهند که چگونه می‌توان هم سبک بصری و هم ارائه داده‌های نمودارها را در یک ارائه کنترل کرد.

برای پرکردن‌ها و خط‌کش‌های جداگانه در بازه‌های صعودی و نزولی، به [مثال نمودار سهام](/slides/fa/php-java/create-chart/#create-stock-charts) مراجعه کنید.

## **قالب‌بندی موجودیت‌های نمودار**

از [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) برای قالب‌بندی عناوین نمودار، محورها، خطوط شبکه، توضیح‌نامه‌ها و ناحیه‌نقاشی استفاده کنید. این مثال یک نمودار خطی با نشانگرها و داده‌های پیش‌فرض ایجاد می‌کند و سپس سبک‌های متنی و خطی جداگانه‌ای به محورهاِ مقدار و دسته‌بندی آن اعمال می‌کند. اندازه قلم و عرض خطوط بر حسب پوینت مشخص می‌شوند؛ برچسب‌های دسته‌بندی به اندازه ۴۵ درجه چرخانده می‌شوند.

محور مقدار از [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setNumberFormat) به‌صورت مستقل از سلول‌های منبع استفاده می‌کند. مقیاس آن از ‎‑2 تا 15 است، با بازه‌های اصلی 2 و بازه‌های جزئی 0.5. مثال همچنین قالب درصدی را با [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setDisplayUnit) که بر روی هزارها تنظیم شده ترکیب می‌کند، بنابراین این تنظیمات را بر اساس معنی و اندازه داده‌های خود تنظیم کنید. توضیح‌نامه به دلیل فراخوانی [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#setOverlay) با `false` در خارج از ناحیه‌نقاشی می‌ماند. پرکردن‌های پشت‌دیوار و کف از طریق [getBackWall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getBackWall) و [getFloor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getFloor) پیکربندی می‌شوند، اما این سطوح فقط در نمودارهای سه‌بعدی قابل مشاهده هستند.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\LineDashStyle;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\TickLabelPositionType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);

    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle::DashDot);

    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");

    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);

    $chart->getAxes()->getVerticalAxis()->setMaxValue(15);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);

    $valueAxisText = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $valueAxisText->setFontBold(NullableBool::True);
    $valueAxisText->setFontHeight(16);
    $valueAxisText->setFontItalic(NullableBool::True);
    $valueAxisText->getFillFormat()->setFillType(FillType::Solid);
    $valueAxisText->getFillFormat()->getSolidFillColor()->setPresetColor(PresetColor::DarkGreen);
    $valueAxisText->setLatinFont(new FontData("Times New Roman"));

    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valueAxisTitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valueAxisTitle->setText("Primary Axis");
    $valueAxisTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valueAxisTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valueAxisTitle->getPortionFormat()->setFontHeight(20);
    $valueAxisTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valueAxisTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 128, 0));
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);

    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

    $categoryAxisText = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $categoryAxisText->setFontBold(NullableBool::True);
    $categoryAxisText->setFontHeight(16);
    $categoryAxisText->setFontItalic(NullableBool::True);
    $categoryAxisText->getFillFormat()->setFillType(FillType::Solid);
    $categoryAxisText->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $categoryAxisText->setLatinFont(new FontData("Arial"));

    $chart->getAxes()->getHorizontalAxis()->setTitle(true);
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");

    $categoryAxisTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $categoryAxisTitle->setText("Sample Category");
    $categoryAxisTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $categoryAxisTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $categoryAxisTitle->getPortionFormat()->setFontHeight(20);
    $categoryAxisTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $categoryAxisTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);

    $legendText = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $legendText->setFontBold(NullableBool::True);
    $legendText->setFontHeight(16);
    $legendText->setFontItalic(NullableBool::True);
    $legendText->getFillFormat()->setFillType(FillType::Solid);
    $legendText->getFillFormat()->getSolidFillColor()->setPresetColor(PresetColor::DarkRed);

    $chart->getLegend()->setOverlay(false);

    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setPresetColor(PresetColor::LightCyan);

    $presentation->save("FormattedChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم ویژگی‌های قلم برای یک نمودار**

اندازه قلم پیش‌فرض متن نمودار را از طریق [Chart::getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getTextFormat) تنظیم کنید. مثال یک نمودار ستونی تجمعی با قلم 20 پوینت ایجاد می‌کند و برچسب‌های مقدار برای سری اول را از طریق [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) فعال می‌نماید. عناصر متنی که تنظیمات قلم صریح خود را دارند می‌توانند پیش‌فرض نمودار را نادیده بگیرند.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **بازاستفاده از قالب‌بندی فریم متن برای توضیح‌نامه نمودار**

برای هم‌خوانی توضیح‌نامه با عنوان اسلاید، قلم عنوان را از طریق [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) در اولین پاراگراف تنظیم کنید. بر روی قالبی که توسط [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#getTextFormat) توضیح‌نامه بازگردانده می‌شود، [copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyFrom) را صدا بزنید. این کار تنظیمات فریم متن، قالب‌بندی اولین پاراگراف و ویژگی‌های قلم پیش‌فرض آن پاراگراف را کپی می‌کند. قالب‌بندی اعمال‌شده مستقیم به قسمت‌های جداگانه یا به پاراگراف‌های بعدی، به منبع محلی می‌ماند.

مثال از عنوان بولد، 26‑پوینت Calibri به رنگ سرمه‌ای به عنوان قالب استفاده می‌کند. پس از استایل‌دهی به توضیح‌نامه، [copyTo](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyTo) را برای اعمال همان قالب به یک عنوان جداگانه فراخوانی می‌کند.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\LegendPositionType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\StyleType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $heading = $shapes->addAutoShape(ShapeType::Rectangle, 40, 20, 640, 40, false);
    $sourceTextFrame = $heading->addTextFrame("Quarterly sales");
    $font = $sourceTextFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
    $font->setLatinFont(new FontData("Calibri"));
    $font->setFontHeight(26);
    $font->setFontBold(NullableBool::True);
    $font->getFillFormat()->setFillType(FillType::Solid);
    $font->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 32, 64, 96));

    $chart = $shapes->addChart(ChartType::ClusteredColumn, 40, 75, 640, 360);
    $chart->setStyle(StyleType::Style3);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->getCell(0, 0, 1)->setValue("Retail");
    $workbook->getCell(0, 0, 2)->setValue("Online");
    $workbook->getCell(0, 0, 3)->setValue("Wholesale");
    for ($quarter = 1; $quarter <= 4; $quarter++) {
        $workbook->getCell(0, $quarter, 0)->setValue("Q" . $quarter);
    }

    $chart->setLegend(true);
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $legendFormat = $chart->getLegend()->getTextFormat();
    $legendFormat->copyFrom($sourceTextFrame);

    $caption = $shapes->addAutoShape(ShapeType::Rectangle, 40, 460, 640, 40, false);
    $captionTextFrame = $caption->addTextFrame("Sales in millions of dollars");
    $legendFormat->copyTo($captionTextFrame);

    $presentation->save("legend-formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

در ارائه ذخیره‌شده، توضیح‌نامه و عنوان با عنوان اصلی از نظر اندازه، وزن و رنگ مطابقت دارند. توضیح‌نامه هنوز نام سری‌ها را نمایش می‌دهد و عنوان متن خود را حفظ می‌کند. اگر بخشی در عنوان قبلاً اندازه قلم صریح داشته باشد، آن اندازه بر پیش‌فرض پاراگراف کپی‌شده اولویت دارد.

| قبل از کپی | بعد از کپی |
| --- | --- |
| ![نمودار فروش فصلی با برچسب‌های توضیح‌نامه سیاه معمولی و یک عنوان سیاه](legend-formatting-before.png) | ![نمودار مشابه با برچسب‌های توضیح‌نامه بزرگتر، برجسته و رنگ سرمه‌ای و عنوان مطابقت‌دار](legend-formatting.png) |

## **تنظیم قالب عددی**

از [ChartDataCell::setPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setPresetNumberFormat) برای اعمال یک قالب عددی توکار به سلول‌های کتاب کار نمودار استفاده کنید. این مثال یک نمودار ستونی تجمعی با داده‌های پیش‌فرض و پشت‌پوشیده‌به‑سلول ایجاد می‌کند و ایندکس قالب 10 (`0.00%`) را به هر سلول مقدار سری اعمال می‌کند. این کار نحوه نمایش مقدارها را در کتاب کار بدون تغییر اعداد زیرین تغییر می‌دهد؛ برای مثال 0.25 به صورت 25.00% نمایش داده می‌شود. قالب‌های محور و برچسب‌های داده می‌توانند به‌صورت جداگانه پیکربندی شوند.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries();

    for ($i = 0; $i < java_values($series->size()); $i++) {
        $chartSeries = $series->get_Item($i);
        $dataPoints = $chartSeries->getDataPoints();
        for ($j = 0; $j < java_values($dataPoints->size()); $j++) {
            $dataPoint = $dataPoints->get_Item($j);
            $dataPoint->getValue()->getAsCell()->setPresetNumberFormat(10); // 0.00%
        }
    }

    $presentation->save("PresetNumberFormat_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

جدول زیر ایندکس‌های قالب عددی توکار را با قالب‌های نمایشی Excel برای محلی English (United States) فهرست می‌کند. رشته‌های قالب دقیق و نمایش آنها می‌توانند بسته به برنامه و محلی متفاوت باشند، به‌ویژه برای ارزها و تاریخ‌ها. برخی قالب‌های Excel نیز با پیش‌فرض‌های استاندارد OOXML تفاوت دارند، همان‌طور که در [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) توضیح داده شده است.

| شماره | قالب |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **تنظیم حاشیه‌های گرد شده ناحیه نمودار**

با فراخوانی [Chart::setRoundedCorners](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setRoundedCorners) با مقدار `true` گوشه‌های ناحیه نمودار را گرد کنید. مثال یک نمودار ستونی تجمعی ایجاد می‌کند و از [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) برای دادن رنگ خاکستری ثابت و سبک خط تک‌خطی به مرزی‌اش قبل از ذخیره‌سازی ارائه استفاده می‌کند.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chart->getLineFormat()->setStyle(LineStyle::Single);
    $chart->setRoundedCorners(true);

    $presentation->save("out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ویرایش حاشیه‌نویسی‌های موجود در نمودار**

یک نمودار می‌تواند شامل اشکال سفارشی باشد، مانند یک حاشیه‌نویسی متنی که وضعیت گزارشی را توضیح می‌دهد. به این اشکال از طریق [Chart::getUserShapes](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getUserShapes) دسترسی پیدا کنید. مجموعه‌ای که توسط [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) برگردانده می‌شود شامل اشکال متعلق به نمودار است.

یک جعبه متن عادی که بر روی نمودار قرار می‌گیرد، متعلق به اسلاید است، حتی اگر شبیه جزء نمودار به نظر برسد. پیمایش از طریق [Slide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) نمودار و اشکال عادی اسلاید را پیدا می‌کند، اما اشکال فردی داخل نمودار را فهرست نمی‌کند. عناوین نمودار و برچسب‌های داده عناصر جداگانه‌ای از نمودار هستند، نه حاشیه‌نویسی‌های سفارشی در این مجموعه.

[chart-annotations.pptx](chart-annotations.pptx) را دانلود کنید و در پوشه کاری برنامه قرار دهید. اسلاید اول آن حاوی یک نمودار با حاشیه‌نویسی بدون گروه "Preliminary results"، یک خط متعلق به نمودار و یک جعبه متن اسلایدی "Slide overlay" است. مثال اولین نمودار را در آن اسلاید پیدا می‌کند و حاشیه‌نویسی را به "Final results" تغییر می‌دهد وقتی گزارش آماده انتشار باشد. مجموعه خالی را بررسی می‌کند و فقط یک [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) با فریم متن غیر تهی که توسط [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getTextFrame) بازگردانده می‌شود و متن مورد انتظار دارد، ویرایش می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-annotations.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chartType = new JavaClass("com.aspose.slides.IChart");
    $autoShapeType = new JavaClass("com.aspose.slides.IAutoShape");
    $chart = null;
    for ($i = 0; $i < java_values($slide->getShapes()->size()); $i++) {
        $shape = $slide->getShapes()->get_Item($i);
        if (java_instanceof($shape, $chartType)) {
            $chart = $shape;
            break;
        }
    }

    if ($chart === null || java_values($chart->getUserShapes()->getShapes()->size()) == 0) {
        echo "No chart or chart-owned shapes found." . PHP_EOL;
        return;
    }

    $updated = false;
    $userShapes = $chart->getUserShapes()->getShapes();
    for ($i = 0; $i < java_values($userShapes->size()); $i++) {
        $shape = $userShapes->get_Item($i);
        if (java_instanceof($shape, $autoShapeType)) {
            $annotation = $shape;
            if (!java_is_null($annotation->getTextFrame()) && java_values($annotation->getTextFrame()->getText()) === "Preliminary results") {
                $annotation->getTextFrame()->setText("Final results");
                $updated = true;
                break;
            }
        }
    }

    if ($updated) {
        $presentation->save("chart-annotations-updated.pptx", SaveFormat::Pptx);
    } else {
        echo "No matching text annotation found." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

خط و جعبه متن اسلاید بدون تغییر می‌مانند. تصاویر زیر ورودی و نتیجه ذخیره‑شده بازگشایی‌شده را نشان می‌دهند:

| قبل از ویرایش | بعد از ویرایش |
| --- | --- |
| ![حاشیه‌نویسی نمودار با متن «نتایج اولیه»](chart-annotations-before.png) | ![حاشیه‌نویسی نمودار با متن «نتایج نهایی»](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
مثال فقط اشکال سطح‑بالای متعلق به نمودار را بررسی می‌کند. اگر یک حاشیه‌نویسی داخل یک [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) باشد، مجموعهٔ [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) آن گروه را نیز بررسی کنید. این کار را به‌صورت بازگشتی برای گروه‌های تو در تو تکرار کنید و همان بررسی‌های متنی را بر اشکال فرزند آنها اعمال کنید. یک گروه خود یک مخزن است؛ آن را به‌عنوان جعبه متن در نظر نگیرید.
{{% /alert %}}

## **سؤالات متداول**

**آیا می‌توانم پرکردن‌های نیمه‌شفاف برای ستون‌ها/ناحیه‌ها تنظیم کنم در حالی که حاشیه را مات نگه دارم؟**

بله. شفافیت پرکردن و خط مرزی به‌صورت جداگانه پیکربندی می‌شوند. این برای بهبود خوانایی شبکه و داده‌ها در تجسم‌های متراکم مفید است.

**چگونه می‌توانم با برچسب‌های داده که هم‌پوشانی دارند سروکار داشته باشم؟**

اندازه قلم را کاهش دهید، اجزای غیرضروری برچسب (مثلاً دسته‌ها) را غیرفعال کنید، موقعیت برچسب را تنظیم کنید، در صورت نیاز فقط برای نقاط انتخاب‌شده برچسب نشان دهید، یا قالب را به «value + legend» تغییر دهید.

**آیا می‌توانم پرکردن‌های گرادیان یا الگو را بر سری‌ها اعمال کنم؟**

بله. سری‌ها از پرکردن‌های ثابت، گرادیان و الگو پشتیبانی می‌کنند. در عمل، از گرادیان‌ها به‌طور محدود استفاده کنید و ترکیب‌هایی که کنتراست را با شبکه و متن کاهش می‌دهند، اجتناب کنید.