---
title: Video Frame
type: docs
weight: 10
url: /python-net/video-frame/
keywords: "Video hinzufügen, Video-Frame erstellen, Video extrahieren, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Video-Frame zu PowerPoint-Präsentation in Python hinzufügen"
---

Ein gut platzierter Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement Ihres Publikums erhöhen.

PowerPoint ermöglicht es Ihnen, Videos auf eine Folie in einer Präsentation auf zwei Arten hinzuzufügen:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Ein Online-Video hinzufügen (von einer Webquelle wie YouTube).

Um Ihnen das Hinzufügen von Videos (Videoobjekten) zu einer Präsentation zu ermöglichen, bietet Aspose.Slides die [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) Schnittstelle, die [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) Schnittstelle und andere relevante Typen.

## **Eingebetteten Video-Frame erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video-Frame erstellen, um das Video in Ihre Präsentation einzubetten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) Objekt hinzu und übergeben Sie den Pfad der Videodatei, um das Video mit der Präsentation einzubetten.
1. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) Objekt hinzu, um einen Rahmen für das Video zu erstellen.
1. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Holt die erste Folie und fügt einen Video-Frame hinzu
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Speichert die Präsentation auf der Festplatte
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Alternativ können Sie ein Video hinzufügen, indem Sie den Pfad zur Datei direkt an die Methode `add_video_frame(x, y, width, height, fname)` übergeben:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Video-Frame mit Video aus Webquelle erstellen**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube-Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über seinen Weblink zu Ihrer Präsentation hinzufügen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) Objekt hinzu und übergeben Sie den Link zum Video.
1. Setzen Sie ein Thumbnail für den Video-Frame.
1. Speichern Sie die Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint-Präsentation hinzufügen:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Fügt einen Video-Frame hinzu
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Lädt Thumbnail
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())

with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Video von Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides auch das Extrahieren von Videos, die in Präsentationen eingebettet sind.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse, um die Präsentation zu laden, die das Video enthält.
2. Durchlaufen Sie alle [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) Objekte.
3. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) Objekte, um einen [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) zu finden.
4. Speichern Sie das Video auf der Festplatte.

Dieser Python-Code zeigt Ihnen, wie Sie das Video auf einer Präsentationsfolie extrahieren:

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