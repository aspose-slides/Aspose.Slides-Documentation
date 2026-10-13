---
title: تخصيص محاور المخططات في العروض التقديمية باستخدام Java
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
- موقع المحور
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف كيف تستخدم Aspose.Slides for Java لتخصيص محاور المخططات في عروض PowerPoint التقديمية للتقارير والتصورات."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص محاور المخططات باستخدام Aspose.Slides للغة Java. وتغطي القيم المحسوبة للمحاور، وتبديل صفوف وأعمدة المخطط، وإظهار المحاور، وفواصل تسميات الفئات وعلامات الفواصل، وفئات التاريخ والتنسيق، وتدوير العنوان، ووضع المحور، ووحدات العرض، والتدرج اللوغاريتمي.

## **الحصول على القيم القصوى على المحور العمودي في المخططات**

قم بإنشاء [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) وإضافة مخطط مساحة ببيانات افتراضية. استدعِ [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) قبل قراءة القيم المحسوبة للمحاور لضمان أن تخطيط المخطط محدث.

اقرأ [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) و [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) للحصول على حدود المحور، و [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) و [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) لفواصل العلامات. وتُوفر [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) و [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) مقاييس الوقت، وهي ذات صلة بمحاور التاريخ. يقوم المثال بتخزين هذه القيم في متغيرات محلية وحفظ المخطط.

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

استخدم [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) لتبديل أدوار السلاسل والفئات في بيانات المخطط. كل فئة سابقة تصبح سلسلة، وكل سلسلة سابقة تصبح فئة. يغيّر هذا طريقة تجميع البيانات؛ ولا يقوم بتبديل المحاور الأفقية والرأسية. يستخدم المثال [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) لربط البيانات الافتراضية بـ `Sheet1!A1:D5`، بما في ذلك صف الرأس وعمود الفئة، قبل تبديل الصفوف والأعمدة. يقوم بحفظ مخطط بأربع سلاسل وثلاث فئات.

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

## **تعطيل المحور العمودي لمخططات الخط**

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

## **تعطيل المحور الأفقي لمخططات الخط**

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

## **تغيير محور الفئة**

استخدم [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) لاختيار محور فئة تاريخي أو نصي. يتطلب هذا المثال الملف `ExistingChart.pptx`، حيث يكون المخطط هو الشكل الأول في الشريحة الأولى وتحتوي خلايا الفئة على قيم تاريخ رقمية من Excel. يغيّر ذلك المحور الأفقي إلى محور تاريخ. استدعاء [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) مع `false`، و[setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) مع `1`، و[setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) مع `TimeUnitType.Months` يضع العلامات الرئيسية على فواصل شهرية.

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

## **التحكم في فواصل تسميات محور الفئة**

عند وجود العديد من الفئات في المخطط، قلل عدد تسميات المحور الظاهرة دون إزالة الفئات أو نقاط البيانات. استدعِ [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) مع `false`، ثم مرّر الفاصل الفئوي المطلوب إلى [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). بالنسبة للفئات النصية بترتيبها العادي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات المعروضة في المثال |
| --- | --- |
| `1` | الفئة 1، الفئة 2، الفئة 3، ... الفئة 24 |
| `2` | الفئة 1، الفئة 3، الفئة 5، ... الفئة 23 |
| `3` | الفئة 1، الفئة 4، الفئة 7، ... الفئة 22 |

الفاصل `3` يعرض كل تسمية ثالثة، ويترك تسميتين مخفيتين بين التسميات المعروضة. ولا يزيل الأعمدة المقابلة. يختار التباعد التلقائي فاصلًا بناءً على المساحة المتاحة؛ ولا يعني بالضرورة عرض كل تسمية.

لعلامات الفواصل تحكم منفصل. استدعِ [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) مع `false` واستخدم [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) لتعيين فاصلها. على سبيل المثال، `1` يحافظ على علامة فاصل عند كل فاصل فئة بينما تظهر التسميات فقط كل فئة ثالثة. استخدم [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) بنمط مرئي لتتمكن من رؤية النتيجة. استدعاء أي من مُعينات التباعد التلقائي مع `true` مرة أخرى يسمح للمخطط باختيار ذلك الفاصل مرة أخرى.

