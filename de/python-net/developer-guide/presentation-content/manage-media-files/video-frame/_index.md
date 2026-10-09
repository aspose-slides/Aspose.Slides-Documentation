---
title: Video‑Frames in Präsentationen mit Python verwalten
linktitle: Video‑Frame
type: docs
weight: 10
url: /de/python-net/video-frame/
keywords:
- Video hinzufügen
- Video erstellen
- Video einbetten
- Video extrahieren
- Video abrufen
- Video‑Frame
- Web‑Quelle
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie programmgesteuert Video‑Frames in PowerPoint‑ und OpenDocument‑Folien mit Aspose.Slides für Python über .NET hinzufügen und extrahieren. Schnelle Kurz‑Anleitung."
---
## **Einleitung**

Videos können helfen, Ideen zu erklären und ein Publikum zu fesseln. Aspose.Slides für Python über .NET ermöglicht das Hinzufügen von Video‑Frames zu Folien, das Anpassen von Wiedergabeeinstellungen, das Verwalten von Untertiteln und das Extrahieren eingebetteter Videodaten.

PowerPoint unterstützt lokale Videos und Verknüpfungen zu Online‑Videos, wie z. B. YouTube‑Videos.

Um Videodaten und Video‑Frames darzustellen, stellt Aspose.Slides die [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/)-Klasse, die [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)-Klasse und weitere relevante Typen bereit.

## **Erstellen eines eingebetteten Video‑Frames**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten.

Dieses Beispiel bettet ein lokales Video in die erste Folie einer vorhandenen Präsentation ein und speichert das Ergebnis. Die Koordinaten und Abmessungen des Frames sind in Punkten angegeben. Der Stream bleibt geöffnet, bis das Speichern abgeschlossen ist, da [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) ihn gesperrt hält, während die Präsentation ihn verwendet.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

Sie können auch einen lokalen Videopfad direkt an [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). Dieses Beispiel bettet das Video in die erste Folie einer neuen Präsentation ein. Das Video muss bis zum Speichern der Präsentation zugänglich bleiben.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Erstellen eines Video‑Frames mit Video aus einer Webquelle**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) unterstützt Online‑Videos in Präsentationen. Sie können einen Video‑Frame erstellen, der auf ein Online‑Video, beispielsweise ein YouTube‑Video, verlinkt.

Dieses Beispiel fügt einen YouTube‑Video‑Link und ein Vorschaubild zur ersten Folie hinzu. Ersetzen Sie den Video‑Bezeichner, um ein anderes Video zu verwenden. Die Einstellung [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) fordert die automatische Wiedergabe an. Das Herunterladen des Vorschaubilds und das Abspielen des Videos erfordern Internetzugang. Der Präsentations‑Viewer muss ebenfalls die Online‑Videowiedergabe unterstützen.

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **Video im Vollbildmodus abspielen**

In einer Schulungspräsentation können Sie eine Software‑Demonstration im Vollbildmodus abspielen, damit das Publikum die Details sehen kann. Setzen Sie [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) auf `True`, um dieses Verhalten während der Wiedergabe zu aktivieren.

Dieses Beispiel öffnet eine Präsentation, findet den ersten [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) auf der ersten Folie und aktiviert die Vollbild‑Wiedergabe. Die Eingabe‑Präsentation muss mindestens eine Folie mit einem vorhandenen Video‑Frame auf der ersten Folie enthalten.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

Die Vollbild‑Wiedergabe steuert, wie das Video angezeigt wird. Unabhängig davon regelt [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/), ob es automatisch oder per Klick startet, und [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) , ob es wiederholt wird. Um das Startverhalten zu wählen, setzen Sie den Wiedergabemodus auf [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). Das Beispiel bewahrt die vorhandenen Start‑ und Schleifeinstellungen.

## **Video nach Wiedergabe zurückspulen**

In einer Schulungspräsentation macht das Zurückspulen eines Demonstrationsvideos an den Anfang das Video bereit, es erneut abzuspielen. Setzen Sie [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) auf `True`, um das Video nach Beendigung der Wiedergabe an den Anfang zurückzusetzen.

Dieses Beispiel öffnet eine Präsentation, findet den ersten [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) auf der ersten Folie und aktiviert das Zurückspulen. Es deaktiviert die Schleife, damit die Wiedergabe beendet werden kann, und setzt die Wiedergabe auf Start per Klick. Die Eingabe‑Präsentation muss mindestens eine Folie mit einem vorhandenen Video‑Frame auf der ersten Folie enthalten.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

