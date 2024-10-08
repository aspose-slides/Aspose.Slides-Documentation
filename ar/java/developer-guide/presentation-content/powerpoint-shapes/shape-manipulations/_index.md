---
title: تلاعب الأشكال
type: docs
weight: 40
url: /ar/java/shape-manipulations/
---

## **البحث عن شكل في الشريحة**
سيتناول هذا الموضوع تقنية بسيطة لتسهيل على المطورين العثور على شكل معين في الشريحة دون استخدام معرفه الداخلي. من المهم معرفة أن ملفات PowerPoint لا تحتوي على أي وسيلة لتحديد الأشكال في الشريحة باستثناء معرف فريد داخلي. يبدو أنه من الصعب على المطورين العثور على شكل باستخدام معرفه الفريد الداخلي. جميع الأشكال المضافة إلى الشرائح تحتوي على نص بديل. نقترح على المطورين استخدام النص البديل للعثور على شكل معين. يمكنك استخدام MS PowerPoint لتعريف النص البديل للعناصر التي تخطط لتغييرها في المستقبل.

بعد ضبط النص البديل لأي شكل مرغوب، يمكنك بعد ذلك فتح تلك العرض التقديمي باستخدام Aspose.Slides لـ Java والتكرار عبر جميع الأشكال المضافة إلى الشريحة. خلال كل تكرار، يمكنك التحقق من النص البديل للشكل والشكل الذي يتطابق مع النص البديل سيكون الشكل المطلوب منك. لإظهار هذه التقنية بطريقة أفضل، قمنا بإنشاء طريقة، [findShape](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) التي تجد شكل معين في الشريحة ثم تعيد ببساطة ذلك الشكل.

```java
// إنشاء كائن من فئة Presentation يمثل ملف العرض التقديمي
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
// تنفيذ الطريقة للعثور على شكل في شريحة باستخدام نصه البديل
public static IShape findShape(ISlide slide, String alttext)
{
    // التكرار عبر جميع الأشكال داخل الشريحة
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // إذا كان النص البديل للشريحة يتطابق مع المطلوب
        // أعد الشكل
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **استنساخ شكل**
لاستنساخ شكل إلى الشريحة باستخدام Aspose.Slides لـ Java:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. الحصول على مرجع لشريحة باستخدام فهرسها.
1. الوصول إلى مجموعة أشكال الشريحة المصدر.
1. إضافة شريحة جديدة إلى العرض التقديمي.
1. استنساخ الأشكال من مجموعة أشكال الشريحة المصدر إلى الشريحة الجديدة.
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
يسمح Aspose.Slides لـ Java للمطورين بإزالة أي شكل. لإزالة الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل مع نص بديل محدد.
1. إزالة الشكل.
1. حفظ الملف على القرص.

```java
// إنشاء كائن Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع المربع
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "مستخدم معرف";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // حفظ العرض التقديمي على القرص
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إخفاء شكل**
يسمح Aspose.Slides لـ Java للمطورين بإخفاء أي شكل. لإخفاء الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل مع نص بديل محدد.
1. إخفاء الشكل.
1. حفظ الملف على القرص.

```java
// إنشاء كائن Presentation يمثل PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع المربع
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "مستخدم معرف";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // حفظ العرض التقديمي على القرص
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغيير ترتيب الأشكال**
يسمح Aspose.Slides لـ Java للمطورين بإعادة ترتيب الأشكال. إعادة ترتيب الشكل تحدد أي شكل يكون في المقدمة أو أي شكل يكون في الخلف. لإعادة ترتيب الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة شكل.
1. إضافة بعض النص في إطار نص الشكل.
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
    portion.setText("نص علامة مائية نص علامة مائية نص علامة مائية");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على معرف شكل Interop**
يسمح Aspose.Slides لـ Java للمطورين بالحصول على معرف شكل فريد في نطاق الشريحة على عكس طريقة [getUniqueId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getUniqueId--)، التي تسمح بالحصول على معرف فريد في نطاق العرض التقديمي. تمت إضافة طريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) إلى واجهات [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) و [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/Shape) كلاس على التوالي. القيمة التي تعيدها طريقة [getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) تتوافق مع قيمة المعرف لكائن Microsoft.Office.Interop.PowerPoint.Shape. أدناه عينة من الكود المقدمة.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // الحصول على معرف شكل فريد في نطاق الشريحة
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين نص بديل للشكل**
يسمح Aspose.Slides لـ Java للمطورين بتعيين نص بديل لأي شكل.
يمكن تمييز الأشكال في عرض تقديمي من خلال طرق [AlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) أو [اسم الشكل](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setName-java.lang.String-).
يمكن قراءة أو تعيين [setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) و [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getAlternativeText--) باستخدام Aspose.Slides وكذلك Microsoft PowerPoint.
باستخدام هذه الطريقة، يمكنك تمييز شكل ويمكنك إجراء عمليات مختلفة مثل إزالة شكل،
إخفاء شكل أو إعادة ترتيب أشكال على الشريحة.
لتعيين النص البديل لشكل، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة أي شكل إلى الشريحة.
1. تنفيذ بعض المهام مع الشكل المضاف حديثًا.
1. الاستعراض عبر الأشكال للعثور على شكل.
1. تعيين النص البديل.
1. حفظ الملف على القرص.

```java
// إنشاء كائن Presentation يمثل PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع المربع
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("مستخدم معرف");
        }
    }

    // حفظ العرض التقديمي على القرص
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الوصول إلى تنسيقات التخطيط للشكل**
يوفر Aspose.Slides لـ Java واجهة برمجة تطبيقات بسيطة للوصول إلى تنسيقات التخطيط لشكل. توضح هذه المقالة كيفية الوصول إلى تنسيقات التخطيط.

أدناه عينة من الشيفرة المقدمة.

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

## **رسم الشكل كـ SVG**
الآن يدعم Aspose.Slides لـ Java رسم شكل كـ SVG. تمت إضافة طريقة [writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (وتجاوزاتها) إلى [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/Shape) كلاس وواجهة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape). تتيح لك هذه الطريقة حفظ محتوى الشكل كملف SVG. يوضح مقتطف الكود أدناه كيفية تصدير شكل الشريحة إلى ملف SVG.

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
يسمح Aspose.Slides بمحاذاة الأشكال إما بالنسبة لهامش الشريحة أو بالنسبة لبعضها البعض. لهذا الغرض، تمت إضافة طريقة التحميل الزائد [SlidesUtil.alignShape()](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) . يحدد التعداد [ShapesAlignmentType](https://reference.aspose.com/slides/java/com.aspose.slides/ShapesAlignmentType) خيارات المحاذاة الممكنة.

**المثال 1**

يدرج الشيفرة المصدرية أدناه الأشكال ذات الفهارس 1 و 2 و 4 على طول الحدود العليا للشريحة.

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

**المثال 2**

يوضح المثال أدناه كيفية محاذاة مجموعة الأشكال بالكامل بالنسبة لأدنى شكل في المجموعة.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```