---
title: إدارة تسميات بيانات المخطط في العروض التقديمية باستخدام Java
linktitle: تسمية البيانات
type: docs
url: /ar/java/chart-data-label/
keywords:
- مخطط
- تسمية البيانات
- دقة البيانات
- نسبة مئوية
- مسافة التسمية
- موقع التسمية
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إضافة وتنسيق تسميات بيانات المخطط في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Java لإنشاء شرائح أكثر جاذبية."
---
## **مقدمة**

تُظهر تسميات البيانات معلومات حول سلاسل المخطط ونقاط البيانات الفردية، مما يساعد القراء على تحديد القيم وفهم المخطط. يشرح هذا المقال كيفية تنسيق القيم، وعرض النسب المئوية، وقراءة نص التسمية، والتحكم في التسميات خارج الحد الأقصى للمحور، وضبط تباعد تسميات محور الفئة، وتحديد موقع تسميات مخطط الدائرة.

## **تعيين دقة البيانات في تسميات المخطط**

استخدم [setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) لتنسيق قيم السلسلة. يؤدي هذا المثال إلى إنشاء مخطط خط ببيانات افتراضية، يعرض جدول البيانات الخاص به، ويفعل تسميات القيم للسلسلة الأولى. التنسيق `#,##0.00` يعرض فاصل الآلاف ومكانين عشريين دون تغيير القيم الأساسية.

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

