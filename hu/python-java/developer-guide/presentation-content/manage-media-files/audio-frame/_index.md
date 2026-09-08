---
title: "Hangkeretek kezelése prezentációkban Python segítségével"
linktitle: "Hangkeret"
type: docs
weight: 10
url: /hu/python-java/audio-frame/
keywords:
  - "hang"
  - "hangkeret"
  - "bélyegkép"
  - "hang hozzáadása"
  - "hangtulajdonságok"
  - "hangbeállítások"
  - "hang kinyerése"
  - "Python"
  - "Aspose.Slides"
description: "Hangkeretek létrehozása és vezérlése az Aspose.Slides for Python via Java segítségével — kódpéldák a beágyazáshoz, vágáshoz, hurkoláshoz és a lejátszás konfigurálásához PPT, PPTX és ODP prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk hangkeretekkel az Aspose.Slides-ben. Megmutatja, hogyan lehet beágyazott hangot hozzáadni a diákhoz, testreszabni a hangkeret bélyegképét, konfigurálni a lejátszási beállításokat, például hangerő, hurok, elrejtés, vágás és elhalványulási időket, valamint hogyan lehet kinyerni a diavetítés-átmenetekben használt hangot.

## **Hangkeretek létrehozása**

Az Aspose.Slides for Python via Java lehetővé teszi hangfájlok diákhoz adását. A hangfájlok beágyazott hangkeretekként kerülnek a diákba.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg a dias referenciaját az indexe alapján.
3. Olvassa be a diára beágyazni kívánt hangfájlt.
4. Adja hozzá a beágyazott hangkeretet (amely a hangfájlt tartalmazza) a diához.
5. Állítsa be a [setPlayMode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setPlayMode) és a [setVolume](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setVolume) metódusokat a [AudioFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/) objektumon.
6. Mentse el a módosított bemutatót.

Ez a Python kód megmutatja, hogyan adhatunk hozzá beágyazott hangkeretet egy diához:

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

## **A hangkeret bélyegképének megváltoztatása**

Amikor hangfájlt adunk hozzá egy bemutatóhoz, a hang egy alapértelmezett képpel rendelkező keretként jelenik meg (lásd az alábbi képet). Megváltoztathatja a hangkeret előnézeti képét (állítsa be a kívánt képet).

Ez a Python kód megmutatja, hogyan változtathatja meg egy hangkeret bélyegképét vagy előnézeti képét:

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

## **Hang lejátszási beállításainak módosítása**

Az Aspose.Slides for Python via Java lehetővé teszi a hang lejátszását vagy tulajdonságait szabályozó beállítások módosítását. Például beállíthatja a hangerőt, lejátszhatja a hangot hurkolva, vagy akár elrejtheti a hangeszközt.

Az **Audio Options** panel a Microsoft PowerPointben:

![példa1_kép](audio_frame_0.png)

A PowerPoint **Audio Options** beállításai, amelyek az Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/) tulajdonságainak felelnek meg:

- **Start** legördülő lista megfelel a [setPlayMode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setPlayMode) metódusnak
- **Volume** megfelel a [setVolume](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setVolume) metódusnak
- **Play Across Slides** megfelel a [setPlayAcrossSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) metódusnak
- **Loop until Stopped** megfelel a [setPlayLoopMode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setPlayLoopMode) metódusnak
- **Hide During Show** megfelel a [setHideAtShowing](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setHideAtShowing) metódusnak
- **Rewind after Playing** megfelel a [setRewindAudio](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setRewindAudio) metódusnak

A PowerPoint **Editing** beállításai, amelyek az Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/) tulajdonságainak felelnek meg:

- **Fade In** megfelel a [setFadeInDuration](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setFadeInDuration) metódusnak
- **Fade Out** megfelel a [setFadeOutDuration](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setFadeOutDuration) metódusnak
- **Trim Audio Start Time** megfelel a [setTrimFromStart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setTrimFromStart) metódusnak
- **Trim Audio End Time** értéke a hang időtartama mínusz a [setTrimFromEnd](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setTrimFromEnd) metódus értéke

A PowerPoint hangvezérlő panelen található **Volume control** a [setVolumeValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setVolumeValue) metódusnak felel meg, és lehetővé teszi a hangerő százalékos módosítását.

Így módosíthatja a Hang lejátszási beállításait:

1. [Create](#create-audio-frames) vagy szerezze be a hangkeretet.
2. Állítsa be az új értékeket a módosítani kívánt hangkeret tulajdonságokhoz.
3. Mentse el a módosított PowerPoint fájlt.

Ez a Python kód bemutat egy műveletet, amelyben a hang beállításait módosítjuk:

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
        # Lejátszás kattintásra alacsony hangerővel, diákon át, hurok nélkül.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # A keret elrejtése a diavetítés során és visszatekerés lejátszás után.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

Ez a Python példa megmutatja, hogyan adjon hozzá új hangkeretet beágyazott hanggal, vágja le, és állítsa be az elhalványulási időket:

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

    # Vágjon le 1,5 másodpercet a kezdetnél és 2 másodpercet a végén.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Állítsa be a fade-in időt 200 ms-re és a fade-out időt 500 ms-re.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az alábbi kódrészlet bemutatja, hogyan lehet lekérni egy beágyazott hangot tartalmazó hangkeretet, és annak hangerősségét 85%-ra állítani:

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

## **Hang feliratok kezelése**

Az Aspose.Slides lehetővé teszi a hangkerethez zárt feliratok hozzáadását a [getCaptionTracks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#getCaptionTracks) metóduson keresztül. Ez a metódus egy [CaptionsCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/) objektumot ad vissza, amely lehetővé teszi WebVTT felirat sávok hozzáadását, meglévő sávok bejárását és szükség esetén azok eltávolítását.

**Hang feliratok hozzáadása**

Használja a [getCaptionTracks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#getCaptionTracks) metódust, hogy egy vagy több feliratsávot csatoljon egy hangkerethez. Az alábbi példában egy hangfájlt adunk hozzá egy diához, majd egy új feliratsávot töltünk be egy `.vtt` fájlból.

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

    # Adj hozzá egy új feliratsávot egy WebVTT fájlból.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Hang feliratok kinyerése**

Bejárhatja a hangkerethez kapcsolódó feliratsávokat, és mentheti őket `.vtt` fájlokként. Minden feliratsáv bináris adatot és egyedi azonosítót biztosít, amely exportáláskor felhasználható.

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
                # Mentse a feliratsávot .vtt fájlként.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**Hang feliratok eltávolítása**

A feliratok egy hangkeretből való eltávolításához használja a [CaptionsCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/) által biztosított metódusokat, például a [clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/#clear), a [remove](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/#remove) vagy a [removeAt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/#removeAt) metódust. Az alábbi példa eltávolítja az összes feliratsávot egy hangkeretből.

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

## **Hang kinyerése**

Az Aspose.Slides for Python via Java lehetővé teszi a diavetítés-átmenetekben használt hang kinyerését. Például egy adott diára vonatkozó hangot kinyerhet.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és töltse be a hangot tartalmazó bemutatót.
2. Szerezze meg a megfelelő dia referenciaját az indexe alapján.
3. Érje el a [slideshow transitions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#getSlideShowTransition) objektumot a dián.
4. Kinyerje a hangot bájt adatként.

Ez a Python kód megmutatja, hogyan nyerheti ki egy dia által használt hangot:

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

## **GYIK**

**Újra felhasználhatom ugyanazt a hangfájlt több dián anélkül, hogy megnövelném a fájlméretet?**

Igen. Adja hozzá a hangot egyszer a bemutató közös [audio collection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getAudios) gyűjteményéhez, majd hozzon létre további hangkereteket, amelyek erre a meglévő eszközre hivatkoznak. Így elkerülhető a médiaadatok duplikálása, és a bemutató mérete kontroll alatt marad.

**Lecserélhetem egy meglévő hangkeret hangját anélkül, hogy újra létrehoznám a formát?**

Igen. Egy hivatkozott hang esetén frissítse a [link path](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setLinkPathLong) értékét, hogy az új fájlra mutasson. Egy beágyazott hang esetén cserélje ki a [embedded audio](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setEmbeddedAudio) objektumot egy másikra a bemutató [audio collection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getAudios) gyűjteményéből. A keret formázása és a legtöbb lejátszási beállítás változatlan marad.

**A vágás megváltoztatja-e a prezentációban tárolt alapuló hangadatot?**

Nem. A vágás csak a lejátszási határokat módosítja. Az eredeti hangbájtok érintetlenül maradnak, és továbbra is elérhetők a beágyazott hang vagy a bemutató hanggyűjteménye révén.