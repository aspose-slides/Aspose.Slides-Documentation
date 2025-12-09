---
title: صورة
type: docs
weight: 50
url: /ar/net/examples/elements/picture/
keywords:
- مثال صورة
- إطار صورة
- إضافة صورة
- الوصول إلى صورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "العمل مع الصور في C# باستخدام Aspose.Slides: إدراج، استبدال، قص، ضغط، تعديل الشفافية والتأثيرات، ملء الأشكال، وتصدير إلى PPT و PPTX و ODP."
---

يعرض كيفية إدراج والوصول إلى الصور من الصور المخزنة في الذاكرة باستخدام **Aspose.Slides for .NET**. الأمثلة أدناه تنشئ صورة في الذاكرة، تضعها على شريحة، ثم تسترجعها.

## إضافة صورة

يقوم هذا الكود بإنشاء بت ماب صغير، ويحوّله إلى تدفق، ثم يدرجه كإطار صورة على الشريحة الأولى.
```csharp
public static void Add_Picture()
{
    using var pres = new Presentation();

    // إنشاء صورة بسيطة في الذاكرة
    using var bmp = new Bitmap(width: 100, height: 100);
    using (var g = Graphics.FromImage(bmp))
    {
        g.Clear(Color.LightGreen);
    }

    // تحويل الـ Bitmap إلى MemoryStream
    using var imageStream = new MemoryStream();
    bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // إضافة الصورة إلى العرض التقديمي
    var ppImage = pres.Images.AddImage(imageStream);

    // إدراج إطار صورة يُظهر الصورة على الشريحة الأولى
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bmp.Width, height: bmp.Height, ppImage);

    pres.Save(@"c:\_tmp\xxx.pptx", SaveFormat.Pptx);
}
```


## الوصول إلى صورة

يتأكد هذا المثال من أن الشريحة تحتوي على إطار صورة ثم يصل إلى أول إطار يجدها.
```csharp
public static void Access_Picture()
{
    using var pres = new Presentation();

    // تأكد من وجود إطار صورة واحد على الأقل للعمل معه
    using var bmp = new Bitmap(40, 40);

    // تحويل الـ Bitmap إلى MemoryStream
    using var imageStream = new MemoryStream();
    bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // إضافة الصورة إلى العرض التقديمي
    var ppImage = pres.Images.AddImage(imageStream);
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, ppImage);

    // الوصول إلى أول إطار صورة في الشريحة
    var pictureFrame = pres.Slides[0].Shapes.OfType<PictureFrame>().First();
}
```
