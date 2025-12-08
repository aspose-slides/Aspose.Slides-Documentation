---
title: معالجة الأشكال
type: docs
weight: 40
url: /ar/nodejs-java/shape-manipulations/
---

## **العثور على الشكل في الشريحة**
ستصف هذه المادة تقنية بسيطة لتسهيل عملية البحث عن شكل معين في شريحة دون الحاجة إلى استخدام المعرف الداخلي الخاص به. من المهم معرفة أن ملفات PowerPoint Presentation لا تتوفر لديها أي طريقة لتحديد الأشكال في الشريحة باستثناء المعرف الفريد الداخلي. يبدو أن العثور على شكل باستخدام المعرف الفريد الداخلي يمثل صعوبة للمطورين. جميع الأشكال المضافة إلى الشرائح تحتوي على نص بديل (Alt Text). نقترح على المطورين استخدام النص البديل للعثور على شكل محدد. يمكنك استخدام MS PowerPoint لتحديد النص البديل للكائنات التي تخطط لتغييرها في المستقبل.

بعد تعيين النص البديل لأي شكل مطلوب، يمكنك فتح ذلك العرض التقديمي باستخدام Aspose.Slides for Node.js via Java والمرور عبر جميع الأشكال المضافة إلى الشريحة. خلال كل تكرار، يمكنك فحص النص البديل للشكل، وسيكون الشكل الذي يطابق النص البديل هو الشكل المطلوب. لتوضيح هذه التقنية بشكل أفضل، أنشأنا طريقة [findShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) تقوم بالعثور على شكل معين في الشريحة وتعيد ذلك الشكل ببساطة.
```javascript
// إنشاء فئة Presentation التي تمثل ملف العرض التقديمي
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // النص البديل للشكل المراد العثور عليه
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


## **استنساخ الشكل**
لاستنساخ شكل إلى شريحة باستخدام Aspose.Slides for Node.js via Java:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. الحصول على مرجع الشريحة باستخدام فهرستها.
1. الوصول إلى مجموعة أشكال الشريحة المصدر.
1. إضافة شريحة جديدة إلى العرض التقديمي.
1. استنساخ الأشكال من مجموعة أشكال الشريحة المصدر إلى الشريحة الجديدة.
1. حفظ العرض التقديمي المعدل كملف PPTX.

المثال أدناه يضيف مجموعة أشكال إلى شريحة.
```javascript
// إنشاء فئة Presentation
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // كتابة ملف PPTX إلى القرص
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إزالة الشكل**
Aspose.Slides for Node.js via Java تسمح للمطورين بإزالة أي شكل. لإزالة الشكل من أي شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل بواسطة نص بديل محدد.
1. إزالة الشكل.
1. حفظ الملف إلى القرص.
```javascript
// إنشاء كائن Presentation
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة شكل تلقائي من نوع مستطيل
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
Aspose.Slides for Node.js via Java تسمح للمطورين بإخفاء أي شكل. لإخفاء الشكل من أي شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل بواسطة نص بديل محدد.
1. إخفاء الشكل.
1. حفظ الملف إلى القرص.
```javascript
// إنشاء فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة شكل تلقائي من نوع مستطيل
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
Aspose.Slides for Node.js via Java تسمح للمطورين بإعادة ترتيب الأشكال. يحدد إعادة ترتيب الشكل أي شكل يكون في المقدمة أو في الخلف. لإعادة ترتيب الشكل من أي شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة شكل.
1. إضافة نص إلى إطار النص الخاص بالشكل.
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


