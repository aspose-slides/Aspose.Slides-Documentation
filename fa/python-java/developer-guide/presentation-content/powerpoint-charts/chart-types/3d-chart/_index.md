---
title: سفارشی‌سازی نمودارهای 3D در ارائه‌ها با استفاده از پایتون
linktitle: نمودار 3D
type: docs
url: /fa/python-java/3d-chart/
keywords:
- نمودار 3D
- چرخش
- عمق
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "نمودارهای 3D را در ارائه‌های PowerPoint با Aspose.Slides برای Python از طریق Java ایجاد کنید. چرخش، نسبت‌های ارتفاع، عمق نمودار و فاصله بین سری‌ها را با مثال‌های Python تنظیم کنید."
---
## **نمای کلی**

Aspose.Slides for Python via Java به شما امکان می‌دهد نمای یک نمودار 3D را از طریق متد [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D) سفارشی‌سازی کنید. این مقاله نشان می‌دهد چگونه چرخش، نسبت‌های ارتفاع، عمق، محورهای زاویه‌درست و فاصله بین سری‌ها را تنظیم کرده و سپس ارائه را در قالب PPTX ذخیره کنید.

## **تنظیم چرخش و عمق یک نمودار 3D**

مثال زیر یک [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد می‌کند و از [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) برای افزودن یک نمودار ستونی 3D انباشته به اولین اسلاید آن استفاده می‌کند. این مثال سری‌ها و دسته‌های پیش‌فرض را با دو سری که هر کدام شامل سه مقدار هستند، جایگزین می‌کند. شاخص برگه کاری `0` برگه داده اول نمودار را شناسایی می‌کند؛ سطر `0` نام‌های سری‌ها را نگه می‌دارد و ستون `0` برچسب‌های دسته‌ها را.

متدهای [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) و [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) به ترتیب چرخش نمودار را روی 40 و 270 درجه تنظیم می‌کنند. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) عمق آن را به 150٪ از عرض آن تنظیم می‌کند، در حالی که [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) محورهای زاویه‌درست را به جای پرسپکتیو فعال می‌سازد. ارائه حاصل شامل نمودار پرشده با این تنظیمات نمای 3D است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **اعمال پر کردن تصویر به سطح یک نمودار 3D**

یک نمودار 3D دارای سه سطح است که می‌توانید به‌صورت مستقل پر کنید: [side wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getSideWall)، [back wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) و [floor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor). نوع پر کردن سطح را با استفاده از [fill type](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) به `Picture` تنظیم کنید و یک تصویر اختصاص دهید. هر دو حالت پر کردن تصویر با [picture fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) و نوع تصویر سطح با [picture type](https://reference.aspose.com/slides/python-java/aspose.slides/chartwall/#setPictureType) را به `Stretch` تنظیم کنید تا یک نسخه از تصویر در سراسر سطح قرار گیرد.

فایل [arrow.png](arrow.png) را در پوشه کاری ذخیره کنید. مثال نمودار را می‌چرخاند و مقدار حداکثر محور عمودی را افزایش می‌دهد تا کف بین ستون‌ها قابل مشاهده باشد. سپس اسلاید را دو بار تکثیر می‌کند و پیکان را بر سطح متفاوتی در هر اسلاید اعمال می‌کند. هر سه نمودار داده، زاویه دید و پس‌زمینه یکسانی دارند.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, PictureFillMode, PictureType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(30)
    
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(24)

    back_slide = presentation.getSlides().addClone(slide)
    floor_slide = presentation.getSlides().addClone(slide)
    back_chart = back_slide.getShapes().get_Item(0)
    floor_chart = floor_slide.getShapes().get_Item(0)

    image_bytes = Path("arrow.png").read_bytes()
    arrow = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_bytes))

    surfaces = (chart.getSideWall(), back_chart.getBackWall(), floor_chart.getFloor())
    for surface in surfaces:
        fill = surface.getFormat().getFill()
        fill.setFillType(FillType.Picture)
        picture_fill = fill.getPictureFillFormat()
        picture_fill.getPicture().setImage(arrow)
        picture_fill.setPictureFillMode(PictureFillMode.Stretch)
        surface.setPictureType(PictureType.Stretch)

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

مایکروسافت پاورپوینت سه اسلاید را به صورت زیر نمایش می‌دهد.

