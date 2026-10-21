---
title: إدارة دفاتر عمل المخططات في العروض التقديمية باستخدام JavaScript
linktitle: دفتر عمل المخطط
type: docs
weight: 70
url: /ar/nodejs-java/chart-workbook/
keywords:
- دفتر عمل المخطط
- بيانات المخطط
- خلية دفتر العمل
- علامة البيانات
- ورقة العمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- مخزن مؤقت للمخطط
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "اكتشف Aspose.Slides لـ Node.js عبر Java: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint وOpenDocument لتبسيط بيانات عروضك التقديمية."
---
## **نظرة عامة**

هذه المقالة تشرح كيفية العمل مع دفاتر عمل المخططات في Aspose.Slides. تُظهر كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعناوين بيانات للمخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر عمل خارجية كمصادر بيانات للمخططات. توضح الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، واسترداد مسار دفتر عمل خارجي مرتبط بمخطط، وتعديل بيانات المخطط عندما يكون دفتر العمل متاحًا.

للخلايا التي تمثل بيانات مفقودة، راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/nodejs-java/chart-series/) لمعرفة الفارق بين الخلية الفارغة والصفر، ومقارنة مخطط خطي لأوضاع العرض المتاحة.

## **تضمين البيانات من الصفوف والأعمدة المخفية**

استخدم [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) للتحكم فيما إذا كان المخطط يرسم البيانات من صفوف وأعمدة ورقة العمل المخفية. اضبطه إلى `true` لرسم الخلايا الظاهرة فقط، أو إلى `false` لتضمين كل من الخلايا الظاهرة والمخفية. هذا الإعداد يتحكم في رسم المخطط؛ ولا يقوم بإخفاء أو إظهار صفوف أو أعمدة ورقة العمل.

العرض التقديمي [sample presentation](hidden-source-data.pptx) يحتوي على مخطط عمودي كأول شكل في شريحته الأولى. ورقة العمل المضمنة، `Sheet1`، تحتوي على النطاق المصدر التالي، `A1:C4`. الصف 3 والعمود C مخفيان، لكن خلاياهما لا تزال تحتوي على قيم.

| صف ورقة العمل | A: الشهر | B: التجزئة | C: الجملة (عمود مخفي) |
| --- | --- | --- | --- |
| 2 | يناير | 10 | 30 |
| 3 (صف مخفي) | فبراير | 40 | 60 |
| 4 | مارس | 20 | 50 |

الوصول إلى الخلايا المصدرية عبر [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) وقراءة [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) لتفقد حالة الإخفاء. تُعيد هذه الطريقة حالة الإخفاء دون تعديلها. في هذا الملف، B2 ظاهرة، B3 تنتمي إلى الصف المخفي، وC2 تنتمي إلى العمود المخفي؛ الأمثلة تطبع `false`، `true`، و`true` على التوالي.

في هذا المثال، حدّث بيانات المخطط بعد تغيير إعداد الرسم: احتفظ بدفتر العمل المضمن باستخدام [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) وأعد تحميله باستخدام [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/). عند تضمين كل الخلايا، استخدم أيضًا [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) لاستعادة النطاق الكامل، بما في ذلك فئة فبراير المخفية. مجرد تغيير العلم غير كافٍ لتحديث بيانات المخطط المخزنة مؤقتًا وعناوين الفئات في هذا المثال. يقوم المثال بتحويل المخزن المؤقت Node.js إلى مصفوفة بايت Java قبل تمريره إلى طريقة الكتابة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // تحديث بيانات المخطط من دفتر العمل المضمّن.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // استعادة النطاق المصدر الكامل، بما في ذلك الفئات المخفية.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

يحفظ المثال إصدارين من العرض التقديمي: أحدهما يحتوي فقط على قيم التجزئة الظاهرة (10 و 20)، وآخر يحتوي على جميع القيم الستة. الصور أدناه توضح وضعية الرسمين. الصف 3 والعمود C يظلان مخفيين في كلا دفترَي العمل المضمنين.

| الخلايا الظاهرة فقط (`true`) | كل الخلايا (`false`) |
| --- | --- |
| ![الخلايا الظاهرة فقط: قيم التجزئة 10 و 20 لشهري يناير ومارس.](hidden_cells_True.png) | ![كل الخلايا: قيم التجزئة والجملة لشهري يناير وفبراير ومارس.](hidden_cells_False.png) |

الخلية المخفية التي تحتوي على قيمة تختلف عن الخلية الفارغة. يتحكم [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) في كيفية عرض القيم المفقودة؛ ولا يتضمن أو يستثني البيانات المصدرية المخفية. راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/nodejs-java/chart-series/#control-the-display-of-empty-cells) لمثال.

