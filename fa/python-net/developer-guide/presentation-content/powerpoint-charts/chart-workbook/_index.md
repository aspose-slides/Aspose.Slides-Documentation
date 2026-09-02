---
title: مدیریت کتاب کارهای نمودار در ارائه‌ها با پایتون
linktitle: کتاب کار نمودار
type: docs
weight: 70
url: /fa/python-net/chart-workbook/
keywords:
- کتاب کار نمودار
- داده‌های نمودار
- سلول کتاب کار
- برچسب داده
- برگه کاری
- منبع داده
- کتاب کار خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب کار
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "Aspose.Slides برای پایتون از طریق .NET را کشف کنید: به‌راحتی کتاب کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه‌تان را به‌صورت بهینه‌تری سازمان‌دهی کنید."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. نحوه خواندن و نوشتن داده‌های نمودار از طریق جریان‌های کتاب‌کار، استفاده از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار، دسترسی به مجموعه‌های Worksheet و تعیین نوع منبع داده برای مقادیر نمودار را توضیح می‌دهد.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی مرتبط با یک نمودار را به‌دست آورید و داده‌های نمودار را وقتی کتاب‌کار در دسترس باشد ویرایش کنید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب کار**

Aspose.Slides روش‌هایی برای خواندن و نوشتن کتاب‌کارهای داده نمودار (که حاوی داده‌های نمودار ویرایش‌شده با Aspose.Cells هستند) فراهم می‌کند. **Note:** داده‌های نمودار باید به همان شکل یا ساختاری مشابه منبع سازماندهی شوند.

کد پایتون نمونه زیر این عملیات را نشان می‌دهد:

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

## **تنظیم یک سلول WorkBook به عنوان برچسب داده نمودار**

گاهی نیاز به برچسب‌های نمودار دارید که مستقیماً از سلول‌های کتاب‌کار زیرین گرفته شوند. Aspose.Slides به شما امکان می‌دهد برچسب‌های داده را به سلول‌های مشخصی از کتاب‌کار بایند کنید تا متن برچسب همیشه مقدار سلول را بازتاب دهد. مثال زیر نشان می‌دهد چگونه برچسب‌های مقدار-از-سلول را فعال کنید و برچسب‌های انتخاب‌شده را به سلول‌های سفارشی در کتاب‌کار نمودار ارجاع دهید.

1. یک نمونه از کلاس [Presentation](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/) ایجاد کنید.  
1. با استفاده از شاخص، مرجع اسلاید را دریافت کنید.  
1. یک نمودار حبابی با داده‌های نمونه اضافه کنید.  
1. به سری‌های نمودار دسترسی پیدا کنید.  
1. از یک سلول کتاب کار به عنوان برچسب داده استفاده کنید.  
1. ارائه را ذخیره کنید.

کد پایتون زیر نحوه تنظیم یک سلول کتاب‌کار به عنوان برچسب داده نمودار را نشان می‌دهد:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
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

## **مدیریت صفحات کاری**

کد پایتون زیر نشان می‌دهد چگونه از ویژگی `worksheets` برای دسترسی به مجموعه Worksheetها استفاده کنید:

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

کد پایتون زیر نحوه مشخص کردن یک نوع منبع داده را نشان می‌دهد:

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

## **تشخیص فرمت‌های کتاب‌کار جاسازی شده نام پشتیبانی‌شده**

Aspose.Slides قالب کتاب‌کار باینری اکسل (.xlsb) را که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید از ویژگی `embedded_workbook_type` در [ChartData](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/) به همراه شمارش [WorkbookType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/workbooktype/) برای شناسایی فرمت‌های نام پشتیبانی‌شده و رد نمودارهای مربوط استفاده کنید.

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
            # کتاب‌کار جاسازی‌شده در فرمت .xlsb است که پشتیبانی نمی‌شود.
            continue

        # در اینجا داده‌های کتاب‌کار نمودار را بخوانید یا اصلاح کنید.
