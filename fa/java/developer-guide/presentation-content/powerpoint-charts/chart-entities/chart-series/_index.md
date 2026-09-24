---
title: مدیریت سری‌های دادهٔ نمودار در ارائه‌ها با جاوا
linktitle: سری داده
type: docs
url: /fa/java/chart-series/
keywords:
- سری نمودار
- همپوشانی سری
- رنگ سری
- نام سری
- نقطه داده
- سلول کتاب کار
- فاصله سری
- مقدار منفی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "بیاموزید چگونه سری‌های نمودار، نقاط داده، سلول‌های کتاب کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با جاوا مدیریت کنید."
---
## **مروری**

یک نمودار داده‌های رسم شده خود را در یک کتاب کار داده‌های نمودار ذخیره می‌کند. یک [IChartSeries](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/) یک مجموعه از مقادیر مرتبط را نمایندگی می‌کند و هر [IChartDataPoint](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/) در این سری به یک یا چند سلول کتاب کار اشاره دارد. اشیاء [IChartCategory](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین سری‌ها را فراهم می‌کنند. بنابراین نام سری، دسته‌ها و مقادیر نقاط به اشیاء [IChartDataCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/) متصل هستند و فقط به‌صورت متن نمایش ذخیره نمی‌شوند.

برای یک نمودار دسته‌ای معمولی، کتاب کار پیش‌فرض از ردیف 0 برای نام سری‌ها، ستون 0 برای نام دسته‌ها و سلول‌های باقی‌مانده برای مقادیر سری‌ها استفاده می‌کند. شاخص‌های کاربرگ، ردیف و ستون که به [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) ارسال می‌شوند، از صفر شروع می‌شوند. این چیدمان هنگام ایجاد نمودار با داده‌های پیش‌فرض مفید است، اما فرض نکنید که همهٔ نمودارهای موجود از آن استفاده می‌کنند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کتاب کار، سلول‌های ارجاع‌شده توسط سری‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه حوزهٔ متفاوت هستند:

- تنظیمات سطح سری، مانند [IChartSeries.getFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getFormat--)، ظاهر پیش‌فرض تمام نقاط در یک سری را فراهم می‌کند.
- تنظیمات نقطه داده، مانند [IChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/#getFormat--)، ظاهر سری را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی برای سری‌های سازگار که به همان [IChartSeriesGroup](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseriesgroup/) تعلق دارند اعمال می‌شود. برای تنظیم گزینه‌هایی مانند همپوشانی یا عرض فاصله، گروه را از طریق [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) دسترسی پیدا کنید.

زمانی که هیچ پر کردن صریحی برای نقطه یا سری تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم قالب‌بندی سری و هم نقطه موجود باشد، قالب‌بندی نقطه برای آن نقطه برتر است.

![نمودار-سری-پاورپوینت](chart-series-powerpoint.png)

## **تنظیم همپوشانی سری نمودار**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getOverlap--) میزان همپوشانی نوارها یا ستون‌ها را در یک نمودار 2D از -100 تا 100 درصد گزارش می‌دهد. این یک نمای فقط‑خواندنی از تنظیمات در گروه سری والد است. برای به‌روزرسانی تمام سری‌های سازگار در آن گروه از [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) استفاده کنید. این گزینه برای انواع نموداری که نوارها یا ستون‌های گروه‌بندی‌شده را نمایش می‌دهند اعمال می‌شود؛ بر گروه‌های سری نامرتبط در یک نمودار ترکیبی تأثیر نمی‌گذارد.

مثال زیر همپوشانی را برای گروهی که شامل اولین سری است تنظیم می‌کند:

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

## **تغییر رنگ پر کردن سری**

برای تنظیم پر کردن پیش‌فرض یک سری کامل از [IChartSeries.getFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getFormat--) استفاده کنید. اگر یک نقطه قبلاً پر کردن صریح دارد، تنظیم [IChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/#getFormat--) آن، پر کردن سری را برای آن نقطه بازنویسی می‌کند.

مثال زیر یک پر کردن آبی یکدست را به اولین سری اعمال می‌کند:

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

![رنگ سری](series_color.png)

## **تغییر نام سری**

نام یک سری در کتاب کار داده‌های نمودار ذخیره می‌شود و معمولاً در راهنما نمایش داده می‌شود. در کتاب کار پیش‌فرض ایجاد شده برای یک نمودار ستون خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین سری را شامل می‌شود. ثابت‌های نام‌گذاری شده در مثال زیر این ساختار را به‌صورت صریح نشان می‌دهند:

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

همچنین می‌توانید سلولی که توسط [IChartSeries.getName](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getName--) ارجاع شده است به‌روز کنید. این رویکرد از فرض ردیف و ستون خاص در یک نمودار موجود جلوگیری می‌کند:

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

## **دریافت رنگ پر کردن خودکار سری**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) رنگ محاسبه‌شده بر مبنای شاخص سری و سبک نمودار را برمی‌گرداند. این رنگ وقتی استفاده می‌شود که پر کردن سری صریحاً تعریف نشده باشد. فراخوانی متد تنها رنگ محاسبه‌شده را می‌خواند؛ پر کردن جدیدی اختصاص نمی‌دهد.

مثال زیر رنگ خودکار هر سری پیش‌فرض را چاپ می‌کند:

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

خروجی مثال برای سبک پیش‌فرض نمودار:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

رنگ‌های دقیق به سبک و تم نمودار وابسته‌اند.

## **تنظیم رنگ معکوس پر برای یک سری نمودار**

برای سری‌های نوار، ستون و حباب، [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) می‌تواند مقادیر منفی را با پر کردن متفاوتی نمایش دهد. پر کردن معمولی سری را به یکدست تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) اختصاص دهید. اعداد منفی در کتاب کار بدون تغییر می‌مانند؛ فقط رنگ نمایش آنها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک سری جایگزین می‌کند. ردیف 0 کاربرگ شامل نام سری، ستون 0 شامل نام‌های دسته و ستون 1 شامل مقادیر است:

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

![رنگ پر کردن معکوس یکدست](inverted_solid_fill_color.png)

می‌توانید برای یک نقطه معکوس‌سازی را از طریق [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) فعال کنید. در مثال زیر، معکوس‌سازی برای سری غیرفعال و فقط برای نقطهٔ انتخاب‌شده فعال شده است. این نقطه همچنین مقدار منفی دریافت می‌کند تا اثر قابل مشاهده باشد:

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

## **پاک کردن مقدار نقطه دادهٔ خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول پشتیبان کتاب کار آن را به `null` تنظیم کنید. برای یک نمودار ستون، مقدار ترسیم‌شده از طریق [IChartDataPoint.getValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/#getValue--) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات مقدار خالی نمودار به‌عنوان خالی در نظر می‌گیرد.

مثال زیر تنها نقطه دوم در اولین سری را پاک می‌کند:

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

نمودارهای پراکنی از سلول‌های X و Y جداگانه استفاده می‌کنند و نمودارهای حباب نیز از سلول اندازه استفاده می‌کنند. فقط سلولی که نمایانگر مقداری است که قصد حذف آن را دارید، پاک کنید. هنگام تمایل به حفظ دیگر نقاط، از [IChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapointcollection/#clear--) استفاده نکنید، زیرا این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

یک سلول خالی کتاب کار نمایانگر دادهٔ مفقود است؛ سلولی که `0` دارد نمایانگر مقدار عددی شناخته‌شده است. با فراخوانی [IChartDataCell.setValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) مقدار `null`، سلول را خالی کنید. صفر عددی صرفاً صفر می‌ماند بدون توجه به تنظیم خالی بودن سلول.

از [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) برای انتخاب نحوهٔ نمایش سلول‌های خالی توسط نمودار استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود. بدون پر کردن سلول خالی کتاب کار با صفر یا مقدار درون‌یابی، نحوهٔ ترسیم خالی‌ها را تغییر می‌دهد.

مثال خودکفای زیر یک نمودار خطی با یک سری ایجاد می‌کند، مقدار روز 3 را پاک می‌کند و همان نمودار را برای هر حالت ذخیره می‌کند. نیازی به فایل ورودی نیست. [IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/) از کاربرگ 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام سری را نگه می‌دارد. داده نهایی `10, 20, empty, 30, 40` است.

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

    // روز ۳ را واقعا خالی بگذارید، در حالی که دسته و نقطه داده آن را نگه می‌دارید.
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

هر فایل خروجی حالت اختصاص داده‌شده قبل از ذخیره‌سازی را ذخیره می‌کند: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ تنها یک نسخه، حالت موردنظر را تنظیم کنید و یک بار ارائه را ذخیره کنید به‌جای تکرار برای همه حالت‌ها.

مقایسهٔ زیر همان داده را در هر سه فایل نشان می‌دهد. روز 3 در کتاب کار در هر حالت خالی است:

![نمودارهای خطی با دادهٔ یکسان: Gap خط را در روز 3 قطع می‌کند، Zero خط را به صفر می‌کشاند و Span روز 2 را به روز 4 وصل می‌کند.](display_blanks_as.png)

اثر قابل مشاهده به نوع نمودار بستگی دارد. یک نمودار خطی مقایسهٔ سه حالت را آسان می‌کند. نمودارهای نوار و ستون خطی برای اتصال بین دستهٔ مفقود ندارند، بنابراین `Span` نمی‌تواند بخش متصل نشان داده‌شده را تولید کند؛ یک ستون خالی و یک ستون با ارتفاع صفر نیز می‌توانند مشابه به‌نظر برسند. به‌طور مشابه، یک نمودار پراکنی فقط با نشانگرها خط اتصال ندارد. انتظار نتایج متمایز برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوع مورد استفاده بررسی کنید.

## **تنظیم عرض فاصله سری**

عرض فاصله فواصل بین خوشه‌های نوار یا ستون مجاور است که به‌صورت درصدی از عرض نوار یا ستون بیان می‌شود. مشابه همپوشانی، این تنظیم به گروه سری والد تعلق دارد نه به یک سری منفرد. برای گروه یک بار [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) را صدا بزنید. مقدار بزرگ‌تر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچک‌تر آنها را متراکم‌تر می‌سازد.

مثال زیر عرض فاصله را تغییر می‌دهد و تنها ارائهٔ نهایی را ذخیره می‌کند:

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

## **پرسش‌های متداول**

**کدام انواع نمودار از سری‌های داده پشتیبانی می‌کنند؟**  
تمامی انواع نمودارهای موجود در شمارش‌گر [ChartType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/) از داده‌های نمودار استفاده می‌کنند، اما سری‌های آنها ساختار یا تنظیمات ارزش مشابهی ندارند. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنی از مقادیر X و Y، و نمودارهای حباب اندازهٔ حباب را اضافه می‌کنند. از روش ایجاد نقطه داده‌ای که با نوع سری مطابقت دارد استفاده کنید. گزینه‌هایی مانند همپوشانی و عرض فاصله فقط برای گروه‌های نوار یا ستون سازگار اعمال می‌شوند.

**یک گروه سری نمودار چیست؟**  
یک [IChartSeriesGroup](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseriesgroup/) شامل سری‌های سازگاری است که تنظیمات نموداری سطح‌گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک سری دسترسی پیدا می‌کنید لزوماً تمام سری‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار newly created شامل داده‌های پیش‌فرض است؟**  
بله. به‌صورت پیش‌فرض، [IShapeCollection.addChart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) نمونه‌ای از سری‌ها، دسته‌ها و مقادیر را ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعه دادهٔ کاملاً سفارشی، هر دو مجموعهٔ سری و دسته را پاک کنید. یک overload نیز می‌تواند نمودار را بدون داده‌های پیش‌فرض ایجاد کند.

**شیوهٔ اتصال اشیای نمودار به سلول‌های کتاب کار چگونه است؟**  
نام‌های سری، برچسب‌های دسته و مقادیر نقطه داده به سلول‌های یک [IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده عنصر مربوط به نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقدار سری را هماهنگ نگه دارید تا هر نقطه زیر دستهٔ موردنظر رسم شود.

**چگونه یک نقطه را پاک کنم بدون اینکه کل سری پاک شود؟**  
سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی حفظ شود. فقط زمانی از [IChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapointcollection/#clear--) استفاده کنید که قصد حذف تمام نقاط آن سری را دارید. اگر دسته‌ها را نیز حذف می‌کنید، تمام سری‌ها را به‌روزرسانی کنید تا مقادیرشان با مجموعهٔ دسته‌ها همسو بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**  
نتیجه به نوع نمودار و مقداری که از طریق [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) پیکربندی شده است بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فواصل، مقادیر صفر یا با وصل کردن نقاط همسایه نمایش دهند. تنظیمی که معنای دادهٔ مفقود را در ارائهٔ شما منعکس می‌کند انتخاب کنید. برای مثال کامل و مقایسهٔ بصری به بخش [کنترل نمایش سلول‌های خالی](#control-the-display-of-empty-cells) مراجعه کنید.

**مقدارهای منفی چگونه قالب‌بندی می‌شوند؟**  
برای سری‌های نوار، ستون و حباب پشتیبانی‌شده، [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) را فراخوانی کنید و رنگ بازگردانده‌شده توسط [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) بازنویسی کنید. این متدها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**وقتی هم سری و هم نقطه قالب‌بندی شوند، کدامیک برتری دارد؟**  
قالب‌بندی صریح نقطه داده برای آن نقطه برتری دارد. سایر نقاط همچنان از قالب پیش‌فرض سری استفاده می‌کنند یا وقتی قالب پیش‌فرض سری تعریف نشده باشد، از سبک و تم خودکار نمودار. تنظیمات گروهی مانند همپوشانی و عرض فاصله نمایش طرح را کنترل می‌کنند و بازنویسی قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد سری‌های یک نمودار وجود دارد؟**  
Aspose.Slides محدودیتی ثابت برای تعداد سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان رندرینگ و خوانایی نمودار حد مفیدی را تعیین می‌کند.

**چه کاری باید انجام دهم وقتی ستون‌ها بیش از حد نزدیک یا دور هستند؟**  
بر روی گروه سری والد مناسب [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) صدا بزنید. مقدار را افزایش دهید تا فضای بین خوشه‌ها گسترده‌تر شود یا کاهش دهید تا خوشه‌ها به هم نزدیک‌تر شوند.