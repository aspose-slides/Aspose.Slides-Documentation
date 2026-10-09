---
title: Video-Frames in Präsentationen mit Python verwalten
linktitle: Video-Frame
type: docs
weight: 10
url: /de/python-java/video-frame/
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
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie programmgesteuert Video-Frames in PowerPoint- und OpenDocument-Folien mithilfe von Aspose.Slides for Python via Java hinzufügen und extrahieren. Schnelle Anleitung."
---
## **Einleitung**

Videos können dabei helfen, Ideen zu erklären und ein Publikum zu fesseln. Aspose.Slides for Python via Java ermöglicht das Hinzufügen von Videoframes zu Folien, das Anpassen von Wiedergabeeinstellungen, das Verwalten von Untertiteln und das Extrahieren eingebetteter Videodaten.

PowerPoint unterstützt lokale Videos und Links zu Online‑Videos, wie z. B. YouTube‑Videos.

Um Videodaten und Videoframes darzustellen, stellt Aspose.Slides die Klasse [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/), die Klasse [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) und andere relevante Typen bereit.

## **Ein eingebettetes Videoframe erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie ein Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten.

Dieses Beispiel bettet ein lokales Video in die erste Folie einer vorhandenen Präsentation ein und speichert das Ergebnis. Die Koordinaten und Abmessungen des Frames sind in Punkten angegeben. Python liest die Videobytes von der Festplatte, und JPype konvertiert sie in ein Java‑Byte‑Array, bevor das Video zur Präsentation hinzugefügt wird.

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

Sie können auch einen lokalen Videopfad direkt an [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame) übergeben. Dieses Beispiel bettet das Video in die erste Folie einer neuen Präsentation ein. Das Video muss bis zum Speichern der Präsentation zugänglich bleiben.

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

## **Ein Video‑Frame mit Video aus einer Web‑Quelle erstellen**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) unterstützt Online‑Videos in Präsentationen. Sie können ein Video‑Frame erstellen, das auf ein Online‑Video verweist, beispielsweise ein YouTube‑Video.

Dieses Beispiel fügt einen YouTube‑Video‑Link und ein Vorschaubild zur ersten Folie hinzu. Ersetzen Sie den Video‑Identifier, um ein anderes Video zu verwenden. Die Methode [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) fordert die automatische Wiedergabe an. Das Herunterladen des Vorschaubilds und das Abspielen des Videos erfordern Internetzugang. Der Präsentations‑Viewer muss ebenfalls die Online‑Videowiedergabe unterstützen.

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

## **Ein Video im Vollbildmodus abspielen**

In einer Schulungspräsentation können Sie eine Software‑Demo im Vollbildmodus abspielen, damit das Publikum die Details sehen kann. Rufen Sie [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) mit `True` auf, um dieses Verhalten während der Wiedergabe zu aktivieren.

Dieses Beispiel öffnet eine Präsentation, findet das erste [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) auf der ersten Folie und aktiviert die Vollbild‑Wiedergabe. Die Eingabe‑Präsentation muss mindestens eine Folie mit einem vorhandenen Video‑Frame auf der ersten Folie enthalten.

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

Die Vollbild‑Wiedergabe steuert, wie das Video angezeigt wird. Unabhängig davon regelt [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode), ob es automatisch oder per Klick startet, und [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) bestimmt, ob es wiederholt wird. Um das Startverhalten zu wählen, setzen Sie den Wiedergabemodus auf [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). Das Beispiel bewahrt die vorhandenen Start‑ und Schleife‑Einstellungen.

## **Ein Video nach der Wiedergabe zurückspulen**

In einer Schulungspräsentation macht das Zurückspulen eines Demonstrationsvideos an den Anfang das Video wieder bereit für den Präsentierenden. Rufen Sie [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) mit `True` auf, um das Video nach Abschluss der Wiedergabe an den Anfang zurückzusetzen.

Dieses Beispiel öffnet eine Präsentation, findet das erste [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) auf der ersten Folie und aktiviert das Zurückspulen. Es deaktiviert die Schleife, sodass die Wiedergabe beendet werden kann, und setzt die Wiedergabe so, dass sie per Klick startet. Die Eingabe‑Präsentation muss mindestens eine Folie mit einem vorhandenen Video‑Frame auf der ersten Folie enthalten.

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

