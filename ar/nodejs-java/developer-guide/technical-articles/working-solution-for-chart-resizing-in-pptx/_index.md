---
title: حل عملي لإعادة تحجيم المخططات في PPTX
type: docs
weight: 40
url: /ar/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
  - إعادة تحجيم المخطط
  - مخطط إكسل
  - كائن OLE
  - تضمين مخطط
  - PowerPoint
  - عرض تقديمي
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "إصلاح مشكلة إعادة تحجيم المخطط غير المتوقعة في ملفات PPTX عند استخدام كائنات OLE مدمجة من Excel مع Aspose.Slides for Node.js via Java. ضبط أبعاد المخطط الثابتة للحفاظ على تناسق أحجام المخطط وإطار OLE."
---
## **نظرة عامة**

يمكن أن تتغير حجم مخططات إكسل المدمجة ككائنات OLE في عروض PowerPoint باستخدام مكونات Aspose بعد تفعيلها لأول مرة. يمكن أن يؤدي ذلك إلى فرق ملحوظ في مظهر المخطط قبل وبعد التفعيل. توضح هذه المقالة سبب حدوث تغيير الحجم وتظهر كيفية منعه من خلال مطابقة أبعاد المخطط الثابتة مع إطار OLE.

في [إنشاء مخططات إكسل وتضمينها ككائنات OLE في العروض التقديمية](/slides/ar/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، شرحنا كيفية إنشاء مخطط إكسل باستخدام Aspose.Cells for Node.js via Java وتضمينه في عرض PowerPoint باستخدام Aspose.Slides for Node.js via Java. لمعالجة [مشكلة معاينة الكائن](/slides/ar/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة المخطط إلى إطار كائن OLE الخاص بالمخطط. في العرض الناتج، عند النقر المزدوج على إطار كائن OLE الذي يعرض صورة المخطط، يتم تفعيل مخطط إكسل. يمكن للمستخدمين تعديل دفتر إكسل المدمج ثم العودة إلى الشريحة بالنقر خارج دفتر العمل المفعّل. يتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة، وتختلف عامل إعادة الحجم اعتمادًا على الأحجام الأصلية لكل من إطار كائن OLE ودفتر إكسل المدمج.

## **سبب تغيير الحجم**

يمتلك دفتر إكسل المدمج أبعاده الخاصة للنافذة، ويحاول إكسل الاحتفاظ بها عندما يتم تفعيل الكائن للمرة الأولى. إطار OLE على الشريحة له أبعاد معرفة بشكل مستقل. عندما يتم تفعيل دفتر إكسل، يتفاوض إكسل وPowerPoint على حجم الكائن للحفاظ على نسبه كجزء من عملية الدمج. لذا يمكن أن تتسبب الاختلافات بين نافذة دفتر العمل وإطار OLE في تغيير حجم الكائن.

## **الحل العملي**

طابق حجم المخطط مع إطار OLE على الشريحة واحفظ أبعاد المخطط مستقلة عن نافذة دفتر العمل. يعمل هذا الحل مع عرض تقديمي جديد أو قالب موجود.

يتطلب المثال Aspose.Cells for Node.js via Java وAspose.Slides for Node.js via Java. ثبّت حزم Node.js `aspose.cells` و`aspose.slides.via.java` و`java`. شغّل النصين CommonJS أدناه في عمليات Node.js منفصلة، باستخدام نفس دليل العمل، لأن كلا حزمتَي Aspose تقومان بتهيئة جسر Java أثناء التحميل. ينشئ مخطط عمودي بسيط على ورقة مخطط نشطة ويضمّن دفتر العمل بتنسيق XLS. لا يتم تعيين صورة معاينة للمخطط؛ يصبح المخطط مرئيًا عندما يتم تفعيل كائن OLE في PowerPoint.

ينشئ المثال عرضًا تقديميًا جديدًا بإطار OLE بحجم 9.5 × 4 بوصة موضعه 0.5 بوصة من الحافة اليسرى و1 بوصة من الأعلى. إحداثيات الشريحة وأبعادها بالنقاط (72 نقطة لكل بوصة). للعرض القائم، راجع [استخدام قالب](#use-a-template).

## **تعيين حجم مخطط ثابت**

عيّن [setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) إلى false بحيث تكون أبعاد المخطط مستقلة عن نافذة دفتر العمل. عيّن أبعاد [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject) عبر [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) و[setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight)، محولًا النقاط إلى بكسلات باستخدام 96 بكسل لكل بوصة: إطار مقاسه 684 × 288 نقطة يعادل مخططًا مقاسه 912 × 384 بكسل. عيّن [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) إلى القيمة CUSTOM من `PrintSizeType`. يضمّن المثال دفتر العمل عبر [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) ويخزن عرضًا تقديميًا بإطار OLE بحجم 9.5 × 4 بوصة.

احفظ هذا النص الأول باسم `create-fixed-chart.js`. يُنشئ ملف `chart-fixed-size.xls` بمخطط مقاسه 912 × 384 بكسل، مطابقًا للإطار الذي قيَّس بـ 684 × 288 نقطة المستخدم في النص الثاني. لا يلزم وجود دفتر عمل إدخال.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // مطابقة أبعاد إطار OLE بالنقاط (72 نقطة لكل بوصة).
    const width = 684; // 9.5 بوصة.
    const height = 288; // 4 بوصات.

    chart.setSizeWithWindow(false);
    // تحويل النقاط إلى بكسلات المخطط باستخدام 96 بكسل لكل بوصة.
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// اكتملت جميع الأعمال المتزامنة؛ أوقف عملية جسر Java.
process.exit(0);
```

احفظ النص الثاني باسم `embed-fixed-chart.js` وشغّله بعد `create-fixed-chart.js`. يقرأ دفتر العمل XLS المُولد ويحفظ `chart-fixed-size.pptx`. يتطلب جسر Java مصفوفة بايت Java صريحة لبيانات دفتر العمل وقيم float Java لإحداثيات وإبعاد الإطار. امتداد `xls` يتطابق مع تنسيق دفتر العمل المحفوظ.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // إحداثيات الشريحة وأبعادها بالنقاط (72 نقطة لكل بوصة).
    const width = 684; // 9.5 بوصة.
    const height = 288; // 4 بوصات.
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// اكتملت جميع الأعمال المتزامنة؛ أوقف عملية جسر Java.
process.exit(0);
```

## **استخدام قالب**

منطق القياس هو نفسه للعرض التقديمي الموجود. لتكييف المثال:

1. حمّل قالب العرض بدلاً من إنشاء عرض فارغ.
1. تأكّد أن الشريحة الأولى تحتوي على ثلاثة أشكال على الأقل، ثم استخدم الشكل في الفهرس 2 كعنصر نائب.
1. خذ عرض وإرتفاع الإطار من ذلك الشكل بدلًا من القيم الثابتة 684 و288. استخدم نفس الأبعاد في نص إنشاء دفتر العمل، مع الحفاظ على حسابات القياس دون تغيير، وأعد توليد دفتر العمل XLS قبل تضمينه.
1. أضف إطار OLE في موضع العنصر النائب بدلًا من الإحداثيات الثابتة 36 و72.
1. احذف العنصر النائب قبل حفظ العرض.

## **الأسئلة المتداولة**

**لماذا يتغير حجم مخطط إكسل المدمج بعد تفعيله في PowerPoint؟**

يحدث هذا لأن إكسل يحاول استعادة حجم النافذة الأصلي عند التفعيل الأول، بينما يمتلك إطار كائن OLE في PowerPoint أبعاده الخاصة. يتفاوض PowerPoint وإكسل على الحجم للحفاظ على نسبة العرض إلى الارتفاع، مما قد يسبب تغيير الحجم.

**كيف يمكن الحفاظ على تناسق أحجام المخطط وإطار OLE؟**

عين أبعاد مخطط ثابتة تتطابق مع إطار OLE واستخدم حجم طباعة مخطط مخصص قبل تضمين دفتر العمل. يوضح المثال أعلاه الإعدادات المطلوبة والتحويلات الوحدوية.

**هل مطابقة حجم نافذة دفتر العمل كافية؟**

مطابقة حجم نافذة دفتر العمل وحدها لا تمنع بشكل موثوق تغيير حجم إطار OLE بعد التفعيل. استخدم أبعاد مخطط ثابتة كما هو موضح في المثال.

**هل يعمل هذا الحل مع العروض التقديمية القائمة على القالب وعروض تقديمية جديدة؟**

نعم. للقالب، استخدم أبعاد وموقع العنصر النائب. للعرض الجديد، حدد أبعاد الإطار وموقعه مباشرة.

**هل يمكنني استخدام هذا المثال مع مخططات تم إنشاؤها في برامج جداول بيانات أخرى؟**

يستخدم المثال دفتر إكسل تم إنشاؤه بـ Aspose.Cells. لا يُظهر سلوك التفعيل لبرامج جداول بيانات أخرى.

## **الأقسام ذات الصلة**

- [إنشاء مخططات إكسل وتضمينها ككائنات OLE في العروض التقديمية](/slides/ar/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)