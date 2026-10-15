---
title: تخصيص محاور المخطط في العروض التقديمية باستخدام JavaScript
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
- القيمة العظمى
- القيمة الصغرى
- خط المحور
- تنسيق التاريخ
- عنوان المحور
- موضع المحور
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "اكتشف كيفية استخدام JavaScript مع Aspose.Slides لـ Node.js عبر Java لتخصيص محاور المخطط في عروض PowerPoint التقديمية للتقارير والتصورات."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تخصيص محاور المخططات باستخدام Aspose.Slides لـ Node.js عبر Java. تغطي القيم المحسوبة للمحور، تبديل صفوف وأعمدة المخطط، إظهار المحور، فواصل تسميات الفئات وعلامات التحديد، فئات التاريخ وتنسيقها، تدوير العنوان، وضع المحور، وحدات العرض، والقياس اللوغاريتمي.

## **الحصول على القيم القصوى على المحور العمودي في المخططات**

أنشئ [العرض التقديمي](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) وأضف مخطط مساحة بالبيانات الافتراضية. استدعِ [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) قبل قراءة القيم المحسوبة للمحور لضمان أن تخطيط المخطط محدث.

اقرأ [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) و [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) للحصول على حدود المحور، و [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) و [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) لفواصل العلامات. توفر [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) و [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) مقاييس الوحدات الزمنية، والتي تكون ذات صلة بمحاور التاريخ. يخزن المثال هذه القيم في متغيرات محلية ويحفظ المخطط.

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

استخدم [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) لتبادل أدوار السلاسل والفئات في بيانات المخطط. كل فئة سابقة تصبح سلسلة، وكل سلسلة سابقة تصبح فئة. هذا يغيّر طريقة تجميع البيانات؛ لا يبدّل المحاور الأفقية والرأسية. يستخدم المثال [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) لربط البيانات الافتراضية بـ `Sheet1!A1:D5`، بما في ذلك صف الرأس وعمود الفئة، قبل تبديل الصفوف والأعمدة. يحفظ مخططًا بأربع سلاسل وثلاث فئات.

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

## **عكس ترتيب رسم محور**

استخدم [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) لعكس محور فئة أو قيم. على سبيل المثال، يمكن لمخطط شريطي أفقي إظهار مراحل المشروع من الأعلى إلى الأسفل بالترتيب نفسه الموجود في ورقة العمل: التخطيط، التطوير، الاختبار. عكس المحور يغيّر اتجاه الرسم؛ لا يرتّب أو يعيد ترتيب بيانات المصنف. بالمقابل، [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) يبدّل أدوار السلاسل والفئات.

المثال التالي ينشئ مخطط شريطي أفقي بثلاث مراحل وسلسلة واحدة. يحفظ عرضًا تقديميًا بثلاث شرائح: الترتيب الطبيعي، فئات معكوسة، وقيم معكوسة. كل نسخة تستخدم مجموعة البيانات نفسها، ويُعكس محور واحد فقط في كل نسخة.

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
    // إبقاء محور القيم الأفقي في الأسفل.
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

يمكن لعكس المحور أيضًا نقل المحور المتعامد إلى الجانب المقابل من الرسم. يتحكم [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) بمكان تقاطع المحور الآخر مع المحور الجاري تهيئته. في الشريحة 2، استدعاؤه بـ `aspose.slides.CrossesType.Maximum` على محور الفئة المعكوس يبقي محور القيم الأفقي في الأسفل. لنقطة تقاطع محددة، استخدم [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). تحقق من إعدادات التقاطع عند تغيير الاتجاه، خاصة إذا كان المخطط يحتوي بالفعل على نقطة تقاطع مخصّصة. استدعِ `setPlotOrderReversed` بـ `false` لاستعادة اتجاه الرسم الطبيعي؛ إعدادات التقاطع مستقلة.