Das Zurückspulen bringt das Video an den Anfang, ohne es erneut zu starten. Im Gegensatz dazu wiederholt das Aufrufen von [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) mit `True` die Wiedergabe automatisch. Deaktivieren Sie die Schleife, wenn das Video bis zum Ende laufen und anschließend bereit zum erneuten Abspielen sein soll. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) steuert unabhängig davon, ob die Wiedergabe automatisch oder per Klick startet; dieses Beispiel verwendet [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/), sodass der Präsentierende kontrolliert, wann die Wiedergabe beginnt. Setzen Sie den Wiedergabemodus nach der Schleife‑Einstellung, wie im Beispiel gezeigt. Das Zurückspulen funktioniert unabhängig von [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Ein Video‑Frame trimmen**

Verwenden Sie [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) und [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd), um zu Beginn oder am Ende eines Videos während der Wiedergabe Teile zu überspringen. Beide Werte sind in Millisekunden angegeben. Das Trimmen ändert die Wiedergabeeinstellungen, ohne die eingebetteten Videodaten zu verändern.

**Trimmeinstellungen festlegen**

Dieses Beispiel bettet ein lokales Video ein und überspringt während der Wiedergabe die ersten 2,5 Sekunden und die letzte Sekunde. Verwenden Sie ein Video, das länger als 3,5 Sekunden ist, damit ein abspielbarer Abschnitt erhalten bleibt.

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

**Trimmeinstellungen auslesen**

Dieses Beispiel gibt die Trimmwerte des ersten Video‑Frames auf der ersten Folie in Millisekunden aus. Die Präsentation muss mindestens eine Folie enthalten. Wenn diese Folie keinen Video‑Frame hat, wird nichts ausgegeben. Das vorherige Beispiel erzeugt die Werte 2500 und 1000.

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

## **Video‑Untertitel verwalten**

Aspose.Slides ermöglicht es Ihnen, geschlossene Untertitel für Video‑Frames in PowerPoint‑Präsentationen zu verwalten. Untertitel werden im WebVTT‑Format gespeichert und über die Methode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) bereitgestellt.

**Untertitel zu einem Video‑Frame hinzufügen**

Dieses Beispiel bettet ein lokales Video ein und fügt eine WebVTT‑Untertitelspur mit dem Namen English hinzu. Die Zeitstempel der Untertitel sollten mit dem Video übereinstimmen. Die gespeicherte Präsentation enthält sowohl das Video als auch seine Untertitel.

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

    # Fügen Sie eine neue Untertitelspur aus einer WebVTT-Datei hinzu.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die Klasse [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) bietet außerdem eine Überladung, mit der Sie Untertitel aus einem Stream hinzufügen können.

**Untertitel aus einem Video‑Frame extrahieren**

Dieses Beispiel speichert alle Untertitelspuren von Video‑Frames auf der ersten Folie als separate WebVTT‑Dateien. Fortlaufende Nummern halten die Ausgabedateien eindeutig. Die Konsole gibt die Anzahl der extrahierten Spuren aus. Die Präsentation muss mindestens eine Folie enthalten.

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

Jedes [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/)‑Objekt stellt den Untertitel‑Identifier, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑Zeichenkette bereit.

**Untertitel aus einem Video‑Frame entfernen**

Dieses Beispiel entfernt alle Untertitel aus dem Video‑Frame an der ersten Shape‑Position auf der ersten Folie und speichert das Ergebnis. Es wird vorausgesetzt, dass die Folie und das Shape existieren und dass das Shape ein Video‑Frame ist.

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
        # Entfernen Sie alle Untertitel aus dem Video-Frame.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Wenn Sie nur eine Untertitelspur entfernen müssen, verwenden Sie die Methoden [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) oder [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) anstelle von [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

## **Video aus einer Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

Dieses Beispiel extrahiert eingebettete Videos von jeder Folie in separate, nummerierte Binärdateien. Verlinkte Videos werden übersprungen, da sie keine eingebetteten Daten besitzen. Die Konsole gibt den MIME‑Typ jedes Videos und die Gesamtanzahl aus. Die Ausgabe verwendet die generische Erweiterung `.bin`; passen Sie sie bei Bedarf an den gemeldeten Medientyp an.

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

**Welche Video‑Wiedergabeparameter können für einen Video‑Frame geändert werden?**

Sie können den [playback mode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (auto oder per Klick) und das [looping](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) steuern. Diese Optionen stehen über die Methoden des [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/)-Objekts zur Verfügung.

**Beeinflusst das Hinzufügen eines Videos die PPTX-Dateigröße?**

Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Wenn Sie zu einem Online‑Video verlinken und ein Vorschaubild hinzufügen, speichert die Präsentation den Link und das Vorschaubild statt der Videodaten, sodass die Größensteigerung normalerweise geringer ist.

**Kann ich das Video in einem bestehenden Video‑Frame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [video content](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) im Frame austauschen und dabei die Geometrie des Shapes beibehalten; dies ist ein übliches Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video hat einen [content type](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType), den Sie auslesen und verwenden können, beispielsweise beim Speichern auf die Festplatte.