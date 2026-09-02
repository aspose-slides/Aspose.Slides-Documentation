---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية باستخدام JavaScript
linktitle: سلسلة البيانات
type: docs
url: /ar/nodejs-java/chart-series/
keywords:
- سلسلة مخطط
- تداخل السلسلة
- لون السلسلة
- اسم السلسلة
- نقطة بيانات
- خلية دفتر العمل
- فجوة السلسلة
- قيمة سلبية
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعرف على كيفية إدارة سلاسل المخططات، نقاط البيانات، خلايا دفتر العمل، التنسيق، التداخل، عرض الفجوة، والقيم السلبية في العروض التقديمية باستخدام جافا سكريبت."
---
## **نظرة عامة**

يخزن المخطط بياناته المرسومة في دفتر بيانات المخطط. تمثل [ChartSeries](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/) مجموعة واحدة من القيم المرتبطة، وكل [ChartDataPoint](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapoint/) في السلسلة يشير إلى خلية أو أكثر في دفتر العمل. توفر كائنات [ChartCategory](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartcategory/) التسميات أو قيم التجميع المشتركة بين السلاسل. وبالتالي يتم ربط اسم السلسلة والفئات وقيم النقاط بكائنات [ChartDataCell](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/) بدلاً من تخزينها كنص عرض فقط.

