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
description: "Erfahren Sie, wie Sie programmgesteuert Video-Frames in PowerPoint- und OpenDocument‑Folien mit Aspose.Slides für .NET hinzufügen und extrahieren. Schnelle Anleitung."
---
## **Einleitung**

Videos können dabei helfen, Ideen zu erklären und ein Publikum zu fesseln. Aspose.Slides für .NET ermöglicht das Hinzufügen von Video-Frames zu Folien, das Anpassen von Wiedergabeeinstellungen, das Verwalten von Untertiteln und das Extrahieren eingebetteter Videodaten.

PowerPoint unterstützt lokale Videos und Links zu Online-Videos, wie z. B. YouTube-Videos.

Um Videodaten und Video-Frames darzustellen, stellt Aspose.Slides das [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/)-Interface, das [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)-Interface und weitere relevante Typen bereit.

## **Einbetten eines Video-Frames**

Wenn die Videodatei, die Sie Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video-Frame erstellen, um das Video in Ihre Präsentation einzubetten.

Dieses Beispiel bettet ein lokales Video auf der ersten Folie einer vorhandenen Präsentation ein und speichert das Ergebnis. Die Koordinaten und Abmessungen des Frames sind in Punkt angegeben. Der Stream bleibt geöffnet, bis das Speichern abgeschlossen ist, weil [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) ihn gesperrt hält, während die Präsentation ihn verwendet.

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

## **Erstellen eines Video-Frames mit Video aus einer Webquelle**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) unterstützt Online-Videos in Präsentationen. Sie können einen Video-Frame erstellen, der auf ein Online-Video verweist, z. B. ein YouTube-Video.

Dieses Beispiel fügt einen YouTube-Video‑Link und ein Vorschaubild zur ersten Folie hinzu. Ersetzen Sie die Video‑Kennung, um ein anderes Video zu verwenden. Die [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/)-Einstellung verlangt automatische Wiedergabe. Das Herunterladen des Vorschaubilds und das Abspielen des Videos erfordern Internetzugriff. Der Präsentations‑Viewer muss ebenfalls die Online‑Videowiedergabe unterstützen.

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

## **Video im Vollbildmodus wiedergeben**

In einer Schulungspräsentation können Sie eine Software‑Demonstration im Vollbildmodus wiedergeben, damit das Publikum die Details sehen kann. Setzen Sie [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) auf `true`, um dieses Verhalten während der Wiedergabe zu aktivieren.

Dieses Beispiel öffnet eine Präsentation, findet den ersten [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) auf der ersten Folie und aktiviert die Vollbild‑Wiedergabe. Die Eingabe‑Präsentation muss mindestens eine Folie mit einem vorhandenen Video‑Frame auf der ersten Folie enthalten.

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

Vollbild‑Wiedergabe bestimmt, wie das Video angezeigt wird. Unabhängig davon steuert [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/), ob es automatisch oder per Klick startet, und [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) bestimmt, ob es wiederholt wird. Um das Startverhalten zu wählen, setzen Sie den Wiedergabemodus auf [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). Das Beispiel bewahrt die vorhandenen Start‑ und Schleifeneinstellungen.

## **Video nach der Wiedergabe zurückspulen**

In einer Schulungspräsentation macht das Zurückspulen eines Demonstrations‑Videos zum Anfang das Video bereit für eine erneute Wiedergabe durch den Präsentierenden. Setzen Sie [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) auf `true`, um das Video nach Abschluss der Wiedergabe zum Anfang zurückzuspulen.

Dieses Beispiel öffnet eine Präsentation, findet den ersten [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) auf der ersten Folie und aktiviert das Zurückspulen. Es deaktiviert das Schleifen, sodass die Wiedergabe beendet werden kann, und stellt die Wiedergabe auf Start per Klick ein. Die Eingabe‑Präsentation muss mindestens eine Folie mit einem vorhandenen Video‑Frame auf der ersten Folie enthalten.

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

