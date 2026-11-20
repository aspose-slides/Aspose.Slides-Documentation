---
title: تخصيص محاور المخطط في العروض التقديمية باستخدام Java
linktitle: محور المخطط
type: docs
url: /ar/java/chart-axis/
keywords:
- محور المخطط
- المحور العمودي
- المحور الأفقي
- تخصيص المحور
- تعديل المحور
- إدارة المحور
- خصائص المحور
- القيمة القصوى
- القيمة الدنيا
- خط المحور
- تنسيق التاريخ
- عنوان المحور
- موضع المحور
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف كيفية استخدام Aspose.Slides for Java لتخصيص محاور المخططات في عروض PowerPoint التقديمية للتقارير والتصورات."
---
## **نظرة عامة**

هذه المقالة توضح كيفية تخصيص محاور المخطط باستخدام Aspose.Slides for Java. وهي تغطي قيم المحاور المحسوبة، وتبديل صفوف وأعمدة المخطط، ورؤية المحور، وفواصل تسميات الفئات وفواصل العلامات، وفئات التاريخ وتنسيقها، وتدوير العنوان، وتحديد موضع المحور، ووحدات العرض، وتدرج اللوغاريتمي.

## **الحصول على القيم القصوى على المحور العمودي في المخططات**

إنشاء [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) وإضافة مخطط منطقة ببيانات افتراضية. استدعِ [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) قبل قراءة قيم المحاور المحسوبة لضمان تحديث تخطيط المخطط.

اقرأ [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) و[getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) للحصول على حدود المحور، و[getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) و[getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) لفواصل العلامات. توفر [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) و[getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) مقاييس وحدة الوقت، وهي ذات صلة بمحاور التاريخ. يخزن المثال هذه القيم في متغيّرات محلية ويحفظ المخطط.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تبديل البيانات بين المحاور**

استخدم [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) لتبادل أدوار السلاسل والفئات في بيانات المخطط. تصبح كل فئة سابقة سلسلة، وكل سلسلة سابقة فئة. يغيّر هذا طريقة تجميع البيانات؛ لا يبدل المحاور الأفقية والعمودية. يستخدم المثال [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) لربط البيانات الافتراضية بـ `Sheet1!A1:D5`، بما في ذلك صف العنوان وعمود الفئة، قبل تبديل الصفوف والأعمدة. يحفظ مخططاً بأربع سلاسل وثلاث فئات.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **عكس ترتيب رسم المحور**

استخدم [setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) لعكس محور الفئة أو القيمة. على سبيل المثال، يمكن لمخطط شريط أفقي إظهار مراحل المشروع من الأعلى إلى الأسفل بنفس ترتيب الورقة: التخطيط، التطوير، الاختبار. يعكس عكس المحور اتجاه الرسم؛ لا يقوم بترتيب أو إعادة ترتيب بيانات المصنف. بالمقارنة، يقوم [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) بتبادل أدوار السلاسل والفئات.

المثال التالي ينشئ مخطط شريط أفقي بثلاث مراحل وسلسلة واحدة. يحفظ عرضاً تقديمياً بثلاث شرائح: الترتيب العادي، الفئات المعكوسة، والقيم المعكوسة. كل نسخة تستخدم نفس مجموعة البيانات، ويُعكس محور واحد فقط في كل نسخة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // الشريحة 2: عرض الفئة الأولى في الأعلى.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // أبقِ محور القيمة الأفقي في الأسفل.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // الشريحة 3: عكس مقياس الأرقام الأفقي فقط.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يمكن لعكس المحور أيضاً نقل المحور المتقاطع إلى الجانب المقابل من المخطط. يتحكم [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) في مكان تقاطع المحور الآخر مع المحور الجاري تكوينه. في الشريحة 2، استدعاؤه بـ `CrossesType.Maximum` على محور الفئة المعكوس يبقي محور القيمة الأفقي في الأسفل. لنقطة تقاطع محددة، استخدم [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). تحقق من إعدادات التقاطع عند تغيير الاتجاه، خاصة إذا كان المخطط يحتوي بالفعل على نقطة تقاطع مخصصة. استدعِ `setPlotOrderReversed` بـ `false` لاستعادة اتجاه الرسم الطبيعي؛ إعدادات التقاطع منفصلة.

