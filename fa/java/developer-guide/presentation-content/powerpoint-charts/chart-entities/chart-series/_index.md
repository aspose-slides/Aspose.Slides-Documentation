---
title: مدیریت مجموعه داده‌های نمودار در ارائه‌ها با جاوا
linktitle: مجموعه داده‌ها
type: docs
url: /fa/java/chart-series/
keywords:
- مجموعه نمودار
- همپوشانی مجموعه
- رنگ مجموعه
- نام مجموعه
- نقطه داده
- سلول کتاب کار
- فاصله مجموعه
- مقدار منفی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه مجموعه‌های نمودار، نقاط داده، سلول‌های کتاب کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با جاوا مدیریت کنید."
---
## **بررسی کلی**

یک نمودار می‌تواند مقادیر ترسیم‌شده را در سلول‌های کتاب کار یا به‌صورت مقادیر عددی ثابت ذخیره کند. یک [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) نمایانگر یک مجموعه از مقادیر مرتبط است و هر [IChatDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) یک نقطه در آن مجموعه را نشان می‌دهد. اشیای [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی‌شده‌ای را که توسط مجموعه‌ها به اشتراک گذاشته می‌شوند، فراهم می‌آورند. در نمودارهایی که با داده‌های پیش‌فرض ساخته می‌شوند، نام مجموعه‌ها، دسته‌ها و مقادیر نقاط از اشیای [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) موجود در کتاب کار نمودار استفاده می‌شود.

در یک نمودار دسته‌ای معمولی، کتاب کار پیش‌فرض از ردیف ۰ برای نام مجموعه‌ها، ستون ۰ برای نام دسته‌ها و بقیهٔ سلول‌ها برای مقادیر مجموعه‌ها استفاده می‌کند. ایندکس‌های شیت، ردیف و ستون که به ‎[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-)‎ ارسال می‌شوند، صفر‑پایه هستند. این چیدمان هنگام ساخت نمودار با داده‌های پیش‌فرض مفید است، اما فرض نکنید که تمام نمودارهای موجود از آن استفاده می‌کنند. برای ارائهٔ بارگذاری‌شده، قبل از تغییر مقادیر کتاب کار، سلول‌های مورد اشاره توسط مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه سطح مختلف هستند:

- تنظیمات سطح مجموعه، مانند ‎[IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--)‎، ظاهر پیش‌فرض همهٔ نقاط در یک مجموعه را تعیین می‌کند.
- تنظیمات نقطهٔ داده، مانند ‎[IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--)‎، ظاهر مجموعه را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی برای مجموعه‌های سازگاری که به همان ‎[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/)‎ تعلق دارند، اعمال می‌شود. برای تنظیم گزینه‌هایی مانند Overlap یا Gap Width، از ‎[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--)‎ استفاده کنید.

وقتی پر کردن صریحی برای نقطه یا مجموعه تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. هنگامی که هر دو قالب‌بندی مجموعه و نقطه موجود باشد، قالب‌بندی نقطه در اولویت قرار می‌گیرد.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تنظیم مقادیر مجموعه با مقادیر عددی ثابت**

زمانی که مقادیر مجموعه از داده‌های برنامه یا محاسبه‌های داخلی می‌آیند و نیازی به ارجاع به سلول‌های شیت ندارند، از مقادیر عددی ثابت استفاده کنید. قبل از اختصاص مقدار به هر نقطه، ‎[setDataSourceTypeForValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-)‎ را با ‎[DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/#DoubleLiterals)‎ فراخوانی کنید و سپس نتیجهٔ ‎[getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--)‎ هر نقطه را با ‎[setAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-)‎ تنظیم کنید.

این تنظیم مجموعه، نوع منبع همهٔ مقادیر نقطه‌ها در آن مجموعه را کنترل می‌کند. متد ‎[getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ibasechartvalue/#getDataSourceType--)‎ برای هر مقدار نقطه، نوع انتخاب‌شده را برمی‌گرداند؛ می‌توانید آن را از طریق تنظیم مجموعه تغییر دهید. هنگام کار با ‎`Worksheet`‎، از ‎[getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/isinglecellchartvalue/#getAsCell--)‎ برای دسترسی به سلول مرجع استفاده کنید. هنگام کار با ‎`DoubleLiterals`‎، از ‎[getAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--)‎ یا ‎`setAsLiteralDouble`‎ برای خواندن یا نوشتن عدد به‌صورت مستقیم بهره بگیرید.

مثال زیر یک نمودار ستونی با مجموعه و دسته‌های پیش‌فرض ایجاد می‌کند، سپس مقادیر محاسبه‌شدهٔ ۱۰، ۲۰ و … را به نقاط موجود مجموعهٔ اول اختصاص می‌دهد. سپس ارائه را ذخیره، باز می‌کند و مقادیر ذخیره‌شده را چاپ می‌کند.

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

نوع منبع مقدار نقطه جدا از ‎[IChartData.getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getDataSourceType--)‎ است که پیکربندی کتاب کار داخلی یا خارجی نمودار را مشخص می‌کند. استفاده از مقادیر عددی ثابت به‌تنهایی کتاب کار توکار را حذف نمی‌کند. در این مثال، کتاب کار برای برچسب‌های دسته، نام‌های مجموعه و سایر مجموعه‌ها در دسترس می‌ماند. برای مدیریت کتاب کار، بخش ‎[Chart Workbook](/slides/fa/java/chart-workbook/)‎ را ببینید.

برای نمودارهای Scatter و Bubble، از ‎[setDataSourceTypeForXValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-)‎ و ‎[setDataSourceTypeForYValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-)‎ برای انتخاب منبع ‎[getXValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getXValue--)‎ و ‎[getYValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getYValue--)‎ استفاده کنید. برای نمودارهای Bubble نیز ‎[setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-)‎ برای ‎[getBubbleSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getBubbleSize--)‎ به کار می‌رود. هر منبع مربوطه را قبل از اختصاص عدد با ‎`DoubleLiterals`‎ تنظیم کنید و سپس از متد ‎`setAsLiteralDouble`‎ استفاده کنید.

## **تنظیم Overlap مجموعهٔ نمودار**

‎[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--)‎ میزان همپوشانی نوارها یا ستون‌ها را در یک نمودار دو‑بعدی از ‎-100‎ تا ‎100‎ درصد گزارش می‌دهد. این مقدار فقط یک تصویر خواندنی از تنظیمات گروه والد است. برای به‌روزرسانی همهٔ مجموعه‌های سازگار در آن گروه، از ‎[IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-)‎ استفاده کنید. این گزینه فقط برای انواع نموداری که نوارهای گروهی یا ستون‌های گروهی نمایش می‌دهند، اعمال می‌شود؛ در ترکیبی که گروه‌های نامرتبط دارند، تأثیری ندارد.

مثال زیر Overlap گروهی که شامل مجموعهٔ اول است را تنظیم می‌کند:

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

برای تعیین پر کردن پیش‌فرض یک مجموعه کامل، از ‎[IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--)‎ استفاده کنید. اگر یک نقطه پیش از ذلك پر کردن صریح داشته باشد، تنظیم ‎[IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--)‎ آن، پر کردن مجموعه را برای همان نقطه بازنویسی می‌کند.

مثال زیر پر کردن ثابت آبی را برای مجموعهٔ اول اعمال می‌کند:

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

نام مجموعه در کتاب کار داده‌های نمودار ذخیره می‌شود و معمولاً در لیجند نمایش داده می‌شود. در کتاب کار پیش‌فرض برای یک نمودار ستونی خوشه‌ای، سلول ‎B1‎ (ردیف ۰، ستون ۱) شامل نام اولین مجموعه است. ثابت‌های نام‌گذاری در مثال زیر ساختار را به طور صریح نشان می‌دهند:

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

همچنین می‌توانید سلولی که ‎[IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--)‎ به آن ارجاع می‌دهد، به‌روز کنید. این روش فرض ردیف و ستون خاصی را در یک نمودار موجود حذف می‌کند:

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

### **ایجاد مجموعه‌ای با نام از چند سلول**

یک نام ترکیبی برای مجموعه زمانی مفید است که نام محصول و دورهٔ گزارش در سلول‌های جداگانه‌ای ذخیره شده باشند. به‌عنوان مثال می‌توانید ‎`Product A`‎ در ‎B1‎ و ‎`2026`‎ در ‎C1‎ را ترکیب کنید و همچنان هر دو قسمت به سلول‌های منبع خود مرتبط بمانند.

از ‎[IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-)‎ برای دریافت بازهٔ نام استفاده کنید و سپس آن مجموعه را به ‎[IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-)‎ بدهید. آرگومان ‎`skipHiddenCells`‎ تعیین می‌کند که سلول‌های پنهان شامل شوند یا نه: ‎`true`‎ آنها را حذف می‌کند، ‎`false`‎ همه را شامل می‌شود. این مثال از ‎`false`‎ برای شامل کردن تمام سلول‌های بازهٔ نام استفاده می‌کند.

مثال زیر یک ارائه با یک مجموعه و دو نقطه داده ایجاد می‌کند. سلول‌های ‎B1:C1‎ فقط نام مجموعه را فراهم می‌آورند؛ ‎A2:A3‎ برچسب‌های دسته را؛ و ‎B2:B3‎ مقادیر عددی را.

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

نام مجموعهٔ حاصل ‎`Product A 2026`‎ است؛ بین دو مقدار سلول یک فاصله وجود دارد. لیجند این نام را به‌عنوان یک ورودی برای هر دو ستون نشان می‌دهد. تصویر زیر نتیجه را نشان می‌دهد:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **دریافت رنگ پر کردن خودکار مجموعه**

‎[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--)‎ رنگی را برمی‌گرداند که بر پایهٔ شاخص مجموعه و سبک نمودار محاسبه می‌شود. این رنگ زمانی به کار می‌رود که پر کردن مجموعه به‌صورت صریح تعریف نشده باشد. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ پر کردن جدیدی ایجاد نمی‌کند.

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

## **تنظیم رنگ پر کردن معکوس برای یک مجموعه**

برای مجموعه‌های Bar، Column و Bubble، ‎[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-)‎ می‌تواند مقادیر منفی را با رنگ متفاوتی نمایش دهد. پر کردن معمولی مجموعه را به‌صورت ثابت تنظیم کنید، معکوس شدن را فعال کنید و رنگ منفی را از طریق ‎[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)‎ اختصاص دهید. اعداد منفی در کتاب کار بدون تغییر می‌مانند؛ تنها رنگ نمایش آنها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف ۰ شیت نام مجموعه، ستون ۰ نام دسته‌ها و ستون ۱ مقادیر را دارد:

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

برای یک نقطه می‌توانید معکوس شدن را با ‎[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-)‎ فعال کنید. مثال زیر معکوس را برای مجموعه غیرفعال و فقط برای نقطهٔ انتخاب‌شده فعال می‌کند؛ همچنین مقدار منفی به نقطه اختصاص داده شده تا اثر قابل مشاهده باشد:

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

## **پاک‌سازی مقدار یک نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف سایر نقاط، سلول کتاب کار مرتبط با آن را به ‎`null`‎ تنظیم کنید. در یک نمودار ستونی، مقدار ترسیم‌شده از طریق ‎[IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--)‎ در دسترس است. نقطه در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر پایه تنظیمات خالی بودن مقدار در نظر می‌گیرد.

مثال زیر فقط نقطهٔ دوم در مجموعهٔ اول را پاک می‌کند:

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

نمودارهای Scatter از سلول‌های جداگانهٔ X و Y استفاده می‌کنند و نمودارهای Bubble نیز یک سلول اندازه دارند. فقط سلولی را که نشانگر مقداری است که می‌خواهید حذف کنید، پاک کنید. از ‎[IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--)‎ وقتی می‌خواهید سایر نقاط را نگه دارید، استفاده نکنید؛ این متد تمام نقاط مجموعه را حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های پنهانی که مقدار دارند، موردی متفاوت از سلول‌های خالی هستند. برای شامل یا حذف داده‌ها از ردیف‌ها و ستون‌های پنهان، به ‎[Include Data from Hidden Rows and Columns](/slides/fa/java/chart-workbook/#include-data-from-hidden-rows-and-columns)‎ مراجعه کنید.

یک سلول کتاب کار خالی دادهٔ گمشده را نشان می‌دهد؛ سلولی که ‎`0`‎ داشته باشد، مقدار عددی شناخته‌شده‌ای است. برای خالی کردن سلول، ‎[IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-)‎ را با ‎`null`‎ فراخوانی کنید. مقدار عددی صفر همچنان صفر می‌ماند، صرف‌نظر از تنظیم خالی بودن سلول.

از ‎[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)‎ برای انتخاب نحوهٔ نمایش سلول‌های خالی توسط نمودار استفاده کنید. این تنظیم برای تمام نمودار اعمال می‌شود و نحوهٔ ترسیم خالی‌ها را تغییر می‌دهد، بدون اینکه سلول خالی با صفر یا مقدار برآوردی پر شود.

مثال زیر یک نمودار خطی با یک مجموعه می‌سازد، مقدار روز ۳ را پاک می‌کند و هر حالت را در یک فایل جداگانه ذخیره می‌کند. نیازی به فایل ورودی نیست. ‎[IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/)‎ از شیت ۰، ستون ۰ برای برچسب‌های دسته و ستون ۱ برای مقادیر استفاده می‌کند؛ ردیف ۰ نام مجموعه را دارد. دادهٔ نهایی ‎`10, 20, empty, 30, 40`‎ است.

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

    // Day 3 را واقعاً خالی بگذارید، در حالی که دسته‌بندی و نقطه داده آن را نگه دارید.
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

هر فایل خروجی حالت انتخاب‌شده قبل از ذخیره را نشان می‌دهد: ‎`empty_cells_Gap.pptx`‎، ‎`empty_cells_Zero.pptx`‎ و ‎`empty_cells_Span.pptx`‎. برای ذخیرهٔ تنها یک نسخه، حالت دلخواه را تنظیم کنید و یکبار ارائه را ذخیره کنید.

مقایسهٔ زیر همان داده را در هر سه فایل نشان می‌دهد. روز ۳ در تمامی موارد در کتاب کار خالی است:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

اثر قابل مشاهده بسته به نوع نمودار متفاوت است. یک نمودار خطی سه حالت را به‌راحتی مقایسه می‌کند. نمودارهای Bar و Column خطی برای اتصال بین دسته‌های گمشده ندارند، بنابراین ‎`Span`‎ نمی‌تواند بخشی که در بالا نشان داده شده را تولید کند؛ یک ستون گمشده و یک ستون صفر‑ارتفاع ممکن است مشابه به‌نظر برسند. به‌طور مشابه، یک نمودار Scatter فقط با نشانگرها، خطی برای اتصال ندارد. انتظار نتایج سه‌گانه برای هر نوع نمودار نباشید؛ خروجی را برای نوع مورد استفاده‌تان بررسی کنید.

## **تنظیم عرض فاصلهٔ مجموعه**

عرض فاصله (Gap Width) فاصله بین خوشه‌های نوار یا ستون مجاور است و به‌صورت درصدی از عرض نوار یا ستون بیان می‌شود. مشابه Overlap، این تنظیم به گروه والد تعلق دارد نه به یک مجموعهٔ منفرد. برای گروه یک بار ‎[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)‎ فراخوانی کنید. مقدار بزرگ‌تر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچک‌تر آن‌ها را فشرده‌تر می‌کند.

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

**کدام انواع نمودار از مجموعه داده پشتیبانی می‌کنند؟**

تمامی انواع نموداری که توسط ‎[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)‎ تعریف شده‌اند از داده‌های نمودار استفاده می‌کنند، اما ساختار یا تنظیمات مقادیر مجموعه‌ها برای همه یکسان نیست. به‌عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، Scatter از مقادیر X و Y، و Bubble اندازهٔ بلور را نیز اضافه می‌کند. از متد ساخت نقطه داده‌ای که با نوع مجموعه هماهنگ است استفاده کنید. گزینه‌هایی مانند Overlap و Gap Width تنها برای گروه‌های Bar یا Column سازگار اعمال می‌شوند.

**یک گروه مجموعهٔ نمودار چیست؟**

یک ‎[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/)‎ شامل مجموعه‌های سازگاری است که تنظیمات ترسیم سطح گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از یک مجموعه به آن دسترسی پیدا می‌کنید لزوماً تمام مجموعه‌های نمودار را تحت تأثیر قرار نمی‌دهد.

**آیا یک نمودار تازه‌ساخته داده‌های پیش‌فرض دارد؟**

بله. به‌صورت پیش‌فرض، ‎[IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-)‎ مجموعه‌ها، دسته‌ها و مقادیر نمونه را ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش یا هر دو مجموعه و دسته را پیش از افزودن داده‌های سفارشی پاک کنید. یک بارگذاری دیگر نیز می‌تواند نموداری بدون دادهٔ پیش‌فرض ایجاد کند.

**اجسام نمودار چگونه به سلول‌های کتاب کار مرتبط می‌شوند؟**

نام مجموعه‌ها، برچسب‌های دسته و مقادیر نقطه داده‌ها به سلول‌های یک ‎[IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/)‎ ارجاع می‌دهند. تغییر سلول مرجع، عنصر مربوطه در نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر مجموعه را هم‌راستا نگه دارید تا هر نقطه زیر دستهٔ مورد نظر ترسیم شود.

**چگونه یک نقطه را به‌جای کل مجموعه پاک کنم؟**

سلول مقدار مربوطه را به ‎`null`‎ تنظیم کنید تا موقعیت دسته نقطه به‌عنوان نقطهٔ خالی باقی بماند. فقط وقتی می‌خواهید تمام نقاط یک مجموعه را حذف کنید، از ‎[IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--)‎ استفاده کنید. اگر دسته‌ها را نیز حذف می‌کنید، باید هر مجموعه را به‌گونه‌ای تنظیم کنید که مقادیر همچنان با مجموعهٔ دسته‌ها هم‌راستا باشند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و مقدار تنظیم شده توسط ‎[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)‎ بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فاصله، مقدار صفر یا با اتصال نقاط همسایه نشان دهند. تنظیمی را انتخاب کنید که با معنا‌ی دادهٔ گمشده در ارائهٔ شما همخوانی داشته باشد. برای مثال کامل و مقایسهٔ تصویری به بخش ‎[Control the Display of Empty Cells](#control-the-display-of-empty-cells)‎ مراجعه کنید.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های Bar، Column و Bubble پشتیبانی‌شده، ‎[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-)‎ را فراخوانی کنید و رنگ برگشتی توسط ‎[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)‎ را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با ‎[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-)‎ بازنویسی کنید. این متدها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**زمانی که هم مجموعه و هم نقطه قالب‌بندی شوند، کدام یک برتری دارد؟**

قالب‌بندی صریح نقطهٔ داده برای همان نقطه اولویت دارد. سایر نقاط از قالب‌بندی صریح مجموعه یا، در صورت عدم تعریف، از سبک و تم خودکار نمودار استفاده می‌کنند. تنظیمات گروهی مانند Overlap و Gap Width بر چیدمان کلی تأثیر می‌گذارند و بازنویسی قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد مجموعه‌های قابل افزودن به یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد مجموعه‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه موجود، زمان رندر و خوانایی نمودار، حد عملی را تعیین می‌کنند.

**اگر ستون‌ها بیش از حد نزدیک یا دور باشند، چه کاری باید انجام دهم؟**

‎[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)‎ را بر روی گروه والد مربوطه فراخوانی کنید. مقدار را افزایش دهید تا فاصله بین خوشه‌ها گسترده شود یا کاهش دهید تا خوشه‌ها به‌هم نزدیک‌تر شوند.