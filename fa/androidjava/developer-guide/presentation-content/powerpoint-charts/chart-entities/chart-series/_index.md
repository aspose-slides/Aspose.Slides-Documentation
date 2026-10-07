---
title: مدیریت سری داده‌های نمودار در ارائه‌های اندروید
linktitle: سری داده‌ها
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
- اندروید
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های کتاب‌کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌های اندروید مدیریت کنید."
---
## **بررسی کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک کتاب‌کار داده‌های نمودار ذخیره می‌کند. یک [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) مجموعه‌ای از مقادیر مرتبط را نشان می‌دهد و هر [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) در سری به یک یا بیش از یک سلول کتاب‌کار ارجاع می‌دهد. اشیای [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین سری‌ها را فراهم می‌کنند. بنابراین نام سری، دسته‌ها و مقادیر نقاط به اشیای [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) متصل هستند نه اینکه فقط به‌صورت متن نمایشی ذخیره شوند.

برای یک نمودار دسته‌ای معمولی، کتاب‌کار پیش‌فرض ردیف 0 را برای نام‌های سری، ستون 0 را برای نام‌های دسته و بقیه سلول‌ها را برای مقادیر سری استفاده می‌کند. شاخص‌های ورق‌کار، ردیف و ستون که به [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) ارسال می‌شوند، مبتنی بر صفر هستند. این چیدمان زمانی که نموداری با داده‌های پیش‌فرض ایجاد می‌کنید مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کتاب‌کار، سلول‌های ارجاع‌دیده‌شده توسط سری‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه حوزه متفاوت هستند:

- تنظیمات در سطح سری، مانند [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--), ظاهر پیش‌فرض همه نقاط در یک سری را فراهم می‌کنند.
- تنظیمات نقطه‌داده، مانند [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), ظاهر سری را برای یک نقطه بازنویسی می‌کنند.
- تنظیمات گروهی بر روی سری‌های سازگاری که به همان [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) تعلق دارند اعمال می‌شود. هنگام نیاز به تنظیم گزینه‌هایی مانند همپوشانی یا عرض فواصل، گروه را از طریق [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) دسترسی کنید.

زمانی که پر کردن صریح نقطه یا سری تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کنند. هنگامی که هم فرمت سری و هم فرمت نقطه وجود داشته باشد، فرمت نقطه برای آن نقطه برتری دارد.

![نمودار-سری-پاورپوینت](chart-series-powerpoint.png)

## **تنظیم همپوشانی سری نمودار**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) گزارش می‌دهد که ستون‌ها یا میله‌ها در یک نمودار دو‌بعدی تا چه حد همپوشانی دارند، از -100 تا 100 درصد. این یک پیش‌بینی فقط‑خواندنی از تنظیمات گروه سری والد است. از [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) برای به‌روزرسانی همه سری‌های سازگار در آن گروه استفاده کنید. این گزینه بر انواع نمودارهایی که میله‌ها یا ستون‌های گروهی را نمایش می‌دهند اعمال می‌شود؛ بر گروه‌های سری نامرتبط در یک نمودار ترکیبی تأثیری ندارد.

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

از [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) برای تنظیم پر کردن پیش‌فرض یک سری کامل استفاده کنید. اگر یک نقطه قبلاً پر کردن صریح داشته باشد، تنظیم [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) آن، پر کردن سری را برای آن نقطه بازنویسی می‌کند.

مثال زیر یک پر کردن آبی جامد به اولین سری اعمال می‌کند:

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

نام یک سری در کتاب‌کار داده‌های نمودار ذخیره می‌شود و معمولاً در فهرست (legend) نمایش داده می‌شود. در کتاب‌کار پیش‌فرض ساخته‌شده برای یک نمودار ستون خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین سری را شامل می‌شود. ثابت‌های نام‌گذاری شده در مثال زیر این ساختار را صریح می‌سازند:

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

همچنین می‌توانید سلولی که توسط [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--) ارجاع داده شده است به‌روزرسانی کنید. این رویکرد از فرض ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

### **ایجاد یک سری با نامی از چند سلول**

یک نام ترکیبی برای سری زمانی مفید است که نام محصول و دوره گزارش در سلول‌های جداژه کتاب‌کار ذخیره شده باشند. به عنوان مثال، می‌توانید `Product A` در B1 و `2026` در C1 را به یک نام واحد سری ترکیب کنید و هر دو بخش را به سلول‌های مبدأشان مرتبط نگه دارید. از [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) برای بازیابی بازه نام استفاده کنید، سپس آن مجموعه را به [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) پاس دهید. آرگومان `skipHiddenCells` تعیین می‌کند آیا سلول‌های پنهان شامل شوند یا نه: `true` آن‌ها را حذف می‌کند، در حالی که `false` شامل می‌شود. این مثال از `false` برای شامل کردن تمام سلول‌های بازه نام استفاده می‌کند.

مثال زیر یک ارائه با یک سری و دو نقطه داده ایجاد می‌کند. سلول‌های B1:C1 فقط نام سری را فراهم می‌کنند؛ A2:A3 برچسب‌های دسته را فراهم می‌کنند و B2:B3 مقادیر عددی را فراهم می‌کنند.

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

    // این دو سلول نام سری را فراهم می‌کنند.
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

