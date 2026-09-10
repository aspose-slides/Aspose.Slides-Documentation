---
title: افزودن خطوط روند به نمودارهای ارائه در پایتون
linktitle: خط روند
type: docs
url: /fa/python-java/trend-line/
keywords:
- نمودار
- خط روند
- خط روند نمایی
- خط روند خطی
- خط روند لگاریتمی
- خط روند متوسط متحرک
- خط روند چندجمله‌ای
- خط روند توان
- خط روند سفارشی
- پاورپوینت
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "به‌سرعت خطوط روند را در نمودارهای پاورپوینت با Aspose.Slides برای پایتون از طریق جاوا اضافه و سفارشی کنید — راهنمای عملی برای جذب مخاطبان شما."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه خطوط روند را به نمودارهای ارائه با استفاده از Aspose.Slides اضافه کنید. این مقاله نشان می‌دهد چگونه یک نمودار ایجاد کنید، خطوط روند را به سری‌های نمودار اضافه کنید و با چندین نوع خط روند کار کنید، از جمله نمایی، خطی، لگاریتمی، متوسط متحرک، چندجمله‌ای و توان.

همچنین نحوه افزودن یک خط سفارشی به نمودار با درج یک شکل خطی را شرح می‌دهد و شامل سؤالات متداول کوتاهی درباره مقادیر پیشرو و پسرو خط روند و این که آیا خطوط روند هنگام خروجی به PDF یا SVG و هنگام رندر نمودارها به‌عنوان تصویر حفظ می‌شوند، است.

## **افزودن خط روند**

Aspose.Slides for Python via Java یک API ساده برای مدیریت خطوط روند مختلف نمودارها فراهم می‌کند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک اسلاید را بر اساس اندیس آن به‌دست آورید.
1. یک نمودار با داده‌های پیش‌فرض و نوع دلخواه اضافه کنید (در این مثال از [ChartType.ClusteredColumn](https://reference.aspose.com/slides/fa/python-java/aspose.slides/charttype/#ClusteredColumn) استفاده شده است).
1. یک خط روند نمایی به سری 1 نمودار اضافه کنید.
1. یک خط روند خطی به سری 1 نمودار اضافه کنید.
1. یک خط روند لگاریتمی به سری 2 نمودار اضافه کنید.
1. یک خط روند متوسط متحرک به سری 2 نمودار اضافه کنید.
1. یک خط روند چندجمله‌ای به سری 3 نمودار اضافه کنید.
1. یک خط روند توان به سری 3 نمودار اضافه کنید.
1. ارائهٔ تغییر یافته را در یک فایل PPTX ذخیره کنید.

کد زیر یک نمودار با خطوط روند ایجاد می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# یک نمونه از کلاس Presentation ایجاد کنید.
presentation = Presentation()
try:
    # یک نمودار ستون خوشه‌ای ایجاد کنید.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # یک خط روند نمایی به سری 1 نمودار اضافه کنید.
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # یک خط روند خطی به سری 1 نمودار اضافه کنید.
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # یک خط روند لگاریتمی به سری 2 نمودار اضافه کنید.
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # یک خط روند متوسط متحرک به سری 2 نمودار اضافه کنید.
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # یک خط روند چندجمله‌ای به سری 3 نمودار اضافه کنید.
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # یک خط روند توان به سری 3 نمودار اضافه کنید.
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # ارائه را ذخیره کنید.
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **افزودن خط سفارشی**

Aspose.Slides برای Python از طریق Java یک API ساده برای افزودن خطوط سفارشی به یک نمودار فراهم می‌کند. برای افزودن یک خط ساده به نمودار در یک اسلاید انتخابی، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
- یک اسلاید را بر اساس اندیس آن به‌دست آورید.
- با استفاده از متد [addChart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addChart) از کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/) یک نمودار جدید ایجاد کنید.
- با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addAutoShape) و [ShapeType.Line](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapetype/#Line) یک شکل خطی اضافه کنید.
- رنگ خط شکل را تنظیم کنید.
- ارائهٔ تغییر یافته را در یک فایل PPTX ذخیره کنید.

کد زیر یک نمودار با خط سفارشی ایجاد می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# یک نمونه از کلاس Presentation ایجاد کنید.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**معنی 'forward' و 'backward' در یک خط روند چیست؟**

اینها طول‌های خط روند هستند که به‌صورت جلو یا عقب پیش‌بینی می‌شوند: برای نمودارهای پراکندگی (XY)، بر حسب واحدهای محور اندازه‌گیری می‌شوند؛ برای نمودارهای غیرپراکندگی، بر حسب تعداد دسته‌ها اندازه‌گیری می‌شوند. تنها مقادیر غیرمنفی مجازند.

**آیا خط روند هنگام خروجی ارائه به PDF یا SVG یا هنگام رندر اسلاید به تصویر حفظ می‌شود؟**

بله. Aspose.Slides ارائه‌ها را به [PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/fa/python-java/render-a-slide-as-an-svg-image/) تبدیل می‌کند و نمودارها را به تصاویر رندر می‌سازد؛ خطوط روند به‌عنوان بخشی از نمودار در طول این عملیات حفظ می‌شوند. همچنین روشی برای [صادر کردن تصویر نمودار](/slides/fa/python-java/create-shape-thumbnails/) وجود دارد.