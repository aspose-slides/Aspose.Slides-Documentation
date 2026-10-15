---
title: تخصيص محاور المخطط في العروض التقديمية باستخدام Java
linktitle: محور المخطط
type: docs
url: /ar/java/chart-axis/
keywords:
- محور المخطط
- المحور الرأسي
- المحور الأفقي
- تخصيص المحور
- التلاعب بالمحور
- إدارة المحور
- خصائص المحور
- القيمة العظمى
- القيمة الصغرى
- خط المحور
- تنسيق التاريخ
- عنوان المحور
- موضع المحور
- PowerPoint
- العرض التقديمي
- Java
- Aspose.Slides
description: "اكتشف كيفية استخدام Aspose.Slides for Java لتخصيص محاور المخطط في عروض PowerPoint التقديمية للتقارير والمرئيات."
---
## **نظرة عامة**

هذه المقالة توضح كيفية تخصيص محاور المخطط باستخدام Aspose.Slides for Java. تغطي القيم المحسوبة للمحاور، تبديل صفوف وأعمدة المخطط، إظهار المحور، فواصل تسمية الفئات وعلامات الخط، الفئات التاريخية والتنسيق، دوران العنوان، موقع المحور، وحدات العرض، والقياس اللوغاريتمي.

## **الحصول على القيم العظمى على المحور الرأسي في المخططات**

أنشئ [العرض التقديمي](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) وأضف مخطط منطقة ببيانات افتراضية. استدعِ [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) قبل قراءة قيم المحور المحسوبة لضمان تحديث تخطيط المخطط.

اقرأ [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) و[getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) للحصول على حدود المحور، و[getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) و[getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) لفواصل العلامات. توفر [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) و[getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) مقاييس وحدة الزمن، وهي ذات صلة بمحاور التاريخ. يخزن المثال هذه القيم في متغيرات محلية ويحفظ المخطط.

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

استخدم [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) لتبادل أدوار السلاسل والفئات في بيانات المخطط. كل فئة سابقة تصبح سلسلة، وكل سلسلة سابقة تصبح فئة. هذا يغير طريقة تجميع البيانات؛ لا يبدل المحاور الأفقية والرأسية. يستخدم المثال [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) لربط البيانات الافتراضية بـ `Sheet1!A1:D5`، بما في ذلك صف العنوان وعمود الفئة، قبل تبديل الصفوف والأعمدة. يحفظ المخطط بأربع سلاسل وثلاث فئات.

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

## **عكس ترتيب الرسم لمحور**

استخدم [setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) لعكس فئة أو قيمة محور. على سبيل المثال، يمكن لمخطط شريطي أفقي أن يعرض مراحل المشروع من الأعلى إلى الأسفل بنفس ترتيب ورقة العمل: التخطيط، التطوير، الاختبار. عكس المحور يغير اتجاه الرسم؛ لا يقوم بفرز أو إعادة ترتيب بيانات المصنف. بالمقابل، [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) يبادل أدوار السلاسل والفئات.

المثال التالي ينشئ مخطط شريطي أفقي بثلاث مراحل وسلسلة واحدة. يحفظ عرضًا تقديميًا بثلاث شرائح: الترتيب العادي، الفئات المعكوسة، والقيم المعكوسة. كل نسخة تستخدم نفس مجموعة البيانات، ويُعكِس محور واحد فقط في كل نسخة.

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
    // إبقاء محور القيمة الأفقي في الأسفل.
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

يمكن لعكس المحور أيضًا نقل المحور المتقاطع إلى الجانب المقابل من الرسم. يتحكم [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) بمكان تقاطع المحور الآخر مع المحور المُكوَّن. في الشريحة 2، يستدعيه بـ `CrossesType.Maximum` على محور الفئة المعكوس ليبقي محور القيمة الأفقي في الأسفل. لتحديد نقطة تقاطع معينة، استخدم [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). تحقق من إعدادات التقاطع عند تغيير الاتجاه، خاصة إذا كان المخطط يحتوي بالفعل على نقطة تقاطع مخصصة. استدعِ `setPlotOrderReversed` بـ `false` لاستعادة اتجاه الرسم الطبيعي؛ إعدادات التقاطع منفصلة.