المثال التالي المستقل يُنشئ 24 فئة وسلسلة واحدة، ثم يحفظ ثلاث شرائح في الملف `CategoryAxisIntervals.pptx`: التباعد التلقائي، التباعد اليدوي للتسميات مع علامات فواصل مستقلة، واستعادة التباعد التلقائي. النسختان تحتفظان ببيانات المخطط الأصلية. لا يُستَخدم عرض تقديمي كمدخل. يجعل نص التسمية الأفقية فرق الكثافة واضحًا.

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

    // الشريحة 2: إظهار كل تسمية ثالثة، ولكن احتفظ بعلامة فاصل لكل فئة.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // الشريحة 3: دع المخطط يختار كلا الفاصلين مرة أخرى.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**التباعد التلقائي (الشريحة 1):** في هذا العرض، تُعرض كل تسمية فئة ثانية وتُلف إلى سطرين. قد يختلف الناتج التلقائي حسب حجم المخطط، الخطوط، وعامِل العرض.

![التباعد التلقائي لتسميات الفئات مع ظهور جميع الأعمدة الـ 24](category-axis-automatic.png)

**التباعد اليدوي (الشريحة 2):** كل تسمية ثالثة تُعرض في سطر واحد، بينما تبقى علامات الفواصل عند كل فاصل فئة. جميع الأعمدة الـ 24، بما في ذلك تلك التي لا تحتوي على تسميات، تظل مرئية بنفس القيم. الشريحة 3 تستعيد المظهر التلقائي المعروض أعلاه.

![فاصل يدوي لتسمية الفئة ثلاثة مع ظهور جميع الأعمدة الـ 24](category-axis-manual.png)

### **اختر المحور والفاصل الصحيحين**

استخدم هذا الفاصل بناءً على عدد الفئات لمحور فئة نصي، مثل محور الفئة في مخطط عمودي، خطي، مساحي، أو شريطي. في المخطط العمودي يكون هو المحور الأفقي. في المخطط الشريطي الأفقي يكون محور الفئة عموديًا، لذا طبّق هذه الإعدادات على المحور الذي تُعيده [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). ينطبق تباعد علامات الفواصل أيضًا على محور السلسلة في المخططات التي تحتوي على واحد.

