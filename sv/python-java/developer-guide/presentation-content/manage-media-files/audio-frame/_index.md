---
title: Hantera ljud i presentationer med Python
linktitle: Ljudram
type: docs
weight: 10
url: /sv/python-java/audio-frame/
keywords:
- ljud
- ljudram
- miniatyrbild
- lägg till ljud
- ljudegenskaper
- ljudalternativ
- extrahera ljud
- Python
- Aspose.Slides
description: "Skapa och kontrollera ljudramar i Aspose.Slides för Python via Java—kodexempel för att bädda in, trimma, loopa och konfigurera uppspelning i PPT-, PPTX- och ODP-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med ljudramar i Aspose.Slides. Den visar hur du lägger till inbäddat ljud i bilder, anpassar ljudramens miniatyrbild, konfigurerar uppspelningsalternativ som volym, loopning, dölja, trimning och toningsvaraktigheter, och extraherar ljud som används i bildspelsövergångar.

## **Skapa ljudramar**

Aspose.Slides for Python via Java låter dig lägga till ljudfiler i bilder. Ljudfilerna bäddas in i bilder som ljudramar. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Hämta en bilds referens via dess index.
3. Läs in ljudfilen du vill bädda in i bilden.
4. Lägg till den inbäddade ljudramen (som innehåller ljudfilen) på bilden.
5. Använd [setPlayMode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#setPlayMode) och [setVolume](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#setVolume) som exponeras av objektet [AudioFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/).
6. Spara den modifierade presentationen.

Denna Python‑kod visar hur du lägger till en inbäddad ljudram i en bild:

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

## **Ändra ljudramens miniatyrbild**

När du lägger till en ljudfil i en presentation visas ljudet som en ram med en standardstandardbild (se bilden i avsnittet nedan). Du kan ändra ramens förhandsbild (ange den bild du föredrar).

Denna Python‑kod visar hur du ändrar en ljudramens miniatyrbild eller förhandsbild:

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

## **Ändra alternativ för ljuduppspelning**

Aspose.Slides för Python via Java låter dig ändra alternativ som styr ett ljuds uppspelning eller egenskaper. Till exempel kan du justera ett ljuds volym, ställa in att ljudet ska spelas i loop, eller till och med dölja ljudikonen.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** som motsvarar Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/) egenskaper:

- **Start**-rullgardinsmenyn matchar metoden [setPlayMode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** matchar metoden [setVolume](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** matchar metoden [setPlayAcrossSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** matchar metoden [setPlayLoopMode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** matchar metoden [setHideAtShowing](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** matchar metoden [setRewindAudio](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#setRewindAudio)

PowerPoint **Editing**-alternativ som motsvarar Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/) egenskaper:

- **Fade In** matchar metoden [setFadeInDuration](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** matchar metoden [setFadeOutDuration](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** matchar metoden [setTrimFromStart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time**‑värdet är ljudets varaktighet minus värdet för metoden [setTrimFromEnd](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#setTrimFromEnd)

PowerPoint **Volume control** på ljudkontrollpanelen motsvarar metoden [setVolumeValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#setVolumeValue). Den låter dig ändra ljudvolymen i procent.

Så här ändrar du ljuduppspelningsalternativen:

1. [Skapa](#create-audio-frames) eller hämta ljudramen.
2. Ställ in nya värden för de Audio Frame‑egenskaper du vill justera.
3. Spara den modifierade PowerPoint‑filen.

Denna Python‑kod demonstrerar en operation där ett ljuds alternativ justeras:

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

Detta Python‑exempel visar hur du lägger till en ny ljudram med inbäddat ljud, trimmar den och sätter toningsvaraktigheterna:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpjp.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Trimma 1.5 sekunder från början och 2 sekunder från slutet.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Ställ in fade-in till 200 ms och fade-out till 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Följande kodexempel visar hur du hämtar en ljudram med inbäddat ljud och sätter dess volym till 85 %:

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

Aspose.Slides låter dig lägga till undertexter till en ljudram via metoden [getCaptionTracks](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#getCaptionTracks). Denna metod returnerar en [CaptionsCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/captionscollection/), som låter dig lägga till WebVTT‑undertextspår, iterera genom befintliga spår och ta bort dem vid behov.

**Lägg till ljudundertexter**

Använd metoden [getCaptionTracks](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#getCaptionTracks) för att bifoga ett eller flera undertextspår till en ljudram. I följande exempel läggs en ljudfil till en bild och därefter laddas ett nytt undertextspår från en `.vtt`‑fil.

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

**Extrahera ljudundertexter**

Du kan iterera genom undertextspåren som är associerade med en ljudram och spara dem som `.vtt`‑filer. Varje undertextspår exponerar dess binära data och unika identifierare, vilket kan användas vid export av undertexter.

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
                # Spara undertextspåret som en .vtt fil.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**Ta bort ljudundertexter**

För att ta bort undertexter från en ljudram, använd metoderna som tillhandahålls av [CaptionsCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/captionscollection/), såsom [clear](https://reference.aspose.com/slides/sv/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/sv/python-java/aspose.slides/captionscollection/#remove) eller [removeAt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/captionscollection/#removeAt). Följande exempel tar bort alla undertextspår från en ljudram.

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

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och öppna presentationen som innehåller ljudet.
2. Hämta den aktuella bildens referens via dess index.
3. Åtkomst till [slideshow transitions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/#getSlideShowTransition) för bilden.
4. Extrahera ljudet som byte‑data.

Denna kod i Python visar hur du extraherar ljudet som används i en bild:

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

**Kan jag återanvända samma ljudresurs i flera bilder utan att öka filstorleken?**

Ja. Lägg till ljudet en gång i presentationens gemensamma [audio collection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getAudios) och skapa ytterligare ljudramar som refererar till den befintliga resursen. Detta förhindrar duplicering av mediadata och håller presentationsstorleken under kontroll.

**Kan jag ersätta ljudet i en befintlig ljudram utan att återskapa formen?**

Ja. För ett länkat ljud, uppdatera [link path](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#setLinkPathLong) så att den pekar på den nya filen. För ett inbäddat ljud, byt ut objektet [embedded audio](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/#setEmbeddedAudio) mot ett annat från presentationens [audio collection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getAudios). Ramens formatering och de flesta uppspelningsinställningar förblir intakta.

**Ändrar trimning den underliggande ljuddata som lagras i presentationen?**

Nej. Trimning justerar endast uppspelningsgränserna. De ursprungliga ljudbytarna förblir opåverkade och är tillgängliga via det inbäddade ljudet eller presentationens audio collection.