---
title: إدارة أشكال العرض التقديمي على Android
linktitle: معالجة الأشكال
type: docs
weight: 40
url: /ar/androidjava/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل في الشريحة
- البحث عن شكل
- نسخ الشكل
- إزالة الشكل
- إخفاء الشكل
- تغيير ترتيب الشكل
- الحصول على معرّف الشكل التفاعلي
- النص البديل للشكل
- تنسيقات تخطيط الشكل
- شكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- PowerPoint
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية إنشاء وتحرير وتحسين الأشكال في Aspose.Slides لـ Android عبر Java وتقديم عروض PowerPoint عالية الأداء."
---

## **العثور على شكل في شريحة**
سيتناول هذا الموضوع تقنية بسيطة لتسهيل عملية العثور على شكل محدد في شريحة دون الحاجة إلى استخدام معرفه الداخلي. من المهم معرفة أن ملفات PowerPoint لا تحتوي على أي طريقة لتحديد الأشكال في الشريحة باستثناء معرف فريد داخلي. يبدو أن المطورين يواجهون صعوبة في العثور على شكل باستخدام معرفه الفريد الداخلي. جميع الأشكال المضافة إلى الشرائح تحتوي على نص بديل. نقترح على المطورين استخدام النص البديل للعثور على شكل معين. يمكنك استخدام MS PowerPoint لتحديد النص البديل للكائنات التي تخطط لتغييرها في المستقبل.

بعد تعيين النص البديل لأي شكل مطلوب، يمكنك فتح ذلك العرض التقديمي باستخدام Aspose.Slides for Android via Java والمرور عبر جميع الأشكال المضافة إلى شريحة. أثناء كل تكرار، يمكنك فحص النص البديل لل shape، وسيكون الشكل الذي يطابق النص البديل هو الشكل المطلوب. لتوضيح هذه التقنية بطريقة أفضل، قمنا بإنشاء طريقة [findShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) تقوم بالمهمة للعثور على شكل معين في شريحة وتعيد ذلك الشكل ببساطة.
```java
// إنشاء كائن من فئة Presentation يمثل ملف العرض التقديمي
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // النص البديل للشكل المراد العثور عليه
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
// تنفيذ طريقة للعثور على شكل في شريحة باستخدام النص البديل
public static IShape findShape(ISlide slide, String alttext)
{
    // التكرار عبر جميع الأشكال داخل الشريحة
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // إذا كان النص البديل للشريحة يطابق المطلوب ثم
        // إرجاع الشكل
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```


## **استنساخ شكل**
لاستنساخ شكل إلى شريحة باستخدام Aspose.Slides for Android via Java:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الحصول على مرجع الشريحة باستخدام فهارسها.
1. الوصول إلى مجموعة أشكال الشريحة المصدر.
1. إضافة شريحة جديدة إلى العرض التقديمي.
1. استنساخ الأشكال من مجموعة أشكال الشريحة المصدر إلى الشريحة الجديدة.
1. حفظ العرض التقديمي المعدل كملف PPTX.

