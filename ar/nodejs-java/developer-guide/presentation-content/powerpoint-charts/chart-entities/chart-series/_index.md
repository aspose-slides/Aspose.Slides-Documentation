---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية باستخدام JavaScript
linktitle: سلسلة البيانات
type: docs
url: /ar/nodejs-java/chart-series/
keywords:
- سلسلة المخطط
- تداخل السلسلة
- لون السلسلة
- اسم السلسلة
- نقطة البيانات
- خلية المصنف
- فجوة السلسلة
- قيمة سلبية
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعرف على كيفية إدارة سلاسل المخطط، نقاط البيانات، خلايا المصنف، التنسيق، التداخل، عرض الفجوة، والقيم السلبية في العروض التقديمية باستخدام JavaScript."
---
## **نظرة عامة**

يخزن المخطط بياناته المرسومة في مصنف بيانات المخطط. تمثّل [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) مجموعة واحدة من القيم ذات الصلة، وكل [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) في السلسلة يشير إلى خلية أو أكثر في المصنف. توفّر كائنات [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) التسميات أو قيم التجميع المشتركة بين السلاسل. وبالتالي يتم ربط اسم السلسلة والفئات وقيم النقاط بـ [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) بدلاً من تخزينها كنص عرض فقط.

للمخطط الفئوي النموذجي، يستخدم المصنف الافتراضي الصف 0 لأسماء السلاسل، والعمود 0 لأسماء الفئات، والخلايا المتبقية لقيم السلسلة. إن فهارس ورقة العمل والصف والعمود التي تُمرّر إلى [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getCell) تبدأ من الصفر. يُعدّ هذا الترتيب مفيداً عند إنشاء مخطط ببيانات افتراضية، لكن لا تفترض أن كل مخطط موجود يستخدمه. بالنسبة لعروض تقديمية محمّلة، تفحّص الخلايا التي تُشير إليها السلاسل والفئات ونقاط البيانات قبل تعديل قيم المصنف.

