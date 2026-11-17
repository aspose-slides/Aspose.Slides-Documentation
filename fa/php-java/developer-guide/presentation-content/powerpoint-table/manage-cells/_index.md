---
title: مدیریت سلول‌های جدول در ارائه‌ها با PHP
linktitle: مدیریت سلول‌ها
type: docs
weight: 30
url: /fa/php-java/manage-cells/
keywords:
- سلول جدول
- ادغام سلول‌ها
- حذف حاشیه
- تقسیم سلול
- تصویر در سلول
- رنگ پس‌زمینه
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت سلول‌های جدول PowerPoint در PHP: شناسایی سلول‌های ترکیب‌شده، حذف حاشیه‌ها، تقسیم سلول‌ها، و تنظیم رنگ پس‌زمینه و تصاویر با Aspose.Slides برای PHP از طریق Java."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد سلول‌های جدول در ارائه‌های PowerPoint را دسترسی و اصلاح کنید. این مقاله توضیح می‌دهد چگونه سلول‌های جدول ترکیب‌شده را شناسایی کنید، حاشیه‌های سلول را حذف کنید، پس از ترکیب یا جداسازی سلول‌ها با شماره‌گذاری سلول کار کنید، رنگ پس‌زمینه یک سلول را تغییر دهید و تصویر را داخل یک سلول جدول اضافه کنید. مثال‌ها نشان می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روز کنید و ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

Aspose.Slides از ایندکس‌های صفر‑محور برای دسترسی به سلول‌های جدول به ترتیب `(ستون، ردیف)` استفاده می‌کند.

## **شناسایی یک سلول جدول ترکیب‌شده**

این مثال یک ارائه موجود را باز می‌کند و اولین شکل در اولین اسلاید را به‌عنوان جدول دسترسی می‌دهد. فرض می‌شود اسلاید و شکل وجود داشته باشند و شکل یک جدول باشد. سپس تمام ردیف‌ها و ستون‌ها را پیمایش می‌کند و از [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) برای شناسایی سلول‌های موجود در نواحی ترکیب‌شده استفاده می‌کند. برای هر تطبیق، مختصات سلول را به ترتیب `row;column`، [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/)، [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/)، و مختصات شروع ناحیه، [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) و [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) چاپ می‌کند.

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

## **حذف حاشیه‌های سلول جدول**

