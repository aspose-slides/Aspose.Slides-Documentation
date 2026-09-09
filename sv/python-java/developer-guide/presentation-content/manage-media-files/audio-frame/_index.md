---
title: Hantera ljud i presentationer med Python
linktitle: Ljudram
type: docs
weight: 10
url: /sv/python-java/audio-frame/
keywords:
- ljud
- ljudram
- miniatyr
- lägg till ljud
- ljudegenskaper
- ljudalternativ
- extrahera ljud
- Python
- Aspose.Slides
description: "Skapa och kontrollera ljudramar i Aspose.Slides för Python via Java—kodexempel för att bädda in, trimma, loopa och konfigurera uppspelning i PPT-, PPTX- och ODP-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med ljudramar i Aspose.Slides. Den visar hur man lägger till inbäddat ljud till bilder, anpassar ljudramens miniatyr, konfigurerar uppspelningsalternativ såsom volym, loopning, döljning, trimning och toningslängder, samt extraherar ljud som används i bildspelsövergångar.

## **Skapa ljudramar**

Aspose.Slides för Python via Java låter dig lägga till ljudfiler till bilder. Ljudfilerna bäddas in i bilder som ljudramar. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Hämta en referens till en bild med dess index.
3. Läs in ljudfilen som du vill bädda in i bilden.
4. Lägg till den inbäddade ljudramen (som innehåller ljudfilen) på bilden.
5. Använd [setPlayMode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#setPlayMode) och [setVolume](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#setVolume) som exponeras av objektet [AudioFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/).
6. Spara den modifierade presentationen.

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

## **Ändra ljudramens miniatyr**

När du lägger till en ljudfil i en presentation visas ljudet som en ram med en standardstandardbild (se bilden i avsnittet nedan). Du kan ändra ljudramens förhandsbild till en bild du själv väljer.

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

## **Ändra uppspelningsalternativ för ljud**

Aspose.Slides för Python via Java låter dig ändra alternativ som styr ljuduppspelning eller egenskaper. Till exempel kan du justera ljudvolymen, ställa in att ljudet ska loopas eller till och med dölja ljudikonen.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** som motsvarar Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/) egenskaper:

- **Start** rullgardinslistan matchar metoden [setPlayMode]
- **Volume** matchar metoden [setVolume]
- **Play Across Slides** matchar metoden [setPlayAcrossSlides]
- **Loop until Stopped** matchar metoden [setPlayLoopMode]
- **Hide During Show** matchar metoden [setHideAtShowing]
- **Rewind after Playing** matchar metoden [setRewindAudio]

PowerPoint **Editing** alternativ som motsvarar Aspose.Slides [AudioFrame] egenskaper:

- **Fade In** matchar metoden [setFadeInDuration] 
- **Fade Out** matchar metoden [setFadeOutDuration] 
- **Trim Audio Start Time** matchar metoden [setTrimFromStart] 
- **Trim Audio End Time** värdet är lika med ljudets varaktighet minus värdet som anges av metoden [setTrimFromEnd]

PowerPoint **Volume control** på ljudkontrollpanelen motsvarar metoden [setVolumeValue]. Den låter dig ändra ljudvolymen i procent.

Så här ändrar du uppspelningsalternativen för ljud:

1. [Skapa](#create-audio-frames) eller hämta ljudramen.
2. Ställ in nya värden för de ljudramsegenskaper du vill justera.
3. Spara den modifierade PowerPoint-filen.

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
        # Spela vid klick med låg volym, över bilder, utan loopning.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Dölj ramen under bildspelet och spola tillbaka efter uppspelning.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

Detta Python‑exempel visar hur man lägger till en ny ljudram med inbäddat ljud, trimmar den och ställer in toningslängderna:

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

    # Trimma 1,5 sekunder från början och 2 sekunder från slutet.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Ställ in fade‑in till 200 ms och fade‑out till 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Följande kodexempel visar hur man hämtar en ljudram med inbäddat ljud och ställer in dess volym till 85 %:

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

## **Hantera ljudtextning**

Aspose.Slides låter dig lägga till stängda undertexter till en ljudram via metoden [getCaptionTracks]. Denna metod returnerar en [CaptionsCollection], som låter dig lägga till WebVTT‑undertextspår, iterera genom befintliga spår och ta bort dem vid behov.

**Lägg till ljudtextning**

Använd metoden [getCaptionTracks] för att fästa ett eller flera undertextspår till en ljudram. I följande exempel läggs en ljudfil till en bild och sedan laddas ett nytt undertextspår från en `.vtt`‑fil.

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

    # Lägg till ett nytt undertextspår från en WebVTT-fil.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Extrahera ljudtextning**

Du kan iterera genom undertextspåren som är kopplade till en ljudram och spara dem som `.vtt`‑filer. Varje undertextspår exponerar sin binära data och unika identifierare, som kan användas vid export av undertexter.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # Spara undertextspåret som en .vtt-fil.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**Ta bort ljudtextning**

För att ta bort undertexter från en ljudram, använd metoderna som tillhandahålls av [CaptionsCollection], såsom [clear], [remove] eller [removeAt]. Följande exempel tar bort alla undertextspår från en ljudram.

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

## **Extrahera ljud**

Aspose.Slides för Python via Java låter dig extrahera ljudet som används i bildspelsövergångar. Till exempel kan du extrahera ljudet som används i en specifik bild.

1. Skapa en instans av klassen [Presentation] och läs in presentationen som innehåller ljudet.
2. Hämta en referens till den relevanta bilden med dess index.
3. Åtkomst till [slideshow transitions] för bilden.
4. Extrahera ljudet som byte‑data.

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

## **Vanliga frågor**

**Kan jag återanvända samma ljudresurs på flera bilder utan att öka filstorleken?**

Ja. Lägg till ljudet en gång i presentationens delade [audio collection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getAudios) och skapa ytterligare ljudramar som refererar till den befintliga resursen. Detta undviker duplicering av mediedata och håller presentationens storlek under kontroll.

**Kan jag ersätta ljudet i en befintlig ljudram utan att återskapa formen?**

Ja. För ett länkat ljud, uppdatera [link path](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#setLinkPathLong) så att det pekar på den nya filen. För ett inbäddat ljud, byt ut objektet [embedded audio](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#setEmbeddedAudio) mot ett annat från presentationens [audio collection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getAudios). Ramens formatering och de flesta uppspelningsinställningar förblir intakta.

**Ändrar trimning den underliggande ljuddata som lagras i presentationen?**

Nej. Trimning justerar endast uppspelningsgränserna. De ursprungliga ljudbyterna förblir orörda och kan nås via det inbäddade ljudet eller presentationens ljudsamling.