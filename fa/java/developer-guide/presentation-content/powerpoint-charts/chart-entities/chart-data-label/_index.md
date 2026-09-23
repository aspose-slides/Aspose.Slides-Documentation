---
title: مدیریت برچسب‌های داده نمودار در ارائه‌ها با استفاده از Java
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
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "بیاموزید چگونه برچسب‌های دادهٔ نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Java اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **معرفی**

برچسب‌های داده اطلاعاتی دربارهٔ مجموعه‌های نمودار و نقاط دادهٔ فردی نمایش می‌دهند و به خوانندگان کمک می‌کنند تا مقادیر را شناسایی کرده و نمودار را درک کنند. این مقاله توضیح می‌دهد چگونه مقادیر را قالب‌بندی کنید، درصدها را نمایش دهید، متن برچسب را بخوانید، فاصلهٔ برچسب محور دسته‌بندی را تنظیم کنید، و موقعیت برچسب‌های نمودار دایره‌ای را تعیین کنید.

## **تنظیم دقت داده‌ها در برچسب‌های دادهٔ نمودار**

از [setNumberFormatOfValues](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) برای قالب‌بندی مقادیر مجموعه‌ها استفاده کنید. این مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند، جدول داده‌های آن را نمایش می‌دهد و برچسب‌های مقدار را برای اولین مجموعه فعال می‌کند. قالب `#,##0.00` جداکنندهٔ هزارگان و دو رقم اعشار را نشان می‌دهد بدون اینکه مقادیر پایه‌ای تغییر کنند.

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

## **نمایش درصد به عنوان برچسب‌ها**

برای یک نمودار ستون پشته‌ای، هر مقدار را به‌عنوان درصدی از مجموع دستهٔ مربوطه محاسبه کنید و متن را به فریم متنی که توسط [getTextFrameForOverriding](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) برگردانده می‌شود، اختصاص دهید. این مثال از داده‌های پیش‌فرض نمودار استفاده می‌کند و درصدها را با دو رقم اعشار در فونت ۸ پوینت نمایش می‌دهد. دسته‌های دارای مجموع صفر نادیده گرفته می‌شوند تا از تقسیم بر صفر جلوگیری شود. اگر داده‌های نمودار تغییر کنند، متن برچسب سفارشی را دوباره محاسبه کنید.

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

هنگامی که مقادیر به صورت کسر ذخیره می‌شوند، از [setNumberFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) برای نمایش درصدها استفاده کنید. برای اعمال قالب برچسب مستقل از سلول‌های منبع، مقدار `false` را به [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) پاس دهید.

این مثال یک نمودار ستون ۱۰۰٪ پشته‌ای با مجموعه‌های قرمز و آبی در چهار دسته ایجاد می‌کند. هر جفت مقدار به ۱ می‌رسد. قالب برچسب `0.0%` مقدار ۰٫۳۰ را به‌عنوان ۳۰٫۰٪ نمایش می‌دهد، در حالی که محور عمودی از دو رقم اعشار استفاده می‌کند. هر دو مجموعه از متن برچسب سفید با اندازهٔ ۱۰ پوینت استفاده می‌کنند.

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

از [getActualLabelText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idatalabel/#getActualLabelText--) برای بازیابی متنی که توسط تنظیمات برچسب داده تولید می‌شود استفاده کنید. این برای استخراج برچسب‌ها برای گزارش‌ها، جستجو در محتوای ارائه یا اعتبارسنجی نمودارهای تولیدی مفید است. در مثال زیر، قالب پیش‌فرض [برچسب داده](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idatalabelformat/) نام هر دسته، نام مجموعه و مقدار را ترکیب می‌کند. یک نقطه مقدار خود را به‌صورت درصد قالب‌بندی می‌کند و دیگری از متن سفارشی که از [getTextFrameForOverriding](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) دریافت می‌شود، استفاده می‌کند.

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

عدد ذخیره‌شده در یک نقطه داده همان `0.75` می‌ماند، حتی زمانی که برچسب آن `75%` را همراه با نام دسته و نام مجموعه نمایش می‌دهد. متن سفارشی متن برچسب تولید شده را جایگزین می‌کند. [getActualLabelText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idatalabel/#getActualLabelText--) در هر دو حالت رشتهٔ برچسب نهایی را برمی‌گرداند. هنگام نیاز به استخراج تنها برچسب‌های قابل مشاهده، همان‌طور که در بالا نشان داده شده است، به‌طور جداگانه [isVisible](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idatalabel/#isVisible--) را بررسی کنید.

## **تنظیم فاصلهٔ برچسب از محور**

از [setLabelOffset](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iaxis/#setLabelOffset-int-) برای کنترل فاصلهٔ بین برچسب‌های محور دسته‌بندی و خود محور استفاده کنید. مقدار به‌صورت درصدی از حداکثر اندازهٔ قلم برچسب‌های محور محاسبه می‌شود. این مثال یک نمودار ستون خوشه‌ای ایجاد می‌کند و مقدار جابجایی برچسب محور افقی را روی ۵۰۰ تنظیم می‌نماید. این تنظیم بر برچسب‌های محور دسته‌بندی تأثیر می‌گذارد نه بر برچسب‌های متصل به نقاط دادهٔ فردی.

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

در یک نمودار دایره‌ای، موقعیت برچسب‌های داده را تنظیم کنید تا فواصل بهبود یابد و فضای لازم برای خطوط راهنمایی فراهم شود.

این مثال مقدار اولین نقطه داده را نمایش می‌دهد، برچسب آن را بیرون قطعه قرار می‌دهد و جابجایی‌های افقی و عمودی آن را با استفاده از [setX](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutable/#setX-float-) و [setY](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutable/#setY-float-) تنظیم می‌کند. این جابجایی‌ها به‌ترتیب نسبت به عرض و ارتفاع نمودار هستند.

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

## **پرسش‌های متداول**

**چگونه می‌توانم از هم‌پوشانی برچسب‌های داده در نمودارهای متراکم جلوگیری کنم؟**

از ترکیب قرارگیری خودکار برچسب‌ها، خطوط راهنما و کاهش اندازه قلم استفاده کنید؛ در صورت لزوم برخی فیلدها (مثلاً دسته) را مخفی کنید یا فقط برای مقادیر انتهایی یا نقاط کلیدی برچسب نمایش دهید.

**چگونه می‌توانم برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کنم؟**

پیش از فعال‌سازی برچسب‌ها نقاط داده را فیلتر کنید و نمایش مقادیر صفر، مقادیر منفی یا مقادیر گمشده را بر اساس یک قاعدهٔ تعریف‌شده غیرفعال کنید.

**چگونه می‌توانم سبک برچسب ثابت را هنگام خروجی به PDF/تصاویر تضمین کنم؟**

به‌طور صریح خانوادهٔ قلم و اندازهٔ آن را تنظیم کنید و اطمینان حاصل کنید که قلم در محیط رندرینگ موجود است تا از استفاده از قلم پیش‌فرض جلوگیری شود.