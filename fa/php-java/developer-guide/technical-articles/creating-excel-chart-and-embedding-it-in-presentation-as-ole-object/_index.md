---
title: ایجاد نمودارهای Excel و جاسازی آن‌ها در ارائه‌ها به‌عنوان اشیای OLE
type: docs
weight: 30
url: /fa/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- نمودار Excel
- جاسازی نمودار
- شی OLE
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یک نمودار Excel با Aspose.Cells برای PHP از طریق Java ایجاد کنید و کتاب‌کار را در یک ارائه PowerPoint با Aspose.Slides برای PHP از طریق Java جاسازی کنید، به‌همراه پیش‌نمایش نمودار."
---
## **مرور کلی**

این مقاله نشان می‌دهد چگونه می‌توانید یک نمودار ستونی Excel را با Aspose.Cells for PHP via Java ایجاد کنید و کتاب‌کار آن را در یک ارائه PowerPoint با Aspose.Slides for PHP via Java جاسازی کنید. کتاب‌کار جاسازی‌شده شامل داده‌های منبع و نمودار است. یک پیش‌نمایش PNG جداگانه، نمودار را بر روی اسلاید قبل از فعال شدن شی OLE نمایش می‌دهد.

نتیجه یک شیء Excel جاسازی‌شده است، نه یک نمودار بومی PowerPoint. ویرایش کتاب‌کار از طریق OLE نیاز به برنامهٔ دسکتاپی دارد که پشتیبانی از فعال‌سازی OLE را داشته باشد و نصب Excel سازگار باشد.

## **پیش‌نیازها**

Aspose.Cells for PHP via Java و Aspose.Slides for PHP via Java را با همان نمونهٔ PHP/Java Bridge پیکربندی کنید. هر دو wrapper PHP را بارگذاری کنید و کتابخانه‌های جاوا هر دو محصول را برای پل در دسترس قرار دهید. برای تولید ارائه با این کتابخانه‌ها نیازی به Microsoft Office نیست.

فایلی ورودی مورد نیاز نیست: مثال داده‌ها و نمودار را در حافظه می‌سازد، سپس `OutputChart.pptx` را در پوشهٔ کاری فعلی می‌نویسد. هنگام اجرای خارج از حالت ارزیابی، برای هر دو محصول لایسنس اعمال کنید.

## **نحوهٔ کار جاسازی**

1. یک کتاب‌کار با یک برگه داده و یک برگه نمودار ایجاد کنید.  
1. برگه نمودار را فعال کنید تا کتاب‌کار روی نمودار باز شود.  
1. دامنهٔ نمایش OLE کتاب‌کار را تنظیم کنید و نمودار را به PNG رندر کنید.  
1. کتاب‌کار را به صورت XLSX در حافظه ذخیره کنید و آن بایت‌ها را در یک اسلاید جاسازی کنید.  
1. PNG را به عنوان پیش‌نمایش شیء OLE اختصاص دهید و ارائه را به صورت PPTX ذخیره کنید.  

دامنهٔ نمایش کتاب‌کار و قاب اسلاید نقش‌های متفاوتی دارند. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) مقدارهای شروع/پایان ردیف و ستون ایندکس‌دار صفر مبنا را می‌گیرد. [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) به‌جای آن، ردیف بالایی، ستون چپ، ردیف پایینی و ستون راست را می‌گیرد. در مثال، ایندکس ردیف 55 و ایندکس ستون 25 به‌عنوان مرزهای پایین‑راست استفاده شده‌اند؛ این مقادیر صرفاً انتخاب‌های چیدمان هستند و تعداد ردیف‌ها یا ستون‌های داده را نشان نمی‌دهند.

قاب اسلاید از واحد points استفاده می‌کند. در مثال، این قاب داخل اسلاید جای می‌گیرد و به‌صورت مرکزی قرار می‌گیرد در حالی که نسبت طول‑عرض PNG حفظ می‌شود، نه کشیده شدن پیش‌نمایش برای پر کردن اسلاید.

## **ایجاد و جاسازی نمودار**

مثال کامل زیر `DataSheet` را با چهار ردیف و پنج ستون مقدار پر می‌کند. هر ردیف تبدیل به یک سری دادهٔ نمودار می‌شود. قبل از ذخیرهٔ کتاب‌کار، `ChartSheet` به عنوان برگهٔ فعال انتخاب می‌شود.

