---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية باستخدام JavaScript
linktitle: سلسلة البيانات
type: docs
url: /ar/nodejs-java/chart-series/
keywords:
- سلسلة مخطط
- تراكب السلسلة
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
description: "تعلم كيفية إدارة سلاسل المخطط، نقاط البيانات، خلايا دفتر العمل، التنسيق، التراكب، عرض الفجوة، والقيم السلبية في العروض التقديمية باستخدام JavaScript."
---
## **نظرة عامة**

يمكن للمخطط تخزين القيم المرسومة إما في خلايا دفتر العمل أو مباشرةً كقواعد عددية. يمثل [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) مجموعة واحدة من القيم المرتبطة، ويُمثل كل [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) نقطةً في تلك السلسلة. توفر كائنات [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) الملصقات أو قيم التجميع المشتركة بين السلاسل. في المخططات التي تُنشأ بالبيانات الافتراضية، تُستخدم كائنات [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) من دفتر عمل المخطط لأسماء السلاسل والفئات وقيم النقاط.

بالنسبة لمخطط فئوي نموذجي، يستخدم دفتر العمل الافتراضي الصف 0 لأسماء السلاسل، العمود 0 لأسماء الفئات، وتُملأ الخلايا المتبقية بقيم السلاسل. فهارس ورقة العمل، الصف، والعمود التي تُمرّر إلى [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) تكون صفرية. هذا التخطيط مفيد عند إنشاء مخطط ببيانات افتراضية، لكن لا تفترض أن كل مخطط موجود يستخدمه. بالنسبة لعروض تقديمية محمّلة، افحص الخلايا التي تُشير إليها السلاسل والفئات ونقاط البيانات قبل تعديل قيم دفتر العمل.

إعدادات المخطط لها ثلاث نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/)، تُوفر المظهر الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات نقطة البيانات، مثل [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/)، تُستبدل مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تُطبق على سلاسل متوافقة تنتمي إلى نفس [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/). يمكنك الوصول إلى المجموعة عبر [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) عندما تحتاج إلى ضبط خيارات مثل التراكب أو عرض الفجوة.

عند عدم تعيين تعبئة صريحة للنقطة أو السلسلة، يحدد نمط المخطط والموضوع المظهر التلقائي. عندما يتوفر كل من تنسيق السلسلة وتنسيق النقطة، يُعطى تنسيق النقطة الأولوية لتلك النقطة.

![سلسلة المخطط في PowerPoint](chart-series-powerpoint.png)

## **تعيين قيم السلسلة باستخدام قواعد عددية**

استخدم القواعد العددية عندما تأتي قيم السلسلة من بيانات التطبيق أو الحسابات ولا تحتاج إلى مراجع خلايا ورقة العمل. استدعِ [setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) مع [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) قبل إسناد نتيجة [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) لكل نقطة عبر [setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/).

يتحكم إعداد المجموعة في نوع مصدر جميع قيم النقاط في تلك السلسلة. تُظهر طريقة [getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/) لكل قيمة نقطة النوع المحدد؛ غيّره عبر إعداد المجموعة. مع `Worksheet`، استخدم [getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/) للوصول إلى الخلية المرجعية. مع `DoubleLiterals`، استخدم [getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/) أو `setAsLiteralDouble` لقراءة أو كتابة العدد مباشرة.

