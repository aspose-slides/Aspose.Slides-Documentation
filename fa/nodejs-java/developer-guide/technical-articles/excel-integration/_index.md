---
title: یکپارچه‌سازی داده‌های اکسل در ارائه‌های پاورپوینت
linktitle: یکپارچه‌سازی اکسل
type: docs
weight: 330
url: /fa/nodejs-java/excel-integration/
keywords:
- اکسل
- کاربرگ
- خواندن اکسل
- یکپارچه‌سازی اکسل
- منبع داده
- ادغام نامه
- واردکردن جدول
- اکسل به پاورپوینت
- پاورپوینت
- ارائه
- نود.جی‌اس
- جاوااسکریپت
- Aspose.Slides
description: "داده‌ها را از کتاب‌های کار اکسل در جاوااسکریپت با Aspose.Slides بخوانید. شیت‌ها و سلول‌ها را بارگذاری کنید و از مقادیر آن برای تولید ارائه‌های پاورپوینت مبتنی بر داده استفاده کنید."
---
## **مقدمه**

ارائه‌های پاورپوینت راهی قدرتمند برای نمایش و انتقال اطلاعات هستند. آن‌ها اغلب همراه با کتاب‌های کار اکسل استفاده می‌شوند، جایی که اکسل به عنوان منبع عالی داده‌های ساختار یافته عمل می‌کند و پاورپوینت در تصویرسازی آن داده‌ها برای مخاطبان برتری دارد.

سناریوهای عملی بسیاری وجود دارد که ترکیب اکسل و پاورپوینت در آن‌ها ضروری است: ادغام نامه‌ها، پر کردن جداول داده، ایجاد یک اسلاید برای هر رکورد داده (تولید دسته‌ای اسلاید)، ساخت مواد آموزشی، و تجمیع چندین گزارش اکسل در یک ارائه، به عنوان مثال.

تا کنون، پیاده‌سازی چنین ویژگی‌هایی با API Aspose.Slides نیاز به استفاده از راه‌حل‌های شخص ثالث مانند Aspose.Cells داشت. در حالی که این ابزارها قوی هستند، برای کاربرانی که تنها به عملکرد پایه یکپارچه‌سازی داده‌ها نیاز دارند ممکن است بیش از حد پیچیده و پر هزینه باشند.

## **چگونه کار می‌کند**

برای ساده‌تر و کارآمدتر کردن کار با داده‌های اکسل، Aspose.Slides کلاس‌های جدیدی برای خواندن داده‌ها از کتاب‌های کار اکسل و وارد کردن محتوا به یک ارائه معرفی کرده است. این ویژگی امکان‌های قدرتمند جدیدی را برای کاربران API که می‌خواهند از اکسل به عنوان منبع داده در جریان کار ارائه‌های خود استفاده کنند، فراهم می‌کند.

عملکرد جدید برای دسترسی عمومی به داده‌ها طراحی شده است و در مدل شیء سند ارائه (DOM) یکپارچه نشده است. این به این معناست که *امکان ویرایش یا ذخیره فایل‌های اکسل را نمی‌دهد* — هدف اصلی آن فقط باز کردن کتاب‌های کار و مرور محتوای آن‌ها برای بازیابی دادهٔ سلول‌ها است.

