---
title: Audio keretek kezelése prezentációkban Python használatával
linktitle: Audio keret
type: docs
weight: 10
url: /hu/python-java/audio-frame/
keywords:
- hang
- audio keret
- előnézet
- hang hozzáadása
- hang tulajdonságok
- hang beállítások
- hang kinyerése
- Python
- Aspose.Slides
description: "Ágyazz be hangot a diákba, változtasd meg a hang ikont, konfiguráld a lejátszást, kezeld a WebVTT feliratokat, és nyerd ki a diaváltási hangokat az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

Az audio keret lehetővé teszi hang lejátszását egy dián. Az Aspose.Slides for Python via Java segítségével beágyazhatsz egy hangklipet, kiválaszthatod azt ábrázoló képet, beállíthatod a lejátszást, és feliratokat csatolhatsz. Emellett lekérdezheted a diaátmenethez rendelt hangot.

## **Audio keretek létrehozása**

`audio.wav` fájl bájtjait add hozzá a prezentáció audio gyűjteményéhez, majd használd az [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) hívást a helyi audio klip beágyazásához az első dián. Az első két koordináta helyezi el a keretet a dián, a következő két érték beállítja a szélességét és magasságát pontban. Ez a példa meghívja a [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) metódust a klip automatikus indításához, és meghívja a [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) metódust a hangos előre beállított érték kiválasztásához.

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

## **Az audio keret előnézeti képének módosítása**

Alapértelmezés szerint egy audio keret a hangszóró ikont jeleníti meg. Egy egyéni előnézet megjelenítéséhez adj egy képet a prezentációhoz az [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) metódussal, és állítsd be a keret képére a [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage) metódussal. A példa egy JPEG-et használ előnézetként egy beágyazott audio klipehez.

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

## **Hang lejátszási beállítások módosítása**

A PowerPoint **Audio Options** vezérlői határozzák meg, mikor kezdődik a klip, milyen hangos, és hogyan viselkedik a diavetítés során.

![PowerPoint hangbeállítási vezérlők egy audio kerethez](audio_frame_0.png)

| PowerPoint vezérlő | Aspose.Slides for Python via Java method |
| --- | --- |
| Indítás | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| Hangerő előre beállított érték | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| Lejátszás diákon át | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Ismétlés leállításig | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Elrejtés előadás alatt | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| Visszatekercselés lejátszás után | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| Beúsztatás | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| Kicsengés | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Hang kezdési idő vágása | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| Hang befejezési idő vágása | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Hangerő csúszka | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

A példa megtalálja az első audio keretet az első dián, meghívja a [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) metódust a lejátszás indításához kattintásra, és kiválasztja az alacsony hangerő előre beállított értéket. A klip a diákon át folytatódik a hurok letiltásával. Az ikon rejtve marad az előadás során, és a klip visszatekeredik lejátszás után.

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
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

3,5 másodpercnél hosszabb klip esetén ez a példa kihagyja az első 1,5 másodpercet és az utolsó 2 másodpercet. A [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) a klip végéből eltávolítandó időt veszi. A PowerPointban látható befejezési időhez vonjuk le ezt az eltolást a teljes klipidőből. A levágott klipe 200 ms alatt húz be, és 500 ms alatt húz ki. Mind a négy metódus értékei ezredmásodpercben adhatók meg.

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

    # Vágja le 1,5 másodpercet a kezdetről és 2 másodpercet a végéről.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Állítsa be a beúsztatást 200 ms-re és a kicsengést 500 ms-re.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A lejátszási hangerő meghatározott százalékra állításához használd a [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) metódust. Ez a példa az első audio keretet az első dián 85%-ra állítja.

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

## **Audio feliratok kezelése**

Minden audio keret hozzáférést biztosít a felirat sávokhoz a [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks) segítségével. Használd a gyűjteményt WebVTT feliratok csatolásához a klipehez, létező sávok exportálásához vagy eltávolításához.

### **Audio feliratok hozzáadása**

A példa egy audio klipeet ágyazza be az első diára, és a [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) hívást használja helyi WebVTT sáv csatolásához. Az első argumentum a sáv címkét adja meg, a második a időzített feliratokat tartalmazó fájlt azonosítja.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpave.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Új felirat sáv hozzáadása egy WebVTT fájlból.
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Audio feliratok kinyerése**

Ez a példa exportálja az első dián egy audio kerethez csatolt minden feliratsávot. A [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) által visszaadott bájtokat egy WebVTT fájlba írja, és a [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) által visszaadott azonosítót használja fájlnévként, hogy minden sáv külön kimenettel rendelkezzen.

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
                # Mentse a felirat sávot .vtt fájlként.
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **Audio feliratok eltávolítása**

Használd a [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) vagy [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) hívást egy egyedi sáv törléséhez. A példa a [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) metódust használja az összes felirat eltávolításához az első dián az első audio keretről, miközben a klipet megőrzi.

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

### **Sor keresése audio feliratokban**

Az első diához tartozó audio feliratokban egy sort keresni, a [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) által visszaadott szöveget kell memóriában keresni. Egy egyszerű szöveges WebVTT idézetben az idővonal `-->` tartalmaz, a feliratsorok ezt követik, és egy üres sor zárja az idézetet. Ez a példa kiíratja a sáv címkét és minden olyan feliratsort, amely tartalmazza a „café” szót.

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

## **Audio kinyerése**

Egy diaváltásnak saját hangja lehet. A lekérdezéshez hívd a [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound) metódust a diaváltáson. A példa a [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) által visszaadott bájtokat olvassa, és kiírja a bájtok számát. Ha az első dián nincs váltási hang, helyette egy üzenetet írás.

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

## **GYIK**

**Can I reuse the same audio clip across multiple slides without duplicating it?**

Igen. A klipet egyszer add hozzá a prezentáció [audio collection](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) és minden dián a ugyanazt az audio objektumot adod át az [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) hívásnak.

**Can I replace the sound in an existing audio frame?**

Igen. Egy hivatkozott hang esetén használd a [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong) hívást a helyettesítő fájlra mutatáshoz. Beágyazott hang esetén válassz egy másik klipet a prezentáció audio gyűjteményéből a [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio) segítségével. Mindkét megközelítés megőrzi a meglévő keretet.

**Does trimming change the audio data stored in the presentation?**

Nem. A [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) és [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) a lejátszási határokat állítják be. A teljes klipet továbbra is lekérdezheted a [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio) metódussal.