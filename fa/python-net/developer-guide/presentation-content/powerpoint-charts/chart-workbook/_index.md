---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها با پایتون
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/python-net/chart-workbook/
keywords:
- کتاب‌کار نمودار
- داده نمودار
- سلول کتاب‌کار
- برچسب داده
- برگه‌کار
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب‌کار
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "Aspose.Slides برای پایتون از طریق .NET را کشف کنید: به سادگی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنیم. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانیم و بنویسیم، از سلول‌های کتاب‌کار به‌عنوان برچسب‌های داده نمودار استفاده کنیم، به مجموعه‌های شیت‌نامه دسترسی داشته باشیم و نوع منبع داده برای مقادیر نمودار را مشخص کنیم.

همچنین نحوه کار با کتاب‌کارهای خارجی به‌عنوان منبع داده برای نمودارها را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهیم، مسیر کتاب‌کار خارجی پیوست به یک نمودار را بازیابی کنیم و داده‌های نمودار را زمانی که کتاب‌کار در دسترس است ویرایش کنیم.

برای سلول‌های کتاب‌کاری که نمایانگر دادهٔ مفقود هستند، به [کنترل نمایش سلول‌های خالی](/slides/fa/python-net/chart-series/) برای تفاوت بین یک سلول خالی و صفر، و مقایسهٔ نمودار خطی از حالت‌های نمایش موجود مراجعه کنید.

## **درج داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) برای کنترل اینکه آیا یک نمودار داده‌ها را از ردیف‌ها و ستون‌های مخفی شیت‌نامه رسم کند یا نه استفاده کنید. مقدار `True` باعث می‌شود فقط سلول‌های قابل مشاهده رسم شوند و مقدار `False` هر دو سلول قابل مشاهده و مخفی را شامل می‌شود. این تنظیم فقط بر رسم نمودار تاثیر دارد؛ ردیف‌ها یا ستون‌های شیت‌نامه را مخفی یا نمایان نمی‌کند.

[نمونه ارائه](hidden-source-data.pptx) شامل یک نمودار ستونی است که به‌عنوان اولین شکل در اولین اسلاید قرار دارد. شیت‌نامهٔ جاسازی‌شده، `Sheet1`، شامل بازهٔ منبع زیر است: `A1:C4`. ردیف ۳ و ستون C مخفی هستند، اما سلول‌های آنها همچنان مقدار دارند.

| ردیف شیت | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

دسترسی به سلول‌های منبع از طریق [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) و خواندن [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) برای بررسی وضعیت مخفی بودن آنها امکان‌پذیر است. این ویژگی فقط‑خواندنی است. در این فایل، B2 قابل مشاهده است، B3 متعلق به ردیف مخفی است و C2 متعلق به ستون مخفی؛ مثال به ترتیب `False`، `True` و `True` را چاپ می‌کند.

در این مثال، پس از تغییر تنظیم رسم، داده‌های نمودار را تازه کنید: کتاب‌کار جاسازی‌شده را با [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) نگه دارید و با [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) دوباره بارگذاری کنید. هنگام دربر گرفتن تمام سلول‌ها، از [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) نیز برای بازگرداندن بازهٔ کامل، شامل دستهٔ مخفی فوریه، استفاده کنید. صرف تغییر پرچم کافی نیست تا داده‌های کش‌شدهٔ این نمونه و برچسب‌های دسته به‌روز شوند.

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

