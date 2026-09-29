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
- کاربرگ
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب‌کار
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "Aspose.Slides برای PHP از طریق Java را کشف کنید: به‌صورت راحت کتاب‌کارهای نمودار در قالب‌های PowerPoint و OpenDocument را مدیریت کنید تا داده‌های ارائه‌ی خود را بهینه‌سازی کنید."
---
## **مروری کلی**

این مقاله نحوه کار با کتاب‌های کاری نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه می‌توان داده‌های نمودار را از طریق جریان‌های کتاب‌کار خواند و نوشت، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار استفاده کرد، به مجموعه‌های کاربرگ دسترسی یافت و نوع منبع داده برای مقادیر نمودار را مشخص نمود.

همچنین کار با کتاب‌های کاری خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص داده شود، مسیر کتاب‌کار خارجی پیوند خورده به یک نمودار بازیابی شود و داده‌های نمودار هنگام در دسترس بودن کتاب‌کار ویرایش گردد.

برای سلول‌های کتاب‌کاری که نمایانگر داده‌های مفقود هستند، به [Control the Display of Empty Cells](/slides/fa/php-java/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر و مقایسهٔ نمودار خطی حالت‌های نمایش موجود را ببینید.

## **شامل کردن داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/setplotvisiblecellsonly/) برای کنترل اینکه آیا یک نمودار فقط داده‌های ردیف‌ها و ستون‌های مخفی کاربرگ را ترسیم می‌کند یا نه استفاده کنید. مقدار `true` فقط سلول‌های قابل مشاهده را ترسیم می‌کند، در حالی که مقدار `false` هر دو سلول قابل مشاهده و مخفی را شامل می‌شود. این تنظیم فقط بر ترسیم نمودار تأثیر می‌گذارد؛ ردیف‌ها یا ستون‌های کاربرگ را مخفی یا آشکار نمی‌کند.

فایل [hidden-source-data.pptx](hidden-source-data.pptx) را دانلود کنید و در پوشهٔ کاری خود قرار دهید. اسلاید اول آن حاوی یک نمودار ستونی به عنوان اولین شکل است. کاربرگ توکار، `Sheet1`، شامل بازهٔ منبع زیر است: `A1:C4`. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آن‌ها هنوز مقادیر دارند.

| ردیف کاربرگ | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

از طریق [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/getchartdataworkbook/) به سلول‌های منبع دسترسی پیدا کنید و با استفاده از [ChartDataCell::isHidden](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/ishidden/) وضعیت مخفی بودن آن‌ها را بررسی کنید. این روش بدون تغییر وضعیت، وضعیت مخفی بودن را گزارش می‌دهد. در این فایل، B2 قابل مشاهده است، B3 به ردیف مخفی تعلق دارد و C2 به ستون مخفی؛ مثال به ترتیب `false`، `true` و `true` را چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم ترسیم، داده‌های نمودار را تازه‌سازی کنید: کتاب‌کار توکار را با [readWorkbookStream](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/readworkbookstream/) نگه دارید و با [writeWorkbookStream](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/writeworkbookstream/) دوباره بارگذاری کنید. هنگام شامل کردن تمام سلول‌ها، همچنین از [setRange](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/setrange/) استفاده کنید تا بازهٔ کامل، شامل دستهٔ مخفی فوریه، بازگردانده شود. تنها تغییر پرچم برای تازه‌سازی داده‌های کش‌شدهٔ این نمونه کافی نیست.

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

            // داده‌های نمودار را از کتاب‌کار توکار تازه‌سازی کنید.
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

مثال `hidden_cells_true.pptx` را فقط با مقادیر قابل مشاهدهٔ خرده‌فروشی (10 و 20) ذخیره می‌کند و `hidden_cells_false.pptx` را با تمام شش مقدار. تصویرهای زیر دو حالت ترسیم را نشان می‌دهند. ردیف 3 و ستون C در هر دو کتاب‌کار توکار مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`true`) | تمام سلول‌ها (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول مخفی حاوی مقدار، متفاوت از یک سلول خالی است. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/setdisplayblanksas/) کنترل می‌کند مقادیر گمشده چگونه نمایش داده شوند؛ این تنظیم شامل یا حذف داده‌های منبع مخفی نمی‌شود. برای مثال به [Control the Display of Empty Cells](/slides/fa/php-java/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides for PHP via Java متدهای [readWorkbookStream](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/readworkbookstream/) و [writeWorkbookStream](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/writeworkbookstream/) را فراهم می‌کند که به شما امکان می‌دهد کتاب‌های کاری داده‌های نمودار (شامل داده‌های ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **نکته** این است که داده‌های نمودار باید به همان شیوه سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این مثال `chart.pptx` را باز می‌کند؛ این فایل باید در اسلاید اول خود یک نمودار به عنوان اولین شکل داشته باشد. کتاب‌کار توکار را به یک آرایهٔ بایت می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را دوباره می‌نویسد. تغییرات فقط در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

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

### **اعتبارسنجی چیدمان نمودار پس از تغییر کتاب‌کار**

زمانی که کتاب‌کار توکار را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند موجب شود که [Chart::validateChartLayout](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/validatechartlayout/) با خطای «index-out-of-range» ناموفق باشد. قبل از نوشتن کتاب‌کار به‌روز شده به نمودار، سری‌ها و دسته‌های موجود را پاک کنید. این مثال به `chart.pptx` با یک نمودار به عنوان اولین شکل در اسلاید اول نیاز دارد. علامت‌گذاری‌های نظری نشان می‌دهند که ویرایش کتاب‌کار در کجا انجام می‌شود؛ مثال اجرایی کتاب‌کار اصلی را بازمی‌نویسد و چیدمان را در حافظه اعتبارسنجی می‌کند.

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

        // در اینجا بایت‌های کتاب‌کار را تغییر دهید، به عنوان مثال با استفاده از Aspose.Cells.

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

پاک‌سازی مجموعه‌ها قبل از نوشتن کتاب‌کار، مراجع داده‌ای کهنه را حذف می‌کند. قبل از استفاده از نمودار، سری‌ها و نقشه‌های دسته‌بندی لازم برای کتاب‌کار به‌روز‌شده را بازسازی کنید.

## **تنظیم یک سلول کتاب‌کار به عنوان برچسب دادهٔ نمودار**

می‌توانید از متن سلول‌های کتاب‌کار به عنوان برچسب‌های دادهٔ نمودار استفاده کنید. گام‌های زیر نشان می‌دهد چگونه برچسب‌ها را در یک نمودار حبابی به سلول‌های کتاب‌کار داده متصل کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.  
1. اسلاید اول را با ایندکس صفر‑پایه دسترسی پیدا کنید.  
1. یک نمودار حبابی با داده‌های پیش‌فرض اضافه کنید.  
1. سری نمودار را دسترسی پیدا کنید.  
1. سلول کتاب‌کار را به عنوان برچسب داده تنظیم کنید.  
1. ارائه را ذخیره کنید.

این مثال `chart2.pptx` را باز می‌کند؛ این فایل باید حداقل یک اسلاید داشته باشد و یک نمودار حبابی با داده‌های پیش‌فرض به آن اضافه می‌کند. از سلول‌های A10:A12 در کاربرگ 0 برای اولین سه برچسب در اولین سری استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌کند و نتیجه را در `resultchart.pptx` ذخیره می‌کند.

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

## **مدیریت کاربرگ‌ها**

متد [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/getworksheets/) دسترسی به کاربرگ‌های موجود در یک کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و نام هر کاربرگ را در کنسول چاپ می‌نماید.

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

## **مشخص کردن نوع منبع داده**

این مثال یک نمودار ستونی ۳‑بعدی با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع داده متفاوت تنظیم می‌نماید. نام اول از یک رشتهٔ متنی استفاده می‌کند؛ نام دوم از سلول C1 در کاربرگ 0 می‌گیرد. شمارشگر [DataSourceType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/datasourcetype/) منبع هر نام را انتخاب می‌کند. نتیجه در `pres.pptx` ذخیره می‌شود.

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

## **تشخیص قالب‌های کتاب‌کار توکار پشتیبانی‌نشده**

Aspose.Slides قالب کتاب‌کار دودویی اکسل (.xlsb) را که می‌تواند در برخی نمودارها توکار شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از متد `getEmbeddedWorkbookType` در [ChartData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/) به همراه شمارشگر [WorkbookType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/workbooktype/) قالب‌های پشتیبانی‌نشده را شناسایی و آن نمودارها را نادیده بگیرید. این مثال اشکال موجود در اسلاید اول `sample.pptx` را بررسی می‌کند، اشکال غیرنموداری را عبور می‌دهد و برای هر نمودار دارای کتاب‌کار .xlsb پیغام تشخیصی چاپ می‌کند.

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

        // در اینجا داده‌های کتاب‌کار نمودار پشتیبانی‌شده را بخوانید یا تغییر دهید.
    }
} finally {
    $presentation->dispose();
}
```

## **کتاب‌کار خارجی**

Aspose.Slides پشتیبانی می‌کند که کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها استفاده شوند.

### **ایجاد یک کتاب‌کار خارجی**

از [readWorkbookStream](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/readworkbookstream/) و [setExternalWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/setexternalworkbook/) برای استخراج کتاب‌کار توکار یک نمودار به یک فایل و پیوند نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند، کتاب‌کار آن را در `externalWorkbook1.xlsx` می‌نویسد و قبل از اختصاص فایل به عنوان منبع دادهٔ نمودار، نوشتن فایل را کامل می‌کند. ارائهٔ پیوند خورده در `externalWorkbook.pptx` ذخیره می‌شود.

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

### **تنظیم یک کتاب‌کار خارجی**

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/setexternalworkbook/) می‌توانید یک کتاب‌کار خارجی را به یک نمودار به عنوان منبع داده اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورتی که جابه‌جا شده باشد) استفاده شود.

در حالی که نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌های دوردست یا منابع را ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال به `externalWorkbook.xlsx` در پوشهٔ کاری نیاز دارد. کاربرگ با نام `Sheet1` باید شامل یک نام سری در B1، اسامی دسته در A2:A4 و مقادیر عددی در B2:B4 باشد. مثال یک نمودار دایره‌ای ایجاد می‌کند، کتاب‌کار را پیوند می‌دهد و با استفاده از [setRange](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/setrange/) بازهٔ A1:B4 را به یک سری و سه دسته‌بندی نگاشت می‌کند. نتیجه در `Presentation_with_externalWorkbook.pptx` ذخیره می‌شود.

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

پارامتر `updateChartData` متد [setExternalWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/setexternalworkbook/) کنترل می‌کند آیا کتاب‌کار بارگذاری شود یا نه.

* وقتی `updateChartData` برابر `false` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود. داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روز نمی‌شود، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.  
* وقتی `updateChartData` برابر `true` باشد، داده‌های نمودار از کتاب‌کار هدف به‌روز می‌شود.

مثال زیر یک URL جایگزین را با `updateChartData` برابر `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شوند و ارائه بدون بارگذاری کتاب‌کار ناموجود ذخیره می‌شود.

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

### **دریافت مسیر کتاب‌کار منبع دادهٔ خارجی یک نمودار**

برای شناسایی کتاب‌کاری که به یک نمودار پیوند خورده است، ابتدا بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند یا نه. اگر بله، می‌توانید مسیر کتاب‌کار را با دنبال کردن گام‌های زیر بازیابی کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.  
1. اسلاید اول را با ایندکس صفر‑پایه دسترسی پیدا کنید.  
1. بررسی کنید که اولین شکل یک نمودار است.  
1. نوع منبع دادهٔ نمودار را بخوانید.  
1. اگر منبع یک کتاب‌کار خارجی باشد، مسیر آن را بخوانید.

این مثال `externalWorkbook.pptx` را که در مثال پیشین ایجاد شد، باز می‌کند و اولین شکل در اسلاید اول را بررسی می‌نماید. اگر یک نمودار پیوند خورده به کتاب‌کار خارجی باشد، [getExternalWorkbookPath](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/getexternalworkbookpath/) را در کنسول چاپ می‌کند. سپس یک کپی از ارائه را در `Result.pptx` ذخیره می‌کند.

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

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را به همان روشی که داده‌های کتاب‌کارهای داخلی را ویرایش می‌کنید، تغییر دهید. زمانی که کتاب‌کار خارجی قابل بارگذاری نباشد، استثنائی پرتاب می‌شود.

