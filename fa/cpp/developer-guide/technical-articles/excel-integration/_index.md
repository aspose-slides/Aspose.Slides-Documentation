---
title: یکپارچه‌سازی داده‌های اکسل در ارائه‌های پاورپوینت
linktitle: یکپارچه‌سازی اکسل
type: docs
weight: 330
url: /fa/cpp/excel-integration/
keywords:
- اکسل
- کتاب‌کار
- خواندن اکسل
- ادغام اکسل
- منبع داده
- ادغام ایمیل
- وارد کردن جدول
- اکسل به پاورپوینت
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "داده‌ها را از کتاب‌کارهای اکسل در Aspose.Slides با استفاده از API ExcelDataWorkbook بخوانید. شیت‌ها و سلول‌ها را بارگذاری کنید و از مقادیر برای تولید ارائه‌های پاورپوینتی مبتنی بر داده استفاده کنید."
---
## **معرفی**

ارائه‌های پاورپوینت یک روش قدرتمند برای نمایش و انتقال اطلاعات هستند. این ارائه‌ها اغلب همراه با کتاب‌کارهای اکسل استفاده می‌شوند، که در آن اکسل به عنوان منبع عالی داده‌های ساختاریافته عمل می‌کند و پاورپوینت به‌خوبی این داده‌ها را برای مخاطبان به تصویر می‌کشد.

سنارهایی عملی بسیاری وجود دارد که ترکیب اکسل و پاورپوینت در آن‌ها ضروری است: ادغام ایمیل، پر کردن جدول‌های داده، تولید یک اسلاید برای هر رکورد داده (تولید دسته‌ای اسلاید)، ایجاد مواد آموزشی، و ترکیب چندین گزارش اکسل در یک ارائه، فقط به چند مورد از آن‌ها اشاره شد.

تا کنون، پیاده‌سازی چنین ویژگی‌هایی با API Aspose.Slides نیاز به استفاده از راه‌حل‌های شخص ثالث مانند Aspose.Cells داشت. اگرچه این ابزارها قدرتمندند، برای کاربرانی که تنها به عملکرد سادهٔ یکپارچه‌سازی داده نیاز دارند می‌توانند بیش از حد پیچیده و هزینه‌بر باشند.

## **نحوه کار**

برای ساده‌تر و کارآمدتر کردن کار با داده‌های اکسل، Aspose.Slides کلاس‌های جدیدی برای خواندن داده‌ها از کتاب‌کارهای اکسل و وارد کردن محتوا به یک ارائه معرفی کرده است. این ویژگی امکانات جدیدی قدرتمند برای کاربران API که می‌خواهند اکسل را به عنوان منبع داده در جریان کار ارائه خود به کار بگیرند فراهم می‌کند.

عملکرد جدید برای دسترسی عمومی به داده طراحی شده است و در مدل شیء سند ارائه (DOM) یکپارچه نشده است. به این معنی که *امکان ویرایش یا ذخیرهٔ فایل‌های اکسل را ندارد* — هدف تنها باز کردن کتاب‌کارها و مرور محتوا برای بازیابی داده‌های سلول است.

