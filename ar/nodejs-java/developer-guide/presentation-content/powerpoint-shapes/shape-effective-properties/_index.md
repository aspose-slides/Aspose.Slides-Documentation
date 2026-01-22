---
title: الحصول على الخصائص الفعالة للأشكال من العروض التقديمية في JavaScript
linktitle: الخصائص الفعالة
type: docs
weight: 50
url: /ar/nodejs-java/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- إضاءة التجهيز
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
description: "اكتشف كيف تقوم Aspose.Slides for Node.js عبر Java بحساب وتطبيق الخصائص الفعالة للأشكال للحصول على عرض PowerPoint دقيق."
---

في هذا الموضوع، سنناقش الخصائص **الفعالة** و **المحلية**. عندما نقوم بتعيين القيم مباشرةً في هذه المستويات

1. في خصائص الجزء على شريحة الجزء؛
1. في نمط نص الشكل النموذجي على الشريحة التخطيطية أو الشريحة الرئيسية (إذا كان لشكل إطار النص للجزء أحدهما)؛
1. في إعدادات النص العامة للعرض التقديمي؛

تُسمى تلك القيم **القيم المحلية**. في أي مستوى، يمكن تعريف **القيم المحلية** أو إهمالها. ولكن عندما يحتاج التطبيق إلى معرفة كيف يجب أن يبدو الجزء، يستخدم **القيم الفعالة**. يمكنك الحصول على القيم الفعالة باستخدام طريقة **getEffective()** من التنسيق المحلي.

يظهر لك هذا المثال البرمجي كيفية الحصول على القيم الفعالة:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    var effectiveTextFrameFormat = localTextFrameFormat.getEffective();
    var localPortionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    var effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الحصول على الخصائص الفعالة للكاميرا**
يسمح Aspose.Slides for Node.js عبر Java للمطورين بالحصول على الخصائص الفعالة للكاميرا. لهذا الغرض، أضيفت الفئة **CameraEffectiveData** إلى Aspose.Slides. تمثل الفئة **CameraEffectiveData** كائنًا غير قابل للتغيير يحتوي على خصائص الكاميرا الفعالة. يُستخدم كائن من فئة **CameraEffectiveData** كجزء من فئة **ThreeDFormatEffectiveData**، والتي هي زوج [القيم الفعالة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) للصف [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) class.

يظهر لك هذا المثال البرمجي كيفية الحصول على الخصائص الفعالة للكاميرا:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective camera properties =");
    console.log("Type: " + threeDEffectiveData.getCamera().getCameraType());
    console.log("Field of view: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    console.log("Zoom: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الحصول على الخصائص الفعالة لـ Light Rig**
يسمح Aspose.Slides for Node.js عبر Java للمطورين بالحصول على الخصائص الفعالة لـ Light Rig. لهذا الغرض، أضيفت الفئة **LightRigEffectiveData** إلى Aspose.Slides. تمثل الفئة **LightRigEffectiveData** كائنًا غير قابل للتغيير يحتوي على خصائص إضاءة التجهيز الفعالة. يُستخدم كائن من فئة **LightRigEffectiveData** كجزء من فئة **ThreeDFormatEffectiveData**، والتي هي زوج [القيم الفعالة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) للصف [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) class.

يظهر لك هذا المثال البرمجي كيفية الحصول على الخصائص الفعالة لـ Light Rig:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective light rig properties =");
    console.log("Type: " + threeDEffectiveData.getLightRig().getLightType());
    console.log("Direction: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الحصول على الخصائص الفعالة لشكل الحافة**
يسمح Aspose.Slides for Node.js عبر Java للمطورين بالحصول على الخصائص الفعالة لشكل الحافة. لهذا الغرض، أضيفت الفئة **ShapeBevelEffectiveData** إلى Aspose.Slides. تمثل الفئة **ShapeBevelEffectiveData** كائنًا غير قابل للتغيير يحتوي على خصائص بروز وجه الشكل الفعالة. يُستخدم كائن من فئة **ShapeBevelEffectiveData** كجزء من فئة **ThreeDFormatEffectiveData**، والتي هي زوج [القيم الفعالة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) للصف [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) class.

يظهر لك هذا المثال البرمجي كيفية الحصول على الخصائص الفعالة لشكل الحافة:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + threeDEffectiveData.getBevelTop().getBevelType());
    console.log("Width: " + threeDEffectiveData.getBevelTop().getWidth());
    console.log("Height: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الحصول على الخصائص الفعالة لإطار النص**
باستخدام Aspose.Slides for Node.js عبر Java، يمكنك الحصول على الخصائص الفعالة لإطار النص. لهذا الغرض، أضيفت الفئة **TextFrameFormatEffectiveData** إلى Aspose.Slides. تحتوي على خصائص تنسيق إطار النص الفعالة.

يظهر لك هذا المثال البرمجي كيفية الحصول على خصائص تنسيق إطار النص الفعالة:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();
    console.log("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    console.log("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    console.log("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    console.log("Margins");
    console.log("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    console.log("   Top: " + effectiveTextFrameFormat.getMarginTop());
    console.log("   Right: " + effectiveTextFrameFormat.getMarginRight());
    console.log("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الحصول على الخصائص الفعالة لنمط النص**
باستخدام Aspose.Slides for Node.js عبر Java، يمكنك الحصول على الخصائص الفعالة لنمط النص. لهذا الغرض، أضيفت الفئة **TextStyleEffectiveData** إلى Aspose.Slides. تحتوي على خصائص نمط النص الفعالة.

يظهر لك هذا المثال البرمجي كيفية الحصول على خصائص نمط النص الفعالة:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    for (var i = 0; i <= 8; i++) {
        var effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        console.log(("= Effective paragraph formatting for style level #" + i) + " =");
        console.log("Depth: " + effectiveStyleLevel.getDepth());
        console.log("Indent: " + effectiveStyleLevel.getIndent());
        console.log("Alignment: " + effectiveStyleLevel.getAlignment());
        console.log("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الحصول على قيمة ارتفاع الخط الفعالة**
باستخدام Aspose.Slides for Node.js عبر Java، يمكنك الحصول على الخصائص الفعالة لارتفاع الخط. هنا نوفر مثالًا يُظهر تغيير قيمة ارتفاع الخط الفعالة للجزء بعد ضبط قيم ارتفاع الخط المحلية على مستويات بنية العرض المختلفة:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();
    var portion0 = new aspose.slides.Portion("Sample text with first portion");
    var portion1 = new aspose.slides.Portion(" and second portion.");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    console.log("Effective font height after setting entire presentation default font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    pres.save("SetLocalFontHeightValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الحصول على تنسيق التعبئة الفعال للجدول**
باستخدام Aspose.Slides for Node.js عبر Java، يمكنك الحصول على تنسيق التعبئة الفعال لأجزاء منطقية مختلفة في الجدول. لهذا الغرض، أضيفت الفئة **CellFormatEffectiveData** إلى Aspose.Slides. تحتوي على خصائص تنسيق التعبئة الفعالة. يرجى ملاحظة ما يلي: تنسيق الخلية يحصل دائمًا على الأولوية على تنسيق الصف؛ الصف يحصل على الأولوية على العمود؛ والعمود يحصل على الأولوية على الجدول بأكمله.
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var tableFormatEffective = tbl.getTableFormat().getEffective();
    var rowFormatEffective = tbl.getRows().get_Item(0).getRowFormat().getEffective();
    var columnFormatEffective = tbl.getColumns().get_Item(0).getColumnFormat().getEffective();
    var cellFormatEffective = tbl.get_Item(0, 0).getCellFormat().getEffective();
    var tableFillFormatEffective = tableFormatEffective.getFillFormat();
    var rowFillFormatEffective = rowFormatEffective.getFillFormat();
    var columnFillFormatEffective = columnFormatEffective.getFillFormat();
    var cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

كيف يمكنني معرفة أنني حصلت على “لقطة” بدلاً من “كائن حي”، ومتى يجب علي قراءة الخصائص الفعالة مرة أخرى؟
كائنات EffectiveData هي لقطات غير قابلة للتغيير للقيم التي تم حسابها في لحظة الاستدعاء. إذا قمت بتغيير الإعدادات المحلية أو الموروثة للشكل، استخرج البيانات الفعالة مرة أخرى للحصول على القيم المحدّثة.

هل يؤثر تغيير شريحة التخطيط/الرئيسية على الخصائص الفعالة التي تم استرجاعها بالفعل؟
نعم، ولكن فقط بعد قراءة القيم مرة أخرى. كائن EffectiveData الذي تم الحصول عليه مسبقًا لا يحدث نفسه تلقائيًا—اطلبه مرة أخرى بعد تغيير التخطيط أو الشريحة الرئيسية.

هل يمكنني تعديل القيم عبر EffectiveData؟
لا. EffectiveData للقراءة فقط. قم بتعديل القيم في كائنات التنسيق المحلية (الشكل/النص/3D، إلخ)، ثم احصل على القيم الفعالة مرة أخرى.

ماذا يحدث إذا لم يتم تعيين الخاصية على مستوى الشكل، ولا في التخطيط/الرئيسية، ولا في الإعدادات العامة؟
يتم تحديد القيمة الفعالة بواسطة النظام الافتراضي (القيم الافتراضية لـ PowerPoint/Aspose.Slides). تصبح هذه القيمة المحسومة جزءًا من لقطة EffectiveData.

من قيمة الخط الفعالة، هل يمكنني معرفة المستوى الذي قدم الحجم أو نوع الخط؟
ليس مباشرة. تُعيد EffectiveData القيمة النهائية. لتحديد المصدر، تحقق من القيم المحلية في الجزء/الفقرة/إطار النص والأنماط النصية في التخطيط/الرئيسية/العرض لتحديد أين ظهرت أول تعريف صريح.

لماذا تبدو قيم EffectiveData أحيانًا مطابقة للقيم المحلية؟
لأن القيمة المحلية أصبحت النهائية (لم يتطلب الأمر وراثة من مستوى أعلى). في مثل هذه الحالات، تكون القيمة الفعالة مساوية للقيمة المحلية.

متى يجب استخدام الخصائص الفعالة، ومتى ينبغي العمل فقط بالقيم المحلية؟
استخدم EffectiveData عندما تحتاج إلى النتيجة “كما تم عرضها” بعد تطبيق جميع الوراثات (مثلاً لتطابق الألوان أو المسافات البادئة أو الأحجام). إذا كنت تحتاج إلى تعديل التنسيق في مستوى معين، عدّل الخصائص المحلية ثم، إذا لزم الأمر، أعد قراءة EffectiveData للتحقق من النتيجة.