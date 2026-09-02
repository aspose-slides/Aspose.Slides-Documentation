---
title: مدیریت مجموعه داده‌های نمودار در ارائه‌ها با جاوا
linktitle: مجموعه داده‌ها
type: docs
url: /fa/java/chart-series/
keywords:
- مجموعه نمودار
- پوشش مجموعه
- رنگ مجموعه
- نام مجموعه
- نقطه داده
- سلول کاربرگ
- فاصله مجموعه
- مقدار منفی
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه مجموعه‌های نمودار، نقاط داده، سلول‌های کاربرگ، قالب‌بندی، پوشش، عرض فاصله و مقادیر منفی را در ارائه‌ها با جاوا مدیریت کنید."
---
## **نمای کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک کاربرگ داده‌های نمودار ذخیره می‌کند. یک [IChartSeries](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/) نمایانگر یک مجموعه مقادیر مرتبط است و هر [IChartDataPoint](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/) در این مجموعه به یک یا چند سلول کاربرگ اشاره می‌کند. اشیاء [IChartCategory](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی را که بین مجموعه‌ها به‌اشتراک گذاشته می‌شوند، فراهم می‌آورند. بنابراین نام مجموعه، دسته‌ها و مقادیر نقاط به اشیاء [IChartDataCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/) متصل هستند نه این‌که فقط به‌عنوان متن نمایش ذخیره شوند.

برای یک نمودار دسته‌ای معمولی، کاربرگ پیش‌فرض از ردیف 0 برای نام مجموعه‌ها، ستون 0 برای نام دسته‌ها و سلول‌های باقی‌مانده برای مقادیر مجموعه استفاده می‌کند. اندیس‌های برگه کاری، ردیف و ستون که به [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) پاس می‌شوند، صفر‑مبنائی هستند. این طرح برای زمانی که نمودار را با داده‌های پیش‌فرض ایجاد می‌کنید مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کاربرگ، سلول‌های مرجع‌دار توسط مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه حوزه متفاوت هستند:

