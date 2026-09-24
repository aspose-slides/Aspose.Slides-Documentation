---
title: مدیریت سری‌های داده نمودار در ارائه‌ها بر روی اندروید
linktitle: سری‌های داده
type: docs
url: /fa/androidjava/chart-series/
keywords:
- سری نمودار
- همپوشانی سری
- رنگ سری
- نام سری
- نقطه داده
- سلول کتاب‌کار
- فاصله سری
- مقدار منفی
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های کتاب‌کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها بر روی اندروید مدیریت کنید."
---
## **نمای کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک کتاب‌کار داده‌نمودار ذخیره می‌کند. یک [IChartSeries](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/) نمایانگر یک مجموعه از مقادیر مرتبط است و هر [IChartDataPoint](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/) در سری به یک یا چند سلول کتاب‌کار اشاره می‌کند. اشیاء [IChartCategory](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین سری‌ها را فراهم می‌کنند. نام سری، دسته‌ها و مقادیر نقطه‌ها بنابراین به اشیاء [IChartDataCell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatacell/) متصل هستند نه اینکه فقط به‌عنوان متن نمایش ذخیره شوند.

برای یک نمودار دسته‌ای معمولی، کتاب‌کار پیش‌فرض از سطر 0 برای نام‌های سری، ستون 0 برای نام‌های دسته و بقیه سلول‌ها برای مقادیر سری استفاده می‌کند. شاخص‌های کاربرگ، سطر و ستون که به [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) ارسال می‌شوند، مبتنی بر صفر هستند. این چیدمان هنگام ایجاد نمودار با داده‌های پیش‌فرض مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای ارائه بارگذاری‌شده، قبل از تغییر مقادیر کتاب‌کار، سلول‌های ارجاع‌داده‌شده توسط سری‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه دامنه متفاوت هستند:

- تنظیمات سطح سری، مانند [IChartSeries.getFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getFormat--)، ظاهر پیش‌فرض تمام نقاط یک سری را فراهم می‌کند.
- تنظیمات نقطه داده، مانند [IChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--)، ظاهر سری را برای یک نقطه خاص بازنویسی می‌کند.
- تنظیمات گروه برای سری‌های سازگاری که به همان [IChartSeriesGroup](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseriesgroup/) تعلق دارند اعمال می‌شود. برای تنظیم گزینه‌هایی مانند همپوشانی یا عرض فاصله، از [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) استفاده کنید.

وقتی پر شدن صریح برای نقطه یا سری تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم فرمت سری و هم فرمت نقطه موجود باشد، فرمت نقطه برای آن نقطه اولویت دارد.

![نمودار-سری-پاورپوینت](chart-series-powerpoint.png)

## **تنظیم همپوشانی سری نمودار**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getOverlap--) گزارش می‌دهد که نوارها یا ستون‌ها در یک نمودار دوبعدی تا چه حد همپوشانی دارند، از -100 تا 100 درصد. این یک پیش‌نمایش فقط‌خواندنی از تنظیمات در گروه سری والد است. برای به‌روزرسانی همه سری‌های سازگار در آن گروه از [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) استفاده کنید. این گزینه برای انواع نموداری که نوارها یا ستون‌های گروهی را نمایش می‌دهند اعمال می‌شود؛ به گروه‌های سری نامرتبط در یک نمودار ترکیبی اثر نمی‌گذارد.

مثال زیر همپوشانی برای گروهی که شامل اولین سری است تنظیم می‌کند:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // نمودار جدید شامل سری‌های نمونه، دسته‌ها و مقادیر است.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![همپوشانی سری](series_overlap.png)

## **تغییر رنگ پر شدن سری**

از [IChartSeries.getFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getFormat--) برای تنظیم پر شدن پیش‌فرض یک سری کامل استفاده کنید. اگر برای یک نقطه پر شدن صریحی تعیین شده باشد، تنظیمات [IChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) آن، پر شدن سری را برای آن نقطه بازنویسی می‌کند.

مثال زیر پر شدن آبی ثابت را به اولین سری اعمال می‌کند:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![رنگ سری](series_color.png)

## **تغییر نام سری**

نام یک سری در کتاب‌کار داده‌نمودار ذخیره می‌شود و معمولاً در راهنما (legend) نمایش داده می‌شود. در کتاب‌کار پیش‌فرض ایجاد شده برای یک نمودار ستونی خوشه‌ای، سلول B1 در سطر 0، ستون 1 قرار دارد و نام اولین سری را شامل می‌شود. ثابت‌های نام‌گذاری در مثال زیر این ساختار را به‌طور صریح نشان می‌دهند:

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

همچنین می‌توانید سلولی که توسط [IChartSeries.getName](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getName--) ارجاع شده است به‌روزرسانی کنید. این روش از فرض ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