| الترتيب الطبيعي (الشريحة 1) | فئات معكوسة (الشريحة 2) | قيم معكوسة (الشريحة 3) |
| --- | --- | --- |
| ![مخطط شريطي أفقي بترتيب الفئة والمحور القيمي العادي](axis-order-normal.png) | ![مخطط شريطي أفقي مع عرض الفئات من الأعلى إلى الأسفل](axis-order-categories-reversed.png) | ![مخطط شريطي أفقي بمحور قيم معكوس وصفر على اليمين](axis-order-values-reversed.png) |
| تتراوح الفئات من الأسفل إلى الأعلى؛ القيم تزداد من اليسار إلى اليمين. | التخطيط، التطوير، والاختبار تتراوح من الأعلى إلى الأسفل. القيم وترتيب صفوف المصنف لا يتغير. | تحافظ الفئات على ترتيبها الطبيعي؛ القيم تزداد من اليمين إلى اليسار. يتقاطع محور الفئة عند الصفر على اليمين. |

## **تعطيل المحور العمودي للمخططات الخطية**

استدعِ [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) مع `false` على المحور العمودي لإخفائه. ينشئ المثال مخططًا خطيًا بالبيانات الافتراضية ويحفظه مع إخفاء المحور العمودي.

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

## **تعطيل المحور الأفقي للمخططات الخطية**

استدعِ [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) مع `false` على المحور الأفقي لإخفائه. ينشئ المثال مخططًا خطيًا بالبيانات الافتراضية ويحفظه مع إخفاء المحور الأفقي.

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

## **تغيير محور الفئة**

استخدم [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) لاختيار محور فئة تاريخ أو نص. يتطلب هذا المثال ملف `ExistingChart.pptx`، حيث يكون المخطط هو الشكل الأول في الشريحة الأولى وتحتوي خلايا الفئة على قيم تاريخ Excel رقمية. يغيّر المحور الأفقي إلى محور تاريخ. استدعِ [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) بـ `false`، ثم [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) بـ `1`، و[setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) بـ `TimeUnitType.Months` لتحديد علامات رئيسية بفاصل شهر واحد.

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

## **التحكم في فواصل تسميات محور الفئة**

عند وجود عدد كبير من الفئات في المخطط، قلل عدد التسميات الظاهرة للمحور دون حذف الفئات أو نقاط البيانات. استدعِ [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) بـ `false`، ثم مرّر الفاصل الفئوي المطلوب إلى [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). بالنسبة للفئات النصية بترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات المعروضة في المثال |
| --- | --- |
| `1` | الفئة 1, الفئة 2, الفئة 3, ... الفئة 24 |
| `2` | الفئة 1, الفئة 3, الفئة 5, ... الفئة 23 |
| `3` | الفئة 1, الفئة 4, الفئة 7, ... الفئة 22 |

فاصل `3` يعرض كل تسمية ثالثة، ويخفي اثنتين بين كل تسمية ظاهرية. لا يتم حذف الأعمدة المقابلة. يختار الفاصل التلقائي فاصلًا بناءً على المساحة المتاحة؛ لا يعرض بالضرورة كل تسمية.

علامات التحديد لها إعدادات منفصلة. استدعِ [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) بـ `false` واستخدم [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) لتعيين فاصلها. على سبيل المثال، `1` يبقي علامة تحديد عند كل فاصل فئة بينما تظهر التسميات كل فئة ثالثة فقط. استخدم [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) بنمط مرئي لترى النتيجة. استدعاء أي من مُعينات الفاصل التلقائي بـ `true` مرة أخرى يسمح للمخطط باختيار الفاصل مرة أخرى.

المثال المستقل التالي ينشئ 24 فئة وسلسلة واحدة، ثم يحفظ ثلاث شرائح في `CategoryAxisIntervals.pptx`: الفاصل التلقائي، الفاصل اليدوي مع علامات تحديد مستقلة، واستعادة الفاصل التلقائي. النسختان تحتفظان ببيانات المخطط الأصلية. لا يلزم أي عرض تقديمي مدخل. يجعل نص التسميات الأفقي الفرق في الكثافة واضحًا للعين.

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

    // الشريحة 2: إظهار كل تسمية ثالثة، مع الحفاظ على علامة تحديد لكل فئة.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // الشريحة 3: السماح للمخطط باختيار الفاصلين مرة أخرى.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**الفاصل التلقائي (الشريحة 1):** في هذا العرض، تُعرض كل تسمية فئة ثانية وتلتف على سطرين. قد يختلف النتيجة التلقائية حسب حجم المخطط والخطوط والمحرك.

