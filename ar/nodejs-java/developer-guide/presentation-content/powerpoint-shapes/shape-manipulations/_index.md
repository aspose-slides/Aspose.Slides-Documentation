---
title: إدارة أشكال العرض التقديمي في جافا سكريبت
linktitle: معالجة الشكل
type: docs
weight: 40
url: /ar/nodejs-java/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على الشريحة
- العثور على شكل
- استنساخ الشكل
- إزالة الشكل
- إخفاء الشكل
- تغيير ترتيب الشكل
- الحصول على معرف شكل Interop
- نص بديل للشكل
- نقطة ضبط الشكل
- ضبط الشكل المسبق
- هندسة الشكل
- تنسيقات تخطيط الشكل
- الشكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- عكس الشكل
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية التعرف على أشكال العرض التقديمي، وضبطها، واستنساخها، وإزالتها، وإخفائها، وإعادة ترتيبها، وتصديرها، ومحاذاتها، وعكسها باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

Aspose.Slides for Node.js via Java تمثّل الأشكال على الشريحة كـ[ShapeCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/) مرتّبة. تُعد المجموعة هي الموضع الذي يمكنك من خلاله العثور على الأشكال وتعديلها ومصدر ترتيب تراكبها: الفهرس `0` هو الشكل الأبعد إلى الخلف، بينما الفهرس الأخير هو الشكل الأقرب إلى الأمام.

يتبع هذا المقال هذا النموذج. يشرح أولاً كيفية التعرف على الشكل بشكل موثوق وتعديل نقاط ضبط الشكل المسبقة، ثم يظهر كيفية استنساخ، إزالة، إخفاء، وإعادة ترتيب الأشكال. تغطي الأقسام النهائية تنسيق المستوى التخطيطي، تصدير SVG، المحاذاة، وإعدادات الانعكاس. كل مثال مستقل، لذلك يمكنك استخدام العمليات التي يتطلبها سير عملك فقط.

## **التعرّف على الأشكال وإيجادها**

فهارس المجموعة مريحة عند معالجة ملف معروف، لكنها ليست معرفات ثابتة. إضافة أو إزالة أو إعادة ترتيب شكل يمكن أن يغيّر فهرسه. اختر معرفًا وفقًا لكيفية إنشاء العرض التقديمي وصيانته:

- [Name](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/getname/) مفيد للقوالب التي يتحكم فيها المطور وسهل الفحص في لوحة التحديد في PowerPoint. يمكن تعديل الأسماء ولا يُضمن أنها فريدة، لذا ضع اتفاقية تسمية إذا كان الكود يعتمد عليها.
- [AlternativeText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/getalternativetext/) مفيد عندما يكون الوصف المتاح لإمكانية الوصول أو العلامة التي يضيفها المؤلف هي التي تحدد الشكل. هو مرئي للمستخدمين، قد يُترجم أو يُعاد صياغته لإمكانية الوصول، ولا يُضمن أنه فريد. لا تستخدم نص الوصول بمعناه الأصلي كمفتاح قاعدة بيانات بشكل صامت.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) هو معرف للقراءة فقط فريد داخل الشريحة ويتطابق مع معرف الشكل المستخدم من قبل PowerPoint interop. استخدمه عند التكامل مع PowerPoint أو عندما تحتاج إلى إشارة لا لبس فيها طوال عمر الشكل. الشكل المستنسخ أو المُعاد إنشاؤه هو شكل مختلف ويحصل على معرفه الخاص.

الطريقة المرتبطة [getUniqueId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/getuniqueid/) تُعيد معرفًا بنطاق العرض التقديمي، لكن هذا المعرف مخصص للإضافات ويمكن إعادة تعيينه. لا ينبغي اعتباره مفتاحًا خارجيًا دائمًا. إذا كانت الهوية طويلة الأمد ضرورية، احتفظ بالت映映映映映映映映映映映映管 in application data and validate that the expected shape still exists.

المثال التالي يبحث عن الاسم بمقارنة دقيقة ويُبلغ عن معرف Interop الخاص بالشريحة. عندما لا يحتوي القالب على الشكل المتوقع، يُبلغ الكود عن تلك النتيجة بدلاً من المتابعة مع الكائن الخطأ.

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

