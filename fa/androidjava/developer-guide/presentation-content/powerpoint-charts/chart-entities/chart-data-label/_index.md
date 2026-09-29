---
title: مدیریت برچسب‌های داده نمودار در ارائه‌ها برای اندروید
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
description: "یاد بگیرید چگونه برچسب‌های داده نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای اندروید از طریق Java اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **مقدمه**

برچسب‌های داده اطلاعاتی دربارهٔ سری‌های نمودار و نقاط دادهٔ فردی نمایش می‌دهند و به خوانندگان کمک می‌کنند تا مقادیر را شناسایی و نمودار را درک کنند. این مقاله توضیح می‌دهد چگونه مقادیر را قالب‌بندی کنیم، درصدها را نمایش دهیم، متن برچسب را بخوانیم، برچسب‌ها را فراتر از حداکثر محور کنترل کنیم، فاصله‌گذاری برچسب‌های محور دسته‌بندی را تنظیم کنیم و برچسب‌های نمودار دایره‌ای را موقعیت‌دهی کنیم.

## **تنظیم دقت داده در برچسب‌های داده نمودار**

از [setNumberFormatOfValues](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) برای قالب‌بندی مقادیر سری‌ها استفاده کنید. این مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند، جدول داده‌های آن را نشان می‌دهد و برچسب‌های مقدار را برای اولین سری فعال می‌کند. قالب `#,##0.00` یک جداکنندهٔ هزارگان و دو رقم اعشار نمایش می‌دهد بدون اینکه مقادیر پایه تغییر کنند.

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

برای یک نمودار ستونی انباشتی، هر مقدار را به عنوان درصدی از مجموع دستهٔ مربوطه محاسبه کنید و متن را به قاب متنی که توسط [getTextFrameForOverriding](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) برگردانده می‌شود اختصاص دهید. این مثال از داده‌های پیش‌فرض نمودار استفاده می‌کند و درصدها را با دو رقم اعشار در قلم ۸ نقطه‌ای نمایش می‌دهد. دسته‌هایی که مجموع آن‌ها صفر است برای جلوگیری از تقسیم بر صفر نادیده گرفته می‌شوند. اگر داده‌های نمودار تغییر کند، متن برچسب سفارشی را دوباره محاسبه کنید.

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

## **تنظیم علامت درصد با برچسب‌های داده نمودار**

زمانی که مقادیر به صورت کسر ذخیره شده‌اند، از [setNumberFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) برای نمایش درصدها استفاده کنید. برای اعمال قالب برچسب به‌صورت مستقل از سلول‌های منبع، `false` را به [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) پاس دهید.

این مثال یک نمودار ستونی انباشتی ۱۰۰٪ با سری‌های قرمز و آبی در چهار دسته ایجاد می‌کند. هر جفت مقدار مجموعاً برابر با ۱ است. قالب برچسب `0.0%` مقدار ۰٫۳۰ را به‌صورت ۳۰.۰٪ نمایش می‌دهد، در حالی که محور عمودی دو رقم اعشار دارد. هر دو سری از متن برچسب سفید با اندازهٔ ۱۰ نقطه استفاده می‌کنند.

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

از [getActualLabelText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) برای دریافت متنی که برچسب داده بر اساس تنظیمات تولید می‌کند استفاده کنید. این ویژگی هنگام استخراج برچسب برای گزارش‌ها، جستجوی محتوای ارائه یا اعتبارسنجی نمودارهای تولید شده مفید است. در مثال زیر، قالب پیش‌فرض [data label format](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idatalabelformat/) هر نام دسته، نام سری و مقدار را ترکیب می‌کند. یک نقطه مقدار خود را به‌صورت درصد فرمت می‌کند و نقطهٔ دیگر متن سفارشی را از [getTextFrameForOverriding](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) دریافت می‌کند.

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

