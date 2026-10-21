---
title: مدیریت برچسب‌های دادهٔ نمودار در ارائه‌ها با استفاده از جاوا
linktitle: برچسب داده
type: docs
url: /fa/java/chart-data-label/
keywords:
  - نمودار
  - برچسب داده
  - دقت داده
  - درصد
  - فاصله برچسب
  - موقعیت برچسب
  - پاورپوینت
  - ارائه
  - جاوا
  - Aspose.Slides
description: "یادگیری افزودن و قالب‌بندی برچسب‌های دادهٔ نمودار در ارائه‌های پاورپوینت با استفاده از Aspose.Slides برای جاوا برای اسلایدهای جذاب‌تر."
---
## **مقدمه**

برچسب‌های داده اطلاعاتی دربارهٔ مجموعه‌های نمودار و نقاط دادهٔ منفرد را نمایش می‌دهند و به خوانندگان کمک می‌کنند مقادیر را شناسایی و نمودار را درک کنند. این مقاله توضیح می‌دهد چگونه مقادیر را قالب‌بندی کنید، درصدها را به‌صورت برچسب نمایش دهید، متن برچسب را بخوانید، برچسب‌ها را فراتر از حداکثر محور کنترل کنید، فاصلهٔ برچسب محور دسته‌بندی را تنظیم کنید و برچسب‌های نمودار دایره‌ای را موقعیت‌دهی کنید.

## **تنظیم دقت داده در برچسب‌های دادهٔ نمودار**

از [setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) برای قالب‌بندی مقادیر مجموعه استفاده کنید. این مثال یک نمودار خطی با دادهٔ پیش‌فرض ایجاد می‌کند، جدول دادهٔ آن را نمایش می‌دهد و برچسب‌های مقدار را برای مجموعهٔ اول فعال می‌سازد. قالب `#,##0.00` یک جداکنندهٔ هزارگان و دو رقم اعشار را بدون تغییر مقادیر پایه نمایش می‌دهد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای قالب‌بندی سلول‌های عددی در کتاب‌کار جاسازی‌شدهٔ یک نمودار، به [Set Custom Number Formats for Workbook Cells](/slides/fa/java/chart-workbook/#set-custom-number-formats-for-workbook-cells) مراجعه کنید. آن مثال همچنین نشان می‌دهد که برچسب‌های مقدار فرمت سلول منبع خود را دنبال می‌کنند در حالی که مقادیر عددی ذخیره‌شده حفظ می‌شوند.

## **نمایش درصد به‌عنوان برچسب**

برای یک نمودار ستونی انباشته، هر مقدار را به‌عنوان درصدی از مجموع دسته خود محاسبه کنید و متن را به فریم متنی که توسط [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) برگردانده می‌شود، اختصاص دهید. این مثال از دادهٔ پیش‌فرض نمودار استفاده می‌کند و درصدها را با دو رقم اعشار در قلم ۸ پوینت نمایش می‌دهد. دسته‌هایی که مجموعشان صفر است برای جلوگیری از تقسیم بر صفر رد می‌شوند. اگر دادهٔ نمودار تغییر کند متن برچسب سفارشی را مجدداً محاسبه کنید.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);

    double[] categoryTotals = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            IChartSeries series = chart.getChartData().getSeries().get_Item(i);
            Number pointValue = (Number) series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += pointValue.doubleValue();
        }
    }

    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            Number pointValue = (Number) series.getDataPoints().get_Item(j).getValue().getData();
            double dataPointPercent = (pointValue.doubleValue() / categoryTotals[j]) * 100;

            IPortion portion = new Portion();
            portion.setText(String.format(Locale.US, "%.2f %%", dataPointPercent));
            portion.getPortionFormat().setFontHeight(8f);

            label.getTextFrameForOverriding().setText("");
            IParagraph paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم علامت درصد با برچسب‌های دادهٔ نمودار**

زمانی که مقادیر به صورت کسر ذخیره می‌شوند، از [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) برای نمایش درصدها استفاده کنید. برای اعمال قالب برچسب مستقل از سلول‌های منبع، `false` را به [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) پاس دهید.