عند كون العملية خاصة بنوع شكل معين، تحقق من فئة وقت التشغيل قبل استخدام الأعضاء الخاصة بالنوع. هذا المثال يحدّث النص والنص البديل فقط إذا كان الكائن المسَمّى هو [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/).

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

## **التعرّف على تعديلات الشكل المسبقة وتعديلها**

يمكن للأشكال الهندسية المسبقة أن تكشف عن نقاط ضبط تتحكم في ميزات مثل حجم الزاوية، نسب السهم، أو زوايا القوس. يمكن الوصول إليها عبر مجموعة القراءة فقط [GeometryShape.getAdjustments](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/geometryshape/). تُزود الشكل المجموعة نفسها، لكن كل [AdjustValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/adjustvalue/) يحتوي على قيمة يمكن تغييرها.

لا تعتمد فقط على فهرس ثابت للمجموعة. كرّر عبر الضبط وتفقد طريقة القراءة فقط [getType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/adjustvalue/) التي تُعيد قيمة [ShapeAdjustmentType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapeadjustmenttype/) التي تصف ما يتحكم فيه الضبط. طريقة القراءة فقط [getName](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/adjustvalue/getname/) توفر معلومات تعريف إضافية وهي مفيدة خصوصًا عندما يحتوي المسبق على أكثر من ضبط من نفس النوع الدلالي.

استخدم طريقة القيمة التي تتطابق مع معنى الضبط:

| نوع الضبط | الغرض | القيمة لتغييرها |
|---|---|---|
| `CornerSize` | حجم الزوايا المستديرة | [setRawValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | سمك ذيل السهم | `setRawValue` |
| `ArrowheadLength` | طول رأس السهم | `setRawValue` |
| `ArrowheadWidth` | عرض رأس السهم | `setRawValue` |
| `StartAngle` | زاوية البداية لفطيرة أو قوس | [setAngleValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | زاوية النهاية لفطيرة أو قوس | `setAngleValue` |

`getType` و `getName` تُعيد معلومات قراءة فقط. `getRawValue` و `setRawValue` تعمل مع عدد صحيح بوحدات الهندسة الأصلية للمسبق، بينما `getAngleValue` و `setAngleValue` تعمل مع زاوية بالدرجات. عدد، ترتيب، معنى، والنطاق الصحيح للضبط يعتمد على المسبق [GeometryShape.getShapeType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/geometryshape/). قيمة صالحة لمسبق قد تكون غير صالحة أو لها تأثير مختلف لمسبق آخر.

عندما تُعيد `getType` القيمة `ShapeAdjustmentType.Custom`، لا تتعرف الـ API على معنى دلالي قياسي. تفقد `getName`، نوع المسبق، والقيمة الحالية، واترك الضبط دون تغيير ما لم تكن تعرف المعنى والنطاق المتوقعين. حتى للأنواع المعروفة، تحقق مما إذا كان نفس النوع يظهر أكثر من مرة قبل اختيار قيمة. تُظهر مقالة [Connector](/slides/ar/nodejs-java/connector/) هذا الوضع مع ضبط انحناء الموصل.

المثال الكامل التالي يُنشئ نسخًا افتراضية ومعدّلة من ثلاثة أشكال مسبقة. يكرّر عبر كل ضبط، يُبلغ عن اسمه ونوعه، يغيّر القيم المرتبطة بالحجم عبر `setRawValue`، ويغيّر الزوايا عبر `setAngleValue`، ويحفظ النتيجة. العمود الأيسر يحتفظ بالهندسة الافتراضية؛ العمود الأيمن يُظهر المستطيل المستدير المعدل، السهم الرباعي الاتجاهات، والفطيرة.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // يضيف عناوين لأعمدة الشكل الافتراضي والمعدّل.
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

التحقق من النوع الدلالي قبل تغيير القيمة يجعل الكود صريحًا بشأن نواياه ويتجنب الافتراض بأن فهرس مجموعة معين له نفس المعنى عبر أشكال مسبقة مختلفة.

## **تعديل مجموعة الأشكال**

تعمل طرق الإضافة، الاستنساخ، الإزالة، وإعادة الترتيب على المجموعة فورًا. إذا غيّرت عملية ما عدد الأشكال أو ترتيبها، لا تستمر بالاعتماد على الفهارس التي تم التقاطها قبل تلك العملية.

### **استنساخ شكل**

[addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/addclone/) يُنشئ نسخة مستقلة ويضيفها إلى نهاية المجموعة الهدف. [insertClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/insertclone/) أيضًا يُنشئ نسخة لكنه يضعها عند فهرس ترتيب z محدد. التحميلات التي تقبل إحداثيات تنقل النسخة دون تغيير حجمها؛ التحميلات التي تشمل العرض والارتفاع يمكنها تغيير الحجم كذلك.

المثال يُنشئ شريحة هدف، يستنسخ مستطيلًا مُعنونًا إلى الأمام، ويُدخل نسخة ثانية إلى الخلف. لا تغيّر التغييرات التي تُجرى على أي نسخة مصدر الشكل.

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

الاستنساخ ينسخ محتوى الشكل وتنسيقه، بما في ذلك اسمه والنص البديل. عيّن معرّفات منطقية جديدة للنسخة عندما يجب أن تكون تلك القيم فريدة. الموارد المستخدمة من قبل الأشكال المعقّدة يديرها العرض التقديمي، لكن النسخة تظل عنصرًا جديدًا في المجموعة بمعرف شكل جديد.

### **إزالة الأشكال**

[remove](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/remove/) يزيل كائن شكل محدد من مجموعته. عند إزالة تطابقات متعددة أثناء تكرار بالفهارس، تجول من النهاية حتى يبقى كل فهرس متبقي صالحًا.

هذا المثال يزيل كل شكل يحمل اسمًا معينًا. يقرأ الشكل عند الفهرس الحالي ولا يفترض نوع شكل محدد.

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

بعد الإزالة، يتغيّر عدد الأشكال وفهارس الأشكال اللاحقة. تبقى الإشارات إلى الأشكال غير المتأثرة أكثر موثوقية من الفهارس المحفوظة. ضع في الاعتبار الموصلات، الرسوم المتحركة، وميزات العرض الأخرى التي قد تشير إلى الكائن المُزال؛ إزالة شكل مرئي قد تغيّر أكثر من مظهر الشريحة.

### **إخفاء شكل**

ضبط [Hidden](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/sethidden/) إلى `true` يبقي الشكل في المجموعة لكنه يمنعه من الظهور في عرض الشرائح العادي. يبقى فهرسه وتنسيقه ومحتواه متاحًا للكود، لذا الإخفاء مناسب للعناصر الاختيارية التي قد تُستعاد لاحقًا.

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

الإخفاء ليس حذفًا أو أمانًا. لا يزال بإمكان المستخدم أو الكود اكتشاف الكائن وإظهارّه مرة أخرى، وهو يظل جزءًا من ملف العرض التقديمي.

### **تغيير ترتيب Z**

الأشكال المتداخلة تُرسم بترتيب المجموعة. [reorder](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/reorder/) ينقل شكلًا موجودًا إلى فهرس هدف دون استنساخه. الفهرس `0` هو الخلف؛ `size() - 1` هو الأمام.

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

يُنشئ المستطيل أولًا ويقع في البداية خلف الإهليلج. نقله إلى الفهرس النهائي يجعله في الأمام. أكّد ترتيب Z بعد إضافة أو استنساخ جميع الأشكال ذات الصلة، لأن تلك العمليات تُضيف أو تُدرج عناصر جديدة إلى المجموعة وقد تغير التراكم المقصود.

## **فحص الأشكال على شرائح التخطيط**

الشرائح العادية، شرائح التخطيط، والشرائح الرئيسة لها مجموعات أشكال منفصلة. الشكل في مجموعة التخطيط ليس هو نفسه الشكل المماثل المتواجد على شريحة عادية. افحص أشكال التخطيط عندما تحتاج إلى فهم أو تغيير تنسيق مقدّم من قبل التخطيط.

المثال التالي يقرأ كل شكل تخطيط's [FillFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/getfillformat/) و[LineFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/getlineformat/) بدون افتراض أن كل شكل هو `AutoShape`.

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

تحرير تخطيط قد يؤثر على عدة شرائح تستخدمه. قبل تغيير شكل تخطيط، حدّد ما إذا كانت شريحة عادية تُورِث الكائن أو تحتوي على تجاوز محلي، واختبر كل شريحة تستخدم ذلك التخطيط.

## **تصدير شكل إلى SVG**

[writeAsSvg](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/writeassvg/) يكتب محتوى شكل مُصوَّر إلى دفق. النتيجة تحتوي على الشكل فقط، ولا تشمل خلفية الشريحة بأكملها أو الأشكال المجاورة.

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

احتفظ بالعرض التقديمي مفتوحًا أثناء التصيير. يعتمد الإخراج على تنسيق الشكل وعلى موارد مثل الخطوط والصور. إذا كنت بحاجة إلى التركيب الكامل، صدِّر الشريحة بدلًا من الشكل الفردي. المتصل هو مالك الدفق ويجب أن يغلقه.

## **محاذاة الأشكال**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideutil/alignshapes/) تُتيح خيارات محاذاة إما كل الأشكال أو فهارس مجموعة مختارة. [ShapesAlignmentType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapesalignmenttype/) يحدد الحافة أو الخط المركزي أو وضع التوزيع. اضبط `alignToSlide` إلى `true` لاستخدام حواف الشريحة؛ اضبطه إلى `false` لمحاذاة الأشكال المختارة بالنسبة لبعضها البعض.

هذا المثال يُحاذي ثلاثة أشكال إلى الحافة العلوية للشريحة. تُحوَّل مراجع الأشكال المرجعة إلى فهارسها الحالية فورًا قبل المحاذاة.

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

المحاذاة تغير المواقع، لا ترتيب Z. المحاذاة النسبية عادةً ما تحتاج إلى شكلين على الأقل، بينما يتطلب التوزيع الأفقي أو الرأسي عددًا كافيًا من الأشكال لتحديد الفواصل. إعادة حساب الفهارس إذا عدّلت المجموعة قبل استدعاء الطريقة.

## **انعكاس شكل**

فئة [ShapeFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapeframe/) تخزن الموضع، الحجم، إعدادات الانعكاس الأفقي والعمودي، والدوران. قيمتي `getFlipH` و`getFlipV` تستخدم [NullableBool](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/nullablebool/): `True` يُفعِّل الانعكاس، `False` يُعطّله، و`NotDefined` يحافظ على الحالة غير المحددة/الافتراضية.

العرض التقديمي المُدخل أدناه يحتوي على شكل غير معكوس.

![الشكل قبل الانعكاس](shape_to_be_flipped.png)

المثال يحافظ على كل قيم الإطار الأخرى ويستبدل إعدادات الانعكاس فقط. هذا مهم لأن تعيين [Frame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/setframe/) جديد يستبدل الإطار بالكامل.

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

الشكل المحفوظ الآن معكوس أفقيًا وعموديًا مع الحفاظ على موضعه وحجمه ودورانه.

![الشكل بعد الانعكاس](flipped_shape.png)

## **الأسئلة الشائعة**

**هل يجب عليّ استخدام فهرس المجموعة كمعرف للشكل؟**

فقط للمعالجة قصيرة الأمد عندما لا تتغير المجموعة قبل استخدام الفهرس. يُفضَّل الاعتماد على اسم `Name` أو `AlternativeText` المُتحقَّق في القوالب المكتوبة، أو `OfficeInteropShapeId` لأعمال التفاعل على مستوى الشريحة.

**هل إخفاء الشكل يزيله من ترتيب Z؟**

لا. يظل الشكل المخفي في المجموعة عند نفس الفهرس. يمكن العثور عليه، إعادة ترتيبه، تحريره، أو إظهاره مرة أخرى.

**لماذا ظهر الشكل المستنسخ أمام شكل آخر؟**

`addClone` يضيف النسخة إلى نهاية المجموعة، وهي أمامية ترتيب Z. استخدم `insertClone` لاختيار الفهرس الأولي أو `reorder` بعد إضافة جميع الأشكال.

**هل يمكنني استخدام فهرس ثابت لتحديد ضبط شكل مسبق؟**

فقط بعد التحقق من المسبق المحدد وترتيب المجموعة بدقة. يُفضَّل تكرار خلال `GeometryShape.getAdjustments` والتحقق من `AdjustValue.getType`؛ استخدم `AdjustValue.getName` كمعلومات إضافية عندما يظهر نفس النوع الدلالي أكثر من مرة.