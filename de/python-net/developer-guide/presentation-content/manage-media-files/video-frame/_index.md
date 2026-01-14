---
title: Videos zu Präsentationen in Python hinzufügen
linktitle: Video-Frame
type: docs
weight: 10
url: /de/python-net/video-frame/
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
description: "Lernen Sie, wie Sie programmgesteuert Video-Frames in PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Python via .NET hinzufügen und extrahieren. Schnelle Anleitung."
---

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und die Engagement‑Werte bei Ihrem Publikum erhöhen. 

PowerPoint ermöglicht das Hinzufügen von Videos zu einer Folie in einer Präsentation auf zwei Arten:

* Video lokal hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Online‑Video hinzufügen (von einer Web‑Quelle wie YouTube).

Um Ihnen das Hinzufügen von Videos (Video‑Objekten) zu einer Präsentation zu ermöglichen, stellt Aspose.Slides die Klasse [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) , die Klasse [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) und weitere relevante Typen bereit. 

## **Einbetten eines Video‑Frames erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Holen Sie die Referenz einer Folie über deren Index. 
1. Fügen Sie ein [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/)-Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten. 
1. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)-Objekt hinzu, um einen Rahmen für das Video zu erstellen.  
1. Speichern Sie die modifizierte Präsentation. 

Dieser Python‑Code zeigt, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:
```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Holt die erste Folie und fügt einen Video-Frame hinzu
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

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube‑Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über dessen Web‑Link zu Ihrer Präsentation hinzufügen. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Holen Sie die Referenz einer Folie über deren Index. 
1. Fügen Sie ein [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/)-Objekt hinzu und übergeben Sie den Link zum Video.
1. Legen Sie ein Miniaturbild für den Video‑Frame fest. 
1. Speichern Sie die Präsentation. 

Dieser Python‑Code zeigt, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint‑Präsentation hinzufügen:
```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Fügt einen Video-Frame hinzu
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

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) , um die Präsentation zu laden, die das Video enthält. 
2. Iterieren Sie über alle [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/)-Objekte.
3. Iterieren Sie über alle [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)-Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) zu finden. 
4. Speichern Sie das Video auf dem Datenträger.

Dieser Python‑Code zeigt, wie Sie das Video auf einer Präsentationsfolie extrahieren:
```python
import aspose.slides as slides

# Erstellt ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```


## **FAQ**

**Welche Wiedergabe‑Parameter können für einen VideoFrame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (automatisch oder bei Klick) und das [Schleifen](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) steuern. Diese Optionen stehen über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)-Objekts zur Verfügung.

**Beeinflusst das Hinzufügen eines Videos die Größe der PPTX‑Datei?**

Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Wenn Sie ein Online‑Video hinzufügen, werden nur ein Link und ein Miniaturbild eingebettet, sodass die Größenzunahme geringer ist.

**Kann ich das Video in einem bestehenden VideoFrame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Video‑Inhalt](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) im Frame austauschen, während Sie die Geometrie der Form beibehalten; dies ist ein übliches Szenario zum Aktualisieren von Medien in einem vorhandenen Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video hat einen [Inhaltstyp](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/), den Sie auslesen und verwenden können, zum Beispiel beim Speichern auf dem Datenträger.