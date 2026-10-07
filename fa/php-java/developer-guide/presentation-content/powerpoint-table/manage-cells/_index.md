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
description: "مدیریت سلول‌های جدول PowerPoint در PHP: شناسایی سلول‌های ادغام‌شده، حذف حاشیه‌ها، تقسیم سلول‌ها و تنظیم رنگ‌های پس‌زمینه و تصاویر با Aspose.Slides برای PHP از طریق Java."
---
## **بررسی کلی**

Aspose.Slides به شما امکان دسترسی و ویرایش سلول‌های جدول در ارائه‌های PowerPoint را می‌دهد. این مقاله توضیح می‌دهد چگونه سلول‌های جدول ادغام‌شده را شناسایی کنید، مرزهای سلول را حذف کنید، پس از ادغام یا تقسیم سلول‌ها با شماره‌گذاری سلول کار کنید، رنگ پس‌زمینه یک سلول را تغییر دهید و یک تصویر را داخل یک سلول جدول اضافه کنید. نمونه‌ها نشان می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روزرسانی کنید و ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

Aspose.Slides از ایندکس‌های صفر‑مبنا برای دسترسی به سلول‌های جدول به ترتیب `(column, row)` استفاده می‌کند.

## **شناسایی یک سلول جدول ادغام‌شده**

