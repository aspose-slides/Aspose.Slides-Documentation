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
description: "Erfahren Sie, wie Sie programmgesteuert Video-Frames in PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Python via .NET hinzufügen und extrahieren. Schnellguide."
---
## **Einführung**

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement Ihres Publikums steigern. 

PowerPoint ermöglicht das Hinzufügen von Videos zu einer Folie in einer Präsentation auf zwei Arten:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Ein Online-Video hinzufügen (aus einer Webquelle wie YouTube).

Um Ihnen das Hinzufügen von Videos (Videoobjekten) zu einer Präsentation zu ermöglichen, stellt Aspose.Slides die Klasse [Video](https://reference.aspose.com/slides/de/python-net/aspose.slides/video/) , die Klasse [VideoFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/) und weitere relevante Typen bereit. 

## **Erstellen eines eingebetteten Video-Frames**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video-Frame erstellen, um das Video in Ihre Präsentation einzubetten. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) .
1. Holen Sie die Referenz einer Folie über deren Index. 
1. Fügen Sie ein [Video](https://reference.aspose.com/slides/de/python-net/aspose.slides/video/) -Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten. 
1. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/) -Objekt hinzu, um einen Frame für das Video zu erstellen.  
1. Speichern Sie die geänderte Präsentation. 

Dieses Python‑Beispiel zeigt, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:

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


## **Video-Frame mit Video aus einer Webquelle erstellen**

Neuere Versionen von Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) unterstützen Online‑Videos in Präsentationen. Wenn das von Ihnen gewünschte Video online verfügbar ist (z. B. auf YouTube), können Sie es über dessen Weblink zu Ihrer Präsentation hinzufügen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) .
1. Holen Sie die Referenz einer Folie über deren Index. 
1. Fügen Sie ein [Video](https://reference.aspose.com/slides/de/python-net/aspose.slides/video/) -Objekt hinzu und übergeben Sie den Link zum Video.
1. Setzen Sie ein Vorschaubild für den Video-Frame. 
1. Speichern Sie die Präsentation. 

Dieses Python‑Beispiel zeigt, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint‑Präsentation hinzufügen:

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

## **Video-Frame zuschneiden**

Aspose.Slides ermöglicht es, den abgespielten Teil eines Videos zu steuern, indem die Werte trim-from-start und trim-from-end über [VideoFrame.trim_from_start](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/trim_from_start/) und [VideoFrame.trim_from_end](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/trim_from_end/) gesetzt werden. Beide Werte werden in Millisekunden angegeben und bestimmen, wie viel Zeit am Anfang bzw. Ende des Videos übersprungen wird. Diese Einstellungen ändern die Wiedergabeeigenschaften des Videos in der Präsentation; sie schneiden das eingebettete Videomaterial nicht zu oder verändern die binären Daten nicht.

**Trim‑Einstellungen festlegen**

Um einen Video-Frame zu erstellen und dessen Trim‑Einstellungen festzulegen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) .
1. Fügen Sie ein [Video](https://reference.aspose.com/slides/de/python-net/aspose.slides/video/) -Objekt zur Präsentation hinzu.
1. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/) -Objekt zu einer Folie hinzu.
1. Setzen Sie die Werte trim-from-start und trim-from-end über [VideoFrame.trim_from_start](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/trim_from_start/) und [VideoFrame.trim_from_end](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/trim_from_end/) .
1. Speichern Sie die geänderte Präsentation.

Das folgende Code‑Beispiel lässt die ersten 2,5 Sekunden und die letzte Sekunde eines eingebetteten Videos während der Wiedergabe aus:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)

    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Trim‑Einstellungen auslesen**

Um vorhandene Trim‑Einstellungen zu prüfen, laden Sie eine Präsentation, finden ein [VideoFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/) -Objekt unter den Formen der ersten Folie und lesen die Werte über [VideoFrame.trim_from_start](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/trim_from_start/) und [VideoFrame.trim_from_end](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/trim_from_end/) aus.

Das folgende Code‑Beispiel findet den ersten Video‑Frame auf der ersten Folie und gibt dessen Trim‑Einstellungen in Millisekunden aus:

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            video_frame = shape
            trim_from_start = video_frame.trim_from_start
            trim_from_end = video_frame.trim_from_end

            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
