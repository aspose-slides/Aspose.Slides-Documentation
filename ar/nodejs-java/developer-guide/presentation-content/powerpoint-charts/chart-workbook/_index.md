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
- ملصق البيانات
- ورقة العمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- ذاكرة التخزين المؤقت للمخطط
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "اكتشف Aspose.Slides لـ Node.js عبر Java: قم بإدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint وOpenDocument لتبسيط بيانات العرض التقديمي الخاص بك."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع دفاتر عمل المخططات في Aspose.Slides. توضح كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كملصقات بيانات للمخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر العمل الخارجية كمصادر بيانات للمخططات. توضح الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، استرداد مسار دفتر العمل الخارجي المرتبط بمخطط، وتحرير بيانات المخطط عندما يكون دفتر العمل متاحًا.

## **قراءة وكتابة بيانات المخطط من دفتر عمل**

يوفر Aspose.Slides طريقتي [readWorkbookStream](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) و [writeWorkbookStream](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) اللتين تتيحان لك قراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات مخطط تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أنه يجب تنظيم بيانات المخطط بنفس الطريقة أو أن يكون لها بنية مشابهة للمصدر.

هذا الكود JavaScript يوضح عملية نموذجية:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **التحقق من تخطيط المخطط بعد تعديل دفتر العمل**

عند استبدال دفتر عمل مضمّن بآخر معدل، يحتفظ المخطط بسلسلاته ومجموعات الفئات الأصلية. هذا الاختلاف يمكن أن يتسبب في فشل [Chart.validateChartLayout](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Chart#validateChartLayout--) مع خطأ “فهرس خارج النطاق”. يجب مسح السلاسل والفئات الموجودة قبل كتابة دفتر العمل المحدّث مرة أخرى إلى المخطط.

```javascript
// بعد تعديل تدفق دفتر العمل (مثلاً باستخدام Aspose.Cells)
var updatedWorkbook = chartData.readWorkbookStream();

// امسح مراجع البيانات الحالية.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

يمكّن مسح المجموعات من ضمان توافق بنية بيانات المخطط مع دفتر العمل الجديد، مما يسمح لـ `validateChartLayout` بالانتهاء دون أخطاء.

## **تعيين خلية دفتر العمل كملصق بيانات للمخطط**

1. إنشاء مثيل من فئة [Presentation](https://apireference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation) .
1. الحصول على مرجع شريحة عبر فهرسها.
1. إضافة مخطط فقاعة مع بعض البيانات.
1. الوصول إلى سلسلة المخطط.
1. تعيين خلية دفتر العمل كملصق بيانات.
1. حفظ العرض التقديمي.

هذا الكود JavaScript يوضح كيفية تعيين خلية دفتر عمل كملصق بيانات للمخطط:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// يقوم بإنشاء فئة عرض تقديمي تمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **إدارة أوراق العمل**

هذا الكود JavaScript يوضح عملية حيث يتم استخدام طريقة [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) للوصول إلى مجموعة أوراق العمل:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تحديد نوع مصدر البيانات**

هذا الكود JavaScript يوضح كيفية تحديد نوع لمصدر البيانات:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **كشف تنسيقات دفاتر العمل المضمنة غير المدعومة**

لا يدعم Aspose.Slides تنسيق دفتر العمل الثنائي Excel (.xlsb) الذي يمكن تضمينه في بعض المخططات. يمكنك استخدام طريقة `getEmbeddedWorkbookType` على [ChartData](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/workbooktype/) للكشف عن التنسيقات غير المدعومة وتجاوز تلك المخططات.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
            // دفتر العمل المضمّن بصيغة .xlsb غير مدعوم.
            continue;
        }

        // اقرأ أو عدل بيانات دفتر عمل المخطط هنا.
    }
} finally {
    presentation.dispose();
}
```

## **دفتر عمل خارجي**

يدعم Aspose.Slides دفاتر العمل الخارجية كمصدر بيانات للمخططات.

### **إنشاء دفتر عمل خارجي**

باستخدام طريقتي **`readWorkbookStream`** و **`setExternalWorkbook`**، يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو جعل دفتر عمل داخلي خارجياً.

هذا الكود JavaScript يوضح عملية إنشاء دفتر عمل خارجي:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream تُرجع بايتات دفتر العمل كـ Buffer من Node.
    var workbookData = chart.getChartData().readWorkbookStream();
    fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **تعيين دفتر عمل خارجي**

باستخدام طريقة **`setExternalWorkbook`**، يمكنك تعيين دفتر عمل خارجي إلى مخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الأخير).