| دیوار کناری | دیوار پشت | کف |
| --- | --- | --- |
| ![پیکان اشاره‌کننده به داخل نمودار در امتداد دیوار کناری](side-wall.png) | ![پیکان که به سمت راست در طول دیوار پشت اشاره می‌کند](back-wall.png) | ![پیکان که به سمت راست در کف بین ستون‌ها اشاره می‌کند](floor.png) |

## **تنظیم نسبت‌های ارتفاع یک نمودار 3D**

از [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) برای تنظیم ارتفاع یک نمودار 3D به صورت درصدی از عرض آن استفاده کنید. این کار نسبت‌های صحنه 3D را بدون تغییر اندازه‌ی شی نمودار در اسلاید تغییر می‌دهد.

مثال زیر یک نمودار [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) با داده‌های پیش‌فرض ایجاد می‌کند: سه سری و چهار دسته. این مثال سه ارائه با نسبت‌های ارتفاع 50٪، 100٪ و 200٪ ذخیره می‌کند. موقعیت، عرض و ارتفاع نمودار ثابت می‌مانند. داده‌ها، چرخش، عمق، فاصله سری‌ها و قالب‌بندی در تمام سه فایل یکسان هستند؛ تنها درصد ارتفاع تغییر می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تصاویر زیر تنظیمات ارتفاع یکسان را در مثال .NET معادل نشان می‌دهند و با استفاده از مایکروسافت پاورپوینت استخراج شده‌اند. درصد کوچکتر صحنه‌ای صاف‌تر تولید می‌کند، در حالی که درصد بزرگتر صحنه‌ای بلندتر در همان شی نمودار ایجاد می‌کند. پاورپوینت ممکن است فواصل تیک‌های محور و موقعیت برچسب‌ها را برای تطبیق با صحنه تنظیم کند.

| ارتفاع: 50% | ارتفاع: 100% | ارتفاع: 200% |
| --- | --- | --- |
| ![نمودار ستونی 3D با ارتفاع تنظیم شده به 50 درصد از عرض آن](height_percent_50.png) | ![نمودار ستونی 3D با ارتفاع تنظیم شده به 100 درصد از عرض آن](height_percent_100.png) | ![نمودار ستونی 3D با ارتفاع تنظیم شده به 200 درصد از عرض آن](height_percent_200.png) |

این متدها جنبه‌های مختلفی از نمودار را کنترل می‌کنند:

| متد | تأثیر |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | ارتفاع صحنه 3D به صورت درصدی از عرض آن. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | ارتفاع شی نمودار در اسلاید، به نقطه. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | عمق صحنه 3D به صورت درصدی از عرض آن. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | فاصله بین سری‌ها در محور عمق، به درصدی از عرض مارکر. |

تنظیم ارتفاع بر نمودارهای ستونی و میله‌ای 3D، شامل انواع سلندری، مخروطی و هرم‌دار، و همچنین نمودارهای خطی، مساحتی، کیکی و سطحی 3D تأثیر می‌گذارد. مقایسه فوق از نوع تأیید شده `Column3D` استفاده می‌کند. این تنظیم ظاهر یک نمودار 2D `ClusteredColumn` یا `BubbleWith3D` را تغییر نمی‌دهد؛ این نام‌ها اعضای کلاس [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) هستند. برای سایر تنظیمات ظاهر نمودارها، به [Chart Formatting](/slides/fa/python-java/chart-formatting/) مراجعه کنید.

## **تنظیم فاصله بین سری‌ها**

از [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) برای کنترل فاصله بین سری‌های داده در طول محور عمق یک نمودار 3D استفاده کنید، که به صورت درصدی از عرض مارکر بیان می‌شود. از مقادیر **0 تا 500** استفاده کنید، شامل: `0` فاصله را حذف می‌کند، در حالی که مقادیر بزرگتر فاصله را افزایش می‌دهند. با عمق ثابت نمودار، افزایش فاصله باعث باریک‌تر شدن مارکرها در محور عمق می‌شود.

گروه را از طریق [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) دسترسی پیدا کنید. این تنظیم برای هر سری در آن گروه اعمال می‌شود، نه فقط سری‌ای که برای دسترسی استفاده شده است. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) فاصله عمقی را برمی‌گرداند و تنظیمات گروه والد را نشان می‌دهد.

