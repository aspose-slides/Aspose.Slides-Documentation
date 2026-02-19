---
title: صورة
type: docs
weight: 50
url: /ar/net/examples/elements/picture/
keywords:
- صورة
- إطار صورة
- إضافة صورة
- الوصول إلى صورة
- مثال برمجي
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "العمل مع الصور في Aspose.Slides for .NET: إدراج، قص، ضغط، إعادة تلوين، وتصدير الصور مع أمثلة C# لعروض PPT و PPTX و ODP."
---
توضح هذه المقالة كيفية إدراج الصور والوصول إليها من صور مخزنة في الذاكرة باستخدام **Aspose.Slides for .NET**. الأمثلة أدناه تنشئ صورة في الذاكرة، تضعها على شريحة، ثم تسترجعها.

## **إضافة صورة**

يقوم هذا الكود بإنشاء صورة نقطية صغيرة، يحولها إلى تدفق، ويُدرجها كإطار صورة في الشريحة الأولى.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // إنشاء صورة بسيطة في الذاكرة.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // تحويل الـ bitmap إلى MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // إضافة الصورة إلى العرض التقديمي.
    var image = presentation.Images.AddImage(imageStream);

    // إدراج إطار صورة يعرض الصورة على الشريحة الأولى.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **الوصول إلى صورة**

يتأكد هذا المثال من أن الشريحة تحتوي على إطار صورة ثم يصل إلى أول إطار يجده.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // تأكد من وجود إطار صورة واحد على الأقل للعمل معه.
    using var bitmap = new Bitmap(40, 40);

    // تحويل الـ bitmap إلى MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // إضافة الصورة إلى العرض التقديمي.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // الوصول إلى أول إطار صورة على الشريحة.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```