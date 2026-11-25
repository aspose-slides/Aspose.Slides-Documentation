---
title: سفارشی‌سازی نمودارهای 3D در ارائه‌ها با پایتون
linktitle: نمودار 3D
type: docs
url: /fa/python-net/3d-chart/
keywords:
- نمودار 3D
- چرخش
- عمق
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "نمودارهای 3D را در ارائه‌های PowerPoint با Aspose.Slides برای پایتون از طریق .NET ایجاد کنید. چرخش، نسبت‌های ارتفاع، عمق نمودار و فاصله بین سری‌ها را با مثال‌های پایتون تنظیم کنید."
---
## **نمای کلی**

Aspose.Slides for Python via .NET به شما امکان می‌دهد نمای یک نمودار سه‌بعدی را از طریق ویژگی [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) سفارشی کنید. این مقاله نشان می‌دهد چگونه چرخش، نسبت‌های ارتفاع، عمق، محورهای زاویه‌یعنی و فاصله بین سری‌ها را تنظیم کنید و سپس ارائه را در قالب PPTX ذخیره کنید.

## **تنظیم چرخش و عمق یک نمودار سه‌بعدی**

مثال زیر یک [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد می‌کند و با استفاده از [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) یک نمودار ستونی 3D انباشته به اولین اسلاید اضافه می‌کند. این مثال سری‌ها و دسته‌های پیش‌فرض را با دو سری که هر کدام شامل سه مقدار هستند جایگزین می‌کند. اندیس کاربرگ `0` اولین کاربرگ داده‌ای نمودار را شناسایی می‌کند؛ ردیف `0` نام‌های سری‌ها و ستون `0` برچسب‌های دسته‌بندی را دارد.

ویژگی‌های [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) و [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) به ترتیب چرخش نمودار را به 40 و 270 درجه تنظیم می‌کنند. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) عمق آن را به 150٪ از عرض تنظیم می‌کند، در حالی که [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) به جای پرسپکتیو، محورهای زاویه‌یعنی را فعال می‌سازد. ارائه حاصل شامل نمودار پر شده با این تنظیمات نمای 3D است.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **اعمال پرکردن تصویری بر سطح نمودار سه‌بعدی**

می‌توانید [side wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/)، [back wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) و [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) یک نمودار 3D را به‌صورت مستقل پر کنید. نوع پرکردن سطح را با [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) به `PICTURE` تنظیم کنید و یک تصویر اختصاص دهید. برای پر کردن یک کپی تصویر در تمام سطح، حالت پرکردن تصویر ([picture fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/)) و نوع تصویری سطح ([picture type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/)) را به `STRETCH` تنظیم نمایید.

[arrow.png](arrow.png) را در پوشه کاری ذخیره کنید. مثال چرخش نمودار را اعمال می‌کند و مقدار بیشینه محور عمودی را افزایش می‌دهد تا کف بین ستون‌ها قابل مشاهده باشد. اسلاید دو بار کپی می‌شود و سپس پیکان به سطح متفاوتی در هر اسلاید اعمال می‌شود. هر سه نمودار داده‌ها، زاویهٔ دید و پس‌زمینهٔ یکسانی دارند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

Microsoft PowerPoint سه اسلاید را به‌صورت زیر نشان می‌دهد.

| دیوار جانبی | دیوار پشت | کف |
| --- | --- | --- |
| ![پیکان که به سمت داخل نمودار در دیوار جانبی اشاره می‌کند](side-wall.png) | ![پیکان به سمت راست در دیوار پشت](back-wall.png) | ![پیکان به سمت راست در کف بین ستون‌ها](floor.png) |

## **تنظیم نسبت‌های ارتفاع یک نمودار سه‌بعدی**

از [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) برای تنظیم ارتفاع یک نمودار 3D به‌عنوان درصدی از عرض آن استفاده کنید. این کار نسبت‌های صحنهٔ 3D را بدون تغییر اندازهٔ شیء نمودار در اسلاید تغییر می‌دهد.

