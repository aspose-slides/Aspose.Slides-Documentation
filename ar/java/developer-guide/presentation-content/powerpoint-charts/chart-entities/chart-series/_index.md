---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية في Java
linktitle: سلاسل البيانات
type: docs
url: /ar/java/chart-series/
keywords:
- سلاسل المخطط
- تداخل السلسلة
- لون السلسلة
- اسم السلسلة
- نقطة البيانات
- خلية دفتر العمل
- فجوة السلسلة
- قيمة سالبة
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إدارة سلاسل المخطط، نقاط البيانات، خلايا دفتر العمل، التنسيق، التداخل، عرض الفجوة، والقيم السالبة في العروض التقديمية باستخدام Java."
---
## **نظرة عامة**

يخزن المخطط بياناته المرسومة في دفتر بيانات المخطط. يمثل [IChartSeries](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartseries/) مجموعة واحدة من القيم ذات الصلة، وكل [IChartDataPoint](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatapoint/) في السلسلة يشير إلى خلية أو أكثر في دفتر العمل. توفر كائنات [IChartCategory](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartcategory/) التسميات أو قيم التجميع المشتركة بين السلاسل. لذا فإن اسم السلسلة والفئات وقيم النقاط مرتبطة بكائنات [IChartDataCell](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/) بدلاً من تخزينها كنص عرض فقط.

بالنسبة إلى مخطط الفئات النموذجي، يستخدم دفتر العمل الافتراضي الصف 0 لأسماء السلاسل، والعمود 0 لأسماء الفئات، وتُستَخدم الخلايا المتبقية لقيم السلسلة. فهارس ورقة العمل والصف والعمود التي تُمرَّر إلى [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) هي صفر‑مؤشرة. هذا التخطيط مفيد عندما تنشئ مخططًا ببيانات افتراضية، ولكن لا تُفترض أن كل مخطط موجود يستخدمه. بالنسبة إلى عرض تقديم تم تحميله، افحص الخلايا التي تشير إليها السلاسل والفئات ونقاط البيانات قبل تغيير قيم دفتر العمل.

