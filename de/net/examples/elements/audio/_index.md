---
title: Audio
type: docs
weight: 70
url: /de/net/examples/elements/audio/
keywords:
- Audio-Beispiel
- Audio-Frame
- Audio hinzufügen
- Audio zugreifen
- Audio entfernen
- Audio-Wiedergabe
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Arbeiten Sie mit Audio in C# unter Verwendung von Aspose.Slides: Hinzufügen, Ersetzen, Extrahieren und Kürzen von Sounds, Einstellen von Lautstärke und Wiedergabe für Folien und Formen in PowerPoint und OpenDocument."
---

Zeigt, wie Audio‑Frames eingebettet und die Wiedergabe mit **Aspose.Slides for .NET** gesteuert werden kann. Die folgenden Beispiele zeigen grundlegende Audio‑Operationen.

## Audio‑Frame hinzufügen

Fügen Sie einen leeren Audio‑Frame ein, der später eingebettete Audiodaten enthalten kann.
```csharp
static void Add_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Erstelle einen leeren Audio-Frame (Audio wird später eingebettet)
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```


## Auf einen Audio‑Frame zugreifen

Dieser Code ruft den ersten Audio‑Frame auf einer Folie ab.
```csharp
static void Access_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Greift auf den ersten Audio-Frame auf der Folie zu
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```


## Audio‑Frame entfernen

Löschen Sie einen zuvor hinzugefügten Audio‑Frame.
```csharp
static void Remove_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Entfernt den Audio-Frame
    slide.Shapes.Remove(audioFrame);
}
```


## Audio‑Wiedergabe festlegen

Konfigurieren Sie den Audio‑Frame so, dass er automatisch abgespielt wird, wenn die Folie erscheint.
```csharp
static void Set_Audio_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Automatisch abspielen, wenn die Folie erscheint
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```
