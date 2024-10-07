---
title: معالجة الأشكال
type: docs
weight: 40
url: /androidjava/shape-manipulations/
---

## **البحث عن شكل في الشريحة**
تتناول هذه الموضوع تقنية بسيطة لتسهيل على المطورين العثور على شكل معين في شريحة دون استخدام معرفه الداخلي. من المهم معرفة أن ملفات عرض PowerPoint لا تحتوي على طريقة لتحديد الأشكال في الشريحة سوى معرف فريد داخلي. يبدو أن من الصعب على المطورين العثور على شكل باستخدام معرفه الداخلي الفريد. جميع الأشكال المضافة إلى الشرائح تحتوي على نص بديل. نقترح على المطورين استخدام النص البديل للعثور على شكل معين. يمكنك استخدام MS PowerPoint لتحديد النص البديل للأشياء التي تخطط لتغييرها في المستقبل.

بعد ضبط النص البديل على أي شكل مرغوب فيه، يمكنك فتح هذا العرض باستخدام Aspose.Slides لـ Android عبر Java والتكرار عبر جميع الأشكال المضافة إلى الشريحة. خلال كل تكرار، يمكنك التحقق من النص البديل للشكل والشكل الذي يتطابق مع النص البديل سيكون الشكل المطلوب منك. لإظهار هذه التقنية بشكل أفضل، أنشأنا طريقة، [findShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) تقوم بالبحث عن شكل معين في الشريحة ثم ببساطة تعيد ذلك الشكل.

```java
// إنشاء فئة Presentation تمثل ملف العرض
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // النص البديل للشكل المراد العثور عليه
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("اسم الشكل: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// تنفيذ الطريقة للعثور على شكل في الشريحة باستخدام نصه البديل
public static IShape findShape(ISlide slide, String alttext)
{
    // التكرار عبر جميع الأشكال داخل الشريحة
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // إذا كان النص البديل للشريحة يتطابق مع النص المطلوب
        // أعد الشكل
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **نسخ الشكل**
لنسخ شكل إلى شريحة باستخدام Aspose.Slides لـ Android عبر Java:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الحصول على مرجع لشريحة باستخدام مؤشرها.
1. الوصول إلى مجموعة أشكال الشريحة المصدر.
1. إضافة شريحة جديدة إلى العرض.
1. نسخ الأشكال من مجموعة أشكال الشريحة المصدر إلى الشريحة الجديدة.
1. حفظ العرض المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى شريحة.

```java
// إنشاء فئة Presentation
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

## **إزالة الشكل**
تتيح Aspose.Slides لـ Android عبر Java للمطورين إزالة أي شكل. لإزالة الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل بمحدد النص البديل.
1. إزالة الشكل.
1. حفظ الملف على القرص.

```java
// إنشاء كائن Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع مستطيل
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "معرف من قبل المستخدم";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (altText.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // حفظ العرض على القرص
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إخفاء الشكل**
تتيح Aspose.Slides لـ Android عبر Java للمطورين إخفاء أي شكل. لإخفاء الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل بمحدد النص البديل.
1. إخفاء الشكل.
1. حفظ الملف على القرص.

```java
// إنشاء فئة Presentation تمثل الـ PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع مستطيل
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "معرف من قبل المستخدم";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (altText.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // حفظ العرض على القرص
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغيير ترتيب الأشكال**
تتيح Aspose.Slides لـ Android عبر Java للمطورين إعادة ترتيب الأشكال. تعيد ترتيب الشكل توضح أي شكل في المقدمة أو أي شكل في الخلف. لإعادة ترتيب الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة شكل.
1. إضافة نص داخل إطار نص الشكل.
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
    portion.setText("نص العلامة المائية نص العلامة المائية نص العلامة المائية");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على معرّف شكل Interop**
تتيح Aspose.Slides لـ Android عبر Java للمطورين الحصول على معرف فريد لشكل في نطاق الشريحة في مقابل طريقة [getUniqueId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getUniqueId--)، التي تتيح الحصول على معرف فريد في نطاق العرض. تمت إضافة طريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) إلى واجهات [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) وفئة [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) على التوالي. القيمة المعادة من طريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) تتوافق مع قيمة المعرّف لكائن Microsoft.Office.Interop.PowerPoint.Shape. أدناه تم إعطاء مثال على الشيفرة.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // الحصول على معرف الشكل الفريد في نطاق الشريحة
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين النص البديل للشكل**
تتيح Aspose.Slides لـ Android عبر Java للمطورين تعيين AlternateText لأي شكل. يمكن تمييز الأشكال في العرض باستخدام طريقة [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) أو [اسم الشكل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setName-java.lang.String-). يمكن قراءة أو تعيين طريقتي [setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) و[getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) باستخدام Aspose.Slides بالإضافة إلى Microsoft PowerPoint. 

باستخدام هذه الطريقة، يمكنك وسم شكل ويمكنك تنفيذ عمليات مختلفة مثل إزالة شكل، إخفاء شكل أو إعادة ترتيب الأشكال في الشريحة. لتعيين النص البديل لشكل، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة أي شكل إلى الشريحة.
1. تنفيذ بعض الأعمال مع الشكل المضاف حديثًا.
1. التجول عبر الأشكال للعثور على شكل.
1. تعيين النص البديل.
1. حفظ الملف على القرص.

```java
// إنشاء فئة Presentation تمثل الـ PPTX
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
            shape.setAlternativeText("معرف من قبل المستخدم");
        }
    }

    // حفظ العرض على القرص
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الوصول إلى تنسيقات التخطيط للشكل**
تتيح Aspose.Slides لـ Android عبر Java واجهة برمجة تطبيقات بسيطة للوصول إلى تنسيقات التخطيط لشكل. توضح هذه المقالة كيفية الوصول إلى تنسيقات التخطيط.

تم إعطاء مثال كود أدناه.

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

## **تحويل الشكل إلى SVG**
الآن تدعم Aspose.Slides لـ Android عبر Java تحويل الشكل إلى svg. تمت إضافة طريقة [writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (وأحمالها) إلى فئة [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) وواجهة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape). تتيح هذه الطريقة حفظ محتوى الشكل كملف SVG. يوضح مقطع الشيفرة أدناه كيفية تصدير شكل الشريحة إلى ملف SVG.

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

## **محاذاة الأشكال**
تتيح Aspose.Slides محاذاة الأشكال إما بالنسبة لحدود الشريحة أو بالنسبة لبعضها البعض. لهذا الغرض، تمت إضافة طريقة مشروطة [SlidesUtil.alignShape()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-). يحدد تعداد [ShapesAlignmentType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapesAlignmentType) خيارات المحاذاة الممكنة.

**مثال 1**

يقوم كود المصدر أدناه بمحاذاة الأشكال ذات الفهارس 1 و2 و4 على طول الحدود العلوية للوحة.

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
```

**مثال 2**

يوضح المثال أدناه كيف يمكن محاذاة مجموعة الأشكال بالكامل بالنسبة لأدنى شكل في المجموعة.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```