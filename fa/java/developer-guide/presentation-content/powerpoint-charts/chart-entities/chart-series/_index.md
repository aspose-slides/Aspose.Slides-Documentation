---
title: مدیریت سری‌های داده نمودار در ارائه‌ها با جاوا
linktitle: سری داده
type: docs
url: /fa/java/chart-series/
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
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های کتاب‌کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با جاوا مدیریت کنید."
---
## **مرور کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک کتاب‌کار داده نمودار ذخیره می‌کند. یک [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) یک مجموعه مقادیر مرتبط را نشان می‌دهد و هر [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) در این مجموعه به یک یا چند سلول کتاب‌کار ارجاع می‌دهد. اشیای [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی‌شده‌ای را که بین مجموعه‌ها مشترک است، فراهم می‌کنند. بنابراین نام مجموعه، دسته‌ها و مقادیر نقاط به اشیای [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) مرتبط هستند نه اینکه صرفاً به‌عنوان متن نمایش ذخیره شوند.

در یک نمودار دسته‌ای معمولی، کتاب‌کار پیش‌فرض از ردیف 0 برای نام‌های مجموعه، ستون 0 برای نام‌های دسته و بقیه سلول‌ها برای مقادیر مجموعه استفاده می‌کند. اندیس‌های برگه کاری، ردیف و ستون که به ‎[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-)‎ پاس داده می‌شوند، صفر‑مبنا هستند. این چیدمان هنگام ایجاد یک نمودار با داده‌های پیش‌فرض مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای ارائهٔ بارگذاری‌شده، پیش از تغییر مقادیر کتاب‌کار، سلول‌های ارجاع دیده شده توسط مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار در سه حوزهٔ متفاوت قرار دارند:

- تنظیمات سطح مجموعه، مانند ‎[IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--)‎، ظاهر پیش‌فرض تمام نقاط یک مجموعه را تعیین می‌کنند.
- تنظیمات نقطهٔ داده، مانند ‎[IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--)‎، ظاهر یک نقطه را نسبت به مجموعه‌اش بازنویسی می‌کند.
- تنظیمات گروهی به مجموعه‌های هم‌روندی که به یک ‎[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/)‎ تعلق دارند اعمال می‌شوند. برای تنظیم گزینه‌هایی مثل همپوشانی یا عرض فاصله، گروه را از طریق ‎[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--)‎ دریافت کنید.

زمانی که پر شدن صریحی برای نقطه یا مجموعه تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. هنگامی که هم قالب‌بندی مجموعه و هم نقطه موجود باشد، قالب‌بندی نقطه برای آن نقطه برتری دارد.

![نمودار‑سری‑پاورپوینت](chart-series-powerpoint.png)

## **تنظیم همپوشانی سری‌های نمودار**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) گزارش می‌دهد که نوارها یا ستون‌ها در یک نمودار دو‑بعدی تا چه میزان (از ‎-100‎ تا ‎100‎ درصد) روی هم می‌افتند. این مقدار تنها یک تصویر فقط‑خواندنی از تنظیمات گروه والد است. برای به‌روزرسانی تمام مجموعه‌های هم‌روند در آن گروه، از ‎[IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-)‎ استفاده کنید. این گزینه برای انواع نموداری که نوارها یا ستون‌های گروهی نمایش می‌دهند اعمال می‌شود؛ در نمودار ترکیبی بر مجموعه‌های گروهی نامرتبط اثر نمی‌گذارد.

مثال زیر همپوشانی گروهی که حاوی اولین مجموعه است را تنظیم می‌کند:

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

![همپوشانی مجموعه‌ها](series_overlap.png)

## **تغییر رنگ پر کنندهٔ مجموعه**

از ‎[IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--)‎ برای تنظیم پر کنندهٔ پیش‌فرض یک مجموعه تمام‌عیار استفاده کنید. اگر برای یک نقطه پر کنندهٔ صریحی تنظیم شده باشد، تنظیم ‎[IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--)‎ آن برای همان نقطه بر قالب‌بندی مجموعه ارجحیت دارد.

مثال زیر یک پر کردن آبی ثابت به اولین مجموعه اعمال می‌کند:

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

![رنگ مجموعه](series_color.png)

## **تغییر نام مجموعه**

نام یک مجموعه در کتاب‌کار دادهٔ نمودار ذخیره می‌شود و معمولاً در راهنمایی (legend) نمایش داده می‌شود. در کتاب‌کار پیش‌فرض ساخته‌شده برای یک نمودار ستونی خوشه‌ای، سلول ‎B1‎ (ردیف 0، ستون 1) شامل نام اولین مجموعه است. ثابت‌های نام‌گذاری در مثال زیر این ساختار را صریح می‌کند:

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

