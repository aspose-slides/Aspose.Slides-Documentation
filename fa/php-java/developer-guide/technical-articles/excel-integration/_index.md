---
title: یکپارچه‌سازی داده‌های Excel در ارائه‌های PowerPoint
linktitle: یکپارچه‌سازی Excel
type: docs
weight: 330
url: /fa/php-java/excel-integration/
keywords:
- Excel
- دفتر کار
- خواندن Excel
- یکپارچه‌سازی Excel
- منبع داده
- ادغام ایمیل
- وارد کردن جدول
- Excel به PowerPoint
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "داده‌ها را از کتاب‌کارهای Excel با استفاده از Aspose.Slides برای PHP از طریق Java بخوانید. برگه‌ها و سلول‌ها را بارگذاری کنید و از مقادیر آن‌ها برای تولید ارائه‌های PowerPoint مبتنی بر داده استفاده کنید."
---
## **معرفی**

ارائه‌های PowerPoint روشی قدرتمند برای نمایش و انتقال اطلاعات هستند. این ارائه‌ها اغلب همراه با کتاب‌کارهای Excel استفاده می‌شوند، جایی که Excel منبع عالی داده‌های ساختاریافته است و PowerPoint در تجسم آن داده‌ها برای مخاطب برتری دارد.

سناریوهای عملی بسیاری وجود دارد که ترکیب Excel و PowerPoint در آن‌ها ضروری است: ترکیب ایمیل، پر کردن جداول داده، تولید یک اسلاید برای هر رکورد داده (تولید دسته‌ای اسلاید)، ایجاد مواد آموزشی، و ترکیب چندین گزارش Excel در یک ارائه، و غیره.

تا به حال، پیاده‌سازی چنین ویژگی‌هایی با Aspose.Slides API نیاز به اتکا به راه‌حل‌های شخص ثالثی مانند Aspose.Cells داشت. در حالی که این ابزارها قدرتمند هستند، می‌توانند برای کاربرانی که فقط به عملکرد پایه‌ای ادغام داده نیاز دارند، بیش از حد پیچیده و پرهزینه باشند.

## **نحوه کار**

برای ساده‌تر و روان‌تر کردن کار با داده‌های Excel، Aspose.Slides کلاس‌های جدیدی برای خواندن داده‌ها از کتاب‌کارهای Excel و وارد کردن محتوا به یک ارائه معرفی کرده است. این ویژگی امکانات جدیدی قدرتمند برای کاربران API که می‌خواهند Excel را به عنوان منبع داده در جریان کار ارائه خود به‌کار ببرند، فراهم می‌کند.

عملکرد جدید برای دسترسی عمومی به داده‌ها طراحی شده و در مدل شیء سند ارائه (DOM) ادغام نشده است. به این معناست که *امکان ویرایش یا ذخیره فایل‌های Excel را ندارد* — هدف صرفاً باز کردن کتاب‌کارها و مرور محتوا برای استخراج داده‌های سلول است.