این مثال یک نمودار ستونی ۱۰۰٪ انباشته با سری‌های قرمز و آبی در چهار دسته ایجاد می‌کند. هر جفت مقدار به ۱ می‌رسد. قالب برچسب `0.0%` مقدار ۰٫۳۰ را به‌صورت ۳۰٫۰٪ نمایش می‌دهد، در حالی که محور عمودی از دو رقم اعشار استفاده می‌کند. هر دو سری از متن برچسب سفید ۱۰ پوینت استفاده می‌کنند.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    for (int i = 0; i < 4; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    String[] seriesNames = { "Reds", "Blues" };
    Color[] seriesColors = { Color.RED, Color.BLUE };
    double[][] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

    for (int i = 0; i < seriesNames.length; i++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (int j = 0; j < 4; j++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(FillType.Solid);
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **خواندن متن واقعی برچسب‌های داده**

از [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) برای دریافت متنی که توسط تنظیمات برچسب داده تولید می‌شود استفاده کنید. این هنگام استخراج برچسب‌ها برای گزارش‌ها، جستجو در محتوای ارائه یا اعتبارسنجی نمودارهای تولیدشده مفید است. در مثال زیر، قالب پیش‌فرض [data label format](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) هر نام دسته، نام سری و مقدار را ترکیب می‌کند. یک نقطه مقدار خود را به‌صورت درصد قالب‌بندی می‌کند و نقطهٔ دیگر متن سفارشی را از [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) دریافت می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    IChartDataCell secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    IChartDataCell northSeriesCell = workbook.getCell(0, 0, 1, "North");
    IChartSeries north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    IChartDataCell northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    IChartDataCell northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    IChartDataCell southSeriesCell = workbook.getCell(0, 0, 2, "South");
    IChartSeries south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    IChartDataCell southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    IChartDataCell southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (IChartSeries series : chart.getChartData().getSeries()) {
        for (IChartDataPoint point : series.getDataPoints()) {
            IDataLabel label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            System.out.println("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

عدد ذخیره‌شده در یک نقطهٔ داده به‌صورت `0.75` باقی می‌ماند، حتی زمانی که برچسب آن `75%` به‌همراه نام‌های دسته و سری نشان می‌دهد. متن سفارشی متن برچسب تولیدشده را جایگزین می‌کند. [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) در هر دو حالت رشتهٔ برچسب نهایی را برمی‌گرداند. همان‌طور که در بالا نشان داده شد، برای استخراج فقط برچسب‌های قابل مشاهده، به‌طور جداگانه [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--) را بررسی کنید.

## **کنترل برچسب‌های داده فراتر از حداکثر محور**

زمانی که بازهٔ محور را به‌صورت دستی محدود می‌کنید، ممکن است برخی نقاط داده از حداکثر آن فراتر روند. از [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) برای کنترل نمایش یا عدم نمایش برچسب‌های دادهٔ آنها استفاده کنید. این تنظیم فقط نمایش برچسب را تغییر می‌دهد؛ بازهٔ محور یا مقادیر دادهٔ پایه را تغییر نمی‌دهد.

مثال زیر یک نمودار ستونی خوشه‌ای ۲D با مقادیر ۶۰ و ۱۲۰ ایجاد می‌کند. `false` به [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) منتقل می‌شود و حداکثر به ۱۰۰ با [setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-) بر روی محور عمودی تنظیم می‌شود. اسلاید اول اجازه می‌دهد برچسب‌ها فراتر از حداکثر باشند؛ یک نسخهٔ دیگر آن اسلاید این گزینه را غیرفعال می‌کند. هر دو اسلاید در `DataLabelsOverMaximum.pptx` ذخیره می‌شوند.

برچسب‌های مقدار را با [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) فعال کنید. این تنظیم سطح نمودار به‌تنهایی مقدار را نشان نمی‌دهد و باز هم نمی‌تواند نمایش مقدار غیرفعال‌شدهٔ یک برچسب منفرد را نادیده بگیرد. این مثال مقدارها را برای تمام مجموعه فعال می‌کند و با [setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-) برچسب‌ها را در انتهای بیرونی هر ستون قرار می‌دهد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell firstCategory = workbook.getCell(0, 1, 0, "Within range");
    IChartDataCell secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Values");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    IChartDataCell firstValue = workbook.getCell(0, 1, 1, 60);
    IChartDataCell secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    ISlide secondSlide = presentation.getSlides().addClone(slide);
    IChart secondChart = (IChart) secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تصاویر زیر اسلایدهای ذخیره‌شده را که توسط Microsoft PowerPoint رندر شده‌اند نشان می‌دهند. با `true`، برچسب **120** در مرز بالایی قابل مشاهده است؛ با `false` مخفی می‌شود. برچسب **60** همچنان قابل مشاهده است، حداکثر محور در **100** باقی می‌ماند و نقطهٔ دادهٔ دوم در هر دو حالت **120** است.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![نمودار PowerPoint که برچسب مقدار 120 را با حداکثر محور 100 نشان می‌دهد](data-labels-over-maximum-true.png) | ![نمودار PowerPoint که برچسب مقدار 120 را با حداکثر محور 100 مخفی می‌کند](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}

این مثال از یک نمودار ستونی ۲D با محور مقدار استفاده می‌کند. نمودارهایی بدون محور مقدار، مانند نمودارهای دایره‌ای و دونات، حداکثر محوری برای محدود کردن به این شکل ندارند.

{{% /alert %}}

## **تنظیم فاصله برچسب از محور**

از [setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-) برای کنترل فاصله بین برچسب‌های محور دسته‌بندی و محور استفاده کنید. مقدار بر حسب درصد از بیشینهٔ اندازهٔ قلم برچسب‌های محور است. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و فاصلهٔ برچسب محور افقی را برابر ۵۰۰ تنظیم می‌کند. این تنظیم برچسب‌های محور دسته‌بندی را تحت تأثیر قرار می‌دهد نه برچسب‌های متصل به نقاط دادهٔ منفرد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم موقعیت برچسب**

در یک نمودار دایره‌ای، موقعیت برچسب‌های داده را برای بهبود فاصله و گذاشتن فضا برای خطوط راهنما تنظیم کنید.

این مثال مقدار اولین نقطهٔ داده را نمایش می‌دهد، برچسب آن را خارج از قطعه قرار می‌دهد و افست‌های افقی و عمودی آن را با استفاده از [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) و [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-) تنظیم می‌کند. این افست‌ها به‌صورت نسبی به عرض و ارتفاع نمودار هستند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![نمودار دایره‌ای با موقعیت برچسب داده تنظیم‌شده](pie-chart-adjusted-label.png)

## **قالب‌بندی خطوط راهنما**

هنگامی که برچسب‌های نمودار دایره‌ای خارج از قطعات قرار می‌گیرند، خطوط راهنما به خوانندگان کمک می‌کند تا هر مقدار را با قطعهٔ مربوطه مطابقت دهند. رنگی متضاد و خطی کمی ضخیم‌تر می‌تواند این اتصال‌ها را پیگیری‌پذیرتر کند، در حالی که شفافیت و سبک خط‌چین خطوط را به‌صورت ظاهری کم‌تداخل نگه می‌دارد.

از [getLeaderLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelcollection/#getLeaderLinesFormat--) برای قالب‌بندی خطوط راهنما در سطح مجموعهٔ برچسب‌های دادهٔ سری استفاده کنید. تنظیمات موجود در `series.getLabels().getLeaderLinesFormat().getLine()` به کل مجموعه اعمال می‌شود، نه به برچسب منفرد.

این مثال یک نمودار دایره‌ای با دادهٔ پیش‌فرض ایجاد می‌کند، مقادیر را خارج از قطعات نشان می‌دهد و با [setShowLeaderLines](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowLeaderLines-boolean-) خطوط راهنما را فعال می‌کند. دو برچسب با استفاده از افست‌های [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) و [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-) دورتر از قطعاتشان جابه‌جا می‌شوند؛ این افست‌ها به‌صورت کسری از عرض و ارتفاع نمودار بیان می‌شوند. ارائه ورودی موردنیاز نیست.

متد [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) خط را به رنگ آبی مایل به شفاف با مقدار آلفای ۱۹۱ از ۲۵۵ تنظیم می‌کند که تقریباً ۲۵٪ شفافیت می‌دهد. [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) ضخامت را به ۲ پوینت تنظیم می‌کند و [setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) خط را خط‌چین می‌سازد.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400);
    chart.setLegend(false);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
    labelFormat.setShowValue(true);
    labelFormat.setPosition(LegendDataLabelPosition.OutsideEnd);
    labelFormat.setShowLeaderLines(true);

    // دو برچسب را از قطعاتشان دورتر جابجا کنید.
    series.getLabels().get_Item(0).setX(0.10f);
    series.getLabels().get_Item(0).setY(-0.05f);
    series.getLabels().get_Item(1).setX(-0.10f);
    series.getLabels().get_Item(1).setY(0.05f);

    ILineFormat line = series.getLabels().getLeaderLinesFormat().getLine();
    line.getFillFormat().setFillType(FillType.Solid);
    line.getFillFormat().getSolidFillColor().setColor(new Color(30, 90, 160, 191));
    line.setWidth(2);
    line.setDashStyle(LineDashStyle.Dash);

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

فعال کردن خطوط راهنما تضمین نمی‌کند که برای هر برچسب یک خط ظاهر شود. قابلیت مشاهده به موقعیت برچسب و رفتار چیدمان نمودار بستگی دارد. در این مثال، دو برچسب جابجا شده خطوط راهنمای قابل مشاهده دارند؛ برچسب‌هایی که نزدیک به قطعاتشان می‌مانند به آنها نیازی ندارند.

تصویر زیر فایل `FormattedLeaderLines.pptx` ذخیره‌شده را که با Aspose.Slides رندر شده نشان می‌دهد:

![نمودار دایره‌ای با خطوط راهنمای آبی، نیمه‌شفاف و خط‌چین که دو برچسب خارجی را به قطعاتشان متصل می‌کند](formatted-leader-lines.png)

## **افزودن چند ردیف برچسب داده بالای نمودار ستونی**

این مثال یک نمودار ستونی با دو ردیف برچسب داده بالای ناحیهٔ نمودار ایجاد می‌کند. سری A ستون‌های قابل مشاهده را نشان می‌دهد، در حالی که سری‌های B و C برچسب‌های اضافی را فراهم می‌کنند. ستون‌های آنها با حذف پر و خط پیرامونی مخفی می‌شوند. روش [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) تمام سه سری را با مراکز دستهٔ یکسان تراز می‌کند.

تنظیمات [ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) فضای لازم برای ردیف‌های برچسب را رزرو می‌کند. پس از اینکه [Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) موقعیت پیش‌فرض‌ها را محاسبه کرد، [DataLabel.setX and DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/) تراز افقی را حفظ کرده و افست‌های عمودی را برای چینش برچسب‌ها در دو ردیف اعمال می‌کند. اعداد همچنان برچسب‌های دادهٔ مرتبط با مقادیر سری هستند؛ فقط سرصفحه‌های ردیف به‌صورت اشکال متنی جداگانه‌اند.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    String[] categories = {"North", "South", "East", "West"};
    String[] seriesNames = {"Series A", "Series B", "Series C"};
    double[][] seriesValues = {
            {35, 42, 28, 47},
            {22, 31, 19, 26},
            {12, 16, 14, 18}
    };

    for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        chart.getChartData().getCategories().add(
                workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]));
    }

    for (int seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().add(
                workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]),
                ChartType.ClusteredColumn);

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            series.getDataPoints().addDataPointForBarSeries(workbook.getCell(
                    0, categoryIndex + 1, seriesIndex + 1,
                    seriesValues[seriesIndex][categoryIndex]));
        }

        if (seriesIndex > 0) {
            // ستون‌های B و C را مخفی کنید، اما برچسب‌های دادهٔ آنها را نگه دارید.
            series.getFormat().getFill().setFillType(FillType.NoFill);
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().setFontHeight(12);
            IFillFormat labelFill = series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(FillType.Solid);
            labelFill.getSolidFillColor().setColor(java.awt.Color.BLACK);
            series.getLabels().getDefaultDataLabelFormat().setPosition(
                    LegendDataLabelPosition.InsideBase);
        }
    }

    // تمامی سه مجموعه را با مراکز دستهٔ یکسان تراز کنید.
    chart.getChartData().getSeries().get_Item(0)
            .getParentSeriesGroup().setOverlap((byte) 100);

    // در این مثال فشرده از خطوط شبکهٔ کمتری استفاده کنید.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // فضای لازم در بالای ناحیهٔ نمودار را برای دو ردیف برچسب داده اختصاص دهید.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);
    chart.getPlotArea().setX(0.15f);
    chart.getPlotArea().setY(0.32f);
    chart.getPlotArea().setWidth(0.80f);
    chart.getPlotArea().setHeight(0.48f);
    chart.validateChartLayout();

    for (int seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            IDataLabel dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // موقعیت افقی پیش‌فرض را حفظ کنید. Y یک افست از
            // موقعیت پیش‌فرض برچسب است که به‌صورت کسری از ارتفاع نمودار بیان می‌شود.
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // فقط سرعنوان ردیف یک شکل متنی جداگانه است.
        IAutoShape rowHeading = slide.getShapes().addAutoShape(
                ShapeType.Rectangle, chart.getX(),
                chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(FillType.NoFill);
        rowHeading.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        IPortionFormat headingFormat = rowHeading.getTextFrame().getParagraphs()
                .get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(FillType.Solid);
        headingFormat.getFillFormat().getSolidFillColor().setColor(java.awt.Color.BLACK);
    }

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![نمودار ستونی با دو ردیف برچسب داده بالای ناحیهٔ نمودار](multiple-rows-of-labels.png)

## **سوالات متداول**

**چگونه می‌توانم از هم‌پوشانی برچسب‌های داده در نمودارهای متراکم جلوگیری کنم؟**

از قرار دادن خودکار برچسب، خطوط راهنما و کاهش اندازهٔ قلم ترکیب کنید؛ در صورت نیاز برخی فیلدها (مثلاً دسته) را مخفی کنید یا فقط برچسب‌های مقادیر انتها یا نقاط کلیدی را نمایش دهید.

**چگونه می‌توانم برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کنم؟**

قبل از فعال‌سازی برچسب‌ها نقاط داده را فیلتر کنید و نمایش را برای مقادیر ۰، مقادیر منفی یا مقادیر گمشده بر اساس قانونی تعریف‌شده غیرفعال کنید.

**چگونه می‌توانم سبک برچسب را به‌صورت یکسان هنگام صادرات به PDF/تصاویر حفظ کنم؟**

قابلاً قلم و اندازه را به‌طور صریح تنظیم کنید و اطمینان حاصل کنید که قلم در محیط رندر موجود است تا از استفاده از قلم جایگزین جلوگیری شود.