---
title: مدیریت جدول‌های ارائه در PHP
linktitle: مدیریت جدول
type: docs
weight: 10
url: /fa/php-java/manage-table/
keywords:
- افزودن جدول
- ایجاد جدول
- دسترسی به جدول
- نسبت ابعاد
- تراز متن
- قالب‌بندی متن
- سبک جدول
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "ایجاد و ویرایش جدول‌ها در اسلایدهای PowerPoint با Aspose.Slides برای PHP از طریق Java. نمونه‌های کد ساده‌ای را کشف کنید تا گردش کارهای جدول خود را ساده کنید."
---
## **مقدمه**

جداول در پاورپوینت اطلاعات را به سطرها و ستون‌ها سازماندهی می‌کنند تا خواندن و مقایسه مقادیر آسان‌تر شود.

Aspose.Slides کلاس‌های [جدول](https://reference.aspose.com/slides/php-java/aspose.slides/table/) ، [سلول](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) و انواع دیگر را فراهم می‌کند تا بتوانید جداول را در ارائه‌ها ایجاد، به‌روزرسانی و مدیریت کنید.

## **ایجاد جدول از ابتدا**

با تعیین موقعیت، عرض ستون‌ها و ارتفاع سطرها یک جدول ایجاد کنید. پس از افزودن آن به اسلاید، می‌توانید حاشیه‌های سلول را قالب‌بندی کنید، سلول‌ها را ادغام کنید و متن وارد کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد کنید.
2. یک مرجع به اسلاید را بر اساس شاخص آن دریافت کنید.
3. یک آرایه از عرض ستون‌ها را بر حسب نقطه تعریف کنید.
4. یک آرایه از ارتفاع سطرها را بر حسب نقطه تعریف کنید.
5. یک شیء [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) را از طریق متد [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) به اسلاید اضافه کنید.
6. در هر [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) پیمایش کنید تا قالب‌بندی حاشیه‌های بالا، پایین، راست و چپ را اعمال کنید.
7. دو سلول اول ردیف اول جدول را ادغام کنید.
8. از طریق متد [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) به سلول ادغام‌شده دسترسی پیدا کنید.
9. متن را در سلول ادغام‌شده تنظیم کنید.
10. ارائه تغییر یافته را ذخیره کنید.

مثال زیر جدولی با سه ستون و پنج ردیف در موقعیت (100, 50) نقطه ایجاد می‌کند. حاشیه‌های قرمز با عرض 5 نقطه اعمال می‌شود، دو سلول اول ردیف اول ادغام می‌شود و نتیجه به عنوان `table.pptx` ذخیره می‌شود.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 0), false);
    $table->get_Item(0, 0)->getTextFrame()->setText("Merged Cells");

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **شماره‌گذاری در جدول استاندارد**

در یک جدول استاندارد، شاخص‌های سلول از صفر شروع می‌شوند و به ترتیب (ستون، ردیف) هستند. اولین سلول به صورت (0, 0) اندیس‌گذاری می‌شود.

به عنوان مثال، سلول‌های یک جدول با 4 ستون و 4 ردیف به این شکل شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

این مثال جدول 4 × 4 نشان داده شده در بالا را ایجاد می‌کند، با عرض ستون‌ها و ارتفاع سطرها برابر 70 نقطه و حاشیه‌های سلولی قرمز با عرض 5 نقطه. مختصات‌ها شاخص‌های سلول را نشان می‌دهند؛ این مثال سلول‌ها را خالی می‌گذارد و جدول را به عنوان `StandardTables_out.pptx` ذخیره می‌کند.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $presentation->save("StandardTables_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **دسترسی به جدول موجود**

جداول در مجموعهٔ شکل‌های یک اسلاید ذخیره می‌شوند. با پیمایش شکل‌ها جدول را پیدا کنید، سپس از کلاس [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) برای خواندن یا به‌روزرسانی سلول‌های آن استفاده کنید.

1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) بارگذاری کنید.
2. مرجع اسلاید حاوی جدول را بر اساس شاخص آن دریافت کنید.
3. در اشیاء [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) پیمایش کنید و زمانی که جدول یافت شد توقف کنید. اگر اسلاید شامل چند جدول باشد، از [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) برای شناسایی جدول مورد نیاز استفاده کنید.
4. متن سلول هدف را به‌روزرسانی کنید.
5. ارائه تغییر یافته را ذخیره کنید.

