---
title: "أشكال مجموعة العروض التقديمية في جافا"
linktitle: "مجموعة الأشكال"
type: docs
weight: 40
url: /ar/java/group/
keywords:
- "مجموعة الشكل"
- "مجموعة الأشكال"
- "إضافة مجموعة"
- "نص بديل"
- "PowerPoint"
- "عرض تقديمي"
- "Java"
- "Aspose.Slides"
description: "تعلم كيفية تجميع وفك تجميع الأشكال في عروض PowerPoint باستخدام Aspose.Slides للغة Java-دليل سريع خطوة بخطوة مع كود Java مجاني."
---

## **إضافة شكل مجموعة**
يدعم Aspose.Slides العمل مع أشكال المجموعات في الشرائح. تساعد هذه الميزة المطورين على إنشاء عروض تقديمية أكثر غنى. يدعم Aspose.Slides for Java إضافة أو الوصول إلى أشكال المجموعات. يمكن إضافة أشكال إلى شكل مجموعة مضاف لتعبئته أو الوصول إلى أي خاصية من خصائص شكل المجموعة. لإضافة شكل مجموعة إلى شريحة باستخدام Aspose.Slides for Java:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
1. إضافة شكل مجموعة إلى الشريحة.
1. إضافة الأشكال إلى شكل المجموعة المضاف.
1. حفظ العرض المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى شريحة.
```java
// إنشاء فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // الوصول إلى مجموعة الأشكال في الشرائح
    IShapeCollection slideShapes = sld.getShapes();

    // إضافة شكل مجموعة إلى الشريحة
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // إضافة أشكال داخل مجموعة الشكل المضافة
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // إضافة إطار مجموعة الشكل
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // كتابة ملف PPTX إلى القرص
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الوصول إلى خاصية AltText**
يظهر هذا الموضوع خطوات بسيطة، مع أمثلة شفرة، لإضافة شكل مجموعة والوصول إلى خاصية AltText لأشكال المجموعات في الشرائح. للوصول إلى AltText لشكل مجموعة في شريحة باستخدام Aspose.Slides for Java:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي تمثل ملف PPTX.
1. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
1. الوصول إلى مجموعة الأشكال في الشرائح.
1. الوصول إلى شكل المجموعة.
1. الوصول إلى خاصية [AlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getAlternativeText--) .

المثال أدناه يصل إلى النص البديل لشكل المجموعة.
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // الوصول إلى مجموعة الأشكال في الشرائح
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


## **الأسئلة الشائعة**

**هل تدعم التجميع المتداخل (مجموعة داخل مجموعة)؟**

نعم. يحتوي [GroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/) على طريقة [getParentGroup](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getParentGroup--)، التي تشير مباشرة إلى دعم التسلسل الهرمي (يمكن أن تكون المجموعة طفلاً لمجموعة أخرى).

**كيف يمكنني التحكم بترتيب Z للمجموعة بالنسبة للكائنات الأخرى على الشريحة؟**

استخدم طريقة [getZOrderPosition](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getZOrderPosition--) الخاصة بـ [GroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/) لفحص موقعه في مكدس العرض.

**هل يمكنني منع التحريك/التحرير/إلغاء التجميع؟**

نعم. يتم كشف قسم القفل للمجموعة عبر [GroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/#getGroupShapeLock--)، والذي يسمح لك بتقييد العمليات على الكائن.