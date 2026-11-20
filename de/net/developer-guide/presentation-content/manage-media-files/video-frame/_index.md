---
title: Video-Frames in Präsentationen in .NET verwalten
linktitle: Video-Frame
type: docs
weight: 10
url: /de/net/video-frame/
keywords:
- Video hinzufügen
- Video erstellen
- Video einbetten
- Video extrahieren
- Video abrufen
- Video-Frame
- Webquelle
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie programmgesteuert Video-Frames in PowerPoint- und OpenDocument-Folien mit Aspose.Slides für .NET hinzufügen und extrahieren. Schneller Leitfaden."
---
## **Einleitung**

Videos können helfen, Ideen zu erklären und ein Publikum zu fesseln. Aspose.Slides für .NET ermöglicht das Hinzufügen von Video-Frames zu Folien, das Anpassen von Wiedergabeeinstellungen, das Verwalten von Untertiteln und das Extrahieren eingebetteter Videodaten.

PowerPoint unterstützt lokale Videos und Links zu Online-Videos, wie beispielsweise YouTube-Videos.

Um Videodaten und Video-Frames darzustellen, stellt Aspose.Slides die Schnittstelle [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) und die Schnittstelle [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) sowie weitere relevante Typen bereit.

## **Erstellen eines eingebetteten Video-Frames**

Wenn die Videodatei, die Sie Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video-Frame erstellen, um das Video in Ihre Präsentation einzubetten.

Dieses Beispiel bettet ein lokales Video auf der ersten Folie einer vorhandenen Präsentation ein und speichert das Ergebnis. Frame-Koordinaten und -Abmessungen sind in Punkten angegeben. Der Stream bleibt geöffnet, bis das Speichern abgeschlossen ist, weil [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) ihn gesperrt hält, solange die Präsentation ihn verwendet.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

Sie können auch einen lokalen Videopfad direkt an [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) übergeben. Dieses Beispiel bettet das Video auf der ersten Folie einer neuen Präsentation ein. Das Video muss bis zum Speichern der Präsentation zugänglich bleiben.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Video-Lautstärke genau einstellen**

In Aspose.Slides für .NET 26.11 oder höher setzt [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) einen Gleitkomma-Prozentsatz von 0 bis 100. Verwenden Sie ihn, wenn die [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) Voreinstellungen zu grob sind. Beispielsweise fordert `75.5f` eine Lautstärke von 75,5 % an.

Dieses Beispiel erfordert [Aspose.Slides für .NET](/slides/de/net/installation/) 26.11 oder höher und ein lokales `video.mp4`. Es bettet das Video ein, initialisiert die Wiedergabe explizit, speichert die Präsentation und liest den gespeicherten Prozentsatz wieder aus.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

var volume = 75.5f;
if (float.IsNaN(volume) || float.IsInfinity(volume) || volume < 0 || volume > 100)
{
    Console.WriteLine("Use a finite volume from 0 to 100.");
    return;
}

using (var presentation = new Presentation())
{
    var videoBytes = File.ReadAllBytes("video.mp4");
    var video = presentation.Videos.AddVideo(videoBytes);
    var frame = presentation.Slides[0].Shapes.AddVideoFrame(50, 50, 320, 180, video);
    frame.PlayMode = VideoPlayModePreset.Auto;
    frame.VolumeValue = volume;
    presentation.Save("video-volume.pptx", SaveFormat.Pptx);
}