نام سری حاصل `Product A 2026` است، با یک فاصله بین دو مقدار سلولی. فهرست این را به‌عنوان یک ورودی برای هر دو ستون نشان می‌دهد. تصویر زیر نتیجه را نشان می‌دهد:

![نمودار ستونی با مقادیر شمال و جنوب و نام ترکیبی سری Product A 2026 در فهرست](composite_series_name.png)

## **دریافت رنگ پر کردن خودکار سری**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) رنگی را که بر پایه شاخص سری و سبک نمودار به‌صورت عدد صحیح رنگ ARGB اندروید محاسبه می‌شود برمی‌گرداند. این رنگ زمانی استفاده می‌شود که پر کردن سری به‌صورت صریح تعریف نشده باشد. فراخوانی این متد رنگ محاسبه‌شده را می‌خواند؛ هیچ پر کردن جدیدی اختصاص نمی‌دهد.

مثال زیر عدد صحیح رنگ خودکار هر سری پیش‌فرض را چاپ می‌کند:

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

مقادیر صحیح دقیق به سبک و تم نمودار بستگی دارند.

## **تنظیم رنگ معکوس پر برای یک سری نمودار**

برای سری‌های میله، ستون و حباب، [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) می‌تواند مقادیر منفی را با پر رنگ متفاوت نمایش دهد. پر کردن معمولی سری را به جامد تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) اختصاص دهید. اعداد منفی در کتاب‌کار بدون تغییر می‌مانند؛ فقط رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک سری جایگزین می‌کند. ردیف 0 ورق‌کار نام سری را شامل می‌شود، ستون 0 نام‌های دسته را شامل می‌شود و ستون 1 مقادیر را شامل می‌شود:

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

![رنگ پر معکوس جامد](inverted_solid_fill_color.png)

می‌توانید برای یک نقطه معکوس‌سازی را از طریق [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) فعال کنید. در مثال زیر، معکوس‌سازی برای سری غیرفعال و فقط برای نقطه منتخب فعال است. همچنین به نقطه مقدار منفی اختصاص داده می‌شود تا اثر قابل مشاهده باشد:

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

## **پاکسازی مقدار نقطه داده مشخص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول پشتیبان کتاب‌کار آن را به `null` تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را مطابق تنظیمات مقدار خالی نمودار به‌صورت خالی در نظر می‌گیرد.

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

نمودارهای پراکنده از سلول‌های جداگانه X و Y استفاده می‌کنند و نمودارهای حبابی همچنین از یک سلول اندازه استفاده می‌کنند. فقط سلولی که مقدار مورد نظر برای حذف را نمایندگی می‌کند پاک کنید. هنگامیکه می‌خواهید نقاط دیگر را نگه دارید، از فراخوانی [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) خودداری کنید، زیرا این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که مقادیر دارند موردی متفاوت از سلول‌های خالی هستند. برای شامل یا حذف داده‌ها از ردیف‌ها و ستون‌های مخفی ورق‌کار، به [Include Data from Hidden Rows and Columns](/slides/fa/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns) مراجعه کنید.

یک سلول خالی در کتاب‌کار نمایانگر داده‌ی گمشده است؛ یک سلول حاوی `0` نمایانگر مقدار عددی شناخته‌شده است. برای خالی کردن یک سلول، [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) را با `null` صدا بزنید. صفر عددی همچنان صفر می‌ماند، صرف‌نظر از تنظیم خالی‑سلول.

از [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) برای انتخاب نحوه نمایش سلول‌های خالی در نمودار استفاده کنید. این تنظیم بر تمام نمودار اعمال می‌شود. نحوه ترسیم خالی‌ها را تغییر می‌دهد، بدون پر کردن سلول خالی کتاب‌کار با صفر یا مقدار درونیابی‌شده.

مثال زیر خودکفا یک نمودار خطی با یک سری ایجاد می‌کند، مقدار روز 3 را پاک می‌کند و همان نمودار را با هر حالت ذخیره می‌نماید. نیازی به فایل ورودی نیست. [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) از ورق‌کار 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام سری را در خود دارد. داده نهایی `10, 20, empty, 30, 40` است.

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

    // روز ۳ را واقعاً خالی بگذارید، در حالی که دسته‌بندی و نقطه دادهٔ آن را نگه می‌دارید.
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

هر فایل خروجی حالت اختصاص‌یافته قبل از ذخیره‌سازی را ذخیره می‌کند: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیره تنها یک نسخه، حالت دلخواه را اختصاص داده و یک بار ارائه را ذخیره کنید به‌جای تکرار بر روی حالت‌ها.

مقایسه زیر همان داده‌ها را در هر سه فایل نشان می‌دهد. روز 3 در کتاب‌کار در هر حالت خالی است:

![نمودارهای خطی با داده‌های یکسان: Gap خط را در روز 3 قطع می‌کند، Zero خط را به صفر می‌کشاند، و Span روز 2 را به روز 4 متصل می‌کند.](display_blanks_as.png)