مثال زیر یک نمودار [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) با داده‌های پیش‌فرض (سه سری و چهار دسته) ایجاد می‌کند. سه ارائه با نسبت‌های ارتفاع 50٪، 100٪ و 200٪ ذخیره می‌شوند. موقعیت، عرض و ارتفاع نمودار ثابت می‌مانند. داده‌ها، چرخش، عمق، فاصلهٔ سری‌ها و قالب‌بندی در همهٔ فایل‌ها یکسان است؛ تنها درصد ارتفاع تغییر می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

تصاویر زیر از ارائه‌های تولید شده با استفاده از Microsoft PowerPoint استخراج شده‌اند. درصد کمتر صحنهٔ مسطح‌تری تولید می‌کند، در حالی که درصد بزرگتر صحنهٔ بلندتری را در همان شیء نمودار ایجاد می‌کند. PowerPoint ممکن است فواصل تیک محور و مکان برچسب‌ها را برای متناسب شدن صحنه تنظیم کند.

| ارتفاع: 50٪ | ارتفاع: 100٪ | ارتفاع: 200٪ |
| --- | --- | --- |
| ![نمودار ستونی 3D با ارتفاع تنظیم شده به 50٪ از عرض آن](height_percent_50.png) | ![نمودار ستونی 3D با ارتفاع تنظیم شده به 100٪ از عرض آن](height_percent_100.png) | ![نمودار ستونی 3D با ارتفاع تنظیم شده به 200٪ از عرض آن](height_percent_200.png) |

این ویژگی‌ها جنبه‌های مختلفی از نمودار را کنترل می‌کنند:

| ویژگی | اثر |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | ارتفاع صحنهٔ 3D به‌عنوان درصدی از عرض آن. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | ارتفاع شیء نمودار بر روی اسلاید، به پوینت. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | عمق صحنهٔ 3D به‌عنوان درصدی از عرض آن. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | فاصله بین سری‌ها در محور عمق، به‌عنوان درصدی از عرض مارکر. |

تنظیم ارتفاع بر نمودارهای ستونی و میله‌ای 3D تأثیر می‌گذارد، از جمله انواع سیلندری، کونوس و هرم، همچنین نمودارهای خطی، مساحتی، دایره‌ای و سطحی 3D. مقایسهٔ بالا از نوع تأیید شدهٔ `COLUMN_3D` استفاده می‌کند. این تنظیم شکل نمودار 2D `CLUSTERED_COLUMN` یا `BUBBLE_WITH_3D` را تغییر نمی‌دهد؛ این نام‌ها عضو شمارۀ [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) هستند. برای سایر تنظیمات ظاهر نمودار، به [Chart Formatting](/slides/fa/python-net/chart-formatting/) مراجعه کنید.

## **تنظیم فاصله بین سری‌ها**

از [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) برای کنترل فاصله بین سری‌های داده‌ای در محور عمق یک نمودار 3D استفاده کنید؛ مقدار به‌صورت درصدی از عرض مارکر بیان می‌شود. مقادیر بین **0 تا 500** مجاز هستند: `0` فاصله را حذف می‌کند، در حالی که مقادیر بزرگ‌تر فاصله را افزایش می‌دهند. با ثابت ماندن عمق نمودار، افزایش فاصله باعث نازک‌تر شدن مارکرها در محور عمق می‌شود.

به گروه از طریق [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) دسترسی پیدا کنید. این تنظیم برای تمام سری‌های آن گروه اعمال می‌شود، نه تنها برای سری‌ای که برای دسترسی استفاده شده است. ویژگی [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) فقط خواندنی است و مقدار تنظیمات گروه والد را نشان می‌دهد.

این تنظیم بر نمودارهای ستونی و میله‌ای 3D تأثیر می‌گذارد، از جمله انواع سیلندری، کونوس و هرم، همچنین نمودارهای خطی و مساحتی 3D. ظاهر بستگی به این دارد که سری‌ها در عمق چیدمان شده باشند، خوشه‌ای یا انباشته. برای مقایسهٔ واضح فاصله‌ها بین سری‌های جداگانه، از `ChartType.COLUMN_3D` در شمارۀ [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) استفاده کنید.

