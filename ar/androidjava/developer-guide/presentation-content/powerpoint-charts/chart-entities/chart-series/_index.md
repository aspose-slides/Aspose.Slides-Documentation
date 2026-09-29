---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية على Android
linktitle: سلاسل البيانات
type: docs
url: /ar/androidjava/chart-series/
keywords:
- سلسلة المخطط
- تداخل السلسلة
- لون السلسلة
- اسم السلسلة
- نقطة البيانات
- خلية دفتر العمل
- فجوة السلسلة
- قيمة سلبية
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعرف على كيفية إدارة سلاسل المخططات، نقاط البيانات، خلايا دفتر العمل، التنسيق، التداخل، عرض الفجوة، والقيم السلبية في العروض التقديمية على Android."
---
## **نظرة عامة**

يخزن المخطط بياناته المرسومة في دفتر بيانات المخطط. يمثل [IChartSeries](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartseries/) مجموعة واحدة من القيم المرتبطة، وتشير كل [IChartDataPoint](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatapoint/) في السلسلة إلى خلية أو أكثر في دفتر العمل. توفر كائنات [IChartCategory](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartcategory/) التسميات أو قيم التجميع المشتركة بين السلاسل. لذلك فإن اسم السلسلة، الفئات، وقيم النقاط مرتبطة بكائنات [IChartDataCell](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/) بدلاً من تخزينها فقط كنص عرض.

بالنسبة لمخطط فئة تقليدي، يستخدم دفتر العمل الافتراضي الصف 0 لأسماء السلاسل، العمود 0 لأسماء الفئات، وتُملأ الخلايا المتبقية بقيم السلسلة. الفهارس الخاصة بورقة العمل والصف والعمود التي تُمرَّر إلى [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) هي صفرية. هذا الترتيب مفيد عندما تنشئ مخططًا ببيانات افتراضية، لكن لا تفترض أن كل مخطط موجود يستخدمه. بالنسبة لعروض تقديمية محمَّلة، افحص الخلايا التي تشير إليها السلاسل والفئات ونقاط البيانات قبل تعديل قيم دفتر العمل.

