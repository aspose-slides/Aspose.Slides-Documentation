---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها با Python
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
description: "Aspose.Slides برای Python از طریق .NET را کشف کنید: به آسانی کتاب‌کارهای نمودار را در قالب‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه کنید."
---
## **نمای کلی**

این مقاله نحوه کار با کتاب‌کارهای نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه می‌توان داده‌های نمودار را از طریق جریان‌های کتاب‌کار خواند و نوشت، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار استفاده کرد، به مجموعه‌های ورک‌شیت دسترسی یافت و نوع منبع داده برای مقادیر نمودار را مشخص کرد.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی مرتبط با یک نمودار را بازیابی کنید و داده‌های نمودار را زمانی که کتاب‌کار در دسترس است ویرایش کنید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides متدهایی برای خواندن و نوشتن کتاب‌کارهای داده نمودار (که شامل داده‌های نمودار ویرایش شده با Aspose.Cells هستند) فراهم می‌کند. **توجه:** داده‌های نمودار باید به همان شیوه یا ساختاری مشابه منبع سازماندهی شوند.

کد پایتون زیر یک عملیات نمونه را نشان می‌دهد:

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

هنگام جایگزینی یک کتاب‌کار توکار با یک کتاب‌کار اصلاح‌شده، نمودار مجموعه‌های سری و دسته‌بندی اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود که [IChart.validate_chart_layout](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichart/validate_chart_layout/) با خطای out‑of‑range ایندکس شکست بخورد. قبل از نوشتن کتاب‌کار به‌روزرسانی‌شده به نمودار، سری‌ها و دسته‌ها را پاک کنید.

```python
# پس از تغییر جریان کتاب‌کار (مثلاً با استفاده از Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# ارجاعات داده موجود را پاک کنید.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

پاک‌سازی مجموعه‌ها اطمینان می‌دهد که ساختار داده‌های نمودار با کتاب‌کار جدید سازگار است و `validate_chart_layout` بدون خطا تکمیل می‌شود.

## **تنظیم یک سلول کتاب‌کار به عنوان برچسب داده نمودار**

گاهی نیاز به برچسب‌های نمودار دارید که مستقیماً از سلول‌های کتاب‌کار زیرین استخراج می‌شوند. Aspose.Slides به شما اجازه می‌دهد برچسب‌های داده را به سلول‌های خاصی بایند کنید تا متن برچسب همیشه مقدار سلول را منعکس کند. مثال زیر نشان می‌دهد چگونه برچسب‌های «مقدار از سلول» را فعال کنید و برچسب‌های انتخابی را به سلول‌های سفارشی در کتاب‌کار نمودار اشاره دهید.

1. یک نمونه از کلاس [Presentation](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/) ایجاد کنید.  
1. مرجع اسلاید را بر اساس اندیس دریافت کنید.  
1. یک نمودار حبابی با داده‌های نمونه اضافه کنید.  
1. به سری‌های نمودار دسترسی پیدا کنید.  
1. از یک سلول کتاب‌کار به‌عنوان برچسب داده استفاده کنید.  
1. ارائه را ذخیره کنید.

کد پایتون زیر نحوه تنظیم یک سلول کتاب‌کار به عنوان برچسب داده نمودار را نشان می‌دهد:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# یک شیء از کلاس Presentation ایجاد کنید که نمایانگر یک فایل ارائه است.
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

## **مدیریت ورک‌شیت‌ها**

کد پایتون زیر نشان می‌دهد چگونه از ویژگی `worksheets` برای دسترسی به مجموعه ورک‌شیت‌ها استفاده کنید:

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

## **تشخیص فرمت‌های کتاب‌کار توکار پشتیبانی‌نشده**

Aspose.Slides از فرمت کتاب‌کار باینری اکسل (.xlsb) که می‌تواند در برخی نمودارها توکار شود، پشتیبانی نمی‌کند. می‌توانید از ویژگی `embedded_workbook_type` در [ChartData](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/) به همراه شمارش‌ه‌ [WorkbookType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/workbooktype/) برای تشخیص فرمت‌های پشتیبانی‌نشده استفاده کنید و آن نمودارها را نادیده بگیرید.

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
            # کتاب‌کار توکار در قالب .xlsb است که پشتیبانی نمی‌شود.
            continue

        # در اینجا داده‌های کتاب‌کار نمودار را بخوانید یا اصلاح کنید.
```

## **کتاب‌کارهای خارجی**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **تنظیم کتاب‌کارهای خارجی**

با استفاده از متد [ChartData.set_external_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/set_external_workbook/) می‌توانید یک کتاب‌کار خارجی را به عنوان منبع دادهٔ نمودار اختصاص دهید. این متد همچنین می‌تواند مسیر کتاب‌کار خارجی را در صورت جابه‌جایی به‌روزرسانی کند.

اگرچه نمی‌توانید داده‌ها را در کتاب‌کارهای ذخیره‌شده در مکان‌های دوردست یا منابع ویرایش کنید، می‌توانید همچنان از آن‌ها به‌عنوان منابع دادهٔ خارجی استفاده کنید. اگر مسیری نسبی برای کتاب‌کار خارجی ارائه دهید، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

کد پایتون زیر نحوه تنظیم یک کتاب‌کار خارجی را نشان می‌دهد:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # False را پاس می‌دهیم تا فقط مسیر ذخیره شود: کتاب‌کار هدف نیازی به وجود داشتن در این لحظه ندارد.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

