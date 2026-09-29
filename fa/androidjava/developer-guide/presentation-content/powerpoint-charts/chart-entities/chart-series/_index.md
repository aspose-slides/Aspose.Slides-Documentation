---
title: مدیریت سری‌های دادهٔ نمودار در ارائه‌ها بر روی اندروید
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
description: "یادگیری نحوه مدیریت سری‌های نمودار، نقاط داده، سلول‌های کتاب‌کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی در ارائه‌ها بر روی اندروید."
---
## **نمای کلی**

یک نمودار داده‌های نمودار شده خود را در یک کتاب‌کار دادهٔ نمودار ذخیره می‌کند. یک [IChartSeries](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/) یک مجموعهٔ مقادیر مرتبط را نشان می‌دهد و هر [IChartDataPoint](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/) در این مجموعه به یک یا چند سلول کتاب‌کار ارجاع می‌دهد. اشیاء [IChartCategory](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی شدهٔ مشترک بین مجموعه‌ها را فراهم می‌کنند. بنابراین نام مجموعه، دسته‌ها و مقادیر نقطه‌ها به اشیاء [IChartDataCell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatacell/) متصل هستند نه اینکه فقط به عنوان متن نمایش ذخیره شوند.

برای یک نمودار دسته‌ای معمول، کتاب‌کار پیش‌فرض از ردیف 0 برای نام‌های مجموعه، ستون 0 برای نام‌های دسته و سلول‌های باقی‌مانده برای مقادیر مجموعه استفاده می‌کند. اندیس‌های کاربرگ، ردیف و ستون که به [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) پاس داده می‌شوند، از صفر شروع می‌شوند. این چیدمان وقتی که نمودار را با داده‌های پیش‌فرض ایجاد می‌کنید مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائهٔ بارگذاری‑شده، قبل از تغییر مقادیر کتاب‌کار، سلول‌های ارجاع‑داده‌شده توسط مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار در سه محدودهٔ متفاوت وجود دارند:

- تنظیمات سطح مجموعه، مانند [IChartSeries.getFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getFormat--)، ظاهر پیش‌فرض همهٔ نقاط یک مجموعه را فراهم می‌کند.
- تنظیمات نقطهٔ داده، مانند [IChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--)، ظاهر مجموعه را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی بر مجموعه‌های سازگاری که به همان [IChartSeriesGroup](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseriesgroup/) تعلق دارند اعمال می‌شود. برای تنظیم گزینه‌هایی مانند overlap یا gap width، از [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) استفاده کنید.

وقتی هیچ پرش صریحی برای نقطه یا مجموعه تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم تنظیمات مجموعه و هم تنظیمات نقطه وجود داشته باشد، تنظیمات نقطه برای همان نقطه اولویت دارد.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تنظیم Overlap مجموعهٔ نمودار**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getOverlap--) مقدار همپوشانی نوارها یا ستون‌ها را در یک نمودار دو‑بعدی، از -100 تا 100 درصد، گزارش می‌دهد. این یک نمای فقط‑خواندنی از تنظیمات گروه مجموعهٔ والد است. برای به‑روزرسانی همهٔ مجموعه‌های سازگار در آن گروه، از [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) استفاده کنید. این گزینه برای انواع نموداری که نوارها یا ستون‌های گروهی را نمایش می‌دهند اعمال می‌شود؛ برای گروه‌های مجموعهٔ نامرتبط در یک نمودار ترکیبی تأثیری ندارد.

مثال زیر overlap گروهی که شامل اولین مجموعه است را تنظیم می‌کند:

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

![The series overlap](series_overlap.png)

## **تغییر رنگ پرشدن مجموعه**

از [IChartSeries.getFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getFormat--) برای تنظیم پرشدن پیش‌فرض یک مجموعهٔ کامل استفاده کنید. اگر یک نقطه قبلاً پرشدن صریح داشته باشد، تنظیم [IChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) آن، پرشدن مجموعه را برای همان نقطه بازنویسی می‌کند.

مثال زیر پرشدن آبی ثابت را به اولین مجموعه اعمال می‌کند:

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

![The color of the series](series_color.png)

## **تغییر نام مجموعه**

نام مجموعه در کتاب‌کار دادهٔ نمودار ذخیره می‌شود و معمولاً در افسانه (legend) نمایش داده می‌شود. در کتاب‌کار پیش‌فرض ایجاد شده برای یک نمودار ستونی خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین مجموعه را شامل می‌شود. ثابت‌های نام‌گذاری در مثال زیر این ساختار را به‌وضوح نشان می‌دهند:

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

همچنین می‌توانید سلولی را که توسط [IChartSeries.getName](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getName--) ارجاع شده است، به‌روزرسانی کنید. این روش از فرض یک ردیف و ستون خاص در یک نمودار موجود جلوگیری می‌کند:

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

![The series name](series_name.png)

