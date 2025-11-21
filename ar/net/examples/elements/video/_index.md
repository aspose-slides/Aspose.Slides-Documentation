---
title: فيديو
type: docs
weight: 80
url: /ar/net/examples/elements/video/
keywords:
- مثال فيديو
- إطار فيديو
- إضافة فيديو
- الوصول إلى فيديو
- حذف فيديو
- تشغيل الفيديو
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "العمل مع الفيديو في C# باستخدام Aspose.Slides: إدراج، استبدال، قص، تعيين إطارات ملصق وخيارات التشغيل، وتصدير العروض التقديمية إلى PPT و PPTX و ODP."
---

يعرض كيفية تضمين إطارات الفيديو وتعيين خيارات التشغيل باستخدام **Aspose.Slides for .NET**.

## إضافة إطار فيديو

أدرج إطار فيديو فارغًا إلى شريحة.
```csharp
static void Add_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // إضافة إطار فيديو مدمج فارغ
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```


## الوصول إلى إطار فيديو

استرجع أول إطار فيديو تم إضافته إلى شريحة.
```csharp
static void Access_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // الوصول إلى أول إطار فيديو على الشريحة
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```


## إزالة إطار فيديو

احذف إطار فيديو من الشريحة.
```csharp
static void Remove_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // إزالة إطار الفيديو
    slide.Shapes.Remove(videoFrame);
}
```


## تعيين تشغيل الفيديو

قم بتكوين الفيديو لتشغيله تلقائيًا عندما تُعرض الشريحة.
```csharp
static void Set_Video_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // تكوين الفيديو للتشغيل تلقائيًا
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```
