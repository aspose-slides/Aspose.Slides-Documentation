---
title: إدارة تسميات بيانات المخطط في العروض التقديمية باستخدام Java
linktitle: تسمية البيانات
type: docs
url: /ar/java/chart-data-label/
keywords:
- مخطط
- تسمية بيانات
- دقة البيانات
- نسبة مئوية
- مسافة التسمية
- موضع التسمية
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إضافة وتنسيق تسميات بيانات المخططات في عروض PowerPoint باستخدام Aspose.Slides for Java للحصول على شرائح أكثر جاذبية."
---
## **المقدمة**

تقوم تسميات البيانات بعرض معلومات حول سلاسل المخططات والنقاط البيانات الفردية، مما يساعد القارئ على تحديد القيم وفهم المخطط. توضح هذه المقالة كيفية تنسيق القيم، عرض النسب المئوية، قراءة نص التسمية، التحكم في التسميات خارج الحد الأقصى للمحور، تعديل تباعد تسميات محور الفئات، وتحديد موضع تسميات المخطط الدائري.

## **عدد تسميات البيانات الظاهرة**

استخدم [getCountOfVisibleDataLabels](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelcollection/#getCountOfVisibleDataLabels--) للتحقق من عدد تسميات البيانات التي تم تمكين عرضها قبل نشر العرض التقديمي. على عكس [getCount](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelcollection/#getCount--)، الذي يُعيد إجمالي عدد التسميات في المجموعة، فإنه يأخذ في الاعتبار الإعدادات الافتراضية للسلسلة وإعدادات كل تسمية بشكل منفصل.

هذا المثال يُنشئ مخططًا عموديًا بسلسلة واحدة وثلاث نقاط بيانات. يصل إلى مجموعة تسميات السلسلة عبر [getLabels](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getLabels--) ويطبع عدد التسميات الظاهرة مع تغير الإعدادات: **0, 3, 2, 3**. يظل العدد الإجمالي **3**.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesCell = workbook.getCell(0, 0, 1, "Values");
    IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

    for (int i = 0; i < 3; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IDataLabelCollection labels = series.getLabels();
    System.out.println("Total: " + labels.getCount() + "; visible: " + labels.getCountOfVisibleDataLabels()); // الإجمالي: 3; الظاهر: 0

    labels.getDefaultDataLabelFormat().setShowValue(true);
    System.out.println("Visible: " + labels.getCountOfVisibleDataLabels()); // الظاهر: 3

    labels.get_Item(1).getDataLabelFormat().setShowValue(false);
    System.out.println("Visible: " + labels.getCountOfVisibleDataLabels()); // الظاهر: 2

    labels.get_Item(1).getDataLabelFormat().setShowLegendKey(true);
    System.out.println("Visible: " + labels.getCountOfVisibleDataLabels()); // الظاهر: 3
} finally {
    presentation.dispose();
}
```

توفر طريقة [getDefaultDataLabelFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelcollection/#getDefaultDataLabelFormat--) الإعدادات الافتراضية. تمرير `true` إلى [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) هناك يُظهر القيم لجميع الثلاث تسميات. تمرير `false` عبر [getDataLabelFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getDataLabelFormat--) لتسمية واحدة يتجاوز هذا الإعداد لتلك التسمية المحددة. تمرير `true` إلى [setShowLegendKey](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowLegendKey-boolean-) يجعل تلك التسمية تُحسب مرة أخرى كظاهرة، رغم أن قيمتها لا تزال مخفية.

يعكس العدد الظاهر إعدادات الظهور. لا يقيس ما إذا كانت التسميات متداخلة أو مقطوعة أو قابلة للقراءة في المخطط المرسوم.

## **تعيين دقة البيانات في تسميات مخطط البيانات**

استخدم [setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) لتنسيق قيم السلسلة. يُنشئ هذا المثال مخططًا خطيًا ببيانات افتراضية، يعرض جدول البيانات الخاص به، ويمكّن تسميات القيم للسلسلة الأولى. يُظهر التنسيق `#,##0.00` فاصل الآلاف ومكانين عشريين دون تغيير القيم الأساسية.

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

لتنسيق الخلايا الرقمية في دفتر عمل مدمج بالمخطط، اطلع على [Set Custom Number Formats for Workbook Cells](/slides/ar/java/chart-workbook/#set-custom-number-formats-for-workbook-cells). يوضح ذلك المثال أيضًا أن تسميات القيم تتبع تنسيقات خلايا المصدر مع الحفاظ على القيم الرقمية المخزنة.

## **عرض النسبة المئوية كتلخيصات**

للمخطط العمودي المتراكم، احسب كل قيمة كنسبة مئوية من إجمالي الفئة وعيّن النص إلى إطار النص الذي تُعيده [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--). يستخدم هذا المثال بيانات المخطط الافتراضية ويعرض النسب المئوية بمكانين عشريين بخط 8 نقاط. تُهمل الفئات التي مجموعها صفر لتجنب القسمة على الصفر. أعد حساب نص التسمية المخصص إذا تغيرت بيانات المخطط.

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

## **تعيين علامة النسبة المئوية مع تسميات مخطط البيانات**

عند تخزين القيم ككسر، استخدم [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) لعرض النسب المئوية. مرّر `false` إلى [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) لتطبيق تنسيق التسمية بشكل مستقل عن خلايا المصدر.

هذا المثال يُنشئ مخططًا عموديًا متراكمًا بنسبة 100% مع سلسلتين باللون الأحمر والأزرق عبر أربع فئات. كل زوج من القيم يساوي 1. يُظهر تنسيق التسمية `0.0%` القيمة 0.30 كـ30.0%، بينما يستخدم المحور العمودي منزلتين عشريتين. تستخدم السلسلتان نصًا أبيضًـا بحجم 10 نقاط.

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

استخدم [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) لاسترداد النص الناتج عن إعدادات تسمية البيانات. يكون ذلك مفيدًا عند استخراج التسميات للتقارير، أو البحث في محتوى العرض التقديمي، أو التحقق من صحة المخططات المُولدة. في المثال أدناه، يجمع [تنسيق تسمية البيانات](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) الافتراضي كل من اسم الفئة واسم السلسلة والقيمة. تُنسق نقطة واحدة قيمتها كنسبة مئوية، وأخرى تستخدم نصًا مخصصًا من [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

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

يبقى الرقم المخزن في نقطة البيانات هو `0.75`، حتى عندما تُظهر تسميتها `75%` مع أسماء الفئة والسلسلة. يستبدل النص المخصص نص التسمية المُولَّد. تُعيد [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) سلسلة التسمية الناتجة في الحالتين. تحقق من [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--) بشكل منفصل، كما هو موضح أعلاه، عندما تريد استخراج التسميات الظاهرة فقط.

## **التحكم في تسميات البيانات خارج الحد الأقصى للمحور**

عند تحديد نطاق المحور يدويًا، قد تتجاوز بعض نقاط البيانات الحد الأقصى. استخدم [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) للتحكم فيما إذا كانت تسميات البيانات تُعرض. يغيّر هذا الإعداد ظهور التسميات؛ لكنه لا يغير نطاق المحور أو القيم الأساسية.

ينشئ المثال أدناه مخططًا عموديًا متجميعًا ثنائي الأبعاد بقيم 60 و120. يمرّر `false` إلى [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) ويضبط الحد الأقصى على 100 باستخدام [setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-) للمحور العمودي. الشريحة الأولى تسمح بالتسميات خارج الحد الأقصى؛ نسخة من تلك الشريحة تعطلها. تُحفظ كلتا الشريحتين في `DataLabelsOverMaximum.pptx`.

فعّل تسميات القيم باستخدام [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). لا يُفعِّل الإعداد على مستوى المخطط عرض القيم بنفسه ولا يتجاوز إيقاف عرض القيمة لتسمية فردية. يُفعِّل هذا المثال القيم للسلسلة بالكامل ويستخدم [setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-) لوضع التسميات في الطرف الخارجي لكل عمود.

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

الصورة التالية تُظهر الشرائح المحفوظة والتي تم عرضها بواسطة Microsoft PowerPoint. مع `true`، تكون التسمية **120** ظاهرة عند الحد الأعلى؛ مع `false`، تكون مخفية. تبقى التسمية **60** ظاهرة، يبقى الحد الأقصى للمحور **100**، وتبقى نقطة البيانات الثانية **120** في الحالتين.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![مخطط PowerPoint يُظهر تسمية القيمة 120 مع حد أقصى للمحور يساوي 100](data-labels-over-maximum-true.png) | ![مخطط PowerPoint يخفي تسمية القيمة 120 مع حد أقصى للمحور يساوي 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
هذا المثال يستخدم مخططًا عموديًا ثنائي الأبعاد مع محور قيم. المخططات التي لا تحتوي على محور قيم، مثل المخططات الدائرية ومخططات الحلقة، لا تملك حدًا أقصى للمحور يمكن تقييده بهذه الطريقة.
{{% /alert %}}

## **تحديد مسافة التسمية عن المحور**

استخدم [setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-) للتحكم في المسافة بين تسميات محور الفئات والمحور. القيمة تُعبّر عن نسبة مئوية من أقصى حجم خط لتسميات المحور. يُنشئ هذا المثال مخططًا عموديًا متجميعًا ويضبط إزاحة تسمية المحور الأفقي إلى 500. يؤثر هذا الإعداد على تسميات محور الفئات وليس على التسميات المرتبطة بنقاط البيانات الفردية.

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

## **ضبط موضع التسمية**

في المخطط الدائري، اضبط مواضع تسميات البيانات لتحسين التباعد وإتاحة مساحة لخطوط الوصل.

يعرض هذا المثال قيمة نقطة البيانات الأولى، يضع её التسمية خارج القطعة، ويضبط الإزاحات الأفقية والرأسية باستخدام [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) و [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-). تُعبر هذه الإزاحات كنسبة من عرض وارتفاع المخطط.

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

![مخطط دائري مع ضبط موضع تسمية البيانات](pie-chart-adjusted-label.png)

## **تنسيق خطوط الوصل**

عند وضع تسميات المخطط الدائري خارج القطع، تساعد خطوط الوصل القارئ على ربط كل قيمة بالقطعة الصحيحة. يمكن للون المتباين وخط سميك قليلاً أن يجعل هذه الوصلات أسهل في المتابعة، بينما يضمن الشفافية والنمط المتقطع أن لا تكون الخطوط بارزة جدًا.

استخدم [getLeaderLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelcollection/#getLeaderLinesFormat--) لتنسيق خطوط الوصل على مستوى مجموعة تسميات بيانات السلسلة. تنطبق الإعدادات في `series.getLabels().getLeaderLinesFormat().getLine()` على المجموعة ككل، وليس على تسمية فردية.

هذا المثال يُنشئ مخططًا دائريًا ببيانات افتراضية، يعرض القيم خارج القطع، ويفعِّل [setShowLeaderLines](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowLeaderLines-boolean-). ينقل تسميتين بعيدًا عن قطعهما باستخدام إزاحات [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) و [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-)، معبّرة ككسر من عرض وارتفاع المخطط. لا يلزم وجود عرض تقديمي إدخالي.

يُعيّن [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) للخط لونًا أزرق صلبًا مع قيمة ألفا 191 من 255، ما يُعطي تقريبًا 25٪ شفافية. تُحدد [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) السمك إلى نقطتين، وتُحوّل [setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) الخط إلى متقطع.

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

    // نقل تسميتين أبعد من القطع الخاصة بهما.
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

تفعيل خطوط الوصل لا يضمن ظهور خط لكل تسمية. يعتمد الظهور على موضع التسمية وسلوك تخطيط المخطط. في هذا المثال، للملصقتين المنقولتين خطوط وصل ظاهرة؛ أما التسميات القريبة من القطع فلا تحتاج إلى خطوط.

الصورة التالية تُظهر ملف `FormattedLeaderLines.pptx` المحفوظ والمُعرض بواسطة Aspose.Slides:

![مخطط دائري بخطوط وصل زرقاء شبه شفافة ومتقطعة تربط تسميتين خارجيتين بقطعهما](formatted-leader-lines.png)

## **إضافة عدة صفوف من تسميات البيانات أعلى مخطط عمودي**

هذا المثال يُنشئ مخططًا عموديًا مع صفين من تسميات البيانات فوق مساحة الرسم. تُظهر السلسلة A الأعمدة الظاهرة، بينما توفر السلسلة B والسلسلة C التسميات الإضافية. تُخفي أعمدتهما بإزالة التعبئة والحد. تُحاذي الطريقة [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) الثلاث سلاسل إلى نفس مراكز الفئات.

تُخصص إعدادات [ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) مساحة لصفوف التسميات. بعد أن تُحسب المواضع الافتراضية بواسطة [Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/)، تُحافظ [DataLabel.setX و DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/) على المحاذاة الأفقية وتُطبق إزاحات عمودية لترتيب التسميات في صفين. تظل الأرقام تسميات بيانات مربوطة بقيم السلسلة؛ فقط عناوين الصفوف هي أشكال نصية منفصلة.

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
            // إخفاء أعمدة B و C، مع إبقاء تسميات البيانات.
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

    // محاذاة السلاسل الثلاثة على نفس مراكز الفئات.
    chart.getChartData().getSeries().get_Item(0)
            .getParentSeriesGroup().setOverlap((byte) 100);

    // استخدام خطوط شبكة أقل لهذا المثال المدمج.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // حجز مساحة فوق منطقة الرسم لصفين من تسميات البيانات.
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

        // فقط عنوان الصف هو شكل نصي منفصل.
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

![مخطط عمودي مع صفين من تسميات البيانات فوق مساحة الرسم](multiple-rows-of-labels.png)

## **الأسئلة المتداولة**

**كيف يمكنني منع تداخل تسميات البيانات في المخططات المكتظة؟**

امزج بين وضعية التسمية التلقائية، خطوط الوصل، وتقليل حجم الخط؛ إذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو اعرض التسميات فقط للقيم القصوى أو النقاط الرئيسة.

**كيف يمكنني إلغاء تمكين التسميات للقيم الصفرية أو السلبية أو الفارغة فقط؟**

قم بفلترة نقاط البيانات قبل تمكين التسميات وأوقف العرض للقيم التي تساوي 0 أو القيم السلبية أو القيم المفقودة وفق قاعدة محددة.

**كيف يمكنني ضمان أسلوب تسمية متسق عند التصدير إلى PDF/صور؟**

حدد صراحةً عائلة الخط وحجمه وتأكد من توافر الخط في بيئة العرض لتجنب الاعتماد على الخطوط البديلة.