مثال دو نسخه از ارائه را ذخیره می‌کند: یکی فقط با مقادیر خرده‌فروشی قابل مشاهده (۱۰ و ۲۰) و دیگری با تمام شش مقدار. تصاویر زیر از ارائه‌های ذخیره‌شده پس از بازگشایش رندر شده‌اند؛ هر دو فایل تنظیم رسم اختصاصی خود را حفظ می‌کنند. ردیف ۳ و ستون C در هر دو کتاب‌کار جاسازی‌شده مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`True`) | تمام سلول‌ها (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول مخفی که دارای مقدار است با یک سلول خالی متفاوت است. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) کنترل می‌کند مقادیر مفقود چگونه نمایش داده شوند؛ این ویژگی منبع دادهٔ مخفی را شامل یا مستثنی نمی‌کند. برای مثال به [کنترل نمایش سلول‌های خالی](/slides/fa/python-net/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **استخراج بازه داده‌ای نمودار**

پیش از به‌روزرسانی داده‌های کتاب‌کار در یک ارائهٔ موجود، بازه‌های منبع را بررسی کنید تا مشخص کنید هر نمودار از کدام سلول‌های شیت‌نامه استفاده می‌کند. روش [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) بازهٔ دادهٔ فعلی را به‌صورت یک فرمول معتبر برای شیت‌نامه بازمی‌گرداند، برای مثال `Sheet1!$A$1:$D$5`. در اینجا `Sheet1` نام شیت‌نامه است، `!` آن را از بازهٔ سلولی جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 (شامل) را نشان می‌دهد. علامت دلار اشاره به ارجاع مطلق ردیف و ستون دارد.

این متد بازهٔ فعلی را بدون تغییر نمودار یا کتاب‌کار می‌خواند. اگر نمودار از کتاب‌کار به‌عنوان منبع داده استفاده نکند، استثنایی پرتاب می‌شود. برای اطلاعات بیشتر، به [مرجع API ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) مراجعه کنید.

این مثال یک ارائه را باز می‌کند و به‌طور مستقیم روی هر اسلاید شکل‌ها را برای نمودارها بررسی می‌کند. نام هر نمودار و بازهٔ منبع آن را چاپ می‌کند. اگر بازه قابل بازیابی نباشد، پیام تشخیص خطا را چاپ کرده و به نمودار بعدی ادامه می‌دهد.

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

## **خواندن و نوشتن داده‌های نمودار از کتاب‌کار**

Aspose.Slides for Python via .NET روش‌های [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) را فراهم می‌کند که به شما امکان خواندن و نوشتن کتاب‌کارهای دادهٔ نمودار (شامل داده‌های ویرایش‌شده با Aspose.Cells) را می‌دهد. **Note** که دادهٔ نمودار باید به همان شیوه سازماندهی شود یا ساختاری مشابه منبع داشته باشد.

این مثال از یک ارائه با یک نمودار به‌عنوان اولین شکل در اولین اسلاید استفاده می‌کند. کتاب‌کار جاسازی‌شده را به یک جریان می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را باز می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ این مثال ارائه را ذخیره نمی‌کند.

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

هنگامی که یک کتاب‌کار جاسازی‌شده را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) با خطای «اندیس خارج از محدوده» شکست بخورد. قبل از نوشتن کتاب‌کار به‌روز شده به نمودار، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک نمودار استفاده می‌کند که اولین شکل در اولین اسلاید است. نظرات نشان‌دهندهٔ جایی هستند که ویرایش کتاب‌کار قرار بود انجام شود؛ مثال قابل اجرا فقط کتاب‌کار اصلی را بازمی‌نویسد و چیدمان را در حافظه اعتبارسنجی می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # در اینجا جریان کتاب‌کار را اصلاح کنید، برای مثال با استفاده از Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

پاک کردن مجموعه‌ها مراجع دادهٔ منسوخ را پیش از نوشتن کتاب‌کار حذف می‌کند. قبل از استفاده از نمودار، هر سری و نگاشت دستهٔ مورد نیاز برای کتاب‌کار به‌روزشده را بازسازی کنید.

## **انتخاب روش ذخیره‌سازی برچسب‌های دسته**

در حالی که مجموعهٔ دسته خالی است، مقدار [ChartCategoryCollection.use_cells](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorycollection/use_cells/) را تنظیم کنید. برای برچسب‌هایی که به سلول‌های شیت‌نامه ارجاع می‌دهند یا سلسله‌مراتبی مانند فصول بر مبنای سال تشکیل می‌شوند، `True` تعیین کنید. برای یک سطح تک برچسب که به‌صورت رشته ارائه می‌شود، `False` بگذارید. این تنظیم تنها برای دسته‌ها اعمال می‌شود. هر دو نمودار در مثال از سلول‌های شیت‌نامه برای مقادیر سری عددی خود استفاده می‌کنند.