![فاصل تلقائي لتسميات الفئة مع ظهور جميع الأعمدة الـ 24](category-axis-automatic.png)

**الفاصل اليدوي (الشريحة 2):** تُعرض كل تسمية ثالثة على سطر واحد، بينما تبقى علامات التحديد عند كل فاصل فئة. جميع الأعمدة الـ 24، بما فيها تلك التي لا تحمل تسميات، تبقى مرئية بنفس القيم. الشريحة 3 تستعيد المظهر التلقائي المعروض أعلاه.

![فاصل يدوي لتسميات الفئة بمعدل ثلاثة مع ظهور جميع الأعمدة الـ 24](category-axis-manual.png)

### **اختر المحور والفاصل الصحيح**

استخدم هذا الفاصل العددي للفئات لنوع محور فئة نصية، مثل محور فئة عمود، خط، مساحة، أو مخطط شريطي. في مخطط العمود يكون المحور الأفقي. في مخطط شريطي أفقي يكون محور الفئة عموديًا، لذا طبّق هذه الإعدادات على المحور المرجع من [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). ينطبق فاصل علامات التحديد أيضًا على محور سلسلة في المخططات التي تحتوي على أحدهما.

لا تستخدم فاصل تسميات الفئة لتعيين المقياس الرقمي لمحور القيم. على محور القيم، يحدّد [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) اختلاف القيم: على سبيل المثال، وحدة رئيسية بقيمة `10` تُنتج علامات عند 0، 10، 20، وهكذا عندما يبدأ المحور من الصفر. فاصل تسمية الفئة `3` يحسب مواضع الفئات بغض النظر عن قيم بياناتها. تستخدم مخططات التشتت والفقاعات محاور قيم بدلًا من محور فئة نصية. لمحور تاريخ، استخدم وحدات زمنية رئيسية ومقاييس كما هو موضح في [تغيير محور الفئة](#change-a-category-axis).

## **تعيين تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال البيانات الافتراضية للمخطط بأربع قيم سنوية. تُخزن التواريخ كأرقام تسلسلية OLE Automation في ورقة العمل الأولى (الفهرس `0`)، محسوبة كعدد الأيام منذ 30 ديسمبر 1899. يستخدم حساب JavaScript طوابع زمنية UTC ويقسم الفرق على 86 400 000 مللي ثانية لكل يوم. استدعِ [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) بـ `CategoryAxisType.Date`، ثم [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) بـ `false`، ومرّر `yyyy` إلى [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) حتى تُظهر تسميات الفئة السنوات بأربعة أرقام بغض النظر عن تنسيق الخلية.

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

## **تعيين زاوية تدوير عنوان محور المخطط**

استدعِ [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) بـ `true` على المحور العمودي، قدّم نص العنوان، واستخدم [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) لتدوير العنوان. تُقاس الزاوية بالدرجات؛ يحفظ المثال مخطط عمودي مع تدوير عنوان محور القيم بمقدار 90 درجة.

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

## **تعيين موضع المحور على محور الفئة أو القيم**

استخدم [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) للتحكم فيما إذا كان محور القيم يقطع محور الفئة بين الفئات أو عند علامات الفئة. ينطبق هذا الإعداد على محاور الفئة. يضبط المثال القيمة إلى `true` على محور الفئة الأفقي في مخطط عمود ويحفظ النتيجة.

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

## **تعيين وحدة العرض على محور قيم المخطط**

استخدم [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) لتقييس تسميات محور القيم دون تغيير البيانات الأساسية. مع [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) مضبوط على `Millions`، تُعرض القيمة 60 000 000 كـ 60. ينشئ المثال مخطط عمودي ويطبق وحدة العرض بالملايين على محوره الرأسي.

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

## **تهيئة محور قيم لوغاريتمي**

محور قيم لوغاريتمي مفيد عندما تتراوح القيم الموجبة عبر عدة أوامر من الدرجة. على سبيل المثال، قد يتلقى أحد الخدمات 10، 100، 1 000، 10 000، و100 000 طلبًا على مدار خمس فترات. على مقياس خطي، تظهر القيم الأصغر متقاربة جدًا بالقرب من الصفر. يجعل المقياس اللوغاريتمي نموها النسبي أسهل للمقارنة: المسافات المتساوية تمثل نسبًا متساوية بدلًا من اختلافات متساوية.

استدعِ [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) بـ `true` على محور القيم واستخدم [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) لاختيار الأساس. يغيّر ذلك طريقة عرض القيم الحالية؛ لا يغيّر البيانات ولا يضيف خط اتجاه لوغاريتمي. خط الاتجاه يمثل علاقة ملائمة في البيانات وهو ميزة مستقلة.

### **اختر محور القيم والأساس**

للمخطط الخطي أو العمودي، يُسترجع محور القيم عبر [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). للمخطط الشريطي الأفقي، يُسترجع عبر [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). تحتوي مخططات التشتت والفقاعات على محوري قيم، لذا اختر المحور الأفقي لقيم X، والمحور العمودي لقيم Y، أو كليهما. لا تُطبق المقياس اللوغاريتمي على محور فئة.

الأساس اللوغاريتمي الافتراضي هو `10`. للمخططات PPTX، يمكن استخدام أساس من `2` إلى `1000` شمولًا؛ وتُدعم الأساسات الكسرية مثل `2.5`. مع الأساس `10`، تكون القوى المتتالية مثل 10، 100، 1 000، و10 000 متباعدة بشكل متساوٍ.

### **قارن المقياس الخطي واللوغاريتمي**

المثال المستقل التالي ينشئ مخططًا خطيًا بخمسة أعداد طلبات في الشريحة الأولى، ثم ينسخ تلك الشريحة ويفعّل محور قيم لوغاريتمي بالأساس 10 في الشريحة الثانية. تحتفظ الشريحتان بنفس البيانات.

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

    // احتفظ بالشريحة الأولى خطيًا وعدّل فقط مقياس محور القيم في النسخة.
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

**المقياس الخطي (الشريحة 1):** تُظهر المسافات الرأسية المتساوية اختلافات عددية متساوية في طلبات العُمد. تهيمن القيمة الكبيرة على المخطط، ما يصعب تمييز القيم الأصغر.

![مخطط خطي في PowerPoint يُظهر خمس عدد طلبات على محور قيم خطي](value-axis-linear.png)

**المقياس اللوغاريتمي (الشريحة 2):** تُظهر المسافات الرأسية المتساوية نسبًا متساوية. كل فترة تحتوي على عشرة أضعاف عدد الطلبات من الفترة السابقة، لذا تشكُّل النقاط خطًا صاعدًا مستقيمًا على مقياس الأساس 10. لا يزال محور التسميات يُظهر القيم الأصلية للطلبات.

![نفس الخمس طلبات في PowerPoint على محور قيم لوغاريتمي بالأساس 10](value-axis-logarithmic.png)

### **معالجة القيم الصفرية والسالبة**

يمكن للمقياس اللوغاريتمي عرض قيم موجبة فقط. تحقّق من البيانات قبل تمكينه. إذا كانت القيم الصفرية أو السالبة ذات معنى، احتفظ بمقياس خطي أو اعرضها بشكل منفصل. إذا كان استبعاد تلك القيم مناسبًا للتحليل، فسّر الإقصاء. لا تستبدلها صامتًا بأرقام موجبة صغيرة، لأن ذلك يغيّر معنى البيانات. يجب أن تكون أي حدود دنيا أو قصوى مُعَدَّة يدويًا لمحور لوغاريتمي إيجابية أيضًا.

## **الأسئلة المتكررة**

**كيف يمكنني تعيين القيمة التي يتقاطع عندها أحد المحاور مع الآخر (تقاطع المحاور)؟**

استخدم [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) لتحديد سلوك التقاطع. لتحديد قيمة تقاطع عددية، استخدم [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). تسمح لك هذه الإعدادات بنقل تقاطع المحور إلى خط أساس مناسب.

**كيف يمكنني وضع تسميات العلامات بالنسبة للمحور؟**

استدعِ [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) باستخدام [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`، `High`، `NextTo`، أو `None`. للتحكم في علامات التحديد نفسها، استخدم [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) أو [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/)؛ هذه مستقلة عن وضع التسميات.