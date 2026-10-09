---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها با استفاده از Python via Java
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/python-java/chart-workbook/
keywords:
- کتاب‌کار نمودار
- دادهٔ نمودار
- سلول کتاب‌کار
- برچسب داده
- کاربرگ
- منبع داده
- کتاب‌کار خارجی
- دادهٔ خارجی
- کش نمودار
- بازیابی کتاب‌کار
- PowerPoint
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "Aspose.Slides برای Python via Java را کشف کنید: به راحتی کتاب‌کارهای نمودار را در قالب‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائهٔ خود را بهینه‌سازی کنید."
---
## **بررسی کلی**

این مقاله نحوه کار با کتاب‌کارهای نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه می‌توان داده‌های نمودار را از طریق جریان‌های کتاب‌کار خواند و نوشت، از سلول‌های کتاب‌کار به عنوان برچسب داده‌های نمودار استفاده کرد، به مجموعه‌های ورق‌های کاری دسترسی پیدا کرد و نوع منبع داده برای مقادیر نمودار را مشخص کرد.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع دادهٔ نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص داده می‌شود، مسیر یک کتاب‌کار خارجی متصل به نمودار بازیابی می‌شود و داده‌های نمودار زمانی که کتاب‌کار در دسترس است، ویرایش می‌شود.