در هستهٔ این ویژگی کلاس جدید [ExcelDataWorkbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.excel/exceldataworkbook/) قرار دارد. این کلاس به شما امکان می‌دهد یک کتاب‌کار اکسل را از فایل محلی یا یک جریان بارگذاری کنید. پس از بارگذاری، چندین overload از متد [GetCell](https://reference.aspose.com/slides/fa/cpp/aspose.slides.excel/exceldataworkbook/getcell/) در اختیار شماست که می‌توانید با استفاده از آن سلول‌های خاص را بر اساس موقعیت (مثلاً شاخص ردیف و ستون یا محدوده‌های نام‌دار) بازیابی کنید.

هر فراخوانی به [GetCell](https://reference.aspose.com/slides/fa/cpp/aspose.slides.excel/exceldataworkbook/getcell/) یک نمونه از کلاس [ExcelDataCell](https://reference.aspose.com/slides/fa/cpp/aspose.slides.excel/exceldatacell/) را برمی‌گرداند. این شیء نمایانگر یک سلول واحد در کتاب‌کار اکسل است و دسترسی ساده و شهودی به مقدار آن را فراهم می‌کند.

#### **وارد کردن یک نمودار اکسل**

گام بعدی برای گسترش عملکرد، کلاس [ExcelWorkbookImporter](https://reference.aspose.com/slides/fa/cpp/aspose.slides.import/excelworkbookimporter/) است. این کلاس کمکی عملکردی برای وارد کردن محتوا از کتاب‌کار اکسل به یک ارائه ارائه می‌دهد. این کلاس چند overload از متد [AddChartFromWorkbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) دارد که به شما کمک می‌کند نمودار انتخابی را از کتاب‌کار اکسل مشخص‌شده استخراج کرده و در انتهای مجموعهٔ شکل‌های داده‌شده در مختصات موردنظر اضافه کنید.

به‌عبارت دیگر، این یک API سبک و ساده برای خواندن داده‌های اکسل است — دقیقاً همان چیزی که بسیاری از توسعه‌دهندگان بدون بار اضافهٔ یک کتابخانهٔ کامل پردازش جدول‌محور نیاز دارند.

## **بیایید کد بنویسیم**

### **نمونه سناریوی ادغام ایمیل**

در مثال زیر، یک سناریوی سادهٔ ادغام ایمیل را پیاده‌سازی می‌کنیم که بر پایه داده‌های ذخیره‌شده در یک کتاب‌کار اکسل، چندین ارائه تولید می‌کند.

برای شروع، به دو مورد نیاز داریم:
1. یک کتاب‌کار اکسل حاوی داده‌ها

![مثال داده اکسل](example1_image0.png)

2. قالب ارائهٔ پاورپوینت

![مثال قالب پاورپوینت](example1_image1.png)

```cpp
// بارگذاری کتاب‌کار اکسل با داده‌های کارکنان.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// بارگذاری قالب ارائه.
auto templatePresentation = MakeObject<Presentation>(u"PresentationTemplate.pptx");

    // پیمایش ردیف‌های اکسل (به‌جز سرصفحه در ردیف ۰).
for (auto rowIndex = 1; rowIndex <= 4; rowIndex++) {

    // ایجاد یک ارائه جدید برای هر رکورد کارمند.
    auto employeePresentation = MakeObject<Presentation>();

    // حذف اسلاید خالی پیش‌فرض.
    employeePresentation->get_Slides()->RemoveAt(0);

    // کپی اسلاید قالب به ارائه جدید.
    auto slide = employeePresentation->get_Slides()->AddClone(templatePresentation->get_Slide(0));

    // دریافت پاراگراف‌ها از شکل هدف (فرض می‌کند اندیس شکل ۱ استفاده شده است).
    auto paragraphs = ExplicitCast<IAutoShape>(slide->get_Shape(1))->get_TextFrame()->get_Paragraphs();

    // جایگزینی متغیرهای جای‌دار با داده‌های اکسل.
    auto employeeName = workbook->GetCell(worksheetIndex, rowIndex, 0)->get_Value()->ToString();
    auto namePortion = paragraphs->idx_get(0)->get_Portion(0);
    namePortion->set_Text(namePortion->get_Text().Replace(u"{{EmployeeName}}", employeeName));

    auto department = workbook->GetCell(worksheetIndex, rowIndex, 1)->get_Value()->ToString();
    auto departmentPortion = paragraphs->idx_get(1)->get_Portion(0);
    departmentPortion->set_Text(departmentPortion->get_Text().Replace(u"{{Department}}", department));

    auto yearsOfService = workbook->GetCell(worksheetIndex, rowIndex, 2)->get_Value()->ToString();
    auto yearsPortion = paragraphs->idx_get(2)->get_Portion(0);
    yearsPortion->set_Text(yearsPortion->get_Text().Replace(u"{{YearsOfService}}", yearsOfService));

    // ذخیره ارائه شخصی‌سازی شده در یک فایل جداگانه.
    employeePresentation->Save(String::Format(u"{0} Report.pptx", employeeName), SaveFormat::Pptx);
    employeePresentation->Dispose();
}

templatePresentation->Dispose();
```

![نتیجه](example1_image2.png)

### **مثال جدول اکسل**

در مثال دوم، به سادگی داده‌ها را از یک جدول اکسل کپی می‌کنیم و در یک اسلاید پاورپوینت به شکل بصری جذاب‌تری نمایش می‌دهیم.

در این مثال، همان کتاب‌کار اکسل مورد استفاده در مثال اول که شامل یک جدول سادهٔ کارکنان است را مجدداً استفاده می‌کنیم.

```cpp
// بارگذاری کتاب‌کار اکسل حاوی داده‌های کارکنان.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// ایجاد یک ارائه جدید پاورپوینت.
auto presentation = MakeObject<Presentation>();

// افزودن یک شکل جدول به اولین اسلاید.
auto table = presentation->get_Slide(0)->get_Shapes()->AddTable(
    50, 200,
    MakeArray<double>({200, 200, 200}),
    MakeArray<double>({30, 30, 30, 30, 30})
);

// پر کردن جدول پاورپوینت با داده‌های کتاب‌کار اکسل.
for (auto rowIndex = 0; rowIndex < 5; rowIndex++) {
    for (auto columnIndex = 0; columnIndex < 3; columnIndex++) {
        auto cellValue = workbook->GetCell(worksheetIndex, rowIndex, columnIndex)->get_Value()->ToString();
        table->get_Column(columnIndex)->idx_get(rowIndex)->get_TextFrame()->set_Text(cellValue);
    }
}

// ذخیرهٔ ارائهٔ حاصل در یک فایل.
presentation->Save(u"Table.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![نتیجه](example2_image0.png)

### **مثال وارد کردن یک نمودار اکسل**

در این مثال، یک نمودار را از کاربرگ اول کتاب‌کار اکسل مورد استفاده در مثال قبلی وارد می‌کنیم. این نمودار در ارائهٔ نهایی به کتاب‌کار خارجی لینک می‌شود.

اول، یک نمودار دایره‌ای (Pie) به کتاب‌کار اکسل بر پایه جدول کارکنان اضافه می‌کنیم.

![مثال نمودار اکسل](example3_image0.png)

```cpp
// ایجاد یک ارائه جدید پاورپوینت.
auto presentation = MakeObject<Presentation>();

// دریافت مجموعهٔ شکل‌ها از اولین اسلاید.
auto shapes = presentation->get_Slide(0)->get_Shapes();

// وارد کردن نمودار به نام "Chart 1" از اولین شیت کتاب‌کار و افزودن آن به مجموعهٔ شکل‌ها.
ExcelWorkbookImporter::AddChartFromWorkbook(shapes, 10.0, 10.0, u"TemplateData.xlsx", u"Sheet1", u"Chart 1", false);

// ذخیرهٔ ارائهٔ حاصل در یک فایل.
presentation->Save(u"Chart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![نتیجه](example3_image1.png)

### **مثال وارد کردن تمام نمودارهای اکسل**

بیایید تصور کنیم یک کتاب‌کار اکسل پر از نمودارها دارید و می‌خواهید همهٔ آن‌ها را به یک ارائه وارد کنید. هر نمودار باید در یک اسلاید جدید قرار گیرد.

کد زیر تمام کاربرگ‌های فایل اکسل منبع را پیمایش می‌کند، نمودارها را از هر کاربرگ استخراج کرده و هر نمودار را با استفاده از یک قالب اسلاید خالی به یک اسلاید جداگانه اضافه می‌کند. در ارائهٔ حاصل، فقط دادهٔ نمودار تعبیه می‌شود، نه کل کتاب‌کار.

```cpp
// بارگذاری کتاب‌کار اکسل حاوی داده‌های کارکنان.
auto workbook = MakeObject<ExcelDataWorkbook>(u"ExcelWithCharts.xlsx");

// ایجاد یک ارائه جدید پاورپوینت.
auto presentation = MakeObject<Presentation>();

// دریافت طرح اسلاید خالی.
auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// دریافت نام تمام کاربرگ‌های موجود در کتاب‌کار اکسل.
auto worksheetNames = workbook->GetWorksheetNames();

for (auto&& name : worksheetNames)
{
    // دریافت یک دیکشنری که ایندکس‌های نمودار را به نام‌های نمودار برای کاربرگ نگاشت می‌کند.
    auto worksheetCharts = workbook->GetChartsFromWorksheet(name);

    for (auto&& chart : worksheetCharts)
    {
        // افزودن یک اسلاید جدید با استفاده از طرح خالی.
        auto slide = presentation->get_Slides()->AddEmptySlide(blankLayout);

        // وارد کردن نمودار مشخص‌شده از کتاب‌کار اکسل به مجموعهٔ شکل‌های اسلاید.
        ExcelWorkbookImporter::AddChartFromWorkbook(slide->get_Shapes(), 10.0, 10.0, workbook, name, chart.get_Key(), false);
    }
}

// ذخیرهٔ ارائهٔ حاصل در یک فایل.
presentation->Save(u"Charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **خلاصه**

این مکانیزم که به‌صورت مستقیم در Aspose.Slides در دسترس است، کار با داده‌های اکسل و ارائه‌ها را در یک مکان ترکیب می‌کند. این امکان را می‌دهد تا اسلایدهایی با نمودارهای بصری و داده‌های ارائه‌شده به شکل جداول اکسل ایجاد کنید — بدون هیچ کتابخانهٔ اضافی یا یکپارچه‌سازی پیچیده.