پارامتر `update_chart_data` در متد [set_external_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/set_external_workbook/) مشخص می‌کند که آیا کتاب‌کار اکسل بارگذاری شود یا نه.

- وقتی `update_chart_data` برابر با `False` باشد، تنها مسیر کتاب‌کار به‌روزرسانی می‌شود؛ داده‌های نمودار از کتاب‌کار هدف بارگذاری یا تازه‌سازی نمی‌شوند. از این تنظیم زمانی استفاده کنید که کتاب‌کار هدف وجود نداشته باشد یا در دسترس نباشد.  
- وقتی `update_chart_data` برابر با `True` (پیش‌فرض) باشد، داده‌های نمودار از کتاب‌کار هدف بارگذاری و به‌روزرسانی می‌شوند. اگر آن کتاب‌کار باز نشود، استثنایی با پیام «External workbook is not available» صادر می‌شود.

### **ایجاد کتاب‌کارهای خارجی**

با استفاده از متدهای [read_workbook_stream](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و [set_external_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/set_external_workbook/) می‌توانید یا یک کتاب‌کار خارجی را از صفر ایجاد کنید یا یک کتاب‌کار داخلی را به خارجی تبدیل کنید.

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

### **دریافت مسیر کتاب‌کار منبع دادهٔ خارجی برای یک نمودار**

گاهی دادهٔ یک نمودار به یک کتاب‌کار اکسل خارجی مرتبط است نه به دادهٔ توکار ارائه. با Aspose.Slides می‌توانید منبع دادهٔ نمودار را بررسی کنید و اگر منبع یک کتاب‌کار خارجی بود، مسیر کامل کتاب‌کار را بخوانید.

1. یک نمونه از کلاس [Presentation](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/) ایجاد کنید.  
1. مرجع اسلاید را بر اساس اندیس دریافت کنید.  
1. مرجع شکل نمودار را دریافت کنید.  
1. منبع ([ChartDataSourceType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatasourcetype/)) که نمایانگر منبع دادهٔ نمودار است را به‌دست آورید.  
1. بررسی کنید آیا نوع منبع با نوع منبع دادهٔ کتاب‌کار خارجی مطابقت دارد یا خیر.

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

### **ویرایش دادهٔ نمودار**

می‌توانید داده‌ها را در کتاب‌کارهای خارجی همانند کتاب‌کارهای داخلی ویرایش کنید. اگر کتاب‌کار خارجی بارگذاری نشود، استثنایی صادر می‌شود.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **بازیابی کتاب‌کار از ذخیره‌ساز نمودار**

اگر یک نمودار از کتاب‌کار خارجی که از دست رفته یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. ابتدا یک [LoadOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/) ایجاد کنید، سپس `SpreadsheetOptions.recover_workbook_from_chart_cache` را از طریق `LoadOptions.spreadsheet_options` فعال کنید قبل از باز کردن ارائه.

مثال پایتون زیر ارائه‌ای را باز می‌کند که نمودار آن به یک کتاب‌کار خارجی غیرقابل دسترسی ارجاع دارد و داده‌های بازیابی‌شده را از طریق [Chart.chart_data](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/chart_data/) و [ChartData.chart_data_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) دسترسی می‌دهد:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # خواندن یا اصلاح داده‌های کتاب‌کار بازیابی‌شده در اینجا.
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنایی صادر می‌کند. تنها زمانی بازیابی را فعال کنید که استفاده از دادهٔ کش‌شده نمودار یک گزینهٔ قابل قبول باشد، زیرا کش ممکن است تغییرات ایجاد شده در کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه را شامل نشود.

## **سوالات متداول**

**آیا می‌توانم تعیین کنم یک نمودار خاص به کتاب‌کار خارجی یا توکار لینک دارد؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/data_source_type/) و [path to an external workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/external_workbook_path/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی را مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این برای قابلیت حمل پروژه مفید است؛ اما توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌کارهایی که روی منابع/به‌اشتراک‌گذاری‌های شبکه قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای دوردست از Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند منبع باشند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

فقط در صورتی که داده‌های نمودار را ویرایش کرده باشید. ارائه یک [link to the external file](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند، بنابراین باز کردن و ذخیرهٔ ارائه کتاب‌کار را دست‌نخورده می‌گذارد. اما مقادیری که از طریق دادهٔ نمودار تغییر می‌دهید (به‌مثال در بخش [Edit Chart Data](#edit-chart-data) بالا) هنگام ذخیرهٔ ارائه به کتاب‌کار خارجی بازنویسی می‌شوند؛ اگر نسخهٔ اصلی باید دست‌نخورده بماند، روی یک کپی کار کنید.

**اگر فایل خارجی رمز عبور داشته باشد چه کار کنم؟**

Aspose.Slides هنگام لینک‌کردن رمز عبور را قبول نمی‌کند. رویکرد معمول این است که پیش از آن حفاظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده تهیه کنید (به‌عنوان مثال با استفاده از [Aspose.Cells](/cells/python-net/)) و به آن نسخه لینک کنید.

**آیا می‌توان چندین نمودار را به یک کتاب‌کار خارجی ارجاع داد؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در تمام نمودارها بازتاب خواهد یافت.