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
- تسمية البيانات
- ورقة عمل
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
description: "اكتشف Aspose.Slides لـ Node.js عبر Java: إدارة دفاتر عمل المخطط بسهولة في صيغ PowerPoint وOpenDocument لتبسيط بيانات عروضك التقديمية."
---
## **نظرة عامة**

هذا المقال يوضح كيفية العمل مع دفاتر عمل المخططات في Aspose.Slides. يُظهر كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعناوين بيانات للمخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما يغطي العمل مع دفاتر عمل خارجية كمصادر بيانات للمخططات. تُظهر الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، واسترجاع مسار دفتر عمل خارجي مرتبط بمخطط، وتعديل بيانات المخطط عندما يكون دفتر العمل متاحًا.

لخلايا دفتر العمل التي تمثل بيانات مفقودة، راجع [Control the Display of Empty Cells](/slides/ar/nodejs-java/chart-series/) للاطلاع على الفرق بين الخلية الفارغة والصفر، ومقارنة مخطط خطي بين أوضاع العرض المتاحة.

## **تضمين البيانات من الصفوف والأعمدة المخفية**

استخدم [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) للتحكم فيما إذا كان المخطط يرسم بيانات من صفوف وأعمدة ورقة العمل المخفية. اضبطه على `true` لرسم الخلايا المرئية فقط، أو `false` لتضمين كل الخلايا المرئية والمخفية. هذه الإعدادات تتحكم في رسم المخطط؛ ولا تقوم بإخفاء أو إظهار صفوف أو أعمدة ورقة العمل.

العرض التقديمي [sample presentation](hidden-source-data.pptx) يحتوي على مخطط عمودي كأول شكل في شريحته الأولى. ورقة العمل المضمّنة، `Sheet1`، تحتوي على النطاق المصدر التالي، `A1:C4`. الصف 3 والعمود C مخفيان، لكن خلاياهما لا تزال تحتوي على قيم.

| صف ورقة العمل | A: الشهر | B: التجزئة | C: الجملة (عمود مخفي) |
| --- | --- | --- | --- |
| 2 | يناير | 10 | 30 |
| 3 (صف مخفي) | فبراير | 40 | 60 |
| 4 | مارس | 20 | 50 |

الوصول إلى خلايا المصدر عبر [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) وقراءة [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#isHidden) لتفقد حالة الإخفاء الخاصة بها. هذه الطريقة تُبلغ عن حالة الإخفاء دون تغييرها. في هذا الملف، B2 مرئية، B3 تنتمي إلى الصف المخفي، وC2 تنتمي إلى العمود المخفي؛ المثال يطبع `false`، `true`، و`true` على التوالي.

لهذا المثال، حدّث بيانات المخطط بعد تغيير إعداد الرسم: احتفظ بدفتر العمل المضمّن باستخدام [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) وأعد تحميله باستخدام [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream). عند تضمين جميع الخلايا، استخدم أيضًا [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange) لاستعادة النطاق الكامل، بما في ذلك الفئة المخفية لفبراير. مجرد تغيير العلامة غير كافٍ لتحديث البيانات المخزنة مؤقتًا للمخطط وتصنيفات الفئات في هذا العينة. المثال يحول المصفوفة المؤقتة لـ Node.js إلى مصفوفة بايتات Java قبل تمريرها إلى طريقة الكتابة.

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
        // الشكل الأول ليس مخططًا.
    }
} finally {
    presentation.dispose();
}
```

يحفظ المثال إصداريّن من العرض التقديمي: أحدهما يحتوي فقط على قيم التجزئة المرئية (10 و20)، والآخر يحتوي على جميع القيم الستة. الصور أدناه توضح وضعي الرسم. يظل الصف 3 والعمود C مخفيين في كل من دفاتر العمل المضمّنة.

| الخلايا المرئية فقط (`true`) | جميع الخلايا (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

الخلية المخفية التي تحتوي على قيمة تختلف عن الخلية الفارغة. يتحكم [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) في طريقة عرض القيم المفقودة؛ ولا يضيف أو يستثنى بيانات المصدر المخفي. راجع [Control the Display of Empty Cells](/slides/ar/nodejs-java/chart-series/#control-the-display-of-empty-cells) لمثال.

## **استرجاع نطاق بيانات المخطط**

قبل تحديث بيانات دفتر العمل في عرض تقديمي موجود، افحص نطاقات المصدر لتحديد خلايا ورقة العمل التي يستخدمها كل مخطط. طريقة [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getRange) تُعيد النطاق الحالي للبيانات على شكل صيغة مؤهلة للورقة، مثل `Sheet1!$A$1:$D$5`. هنا، `Sheet1` هو اسم الورقة، `!` يفصلها عن نطاق الخلايا، و`$A$1:$D$5` يحدد الخلايا من A1 إلى D5 شاملًا. تشير علامات الدولار إلى مراجع صف وعمود مطلقة.

الطريقة تقرأ النطاق الحالي دون تغيير المخطط أو دفتر عمله. إذا لم يستخدم المخطط دفتر عمل كمصدر بيانات، فإنها تُطلق استثناء `InvalidOperationException`. لمزيد من المعلومات، راجع [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/).

يفتح هذا المثال عرضًا تقديميًا ويفحص الأشكال مباشرةً على كل شريحة للبحث عن مخططات. يطبع اسم كل مخطط والنطاق المصدر. إذا لم يستخدم المخطط دفتر عمل، يطبع رسالة ويتابع إلى المخطط التالي.

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

## **قراءة وكتابة بيانات المخطط من دفتر عمل**

توفر Aspose.Slides for Node.js via Java طريقتي [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) و[writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) اللتين تسمحان بقراءة وكتابة دفاتر عمل بيانات المخططات (التي تحتوي على بيانات مخطط تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تُنظم بنفس الطريقة أو أن تكون ذات بنية مشابهة للمصدر.

يستخدم هذا المثال عرضًا تقديميًا يحتوي على مخطط كأول شكل في شريحته الأولى. يقرأ دفتر العمل المضمّن إلى مصفوفة بايتات، يمسح السلسلة والفئات الحالية، ثم يكتب نفس دفتر العمل مرة أخرى. تبقى التغييرات في الذاكرة؛ لا يقوم المثال بحفظ العرض التقديمي.

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

### **التحقق من تخطيط المخطط بعد تعديل دفتر العمل**

عند استبدال دفتر عمل مضمّن بآخر معدل، يحتفظ المخطط بسلسلته الأصلية ومجموعات الفئات. هذا الاختلاف قد يتسبب في فشل [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#validateChartLayout) بخطأ عن عدم تطابق الفهرس. امسح السلاسل والفئات الحالية قبل كتابة دفتر العمل المعدَّل مرة أخرى إلى المخططات. يستخدم هذا المثال مخططًا هو الشكل الأول في الشريحة الأولى. العلامة التعليقية تُظهر مكان تحرير دفتر العمل؛ المثال القابل للتنفيذ يكتب دفتر العمل الأصلي مرة أخرى ويُصادق على التخطيط في الذاكرة.

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

        // عدّل بايتات دفتر العمل هنا، على سبيل المثال باستخدام Aspose.Cells.

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

إزالة المجموعات تُزيل مراجع البيانات القديمة قبل كتابة دفتر العمل مرة أخرى. أعد بناء أي سلاسل أو تعيينات فئات مطلوبة لدفتر العمل المحدث قبل استخدام المخطط.

## **تعيين خلية دفتر عمل كعنوان بيانات المخطط**

يمكنك استخدام النص من خلايا دفتر العمل كعناوين بيانات للمخطط.

يضيف هذا المثال مخطط فقاعة ببيانات افتراضية إلى الشريحة الأولى من عرض تقديمي موجود. يستخدم الخلايا A10:A12 في ورقة العمل 0 للثلاث عناوين الأولى في السلسلة الأولى، يُفعِّل العناوين من الخلايا، ويحفظ العرض التقديمي المحدث.

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

توفر طريقة [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) وصولًا إلى أوراق العمل في دفتر عمل المخططات. يُنشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويطبع اسم كل ورقة عمل إلى وحدة التحكم.

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

يُنشئ هذا المثال مخطط عمودي ثلاثي الأبعاد ببيانات افتراضية ويحدِّد اسمين للسلسلة باستخدام مصادر بيانات مختلفة. الاسم الأول يستخدم نصًا حرفيًا؛ الاسم الثاني يستخدم الخلية C1 في ورقة العمل 0. يحدد تعداد [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) المصدر لكل اسم. يحفظ المثال العرض التقديمي مع أسماء السلسلة المحدَّثة.

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

## **الكشف عن صيغ دفاتر العمل المضمّنة غير المدعومة**

لا تدعم Aspose.Slides صيغة دفتر العمل الثنائي للExcel (.xlsb) التي يمكن تضمينها في بعض المخططات. يمكنك استخدام طريقة [getEmbeddedWorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) على [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) لتحديد الصيغ غير المدعومة وتخطي تلك المخططات. يفحص هذا المثال الأشكال في الشريحة الأولى من عرض تقديمي موجود، يتخطى الأشكال غير المخططات، ويطبع رسالة تشخيصية لكل مخطط يحتوي على دفتر عمل .xlsb مضمّن.

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

        // اقرأ أو عدّل بيانات دفتر عمل المخطط المدعومة هنا.
    }
} finally {
    presentation.dispose();
}
```

## **دفتر عمل خارجي**

تدعم Aspose.Slides استخدام دفاتر عمل خارجية كمصدر بيانات للمخططات.

### **إنشاء دفتر عمل خارجي**

استخدم [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) و[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) لتصدير دفتر عمل مخطط مضمّن إلى ملف وربط المخطط بذلك دفتر العمل الخارجي.

يُنشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويصدر دفتر عمله. يكمل كتابة الملف قبل تعيين دفتر العمل الخارجي كمصدر بيانات المخطط، ثم يحفظ العرض التقديمي المرتبط.

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