مثال زیر فایل `UpdateExistingTable.pptx` را باز می‌کند و اولین جدول در اولین اسلاید را پیدا می‌کند. سلول در ستون 0، ردیف 1 را به مقدار `New` تنظیم می‌کند و نتیجه را به عنوان `table1_out.pptx` ذخیره می‌کند. ورودی باید حداقل یک اسلاید داشته باشد و اولین جدول در آن اسلاید باید حداقل یک ستون و دو ردیف داشته باشد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("UpdateExistingTable.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = null;
    $tableClass = new JavaClass("com.aspose.slides.Table");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            $table = $shape;
            break;
        }
    }

    if ($table !== null) {
        $table->get_Item(0, 1)->getTextFrame()->setText("New");
        $presentation->save("table1_out.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

برای تغییر اندازهٔ یک سطر در جدول موجود و درک دلیل اینکه چرا ارتفاع واقعی می‌تواند بیش از حداقل درخواست‌شده باشد، به [کنترل ارتفاع سطر](/slides/fa/php-java/manage-rows-and-columns/#control-row-height) مراجعه کنید.

## **یافتن سلولی که TextFrame صاحب آن است**

هنگامی که کد عمومی پردازش متن یک [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) را از یک جدول دریافت می‌کند، از متد [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) برای بازیابی [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) صاحب آن استفاده کنید. برای یک TextFrame سلول‑جدول، [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) صاحب را برمی‌گرداند و [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) مقدار `null` برمی‌گرداند، حتی اگر جدول خود یک شکل باشد.

مختصات سلول‌ها از طریق متدهای فقط‑خواندنی [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) و [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) در دسترس هستند. همچنین [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) ناوبری فقط‑خواندنی را فراهم می‌کند: صاحب را برمی‌گرداند اما مالکیت را تغییر نمی‌دهد. همواره قبل از استفاده، سلول بازگردانده شده را با `java_is_null` بررسی کنید.

برای یک مثال کامل که مالکین سلول‑جدول و شکل را شناسایی می‌کند، از جمله اشکالی که با گره‌های SmartArt مرتبط هستند، به [جستجو و جایگزینی متن](/slides/fa/php-java/search-and-replace-text/) مراجعه کنید.

## **تراز کردن متن در جدول**

می‌توانید تثبیت عمودی و جهت متن سلول‌های فردی جدول را کنترل کنید. مثال در این بخش متن را در داخل اولین سلول به‌صورت مرکزی قرار می‌دهد و به اندازهٔ 270 درجه چرخش می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید را بر اساس شاخص آن دریافت کنید.
3. یک شیء [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) را به اسلاید اضافه کنید.
4. یک شیء [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) را از جدول دسترسی پیدا کنید.
5. اولین [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) را دسترسی یافته و متن و رنگ آن را تنظیم کنید.
6. تثبیت عمودی سلول و جهت متن را با استفاده از [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) و [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/) تنظیم کنید.
7. ارائه تغییر یافته را ذخیره کنید.

این مثال جدول 4 × 4 ای با عرض ستون‌های 120 نقطه و ارتفاع سطرهای 100 نقطه ایجاد می‌کند. متن سلول (0, 0) را قالب‌بندی می‌کند، مقادیر را به بقیه سلول‌های ردیف اول اضافه می‌کند و نتیجه را به عنوان `Vertical_Align_Text_out.pptx` ذخیره می‌کند.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $black = java("java.awt.Color")->BLACK;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 120, 120, 120, 120 ];
    $rowHeights = [ 100, 100, 100, 100 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 0)->getTextFrame()->setText("10");
    $table->get_Item(2, 0)->getTextFrame()->setText("20");
    $table->get_Item(3, 0)->getTextFrame()->setText("30");

    $textFrame = $table->get_Item(0, 0)->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);

    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

    $cell = $table->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم قالب‌بندی متن در سطح جدول**

از [setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) برای اعمال قالب‌بندی متن به تمام سلول‌های یک جدول استفاده کنید. بارگذاری‌های آن بخش، پاراگراف و قالب‌بندی چارچوب متن را می‌پذیرند، به‌طوری که می‌توانید این ویژگی‌ها را بدون پیمایش سلول‌های فردی تنظیم کنید.

1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) بارگذاری کنید.
2. مرجع اسلاید را بر اساس شاخص آن بگیرید.
3. یک شیء [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) را از اسلاید دسترسی پیدا کنید.
4. اندازهٔ قلم را با استفاده از [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) برای متن تنظیم کنید.
5. ترازبندی پاراگراف و حاشیهٔ راست را با استفاده از [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) و [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) تنظیم کنید.
6. جهت متن را با استفاده از [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) تنظیم کنید.
7. ارائه تغییر یافته را ذخیره کنید.

مثال زیر فایل `table.pptx` را باز می‌کند که باید حداقل یک اسلاید داشته باشد که اولین شکل آن یک جدول باشد. اندازهٔ قلم را به 25 نقطه تنظیم می‌کند، پاراگراف‌ها را راست‌چین با حاشیهٔ راست 20 نقطه می‌کند و متن را عمودی می‌سازد. ارائه قالب‌بندی‌شده به عنوان `result.pptx` ذخیره می‌شود.

```php
use aspose\slides\ParagraphFormat;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->setTextFormat($textFrameFormat);

    $presentation->save("result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **دریافت ویژگی‌های سبک جدول**

از [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) برای خواندن سبک پیش‌تنظیم‌شدهٔ جدول و از [setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) برای اختصاص آن استفاده کنید. این مثال [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) را بر یک جدول اعمال می‌کند، مقدار پیش‌تنظیم را چاپ می‌کند و همان پیش‌تنظیم را به جدول دوم اختصاص می‌دهد. هر دو جدول در `table-style.pptx` ذخیره می‌شوند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 100, 150 ];
    $rowHeights = [ 5, 5, 5 ];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = java_values($table->getStylePreset());
    echo "Table style preset: " . $stylePreset . PHP_EOL;

    $anotherTable = $slide->getShapes()->addTable(10, 100, $columnWidths, $rowHeights);
    $anotherTable->setStylePreset($stylePreset);

    $presentation->save("table-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **قفل کردن نسبت ابعاد جدول**

نسبت ابعاد جدول، نسبت عرض آن به ارتفاع است. از [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) برای قفل کردن این نسبت برای جدول استفاده کنید.

مثال زیر فایل `pres.pptx` را باز می‌کند که باید حداقل یک اسلاید داشته باشد که اولین شکل آن یک جدول باشد. حالت قفل فعلی را چاپ می‌کند، قفل نسبت ابعاد را فعال می‌کند، حالت به‌روزشده (`true`) را چاپ می‌کند و نتیجه را به عنوان `pres-out.pptx` ذخیره می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $table->getGraphicalObjectLock()->setAspectRatioLocked(true);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $presentation->save("pres-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**آیا می‌توانم جهت خواندن راست‑به‑چپ (RTL) را برای یک جدول کامل و متن داخل سلول‌های آن فعال کنم؟**

بله. جدول یک متد [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) را ارائه می‌دهد و پاراگراف‌ها متد [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/) دارند. استفاده از هر دو اطمینان می‌دهد که ترتیب RTL صحیح بوده و رندر داخل سلول‌ها به درستی انجام شود.

**چگونه می‌توانم از جابجا یا تغییر اندازهٔ جدول توسط کاربران در فایل نهایی جلوگیری کنم؟**

از [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) برای غیرفعال‌سازی جابجایی، تغییر اندازه، انتخاب و غیره استفاده کنید. این قفل‌ها بر جداول نیز اعمال می‌شوند.

**آیا درج تصویر به‌عنوان پس‌زمینه داخل یک سلول پشتیبانی می‌شود؟**

بله. می‌توانید برای یک سلول یک [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) تنظیم کنید؛ تصویر به‌موجب حالت انتخابی (کشیدن یا کاشی) کل ناحیهٔ سلول را پوشش می‌دهد.