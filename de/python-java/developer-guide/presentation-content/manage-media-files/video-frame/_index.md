---
title: Verwalten von Video-Frames in Präsentationen mit Python
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
- Web-Quelle
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie programmgesteuert Video-Frames in PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Python über Java hinzufügen und extrahieren. Schnelle Schritt-für-Schritt-Anleitung."
---
## **Einleitung**

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement Ihres Publikums steigern.

PowerPoint ermöglicht es Ihnen, Videos auf einer Folie in einer Präsentation auf zwei Arten hinzuzufügen:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Ein Online‑Video hinzufügen (aus einer Web‑Quelle wie YouTube)

Damit Sie Videos (Video‑Objekte) zu einer Präsentation hinzufügen können, stellt Aspose.Slides die Klasse [Video](https://reference.aspose.com/slides/de/python-java/aspose.slides/video/), die Klasse [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/) und weitere relevante Typen bereit.

## **Erstellen eingebetteter Videoframes**

Wenn die Videodatei, die Sie Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Videoframe erstellen, um das Video in Ihrer Präsentation einzubetten.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
2. Rufen Sie über den Index die Referenz einer Folie ab.
3. Fügen Sie ein [Video](https://reference.aspose.com/slides/de/python-java/aspose.slides/video/)‑Objekt hinzu und übergeben Sie die Videodateidaten, um das Video in der Präsentation einzubetten.
4. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/)‑Objekt hinzu, um einen Frame für das Video zu erstellen.
5. Speichern Sie die geänderte Präsentation.

Dieses Python‑Beispiel zeigt, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Alternativ können Sie ein Video hinzufügen, indem Sie seinen Dateipfad direkt an die Methode [addVideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addVideoFrame) übergeben:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```

## **Erstellen von Videoframes mit Videos aus Web‑Quellen**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube‑Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über den Web‑Link zu Ihrer Präsentation hinzufügen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
2. Rufen Sie über den Index die Referenz einer Folie ab.
3. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/)‑Objekt hinzu und übergeben Sie den Link zum Video.
4. Legen Sie ein Miniaturbild für den Videoframe fest.
5. Speichern Sie die Präsentation.

Dieses Python‑Beispiel zeigt, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint‑Präsentation hinzufügen:

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # Lade das Miniaturbild.
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Trimmen eines Videoframes**

Aspose.Slides ermöglicht es, zu steuern, welcher Teil eines Videos abgespielt wird, indem die Werte trim‑from‑start und trim‑from‑end über [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#setTrimFromStart) und [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#setTrimFromEnd) festgelegt werden. Beide Werte werden in Millisekunden angegeben und bestimmen, wie viel Zeit zu Beginn bzw. am Ende des Videos übersprungen wird. Diese Einstellungen ändern die Wiedergabe‑Parameter des Videos in der Präsentation; sie schneiden das eingebettete Videobinary nicht zu oder ändern es anderweitig.

**Trim‑Einstellungen festlegen**

So erstellen Sie einen Videoframe und legen seine Trim‑Einstellungen fest:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
2. Fügen Sie der Präsentation ein [Video](https://reference.aspose.com/slides/de/python-java/aspose.slides/video/)‑Objekt hinzu.
3. Fügen Sie einer Folie ein [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/)‑Objekt hinzu.
4. Setzen Sie die Werte trim‑from‑start und trim‑from‑end über [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#setTrimFromStart) und [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#setTrimFromEnd).
5. Speichern Sie die geänderte Präsentation.

Das folgende Codebeispiel überspringt die ersten 2,5 Sekunden und die letzte Sekunde eines eingebetteten Videos während der Wiedergabe:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Trim‑Einstellungen auslesen**

Um vorhandene Trim‑Einstellungen zu prüfen, laden Sie eine Präsentation, finden ein [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/)‑Objekt unter den Formen auf der ersten Folie und lesen die Werte über [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#getTrimFromStart) und [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#getTrimFromEnd).

Das folgende Codebeispiel findet den ersten Videoframe auf der ersten Folie und gibt seine Trim‑Einstellungen in Millisekunden aus:

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

## **Verwalten von Videountertiteln**

Aspose.Slides ermöglicht das Verwalten von Untertiteln für Videoframes in PowerPoint‑Präsentationen. Untertitel werden im WebVTT‑Format gespeichert und über die Methode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#getCaptionTracks) bereitgestellt.

**Untertitel zu einem Videoframe hinzufügen**

So fügen Sie einem Videoframe Untertitel hinzu:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
2. Fügen Sie ein Video zur Präsentation hinzu.
3. Fügen Sie einer Folie ein [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/)‑Objekt hinzu.
4. Verwenden Sie die [CaptionsCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/), die von [getCaptionTracks](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#getCaptionTracks) zurückgegeben wird, um einen WebVTT‑Untertitel‑Track hinzuzufügen.
5. Speichern Sie die geänderte Präsentation.

Der folgende Code zeigt, wie Sie Untertitel zu einem Videoframe hinzufügen:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Füge eine neue Untertitelspur aus einer WebVTT-Datei hinzu.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die Klasse [CaptionsCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/) bietet außerdem eine Überladung, mit der Sie Untertitel aus einem Stream hinzufügen können.

**Untertitel aus einem Videoframe extrahieren**

So extrahieren Sie Untertitel aus einem Videoframe:

1. Laden Sie die Präsentation, die das Video enthält.
2. Suchen Sie das gewünschte [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/)‑Objekt.
3. Durchlaufen Sie die Untertitel‑Tracks in der [CaptionsCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/).
4. Speichern Sie jeden Untertitel‑Track in einer `.vtt`‑Datei.

Der folgende Code zeigt, wie Sie Untertitel aus einem Videoframe extrahieren:

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
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # Speichere die Untertitelspur in einer WebVTT-Datei.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

Jedes [Captions](https://reference.aspose.com/slides/de/python-java/aspose.slides/captions/)‑Objekt stellt die Untertitel‑Kennung, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑Zeichenkette bereit.

**Untertitel aus einem Videoframe entfernen**

So entfernen Sie Untertitel aus einem Videoframe:

1. Laden Sie die Präsentation, die das Video enthält.
2. Holen Sie das gewünschte [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/)‑Objekt.
3. Entfernen Sie Untertitel‑Tracks aus der [CaptionsCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/).
4. Speichern Sie die geänderte Präsentation.

Der folgende Code zeigt, wie Sie alle Untertitel aus einem Videoframe entfernen:

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
        # Entferne alle Untertitel aus dem Video-Frame.
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Falls Sie nur einen Untertitel‑Track entfernen müssen, verwenden Sie die Methoden [remove](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/#remove) oder [removeAt](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/#removeAt) anstelle von [clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/#clear).

## **Video aus Folien extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/), um die Präsentation zu laden, die das Video enthält.
2. Durchlaufen Sie alle [Slide](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/)‑Objekte.
3. Durchlaufen Sie alle [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/)‑Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/) zu finden.
4. Speichern Sie das Video auf dem Datenträger.

Dieses Python‑Beispiel zeigt, wie Sie das Video einer Präsentationsfolie extrahieren:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **FAQ**

**Welche Video‑Wiedergabe‑Parameter können für einen VideoFrame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#setPlayMode) (automatisch oder per Klick) und das [Looping](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#setPlayLoopMode) steuern. Diese Optionen stehen über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/)‑Objekts zur Verfügung.

**Beeinflusst das Hinzufügen eines Videos die Größe der PPTX‑Datei?**

Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Wenn Sie ein Online‑Video hinzufügen, werden nur ein Link und ein Miniaturbild eingebettet, sodass die Größen­zunahme geringer ist.

**Kann ich das Video in einem vorhandenen VideoFrame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Video‑Inhalt](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#setEmbeddedVideo) innerhalb des Frames austauschen, wobei die Geometrie der Form erhalten bleibt; dies ist ein gängiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video verfügt über einen [Content‑Type](https://reference.aspose.com/slides/de/python-java/aspose.slides/video/#getContentType), den Sie auslesen und beispielsweise beim Speichern auf dem Datenträger verwenden können.