Das Zurückspulen setzt das Video an den Anfang zurück, ohne es erneut zu starten. Im Gegensatz dazu wiederholt das Aktivieren von [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) die Wiedergabe automatisch. Deaktivieren Sie die Schleife, wenn das Video bis zum Ende laufen und bereit zum erneuten Abspielen sein soll. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) steuert unabhängig davon den automatischen oder per Klick gestarteten Beginn; dieses Beispiel verwendet [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/), sodass der Präsentator entscheidet, wann die Wiedergabe startet. Setzen Sie den Wiedergabemodus nach der Schleifeneinstellung, wie im Beispiel gezeigt. Das Zurückspulen funktioniert unabhängig von [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/).

## **Video‑Frame zuschneiden**

Verwenden Sie [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) und [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/), um zu Beginn oder am Ende eines Videos während der Wiedergabe einen Teil zu überspringen. Beide Werte sind in Millisekunden angegeben. Das Zuschneiden ändert die Wiedergabeeinstellungen, ohne die eingebetteten Videodaten zu ändern.

**Trim-Einstellungen festlegen**

Dieses Beispiel bettet ein lokales Video ein und überspringt die ersten 2,5 Sekunden und die letzte Sekunde während der Wiedergabe. Verwenden Sie ein Video, das länger als 3,5 Sekunden ist, damit ein abspielbarer Abschnitt verbleibt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Trim-Einstellungen lesen**

Dieses Beispiel gibt die Zuschneidewerte des ersten Video‑Frames auf der ersten Folie in Millisekunden aus. Die Präsentation muss mindestens eine Folie enthalten. Hat diese Folie keinen Video‑Frame, wird nichts ausgegeben. Das vorherige Beispiel liefert die Werte 2500 und 1000.

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **Video‑Untertitel verwalten**

Aspose.Slides ermöglicht die Verwaltung von Untertiteln für Video‑Frames in PowerPoint‑Präsentationen. Untertitel werden im WebVTT‑Format gespeichert und über die Eigenschaft [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) bereitgestellt.

**Untertitel zu einem Video‑Frame hinzufügen**

Dieses Beispiel bettet ein lokales Video ein und fügt eine WebVTT‑Untertitelspur mit dem Label English hinzu. Die Zeitstempel der Untertitel sollten zum Video passen. Die gespeicherte Präsentation enthält sowohl das Video als auch dessen Untertitel.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

Die Klasse [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) bietet ebenfalls eine Überladung, die das Hinzufügen von Untertiteln aus einem Stream ermöglicht.

**Untertitel aus einem Video‑Frame extrahieren**

Dieses Beispiel speichert alle Untertitelspuren von Video‑Frames auf der ersten Folie als getrennte WebVTT‑Dateien. Aufeinanderfolgende Nummern halten die Ausgabedateien eindeutig. Die Konsole gibt die Anzahl der extrahierten Spuren aus. Die Präsentation muss mindestens eine Folie enthalten.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

Jedes [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/)‑Objekt stellt den Untertitel‑Bezeichner, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑Zeichenfolge bereit.

**Untertitel von einem Video‑Frame entfernen**

Dieses Beispiel entfernt alle Untertitel vom Video‑Frame an der ersten Shape‑Position auf der ersten Folie und speichert das Ergebnis. Es wird angenommen, dass Folie und Shape existieren und dass das Shape ein Video‑Frame ist.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Wenn Sie nur eine Untertitelspur entfernen müssen, verwenden Sie die Methoden [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) oder [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/), anstatt [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/).

## **Video aus einer Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

Dieses Beispiel extrahiert eingebettete Videos aus jeder Folie in separate, nummerierte Binärdateien. Verknüpfte Videos werden übersprungen, da sie keine eingebetteten Daten besitzen. Die Konsole gibt den MIME‑Typ jedes Videos und die Gesamtanzahl aus. Der Output verwendet die generische `.bin`‑Erweiterung; passen Sie sie bei Bedarf dem gemeldeten Medientyp an.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **FAQ**

**Welche Video‑Wiedergabeparameter können für einen Video‑Frame geändert werden?**

Sie können den [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/)-Modus (auto oder per Klick) und [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) steuern. Diese Optionen stehen über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)-Objekts zur Verfügung.

**Wirkt sich das Hinzufügen eines Videos auf die PPTX-Dateigröße aus?**

Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Wenn Sie hingegen auf ein Online‑Video verlinken und ein Vorschaubild hinzufügen, speichert die Präsentation den Link und das Vorschaubild statt der Videodaten, sodass die Größenincrease normalerweise kleiner ist.

**Kann ich das Video in einem vorhandenen Video‑Frame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/)‑Inhalt im Frame austauschen, während Sie die Geometrie des Shapes beibehalten; dies ist ein gängiges Szenario zum Aktualisieren von Medien in einem vorhandenen Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video hat einen [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/), den Sie auslesen und verwenden können, zum Beispiel beim Speichern auf die Festplatte.