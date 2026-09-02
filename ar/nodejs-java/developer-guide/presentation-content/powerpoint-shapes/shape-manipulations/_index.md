---
title: إدارة أشكال العرض التقديمي في جافاسكريبت
linktitle: معالجة الأشكال
type: docs
weight: 40
url: /ar/nodejs-java/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على الشريحة
- العثور على الشكل
- استنساخ الشكل
- إزالة الشكل
- إخفاء الشكل
- تغيير ترتيب الشكل
- الحصول على معرّف الشكل Interop
- نص بديل للشكل
- تنسيقات تخطيط الشكل
- الشكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- قلب الشكل
- PowerPoint
- عرض تقديمي
- Node.js
- جافاسكريبت
- Aspose.Slides
description: "تعلم كيفية تحديد، استنساخ، إزالة، إخفاء، إعادة ترتيب، تصدير، محاذاة، وقلب أشكال العرض التقديمي باستخدام Aspose.Slides for Node.js عبر Java."
---
## **نظرة عامة**

Aspose.Slides for Node.js via Java يمثل الأشكال على الشريحة كمجموعة مرتبة من نوع [ShapeCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/). تعتبر المجموعة هي المكان الذي يمكنك من خلاله العثور على الأشكال وتعديلها ومصدر ترتيب تراكبها: الفهرس `0` هو الشكل الخلفي، بينما الفهرس الأخير هو الشكل الأمامى.

يتبع هذا المقال النموذج المذكور. يشرح أولاً كيفية التعرف على الشكل بشكل موثوق، ثم يوضح كيفية استنساخ الشكل، إزالته، إخفائه وإعادة ترتيبه. تغطي الأقسام الأخيرة تنسيق المستوى التخطيطي، تصدير SVG، المحاذاة وإعدادات الانعكاس. كل مثال مستقل، لذا يمكنك استخدام العمليات التي تحتاجها فقط في سير العمل الخاص بك.

## **تحديد وإيجاد الأشكال**

تُعد فهارس المجموعة مريحة عند معالجة ملف معروف، لكنها ليست معرّفات ثابتة. يمكن أن يغيّر إضافة أو إزالة أو إعادة ترتيب شكل فهرسته. اختر معرّفًا وفقًا لكيفية إنشاء العرض التقديمي وصيانته:

- [Name](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/getname/) مفيد للقوالب التي يتحكم فيها المطورون ويسهل فحصه في لوحة التحديد في PowerPoint. يمكن تحرير الأسماء ولا يُضمن أنها فريدة، لذا ضع اتفاقية تسمية إذا كان الكود يعتمد عليها.
- [AlternativeText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/getalternativetext/) مفيد عندما تكون الوصفية لتسهيل الاستخدام أو العلامة التي يضيفها المؤلف قد حدّدت الشكل بالفعل. هي مرئية للمستخدمين، قد تُترجم أو تُعاد صياغتها لتسهيل الاستخدام، ولا يُضمن أنها فريدة. لا تعِد إعادة استعمال نص توضيحي ذي معنى كمفتاح قاعدة بيانات دون إخبار المستخدم.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) معرّف للقراءة فقط وفريد داخل الشريحة ويتطابق مع معرف الشكل المستخدم في تفاعل PowerPoint. استخدمه عند التكامل مع PowerPoint أو عندما تحتاج إلى مرجع لا لبس فيه طوال عمر الشكل. الشكل المستنسخ أو المعاد إنشاؤه يُعطي معرفًا مختلفًا.

الطريقة المرتبطة [getUniqueId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/getuniqueid/) تُعيد معرّفًا بنطاق العرض التقديمي، لكن هذا المعرف مخصص للإضافات ويمكن إعادة تعيينه. لا يُنظر إليه كمفتاح خارجي دائم. إذا كانت الهوية طويلة الأمد ضرورية، احفظ التخطيط في بيانات التطبيق وتحقق من أن الشكل المتوقع لا يزال موجودًا.

المثال التالي يبحث عن اسم مع مقارنة دقيقة ويُبلغ عن معرف Interop نطاق الشريحة. عندما لا يحتوي القالب على الشكل المتوقع، يُظهر الكود النتيجة بدلاً من المتابعة مع كائن خاطئ.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

