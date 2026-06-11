---
title: Video
type: docs
weight: 80
url: /sv/net/examples/elements/video/
keywords:
- video
- videoram
- lägg till video
- åtkomst till video
- ta bort video
- videouppspelning
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lägg till och kontrollera videor med Aspose.Slides för .NET: infoga, spela upp, trimma, ange förhandsbilder och exportera med C#-exempel för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur du bäddar in videoramar och ställer in uppspelningsalternativ med hjälp av **Aspose.Slides for .NET**.

## **Lägg till en videoram**

Infoga en tom videoram på en bild.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Lägg till en video.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **Åtkomst till en videoram**

Hämta den första videoramen som lagts till på en bild.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Åtkomst till den första videoramen på bilden.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **Ta bort en videoram**

Ta bort en videoram från bilden.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Ta bort videoramen.
    slide.Shapes.Remove(videoFrame);
}
```

## **Ställ in videouppspelning**

Konfigurera videon så att den spelas upp automatiskt när bilden visas.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Konfigurera videon så att den spelas upp automatiskt.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```