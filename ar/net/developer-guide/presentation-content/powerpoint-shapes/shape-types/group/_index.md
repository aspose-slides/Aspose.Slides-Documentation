---
title: مجموعة
type: docs
weight: 40
url: /net/group/
keywords: "شكل مجموعة، شكل PowerPoint، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "إضافة شكل مجموعة إلى عرض PowerPoint في C# أو .NET"
---

## **إضافة شكل مجموعة**
يدعم Aspose.Slides العمل مع أشكال المجموعة على الشرائح. تساعد هذه الميزة المطورين على دعم عروض تقديمية أكثر ثراءً. يدعم Aspose.Slides لـ .NET إضافة أو الوصول إلى أشكال المجموعة. من الممكن إضافة أشكال إلى شكل مجموعة مضاف لملئه أو الوصول إلى أي خاصية من شكل المجموعة. لإضافة شكل مجموعة إلى شريحة باستخدام Aspose.Slides لـ .NET:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع شريحة باستخدام مؤشرها.
1. إضافة شكل مجموعة إلى الشريحة.
1. إضافة الأشكال إلى شكل المجموعة المضاف.
1. حفظ العرض التقديمي المعدل كملف PPTX.

يضيف المثال أدناه شكل مجموعة إلى شريحة.

```c#
// إنشاء مثيل لفئة Presentation 
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
تظهر هذه الموضوع خطوات بسيطة، مع أمثلة للشفرة، لإضافة شكل مجموعة والوصول إلى خاصية AltText لأشكال المجموعة على الشرائح. للوصول إلى AltText لشكل مجموعة في شريحة باستخدام Aspose.Slides لـ .NET:

1. إنشاء فئة `Presentation` التي تمثل ملف PPTX.
1. الحصول على مرجع شريحة باستخدام مؤشرها.
1. الوصول إلى مجموعة الأشكال في الشرائح.
1. الوصول إلى شكل المجموعة.
1. الوصول إلى خاصية AltText.

يصل المثال أدناه إلى النص البديل لشكل المجموعة.

```c#
// إنشاء فئة Presentation التي تمثل ملف PPTX
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