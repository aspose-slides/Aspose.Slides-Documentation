---
title: إدارة ملصقات بيانات المخطط في العروض التقديمية على أندرويد
linktitle: ملصق البيانات
type: docs
url: /ar/androidjava/chart-data-label/
keywords:
- مخطط
- ملصق بيانات
- دقة البيانات
- نسبة مئوية
- مسافة الملصق
- موقع الملصق
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية إضافة وتنسيق ملصقات بيانات المخطط في عروض PowerPoint التقديمية باستخدام Aspose.Slides لأندرويد عبر Java للحصول على شرائح أكثر جذبًا."
---
## **المقدمة**

تُظهر ملصقات البيانات معلومات حول سلاسل المخطط ونقاط البيانات الفردية، مما يساعد القراء على التعرف على القيم وفهم المخطط. يشرح هذا المقال كيفية تنسيق القيم، عرض النسب المئوية، قراءة نص الملصق، التحكم في الملصقات التي تتجاوز الحد الأقصى للمحور، ضبط تباعد ملصقات محور الفئات، وتحديد موضع ملصقات المخطط الدائري.

## **تعيين دقة البيانات في ملصقات بيانات المخطط**

استخدم [setNumberFormatOfValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) لتنسيق قيم السلسلة. ينشئ هذا المثال مخططًا خطيًا ببيانات افتراضية، يعرض جدول البيانات الخاص به، ويفعل ملصقات القيم للسلسلة الأولى. التنسيق `#,##0.00` يعرض فاصل الآلاف ومكانين عشريين دون تعديل القيم الأساسية.

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

