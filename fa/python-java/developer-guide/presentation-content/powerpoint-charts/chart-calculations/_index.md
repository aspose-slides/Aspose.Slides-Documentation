---
title: بهینه‌سازی محاسبات نمودار برای ارائه‌ها در Python via Java
linktitle: محاسبات نمودار
type: docs
weight: 50
url: /fa/python-java/chart-calculations/
keywords:
- محاسبات نمودار
- عناصر نمودار
- موقعیت عنصر
- موقعیت واقعی
- عنصر فرزند
- عنصر والد
- مقادیر نمودار
- مقدار واقعی
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "محاسبات نمودار، به‌روزرسانی داده‌ها و کنترل دقت را در Aspose.Slides برای Python via Java برای PPT و PPTX درک کنید، همراه با مثال‌های عملی کد Python."
---
## **نمای کلی**

Aspose.Slides API‌هایی را برای کار با محاسبات نمودار و داده‌های چیدمان در ارائه‌ها فراهم می‌کند. این مقاله نشان می‌دهد چگونه مقادیر واقعی عناصر نمودار، از جمله موقعیت و اندازه واقعی عناصر نمودار و مقادیر واقعی محورهای نمودار را بازیابی کنید. همچنین توضیح می‌دهد که این مقادیر پس از اعتبارسنجی چیدمان نمودار پر می‌شوند.

علاوه بر این، مقاله نشان می‌دهد چگونه موقعیت واقعی عناصر والد نمودار را به دست آورید و چگونه اجزای نمودار مانند عنوان، محورها، افسانه و خطوط شبکه را پنهان کنید. این مثال‌ها به شما کمک می‌کند اطلاعات چیدمان نمودار را بررسی کنید و دیداری عناصر نمودار را در ارائه‌های PowerPoint به‌صورت برنامه‌ای کنترل کنید.

## **محاسبه مقادیر واقعی عناصر نمودار**
Aspose.Slides for Python via Java یک API ساده برای دریافت این ویژگی‌ها فراهم می‌کند. متدهای کلاس [محور](https://reference.aspose.com/slides/fa/python-java/aspose.slides/axis/) اطلاعاتی درباره مقادیر واقعی محورهای نمودار ارائه می‌دهند ([getActualMaxValue](https://reference.aspose.com/slides/fa/python-java/aspose.slides/axis/#getActualMaxValue), [getActualMinValue](https://reference.aspose.com/slides/fa/python-java/aspose.slides/axis/#getActualMinValue), [getActualMajorUnit](https://reference.aspose.com/slides/fa/python-java/aspose.slides/axis/#getActualMajorUnit), [getActualMinorUnit](https://reference.aspose.com/slides/fa/python-java/aspose.slides/axis/#getActualMinorUnit), [getActualMajorUnitScale](https://reference.aspose.com/slides/fa/python-java/aspose.slides/axis/#getActualMajorUnitScale), [getActualMinorUnitScale](https://reference.aspose.com/slides/fa/python-java/aspose.slides/axis/#getActualMinorUnitScale)). ابتدا متد [Chart.validateChartLayout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#validateChartLayout) را فراخوانی کنید تا این ویژگی‌ها با مقادیر واقعی پر شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **محاسبه موقعیت واقعی عناصر والد نمودار**
Aspose.Slides for Python via Java یک API ساده برای دریافت این ویژگی‌ها فراهم می‌کند. متدهای کلاس [ChartPlotArea](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartplotarea/) اطلاعاتی درباره موقعیت و اندازه واقعی ناحیه رسم نمودار ارائه می‌دهند ([getActualX](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartplotarea/#getActualX), [getActualY](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartplotarea/#getActualY), [getActualWidth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartplotarea/#getActualWidth), [getActualHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartplotarea/#getActualHeight)). ابتدا متد [Chart.validateChartLayout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#validateChartLayout) را فراخوانی کنید تا این ویژگی‌ها با مقادیر واقعی پر شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **پنهان کردن عناصر نمودار**
این بخش توضیح می‌دهد چگونه اطلاعاتی را از یک نمودار پنهان کنید. با استفاده از Aspose.Slides for Python via Java می‌توانید **عنوان، محور عمودی، محور افقی** و **خطوط شبکه** را مخفی کنید. مثال کد زیر نشان می‌دهد چگونه از این ویژگی‌ها استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # عنوان نمودار را مخفی کنید.
    chart.setTitle(False)

    # محور مقدار را مخفی کنید.
    chart.getAxes().getVerticalAxis().setVisible(False)

    # محور دسته‌بندی را مخفی کنید.
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # راهنما را مخفی کنید.
    chart.setLegend(False)

    # خطوط اصلی شبکه را مخفی کنید.
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # فقط اولین سری را نگه دارید. حذف از انتها ایندکس‌های باقی‌مانده را معتبر نگه می‌دارد.
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # رنگ خط سری را تنظیم کنید.
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **پرسش‌های متداول**

**آیا کتاب‌کارهای Excel خارجی می‌توانند به‌عنوان منبع داده استفاده شوند و این چگونه بر محاسبه مجدد تأثیر می‌گذارد؟**

بله. یک نمودار می‌تواند به کتاب‌کار خارجی ارجاع دهد: هنگامی که منبع خارجی متصل یا تازه‌سازی می‌شود، فرمول‌ها و مقادیر از آن کتاب‌کار گرفته می‌شوند و نمودار در طول عملیات باز/ویرایش به‌روز می‌شود. API به شما امکان می‌دهد مسیر کتاب‌کار خارجی را با استفاده از [setExternalWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#setExternalWorkbook) مشخص کنید و داده‌های پیوندی را مدیریت کنید.

**آیا می‌توانم خطوط روند را بدون پیاده‌سازی رگرسیون خودمحاسبه و نمایش دهم؟**

بله. [خطوط روند](/slides/fa/python-java/trend-line/) (خطی، نمایی و سایر) توسط Aspose.Slides اضافه و به‌روزرسانی می‌شوند؛ پارامترهای آنها به‌صورت خودکار از داده‌های سری‌ها بازمحاسبه می‌شوند، بنابراین نیازی به پیاده‌سازی محاسبات خودتان ندارید.

**اگر یک ارائه چندین نمودار با پیوندهای خارجی داشته باشد، آیا می‌توانم کنترل کنم که هر نمودار از کدام کتاب‌کار برای مقادیر محاسبه‌شده استفاده کند؟**

بله. هر نمودار می‌تواند به [کتاب‌کار خارجی] خود اشاره کند یا می‌توانید برای هر نمودار به‌طور مستقل کتاب‌کار خارجی را ایجاد/جایگزین کنید بدون اینکه به دیگران تأثیر بگذارد.