| الترتيب العادي (الشريحة 1) | الفئات المعكوسة (الشريحة 2) | القيم المعكوسة (الشريحة 3) |
| --- | --- | --- |
| ![مخطط شريط أفقي بترتيب الفئة والمحور القيمي العادي](axis-order-normal.png) | ![مخطط شريط أفقي مع الفئات معروضة من الأعلى إلى الأسفل](axis-order-categories-reversed.png) | ![مخطط شبار أفقي مع محور قيمة معكوس والصفر على اليمين](axis-order-values-reversed.png) |
| الفئات تمتد من الأسفل إلى الأعلى؛ القيم تزداد من اليسار إلى اليمين. | التخطيط، التطوير، والاختبار تمتد من الأعلى إلى الأسفل. القيم وترتيب صفوف المصنف لا يتغير. | الفئات تحتفظ بترتيبها الطبيعي؛ القيم تزداد من اليمين إلى اليسار. محور الفئة يعبر عند الصفر على اليمين. |

## **إلغاء تمكين المحور العمودي لمخططات الخط**

استدعِ [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) مع `false` على المحور العمودي لإخفائه. ينشئ المثال مخطط خط ببيانات افتراضية ويحفظه مع إخفاء المحور العمودي.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إلغاء تمكين المحور الأفقي لمخططات الخط**

استدعِ [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) مع `false` على المحور الأفقي لإخفائه. ينشئ المثال مخطط خط ببيانات افتراضية ويحفظه مع إخفاء المحور الأفقي.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إظهار أو إخفاء خطوط الشبكة في المخطط**

