---
title: مدیریت سلول‌های جدول در ارائه‌ها با استفاده از PHP
linktitle: مدیریت سلول‌ها
type: docs
weight: 30
url: /fa/php-java/manage-cells/
keywords:
- سلول جدول
- ادغام سلول‌ها
- حذف حاشیه
- تقسیم سلول
- تصویر در سلول
- رنگ پس‌زمینه
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "به راحتی سلول‌های جدول را در PowerPoint با Aspose.Slides برای PHP مدیریت کنید. دسترسی، اصلاح و استایل‌دهی سریع به سلول‌ها را برای خودکارسازی یک‌پارچه اسلایدها فراگیرید."
---
## **بررسی کلی**

Aspose.Slides به شما امکان دسترسی و ویرایش سلول‌های جدول در ارائه‌های PowerPoint را می‌دهد. این مقاله توضیح می‌دهد که چگونه سلول‌های جدول ادغام‌شده را شناسایی کنید، خطوط مرزی سلول‌ها را حذف کنید، پس از ادغام یا تقسیم سلول‌ها با شماره‌گذاری سلول‌ها کار کنید، رنگ پس‌زمینه یک سلول را تغییر دهید و یک تصویر را داخل سلول جدول اضافه کنید. مثال‌ها نشان می‌دهند که چگونه یک ارائه را ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روزرسانی کنید و ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره نمایید.

## **شناسایی سلول جدول ادغام‌شده**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
2. جدول را از اولین اسلاید دریافت کنید. 
3. در سطرها و ستون‌های جدول پیمایش کنید تا سلول‌های ادغام‌شده را پیدا کنید.
4. وقتی سلول‌های ادغام‌شده یافت شدند، پیغام مناسب را چاپ کنید.

این کد PHP نشان می‌دهد که چگونه سلول‌های جدول ادغام‌شده را در یک ارائه شناسایی کنید:

