---
title: مدیریت جداول ارائه در PHP
linktitle: مدیریت جدول
type: docs
weight: 10
url: /fa/php-java/manage-table/
keywords:
- افزودن جدول
- ایجاد جدول
- دسترسی به جدول
- نسبت ابعادی
- تراز متن
- قالب‌بندی متن
- سبک جدول
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "ایجاد و ویرایش جداول در اسلایدهای PowerPoint با Aspose.Slides برای PHP از طریق Java. نمونه‌های کد ساده‌ای را کشف کنید تا جریان کاری جداول خود را بهینه‌سازی کنید."
---
## **مقدمه**

یک جدول در PowerPoint روش کارآمدی برای نمایش و ارائه اطلاعات است. اطلاعات در یک شبکه سلول‌ها (که به صورت سطرها و ستون‌ها چینیده‌اند) ساده و به راحتی قابل فهم است.

Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Table) و کلاس [Cell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cell/) و انواع دیگر را فراهم می‌کند تا بتوانید جدول‌ها را در انواع مختلف ارائه‌ها ایجاد، به‌روزرسانی و مدیریت کنید.

## **ایجاد جدول از ابتدا**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.  
2. از طریق ایندکس، مرجع یک اسلاید را دریافت کنید.  
3. یک آرایه از `columnWidth` تعریف کنید.  
4. یک آرایه از `rowHeight` تعریف کنید.  
5. یک شیء [Table](https://reference.aspose.com/slides/fa/php-java/aspose.slides/table/) را از طریق متد [addTable](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addtable/) به اسلاید اضافه کنید.  
6. از هر [Cell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cell/) پیمایش کنید تا قالب‌بندی حاشیه‌های بالا، پایین، راست و چپ را اعمال کنید.  
7. دو سلول اول ردیف اول جدول را ادغام کنید.  
8. به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) یک [Cell] دسترسی پیدا کنید.  
9. متنی به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) اضافه کنید.  
10. ارائه‌ی تغییر یافته را ذخیره کنید.