| الترتيب العادي (الشريحة 1) | الفئات المعكوسة (الشريحة 2) | القيم المعكوسة (الشريحة 3) |
| --- | --- | --- |
| ![مخطط شريطي أفقي بترتيب فئة وقيمة عادي](axis-order-normal.png) | ![مخطط شريطي أفقي مع الفئات المعروضة من الأعلى إلى الأسفل](axis-order-categories-reversed.png) | ![مخطط شريطي أفقي بمحور قيمة معكوس والصفر على اليمين](axis-order-values-reversed.png) |
| الفئات تمتد من الأسفل إلى الأعلى؛ القيم تزيد من اليسار إلى اليمين. | التخطيط، التطوير، والاختبار تمتد من الأعلى إلى الأسفل. القيم وترتيب صفوف المصنف لم يتغيرا. | الفئات تحتفظ بترتيبها الطبيعي؛ القيم تزيد من اليمين إلى اليسار. محور الفئة يتقاطع عند الصفر على اليمين. |

## **إلغاء إظهار المحور الرأسي لرسوم الخطوط**

استدعِ [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) بـ `false` على المحور الرأسي لإخفائه. يخلق المثال مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور الرأسي.

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

## **إلغاء إظهار المحور الأفقي لرسوم الخطوط**

استدعِ [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) بـ `false` على المحور الأفقي لإخفائه. يخلق المثال مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور الأفقي.

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

## **تغيير محور الفئة**

استخدم [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) لاختيار محور فئة تاريخي أو نصي. يتطلب هذا المثال الملف `ExistingChart.pptx`، مع مخطط كأول شكل في الشريحة الأولى وخلايا فئة تحتوي على قيم تواريخ Excel رقمية. يغيّر المحور الأفقي إلى محور تاريخ. استدعِ [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) بـ `false`، و[setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) بـ `1`، و[setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) بـ `TimeUnitType.Months` لتحديد الفواصل الشهرية للعلامات الكبيرة.

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

## **التحكم في فواصل تسمية محور الفئة**

عند وجود عدد كبير من الفئات في مخطط، قلل عدد تسميات المحور الظاهرة دون إزالة الفئات أو نقاط البيانات. استدعِ [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) بـ `false`، ثم مرّر الفاصل الفئوي المرغوب إلى [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). بالنسبة للفئات النصية بترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات المعروضة في المثال |
| --- | --- |
| `1` | الفئة 1، الفئة 2، الفئة 3، … الفئة 24 |
| `2` | الفئة 1، الفئة 3، الفئة 5، … الفئة 23 |
| `3` | الفئة 1، الفئة 4، الفئة 7، … الفئة 22 |

فاصل `3` يعرض كل تسمية ثالثة، مخفيًا تسميتين بين كل تسمية معروضة. لا يزيل الأعمدة المقابلة. يختار الفاصل التلقائي بناءً على المساحة المتاحة؛ لا يعرض بالضرورة كل تسمية.

علامات الخط لها تحكم منفصل. استدعِ [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) بـ `false` واستخدم [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) لتحديد فاصلها. على سبيل المثال، `1` يبقي علامة خط عند كل فاصل فئة بينما تظهر التسميات كل فئة ثالثة فقط. استخدم [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) بنمط مرئي لتتمكن من رؤية النتيجة. استدعاء أي من محددات الفواصل التلقائية بـ `true` مرة أخرى يسمح للمخطط باختيار الفاصل تلقائيًا مرة أخرى.

المثال المستقل التالي ينشئ 24 فئة وسلسلة واحدة، ثم يحفظ ثلاث شرائح في `CategoryAxisIntervals.pptx`: الفواصل التلقائية، الفواصل اليدوية مع علامات خط مستقلة، واستعادة الفواصل التلقائية. النسختان تحتفظان ببيانات المخطط الأصلية. لا يلزم عرض تقديمي إدخال. تجعل نصوص التسميات الأفقية الاختلاف في الكثافة واضحًا.

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

    // الشريحة 2: عرض كل تسمية ثالثة، لكن الإبقاء على علامة خط لكل فئة.
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