Das Zurückspulen führt das Video zum Anfang zurück, ohne es erneut zu starten. Im Gegensatz dazu wiederholt das Aktivieren von [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) die Wiedergabe automatisch. Deaktivieren Sie das Schleifen, wenn das Video vollständig beendet werden und sofort erneut abspielbereit sein soll. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) steuert unabhängig davon den automatischen oder per Klick gestarteten Beginn; dieses Beispiel verwendet [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/), sodass der Präsentierende den Start der Wiedergabe kontrolliert. Setzen Sie den Wiedergabemodus nach der Schleife‑Einstellung, wie im Beispiel gezeigt. Das Zurückspulen funktioniert unabhängig von [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Ein Video-Frame zuschneiden**

Verwenden Sie [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) und [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/), um zu Beginn oder am Ende eines Videos während der Wiedergabe einen Teil zu überspringen. Beide Werte sind in Millisekunden angegeben. Das Zuschneiden ändert die Wiedergabeeinstellungen, ohne die eingebetteten Videodaten zu verändern.

**Trim‑Einstellungen festlegen**

Dieses Beispiel bettet ein lokales Video ein und überspringt beim Abspielen die ersten 2,5 Sekunden sowie die letzte Sekunde. Verwenden Sie ein Video, das länger als 3,5 Sekunden ist, damit ein abspielbarer Abschnitt erhalten bleibt.

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

**Trim‑Einstellungen auslesen**

Dieses Beispiel gibt die Trim‑Werte des ersten Video‑Frames auf der ersten Folie in Millisekunden aus. Die Präsentation muss mindestens eine Folie enthalten. Hat diese Folie keinen Video‑Frame, wird nichts ausgegeben. Das vorherige Beispiel erzeugt die Werte 2500 und 1000.

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

## **Video‑Untertitel verwalten**

Aspose.Slides ermöglicht das Verwalten von geschlossenen Untertiteln für Video‑Frames in PowerPoint‑Präsentationen. Untertitel werden im WebVTT‑Format gespeichert und über die Eigenschaft [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) bereitgestellt.

**Untertitel zu einem Video‑Frame hinzufügen**

Dieses Beispiel bettet ein lokales Video ein und fügt eine WebVTT‑Untertitelspur mit dem Label „English“ hinzu. Die Zeitstempel der Untertitel sollten zum Video passen. Die gespeicherte Präsentation enthält sowohl das Video als auch seine Untertitel.

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

Die [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/)-Schnittstelle bietet zudem eine Überladung, mit der Sie Untertitel aus einem Stream hinzufügen können.

**Untertitel von einem Video‑Frame extrahieren**

Dieses Beispiel speichert alle Untertitelspuren von Video‑Frames auf der ersten Folie als separate WebVTT‑Dateien. Fortlaufende Nummern halten die Ausgabedateien eindeutig. Die Konsole gibt die Anzahl der extrahierten Spuren aus. Die Präsentation muss mindestens eine Folie enthalten.

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

Jedes [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/)-Objekt stellt die Untertitel‑Kennung, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑Zeichenkette bereit.

**Untertitel von einem Video‑Frame entfernen**

Dieses Beispiel entfernt alle Untertitel vom Video‑Frame an der ersten Shape‑Position auf der ersten Folie und speichert das Ergebnis. Es wird davon ausgegangen, dass Folie und Shape existieren und dass das Shape ein Video‑Frame ist.

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

Wenn Sie nur eine Untertitelspur entfernen möchten, verwenden Sie die [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/)‑ oder [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/)‑Methoden anstelle von [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

## **Video aus einer Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

Dieses Beispiel extrahiert eingebettete Videos aus jeder Folie in separate, nummerierte Binärdateien. Verknüpfte Videos werden übersprungen, da sie keine eingebetteten Daten besitzen. Die Konsole gibt den MIME‑Typ jedes Videos und die Gesamtanzahl aus. Die Ausgabe verwendet die generische Erweiterung `.bin`; passen Sie sie bei Bedarf dem gemeldeten Medientyp an.

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

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (automatisch oder per Klick) und die [Schleife](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) steuern. Diese Optionen stehen über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/)‑Objekts zur Verfügung.

**Hat das Hinzufügen eines Videos Einfluss auf die PPTX‑Dateigröße?**

Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Wenn Sie zu einem Online‑Video verlinken und ein Vorschaubild hinzufügen, speichert die Präsentation den Link und das Vorschaubild statt der Videodaten, sodass die Größensteigerung in der Regel geringer ist.

**Kann ich das Video in einem vorhandenen Video‑Frame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Videoinhalt](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) innerhalb des Frames austauschen, während Sie die Geometrie der Shape beibehalten; dies ist ein häufiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video hat einen [Inhaltstyp](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/), den Sie auslesen und beispielsweise beim Speichern auf die Festplatte verwenden können.