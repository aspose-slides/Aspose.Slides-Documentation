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
- برگه کاری
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب‌کار
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "Aspose.Slides برای پایتون از طریق .NET را کشف کنید: به‌سادگی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های برگه‌های کاری دسترسی پیدا کنید، و نوع منبع داده را برای مقادیر نمودار تعیین کنید.

همچنین کار با کتاب‌کارهای خارجی به‌عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر یک کتاب‌کار خارجی مرتبط با یک نمودار را بازیابی کنید، و هنگام موجود بودن کتاب‌کار، داده‌های نمودار را ویرایش کنید.

برای سلول‌های کتاب‌کاری که نمایانگر داده‌های گمشده هستند، به [کنترل نمایش سلول‌های خالی](/slides/fa/python-net/chart-series/) مراجعه کنید تا تفاوت بین سلول خالی و صفر، و مقایسه خطوط نموداری برای حالت‌های نمایش موجود را ببینید.

## **گنجاندن داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) برای کنترل این‌که آیا یک نمودار داده‌ها را از ردیف‌ها و ستون‌های مخفی برگه کاری ترسیم کند یا نه استفاده کنید. آن را به `True` تنظیم کنید تا فقط سلول‌های قابل مشاهده ترسیم شوند، یا به `False` برای شامل کردن هر دو سلول قابل مشاهده و مخفی. این تنظیم فقط نمودار را تحت تأثیر قرار می‌دهد؛ ردیف‌ها یا ستون‌های برگه کاری را مخفی یا آشکار نمی‌کند.

[نمونه ارائه](hidden-source-data.pptx) شامل یک نمودار ستونی به‌عنوان اولین شکل در اسلاید اول است. برگه کاری جاسازی‌شده، `Sheet1`، بازه منبع زیر را دارد: `A1:C4`. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آن‌ها هنوز مقدار دارند.

| ردیف ورق کاری | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

به سلول‌های منبع از طریق [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) دسترسی پیدا کنید و برای بررسی وضعیت مخفی بودن آن‌ها از [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) استفاده کنید. این ویژگی فقط‑خواندنی است. در این فایل، B2 قابل مشاهده است، B3 متعلق به ردیف مخفی است، و C2 متعلق به ستون مخفی؛ مثال `False`، `True` و `True` را به ترتیب چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم ترسیم، داده‌های نمودار را تازه کنید: کتاب‌کار جاسازی‌شده را با [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) حفظ کنید و آن را با [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) دوباره بارگذاری کنید. هنگام گنجاندن همه سلول‌ها، از [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) نیز برای بازگرداندن بازه کامل، شامل دسته‌فیلد مخفی February، استفاده کنید. فقط تغییر پرچم کافی نیست تا داده‌های کش‌شدهٔ این نمونه و برچسب‌های دسته refresh شوند.

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
                # بازنشانی بازهٔ منبع کامل، شامل دسته‌های مخفی.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

