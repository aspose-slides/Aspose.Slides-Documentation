---
title: یکپارچه‌سازی داده‌های اکسل در ارائه‌های PowerPoint
linktitle: یکپارچه‌سازی اکسل
type: docs
weight: 330
url: /fa/java/excel-integration/
keywords:
- اکسل
- کتاب‌کار
- خواندن اکسل
- یکپارچه‌سازی اکسل
- منبع داده
- ادغام نامه
- وارد کردن جدول
- اکسل به PowerPoint
- PowerPoint
- ارائه
- جاوا
- Aspose.Slides
description: "داده‌ها را از کتاب‌کارهای اکسل در Aspose.Slides با استفاده از API ExcelDataWorkbook بخوانید. برگه‌ها و سلول‌ها را بارگذاری کنید و از مقادیر برای ایجاد ارائه‌های PowerPoint مبتنی بر داده استفاده کنید."
---
## **معرفی**

ارائه‌های PowerPoint روشی قدرتمند برای نمایش و انتقال اطلاعات هستند. اغلب همراه با کتاب‌کارهای Excel استفاده می‌شوند، که در آن Excel منبع ساختارمند داده‌هاست و PowerPoint برای تجسم آن داده‌ها برای مخاطب برتری دارد.

سناریوهای عملی متعددی وجود دارد که ترکیب Excel و PowerPoint در آن‌ها ضروری است: ادغام نامه‌ها، پر کردن جداول داده، تولید یک اسلاید برای هر رکورد داده (تولید دسته‌ای اسلاید)، تهیه مواد آموزشی و تجمیع چندین گزارش Excel در یک ارائه، تنها به چند مثال اشاره شد.

تا کنون، پیاده‌سازی چنین ویژگی‌هایی با API Aspose.Slides نیاز به تکیه بر راه‌حل‌های شخص ثالث مانند Aspose.Cells داشت. اگرچه این ابزارها قدرتمند هستند، اما برای کاربرانی که فقط به عملکرد پایه یکپارچه‌سازی داده نیاز دارند، ممکن است بیش از حد پیچیده و گران‌قیمت باشند.

## **نحوه کار**

برای ساده‌سازی کار با داده‌های Excel و بهبود جریان کار، Aspose.Slides کلاس‌های جدیدی برای خواندن داده‌ها از کتاب‌کارهای Excel و وارد کردن محتوا به یک ارائه معرفی کرده است. این ویژگی امکانات جدید و قدرتمندی را برای کاربران API فراهم می‌کند که می‌خواهند Excel را به عنوان منبع داده در جریان کارهای ارائه خود به‌کار ببرند.

عملکرد جدید برای دسترسی عمومی به داده‌ها طراحی شده و در مدل شیء سند ارائه (DOM) ادغام نشده است. به عبارت دیگر *اجازه ویرایش یا ذخیره فایل‌های Excel را نمی‌دهد* — هدف تنها باز کردن کتاب‌کارها و مرور محتوا برای استخراج داده‌های سلول است.

هسته این ویژگی، کلاس جدید [ExcelDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/exceldataworkbook/) است. این کلاس امکان بارگذاری یک کتاب‌کار Excel از فایل محلی یا جریان را فراهم می‌کند. پس از بارگذاری، چندین overload از متد [getCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) در اختیار شماست تا سلول‌های خاص را بر اساس موقعیت (مثلاً اندیس ردیف و ستون یا محدوده‌های نامگذاری‌شده) بازیابی کنید.

هر فراخوانی به [getCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) یک نمونه از کلاس [ExcelDataCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/exceldatacell/) را برمی‌گرداند. این شیء نمایانگر یک سلول واحد در کتاب‌کار Excel است و به شما دسترسی ساده و شهودی به مقدار آن ارائه می‌دهد.

#### **وارد کردن نمودار Excel**

