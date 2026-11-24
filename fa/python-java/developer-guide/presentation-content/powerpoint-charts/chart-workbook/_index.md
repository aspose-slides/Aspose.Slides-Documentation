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
description: "کشف Aspose.Slides برای Python via Java: به راحتی کتاب‌کارهای نمودار را در قالب‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه کنید."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به‌عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های شیت‌ها دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را تعیین کنید.

همچنین کار با کتاب‌کارهای خارجی به‌عنوان منابع داده برای نمودارها را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و تخصیص داده شود، مسیر کتاب‌کار خارجی پیوست‌شده به یک نمودار بازیابی شود و داده‌های نمودار هنگام در دسترس بودن کتاب‌کار ویرایش شود.

برای سلول‌های کتاب‌کار که نمایانگر داده‌های گمشده هستند، به [کنترل نمایش سلول‌های خالی](/slides/fa/python-java/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر و مقایسهٔ نمودار خطی حالت‌های نمایش موجود را ببینید.

## **شامل داده‌ها از سطرها و ستون‌های پنهان**

از [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) برای کنترل اینکه آیا یک نمودار داده‌ها را فقط از سلول‌های قابل مشاهده یا از هر دو سلول قابل مشاهده و پنهان ترسیم کند استفاده کنید. مقدار `True` را تنظیم کنید تا فقط سلول‌های قابل مشاهده ترسیم شوند، یا `False` را تنظیم کنید تا هر دو سلول قابل مشاهده و پنهان شامل شوند. این تنظیم فقط بر ترسیم نمودار تأثیر دارد؛ سطرها یا ستون‌های شیت را مخفی یا آشکار نمی‌کند.

[نمونه ارائه](hidden-source-data.pptx) شامل یک نمودار ستونی به‌عنوان اولین شکل در اسلاید اول خود است. شیت توکار `Sheet1` شامل بازه منبع زیر است: `A1:C4`. سطر ۳ و ستون C پنهان هستند، اما سلول‌های آنها هنوز مقادیر دارند.

| سطر شیت | A: ماه | B: خرده‌فروش | C: عمده‌فروش (ستون پنهان) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (سطر پنهان) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

دستگاه‌های منبع را از طریق [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) دسترسی پیدا کنید و برای بررسی وضعیت مخفی بودن آنها از [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) استفاده کنید. این متد وضعیت مخفی بودن را بدون تغییر گزارش می‌دهد. در این مثال، B2 قابل مشاهده است، B3 متعلق به سطر پنهان است و C2 متعلق به ستون پنهان؛ خروجی به ترتیب `False`، `True` و `True` چاپ می‌شود.

برای این مثال، پس از تغییر تنظیم ترسیم، داده‌های نمودار را تازه کنید: کتاب‌کار توکار را با [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) حفظ کنید و با [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) دوباره بارگذاری کنید. هنگام شامل کردن همه سلول‌ها، همچنین از [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) برای بازگرداندن بازه کامل، شامل دستهٔ پنهان فوریه، استفاده کنید. فقط تغییر پرچم برای تازه‌سازی داده‌های کش‌شدهٔ نمونه کافی نیست.

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

            # به‌روزرسانی داده‌های نمودار از کتاب‌کار توکار.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # بازگرداندن بازهٔ منبع کامل، شامل دسته‌های پنهان.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

این مثال دو نسخه از ارائه را ذخیره می‌کند: یکی فقط با مقادیر خرده‌فروش قابل مشاهده (10 و 20)، و دیگری با تمام شش مقدار. تصاویر زیر دو حالت ترسیم را نشان می‌دهند. سطر ۳ و ستون C در هر دو کتاب‌کار توکار مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`True`) | همه سلول‌ها (`False`) |
| --- | --- |
| ![فقط سلول‌های قابل مشاهده: مقادیر خرده‌فروش 10 و 20 برای ژانویه و مارس.](hidden_cells_True.png) | ![همه سلول‌ها: مقادیر خرده‌فروش و عمده‌فروش برای ژانویه، فوریه و مارس.](hidden_cells_False.png) |