```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// فرض بر این است که Slide#0.Shape#0 یک جدول است

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **حذف خطوط مرزی سلول جدول**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
2. از طریق شاخص، مرجع یک اسلاید را دریافت کنید. 
3. آرایه‌ای از ستون‌ها با عرض تعریف کنید.
4. آرایه‌ای از سطرها با ارتفاع تعریف کنید.
5. با استفاده از متد [addTable](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/#addTable) یک جدول به اسلاید اضافه کنید.
6. روی هر سلول پیمایش کنید تا خطوط مرزی بالا، پایین، راست و چپ را پاک کنید.
7. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد که چگونه خطوط مرزی سلول‌های جدول را حذف کنید:

```php
  # نمونه ساز کلاس Presentation که یک فایل PPTX را نمایندگی می‌کند
  $pres = new Presentation();
  try {
    # به اسلاید اول دسترسی می‌یابد
    $sld = $pres->getSlides()->get_Item(0);
    # ستون‌ها را با عرض‌ها و سطرها را با ارتفاع‌ها تعریف می‌کند
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # شکل جدول را به اسلاید اضافه می‌کند
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # قالب حاشیه را برای هر سلول تنظیم می‌کند
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # فایل PPTX را روی دیسک می‌نویسد
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **شماره‌گذاری در سلول‌های ادغام‌شده**
اگر دو جفت سلول (1, 1) × (2, 1) و (1, 2) × (2, 2) را ادغام کنیم، جدول حاصل شماره‌گذاری می‌شود. این کد PHP فرآیند را نشان می‌دهد:

```php
  # نمونه ساز کلاس Presentation که یک فایل PPTX را نمایندگی می‌کند
  $pres = new Presentation();
  try {
    # به اسلاید اول دسترسی می‌یابد
    $sld = $pres->getSlides()->get_Item(0);
    # ستون‌ها را با عرض‌ها و سطرها را با ارتفاع‌ها تعریف می‌کند
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # یک شکل جدول را به اسلاید اضافه می‌کند
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # قالب حاشیه را برای هر سلول تنظیم می‌کند
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # سلول‌ها (1, 1) × (2, 1) را ادغام می‌کند
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # سلول‌ها (1, 2) × (2, 2) را ادغام می‌کند
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

سپس سلول‌ها را بیشتر ادغام می‌کنیم با ادغام (1, 1) و (1, 2). نتیجه جدولی است که یک سلول بزرگ ادغام‌شده در مرکز دارد:

```php
  # یک نمونه از کلاس Presentation که یک فایل PPTX را نمایندگی می‌کند
  $pres = new Presentation();
  try {
    # به اسلاید اول دسترسی می‌یابد
    $sld = $pres->getSlides()->get_Item(0);
    # ستون‌ها را با عرض‌ها و سطرها را با ارتفاع‌ها تعریف می‌کند
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # یک شکل جدول را به اسلاید اضافه می‌کند
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # قالب حاشیه را برای هر سلول تنظیم می‌کند
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # سلول‌ها (1, 1) × (2, 1) را ادغام می‌کند
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # سلول‌ها (1, 2) × (2, 2) را ادغام می‌کند
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # سلول‌ها (1, 1) × (1, 2) را ادغام می‌کند
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # فایل PPTX را روی دیسک می‌نویسد
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **شماره‌گذاری در سلول تقسیم‌شده**
در مثال‌های قبلی، وقتی سلول‌های جدول ادغام شدند، سیستم شماره‌گذاری یا اعداد در سلول‌های دیگر تغییر نکرد.  

این بار، یک جدول معمولی (بدون سلول‌های ادغام‌شده) را می‌گیریم و سعی می‌کنیم سلول (1,1) را تقسیم کنیم تا جدول ویژه‌ای به دست آید. ممکن است به شماره‌گذاری این جدول توجه کنید که ممکن است عجیب به‌نظر برسد. اما این همان روشی است که Microsoft PowerPoint سلول‌های جدول را شماره‌گذاری می‌کند و Aspose.Slides نیز همین کار را انجام می‌دهد.  

این کد PHP فرآیند شرح‌داده‌شده را نشان می‌دهد:

```php
  # یک نمونه از کلاس Presentation که یک فایل PPTX را نمایندگی می‌کند
  $pres = new Presentation();
  try {
    # به اسلاید اول دسترسی می‌یابد
    $sld = $pres->getSlides()->get_Item(0);
    # ستون‌ها را با عرض‌ها و سطرها را با ارتفاع‌ها تعریف می‌کند
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # یک شکل جدول را به اسلاید اضافه می‌کند
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # قالب حاشیه را برای هر سلول تنظیم می‌کند
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # سلول‌ها (1, 1) × (2, 1) را ادغام می‌کند
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # سلول‌ها (1, 2) × (2, 2) را ادغام می‌کند
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # سلول (1, 1) را تقسیم می‌کند
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # فایل PPTX را روی دیسک می‌نویسد
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تغییر رنگ پس‌زمینه سلول جدول**

این کد PHP نشان می‌دهد که چگونه رنگ پس‌زمینه یک سلول جدول را تغییر دهید:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # یک جدول جدید ایجاد می‌کند
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # رنگ پس‌زمینه سلول را تنظیم می‌کند
    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **اضافه کردن تصویر داخل سلول جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
2. از طریق شاخص، مرجع یک اسلاید را دریافت کنید.
3. آرایه‌ای از ستون‌ها با عرض تعریف کنید.
4. آرایه‌ای از سطرها با ارتفاع تعریف کنید.
5. با استفاده از متد [AddTable](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/#addTable) یک جدول به اسلاید اضافه کنید.
6. یک شی `Images` برای نگهداری فایل تصویر ایجاد کنید.
7. تصویر `IImage` را به شی `IPPImage` اضافه کنید.
8. `FillFormat` سلول جدول را روی `Picture` تنظیم کنید.
9. تصویر را به اولین سلول جدول اضافه کنید.
10. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد که چگونه هنگام ایجاد جدول، یک تصویر را داخل سلول جدول قرار دهید:

```php
  # یک نمونه از کلاس Presentation که یک فایل PPTX را نمایندگی می‌کند
  $pres = new Presentation();
  try {
    # به اسلاید اول دسترسی می‌یابد
    $islide = $pres->getSlides()->get_Item(0);
    # ستون‌ها را با عرض‌ها و سطرها را با ارتفاع‌ها تعریف می‌کند
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # یک شکل جدول را به اسلاید اضافه می‌کند
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # یک شیء IPPImage با استفاده از فایل تصویر ایجاد می‌کند
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # تصویر را به اولین سلول جدول اضافه می‌کند
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # فایل PPTX را روی دیسک ذخیره می‌کند
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**آیا می‌توانم ضخامت و سبک خطوط متفاوتی برای هر طرف یک سلول تنظیم کنم؟**

بله. خطوط مرزی [top](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellformat/getborderright/) دارای خصوصیات جداگانه هستند، بنابراین ضخامت و سبک هر طرف می‌تواند متفاوت باشد. این به‌صورت منطقی از کنترل خطوط مرزی به‌ازای هر طرف سلول که در مقاله نشان داده شد، پیروی می‌کند.

**اگر پس از تنظیم یک تصویر به‌عنوان پس‌زمینه سلول، اندازه ستون/سطر را تغییر دهم، چه اتفاقی برای تصویر می‌افتد؟**

رفتار بستگی به [fill mode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillmode/) (کشیدگی/کاشی) دارد. در حالت کشیدگی، تصویر با سلول جدید سازگار می‌شود؛ در حالت کاشی، کاشی‌ها دوباره محاسبه می‌شوند. مقاله به حالت‌های نمایش تصویر در یک سلول اشاره دارد.

**آیا می‌توانم یک ابر링ک را به تمام محتوای یک سلول اختصاص دهم؟**

[Hyperlinks](/slides/fa/php-java/manage-hyperlinks/) در سطح متن (بخش) داخل فریم متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، می‌توانید لینک را به یک بخش یا به تمام متن داخل سلول اختصاص دهید.

**آیا می‌توانم فونت‌های متفاوتی داخل یک سلول تنظیم کنم؟**

بله. فریم متن یک سلول از [portions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/) (بخش‌ها) با قالب‌بندی مستقل—خانواده فونت، سبک، اندازه و رنگ—پشتیبانی می‌کند.