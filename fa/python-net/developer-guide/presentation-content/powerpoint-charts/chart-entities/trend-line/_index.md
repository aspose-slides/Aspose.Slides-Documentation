---
title: افزودن خطوط روند به نمودارهای ارائه در پایتون
linktitle: خط روند
type: docs
url: /fa/python-net/trend-line/
keywords:
- نمودار
- خط روند
- خط روند نمایی
- خط روند خطی
- خط روند لگاریتمی
- خط روند میانگین متحرک
- خط روند چندجمله‌ای
- خط روند توان
- خط روند سفارشی
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "به‌سرعت خطوط روند را در نمودارهای PowerPoint با Aspose.Slides برای پایتون از طریق .NET اضافه و سفارشی کنید — راهنمای عملی برای جذب مخاطبان شما."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با استفاده از Aspose.Slides خطوط روند را به نمودارهای ارائه اضافه کنید. نحوه ایجاد یک نمودار، افزودن خطوط روند به سری‌های نمودار و کار با انواع مختلف خطوط روند شامل نمایی، خطی، لگاریتمی، میانگین متحرک، چندجمله‌ای و توان را نشان می‌دهد.

همچنین نحوه افزودن خط سفارشی به یک نمودار با درج یک شکل خطی را شرح می‌دهد و شامل سؤالات متداول کوتاهی درباره مقادیر پیش‌بینی خط روند به جلو و عقب و این که آیا خطوط روند هنگام خروجی به PDF یا SVG و هنگام رندر نمودارها به‌عنوان تصویر حفظ می‌شوند یا نه می‌باشد.

## **اضافه کردن خط روند**

از [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) برای افزودن یک خط روند به یک سری نمودار استفاده کنید و نوع آن را با [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/) انتخاب کنید. این مثال یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض ایجاد می‌کند و دو خط روند به هر یک از سه سری آن اضافه می‌کند.

خط روند نمایی معادله و مقدار R‑مربعات خود را از طریق [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) و [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/) مخفی می‌کند، در حالی که خط روند خطی به رنگ قرمز است. خط روند لگاریتمی از [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) برای برچسب سفارشی استفاده می‌کند. میانگین متحرک از یک [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) با سه نقطه داده استفاده می‌کند و یک [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/) سفارشی دارد. خط روند چندجمله‌ای دارای یک [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) با مقدار سه است و یک دسته به‌سوی جلو از طریق [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/) گسترش می‌یابد. خط روند توان یک دسته به‌سوی عقب از طریق [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/) گسترش می‌یابد.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    first_series = chart.chart_data.series[0]

    exponential_trendline = first_series.trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    exponential_trendline.display_equation = False
    exponential_trendline.display_r_squared_value = False

    linear_trendline = first_series.trend_lines.add(charts.TrendlineType.LINEAR)
    linear_trendline.format.line.fill_format.fill_type = slides.FillType.SOLID
    linear_trendline.format.line.fill_format.solid_fill_color.r = 255
    linear_trendline.format.line.fill_format.solid_fill_color.g = 0
    linear_trendline.format.line.fill_format.solid_fill_color.b = 0

    second_series = chart.chart_data.series[1]

    logarithmic_trendline = second_series.trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    logarithmic_trendline.add_text_frame_for_overriding("New log trend line")

    moving_average_trendline = second_series.trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    moving_average_trendline.period = 3
    moving_average_trendline.trendline_name = "New TrendLine Name"

    third_series = chart.chart_data.series[2]

    polynomial_trendline = third_series.trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    polynomial_trendline.forward = 1
    polynomial_trendline.order = 3

    power_trendline = third_series.trend_lines.add(charts.TrendlineType.POWER)
    power_trendline.backward = 1

    presentation.save("ChartTrendLines.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم نقطه تقاطع خط روند**

از [intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) برای ثابت نگه داشتن مقدار Y خط روند در X = 0 استفاده کنید. این تنظیم برای خطوط روند خطی، نمایی و چندجمله‌ای پشتیبانی می‌شود.

به عنوان مثال، یک مدل هزینه تولید ممکن است نیاز داشته باشد که از هزینه‌های ثابت شناخته‌شده ۱۰۰ شروع شود، حتی زمانی که اندازه‌گیری‌ها در حجم‌های تولید غیرصفر نشان دهنده یک پایه متفاوت هستند. برای یک خط روند خطی، ثابت کردن نقطه تقاطع معادله `y = ax + b` را به `b = 100` محدود می‌کند؛ شیب بر اساس داده‌ها تحت این محدودیت برازش می‌شود. این صرفاً خطی که قبلاً برازش شده را جابجا نمی‌کند. تنظیمات عبور محور تعیین می‌کند که محورها در کجا به هم می‌رسند، نه ضرایب خط روند برازش‌شده.

مثال زیر یک نمودار پراکندگی (XY) با حجم‌های تولید از ۱ تا ۴ و هزینه‌های ۱۷۰، ۲۰۰، ۲۳۰ و ۲۶۰ ایجاد می‌کند. نمودار را با نقطه تقاطع خودکار پیش‌فرض ذخیره می‌کند، نقطه تقاطع را به ۱۰۰ تنظیم می‌کند و یک فایل PPTX دوم ذخیره می‌کند. دو فایل تنها در تنظیم نقطه تقاطع متفاوت هستند. خط روند معادله خود را نمایش می‌دهد و به X = 0 بازمی‌گردد.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_MARKERS, 20, 20, 480, 210)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    name_cell = workbook.get_cell(0, 0, 1, "Production cost")
    series = chart.chart_data.series.add(name_cell, charts.ChartType.SCATTER_WITH_MARKERS)
    costs = [170, 200, 230, 260]

    for i, cost in enumerate(costs):
        x_cell = workbook.get_cell(0, i + 1, 0, i + 1)
        y_cell = workbook.get_cell(0, i + 1, 1, cost)
        series.data_points.add_data_point_for_scatter_series(x_cell, y_cell)

    trendline = series.trend_lines.add(charts.TrendlineType.LINEAR)
    trendline.display_equation = True
    trendline.backward = 1

    presentation.save("AutomaticIntercept.pptx", slides.export.SaveFormat.PPTX)

    trendline.intercept = 100
    presentation.save("FixedIntercept.pptx", slides.export.SaveFormat.PPTX)
