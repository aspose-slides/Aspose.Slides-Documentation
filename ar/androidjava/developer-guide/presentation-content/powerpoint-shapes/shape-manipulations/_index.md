---
title: إدارة أشكال العروض التقديمية على Android
linktitle: معالجة الأشكال
type: docs
weight: 40
url: /ar/androidjava/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على الشريحة
- العثور على شكل
- استنساخ شكل
- إزالة شكل
- إخفاء شكل
- تغيير ترتيب الشكل
- الحصول على معرف Interop للشكل
- النص البديل للشكل
- تنسيقات تخطيط الشكل
- الشكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- PowerPoint
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية إنشاء وتحرير وتحسين الأشكال في Aspose.Slides للـ Android عبر Java وتقديم عروض PowerPoint عالية الأداء."
---

## **ابحث عن شكل على الشريحة**
سوف يصف هذا الموضوع تقنية بسيطة لتسهيل عملية العثور على شكل محدد في الشريحة للمطورين دون استخدام المعرف الداخلي الخاص به. من المهم معرفة أن ملفات عرض PowerPoint لا تحتوي على أي طريقة لتحديد الأشكال في الشريحة سوى المعرف الفريد الداخلي. يبدو أن العثور على شكل باستخدام المعرف الفريد الداخلي صعب بالنسبة للمطورين. جميع الأشكال المضافة إلى الشرائح تحتوي على نص بديل. نقترح على المطورين استخدام النص البديل للعثور على شكل محدد. يمكنك استخدام MS PowerPoint لتحديد النص البديل للكائنات التي تخطط لتغييرها في المستقبل.

بعد تعيين النص البديل لأي شكل مرغوب، يمكنك بعد ذلك فتح هذا العرض باستخدام Aspose.Slides للـ Android عبر Java وتتجول عبر جميع الأشكال المضافة إلى شريحة. خلال كل تكرار، يمكنك فحص النص البديل للشكل وسيكون الشكل الذي يمتلك النص البديل المطابق هو الشكل المطلوب. لتوضيح هذه التقنية بشكل أفضل، أنشأنا طريقة، [findShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) التي تقوم بالعثور على شكل محدد في شريحة وتُرجع ذلك الشكل ببساطة.
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
// تنفيذ طريقة للعثور على شكل في شريحة باستخدام النص البديل لها
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
1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الحصول على مرجع شريحة باستخدام فهرستها.
1. الوصول إلى مجموعة أشكال الشريحة المصدر.
1. إضافة شريحة جديدة إلى العرض.
1. استنساخ الأشكال من مجموعة أشكال الشريحة المصدر إلى الشريحة الجديدة.
1. حفظ العرض المعدل كملف PPTX.

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

    // حفظ ملف PPTX إلى القرص
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إزالة شكل**
يسمح Aspose.Slides للـ Android عبر Java للمطورين بإزالة أي شكل. لإزالة الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. البحث عن الشكل بنص بديل محدد.
1. إزالة الشكل.
1. حفظ الملف إلى القرص.
```java
// إنشاء كائن Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع مستطيل
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
يسمح Aspose.Slides للـ Android عبر Java للمطورين بإخفاء أي شكل. لإخفاء الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. البحث عن الشكل بنص بديل محدد.
1. إخفاء الشكل.
1. حفظ الملف إلى القرص.
```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع مستطيل
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
يسمح Aspose.Slides للـ Android عبر Java للمطورين بإعادة ترتيب الأشكال. يحدد إعادة ترتيب الشكل أي شكل يكون في المقدمة أو في الخلف. لإعادة ترتيب الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة شكل.
1. إضافة بعض النص إلى إطار النص الخاص بالشكل.
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


## **الحصول على معرف Interop للشكل**
يسمح Aspose.Slides للـ Android عبر Java للمطورين بالحصول على معرّف شكل فريد ضمن نطاق الشريحة بالمقارنة مع طريقة [getUniqueId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getUniqueId--)، التي تسمح بالحصول على معرّف فريد ضمن نطاق العرض. تمت إضافة طريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) إلى واجهة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) وفئة [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape). القيمة التي تُرجعها طريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) تتطابق مع قيمة المعرف لكائن Microsoft.Office.Interop.PowerPoint.Shape. أدناه عينة من الشفرة.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // الحصول على معرف الشكل الفريد في نطاق الشريحة
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين النص البديل لشكل**
يسمح Aspose.Slides للـ Android عبر Java للمطورين بتعيين AlternateText لأي شكل. يمكن تمييز الأشكال في عرض بواسطة طريقة [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) أو طريقة [Shape Name](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setName-java.lang.String-). يمكن قراءة أو تعيين الطريقتين [setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) و [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) باستخدام Aspose.Slides وكذلك Microsoft PowerPoint. باستخدام هذه الطريقة، يمكنك وسم شكل وتنفيذ عمليات مختلفة مثل إزالة الشكل، إخفاء الشكل أو إعادة ترتيب الأشكال في شريحة. لتعيين AlternateText لشكل، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة أي شكل إلى الشريحة.
1. تنفيذ بعض الأعمال مع الشكل المضاف حديثاً.
1. التنقل عبر الأشكال للعثور على الشكل.
1. تعيين AlternativeText.
1. حفظ الملف إلى القرص.
```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع مستطيل
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
يوفر Aspose.Slides للـ Android عبر Java واجهة برمجة تطبيقات بسيطة للوصول إلى تنسيقات التخطيط لشكل. توضح هذه المقالة كيفية الوصول إلى تنسيقات التخطيط.

العينة التالية من الشفرة موضحة.
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


## **تحويل شكل إلى SVG**
الآن يدعم Aspose.Slides للـ Android عبر Java تحويل شكل إلى SVG. تمت إضافة طريقة [writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (وإصدارها المتعدد) إلى فئة [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) وواجهة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape). تسمح هذه الطريقة بحفظ محتوى الشكل كملف SVG. يُظهر مقتطف الشفرة أدناه كيفية تصدير شكل الشريحة إلى ملف SVG.
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
يسمح Aspose.Slides بمحاذاة الأشكال إما بالنسبة لهوامش الشريحة أو بالنسبة لبعضها البعض. لهذا الغرض، تمت إضافة الطريقة المحملة بالعديد من المعلمات [SlidesUtil.alignShape()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-). تحدد enumeration [ShapesAlignmentType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapesAlignmentType) خيارات المحاذاة الممكنة.

**مثال 1**

الشفرة المصدرية أدناه تحاذي الأشكال ذات الفهارس 1 و2 و4 على الحافة العليا للشريحة.
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

المثال أدناه يوضح كيفية محاذاة مجموعة الأشكال بالكامل بالنسبة إلى الشكل الأدنى في المجموعة.
```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```


## **خصائص الانعكاس**
في Aspose.Slides، توفر فئة [ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) التحكم في الانعكاس الأفقي والرأسي للأشكال عبر خصائصها `flipH` و `flipV`. كلا الخصيصتين من النوع `byte`، حيث القيم `1` تعني انعكاس، `0` لا انعكاس، أو `-1` لاستخدام السلوك الافتراضي. هذه القيم يمكن الوصول إليها من خلال [Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--).

لتعديل إعدادات الانعكاس، يتم إنشاء مثيل جديد من [ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) باستخدام الموقع والحجم الحاليين للشكل، القيم المطلوبة لـ `flipH` و `flipV`، وزاوية الدوران. تعيين هذا المثيل إلى [Frame] الخاص بالشكل وحفظ العرض يطبق التحولات الانعكاسية ويضيفها إلى ملف الإخراج.

لنفترض أن لدينا ملف sample.pptx يحتوي على شريحة أولى بها شكل واحد بإعدادات الانعكاس الافتراضية، كما هو موضح أدناه.

![The shape to be flipped](shape_to_be_flipped.png)

الشيفرة التالية تسترجع خصائص الانعكاس الحالية للشكل وتقوم بعكسه أفقياً ورأسياً.
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // استرداد خاصية القلب الأفقي للشكل.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // استرداد خاصية القلب العمودي للشكل.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // قلب أفقي.
    byte flipV = NullableBool.True; // قلب أفقي.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


![The flipped shape](flipped_shape.png)

## **الأسئلة الشائعة**

**هل يمكنني دمج الأشكال (اتحاد/تقاطع/طرح) على شريحة كما في محرر سطح المكتب؟**

ليس هناك واجهة برمجة تطبيقات مدمجة للعمليات البوليانية. يمكنك تقريب ذلك بإنشاء المخطط المطلوب بنفسك—مثلاً حساب الهندسة الناتجة (باستخدام [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)) وإنشاء شكل جديد بذلك المخطط، مع إمكانية إزالة الأشكال الأصلية.

**كيف يمكنني التحكم بترتيب الرفع (z-order) بحيث يبقى الشكل دائماً "في الأعلى"؟**

غيّر ترتيب الإدراج/النقل داخل مجموعة [shapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) الخاصة بالشريحة. للحصول على نتائج متوقعة، أنهِ ترتيب z-order بعد إتمام جميع التعديلات الأخرى على الشريحة.

**هل يمكنني "قفل" شكل لمنع المستخدمين من تحريره في PowerPoint؟**

نعم. عيّن [علامات حماية على مستوى الشكل](/slides/ar/androidjava/applying-protection-to-presentation/) (مثل قفل التحديد، التحريك، تغيير الحجم، تحرير النص). إذا لزم الأمر، طبق القيود على القالب أو التخطيط. لاحظ أن هذه الحماية على مستوى واجهة المستخدم، وليست خاصية أمان؛ لتعزيز الحماية، يمكن دمجها مع قيود على مستوى الملف مثل [توصيات القراءة فقط أو كلمات المرور](/slides/ar/androidjava/password-protected-presentation/).