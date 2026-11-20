---
title: Verwalten von Videoframes in Präsentationen mit C++
linktitle: Videoframe
type: docs
weight: 10
url: /de/cpp/video-frame/
keywords:
- Video hinzufügen
- Video erstellen
- Video einbetten
- Video extrahieren
- Video abrufen
- Videoframe
- Webquelle
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie programmgesteuert Videoframes in PowerPoint- und OpenDocument-Folien mit Aspose.Slides für C++ hinzufügen und extrahieren. Schnelle Anleitung."
---
## **Einführung**

Videos können dabei helfen, Ideen zu erklären und ein Publikum zu fesseln. Aspose.Slides für C++ ermöglicht das Hinzufügen von Videoframes zu Folien, das Anpassen von Wiedergabeeinstellungen, die Verwaltung von Untertiteln und das Extrahieren eingebetteter Videodaten.

PowerPoint unterstützt lokale Videos und Links zu Online‑Videos, wie z. B. YouTube‑Videos.

Zur Darstellung von Videodaten und Videoframes stellt Aspose.Slides die Schnittstelle [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) sowie die Schnittstelle [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) und weitere relevante Typen bereit.

## **Erstellen eines eingebetteten Videoframes**

Wenn die Videodatei, die Sie Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie ein Videoframe erstellen, um das Video in Ihre Präsentation einzubetten.

Dieses Beispiel bettet ein lokales Video in die erste Folie einer vorhandenen Präsentation ein und speichert das Ergebnis. Die Koordinaten und Abmessungen des Frames sind in Punkten angegeben. Der Stream bleibt geöffnet, bis das Speichern abgeschlossen ist, da [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) ihn gesperrt hält, solange die Präsentation ihn verwendet.

```cpp
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <Export/SaveFormat.h>
#include <LoadingStreamBehavior.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto videoStream = File::OpenRead(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::KeepLocked);
slide->get_Shapes()->AddVideoFrame(10, 10, 150, 250, video);

presentation->Save(u"embedded_video.pptx", SaveFormat::Pptx);

presentation->Dispose();
videoStream->Dispose();
```

Sie können auch einen lokalen Videopfad direkt an [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) übergeben. Dieses Beispiel bettet das Video in die erste Folie einer neuen Präsentation ein. Das Video muss bis zum Speichern der Präsentation zugänglich bleiben.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

slide->get_Shapes()->AddVideoFrame(50, 150, 300, 150, u"video.avi");

