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
description: "یاد بگیرید چگونه برچسب‌های دادهٔ نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای جاوا اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **مقدمه**

برچسب‌های داده اطلاعاتی دربارهٔ سری‌های نمودار و نقاط دادهٔ فردی را نمایش می‌دهند و به خوانندگان کمک می‌کنند تا مقادیر را شناسایی کرده و نمودار را درک کنند. این مقاله نحوهٔ قالب‌بندی مقادیر، نمایش درصدها، خواندن متن برچسب، کنترل برچسب‌ها فراتر از حداکثر محور، تنظیم فاصلهٔ برچسب محور دسته‌بندی و موقعیت‌دهی به برچسب‌های نمودار دایره‌ای را توضیح می‌دهد.

## **تنظیم دقت عددی در برچسب‌های دادهٔ نمودار**

از [setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) برای قالب‌بندی مقادیر سری‌ها استفاده کنید. این مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند، جدول دادهٔ آن را نمایش می‌دهد و برچسب‌های مقداری را برای اولین سری فعال می‌سازد. قالب `#,##0.00` جداکنندهٔ هزارگان و دو رقم اعشار را بدون تغییر مقادیر پایه نشان می‌دهد.

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

## **نمایش درصد به‌عنوان برچسب‌ها**

برای یک نمودار ستونی انباشته، هر مقدار را به‌عنوان درصدی از مجموع دستهٔ خود محاسبه کنید و متن را به قاب متنی که توسط [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) برگردانده می‌شود اختصاص دهید. این مثال از داده‌های پیش‌فرض نمودار استفاده می‌کند و درصدها را با دو رقم اعشار در قلم 8 نقطه‌ای نشان می‌دهد. دسته‌هایی که مجموعشان صفر است برای جلوگیری از تقسیم بر صفر نادیده گرفته می‌شوند. اگر داده‌های نمودار تغییر کند، متن برچسب سفارشی را دوباره محاسبه کنید.

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

زمانی که مقادیر به‌صورت کسر ذخیره می‌شوند، برای نمایش درصدها از [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) استفاده کنید. برای اعمال قالب برچسب مستقل از سلول‌های منبع، مقدار `false` را به [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) پاس دهید.

این مثال یک نمودار ستونی 100٪ انباشته با سری‌های قرمز و آبی در چهار دسته ایجاد می‌کند. هر جفت مقدار به‌همین ترتیب به 1 می‌رسند. قالب برچسب `0.0%` مقدار 0.30 را به‌صورت 30.0٪ نمایش می‌دهد، در حالی که محور عمودی از دو رقم اعشار استفاده می‌کند. هر دو سری از متن برچسب سفید با اندازهٔ 10 نقطه استفاده می‌کنند.

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

از [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) برای دریافت متنی که توسط تنظیمات برچسب داده تولید شده است، استفاده کنید. این کار هنگام استخراج برچسب‌ها برای گزارش‌ها، جستجو در محتوای ارائه یا اعتبارسنجی نمودارهای تولیدشده مفید است. در مثال زیر، قالب پیش‌فرض [data label format](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) نام هر دسته، نام سری و مقدار را ترکیب می‌کند. یک نقطه مقدار خود را به‌صورت درصد قالب‌بندی می‌کند و دیگری از متن سفارشی که توسط [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) برگردانده می‌شود، استفاده می‌کند.

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

عدد ذخیره‌شده در یک نقطهٔ داده همچنان `0.75` می‌ماند، حتی وقتی برچسب آن `75%` را همراه با نام‌های دسته و سری نشان می‌دهد. متن سفارشی متن تولیدی برچسب را جایگزین می‌کند. [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) در هر دو حالت رشتهٔ برچسب نهایی را برمی‌گرداند. برای استخراج فقط برچسب‌های قابل مشاهده، همان‌طور که در بالا نشان داده شد، به‌صورت جداگانه به [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--) نگاه کنید.

## **کنترل برچسب‌های داده فراتر از حداکثر محور**

زمانی که بازهٔ محور را به‌صورت دستی محدود می‌کنید، ممکن است برخی نقاط داده از حداکثر آن فراتر روند. برای کنترل نمایش یا عدم نمایش برچسب‌های دادهٔ آنها از [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) استفاده کنید. این تنظیم فقط قابلیت مشاهده برچسب را تغییر می‌دهد؛ بازهٔ محور یا مقادیر پایه داده را تغییر نمی‌دهد.