لتنسيق الخلايا الرقمية في دفتر العمل المضمن للمخطط، راجع [Set Custom Number Formats for Workbook Cells](/slides/ar/androidjava/chart-workbook/#set-custom-number-formats-for-workbook-cells). يوضح ذلك المثال أيضًا ملصقات القيم التي تتبع صيغ الخلايا المصدر مع الحفاظ على القيم الرقمية المخزنة.

## **عرض النسب المئوية كملصقات**

في مخطط أعمدة مكدس، احسب كل قيمة كنسبة مئوية من إجمالي فئتها وعيّن النص إلى الإطار النصي الذي تُرجعه الدالة [getTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--). يستخدم هذا المثال بيانات المخطط الافتراضية ويعرض النسب المئوية بمكانين عشريين بخط بحجم 8 نقاط. تُتخطى الفئات التي يكون مجموعها صفرًا لتجنب القسمة على صفر. أعد حساب نص الملصق المخصص إذا تغيّر بيانات المخطط.

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

## **تعيين علامة النسبة المئوية مع ملصقات بيانات المخطط**

عند تخزين القيم على شكل كسور، استخدم [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) لعرض النسب المئوية. مرِّر `false` إلى الدالة [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) لتطبيق تنسيق الملصق بشكل مستقل عن خلايا المصدر.

يخلق هذا المثال مخطط أعمدة مكدس 100% مع سلاسل حمراء وزرقاء عبر أربعة فئات. كل زوج من القيم يساوي 1. تنسيق الملصق `0.0%` يعرض 0.30 كـ 30.0%، بينما يستخدم المحور الرأسي مكانين عشريين. تستخدم السلسلتان نص ملصق أبيض بحجم 10 نقاط.

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

## **قراءة النص الفعلي لملصقات البيانات**

استخدم [getActualLabelText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) لاسترجاع النص الذي ينتجه إعدادات ملصق البيانات. هذا مفيد عند استخراج الملصقات للتقارير، البحث في محتوى العرض التقديمي، أو التحقق من صحة المخططات المولدة. في المثال أدناه، يجمع [data label format](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/) الافتراضي كل من اسم الفئة، اسم السلسلة، والقيمة. ينسق أحد النقاط قيمته كنسبة مئوية، ويستخدم آخر نصًا مخصصًا من [getTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

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

يبقى الرقم المخزن في نقطة البيانات `0.75`، حتى عندما يُظهر ملصقه `75%` مع أسماء الفئة والسلسلة. يستبدل النص المخصص نص الملصق المُولد. تُعيد الدالة [getActualLabelText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) سلسلة الملصق الناتجة في كلتا الحالتين. تحقق من [isVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#isVisible--) بشكل منفصل، كما هو موضح أعلاه، عندما تريد استخراج الملصقات الظاهرة فقط.

## **التحكم في ملصقات البيانات التي تتجاوز الحد الأقصى للمحور**

عند تحديد نطاق المحور يدويًا، قد تتجاوز بعض نقاط البيانات الحد الأقصى له. استخدم [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) للتحكم فيما إذا كانت ملصقاتها مرئية. يغيّر هذا الإعداد رؤية الملصق؛ ولا يغيّر نطاق المحور أو القيم الأساسية للبيانات.

يقوم المثال أدناه بإنشاء مخطط أعمدة مجموعة ثنائي الأبعاد بقيم 60 و120. يمرّر `false` إلى الدالة [setAutomaticMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) ويضبط الحد الأقصى إلى 100 باستخدام [setMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMaxValue-double-) على المحور الرأسي. الشريحة الأولى تسمح بملصقات تتجاوز الحد الأقصى؛ يُعطل نسخة من تلك الشريحة ذلك. تُحفظ كلتا الشريحتين في `DataLabelsOverMaximum.pptx`.

فعّل ملصقات القيم باستخدام [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). إعداد مستوى المخطط لا يفعّل عرض القيم بمفرده ولا يتجاوز إيقاف عرض القيمة لملصق فردي. يفعّل هذا المثال القيم لكامل السلسلة ويستخدم [setPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setPosition-int-) لوضع الملصقات عند الطرف الخارجي لكل عمود.

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

تظهر الصور التالية الشرائح المحفوظة التي تم عرضها بواسطة Microsoft PowerPoint. مع `true`، يكون الملصق **120** مرئيًا عند الحد العلوي؛ ومع `false`، يكون مخفيًا. يظل الملصق **60** مرئيًا، يبقى الحد الأقصى للمحور **100**، وتظل نقطة البيانات الثانية **120** في كلتا الحالتين.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
يستخدم هذا المثال مخطط أعمدة ثنائي الأبعاد مع محور قيم. المخططات التي لا تحتوي على محور قيم، مثل المخططات الدائرية ومخططات الدونات، لا تمتلك حدًا أقصى للمحور لتقييده بهذه الطريقة.
{{% /alert %}}

## **تعيين مسافة الملصق من المحور**

استخدم [setLabelOffset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setLabelOffset-int-) للتحكم في المسافة بين ملصقات محور الفئة والمحور. القيمة هي نسبة مئوية من الحد الأقصى لحجم خط ملصقات المحور. ينشئ هذا المثال مخطط أعمدة مجموعة ويضبط إزاحة ملصق المحور الأفقي إلى 500. يؤثر هذا الإعداد على ملصقات محور الفئة بدلًا من الملصقات المرفقة بنقاط البيانات الفردية.

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

## **ضبط موقع الملصق**

في مخطط دائري، اضبط مواضع ملصقات البيانات لتحسين التباعد وإتاحة مساحة لخطوط الوصل.

يعرض هذا المثال قيمة نقطة البيانات الأولى، يضع ملصقها خارج الشريحة، ويضبط إزاحاته الأفقية والعمودية باستخدام [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setX-float-) و [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setY-float-). تكون هذه الإزاحات نسبة إلى عرض وارتفاع المخطط على التوالي.

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

![مخطط دائري مع موضع ملصق بيانات معدل](pie-chart-adjusted-label.png)

## **تنسيق خطوط الوصل**

عندما تكون ملصقات المخطط الدائري خارج شرائحها، تساعد خطوط الوصل القراء على مطابقة كل قيمة مع الشريحة الصحيحة. يمكن للون المتباين والخط السميك قليلًا أن يجعل هذه الروابط أسهل في المتابعة، بينما الشفافية والنمط المتقطع تحافظ على مظهر الخطوط غير مزعج بصريًا.

استخدم [getLeaderLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelcollection/#getLeaderLinesFormat--) لتنسيق خطوط الوصل على مستوى مجموعة ملصقات البيانات للسلسلة. تنطبق الإعدادات في `series.getLabels().getLeaderLinesFormat().getLine()` على المجموعة بأكملها، وليس على ملصق فردي.

يخلق هذا المثال مخططًا دائريًا ببيانات افتراضية، يعرض القيم خارج الشرائح، ويفعل [setShowLeaderLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowLeaderLines-boolean-). ينقل ملصقين بعيدًا عن الشرائح باستخدام إزاحتي [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setX-float-) و [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setY-float-)، معبرًا عنها ككسر من عرض وارتفاع المخطط. لا يلزم تقديم عرض تقديمي كمدخل.

تحدد دالة [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getFillFormat--) للخط لونًا أزرقًا صلبًا مع قيمة ألفا 191 من أصل 255، مما يمنح شفافية تقريبية 25٪. يضبط [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) السماكة إلى نقطتين، و [setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) يجعل الخط متقطعًا.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    // تحريك ملصقين بعيدًا عن شرائحهما.
    series.getLabels().get_Item(0).setX(0.10f);
    series.getLabels().get_Item(0).setY(-0.05f);
    series.getLabels().get_Item(1).setX(-0.10f);
    series.getLabels().get_Item(1).setY(0.05f);

    ILineFormat line = series.getLabels().getLeaderLinesFormat().getLine();
    line.getFillFormat().setFillType(FillType.Solid);
    line.getFillFormat().getSolidFillColor().setColor(Color.argb(191, 30, 90, 160));
    line.setWidth(2);
    line.setDashStyle(LineDashStyle.Dash);

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تفعيل خطوط الوصل لا يضمن ظهور خط لكل ملصق. تعتمد الرؤية على موضع الملصق وسلوك تخطيط المخطط. في هذا المثال، يحتوي الملصقان المنفصلان على خطوط وصلة مرئية؛ ولا تحتاج الملصقات القريبة من شرائحها إلى ذلك.

الصورة التالية تُظهر ملف `FormattedLeaderLines.pptx` المحفوظ والمُعرض باستخدام Aspose.Slides:
![مخطط دائري بخطوط وصلة زرقاء نصف شفافة ومتقطعة تربط ملصقين خارجيين بشرائحهما](formatted-leader-lines.png)

## **إضافة صفوف متعددة من ملصقات البيانات فوق مخطط الأعمدة**

يخلق هذا المثال مخطط أعمدة مع صفين من ملصقات البيانات فوق مساحة الرسم. السلسلة A تعرض الأعمدة المرئية، بينما السلسلة B والسلسلة C توفّران الملصقات الإضافية. تُخفى أعمدةهما بإزالة التعبئة والحد. تُحاذى الطريقة [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartseriesgroup/#setOverlap-byte-) جميع السلاسل الثلاثة إلى نفس مراكز الفئة.

تخصيصات [ChartPlotArea](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartplotarea/) تحجز مساحة لصفوف الملصقات. بعد أن تحسب الدالة [Chart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) المواقع الافتراضية، يحافظ كل من [DataLabel.setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabel/#setX-float-) و [DataLabel.setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabel/#setY-float-) على المحاذاة الأفقية ويطبق إزاحات عمودية لترتيب الملصقات في صفين. تظل الأرقام ملصقات بيانات مرتبطة بقيم السلسلة؛ فقط عناوين الصفوف هي أشكال نصية منفصلة.

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
            // إخفاء أعمدة B و C، مع الحفاظ على ملصقات البيانات الخاصة بهما.
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

    // محاذاة السلاسل الثلاثة جميعًا إلى مراكز الفئات نفسها.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap((byte) 100);

    // استخدام خطوط شبكة أقل لهذا المثال المدمج.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // حجز مساحة فوق منطقة الرسم لصفين من ملصقات البيانات.
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
            // الاحتفاظ بالموضع الأفقي الافتراضي. Y هو إزاحة من
            // موضع الملصق الافتراضي، معبرًا عنه ككسر من ارتفاع المخطط.
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // العنوان الصفّي هو الشكل النصي المنفصل الوحيد.
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

![مخطط أعمدة مع صفين من ملصقات البيانات فوق مساحة الرسم](multiple-rows-of-labels.png)

## **الأسئلة الشائعة**

**كيف يمكنني منع تداخل ملصقات البيانات في المخططات الكثيفة؟**  
ادمج وضع الملصقات التلقائي، خطوط الوصل، وتصغير حجم الخط؛ وإذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو اعرض الملصقات فقط للقيم المتطرفة أو النقاط الرئيسية.

**كيف يمكنني إلغاء تمكين الملصقات فقط للقيم الصفرية أو السالبة أو الفارغة؟**  
قُم بتصفية نقاط البيانات قبل تمكين الملصقات وأوقف العرض للقيم التي تساوي 0 أو القيم السالبة أو القيم المفقودة وفق قاعدة محددة.

**كيف يمكنني ضمان نمط ملصق متسق عند التصدير إلى ملفات PDF/صور؟**  
حدد صراحة عائلة الخط وحجمه وتحقق من توفر الخط في بيئة العرض لتجنب اللجوء إلى خط بديل.