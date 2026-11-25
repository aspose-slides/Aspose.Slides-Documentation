---
title: سفارشی‌سازی نمودارهای 3D در ارائه‌ها با استفاده از Java
linktitle: نمودار 3D
type: docs
url: /fa/java/3d-chart/
keywords:
- نمودار 3D
- چرخش
- عمق
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "نمودارهای 3D را در ارائه‌های PowerPoint با Aspose.Slides برای Java ایجاد کنید. چرخش، نسبت‌های ارتفاع، عمق نمودار و فاصله بین سری‌ها را با مثال‌های Java تنظیم کنید."
---
## **نمای کلی**

Aspose.Slides for Java به شما اجازه می‌دهد نمای یک نمودار 3D را از طریق روش [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) سفارشی کنید. این مقاله نشان می‌دهد چگونه چرخش، نسبت‌های ارتفاع، عمق، محورها با زاویهٔ راست و فاصله بین سری‌ها را تنظیم کنید و سپس ارائه را در قالب PPTX ذخیره کنید.

## **تنظیم چرخش و عمق یک نمودار 3D**

مثال زیر یک [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد می‌کند و از [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) برای افزودن یک نمودار ستونی 3D انباشته به اسلاید اول آن استفاده می‌نماید. این مثال سری‌ها و دسته‌های پیش‌فرض را با دو سری که هر کدام سه مقدار دارند، جایگزین می‌کند. شاخص ورق کاری `0` اولین ورق داده‌های نمودار را شناسایی می‌کند؛ ردیف `0` نام‌های سری‌ها را دارد و ستون `0` برچسب‌های دسته‌بندی را دارد.

متدهای [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) و [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) به ترتیب چرخش نمودار را به 40 و 270 درجه تنظیم می‌کنند. [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) عمق آن را به 150٪ از عرضش تنظیم می‌کند، در حالی که [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) به‌جای پرسپکتیو، محورها را با زاویهٔ راست فعال می‌سازد. ارائهٔ حاصل شامل نمودار پرشده با این تنظیمات نمای 3D است.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **اعمال پر کردن تصویر بر سطح یک نمودار 3D**

یک نمودار 3D دارای سه سطح است که می‌توانید به‌صورت مستقل پر کنید: [side wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getSideWall--)، [back wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--)، و [floor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--). نوع پر کردن سطح را با استفاده از [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) به `Picture` تنظیم کرده و یک تصویر اختصاص دهید. هم [picture fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) و هم [picture type](https://reference.aspose.com/slides/java/com.aspose.slides/ichartwall/#setPictureType-int-) سطح را به `Stretch` تنظیم کنید تا یک کپی تصویر در تمام سطح جای بگیرد.

فایل [arrow.png](arrow.png) را در پوشه کاری ذخیره کنید. مثال نمودار را می‌چرخاند و مقدار حداکثر محور عمودی را افزایش می‌دهد تا کف بین ستون‌ها قابل مشاهده باشد. سپس اسلاید را دو بار کلون می‌کند و پیکان را بر سطح متفاوتی در هر اسلاید اعمال می‌کند. هر سه نمودار داده، زاویهٔ دید و پس‌زمینهٔ یکسانی را حفظ می‌کنند.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    byte[] imageBytes = Files.readAllBytes(Paths.get("arrow.png"));
    IPPImage arrow = presentation.getImages().addImage(imageBytes);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint سه اسلاید را به‌صورت زیر نشان می‌دهد.

| دیوار جانبی | دیوار پشت | کف |
| --- | --- | --- |
| ![پیکان که به سمت داخل نمودار در امتداد دیوار جانبی اشاره می‌کند](side-wall.png) | ![پیکان که به راست در سراسر دیوار پشت اشاره می‌کند](back-wall.png) | ![پیکان که به راست در سراسر کف بین ستون‌ها اشاره می‌کند](floor.png) |

## **تنظیم نسبت‌های ارتفاع یک نمودار 3D**

از [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) برای تعیین ارتفاع یک نمودار 3D به‌صورت درصدی از عرض آن استفاده کنید. این کار نسبت‌های صحنهٔ 3D را بدون تغییر اندازهٔ شیء نمودار در اسلاید تغییر می‌دهد.

مثال زیر یک نمودار [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) را با داده‌های پیش‌فرض ایجاد می‌کند: سه سری و چهار دسته. این مثال سه ارائه با نسبت‌های ارتفاع 50٪، 100٪ و 200٪ ذخیره می‌کند. موقعیت، عرض و ارتفاع نمودار ثابت می‌مانند. داده‌ها، چرخش، عمق، فاصلهٔ سری‌ها و قالب‌بندی در تمام سه فایل یکسان هستند؛ فقط درصد ارتفاع تغییر می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

تصاویر زیر همان تنظیمات ارتفاع را در مثال معادل .NET نشان می‌دهند و با استفاده از Microsoft PowerPoint صادر شده‌اند. درصد کمتر صحنه‌ای صاف‌تر و درصد بالاتر صحنه‌ای بلندتر در همان شیء نمودار تولید می‌کند. PowerPoint ممکن است فاصله‌های علامت‌گذاری محور و موقعیت برچسب‌ها را نیز برای تناسب صحنه تنظیم کند.

| ارتفاع: 50% | ارتفاع: 100% | ارتفاع: 200% |
| --- | --- | --- |
| ![نمودار ستونی 3D با ارتفاع تنظیم شده به 50 درصد از عرض آن](height_percent_50.png) | ![نمودار ستونی 3D با ارتفاع تنظیم شده به 100 درصد از عرض آن](height_percent_100.png) | ![نمودار ستونی 3D با ارتفاع تنظیم شده به 200 درصد از عرض آن](height_percent_200.png) |

این متدها جنبه‌های مختلف نمودار را کنترل می‌کنند:

| متد | اثر |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | ارتفاع صحنه 3D به‌عنوان درصدی از عرض آن. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | ارتفاع شیء نمودار در اسلاید، به پوینت. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | عمق صحنه 3D به‌عنوان درصدی از عرض آن. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | فاصله بین سری‌ها در محور عمق، به‌عنوان درصدی از عرض علامت. |

تنظیم ارتفاع بر نمودارهای ستونی و میله‌ای 3D، از جمله گونه‌های سیلندری، مخروطی و هرم‌مانند، و همچنین نمودارهای خطی، مساحتی، دایره‌ای و سطحی 3D تاثیر می‌گذارد. مقایسهٔ بالا از نوع تأیید شدهٔ `Column3D` استفاده می‌کند. این تنظیم ظاهر نمودار 2D `ClusteredColumn` یا `BubbleWith3D` را تغییر نمی‌دهد؛ این نام‌ها اعضای کلاس [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) هستند. برای تنظیمات دیگر ظاهر نمودار، به [Chart Formatting](/slides/fa/java/chart-formatting/) مراجعه کنید.

## **تنظیم فاصله بین سری‌ها**

از [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) برای کنترل فاصله بین سری‌های داده در محور عمق یک نمودار 3D استفاده کنید، که به‌صورت درصدی از عرض علامت بیان می‌شود. از مقادیر **0 تا 500** استفاده کنید: `0` فاصله را حذف می‌کند، در حالی که مقادیر بزرگتر فواصل را افزایش می‌دهند. با عمق ثابت نمودار، افزایش فاصله باعث باریک‌تر شدن علامت‌ها در محور عمق می‌شود.

گروه را از طریق [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) دسترسی پیدا کنید. این تنظیم برای هر سری در آن گروه اعمال می‌شود، نه فقط برای سری‌ای که برای دسترسی استفاده شده است. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) مقدار فاصله عمق را برمی‌گرداند و تنظیمات گروه والد را نشان می‌دهد.

این تنظیم بر نمودارهای ستونی و میله‌ای 3D، شامل گونه‌های سیلندری، مخروطی و هرم‌مانند، و همچنین نمودارهای خطی و مساحتی 3D تاثیر می‌گذارد. ظاهر بستگی به این دارد که سری‌ها به صورت عمقی، خوشه‌ای یا انباشته ترتیب داده شوند. برای مقایسهٔ واضح فواصل بین سری‌های جداگانه، از `ChartType.Column3D` موجود در کلاس [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) استفاده کنید.

این متدها جنبه‌های مختلف نمودار را کنترل می‌کنند:

| متد | اثر |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | فاصله بین سری‌ها در محور عمق، به‌عنوان درصدی از عرض علامت. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | فاصله بین خوشه‌های میله یا ستون متوالی، به‌عنوان درصدی از عرض میله یا ستون. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | عمق کلی نمودار، به‌عنوان درصدی از عرض نمودار. |

مثال خودکار زیر از داده‌های پیش‌فرض نمودار استفاده می‌کند، که شامل سه سری و چهار دسته است. این مثال دو ارائه با داده، چرخش، عرض فاصله و عمق نمودار یکسان ذخیره می‌کند؛ فقط عمق فاصله تغییر می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

تصاویر زیر همان تنظیمات عمق فاصله را در مثال معادل .NET نشان می‌دهند و با استفاده از Microsoft PowerPoint صادر شده‌اند.

| عمق فاصله: 0% | عمق فاصله: 500% |
| --- | --- |
| ![نمودار ستونی 3D بدون هیچ فاصله‌ای بین سری‌ها در محور عمق](gap_depth_0.png) | ![نمودار ستونی 3D با فاصلهٔ 500 درصدی بین سری‌ها در محور عمق](gap_depth_500.png) |

## **تغییر نوع سری 3D و شکل میله**

در یک نمودار سیلندری خوشه‌ای، سری اول با شکل میلهٔ سیلندری شروع می‌شود. مثال مقادیر صحیح بازگردانده شده توسط [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) و [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) را قبل و بعد از هر تغییر چاپ می‌کند. جدول نام‌های ثابت متناظر را نشان می‌دهد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| تغییر در سری اول | نوع سری | شکل میله |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

تنظیم شکل به `Box` همچنین نوع سری را به `ClusteredColumn3D` تغییر می‌دهد. اگر کد شما بر اساس نوع سری شاخه‌بندی می‌کند، پس از تغییر شکل، `series.getType()` را صدا بزنید. مقداری که قبل از انتساب ذخیره شده باشد، هنوز شاخهٔ `ClusteredCone` را انتخاب می‌کند.

![مقایسهٔ PowerPoint که سری اول را به‌عنوان سیلندری‌ها، مخروط‌ها و ستون‌های مستطیلی از چپ به راست نشان می‌دهد](series-shapes.png)

## **پرسش‌های متداول**

**کدام انواع نمودار در Aspose.Slides حالت 3D را پشتیبانی می‌کنند؟**

Aspose.Slides انواع 3D نمودارهای ستونی را پشتیبانی می‌کند، از جمله Column 3D، Clustered Column 3D، Stacked Column 3D و 100% Stacked Column 3D، به‌همراه انواع مرتبط 3D که از طریق کلاس [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) در دسترس هستند. برای دریافت فهرست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) را در مرجع API نسخهٔ نصب شدهٔ خود بررسی کنید.

**آیا می‌توانم تصویر رستر از یک نمودار 3D برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید یک نمودار را به تصویر صادر کنید با استفاده از [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) یا [render the entire slide](/slides/fa/java/convert-powerpoint-to-png/) به فرمت‌هایی مانند PNG یا JPEG. این کار مفید است وقتی به پیش‌نمایش رستر نیاز دارید یا می‌خواهید نمودار را در اسناد، داشبوردها یا صفحات وب بدون نیاز به PowerPoint جاسازی کنید.

**عملکرد ساخت و رندر نمودارهای بزرگ 3D چقدر است؟**

عملکرد به حجم داده و پیچیدگی بصری بستگی دارد. برای بهترین نتایج، اثرات 3D را به حداقل برسانید، از بافت‌های سنگین روی دیوارها و نواحی نمودار اجتناب کنید، در صورت امکان تعداد نقاط داده در هر سری را محدود کنید و رندر را به خروجی با اندازهٔ مناسب (رزولوشن و ابعاد) انجام دهید تا با نیازهای نمایش یا چاپ هدف منطبق باشد.