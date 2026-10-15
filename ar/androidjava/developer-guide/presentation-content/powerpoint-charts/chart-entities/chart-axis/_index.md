---
title: تخصيص محاور المخططات في العروض التقديمية على Android
linktitle: محور المخطط
type: docs
url: /ar/androidjava/chart-axis/
keywords:
- محور المخطط
- المحور الرأسي
- المحور الأفقي
- تخصيص المحور
- معالجة المحور
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
- Android
- Java
- Aspose.Slides
description: "اكتشف كيفية استخدام Aspose.Slides for Android عبر Java لتخصيص محاور المخططات في عروض PowerPoint التقديمية للتقارير والمرئيات."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص محاور المخطط باستخدام Aspose.Slides for Android عبر Java. تغطي القيم المحسوبة للمحاور، تبديل صفوف وأعمدة المخطط، إظهار أو إخفاء المحور، فواصل تسميات الفئات وعلامات التحديد، فئات التاريخ وتنسيقها، تدوير العنوان، وضع المحور، وحدات العرض، والتدرج اللوغاريتمي.

## **الحصول على القيم القصوى على المحور الرأسي في المخططات**

أنشئ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) وأضف مخططًا مساحيًا بالبيانات الافتراضية. استدعِ [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) قبل قراءة القيم المحسوبة للمحاور حتى يكون تخطيط المخطط محدثًا.

اقرأ [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) و [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) للحصول على حدود المحور، و [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) و [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) لفواصل العلامات. توفر [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) و [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) مقاييس زمنية، وهي ذات صلة بمحاور التاريخ. يقوم المثال بتخزين هذه القيم في متغيرات محلية ويحفظ المخطط.

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

استخدم [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) لتبادل أدوار السلاسل والفئات في بيانات المخطط. تصبح كل فئة سابقة سلسلة، وكل سلسلة سابقة فئة. هذا يغيّر طريقة تجميع البيانات؛ ولا يبدل المحاور الأفقية والرأسية. يستخدم المثال [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) لربط البيانات الافتراضية بـ `Sheet1!A1:D5`، بما في ذلك صف العنوان وعمود الفئة، قبل تبديل الصفوف والأعمدة. ثم يحفظ مخططًا بأربع سلاسل وثلاث فئات.

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

استخدم [setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) لعكس محور فئة أو قيمة. على سبيل المثال، يمكن لمخطط شريطي أفقي إظهار مراحل المشروع من الأعلى إلى الأسفل بنفس ترتيب ورقة العمل: التخطيط، التطوير، الاختبار. عكس المحور يغيّر اتجاه الرسم؛ ولا يفرز أو يعيد ترتيب بيانات المصنف. بالمقارنة، يقوم [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) بتبادل أدوار السلاسل والفئات.

المثال التالي ينشئ مخططًا شريطيًا أفقيًا بثلاث مراحل وسلسلة واحدة. يحفظ عرضًا تقديميًا بثلاث شرائح: الترتيب العادي، الفئات المعكوسة، والقيم المعكوسة. كل نسخة تستخدم نفس مجموعة البيانات، ويتم عكس محور واحد فقط في كل نسخة.

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

    // الشريحة 3: عكس مقياس الأعداد الأفقي فقط.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يمكن أيضًا عند عكس محور نقل المحور المتعامد إلى الجانب المقابل من الرسم. يتحكم [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) في مكان عبور المحور الآخر مع المحور المُكوَّن. في الشريحة 2، يتم استدعاؤه بـ `CrossesType.Maximum` على محور الفئة المعكوس لتبقى محور القيمة الأفقي في الأسفل. لنقطة عبور محددة، استخدم [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). تحقق من إعدادات العبّور عند تغيير الاتجاه، خاصةً إذا كان المخطط يحتوي بالفعل على نقطة عبور مخصصة. استدعِ `setPlotOrderReversed` بـ `false` لاستعادة اتجاه الرسم العادي؛ إعدادات العبّور منفصلة.

| الترتيب العادي (الشريحة 1) | الفئات المعكوسة (الشريحة 2) | القيم المعكوسة (الشريحة 3) |
| --- | --- | --- |
| ![مخطط شريطي أفقي بترتيب فئة وقيمة عادي](axis-order-normal.png) | ![مخطط شريطي أفقي مع عرض الفئات من الأعلى إلى الأسفل](axis-order-categories-reversed.png) | ![مخطط شريطي أفقي مع محور قيمة معكوس والصفر على اليمين](axis-order-values-reversed.png) |
| الفئات تمتد من الأسفل إلى الأعلى؛ القيم تزداد من اليسار إلى اليمين. | التخطيط، التطوير، والاختبار تمتد من الأعلى إلى الأسفل. القيم وترتيب صفوف المصنف لم يتغيرا. | الفئات تحتفظ بترتيبها الطبيعي؛ القيم تزداد من اليمين إلى اليسار. يعبر محور الفئة عند الصفر على اليمين. |

## **إلغاء إظهار المحور الرأسي للمخططات الخطية**

استدعِ [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) بـ `false` على المحور الرأسي لإخفائه. ينشئ المثال مخططًا خطيًا بالبيانات الافتراضية ويحفظه مع إخفاء المحور الرأسي.

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

## **إلغاء إظهار المحور الأفقي للمخططات الخطية**

استدعِ [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) بـ `false` على المحور الأفقي لإخفائه. ينشئ المثال مخططًا خطيًا بالبيانات الافتراضية ويحفظه مع إخفاء المحور الأفقي.

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

استخدم [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) لاختيار محور فئة تاريخ أو نص. يتطلب هذا المثال ملف `ExistingChart.pptx`، مع مخطط كأول شكل في الشريحة الأولى وخلايا فئة تحتوي على قيم تاريخ Excel رقمية. يغيّر المحور الأفقي إلى محور تاريخ. استدعِ [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) بـ `false`، ثم [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) بـ `1`، و [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) بـ `TimeUnitType.Months` لتحديد العلامات الرئيسية بفواصل شهرية.

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

عند وجود عدد كبير من الفئات، قلل عدد تسميات المحور الظاهرة دون إزالة الفئات أو النقاط البيانية. استدعِ [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) بـ `false`، ثم مرّر الفاصل المطلوب إلى [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). للفئات النصية بترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات المعروضة في المثال |
| --- | --- |
| `1` | الفئة 1، الفئة 2، الفئة 3، … الفئة 24 |
| `2` | الفئة 1، الفئة 3، الفئة 5، … الفئة 23 |
| `3` | الفئة 1، الفئة 4، الفئة 7، … الفئة 22 |

يعرض الفاصل `3` كل تسمية ثالثة، ويترك تسميتين مخفيتين بين كل تسمية معروضة. لا يتم إزالة الأعمدة المقابلة. يختار الفاصل التلقائي بناءً على المساحة المتاحة؛ ولا يعرض بالضرورة كل تسمية.

لعلامات التحديد فواصل مستقلة. استدعِ [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) بـ `false` واستخدم [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) لتحديد فاصلها. على سبيل المثال، `1` يبقي علامة تحديد عند كل فاصل فئة بينما تظهر التسميات كل فئة ثالثة فقط. استخدم [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) بنمط مرئي لتتمكن من رؤية النتيجة. استدعاء أي من محددات الفاصل التلقائي بـ `true` مرةً أخرى يسمح للمخطط باختيار الفاصل تلقائيًا مرة أخرى.

المثال التالي المستقل ينشئ 24 فئة وسلسلة واحدة، ثم يحفظ ثلاث شرائح في `CategoryAxisIntervals.pptx`: الفاصل التلقائي، الفاصل اليدوي مع علامات تحديد مستقلة، واستعادة الفاصل التلقائي. تحتفظ النسختان بالبيانات الأصلية للمخطط. لا يلزم وجود عرض تقديمي إدخالي. يجعل نص التسمية الأفقي الاختلاف في الكثافة واضحًا.

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

    // الشريحة 2: عرض كل تسمية ثالثة، لكن إبقاء علامة تحديد لكل فئة.
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

**الفاصل التلقائي (الشريحة 1):** في هذا العرض، يتم عرض كل تسمية فئة ثانية وتلتف على سطرين. قد يختلف النتيجة التلقائية حسب حجم المخطط والخطوط وواجهة العرض.