این ویژگی‌ها جنبه‌های مختلفی از نمودار را کنترل می‌کنند:

| ویژگی | اثر |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | فاصله بین سری‌ها در محور عمق، به‌عنوان درصدی از عرض مارکر. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | فاصله بین خوشه‌های میله یا ستون مجاور، به‌عنوان درصدی از عرض میله یا ستون. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | عمق کلی نمودار، به‌عنوان درصدی از عرض نمودار. |

مثال زیر از داده‌های پیش‌فرض نمودار استفاده می‌کند که شامل سه سری و چهار دسته است. دو ارائه با داده‌ها، چرخش، عرض فاصله و عمق نمودار یکسان ذخیره می‌شوند؛ تنها عمق فاصله تغییر می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

تصاویر زیر از ارائه‌های تولید شده با استفاده از Microsoft PowerPoint استخراج شده‌اند.

| عمق فاصله: 0٪ | عمق فاصله: 500٪ |
| --- | --- |
| ![نمودار ستونی 3D بدون فاصله بین سری‌ها در محور عمق](gap_depth_0.png) | ![نمودار ستونی 3D با فاصلهٔ 500 درصدی بین سری‌ها در محور عمق](gap_depth_500.png) |

## **تغییر نوع سری سه‌بعدی و شکل میله**

در یک نمودار سیلندری خوشه‌ای، اولین سری با میله‌های سیلندری شروع می‌شود. مثال قبل و بعد از هر تغییر، مقدارهای [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) و [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) را می‌خواند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| تغییر در اولین سری | `type` | `bar_3d_shape` |
| --- | --- | --- |
| ایجاد نمودار | `CLUSTERED_CYLINDER` | `CYLINDER` |
| تنظیم `type` به `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| تنظیم `bar_3d_shape` به `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

تنظیم شکل به `BOX` همچنین نوع سری را به `CLUSTERED_COLUMN_3D` تغییر می‌دهد. اگر کد شما بر اساس نوع سری شاخه‌بندی می‌شود، بعد از تغییر شکل، مقدار `series.type` را دوباره بخوانید؛ مقدار کشیده‌شده پیش از انتساب هنوز شاخهٔ `CLUSTERED_CONE` را انتخاب می‌کند.

![مقایسهٔ PowerPoint که اولین سری را از سیلندری، کونوس و ستون‌های مستطیلی از چپ به راست نشان می‌دهد](series-shapes.png)

## **پرسش‌های متداول**

**کدام انواع نمودارها حالت 3D را در Aspose.Slides پشتیبانی می‌کنند؟**

Aspose.Slides انواع سه‌بعدی نمودارهای ستونی را پشتیبانی می‌کند، از جمله Column 3D، Clustered Column 3D، Stacked Column 3D و 100 % Stacked Column 3D، به همراه انواع 3D مرتبط که از طریق شمارۀ [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) در دسترس هستند. برای دریافت فهرست دقیق و به‌روز، عضوهای [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) را در مرجع API نسخه نصب‌شده خود بررسی کنید.

**آیا می‌توانم تصویر رستر از یک نمودار 3D برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید نمودار را با استفاده از [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) به تصویر صادر کنید یا کل اسلاید را به فرمت‌هایی مانند PNG یا JPEG رندر کنید ([render the entire slide](/slides/fa/python-net/convert-powerpoint-to-png/)). این کار زمانی مفید است که به پیش‌نمایش رستر نیاز داشته باشید یا بخواهید نمودار را بدون نیاز به PowerPoint در اسناد، داشبوردها یا صفحات وب تعبیه کنید.

**کارایی ساخت و رندر نمودارهای بزرگ 3D چقدر است؟**

کارایی به حجم داده‌ها و پیچیدگی بصری وابسته است. برای بهترین نتایج، اثرات 3D را به حداقل برسانید، از بافت‌های سنگین بر روی دیوارها و نواحی نمودار خودداری کنید، تعداد نقاط داده در هر سری را در صورت امکان محدود کنید و خروجی را با رزولوشن و ابعاد متناسب با نمایشگر یا چاپ هدف رندر کنید.