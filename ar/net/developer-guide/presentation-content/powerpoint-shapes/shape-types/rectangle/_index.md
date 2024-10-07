---
title: مستطيل
type: docs
weight: 80
url: /net/rectangle/
keywords: "إنشاء مستطيل، شكل PowerPoint، تقديم PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "إنشاء مستطيل في تقديم PowerPoint باستخدام C# أو .NET"
---


## **إنشاء مستطيل بسيط**
مثل المواضيع السابقة، هذه أيضًا تتعلق بإضافة شكل، وهذه المرة الشكل الذي سنتحدث عنه هو المستطيل. في هذا الموضوع، قمنا بشرح كيفية تمكين المطورين من إضافة مستطيلات بسيطة أو منسقة إلى شرائحهم باستخدام Aspose.Slides لـ .NET. لإضافة مستطيل بسيط إلى شريحة مختارة من العرض، يرجى اتباع الخطوات أدناه:

1. قم بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
1. احصل على مرجع الشريحة باستخدام فهرسها.
1. أضف IAutoShape من نوع المستطيل باستخدام طريقة AddAutoShape المكشوفة بواسطة كائن IShapes.
1. اكتب العرض المعدل كملف PPTX.

في المثال المعطى أدناه، أضفنا مستطيلًا بسيطًا إلى الشريحة الأولى من العرض.

```c#
// Instantiate Prseetation class that represents the PPTX
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Add autoshape of rectangle type
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //Write the PPTX file to disk
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```


## **إنشاء مستطيل مزخرف**
لإضافة مستطيل مزخرف إلى شريحة، يرجى اتباع الخطوات أدناه:

1. قم بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
1. احصل على مرجع الشريحة باستخدام فهرسها.
1. أضف IAutoShape من نوع المستطيل باستخدام طريقة AddAutoShape المكشوفة بواسطة كائن IShapes.
1. اضبط نوع التعبئة للمستطيل إلى صلب.
1. اضبط لون المستطيل باستخدام خاصية SolidFillColor.Color كما هو مكشوف من كائن FillFormat المرتبط بكائن IShape.
1. اضبط لون خطوط المستطيل.
1. اضبط عرض خطوط المستطيل.
1. اكتب العرض المعدل كملف PPTX.
   تم تنفيذ الخطوات أعلاه في المثال المعطى أدناه.

```c#
// Instantiate Prseetation class that represents the PPTX
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Add autoshape of rectangle type
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Apply some formatting to rectangle shape
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Apply some formatting to the line of rectangle
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Write the PPTX file to disk
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```