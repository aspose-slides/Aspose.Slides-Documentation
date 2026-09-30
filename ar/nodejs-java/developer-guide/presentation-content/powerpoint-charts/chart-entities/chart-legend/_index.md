---
title: تخصيص وسوم المخططات في العروض التقديمية باستخدام JavaScript
linktitle: وسم المخطط
type: docs
url: /ar/nodejs-java/chart-legend/
keywords:
- وسم المخطط
- موضع الوسم
- حجم الخط
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "قم بتخصيص وسوم المخططات باستخدام Aspose.Slides لـ Node.js عبر Java لتحسين عروض PowerPoint التقديمية من خلال تنسيق وسوم مخصص."
---
## **نظرة عامة**

يوفر Aspose.Slides for Node.js عبر Java خيارات لتخصيص وسوم المخطط في عروض PowerPoint التقديمية. تُظهر هذه المقالة كيفية تحديد موضع وحجم الوسم، وتعيين حجم الخط للوسم بأكمله، وتنسيق إدخال وسم فردي، وإخفاء أو استعادة الإدخالات المحددة.

تغطي الأسئلة الشائعة السلوكيات المرتبطة، بما في ذلك حجز مساحة للوسم، وعرض تسميات متعددة الأسطر، ووراثة التنسيق من سمة العرض التقديمي.

## **موضع الوسم**

استخدم طرق [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/), و[setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/) للوسم لتحديد موضعه وحجمه ككسر من أبعاد المخطط.

ينشئ هذا المثال عرضًا تقديميًا ويضيف مخطط أعمدة مجمع ببيانات افتراضية إلى الشريحة الأولى. تقسيم إزاحات وأبعاد الوسم المطلوبة على عرض وارتفاع المخطط يحولها إلى قيم نسبية: يتم إزاحة الوسم بمقدار 50 نقطة من الركن العلوي الأيسر للمخطط وتكون حجمه 100×100 نقطة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // تحديد موضع وحجم الوسم بالنسبة إلى المخطط.
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين حجم الخط للوسم**

استخدم [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/) للوسم للوصول إلى تنسيق النص الخاص به واستخدم [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) لتعيين حجم الخط بالنقاط.

ينشئ هذا المثال مخططًا ببيانات افتراضية ويعيّن نص الوسم إلى 20 نقطة. كما يقوم بتعطيل الحدود التلقائية للمحور الرأسي ويعيّن نطاقه من -5 إلى 10.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين حجم الخط لإدخال وسم فردي**

استخدم المجموعة التي تُرجعها طريقة [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/) للوسم للوصول إلى تنسيق إدخال معين. مؤشرات الإدخالات تبدأ من الصفر، لذا فإن الفهرس `1` يشير إلى الإدخال الثاني.

ينشئ هذا المثال مخطط أعمدة مجمع تتضمن بياناته الافتراضية سلسلتين على الأقل. يقوم بتنسيق الإدخال الثاني للوسم باستخدام نص عريض ومائل وزرقاء بحجم 20 نقطة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إخفاء إدخالات وسم فردية**

لإستبعاد سلسلة مساعدة من الوسم مع إبقاء بياناتها ظاهرة، استدعِ [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) مع `true` عبر [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/). هذا يُخفي فقط إدخال الوسم المحدد؛ ولا يزيل السلسلة أو نقاط بياناتها. بالمقابل، استدعاء [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) مع `false` يُخفي الوسم بأكمله.

يخلق المثال أدناه مخطط أعمدة مجمع بعدة سلاسل باستخدام البيانات الافتراضية. يُخفي إدخال وسمة السلسلة الثانية (الفهرس `1`) ويحفظ العرض التقديمي. ثم يستعيد الإدخال عن طريق استدعاء [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) مع `false` ويحفظ نسخة ثانية. تظل الأعمدة مرئية في كلا الملفين.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // استعادة نفس الإدخال دون تعديل بيانات المخطط.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تُظهر المقارنة أدناه نفس المخطط مع جميع الإدخالات مرئية ومع إخفاء الإدخال الثاني. تظل أعمدة السلسلة الثانية دون تغيير.

![مقارنة مخطط مع جميع إدخالات الوسم مرئية ومع إخفاء السلسلة 2 من الوسم؛ جميع الأعمدة تظل مرئية.](hide-legend-entry.png)

في مخططات العمود والشريط والخط، تحدد إدخالات الوسم السلسلة. بالنسبة لمخططات الدائرة، تحدد نقاط البيانات الفردية (الشرائح)، لذا استخدم [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) على الشريحة المحددة بدلاً من ذلك. توثّق API هذه الطريقة لنقطة البيانات لأنواع المخططات `Pie` و`Pie3D` و`ExplodedPie` و`ExplodedPie3D` و`PieOfPie` و`BarOfPie`. لا تفترض أنها تنطبق على مخططات الدونات، والتي ليست مدرجة في تلك القائمة.

## **الأسئلة الشائعة**

**هل يمكنني جعل المخطط يخصص مساحة للوسم بدلاً من وضعه فوقه؟**  
نعم. استدعِ [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) مع `false` لحجز مساحة للوسم بدلاً من السماح له بتغطية مساحة الرسم.

**هل يمكنني إنشاء تسميات وسمة متعددة الأسطر؟**  
نعم. يمكن أن تُلف التسميات الطويلة عندما يكون العرض المتاح غير كافٍ. يمكنك أيضًا استخدام أحرف السطر الجديد في أسماء السلاسل لطلب فواصل أسطر.

**كيف أجعل الوسم يتبع نظام ألوان سمة العرض التقديمي؟**  
اترك ألوان الوسم وتعبئاته وخطوطه غير محددة حتى يتمكن من وراثة تنسيق السمة. يطغى التنسيق الصريح على إعدادات السمة المقابلة.