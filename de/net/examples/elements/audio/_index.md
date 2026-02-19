---
title: Audio
type: docs
weight: 70
url: /de/net/examples/elements/audio/
keywords:
- Audio
- Audio-Frame
- Audio hinzufügen
- Audio abrufen
- Audio entfernen
- Audio-Wiedergabe
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie Audiodemonstrationen von Aspose.Slides für .NET: Einfügen, Abspielen, Trimmen und Extrahieren von Sound in PPT-, PPTX- und ODP-Präsentationen mit klarem C#-Code."
---
Dieser Artikel demonstriert, wie man Audio-Frames einbettet und die Wiedergabe mit **Aspose.Slides for .NET** steuert. Die folgenden Beispiele zeigen grundlegende Audio-Operationen.

## **Audio-Frame hinzufügen**

Fügen Sie einen leeren Audio-Frame ein, der später eingebettete Audiodaten enthalten kann.

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Erstelle einen leeren Audio-Frame (Audio wird später eingebettet).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **Zugriff auf einen Audio-Frame**

Dieser Code ruft den ersten Audio-Frame auf einer Folie ab.

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Greife auf das erste Audio-Frame auf der Folie zu.
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **Audio-Frame entfernen**

Löschen Sie einen zuvor hinzugefügten Audio-Frame.

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Entferne das Audio-Frame.
    slide.Shapes.Remove(audioFrame);
}
```

## **Audio-Wiedergabe festlegen**

Konfigurieren Sie den Audio-Frame so, dass er automatisch abgespielt wird, wenn die Folie angezeigt wird.

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Automatisch abspielen, wenn die Folie erscheint.
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```