---
title: تخصيص محاور المخطط في العروض التقديمية على Android
linktitle: محور المخطط
type: docs
url: /ar/androidjava/chart-axis/
keywords:
- محور المخطط
- محور عمودي
- محور أفقي
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
- Android
- Java
- Aspose.Slides
description: "اكتشف كيفية استخدام Aspose.Slides للـ Android عبر Java لتخصيص محاور المخططات في عروض PowerPoint التقديمية للتقارير والمرئيات."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص محاور المخطط باستخدام Aspose.Slides للـ Android عبر Java. وتتضمن القيم المحسوبة للمحاور، تبديل صفوف وأعمدة المخطط، إظهار أو إخفاء المحور، فواصل تسميات الفئات وعلامات الفواصل، الفئات التاريخية وتنسيقها، تدوير العنوان، تموضع المحور، وحدات العرض، والقياس اللوغاريتمي.

## **الحصول على القيم القصوى على المحور الرأسي في المخططات**

إنشاء [العرض التقديمي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) وإضافة مخطط مساحاتي مع بيانات افتراضية. استدعِ [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) قبل قراءة القيم المحسوبة للمحاور حتى يصبح تخطيط المخطط محدثًا.

اقرأ [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) و[ getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) للحصول على حدود المحور، و[getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) و[getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) لفواصل العلامات. يُقدّم [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) و[getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) مقاييس الوقت، وهي ذات صلة بمحاور التاريخ. يخزن المثال هذه القيم في متغيرات محلية ويحفظ المخطط.

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

استخدم [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) لتبادل أدوار السلاسل والفئات في بيانات المخطط. كل فئة سابقة تصبح سلسلة، وكل سلسلة سابقة تصبح فئة. يغيّر هذا طريقة تجميع البيانات؛ ولا يبدل المحورين الأفقي والرأسي. يستخدم المثال [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) لربط البيانات الافتراضية بـ `Sheet1!A1:D5`، متضمنًا صف العنوان وعمود الفئة، قبل تبديل الصفوف والأعمدة. ثم يحفظ مخططًا بأربع سلاسل وثلاث فئات.

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

## **عكس ترتيب الرسم للمحور**

استخدم [setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) لعكس محور الفئة أو القيمة. على سبيل المثال، يمكن لمخطط شريطي أفقي إظهار مراحل المشروع من الأعلى إلى الأسفل بنفس ترتيب ورقة العمل: التخطيط، التطوير، الاختبار. عكس المحور يغيّر اتجاه الرسم؛ ولا يقوم بفرز أو إعادة ترتيب بيانات المصنف. بالمقارنة، [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) يبدّل أدوار السلاسل والفئات.

المثال التالي ينشئ مخطط شريطي أفقي بثلاث مراحل وسلسلة واحدة. يحفظ عرضًا تقديميًا بثلاث شرائح: الترتيب الطبيعي، الفئات المقلوبة، والقيم المقلوبة. تستخدم كل نسخة نفس مجموعة البيانات، ويتم عكس محور واحد فقط في كل نسخة.

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
    // الإبقاء على محور القيمة الأفقي في الأسفل.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // الشريحة 3: عكس المقياس الرقمي الأفقي فقط.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يمكن أيضًا لعكس المحور نقل المحور المتعامد إلى الجانب المقابل من الرسم. يتحكم [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) في مكان تقاطع المحور الآخر مع المحور الجاري تكوينه. في الشريحة 2، استدعاؤه بـ `CrossesType.Maximum` على محور الفئة المقلوب يبقي محور القيمة الأفقي في الأسفل. لنقطة تقاطع محددة، استخدم [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). تحقق من إعدادات التقاطع عند تغيير الاتجاه، خاصة إذا كان المخطط يحتوي مسبقًا على نقطة تقاطع مخصصة. استدعِ `setPlotOrderReversed` بـ `false` لاستعادة اتجاه الرسم الطبيعي؛ إعدادات التقاطع مستقلة.

