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
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "به سرعت خطوط روند را در نمودارهای PowerPoint و OpenDocument با Aspose.Slides برای Python via .NET اضافه و سفارشی کنید — یک راهنمای عملی و مثال‌های کد برای بهبود دقت پیش‌بینی و جلب توجه مخاطبان شما."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه خطوط روند را به نمودارهای ارائه با استفاده از Aspose.Slides اضافه کنید. نحوه ایجاد یک نمودار، افزودن خطوط روند به سری‌های نمودار و کار با چندین نوع خط روند، از جمله نمایی، خطی، لگاریتمی، میانگین متحرک، چندجمله‌ای و توان، را نشان می‌دهد.

همچنین نحوه افزودن خط سفارشی به یک نمودار با وارد کردن یک شکل خطی را شرح می‌دهد و شامل یک سؤالات متداول کوتاه درباره مقادیر پیش‌بینی خط روند به جلو و عقب و اینکه آیا خطوط روند هنگام صادرات به PDF یا SVG و هنگام رندر نمودارها به عنوان تصویر حفظ می‌شوند یا نه، می‌باشد.

## **افزودن خط روند**
Aspose.Slides for Python via .NET یک API ساده برای مدیریت خطوط روند مختلف نمودارها ارائه می‌دهد:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. مرجع یک اسلاید را بر اساس شاخص آن به دست آورید.
3. یک نمودار با داده‌های پیش‌فرض و از هر نوع دلخواه (در این مثال از ChartType.CLUSTERED_COLUMN استفاده می‌شود) اضافه کنید.
4. اضافه کردن خط روند نمایی برای سری 1 نمودار.
5. اضافه کردن خط روند خطی برای سری 1 نمودار.
6. اضافه کردن خط روند لگاریتمی برای سری 2 نمودار.
7. اضافه کردن خط روند میانگین متحرک برای سری 2 نمودار.
8. اضافه کردن خط روند چندجمله‌ای برای سری 3 نمودار.
9. اضافه کردن خط روند توان برای سری 3 نمودار.
10. ارائهٔ اصلاح‌شده را به یک فایل PPTX بنویسید.

کد زیر برای ایجاد یک نمودار با خطوط روند استفاده می‌شود.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# ساخت ارائهٔ خالی
with slides.Presentation() as pres:

    # ایجاد نمودار ستونی خوشه‌ای
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # افزودن خط روند نمایی برای سری 1 نمودار
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # افزودن خط روند خطی برای سری 1 نمودار
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # افزودن خط روند لگاریتمی برای سری 2 نمودار
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # افزودن خط روند میانگین متحرک برای سری 2 نمودار
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # افزودن خط روند چندجمله‌ای برای سری 3 نمودار
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # افزودن خط روند توان برای سری 3 نمودار
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # ذخیرهٔ ارائه
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```

## **افزودن خط سفارشی**
Aspose.Slides for Python via .NET یک API ساده برای افزودن خطوط سفارشی در یک نمودار ارائه می‌دهد. برای افزودن یک خط ساده به اسلاید انتخاب‌شدهٔ ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس Presentation ایجاد کنید
- مرجع یک اسلاید را با استفاده از Index آن به دست آورید
- یک نمودار جدید با استفاده از متد AddChart ارائه‌شده توسط شی Shapes ایجاد کنید
- یک AutoShape از نوع Line با استفاده از متد AddAutoShape ارائه‌شده توسط شی Shapes اضافه کنید
- رنگ خطوط شکل را تنظیم کنید.
- ارائهٔ اصلاح‌شده را به عنوان یک فایل PPTX بنویسید

کد زیر برای ایجاد یک نمودار با خطوط سفارشی استفاده می‌شود.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **سؤالات متداول**

**معنی 'به‌جهت جلو' و 'به‌جهت عقب' در یک خط روند چیست؟**

اینها طول خط روند هستند که به‌جهت جلو یا عقب پیش‌بینی می‌شود: برای نمودارهای پراکندگی (XY) — بر حسب واحدهای محور؛ برای نمودارهای غیرپراکندگی — بر حسب تعداد دسته‌ها. تنها مقادیر غیرمنفی مجاز هستند.

**آیا خط روند هنگام صادرات ارائه به PDF یا SVG، یا هنگام رندر اسلاید به تصویر حفظ می‌شود؟**

بله. Aspose.Slides ارائه‌ها را به [PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/fa/python-net/render-a-slide-as-an-svg-image/) تبدیل می‌کند و نمودارها را به تصویر رندر می‌کند؛ خطوط روند، به‌عنوان بخشی از نمودار، در این عملیات حفظ می‌شوند. همچنین یک متد برای [صادرات تصویر نمودار](/slides/fa/python-net/create-shape-thumbnails/) موجود است.