المثال التالي يُنشئ مخطط أعمدة بسلاسل وفئات افتراضية، ثم يُعين قيمًا محسوبة 10، 20، وهكذا إلى النقاط الحالية للسلسلة الأولى. يُحفظ العرض التقديمي، يُعاد فتحه، ويُطبع القيم المخزنة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(aspose.slides.DataSourceType.DoubleLiterals);
    for (let i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("numeric_literals.pptx");
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedChart = reopenedSlide.getShapes().get_Item(0);
    const reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (let i = 0; i < reopenedSeries.getDataPoints().size(); i++) {
        const point = reopenedSeries.getDataPoints().get_Item(i);
        console.log(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

نوع مصدر قيمة النقطة منفصل عن [ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/)، الذي يحدد تكوين دفتر العمل الداخلي أو الخارجي للمخطط. لا يؤدي استخدام القواعد العددية بحد ذاته إلى إزالة دفتر العمل المضمّن. في هذا المثال، يبقى دفتر العمل متاحًا لتسميات الفئات، وأسماء السلاسل، والسلاسل الأخرى. راجع [Chart Workbook](/slides/ar/nodejs-java/chart-workbook/) لإدارة دفتر العمل.

بالنسبة لمخططات التشتت والفقاعات، استخدم [setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) و [setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) لاختيار المصادر لـ [getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/) و [getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/). تستخدم مخططات الفقاعات أيضًا [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) لـ [getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/). عيّن كل مصدر مناسب إلى `DoubleLiterals` قبل إسناد الأرقام عبر طريقة `setAsLiteralDouble` لتلك القيمة.

## **تعيين تراكب سلسلة المخطط**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/) يُظهر مدى تداخل الأعمدة أو القضبان في مخطط ثنائي الأبعاد، من -100 إلى 100 بالمائة. هو إسقاط للقراءة فقط للإعداد على مجموعة السلسلة الأصلية. استخدم [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) لتحديث كل السلاسل المتوافقة في تلك المجموعة. يطبق هذا الخيار على أنواع المخططات التي تعرض قضبان أو أعمدة مُجَمّعة؛ ولا يُؤثر على مجموعات السلاسل غير ذات الصلة في مخطط مركّب.

المثال التالي يُعيّن التراكب للمجموعة التي تحتوي السلسلة الأولى:

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

    // المخطط الجديد يحتوي على سلاسل عينة، فئات، وقيم.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![تراكب السلسلة](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

استخدم [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كان للنقطة تعبئة صريحة، فإن إعداد [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/) يتجاوز تعبئة السلسلة لتلك النقطة.

المثال التالي يطبق تعبئة زرقاء صلبة على السلسلة الأولى:

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

يُخزن اسم السلسلة في دفتر بيانات المخطط وعادةً ما يُعرض في وسيلة الإيضاح. في دفتر العمل الافتراضي المُنشأ لمخطط أعمدة مُجمّع، تكون الخلية B1 في الصف 0، العمود 1 وتحتوي على اسم السلسلة الأولى. تُظهر الثوابت المُسماة في المثال التالي هذا الهيكل بوضوح:

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

يمكنك أيضًا تحديث الخلية التي يُشير إليها [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/). يُجنبك هذا النهج الافتراض بوجود صف وعمود معينين في مخطط موجود:

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

### **إنشاء سلسلة باسم مُستمد من خلايا متعددة**

اسم سلسلة مركّب مفيد عندما يُخزّن اسم المنتج وفترة التقرير في خلايا دفتر عمل منفصلة. على سبيل المثال، يمكنك دمج `Product A` في B1 و `2026` في C1 لتكوين اسم سلسلة واحد مع الحفاظ على ارتباط الجزأين بخلايا المصدر.

استخدم [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/) لاسترداد نطاق الاسم، ثم مرّر ذلك التجميع إلى [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/). يتحكم معامل `skipHiddenCells` فيما إذا كانت الخلايا المخفية تُضمّن: `true` تستثنيها، بينما `false` تُضمّنها. هذا المثال يستخدم `false` لتضمين كل الخلايا في نطاق الاسم.

المثال التالي يُنشئ عرضًا تقديميًا بسلسلة واحدة ونقطتي بيانات. تُوفر الخلايا B1:C1 اسم السلسلة فقط؛ تُوفر A2:A3 تسميات الفئات، وتُوفر B2:B3 القيم العددية.

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

    // هاتان الخليتان توفران اسم السلسلة.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // خلايا منفصلة توفر الفئات ونقاط البيانات الرقمية.
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

![مخطط عمودي بالقيم الشمالية والجنوبية والاسم المركب للسلسلة Product A 2026 في وسيلة الإيضاح](composite_series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/) يُعيد اللون المُحسب من فهرس السلسلة ونمط المخطط. هذا هو اللون المستخدم عندما لا يتم تعريف تعبئة السلسلة صراحة. تُقرأ الطريقة اللون المُحسب؛ ولا تُعيّن تعبئة جديدة.

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

إخراج المثال لنمط المخطط الافتراضي:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

الألوان الدقيقة تعتمد على نمط المخطط والموضوع.

## **تعيين لون تعبئة معكوس لسلسلة المخطط**

بالنسبة لسلاسل الأعمدة والقضبان والفقاعات، يمكن لـ [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) عرض القيم السالبة بتعبئة مختلفة. عيّن تعبئة السلسلة العادية إلى صلبة، فعل الانعكاس، وعين لون القيم السالبة عبر [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). تظل الأعداد السالبة غير معدلة في دفتر العمل؛ يتغيّر فقط لون عرضها.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. يحتوي صف ورقة العمل 0 على اسم السلسلة، والعمود 0 على أسماء الفئات، والعمود 1 على القيم:

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

يمكنك تفعيل الانعكاس لنقطة واحدة عبر [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). في المثال التالي يُعطل الانعكاس للسلسلة ويُفعّل فقط للنقطة المختارة. تُعطى النقطة أيضًا قيمة سالبة لتظهر التأثير:

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

لجعل نقطة واحدة فارغة دون إزالة النقاط الأخرى، عيّن خلية دفتر العمل الداعمة لها إلى `null`. في مخطط عمودي، تكون القيمة المرسومة متوفرة عبر [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/). تظل نقطة البيانات في نفس موضع الفئة، لكن المخطط يعامل قيمتها كفراغ وفقًا لإعدادات القيم الفارغة في المخطط.

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

تستخدم مخططات التشتت خلايا X وY منفصلة، وتستخدم مخططات الفقاعات أيضًا خلية حجم. امسح فقط الخلية التي تمثّل القيمة التي تنوي إزالتها. لا تستدعِ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) عندما تريد الإبقاء على النقاط الأخرى، لأن هذه الطريقة تُزيل كل نقاط البيانات من التجميع.

## **التحكم في عرض الخلايا الفارغة**

الخلايا المخفية التي تحتوي على قيم هي حالة منفصلة عن الخلايا الفارغة. لتضمين أو استبعاد البيانات من صفوف وأعمدة ورقة العمل المخفية، راجع [Include Data from Hidden Rows and Columns](/slides/ar/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

تمثل خلية دفتر العمل الفارغة بيانات مفقودة؛ خلية تحتوي على `0` تمثل قيمة عددية معروفة. استدعِ [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/) مع `null` لجعل الخلية فارغة. الصفر الرقمي يظل صفرًا بغض النظر عن إعداد الخلية الفارغة.

استخدم [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) لاختيار كيفية عرض المخطط للخلايا الفارغة. يُطبق هذا الإعداد على المخطط بأكمله. إنه يغيّر كيفية رسم الفراغات دون ملء الخلية الفارغة بالصفر أو بقيمة مُق interpolated.

المثال التالي المستقل يُنشئ مخطط خط مع سلسلة واحدة، يمسح القيمة للـ Day 3، ويحفظ المخطط نفسه بكل وضع. لا يلزم ملف إدخال. يستخدم [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) ورقة العمل 0، العمود 0 لتسميات الفئات، والعمود 1 للقيم؛ الصف 0 يحمل اسم السلسلة. البيانات النهائية هي `10، 20، فارغ، 30، 40`.

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

    // اترك اليوم 3 فارغًا حقًا، مع الاحتفاظ بفئته ونقطة بياناته.
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

كل ملف إخراج يُخزن الوضع المُعيّن قبل الحفظ: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx`، و `empty_cells_Span.pptx`. لحفظ نسخة واحدة فقط، عيّن الوضع المطلوب واحفظ العرض التقديمي مرة واحدة بدلاً من التكرار على الأوضاع.

المقارنة أدناه تُظهر نفس البيانات في جميع الملفات الثلاثة. يكون الـ Day 3 فارغًا في دفتر العمل في كل حالة:

![مخططات خط ببيانات متطابقة: Gap يُكسر الخط عند Day 3، Zero يُخفض الخط إلى الصفر، و Span يربط Day 2 بـ Day 4.](display_blanks_as.png)

التأثير المرئي يعتمد على نوع المخطط. يجعل مخطط الخط جميع الأوضاع الثلاثة سهلة المقارنة. لا تمتلك مخططات الأعمدة والبار خطوطًا لتوصيل الفجوات، لذا لا يمكن لـ `Span` إنتاج المقطع المتصل كما في الأعلى؛ قد يبدو العمود المفقود والعمود صفر الارتفاع متشابهين. بالمثل، لا يُظهر مخطط التشتت ذات العلامات خطًا موصولًا. لا تتوقع ثلاث نتائج متميزة لكل نوع مخطط؛ تحقق من النتيجة للنوع الذي تستخدمه.

## **تعيين عرض الفجوة بين السلاسل**

عرض الفجوة هو المسافة بين مجموعات الأعمدة أو القضبان المتجاورة، معبرًا عنها كنسبة مئوية من عرض العمود أو القضيب. مثل التراكب، ينتمي إلى مجموعة السلسلة الأصلية وليس إلى سلسلة واحدة. استدعِ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) مرة واحدة للمجموعة. قيمة أكبر تُنشئ مساحة أكبر بين المجموعات؛ قيمة أصغر تجعلها أكثر كثافة.

المثال التالي يُغيّر عرض الفجوة ويحفظ العرض التقديمي النهائي فقط:

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

**ما أنواع المخططات التي تدعم سلاسل البيانات؟**

جميع أنواع المخططات الممثلة في تعداد [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) تستخدم بيانات المخطط، لكن سلاسلها لا تشترك جميعًا في نفس بنية القيم أو الإعدادات. على سبيل المثال، تُستخدم المخططات الفئوية الفئات والقيم، وتُستخدم مخططات التشتت قيم X وY، وتضيف مخططات الفقاعات أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتطابق مع نوع السلسلة. تنطبق خيارات مثل التراكب وعرض الفجوة فقط على مجموعات الأعمدة أو القضبان المتوافقة.

**ما هي مجموعة سلاسل المخطط؟**

[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) يحتوي على سلاسل متوافقة تشترك في إعدادات رسم على مستوى المجموعة. يمكن لمخطط مركّب أن يحتوي على أكثر من مجموعة، لذا تغيير المجموعة من خلال سلسلة لا يعني بالضرورة تغيير كل السلاسل في المخطط.

**هل يحتوي المخطط المُنشأ حديثًا على بيانات افتراضية؟**

نعم. بشكلٍ افتراضي، يُنشئ [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) سلاسل، فئات، وقيم تجريبية. يمكنك تعديل تلك الخلايا أو مسح مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة تمامًا. يمكن أيضًا لعملية تحميل بديلة إنشاء مخطط بدون بيانات افتراضية.

**كيف يتم ربط كائنات المخطط بخلايا دفتر العمل؟**

تُشير أسماء السلاسل، تسميات الفئات، وقيم نقاط البيانات إلى خلايا في [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/). تعديل خلية مُشار إليها يُحدّث العنصر المقابل في المخطط. عند بناء بيانات مخصصة، احرص على محاذاة صفوف الفئات وصفوف قيم السلاسل بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف أقوم بمسح نقطة واحدة بدلاً من السلسلة بأكملها؟**

عيّن الخلية ذات القيمة ذات الصلة إلى `null` للحفاظ على موضع الفئة للنقطة كنقطة فارغة. استخدم [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) فقط عندما ترغب في إزالة جميع النقاط من تلك السلسلة. إذا أزلت الفئات أيضًا، حدّث كل السلاسل بحيث تظل قيمها محاذية لمجموعة الفئات.

**كيف تُعرض النقاط الفارغة؟**

تعتمد النتيجة على نوع المخطط والقيمة المُضبوطة عبر [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/). يمكن للمخططات المدعومة عرض الفراغات كفجوات، كقيمة صفرية، أو بربط النقاط المتجاورة. اختر الإعداد الذي يتماشى مع معنى البيانات المفقودة في عرضك التقديمي. راجع [Control the Display of Empty Cells](#control-the-display-of-empty-cells) للحصول على مثال كامل ومقارنة بصرية.

**كيف يُنسَق القيم السالبة؟**

بالنسبة للسلاسل المدعومة من نوع العمود أو الشريحة أو الفقاعة، استدعِ [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) وعين اللون المسترجع من [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). يمكنك تجاوز السلوك لنقطة فردية عبر [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). تؤثر هذه الأساليب على التنسيق فقط، ولا تغير القيم الرقمية المخزنة.

**أي تنسيق ينتصر عندما يتم تنسيق كلّ من السلسلة والنقطة؟**

يأخذ تنسيق نقطة البيانات الصريح الأولوية لتلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، إذا لم يُحدَّد تنسيق السلسلة، نمط المخطط والموضوع التلقائي. تتحكم إعدادات المجموعة مثل التراكب وعرض الفجوة في التخطيط ولا تُعتَبر تجاوزات تنسيق على مستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها المخطط؟**

لا يفرض Aspose.Slides حدًا ثابتًا منفصلًا لعدد السلاسل. في الممارسة العملية، تحدد قيود ملف العرض التقديمي، الذاكرة المتاحة، زمن المعالجة، وقابلية قراءة المخطط حدًا عمليًا.

**ماذا أفعل إذا كانت الأعمدة متقاربة جدًا أو متباعدة جدًا؟**

استدعِ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) على مجموعة السلسلة الأصلية المناسبة. زد القيمة لتوسيع المسافة بين المجموعات، أو قلِّلها لتقريبها.