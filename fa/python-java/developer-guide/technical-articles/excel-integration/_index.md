---
title: یکپارچه‌سازی داده‌های اکسل در ارائه‌های PowerPoint
linktitle: یکپارچه‌سازی اکسل
type: docs
weight: 330
url: /fa/python-java/excel-integration/
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
- Python
- Java
- Aspose.Slides
description: "داده‌ها را از کتاب‌کارهای اکسل در Aspose.Slides برای Python از طریق Java با استفاده از API ExcelDataWorkbook بخوانید. شیت‌ها و سلول‌ها را بارگذاری کنید و از مقادیر آنها برای تولید ارائه‌های PowerPoint مبتنی بر داده استفاده کنید."
---
## **معرفی**

ارائه‌های PowerPoint روشی قدرتمند برای نمایش و انتقال اطلاعات هستند. این ارائه‌ها اغلب همراه با کتاب‌کارهای Excel استفاده می‌شوند، که در آن Excel منبع ساختارمند داده‌هاست و PowerPoint توانایی تجسم این داده‌ها برای مخاطب را دارد.

سناریوهای عملی متعددی وجود دارد که ترکیب Excel و PowerPoint در آنها ضروری است: ادغام نامه‌ها، پر کردن جداول داده‌ای، تولید اسلایدی برای هر رکورد داده (تولید دسته‌ای اسلاید)، ایجاد مطالب آموزشی، و تجمیع چندین گزارش Excel در یک ارائه، تنها به چند مثال اشاره می‌کنیم.

تا کنون پیاده‌سازی چنین ویژگی‌هایی با API Aspose.Slides نیاز به اتکای بر راه‌حل‌های شخص ثالث مانند Aspose.Cells داشت. اگرچه این ابزارها قدرتمندند، اما برای کاربرانی که فقط به عملکرد پایهٔ یکپارچه‌سازی داده‌ها نیاز دارند، می‌توانند بیش از حد پیچیده و پرهزینه باشند.

## **نحوه کار**

برای آسان‌تر و یکنواخت‌تر کردن کار با داده‌های Excel، Aspose.Slides کلاس‌های جدیدی برای خواندن داده‌ها از کتاب‌کارهای Excel و وارد کردن محتوا به یک ارائه معرفی کرده است. این ویژگی امکانات جدیدی را برای کاربران API که می‌خواهند از Excel به عنوان منبع داده در جریان‌کارهای ارائه خود استفاده کنند، فراهم می‌کند.

این کارکرد جدید برای دسترسی عمومی به داده‌ها طراحی شده و در مدل شیئی سند ارائه (DOM) ادغام نشده است. به این معنی که *اجازهٔ ویرایش یا ذخیرهٔ فایل‌های Excel را نمی‌دهد* — هدف تنها باز کردن کتاب‌کارها و جستجو در محتوای آنها برای دریافت دادهٔ سلول‌هاست.