إعدادات المخطط لها ثلاث نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [IChartSeries.getFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartseries/#getFormat--)، توفر المظهر الافتراضي لكل النقاط في سلسلة واحدة.
- إعدادات على مستوى نقطة البيانات، مثل [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatapoint/#getFormat--)، تتجاوز مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تنطبق على السلاسل المتوافقة التي تنتمي إلى نفس [IChartSeriesGroup](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartseriesgroup/). يتم الوصول إلى المجموعة عبر [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) عندما تحتاج إلى تعيين خيارات مثل التداخل أو عرض الفجوة.

عندما لا يتم تعيين تعبئة صريحة للنقطة أو السلسلة، يحدد نمط المخطط والسمات المظهر التلقائي. عندما تكون هناك تنسيقات لكل من السلسلة والنقطة، تتفوق تنسيق النقطة لتلك النقطة.

![سلسلة المخطط في PowerPoint](chart-series-powerpoint.png)

## **تعيين تداخل سلسلة المخطط**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartseries/#getOverlap--) يبلغ عن مقدار تداخل الأعمدة أو الأشرطة في مخطط ثنائي الأبعاد، من -100 إلى 100 بالمئة. وهو إسقاط للقراءة فقط للإعداد في مجموعة السلسلة الأصلية. استخدم [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) لتحديث كل السلاسل المتوافقة في تلك المجموعة. ينطبق هذا الخيار على أنواع المخططات التي تعرض أشرطة أو أعمدة مجموعة؛ ولا يُؤثر على مجموعات السلاسل غير المرتبطة في مخطط مركب.

المثال التالي يعين التداخل للمجموعة التي تحتوي على السلسلة الأولى:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // المخطط الجديد يحتوي على سلاسل وعناصر فئة وقيم تجريبية.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![تداخل السلسلة](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

استخدم [IChartSeries.getFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartseries/#getFormat--) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كان للنقطة تعبئة صريحة، فإن إعداد [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatapoint/#getFormat--) يتجاوز تعبئة السلسلة لتلك النقطة.

المثال التالي يطبق تعبئة صلبة باللون الأزرق على السلسلة الأولى:

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

النتيجة:

![لون السلسلة](series_color.png)

## **تغيير اسم السلسلة**

يُخزَّن اسم السلسلة في دفتر بيانات المخطط وعادةً ما يُعرض في المفتاح. في دفتر العمل الافتراضي الذي يُنشَأ لمخطط عمود مجموعات، تكون الخلية B1 في الصف 0 والعمود 1 وتحتوي على اسم السلسلة الأولى. الثوابت المسماة في المثال التالي تجعل هذا الهيكل واضحًا:

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

يمكنك أيضًا تحديث الخلية التي يُرجعها [IChartSeries.getName](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartseries/#getName--). يتيح هذا النهج تجنب الافتراض بوجود صف أو عمود معين في مخطط موجود:

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

النتيجة:

![اسم السلسلة](series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) يُعيد اللون الذي يُحسب من فهرس السلسلة ونمط المخطط. هذا هو اللون المستخدم عندما لا يتم تعريف تعبئة السلسلة صراحة. قراءة الطريقة تُعيد اللون المُحسب؛ ولا تُعيّن تعبئة جديدة.

المثال التالي يطبع اللون التلقائي لكل سلسلة افتراضية:

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

مخرجات المثال للنمط الافتراضي للمخطط:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

الألوان الدقيقة تعتمد على نمط المخطط والسمات.

## **تعيين لون تعبئة عكسي لسلسلة المخطط**

بالنسبة إلى سلاسل الأشرطة والعمود والفقاعات، يمكن لـ [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) عرض القيم السالبة بتعبئة مختلفة. عيّن تعبئة السلسلة العادية إلى صلبة، فعّل العكس، وعيِّن لون القيمة السالبة عبر [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). الأرقام السالبة تظل دون تغيير في دفتر العمل؛ يتغير لون عرضها فقط.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. يحتوي الصف 0 من ورقة العمل على اسم السلسلة، والعمود 0 على أسماء الفئات، والعمود 1 على القيم:

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

النتيجة:

![لون التعبئة الصلبة المعكوس](inverted_solid_fill_color.png)

يمكنك تفعيل العكس لنقطة واحدة عبر [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). في المثال التالي يُعطَّل العكس للسلسلة ويُفعَّل فقط للنقطة المحددة. تُعيَّن النقطة أيضًا قيمة سالبة لتكون النتيجة مرئية:

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

## **مسح قيمة نقطة بيانات محددة**

لجعل نقطة واحدة فارغة دون إزالة النقاط الأخرى، عيّن الخلية الداعمة في دفتر العمل إلى `null`. بالنسبة إلى مخطط عمودي، تكون القيمة المرسومة متاحة عبر [IChartDataPoint.getValue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatapoint/#getValue--). تبقى نقطة البيانات في نفس موضع الفئة، لكن المخطط يتعامل مع قيمتها كخالية وفقًا لإعدادات قيمة الخلايا الفارغة في المخطط.

المثال التالي يمسح فقط النقطة الثانية في السلسلة الأولى:

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

تستخدم مخططات التشتت خلايا X وY منفصلة، وتستخدم مخططات الفقاعات أيضًا خلية حجم. امسح الخلية التي تمثل القيمة التي تنوي إزالتها فقط. لا تستدعِ [IChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatapointcollection/#clear--) عندما تريد الإبقاء على النقاط الأخرى، لأن هذه الطريقة تزيل كل نقاط البيانات من المجموعة.

## **التحكم في عرض الخلايا الفارغة**

الخلايا المخفية التي تحتوي على قيم هي حالة منفصلة عن الخلايا الفارغة. لإدراج أو استبعاد البيانات من صفوف وأعمدة ورقة العمل المخفية، طالع [إدراج البيانات من الصفوف والأعمدة المخفية](/slides/ar/java/chart-workbook/#include-data-from-hidden-rows-and-columns).

تمثل الخلية الفارغة في دفتر العمل بيانات مفقودة؛ بينما تمثل الخلية التي تحتوي على `0` قيمة رقمية معروفة. استدعِ [IChartDataCell.setValue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) مع `null` لجعل الخلية فارغة. الصفر الرقمي يبقى صفرًا بغض النظر عن إعداد الخلية الفارغة.

استخدم [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) لاختيار كيفية عرض المخطط للخلايا الفارغة. ينطبق هذا الإعداد على المخطط بأكمله. إنه يغيّر طريقة رسم الفارغات دون ملء الخلية الفارغة في دفتر العمل بصفر أو قيمة مُق interpolated.

المثال التالي المستقل يُنشئ مخطط خط مع سلسلة واحدة، يمسح القيمة لليوم 3، ويحفظ المخطط نفسه بثلاثة أنماط. لا يلزم ملف إدخال. يستخدم [IChartDataWorkbook](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/) ورقة عمل 0، العمود 0 لتسميات الفئات، والعمود 1 للقيم؛ الصف 0 يحمل اسم السلسلة. البيانات النهائية هي `10, 20, empty, 30, 40`.

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

    // اتّرك اليوم 3 فارغًا فعلًا، مع الاحتفاظ بفئته ونقطة البيانات الخاصة به.
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

كل ملف ناتج يُخزن النمط المُعيَّن قبل الحفظ: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx`، و`empty_cells_Span.pptx`. لحفظ نسخة واحدة فقط، عيّن النمط المطلوب واحفظ العرض مرةً واحدة بدلاً من التكرار على الأنماط.

المقارنة أدناه تُظهر نفس البيانات في الملفات الثلاثة. اليوم 3 فارغ في دفتر العمل في جميع الحالات:

![مخططات الخط مع بيانات متماثلة: الفجوة تقطع الخط عند اليوم 3، الصفر يُخفض الخط إلى الصفر، والامتداد يربط اليوم 2 باليوم 4.](display_blanks_as.png)

التأثير المرئي يعتمد على نوع المخطط. يُسهل مخطط الخط مقارنة جميع الأنماط الثلاثة. لا تمتلك مخططات الأشرطة والأعمدة خطًا يربط عبر فئة مفقودة، لذا لا يمكن لـ `Span` إنتاج الجزء المتصل كما هو موضح أعلاه؛ كما أن العمود المفقود والعمود ذو الارتفاع صفر قد يبدوان متشابهين. بالمثل، مخطط التشتت مع العلامات فقط لا يمتلك خطًا موصولًا. لا تتوقع ثلاث نتائج متميزة لكل نوع مخطط؛ تحقق من النتيجة للنوع الذي تستخدمه.

## **تعيين عرض الفجوة بين السلاسل**

عرض الفجوة هو المسافة بين مجموعات الأشرطة أو الأعمدة المتجاورة، تُعبَّر كنسبة مئوية من عرض العمود أو الشريط. مثل التداخل، ينتمي إلى مجموعة السلسلة الأصلية وليس إلى سلسلة واحدة. استدعِ [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) مرةً واحدة للمجموعة. القيمة الأكبر تُنشئ مساحة أكبر بين المجموعات؛ والقيمة الأصغر تجعلها أكثر كثافة.

المثال التالي يغيّر عرض الفجوة ويحفظ العرض النهائي فقط:

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

النتيجة:

![عرض الفجوة](gap_width.png)

## **الأسئلة المتكررة**

**أي نوع من المخططات يدعم سلاسل البيانات؟**

جميع أنواع المخططات الممثلة في تعداد [ChartType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/charttype/) تستخدم بيانات المخطط، لكن سلاسلها لا تشترك جميعها في هيكل القيم أو الإعدادات نفسها. على سبيل المثال، تستخدم مخططات الفئات الفئات والقيم، وتستخدم مخططات التشتت قيم X وY، وتضيف مخططات الفقاعات أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتطابق مع نوع السلسلة. تنطبق خيارات مثل التداخل وعرض الفجوة فقط على مجموعات الأشرطة أو الأعمدة المتوافقة.

**ما هي مجموعة سلاسل المخطط؟**

[IChartSeriesGroup](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartseriesgroup/) تحتوي على سلاسل متوافقة تتشارك إعدادات الرسم على مستوى المجموعة. يمكن لمخطط مركب أن يحتوي على أكثر من مجموعة، لذا فإن تغيير المجموعة التي تُصل عبر سلسلة واحدة لا يغيّر بالضرورة كل السلاسل في المخطط.

**هل يحتوي المخطط المُنشأ حديثًا على بيانات افتراضية؟**

نعم. بشكل افتراضي، تُنشئ [IShapeCollection.addChart](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) سلاسل وعناصر فئة وقيم نموذجية. يمكنك تعديل هذه الخلايا أو مسح كل من مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة بالكامل. هناك نسخة مفرطة يمكنها أيضًا إنشاء مخطط بدون بيانات افتراضية.

**كيف تُربط كائنات المخطط بخلايا دفتر العمل؟**

أسماء السلاسل، وتسميات الفئات، وقيم نقاط البيانات تُشير إلى خلايا في [IChartDataWorkbook](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/). تعديل خلية مُشار إليها يحدث تحديثًا للعنصر المقابل في المخطط. عند بناء بيانات مخصصة، حافظ على محاذاة صفوف الفئات وصفوف قيم السلاسل بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف أمسح نقطة واحدة بدلًا من مسح السلسلة بأكملها؟**

عيّن خلية القيمة ذات الصلة إلى `null` لتبقى نقطة البيانات في موضع الفئة كقيمة فارغة. استخدم [IChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatapointcollection/#clear--) فقط عندما تريد إزالة جميع النقاط من تلك السلسلة. إذا أزلت الفئات أيضًا، حدّث كل السلاسل بحيث تظل قيمها محاذية لمجموعة الفئات.

**كيف يُعرض النقاط الفارغة؟**

تختلف النتيجة حسب نوع المخطط والقيمة التي تم تكوينها عبر [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). يمكن للمخططات المدعومة عرض الفارغات كفجوات أو كقيم صفرية أو بربط النقاط المجاورة. اختر الإعداد الذي يتماشى مع معنى البيانات المفقودة في عرضك. طالع [التحكم في عرض الخلايا الفارغة](#control-the-display-of-empty-cells) للحصول على مثال كامل ومقارنة بصرية.

**كيف تُنسق القيم السالبة؟**

بالنسبة إلى السلاسل المدعومة من الأشرطة والأعمدة والفقاعات، استدعِ [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) وعين اللون العائد من [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). يمكنك تجاوز السلوك لنقطة فردية عبر [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). هذه الأساليب تؤثر على التنسيق فقط، وليس على القيم الرقمية المخزنة.

**أي تنسيق ينتصر عندما يتم تنسيق كل من السلسلة والنقطة؟**

التنسيق الصريح لنقطة البيانات يتفوق لتلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، عندما لا يُحدَّد تنسيق السلسلة، نمط المخطط والسمات التلقائية. إعدادات المجموعة مثل التداخل وعرض الفجوة تتحكم في التخطيط ولا تُعدّ تجاوزات تنسيق على مستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها المخطط؟**

Aspose.Slides لا يفرض حدًا ثابتًا منفصلًا لعدد السلاسل. في الممارسة العملية، تحدد قيود ملف العرض، الذاكرة المتوفرة، زمن التجسيد، وقابلية قراءة المخطط حدًا عمليًا.

**ماذا عليّ تعديل عندما تكون الأعمدة قريبة جدًا أو متباعدة جدًا؟**

استدعِ [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) على مجموعة السلسلة الأصلية المناسبة. زد القيمة لتوسيع الفجوة بين المجموعات، أو قللها لجذب المجموعات أقرب إلى بعضها.