کتاب‌کار به‌صورت صریح به XLSX ذخیره می‌شود، که با پسوند `xlsx` پاس‑ شده به [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) مطابقت دارد. نتایج عددی جاوا با `java_values` قبل از انجام عملیات ریاضی توسط PHP تبدیل می‌شوند، در حالی که داده‌های باینری در آرایه‌های بایت جاوا باقی می‌مانند. PNG مستقیماً از بایت‌های آن بدون تبدیل به bitmap میانی بارگذاری می‌شود. اختصاص آن از طریق [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) جایگزین placeholder پیش‌فرض OLE می‌شود.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // نگه داشتن PNG و XLSX به‌عنوان آرایه‌های بایتی Java هنگام انتقال به Slides.
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // متناسب کردن و مرکزگذاری پیش‌نمایش در حالی که نسبت ابعاد آن حفظ می‌شود.
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **نتیجهٔ مورد انتظار**

`OutputChart.pptx` شامل یک اسلاید با یک کتاب‌کار Excel جاسازی‌شده و پیش‌نمایش نمودار است. کتاب‌کار شامل داده‌های اصلی و یک نمودار ستونی با چهار سری است. پیش‌نمایش به‌صورت مرکزی بر روی اسلاید قرار گرفته و نسبت‌های خود را حفظ می‌کند.

![نمودار ستونی Excel که به عنوان پیش‌نمایش یک کتاب‌کار جاسازی‌شده نمایش داده می‌شود](excel-chart-ole-preview.png)

در محیط دسکتاپ PowerPoint که Excel در دسترس باشد، با دوبار کلیک بر روی شیء می‌توانید کتاب‌کار جاسازی‌شده را فعال و ویرایش کنید. فعال‌سازی و ویرایش بستگی به پشتیبانی OLE برنامهٔ میزبان و تنظیمات امنیتی دارد.

## **پرسش‌های متداول**

**چرا تصویر پیش‌نمایش مورد نیاز است؟**  
کتاب‌کار جاسازی‌شده و پیش‌نمایش اسلاید آن محتویات جداگانه‌ای هستند. برای اینکه اسلاید به جای placeholder پیش‌فرض «EMBEDDED OLE OBJECT» نمودار را نشان دهد، نیاز به یک تصویر نمودار دارید. نگاه کنید به [Object Preview Issue when Adding OleObjectFrame](/slides/fa/php-java/object-preview-issue-when-adding-oleobjectframe/).

**آیا پیش‌نمایش به‌صورت خودکار هنگام تغییر کتاب‌کار در کد به‌روزرسانی می‌شود؟**  
پیش‌نمایش را مانند یک snapshot در نظر بگیرید. هنگام به‌روزرسانی داده‌های کتاب‌کار برنامه‌نویسی، نمودار را دوباره تولید کنید و تصویر پیش‌نمایش و دادهٔ کتاب‌کار جاسازی‌شده را جایگزین کنید.

**آیا می‌توانم به‌جای XLSX از XLS استفاده کنم؟**  
بله. کتاب‌کار را در قالب XLS ذخیره کنید و از `xls` به‌عنوان پسوند دادهٔ جاسازی‌شده استفاده کنید. پسوند باید با قالب واقعی کتاب‌کار مطابقت داشته باشد؛ تغییر فقط پسوند بدون تبدیل داده مؤثر نیست.

**چرا ممکن است پس از فعال‌سازی اندازهٔ شیء تغییر کند؟**  
برنامهٔ میزبان می‌تواند ارائهٔ شیء OLE را هنگام فعال‌سازی کتاب‌کار به‌روز کند. هم دامنهٔ نمایش OLE کتاب‌کار و هم ابعاد قاب اسلاید نقش دارند. ببینید [Working Solution for Chart Resizing in PPTX](/slides/fa/java/working-solution-for-chart-resizing-in-pptx/).

## **بخش‌های مرتبط**

- [راه‌حل کاری برای تغییر اندازهٔ نمودار در PPTX](/slides/fa/java/working-solution-for-chart-resizing-in-pptx/)
- [مسئله پیش‌نمایش شیء هنگام افزودن OleObjectFrame](/slides/fa/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [مدیریت اشیاء OLE](/slides/fa/php-java/manage-ole/)