این تنظیم بر نمودارهای ستونی و میله‌ای 3D، شامل انواع سلندری، مخروطی و هرم‌دار، و همچنین نمودارهای خطی و مساحتی 3D تأثیر می‌گذارد. ظاهر بستگی دارد به اینکه سری‌ها به صورت عمقی، خوشه‌ای یا انباشته مرتب شده باشند. برای مقایسه واضح فاصله‌ها بین سری‌های جداگانه، از `ChartType.Column3D` در کلاس [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) استفاده کنید.

این متدها جنبه‌های مختلفی از نمودار را کنترل می‌کنند:

| متد | تأثیر |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | فاصله بین سری‌ها در محور عمق، به درصدی از عرض مارکر. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | فاصله بین خوشه‌های میله یا ستون مجاور، به درصدی از عرض میله یا ستون. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | عمق کلی نمودار، به درصدی از عرض نمودار. |

مثال خودکفای زیر از داده‌های پیش‌فرض نمودار استفاده می‌کند که شامل سه سری و چهار دسته است. این مثال دو ارائه با داده، چرخش، عرض فاصله و عمق نمودار یکسان ذخیره می‌کند؛ تنها عمق فاصله تغییر می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تصاویر زیر تنظیمات یکسان عمق فاصله را در مثال .NET معادل نشان می‌دهند و با استفاده از مایکروسافت پاورپوینت استخراج شده‌اند.

| عمق فاصله: 0% | عمق فاصله: 500% |
| --- | --- |
| ![نمودار ستونی 3D بدون فاصله بین سری‌ها در طول محور عمق](gap_depth_0.png) | ![نمودار ستونی 3D با فاصله 500 درصدی بین سری‌ها در طول محور عمق](gap_depth_500.png) |

## **تغییر نوع سری 3D و شکل میله**

در یک نمودار سلندری خوشه‌ای، سری اول با شکل میله‌ای سلندری شروع می‌شود. مثال مقادیر عددی بازگردانده شده توسط [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) و [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) را قبل و پس از هر تغییر چاپ می‌کند. جدول نام ثابت‌های مربوطه را نشان می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| تغییر در سری اول | نوع سری | شکل میله |
| --- | --- | --- |
| ایجاد نمودار | `ClusteredCylinder` | `Cylinder` |
| تنظیم نوع سری به `ClusteredCone` | `ClusteredCone` | `Cone` |
| تنظیم شکل میله به `Box` | `ClusteredColumn3D` | `Box` |

تنظیم شکل به `Box` همچنین نوع سری را به `ClusteredColumn3D` تغییر می‌دهد. اگر کد شما بر اساس نوع سری شاخه‌بندی می‌شود، پس از تغییر شکل، `series.getType()` را فراخوانی کنید. مقدار ذخیره‌شده قبل از انتساب همچنان شاخه `ClusteredCone` را انتخاب خواهد کرد.

![مقایسه پاورپوینت نشان‌دهنده سری اول به صورت سیلندرها، مخروط‌ها و ستون‌های مستطیلی از چپ به راست](series-shapes.png)

## **FAQ**

**کدام نوع نمودارها حالت 3D را در Aspose.Slides پشتیبانی می‌کنند؟**

Aspose.Slides انواع 3D نمودارهای ستونی، از جمله Column 3D، Clustered Column 3D، Stacked Column 3D و 100% Stacked Column 3D را به همراه انواع 3D مرتبط که از طریق کلاس [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) در دسترس هستند، پشتیبانی می‌کند. برای دریافت فهرست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) را در مرجع API نسخه نصب‌شده خود بررسی کنید.

**آیا می‌توانم تصویر رستر از یک نمودار 3D برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید نمودار را با استفاده از [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) به تصویر صادر کنید یا [render the entire slide](/slides/fa/python-java/convert-powerpoint-to-png/) را به فرمت‌هایی مانند PNG یا JPEG تبدیل کنید. این کار زمانی مفید است که به پیش‌نمایش رستری نیاز دارید یا می‌خواهید نمودار را بدون نیاز به پاورپوینت در اسناد، داشبوردها یا صفحات وب جاسازی کنید.

**عملکرد ساخت و رندر نمودارهای بزرگ 3D چقدر است؟**

عملکرد به حجم داده‌ها و پیچیدگی بصری وابسته است. برای بهترین نتایج، اثرات 3D را به حداقل برسانید، از بافت‌های سنگین بر روی دیوارها و نواحی نمودار خودداری کنید، در صورت امکان تعداد نقاط داده در هر سری را محدود کنید و خروجی را با رزولوشن و ابعاد مناسب برای نمایش یا چاپ هدف رندر کنید.