المثال أدناه يضيف مجموعة أشكال إلى شريحة.
```java
// إنشاء كائن من فئة Presentation
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // كتابة ملف PPTX إلى القرص
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إزالة شكل**
يسمح Aspose.Slides for Android via Java للمطورين بإزالة أي شكل. لإزالة الشكل من أي شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل بالنص البديل المحدد.
1. إزالة الشكل.
1. حفظ الملف إلى القرص.
```java
// إنشاء كائن Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة شكل تلقائي من النوع مستطيل
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // حفظ العرض التقديمي إلى القرص
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إخفاء شكل**
يسمح Aspose.Slides for Android via Java للمطورين بإخفاء أي شكل. لإخفاء الشكل من أي شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل بالنص البديل المحدد.
1. إخفاء الشكل.
1. حفظ الملف إلى القرص.
```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع مستطيل
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // حفظ العرض التقديمي إلى القرص
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تغيير ترتيب الشكل**
يسمح Aspose.Slides for Android via Java للمطورين بإعادة ترتيب الأشكال. يحدد إعادة ترتيب الشكل أي شكل يكون في المقدمة أو في الخلفية. لإعادة ترتيب الشكل في أي شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة شكل.
1. إضافة نص إلى إطار نص الشكل.
1. إضافة شكل آخر بنفس الإحداثيات.
1. إعادة ترتيب الأشكال.
1. حفظ الملف إلى القرص.
```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الحصول على معرف الشكل التفاعلي**
يسمح Aspose.Slides for Android via Java للمطورين بالحصول على معرف شكل فريد في نطاق الشريحة بالمقابل مع طريقة [getUniqueId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getUniqueId--) التي تسمح بالحصول على معرف فريد في نطاق العرض التقديمي. تم إضافة الطريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) إلى واجهة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) وفئة [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) على التوالي. القيمة المرجعة من طريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) تتطابق مع قيمة معرف كائن Microsoft.Office.Interop.PowerPoint.Shape. أدناه مثال على الشيفرة.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // الحصول على معرف الشكل الفريد في نطاق الشريحة
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين نص بديل لشكل**
يسمح Aspose.Slides for Android via Java للمطورين بتعيين AlternativeText لأي شكل.
يمكن تمييز الأشكال في العرض التقديمي باستخدام طريقة [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) أو [Shape Name](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setName-java.lang.String-).
يمكن قراءة أو تعيين طريقتي [setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) و [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) باستخدام Aspose.Slides وكذلك Microsoft PowerPoint.
باستخدام هذه الطريقة، يمكنك وسم الشكل وإجراء عمليات مختلفة مثل إزالة الشكل، إخفاء الشكل أو إعادة ترتيب الأشكال على الشريحة.
لتعيين AlternativeText لشكل، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة أي شكل إلى الشريحة.
1. القيام ببعض العمل مع الشكل المضاف حديثًا.
1. المرور عبر الأشكال للعثور على الشكل.
1. تعيين AlternativeText.
1. حفظ الملف إلى القرص.
```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع مستطيل
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // حفظ العرض التقديمي إلى القرص
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الوصول إلى تنسيقات التخطيط لشكل**
يوفر Aspose.Slides for Android via Java واجهة برمجة تطبيقات بسيطة للوصول إلى تنسيقات التخطيط لشكل. يوضح هذا المقال كيفية الوصول إلى تنسيقات التخطيط.

أدناه مثال على الشيفرة.
```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **تصيير شكل كملف SVG**
الآن يدعم Aspose.Slides for Android via Java تصيير شكل كملف SVG. تمت إضافة طريقة [writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (وتجاوزاتها) إلى فئة [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) وواجهة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape). تسمح هذه الطريقة بحفظ محتوى الشكل كملف SVG. يوضح المقتطف البرمجي أدناه كيفية تصدير شكل الشريحة إلى ملف SVG.
```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **محاذاة شكل**
يسمح Aspose.Slides بمحاذاة الأشكال إما بالنسبة لهوامش الشريحة أو بالنسبة لبعضها البعض. لهذا الغرض، تمت إضافة طريقة [SlidesUtil.alignShape()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) المتعددة التحميلات. تحدد تعداد [ShapesAlignmentType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapesAlignmentType) خيارات المحاذاة الممكنة.

**مثال 1**

الكود المصدر أدناه يحاذي الأشكال ذات الفهارس 1 و2 و4 على الحد العلوي للشريحة.
```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```


**مثال 2**

المثال أدناه يوضح كيفية محاذاة مجموعة الأشكال بأكملها بالنسبة للشكل الأسفل في المجموعة.
```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```


## **خصائص الانعكاس**

في Aspose.Slides، توفر الفئة [ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) التحكم في انعكاس الشكل أفقيًا وعموديًا عبر خاصيتي `flipH` و `flipV`. كلتا الخصيتين من نوع `byte`، حيث تشير القيمة `1` إلى انعكاس، `0` إلى عدم الانعكاس، أو `-1` لاستخدام السلوك الافتراضي. يمكن الوصول إلى هذه القيم من خلال [Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--) الخاص بالشكل.

لتعديل إعدادات الانعكاس، يُنشأ كائن جديد من [ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) باستخدام موضع الشكل الحالي وحجمه، والقيم المطلوبة لـ `flipH` و `flipV`، وزاوية الدوران. يُعيّن هذا الكائن إلى [Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--) الخاص بالشكل، ثم يُحفظ العرض التقديمي لتطبيق التحويلات وتأكيدها في ملف الإخراج.

لنفترض أن لدينا ملف sample.pptx يحتوي على الشريحة الأولى التي تضم شكلًا واحدًا بإعدادات انعكاس افتراضية، كما هو موضح أدناه.

![The shape to be flipped](shape_to_be_flipped.png)

الكود التالي يسترجع خصائص الانعكاس الحالية للشكل ويقوم بإنعكاسه أفقياً وعمودياً.
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // استرجاع خاصية الانعكاس الأفقي للشكل.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // استرجاع خاصية الانعكاس العمودي للشكل.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // انعكاس أفقي.
    byte flipV = NullableBool.True; // انعكاس أفقي.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


النتيجة:

![The flipped shape](flipped_shape.png)

## **الأسئلة الشائعة**

**هل يمكنني دمج الأشكال (اتحاد/تقاطع/طرح) في شريحة كما هو موجود في محرر سطح المكتب؟**

لا توجد واجهة برمجة تطبيقات للعمليات البوليانية مدمجة. يمكنك تقريب ذلك بإنشاء المخطط المطلوب بنفسك—مثلاً حساب الهندسة الناتجة عبر [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) وإنشاء شكل جديد بهذا الحد، مع إمكانية إزالة الأشكال الأصلية.

**كيف يمكنني التحكم في ترتيب الطبقات (z-order) بحيث يبقى الشكل دائمًا "في الأعلى"؟**

غيّر ترتيب الإدخال/النقل داخل مجموعة [shapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) الخاصة بالشريحة. للحصول على نتائج متوقعة، أكمل ترتيب z-order بعد جميع تعديلات الشريحة الأخرى.

**هل يمكنني "قفل" شكل لمنع المستخدمين من تعديله في PowerPoint؟**

نعم. عيّن أعلام حماية على مستوى الشكل (مثل قفل التحديد، الحركة، تغيير الحجم، تعديل النص). إذا لزم الأمر، يمكنك تطبيق قيود مماثلة على القالب أو التخطيط. لاحظ أن هذا حماية على مستوى واجهة المستخدم، وليس ميزة أمان؛ للحصول على حماية أقوى، اجمعها مع قيود على مستوى الملف مثل [توصيات القراءة فقط أو كلمات المرور](/slides/ar/androidjava/password-protected-presentation/).