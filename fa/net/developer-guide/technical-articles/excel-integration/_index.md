---
title: ادغام داده‌های اکسل در ارائه‌های پاورپوینت
linktitle: یکپارچه‌سازی اکسل
type: docs
weight: 330
url: /fa/net/excel-integration/
keywords:
- اکسل
- کتاب‌کار
- خواندن اکسل
- یکپارچه‌سازی اکسل
- منبع داده
- ترکیب نامه
- وارد کردن جدول
- اکسل به پاورپوینت
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "داده‌ها را از کتاب‌های کاری اکسل در Aspose.Slides با استفاده از API ExcelDataWorkbook بخوانید. شیت‌ها و سلول‌ها را بارگذاری کنید و از مقادیر آن‌ها برای تولید ارائه‌های پاورپوینت مبتنی بر داده استفاده کنید."
---
## **مقدمه**

ارائه‌های پاورپوینت روشی قدرتمند برای نمایش و انتقال اطلاعات هستند. آن‌ها اغلب همراه با کتاب‌های کاری اکسل استفاده می‌شوند؛ جایی که اکسل به عنوان منبع داده‌های ساختاریافته عالی عمل می‌کند و پاورپوینت در تجسم این داده‌ها برای مخاطب برتری دارد.

چندین سناریوی عملی وجود دارد که ترکیب اکسل و پاورپوینت ضروری است: ادغام نامه‌ها، پرکردن جداول داده، تولید یک اسلاید برای هر رکورد داده (تولید اسلایدهای دسته‌ای)، ایجاد مطالب آموزشی، و تجمیع چندین گزارش اکسل در یک ارائه، و غیره.

تا کنون، پیاده‌سازی چنین ویژگی‌هایی با API Aspose.Slides نیاز به اعتماد به راه‌حل‌های شخص ثالث مانند Aspose.Cells داشت. اگرچه این ابزارها قوی هستند، می‌توانند برای کاربرانی که فقط به عملکرد پایه یکپارچه‌سازی داده نیاز دارند، بیش از حد پیچیده و هزینه‌بر باشند.

## **نحوه کارکرد**

برای آسان‌تر و به‌صرفه‌تر کردن کار با داده‌های اکسل، Aspose.Slides کلاس‌های جدیدی برای خواندن داده‌ها از کتاب‌های کاری اکسل و وارد کردن محتوا به یک ارائه معرفی کرده است. این ویژگی امکانات جدید قدرتمندی را برای کاربران API فراهم می‌کند که می‌خواهند از اکسل به‌عنوان منبع داده در جریان کارهای ارائه خود استفاده کنند.

عملکرد جدید برای دسترسی عمومی به داده طراحی شده و در مدل شیء سند ارائه (DOM) یکپارچه نشده است. یعنی *اجازه ویرایش یا ذخیره‌سازی فایل‌های اکسل را نمی‌دهد* — هدف sole آن فقط باز کردن کتاب‌های کاری و مرور محتوا برای استخراج داده‌های سلول است.

