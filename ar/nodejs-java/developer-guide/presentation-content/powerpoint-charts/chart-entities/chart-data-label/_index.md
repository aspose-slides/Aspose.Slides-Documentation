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
- موقع التسمية
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية إضافة وتنسيق تسميات بيانات المخطط في عروض PowerPoint التقديمية باستخدام JavaScript و Aspose.Slides لـ Node.js عبر Java للحصول على شرائح أكثر جاذبية."
---
## **المقدمة**

تظهر تسميات البيانات معلومات حول سلاسل المخطط والنقاط الفردية، مما يساعد القراء على التعرف على القيم وفهم المخطط. يشرح هذا المقال كيفية تنسيق القيم، وعرض النسب المئوية، وقراءة نص التسمية، والتحكم في التسميات خارج الحد الأقصى للمحور، وضبط تباعد تسميات محور الفئة، وتحديد موقع تسميات المخطط الدائري.

## **تحديد دقة البيانات في تسميات بيانات المخطط**

استخدم [setNumberFormatOfValues](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) لتنسيق قيم السلسلة. يوضح هذا المثال إنشاء مخطط خطي ببيانات افتراضية، وعرض جدول البيانات الخاص به، وتمكين تسميات القيم للسلسلة الأولى. التنسيق `#,##0.00` يعرض فاصل الآلاف ومكانين عشريين دون تغيير القيم الأساسية.

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

## **عرض النسبة المئوية كتصنيفات**

بالنسبة لمخطط الأعمدة المتراكم، احسب كل قيمة كنسبة مئوية من إجمالي الفئة الخاصة بها وعيّن النص إلى إطار النص الذي تُرجعه [getTextFrameForOverriding](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/). يستخدم هذا المثال بيانات المخطط الافتراضية ويعرض النسب المئوية بمكانين عشريين بحجم خط 8 نقاط. يتم تخطي الفئات التي يكون مجموعها صفر لتجنب القسمة على الصفر. أعد حساب نص التسمية المخصَّص إذا تغيرت بيانات المخطط.

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

## **تعيين علامة النسبة المئوية في تسميات بيانات المخطط**

عندما تُخزن القيم ككسرات، استخدم [setNumberFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) لعرض النسب المئوية. مرّر `false` إلى [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) لتطبيق تنسيق التسمية بشكل مستقل عن الخلايا المصدر.

ينشئ هذا المثال مخطط أعمدة متراكم بنسبة 100% مع سلسلتين حمراء وزرقاء عبر أربع فئات. كل زوج من القيم يساوي 1. يعرض تنسيق التسمية `0.0%` القيمة 0.30 كـ 30.0%، بينما يستخدم المحور العمودي مكانين عشريين. تستخدم كلتا السلسلتين نص تسمية أبيض بحجم 10 نقاط.

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

استخدم [getActualLabelText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) لاسترجاع النص الذي تنتجه إعدادات تسمية البيانات. يكون ذلك مفيدًا عند استخراج التسميات للتقارير، أو البحث في محتوى العرض التقديمي، أو التحقق من صحة المخططات المُولَّدة. في المثال أدناه، يجمع تنسيق [تسمية البيانات الافتراضي](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datalabelformat/) كل من اسم الفئة، واسم السلسلة، والقيمة. يقوم أحد النقاط بتنسيق قيمته كنسبة مئوية، وآخر يستخدم نصًا مخصَّصًا من [getTextFrameForOverriding](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/).

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

يبقى الرقم المخزن في نقطة البيانات هو `0.75`، حتى عندما تُظهر التسمية `75%` مع أسماء الفئة والسلسلة. النص المخصَّص يحلّ محل النص المُولَّد للتسمية. تُعيد [getActualLabelText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) سلسلة التسمية الناتجة في كلتا الحالتين. تحقق من [isVisible](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datalabel/isvisible/) بشكل منفصل، كما هو موضح أعلاه، عندما تريد استخراج التسميات الظاهرة فقط.

## **التحكم في تسميات البيانات خارج الحد الأقصى للمحور**

