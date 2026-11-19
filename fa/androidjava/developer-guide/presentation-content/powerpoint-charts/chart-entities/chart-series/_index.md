---
title: مدیریت سری‌های داده نمودار در ارائه‌ها بر روی Android
linktitle: سری داده‌ها
type: docs
url: /fa/androidjava/chart-series/
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
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه در ارائه‌های Android سری‌های نمودار، نقاط داده، سلول‌های کتاب کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را مدیریت کنید."
---
## **بررسی کلی**

یک نمودار می‌تواند مقادیر رسم‌شده خود را در سلول‌های کتاب کار ذخیره کند یا به‌صورت literals عددی مستقیم. یک [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) نمایانگر یک مجموعه از مقادیر مرتبط است و هر [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) نمایانگر یک نقطه در آن مجموعه است. اشیاء [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی را که بین مجموعه‌ها مشترک است، فراهم می‌کنند. در نمودارهای ایجاد شده با داده‌های پیش‌فرض، نام مجموعه‌ها، دسته‌ها و مقادیر نقاط از اشیاء [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) در کتاب کار نمودار استفاده می‌کنند.

برای یک نمودار دسته‌ای معمولی، کتاب کار پیش‌فرض از ردیف 0 برای نام‌های سری، ستون 0 برای نام‌های دسته و سلول‌های باقی‌مانده برای مقادیر سری استفاده می‌کند. اندیس‌های Worksheet، row و column که به متد [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) پاس داده می‌شوند، صفر‑پایه هستند. این چیدمان زمانی مفید است که نموداری را با داده‌های پیش‌فرض ایجاد می‌کنید، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کتاب کار، سلول‌های ارجاع‌داده‌شده توسط سری‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه حوزه متفاوت هستند:

- تنظیمات سطح سری، مانند [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--)، ظاهر پیش‌فرض برای تمام نقاط یک سری را فراهم می‌کند.
- تنظیمات نقطه‑داده، مانند [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--)، ظاهر سری را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروه بر روی مجموعه‌های سری سازگاری که به یک [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) تعلق دارند، اعمال می‌شود. برای تنظیم گزینه‌هایی مانند overlap یا gap width، از [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) استفاده کنید.

وقتی هیچ پر کردن صریحی برای نقطه یا سری تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم تنظیمات سری و هم نقطه موجود باشد، تنظیمات نقطه برای آن نقطه اولویت دارد.

![chart-series-powerpoint](chart-series-powerpoint.png)

برای یک نمودار سیلندر خوشه‌ای، ببینید چگونه [تغییر نوع سری 3D یا شکل میله](/slides/fa/androidjava/3d-chart/#change-the-3d-series-type-and-bar-shape) بر سری اول تاثیر می‌گذارد.

## **تنظیم مقادیر سری با literals عددی**

از literals عددی هنگامی استفاده کنید که مقادیر سری از داده‌های برنامه یا محاسبات می‌آیند و نیازی به ارجاع به سلول‌های Worksheet ندارند. قبل از اختصاص مقدار برای هر نقطه، متد [setDataSourceTypeForValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) را با مقدار [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/#DoubleLiterals) صدا بزنید و سپس نتیجهٔ [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) هر نقطه را از طریق [setAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-) تنظیم کنید.

تنظیم مجموعه نوع منبع تمام مقادیر نقاط در آن سری را کنترل می‌کند. متد [getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibasechartvalue/#getDataSourceType--) برای هر مقدار نقطه نوع انتخابی را گزارش می‌دهد؛ آن را از طریق تنظیمات مجموعه تغییر دهید. برای دسترسی به سلول ارجاع‌شده با `Worksheet`، از [getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isinglecellchartvalue/#getAsCell--) استفاده کنید. برای `DoubleLiterals`، از [getAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) یا `setAsLiteralDouble` برای خواندن یا نوشتن مستقیم عدد استفاده کنید.

مثال زیر یک نمودار ستونی با سری‌ها و دسته‌های پیش‌فرض ایجاد می‌کند، سپس مقادیر محاسبه‌شده ۱۰، ۲۰ و به‌این‌سابقه را به نقاط موجود اولین سری اختصاص می‌دهد. سپس ارائه را ذخیره، باز می‌کند و مقادیر ذخیره‌شده را چاپ می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals);
    for (int i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IChart reopenedChart = (IChart) reopenedSlide.getShapes().get_Item(0);
    IChartSeries reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (IChartDataPoint point : reopenedSeries.getDataPoints()) {
        System.out.println(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

نوع منبع مقدار نقطه مستقلاً از [IChartData.getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) است که پیکربندی کتاب کار داخلی یا خارجی نمودار را شناسایی می‌کند. استفاده از literals عددی به‌تنهایی کتاب کار توکار را حذف نمی‌کند. در این مثال، کتاب کار برای برچسب‌های دسته، نام‌های سری و سری‌های دیگر در دسترس می‌ماند. برای مدیریت کتاب کار به [Chart Workbook](/slides/fa/androidjava/chart-workbook/) مراجعه کنید.

برای نمودارهای پراکنده و حبابی، از [setDataSourceTypeForXValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) و [setDataSourceTypeForYValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) برای انتخاب منابع [getXValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getXValue--) و [getYValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getYValue--) استفاده کنید. نمودارهای حبابی همچنین از [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) برای [getBubbleSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getBubbleSize--) بهره می‌برند. هر منبع مربوطه را پیش از اختصاص اعداد با متد `setAsLiteralDouble` به `DoubleLiterals` تنظیم کنید.

## **تنظیم overlap سری نمودار**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) گزارش می‌دهد که نوارها یا ستون‌ها در یک نمودار ۲‑بعدی تا چه حد هم‌پوشانی دارند، در بازهٔ ‑۱۰۰ تا ۱۰۰ درصد. این مقدار تنها یک تصویر فقط‑خواندنی از تنظیمات گروه سری والد است. برای به‌روزرسانی همه سری‌های سازگار در آن گروه، از [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) استفاده کنید. این گزینه برای نوع نمودارهایی که نوارها یا ستون‌های گروهی را نشان می‌دهند اعمال می‌شود و بر گروه‌های سری نامرتبط در یک نمودار ترکیبی تأثیری ندارد.

مثال زیر overlap گروهی که شامل اولین سری است را تنظیم می‌کند:

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

![The series overlap](series_overlap.png)

## **تغییر رنگ پر کردن سری**

از [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) برای تنظیم پر کردن پیش‌فرض کل یک سری استفاده کنید. اگر یک نقطه قبلاً پر کردن صریح داشته باشد، تنظیمات [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) آن، پر کردن سری را برای آن نقطه بازنویسی می‌کند.

مثال زیر پر کردن صلب آبی را به اولین سری اعمال می‌کند:

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

## **تغییر نام سری**

نام سری در کتاب کار دادهٔ نمودار ذخیره می‌شود و معمولاً در legend نمایش داده می‌شود. در کتاب کار پیش‌فرض ایجاد شده برای یک نمودار ستونی خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین سری را داراست. ثابت‌های نام‌گذاری در مثال زیر این ساختار را به‌صورت صریح نشان می‌دهند:

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

همچنین می‌توانید سلولی که توسط [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--) ارجاع شده است، به‌روزرسانی کنید. این روش از فرض ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

### **ایجاد سری با نامی از چند سلول**

نام ترکیبی سری زمانی مفید است که نام محصول و دورهٔ گزارش در سلول‌های جداگانه کتاب کار ذخیره شده باشند. به عنوان مثال می‌توانید `Product A` در B1 و `2026` در C1 را به یک نام سری ترکیب کنید در حالی که هر دو بخش به سلول‌های منبع خود مرتبط می‌مانند.

از [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) برای دریافت محدودهٔ نام استفاده کنید، سپس آن مجموعه را به متد [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) پاس دهید. آرگومان `skipHiddenCells` تعیین می‌کند که سلول‌های مخفی گنجانده شوند یا نه: `true` آن‌ها را مستثنی می‌کند، در حالی که `false` شامل می‌کند. این مثال از `false` برای گنجاندن تمام سلول‌های محدودهٔ نام استفاده می‌کند.

مثال زیر یک ارائه با یک سری و دو نقطه داده ایجاد می‌کند. سلول‌های B1:C1 فقط نام سری را فراهم می‌کنند؛ A2:A3 برچسب‌های دسته را، و B2:B3 مقادیر عددی را فراهم می‌کنند.

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

    // این دو سلول نام سری را تأمین می‌کنند.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // سلول‌های جداگانه دسته‌ها و نقاط داده عددی را تأمین می‌کنند.
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

نام سری حاصل `Product A 2026` است که بین دو مقدار سلولی یک فاصله دارد. legend این را به عنوان یک مورد برای هر دو ستون نشان می‌دهد. تصویر زیر نتیجه را نشان می‌دهد:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **دریافت رنگ پر خودکار سری**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) مقدار رنگ ARGB اندروید محاسبه‌شده از اندیس سری و سبک نمودار را برمی‌گرداند. این رنگ زمانی استفاده می‌شود که پر کردن سری صریحاً تعریف نشده باشد. فراخوانی این متد رنگ محاسبه‌شده را می‌خواند؛ رنگ جدیدی را اختصاص نمی‌دهد.

مثال زیر مقدار عددی رنگ خودکار هر سری پیش‌فرض را چاپ می‌کند:

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

مقادیر عددی دقیق بسته به سبک و تم نمودار متفاوت است.

## **تنظیم رنگ پر معکوس برای یک سری نمودار**

برای سری‌های بار، ستون و حباب، می‌توانید با [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) مقادیر منفی را با پر کردن متفاوت نشان دهید. پر کردن معمولی سری را به حالت صلب تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) اختصاص دهید. اعداد منفی در کتاب کار بدون تغییر می‌مانند؛ فقط رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک سری جایگزین می‌کند. ردیف 0 Worksheet نام سری را دارد، ستون 0 نام‌های دسته و ستون 1 مقادیر را در بر دارد:

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

می‌توانید برای یک نقطهٔ خاص معکوس‌سازی را از طریق [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) فعال کنید. در مثال زیر معکوس‌سازی برای سری غیرفعال و فقط برای نقطهٔ انتخاب‌شده فعال می‌شود. همچنین به نقطه مقدار منفی اختصاص می‌دهیم تا اثر قابل مشاهده باشد:

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

## **پاک‌سازی مقدار نقطه دادهٔ خاص**

برای خالی کردن یک نقطه بدون حذف سایر نقاط، سلول کتاب کار مربوطه را به `null` تنظیم کنید. برای یک نمودار ستونی، مقدار رسم‌شده از طریق [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) در دسترس است. نقطه داده همچنان در موقعیت دستهٔ خود باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات خالی‑مقدار نمودار به‌صورت خالی در نظر می‌گیرد.

مثال زیر تنها نقطه دوم سری اول را پاک می‌کند:

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

نمودارهای پراکنده از سلول‌های X و Y جداگانه استفاده می‌کنند و نمودارهای حبابی نیز سلول اندازه دارند. فقط سلولی را که نمایانگر مقداری است که می‌خواهید حذف کنید پاک کنید. هنگام تمایل به حفظ سایر نقاط، از فراخوانی [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) خودداری کنید، زیرا این متد تمام نقاط مجموعه را حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که حاوی مقادیر هستند موردی جدا از سلول‌های خالی هستند. برای گنجاندن یا حذف داده‌ها از ردیف‌ها و ستون‌های مخفی Worksheet، به [Include Data from Hidden Rows and Columns](/slides/fa/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns) مراجعه کنید.

یک سلول خالی کتاب کار نمایانگر دادهٔ گمشده است؛ سلولی که `0` دارد نمایانگر یک مقدار عددی شناخته‌شده است. برای خالی کردن سلول، متد [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) را با `null` فراخوانی کنید. صفر عددی به‌عنوان صفر باقی می‌ماند، صرف‌نظر از تنظیمات سلول خالی.

از [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) برای انتخاب نحوه نمایش سلول‌های خالی استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود و نحوهٔ رسم خالی‌ها را تغییر می‌دهد، بدون این‌که سلول خالی کتاب کار را با صفر یا مقدار درون‌خطی پر کند.

مثال زیر یک نمودار خطی با یک سری ایجاد می‌کند، مقدار روز ۳ را پاک می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. نیازی به فایل ورودی نیست. [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) از Worksheet 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام سری را در خود دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است.

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

    // روز ۳ را واقعاً خالی بگذارید در حالی که دسته و نقطه دادهٔ آن را حفظ می‌کنید.
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

هر فایل خروجی حالت تنظیم‌شده پیش از ذخیره‌سازی را نشان می‌دهد: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ تنها یک نسخه، حالت دلخواه را تنظیم و یک‌بار ارائه را ذخیره کنید.

مقایسهٔ زیر همان داده‌ها را در هر سه فایل نشان می‌دهد. روز ۳ در کتاب کار در هر حالت خالی است:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

اثر قابل مشاهده بسته به نوع نمودار متفاوت است. یک نمودار خطی سه حالت را به‌راحتی مقایسه می‌کند. نمودارهای بار و ستون خطی برای متصل کردن بین دستهٔ گمشده ندارند، بنابراین `Span` نمی‌تواند بخش متصل‌شده را تولید کند؛ یک ستون گمشده و یک ستون صفر‑ارتفاع می‌توانند شبیه هم به‌نظر برسند. به‌طور مشابه، یک نمودار پراکندهٔ فقط با نشانگرها خطی برای اتصال ندارد. انتظار نتایج سه‌گانهٔ متمایز برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوع استفاده‌شده بررسی کنید.

## **تنظیم عرض فاصلهٔ سری**

عرض فاصله (gap width) فضای بین خوشه‌های میله یا ستون مجاور است که به‌صورت درصدی از عرض میله یا ستون بیان می‌شود. مانند overlap، این تنظیم متعلق به گروه سری والد است نه به یک سری منفرد. یک بار متد [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) را برای گروه صدا بزنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچک‌تر آن‌ها را متراکم‌تر می‌سازد.

مثال زیر عرض فاصله را تغییر داده و تنها ارائهٔ نهایی را ذخیره می‌کند:

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

## **نمایش یا مخفی‌سازی خطوط سری**

خطوط سری بخش‌های مرتبط یک نمودار را به‌صورت بصری به هم وصل می‌کند. برای نمایش یا مخفی‌سازی آن‌ها در نمودارهای پشته‌ای بار و OfPie پشتیبانی‌شده، از [IChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSeriesLines-boolean-) استفاده کنید. در نمودارهای پشته‌ای دو‑بعدی بار و ستون، این خطوط مرزهای پشتهٔ متناظر را در میان دسته‌ها متصل می‌کنند. در نمودارهای Pie of Pie و Bar of Pie، این خطوط نمودار اصلی را به نمودار ثانویه وصل می‌کنند. این تنظیم یک اتصال عمومی برای سایر انواع نمودار نیست.

گروه را از طریق [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) دسترسی پیدا کنید. این تنظیم برای هر سری در آن گروه اعمال می‌شود. [IChartSeries.hasSeriesLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#hasSeriesLines--) فقط‑خواندنی است و تنظیمات گروه والد را منعکس می‌کند؛ برای به‌روزرسانی از متد setter گروه استفاده کنید.

مثال زیر یک نمودار [PieOfPie](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#PieOfPie) با داده‌های پیش‌فرض ایجاد می‌کند. همان نمودار را ابتدا با خطوط سری فعال و سپس غیرفعال ذخیره می‌کند تا دو ارائه برای مقایسه تولید شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();

    seriesGroup.setSeriesLines(true);
    presentation.save("series_lines_enabled.pptx", SaveFormat.Pptx);

    seriesGroup.setSeriesLines(false);
    presentation.save("series_lines_disabled.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| خطوط سری فعال | خطوط سری غیرفعال |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| دو خط اصلی پای را به پای ثانویه متصل می‌کنند. | هر دو پای قابل مشاهده‌اند، اما خطوط اتصال مخفی هستند. |

خطوط سری با خطوط راهنمای برچسب داده، که برچسب‌ها را به نقاط داده متصل می‌کند؛ خطوط شبکه، که بازه‌های محورهای نمودار را نشان می‌دهند؛ و خطوط در یک نمودار خطی، که مقادیر داده را نشان می‌دهند، متفاوت است. این تنظیم آن‌ها را کنترل نمی‌کند.

## **سوالات متداول**

**کدام نوع نمودارها از داده‌های سری پشتیبانی می‌کنند؟**

همهٔ نوع‌های نموداری که توسط شمارندهٔ [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) تعریف شده‌اند از داده‌های نمودار استفاده می‌کنند، اما سری‌های آن‌ها ساختار مقدار یا تنظیمات یکسانی ندارند. به‌عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده از مقادیر X و Y، و نمودارهای حبابی از اندازهٔ حباب‌ها بهره می‌برند. از متد ایجاد نقطه‑دادهٔ متناسب با نوع سری استفاده کنید. گزینه‌هایی نظیر overlap و gap width فقط برای گروه‌های بار یا ستون سازگار اعمال می‌شوند.

**گروه سری نمودار چیست؟**

[IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) شامل سری‌های سازگاری است که تنظیمات رسم سطح‑گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک سری دسترسی می‌شود، لزوماً تمام سری‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه‑ساخته داده‌های پیش‌فرض دارد؟**

بله. به‌صورت پیش‌فرض، [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) سری‌ها، دسته‌ها و مقادیر نمونه ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن یک مجموعه دادهٔ کاملاً سفارشی، هر دو مجموعه سری و دسته را پاک کنید. یک overload نیز می‌تواند نموداری بدون داده پیش‌فرض ایجاد کند.

**نمودارها چگونه به سلول‌های کتاب کار متصل می‌شوند؟**

نام‌های سری، برچسب‌های دسته و مقادیر نقاط داده به سلول‌های یک [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده، عنصر متناظر نمودار را به‌روزرسانی می‌کند. هنگام ساخت دادهٔ سفارشی، ردیف‌های دسته و ردیف‌های مقادیر سری را هم‌راستا نگه دارید تا هر نقطه زیر دستهٔ موردنظر رسم شود.

**چگونه یک نقطه را به‌جای سری کامل پاک کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان یک نقطهٔ خالی حفظ شود. از [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) فقط زمانی استفاده کنید که قصد حذف همهٔ نقاط آن سری را داشته باشید، زیرا این متد تمام نقاط مجموعه را حذف می‌کند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقداری که از طریق [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) تنظیم می‌شود، بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فاصله، مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که معنای دادهٔ گمشده را در ارائهٔ شما منعکس کند. برای مثال کامل و مقایسهٔ تصویری به بخش [Control the Display of Empty Cells](#control-the-display-of-empty-cells) مراجعه کنید.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای سری‌های بار، ستون و حباب پشتیبانی‌شده، متد [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) را فراخوانی کنید و رنگی که از [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) برمی‌گردد، تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ جداگانه با [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) بازنویسی کنید. این روش‌ها قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**وقتی هم سری و هم نقطه قالب‌بندی شوند، کدام برنده می‌شود؟**

قالب‌بندی صریح نقطه‑داده برای آن نقطه اولویت دارد. سایر نقاط همچنان از قالب‌بندی صریح سری استفاده می‌کنند یا، اگر قالب‌بندی سری تعریف نشده باشد، از سبک و تم خودکار نمودار. تنظیمات گروهی مانند overlap و gap width مربوط به چیدمان هستند و به‌عنوان بازنویسی سطح نقطه اعمال نمی‌شوند.

**آیا محدودیتی برای تعداد سری‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیتی ثابت برای تعداد سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان رندر و خوانایی نمودار تعیین‌کنندهٔ حد مفید هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها بیش از حد نزدیک یا دور از یکدیگر هستند؟**

متد [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) را بر روی گروه سری والد مناسب صدا بزنید. مقدار را افزایش دهید تا فضای بین خوشه‌ها گسترده‌تر شود یا کاهش دهید تا خوشه‌ها به‌یکدیگر نزدیک‌تر شوند.