| الترتيب الطبيعي (الشريحة 1) | الفئات المقلوبة (الشريحة 2) | القيم المقلوبة (الشريحة 3) |
| --- | --- | --- |
| ![مخطط شريطي أفقي بترتيب طبيعي للفئة والمحور القيمي](axis-order-normal.png) | ![مخطط شريطي أفقي مع عرض الفئات من الأعلى إلى الأسفل](axis-order-categories-reversed.png) | ![مخطط شريطي أفقي بمحور قيمة مقلوب وصفر على اليمين](axis-order-values-reversed.png) |
| الفئات تمتد من الأسفل إلى الأعلى؛ القيم تزداد من اليسار إلى اليمين. | التخطيط، التطوير، والاختبار تمتد من الأعلى إلى الأسفل. القيم وترتيب صفوف المصنف لم يتغير. | الفئات تحتفظ بترتيبها الطبيعي؛ القيم تزداد من اليمين إلى اليسار. يقاطع محور الفئة عند الصفر على اليمين. |

## **إخفاء المحور الرأسي لمخططات الخطوط**

استدعِ [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) بـ `false` على المحور الرأسي لإخفائه. المثال ينشئ مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور الرأسي.

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

## **إخفاء المحور الأفقي لمخططات الخطوط**

استدعِ [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) بـ `false` على المحور الأفقي لإخفائه. المثال ينشئ مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور الأفقي.

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

## **إظهار أو إخفاء خطوط شبكة المخطط**

