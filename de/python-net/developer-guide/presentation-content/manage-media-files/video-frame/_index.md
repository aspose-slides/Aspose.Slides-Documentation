---
title: Videos zu Präsentationen in Python hinzufügen
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
description: "Lernen Sie, wie Sie programmgesteuert Video‑Frames in PowerPoint‑ und OpenDocument‑Folien mit Aspose.Slides für Python via .NET hinzufügen und extrahieren. Schnelle Anleitung."
---
Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement Ihres Publikums steigern. 

PowerPoint ermöglicht es Ihnen, Videos in einer Folie einer Präsentation auf zwei Arten hinzuzufügen:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Ein Online-Video hinzufügen (aus einer Web-Quelle wie YouTube). 

Um Ihnen das Hinzufügen von Videos (Video-Objekten) zu einer Präsentation zu ermöglichen, stellt Aspose.Slides die Klasse [Video](https://reference.aspose.com/slides/de/python-net/aspose.slides/video/) bereit, die Klasse [VideoFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/) und weitere relevante Typen. 

## **Eingebetteten Video‑Frame erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
1. Holen Sie sich die Referenz einer Folie über deren Index. 
1. Fügen Sie ein [Video](https://reference.aspose.com/slides/de/python-net/aspose.slides/video/)-Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten. 
1. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/)-Objekt hinzu, um einen Frame für das Video zu erstellen.  
1. Speichern Sie die geänderte Präsentation. 

Dieser Python-Code zeigt Ihnen, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Holt die erste Folie und fügt einen Videoframe hinzu
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Speichert die Präsentation auf dem Datenträger
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Alternativ können Sie ein Video hinzufügen, indem Sie dessen Dateipfad direkt an die Methode `add_video_frame(x, y, width, height, fname)` übergeben:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Video‑Frame mit Video aus Web‑Quelle erstellen**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube-Videos in Präsentationen. Wenn das von Ihnen zu verwendende Video online verfügbar ist (z. B. auf YouTube), können Sie es über dessen Web-Link Ihrer Präsentation hinzufügen. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
1. Holen Sie sich die Referenz einer Folie über deren Index. 
1. Fügen Sie ein [Video](https://reference.aspose.com/slides/de/python-net/aspose.slides/video/)-Objekt hinzu und übergeben Sie den Link zum Video.
1. Legen Sie ein Thumbnail für den Video‑Frame fest. 
1. Speichern Sie die Präsentation. 

Dieser Python-Code zeigt Ihnen, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint-Präsentation hinzufügen:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Fügt einen videoFrame hinzu
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Lädt das Thumbnail
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Video‑Untertitel verwalten**

Aspose.Slides ermöglicht Ihnen das Verwalten von Untertiteln für Video‑Frames in PowerPoint‑Präsentationen. Untertitel werden im WebVTT-Format gespeichert und über die Eigenschaft [VideoFrame.caption_tracks](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/caption_tracks/) bereitgestellt.

**Untertitel zu einem Video‑Frame hinzufügen**

Um Untertitel zu einem Video‑Frame hinzuzufügen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
1. Fügen Sie der Präsentation ein Video hinzu.
1. Fügen Sie einer Folie ein [VideoFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/)-Objekt hinzu.
1. Verwenden Sie die [CaptionsCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/captionscollection/) , die von [caption_tracks](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/caption_tracks/) zurückgegeben wird, um eine WebVTT-Untertitelspur hinzuzufügen.
1. Speichern Sie die geänderte Präsentation.

Der folgende Code zeigt Ihnen, wie Sie Untertitel zu einem Video‑Frame hinzufügen:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Fügt eine neue Untertitelspur aus einer WebVTT-Datei hinzu.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

Die Klasse [CaptionsCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/captionscollection/) bietet zudem eine Überladung, mit der Sie Untertitel aus einem Stream hinzufügen können.

**Untertitel aus einem Video‑Frame extrahieren**

Um Untertitel aus einem Video‑Frame zu extrahieren:

1. Laden Sie die Präsentation, die das Video enthält.
1. Finden Sie das Ziel‑[VideoFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/)-Objekt.
1. Durchlaufen Sie die Sammlung [caption_tracks](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/caption_tracks/).
1. Speichern Sie jede Untertitelspur in einer `.vtt`‑Datei.

Der folgende Code zeigt Ihnen, wie Sie Untertitel aus einem Video‑Frame extrahieren:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # Speichert die Untertitelspur in einer WebVTT-Datei.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

Jedes [Captions](https://reference.aspose.com/slides/de/python-net/aspose.slides/captions/)-Objekt stellt die Untertitel‑Kennung, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑String bereit.

**Untertitel aus einem Video‑Frame entfernen**

Um Untertitel aus einem Video‑Frame zu entfernen:

1. Laden Sie die Präsentation, die das Video enthält.
1. Holen Sie das Ziel‑[VideoFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/)-Objekt.
1. Entfernen Sie Untertitelspuren aus der [CaptionsCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/captionscollection/).
1. Speichern Sie die geänderte Präsentation.

Der folgende Code zeigt Ihnen, wie Sie alle Untertitel aus einem Video‑Frame entfernen:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # Typ: slides.VideoFrame

    # Entfernt alle Untertitel aus dem Video‑Frame.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Wenn Sie nur eine Untertitelspur entfernen müssen, verwenden Sie die Methoden [remove](https://reference.aspose.com/slides/de/python-net/aspose.slides/captionscollection/remove/) oder [remove_at](https://reference.aspose.com/slides/de/python-net/aspose.slides/captionscollection/remove_at/), anstelle von [clear](https://reference.aspose.com/slides/de/python-net/aspose.slides/captionscollection/clear/).

## **Video aus Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/), um die Präsentation zu laden, die das Video enthält. 
2. Durchlaufen Sie alle [Slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/)-Objekte.
3. Durchlaufen Sie alle [Shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/)-Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/) zu finden. 
4. Speichern Sie das Video auf dem Datenträger.

Dieser Python-Code zeigt Ihnen, wie Sie das Video einer Präsentationsfolie extrahieren:

```python
import aspose.slides as slides

# Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **FAQ**

**Welche Videowiedergabe-Parameter können für einen Video‑Frame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/play_mode/) (automatisch oder bei Klick) und das [Looping](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/play_loop_mode/) steuern. Diese Optionen stehen über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/)-Objekts zur Verfügung.

**Beeinflusst das Hinzufügen eines Videos die PPTX-Dateigröße?**

Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Größe der Präsentation proportional zur Dateigröße wächst. Wenn Sie ein Online-Video hinzufügen, werden ein Link und ein Thumbnail eingebettet, sodass die Größenzunahme geringer ist.

**Kann ich das Video in einem bestehenden Video‑Frame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Videoinhalt](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/embedded_video/) im Frame austauschen, während Sie die Geometrie der Form beibehalten; dies ist ein häufiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video hat einen [content type](https://reference.aspose.com/slides/de/python-net/aspose.slides/video/content_type/), den Sie auslesen und beispielsweise beim Speichern auf dem Datenträger verwenden können.