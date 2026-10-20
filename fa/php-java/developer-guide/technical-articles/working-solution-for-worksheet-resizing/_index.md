---
title: راه‌حل عملی برای تغییر اندازه برگه کاری
type: docs
weight: 20
url: /fa/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- تصویر پیش‌نمایش
- تغییر اندازه تصویر
- Excel
- برگه کاری
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "رفع تغییر اندازه OLE برگه Excel در ارائه‌ها: دو روش برای حفظ یکنواختی قاب‌های شیء—مقیاس‌بندی قاب یا برگه—در فرمت‌های PPT و PPTX."
---
{{% alert color="info" title="Note" %}}

برگه‌های Excel که به عنوان اشیاء OLE در یک ارائه PowerPoint با استفاده از مؤلفه‌های Aspose جاسازی می‌شوند، ممکن است پس از اولین فعال‌سازی به‌ طور غیرمنتظره‌ای اندازه‌شان تغییر کند. این رفتار تفاوت بصری قابل‌توجهی بین شیء OLE قبل و بعد از فعال‌سازی ایجاد می‌کند. این مقاله به توضیح مشکل می‌پردازد و دو روش برای رفع آن را توصیف می‌کند.

{{% /alert %}}

## **پیش‌زمینه**

در مقاله [مدیریت OLE](/slides/fa/php-java/manage-ole/)، ما توضیح دادیم که چگونه یک قاب OLE را به یک ارائه PowerPoint با استفاده از Aspose.Slides برای PHP از طریق Java اضافه کنیم. برای رفع [مسئله پیش‌نمایش شیء](/slides/fa/php-java/object-preview-issue-when-adding-oleobjectframe/)، تصویری از ناحیه انتخاب‌شده برگه کاری را به قاب شیء OLE اختصاص دادیم. در ارائه خروجی، وقتی که روی قاب شیء OLE که تصویر برگه کاری را نشان می‌دهد دوبار کلیک کنید، کتاب‌خانه Excel فعال می‌شود. کاربران نهایی می‌توانند هر تغییر دلخواهی را در کتاب‌خانه Excel واقعی اعمال کنند و سپس با کلیک خارج از کتاب‌خانه فعال شده به اسلاید بازگردند. اندازهٔ قاب شیء OLE هنگام بازگشت کاربر به اسلاید تغییر خواهد کرد. عامل تغییر اندازه بسته به اندازهٔ قاب شیء OLE و کتاب‌خانه Excel جاسازی‌شده متفاوت خواهد بود.

## **علت تغییر اندازه**

از آنجا که کتاب‌خانه Excel اندازهٔ پنجرهٔ خود را دارد، سعی می‌کند پس از اولین فعال‌سازی اندازهٔ اصلی خود را حفظ کند. از سوی دیگر، قاب شیء OLE اندازهٔ مخصوص به خود را دارد. طبق گفته مایکروسافت، وقتی کتاب‌خانه Excel فعال می‌شود، Excel و PowerPoint برای تعیین اندازه‌ توافق می‌کنند تا اطمینان حاصل شود نسبت‌های صحیح را در فرآیند جاسازی حفظ می‌کند. تغییر اندازه بر اساس تفاوت‌های بین اندازهٔ پنجرهٔ Excel و اندازه و موقعیت قاب شیء OLE رخ می‌دهد.

## **راه‌حل عملی**

دو راه‌حل ممکن برای جلوگیری از اثر تغییر اندازه وجود دارد.

- قاب OLE را در ارائه PowerPoint مقیاس‌بندی کنید تا با کل ارتفاع و عرض ردیف‌ها و ستون‌های انتخاب‌شده مطابقت داشته باشد.
- اندازهٔ قاب OLE را ثابت نگه دارید و ردیف‌ها و ستون‌های انتخاب‌شده را برای متناسب شدن با آن مقیاس‌بندی کنید.

### **مقیاس‌بندی اندازهٔ قاب OLE**

این روش اندازهٔ قاب OLE را به‌گونه‌ای تنظیم می‌کند که با کل ارتفاع و عرض ردیف‌ها و ستون‌های انتخاب‌شده در برگه Excel جاسازی‌شده مطابقت داشته باشد.