این مثال به `presentation.pptx` با یک نمودار به عنوان اولین شکل در اولین اسلاید و یک کتاب‌کار خارجی قابل دسترسی نیاز دارد. مقدار پشتیبانی‌شده از سلول برای اولین نقطه دادهٔ اولین سری را به 100 تنظیم می‌کند و ارائه را در `presentation_out.pptx` ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX پیوند خورده را به‌روز کند، بنابراین در صورت نیاز به حفظ کتاب‌کار اصلی، از یک کپی استفاده کنید.

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

### **بازیابی کتاب‌کار از حافظهٔ کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی که موجود نیست یا در دسترس نیست استفاده می‌کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. قبل از باز کردن ارائه، یک [LoadOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/) ایجاد کنید، با [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) تنظیم کنید و [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) را روی `true` قرار دهید.

مثال PHP زیر `presentation.pptx` را باز می‌کند؛ اولین شکل در اولین اسلاید آن باید یک نمودار باشد که به کتاب‌کار خارجی ناموجود ارجاع می‌دهد، و داده‌های بازیابی‌شده را از طریق [Chart::getChartData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/getchartdata/) و [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/getchartdataworkbook/) دسترسی می‌یابد:

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

        // در اینجا داده‌های کتاب‌کار بازیابی‌شده را بخوانید یا تغییر دهید.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

