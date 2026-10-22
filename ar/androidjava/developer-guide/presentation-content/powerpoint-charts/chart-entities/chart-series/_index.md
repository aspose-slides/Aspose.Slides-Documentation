---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية على Android
linktitle: سلاسل البيانات
type: docs
url: /ar/androidjava/chart-series/
keywords:
- سلسلة مخطط
- تداخل السلسلة
- لون السلسلة
- اسم السلسلة
- نقطة بيانات
- خلية مصنف
- فجوة السلسلة
- قيمة سلبية
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية إدارة سلاسل المخططات، نقاط البيانات، خلايا المصنف، التنسيق، التراكب، عرض الفجوة، والقيم السلبية في العروض التقديمية على Android."
---
## **نظرة عامة**

يمكن للمخطط تخزين القيم المرسومة إما في خلايا المصنف أو مباشرةً كقيم عددية حرفية. تمثل [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) مجموعة واحدة من القيم المرتبطة، وكل [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) يمثل نقطة في تلك السلسلة. توفر كائنات [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) التسميات أو قيم التجميع المشتركة بين السلاسل. في المخططات التي تم إنشاؤها ببيانات افتراضية، تُستخدم أسماء السلاسل والفئات وقيم النقاط كائنات [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) من مصنف المخطط.

للمخطط الفئوي النموذجي، يستخدم المصنف الافتراضي الصف 0 لأسماء السلاسل، والعمود 0 لأسماء الفئات، والخلايا المتبقية لقيم السلاسل. فهارس ورقة العمل والصف والعمود التي تُمرَّر إلى [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) هي صفرية. هذا التخطيط مفيد عند إنشاء مخطط ببيانات افتراضية، لكن لا تفترض أن كل مخطط موجود يستخدمه. بالنسبة للعرض المحمَّل، افحص الخلايا التي تشير إليها السلاسل والفئات ونقاط البيانات قبل تغيير قيم المصنف.

إعدادات المخطط لها ثلاث نُطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--)، تُوفِّر المظهر الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات نقطة البيانات، مثل [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--)، تُعيد كتابة مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تُطبَّق على السلاسل المتوافقة التي تنتمي إلى نفس [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/). يمكن الوصول إلى المجموعة عبر [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) عندما تحتاج إلى ضبط خيارات مثل التراكب أو عرض الفجوة.

عند عدم تعيين تعبئة صريحة للنقطة أو السلسلة، يحدد نمط المخطط والموضوع المظهر التلقائي. عندما يكون كل من تنسيق السلسلة وتنسيق النقطة موجودين، يتفوَّق تنسيق النقطة على ذلك.

![سلسلة المخطط في PowerPoint](chart-series-powerpoint.png)

## **تعيين قيم السلسلة باستخدام القيم العددية الحرفية**