مثال دو نمودار ستونی ایجاد می‌کند و حالت ذخیره‌سازی و برچسب‌های `Q1 Q2 Q3 Q4` هر کدام را چاپ می‌کند. برای برچسب‌های مبتنی بر سلول، [ChartCategory.as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/as_cell/) سلول شیت‌نامه را برمی‌گرداند و [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) برچسب ذخیره‌شده در آن را برمی‌گرداند. برای برچسب‌های صریح، مستقیماً رشته را از [ChartCategory.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/value/) بخوانید.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    for use_cells, x in [(True, 20), (False, 360)]:
        chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, x, 20, 320, 250)
        data = chart.chart_data
        data.series.clear()
        data.categories.clear()
        data.categories.use_cells = use_cells

        workbook = data.chart_data_workbook
        series_name = workbook.get_cell(0, 0, 1, "Sales")
        series = data.series.add(series_name, chart.type)
        for row in range(1, 5):
            label = f"Q{row}"
            if use_cells:
                label_cell = workbook.get_cell(0, row, 0, label)
                data.categories.add(label_cell)
            else:
                data.categories.add(label)

            value_cell = workbook.get_cell(0, row, 1, row * 10)
            series.data_points.add_data_point_for_bar_series(value_cell)

        labels = [category.as_cell.value if use_cells else category.value for category in data.categories]
        print(f"use_cells = {data.categories.use_cells}:", *labels)

    presentation.save("category-labels.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم قالب عددی سفارشی برای سلول‌های کتاب‌کار**

از [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) برای کنترل نحوهٔ نمایش مقادیر عددی در کتاب‌کار جاسازی‌شدهٔ یک نمودار استفاده کنید. به‌عنوان مثال، ممکن است گزارشی نیاز داشته باشد نرخ تبدیل را به‌صورت درصدی با چهار رقم اعشار و یک ضریب را با پنج رقم اعشار نمایش دهد. هر دو مقدار باید عددی باقی بمانند تا برای محاسبات و رسم نمودار در دسترس باشند.

یک قالب عددی نمایش را تغییر می‌دهد، نه مقدار ذخیره‌شده. قالب `0.0000%` عدد `0.125` را به‌صورت `12.5000%` نمایش می‌دهد؛ عدد ذخیره‌شده همچنان `0.125` است. به‌همین ترتیب، `0.00000` عدد `0.1234567` را به‌صورت `0.12346` نشان می‌دهد بدون اینکه مقدار ذخیره‌شده گرد شود. اگر قالب سفارشی یک رشتهٔ خالی (`""`) باشد، به‌جای آن از [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) استفاده می‌شود.

در مثال زیر یک نمودار ستونی ایجاد می‌شود و سلول‌های آن از طریق [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) دسترسی پیدا می‌کنند. در شیت‌نامهٔ ۰، B2 شامل نرخ تبدیل و C2 شامل ضریب است. هر دو سلول مقادیر نمودار را تامین می‌کنند. مثال همچنین برچسب‌های مقدار را فعال می‌کند که به قالب‌های منبع مرتبط هستند.

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

قالب‌های سلول کتاب‌کار جدا از قالب‌های مستقیم روی محورهای نمودار یا برچسب‌های داده هستند. در این مثال هر برچسب مقدار سلول منبع خود را نمایش می‌دهد چون [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) فعال است و به قالب عددی منبع پیوند دارد چون [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) `True` است. پس از ذخیره و بازگشایی ارائه، برچسب‌ها `12.5000%` و `0.12346` را نشان می‌دهند، همان‌طور که در زیر مشاهده می‌شود. محور عمودی از قالب عددی خود `[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/)` با مقدار `0.00` استفاده می‌کند و [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) برای آن `False` است.

برای قالب‌بندی مستقل یک برچسب داده، پرچم پیوند به منبع آن را `False` کنید و `[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/)` موردنظر را انتساب دهید. این کار قالب سلول کتاب‌کار را تغییر نمی‌دهد. برای مثال، قالب مستقل برچسب `0.00` مقدار اول را به‌صورت `0.13` نمایش می‌دهد، در حالی که B2 همچنان `12.5000%` را نشان می‌دهد. برای قالب‌بندی مستقیم برچسب‌ها به [برچسب‌های دادهٔ نمودار](/slides/fa/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) مراجعه کنید.

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **استفاده از سلول کتاب‌کار به‌عنوان برچسب دادهٔ نمودار**

می‌توانید از متن سلول‌های کتاب‌کار به‌عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با دادهٔ پیش‌فرض به اولین اسلاید یک ارائهٔ موجود اضافه می‌کند. از سلول‌های A10:A12 در شیت‌نامهٔ ۰ برای اولین سه برچسب در سری اول استفاده می‌کند، برچسب‌های سلولی را فعال می‌کند و ارائه به‌روزشده را ذخیره می‌نماید.

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

## **مدیریت شیت‌نامه‌ها**

ویژگی [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) دسترسی به شیت‌نامه‌های موجود در کتاب‌کار یک نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با دادهٔ پیش‌فرض ایجاد می‌کند و نام هر شیت‌نامه را در کنسول چاپ می‌کند.

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

مقادیر نقاط سری می‌توانند مستقیماً به‌صورت literals عددی ذخیره شوند. برای مثال کامل به [تنظیم مقادیر سری با literals عددی](/slides/fa/python-net/chart-series/#set-series-values-using-numeric-literals) مراجعه کنید. نوع منبع مقادیر نقاط مستقل از پیکربندی کتاب‌کار داخلی یا خارجی نمودار است؛ استفاده از literals عددی به خودی خود کتاب‌کار جاسازی‌شده را حذف نمی‌کند.

این مثال یک نمودار ستونی سه‌بعدی با دادهٔ پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع داده متفاوت تنظیم می‌کند. نام اول از یک literal رشته‌ای استفاده می‌کند؛ نام دوم از سلول C1 در شیت‌نامهٔ ۰ می‌آید. شمارش [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) منبع را برای هر نام انتخاب می‌کند. مثال ارائه را با نام‌های سری به‌روزشده ذخیره می‌کند.

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

## **تشخیص قالب‌های پشتیبانی‌نشدهٔ کتاب‌کار جاسازی‌شده**

Aspose.Slides از قالب کتاب‌کار باینری اکسل (.xlsb) که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از ویژگی [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) روی [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) قالب‌های پشتیبانی‌نشده را شناسایی کرده و آن نمودارها را نادیده بگیرید. این مثال شکل‌های اولین اسلاید یک ارائهٔ موجود را بررسی می‌کند، شکل‌های غیرنموداری را نادیده می‌گیرد و برای هر نمودار با کتاب‌کار .xlsb جاسازی‌شده پیام تشخیص خطا چاپ می‌کند.

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

        # در اینجا داده‌های کتاب‌کار پشتیبانی‌شدهٔ نمودار را بخوانید یا تغییر دهید.
```

## **کتاب‌کار خارجی**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به‌عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) برای استخراج یک کتاب‌کار نمودار جاسازی‌شده به یک فایل و پیوند نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با دادهٔ پیش‌فرض ایجاد می‌کند و کتاب‌کار آن را استخراج می‌کند. قبل از اختصاص کتاب‌کار خارجی به عنوان منبع دادهٔ نمودار، جریان خروجی را می‌بندد و سپس ارائهٔ پیوندشده را ذخیره می‌کند.

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

با استفاده از متد [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) می‌توانید یک کتاب‌کار خارجی را به یک نمودار به‌عنوان منبع دادهٔ خود اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (اگر کتاب‌کار به مکان دیگری منتقل شده باشد) استفاده شود.

در حالی که نمی‌توانید داده‌ها را در کتاب‌کارهایی که در مکان‌های دوردست یا منابع ذخیره شده‌اند ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی فراهم شود، به‌طور خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک کتاب‌کار خارجی استفاده می‌کند که شیت‌نامهٔ آن به نام `Sheet1` شامل یک نام سری در B1، نام‌های دسته در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار دایره‌ای ایجاد می‌کند، کتاب‌کار را پیوند می‌دهد و با استفاده از [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) بازهٔ A1:B4 را به یک سری و سه دسته نگاشت می‌کند. سپس ارائه را با نمودار پیوندشده ذخیره می‌کند.

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

پارامتر `update_chart_data` در متد [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) کنترل می‌کند آیا کتاب‌کار بارگذاری شود یا نه.

* زمانی که `update_chart_data` برابر با `False` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود. دادهٔ نمودار از کتاب‌کار هدف بارگذاری یا به‌روز نمی‌شود، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
* زمانی که `update_chart_data` برابر با `True` باشد، دادهٔ نمودار از کتاب‌کار هدف به‌روز می‌شود.

مثال زیر یک URL نگهدارنده را با `update_chart_data` تنظیم‌شده بر روی `False` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شوند و ارائه بدون بارگذاری کتاب‌کار در دسترس نیست ذخیره می‌شود.

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

برای شناسایی کتاب‌کار پیوست به یک نمودار، بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کتاب‌کار آن را بازیابی کنید.

این مثال اولین شکل در اولین اسلاید یک ارائه با کتاب‌کار خارجی پیوست را بررسی می‌کند. اگر شکل یک نمودار پیوست به کتاب‌کار خارجی باشد، مثال مسیر [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) را در کنسول چاپ می‌کند. سپس یک کپی از ارائه را ذخیره می‌کند.

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

### **ویرایش دادهٔ نمودار**

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همان‌طور که تغییرات را در محتویات کتاب‌کارهای داخلی اعمال می‌کنید، ویرایش کنید. وقتی کتاب‌کار خارجی قابل بارگذاری نباشد، استثنایی پرتاب می‌شود.

این مثال از یک نمودار استفاده می‌کند که اولین شکل در اولین اسلاید است و به یک کتاب‌کار خارجی قابل دسترس پیوست شده است. مقدار پشت سر سلول اولین نقطهٔ دادهٔ سری اول را به 100 تنظیم می‌کند و ارائه به‌روزشده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوست را به‌روز کند، بنابراین در صورت نیاز به حفظ کتاب‌کار اصلی از یک کپی استفاده کنید.

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

### **بازیابی یک کتاب‌کار از حافظهٔ کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی استفاده می‌کند که مفقود یا در دسترس نیست، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک شیء [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) ایجاد کنید، ویژگی [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/) آن را پیکربندی کنید و قبل از باز کردن ارائه مقدار [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) را روی `True` بگذارید.

مثال پایتون زیر داده‌های کتاب‌کار را برای یک نمودار که اولین شکل در اولین اسلاید است و کتاب‌کار خارجی غیرقابل دسترسی را ارجاع می‌دهد، بازیابی می‌کند. داده‌های بازیابی‌شده از طریق [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) و [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) دسترسی می‌شود:

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

        # در اینجا داده‌های کتاب‌کار بازیابی‌شده را بخوانید یا تغییر دهید.
    else:
        print("The first shape is not a chart.")
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنایی پرتاب می‌کند. بازیابی را تنها زمانی فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار به‌عنوان یک مسیر بازگشت قابل قبول باشد، زیرا کش ممکن است شامل تغییراتی که پس از آخرین به‌روزرسانی ارائه روی کتاب‌کار خارجی اعمال شده باشد، نباشد.

## **سؤالات متداول**

**آیا می‌توانم تشخیص دهم که یک نمودار خاص به یک کتاب‌کار خارجی یا جاسازی‌شده پیوست است؟**

بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) و یک [مسیر به کتاب‌کار خارجی](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابه‌جایی کتاب‌کار ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از کتاب‌کارهایی که روی منابع شبکه/به اشتراک‌گذاری‌ها قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای دوردست از طریق Aspose.Slides پشتیبانی نمی‌شود؛ آنها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه فقط یک [پیوند به فایل خارجی](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) را ذخیره می‌کند. ویرایش داده‌های نمودار مبتنی بر سلول می‌تواند فایل XLSX محلی پیوندشده را نیز به‌روزرسانی کند. اگر کتاب‌کار اصلی باید دست‌نخورده بماند، از یک کپی استفاده کنید.

**اگر فایل خارجی با رمز عبور محافظت شده باشد، چه کاری باید انجام دهم؟**

Aspose.Slides هنگام پیوندگیری رمز عبور قبول نمی‌کند. یک روش رایج این است که پیش از پیوند، محافظت را حذف کنید یا یک کپی رمزگشایی شده تهیه کنید (به‌عنوان مثال با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) و به آن کپی پیوند دهید.

**آیا می‌توان چندین نمودار را به یک کتاب‌کار خارجی ارجاع داد؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر نمودار در بارگذاری بعدی داده‌ها منعکس می‌شود.