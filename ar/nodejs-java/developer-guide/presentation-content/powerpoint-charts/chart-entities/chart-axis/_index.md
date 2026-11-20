---
title: تخصيص محاور المخطط في العروض التقديمية باستخدام جافاسكريبت
linktitle: محور المخطط
type: docs
url: /ar/nodejs-java/chart-axis/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "اكتشف طريقة استخدام جافاسكريبت مع Aspose.Slides لـ Node.js عبر Java لتخصيص محاور المخطط في عروض PowerPoint التقديمية للتقارير والتصوير البصري."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص محاور المخطط باستخدام Aspose.Slides لـ Node.js عبر Java. يغطي المقال القيم المحسوبة للمحور، تبديل صفوف وأعمدة المخطط، رؤية المحور، فواصل تسميات الفئات وعلامات الفواصل، الفئات التاريخية وتنسيقها، دوران العنوان، موضع المحور، وحدات العرض، والتدرج اللوغاريتمي.

## **الحصول على القيم القصوى على المحور العمودي في المخططات**

إنشاء [العرض التقديمي](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) وإضافة مخطط منطقة بالبيانات الافتراضية. استدعِ [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) قبل قراءة القيم المحسوبة للمحور لضمان تحديث تخطيط المخطط.

اقرأ [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) و[ getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) للحصول على حدود المحور، و[getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) و[getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) لفواصل العلامات. توفر [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) و[getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) مقاييس الوحدات الزمنية، وهي ذات صلة بمحاور التاريخ. يخزن المثال هذه القيم في متغيرات محلية ويحفظ المخطط.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تبديل البيانات بين المحاور**

استخدم [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) لتبادل أدوار السلاسل والفئات في بيانات المخطط. كل فئة سابقة تصبح سلسلة، وكل سلسلة سابقة تصبح فئة. هذا يغيّر طريقة تجميع البيانات؛ ولكنه لا يبدّل المحاور الأفقية والعمودية. يستخدم المثال [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) لربط البيانات الافتراضية بـ `Sheet1!A1:D5`، بما في ذلك صف الرأس وعمود الفئة، قبل تبديل الصفوف والأعمدة. يحفظ المخطط مع أربع سلاسل وثلاث فئات.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **عكس ترتيب رسم المحور**

استخدم [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) لعكس محور فئة أو قيمة. على سبيل المثال، يمكن لمخطط شريط أفقي أن يعرض مراحل المشروع من الأعلى إلى الأسفل بنفس ترتيب ورقة العمل: التخطيط، التطوير، الاختبار. عكس المحور يغيّر اتجاه الرسم؛ لا يقوم بفرز أو إعادة ترتيب بيانات ورقة العمل. بالمقارنة، [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) يبدّل أدوار السلاسل والفئات.