مثال یک کتاب‌خانه Excel موجود را بارگذاری می‌کند و با استفاده از ایندکس‌های صفر‑محور، اولین ۱۰ ردیف و ۱۳ ستون از برگهٔ اول آن را انتخاب می‌نماید. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) دامنهٔ نمایش‑داده‌شده را تعریف می‌کند. پیش‌نمایش با ۹۶ DPI رندر می‌شود و ابعاد پیکسلی آن با استفاده از ۷۲ پوینت در اینچ به پوینت تبدیل می‌شود. [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) کتاب‌خانهٔ تغییر یافته را در قاب با آن ابعاد جاسازی می‌کند. پیش‌نمایش از طریق [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) اختصاص داده می‌شود تا جایگزین متن نگهدارندهٔ «EMBEDDED OLE OBJECT» در ارائهٔ ذخیره‌شده شود.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // جاسازی کتاب‌کار تغییر یافته و نگهداری داده‌های باینری در آرایه‌های بایت جاوا.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $frameWidth = java_values($image->getWidth()) * 72.0 / $imageResolution;
        $frameHeight = java_values($image->getHeight()) * 72.0 / $imageResolution;
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

کمک‌کنندهٔ پیش‌نمایش [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) را روی بازهٔ انتخاب‌شده تنظیم می‌کند و حاشیه‌ها، سرصفحه‌ها و پاورقی‌ها را حذف می‌نماید. با فعال بودن [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea)، [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) بازه را به‌عنوان تصویر PNG رندر می‌کند. این کمک‌کننده یک جریان ورودی جدید شامل تصویر PNG باز می‌گرداند که در ابتدا قرار دارد تا در ارائه استفاده شود.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

### **مقیاس‌بندی اندازهٔ محدودهٔ سلول**

این روش ارتفاع ردیف‌های انتخاب‌شده و عرض ستون‌های انتخاب‌شده را مقیاس‌بندی می‌کند تا با یک اندازهٔ سفارشی قاب OLE مطابقت داشته باشد.

مثال یک کتاب‌خانه Excel موجود را بارگذاری می‌کند و با استفاده از ایندکس‌های صفر‑محور، اولین ۱۰ ردیف و ۱۳ ستون از برگهٔ اول آن را انتخاب می‌نماید. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) بازهٔ نمایش‑داده‌شده را تعریف می‌کند و کمک‌کننده زیر آن بازه را برای متناسب شدن با قاب ۴۰۰ پوینت عرض و ۱۰۰ پوینت ارتفاع مقیاس‌بندی می‌کند. پس از ذخیرهٔ کتاب‌خانهٔ تغییر یافته در یک جریان، [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) آن را با اندازهٔ مشخص جاسازی می‌کند. پیش‌نمایشی که با ۹۶ DPI رندر شده است از طریق [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) اختصاص می‌یابد، به‌طوری که ارائهٔ ذخیره‌شده سلول‌های انتخاب‌شده را به‌جای نگهدارندهٔ پیش‌فرض نشان می‌دهد.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);
    $frameWidth = 400;
    $frameHeight = 100;
    ScaleCellRange($cellRange, $frameWidth, $frameHeight);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // جاسازی کتاب‌کار تغییر یافته و نگه‌داری داده‌های باینری در آرایه‌های بایت جاوا.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

کمک‌کنندهٔ مقیاس‌بندی نسبت‌های عرض و ارتفاع جداگانه‌ای برای بازهٔ انتخاب‌شده محاسبه می‌کند و عرض نسبی ستون‌ها و ارتفاع نسبی ردیف‌ها را حفظ می‌نماید. ابعاد محاسبه‌شده را قبل از اعمال با [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) و [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch) از پوینت به اینچ تبدیل می‌کند. بازهٔ انتخاب‌شده باید عرض و ارتفاع غیرصفر داشته باشد.

```php
use aspose\cells\CellsUnitType;

// عرض و ارتفاع ابعاد مورد انتظار بازه سلول به پوینت هستند.
function ScaleCellRange($cellRange, $width, $height) {
    $rangeWidth = java_values($cellRange->getWidth());
    $rangeHeight = java_values($cellRange->getHeight());
    $cells = $cellRange->getWorksheet()->getCells();
    $columnCount = java_values($cellRange->getColumnCount());
    $rowCount = java_values($cellRange->getRowCount());
    $firstColumn = java_values($cellRange->getFirstColumn());
    $firstRow = java_values($cellRange->getFirstRow());

    for ($i = 0; $i < $columnCount; $i++) {
        $columnIndex = $firstColumn + $i;
        $columnWidth = java_values($cells->getColumnWidth($columnIndex, false, CellsUnitType::POINT));
        $newColumnWidth = $columnWidth * $width / $rangeWidth;
        $widthInInches = $newColumnWidth / 72.0;
        $cells->setColumnWidthInch($columnIndex, $widthInInches);
    }

    for ($i = 0; $i < $rowCount; $i++) {
        $rowIndex = $firstRow + $i;
        $rowHeight = java_values($cells->getRowHeight($rowIndex, false, CellsUnitType::POINT));
        $newRowHeight = $rowHeight * $height / $rangeHeight;
        $heightInInches = $newRowHeight / 72.0;
        $cells->setRowHeightInch($rowIndex, $heightInInches);
    }
}
```