عندما تكون العملية خاصة بنوع شكل ما، تحقق من الفئة في وقت التشغيل قبل استخدام الأعضاء الخاصة بالنوع. يُظهر هذا المثال كيفية تحديث النص والنص البديل فقط إذا كان الكائن المُسمى من نوع [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/).

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **تعديل مجموعة الأشكال**

تعمل طرق الإضافة، الاستنساخ، الإزالة وإعادة الترتيب مباشرة على المجموعة. إذا غيّرت عملية ما عدد الأشكال أو ترتيبها، لا تستمر في الاعتماد على الفهارس التي تم التقاطها قبل تلك العملية.

### **استنساخ شكل**

[addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/addclone/) يُنشئ نسخة مستقلة ويضيفها إلى نهاية المجموعة المستهدفة. [insertClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/insertclone/) يخلق نسخة أيضًا لكنه يضعها عند فهرس Z‑order محدد. الإصدارات التي تقبل إحداثيات تنقل النسخة دون تغيير حجمها؛ الإصدارات التي تقبل العرض والارتفاع يمكنها تغيير الحجم كذلك.

المثال يُنشئ شريحة هدف، يستنسخ مستطيلًا مُعنونًا إلى الأمام، ويُدرج نسخة ثانية في الخلف. لا تُغيّر التعديلات على أي نسخة المصدر.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الاستنساخ ينسخ محتوى الشكل وتنسيقه، بما في ذلك اسمه والنص البديل. عيّن معرّفات منطقية جديدة للنسخة عندما يجب أن تكون هذه القيم فريدة. الموارد المستخدمة من قبل الأشكال المعقّدة يديرها العرض التقديمي، لكن النسخة تظل عنصرًا جديدًا في المجموعة له هوية شكل جديدة.

### **إزالة أشكال**

[remove](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/remove/) يحذف كائن شكل محدد من مجموعته. عند إزالة عدة مطابقة أثناء التكرار المفهرس، عبّر من النهاية بحيث يظل كل فهرس متبقي صالحًا.

هذا المثال يزيل كل شكل يحمل اسمًا معينًا. يقرأ الشكل عند الفهرس الحالي ولا يفترض نوعًا معينًا.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

بعد الإزالة، يتغيّر عدد الأشكال وفهارس الأشكال اللاحقة. تبقى المراجع إلى الأشكال غير المتأثرة أكثر موثوقية من الفهارس المخزنة. ضع في الحسبان الموصلات، الرسوم المتحركة وميزات العرض التقديمي الأخرى التي قد تشير إلى الكائن المُزال؛ قد يغيّر حذف شكل مرئي أكثر من مجرد مظهر الشريحة.

### **إخفاء شكل**

ضبط [Hidden](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/sethidden/) إلى `true` يبقي الشكل في المجموعة ولكن يمنعه من الظهور في العرض العادي. يظل فهرسه وتنسيقه ومحتواه متاحًا للشفرة، لذا يُعتبر الإخفاء مناسبًا للعناصر الاختيارية التي قد تُستعاد لاحقًا.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الإخفاء ليس حذفًا ولا أمانًا. لا يزال بإمكان المستخدم أو الشفرة اكتشاف الكائن وإظهارّه مرة أخرى، ويظل جزءًا من ملف العرض التقديمي.

### **تغيير ترتيب Z**

الأشكال المتداخلة تُرسم بترتيب المجموعة. [reorder](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/reorder/) ينقل شكلًا موجودًا إلى فهرس هدف دون استنساخه. الفهرس `0` هو الخلف، `size() - 1` هو الأمام.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يُنشأ المستطيل أولًا ويقع في البداية خلف القطعة الناطقة. نقله إلى الفهرس النهائي يجعله في الأمام. أكّد ترتيب Z بعد إضافة أو استنساخ جميع الأشكال المرتبطة، لأن تلك العمليات تُضيف أو تُدرج عناصر مجموعة جديدة وقد تُغيّر التراص المقصود.

## **فحص الأشكال على شرائح التخطيط**

الشرائح العادية، شرائح التخطيط والشرائح الرئيسية لها مجموعات أشكال منفصلة. الشكل داخل مجموعة التخطيط ليس هو نفس الكائن الموجود على شريحة عادية بنفس الموضع. افحص أشكال التخطيط عندما تحتاج إلى فهم أو تغيير تنسيق مقدم من تخطيط.