این مثال دو نسخه از ارائه را ذخیره می‌کند: یکی فقط با مقادیر خرده‌فروشی قابل مشاهده (10 و 20)، و دیگری با تمام شش مقدار. تصاویر زیر پس از باز کردن مجدد ارائه‌های ذخیره‌شده رندر شده‌اند؛ هر دو فایل تنظیم ترسیم اختصاص داده‌شده خود را حفظ می‌کنند. ردیف 3 و ستون C در هر دو کتاب‌کار جاسازی‌شده مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`True`) | همه سلول‌ها (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول مخفی که مقدار دارد، با یک سلول خالی متفاوت است. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) کنترل می‌کند مقادیر گمشده چگونه نمایش داده شوند؛ این ویژگی مخفی بودن منبع داده را شامل یا حذف نمی‌کند. برای مثال به [کنترل نمایش سلول‌های خالی](/slides/fa/python-net/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **دریافت بازه داده‌ای نمودار**

قبل از به‌روزرسانی داده‌های کتاب‌کار در یک ارائهٔ موجود، بازه‌های منبع را بررسی کنید تا مشخص کنید هر نمودار از کدام سلول‌های برگه کاری استفاده می‌کند. متد [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) بازهٔ دادهٔ فعلی را به‌صورت فرمولی با شناسایی برگه کاری برمی‌گرداند، مثلاً `Sheet1!$A$1:$D$5`. در اینجا `Sheet1` نام برگه کاری است، `!` آن را از بازهٔ سلولی جدا می‌کند، و `$A$1:$D$5` سلول‌های A1 تا D5 را شامل می‌شود. علامت‌های دلار نشان‌دهندهٔ ارجاع مطلق به ردیف و ستون هستند.

این متد بازهٔ فعلی را بدون تغییر نمودار یا کتاب‌کار می‌خواند. اگر نمودار از کتاب‌کاری به‌عنوان منبع داده استفاده نکند، یک استثنا پرتاب می‌کند. برای اطلاعات بیشتر، به [مرجع API ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) مراجعه کنید.

این مثال یک ارائه را باز می‌کند و شکل‌ها را مستقیماً بر روی هر اسلاید برای پیدا کردن نمودارها بررسی می‌کند. نام هر نمودار و بازه منبع آن را چاپ می‌کند. اگر بازه قابل بازیابی نباشد، پیام تشخیص‌دهی چاپ می‌شود و به نمودار بعدی ادامه می‌دهد.

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

Aspose.Slides for Python via .NET متدهای [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) را فراهم می‌کند که به شما امکان می‌دهد کتاب‌کارهای دادهٔ نمودار (حاوی داده‌های ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **نکته** این است که دادهٔ نمودار باید به همان شکل یا ساختار مشابه منبع سازماندهی شود.

این مثال از یک ارائه با یک نمودار به‌عنوان اولین شکل در اسلاید اول استفاده می‌کند. کتاب‌کار جاسازی‌شده را به یک جریان می‌خواند، سری‌ها و دسته‌ها را پاک می‌کند، و همان کتاب‌کار را دوباره می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

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

### **اعتبارسنجی طرح‌بندی نمودار پس از اصلاح کتاب‌کار**

زمانی که یک کتاب‌کار جاسازی‌شده را با کتاب‌کاری اصلاح‌شده جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود که [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) با خطای out‑of‑range اندیس شکست بخورد. پیش از نوشتن کتاب‌کار به‌روز شده، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک نمودار که اولین شکل در اسلاید اول است استفاده می‌کند. نظرات محل ویرایش کتاب‌کار را نشان می‌دهند؛ مثال اجرایی کتاب‌کار اصلی را باز می‌نویسد و طرح‌بندی را در حافظه اعتبارسنجی می‌کند.

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

پاک‌سازی مجموعه‌ها قبل از نوشتن کتاب‌کار، مراجع داده‌های قدیمی را حذف می‌کند. قبل از استفاده از نمودار، هر سری و دسته‌ای که برای کتاب‌کار به‌روز شده نیاز است را بازسازی کنید.

## **تنظیم قالب‌های عددی سفارشی برای سلول‌های کتاب‌کار**

از [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) برای کنترل نمایش مقادیر عددی در کتاب‌کار جاسازی‌شدهٔ نمودار استفاده کنید. به‌عنوان مثال، ممکن است گزارشی نیاز به نرخ تبدیل به‌صورت درصد با چهار رقم اعشار و یک ضریب با پنج رقم اعشار داشته باشد. هر دو مقدار باید عددی باقی بمانند تا برای محاسبات و ترسیم نمودار در دسترس باشند.

قالب عددی تنها نمایش را تغییر می‌دهد، نه مقدار ذخیره‌شده. قالب `0.0000%` مقدار `0.125` را به‌صورت `12.5000%` نمایش می‌دهد؛ عدد ذخیره‌شده همچنان `0.125` است. به‌طور مشابه، `0.00000` مقدار `0.1234567` را به‌صورت `0.12346` نمایش می‌دهد بدون این‌که مقدار ذخیره‌شده رند شود. اگر قالب سفارشی یک رشتهٔ خالی (`""`) باشد، از [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) استفاده می‌شود.

مثال زیر یک نمودار ستونی ایجاد می‌کند و به سلول‌های آن از طریق [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) دسترسی پیدا می‌کند. در برگه کاری 0، B2 حاوی نرخ تبدیل و C2 حاوی ضریب است. هر دو سلول مقادیر نمودار را فراهم می‌کنند. مثال همچنین برچسب‌های مقدار را که به قالب‌های منبع پیوند دارند فعال می‌کند.

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

قالب‌های سلول کتاب‌کار جدا از قالب‌های تنظیم‌شده مستقیم بر روی محورها یا برچسب‌های داده هستند. در این مثال، هر برچسب مقدار سلول منبع خود را نمایش می‌دهد چون [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) فعال است و به دلیل [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) برابر با `True` قالب عددی منبع را دنبال می‌کند. پس از ذخیره و باز کردن مجدد ارائه، برچسب‌ها `12.5000%` و `0.12346` را نمایش می‌دهند، همان‌طور که در تصویر زیر دیده می‌شود. محور عمودی از قالب خود `[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/)` برابر با `0.00` استفاده می‌کند و [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) برابر با `False` است.

برای قالب‌بندی مستقل یک برچسب داده، پرچم پیوند به منبع آن را به `False` تنظیم کنید و `[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/)` دلخواه را اختصاص دهید. این کار قالب سلول کتاب‌کار را تغییر نمی‌دهد. به‌عنوان مثال، قالب مستقل `0.00` مقدار اول را به‌صورت `0.13` نمایش می‌دهد در حالی که B2 همچنان `12.5000%` را نشان می‌دهد. برای قالب‌بندی مستقیم برچسب‌ها به [برچسب‌های دادهٔ نمودار](/slides/fa/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) مراجعه کنید.

تصویر زیر پس از ذخیره و باز کردن مجدد ارائه رندر شده است:

![نمودار ستونی با برچسب‌های پیوند‌دار به منبع که 12.5000% و 0.12346 را نشان می‌دهند و محور عددی به‌صورت مستقل قالب‌بندی شده است.](custom-cell-formats.png)

## **استفاده از یک سلول کتاب‌کار به‌عنوان برچسب دادهٔ نمودار**

می‌توانید متن سلول‌های کتاب‌کار را به‌عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با داده‌های پیش‌فرض به اسلاید اول یک ارائهٔ موجود اضافه می‌کند. از سلول‌های A10:A12 در برگه کاری 0 برای اولین سه برچسب در اولین سری استفاده می‌کند، برچسب‌ها از سلول‌ها فعال می‌شود و ارائه به‌روز شده را ذخیره می‌کند.

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

## **مدیریت برگه‌های کاری**

خصوصیت [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) دسترسی به برگه‌های کاری در یک کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و نام هر برگه کاری را در کنسول چاپ می‌کند.

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

این مثال یک نمودار ستونی 3 بعدی با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع داده متفاوت تنظیم می‌کند. نام اول از یک رشتهٔ ثابت استفاده می‌کند؛ نام دوم از سلول C1 در برگه کاری 0 استفاده می‌کند. شمارندهٔ [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) منبع هر نام را انتخاب می‌کند. مثال ارائه را با نام‌های سری به‌روز شده ذخیره می‌کند.

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

## **تشخیص قالب‌های کتاب‌کار جاسازی‌شدهٔ پشتیبانی‌نشده**

Aspose.Slides قالب کتاب‌کار باینری Excel (.xlsb) را که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید از خصوصیت [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) در [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) همراه با شمارندهٔ [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) برای تشخیص قالب‌های پشتیبانی‌نشده استفاده کنید و آن نمودارها را رد کنید. این مثال شکل‌های اسلاید اول یک ارائهٔ موجود را بررسی می‌کند، شکل‌های غیرنمودار را رد می‌کند، و برای هر نموداری که کتاب‌کار .xlsb جاسازی‌شده دارد، پیام تشخیص چاپ می‌کند.

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

        # در اینجا داده‌های کتاب‌کار نمودار پشتیبانی‌شده را بخوانید یا اصلاح کنید.
```

## **کتاب‌کار خارجی**

Aspose.Slides پشتیبانی می‌کند از استفاده از کتاب‌کارهای خارجی به‌عنوان منبع داده برای نمودارها.

### **ایجاد یک کتاب‌کار خارجی**

از [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) برای استخراج کتاب‌کار نمودار جاسازی‌شده به یک فایل و پیوند نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و کتاب‌کار آن را صادر می‌نماید. قبل از اختصاص کتاب‌کار خارجی به عنوان منبع دادهٔ نمودار، جریان خروجی را می‌بندد، سپس ارائهٔ پیوندشده را ذخیره می‌کند.

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

با استفاده از متد [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) می‌توانید یک کتاب‌کار خارجی را به یک نمودار به‌عنوان منبع دادهٔ آن اختصاص دهید. این متد همچنین می‌تواند مسیر کتاب‌کار خارجی را به‌روزرسانی کند (اگر کتاب‌کار جابه‌جا شده باشد).

در حالی که نمی‌توانید داده‌ها را در کتاب‌کارهای ذخیره‌شده در مکان‌های دوردست یا منابع ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک کتاب‌کار خارجی استفاده می‌کند که برگه کاری آن به نام `Sheet1` شامل نام سری در B1، نام‌های دسته در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار دایره‌ای ایجاد می‌کند، کتاب‌کار را پیوند می‌دهد، و با استفاده از [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) بازه A1:B4 را به یک سری و سه دسته نگاشت می‌کند. ارائه با نمودار پیوندشده ذخیره می‌شود.

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

پارامتر `update_chart_data` در متد [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) تعیین می‌کند که آیا کتاب‌کار بارگذاری شود یا نه.

* وقتی `update_chart_data` برابر `False` باشد، فقط مسیر کتاب‌کار به‌روز می‌شود. داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روز نمی‌شوند، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
* وقتی `update_chart_data` برابر `True` باشد، داده‌های نمودار از کتاب‌کار هدف به‌روز می‌شوند.

مثال زیر یک URL جایگزین را با `update_chart_data` برابر `False` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شود و ارائه بدون بارگذاری کتاب‌کار در دسترس نیست ذخیره می‌شود.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **به‌دست آوردن مسیر کتاب‌کار منبع دادهٔ خارجی یک نمودار**

برای شناسایی کتاب‌کار پیوندشده به یک نمودار، بررسی کنید که آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کتاب‌کار آن را بازیابی کنید.

این مثال شکل اول در اسلاید اول یک ارائه را که کتاب‌کار خارجی پیوندشده دارد بررسی می‌کند. اگر یک نمودار پیوندشده به کتاب‌کار خارجی باشد، [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) را در کنسول چاپ می‌کند. سپس یک کپی از ارائه را ذخیره می‌کند.

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

می‌توانید داده‌های کتاب‌کارهای خارجی را همان‌طور که محتویات کتاب‌کارهای داخلی را ویرایش می‌کنید، تغییر دهید. وقتی کتاب‌کار خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

این مثال از یک نمودار که اولین شکل در اسلاید اول است و به یک کتاب‌کار خارجی دسترسی‌پذیر پیوند دارد استفاده می‌کند. مقدار پشتیبانی‌شده توسط سلول اولین نقطه داده در اولین سری را به 100 تنظیم می‌کند و ارائه به‌روز شده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوندشده را به‌روز کند، بنابراین در صورت نیاز به حفظ کتاب‌کار اصلی، از یک کاپی استفاده کنید.

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

### **بازیابی کتاب‌کار از حافظهٔ کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی که گم شده یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. قبل از باز کردن ارائه، یک [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) ایجاد کنید، [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/) آن را پیکربندی کنید، و [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) را به `True` تنظیم کنید.

مثال زیر به‌زبان پایتون کتاب‌کار داده‌ها را برای یک نمودار که اولین شکل در اسلاید اول است و به یک کتاب‌کار خارجی در دسترس نیست ارجاع می‌دهد، بازیابی می‌کند. داده‌های بازیابی‌شده از طریق [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) و [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) دسترسی پیدا می‌شود:

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

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides یک استثنا پرتاب می‌کند. فقط زمانی بازیابی را فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار گزینهٔ قابل قبولی باشد، زیرا کش ممکن است حاوی تغییرات انجام‑شده به کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه نباشد.

## **FAQ**

**آیا می‌توانم تشخیص دهم که یک نمودار خاص به کتاب‌کار خارجی یا جاسازی‌شده پیوند دارد؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) و یک [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابه‌جایی کتاب‌کار ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از کتاب‌کارهای قرارگیری در منابع/به‌اشتراک‌گذاری‌های شبکه استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای دوردست از Aspose.Slides پشتیبانی نمی‌شود—فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ذخیره می‌کند. ویرایش داده‌های نمودار پشتیبانی‌شده توسط سلول می‌تواند فایل XLSX محلی پیوندشده را نیز به‌روز کند. اگر کتاب‌کار اصلی باید بدون تغییر بماند، از یک کاپی استفاده کنید.

**اگر فایل خارجی با رمز عبور محافظت شده باشد، چه کار باید کنم؟**

Aspose.Slides هنگام پیوند، رمز عبور نمی‌پذیرد. رویکرد معمول این است که پیش از موارد، محافظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده (به‌عنوان مثال با [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) تهیه کنید و به آن پیوند دهید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی اشاره کنند؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همگی به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر نمودار در بارگذاری بعدی داده‌ها منعکس می‌شود.