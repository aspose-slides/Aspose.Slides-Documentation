---
title: یکپارچه‌سازی داده‌های Excel در ارائه‌های PowerPoint
linktitle: ادغام Excel
type: docs
weight: 330
url: /fa/net/excel-integration/
aliases:
  - /net/developer-guide/technical-articles/excel-integration/
keywords:
- Excel
- دفتر کار
- خواندن Excel
- ادغام Excel
- منبع داده
- ادغام ایمیل
- وارد کردن جدول
- Excel به PowerPoint
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "داده‌ها را از دفترهای کار Excel در Aspose.Slides با استفاده از API ExcelDataWorkbook بخوانید. شیت‌ها و سلول‌ها را بارگذاری کنید و از مقادیر آن‌ها برای تولید ارائه‌های PowerPoint مبتنی بر داده استفاده کنید."
---
## **معرفی**

ارائه‌های PowerPoint روشی قدرتمند برای نمایش و انتقال اطلاعات هستند. این ارائه‌ها اغلب در ترکیب با کتاب‌های کاری Excel استفاده می‌شوند، به‌طوری که Excel منبع بسیار خوبی برای داده‌های ساختاریافته فراهم می‌کند و PowerPoint در تجسم آن داده‌ها برای مخاطب مهارت دارد.

سناریوهای عملی بسیاری وجود دارد که ترکیب Excel و PowerPoint برای آن‌ها ضروری است: ادغام نامه‌ها، پر کردن جداول داده‌ای، تولید یک اسلاید برای هر رکورد داده (تولید دسته‌ای اسلاید)، ایجاد مواد آموزشی، و تجمیع چندین گزارش Excel در یک ارائه، تنها به چند مثال اشاره می‌کنیم.

تا به حال، پیاده‌سازی چنین ویژگی‌هایی با API Aspose.Slides نیاز به اتکا به راه‌حل‌های شخص ثالث مانند Aspose.Cells داشت. اگرچه این ابزارها قدرتمند هستند، برای کاربرانی که فقط به عملکرد پایه‌ای ادغام داده‌ها نیاز دارند می‌توانند بیش از حد پیچیده و هزینه‌بر باشند.

## **نحوه کار**

برای ساده‌تر و روان‌تر شدن کار با داده‌های Excel، Aspose.Slides کلاس‌های جدیدی برای خواندن داده‌ها از کتاب‌های کاری Excel و وارد کردن محتوا در یک ارائه معرفی کرده است. این قابلیت امکانات قدرتمند جدیدی برای کاربران API که می‌خواهند از Excel به‌عنوان منبع داده در جریان‌های کاری ارائه خود استفاده کنند، باز می‌کند.

عملکرد جدید برای دسترسی عمومی به داده‌ها طراحی شده و در مدل شیء سند ارائه (Presentation Document Object Model) ادغام نشده است. یعنی *این امکان ویرایش یا ذخیره فایل‌های Excel را فراهم نمی‌کند* — هدف اصلی آن فقط باز کردن کتاب‌های کاری و مرور محتوا برای استخراج داده‌های سلولی است.

