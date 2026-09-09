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
description: "Erfahren Sie, wie Sie programmgesteuert Video-Frames in PowerPoint- und OpenDocument-Folien mithilfe von Aspose.Slides für Python via Java hinzufügen und extrahieren. Schnelle Anleitungs-Kurzfassung."
---
## **Einführung**

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement‑Level Ihres Publikums erhöhen.

PowerPoint ermöglicht es Ihnen, Videos auf einer Folie in einer Präsentation auf zwei Arten hinzuzufügen:

* Fügen Sie ein lokales Video hinzu oder betten Sie es ein (auf Ihrem Rechner gespeichert)
* Fügen Sie ein Online‑Video hinzu (aus einer Webquelle wie YouTube).

Um Ihnen das Hinzufügen von Videos (Video‑Objekten) zu einer Präsentation zu ermöglichen, stellt Aspose.Slides die Klasse [Video](https://reference.aspose.com/slides/de/python-java/aspose.slides/video/) bereit, die Klasse [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/) und weitere relevante Typen.

## **Erstellen eingebetteter Video‑Frames**

Wenn die Videodatei, die Sie Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) .
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie ein [Video](https://reference.aspose.com/slides/de/python-java/aspose.slides/video/)‑Objekt hinzu und übergeben Sie die Videodateidaten, um das Video in die Präsentation einzubetten.
1. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/)‑Objekt hinzu, um einen Frame für das Video zu erstellen.
1. Speichern Sie die geänderte Präsentation.

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

Alternativ können Sie ein Video hinzufügen, indem Sie dessen Dateipfad direkt an die Methode [addVideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addVideoFrame) übergeben:

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

## **Erstellen von Video‑Frames mit Videos aus Web‑Quellen**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube‑Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über dessen Web‑Link zu Ihrer Präsentation hinzufügen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) .
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/)‑Objekt hinzu und übergeben Sie den Link zum Video.
1. Legen Sie ein Thumbnail für den Video‑Frame fest.
1. Speichern Sie die Präsentation.

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # Lade das Thumbnail.
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

## **Trimmen eines Video‑Frames**

Aspose.Slides ermöglicht es Ihnen, welchen Teil eines Videos Sie abspielen, indem Sie die Werte trim‑from‑start und trim‑from‑end über [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#setTrimFromStart) und [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#setTrimFromEnd) festlegen. Beide Werte werden in Millisekunden angegeben und definieren, wie viel Zeit am Anfang bzw. Ende des Videos übersprungen wird. Diese Einstellungen ändern die Wiedergabe‑Parameter im Video‑Frame der Präsentation; sie schneiden das eingebettete Video‑Binary nicht zu und verändern es nicht.

**Trim‑Einstellungen festlegen**

Um einen Video‑Frame zu erstellen und dessen Trimm‑Einstellungen festzulegen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) .
1. Fügen Sie ein [Video](https://reference.aspose.com/slides/de/python-java/aspose.slides/video/)‑Objekt zur Präsentation hinzu.
1. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/)‑Objekt zu einer Folie hinzu.
1. Setzen Sie die trim‑from‑start‑ und trim‑from‑end‑Werte über [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#setTrimFromStart) und [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#setTrimFromEnd) .
1. Speichern Sie die geänderte Präsentation.

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

Um vorhandene Trimm‑Einstellungen zu prüfen, laden Sie eine Präsentation, finden Sie ein [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/)‑Objekt unter den Shapes auf der ersten Folie und lesen Sie die Werte über [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#getTrimFromStart) und [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#getTrimFromEnd) aus.

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

Aspose.Slides ermöglicht es Ihnen, geschlossene Untertitel für Video‑Frames in PowerPoint‑Präsentationen zu verwalten. Untertitel werden im WebVTT‑Format gespeichert und über die Methode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#getCaptionTracks) bereitgestellt.

**Untertitel zu einem Video‑Frame hinzufügen**

Um Untertitel zu einem Video‑Frame hinzuzufügen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) .
1. Fügen Sie ein Video zur Präsentation hinzu.
1. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/)‑Objekt zu einer Folie hinzu.
1. Verwenden Sie die [CaptionsCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/) , die von [getCaptionTracks](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#getCaptionTracks) zurückgegeben wird, um eine WebVTT‑Untertitelspur hinzuzufügen.
1. Speichern Sie die geänderte Präsentation.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Eine neue Untertitelspur aus einer WebVTT-Datei hinzufügen.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die Klasse [CaptionsCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/) bietet außerdem eine Überladung, mit der Sie Untertitel aus einem Stream hinzufügen können.

**Untertitel aus einem Video‑Frame extrahieren**

Um Untertitel aus einem Video‑Frame zu extrahieren:

1. Laden Sie die Präsentation, die das Video enthält.
1. Finden Sie das Ziel‑[VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/)‑Objekt.
1. Iterieren Sie über die Untertitelspuren in der [CaptionsCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/) .
1. Speichern Sie jede Untertitelspur in einer `.vtt`‑Datei.

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

Jedes [Captions](https://reference.aspose.com/slides/de/python-java/aspose.slides/captions/)‑Objekt stellt die Untertitel‑ID, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑String bereit.

**Untertitel aus einem Video‑Frame entfernen**

Um Untertitel aus einem Video‑Frame zu entfernen:

1. Laden Sie die Präsentation, die das Video enthält.
1. Holen Sie das Ziel‑[VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/)‑Objekt.
1. Entfernen Sie Untertitelspuren aus der [CaptionsCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/) .
1. Speichern Sie die geänderte Präsentation.

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

Wenn Sie nur eine Untertitelspur entfernen möchten, verwenden Sie die Methoden [remove](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/#remove) oder [removeAt](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/#removeAt) anstelle von [clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/#clear).

## **Video aus Folien extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) , um die Präsentation zu laden, die das Video enthält.
2. Iterieren Sie über alle [Slide](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/)‑Objekte.
3. Iterieren Sie über alle [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/)‑Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/) zu finden.
4. Speichern Sie das Video auf dem Datenträger.

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

**Welche Video‑Wiedergabe‑Parameter können für einen Video‑Frame geändert werden?**

Sie können den [playback mode](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#setPlayMode) (automatisch oder per Klick) und das [looping](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#setPlayLoopMode) steuern. Diese Optionen stehen über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/)‑Objekts zur Verfügung.

**Beeinflusst das Hinzufügen eines Videos die Größe der PPTX‑Datei?**

Ja. Beim Einbetten eines lokalen Videos werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Beim Hinzufügen eines Online‑Videos werden lediglich ein Link und ein Thumbnail eingebettet, wodurch die Größensteigerung geringer ist.

**Kann ich das Video in einem bestehenden Video‑Frame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [video content](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/#setEmbeddedVideo) innerhalb des Frames austauschen, während die Geometrie der Shape unverändert bleibt; dies ist ein gängiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Content‑Typ (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video besitzt einen [content type](https://reference.aspose.com/slides/de/python-java/aspose.slides/video/#getContentType), den Sie auslesen und beispielsweise beim Speichern auf dem Datenträger verwenden können.