استخدم القيم العددية الحرفية عندما تأتي قيم السلسلة من بيانات التطبيق أو الحسابات ولا تحتاج إلى مراجع خلايا ورقة العمل. استدعِ [setDataSourceTypeForValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) مع [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/#DoubleLiterals) قبل تعيين نتيجة كل نقطة عبر [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) باستخدام [setAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-).

إعداد المجموعة يتحكم في نوع مصدر جميع قيم النقاط في تلك السلسلة. تُبلِّغ طريقة [getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibasechartvalue/#getDataSourceType--) لكل قيمة النقطة النوع المختار؛ غيِّره عبر إعداد المجموعة. باستخدام `Worksheet`، استخدم [getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isinglecellchartvalue/#getAsCell--) للوصول إلى الخلية المشار إليها. باستخدام `DoubleLiterals`، استخدم [getAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) أو `setAsLiteralDouble` لقراءة أو كتابة الرقم مباشرة.

المثال التالي يُنشئ مخطط أعمدة بأسماء وفئات افتراضية، ثم يعين القيم المحسوبة 10، 20، وما إلى ذلك للنقاط الموجودة في سلسلته الأولى. يحفظ العرض، يعيده فتحه، ويطبع القيم المخزَّنة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals);
    for (int i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IChart reopenedChart = (IChart) reopenedSlide.getShapes().get_Item(0);
    IChartSeries reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (IChartDataPoint point : reopenedSeries.getDataPoints()) {
        System.out.println(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

نوع مصدر قيمة النقطة منفصل عن [IChartData.getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) الذي يحدِّد تكوين المصنف الداخلي أو الخارجي للمخطط. لا يؤدي استخدام القيم العددية الحرفية بحد ذاته إلى إزالة المصنف المضمن. في هذا المثال، يظل المصنف متاحًا لتسميات الفئات، أسماء السلاسل، والسلاسل الأخرى. راجع [Chart Workbook](/slides/ar/androidjava/chart-workbook/) لإدارة المصنف.

بالنسبة لمخططات التشتت والفقاعات، استخدم [setDataSourceTypeForXValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) و [setDataSourceTypeForYValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) لاختيار المصادر لـ [getXValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getXValue--) و [getYValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getYValue--). كما تستخدم مخططات الفقاعات [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) لـ [getBubbleSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getBubbleSize--). اضبط كل مصدر مناسب إلى `DoubleLiterals` قبل تعيين الأرقام عبر طريقة `setAsLiteralDouble` الخاصة بهذه القيمة.

## **تعيين تراكب سلسلة المخطط**

تقارير [IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) مقدار تداخل الأعمدة أو الأشرطة في مخطط ثنائي الأبعاد، من -100 إلى 100 بالمائة. هو إسقاط للقراءة فقط للإعداد على مجموعة السلسلة الأصلية. استخدم [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) لتحديث كل السلاسل المتوافقة في تلك المجموعة. ينطبق هذا الخيار على أنواع المخططات التي تُظهر أشرطة أو أعمدة مجمَّعة؛ ولا يؤثر على مجموعات السلاسل غير المتعلقة في مخطط مركب.

المثال التالي يعيّن التراكب للمجموعة التي تحتوي على السلسلة الأولى:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // المخطط الجديد يحتوي على سلاسل وعناصر فئة وقيم عينة.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![تراكب السلسلة](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

استخدم [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كانت النقطة لديها تعبئة صريحة، فإن إعداد [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) يتجاوز تعبئة السلسلة لتلك النقطة.

المثال التالي يطبِّق تعبئة زرقاء صلبة على السلسلة الأولى:

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

يُخزن اسم السلسلة في مصنف بيانات المخطط ويُعرض عادةً في وسيلة الإيضاح. في المصنف الافتراضي الذي يُنشأ لمخطط أعمدة مجموعة، تكون الخلية B1 في الصف 0، العمود 1 وتحتوي على اسم السلسلة الأولى. الثوابت المسماة في المثال التالي تجعل هذا الهيكل واضحًا:

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

يمكنك أيضًا تحديث الخلية التي يُشير إليها [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--). يَتَجنَّب هذا النهج الافتراض بوجود صف وعمود معينين في مخطط موجود:

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

### **إنشاء سلسلة باسم من خلايا متعددة**

يكون اسم السلسلة المركب مفيدًا عندما يُخزَّن اسم المنتج وفترة التقارير في خلايا مصنف منفصلة. على سبيل المثال، يمكنك دمج `Product A` في B1 و `2026` في C1 لتكوين اسم سلسلة واحد مع الحفاظ على ربط كل جزء بخلايا المصدر.

استخدم [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) لاسترجاع نطاق الاسم، ثم مرّر ذلك التجميع إلى [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-). يتحكم الوسيط `skipHiddenCells` فيما إذا كانت الخلايا المخفية تُضمَّن: `true` تُستبعد، بينما `false` تُضمَّن. يستخدم هذا المثال `false` لتضمين كل الخلايا في نطاق الاسم.

المثال التالي ينشئ عرضًا بسلسلة واحدة ونقطتي بيانات. تُزود الخلايا B1:C1 فقط باسم السلسلة؛ A2:A3 تُزوِّد بتسميات الفئات، و B2:B3 تُزوِّد بالقيم العددية.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // هاتان الخليتان توفران اسم السلسلة.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // الخلايا المنفصلة تزود الفئات ونقاط البيانات الرقمية.
    IChartDataCell northCategory = workbook.getCell(0, 1, 0, "North");
    IChartDataCell southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    IChartDataCell northValue = workbook.getCell(0, 1, 1, 120);
    IChartDataCell southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اسم السلسلة الناتج هو `Product A 2026` مع مسافة بين القيمتين من الخليتين. تُظهر وسيلة الإيضاح ذلك كإدخال واحد لكل العمودين. تُظهر الصورة أدناه النتيجة:

![مخطط أعمدة بقيم شمال وجنوب واسم سلسلة مركب Product A 2026 في وسيلة الإيضاح](composite_series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

ترجع [IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) اللون المحسوب من فهرس السلسلة ونمط المخطط كعدد صحيح لون Android ARGB. هذا هو اللون المستخدم عندما لا تُحدد تعبئة السلسلة صراحة. استدعاء الطريقة يقرأ اللون المحسوب؛ لا يعيِّن تعبئة جديدة.

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

القيم الصحيحة الدقيقة تعتمد على نمط المخطط والموضوع.

## **تعيين لون تعبئة معكوس لسلسلة المخطط**

بالنسبة لسلاسل الأعمدة، الأشرطة، والفقاعات، يمكن لـ [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) عرض القيم السالبة بتعبئة مختلفة. عيّن تعبئة السلسلة العادية إلى صلبة، فعَّل الانعكاس، وعيّن لون القيمة السالبة عبر [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). تظل الأرقام السالبة دون تغيير في المصنف؛ يتغيّر فقط لون العرض.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. الصف 0 من ورقة العمل يحتوي اسم السلسلة، العمود 0 يحتوي أسماء الفئات، والعمود 1 يحتوي القيم:

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

![لون التعبئة الصلبة المعكوس](inverted_solid_fill_color.png)

يمكنك تمكين الانعكاس لنقطة واحدة عبر [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). في المثال التالي يُعطَّل الانعكاس للسلسلة ويُفعَّل فقط للنقطة المختارة. تُعطَى النقطة أيضًا قيمة سالبة لتظهر التأثير:

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

## **مسح قيمة نقطة بيانات محددة**

لجعل نقطة واحدة فارغة دون إزالة النقاط الأخرى، عيّن خلية المصنف الداعمة لها إلى `null`. في مخطط عمودي، تكون القيمة المرسومة متاحة عبر [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). تظل نقطة البيانات في موقع الفئة نفسه، لكن المخطط يتعامل مع قيمتها كفراغ وفقًا لإعدادات القيم الفارغة في المخطط.

المثال التالي يمسح الثانية فقط في السلسلة الأولى:

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

تستخدم مخططات التشتت خلايا X وY منفصلة، وتستخدم مخططات الفقاعات أيضًا خلية حجم. امسح الخلية التي تمثل القيمة التي تريد إزالتها فقط. لا تستدعِ [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) عندما تريد الاحتفاظ بالنقاط الأخرى، لأن هذه الطريقة تُزيل كل نقاط البيانات من التجميع.

## **التحكم في عرض الخلايا الفارغة**

الخلايا المخفية التي تحتوي على قيم هي حالة منفصلة عن الخلايا الفارغة. لتضمين أو استبعاد البيانات من صفوف وأعمدة ورقة العمل المخفية، راجع [Include Data from Hidden Rows and Columns](/slides/ar/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns).

تمثل الخلية الفارغة في المصنف بيانات مفقودة؛ أما الخلية التي تحتوي على `0` فتمثل قيمة عددية معروفة. استدعِ [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) مع `null` لجعل الخلية فارغة. يظل الصفر الرقمي صفرًا بغض النظر عن إعداد الخلية الفارغة.

استخدم [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) لاختيار طريقة عرض المخطط للخلايا الفارغة. يُطبَّق هذا الإعداد على المخطط بأكمله. يغيّر طريقة رسم الفجوات دون ملء الخلية الفارغة بصفر أو قيمة مُستنتجة.

المثال المستقل التالي ينشئ مخطط خط مع سلسلة واحدة، يمسح القيمة لليوم 3، ويحفظ المخطط ذاته في كل وضع. لا يُطلَب ملف إدخال. يستخدم [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) ورقة العمل 0، العمود 0 لتسميات الفئات، والعمود 1 للقيم؛ الصف 0 يحمل اسم السلسلة. البيانات النهائية هي `10, 20, empty, 30, 40`.

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

    // اترك اليوم 3 فارغًا فعليًا، مع الاحتفاظ بفئته ونقطة البيانات الخاصة به.
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

كل ملف إخراج يُخزِّن الوضع المعين قبل الحفظ: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx`، و `empty_cells_Span.pptx`. لحفظ نسخة واحدة فقط، عيّن الوضع المطلوب واحفظ العرض مرة واحدة بدلاً من التكرار عبر الأوضاع.

المقارنة أدناه تُظهر نفس البيانات في جميع الملفات الثلاثة. اليوم 3 فارغ في المصنف في كل حالة:

![مخططات خط مع بيانات متماثلة: Gap يقطع الخط عند اليوم 3، Zero يُظهر الخط عند الصفر، و Span يربط اليوم 2 باليوم 4.](display_blanks_as.png)

يعتمد التأثير المرئي على نوع المخطط. يجعل مخطط الخط المقارنة بين جميع الأوضاع سهلة. لا تمتلك مخططات الأشرطة والأعمدة خطًا لتوصيل الفجوات، لذلك لا يمكن لـ `Span` إنتاج الجزء الموصل الموضح أعلاه؛ قد يبدو العمود المفقود والعمود صفر الارتفاع متشابهين. بالمثل، مخطط التشتت مع علامات فقط لا يملك خطًا موصلًا. لا تتوقع ثلاث نتائج متميزة لكل نوع مخطط؛ تحقق من النتيجة للنوع الذي تستخدمه.

## **تعيين عرض الفجوة بين السلاسل**

عرض الفجوة هو المسافة بين مجموعات الأشرطة أو الأعمدة المتجاورة، يُعبَّر عنها كنسبة مئوية من عرض الشريط أو العمود. مثل التراكب، ينتمي إلى مجموعة السلسلة الأصلية وليس إلى سلسلة واحدة. استدعِ [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) مرة واحدة للمجموعة. قيمة أكبر تُنشئ مساحة أكبر بين المجموعات؛ قيمة أصغر تجعلها أكثر كثافة.

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

جميع أنواع المخططات الممثَّلة في تعداد [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) تستخدم بيانات المخطط، لكن سلاسلها لا تشترك جميعًا في نفس هيكل القيم أو الإعدادات. على سبيل المثال، تستخدم المخططات الفئوية فئات وقيم، ومخططات التشتت قيم X وY، ومخططات الفقاعات تضيف أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتطابق مع نوع السلسلة. تنطبق خيارات مثل التراكب وعرض الفجوة فقط على مجموعات الأشرطة أو الأعمدة المتوافقة.

**ما هي مجموعة سلاسل المخطط؟**

تحتوي [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) على سلاسل متوافقة تشترك في إعدادات رسم على مستوى المجموعة. يمكن لمخطط مركب أن يحتوي على أكثر من مجموعة، لذا قد لا يؤدي تغيير المجموعة التي تُوصل من خلال سلسلة واحدة إلى تغيير جميع السلاسل في المخطط.

**هل يحتوي المخطط المُنشأ حديثًا على بيانات افتراضية؟**

نعم. بشكل افتراضي، تُنشئ [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) سلاسل وعناصر فئة وقيم عينة. يمكنك تعديل تلك الخلايا أو مسح كلا مجموعتي السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة تمامًا. يمكن أيضًا استدعاء نسخة ذات حمل زائد لإنشاء مخطط بدون بيانات افتراضية.

**كيف يتم ربط كائنات المخطط بخلايا المصنف؟**

تشير أسماء السلاسل، تسميات الفئات، وقيم نقاط البيانات إلى خلايا في [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/). تحديث خلية مُشار إليها يُحدِّث العنصر المقابل في المخطط. عند بناء بيانات مخصصة، احرص على محاذاة صفوف الفئات وصفوف قيم السلاسل بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف يمكن مسح نقطة واحدة بدلاً من السلسلة بأكملها؟**

عيّن خلية القيمة ذات الصلة إلى `null` للحفاظ على موقع الفئة للنقطة كنقطة فارغة. استخدم [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) فقط عندما تريد إزالة جميع النقاط من تلك السلسلة. إذا أزلت الفئات أيضًا، حدّث كل السلاسل بحيث تظل قيمها محاذية مع مجموعة الفئات.

**كيف تُعرض النقاط الفارغة؟**

يعتمد الشكل على نوع المخطط والقيمة المُكوَّنة عبر [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). يمكن للمخططات المدعومة عرض الفجوات كفجوات، كقِيَم صفرية، أو بربط النقاط المجاورة. اختر الإعداد الذي يتوافق مع معنى البيانات المفقودة في عرضك. راجع [Control the Display of Empty Cells](#control-the-display-of-empty-cells) للحصول على مثال كامل ومقارنة بصرية.

**كيف يتم تنسيق القيم السالبة؟**

بالنسبة للسلاسل المدعومة من الأشرطة، الأعمدة، والفقاعات، استدعِ [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) وعيّن اللون الذي تُرجعه [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). يمكنك تجاوز السلوك لنقطة فردية عبر [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). تؤثر هذه الأساليب على التنسيق، وليس على القيم الرقمية المخزَّنة.

**أي تنسيق ينتصر عندما يتم تنسيق كل من السلسلة والنقطة؟**

يتفوّق تنسيق نقطة البيانات الصريح لتلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، عندما لا يُحدَّد تنسيق السلسلة، النمط والموضوع التلقائي للمخطط. تُتحكم إعدادات المجموعة مثل التراكب وعرض الفجوة في التخطيط ولا تُعتبر تجاوزات تنسيق على مستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها المخطط؟**

لا يفرض Aspose.Slides حدًا ثابتًا منفصلًا لعدد السلاسل. في الواقع، تحدد قيود ملف العرض، الذاكرة المتاحة، وقت التقديم، وقابلية قراءة المخطط حدًا عمليًا.

**ماذا يجب تعديل عندما تكون الأعمدة قريبة جدًا أو متباعدة جدًا؟**

استدعِ [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) على مجموعة السلسلة الأصلية المناسبة. زد القيمة لتوسيع المسافة بين المجموعات، أو قللها لجعل المجموعات أقرب إلى بعضها.