عدد ذخیره‌شده در یک نقطه داده همچنان `0.75` باقی می‌ماند، حتی اگر برچسب آن `75%` به همراه نام‌های دسته و سری نمایش دهد. متن سفارشی متن برچسب تولید‌شده را جایگزین می‌کند. [getActualLabelText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) در هر دو حالت رشتهٔ برچسب نهایی را باز می‌گرداند. همان‌طور که در بالا نشان داده شد، برای استخراج تنها برچسب‌های قابل مشاهده، باید به‌طور جداگانه [isVisible](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idatalabel/#isVisible--) بررسی شود.

## **کنترل برچسب‌های داده فراتر از حداکثر محور**

زمانی که بازهٔ محور را به‌صورت دستی محدود می‌کنید، ممکن است برخی نقاط داده از حداکثر آن بیشتر باشند. از [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) برای کنترل اینکه آیا برچسب‌های دادهٔ آن‌ها نمایش داده شوند یا نه استفاده کنید. این تنظیم تنها نمایش برچسب را تغییر می‌دهد؛ بازهٔ محور یا مقادیر پایه داده را تغییر نمی‌دهد.

مثال زیر یک نمودار ستونی خوشه‌ای ۲‑بعدی با مقادیر ۶۰ و ۱۲۰ ایجاد می‌کند. `false` را به [setAutomaticMaxValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) پاس می‌دهد و حداکثر را با [setMaxValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaxis/#setMaxValue-double-) بر روی محور عمودی برابر ۱۰۰ تنظیم می‌کند. اسلاید اول اجازهٔ نمایش برچسب‌ها فراتر از حداکثر را می‌دهد؛ نسخهٔ کپی شدهٔ آن این امکان را غیرفعال می‌کند. هر دو اسلاید در `DataLabelsOverMaximum.pptx` ذخیره می‌شوند.

با [setShowValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) برچسب‌های مقدار را فعال کنید. این تنظیم سطح نمودار به‌تنهایی مقدار نمایش را فعال نمی‌کند و نمایش مقدار غیرفعال‌شدهٔ برچسب فردی را بازنویسی نمی‌کند. این مثال مقدارها را برای تمام سری فعال می‌کند و با استفاده از [setPosition](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idatalabelformat/#setPosition-int-) برچسب‌ها را در انتهای بیرونی هر ستون قرار می‌دهد.

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

تصاویر زیر اسلایدهای ذخیره‌شده را که توسط Microsoft PowerPoint رندر شده‌اند نشان می‌دهند. با `true`، برچسب **120** در مرز بالایی قابل مشاهده است؛ با `false`، مخفی می‌شود. برچسب **60** همچنان قابل مشاهده است، حداکثر محور در **100** باقی می‌ماند و نقطهٔ دادهٔ دوم در هر دو حالت **120** است.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
این مثال از یک نمودار ستونی ۲‑بعدی با محور مقدار استفاده می‌کند. نمودارهایی که محور مقدار ندارند، مانند نمودارهای دایره‌ای و دونات، حداکثر محوری برای محدود کردن به این شکل ندارند.
{{% /alert %}}

## **تنظیم فاصله برچسب از محور**

از [setLabelOffset](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaxis/#setLabelOffset-int-) برای کنترل فاصلهٔ بین برچسب‌های محور دسته‌بندی و محور استفاده کنید. مقدار این تنظیم درصدی از حداکثر اندازهٔ قلم برچسب‌های محور است. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و مقدار جابجایی برچسب محور افقی را برابر ۵۰۰ می‌گذارد. این تنظیم برچسب‌های محور دسته‌بندی را تحت تأثیر قرار می‌دهد نه برچسب‌های متصل به نقاط دادهٔ فردی.

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

در یک نمودار دایره‌ای، موقعیت برچسب‌های داده را تنظیم کنید تا فاصله‌ها بهبود یابد و فضای کافی برای خطوط راهنما فراهم شود.

این مثال مقدار اولین نقطه داده را نمایش می‌دهد، برچسب آن را در خارج از قطعه قرار می‌دهد و جابجایی‌های افقی و عمودی آن را با استفاده از [setX](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutable/#setX-float-) و [setY](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutable/#setY-float-) تنظیم می‌کند. این جابجایی‌ها به‌صورت نسبی به عرض و ارتفاع نمودار هستند.

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

## **FAQ**

**چگونه می‌توان از هم‌پوشانی برچسب‌های داده در نمودارهای پرشتاب جلوگیری کرد؟**

انتخاب خودکار مکان برچسب، استفاده از خطوط راهنما و کاهش اندازهٔ قلم را ترکیب کنید؛ در صورت نیاز برخی فیلدها (مثلاً دسته) را مخفی کنید یا فقط برای مقادیر افراطی یا نقاط کلیدی برچسب نمایش دهید.

**چگونه می‌توان برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کرد؟**

قبل از فعال‌سازی برچسب‌ها نقاط داده را فیلتر کنید و نمایش را برای مقادیر ۰، مقادیر منفی یا مقادیر گمشده طبق قاعده‌ای تعریف‌شده خاموش کنید.

**چگونه می‌توان سبک برچسب را هنگام خروجی به PDF/تصاویر ثابت نگه داشت؟**

قالب قلم و اندازه را به‌طور صریح تنظیم کنید و اطمینان حاصل کنید که قلم در محیط رندر موجود است تا از استفادهٔ جایگزین جلوگیری شود.