استدعِ [getShowMajorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMajorGridLines--) و[getShowMinorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMinorGridLines--) للتحقق من الخطوط التي يعرضها المحور. تُظهر هذه الطرق حالة الرؤية الحالية. لإظهار خطوط الشبكة الصغيرة، استخدم [getMinorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMinorGridLinesFormat--) واضبط تعبئة الخط على لون صلب مرئي. لإخفائها، اضبط التعبئة إلى [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/#NoFill). استخدم [getMajorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMajorGridLinesFormat--) لتغيير تعبئة الخط لخطوط الشبكة الكبيرة بنفس الطريقة. يحافظ تغيير التعبئة على رؤية المحور والعلامات.

المحور العمودي لهذا المخطط العمودي المدمج يُظهر في البداية خطوط الشبكة الكبيرة فقط. يعرض المثال خطوط الشبكة الصغيرة بالبرتقالي الداكن، ثم يخفيها مرة أخرى قبل حفظ العرض التقديمي. يطبع حالة رؤية خطوط الشبكة في كل خطوة.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(new Color(255, 140, 0));
    System.out.printf("Enabled: minor=%b%n", axis.getShowMinorGridLines());

    minorFill.setFillType(FillType.NoFill);
    System.out.printf("Hidden: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| خطوط الشبكة الصغيرة مفعلة | خطوط الشبكة الصغيرة مخفية |
| --- | --- |
| ![خطوط شبكة صغيرة برتقالية بين خطوط الشبكة الكبيرة على المحور العمودي](minor-gridlines-enabled.png) | ![نفس المخطط العمودي مع ظهور خطوط الشبكة الكبيرة فقط](minor-gridlines-hidden.png) |

## **تغيير محور الفئة**

استخدم [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) لاختيار محور فئة تاريخ أو نص. يتطلب هذا المثال ملف `ExistingChart.pptx`، مع مخطط كأول شكل في الشريحة الأولى وخلايا الفئات التي تحتوي على قيم تاريخ إكسل عددية. يغيّر المحور الأفقي إلى محور تاريخ. استدعِ [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) مع `false`، و[setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) مع `1`، و[setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) مع `TimeUnitType.Months` لتحديد العلامات الكبيرة على فواصل شهرية.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تحديد نوع محور الفئة من البيانات**

استدعِ [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--) بعد تعبئة الفئات، ثم اقرأ [getCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getCategoryAxisType--) لفحص الاختيار. هذا مفيد عندما يتلقى المخطط إما تسميات نصية أو قيم تاريخ عددية. يحدد الأسلوب النوع عند الاستدعاء؛ لا يفعّل وضعًا دائمًا يُعيد تقييم التغييرات اللاحقة للبيانات. استدعِه مرة أخرى بعد استبدال الفئات.

ينشئ المثال مخططاً بفئات نصية ويطبع `true` عندما يكون النوع المختار `CategoryAxisType.Text`. ثم يستبدل قيم خلايا الفئة بالتواريخ ويستدعي الأسلوب مرة أخرى، مطبعاً `true` عندما يكون النوع المختار `CategoryAxisType.Date`. تُخزن التواريخ كقيم رقمية لـ OLE Automation، تُحسب كعدد الأيام منذ 30 ديسمبر 1899، وليس كسلاسل تاريخية. يتحكم [setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) في طريقة عرض تلك القيم؛ لا يحول النص إلى تواريخ رقمية. للمزيد عن خلايا الفئات، راجع [Chart Workbook](/slides/ar/java/chart-workbook/).

استخدم التحديد التلقائي عندما يكون الإدخال معروفًا بأنه يحتوي على فئات نصية أو تواريخ عددية، كما في هذا المثال. بالنسبة للتسميات العددية العادية أو الفئات المختلطة أو البيانات الفارغة، استدعِ صراحةً [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisType-int-) لمطابقة المعنى المقصود. القيم العددية وحدها لا تُثبت أن الفئات تمثل تواريخ.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    String[] labels = { "First", "Second", "Third" };

    for (int i = 0; i < labels.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Text); // صحيح

    LocalDate baseDate = LocalDate.of(1899, 12, 30);
    LocalDate[] dates = { LocalDate.of(2026, 1, 1), LocalDate.of(2026, 1, 2), LocalDate.of(2026, 2, 1) };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        categoryCell.setValue((double)(dates[i].toEpochDay() - baseDate.toEpochDay()));
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Date); // صحيح

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **التحكم في فواصل تسميات محور الفئة**

عندما يحتوي المخطط على العديد من الفئات، قلل عدد تسميات المحور الظاهرة دون إزالة الفئات أو نقاط البيانات. استدعِ [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) مع `false`، ثم مرّر الفاصل الزمني المطلوب إلى [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). بالنسبة للفئات النصية بترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل الزمني | التسميات المعروضة في المثال |
| --- | --- |
| `1` | الفئة 1، الفئة 2، الفئة 3، ... الفئة 24 |
| `2` | الفئة 1، الفئة 3، الفئة 5، ... الفئة 23 |
| `3` | الفئة 1، الفئة 4، الفئة 7، ... الفئة 22 |

فاصل زمني `3` يعرض كل تسمية ثالثة، مع إخفاء تسمتين بين كل تسمتين معروفتين. لا يزيل الأعمدة المقابلة. يختار التباعد التلقائي فاصلًا بناءً على المساحة المتاحة؛ لا يضمن عرض كل تسمية.

للعلامات، هناك ضوابط منفصلة. استدعِ [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) مع `false` واستخدم [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) لتحديد فاصلها. على سبيل المثال، `1` يبقي علامة tick عند كل فاصل فئة بينما تظهر التسميات كل فئة ثالثة فقط. استدعِ [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) بنمط مرئي لتستطيع رؤية النتيجة. استدعاء أي من مبدئي التباعد مرة أخرى بـ `true` يسمح للمخطط باختيار الفاصل مرة أخرى تلقائياً.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // الشريحة 2: إظهار كل تسمية ثالثة، لكن إبقاء علامة tick لكل فئة.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // الشريحة 3: السماح للمخطط باختيار الفواصل مرة أخرى.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**التباعد التلقائي (الشريحة 1):** في هذا العرض، تُعرض كل تسمية فئة ثانية وتلتف على سطرين. قد يختلف الناتج التلقائي مع حجم المخطط، الخطوط، ومُحرك العرض.

![التباعد التلقائي لتسميات الفئات مع إظهار جميع الأعمدة الـ 24](category-axis-automatic.png)

**التباعد اليدوي (الشريحة 2):** كل تسمية ثالثة تُعرض على سطر واحد، بينما تبقى علامات tick عند كل فاصل فئة. جميع الأعمدة الـ 24، بما في ذلك تلك بدون تسميات، تظل مرئية بنفس القيم. الشريحة 3 تستعيد المظهر التلقائي الموضح أعلاه.

![فاصل تسميات الفئات يدوياً ثلاثة مع إظهار جميع الأعمدة الـ 24](category-axis-manual.png)

### **اختر المحور والفاصل الصحيح**

استخدم هذا الفاصل لعدد الفئات لمحور فئة نصية، مثل محور الفئة لمخطط عمودي، خطي، مساحة أو شريط. في المخطط العمودي يكون هو المحور الأفقي. في مخطط الشريط الأفقي يكون محور الفئة عمودياً، لذا طبّق هذه الإعدادات على المحور الذي يُرجع [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). ينطبق تباعد العلامات أيضًا على محور السلسلة في المخططات التي لديها واحد.

لا تستخدم تباعد تسميات الفئة لتحديد مقياس عددية لمحور القيمة. على محور القيمة، يحدد [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) فرق القيم؛ على سبيل المثال، وحدة رئيسية `10` تُنتج علامات عند 0، 10، 20، وهكذا عندما يبدأ المحور من الصفر. فاصل تسميات الفئة `3` يعد مواضع الفئات بغض النظر عن قيم البيانات. تستخدم مخططات التشتت والفقاعات محاور قيم بدلاً من محور فئة نصية. بالنسبة لمحور التاريخ، استخدم وحدات زمنية رئيسية ومقاييس كما هو موضح في [تغيير محور الفئة](#change-a-category-axis).

## **تعيين تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال بيانات المخطط الافتراضية بأربع قيم سنوية. تُخزن التواريخ كأرقام تسلسلية لـ OLE Automation في ورقة العمل الأولى (الفهرس `0`)، تُحسب كعدد الأيام منذ 30 ديسمبر 1899. استخدم [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) مع `CategoryAxisType.Date`، استدعِ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) مع `false`، ومرّر `yyyy` إلى [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) لتظهر تسميات الفئة سنوات بأربعة أرقام بغض النظر عن تنسيق الخلية.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    LocalDate baseDate = LocalDate.of(1899, 12, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        LocalDate date = LocalDate.of(2015 + i, 1, 1);
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, date.toEpochDay() - baseDate.toEpochDay());
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين زاوية دوران لعنوان محور المخطط**

استدعِ [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) مع `true` على المحور العمودي، قدم نص العنوان، واستخدم [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) لتدوير العنوان. تُقاس الزاوية بالدرجات؛ يحفظ المثال مخططاً عمودياً مع دوران عنوان محور القيمة بمقدار 90 درجة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين موضع المحور على محور فئة أو قيمة**

استخدم [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) للتحكم فيما إذا كان محور القيمة يعبر محور الفئة بين الفئات أو عند علامات الفئة. يُطبق هذا الإعداد على محاور الفئة. يضبط المثال القيمة إلى `true` على محور الفئة الأفقي لمخطط عمودي ويحفظ النتيجة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين وحدة العرض على محور قيمة المخطط**

استخدم [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) لتكبير أو تصغير تسميات محور القيمة دون تغيير البيانات الأساسية. عند ضبط [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) إلى `Millions`، يُعرض القيمة 60,000,000 كـ 60. ينشئ المثال مخططاً عمودياً ويطبق وحدة العرض بالملايين على محوره العمودي.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تكوين محور قيمة لوغاريتمي**

محور قيمة لوغاريتمي مفيد عندما تمتد القيم الموجبة عبر عدة مرتبات من الحجم. على سبيل المثال، قد يتلقى خدمة 10، 100، 1,000، 10,000، و100,000 طلباً خلال خمس فترات. على مقياس خطي، تظهر القيم الأصغر متقاربة قرب الصفر. يُسهّل المقياس اللوغاريتمي مقارنة النمو النسبي: المسافات المتساوية تمثل نسباً متساوية لا فروقاً متساوية.

استدعِ [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) مع `true` على محور القيمة واستخدم [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) لاختيار القاعدة. يغيّر هذا طريقة عرض القيم الحالية؛ لا يغيّر البيانات ولا يضيف خط اتجاه لوغاريتمي. خط الاتجاه يمثل علاقة ملائمة في البيانات وهو ميزة منفصلة.

### **اختر محور القيمة والأساس**

للمخطط الخطي أو العمودي، يُرجع محور القيمة عبر [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). للمخطط الشريطي الأفقي، يُرجع عبر [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). لمخططات التشتت والفقاعات هناك محوران للقيمة، لذا اختر المحور الأفقي لقيم X، والمحور العمودي لقيم Y، أو كليهما. لا تُطبق المقياس اللوغاريتمي على محور الفئة.

القاعدة اللوغاريتمية الافتراضية هي `10`. لمخططات PPTX، يمكن استخدام قاعدة من `2` إلى `1000` شاملة؛ تُدعم القواعد الكسرية مثل `2.5`. باستخدام القاعدة `10`، تكون القواسم المتتالية مثل 10، 100، 1,000، و10,000 متباعدة بمسافات متساوية.

### **قارن بين المقياس الخطي واللوغاريتمي**

ينشئ المثال التالي مخطط خط مع خمس عدد طلبات في الشريحة الأولى، ثم يستنسخ تلك الشريحة ويفعل محور قيمة لوغاريتمي بقاعدة 10 في الشريحة الثانية. كلا الشريحتين تحتفظان بنفس البيانات.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // احتفظ بالشريحة الأولى خطية وقم بتغيير مقياس محور القيمة للنسخة فقط.
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**المقياس الخطي (الشريحة 1):** تمثل المسافات العمودية المتساوية فروقاً متساوية في عدد الطلبات. تهيمن القيمة الأكبر على المخطط، مما يصعّب تمييز القيم الأصغر.

![مخطط خط في PowerPoint يُظهر خمس عدد طلبات على محور قيمة خطي](value-axis-linear.png)

**المقياس اللوغاريتمي (الشريحة 2):** تمثل المسافات العمودية المتساوية نسباً متساوية. كل فترة لديها عشرة أضعاف عدد الطلبات من السابقة، لذا تشكل النقاط خطاً صاعداً مستقيمًا على مقياس القاعدة 10. لا تزال تسميات المحور تُظهر عدد الطلبات الأصلي.

![نفس عدد الطلبات الخمس في PowerPoint على محور قيمة لوغاريتمي قاعدة 10](value-axis-logarithmic.png)

### **التعامل مع القيم الصفرية والسالبة**

يمكن للمقياس اللوغاريتمي عرض قيم موجبة فقط. افحص البيانات قبل تفعيله. إذا كانت القيم الصفرية أو السالبة ذات معنى، احتفظ بالمقياس الخطي أو اعرضها بشكل منفصل. إذا كان استبعاد تلك القيم مناسبًا للتحليل، فسّره. لا تستبدلها صمتًا بأرقام موجبة صغيرة، إذ يغيّر ذلك معنى البيانات. يجب أن تكون أي قيمة حد أدنى أو أقصى يحددها المستخدم لمحور لوغاريتمي موجبة أيضًا.

## **الأسئلة المتكررة**

**كيف أحدد القيمة التي يتقاطع عندها محور مع الآخر (تقاطع المحاور)؟**

استخدم [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) لاختيار سلوك التقاطع. لتحديد قيمة تقاطع عددية، استخدم [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). تسمح هذه الإعدادات بنقل تقاطع المحور إلى خط أساس مناسب.

**كيف يمكنني وضع تسميات العلامات بالنسبة للمحور؟**

استدعِ [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) باستخدام [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`، `High`، `NextTo`، أو `None`. للتحكم في علامات tick نفسها، استخدم [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) أو [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); هذه الخيارات منفصلة عن وضعية التسميات.