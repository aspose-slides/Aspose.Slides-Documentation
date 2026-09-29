---
title: إدارة بيانات سلاسل المخطط في العروض التقديمية باستخدام JavaScript
linktitle: سلاسل البيانات
type: docs
url: /ar/nodejs-java/chart-series/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية إدارة سلاسل المخطط، نقاط البيانات، خلايا دفتر العمل، التنسيق، التداخل، عرض الفجوة، والقيم السلبية في العروض التقديمية باستخدام JavaScript."
---
## **نظرة عامة**

يخزن المخطط بياناته المخططة في دفتر عمل بيانات المخطط. تمثّل [ChartSeries](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/) مجموعة واحدة من القيم المرتبطة، وكل [ChartDataPoint](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapoint/) في السلسلة يشير إلى خلية واحدة أو أكثر في دفتر العمل. توفر كائنات [ChartCategory](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartcategory/) التسميات أو قيم التجميع المشتركة بين السلاسل. وبالتالي فإن اسم السلسلة والفئات وقيم النقاط مرتبطة بكائنات [ChartDataCell](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/) بدلاً من تخزينها كنص عرض فقط.

بالنسبة للمخطط الفئوي النموذجي، يستخدم دفتر العمل الافتراضي الصف 0 لأسماء السلاسل، والعمود 0 لأسماء الفئات، والبقية للخلايا التي تحتوي على قيم السلسلة. الفهارس الخاصة بالورقة، الصف، والعمود التي تُمرّر إلى [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/#getCell) تبدأ من الصفر. يُفيد هذا التخطيط عند إنشاء مخطط ببيانات افتراضية، لكن لا تفترض أن كل مخطط موجود يستخدمه. بالنسبة للعرض التقديمي المحمل، افحص الخلايا التي تُشير إليها السلاسل والفئات ونقاط البيانات قبل تعديل قيم دفتر العمل.

لإعدادات المخطط ثلاث نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [ChartSeries.getFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#getFormat)، تُقدِّم المظهر الافتراضي لكل النقاط في سلسلة واحدة.
- إعدادات على مستوى نقطة البيانات، مثل [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapoint/#getFormat)، تتجاوز مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تنطبق على السلاسل المتوافقة التي تنتمي إلى نفس [ChartSeriesGroup](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseriesgroup/). يمكن الوصول إلى المجموعة عبر [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) عندما تحتاج لتعيين خيارات مثل التداخل أو عرض الفجوة.

عند عدم تحديد تعبئة صريحة للنقطة أو السلسلة، يحدد نمط المخطط والثيم المظهر التلقائي. عندما تكون كلٌ من تنسيقات السلسلة والنقطة موجودة، تُعطى أولوية لتنسيق النقطة لتلك النقطة.

![سلسلة المخطط في PowerPoint](chart-series-powerpoint.png)

## **تعيين تداخل سلاسل المخطط**

يُبلغ [ChartSeries.getOverlap](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#getOverlap) مقدار تداخل الأعمدة أو الأعمدة في مخطط 2D، من -100 إلى 100 في المئة. وهو عرض قراءة فقط للإعداد في مجموعة السلسلة الأصلية. استخدم [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) لتحديث كل السلاسل المتوافقة في تلك المجموعة. ينطبق هذا الخيار على أنماط المخططات التي تُظهر أعمدة أو أشرطة مجمّعة؛ ولا يؤثر على مجموعات السلاسل غير المرتبطة في مخطط مركب.

المثال التالي يعيّن التداخل للمجموعة التي تحتوي على السلسلة الأولى:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // المخطط الجديد يحتوي على سلاسل، فئات، وقيم نموذجية.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![تداخل السلسلة](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

استخدم [ChartSeries.getFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#getFormat) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كانت النقطة لديها تعبئة صريحة مسبقًا، فإن إعداد [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapoint/#getFormat) يتجاوز تعبئة السلسلة لتلك النقطة.

المثال التالي يطبّق تعبئة صلبة باللون الأزرق على السلسلة الأولى:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![لون السلسلة](series_color.png)

## **تغيير اسم السلسلة**

يُخزن اسم السلسلة في دفتر عمل بيانات المخطط ويُعرض عادةً في الأسطورة. في دفتر العمل الافتراضي المُنشأ لمخطط عمود مُجمّع، تكون الخلية B1 في الصف 0 والعمود 1 وتحتوي على اسم السلسلة الأولى. الثوابت المسماة في المثال التالي تجعل هذا الهيكل واضحًا:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يمكنك أيضًا تحديث الخلية التي يُشير إليها [ChartSeries.getName](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#getName). يتجنّب هذا الأسلوب الافتراض بوجود صف أو عمود معين في مخطط موجود:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![اسم السلسلة](series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

يعيد [ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) اللون المحسوب من فهرس السلسلة ونمط المخطط. هذا هو اللون المستخدم عندما لا تُحدَّد تعبئة السلسلة صراحة. استدعاء الطريقة يقرأ اللون المحسوب؛ ولا يعيّن تعبئة جديدة.

المثال التالي يطبع اللون التلقائي لكل سلسلة افتراضية:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

مخرجات المثال لنمط المخطط الافتراضي:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

الألوان الدقيقة تعتمد على نمط المخطط والثيم.

## **تعيين لون تعبئة معكوس لسلسلة المخطط**

بالنسبة لسلاسل الأعمدة، الأشرطة، والفقاعات، يمكن لـ [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) عرض القيم السالبة بتعبئة مختلفة. عيّن تعبئة السلسلة العادية إلى صلبة، فعّل الانعكاس، وعيّن لون القيمة السالبة عبر [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). تبقى الأرقام السالبة غير معدَّلة في دفتر العمل؛ يتغيّر فقط لون العرض.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. الصف 0 في الورقة يحتوي على اسم السلسلة، والعمود 0 يحتوي على أسماء الفئات، والعمود 1 يحتوي على القيم:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![لون التعبئة الصلبة المعكوس](inverted_solid_fill_color.png)

يمكنك تمكين الانعكاس لنقطة واحدة عبر [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). في المثال التالي، يُعطَّل الانعكاس للسلسلة ويُفعَّل فقط للنقطة المحددة. تُعطى النقطة أيضًا قيمة سالبة لتظهر التأثير:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مسح قيمة نقطة بيانات معينة**

لجعل نقطة واحدة فارغة دون إزالة النقاط الأخرى، عيّن خلية دفتر العمل الداعمة لها إلى `null`. بالنسبة لمخطط عمودي، القيمة المرسومة متاحة عبر [ChartDataPoint.getValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapoint/#getValue). تظل نقطة البيانات في نفس موقع الفئة، لكن المخطط يتعامل مع قيمتها كفراغ وفقًا لإعدادات القيم الفارغة في المخطط.

المثال التالي يمسح فقط النقطة الثانية في السلسلة الأولى:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تستخدم مخططات التشتت خلايا X وY منفصلة، وتستخدم مخططات الفقاعات أيضًا خلية الحجم. امسح الخلية التي تمثّل القيمة التي ترغب في إزالتها. لا تستدعِ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapointcollection/#clear) عندما تريد الحفاظ على النقاط الأخرى، لأن هذه الطريقة تحذف كل نقاط البيانات من المجموعة.

## **التحكم في عرض الخلايا الفارغة**

الخلايا المخفية التي تحتوي على قيم هي حالة منفصلة عن الخلايا الفارغة. لتضمين أو استبعاد البيانات من صفوف وأعمدة الورقة المخفية، راجع [Include Data from Hidden Rows and Columns](/slides/ar/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

الخلية الفارغة في دفتر العمل تمثّل بيانات مفقودة؛ الخلية التي تحتوي على `0` تمثّل قيمة عددية معروفة. استدعِ [ChartDataCell.setValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#setValue) مع `null` لجعل الخلية فارغة. الصفر الرقمي يبقى صفرًا بغض النظر عن إعداد الخلايا الفارغة.

استخدم [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) لاختيار طريقة عرض المخطط للخلايا الفارغة. ينطبق هذا الإعداد على كامل المخطط. إنه يغيّر طريقة رسم الفواصل دون ملء الخلية الفارغة بالصفر أو قيمة مقربة.

المثال التالي المستقل يُنشئ مخططًا خطيًا بسلسلة واحدة، يمسح القيمة لليوم 3، ويحفظ المخطط بنفسه بكل وضع. لا يلزم ملف إدخال. يستخدم [ChartDataWorkbook](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/) الورقة 0، العمود 0 لتسميات الفئات، والعمود 1 للقيم؛ الصف 0 يحمل اسم السلسلة. البيانات النهائية هي `10, 20, empty, 30, 40`.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // اترك اليوم 3 فارغًا فعليًا، مع الحفاظ على فئته ونقطة البيانات الخاصة به.
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

كل ملف ناتج يُخزّن الوضع المعيّن قبل الحفظ: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx`، و`empty_cells_Span.pptx`. لحفظ نسخة واحدة فقط، عيّن الوضع المطلوب واحفظ العرض التقديمي مرة واحدة بدلًا من التكرار على الأوضاع.

المقارنة أدناه تُظهر نفس البيانات في جميع الملفات الثلاثة. اليوم 3 فارغ في دفتر العمل في كل حالة:

![مخططات خطية ببيانات متطابقة: الفجوة تقطع الخط في اليوم 3، الصفر يُخفض الخط إلى الصفر، والامتداد يربط اليوم 2 باليوم 4.](display_blanks_as.png)

التأثير المرئي يعتمد على نوع المخطط. يجعل مخطط الخطّ الثلاثة أوضاع سهلة المقارنة. المخططات الشريطية والعمودية لا تمتلك خطًا يربط عبر فئة مفقودة، لذا لا يستطيع `Span` إنتاج القطعة المتصلة الموضحة أعلاه؛ وقد تبدو عمود مفقود وعمود بارتفاع صفر متشابهين. بالمثل، مخطط التشتت مع العلامات فقط لا يملك خطًا متصلًا. لا تتوقع ثلاث نتائج متميزة لكل نوع مخطط؛ افحص النتيجة للنوع الذي تستخدمه.

## **تعيين عرض الفجوة بين السلاسل**

عرض الفجوة هو المسافة بين مجموعات الأعمدة أو الأشرطة المتجاورة، تُعبَّر كنسبة مئوية من عرض العمود أو الشريط. مثل التداخل، ينتمي إلى مجموعة السلسلة الأصلية بدلاً من سلسلة واحدة. استدعِ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) مرة واحدة للمجموعة. القيمة الأكبر تخلق مساحة أكبر بين المجموعات؛ والقيمة الأصغر تجعلها أكثر كثافة.

المثال التالي يغيّر عرض الفجوة ويحفظ العرض التقديمي النهائي فقط:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![عرض الفجوة](gap_width.png)

## **الأسئلة الشائعة**

**ما أنواع المخططات التي تدعم سلاسل البيانات؟**

جميع أنواع المخططات المًمثلة في تعداد [ChartType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/charttype/) تستخدم بيانات المخطط، لكن سلاسلها لا تتشارك جميعها نفس بنية القيم أو الإعدادات. على سبيل المثال، تستخدم المخططات الفئوية الفئات والقيم، ومخططات التشتت قيم X وY، ومخططات الفقاعات تضيف أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتطابق مع نوع السلسلة. تنطبق خيارات مثل التداخل وعرض الفجوة فقط على مجموعات الأعمدة أو الشريط المتوافقة.

**ما هي مجموعة سلاسل المخطط؟**

[ChartSeriesGroup](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseriesgroup/) يحتوي على سلاسل متوافقة تشترك في إعدادات التخطيط على مستوى المجموعة. يمكن أن يحتوي مخطط مركب على أكثر من مجموعة، لذا تغيير المجموعة التي تُصل من خلالها إحدى السلاسل لا يغيّر بالضرورة كل السلاسل في المخطط.

**هل يحتوي المخطط المُنشأ حديثًا على بيانات افتراضية؟**

نعم. بشكل افتراضي، تُنشئ الدالة [ShapeCollection.addChart](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/#addChart) سلاسل، فئات، وقيم نموذجية. يمكنك تعديل تلك الخلايا أو مسح كل من مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة بالكامل. يمكن للنسخة الفائقة أيضًا إنشاء مخطط دون بيانات افتراضية.

**كيف تُربط كائنات المخطط بخلايا دفتر العمل؟**

أسماء السلاسل، تسميات الفئات، وقيم نقاط البيانات تُشير إلى خلايا في [ChartDataWorkbook](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/). تعديل خلية مُشار إليها يُحدِّث العنصر المقابل في المخطط. عند بناء بيانات مخصصة، احرص على محاذاة صفوف الفئات وصفوف قيم السلاسل بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف أحذف نقطة واحدة بدلاً من السلسلة بأكملها؟**

عيّن خلية القيمة ذات الصلة إلى `null` لتبقى نقطة الفئة في موقعها كنقطة فارغة. استخدم [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapointcollection/#clear) فقط عندما ترغب في حذف كل النقاط من تلك السلسلة. إذا أزلت الفئات أيضًا، حدّث كل السلاسل بحيث تظل قيمها متناسقة مع مجموعة الفئات.

**كيف تُعرض النقاط الفارغة؟**

يعتمد النتيجة على نوع المخطط والقيمة المُعيَّنة عبر [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs). يمكن للمخططات المدعومة عرض الفواصل كفجوات، كقِيَم صفرية، أو بربط النقاط المتجاورة. اختر الإعداد الذي يتطابق مع معنى البيانات المفقودة في عرضك. راجع [Control the Display of Empty Cells](#control-the-display-of-empty-cells) لمثال كامل ومقارنة بصرية.

**كيف يُنسق القيم السالبة؟**

بالنسبة للسلاسل الشريطية، العمودية، والفقاعات المدعومة، استدعِ [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) وعَيِّن اللون الذي تُعيده [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). يمكنك تجاوز السلوك لنقطة فردية باستخدام [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). هذه الطرق تؤثر على التنسيق، وليس على القيم العددية المخزّنة.

**أي تنسيق ينتصر عندما يتم تنسيق كل من السلسلة والنقطة؟**

يتفوّق تنسيق نقطة البيانات الصريح لتلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، إذا لم يُحدَّد تنسيق السلسلة، النمط والثيم التلقائي للمخطط. إعدادات المجموعة مثل التداخل وعرض الفجوة تتحكم في التخطيط وليست تجاوزات تنسيق على مستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها المخطط؟**

Aspose.Slides لا يفرض حدًا ثابتًا منفصلًا لعدد السلاسل. في الواقع، تحدد قيود ملف العرض، الذاكرة المتاحة، زمن التقديم، وقابلية قراءة المخطط حدًا عمليًا.

**ماذا يجب تغييره عندما تكون الأعمدة متقاربة جدًا أو متباعدة كثيرًا؟**

استدعِ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) على مجموعة السلسلة الأصلية المناسبة. زد القيمة لتوسيع المسافة بين المجموعات، أو قللها لتقريب المجموعات من بعضها البعض.