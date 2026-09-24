---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها با Python
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/python-net/chart-workbook/
keywords:
- کتاب‌کار نمودار
- داده نمودار
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
description: "Aspose.Slides برای Python از طریق .NET را کشف کنید: به راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنیم. این مقاله نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های کاربرگ دسترسی پیدا کنید و نوع منبع داده را برای مقادیر نمودار مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی مرتبط با یک نمودار را بازیابی کنید و داده‌های نمودار را زمانی که کتاب‌کار در دسترس است ویرایش کنید.

برای سلول‌های کتاب‌کاری که نشانگر داده‌های گمشده هستند، به [Control the Display of Empty Cells](/slides/fa/python-net/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر، و مقایسه نمودار خطی حالت‌های نمایش موجود را ببینید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides روش‌هایی برای خواندن و نوشتن کتاب‌کارهای داده نمودار فراهم می‌کند (که شامل داده‌های نمودار ویرایش‌شده با Aspose.Cells هستند). **Note:** داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

کد Python زیر یک عملیات نمونه را نشان می‌دهد:
```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

### **اعتبارسنجی چیدمان نمودار پس از تغییر کتاب‌کار**

زمانی که یک کتاب‌کار جاسازی‌شده را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار مجموعه‌های سری و دسته‌بندی اصلی خود را حفظ می‌کند. این ناسازگاری می‌تواند باعث شود [IChart.validate_chart_layout](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichart/validate_chart_layout/) با خطای out-of-range شاخص شکست بخورد. قبل از نوشتن کتاب‌کار به‌روز شده به نمودار، سری‌ها و دسته‌بندی‌های موجود را پاک کنید.
```python
# پس از اصلاح جریان کتاب‌کار (مثلاً با استفاده از Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# پاک‌سازی مراجع داده‌های موجود.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

پاک‌سازی مجموعه‌ها اطمینان می‌دهد که ساختار داده‌های نمودار با کتاب‌کار جدید سازگار است و `validate_chart_layout` بدون خطا تکمیل می‌شود.

## **تنظیم یک سلول کتاب‌کار به عنوان برچسب داده نمودار**

گاهی اوقات به برچسب‌های نمودار نیاز دارید که مستقیماً از سلول‌های کتاب‌کار داده زیرین آمده باشند. Aspose.Slides امکان بایند کردن برچسب‌های داده به سلول‌های خاص کتاب‌کار را می‌دهد تا متن برچسب همیشه مقدار سلول را نشان دهد. مثال زیر نشان می‌دهد چگونه برچسب‌های مقدار-از-سلول را فعال کنید و برچسب‌های انتخاب‌شده را به سلول‌های سفارشی در کتاب‌کار نمودار اشاره دهید.

1. یک نمونه از کلاس [Presentation](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، مرجع اسلاید را دریافت کنید.
1. یک نمودار حبابی با داده‌های نمونه اضافه کنید.
1. سری‌های نمودار را دسترسی پیدا کنید.
1. از یک سلول کتاب‌کار به عنوان برچسب داده استفاده کنید.
1. ارائه (Presentation) را ذخیره کنید.

کد Python زیر نشان می‌دهد چگونه یک سلول کتاب‌کار را به عنوان برچسب داده نمودار تنظیم کنید:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

# نمونه‌سازی کلاس Presentation که یک فایل ارائه را نمایندگی می‌کند.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **مدیریت کاربرگ‌ها**

کد Python زیر نشان می‌دهد چگونه از ویژگی `worksheets` برای دسترسی به مجموعه کاربرگ‌ها استفاده کنید:
```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **مشخص کردن نوع منبع داده**

کد Python زیر نشان می‌دهد چگونه نوع منبع داده را مشخص کنید:
```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **شناسایی قالب‌های کتاب‌کار جاسازی‌شده نام پشتیبانی‌شده**

Aspose.Slides از قالب کتاب‌کار باینری Excel (.xlsb) که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید از ویژگی `embedded_workbook_type` در [ChartData](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/workbooktype/) برای شناسایی قالب‌های نام پشتیبانی‌شده و عبور از آن نمودارها استفاده کنید.
```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # کتاب‌کار جاسازی‌شده در قالب .xlsb است که پشتیبانی نمی‌شود.
            continue

        # داده‌های کتاب‌کار نمودار را اینجا بخوانید یا اصلاح کنید.
```

## **کتاب‌کارهای خارجی**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **تنظیم کتاب‌کارهای خارجی**

با استفاده از روش [ChartData.set_external_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/set_external_workbook/) می‌توانید یک کتاب‌کار خارجی را به عنوان منبع داده یک نمودار اختصاص دهید. این روش همچنین می‌تواند مسیر یک کتاب‌کار خارجی را به‌روزرسانی کند اگر جابجا شده باشد.

اگرچه نمی‌توانید داده‌ها را در کتاب‌کارهای ذخیره‌شده در مکان‌های دوردست یا منابع ویرایش کنید، همچنان می‌توانید از آن کتاب‌کارها به عنوان منابع داده خارجی استفاده کنید. اگر مسیر نسبی برای یک کتاب‌کار خارجی ارائه دهید، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

کد Python زیر نشان می‌دهد چگونه یک کتاب‌کار خارجی تنظیم کنید:
```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # False را پاس می‌کنیم تا فقط مسیر ذخیره شود: کتاب‌کار هدف هنوز لازم نیست وجود داشته باشد.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

پارامتر `update_chart_data` روش [set_external_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/set_external_workbook/) مشخص می‌کند که آیا کتاب‌کار Excel بارگذاری خواهد شد یا نه.

- وقتی `update_chart_data` روی `False` تنظیم شود، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود؛ داده‌های نمودار از کتاب‌کار هدف بارگذاری یا تازه‌سازی نمی‌شوند. از این تنظیم وقتی که کتاب‌کار هدف وجود نداشته باشد یا در دسترس نباشد استفاده کنید.
- وقتی `update_chart_data` روی `True` (پیش‌فرض) تنظیم شود، داده‌های نمودار از کتاب‌کار هدف بارگذاری و به‌روز می‌شوند. اگر آن کتاب‌کار باز نشود، استثنائی با پیام "External workbook is not available" رخ می‌دهد.

### **ایجاد کتاب‌کارهای خارجی**

با استفاده از روش‌های [read_workbook_stream](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و [set_external_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/set_external_workbook/) می‌توانید یا یک کتاب‌کار خارجی را از ابتدا ایجاد کنید یا یک کتاب‌کار داخلی را به یک کتاب‌کار خارجی تبدیل کنید.

کد Python زیر فرآیند ایجاد کتاب‌کار خارجی را نشان می‌دهد:
```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **دریافت مسیر کتاب‌کار منبع داده خارجی برای یک نمودار**

گاهی داده‌های یک نمودار به یک کتاب‌کار Excel خارجی مرتبط هستند نه به داده‌های جاسازی‌شده ارائه. با Aspose.Slides می‌توانید منبع داده نمودار را بررسی کرده و اگر کتاب‌کاری خارجی باشد، مسیر کامل کتاب‌کار را بخوانید.

1. یک نمونه از کلاس [Presentation](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را با اندیس آن دریافت کنید.
1. مرجع شکل نمودار را دریافت کنید.
1. منبع ([ChartDataSourceType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatasourcetype/)) که نشان‌دهنده منبع داده نمودار است را به‌دست آورید.
1. بررسی کنید آیا نوع منبع با نوع منبع داده کتاب‌کار خارجی مطابقت دارد یا نه.

کد Python زیر عملیات را نشان می‌دهد:
```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **ویرایش داده‌های نمودار**

شما می‌توانید داده‌ها را در کتاب‌کارهای خارجی همانند کتاب‌کارهای داخلی ویرایش کنید. اگر کتاب‌کار خارجی بارگذاری نشود، استثنائی رخ می‌دهد.
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **بازیابی کتاب‌کار از کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی استفاده می‌کند که گم شده یا در دسترس نیست، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. ابتدا [LoadOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/) ایجاد کنید، سپس ویژگی [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/fa/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) را از طریق [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/spreadsheet_options/) قبل از باز کردن ارائه فعال کنید.

مثال Python زیر یک ارائه را که نمودار آن به کتاب‌کار خارجی در دسترس نیست ارجاع می‌دهد باز می‌کند و داده‌های بازیابی شده را از طریق [Chart.chart_data](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/chart_data/) و [ChartData.chart_data_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) دسترسی می‌دهد:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # داده‌های کتاب‌کار بازیابی‌شده را اینجا بخوانید یا اصلاح کنید.
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides یک استثنا ایجاد می‌کند. بازیابی را تنها زمانی فعال کنید که استفاده از داده‌های کش‌شده نمودار گزینه قابل قبولی باشد، زیرا کش ممکن است تغییرات اعمال‌شده به کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه را نداشته باشد.

## **سوالات متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به یک کتاب‌کار خارجی یا جاسازی‌شده مرتبط است؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/data_source_type/) و [path to an external workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/external_workbook_path/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا اطمینان حاصل کنید که از یک فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این ویژگی برای قابلیت حمل پروژه مفید است؛ اما توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌کارهای قرار گرفته بر روی منابع/به‌اشتراک‌گذاری‌های شبکه استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به عنوان منبع داده خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای دوردست از Aspose.Slides پشتیبانی نمی‌شود—آنها فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیره‌سازی ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

فقط در صورتی که داده‌های نمودار را ویرایش کرده باشید. ارائه یک [link to the external file](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/external_workbook_path/) را ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند، بنابراین باز کردن و ذخیره‌سازی ارائه فایل کتاب‌کار را دست نخورده می‌گذارد. اما مقادیری که از طریق داده‌های نمودار (به مثال، بخش ویرایش داده‌های نمودار) تغییر می‌دهید، هنگام ذخیره‌سازی ارائه به کتاب‌کار خارجی نوشته می‌شوند—اگر باید نسخه اصلی دست نخورده بماند، روی یک کپی کار کنید.

**اگر فایل خارجی با رمز محافظت شده باشد باید چه کنم؟**

Aspose.Slides هنگام ایجاد لینک، رمز عبور را قبول نمی‌کند. یک روش متداول این است که حفاظت را از پیش حذف کنید یا یک نسخه رمزگشایی‌شده تهیه کنید (به‌عنوان مثال با استفاده از [Aspose.Cells](/cells/python-net/)) و به آن نسخه لینک دهید.

**آیا چند نمودار می‌توانند به یک کتاب‌کار خارجی یکسان ارجاع دهند؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در هر نمودار منعکس می‌شود.