المثال التالي يقرأ كل شكل في التخطيط ويستخرج خصائص [FillFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/getfillformat/) و[LineFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/getlineformat/) دون افتراض أن كل شكل هو `AutoShape`.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

تحرير تخطيط قد يؤثر على عدة شرائح تستخدمه. قبل تغيير شكل تخطيط، حدّد ما إذا كانت الشريحة العادية ترث الكائن أو تحتوي على تعديل محلي، واختبر كل شريحة تستخدم ذلك التخطيط.

## **تصدير شكل إلى SVG**

[writeAsSvg](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/writeassvg/) يكتب المحتوى المرسوم لشكل واحد إلى دفق. النتيجة تحتوي على الشكل فقط، لا الخلفية الكاملة للشريحة أو الأشكال المجاورة.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

احافظ على فتح العرض التقديمي أثناء التصدير. يعتمد الناتج على تنسيق الشكل وعلى موارد مثل الخطوط والصور. إذا كنت بحاجة إلى التكوين الكامل، صدّر الشريحة بدلاً من الشكل الفردي. يتحكم المستدعي في الدفق ويجب أن يغلقه.

## **محاذاة الأشكال**

الطريقة [SlideUtil.alignShapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideutil/alignshapes/) لديها إصدارات تُحاذِّـئ كل الأشكال أو فهارس مجموعة مختارة. النوع [ShapesAlignmentType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapesalignmenttype/) يُحدّد الحافة أو الخط المركزي أو وضع التوزيع. ضع `alignToSlide` إلى `true` لاستخدام حواف الشريحة؛ وضعه إلى `false` لمحاذاة الأشكال المختارة بالنسبة لبعضها البعض.

هذا المثال يُحاذِّـئ ثلاثة أشكال إلى الحافة العلوية للشريحة. تُحوَّل مراجع الأشكال المعادة إلى فهارسها الحالية فورًا قبل المحاذاة.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المحاذاة تُغيِّر المواقع، لا ترتيب Z. عادةً ما تحتاج المحاذاة النسبية إلى شكلين على الأقل، بينما يتطلب التوزيع الأفقي أو العمودي عددًا كافيًا من الأشكال لتحديد الفواصل. أعد حساب الفهارس إذا عدلت المجموعة قبل استدعاء الطريقة.

## **قلب شكل**

الفئة [ShapeFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapeframe/) تُخزّن الموضع، الحجم، إعدادات القفل الأفقي والرأسي، والدوران. قيمتي `getFlipH` و`getFlipV` تستخدم نوع [NullableBool](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/nullablebool/): `True` يُفعِّل القلب، `False` يُعطّله، و`NotDefined` يحافظ على الحالة غير المحددة/الافتراضية.

العرض التقديمي المدخل أدناه يحتوي على شكل غير مقلوب.

![The shape before flipping](shape_to_be_flipped.png)

المثال يحافظ على كل قيم الإطار الأخرى ويستبدل إعدادات القلب فقط. هذا مهم لأن تعيين [Frame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/setframe/) جديد يستبدل الإطار بالكامل.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الشكل المحفوظ يتم عكسه أفقيًا وعموديًا مع الحفاظ على موضعه وحجمه ودورانه.

![The shape after flipping](flipped_shape.png)

## **الأسئلة المتكررة**

**هل يجب استخدام فهرس المجموعة كمُعرّف للشكل؟**

فقط للمعالجة قصيرة الأمد عندما لا تتغير المجموعة قبل استخدام الفهرس. يُفضَّل اعتماد اتفاقية `Name` أو `AlternativeText` للقوالب المُصمَّمة، أو `OfficeInteropShapeId` للعمل مع Interop بنطاق الشريحة.

**هل إخفاء الشكل يزيله من ترتيب Z؟**

لا. يظل الشكل المخفي داخل المجموعة بنفس الفهرس. يمكن العثور عليه، إعادة ترتيبه، تحريره أو إظهاره مرة أخرى.

**لماذا ظهر الشكل المستنسخ أمام شكل آخر؟**

`addClone` يُضيف النسخة إلى نهاية المجموعة، والتي تمثل الأمام في ترتيب Z. استخدم `insertClone` لتحديد الفهرس الأولي أو `reorder` بعد إضافة جميع الأشكال.