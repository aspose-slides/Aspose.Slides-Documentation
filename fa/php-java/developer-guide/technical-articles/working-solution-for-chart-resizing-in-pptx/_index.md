---
title: راه‌حل عملی برای تغییر اندازه نمودار در PPTX
type: docs
weight: 40
url: /fa/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغییر اندازه نمودار
- نمودار Excel
- شی OLE
- جاسازی نمودار
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "رفع تغییر اندازه غیرمنتظره نمودار در PPTX هنگام استفاده از اشیای OLE Excel جاسازی‌شده با Aspose.Slides برای PHP از طریق Java. تنظیم ابعاد ثابت نمودار برای حفظ یکسانی اندازه‌های نمودار و قاب OLE."
---
## **بررسی کلی**

نمودارهای Excel که به‌عنوان اشیای OLE در ارائه‌های PowerPoint با استفاده از اجزای Aspose جاسازی می‌شوند، پس از اولین فعال‌سازی ممکن است اندازه‌شان تغییر کند. این می‌تواند منجر به تفاوت مشهودی در ظاهر نمودار قبل و پس از فعال‌سازی شود. این مقاله دلیل رخ دادن تغییر اندازه را توضیح می‌دهد و نشان می‌دهد چگونه با هم‌تراز کردن ابعاد ثابت نمودار با قاب OLE از آن جلوگیری کنیم.

