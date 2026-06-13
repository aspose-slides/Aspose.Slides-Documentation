---
title: ویدیو
type: docs
weight: 80
url: /fa/net/examples/elements/video/
keywords:
  - ویدیو
  - فریم ویدیو
  - افزودن ویدیو
  - دسترسی به ویدیو
  - حذف ویدیو
  - پخش ویدیو
  - مثال کد
  - پاورپوینت
  - OpenDocument
  - ارائه
  - .NET
  - C#
  - Aspose.Slides
description: "با Aspose.Slides برای .NET ویدیوها را اضافه و کنترل کنید: وارد کردن، پخش، برش، تنظیم فریم‌های پوستر، و استخراج با مثال‌های C# برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد چگونه فریم‌های ویدیو را جاسازی کرده و گزینه‌های پخش را با استفاده از **Aspose.Slides for .NET** تنظیم کنید.

## **افزودن فریم ویدیو**

یک فریم ویدیو خالی را بر روی اسلایدی درج کنید.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // یک ویدیو اضافه کنید.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **دسترسی به فریم ویدیو**

اولین فریم ویدیو اضافه شده به اسلاید را بازیابی کنید.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // دسترسی به اولین فریم ویدیو در اسلاید.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **حذف فریم ویدیو**

یک فریم ویدیو را از اسلاید حذف کنید.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // فریم ویدیو را حذف کنید.
    slide.Shapes.Remove(videoFrame);
}
```

## **تنظیم پخش ویدیو**

ویدیو را طوری پیکربندی کنید که به‌صورت خودکار هنگام نمایش اسلاید پخش شود.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // پیکربندی ویدیو برای پخش خودکار.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```