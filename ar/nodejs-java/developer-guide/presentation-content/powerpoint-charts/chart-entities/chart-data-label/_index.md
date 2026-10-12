---
title: إدارة تسميات بيانات المخطط في العروض التقديمية باستخدام JavaScript
linktitle: تسمية البيانات
type: docs
url: /ar/nodejs-java/chart-data-label/
keywords:
- مخطط
- تسمية البيانات
- دقة البيانات
- نسبة مئوية
- مسافة التسمية
- موضع التسمية
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية إضافة وتنسيق تسميات بيانات المخطط في عروض PowerPoint التقديمية باستخدام JavaScript و Aspose.Slides لـ Node.js عبر Java للحصول على شرائح أكثر جاذبية."
---
## **مقدمة**

تُظهر تسميات البيانات معلومات حول سلاسل المخطط ونقاط البيانات الفردية، مما يساعد القارئ على التعرف على القيم وفهم المخطط. يشرح هذا المقال كيفية تنسيق القيم، وعرض النسب المئوية، وقراءة نص التسمية، والتحكم في التسميات خارج الحد الأقصى للمحور، وضبط تباعد تسميات محور الفئات، وتحديد موضع تسميات المخطط الدائري.

## **تحديد دقة البيانات في تسميات بيانات المخطط**

استخدم [setNumberFormatOfValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) لتنسيق قيم السلسلة. يُنشئ هذا المثال مخططًا خطيًا بالبيانات الافتراضية، يعرض جدول البيانات الخاص به، ويفعل تسميات القيم للسلسلة الأولى. التنسيق `#,##0.00` يُظهر فاصل آلاف ومكانين عشريين دون تغيير القيم الأساسية.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    const series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **عرض النسبة المئوية كعناوين**

