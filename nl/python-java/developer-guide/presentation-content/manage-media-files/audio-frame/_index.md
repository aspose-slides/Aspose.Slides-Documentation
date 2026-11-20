---
title: Beheer audioframes in presentaties met Python
linktitle: Audioframe
type: docs
weight: 10
url: /nl/python-java/audio-frame/
keywords:
- audio
- audioframe
- miniatuur
- audio toevoegen
- audio-eigenschappen
- audio-opties
- audio extraheren
- Python
- Aspose.Slides
description: "Audio insluiten in dia's, het audio‑icoon wijzigen, afspelen configureren, WebVTT‑bijschriften beheren en overgangsgeluiden van dia's extraheren met Aspose.Slides for Python via Java."
---
## **Overzicht**

Een audioframe stelt je in staat een geluid af te spelen op een dia. Met Aspose.Slides for Python via Java kun je een audioclip insluiten, de afbeelding kiezen die het vertegenwoordigt, de weergave aanpassen en ondertitels toevoegen. Je kunt ook een geluid ophalen dat aan een dia‑overgang is toegewezen.

## **Audioframes maken**

Voeg de bytes van `audio.wav` toe aan de audio‑collectie van de presentatie en gebruik vervolgens [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) om een lokaal audioclip in te sluiten op de eerste dia. De eerste twee coördinaten plaatsen het frame op de dia, en de volgende twee waarden stellen de breedte en hoogte in, allemaal in points. Dit voorbeeld roept [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) aan om het clip automatisch te starten en roept [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) aan om het volumepreset “luid” te selecteren.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audio)

    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
    audio_frame.setVolume(AudioVolumeMode.Loud)

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Miniatuur van audioframe wijzigen**

Standaard toont een audioframe een luidspreker‑icoon. Om een aangepaste miniatuur weer te geven, voeg je een afbeelding toe aan de presentatie met [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage), en stel je deze in op de afbeelding van het frame met [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage). Het voorbeeld gebruikt een JPEG als miniatuur voor een ingesloten audioclip.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audio)

    image = Images.fromFile("eagle.jpeg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    audio_frame.getPictureFormat().getPicture().setImage(picture)

    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Audio-afspeelopties wijzigen**

De **Audio‑opties** van PowerPoint bepalen wanneer een clip begint, hoe luid hij is en hoe hij zich tijdens een diavoorstelling gedraagt.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint‑besturing | Aspose.Slides for Python via Java‑methode |
| --- | --- |
| Starten | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| Volume‑preset | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| Afspelen over dia's | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Lussen tot gestopt | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Verbergen tijdens voorstelling | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| Terugspoelen na afspelen | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| Invloeien | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| Uitvloeien | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Audio‑starttijd trimmen | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| Audio‑eindtijd trimmen | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Volumeregelaar | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

Het voorbeeld vindt het eerste audioframe op de eerste dia, roept [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) aan om de weergave te starten bij een klik, en selecteert het lage volumepreset. Het clip blijft over dia's heen afspelen met uitgeschakelde lus. Het pictogram blijft verborgen tijdens de voorstelling, en het clip wordt teruggespoeld na het afspelen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        # Afspelen bij klik met laag volume, over dia's, zonder herhalen.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Verberg het frame tijdens de diavoorstelling en spoel terug na het afspelen.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

Voor een clip langer dan 3,5 seconde slaat dit voorbeeld de eerste 1,5 seconde en de laatste 2 seconden over. [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) neemt de duur die van het einde van de clip moet worden weggelaten. Om de eindtijd te krijgen die in PowerPoint wordt weergegeven, trek je die offset af van de volledige clipduur. Het bijgesneden clip vloeit in gedurende 200 milliseconden en uit gedurende 500 milliseconden. Alle vier de methoden nemen waarden in milliseconden.

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

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Snijd 1,5 seconde af vanaf het begin en 2 seconden af vanaf het einde.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Stel fade-in in op 200 ms en fade-out op 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Om het afspeelvolume op een specifiek percentage in te stellen, gebruik je [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue). Dit voorbeeld stelt het eerste audioframe op de eerste dia in op 85%.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

## **Audio‑bijschriften beheren**

Elk audioframe geeft toegang tot zijn bijschrift‑sporen via [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks). Gebruik de collectie om WebVTT‑bijschriften aan de clip toe te voegen, bestaande sporen te exporteren of ze te verwijderen.

### **Audio‑bijschriften toevoegen**

Het voorbeeld sluit een audioclip in op de eerste dia en gebruikt [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) om een lokaal WebVTT‑spoor toe te voegen. Het eerste argument levert het spoorlabel, en het tweede identificeert het bestand dat de getimede bijschriften bevat.

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

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Voeg een nieuw ondertitelspoor toe vanaf een WebVTT-bestand.
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Audio‑bijschriften extraheren**

Dit voorbeeld exporteert elk bijschriftspoor dat aan een audioframe op de eerste dia is gekoppeld. Het schrijft de bytes die door [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) worden geretourneerd naar een WebVTT‑bestand en gebruikt de identifier die door [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) wordt geretourneerd als bestandsnaam zodat elk spoor een afzonderlijke output heeft.

```python
from pathlib import Path

import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # Bewaar het ondertitelspoor als een .vtt bestand.
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **Audio‑bijschriften verwijderen**

Gebruik [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) of [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) om een individueel spoor te verwijderen. Het voorbeeld gebruikt [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) om alle bijschriften van het eerste audioframe op de eerste dia te verwijderen terwijl de clip behouden blijft.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

### **Een regel in audio‑bijschriften vinden**

Om een regel in de audio‑bijschriften op de eerste dia te vinden, zoek je de tekst die door [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) in het geheugen wordt geretourneerd. In een platte‑tekst WebVTT‑cue bevat de timing‑regel `-->`, de bijschrift‑regels volgen deze, en een lege regel beëindigt de cue. Dit voorbeeld drukt het spoorlabel en elke bijschrift‑regel af die “café” bevat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, AudioFrame):
            continue
        for track in shape.getCaptionTracks():
            in_cue = False
            captions = str(track.getDataAsString())
            for line in captions.splitlines():
                if not line:
                    in_cue = False
                elif "-->" in line:
                    in_cue = True
                elif in_cue and "café" in line.casefold():
                    print(f"{track.getLabel()}: {line}")
finally:
    presentation.dispose()
```

## **Audio extraheren**

Een dia‑overgang kan een eigen geluid hebben. Om dit op te halen, roep je [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound) aan op de dia‑overgang. Het voorbeeld krijgt toegang tot de bytes die door [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) worden geretourneerd en drukt het aantal bytes af. Als de eerste dia geen overgangsgeluid heeft, wordt in plaats daarvan een bericht afgedrukt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print(f"Transition sound: {len(audio_data)} bytes.")
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**Kan ik dezelfde audioclips hergebruiken op meerdere dia's zonder deze te dupliceren?**

Ja. Voeg de clip één keer toe aan de [audio‑collectie](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) van de presentatie en geef hetzelfde audio‑object door aan [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) voor elke dia.

**Kan ik het geluid in een bestaand audioframe vervangen?**

Ja. Voor een gekoppeld geluid gebruik je [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong) om naar het vervangende bestand te wijzen. Voor een ingesloten geluid selecteer je een andere clip uit de audio‑collectie van de presentatie met [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio). Beide benaderingen behouden het bestaande frame.

**Verandert trimmen de audio‑gegevens die in de presentatie zijn opgeslagen?**

Nee. [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) en [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) stellen de afspeelgrenzen in. Je kunt nog steeds de volledige clip ophalen via [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio).