---
title: Správa audio rámců v prezentacích pomocí Pythonu
linktitle: Audio rámec
type: docs
weight: 10
url: /cs/python-java/audio-frame/
keywords:
- audio
- audio rámec
- miniatura
- přidat audio
- vlastnosti audia
- možnosti audia
- extrahovat audio
- Python
- Aspose.Slides
description: "Vkládání audia do snímků, změna ikony audia, konfigurace přehrávání, správa WebVTT titulků a extrakce zvuků přechodů snímků pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Audio rámec vám umožňuje přehrát zvuk na snímku. S Aspose.Slides pro Python přes Java můžete vložit zvukový klip, vybrat obrázek, který jej představuje, upravit přehrávání a připojit titulky. Také můžete získat zvuk přiřazený k přechodu snímku.

## **Vytvoření audio rámců**

Přidejte bajty z `audio.wav` do audio sbírky prezentace a poté použijte [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) k vložení místního audio klipu na první snímek. První dvě souřadnice umisťují rámec na snímek a další dvě hodnoty nastavují jeho šířku a výšku, vše v bodech. Tento příklad volá [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode), aby spustil klip automaticky, a volá [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) pro výběr hlasitého přednastavení.

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

## **Změna miniatury audio rámce**

Ve výchozím nastavení audio rámec zobrazuje ikonu reproduktoru. Pro zobrazení vlastní miniatury přidejte obrázek do prezentace pomocí [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) a nastavte jej na obrázek rámce pomocí [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage). Příklad používá JPEG jako miniaturu pro vložený audio klip.

```python
from pathlib import Path

import jpime
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

## **Změna možností přehrávání zvuku**

Ovládací prvky **Audio Options** v PowerPointu určují, kdy klip začne, jak hlasitý je a jak se chová během prezentace.

![Ovládací prvky PowerPoint Audio Options pro audio rámec](audio_frame_0.png)

| Ovládací prvek PowerPointu | Metoda Aspose.Slides pro Python přes Java |
| --- | --- |
| Spustit | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| Předvolba hlasitosti | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| Přehrát napříč snímky | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Opakovat dokud není zastaveno | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Skrýt během prezentace | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| Přetočit po přehrání | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| Prolnutí dovnitř | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| Prolnutí ven | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Oříznout čas začátku zvuku | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| Oříznout čas konce zvuku | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Posuvník hlasitosti | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

Příklad najde první audio rámec na prvním snímku, zavolá [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) pro spuštění přehrávání po kliknutí a vybere nízkou předvolbu hlasitosti. Klip pokračuje napříč snímky s vypnutým opakováním. Ikona zůstává skrytá během prezentace a klip se po přehrání přetočí zpět.

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
        # Přehrát po kliknutí s nízkou hlasitostí, napříč snímky, bez opakování.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Skrýt rámec během prezentace a přetočit po přehrání.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

Pro klip delší než 3,5 sekundy tento příklad přeskočí první 1,5 sekundy a poslední 2 sekundy. [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) určuje dobu, která se má vynechat na konci klipu. Chcete-li získat koncový čas zobrazený v PowerPointu, odečtěte tento posun od celkové délky klipu. Oříznutý klip se během 200 milisekund rozsvítí (fade in) a během 500 milisekund zhasne (fade out). Všechny čtyři metody přijímají hodnoty v milisekundách.

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

    # Oříznout 1,5 sekundy od začátku a 2 sekundy od konce.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Nastavit prolnutí dovnitř na 200 ms a prolnutí ven na 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pro nastavení hlasitosti přehrávání na konkrétní procento použijte [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue). Tento příklad nastaví první audio rámec na prvním snímku na 85%.

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

## **Správa audio titulků**

Každý audio rámec poskytuje přístup ke svým stopám titulků prostřednictvím [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks). Použijte kolekci k připojení WebVTT titulků ke klipu, exportu existujících stop nebo jejich odstranění.

### **Přidání audio titulků**

Příklad vloží audio klip na první snímek a použije [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) k připojení místní WebVTT stopy. První argument poskytuje název stopy a druhý určuje soubor obsahující časované titulky.

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

    # Přidat novou stopu titulků ze souboru WebVTT.
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Extrahovat audio titulky**

Tento příklad exportuje každou stopu titulků připojenou k audio rámci na prvním snímku. Zapíše bajty vrácené metodou [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) do souboru WebVTT a použije identifikátor vrácený metodou [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) jako název souboru, aby měla každá stopa samostatný výstup.

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
                # Uložit stopu titulků jako soubor .vtt.
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **Odstranění audio titulků**

Použijte [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) nebo [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) pro smazání jednotlivé stopy. Příklad používá [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) k odstranění všech titulků z první audio rámce na prvním snímku při zachování klipu.

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

### **Vyhledání řádku v audio titulcích**

Chcete-li najít řádek v audio titulcích na prvním snímku, vyhledejte text vrácený metodou [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) v paměti. V prostém textovém WebVTT cue časová řádka obsahuje `-->`, řádky titulků následují a prázdný řádek ukončuje cue. Tento příklad vypíše název stopy a každou řádku titulků obsahující „café“.

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

## **Extrahovat zvuk**

Přechod snímku může mít vlastní zvuk. Pro jeho získání zavolejte [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound) na přechodu snímku. Příklad získá bajty vrácené metodou [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) a vypíše počet bajtů. Pokud první snímek nemá zvuk přechodu, vypíše místo toho zprávu.

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

## **Často kladené otázky**

**Mohu znovu použít stejný audio klip na více snímcích bez duplikace?**

Ano. Přidejte klip jednou do [audio collection](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) prezentace a pro každý snímek předávejte stejný audio objekt metodě [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded).

**Mohu nahradit zvuk v existujícím audio rámci?**

Ano. Pro propojený zvuk použijte [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong), aby ukazoval na náhradní soubor. Pro vložený zvuk vyberte jiný klip z audio sbírky prezentace pomocí [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio). Oba přístupy zachovají existující rámec.

**Mění ořezávání uložená audio data v prezentaci?**

Ne. [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) a [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) nastavují hranice přehrávání. Stále můžete získat celý klip pomocí [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio).