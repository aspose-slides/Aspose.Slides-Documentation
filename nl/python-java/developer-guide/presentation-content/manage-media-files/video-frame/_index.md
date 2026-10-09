---
title: Beheer videoframes in presentaties met Python
linktitle: Videoframe
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
description: "Leer programmatisch video-frames toe te voegen en te extraheren in PowerPoint- en OpenDocument-dia's met Aspose.Slides voor Python via Java. Snelle handleiding."
---
## **Inleiding**

Video's kunnen helpen om ideeën uit te leggen en een publiek te boeien. Aspose.Slides for Python via Java stelt je in staat videoframes aan dia's toe te voegen, afspeelinstellingen aan te passen, bijschriften te beheren en ingebedde videogegevens te extraheren.

PowerPoint ondersteunt lokale video’s en koppelingen naar online video’s, zoals YouTube‑video’s.

Om videogegevens en videoframes te vertegenwoordigen, biedt Aspose.Slides de klasse [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) , de klasse [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) en andere relevante types.

## **Maak een ingebedde videoframe**

Als het videobestand dat je aan je dia wilt toevoegen lokaal is opgeslagen, kun je een videoframe maken om de video in je presentatie in te sluiten.

Dit voorbeeld voegt een lokale video toe aan de eerste dia van een bestaande presentatie en slaat het resultaat op. Frame‑coördinaten en afmetingen zijn in points. Python leest de video‑bytes van de schijf, en JPype zet ze om naar een Java‑byte‑array voordat de video aan de presentatie wordt toegevoegd.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video)

    presentation.save("embedded_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Je kunt ook een lokaal videopad rechtstreeks doorgeven aan [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). Dit voorbeeld voegt de video toe aan de eerste dia van een nieuwe presentatie. De video moet toegankelijk blijven totdat de presentatie is opgeslagen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Maak een videoframe met video van een webbron**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ondersteunt online video’s in presentaties. Je kunt een videoframe maken dat koppelt naar een online video, bijvoorbeeld een YouTube‑video.

Dit voorbeeld voegt een YouTube‑videolink en miniatuur toe aan de eerste dia. Vervang de video‑identifier om een andere video te gebruiken. De methode [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) vraagt om automatisch afspelen. Het downloaden van de miniatuur en het afspelen van de video vereisen internettoegang. De presentatie‑viewer moet ook online video‑afspelen ondersteunen.

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_id = "aqz-KE-bpKQ"
    video_url = "https://www.youtube.com/embed/" + video_id
    video_frame = slide.getShapes().addVideoFrame(10, 10, 427, 240, video_url)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    thumbnail_url = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
    thumbnail = presentation.getImages().addImage(java_thumbnail_data)
    video_frame.getPictureFormat().getPicture().setImage(thumbnail)

    presentation.save("online_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Speel een video in volledig scherm**

In een trainingspresentatie kun je een software‑demo in volledig scherm afspelen zodat het publiek de details kan zien. Roep [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) aan met `True` om dit gedrag tijdens het afspelen in te schakelen.

Dit voorbeeld opent een presentatie, vindt de eerste [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) op de eerste dia, en schakelt volledig‑scherm‑afspelen in. De invoer‑presentatie moet minimaal één dia bevatten met een bestaand videoframe op de eerste dia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setFullScreenMode(True)
            break

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Volledig‑scherm‑afspelen bepaalt hoe de video wordt weergegeven. Onafhankelijk daarvan regelt [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) of deze automatisch of bij klikken start, en [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) bepaalt of deze herhaalt. Om het startgedrag te kiezen, stel je de afspeelmodus in op [VideoPlayModePreset.Auto of VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). Het voorbeeld behoudt de bestaande start‑ en lussinstellingen.

## **Terugspoelen van een video na afspelen**

In een trainingspresentatie maakt het terugspoelen van een demonstratie‑video naar het begin het klaar voor de presentator om opnieuw af te spelen. Roep [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) aan met `True` om de video na afloop van het afspelen naar het begin te retourneren.

Dit voorbeeld opent een presentatie, vindt de eerste [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) op de eerste dia, en schakelt terugspoelen in. Het schakelt de lus uit zodat het afspelen kan eindigen en stelt het afspelen in om bij klikken te starten. De invoer‑presentatie moet minimaal één dia bevatten met een bestaand videoframe op de eerste dia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame, VideoPlayModePreset

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setRewindVideo(True)
            shape.setPlayLoopMode(False)
            shape.setPlayMode(VideoPlayModePreset.OnClick)
            break

    presentation.save("rewind_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Terugspoelen zet de video terug naar het begin zonder deze opnieuw te starten. In tegenstelling tot het aanroepen van [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) met `True`, die het afspelen automatisch herhaalt. Houd de lus uitgeschakeld wanneer je wilt dat de video klaar is om opnieuw afgespeeld te worden. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) regelt onafhankelijk of het automatisch of bij klikken start; dit voorbeeld gebruikt [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) zodat de presentator bepaalt wanneer het afspelen start. Stel de afspeelmodus in na de lusinstelling, zoals in het voorbeeld getoond. Terugspoelen werkt onafhankelijk van [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Trimmen van een videoframe**

Gebruik [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) en [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) om het begin‑ of einddeel van een video over te slaan tijdens het afspelen. Beide waarden staan in milliseconden. Trimmen wijzigt afspeelinstellingen zonder de ingebedde videogegevens te wijzigen.

**Triminstellingen instellen**

Dit voorbeeld voegt een lokale video in en slaat de eerste 2,5 seconden en de laatste seconde over tijdens het afspelen. Gebruik een video langer dan 3,5 seconden zodat er een speelbaar segment overblijft.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Triminstellingen lezen**

Dit voorbeeld drukt de trim‑waarden van het eerste videoframe op de eerste dia af in milliseconden. De presentatie moet minimaal één dia bevatten. Als die dia geen videoframe heeft, wordt er niets afgedrukt. Het voorgaande voorbeeld levert waarden van 2500 en 1000.

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

## **Beheer videobijschriften**

Aspose.Slides maakt het mogelijk om closed captions voor videoframes in PowerPoint‑presentaties te beheren. Bijschriften worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de methode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks).

**Bijschriften toevoegen aan een videoframe**

Dit voorbeeld voegt een lokale video in en voegt een WebVTT‑bijschrifttrack met het label English toe. De tijdstempels van de bijschriften moeten overeenkomen met de video. De opgeslagen presentatie bevat zowel de video als de bijschriften.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Voeg een nieuw ondertiteltrack toe vanaf een WebVTT‑bestand.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De klasse [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) biedt ook een overload waarmee je bijschriften uit een stream kunt toevoegen.

**Bijschriften extraheren uit een videoframe**

Dit voorbeeld slaat alle bijschrifttracks van videoframes op de eerste dia op als afzonderlijke WebVTT‑bestanden. Sequentiële nummers houden de uitvoerbestanden gescheiden. De console meldt het aantal geëxtraheerde tracks. De presentatie moet minimaal één dia bevatten.

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

    track_count = 0
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                track_count += 1
                output_path = Path(f"captions_{track_count}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                output_path.write_bytes(caption_data)

    print(f"Caption tracks extracted: {track_count}")
finally:
    presentation.dispose()
```

Elk [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/)‑object geeft de bijschrift‑identifier, het label, binaire data en de bijschrifttekst als UTF‑8‑string weer.

**Bijschriften verwijderen uit een videoframe**

Dit voorbeeld verwijdert alle bijschriften van het videoframe op de eerste vorm‑positie op de eerste dia en slaat het resultaat op. Het gaat ervan uit dat de dia en vorm bestaan en dat de vorm een videoframe is.

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
        # Verwijder alle bijschriften van het videoframe.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Als je slechts één bijschrifttrack wilt verwijderen, gebruik dan de methoden [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) of [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) in plaats van [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

## **Video uit een dia extraheren**

Naast het toevoegen van video’s aan dia’s, maakt Aspose.Slides het mogelijk om video’s die in presentaties zijn ingebed te extraheren.

Dit voorbeeld extrahert ingebedde video’s van elke dia naar afzonderlijke, genummerde binaire bestanden. Gelinkte video’s worden overgeslagen omdat ze geen ingebedde data bevatten. De console drukt het MIME‑type van elke video en het totaal aantal af. De uitvoer gebruikt de algemene extensie `.bin`; wijzig deze naar het gerapporteerde mediatype indien nodig.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("presentation_with_videos.pptx")
try:
    video_count = 0
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = Path(f"extracted_video_{video_count}.bin")
                video_data = bytes(video.getBinaryData())
                output_path.write_bytes(video_data)
                print(f"Video {video_count}: {video.getContentType()}")

    print(f"Embedded videos extracted: {video_count}")
finally:
    presentation.dispose()
```

## **FAQ**

**Welke afspeelparameters van een video kunnen worden gewijzigd voor een videoframe?**

Je kunt de [afspeelmodus](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (auto of bij klik) en het [herhalen](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) aanpassen. Deze opties zijn beschikbaar via de methoden van het object [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/).

**Heeft het toevoegen van een video invloed op de grootte van het PPTX‑bestand?**

Ja. Wanneer je een lokale video inbedt, wordt de binaire data in het document opgenomen, zodat de presentatie‑grootte evenredig stijgt met de bestandsgrootte. Wanneer je naar een online video linkt en een miniatuur toevoegt, slaat de presentatie alleen de link en de preview‑afbeelding op in plaats van de videogegevens, waardoor de toename meestal kleiner is.

**Kan ik de video in een bestaand videoframe vervangen zonder de positie en grootte te wijzigen?**

Ja. Je kunt de [videoinhoud](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) binnen het frame verwisselen terwijl je de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het contenttype (MIME) van een ingebedde video worden bepaald?**

Ja. Een ingebedde video heeft een [contenttype](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) dat je kunt uitlezen en gebruiken, bijvoorbeeld bij het opslaan naar schijf.