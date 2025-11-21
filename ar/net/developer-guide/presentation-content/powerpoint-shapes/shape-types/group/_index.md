---
title: مجموعة
type: docs
weight: 40
url: /ar/net/group/
keywords: "شكل مجموعة, شكل PowerPoint, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "إضافة شكل مجموعة إلى عرض PowerPoint باستخدام C# أو .NET"
---

## **Add Group Shape**
يدعم Aspose.Slides العمل مع أشكال المجموعات على الشرائح. تساعد هذه الميزة المطورين على إنشاء عروض تقديمية أكثر غنى. يدعم Aspose.Slides for .NET إضافة أو الوصول إلى أشكال المجموعات. يمكن إضافة أشكال إلى شكل مجموعة مضاف لملئه أو للوصول إلى أي خاصية من خصائص شكل المجموعة. لإضافة شكل مجموعة إلى شريحة باستخدام Aspose.Slides for .NET:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. إضافة شكل مجموعة إلى الشريحة.
1. إضافة الأشكال إلى شكل المجموعة المضاف.
1. حفظ العرض المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى شريحة.
```c#
// إنشاء كائن من الفئة Presentation 
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

    // إضافة إطار لشكل المجموعة 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // كتابة ملف PPTX إلى القرص 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```


## **Access AltText Property**
يوضح هذا الموضوع خطوات بسيطة، مع أمثلة شفرة، لإضافة شكل مجموعة والوصول إلى خاصية AltText لأشكال المجموعات على الشرائح. للوصول إلى AltText لشكل مجموعة في شريحة باستخدام Aspose.Slides for .NET:

1. إنشاء كائن من الفئة `Presentation` التي تمثل ملف PPTX.
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. الوصول إلى مجموعة الأشكال في الشرائح.
1. الوصول إلى شكل المجموعة.
1. الوصول إلى خاصية AltText.

المثال أدناه يصل إلى النص البديل لشكل المجموعة.
```c#
// إنشاء كائن من الفئة Presentation التي تمثل ملف PPTX
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


## **FAQ**

**Is nested grouping (a group inside a group) supported?**

نعم. يحتوي [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) على خاصية [ParentGroup](https://reference.aspose.com/slides/net/aspose.slides/shape/parentgroup/) التي تشير مباشرة إلى دعم التسلسل الهرمي (يمكن أن تكون مجموعة فرعية لمجموعة أخرى).

**How do I control the group’s z-order relative to other objects on the slide?**

استخدم خاصية [ZOrderPosition](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) الخاصة بـ[GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) لتفقد موقعها في طبقة العرض.

**Can I prevent moving/editing/ungrouping?**

نعم. يتم توفير قسم القفل للمجموعة عبر [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshape/groupshapelock/)، والذي يسمح لك بتقييد العمليات على الكائن.