---
title: أشكال مجموعة العروض التقديمية في .NET
linktitle: مجموعة الشكل
type: docs
weight: 40
url: /ar/net/group/
keywords:
- شكل مجموعة
- مجموعة الشكل
- إضافة مجموعة
- نص بديل
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية تجميع وإلغاء تجميع الأشكال في عروض PowerPoint باستخدام Aspose.Slides لـ .NET—دليل سريع خطوة بخطوة مع شفرة C# مجانية."
---

## **إضافة شكل مجموعة**
Aspose.Slides تدعم العمل مع أشكال المجموعات على الشرائح. هذه الميزة تساعد المطورين على إنشاء عروض تقديمية أغنى. Aspose.Slides لـ .NET يدعم إضافة أو الوصول إلى أشكال المجموعات. يمكن إضافة أشكال إلى شكل مجموعة مضاف لملئه أو للوصول إلى أي خاصية من خصائص شكل المجموعة. لإضافة شكل مجموعة إلى شريحة باستخدام Aspose.Slides لـ .NET:

1. إنشاء مثال من الفئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع شريحة باستخدام فهرسها
1. إضافة شكل مجموعة إلى الشريحة.
1. إضافة الأشكال إلى شكل المجموعة المضاف.
1. حفظ العرض التقديمي المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى شريحة.
```c#
// إنشاء كائن من فئة Presentation 
using (Presentation pres = new Presentation())
{
    // الحصول على الشريحة الأولى 
    ISlide sld = pres.Slides[0];

    // الوصول إلى مجموعة الأشكال في الشرائح 
    IShapeCollection slideShapes = sld.Shapes;

    // إضافة شكل مجموعة إلى الشريحة 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // إضافة أشكال داخل شكل المجموعة المضاف 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // إضافة إطار شكل المجموعة 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // كتابة ملف PPTX إلى القرص 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```


## **الوصول إلى خاصية AltText**
هذا الموضوع يوضح خطوات بسيطة، مع أمثلة شفرة، لإضافة شكل مجموعة والوصول إلى خاصية AltText لأشكال المجموعات على الشرائح. للوصول إلى AltText لشكل مجموعة في شريحة باستخدام Aspose.Slides لـ .NET:

1. إنشاء مثال من الفئة `Presentation` التي تمثل ملف PPTX.
1. الحصول على مرجع شريحة باستخدام فهرسها.
1. الوصول إلى مجموعة الأشكال للشرائح.
1. الوصول إلى شكل المجموعة.
1. الوصول إلى خاصية AltText.

المثال أدناه يصل إلى النص البديل لشكل المجموعة.
```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation("AltText.pptx");

// الحصول على الشريحة الأولى
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // الوصول إلى مجموعة الأشكال في الشرائح
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // الوصول إلى شكل المجموعة.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // الوصول إلى خاصية AltText
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```


## **الأسئلة الشائعة**

**هل يتم دعم التجميع المتداخل (مجموعة داخل مجموعة)؟**

نعم. يحتوي [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) على خاصية [ParentGroup](https://reference.aspose.com/slides/net/aspose.slides/shape/parentgroup/) التي تشير مباشرةً إلى دعم التسلسل الهرمي (يمكن أن تكون مجموعة فرعية لمجموعة أخرى).

**كيف يمكنني التحكم في ترتيب Z (z-order) للمجموعة بالنسبة للكائنات الأخرى على الشريحة؟**

استخدم خاصية [ZOrderPosition](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) الخاصة بـ [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) لفحص موقعه في مكدس العرض.

**هل يمكنني منع التحريك/التحرير/إلغاء التجميع؟**

نعم. يتم كشف قسم القفل للمجموعة عبر [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshape/groupshapelock/)، والذي يسمح لك بتقييد العمليات على الكائن.