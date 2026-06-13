---
title: بهینه‌سازی محاسبات نمودار برای ارائه‌ها در Python
linktitle: محاسبات نمودار
type: docs
weight: 50
url: /fa/python-net/chart-calculations/
keywords:
- محاسبات نمودار
- عناصر نمودار
- موقعیت عنصر
- موقعیت واقعی
- عنصر فرزند
- عنصر والد
- مقادیر نمودار
- مقدار واقعی
- پاورپوینت
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: محاسبات نمودار، به‌روزرسانی داده‌ها و کنترل دقت را در Aspose.Slides برای Python از طریق .NET برای فرمت‌های PPT، PPTX و ODP درک کنید، همراه با مثال‌های کد عملی.
---
## **بررسی کلی**

Aspose.Slides APIهایی برای کار با محاسبات نمودار و داده‌های طرح‌بندی در ارائه‌ها فراهم می‌کند. این مقاله نحوه بازیابی مقادیر واقعی عناصر نمودار، از جمله موقعیت و اندازه واقعی عناصری که `ActualLayout` را پیاده‌سازی می‌کنند و مقادیر واقعی محورهای نمودار را نشان می‌دهد. همچنین توضیح می‌دهد که این مقادیر پس از اعتبارسنجی طرح‌بندی نمودار پر می‌شوند.

علاوه بر این، مقاله نشان می‌دهد چگونه موقعیت واقعی عناصر نمودار والد را به دست آورید و چگونه مؤلفه‌های نمودار مانند عنوان، محورها، لگند و خطوط شبکه را مخفی کنید. این مثال‌ها به شما کمک می‌کنند اطلاعات طرح‌بندی نمودار را بررسی کرده و دیداری عناصر نمودار را در ارائه‌های PowerPoint به‌صورت برنامه‌نویسی کنترل کنید.

## **محاسبه مقادیر واقعی عناصر نمودار**
Aspose.Slides برای Python از طریق .NET یک API ساده برای دریافت این ویژگی‌ها فراهم می‌کند. این به شما کمک می‌کند مقادیر واقعی عناصر نمودار را محاسبه کنید. مقادیر واقعی شامل موقعیت عناصری است که از کلاس [IActualLayout](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/iactuallayout/) ارث‌بری می‌کنند (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) و مقادیر واقعی محورها (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```

## **محاسبه موقعیت واقعی عناصر نمودار والد**
Aspose.Slides برای Python از طریق .NET یک API ساده برای دریافت این ویژگی‌ها فراهم می‌کند. ویژگی‌های IActualLayout اطلاعاتی درباره موقعیت واقعی عنصر نمودار والد ارائه می‌دهند. لازم است پیش از آن متد IChart.ValidateChartLayout() فراخوانی شود تا ویژگی‌ها با مقادیر واقعی پر شوند.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```

## **مخفی کردن اطلاعات از نمودار**
این موضوع به شما کمک می‌کند نحوه مخفی کردن اطلاعات از نمودار را درک کنید. با استفاده از Aspose.Slides برای Python از طریق .NET می‌توانید **عنوان، محور عمودی، محور افقی** و **خطوط شبکه** را از نمودار مخفی کنید. مثال کد زیر نشان می‌دهد چگونه از این ویژگی‌ها استفاده کنید.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # پنهان‌کردن عنوان نمودار
    chart.has_title = False

    # پنهان‌کردن محور مقدارها
    chart.axes.vertical_axis.is_visible = False

    # نمایش محور دسته‌بندی
    chart.axes.horizontal_axis.is_visible = False

    # پنهان‌کردن لگند
    chart.has_legend = False

    # پنهان‌کردن خطوط شبکه اصلی
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # تنظیم رنگ خط سری
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```

## **پرسش‌های متداول**

**آیا دفترهای کار Excel خارجی می‌توانند به‌عنوان منبع داده عمل کنند و این بر بازمحاسبه چه تاثیری دارد؟**

بله. یک نمودار می‌تواند به دفتر کار خارجی ارجاع دهد: هنگامی که منبع خارجی را متصل یا تازه‌سازی می‌کنید، فرمول‌ها و مقادیر از آن دفتر کار گرفته می‌شوند و نمودار در حین عملیات باز/ویرایش به‌روزرسانی‌ها را منعکس می‌کند. API به شما امکان می‌دهد مسیر [مشخص کردن دفتر کار خارجی](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/set_external_workbook/) را تنظیم و داده‌های لینک‌شده را مدیریت کنید.

**آیا می‌توانم خطوط روند را بدون پیاده‌سازی رگرسیون خودمحاسب کنم و نمایش دهم؟**

بله. [خطوط‌روند](/slides/fa/python-net/trend-line/) (خطی، نمایی و سایر) توسط Aspose.Slides اضافه و به‌روز می‌شوند؛ پارامترهای آن‌ها به‌صورت خودکار از داده‌های سری محاسبه می‌شوند، بنابراین نیازی به پیاده‌سازی محاسبات خودتان ندارید.

**اگر یک ارائه دارای چندین نمودار با لینک‌های خارجی باشد، آیا می‌توانم کنترل کنم هر نمودار از کدام دفتر کار برای مقادیر محاسبه‌شده استفاده کند؟**

بله. هر نمودار می‌تواند به [دفتر کار خارجی](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/set_external_workbook/) خود اشاره کند، یا می‌توانید برای هر نمودار یک دفتر کار خارجی را به‌صورت مستقل ایجاد/جایگزین کنید.