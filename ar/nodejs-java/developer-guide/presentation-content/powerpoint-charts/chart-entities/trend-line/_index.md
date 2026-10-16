---
title: إضافة خطوط الاتجاه إلى مخططات العروض التقديمية في JavaScript
linktitle: خط الاتجاه
type: docs
url: /ar/nodejs-java/trend-line/
keywords:
- مخطط
- خط الاتجاه
- خط الاتجاه الأسي
- خط الاتجاه الخطي
- خط الاتجاه اللوغاريتمي
- خط الاتجاه للمتوسط المتحرك
- خط الاتجاه متعدد الحدود
- خط الاتجاه القوي
- خط الاتجاه المخصص
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إضافة وتخصيص خطوط الاتجاه بسرعة في مخططات PowerPoint باستخدام JavaScript و Aspose.Slides لـ Node.js عبر Java — دليل عملي لجذب جمهورك."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية إضافة خطوط الاتجاه إلى مخططات العروض التقديمية باستخدام Aspose.Slides. توضح كيفية إنشاء مخطط، إضافة خطوط الاتجاه إلى سلسلة المخطط، والعمل مع عدة أنواع من خطوط الاتجاه، بما في ذلك الأسية، الخطية، اللوغاريتمية، المتوسط المتحرك، المتعددة الحدود، والقوة.

كما يصف كيفية إضافة خط مخصص إلى مخطط عن طريق إدراج شكل خط، ويتضمن قسم أسئلة شائعة قصير حول قيم توقع خط الاتجاه للأمام وللخلف وما إذا كانت خطوط الاتجاه تُحافظ عليها أثناء تصدير إلى PDF أو SVG وعند عرض المخططات كصور.

## **إضافة خط اتجاه**

استخدم [TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add) لإضافة خط اتجاه إلى سلسلة مخطط، مع تحديد نوعه باستخدام [TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/). ينشئ المثال مخطط أعمدة مجمّع ببيانات افتراضية ويضيف خطي اتجاه إلى كل من سلسلةه الثلاث.

يخفي خط الاتجاه الأسّي معادلته وقيمة R‑squared من خلال [setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation) و[setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue)، بينما يكون خط الاتجاه الخطي أحمر. يستخدم خط الاتجاه اللوغاريتمي [addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding) لإضافة تسمية مخصصة. يستخدم المتوسط المتحرك [setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod) لثلاث نقاط بيانات و[setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName) مخصص.

يحتوي خط الاتجاه المتعدد الحدود على [setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder) قيمته ثلاثة ويمتد فئة واحدة إلى الأمام عبر [setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward). يمتد خط الاتجاه القوي فئة واحدة إلى الخلف عبر [setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);

    const firstSeries = chart.getChartData().getSeries().get_Item(0);

    const exponentialTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    const linearTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(red);

    const secondSeries = chart.getChartData().getSeries().get_Item(1);

    const logarithmicTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    const movingAverageTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod(java.newByte(3));
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    const thirdSeries = chart.getChartData().getSeries().get_Item(2);

    const polynomialTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder(java.newByte(3));

    const powerTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين نقطة تقاطع خط الاتجاه**

استخدم [setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept) لتثبيت قيمة Y لخط الاتجاه عند X = 0. يدعم هذا الإعداد خطوط الاتجاه الخطية، الأسية، والمتعددة الحدود.

على سبيل المثال، قد يحتاج نموذج تكلفة الإنتاج إلى البدء بتكاليف ثابتة معروفة قدرها 100، حتى عندما تشير القياسات عند مستويات إنتاج غير صفرية إلى خط أساس مختلف. بالنسبة لخط الاتجاه الخطي، يقيّد تثبيت نقطة التقاطع المعادلة `y = ax + b` لتصبح `b = 100`؛ يتم تعديل الانحدار وفق البيانات تحت هذا القيد. لا يقوم بذلك فقط بنقل خط تم تثبيته مسبقًا. تتحكم إعدادات تقاطع المحاور في مكان التقاء محاور المخطط، لا في معاملات خط الاتجاه المتناسب.

ينشئ المثال التالي مخططًا مبعثرًا (XY) بأحجام إنتاج تتراوح من 1 إلى 4 وتكاليف 170، 200، 230، و260. يحفظ المخطط بنقطة التقاطع التلقائية الافتراضية، ثم يضبط نقطة التقاطع إلى 100، ويحفظ نسخة PPTX ثانية. يختلف الملفان فقط في إعداد نقطة التقاطع. يعرض خط الاتجاه معادلته ويمتد مرة أخرى إلى X = 0.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const nameCell = workbook.getCell(0, 0, 1, "Production cost");
    const series = chart.getChartData().getSeries().add(nameCell, aspose.slides.ChartType.ScatterWithMarkers);
    const costs = [170, 200, 230, 260];

    for (let i = 0; i < costs.length; i++) {
        const xCell = workbook.getCell(0, i + 1, 0, i + 1);
        const yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    const trendline = series.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", aspose.slides.SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مع الحساب التلقائي، تُنتج هذه البيانات المعادلة `y = 30x + 140`. ضبط نقطة التقاطع إلى 100 ينتج تقريبًا المعادلة `y = 43.33x + 100`: القيمة المتطابقة عند الصفر تتطابق مع الخط الأساسي المعرف، بينما لم يعد الخط يمر عبر كل نقطة بيانات.

| نقطة تقاطع تلقائية | نقطة تقاطع ثابتة 100 |
| --- | --- |
| ![خط اتجاه خطي مع نقطة تقاطع محسوبة تلقائيًا 140](intercept-automatic.png) | ![خط اتجاه خطي مع نقطة تقاطع ثابتة 100](intercept-fixed.png) |

تستخدم الصورتان نفس البيانات ومقاييس المحاور. تمتد خطوط الاتجاه مرة أخرى إلى X = 0 لإظهار نقاط التقاطع.

بشكل افتراضي، يُعيد [getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept) القيمة `NaN`، التي تمثل نقطة تقاطع غير محددة بدلاً من الصفر. ثم تُحسب نقطة التقاطع تلقائيًا من البيانات.

## **إضافة خط مخصص**

الخط المخصص هو شكل يُرسم فوق المخطط بدلاً من أن يكون خط اتجاه يُحسب من بيانات السلسلة. يستخدم هذا المثال [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape) لإضافة خط أفقي إلى الشريحة فوق المخطط. يتم تحديد موضع الخط بإحداثيات الشريحة، مقاسًا بالنقاط، لذا يبدأ عند الحافة اليسرى للمخطط ويقع في منتصف ارتفاع المخطط. يتطابق عرضه مع عرض المخطط. تُعطي الدالة [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) الخط لونًا أحمر صلب.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);

    const line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

    presentation.save("AddCustomLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**ما معنى 'forward' و 'backward' لخط الاتجاه؟**

إنهما طولان لخط الاتجاه المُسقَط إلى الأمام/الخلف: بالنسبة لمخططات المبعثر (XY) — بوحدات المحور؛ بالنسبة للمخططات غير المبعثرة — بعدد الفئات. يُسمح فقط بالقيم غير السالبة.

**هل سيُحفظ خط الاتجاه عند تصدير العرض التقديمي إلى PDF أو SVG، أو عند تحويل شريحة إلى صورة؟**

نعم. تقوم Aspose.Slides بتحويل العروض التقديمية إلى [PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/) أو [SVG](/slides/ar/nodejs-java/render-a-slide-as-an-svg-image/) وتعرض المخططات كصور؛ تُحفظ خطوط الاتجاه، كجزء من المخطط، خلال هذه العمليات. كما تتوفر طريقة لـ [تصدير صورة للمخطط](/slides/ar/nodejs-java/create-shape-thumbnails/) نفسها.