## **دریافت رنگ پرشدن خودکار مجموعه**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) رنگی را که بر پایهٔ اندیس مجموعه و سبک نمودار محاسبه می‌شود، به صورت یک عدد صحیح ARGB اندروید برمی‌گرداند. این همان رنگی است که وقتی پرشدن مجموعه به‌صورت صریح تعریف نشده باشد، استفاده می‌شود. فراخوانی این متد فقط مقدار محاسبه‌شده را می‌خواند؛ پرشدنی جدید اختصاص نمی‌دهد.

مثال زیر عدد صحیح رنگ خودکار هر مجموعه پیش‌فرض را چاپ می‌کند:

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

مقادیر دقیق عددی بسته به سبک و تم نمودار متفاوت هستند.

## **تنظیم رنگ پرشدن معکوس برای یک مجموعهٔ نمودار**

برای مجموعه‌های نوار، ستون و حباب، [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) می‌تواند مقادیر منفی را با پرشدن متفاوتی نمایش دهد. پرشدن معمولی مجموعه را به‌صورت ثابت تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) اختصاص دهید. اعداد منفی در کتاب‌کار بدون تغییر می‌مانند؛ فقط رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف 0 کاربرگ شامل نام مجموعه، ستون 0 شامل نام‌های دسته و ستون 1 شامل مقادیر است:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

می‌توانید برای یک نقطهٔ خاص معکوس‌سازی را از طریق [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) فعال کنید. در مثال زیر معکوس‌سازی برای مجموعه غیرفعال و فقط برای نقطهٔ انتخاب‌شده فعال می‌شود. همچنین به این نقطه مقدار منفی اختصاص داده می‌شود تا اثر قابل مشاهده باشد:

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

## **پاک کردن مقدار یک نقطهٔ دادهٔ خاص**

برای خالی‌کردن یک نقطه بدون حذف نقاط دیگر، سلول پشتیبان کتاب‌کار آن را به `null` تنظیم کنید. برای یک نمودار ستونی، مقدار رسم‌شده از طریق [IChartDataPoint.getValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) در دسترس است. نقطهٔ داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات مقادیر خالی نمودار به‌عنوان خالی درنظر می‌گیرد.

مثال زیر فقط نقطهٔ دوم مجموعهٔ اول را پاک می‌کند:

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

نمودارهای پراکندگی از سلول‌های جداگانهٔ X و Y استفاده می‌کنند و نمودارهای حباب نیز از یک سلول اندازه استفاده می‌کنند. فقط سلولی را که نمایانگر مقدار مورد نظر برای حذف است پاک کنید. هنگام نیاز به حفظ نقاط دیگر، از فراخوانی [IChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) خودداری کنید، زیرا این متد تمام نقاط دادهٔ مجموعه را حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های پنهانی که مقادیر دارند موردی متفاوت نسبت به سلول‌های خالی هستند. برای شامل یا حذف داده‌ها از ردیف‌ها و ستون‌های پنهان کاربرگ، به مقالهٔ [Include Data from Hidden Rows and Columns](/slides/fa/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns) مراجعه کنید.

یک سلول کتاب‌کار خالی نشان‌دهندهٔ دادهٔ از دست رفته است؛ سلولی که `0` دارد نمایانگر مقدار عددی شناخته‌شده‌ای است. برای خالی‌کردن یک سلول، [IChartDataCell.setValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) را با `null` فراخوانی کنید. عدد صفر عددی صفر می‌ماند صرف‌نظر از تنظیم خالی‑سلول.

از [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) برای انتخاب نحوهٔ نمایش سلول‌های خالی توسط نمودار استفاده کنید. این تنظیم بر کل نمودار اعمال می‌شود. این گزینه نحوهٔ رسم خالی‌ها را تغییر می‌دهد بدون اینکه سلول خالی کتاب‌کار با صفر یا مقدار درونی‌سازی‑شده پر شود.

مثال خود‑محافظ زیر یک نمودار خطی با یک مجموعه ایجاد می‌کند، مقدار روز 3 را پاک می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. نیازی به فایل ورودی نیست. [IChartDataWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdataworkbook/) از کاربرگ 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام مجموعه را دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است.

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

    // روز 3 را به‌طور واقعی خالی بگذارید، در حالی که دسته و نقطهٔ دادهٔ آن را حفظ می‌کنید.
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

هر فایل خروجی حالت اختصاص‑یافته قبل از ذخیره‌سازی را نشان می‌دهد: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ فقط یک نسخه، حالت دلخواه را تنظیم کنید و یک‌بار ارائه را ذخیره کنید، به جای تکرار بر روی حالت‌ها.

مقایسهٔ زیر همان داده را در هر سه فایل نشان می‌دهد. روز 3 در هر حالت در کتاب‌کار خالی است:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

اثر قابل مشاهده بسته به نوع نمودار متفاوت است. یک نمودار خطی همهٔ سه حالت را برای مقایسه آسان می‌کند. نمودارهای میله و ستونی خطی برای اتصال قطعات بین دسته‌های گمشده ندارند، به همین دلیل `Span` نمی‌تواند قطعهٔ متصل را که در بالا نشان داده شد تولید کند؛ یک ستون گمشده و یک ستون با ارتفاع صفر نیز می‌توانند مشابه به‌نظر برسند. به‌طور مشابه، یک نمودار پراکندگی فقط با مارکرها هیچ خط متصلی ندارد. انتظار ندارید که برای هر نوع نمودار سه نتیجهٔ متمایز داشته باشید؛ خروجی را برای نوع نموداری که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض فاصلهٔ مجموعه**