در [ایجاد نمودارهای Excel و جاسازی آن‌ها به‌عنوان اشیای OLE در ارائه‌ها](/slides/fa/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، ما نحوه‌ی ساخت یک نمودار Excel با Aspose.Cells برای PHP از طریق Java و جاسازی آن در یک ارائه PowerPoint با استفاده از Aspose.Slides برای PHP از طریق Java را شرح دادیم. برای رفع [مشکل پیش‌نمایش شی](/slides/fa/php-java/object-preview-issue-when-adding-oleobjectframe/)، تصویر نمودار را به قاب شی OLE نمودار اختصاص دادیم. در ارائه خروجی، هنگامی که بر روی قاب شی OLE که تصویر نمودار را نشان می‌دهد دوبار کلیک می‌کنید، نمودار Excel فعال می‌شود. کاربران می‌توانند کتاب‌کار Excel جاسازی‌شده را ویرایش کرده و سپس با کلیک خارج از کتاب‌کار فعال‌شده به اسلاید بازگردند. اندازه‌ی قاب شی OLE هنگام بازگشت کاربر به اسلاید تغییر می‌کند و ضریب تغییر اندازه بسته به اندازه‌های اصلی هر دو قاب شی OLE و کتاب‌کار Excel جاسازی‌شده متفاوت است.

## **علت تغییر اندازه**

کتاب‌کار Excel جاسازی‌شده دارای ابعاد پنجره خود است که Excel سعی می‌کند هنگام اولین فعال‌سازی شی، این ابعاد را حفظ کند. قاب OLE بر روی اسلاید ابعاد مستقلی دارد. زمانی که کتاب‌کار Excel فعال می‌شود، Excel و PowerPoint برای حفظ نسبت‌های ابعاد شی، اندازه‌ی آن را تنظیم می‌کنند. تفاوت بین پنجره کتاب‌کار و قاب OLE می‌تواند منجر به تغییر اندازه شی شود.

## **راه‌حل عملی**

اندازه‌ی نمودار را با قاب OLE بر روی اسلاید هم‌تراز کنید و ابعاد نمودار را مستقل از پنجره کتاب‌کار نگه دارید. این راه‌حل برای یک ارائهٔ جدید یا یک قالب موجود کار می‌کند.

مثال نیاز به Aspose.Cells برای PHP از طریق Java و Aspose.Slides برای PHP از طریق Java دارد. هر دو محصول را با همان نمونهٔ PHP/Java Bridge پیکربندی کنید، هر دو wrapper PHP را بارگذاری کنید و هر دو کتابخانهٔ Java را در دسترس bridge قرار دهید. نیازی به فایل‌های ورودی نیست. این مثال یک نمودار ستونی ساده بر روی یک شیت نمودار فعال ایجاد می‌کند و کتاب‌کار را در قالب XLS جاسازی می‌نماید. تصویر پیش‌نمایش نمودار تخصیص داده نمی‌شود؛ نمودار زمانی که شی OLE در PowerPoint فعال می‌شود قابل مشاهده می‌گردد.

مثال یک ارائهٔ جدید با قاب OLE به اندازهٔ 9.5 × 4 اینچ ایجاد می‌کند که 0.5 اینچ از لبهٔ چپ و 1 اینچ از بالای اسلاید قرار گرفته است. مختصات و ابعاد اسلاید بر پایهٔ نقطه (72 نقطه در هر اینچ) هستند. برای یک ارائهٔ موجود، به بخش [استفاده از قالب](#use-a-template) مراجعه کنید.

## **تنظیم اندازه ثابت نمودار**

[Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) را روی false تنظیم کنید تا ابعاد نمودار مستقل از پنجره کتاب‌کار باشد. ابعاد [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) را از طریق [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) و [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height) تنظیم کنید و نقطه‌ها را با استفاده از 96 پیکسل در هر اینچ به پیکسل تبدیل کنید: قاب اندازهٔ 684 × 288 نقطه معادل نموداری با اندازهٔ 912 × 384 پیکسل است. [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) را روی مقدار CUSTOM از [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/) تنظیم کنید. مثال کتاب‌کار را با استفاده از [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) جاسازی می‌کند و یک ارائه را با قاب OLE به اندازهٔ 9.5 × 4 اینچ ذخیره می‌نماید.

نتایج عددی Java قبل از استفاده به‌عنوان شاخص‌های PHP با `java_values` تبدیل می‌شوند. بایت‌های کتاب‌کار در یک آرایه بایت Java باقی می‌مانند تا به [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) پاس داده شوند.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // مختصات و ابعاد اسلاید بر حسب نقاط (۷۲ نقطه در هر اینچ) هستند.
        $width = 684; // 9.5 اینچ.
        $height = 288; // 4 اینچ.

        $chart->setSizeWithWindow(false);
        // نقاط را با استفاده از ۹۶ پیکسل در هر اینچ به پیکسل‌های نمودار تبدیل کنید.
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **استفاده از قالب**

منطق اندازه‌گذاری برای یک ارائهٔ موجود همانند ارائهٔ جدید است. برای تطبیق مثال:

1. به‌جای ایجاد یک ارائهٔ خالی، قالب ارائه را بارگذاری کنید.  
2. اطمینان حاصل کنید که اسلاید اول حداقل سه شکل دارد، سپس شکل با شاخص 2 را به‌عنوان متغیر نگه‌دار استفاده کنید.  
3. عرض و ارتفاع قاب را از آن شکل بگیرید به‌جای استفاده از مقادیر ثابت 684 و 288. محاسبات اندازه‌گذاری دست‌نخورده باقی می‌مانند.  
4. قاب OLE را در موقعیت متغیر نگه‌دار اضافه کنید به‌جای مختصات ثابت 36 و 72.  
5. پیش از ذخیرهٔ ارائه، متغیر نگه‌دار را حذف کنید.

## **سوالات متداول**

**چرا نمودار Excel جاسازی‌شده پس از فعال‌سازی در PowerPoint اندازه‌اش را تغییر می‌دهد؟**  
این به این دلیل است که Excel سعی می‌کند هنگام اولین فعال‌سازی، اندازهٔ اصلی پنجره را بازگرداند، در حالی که قاب شی OLE در PowerPoint ابعاد جداگانه‌ای دارد. PowerPoint و Excel برای حفظ نسبت ابعاد با یکدیگر مذاکره می‌کنند که می‌تواند منجر به تغییر اندازه شود.

**چگونه می‌توان ابعاد نمودار و قاب OLE را یکسان نگه داشت؟**  
ابعاد ثابت نمودار را طوری تنظیم کنید که با قاب OLE هم‌تراز باشد و قبل از جاسازی کتاب‌کار، یک اندازهٔ چاپ سفارشی برای نمودار تعیین کنید. مثال بالا تنظیمات مورد نیاز و تبدیل واحدها را نشان می‌دهد.

**آیا تنظیم اندازهٔ پنجره کتاب‌کار کافی است؟**  
تنظیم تنها اندازهٔ پنجره کتاب‌کار به‌طور قابل اعتماد از تغییر اندازهٔ قاب OLE پس از فعال‌سازی جلوگیری نمی‌کند. از ابعاد ثابت نمودار همان‌طور که در مثال نشان داده شده استفاده کنید.

**آیا این راه‌حل برای ارائه‌های مبتنی بر قالب و ارائه‌های جدید کار می‌کند؟**  
بله. برای یک قالب، از ابعاد و موقعیت متغیر نگه‌دار استفاده کنید. برای یک ارائهٔ جدید، مستقیماً ابعاد و موقعیت قاب را مشخص کنید.

**آیا می‌توانم این مثال را با نمودارهایی که در برنامه‌های صفحه‌گسترده دیگر ایجاد شده‌اند، استفاده کنم؟**  
این مثال از کتاب‌کار Excel ایجاد شده با Aspose.Cells استفاده می‌کند. رفتار فعال‌سازی برای برنامه‌های صفحه‌گسترده دیگر نشان داده نشده است.

## **بخش‌های مرتبط**

- [ایجاد نمودارهای Excel و جاسازی آن‌ها به‌عنوان اشیای OLE در ارائه‌ها](/slides/fa/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)