گام بعدی برای گسترش عملکرد، کلاس [ExcelWorkbookImporter](https://reference.aspose.com/slides/fa/java/com.aspose.slides/excelworkbookimporter/) است. این کلاس کمکی عملکردی برای وارد کردن محتوا از یک کتاب‌کار Excel به ارائه فراهم می‌کند. چندین overload از متد [addChartFromWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) دارد که به شما کمک می‌کند نمودار انتخاب‌شده را از کتاب‌کار Excel مشخص بازیابی کرده و در انتهای مجموعهٔ اشکال داده‌شده، در مختصات تعیین‌شده اضافه کنید.

به‌طور مختصر، این یک API سبک و سرراست برای خواندن داده‌های Excel است — دقیقا همان چیزی که بسیاری از توسعه‌دهندگان بدون بار اضافی یک کتابخانهٔ کامل پردازش صفحه‌گسترده نیاز دارند.

## **بیایید کدنویسی کنیم**

### **مثال سناریوی ادغام نامه**

در مثال زیر، سناریوی سادهٔ Mail Merge را با تولید چندین ارائه بر پایه داده‌های ذخیره‌شده در یک کتاب‌کار Excel پیاده‌سازی می‌کنیم.

برای شروع به دو مورد نیاز داریم:
1. یک کتاب‌کار Excel حاوی داده‌ها

![مثال داده‌های Excel](example1_image0.png)

2. قالب ارائه PowerPoint

![مثال قالب PowerPoint](example1_image1.png)

```java
// کتاب‌کار Excel حاوی داده‌های کارمندان را بارگذاری کنید.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// قالب ارائه را بارگذاری کنید.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // مرور ردیف‌های Excel (به‌جز سرصفحه در ردیف 0).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // ایجاد یک ارائه جدید برای هر رکورد کارمند.
        Presentation employeePresentation = new Presentation();

        try {
            // حذف اسلاید خالی پیش‌فرض.
            employeePresentation.getSlides().removeAt(0);

            // کپی اسلاید قالب به ارائه جدید.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // دریافت پاراگراف‌ها از شکل هدف (فرض می‌شود ایندکس شکل 1 استفاده شود).
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // جایگزینی متغیرهای جایگزین با داده‌های Excel.
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // ذخیره ارائه شخصی‌سازی‌شده در یک فایل جداگانه.
            employeePresentation.save(String.format("%s Report.pptx", employeeName), SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![نتیجه](example1_image2.png)

### **مثال جدول Excel**

در مثال دوم، به سادگی داده‌ها را از یک جدول Excel کپی می‌کنیم و آنها را در یک اسلاید PowerPoint به شکل بصری‌تری نمایش می‌دهیم.

در این مثال، همان کتاب‌کار Excel مورد استفاده در مثال اول را دوباره به کار می‌بریم که شامل یک جدول سادهٔ کارمندان است.

```java
// کتاب‌کار Excel حاوی داده‌های کارمندان را بارگذاری کنید.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// یک ارائه PowerPoint جدید ایجاد کنید.
Presentation presentation = new Presentation();

try {
    // یک شکل جدول به اسلاید اول اضافه کنید.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // جدول PowerPoint را با داده‌های کتاب‌کار Excel پر کنید.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // ارائهٔ حاصل را در یک فایل ذخیره کنید.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![نتیجه](example2_image0.png)

### **مثال وارد کردن نمودار Excel**

در این مثال، یک نمودار را از ورق اول کتاب‌کار Excel مورد استفاده در مثال قبلی وارد می‌کنیم. نمودار در ارائهٔ نهایی به کتاب‌کار خارجی لینک می‌شود.

اول، یک نمودار دایره‌ای (Pie) بر اساس جدول کارمندان به کتاب‌کار Excel اضافه می‌کنیم.

![مثال نمودار Excel](example3_image0.png)

```java
// یک ارائه PowerPoint جدید ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // مجموعهٔ اشکال اسلاید اول را دریافت کنید.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // نمودار با نام "Chart 1" را از اولین ورق کتاب‌کار وارد کنید و به مجموعهٔ اشکال اضافه کنید.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // ارائهٔ حاصل را در یک فایل ذخیره کنید.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![نتیجه](example3_image1.png)

### **مثال وارد کردن تمام نمودارهای Excel**

فرض کنید یک کتاب‌کار Excel پر از نمودارها دارید و می‌خواهید همهٔ آنها را به یک ارائه وارد کنید. هر نمودار باید در اسلاید جدیدی قرار گیرد.

کد زیر تمام ورق‌های موجود در فایل Excel منبع را می‌چرخاند، نمودارها را از هر ورق استخراج می‌کند و هر نمودار را با استفاده از یک طرح‌بندی اسلاید خالی به اسلاید جداگانه‌ای اضافه می‌کند. در ارائهٔ نهایی، تنها داده‌های نمودار جاسازی می‌شود، نه کل کتاب‌کار.

```java
// کتاب‌کار Excel حاوی داده‌های کارمندان را بارگذاری کنید.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// یک ارائه PowerPoint جدید ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // طرح اسلاید خالی را دریافت کنید.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // نام تمام ورق‌های موجود در کتاب‌کار Excel را بدست آورید.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // نقشه‌ای که شاخص‌های نمودار را به نام‌های نمودار برای ورق مرتبط می‌کند، دریافت کنید.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // اسلاید جدیدی با استفاده از طرح خالی اضافه کنید.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // نمودار مشخص‌شده را از کتاب‌کار Excel به مجموعهٔ اشکال اسلاید وارد کنید.
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // ارائهٔ حاصل را در یک فایل ذخیره کنید.
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **خلاصه**

این مکانیزم که به‌صورت مستقیم در Aspose.Slides در دسترس است، کار با داده‌های Excel و ارائه‌ها را در یک مکان ترکیب می‌کند. به شما امکان می‌دهد اسلایدهای حاوی نمودارهای بصری و داده‌های ارائه‌شده به شکل جداول Excel ایجاد کنید — بدون نیاز به کتابخانه‌های اضافی یا ادغام‌های پیچیده.