شما می‌توانید سلول ارجاع‌شده توسط ‎[IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--)‎ را نیز به‌روز کنید. این روش از فرض ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

![نام مجموعه](series_name.png)

### **ایجاد مجموعه‌ای با نام ترکیبی از چند سلول**

نام ترکیبی مجموعه زمانی مفید است که نام محصول و بازهٔ گزارش‌گیری در سلول‌های جداگانه‌ای ذخیره شوند. به‌عنوان مثال می‌توانید `Product A` در ‎B1‎ و `2026` در ‎C1‎ را به یک نام مجموعه ترکیب کنید در حالی که هر دو بخش به سلول‌های منبع خود پیوند دارند.

برای دریافت بازهٔ نام از ‎[IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-)‎ استفاده کنید، سپس آن مجموعه را به ‎[IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-)‎ پاس دهید. آرگومان ‎skipHiddenCells‎ تعیین می‌کند که آیا سلول‌های مخفی شامل شوند یا نه: ‎true‎ آن‌ها را حذف می‌کند، ‎false‎ شامل می‌شود. این مثال از ‎false‎ برای شامل کردن تمام سلول‌های بازهٔ نام استفاده می‌کند.

مثال زیر یک ارائه با یک مجموعه و دو نقطهٔ داده ایجاد می‌کند. سلول‌های ‎B1:C1‎ فقط نام مجموعه را فراهم می‌کنند؛ ‎A2:A3‎ برچسب‌های دسته؛ و ‎B2:B3‎ مقادیر عددی.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // این دو سلول نام مجموعه را فراهم می‌کند.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // سلول‌های جداگانه دسته‌ها و نقاط داده عددی را فراهم می‌کنند.
    IChartDataCell northCategory = workbook.getCell(0, 1, 0, "North");
    IChartDataCell southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    IChartDataCell northValue = workbook.getCell(0, 1, 1, 120);
    IChartDataCell southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نام مجموعهٔ حاصل `Product A 2026` است، با یک فاصله بین دو مقدار سلول. راهنمایی آن را به‌عنوان یک ورودی برای هر دو ستون نمایش می‌دهد. تصویر زیر نتیجه را نشان می‌دهد:

![نمودار ستون با مقادیر شمال و جنوب و نام ترکیبی مجموعه Product A 2026 در راهنمایی](composite_series_name.png)

## **دریافت رنگ پر کنندهٔ خودکار مجموعه**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) رنگی را برمی‌گرداند که بر پایهٔ اندیس مجموعه و سبک نمودار محاسبه می‌شود. این همان رنگی است که زمانی استفاده می‌شود که پر کردن مجموعه صریحاً تعریف نشده باشد. فراخوانی متد فقط رنگ محاسبه‌شده را می‌خواند؛ رنگ جدیدی را اختصاص نمی‌دهد.

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

## **تنظیم رنگ پر کردن معکوس برای یک مجموعه نمودار**

برای مجموعه‌های نوار، ستون و حباب، ‎[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-)‎ می‌تواند مقادیر منفی را با پر کردن متفاوتی نشان دهد. پر کردن معمولی مجموعه را به‌صورت صلب تنظیم کنید، معکوس‌سازی را فعال نمایید و رنگ مقدار منفی را از طریق ‎[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)‎ اختصاص دهید. اعداد منفی در کتاب‌کار تغییر نمی‌کنند؛ تنها رنگ نمایش آن‌ها عوض می‌شود.

مثال زیر داده‌های پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف ‎0‎ برگه کاری نام مجموعه را دارد، ستون ‎0‎ نام‌های دسته و ستون ‎1‎ مقادیر را داراست:

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

![رنگ صلب معکوس شده](inverted_solid_fill_color.png)

می‌توانید برای یک نقطه خاص معکوس‌سازی را از طریق ‎[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-)‎ فعال کنید. در مثال زیر معکوس‌سازی برای مجموعه غیرفعال و فقط برای نقطهٔ انتخاب‌شده فعال می‌شود. نقطه نیز مقدار منفی دریافت می‌کند تا اثر واضح باشد:

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

