---
title: Audió kezelése prezentációkban Python használatával
linktitle: Audió keret
type: docs
weight: 10
url: /hu/python-java/audio-frame/
keywords:
- audió
- audió keret
- bélyegkép
- hang hozzáadása
- hang tulajdonságok
- hang beállítások
- hang kinyerése
- Python
- Aspose.Slides
description: "Audiókeretek létrehozása és vezérlése az Aspose.Slides for Python via Java használatával—kódpéldák a beágyazáshoz, vágáshoz, hurokhoz, és a lejátszás konfigurálásához PPT, PPTX és ODP prezentációkban."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhatunk audiókeretekkel az Aspose.Slides-ben. Bemutatja, hogyan adhatunk beágyazott hangot a diákhoz, testreszabhatjuk az audiókeret miniatűrjét, konfigurálhatjuk a lejátszási beállításokat, például hangerőt, ismétlést, elrejtést, vágást és elhalványulási időtartamokat, valamint hogyan nyerhetjük ki a diavetítés átmeneteihez használt hangot.

## **Audiókeretek létrehozása**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy hangfájlokat adjunk a diákhoz. A hangfájlok beágyazottak a diákban audiókeretként.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára a indexe alapján.
3. Olvassa be a beágyazni kívánt hangfájlt.
4. Adja hozzá a beágyazott audiókeretet (amely a hangfájlt tartalmazza) a diához.
5. Használja a [AudioFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/) objektum által biztosított [setPlayMode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setPlayMode) és [setVolume](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setVolume) metódusokat.
6. Mentse a módosított prezentációt.

Ez a Python kód megmutatja, hogyan adjon egy beágyazott audiókeretet egy diához:

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

## **Az audiókeret miniatűrjének módosítása**

Ha hangfájlt ad egy prezentációhoz, az hangként egy alapértelmezett képpel (lásd az alábbi képet) jelenik meg keretként. A keret előnézeti képét megváltoztathatja egy saját választott képre.

Ez a Python kód megmutatja, hogyan módosítsa az audiókeret miniatűrjét vagy előnézeti képét:

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

## **Az audió lejátszási beállítások módosítása**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy megváltoztassa a hang lejátszását vagy tulajdonságait szabályozó beállításokat. Például beállíthatja a hangerőt, engedélyezheti a hurok lejátszást, vagy elrejtheti a hang ikont.

Az **Audióbeállítások** panel a Microsoft PowerPointben:

![example1_image](audio_frame_0.png)

PowerPoint **Audióbeállítások**, amelyek megfelelnek az Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/) tulajdonságainak:

- **Indítás** legördülő lista megegyezik a [setPlayMode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setPlayMode) metódussal
- **Hangerő** megegyezik a [setVolume](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setVolume) metódussal
- **Lejátszás a diákon keresztül** megegyezik a [setPlayAcrossSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) metódussal
- **Ismétlés a leállításig** megegyezik a [setPlayLoopMode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setPlayLoopMode) metódussal
- **Elrejtés a bemutató alatt** megegyezik a [setHideAtShowing](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setHideAtShowing) metódussal
- **Visszatekerés lejátszás után** megegyezik a [setRewindAudio](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setRewindAudio) metódussal

PowerPoint **Szerkesztési** opciók, amelyek megfelelnek az Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/) tulajdonságainak:

- **Halványulás be** megegyezik a [setFadeInDuration](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setFadeInDuration) metódussal 
- **Halványulás ki** megegyezik a [setFadeOutDuration](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setFadeOutDuration) metódussal 
- **Audió vágás kezdési idő** megegyezik a [setTrimFromStart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setTrimFromStart) metódussal 
- **Audió vágás befejezési idő** értéke megegyezik az audió hosszával mínusz a [setTrimFromEnd](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setTrimFromEnd) metódussal beállított értékkel

A PowerPoint **Hangerő szabályzó** az audió vezérlőpanelen megegyezik a [setVolumeValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setVolumeValue) metódussal. Lehetővé teszi a hangerő százalékos módosítását.

Így módosíthatja az audió lejátszási beállításokat:

1. [Create](#create-audio-frames) vagy szerezze be az audiókeretet.
2. Állítson be új értékeket a módosítani kívánt audiókeret tulajdonságokra.
3. Mentse a módosított PowerPoint fájlt.

Ez a Python kód bemutat egy műveletet, amelyben a hangbeállításokat módosítják:

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
        # Lejátszás kattintásra alacsony hangerővel, a diákon keresztül, ismétlés nélkül.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # A keret elrejtése a diavetítés alatt és visszatekerés lejátszás után.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

Ez a Python példa megmutatja, hogyan adjon hozzá egy új audiókeretet beágyazott hanggal, vágja le, és állítsa be a halványulási időtartamokat:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpage.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Vágjon le 1,5 másodpercet a kezdetektől és 2 másodpercet a végétől.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Állítsa be a befelé halványulást 200 ms-re és a kifelé halványulást 500 ms-re.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A következő kódrészlet bemutatja, hogyan kérjen le egy audiókeretet beágyazott hanggal, és állítsa be a hangerőt 85%-ra:

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

## **Audió feliratok kezelése**

Az Aspose.Slides lehetővé teszi, hogy zárt feliratokat adjunk egy audiókerethez a [getCaptionTracks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#getCaptionTracks) metódus segítségével. Ez a metódus egy [CaptionsCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/) objektumot ad vissza, amely lehetővé teszi WebVTT felirat sávok hozzáadását, a meglévő sávok bejárását, és szükség esetén azok eltávolítását.

**Audió feliratok hozzáadása**

Használja a [getCaptionTracks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#getCaptionTracks) metódust, hogy egy vagy több feliratsávot csatoljon egy audiókerethez. Az alábbi példában egy hangfájlt adunk egy diához, majd egy új feliratsávot töltünk be egy `.vtt` fájlból.

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

    # Új feliratsáv hozzáadása egy WebVTT fájlból.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Audió feliratok kinyerése**

Végigiterálhat a audiókerethez társított feliratsávokon, és elmentheti őket `.vtt` fájlként. Minden feliratsáv bináris adatot és egyedi azonosítót exponál, amely exportáláskor felhasználható.

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

**Audió feliratok eltávolítása**

A feliratok eltávolításához egy audiókeretből használja a [CaptionsCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/) által biztosított metódusokat, például a [clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/#remove) vagy [removeAt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/#removeAt) metódusokat. Az alábbi példa eltávolítja az összes feliratsávot egy audiókeretből.

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

## **Audió kinyerése**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy kinyerje a diavetítés átmeneteihez használt hangot. Például egy adott dia hangját is kinyerheti.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt, és töltse be azt a prezentációt, amely tartalmazza a hangot.
2. Szerezzen hivatkozást a megfelelő diára az indexe alapján.
3. Hozzáférhet a dia [slideshow transitions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#getSlideShowTransition) tulajdonságához.
4. Kinyeri a hangot bájt adatként.

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

**Újrahasználhatom ugyanazt az audióeszközt több dián anélkül, hogy a fájlméret nőne?**

Igen. Adja hozzá a hangot egyszer a prezentáció megosztott [audio collection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getAudios) gyűjteményéhez, és hozzon létre további audiókereteket, amelyek erre a meglévő eszközre hivatkoznak. Ez megakadályozza a médiaadatok duplikálását, és a prezentáció méretét kordában tartja.

**Lecserélhetem a hangot egy meglévő audiókeretben anélkül, hogy újra létrehoznám az alakzatot?**

Igen. Egy hivatkozott hang esetén frissítse a [link path](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setLinkPathLong) értékét, hogy az új fájlra mutasson. Beágyazott hang esetén cserélje ki a [embedded audio](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/#setEmbeddedAudio) objektumot egy másikra a prezentáció [audio collection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getAudios) gyűjteményéből. A keret formázása és a legtöbb lejátszási beállítás változatlan marad.

**A vágás megváltoztatja a prezentációban tárolt alapvető audióadatot?**

Nem. A vágás csak a lejátszási határokat módosítja. Az eredeti audióbájtok változatlanul megmaradnak, és hozzáférhetők a beágyazott hang vagy a prezentáció audiógyűjteménye révén.