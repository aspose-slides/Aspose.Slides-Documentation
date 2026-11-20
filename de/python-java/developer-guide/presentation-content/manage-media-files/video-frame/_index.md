---
title: Video‑Frames in Präsentationen mit Python verwalten
linktitle: Video‑Frame
type: docs
weight: 10
url: /de/python-java/video-frame/
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
description: "Erfahren Sie, wie Sie programmgesteuert Video‑Frames in PowerPoint‑ und OpenDocument‑Folien mit Aspose.Slides für Python via Java hinzufügen und extrahieren. Schnelle Anleitung."
---
## **Einleitung**

Videos können dabei helfen, Ideen zu erklären und das Publikum zu fesseln. Aspose.Slides für Python via Java ermöglicht das Hinzufügen von Video‑Frames zu Folien, das Anpassen von Wiedergabeeinstellungen, die Verwaltung von Untertiteln und das Extrahieren eingebetteter Videodaten.

PowerPoint unterstützt lokale Videos und Verknüpfungen zu Online‑Videos, wie zum Beispiel YouTube‑Videos.

Um Videodaten und Video‑Frames darzustellen, stellt Aspose.Slides die Klasse [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/), die Klasse [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) und weitere relevante Typen bereit.

## **Einbetten eines Video‑Frames**

Wenn die Videodatei, die Sie Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten.