![نام سری](series_name.png)

## **دریافت رنگ خودکار پر شدن سری**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) رنگی را که از ایندکس سری و سبک نمودار محاسبه می‌شود به‌عنوان عدد صحیح رنگ ARGB اندروید برمی‌گرداند. این رنگ زمانی استفاده می‌شود که پر شدن سری به‌صورت صریح تعریف نشده باشد. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ پر شدن جدیدی اختصاص نمی‌دهد.

مثال زیر رنگ عددی خودکار هر سری پیش‌فرض را چاپ می‌کند:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

مقادیر عدد صحیح دقیق به سبک و تم نمودار بستگی دارد.

## **تنظیم رنگ پر شدن معکوس برای یک سری نمودار**

برای سری‌های نوار، ستون و حباب، [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) می‌تواند مقادیر منفی را با پر شدن متفاوتی نمایش دهد. پر شدن معمولی سری را به حالت ثابت تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) اختصاص دهید. اعداد منفی در کتاب‌کار بدون تغییر می‌مانند؛ فقط رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک سری جایگزین می‌کند. سطر 0 کاربرگ نام سری را دارد، ستون 0 نام‌های دسته و ستون 1 مقادیر را دارد:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

![رنگ پر شدن ثابت معکوس](inverted_solid_fill_color.png)

می‌توانید برای یک نقطه خاص معکوس‌سازی را با استفاده از [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) فعال کنید. در مثال زیر معکوس‌سازی برای سری غیرفعال و فقط برای نقطه منتخب فعال شده است. این نقطه همچنین مقدار منفی دریافت می‌کند تا اثر مشاهده شود:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

## **پاک کردن مقدار نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول پشتیبان کتاب‌کار آن را به `null` تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق [IChartDataPoint.getValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را به‌عنوان خالی بر اساس تنظیمات خالی‌سازی نمودار در نظر می‌گیرد.

مثال زیر فقط نقطه دوم در اولین سری را پاک می‌کند:

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

نمودارهای پراکندگی از سلول‌های X و Y جداگانه استفاده می‌کنند و نمودارهای حباب نیز از سلول اندازه بهره می‌برند. فقط سلولی که نمایانگر مقداری است که می‌خواهید حذف کنید، پاک کنید. هنگامیکه می‌خواهید نقاط دیگر باقی بمانند، از [IChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) استفاده نکنید، زیرا این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

یک سلول کتاب‌کار خالی نشانگر داده‌های گمشده است؛ سلولی که `0` دارد نمایانگر مقدار عددی شناخته شده است. برای خالی کردن یک سلول، [IChartDataCell.setValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) را با `null` فراخوانی کنید. عدد صفر عددی صفر می‌ماند صرف‌نظر از تنظیم خالی‌سازی سلول.

از [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) برای انتخاب نحوه نمایش سلول‌های خالی در نمودار استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود. این گزینه نحوه ترسیم خالی‌ها را تغییر می‌دهد، بدون اینکه سلول خالی کتاب‌کار را با صفر یا مقدار برآیند پر کند.

مثال خودکفایی زیر یک نمودار خطی با یک سری ایجاد می‌کند، مقدار روز 3 را خالی می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. نیازی به فایل ورودی نیست. [IChartDataWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdataworkbook/) از کاربرگ 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ سطر 0 نام سری را نگه می‌دارد. داده نهایی `10, 20, empty, 30, 40` است.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // روز ۳ را واقعاً خالی بگذارید، در حالی که دسته و نقطه داده آن را حفظ می‌کنید.
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

هر فایل خروجی حالت اختصاص داده شده قبل از ذخیره‌سازی را نشان می‌دهد: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیره تنها یک نسخه، حالت دلخواه را تعیین کنید و یک‌بار ارائه را ذخیره کنید به‌جای اینکه بر تمام حالت‌ها تکرار کنید.

مقایسه زیر همان داده را در هر سه فایل نشان می‌دهد. روز 3 در کتاب‌کار در هر حالت خالی است:

![نمودارهای خطی با داده یکسان: فاصله (Gap) خط را در روز 3 قطع می‌کند، صفر (Zero) خط را به صفر می‌رساند و بازه (Span) روز 2 را به روز 4 متصل می‌کند.](display_blanks_as.png)

اثر قابل مشاهده به نوع نمودار بستگی دارد. یک نمودار خطی سه حالت را برای مقایسه آسان فراهم می‌کند. نمودارهای نوار و ستونی خطی برای اتصال بین دسته‌های گمشده ندارند، بنابراین `Span` نمی‌تواند بخش اتصال نشان‌داده‌شده در بالا را تولید کند؛ یک ستون گمشده و یک ستون صفرارتفاع نیز می‌توانند مشابه به نظر برسند. به‌طور مشابه، یک نمودار پراکندگی فقط دارای نشانگرها است و خط متصل ندارند. انتظار داشتن سه نتیجه متمایز برای هر نوع نمودار را نداشته باشید؛ خروجی نوع مورد استفاده خود را بررسی کنید.

