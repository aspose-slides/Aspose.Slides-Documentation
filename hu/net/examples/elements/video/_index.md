---
title: Videó
type: docs
weight: 80
url: /hu/net/examples/elements/video/
keywords:
- videó
- videókeret
- videó hozzáadása
- videó elérése
- videó eltávolítása
- videó lejátszása
- kódpélda
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Videók hozzáadása és vezérlése az Aspose.Slides for .NET segítségével: beszúrás, lejátszás, vágás, poszterkeretek beállítása, valamint exportálás C# példákkal PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja, hogyan lehet videókereteket beágyazni, és beállítani a lejátszási beállításokat a **Aspose.Slides for .NET** használatával.

## **Videókeret hozzáadása**

Helyezzen egy üres videókeretet a diára.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Videó hozzáadása.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **Videókeret elérése**

Szerezze be az első, a diára hozzáadott videókeretet.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // A dián lévő első videókeret elérése.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **Videókeret eltávolítása**

Törölje a videókeretet a diáról.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Videókeret eltávolítása.
    slide.Shapes.Remove(videoFrame);
}
```

## **Videó lejátszásának beállítása**

Állítsa be a videót úgy, hogy automatikusan lejátszódjon, amikor a diát megjelenítik.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // A videó automatikus lejátszásának beállítása.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```