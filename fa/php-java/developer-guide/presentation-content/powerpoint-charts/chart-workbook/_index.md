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
description: "Aspose.Slides برای PHP را از طریق Java کشف کنید: به سادگی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنیم. این مقاله نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار خوانده و نوشته، از سلول‌های کتاب‌کار به عنوان برچسب‌های دادهٔ نمودار استفاده کنیم، به مجموعه‌های کاربرگ دسترسی پیدا کنیم و نوع منبع داده برای مقادیر نمودار را مشخص کنیم.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع دادهٔ نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص داده، مسیر کتاب‌کار خارجی مرتبط با یک نمودار را بازیابی کرده و هنگام در دسترس بودن کتاب‌کار، داده‌های نمودار را ویرایش کنیم.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides متدهای [readWorkbookStream](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/#readWorkbookStream) و [writeWorkbookStream](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/#writeWorkbookStream) را فراهم می‌کند که به شما امکان می‌دهد کتاب‌کارهای دادهٔ نمودار (حاوی داده‌های نمودار ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **نکته** این است که داده‌های نمودار باید به همان شیوه سازمان‌دهی شوند یا ساختاری مشابه منبع داشته باشند.

This PHP code demonstrates a sample operation:

```php
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $data = $chart->getChartData();
    $stream = $data->readWorkbookStream();
    $data->getSeries()->clear();
    $data->getCategories()->clear();
    $data->writeWorkbookStream($stream);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم یک سلول کتاب‌کار به عنوان برچسب دادهٔ نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.  
1. از طریق اندیس، مرجع یک اسلاید را دریافت کنید.  
1. یک نمودار حبابی با برخی داده‌ها اضافه کنید.  
1. به سری‌های نمودار دسترسی پیدا کنید.  
1. سلول کتاب‌کار را به عنوان برچسب داده تنظیم کنید.  
1. ارائه را ذخیره کنید.

This PHP code shows you to set a workbook cell as a chart data label:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # یک نمونه از کلاس ارائه که نمایانگر یک فایل ارائه است
  $pres = new Presentation("chart2.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $dataLabelCollection = $series->get_Item(0)->getLabels();
    $dataLabelCollection->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $dataLabelCollection->get_Item(0)->setValueFromCell($wb->getCell(0, "A10", $lbl0));
    $dataLabelCollection->get_Item(1)->setValueFromCell($wb->getCell(0, "A11", $lbl1));
    $dataLabelCollection->get_Item(2)->setValueFromCell($wb->getCell(0, "A12", $lbl2));
    $pres->save("resultchart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **مدیریت کاربرگ‌ها**

این کد PHP عملی را نشان می‌دهد که در آن متد [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#getWorksheets) برای دسترسی به مجموعهٔ کاربرگ‌ها استفاده می‌شود:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    for($i = 0; $i < java_values($wb->getWorksheets()->size()) ; $i++) {
      echo($wb->getWorksheets()->get_Item($i)->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **مشخص کردن نوع منبع داده**

این کد PHP نشان می‌دهد چگونه برای یک منبع داده یک نوع را مشخص کنید:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $val = $chart->getChartData()->getSeries()->get_Item(0)->getName();
    $val->setDataSourceType(DataSourceType::StringLiterals);
    $val->setData("LiteralString");
    $val = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $val->setData($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1", "NewCell"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تشخیص فرمت‌های کتاب‌کار جاسازی‌شدهٔ پشتیبانی‌نشده**

Aspose.Slides از فرمت کتاب‌کار باینری Excel (.xlsb) که می‌تواند در برخی نمودارها جاسازی شود پشتیبانی نمی‌کند. می‌توانید از متد `getEmbeddedWorkbookType` در [ChartData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/) همراه با شمارش‌گر [WorkbookType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/workbooktype/) برای شناسایی فرمت‌های پشتیبانی‌نشده و صرف‌نظر کردن از آن نمودارها استفاده کنید.

```php
$presentation = new Presentation("sample.pptx");
try {
  $slide = $presentation->getSlides()->get_Item(0);
  $shapes = $slide->getShapes();

  for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
    $shape = $shapes->get_Item($shapeIndex);

    if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
      continue;
    }

    $chart = $shape;
    $chartData = $chart->getChartData();

    if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook &&
        java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro) {
      # کتاب‌کار جاسازی‌شده در قالب .xlsb است که پشتیبانی نمی‌شود.
      continue;
    }

    # در اینجا داده‌های کتاب‌کار نمودار را بخوانید یا ویرایش کنید.
  }
} finally {
  $presentation->dispose();
}
```

## **کتاب‌کار خارجی**

Aspose.Slides از کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

با استفاده از متدهای **`readWorkbookStream`** و **`setExternalWorkbook`** می‌توانید یا یک کتاب‌کار خارجی را از ابتدا ایجاد کنید یا یک کتاب‌کار داخلی را به کتاب‌کار خارجی تبدیل کنید.

This PHP code demonstrates the external workbook creation process:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $workbookPath = "externalWorkbook1.xlsx";
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
    $Array = new java_class("java.lang.reflect.Array");
    try {
      $workbookData = $chart->getChartData()->readWorkbookStream();
      $fileStream->write($workbookData, 0, $Array->getLength($workbookData));
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
    $chart->getChartData()->setExternalWorkbook($workbookPath);
    $pres->save("externalWorkbook.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **تنظیم یک کتاب‌کار خارجی**

با استفاده از متد **`setExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را به عنوان منبع دادهٔ یک نمودار اختصاص دهید. این متد همچنین می‌تواند برای به‌روز‌رسانی مسیر کتاب‌کار خارجی استفاده شود (اگر کتاب‌کار جابجا شده باشد).

