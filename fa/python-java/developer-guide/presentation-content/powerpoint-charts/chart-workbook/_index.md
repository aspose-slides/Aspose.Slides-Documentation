---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها با استفاده از Python via Java
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/python-java/chart-workbook/
keywords:
- کتاب‌کار نمودار
- داده‌های نمودار
- سلول کتاب‌کار
- برچسب داده
- کاربرگ
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب‌کار
- پاورپوینت
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "Aspose.Slides برای Python via Java را کشف کنید: به‌راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه کنید."
---
## **نمای کلی**

این مقاله نحوه کار با کتاب‌کارهای نموداری در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه می‌توان داده‌های نمودار را از طریق جریان‌های کتاب‌کار خواند و نوشت، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار استفاده کرد، به مجموعه‌های کاربرگی دسترسی یافت و نوع منبع داده برای مقادیر نمودار را تعیین کرد.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص داد، مسیر یک کتاب‌کار خارجی پیوسته به نمودار را بازیابی کرد و داده‌های نمودار را هنگام در دسترس بودن کتاب‌کار ویرایش کرد.

برای سلول‌های کتاب‌کاری که نمایانگر داده‌های گمشده هستند، به مقاله [Control the Display of Empty Cells](/slides/fa/python-java/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر و مقایسهٔ خطی نمایش حالت‌های مختلف را ببینید.

## **گنجاندن داده‌ها از ردیف‌ها و ستون‌های مخفی**

از متد [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) برای کنترل اینکه آیا نمودار فقط از سلول‌های قابل مشاهده یا هم از سلول‌های مخفی استفاده کند، استفاده کنید. مقدار `True` باعث می‌شود فقط سلول‌های قابل مشاهده ترسیم شوند، و مقدار `False` هر دو را شامل می‌شود. این تنظیم فقط رفتار ترسیم نمودار را کنترل می‌کند؛ ردیف‌ها یا ستون‌های کاربرگ را مخفی یا آشکار نمی‌کند.

فایل [hidden-source-data.pptx](hidden-source-data.pptx) را دانلود کنید و در پوشهٔ کاری قرار دهید. اولین اسلاید آن شامل یک نمودار ستونی به عنوان اولین شکل است. کاربرگ توکار، `Sheet1`، دارای محدوده منبع زیر است: `A1:C4`. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آنها هنوز مقدار دارند.

| ردیف کاربرگ | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

منابع سلولی را از طریق [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getChartDataWorkbook) دسترسی پیدا کنید و وضعیت مخفی بودن آنها را با [ChartDataCell.isHidden](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatacell/#isHidden) بررسی کنید. این متد وضعیت مخفی بودن را بدون تغییر آن گزارش می‌دهد. در این مثال، B2 قابل مشاهده است، B3 مربوط به ردیف مخفی است و C2 متعلق به ستون مخفی؛ مقدارهای چاپ‌شده به ترتیب `False`، `True` و `True` هستند.

برای این مثال، پس از تغییر تنظیم ترسیم، داده‌های نمودار را تازه کنید: کتاب‌کار توکار را با [readWorkbookStream](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#readWorkbookStream) دریافت کنید و آن را با [writeWorkbookStream](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#writeWorkbookStream) دوباره بارگذاری کنید. هنگام گنجاندن همهٔ سلول‌ها، از [setRange](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#setRange) برای بازیابی محدودهٔ کامل، شامل دستهٔ مخفی فوریه، استفاده کنید. فقط تغییر پرچم کافی نیست تا داده‌های کش‌شدهٔ این نمونهٔ نمودار و برچسب‌های دسته به‌روز شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # داده‌های نمودار را از کتاب‌کار توکار تازه‌سازی کنید.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # محدودهٔ منبع کامل را بازیابی کنید، شامل دسته‌های مخفی.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

این مثال فایل `hidden_cells_True.pptx` را فقط با مقادیر قابل مشاهدهٔ خرده‌فروشی (10 و 20) ذخیره می‌کند و `hidden_cells_False.pptx` را با تمام شش مقدار. تصاویر زیر دو حالت ترسیم را نشان می‌دهند. ردیف 3 و ستون C در هر دو کتاب‌کار توکار مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`True`) | همهٔ سلول‌ها (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول مخفی که حاوی مقدار است، با یک سلول خالی متفاوت است. متد [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#setDisplayBlanksAs) کنترل می‌کند که مقادیر گمشده چگونه نمایش داده شوند؛ این متد داده‌های منبع مخفی را شامل یا مستثنی نمی‌کند. برای مثال، به مقاله [Control the Display of Empty Cells](/slides/fa/python-java/chart-series/#control-the-display-of-empty-cells) رجوع کنید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides for Python via Java متدهای [readWorkbookStream](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#readWorkbookStream) و [writeWorkbookStream](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#writeWorkbookStream) را فراهم می‌کند که به شما امکان می‌دهد کتاب‌کارهای دادهٔ نمودار (شامل داده‌های ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که داده‌های نمودار باید به همان شیوه سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این مثال فایل `chart.pptx` را باز می‌کند که باید در اولین اسلایدش یک نمودار به عنوان اولین شکل داشته باشد. کتاب‌کار توکار را به یک آرایهٔ بایت می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را باز می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال فایل ارائه را ذخیره نمی‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **اعتبارسنجی چیدمان نمودار پس از تغییر کتاب‌کار**

زمانی که کتاب‌کار توکار را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شکست متد [Chart.validateChartLayout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#validateChartLayout) با خطای «index‑out‑of‑range» شود. قبل از نوشتن کتاب‌کار به‌روز شده، سری‌ها و دسته‌های موجود را پاک کنید. این مثال به `chart.pptx` با یک نمودار به عنوان اولین شکل اولین اسلاید نیاز دارد. نظرها نشان می‌دهند که ویرایش کتاب‌کار کجا انجام می‌شود؛ مثال قابل اجرا کتاب‌کار اصلی را باز می‌نویسد و چیدمان را در حافظه اعتبارسنجی می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # بایت‌های کتاب‌کار را در اینجا اصلاح کنید، به عنوان مثال با استفاده از Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

پاک‌سازی مجموعه‌ها مراجع دادهٔ منسوخ را قبل از نوشتن کتاب‌کار حذف می‌کند. قبل از استفاده از نمودار، هر نگاشت سری و دستهٔ مورد نیاز برای کتاب‌کار به‌روز شده را دوباره بسازید.

## **تنظیم یک سلول کتاب‌کار به‌عنوان برچسب دادهٔ نمودار**

می‌توانید متن سلول‌های کتاب‌کار را به‌عنوان برچسب‌های دادهٔ نمودار استفاده کنید. مراحل زیر نشان می‌دهد چگونه برچسب‌های یک نمودار حبابی را به سلول‌های کتاب‌کار دادهٔ آن متصل کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. اولین اسلاید را بر اساس شاخص صفر دریافت کنید.
1. یک نمودار حبابی با دادهٔ پیش‌فرض اضافه کنید.
1. به سری‌های نمودار دسترسی پیدا کنید.
1. سلول کتاب‌کار را به‌عنوان برچسب داده تنظیم کنید.
1. ارائه را ذخیره کنید.

این مثال فایل `chart2.pptx` را باز می‌کند که باید حداقل یک اسلاید داشته باشد و یک نمودار حبابی با دادهٔ پیش‌فرض اضافه می‌کند. از سلول‌های A10:A12 در کاربرگ 0 برای سه برچسب اول سری اول استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌کند و نتیجه را در `resultchart.pptx` ذخیره می‌نماید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)

    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **مدیریت کاربرگ‌ها**

متد [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/#getWorksheets) دسترسی به کاربرگ‌های یک کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با دادهٔ پیش‌فرض ایجاد می‌کند و نام هر کاربرگ را در کنسول چاپ می‌نماید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **مشخص‌کردن نوع منبع داده**

این مثال یک نمودار ستونی سه‌بعدی با دادهٔ پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع داده متفاوت تنظیم می‌نماید. نام اول از یک رشتهٔ ثابت استفاده می‌کند؛ نام دوم از سلول C1 در کاربرگ 0 می‌گیرد. شمارش‌گر [DataSourceType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/datasourcetype/) منبع هر نام را انتخاب می‌کند. نتیجه در `pres.pptx` ذخیره می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تشخیص قالب‌های کتاب‌کار توکار پشتیبانی‌نشده**

Aspose.Slides از قالب کتاب‌کار باینری اکسل (.xlsb) که می‌تواند در برخی نمودارها توکار باشد، پشتیبانی نمی‌کند. می‌توانید با استفاده از متد [getEmbeddedWorkbookType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) بر روی [ChartData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/) همراه با شمارش‌گر [WorkbookType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/workbooktype/) قالب‌های پشتیبانی‌نشده را شناسایی و آن نمودارها را نادیده بگیرید. این مثال اشکال موجود در اولین اسلاید `sample.pptx` را بررسی می‌کند، اشکال غیرنموداری را رد می‌کند و برای هر نمودار دارای کتاب‌کار .xlsb یک پیام تشخیص خطا چاپ می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        chart_data = shape.getChartData()

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # خواندن یا اصلاح داده‌های کتاب‌کار نمودار پشتیبانی‌شده در اینجا.
finally:
    presentation.dispose()
```

## **کتاب‌کار خارجی**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به‌عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از متدهای [readWorkbookStream](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#readWorkbookStream) و [setExternalWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#setExternalWorkbook) برای استخراج کتاب‌کار توکار یک نمودار به فایل و پیوند نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با دادهٔ پیش‌فرض ایجاد می‌کند، کتاب‌کار آن را در `externalWorkbook1.xlsx` می‌نویسد و قبل از اختصاص فایل به عنوان منبع دادهٔ نمودار عملیات نوشتن را کامل می‌کند. ارائهٔ پیوندشده در `externalWorkbook.pptx` ذخیره می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **تنظیم یک کتاب‌کار خارجی**

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#setExternalWorkbook) می‌توانید یک کتاب‌کار خارجی را به‌عنوان منبع دادهٔ یک نمودار اختصاص دهید. این متد همچنین می‌تواند مسیر کتاب‌کار خارجی را به‌روز کند (اگر کتاب‌کار جابه‌جا شده باشد).

اگرچه نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌های دوردست یا منابع را مستقیم ویرایش کنید، می‌توانید همچنان از چنین کتاب‌کارهایی به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌طور خودکار به مسیر کامل تبدیل می‌گردد.

این مثال به `externalWorkbook.xlsx` در پوشهٔ کاری نیاز دارد. کاربرگ `Sheet1` باید شامل یک نام سری در B1، نام‌های دسته در A2:A4 و مقادیر عددی در B2:B4 باشد. مثال یک نمودار دایره‌ای ایجاد می‌کند، کتاب‌کار را پیوند می‌دهد و از [setRange](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#setRange) برای نگاشت A1:B4 به یک سری و سه دسته استفاده می‌کند. نتیجه در `Presentation_with_externalWorkbook.pptx` ذخیره می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

پارامتر `updateChartData` متد [setExternalWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#setExternalWorkbook) تعیین می‌کند که آیا کتاب‌کار بارگیری شود یا نه.

* وقتی `updateChartData` برابر `False` باشد، فقط مسیر کتاب‌کار به‌روز می‌شود. داده‌های نمودار از کتاب‌کار هدف بارگیری یا به‌روز نمی‌شوند، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
* وقتی `updateChartData` برابر `True` باشد، داده‌های نمودار از کتاب‌کار هدف به‌روز می‌شوند.

مثال زیر یک URL جایگزین را با `updateChartData` برابر `False` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شود و ارائه بدون بارگیری کتاب‌کار در دسترس ذخیره می‌گردد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **دریافت مسیر کتاب‌کار منبع دادهٔ خارجی یک نمودار**

برای شناسایی کتاب‌کاری که به یک نمودار پیوند دارد، ابتدا بررسی کنید که آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند یا نه. اگر چنین باشد، می‌توانید مسیر کتاب‌کار را با انجام مراحل زیر بازیابی کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. اولین اسلاید را بر اساس شاخص صفر دریافت کنید.
1. بررسی کنید که اولین شکل یک نمودار باشد.
1. نوع منبع دادهٔ نمودار را بخوانید.
1. اگر منبع یک کتاب‌کار خارجی باشد، مسیر آن را بخوانید.

این مثال فایل `externalWorkbook.pptx` را که در مثال قبلی ایجاد شده است باز می‌کند و اولین شکل در اولین اسلاید را بررسی می‌نماید. اگر نمودار به یک کتاب‌کار خارجی پیوند داشته باشد، متد [getExternalWorkbookPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) را در کنسول چاپ می‌کند. سپس یک نسخهٔ از ارائه را در `Result.pptx` ذخیره می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ویرایش داده‌های نمودار**

می‌توانید داده‌های کتاب‌کارهای خارجی را به همان شیوه‌ای که محتویات کتاب‌کارهای داخلی را تغییر می‌دهید، ویرایش کنید. وقتی کتاب‌کار خارجی قابل بارگیری نباشد، استثنایی صادر می‌شود.

این مثال به `presentation.pptx` با یک نمودار به عنوان اولین شکل اولین اسلاید و یک کتاب‌کار خارجی قابل دسترس نیاز دارد. مقدار نقطهٔ دادهٔ اول در سری اول را به 100 تنظیم می‌کند و ارائه را در `presentation_out.pptx` ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX مرتبط را به‌روز کند، بنابراین در صورت نیاز به حفظ کتاب‌کار اصلی از یک نسخهٔ کپی استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **بازیابی کتاب‌کار از کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی که موجود نیست یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. ابتدا یک شیء [LoadOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/) ایجاد کنید، متد [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) را فراخوانی کنید و قبل از باز کردن ارائه، [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) را روی `True` تنظیم کنید.

مثال زیر در پایتون فایل `presentation.pptx` را باز می‌کند که اولین شکل در اولین اسلاید باید یک نمودار باشد که به یک کتاب‌کار خارجی غیربازدارد ارجاع می‌دهد، و داده‌های بازیابی‌شده را از طریق [Chart.getChartData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#getChartData) و [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getChartDataWorkbook) دسترسی پیدا می‌کند:

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # داده‌های کتاب‌کار بازیابی‌شده را در اینجا بخوانید یا اصلاح کنید.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

اگر کتاب‌کار خارجی غیرباز باشد و بازیابی فعال نباشد، Aspose.Slides استثنا می‌اندازد. بازیابی را فقط زمانی فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ پذیرفتنی باشد، زیرا کش ممکن است شامل تغییرات اعمال‌شده بر کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه نباشد.

## **سوالات متداول**

**آیا می‌توانم تشخیص دهم که یک نمودار خاص به کتاب‌کار خارجی یا توکار پیوند دارد؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getDataSourceType) و [path to an external workbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا اطمینان حاصل کنید فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌طور خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابجایی کتاب‌کار ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از کتاب‌کارهایی که در منابع/به اشتراک‌گذاری‌های شبکه قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای دوردست از Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه فقط یک [link to the external file](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) را ذخیره می‌کند. ویرایش داده‌های نمودار بر پایهٔ سلول می‌تواند فایل XLSX محلی مرتبط را به‌روز کند. اگر فایل اصلی باید بدون تغییر باقی بماند، از یک کپی از کتاب‌کار استفاده کنید.

**اگر فایل خارجی رمز عبور داشته باشد، چه کاری باید انجام دهم؟**

Aspose.Slides هنگام پیوندگیری رمز عبوری نمی‌پذیرد. یک روش معمول این است که پیش از استفاده حفاظت را حذف کنید یا یک نسخهٔ رمزشکسته (مثلاً با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) تهیه کنید و به آن پیوند دهید.

**آیا چندین نمودار می‌توانند به همان کتاب‌کار خارجی ارجاع دهند؟**

بله. هر نمودار پیوند خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگیری داده‌ها در تمام نمودارها منعکس می‌شود.