اگر کتاب‌کار خارجی ناموجود باشد و بازیابی غیرفعال باشد، Aspose.Slides استثنائی پرتاب می‌کند. فقط زمانی بازیابی را فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ قابل قبول باشد، زیرا ممکن است این کش شامل تغییرات انجام‌ شده بر روی کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه نباشد.

## **سوالات متداول**

**آیا می‌توانم تشخیص دهم که یک نمودار خاص به کتاب‌کار خارجی یا توکار پیوند دارد؟**  
بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/getdatasourcetype/) و [path to an external workbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/getexternalworkbookpath/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا اطمینان حاصل کنید که یک فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**  
بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابجایی کتاب‌کار ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از کتاب‌کارهایی که در منابع/اشتراک‌های شبکه‌ای قرار دارند استفاده کنم؟**  
بله، چنین کتاب‌کارهایی می‌توانند به عنوان منبع دادهٔ خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌کارهای دوردست از Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**  
ارائه یک [link to the external file](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/getexternalworkbookpath/) ذخیره می‌کند. ویرایش داده‌های نموداری که از سلول پشتیبانی می‌شود می‌تواند فایل XLSX محلی پیوند خورده را نیز به‌روز کند. اگر فایل اصلی باید دست‌نخورده بماند، از یک کپی کتاب‌کار استفاده کنید.

**اگر فایل خارجی دارای رمز عبور باشد چه باید انجام دهم؟**  
Aspose.Slides هنگام پیوند، رمز عبور را قبول نمی‌کند. روش رایج حذف پیش‌ازوقت حفاظت یا تهیهٔ یک کپی رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/java/)) و پیوند به آن کپی است.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی اشاره کنند؟**  
بله. هر نمودار پیوند خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در تمام نمودارها منعکس می‌شود.