## **پاک کردن مقدار یک نقطهٔ دادهٔ خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول پشت صحنهٔ آن را به ‎null‎ تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق ‎[IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--)‎ قابل دسترسی است. نقطه داده در همان موقعیت دسته می‌ماند، ولی نمودار مقدار آن را مطابق تنظیمات خالی‑مقدار، به‌عنوان خالی در نظر می‌گیرد.

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

نمودارهای پراکنده از سلول‌های X و Y جداگانه استفاده می‌کنند و نمودارهای حباب نیز از سلول اندازه استفاده می‌کنند. فقط سلولی را که نمایانگر مقداری است که می‌خواهید حذف کنید، پاک کنید. هنگام تمایل به حفظ سایر نقاط، ‎[IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--)‎ را فراخوانی نکنید؛ این متد تمام نقاط مجموعه را حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که دارای مقدار هستند مورد متفاوتی نسبت به سلول‌های خالی محسوب می‌شوند. برای گنجاندن یا حذف داده‌ها از ردیف‌ها و ستون‌های مخفی برگه کاری، به ‎[Include Data from Hidden Rows and Columns](/slides/fa/java/chart-workbook/#include-data-from-hidden-rows-and-columns)‎ مراجعه کنید.

یک سلول خالی در کتاب‌کار نمایانگر دادهٔ گمشده است؛ سلولی که ‎0‎ دارد نمایانگر مقدار عددی شناخته‌شده است. برای خالی کردن یک سلول، ‎[IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-)‎ را با ‎null‎ صدا بزنید. عدد صفر عددی صفر باقی می‌ماند، صرف‌نظر از تنظیم خالی‑سلول.

از ‎[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)‎ برای انتخاب نحوهٔ نمایش سلول‌های خالی در کل نمودار استفاده کنید. این تنظیم برای تمام نمودار اعمال می‌شود و نحوهٔ ترسیم خالی‌ها را بدون پر کردن سلول خالی با صفر یا مقدار تقریباً تغییر می‌دهد.

مثال زیر یک نمودار خطی با یک مجموعه می‌سازد، مقدار روز ۳ را پاک می‌کند و هر حالت را ذخیره می‌کند. نیازی به فایل ورودی نیست. ‎[IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/)‎ از برگه‌کاری 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام مجموعه را در خود دارد. دادهٔ نهایی ‎10, 20, empty, 30, 40‎ است.

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

    // روز ۳ را به صورت واقعی خالی بگذارید در حالی که دسته و نقطه داده آن را حفظ می‌کنید.
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

هر فایل خروجی حالت اختصاص‌یافته پیش از ذخیره را نشان می‌دهد: ‎empty_cells_Gap.pptx‎، ‎empty_cells_Zero.pptx‎ و ‎empty_cells_Span.pptx‎. برای ذخیرهٔ تنها یک نسخه، حالت موردنظر را تنظیم کنید و یکبار ارائه را ذخیره کنید.

مقایسهٔ زیر همان داده را در هر سه فایل نشان می‌دهد. روز ۳ در کتاب‌کار در همه موارد خالی است:

![نمودارهای خطی با دادهٔ یکسان: Gap خط را در روز ۳ می‌شکند، Zero خط را به صفر می‌کشاند و Span روز ۲ را به روز ۴ متصل می‌کند.](display_blanks_as.png)

اثر قابل‌مشاهده به نوع نمودار وابسته است. در نمودار خطی همهٔ سه حالت به راحتی قابل مقایسه‌اند. نمودارهای نوار و ستون خطی برای اتصال بین دستهٔ گمشده ندارند، بنابراین ‎Span‎ نمی‌تواند قطعهٔ متصل‌شدهٔ بالا را تولید کند؛ یک ستون گمشده و یک ستون صفر‑ارتفاع می‌توانند ظاهراً مشابه باشند. به‌طور مشابه، نمودار پراکنده فقط نشانگر دارد و خطی برای وصل کردن وجود ندارد. انتظار نتایج سه‑گانهٔ متمایز برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض فاصله مجموعه**

عرض فاصله فضای بین خوشه‌های نوار یا ستون مجاور است و به صورت درصدی از عرض نوار یا ستون بیان می‌شود. همانند همپوشانی، این تنظیم متعلق به گروه والد مجموعه است نه به یک مجموعهٔ واحد. برای گروه یکبار ‎[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)‎ را فراخوانی کنید. مقدار بزرگتر فضای بین خوشه‌ها را گسترده‌تر می‌کند؛ مقدار کوچکتر آن‌ها را متراکم می‌سازد.

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

![عرض فاصله](gap_width.png)

## **پرسش‌های متداول**

**کدام انواع نمودار از مجموعه داده‌ها پشتیبانی می‌کنند؟**

تمام انواع نمودارهای تعریف‌شده در ‎[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)‎ از داده‌های نمودار استفاده می‌کنند، اما ساختار مقادیر یا تنظیمات مجموعهٔ آن‌ها یکسان نیست. به‌عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده از مقادیر X و Y، و نمودارهای حباب از اندازهٔ حباب‌ها علاوه بر X و Y. از روش ایجاد نقطهٔ داده‌ای استفاده کنید که با نوع مجموعه مطابقت داشته باشد. گزینه‌هایی مانند همپوشانی و عرض فاصله فقط برای گروه‌های نوار یا ستون سازگار اعمال می‌شوند.

**گروه مجموعهٔ نمودار چیست؟**

یک ‎[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/)‎ شامل مجموعه‌های سازگاری است که تنظیمات رسم سطح‑گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک مجموعه دسترسی پیدا می‌کنید، لزوماً همهٔ مجموعه‌های نمودار را تحت تأثیر قرار نمی‌دهد.

**آیا یک نمودار تازه‌ساز داده‌های پیش‌فرض دارد؟**

بله. به‌صورت پیش‌فرض ‎[IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-)‎ مجموعه‌ها، دسته‌ها و مقادیر نمونه ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعه دادهٔ سفارشی کامل، هر دو مجموعه و دسته‌ها را پاک کنید. یک overload نیز می‌تواند نموداری بدون دادهٔ پیش‌فرض ایجاد کند.

**شیءهای نمودار چگونه به سلول‌های کتاب‌کار مرتبط می‌شوند؟**

نام‌های مجموعه، برچسب‌های دسته و مقادیر نقطهٔ داده به سلول‌های ‎[IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/)‎ ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده عنصر مربوط به نمودار را به‌روز می‌کند. هنگام ساخت دادهٔ سفارشی، ردیف‌های دسته و ردیف‌های مقادیر مجموعه را طوری تنظیم کنید که هر نقطه زیر دستهٔ موردنظر خود ترسیم شود.

**چگونه یک نقطه را به‌جای تمام مجموعه پاک کنم؟**

سلول مقدار مربوطه را به ‎null‎ تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی حفظ شود. از ‎[IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--)‎ فقط زمانی استفاده کنید که قصد حذف تمام نقاط یک مجموعه را دارید. اگر دسته‌ها را نیز حذف می‌کنید، تمام مجموعه‌ها را طوری به‌روز کنید که مقادیرشان با مجموعهٔ دسته هم‌راستا بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقداری که از طریق ‎[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)‎ پیکربندی می‌شود، بستگی دارد. نمودارهای پشتیبان می‌توانند خالی‌ها را به‌صورت فاصله، مقدار صفر یا با وصل کردن نقاط مجاور نمایش دهند. تنظیمی که با معنی دادهٔ گمشده در ارائهٔ شما مطابقت داشته باشد انتخاب کنید. برای مثال کامل و مقایسهٔ بصری، بخش ‎[Control the Display of Empty Cells](#control-the-display-of-empty-cells)‎ را ببینید.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های نوار، ستون و حباب پشتیبانی‌شده، ‎[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-)‎ را فراخوانی کنید و رنگی که از ‎[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)‎ برمی‌گردد تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با ‎[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-)‎ بازنویسی کنید. این متدها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند، مقدار عددی ذخیره‌شده را تغییر نمی‌دهند.

**زمانی که هم مجموعه و هم نقطه قالب‌بندی شوند، کدام یک برتری دارد؟**

قالب‌بندی صریح نقطهٔ داده برای همان نقطه برتری دارد. سایر نقاط به قالب‌بندی صریح مجموعه یا، اگر قالب‌بندی مجموعه تعریف نشده باشد، به سبک و تم خودکار نمودار ادامه می‌دهند. تنظیمات گروهی مانند همپوشانی و عرض فاصله کنترل چیدمان را انجام می‌دهند و بازنویسی قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد مجموعه‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد مجموعه‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان رندرینگ و خوانایی نمودار تعیین‌کنندهٔ حد قابل‌استفاده هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها خیلی نزدیک یا خیلی دور هستند؟**

بر روی گروه والد مجموعه مناسب ‎[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)‎ را فراخوانی کنید. مقدار را افزایش دهید تا فاصله بین خوشه‌ها عریض‌تر شود یا کاهش دهید تا خوشه‌ها به‌هم نزدیک‌تر شوند.