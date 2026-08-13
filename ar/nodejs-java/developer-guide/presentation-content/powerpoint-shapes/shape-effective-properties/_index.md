---
title: احصل على خصائص الشكل الفعّالة من العروض التقديمية في JavaScript
linktitle: خصائص فعّالة
type: docs
weight: 50
url: /ar/nodejs-java/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- نظام الإضاءة
- شكل الحافة
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- العرض التقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية استخدام Aspose.Slides لـ Node.js عبر Java للتمييز بين تنسيق الشكل المحلي والوراثي والفعّال في عروض PowerPoint التقديمية."
---
## **فهم الخصائص المحلية والوراثية والفعّالة**

يمكن أن يأتي تنسيق PowerPoint من عدة مصادر. القيمة المخزنة مباشرة على كائن هي **القيمة المحلية**. إذا لم يتم تعيين تلك القيمة، يبحث PowerPoint في مصادر تنسيق الوالدين، مثل الإعداد الافتراضي للفقرة، نمط النص، تخطيط أو شريحة رئيسية، سمة، أو الإعدادات الافتراضية على مستوى العرض التقديمي. تلك القيم هي **القيم الوراثية**. القيمة التي تبقى بعد حل كامل التسلسل الهرمي هي **القيمة الفعّالة**—القيمة المستخدمة لعرض الكائن.