در قلب این ویژگی کلاس جدید [ExcelDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.excel/exceldataworkbook/) است. این کلاس به شما امکان بارگذاری یک کتاب کاری Excel از فایل محلی یا جریان (stream) را می‌دهد. پس از بارگذاری، چندین overload از متد [GetCell](https://reference.aspose.com/slides/fa/net/aspose.slides.excel/exceldataworkbook/getcell/) در اختیار شماست که می‌توانید برای دریافت سلول‌های خاص بر اساس موقعیتشان (مثلاً ایندکس ردیف و ستون یا محدوده‌های نام‌گذاری‌شده) استفاده کنید.

هر فراخوانی به [GetCell](https://reference.aspose.com/slides/fa/net/aspose.slides.excel/exceldataworkbook/getcell/) یک نمونه از کلاس [ExcelDataCell](https://reference.aspose.com/slides/fa/net/aspose.slides.excel/exceldatacell/) را برمی‌گرداند. این شیء نمایانگر یک سلول واحد در کتاب کاری Excel است و به شما دسترسی ساده و شهودی به مقدار آن سلول می‌دهد.

#### **وارد کردن یک نمودار Excel**

گام بعدی برای گسترش عملکرد، کلاس [ExcelWorkbookImporter](https://reference.aspose.com/slides/fa/net/aspose.slides.import/excelworkbookimporter/) است. این کلاس کمکی عملکردی برای وارد کردن محتوا از یک کتاب کاری Excel به یک ارائه فراهم می‌کند. این کلاس چند overload از متد [AddChartFromWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) دارد که به شما کمک می‌کند نمودار انتخابی را از کتاب کاری Excel مشخص شده بازیابی کنید و در مختصات تعیین‌شده به انتهای مجموعه شکل‌های داده‌شده اضافه کنید.

#### **وارد کردن یک جدول Excel**

کلاس [ExcelWorkbookImporter](https://reference.aspose.com/slides/fa/net/aspose.slides.import/excelworkbookimporter/) همچنین چند overload از متد [AddTableFromWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/) دارد. این متدها به شما اجازه می‌دهند محدوده سلولی مشخصی را از یک Worksheet مشخص وارد کنید و به‌صورت جدول در انتهای مجموعه شکل‌های داده‌شده در مختصات تعیین‌شده اضافه کنید.

به‌طور خلاصه، این یک API سبک و ساده برای خواندن داده‌های Excel است — دقیقاً آنچه بسیاری از توسعه‌دهندگان بدون بار اضافی یک کتابخانه کامل پردازش صفحه‑گسترده می‌خواهند.

## **بیایید کد بنویسیم**

### **مثال سناریوی ادغام نامه**

در مثال زیر، سناریوی ساده‌ای از ادغام نامه را پیاده‌سازی می‌کنیم که بر پایه داده‌های موجود در یک کتاب کاری Excel، چندین ارائه تولید می‌کند.

برای شروع، به دو مورد نیاز داریم:
1. یک کتاب کاری Excel حاوی داده‌ها

![مثال داده‌های Excel](example1_image0.png)

2. قالب ارائه PowerPoint

![مثال قالب PowerPoint](example1_image1.png)

```csharp
// بارگذاری دفتر کار Excel با داده‌های کارمند.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// بارگذاری قالب ارائه.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// پیمایش ردیف‌های Excel (به‌جز سرصفحه در ردیف 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // ایجاد یک ارائه جدید برای هر رکورد کارمند.
    using Presentation employeePresentation = new Presentation();

    // حذف اسلاید خالی پیش‌فرض.
    employeePresentation.Slides.RemoveAt(0);

    // کلون کردن اسلاید قالب به داخل ارائه جدید.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // دریافت پاراگراف‌ها از شکل هدف (فرض می‌شود اندیس شکل 1 استفاده شده باشد).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // جایگزینی متغیرهای جای‌گذاری با داده‌های Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // ذخیره ارائه شخصی‌سازی‌شده در یک فایل جداگانه.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![نتیجه](example1_image2.png)

### **مثال جدول Excel**

در مثال دوم، به‌سادگی داده‌ها را از یک جدول Excel کپی می‌کنیم و در یک اسلاید PowerPoint به شکلی جذاب‌تر نمایش می‌دهیم.

در این مثال، همان کتاب کاری Excel را که در مثال اول استفاده شد، دوباره به کار می‌بریم؛ این کتاب حاوی یک جدول ساده کارکنان است.

```csharp
// بارگذاری دفتر کار Excel حاوی داده‌های کارمند.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// ایجاد یک ارائه PowerPoint جدید.
using Presentation presentation = new Presentation();

// افزودن یک شکل جدول به اسلاید اول.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// پرکردن جدول PowerPoint با داده‌های دفتر کار Excel.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// ذخیره ارائه نهایی به یک فایل.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![نتیجه](example2_image0.png)

### **مثال وارد کردن یک نمودار Excel**

در این مثال، یک نمودار را از اولین Worksheet کتاب کاری Excel استفاده‌شده در مثال قبلی وارد می‌کنیم. این نمودار در ارائه نهایی به کتاب کاری خارجی لینک خواهد شد.

ابتدا یک نمودار دایره‌ای (Pie) بر اساس جدول کارکنان به کتاب کاری Excel اضافه می‌کنیم.

![مثال نمودار Excel](example3_image0.png)

```csharp
// یک ارائه PowerPoint جدید ایجاد کنید.
using Presentation presentation = new Presentation();

// دریافت مجموعه شکل‌ها از اسلاید اول.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// نمودار با نام "Chart 1" را از اولین شیت دفتر کار وارد کنید و به مجموعه شکل‌ها اضافه کنید.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// ارائه حاصل را در یک فایل ذخیره کنید.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![نتیجه](example3_image1.png)

### **مثال وارد کردن تمام نمودارهای Excel**

فرض کنید یک کتاب کاری Excel پر از نمودار دارید و می‌خواهید همه آن‌ها را به یک ارائه وارد کنید. هر نمودار باید در یک اسلاید جدید قرار گیرد.

کد زیر تمام Worksheetهای موجود در فایل Excel منبع را مرور می‌کند، نمودارهای هر Worksheet را استخراج می‌کند و هر یک را با استفاده از یک طرح اسلاید خالی به اسلاید جداگانه‌ای اضافه می‌گردد. در ارائه نهایی فقط داده‌های نمودارها تعبیه می‌شود، نه کل کتاب کاری.

```csharp
// کتاب کار Excel حاوی داده‌های کارمند را بارگذاری کنید.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// یک ارائه PowerPoint جدید ایجاد کنید.
using Presentation presentation = new Presentation();

// دریافت چینش اسلاید خالی.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// دریافت نام تمام worksheets موجود در دفتر کار Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // دریافت دیکشنری‌ای که ایندکس‌های نمودار را به نام‌های نمودار برای worksheet نگاشت می‌کند.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // افزودن یک اسلاید جدید با استفاده از چینش خالی.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // وارد کردن نمودار مشخص‌شده از دفتر کار Excel به مجموعه شکل‌های اسلاید.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// ذخیره ارائه نهایی در یک فایل.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **مثال وارد کردن یک جدول Excel**

در این مثال، یک جدول قالب‌بندی‌شده را مستقیماً از یک Worksheet Excel به یک ارائه PowerPoint وارد می‌کنیم.

Worksheet منبع Excel شامل یک جدول قالب‌بندی‌شده با داده‌های کارکنان است:

![مثال جدول Excel](example4_image0.png)

```csharp
// یک ارائه PowerPoint جدید ایجاد کنید.
using Presentation presentation = new Presentation();

// دریافت مجموعه شکل‌ها از اسلاید اول.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// جدول را از اولین شیت دفتر کار وارد کنید و به مجموعه شکل‌ها اضافه کنید.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// ارائه حاصل را در یک فایل ذخیره کنید.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```

![نتیجه](example4_image1.png)


## **خلاصه**

این مکانیزم که مستقیماً در Aspose.Slides موجود است، کار با داده‌های Excel و ارائه‌ها را در یک مکان ترکیب می‌کند. این امکان را می‌دهد تا اسلایدهایی با نمودارهای بصری و داده‌های ارائه‌شده به شکل جدول‌های Excel ایجاد کنید — بدون نیاز به کتابخانه‌های اضافی یا یکپارچه‌سازی‌های پیچیده.