![تباعد تلقائي لتسميات فئة مع عرض جميع 24 عمودًا](category-axis-automatic.png)

**الفاصل اليدوي (الشريحة 2):** يتم عرض كل تسمية ثالثة على سطر واحد، بينما تبقى علامات التحديد عند كل فاصل فئة. جميع الأعمدة الـ 24، بما فيها غير المعنونة، تبقى مرئية بنفس القيم. الشريحة 3 تستعيد المظهر التلقائي المعروض أعلاه.

![فاصل يدوي لتسمية فئة ثلاثية مع عرض جميع 24 عمودًا](category-axis-manual.png)

### **اختر المحور والفاصل الصحيح**

استخدم هذا الفاصل لعدد الفئات لمحور فئة نصية، مثل محور الفئة في مخطط عمودي، خطي، مساحي أو شريطي. في مخطط عمودي، يكون هو المحور الأفقي. في مخطط شريطي أفقي، يكون محور الفئة عموديًا، لذا طبّق هذه الإعدادات على المحور الذي تُرجعه [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). ينطبق فاصل علامات التحديد أيضًا على محور السلسلة في المخططات التي تحتوي على واحد.

لا تستخدم فاصل تسميات الفئة لتعيين المقياس الرقمي لمحور القيمة. على محور القيمة، يحدد [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) الفرق بين القيم: على سبيل المثال، وحدة رئيسية `10` تنتج علامات عند 0، 10، 20، وهكذا عندما يبدأ المحور من الصفر. فاصل تسمية الفئة `3` يعدّ مواضع الفئات بغض النظر عن قيمها. تستخدم المخططات النقطية والفقاعية محاور قيمة بدلاً من محور فئة نصية. لمحور تاريخ، استخدم الوحدات الزمنية ومقاييسها كما هو موضح في [تغيير محور الفئة](#change-a-category-axis).

## **تعيين تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال البيانات الافتراضية للمخطط بأربع قيم سنوية. تُخزن التواريخ كأرقام تسلسلية OLE Automation في ورقة العمل الأولى (الفهرس `0`)، محسوبة كعدد الأيام منذ 30 ديسمبر 1899. يستخدم كل التقويمين توقيت UTC ويُمسح قبل تعيين التواريخ حتى لا تؤثر التغييرات الموسمية أو الوقت الحالي على الحساب. استدعِ [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) بـ `CategoryAxisType.Date`، ثم [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) بـ `false`، ومرّر `yyyy` إلى [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) لتظهر تسميات الفئة بأربع أرقام سنة مستقلة عن تنسيق الخلية.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(2015 + i, Calendar.JANUARY, 1);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, serialDate);
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

## **تعيين زاوية تدوير لعنوان محور المخطط**

استدعِ [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) بـ `true` على المحور الرأسي، قدم نص العنوان، واستخدم [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) لتدوير العنوان. تُقاس الزاوية بالدرجات؛ يحفظ المثال مخططًا عموديًا مع تدوير عنوان محور القيمة بـ 90 درجة.

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

## **تحديد موضع المحور على محور فئة أو قيمة**

استخدم [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) للتحكم فيما إذا كان محور القيمة يعبر محور الفئة بين الفئات أو عند علامات الفئة. ينطبق هذا الإعداد على محاور الفئة. يضبط المثال القيمة إلى `true` على محور الفئة الأفقي لمخطط عمودي ويحفظ النتيجة.

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

استخدم [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) لتكبير أو تصغير تسميات محور القيمة دون تغيير البيانات الأساسية. مع [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) مضبوطة على `Millions`، يُعرض القيمة 60,000,000 كـ 60. ينشئ المثال مخططًا عموديًا ويطبق وحدة العرض بالملايين على محوره الرأسي.

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

محور قيمة لوغاريتمي مفيد عندما تمتد القيم الموجبة عبر عدة درجات عديدة. على سبيل المثال، قد يتلقى خدمة 10، 100، 1,000، 10,000، و100,000 طلبًا عبر خمس فترات. على مقياس خطي، تظهر القيم الأصغر متقاربة بالقرب من الصفر. يسهّل المقياس اللوغاريتمي مقارنة النمو النسبي: المسافات المتساوية تمثل نسبًا متساوية بدلاً من اختلافات مطلقة.

استدعِ [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) بـ `true` على محور القيمة واستخدم [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) لتحديد القاعدة. يغيّر هذا طريقة عرض القيم الحالية؛ ولا يغيّر البيانات ولا يضيف خط اتجاه لوغاريتمي. خط الاتجاه يمثل علاقة مُناسبة للبيانات وهو ميزة منفصلة.

### **اختر محور القيمة والقاعدة**

للمخطط الخطي أو العمودي، يُسترجع محور القيمة بواسطة [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). للمخطط الشريطي الأفقي، يُسترجع بواسطة [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). للمخططات النقطية والفقاعية توجد محوري قيمة؛ اختر المحور الأفقي لقيم X، والمحور الرأسي لقيم Y، أو كليهما. لا تُطبق التدرج اللوغاريتمي على محور الفئة.

القاعدة اللوغاريتمية الافتراضية هي `10`. لمخططات PPTX، يمكن استخدام قاعدة من `2` إلى `1000` شاملة؛ وتُدعم القواعد الكسورية مثل `2.5`. مع القاعدة `10`، تُتوزع القوى المتتالية مثل 10، 100، 1,000، و10,000 بالتساوي.

### **مقارنة التدرج الخطي واللوغاريتمي**

ينشئ المثال المستقل مخططًا خطيًا بخمس عدادات طلب في الشريحة الأولى، ثم يستنسخ تلك الشريحة ويفعل محور قيمة لوغاريتمي بقاعدة 10 في الشريحة الثانية. تحتفظ كلتا الشريحتين بنفس البيانات.

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

    // احتفظ بالشرحة الأولى خطية وغيّر فقط مقياس محور القيمة في النسخة.
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

**مقياس خطي (الشريحة 1):** المسافات الرأسية المتساوية تمثل اختلافات عددية متساوية في عدد الطلبات. تهيمن القيمة الأكبر على المخطط، مما يصعّب التمييز بين القيم الأصغر.

![مخطط خطي في PowerPoint يظهر خمس عدادات طلب على محور قيمة خطي](value-axis-linear.png)

**مقياس لوغاريتمي (الشريحة 2):** المسافات الرأسية المتساوية تمثل نسبًا متساوية. كل فترة تحتوي على عشر مرات الطلبات السابقة، لذا تشكِّل النقاط خطًا مرتفعًا مستقيمًا على المقياس القاعدي 10. لا تزال تسميات المحور تظهر القيم الأصلية للطلبات.

![نفس خمس عدادات الطلب في PowerPoint على محور قيمة لوغاريتمي بقاعدة 10](value-axis-logarithmic.png)

### **معالجة القيم الصفرية والسلبية**

يمكن للمقياس اللوغاريتمي عرض القيم الموجبة فقط. تحقق من البيانات قبل تفعيله. إذا كانت القيم الصفرية أو السلبية ذات معنى، احتفظ بمقياس خطي أو اعرضها بشكل منفصل. إذا كان استبعاد تلك القيم مناسبًا للتحليل، فسّره. لا تستبدلها صمتًا بأرقام صغيرة موجبة، فهذا يغيّر معنى البيانات. يجب أن تكون أي حد أدنى أو أقصى مُعيّن يدويًا لمحور لوغاريتمي أيضًا موجبة.

## **الأسئلة المتكررة**

**كيف يمكنني تحديد القيمة التي يتقاطع عندها محور مع الآخر (تقاطع المحاور)؟**

استخدم [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) لتحديد سلوك التقاطع. لتحديد قيمة تقاطع رقمية، استخدم [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). تسمح لك هذه الإعدادات بنقل تقاطع المحور إلى خط أساس مناسب.

**كيف يمكنني وضع تسميات العلامات بالنسبة للمحور؟**

استدعِ [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) باستخدام [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`، `High`، `NextTo` أو `None`. للتحكم في علامات التحديد نفسها، استخدم [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) أو [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); هذه مستقلة عن موضع التسميات.