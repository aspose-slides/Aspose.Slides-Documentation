---
title: یکپارچه‌سازی داده‌های اکسل در ارائه‌های پاورپوینت
linktitle: یکپارچه‌سازی اکسل
type: docs
weight: 330
url: /fa/net/excel-integration/
keywords:
- اکسل
- دفتر کار
- خواندن اکسل
- یکپارچه‌سازی اکسل
- منبع داده
- ادغام ایمیل
- وارد کردن جدول
- اکسل به پاورپوینت
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "داده‌ها را از کتاب‌کارهای Excel در Aspose.Slides با استفاده از API ExcelDataWorkbook بخوانید. برگه‌ها و سلول‌ها را بارگیری کنید و از مقادیر برای تولید ارائه‌های PowerPoint مبتنی بر داده استفاده کنید."
---
## **مقدمه**

پیشنهادات PowerPoint روشی قدرتمند برای نمایش و انتقال اطلاعات هستند. آن‌ها اغلب همراه با کاربرگ‌های Excel استفاده می‌شوند، جایی که Excel به عنوان منبع عالی داده‌های ساختار یافته عمل می‌کند و PowerPoint در تصویرسازی آن داده‌ها برای مخاطب برتری دارد.

سناریوهای عملی زیادی وجود دارد که ترکیب Excel و PowerPoint ضروری است: ترکیب ایمیل، پر کردن جداول داده‌ها، تولید یک اسلاید برای هر رکورد داده (تولید دسته‌ای اسلاید)، ایجاد مطالب آموزشی، و یکپارچه‌سازی چندین گزارش Excel در یک ارائه، به عنوان مثال.

تا کنون، پیاده‌سازی چنین ویژگی‌هایی با API Aspose.Slides نیاز به تکیه بر راه‌حل‌های شخص ثالث مانند Aspose.Cells داشت. اگرچه این ابزارها قدرتمند هستند، می‌توانند برای کاربرانی که فقط به عملکرد یکپارچه‌سازی داده‌های پایه نیاز دارند، بسیار پیچیده و هزینه‌بر باشند.

## **نحوه کار**

برای ساده‌تر و کارآمدتر کردن کار با داده‌های Excel، Aspose.Slides کلاس‌های جدیدی برای خواندن داده‌ها از کاربرگ‌های Excel و وارد کردن محتوا به یک ارائه معرفی کرده است. این ویژگی امکانات جدیدی قدرتمند برای کاربران API فراهم می‌کند که می‌خواهند Excel را به عنوان منبع داده در جریان کاری ارائه خود به کار ببرند.

این قابلیت جدید برای دسترسی عمومی به داده‌ها طراحی شده و در درخت سند ارائه (DOM) ادغام نشده است. به این معنی که *اجازه ویرایش یا ذخیره فایل‌های Excel را نمی‌دهد* — هدف تک‌تاکی آن باز کردن کاربرگ‌ها و مرور محتوا برای استخراج داده‌های سلولی است.

