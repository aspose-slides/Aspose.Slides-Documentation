---
title: ادغام داده‌های اکسل در ارائه‌های پاورپوینت
linktitle: یکپارچه‌سازی اکسل
type: docs
weight: 330
url: /fa/androidjava/excel-integration/
keywords:
- اکسل
- دفتر کار
- خواندن اکسل
- یکپارچه‌سازی اکسل
- منبع داده
- ادغام نامه
- واردکردن جدول
- اکسل به پاورپوینت
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "داده‌ها را از دفترهای کار اکسل در Aspose.Slides با استفاده از API ExcelDataWorkbook بخوانید. شیت‌ها و سلول‌ها را بارگذاری کنید و از مقادیر برای تولید ارائه‌های پاورپوینت مبتنی بر داده استفاده نمایید."
---
## **مقدمه**

پرزنتیشن‌های PowerPoint راهی قدرتمند برای نمایش و انتقال اطلاعات هستند. آن‌ها اغلب همراه با کتاب‌کارهای Excel استفاده می‌شوند، جایی که Excel منبعی عالی برای داده‌های ساختاریافته فراهم می‌کند و PowerPoint برای نمایش بصری این داده‌ها به مخاطب برتر است.

سناریوهای عملی متعددی وجود دارد که ترکیب Excel و PowerPoint در آن‌ها ضروری است: ادغام نامه‌ها، پر کردن جدول‌های داده، تولید یک اسلاید برای هر رکورد داده (تولید اسلایدهای دسته‌ای)، ایجاد مطالب آموزشی، و تجمیع چندین گزارش Excel در یک ارائه، تنها به چند مورد اشاره شد.

تا کنون، پیاده‌سازی چنین ویژگی‌هایی با API Aspose.Slides نیاز به تکیه بر راه‌حل‌های شخص ثالث مانند Aspose.Cells داشت. اگرچه این ابزارها قدرتمند هستند، برای کاربرانی که فقط به کارکردهای پایه یکپارچه‌سازی داده نیاز دارند، می‌توانند بیش از حد پیچیده و پرهزینه باشند.

## **نحوه کارکرد**

برای آسان‌تر و یکنواخت‌تر کردن کار با داده‌های Excel، Aspose.Slides کلاس‌های جدیدی برای خواندن داده‌ها از کتاب‌کارهای Excel و وارد کردن محتوا به یک ارائه معرفی کرده است. این ویژگی امکانات جدید قدرتمندی را برای کاربران API که می‌خواهند از Excel به عنوان منبع داده در جریان کارهای ارائه خود استفاده کنند، فراهم می‌کند.

این کارکرد جدید برای دسترسی عمومی به داده‌ها طراحی شده و در مدل شی‌ء سند ارائه (DOM) ادغام نشده است. یعنی *این امکان ویرایش یا ذخیره فایل‌های Excel را نمی‌دهد* — هدف تنها باز کردن کتاب‌کارها و مرور محتوای آن‌ها برای بازیابی داده‌های سلول است.

در قلب این ویژگی، کلاس جدید [ExcelDataWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/exceldataworkbook/) قرار دارد. این کلاس به شما اجازه می‌دهد تا یک کتاب‌کار Excel را از فایل محلی یا یک جریان بارگذاری کنید. پس از بارگذاری، چندین overload از متد [getCell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) را ارائه می‌کند که می‌توانید برای بازیابی سلول‌های خاص با موقعیت آن‌ها (مثلاً شاخص ردیف و ستون یا محدوده‌های نام‌گذاری‌شده) استفاده کنید.

هر فراخوانی از [getCell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) یک نمونه از کلاس [ExcelDataCell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/exceldatacell/) برمی‌گرداند. این شیء نمایانگر یک سلول منفرد در کتاب‌کار Excel است و دسترسی ساده و بصری به مقدار آن را فراهم می‌کند.

#### **وارد کردن یک نمودار اکسل**

گام بعدی برای گسترش کارکرد، کلاس [ExcelWorkbookImporter](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/excelworkbookimporter/) است. این کلاس ابزاری است که امکان وارد کردن محتوا از یک کتاب‌کار Excel به یک ارائه را می‌دهد. این کلاس چند overload از متد [addChartFromWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) دارد که به شما کمک می‌کند نمودار انتخاب‌شده را از کتاب‌کار Excel مشخص‌شده بازیابی کنید و در انتهای مجموعه شکل‌های داده شده در مختصات تعیین‌شده اضافه کنید.

به‌طور خلاصه، این یک API سبک وزن و ساده برای خواندن داده‌های Excel است — دقیقاً آن‌چه بسیاری از توسعه‌دهندگان بدون بار اضافی کتابخانهٔ کامل پردازش صفحه‌گسترده نیاز دارند.

## **بیایید کد بنویسیم**

### **مثال سناریوی ادغام نامه**

