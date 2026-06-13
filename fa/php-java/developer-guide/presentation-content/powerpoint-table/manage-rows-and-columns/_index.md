---
title: مدیریت ردیف‌ها و ستون‌ها در جداول PowerPoint با استفاده از PHP
linktitle: ردیف‌ها و ستون‌ها
type: docs
weight: 20
url: /fa/php-java/manage-rows-and-columns/
keywords:
- ردیف جدول
- ستون جدول
- ردیف اول
- سرصفحه جدول
- تکثیر ردیف
- تکثیر ستون
- کپی ردیف
- کپی ستون
- حذف ردیف
- حذف ستون
- قالب‌بندی متن ردیف
- قالب‌بندی متن ستون
- سبک جدول
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت ردیف‌ها و ستون‌های جدول در PowerPoint با Aspose.Slides برای PHP از طریق Java و تسریع ویرایش ارائه و به‌روزرسانی داده‌ها."
---
## **مقدمه**

برای اینکه بتوانید ردیف‌ها و ستون‌های یک جدول را در یک ارائه PowerPoint مدیریت کنید، Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/fa/php-java/aspose.slides/table/) و بسیاری از انواع دیگر را فراهم می‌کند.

## **تنظیم ردیف اول به عنوان سرصفحه**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید.  
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک شیء [Table](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Table) ایجاد کنید و آن را به null تنظیم کنید.  
4. در تمام اشیاء [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) پیمایش کنید تا جدول مرتبط پیدا شود.  
5. ردیف اول جدول را به عنوان سرصفحه تنظیم کنید.  

این کد PHP نشان می‌دهد که چگونه ردیف اول جدول را به عنوان سرصفحه تنظیم کنید:

