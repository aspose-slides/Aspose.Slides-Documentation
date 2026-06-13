---
title: ادغام داده‌های Excel در ارائه‌های PowerPoint
linktitle: ادغام Excel
type: docs
weight: 330
url: /fa/python-net/excel-integration/
keywords:
- Excel
- دفتر کاری
- خواندن Excel
- ادغام Excel
- منبع داده
- ادغام ایمیل
- وارد کردن جدول
- Excel به PowerPoint
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "داده‌ها را از دفترهای کاری Excel در Aspose.Slides با استفاده از API ExcelDataWorkbook بخوانید. شیت‌ها و سلول‌ها را بارگذاری کنید و از مقادیر آن‌ها برای تولید ارائه‌های PowerPoint مبتنی بر داده استفاده کنید."
---
## **معرفی**

ارائه‌های PowerPoint روشی قدرتمند برای نمایش و انتقال اطلاعات هستند. این ارائه‌ها اغلب همراه با کتاب‌های کار Excel استفاده می‌شوند، جایی که Excel منبع عالی داده‌های ساختاریافته است و PowerPoint در تجسم آن داده‌ها برای مخاطب بسیار موثر است.

سناریوهای عملی متعددی وجود دارد که ترکیب Excel و PowerPoint در آن‌ها ضروری است: ادغام ایمیل‌ها، پر کردن جداول داده‌ها، تولید یک اسلاید برای هر رکورد داده (تولید انبوه اسلاید)، ایجاد مواد آموزشی، و ادغام چندین گزارش Excel در یک ارائه، تنها به چند مورد اشاره شد.

تا به‌حال، پیاده‌سازی چنین ویژگی‌هایی با API Aspose.Slides نیازمند اتکا به راه‌حل‌های شخص ثالثی مانند Aspose.Cells بود. اگرچه این ابزارها قوی هستند، می‌توانند برای کاربرانی که فقط به عملکرد پایه یکپارچه‌سازی داده نیاز دارند، بیش از حد پیچیده و هزینه‌بر باشند.

## **نحوه کارکرد**

برای ساده‌تر و کارآمدتر کردن کار با داده‌های Excel، Aspose.Slides کلاس‌های جدیدی برای خواندن داده‌ها از کتاب‌های کار Excel و وارد کردن محتوا به یک ارائه معرفی کرده است. این قابلیت امکانات جدیدی را برای کاربران API فراهم می‌کند تا بتوانند از Excel به عنوان منبع داده در جریان کارهای ارائه خود استفاده کنند.

عملکرد جدید برای دسترسی عمومی به داده‌ها طراحی شده و درون مدل شیء سند ارائه (Presentation Document Object Model) ادغام نشده است. به این معنا که *امکان ویرایش یا ذخیره فایل‌های Excel را فراهم نمی‌کند* — هدف sole آن باز کردن کتاب‌های کار و مرور محتوا برای استخراج داده‌های سلولی است.

در قلب این ویژگی، کلاس جدید [ExcelDataWorkbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.excel/exceldataworkbook/) قرار دارد. این کلاس به شما امکان می‌دهد یک کتاب کار Excel را از فایل محلی یا یک جریان (stream) بارگذاری کنید. پس از بارگذاری، چندین overload از متد [get_cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) در اختیار شماست که می‌توانید برای بازیابی سلول‌های خاص بر اساس موقعیت‌شان (مثلاً اندیس‌های ردیف و ستون یا محدوده‌های نام‌گذاری شده) استفاده کنید.

هر فراخوانی به [get_cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) یک نمونه از کلاس [ExcelDataCell](https://reference.aspose.com/slides/fa/python-net/aspose.slides.excel/exceldatacell/) را بر می‌گرداند. این شیء نمایانگر یک سلول منفرد در کتاب کار Excel بوده و دسترسی ساده و شهودی به مقدار آن را فراهم می‌کند.

#### **وارد کردن نمودار Excel**

مرحله بعدی برای گسترش قابلیت‌ها، کلاس [ExcelWorkbookImporter](https://reference.aspose.com/slides/fa/python-net/aspose.slides.importing/excelworkbookimporter/) است. این کلاس کمکی عملکردی برای وارد کردن محتوا از یک کتاب کار Excel به یک ارائه ارائه می‌دهد. این کلاس شامل چند overload از متد [add_chart_from_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.importing/excelworkbookimporter/add_chart_from_workbook/) است که به شما کمک می‌کند نمودار انتخاب‌شده را از کتاب کار Excel مشخص استخراج کرده و در انتهای مجموعه شکل‌های داده‌شده، در مختصات مشخص قرار دهید.

به طور خلاصه، این یک API سبک و سرراست برای خواندن داده‌های Excel است — دقیقا همان چیزی که بسیاری از توسعه‌دهندگان بدون بار اضافی یک کتابخانه پردازش کامل صفحات گسترده نیاز دارند.

## **بیایید کد بزنیم**

### **مثال سناریوی ادغام ایمیل (Mail Merge)**

در مثال زیر، یک سناریوی ساده ادغام ایمیل را با تولید چندین ارائه بر پایه داده‌های ذخیره‌شده در یک کتاب کار Excel پیاده‌سازی خواهیم کرد.

برای شروع، به دو مورد نیاز داریم:
1. یک دفتر کار Excel شامل داده‌ها

![مثال داده‌های Excel](example1_image0.png)

2. الگوی ارائه PowerPoint

![مثال الگوی PowerPoint](example1_image1.png)

```py
import aspose.slides as slides

# بارگذاری دفتر کار Excel با داده‌های کارمند.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# بارگذاری الگوی ارائه.
with slides.Presentation("PresentationTemplate.pptx") as template_presentation:

    # مرور ردیف‌های Excel (به‌جز سربرگ در ردیف 0).
    for row_index in range(1, 5):

        # ایجاد یک ارائه جدید برای هر رکورد کارمند.
        with slides.Presentation() as employee_presentation:

            # حذف اسلاید خالی پیش‌فرض.
            employee_presentation.slides.remove_at(0)

            # کلون کردن اسلاید الگو به داخل ارائه جدید.
            slide = employee_presentation.slides.add_clone(template_presentation.slides[0])

            # دریافت پاراگراف‌ها از شکل هدف (فرض می‌کند اندیس شکل 1 استفاده می‌شود).
            paragraphs = slide.shapes[1].text_frame.paragraphs

            # جایگزینی متغیرهای جایگزین با داده‌های Excel.
            employee_name = workbook.get_cell(worksheet_index, row_index, 0).value
            name_portion = paragraphs[0].portions[0]
            name_portion.text = name_portion.text.replace("{{EmployeeName}}", employee_name)

            department = workbook.get_cell(worksheet_index, row_index, 1).value
            department_portion = paragraphs[1].portions[0]
            department_portion.text = department_portion.text.replace("{{Department}}", department)

            years_of_service = str(workbook.get_cell(worksheet_index, row_index, 2).value)
            years_portion = paragraphs[2].portions[0]
            years_portion.text = years_portion.text.replace("{{YearsOfService}}", years_of_service)

            # ذخیره ارائه شخصی‌سازی‌شده به یک فایل جداگانه.
            employee_presentation.save(f"{employee_name} Report.pptx", slides.export.SaveFormat.PPTX)
```

![نتیجه](example1_image2.png)

### **مثال جدول Excel**

در مثال دوم، به سادگی داده‌ها را از یک جدول Excel کپی کرده و در یک اسلاید PowerPoint به شکلی بصری‌تر نمایش می‌دهیم.

در این مثال، همان دفتر کار Excel را که در مثال اول استفاده شد، که شامل یک جدول ساده کارمندان است، دوباره به کار می‌بریم.

```py
# بارگذاری دفتر کار Excel که شامل داده‌های کارمند است.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# ایجاد یک ارائه PowerPoint جدید.
with slides.Presentation() as presentation:

    # افزودن یک شکل جدول به اسلاید اول.
    table = presentation.slides[0].shapes.add_table(
        50, 200,
        [200, 200, 200],
        [30, 30, 30, 30, 30]
    )

    # پر کردن جدول PowerPoint با داده‌های دفتر کار Excel.
    for row_index in range(0, 5):
        for column_index in range(0, 3):
            cell_value = str(workbook.get_cell(worksheet_index, row_index, column_index).value)
            table.columns[column_index][row_index].text_frame.text = cell_value

    # ذخیره ارائه حاصل در یک فایل.
    presentation.save("Table.pptx", slides.export.SaveFormat.PPTX)
```

![نتیجه](example2_image0.png)

### **مثال وارد کردن نمودار Excel**

در این مثال، یک نمودار را از اولین برگه کتاب کار Excel که در مثال قبلی استفاده شد، وارد می‌کنیم. نمودار در ارائه نهایی به کتاب کار خارجی لینک خواهد شد.

ابتدا یک نمودار دایره‌ای (Pie) به کتاب کار Excel بر پایه جدول کارمندان اضافه می‌کنیم.

![مثال نمودار Excel](example3_image0.png)

```py
# ایجاد یک ارائه PowerPoint جدید.
with slides.Presentation() as presentation:
    # دریافت مجموعه شکل‌ها از اسلاید اول.
    shapes = presentation.slides[0].shapes

    # وارد کردن نمودار با نام "Chart 1" از اولین شیت دفتر کار و افزودن آن به مجموعه شکل‌ها.
    slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
        shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # ذخیره ارائه حاصل در یک فایل.
    presentation.save("Chart.pptx", slides.export.SaveFormat.PPTX)
```

![نتیجه](example3_image1.png)

### **مثال وارد کردن همه نمودارهای Excel**

تصور کنید یک دفتر کار Excel پر از نمودار دارید و می‌خواهید همه آن‌ها را به یک ارائه وارد کنید. هر نمودار باید در یک اسلاید جدید قرار گیرد.

کد زیر تمام برگه‌های فایل Excel منبع را مرور می‌کند، نمودارها را از هر برگه استخراج می‌کند و هر نمودار را با استفاده از یک طرح اسلاید خالی به اسلاید جداگانه‌ای اضافه می‌کند. در ارائه نهایی، تنها داده‌های نمودارها تعبیه می‌شوند، نه کل دفتر کار.

```py
# بارگذاری دفتر کار Excel که شامل داده‌های کارمند است.
workbook = slides.excel.ExcelDataWorkbook("ExcelWithCharts.xlsx")

# ایجاد یک ارائه PowerPoint جدید.
with slides.Presentation() as presentation:
    # دریافت طرح اسلاید خالی.
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # دریافت نام تمام ورق‌های کار موجود در دفتر کار Excel.
    worksheet_names = workbook.get_worksheet_names()

    for name in worksheet_names:
        # دریافت دیکشنری‌ای که ایندکس‌های نمودار را به نام‌های آن‌ها برای ورق کار mapping می‌کند.
        worksheet_charts = workbook.get_charts_from_worksheet(name)
        
        for chart in worksheet_charts:
            # افزودن اسلاید جدید با استفاده از طرح خالی.
            slide = presentation.slides.add_empty_slide(blank_layout)

            # وارد کردن نمودار مشخص شده از دفتر کار Excel به مجموعه شکل‌های اسلاید.
            slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
                slide.shapes, 10, 10, workbook, name, chart.key, False)

    # ذخیره ارائه حاصل در یک فایل.
    presentation.save("Charts.pptx", slides.export.SaveFormat.PPTX)
```

## **خلاصه**

این مکانیزم که به‌صورت مستقیم در Aspose.Slides موجود است، کار با داده‌های Excel و ارائه‌ها را در یک مکان ترکیب می‌کند. این امکان را می‌دهد تا اسلایدهایی با نمودارهای بصری و داده‌های ارائه‌شده به شکل جداول Excel ایجاد کنید — بدون نیاز به کتابخانه‌های اضافی یا ادغام‌های پیچیده.