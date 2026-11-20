---
title: Video-frames beheren in presentaties met Python
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
- video-frame
- webbron
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u programmatisch video-frames kunt toevoegen en extraheren in PowerPoint- en OpenDocument-dia's met Aspose.Slides voor Python via Java. Snelle stapsgewijze handleiding."
---
## **Inleiding**

Video's kunnen helpen ideeën uit te leggen en een publiek te betrekken. Aspose.Slides voor Python via Java stelt u in staat videoframes toe te voegen aan dia's, afspeelinstellingen aan te passen, ondertitels te beheren en ingebedde videogegevens te extraheren.

PowerPoint ondersteunt lokale video's en koppelingen naar online video's, zoals YouTube-video's.

Om video-gegevens en videoframes te vertegenwoordigen, biedt Aspose.Slides de klasse [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) klasse, de klasse [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) klasse, en andere relevante typen.

## **Maak een ingesloten video-frame**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een video-frame maken om de video in uw presentatie in te sluiten.

Dit voorbeeld sluit een lokale video in op de eerste dia van een bestaande presentatie en slaat het resultaat op. Frame‑coördinaten en afmetingen zijn in punten. Python leest de videobytes van de schijf, en JPype zet ze om naar een Java‑byte‑array voordat de video aan de presentatie wordt toegevoegd.

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

U kunt ook een lokaal video‑pad direct doorgeven aan [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). Dit voorbeeld sluit de video in op de eerste dia van een nieuwe presentatie. De video moet toegankelijk blijven tot de presentatie is opgeslagen.

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

## **Maak een video-frame met video van een webbron**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ondersteunt online video's in presentaties. U kunt een video-frame maken dat naar een online video linkt, zoals een YouTube-video.

Dit voorbeeld voegt een YouTube‑videolink en miniatuur toe aan de eerste dia. Vervang de video‑identifier om een andere video te gebruiken. De methode [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) vraagt om automatische afspelen. Het downloaden van de miniatuur en het afspelen van de video vereisen internettoegang. De presentatieweergave moet ook online video‑afspelen ondersteunen.

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

## **Video afspelen in volledig scherm modus**

In een trainingspresentatie kunt u een software‑demonstratie in volledig scherm afspelen zodat het publiek de details kan zien. Roep [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) aan met `True` om dit gedrag tijdens het afspelen in te schakelen.

Dit voorbeeld opent een presentatie, zoekt het eerste [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) op de eerste dia, en schakelt volledig‑scherm afspelen in. De invoerpresentatie moet minstens één dia bevatten met een bestaand video‑frame op de eerste dia.

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

Volledig‑scherm afspelen bepaalt hoe de video wordt weergegeven. Onafhankelijk daarvan bepaalt [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) of deze automatisch of bij klik start, en [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) of deze herhaalt. Om het startgedrag te kiezen, stelt u de afspeelmodus in op [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). Het voorbeeld behoudt de bestaande start‑ en lusinstellingen.

## **Video terugspoelen na afspelen**

In een trainingspresentatie maakt het terugspoelen van een demonstratievideo naar het begin deze klaar voor de presentator om opnieuw af te spelen. Roep [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) aan met `True` om de video na afloop van het afspelen naar het begin terug te brengen.

Dit voorbeeld opent een presentatie, zoekt het eerste [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) op de eerste dia, en schakelt terugspoelen in. Het schakelt lus uit zodat afspelen kan eindigen en stelt afspelen in op starten bij klik. De invoerpresentatie moet minstens één dia bevatten met een bestaand video‑frame op de eerste dia.

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

Terugspoelen brengt de video naar het begin zonder deze opnieuw te starten. Daarentegen herhaalt het aanroepen van [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) met `True` het afspelen automatisch. Houd de lus uitgeschakeld wanneer u wilt dat de video voltooid wordt en klaar blijft om opnieuw af te spelen. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) regelt onafhankelijk automatisch of bij‑klik starten; dit voorbeeld gebruikt [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) zodat de presentator bepaalt wanneer het afspelen start. Stel de afspeelmodus in na de lusinstelling, zoals getoond in het voorbeeld. Terugspoelen werkt onafhankelijk van [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Een video-frame bijsnijden**

Gebruik [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) en [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) om het begin‑ of einde‑deel van een video over te slaan tijdens het afspelen. Beide waarden zijn in milliseconden. Bijsnijden wijzigt afspeelinstellingen zonder de ingebedde video‑gegevens te wijzigen.

**Triminstellingen instellen**

Dit voorbeeld sluit een lokale video in en slaat de eerste 2,5 seconde en de laatste seconde over tijdens het afspelen. Gebruik een video langer dan 3,5 seconde zodat er een afspeelbaar segment overblijft.

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

Dit voorbeeld drukt de trimwaarden van het eerste video‑frame op de eerste dia af in milliseconden. De presentatie moet minstens één dia bevatten. Als die dia geen video‑frame heeft, wordt niets afgedrukt. Het voorgaande voorbeeld levert waarden van 2500 en 1000.

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

## **Beheer van video-bijschriften**

Aspose.Slides stelt u in staat gesloten ondertitels voor video‑frames in PowerPoint‑presentaties te beheren. Bijschriften worden opgeslagen in WebVTT‑formaat en worden blootgesteld via de methode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks).