در هستهٔ این ویژگی کلاس جدید [ExcelDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/exceldataworkbook/) قرار دارد. این کلاس به شما امکان می‌دهد یک کتاب کار اکسل را از یک فایل محلی یا یک جریان بارگذاری کنید. پس از بارگذاری، چندین overload از متد [getCell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/exceldataworkbook/#getCell) را فراهم می‌کند که می‌توانید برای بازیابی سلول‌های خاص بر اساس موقعیت آن‌ها (مثلاً اندیس‌های ردیف و ستون یا بازه‌های نام‌گذاری شده) استفاده کنید.

هر فراخوانی به [getCell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/exceldataworkbook/#getCell) یک نمونه از کلاس [ExcelDataCell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/exceldatacell/) را برمی‌گرداند. این شیء یک سلول واحد در کتاب کار اکسل را نشان می‌دهد و به شما دسترسی ساده و شهودی به مقدار آن سلول می‌دهد.

#### **وارد کردن یک نمودار اکسل**

گام بعدی برای گسترش قابلیت، کلاس [ExcelWorkbookImporter](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/excelworkbookimporter/) است. این کلاس کمکی عملکردی برای وارد کردن محتوا از یک کتاب کار اکسل به یک ارائه فراهم می‌کند. این کلاس شامل چندین overload از متد [addChartFromWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) است که به شما کمک می‌کند نمودار انتخاب‌شده را از کتاب کار اکسل مشخص شده استخراج کرده و به انتهای مجموعهٔ اشکال داده‌شده در مختصات تعیین‌شده اضافه کنید.

به طور خلاصه، این یک API سبک و ساده برای خواندن داده‌های اکسل است — دقیقاً همان چیزی که بسیاری از توسعه‌دهندگان بدون بار اضافی یک کتابخانهٔ کامل پردازش جدول‌محور نیاز دارند.

## **بیایید کدنویسی کنیم**

### **مثال سناریوی ادغام نامه**

در مثال زیر، یک سناریوی سادهٔ ادغام نامه را با تولید چندین ارائه بر پایه داده‌های ذخیره‌شده در یک کتاب کار اکسل پیاده‌سازی می‌کنیم.

برای شروع، به دو مورد نیاز داریم:
1. یک کتاب کار اکسل حاوی داده‌ها

![مثال داده‌های اکسل](example1_image0.png)

2. قالب ارائهٔ پاورپوینت

![مثال قالب پاورپوینت](example1_image1.png)

```js
// بارگذاری کتاب کار اکسل با داده‌های کارمند.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// بارگذاری قالب ارائه.
let templatePresentation = new aspose.slides.Presentation("PresentationTemplate.pptx");

try {
    // پیمایش ردیف‌های اکسل (به‌جز سرصفحه در ردیف ۰).
    for (let rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // ایجاد یک ارائه جدید برای هر رکورد کارمند.
        let employeePresentation = new aspose.slides.Presentation();

        try {
            // حذف اسلاید خالی پیش‌فرض.
            employeePresentation.getSlides().removeAt(0);

            // تکثیر اسلاید قالب به ارائه جدید.
            let slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // دریافت پاراگراف‌ها از شکل هدف (فرض می‌شود ایندکس شکل ۱ استفاده شده است).
            let paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs();

            // جایگزینی متغیرهای جایگزین با داده‌های اکسل.
            let employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            let namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            let department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            let departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            let yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            let yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // ذخیرهٔ ارائه شخصی‌سازی شده در یک فایل جداگانه.
            employeePresentation.save(`${employeeName} Report.pptx`, aspose.slides.SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![نتیجه](example1_image2.png)

### **مثال جدول اکسل**

در مثال دوم، به سادگی داده‌ها را از یک جدول اکسل کپی می‌کنیم و آن را به شکل بصری جذاب‌تری در یک اسلاید پاورپوینت نمایش می‌دهیم.

در این مثال، همان کتاب کار اکسل را که در مثال اول استفاده شد، باز می‌گیریم؛ این کتاب کار شامل یک جدول سادهٔ کارمندان است.

```js
// بارگذاری کتاب کار اکسل حاوی داده‌های کارمند.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// ایجاد یک ارائهٔ پاورپوینت جدید.
let presentation = new aspose.slides.Presentation();

try {
    // افزودن یک شکل جدول به اسلاید اول.
    let table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            java.newArray("double", [200, 200, 200]),
            java.newArray("double", [30, 30, 30, 30, 30])
    );

    // پر کردن جدول پاورپوینت با داده‌های کتاب کار اکسل.
    for (let rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (let columnIndex = 0; columnIndex < 3; columnIndex++) {
            let cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // ذخیرهٔ ارائهٔ حاصل در یک فایل.
    presentation.save("Table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![نتیجه](example2_image0.png)

### **مثال وارد کردن یک نمودار اکسل**

در این مثال، یک نمودار را از اولین برگهٔ کتاب کار اکسل استفاده‌شده در مثال قبلی وارد می‌کنیم. نمودار در ارائهٔ حاصل به کتاب کار خارجی لینک خواهد شد.

ابتدا، یک نمودار دایره‌ای (Pie chart) به کتاب کار اکسل بر پایه جدول کارمندان اضافه می‌کنیم.

![مثال نمودار اکسل](example3_image0.png)

```js
// ایجاد یک ارائهٔ پاورپوینت جدید.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت مجموعهٔ اشکال اسلاید اول.
    let shapes = presentation.getSlides().get_Item(0).getShapes();

    // وارد کردن نمودار با نام "Chart 1" از شیت اول کتاب کار و افزودن آن به مجموعهٔ اشکال.
    aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // ذخیرهٔ ارائهٔ حاصل در یک فایل.
    presentation.save("Chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![نتیجه](example3_image1.png)

### **مثال وارد کردن تمام نمودارهای اکسل**

تصور کنیم یک کتاب کار اکسل پر از نمودارها دارید و می‌خواهید همهٔ آن‌ها را به یک ارائه وارد کنید. هر نمودار باید در یک اسلاید جدید قرار گیرد.

کد زیر تمام برگه‌های فایل اکسل منبع را مرور می‌کند، نمودارها را از هر برگه استخراج می‌نماید و هر نمودار را به یک اسلاید جداگانه با استفاده از طرح اسلاید خالی اضافه می‌کند. در ارائهٔ حاصل، تنها دادهٔ نمودارها تعبیه می‌شود و کل کتاب کار نه.

```js
// بارگذاری کتاب کار اکسل حاوی داده‌های کارمند.
let workbook = new aspose.slides.ExcelDataWorkbook("ExcelWithCharts.xlsx");

// ایجاد یک ارائهٔ پاورپوینت جدید.
let presentation = new aspose.slides.Presentation();
try {
    // دریافت طرح اسلاید خالی.
    let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

    // دریافت نام تمام شیت‌های موجود در کتاب کار اکسل.
    let worksheetNames = workbook.getWorksheetNames().iterator();

    while (worksheetNames.hasNext()) {
        let name = worksheetNames.next();
        // دریافت نقشه‌ای که ایندکس‌های نمودار را به نام‌های آن‌ها برای شیت مرتبط می‌کند.
        let worksheetCharts = workbook.getChartsFromWorksheet(name).iterator();

        while (worksheetCharts.hasNext()) {
            let chart = worksheetCharts.next();
            // افزودن اسلاید جدید با استفاده از طرح خالی.
            let slide = presentation.getSlides().addEmptySlide(layoutSlide);

            // وارد کردن نمودار مشخص‌شده از کتاب کار اکسل به مجموعهٔ اشکال اسلاید.
            aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // ذخیرهٔ ارائهٔ حاصل در یک فایل.
    presentation.save("Charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **خلاصه**

این مکانیزم که به‌صورت مستقیم در Aspose.Slides در دسترس است، کار با داده‌های اکسل و ارائه‌ها را در یک مکان ترکیب می‌کند. این امکان را می‌دهد که اسلایدهایی با نمودارهای بصری و داده‌های ارائه‌شده به صورت جداول اکسل بسازید — بدون نیاز به کتابخانه‌های اضافی یا ادغام‌های پیچیده.