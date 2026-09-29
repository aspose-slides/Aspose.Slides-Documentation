---
title: مدیریت سری‌های داده نمودار در ارائه‌ها با جاوا
linktitle: سری‌های داده
type: docs
url: /fa/java/chart-series/
keywords:
- سری‌های نمودار
- همپوشانی سری
- رنگ سری
- نام سری
- نقطه داده
- سلول کاربرگ
- فاصله سری
- مقدار منفی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های کاربرگ، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با جاوا مدیریت کنید.
---
## **مرور کلی**

یک نمودار داده‌های رسم‌شده خود را در یک کاربرگ داده‌های نمودار ذخیره می‌کند. یک [IChartSeries](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/) یک مجموعه مقادیر مرتبط را نشان می‌دهد و هر [IChartDataPoint](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/) در این سری به یک یا چند سلول کاربرگ اشاره دارد. اشیاء [IChartCategory](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی‌شده‌ای که توسط سری‌ها مشترک است را فراهم می‌کنند. بنابراین نام سری، دسته‌ها و مقادیر نقطه‌ها به اشیاء [IChartDataCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/) متصل هستند نه فقط به عنوان متن نمایش ذخیره شوند.

برای یک نمودار دسته‌ای معمولی، کاربرگ پیش‌فرض ردیف 0 را برای نام‌های سری‌ها، ستون 0 را برای نام‌های دسته و بقیه سلول‌ها را برای مقادیر سری‌ها استفاده می‌کند. ایندکس‌های کاربرگ، ردیف و ستون که به [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) پاس داده می‌شوند، مبتنی بر صفر هستند. این چیدمان زمانی مفید است که نموداری با داده‌های پیش‌فرض ایجاد می‌کنید، اما فرض نکنید که همه نمودارهای موجود از آن استفاده می‌کنند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کاربرگ، سلول‌های ارجاع‌شده توسط سری‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار سه حوزه مختلف دارند:

- تنظیمات سطح سری، مانند [IChartSeries.getFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getFormat--)، ظاهر پیش‌فرض تمام نقاط یک سری را فراهم می‌کند.
- تنظیمات نقطه داده، مانند [IChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/#getFormat--)، ظاهر سری را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی برای سری‌های سازگاری که به یک [IChartSeriesGroup](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseriesgroup/) تعلق دارند، اعمال می‌شود. برای تنظیم گزینه‌هایی مانند هم‌پوشانی یا عرض فاصله، از طریق [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) به گروه دسترسی پیدا کنید.

زمانی که پرکردن صریح برای نقطه یا سری تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم قالب‌بندی سری و هم نقطه موجود باشد، قالب‌بندی نقطه برای آن نقطه ارجحیت دارد.

![سری-نمودار‑پاورپوینت](chart-series-powerpoint.png)

## **تنظیم هم‌پوشانی سری نمودار**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getOverlap--) مقدار هم‌پوشانی میله‌ها یا ستون‌ها در یک نمودار دو‑بعدی را از -۱۰۰ تا ۱۰۰ درصد گزارش می‌دهد. این یک تصویر فقط‑خواندنی از تنظیمات گروه سری والد است. برای به‌روزرسانی تمام سری‌های سازگار در آن گروه از [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) استفاده کنید. این گزینه برای انواع نمودارهایی که میله‌ها یا ستون‌های گروه‌بندی‌شده را نشان می‌دهند اعمال می‌شود؛ در یک نمودار ترکیبی بر گروه‌های سری نامرتبط تأثیر نمی‌گذارد.

مثال زیر هم‌پوشانی گروهی که شامل اولین سری است را تنظیم می‌کند:

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

![هم‌پوشانی‑سری](series_overlap.png)

## **تغییر رنگ پر شدن سری**

از [IChartSeries.getFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getFormat--) برای تنظیم پر‌کردن پیش‌فرض یک سری کامل استفاده کنید. اگر یک نقطه پیش‌از‌پیش پر شد، تنظیم [IChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/#getFormat--) آن، پر‌کردن سری را برای آن نقطه بازنویسی می‌کند.

مثال زیر پر‌کردن آبی یک‌دست به اولین سری اعمال می‌کند:

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

![رنگ‑سری](series_color.png)

## **تغییر نام سری**

نام یک سری در کاربرگ داده‌های نمودار ذخیره می‌شود و به‌طور معمول در افسانه (legend) نمایش داده می‌شود. در کاربرگ پیش‌فرض ایجاد شده برای یک نمودار ستونی خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و شامل نام اولین سری است. ثابت‌های نام‌گذاری‌شده در مثال زیر این ساختار را به‌صورت صریح نشان می‌دهند:

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

شما همچنین می‌توانید سلولی که توسط [IChartSeries.getName](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getName--) ارجاع شده است را به‌روزرسانی کنید. این روش از فرض ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

![نام‑سری](series_name.png)

## **دریافت رنگ پر خودکار سری**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) رنگی را که بر اساس شاخص سری و سبک نمودار محاسبه می‌شود بازمی‌گرداند. این رنگ زمانی استفاده می‌شود که پر‌کردن سری به‌صورت صریح تعریف نشده باشد. فراخوانی این متد رنگ محاسبه‌شده را می‌خواند؛ پر کردن جدیدی اختصاص نمی‌دهد.

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

رنگ‌های دقیق به سبک و تم نمودار وابسته هستند.

## **تنظیم رنگ پر معکوس برای یک سری نمودار**

برای سری‌های میله‌ای، ستونی و حبابی، [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) می‌تواند مقادیر منفی را با پر کردن متفاوت نمایش دهد. پر کردن معمولی سری را به صورت یک‌دست تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) اختصاص دهید. اعداد منفی در کاربرگ بدون تغییر باقی می‌مانند؛ فقط رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک سری جایگزین می‌کند. ردیف 0 کاربرگ نام سری را دارد، ستون 0 نام‌های دسته و ستون 1 مقادیر را دارد:

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

![رنگ‑پر‑معکوس‑یکدست](inverted_solid_fill_color.png)

می‌توانید معکوس‌سازی را برای یک نقطه از طریق [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) فعال کنید. در مثال زیر معکوس‌سازی برای سری غیرفعال و فقط برای نقطهٔ انتخاب‌شده فعال شده است. همچنین به این نقطه مقدار منفی اختصاص داده می‌شود تا اثر قابل مشاهده باشد:

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

## **پاک‌کردن مقدار نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول کاربرگ پشت آن را به `null` تنظیم کنید. برای یک نمودار ستونی، مقدار رسم‌شده از طریق [IChartDataPoint.getValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/#getValue--) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات مقدار خالی نمودار به‌عنوان خالی در نظر می‌گیرد.

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

نمودارهای پراکنده از سلول‌های جداگانه X و Y استفاده می‌کنند و نمودارهای حبابی همچنین یک سلول اندازه دارند. فقط سلولی را که نمایانگر مقداری است که می‌خواهید حذف کنید، پاک کنید. هنگام تمایل به نگه داشتن نقاط دیگر، [IChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapointcollection/#clear--) را فراخوانی نکنید، زیرا این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که شامل مقدار هستند، موردی متفاوت نسبت به سلول‌های خالی هستند. برای شامل یا حذف داده‌ها از ردیف‌ها و ستون‌های مخفی کاربرگ، به ‎[Include Data from Hidden Rows and Columns](/slides/fa/java/chart-workbook/#include-data-from-hidden-rows-and-columns)‎ مراجعه کنید.

یک سلول خالی کاربرگ نمایانگر داده‌های گمشده است؛ سلولی که شامل `0` است، نمایانگر مقدار عددی شناخته‌شده‌ای است. با فراخوانی [IChartDataCell.setValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) با مقدار `null` یک سلول را خالی کنید. صفر عددی صرفاً صفر می‌ماند، صرف‌نظر از تنظیمات سلول خالی.

از [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) برای انتخاب نحوه نمایش سلول‌های خالی توسط نمودار استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود. نحوه رسم خالی‌ها را تغییر می‌دهد، بدون پر کردن سلول خالی کاربرگ با صفر یا مقدار درون‌یابی‌شده.

مثال خودکفا زیر یک نمودار خطی با یک سری ایجاد می‌کند، مقدار روز ۳ را پاک می‌کند و همان نمودار را با هر حالت ذخیره می‌نماید. هیچ فایل ورودی‌ای مورد نیاز نیست. ‎[IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/)‎ از کاربرگ ۰، ستون ۰ برای برچسب‌های دسته و ستون ۱ برای مقادیر استفاده می‌کند؛ ردیف ۰ نام سری را نگه می‌دارد. داده نهایی `10, 20, empty, 30, 40` است.

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

    // روز 3 را واقعاً خالی بگذارید، در حالی که دسته و نقطه داده آن را نگه می‌دارید.
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

هر فایل خروجی حالت اختصاص یافته قبل از ذخیره را نگه می‌دارد: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیره تنها یک نسخه، حالت موردنظر را تنظیم کنید و یک بار ارائه را ذخیره کنید به جای تکرار بر روی حالت‌ها.

مقایسه زیر همان داده را در هر سه فایل نشان می‌دهد. روز ۳ در کاربرگ در همه موارد خالی است:

![نمودارهای‑خطی‑با‑داده‑یکسان:‑Gap‑خط‑را‑در‑روز‑۳‑قطع‑می‌کند،‑Zero‑خط‑را‑به‑صفر‑می‌برد‑و‑Span‑نقطهٔ‑روز‑۲‑را‑به‑روز‑۴‑متصل‑می‌کند](display_blanks_as.png)

اثر قابل مشاهده به نوع نمودار بستگی دارد. یک نمودار خطی همهٔ سه حالت را به‌سادگی مقایسه می‌کند. نمودارهای میله‌ای و ستونی خطی برای ارتباط بین دستهٔ گم‌شده ندارند، بنابراین `Span` نمی‌تواند بخش اتصال نشان‑داده‌شده را تولید کند؛ یک ستون گمشده و یک ستون با ارتفاع صفر نیز می‌توانند مشابه به نظر برسند. به‌طور مشابه، یک نمودار پراکنده فقط با نشانگرها خط اتصال ندارد. انتظار نتایج سه‌گانه متمایز برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض فاصله سری**

عرض فاصله فضای بین خوشه‌های میله یا ستون مجاور است که به‌صورت درصدی از عرض میله یا ستون بیان می‌شود. مانند هم‌پوشانی، این تنظیم به گروه سری والد تعلق دارد، نه به یک سری. برای گروه یکبار [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) را فراخوانی کنید. مقدار بزرگتر فضای بین خوشه‌ها را بیشتر می‌کند؛ مقدار کوچک‌تر آن‌ها را متراکم‌تر می‌سازد.

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

![عرض‑فاصله](gap_width.png)

## **FAQ**

**کدام انواع نمودار از سری داده پشتیبانی می‌کنند؟**

تمام انواع نمودار نمایان‌شده در شمارش [ChartType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/) از داده‌های نمودار استفاده می‌کنند، اما ساختار یا تنظیمات مقادیر سری‌ها یکسان نیست. به‌عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده مقادیر X و Y، و نمودارهای حبابی اندازهٔ حباب‌ها را اضافه می‌کنند. از روش ایجاد نقطه‌داده‌ای که با نوع سری هم‌خوانی دارد استفاده کنید. گزینه‌هایی مانند هم‌پوشانی و عرض فاصله فقط برای گروه‌های میله یا ستون سازگار اعمال می‌شود.

**گروه سری نمودار چیست؟**

یک [IChartSeriesGroup](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseriesgroup/) شامل سری‌های سازگاری است که تنظیمات رسم سطح گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروه دسترسی‌یافته از طریق یک سری لزوماً تمام سری‌های نمودار را تحت تأثیر قرار نمی‌دهد.

**آیا یک نمودار تازه ایجادشده شامل داده‌های پیش‌فرض است؟**

بله. به‌طور پیش‌فرض، [IShapeCollection.addChart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) نمونه‌ای از سری‌ها، دسته‌ها و مقادیر ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا پیش از افزودن یک مجموعه دادهٔ کاملاً سفارشی، هر دو مجموعه سری و دسته را پاک کنید. یک overload نیز می‌تواند نموداری بدون داده‌های پیش‌فرض ایجاد کند.

**چگونه اشیاء نمودار به سلول‌های کاربرگ متصل می‌شوند؟**

نام‌های سری، برچسب‌های دسته و مقادیر نقاط داده به سلول‌های [IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده عنصر مربوط به نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر سری را هم‌تراز نگه دارید تا هر نقطه زیر دستهٔ موردنظر رسم شود.

**چگونه یک نقطه را به‌جای کل سری پاک کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی حفظ شود. از [IChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapointcollection/#clear--) فقط زمانی استفاده کنید که قصد حذف تمام نقاط آن سری را دارید. اگر دسته‌ها را نیز حذف می‌کنید، هر سری را به‌روزرسانی کنید تا مقادیرشان همچنان با مجموعهٔ دسته‌ها هم‌تراز بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقداری که از طریق [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) تنظیم شده است بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فاصله، مقدار صفر یا با اتصال نقاط مجاور نمایش دهند. تنظیمی را انتخاب کنید که با معنای داده‌های گمشده در ارائه شما منطبق باشد. برای مثال کامل و مقایسهٔ بصری به [Control the Display of Empty Cells](#control-the-display-of-empty-cells) مراجعه کنید.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای سری‌های میله‌ای، ستونی و حبابی پشتیبانی‌شده، [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) را فراخوانی کنید و رنگ بازگردانده‌شده توسط [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ جداگانه با [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) بازنویسی کنید. این متدها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**کدام قالب‌بندی برنده می‌شود وقتی هم سری و هم نقطه قالب‌بندی شده‌اند؟**

قالب‌بندی صریح نقطه داده برای آن نقطه ارجحیت دارد. نقاط دیگر به‌کارگیری قالب صریح سری را ادامه می‌دهند یا وقتی قالب سری تعریف نشده باشد، از سبک و تم خودکار نمودار استفاده می‌کنند. تنظیمات گروهی مانند هم‌پوشانی و عرض فاصله طرح‌بندی را کنترل می‌کنند و بازنویسی قالب‌بندی در سطح نقطه نیستند.

**آیا محدودیتی برای تعداد سری‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان رندر و قابلیت خواندن نمودار، حد مفیدی را تعیین می‌کنند.

**چه چیزی را تغییر دهم وقتی ستون‌ها بیش از حد نزدیک یا دور هستند؟**

بر روی گروه سری والد مناسب [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) فراخوانی کنید. مقدار را افزایش دهید تا فضای بین خوشه‌ها بیش‌تر شود یا کاهش دهید تا خوشه‌ها به‌هم نزدیک‌تر شوند.