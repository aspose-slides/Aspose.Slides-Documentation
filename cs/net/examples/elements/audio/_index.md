---
title: Audio
type: docs
weight: 70
url: /cs/net/examples/elements/audio/
keywords:
- zvuk
- audio rámeček
- přidat audio
- přístup k audio
- odstranit audio
- přehrávání audia
- ukázka kódu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Objevte příklady audia pro Aspose.Slides pro .NET: vkládání, přehrávání, ořezávání a extrahování zvuku v prezentacích PPT, PPTX a ODP s přehledným C# kódem."
---
Tento článek ukazuje, jak vložit audio rámečky a řídit přehrávání pomocí **Aspose.Slides for .NET**. Následující příklady ukazují základní operace s audio.

## **Přidat audio rámeček**

Vložte prázdný audio rámeček, který může později obsahovat vložená zvuková data.

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Vytvořte prázdný audio rámeček (audio bude vloženo později).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **Přístup k audio rámečku**

Tento kód načte první audio rámeček na snímku.

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Přístup k prvnímu audio rámečku na snímku.
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **Odstranit audio rámeček**

Smažte dříve přidaný audio rámeček.

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Odstraňte audio rámeček.
    slide.Shapes.Remove(audioFrame);
}
```

## **Nastavit přehrávání audia**

Nastavte audio rámeček tak, aby se přehrál automaticky, když se snímek zobrazí.

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Přehrát automaticky, když se snímek zobrazí.
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```