```

با محاسبه خودکار، این داده‌ها `y = 30x + 140` را تولید می‌کنند. تنظیم نقطه تقاطع به ۱۰۰ به‌جای آن تقریباً `y = 43.33x + 100` ایجاد می‌کند: مقدار برازش‌شده در صفر با پایه شناخته‌شده مطابقت دارد، در حالی که خط دیگر از تمام نقاط داده عبور نمی‌کند.

| نقطه تقاطع خودکار | نقطه تقاطع ثابت ۱۰۰ |
| --- | --- |
| ![خط روند خطی با نقطه تقاطع محاسبه‌شده خودکار ۱۴۰](intercept-automatic.png) | ![خط روند خطی با نقطه تقاطع ثابت ۱۰۰](intercept-fixed.png) |

هر دو تصویر از همان داده‌ها و مقیاس‌های محوری استفاده می‌کنند. خطوط روند به X = 0 بازگردانده می‌شوند تا نقطه تقاطع آن‌ها نشان داده شود.

به‌صورت پیش‌فرض، این ویژگی شامل `float("nan")` است که نشان‌دهنده نقطه تقاطع نامشخص به جای صفر است. سپس نقطه تقاطع به‌صورت خودکار از داده‌ها محاسبه می‌شود.

## **اضافه کردن خط سفارشی**

یک خط سفارشی شکل‌ای است که بر روی نمودار کشیده می‌شود نه خط روندی که از داده‌های سری محاسبه می‌شود. این مثال از [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) برای افزودن یک خط افقی به اسلاید بر روی نمودار استفاده می‌کند. موقعیت خط در مختصات اسلاید به‌واحد نقطه (point) مشخص می‌شود، به‌طوری که از لبه چپ نمودار شروع شده و نیم‌راه پایین نمودار قرار می‌گیرد. عرض آن برابر با عرض نمودار است. [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) رنگ قرمز جامد به خط می‌دهد.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)

    line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, chart.x, chart.y + chart.height / 2, chart.width, 0)
    line.line_format.fill_format.fill_type = slides.FillType.SOLID
    line.line_format.fill_format.solid_fill_color.r = 255
    line.line_format.fill_format.solid_fill_color.g = 0
    line.line_format.fill_format.solid_fill_color.b = 0

    presentation.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **سؤالات متداول**

**معنی 'forward' و 'backward' برای یک خط روند چیست؟**

آنها طول‌های خط روند در جهت جلو/عقب هستند: برای نمودارهای پراکنش (XY) — به‌واحدهای محور؛ برای نمودارهای غیرپراکنش — به‌تعداد دسته‌ها. فقط مقادیر غیرمنفی مجاز هستند.

**آیا خط روند هنگام صادرات ارائه به PDF یا SVG یا هنگام رندر یک اسلاید به تصویر حفظ می‌شود؟**

بله. Aspose.Slides ارائه‌ها را به [PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/) یا [SVG](/slides/fa/python-net/render-a-slide-as-an-svg-image/) تبدیل می‌کند و نمودارها را به تصاویر رندر می‌کند؛ خطوط روند به‌عنوان بخشی از نمودار در طول این عملیات حفظ می‌شوند. یک متد نیز برای [صادر کردن تصویر نمودار](/slides/fa/python-net/create-shape-thumbnails/) موجود است.