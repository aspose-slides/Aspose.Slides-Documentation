---
title: مجموعات أشكال العروض التقديمية في .NET
linktitle: مجموعة الأشكال
type: docs
weight: 40
url: /ar/net/group/
keywords:
- شكل مجموعة
- مجموعة أشكال
- إضافة مجموعة
- نص بديل
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية تجميع وفك تجميع الأشكال في عروض PowerPoint باستخدام Aspose.Slides for .NET—دليل سريع خطوة بخطوة مع كود C# مجاني."
---

## **Add a Group Shape**
تدعم Aspose.Slides العمل مع مجموعات الأشكال على الشرائح. تساعد هذه الميزة المطورين على إنشاء عروض تقديمية أغنى. تدعم Aspose.Slides for .NET إضافة أو الوصول إلى مجموعات الأشكال. يمكن إضافة أشكال إلى مجموعة الأشكال المضافة لملئها أو للوصول إلى أي خاصية من خصائص مجموعة الأشكال. لإضافة مجموعة أشكال إلى شريحة باستخدام Aspose.Slides for .NET:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها
1. إضافة مجموعة أشكال إلى الشريحة.
1. إضافة الأشكال إلى مجموعة الأشكال المضافة.
1. حفظ العرض التقديمي المعدل كملف PPTX.

المثال التالي يضيف مجموعة أشكال إلى شريحة.
```c#
// إنشاء كائن من فئة Presentation 
using (Presentation pres = new Presentation())
{
    // الحصول على الشريحة الأولى 
    ISlide sld = pres.Slides[0];

    // الوصول إلى مجموعة الأشكال في الشرائح 
    IShapeCollection slideShapes = sld.Shapes;

    // إضافة مجموعة أشكال إلى الشريحة 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // إضافة أشكال داخل مجموعة الأشكال المضافة 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // إضافة إطار مجموعة الأشكال 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // كتابة ملف PPTX إلى القرص 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```


## **Access the AltText Property**
يُظهر هذا الموضوع خطوات بسيطة، مدعومة بأمثلة شفرة، لإضافة مجموعة أشكال والوصول إلى خاصية AltText لمجموعات الأشكال على الشرائح. للوصول إلى AltText لمجموعة أشكال في شريحة باستخدام Aspose.Slides for .NET:

1. إنشاء مثيل من الفئة `Presentation` التي تمثل ملف PPTX.
1. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
1. الوصول إلى مجموعة الأشكال في الشرائح.
1. الوصول إلى مجموعة الأشكال.
1. الوصول إلى خاصية AltText.

المثال التالي يصل إلى النص البديل لمجموعة الأشكال.
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
        // الوصول إلى مجموعة الأشكال.
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
نعم. يحتوي [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) على خاصية [ParentGroup](https://reference.aspose.com/slides/net/aspose.slides/shape/parentgroup/) ، التي تشير مباشرةً إلى دعم الهرمية (يمكن أن تكون مجموعة فرعية لمجموعة أخرى).

**How do I control the group’s z-order relative to other objects on the slide?**  
استخدم خاصية [ZOrderPosition](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) الخاصة بـ [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) لتفقد موقعها في مكدس العرض.

**Can I prevent moving/editing/ungrouping?**  
نعم. يتم كشف قسم القفل للمجموعة عبر [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshape/groupshapelock/)، مما يتيح لك تقييد العمليات على الكائن.