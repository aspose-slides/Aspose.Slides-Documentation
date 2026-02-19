---
title: فيديو
type: docs
weight: 80
url: /ar/net/examples/elements/video/
keywords:
- فيديو
- إطار فيديو
- إضافة فيديو
- الوصول إلى الفيديو
- إزالة فيديو
- تشغيل الفيديو
- مثال على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إضافة والتحكم في الفيديوهات باستخدام Aspose.Slides for .NET: إدراج، تشغيل، تقليم، تعيين إطارات الملصق، وتصدير مع أمثلة C# لعروض PPT و PPTX و ODP."
---
توضح هذه المقالة كيفية تضمين إطارات الفيديو وتعيين خيارات التشغيل باستخدام **Aspose.Slides for .NET**.

## **Add a Video Frame**
إضافة إطار فيديو

Insert an empty video frame onto a slide.
إدراج إطار فيديو فارغ على الشريحة.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // إضافة فيديو.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **Access a Video Frame**
الوصول إلى إطار فيديو

Retrieve the first video frame added to a slide.
استرجاع أول إطار فيديو تم إضافته إلى الشريحة.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // الوصول إلى أول إطار فيديو على الشريحة.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **Remove a Video Frame**
إزالة إطار فيديو

Delete a video frame from the slide.
حذف إطار فيديو من الشريحة.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // إزالة إطار الفيديو.
    slide.Shapes.Remove(videoFrame);
}
```

## **Set Video Playback**
ضبط تشغيل الفيديو

Configure the video to play automatically when the slide is displayed.
تكوين الفيديو لتشغيله تلقائيًا عند عرض الشريحة.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // تكوين الفيديو لتشغيله تلقائيًا.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```