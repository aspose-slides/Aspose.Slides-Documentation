---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها با پایتون
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/python-net/chart-workbook/
keywords:
- کتاب‌کار نمودار
- داده‌های نمودار
- سلول کتاب‌کار
- برچسب داده
- برگه‌کاری
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب‌کار
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "Aspose.Slides برای پایتون از طریق .NET را کشف کنید: به‌سرعت کتاب‌کارهای نمودار را در قالب‌های پاورپوینت و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه کنید."
---
## **مرور کلی**

این مقاله نحوه کار با کتاب‌کارهای نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه می‌توان داده‌های نمودار را از طریق جریان‌های کتاب‌کار خواند و نوشت، از سلول‌های کتاب‌کار به‌عنوان برچسب‌های دادهٔ نمودار استفاده کرد، به مجموعه‌های برگه‌ها دسترسی یافت و نوع منبع دادهٔ مقادیر نمودار را مشخص کرد.

همچنین کار با کتاب‌کارهای خارجی به‌عنوان منابع دادهٔ نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص داده شود، مسیر کتاب‌کار خارجی پیوست به یک نمودار بازیابی شود و دادهٔ نمودار هنگام در دسترس بودن کتاب‌کار ویرایش شود.

برای سلول‌های کتاب‌کار که نمایانگر دادهٔ گمشده هستند، به [کنترل نمایش سلول‌های خالی](/slides/fa/python-net/chart-series/) مراجعه کنید تا تفاوت بین سلول خالی و صفر و مقایسهٔ خطی حالت‌های نمایش موجود را ببینید.

## **داده‌ها را از ردیف‌ها و ستون‌های مخفی شامل کنید**

از [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) برای کنترل این‌که آیا نمودار داده‌ها را از ردیف‌ها و ستون‌های مخفی برگه کاری پردازش می‌کند یا نه استفاده کنید. آن را به `True` تنظیم کنید تا فقط سلول‌های قابل مشاهده پردازش شوند، یا به `False` تا هر دو سلول قابل مشاهده و مخفی شامل شوند. این تنظیم فقط پردازش نمودار را کنترل می‌کند؛ ردیف‌ها یا ستون‌های برگه کاری را مخفی یا آشکار نمی‌کند.

فایل [hidden-source-data.pptx](hidden-source-data.pptx) را دانلود کنید و در پوشهٔ کاری قرار دهید. اسلاید اول آن شامل یک نمودار ستونی به‌عنوان اولین شکل است. برگه کاری جاسازی‌شده، `Sheet1`، شامل بازهٔ منبع زیر است: `A1:C4`. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آن‌ها همچنان مقدار دارند.

| ردیف برگه کاری | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

از طریق [ChartData.chart_data_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) به سلول‌های منبع دسترسی پیدا کنید و با [ChartDataCell.is_hidden](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatacell/is_hidden/) وضعیت مخفی بودن آن‌ها را بررسی کنید. این ویژگی فقط‑خواندنی است. در این فایل، B2 قابل مشاهده است، B3 به ردیف مخفی تعلق دارد و C2 به ستون مخفی؛ مثال مقادیر `False`، `True` و `True` را به ترتیب چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم پردازش، داده‌های نمودار را تازه کنید: کتاب‌کار جاسازی‌شده را با [read_workbook_stream](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) نگه داری کنید و با [write_workbook_stream](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) دوباره بارگذاری کنید. هنگام شامل‌سازی همهٔ سلول‌ها، از [set_range](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/set_range/) برای بازیابی بازهٔ کامل، شامل دستهٔ مخفی فوریه، استفاده کنید. فقط تغییر پرچم برای تازه‌سازی داده‌های کش‌شدهٔ این نمونه و برچسب‌های دسته کافی نیست.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # داده‌های نمودار را از کتاب‌کار جاسازی‌شده تازه کنید.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # بازهٔ منبع کامل را بازیابی کنید، شامل دسته‌های مخفی.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

مثال `hidden_cells_True.pptx` را فقط با مقادیر خرده‌فروشی قابل مشاهده (10 و 20) ذخیره می‌کند و `hidden_cells_False.pptx` را با همهٔ شش مقدار. تصاویر زیر پس از باز کردن مجدد ارائه‌های ذخیره‌شده رندر شده‌اند؛ هر دو فایل تنظیم پردازش اختصاصی خود را حفظ می‌کنند. ردیف 3 و ستون C در هر دو کتاب‌کار جاسازی‌شده مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`True`) | همهٔ سلول‌ها (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول مخفی حاوی مقدار، متفاوت از یک سلول خالی است. [Chart.display_blanks_as](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/display_blanks_as/) کنترل می‌کند مقادیر گمشده چگونه نمایش داده شوند؛ این ویژگی شامل یا حذف دادهٔ منبع مخفی نمی‌شود. برای مثال به [کنترل نمایش سلول‌های خالی](/slides/fa/python-net/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides for Python via .NET روش‌های [read_workbook_stream](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و [write_workbook_stream](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) را فراهم می‌کند که به شما امکان خواندن و نوشتن کتاب‌کارهای دادهٔ نمودار (حاوی دادهٔ ویرایش‌ شده با Aspose.Cells) را می‌دهد. **Note** داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این مثال `chart.pptx` را باز می‌کند؛ این فایل باید یک نمودار به‌عنوان اولین شکل در اسلاید اول داشته باشد. کتاب‌کار جاسازی‌شده را به‌صورت یک جریان می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را دوباره می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **اعتبارسنجی طرح نمودار پس از تغییر کتاب‌کار**

هنگامی که کتاب‌کار جاسازی‌شده را با یک نسخهٔ تغییر یافته جایگزین می‌کنید، نمودار سری‌ها و مجموعه‌های دستهٔ اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شکست [Chart.validate_chart_layout](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/validate_chart_layout/) با خطای خارج از دائرۀ شاخص شود. قبل از نوشتن کتاب‌کار بروز شده به نمودار، سری‌ها و دسته‌های موجود را پاک کنید. این مثال نیاز به `chart.pptx` دارد که در اسلاید اول یک نمودار داشته باشد. کامنت‌ها نشان می‌دهند که ویرایش کتاب‌کار در اینجا انجام می‌شود؛ مثال runnable کتاب‌کار اصلی را بازنویسی می‌کند و طرح را در حافظه اعتبارسنجی می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # جریان کتاب‌کار را اینجا تغییر دهید، به عنوان مثال با استفاده از Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

پاک‌سازی مجموعه‌ها مراجع دادهٔ منقضی‌شده را قبل از نوشتن کتاب‌کار حذف می‌کند. قبل از استفاده از نمودار، هر سری و نگاشت دستهٔ مورد نیاز برای کتاب‌کار بروز شده را بازسازی کنید.

## **تنظیم یک سلول کتاب‌کار به‌عنوان برچسب دادهٔ نمودار**

می‌توانید از متن سلول‌های کتاب‌کار به‌عنوان برچسب‌های دادهٔ نمودار استفاده کنید. مراحل زیر نشان می‌دهد چگونه برچسب‌ها را در یک نمودار حبابی به سلول‌های کتاب‌کار دادهٔ آن پیوند دهید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید اول را بر اساس شاخص صفر‑مبنا دسترسی پیدا کنید.
3. یک نمودار حبابی با دادهٔ پیش‌فرض اضافه کنید.
4. سری نمودار را دسترسی پیدا کنید.
5. سلول کتاب‌کار را به‌عنوان برچسب داده تنظیم کنید.
6. ارائه را ذخیره کنید.

این مثال `chart2.pptx` را باز می‌کند؛ این فایل باید حداقل یک اسلاید داشته باشد و یک نمودار حبابی با دادهٔ پیش‌فرض اضافه می‌کند. از سلول‌های A10:A12 در برگه 0 برای اولین سه برچسب در اولین سری استفاده می‌کند، برچسب‌ها از سلول‌ها فعال می‌شوند و نتیجه را در `resultchart.pptx` ذخیره می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **مدیریت برگه‌ها**

ویژگی [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) دسترسی به برگه‌های موجود در یک کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار پای با دادهٔ پیش‌فرض می‌سازد و نام هر برگه را در کنسول چاپ می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **مشخص کردن نوع منبع داده**

این مثال یک نمودار ستون 3D با دادهٔ پیش‌فرض می‌سازد و دو نام سری را با استفاده از منابع دادهٔ مختلف تنظیم می‌کند. نام اول از یک رشتهٔ ثابت استفاده می‌کند؛ نام دوم از سلول C1 در برگه 0 استفاده می‌کند. شمارشی [DataSourceType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datasourcetype/) منبع هر نام را انتخاب می‌کند. نتیجه در `pres.pptx` ذخیره می‌شود.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **تشخیص فرمت‌های کارپوشه جاسازی‌شده پشتیبانی‌نشده**

Aspose.Slides از قالب کتاب‌کار باینری اکسل (.xlsb) که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از ویژگی [embedded_workbook_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) در [ChartData](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/) به‌همراه شمارشی [WorkbookType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/workbooktype/) فرمت‌های پشتیبانی‌نشده را شناسایی کرده و آن نمودارها را نادیده بگیرید. این مثال اشکال موجود در اسلاید اول `sample.pptx` را بررسی می‌کند، اشکال غیرنموداری را رد می‌کند و برای هر نمودار دارای کتاب‌کار .xlsb جاسازی‌شده پیغام تشخیصی چاپ می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # داده‌های کتاب‌کار نمودار پشتیبانی‌شده را اینجا بخوانید یا تغییر دهید.
```

## **کارپوشه خارجی**

Aspose.Slides استفاده از کتاب‌کارهای خارجی به‌عنوان منبع دادهٔ نمودارها را پشتیبانی می‌کند.

### **ایجاد کارپوشه خارجی**

از [read_workbook_stream](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و [set_external_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/set_external_workbook/) برای استخراج کتاب‌کار نمودار جاسازی‌شده به یک فایل و پیوند نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار پای با دادهٔ پیش‌فرض می‌سازد، کتاب‌کار آن را در `externalWorkbook1.xlsx` می‌نویسد و قبل از اختصاص فایل به عنوان منبع دادهٔ نمودار جریان خروجی را می‌بندد. ارائهٔ پیوست‌شده در `externalWorkbook.pptx` ذخیره می‌شود.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)
    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **تنظیم کارپوشه خارجی**

با استفاده از روش [set_external_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/set_external_workbook/) می‌توانید یک کتاب‌کار خارجی را به‌عنوان منبع دادهٔ یک نمودار اختصاص دهید. این روش همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورتی که جابجا شده باشد) استفاده شود.

اگرچه نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌های دوردست یا منابع را ویرایش کنید، هنوز می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای یک کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال به `externalWorkbook.xlsx` در پوشهٔ کاری نیاز دارد. برگه کاری با نام `Sheet1` باید یک نام سری در B1، نام‌های دسته در A2:A4 و مقادیر عددی در B2:B4 داشته باشد. مثال یک نمودار پای می‌سازد، کتاب‌کار را پیوست می‌کند و با استفاده از [set_range](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/set_range/) بازهٔ A1:B4 را به یک سری و سه دسته نگاشت می‌کند. نتیجه در `Presentation_with_externalWorkbook.pptx` ذخیره می‌شود.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

پارامتر `update_chart_data` در [set_external_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/set_external_workbook/) کنترل می‌کند آیا کتاب‌کار بارگذاری شود یا نه.

* وقتی `update_chart_data` برابر `False` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود. دادهٔ نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شود، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
* وقتی `update_chart_data` برابر `True` باشد، دادهٔ نمودار از کتاب‌کار هدف به‌روزرسانی می‌شود.

مثال زیر یک URL مکان‌دار را با `update_chart_data` تنظیم شده بر `False` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار پای را حفظ می‌کند و ارائه را بدون بارگذاری کتاب‌کار غیرقابل دسترس ذخیره می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)

    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **دریافت مسیر کارپوشه منبع داده خارجی یک نمودار**

برای شناسایی کتاب‌کاری که به یک نمودار پیوست است، ابتدا بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند یا نه. اگر این‌گونه باشد، می‌توانید مسیر کتاب‌کار را با گام‌های زیر بازیابی کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید اول را بر اساس شاخص صفر‑مبنا دسترسی پیدا کنید.
3. بررسی کنید که اولین شکل یک نمودار باشد.
4. نوع منبع دادهٔ نمودار را بخوانید.
5. اگر منبع یک کتاب‌کار خارجی باشد، مسیر آن را بخوانید.

این مثال `externalWorkbook.pptx` را که در مثال قبلی ایجاد شد باز می‌کند و اولین شکل در اسلاید اول را بررسی می‌کند. اگر یک نمودار پیوست به کتاب‌کار خارجی باشد، مثال `[external_workbook_path](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/external_workbook_path/)` را در کنسول چاپ می‌کند. سپس یک نسخهٔ کپی از ارائه را در `Result.pptx` ذخیره می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **ویرایش داده‌های نمودار**

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همان‌گونه که محتویات کتاب‌کارهای داخلی را ویرایش می‌کنید، تغییر دهید. وقتی یک کتاب‌کار خارجی قابل بارگذاری نباشد، یک استثنا رخ می‌دهد.

این مثال به `presentation.pptx` نیاز دارد که در اسلاید اول یک نمودار داشته باشد و کتاب‌کار خارجی قابل دسترسی باشد. مقدار پشتیبان‑سلول اولین نقطه دادهٔ اولین سری را به 100 تنظیم می‌کند و ارائه را در `presentation_out.pptx` ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوست‌شده را به‌روز کند، بنابراین برای حفظ کتاب‌کار اصلی از یک کپی استفاده کنید.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **بازگرداندن کارپوشه از کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی استفاده می‌کند که موجود یا در دسترس نیست، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک [LoadOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/) ایجاد کنید، ویژگی [spreadsheet_options](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/spreadsheet_options/) آن را پیکربندی کنید و قبل از باز کردن ارائه، [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/fa/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) را به `True` تنظیم کنید.

مثال پایتون زیر `presentation.pptx` را باز می‌کند؛ اولین شکل در اسلاید اول باید یک نمودار باشد که به یک کتاب‌کار خارجی غیرقابل دسترس اشاره دارد و داده‌های بازیابی‌شده را از طریق [Chart.chart_data](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/chart_data/) و [ChartData.chart_data_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) دسترسی می‌یابد:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # داده‌های کتاب‌کار بازیابی‌شده را اینجا بخوانید یا تغییر دهید.
    else:
        print("The first shape is not a chart.")
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازسازی غیرفعال باشد، Aspose.Slides یک استثنا ایجاد می‌کند. بازسازی را فقط زمانی فعال کنید که استفاده از دادهٔ کش‌شدهٔ نمودار به‌عنوان یک روش برگشت پذیر قابل قبول باشد، زیرا ممکن است کش شامل تغییرات اعمال‌شده به کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه نباشد.

## **پرسش‌های متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به یک کتاب‌کار خارجی یا جاسازی‌شده پیوست است؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/data_source_type/) و [path to an external workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/external_workbook_path/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا اطمینان حاصل کنید که فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابه‌جایی کتاب‌کار ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از کتاب‌کارهایی که روی منابع شبکه/به‌اشتراک‌گذاری قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌کارهای راه دور از طریق Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیره ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [link to the external file](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/external_workbook_path/) را ذخیره می‌کند. ویرایش داده‌های نمودار پشتیبانی‌شده از سلول می‌تواند فایل XLSX محلی پیوست‌شده را نیز به‌روز کند. اگر باید کتاب‌کار اصلی دست‌نخورده بماند، از یک کپی استفاده کنید.

**اگر فایل خارجی دارای رمز عبور باشد، چه کاری باید انجام دهم؟**

Aspose.Slides هنگام پیوست کردن رمز عبور قبول نمی‌کند. یک روش معمول این است که پیش از زمان محافظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده (به‌عنوان مثال با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) تهیه کنید و به آن نسخهٔ کپی پیوست کنید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی اشاره کنند؟**

بله. هر نمودار پیوند خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در تمام نمودارها بازتاب می‌یابد.