using var saved = new Presentation("video-volume.pptx");
var savedFrame = saved.Slides[0].Shapes.OfType<IVideoFrame>().First();
Console.WriteLine(savedFrame.VolumeValue);
```

Validieren Sie die Eingaben selbst; verlassen Sie sich nicht darauf, dass der Setter Werte außerhalb des dokumentierten Bereichs ablehnt. Die Voreinstellungen Low, Medium und Loud entsprechen in 26.11 den Werten 20, 50 bzw. 80. Das Setzen einer Voreinstellung kann einen vorherigen Prozentsatz überschreiben, daher sollten Sie den Prozentsatz zuletzt zuweisen, wenn Sie einen genauen Wert benötigen. Verwenden Sie [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) für die explizite Stummschaltung; eine numerische Null und das Voreinstellungs‑Enum sind keine austauschbaren Zustände.

Setzen Sie ebenfalls [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) explizit, wenn Sie ein verlinktes Video konfigurieren, und halten Sie die Mediendatei für den Betrachter verfügbar. Das Speichern und erneute Öffnen prüft die gespeicherte Einstellung; die tatsächliche Wiedergabe und Lautstärke hängen vom Präsentationsplayer und dessen Audioeinstellungen ab.

## **Erstellen eines Video-Frames mit Video aus einer Webquelle**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) unterstützt Online-Videos in Präsentationen. Sie können einen Video-Frame erstellen, der auf ein Online-Video, z. B. ein YouTube-Video, verlinkt.

Dieses Beispiel fügt einen YouTube-Video‑Link und ein Vorschaubild zur ersten Folie hinzu. Ersetzen Sie den Video‑Identifizierer, um ein anderes Video zu verwenden. Die [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/)‑Einstellung fordert automatische Wiedergabe an. Das Herunterladen des Vorschaubilds und das Abspielen des Videos erfordern Internetzugang. Der Präsentationsbetrachter muss ebenfalls die Wiedergabe von Online-Videos unterstützen.

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **Ein Video im Vollbildmodus abspielen**

In einer Schulungspräsentation können Sie eine Software‑Demonstration im Vollbildmodus abspielen, damit das Publikum die Details sehen kann. Setzen Sie [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) auf `true`, um dieses Verhalten während der Wiedergabe zu aktivieren.

Dieses Beispiel öffnet eine Präsentation, findet das erste [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) auf der ersten Folie und aktiviert die Vollbild‑Wiedergabe. Die Eingabe‑Präsentation muss mindestens eine Folie mit einem vorhandenen Video‑Frame auf der ersten Folie enthalten.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

Die Vollbild‑Wiedergabe steuert, wie das Video angezeigt wird. Unabhängig davon regelt [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/), ob es automatisch oder bei Klick startet, und [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) , ob es wiederholt wird. Um das Startverhalten zu wählen, setzen Sie den Wiedergabemodus auf [VideoPlayModePreset.Auto oder VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). Das Beispiel bewahrt die vorhandenen Start‑ und Schleife‑Einstellungen.

## **Video nach Wiedergabe zurückspulen**

In einer Schulungspräsentation macht das Zurückspulen eines Demonstrationsvideos an den Anfang das Video bereit für die erneute Wiedergabe durch den Präsentierenden. Setzen Sie [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) auf `true`, um das Video nach Abschluss der Wiedergabe zum Anfang zurückzuspulen.

Dieses Beispiel öffnet eine Präsentation, findet das erste [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) auf der ersten Folie und aktiviert das Zurückspulen. Es deaktiviert das Looping, damit die Wiedergabe beendet werden kann, und setzt die Wiedergabe auf Start bei Klick. Die Eingabe‑Präsentation muss mindestens eine Folie mit einem vorhandenen Video‑Frame auf der ersten Folie enthalten.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

Das Zurückspulen bringt das Video an den Anfang, ohne es erneut zu starten. Im Gegensatz dazu bewirkt das Aktivieren von [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/), dass die Wiedergabe automatisch wiederholt wird. Deaktivieren Sie das Looping, wenn das Video beendet werden soll und bereit für eine erneute Wiedergabe bleibt. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) steuert unabhängig davon den automatischen oder klickbasierten Start; dieses Beispiel verwendet [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) , sodass der Präsentierende bestimmt, wann die Wiedergabe beginnt. Setzen Sie den Wiedergabemodus nach der Schleife‑Einstellung, wie im Beispiel gezeigt. Das Zurückspulen funktioniert unabhängig von [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Video-Frame zuschneiden**

Verwenden Sie [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) und [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/), um zu Beginn oder am Ende eines Videos während der Wiedergabe einen Teil zu überspringen. Beide Werte sind in Millisekunden angegeben. Das Zuschneiden ändert die Wiedergabeeinstellungen, ohne die eingebetteten Videodaten zu verändern.

**Trim-Einstellungen festlegen**

Dieses Beispiel bettet ein lokales Video ein und überspringt während der Wiedergabe die ersten 2,5 Sekunden sowie die letzte Sekunde. Verwenden Sie ein Video, das länger als 3,5 Sekunden ist, damit ein abspielbarer Abschnitt erhalten bleibt.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Trim-Einstellungen lesen**

Dieses Beispiel gibt die Trim‑Werte des ersten Video‑Frames auf der ersten Folie in Millisekunden aus. Die Präsentation muss mindestens eine Folie enthalten. Wenn diese Folie keinen Video‑Frame hat, wird nichts ausgegeben. Das vorherige Beispiel erzeugt die Werte 2500 und 1000.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **Video-Untertitel verwalten**

Aspose.Slides ermöglicht die Verwaltung von Untertiteln für Video‑Frames in PowerPoint‑Präsentationen. Untertitel werden im WebVTT‑Format gespeichert und über die Eigenschaft [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) bereitgestellt.

### **Untertitel zu einem Video‑Frame hinzufügen**

Dieses Beispiel bettet ein lokales Video ein und fügt eine WebVTT‑Untertitelspur mit dem Label English hinzu. Die Zeitstempel der Untertitel sollten mit dem Video übereinstimmen. Die gespeicherte Präsentation enthält sowohl das Video als auch dessen Untertitel.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

Die Schnittstelle [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) bietet außerdem eine Überladung, mit der Sie Untertitel aus einem Stream hinzufügen können.

### **Untertitel aus einem Video‑Frame extrahieren**

Dieses Beispiel speichert alle Untertitelspuren von Video‑Frames auf der ersten Folie als separate WebVTT‑Dateien. Fortlaufende Nummern halten die Ausgabedateien eindeutig. Die Konsole meldet die Anzahl extrahierter Spuren. Die Präsentation muss mindestens eine Folie enthalten.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

Jedes [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/)‑Objekt stellt den Untertitel‑Identifikator, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑Zeichenkette bereit.

### **Untertitel von einem Video‑Frame entfernen**

Dieses Beispiel entfernt alle Untertitel vom Video‑Frame an der ersten Shape‑Position auf der ersten Folie und speichert das Ergebnis. Es wird davon ausgegangen, dass die Folie und das Shape existieren und dass das Shape ein Video‑Frame ist.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

Wenn Sie nur eine Untertitelspur entfernen müssen, verwenden Sie die Methoden [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) oder [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) anstelle von [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

### **Video‑Untertitel durchsuchen**

[ICaptions.DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) gibt die komplette WebVTT‑Spur zurück, einschließlich Header, Timing‑Zeilen und Untertiteltext. Um eine gesprochene Phrase und deren Zeitstempel zu finden, lesen Sie die Cues im Speicher. Beispielsweise könnte eine englische Spur auf Folie 2 den folgenden Text enthalten:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Das Beispiel durchläuft jede Folie und liest die Spuren ihrer obersten Video‑Frames über [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/). In einem Klartext‑Cue enthält die Timing‑Zeile `-->` und eine leere Zeile beendet den Cue. Wenn der Untertiteltext „café“ enthält, gibt das Beispiel die Foliennummer, das Spur‑Label, die ursprüngliche Timing‑Zeile und den vollständigen Untertitel aus.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("captioned_media.pptx");
foreach (var slide in presentation.Slides)
{
    var tracks = slide.Shapes.OfType<IVideoFrame>().SelectMany(frame => frame.CaptionTracks);
    foreach (var track in tracks)
    {
        using var reader = new StringReader(track.DataAsString);
        while (reader.ReadLine() is string timing)
        {
            if (!timing.Contains("-->")) continue;

            var lines = new List<string>();
            while (reader.ReadLine() is string line && line.Length > 0)
                lines.Add(line);

            var caption = string.Join(Environment.NewLine, lines);
            if (caption.Contains("café", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Slide {slide.SlideNumber} | {track.Label} | {timing}");
                Console.WriteLine(caption);
            }
        }
    }
}
```

