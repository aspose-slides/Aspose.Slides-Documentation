---  
title: سفارشی‌سازی نمودارهای 3D در ارائه‌ها بر روی Android  
linktitle: نمودار 3D  
type: docs  
url: /fa/androidjava/3d-chart/  
keywords:  
- نمودار 3D  
- چرخش  
- عمق  
- PowerPoint  
- ارائه  
- Android  
- Java  
- Aspose.Slides  
description: "نمودارهای 3D را در ارائه‌های PowerPoint با Aspose.Slides برای Android از طریق Java ایجاد کنید. چرخش، نسبت‌های ارتفاع، عمق نمودار و فاصله بین سری‌ها را با مثال‌های Java تنظیم کنید."  
---
## **بررسی کلی**

Aspose.Slides for Android via Java به شما امکان می‌دهد نمای یک نمودار 3D را از طریق متد [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) سفارشی کنید. این مقاله نشان می‌دهد چگونه چرخش، نسبت ارتفاع، عمق، محورهای زاویه راست و فاصله بین سری‌ها را تنظیم کنید و سپس ارائه را در قالب PPTX ذخیره نمایید.

## **تنظیم چرخش و عمق یک نمودار 3D**

مثال زیر یک [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد می‌کند و با استفاده از [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) یک نمودار ستونی 3D انباشته را به اولین اسلاید اضافه می‌نماید. این مثال سری‌ها و دسته‌بندی‌های پیش‌فرض را با دو سری حاوی هر کدام سه مقدار جایگزین می‌کند. شاخص کاربرگ `0` اولین کاربرگ داده‌های نمودار را شناسایی می‌کند؛ ردیف `0` نام‌های سری‌ها را دارد و ستون `0` برچسب‌های دسته‌بندی را.

متدهای [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) و [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) به ترتیب چرخش نمودار را به 40 و 270 درجه تنظیم می‌کنند. متد [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) عمق آن را به 150٪ از عرض تنظیم می‌نماید، در حالی که [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) محورهای زاویه راست را به جای پرسپکتیو فعال می‌کند. ارائهٔ حاصل شامل نمودار پر شده با این تنظیمات نمای 3D است.

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

## **تنظیم نسبت ارتفاع یک نمودار 3D**

از [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) برای تعیین ارتفاع یک نمودار 3D به صورت درصدی از عرض آن استفاده کنید. این کار نسبت صحنهٔ 3D را بدون تغییر اندازهٔ شیء نمودار روی اسلاید تغییر می‌دهد.

مثال زیر یک نمودار [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) با داده‌های پیش‌فرض ایجاد می‌کند: سه سری و چهار دسته. این مثال سه ارائه با نسبت ارتفاع 50٪، 100٪ و 200٪ ذخیره می‌کند. موقعیت، عرض و ارتفاع نمودار ثابت می‌مانند. داده‌ها، چرخش، عمق، فاصلهٔ سری‌ها و قالب‌بندی در هر سه فایل یکسان است؛ فقط درصد ارتفاع تغییر می‌کند.

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

تصاویر زیر همان تنظیمات ارتفاع را در مثال معادل .NET نشان می‌دهند و با Microsoft PowerPoint استخراج شده‌اند. درصد کمتر صحنهٔ مسطح‌تری ایجاد می‌کند، در حالی که درصد بیشتر صحنهٔ بلندی را در همان شیء نمودار می‌سازد. PowerPoint ممکن است فواصل تیک محور و مکان برچسب‌ها را برای تطبیق صحنه تنظیم کند.

| ارتفاع: 50٪ | ارتفاع: 100٪ | ارتفاع: 200٪ |
| --- | --- | --- |
| ![نمودار ستونی 3D با ارتفاع تنظیم‌شده به 50 درصد از عرض آن](height_percent_50.png) | ![نمودار ستونی 3D با ارتفاع تنظیم‌شده به 100 درصد از عرض آن](height_percent_100.png) | ![نمودار ستونی 3D با ارتفاع تنظیم‌شده به 200 درصد از عرض آن](height_percent_200.png) |

این متدها جنبه‌های مختلفی از نمودار را کنترل می‌کنند:

| متد | اثر |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | ارتفاع صحنهٔ 3D به صورت درصدی از عرض آن. |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | ارتفاع شیء نمودار روی اسلاید، به پوینت. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | عمق صحنهٔ 3D به صورت درصدی از عرض آن. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | فاصله بین سری‌ها در محور عمق، به درصدی از عرض مارکر. |

تنظیم ارتفاع بر نمودارهای ستونی و میله‌ای 3D اثر می‌گذارد، شامل انواع سیلندری، مخروطی و هرم‌دار، همچنین نمودارهای خطی، مساحی، دایره‌ای و سطحی 3D. مقایسهٔ بالا از نوع تأییدشدهٔ `Column3D` استفاده می‌کند. این تنظیم باعث تغییر ظاهر نمودار دو‑بعدی `ClusteredColumn` یا نمودار `BubbleWith3D` نمی‌شود؛ این نام‌ها عضو کلاس [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) هستند. برای سایر تنظیمات ظاهر نمودار، به بخش [Chart Formatting](/slides/fa/androidjava/chart-formatting/) مراجعه کنید.

## **تنظیم فاصله بین سری‌ها**

از [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) برای کنترل فاصلهٔ بین سری‌های داده در محور عمق یک نمودار 3D استفاده کنید؛ مقدار به درصدی از عرض مارکر بیان می‌شود. مقادیر از **0 تا 500**، شامل می‌شود: `0` فاصله را حذف می‌کند، در حالی که مقادیر بزرگتر فضای بین سری‌ها را افزایش می‌دهند. با عمق ثابت نمودار، افزایش فاصله باعث نازک‌تر شدن مارکرها در محور عمق می‌شود.

دسترسی به گروه از طریق [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) انجام می‌شود. این تنظیم برای هر سری در آن گروه اعمال می‌شود، نه فقط برای سری‌ای که از طریق آن دسترسی پیدا می‌کنید. متد [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) مقدار فاصلهٔ عمق را برمی‌گرداند و تنظیمات گروه والد را نشان می‌دهد.

این تنظیم بر نمودارهای ستونی و میله‌ای 3D، شامل انواع سیلندری، مخروطی و هرم‌دار، و همچنین نمودارهای خطی و مساحی 3D تأثیر می‌گذارد. ظاهر به این بستگی دارد که سری‌ها در عمق، خوشه‌ای یا انباشته مرتب شده باشند. برای مقایسهٔ واضح فاصله‌ها بین سری‌های جداگانه، از `ChartType.Column3D` کلاس [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) استفاده کنید.

این متدها جنبه‌های مختلفی از نمودار را کنترل می‌کنند:

| متد | اثر |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | فاصله بین سری‌ها در محور عمق، به درصدی از عرض مارکر. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | فاصله بین خوشه‌های میله یا ستون مجاور، به درصدی از عرض میله یا ستون. |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | عمق کلی نمودار، به درصدی از عرض نمودار. |

مثال خودکفای زیر از داده‌های پیش‌فرض نمودار استفاده می‌کند که شامل سه سری و چهار دسته است. این مثال دو ارائه با داده، چرخش، عرض فاصله و عمق نمودار یکسان ذخیره می‌کند؛ فقط عمق فاصله تغییر می‌کند.

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

تصاویر زیر همان تنظیمات عمق فاصله را در مثال معادل .NET نشان می‌دهند و با Microsoft PowerPoint استخراج شده‌اند.

| عمق فاصله: 0٪ | عمق فاصله: 500٪ |
| --- | --- |
| ![نمودار ستونی 3D بدون فاصله بین سری‌ها در محور عمق](gap_depth_0.png) | ![نمودار ستونی 3D با فاصلهٔ 500 درصدی بین سری‌ها در محور عمق](gap_depth_500.png) |

## **تغییر نوع سری 3D و شکل میله**

در یک نمودار سیلندری خوشه‌ای، اولین سری با شکل میلهٔ سیلندری آغاز می‌شود. مثال مقادیر عددی برگشتی از [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) و [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) را قبل و بعد از هر تغییر چاپ می‌کند. جدول نام‌های ثابت متناظر را نشان می‌دهد.

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
| ایجاد نمودار | `ClusteredCylinder` | `Cylinder` |
| تنظیم نوع سری به `ClusteredCone` | `ClusteredCone` | `Cone` |
| تنظیم شکل میله به `Box` | `ClusteredColumn3D` | `Box` |

تنظیم شکل به `Box` همچنین نوع سری را به `ClusteredColumn3D` تغییر می‌دهد. اگر کد شما بر اساس نوع سری شاخه‌بندی می‌کند، پس از تغییر شکل حتماً `series.getType()` را فراخوانی کنید. مقدار کشیده‌شده قبل از تخصیص هنوز شاخهٔ `ClusteredCone` را انتخاب خواهد کرد.

![مقایسهٔ PowerPoint نشان‌دهندهٔ سری اول به صورت میله‌های سیلندری، مخروطی و مستطیلی از چپ به راست](series-shapes.png)

## **سوالات متداول**

**کدام انواع نمودارها حالت 3D را در Aspose.Slides پشتیبانی می‌کنند؟**

Aspose.Slides انواع 3D نمودارهای ستونی را پشتیبانی می‌کند، از جمله Column 3D، Clustered Column 3D، Stacked Column 3D و 100% Stacked Column 3D، به‌همراه انواع 3D مرتبط که از طریق کلاس [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) نمایش داده می‌شوند. برای دریافت فهرست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) را در مستندات API نسخهٔ نصب‌تان بررسی کنید.

**آیا می‌توانم یک تصویر رستری از نمودار 3D برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید نمودار را با استفاده از [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) به تصویر تبدیل کنید یا کل اسلاید را به فرمت‌هایی همچون PNG یا JPEG رندر کنید ([render the entire slide](/slides/fa/androidjava/convert-powerpoint-to-png/)). این کار برای پیش‌نمایش رستری یا قرار دادن نمودار در اسناد، داشبوردها یا صفحات وب بدون نیاز به PowerPoint مفید است.

**عملکرد ساخت و رندر نمودارهای بزرگ 3D چطور است؟**

عملکرد به حجم داده‌ها و پیچیدگی بصری وابسته است. برای به‌دست آوردن نتایج بهتر، اثرات 3D را به حداقل برسانید، از بافت‌های سنگین بر روی دیوارها و نواحی نمودار پرهیز کنید، تعداد نقاط داده در هر سری را در صورت امکان کاهش دهید و به‌صورت خروجی به اندازهٔ مناسب (رزولوشن و ابعاد) رندر کنید تا با نیازهای نمایش یا چاپ مطابقت داشته باشد.