```

## **کتاب‌کارهای خارجی**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **تنظیم کتاب‌کارهای خارجی**

با استفاده از متد [ChartData.set_external_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/set_external_workbook/) می‌توانید یک کتاب‌کار خارجی را به یک نمودار به عنوان منبع داده‌اش اختصاص دهید. این متد همچنین می‌تواند مسیر کتاب‌کار خارجی را به‌روز کند اگر منتقل شده باشد.

اگرچه نمی‌توانید داده‌ها را در کتاب‌کارهای ذخیره‌شده در مکان‌های دوردست یا منابع ویرایش کنید، می‌توانید همچنان از این کتاب‌کارها به عنوان منابع داده خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه دهید، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

کد پایتون زیر نحوه تنظیم یک کتاب‌کار خارجی را نشان می‌دهد:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

پارامتر `update_chart_data` متد [set_external_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/set_external_workbook/) مشخص می‌کند که آیا کتاب‌کار اکسل بارگذاری شود یا خیر.

- وقتی `update_chart_data` برابر `False` باشد، فقط مسیر کتاب‌کار به‌روز می‌شود؛ داده‌های نمودار بارگیری یا تازه‌سازی نمی‌شوند. از این تنظیم زمانی استفاده کنید که کتاب‌کار هدف وجود نداشته باشد یا در دسترس نباشد.  
- وقتی `update_chart_data` برابر `True` باشد، داده‌های نمودار از کتاب‌کار هدف بارگیری و به‌روز می‌شوند.

### **ایجاد کتاب‌کارهای خارجی**

با استفاده از متدهای [read_workbook_stream](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و [set_external_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/set_external_workbook/) می‌توانید یا یک کتاب‌کار خارجی را از ابتدا ایجاد کنید یا یک کتاب‌کار داخلی را به کتاب‌کار خارجی تبدیل کنید.

این کد پایتون فرآیند ایجاد کتاب‌کار خارجی را نشان می‌دهد:

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

گاهی داده‌های یک نمودار به یک کتاب‌کار اکسل خارجی به جای داده‌های جاسازی‌شده در ارائه لینک می‌شود. با Aspose.Slides می‌توانید منبع داده نمودار را بررسی کنید و اگر کتاب‌کار خارجی باشد، مسیر کامل آن را بخوانید.

1. یک نمونه از کلاس [Presentation](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/) ایجاد کنید.  
1. با استفاده از شاخص، مرجع اسلاید را دریافت کنید.  
1. مرجع شکل نمودار را به‑دست آورید.  
1. منبع ([ChartDataSourceType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatasourcetype/)) که نمایانگر منبع داده نمودار است را دریافت کنید.  
1. بررسی کنید آیا نوع منبع با نوع منبع کتاب‌کار خارجی مطابقت دارد یا خیر.

کد پایتون زیر این عملیات را نشان می‌دهد:

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

می‌توانید داده‌ها را در کتاب‌کارهای خارجی به همان شکلی که در کتاب‌کارهای داخلی ویرایش می‌کنید، ویرایش کنید. اگر یک کتاب‌کار خارجی قابل بارگذاری نباشد، استثنا پرتاب می‌شود.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **بازیابی کتاب‌کار از حافظه موقت نمودار**

اگر یک نمودار از کتاب‌کار خارجی استفاده می‌کند که موجود نیست یا در دسترس نیست، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک شیء [LoadOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/) ایجاد کنید، سپس قبل از باز کردن ارائه، ویژگی [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/fa/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) را از طریق [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/spreadsheet_options/) فعال کنید.

مثال پایتون زیر یک ارائه را که نمودار آن به کتاب‌کار خارجی در دسترس نیست، باز می‌کند و داده‌های بازیابی‌شده را از طریق [Chart.chart_data](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/chart_data/) و [ChartData.chart_data_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) دسترسی می‌دهد:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # داده‌های بازیابی‌شدهٔ کتاب‌کار را در اینجا بخوانید یا اصلاح کنید.
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنا پرتاب می‌کند. بازیابی را فقط زمانی فعال کنید که استفاده از داده‌های کش‌شده نمودار یک گزینهٔ قابل قبول باشد، زیرا کش ممکن است تغییرات اعمال‌شده به کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه را شامل نشود.

## **سوالات متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به کتاب‌کار خارجی یا جاسازی‌شده لینک دارد؟**  
بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/data_source_type/) و [مسیر به کتاب‌کار خارجی](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/external_workbook_path/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**  
بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این کار برای جابجایی پروژه مفید است؛ اما توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌کارهایی که روی منابع/اشتراک‌های شبکه قرار دارند استفاده کنم؟**  
بله، چنین کتاب‌کارهایی می‌توانند به عنوان منبع داده خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای راه دور از Aspose.Slides پشتیبانی نمی‌شود؛ آنها فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**  
خیر. ارائه یک [لینک به فایل خارجی](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی هنگام ذخیرهٔ ارائه دست‌نخورده می‌ماند.

**اگر فایل خارجی با رمز عبور محافظت شده باشد چه باید کرد؟**  
Aspose.Slides هنگام لینک کردن رمز عبور نمی‌پذیرد. رویکرد معمول این است که پیش از لینک کردن حفاظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](/cells/python-net/)) تهیه کنید و به آن نسخه لینک کنید.

**آیا می‌توان چندین نمودار را به یک کتاب‌کار خارجی ارجاع داد؟**  
بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در تمام نمودارها منعکس می‌شود.