المثال التالي ينشئ مخطط شريط أفقي بثلاث مراحل وسلسلة واحدة. يحفظ عرض تقديمي بثلاث شرائح: الترتيب الطبيعي، الفئات المقلوبة، والقيم المقلوبة. كل نسخة تستخدم نفس مجموعة البيانات، ويتم عكس محور واحد فقط في كل نسخة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredBar);
    var stages = ["Planning", "Development", "Testing"];
    var values = [10, 30, 20];
    for (var i = 0; i < stages.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // الشريحة 2: عرض الفئة الأولى في الأعلى.
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // احفظ محور القيمة الأفقي في الأسفل.
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // الشريحة 3: عكس مقياس الأعداد الأفقي فقط.
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يمكن لعكس المحور أيضًا نقل المحور العمودي إلى الجانب المقابل من المخطط. يتحكم [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) في مكان تقاطع المحور الآخر مع المحور الجاري تكوينه. في الشريحة 2، يتم استدعاؤه بـ `aspose.slides.CrossesType.Maximum` على محور الفئة المقلوب لإبقاء محور القيمة الأفقي في الأسفل. لنقطة تقاطع محددة، استخدم [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). تحقق من إعدادات التقاطع عند تغيير الاتجاه، خاصة إذا كان المخطط يحتوي بالفعل على نقطة تقاطع مخصصة. استدعِ `setPlotOrderReversed` بـ `false` لاستعادة اتجاه الرسم الطبيعي؛ إعدادات التقاطع مستقلة.

| الترتيب العادي (الشريحة 1) | الفئات المقلوبة (الشريحة 2) | القيم المقلوبة (الشريحة 3) |
| --- | --- | --- |
| ![مخطط شريط أفقي بترتيب الفئة والمحور القيمي العادي](axis-order-normal.png) | ![مخطط شريط أفقي مع عرض الفئات من الأعلى إلى الأسفل](axis-order-categories-reversed.png) | ![مخطط شريط أفقي بمحور قيم مقلوب والصفر على اليمين](axis-order-values-reversed.png) |
| الفئات تمتد من الأسفل إلى الأعلى؛ القيم تزداد من اليسار إلى اليمين. | التخطيط، التطوير، والاختبار تمتد من الأعلى إلى الأسفل. القيم وترتيب صفوف ورقة العمل لم يتغير. | الفئات تحتفظ بترتيبها الطبيعي؛ القيم تزداد من اليمين إلى اليسار. يتقاطع محور الفئة عند الصفر على اليمين. |

## **تعطيل المحور العمودي لمخططات الخط**

استدعِ [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) بـ `false` على المحور العمودي لإخفائه. ينشئ المثال مخطط خط بالبيانات الافتراضية ويحفظه مع إخفاء المحور العمودي.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعطيل المحور الأفقي لمخططات الخط**

استدعِ [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) بـ `false` على المحور الأفقي لإخفائه. ينشئ المثال مخطط خط بالبيانات الافتراضية ويحفظه مع إخفاء المحور الأفقي.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إظهار أو إخفاء خطوط الشبكة في المخطط**

استدعِ [getShowMajorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowmajorgridlines/) و[getShowMinorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowminorgridlines/) للتحقق من أي خطوط شبكة يعرضها المحور. لإظهار خطوط الشبكة الفرعية، استخدم [getMinorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getminorgridlinesformat/) واضبط تعبئة الخط إلى لون صلب مرئي. لإخفائها، اضبط التعبئة إلى [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/). استخدم [getMajorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getmajorgridlinesformat/) لتغيير تعبئة الخط لخطوط الشبكة الرئيسية بنفس الطريقة. تغيير التعبئة يحافظ على رؤية المحور وعلامات الفواصل.

المحور العمودي لهذا المخطط العمودي المتجمع يعرض في البداية خطوط الشبكة الرئيسية فقط. يعرض المثال خطوط الشبكة الفرعية بالبرتقالي الداكن، ثم يخفيها مرة أخرى قبل حفظ العرض التقديمي. يطبع رؤية خطوط الشبكة في كل خطوة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 30, 660, 230);
    var axis = chart.getAxes().getVerticalAxis();
    console.log("Initial: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    var minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    var darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    minorFill.getSolidFillColor().setColor(darkOrange);
    console.log("Enabled: minor=%s", axis.getShowMinorGridLines());

    minorFill.setFillType(java.newByte(aspose.slides.FillType.NoFill));
    console.log("Hidden: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| خطوط الشبكة الفرعية مفعلة | خطوط الشبكة الفرعية مخفية |
| --- | --- |
| ![خطوط شبكة فرعية برتقالية بين خطوط الشبكة الرئيسية على المحور العمودي](minor-gridlines-enabled.png) | ![نفس مخطط العمود مع إظهار خطوط الشبكة الرئيسية فقط](minor-gridlines-hidden.png) |

## **تغيير محور الفئة**

استخدم [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) لاختيار محور فئة تاريخي أو نصي. يتطلب هذا المثال ملف `ExistingChart.pptx`، حيث يكون المخطط هو الشكل الأول في الشريحة الأولى وتحتوي خلايا الفئة على قيم تاريخية رقمية من Excel. يغيّر المحور الأفقي إلى محور تاريخ. استدعِ [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) بـ `false`، ثم [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) بـ `1`، و[setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) بـ `TimeUnitType.Months` لتحديد الفواصل الرئيسية بفواصل شهرية.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تحديد نوع محور الفئة من البيانات**

استدعِ [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistypeautomatically/) بعد تعبئة الفئات، ثم اقرأ [getCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getcategoryaxistype/) لفحص الاختيار. هذا مفيد عندما يتلقى نفس المخطط إما تسميات نصية أو قيم تاريخية رقمية. تحدد الطريقة النوع عند الاستدعاء؛ ولا تُفعّل وضعًا مستمرًا يعيد التقييم عند تغيّر البيانات لاحقًا. استدعِها مرة أخرى بعد استبدال الفئات.

المثال التالي ينشئ مخططًا بفئات نصية ويطبع `true` عندما يكون النوع المختار هو `CategoryAxisType.Text`. ثم يستبدل قيم خلايا الفئة بالتواريخ ويستدعي الطريقة مرة أخرى، مطبعًا `true` عندما يكون النوع المختار هو `CategoryAxisType.Date`. تُخزن التواريخ كقيم رقمية من نوع OLE Automation، محسوبة كعدد الأيام منذ 30 ديسمبر 1899، بدلاً من سلاسل تاريخية. يستخدم حساب JavaScript طوابع زمنية UTC ويقسم الفرق على 86 400 000 مللي ثانية لكل يوم؛ مؤشرات الشهور تبدأ من الصفر. استخدم `java.newDouble` لتمرير كل قيمة تاريخ إلى Java كعدد مزدوج. يتحكم [setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) في كيفية عرض تلك القيم؛ ولا يحول النص إلى تواريخ رقمية. لمزيد من المعلومات عن خلايا الفئة، راجع [Chart Workbook](/slides/ar/nodejs-java/chart-workbook/).

استخدم التحديد التلقائي عندما يكون الإدخال معروفًا بأنه يحتوي على فئات نصية أو تواريخ رقمية، كما في هذا المثال. بالنسبة للتسميات الرقمية العادية، الفئات المختلطة، أو البيانات الفارغة، استدعِ صراحةً [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) لمطابقة المعنى المقصود. القيم الرقمية وحدها لا تُثبت أن الفئات تمثل تواريخ.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var seriesName = workbook.getCell(0, 0, 1, "Sales");
    var series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    var labels = ["First", "Second", "Third"];

    for (var i = 0; i < labels.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Text); // true

    var baseDate = Date.UTC(1899, 11, 30);
    var dates = [Date.UTC(2026, 0, 1), Date.UTC(2026, 0, 2), Date.UTC(2026, 1, 1)];

    for (var i = 0; i < dates.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0);
        var dateValue = java.newDouble((dates[i] - baseDate) / 86400000);
        categoryCell.setValue(dateValue);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Date); // true

    presentation.save("AutomaticCategoryAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **التحكم في فواصل تسميات محور الفئة**

عند وجود عدد كبير من الفئات في المخطط، قلل عدد تسميات المحور الظاهرة دون إزالة الفئات أو نقاط البيانات. استدعِ [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) بـ `false`، ثم مرّر الفاصل الزمني المطلوب للفئة إلى [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). بالنسبة للفئات النصية في ترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات المعروضة في المثال |
| --- | --- |
| `1` | الفئة 1, الفئة 2, الفئة 3, ... الفئة 24 |
| `2` | الفئة 1, الفئة 3, الفئة 5, ... الفئة 23 |
| `3` | الفئة 1, الفئة 4, الفئة 7, ... الفئة 22 |

الفاصل `3` يعرض كل تسمية ثالثة، ويترك اثنتين مخفيتين بين التسميات المعروضة. لا يزيل الأعمدة المقابلة. يختار التباعد التلقائي الفاصل بناءً على المساحة المتاحة؛ ولا يعرض بالضرورة كل تسمية.

لعلامات الفواصل تحكم منفصل. استدعِ [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) بـ `false` واستخدم [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) لتحديد فواصلها. على سبيل المثال، `1` يبقي علامة فاصل عند كل فاصل فئة بينما تظهر التسميات كل فئة ثالثة فقط. استدعِ [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) بنمط مرئي لترى النتيجة. استدعاء أي من محددات التباعد التلقائي بـ `true` مرة أخرى يسمح للمخطط باختيار الفاصل مرة أخرى.

المثال التالي المستقل يُنشئ 24 فئة وسلسلة واحدة، ثم يحفظ ثلاث شرائح في `CategoryAxisIntervals.pptx`: تباعد تلقائي، تباعد يدوي مع علامات فواصل مستقلة، واستعادة التباعد التلقائي. النسختان تحتفظان ببيانات المخطط الأصلية. لا يلزم عرض تقديمي مُدخل. يجعل النص الأفقي للملصق الفرق في الكثافة واضحًا.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // الشريحة 2: إظهار كل تسمية ثالثة، مع الإبقاء على علامة فاصل لكل فئة.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // الشريحة 3: السماح للمخطط باختيار كلا الفاصلين مرة أخرى.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**التباعد التلقائي (الشريحة 1):** في هذا العرض، تُعرض كل تسمية فئة ثانية وتُلف إلى سطرين. قد يختلف الناتج التلقائي حسب حجم المخطط، الخطوط، وموضع الرسم.

![تباعد تسميات الفئات التلقائي مع ظهور جميع الأعمدة الـ 24](category-axis-automatic.png)

**التباعد اليدوي (الشريحة 2):** تُعرض كل تسمية ثالثة على سطر واحد، بينما تظل علامات الفواصل عند كل فاصل فئة. تظل جميع الأعمدة الـ 24، بما فيها غير المعروضة، مرئية بنفس القيم. تستعيد الشريحة 3 المظهر التلقائي الموضح أعلاه.

![فاصل تسميات الفئة اليدوي ثلاثة مع ظهور جميع الأعمدة الـ 24](category-axis-manual.png)

### **اختر المحور والفاصل الزمني الصحيح**

استخدم هذا الفاصل الزمني لعدد الفئات لمحور فئة نصية، مثل محور فئة عمود، خط، منطقة، أو شريط. في مخطط العمود، هو المحور الأفقي. في مخطط شريط أفقي، يكون محور الفئة عموديًا، لذا يُطبق هذا الإعداد على المحور المرتجع من [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). ينطبق تباعد علامات الفواصل أيضًا على محور سلسلة في المخططات التي تحتوي على أحدهما.

لا تستخدم تباعد تسميات الفئة لضبط مقياس محور القيمة. على محور القيمة، يحدد [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) فرق القيم: على سبيل المثال، وحدة رئيسية بـ `10` تُنتج علامات عند 0، 10، 20، وهكذا عندما يبدأ المحور من الصفر. فاصل تسمية الفئة بـ `3` يعد مواضع الفئات، بغض النظر عن قيم بياناتها. تستخدم المخططات النقطية والفقاعية محاور قيم بدلاً من محور فئة نصية. بالنسبة لمحور التاريخ، استخدم الوحدات الزمنية الرئيسية والمقاييس كما هو موضح في [تغيير محور الفئة](#change-a-category-axis).

## **ضبط تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال بيانات المخطط الافتراضية بأربع قيم سنوية. تُخزن التواريخ كأرقام تسلسلية OLE Automation في ورقة العمل الأولى (الفهرس `0`)، محسوبة كعدد الأيام منذ 30 ديسمبر 1899 لهذه التواريخ. يستخدم حساب JavaScript طوابع زمنية UTC ويقسم الفرق على 86 400 000 مللي ثانية لكل يوم. استخدم [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) بـ `CategoryAxisType.Date`، استدعِ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) بـ `false`، ومرّر `yyyy` إلى [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) لتظهر تسميات الفئة السنوات ذات الأربع أرقام بغض النظر عن تنسيق الخلية.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ضبط زاوية الدوران لعنوان محور المخطط**

استدعِ [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) بـ `true` على المحور العمودي، قدم نص العنوان، واستخدم [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) لتدوير العنوان. تُقاس الزاوية بالدرجات؛ يحفظ هذا المثال مخطط عمود بعنوان محور القيمة مدورًا بزاوية 90 درجة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ضبط موضع المحور على محور الفئة أو القيم**

استخدم [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) للتحكم فيما إذا كان محور القيم يتقاطع مع محور الفئة بين الفئات أو عند علامات الفئة. ينطبق هذا الإعداد على محاور الفئة. يضبط المثال هذه الخاصية على `true` في محور الفئة الأفقي لمخطط عمود ويحفظ النتيجة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ضبط وحدة العرض على محور القيم في المخطط**

استخدم [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) لتكبير أو تصغير التسميات على محور القيم دون تغيير البيانات الأساسية. مع [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) مضبوطًا على `Millions`، تُعرض القيمة 60 000 000 كـ 60. ينشئ المثال مخطط عمود ويطبق وحدة العرض بالملايين على محوره العمودي.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ضبط محور القيم اللوغاريتمي**

محور القيم اللوغاريتمي مفيد عندما تمتد القيم الموجبة على عدة أوامر من الحجم. على سبيل المثال، قد يتلقى خدمة 10، 100، 1 000، 10 000، و100 000 طلبًا خلال خمس فترات. على مقياس خطي، تظهر القيم الصغيرة متقاربة بالقرب من الصفر. يجعل المقياس اللوغاريتمي نموها النسبي أسهل للمقارنة: المسافات المتساوية تمثل نسبًا متساوية بدلاً من اختلافات متساوية.

استدعِ [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) بـ `true` على محور القيمة واستخدم [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) لاختيار القاعدة. هذا يغيّر طريقة عرض القيم الحالية؛ لا يغيّر البيانات أو يضيف خط اتجاه لوغاريتمي. خط الاتجاه يمثل علاقة مُناسبة في البيانات وهو ميزة مستقلة.

### **اختر محور القيمة والقاعدة**

بالنسبة لمخطط خط أو عمود، يُسترجع محور القيمة عبر [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). في مخطط شريط أفقي، يُسترجع عبر [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). تحتوي المخططات النقطية والفقاعية على محوري قيمة، لذا اختر المحور الأفقي لقيم X، والمحور العمودي لقيم Y، أو كليهما. لا تُطبق التدرج اللوغاريتمي على محور فئة.

القاعدة اللوغاريثمية الافتراضية هي `10`. بالنسبة لمخططات PPTX، استخدم قاعدة من `2` إلى `1000` شاملة؛ تدعم القواعد الكسرية مثل `2.5`. مع القاعدة `10`، تكون القوى المتتالية مثل 10، 100، 1 000، و10 000 متساوية التباعد.

### **قارن بين التدرج الخطي واللوغاريتمي**

المثال التالي المستقل يُنشئ مخطط خط مع خمس عدد طلبات في الشريحة الأولى، ثم ينسخ تلك الشريحة ويُمكّن محور قيمة لوغاريتمي بقاعدة 10 في الشريحة الثانية. تحتفظ كلتا الشريحتين بنفس البيانات.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // احتفظ بالشريحة الأولى خطية وغيّر مقياس محور القيمة في النسخة فقط.
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**المقياس الخطي (الشريحة 1):** تمثل المسافات العمودية المتساوية فروقًا متساوية في عدد الطلبات. تُهيمن القيمة الأكبر على المخطط، مما يصعب تمييز القيم الأصغر.

![مخطط خط في PowerPoint يظهر خمس عدد طلبات على محور قيم خطي](value-axis-linear.png)

**المقياس اللوغاريتمي (الشريحة 2):** تمثل المسافات العمودية المتساوية نسبًا متساوية. كل فترة تحتوي على عشر مرات طلبات الفترة السابقة، لذا تُشكل النقاط خطًا مرتفعًا مستقيمًا على مقياس القاعدة 10. لا تزال تسميات المحور تُظهر عدد الطلبات الأصلي.

![نفس خمس عدد طلبات في PowerPoint على محور قيم لوغاريتمي بالقاعدة 10](value-axis-logarithmic.png)

### **معالجة القيم الصفرية والسالبة**

يمكن للمقياس اللوغاريتمي عرض قيم موجبة فقط. تحقق من البيانات قبل تمكينه. إذا كانت القيم الصفرية أو السالبة ذات معنى، احتفظ بمقياس خطي أو أظهرها بشكل منفصل. إذا كان استبعاد تلك القيم مناسبًا للتحليل، فسّس السبب. لا تستبدلها صمتًا بأرقام موجبة صغيرة، لأن ذلك يُغيّر معنى البيانات. يجب أن تكون أي قيمة حد أدنى أو أقصى مُعَّدة يدويًا لمحور لوغاريتمي أيضًا موجبة.

## **الأسئلة المتداولة**

**كيف أضبط القيمة التي يتقاطع عندها أحد المحاور مع الآخر (تقاطع المحور)؟**

استخدم [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) لاختيار سلوك التقاطع. لتحديد قيمة تقاطع رقمية، استخدم [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). تتيح لك هذه الإعدادات نقل تقاطع المحور إلى خط أساس مناسب.

**كيف يمكنني وضع تسميات العلامات بالنسبة إلى المحور؟**

استدعِ [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) مستخدمًا [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`، `High`، `NextTo`، أو `None`. للتحكم في علامات الفواصل نفسها، استخدم [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) أو [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); فهي منفصلة عن موضع التسميات.