في مخطط عمودي مكدس، احسب كل قيمة كنسبة مئوية من إجمالي الفئة الخاصة بها وعيّن النص إلى إطار النص الذي تُعيده الدالة [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/). يستخدم هذا المثال بيانات المخطط الافتراضية ويعرض النسب المئوية بمكانين عشريين بخط بحجم 8 نقاط. تُتخطى الفئات التي مجموعها صفر لتجنب القسمة على صفر. أعد حساب نص التسمية المخصص إذا تغيرت بيانات المخطط.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);

    const categoryTotals = new Array(chart.getChartData().getCategories().size()).fill(0);
    for (let k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
            const series = chart.getChartData().getSeries().get_Item(i);
            const pointValue = series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += Number(pointValue);
        }
    }

    for (let x = 0; x < chart.getChartData().getSeries().size(); x++) {
        const series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            const pointValue = series.getDataPoints().get_Item(j).getValue().getData();
            const dataPointPercent = (Number(pointValue) / categoryTotals[j]) * 100;

            const portion = new aspose.slides.Portion();
            portion.setText(dataPointPercent.toFixed(2) + " %");
            portion.getPortionFormat().setFontHeight(8);

            label.getTextFrameForOverriding().setText("");
            const paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **تعيين علامة النسبة المئوية مع تسميات بيانات المخطط**

عند تخزين القيم ككسور، استخدم [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) لعرض النسب المئوية. مرّر `false` إلى [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) لتطبيق تنسيق التسمية بشكل مستقل عن خلايا المصدر.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    for (let i = 0; i < 4; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    const seriesNames = ["Reds", "Blues"];
    const white = java.getStaticFieldValue("java.awt.Color", "WHITE");
    const seriesColors = [java.getStaticFieldValue("java.awt.Color", "RED"), java.getStaticFieldValue("java.awt.Color", "BLUE")];
    const values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]];

    for (let i = 0; i < seriesNames.length; i++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (let j = 0; j < 4; j++) {
            const valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        const labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(white);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **قراءة النص الفعلي لتسميات البيانات**

استخدم [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) لاسترجاع النص الناتج عن إعدادات تسمية البيانات. يكون هذا مفيدًا عند استخراج التسميات للتقارير، أو البحث في محتوى العرض التقديمي، أو التحقق من صحة المخططات المُولدة. في المثال أدناه، يجمع تنسيق [تسمية البيانات الافتراضية](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/) بين اسم كل فئة، اسم السلسلة، والقيمة. تنسق نقطة واحدة قيمتها كنسبة مئوية، وأخرى تستخدم نصًا مخصصًا من [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    const secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    const northSeriesCell = workbook.getCell(0, 0, 1, "North");
    const north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    const northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    const northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    const southSeriesCell = workbook.getCell(0, 0, 2, "South");
    const south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    const southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    const southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        const format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const point = series.getDataPoints().get_Item(j);
            const label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            console.log("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

الرقم المخزن في نقطة البيانات يظل `0.75`، حتى عندما تُظهر تسميتها `75%` مع أسماء الفئة والسلسلة. النص المخصص يحل محل النص المُولد للتسمية. تُعيد [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) سلسلة التسمية الناتجة في كلتا الحالتين. راجع [isVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/isvisible/) بشكل منفصل، كما هو موضح أعلاه، عندما تريد استخراج التسميات المرئية فقط.

## **التحكم في تسميات البيانات خارج الحد الأقصى للمحور**

عند تحديد نطاق المحور يدويًا، قد تتجاوز بعض نقاط البيانات الحد الأقصى. استخدم [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) للتحكم في ما إذا كانت تُظهر تسميات البيانات تلك. لا تُغيّر هذه الإعدادات من مرئية التسمية؛ بل لا تُغيّر نطاق المحور أو القيم الأساسية.

المثال أدناه يُنشئ مخططًا عموديًا مُكّ clustered بأعمدة قيمها 60 و120. يمرّر `false` إلى [setAutomaticMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) ويضبط الحد الأقصى إلى 100 باستخدام [setMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmaxvalue/) على المحور الرأسي. الشريحة الأولى تسمح بالتسميات خارج الحد الأقصى؛ نسخة من تلك الشريحة تُعطلها. تُحفظ كلا الشريحتين في `DataLabelsOverMaximum.pptx`.

فعّل تسميات القيم باستخدام [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/). لا يفعّل الإعداد على مستوى المخطط عرض القيم بحد ذاته ولا يتجاوز إعداد إلغاء تمكين عرض القيمة لتسمية فردية. يُفعّل هذا المثال القيم لكامل السلسلة ويستخدم [setPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setposition/) لوضع التسميات في النهاية الخارجية لكل عمود.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();

    const firstCategory = workbook.getCell(0, 1, 0, "Within range");
    const secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    const seriesName = workbook.getCell(0, 0, 1, "Values");
    const series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    const firstValue = workbook.getCell(0, 1, 1, 60);
    const secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    const secondSlide = presentation.getSlides().addClone(slide);
    const secondChart = secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الصورة التالية تُظهر الشرائح المحفوظة التي عُرضت في Microsoft PowerPoint. مع `true`، تكون التسمية **120** مرئية عند الحد العلوي؛ مع `false`، تُخفى. تظل التسمية **60** مرئية، يبقى الحد الأقصى للمحور **100**، وتظل نقطة البيانات الثانية **120** في الحالتين.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![مخطط PowerPoint يُظهر تسمية القيمة 120 مع حد أقصى للمحور يبلغ 100](data-labels-over-maximum-true.png) | ![مخطط PowerPoint يخفي تسمية القيمة 120 مع حد أقصى للمحور يبلغ 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
هذا المثال يستخدم مخططًا عموديًا ثنائي الأبعاد مع محور قيم. المخططات التي لا تملك محور قيم، مثل المخططات الدائرية ومخططات الدونات، لا تملك حدًا أقصى للمحور يمكن تقييده بهذه الطريقة.
{{% /alert %}}

## **تعيين مسافة التسمية من المحور**

استخدم [setLabelOffset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlabeloffset/) للتحكم في المسافة بين تسميات محور الفئات والمحور. القيمة هي نسبة مئوية من أقصى حجم خط لتسميات المحور. يُنشئ هذا المثال مخططًا عموديًا مُجتمعًا ويضبط إزاحة تسمية المحور الأفقي إلى 500. تؤثر هذه الإعدادات على تسميات محور الفئات بدلاً من التسميات المرتبطة بنقاط البيانات الفردية.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **ضبط موضع التسمية**

في مخطط دائري، اضبط مواضع تسميات البيانات لتحسين التباعد وإتاحة مساحة لخطوط الربط.

يُظهر هذا المثال قيمة نقطة البيانات الأولى، يضع تسميتها خارج الشريحة، ويضبط الإزاحات الأفقية والرأسية باستخدام [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) و [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/). هذه الإزاحات نسبية إلى عرض وارتفاع المخطط على التوالي.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    const series = chart.getChartData().getSeries();

    const label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(java.newFloat(0.71));
    label.setY(java.newFloat(0.04));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![مخطط دائري مع ضبط موضع تسمية البيانات](pie-chart-adjusted-label.png)

## **إضافة عدة صفوف من تسميات البيانات فوق مخطط عمودي**

يُنشئ هذا المثال مخططًا عموديًا بصفين من تسميات البيانات فوق منطقة الرسم. تُظهر السلسلة A الأعمدة المرئية، بينما تُوفر السلسلة B والسلسلة C التسميات الإضافية. تُخفى أعمدتها بإزالة التعبئة والحد. تُحاذي طريقة [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) بين الثلاث سلاسل معًا في مراكز الفئات نفسها.

تُخصص إعدادات [ChartPlotArea](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartplotarea/) مساحة لصفوف التسميات. بعد أن يحسب [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) المواقع الافتراضية، تُحافظ [DataLabel.setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) و [DataLabel.setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) على محاذاة أفقية وتطبق إزاحات رأسية لترتيب التسميات في صفين. لا تزال الأرقام تسميات بيانات مرتبطة بقيم السلسلة؛ فقط عناوين الصفوف هي أشكال نصية منفصلة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categories = ["North", "South", "East", "West"];
    const seriesNames = ["Series A", "Series B", "Series C"];
    const seriesValues = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]];

    for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        const categoryCell = workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        const seriesCell = workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
        const series = chart.getChartData().getSeries().add(seriesCell, aspose.slides.ChartType.ClusteredColumn);

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const valueCell = workbook.getCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        if (seriesIndex > 0) {
            // إخفاء أعمدة B و C، ولكن الإبقاء على تسميات البيانات الخاصة بهما.
            series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
            const labelFill = series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
            labelFill.getSolidFillColor().setColor(black);
            series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.InsideBase);
        }
    }

    // محاذاة السلاسل الثلاثة جميعًا إلى مراكز الفئات نفسها.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(java.newByte(100));

    // استخدام خطوط شبكة أقل لهذا المثال المدمج.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // حجز مساحة فوق منطقة الرسم لصفين من تسميات البيانات.
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    chart.getPlotArea().setX(java.newFloat(0.15));
    chart.getPlotArea().setY(java.newFloat(0.32));
    chart.getPlotArea().setWidth(java.newFloat(0.80));
    chart.getPlotArea().setHeight(java.newFloat(0.48));
    chart.validateChartLayout();

    for (let seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const rowTop = seriesIndex == 1 ? 0.15 : 0.03;

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // الاحتفاظ بالموقع الأفقي الافتراضي. Y هو إزاحة من
            // موضع التسمية الافتراضي، معبرًا عنه ككسر من ارتفاع المخطط.
            dataLabel.setX(0);
            dataLabel.setY(java.newFloat(rowTop - dataLabel.getActualY() / chart.getHeight()));
        }

        // العنوان الصفّي هو شكل نصي منفصل فقط.
        const rowHeading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, chart.getX(), chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        const headingFormat = rowHeading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        headingFormat.getFillFormat().getSolidFillColor().setColor(black);
    }

    presentation.save("multiple-rows-of-labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![مخطط عمودي بصفين من تسميات البيانات فوق منطقة الرسم](multiple-rows-of-labels.png)

## **الأسئلة الشائعة**

**كيف يمكنني منع تداخل تسميات البيانات في المخططات المكتظة؟**  
اجمع بين وضع التسميات التلقائي، وخطوط الربط، وتقليل حجم الخط؛ إذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو أظهر التسميات فقط للقيم المتطرفة أو النقاط الرئيسية.

**كيف يمكنني تعطيل التسميات فقط للقيم الصفرية أو السالبة أو الفارغة؟**  
قم بفلترة نقاط البيانات قبل تمكين التسميات وأوقف العرض للقيم التي تساوي 0، أو القيم السالبة، أو القيم المفقودة وفق قاعدة محددة.

**كيف أضمن أسلوب تسمية موحد عند التصدير إلى PDF/صور؟**  
حدِّد صراحةً عائلة الخط وحجمه وتحقق من توفر الخط في بيئة العرض لتجنب الاعتماد على الخط البديل.