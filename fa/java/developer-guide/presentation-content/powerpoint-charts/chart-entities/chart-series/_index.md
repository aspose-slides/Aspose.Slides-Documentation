---
title: مدیریت سری‌های دادهٔ نمودار در ارائه‌ها با Java
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
description: "نحوه مدیریت سری‌های نمودار، نقاط داده، سلول‌های کتاب‌کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی در ارائه‌ها با Java را بیاموزید."
---
## **مروری**

یک نمودار می‌تواند مقادیر ترسیم‌شده خود را در سلول‌های کتاب کار یا به‌صورت literals عددی مستقیم ذخیره کند. یک [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) یک مجموعه از مقادیر مرتبط را نشان می‌دهد و هر [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) یک نقطه در آن مجموعه است. اشیاء [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین مجموعه‌ها را فراهم می‌کنند. در نمودارهایی که با داده‌های پیش‌فرض ایجاد می‌شوند، نام‌های مجموعه، دسته‌ها و مقادیر نقاط از اشیاء [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) کتاب کار نمودار استفاده می‌کند.

برای یک نمودار دسته‌ای معمول، کتاب کار پیش‌فرض ردیف 0 را برای نام‌های مجموعه، ستون 0 را برای نام‌های دسته و بقیه سلول‌ها را برای مقادیر مجموعه استفاده می‌کند. شاخص‌های Worksheet، row و column که به [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) پاس داده می‌شوند، مبتنی بر شمارش صفر هستند. این چیدمان هنگام ساخت نمودار با داده‌های پیش‌فرض مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کتاب کار، سلول‌های ارجاع داده‌شده توسط مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه محدوده متفاوت هستند:

- تنظیمات در سطح مجموعه، مانند [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--)، ظاهر پیش‌فرض تمام نقاط یک مجموعه را فراهم می‌کند.
- تنظیمات در سطح نقطه داده، مانند [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--)، ظاهر مجموعه را برای یک نقطه خاص بازنویسی می‌کند.
- تنظیمات گروهی بر روی مجموعه‌های سازگاری که به همان [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) تعلق دارند اعمال می‌شود. برای تنظیم گزینه‌هایی مانند overlap یا gap width، گروه را از طریق [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) دریافت کنید.

اگر پرشدن نقطه یا مجموعه به‌صورت صریح تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم تنظیمات مجموعه و هم نقطه موجود باشد، تنظیمات نقطه بر آن نقطه اولویت دارد.

![chart-series-powerpoint](chart-series-powerpoint.png)

برای یک نمودار استوانه‌ای خوشه‌ای، نحوهٔ تأثیر [changing the 3D series type or bar shape](/slides/fa/java/3d-chart/#change-the-3d-series-type-and-bar-shape) بر اولین مجموعه را ببینید.

## **تنظیم مقادیر مجموعه با literals عددی**

از literals عددی زمانی استفاده کنید که مقادیر مجموعه از داده‌های برنامه یا محاسبات حاصل می‌شوند و نیازی به ارجاع به سلول‌های Worksheet ندارند. قبل از اختصاص نتیجهٔ هر نقطه با [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) از طریق [setAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-)، [setDataSourceTypeForValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) را با [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/#DoubleLiterals) فراخوانی کنید.

این تنظیم کلی منبع نوع تمام مقادیر نقطه‌ها در آن مجموعه را کنترل می‌کند. متد [getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ibasechartvalue/#getDataSourceType--) هر نقطه نوع انتخابی را گزارش می‌دهد؛ آن را از طریق تنظیم کلی تغییر دهید. با `Worksheet`، برای دسترسی به سلول ارجاع‌شده از [getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/isinglecellchartvalue/#getAsCell--) استفاده کنید. با `DoubleLiterals`، برای خواندن یا نوشتن مستقیم عدد از [getAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) یا `setAsLiteralDouble` استفاده کنید.

مثال زیر یک نمودار ستونی با مجموعه‌ها و دسته‌های پیش‌فرض ایجاد می‌کند، سپس مقادیر محاسبه‌شدهٔ ۱۰، ۲۰ و غیره را به نقاط موجود اولین مجموعه اختصاص می‌دهد. پس از ذخیرهٔ ارائه، آن را دوباره باز می‌کند و مقادیر ذخیره‌شده را چاپ می‌کند.

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

نوع منبع مقدار نقطه جدا از [IChartData.getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getDataSourceType--) است که پیکربندی کتاب کار داخلی یا خارجی نمودار را شناسایی می‌کند. استفاده از literals عددی به‌تنهایی کتاب کار جاسازی‌شده را حذف نمی‌کند. در این مثال، کتاب کار برای برچسب‌های دسته، نام‌های مجموعه و سایر مجموعه‌ها در دسترس باقی می‌ماند. برای مدیریت کتاب کار، به [Chart Workbook](/slides/fa/java/chart-workbook/) مراجعه کنید.

برای نمودارهای پراکندگی و حباب، از [setDataSourceTypeForXValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) و [setDataSourceTypeForYValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) برای انتخاب منبع‌های [getXValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getXValue--) و [getYValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getYValue--) استفاده کنید. نمودارهای حباب همچنین از [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) برای [getBubbleSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getBubbleSize--) بهره می‌برند. هر منبع مربوطه را قبل از اختصاص عدد به `setAsLiteralDouble` آن مقدار، به `DoubleLiterals` تنظیم کنید.

## **تنظیم Overlap مجموعه نمودار**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) مقدار هم‌پوشانی میله‌ها یا ستون‌ها را در یک نمودار ۲بعدی، از -۱۰۰ تا ۱۰۰ درصد، گزارش می‌کند. این یک پیش‌بینی فقط‑خواندنی از تنظیمات گروه والد است. برای به‌روزرسانی همهٔ مجموعه‌های سازگار در آن گروه، از [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) استفاده کنید. این گزینه تنها به انواع نمودارهایی که میله‌ها یا ستون‌های گروهی نشان می‌دهند اعمال می‌شود؛ بر گروه‌های مجموعه نامرتبط در یک نمودار ترکیبی تأثیری ندارد.

مثال زیر overlap گروهی که شامل اولین مجموعه است تنظیم می‌کند:

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

## **تغییر رنگ پر کردن مجموعه**

از [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) برای تنظیم پر کردن پیش‌فرض یک مجموعه کامل استفاده کنید. اگر یک نقطه قبلاً پر شدن صریح داشته باشد، تنظیم [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) آن، پر کردن مجموعه را برای آن نقطه بازنویسی می‌کند.

مثال زیر پر کردن آبی جامد را به اولین مجموعه اعمال می‌کند:

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

![The color of the series](series_color.png)

## **تغییر نام مجموعه**

نام مجموعه در کتاب کار داده‌های نمودار ذخیره می‌شود و معمولاً در legend نمایش داده می‌شود. در کتاب کار پیش‌فرض یک نمودار ستونی خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین مجموعه را دارد. ثابت‌های نام‌دار در مثال زیر این ساختار را واضح می‌کند:

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

می‌توانید سلولی که توسط [IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--) ارجاع شده است نیز به‌روزرسانی کنید. این روش از فرض ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

### **ایجاد مجموعه‌ای با نام از چندین سلول**

یک نام مجموعه ترکیبی زمانی مفید است که نام محصول و دورهٔ گزارش در سلول‌های جداگانه کتاب کار ذخیره شوند. به عنوان مثال می‌توانید `Product A` در B1 و `2026` در C1 را به یک نام مجموعه ترکیب کنید در حالی که هر دو قسمت به سلول منبع خود لینک شده‌اند.

از [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) برای دریافت محدودهٔ نام استفاده کنید، سپس آن مجموعه را به [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) پاس دهید. آرگومان `skipHiddenCells` تعیین می‌کند که آیا سلول‌های مخفی شامل شوند یا نه: `true` آنها را حذف می‌کند، در حالی که `false` شامل می‌شود. این مثال از `false` برای شامل کردن همهٔ سلول‌های محدودهٔ نام استفاده می‌کند.

مثال زیر یک ارائه با یک مجموعه و دو نقطه داده ایجاد می‌کند. سلول‌های B1:C1 فقط نام مجموعه را فراهم می‌کنند؛ A2:A3 برچسب‌های دسته را فراهم می‌کنند و B2:B3 مقادیر عددی را فراهم می‌کنند.

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

    // این دو سلول نام مجموعه را فراهم می‌کنند.
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

نام مجموعهٔ حاصل `Product A 2026` است، با یک فاصله بین دو مقدار سلولی. legend این را به‌عنوان یک ورودی برای هر دو ستون نمایش می‌دهد. تصویر زیر نتیجه را نشان می‌دهد:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **دریافت رنگ پر خودکار مجموعه**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) رنگی را بر می‌گرداند که از ایندکس مجموعه و سبک نمودار محاسبه می‌شود. این رنگ زمانی استفاده می‌شود که پر کردن مجموعه صریحاً تعریف نشده باشد. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند و پر جدیدی اختصاص نمی‌دهد.

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

رنگ‌های دقیق به سبک و تم نمودار وابسته‌اند.

## **تنظیم رنگ پر معکوس برای مجموعه نمودار**

برای مجموعه‌های میله، ستون و حباب، می‌توانید با [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) مقادیر منفی را با پر متفاوتی نمایش دهید. پر معمولی مجموعه را به حالت جامد تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ منفی را از طریق [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) اختصاص دهید. اعداد منفی در کتاب کار تغییر نمی‌کنند؛ تنها رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف 0 کتاب کار نام مجموعه را دارد، ستون 0 نام‌های دسته و ستون 1 مقادیر را دارد:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

می‌توانید برای یک نقطه خاص با [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) معکوس‌سازی را فعال کنید. در مثال زیر معکوس‌سازی برای مجموعه غیرفعال و فقط برای نقطهٔ انتخاب‌شده فعال می‌شود. همان نقطه نیز مقدار منفی دریافت می‌کند تا اثر قابل مشاهده باشد:

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

## **پاک کردن مقدار یک نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف بقیهٔ نقاط، سلول کتاب کار پشتیبان آن را به `null` تنظیم کنید. در یک نمودار ستونی، مقدار ترسیم‌شده از طریق [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات خالی‌بودن نمودار به‌عنوان خالی در نظر می‌گیرد.

مثال زیر فقط نقطه دوم مجموعهٔ اول را پاک می‌کند:

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

نمودارهای پراکندگی از سلول‌های X و Y جداگانه استفاده می‌کنند و نمودارهای حباب نیز یک سلول اندازه دارند. فقط سلولی که نشانگر مقدار مورد نظر شماست را پاک کنید. برای حذف همهٔ نقاط از یک مجموعه، متد [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) را صدا بزنید؛ این متد تمام نقاط را حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که مقدار دارند موردی متفاوت از سلول‌های خالی هستند. برای شامل یا حذف داده‌ها از ردیف‌ها و ستون‌های مخفی Worksheet، به [Include Data from Hidden Rows and Columns](/slides/fa/java/chart-workbook/#include-data-from-hidden-rows-and-columns) مراجعه کنید.

یک سلول خالی کتاب کار نشان‌دهندهٔ دادهٔ گمشده است؛ یک سلول حاوی `0` نشان‌دهندهٔ مقدار عددی شناخته‌شده است. برای خالی کردن سلول، با `null` به [IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) فراخوانی کنید. عدد صفر عددی صفر باقی می‌ماند چه تنظیم خالی‌سلول چه باشد.

از [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) برای انتخاب نحوهٔ نمایش سلول‌های خالی در کل نمودار استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود و نحوهٔ ترسیم خالی‌ها را بدون پر کردن سلول خالی با صفر یا مقدار درونی‌سازی‌ شده تغییر می‌دهد.

مثال زیر خودکفا یک نمودار خطی با یک مجموعه ایجاد می‌کند، مقدار روز ۳ را پاک می‌کند و هر حالت را ذخیره می‌کند. نیازی به فایل ورودی نیست. [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) از Worksheet 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام مجموعه را دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است.

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

    // روز 3 را به‌طور واقعی خالی بگذارید، در حالی که دسته‌بندی و نقطه دادهٔ آن را نگه می‌دارید.
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

هر فایل خروجی حالت انتخاب‌شده قبل از ذخیره را ثبت می‌کند: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ تنها یک نسخه، حالت موردنظر را تنظیم کنید و یک‌بار ارائه را ذخیره کنید.

مقایسهٔ زیر همان داده را در هر سه فایل نشان می‌دهد. روز ۳ در کتاب کار در هر حالت خالی است:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

اثر قابل مشاهده بسته به نوع نمودار متفاوت است. یک نمودار خطی سه حالت را به‌راحتی مقایسه می‌کند. نمودارهای میله و ستون خطی برای اتصال بین دستهٔ گمشده ندارند، بنابراین `Span` نمی‌تواند قطعهٔ اتصال نشان داده‌شده در بالا را تولید کند؛ یک ستون گمشده و یک ستون با ارتفاع صفر نیز ممکن است مشابه به نظر برسند. به‌طور مشابه، یک نمودار پراکندگی صرفاً با نشانگرها خطی برای اتصال ندارند. انتظار نتایج سه‌گانهٔ متمایز برای همهٔ انواع نمودارها را نداشته باشید؛ خروجی را برای نوع مورد استفاده‌تان بررسی کنید.

## **تنظیم عرض فاصلهٔ مجموعه**

عرض فاصله (Gap width) فضای بین خوشه‌های میله یا ستون مجاور است که به‌صورت درصدی از عرض میله یا ستون بیان می‌شود. مشابه overlap، این تنظیم به گروه والد مجموعه تعلق دارد نه به یک مجموعه منفرد. یک بار برای گروه با [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) فراخوانی کنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آن‌ها را متراکم‌تر می‌کند.

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

![The gap width](gap_width.png)

## **نمایش یا مخفی‌سازی خطوط مجموعه**

خطوط مجموعه (Series lines) بخش‌های مرتبط یک نمودار را به‌صورت بصری به هم متصل می‌کند. برای نمایش یا مخفی‌سازی آن‌ها در نمودارهای stacked bar و OfPie پشتیبانی‌شده، از [IChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setSeriesLines-boolean-) استفاده کنید. در نمودارهای stacked bar و column دو‑بعدی، این خطوط مرزهای مربوط به هر پشته را بین دسته‌ها متصل می‌کند. در نمودارهای Pie of Pie و Bar of Pie، این خطوط نمودار اصلی را به نمودار ثانویه وصل می‌کند. این تنظیم برای انواع دیگر نمودارها عمومی نیست.

گروه را از طریق [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) دریافت کنید. این تنظیم برای هر مجموعه در آن گروه اعمال می‌شود. [IChartSeries.hasSeriesLines](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#hasSeriesLines--) فقط‑خواندنی است و تنظیمات گروه والد را نشان می‌دهد؛ برای به‌روزرسانی آن باید setter گروه را صدا بزنید.

مثال زیر یک نمودار [PieOfPie](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#PieOfPie) با داده‌های پیش‌فرض می‌سازد، آن را یک بار با خطوط مجموعه فعال و یک بار غیرفعال ذخیره می‌کند تا دو ارائه برای مقایسه داشته باشید.

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

| خطوط مجموعه فعال | خطوط مجموعه غیرفعال |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| دو خط اصلی پای را به پای ثانوی متصل می‌کنند. | هر دو پای قابل مشاهده‌اند اما خطوط اتصال مخفی هستند. |

خطوط مجموعه با خطوط راهنما (leader lines) برچسب داده، خطوط شبکه (gridlines) و خطوط در یک نمودار خطی که مقادیر داده را نشان می‌دهند، متفاوت هستند. این تنظیم این عناصر را کنترل نمی‌کند.

## **سوالات متداول**

**کدام انواع نمودار از مجموعه داده پشتیبانی می‌کنند؟**

تمامی انواع نمودارهای موجود در شمارش‌گر [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) از داده‌های نمودار استفاده می‌کنند، اما مجموعه‌های آن‌ها همگی ساختار مقدار یا تنظیمات یکسانی ندارند. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکندگی از مقادیر X و Y، و نمودارهای حباب از اندازه حباب نیز بهره می‌برند. از روش ایجاد نقطه داده‌ای که با نوع مجموعه مطابقت دارد استفاده کنید. گزینه‌هایی مانند overlap و gap width فقط برای گروه‌های میله یا ستون سازگار اعمال می‌شوند.

**مجموعه گروهی نمودار چیست؟**

[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) شامل مجموعه‌های سازگاری است که تنظیمات رسم در سطح گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک مجموعه دست می‌یابد لزوماً همهٔ مجموعه‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه‌ساخته داده‌های پیش‌فرض دارد؟**

بله. به‌طور پیش‌فرض، [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) مجموعه‌های نمونه، دسته‌ها و مقادیر را ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن دادهٔ کاملاً سفارشی، هر دو مجموعه و دسته را پاک کنید. یک overload نیز می‌تواند نموداری بدون دادهٔ پیش‌فرض ایجاد کند.

**چگونه اشیاء نمودار به سلول‌های کتاب کار متصل می‌شوند؟**

نام‌های مجموعه، برچسب‌های دسته و مقادیر نقطه داده به سلول‌های یک [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده عنصر مربوطه در نمودار را به‌روز می‌کند. هنگامی که دادهٔ سفارشی می‌سازید، ردیف‌های دسته و ردیف‌های مقادیر مجموعه را طوری تنظیم کنید که هر نقطه زیر دستهٔ موردنظر رسم شود.

**چگونه یک نقطه را به‌جای کل مجموعه پاک کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دسته‌ای نقطه به‌عنوان نقطهٔ خالی حفظ شود. فقط وقتی می‌خواهید تمام نقاط یک مجموعه را حذف کنید، از [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) استفاده کنید؛ این متد همهٔ نقاط را از مجموعه حذف می‌کند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقدار تنظیم‌شده از طریق [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فاصله، مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که معنای دادهٔ گمشده را در ارائهٔ شما منعکس کند. برای مثال کامل و مقایسهٔ تصویری، به [Control the Display of Empty Cells](#control-the-display-of-empty-cells) مراجعه کنید.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های میله، ستون و حباب پشتیبانی‌شده، با [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) و تنظیم رنگی که از [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) برمی‌گردد، می‌توانید مقادیر منفی را با رنگ متفاوت نشان دهید. می‌توانید برای یک نقطهٔ خاص این رفتار را با [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) بازنویسی کنید. این متدها صرفاً قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**در صورتی که هم مجموعه و هم نقطه قالب‌بندی شوند، کدام برتری دارد؟**

قالب‌بندی صریح نقطه داده برای آن نقطه اولویت دارد. نقاط دیگر همچنان از قالب صریح مجموعه یا، اگر قالب مجموعه تعریف نشده باشد، از سبک و تم خودکار نمودار استفاده می‌کنند. تنظیمات گروهی مانند overlap و gap width مربوط به چیدمان هستند و به‌عنوان بازنویسی‌های سطح نقطه در نظر گرفته نمی‌شوند.

**آیا محدودیتی برای تعداد مجموعه‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت شمارشی ثابت جداگانه‌ای برای تعداد مجموعه‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان رندر و خوانایی نمودار تعیین‌کنندهٔ حد عملی هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها بیش از حد به‌هم‌چسب یا بیش از حد دور هستند؟**

روی گروه والد مناسب با [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) فراخوانی کنید. مقدار را افزایش دهید تا فاصله بین خوشه‌ها گسترده شود یا کاهش دهید تا خوشه‌ها به‌هم نزدیک‌تر شوند.