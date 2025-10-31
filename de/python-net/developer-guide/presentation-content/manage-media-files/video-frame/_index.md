---
title: Videos zu Präsentationen in Python hinzufügen
linktitle: Videorahmen
type: docs
weight: 10
url: /de/python-net/video-frame/
keywords:
- video hinzufügen
- video erstellen
- video einbetten
- video extrahieren
- video abrufen
- videorahmen
- webquelle
- PowerPoint
- OpenDocument
- präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie programmgesteuert Videoframes in PowerPoint- und OpenDocument‑Folien mithilfe von Aspose.Slides für Python über .NET hinzufügen und extrahieren. Schnell‑Anleitung."
---

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement des Publikums erhöhen. 

PowerPoint ermöglicht das Hinzufügen von Videos zu einer Folie in einer Präsentation auf zwei Arten:

* Lokales Video hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Online‑Video hinzufügen (aus einer Webquelle wie YouTube).

Um Ihnen das Hinzufügen von Videos (Videoobjekten) zu einer Präsentation zu ermöglichen, stellt Aspose.Slides die Schnittstelle [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) , die Schnittstelle [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) und weitere relevante Typen bereit. 

## **Erstelle eingebetteten Videorahmen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Videorahmen erstellen, um das Video in Ihre Präsentation einzubetten. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich über den Index eine Referenz auf die Folie.
3. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/)‑Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video mit der Präsentation einzubetten.
4. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/)‑Objekt hinzu, um einen Rahmen für das Video zu erstellen.  
5. Speichern Sie die geänderte Präsentation. 

Dieser Python‑Code zeigt, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Holt die erste Folie und fügt einen Videorahmen hinzu
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Speichert die Präsentation auf die Festplatte
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Alternativ können Sie ein Video hinzufügen, indem Sie seinen Dateipfad direkt an die Methode `add_video_frame(x, y, width, height, fname)` übergeben:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Erstelle Videorahmen mit Video aus Webquelle**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube‑Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über seinen Web‑Link zu Ihrer Präsentation hinzufügen. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich über den Index eine Referenz auf die Folie.
3. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/)‑Objekt hinzu und übergeben Sie den Link zum Video.
4. Legen Sie ein Thumbnail für den Videorahmen fest.
5. Speichern Sie die Präsentation. 

Dieser Python‑Code zeigt, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint‑Präsentation hinzufügen:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Fügt einen Videorahmen hinzu
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Lädt das Vorschaubild
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Video aus Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse, um die Präsentation zu laden, die das Video enthält. 
2. Durchlaufen Sie alle [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)‑Objekte.
3. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)‑Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) zu finden. 
4. Speichern Sie das Video auf der Festplatte.

Dieser Python‑Code zeigt, wie Sie das Video einer Präsentationsfolie extrahieren:

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

**Welche Videowiedergabeparameter können für einen VideoFrame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (auto oder per Klick) und das [Looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) steuern. Diese Optionen sind über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)‑Objekts verfügbar.

**Hat das Hinzufügen eines Videos Auswirkungen auf die Größe der PPTX‑Datei?**

Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Wenn Sie ein Online‑Video hinzufügen, werden ein Link und ein Thumbnail eingebettet, sodass die Größensteigerung geringer ausfällt.

**Kann ich das Video in einem bestehenden VideoFrame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Videoinhalt](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) innerhalb des Rahmens austauschen, wobei die Geometrie der Form erhalten bleibt; dies ist ein übliches Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video hat einen [Inhaltstyp](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/), den Sie auslesen und beispielsweise beim Speichern auf die Festplatte verwenden können.