در هستهٔ این ویژگی، کلاس جدید [ExcelDataWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/exceldataworkbook/) قرار دارد. این کلاس امکان بارگذاری یک کتاب‌کار Excel از فایل محلی یا یک جریان را فراهم می‌کند. پس از بارگذاری، چندین overload از متد [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/fa/python-java/aspose.slides/exceldataworkbook/#getCell) در اختیار شماست که می‌توانید برای بازیابی سلول‌های خاص بر اساس موقعیت‌شان (مثلاً اندیس‌های ردیف و ستون یا بازه‌های نام‌گذاری‌شده) از آنها استفاده کنید.

هر فراخوانی به [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/fa/python-java/aspose.slides/exceldataworkbook/#getCell) یک شیء [ExcelDataCell](https://reference.aspose.com/slides/fa/python-java/aspose.slides/exceldatacell/) برمی‌گرداند. این شیء نمایانگر یک سلول منفرد در کتاب‌کار Excel است و دسترسی ساده و شهودی به مقدار آن را فراهم می‌کند.

#### **وارد کردن نمودار Excel**

گام بعدی برای گسترش کارکرد، کلاس [ExcelWorkbookImporter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/excelworkbookimporter/) است. این کلاس کمکی قابلیت وارد کردن محتوا از یک کتاب‌کار Excel به یک ارائه را فراهم می‌کند. این کلاس چند overload از متد [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) دارد که به شما کمک می‌کند نمودار انتخابی را از کتاب‌کار Excel مشخص شده دریافت کرده و در انتهای مجموعهٔ اشکال داده‌شده، در مختصات مشخص‌شده اضافه کنید.

#### **وارد کردن جدول Excel**

کلاس [ExcelWorkbookImporter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/excelworkbookimporter/) همچنین چند overload از متد [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook) دارد. این متدها به شما اجازه می‌دهند بازهٔ سلولی مشخصی را از کاربرگ مشخص‌شده وارد کرده و به عنوان یک جدول در انتهای مجموعهٔ اشکال داده‌شده، در مختصات مشخص‌شده اضافه کنید.

به‌عبارت دیگر، این یک API سبک و ساده برای خواندن داده‌های Excel است — دقیقاً همان چیزی که بسیاری از توسعه‌دهندگان بدون بار اضافی یک کتابخانهٔ کامل پردازش صفحه‌گسترده به آن نیاز دارند.

## **بیایید کد بنویسیم**

### **مثال سناریوی ادغام نامه**

در مثال زیر، یک سناریوی سادهٔ ادغام نامه را با تولید چندین ارائه بر پایهٔ داده‌های ذخیره‌شده در یک کتاب‌کار Excel پیاده‌سازی می‌کنیم.

برای شروع، به دو مورد نیاز داریم:

1. یک کتاب‌کار Excel حاوی داده‌ها

![Excel data example](example1_image0.png)

2. یک قالب ارائه PowerPoint

![PowerPoint template example](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# بارگذاری کتاب‌کار اکسل حاوی داده‌های کارمندان.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# بارگذاری قالب ارائه.
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # تکرار بر روی ردیف‌های اکسل (به‌جز سرصفحه در ردیف 0).
    for row_index in range(1, 5):

        # ایجاد یک ارائه برای هر رکورد کارمند.
        employee_presentation = Presentation()

        try:
            # حذف اسلاید خالی پیش‌فرض.
            employee_presentation.getSlides().removeAt(0)

            # کپی‌کردن اسلاید قالب به داخل ارائه.
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # دریافت پاراگراف‌ها از شکل هدف (فرض می‌کند ایندکس شکل 1 استفاده شده است).
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # جایگزینی جای‌گیرها با داده‌های اکسل.
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # ذخیرهٔ ارائه شخصی‌سازی‌شده در یک فایل جداگانه.
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![Result](example1_image2.png)

### **مثال جدول Excel**

در مثال دوم، به‌سادگی داده‌ها را از یک جدول Excel کپی می‌کنیم و آنها را در یک اسلاید PowerPoint به شکلی بصری‌تر نمایش می‌دهیم.

در این مثال، همان کتاب‌کار Excel اولین مثال را مجدداً استفاده می‌کنیم که شامل یک جدول سادهٔ کارمندان است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# بارگذاری کتاب‌کار اکسل حاوی داده‌های کارمندان.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# ایجاد یک ارائه PowerPoint.
presentation = Presentation()

try:
    # افزودن یک شکل جدول به اسلاید اول.
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # پر کردن جدول PowerPoint با داده‌های کتاب‌کار اکسل.
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # ذخیرهٔ ارائه نهایی در یک فایل.
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example2_image0.png)

### **مثال وارد کردن نمودار Excel**

در این مثال، یک نمودار را از کاربرگ اول کتاب‌کار Excel استفاده‌شده در مثال قبلی وارد می‌کنیم. این نمودار در ارائهٔ نهایی به کتاب‌کار خارجی لینک می‌شود.

ابتدا، یک نمودار دایره‌ای بر پایهٔ جدول کارمندان به کتاب‌کار Excel اضافه می‌کنیم.

![Excel Chart example](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# یک ارائه PowerPoint ایجاد کنید.
presentation = Presentation()
try:
    # دریافت مجموعهٔ اشکال اسلاید اول.
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # نقشه‌ای با نام "Chart 1" را از اولین شیت کتاب‌کار وارد کرده و به مجموعهٔ اشکال اضافه کنید.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # ارائهٔ حاصل را در یک فایل ذخیره کنید.
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example3_image1.png)

### **مثال وارد کردن همه نمودارهای Excel**

فرض کنید یک کتاب‌کار Excel پر از نمودار دارید و می‌خواهید همهٔ آنها را به یک ارائه وارد کنید. هر نمودار باید در یک اسلاید جدید قرار گیرد.

کد زیر تمام کاربرگ‌های فایل Excel منبع را می‌گرداند، نمودارهای هر کاربرگ را استخراج می‌کند و هر نمودار را با استفاده از یک طرح اسلاید خالی به یک اسلاید جداگانه اضافه می‌کند. در ارائهٔ نهایی، فقط دادهٔ نمودارها جاسازی می‌شوند، نه کل کتاب‌کار.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# بارگذاری کتاب‌کار اکسل حاوی داده‌های کارمندان.
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# یک ارائه PowerPoint ایجاد کنید.
presentation = Presentation()
try:
    # دست‌رسی به طرح اسلاید خالی.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # اسلاید پیش‌فرض را حذف کنید تا نتیجه شامل یک اسلاید برای هر نمودار باشد.
    presentation.getSlides().removeAt(0)

    # دریافت نام‌های تمامی ورق‌های کتاب‌کار اکسل.
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # دریافت نقشه‌ای که ایندکس‌های نمودار را به نام‌های نمودار برای ورق مرتبط می‌کند.
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # اضافه کردن اسلاید با استفاده از طرح خالی.
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # وارد کردن نمودار مشخص‌شده از کتاب‌کار اکسل به مجموعهٔ اشکال اسلاید.
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # ذخیرهٔ ارائهٔ نهایی در یک فایل.
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **مثال وارد کردن جدول Excel**

در این مثال، یک جدول قالب‌بندی‌شده را مستقیم از یک کاربرگ Excel به یک ارائه PowerPoint وارد می‌کنیم.

کاربرگ Excel منبع شامل یک جدول قالب‌بندی‌شده با داده‌های کارمندان است:

![Excel Table example](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# یک ارائه PowerPoint ایجاد کنید.
presentation = Presentation()
try:
    # دریافت اولین اسلاید و مجموعهٔ اشکال آن.
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # وارد کردن جدول از اولین شیت کتاب‌کار و افزودن آن به مجموعهٔ اشکال.
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # ذخیرهٔ ارائهٔ حاصل در یک فایل.
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example4_image1.png)

## **خلاصه**

این مکانیزم که مستقیماً در Aspose.Slides موجود است، کار با داده‌های Excel و ارائه‌ها را در یک جا ترکیب می‌کند. این امکان را می‌دهد تا اسلایدهایی با نمودارهای بصری و داده‌های ارائه‌شده به شکل جداول Excel ایجاد کنید—بدون نیاز به کتابخانه‌های اضافی یا ادغام‌های پیچیده.