إعدادات المخطط لها ثلاث نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [IChartSeries.getFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartseries/#getFormat--)، توفر المظهر الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات نقطة البيانات، مثل [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--)، تتجاوز مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تنطبق على السلاسل المتوافقة التي تنتمي إلى نفس [IChartSeriesGroup](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartseriesgroup/). يمكنك الوصول إلى المجموعة عبر [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) عندما تحتاج إلى ضبط خيارات مثل التداخل أو عرض الفجوة.

عندما لا يتم تحديد تعبئة صريحة للنقطة أو السلسلة، يحدد نمط المخطط والثيم المظهر التلقائي. عندما يتوفر كل من تنسيق السلسلة وتنسيق النقطة، فإن تنسيق النقطة له الأولوية لتلك النقطة.

![سلسلة المخطط في PowerPoint](chart-series-powerpoint.png)

## **ضبط تداخل سلسلة المخطط**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartseries/#getOverlap--) يبلغ عن مقدار تداخل الأشرطة أو الأعمدة في مخطط ثنائي الأبعاد، من -100 إلى 100 بالمئة. هو إسقاط للقراءة فقط للإعداد على مجموعة السلاسل الأصلية. استخدم [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) لتحديث كل السلاسل المتوافقة في تلك المجموعة. ينطبق هذا الخيار على أنواع المخططات التي تعرض أشرطة أو أعمدة مجموعة؛ ولا يؤثر على مجموعات السلاسل غير المرتبطة في مخطط مركب.

المثال التالي يضبط التداخل للمجموعة التي تحتوي على السلسلة الأولى:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // المخطط الجديد يحتوي على سلاسل وعينات وفئات وقيم.
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

استخدم [IChartSeries.getFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartseries/#getFormat--) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كانت النقطة لديها تعبئة صريحة بالفعل، فإن إعداد [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) يتجاوز تعبئة السلسلة لتلك النقطة.

المثال التالي يطبق تعبئة صلبة زرقاء على السلسلة الأولى:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

يُخزن اسم السلسلة في دفتر بيانات المخطط ويظهر عادة في المفتاح. في دفتر العمل الافتراضي الذي يتم إنشاؤه لمخطط عمود مزدحم، الخلية B1 هي في الصف 0 والعمود 1 وتحتوي على اسم السلسلة الأولى. الثوابت المسماة في المثال التالي تجعل هذا الهيكل واضحًا:

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

يمكنك أيضًا تحديث الخلية التي يشير إليها [IChartSeries.getName](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartseries/#getName--) . هذه الطريقة تتجنب الافتراض بوجود صف وعمود معينين في مخطط موجود:

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

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) يُعيد اللون المحسوب من فهرس السلسلة ونمط المخطط كعدد صحيح لون ARGB لأندرويد. هذا هو اللون المستخدم عندما لا يتم تعريف تعبئة السلسلة صراحة. استدعاء الطريقة يقرأ اللون المحسوب؛ لا يُضيف تعبئة جديدة.

المثال التالي يطبع عدد اللون التلقائي لكل سلسلة افتراضية:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

القيم الصحيحة تعتمد على نمط المخطط والثيم.

## **ضبط تعبئة مقلوبة لسلسلة المخطط**

بالنسبة لسلاسل الأشرطة، الأعمدة، والفقاعات، يمكن لـ [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) عرض القيم السالبة بتعبئة مختلفة. اضبط تعبئة السلسلة العادية لتكون صلبة، فعل الانعكاس، وعين لون القيمة السلبية عبر [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). الأرقام السالبة تظل دون تغيير في دفتر العمل؛ فقط يتغير لون عرضها.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. الصف 0 من ورقة العمل يحتوي على اسم السلسلة، العمود 0 يحتوي على أسماء الفئات، والعمود 1 يحتوي على القيم:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

![لون التعبئة الصلبة المقلوب](inverted_solid_fill_color.png)

يمكنك تمكين الانعكاس لنقطة واحدة عبر [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). في المثال التالي، يتم تعطيل الانعكاس للسلسلة وتفعيله فقط للنقطة المختارة. تُعطى النقطة قيمة سالبة لكي يكون التأثير مرئيًا:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

## **مسح قيمة نقطة بيانات معينة**

لجعل نقطة واحدة فارغة دون إزالة النقاط الأخرى، اضبط خلية دفتر العمل الخلفية لتكون `null`. بالنسبة لمخطط عمودي، القيمة المرسومة متاحة عبر [IChartDataPoint.getValue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). تظل نقطة البيانات في نفس موقع الفئة، لكن المخطط يتعامل مع قيمتها كفراغ وفقًا لإعدادات فراغ المخطط.

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

تستخدم مخططات التشتت خلايا X وY منفصلة، وتستخدم مخططات الفقاعات أيضًا خلية حجم. امسح فقط الخلية التي تمثل القيمة التي تريد إزالتها. لا تستخدم [IChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) عندما ترغب في الحفاظ على بقية النقاط، لأن هذه الطريقة تُزيل كل نقاط البيانات من المجموعة.

## **التحكم في عرض الخلايا الفارغة**

الخلايا المخفية التي تحتوي على قيم هي حالة منفصلة عن الخلايا الفارغة. لتضمين أو استبعاد البيانات من صفوف وأعمدة ورقة العمل المخفية، راجع [Include Data from Hidden Rows and Columns](/slides/ar/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns).

الخلية الفارغة في دفتر العمل تمثل بيانات مفقودة؛ والخلية التي تحتوي على `0` تمثل قيمة عددية معروفة. استدعِ [IChartDataCell.setValue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) مع `null` لجعل الخلية فارغة. الصفر الرقمي يظل صفرًا بغض النظر عن إعداد الخلية الفارغة.

استخدم [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) لاختيار كيفية عرض المخطط للخلايا الفارغة. ينطبق هذا الإعداد على المخطط بأكمله. إنه يغيّر طريقة رسم الفراغات دون تعبئة خلية دفتر العمل الفارغة بصفر أو قيمة مُستنتجة.

المثال الذاتي التالي ينشئ مخطط خط واحد بسلسلة واحدة، يمسح القيمة لليوم الثالث، ويحفظ المخطط نفسه بكل وضع. لا تحتاج إلى ملف إدخال. يستخدم [IChartDataWorkbook](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdataworkbook/) ورقة العمل 0، العمود 0 لتسميات الفئات، والعمود 1 للقيم؛ الصف 0 يحمل اسم السلسلة. البيانات النهائية هي `10, 20, empty, 30, 40`.

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

    // اترك اليوم 3 فارغًا فعليًا، مع الاحتفاظ بفئته ونقطة البيانات.
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

كل ملف ناتج يخزن الوضع المحدد قبل الحفظ: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx`، و `empty_cells_Span.pptx`. لحفظ نسخة واحدة فقط، عيّن الوضع المطلوب واحفظ العرض مرة واحدة بدلاً من التكرار عبر الأوضاع.

المقارنة أدناه تُظهر نفس البيانات في جميع الملفات الثلاثة. اليوم الثالث فارغ في دفتر العمل في كل حالة:

![مخططات الخط مع بيانات متطابقة: الفجوة تقطع الخط في اليوم 3، الصفر يهبط بالخط إلى الصفر، والامتداد يربط اليوم 2 باليوم 4.](display_blanks_as.png)

التأثير المرئي يعتمد على نوع المخطط. يجعل مخطط الخط جميع الأوضاع الثلاثة سهلة المقارنة. مخططات الأشرطة والأعمدة لا تمتلك خطًا لتوصيل الفئات المفقودة، لذا لا يمكن لـ `Span` إنتاج الجزء المتصل الموضح أعلاه؛ ويمكن أن يبدو العمود المفقود والعمود صفر الارتفاع متشابهين. بالمثل، مخطط التشتت مع العلامات فقط لا يحتوي على خط وصلة. لا تتوقع ثلاث نتائج مميزة لكل نوع مخطط؛ تحقق من النتيجة للنوع الذي تستخدمه.

## **ضبط عرض فجوة السلسلة**

عرض الفجوة هو المسافة بين مجموعات الأشرطة أو الأعمدة المتجاورة، معبرًا عنها بنسبة مئوية من عرض العمود أو الشريط. مثل التداخل، ينتمي إلى مجموعة السلسلة الأصلية بدلاً من سلسلة واحدة. استدعِ [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) مرة واحدة للمجموعة. القيمة الأكبر تخلق مساحة أكبر بين المجموعات؛ والقيمة الأصغر تجعلها أكثر كثافة.

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

**ما أنواع المخططات التي تدعم سلاسل البيانات؟**

جميع أنواع المخططات الممثلة في تعداد [ChartType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/charttype/) تستخدم بيانات المخطط، لكن سلاسلها لا تملك نفس هيكل القيم أو الإعدادات. على سبيل المثال، تستخدم المخططات الفئوية فئات وقيم، وتستخدم مخططات التشتت قيم X وY، وتضيف مخططات الفقاعات أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتطابق مع نوع السلسلة. تنطبق الخيارات مثل التداخل وعرض الفجوة فقط على مجموعات الأشرطة أو الأعمدة المتوافقة.

**ما هي مجموعة سلاسل المخطط؟**

[IChartSeriesGroup](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartseriesgroup/) تحتوي على سلاسل متوافقة تشترك في إعدادات رسم على مستوى المجموعة. يمكن لمخطط مركب أن يحتوي على أكثر من مجموعة، لذا تعديل المجموعة التي تُصل إلى واحدة عبر سلسلة لا يغيّر بالضرورة كل السلاسل في المخطط.

**هل يحتوي المخطط المنشئ حديثًا على بيانات افتراضية؟**

نعم. بشكل افتراضي، يُنشئ [IShapeCollection.addChart](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) سلاسل وعناوين وفئات وقيم تجريبية. يمكنك تعديل تلك الخلايا أو مسح كل من مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة بالكامل. يمكن أيضًا وجود نسخة مفرطة تُنشئ مخططًا بدون بيانات افتراضية.

**كيف يتم ربط كائنات المخطط بخلايا دفتر العمل؟**

أسماء السلاسل، تسميات الفئات، وقيم نقاط البيانات تشير إلى خلايا في [IChartDataWorkbook](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdataworkbook/). تعديل خلية مشار إليها يحدث تحديثًا للعنصر المقابل في المخطط. عند بناء بيانات مخصصة، احرص على محاذاة صفوف الفئات وصفوف قيم السلسلة بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف أمسح نقطة واحدة بدلاً من مسح السلسلة بأكملها؟**

اضبط خلية القيمة ذات الصلة لتصبح `null` لتبقى نقطة البيانات في موقع فئتها كنقطة فارغة. استخدم [IChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) فقط عندما ترغب في إزالة جميع النقاط من تلك السلسلة. إذا أزلت الفئات أيضًا، حدّث كل السلاسل بحيث تظل قيمها محاذية لمجموعة الفئات.

**كيف تُعرض النقاط الفارغة؟**

النتيجة تعتمد على نوع المخطط والقيمة المُكوَّنة عبر [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). تدعم المخططات المعروضة عرض الفراغات كفجوات، كقيم صفرية، أو بربط النقاط المجاورة. اختر الإعداد الذي يعكس معنى البيانات المفقودة في عرضك. راجع [التحكم في عرض الخلايا الفارغة](#control-the-display-of-empty-cells) للحصول على مثال كامل ومقارنة بصرية.

**كيف يتم تنسيق القيم السالبة؟**

بالنسبة لسلاسل الأشرطة، الأعمدة، والفقاعات المدعومة، استدعِ [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) واضبط اللون المسترجع من [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). يمكنك تجاوز السلوك لنقطة فردية عبر [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). هذه الأساليب تؤثر على التنسيق، وليس على القيم الرقمية المخزنة.

**أي تنسيق ينتصر عندما يتم تنسيق كل من السلسلة والنقطة؟**

التنسيق الصريح لنقطة البيانات يتفوق لتلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، إذا لم يُعرَّف تنسيق السلسلة، النمط والموضوع التلقائي للمخطط. إعدادات المجموعة مثل التداخل وعرض الفجوة تتحكم في التخطيط ولا تُعَدّ تجاوزًا لتنسيق المستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها المخطط؟**

Aspose.Slides لا يفرض حدًا ثابتًا منفصلًا لعدد السلاسل. في الممارسة العملية، تحدد قيود ملف العرض، الذاكرة المتاحة، وقت التحrender، وقابلية قراءة المخطط حدًا عمليًا.

**ماذا يجب تعديل عندما تكون الأعمدة متقربة جدًا أو متباعدة جدًا؟**

استدعِ [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) على مجموعة السلاسل الأصلية المناسبة. زد القيمة لتوسيع المسافة بين المجموعات، أو قللها لتقريب المجموعات من بعضها البعض.