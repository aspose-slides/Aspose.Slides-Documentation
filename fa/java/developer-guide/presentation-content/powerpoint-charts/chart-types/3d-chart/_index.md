---
title: سفارشی‌سازی نمودارهای 3D در ارائه‌ها با استفاده از Java
linktitle: نمودار 3D
type: docs
url: /fa/java/3d-chart/
keywords:
- نمودار 3D
- چرخش
- عمق
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "نمودارهای 3D را در ارائه‌های PowerPoint با Aspose.Slides برای Java ایجاد کنید. چرخش، نسبت ارتفاع، عمق نمودار و فاصله بین سری‌ها را با مثال‌های Java تنظیم کنید."
---
## **مروری کلی**

Aspose.Slides for Java به شما امکان می‌دهد نمای یک نمودار 3D را از طریق متد [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) سفارشی کنید. این مقاله نشان می‌دهد چگونه چرخش، نسبت ارتفاع، عمق، محورهای زاویه‌دار راست و فاصله بین سری‌ها را تنظیم کرده و سپس ارائه را در قالب PPTX ذخیره کنید.

## **تنظیم چرخش و عمق یک نمودار 3D**

مثال زیر یک [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد می‌کند و با استفاده از [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) یک نمودار ستونی 3D انباشته به اسلاید اول اضافه می‌سالید. این مثال سری‌ها و دسته‌بندی‌های پیش‌فرض را با دو سری شامل هر کدام سه مقدار جایگزین می‌کند. شاخص کاری‌برگه `0` اولین برگه داده نمودار را تعیین می‌کند؛ ردیف `0` نام‌های سری را می‌گیرد و ستون `0` برچسب‌های دسته‌بندی را دارد.

متدهای [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) و [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) به ترتیب چرخش نمودار را به 40 و 270 درجه تنظیم می‌کنند. متد [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) عمق آن را به 150٪ عرض تنظیم می‌کند، در حالی که [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) محورهای زاویه‌دار راست را به جای پرسپکتیو فعال می‌سازد. ارائهٔ حاصل شامل نمودار پر شده با این تنظیمات نمای 3D است.

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

از [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) برای تنظیم ارتفاع یک نمودار 3D به صورت درصدی از عرض آن استفاده کنید. این کار نسبت صحنهٔ 3D را بدون تغییر اندازهٔ شیء نمودار در اسلاید تغییر می‌دهد.

مثال زیر یک نمودار [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) با داده پیش‌فرض ایجاد می‌کند: سه سری و چهار دسته‌بندی. این مثال سه ارائه را با نسبت‌های ارتفاع 50٪، 100٪ و 200٪ ذخیره می‌کند. موقعیت، عرض و ارتفاع نمودار ثابت می‌مانند. داده‌ها، چرخش، عمق، فاصله بین سری‌ها و قالب‌بندی در هر سه فایل یکسان است؛ تنها درصد ارتفاع تغییر می‌کند.

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

تصاویر زیر همان تنظیمات ارتفاع را در مثال .NET معادل نشان می‌دهند و توسط Microsoft PowerPoint استخراج شده‌اند. درصد کمتر صحنه‌ای صاف‌تر، در حالی که درصد بالاتر صحنه‌ای بلندتر در همان شیء نمودار ایجاد می‌کند. PowerPoint ممکن است فاصله‌های تیک محور و قرارگیری برچسب‌ها را برای متناسب شدن با صحنه تنظیم کند.

| ارتفاع: 50٪ | ارتفاع: 100٪ | ارتفاع: 200٪ |
| --- | --- | --- |
| ![نمودار ستونی 3D با ارتفاع تنظیم شده به 50 درصد از عرض آن](height_percent_50.png) | ![نمودار ستونی 3D با ارتفاع تنظیم شده به 100 درصد از عرض آن](height_percent_100.png) | ![نمودار ستونی 3D با ارتفاع تنظیم شده به 200 درصد از عرض آن](height_percent_200.png) |

این متدها جنبه‌های مختلفی از نمودار را کنترل می‌کنند:

| متد | اثر |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | ارتفاع صحنهٔ 3D به صورت درصدی از عرض آن. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | ارتفاع شیء نمودار روی اسلاید، به پوینت. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | عمق صحنهٔ 3D به صورت درصدی از عرض آن. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | فاصله بین سری‌ها در امتداد محور عمق، به درصدی از عرض مارکر. |

تنظیم ارتفاع بر نمودارهای ستونی و نوار 3D، شامل انواع استوانه‌ای، مخروطی و هرم‌مانند، همچنین نمودارهای خط، مساحت، دایره‌ای و سطحی 3D تأثیر می‌گذارد. مقایسهٔ بالا از نوع تأیید شدهٔ `Column3D` استفاده می‌کند. این تنظیم ظاهر نمودار دو بعدی `ClusteredColumn` یا نمودار `BubbleWith3D` را تغییر نمی‌دهد؛ این نام‌ها عضو کلاس [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) هستند. برای سایر تنظیمات ظاهر نمودار، به [Chart Formatting](/slides/fa/java/chart-formatting/) مراجعه کنید.

## **تنظیم فاصله بین سری‌ها**

از [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) برای کنترل فاصله بین سری‌های داده در امتداد محور عمق یک نمودار 3D استفاده کنید؛ این مقدار به درصدی از عرض مارکر بیان می‌شود. مقادیر از **0 تا 500** مجازند: `0` فاصله را حذف می‌کند، در حالی که مقادیر بزرگتر فاصله را افزایش می‌دهند. با ثابت ماندن عمق نمودار، افزایش فاصله باعث باریک‌تر شدن مارکرها در محور عمق می‌شود.

به گروه از طریق [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) دسترسی پیدا کنید. این تنظیم برای هر سری در آن گروه اعمال می‌شود، نه فقط برای سری‌ای که برای دسترسی به آن استفاده شده است. متد [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) فاصله عمق را برمی‌گرداند و تنظیمات گروه والد را منعکس می‌کند.

این تنظیم بر نمودارهای ستونی و نوار 3D، شامل انواع استوانه‌ای، مخروطی و هرم‌مانند، همچنین نمودارهای خطی و مساحتی 3D تأثیر می‌گذارد. ظاهر بسته به این است که سری‌ها در عمق، خوشه‌ای یا انباشته باشند. برای مقایسهٔ واضح فاصله‌ها بین سری‌های جداگانه، از `ChartType.Column3D` کلاس [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) استفاده کنید.

این متدها جنبه‌های مختلفی از نمودار را کنترل می‌کنند:

| متد | اثر |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | فاصله بین سری‌ها در امتداد محور عمق، به درصدی از عرض مارکر. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | فاصله بین خوشه‌های نوار یا ستون مجاور، به درصدی از عرض نوار یا ستون. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | عمق کلی نمودار، به درصدی از عرض نمودار. |

مثال زیر به طور مستقل از داده‌های پیش‌فرض نمودار استفاده می‌کند که شامل سه سری و چهار دسته‌بندی است. این مثال دو ارائه را با داده‌های یکسان، چرخش، عرض فاصله و عمق نمودار ذخیره می‌کند؛ تنها عمق فاصله تغییر می‌کند.

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

تصاویر زیر همان تنظیمات عمق فاصله را در مثال .NET معادل نشان می‌دهند و توسط Microsoft PowerPoint استخراج شده‌اند.

| عمق فاصله: 0٪ | عمق فاصله: 500٪ |
| --- | --- |
| ![نمودار ستونی 3D بدون فاصله بین سری‌ها در امتداد محور عمق](gap_depth_0.png) | ![نمودار ستونی 3D با فاصله 500 درصدی بین سری‌ها در امتداد محور عمق](gap_depth_500.png) |

## **تغییر نوع سری 3D و شکل میله**

در یک نمودار استوانه‌ای خوشه‌ای، اولین سری با شکل میلهٔ استوانه‌ای آغاز می‌شود. مثال مقادیر عددی برگشتی توسط [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) و [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) را قبل و بعد از هر تغییر چاپ می‌کند. جدول نام ثابت‌های متناظر را نشان می‌دهد.

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

| تغییر به اولین سری | نوع سری | شکل میله |
| --- | --- | --- |
| ایجاد نمودار | `ClusteredCylinder` | `Cylinder` |
| تنظیم نوع سری به `ClusteredCone` | `ClusteredCone` | `Cone` |
| تنظیم شکل میله به `Box` | `ClusteredColumn3D` | `Box` |

تنظیم شکل به `Box` همچنین نوع سری را به `ClusteredColumn3D` تغییر می‌دهد. اگر کد شما بر پایهٔ نوع سری شاخه‌گذاری می‌شود، پس از تغییر شکل، `series.getType()` را فراخوانی کنید. مقدار کشیده‌شده پیش از انتساب همچنان شاخهٔ `ClusteredCone` را انتخاب می‌کند.

![مقایسهٔ PowerPoint که اولین سری را به صورت استوانه، مخروط و ستون‌های مستطیلی از چپ به راست نشان می‌دهد](series-shapes.png)

## **سوالات متداول**

**کدام انواع نمودارها حالت 3D را در Aspose.Slides پشتیبانی می‌کنند؟**

Aspose.Slides انواع 3D نمودارهای ستونی را پشتیبانی می‌کند، از جمله Column 3D، Clustered Column 3D، Stacked Column 3D و 100 % Stacked Column 3D، به همراه انواع 3D مرتبط که از طریق کلاس [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) در دسترس هستند. برای فهرست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) را در مرجع API نسخهٔ نصب شدهٔ خود بررسی کنید.

**آیا می‌توانم تصویر رستری از یک نمودار 3D برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید نمودار را با استفاده از [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) به تصویر تبدیل کنید یا کل اسلاید را به فرمت‌هایی مانند PNG یا JPEG رندر کنید ([render the entire slide](/slides/fa/java/convert-powerpoint-to-png/)). این گزینه برای پیش‌نمایش رستری یا ادغام نمودار در اسناد، داشبوردها یا صفحات وب بدون نیاز به PowerPoint مفید است.

**عملکرد ساخت و رندر نمودارهای بزرگ 3D چقدر است؟**

عملکرد به حجم داده و پیچیدگی بصری بستگی دارد. برای نتایج بهینه، اثرات 3D را حداقل نگه دارید، از تکسچرهای سنگین بر روی دیوارها و نواحی نمودار خودداری کنید، تعداد نقاط داده در هر سری را در حد امکان محدود کنید و خروجی را با رزولوشن و ابعاد مناسب برای نمایش یا چاپ هدف رندر کنید.