presentation->Save(u"video_from_path.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Erstellen eines Videoframes mit Video aus einer Webquelle**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) unterstützt Online‑Videos in Präsentationen. Sie können ein Videoframe erstellen, das auf ein Online‑Video, z. B. ein YouTube‑Video, verweist.

Dieses Beispiel fügt einen YouTube‑Video‑Link und ein Vorschaubild zur ersten Folie hinzu. Ersetzen Sie den Video‑Identifier, um ein anderes Video zu verwenden. Die Methode [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) fordert die automatische Wiedergabe an. Das Herunterladen des Vorschaubilds und das Abspielen des Videos erfordern Internetzugriff. Der Präsentations‑Viewer muss ebenfalls die Online‑Video‑Wiedergabe unterstützen.

```cpp
#include <net/web_client.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/VideoPlayModePreset.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);


auto webClient = MakeObject<System::Net::WebClient>();

String videoId = u"aqz-KE-bpKQ";
auto videoUrl = String::Format(u"https://www.youtube.com/embed/{0}", videoId);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

auto thumbnailUrl = String::Format(u"https://img.youtube.com/vi/{0}/hqdefault.jpg", videoId);
auto thumbnailData = webClient->DownloadData(thumbnailUrl);
auto thumbnail = presentation->get_Images()->AddImage(thumbnailData);
videoFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"online_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Video im Vollbildmodus abspielen**

In einer Schulungspräsentation können Sie eine Software‑Demonstration im Vollbildmodus abspielen, damit das Publikum die Details sehen kann. [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) akzeptiert `true`, um dieses Verhalten während der Wiedergabe zu aktivieren.

Dieses Beispiel öffnet eine Präsentation, findet das erste [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) auf der ersten Folie und aktiviert die Vollbild‑Wiedergabe. Die Eingabepäsentation muss mindestens eine Folie mit einem bereits vorhandenen Videoframe auf der ersten Folie enthalten.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_FullScreenMode(true);
        break;
    }
}

presentation->Save(u"full_screen_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Die Vollbild‑Wiedergabe steuert, wie das Video angezeigt wird. Unabhängig davon steuert [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/), ob es automatisch oder per Klick startet, und [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) legt fest, ob es wiederholt wird. Um das Startverhalten zu wählen, setzen Sie den Wiedergabemodus auf [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/). Das Beispiel bewahrt die vorhandenen Start‑ und Schleife‑Einstellungen.

## **Video nach Wiedergabe zurückspulen**

In einer Schulungspräsentation stellt das Zurückspulen eines Demonstrationsvideos an den Anfang sicher, dass es vom Vortragenden erneut abgespielt werden kann. Rufen Sie [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) mit `true` auf, um das Video nach Abschluss der Wiedergabe an den Anfang zurückzusetzen.

Dieses Beispiel öffnet eine Präsentation, findet das erste [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) auf der ersten Folie und aktiviert das Zurückspulen. Es deaktiviert die Wiederholung, damit die Wiedergabe beendet werden kann, und setzt die Wiedergabe auf Start per Klick. Die Eingabepäsentation muss mindestens eine Folie mit einem bereits vorhandenen Videoframe auf der ersten Folie enthalten.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <DOM/VideoPlayModePreset.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_RewindVideo(true);
        videoFrame->set_PlayLoopMode(false);
        videoFrame->set_PlayMode(VideoPlayModePreset::OnClick);
        break;
    }
}

presentation->Save(u"rewind_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Zurückspulen setzt das Video an den Anfang zurück, ohne es erneut zu starten. Im Gegensatz dazu wiederholt das Aktivieren von [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) die Wiedergabe automatisch. Lassen Sie die Wiederholung deaktiviert, wenn das Video vollständig abgespielt werden und anschließend bereit für eine erneute Wiedergabe bleiben soll. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) steuert unabhängig davon, ob die Wiedergabe automatisch oder per Klick startet; dieses Beispiel verwendet [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/), sodass der Vortragende den Startzeitpunkt bestimmt. Setzen Sie den Wiedergabemodus nach der Schleifen‑Einstellung, wie im Beispiel gezeigt. Das Zurückspulen funktioniert unabhängig von [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/).

## **Trimmen eines Videoframes**

Verwenden Sie [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) und [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/), um zu Beginn oder am Ende eines Videos während der Wiedergabe einen Teil zu überspringen. Beide Werte sind in Millisekunden angegeben. Das Trimmen ändert die Wiedergabeeinstellungen, ohne die eingebetteten Videodaten zu verändern.

**Trim‑Einstellungen festlegen**

Dieses Beispiel bettet ein lokales Video ein und überspringt die ersten 2,5 Sekunden sowie die letzte Sekunde während der Wiedergabe. Verwenden Sie ein Video, das länger als 3,5 Sekunden ist, damit ein abspielbarer Abschnitt erhalten bleibt.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);
videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Trim‑Einstellungen auslesen**

Dieses Beispiel gibt die Trim‑Werte des ersten Videoframes auf der ersten Folie in Millisekunden aus. Die Präsentation muss mindestens eine Folie enthalten. Hat diese Folie kein Videoframe, wird nichts ausgegeben. Das vorherige Beispiel liefert die Werte 2500 und 1000.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        Console::WriteLine(String::Format(u"Trim from start: {0} ms", videoFrame->get_TrimFromStart()));
        Console::WriteLine(String::Format(u"Trim from end: {0} ms", videoFrame->get_TrimFromEnd()));
        break;
    }
}

presentation->Dispose();
```

## **Video‑Untertitel verwalten**

Aspose.Slides ermöglicht die Verwaltung von Closed‑Captions für Videoframes in PowerPoint‑Präsentationen. Untertitel werden im WebVTT‑Format gespeichert und über die Methode [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) bereitgestellt.

### **Untertitel zu einem Videoframe hinzufügen**

Dieses Beispiel bettet ein lokales Video ein und fügt eine WebVTT‑Untertitelspur mit dem Label “English” hinzu. Die Zeitstempel der Untertitel sollten zum Video passen. Die gespeicherte Präsentation enthält sowohl das Video als auch seine Untertitel.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Die Schnittstelle [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) bietet zudem eine Überladung, mit der Sie Untertitel aus einem Stream hinzufügen können.

### **Untertitel aus einem Videoframe extrahieren**

Dieses Beispiel speichert alle Untertitelspuren von Videoframes auf der ersten Folie als separate WebVTT‑Dateien. Aufeinanderfolgende Nummern halten die Ausgabedateien eindeutig. Die Konsole gibt die Anzahl der extrahierten Spuren aus. Die Präsentation muss mindestens eine Folie enthalten.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto trackCount = 0;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : IterateOver(videoFrame->get_CaptionTracks()))
        {
            trackCount++;
            auto outputPath = String::Format(u"captions_{0}.vtt", trackCount);
            File::WriteAllBytes(outputPath, captionTrack->get_BinaryData());
        }
    }
}

Console::WriteLine(String::Format(u"Caption tracks extracted: {0}", trackCount));

