---
title: تصویر
type: docs
weight: 50
url: /fa/net/examples/elements/picture/
keywords:
- تصویر
- قاب تصویر
- افزودن تصویر
- دسترسی به تصویر
- نمونه کد
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کار با تصاویر در Aspose.Slides برای .NET: درج، برش، فشرده‌سازی، تغییر رنگ و استخراج تصاویر با نمونه‌های C# برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد که چگونه می‌توان تصاویر را از تصاویر درون حافظه‌ای وارد و دسترسی پیدا کرد با استفاده از **Aspose.Slides for .NET**. مثال‌های زیر یک تصویر را در حافظه ایجاد می‌کند، آن را بر روی یک اسلاید قرار می‌دهد، و سپس بازیابی می‌کند.

## **افزودن تصویر**

این کد یک bitmap کوچک تولید می‌کند، آن را به یک جریان تبدیل می‌نماید و به عنوان یک فریم تصویر در اولین اسلاید درج می‌کند.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // ایجاد یک تصویر ساده در حافظه.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // تبدیل bitmap به MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // افزودن تصویر به ارائه.
    var image = presentation.Images.AddImage(imageStream);

    // درج یک فریم تصویر که تصویر را در اولین اسلاید نشان می‌دهد.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **دسترسی به تصویر**

این مثال اطمینان می‌دهد که یک اسلاید شامل یک فریم تصویر باشد و سپس به اولین فریمی که پیدا می‌کند دسترسی پیدا می‌کند.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // اطمینان از وجود حداقل یک فریم تصویر برای کار.
    using var bitmap = new Bitmap(40, 40);

    // تبدیل bitmap به MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // افزودن تصویر به ارائه.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // دسترسی به اولین فریم تصویر در اسلاید.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```