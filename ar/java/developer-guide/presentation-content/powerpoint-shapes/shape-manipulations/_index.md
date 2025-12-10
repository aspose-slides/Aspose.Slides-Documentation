---
title: إدارة أشكال العرض التقديمي في جافا
linktitle: معالجة الشكل
type: docs
weight: 40
url: /ar/java/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على الشريحة
- البحث عن شكل
- استنساخ الشكل
- إزالة الشكل
- إخفاء الشكل
- تغيير ترتيب الشكل
- الحصول على معرف شكل Interop
- النص البديل للشكل
- تنسيقات تخطيط الشكل
- الشكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- PowerPoint
- العرض التقديمي
- Java
- Aspose.Slides
description: "تعلّم إنشاء وتحرير وتحسين الأشكال في Aspose.Slides for Java وتقديم عروض PowerPoint عالية الأداء."
---

## **العثور على شكل في شريحة**
ستصف هذه المادة تقنية بسيطة لتسهيل العثور على شكل معين في شريحة للمطورين دون الحاجة لاستخدام معرّفه الداخلي. من المهم معرفة أن ملفات PowerPoint Presentation لا تملك طريقة لتحديد الأشكال في الشريحة إلا عبر معرّف داخلي فريد. يبدو أن من الصعب على المطورين العثور على شكل باستخدام معرّفه الداخلي الفريد. جميع الأشكال المضافة إلى الشرائح تحتوي على نص بديل. نقترح على المطورين استخدام النص البديل للعثور على شكل معين. يمكنك استخدام MS PowerPoint لتحديد النص البديل للكائنات التي تخطط لتغييرها في المستقبل.

بعد تعيين النص البديل لأي شكل مرغوب، يمكنك فتح ذلك العرض التقديمي باستخدام Aspose.Slides for Java والتجول عبر جميع الأشكال المضافة إلى الشريحة. خلال كل تكرار، يمكنك فحص النص البديل للشكل وسيكون الشكل الذي يتطابق نصه البديل هو الشكل المطلوب. لإظهار هذه التقنية بطريقة أفضل، أنشأنا طريقة [findShape](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) التي تقوم بالبحث عن شكل معين في شريحة وتعيد ذلك الشكل ببساطة.
```java
// إنشاء كائن من فئة Presentation يمثل ملف العرض التقديمي
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // النص البديل للشكل المطلوب العثور عليه
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
// تنفيذ طريقة للعثور على شكل في شريحة باستخدام النص البديل الخاص به
public static IShape findShape(ISlide slide, String alttext)
{
    // التكرار عبر جميع الأشكال داخل الشريحة
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // إذا كان النص البديل للشكل يطابق المطلوب
        // إرجاع الشكل
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```


## **استنساخ شكل**
لنسخ شكل إلى شريحة باستخدام Aspose.Slides for Java:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. الوصول إلى مجموعة أشكال الشريحة المصدر.
1. إضافة شريحة جديدة إلى العرض التقديمي.
1. نسخ الأشكال من مجموعة أشكال الشريحة المصدر إلى الشريحة الجديدة.
1. حفظ العرض التقديمي المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى شريحة.
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
Aspose.Slides for Java يسمح للمطورين بإزالة أي شكل. لإزالة الشكل من أي شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل الذي يحتوي على نص بديل محدد.
1. إزالة الشكل.
1. حفظ الملف على القرص.
```java
// إنشاء كائن Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة شكل أوتوماتيكي من نوع مستطيل
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
Aspose.Slides for Java يسمح للمطورين بإخفاء أي شكل. لإخفاء الشكل من أي شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل الذي يحتوي على نص بديل محدد.
1. إخفاء الشكل.
1. حفظ الملف على القرص.
```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة شكل أوتوماتيكي من نوع مستطيل
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
Aspose.Slides for Java يسمح للمطورين بإعادة ترتيب الأشكال. إعادة ترتيب الشكل تحدد أي شكل يكون في المقدمة أو في الخلف. لإعادة ترتيب الشكل من أي شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
1. الوصول إلى الشريحة الأولى.
1. إضافة شكل.
1. إضافة نص إلى إطار النص الخاص بالشكل.
1. إضافة شكل آخر بنفس الإحداثيات.
1. إعادة ترتيب الأشكال.
1. حفظ الملف على القرص.
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


## **الحصول على معرّف الشكل Interop**
Aspose.Slides for Java يسمح للمطورين بالحصول على معرف شكل فريد في نطاق الشريحة على عكس طريقة [getUniqueId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getUniqueId--) التي تسمح بالحصول على معرف فريد في نطاق العرض التقديمي. تم إضافة الطريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) إلى واجهة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) وفئة [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/Shape) على التوالي. القيمة التي تُعيدها الطريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) تتطابق مع قيمة Id لكائن Microsoft.Office.Interop.PowerPoint.Shape. فيما يلي مثال على الشيفرة.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // الحصول على معرف الشكل الفريد في نطاق الشريحة
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```


## **ضبط النص البديل لشكل**
Aspose.Slides for Java يسمح للمطورين بضبط AlternateText لأي شكل. يمكن تمييز الأشكال في عرض تقديمي عبر الطريقة [AlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) أو طريقة [Shape Name](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setName-java.lang.String-). يمكن قراءة أو ضبط الطريقتين [setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) و [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getAlternativeText--) باستخدام Aspose.Slides وكذلك Microsoft PowerPoint. باستخدام هذه الطريقة، يمكنك وضع علامة على الشكل وإجراء عمليات مختلفة مثل إزالة الشكل، إخفاء الشكل أو إعادة ترتيب الأشكال على الشريحة. لضبط AlternateText لشكل، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
1. الوصول إلى الشريحة الأولى.
1. إضافة أي شكل إلى الشريحة.
1. القيام ببعض الأعمال مع الشكل المضاف حديثًا.
1. التجول عبر الأشكال للعثور على الشكل.
1. ضبط AlternativeText.
1. حفظ الملف على القرص.
```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة شكل أوتوماتيكي من نوع مستطيل
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
Aspose.Slides for Java يوفر API بسيط للوصول إلى تنسيقات التخطيط لشكل. توضح هذه المقالة كيفية الوصول إلى تنسيقات التخطيط.