```php
  # یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
  $pres = new Presentation();
  try {
    # به اولین اسلاید دسترسی می‌یابد
    $sld = $pres->getSlides()->get_Item(0);
    # ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # یک شکل جدول را به اسلاید اضافه می‌کند
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # قالب حاشیه را برای هر سلول تنظیم می‌کند
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # سلول‌های 1 و 2 ردیف 1 را ادغام می‌کند
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # متنی به سلول ادغام‌شده اضافه می‌کند
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # ارائه را روی دیسک ذخیره می‌کند
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **شماره‌گذاری در جدول استاندارد**

در یک جدول استاندارد، شماره‌گذاری سلول‌ها ساده و مبتنی بر صفر است. اولین سلول در جدول به صورت 0,0 (ستون 0، ردیف 0) اندیس‌گذاری می‌شود.  

برای مثال، سلول‌های یک جدول با 4 ستون و 4 ردیف به این صورت شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

این کد PHP نشان می‌دهد چگونه شماره‌گذاری سلول‌های یک جدول را تعیین کنید:

```php
  # یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
  $pres = new Presentation();
  try {
    # به اولین اسلاید دسترسی می‌یابد
    $sld = $pres->getSlides()->get_Item(0);
    # ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
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
    # ارائه را روی دیسک ذخیره می‌کند
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **دسترسی به جدول موجود**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.  
2. از طریق ایندکس، مرجع اسلاید حاوی جدول را دریافت کنید.  
3. یک شیء [Table](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Table) ایجاد کنید و آن را به null تنظیم کنید.  
4. تا یافتن جدول، از طریق تمام اشیاء [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) پیمایش کنید.  

اگر فکر می‌کنید اسلاید مورد بررسی تنها یک جدول دارد، می‌توانید به سادگی تمام اشکال موجود در آن را بررسی کنید. وقتی یک شکل به عنوان جدول شناسایی شد، می‌توانید آن را به شیء [Table] تبدیل کنید. اما اگر اسلاید چندین جدول داشته باشد، بهتر است جدول مورد نیاز خود را از طریق متد [setAlternativeText(String value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/setalternativetext/) جستجو کنید.  

5. از شیء [Table](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Table) برای کار با جدول استفاده کنید. در مثال زیر، یک ردیف جدید به جدول افزودیم.  
6. ارائه‌ی تغییر یافته را ذخیره کنید.

```php
  # یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # به اولین اسلاید دسترسی می‌یابد
    $sld = $pres->getSlides()->get_Item(0);
    # مقدار اولیه TableEx برابر null می‌شود
    $tbl = null;
    # از شکل‌ها عبور می‌کند و مرجع به جدول پیدا شده را تنظیم می‌کند
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # متن برای اولین ستون ردیف دوم تنظیم می‌شود
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # ارائه‌ی تغییر یافته را روی دیسک ذخیره می‌کند
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تراز متن در جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.  
2. از طریق ایندکس، مرجع یک اسلاید را دریافت کنید.  
3. شیء [Table](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Table) را به اسلاید اضافه کنید.  
4. به شیء [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) از جدول دسترسی پیدا کنید.  
5. به [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) دسترسی پیدا کنید.  
6. متن را به صورت عمودی تراز کنید.  
7. ارائه‌ی تغییر یافته را ذخیره کنید.

```php
  # یک نمونه از کلاس Presentation ایجاد می‌کند
  $pres = new Presentation();
  try {
    # اولین اسلاید را دریافت می‌کند
    $slide = $pres->getSlides()->get_Item(0);
    # ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # شکل جدول را به اسلاید اضافه می‌کند
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # به فریم متن دسترسی پیدا می‌کند
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # شیء Paragraph را برای فریم متن ایجاد می‌کند
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # شیء Portion را برای پاراگراف ایجاد می‌کند
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # متن را به صورت عمودی تراز می‌کند
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # ارائه را روی دیسک ذخیره می‌کند
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم قالب‌بندی متن در سطح جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.  
2. از طریق ایندکس، مرجع یک اسلاید را دریافت کنید.  
3. به شیء [Table](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Table) از اسلاید دسترسی پیدا کنید.  
4. متد [setFontHeight(float value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setFontHeight) را برای متن تنظیم کنید.  
5. متدهای [setAlignment(int value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setalignment/) و [setMarginRight(float value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setmarginright/) را تنظیم کنید.  
6. متد [setTextVerticalType(byte value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/settextverticaltype/) را تنظیم کنید.  
7. ارائه‌ی تغییر یافته را ذخیره کنید.

```php
  # یک نمونه از کلاس Presentation ایجاد می‌کند
  $pres = new Presentation("simpletable.pptx");
  try {
    # فرض می‌کنیم که اولین شکل در اولین اسلاید یک جدول است
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # ارتفاع فونت سلول‌های جدول را تنظیم می‌کند
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # تراز متن سلول‌های جدول و حاشیه راست را در یک فراخوانی تنظیم می‌کند
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # نوع عمودی متن سلول‌های جدول را تنظیم می‌کند
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **دریافت ویژگی‌های سبک جدول**

Aspose.Slides به شما اجازه می‌دهد ویژگی‌های سبک یک جدول را بازیابی کنید تا بتوانید این جزئیات را برای جدول دیگر یا مکان دیگری استفاده کنید. این کد PHP نشان می‌دهد چگونه ویژگی‌های سبک را از یک سبک پیش‌فرض جدول دریافت کنید:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// تغییر تم پیش‌فرض سبک پیش‌تنظیم

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **قفل کردن نسبت ابعادی جدول**

نسبت ابعادی یک شکل هندسی، نسبت اندازه‌های آن در ابعاد مختلف است. Aspose.Slides متد [setAspectRatioLocked](https://reference.aspose.com/slides/fa/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) را فراهم کرده تا بتوانید تنظیم نسبت ابعادی را برای جدول‌ها و سایر شکل‌ها قفل کنید.

این کد PHP نشان می‌دهد چگونه نسبت ابعادی یک جدول را قفل کنید:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// invert

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سؤالات متداول**

**آیا می‌توانم جهت خواندن از راست به چپ (RTL) را برای کل جدول و متن داخل سلول‌های آن فعال کنم؟**

بله. جدول متد [setRightToLeft](https://reference.aspose.com/slides/fa/php-java/aspose.slides/table/setrighttoleft/) را در اختیار می‌گذارد و پاراگراف‌ها متد [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setrighttoleft/) دارند. استفاده از هر دو تضمین می‌کند که ترتیب و رندر صحیح RTL داخل سلول‌ها اعمال شود.

**چگونه می‌توانم از جابجا یا تغییر اندازه جدول توسط کاربران در فایل نهایی جلوگیری کنم؟**

از قفل‌های شکل استفاده کنید تا حرکت، تغییر اندازه، انتخاب و غیره را غیرفعال کنید. این قفل‌ها بر روی جدول‌ها نیز اعمال می‌شوند.

**آیا درج تصویر داخل سلول به عنوان پس‌زمینه پشتیبانی می‌شود؟**

بله. می‌توانید برای یک سلول [picture fill](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/) تنظیم کنید؛ تصویر بر حسب حالت انتخابی (کشیده شدن یا کاشی) ناحیه سلول را پوشش می‌دهد.