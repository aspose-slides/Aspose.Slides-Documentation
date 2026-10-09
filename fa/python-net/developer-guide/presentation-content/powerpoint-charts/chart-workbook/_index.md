---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها با پایتون
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/python-net/chart-workbook/
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
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "Aspose.Slides برای پایتون از طریق .NET را کشف کنید: به راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائهٔ خود را بهینه کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنیم. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب‌های دادهٔ نمودار استفاده کنید، به مجموعه‌های کاربرگ دسترسی پیدا کنید و نوع منبع داده را برای مقادیر نمودار مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع دادهٔ نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی پیوست به یک نمودار را بازیابی کنید و داده‌های نمودار را هنگامی که کتاب‌کار در دسترس است ویرایش کنید.

برای سلول‌های کتاب‌کاری که داده‌ی گمشده را نمایان می‌کنند، به [کنترل نمایش سلول‌های خالی](/slides/fa/python-net/chart-series/) برای تفاوت بین یک سلول خالی و صفر، و مقایسهٔ نمودار خطی حالت‌های نمایش موجود مراجعه کنید.

## **شامل کردن داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) برای کنترل این‌که آیا یک نمودار داده‌ها را از ردیف‌ها و ستون‌های مخفی کاربرگ رسم می‌کند یا نه استفاده کنید. مقدار `True` را تنظیم کنید تا فقط سلول‌های قابل مشاهده رسم شوند، یا `False` تا هم سلول‌های قابل مشاهده و هم مخفی گنجانده شوند. این تنظیم فقط روی رسم نمودار تأثیر می‌گذارد؛ ردیف‌ها یا ستون‌های کاربرگ را مخفی یا نمایان نمی‌کند.

[نمونهٔ ارائه](hidden-source-data.pptx) شامل یک نمودار ستونی به‌عنوان اولین شکل در اسلاید اول است. کاربرگ جاسازی‌شده، `Sheet1`، شامل بازهٔ منبع زیر است: `A1:C4`. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آن‌ها همچنان مقادیر دارند.

| ردیف کاربرگ | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) دسترسی پیدا کنید و برای بررسی وضعیت مخفی بودن آن‌ها از [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) استفاده کنید. این ویژگی فقط‑خواندنی است. در این فایل، B2 قابل مشاهده است، B3 متعلق به ردیف مخفی است و C2 متعلق به ستون مخفی؛ مثال به ترتیب `False`، `True` و `True` را چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم رسم، داده‌های نمودار را تازه کنید: کتاب‌کار جاسازی‌شده را با [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) نگه دارید و با [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) دوباره بارگذاری کنید. هنگام گنجاندن همه سلول‌ها، برای بازیابی بازهٔ کامل شامل دستهٔ مخفی فوریه، از [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) نیز استفاده کنید. فقط تغییر پرچم کافی نیست تا داده‌های کش‌شدهٔ این نمونه و برچسب‌های دسته بروز شوند.

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

            # تازه‌سازی داده‌های نمودار از کتاب‌کار جاسازی‌شده.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # بازگرداندن بازهٔ منبع کامل، شامل دسته‌های مخفی.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

