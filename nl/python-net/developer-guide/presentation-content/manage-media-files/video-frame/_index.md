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
- videoframe
- webbron
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u programmatisch videoframes kunt toevoegen en extraheren in PowerPoint- en OpenDocument-dia's met Aspose.Slides voor Python via .NET. Snelle stapsgewijze handleiding."
---
## **Introductie**

Een goed geplaatste video in een presentatie kan uw boodschap krachtiger maken en het betrokkenheidsniveau van uw publiek verhogen. 

PowerPoint stelt u in staat om video's toe te voegen aan een dia in een presentatie op twee manieren:

* Voeg een lokale video toe of embed deze (opgeslagen op uw computer)
* Voeg een online video toe (van een webbron zoals YouTube).

Om u in staat te stellen video's (video‑objecten) toe te voegen aan een presentatie, biedt Aspose.Slides de klasse [Video](https://reference.aspose.com/slides/nl/python-net/aspose.slides/video/) , de klasse [VideoFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/) en andere relevante types. 

## **Ingebedde videoframe maken**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een videoframe maken om de video in uw presentatie in te sluiten. 

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) aan.  
2. Verkrijg een referentie naar een dia via de index.  
3. Voeg een [Video](https://reference.aspose.com/slides/nl/python-net/aspose.slides/video/) object toe en geef het pad naar het videobestand op om de video in de presentatie in te sluiten.  
4. Voeg een [VideoFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/) object toe om een frame voor de video te maken.  
5. Sla de gewijzigde presentatie op.  

Deze Python‑code laat zien hoe u een lokaal opgeslagen video aan een presentatie toevoegt:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Haalt de eerste dia op en voegt een videoframe toe
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Slaat de presentatie op schijf
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

U kunt ook een video toevoegen door het bestandspad rechtstreeks door te geven aan de `add_video_frame(x, y, width, height, fname)`‑methode:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **Videoframe maken met video van webbron**

Nieuwere versies van Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) ondersteunen online video's in presentaties. Als de video die u wilt gebruiken online beschikbaar is (bijv. op YouTube), kunt u deze via de webkoppeling aan uw presentatie toevoegen.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) aan.  
2. Verkrijg een referentie naar een dia via de index.  
3. Voeg een [Video](https://reference.aspose.com/slides/nl/python-net/aspose.slides/video/) object toe en geef de koppeling naar de video door.  
4. Stel een miniatuurafbeelding in voor het videoframe.  
5. Sla de presentatie op.  

Deze Python‑code laat zien hoe u een video van het web toevoegt aan een dia in een PowerPoint‑presentatie:

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

## **Trim van een videoframe**

Aspose.Slides stelt u in staat om te bepalen welk deel van een video wordt afgespeeld door de trim‑from‑start‑ en trim‑from‑end‑waarden in te stellen via [VideoFrame.trim_from_start](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/trim_from_start/) en [VideoFrame.trim_from_end](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/trim_from_end/). Beide waarden worden gespecificeerd in milliseconden en geven aan hoeveel tijd er respectievelijk aan het begin en einde van de video wordt overgeslagen. Deze instellingen wijzigen de afspeelinstellingen van de video in de presentatie; ze knippen of wijzigen niet de ingebedde videobinaire gegevens.

**Trim‑instellingen instellen**

Om een videoframe te maken en de trim‑instellingen te configureren:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) aan.  
2. Voeg een [Video](https://reference.aspose.com/slides/nl/python-net/aspose.slides/video/) object toe aan de presentatie.  
3. Voeg een [VideoFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/) object toe aan een dia.  
4. Stel de trim‑from‑start‑ en trim‑from‑end‑waarden in via [VideoFrame.trim_from_start](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/trim_from_start/) en [VideoFrame.trim_from_end](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/trim_from_end/).  
5. Sla de gewijzigde presentatie op.  

De volgende code‑example slaat de eerste 2,5 s en de laatste seconde van een ingebedde video over tijdens het afspelen:

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

**Trim‑instellingen lezen**

Om bestaande trim‑instellingen te inspecteren, laad een presentatie, vind een [VideoFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/) object onder de shapes op de eerste dia, en lees de waarden via [VideoFrame.trim_from_start](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/trim_from_start/) en [VideoFrame.trim_from_end](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/trim_from_end/).

De volgende code‑example vindt het eerste videoframe op de eerste dia en rapporteert de trim‑instellingen in milliseconden:

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

## **Beheer video‑ondertitels**

Aspose.Slides stelt u in staat om closed captions voor videoframes in PowerPoint‑presentaties te beheren. Ondertitels worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de eigenschap [VideoFrame.caption_tracks](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/caption_tracks/).

**Ondertitels toevoegen aan een videoframe**

Om ondertitels toe te voegen aan een videoframe:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) aan.  
2. Voeg een video toe aan de presentatie.  
3. Voeg een [VideoFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/) object toe aan een dia.  
4. Gebruik de [CaptionsCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/captionscollection/) die wordt geretourneerd door [caption_tracks](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/caption_tracks/) om een WebVTT‑ondertiteltrack toe te voegen.  
5. Sla de gewijzigde presentatie op.  

De volgende code toont hoe u ondertitels toevoegt aan een videoframe:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Voegt een nieuw ondertiteltrack toe vanuit een WebVTT-bestand.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

De class [CaptionsCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/captionscollection/) biedt ook een overload waarmee u ondertitels vanuit een stream kunt toevoegen.

**Ondertitels extraheren uit een videoframe**

Om ondertitels uit een videoframe te extraheren:

1. Laad de presentatie die de video bevat.  
2. Zoek het doel‑[VideoFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/) object.  
3. Doorloop de collectie [caption_tracks](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/caption_tracks/).  
4. Sla elke ondertiteltrack op in een `.vtt`‑bestand.  

De volgende code toont hoe u ondertitels uit een videoframe extraheert:

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

Elk [Captions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/captions/) object geeft de ondertitel‑identifier, het label, de binaire data en de ondertiteltekst als UTF‑8‑string weer.

**Ondertitels verwijderen uit een videoframe**

Om ondertitels uit een videoframe te verwijderen:

1. Laad de presentatie die de video bevat.  
2. Verkrijg het doel‑[VideoFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/) object.  
3. Verwijder ondertiteltracks uit de [CaptionsCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/captionscollection/).  
4. Sla de gewijzigde presentatie op.  

De volgende code toont hoe u alle ondertitels uit een videoframe verwijdert:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # type: slides.VideoFrame

    # Verwijdert alle ondertitels van het videoframe.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Als u slechts één ondertiteltrack wilt verwijderen, gebruik dan de methoden [remove](https://reference.aspose.com/slides/nl/python-net/aspose.slides/captionscollection/remove/) of [remove_at](https://reference.aspose.com/slides/nl/python-net/aspose.slides/captionscollection/remove_at/) in plaats van [clear](https://reference.aspose.com/slides/nl/python-net/aspose.slides/captionscollection/clear/).

## **Video extraheren van dia**

Naast het toevoegen van video’s aan dia’s, maakt Aspose.Slides het mogelijk om video’s die in presentaties zijn ingebed te extraheren.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) om de presentatie die de video bevat te laden.  
2. Doorloop alle [Slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/) objecten.  
3. Doorloop alle [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/) objecten om een [VideoFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/) te vinden.  
4. Sla de video op schijf.  

Deze Python‑code laat zien hoe u de video van een presentatiedia extrahert:

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

**Welke afspeelparameters kunnen voor een VideoFrame worden aangepast?**

U kunt de [playback‑mode](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/play_mode/) (auto of bij klik) en de [loop‑instelling](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/play_loop_mode/) bepalen. Deze opties zijn beschikbaar via de eigenschappen van het [VideoFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/) object.

**Beïnvloedt het toevoegen van een video de bestandsgrootte van de PPTX?**

Ja. Wanneer u een lokale video embedt, worden de binaire gegevens in het document opgenomen, waardoor de presentatiegrootte evenredig toeneemt met de bestandsgrootte. Wanneer u een online video toevoegt, worden alleen een koppeling en een miniatuurafbeelding ingesloten, waardoor de grootte‑toename kleiner blijft.

**Kan ik de video in een bestaand VideoFrame vervangen zonder positie en grootte te wijzigen?**

Ja. U kunt de [video‑content](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/embedded_video/) binnen het frame verwisselen terwijl u de geometrie van de shape behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het content‑type (MIME) van een ingebedde video worden bepaald?**

Ja. Een ingebedde video heeft een [content‑type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/video/content_type/) dat u kunt uitlezen en gebruiken, bijvoorbeeld bij het opslaan op schijf.