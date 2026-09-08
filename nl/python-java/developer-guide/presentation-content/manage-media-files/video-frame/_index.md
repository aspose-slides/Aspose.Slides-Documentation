---
title: Beheer videoframes in presentaties met Python
linktitle: Video-frame
type: docs
weight: 10
url: /nl/python-java/video-frame/
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
description: "Leer hoe u programmatically video-frames kunt toevoegen en extraheren in PowerPoint- en OpenDocument-slides met Aspose.Slides voor Python via Java. Snelle how-to-gids."
---
## **Inleiding**

Een goed geplaatst video in een presentatie kan uw boodschap overtuigender maken en de betrokkenheid van uw publiek verhogen.

PowerPoint staat u toe video's toe te voegen aan een dia in een presentatie op twee manieren:

* Voeg een lokale video toe of embed deze (opgeslagen op uw machine)
* Voeg een online video toe (van een webbron zoals YouTube).

Om u toe te staan video's (video‑objecten) aan een presentatie toe te voegen, biedt Aspose.Slides de [Video](https://reference.aspose.com/slides/nl/python-java/aspose.slides/video/) klasse, [VideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/) klasse en andere relevante typen.

## **Ingesloten videoframes maken**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een videoframe maken om de video in uw presentatie te embedden.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
2. Haal een referentie naar een dia op via de index.
3. Voeg een [Video](https://reference.aspose.com/slides/nl/python-java/aspose.slides/video/) object toe en geef de videobestandgegevens door om de video in de presentatie te embedden.
4. Voeg een [VideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/) object toe om een frame voor de video te creëren.
5. Sla de gewijzigde presentatie op.

Deze Python‑code laat zien hoe u een lokaal opgeslagen video aan een presentatie toevoegt:

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

U kunt ook een video toevoegen door het bestandspad rechtstreeks door te geven aan de [addVideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addVideoFrame) methode:

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

## **Videoframes maken met video van webbronnen**

Microsoft [PowerPoint 2013 en nieuwer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) ondersteunt YouTube‑video‑s in presentaties. Als de video die u wilt gebruiken online beschikbaar is (bijv. op YouTube), kunt u deze via de web‑link aan uw presentatie toevoegen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse
2. Haal een referentie naar een dia op via de index.
3. Voeg een [VideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/) object toe en geef de link naar de video door.
4. Stel een miniatuurafbeelding in voor het videoframe.
5. Sla de presentatie op.

Deze Python‑code laat zien hoe u een video van het web aan een dia in een PowerPoint‑presentatie toevoegt:

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

## **Een videoframe bijsnijden**

Aspose.Slides stelt u in staat te bepalen welk deel van een video wordt afgespeeld door de trim‑from‑start‑ en trim‑from‑end‑waarden in te stellen via [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#setTrimFromStart) en [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#setTrimFromEnd). Beide waarden worden opgegeven in milliseconden en bepalen hoeveel tijd er respectievelijk aan het begin en einde van de video wordt overgeslagen. Deze instellingen wijzigen de afspeelinstellingen van de video in de presentatie; ze knippen of wijzigen niet de ingesloten videobinaire gegevens.

**Instellingen voor bijsnijden instellen**

Om een videoframe te maken en de bijsnijdinstellingen te definiëren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
2. Voeg een [Video](https://reference.aspose.com/slides/nl/python-java/aspose.slides/video/) object toe aan de presentatie.
3. Voeg een [VideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/) object toe aan een dia.
4. Stel de trim‑from‑start‑ en trim‑from‑end‑waarden in via [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#setTrimFromStart) en [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#setTrimFromEnd).
5. Sla de gewijzigde presentatie op.

De volgende code‑voorbeeld slaat de eerste 2,5 seconde en de laatste seconde van een ingesloten video over tijdens het afspelen:

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

**Bijsnijdinstellingen lezen**

Om bestaande bijsnijdinstellingen te inspecteren, laad een presentatie, zoek een [VideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/) object tussen de vormen op de eerste dia, en lees de waarden via [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#getTrimFromStart) en [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#getTrimFromEnd).

Het volgende code‑voorbeeld vindt het eerste videoframe op de eerste dia en rapporteert de bijsnijdinstellingen in milliseconden:

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

## **Videobijschriften beheren**

Aspose.Slides stelt u in staat gesloten bijschriften voor videoframes in PowerPoint‑presentaties te beheren. Bijschriften worden opgeslagen in WebVTT‑formaat en zijn beschikbaar via de [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#getCaptionTracks) methode.

**Bijschriften toevoegen aan een videoframe**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
2. Voeg een video toe aan de presentatie.
3. Voeg een [VideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/) object toe aan een dia.
4. Gebruik de [CaptionsCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/) die wordt geretourneerd door [getCaptionTracks](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#getCaptionTracks) om een WebVTT‑bijschrifttrack toe te voegen.
5. Sla de gewijzigde presentatie op.

De volgende code laat zien hoe u bijschriften aan een videoframe toevoegt:

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

    # Voeg een nieuw ondertiteltrack toe vanaf een WebVTT bestand.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De [CaptionsCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/) klasse biedt ook een overload waarmee u bijschriften vanuit een stream kunt toevoegen.

**Bijschriften extraheren uit een videoframe**

1. Laad de presentatie die de video bevat.
2. Zoek het doel‑[VideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/) object.
3. Doorloop de bijschrifttracks in de [CaptionsCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/).
4. Sla elke bijschrifttrack op naar een `.vtt`‑bestand.

De volgende code laat zien hoe u bijschriften uit een videoframe kunt extraheren:

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
                # Sla het ondertiteltrack op naar een WebVTT-bestand.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

Elk [Captions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captions/) object geeft de bijschrift‑identifier, het label, de binaire gegevens en de bijschrifttekst weer als een UTF‑8‑string.

**Bijschriften verwijderen uit een videoframe**

1. Laad de presentatie die de video bevat.
2. Haal het doel‑[VideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/) object op.
3. Verwijder bijschrifttracks uit de [CaptionsCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/).
4. Sla de gewijzigde presentatie op.

De volgende code laat zien hoe u alle bijschriften uit een videoframe verwijdert:

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
        # Verwijder alle ondertitels van het videoframe.
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Als u slechts één bijschrifttrack wilt verwijderen, gebruik dan de [remove](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/#remove) of [removeAt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/#removeAt) methoden in plaats van [clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/#clear).

## **Video extraheren van dia's**

Naast het toevoegen van video’s aan dia’s, stelt Aspose.Slides u in staat video’s die in presentaties zijn ingesloten te extraheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse om de presentatie die de video bevat te laden.
2. Doorloop alle [Slide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/) objecten.
3. Doorloop alle [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/) objecten om een [VideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/) te vinden.
4. Sla de video op naar schijf.

Deze Python‑code laat zien hoe u de video op een presentatiedia kunt extraheren:

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

**Welke afspeelparameters kunnen gewijzigd worden voor een VideoFrame?**

U kunt de [playback mode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#setPlayMode) (automatisch of bij klik) en de [looping](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#setPlayLoopMode) regelen. Deze opties zijn beschikbaar via de eigenschappen van het [VideoFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/) object.

**Beïnvloedt het toevoegen van een video de grootte van het PPTX‑bestand?**

Ja. Wanneer u een lokale video embed, worden de binaire gegevens in het document opgenomen, waardoor de presentatiegrootte evenredig toeneemt met de bestandsgrootte. Wanneer u een online video toevoegt, worden een link en een miniatuurafbeelding embed, waardoor de grootte‑toename kleiner is.

**Kan ik de video in een bestaand VideoFrame vervangen zonder de positie en grootte te wijzigen?**

Ja. U kunt de [video content](https://reference.aspose.com/slides/nl/python-java/aspose.slides/videoframe/#setEmbeddedVideo) binnen het frame verwisselen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het inhoudstype (MIME) van een ingesloten video worden bepaald?**

Ja. Een ingesloten video heeft een [content type](https://reference.aspose.com/slides/nl/python-java/aspose.slides/video/#getContentType) die u kunt lezen en gebruiken, bijvoorbeeld bij het opslaan naar schijf.