فيما يلي مثال على الشيفرة.
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


## **تصيير شكل بصيغة SVG**
الآن يدعم Aspose.Slides for Java تصيير شكل كـ SVG. تم إضافة الطريقة [writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (مع التحميل الزائد لها) إلى فئة [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/Shape) وواجهة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape). تسمح هذه الطريقة بحفظ محتوى الشكل كملف SVG. يوضح المقتطف أدناه كيفية تصدير شكل الشريحة إلى ملف SVG.
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
Aspose.Slides يسمح بمحاذاة الأشكال إما بالنسبة لهوامش الشريحة أو بالنسبة لبعضها البعض. لهذا الغرض، تمت إضافة الطريقة المحملة الزائدة [SlidesUtil.alignShape()](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) . تعداد [ShapesAlignmentType](https://reference.aspose.com/slides/java/com.aspose.slides/ShapesAlignmentType) يحدد خيارات المحاذاة الممكنة.

**Example 1**

الكود المصدر أدناه يوازن الأشكال ذات الفهارس 1 و2 و4 على الحدود العليا للشريحة.
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


**Example 2**

المثال أدناه يوضح كيفية محاذاة مجموعة الأشكال بأكملها بالنسبة لأدنى شكل في المجموعة.
```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```


## **خصائص الانعكاس**
في Aspose.Slides، توفر الفئة [ShapeFrame](https://reference.aspose.com/slides/java/com.aspose.slides/shapeframe/) التحكم في انعكاس الأشكال أفقيًا وعموديًا عبر الخاصيتين `flipH` و `flipV`. كلتا الخاصيتين من النوع `byte`، ويمكن أن تكون قيمتها `1` للدلالة على انعكاس، `0` لعدم الانعكاس، أو `-1` لاستخدام السلوك الافتراضي. يمكن الوصول إلى هذه القيم من خلال [Frame](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getFrame--) الخاص بالشكل.

لتعديل إعدادات الانعكاس، يتم إنشاء كائن جديد من فئة [ShapeFrame](https://reference.aspose.com/slides/java/com.aspose.slides/shapeframe/) باستخدام موقع وحجم الشكل الحالي، والقيم المطلوبة للخاصيتين `flipH` و `flipV`، وزاوية الدوران. يتم تعيين هذا الكائن إلى [Frame](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getFrame--) الخاص بالشكل، ثم حفظ العرض التقديمي لتطبيق التحولات المرآة وتسجيلها في ملف الإخراج.

لنفترض أن لدينا ملف sample.pptx يحتوي على شريحة أولى بها شكل واحد بإعدادات انعكاس افتراضية، كما هو موضح أدناه.

![The shape to be flipped](shape_to_be_flipped.png)

المثال التالي يسترجع خصائص الانعكاس الحالية للشكل ويقلبه أفقيًا وعموديًا.
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // استرجاع خاصية الانعكاس الأفقي للشكل.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // استرجاع خاصية الانعكاس الرأسي للشكل.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Flip horizontally.
    byte flipV = NullableBool.True; // Flip horizontally.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


النتيجة:

![The flipped shape](flipped_shape.png)

## **الأسئلة المتكررة**

**هل يمكنني دمج الأشكال (union/intersect/subtract) على شريحة كما في محرر سطح المكتب؟**

لا توجد واجهة برمجة تطبيقات مدمجة للعمليات البولية. يمكنك تقريب ذلك بإنشاء المخطط المطلوب يدويًا—على سبيل المثال، حساب الهندسة الناتجة (عبر [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)) وإنشاء شكل جديد بهذا المخطط، مع إمكانية حذف الأشكال الأصلية.

**كيف يمكنني التحكم في ترتيب التراكب (z-order) بحيث يبقى الشكل دائمًا "في المقدمة"؟**

غيّر ترتيب الإدراج/النقل داخل مجموعة [shapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) الخاصة بالشريحة. للحصول على نتائج متوقعة، احرص على finalize ترتيب z-order بعد جميع تعديلات الشريحة الأخرى.

**هل يمكنني "قفل" شكل لمنع المستخدمين من تحريره في PowerPoint؟**

نعم. اضبط علامات الحماية على مستوى الشكل ([shape-level protection flags](/slides/ar/java/applying-protection-to-presentation/)) مثل قفل التحديد، الحركة، تغيير الحجم، تحرير النص. إذا لزم الأمر، يمكن تطبيق قيود مماثلة على القالب أو التخطيط. لاحظ أن هذا الحماية على مستوى الواجهة، وليس خاصية أمان؛ للحصول على حماية أقوى، يمكن دمجها مع قيود على مستوى الملف مثل توصيات القراءة فقط أو كلمات مرور ([read-only recommendations or passwords](/slides/ar/java/password-protected-presentation/)).