---
title: إدارة أشكال العرض التقديمي باستخدام JavaScript
linktitle: معالجة الشكل
type: docs
weight: 40
url: /ar/nodejs-java/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على الشريحة
- البحث عن شكل
- استنساخ الشكل
- إزالة الشكل
- إخفاء الشكل
- تغيير ترتيب الشكل
- الحصول على معرف الشكل Interop
- النص البديل للشكل
- تنسيقات تخطيط الشكل
- الشكل بصيغة SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- PowerPoint
- العرض التقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية إنشاء وتحرير وتحسين الأشكال باستخدام JavaScript و Aspose.Slides لـ Node.js عبر Java وتقديم عروض PowerPoint ذات أداء عالي."
---

## **العثور على الشكل في الشريحة**
سوف يصف هذا القسم تقنية بسيطة لتسهيل عملية العثور على شكل محدد في شريحة دون الحاجة إلى استخدام المعرف الداخلي الخاص به. من المهم معرفة أن ملفات PowerPoint لا توفر طريقة لتحديد الأشكال في الشريحة إلا باستخدام معرف فريد داخلي. يبدو أن المطورين يواجهون صعوبة في العثور على شكل باستخدام هذا المعرف الفريد. جميع الأشكال المضافة إلى الشرائح تحتوي على نص بديل. نوصي المطورين باستخدام النص البديل للعثور على شكل معين. يمكنك استخدام Microsoft PowerPoint لتحديد النص البديل للكائنات التي تخطط لتغييرها في المستقبل.

بعد تعيين النص البديل لأي شكل مرغوب، يمكنك فتح ذلك العرض التقديمي باستخدام Aspose.Slides for Node.js via Java وتكرار جميع الأشكال المضافة إلى الشريحة. خلال كل تكرار، يمكنك فحص النص البديل للشكل، وسيكون الشكل الذي يطابق النص البديل هو الشكل المطلوب. لتوضيح هذه التقنية بشكل أفضل، أنشأنا طريقة [findShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) تقوم بالمهمة للعثور على شكل محدد في الشريحة وتعيد ذلك الشكل ببساطة.
```javascript
// إنشاء كائن من فئة Presentation يمثل ملف العرض التقديمي
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // النص البديل للشكل الذي سيتم العثور عليه
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```


## **نسخ الشكل**
لنسخ شكل إلى شريحة باستخدام Aspose.Slides for Node.js via Java:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. الوصول إلى مجموعة أشكال الشريحة المصدر.
1. إضافة شريحة جديدة إلى العرض التقديمي.
1. نسخ الأشكال من مجموعة أشكال الشريحة المصدر إلى الشريحة الجديدة.
1. حفظ العرض التقديمي المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى شريحة.
```javascript
// إنشاء كائن من فئة Presentation
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // حفظ ملف PPTX إلى القرص
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إزالة الشكل**
يسمح Aspose.Slides for Node.js via Java للمطورين بإزالة أي شكل. لإزالة الشكل من أي شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل الذي يملك نصًا بديلًا محددًا.
1. إزالة الشكل.
1. حفظ الملف إلى القرص.
```javascript
// إنشاء كائن Presentation
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة شكل أوتوماتيكي من نوع مستطيل
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // حفظ العرض التقديمي إلى القرص
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إخفاء الشكل**
يسمح Aspose.Slides for Node.js via Java للمطورين بإخفاء أي شكل. لإخفاء الشكل من أي شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل الذي يملك نصًا بديلًا محددًا.
1. إخفاء الشكل.
1. حفظ الملف إلى القرص.
```javascript
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة شكل أوتوماتيكي من نوع مستطيل
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // حفظ العرض التقديمي إلى القرص
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تغيير ترتيب الأشكال**
يسمح Aspose.Slides for Node.js via Java للمطورين بإعادة ترتيب الأشكال. يحدد إعادة ترتيب الشكل أي شكل يكون في المقدمة أو في الخلفية. لإعادة ترتيب الأشكال في أي شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة شكل.
1. إضافة نص في إطار النص الخاص بالشكل.
1. إضافة شكل آخر بنفس الإحداثيات.
1. إعادة ترتيب الأشكال.
1. حفظ الملف إلى القرص.
```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الحصول على معرّف الشكل بين الأنظمة (Interop)**
يسمح Aspose.Slides for Node.js via Java للمطورين بالحصول على معرف فريد للشكل في نطاق الشريحة بالمقارنة مع طريقة [getUniqueId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getUniqueId--) التي تتيح الحصول على معرف فريد في نطاق العرض التقديمي. تمت إضافة الطريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) إلى الفئة [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape). القيمة التي تُرجعها طريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) تتوافق مع قيمة المعرف لكائن Microsoft.Office.Interop.PowerPoint.Shape. أدناه مثال على الشيفرة.
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // الحصول على معرف الشكل الفريد في نطاق الشريحة
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين النص البديل للشكل**
يسمح Aspose.Slides for Node.js via Java للمطورين بتعيين الخاصية AlternateText لأي شكل. يمكن تمييز الأشكال في العرض التقديمي باستخدام طريقة [AlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) أو طريقة [Shape Name](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setName-java.lang.String-). يمكن قراءة أو تعيين النص البديل باستخدام الطريقتين [setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) و[getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getAlternativeText--) عبر Aspose.Slides أو Microsoft PowerPoint. باستخدام هذه الطريقة، يمكنك وسم الشكل وإجراء عمليات مختلفة مثل إزالة الشكل، إخفاء الشكل أو إعادة ترتيب الأشكال في الشريحة. لتعيين AlternateText لشكل، يرجى اتباع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة أي شكل إلى الشريحة.
1. القيام ببعض الأعمال مع الشكل المضاف حديثًا.
1. التجول بين الأشكال للعثور على الشكل المطلوب.
1. تعيين قيمة AlternativeText.
1. حفظ الملف إلى القرص.
```javascript
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة شكل أوتوماتيكي من نوع مستطيل
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // حفظ العرض التقديمي إلى القرص
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الوصول إلى تنسيقات التخطيط للشكل**
يوفر Aspose.Slides for Node.js via Java واجهة برمجة تطبيقات بسيطة للوصول إلى تنسيقات التخطيط لشكل. يوضح هذا المقال كيفية الوصول إلى تنسيقات التخطيط.

أدناه مثال على الشيفرة.
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تصيير الشكل كملف SVG**
الآن يدعم Aspose.Slides for Node.js via Java تصيير شكل كملف SVG. تمت إضافة الطريقة [writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (مع تجاوزها) إلى الفئة [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape). تسمح هذه الطريقة بحفظ محتوى الشكل كملف SVG. يوضح المقتطف البرمجي أدناه كيفية تصدير شكل الشريحة إلى ملف SVG.
```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **محاذاة الأشكال**
يسمح Aspose.Slides بمحاذاة الأشكال إما بالنسبة لهامش الشريحة أو بالنسبة لبعضها البعض. لهذا الغرض، تمت إضافة طريقة محملة [SlidesUtil.alignShape()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-). تحدد تعداد [ShapesAlignmentType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapesAlignmentType) خيارات المحاذاة المتاحة.