در هسته این ویژگی، کلاس جدید [ExcelDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.excel/exceldataworkbook/) قرار دارد. این کلاس به شما امکان می‌دهد یک کتاب کاری اکسل را از فایل محلی یا یک جریان بارگذاری کنید. پس از بارگذاری، چندین overload از متد [GetCell](https://reference.aspose.com/slides/fa/net/aspose.slides.excel/exceldataworkbook/getcell/) را فراهم می‌کند که می‌توانید برای دریافت سلول‌های خاص بر اساس موقعیت آن‌ها (مانند شاخص‌های ردیف و ستون یا بازه‌های نام‌گذاری‌شده) استفاده کنید.

هر فراخوانی از [GetCell](https://reference.aspose.com/slides/fa/net/aspose.slides.excel/exceldataworkbook/getcell/) یک نمونه از کلاس [ExcelDataCell](https://reference.aspose.com/slides/fa/net/aspose.slides.excel/exceldatacell/) را بر می‌گرداند. این شیء نمایانگر یک سلول واحد در کتاب کاری اکسل است و به شما دسترسی ساده و مستقیم به مقدار آن ارائه می‌دهد.

#### **وارد کردن نمودار اکسل**

گام بعدی برای گسترش عملکرد، کلاس [ExcelWorkbookImporter](https://reference.aspose.com/slides/fa/net/aspose.slides.import/excelworkbookimporter/) است. این کلاس ابزار، قابلیت وارد کردن محتوا از یک کتاب کاری اکسل به یک ارائه را فراهم می‌کند. آن شامل چند overload از متد [AddChartFromWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) است که به شما کمک می‌کند نمودار انتخاب‌شده را از کتاب کاری اکسل مشخص شده استخراج کرده و در انتهای مجموعه شکل‌های داده‌شده، در مختصات تعیین‌شده اضافه کنید.

#### **وارد کردن جدول اکسل**

کلاس [ExcelWorkbookImporter](https://reference.aspose.com/slides/fa/net/aspose.slides.import/excelworkbookimporter/) همچنین شامل چند overload از متد [AddTableFromWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/) است. این متدها به شما امکان می‌دهند یک بازه سلولی مشخص از یک ورق کاری معین را وارد کنید و به عنوان جدول در انتهای مجموعه شکل‌های داده‌شده، در مختصات تعیین‌شده اضافه کنید.

به‌طور خلاصه، این یک API سبک و ساده برای خواندن داده‌های اکسل است — دقیقاً همان‌چیزی که بسیاری از توسعه‌دهندگان بدون بار اضافی یک کتابخانه کامل پردازش صفحات‌محور نیاز دارند.

## **بیایید برنامه‌نویسی کنیم**

### **مثال سناریوی ادغام نامه**

در مثال زیر، یک سناریو ساده ادغام نامه را با تولید چندین ارائه بر پایه داده‌های ذخیره‌شده در یک کتاب کاری اکسل پیاده‌سازی می‌کنیم.

برای شروع، به دو مورد نیاز داریم:
1. یک کتاب کاری اکسل حاوی داده‌ها
![مثال داده‌های اکسل](example1_image0.png)

2.  قالب ارائه پاورپوینت
![مثال قالب پاورپوینت](example1_image1.png)

```csharp
// بارگذاری کتاب کار اکسل با داده‌های کارمند.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// بارگذاری قالب ارائه.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// حلقه‌زدن روی ردیف‌های اکسل (به‌جز سرصفحه در ردیف 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // ایجاد یک ارائه جدید برای هر رکورد کارمند.
    using Presentation employeePresentation = new Presentation();

    // حذف اسلاید خالی پیش‌فرض.
    employeePresentation.Slides.RemoveAt(0);

    // کلون کردن اسلاید قالب به داخل ارائه جدید.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // دریافت پاراگراف‌ها از شکل هدف (فرض می‌شود ایندکس شکل 1 استفاده شده است).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // جایگزینی نگهدارنده‌ها با داده‌های اکسل.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // ذخیره ارائه شخصی‌سازی‌شده به فایل جداگانه.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```
![نتیجه](example1_image2.png)

### **مثال جدول اکسل**

در مثال دوم، به‌سادگی داده‌ها را از یک جدول اکسل کپی کرده و در یک اسلاید پاورپوینت به شکل ظاهری جذاب‌تر نمایش می‌دهیم.

در این مثال، همان کتاب کاری اکسل مورد استفاده در مثال اول را که شامل یک جدول ساده کارمندان است، مجدداً استفاده می‌کنیم.

```csharp
// بارگذاری کتاب کار اکسل شامل داده‌های کارمندان.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// ایجاد یک ارائه پاورپوینت جدید.
using Presentation presentation = new Presentation();

// افزودن شکل جدول به اسلاید اول.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// پر کردن جدول پاورپوینت با داده‌های کتاب کار اکسل.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// ذخیره ارائه حاصل در یک فایل.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```
![نتیجه](example2_image0.png)

### **مثال وارد کردن نمودار اکسل**

در این مثال، یک نمودار را از اولین ورق کاری کتاب اکسل استفاده‌شده در مثال قبلی وارد می‌کنیم. نمودار در ارائه نهایی به کتاب کاری خارجی پیوند خواهد داد.

ابتدا، یک نمودار دایره‌ای بر پایه جدول کارمندان به کتاب کاری اکسل اضافه می‌کنیم.

![مثال نمودار اکسل](example3_image0.png)

```csharp
// ایجاد یک ارائه پاورپوینت جدید.
using Presentation presentation = new Presentation();

// دریافت مجموعه اشکال اسلاید اول.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// وارد کردن نمودار با نام "Chart 1" از اولین شیت کتاب کار و افزودن آن به مجموعه اشکال.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// ذخیره ارائه حاصل در یک فایل.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![نتیجه](example3_image1.png)

### **مثال وارد کردن تمام نمودارهای اکسل**

تصور کنید یک کتاب کاری اکسل پر از نمودارها دارید و نیاز دارید تمام آن‌ها را به یک ارائه وارد کنید. هر نمودار باید در یک اسلاید جدید قرار گیرد.

کد زیر تمام ورق‌های کاری در فایل اکسل منبع را مرور می‌کند، نمودارهای هر ورق را استخراج می‌کند و هر نمودار را با استفاده از یک طرح اسلاید خالی به اسلاید جداگانه‌ای اضافه می‌نماید. در ارائه نهایی، فقط داده‌های نمودار جاسازی می‌شود و نه کل کتاب کاری.

```csharp
// بارگذاری کتاب کار اکسل حاوی داده‌های کارمند.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// ایجاد یک ارائه پاورپوینت جدید.
using Presentation presentation = new Presentation();

// دریافت طرح اسلاید خالی.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// دریافت نام تمام ورق‌های کاری موجود در کتاب کار اکسل.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // دریافت یک دیکشنری که شاخص‌های نمودار را به نام‌های آن برای ورق کاری نگاشت می‌کند.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // افزودن اسلاید جدید با استفاده از طرح خالی.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // وارد کردن نمودار مشخص‌شده از کتاب کار اکسل به مجموعه اشکال اسلاید.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// ذخیره ارائه حاصل در یک فایل.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **مثال وارد کردن جدول اکسل**

در این مثال، یک جدول قالب‌بندی‌شده را از یک ورق کاری اکسل مستقیم به یک ارائه پاورپوینت وارد می‌کنیم.

ورق کاری اکسل منبع شامل یک جدول قالب‌بندی‌شده با داده‌های کارمندان است:

![مثال جدول اکسل](example4_image0.png)

```csharp
// ایجاد یک ارائه پاورپوینت جدید.
using Presentation presentation = new Presentation();

// دریافت مجموعه اشکال اسلاید اول.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// وارد کردن جدول از اولین شیت کتاب کار و افزودن آن به مجموعه اشکال.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// ذخیره ارائه حاصل در یک فایل.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```
![نتیجه](example4_image1.png)

## **خلاصه**

این مکانیزم که به‌صورت مستقیم در Aspose.Slides در دسترس است، کار با داده‌های اکسل و ارائه‌ها را در یک مکان ترکیب می‌کند. این امکان را می‌دهد که اسلایدهایی با نمودارهای بصری و داده‌های ارائه‌شده به شکل جداول اکسل ایجاد کنید — بدون نیاز به کتابخانه‌های اضافی یا ادغام‌های پیچیده.