یک [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد کنید و با استفاده از [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) یک جدول به اولین اسلاید آن اضافه کنید. عرض ستون‌ها، ارتفاع ردیف‌ها و موقعیت جدول بر حسب نقطه مشخص می‌شود. این مثال تمام چهار حاشیه سلول را به [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) تنظیم می‌کند تا نامرئی شوند.

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

## **اضافه کردن حاشیه‌های مورب سلول**

از [getBorderDiagonalDown](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonaldown/) برای رسم خطی از گوشه بالا‑چپ به پایین‑راست و از [getBorderDiagonalUp](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonalup/) برای رسم خطی از گوشه پایین‑چپ به بالا‑راست استفاده کنید. یک مورب می‌تواند سرصفحهٔ گوشه‌ای را نشان دهد؛ هر دو مورب می‌توانند شکل Xی ایجاد کنند تا سلول به‌عنوان عدم‌قابلیت اعمال علامت‌دار شود.

هر مورب دارای [LineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) خودش است. در [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) از [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) برای انتخاب [FillType::Solid](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) و از طریق [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) یک رنگ انتخاب کنید. عرض خط را بر حسب نقطه با [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) تنظیم کنید.

این مثال سه سلول در یک ردیف ایجاد می‌کند: یک مورب نزولی قرمز، یک مورب صعودی آبی و هر دو مورب. حاشیه‌های بالا، پایین، چپ و راست سلول‌ها دست‌نخورده می‌مانند.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 210, 210, 210 ];
    $rowHeights = [ 160 ];
    $table = $slide->getShapes()->addTable(45, 130, $columnWidths, $rowHeights);

    $downwardBorder = $table->get_Item(0, 0)->getCellFormat()->getBorderDiagonalDown();
    $downwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $downwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $downwardBorder->setWidth(3);

    $upwardBorder = $table->get_Item(1, 0)->getCellFormat()->getBorderDiagonalUp();
    $upwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $upwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $upwardBorder->setWidth(5);

    $crossDownwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalDown();
    $crossDownwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossDownwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $crossDownwardBorder->setWidth(3);

    $crossUpwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalUp();
    $crossUpwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossUpwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $crossUpwardBorder->setWidth(5);

    $presentation->save("diagonal_cell_borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

یک مورب فقط قالب‌بندی سلول را تغییر می‌دهد. هر سلول یک چارچوب متن دارد که از طریق [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) قابل دسترسی است. نواحی هر دو طرف یک مورب نمی‌توانند به‌صورت مستقل ویرایش شوند.

جدول ذخیره‌شده، در Microsoft PowerPoint رندر می‌شود:

![سه سلول جدول که یک مورب قرمز از بالا‑چپ به پایین‑راست، یک مورب آبی از پایین‑چپ به بالا‑راست و هر دو مورب شکل X تشکیل می‌دهند.](diagonal-cell-borders.png)

*از چپ به راست: مورب نزولی (قرمز، 3 pt)، مورب صعودی (آبی، 5 pt) و هر دو مورب.*

## **ترکیب سلول‌های جدول**

از [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) برای ترکیب یک بازهٔ مستطیلی از سلول‌های جدول به یک سلول استفاده کنید. سلول‌های گوشهٔ بالا‑چپ و پایین‑راست بازه را مشخص کنید. آرگومان نهایی تعیین می‌کند آیا ترکیب می‌تواند شامل سلول‌های خارج از بازه مشخص‌شده باشد؛ `false` ترکیب را درون آن بازه نگه می‌دارد.

این مثال یک جدول 4×4 با ستون‌ها و ردیف‌های 70 نقطه‌ای ایجاد می‌کند، سپس چهار سلول مرکزی را از `(1, 1)` تا `(2, 2)` ترکیب می‌کند. سلول حاصل دو ستون و دو ردیف را پوشش می‌دهد، در حالی که شبکهٔ زیرین جدول همچنان چهار ستون و چهار ردیف را حفظ می‌کند. برای دسترسی به محتوای یا قالب‌بندی سلول ترکیب‌شده، از موقعیت بالا‑چپ آن استفاده کنید: `$table->get_Item(1, 1)` در این مثال. سایر موقعیت‌های درون بازه ترکیب‌شده همچنان بخشی از شبکه جدول می‌مانند، بنابراین ایندکس‌های سلول‌های خارج از بازه تغییر نمی‌کنند.

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

## **جداسازی سلول‌های جدول**

ترکیب سلول‌ها در مثال قبلی شبکه جدول را حفظ می‌کند. جداسازی یک سلول می‌تواند یک ستون جدید به شبکه اضافه کند و ایندکس ستون‌های سمت راست آن را تغییر دهد. Aspose.Slides مدل شبکه جدول PowerPoint را دنبال می‌کند.

این مثال یک جدول 4×4 با ستون‌ها و ردیف‌های 70 نقطه‌ای ایجاد می‌کند و بر روی سلول `(1, 1)` [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) را فراخوانی می‌کند. نیمی از عرض 70 نقطه‌ای سلول برای ایجاد دو سلول با عرض مساوی به‌کار رفته است.

پس از این جداسازی، دو نیمه به‌صورت `$table->get_Item(1, 1)` و `$table->get_Item(2, 1)` دسترسی دارند. شبکه جدول اکنون پنج ستون دارد: سلول‌های اصلی در ستون‌های 2 و 3 به ستون‌های 3 و 4 منتقل می‌شوند. ایندکس‌های ردیف بدون تغییر می‌مانند. هنگام دسترسی به سلول‌ها پس از جداسازی، از این ایندکس‌های ستون به‌روزرسانی‌شده استفاده کنید.

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

<!-- visual-explanation:manage-cells:start -->
[![یک سلول 70‑نقطه‌ای که ترکیب نشده به دو سلول 35‑نقطه‌ای تقسیم می‌شود، یک ستون شبکهٔ پنجم را اضافه می‌کند و ایندکس‌های سمت راست را جابجا می‌کند.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*تقسیم عرض بر سلول (1, 1) تأثیر می‌گذارد، با استفاده از ایندکس‌های صفر‑محور (ستون، ردیف). سایر ردیف‌ها سلولی که هر دو موقعیت ستون جدید را پوشش می‌دهد، حفظ می‌کنند.*
<!-- visual-explanation:manage-cells:end -->

### **جداسازی سلول‌های ترکیب‌شده بر حسب ردیف یا ستون**

برای آماده‌سازی سلول‌های قالب ترکیب‌شده برای پر کردن داده‌ها، از [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) برای جداسازی بر حسب مرز ردیف موجود یا از [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) برای جداسازی بر حسب مرز ستون استفاده کنید.

آرگومان `index` تعداد ردیف‌ها در قسمت بالایی یا تعداد ستون‌ها در قسمت چپ جداسازی را می‌شمارد؛ این مقدار نسبت به ناحیهٔ ترکیب‌شده است:

- جداسازی ردیف: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- جداسازی ستون: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

این مثال انتظار دارد ارائه دارای جدول به‌عنوان اولین شکل در اولین اسلاید باشد، به‌طوری که `(1, 2)` و `(1, 3)` به‌صورت عمودی ترکیب شده‌اند. از موقعیت پایین شروع می‌کند، از [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) و [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) برای یافتن مبدأ استفاده می‌کند و هر دو بازه را بررسی می‌کند. `splitByRowSpan(1)` سپس ردیف‌های 2 و 3 را برای نام محصولات جدا می‌کند. برای ترکیب افقی دو ستونی، به‌جای آن از `splitByColSpan(1)` استفاده کنید.

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

        // سلول‌های حاصل از جدول پس از جداسازی را بازیابی کنید.
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

شبکه جدول و ایندکس‌های سلول‌های اطراف بدون تغییر می‌مانند. سلول‌های حاصل را بر حسب مختصات بازیابی کنید؛ در اینجا هر دو دارای بازهٔ 1 هستند و [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) `false` چاپ می‌کند. نواحی بزرگتر می‌توانند پس از یک جداسازی همچنان جزئی ترکیب‌شده بمانند.

متن اصلی و قالب‌بندی آن در سلول بالایی (یا چپ) باقی می‌ماند؛ سلول جدید خالی است اما قالب‌بندی سلول مانند پر‑کردن، حاشیه‌ها و حاشیه داخلی را به ارث می‌برد. پس از جداسازی سلول‌ها را پر کنید و هر قالب‌بندی متنی مورد نیاز را به‌صورت صریح تنظیم کنید.

ارائهٔ ذخیره‌شده شامل سلول‌های جداگانهٔ «Product A» و «Product B» با حفظ قالب‌بندی سلول قالب است. برای جزئیات بیشتر به [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) مراجعه کنید.

### **جداسازی یک سلول بر حسب ارتفاع مشخص**

[splitByHeight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyheight/) ارتفاع بخش بالایی را بر حسب نقطه می‌گیرد. [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) تعداد ردیف‌های موجود در بخش بالایی را می‌گیرد. برای مرکز کردن یک سلول 40‑نقطه‌ای در ستون راست، 40 را از ارتفاع واقعی سلول کم کنید و فضای باقی‌مانده را به‌صورت مساوی بالا و پایین تقسیم کنید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 160, 160 ];
    $rowHeights = [ 140 ];
    
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);
    $table->get_Item(0, 0)->getTextFrame()->setText("Left");

    $rightCell = $table->get_Item(1, 0);
    $height = java_values($rightCell->getHeight());
    $margin = ($height - 40) / 2;

    $rightCell->splitByHeight($margin);
    $table->get_Item(1, 1)->splitByHeight(40);
    $table->get_Item(1, 1)->getTextFrame()->setText("Middle");

    $presentation->save("split_by_height.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

اولین جداسازی یک ردیف شبکه اضافه می‌کند و 90 نقطهٔ پایین را در سلول `(1, 1)` می‌گذارد. جداسازی دوم آن سلول را به یک سلول میانی 40 نقطه‌ای و یک سلول پایینی 50 نقطه‌ای تقسیم می‌کند. ستون راست اکنون سه سلول با ارتفاع‌های 50، 40 و 50 نقطه از بالا به پایین دارد. سلول چپ تمام سه ردیف را پوشش می‌دهد و ارتفاع اصلی 140 نقطه‌ای خود را حفظ می‌کند.

![سلول چپ تمام ارتفاع جدول را در کنار سه سلول با «Middle» در وسط پوشش می‌دهد.](split-by-height.png)

## **تغییر رنگ پس‌زمینه سلول جدول**

این مثال جدول با ستون‌های 150 نقطه‌ای و ردیف‌های 50 نقطه‌ای ایجاد می‌کند. با استفاده از [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) یک پر‑کردن صلب انتخاب می‌شود و رنگ بازگشت‌داده‌شده توسط [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) برای سلول `(2, 3)`، که در ستون سوم و ردیف چهارم است، به قرمز تنظیم می‌شود.

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

## **افزودن تصویر داخل یک سلول جدول**

تصویر ورودی را قبل از اجرای این مثال در پوشه کاری قرار دهید. تصویر با استفاده از [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) بارگذاری می‌شود و با [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) به مجموعهٔ تصاویر ارائه اضافه می‌گردد. سپس تصویر به پر‑کردن تصویر سلول `(0, 0)`، اولین سلول جدول، اختصاص داده می‌شود.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) تصویر را برای پر کردن سلول کش می‌دهد که ممکن است نسبت ابعاد آن را تغییر دهد. عرض ستون‌ها و ارتفاع ردیف‌ها بر حسب نقطه است. تصویر بارگذاری‌شده پس از افزودن به ارائه در یک بلوک `finally` حذف می‌شود.

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

## **سؤالات متداول**

**آیا می‌توانم ضخامت و سبک خطوط مختلف را برای طرف‌های متفاوت یک سلول تنظیم کنم؟**

بله. حاشیه‌های [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) دارای ویژگی‌های جداگانه‌ای هستند، بنابراین ضخامت و سبک هر طرف می‌تواند متفاوت باشد.

**اگر پس از تنظیم تصویر به‌عنوان پس‌زمینه سلول، اندازهٔ ستون/ردیف را تغییر دهم چه اتفاقی می‌افتد؟**

رفتار بستگی به [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (کشیدن/کاشی) دارد. در حالت کشیدن، تصویر با سلول جدید منطبق می‌شود؛ در حالت کاشی، کاشی‌ها مجدداً محاسبه می‌شوند.

**آیا می‌توانم یک پیوند را به تمام محتوای یک سلول اختصاص دهم؟**

[Hyperlinks](/slides/fa/php-java/manage-hyperlinks/) در سطح بخش متن (portion) داخل چارچوب متن سلول یا در سطح تمام جدول/شکل تنظیم می‌شوند. در عمل، پیوند را به یک بخش یا تمام متن داخل سلول اختصاص می‌دهید.

**آیا می‌توانم فونت‌های متفاوتی داخل یک سلول تنظیم کنم؟**

بله. چارچوب متن سلول از [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (قطعات) با قالب‌بندی مستقل—خانوادهٔ فونت، سبک، اندازه و رنگ—پشتیبانی می‌کند.