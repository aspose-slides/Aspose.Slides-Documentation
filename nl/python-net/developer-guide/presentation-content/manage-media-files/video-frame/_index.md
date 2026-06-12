---
title: Video's toevoegen aan presentaties in Python
linktitle: Videoframe
type: docs
weight: 10
url: /nl/python-net/video-frame/
keywords:
- video toevoegen
- video maken
- video insluiten
- video extraheren
- video ophalen
- video-frame
- webbron
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u programmatisch video-frames kunt toevoegen en extraheren in PowerPoint- en OpenDocument-slides met Aspose.Slides voor Python via .NET. Snelle handleiding."
---
## **Inleiding**

Een goed geplaatste video in een presentatie kan uw boodschap overtuigender maken en het betrokkenheidsniveau van uw publiek verhogen. 

PowerPoint stelt u in staat om video's aan een dia in een presentatie toe te voegen op twee manieren:

* Voeg een lokale video toe of embed deze (opgeslagen op uw computer)
* Voeg een online video toe (van een webbron zoals YouTube).

Om video‑objecten aan een presentatie toe te voegen, biedt Aspose.Slides de [Video](https://reference.aspose.com/slides/nl/python-net/aspose.slides/video/)‑klasse, de [VideoFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/)‑klasse en andere relevante typen. 

## **Ingesloten video‑frame maken**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een video‑frame maken om de video in uw presentatie in te sluiten. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.  
1. Haal de referentie van een dia op via de index.  
1. Voeg een [Video](https://reference.aspose.com/slides/nl/python-net/aspose.slides/video/)‑object toe en geef het pad van het videobestand op om de video in de presentatie in te sluiten.  
1. Voeg een [VideoFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/)‑object toe om een frame voor de video te maken.  
1. Sla de gewijzigde presentatie op.  

Deze Python‑code laat zien hoe u een lokaal opgeslagen video aan een presentatie toevoegt:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Haalt de eerste dia op en voegt een videoframe toe
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Slaat de presentatie op op schijf
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

U kunt ook een video toevoegen door het bestandspad direct door te geven aan de `add_video_frame(x, y, width, height, fname)`‑methode:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Video‑frame maken met video van webbron**

Microsoft [PowerPoint 2013 en nieuwer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) ondersteunt YouTube‑video’s in presentaties. Als de video die u wilt gebruiken online beschikbaar is (bijv. op YouTube), kunt u deze via de web‑link aan uw presentatie toevoegen. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse  
1. Haal de referentie van een dia op via de index.  
1. Voeg een [Video](https://reference.aspose.com/slides/nl/python-net/aspose.slides/video/)‑object toe en geef de koppeling naar de video door.  
1. Stel een miniatuurafbeelding in voor het video‑frame.  
1. Sla de presentatie op.  

Deze Python‑code laat zien hoe u een video van het web aan een dia in een PowerPoint‑presentatie toevoegt:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Voegt een videoFrame toe
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Laadt miniatuurafbeelding
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Video‑bijschriften beheren**

Aspose.Slides stelt u in staat om ondertitels voor video‑frames in PowerPoint‑presentaties te beheren. Ondertitels worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de eigenschap [VideoFrame.caption_tracks](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/caption_tracks/).

**Ondertitels toevoegen aan een video‑frame**

Om ondertitels aan een video‑frame toe te voegen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.  
1. Voeg een video toe aan de presentatie.  
1. Voeg een [VideoFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/)‑object toe aan een dia.  
1. Gebruik de [CaptionsCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/captionscollection/) die wordt geretourneerd door [caption_tracks](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/caption_tracks/) om een WebVTT‑ondertiteltrack toe te voegen.  
1. Sla de gewijzigde presentatie op.  

De volgende code laat zien hoe u ondertitels aan een video‑frame toevoegt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Voegt een nieuw ondertiteltrack toe vanuit een WebVTT‑bestand.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

De [CaptionsCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/captionscollection/)‑klasse biedt ook een overload waarmee u ondertitels vanuit een stream kunt toevoegen.

**Ondertitels extraheren uit een video‑frame**

Om ondertitels uit een video‑frame te extraheren:

1. Laad de presentatie die de video bevat.  
1. Zoek het doel‑[VideoFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/)‑object.  
1. Doorloop de [caption_tracks](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/caption_tracks/)‑collectie.  
1. Sla elke ondertiteltrack op in een `.vtt`‑bestand.  

De volgende code laat zien hoe u ondertitels uit een video‑frame extraheert:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # Slaat het ondertiteltrack op naar een WebVTT-bestand.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

Elk [Captions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/captions/)‑object toont de ondertitel‑identifier, het label, binaire gegevens en de ondertiteltekst als een UTF‑8‑string.

**Ondertitels verwijderen uit een video‑frame**

Om ondertitels uit een video‑frame te verwijderen:

1. Laad de presentatie die de video bevat.  
1. Haal het doel‑[VideoFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/)‑object op.  
1. Verwijder ondertitel‑tracks uit de [CaptionsCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/captionscollection/).  
1. Sla de gewijzigde presentatie op.  

De volgende code laat zien hoe u alle ondertitels uit een video‑frame verwijdert:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # type: slides.VideoFrame

    # Verwijdert alle ondertitels van het video-frame.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Als u slechts één ondertiteltrack moet verwijderen, gebruik dan de [remove](https://reference.aspose.com/slides/nl/python-net/aspose.slides/captionscollection/remove/)‑ of [remove_at](https://reference.aspose.com/slides/nl/python-net/aspose.slides/captionscollection/remove_at/)‑methoden in plaats van [clear](https://reference.aspose.com/slides/nl/python-net/aspose.slides/captionscollection/clear/).

## **Video extraheren uit dia**

Naast het toevoegen van video’s aan dia’s, stelt Aspose.Slides u in staat om video’s die in presentaties zijn ingebed te extraheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse om de presentatie met de video te laden.  
2. Doorloop alle [Slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/)‑objecten.  
3. Doorloop alle [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/)‑objecten om een [VideoFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/) te vinden.  
4. Sla de video op op schijf.  

Deze Python‑code laat zien hoe u de video op een presentatiedia extraheert:

```python
import aspose.slides as slides

# Instantieert een Presentation-object dat een presentatiebestand vertegenwoordigt
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **FAQ**

**Welke videoweergave‑parameters kunnen worden gewijzigd voor een VideoFrame?**

U kunt de [playback mode](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/play_mode/) (automatisch of bij klik) en [looping](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/play_loop_mode/) regelen. Deze opties zijn beschikbaar via de eigenschappen van het [VideoFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/)‑object.

**Heeft het toevoegen van een video invloed op de bestandsgrootte van de PPTX?**

Ja. Wanneer u een lokale video embedt, worden de binaire gegevens in het document opgenomen, waardoor de presentatiegrootte evenredig met de bestandsgrootte toeneemt. Wanneer u een online video toevoegt, worden een koppeling en een miniatuurafbeelding ingebed, waardoor de toename van de grootte kleiner is.

**Kan ik de video in een bestaand VideoFrame vervangen zonder de positie en grootte te wijzigen?**

Ja. U kunt de [video content](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/embedded_video/) binnen het frame verwisselen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het content‑type (MIME) van een embedded video worden bepaald?**

Ja. Een ingesloten video heeft een [content type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/video/content_type/) die u kunt lezen en gebruiken, bijvoorbeeld bij het opslaan op schijf.