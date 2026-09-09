---
title: Beheer video‑frames in presentaties met Python
linktitle: Video‑frame
type: docs
weight: 10
url: /nl/python-java/video-frame/
keywords:
- video toevoegen
- video maken
- video insluiten
- video extraheren
- video ophalen
- video‑frame
- web‑bron
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer op programmeerwijze video‑frames toe te voegen en te extraheren in PowerPoint‑ en OpenDocument‑dia's met Aspose.Slides voor Python via Java. Snelle how‑to‑gids."
---
## **Inleiding**

Een goed geplaatste video in een presentatie kan je boodschap krachtiger maken en de betrokkenheid van je publiek vergroten.

PowerPoint biedt twee manieren om video's aan een dia toe te voegen:

* Een lokale video (opgeslagen op je computer) toevoegen of insluiten  
* Een online video (van een webbron zoals YouTube) toevoegen.

Om je in staat te stellen video's (videobjecten) aan een presentatie toe te voegen, biedt Aspose.Slides de [Video](https://reference.aspose.com/slides/nl/python-java/aspose.slides/video/)‑klasse, de [VideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/)‑klasse en andere relevante types.

## **Ingesloten video‑frames maken**

Als het videobestand dat je wilt toevoegen lokaal is opgeslagen, kun je een video‑frame maken om de video in je presentatie in te sluiten.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.  
2. Haal een verwijzing op naar een dia via de index.  
3. Voeg een [Video](https://reference.aspose.com/slides/nl/python-java/aspose.slides/video/)‑object toe en geef de videobestand‑gegevens door om de video in de presentatie in te sluiten.  
4. Voeg een [VideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/)‑object toe om een frame voor de video te maken.  
5. Sla de aangepaste presentatie op.

Deze Python‑code laat zien hoe je een lokaal opgeslagen video aan een presentatie toevoegt:

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

Als alternatief kun je een video toevoegen door het bestandspad rechtstreeks door te geven aan de [addVideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addVideoFrame)‑methode:

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

## **Video‑frames maken met video van webbronnen**

Microsoft [PowerPoint 2013 en later](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) ondersteunt YouTube‑video’s in presentaties. Als de video die je wilt gebruiken online beschikbaar is (bijv. op YouTube), kun je deze via de web‑link aan je presentatie toevoegen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.  
2. Haal een verwijzing op naar een dia via de index.  
3. Voeg een [VideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/)‑object toe en geef de link naar de video door.  
4. Stel een miniatuurafbeelding in voor het video‑frame.  
5. Sla de presentatie op.

Deze Python‑code laat zien hoe je een video van het internet aan een dia in een PowerPoint‑presentatie toevoegt:

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

    # Laad de miniatuur.
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

## **Een video‑frame inkorten**

Aspose.Slides stelt je in staat te bepalen welk deel van een video wordt afgespeeld door de waarden *trim‑from‑start* en *trim‑from‑end* in te stellen via [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#setTrimFromStart) en [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#setTrimFromEnd). Beide waarden worden opgegeven in milliseconden en bepalen hoeveel tijd respectievelijk aan het begin en het einde van de video wordt overgeslagen. Deze instellingen wijzigen de afspeelinstellingen in de presentatie; ze knippen of wijzigen de ingebedde video‑binaire data niet.

**Trim‑instellingen definiëren**

Om een video‑frame te maken en de trim‑instellingen in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.  
2. Voeg een [Video](https://reference.aspose.com/slides/nl/python-java/aspose.slides/video/)‑object toe aan de presentatie.  
3. Voeg een [VideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/)‑object toe aan een dia.  
4. Stel de *trim‑from‑start*‑ en *trim‑from‑end*‑waarden in via [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#setTrimFromStart) en [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#setTrimFromEnd).  
5. Sla de aangepaste presentatie op.

De volgende code‑voorbeeld slaat de eerste 2,5 sec. en de laatste seconde van een ingesloten video over tijdens het afspelen:

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

**Trim‑instellingen lezen**

Om bestaande trim‑instellingen te inspecteren, laad je een presentatie, zoek je een [VideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/)‑object onder de shapes op de eerste dia, en lees je de waarden via [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#getTrimFromStart) en [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#getTrimFromEnd).

De volgende code‑voorbeeld vindt het eerste video‑frame op de eerste dia en rapporteert de trim‑instellingen in milliseconden:

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

## **Videocaptions beheren**

Aspose.Slides maakt het mogelijk closed captions voor video‑frames in PowerPoint‑presentaties te beheren. Captions worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#getCaptionTracks)‑methode.

**Captions toevoegen aan een video‑frame**

Om captions toe te voegen aan een video‑frame:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.  
2. Voeg een video toe aan de presentatie.  
3. Voeg een [VideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/)‑object toe aan een dia.  
4. Gebruik de [CaptionsCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/) die wordt geretourneerd door [getCaptionTracks](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#getCaptionTracks) om een WebVTT‑caption‑track toe te voegen.  
5. Sla de aangepaste presentatie op.

De volgende code toont hoe je captions toevoegt aan een video‑frame:

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

    # Voeg een nieuw ondertitelings-track toe vanuit een WebVTT-bestand.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De [CaptionsCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/)‑klasse biedt ook een overload waarmee je captions vanuit een stream kunt toevoegen.

**Captions extraheren uit een video‑frame**

Om captions uit een video‑frame te halen:

1. Laad de presentatie die de video bevat.  
2. Zoek het doel‑[VideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/)‑object.  
3. Loop door de caption‑tracks in de [CaptionsCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/).  
4. Sla elke caption‑track op in een `.vtt`‑bestand.

De volgende code toont hoe je captions uit een video‑frame extrahert:

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
                # Sla het ondertitelings‑track op naar een WebVTT‑bestand.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

Elk [Captions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captions/)‑object geeft de caption‑identifier, label, binaire data en caption‑tekst als een UTF‑8‑string weer.

**Captions verwijderen uit een video‑frame**

Om captions uit een video‑frame te verwijderen:

1. Laad de presentatie die de video bevat.  
2. Haal het doel‑[VideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/)‑object op.  
3. Verwijder caption‑tracks uit de [CaptionsCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/).  
4. Sla de aangepaste presentatie op.

De volgende code laat zien hoe je alle captions uit een video‑frame verwijdert:

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
        # Verwijder alle ondertitels van het video-frame.
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Als je slechts één caption‑track wilt verwijderen, gebruik dan de [remove](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/#remove)‑ of [removeAt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/#removeAt)‑methoden in plaats van [clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/#clear).

## **Video’s extraheren uit dia’s**

Naast het toevoegen van video's aan dia’s maakt Aspose.Slides het mogelijk om video's die in presentaties zijn ingesloten, te extraheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse om de presentatie met de video te laden.  
2. Loop door alle [Slide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/)‑objecten.  
3. Loop door alle [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/)‑objecten om een [VideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/) te vinden.  
4. Sla de video op op schijf.

Deze Python‑code toont hoe je de video van een presentatiedia extraheert:

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

**Welke afspeelparameters kunnen worden aangepast voor een VideoFrame?**

Je kunt de [playback‑mode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#setPlayMode) (automatisch of bij klik) en het [loop‑gedrag](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#setPlayLoopMode) regelen. Deze opties zijn beschikbaar via de eigenschappen van het **VideoFrame**‑object.

**Heeft het toevoegen van een video invloed op de bestandsgrootte van de PPTX?**

Ja. Wanneer je een lokale video insluit, wordt de binaire data in het document opgenomen, waardoor de presentatiegrootte evenredig toeneemt met de bestandsgrootte. Wanneer je een online video toevoegt, worden alleen een link en een miniatuurafbeelding ingesloten, waardoor de omvangstoename kleiner blijft.

**Kan ik de video in een bestaand VideoFrame vervangen zonder de positie en grootte te wijzigen?**

Ja. Je kunt de [video‑content](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#setEmbeddedVideo) binnen het frame verwisselen terwijl je de geometrie van de shape behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaand layout.

**Kan het content‑type (MIME) van een ingesloten video worden bepaald?**

Ja. Een ingesloten video heeft een [content‑type](https://reference.aspose.com/slides/nl/python-java/aspose.slides/video/#getContentType) dat je kunt uitlezen en gebruiken, bijvoorbeeld bij het opslaan op schijf.