مثال دو نسخه از ارائه را ذخیره می‌کند: یکی فقط با مقادیر خرده‌فروشی قابل مشاهده (10 و 20) و دیگری با همهٔ شش مقدار. تصاویر زیر از ارائه‌های ذخیره‌شده بعد از بازگشایی آن‌ها رندر شده‌اند؛ هر دو فایل تنظیم رسم اختصاص داده‌شده خود را حفظ می‌کنند. ردیف 3 و ستون C در هر دو کتاب‌کار جاسازی‌شده مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`True`) | همه سلول‌ها (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول مخفی که مقدار دارد با یک سلول خالی متفاوت است. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) کنترل می‌کند مقادیر گمشده چگونه نمایش داده شوند؛ این تنظیم شامل یا حذف دادهٔ منبع مخفی نمی‌شود. برای مثال به [کنترل نمایش سلول‌های خالی](/slides/fa/python-net/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **بازیابی بازهٔ دادهٔ نمودار**

قبل از به‌روزرسانی داده‌های کتاب‌کار در یک ارائهٔ موجود، بازه‌های منبع را برای شناسایی سلول‌های کاربرگی که هر نمودار استفاده می‌کند، بررسی کنید. متد [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) بازهٔ دادهٔ فعلی را به‌صورت فرمول qualified با کاربرگ برمی‌گرداند، مانند `Sheet1!$A$1:$D$5`. در اینجا، `Sheet1` نام کاربرگ است، `!` آن را از بازهٔ سلولی جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را (به‌صورت شامل) مشخص می‌کند. علامت دلار نشان‌دهنده مراجع مطلق ردیف و ستون است.

این متد بازهٔ فعلی را می‌خواند بدون اینکه نمودار یا کتاب‌کار آن را تغییر دهد. اگر نمودار از کتاب‌کاری به عنوان منبع داده استفاده نکند، استثنایی صادر می‌شود. برای اطلاعات بیشتر به [مرجع API ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) مراجعه کنید.

این مثال یک ارائه را باز می‌کند و شکل‌های موجود در هر اسلاید را برای نمودارها بررسی می‌کند. نام هر نمودار و بازهٔ منبع آن را چاپ می‌کند. اگر بازه نتواند بازیابی شود، پیام تشخیصی چاپ می‌کند و به نمودار بعدی ادامه می‌دهد.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides برای Python از طریق .NET متدهای [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) را فراهم می‌کند که به شما اجازه می‌دهد کتاب‌کارهای دادهٔ نمودار (حاوی داده‌های ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که داده‌های نمودار باید به همان شیوه سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این مثال از یک ارائه با نموداری به‌عنوان اولین شکل در اسلاید اول استفاده می‌کند. کتاب‌کار جاسازی‌شده را به یک جریان می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را دوباره می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

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

### **اعتبارسنجی چیدمان نمودار پس از تغییر کتاب‌کار**

وقتی کتاب‌کار جاسازی‌شده با یک کتاب‌کار اصلاح‌شده جایگزین می‌شود، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند منجر به خطای «index‑out‑of‑range» در [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) شود. قبل از نوشتن کتاب‌کار بروز‑شده به نمودار، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک نمودار که اولین شکل در اسلاید اول است استفاده می‌کند. نظرات محل ویرایش کتاب‌کار را نشان می‌دهند؛ مثال قابل اجرای اصلی کتاب‌کار را باز می‌نویسد و چیدمان را در حافظه اعتبارسنجی می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # جریان کتاب‌کار را در اینجا تغییر دهید، به عنوان مثال با استفاده از Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

پاک‌سازی مجموعه‌ها قبل از نوشتن کتاب‌کار باعث حذف ارجاعات دادهٔ منقضی می‌شود. پیش از استفاده از نمودار، سری‌ها و نگاشت‌های دستهٔ موردنیاز برای کتاب‌کار بروز‑شده را بازسازی کنید.

## **تنظیم یک سلول کتاب‌کار به‌عنوان برچسب دادهٔ نمودار**

می‌توانید از متن سلول‌های کتاب‌کار به‌عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با داده‌های پیش‌فرض به اسلاید اول یک ارائهٔ موجود اضافه می‌کند. از سلول‌های A10:A12 در کاربرگ 0 برای اولین سه برچسب در اولین سری استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌کند و ارائهٔ به‌روز شده را ذخیره می‌کند.

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

## **مدیریت کاربرگ‌ها**

ویژگی [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) دسترسی به کاربرگ‌های موجود در یک کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و نام هر کاربرگ را به کنسول چاپ می‌کند.

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

این مثال یک نمودار ستونی ۳‑بعدی با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع دادهٔ متفاوت تنظیم می‌کند. نام اول از یک مقدار رشته‌ای استفاده می‌کند؛ نام دوم از سلول C1 در کاربرگ 0 استفاده می‌کند. شمارندهٔ [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) منبع هر نام را انتخاب می‌کند. مثال ارائه را با نام‌های سری بروز‑شده ذخیره می‌کند.

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

## **تشخیص فرمت‌های کتاب‌کار جاسازی‌شدهٔ نام پشتیبانی‌شده**

Aspose.Slides فرمت کتاب‌کار باینری Excel (.xlsb) را که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید از ویژگی [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) بر روی [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) به همراه شمارندهٔ [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) برای تشخیص فرمت‌های نام پشتیبانی‌شده استفاده کنید و آن نمودارها را صرف‌نظر کنید. این مثال شکل‌های اسلاید اول یک ارائهٔ موجود را بررسی می‌کند، شکل‌های غیرنموداری را نادیده می‌گیرد و برای هر نمودار دارای کتاب‌کار .xlsb جاسازی‌شده، پیام تشخیصی می‌نویسد.

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

        # خواندن یا اصلاح داده‌های کتاب‌کار نمودار پشتیبانی‌شده در اینجا.
```

## **کتاب‌کار خارجی**

Aspose.Slides استفاده از کتاب‌کارهای خارجی را به‌عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) برای استخراج یک کتاب‌کار نمودار جاسازی‌شده به فایل و پیوست نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد کرده و کتاب‌کار آن را صادر می‌کند. قبل از اختصاص کتاب‌کار خارجی به عنوان منبع دادهٔ نمودار، جریان خروجی را می‌بندد و سپس ارائهٔ پیوست‌شده را ذخیره می‌کند.

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

### **تنظیم یک کتاب‌کار خارجی**

با استفاده از متد [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) می‌توانید یک کتاب‌کار خارجی را به یک نمودار به‌عنوان منبع دادهٔ آن اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورتی که کتاب‌کار جابه‌جا شده باشد) استفاده شود.

در حالی که نمی‌توانید داده‌ها را در کتاب‌کارهای ذخیره‌شده در مکان‌های دوردست یا منابع ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک کتاب‌کار خارجی استفاده می‌کند که کاربرگ آن با نام `Sheet1` شامل یک نام سری در B1، نام‌های دسته در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار دایره‌ای می‌سازد، کتاب‌کار را پیوست می‌کند و با استفاده از [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) بازهٔ A1:B4 را به یک سری و سه دسته نگاشت می‌کند. سپس ارائهٔ حاوی نمودار پیوست‌شده را ذخیره می‌کند.

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

پارامتر `update_chart_data` متد [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) کنترل می‌کند که آیا کتاب‌کار بارگذاری شود یا نه.

* وقتی `update_chart_data` برابر `False` باشد، فقط مسیر کتاب‌کار به‌روز می‌شود. دادهٔ نمودار از کتاب‌کار هدف بارگذاری یا بروز نمی‌شود، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
* وقتی `update_chart_data` برابر `True` باشد، دادهٔ نمودار از کتاب‌کار هدف بروز می‌شود.

مثال زیر یک URL placeholder را با `update_chart_data` برابر `False` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شود و ارائه بدون بارگذاری کتاب‌کار غیرقابل دسترس ذخیره می‌شود.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **دریافت مسیر کتاب‌کار منبع دادهٔ خارجی یک نمودار**

برای شناسایی کتاب‌کار پیوست‌شده به یک نمودار، بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کتاب‌کار آن را بازیابی کنید.

این مثال اولین شکل در اسلاید اول یک ارائه با کتاب‌کار خارجی پیوست‌شده را بررسی می‌کند. اگر این شکل یک نمودار پیوست‌شده به کتاب‌کار خارجی باشد، مثال [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) را در کنسول چاپ می‌کند. سپس یک نسخهٔ کپی از ارائه را ذخیره می‌کند.

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

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همان‌طور که داده‌های کتاب‌کارهای داخلی را ویرایش می‌کنید، تغییر دهید. وقتی یک کتاب‌کار خارجی قابل بارگذاری نباشد، استثنایی صادر می‌شود.

این مثال از یک نمودار که اولین شکل در اسلاید اول است و به یک کتاب‌کار خارجی قابل دسترس پیوست شده استفاده می‌کند. مقدار پشتیبانی‌شده توسط سلول اولین نقطه داده در اولین سری را به 100 تنظیم کرده و ارائهٔ بروز شده را ذخیره می‌کند. ویرایش مقادیر سلول می‌تواند فایل XLSX خارجی پیوست‌شده را بروز کند، بنابراین اگر نیاز به حفظ کتاب‌کار اصلی دارید، از یک نسخهٔ کپی استفاده کنید.

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

### **بازیابی کتاب‌کار از کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی که گمشده یا در دسترس نیست استفاده می‌کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. قبل از باز کردن ارائه، یک [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) ایجاد کنید، ویژگیٔ [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/) آن را پیکربندی کنید و [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) را به `True` تنظیم کنید.

مثال پایتون زیر داده‌های کتاب‌کار را برای یک نمودار که اولین شکل در اسلاید اول است و به یک کتاب‌کار خارجی در دسترس نیست، باز می‌گرداند. داده‌های بازیابی‌شده از طریق [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) و [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) دسترسی پیدا می‌شود:

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

        # در اینجا داده‌های کتاب‌کار بازیابی‌شده را بخوانید یا اصلاح کنید.
    else:
        print("The first shape is not a chart.")
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنایی صادر می‌کند. بازیابی را فقط زمانی فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار گزینهٔ قابل قبولی باشد، زیرا کش ممکن است شامل تغییرات انجام‌شده در کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه نشود.

## **سوالات متداول**

**آیا می‌توانم تشخیص دهم که یک نمودار خاص به یک کتاب‌کار خارجی یا جاسازی‌شده پیوست شده است؟**

بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) و یک [مسیر به یک کتاب‌کار خارجی](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر یک مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابه‌جایی کتاب‌کار ممکن است نیاز به به‌روزرسانی لینک داشته باشد.

**آیا می‌توانم از کتاب‌کارهایی که در منابع/به‌اشتراک‌گذاری‌های شبکه‌ای قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای دوردست از Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [لینک به فایل خارجی](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) را ذخیره می‌کند. ویرایش داده‌های نمودار پشتیبانی‌شده توسط سلول می‌تواند فایل XLSX محلی پیوست‌شده را نیز بروز کند. اگر نسخهٔ اصلی باید دست‌نخورده بماند، یک کپی از کتاب‌کار استفاده کنید.

**اگر فایل خارجی با گذرواژه محافظت شود، چه کاری باید انجام دهم؟**

Aspose.Slides هنگام پیوست‌کردن گذرواژه‌ای قبول نمی‌کند. رویکرد معمول این است که قبل از این کار محافظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده (به‌عنوان مثال با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) تهیه کنید و به آن نسخه پیوست کنید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی ارجاع دهند؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در تمام نمودارها منعکس می‌شود.