**مثال 1**

الكود المصدر أدناه يوافق الأشكال ذات الفهارس 1،2 و4 على الحافة العليا للشريحة.
```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


**مثال 2**

المثال أدناه يوضح كيفية محاذاة مجموعة الأشكال بالكامل بالنسبة لأدنى شكل في المجموعة.
```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **خصائص الانعكاس**

في Aspose.Slides، توفر الفئة [ShapeFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeframe/) التحكم في الانعكاس الأفقي والعمودي للأشكال عبر خاصيتي `flipH` و`flipV`. كلا الخصيتين من نوع `byte`، حيث القيمة `1` تشير إلى الانعكاس، `0` لعدم الانعكاس، أو `-1` لاستخدام السلوك الافتراضي. يمكن الوصول إلى هذه القيم من خلال [Frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getFrame) الخاص بالشكل.

لتعديل إعدادات الانعكاس، يتم إنشاء مثيل جديد من [ShapeFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeframe/) مع الموضع الحالي للشكل وحجمه، والقيم المطلوبة لـ `flipH` و`flipV`، وزاوية الدوران. يتم تعيين هذا المثيل إلى [Frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getFrame) الخاص بالشكل وحفظ العرض التقديمي لتطبيق التحولات العاكسة وتطبيقها على ملف الإخراج.

لنفترض أن لدينا ملف sample.pptx يحتوي على شريحة أولى تشمل شكلًا واحدًا بإعدادات انعكاس افتراضية، كما هو موضح أدناه.

![The shape to be flipped](shape_to_be_flipped.png)

الكود التالي يسترجع خصائص الانعكاس الحالية للشكل ويقوم بعكسه أفقيًا وعموديًا.
```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // استرجاع خاصية الانعكاس الأفقي للشكل.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // استرجاع خاصية الانعكاس العمودي للشكل.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // انعكاس أفقي.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // انعكاس عمودي.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


النتيجة:

![The flipped shape](flipped_shape.png)

## **الأسئلة المتكررة**

**هل يمكنني دمج الأشكال (اتحاد/تقاطع/طرح) في شريحة كما في محررات سطح المكتب؟**

لا توجد واجهة برمجة تطبيقات مدمجة للعمليات البوليانية. يمكنك تقريب ذلك بإنشاء الشكل المطلوب يدويًا—مثلاً حساب الهندسة الناتجة عبر [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) وإنشاء شكل جديد بهذه الحدود، مع إمكانية حذف الأشكال الأصلية.

**كيف يمكنني التحكم في ترتيب التراكب (z-order) بحيث يظل الشكل دائمًا "في القمة"؟**

غير ترتيب الإدراج/النقل داخل مجموعة [shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) الخاص بالشريحة. للحصول على نتائج متوقعة، قم بتثبيت ترتيب z-order بعد إتمام جميع تعديلات الشريحة الأخرى.

**هل يمكنني "قفل" شكل لمنع المستخدمين من تحريره في PowerPoint؟**

نعم. اضبط علامات الحماية على مستوى الشكل (مثل قفل التحديد، الحركة، تغيير الحجم، تحرير النص). إذا لزم الأمر، يمكن تطبيق قيود مماثلة على القالب أو التخطيط. تجدر الإشارة إلى أن هذه الحماية هي على مستوى واجهة المستخدم، ليست ميزة أمان؛ للحصول على حماية أقوى، يمكن دمجها مع قيود على مستوى الملف مثل التوصيات للقراءة فقط أو كلمات المرور [/slides/nodejs-java/password-protected-presentation/].