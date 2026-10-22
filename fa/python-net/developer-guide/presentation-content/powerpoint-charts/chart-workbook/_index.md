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
- کاربرگ
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب‌کار
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "Aspose.Slides برای پایتون از طریق .NET را کشف کنید: با سهولت کتاب‌کارهای نمودار را در قالب‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به‌عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های کاربرگ دسترسی داشته باشید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین به کار با کتاب‌کارهای خارجی به‌عنوان منابع داده برای نمودارها می‌پردازد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی پیوند شده به یک نمودار را دریافت کنید و داده‌های نمودار را هنگامی که کتاب‌کار در دسترس باشد، ویرایش کنید.

برای سلول‌های کتاب‌کار که داده‌های گمشده را نشان می‌دهند، به [کنترل نمایش سلول‌های خالی](/slides/fa/python-net/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر و مقایسه‌ای خطی از حالت‌های نمایش موجود را ببینید.

## **شامل کردن داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) برای کنترل اینکه آیا نمودار داده‌ها را از ردیف‌ها و ستون‌های مخفی کاربرگ رسم کند یا خیر استفاده کنید. آن را به `True` تنظیم کنید تا فقط سلول‌های قابل مشاهده رسم شوند، یا به `False` تا هم سلول‌های قابل مشاهده و هم مخفی شامل شوند. این تنظیم فقط رسم نمودار را کنترل می‌کند؛ ردیف یا ستون‌های کاربرگ را مخفی یا آشکار نمی‌کند.

[پیشنمایش نمونه](hidden-source-data.pptx) شامل یک نمودار ستونی به‌عنوان اولین شکل در اسلاید اول است. کاربرگ جاسازی‌شده، `Sheet1`، دارای بازه منبع زیر است: `A1:C4`. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آن‌ها همچنان مقدار دارند.

| ردیف کاربرگ | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) دسترسی پیدا کنید و با خواندن [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) وضعیت مخفی بودن آن‌ها را بررسی کنید. این ویژگی فقط خواندنی است. در این مثال، B2 قابل مشاهده است، B3 متعلق به ردیف مخفی است و C2 متعلق به ستون مخفی؛ مثال مقادیر `False`، `True` و `True` را به ترتیب چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم رسم، داده‌های نمودار را تازه کنید: کتاب‌کار جاسازی‌شده را با [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) نگه دارید و با [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) دوباره بارگذاری کنید. هنگام شامل کردن تمام سلول‌ها، همچنین از [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) برای بازگرداندن بازه کامل، شامل دسته‌ٔ مخفی فوریه استفاده کنید. فقط تغییر پرچم برای تازه‌سازی داده‌های کش شدهٔ این نمونه کافی نیست.

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

            # تجدید داده‌های نمودار از کتاب‌کار جاسازی‌شده.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # بازگرداندن بازه منبع کامل، شامل دسته‌های مخفی.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

این مثال دو نسخه از ارائه را ذخیره می‌کند: یکی فقط با مقادیر خرده‌فروشی قابل مشاهده (10 و 20) و دیگری با تمام شش مقدار. تصاویر زیر از ارائه‌های ذخیره‌شده پس از بازگشایی آن‌ها رندر شده‌اند؛ هر دو فایل تنظیم رسم اختصاصی خود را حفظ می‌کنند. ردیف 3 و ستون C در هر دو کتاب‌کار جاسازی‌شده مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`True`) | تمام سلول‌ها (`False`) |
| --- | --- |
| ![فقط سلول‌های قابل مشاهده: مقدارهای خرده‌فروشی 10 و 20 برای ژانویه و مارس.](hidden_cells_True.png) | ![تمام سلول‌ها: مقدارهای خرده‌فروشی و عمده‌فروشی برای ژانویه، فوریه و مارس.](hidden_cells_False.png) |