این کمک‌کنندهٔ پیش‌نمایش بازهٔ تغییر اندازه‌ داده‌شده را با استفاده از [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) رندر می‌کند. [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) را به آن بازه محدود می‌کند، حاشیه‌ها، سرصفحه‌ها و پاورقی‌ها را حذف می‌نماید و یک جریان PNG را که در ابتدا قرار دارد برمی‌گرداند.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

## **نتیجه‌گیری**

{{% alert color="info" title="Note" %}}

دو رویکرد برای رفع مشکل تغییر اندازه برگه وجود دارد. رویکردی را انتخاب کنید که بهترین تطابق را با نیازها و موارد کاربرد شما داشته باشد. هر دو رویکرد به‌ همان صورت کار می‌کنند، چه ارائه‌ها از یک الگو ساخته شوند و چه از صفر. علاوه بر این، در این راه‌حل هیچ محدودیتی برای اندازهٔ قاب شیء OLE وجود ندارد.

{{% /alert %}}

## **پرسش‌های متداول**

**چرا یک برگه Excel جاسازی‌شده هنگام اولین فعال‌سازی در PowerPoint اندازه‌اش تغییر می‌کند؟**

این به این دلیل است که Excel سعی می‌کند هنگام فعال‌سازی اندازهٔ اصلی پنجرهٔ خود را حفظ کند، در حالی که قاب شیء OLE در PowerPoint ابعاد خاص خود را دارد. PowerPoint و Excel برای حفظ نسبت ابعاد توافق می‌کنند که می‌تواند منجر به تغییر اندازه شود.

**آیا می‌توان این مشکل تغییر اندازه را به طور کامل جلوگیری کرد؟**

بله. با مقیاس‌بندی قاب OLE به‌طوری که متناسب با اندازهٔ محدودهٔ سلول‌های Excel باشد یا با مقیاس‌بندی محدودهٔ سلول‌ها برای متناسب شدن با اندازهٔ مطلوب قاب OLE، می‌توانید از تغییر اندازه ناخواسته جلوگیری کنید.

**کدام روش مقیاس‌بندی را باید استفاده کنم، مقیاس‌بندی قاب OLE یا مقیاس‌بندی محدودهٔ سلول؟**

اگر می‌خواهید اندازه‌های اولیه ردیف‌ها و ستون‌های Excel را حفظ کنید، **مقیاس‌بندی قاب OLE** را انتخاب کنید. اگر به یک اندازه ثابت برای قاب OLE در ارائهٔ خود نیاز دارید، **مقیاس‌بندی محدودهٔ سلول** را انتخاب کنید.

**آیا این راه‌حل‌ها در صورتی که ارائهٔ من بر پایهٔ یک الگو باشد کار می‌کنند؟**

بله. هر دو راه‌حل برای ارائه‌های ایجاد شده از الگوها و همچنین از ابتدا کار می‌کنند.

**آیا محدودیتی برای اندازهٔ قاب OLE هنگام استفاده از این روش‌ها وجود دارد؟**

خیر. می‌توانید قاب شیء OLE را به هر اندازه‌ای بسازید به شرطی که مقیاس را به‌درستی تنظیم کنید.

**آیا راهی برای حذف متن نگهدارندهٔ «EMBEDDED OLE OBJECT» در PowerPoint وجود دارد؟**

بله. با گرفتن یک snapshot از محدودهٔ سلول هدف در Excel و تنظیم آن به‌عنوان تصویر نگهدارندهٔ قاب OLE، می‌توانید تصویر پیش‌نمایش سفارشی را به‌جای نگهدارنده پیش‌فرض نمایش دهید.

## **مقاله‌های مرتبط**

[ایجاد یک نمودار Excel و جاسازی آن در یک ارائه به‌عنوان شیء OLE](/slides/fa/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[به‌روزرسانی خودکار اشیاء OLE با استفاده از افزونهٔ MS PowerPoint](/slides/fa/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)