```php
  # یک نمونه از کلاس Presentation را ایجاد می‌کند
  $pres = new Presentation("table.pptx");
  try {
    # به اولین اسلاید دسترسی می‌یابد
    $sld = $pres->getSlides()->get_Item(0);
    # مقداردهی اولیه TableEx با null
    $tbl = null;
    # در میان اشکال پیمایش می‌کند و مرجعی به جدول تنظیم می‌دارد
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # ردیف اول جدول را به عنوان سرصفحه تنظیم می‌کند
        $tbl->setFirstRow(true);
      }
    }
    # ارائه را بر روی دیسک ذخیره می‌کند
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **کپی ردیف یا ستون جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید،  
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک آرایه از `columnWidth` تعریف کنید.  
4. یک آرایه از `rowHeight` تعریف کنید.  
5. شیء [Table](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Table) را به اسلاید از طریق متد [addTable](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addtable/) اضافه کنید.  
6. ردیف جدول را کپی کنید.  
7. ستون جدول را کپی کنید.  
8. ارائه تغییر یافته را ذخیره کنید.  

این کد PHP نشان می‌دهد که چگونه ردیف یا ستون یک جدول PowerPoint را کپی کنید:

```php
  # یک نمونه از کلاس Presentation را ایجاد می‌کند
  $pres = new Presentation("Test.pptx");
  try {
    # به اولین اسلاید دسترسی می‌یابد
    $sld = $pres->getSlides()->get_Item(0);
    # ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # یک شکل جدول را به اسلاید اضافه می‌کند
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # متنی به سلول 1 ردیف 1 اضافه می‌کند
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # متنی به سلول 2 ردیف 1 اضافه می‌کند
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # ردیف 1 را در انتهای جدول کپی می‌کند
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # متنی به سلول 1 ردیف 2 اضافه می‌کند
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # متنی به سلول 2 ردیف 2 اضافه می‌کند
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # ردیف 2 را به عنوان ردیف چهارم جدول کپی می‌کند
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # ستون اول را در انتها کپی می‌کند
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # ستون دوم را در اندیس ستون چهارم کپی می‌کند
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # ارائه را بر روی دیسک ذخیره می‌کند
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **حذف ردیف یا ستون از جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید،  
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک آرایه از `columnWidth` تعریف کنید.  
4. یک آرایه از `rowHeight` تعریف کنید.  
5. شیء [Table](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Table) را به اسلاید از طریق متد [addTable](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addtable/) اضافه کنید.  
6. ردیف جدول را حذف کنید.  
7. ستون جدول را حذف کنید.  
8. ارائه تغییر یافته را ذخیره کنید.  

این کد PHP نشان می‌دهد که چگونه ردیف یا ستونی را از جدول حذف کنید:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = array(100, 50, 30 );
    $rowHeight = array(30, 50, 30 );
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم قالب‌بندی متن در سطح ردیف جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید،  
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
3. به شیء [Table](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Table) مرتبط از اسلاید دسترسی پیدا کنید.  
4. ارتفاع فونت سلول‌های ردیف اول را با [setFontHeight(float value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setFontHeight) تنظیم کنید.  
5. تراز ([setAlignment(int value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setalignment/)) و حاشیه راست ([setMarginRight(float value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setmarginright/)) سلول‌های ردیف اول را تنظیم کنید.  
6. نوع عمودی متن سلول‌های ردیف دوم را با [setTextVerticalType(byte value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/settextverticaltype/) تنظیم کنید.  
7. ارائه تغییر یافته را ذخیره کنید.  

این کد PHP عملیات را نشان می‌دهد.

```php
  # یک نمونه از کلاس Presentation ایجاد می‌کند
  $pres = new Presentation();
  try {
    # فرض می‌کنیم اولین شکل در اولین اسلاید یک جدول است
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # ارتفاع قلم سلول‌های ردیف اول را تنظیم می‌کند
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # تراز متن و حاشیه راست سلول‌های ردیف اول را تنظیم می‌کند
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # نوع عمودی متن سلول‌های ردیف دوم را تنظیم می‌کند
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # ارائه را بر روی دیسک ذخیره می‌کند
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم قالب‌بندی متن در سطح ستون جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید،  
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
3. به شیء [Table](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Table) مرتبط از اسلاید دسترسی پیدا کنید.  
4. ارتفاع فونت سلول‌های ستون اول را با [setFontHeight(float value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setFontHeight) تنظیم کنید.  
5. تراز ([setAlignment(int value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setalignment/)) و حاشیه راست ([setMarginRight(float value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setmarginright/)) سلول‌های ستون اول را تنظیم کنید.  
6. نوع عمودی متن سلول‌های ستون دوم را با [setTextVerticalType(byte value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/settextverticaltype/) تنظیم کنید.  
7. ارائه تغییر یافته را ذخیره کنید.  

این کد PHP عملیات را نشان می‌دهد:

```php
  # یک نمونه از کلاس Presentation ایجاد می‌کند
  $pres = new Presentation();
  try {
    # فرض می‌کنیم اولین شکل در اولین اسلاید یک جدول است
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # ارتفاع قلم سلول‌های ستون اول را تنظیم می‌کند
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # تراز متن و حاشیه راست سلول‌های ستون اول را در یک فراخوانی تنظیم می‌کند
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # نوع عمودی متن سلول‌های ستون دوم را تنظیم می‌کند
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **دریافت ویژگی‌های سبک جدول**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های سبک یک جدول را بازیابی کنید تا بتوانید این جزئیات را برای جدول دیگری یا در مکان دیگری استفاده کنید. این کد PHP نشان می‌دهد که چگونه ویژگی‌های سبک را از یک سبک پیش‌فرض جدول بگیرید:

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

## **پرسش‌های متداول**

**آیا می‌توانم تم‌ها/سبک‌های PowerPoint را به جدول موجود اعمال کنم؟**  
بله. جدول تم اسلاید/چیدمان/مستر را به ارث می‌برد و هنوز می‌توانید پرکننده‌ها، حاشیه‌ها و رنگ‌های متن را روی آن تم بازنویسی کنید.

**آیا می‌توانم ردیف‌های جدول را مانند Excel مرتب کنم؟**  
خیر، جداول Aspose.Slides قابلیت مرتب‌سازی یا فیلترهای داخلی ندارند. ابتدا داده‌های خود را در حافظه مرتب کنید، سپس ردیف‌های جدول را بر اساس آن ترتیب پر کنید.

**آیا می‌توانم ستون‌های خط‌دار (Striped) داشته باشم در حالی که رنگ‌های سفارشی برای سلول‌های خاص حفظ می‌شود؟**  
بله. ستون‌های خط‌دار را فعال کنید، سپس سلول‌های خاص را با قالب‌بندی محلی بازنویسی کنید؛ قالب‌بندی سطح سلول بر سبک جدول ارجحیت دارد.