یک سلول مخفی که دارای مقدار است با یک سلول خالی متفاوت است. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) کنترل می‌کند مقادیر گمشده چگونه نمایش داده شوند؛ این ویژگی داده‌های منبع مخفی را شامل یا حذف نمی‌کند. برای مثال به [کنترل نمایش سلول‌های خالی](/slides/fa/python-net/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **دریافت بازه داده‌های یک نمودار**

قبل از به‌روزرسانی داده‌های کتاب‌کار در یک ارائه موجود، بازه‌های منبع را بررسی کنید تا تشخیص دهید هر نمودار از کدام سلول‌های کاربرگ استفاده می‌کند. روش [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) بازه دادهٔ فعلی را به‌صورت فرمولی با تعیین کاربرگ برمی‌گرداند، مانند `Sheet1!$A$1:$D$5`. در اینجا، `Sheet1` نام کاربرگ است، `!` آن را از بازه سلولی جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را شامل می‌شود. علامت‌های دلار نشان دهندهٔ مراجع مطلق ردیف و ستون هستند.

این روش بازه فعلی را بدون تغییر نمودار یا کتاب‌کار می‌خواند. اگر نمودار از کتاب‌کاری به‌عنوان منبع داده استفاده نکند، استثنا تولید می‌کند. برای اطلاعات بیشتر به [مرجع API ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) مراجعه کنید.

این مثال یک ارائه را باز می‌کند و شکل‌ها را مستقیماً روی هر اسلاید برای پیدا کردن نمودارها بررسی می‌کند. نام هر نمودار و بازه منبع آن را چاپ می‌کند. اگر بازه قابل بازیابی نباشد، پیام تشخیص خطا چاپ می‌شود و به نمودار بعدی ادامه می‌دهد.

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

Aspose.Slides for Python via .NET روش‌های [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) را ارائه می‌دهد که امکان خواندن و نوشتن کتاب‌کارهای دادهٔ نمودار (حاوی داده‌های ویرایش‌شده با Aspose.Cells) را می‌دهند. **Note** داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این مثال یک ارائه با یک نمودار به‌عنوان اولین شکل در اسلاید اول را استفاده می‌کند. کتاب‌کار جاسازی‌شده را به یک جریان می‌خواند، سری‌ها و دسته‌ها را پاک می‌کند و همان کتاب‌کار را باز می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

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

هنگامی که کتاب‌کار جاسازی‌شده را با یک کتاب‌کار تغییر یافته جایگزین می‌کنید، نمودار کلکسیون‌های سری و دستهٔ اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شکست [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) با خطای out‑of‑range شود. پیش از نوشتن کتاب‌کار به‌روز شده، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک نمودار که اولین شکل در اسلاید اول است استفاده می‌کند. کامنت نشان می‌دهد جایی که ویرایش کتاب‌کار اتفاق می‌افتد؛ مثال اجرایی کتاب‌کار اصلی را باز می‌نویسد و طرح را در حافظه اعتبارسنجی می‌کند.

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

پاک‌سازی کلکسیون‌ها مراجع دادهٔ منسوخ را قبل از نوشتن کتاب‌کار حذف می‌کند. پیش از استفاده از نمودار، سری‌ها و نگاشت‌های دستهٔ لازم را برای کتاب‌کار به‌روز شده بازسازی کنید.

## **تنظیم قالب‌های عددی سفارشی برای سلول‌های کتاب‌کار**

از [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) برای کنترل نحوهٔ نمایش مقادیر عددی در کتاب‌کار جاسازی‌شدهٔ نمودار استفاده کنید. به‌عنوان مثال، ممکن است یک گزارش نیاز داشته باشد نرخ تبدیل به‌صورت درصد با چهار رقم اعشار و یک ضریب با پنج رقم اعشار نمایش داده شود. هر دو مقدار را عددی نگه دارید تا برای محاسبات و رسم نمودار در دسترس باشند.

یک قالب عددی تنها نمایش را تغییر می‌دهد، نه مقدار ذخیره‌شده. قالب `0.0000%` مقدار `0.125` را به‌صورت `12.5000%` نمایش می‌دهد؛ عدد ذخیره‌شده به `12.5` تبدیل نمی‌شود. به‌طور مشابه، `0.00000` مقدار `0.1234567` را به‌صورت `0.12346` نمایش می‌دهد بدون این‌که مقدار ذخیره‌شده گرد شود. اگر قالب سفارشی یک رشتهٔ خالی (`""`) باشد، از [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) استفاده می‌شود.

مثال زیر یک نمودار ستونی ایجاد می‌کند و سلول‌های آن را از طریق [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) دسترسی می‌دهد. در کاربرگ 0، B2 حاوی نرخ تبدیل و C2 حاوی ضریب است. هر دو سلول مقدارهای نمودار را تأمین می‌کنند. مثال همچنین برچسب‌های مقداری که به قالب‌های منبع لینک شده‌اند را فعال می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 270, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 20, 620, 210)
    chart.has_title = False

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00"
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A2", "Sample")
    chart.chart_data.categories.add(category_cell)

    percentage_cell = workbook.get_cell(0, "B2", 0.125)
    percentage_cell.custom_number_format = "0.0000%"
    percentage_name = workbook.get_cell(0, "B1", "Conversion rate")
    percentage_series = chart.chart_data.series.add(percentage_name, chart.type)
    percentage_series.data_points.add_data_point_for_bar_series(percentage_cell)

    precision_cell = workbook.get_cell(0, "C2", 0.1234567)
    precision_cell.custom_number_format = "0.00000"
    precision_name = workbook.get_cell(0, "C1", "Coefficient")
    precision_series = chart.chart_data.series.add(precision_name, chart.type)
    precision_series.data_points.add_data_point_for_bar_series(precision_cell)

    for series in chart.chart_data.series:
        label_format = series.data_points[0].label.data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = True

    presentation.save("CustomCellFormats.pptx", slides.export.SaveFormat.PPTX)
```

قالب‌های سلول کتاب‌کار جدا از قالب‌های تنظیم‌شده مستقیم بر محورها یا برچسب‌های داده هستند. در این مثال، هر برچسب مقدار سلول منبع خود را نمایش می‌دهد زیرا [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) فعال است و به دلیل اینکه [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) برابر `True` است، قالب عددی منبع را دنبال می‌کند. پس از ذخیره و بازگشایی ارائه، برچسب‌ها `12.5000%` و `0.12346` را نمایش می‌دهند، همان‌طور که در زیر نشان داده شده است. محور عمودی از قالب عددی خود `[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/)` با مقدار `0.00` استفاده می‌کند و [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) بر روی `False` تنظیم شده است.

برای قالب‌بندی مستقل یک برچسب داده، پرچم لینک به منبع آن را به `False` تنظیم کنید و [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) موردنظر را اختصاص دهید. این کار قالب سلول کتاب‌کار را تغییر نمی‌دهد. برای مثال، قالب مستقل `0.00` مقدار اول را به‌صورت `0.13` نمایش می‌دهد در حالی که B2 همچنان `12.5000%` را نشان می‌دهد. برای قالب‌بندی مستقیم برچسب‌ها به [برچسب‌های دادهٔ نمودار](/slides/fa/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) مراجعه کنید.

![نمودار ستونی با برچسب‌های لینک‌شده به منبع که `12.5000%` و `0.12346` را نشان می‌دهند و محوری عددی با قالب مستقل.](custom-cell-formats.png)

## **تنظیم یک سلول کتاب‌کار به عنوان برچسب داده نمودار**

می‌توانید از متن سلول‌های کتاب‌کار به‌عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با داده‌های پیش‌فرض به اسلاید اول یک ارائه موجود اضافه می‌کند. از سلول‌های A10:A12 در کاربرگ 0 برای اولین سه برچسب در سری اول استفاده می‌کند، برچسب‌های سلولی را فعال می‌کند و ارائه به‌روزشده را ذخیره می‌کند.

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

ویژگی [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) دسترسی به کاربرگ‌های موجود در کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض می‌سازد و نام هر کاربرگ را در کنسول چاپ می‌کند.

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

مقادیر نقطهٔ سری می‌توانند به‌صورت مستقیم به‌عنوان literals عددی ذخیره شوند. برای مثال کامل به [تنظیم مقادیر سری با literals عددی](/slides/fa/python-net/chart-series/#set-series-values-using-numeric-literals) مراجعه کنید. نوع منبع مقادیر نقطه‌ای مستقل از پیکربندی کتاب‌کار داخلی یا خارجی نمودار است؛ استفاده از literals عددی به‌تنهایی کتاب‌کار جاسازی‌شده را حذف نمی‌کند.

این مثال یک نمودار ستونی 3 بعدی با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع دادهٔ متفاوت تنظیم می‌کند. اولین نام از یک literal رشته‌ای استفاده می‌کند؛ دومین نام از سلول C1 در کاربرگ 0 استفاده می‌کند. شمارش [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) برای انتخاب منبع هر نام به‌کار گرفته می‌شود. مثال ارائه را با نام‌های سری به‌روزشده ذخیره می‌کند.

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

## **تشخیص فرمت‌های کتاب‌کار جاسازی‌شده پشتیبانی‌نشده**

Aspose.Slides فرمت کتاب‌کار باینری Excel (.xlsb) را که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از ویژگی [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) در [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) فرمت‌های پشتیبانی‌نشده را شناسایی کنید و آن نمودارها را کنار بگذارید. این مثال شکل‌های اسلاید اول یک ارائه موجود را بررسی می‌کند، شکل‌های غیرنموداری را رد می‌کند و برای هر نمودار دارای کتاب‌کار .xlsb یک پیام تشخیص خطا چاپ می‌کند.

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

## **کتاب‌کار خارجی**

Aspose.Slides استفاده از کتاب‌کارهای خارجی به‌عنوان منبع داده برای نمودارها را پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) برای استخراج کتاب‌کار جاسازی‌شدهٔ یک نمودار به فایل و پیوند نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض می‌سازد و کتاب‌کار آن را استخراج می‌کند. قبل از اختصاص کتاب‌کار خارجی به‌عنوان منبع دادهٔ نمودار، جریان خروجی را می‌بندد، سپس ارائهٔ پیوندشده را ذخیره می‌کند.

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

با استفاده از روش [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) می‌توانید یک کتاب‌کار خارجی را به‌عنوان منبع دادهٔ نمودار اختصاص دهید. این روش همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورت جابه‌جا شدن آن) استفاده شود.

اگرچه نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌های راه دور یا منابع را ویرایش کنید، می‌توانید همچنان از چنین کتاب‌کارهایی به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک کتاب‌کار خارجی استفاده می‌کند که کاربرگ آن به نام `Sheet1` شامل یک نام سری در B1، نام‌های دسته در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار دایره‌ای می‌سازد، کتاب‌کار را پیوند می‌دهد و از [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) برای نگاشت A1:B4 به یک سری و سه دسته استفاده می‌کند. ارائه با نمودار پیوندشده ذخیره می‌شود.

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

پارامتر `update_chart_data` روش [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) کنترل می‌کند که آیا کتاب‌کار بارگذاری شود یا خیر.

* هنگامی که `update_chart_data` برابر `False` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود. داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شوند، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
* هنگامی که `update_chart_data` برابر `True` باشد، داده‌های نمودار از کتاب‌کار هدف به‌روزرسانی می‌شوند.

مثال زیر یک URL جایگزین‌کننده با `update_chart_data` تنظیم‌شده روی `False` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شوند و ارائه بدون بارگذاری کتاب‌کار غیرقابل دسترس ذخیره می‌شود.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **دریافت مسیر کتاب‌کار منبع داده خارجی یک نمودار**

برای شناسایی کتاب‌کار پیوندشده به یک نمودار، بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کتاب‌کار آن را دریافت کنید.

این مثال اولین شکل در اسلاید اول یک ارائه با کتاب‌کار خارجی پیوندشده را بررسی می‌کند. اگر شکل یک نمودار پیوندشده به کتاب‌کار خارجی باشد، مثال [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) را در کنسول چاپ می‌کند. سپس یک کپی از ارائه را ذخیره می‌کند.

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

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همان‌گونه که داده‌های کتاب‌کارهای داخلی را ویرایش می‌کنید، تغییر دهید. وقتی کتاب‌کار خارجی قابل بارگذاری نباشد، استثنا رخ می‌دهد.

این مثال از یک نمودار که اولین شکل در اسلاید اول است و به یک کتاب‌کار خارجی قابل دسترس پیوند دارد استفاده می‌کند. مقدار پشتیبانی‌شده توسط سلول اولین نقطه دادهٔ اولین سری را به 100 تنظیم می‌کند و ارائه به‌روزشده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوندشده را به‌روزرسانی کند، بنابراین برای حفظ کتاب‌کار اصلی از یک کپی استفاده کنید.

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

### **بازیابی یک کتاب‌کار از حافظه‌سنجی نمودار**

اگر نموداری از یک کتاب‌کار خارجی که مفقود یا غیرقابل دسترس است استفاده کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش شده در ارائه بازسازی کند. قبل از باز کردن ارائه، یک [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) ایجاد کنید، [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/) آن را پیکربندی کنید و [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) را روی `True` تنظیم کنید.

مثال پایتون زیر داده‌های کتاب‌کار را برای یک نمودار که اولین شکل در اسلاید اول است و به یک کتاب‌کار خارجی غیرقابل دسترس ارجاع می‌دهد، بازیابی می‌کند. داده‌های بازیابی‌شده از طریق [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) و [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) دسترسی می‌شوند:

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

        # خواندن یا تغییر داده‌های کتاب‌کار بازیابی‌شده در اینجا.
    else:
        print("The first shape is not a chart.")
```

