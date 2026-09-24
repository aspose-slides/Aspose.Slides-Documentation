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
description: "Aspose.Slides برای PHP را از طریق جاوا کشف کنید: به‌راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنیم. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های کاربرگ دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی مرتبط با یک نمودار را بازیابی کنید و داده‌های نمودار را زمانی که کتاب‌کار در دسترس باشد، ویرایش کنید.

برای سلول‌های کتاب‌کار که داده‌های گمشده را نشان می‌دهند، به [کنترل نمایش سلول‌های خالی](/slides/fa/php-java/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر، و مقایسه خطی نمودار از حالت‌های نمایش موجود را ببینید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides متدهای [readWorkbookStream](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/#readWorkbookStream) و [writeWorkbookStream](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/#writeWorkbookStream) را فراهم می‌کند که به شما امکان خواندن و نوشتن کتاب‌کارهای داده نمودار (شامل داده‌های نمودار ویرایش‌شده با Aspose.Cells) را می‌دهد. **تذکر** این است که داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این کد PHP یک عملیات نمونه را نشان می‌دهد:

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

### **اعتبارسنجی چیدمان نمودار پس از تغییر کتاب‌کار**

زمانی که یک کتاب‌کار توکار را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار مجموعه‌های سری و دسته‌بندی اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود [Chart::validateChartLayout](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/validatechartlayout/) با خطای out‑of‑range ایندکس شکست بخورد. پیش از نوشتن کتاب‌کار به‌روز شده به نمودار، سری‌ها و دسته‌ها را پاک کنید.

```php
// پس از تغییر جریان کتاب‌کار (مثلاً با استفاده از Aspose.Cells)
$updatedWorkbook = $chartData->readWorkbookStream();

// ارجاع‌های داده موجود را پاک کنید.
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

پاک‌سازی مجموعه‌ها تضمین می‌کند که ساختار داده‌های نمودار با کتاب‌کار جدید همخوانی دارد و `validateChartLayout` بدون خطا تکمیل می‌شود.

## **تنظیم یک سلول کتاب‌کار به عنوان برچسب داده نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
1. یک نمودار حبابی (Bubble) با برخی داده‌ها اضافه کنید.
1. به سری‌های نمودار دسترسی پیدا کنید.
1. سلول کتاب‌کار را به عنوان برچسب داده تنظیم کنید.
1. ارائه را ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک سلول کتاب‌کار را به عنوان برچسب داده نمودار تنظیم کنید:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # نمونه‌سازی یک کلاس ارائه که نمایانگر یک فایل ارائه است
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

این کد PHP عملیاتی را نشان می‌دهد که در آن از متد [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#getWorksheets) برای دسترسی به مجموعه کاربرگ استفاده می‌شود:

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

این کد PHP نشان می‌دهد چگونه برای یک منبع داده نوعی را مشخص کنید:

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

## **تشخیص فرمت‌های پشتیبانی‌نشده کتاب‌کار توکار**

Aspose.Slides از فرمت کتاب‌کار باینری Excel (.xlsb) که می‌تواند در برخی نمودارها توکار شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از متد `getEmbeddedWorkbookType` روی [ChartData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/) همراه با شمارشگر [WorkbookType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/workbooktype/) فرمت‌های پشتیبانی‌نشده را شناسایی کرده و آن نمودارها را نادیده بگیرید.

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
      # کتاب‌کار توکار در قالب .xlsb است که پشتیبانی نمی‌شود.
      continue;
    }

    # داده‌های کتاب‌کار نمودار را در اینجا بخوانید یا تغییر دهید.
  }
} finally {
  $presentation->dispose();
}
```

## **کتاب‌کار خارجی**

Aspose.Slides از کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

با استفاده از متدهای **`readWorkbookStream`** و **`setExternalWorkbook`** می‌توانید یا یک کتاب‌کار خارجی از ابتدا ایجاد کنید یا یک کتاب‌کار داخلی را خارجی کنید.

این کد PHP فرآیند ایجاد کتاب‌کار خارجی را نشان می‌دهد:

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

با استفاده از متد **`setExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را به عنوان منبع داده برای یک نمودار اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی استفاده شود (اگر کتاب‌کار جابه‌جا شده باشد).

در حالی که نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌ها یا منابع از راه دور را ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای یک کتاب‌کار خارجی ارائه شود، به‌طور خودکار به مسیر کامل تبدیل می‌شود.

این کد PHP نشان می‌دهد چگونه یک کتاب‌کار خارجی تنظیم کنید:

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

پارامتر `ChartData` (در زیر متد `setExternalWorkbook`) برای تعیین اینکه آیا کتاب‌کار اکسل بارگذاری شود یا نه، استفاده می‌شود.

* وقتی مقدار `ChartData` برابر `false` تنظیم شود، تنها مسیر کتاب‌کار به‌روزرسانی می‌شود—داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شوند. شما ممکن است این تنظیم را زمانی که کتاب‌کار هدف وجود نداشته یا در دسترس نیست، استفاده کنید.
* وقتی مقدار `ChartData` برابر `true` تنظیم شود، داده‌های نمودار از کتاب‌کار هدف به‌روزرسانی می‌شوند.

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

### **دریافت مسیر کتاب‌کار منبع داده خارجی یک نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
1. یک شی برای شکل نمودار ایجاد کنید.
1. یک شی برای نوع منبع (`ChartDataSourceType`) که منبع داده نمودار را نمایندگی می‌کند، ایجاد کنید.
1. شرط مرتبط را بر اساس اینکه نوع منبع همان نوع منبع داده کتاب‌کار خارجی باشد، مشخص کنید.

این کد PHP عملیات را نشان می‌دهد:

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

### **ویرایش داده‌های نمودار**

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همان‌طور که تغییرات محتویات کتاب‌کارهای داخلی را اعمال می‌کنید، ویرایش کنید. هنگامی که یک کتاب‌کار خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

این کد PHP پیاده‌سازی فرآیند توصیف‌شده است:

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

### **بازیابی کتاب‌کار از حافظه‌نهی (Cache) نمودار**

اگر یک نمودار از کتاب‌کار خارجی استفاده کند که مفقود یا در دسترس نباشد، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های ذخیره‌شده در ارائه بازسازی کند. یک [LoadOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/) ایجاد کنید، آن را با [SpreadsheetOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/spreadsheetoptions/) پیکربندی کنید و قبل از باز کردن ارائه، متد [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) را با مقدار `true` فراخوانی کنید.

مثال PHP زیر یک ارائه را که نمودار آن به یک کتاب‌کار خارجی در دسترس نیست ارجاع می‌دهد، باز می‌کند و داده‌های بازیابی‌شده را از طریق [Chart::getChartData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/#getChartData) و [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/#getChartDataWorkbook) دسترسی می‌یابد:

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # داده‌های کتاب‌کار بازیابی شده را در اینجا بخوانید یا تغییر دهید.
} finally {
    $presentation->dispose();
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides یک استثنا پرتاب می‌کند. فقط زمانی بازیابی را فعال کنید که استفاده از داده‌های نمودار ذخیره‌شده یک گزینه پیش‌فرض قابل قبول باشد، زیرا ممکن است کش شامل تغییرات انجام‌شده بر روی کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه نباشد.

## **پرسش‌های متداول**

**آیا می‌توانم تعیین کنم آیا یک نمودار خاص به یک کتاب‌کار خارجی یا توکار پیوند دارد؟**

بله. یک نمودار دارای یک [نوع منبع داده](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/getdatasourcetype/) و یک [مسیر به کتاب‌کار خارجی](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/getexternalworkbookpath/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا اطمینان حاصل کنید که فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر یک مسیر نسبی را مشخص کنید، به‌طور خودکار به مسیر مطلق تبدیل می‌شود. این برای قابل حمل بودن پروژه مناسب است؛ اما توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌کارهای موجود در منابع/به‌اشتراک‌گذاری‌های شبکه استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع داده خارجی استفاده شوند. اما ویرایش کتاب‌کارهای از راه دور به‌صورت مستقیم از Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیره ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

خیر. ارائه یک [لینک به فایل خارجی](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/getexternalworkbookpath/) را ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. خود فایل خارجی هنگام ذخیره ارائه تغییر نمی‌کند.

**در صورتی که فایل خارجی با رمز عبور محافظت شده باشد چه کاری باید انجام دهم؟**

Aspose.Slides هنگام ایجاد لینک، رمز عبور را نمی‌پذیرد. یک روش متداول این است که پیش از آن حفاظت را حذف کنید یا یک نسخه رمزگشایی‌شده تهیه کنید (به‌عنوان مثال با استفاده از [Aspose.Cells](/cells/php-java/)) و به آن نسخه لینک دهید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی یکسان ارجاع دهند؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر نمودار در بارگذاری بعدی داده‌ها منعکس خواهد شد.