---
title: مجموعة
type: docs
weight: 40
url: /ar/androidjava/group/
---

## **إضافة شكل مجموعة**
يدعم Aspose.Slides العمل مع أشكال المجموعات على الشرائح. تساعد هذه الميزة المطورين في دعم عروض تقديمية أغنى. يدعم Aspose.Slides لنظام Android عبر Java إضافة أو الوصول إلى أشكال المجموعات. من الممكن إضافة أشكال إلى شكل مجموعة تم إضافته لتعبئته أو الوصول إلى أي خاصية من خصائص شكل المجموعة. لإضافة شكل مجموعة إلى شريحة باستخدام Aspose.Slides لنظام Android عبر Java:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الحصول على مرجع شريحة باستخدام فهرسها.
1. إضافة شكل مجموعة إلى الشريحة.
1. إضافة الأشكال إلى شكل المجموعة المضاف.
1. حفظ العرض التقديمي المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى شريحة.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // الوصول إلى مجموعة الأشكال على الشرائح
    IShapeCollection slideShapes = sld.getShapes();

    // إضافة شكل مجموعة إلى الشريحة
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // إضافة أشكال داخل شكل المجموعة المضاف
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // إضافة إطار شكل المجموعة
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // كتابة ملف PPTX إلى القرص
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الوصول إلى خاصية AltText**
توضح هذه الموضوع خطوات بسيطة، مكتملة بأمثلة من الشيفرة، لإضافة شكل مجموعة والوصول إلى خاصية AltText لأشكال المجموعة على الشرائح. للوصول إلى AltText لشكل مجموعة في شريحة باستخدام Aspose.Slides لنظام Android عبر Java:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) التي تمثل ملف PPTX.
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. الوصول إلى مجموعة الأشكال على الشرائح.
1. الوصول إلى شكل المجموعة.
1. الوصول إلى خاصية [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) .

المثال أدناه يصل إلى النص البديل لشكل المجموعة.

```java
// إنشاء مثيل من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // الوصول إلى مجموعة الأشكال على الشرائح
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // الوصول إلى شكل المجموعة.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // الوصول إلى خاصية AltText
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```