**الفواصل التلقائية (الشريحة 1):** في هذا العرض، تُعرض كل تسمية فئة ثانية وتُكّسَّر على سطرين. قد تختلف النتيجة التلقائية بحسب حجم المخطط، الخطوط، والعارض.

![مسافات تسميات فئة تلقائية مع جميع الأعمدة الـ 24 مرئية](category-axis-automatic.png)

**الفواصل اليدوية (الشريحة 2):** تُعرض كل تسمية ثالثة على سطر واحد، بينما تظل علامات الخط عند كل فاصل فئة. جميع الأعمدة الـ 24، بما فيها تلك دون تسميات، تظل مرئية بنفس القيم. الشريحة 3 تستعيد المظهر التلقائي المعروض أعلاه.

![فاصل تسميات فئة يدوي بمقدار ثلاثة مع جميع الأعمدة الـ 24 مرئية](category-axis-manual.png)

### **اختر المحور والفاصل الصحيح**

استخدم هذا الفاصل للعدد الفئوي لمحور فئة نصية، مثل محور الفئة في مخطط عمودي، خطي، مساحي أو شريطي. في مخطط عمودي، يكون هو المحور الأفقي. في مخطط شريطي أفقي، يكون محور الفئة عموديًا، لذا طبّق هذه الإعدادات على المحور الذي تُرجعه [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). ينطبق فاصل علامات الخط أيضًا على محور السلسلة في المخططات التي تحتوي على واحد.

