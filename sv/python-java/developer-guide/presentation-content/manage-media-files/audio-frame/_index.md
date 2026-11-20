---
title: Hantera ljudramar i presentationer med Python
linktitle: Ljudram
type: docs
weight: 10
url: /sv/python-java/audio-frame/
keywords:
- ljud
- ljudram
- miniatyrbild
- lägga till ljud
- ljudegenskaper
- ljudalternativ
- extrahera ljud
- Python
- Aspose.Slides
description: "Bädda in ljud i bilder, ändra ljudikonen, konfigurera uppspelning, hantera WebVTT-undertexter och extrahera bildövergångsljud med Aspose.Slides för Python via Java."
---
## **Översikt**

En ljudram låter dig spela ett ljud på en bild. Med Aspose.Slides för Python via Java kan du bädda in ett ljudklipp, välja bilden som representerar det, justera uppspelning och bifoga bildtexter. Du kan också hämta ett ljud som tilldelats en bildövergång.

## **Skapa ljudramar**

Lägg till byte från `audio.wav` till presentationens ljudsamling, och använd sedan [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) för att bädda in ett lokalt ljudklipp på den första bilden. De två första koordinaterna placerar ramen på bilden, och de nästa två värdena anger dess bredd och höjd, alla i punkter. Detta exempel anropar [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) för att starta klippet automatiskt och anropar [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) för att välja den höga förinställningen.

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

Som standard visar en ljudram en högtalarikon. För att visa en anpassad miniatyr, lägg till en bild i presentationen med [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) och sätt den på ramens bild med [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage). Exemplet använder en JPEG som miniatyr för ett inbäddat ljudklipp.

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

## **Ändra ljuduppspelningsalternativ**

PowerPoints **Audio Options**-kontroller bestämmer när ett klipp startar, hur högt det låter och hur det beter sig under en bildspelsvisning.

![PowerPoint-ljudalternativ för en ljudram](audio_frame_0.png)

| PowerPoint-kontroll | Aspose.Slides for Python via Java method |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| Volyminställning | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| Spela över bilder | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Loop tills stoppad | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Dölj under visning | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| Spola tillbaka efter uppspelning | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| Tona in | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| Tona ut | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Trimma ljud starttid | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| Trimma ljud sluttid | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Volymreglage | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

Exemplet hittar den första ljudramen på den första bilden, anropar [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) för att starta uppspelning vid ett klick, och väljer den låga volyminställningen. Klippet fortsätter över bilder med loopning inaktiverad. Ikonen förblir dold under visningen, och klippet spolar tillbaka efter uppspelning.

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
        # Spela vid klick med låg volym, över bilder, utan loopning.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Dölj ramen under bildspelsvisningen och spola tillbaka efter uppspelning.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

För ett klipp längre än 3,5 sekunder hoppar detta exempel över de första 1,5 sekunderna och de sista 2 sekunderna. [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) tar den varaktighet som ska utelämnas från slutet av klippet. För att få sluttiden som visas i PowerPoint, dra av den förskjutningen från hela klippets varaktighet. Det trimmade klippet tonar in under 200 millisekunder och tonar ut under 500 millisekunder. Alla fyra metoder tar värden i millisekunder.

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

    # Trimma 1,5 sekunder från början och 2 sekunder från slutet.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Ställ in toning in till 200 ms och toning out till 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

För att ställa in uppspelningsvolymen till en specifik procentandel, använd [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue). Detta exempel sätter den första ljudramen på den första bilden till 85 %.

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

## **Hantera ljudundertexter**

Varje ljudram ger åtkomst till sina undertextspår via [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks). Använd samlingen för att bifoga WebVTT-undertexter till klippet, exportera befintliga spår eller ta bort dem.

### **Lägg till ljudundertexter**

Exemplet bäddar in ett ljudklipp på den första bilden och använder [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) för att bifoga ett lokalt WebVTT-spår. Det första argumentet anger spårets etikett, och det andra identifierar filen som innehåller de tidsinställda undertexterna.

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

    # Lägg till ett nytt undertextspår från en WebVTT-fil.
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Extrahera ljudundertexter**

Detta exempel exporterar varje undertextspår som är bifogat till en ljudram på den första bilden. Det skriver de byte som returneras av [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) till en WebVTT-fil och använder identifieraren som returneras av [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) som filnamn så att varje spår har en separat utdata.

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
                # Spara undertextspåret som en .vtt-fil.
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **Ta bort ljudundertexter**

Använd [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) eller [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) för att radera ett enskilt spår. Exemplet använder [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) för att ta bort alla undertexter från den första ljudramen på den första bilden samtidigt som klippet behålls.

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

### **Hitta en rad i ljudundertexter**

För att hitta en rad i ljudundertexterna på den första bilden, sök i texten som returneras av [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) i minnet. I en klartext-WebVTT-cue innehåller tidslinjen `-->`, undertextraderna följer den, och en tom rad avslutar cue:n. Detta exempel skriver ut spårets etikett och varje undertextrad som innehåller “café”.

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

## **Extrahera ljud**

En bildövergång kan ha ett eget ljud. För att hämta det, anropa [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound) på bildövergången. Exemplet får åtkomst till de byte som returneras av [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) och skriver ut antalet byte. Om den första bilden inte har något övergångsljud, skriver det ut ett meddelande istället.

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

## **Vanliga frågor**

**Kan jag återanvända samma ljudklipp på flera bilder utan att duplicera det?**

Ja. Lägg till klippet en gång i presentationens [audio collection](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) och skicka samma ljudobjekt till [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) för varje bild.

**Kan jag ersätta ljudet i en befintlig ljudram?**

Ja. För ett länkat ljud, använd [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong) för att peka på ersättningsfilen. För ett inbäddat ljud, välj ett annat klipp från presentationens ljudsamling med [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio). Båda metoderna bevarar den befintliga ramen.

**Ändrar trimning ljuddata som lagras i presentationen?**

Nej. [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) och [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) anger uppspelningsgränser. Du kan fortfarande hämta hela klippet från [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio).