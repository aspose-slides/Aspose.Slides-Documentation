---
title: سفارشی‌سازی نمودارهای 3D در ارائه‌ها با استفاده از JavaScript
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

Aspose.Slides for Node.js via Java به شما امکان می‌دهد نمای یک نمودار 3D را با استفاده از روش [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) سفارشی کنید. این مقاله نحوه تنظیم چرخش، نسبت‌های ارتفاع، عمق، محورهای زاویه‌دار و فاصله بین سری‌ها را نشان می‌دهد و سپس ارائه را با فرمت PPTX ذخیره می‌کند.

## **تنظیم چرخش و عمق یک نمودار 3D**

مثال زیر یک [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد می‌کند و از [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) برای افزودن یک نمودار ستونی 3D انباشته به اولین اسلاید آن استفاده می‌کند. این مثال سری‌ها و دسته‌ها را به دو سری که هر کدام سه مقدار دارند، جایگزین می‌کند. اندیس کاربرگ `0` کاربرگ داده‌های اولیه نمودار را مشخص می‌کند؛ سطر `0` نام‌های سری‌ها را دارد و ستون `0` برچسب‌های دسته‌ها را.

روش‌های [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) و [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) چرخش نمودار را به ترتیب 40 و 270 درجه تنظیم می‌کنند. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) عمق آن را به 150٪ از عرض تنظیم می‌کند، در حالی که [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) محورهای زاویه‌دار را به جای پرسپکتیو فعال می‌سازد. ارائه نهایی حاوی نمودار پر شده با این تنظیمات نمای 3D است.

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

## **تنظیم نسبت‌های ارتفاع یک نمودار 3D**

از [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) برای تنظیم ارتفاع نمودار 3D به عنوان درصدی از عرض آن استفاده کنید. این کار نسبت‌های صحنه 3D را بدون تغییر اندازه شی نمودار در اسلاید تغییر می‌دهد.

مثال زیر یک نمودار [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) با داده‌های پیش‌فرض ایجاد می‌کند: سه سری و چهار دسته. این مثال سه ارائه با نسبت‌های ارتفاع 50٪، 100٪ و 200٪ ذخیره می‌کند. موقعیت، عرض و ارتفاع نمودار ثابت می‌مانند. داده‌ها، چرخش، عمق، فاصله بین سری‌ها و قالب‌بندی در تمام سه فایل یکسان است؛ تنها درصد ارتفاع تغییر می‌کند.

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

تصاویر زیر تنظیمات ارتفاع یکسان را در مثال معادل .NET نشان می‌دهند و با استفاده از Microsoft PowerPoint استخراج شده‌اند. درصد کمتر صحنه را صاف‌تر می‌کند، در حالی که درصد بزرگتر صحنه را بلندتر می‌سازد. PowerPoint ممکن است بازه‌های تیک محور و موقعیت برچسب‌ها را برای تناسب صحنه تنظیم کند.

| ارتفاع: 50٪ | ارتفاع: 100٪ | ارتفاع: 200٪ |
| --- | --- | --- |
| ![نمودار ستونی 3D با ارتفاع تنظیم شده به 50 درصد از عرض آن](height_percent_50.png) | ![نمودار ستونی 3D با ارتفاع تنظیم شده به 100 درصد از عرض آن](height_percent_100.png) | ![نمودار ستونی 3D با ارتفاع تنظیم شده به 200 درصد از عرض آن](height_percent_200.png) |

این متدها جنبه‌های مختلفی از نمودار را کنترل می‌کنند:

| متد | اثر |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | ارتفاع صحنه 3D به عنوان درصدی از عرض آن. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | ارتفاع شی نمودار در اسلاید، به پوینت. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | عمق صحنه 3D به عنوان درصدی از عرض آن. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | فاصله بین سری‌ها در طول محور عمق، به عنوان درصدی از عرض مارکر. |

تنظیم ارتفاع بر روی نمودارهای ستونی و میله‌ای 3D، شامل انواع استوانه‌ای، مخروطی و هرمی، و همچنین نمودارهای خطی، مساحتی، دایره‌ای و سطحی 3D تأثیر می‌گذارد. مقایسه بالا از نوع معتبر `Column3D` استفاده می‌کند. این تنظیم ظاهر یک نمودار 2D `ClusteredColumn` یا یک نمودار `BubbleWith3D` را تغییر نمی‌دهد؛ این نام‌ها عضو کلاس [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) هستند. برای سایر تنظیمات ظاهر نمودار، به [Chart Formatting](/slides/fa/nodejs-java/chart-formatting/) مراجعه کنید.

## **تنظیم فاصله بین سری‌ها**

از [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) برای کنترل فاصله بین سری‌های داده‌ای در طول محور عمق یک نمودار 3D استفاده کنید؛ این مقدار به عنوان درصدی از عرض مارکر بیان می‌شود. از مقادیر **0 تا 500** به صورت شامل استفاده کنید: `0` فاصله را حذف می‌کند، در حالی که مقادیر بزرگتر فاصله را افزایش می‌دهند. با عمق ثابت نمودار، افزایش فاصله باعث نازک‌تر شدن مارکرها در طول محور عمق می‌شود.

به گروه از طریق [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) دسترسی پیدا کنید. این تنظیم برای هر سری در آن گروه اعمال می‌شود، نه فقط سری‌ای که برای دسترسی به گروه استفاده شده است. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) مقدار عمق فاصله را برمی‌گرداند و تنظیمات گروه والد را نشان می‌دهد.

این تنظیم بر روی نمودارهای ستونی و میله‌ای 3D، شامل انواع استوانه‌ای، مخروطی و هرمی، و همچنین نمودارهای خطی و مساحتی 3D تأثیر می‌گذارد. ظاهر بسته به این است که سری‌ها در عمق، خوشه‌ای یا انباشته چیدمان داشته باشند. برای مقایسه واضح فاصله‌ها بین سری‌های جداگانه، از `ChartType.Column3D` کلاس [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) استفاده کنید.

این متدها جنبه‌های مختلفی از نمودار را کنترل می‌کنند:

| متد | اثر |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | فاصله بین سری‌ها در طول محور عمق، به عنوان درصدی از عرض مارکر. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | فاصله بین خوشه‌های میله یا ستون مجاور، به عنوان درصدی از عرض میله یا ستون. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | عمق کلی نمودار، به عنوان درصدی از عرض نمودار. |

مثال مستقل زیر از داده‌های پیش‌فرض نمودار استفاده می‌کند که شامل سه سری و چهار دسته است. این مثال دو ارائه با داده، چرخش، عرض فاصله و عمق نمودار یکسان ذخیره می‌کند؛ تنها عمق فاصله تغییر می‌کند.

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

تصاویر زیر تنظیمات عمق فاصله یکسان را در مثال معادل .NET نشان می‌دهند و با استفاده از Microsoft PowerPoint استخراج شده‌اند.

| عمق فاصله: 0٪ | عمق فاصله: 500٪ |
| --- | --- |
| ![نمودار ستونی 3D بدون فاصله بین سری‌ها در طول محور عمق](gap_depth_0.png) | ![نمودار ستونی 3D با فاصله 500 درصدی بین سری‌ها در طول محور عمق](gap_depth_500.png) |

## **تغییر نوع سری 3D و شکل میله**

در یک نمودار استوانه‌ای خوشه‌ای، اولین سری با شکل میله‌ای استوانه‌ای شروع می‌شود. مثال مقادیر عددی بازگشتی توسط [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) و [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) را قبل و بعد از هر تغییر چاپ می‌کند. جدول نام ثابت‌های متناظر را نشان می‌دهد.

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

| تغییر در اولین سری | نوع سری | شکل میله |
| --- | --- | --- |
| ایجاد نمودار | `ClusteredCylinder` | `Cylinder` |
| تنظیم نوع سری به `ClusteredCone` | `ClusteredCone` | `Cone` |
| تنظیم شکل میله به `Box` | `ClusteredColumn3D` | `Box` |

تنظیم شکل به `Box` همچنین نوع سری را به `ClusteredColumn3D` تغییر می‌دهد. اگر کد شما بر اساس نوع سری شاخه‌بندی می‌شود، پس از تغییر شکل `series.getType()` را فراخوانی کنید. مقدار کشیده‌شده قبل از انتساب هنوز شاخه `ClusteredCone` را انتخاب می‌کند.

![مقایسه PowerPoint که اولین سری را به صورت استوانه، مخروط و ستون‌های مستطیلی از چپ به راست نشان می‌دهد](series-shapes.png)

## **سوالات متداول**

**کدام انواع نمودار در Aspose.Slides حالت 3D را پشتیبانی می‌کنند؟**

Aspose.Slides انواع 3D نمودارهای ستونی را پشتیبانی می‌کند، شامل Column 3D، Clustered Column 3D، Stacked Column 3D و 100% Stacked Column 3D، به همراه انواع 3D مرتبط که از طریق کلاس [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) در دسترس هستند. برای دریافت فهرست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) را در مرجع API نسخه نصب‌شده خود بررسی کنید.

**آیا می‌توانم تصویر رستر از یک نمودار 3D برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید یک نمودار را با استفاده از [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) به تصویر صادر کنید یا کل اسلاید را با روش [render the entire slide](/slides/fa/nodejs-java/convert-powerpoint-to-png/) به فرمت‌هایی مانند PNG یا JPEG رندر کنید. این کار زمانی مفید است که به پیش‌نمایش رستری نیاز دارید یا می‌خواهید نمودار را بدون نیاز به PowerPoint در اسناد، داشبوردها یا صفحات وب جاسازی کنید.

**کارایی ساخت و رندر نمودارهای بزرگ 3D چقدر است؟**

کارایی به حجم داده‌ها و پیچیدگی بصری بستگی دارد. برای بهترین نتایج، اثرات 3D را به حداقل برسانید، از بافت‌های سنگین بر روی دیوارها و نواحی نمودار پرهیز کنید، در صورت امکان تعداد نقاط داده برای هر سری را محدود کنید و به ابعاد خروجی مناسب (رزولوشن و اندازه) برای نمایش یا چاپ هدف رندر کنید.