در قلب این ویژگی، کلاس جدید [ExcelDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.excel/exceldataworkbook/) قرار دارد. این کلاس به شما اجازه می‌دهد یک کاربرگ Excel را از فایل محلی یا جریان بارگذاری کنید. پس از بارگذاری، چندین overload از متد [GetCell](https://reference.aspose.com/slides/fa/net/aspose.slides.excel/exceldataworkbook/getcell/) در اختیار شماست که می‌توانید برای دریافت سلول‌های خاص بر اساس موقعیتشان (مثلاً ایندکس‌های ردیف و ستون یا نام محدوده) استفاده کنید.

هر فراخوانی از متد [GetCell](https://reference.aspose.com/slides/fa/net/aspose.slides.excel/exceldataworkbook/getcell/) یک نمونه از کلاس [ExcelDataCell](https://reference.aspose.com/slides/fa/net/aspose.slides.excel/exceldatacell/) برمی‌گرداند. این شیء نمایانگر یک سلول واحد در کاربرگ Excel است و دسترسی ساده و شهودی به مقدار آن را فراهم می‌کند.

#### **وارد کردن نمودار Excel**

گام بعدی برای گسترش قابلیت، کلاس [ExcelWorkbookImporter](https://reference.aspose.com/slides/fa/net/aspose.slides.import/excelworkbookimporter/) است. این کلاس کمکی قابلیت وارد کردن محتوا از یک کاربرگ Excel به یک ارائه را فراهم می‌کند. این کلاس چند overload از متد [AddChartFromWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) دارد که به شما کمک می‌کند نمودار انتخاب‌شده را از کاربرگ Excel مشخص شده استخراج کرده و در انتهای مجموعه اشکال داده‌شده در مختصات تعیین‌شده اضافه کنید.

به طور خلاصه، این یک API سبک و ساده برای خواندن داده‌های Excel است — دقیقاً همان چیزی که بسیاری از توسعه‌دهندگان بدون بار اضافی یک کتابخانه کامل پردازش جدول‑محور نیاز دارند.

## **بیایید کدنویسی کنیم**

### **مثال سناریوی ترکیب ایمیل**

در مثال زیر، یک سناریوی ساده ترکیب ایمیل را با تولید چندین ارائه بر پایه داده‌های ذخیره‌شده در یک کاربرگ Excel پیاده‌سازی می‌کنیم.

برای شروع، به دو مورد نیاز داریم:
1. یک کاربرگ Excel حاوی داده‌ها

![مثال داده‌های Excel](example1_image0.png)

2. قالب ارائه PowerPoint

![مثال قالب PowerPoint](example1_image1.png)

```csharp
// کتاب کار Excel حاوی داده‌های کارمندان را بارگذاری کنید.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// قالب ارائه را بارگذاری کنید.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// از سطرهای Excel عبور کنید (به‌جز سرفصل در سطر ۰).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // یک ارائه جدید برای هر رکورد کارمند ایجاد کنید.
    using Presentation employeePresentation = new Presentation();

    // اسلاید خالی پیش‌فرض را حذف کنید.
    employeePresentation.Slides.RemoveAt(0);

    // اسلاید قالب را به ارائه جدید کلون کنید.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // پاراگراف‌ها را از شکل هدف دریافت کنید (فرض می‌شود اندیس شکل ۱ استفاده شده باشد).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // متغیرهای جایگزین را با داده‌های Excel جایگزین کنید.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // ارائه شخصی‌سازی‌شده را در یک فایل جداگانه ذخیره کنید.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![نتیجه](example1_image2.png)

### **مثال جدول Excel**

در مثال دوم، به سادگی داده‌ها را از یک جدول Excel کپی می‌کنیم و آن را در یک اسلاید PowerPoint به شکل بصری‌تری نمایش می‌دهیم.

در این مثال، همان کاربرگ Excel مثال قبلی را استفاده می‌کنیم که شامل یک جدول ساده کارمندان است.

```csharp
// کتاب کار Excel حاوی داده‌های کارمندان را بارگذاری کنید.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// یک ارائه PowerPoint جدید ایجاد کنید.
using Presentation presentation = new Presentation();

// یک شکل جدول به اسلاید اول اضافه کنید.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// جدول PowerPoint را با داده‌های کتاب کار Excel پر کنید.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// ارائه حاصل را در یک فایل ذخیره کنید.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![نتیجه](example2_image0.png)

### **مثال وارد کردن نمودار Excel**

در این مثال، یک نمودار را از اولین برگه کاری کاربرگ Excel استفاده‌شده در مثال قبلی وارد می‌کنیم. نمودار در ارائه نهایی به کاربرگ خارجی لینک خواهد شد.

ابتدا یک نمودار دایره‌ای (Pie) به کاربرگ Excel بر پایه جدول کارمندان اضافه می‌کنیم.

![مثال نمودار Excel](example3_image0.png)

```csharp
// یک ارائه PowerPoint جدید ایجاد کنید.
using Presentation presentation = new Presentation();

// مجموعه اشکال اسلاید اول را دریافت کنید.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// نمودار به نام "Chart 1" را از اولین برگه کاربرگ وارد کرده و به مجموعهٔ اشکال اضافه کنید.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// ارائهٔ حاصل را در یک فایل ذخیره کنید.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![نتیجه](example3_image1.png)

### **مثال وارد کردن تمام نمودارهای Excel**

فرض کنید یک کاربرگ Excel پر از نمودارها دارید و می‌خواهید همه آن‌ها را به یک ارائه وارد کنید. هر نمودار باید در یک اسلاید جدید قرار گیرد.

کد زیر تمام برگه‌های کاری فایل Excel منبع را مرور می‌کند، نمودارها را از هر برگه استخراج می‌کند و هر نمودار را با استفاده از یک طرح اسلاید خالی به یک اسلاید جداگانه اضافه می‌کند. در ارائه نهایی، فقط داده‌های نمودار جاسازی می‌شوند، نه کل کاربرگ.

```csharp
// کتاب کار Excel حاوی داده‌های کارمندان را بارگذاری کنید.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// یک ارائه PowerPoint جدید ایجاد کنید.
using Presentation presentation = new Presentation();

// طرح اسلاید خالی را دریافت کنید.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// نام‌های تمام برگه‌های کاری موجود در کتاب کار Excel را دریافت کنید.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // یک فرهنگ‌نامه که ایندکس‌های نمودار را به نام‌های نمودار برای برگه کاری نگاشت می‌کند.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // یک اسلاید جدید با استفاده از طرح خالی اضافه کنید.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // نمودار مشخص‌شده را از کتاب کار Excel به مجموعهٔ اشکال اسلاید وارد کنید.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// ارائهٔ حاصل را در یک فایل ذخیره کنید.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

## **خلاصه**

این مکانیزم که مستقیماً در Aspose.Slides موجود است، کار با داده‌های Excel و ارائه‌ها را در یک مکان ترکیب می‌کند. این امکان را می‌دهد تا اسلایدهایی با نمودارهای بصری و داده‌ها به صورت جداول Excel ایجاد کنید — بدون نیاز به کتابخانه‌های اضافه یا ادغام‌های پیچیده.