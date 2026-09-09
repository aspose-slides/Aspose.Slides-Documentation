---
title: Beheer audio in presentaties met Python
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
description: "Maak en beheer audio-frames in Aspose.Slides voor Python via Java—code-voorbeelden om in te sluiten, te trimmen, te laten herhalen en de weergave te configureren in PPT-, PPTX- en ODP-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u met audio‑frames in Aspose.Slides kunt werken. Het laat zien hoe u ingesloten audio aan dia’s kunt toevoegen, de thumbnail van het audio‑frame kunt aanpassen, afspeelopties zoals volume, herhaling, verbergen, trimmen en vervagingstijden kunt configureren, en audio kunt extraheren die wordt gebruikt in dia‑show‑overgangen.

## **Audio-frames maken**

Aspose.Slides voor Python via Java stelt u in staat om audiobestanden aan dia’s toe te voegen. De audiobestanden worden in de dia’s ingebed als audio‑frames. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
2. Haal een referentie naar een dia op basis van de index.
3. Lees het audiobestand dat u in de dia wilt insluiten.
4. Voeg het ingebedde audio‑frame (met het audiobestand) toe aan de dia.
5. Gebruik [setPlayMode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setPlayMode) en [setVolume](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setVolume) die beschikbaar worden gesteld door het [AudioFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/) object.
6. Sla de gewijzigde presentatie op.

Deze Python‑code laat zien hoe u een ingebed audio‑frame aan een dia toevoegt:

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

## **Miniatuur van het audio‑frame wijzigen**

Wanneer u een audiobestand aan een presentatie toevoegt, wordt de audio weergegeven als een frame met een standaard‑standaardafbeelding (zie de afbeelding in de sectie hieronder). U kunt de voorbeeldafbeelding van het audio‑frame wijzigen naar een afbeelding naar keuze.

Deze Python‑code laat zien hoe u de miniatuur of voorbeeldafbeelding van een audio‑frame wijzigt:

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
    audio_data = Path("sample2.mp3").read_bytes()
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

## **Audio‑afspeelopties wijzigen**

Aspose.Slides voor Python via Java maakt het mogelijk om opties die de audio‑afspeelinstellingen of eigenschappen regelen, te wijzigen. U kunt bijvoorbeeld het audiovolume aanpassen, de audio op herhaling instellen of zelfs het audio‑icoon verbergen.

Het **Audio‑opties**‑paneel in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio‑opties** die overeenkomen met de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/)‑eigenschappen:

- **Start** drop‑down lijst komt overeen met de [setPlayMode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setPlayMode)‑methode
- **Volume** komt overeen met de [setVolume](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setVolume)‑methode
- **Play Across Slides** komt overeen met de [setPlayAcrossSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setPlayAcrossSlides)‑methode
- **Loop until Stopped** komt overeen met de [setPlayLoopMode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setPlayLoopMode)‑methode
- **Hide During Show** komt overeen met de [setHideAtShowing](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setHideAtShowing)‑methode
- **Rewind after Playing** komt overeen met de [setRewindAudio](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setRewindAudio)‑methode

PowerPoint **Bewerken**‑opties die overeenkomen met de Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/)‑eigenschappen:

- **Fade In** komt overeen met de [setFadeInDuration](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setFadeInDuration)‑methode 
- **Fade Out** komt overeen met de [setFadeOutDuration](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setFadeOutDuration)‑methode 
- **Trim Audio Start Time** komt overeen met de [setTrimFromStart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setTrimFromStart)‑methode 
- **Trim Audio End Time** waarde is gelijk aan de audioduur min de waarde die is ingesteld door de [setTrimFromEnd](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setTrimFromEnd)‑methode

De PowerPoint **volumeregelaar** op het audio‑bedieningspaneel komt overeen met de [setVolumeValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setVolumeValue)‑methode. Hiermee kunt u het audiovolume als percentage aanpassen.

Zo wijzigt u de audio‑afspeelopties:

1. [Maak](#create-audio-frames) of haal het audio‑frame op.
2. Stel nieuwe waarden in voor de audio‑frame‑eigenschappen die u wilt aanpassen.
3. Sla het gewijzigde PowerPoint‑bestand op.

Deze Python‑code demonstreert een bewerking waarbij audio‑opties worden aangepast:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    audio_frame = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        # Afspelen bij klikken op laag volume, over dia's, zonder herhaling.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Verberg het frame tijdens de diavoorstelling en spoel terug na het afspelen.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

Dit Python‑voorbeeld laat zien hoe u een nieuw audio‑frame met ingesloten audio toevoegt, het trimt en de vervagingstijden instelt:

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
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Trim 1,5 seconden van het begin en 2 seconden van het einde.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Stel fade-in in op 200 ms en fade-out op 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De volgende codevoorbeelden laten zien hoe u een audio‑frame met ingesloten audio ophaalt en het volume instelt op 85%:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Audio‑bijschriften beheren**

Aspose.Slides maakt het mogelijk om gesloten bijschriften aan een audio‑frame toe te voegen via de [getCaptionTracks](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#getCaptionTracks)‑methode. Deze methode retourneert een [CaptionsCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/), waarmee u WebVTT‑bijschrifttracks kunt toevoegen, door bestaande tracks kunt itereren en ze kunt verwijderen wanneer nodig.

**Audio‑bijschriften toevoegen**

Gebruik de [getCaptionTracks](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#getCaptionTracks)‑methode om één of meerdere bijschrifttracks aan een audio‑frame toe te voegen. In het volgende voorbeeld wordt een audiobestand aan een dia toegevoegd en vervolgens wordt een nieuwe bijschrifttrack geladen vanuit een `.vtt`‑bestand.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Voeg een nieuw bijschrifttrack toe vanuit een WebVTT-bestand.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Audio‑bijschriften extraheren**

U kunt door de bijschrifttracks die aan een audio‑frame zijn gekoppeld itereren en ze opslaan als `.vtt`‑bestanden. Elke bijschrifttrack geeft zijn binaire gegevens en unieke identifier vrij, die kunnen worden gebruikt bij het exporteren van bijschriften.

```python
from pathlib import Path

import jpype
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
                # Sla het bijschrifttrack op als een .vtt bestand.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**Audio‑bijschriften verwijderen**

Om bijschriften uit een audio‑frame te verwijderen, gebruikt u de methoden die worden aangeboden door [CaptionsCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/), zoals [clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/#remove) of [removeAt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/#removeAt). Het volgende voorbeeld verwijdert alle bijschrifttracks uit een audio‑frame.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Audio extraheren**

Aspose.Slides voor Python via Java maakt het mogelijk om het geluid dat wordt gebruikt bij dia‑show‑overgangen te extraheren. U kunt bijvoorbeeld het geluid dat in een specifieke dia wordt gebruikt extraheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse en laad de presentatie die de audio bevat.
2. Haal een referentie naar de betreffende dia op basis van de index.
3. Benader de [slideshow transitions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#getSlideShowTransition) van de dia.
4. Extraheer het geluid als byte‑data.

Deze Python‑code laat zien hoe u de audio die in een dia wordt gebruikt, kunt extraheren:

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
        print("Length:", len(audio_data))
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**Kan ik hetzelfde audio‑bestand opnieuw gebruiken op meerdere dia’s zonder de bestandsgrootte op te blazen?**

Ja. Voeg de audio één keer toe aan de gedeelde [audio collection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getAudios) van de presentatie en maak extra audio‑frames aan die naar dat bestaande asset verwijzen. Dit voorkomt dat mediagegevens worden gedupliceerd en houdt de presentatiemaat onder controle.

**Kan ik het geluid in een bestaand audio‑frame vervangen zonder de vorm opnieuw te maken?**

Ja. Voor een gekoppeld geluid werkt u het [link path](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setLinkPathLong) bij zodat deze naar het nieuwe bestand verwijst. Voor een ingebed geluid vervangt u het [embedded audio](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setEmbeddedAudio)‑object door een ander object uit de [audio collection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getAudios) van de presentatie. De opmaak van het frame en de meeste afspeelinstellingen blijven ongewijzigd.

**Verandert trimmen de onderliggende audiogegevens die in de presentatie zijn opgeslagen?**

Nee. Trimmen past alleen de afspeelgrenzen aan. De oorspronkelijke audio‑bytes blijven onaangeroerd en toegankelijk via de ingebedde audio of de [audio collection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getAudios) van de presentatie.