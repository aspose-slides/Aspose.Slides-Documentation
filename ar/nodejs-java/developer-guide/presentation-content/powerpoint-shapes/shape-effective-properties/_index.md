---
title: الخصائص الفعالة للشكل
type: docs
weight: 50
url: /ar/nodejs-java/shape-effective-properties/
---

في هذا الموضوع، سنناقش الخصائص **effective** و **local**. عندما نقوم بتعيين القيم مباشرةً على هذه المستويات

1. في خصائص الجزء على شريحة الجزء؛
1. في نمط نص الشكل النموذجي على شريحة التخطيط أو الشريحة الرئيسية (إذا كان شكل الإطار النصي للجزء يمتلك واحدًا)؛
1. في إعدادات النص العالمية للعرض التقديمي؛

تُسمى تلك القيم **local**. في أي مستوى، يمكن تعريف قيم **local** أو إغفالها. ولكن عندما تحتاج تطبيقًا إلى معرفة مظهر الجزء، يستخدم القيم **effective**. يمكنك الحصول على القيم **effective** باستخدام طريقة **getEffective()** من التنسيق المحلي.

يعرض هذا الكود النموذجي كيفية الحصول على القيم **effective**:
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


## **Getting Effective Properties of the Camera**
يسمح Aspose.Slides for Node.js via Java للمطورين بالحصول على خصائص الكاميرا **effective**. لهذا الغرض، تمت إضافة الفئة [**CameraEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CameraEffectiveData) إلى Aspose.Slides. تمثل فئة [CameraEffectiveData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CameraEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص كاميرا **effective**. تُستخدم نسخة من فئة [**CameraEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CameraEffectiveData) كجزء من فئة [**ThreeDFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormatEffectiveData)، وهي زوج من [القيم **effective**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) لفئة [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

يعرض هذا الكود النموذجي كيفية الحصول على خصائص الكاميرا **effective**:
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


## **Getting Effective Properties of Light Rig**
يسمح Aspose.Slides for Node.js via Java للمطورين بالحصول على خصائص Light Rig **effective**. لهذا الغرض، تمت إضافة الفئة [**LightRigEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRigEffectiveData) إلى Aspose.Slides. تمثل فئة [LightRigEffectiveData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRigEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص Light Rig **effective**. تُستخدم نسخة من فئة [**LightRigEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRigEffectiveData) كجزء من فئة [**ThreeDFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormatEffectiveData)، وهي زوج من [القيم **effective**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) لفئة [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

يعرض هذا الكود النموذجي كيفية الحصول على خصائص Light Rig **effective**:
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


## **Getting Effective Properties of Bevel Shape**
يسمح Aspose.Slides for Node.js via Java للمطورين بالحصول على خصائص Bevel Shape **effective**. لهذا الغرض، تمت إضافة الفئة [**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData) إلى Aspose.Slides. تمثل فئة [ShapeBevelEffectiveData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص التجاويف الوجهية للشكلة **effective**. تُستخدم نسخة من فئة [**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData) كجزء من فئة [**ThreeDFormatEffectiveData**]([**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData))، وهي زوج من [القيم **effective**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) لفئة [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

يعرض هذا الكود النموذجي كيفية الحصول على خصائص Bevel Shape **effective**:
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


## **Getting Effective Properties of a Text Frame**
باستخدام Aspose.Slides for Node.js via Java، يمكنك الحصول على خصائص Text Frame **effective**. لهذا الغرض، تمت إضافة الفئة [**TextFrameFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormatEffectiveData) إلى Aspose.Slides. تحتوي على خصائص تنسيق إطار النص **effective**.

يعرض هذا الكود النموذجي كيفية الحصول على خصائص تنسيق إطار النص **effective**:
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


## **Getting Effective Properties of a Text Style**
باستخدام Aspose.Slides for Node.js via Java، يمكنك الحصول على خصائص Text Style **effective**. لهذا الغرض، تمت إضافة الفئة [**TextStyleEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextStyleEffectiveData) إلى Aspose.Slides. تحتوي على خصائص نمط النص **effective**.

يعرض هذا الكود النموذجي كيفية الحصول على خصائص نمط النص **effective**:
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


## **Getting Effective Font Height Value**
باستخدام Aspose.Slides for Node.js via Java، يمكنك الحصول على خصائص ارتفاع الخط **effective**. هنا، نوفر كودًا يُظهر قيمة ارتفاع الخط **effective** للجزء والتي تتغير بعد تعيين قيم ارتفاع الخط المحلية على مستويات مختلفة من هيكلة العرض التقديمي:
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


## **Getting Effective Fill Format for Table**
باستخدام Aspose.Slides for Node.js via Java، يمكنك الحصول على تنسيق التعبئة **effective** لجداول مختلفة. لهذا الغرض، تمت إضافة الفئة [**CellFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CellFormatEffectiveData) إلى Aspose.Slides. تحتوي على خصائص تنسيق التعبئة **effective**. يرجى ملاحظة ما يلي: تنسيق الخلية يحصل دائمًا على الأولوية على تنسيق الصف؛ والصف يحصل على الأولوية على العمود؛ والعمود يحصل على الأولوية على كامل الجدول.
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


## **FAQ**

**How can I tell that I got a "snapshot" rather than a "live object," and when should I read effective properties again?**

كائنات EffectiveData هي لقطات ثابتة للقيم المحسوبة في وقت الاستدعاء. إذا قمت بتغيير الإعدادات المحلية أو الموروثة للشكل، استرجع البيانات **effective** مرة أخرى للحصول على القيم المحدثة.

**Does changing the layout/master slide affect effective properties that have already been retrieved?**

نعم، ولكن فقط بعد قراءتها مرة أخرى. كائن EffectiveData المستخرج مسبقًا لا يتم تحديثه تلقائيًا—اطلبه مرة أخرى بعد تعديل التخطيط أو الشريحة الرئيسية.

**Can I modify values through EffectiveData?**

لا. EffectiveData للقراءة فقط. قم بإجراء التغييرات في كائنات التنسيق المحلية (shape/text/3D، إلخ)، ثم احصل على القيم **effective** مرة أخرى.

**What happens if a property is not set at the shape level, nor in the layout/master, nor in global settings?**

تحدد القيمة **effective** بواسطة آلية الافتراضية (الافتراضات في PowerPoint/Aspose.Slides). تلك القيمة المح resolved تُصبح جزءًا من لقطة EffectiveData.

**From an effective font value, can I tell which level provided the size or typeface?**

ليس مباشرة. EffectiveData تُعيد القيمة النهائية. لتحديد المصدر، تفقد القيم المحلية على مستوى الجزء/الفقرة/إطار النص والأنماط النصية على التخطيط/الشريحة الرئيسية/العرض التقديمي لمعرفة أين ظهرت التعريف الأول.

**Why do EffectiveData values sometimes look identical to the local ones?**

لأن القيمة المحلية أصبحت نهائية (لم يُستدعَ أي مستوى أعلى). في هذه الحالات تكون القيمة **effective** مطابقة للقيمة المحلية.

**When should I use effective properties, and when should I work only with local ones?**

استخدم EffectiveData عندما تحتاج إلى النتيجة "كما تُعرض" بعد تطبيق جميع الوراثيات (مثل محاذاة الألوان أو المسافات أو الأحجام). إذا كنت بحاجة لتغيير التنسيق على مستوى محدد، عدل الخصائص المحلية ثم، إذا لزم الأمر، أعد قراءة EffectiveData للتحقق من النتيجة.