لتنسيق الخلايا الرقمية في دفتر العمل المضمّن بالمخطط، راجع [تحديد تنسيقات أرقام مخصصة لخلايا دفتر العمل](/slides/ar/java/chart-workbook/#set-custom-number-formats-for-workbook-cells). يوضح هذا المثال أيضًا تسميات القيم التي تتبع تنسيقات الخلايا المصدر مع الحفاظ على القيم الرقمية المخزنة.

## **عرض النسبة المئوية كتسميات**

لإنشاء مخطط أعمدة مكدس، احسب كل قيمة كنسبة مئوية من إجمالي الفئة الخاصة بها وعيّن النص إلى الإطار النصي الذي تُعيده الدالة [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--). يستخدم هذا المثال بيانات المخطط الافتراضية ويعرض النسب المئوية بمكانين عشريين بخط بحجم 8 نقاط. تُتخطى الفئات التي يكون مجموعها صفرًا لتجنب القسمة على الصفر. أعد حساب نص التسمية المخصص إذا تغيرت بيانات المخطط.

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

## **تعيين علامة النسبة المئوية مع تسميات بيانات المخطط**

عند تخزين القيم على شكل كسور، استخدم [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) لعرض النسب المئوية. مرّر القيمة `false` إلى الدالة [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) لتطبيق تنسيق التسمية بشكل مستقل عن خلايا المصدر.

هذا المثال ينشئ مخطط أعمدة مكدس بنسبة 100٪ يحتوي على سلسلتين حمراء وزرقاء عبر أربع فئات. كل زوج من القيم يساوي 1. يُظهر تنسيق التسمية `0.0%` القيمة 0.30 كـ 30.0٪، بينما يستخدم المحور الرأسي مكانين عشريين. تستخدم السلسلتان نصًا أبيضًا بحجم 10 نقاط للتسميات.

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

## **قراءة النص الفعلي لتسميات البيانات**

استخدم [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) لاسترجاع النص الذي تُنتجه إعدادات تسمية البيانات. يكون ذلك مفيدًا عند استخراج التسميات للتقارير، أو البحث في محتوى العرض التقديمي، أو التحقق من صحة المخططات المُنشأة. في المثال أدناه، يجمع [تنسيق تسمية البيانات](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) الافتراضي بين اسم كل فئة، واسم السلسلة، والقيمة. تُنسيق نقطة واحدة قيمتها كنسبة مئوية، وتستخدم أخرى نصًا مخصصًا من الدالة [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

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

تظل القيمة المخزنة في نقطة البيانات هي `0.75`، حتى عندما تظهر تسميتها `75%` مع أسماء الفئة والسلسلة. يستبدل النص المخصص النص المُولَّد للتسمية. تُعيد الدالة [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) سلسلة التسمية الناتجة في الحالتين. تحقق من [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--) بشكل منفصل، كما هو موضح أعلاه، عندما ترغب في استخراج التسميات الظاهرة فقط.

## **التحكم في تسميات البيانات خارج الحد الأقصى للمحور**

عند تحديد نطاق المحور يدويًا، قد تتجاوز بعض نقاط البيانات الحد الأقصى له. استخدم [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) للتحكم فيما إذا كانت تسميات البيانات الخاصة بها تُظهر. يغيّر هذا الإعداد رؤية التسميات؛ ولا يغيّر نطاق المحور أو القيم الأساسية للبيانات.

ينشئ المثال أدناه مخطط أعمدة متجمع ثنائي الأبعاد بقيم 60 و120. يمرّر القيمة `false` إلى الدالة [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) ويعيّن الحد الأقصى إلى 100 باستخدام [setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-) على المحور الرأسي. الشريحة الأولى تسمح بالتسميات التي تتجاوز الحد الأقصى؛ نسخة تلك الشريحة تعطلها. تُحفظ كلتا الشريحتين في الملف `DataLabelsOverMaximum.pptx`.

فعّل تسميات القيم باستخدام [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). لا يُفعّل إعداد مستوى المخطط عرض القيم بحد ذاته ولا يتجاوز إيقاف عرض القيمة لتسمية فردية. يُفعّل هذا المثال القيم لكامل السلسلة ويستخدم [setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-) لوضع التسميات في الطرف الخارجي لكل عمود.

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

تُظهر الصور التالية الشرائح المحفوظة التي تم عرضها بواسطة Microsoft PowerPoint. مع القيمة `true`، تكون التسمية **120** مرئية عند الحد العلوي؛ ومع القيمة `false`، تُخفى. تظل التسمية **60** مرئية، يبقى الحد الأقصى للمحور عند **100**، وتظل نقطة البيانات الثانية **120** في كلا الحالتين.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
يستخدم هذا المثال مخطط أعمدة ثنائي الأبعاد مع محور قيم. المخططات التي لا تحتوي على محور قيم، مثل مخططات الدائرة والدوامة، ليس لديها حد أقصى للمحور لتحديده بهذه الطريقة.
{{% /alert %}}

## **تعيين مسافة التسمية من المحور**

استخدم [setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-) للتحكم في المسافة بين تسميات محور الفئة والمحور. القيمة هي نسبة مئوية من الحد الأقصى لحجم خط تسميات المحور. يُنشئ هذا المثال مخطط أعمدة متجمع ويعيّن إزاحة تسمية المحور الأفقي إلى 500. يؤثر هذا الإعداد على تسميات محور الفئة بدلاً من التسميات المرتبطة بنقاط البيانات الفردية.

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

## **ضبط موقع التسمية**

في مخطط الدائرة، اضبط مواضع تسميات البيانات لتحسين التباعد وإتاحة مساحة لخطوط الربط.

يعرض هذا المثال قيمة نقطة البيانات الأولى، يضع تسميتها خارج الشريحة، ويضبط إزاحتها الأفقية والعمودية باستخدام [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) و [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-). تُعد هذه الإزاحات نسبة إلى عرض وارتفاع المخطط، على التوالي.

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

![مخطط دائرة مع موضع تسمية بيانات معدل](pie-chart-adjusted-label.png)

## **تنسيق خطوط الربط**

عندما تكون تسميات مخطط الدائرة خارج شرائحها، تساعد خطوط الربط القراء على مطابقة كل قيمة مع الشريحة الصحيحة. يمكن للون المتباين والخط السميك قليلاً أن يجعل هذه الروابط أسهل في المتابعة، بينما يظل الشفافية والنمط المتقطع تجعل الخطوط غير بارزة بصريًا.

استخدم [getLeaderLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelcollection/#getLeaderLinesFormat--) لتنسيق خطوط الربط على مستوى مجموعة تسميات بيانات السلسلة. تُطبق الإعدادات في `series.getLabels().getLeaderLinesFormat().getLine()` على المجموعة، وليس على تسمية فردية.

ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية، يعرض القيم خارج الشرائح، ويفعل [setShowLeaderLines](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowLeaderLines-boolean-). ينقل تسميتين بعيدًا عن شرائحهما باستخدام إزاحات [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) و [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-)، معبرًا عنها ككسر من عرض وارتفاع المخطط. لا يلزم عرض تقديمي كمدخل.

تحدد الدالة [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) للخط لونًا أزرقًا صلبًا بقيمة ألفا 191 من 255، مما يضيف شفافية تقريبًا 25٪. تُعيّن الدالة [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) السماكة إلى نقطتين، وتُحوّل الدالة [setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) الخط إلى نمط متقطع.

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

    // نقل تسميتين بعيدًا عن شرائحهما.
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

تفعيل خطوط الربط لا يضمن ظهور خط لكل تسمية. تعتمد الرؤية على موضع التسمية وسلوك تخطيط المخطط. في هذا المثال، تحتوي التسميتين المنقوتين على خطوط ربط مرئية؛ ولا تحتاج التسميات التي تبقى قريبة من شرائحها إلى ذلك.

تُظهر الصورة التالية الملف المحفوظ `FormattedLeaderLines.pptx` معروضًا باستخدام Aspose.Slides:
![مخطط دائرة بخطوط ربط زرقاء شبه شفافة متقطعة تربط تسميتين خارجيتين بشرائحهما](formatted-leader-lines.png)

## **إضافة صفوف متعددة من تسميات البيانات فوق مخطط العمود**

ينشئ هذا المثال مخططًا عموديًا يحتوي على صفين من تسميات البيانات فوق منطقة الرسم. تعرض السلسلة A الأعمدة الظاهرة، بينما توفر السلسلة B والسلسلة C التسميات الإضافية. تُخفى أعمدتهما بإزالة التعبئة والحد. تُطابق الطريقة [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) جميع السلاسل الثلاثة مع مراكز الفئات نفسها.

تُخصّص إعدادات [ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) مساحة لصفوف التسميات. بعد أن تحسب الدالة [Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) المواضع الافتراضية، تُحافظ الدوال [DataLabel.setX و DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/) على المحاذاة الأفقية وتطبيق إزاحات عمودية لترتيب التسميات في صفين. تظل الأرقام تسميات بيانات مرتبطة بقيم السلسلة؛ فقط عناوين الصفوف هي أشكال نصية منفصلة.

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
            // إخفاء أعمدة B و C، لكن الإبقاء على تسميات البيانات الخاصة بهما.
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

    // محاذاة السلاسل الثلاث جميعها مع نفس مراكز الفئات.
    chart.getChartData().getSeries().get_Item(0)
            .getParentSeriesGroup().setOverlap((byte) 100);

    // استخدام خطوط شبكية أقل لهذا المثال المدمج.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // حجز مساحة فوق الرسم لصفين من تسميات البيانات.
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
            // الاحتفاظ بالموقع الأفقي الافتراضي. Y هو إزاحة من
            // الموقع الافتراضي للتسمية، معبرًا عنه كنسبة من ارتفاع المخطط.
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // العنوان الصفّي هو الشكل النصي المنفصل الوحيد.
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

![مخطط عمودي بصفين من تسميات البيانات فوق منطقة الرسم](multiple-rows-of-labels.png)

## **الأسئلة المتكررة**

**كيف يمكنني منع تداخل تسميات البيانات في المخططات المكتظة؟**

استخدم الجمع بين وضع التسميات التلقائي، وخطوط الربط، وتقليل حجم الخط؛ إذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو اعرض التسميات فقط للقيم المتطرفة أو النقاط الرئيسة.

**كيف يمكنني إلغاء تمكين التسميات فقط للقيم الصفرية أو السالبة أو الفارغة؟**

قم بترشيح نقاط البيانات قبل تفعيل التسميات وأوقف عرض القيم التي تساوي 0 أو القيم السالبة أو القيم المفقودة وفق قاعدة معرفة.

**كيف يمكنني ضمان نمط تسميات ثابت عند التصدير إلى PDF/صور؟**

حدد صراحةً عائلة الخط وحجمه وتأكد من توفر الخط في بيئة العرض لتجنب fallback.