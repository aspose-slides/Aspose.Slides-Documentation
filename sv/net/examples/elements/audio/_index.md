---
title: Ljud
type: docs
weight: 70
url: /sv/net/examples/elements/audio/
keywords:
- ljud
- ljudram
- lägg till ljud
- åtkomst till ljud
- ta bort ljud
- ljuduppspelning
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Upptäck Aspose.Slides för .NET ljudexempel: infoga, spela, trimma och extrahera ljud i PPT-, PPTX- och ODP-presentationer med tydlig C#-kod."
---
Den här artikeln visar hur man bäddar in ljudramar och styr uppspelning med **Aspose.Slides for .NET**. Följande exempel visar grundläggande ljudoperationer.

## **Lägg till en ljudram**

Infoga en tom ljudram som senare kan innehålla inbäddade ljuddata.

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Skapa en tom ljudram (ljud kommer att bäddas in senare).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **Åtkomst till en ljudram**

Den här koden hämtar den första ljudramen på en bild.

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Åtkomst till den första ljudramen på bilden.
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **Ta bort en ljudram**

Ta bort en tidigare tillagd ljudram.

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Ta bort ljudramen.
    slide.Shapes.Remove(audioFrame);
}
```

## **Ställ in ljuduppspelning**

Konfigurera ljudramen så att den spelas upp automatiskt när bilden visas.

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Spela automatiskt när bilden visas.
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```