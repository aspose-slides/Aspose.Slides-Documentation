---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها با استفاده از PHP
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/php-java/chart-workbook/
keywords:
- کتاب‌کار نمودار
- داده‌های نمودار
- سلول کتاب‌کار
- برچسب داده
- برگه کاری
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- کش نمودار
- بازگردانی کتاب‌کار
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "Aspose.Slides برای PHP از طریق Java را کشف کنید: به راحتی کتاب‌کارهای نمودار را در قالب‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائهٔ خود را بهینه‌سازی کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با کاربرگ‌های نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کاربرگ بخوانید و بنویسید، از سلول‌های کاربرگ به‌عنوان برچسب‌های دادهٔ نمودار استفاده کنید، به مجموعه‌های برگه‌های کاری دسترسی داشته باشید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کاربرگ‌های خارجی به‌عنوان منابع دادهٔ نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کاربرگ خارجی ایجاد و اختصاص دهید، مسیر یک کاربرگ خارجی که به یک نمودار وصل است دریافت کنید، و داده‌های نمودار را هنگامی که کاربرگ در دسترس است ویرایش کنید.

برای سلول‌های کاربرگی که دادهٔ گمشده را نشان می‌دهند، به [کنترل نمایش سلول‌های خالی](/slides/fa/php-java/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر، و مقایسهٔ نمودار خطی برای حالت‌های نمایش موجود را ببینید.

## **شامل کردن داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) برای کنترل این‌که آیا یک نمودار داده‌ها را از ردیف‌ها و ستون‌های مخفی برگه کاری ترسیم می‌کند یا نه، استفاده کنید. مقدار `true` باعث ترسیم فقط سلول‌های قابل مشاهده می‌شود و مقدار `false` هر دو سلول قابل مشاهده و مخفی را شامل می‌شود. این تنظیم فقط بر ترسیم نمودار تأثیر دارد؛ ردیف‌ها یا ستون‌های برگه کاری را مخفی یا آشکار نمی‌کند.

[نمونه ارائه](hidden-source-data.pptx) شامل یک نمودار ستونی به‌عنوان اولین شکل در اولین اسلاید است. برگه کاری تعبیه‌شده، `Sheet1`، بازه منبع زیر را دارد: `A1:C4`. ردیف ۳ و ستون C مخفی هستند، اما سلول‌هایشان هنوز مقادیر دارند.

| ردیف برگه کاری | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) دسترسی پیدا کنید و با [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) وضعیت مخفی بودن آن‌ها را بررسی کنید. این متد وضعیت مخفی بودن را بدون تغییر آن گزارش می‌دهد. در این فایل، B2 قابل مشاهده است، B3 به ردیف مخفی تعلق دارد و C2 به ستون مخفی؛ مثال به ترتیب `false`، `true` و `true` را چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم ترسیم، داده‌های نمودار را تازه کنید: کاربرگ تعبیه‌شده را با [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) نگه دارید و با [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) مجدداً بارگذاری کنید. هنگام شامل کردن تمام سلول‌ها، از [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) برای بازگرداندن بازه کامل، شامل دستهٔ مخفی فوریه، استفاده کنید. فقط تغییر پرچم برای تازه‌سازی داده‌های کش‌شدهٔ این مثال کافی نیست.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hidden-source-data.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $workbook = $chart->getChartData()->getChartDataWorkbook();
        echo "B2 hidden: " . (java_values($workbook->getCell(0, "B2")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "B3 hidden: " . (java_values($workbook->getCell(0, "B3")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "C2 hidden: " . (java_values($workbook->getCell(0, "C2")->isHidden()) ? "true" : "false"), PHP_EOL;

        $workbookData = $chart->getChartData()->readWorkbookStream();
        foreach ([true, false] as $visibleOnly) {
            $chart->setPlotVisibleCellsOnly($visibleOnly);

            // داده‌های نمودار را از کتاب‌کار تعبیه‌شده تازه کنید.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // بازهٔ منبع کامل را بازگردانید، شامل دسته‌های مخفی.
                $chart->getChartData()->setRange('Sheet1!$A$1:$C$4');
            }

            $presentation->save("hidden_cells_" . ($visibleOnly ? "true" : "false") . ".pptx", SaveFormat::Pptx);
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

مثال دو نسخه از ارائه را ذخیره می‌کند: یکی فقط با مقادیر خرده‌فروشی قابل مشاهده (10 و 20)، و دیگری با همهٔ شش مقدار. تصاویر زیر دو حالت ترسیم را نشان می‌دهند. ردیف ۳ و ستون C در هر دو کاربرگ تعبیه‌شده مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`true`) | همهٔ سلول‌ها (`false`) |
| --- | --- |
| ![فقط سلول‌های قابل مشاهده: مقادیر خرده‌فروشی 10 و 20 برای ژانویه و مارس.](hidden_cells_True.png) | ![همهٔ سلول‌ها: مقادیر خرده‌فروشی و عمده‌فروشی برای ژانویه، فوریه و مارس.](hidden_cells_False.png) |

یک سلول مخفی که دارای مقدار است، با یک سلول خالی متفاوت است. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) کنترل می‌کند که مقادیر گمشده چگونه نمایش داده شوند؛ این تنظیم شامل یا مستثنی کردن داده‌های منبع مخفی نمی‌شود. برای مثال به [کنترل نمایش سلول‌های خالی](/slides/fa/php-java/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **دریافت بازهٔ داده‌های یک نمودار**

قبل از به‌روزرسانی داده‌های کاربرگ در یک ارائهٔ موجود، بازه‌های منبع را بررسی کنید تا تشخیص دهید هر نمودار از کدام سلول‌های برگه کاری استفاده می‌کند. متد [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) بازهٔ دادهٔ فعلی را به‌صورت فرمولی معیّن به‌برگه کاری برمی‌گرداند، مانند `Sheet1!$A$1:$D$5`. در اینجا، `Sheet1` نام برگه کاری است، `!` آن را از بازهٔ سلولی جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را (به صورت شامل) مشخص می‌کند. علامت دلار نشان‌دهندهٔ ارجاع مطلق به ردیف و ستون است.

این متد بازهٔ فعلی را بدون تغییر نمودار یا کاربرگ می‌خواند. اگر نمودار از کاربرگ به‌عنوان منبع داده استفاده نکند، استثنا تولید می‌کند. برای اطلاعات بیشتر، به [مرجع API ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) مراجعه کنید.

این مثال یک ارائه را باز می‌کند و شکل‌های هر اسلاید را مستقیم برای وجود نمودار بررسی می‌کند. نام هر نمودار و بازهٔ منبع آن را چاپ می‌کند. اگر نموداری از کاربرگ استفاده نکند، پیام مربوطه را چاپ کرده و به نمودار بعدی ادامه می‌دهد.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
                $chart = $shape;
                try {
                    $range = $chart->getChartData()->getRange();
                    echo $chart->getName() . ": " . $range, PHP_EOL;
                } catch (JavaException $exception) {
                    if (java_instanceof($exception, new JavaClass("com.aspose.slides.exceptions.InvalidOperationException"))) {
                        echo $chart->getName() . ": The chart does not use a workbook as its data source.", PHP_EOL;
                    } else {
                        echo $chart->getName() . ": " . $exception->getMessage(), PHP_EOL;
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **خواندن و نوشتن داده‌های نمودار از کاربرگ**

Aspose.Slides for PHP via Java متدهای [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) و [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) را فراهم می‌کند که به شما اجازه می‌دهد کاربرگ‌های دادهٔ نمودار (شامل داده‌های ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که داده‌های نمودار باید به همان شکل یا ساختاری مشابه منبع سازماندهی شوند.

این مثال یک ارائه شامل یک نمودار به‌عنوان اولین شکل در اولین اسلاید دارد. کاربرگ تعبیه‌شده را به یک آرایهٔ بایت می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کاربرگ را دوباره می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **اعتبارسنجی طرح نمودار پس از تغییر کاربرگ**

هنگامی که کاربرگ تعبیه‌شده را با یک کاربرگ اصلاح‌شده جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) با خطای «اندیس خارج از محدوده» مواجه شود. قبل از نوشتن کاربرگ به‌روزشده به نمودار، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک نمودار که اولین شکل در اولین اسلاید است استفاده می‌کند. علامت‌گذاری نظرات جایی را نشان می‌دهد که ویرایش کاربرگ باید انجام شود؛ مثال اجرایی همان کاربرگ اصلی را بازمی‌نویسد و طرح را در حافظه اعتبارسنجی می‌کند.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        // بایت‌های کتاب‌کار را اینجا تغییر دهید، برای مثال با استفاده از Aspose.Cells.

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
        $chart->validateChartLayout();
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

پاک‌کردن مجموعه‌ها قبل از نوشتن کاربرگ، مراجع داده‌های منقضی‌شده را حذف می‌کند. پیش از استفاده از نمودار، هر سری و نگاشت دستهٔ مورد نیاز برای کاربرگ به‌روزشده را بازسازی کنید.

## **تنظیم یک سلول کاربرگ به‌عنوان برچسب دادهٔ نمودار**

می‌توانید از متن سلول‌های کاربرگ به‌عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با داده‌های پیش‌فرض به اسلاید اول یک ارائهٔ موجود اضافه می‌کند. از سلول‌های A10:A12 در برگه 0 برای اولین سه برچسب در سری اول استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌کند و ارائهٔ به‌روز شده را ذخیره می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $series->getLabels()->get_Item(0)->setValueFromCell($workbook->getCell(0, "A10", "Label 0 cell value"));
    $series->getLabels()->get_Item(1)->setValueFromCell($workbook->getCell(0, "A11", "Label 1 cell value"));
    $series->getLabels()->get_Item(2)->setValueFromCell($workbook->getCell(0, "A12", "Label 2 cell value"));

    $presentation->save("resultchart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **مدیریت برگه‌های کاری**

متد [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) دسترسی به برگه‌های کاری در یک کاربرگ نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و نام هر برگه کاری را در کنسول چاپ می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    for ($i = 0; $i < java_values($workbook->getWorksheets()->size()); $i++) {
        echo $workbook->getWorksheets()->get_Item($i)->getName(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **مشخص‌کردن نوع منبع داده**

این مثال یک نمودار ستونی 3بعدی با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع داده متفاوت تنظیم می‌کند. نام اول از یک رشتهٔ ثابت استفاده می‌کند؛ نام دوم از سلول C1 در برگه 0 استفاده می‌کند. شمارۀ [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) منبع را برای هر نام تعیین می‌کند. مثال ارائه را با نام‌های سری به‌روز شده ذخیره می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;
use aspose\slides\DataSourceType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $literalName = $chart->getChartData()->getSeries()->get_Item(0)->getName();

    $literalName->setDataSourceType(DataSourceType::StringLiterals);
    $literalName->setData("LiteralString");

    $cellName = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $nameCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, "C1", "NewCell");
    $cellName->setDataSourceType(DataSourceType::Worksheet);
    $cellName->setData($nameCell);

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تشخیص فرمت‌های کاربرگ تعبیه‌شدهٔ پشتیبانی‌نشده**

Aspose.Slides از فرمت کاربرگ باینری اکسل (.xlsb) که می‌تواند در برخی نمودارها تعبیه شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از متد `getEmbeddedWorkbookType` روی [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) به‌همراه شمارۀ [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) فرمت‌های پشتیبانی‌نشده را تشخیص داده و آن نمودارها را نادیده بگیرید. این مثال شکل‌های اسلاید اول یک ارائهٔ موجود را بررسی می‌کند، اشکال غیرنموداری را رد می‌کند و برای هر نمودار دارای کاربرگ .xlsb پیام تشخیصی چاپ می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartDataSourceType;
use aspose\slides\WorkbookType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
            continue;
        }

        $chart = $shape;
        $chartData = $chart->getChartData();
        $isInternalWorkbook = java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook;
        $isBinaryMacro = java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro;

        if ($isInternalWorkbook && $isBinaryMacro) {
            echo "Skipping a chart with an unsupported .xlsb workbook.", PHP_EOL;
            continue;
        }

        // داده‌های پشتیبانی‌شدهٔ کاربرگ نمودار را اینجا بخوانید یا اصلاح کنید.
    }
} finally {
    $presentation->dispose();
}
```

## **کاربرگ خارجی**

Aspose.Slides از استفاده از کاربرگ‌های خارجی به‌عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کاربرگ خارجی**

از [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) و [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) برای استخراج یک کاربرگ نمودار تعبیه‌شده به یک فایل و اتصال نمودار به آن کاربرگ خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و کاربرگ آن را استخراج می‌کند. پس از اتمام نوشتن فایل، کاربرگ خارجی را به‌عنوان منبع دادهٔ نمودار اختصاص می‌دهد و ارائهٔ لینک‌شده را ذخیره می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $workbookPath = new Java("java.io.File", "externalWorkbook1.xlsx");
    $workbookData = $chart->getChartData()->readWorkbookStream();
    try {
        $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
        try {
            $fileStream->write($workbookData);
        } finally {
            $fileStream->close();
        }
        $chart->getChartData()->setExternalWorkbook($workbookPath->getAbsolutePath());
        
        $presentation->save("externalWorkbook.pptx", SaveFormat::Pptx);
    } catch (JavaException $exception) {
        echo "Could not write the external workbook: " . $exception->getMessage(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```


### **تنظیم یک کاربرگ خارجی**

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) می‌توانید یک کاربرگ خارجی را به‌عنوان منبع دادهٔ یک نمودار اختصاص دهید. این متد همچنین می‌تواند مسیر به کاربرگ خارجی را به‌روزرسانی کند (اگر کاربرگ جابه‌جا شده باشد).

در حالی‌که نمی‌توانید داده‌های کاربرگ‌های ذخیره‌شده در مکان‌های دوردست یا منابع را مستقیماً ویرایش کنید، همچنان می‌توانید از چنین کاربرگ‌هایی به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کاربرگ خارجی فراهم شود، به‌طور خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک کاربرگ خارجی استفاده می‌کند که برگهٔ کاری آن به نام `Sheet1` شامل نام سری در B1، نام دسته‌ها در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار دایره‌ای ایجاد می‌کند، کاربرگ را لینک می‌کند و با استفاده از [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) بازهٔ A1:B4 را به یک سری و سه دسته اختصاص می‌دهد. ارائهٔ حاوی نمودار لینک‌شده را ذخیره می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $workbookFile = new Java("java.io.File", "externalWorkbook.xlsx");
    $workbookPath = $workbookFile->getAbsolutePath();

    $chartData->setExternalWorkbook($workbookPath);
    $chartData->setRange('Sheet1!$A$1:$B$4');

    $presentation->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

پارامتر `updateChartData` در [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) کنترل می‌کند که آیا کاربرگ بارگذاری شود یا نه.

* وقتی `updateChartData` برابر `false` باشد، فقط مسیر کاربرگ به‌روزرسانی می‌شود. دادهٔ نمودار از کاربرگ مقصد بارگذاری یا به‌روزرسانی نمی‌شود، بنابراین کاربرگ می‌تواند در دسترس نباشد.
* وقتی `updateChartData` برابر `true` باشد، دادهٔ نمودار از کاربرگ مقصد به‌روزرسانی می‌شود.

مثال زیر یک URL جایگزین را با `updateChartData` برابر `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شود و ارائه بدون بارگذاری کاربرگ در دسترس ذخیره می‌شود.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chart->getChartData()->setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    $presentation->save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **دریافت مسیر کاربرگ منبع دادهٔ خارجی یک نمودار**

برای شناسایی کاربرگی که به یک نمودار متصل است، بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کاربرگ آن را دریافت کنید.

این مثال اولین شکل در اولین اسلاید یک ارائهٔ دارای کاربرگ خارجی لینک‌شده را بررسی می‌کند. اگر این شکل یک نمودار لینک‌شده به کاربرگ خارجی باشد، متد [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) را در کنسول چاپ می‌کند. سپس یک کپی از ارائه را ذخیره می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ChartDataSourceType;

$presentation = new Presentation("externalWorkbook.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::ExternalWorkbook) {
            echo $chartData->getExternalWorkbookPath(), PHP_EOL;
        } else {
            echo "The chart does not use an external workbook.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **ویرایش داده‌های نمودار**

می‌توانید داده‌های کاربرگ‌های خارجی را همان‌گونه که داده‌های کاربرگ‌های داخلی را ویرایش می‌کنید، تغییر دهید. وقتی یک کاربرگ خارجی قابل بارگذاری نباشد، استثنا رخ می‌دهد.

این مثال از یک نمودار که اولین شکل در اولین اسلاید است و به یک کاربرگ خارجی قابل دسترس لینک شده استفاده می‌کند. مقدار نقطهٔ دادهٔ اول در سری اول را به 100 تنظیم می‌کند و ارائهٔ به‌روز شده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی لینک‌شده را به‌روز کند، بنابراین برای حفظ کاربرگ اصلی از یک کپی استفاده کنید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $series = $chart->getChartData()->getSeries();
        if (java_values($series->size()) > 0 && java_values($series->get_Item(0)->getDataPoints()->size()) > 0) {
            $valueCell = $series->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell();
            if (!java_is_null($valueCell)) {
                $valueCell->setValue(100);
                $presentation->save("presentation_out.pptx", SaveFormat::Pptx);
            } else {
                echo "The first data point is not linked to a workbook cell.", PHP_EOL;
            }
        } else {
            echo "The chart has no data points to edit.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **بازیابی کاربرگ از کش نمودار**

اگر یک نمودار از کاربرگ خارجی که گمشده یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کاربرگ نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) ایجاد کنید، [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) را فراخوانی کنید و [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) را به `true` تنظیم کنید قبل از باز کردن ارائه.

مثال PHP زیر داده‌های کاربرگ را برای یک نمودار که اولین شکل در اولین اسلاید است و به یک کاربرگ خارجی در دسترس نیست، بازیابی می‌کند. داده‌های بازیابی‌شده از طریق [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) و [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) دسترسی می‌شود:

```php
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;
use aspose\slides\LoadOptions;

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

        // خواندن یا اصلاح داده‌های کاربرگ بازیابی‌شده اینجا.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

اگر کاربرگ خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنا می‌اندازد. فقط زمانی که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ قابل قبول است، بازیابی را فعال کنید، زیرا کش ممکن است تغییرات اعمال‌شده به کاربرگ خارجی پس از آخرین به‌روزرسانی ارائه را شامل نشود.

## **پرسش‌های متداول**

**آیا می‌توانم تشخیص دهم یک نمودار خاص به کاربرگ خارجی یا تعبیه‌شده لینک شده است؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) و [path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) است؛ اگر منبع یک کاربرگ خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید یک فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کاربرگ‌های خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابه‌جایی کاربرگ ممکن است نیاز به به‌روزرسانی لینک داشته باشد.

**آیا می‌توانم از کاربرگ‌هایی که روی منابع/به‌اشتراک‌گذاری‌های شبکه قرار دارند استفاده کنم؟**

بله، چنین کاربرگ‌هایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. اما ویرایش مستقیم کاربرگ‌های دوردست از Aspose.Slides پشتیبانی نمی‌شود — آنها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [link to the external file](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) ذخیره می‌کند. ویرایش داده‌های نمودار مبتنی بر سلول می‌تواند فایل XLSX محلی لینک‌شده را نیز به‌روز کند. اگر نسخهٔ اصلی باید دست‌نخورده بماند، از یک کپی کاربرگ استفاده کنید.

**اگر فایل خارجی رمزگذاری شده باشد چه کاری باید انجام دهم؟**

Aspose.Slides هنگام لینک کردن رمز عبور دریافت نمی‌کند. یک روش معمول حذف محافظت پیش از لینک کردن یا تهیهٔ یک نسخهٔ رمزگشایی‌شده (به عنوان مثال با [Aspose.Cells](https://reference.aspose.com/cells/java/)) و لینک به آن نسخه است.

**آیا می‌توان چندین نمودار را به یک کاربرگ خارجی ارجاع داد؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در تمام نمودارها منعکس می‌شود.