## **تنظیم عرض فاصله سری**

عرض فاصله، فضا بین خوشه‌های نوار یا ستونی مجاور است که به صورت درصدی از عرض نوار یا ستون بیان می‌شود. مشابه همپوشانی، این تنظیم به گروه سری والد تعلق دارد نه به یک سری منفرد. برای گروه یک بار [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) را فراخوانی کنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آنها را متراکم‌تر می‌سازد.

مثال زیر عرض فاصله را تغییر می‌دهد و فقط ارائه نهایی را ذخیره می‌کند:

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

![عرض فاصله](gap_width.png)

## **سوالات متداول**

**کدام انواع نمودار از سری داده پشتیبانی می‌کنند؟**

تمام انواع نمودار نمایش داده شده توسط شمارنده [ChartType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/charttype/) از داده‌های نمودار استفاده می‌کنند، اما سری‌های آنها ساختار یا تنظیمات مقدار یکسانی ندارند. به‌عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکندگی از مقادیر X و Y، و نمودارهای حباب از اندازه حباب‌ها بهره می‌برند. از روش ایجاد نقطه داده‌ای که با نوع سری مطابقت دارد استفاده کنید. گزینه‌هایی مانند همپوشانی و عرض فاصله فقط برای گروه‌های نوار یا ستونی سازگار اعمال می‌شوند.

**گروه سری نمودار چیست؟**

یک [IChartSeriesGroup](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseriesgroup/) شامل سری‌های سازگاری است که تنظیمات رسم سطح گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروه دست‌یافته از طریق یک سری لزوماً همه سری‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه ایجاد شده داده‌های پیش‌فرض دارد؟**

بله. به‌طور پیش‌فرض، متد [IShapeCollection.addChart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) نمونه‌ای از سری‌ها، دسته‌ها و مقادیر را ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعه داده کاملاً سفارشی، هر دو مجموعه سری و دسته را پاک کنید. یک overload نیز می‌تواند نموداری بدون داده پیش‌فرض ایجاد کند.

**چگونه اشیاء نمودار به سلول‌های کتاب‌کار متصل می‌شوند؟**

نام‌های سری، برچسب‌های دسته و مقادیر نقطه داده به سلول‌های یک [IChartDataWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌داده‌شده، عنصر مربوطه در نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر سری را هم‌تراز نگه دارید تا هر نقطه زیر دسته موردنظر ترسیم شود.

**چگونه یک نقطه را به‌جای کل سری پاک کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دسته نقطه به عنوان نقطه خالی حفظ شود. فقط زمانی از [IChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) استفاده کنید که قصد حذف تمام نقاط آن سری را داشته باشید. اگر دسته‌ها را نیز حذف می‌کنید، هر سری را طوری به‌روزرسانی کنید که مقادیرشان با مجموعه دسته هم‌تراز بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقدار تنظیم‌شده از طریق [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فاصله، به‌عنوان مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که معنای داده‌های گمشده در ارائه شما را منعکس کند. برای مثال کامل و مقایسه بصری به [کنترل نمایش سلول‌های خالی](#control-the-display-of-empty-cells) مراجعه کنید.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای سری‌های نوار، ستون و حباب پشتیبانی‌شده، متد [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) را فراخوانی کنید و رنگ بازگشتی از [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ واحد با [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) بازنویسی کنید. این روش‌ها صرفاً قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**وقتی هم سری و هم نقطه فرمت داشته باشند، کدام فرمت برتری دارد؟**

قالب‌بندی صریح نقطه داده برای آن نقطه برتری دارد. سایر نقاط به فرمت صریح سری یا، در صورت عدم تعریف فرمت سری، به سبک و تم خودکار نمودار ادامه می‌دهند. تنظیمات گروهی مانند همپوشانی و عرض فاصله بر چیدمان کنترل می‌شوند و بازنویسی‌های سطح نقطه نیستند.

**آیا محدودیتی برای تعداد سری‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه موجود، زمان رندرینگ و خوانایی نمودار، حد مفیدی را تعیین می‌کنند.

**در صورتی که ستون‌ها بیش از حد نزدیک یا دور هستند چه کار کنم؟**

متد [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) را بر روی گروه سری والد مناسب فراخوانی کنید. مقدار را افزایش دهید تا فضای بین خوشه‌ها عریض‌تر شود یا کاهش دهید تا خوشه‌ها به‌یکدیگر نزدیک‌تر شوند.