على سبيل المثال، قد لا تُحدِّد قطعة نصية ارتفاع الخط الخاص بها. تكون قيمتها المحلية [getFontHeight](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portionformat/#getFontHeight) حينها `NaN`، مما يعني "غير محدد هنا". يمكن للقطعة أن ترث الارتفاع من الفقرة، نمط النص الافتراضي للعرض التقديمي، أو مصدر آخر قابل للتطبيق. استدعاء [getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portionformat/#getEffective) على تنسيق القطعة يُعيد الارتفاع النهائي المحلول.

استخدم نوعي بيانات التنسيق لأغراض مختلفة:

- اقرأ أو عدل كائن تنسيق محلي، مثل [PortionFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portionformat/)، عندما تحتاج إلى التحكم في المكان الذي تُعرّف فيه القيمة.
- اقرأ **البيانات الفعّالة** التي تُرجعها `PortionFormat.getEffective` عندما تحتاج إلى النتيجة النهائية المُعرضة. البيانات الفعّالة للقراءة فقط.

قبل تشغيل الأمثلة، [install Aspose.Slides for Node.js via Java](/slides/ar/nodejs-java/installation/).

## **مقارنة القيم المحلية والوراثية والفعّالة**

المثال الكامل التالي ينشئ شكلاً ويطبّق ارتفاعات الخط على مستويات العرض التقديمي، الفقرة، والقطعة. كل خطوة تُطبع القيم المحددة في تلك المستويات والقيمة الفعّالة الناتجة لنفس قطعة النص. كما يُظهر لماذا يجب قراءة البيانات الفعّالة مرة أخرى بعد تغييرات التنسيق.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // قراءة البيانات الفعّالة بعد التغييرات السابقة.
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // تحديد القيم الوراثية على مستويين مختلفين.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // القيمة المحلية للقطعة تتجاوز القيمتين الوراثيتين.
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // تغيير قيمة وراثية لا يتجاوز القيمة المحلية الحالية.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // مسح القيمة المحلية. القطعة الآن ترث من الفقرة مرة أخرى.
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // مسح قيمة الفقرة. الآن يستخدم الإعداد الافتراضي للعرض التقديمي النتيجة.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الأولوية في هذا المثال هي تنسيق القطعة المحلي، ثم تنسيق الفقرة، ثم الإعداد الافتراضي للعرض التقديمي. يمكن لكائنات أخرى أن يكون لها سلاسل وراثة مختلفة، لكن المبدأ هو نفسه: القيمة الصريحة الأكثر تحديدًا تفوز، وتُعيد [getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portionformat/#getEffective) النتيجة النهائية.

## **الحصول على الخصائص النصية الفعّالة**

تنقسم تنسيقات النص عبر عدة كائنات:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/#getEffective) يحل خصائص إطار النص مثل الهوامش، التثبيت، الملاءمة التلقائية، والاتجاه العمودي للنص.
- [TextStyle.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textstyle/#getEffective) يحل تنسيق الفقرة لكل مستوى من مستويات نمط النص.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#getEffective) يحل خصائص الفقرة مثل المحاذاة، الإزاحة، والنقاط.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portionformat/#getEffective) يحل خصائص الحرف مثل ارتفاع الخط، نوع الخط، اللون، الوزن، والمائل.

في المثال التالي، يجب أن يحتوي `text-formatting.pptx` على شريحة واحدة على الأقل وعلى [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) بإطار نص غير فارغ. يمكن للـ AutoShape أن يكون في أي موقع داخل مجموعة الأشكال؛ يبحث الكود عن كائن مناسب ويُتحقق منه قبل الاستخدام.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **الحصول على الخصائص الثلاثية الأبعاد الفعّالة**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getEffective) يُعيد كائن بيانات فعّال واحد يجمع جميع إعدادات 3D المحلولة. تُظهر طرقه [getCamera](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getCamera)، [getLightRig](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getLightRig)، [getBevelTop](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getBevelTop)، و[getBevelBottom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getBevelBottom) البيانات الفعّالة المقابلة. قراءة هذه الإعدادات المتعلقة معًا تُسهل فهم الشكل النهائي ثلاثي الأبعاد.

في هذا المثال، يجب أن يحتوي `shape-3d.pptx` على شكل واحد على الأقل في شريحته الأولى. طبّق إعدادات كاميرا 3D أو إضاءة أو حافة لهذا الشكل إذا أردت أن يحتوي الناتج على قيم غير القيم الافتراضية.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **الحصول على تنسيق الجدول الفعّال**

يمكن أن يأتي تنسيق الجدول من نمط الجدول أو من التنسيقات المطبقة على الجدول كاملًا أو عمود أو صف أو خلية فردية. عند حدوث تعارض بين التعبئات المحددة صراحةً، تكون الأولوية للخلية، ثم الصف، ثم العمود، ثم الجدول بأكمله. التنسيق الفعّال للخلية هو التنسيق النهائي المستخدم لرسم تلك الخلية.

في هذا المثال، يجب أن يحتوي `table-formatting.pptx` على جدول واحد على الأقل في شريحته الأولى. يجب أن يحتوي الجدول على صف وعمود واحد على الأقل. يبحث الكود عن [Table](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/table/) بدلًا من الافتراض بأن `getShapes().get_Item(0)` هو جدول.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

إذا كنت تحتاج إلى اللون بدلاً من نوع التعبئة فقط، تحقق أولاً من [getFillType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fillformat/#getFillType) الفعّال، ثم اقرأ الطريقة المناسبة لذلك النوع—على سبيل المثال، [getSolidFillColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) لتعبئة صلبة.

## **إعادة قراءة البيانات الفعّالية بعد التغييرات**

البيانات الفعّالية تصف تسلسل تنسيق القيم في وقت حلها. استدعِ `getEffective` مرة أخرى بعد تعديل أي شيء يمكن أن يُشارك في ذلك التسلسل، بما في ذلك:

- تنسيق الكائن المحلي؛
- الإعدادات الافتراضية للفقرة أو إطار النص؛
- نمط جدول أو جدول أو عمود أو صف أو تنسيق خلية؛
- تنسيق تخطيط أو شريحة رئيسية؛
- بيانات السمة أو الإعدادات الافتراضية على مستوى العرض التقديمي؛
- التخطيط أو الشريحة الرئيسية المعيَّنة لشريحة.

لا تحتفظ بكائن بيانات فعّالية كلقطة ثابتة. قد يقوم Aspose.Slides بتخزين بعض البيانات الفعّالية مؤقتًا داخليًا، ويمكن لاستدعاء `getEffective` لاحقًا تحديث تلك البيانات. إذا كنت بحاجة إلى مقارنة القيم قبل وبعد التغيير، انسخ القيم العددية التي تحتاجها—مثل ارتفاع الخط أو اللون أو المحاذاة أو عرض الحافة—في متغيّراتك الخاصة قبل إجراء التغيير.

لتغيير قيمة ما، حدّث كائن التنسيق المحلي المناسب ثم استدعِ `getEffective` للتحقق من النتيجة. كائنات البيانات الفعّالية نفسها للقراءة فقط.

## **الأسئلة الشائعة**

**كيف يمكنني معرفة المستوى الذي زود القيمة الفعّالة؟**

البيانات الفعّالة تحتوي على القيمة النهائية فقط، ليست مصدرها. افحص الكائنات المحلية القابلة للتطبيق بدءًا من المستوى الأكثر تحديدًا باتجاه الخارج. بالنسبة للنص، قد يشمل ذلك القطعة، الفقرة، إطار النص، التخطيط، الشريحة الرئيسية، السمة، وإعدادات العرض التقديمي الافتراضية. القيم غير المعرفة مثل `NaN` أو `null` تشير إلى أن البحث يستمر إلى مستوى آخر.

**ماذا يحدث إذا لم يحدد أي مستوى خاصية ما؟**

يقوم Aspose.Slides بحل القيمة الافتراضية المناسبة لـ PowerPoint أو للمكتبة. تظهر تلك القيمة المحلولة في البيانات الفعّالة رغم عدم تعريف أي كائن محلي لها صراحةً.

**لماذا تكون القيمة الفعّالة أحيانًا مساوية للقيمة المحلية؟**

فازت القيمة المحلية في حساب الوراثة. هذا متوقع عندما تُحدد الخاصية صراحةً على الكائن ولا يتجاوزها قاعدة أكثر تحديدًا.

**متى ينبغي استخدام البيانات المحلية بدلًا من البيانات الفعّالية؟**

استخدم البيانات المحلية لتفحص أو تعديل مستوى تنسيق محدد. استخدم البيانات الفعّالية عندما تحتاج إلى المظهر النهائي بعد حل الوراثة، قواعد السمة، والأنماط المطبقة. يوضح مثال [المقارنة الكامل](#compare-local-inherited-and-effective-values) كلا الأمرين في نفس سير العمل.