---
title: Audio
type: docs
weight: 70
url: /nl/net/examples/elements/audio/
keywords:
- audio
- audioframe
- audio toevoegen
- audio openen
- audio verwijderen
- audio afspelen
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek audio‑voorbeelden van Aspose.Slides voor .NET: voeg audio in, speel af, knip bij en haal geluid eruit in PPT-, PPTX- en ODP‑presentaties met duidelijke C#‑code."
---
Dit artikel laat zien hoe u audio‑frames kunt insluiten en de weergave kunt regelen met **Aspose.Slides for .NET**. De volgende voorbeelden tonen basis‑audio‑bewerkingen.

## **Audio‑frame toevoegen**

Voeg een lege audio‑frame in die later ingesloten geluidsgegevens kan bevatten.

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Maak een leeg audio‑frame (audio wordt later ingesloten).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **Toegang tot een audio‑frame**

Deze code haalt het eerste audio‑frame op een dia op.

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Toegang tot het eerste audio-frame op de dia.
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **Audio‑frame verwijderen**

Verwijder een eerder toegevoegd audio‑frame.

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Verwijder het audio-frame.
    slide.Shapes.Remove(audioFrame);
}
```

## **Audio‑afspelen instellen**

Stel het audio‑frame in om automatisch af te spelen zodra de dia verschijnt.

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Speel automatisch af wanneer de dia verschijnt.
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```