---
title: مدیریت داده‌های سری نمودار در ارائه‌ها در اندروید
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
description: "یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های کتاب کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها در اندروید مدیریت کنید."
---
## **نمای کلی**

یک نمودار می‌تواند مقادیر ترسیم‌شده خود را در سلول‌های کتاب کار یا به‌صورت مستقیم به‌عنوان عددهای ثابت ذخیره کند. یک [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) یک مجموعه از مقادیر مرتبط را نمایندگی می‌کند و هر [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) یک نقطه در آن مجموعه را نشان می‌دهد. اشیاء [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین مجموعه‌ها را فراهم می‌کنند. در نمودارهایی که با داده‌های پیش‌فرض ایجاد می‌شوند، نام‌های مجموعه‌ها، دسته‌ها و مقادیر نقاط از اشیاء [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) موجود در کتاب کار نمودار استفاده می‌کنند.

برای یک نمودار دسته‌ای معمولی، کتاب کار پیش‌فرض از ردیف 0 برای نام‌های مجموعه، ستون 0 برای نام‌های دسته و بقیه سلول‌ها برای مقادیر مجموعه‌ها استفاده می‌کند. شاخص‌های worksheet، ردیف و ستون که به [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) پاس داده می‌شوند، به‌صورت صفر‑مبنا هستند. این چیدمان هنگام ایجاد نمودار با داده‌های پیش‌فرض مفید است، اما فرض نکنید که همه نمودارهای موجود از آن استفاده می‌کنند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کتاب کار، سلول‌های مرجع توسط مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه حوزه مختلف هستند:

- تنظیمات سطح مجموعه، مانند [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--)، ظاهر پیش‌فرض برای تمام نقاط در یک مجموعه را فراهم می‌کند.
- تنظیمات نقطه داده، مانند [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--)، ظاهر مجموعه را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی بر روی مجموعه‌های سازگار که به همان [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) تعلق دارند اعمال می‌شود. برای تنظیم گزینه‌هایی مانند پوشش یا عرض فاصله، از [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) برای دسترسی به گروه استفاده کنید.

هنگامی که پر کردن صریح برای نقطه یا مجموعه تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هر دو قالب‌بندی مجموعه و نقطه وجود داشته باشد، قالب‌بندی نقطه برای آن نقطه اولویت دارد.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تنظیم مقادیر مجموعه با استفاده از عددهای ثابت**

از عددهای ثابت استفاده کنید وقتی مقادیر مجموعه از داده‌های برنامه یا محاسبات می‌آیند و نیازی به ارجاع به سلول‌های worksheet ندارند. قبل از اختصاص نتیجه‌ی [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) هر نقطه، متد [setDataSourceTypeForValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) را با [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/#DoubleLiterals) فراخوانی کنید و سپس از [setAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-) استفاده کنید.

تنظیم مجموعه منبع تمام مقادیر نقطه در آن مجموعه را کنترل می‌کند. روش [getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibasechartvalue/#getDataSourceType--) هر مقدار نقطه نوع انتخاب‌شده را گزارش می‌دهد؛ آن را از طریق تنظیم مجموعه تغییر دهید. با `Worksheet` از [getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isinglecellchartvalue/#getAsCell--) برای دسترسی به سلول مرجع استفاده کنید. با `DoubleLiterals` از [getAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) یا `setAsLiteralDouble` برای خواندن یا نوشتن مستقیم عدد استفاده کنید.

مثال زیر یک نمودار ستونی با مجموعه‌ها و دسته‌های پیش‌فرض ایجاد می‌کند، سپس مقادیر محاسبه‌شده 10، 20 و ... را به نقاط موجود اولین مجموعه اختصاص می‌دهد. سپس ارائه را ذخیره، باز می‌کند و مقادیر ذخیره‌شده را چاپ می‌کند.

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

منبع نوع مقدار نقطه جدا از [IChartData.getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) است که پیکربندی کتاب کار داخلی یا خارجی نمودار را شناسایی می‌کند. استفاده از عددهای ثابت به‌تنهایی کتاب کار توکار را حذف نمی‌کند. در این مثال، کتاب کار برای برچسب‌های دسته، نام‌های مجموعه و سایر مجموعه‌ها در دسترس باقی می‌ماند. برای مدیریت کتاب کار، به [Chart Workbook](/slides/fa/androidjava/chart-workbook/) مراجعه کنید.

برای نمودارهای پراکندگی و حبابی، از [setDataSourceTypeForXValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) و [setDataSourceTypeForYValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) برای انتخاب منابع [getXValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getXValue--) و [getYValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getYValue--) استفاده کنید. نمودارهای حبابی همچنین از [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) برای [getBubbleSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getBubbleSize--) بهره می‌برند. هر منبع قابل اعمال را قبل از اختصاص اعداد از طریق متد `setAsLiteralDouble` آن مقدار، به `DoubleLiterals` تنظیم کنید.

## **تنظیم پوشش مجموعه نمودار**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) مقدار پوشش نوارها یا ستون‌ها را در یک نمودار 2D از -100 تا 100 درصد گزارش می‌کند. این یک پیش‌بینی فقط‑خواندنی از تنظیمات در گروه والد مجموعه است. برای به‌روزرسانی تمام مجموعه‌های سازگار در آن گروه، از [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) استفاده کنید. این گزینه بر انواع نمودارهایی که نوارهای گروهی یا ستون‌های گروهی را نمایش می‌دهند اعمال می‌شود؛ بر گروه‌های مجموعه نامرتبط در نمودار ترکیبی تأثیری ندارد.

مثال زیر پوشش گروهی که شامل اولین مجموعه است را تنظیم می‌کند:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // نمودار جدید شامل مجموعه‌های نمونه، دسته‌بندی‌ها و مقادیر است.
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

## **تغییر رنگ پر کردن مجموعه**

از [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) برای تنظیم پر کردن پیش‌فرض یک مجموعه به‌صورت کلی استفاده کنید. اگر نقطه‌ای قبلاً پر کردن صریح داشته باشد، تنظیم [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) آن، پر کردن مجموعه را برای آن نقطه بازنویسی می‌کند.

مثال زیر یک پر کردن صاف آبی را به اولین مجموعه اعمال می‌کند:

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

نام یک مجموعه در کتاب کار داده‌های نمودار ذخیره می‌شود و عموماً در راهنما نمایش داده می‌شود. در کتاب کار پیش‌فرض ایجاد شده برای یک نمودار ستونی خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین مجموعه را شامل می‌شود. ثابت‌های نام‌گذاری در مثال زیر این ساختار را آشکار می‌سازند:

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

همچنین می‌توانید سلولی که توسط [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--) ارجاع داده شده است را به‌روزرسانی کنید. این روش از فرض ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

### **ایجاد مجموعه‌ای با نام ترکیبی از چند سلول**

نام ترکیبی مجموعه زمانی مفید است که نام محصول و دوره گزارش در سلول‌های جداگانه کتاب کار ذخیره شوند. برای مثال می‌توانید `Product A` در B1 و `2026` در C1 را به یک نام مجموعه ترکیب کنید در حالی که هر دو بخشی به سلول‌های منبع خود پیوند دارند.

از [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) برای دریافت بازه نام استفاده کنید، سپس آن مجموعه را به [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) پاس دهید. آرگومان `skipHiddenCells` تعیین می‌کند که آیا سلول‌های مخفی گنجانده شوند یا نه: `true` آن‌ها را حذف می‌کند، در حالی که `false` آن‌ها را شامل می‌شود. این مثال از `false` برای شامل‌کردن تمام سلول‌ها در بازه نام استفاده می‌کند.

مثال زیر یک ارائه با یک مجموعه و دو نقطه داده ایجاد می‌کند. سلول‌های B1:C1 فقط نام مجموعه را تامین می‌کنند؛ A2:A3 برچسب‌های دسته را تامین می‌کنند و B2:B3 مقادیر عددی را.

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

    // این دو سلول نام سری را تامین می‌کنند.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // سلول‌های جداگانه دسته‌ها و نقاط داده عددی را تامین می‌کنند.
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

نام مجموعه حاصل `Product A 2026` است، با یک فاصله بین دو مقدار سلولی. راهنما این را به‌عنوان یک ورودی برای هر دو ستون نمایش می‌دهد. تصویر زیر نتیجه را نشان می‌دهد:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **دریافت رنگ پر کردن خودکار مجموعه**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) رنگ محاسبه‌شده بر پایه اندیس مجموعه و سبک نمودار را به‌صورت عدد صحیح ARGB اندروید برمی‌گرداند. این همان رنگی است که وقتی پر کردن مجموعه به‌صورت صریح تعریف نشده باشد استفاده می‌شود. فراخوانی متد فقط رنگ محاسبه‌شده را می‌خواند؛ هیچ پر کردن جدیدی تعیین نمی‌کند.

مثال زیر رنگ عددی خودکار هر مجموعه پیش‌فرض را چاپ می‌کند:

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

مقادیر صحیح دقیق به سبک و تم نمودار بستگی دارد.

## **تنظیم رنگ پر کردن معکوس برای یک مجموعه نمودار**

برای مجموعه‌های نوار، ستون و حباب، می‌توانید با استفاده از [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) مقادیر منفی را با پر کردن متفاوت نمایش دهید. پر کردن معمولی مجموعه را به‌صورت ثابت تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ منفی را از طریق [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) اختصاص دهید. اعداد منفی در کتاب کار بدون تغییر می‌مانند؛ فقط رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف 0 worksheet نام مجموعه را دارد، ستون 0 نام‌های دسته و ستون 1 مقادیر را دارد:

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

می‌توانید برای یک نقطه معکوس‌سازی را از طریق [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) فعال کنید. در مثال زیر معکوس‌سازی برای مجموعه غیرفعال و تنها برای نقطه انتخاب‌شده فعال است. این نقطه همچنین مقدار منفی دریافت می‌کند تا اثر قابل مشاهده باشد:

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

## **پاک کردن مقدار یک نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول پشتیبان کتاب کار آن را به `null` تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را به‌عنوان خالی طبق تنظیمات مقدار خالی نمودار در نظر می‌گیرد.

مثال زیر تنها نقطه دوم در اولین مجموعه را پاک می‌کند:

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

نمودارهای پراکندگی از سلول‌های جداگانه X و Y استفاده می‌کنند و نمودارهای حبابی نیز از سلول اندازه بهره می‌برند. تنها سلولی را که نمایانگر مقدار مورد نظر برای حذف است پاک کنید. هنگامیکه می‌خواهید نقاط دیگر را نگه دارید، از [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) استفاده نکنید، زیرا این متد تمام نقاط را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که مقداری دارند مورد متفاوتی نسبت به سلول‌های خالی هستند. برای شامل یا حذف داده‌ها از ردیف‌ها و ستون‌های مخفی worksheet، به [Include Data from Hidden Rows and Columns](/slides/fa/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns) مراجعه کنید.

یک سلول کتاب کار خالی نمایانگر داده‌های مفقودی است؛ سلولی که `0` داشته باشد نمایانگر مقدار عددی شناخته‌شده است. برای خالی کردن یک سلول، متد [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) را با `null` صدا بزنید. صفر عددی همچنان صفر می‌ماند صرف‌نظر از تنظیمات سلول خالی.

از [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) برای انتخاب نحوه نمایش سلول‌های خالی در کل نمودار استفاده کنید. این تنظیم برای تمام نمودار اعمال می‌شود و نحوه ترسیم خالی‌ها را تغییر می‌دهد، بدون اینکه سلول کتاب کار خالی را به صفر یا مقدار درونیابی تبدیل کند.

مثال خودکفا زیر یک نمودار خطی با یک مجموعه ایجاد می‌کند، مقدار روز 3 را خالی می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. نیازی به فایل ورودی نیست. [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) از worksheet 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام مجموعه را دارد. داده نهایی `10, 20, empty, 30, 40` است.

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

    // روز 3 را واقعاً خالی بگذارید، در حالی که دسته‌بندی و نقطه داده آن را نگه می‌دارید.
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

هر فایل خروجی حالت اختصاص‌یافته قبل از ذخیره‌سازی را ذخیره می‌کند: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیره فقط یک نسخه، حالت دلخواه را تعیین کنید و یک بار ارائه را ذخیره کنید به‌جای تکرار برای هر حالت.

مقایسه زیر همان داده را در هر سه فایل نشان می‌دهد. روز 3 در کتاب کار در همه موارد خالی است:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

اثر قابل مشاهده به نوع نمودار بستگی دارد. یک نمودار خطی هر سه حالت را به راحتی قابل مقایسه می‌کند. نمودارهای نوار و ستونی خطی برای اتصال بین دسته‌های مفقود ندارند، بنابراین `Span` نمی‌تواند بخش متصل‑شدهٔ بالا را ایجاد کند؛ یک ستون مفقود و یک ستون با ارتفاع صفر نیز می‌توانند مشابه به نظر برسند. به‌طور مشابه، یک نمودار پراکندگی فقط با نشانگرها خط اتصال ندارد. انتظار نتایج سه‌گانه متمایز برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض فاصله مجموعه**

عرض فاصله فاصله بین خوشه‌های نوار یا ستون مجاور است که به‌صورت درصدی از عرض نوار یا ستون بیان می‌شود. مشابه پوشش، این تنظیم به گروه والد مجموعه تعلق دارد نه به یک مجموعه منفرد. کافی است یک بار برای گروه، متد [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) را صدا بزنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آن‌ها را متراکم‌تر می‌سازد.

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

![The gap width](gap_width.png)

## **پرسش‌های متداول**

**کدام انواع نمودار از سری‌های داده پشتیبانی می‌کنند؟**

تمام انواع نمودارهای تعریف‌شده توسط شمارش‌گر [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) از داده‌های نمودار استفاده می‌کنند، اما ساختار یا تنظیمات مقادیر برای هر سری یکسان نیست. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکندگی از مقادیر X و Y، و نمودارهای حبابی اندازه حباب را به‌علاوه دارند. از روش ایجاد نقطه داده‌ای که با نوع سری‌تان مطابقت دارد استفاده کنید. گزینه‌هایی مانند پوشش و عرض فاصله فقط برای گروه‌های نوار یا ستون سازگار اعمال می‌شود.

**یک گروه سری نمودار چیست؟**

[IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) شامل سری‌های سازگاری است که تنظیمات رسم سطح‑گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک سری دسترسی پیدا می‌کنید لزوماً همه سری‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه‑ساخته‌شده شامل داده‌های پیش‌فرض است؟**

بله. به‌صورت پیش‌فرض، [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) نمونه‌ای از سری‌ها، دسته‌ها و مقادیر ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعه داده‌ای کاملاً سفارشی، هر دو مجموعه سری و دسته را پاک کنید. یک overload نیز می‌تواند نموداری بدون داده پیش‌فرض ایجاد کند.

**چگونه اشیاء نمودار به سلول‌های کتاب کار مرتبط می‌شوند؟**

نام‌های سری، برچسب‌های دسته و مقادیر نقطه داده به سلول‌های یک [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول مرجع، عنصر مربوط به نمودار را به‌روزرسانی می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر سری را هم‌راستا نگه دارید تا هر نقطه تحت دستهٔ موردنظر ترسیم شود.

**چگونه یک نقطه را به‌جای کل سری پاک کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دسته نقطه به‌عنوان نقطه خالی حفظ شود. از [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) فقط وقتی که قصد حذف تمام نقاط از آن سری را دارید استفاده کنید. اگر دسته‌ها را نیز حذف می‌کنید، همه سری‌ها را طوری به‌روزرسانی کنید که مقادیرشان با مجموعه دسته‌ها هم‌راستا بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقدار تنظیم‌شده توسط [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فاصله، به‌صورت مقدار صفر یا با اتصال نقاط مجاور نمایش دهند. تنظیمی را انتخاب کنید که با معنای داده‌های مفقود در ارائهٔ شما همخوانی داشته باشد. برای مثال کامل و مقایسهٔ بصری، به [Control the Display of Empty Cells](#control-the-display-of-empty-cells) مراجعه کنید.

**مقدارهای منفی چگونه قالب‌بندی می‌شوند؟**

برای سری‌های نوار، ستون و حباب پشتیبانی‌شده، متد [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) را فراخوانی کنید و رنگی که توسط [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) بازگردانده می‌شود را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) بازنویسی کنید. این متدها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**کدام قالب‌بندی برنده است وقتی هم سری و هم نقطه قالب‌بندی شده باشند؟**

قالب‌بندی صریح نقطه داده برای آن نقطه اولویت دارد. سایر نقاط به‌صورت پیش‌فرض از قالب‌بندی صریح سری یا، وقتی قالب‌بندی سری تعریف نشده باشد، از سبک و تم خودکار نمودار استفاده می‌کنند. تنظیمات گروهی مانند پوشش و عرض فاصله فقط طرح‌بندی را کنترل می‌کنند و بازنویسی قالب‌بندی در سطح نقطه نیستند.

**آیا محدودیتی برای تعداد سری‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان رندر و خوانایی نمودار تعیین‌کنندهٔ حد قابل استفاده هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها خیلی نزدیک یا خیلی دور از هم هستند؟**

متد [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) را بر روی گروه والد مناسب صدا بزنید. مقدار را افزایش دهید تا فضای بین خوشه‌ها گسترده‌تر شود یا کاهش دهید تا خوشه‌ها به هم نزدیک‌تر شوند.