### **Bijschriften toevoegen aan een video-frame**

Dit voorbeeld sluit een lokale video in en voegt een WebVTT‑bijschrifttrack toe getiteld English. De bijschrift‑tijdstempels moeten overeenkomen met de video. De opgeslagen presentatie bevat zowel de video als de bijschriften.

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

    # Voeg een nieuwe ondertiteltrack toe vanuit een WebVTT‑bestand.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De klasse [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) biedt ook een overload waarmee u bijschriften uit een stream kunt toevoegen.

### **Bijschriften uit een video-frame extraheren**

Dit voorbeeld slaat alle bijschrifttracks van video‑frames op de eerste dia op als afzonderlijke WebVTT‑bestanden. Aaneengesloten nummers houden de uitvoerbestanden distinct. De console rapporteert het aantal geëxtraheerde tracks. De presentatie moet minstens één dia bevatten.

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

Elk [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) object maakt het bijschrift‑identifier, label, binaire gegevens en de bijschrifttekst als een UTF‑8‑string beschikbaar.

### **Bijschriften verwijderen uit een video-frame**

Dit voorbeeld verwijdert alle bijschriften uit het video‑frame op de eerste vormpositie op de eerste dia en slaat het resultaat op. Het gaat ervan uit dat de dia en vorm bestaan en dat de vorm een video‑frame is.

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

Als u slechts één bijschrifttrack wilt verwijderen, gebruik dan de methoden [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) of [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) in plaats van [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

### **Zoeken in video-bijschriften**

[Captions.getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) retourneert de volledige WebVTT‑track, inclusief header, timing‑regels en bijschrifttekst. U kunt de bijschriften in het geheugen doorzoeken om een frase en tijdstempel te vinden. Bijvoorbeeld, een Engelse track op dia 2 kan de volgende tekst bevatten.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Dit voorbeeld opent `captioned_media.pptx` en gebruikt [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) om de tracks van elk top‑level video‑frame op elke dia te lezen. In een platte‑tekst cue bevat de timing‑regel `-->`, en een lege regel beëindigt de cue. Voor elk bijschrift dat “café” bevat, ongeacht hoofdlettergebruik, drukt het voorbeeld het dia‑nummer, track‑label, originele timing‑regel en volledige bijschrift af.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("captioned_media.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, VideoFrame):
                continue
            for track in shape.getCaptionTracks():
                track_text = str(track.getDataAsString())
                lines = iter(track_text.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue
                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)
                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.getSlideNumber()} | {track.getLabel()} | {timing}")
                        print(caption)
finally:
    presentation.dispose()
```

Zoeken naar “café” levert één overeenkomst op voor de voorbeeldtrack. De zoekopdracht sluit de track‑header uit en behoudt de timing‑instelling en regeleindes in de uitvoer.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Video uit een dia extraheren**

Naast het toevoegen van video’s aan dia’s, maakt Aspose.Slides het mogelijk video’s die in presentaties zijn ingebed te extraheren.

Dit voorbeeld extraheren ingebedde video’s van elke dia naar afzonderlijke, genummerde binaire bestanden. Gekoppelde video’s worden overgeslagen omdat ze geen ingebedde gegevens hebben. De console drukt het MIME‑type van elke video en het totale aantal af. Uitvoer gebruikt de generieke `.bin`‑extensie; wijzig deze om overeen te komen met het gerapporteerde mediatype indien nodig.

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

**Welke afspeelparameters voor video‑frames kunnen worden aangepast?**

U kunt de [afspeelmodus](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (auto of bij klik) en de [lus](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) regelen. Deze opties zijn beschikbaar via de methoden van het [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) object.

**Heeft het toevoegen van een video invloed op de grootte van het PPTX‑bestand?**

Ja. Wanneer u een lokale video insluit, worden de binaire gegevens in het document opgenomen, waardoor de presentatiegrootte evenredig toeneemt met de bestandsgrootte. Wanneer u linkt naar een online video en een miniatuur toevoegt, slaat de presentatie de link en preview‑afbeelding op in plaats van de videogegevens, waardoor de toename meestal kleiner is.

**Kan ik de video in een bestaand video‑frame vervangen zonder positie en grootte te wijzigen?**

Ja. U kunt de [videoinhoud](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) binnen het frame verwisselen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het content‑type (MIME) van een ingebedde video worden bepaald?**

Ja. Een ingebedde video heeft een [content‑type](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) dat u kunt lezen en gebruiken, bijvoorbeeld bij het opslaan naar schijf.