- تنظیمات سطح مجموعه، مانند [IChartSeries.getFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getFormat--)، ظاهر پیش‌فرض تمام نقاط در یک مجموعه را فراهم می‌کند.
- تنظیمات نقطه داده، مانند [IChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/#getFormat--)، ظاهر مجموعه را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی به مجموعه‌های سازگاری که به همان [IChartSeriesGroup](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseriesgroup/) تعلق دارند، اعمال می‌شود. برای تنظیم گزینه‌هایی مانند پوشش یا عرض فاصله، از [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) عبور کنید.

وقتی پر شدن صریح برای نقطه یا مجموعه تعیین نشود، سبک و تم نمودار ظاهر خودکار را مشخص می‌کند. وقتی هم تنظیمات مجموعه و هم نقطه موجود باشد، تنظیمات نقطه برای آن نقطه برتری دارد.

![نمودار-سلسله-پاورپوینت](chart-series-powerpoint.png)

## **تنظیم پوشش مجموعهٔ نمودار**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getOverlap--) مقدار پوشش نوارها یا ستون‌ها در یک نمودار دو‌بعدی را از ‑100 تا 100 درصد گزارش می‌دهد. این یک تصویر فقط‑خواندنی از تنظیمات در گروه مجموعهٔ والد است. برای به‌روزرسانی تمام مجموعه‌های سازگار در آن گروه از [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) استفاده کنید. این گزینه فقط به انواع نمودارهایی که نوارها یا ستون‌های گروه‌بندی‌شده را نمایش می‌دهند اعمال می‌شود؛ بر گروه‌های مجموعهٔ نامرتبط در یک نمودار ترکیبی تأثیری ندارد.

مثال زیر پوشش گروه حاوی اولین مجموعه را تنظیم می‌کند:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // نمودار جدید شامل مجموعه‌های نمونه، دسته‌ها و مقادیر است.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پوشش‑سلسله](series_overlap.png)

## **تغییر رنگ پر کردن مجموعه**

از [IChartSeries.getFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getFormat--) برای تعیین پر شدن پیش‌فرض یک مجموعه کامل استفاده کنید. اگر یک نقطه قبلاً پر شدن صریح داشته باشد، تنظیمات [IChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/#getFormat--) آن، پر شدن مجموعه را برای همان نقطه بازنویسی می‌کند.

مثال زیر پر شدن آبی یکدست را برای اولین مجموعه اعمال می‌کند:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![رنگ‑سلسله](series_color.png)

## **تغییر نام مجموعه**

یک نام مجموعه در کاربرگ داده‌های نمودار ذخیره می‌شود و معمولاً در فهرست legend نمایش داده می‌شود. در کاربرگ پیش‌فرض ایجادشده برای یک نمودار ستونی خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین مجموعه را در خود دارد. ثابت‌های نام‌دار در مثال زیر این ساختار را به‌وضوح نشان می‌دهند:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

همچنین می‌توانید سلول مرجع‌شده توسط [IChartSeries.getName](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getName--) را به‌روزرسانی کنید. این روش از فرض یک ردیف یا ستون خاص در یک نمودار موجود جلوگیری می‌کند:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![نام‑سلسله](series_name.png)

## **دریافت رنگ پر خودکار مجموعه**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) رنگ محاسبه‌شده بر‑اساس شاخص مجموعه و سبک نمودار را برمی‌گرداند. این همان رنگی است که زمانی که پر کردن مجموعه صراحتاً تعریف نشده باشد، استفاده می‌شود. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ پر شدن جدیدی تخصیص نمی‌دهد.

مثال زیر رنگ خودکار هر مجموعه پیش‌فرض را چاپ می‌کند:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        Color automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

خروجی نمونه برای سبک پیش‌فرض نمودار:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

رنگ‌های دقیق بسته به سبک و تم نمودار متفاوت هستند.

## **تنظیم رنگ پر معکوس برای یک مجموعهٔ نمودار**

برای مجموعه‌های نوار، ستون و حباب، می‌توان با [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) مقادیر منفی را با پر شدن متفاوت نشان داد. پر شدن معمولی مجموعه را به صورت یکدست تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) اختصاص دهید. اعداد منفی در کاربرگ دست‌نخورده می‌مانند؛ فقط رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف 0 برگه کاری نام مجموعه را دارد، ستون 0 نام دسته‌ها و ستون 1 مقادیر را در خود دارد:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![رنگ‑پر‑متقاطع‑معکوس](inverted_solid_fill_color.png)

می‌توانید معکوس‌سازی را برای یک نقطه از طریق [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) فعال کنید. در مثال زیر معکوس‌سازی برای مجموعه غیرفعال و فقط برای نقطهٔ انتخاب‌شده فعال می‌شود. همچنین به نقطه مقدار منفی اختصاص داده می‌شود تا اثر قابل مشاهده باشد:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پاک‌سازی مقدار یک نقطه دادهٔ خاص**

برای خالی کردن یک نقطه بدون حذف سایر نقاط، سلول پشتیبان کاربرگ آن را به `null` تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق [IChartDataPoint.getValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/#getValue--) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را به‌عنوان خالی بر اساس تنظیمات مقدار خالی نمودار در نظر می‌گیرد.

مثال زیر فقط نقطه دوم در اولین مجموعه را پاک می‌کند:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نمودارهای پراکندگی از سلول‌های جداگانه X و Y استفاده می‌کنند و نمودارهای حباب نیز یک سلول اندازه دارند. فقط سلولی را که نشان‌دهندۀ مقدار مورد نظر برای حذف است پاک کنید. هنگام نیاز به نگه‌داشتن دیگر نقاط، از فراخوانی [IChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapointcollection/#clear--) خودداری کنید، زیرا این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **تنظیم عرض فاصلهٔ مجموعه**

عرض فاصله فضا بین خوشه‌های نوار یا ستون مجاور است و به‌صورت درصدی از عرض نوار یا ستون بیان می‌شود. مشابه پوشش، این تنظیم به گروه مجموعهٔ والد تعلق دارد نه به یک مجموعهٔ منفرد. یک بار برای گروه، [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) را صدا بزنید. مقدار بزرگ‌تر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچک‌تر آن‌ها را فشرده‌تر می‌کند.

مثال زیر عرض فاصله را تغییر می‌دهد و فقط ارائهٔ نهایی را ذخیره می‌کند:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![عرض‑فاصله](gap_width.png)

## **پرسش‌های متداول**

**کدام انواع نمودار از مجموعه‌های داده پشتیبانی می‌کنند؟**

تمام انواع نمودارهای نمایش داده شده توسط شمارندهٔ [ChartType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/) از داده‌های نمودار استفاده می‌کنند، اما ساختار مقدار یا تنظیمات مجموعه‌ها برای همه یکسان نیست. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکندگی مقادیر X و Y، و نمودارهای حباب اندازهٔ حباب‌ها را اضافه می‌کنند. از روش ایجاد نقطه داده‌ای که با نوع مجموعه مطابقت دارد استفاده کنید. گزینه‌هایی مانند پوشش و عرض فاصله فقط برای گروه‌های نوار یا ستون سازگار اعمال می‌شوند.

**یک گروه مجموعهٔ نمودار چیست؟**

یک [IChartSeriesGroup](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseriesgroup/) شامل مجموعه‌های سازگاری است که تنظیمات سطح گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک مجموعه دسترسی پیدا می‌کنید لزوماً تمام مجموعه‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه‌ساخته داده‌های پیش‌فرض دارد؟**

بله. به‌صورت پیش‌فرض، متد [IShapeCollection.addChart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) مجموعه‌ها، دسته‌ها و مقادیر نمونه ای ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعهٔ دادهٔ کاملاً سفارشی، هر دو مجموعه و دسته‌ها را پاک کنید. یک بارگذاری دیگر نیز امکان ایجاد نمودار بدون دادهٔ پیش‌فرض را فراهم می‌کند.

**چگونه اشیای نمودار به سلول‌های کاربرگ متصل می‌شوند؟**

نام‌های مجموعه، برچسب‌های دسته و مقادیر نقطه داده به سلول‌های یک [IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول مرجع، عنصر متناظر در نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر مجموعه را هم‌راستا نگه دارید تا هر نقطه زیر دستهٔ هدف ترسیم شود.

**چگونه یک نقطه را به‌جای کل مجموعه پاک کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دسته نقطه به‌عنوان نقطهٔ خالی حفظ شود. فقط زمانی که قصد حذف تمام نقاط یک مجموعه را دارید، از [IChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapointcollection/#clear--) استفاده کنید، زیرا این متد تمام نقاط را از مجموعه حذف می‌کند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقداری که از طریق [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) پیکربندی شده است، بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فاصله، مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که با معنی داده‌های گمشده در ارائهٔ شما منطبق باشد.

**مقدارهای منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های نوار، ستون و حباب پشتیبانی‌شده، متد [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) را صدا بزنید و رنگی که توسط [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) بازگردانده می‌شود، تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ تک با [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) بازنویسی کنید. این متدها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**کدام قالب‌بندی در اولویت است وقتی هم مجموعه و هم نقطه قالب‌بندی شده باشند؟**

قالب‌بندی صریح نقطه داده برای همان نقطه برتری دارد. نقاط دیگر همچنان از قالب‌بندی صریح مجموعه یا، وقتی قالب‌بندی مجموعه تعریف نشده باشد، از سبک و تم خودکار نمودار استفاده می‌کنند. تنظیمات گروهی مانند پوشش و عرض فاصله کنترل چیدمان را انجام می‌دهند و بازنویسی‌های قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد مجموعه‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد مجموعه‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه موجود، زمان رندرینگ و خوانایی نمودار تعیین‌کنندهٔ حد قابل استفاده هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها خیلی نزدیک یا خیلی دور یکدیگر هستند؟**

متد [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) را بر روی گروه مجموعهٔ والد مناسب صدا بزنید. مقدار را افزایش دهید تا فاصله بین خوشه‌ها عریض‌تر شود یا کاهش دهید تا خوشه‌ها به‌یکدیگر نزدیک‌تر شوند.