لإعدادات المخطط ثلاث نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getFormat)، تُوفر المظهر الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات نقطة البيانات، مثل [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#getFormat)، تتجاوز مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تنطبق على السلاسل المتوافقة التي تنتمي إلى نفس [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/). يمكن الوصول إلى المجموعة عبر [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) عندما تحتاج إلى ضبط خيارات مثل التداخل أو عرض الفجوة.

عند عدم ضبط تعبئة صريحة للنقطة أو السلسلة، يحدّد نمط المخطط والثيم المظهر التلقائي. عندما تكون كل من تنسيقات السلسلة والنقطة موجودة، تُعطى أولوية لتنسيق النقطة لتلك النقطة.

![سلسلة المخطط PowerPoint](chart-series-powerpoint.png)

## **ضبط تداخل سلاسل المخطط**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getOverlap) يُبلغ عن مقدار تداخل الأعمدة أو القضبان في مخطط ثنائي الأبعاد، من -100 إلى 100 بالمائة. وهو إسقاط للقراءة فقط للإعداد على مجموعة السلاسل الأصلية. استخدم [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) لتحديث كل السلاسل المتوافقة في تلك المجموعة. ينطبق هذا الخيار على أنواع المخططات التي تعرض أعمدة أو قضبان مجموعّة؛ ولا يؤثر على مجموعات السلاسل غير المرتبطة في مخطط مركب.

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

    // المخطط الجديد يحتوي على سلاسل وعينات، فئات، وقيم.
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

استخدم [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getFormat) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كانت للنقطة تعبئة صريحة، فإن إعداد [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#getFormat) يتجاوز تعبئة السلسلة لتلك النقطة.

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

يُخزن اسم السلسلة في مصنف بيانات المخطط ويُعرض عادةً في وسيلة الإيضاح. في المصنف الافتراضي المُنشأ لمخطط أعمدة مجمّعة، تكون الخلية B1 في الصف 0، العمود 1 وتحتوي على اسم السلسلة الأولى. تُظهر الثوابت المسماة في المثال التالي هذا الهيكل بوضوح:

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

يمكنك أيضاً تحديث الخلية التي تُشير إليها [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getName). يَتجنّب هذا النهج الافتراض بوجود صف وعمود معينين في مخطط موجود:

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

### **إنشاء سلسلة باسم مأخوذ من خلايا متعددة**

يكون اسم السلسلة المركّبة مفيداً عندما يُخزن اسم المنتج وفترة التقرير في خلايا مصنف منفصلة. على سبيل المثال، يمكنك دمج `Product A` في B1 و `2026` في C1 لتكوين اسم سلسلة واحد مع الحفاظ على ربط كلا الجزئين بالخلايا المصدر.

استخدم [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getCellCollection) لاسترجاع نطاق الاسم، ثم مرّر هذا التجميع إلى [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/#add). يتحكم المتغيّر `skipHiddenCells` فيما إذا كانت الخلايا المخفيّة تُضمّن: `true` تستثنيها، و`false` تضمّنها. يستخدم المثال التالي `false` لتضمين كل خلية في نطاق الاسم.

المثال التالي يخلق عرضاً تقديمياً بسلسلة واحدة ونقطتي بيانات. تُزوّد الخلايا B1:C1 باسم السلسلة فقط؛ وتُزوّد A2:A3 بتسميات الفئات، وتُزوّد B2:B3 بالقيم الرقمية.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // هاتان الخليتان تزودان اسم السلسلة.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // خلايا منفصلة تزود الفئات ونقاط البيانات الرقمية.
    const northCategory = workbook.getCell(0, 1, 0, "North");
    const southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    const northValue = workbook.getCell(0, 1, 1, 120);
    const southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اسم السلسلة الناتج هو `Product A 2026` مع مسافة بين القيمتين من الخلية. تُظهر وسيلة الإيضاح ذلك كإدخال واحد لكل العمودين. توضح الصورة أدناه النتيجة:

![مخطط أعمدة مع قيم الشمال والجنوب واسم السلسلة المركّبة Product A 2026 في وسيلة الإيضاح](composite_series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) يُعيد اللون المحسوب من فهرس السلسلة ونمط المخطط. هذا هو اللون المُستخدم عندما لا تُحدَّد تعبئة السلسلة صراحة. تستدعي الطريقة اللون المحسوب؛ ولا تُعيّن تعبئة جديدة.

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

مثال على المخرجات لنمط المخطط الافتراضي:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

تعتمد الألوان الدقيقة على نمط المخطط والثيم.

## **ضبط عكس لون التعبئة لسلسلة المخطط**

بالنسبة لسلاسل الأعمدة، الأعمدة، والفقاعات، يمكن لـ [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) عرض القيم السالبة بتعبئة مختلفة. اضبط تعبئة السلسلة العادية لتكون صلبة، مفعّلًا العكس، وعين لون القيمة السالبة عبر [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). تظل الأرقام السالبة دون تغيير في المصنف؛ يتغيّر فقط لون عرضها.

المثال التالي يُستبدل بيانات المخطط الافتراضية بسلسلة واحدة. يحتوي الصف 0 من ورقة العمل على اسم السلسلة، العمود 0 على أسماء الفئات، والعمود 1 على القيم:

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

![لون التعبئة الصلب المعكوس](inverted_solid_fill_color.png)

يمكنك تمكين العكس لنقطة واحدة عبر [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). في المثال التالي يُعطَّل العكس للسلسلة ويُفعَّل فقط للنقطة المحددة. تُعيّن النقطة قيمة سالبة لتظهر التأثير:

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

لجعل نقطة واحدة فارغة دون إزالة باقي النقاط، اضبط خلية المصنف الداعمة لها إلى `null`. للمخطط العمودي، تتوفر القيمة المرسومة عبر [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#getValue). تبقى نقطة البيانات في نفس موضع الفئة، لكن المخطط يتعامل مع قيمتها كخالية وفق إعدادات القيم الفارغة للمخطط.

المثال التالي يمسح النقطة الثانية في السلسلة الأولى فقط:

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

تستخدم مخططات التناثر خلايا X وY منفصلة، وتستخدم مخططات الفقاعات خلية الحجم أيضاً. امسح الخلية التي تمثل القيمة التي تريد إزالتها فقط. لا تُستدعي [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/#clear) عندما تريد الحفاظ على النقاط الأخرى، لأن هذه الطريقة تُزيل كل نقاط البيانات من التجميع.

## **التحكم في عرض الخلايا الفارغة**

الخلايا المخفية التي تحتوي على قيم هي حالة منفصلة عن الخلايا الفارغة. لتضمين أو استبعاد البيانات من الصفوف والأعمدة المخفيّة في ورقة العمل، راجع [Include Data from Hidden Rows and Columns](/slides/ar/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

تمثّل خلية مصنف فارغة بيانات مفقودة؛ وتُمثّل الخلية التي تحتوي على `0` قيمة رقمية معروفة. استدعِ [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#setValue) مع `null` لجعل الخلية فارغة. يبقى الصفر الرقمي صفرًا بغض النظر عن إعداد الخلية الفارغة.

استخدم [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) لاختيار كيفية عرض المخطط للخلايا الفارغة. ينطبق هذا الإعداد على المخطط بأكمله. يغيّر طريقة رسم الفجوات دون ملء الخلية الفارغة بالصفر أو قيمة مُقوَّسة.

المثال المستقل التالي يُنشئ مخططًا خطيًا بسلسلة واحدة، يمسح القيمة لليوم 3، ويحفظ المخطط نفسه بكل وضع. لا يلزم ملف إدخال. يستخدم [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) ورقة العمل 0، العمود 0 لتسميات الفئات، والعمود 1 للقيم؛ الصف 0 يحمل اسم السلسلة. البيانات النهائية هي `10, 20, empty, 30, 40`.

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

    // اترك اليوم 3 فارغًا حقًا، مع الحفاظ على فئته ونقطة بياناته.
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

كل ملف ناتج يخزن الوضع المُعين قبل الحفظ: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx`، و `empty_cells_Span.pptx`. لحفظ نسخة واحدة فقط، عيّن الوضع المطلوب واحفظ العرض مرةً واحدة بدلاً من التكرار على الأوضاع.

المقارنة أدناه تُظهر البيانات نفسها في جميع الملفات الثلاثة. اليوم 3 فارغ في المصنف في كل حالة:

![مخططات خطية ببيانات متماثلة: الفجوة تقطع الخط في اليوم 3، الصفر يُنزل الخط إلى الصفر، والامتداد يربط اليوم 2 باليوم 4.](display_blanks_as.png)

يعتمد التأثير المرئي على نوع المخطط. يُسهِّل مخطط الخط مقارنة جميع الأوضاع الثلاثة. لا توجد خطوط ربط في مخططات الأعمدة أو القضبان عندما تكون الفئة مفقودة، لذا لا يمكن لـ `Span` إنتاج الجزء المتصل أعلاه؛ كما قد يبدو العمود المفقود وعمود الصفر متشابهين. وبالمثل، لا يُظهر مخطط التناثر مع العلامات فقط خطًا ربطًا. لا تتوقع ثلاث نتائج مميزة لكل نوع مخطط؛ تحقق من المخرجات لنوع المخطط الذي تستخدمه.

## **ضبط عرض الفجوة بين السلاسل**

عرض الفجوة هو المسافة بين مجموعات الأعمدة أو القضبان المتجاورة، تُعبَّر كنسبة مئوية من عرض العمود أو القضيب. مثل التداخل، ينتمي إلى مجموعة السلاسل الأصلية بدلاً من سلسلة واحدة. استدعِ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) مرةً واحدة للمجموعة. القيمة الأكبر تُنشئ مساحة أكبر بين المجموعات؛ والقيمة الأصغر تجعلها أكثر كثافة.

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

![عرض الفجوة](gap_width.png)

## **الأسئلة المتكررة**

**ما أنواع المخططات التي تدعم السلاسل البيانية؟**

جميع أنواع المخططات الممثَّلة في تعداد [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) تستخدم بيانات المخطط، لكن سلاسلها لا تتشارك نفس بنية القيم أو الإعدادات. على سبيل المثال، تستخدم المخططات الفئوية الفئات والقيم، وتستخدم مخططات التناثر قيم X وY، وتضيف مخططات الفقاعات أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتطابق مع نوع السلسلة. تنطبق خيارات مثل التداخل وعرض الفجوة فقط على مجموعات الأعمدة أو القضبان المتوافقة.

**ما هو مجموعة سلاسل المخطط؟**

[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) يُضمّن سلاسل متوافقة تشترك في إعدادات رسم على مستوى المجموعة. يمكن أن يحتوي مخطط مركب على أكثر من مجموعة، لذا فإن تعديل المجموعة التي يتم الوصول إليها عبر سلسلة لا يعني بالضرورة تغيير كل السلاسل في المخطط.

**هل يحتوي المخطط المُنشأ حديثًا على بيانات افتراضية؟**

نعم. بشكل افتراضي، تُنشئ [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addChart) سلاسل وعلاقات وفئات نموذجية. يمكنك تعديل تلك الخلايا أو مسح كل من مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة بالكامل. يمكن أيضًا استدعاء نسخة أخرى لإنشاء مخطط بدون بيانات افتراضية.

**كيف تُربط كائنات المخطط بخلايا المصنف؟**

تشير أسماء السلاسل، وتسميات الفئات، وقيم نقاط البيانات إلى خلايا في [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/). يؤدي تعديل الخلية المشار إليها إلى تحديث العنصر المقابل في المخطط. عند بناء بيانات مخصصة، احرص على محاذاة صفوف الفئات وصفوف قيم السلاسل بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف أمسح نقطة واحدة بدلاً من السلسلة بأكملها؟**

اضبط خلية القيمة ذات الصلة إلى `null` للحفاظ على موضع الفئة كنقطة فارغة. استخدم [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/#clear) فقط عندما تريد إزالة جميع النقاط من تلك السلسلة. إذا أزلت الفئات أيضًا، حدّث كل السلاسل بحيث تظل قيمها متناسقة مع مجموعة الفئات.

**كيف تُعرض النقاط الفارغة؟**

تختلف النتيجة حسب نوع المخطط والإعداد المحدد عبر [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs). يمكن للمخططات المدعومة عرض الفجوات كفراغات، أو كقيم صفرية، أو بربط النقاط المجاورة. اختر الإعداد الذي يعكس معنى البيانات المفقودة في عرضك. راجع [التحكم في عرض الخلايا الفارغة](#control-the-display-of-empty-cells) للحصول على مثال كامل ومقارنة بصرية.

**كيف تُنسق القيم السالبة؟**

بالنسبة للسلاسل المدعومة من الأعمدة، الأعمدة، والفقاعات، استدعِ [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) وعيّن اللون المسترجع عبر [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). يمكن تجاوز السلوك لنقطة فردية باستخدام [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). تؤثر هذه الطرق على التنسيق فقط، ولا تغيّر القيم الرقمية المخزَّنة.

**أي تنسيق ينتصر عندما تُنسق كل من السلسلة والنقطة؟**

أولوية التنسيق الصريح لنقطة البيانات لتلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، إذا لم يُحدَّد تنسيق السلسلة، نمط المخطط والثيم التلقائي. تُسيطر إعدادات المجموعة مثل التداخل وعرض الفجوة على التخطيط ولا تُعدّ تجاوزات تنسيق على مستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها المخطط؟**

لا يفرض Aspose.Slides حدًا ثابتًا منفصلًا لعدد السلاسل. في الواقع، تُحدِّد قيود ملف العرض، الذاكرة المتاحة، وقت التصيير، وقابلية قراءة المخطط حدًا عمليًا.

**ماذا أفعل عندما تكون الأعمدة متقاربة جدًا أو متباعدة جدًا؟**

استدعِ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) على مجموعة السلاسل الأصلية المناسبة. زد القيمة لتوسيع الفجوة بين المجموعات، أو قلّلها لتقريب المجموعات من بعضها.