در مثال زیر، یک سناریوی ساده ادغام نامه را با تولید چندین پرزنتیشن بر پایه داده‌های ذخیره‌شده در یک کتاب‌کار Excel پیاده‌سازی می‌کنیم.

برای شروع، به دو مورد نیاز داریم:
1. یک کتاب‌کار Excel حاوی داده‌ها

![مثال داده‌های Excel](example1_image0.png)

2. قالب پرزنتیشن PowerPoint

![مثال قالب PowerPoint](example1_image1.png)

```java
// دفتر کار اکسل شامل داده‌های کارمندان را بارگذاری کنید.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// قالب ارائه را بارگذاری کنید.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // در سطرهای اکسل پیمایش کنید (به‌جز سرصفحه در سطر 0).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // برای هر رکورد کارمند یک ارائه جدید ایجاد کنید.
        Presentation employeePresentation = new Presentation();

        try {
            // اسلاید خالی پیش‌فرض را حذف کنید.
            employeePresentation.getSlides().removeAt(0);

            // اسلاید قالب را در ارائه جدید کلون کنید.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // پاراگراف‌ها را از شکل هدف دریافت کنید (فرض می‌شود شاخص شکل 1 استفاده شده باشد).
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // متغیرهای جایگزین را با داده‌های اکسل جایگزین کنید.
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // ارائه شخصی‌سازی‌شده را در یک فایل جداگانه ذخیره کنید.
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

### **مثال جدول اکسل**

در مثال دوم، به سادگی داده‌ها را از یک جدول Excel کپی می‌کنیم و آن را روی یک اسلاید PowerPoint به شکل جذاب‌تری نمایش می‌دهیم.

در این مثال، همان کتاب‌کار Excel استفاده شده در مثال اول را که شامل یک جدول سادهٔ کارمندان است، باز استفاده می‌کنیم.

```java
// دفتر کار اکسل شامل داده‌های کارمندان را بارگذاری کنید.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// یک ارائه پاورپوینت جدید ایجاد کنید.
Presentation presentation = new Presentation();

try {
    // یک شکل جدول را به اولین اسلاید اضافه کنید.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // جدول پاورپوینت را با داده‌های کتاب کار اکسل پر کنید.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // ارائه حاصل را در یک فایل ذخیره کنید.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![نتیجه](example2_image0.png)

### **مثال وارد کردن نمودار اکسل**

در این مثال، یک نمودار را از اولین صفحه کاری کتاب‌کار Excel استفاده شده در مثال قبلی وارد می‌کنیم. نمودار در ارائهٔ نهایی به کتاب‌کار خارجی لینک خواهد شد.

ابتدا یک نمودار دایره‌ای (Pie) به کتاب‌کار Excel بر پایه جدول کارمندان اضافه می‌کنیم.

![مثال نمودار اکسل](example3_image0.png)

```java
// یک ارائه پاورپوینت جدید ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // مجموعهٔ اشکال اسلاید اول را دریافت کنید.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // نمودار با نام "Chart 1" را از اولین شیت کتاب‌کار وارد کنید و به مجموعهٔ اشکال اضافه کنید.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // ارائهٔ حاصل را در یک فایل ذخیره کنید.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![نتیجه](example3_image1.png)

### **مثال وارد کردن تمام نمودارهای اکسل**

تصور کنید یک کتاب‌کار Excel پر از نمودار دارید و می‌خواهید همهٔ آن‌ها را به یک پرزنتیشن وارد کنید. هر نمودار باید در یک اسلاید جدید قرار گیرد.

کد زیر تمام صفحات کاری در فایل Excel منبع را پیمایش می‌کند، نمودارها را از هر صفحه استخراج می‌کند و هر نمودار را با استفاده از یک طرح اسلاید خالی به اسلایدی جداگانه اضافه می‌کند. در پرزنتیشن نهایی، فقط داده‌های نمودار جاسازی می‌شود، نه کل کتاب‌کار.

```java
// دفتر کار اکسل شامل داده‌های کارمندان را بارگذاری کنید.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// یک ارائه پاورپوینت جدید ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // طرح اسلاید خالی را دریافت کنید.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // نام تمام شیت‌های موجود در کتاب‌کار اکسل را بدست آورید.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // نقشه‌ای که شاخص‌های نمودار را به نام‌های آن‌ها برای شیت مرتبط می‌کند، دریافت کنید.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // یک اسلاید جدید با استفاده از طرح خالی اضافه کنید.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // نمودار مشخص‌شده را از کتاب‌کار اکسل به مجموعهٔ اشکال اسلاید وارد کنید.
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

این مکانیزم، که مستقیماً در Aspose.Slides در دسترس است، کار با داده‌های Excel و پرزنتیشن‌ها را در یک مکان ترکیب می‌کند. این امکان را می‌دهد تا اسلایدهایی با نمودارهای بصری و داده‌های ارائه‌شده به صورت جدول‌های Excel ایجاد کنید — بدون نیاز به کتابخانه‌های اضافی یا ادغام‌های پیچیده.