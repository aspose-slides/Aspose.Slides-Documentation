---
title: "مدیریت کتاب‌کارهای نمودار در ارائه‌ها با Python"
linktitle: "کتاب‌کار نمودار"
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
  - PowerPoint
  - ارائه
  - Python
  - Aspose.Slides
description: "Aspose.Slides برای Python از طریق .NET را کشف کنید: به‌راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های شیت‌ها دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی پیوست به نمودار را بازیابی کنید و داده‌های نمودار را هنگامی که کتاب‌کار موجود است ویرایش کنید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides روش‌هایی برای خواندن و نوشتن کتاب‌کارهای داده نمودار (که داده‌های نمودار را با Aspose.Cells ویرایش می‌کنند) فراهم می‌کند. **تذکر:** داده‌های نمودار باید به همان شکل یا ساختاری مشابه منبع سازماندهی شوند.

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

## **تنظیم یک سلول کتاب‌کار به عنوان برچسب داده نمودار**

گاهی اوقات نیاز دارید برچسب‌های نمودار مستقیماً از سلول‌های کتاب‌کار زیرین گرفته شوند. Aspose.Slides به شما امکان می‌دهد برچسب‌های داده را به سلول‌های خاص کتاب‌کار متصل کنید به‌طوری که متن برچسب همیشه مقدار سلول را منعکس کند. مثال زیر نشان می‌دهد چگونه برچسب‌های «مقدار از سلول» را فعال کنید و برچسب‌های انتخابی را به سلول‌های سفارشی در کتاب‌کار نمودار اشاره دهید.

1. یک نمونه از کلاس [Presentation](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/) ایجاد کنید.  
2. یک ارجاع به اسلاید بر اساس ایندکس دریافت کنید.  
3. یک نمودار حبابی با داده‌های نمونه اضافه کنید.  
4. به سری‌های نمودار دسترسی پیدا کنید.  
5. یک سلول کتاب‌کار را به عنوان برچسب داده استفاده کنید.  
6. پرزنتیشن را ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه یک سلول کتاب‌کار را به عنوان برچسب داده نمودار تنظیم کنید:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
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

## **مدیریت شیت‌ها**

کد پایتون زیر نشان می‌دهد چگونه از ویژگی `worksheets` برای دسترسی به مجموعه شیت‌ها استفاده کنید:

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

کد پایتون زیر نشان می‌دهد چگونه یک نوع منبع داده را مشخص کنید:

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

## **تشخیص فرمت‌های کتاب‌کار نهفته پشتیبانی‌نشده**

Aspose.Slides از فرمت کتاب‌کار باینری Excel (.xlsb) که می‌تواند در برخی نمودارها نهفته باشد، پشتیبانی نمی‌کند. می‌توانید از ویژگی `embedded_workbook_type` در [ChartData](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/) همراه با شمارش‌گر [WorkbookType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/workbooktype/) استفاده کنید تا فرمت‌های پشتیبانی‌نشده را شناسایی کرده و آن نمودارها را نادیده بگیرید.

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
            # کتاب‌کار نهفته در قالب .xlsb است که پشتیبانی نمی‌شود.
            continue

        # در اینجا داده‌های کتاب‌کار نمودار را بخوانید یا ویرایش کنید.
```

## **کتاب‌کارهای خارجی**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **تنظیم کتاب‌کارهای خارجی**

با استفاده از متد [ChartData.set_external_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/set_external_workbook/) می‌توانید یک کتاب‌کار خارجی را به یک نمودار به‌عنوان منبع داده اختصاص دهید. این متد می‌تواند مسیر کتاب‌کار خارجی را نیز به‌روزرسانی کند اگر جابه‌جا شده باشد.

اگرچه نمی‌توانید داده‌ها را در کتاب‌کارهایی که در مکان‌های دوردست یا منابع ذخیره شده‌اند ویرایش کنید، همچنان می‌توانید از آن کتاب‌کارها به‌عنوان منابع داده خارجی استفاده کنید. اگر مسیر نسبی برای یک کتاب‌کار خارجی فراهم کنید، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

کد پایتون زیر نشان می‌دهد چگونه یک کتاب‌کار خارجی تنظیم کنید:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

پارامتر `update_chart_data` متد [set_external_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/set_external_workbook/) مشخص می‌کند آیا کتاب‌کار Excel بارگذاری خواهد شد یا خیر.

- هنگامی که `update_chart_data` برابر `False` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود؛ داده‌های نمودار از کتاب‌کار هدف بارگذاری یا تازه‌سازی نمی‌شوند. از این تنظیم زمانی استفاده کنید که کتاب‌کار هدف وجود ندارد یا در دسترس نیست.  
- هنگامی که `update_chart_data` برابر `True` باشد، داده‌های نمودار از کتاب‌کار هدف بارگذاری و به‌روز می‌شوند.

### **ایجاد کتاب‌کارهای خارجی**

با استفاده از متدهای [read_workbook_stream](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و [set_external_workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/set_external_workbook/) می‌توانید یا یک کتاب‌کار خارجی را از صفر ایجاد کنید یا یک کتاب‌کار داخلی را به کتاب‌کار خارجی تبدیل کنید.

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

گاهی داده‌های یک نمودار به یک کتاب‌کار Excel خارجی لینک می‌شود نه به داده‌های نهفته ارائه. با Aspose.Slides می‌توانید منبع داده نمودار را بررسی کنید و اگر منبع یک کتاب‌کار خارجی باشد، مسیر کامل کتاب‌کار را بخوانید.

1. یک نمونه از کلاس [Presentation](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/) ایجاد کنید.  
2. یک ارجاع به اسلاید بر اساس ایندکس آن دریافت کنید.  
3. یک ارجاع به شکل نمودار دریافت کنید.  
4. منبع ([ChartDataSourceType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatasourcetype/)) که نمایانگر منبع داده نمودار است را به‌دست آورید.  
5. بررسی کنید آیا نوع منبع با نوع منبع داده کتاب‌کار خارجی مطابقت دارد یا خیر.

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

می‌توانید داده‌ها را در کتاب‌کارهای خارجی همانند کتاب‌کارهای داخلی ویرایش کنید. اگر یک کتاب‌کار خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**آیا می‌توانم تعیین کنم که آیا یک نمودار خاص به یک کتاب‌کار خارجی یا نهفته لینک شده است؟**  
بله. یک نمودار یک [نوع منبع داده](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/data_source_type/) و یک [مسیر به کتاب‌کار خارجی](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/external_workbook_path/) دارد؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**  
بله. اگر مسیر نسبی را مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این برای قابلیت حمل پروژه مفید است؛ با این حال، ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌کارهایی که در منابع/به‌اشتراک‌گذاری‌های شبکه قرار دارند استفاده کنم؟**  
بله، می‌توان از چنین کتاب‌کارهایی به‌عنوان منبع داده خارجی استفاده کرد. اما ویرایش مستقیم کتاب‌کارهای راه دور از Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیره ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**  
خیر. ارائه یک [لینک به فایل خارجی](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی هنگام ذخیره ارائه تغییر نمی‌کند.

**اگر فایل خارجی با رمز عبور محافظت شده باشد چه کاری باید انجام دهم؟**  
Aspose.Slides هنگام لینک کردن رمز عبور را قبول نمی‌کند. یک روش معمول این است که پیش از لینک کردن حفاظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](/cells/python-net/)) تهیه کنید و به آن نسخه لینک کنید.

**آیا چندین نمودار می‌توانند به همان کتاب‌کار خارجی اشاره کنند؟**  
بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در بارگذاری بعدی داده‌ها در هر نمودار منعکس می‌شود.