باستخدام طريقة [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) يمكنك تعيين دفتر عمل خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الأخير).

في حين لا يمكنك تحرير البيانات في دفاتر العمل المخزَّنة في مواقع أو موارد عن بُعد، لا يزال بإمكانك استخدام هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتحول تلقائيًا إلى مسار كامل.

يستخدم هذا المثال دفتر عمل خارجي تحتوي ورقة العمل المسماة `Sheet1` على اسم سلسلة في B1، وأسماء فئات في A2:A4، وقيم رقمية في B2:B4. يُنشئ المثال مخططًا دائريًا، يربط دفتر العمل، ويستخدم [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange) لتعيين النطاق A1:B4 لسلسلة واحدة وثلاث فئات. يحفظ العرض التقديمي بالمخطط المرتبط.

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

معامل `updateChartData` في طريقة [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) يتحكم فيما إذا كان دفتر العمل يُحمَّل.

* عندما يكون `updateChartData` `false`، يُحدَّث مسار دفتر العمل فقط. لا تُحمَّل بيانات المخطط أو تُحدَّث من دفتر العمل الهدف، وبالتالي يمكن أن يكون دفتر العمل غير متاح.
* عندما يكون `updateChartData` `true`، تُحدَّث بيانات المخطط من دفتر العمل الهدف.

يعين المثال التالي عنوان URL نائب مع تعيين `updateChartData` إلى `false`. يحتفظ بالمخطط الدائري ببياناته الافتراضية ويحفظ العرض التقديمي دون تحميل دفتر العمل غير المتاح.

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

### **الحصول على مسار دفتر العمل المصدر الخارجي للمخطط**

لتحديد دفتر العمل المرتبط بمخطط، تحقق مما إذا كان المخطط يستخدم مصدر بيانات خارجي واسترجع مسار دفتر العمل.

يفحص هذا المثال الشكل الأول في الشريحة الأولى من عرض تقديمي يحتوي على دفتر عمل خارجي مرتبط. إذا كان مخططًا مرتبطًا بدفتر عمل خارجي، يطبع [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) إلى وحدة التحكم. ثم يحفظ نسخة من العرض التقديمي.

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

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تُجري بها تغييرات على محتوى دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يُطلق استثناء.

يستخدم هذا المثال مخططًا هو الشكل الأول في الشريحة الأولى ومرتبطًا بدفتر عمل خارجي يمكن الوصول إليه. يحدد قيمة النقطة البيانية الأولى في السلسلة الأولى إلى 100 ويحفظ العرض التقديمي المحدث. تحرير قيم الخلايا يمكن أن يُحدِّث ملف XLSX الخارجي المرتبط، لذا استخدم نسخة إذا كنت بحاجة إلى الحفاظ على دفتر العمل الأصلي.

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

### **استعادة دفتر عمل من ذاكرة التخزين المؤقت للمخطط**

إذا كان مخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزَّنة مؤقتًا في العرض التقديمي. أنشئ [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/)، استدعِ [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions)، واضبط [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) إلى `true` قبل فتح العرض التقديمي.

يعيد المثال التالي في JavaScript استعادة بيانات دفتر العمل لمخطط هو الشكل الأول في الشريحة الأولى ويشير إلى دفتر عمل خارجي غير متاح. يصل إلى البيانات المستعادة عبر [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getChartData) و[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، تُطلق Aspose.Slides استثناءً. فعل الاستعادة فقط عندما يكون استخدام البيانات المخزَّنة مؤقتًا للمخطط خيارًا مقبولًا، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريَّت على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة المتكررة**

**هل يمكنني معرفة ما إذا كان مخطط معين مرتبط بدفتر عمل خارجي أو مضمّن؟**

نعم. يمتلك المخطط [نوع مصدر البيانات](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getDataSourceType) و[مسار دفتر العمل الخارجي](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath)؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تُدعم المسارات النسبية لدفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يُحوَّل تلقائيًا إلى مسار مطلق. يخزن العرض التقديمي المسار المطلق في ملف PPTX، لذا قد يتطلب نقل دفتر العمل تحديث الرابط.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات شبكة؟**

نعم، يمكن استخدام مثل هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يُدعم تحرير دفاتر العمل البعيدة مباشرةً من Aspose.Slides—يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

يحفظ العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath). تحرير بيانات المخطط المدعومة من الخلايا يمكن أيضًا أن يُحدِّث ملف XLSX المحلي المرتبط. استخدم نسخة من دفتر العمل إذا كان من الضروري ألا يتغير الأصل.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

لا تقبل Aspose.Slides كلمة مرور عند الربط. يُنصَح بإزالة الحماية مسبقًا أو إعداد نسخة مُفكَّة (مثلاً باستخدام [Aspose.Cells](https://reference.aspose.com/cells/java/)) وربط تلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. يخزن كل مخطط رابطه الخاص. إذا أشارت جميعها إلى نفس الملف، فإن تحديث ذلك الملف سينعكس على كل مخطط عند تحميل البيانات مجددًا.