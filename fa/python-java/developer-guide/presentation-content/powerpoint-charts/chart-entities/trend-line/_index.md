---
title: اضافه کردن خطوط روند به نمودارهای ارائه در Python
linktitle: خط روند
type: docs
url: /fa/python-java/trend-line/
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
- Java
- Aspose.Slides
description: "به‌سرعت خطوط روند را در نمودارهای PowerPoint با Aspose.Slides برای Python via Java اضافه و سفارشی کنید — راهنمایی عملی برای جذب مخاطب."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان خطوط روند را به نمودارهای ارائه با استفاده از Aspose.Slides اضافه کرد. این مقاله نشان می‌دهد چگونه یک نمودار ایجاد کنید، خطوط روند را به سری‌های نمودار اضافه کنید و با چندین نوع خط روند کار کنید، از جمله نمایی، خطی، لگاریتمی، میانگین متحرک، چندجمله‌ای و توان.

همچنین توضیح می‌دهد چگونه می‌توان یک خط سفارشی به نمودار اضافه کرد با درج یک شکل خط، و شامل سؤالات متداول کوتاهی درباره مقادیر پیش‌بینی خط روند به جلو و عقب و این که آیا خطوط روند هنگام خروجی به PDF یا SVG و هنگام رندر نمودارها به عنوان تصویر حفظ می‌شوند یا نه.

## **اضافه کردن خط روند**

از [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add) برای اضافه کردن خط روند به یک سری نمودار استفاده کنید، نوع آن را با [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/) انتخاب می‌کنید. این مثال یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض ایجاد می‌کند و دو خط روند به هر یک از سه سری آن اضافه می‌کند.

خط روند نمایی معادله و مقدار R‑مربّع خود را از طریق [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) و [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue) مخفی می‌کند، در حالی که خط روند خطی قرمز است. خط روند لگاریتمی برای برچسب سفارشی از [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) استفاده می‌کند. میانگین متحرک از [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) با مقدار سه نقطه داده و یک [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName) سفارشی استفاده می‌کند.

خط روند چندجمله‌ای دارای مرتبه‌ای برابر با سه است که از طریق [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder) تنظیم می‌شود و یک دسته به جلو از طریق [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward) گسترش می‌یابد. خط روند توان یک دسته به عقب از طریق [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward) گسترش می‌یابد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم مقطع خط روند**

از [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept) برای ثابت کردن مقدار Y خط روند در X = 0 استفاده کنید. این تنظیم برای خطوط روند خطی، نمایی و چندجمله‌ای پشتیبانی می‌شود.

به عنوان مثال، یک مدل هزینه تولید ممکن است نیاز داشته باشد که از هزینه‌های ثابت شناخته شده 100 شروع شود، حتی وقتی اندازه‌گیری‌ها در حجم‌های تولید غیرصفر نشانگر یک پایه متفاوت هستند. برای یک خط روند خطی، ثابت کردن مقطع معادله `y = ax + b` را به `b = 100` محدود می‌کند؛ شیب تحت این قید به داده‌ها برآورد می‌شود. این کار به سادگی خطی که قبلاً برازش شده را جابه‌جا نمی‌کند. تنظیمات عبور محور تعیین می‌کند که محورهای نمودار در کجا تقاطع می‌کنند، نه ضرایب خط روند برازش‌شده.

مثال زیر یک نمودار پراکندگی (XY) با حجم‌های تولید از 1 تا 4 و هزینه‌های 170، 200، 230 و 260 ایجاد می‌کند. این نمودار را با مقطع خودکار پیش‌فرض ذخیره می‌کند، مقطع را به 100 تنظیم می‌کند و یک فایل PPTX دوم ذخیره می‌کند. دو فایل تنها در تنظیم مقطع متفاوت هستند. خط روند معادله خود را نشان می‌دهد و به X = 0 باز می‌گردد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

با محاسبه خودکار، این داده‌ها `y = 30x + 140` را تولید می‌کنند. تنظیم مقطع به 100 به‌جای آن تقریباً `y = 43.33x + 100` تولید می‌کند: مقدار برازش‌شده در صفر با پایه شناخته‌شده مطابقت دارد، در حالی که خط دیگر از تمام نقاط داده عبور نمی‌کند.

| مقطع خودکار | مقطع ثابت 100 |
| --- | --- |
| ![خط روند خطی با مقطع محاسبه‌شده به‌صورت خودکار 140](intercept-automatic.png) | ![خط روند خطی با مقطع ثابت 100](intercept-fixed.png) |

هر دو تصویر از همان داده‌ها و مقیاس‌های محور استفاده می‌کنند. خطوط روند به X = 0 بازگشته‌اند تا مقاطعشان نشان داده شود.

به‌صورت پیش‌فرض، [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) مقدار `NaN` را برمی‌گرداند که نمایانگر یک مقطع نامشخص است نه صفر. سپس مقطع به‌صورت خودکار از داده‌ها محاسبه می‌شود.

## **اضافه کردن خط سفارشی**

یک خط سفارشی یک شکل است که بر روی نمودار کشیده می‌شود نه خط روندی که از داده‌های سری محاسبه می‌شود. این مثال از [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) برای افزودن یک خط افقی به اسلاید بر روی نمودار استفاده می‌کند. موقعیت خط در مختصات اسلاید مشخص می‌شود که بر حسب نقطه (point) اندازه‌گیری می‌شود، بنابراین از لبهٔ چپ نمودار شروع می‌شود و در نیمهٔ ارتفاع نمودار قرار می‌گیرد. عرض آن با عرض نمودار برابر است. روش [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) دسترسی به قالب‌بندی خط را فراهم می‌کند تا یک رنگ قرمز ثابت اعمال شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سؤالات متداول**

**«پیش» و «عقب» در خط روند چه معنایی دارند؟**

آنها طول‌های خط روند هستند که به جلو یا عقب پروجکت می‌شوند: برای نمودارهای پراکندگی (XY) — بر حسب واحدهای محور؛ برای نمودارهای غیرپراکندگی — بر حسب تعداد دسته‌ها. فقط مقادیر غیرمنفی مجاز هستند.

**آیا خط روند هنگام خروجی ارائه به PDF یا SVG، یا هنگام رندر یک اسلاید به تصویر نگه داشته می‌شود؟**

بله. Aspose.Slides ارائه‌ها را به [PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/) یا [SVG](/slides/fa/python-java/render-a-slide-as-an-svg-image/) تبدیل می‌کند و نمودارها را به تصاویر رندر می‌کند؛ خطوط روند، به عنوان بخشی از نمودار، در طول این عملیات حفظ می‌شوند. همچنین روشی برای [خروجی تصویر نمودار](/slides/fa/python-java/create-shape-thumbnails/) وجود دارد.