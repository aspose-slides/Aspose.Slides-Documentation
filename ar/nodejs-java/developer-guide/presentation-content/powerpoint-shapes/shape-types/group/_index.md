---
title: مجموعة
type: docs
weight: 40
url: /ar/nodejs-java/group/
---

## **إضافة شكل مجموعة**
Aspose.Slides يدعم العمل مع أشكال المجموعات على الشرائح. تساعد هذه الميزة المطورين على دعم عروض تقديمية أغنى. Aspose.Slides for Node.js عبر Java يدعم إضافة أو الوصول إلى أشكال المجموعات. يمكن إضافة أشكال إلى مجموعة الشكل المضافة لملئها أو الوصول إلى أي خاصية من خصائص مجموعة الشكل. لإضافة مجموعة شكل إلى شريحة باستخدام Aspose.Slides for Node.js عبر Java:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
1. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها
1. إضافة شكل مجموعة إلى الشريحة.
1. إضافة الأشكال إلى مجموعة الشكل التي تمت إضافتها.
1. حفظ العرض التقديمي المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى شريحة.
```javascript
// إنشاء كائن من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // الوصول إلى مجموعة الأشكال في الشرائح
    var slideShapes = sld.getShapes();
    // إضافة شكل مجموعة إلى الشريحة
    var groupShape = slideShapes.addGroupShape();
    // إضافة أشكال داخل مجموعة الشكل المضافة
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // إضافة إطار مجموعة الشكل
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // كتابة ملف PPTX إلى القرص
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الوصول إلى خاصية AltText**
توضع هذه الفقرة خطوات بسيطة، مع أمثلة الشيفرة، لإضافة شكل مجموعة والوصول إلى خاصية AltText لأشكال المجموعات على الشرائح. للوصول إلى AltText لشكل مجموعة في شريحة باستخدام Aspose.Slides for Node.js عبر Java:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) التي تمثل ملف PPTX.
1. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
1. الوصول إلى مجموعة الأشكال في الشرائح.
1. الوصول إلى شكل المجموعة.
1. استدعاء خاصية [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getAlternativeText--) .

المثال أدناه يصل إلى النص البديل لشكل المجموعة.
```javascript
// إنشاء كائن Presentation الذي يمثل ملف PPTX
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // الوصول إلى مجموعة الأشكال في الشرائح
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // الوصول إلى شكل المجموعة.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // الوصول إلى خاصية AltText
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**هل يتم دعم التجميع المتداخل (مجموعة داخل مجموعة)؟**

نعم. يحتوي [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/) على طريقة [getParentGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getparentgroup/) ، والتي تشير مباشرةً إلى دعم التسلسل الهرمي (يمكن أن تكون مجموعة فرعية لمجموعة أخرى).

**كيف يمكنني التحكم في ترتيب z للمجموعة مقارنةً بالكائنات الأخرى على الشريحة؟**

استخدم طريقة [getZOrderPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getzorderposition/) الخاصة بـ [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/) لتفقد موقعها في مكدس العرض.

**هل يمكنني منع التحريك/التعديل/إلغاء التجميع؟**

نعم. قسم القفل للمجموعة يتم كشفه عبر [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/getgroupshapelock/) ، والذي يسمح لك بتقييد العمليات على الكائن.