## **الحصول على معرف الشكل للتكامل (Interop)**
Aspose.Slides for Node.js via Java تسمح للمطورين بالحصول على معرف شكل فريد في نطاق الشريحة على عكس طريقة [getUniqueId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getUniqueId--) التي تسمح بالحصول على معرف فريد في نطاق العرض التقديمي. تم إضافة الطريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) إلى فئة [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) وفئة [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) على التوالي. القيمة التي ترجعها طريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) تتطابق مع قيمة المعرف لكائن Microsoft.Office.Interop.PowerPoint.Shape. أدناه عينة من الشيفرة.
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
Aspose.Slides for Node.js via Java تسمح للمطورين بتعيين AlternateText لأي شكل. يمكن تمييز الأشكال في عرض تقديمي باستخدام طريقة [AlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) أو [Shape Name](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setName-java.lang.String-). يمكن قراءة أو تعيين طريقتي [setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) و [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getAlternativeText--) باستخدام Aspose.Slides وكذلك Microsoft PowerPoint. باستخدام هذه الطريقة، يمكنك وسم الشكل وتنفيذ عمليات مختلفة مثل إزالة الشكل، إخفاء الشكل أو إعادة ترتيب الأشكال على الشريحة. لتعيين AlternateText لشكل، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة أي شكل إلى الشريحة.
1. القيام ببعض الأعمال مع الشكل المضاف حديثًا.
1. التنقل عبر الأشكال للعثور على الشكل.
1. تعيين AlternativeText.
1. حفظ الملف إلى القرص.
```javascript
// إنشاء فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة شكل تلقائي من نوع مستطيل
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


## **الوصول إلى صيغ التخطيط للشكل**
Aspose.Slides for Node.js via Java توفر واجهة برمجة تطبيقات بسيطة للوصول إلى صيغ التخطيط لشكل. توضح هذه المقالة كيفية الوصول إلى صيغ التخطيط.

أدناه عينة من الشيفرة.
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


## **تصدير الشكل كملف SVG**
الآن يدعم Aspose.Slides for Node.js via Java تصدير الشكل كملف svg. تم إضافة الطريقة [writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (مع التحميل الزائد) إلى فئة [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) وفئة [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape). تتيح هذه الطريقة حفظ محتوى الشكل كملف SVG. يوضح المقتطف البرمجي أدناه كيفية تصدير شكل الشريحة إلى ملف SVG.
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
Aspose.Slides تسمح بمحاذاة الأشكال إما بالنسبة إلى هوامش الشريحة أو بالنسبة إلى بعضها البعض. لهذا الغرض، تم إضافة الطريقة الزائدة [SlidesUtil.alignShape()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-). تحدد تعداد [ShapesAlignmentType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapesAlignmentType) خيارات المحاذاة الممكنة.

**مثال 1**

الكود المصدر أدناه يمحّ الأشكال ذات الفهارس 1،2 و4 على الحد العلوي للشريحة.
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

المثال أدناه يظهر كيفية محاذاة مجموعة الأشكال بالكامل بالنسبة إلى الشكل الأسفل في المجموعة.
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

في Aspose.Slides، توفر فئة [ShapeFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeframe/) التحكم في الانعكاس الأفقي والعمودي للأشكال عبر خاصيتي `flipH` و `flipV`. كلا الخاصيتين من نوع `byte`، وتقبل القيم `1` للإشارة إلى انعكاس، `0` لعدم وجود انعكاس، أو `-1` لاستخدام السلوك الافتراضي. هذه القيم يمكن الوصول إليها من خلال [Frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getFrame) الخاص بالشكل.

لتعديل إعدادات الانعكاس، يتم إنشاء نسخة جديدة من فئة [ShapeFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeframe/) باستخدام الموقع والحجم الحاليين للشكل، القيم المطلوبة لـ `flipH` و `flipV`، وزاوية الدوران. تعيين هذه النسخة إلى [Frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getFrame) الخاص بالشكل وحفظ العرض التقديمي يطبق التحولات العكسية ويثبتها في ملف الإخراج.

لنفترض أن لدينا ملف sample.pptx يحتوي على الشريحة الأولى شكلًا واحدًا بإعدادات انعكاس افتراضية، كما هو موضح أدناه.

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

**هل يمكنني دمج الأشكال (الاتحاد/التقاطع/الطرح) على شريحة كما في محرر سطح المكتب؟**

لا توجد واجهة برمجة تطبيقات مدمجة لعمليات Boolean. يمكنك تقليد ذلك بإنشاء المخطط المطلوب يدويًا—على سبيل المثال حساب الهندسة الناتجة (باستخدام [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)) وإنشاء شكل جديد بذلك الحد، وإزالة الأشكال الأصلية إذا رغبت.

**كيف يمكنني التحكم بترتيب الطبقات (z-order) بحيث يبقى الشكل دائمًا "في الأعلى"؟**

قم بتغيير ترتيب الإدراج/النقل داخل مجموعة [shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) الخاصة بالشريحة. للحصول على نتائج متوقعة، أكمل ضبط ترتيب z بعد إتمام جميع التعديلات الأخرى على الشريحة.

**هل يمكنني "قفل" الشكل لمنع المستخدمين من تحريره في PowerPoint؟**

نعم. عيّن [علامات حماية على مستوى الشكل](/slides/ar/nodejs-java/applying-protection-to-presentation/) (مثل قفل التحديد، الحركة، تغيير الحجم، تحرير النص). إذا لزم الأمر، يمكنك تطبيق القيود على القالب أو التخطيط. لاحظ أن هذه الحماية على مستوى واجهة المستخدم وليست ميزة أمان؛ للحصول على حماية أقوى، يمكن دمجها مع قيود على مستوى الملف مثل توصيات للقراءة فقط أو كلمات مرور [/slides/nodejs-java/password-protected-presentation/].