هسته این قابلیت، کلاس جدید [ExcelDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/exceldataworkbook/) است. این کلاس به شما اجازه می‌دهد یک کتاب‌کار Excel را از فایل محلی یا یک جریان بارگذاری کنید. پس از بارگذاری، چندین overload از متد [getCell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/exceldataworkbook/#getCell) در اختیار شماست که می‌توانید برای دریافت سلول‌های خاص بر اساس موقعیتشان (مثلاً ایندکس ردیف و ستون یا محدوده‌های نامگذاری‌شده) استفاده کنید.

هر فراخوانی به [getCell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/exceldataworkbook/#getCell) یک نمونه از کلاس [ExcelDataCell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/exceldatacell/) را برمی‌گرداند. این شیء یک سلول منفرد در کتاب‌کار Excel را نشان می‌دهد و دسترسی ساده و شهودی به مقدار آن فراهم می‌کند.

#### **وارد کردن یک نمودار Excel**

گام بعدی برای گسترش قابلیت، کلاس [ExcelWorkbookImporter](https://reference.aspose.com/slides/fa/php-java/aspose.slides/excelworkbookimporter/) است. این کلاس ابزاری برای وارد کردن محتوا از یک کتاب‌کار Excel به یک ارائه فراهم می‌کند. این کلاس چند overload از متد [addChartFromWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) دارد که به شما کمک می‌کند نمودار منتخب را از کتاب‌کار Excel مشخص‌شده استخراج کرده و در انتهای مجموعه شکل‌های داده‌شده در مختصات مشخص شده قرار دهید.

به‌طور خلاصه، این یک API سبک و سرراست برای خواندن داده‌های Excel است — دقیقاً همان چیزی که بسیاری از توسعه‌دهندگان بدون بار اضافی یک کتابخانه‌ی کامل پردازش صفحات گسترده نیاز دارند.

## **بیایید کد بزنیم**

### **مثال سناریوی Mail Merge**

در مثال زیر، یک سناریوی ساده Mail Merge را پیاده‌سازی می‌کنیم که چندین ارائه بر پایه داده‌های ذخیره‌شده در یک کتاب‌کار Excel تولید می‌کند.

برای شروع، دو مورد نیاز داریم:
1. یک کتاب‌کار Excel حاوی داده‌ها

![مثال داده‌های Excel](example1_image0.png)

2. قالب ارائه PowerPoint

![مثال قالب PowerPoint](example1_image1.png)

```php
// بارگذاری کتاب‌کار Excel با داده‌های کارمند.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// بارگذاری قالب ارائه.
$templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // پیمایش ردیف‌های Excel (به‌جز سرصفحه در ردیف 0).
    for ($rowIndex = 1; $rowIndex <= 4; $rowIndex++) {

        // ایجاد یک ارائه جدید برای هر رکورد کارمند.
        $employeePresentation = new Presentation();

        try {
            // حذف اسلاید خالی پیش‌فرض.
            $employeePresentation->getSlides()->removeAt(0);

            // کپی اسلاید قالب به ارائه جدید.
            $slide = $employeePresentation->getSlides()->addClone($templatePresentation->getSlides()->get_Item(0));

            // دریافت پاراگراف‌ها از شکل هدف (فرض می‌شود ایندکس شکل 1 استفاده شود).
            $paragraphs = $slide->getShapes()->get_Item(1)->getTextFrame()->getParagraphs();

            // جایگزینی نگهدارنده‌ها با داده‌های Excel.
            $employeeName = $workbook->getCell($worksheetIndex, $rowIndex, 0)->getValue()->toString();
            $namePortion = $paragraphs->get_Item(0)->getPortions()->get_Item(0);
            $namePortion->setText($namePortion->getText()->replace("{{EmployeeName}}", $employeeName));

            $department = $workbook->getCell($worksheetIndex, $rowIndex, 1)->getValue()->toString();
            $departmentPortion = $paragraphs->get_Item(1)->getPortions()->get_Item(0);
            $departmentPortion->setText($departmentPortion->getText()->replace("{{Department}}", $department));

            $yearsOfService = $workbook->getCell($worksheetIndex, $rowIndex, 2)->getValue()->toString();
            $yearsPortion = $paragraphs->get_Item(2)->getPortions()->get_Item(0);
            $yearsPortion->setText($yearsPortion->getText()->replace("{{YearsOfService}}", $yearsOfService));

            // ذخیره ارائه شخصی‌سازی‌شده در یک فایل جداگانه.
            $employeePresentation->save(sprintf("%s Report.pptx", $employeeName), SaveFormat::Pptx);
        } finally {
            $employeePresentation->dispose();
        }
    }
} finally {
    $templatePresentation->dispose();
}
```

![نتیجه](example1_image2.png)

### **مثال جدول Excel**

در مثال دوم، به سادگی داده‌ها را از یک جدول Excel کپی می‌کنیم و آن را روی یک اسلاید PowerPoint به شکلی جذاب‌تر نمایش می‌دهیم.

در این مثال، همان کتاب‌کار Excel استفاده‌شده در مثال اول را که شامل یک جدول ساده کارکنان است، دوباره به کار می‌بریم.

```php
// بارگذاری کتاب‌کار Excel حاوی داده‌های کارمند.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// ایجاد یک ارائه PowerPoint جدید.
$presentation = new Presentation();

try {
    // افزودن یک شکل جدول به اسلاید اول.
    $table = $presentation->getSlides()->get_Item(0)->getShapes()->addTable(
            50, 200,
            array(200, 200, 200),
            array(30, 30, 30, 30, 30)
    );

    // پر کردن جدول PowerPoint با داده‌های کتاب‌کار Excel.
    for ($rowIndex = 0; $rowIndex < 5; $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < 3; $columnIndex++) {
            $cellValue = $workbook->getCell($worksheetIndex, $rowIndex, $columnIndex)->getValue()->toString();
            $table->getColumns()->get_Item($columnIndex)->get_Item($rowIndex)->getTextFrame()->setText($cellValue);
        }
    }

    // ذخیره ارائه حاصل در یک فایل.
    $presentation->save("Table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![نتیجه](example2_image0.png)

### **مثال وارد کردن یک نمودار Excel**

در این مثال، یک نمودار را از برگه اول کتاب‌کار Excel که در مثال قبلی استفاده شد وارد می‌کنیم. این نمودار در ارائهٔ نهایی به کتاب‌کار خارجی لینک خواهد شد.

ابتدا یک نمودار دایره‌ای (Pie) بر مبنای جدول کارکنان به کتاب‌کار Excel اضافه می‌کنیم.

![مثال نمودار Excel](example3_image0.png)

```php
// یک ارائه PowerPoint جدید ایجاد کنید.
$presentation = new Presentation();
try {
    // مجموعهٔ اشکال اسلاید اول را دریافت کنید.
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    // نمودار با نام "Chart 1" را از اولین برگهٔ کتاب‌کار وارد کرده و به مجموعهٔ اشکال اضافه کنید.
    ExcelWorkbookImporter::addChartFromWorkbook($shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // ارائهٔ حاصل را در یک فایل ذخیره کنید.
    $presentation->save("Chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![نتیجه](example3_image1.png)

### **مثال وارد کردن تمام نمودارهای Excel**

تصور کنید یک کتاب‌کار Excel پر از نمودار دارید و نیاز دارید همهٔ آن‌ها را به یک ارائه وارد کنید. هر نمودار باید در یک اسلاید جدید قرار گیرد.

کد زیر تمام برگه‌های فایل Excel منبع را پیمایش می‌کند، نمودارها را از هر برگه استخراج می‌کند و هر نمودار را با استفاده از یک طرح اسلاید خالی به اسلاید جداگانه‌ای اضافه می‌کند. در ارائهٔ نهایی، تنها داده‌های نمودار جاسازی می‌شوند، نه کل کتاب‌کار.

```php
// بارگذاری کتاب‌کار Excel حاوی داده‌های کارمند.
$workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// یک ارائه PowerPoint جدید ایجاد کنید.
$presentation = new Presentation();
try {
    // چیدمان اسلاید خالی را بازیابی کنید.
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // نام همهٔ ورق‌های کاری موجود در کتاب‌کار Excel را دریافت کنید.
    $worksheetNames = $workbook->getWorksheetNames()->iterator();

    while (java_values($worksheetNames->hasNext())) {
        $name = $worksheetNames->next();
        // نقشه‌ای که ایندکس‌های نمودار را به نام‌های نمودار برای ورق کاری مرتبط می‌کند، دریافت کنید.
        $worksheetCharts = $workbook->getChartsFromWorksheet($name)->iterator();

        while (java_values($worksheetCharts->hasNext())) {
            $chart = $worksheetCharts->next();
            // یک اسلاید جدید با استفاده از چیدمان خالی اضافه کنید.
            $slide = $presentation->getSlides()->addEmptySlide($blankLayout);

            // نمودار مشخص‌شده را از کتاب‌کار Excel به مجموعهٔ اشکال اسلاید وارد کنید.
            ExcelWorkbookImporter::addChartFromWorkbook(
                    $slide->getShapes(), 10, 10, $workbook, $name, $chart->getKey(), false);
        }
    }

    // ارائهٔ حاصل را در یک فایل ذخیره کنید.
    $presentation->save("Charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **خلاصه**

این مکانیزم که مستقیماً در Aspose.Slides در دسترس است، کار با داده‌های Excel و ارائه‌ها را در یک مکان ترکیب می‌کند. این امکان را به شما می‌دهد تا اسلایدهایی با نمودارهای بصری و داده‌های ارائه‌شده به‌صورت جداول Excel ایجاد کنید — بدون نیاز به کتابخانه‌های اضافی یا یکپارچه‌سازی‌های پیچیده.