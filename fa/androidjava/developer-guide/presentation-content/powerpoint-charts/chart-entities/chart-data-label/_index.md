---
title: مدیریت برچسب‌های داده نمودار در ارائه‌ها بر روی Android
linktitle: برچسب داده
type: docs
url: /fa/androidjava/chart-data-label/
keywords:
- نمودار
- برچسب داده
- دقت داده
- درصد
- فاصله برچسب
- موقعیت برچسب
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌های داده نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Android از طریق Java اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **معرفی**

برچسب‌های داده اطلاعاتی دربارهٔ سلسله‌های نمودار و نقاط دادهٔ فردی نمایش می‌دهند و به خوانندگان کمک می‌کنند تا مقادیر را شناسایی کنند و نمودار را درک نمایند. این مقاله نحوهٔ قالب‌بندی مقادیر، نمایش درصدها، خواندن متن برچسب، کنترل برچسب‌ها فراتر از حداکثر محور، تنظیم فاصله برچسب محور دسته‌بندی و موقعیت‌یابی برچسب‌های نمودار دایره‌ای را توضیح می‌دهد.

## **تنظیم دقت داده در برچسب‌های دادهٔ نمودار**

از [setNumberFormatOfValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) برای قالب‌بندی مقادیر سلسله‌ها استفاده کنید. این مثال یک نمودار خطی با داده پیش‌فرض ایجاد می‌کند، جدول دادهٔ آن را نمایش می‌دهد و برچسب‌های مقدار برای اولین سلسله را فعال می‌کند. قالب `#,##0.00` جداساز هزارگان و دو رقم اعشار را بدون تغییر مقادیر پایه نمایش می‌دهد.

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

## **نمایش درصدها به عنوان برچسب**

برای نمودار میلهٔ پشته‌ای، هر مقدار را به‌عنوان درصدی از مجموع دستهٔ مربوطه محاسبه کنید و متن را به فریم متنی بازگردانده‌شده توسط [getTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) اختصاص دهید. این مثال از داده پیش‌فرض نمودار استفاده می‌کند و درصدها را با دو رقم اعشار در فونت 8 پوینت نمایش می‌دهد. دسته‌هایی که مجموعشان صفر است برای جلوگیری از تقسیم بر صفر نادیده گرفته می‌شوند. اگر دادهٔ نمودار تغییر کند متن برچسب سفارشی را مجدداً محاسبه کنید.

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

## **تنظیم علامت درصد در برچسب‌های دادهٔ نمودار**

زمانی که مقادیر به‌صورت کسر ذخیره شوند، از [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) برای نمایش درصدها استفاده کنید. برای اعمال قالب برچسب به‌صورت مستقل از سلول‌های منبع، `false` را به [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) پاس دهید.

این مثال یک نمودار میلهٔ پشته‌ای 100٪ با سلسله‌های قرمز و آبی در چهار دسته ایجاد می‌کند. هر جفت مقدار به 1 می‌رسد. قالب برچسب `0.0%` مقدار 0.30 را به‌صورت 30.0٪ نمایش می‌دهد، در حالی که محور عمودی از دو رقم اعشار استفاده می‌کند. هر دو سلسله متن برچسب سفید با اندازهٔ 10 پوینت دارند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int[] seriesColors = { Color.RED, Color.BLUE };
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

از [getActualLabelText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) برای بازیابی متنی که توسط تنظیمات برچسب داده تولید می‌شود استفاده کنید. این موضوع هنگام استخراج برچسب‌ها برای گزارش‌ها، جستجوی محتوی ارائه یا اعتبارسنجی نمودارهای تولید‌شده مفید است. در مثال زیر، قالب پیش‌فرض [data label format](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/) هر نام دسته، نام سلسله و مقدار را ترکیب می‌کند. یک نقطه مقدار خود را به‌صورت درصد قالب‌بندی می‌کند و نقطهٔ دیگر متن سفارشی را از [getTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) دریافت می‌کند.

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

عدد ذخیره‌شده در یک نقطه داده همچنان `0.75` می‌ماند، حتی وقتی برچسب آن `75%` به‌همراه نام‌های دسته و سلسله را نشان می‌دهد. متن سفارشی متن تولید شدهٔ برچسب را جایگزین می‌کند. [getActualLabelText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) در هر دو حالت رشتهٔ برچسب نهایی را برمی‌گرداند. همان‌طور که در بالا نشان داده شد، برای استخراج فقط برچسب‌های قابل مشاهده، به‌طور جداگانه از [isVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#isVisible--) استفاده کنید.

## **کنترل برچسب‌های داده فراتر از حداکثر محور**

زمانی که بازهٔ محور را به‌صورت دستی محدود می‌کنید، برخی نقاط داده ممکن است از حداکثر آن عبور کنند. از [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) برای کنترل نمایش برچسب‌های آن‌ها استفاده کنید. این تنظیم فقط قابلیت مشاهده برچسب‌ها را تغییر می‌دهد؛ بازهٔ محور یا مقادیر پایه‌ای داده را دست نخورده می‌گذارد.

مثال زیر یک نمودار میلهٔ خوشه‌ای دو‑بعدی با مقادیر 60 و 120 ایجاد می‌کند. `false` به [setAutomaticMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) پاس داده می‌شود و حداکثر محور عمودی با [setMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMaxValue-double-) به 100 تنظیم می‌شود. اسلاید اول برچسب‌ها را فراتر از حداکثر اجازه می‌دهد؛ یک نسخهٔ آن این امکان را غیرفعال می‌کند. هر دو اسلاید در `DataLabelsOverMaximum.pptx` ذخیره می‌شوند.

با [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) برچسب‌های مقدار را فعال کنید. این تنظیم سطح نمودار به‌تنهایی نمایش مقدار را فعال نمی‌کند و نمی‌تواند نمایش مقدار غیرفعال شدهٔ یک برچسب جداگانه را بازنویسی کند. این مثال مقادیر را برای کل سلسله فعال می‌کند و با [setPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setPosition-int-) برچسب‌ها را در انتهای خارجی هر ستون قرار می‌دهد.

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

تصاویر زیر اسلایدهای ذخیره‌شده را که توسط Microsoft PowerPoint رندر شده‌اند نشان می‌دهند. با `true`، برچسب **120** در مرز بالایی قابل مشاهده است؛ با `false` مخفی می‌ماند. برچسب **60** همچنان قابل مشاهده است، حداکثر محور در **100** باقی می‌ماند و نقطهٔ دادهٔ دوم در هر دو حالت **120** می‌ماند.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![نمودار PowerPoint که برچسب مقدار 120 را با حداکثر محور 100 نشان می‌دهد](data-labels-over-maximum-true.png) | ![نمودار PowerPoint که برچسب مقدار 120 را با حداکثر محور 100 مخفی می‌کند](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
این مثال از یک نمودار میلهٔ دو‑بعدی با محور مقدار استفاده می‌کند. نمودارهایی که محور مقدار ندارند، مانند نمودارهای دایره‌ای و دونات، حداکثر محوری برای محدود کردن به این روش ندارند.
{{% /alert %}}

## **تنظیم فاصله برچسب از محور**

از [setLabelOffset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setLabelOffset-int-) برای کنترل فاصله بین برچسب‌های محور دسته‌بندی و محور استفاده کنید. مقدار بر حسب درصد بیشینهٔ اندازهٔ فونت برچسب‌های محور است. این مثال یک نمودار میلهٔ خوشه‌ای ایجاد می‌کند و افست برچسب محور افقی را به 500 تنظیم می‌کند. این تنظیم برچسب‌های محور دسته‌بندی را تحت تأثیر قرار می‌دهد نه برچسب‌های پیوست‌شده به نقاط دادهٔ فردی.

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

در یک نمودار دایره‌ای، موقعیت برچسب‌های داده را تنظیم کنید تا فاصله بهبود یابد و فضای کافی برای خطوط راهنما باقی بماند.

این مثال مقدار اولین نقطه داده را نمایش می‌دهد، برچسب آن را خارج از قطعه قرار می‌دهد و افست‌های افقی و عمودی را با استفاده از [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setX-float-) و [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setY-float-) تنظیم می‌کند. این افست‌ها به ترتیب نسبت به عرض و ارتفاع نمودار هستند.

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

## **اضافه کردن چند ردیف برچسب داده بالای نمودار میله‌ای**

این مثال یک نمودار میله‌ای با دو ردیف برچسب داده بالای ناحیهٔ ترسیم ایجاد می‌کند. سلسلهٔ A ستون‌های قابل مشاهده را نمایش می‌دهد، در حالی که سلسله‌های B و C برچسب‌های اضافی را فراهم می‌کنند. ستون‌های آن‌ها با حذف پر و خطوط مرزی مخفی می‌شوند. روش [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartseriesgroup/#setOverlap-byte-) همهٔ سه سلسله را با مراکز دسته‌ای یکسان هم‌تراز می‌کند.

تنظیمات [ChartPlotArea](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartplotarea/) فضای لازم برای ردیف‌های برچسب را رزرو می‌کند. پس از محاسبهٔ موقعیت‌های پیش‌فرض توسط [Chart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--)، [DataLabel.setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabel/#setX-float-) و [DataLabel.setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabel/#setY-float-) هم‌ترازی افقی را حفظ و افست‌های عمودی را برای چینش برچسب‌ها در دو ردیف اعمال می‌کنند. اعداد همچنان برچسب‌های دادهٔ مرتبط با مقادیر سلسله هستند؛ فقط عنوان‌های ردیف به‌صورت اشکال متنی جداگانه‌اند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
        IChartDataCell categoryCell = workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, ChartType.ClusteredColumn);

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        if (seriesIndex > 0) {
            // ستون‌های B و C را مخفی کنید، اما برچسب‌های داده آنها را نگه دارید.
            series.getFormat().getFill().setFillType(FillType.NoFill);
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
            IFillFormat labelFill = series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(FillType.Solid);
            labelFill.getSolidFillColor().setColor(Color.BLACK);
            series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.InsideBase);
        }
    }

    // همهٔ سه سلسله را با مراکز دسته‌ای یکسان هم‌تراز کنید.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap((byte) 100);

    // برای این مثال فشرده، خطوط شبکهٔ کمتری استفاده کنید.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // فضای بالای نمودار را برای دو ردیف برچسب داده اختصاص دهید.
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
            // موقعیت پیش‌فرض برچسب است، به صورت کسر ارتفاع نمودار بیان می‌شود.
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // فقط عنوان ردیف یک شکل متن جداگانه است.
        IAutoShape rowHeading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(FillType.NoFill);
        rowHeading.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        IPortionFormat headingFormat = rowHeading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(FillType.Solid);
        headingFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    }

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![نمودار میله‌ای با دو ردیف برچسب داده بالای ناحیهٔ ترسیم](multiple-rows-of-labels.png)

## **سوالات متداول**

**چگونه می‌توانم از همپوشانی برچسب‌های داده در نمودارهای فشرده جلوگیری کنم؟**

از قرارگیری خودکار برچسب، خطوط راهنما و کاهش اندازهٔ فونت ترکیب کنید؛ در صورت نیاز برخی فیلدها (مثلاً دسته) را مخفی کنید یا فقط برای مقادیر افراطی یا نقاط کلیدی برچسب نمایش دهید.

**چگونه می‌توانم برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کنم؟**

نقاط داده را پیش از فعال‌سازی برچسب‌ها فیلتر کنید و نمایش را برای مقادیر 0، مقادیر منفی یا مقادیر گمشده بر اساس قانون تعریف‌شده خاموش کنید.

**چگونه می‌توانم سبک برچسب ثابت را هنگام خروجی به PDF/تصاویر تضمین کنم؟**

فونت و اندازهٔ آن را به‌صورت صریح تنظیم کنید و اطمینان حاصل کنید که فونت در محیط رندر موجود است تا از جایگزینی پیش‌فرض جلوگیری شود.