استدعِ [getShowMajorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMajorGridLines--) و[getShowMinorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMinorGridLines--) للتحقق من خطوط الشبكة التي يعرضها المحور. تُعيد هذه الطرق حالة الرؤية الحالية. لإظهار خطوط الشبكة الصغرى، استخدم [getMinorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMinorGridLinesFormat--) واضبط تعبئة الخط إلى لون صلب مرئي. لإخفائها، اضبط التعبئة إلى [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/#NoFill). استخدم [getMajorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMajorGridLinesFormat--) لتغيير تعبئة الخط لخطوط الشبكة الكبيرة بنفس الطريقة. يضمن تغيير التعبئة بقاء المحور مرئيًا وعلامات الفواصل.

المحور الرأسي لهذا المخطط العمودي المجمّع يعرض في البداية فقط خطوط الشبكة الكبيرة. المثال يعرض خطوط الشبكة الصغرى بالبرتقالي الداكن، ثم يخفيها مرة أخرى قبل حفظ العرض التقديمي. يطبع حالة رؤية خطوط الشبكة في كل خطوة.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(Color.rgb(255, 140, 0));
    System.out.printf("Enabled: minor=%b%n", axis.getShowMinorGridLines());

    minorFill.setFillType(FillType.NoFill);
    System.out.printf("Hidden: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| تم تمكين خطوط الشبكة الصغرى | تم إخفاء خطوط الشبكة الصغرى |
| --- | --- |
| ![خطوط شبكة صغرى برتقالية بين خطوط الشبكة الكبيرة على المحور الرأسي](minor-gridlines-enabled.png) | ![نفس المخطط العمودي مع إظهار خطوط الشبكة الكبيرة فقط](minor-gridlines-hidden.png) |

## **تغيير محور الفئة**

استخدم [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) لاختيار محور فئة تاريخية أو نصية. يتطلب هذا المثال ملف `ExistingChart.pptx`، حيث يكون المخطط هو الشكل الأول في الشريحة الأولى وتحتوي خلايا الفئة على قيم تاريخ Excel رقمية. يغيّر المحور الأفقي إلى محور تاريخ. استدعِ [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) بـ `false`، و[setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) بـ `1`، و[setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) بـ `TimeUnitType.Months` لتعيين الفواصل الكبيرة على فواصل شهرية.

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

استدعِ [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--) بعد تعبئة الفئات، ثم اقرأ [getCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getCategoryAxisType--) لفحص الاختيار. هذا مفيد عندما يتلقى المخطط إما تسميات نصية أو قيم تاريخ رقمية. تُحدِّد الطريقة النوع عند الاستدعاء؛ ولا تُفعِّل وضعًا مستمرًا يعيد التقييم عندما تتغير البيانات لاحقًا. استدعِها مرة أخرى بعد استبدال الفئات.

المثال التالي ينشئ مخططًا بفئات نصية ويطبع `true` عندما يكون النوع المختار هو `CategoryAxisType.Text`. ثم يستبدل قيم خلايا الفئة بالتواريخ ويستدعي الطريقة مرة أخرى، مطبعًا `true` عندما يكون النوع المختار هو `CategoryAxisType.Date`. تُحفظ التواريخ كقيم OLE Automation رقمية، تُحسب كعدد أيام منذ 30 ديسمبر 1899، وليس كسلاسل تاريخية. يستخدم كلا التقويمين توقيت UTC ويتم مسحهما قبل ضبط التواريخ لتجنب تأثير التوقيت الصيفي أو الوقت الحالي من اليوم. يتحكم [setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) في كيفية عرض تلك القيم؛ ولا يُحوِّل النص إلى تواريخ رقمية. لمزيد من المعلومات حول خلايا الفئة، راجع [Chart Workbook](/slides/ar/androidjava/chart-workbook/).

استخدم التحديد التلقائي عندما تكون المدخلات معروفة بأنها تحتوي على فئات نصية أو تواريخ رقمية، كما في هذا المثال. بالنسبة للتسميات الرقمية العادية أو الفئات المختلطة أو البيانات الفارغة، استدعِ [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisType-int-) صراحةً لتطابق المعنى المقصود. القيم الرقمية وحدها لا تُثبت أن الفئات تمثل تواريخ.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

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

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);
    int[][] dates = { { 2026, Calendar.JANUARY, 1 }, { 2026, Calendar.JANUARY, 2 }, { 2026, Calendar.FEBRUARY, 1 } };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(dates[i][0], dates[i][1], dates[i][2]);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        categoryCell.setValue(serialDate);
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

عند وجود عدد كبير من الفئات في المخطط، قلل عدد تسميات المحور الظاهرة دون حذف الفئات أو نقاط البيانات. استدعِ [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) بـ `false`، ثم مرّر الفاصل المطلوب إلى [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). بالنسبة للفئات النصية بترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات المعروضة في المثال |
| --- | --- |
| `1` | الفئة 1، الفئة 2، الفئة 3، … الفئة 24 |
| `2` | الفئة 1، الفئة 3، الفئة 5، … الفئة 23 |
| `3` | الفئة 1، الفئة 4، الفئة 7، … الفئة 22 |

فاصل `3` يعرض كل تسمية ثالثة، ويخفي اثنتين بين كل تسميتين ظاهرتين. لا يزيل الأعمدة المقابلة. يختار الفاصل التلقائي بناءً على المساحة المتوفرة؛ ولا يعرض بالضرورة كل تسمية.

لعلامات الفواصل تحكم منفصل. استدعِ [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) بـ `false` واستخدم [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) لتعيين فاصلها. على سبيل المثال، `1` يبقي علامة فاصل عند كل فاصل فئة بينما تظهر التسميات كل فاصل ثالث. استخدم [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) بنمط مرئي لتتمكن من رؤية النتيجة. استدعاء أي من محددات الفاصل التلقائي بـ `true` مرة أخرى يسمح للمخطط باختيار الفاصل مجددًا.

المثال المستقل التالي ينشئ 24 فئة وسلسلة واحدة، ثم يحفظ ثلاث شرائح في `CategoryAxisIntervals.pptx`: الفاصل التلقائي، الفاصل اليدوي مع علامات فواصل مستقلة، واستعادة الفاصل التلقائي. تحتفظ النسختان بالبيانات الأصلية للمخطط. لا يلزم عرض تقديمي مدخل. يجعل نص التسميات الأفقي الفرق في الكثافة واضحًا.

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

    // الشريحة 2: إظهار كل تسمية ثالثة، مع الحفاظ على علامة فاصل لكل فئة.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // الشريحة 3: السماح للمخطط باختيار كلا الفاصلين مرة أخرى.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**الفاصل التلقائي (الشريحة 1):** في هذا العرض، تُعرض كل تسمية فئة ثانية وتلتف على سطرين. قد يختلف الناتج التلقائي حسب حجم المخطط، الخطوط، ومكوّن العرض.

![تباعد تسميات الفئة التلقائي مع رؤية جميع 24 عمودًا](category-axis-automatic.png)

**الفاصل اليدوي (الشريحة 2):** تُعرض كل تسمية ثالثة على سطر واحد، بينما تُبقى علامات الفواصل عند كل فاصل فئة. جميع الـ 24 عمودًا، بما فيها غير المعروضة، تظل مرئية بنفس القيم. الشريحة 3 تستعيد المظهر التلقائي الموضح أعلاه.

![تباعد تسميات الفئة اليدوي بثلاث فواصل مع رؤية جميع 24 عمودًا](category-axis-manual.png)

### **اختر المحور والفاصل الصحيح**

استخدم هذا الفاصل بحسب عدد الفئات لمحور فئة نصية، مثل محور الفئة في مخطط عمودي، خطي، مساحاتي أو شريطي. في المخطط العمودي، يكون هو المحور الأفقي. في المخطط الشريطي الأفقي، يكون محور الفئة عموديًا، لذا طبّق هذه الإعدادات على المحور المرجوع من [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). ينطبق تباعد علامات الفواصل أيضًا على محور السلسلة في المخططات التي تحتوي على واحد.

لا تستخدم تباعد تسميات الفئة لضبط المقياس الرقمي لمحور القيمة. على محور القيمة، يحدد [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) فرق القيم: على سبيل المثال، وحدة رئيسية `10` تنتج علامات عند 0، 10، 20، وهكذا عندما يبدأ المحور من الصفر. فاصل تسمية الفئة `3` يحسب موضع الفئة بغض النظر عن قيم البيانات. تستخدم مخططات التبعثر والفقاعات محاور قيمة بدلًا من محور فئة نصية. لمحور التاريخ، استخدم وحدات زمنية ومقاييس كما هو موضح في [تغيير محور الفئة](#change-a-category-axis).

## **تحديد تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال البيانات الافتراضية للمخطط بأربعة قيم سنوية. تُحفظ التواريخ كأرقام تسلسلية OLE Automation في ورقة العمل الأولى (الفهرس `0`)، محسوبة كعدد أيام منذ 30 ديسمبر 1899. يستخدم كلا التقويمين توقيت UTC ويتم مسحهما قبل ضبط التواريخ لتجنب تأثير التوقيت الصيفي أو الوقت الحالي من اليوم. استخدم [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) بـ `CategoryAxisType.Date`، واستدعِ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) بـ `false`، ومرّر `yyyy` إلى [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) حتى تُظهر تسميات الفئة السنوات بأربعة أرقام مستقلة عن تنسيق الخلية.

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

## **تعيين زاوية تدوير عنوان محور المخطط**

استدعِ [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) بـ `true` على المحور الرأسي، وزد نص العنوان، واستخدم [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) لتدوير العنوان. الزاوية تُقاس بالدرجات؛ يحفظ هذا المثال مخططًا عموديًا مع عنوان محور القيمة مدوَّرًا بزاوية 90 درجة.

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

## **تحديد موضع المحور على محور الفئة أو القيمة**

استخدم [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) للتحكم فيما إذا كان محور القيمة يعبر محور الفئة بين الفئات أو عند علامات الفئة. يُطبق هذا الإعداد على محاور الفئة. يضبط المثال هذه الخاصية على `true` في محور الفئة الأفقي لمخطط عمودي، ويحفظ النتيجة.

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

استخدم [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) لتكبير أو تصغير تسميات محور القيمة دون تغيير البيانات الأساسية. عند ضبط [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) إلى `Millions`، يُعرض الرقم 60 000 000 كـ 60. يُنشئ المثال مخططًا عموديًا ويطبق وحدة العرض بالملايين على محوره الرأسي.

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

محور قيمة لوغاريتمي مفيد عندما تتراوح القيم الموجبة عبر عدة أوامر من الحجم. على سبيل المثال، قد يتلقى خدمة 10، 100، 1 000، 10 000، و100 000 طلبًا خلال خمس فترات. على مقياس خطي، تظهر القيم الصغيرة متقاربة بالقرب من الصفر. يُسهل المقياس اللوغاريتمي مقارنة نموها النسبي: المسافات المتساوية تمثل نسبًا متساوية بدلًا من فروق مقدارية متساوية.

استدعِ [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) بـ `true` على محور القيمة، واستخدم [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) لاختيار القاعدة. يغيّر هذا طريقة عرض القيم الحالية؛ ولا يُغيّر البيانات ولا يضيف خط اتجاه لوغاريتمي. خط الاتجاه يمثل علاقة مُناسبة في البيانات وهو خاصية منفصلة.

### **اختر محور القيمة والقاعدة**

بالنسبة لمخطط خطي أو عمودي، يُسترجع محور القيمة من [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). بالنسبة لمخطط شريطي أفقي، يُسترجع من [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). تمتلك مخططات التبعثر والفقاعات محورين للقيمة، لذا اختر المحور الأفقي لقيم X، والمحور الرأسي لقيم Y، أو كلاهما. لا تُطبق القياس اللوغاريتمي على محور الفئة.

القاعدة اللوغاريتمية الافتراضية هي `10`. للمخططات PPTX، يمكن استخدام قاعدة من `2` إلى `1000` شاملًا؛ وتُدعم القواعد الكسريّة مثل `2.5`. مع القاعدة `10`، تكون القوى المتتالية مثل 10، 100، 1 000، و10 000 متساوية التباعد.

### **مقارنة القياس الخطي واللوغاريتمي**

المثال المستقل التالي ينشئ مخططًا خطيًا مع عدد الطلبات الخمسة في الشريحة الأولى، ثم ينسخ تلك الشريحة ويفعّل محور قيمة لوغاريتمي بقاعدة 10 في الشريحة الثانية. تحتفظ كلتا الشريحتين بنفس البيانات.

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

    // احتفظ بالشريحة الأولى خطية وغير فقط مقياس محور القيمة للنسخة.
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

**القياس الخطي (الشريحة 1):** تمثّل المسافات العمودية المتساوية فروقًا متساوية في عدد الطلبات. يهيمن أكبر قيمة على المخطط، مما يصعّب تمييز القيم الأصغر.

![مخطط خطي في PowerPoint يُظهر خمسة عدد طلبات على محور قيمة خطي](value-axis-linear.png)

**القياس اللوغاريتمي (الشريحة 2):** تمثّل المسافات العمودية المتساوية نسبًا متساوية. كل فترة لديها عشرة أضعاف عدد الطلبات من الفترة السابقة، لذا تشكِّل النقاط خطًا مرتفعًا مستقيمًا على مقياس قاعدة 10. لا تزال تسميات المحور تُظهر أعداد الطلبات الأصلية.

![نفس خمسة عدد طلبات في PowerPoint على محور قيمة لوغاريتمي بقاعدة 10](value-axis-logarithmic.png)

### **معالجة الصفر والقيم السالبة**

يمكن للمقياس اللوغاريتمي عرض قيم موجبة صرفة فقط. تحقق من البيانات قبل تفعيله. إذا كان الصفر أو القيم السالبة ذات معنى، احتفظ بالمقياس الخطي أو اعرضها بصورة منفصلة. إذا كان استبعاد تلك القيم مناسبًا للتحليل، فوضح سبب الاستبعاد. لا تستبدلها صمتًا بأعداد موجبة صغيرة، حيث يغيّر ذلك معنى البيانات. أي حد أدنى أو أقصى يُضبط يدويًا لمحور لوغاريتمي يجب أن يكون إيجابيًا أيضًا.

## **الأسئلة المتكررة**

**كيف يمكنني تعيين القيمة التي يتقاطع عندها محور مع الآخر؟**

استخدم [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) لاختيار سلوك التقاطع. لتحديد قيمة تقاطع رقمية، استخدم [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). تتيح هذه الإعدادات نقل تقاطع المحور إلى خط أساسي مناسب.

**كيف يمكنني وضع تسميات العلامات بالنسبة للمحور؟**

استدعِ [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) باستخدام [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`، `High`، `NextTo`، أو `None`. للتحكم في علامات الفواصل نفسها، استخدم [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) أو [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); هذه إعدادات مستقلة عن موضع التسميات.