اگر کتاب‌کار خارجی غیرقابل دسترس باشد و بازیابی غیرفعال باشد، Aspose.Slides استثنا پرتاب می‌کند. بازیابی را فقط زمانی فعال کنید که استفاده از داده‌های کش شدهٔ نمودار یک گزینهٔ پذیرش‌پذیر باشد، زیرا کش ممکن است تغییرات انجام‌شده در کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه را نداشته باشد.

## **سؤالات متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به کتاب‌کار خارجی یا کتاب‌کار جاسازی‌شده پیوند دارد؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) و [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابه‌جایی کتاب‌کار ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از کتاب‌کارهای موجود در منابع/به‌اشتراک‌گذاری‌های شبکه استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌کارهای راه دور از طریق Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ذخیره می‌کند. ویرایش داده‌های نمودار پشتیبانی‌شده توسط سلول می‌تواند فایل XLSX محلی پیوندشده را نیز به‌روزرسانی کند. اگر فایل اصلی باید دست‌نخورده بماند، از یک کپی کتاب‌کار استفاده کنید.

**اگر فایل خارجی با رمز عبور محافظت شده باشد چه کاری باید انجام دهم؟**

Aspose.Slides هنگام پیوند نیازی به رمز عبور ندارد. یک روش معمول این است که پیش‌از‌به‌عمل آوردن حفاظت را انجام دهید یا یک کپی رمزگشایی‌شده (به‌عنوان مثال با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) تهیه کنید و به آن پیوند دهید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی ارجاع دهند؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در هر نمودار منعکس می‌شود.