presentation->Dispose();
```

Jedes [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/)‑Objekt stellt den Untertitel‑Identifier, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑Zeichenfolge bereit.

### **Untertitel aus einem Videoframe entfernen**

Dieses Beispiel entfernt alle Untertitel aus dem Videoframe an der ersten Shape‑Position auf der ersten Folie und speichert das Ergebnis. Es wird davon ausgegangen, dass die Folie und das Shape existieren und dass das Shape ein Videoframe ist.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wenn Sie nur eine Untertitelspur entfernen möchten, verwenden Sie die Methoden [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) oder [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) anstelle von [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/).

### **Video‑Untertitel durchsuchen**

[ICaptions::get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) gibt die komplette WebVTT‑Spur zurück, inklusive Header, Timing‑Zeilen und Untertiteltext. Um einen gesprochenen Ausdruck und dessen Zeitstempel zu finden, lesen Sie die Cues im Speicher. Zum Beispiel könnte eine englische Spur auf Folie 2 folgenden Text enthalten:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Das Beispiel öffnet `captioned_media.pptx` und liest die Untertitelspuren jedes obersten Videoframes auf jeder Folie mithilfe von [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/). In einem reinen Text‑Cue enthält die Timing‑Zeile `-->` und eine leere Zeile beendet den Cue. Enthält der Untertitel das Wort “café”, gibt das Beispiel die Folien‑Nummer, das Spurlabel, die ursprüngliche Timing‑Zeile und den vollständigen Untertitel aus. Die Suche ignoriert die Groß‑/Kleinschreibung.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/string_reader.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"captioned_media.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        auto videoFrame = AsCast<IVideoFrame>(shape);
        if (!videoFrame)
            continue;

        for (auto&& track : IterateOver(videoFrame->get_CaptionTracks()))
        {
            auto reader = MakeObject<StringReader>(track->get_DataAsString());
            for (auto timing = reader->ReadLine(); !timing.IsNull(); timing = reader->ReadLine())
            {
                if (!timing.Contains(u"-->"))
                    continue;

                String caption;
                for (auto line = reader->ReadLine(); !String::IsNullOrEmpty(line); line = reader->ReadLine())
                {
                    if (!String::IsNullOrEmpty(caption))
                        caption += u"\n";
                    caption += line;
                }

                if (caption.IndexOf(u"caf\u00E9", StringComparison::OrdinalIgnoreCase) >= 0)
                {
                    Console::WriteLine(String::Format(u"Slide {0} | {1} | {2}", slide->get_SlideNumber(), track->get_Label(), timing));
                    Console::WriteLine(caption);
                }
            }
        }
    }
}
presentation->Dispose();
```

Die Suche nach “café” liefert einen Treffer für die Beispielspur. Die Suche überspringt den Header und bewahrt die Timing‑Einstellung in der Ausgabe.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Video aus einer Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

Dieses Beispiel extrahiert eingebettete Videos von jeder Folie in separate, nummerierte Binärdateien. Verknüpfte Videos werden übersprungen, da sie keine eingebetteten Daten enthalten. Die Konsole gibt den MIME‑Typ jedes Videos und die Gesamtzahl aus. Die Ausgabe verwendet die generische Erweiterung `.bin`; passen Sie sie bei Bedarf an den gemeldeten Medientyp an.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IVideo.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation_with_videos.pptx");

auto videoCount = 0;
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            auto videoFrame = ExplicitCast<IVideoFrame>(shape);
            auto video = videoFrame->get_EmbeddedVideo();
            if (video == nullptr)
            {
                Console::WriteLine(u"Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            auto outputPath = String::Format(u"extracted_video_{0}.bin", videoCount);
            File::WriteAllBytes(outputPath, video->get_BinaryData());
            Console::WriteLine(String::Format(u"Video {0}: {1}", videoCount, video->get_ContentType()));
        }
    }
}

Console::WriteLine(String::Format(u"Embedded videos extracted: {0}", videoCount));

presentation->Dispose();
```

## **FAQ**

**Welche Videowiedergabe‑Parameter können für ein Videoframe geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (auto oder per Klick) und die [Schleifen‑Wiedergabe](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) steuern. Diese Optionen stehen über die Methoden des [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/)‑Objekts zur Verfügung.

**Wirkt sich das Hinzufügen eines Videos auf die Größe der PPTX‑Datei aus?**

Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Wenn Sie zu einem Online‑Video verlinken und ein Vorschaubild hinzufügen, speichert die Präsentation den Link und das Vorschaubild anstelle der Videodaten, sodass die Größensteigerung in der Regel kleiner ist.

**Kann ich das Video in einem vorhandenen Videoframe ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Video‑Inhalt](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) innerhalb des Frames austauschen, während die Geometrie des Shapes erhalten bleibt; dies ist ein gängiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video hat einen [Inhaltstyp](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/), den Sie auslesen und beispielsweise beim Speichern auf die Festplatte verwenden können.