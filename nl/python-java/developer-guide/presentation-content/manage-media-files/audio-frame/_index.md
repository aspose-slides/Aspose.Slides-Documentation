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
description: "Maak en beheer audioframes in Aspose.Slides voor Python via Java—codevoorbeelden om audio in te sluiten, bij te snijden, te herhalen en afspelen te configureren in PPT-, PPTX- en ODP-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u met audio‑frames in Aspose.Slides kunt werken. Het laat zien hoe u ingebedde audio aan dia's kunt toevoegen, de miniatuur van het audioframe kunt aanpassen, afspeelopties zoals volume, herhaling, verbergen, bijsnijden en fade‑tijden kunt configureren, en audio die wordt gebruikt bij diavoorstelling‑overgangen kunt extraheren.

## **Audioframes maken**

Aspose.Slides voor Python via Java stelt u in staat om audiobestanden aan dia's toe te voegen. De audiobestanden worden in dia's ingebed als audio‑frames. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
2. Haal een referentie naar een dia op via de index.
3. lees het audiobestand dat u in de dia wilt insluiten.
4. Voeg het ingebedde audioframe (dat het audiobestand bevat) toe aan de dia.
5. Stel [setPlayMode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setPlayMode) en [setVolume](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setVolume) in die beschikbaar zijn via het [AudioFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/)‑object.
6. Sla de gewijzigde presentatie op.

Deze Python‑code toont hoe u een ingebed audioframe aan een dia kunt toevoegen:

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

Wanneer u een audiobestand aan een presentatie toevoegt, verschijnt de audio als een frame met een standaard afbeeldingsvoorbeeld (zie de afbeelding in de sectie hieronder). U kunt de voorbeeldafbeelding van het audioframe wijzigen (stelt uw gewenste afbeelding in).

Deze Python‑code toont hoe u de miniatuur of voorbeeldafbeelding van een audioframe kunt wijzigen:

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

Aspose.Slides voor Python via Java stelt u in staat om opties te wijzigen die de weergave of eigenschappen van audio regelen. U kunt bijvoorbeeld het volume van de audio aanpassen, de audio in een lus afspelen, of zelfs het audio‑icoon verbergen.

De **Audio‑opties**‑pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio‑opties** die overeenkomen met Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/)‑eigenschappen:

- **Start** vervolgkeuzelijst komt overeen met de [setPlayMode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setPlayMode)‑methode
- **Volume** komt overeen met de [setVolume](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setVolume)‑methode
- **Afspelen over dia's** komt overeen met de [setPlayAcrossSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setPlayAcrossSlides)‑methode
- **Lus tot gestopt** komt overeen met de [setPlayLoopMode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setPlayLoopMode)‑methode
- **Verbergen tijdens diavoorstelling** komt overeen met de [setHideAtShowing](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setHideAtShowing)‑methode
- **Terugspoelen na afspelen** komt overeen met de [setRewindAudio](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setRewindAudio)‑methode

PowerPoint **Bewerken**‑opties die overeenkomen met de eigenschappen van Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/)‑object:

- **Fade in** komt overeen met de [setFadeInDuration](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setFadeInDuration)‑methode 
- **Fade out** komt overeen met de [setFadeOutDuration](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setFadeOutDuration)‑methode 
- **Audio‑begintijd bijsnijden** komt overeen met de [setTrimFromStart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setTrimFromStart)‑methode 
- **Audio‑eindtijd bijsnijden** is gelijk aan de audioduur min de waarde van de [setTrimFromEnd](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setTrimFromEnd)‑methode

De PowerPoint **volumeregelaar** op het audio‑bedieningspaneel komt overeen met de [setVolumeValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setVolumeValue)‑methode. Hiermee kunt u het audio‑volume aanpassen als een percentage.

Zo wijzigt u de audio‑afspeelopties:

1. [Maken](#create-audio-frames) of haal het audioframe op.
2. Stel nieuwe waarden in voor de audioframe‑eigenschappen die u wilt aanpassen.
3. Sla het aangepaste PowerPoint‑bestand op.

Deze Python‑code demonstreert een bewerking waarbij de opties van een audio worden aangepast:

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
        # Afspelen bij klik op laag volume, over dia's, zonder herhalen.
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

Dit Python‑voorbeeld laat zien hoe u een nieuw audioframe met ingebedde audio toevoegt, het bijsnijdt en de fade‑tijden instelt:

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

    # Snij 1,5 seconde van het begin af en 2 seconden van het einde.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Stel fade-in in op 200 ms en fade-out op 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De volgende codevoorbeelden tonen hoe u een audioframe met ingebedde audio ophaalt en het volume op 85 % zet:

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

Aspose.Slides stelt u in staat om gesloten ondertitels aan een audioframe toe te voegen via de [getCaptionTracks](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#getCaptionTracks)‑methode. Deze methode retourneert een [CaptionsCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/), waarmee u WebVTT‑bijschrift‑tracks kunt toevoegen, door bestaande tracks kunt itereren en ze kunt verwijderen indien nodig.

**Audio‑bijschriften toevoegen**

Gebruik de [getCaptionTracks](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#getCaptionTracks)‑methode om één of meer bijschrift‑tracks aan een audioframe te koppelen. In het volgende voorbeeld wordt een audiobestand aan een dia toegevoegd en vervolgens wordt een nieuwe bijschrift‑track geladen vanuit een `.vtt`‑bestand.

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

    # Voeg een nieuw bijschrifttrack toe vanuit een WebVTT‑bestand.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Audio‑bijschriften extraheren**

U kunt door de bijschrift‑tracks die aan een audioframe zijn gekoppeld itereren en ze opslaan als `.vtt`‑bestanden. Elke bijschrift‑track geeft zijn binaire gegevens en unieke identifier vrij, die bij het exporteren van bijschriften gebruikt kan worden.

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
                # Sla het bijschrifttrack op als een .vtt-bestand.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**Audio‑bijschriften verwijderen**

Om bijschriften van een audioframe te verwijderen, gebruikt u de methoden die beschikbaar zijn in [CaptionsCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/), zoals [clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/#remove) of [removeAt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/captionscollection/#removeAt). Het volgende voorbeeld verwijdert alle bijschrift‑tracks van een audioframe.

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

Aspose.Slides voor Python via Java stelt u in staat om het geluid dat wordt gebruikt bij diavoorstelling‑overgangen te extraheren. U kunt bijvoorbeeld het geluid uit een specifieke dia extraheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse en laad de presentatie die de audio bevat.
2. Haal de referentie naar de betreffende dia op via de index.
3. Open de [slideshow transitions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#getSlideShowTransition)‑overgangen voor de dia.
4. Extraheer het geluid als byte‑gegevens.

Deze Python‑code toont hoe u het audio‑bestand dat in een dia wordt gebruikt, kunt extraheren:

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

**Kan ik hetzelfde audio‑bestand hergebruiken op meerdere dia’s zonder de bestandsgrootte te laten toenemen?**

Ja. Voeg de audio één keer toe aan de gedeelde [audio collection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getAudios) van de presentatie en maak extra audioframes die naar dat bestaande onderdeel verwijzen. Dit voorkomt duplicatie van mediagegevens en houdt de presentatiegrootte onder controle.

**Kan ik het geluid in een bestaand audioframe vervangen zonder de vorm opnieuw te maken?**

Ja. Voor een gelinkt geluid werkt u het [link path](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setLinkPathLong) bij zodat het naar het nieuwe bestand wijst. Voor een ingebed geluid vervangt u het [embedded audio](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audioframe/#setEmbeddedAudio)‑object door een ander uit de [audio collection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getAudios) van de presentatie. De opmaak van het frame en de meeste afspeelinstellingen blijven onveranderd.

**Verandert bijsnijden de onderliggende audio‑gegevens die in de presentatie zijn opgeslagen?**

Nee. Bijsnijden wijzigt alleen de afspeelgrenzen. De oorspronkelijke audio‑bytes blijven onaangeroerd en zijn toegankelijk via de ingebedde audio of de audio‑collectie van de presentatie.