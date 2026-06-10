---
title: Hang
type: docs
weight: 70
url: /hu/net/examples/elements/audio/
keywords:
- hang
- hangkeret
- hang hozzáadása
- hang elérése
- hang eltávolítása
- hang lejátszása
- kód példa
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for .NET audio példákat: hang beszúrása, lejátszása, vágása és kinyerése PPT, PPTX és ODP prezentációkban, tiszta C# kóddal."
---
Ez a cikk bemutatja, hogyan ágyazhat be audio kereteket, és szabályozhatja a lejátszást az **Aspose.Slides for .NET** használatával. Az alábbi példák az alapvető audio műveleteket mutatják be.

## **Hangkeret hozzáadása**

Helyezzen be egy üres audio keretet, amely később beágyazott hangadatot tárolhat.

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Hozzon létre egy üres hangkeretet (a hang később be lesz ágyazva).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **Hangkeret elérése**

Ez a kód lekéri az első audio keretet egy dián.

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Az első hangkeret elérése a dián.
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **Hangkeret eltávolítása**

Törölje a korábban hozzáadott audio keretet.

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Hangkeret eltávolítása.
    slide.Shapes.Remove(audioFrame);
}
```

## **Audio lejátszás beállítása**

Állítsa be az audio keretet, hogy automatikusan lejátszódjon, amikor a dia megjelenik.

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Automatikusan lejátszás a dia megjelenésekor.
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```