برای سلول‌های کتاب‌کاری که نمایانگر داده‌های گمشده هستند، به [Control the Display of Empty Cells](/slides/fa/python-java/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر، و مقایسهٔ نمودار خطی حالت‌های نمایش موجود را ببینید.

## **شمول داده‌ها از سطرها و ستون‌های مخفی**

از [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) برای کنترل اینکه آیا یک نمودار داده‌ها را از سطرها و ستون‌های مخفی کاربرگ ترسیم می‌کند یا نه استفاده کنید. مقدار `True` فقط سلول‌های قابل مشاهده را ترسیم می‌کند، یا `False` برای شامل کردن هر دو سلول قابل مشاهده و مخفی. این تنظیم فقط ترسیم نمودار را کنترل می‌کند؛ سطرها یا ستون‌های کاربرگ را مخفی یا نمایان نمی‌کند.

[نمونهٔ ارائه](hidden-source-data.pptx) شامل یک نمودار ستونی به عنوان اولین شکل در اولین اسلاید آن است. کاربرگ توکار، `Sheet1`، بازهٔ منبع زیر را دارد: `A1:C4`. سطر 3 و ستون C مخفی هستند، اما سلول‌های آن‌ها هنوز مقدار دارند.

| سطر کاربرگ | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (سطر مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) دسترسی داشته باشید و با خواندن [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) وضعیت مخفی بودن آن‌ها را بررسی کنید. این روش وضعیت مخفی بودن را بدون تغییر آن گزارش می‌دهد. در این فایل، B2 قابل مشاهده است، B3 متعلق به سطر مخفی است و C2 متعلق به ستون مخفی؛ مثال مقادیر `False`، `True` و `True` را به ترتیب چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم ترسیم، دادهٔ نمودار را تازه‌سازی کنید: کتاب‌کار توکار را با [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) نگه‌دارید و با [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) دوباره بارگذاری کنید. هنگام شمول تمام سلول‌ها، همچنین از [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) برای بازیابی بازهٔ کامل، شامل دستهٔ مخفی فوریه، استفاده کنید. تنها تغییر پرچم برای تازه‌سازی داده‌های کش‌شدهٔ نمونهٔ این نمودار و برچسب‌های دسته کافی نیست.

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
                # بازگرداندن بازهٔ منبع کامل، شامل دسته‌های مخفی.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

مثال دو نسخه از ارائه را ذخیره می‌کند: یکی فقط با مقادیر خرده‌فروشی قابل مشاهده (10 و 20) و دیگری با تمام شش مقدار. تصاویر زیر دو حالت ترسیم را نشان می‌دهند. سطر 3 و ستون C در هر دو کتاب‌کار توکار مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`True`) | تمام سلول‌ها (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول مخفی حاوی مقدار، متفاوت از یک سلول خالی است. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) کنترل می‌کند مقادیر گمشده چگونه نمایش داده شوند؛ این تنظیم شامل یا حذف داده‌های منبع مخفی نمی‌شود. برای مثال به [Control the Display of Empty Cells](/slides/fa/python-java/chart-series/#control-the-display-of-empty-cells) نگاه کنید.

## **بازیابی بازهٔ دادهٔ یک نمودار**

قبل از به‌روزرسانی داده‌های کتاب‌کار در یک ارائهٔ موجود، بازه‌های منبع را بررسی کنید تا مشخص شود هر نمودار از کدام سلول‌های کاربرگ استفاده می‌کند. متد [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) بازهٔ دادهٔ جاری را به صورت فرمولی با مشخصات کاربرگ برمی‌گرداند، مانند `Sheet1!$A$1:$D$5`. در اینجا، `Sheet1` نام کاربرگ است، `!` آن را از بازهٔ سلول‌ها جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را شامل می‌شود. علامت‌های دلار به ارجاع مطلق سطر و ستون اشاره دارند.

این متد بازهٔ جاری را بدون تغییر نمودار یا کتاب‌کار می‌خواند. اگر نمودار از کتاب‌کاری به عنوان منبع داده استفاده نکند، `InvalidOperationException` پرتاب می‌شود. برای اطلاعات بیشتر به [ChartData API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) مراجعه کنید.

این مثال یک ارائه را باز می‌کند و شکل‌های هر اسلاید را مستقیم برای نمودارها بررسی می‌کند. نام هر نمودار و بازهٔ منبع آن را چاپ می‌کند. اگر نموداری از کتاب‌کار استفاده نکند، پیام مربوطه را چاپ کرده و به نمودار بعدی ادامه می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **خواندن و نوشتن دادهٔ نمودار از یک کتاب‌کار**

Aspose.Slides for Python via Java متدهای [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) و [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) را فراهم می‌کند که به شما امکان می‌دهد کتاب‌کارهای دادهٔ نمودار (شامل داده‌های ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که دادهٔ نمودار باید به همان شکل یا ساختار مشابه منبع سازماندهی شود.

این مثال یک ارائه با یک نمودار به عنوان اولین شکل در اولین اسلاید آن استفاده می‌کند. کتاب‌کار توکار را به یک آرایهٔ بایت می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را باز می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال فایل ارائه را ذخیره نمی‌کند.

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

### **اعتبارسنجی چینش نمودار پس از اصلاح کتاب‌کار**

زمانی که یک کتاب‌کار توکار را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) با خطای «index‑out‑of‑range» مواجه شود. قبل از نوشتن کتاب‌کار به‌روزرسانی‌شده به نمودار، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک نمودار که اولین شکل در اولین اسلاید است استفاده می‌کند. کامنت نشان می‌دهد که ویرایش کتاب‌کار در کجا انجام می‌شود؛ مثال قابل اجرا کتاب‌کار اصلی را باز می‌نویسد و چینش را در حافظه اعتبارسنجی می‌کند.

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

        # دیتای بایت کتاب‌کار را اینجا تغییر دهید، برای مثال با استفاده از Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

پاک‌سازی مجموعه‌ها مراجع داده‌های منقضی‌شده را پیش از نوشتن کتاب‌کار حذف می‌کند. پیش از استفاده از نمودار، سری‌ها و نگاشت‌های دستهٔ موردنیاز برای کتاب‌کار به‌روزرسانی‌شده را بازسازی کنید.

## **تنظیم یک سلول کتاب‌کار به عنوان برچسب دادهٔ نمودار**

می‌توانید از متن سلول‌های کتاب‌کار به عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با دادهٔ پیش‌فرض به اولین اسلاید یک ارائهٔ موجود اضافه می‌کند. از سلول‌های A10:A12 در کاربرگ 0 برای سه برچسب اول در اولین سری استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌کند و ارائهٔ به‌روزرسانی‌شده را ذخیره می‌کند.

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

متد [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) دسترسی به کاربرگ‌های موجود در یک کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با دادهٔ پیش‌فرض ایجاد می‌کند و نام هر کاربرگ را در کنسول چاپ می‌کند.

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

## **مشخص کردن نوع منبع داده**

این مثال یک نمودار ستونی 3 بعدی با دادهٔ پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع دادهٔ متفاوت تنظیم می‌کند. نام اول از یک رشتهٔ ثابت استفاده می‌کند؛ نام دوم از سلول C1 در کاربرگ 0 استفاده می‌کند. شمارش [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) منبع هر نام را انتخاب می‌کند. مثال ارائهٔ با نام‌های سری به‌روزرسانی‌شده را ذخیره می‌کند.

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

## **تشخیص قالب‌های کتاب‌کار توکار غیرقابل پشتیبانی**

Aspose.Slides قالب کتاب‌کار باینری اکسل (.xlsb) را که می‌تواند در برخی نمودارها توکار شود، پشتیبانی نمی‌کند. می‌توانید از متد [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) بر روی [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) برای شناسایی قالب‌های غیرقابل پشتیبانی استفاده کنید و آن نمودارها را عبور دهید. این مثال شکل‌های اولین اسلاید یک ارائهٔ موجود را بررسی می‌کند، اشکال غیرنمودار را عبور می‌دهد و برای هر نمودار با کتاب‌کار .xlsb توکار، یک پیام تشخیصی چاپ می‌کند.

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
        # داده‌های کتاب‌کار پشتیبانی‌شدهٔ نمودار را اینجا بخوانید یا ویرایش کنید.
finally:
    presentation.dispose()
```

## **کتاب‌کار خارجی**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) و [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) برای استخراج یک کتاب‌کار نمودار توکار به یک فایل و پیوند نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با دادهٔ پیش‌فرض ایجاد می‌کند و کتاب‌کار آن را استخراج می‌کند. نوشتن فایل را پیش از اختصاص کتاب‌کار خارجی به عنوان منبع دادهٔ نمودار تکمیل می‌کند، سپس ارائهٔ پیونددار را ذخیره می‌کند.

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

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) می‌توانید یک کتاب‌کار خارجی را به عنوان منبع دادهٔ نمودار اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورتی که جابه‌جا شده باشد) استفاده شود.

در حالی که نمی‌توانید داده‌ها را در کتاب‌کارهای ذخیره‌شده در مکان‌های راه‌دور یا منابع ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌طور خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک کتاب‌کار خارجی استفاده می‌کند که کاربرگ آن به نام `Sheet1` شامل یک نام سری در B1، نام‌های دسته در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار دایره‌ای ایجاد می‌کند، کتاب‌کار را پیوند می‌دهد و از [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) برای نگاشت A1:B4 به یک سری و سه دسته استفاده می‌کند. ارائهٔ با نمودار پیوند داده شده را ذخیره می‌کند.

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

پارامتر `updateChartData` متد [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) کنترل می‌کند که آیا کتاب‌کار بارگذاری شود یا نه.

* وقتی `updateChartData` برابر `False` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود. دادهٔ نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شود، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
* وقتی `updateChartData` برابر `True` باشد، دادهٔ نمودار از کتاب‌کار هدف به‌روزرسانی می‌شود.

مثال زیر یک URL جایگزین با `updateChartData` برابر `False` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای را حفظ می‌کند و ارائه را بدون بارگذاری کتاب‌کار در دسترس ذخیره می‌کند.

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

برای شناسایی کتاب‌کاری که به یک نمودار پیوند داده شده، بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کتاب‌کار آن را بازیابی کنید.

این مثال اولین شکل در اولین اسلاید یک ارائهٔ دارای کتاب‌کار خارجی پیوندی را بررسی می‌کند. اگر یک نمودار باشد که به کتاب‌کار خارجی پیوند دارد، [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) را در کنسول چاپ می‌کند. سپس یک کپی از ارائه را ذخیره می‌کند.

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

### **ویرایش دادهٔ نمودار**

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همانند ویرایش محتویات کتاب‌کارهای داخلی اصلاح کنید. وقتی یک کتاب‌کار خارجی قابل بارگذاری نیست، استثنایی پرتاب می‌شود.

این مثال از یک نمودار که اولین شکل در اولین اسلاید است و به یک کتاب‌کار خارجی قابل دسترس پیوند دارد استفاده می‌کند. مقدار پشتیبان‌دار سلولی اولین نقطه داده در اولین سری را به 100 تنظیم می‌کند و ارائهٔ به‌روزرسانی‌شده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوندی را به‌روزرسانی کند، بنابراین در صورت نیاز به حفظ کتاب‌کار اصلی، از یک کپی استفاده کنید.

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

اگر یک نمودار از کتاب‌کار خارجی استفاده می‌کند که مفقود یا در دسترس نیست، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. قبل از باز کردن ارائه، یک [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/) ایجاد کنید، [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) را فراخوانی کنید و [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) را به `True` تنظیم کنید.

مثال زیر پایتون کتاب‌کار داده‌ها را برای یک نمودار که اولین شکل در اولین اسلاید است و به یک کتاب‌کار خارجی غیرفعال ارجاع می‌دهد، بازیابی می‌کند. داده‌های بازیابی‌شده را از طریق [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) و [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) دسترسی می‌یابد:

```python
import jpype
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

        # خواندن یا اصلاح داده‌های کتاب‌کار بازیابی‌شده در اینجا.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides یک استثنا پرتاب می‌کند. فقط زمانی که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ پذیرش‌پذیر باشد، بازیابی را فعال کنید، زیرا کش ممکن است تغییرات انجام‌شده در کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه را شامل نشود.

## **سؤالات متداول**

**آیا می‌توانم تعیین کنم یک نمودار خاص به کتاب‌کار خارجی یا توکار پیوند دارد؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) و [path to an external workbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌طور خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند؛ بنابراین جابجایی کتاب‌کار ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از کتاب‌کارهای قرار گرفته در منابع/به‌اشتراک‌گذاری‌های شبکه استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به عنوان منبع دادهٔ خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌کارهای راه‌دور از Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides فایل XLSX خارجی را هنگام ذخیرهٔ ارائه بازنویسی می‌کند؟**

ارائه یک [link to the external file](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) ذخیره می‌کند. ویرایش داده‌های نمودار پشتیبان‌دار سلولی می‌تواند فایل XLSX محلی پیوندی را نیز به‌روزرسانی کند. اگر کتاب‌کار اصلی باید دست‌نخورده بماند، از یک کپی استفاده کنید.

**اگر فایل خارجی با رمز عبور محافظت شده باشد چه کاری باید انجام دهم؟**

Aspose.Slides هنگام پیوندگیری رمز عبور نمی‌پذیرد. یک روش معمول این است که پیش از پیوند، محافظت را حذف کنید یا یک کپی رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) آماده کنید و به آن پیوند دهید.

**آیا می‌توان چندین نمودار را به یک کتاب‌کار خارجی ارجاع داد؟**

بله. هر نمودار پیوند خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در هر نمودار بازتاب خواهد یافت.