مثال یک ارائه موجود را باز می‌کند و شکل اول در اسلاید اول را به عنوان جدول دسترسی می‌یابد. فرض می‌شود اسلاید و شکل وجود داشته باشند و شکل یک جدول باشد. سپس تمام ردیف‌ها و ستون‌ها را مرور می‌کند و از [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) برای شناسایی سلول‌ها در نواحی ادغام‌شده استفاده می‌کند. برای هر تطابق، مختصات سلول را به ترتیب `row;column`، [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/)، [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/) و مختصات شروع ناحیه را با استفاده از [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) و [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) چاپ می‌کند.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $rowCount = java_values($table->getRows()->size());
    for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++)
    {
        $columnCount = java_values($table->getColumns()->size());
        for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++)
        {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            if (java_values($cell->isMergedCell()))
            {
                printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.\n", $rowIndex, $columnIndex, java_values($cell->getRowSpan()), java_values($cell->getColSpan()), java_values($cell->getFirstRowIndex()), java_values($cell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **حذف مرزهای سلول جدول**

یک [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد کنید و با استفاده از [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) یک جدول به اسلاید اول آن اضافه کنید. عرض ستون‌ها، ارتفاع ردیف‌ها و موقعیت جدول بر حسب نقطه مشخص می‌شود. مثال تمام چهار مرز سلول را به [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) تنظیم می‌کند تا نامرئی شوند.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
        }
    }

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ادغام سلول‌های جدول**

از [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) برای ترکیب یک محدوده مستطیلی از سلول‌های جدول به یک سلول استفاده کنید. سلول‌های گوشهٔ بالایی‑چپ و گوشهٔ پایین‑راست محدوده را مشخص کنید. آرگومان نهایی کنترل می‌کند که آیا ادغام می‌تواند شامل سلول‌های خارج از محدوده مشخص‌شده باشد؛ `false` ادغام را درون آن محدوده نگه می‌دارد.

مثال یک جدول ۴×۴ با ستون‌ها و ردیف‌های ۷۰ نقطه‌ای ایجاد می‌کند، سپس چهار سلول مرکزی را از `(1, 1)` تا `(2, 2)` ادغام می‌کند. سلول حاصل دو ستون و دو ردیف را در بر می‌گیرد، در حالی که شبکهٔ زیرین جدول همچنان چهار ستون و چهار ردیف دارد. برای دسترسی به محتوای سلول ادغام‌شده یا قالب‌بندی آن، از موقعیت بالایی‑چپ استفاده کنید: `$table->get_Item(1, 1)` در این مثال. سایر موقعیت‌ها در محدودهٔ ادغام‌شده همچنان بخشی از شبکهٔ جدول باقی می‌مانند، بنابراین ایندکس‌های سلول‌های خارج از محدوده تغییر نمی‌کنند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->mergeCells($table->get_Item(1, 1), $table->get_Item(2, 2), false);

    $presentation->save("merged_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تقسیم سلول‌های جدول**

ادغام سلول‌ها در مثال قبلی شبکهٔ جدول را حفظ می‌کند. تقسیم یک سلول می‌تواند یک ستون جدید به شبکه اضافه کند و ایندکس‌های ستون‌های سمت راست آن را تغییر دهد. Aspose.Slides مدل شبکهٔ جدول PowerPoint را دنبال می‌کند.

این مثال یک جدول ۴×۴ با ستون‌ها و ردیف‌های ۷۰ نقطه‌ای ایجاد می‌کند و روی سلول `(1, 1)` متد [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) را صدا می‌زند. نیمی از عرض ۷۰ نقطه‌ای سلول به‌منظور ایجاد دو سلول با عرض مساوی منتقل می‌شود.

پس از این تقسیم، دو نیمه به صورت `$table->get_Item(1, 1)` و `$table->get_Item(2, 1)` دسترسی پیدا می‌کنند. شبکهٔ جدول اکنون دارای پنج ستون است: سلول‌هایی که قبلاً در ستون‌های ۲ و ۳ بودند به ستون‌های ۳ و ۴ منتقل می‌شوند. ایندکس‌های ردیف بدون تغییر می‌مانند. هنگام دسترسی به سلول‌ها پس از تقسیم، از این ایندکس‌های به‌روز شدهٔ ستون استفاده کنید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 1)->splitByWidth(java_values($table->get_Item(1, 1)->getWidth()) / 2);

    $presentation->save("split_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **تقسیم سلول‌های ادغام‌شده بر حسب ردیف یا ستون**

برای آماده‌سازی سلول‌های الگوی ادغام‌شده برای پر کردن داده، از [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) برای تقسیم بر اساس مرز ردیف موجود یا از [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) برای تقسیم بر اساس مرز ستون استفاده کنید.

آرگومان `index` ردیف‌ها را در بخش بالایی یا ستون‌ها را در بخش چپ تقسیم می‌شمارید؛ این مقدار نسبت به ناحیهٔ ادغام‌شده است:

- تقسیم ردیف: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- تقسیم ستون: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

مثال فرض می‌کند ارائه دارای جدولی به عنوان اولین شکل در اولین اسلاید باشد، به‌طوری که سلول‌های `(1, 2)` و `(1, 3)` به صورت عمودی ادغام شده‌اند. از موقعیت پایین شروع می‌کند و با استفاده از [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) و [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) ریشه را پیدا می‌کند و هر دو اسپن را بررسی می‌کند. `splitByRowSpan(1)` سپس ردیف‌های ۲ و ۳ را برای نام‌های محصول جدا می‌کند. برای ادغام افقی دو ستونی، به‌جای آن از `splitByColSpan(1)` استفاده کنید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table_template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $selectedCell = $table->get_Item(1, 3);
    $firstColumnIndex = java_values($selectedCell->getFirstColumnIndex());
    $firstRowIndex = java_values($selectedCell->getFirstRowIndex());
    $mergedCell = $table->get_Item($firstColumnIndex, $firstRowIndex);

    if (java_values($mergedCell->isMergedCell()) && java_values($mergedCell->getRowSpan()) == 2 && java_values($mergedCell->getColSpan()) == 1)
    {
        $mergedCell->splitByRowSpan(1);

        // سلول‌های حاصل پس از تقسیم را از جدول دریافت کنید.
        $upperCell = $table->get_Item($firstColumnIndex, $firstRowIndex);
        $lowerCell = $table->get_Item($firstColumnIndex, $firstRowIndex + 1);
        echo "Upper cell merged: " . (java_values($upperCell->isMergedCell()) ? "true" : "false") . PHP_EOL;
        echo "Lower cell merged: " . (java_values($lowerCell->isMergedCell()) ? "true" : "false") . PHP_EOL;

        $upperCell->getTextFrame()->setText("Product A");
        $lowerCell->getTextFrame()->setText("Product B");

        $presentation->save("split_template.pptx", SaveFormat::Pptx);
    }
    else
    {
        echo "Select a merged region spanning exactly two rows and one column." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

شبکهٔ جدول و ایندکس‌های سلول‌های اطراف بدون تغییر می‌مانند. سلول‌های حاصل را بر اساس مختصاتشان دریافت کنید؛ در اینجا هر دو اسپن ۱ دارند و [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) مقدار `false` را باز می‌گرداند. نواحی بزرگتر می‌توانند پس از یک تقسیم قسمتی ادغام‌مانده بمانند.

متن اصلی و قالب‌بندی آن در سلول بالا (یا چپ) باقی می‌ماند؛ سلول جدید خالی است اما قالب‌بندی سلول مثل پر‑بار، مرزها و حاشیه‌ها را به ارث می‌برد. پس از تقسیم سلول‌ها را پر کنید و هر قالب‌بندی متنی مورد نیاز را صراحتاً تنظیم کنید.

ارائهٔ ذخیره‌شده شامل سلول‌های جداگانهٔ «Product A» و «Product B» است که قالب‌بندی سلول قالب حفظ شده است. برای جزئیات به [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) مراجعه کنید.

## **تغییر رنگ پس‌زمینه سلول جدول**

این مثال جدولی با ستون‌های ۱۵۰ نقطه‌ای و ردیف‌های ۵۰ نقطه‌ای ایجاد می‌کند. از [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) برای انتخاب پر‑بار جامد استفاده می‌کند و رنگی که توسط [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) برگردانده می‌شود را برای سلول `(2, 3)` (ستون سوم و ردیف چهارم) به قرمز تنظیم می‌کند.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 50, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **اضافه کردن تصویر داخل یک سلول جدول**

تصویر ورودی را قبل از اجرای این مثال در پوشهٔ کاری قرار دهید. تصویر را با [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) بارگیری می‌کند و با [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) به مجموعهٔ تصویرهای ارائه اضافه می‌کند. سپس تصویر را به پر‑بار تصویر سلول `(0, 0)` (اولین سلول جدول) اختصاص می‌دهد.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) تصویر را برای پر کردن سلول کش می‌دهد که ممکن است نسبت ابعاد آن را تغییر دهد. عرض ستون‌ها و ارتفاع ردیف‌ها بر حسب نقطه است. تصویر بارگیری‌شده پس از افزودن به ارائه در یک بلوک `finally` آزاد می‌شود.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 100, 100, 100, 100, 90 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $image = Images::fromFile("aspose_logo.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->setFillType(FillType::Picture);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("table_cell_with_image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**آیا می‌توانم ضخامت و سبک خطوط متفاوتی برای جهات مختلف یک سلول واحد تنظیم کنم؟**

بله. مرزهای [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) دارای ویژگی‌های جداگانه هستند، بنابراین ضخامت و سبک هر سمت می‌تواند متفاوت باشد.

**اگر پس از تنظیم یک تصویر به عنوان پس‌زمینهٔ سلول، اندازهٔ ستون/ردیف را تغییر دهم، چه اتفاقی می‌افتد؟**

رفتار بستگی به [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile) دارد. با کشش، تصویر با سلول جدید سازگار می‌شود؛ با کاشی‌گذاری، کاشی‌ها مجدداً محاسبه می‌شوند.

**آیا می‌توانم یک پیوند را به تمام محتوای یک سلول اختصاص دهم؟**

[پیوندها](/slides/fa/php-java/manage-hyperlinks/) در سطح متن (پارت) داخل قاب متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، پیوند را به یک پارت یا تمام متن داخل سلول اختصاص می‌دهید.

**آیا می‌توانم فونت‌های متفاوتی داخل یک سلول تنظیم کنم؟**

بله. قاب متن یک سلول از [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (بخش‌ها) با قالب‌بندی مستقل—خانوادهٔ قلم، سبک، اندازه و رنگ—پشتیبانی می‌کند.