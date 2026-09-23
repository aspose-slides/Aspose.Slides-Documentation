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
- موضع التسمية
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم إضافة وتنسيق تسميات بيانات المخطط في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Java للحصول على شرائح أكثر جذبًا."
---
## **مقدمة**

تُظهر تسميات البيانات معلومات حول سلاسل المخطط ونقاط البيانات الفردية، مما يساعد القارئ على تحديد القيم وفهم المخطط. يشرح هذا المقال كيفية تنسيق القيم، عرض النسب المئوية، قراءة نص التسمية، ضبط تباعد تسميات محور الفئات، وتحديد موضع تسميات مخطط الفطيرة.

## **ضبط دقة البيانات في تسميات مخطط البيانات**

استخدم [setNumberFormatOfValues](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) لتنسيق قيم السلسلة. يُنشئ هذا المثال مخططًا خطيًا ببيانات افتراضية، يعرض جدول البيانات الخاص به، ويفعل تسميات القيم للسلسلة الأولى. يَظهر التنسيق `#,##0.00` فاصل الآلاف ومكانين عشريين دون تغيير القيم الأساسية.

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

## **عرض النسبة المئوية كتسميات**

للمخطط العمودي المتراكم، احسب كل قيمة كنسبة مئوية من إجمالي الفئة الخاصة بها وعيّن النص إلى الإطار النصي الذي تُعيده الدالة [getTextFrameForOverriding](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--). يستخدم هذا المثال بيانات المخطط الافتراضية ويعرض النسب المئوية بمكانين عشريين بخط حجم 8 نقاط. يتم تخطي الفئات التي مجموعها صفر لتجنب القسمة على الصفر. أعد حساب نص التسمية المخصص إذا تغيّرت بيانات المخطط.

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

عند حفظ القيم على شكل كسور، استخدم [setNumberFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) لعرض النسب المئوية. مرّر `false` إلى الدالة [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) لتطبيق تنسيق التسمية بشكل مستقل عن الخلايا المصدر.

هذا المثال يُنشئ مخططًا عموديًا متراكمًا بنسبة 100٪ بسلسلتين (حمراء وزرقاء) عبر أربع فئات. كل زوج من القيم يساوي 1. يُظهر تنسيق التسمية `0.0%` القيمة 0.30 كـ30.0٪، بينما يستخدم المحور العمودي منزلتين عشريتين. كلا السلسلتين تستخدم نص تسميات أبيض بحجم 10 نقاط.

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

استخدم [getActualLabelText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idatalabel/#getActualLabelText--) لاسترجاع النص الذي تنتجه إعدادات تسمية البيانات. يكون ذلك مفيدًا عند استخراج التسميات للتقارير، أو البحث في محتوى العرض التقديمي، أو التحقق من صحة المخططات المُولَّدة. في المثال أدناه، يجمع [تنسيق تسمية البيانات](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idatalabelformat/) الافتراضي كلًا من اسم الفئة، اسم السلسلة، والقيمة. يَظهر أحد النقاط قيمته كنسبة مئوية، وآخر يستخدم نصًا مخصصًا من الدالة [getTextFrameForOverriding](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

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

الرقم المخزن في نقطة البيانات يبقى `0.75`، حتى عندما تُظهر تسميتها `75%` مع أسماء الفئة والسلسلة. النص المخصص يستبدل النص المُولَّد للتسمية. تُعيد الدالة [getActualLabelText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idatalabel/#getActualLabelText--) سلسلة التسمية الناتجة في الحالتين. تحقق من الدالة [isVisible](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idatalabel/#isVisible--) بشكل منفصل، كما هو موضح أعلاه، عندما تريد استخراج التسميات المرئية فقط.

## **تعيين مسافة التسمية عن المحور**

استخدم [setLabelOffset](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iaxis/#setLabelOffset-int-) للتحكم في المسافة بين تسميات محور الفئة والمحور. القيمة هي نسبة مئوية من أقصى حجم للخط لتسميات المحور. يُنشئ هذا المثال مخططًا عموديًا مجمعًا ويضبط إزاحة تسميات المحور الأفقي إلى 500. يؤثر هذا الإعداد على تسميات محور الفئة بدلاً من التسميات المرتبطة بنقاط البيانات الفردية.

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

في مخطط الفطيرة، اضبط مواضع تسميات البيانات لتحسين التباعد وإتاحة مساحة لخطوط الربط.

يعرض هذا المثال قيمة أول نقطة بيانات، يضع تسميتها خارج الشريحة، ويضبط إزاحاتها الأفقية والرئيسية باستخدام [setX](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutable/#setX-float-) و[setY](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutable/#setY-float-). هذه الإزاحات نسبية إلى عرض المخطط وارتفاعه على التوالي.

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

![مخطط فطيرة مع موقع تسمية بيانات مُعدَّل](pie-chart-adjusted-label.png)

## **الأسئلة الشائعة**

**كيف يمكنني منع تداخل تسميات البيانات في المخططات المكتظة؟**

استخدم توزيع تلقائي للتسمية، وربط الخطوط، وتقليل حجم الخط؛ إذا لزم الأمر، اخفِ بعض الحقول (مثل الفئة) أو اعرض التسميات فقط للقيم المتطرفة أو النقاط الرئيسية.

**كيف يمكنني إلغاء تفعيل التسميات للقيم الصفرية أو السلبية أو الفارغة؟**

قم بترشيح نقاط البيانات قبل تمكين التسميات وأوقف العرض للقيم 0 أو القيم السلبية أو القيم المفقودة وفقًا لقاعدة محددة.

**كيف أضمن تناسق نمط التسمية عند التصدير إلى PDF/صور؟**

حدد صراحةً عائلة الخط وحجمه وتأكد من توفر الخط في بيئة العرض لتجنب الانتقال إلى خط بديل.