اثر قابل مشاهده به نوع نمودار بستگی دارد. یک نمودار خطی مقایسه سه حالت را آسان می‌کند. نمودارهای میله و ستون خطی برای اتصال بین دسته‌های گمشده ندارند، بنابراین `Span` نمی‌تواند بخش اتصال نشان داده‌شده را تولید کند؛ یک ستون گمشده و یک ستون صفر‑ارتفاع می‌توانند مشابه به نظر برسند. به‌طور مشابه، یک نمودار پراکنده فقط با مارکرها خط اتصال ندارد. انتظار نتایج متمایز برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوع مورد استفاده‌تان بررسی کنید.

## **تنظیم عرض فاصله سری**

عرض فاصله فضای بین خوشه‌های میله یا ستون مجاور است که به صورت درصدی از عرض میله یا ستون بیان می‌شود. مانند همپوشانی، به گروه سری والد تعلق دارد نه به یک سری. برای گروه یک‌بار [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) را فراخوانی کنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آنها را متراکم‌تر می‌کند.

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

**کدام انواع نمودار از سری داده‌ها پشتیبانی می‌کنند؟**

تمام انواع نمودارهای نشان‌داده‌شده توسط شمارش [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) از داده‌های نمودار استفاده می‌کنند، اما سری‌های آنها همه ساختار یا تنظیمات مقدار یکسانی ندارند. به عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده از مقادیر X و Y و نمودارهای حبابی از اندازه حباب استفاده می‌کنند. از روش ایجاد نقطه‑داده‌ای که با نوع سری سازگار است استفاده کنید. گزینه‌هایی مانند همپوشانی و عرض فاصله فقط برای گروه‌های میله یا ستون سازگار اعمال می‌شوند.

**گروه سری نمودار چیست؟**

یک [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) شامل سری‌های سازگار است که تنظیمات ترسیم در سطح گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروه دست‌یافته از طریق یک سری لزوماً تمام سری‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه ایجاد شده دارای داده‌های پیش‌فرض است؟**

بله. به‌صورت پیش‌فرض، [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) سری‌ها، دسته‌ها و مقادیر نمونه ایجاد می‌کند. می‌توانید آن سلول‌ها را ویرایش کنید یا هم‌زمان مجموعه سری‌ها و دسته‌ها را قبل از افزودن مجموعه داده کاملاً سفارشی پاک کنید. یک overload نیز می‌تواند نموداری بدون داده پیش‌فرض ایجاد کند.

**چگونه اشیای نمودار به سلول‌های کتاب‌کار متصل می‌شوند؟**

نام‌های سری، برچسب‌های دسته و مقادیر نقاط داده به سلول‌های یک [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‑دیده‌شده عنصر مربوط به نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر سری را هم‌تراز نگه دارید تا هر نقطه زیر دستهٔ موردنظر ترسیم شود.

**چگونه یک نقطه را به‌جای تمام سری پاک کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطه خالی حفظ شود. فقط زمانی که قصد حذف تمام نقاط از آن سری را دارید از [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) استفاده کنید. اگر دسته‌ها را نیز حذف می‌کنید، هر سری را به‌روزرسانی کنید تا مقادیر آنها با مجموعه دسته هم‌تراز بمانند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقداری که از طریق [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) تنظیم شده است بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فواصل، به‌عنوان مقادیر صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که با معنای داده‌های گمشده در ارائهٔ شما منطبق باشد. برای یک مثال کامل و مقایسهٔ بصری، به [Control the Display of Empty Cells](#control-the-display-of-empty-cells) مراجعه کنید.

**مقدارهای منفی چگونه قالب‌بندی می‌شوند؟**

برای سری‌های میله، ستون و حبابی پشتیبانی‌شده، [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) را فراخوانی کنید و رنگ بازگردانده‌شده توسط [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) بازنویسی کنید. این روش‌ها فقط بر قالب‌بندی تأثیر می‌گذارند، نه بر مقادیر عددی ذخیره‌شده.

**کدام قالب‌بندی بر‌تری دارد وقتی هم سری و هم نقطه قالب‌بندی شوند؟**

قالب‌بندی صریح نقطه‑داده برای آن نقطه برتری دارد. نقاط دیگر همچنان از قالب صریح سری یا، زمانی که قالب سری تعریف نشده باشد، از سبک و تم خودکار نمودار استفاده می‌کنند. تنظیمات گروهی مانند همپوشانی و عرض فاصله چیدمان را کنترل می‌کنند و بازنویسی‌های قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد سری‌های موجود در یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه موجود، زمان رندر و قابلیت خواندن نمودار، محدودیتی مفید تعیین می‌کنند.

**چه چیزی را باید تغییر دهم وقتی ستون‌ها بیش از حد نزدیک یا بیش از حد دور هستند؟**

در گروه سری والد مناسب، [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) را فراخوانی کنید. مقدار را افزایش دهید تا فضای بین خوشه‌ها گسترده‌ شود، یا کاهش دهید تا خوشه‌ها به یکدیگر نزدیک‌تر شوند.