## **استرجاع نطاق بيانات المخطط**

قبل تحديث بيانات دفتر العمل في عرض تقديمي موجود، افحص النطاقات المصدرية لتحديد خلايا ورقة العمل التي يستخدمها كل مخطط. تُعيد طريقة [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) النطاق الحالي للبيانات كصيغة مؤهلة لورقة العمل، مثل `Sheet1!$A$1:$D$5`. هنا، `Sheet1` هو اسم ورقة العمل، و`!` يفصلها عن نطاق الخلايا، و`$A$1:$D$5` يحدد الخلايا من A1 إلى D5 شاملًا. تشير علامات الدولار إلى مراجع صف وعمود ثابتة.

تقرأ الطريقة النطاق الحالي دون تغيير المخطط أو دفتر العمل الخاص به. إذا لم يستخدم المخطط دفتر عمل كمصدر للبيانات، فإنها تُطلق استثناء `InvalidOperationException`. للمزيد من المعلومات، راجع [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/).

يفتح هذا المثال عرضًا تقديميًا ويتحقق من الأشكال مباشرةً على كل شريحة للبحث عن المخططات. يطبع اسم كل مخطط والنطاق المصدر. إذا لم يستخدم مخطط دفتر عمل، يطبع رسالة ويستمر إلى المخطط التالي.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                const chart = shape;
                try {
                    const range = chart.getChartData().getRange();
                    console.log(chart.getName() + ": " + range);
                } catch (exception) {
                    if (exception.cause && java.instanceOf(exception.cause, "com.aspose.slides.exceptions.InvalidOperationException")) {
                        console.log(chart.getName() + ": The chart does not use a workbook as its data source.");
                    } else {
                        console.log(chart.getName() + ": Could not retrieve the data range: " + exception.message);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **قراءة وكتابة بيانات المخطط من دفتر العمل**

توفر Aspose.Slides for Node.js عبر Java الطريقةين [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) و[writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) اللتين تسمحان لك بقراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات مخطط تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تكون منظمة بنفس الطريقة أو أن تكون ذات بنية مشابهة للمصدر.

يستخدم هذا المثال عرضًا تقديميًا يحتوي على مخطط كأول شكل في شريحته الأولى. يقرأ دفتر العمل المضمن إلى مصفوفة بايت، يمسح السلسلة والفئات الحالية، ثم يكتب نفس دفتر العمل مرة أخرى. تظل التغييرات في الذاكرة؛ لا يحفظ المثال العرض التقديمي.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **تحقق من تخطيط المخطط بعد تعديل دفتر العمل**

عند استبدال دفتر عمل مضمّن بآخر معدل، يحتفظ المخطط بالسلسلة ومجموعات الفئات الأصلية. قد يتسبب هذا الاختلاف في فشل [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) مع خطأ “index-out-of-range”. امسح السلسلة والفئات الحالية قبل كتابة دفتر العمل المحدّث إلى المخطط. يستخدم هذا المثال مخططًا هو الشكل الأول في الشريحة الأولى. العلامة التعليقية تحدد مكان تحرير دفتر العمل؛ يكتب المثال دفتر العمل الأصلي مرة أخرى ويفحص التخطيط في الذاكرة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // قم بتعديل بايتات دفتر العمل هنا، على سبيل المثال باستخدام Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

إزالة المجموعات تُزيل مراجع البيانات القديمة قبل كتابة دفتر العمل مرة أخرى. أعد بناء أي سلاسل وفئات مطلوبة للدفتر المعدل قبل استخدام المخطط.

## **تعيين تنسيقات أرقام مخصصة لخلايا دفتر العمل**

استخدم [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) للتحكم في طريقة ظهور القيم الرقمية في دفتر العمل المضمن للمخطط. على سبيل المثال، قد يحتاج تقرير إلى عرض معدل التحويل كنسبة مئوية بأربعة منازل عشرية ومعامل بخمسة منازل عشرية. حافظ على كِلَ القيم كأرقام لتظل متاحة للحسابات ورسم المخطط.

تنسيق الرقم يغيّر العرض فقط، وليس القيمة المخزنة. التنسيق `0.0000%` يعرض `0.125` كـ `12.5000%`؛ ولا يستبدل العدد المخزن بـ `12.5`. بالمثل، `0.00000` يعرض `0.1234567` كـ `0.12346` دون تقريب القيمة المخزنة. إذا كان التنسيق المخصص سلسلة فارغة (`""`)، يُستخدم التنسيق الذي تُعيده [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/).

المثال التالي يُنشئ مخططًا عموديًا ويصل إلى خلاياه عبر [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/). في ورقة العمل 0، يحتوي B2 على معدل التحويل وC2 على المعامل. كلا الخليتين تزودان المخطط بالقيم. يُفعّل المثال أيضًا عناوين القيم المرتبطة بالتنسيقات المصدرية.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    const percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    const percentageName = workbook.getCell(0, "B1", "Conversion rate");
    const percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    const precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    const precisionName = workbook.getCell(0, "C1", "Coefficient");
    const precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (let seriesIndex = 0; seriesIndex < chart.getChartData().getSeries().size(); seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تنسيقات خلايا دفتر العمل منفصلة عن التنسيقات المعينة مباشرةً على محاور المخطط أو عناوين البيانات. في هذا المثال، كل عنوان يعرض قيمة خلية المصدر لأن [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) مضبوطة على `true`، ويتبع تنسيق الرقم المصدر لأن [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) مضبوطة على `true`. بعد حفظ العرض وإعادة فتحه، تُظهر العناوين `12.5000%` و`0.12346` كما هو موضح أدناه. يستخدم المحور العمودي تنسيق رقم خاص به، مُعين بـ [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) كـ `0.00`، مع ضبط [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) على `false`.

لتنسيق عنوان بيانات بشكل مستقل، اضبط علم الربط بالمصدر على `false` وعيّن تنسيقًا باستخدام [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/). لا يغيّر ذلك تنسيق خلية دفتر العمل. على سبيل المثال، تنسيق عنوان مستقل بـ `0.00` يعرض القيمة الأولى كـ `0.13`، بينما لا يزال B2 يعرض `12.5000%`. راجع [Chart Data Labels](/slides/ar/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) لتنسيق العناوين مباشرةً.

الصورة أدناه تم تصييرها من العرض المحفوظ بعد إعادة فتحه:

![مخطط عمودي مع عناوين مرتبطة بالمصدر تُظهر 12.5000% و0.12346 ومحور رقمي مُنسق بشكل مستقل.](custom-cell-formats.png)

## **تعيين خلية دفتر العمل كعلامة بيانات للمخطط**

يمكنك استخدام النص من خلايا دفتر العمل كعناوين بيانات للمخطط.

يضيف هذا المثال مخطط فقاعة ببيانات افتراضية إلى الشريحة الأولى من عرض تقديمي موجود. يستخدم الخلايا A10:A12 في ورقة العمل 0 للعلامات الثلاث الأولى في السلسلة الأولى، يُفعّل العناوين من الخلايا، ويحفظ العرض المحدث.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إدارة أوراق العمل**

توفر الطريقة [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) إمكانية الوصول إلى أوراق العمل في دفتر عمل المخطط. يُنشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويطبع اسم كل ورقة عمل إلى وحدة التحكم.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **تحديد نوع مصدر البيانات**

يُنشئ هذا المثال مخططًا عموديًا ثلاثي الأبعاد ببيانات افتراضية ويضبط اسمين للسلسلتين باستخدام مصادر بيانات مختلفة. الاسم الأول يستخدم سلسلة حرفية؛ الاسم الثاني يستخدم الخلية C1 في ورقة العمل 0. يحدد تعداد [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) المصدر لكل اسم. يحفظ المثال العرض التقديمي بالأسماء المحدثة للسلاسل.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **اكتشاف صيغ دفاتر العمل المضمنة غير المدعومة**

لا يدعم Aspose.Slides صيغة دفتر العمل الثنائي Excel (.xlsb) التي يمكن تضمينها في بعض المخططات. يمكنك استخدام طريقة `getEmbeddedWorkbookType` على [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) لاكتشاف الصيغ غير المدعومة وتجاوز تلك المخططات. يفحص هذا المثال الأشكال في الشريحة الأولى من عرض تقديمي موجود، يتخطى الأشكال التي ليست مخططات، ويطبع رسالة تشخيصية لكل مخطط يحتوي على دفتر عمل .xlsb مضمّن.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // قراءة أو تعديل بيانات دفتر عمل المخطط المدعومة هنا.
    }
} finally {
    presentation.dispose();
}
```

## **دفتر العمل الخارجي**

يدعم Aspose.Slides استخدام دفاتر عمل خارجية كمصدر بيانات للمخططات.

### **إنشاء دفتر عمل خارجي**

استخدم [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) و[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) لتصدير دفتر عمل مخطط مضمّن إلى ملف وربط المخطط بذلك الدفتر الخارجي.

يُنشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويصدر دفتر عمله. يكتمل كتابة الملف قبل تعيين دفتر العمل الخارجي كمصدر بيانات للمخطط، ثم يحفظ العرض المرتبط.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **تعيين دفتر عمل خارجي**

باستخدام طريقة [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/)، يمكنك تعيين دفتر عمل خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الأخير).

في حين لا يمكنك تحرير البيانات في دفاتر العمل المخزنة في مواقع بعيدة أو موارد، لا يزال بإمكانك استخدام مثل هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتحول تلقائيًا إلى مسار كامل.

يستخدم هذا المثال دفتر عمل خارجي تكون ورقة العمل المسماة `Sheet1` فيها اسم سلسلة في B1، أسماء فئات في A2:A4، وقيم رقمية في B2:B4. يُنشئ المثال مخططًا دائريًا، يربط دفتر العمل، ويستخدم [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) لتعيين النطاق A1:B4 لسلسلة واحدة وثلاث فئات. يحفظ العرض بالمخطط المرتبط.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

معامل `updateChartData` في طريقة [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) يتحكم فيما إذا كان دفتر العمل يُحمَّل.

* عندما يكون `updateChartData` مساويًا لـ `false`، يتم تحديث مسار دفتر العمل فقط. لا يتم تحميل بيانات المخطط أو تحديثها من دفتر العمل الهدف، لذا يمكن أن يكون دفتر العمل غير متاح.
* عندما يكون `updateChartData` مساويًا لـ `true`، تُحدَّث بيانات المخطط من دفتر العمل الهدف.

يعطي المثال التالي عنوان URL نائب مع `updateChartData` مضبوطة على `false`. يحتفظ بالمخطط الدائري ببياناته الافتراضية ويحفظ العرض دون تحميل دفتر العمل غير المتاح.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **الحصول على مسار دفتر العمل لمصدر البيانات الخارجي لمخطط**

لتحديد دفتر العمل المرتبط بمخطط، تحقق مما إذا كان المخطط يستخدم مصدر بيانات خارجي واستخلص مسار دفتر العمل.

يفحص هذا المثال الشكل الأول في الشريحة الأولى من عرض تقديمي مرتبط بدفتر عمل خارجي. إذا كان مخططًا مرتبطًا بدفتر عمل خارجي، يطبع [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) إلى وحدة التحكم. ثم يحفظ نسخة من العرض.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تحرير بيانات المخطط**

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تجري بها تغييرات على محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يُطلق استثناء.

يستخدم هذا المثال مخططًا هو الشكل الأول في الشريحة الأولى ومربوطًا بدفتر عمل خارجي يمكن الوصول إليه. يضبط القيمة المدعومة بالخلية لأول نقطة بيانات في السلسلة الأولى إلى 100 ويحفظ العرض المحدث. تحرير قيم الخلايا يمكن أن يحدث ملف XLSX الخارجي المرتبط، لذا استخدم نسخة إذا كان عليك الحفاظ على دفتر العمل الأصلي.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **استعادة دفتر العمل من ذاكرة التخزين المؤقت للمخطط**

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض. أنشئ [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/)، استدعِ [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/)، واضبط [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) على `true` قبل فتح العرض.

يعيد مثال JavaScript التالي بيانات دفتر العمل لمخطط هو الشكل الأول في الشريحة الأولى ويشير إلى دفتر عمل خارجي غير متاح. يصل إلى البيانات المستعادة عبر [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) و[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // قراءة أو تعديل بيانات دفتر العمل المستعاد هنا.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، يُطلق Aspose.Slides استثناء. فعّل الاستعادة فقط عندما يكون استخدام البيانات المخزنة مؤقتًا للمخطط خيارًا مقبولًا، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض.

## **الأسئلة المتكررة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أم مدمج؟**

نعم. يمتلك المخطط نوع مصدر بيانات [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) ومسار إلى دفتر عمل خارجي [path to an external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل يتم دعم المسارات النسبية لدفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتحول تلقائيًا إلى مسار مطلق. يخزن العرض المسار المطلق في ملف PPTX، لذا قد يتطلب نقل دفتر العمل تحديث الارتباط.

**هل يمكنني استخدام دفاتر العمل الموجودة على موارد/مشاركات الشبكة؟**

نعم، يمكن استخدام مثل هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تحرير دفاتر العمل البعيدة مباشرةً؛ يمكن استخدامها فقط كمصدر.

**هل يقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

يحفظ العرض ارتباطًا إلى الملف الخارجي [link to the external file](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). يمكن لتحرير بيانات المخطط المدعومة بالخلية أيضًا تحديث ملف XLSX المحلي المرتبط. استخدم نسخة من دفتر العمل إذا كان يجب الحفاظ على الأصل دون تغيير.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

Aspose.Slides لا يقبل كلمة مرور عند الربط. يُنصح بإزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](https://reference.aspose.com/cells/java/)) وربطها بهذه النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. كل مخطط يخزن ارتباطه الخاص. إذا كانت جميعها تشير إلى نفس الملف، سيُعكس أي تحديث للملف في كل مخطط عند تحميل البيانات مرة أخرى.