اگرچه نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌ها یا منابع از راه دور را ویرایش کنید، همچنان می‌توانید از این کتاب‌کارها به عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای یک کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌گردد.

This PHP code shows you how to set an external workbook:

```php
  # یک نمونه از کلاس Presentation ایجاد می‌کند
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, false);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("externalWorkbook.xlsx");
    $chartData->getSeries()->add($chartData->getChartDataWorkbook()->getCell(0, "B1"), ChartType::Pie);
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B2"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B3"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B4"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A2"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A3"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A4"));
    $pres->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

پارامتر `ChartData` (در زیر متد `setExternalWorkbook`) برای تعیین این که آیا یک کتاب‌کار اکسل بارگذاری شود یا نه استفاده می‌شود.

* وقتی مقدار `ChartData` روی `false` تنظیم شود، فقط مسیر کتاب‌کار به‌روز می‌شود—داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روز نمی‌شوند. ممکن است بخواهید از این تنظیم زمانی استفاده کنید که کتاب‌کار هدف وجود نداشته باشد یا در دسترس نباشد.  
* وقتی مقدار `ChartData` روی `true` تنظیم شود، داده‌های نمودار از کتاب‌کار هدف به‌روز می‌شوند.

```php
  # یک نمونه از کلاس Presentation ایجاد می‌کند
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("http://path/doesnt/exists", false);
    $pres->save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **دریافت مسیر کتاب‌کار منبع دادهٔ خارجی یک نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.  
1. از طریق اندیس، مرجع یک اسلاید را دریافت کنید.  
1. یک شی برای شکل نمودار ایجاد کنید.  
1. یک شی برای نوع منبع (`ChartDataSourceType`) که نمایانگر منبع دادهٔ نمودار است ایجاد کنید.  
1. شرط مربوطه را بر اساس اینکه نوع منبع همان نوع منبع دادهٔ کتاب‌کار خارجی باشد، مشخص کنید.

This PHP code demonstrates the operation:

```php
  # یک نمونه از کلاس Presentation ایجاد می‌کند
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # ارائه را ذخیره می‌کند
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ویرایش دادهٔ نمودار**

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همان‌گونه که محتوای کتاب‌کارهای داخلی را تغییر می‌دهید ویرایش کنید. هنگامی که یک کتاب‌کار خارجی قابل بارگذاری نباشد، استثنایی پرتاب می‌شود.

This PHP code is an implementation of the described process:

```php
  # یک نمونه از کلاس Presentation ایجاد می‌کند
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chartData = $chart->getChartData();
    $chartData->getSeries()->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell()->setValue(100);
    $pres->save("presentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **بازیابی یک کتاب‌کار از کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی که موجود نیست یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. قبل از باز کردن ارائه، [LoadOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/) را ایجاد کنید، آن را با [SpreadsheetOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/spreadsheetoptions/) پیکربندی کنید و متد [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) را با مقدار `true` صدا بزنید.

The following PHP example opens a presentation whose chart references an unavailable external workbook and accesses the recovered data through [Chart::getChartData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/#getChartData) and [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # داده‌های کتاب‌کار بازیابی‌شده را در اینجا بخوانید یا ویرایش کنید.
} finally {
    $presentation->dispose();
}
```

If the external workbook is unavailable and recovery is disabled, Aspose.Slides throws an exception. Enable recovery only when using the cached chart data is an acceptable fallback, because the cache may not contain changes made to the external workbook after the presentation was last updated.

## **سؤالات متداول**

**آیا می‌توانم تعیین کنم که آیا یک نمودار خاص به کتاب‌کار خارجی یا جاسازی‌شده مرتبط است؟**  
بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/getdatasourcetype/) و [مسیر به کتاب‌کار خارجی](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/getexternalworkbookpath/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**  
بله. اگر مسیر نسبی را مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این برای قابلیت حمل پروژه مفید است؛ اما توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌کارهای قرار گرفته در منابع/به‌اشتراک‌گذاری‌های شبکه استفاده کنم؟**  
بله، چنین کتاب‌کارهایی می‌توانند به عنوان منبع دادهٔ خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌کارهای راه دور از Aspose.Slides پشتیبانی نمی‌شود؛ آنها فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه فایل XLSX خارجی را بازنویسی می‌کند؟**  
خیر. ارائه یک [لینک به فایل خارجی](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/getexternalworkbookpath/) را ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی هنگام ذخیرهٔ ارائه تغییر نمی‌کند.

**در صورتی که فایل خارجی با رمز عبور محافظت شده باشد چه باید کرد؟**  
Aspose.Slides هنگام لینک‌دادن رمز عبور را نمی‌پذیرد. رویکرد معمول این است که پیش از آن محافظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](/cells/php-java/)) تهیه کنید و به آن نسخه لینک دهید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی ارجاع دهند؟**  
بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره داشته باشند، به‌روزرسانی آن فایل در هر نمودار در بارگذاری بعدی داده‌ها منعکس می‌شود.