لا تستخدم تباعد تسميات الفئة لتحديد المقياس الرقمي لمحور القيم. على محور القيم، يحدد [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) الفارق بين القيم: على سبيل المثال، وحدة رئيسية قيمتها `10` تُنتج علامات عند 0، 10، 20، وهكذا عندما يبدأ المحور من الصفر. فاصل تسميات الفئة `3` يحسب مواقع الفئات بغض النظر عن قيم البيانات. تستخدم مخططات التشتت والفقاعات محاور القيم بدلاً من محور فئة نصية. لمحور تاريخ، استخدم الوحدات الرئيسية المستندة إلى الوقت والمقاييس كما هو موضح في [Change a Category Axis](#change-a-category-axis).

## **ضبط تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال بيانات المخطط الافتراضية بأربع قيم سنوية. تُخزن التواريخ كأرقام تسلسل OLE Automation في ورقة العمل الأولى (الفهرس `0`)، محسوبة كعدد الأيام منذ 30 ديسمبر 1899 لهذه التواريخ. استخدم [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) مع `CategoryAxisType.Date`، استدعِ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) مع `false`، ومرّر `yyyy` إلى [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) لجعل تسميات الفئة تعرض سنوات بأربع أرقام بشكل مستقل عن تنسيق الخلية.

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

## **ضبط زاوية الدوران لعنوان محور المخطط**

استدعِ [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) مع `true` على المحور العمودي، وزد نص العنوان، واستخدم [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) لتدوير العنوان. تُقاس الزاوية بالدرجات؛ يحفظ هذا المثال مخططًا عموديًا مع عنوان محور القيم مدورًا بزاوية 90 درجة.

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

## **ضبط موضع المحور على محور الفئة أو القيمة**

استخدم [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) للتحكم فيما إذا كان محور القيم يقطع محور الفئة بين الفئات أو عند علامات الفئة. يُطبق هذا الإعداد على محاور الفئة. يضبط المثال قيمته إلى `true` على محور الفئة الأفقي في مخطط عمودي ويحفظ النتيجة.

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

## **ضبط وحدة العرض على محور قيمة المخطط**

استخدم [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) لتكبير أو تصغير التسميات على محور القيمة دون تغيير البيانات الأساسية. عند ضبط [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) إلى `Millions`، تُعرض القيمة 60,000,000 كـ 60. يُنشئ المثال مخططًا عموديًا ويطبق وحدة العرض بالملايين على محوره العمودي.

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

محور القيمة اللوغاريتمي مفيد عندما تتراوح القيم الموجبة عبر عدة أوامر من الحجم. على سبيل المثال، قد يتلقى خدمة 10، 100، 1,000، 10,000، و100,000 طلبًا خلال خمس فترات. على مقياس خطي، تظهر القيم الأصغر متقاربة قرب الصفر. تجعل المقياس اللوغاريتمي نموها النسبي أسهل للمقارنة: تمثل المسافات المتساوية نسبًا متساوية بدلاً من اختلافات متساوية.

استدعِ [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) مع `true` على محور القيمة واستخدم [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) لاختيار القاعدة. يغيّر هذا طريقة عرض القيم الحالية؛ ولا يغير البيانات ولا يُضيف خط اتجاه لوغاريتمي. يُمثل خط الاتجاه علاقة ملائمة في البيانات وهو ميزة منفصلة.

### **اختر محور القيمة والقاعدة**

في مخطط خط أو عمودي، يُعيد [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) محور القيمة. في المخطط الشريطي الأفقي، يُعيد [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) محور القيمة. تحتوي مخططات التشتت والفقاعات على محورين للقيمة، لذا اختر المحور الأفقي لقيم X، والمحور العمودي لقيم Y، أو كليهما. لا تُطبق التدرج اللوغاريتمي على محور الفئة.

القاعدة اللوغاريتمية الافتراضية هي `10`. في مخططات PPTX، استخدم قاعدة بين `2` و`1000` شاملًا؛ وتدعم القواعد الكسرية مثل `2.5`. مع القاعدة `10`، تكون القوى المتتابعة مثل 10، 100، 1,000، و10,000 متساوية المسافة.

### **قارن بين التدرج الخطي واللوغاريتمي**

المثال التالي المستقل يُنشئ مخططًا خطيًا يحتوي على خمس عدد طلبات في الشريحة الأولى، ثم ينسخ تلك الشريحة ويفعل محور قيمة لوغاريتمي بقاعدة 10 في الشريحة الثانية. تحتفظ الشرائحان بنفس البيانات.

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

    // احتفظ بالشريحة الأولى خطيًا وقم بتغيير مقياس محور القيمة للنسخة فقط.
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

**التدرج الخطي (الشريحة 1):** المسافات العمودية المتساوية تمثل اختلافات متساوية في عدد الطلبات. القيمة الأكبر تهيمن على المخطط، مما يصعب تمييز القيم الأصغر.

![مخطط خط في PowerPoint يُظهر خمس عدد طلبات على محور قيمة خطي](value-axis-linear.png)

**التدرج اللوغاريتمي (الشريحة 2):** المسافات العمودية المتساوية تمثل نسبًا متساوية. كل فترة لديها عشرة أضعاف عدد الطلبات مقارنة بالفترة السابقة، لذا تُكوّن النقاط خطًا مستقيمًا صاعدًا على مقياس القاعدة 10. لا تزال تسميات المحور تعرض عدد الطلبات الأصلي.

![نفس خمس عدد طلبات في PowerPoint على محور قيمة لوغاريتمي بقاعدة 10](value-axis-logarithmic.png)

### **معالجة القيم الصفرية والسالبة**

يمكن للمقياس اللوغاريتمي عرض القيم الموجبة فقط. تحقق من البيانات قبل تمكينه. إذا كانت القيم الصفرية أو السالبة ذات معنى، احتفظ بمقياس خطي أو اعرضها بشكل منفصل. إذا كان استبعاد تلك القيم مناسبًا للتحليل، فسِّر الإغفال. لا تستبدلها صامتًا بأعداد موجبة صغيرة، فهذا يغيّر معنى البيانات. يجب أن يكون أي حد أدنى أو أقصى مُكوَّن يدويًا لمحور لوغاريتمي إيجابيًا أيضًا.

## **الأسئلة الشائعة**

**كيف يمكنني ضبط القيمة التي يلتقي عندها محور واحد بالآخر (تقاطع المحور)؟**

استخدم [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) لتحديد سلوك التقاطع. لتحديد قيمة تقاطع رقمية، استخدم [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). تسمح لك هذه الإعدادات بنقل تقاطع المحور إلى خط أساس مناسب.

**كيف يمكنني وضع تسميات العلامات بالنسبة للمحور؟**

استدعِ [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) باستخدام [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`، `High`، `NextTo`، أو `None`. للتحكم في علامات الفواصل نفسها، استخدم [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) أو [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); هذه منفصلة عن وضع التسميات.