Dieses Beispiel bettet ein lokales Video auf der ersten Folie einer bestehenden Präsentation ein und speichert das Ergebnis. Die Frame‑Koordinaten und -Dimensionen werden in Punkten angegeben. Python liest die Videodaten von der Festplatte und JPype wandelt sie in ein Java‑Byte‑Array um, bevor das Video zur Präsentation hinzugefügt wird.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video)

    presentation.save("embedded_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sie können auch einen lokalen Videopfad direkt an [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame) übergeben. Dieses Beispiel bettet das Video auf der ersten Folie einer neuen Präsentation ein. Das Video muss bis zum Speichern der Präsentation zugänglich bleiben.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Erstellen eines Video‑Frames mit Video aus einer Web‑Quelle**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) unterstützt Online‑Videos in Präsentationen. Sie können einen Video‑Frame erstellen, der auf ein Online‑Video, etwa ein YouTube‑Video, verweist.

Dieses Beispiel fügt einen YouTube‑Video‑Link und ein Vorschaubild zur ersten Folie hinzu. Ersetzen Sie die Video‑Kennung, um ein anderes Video zu verwenden. Die Methode [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) verlangt automatische Wiedergabe. Das Herunterladen des Vorschaubilds und das Abspielen des Videos erfordern Internetzugriff. Der Präsentations‑Viewer muss ebenfalls Online‑Video‑Wiedergabe unterstützen.

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_id = "aqz-KE-bpKQ"
    video_url = "https://www.youtube.com/embed/" + video_id
    video_frame = slide.getShapes().addVideoFrame(10, 10, 427, 240, video_url)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    thumbnail_url = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
    thumbnail = presentation.getImages().addImage(java_thumbnail_data)
    video_frame.getPictureFormat().getPicture().setImage(thumbnail)

    presentation.save("online_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Wiedergabe eines Videos im Vollbildmodus**

In einer Schulungspräsentation können Sie eine Software‑Demonstration im Vollbildmodus abspielen, sodass das Publikum die Details sehen kann. Rufen Sie [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) mit `True` auf, um dieses Verhalten während der Wiedergabe zu aktivieren.

Dieses Beispiel öffnet eine Präsentation, findet den ersten [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) auf der ersten Folie und aktiviert die Vollbild‑Wiedergabe. Die Eingabe‑Präsentation muss mindestens eine Folie mit einem vorhandenen Video‑Frame auf der ersten Folie enthalten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setFullScreenMode(True)
            break

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die Vollbild‑Wiedergabe steuert, wie das Video angezeigt wird. Unabhängig davon regelt [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode), ob es automatisch oder bei Klick startet, und [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) steuert, ob es wiederholt wird. Um das Startverhalten zu wählen, setzen Sie den Wiedergabemodus auf [VideoPlayModePreset.Auto oder VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). Das Beispiel behält die vorhandenen Start‑ und Schleifeneinstellungen bei.

## **Nach der Wiedergabe ein Video zurückspulen**

In einer Schulungspräsentation macht das Zurückspulen eines Demonstrations‑Videos zum Anfang das Video wieder bereit für die erneute Wiedergabe. Rufen Sie [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) mit `True` auf, um das Video nach Abschluss der Wiedergabe an den Anfang zurückzusetzen.

Dieses Beispiel öffnet eine Präsentation, findet den ersten [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) auf der ersten Folie und aktiviert das Zurückspulen. Es deaktiviert die Schleife, damit die Wiedergabe beendet werden kann, und setzt die Wiedergabe so, dass sie bei Klick startet. Die Eingabe‑Präsentation muss mindestens eine Folie mit einem vorhandenen Video‑Frame auf der ersten Folie enthalten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame, VideoPlayModePreset

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setRewindVideo(True)
            shape.setPlayLoopMode(False)
            shape.setPlayMode(VideoPlayModePreset.OnClick)
            break

    presentation.save("rewind_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Zurückspulen setzt das Video an den Anfang zurück, ohne es erneut zu starten. Im Gegensatz dazu wiederholt ein Aufruf von [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) mit `True` die Wiedergabe automatisch. Deaktivieren Sie die Schleife, wenn das Video vollständig abgewickelt werden und anschließend bereit zur Wiederholung sein soll. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) steuert unabhängig davon, ob die Wiedergabe automatisch oder per Klick startet; dieses Beispiel verwendet [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/), sodass der Presenter entscheidet, wann die Wiedergabe beginnt. Setzen Sie den Wiedergabemodus nach der Schleifeneinstellung, wie im Beispiel gezeigt. Das Zurückspulen funktioniert unabhängig von [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Trimmen eines Video‑Frames**

Verwenden Sie [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) und [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd), um zu Beginn oder am Ende eines Videos während der Wiedergabe Teile zu überspringen. Beide Werte werden in Millisekunden angegeben. Das Trimmen ändert die Wiedergabeeinstellungen, ohne die eingebetteten Videodaten zu verändern.

**Trim‑Einstellungen festlegen**

Dieses Beispiel bettet ein lokales Video ein und überspringt die ersten 2,5 Sekunden und die letzte Sekunde während der Wiedergabe. Verwenden Sie ein Video, das länger als 3,5 Sekunden ist, damit ein abspielbarer Abschnitt verbleibt.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Trim‑Einstellungen auslesen**

Dieses Beispiel gibt die Trim‑Werte des ersten Video‑Frames auf der ersten Folie in Millisekunden aus. Die Präsentation muss mindestens eine Folie enthalten. Hat die Folie keinen Video‑Frame, wird nichts ausgegeben. Das vorherige Beispiel erzeugt die Werte 2500 und 1000.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **Verwalten von Video‑Untertiteln**

Aspose.Slides ermöglicht die Verwaltung von Untertiteln für Video‑Frames in PowerPoint‑Präsentationen. Untertitel werden im WebVTT‑Format gespeichert und über die Methode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) bereitgestellt.

### **Untertitel zu einem Video‑Frame hinzufügen**

Dieses Beispiel bettet ein lokales Video ein und fügt einen WebVTT‑Untertitel‑Track mit der Bezeichnung English hinzu. Die Untertitel‑Zeitstempel sollten mit dem Video übereinstimmen. Die gespeicherte Präsentation enthält sowohl das Video als auch seine Untertitel.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Neuen Untertitel-Track aus einer WebVTT-Datei hinzufügen.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die Klasse [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) bietet ebenfalls eine Überladung, mit der Sie Untertitel aus einem Stream hinzufügen können.

### **Untertitel aus einem Video‑Frame extrahieren**

Dieses Beispiel speichert alle Untertitel‑Tracks von Video‑Frames auf der ersten Folie als separate WebVTT‑Dateien. Fortlaufende Nummern halten die Ausgabedateien voneinander getrennt. Die Konsole gibt die Anzahl der extrahierten Tracks aus. Die Präsentation muss mindestens eine Folie enthalten.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    track_count = 0
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                track_count += 1
                output_path = Path(f"captions_{track_count}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                output_path.write_bytes(caption_data)

    print(f"Caption tracks extracted: {track_count}")
finally:
    presentation.dispose()
```

Jedes [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/)‑Objekt stellt die Untertitel‑Kennung, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑String bereit.

### **Untertitel aus einem Video‑Frame entfernen**

Dieses Beispiel entfernt alle Untertitel aus dem Video‑Frame an der ersten Shape‑Position auf der ersten Folie und speichert das Ergebnis. Es wird davon ausgegangen, dass die Folie und das Shape existieren und dass das Shape ein Video‑Frame ist.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # Alle Untertitel aus dem Video-Frame entfernen.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Falls Sie nur einen Untertitel‑Track entfernen möchten, verwenden Sie die Methoden [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) oder [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) anstelle von [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

### **Video‑Untertitel durchsuchen**

[Captions.getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) liefert den kompletten WebVTT‑Track, einschließlich Header, Zeitlinien und Untertiteltext. Sie können die Untertitel im Speicher durchsuchen, um eine Phrase und deren Zeitstempel zu finden. Zum Beispiel könnte ein englischer Track auf Folie 2 folgenden Text enthalten.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Dieses Beispiel öffnet `captioned_media.pptx` und verwendet [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks), um die Tracks jedes obersten Video‑Frames auf jeder Folie auszulesen. In einem Klartext‑Cue enthält die Zeitlinie `-->` und eine leere Zeile beendet den Cue. Für jeden Untertitel, der das Wort „café“ in beliebiger Groß‑/Kleinschreibung enthält, gibt das Beispiel die Folien‑Nummer, das Track‑Label, die ursprüngliche Zeitlinie und den vollständigen Untertitel aus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("captioned_media.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, VideoFrame):
                continue
            for track in shape.getCaptionTracks():
                track_text = str(track.getDataAsString())
                lines = iter(track_text.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue
                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)
                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.getSlideNumber()} | {track.getLabel()} | {timing}")
                        print(caption)
finally:
    presentation.dispose()
```

Die Suche nach „café“ liefert einen Treffer für den Beispiel‑Track. Die Suche schließt den Track‑Header aus und behält die Zeit‑Einstellungen sowie Zeilenumbrüche in der Ausgabe bei.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Video aus einer Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

Dieses Beispiel extrahiert eingebettete Videos von jeder Folie in separate, nummerierte Binärdateien. Verknüpfte Videos werden übersprungen, da sie keine eingebetteten Daten besitzen. Die Konsole gibt den MIME‑Typ jedes Videos und die Gesamtsumme aus. Die Ausgabe verwendet die generische Erweiterung `.bin`; passen Sie sie bei Bedarf an den gemeldeten Medientyp an.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("presentation_with_videos.pptx")
try:
    video_count = 0
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = Path(f"extracted_video_{video_count}.bin")
                video_data = bytes(video.getBinaryData())
                output_path.write_bytes(video_data)
                print(f"Video {video_count}: {video.getContentType()}")

    print(f"Embedded videos extracted: {video_count}")
finally:
    presentation.dispose()
```

## **FAQ**

**Welche Wiedergabe‑Parameter können für einen Video‑Frame geändert werden?**

Sie können den [playback mode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (automatisch oder bei Klick) und das [looping](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) steuern. Diese Optionen stehen über die Methoden des [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/)‑Objekts zur Verfügung.

**Beeinflusst das Hinzufügen eines Videos die PPTX‑Dateigröße?**

Ja. Wenn Sie ein lokales Video einbetten, wird die Binärdatei in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Wenn Sie zu einem Online‑Video verlinken und ein Vorschaubild hinzufügen, speichert die Präsentation nur den Link und das Vorschaubild, nicht das Videomaterial, sodass die Größensteigerung in der Regel geringer ist.

**Kann ich das Video in einem bestehenden Video‑Frame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [video content](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) innerhalb des Frames austauschen und dabei die Geometrie der Form beibehalten; dies ist ein gängiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Content‑Typ (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video hat einen [content type](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType), den Sie auslesen und zum Beispiel beim Speichern auf die Festplatte verwenden können.