---
title: Video
type: docs
weight: 80
url: /cs/net/examples/elements/video/
keywords:
- video
- video snímek
- přidat video
- přístup k videu
- odstranit video
- přehrávání videa
- ukázkový kód
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Přidávejte a ovládejte videa pomocí Aspose.Slides pro .NET: vkládejte, přehrávejte, ořezávejte, nastavujte posterové snímky a exportujte s ukázkami v C# pro prezentace PPT, PPTX a ODP."
---
Tento článek demonstruje, jak vložit video snímky a nastavit možnosti přehrávání pomocí **Aspose.Slides for .NET**.

## **Přidání video snímku**

Vložte prázdný video snímek na snímek.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Přidat video.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **Přístup k video snímku**

Získejte první video snímek přidaný do snímku.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Přístup k prvnímu video snímku na snímku.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **Odstranění video snímku**

Odstraňte video snímek ze snímku.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Odstranit video snímek.
    slide.Shapes.Remove(videoFrame);
}
```

## **Nastavení přehrávání videa**

Nastavte video tak, aby se přehrávalo automaticky, když je snímek zobrazen.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Nakonfigurujte video tak, aby se přehrávalo automaticky.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```