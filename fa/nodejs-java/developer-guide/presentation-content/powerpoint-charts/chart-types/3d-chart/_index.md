---
title: سفارشی‌سازی نمودارهای 3D در ارائه‌ها با استفاده از جاوااسکریپت
linktitle: نمودار 3D
type: docs
url: /fa/nodejs-java/3d-chart/
keywords:
- نمودار 3D
- چرخش
- عمق
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "نمودارهای 3D را در ارائه‌های PowerPoint با Aspose.Slides برای Node.js از طریق Java ایجاد کنید. چرخش، نسبت‌های ارتفاع، عمق نمودار و فاصله بین سری‌ها را با مثال‌های JavaScript تنظیم کنید."
---
## **نمای کلی**

Aspose.Slides for Node.js via Java به شما امکان می‌دهد نمای یک نمودار 3D را از طریق متد [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) سفارشی کنید. این مقاله نشان می‌دهد که چگونه چرخش، نسبت‌های ارتفاع، عمق، محورهای زاویه‌دار و فاصله بین سری‌ها را تنظیم کرده و سپس ارائه را در قالب PPTX ذخیره کنید.

## **تنظیم چرخش و عمق نمودار 3D**

مثال زیر یک [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد می‌کند و از [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) برای افزودن یک نمودار ستونی 3D پشته‌ای به اسلاید اول استفاده می‌کند. سری‌ها و دسته‌بندی‌های پیش‌فرض را با دو سری که هر کدام سه مقدار دارند، جایگزین می‌کند. ایندکس ورق کاری `0` اولین ورق داده نمودار را مشخص می‌کند؛ ردیف `0` نام‌های سری‌ها را در خود دارد و ستون `0` برچسب‌های دسته‌بندی را داراست.

متدهای [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) و [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) به ترتیب چرخش نمودار را به 40 و 270 درجه تنظیم می‌کنند. متد [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) عمق آن را برابر 150٪ از عرضش می‌سازد، در حالی که [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) محورهای زاویه‌دار را به جای پرسپکتیو فعال می‌کند. ارائه حاصل شامل نمودار پر شده با این تنظیمات نمای 3D است.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **اعمال پر رنگ تصویر به سطح نمودار 3D**

می‌توانید به صورت جداگانه [دیوار کناری](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/)، [دیوار پشت](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/)، و [کف](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/) یک نمودار 3D را پر کنید. نوع پر کردن سطح را با [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) به `Picture` تنظیم کنید و یک تصویر اختصاص دهید. هر دو [picture fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/) و [picture type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) سطح را به `Stretch` تنظیم کنید تا یک نسخه از تصویر بر کل سطح کشیده شود.

[arrow.png](arrow.png) را در پوشه کاری ذخیره کنید. مثال، نمودار را چرخانده و مقدار حداکثر محور عمودی را بالا می‌برد تا کف بین ستون‌ها قابل مشاهده باشد. سپس اسلاید را دو بار کپی می‌کند و پیکان را روی سطح متفاوتی در هر اسلاید اعمال می‌کند. هر سه نمودار داده، زاویه نمایشی و پس‌زمینه یکسانی دارند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint سه اسلاید را به صورت زیر نشان می‌دهد.

| دیوار کناری | دیوار پشت | کف |
| --- | --- | --- |
| ![پیکان به سمت داخل نمودار در دیوار کناری](side-wall.png) | ![پیکان به سمت راست در دیوار پشت](back-wall.png) | ![پیکان به سمت راست در کف بین ستون‌ها](floor.png) |

## **تنظیم نسبت‌های ارتفاع نمودار 3D**

از [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) برای تعیین ارتفاع یک نمودار 3D به عنوان درصدی از عرض آن استفاده کنید. این کار نسبت‌های صحنه 3D را بدون تغییر اندازه شی نمودار در اسلاید تغییر می‌دهد.

مثال زیر یک نمودار [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) با داده‌های پیش‌فرض ایجاد می‌کند: سه سری و چهار دسته‌بندی. سه ارائه با نسبت‌های ارتفاع 50٪، 100٪ و 200٪ ذخیره می‌کند. موقعیت، عرض و ارتفاع نمودار ثابت می‌مانند. داده‌ها، چرخش، عمق، فاصله بین سری‌ها و قالب‌بندی در هر سه فایل یکسان است؛ تنها درصد ارتفاع تغییر می‌کند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

تصاویر زیر همان تنظیمات ارتفاع را در مثال معادل .NET نشان می‌دهند و با Microsoft PowerPoint صادر شده‌اند. درصد کمتر صحنه‌ایی صاف‌تر و درصد بیشتر صحنه‌ای بلندتر در همان شی نمودار تولید می‌کند. PowerPoint ممکن است فواصل تیکهای محور و جای‌گذاری برچسب‌ها را برای سازگاری با صحنه تنظیم کند.

| ارتفاع: 50% | ارتفاع: 100% | ارتفاع: 200% |
| --- | --- | --- |
| ![نمودار ستونی 3D با ارتفاع 50 درصد از عرضش](height_percent_50.png) | ![نمودار ستونی 3D با ارتفاع 100 درصد از عرضش](height_percent_100.png) | ![نمودار ستونی 3D با ارتفاع 200 درصد از عرضش](height_percent_200.png) |

این متدها جنبه‌های مختلفی از نمودار را کنترل می‌کنند:

| متد | اثر |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | ارتفاع صحنه 3D به عنوان درصدی از عرض آن. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | ارتفاع شی نمودار روی اسلاید، بر حسب نقطه. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | عمق صحنه 3D به عنوان درصدی از عرض آن. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | فاصله بین سری‌ها در محور عمق، به عنوان درصدی از عرض مارکر. |

تنظیم ارتفاع بر نمودارهای ستونی و میله‌ای 3D شامل انواع سیلندر، مخروط و هرم، همچنین نمودارهای خطی، مساحی، کیکی و سطحی 3D تأثیر می‌گذارد. مقایسه فوق از نوع تأیید شده `Column3D` استفاده می‌کند. این تنظیم ظاهر نمودار 2D `ClusteredColumn` یا `BubbleWith3D` را تغییر نمی‌دهد؛ این نام‌ها اعضای کلاس [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) هستند. برای تنظیمات دیگر ظاهر نمودار، به [Chart Formatting](/slides/fa/nodejs-java/chart-formatting/) مراجعه کنید.

## **تنظیم فاصله بین سری‌ها**

از [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) برای کنترل فاصله بین سری‌های داده در محور عمق یک نمودار 3D استفاده کنید؛ مقدار به‌صورت درصدی از عرض مارکر بیان می‌شود. از مقادیر **0 تا 500** (شامل) استفاده کنید: `0` فاصله را حذف می‌کند، در حالی که مقادیر بزرگ‌تر فاصله را افزایش می‌دهند. با عمق ثابت نمودار، افزایش فاصله باعث نازک‌تر شدن مارکرها در محور عمق می‌شود.

گروه را از طریق [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) دسترسی پیدا کنید. این تنظیم برای هر سری در آن گروه اعمال می‌شود، نه فقط برای سری‌ای که برای دسترسی استفاده شده است. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) عمق فاصله را برمی‌گرداند و تنظیمات گروه والد را نشان می‌دهد.

این تنظیم بر نمودارهای ستونی و میله‌ای 3D، شامل انواع سیلندری، مخروطی و هرمی آن‌ها، همچنین نمودارهای خطی و مساحی 3D تأثیر می‌گذارد. ظاهر بستگی به این دارد که سری‌ها در عمق، خوشه‌ای یا پشته‌ای چیده شوند. برای مقایسه واضح فاصله‌ها بین سری‌های جداگانه، از `ChartType.Column3D` کلاس [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) استفاده کنید.

این متدها جنبه‌های مختلفی از نمودار را کنترل می‌کنند:

| متد | اثر |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | فاصله بین سری‌ها در محور عمق، به عنوان درصدی از عرض مارکر. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | فاصله بین خوشه‌های میله یا ستون مجاور، به عنوان درصدی از عرض میله یا ستون. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | عمق کلی نمودار، به عنوان درصدی از عرض نمودار. |

مثال زیر خودکفا از داده‌های پیش‌فرض استفاده می‌کند که شامل سه سری و چهار دسته‌بندی است. دو ارائه با داده، چرخش، عرض فاصله و عمق نمودار یکسان ذخیره می‌کند؛ تنها عمق فاصله تغییر می‌کند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

تصاویر زیر همان تنظیمات عمق فاصله را در مثال معادل .NET نشان می‌دهند و با Microsoft PowerPoint صادر شده‌اند.

| عمق فاصله: 0% | عمق فاصله: 500% |
| --- | --- |
| ![نمودار ستونی 3D بدون فاصله بین سری‌ها در محور عمق](gap_depth_0.png) | ![نمودار ستونی 3D با فاصله 500 درصدی بین سری‌ها در محور عمق](gap_depth_500.png) |

## **تغییر نوع سری 3D و شکل میله**

در یک نمودار سیلندری خوشه‌ای، سری اول با شکل میله سیلندری شروع می‌شود. مثال مقادیر صحیح بازگردانده‌شده توسط [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) و [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) را قبل و بعد از هر تغییر چاپ می‌کند. جدول نام ثابت‌های متناظر را نشان می‌دهد.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| تغییر به سری اول | نوع سری | شکل میله |
| --- | --- | --- |
| ایجاد نمودار | `ClusteredCylinder` | `Cylinder` |
| تنظیم نوع سری به `ClusteredCone` | `ClusteredCone` | `Cone` |
| تنظیم شکل میله به `Box` | `ClusteredColumn3D` | `Box` |

تنظیم شکل به `Box` همچنین نوع سری را به `ClusteredColumn3D` تغییر می‌دهد. اگر کد شما بر اساس نوع سری شاخه‌بندی می‌شود، پس از تغییر شکل، `series.getType()` را فراخوانی کنید. مقدار کشیده‌شده قبل از انتساب همچنان شاخه `ClusteredCone` را انتخاب می‌کند.

![مقایسه PowerPoint نشان‌دهنده سری اول به شکل سیلندری، مخروطی و ستونی مستطیلی از چپ به راست](series-shapes.png)

## **سوالات متداول**

**کدام انواع نمودار در Aspose.Slides از حالت 3D پشتیبانی می‌کنند؟**

Aspose.Slides انواع 3D نمودارهای ستونی را شامل Column 3D، Clustered Column 3D، Stacked Column 3D و 100% Stacked Column 3D، به‌همراه انواع 3D مرتبط که از طریق کلاس [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) در دسترس هستند، پشتیبانی می‌کند. برای دریافت فهرست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) را در مستندات API نسخه نصب‌یتان بررسی کنید.

**آیا می‌توانم تصویر رستری از یک نمودار 3D برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید نمودار را با استفاده از [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) به تصویر استخراج کنید یا کل اسلاید را به فرمت‌هایی مانند PNG یا JPEG تبدیل کنید ([render the entire slide](/slides/fa/nodejs-java/convert-powerpoint-to-png/)). این کار زمانی مفید است که به پیش‌نمایش رستری نیاز داشته باشید یا بخواهید نمودار را در اسناد، داشبوردها یا صفحات وب بدون نیاز به PowerPoint جاسازی کنید.

**عملکرد ساخت و رندر نمودارهای بزرگ 3D چگونه است؟**

عملکرد به حجم داده و پیچیدگی بصری وابسته است. برای به‑دست‑آمدن نتایج بهتر، اثرات 3D را به حداقل برسانید، از بافت‌های سنگین بر روی دیوارها و نواحی نمودار اجتناب کنید، در صورت امکان تعداد نقاط داده در هر سری را محدود کنید و خروجی را با رزولوشن و ابعاد مناسب برای نمایش یا چاپ هدف رندر کنید.