مثال زیر یک نمودار ستونی خوشه‌ای دو‌بعدی با مقادیر 60 و 120 ایجاد می‌کند. مقدار `false` به [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) پاس می‌دهد و حداکثر را به 100 تنظیم می‌کند با استفاده از [setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-) بر روی محور عمودی. اسلاید اول اجازه نشان دادن برچسب‌ها فراتر از حداکثر را می‌دهد؛ یک کپی از آن اسلاید این ویژگی را غیرفعال می‌کند. هر دو اسلاید در `DataLabelsOverMaximum.pptx` ذخیره می‌شوند.

برچسب‌های مقدار را با [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) فعال کنید. تنظیم سطح نمودار به‌تنهایی نمایش مقدار را فعال نمی‌کند و همچنین نمایش مقدار غیرفعال شدهٔ یک برچسب خاص را پوشش نمی‌دهد. این مثال مقادیر را برای تمام سری فعال می‌کند و با [setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-) برچسب‌ها را در انتهای بیرونی هر ستون قرار می‌دهد.

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

تصاویر زیر اسلایدهای ذخیره‌شده را که توسط Microsoft PowerPoint رندر شده‌اند نشان می‌دهند. با `true`، برچسب **120** در مرز بالایی قابل مشاهده است؛ با `false`، مخفی می‌شود. برچسب **60** همچنان قابل مشاهده است، حداکثر محور در **100** می‌ماند و نقطهٔ دادهٔ دوم در هر دو حالت **120** می‌ماند.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![نمودار PowerPoint که برچسب مقدار 120 را با حداکثر محور 100 نشان می‌دهد](data-labels-over-maximum-true.png) | ![نمودار PowerPoint که برچسب مقدار 120 را با حداکثر محور 100 مخفی می‌کند](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
این مثال از یک نمودار ستونی دو‌بعدی با محور مقدار استفاده می‌کند. نمودارهایی که محور مقدار ندارند، مانند نمودارهای دایره‌ای و دونات، حداکثر محور برای محدودسازی ندارند.
{{% /alert %}}

## **تنظیم فاصلهٔ برچسب از محور**

از [setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-) برای کنترل فاصلهٔ بین برچسب‌های محور دسته‌بندی و خود محور استفاده کنید. مقدار، درصدی از حداکثر اندازهٔ قلم برچسب‌های محور است. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و فاصلهٔ برچسب محور افقی را به 500 تنظیم می‌کند. این تنظیم برچسب‌های محور دسته‌بندی را تحت تأثیر قرار می‌دهد نه برچسب‌های متصل به نقاط دادهٔ فردی.

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

## **تنظیم مکان برچسب**

در یک نمودار دایره‌ای، موقعیت برچسب‌های داده را برای بهبود فاصله و ایجاد فضای کافی برای خطوط راهنما تنظیم کنید.

این مثال مقدار اولین نقطه داده را نشان می‌دهد، برچسب آن را بیرون از برش قرار می‌دهد و افست‌های افقی و عمودی آن را با استفاده از [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) و [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-) تنظیم می‌کند. این افست‌ها به‌صورت نسبی به عرض و ارتفاع نمودار هستند.

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

زمانی که برچسب‌های نمودار دایره‌ای بیرون از برش‌ها قرار می‌گیرند، خطوط راهنما به خوانندگان کمک می‌کند تا هر مقدار را به برش صحیح مرتبط کنند. استفاده از رنگ متقابل و خطی کمی ضخیم‌تر می‌تواند این ارتباطات را واضح‌تر کند، در حالی که شفافیت و سبک خط چین خطوط را به‌صورت بصری کم‌رنگ نگه می‌دارد.

از [getLeaderLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelcollection/#getLeaderLinesFormat--) برای قالب‌بندی خطوط راهنما در سطح مجموعهٔ برچسب‌های دادهٔ سری استفاده کنید. تنظیمات موجود در `series.getLabels().getLeaderLinesFormat().getLine()` بر روی کل مجموعه اعمال می‌شوند، نه بر روی برچسب منفرد.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند، مقادیر را بیرون از برش‌ها نمایش می‌دهد و [setShowLeaderLines](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowLeaderLines-boolean-) را فعال می‌کند. دو برچسب با استفاده از افست‌های [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) و [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-) از برش‌های خود دورتر جابجا می‌شوند؛ این افست‌ها به‌عنوان کسرهایی از عرض و ارتفاع نمودار بیان می‌شوند. برای این مثال نیازی به ارائهٔ ورودی نیست.

متد [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) خط را با رنگ آبی ثابت و مقدار آلفای 191 از 255 (حدود 25٪ شفافیت) تنظیم می‌کند. [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) ضخامت را به 2 پوینت تنظیم می‌کند و [setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) خط را به حالت خط چین در می‌آورد.

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

    // دو برچسب را دورتر از برش‌هایشان جابه‌جا کنید.
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

فعال‌سازی خطوط راهنما تضمین نمی‌کند که برای هر برچسب خطی ظاهر شود. قابلیت دیدن به موقعیت برچسب و رفتار چینش نمودار بستگی دارد. در این مثال، دو برچسب جابجا شده خطوط راهنمای قابل مشاهده دارند؛ برچسب‌هایی که نزدیک به برش‌های خود می‌مانند به خطوط نیاز ندارند.

تصویر زیر `FormattedLeaderLines.pptx` ذخیره‌شده را که توسط Aspose.Slides رندر شده نشان می‌دهد:

![نمودار دایره‌ای با خطوط راهنمای آبی، نیمه‌شفاف و خط‌چین که دو برچسب بیرونی را به برش‌های خود متصل می‌کند](formatted-leader-lines.png)

## **افزودن چند ردیف برچسب داده بالای یک نمودار ستونی**

این مثال یک نمودار ستونی با دو ردیف برچسب داده بالای ناحیهٔ نمودار ایجاد می‌کند. سری A ستون‌های قابل مشاهده را نشان می‌دهد، در حالی که سری‌های B و C برچسب‌های اضافی را فراهم می‌کنند. ستون‌های آنها با حذف پر و حاشیه مخفی می‌شوند. متد [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) همهٔ سه سری را با مراکز دسته‌ای یکسان هماهنگ می‌کند.

تنظیمات [ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) فضای لازم برای ردیف‌های برچسب را رزرو می‌کند. پس از محاسبهٔ موقعیت‌های پیش‌فرض توسط [Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/)، متدهای [DataLabel.setX and DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/) تراز افقی را حفظ کرده و افست‌های عمودی را اعمال می‌کنند تا برچسب‌ها در دو ردیف تنظیم شوند. اعداد همچنان برچسب‌های دادهٔ مرتبط با مقادیر سری‌ها هستند؛ تنها سرصفحه‌های ردیف به‌صورت شکل‌های متنی جداگانه‌اند.

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
            // ستون‌های B و C را مخفی کنید، اما برچسب‌های دادهٔ آنها را حفظ کنید.
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

    // تمام سه سری را با مراکز دسته‌ای یکسان هم‌راستا کنید.
    chart.getChartData().getSeries().get_Item(0)
            .getParentSeriesGroup().setOverlap((byte) 100);

    // برای این مثال فشرده از خطوط شبکه کمتر استفاده کنید.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // فضایی بالای نمودار رزرو کنید برای دو ردیف برچسب داده.
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
            // موقعیت افقی پیش‌فرض را حفظ کنید. Y یک جابجا از
            // موقعیت پیش‌فرض برچسب، به‌صورت کسر ارتفاع نمودار بیان شده است.
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // فقط عنوان ردیف یک شکل متنی جداگانه است.
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

**چگونه می‌توان از هم‌پوشانی برچسب‌های داده در نمودارهای پرجمعیت جلوگیری کرد؟**

از ترکیب قراردهی خودکار برچسب، خطوط راهنما و کاهش اندازهٔ قلم استفاده کنید؛ در صورت نیاز برخی فیلدها (مثلاً دسته) را مخفی کنید یا فقط برچسب‌های مقادیر نهایی یا نقاط کلیدی را نشان دهید.

**چگونه می‌توان برچسب‌ها را تنها برای مقادیر صفر، منفی یا خالی غیرفعال کرد؟**

پیش از فعال‌سازی برچسب‌ها، نقاط داده را فیلتر کنید و نمایش مقادیر 0، مقادیر منفی یا مقادیر گمشده را بر اساس قوانین تعریف‌شده غیرفعال کنید.

**چگونه می‌توان اطمینان حاصل کرد که سبک برچسب به‌صورت یکنواخت هنگام خروجی به PDF/تصاویر حفظ می‌شود؟**

قابلوتاً خانواده و اندازهٔ قلم را تنظیم کنید و اطمینان حاصل کنید که قلم در محیط رندر موجود است تا از استفادهٔ جایگزین جلوگیری شود.