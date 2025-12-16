---
title: أشكال مجموعة العرض التقديمي على Android
linktitle: مجموعة الشكل
type: docs
weight: 40
url: /ar/androidjava/group/
keywords:
- شكل مجموعة
- مجموعة الشكل
- إضافة مجموعة
- نص بديل
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية تجميع وفك تجميع الأشكال في عروض PowerPoint باستخدام Aspose.Slides للأندرويد—دليل سريع خطوة بخطوة مع كود Java مجاني."
---

## **إضافة شكل مجموعة**
Aspose.Slides يدعم العمل مع أشكال المجموعات على الشرائح. تساعد هذه الميزة المطورين على إنشاء عروض تقديمية أكثر ثراءً. Aspose.Slides للأندرويد عبر جافا يدعم إضافة أو الوصول إلى أشكال المجموعات. يمكن إضافة أشكال إلى شكل مجموعة مضاف لملئه أو للوصول إلى أي خاصية من خصائص شكل المجموعة. لإضافة شكل مجموعة إلى شريحة باستخدام Aspose.Slides للأندرويد عبر جافا:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع شريحة باستخدام فهرسها
3. إضافة شكل مجموعة إلى الشريحة.
4. إضافة الأشكال إلى شكل المجموعة المُضاف.
5. حفظ العرض التقديمي المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى شريحة.
```java
// إنشاء كائن من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // الوصول إلى مجموعة الأشكال في الشرائح
    IShapeCollection slideShapes = sld.getShapes();

    // إضافة شكل مجموعة إلى الشريحة
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // إضافة أشكال داخل شكل المجموعة المضاف
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // إضافة إطار لشكل المجموعة
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // كتابة ملف PPTX إلى القرص
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الوصول إلى خاصية AltText**
هذا الموضوع يوضح خطوات بسيطة، مع أمثلة أكواد، لإضافة شكل مجموعة والوصول إلى خاصية AltText لأشكال المجموعات على الشرائح. للوصول إلى AltText لشكل مجموعة في شريحة باستخدام Aspose.Slides للأندرويد عبر جافا:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) التي تمثل ملف PPTX.
2. الحصول على مرجع شريحة باستخدام فهرسها.
3. الوصول إلى مجموعة الأشكال في الشرائح.
4. الوصول إلى شكل المجموعة.
5. الوصول إلى خاصية [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) .

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

**هل يتم دعم التجميع المتداخل (مجموعة داخل مجموعة)؟**

نعم. [GroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/) يحتوي على طريقة [getParentGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getParentGroup--)، التي تشير مباشرةً إلى دعم الهرمية (يمكن أن تكون مجموعة طفلاً لمجموعة أخرى).

**كيف يمكنني التحكم في ترتيب Z للمجموعة بالنسبة للكائنات الأخرى على الشريحة؟**

استخدم طريقة [getZOrderPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getZOrderPosition--) الخاصة بـ [GroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/) لفحص موقعها في مكدس العرض.

**هل يمكنني منع التحريك/التحرير/إلغاء التجميع؟**

نعم. قسم القفل للمجموعة متاح عبر [getGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/#getGroupShapeLock--)، مما يتيح لك تقييد العمليات على الكائن.