لا تستخدم فواصل تسمية الفئة لضبط المقياس الرقمي لمحور القيمة. في محور القيمة، يحدد [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) فرق القيم: على سبيل المثال، وحدة رئيسية `10` تنتج علامات عند 0، 10، 20، وهكذا عندما يبدأ المحور من الصفر. فاصل تسمية الفئة `3` يعد مواضع الفئات بغض النظر عن قيم البيانات. تستخدم مخططات التشتت والفقاعات محاور قيمة بدلاً من محور فئة نصية. بالنسبة لمحور التاريخ، استخدم الوحدات والمقاييس الزمنية كما هو موضح في [تغيير محور الفئة](#change-a-category-axis).

## **تعيين تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال البيانات الافتراضية للمخطط بأربع قيم سنوية. تُخزن التواريخ كأرقام تسلسلية OLE Automation في الورقة الأولى (الفهرس `0`)، محسوبة كعدد الأيام منذ 30 ديسمبر 1899. استخدم [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) مع `CategoryAxisType.Date`، استدعِ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) بـ `false`، ومرّر `yyyy` إلى [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) ليعرض تسميات الفئة سنوات بأربعة أرقام بشكل مستقل عن تنسيق الخلية.

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

## **تعيين زاوية الدوران لعنوان محور المخطط**

استدعِ [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) بـ `true` على المحور الرأسي، قدم نص العنوان، واستخدم [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) لتدوير العنوان. تُقاس الزاوية بالدرجات؛ يحفظ المثال مخطط عمودي بعنوان محور قيم مدور بـ 90 درجة.

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

## **تعيين موقع المحور على محور فئة أو قيمة**

استخدم [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) للتحكم فيما إذا كان محور القيمة يتقاطع مع محور الفئة بين الفئات أو عند علامات الفئة. هذا الإعداد يطبق على محاور الفئة. يضبط المثال القيمة إلى `true` على المحور الفئوي الأفقي لمخطط عمودي ويحفظ النتيجة.

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

استخدم [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) لتكبير التسميات على محور القيمة دون تغيير البيانات الأساسية. مع [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) مضبوطًا على `Millions`، يُعرض القيمة 60,000,000 كـ 60. ينشئ المثال مخطط عمودي ويطبق وحدة العرض بالملايين على محوره الرأسي.

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

## **تهيئة محور قيمة لوغاريتمي**

يكون محور القيمة اللوغاريتمي مفيدًا عندما تمتد القيم الإيجابية عبر عدة مرتّبات من القيم. على سبيل المثال، قد يتلقى خدمة 10، 100، 1,000، 10,000، و100,000 طلبًا على مدار خمس فترات. على مقياس خطي، تظهر القيم الصغيرة متقاربة بالقرب من الصفر. يسهّل المقياس اللوغاريتمي مقارنتها لأن المسافات المتساوية تمثل نسبًا متساوية بدلاً من فروق متساوية.

استدعِ [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) بـ `true` على محور القيمة واستخدم [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) لتحديد القاعدة. يغيّر هذا طريقة عرض القيم الحالية؛ لا يغيّر البيانات ولا يضيف خط اتجاه لوغاريتمي. خط الاتجاه يمثل علاقة مُلائمة في البيانات وهو ميزة منفصلة.

### **اختر محور القيمة والقاعدة**

لمخطط خطي أو عمودي، يُرجع محور القيمة بواسطة [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). للمخطط الشريطي الأفقي، يُرجع بواسطة [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). للمخططات المتناثرة والفقاعية هناك محوران للقيمة؛ اختر المحور الأفقي لقيم X، والمحور الرأسي لقيم Y، أو كليهما. لا تُطبق القياس اللوغاريتمي على محور الفئة.

القاعدة اللوغاريتمية الافتراضية هي `10`. لمخططات PPTX، استخدم قاعدة من `2` إلى `1000` شاملًا؛ القواعد الكسرية مثل `2.5` مدعومة أيضًا. مع القاعدة `10`، تكون القوى المتتابعة مثل 10، 100، 1,000، و10,000 متباعدة بالتساوي.

### **قارن بين القياس الخطي واللوغاريتمي**

المثال التالي المستقل ينشئ مخططًا خطيًا بعدد الطلبات الخمسة في الشريحة الأولى، ثم ينسخ تلك الشريحة ويفعّل محور قيمة لوغاريتمي بقاعدة 10 في الثانية. تحتفظ كلتا الشريحتين بنفس البيانات.

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

    // احتفظ بالشريحة الأولى خطيًا وتغيّر فقط مقياس محور القيمة للنسخة.
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

**الميزان الخطي (الشريحة 1):** المسافات الرأسية المتساوية تمثل فروقًا متساوية في عدد الطلبات. تهيمن القيمة الأكبر على المخطط، مما يصعّب تمييز القيم الأصغر.

![مخطط خطي في PowerPoint يُظهر خمس طلبات على محور قيمة خطي](value-axis-linear.png)

**الميزان اللوغاريتمي (الشريحة 2):** المسافات الرأسية المتساوية تمثل نسبًا متساوية. كل فترة لديها عشر مرات طلبات أكثر من السابقة، لذا تشكل النقاط خطًا مستقيمًا صاعدًا على مقياس القاعدة 10. لا تزال تسميات المحور تُظهر عدد الطلبات الأصلي.

![نفس طلبات الخمس في PowerPoint على محور قيمة لوغاريتمي بقاعدة 10](value-axis-logarithmic.png)

### **التعامل مع القيم الصفرية والسالبة**

يمكن للميزان اللوغاريتمي عرض قيم موجبة صارمة فقط. تحقق من البيانات قبل تفعيله. إذا كانت القيم الصفرية أو السالبة ذات معنى، حافظ على مقياس خطي أو اعرضها بشكل منفصل. إذا كان استبعاد تلك القيم مناسبًا للتحليل، فسر الإغفال. لا تستبدلها صمتًا بأرقام إيجابية صغيرة، حيث يغير ذلك معنى البيانات. أي حد أدنى أو أقصى يُحدد يدويًا لمحور لوغاريتمي يجب أن يكون إيجابيًا أيضًا.

## **الأسئلة الشائعة**

**كيف يمكنني تحديد القيمة التي يلتقي فيها أحد المحاور مع الآخر (تقاطع المحاور)؟**

استخدم [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) لتحديد سلوك التقاطع. لتحديد قيمة تقاطع رقمية، استخدم [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). تسمح لك هذه الإعدادات بنقل تقاطع المحور إلى خط أساس مناسب.

**كيف يمكنني موضع تسميات العلامات بالنسبة للمحور؟**

استدعِ [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) باستخدام [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`، `High`، `NextTo`، أو `None`. للتحكم في علامات الخط نفسها، استخدم [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) أو [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); هذه منفصلة عن موضع التسميات.