```

## **Video-Untertitel verwalten**

Aspose.Slides ermöglicht das Verwalten von Untertiteln für Video‑Frames in PowerPoint‑Präsentationen. Untertitel werden im WebVTT‑Format gespeichert und über die Eigenschaft [VideoFrame.caption_tracks](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/caption_tracks/) bereitgestellt.

**Untertitel zu einem Video-Frame hinzufügen**

Um Untertitel zu einem Video‑Frame hinzuzufügen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) .
1. Fügen Sie der Präsentation ein Video hinzu.
1. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/) -Objekt zu einer Folie hinzu.
1. Verwenden Sie die von [caption_tracks](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/caption_tracks/) zurückgegebene [CaptionsCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/captionscollection/) , um einen WebVTT‑Untertitel‑Track hinzuzufügen.
1. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel zeigt, wie Sie Untertitel zu einem Video‑Frame hinzufügen:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Fügt einen neuen Untertitel-Track aus einer WebVTT-Datei hinzu.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

Die Klasse [CaptionsCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/captionscollection/) bietet zudem eine Überladung, mit der Sie Untertitel aus einem Stream hinzufügen können.

**Untertitel aus einem Video-Frame extrahieren**

Um Untertitel aus einem Video‑Frame zu extrahieren:

1. Laden Sie die Präsentation, die das Video enthält.
1. Finden Sie das Ziel‑[VideoFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/) -Objekt.
1. Durchlaufen Sie die Sammlung [caption_tracks](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/caption_tracks/) .
1. Speichern Sie jeden Untertitel‑Track in einer `.vtt`‑Datei.

Das folgende Beispiel zeigt, wie Sie Untertitel aus einem Video‑Frame extrahieren:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # Speichert den Untertitel-Track in einer WebVTT-Datei.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

Jedes [Captions](https://reference.aspose.com/slides/de/python-net/aspose.slides/captions/) -Objekt stellt die Untertitel‑Kennung, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑String bereit.

**Untertitel von einem Video-Frame entfernen**

Um Untertitel von einem Video‑Frame zu entfernen:

1. Laden Sie die Präsentation, die das Video enthält.
1. Holen Sie das Ziel‑[VideoFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/) -Objekt.
1. Entfernen Sie Untertitel‑Tracks aus der [CaptionsCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/captionscollection/) .
1. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel zeigt, wie Sie alle Untertitel von einem Video‑Frame entfernen:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # type: slides.VideoFrame

    # Entfernt alle Untertitel vom Video-Frame.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Wenn Sie nur einen Untertitel‑Track entfernen müssen, verwenden Sie die Methoden [remove](https://reference.aspose.com/slides/de/python-net/aspose.slides/captionscollection/remove/) oder [remove_at](https://reference.aspose.com/slides/de/python-net/aspose.slides/captionscollection/remove_at/) anstelle von [clear](https://reference.aspose.com/slides/de/python-net/aspose.slides/captionscollection/clear/) .

## **Video aus Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) , um die Präsentation mit dem Video zu laden. 
1. Durchlaufen Sie alle [Slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/) -Objekte.
1. Durchlaufen Sie alle [Shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/) -Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/) zu finden. 
1. Speichern Sie das Video auf dem Datenträger.

Dieses Python‑Beispiel zeigt, wie Sie das Video einer Präsentationsfolie extrahieren:

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

**Welche Videowiedergabeparameter können für einen Video-Frame geändert werden?**

Sie können den [playback mode](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/play_mode/) (automatisch oder bei Klick) und das [looping](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/play_loop_mode/) steuern. Diese Optionen sind über die Eigenschaften des [VideoFrame]‑Objekts verfügbar.

**Hat das Hinzufügen eines Videos Einfluss auf die PPTX-Dateigröße?**

Ja. Beim Einbetten eines lokalen Videos werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Beim Hinzufügen eines Online‑Videos werden ein Link und ein Vorschaubild eingebettet, sodass die Größenzunahme geringer ist.

**Kann ich das Video in einem bestehenden Video-Frame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [video content](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/embedded_video/) im Frame austauschen, während die Geometrie der Form erhalten bleibt; dies ist ein gängiges Szenario, um Medien in einem bestehenden Layout zu aktualisieren.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video hat einen [content type](https://reference.aspose.com/slides/de/python-net/aspose.slides/video/content_type/) , den Sie auslesen und beispielsweise beim Speichern auf die Festplatte verwenden können.