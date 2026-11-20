---
title: Audio-Frames in Präsentationen in .NET verwalten
linktitle: Audio-Frame
type: docs
weight: 10
url: /de/net/audio-frame/
keywords:
- Audio
- Audio-Frame
- Vorschaubild
- Audio hinzufügen
- Audioeigenschaften
- Audiooptionen
- Audio extrahieren
- .NET
- C#
- Aspose.Slides
description: "Audio in Folien einbetten, das Audiosymbol ändern, die Wiedergabe konfigurieren, WebVTT-Untertitel verwalten und Übergangs-Sounds von Folien extrahieren mit Aspose.Slides für .NET."
---
## **Übersicht**

Ein Audio-Frame ermöglicht es, einen Sound auf einer Folie abzuspielen. Mit Aspose.Slides für .NET können Sie einen Audioclip einbetten, das Bild auswählen, das ihn darstellt, die Wiedergabe anpassen und Untertitel anhängen. Sie können auch einen einem Folienübergang zugewiesenen Sound abrufen.

## **Audio-Frames erstellen**

Verwenden Sie [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) um einen lokalen Audioclip auf der ersten Folie einzubetten. Die ersten beiden Koordinaten positionieren den Frame auf der Folie, und die nächsten beiden Werte setzen Breite und Höhe, alles in Punkt. Dieses Beispiel setzt [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) so, dass der Clip automatisch startet, und [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) auf die laute Voreinstellung.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```

## **Audio-Frame-Vorschaubild ändern**

Standardmäßig zeigt ein Audio-Frame ein Lautsprechersymbol an. Um ein benutzerdefiniertes Vorschaubild anzuzeigen, fügen Sie ein Bild zur Präsentation mit [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) hinzu und weisen Sie es der [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/)-Eigenschaft des Frames zu. Das Beispiel verwendet ein JPEG als Vorschaubild für einen eingebetteten Audioclip.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

## **Audio-Wiedergabeoptionen ändern**

Die **Audio‑Optionen** von PowerPoint bestimmen, wann ein Clip startet, wie laut er ist und wie er während einer Bildschirmpräsentation funktioniert.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint‑Steuerelement | Aspose.Slides‑Eigenschaft |
| --- | --- |
| Start | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| Volume preset | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| Play Across Slides | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| Loop until Stopped | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| Hide During Show | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| Rewind after Playing | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| Fade In | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| Fade Out | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| Trim Audio start time | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| Trim Audio end time | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| Volume slider | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

Das Beispiel findet den ersten Audio-Frame auf der ersten Folie, setzt [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) so, dass die Wiedergabe bei einem Klick startet, und wählt die niedrige Lautstärke‑Voreinstellung. Der Clip wird über Folien hinweg fortgesetzt, wobei die Wiederholung deaktiviert ist. Das Symbol bleibt während der Show ausgeblendet, und der Clip wird nach der Wiedergabe zurückgespult.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```

Für einen Clip, der länger als 3,5 Sekunden ist, überspringt dieses Beispiel die ersten 1,5 Sekunden und die letzten 2 Sekunden. [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) misst die Dauer, die am Ende des Clips weggelassen wird. Um die in PowerPoint angezeigte Endzeit zu erhalten, subtrahieren Sie diesen Versatz von der Gesamtdauer des Clips. Der beschnittene Clip blendet über 200 Millisekunden ein und über 500 Millisekunden aus. Alle vier Eigenschaften akzeptieren Werte in Millisekunden.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```

Um die Wiedergabelautstärke auf einen bestimmten Prozentsatz zu setzen, verwenden Sie [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/). Dieses Beispiel setzt den ersten Audio-Frame auf der ersten Folie auf 85 %.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```

## **Audio-Untertitel verwalten**

Jeder Audio-Frame verfügt über eine [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/)-Sammlung. Verwenden Sie diese, um WebVTT-Untertitel an den Clip anzuhängen, vorhandene Spuren zu exportieren oder zu entfernen.

### **Audio-Untertitel hinzufügen**

Das Beispiel bettet einen Audioclip auf der ersten Folie ein und verwendet [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) , um eine lokale WebVTT‑Spur anzuhängen. Das erste Argument liefert die Spurbeschrift, und das zweite identifiziert die Datei mit den zeitlich gesteuerten Untertiteln.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```

### **Audio-Untertitel extrahieren**

Dieses Beispiel exportiert jede an einen Audio-Frame auf der ersten Folie angehängte Untertitelspur. Es schreibt die [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) der Spur in eine WebVTT‑Datei und verwendet deren [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) als Dateinamen, sodass jede Spur eine separate Ausgabe hat.

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```

### **Audio-Untertitel entfernen**

Verwenden Sie [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) oder [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) , um eine einzelne Spur zu löschen. Das Beispiel nutzt [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) , um alle Untertitel vom ersten Audio-Frame auf der ersten Folie zu entfernen, wobei der Clip erhalten bleibt.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```

### **Eine Zeile in Audio-Untertiteln finden**

Um eine Zeile in den Audio-Untertiteln auf der ersten Folie zu finden, lesen Sie die [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) jeder Spur im Speicher. In einem Klartext‑WebVTT‑Cue enthält die Timing‑Zeile `-->`, die Untertitelzeilen folgen darauf, und eine leere Zeile beendet den Cue. Dieses Beispiel gibt die Spurbeschrift und jede Untertitelzeile aus, die „café“ enthält.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```

## **Audio extrahieren**

Ein Folienübergang kann einen eigenen Sound haben. Um ihn abzurufen, lesen Sie die [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/)‑Eigenschaft des Übergangs. Das Beispiel greift auf die [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) des Sounds zu und gibt dessen Größe in Bytes aus. Wenn die erste Folie keinen Übergangs‑Sound hat, wird stattdessen eine Meldung ausgegeben.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```

## **FAQ**

**Kann ich denselben Audioclip über mehrere Folien hinweg wiederverwenden, ohne ihn zu duplizieren?**

Ja. Fügen Sie den Clip einmal zur [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) der Präsentation hinzu und übergeben Sie dasselbe Audio‑Objekt bei jedem Folie an [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) .

**Kann ich den Sound in einem bestehenden Audio-Frame ersetzen?**

Ja. Bei einem verknüpften Sound aktualisieren Sie [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/), damit er auf die Ersatzdatei verweist. Bei einem eingebetteten Sound weisen Sie [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/) einen anderen Clip aus der Audio‑Sammlung der Präsentation zu. Beide Vorgehensweisen erhalten den bestehenden Frame.

**Verändert das Trimmen die im Dokument gespeicherten Audiodaten?**

Nein. [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) und [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) setzen nur die Wiedergabegrenzen. Sie können den vollständigen Clip weiterhin über [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/) abrufen.