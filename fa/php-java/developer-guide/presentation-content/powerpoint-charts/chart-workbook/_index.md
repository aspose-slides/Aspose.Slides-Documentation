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
- ورق کاری
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب‌کار
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "Aspose.Slides برای PHP از طریق Java را کشف کنید: به راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با کتاب‌کارهای نموداری در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب داده‌های نمودار استفاده کنید، به مجموعه‌های صفحه‌گسترده دسترسی پیدا کنید و نوع منبع داده را برای مقادیر نمودار مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع دادهٔ نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی مرتبط با یک نمودار را دریافت کنید و داده‌های نمودار را هنگامی که کتاب‌کار در دسترس باشد، ویرایش کنید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب کار**
Aspose.Slides روش‌های [readWorkbookStream](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/#readWorkbookStream) و [writeWorkbookStream](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/#writeWorkbookStream) را فراهم می‌کند که به شما اجازه می‌دهند کتاب‌کارهای دادهٔ نمودار (حاوی داده‌های نمودار ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **Note** داده‌های نمودار باید به همان شیوه سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

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

### **اعتبارسنجی طرح نمودار پس از تغییر کتاب کار**

هنگامی که یک کتاب‌کار توکار را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار مجموعه‌های سری و دسته‌بندی اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شکست [Chart::validateChartLayout](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/validatechartlayout/) با خطای out‑of‑range شود. قبل از نوشتن کتاب‌کار به‌روزرسانی‌شده به نمودار، سری‌ها و دسته‌ها را پاک کنید.

```php
// پس از اصلاح جریان کتاب‌کار (مثلاً با استفاده از Aspose.Cells)
$updatedWorkbook = $chartData->readWorkbookStream();

// Clear existing data references.
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

پاک‌سازی مجموعه‌ها تضمین می‌کند که ساختار دادهٔ نمودار با کتاب‌کار جدید سازگار باشد و `validateChartLayout` بدون خطا کامل شود.

## **تنظیم یک سلول کتاب کار به عنوان برچسب داده نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک نمودار حبابی با برخی داده‌ها اضافه کنید.  
4. به سری‌های نمودار دسترسی پیدا کنید.  
5. سلول کتاب‌کار را به عنوان برچسب داده تنظیم کنید.  
6. ارائه را ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک سلول کتاب‌کار را به عنوان برچسب دادهٔ نمودار تنظیم کنید:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # یک شی از کلاس Presentation ایجاد می‌کند که فایل ارائه را نمایان می‌سازد
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

## **مدیریت ورق‌های کاری**

این کد PHP عملیاتی را نشان می‌دهد که در آن از روش [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#getWorksheets) برای دسترسی به مجموعهٔ ورق‌های کاری استفاده می‌شود:

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

## **تشخیص فرمت‌های کتاب کار جاسازی شدهٔ پشتیبانی‌نشده**

Aspose.Slides از فرمت کتاب‌کار باینری اکسل (.xlsb) که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از متد `getEmbeddedWorkbookType` روی [ChartData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/workbooktype/) فرمت‌های پشتیبانی‌نشده را شناسایی و آن نمودارها را نادیده بگیرید.

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
      # کتاب‌کار جاسازی شده در قالب .xlsb است که پشتیبانی نمی‌شود.
      continue;
    }

    # داده‌های کتاب‌کار نمودار را در اینجا بخوانید یا ویرایش کنید.
  }
} finally {
  $presentation->dispose();
}
```

## **کتاب کار خارجی**

Aspose.Slides از کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب کار خارجی**

با استفاده از روش‌های **`readWorkbookStream`** و **`setExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را از صفر ایجاد کنید یا یک کتاب‌کار داخلی را خارجی کنید.

این کد PHP فرایند ایجاد کتاب کار خارجی را نشان می‌دهد:

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

### **تنظیم یک کتاب کار خارجی**

با استفاده از متد **`setExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را به عنوان منبع دادهٔ یک نمودار اختصاص دهید. این متد همچنین می‌تواند مسیر کتاب‌کار خارجی را به‌روزرسانی کند (اگر کتاب‌کار جابه‌جا شده باشد).

در حالی که نمی‌توانید داده‌ها را در کتاب‌کارهای ذخیره‌شده در مکان‌های دوردست یا منابع ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

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

پارامتر `ChartData` (در زیر متد `setExternalWorkbook`) برای تعیین این که آیا کتاب‌کار اکسل بارگذاری شود یا نه استفاده می‌شود.

* وقتی مقدار `ChartData` روی `false` تنظیم شود، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود—داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شوند. می‌توانید این تنظیم را زمانی که کتاب‌کار هدف وجود ندارد یا در دسترس نیست، استفاده کنید.  
* وقتی مقدار `ChartData` روی `true` تنظیم شود، داده‌های نمودار از کتاب‌کار هدف به‌روزرسانی می‌شوند.

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

### **دریافت مسیر کتاب کار منبع دادهٔ خارجی یک نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک شی برای شکل نمودار ایجاد کنید.  
4. یک شی برای نوع منبع (`ChartDataSourceType`) ایجاد کنید که منبع دادهٔ نمودار را نشان می‌دهد.  
5. شرط مرتبط را بر اساس این که نوع منبع همان نوع منبع دادهٔ کتاب‌کار خارجی باشد، مشخص کنید.

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

می‌توانید داده‌ها را در کتاب‌کارهای خارجی همانند تغییر محتویات کتاب‌کارهای داخلی ویرایش کنید. وقتی یک کتاب‌کار خارجی قابل بارگذاری نباشد، استثنایی پرتاب می‌شود.

این کد PHP پیاده‌سازی فرایند توضیح‌شده را نشان می‌دهد:

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

### **بازیابی یک کتاب کار از کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی استفاده می‌کند که گم شده یا در دسترس نیست، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک شیء [LoadOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/) ایجاد کنید، آن را با [SpreadsheetOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/spreadsheetoptions/) پیکربندی کنید و قبل از باز کردن ارائه متد [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) را روی `true` تنظیم کنید.

مثال PHP زیر یک ارائه را که نمودار آن به کتاب‌کار خارجی در دسترس نیست ارجاع می‌دهد باز می‌کند و داده‌های بازیابی‌شده را از طریق [Chart::getChartData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/#getChartData) و [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/#getChartDataWorkbook) دسترسی می‌دهد:

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

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنایی پرتاب می‌کند. تنها وقتی که استفاده از داده‌های نمودار کش‌شده قابل قبول باشد، بازیابی را فعال کنید، زیرا کش ممکن است شامل تغییرات انجام‌شده بر روی کتاب‌کار خارجی پس از به‌روزرسانی آخرین ارائه نباشد.

## **FAQ**

**آیا می‌توانم تعیین کنم که آیا یک نمودار خاص به کتاب‌کار خارجی یا توکار لینک دارد؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/getdatasourcetype/) و [path to an external workbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/getexternalworkbookpath/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این برای قابل حمل بودن پروژه مفید است؛ اما توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌کارهای قرار گرفته بر روی منابع/به‌اشتراک‌گذاری‌های شبکه استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به عنوان منبع دادهٔ خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌کارهای دوردست از طریق Aspose.Slides پشتیبانی نمی‌شود—فقط می‌توانند به عنوان منبع مورد استفاده قرار گیرند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

نه. ارائه یک [link to the external file](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/getexternalworkbookpath/) را ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی هنگام ذخیرهٔ ارائه تغییر نمی‌کند.

**اگر فایل خارجی پسورد داشته باشد چه باید کرد؟**

Aspose.Slides هنگام لینک کردن پسوردی را نمی‌پذیرد. رویکرد معمول این است که پیشاپیش حفاظت را بردارید یا یک نسخهٔ رمزگشایی‌شده آماده کنید (به عنوان مثال با استفاده از [Aspose.Cells](/cells/php-java/)) و به آن نسخه لینک کنید.

**آیا می‌توان چندین نمودار را به همان کتاب‌کار خارجی ارجاع داد؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به همان فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در هر نمودار منعکس خواهد شد.