بينما لا يمكنك تحرير البيانات في دفاتر العمل المخزنة في مواقع أو موارد عن بُعد، لا يزال بإمكانك استخدام هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

هذا الكود JavaScript يوضح كيفية تعيين دفتر عمل خارجي:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// ينشئ مثالا من فئة Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

المعامل الثاني لطريقة `setExternalWorkbook`، `updateChartData`، يحدد ما إذا كان سيتم تحميل دفتر عمل Excel أم لا.

* عندما يكون `updateChartData` مضبوطًا على `false`، يتم تحديث مسار دفتر العمل فقط — لن يتم تحميل بيانات المخطط أو تحديثها من دفتر العمل الهدف. قد ترغب في استخدام هذا الإعداد عندما يكون دفتر العمل الهدف غير موجود أو غير متاح.
* عندما يكون `updateChartData` مضبوطًا على `true`, يتم تحديث بيانات المخطط من دفتر العمل الهدف.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// ينشئ مثالا من فئة Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **الحصول على مسار دفتر عمل مصدر البيانات الخارجي للمخطط**

1. إنشاء مثيل من فئة [Presentation](https://apireference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation) .
1. الحصول على مرجع شريحة عبر فهرسها.
1. إنشاء كائن لشكل المخطط.
1. إنشاء كائن لنوع المصدر (`ChartDataSourceType`) الذي يمثل مصدر بيانات المخطط.
1. تحديد الشرط المناسب بناءً على كون نوع المصدر هو نفسه نوع مصدر دفتر العمل الخارجي.

هذا الكود JavaScript يوضح العملية:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// ينشئ مثالا من فئة Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // يحفظ العرض التقديمي
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **تحرير بيانات المخطط**

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تجري بها تغييرات على محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يتم رمي استثناء.

هذا الكود JavaScript هو تنفيذ للعملية الموضحة:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// ينشئ مثالا من فئة Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **استعادة دفتر عمل من ذاكرة التخزين المؤقت للمخطط**

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض التقديمي. أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/)، وقم بتكوينه باستخدام [SpreadsheetOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/spreadsheetoptions/)، واستدعِ [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) مع `true` قبل فتح العرض التقديمي.

المثال التالي بلغة JavaScript يفتح عرضًا تقديميًا يشير فيه المخطط إلى دفتر عمل خارجي غير متاح ويصل إلى البيانات المستعادة عبر [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // اقرأ أو عدل بيانات دفتر العمل المستعاد هنا.
} finally {
    presentation.dispose();
}
```

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، سيطلق Aspose.Slides استثناءً. فعل الاستعادة فقط عندما يكون استخدام بيانات المخطط المخزنة مؤقتًا كحل مقبول، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة المتكررة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًًا بدفتر عمل خارجي أو مضمّن؟**

نعم. للمخطط نوع [مصدر البيانات](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) و[مسار إلى دفتر عمل خارجي](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/)؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تدعم المسارات النسبية لدفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتم تحويله تلقائيًا إلى مسار مطلق. هذا مفيد لنقلية المشروع؛ مع ذلك، يجب أن تكون على علم بأن العرض التقديمي سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات شبكة؟**

نعم، يمكن استخدام هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يُدعم تحرير دفاتر العمل البعيدة مباشرة من Aspose.Slides — يمكن استخدامها فقط كمصدر.

**هل يقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

لا. يخزن العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي عند حفظ العرض التقديمي.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

Aspose.Slides لا يقبل كلمة مرور عند الربط. النهج الشائع هو إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](/cells/nodejs-java/)) وربطها بهذه النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. كل مخطط يخزن رابطه الخاص. إذا كانت جميع الروابط تشير إلى نفس الملف، فإن تحديث ذلك الملف سيعكس التغييرات في كل مخطط في المرة التالية التي يتم فيها تحميل البيانات.