في المخطط الفئوي النموذجي، يستخدم دفتر العمل الافتراضي الصف 0 لأسماء السلاسل، والعمود 0 لأسماء الفئات، وتُملأ الخلايا المتبقية بقيم السلاسل. المؤشرات الخاصة بورقة العمل والصف والعمود التي تُمرر إلى [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/#getCell) تبدأ من الصفر. يُعد هذا التصميم مفيدًا عند إنشاء مخطط ببيانات افتراضية، لكن لا تفترض أن كل مخطط موجود يستخدمه. بالنسبة لعرض تم تحميله، افحص الخلايا التي تشير إليها السلاسل والفئات ونقاط البيانات قبل تعديل قيم دفتر العمل.

لإعدادات المخطط ثلاث نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [ChartSeries.getFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#getFormat)، توفّر المظهر الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات نقطة البيانات، مثل [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapoint/#getFormat)، تتجاوز مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تنطبق على السلاسل المتوافقة التي تنتمي إلى نفس [ChartSeriesGroup](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseriesgroup/). يمكنك الوصول إلى المجموعة عبر [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) عندما تحتاج إلى ضبط خيارات مثل التداخل أو عرض الفجوة.

عندما لا يتم تعيين تعبئة صريحة للنقطة أو السلسلة، يحدد نمط المخطط والموضوع المظهر التلقائي. عندما يتوفر كل من تنسيق السلسلة وتنسيق النقطة، يكون لتنسيق النقطة الأولوية لتلك النقطة.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ضبط تداخل سلسلة المخطط**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#getOverlap) يبلّغ عن مقدار تداخل الأعمدة أو الأشرطة في مخطط ثنائي الأبعاد، من -100 إلى 100 بالمائة. وهو استعراض للقراءة فقط للإعداد على مجموعة السلاسل الأصلية. استخدم [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) لتحديث كل السلاسل المتوافقة في تلك المجموعة. ينطبق هذا الخيار على أنواع المخططات التي تعرض أشرطة أو أعمدة مجموعة؛ ولا يؤثر على مجموعات السلاسل غير ذات الصلة في مخطط مركب.

المثال التالي يضبط التداخل للمجموعة التي تحتوي على السلسلة الأولى:

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

    // المخطط الجديد يحتوي على سلاسل عينات وفئات وقيم.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![The series overlap](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

استخدم [ChartSeries.getFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#getFormat) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كان لدى نقطة تعبئة صريحة مسبقًا، فإن إعداد [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapoint/#getFormat) يتجاوز تعبئة السلسلة لتلك النقطة.

المثال التالي يطبق تعبئة صلبة زرقاء على السلسلة الأولى:

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

![The color of the series](series_color.png)

## **تغيير اسم السلسلة**

يُخزّن اسم السلسلة في دفتر بيانات المخطط وعادةً ما يُعرض في المفتاح. في دفتر العمل الافتراضي المُنشأ لمخطط عمودي متكتل، الخلية B1 تكون في الصف 0، العمود 1 وتحتوي على اسم السلسلة الأولى. الثوابت المسماة في المثال التالي تجعل هذه البنية صريحة:

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

يمكنك أيضًا تحديث الخلية التي يشير إليها بالفعل [ChartSeries.getName](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#getName). يavoid هذا النهج الافتراض بوجود صف أو عمود معين في مخطط موجود:

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

![The series name](series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) يُرجع اللون المُحسب من فهرس السلسلة ونمط المخطط. هذا هو اللون المستخدم عندما لا تُحدد تعبئة السلسلة صراحة. استدعاء الطريقة يقرأ اللون المُحسب؛ ولا يضيف تعبئة جديدة.

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

مثال على ناتج نمط المخطط الافتراضي:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

الألوان الدقيقة تعتمد على نمط المخطط والموضوع.

## **ضبط لون التعبئة المعكوسة لسلسلة المخطط**

للسلاسل العمودية، العمدية، والفقاعية، يمكن لـ [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) عرض القيم السالبة بتعبئة مختلفة. اضبط تعبئة السلسلة العادية إلى صلبة، فعّل الانعكاس، وعين لون القيم السالبة عبر [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). تبقى الأرقام السالبة دون تغيير في دفتر العمل؛ فقط يتغير لون العرض.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. يحتوي الصف 0 من ورقة العمل على اسم السلسلة، والعمود 0 على أسماء الفئات، والعمود 1 على القيم:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

يمكنك تفعيل الانعكاس لنقطة واحدة عبر [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). في المثال التالي يُعطَّل الانعكاس للسلسلة ويُفعَّل فقط للنقطة المختارة. تُعطى النقطة أيضًا قيمة سالبة لتظهر التأثير:

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

## **مسح قيمة نقطة بيانات محددة**

لجعل نقطة واحدة فارغة دون إزالة النقاط الأخرى، اضبط الخلية الداعمة في دفتر العمل إلى `null`. بالنسبة لمخطط عمودي، القيمة المرسومة متاحة عبر [ChartDataPoint.getValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapoint/#getValue). تظل نقطة البيانات في نفس موضع الفئة، لكن المخطط يتعامل مع قيمتها كخلية فارغة وفقًا لإعدادات القيم الفارغة للمخطط.

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

تستخدم المخططات المتناثرة خلايا X وY منفصلة، وتستخدم مخططات الفقاعات أيضًا خلية حجم. امسح فقط الخلية التي تمثل القيمة التي ترغب في إزالتها. لا تستدعِ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapointcollection/#clear) عندما تريد الإبقاء على باقي النقاط، لأن هذه الطريقة تحذف كل نقاط البيانات من المجموعة.

## **ضبط عرض الفجوة بين السلاسل**

عرض الفجوة هو المسافة بين مجموعات الأعمدة أو الأشرطة المتجاورة، معبرًا عنها كنسبة مئوية من عرض العمود أو الشريط. مثل التداخل، تنتمي إلى مجموعة السلسلة الأصلية وليس إلى سلسلة واحدة. استدعِ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) مرة واحدة للمجموعة. قيمة أكبر تُنشئ مساحة أوسع بين المجموعات؛ قيمة أصغر تجعلها أكثر كثافة.

المثال التالي يغيّر عرض الفجوة ويحفظ العرض النهائي فقط:

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

![The gap width](gap_width.png)

## **الأسئلة المتكررة**

**ما أنواع المخططات التي تدعم سلاسل البيانات؟**

جميع أنواع المخططات التي تمثلها تعداد [ChartType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/charttype/) تستخدم بيانات المخطط، لكن سلاسلها لا تشترك دائمًا في نفس بنية القيم أو الإعدادات. على سبيل المثال، تستخدم المخططات الفئوية الفئات والقيم، وتستخدم مخططات المتناثر قيم X وY، وتضيف مخططات الفقاعات أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتطابق مع نوع السلسلة. تنطبق خيارات مثل التداخل وعرض الفجوة فقط على مجموعات الأشرطة أو الأعمدة المتوافقة.

**ما هو مجموعة سلسلة المخطط؟**

[ChartSeriesGroup](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseriesgroup/) يحتوي على سلاسل متوافقة تشترك في إعدادات التخطيط على مستوى المجموعة. يمكن لمخطط مركب أن يحتوي على أكثر من مجموعة، لذا فإن تغيير المجموعة عبر سلسلة واحدة لا يغيّر بالضرورة كل السلاسل في المخطط.

**هل يحتوي المخطط الذي يُنشأ حديثًا على بيانات افتراضية؟**

نعم. بشكل افتراضي، يُنشئ [ShapeCollection.addChart](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/#addChart) سلاسل وعناصر فئة وقيم عينات. يمكنك تحرير تلك الخلايا أو مسح كل من مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة تمامًا. يمكن أيضًا استدعاء نسخة م overload لإنشاء مخطط بدون بيانات افتراضية.

**كيف تُربط كائنات المخطط بخلايا دفتر العمل؟**

تُشير أسماء السلاسل، وتسميات الفئات، وقيم نقاط البيانات إلى خلايا في [ChartDataWorkbook](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/). تعديل خلية مُشار إليها يحدّث العنصر المقابل في المخطط. عند بناء بيانات مخصصة، حافظ على توافق صفوف الفئات وصفوف قيم السلاسل بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف أمسح نقطة واحدة بدلاً من مسح السلسلة بأكملها؟**

عيّن الخلية التي تحتوي على القيمة ذات الصلة إلى `null` للحفاظ على موضع الفئة كنقطة فارغة. استخدم [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapointcollection/#clear) فقط عندما تريد حذف جميع النقاط من تلك السلسلة. إذا أزلت الفئات أيضًا، حدّث كل السلاسل بحيث تبقى قيمها متوافقة مع مجموعة الفئات.

**كيف يتم عرض النقاط الفارغة؟**

يعتمد ذلك على نوع المخطط والقيمة المُكوَّنة عبر [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs). تدعم المخططات عرض الفُراغات كفجوات، أو كقِيَم صفرية، أو عبر ربط النقاط المجاورة. اختر الإعداد الذي يتماشى مع معنى البيانات المفقودة في عرضك.

**كيف يتم تنسيق القيم السالبة؟**

بالنسبة للسلاسل العمودية، الأشرطة، والفقاعية المدعومة، استدعِ [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) وعين اللون المرجع من [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). يمكنك تجاوز السلوك لنقطة فردية باستخدام [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). هذه الطرق تؤثر على التنسيق فقط، وليس على القيم الرقمية المخزنة.

**أي تنسيق ينتصر عندما يتم تنسيق كل من السلسلة والنقطة؟**

يأخذ تنسيق نقطة البيانات الصريح الأولوية لتلك النقطة. تظل النقاط الأخرى تستخدم تنسيق السلسلة الصريح أو، إذا لم يُحدَّد تنسيق للسلسلة، النمط والموضوع التلقائي للمخطط. إعدادات المجموعة مثل التداخل وعرض الفجوة تتحكم في التخطيط ولا تُعدّ تجاوزات تنسيق على مستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها المخطط؟**

Aspose.Slides لا يفرض حدًا ثابتًا منفصلًا لعدد السلاسل. في الواقع، تحدد قيود ملف العرض، والذاكرة المتاحة، ووقت التصيير، ووضوح المخطط حدًا عمليًا.

**ماذا أفعل عندما تكون الأعمدة متقاربة جدًا أو متباعدة جدًا؟**

استدعِ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) على مجموعة السلاسل الأصلية المناسبة. زد القيمة لتوسيع الفجوة بين المجموعات، أو قللها لتقريب المجموعات من بعضها البعض.