عرض فاصله (Gap width) فاصله بین خوشه‌های میله یا ستون مجاور است که به‌صورت درصدی از عرض میله یا ستون بیان می‌شود. همانند overlap، این تنظیم متعلق به گروه مجموعهٔ والد است نه به یک مجموعهٔ خاص. یک‌بار برای گروه فراخوانی کنید: [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-). مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آن را متراکم‌تر می‌سازد.

مثال زیر عرض فاصله را تغییر داده و فقط ارائهٔ نهایی را ذخیره می‌کند:

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

![The gap width](gap_width.png)

## **سؤالات متداول**

**کدام انواع نمودار از مجموعه‌های داده پشتیبانی می‌کنند؟**

تمام انواع نمودار که توسط شمارش [ChartType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/charttype/) توصیف می‌شوند از دادهٔ نمودار استفاده می‌کنند، اما ساختار یا تنظیمات ارزش آن‌ها یکسان نیست. به‌عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکندگی از مقادیر X و Y، و نمودارهای حباب علاوه بر آن اندازهٔ حباب را دارند. از روش ایجاد نقطهٔ داده‌ای که با نوع مجموعه مطابقت دارد استفاده کنید. گزینه‌هایی مانند overlap و gap width فقط برای گروه‌های میوه یا ستون سازگار اعمال می‌شوند.

**گروه مجموعهٔ نمودار چیست؟**

یک [IChartSeriesGroup](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseriesgroup/) شامل مجموعه‌های سازگاری است که تنظیمات رسم در سطح گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک مجموعه دسترسی پیدا می‌کنید لزوماً تمام مجموعه‌های نمودار را تغییر نمی‌دهد.

**آیا نمودار تازه‌ساخته‌شده داده‌های پیش‌فرض دارد؟**

بله. به‌طور پیش‌فرض، [IShapeCollection.addChart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) مجموعه‌ها، دسته‌ها و مقادیر نمونه را ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن یک مجموعه دادهٔ کاملاً سفارشی، هر دو مجموعه و دسته‌ها را پاک کنید. یک overload نیز می‌تواند نموداری بدون دادهٔ پیش‌فرض ایجاد کند.

**اشیاء نمودار چگونه به سلول‌های کتاب‌کار متصل می‌شوند؟**

نام‌های مجموعه، برچسب‌های دسته و مقادیر نقطهٔ داده به سلول‌های یک [IChartDataWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‑داده‌شده، المان مربوطهٔ نمودار را به‌روزرسانی می‌کند. هنگام ساخت دادهٔ سفارشی، ردیف‌های دسته و ردیف‌های مقادیر مجموعه را هم‌راستا نگه دارید تا هر نقطه زیر دستهٔ موردنظر رسم شود.

**چگونه یک نقطه را به‌جای تمام مجموعه پاک کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی حفظ شود. فقط وقتی می‌خواهید تمام نقاط یک مجموعه را حذف کنید، از [IChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) استفاده کنید. اگر دسته‌ها را نیز حذف می‌کنید، هر مجموعه را به‌روزرسانی کنید تا مقادیرشان با مجموعهٔ دسته‌ها هم‌راستا بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه بسته به نوع نمودار و مقدار تنظیم‌شده از طریق [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) متفاوت است. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌عنوان شکاف، مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که معنای دادهٔ از دست رفته در ارائهٔ شما را منعکس کند. برای مثال کامل و مقایسهٔ تصویری، بخش «Control the Display of Empty Cells» را ببینید.

**مقدارهای منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های میوه، ستون و حباب پشتیبانی‌شده، [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) را فراخوانی کنید و رنگی که از [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) برمی‌گردد، تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ فردی با [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) بازنویسی کنید. این متدها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**اگر هم مجموعه و هم نقطه قالب‌بندی شوند، کدام برتر است؟**

قالب‌بندی صریح نقطهٔ داده برای همان نقطه اولویت دارد. نقاط دیگر همچنان از قالب‌بندی صریح مجموعه یا، اگر قالب‌بندی مجموعه تعریف نشده باشد، از سبک و تم خودکار نمودار استفاده می‌کنند. تنظیمات گروهی مانند overlap و gap width برچسب‌ها را کنترل می‌کنند و بازنویسی قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد مجموعه‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانهٔ تعداد مجموعه‌ها را اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه موجود، زمان رندر و قابلیت خوانایی نمودار تعیین‌کنندهٔ حد معقول هستند.

**اگر ستون‌ها بیش از حد به‌هم نزدیک یا دور باشند چه کاری باید انجام دهم؟**

متد [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) را بر روی گروه مجموعهٔ والد مناسب فراخوانی کنید. مقدار را افزایش دهید تا فضای بین خوشه‌ها عریض‌تر شود یا کاهش دهید تا خوشه‌ها نزدیک‌تر شوند.