Die Suche nach „café“ liefert eine Übereinstimmung für die Beispielspur. Der Header und die Timing‑Einstellung liegen außerhalb des Cue‑Texts.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Video aus einer Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

Dieses Beispiel extrahiert eingebettete Videos aus jeder Folie in separate, nummerierte Binärdateien. Verlinkte Videos werden übersprungen, da sie keine eingebetteten Daten besitzen. Die Konsole gibt den MIME‑Typ jedes Videos und die Gesamtzahl aus. Die Ausgabe verwendet die generische Erweiterung `.bin`; passen Sie sie bei Bedarf an den gemeldeten Medientyp an.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **FAQ**

**Welche Videowiedergabeparameter können für einen Video‑Frame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (automatisch oder bei Klick) und das [Looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) steuern. Diese Optionen sind über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/)‑Objekts verfügbar.

**Wirkt sich das Hinzufügen eines Videos auf die PPTX‑Dateigröße aus?**

Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Wenn Sie zu einem Online‑Video verlinken und ein Vorschaubild hinzufügen, speichert die Präsentation den Link und das Vorschaubild anstelle der Videodaten, sodass die Größensteigerung in der Regel geringer ist.

**Kann ich das Video in einem vorhandenen Video‑Frame ersetzen, ohne Position und Größe zu verändern?**

Ja. Sie können den [Video‑Inhalt](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) im Frame austauschen, während Sie die Geometrie des Shapes beibehalten; dies ist ein gängiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video verfügt über einen [Content‑Typ](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/), den Sie auslesen und beispielsweise beim Speichern auf die Festplatte verwenden können.