عند تحديد نطاق المحور يدويًا، قد تتجاوز بعض نقاط البيانات الحد الأقصى له. استخدم [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) للتحكم فيما إذا كانت تسميات البيانات الخاصة بها تُظهر أم لا. هذا الإعداد يغيّر رؤية التسمية؛ ولا يغيّر نطاق المحور أو قيم البيانات الأساسية.

ينشئ المثال أدناه مخطط أعمدة متجمع ثنائي الأبعاد بقيم 60 و120. يمرّر `false` إلى [setAutomaticMaxValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) ويضبط الحد الأقصى إلى 100 باستخدام [setMaxValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/axis/setmaxvalue/) على المحور العمودي. الشريحة الأولى تسمح بالتسميات التي تتجاوز الحد الأقصى؛ نسخة من هذه الشريحة تعطلها. تُحفظ كلتا الشريحتين في الملف `DataLabelsOverMaximum.pptx`.

فعِّل تسميات القيم باستخدام [setShowValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datalabelformat/setshowvalue/). لا يفعّل إعداد مستوى المخطط عرض القيم بحد ذاته ولا يتجاوز إلغاء عرض القيم لتسمية فردية. يُفعّل هذا المثال القيم للسلسلة بأكملها ويستخدم [setPosition](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datalabelformat/setposition/) لوضع التسميات عند الطرف الخارجي لكل عمود.

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

تُظهر الصور التالية الشرائح المحفوظة التي تم عرضها بواسطة Microsoft PowerPoint. مع `true`، تكون التسمية **120** مرئية عند الحد الأعلى؛ ومع `false`، تكون مخفية. تظل التسمية **60** مرئية، ويبقى الحد الأقصى للمحور عند **100**، وتبقى نقطة البيانات الثانية **120** في الحالتين.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
يستخدم هذا المثال مخطط أعمدة ثنائي الأبعاد مع محور قيم. المخططات التي لا تحتوي على محور قيم، مثل المخططات الدائرية ومخططات الفطيرة، لا تملك حدًا أقصى للمحور لتقييده بهذه الطريقة.
{{% /alert %}}

## **تحديد مسافة التسمية من المحور**

استخدم [setLabelOffset](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/axis/setlabeloffset/) للتحكم في المسافة بين تسميات محور الفئة والمحور. القيمة هي نسبة مئوية من أقصى حجم خط لتسميات المحور. يخلق هذا المثال مخطط أعمدة متجمع ويضبط إزاحة تسمية المحور الأفقي إلى 500. يؤثر هذا الإعداد على تسميات محور الفئة بدلاً من التسميات المرفقة بنقاط البيانات الفردية.

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

## **ضبط موقع التسمية**

في مخطط دائري، اضبط مواضع تسميات البيانات لتحسين التباعد وإفساح المجال لخطوط الربط.

يعرض هذا المثال قيمة أول نقطة بيانات، يضع تسميتها خارج القطاع، ويضبط إزاحتها الأفقية والعمودية باستخدام [setX](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datalabel/setx/) و[setY](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datalabel/sety/). هذه الإزاحات نسبية لعرض وارتفاع المخطط على التوالي.

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

![مخطط دائري مع موضع تسمية بيانات مُعدَّل](pie-chart-adjusted-label.png)

## **الأسئلة المتداولة**

**كيف يمكنني منع تراكب تسميات البيانات في المخططات المكتنسة؟**

استخدم وضع التسمية التلقائي، وخطوط الربط، وتصغير حجم الخط؛ وإذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو اعرض التسميات فقط للقيم المتطرفة أو النقاط الرئيسية.

**كيف يمكنني تعطيل التسميات فقط للقيم الصفرية أو السلبية أو الفارغة؟**

قم بترشيح نقاط البيانات قبل تمكين التسميات وأوقف العرض للقيم التي تساوي 0 أو القيم السلبية أو القيم المفقودة وفقًا لقاعدة محددة.

**كيف يمكنني ضمان نمط تسمية متسق عند التصدير إلى PDF/صور؟**

حدد عائلة الخط وحجمه صراحةً وتأكد من توفر الخط في بيئة العرض لتجنب الاستخدام الافتراضي.