یک سلول پنهان که دارای مقدار است با یک سلول خالی متفاوت است. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) کنترل می‌کند مقادیر گمشده چگونه نمایش داده شوند؛ این تنظیم شامل یا مستثنی کردن داده‌های منبع پنهان نمی‌شود. برای مثال، به [کنترل نمایش سلول‌های خالی](/slides/fa/python-java/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **استخراج بازه داده‌های نمودار**

قبل از به‌روزرسانی داده‌های کتاب‌کار در یک ارائهٔ موجود، بازه‌های منبع را بررسی کنید تا مشخص کنید هر نمودار از کدام سلول‌های شیت استفاده می‌کند. متد [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) بازهٔ دادهٔ فعلی را به صورت فرمولی با مشخصات شیت بازمی‌گرداند، مانند `Sheet1!$A$1:$D$5`. در اینجا، `Sheet1` نام شیت است، `!` آن را از بازه سلولی جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را شامل می‌شود. علامت دلار نشان‌دهندهٔ ارجاع مطلق ردیف و ستون است.

این متد بازهٔ فعلی را بدون تغییر نمودار یا کتاب‌کار می‌خواند. اگر نمودار از کتاب‌کار به‌عنوان منبع داده استفاده نکند، `InvalidOperationException` پرتاب می‌شود. برای اطلاعات بیشتر، به [مرجع API ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) مراجعه کنید.

این مثال یک ارائه را باز می‌کند و شکل‌های موجود در هر اسلاید را مستقیماً برای نمودارها بررسی می‌کند. نام هر نمودار و بازهٔ منبع آن را چاپ می‌کند. اگر نموداری از کتاب‌کار استفاده نکند، پیامی چاپ می‌شود و به نمودار بعدی ادامه می‌دهد.

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

## **خواندن و نوشتن داده‌های نمودار از کتاب‌کار**

Aspose.Slides for Python via Java متدهای [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) و [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) را فراهم می‌کند که به شما امکان می‌دهد کتاب‌کارهای دادهٔ نمودار (حاوی داده‌های نمودار ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که داده‌های نمودار باید به همان شکل یا ساختار مشابه منبع سازمان‌دهی شوند.

این مثال از یک ارائه با نمودار به‌عنوان اولین شکل در اسلاید اول استفاده می‌کند. کتاب‌کار توکار را به یک آرایه بایت می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را دوباره می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

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

### **اعتبارسنجی طرح‌بندی نمودار پس از تغییر کتاب‌کار**

هنگامی که کتاب‌کار توکار را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شکست [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) با خطای «شاخص خارج از محدوده» شود. قبل از نوشتن کتاب‌کار به‌روز شده به نمودار، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک نمودار که اولین شکل در اسلاید اول است استفاده می‌کند. نظرات نشان می‌دهند که ویرایش کتاب‌کار در کجا انجام می‌شود؛ مثال قابل اجرا کتاب‌کار اصلی را دوباره می‌نویسد و طرح‌بندی را در حافظه اعتبارسنجی می‌کند.

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

        # در اینجا بایت‌های کتاب‌کار را تغییر دهید، برای مثال با استفاده از Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

پاک‌سازی مجموعه‌ها مراجع داده‌های منقضی‌شده را قبل از نوشتن کتاب‌کار حذف می‌کند. پیش از استفاده از نمودار، هر سری و نگاشت دستهٔ مورد نیاز برای کتاب‌کار به‌روز شده را بازسازی کنید.

## **انتخاب نحوهٔ ذخیره‌سازی برچسب‌های دسته**

قبل از افزودن برچسب‌ها، روی مجموعهٔ دستهٔ خالی متد [ChartCategoryCollection.setUseCells](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorycollection/#setUseCells) را صدا بزنید. زمانی که برچسب‌ها به داده‌های کتاب‌کار اشاره دارند یا سلسله‌مراتبی می‌سازند (مانند فصول گروه‌بندی‌شده بر اساس سال) از سلول‌های شیت استفاده کنید. برای برچسب‌های تک‌سطحی که نیازی به ارجاع به سلول ندارند، از رشته‌های لغوی استفاده کنید. این تنظیم فقط برای دسته‌ها اعمال می‌شود. هر دو نمودار زیر برای مقادیر سری عددی خود از سلول‌های شیت استفاده می‌کنند.

مثال دو نمودار ستونی ایجاد می‌کند و حالت ذخیره‌سازی را به همراه `Q1 Q2 Q3 Q4` برای هر یک چاپ می‌کند. برای برچسب‌های مبتنی بر شیت، [ChartCategory.getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/#getAsCell) سلول پایه را برمی‌گرداند و [ChartDataCell.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getValue) برچسب آن را می‌خواند. برای برچسب‌های لغوی، [ChartCategory.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/#getValue) مستقیماً رشته را برمی‌گرداند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    for use_cells in (True, False):
        x = 20 if use_cells else 360
        chart = shapes.addChart(ChartType.ClusteredColumn, x, 20, 320, 250)
        chart_data = chart.getChartData()
        chart_data.getSeries().clear()
        categories = chart_data.getCategories()
        categories.clear()
        categories.setUseCells(use_cells)

        workbook = chart_data.getChartDataWorkbook()
        series_name = workbook.getCell(0, 0, 1, "Sales")
        series = chart_data.getSeries().add(series_name, chart.getType())
        for row in range(1, 5):
            label = f"Q{row}"
            if use_cells:
                label_cell = workbook.getCell(0, row, 0, label)
                categories.add(label_cell)
            else:
                categories.add(label)

            value_cell = workbook.getCell(0, row, 1, jpype.JInt(row * 10))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        stored_in_cells = categories.getUseCells()
        labels = []
        for category in categories:
            value = category.getAsCell().getValue() if stored_in_cells else category.getValue()
            labels.append(str(value))
        print(f"UseCells = {stored_in_cells}:", *labels)

    presentation.save("category-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم قالب عددی سفارشی برای سلول‌های کتاب‌کار**

از [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) برای کنترل نحوهٔ نمایش مقادیر عددی در کتاب‌کار توکار نمودار استفاده کنید. به‌عنوان مثال، گزارشی ممکن است نیاز داشته باشد نرخ تبدیل به‌صورت درصد با چهار رقم اعشار و یک ضریب با پنج رقم اعشار نمایش داده شود. هر دو مقدار را عددی نگه دارید تا برای محاسبه‌ها و ترسیم نمودار در دسترس باشند.

یک قالب عددی نمایش را تغییر می‌دهد، نه مقدار ذخیره‌شده. قالب `0.0000%` عدد `0.125` را به ‌صورت `12.5000%` نمایش می‌دهد؛ مقدار ذخیره‌شده همچنان `0.125` است. به‌طور مشابه، `0.00000` عدد `0.1234567` را به `0.12346` نمایش می‌دهد بدون اینکه مقدار ذخیره‌شده گرد شود. اگر قالب سفارشی رشتهٔ خالی (`""`) باشد، قالب بازگردانده‌شده توسط [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) استفاده می‌شود.

مثال زیر یک نمودار ستونی ایجاد می‌کند و به سلول‌های آن از طریق [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) دسترسی می‌یابد. در شیت ۰، B2 حاوی نرخ تبدیل و C2 حاوی ضریب است. هر دو سلول مقادیر نمودار را فراهم می‌کنند. مثال همچنین برچسب‌های مقدار را که به قالب‌های منبع لینک دارند، فعال می‌کند.

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

قالب‌های سلول کتاب‌کار جدا از قالب‌های تنظیم‌شده مستقیم روی محورها یا برچسب‌های داده هستند. در این مثال، هر برچسب مقدار سلول منبع خود را نمایش می‌دهد زیرا [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) روی `True` تنظیم شده و با [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) روی `True` نیز قرار دارد. پس از ذخیره و بازگشایی ارائه، برچسب‌ها `12.5000%` و `0.12346` را نشان می‌دهند، همان‌طور که در زیر نشان داده شده است. محور عمودی قالب عددی خود را دارد که با [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) به‌صورت `0.00` تنظیم شده و با [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) روی `False` است.

برای قالب‌بندی مستقل یک برچسب داده، پرچم لینک به منبع آن را روی `False` تنظیم کنید و با [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) قالبی اختصاص دهید. این کار قالب سلول کتاب‌کار را تغییر نمی‌دهد. به‌عنوان مثال، قالب مستقل `0.00` مقدار اول را به `0.13` نمایش می‌دهد، در حالی که B2 همچنان `12.5000%` نشان می‌دهد. برای قالب‌بندی مستقیم برچسب‌ها به [برچسب‌های دادهٔ نمودار](/slides/fa/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) مراجعه کنید.

تصویر زیر پس از ذخیره و بازگشایی ارائه رندر شده است:

![نمودار ستونی با برچسب‌های لینک‌شده به منبع که 12.5000% و 0.12346 را نشان می‌دهند و محور عددی به‌صورت مستقل قالب‌بندی شده است.](custom-cell-formats.png)

## **استفاده از یک سلول کتاب‌کار به‌عنوان برچسب دادهٔ نمودار**

می‌توانید متن سلول‌های کتاب‌کار را به‌عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با داده‌های پیش‌فرض به اسلاید اول یک ارائهٔ موجود اضافه می‌کند. از سلول‌های A10:A12 در شیت ۰ برای اولین سه برچسب در سری اول استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌کند و ارائهٔ به‌روزشده را ذخیره می‌کند.

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

## **مدیریت شیت‌ها**

متد [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) دسترسی به شیت‌های موجود در کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و نام هر شیت را در کنسول چاپ می‌کند.

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

## **تعیین نوع منبع داده**

مقادیر نقاط سری می‌توانند به‌صورت literals عددی مستقیماً ذخیره شوند. برای مثال کامل به [تنظیم مقادیر سری با استفاده از literals عددی](/slides/fa/python-java/chart-series/#set-series-values-using-numeric-literals) مراجعه کنید. نوع منبع مقادیر نقطه‌ای از پیکربندی کتاب‌کار داخلی یا خارجی نمودار جداست؛ استفاده از literals عددی به‌تنهایی کتاب‌کار توکار را حذف نمی‌کند.

این مثال یک نمودار ستونی سه‌بعدی با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع داده متفاوت تنظیم می‌کند. نام اول از یک literal رشته‌ای استفاده می‌کند؛ نام دوم از سلول C1 در شیت ۰ استفاده می‌کند. شمارنده [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) منبع هر نام را انتخاب می‌کند. مثال ارائه را با نام‌های سری به‌روزشده ذخیره می‌کند.

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

Aspose.Slides قالب کتاب‌کار باینری اکسل (.xlsb) را که می‌تواند در برخی نمودارها توکار شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از متد [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) روی [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) همراه با شمارنده [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) قالب‌های پشتیبانی‌نشده را شناسایی کرده و آن نمودارها را نادیده بگیرید. این مثال شکل‌های اسلاید اول یک ارائهٔ موجود را بررسی می‌کند، شکل‌های غیرنموداری را رد می‌کند و برای هر نموداری که کتاب‌کار .xlsb توکار دارد، پیام تشخیصی چاپ می‌کند.

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

از [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) و [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) برای استخراج کتاب‌کار توکار یک نمودار به یک فایل و پیوست نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و کتاب‌کار آن را استخراج می‌کند. نوشتن فایل را قبل از تخصیص کتاب‌کار خارجی به عنوان منبع دادهٔ نمودار تکمیل می‌کند، سپس ارائهٔ پیوست‌شده را ذخیره می‌کند.

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

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) می‌توانید یک کتاب‌کار خارجی را به یک نمودار به‌عنوان منبع دادهٔ آن تخصیص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورتی که کتاب‌کار جابجا شده باشد) استفاده شود.

در حالی که نمی‌توانید داده‌ها را در کتاب‌کارهای ذخیره‌شده در مکان‌های از راه دور یا منابع ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌طور خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک کتاب‌کار خارجی استفاده می‌کند که شیت آن با نام `Sheet1` شامل یک نام سری در B1، نام دسته‌ها در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار دایره‌ای ایجاد می‌کند، کتاب‌کار را پیوست می‌کند و با استفاده از [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) بازه A1:B4 را به یک سری و سه دسته اختصاص می‌دهد. سپس ارائه را با نمودار پیوست‌شده ذخیره می‌کند.

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

* وقتی `updateChartData` برابر `False` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود. داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شوند، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
* وقتی `updateChartData` برابر `True` باشد، داده‌های نمودار از کتاب‌کار هدف به‌روزرسانی می‌شوند.

مثال زیر یک URL به‌عنوان نمونه با `updateChartData` برابر `False` تنظیم می‌کند. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شوند و ارائه بدون بارگذاری کتاب‌کار در دسترس نبودن ذخیره می‌شود.

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

برای شناسایی کتاب‌کار پیوست‌شده به یک نمودار، بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کتاب‌کار آن را بازیابی کنید.

این مثال اولین شکل در اسلاید اول یک ارائه با کتاب‌کار خارجی پیوست‌شده را بررسی می‌کند. اگر نمودار پیوست‌شده به کتاب‌کار خارجی باشد، [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) را در کنسول چاپ می‌کند. سپس یک کپی از ارائه را ذخیره می‌کند.

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

می‌توانید داده‌های کتاب‌کارهای خارجی را همانند تغییر محتویات کتاب‌کارهای داخلی ویرایش کنید. هنگامی که کتاب‌کار خارجی بارگذاری نشود، استثنایی پرتاب می‌شود.

این مثال از یک نمودار که اولین شکل در اسلاید اول است و به یک کتاب‌کار خارجی دردسترس پیوست شده، استفاده می‌کند. مقدار بازگردانده‌شده توسط سلول برای اولین نقطه دادهٔ اولین سری را به 100 تنظیم می‌کند و ارائه به‌روزشده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوست‌شده را به‌روزرسانی کند؛ بنابراین اگر نیاز به حفظ کتاب‌کار اصلی دارید، از یک کپی استفاده کنید.

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

اگر یک نمودار از کتاب‌کار خارجی که گم شده یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/) ایجاد کنید، [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) را فراخوانی کنید و [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) را قبل از باز کردن ارائه روی `True` تنظیم کنید.

مثال زیر به زبان Python کتاب‌کار داده‌ها را برای یک نمودار که اولین شکل در اسلاید اول است و به یک کتاب‌کار خارجی در دسترس نیست، بازیابی می‌کند. داده‌های بازیابی‌شده را از طریق [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) و [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) دسترسی می‌یابد:

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

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال شود، Aspose.Slides استثنا پرتاب می‌کند. بازیابی را فقط زمانی فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ قابل قبول باشد، زیرا کش ممکن است تغییرات اعمال‌شده به کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه را شامل نشود.

## **پرسش‌های متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به کتاب‌کار خارجی یا توکار پیوست شده است؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) و [path to an external workbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌طور خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابه‌جایی کتاب‌کار ممکن است نیاز به به‌روزرسانی لینک داشته باشد.

**آیا می‌توانم از کتاب‌کارهایی که بر روی منابع/به‌اشتراک‌گذاری‌های شبکه قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای راه دور از Aspose.Slides پشتیبانی نمی‌شود؛ آنها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [link to the external file](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) را ذخیره می‌کند. ویرایش داده‌های نمودار مبتنی بر سلول می‌تواند فایل XLSX محلی پیوست‌شده را نیز به‌روزرسانی کند. اگر نسخهٔ اصلی باید دست‌نخورده بماند، از یک کپی کتاب‌کار استفاده کنید.

**اگر فایل خارجی با رمز عبور محافظت شده باشد، چه کار باید کنم؟**

Aspose.Slides هنگام پیوست رمز عبور را قبول نمی‌کند. یک رویکرد معمول حذف حفاظت از پیش یا تهیه یک کپی رمزگشایی‌شده (به‌عنوان مثال با [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) و پیوست به آن کپی است.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی ارجاع دهند؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در تمام نمودارها منعکس می‌شود.