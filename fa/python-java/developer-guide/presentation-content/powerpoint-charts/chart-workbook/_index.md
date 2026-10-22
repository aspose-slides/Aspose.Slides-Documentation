---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها با استفاده از Python از طریق Java
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/python-java/chart-workbook/
keywords:
- کتاب‌کار نمودار
- داده‌های نمودار
- سلول کتاب‌کار
- برچسب داده
- ورق کار
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب‌کار
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides برای Python از طریق Java را کشف کنید: به‌سادگی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائهٔ خود را بهینه‌سازی کنید."
---
## **بررسی اجمالی**

این مقاله توضیح می‌دهد که چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده‌ای نمودار استفاده کنید، به مجموعه‌های ورق کار دسترسی داشته باشید و نوع منبع داده را برای مقادیر نمودار مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده‌ای نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی مرتبط با یک نمودار را بازیابی کنید و داده‌های نمودار را زمانی که کتاب‌کار در دسترس است، ویرایش کنید.

برای سلول‌های کتاب‌کاری که نشان‌دهنده داده‌های گمشده هستند، به [Control the Display of Empty Cells](/slides/fa/python-java/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر و مقایسه‌ای خطی از حالت‌های نمایش موجود را ببینید.

## **شامل کردن داده‌ها از سطرها و ستون‌های مخفی**

از [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) برای کنترل این‌که آیا یک نمودار داده‌ها را فقط از سطرها و ستون‌های نمایان ورق کار بگیرد یا نه استفاده کنید. آن را روی `True` تنظیم کنید تا فقط سلول‌های نمایان ترسیم شوند، یا روی `False` تا هر دو سلول نمایان و مخفی شامل شوند. این تنظیم تنها نحوه ترسیم نمودار را کنترل می‌کند؛ سطرها یا ستون‌های ورق کار را مخفی یا نمایان نمی‌کند.

[نمونه ارائه](hidden-source-data.pptx) شامل یک نمودار ستونی به‌عنوان اولین شکل در اولین اسلاید است. ورق کار جاسازی‌شده، `Sheet1`، بازه منبع زیر را دارد: `A1:C4`. سطر 3 و ستون C مخفی هستند، اما سلول‌هایشان هنوز مقدار دارند.

| سطر ورق کار | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (سطر مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) دسترسی پیدا کنید و [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) را بخوانید تا وضعیت مخفی بودنشان را بررسی کنید. این روش وضعیت مخفی بودن را بدون تغییر آن گزارش می‌کند. در این مثال، B2 نمایان است، B3 متعلق به سطر مخفی است و C2 متعلق به ستون مخفی؛ خروجی مثال `False`، `True` و `True` است.

برای این مثال، پس از تغییر تنظیمات ترسیم، داده‌های نمودار را تازه کنید: کتاب‌کار جاسازی‌شده را با [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) نگه‌دارید و با [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) دوباره بارگذاری کنید. هنگام شامل کردن تمام سلول‌ها، از [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) نیز برای بازگرداندن بازه کامل، از جمله دستهٔ مخفی فوریه، استفاده کنید. تنها تغییر پرچم برای تازه‌سازی داده‌های کش‌شده نمونه کافی نیست.

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

            # داده‌های نمودار را از کتاب‌کار جاسازی‌شده تازه کنید.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # محدوده منبع کامل را بازگردانید، از جمله دسته‌های مخفی.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

مثال دو نسخه از ارائه را ذخیره می‌کند: یکی فقط با مقادیر نمایان خرده‌فروشی (10 و 20) و دیگری با تمام شش مقدار. تصاویر زیر حالت‌های ترسیم را نشان می‌دهند. سطر 3 و ستون C در هر دو کتاب‌کار جاسازی‌شده مخفی می‌مانند.

| فقط سلول‌های نمایان (`True`) | تمام سلول‌ها (`False`) |
| --- | --- |
| ![فقط سلول‌های نمایان: مقادیر خرده‌فروشی 10 و 20 برای ژانویه و مارس.](hidden_cells_True.png) | ![تمام سلول‌ها: مقادیر خرده‌فروشی و عمده‌فروشی برای ژانویه، فوریه و مارس.](hidden_cells_False.png) |

یک سلول مخفی که حاوی مقدار است متفاوت از یک سلول خالی است. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) کنترل می‌کند مقادیر گمشده چگونه نمایش داده شوند؛ این تنظیم شامل یا مستثنی کردن داده‌های منبع مخفی را انجام نمی‌دهد. برای مثال به [Control the Display of Empty Cells](/slides/fa/python-java/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **بازیابی محدوده داده‌های نمودار**

قبل از به‌روزرسانی داده‌های کتاب‌کار در یک ارائه موجود، بازه‌های منبع را بررسی کنید تا مشخص شود هر نمودار از کدام سلول‌های ورق کار استفاده می‌کند. متد [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) بازه داده‌ای فعلی را به‌صورت فرمولی با مشخصات ورق کار باز می‌گرداند، مانند `Sheet1!$A$1:$D$5`. در اینجا، `Sheet1` نام ورق کار است، `!` آن را از بازه سلول‌ها جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را شامل می‌شود. علامت‌های دلار نشان‌دهنده ارجاع مطلق به سطر و ستون هستند.

این متد بازه فعلی را بدون تغییر نمودار یا کتاب‌کار آن می‌خواند. اگر نمودار از کتاب‌کاری به‌عنوان منبع داده استفاده نکرده باشد، `InvalidOperationException` پرتاب می‌شود. برای اطلاعات بیشتر به [ChartData API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) مراجعه کنید.

این مثال یک ارائه را باز می‌کند و شکل‌ها را مستقیماً در هر اسلاید برای نمودارها بررسی می‌کند. نام هر نمودار و بازه منبع را چاپ می‌کند. اگر نموداری از کتاب‌کار استفاده نکند، پیامی چاپ می‌کند و به نمودار بعدی ادامه می‌دهد.

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

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides for Python via Java متدهای [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) و [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) را ارائه می‌دهد که امکان خواندن و نوشتن کتاب‌کارهای داده نمودار (حاوی داده‌های نمودار ویرایش‌شده با Aspose.Cells) را می‌دهند. **توجه** داشته باشید که داده‌های نمودار باید به همان شکل سازماندهی شده باشند یا ساختاری مشابه منبع داشته باشند.

این مثال یک ارائه با یک نمودار به‌عنوان اولین شکل در اولین اسلاید استفاده می‌کند. کتاب‌کار جاسازی‌شده را به یک آرایه بایت می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را باز می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

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

### **اعتبارسنجی طرح نمودار پس از تغییر کتاب‌کار**

هنگامی که یک کتاب‌کار جاسازی‌شده با یک کتاب‌کار اصلاح‌شده جایگزین می‌شود، نمودار مجموعه‌های سری و دسته اولیه خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شکست [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) با خطای «اندیس خارج از محدوده» شود. پیش از نوشتن کتاب‌کار به‌روزشده، سری‌ها و دسته‌های موجود را پاک کنید. این مثال یک نمودار را که اولین شکل در اولین اسلاید است استفاده می‌کند. نظر در جایی قرار دارد که ویرایش کتاب‌کار انجام می‌شود؛ مثال قابل اجرا کتاب‌کار اصلی را باز می‌نویسد و طرح را در حافظه اعتبارسنجی می‌کند.

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

        # در اینجا بایت‌های کتاب‌کار را اصلاح کنید، به عنوان مثال، با استفاده از Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

پاک‌سازی مجموعه‌ها قبل از نوشتن کتاب‌کار، مراجع داده‌های قدیمی را حذف می‌کند. قبل از استفاده از نمودار، سری‌ها و نگاش‌های دسته مورد نیاز برای کتاب‌کار به‌روزشده بازسازی شوند.

## **تنظیم قالب‌های عددی سفارشی برای سلول‌های کتاب‌کار**

از [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) برای کنترل نحوه نمایش مقادیر عددی در کتاب‌کار جاسازی‌شده یک نمودار استفاده کنید. به عنوان مثال، یک گزارش ممکن است نرخ تبدیل را به‌عنوان درصد با چهار رقم اعشار و یک ضریب را با پنج رقم اعشار نمایش دهد. هر دو مقدار باید عددی بمانند تا برای محاسبات و ترسیم نمودار در دسترس باشند.

قالب عددی نمایش را تغییر می‌دهد، نه مقدار ذخیره‌شده. قالب `0.0000%` عدد `0.125` را به‌صورت `12.5000%` نشان می‌دهد؛ عدد ذخیره‌شده همچنان `0.125` است. به‌ همان‌طور، `0.00000` عدد `0.1234567` را به‌صورت `0.12346` نشان می‌دهد بدون اینکه مقدار ذخیره‌شده گرد شود. اگر قالب سفارشی رشته خالی (`""`) باشد، قالب بازگردانده‌شده توسط [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) استفاده می‌شود.

مثال زیر یک نمودار ستونی ایجاد می‌کند و به سلول‌های آن از طریق [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) دسترسی پیدا می‌کند. در ورق کار 0، B2 حاوی نرخ تبدیل و C2 حاوی ضریب است. هر دو سلول مقدارهای نمودار را فراهم می‌کنند. مثال همچنین برچسب‌های مقدار را که به قالب‌های منبع پیوند دارند فعال می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210)
    chart.setTitle(False)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00")
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(0)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A2", "Sample")
    chart.getChartData().getCategories().add(category_cell)

    percentage_cell = workbook.getCell(0, "B2", jpype.JDouble(0.125))
    percentage_cell.setCustomNumberFormat("0.0000%")
    percentage_name = workbook.getCell(0, "B1", "Conversion rate")
    percentage_series = chart.getChartData().getSeries().add(percentage_name, chart.getType())
    percentage_series.getDataPoints().addDataPointForBarSeries(percentage_cell)

    precision_cell = workbook.getCell(0, "C2", jpype.JDouble(0.1234567))
    precision_cell.setCustomNumberFormat("0.00000")
    precision_name = workbook.getCell(0, "C1", "Coefficient")
    precision_series = chart.getChartData().getSeries().add(precision_name, chart.getType())
    precision_series.getDataPoints().addDataPointForBarSeries(precision_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(True)

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

قالب‌های سلول کتاب‌کار جدا از قالب‌های تنظیم‌شده مستقیم روی محورهای نمودار یا برچسب‌های داده هستند. در این مثال، هر برچسب مقدار سلول منبع خود را نمایش می‌دهد زیرا [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) روی `True` تنظیم شده و به دلیل تنظیم [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) روی `True` قالب عددی منبع را دنبال می‌کند. پس از ذخیره و بازگشایی ارائه، برچسب‌ها `12.5000%` و `0.12346` را نشان می‌دهند، همان‌طور که در زیر نشان داده شده است. محور عمودی قالب عددی خود را دارد که با [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) به `0.00` تنظیم شده و [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) روی `False` است.

برای قالب‌بندی مستقل یک برچسب داده، پرچم پیوند به منبع آن را به `False` تنظیم کنید و با [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) یک قالب اختصاص دهید. این کار قالب سلول کتاب‌کار را تغییر نمی‌دهد. برای مثال، قالب مستقل برچسب `0.00` مقدار اول را به‌صورت `0.13` نشان می‌دهد، در حالی که B2 همچنان `12.5000%` را نشان می‌دهد. برای قالب‌گذاری مستقیم برچسب‌ها به [Chart Data Labels](/slides/fa/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) مراجعه کنید.

![نمودار ستونی با برچسب‌های منبع‑پیوسته که `12.5000%` و `0.12346` را نشان می‌دهند و یک محور عددی به‌صورت مستقل قالب‌بندی شده است.](custom-cell-formats.png)

## **تنظیم سلول کتاب‌کار به‌عنوان برچسب داده‌ای نمودار**

می‌توانید از متن سلول‌های کتاب‌کار به‌عنوان برچسب‌های داده‌ای نمودار استفاده کنید.

این مثال یک نمودار حبابی با داده‌های پیش‌فرض به اولین اسلاید یک ارائه موجود اضافه می‌کند. از سلول‌های A10:A12 در ورق کار 0 برای سه برچسب اول در اولین سری استفاده می‌کند، برچسب‌های سلولی را فعال می‌کند و ارائه به‌روزشده را ذخیره می‌کند.

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

## **مدیریت ورق‌های کار**

متد [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) دسترسی به ورق‌های کار موجود در کتاب‌کار یک نمودار را فراهم می‌کند. این مثال یک نمودار پای با داده‌های پیش‌فرض ایجاد می‌کند و نام هر ورق کار را در کنسول چاپ می‌کند.

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

مقادیر نقاط سری می‌توانند به‌صورت مستقیم به‌عنوان Literals عددی ذخیره شوند. برای مثال کامل به [Set Series Values Using Numeric Literals](/slides/fa/python-java/chart-series/#set-series-values-using-numeric-literals) مراجعه کنید. نوع منبع مقادیر نقطه‌ای جدا از پیکربندی کتاب‌کار داخلی یا خارجی نمودار است؛ استفاده از Literals عددی به‌تنها خودی خود کتاب‌کار جاسازی‌شده را حذف نمی‌کند.

این مثال یک نمودار ستونی 3D با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع داده متفاوت تنظیم می‌کند. نام اول از یک Literal رشته‌ای استفاده می‌کند؛ نام دوم از سلول C1 در ورق کار 0 استفاده می‌کند. شمارش [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) منبع هر نام را انتخاب می‌کند. مثال ارائه را با نام‌های سری به‌روز شده ذخیره می‌کند.

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

## **تشخیص فرمت‌های کتاب‌کار جاسازی‌شده ناموفق**

Aspose.Slides از فرمت کتاب‌کار باینری اکسل (.xlsb) که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از متد [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) روی [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) فرمت‌های ناموفق را شناسایی کرده و از آن نمودارها عبور کنید. این مثال شکل‌ها را در اولین اسلاید یک ارائه موجود بررسی می‌کند، شکل‌های غیرنموداری را عبور می‌دهد و برای هر نمودار دارای کتاب‌کار .xlsb جاسازی‌شده پیام تشخیصی چاپ می‌کند.

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
        # در اینجا داده‌های کتاب‌کار نمودار پشتیبانی‌شده را بخوانید یا اصلاح کنید.
finally:
    presentation.dispose()
```

## **کتاب‌کار خارجی**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به‌عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) و [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) برای استخراج کتاب‌کار نمودار جاسازی‌شده به یک فایل و پیوند نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار پای با داده‌های پیش‌فرض ایجاد می‌کند و کتاب‌کار آن را صادر می‌کند. نوشتن فایل را قبل از اختصاص کتاب‌کار خارجی به عنوان منبع داده نمودار تکمیل می‌کند، سپس ارائه پیوندی را ذخیره می‌کند.

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

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) می‌توانید یک کتاب‌کار خارجی را به یک نمودار به‌عنوان منبع داده اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (اگر جابجا شده باشد) استفاده شود.

در حالی که نمی‌توانید داده‌ها را در کتاب‌کارهای ذخیره‌شده در مکان‌های دوردست یا منابع ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای یک کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک کتاب‌کار خارجی استفاده می‌کند که ورق کاری به نام `Sheet1` شامل یک نام سری در B1، نام دسته‌ها در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار پای ایجاد می‌کند، کتاب‌کار را پیوند می‌دهد و با استفاده از [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) بازه A1:B4 را به یک سری و سه دسته نگاشت می‌کند. سپس ارائه با نمودار پیوندشده ذخیره می‌شود.

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

* وقتی `updateChartData` برابر `False` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود. داده‌های نمودار بارگذاری یا به‌روزرسانی نمی‌شوند، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
* وقتی `updateChartData` برابر `True` باشد، داده‌های نمودار از کتاب‌کار هدف به‌روزرسانی می‌شود.

مثال زیر یک URL جایگزین را با `updateChartData` تنظیم شده روی `False` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار پای حفظ می‌شوند و ارائه بدون بارگذاری کتاب‌کار در دسترس نیست ذخیره می‌شود.

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

### **دریافت مسیر کتاب‌کار منبع داده خارجی یک نمودار**

برای شناسایی کتاب‌کاری که به یک نمودار پیوند داده شده است، بررسی کنید آیا نمودار از منبع داده خارجی استفاده می‌کند و مسیر کتاب‌کار آن را بازیابی کنید.

این مثال اولین شکل در اولین اسلاید یک ارائه با کتاب‌کار خارجی پیوندشده را بررسی می‌کند. اگر یک نمودار باشد که به کتاب‌کار خارجی پیوند دارد، مثال [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) را در کنسول چاپ می‌کند. سپس یک نسخه از ارائه را ذخیره می‌کند.

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

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همان‌گونه که تغییرات در محتوای کتاب‌کارهای داخلی ایجاد می‌کنید، ویرایش کنید. وقتی یک کتاب‌کار خارجی قابل بارگذاری نباشد، استثنایی پرتاب می‌شود.

این مثال یک نمودار را که اولین شکل در اولین اسلاید است و به یک کتاب‌کار خارجی قابل دسترسی پیوند دارد، استفاده می‌کند. مقدار پشتیبانی‌شده توسط سلول اولین نقطه داده در اولین سری را به 100 تنظیم می‌کند و ارائه به‌روزشده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوندشده را به‌روز کند، بنابراین در صورت نیاز از یک کپی استفاده کنید تا کتاب‌کار اصلی حفظ شود.

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

### **بازگرداندن کتاب‌کار از حافظه پنهان نمودار**

اگر یک نمودار از کتاب‌کار خارجی که گم شده یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. قبل از باز کردن ارائه، یک [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/) ایجاد کنید، [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) را فراخوانی کنید و [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) را روی `True` تنظیم کنید.

مثال پایتون زیر داده‌های کتاب‌کار را برای یک نمودار که اولین شکل در اولین اسلاید است و به یک کتاب‌کار خارجی در دسترس نیست، بازمی‌یابد. داده‌های بازگردانده شده را از طریق [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) و [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) دسترسی می‌یابد:

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

        # در اینجا داده‌های کتاب‌کار بازیابی‌شده را بخوانید یا اصلاح کنید.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنا پرتاب می‌کند. فقط زمانی بازیابی را فعال کنید که استفاده از داده‌های کش‌شده نمودار یک راه‌حل قابل قبول باشد، زیرا کش ممکن است تغییرات انجام‌شده در کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه را نداشته باشد.

## **پرسش‌های متداول**

**آیا می‌توانم تشخیص دهم که یک نمودار خاص به یک کتاب‌کار خارجی یا جاسازی‌شده پیوند دارد؟**

بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) و [مسیر کتاب‌کار خارجی](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، لذا جابجایی کتاب‌کار ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از کتاب‌کارهایی که در منابع/به‌اشتراک‌گذاری‌های شبکه قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع داده خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌کارهای دوردست از طریق Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیره‌سازی ارائه فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [پیوند به فایل خارجی](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) ذخیره می‌کند. ویرایش داده‌های نمودار پشتیبانی‌شده توسط سلول می‌تواند فایل XLSX محلی پیوندشده را نیز به‌روز کند. برای حفظ کتاب‌کار اصلی، از یک کپی استفاده کنید.

**اگر فایل خارجی دارای رمز عبور باشد چه باید کرد؟**

Aspose.Slides هنگام پیوندگیری رمز عبور را نمی‌پذیرد. یک روش معمول حذف محافظت از پیش یا تهیه یک کپی رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) و پیوند به آن کپی است.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی ارجاع دهند؟**

بله. هر نمودار پیوند خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در تمام نمودارها منعکس می‌شود.