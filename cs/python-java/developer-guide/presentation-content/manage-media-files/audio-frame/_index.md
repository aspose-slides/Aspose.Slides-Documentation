---
title: Správa zvuku v prezentacích pomocí Pythonu
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
description: "Vytvořte a ovládejte audio rámy v Aspose.Slides pro Python via Java — příklady kódu pro vložení, ořezání, smyčkování a konfiguraci přehrávání v prezentacích PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s audio rámci v Aspose.Slides. Ukazuje, jak přidat vložený zvuk do snímků, přizpůsobit miniaturu audio rámce, nakonfigurovat možnosti přehrávání, jako jsou hlasitost, smyčkování, skrytí, ořezávání a doby zeslabení, a extrahovat zvuk použitý v přechodech prezentace.

## **Vytvořit audio rámce**

Aspose.Slides pro Python via Java umožňuje přidávat audio soubory do snímků. Audio soubory jsou do snímků vloženy jako audio rámce. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Načtěte audio soubor, který chcete vložit do snímku.
4. Přidejte vložený audio rámec (obsahující audio soubor) do snímku.
5. Nastavte [setPlayMode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setPlayMode) a [setVolume](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setVolume) poskytované objektem [AudioFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/) .
6. Uložte upravenou prezentaci.

Tento Python kód ukazuje, jak přidat vložený audio rámec do snímku:

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

Když přidáte audio soubor do prezentace, zvuk se zobrazí jako rámec se standardním výchozím obrázkem (viz obrázek v následující sekci). Můžete změnit náhledový obrázek audio rámce (nastavte vámi preferovaný obrázek).

Tento Python kód ukazuje, jak změnit miniaturu audio rámce nebo náhledový obrázek:

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

## **Změna možností přehrávání audia**

Aspose.Slides pro Python via Java umožňuje měnit možnosti, které řídí přehrávání nebo vlastnosti audia. Například můžete upravit hlasitost audia, nastavit, aby se audio přehrávalo ve smyčce, nebo dokonce skrýt ikonu audia.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/) properties:
- **Start** rozbalovací seznam odpovídá metodě [setPlayMode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** odpovídá metodě [setVolume](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** odpovídá metodě [setPlayAcrossSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** odpovídá metodě [setPlayLoopMode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** odpovídá metodě [setHideAtShowing](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** odpovídá metodě [setRewindAudio](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setRewindAudio)

Možnosti **Editing** v PowerPointu, které odpovídají vlastnostem Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/) properties:
- **Fade In** odpovídá metodě [setFadeInDuration](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** odpovídá metodě [setFadeOutDuration](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** odpovídá metodě [setTrimFromStart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** hodnota se rovná délce audia minus hodnota metody [setTrimFromEnd](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setTrimFromEnd) method

Ovládání **Volume control** v PowerPointu na panelu pro ovládání audia odpovídá metodě [setVolumeValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setVolumeValue) . Umožňuje změnit hlasitost audia v procentech.

Takto změníte možnosti přehrávání audia:
1. [Vytvořit](#create-audio-frames) nebo získat Audio Frame.
2. Nastavte nové hodnoty pro vlastnosti Audio Frame, které chcete upravit.
3. Uložte upravený soubor PowerPoint.

Tento Python kód demonstruje operaci, při které jsou upraveny možnosti audia:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    audio_frame = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        # Přehrát při kliknutí s nízkou hlasitostí, napříč snímky, bez smyčkování.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Skrýt rámec během prezentace a po přehrání jej přetočit zpět.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

Tento Python příklad ukazuje, jak přidat nový audio rámec s vloženým audiem, oříznout jej a nastavit doby zeslabení:

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

    # Oříznout 1,5 sekundy od začátku a 2 sekundy od konce.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Nastavit fade-in na 200 ms a fade-out na 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Následující ukázkový kód ukazuje, jak získat audio rámec s vloženým audiem a nastavit jeho hlasitost na 85 %:

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

## **Správa titulků audia**

Aspose.Slides umožňuje přidat uzavřené titulky k audio rámci pomocí metody [getCaptionTracks](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#getCaptionTracks) . Tato metoda vrací [CaptionsCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/captionscollection/) , která umožňuje přidávat WebVTT titulkové stopy, procházet existující stopy a odstraňovat je podle potřeby.

**Přidání titulků audia**

Použijte metodu [getCaptionTracks](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#getCaptionTracks) k připojení jedné nebo více titulkových stop k audio rámci. V následujícím příkladu je audio soubor přidán do snímku a poté je nová titulková stopa načtena ze souboru `.vtt` .

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

    # Přidat novou stopu titulků ze souboru WebVTT.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Extrahování titulků audia**

Můžete procházet titulkové stopy spojené s audio rámcem a uložit je jako soubory `.vtt`. Každá titulková stopa poskytuje svá binární data a jedinečný identifikátor, který lze použít při exportu titulků.

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
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**Odstranění titulků audia**

Pro odstranění titulků z audio rámce použijte metody poskytované třídou [CaptionsCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/captionscollection/) , jako jsou [clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/captionscollection/#clear) , [remove](https://reference.aspose.com/slides/cs/python-java/aspose.slides/captionscollection/#remove) nebo [removeAt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/captionscollection/#removeAt) . Následující příklad odstraňuje všechny titulkové stopy z audio rámce.

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

## **Extrahování audia**

Aspose.Slides pro Python via Java umožňuje extrahovat zvuk použitého při přechodech prezentace. Například můžete extrahovat zvuk použitý v konkrétním snímku.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte prezentaci obsahující audio.
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přistupte k [slideshow transitions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#getSlideShowTransition) pro snímek.
4. Extrahujte zvuk v bajtových datech.

Tento Python kód ukazuje, jak extrahovat audio použité v snímku:

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

## **Často kladené otázky**

**Mohu znovu použít stejný audio soubor na více snímcích, aniž by se zvětšila velikost souboru?**

Ano. Přidejte audio jednou do sdílené [audio collection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getAudios) prezentace a vytvořte další audio rámce, které odkazují na tento existující asset. Tím se zabrání duplikaci mediálních dat a velikost prezentace zůstane pod kontrolou.

**Mohu nahradit zvuk v existujícím audio rámci, aniž bych znovu vytvářel tvar?**

Ano. Pro propojený zvuk aktualizujte [link path](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setLinkPathLong), aby ukazoval na nový soubor. Pro vložený zvuk vyměňte objekt [embedded audio](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setEmbeddedAudio) za jiný z [audio collection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getAudios) prezentace. Formátování rámce a většina nastavení přehrávání zůstane nezměněna.

**Změní ořezávání základní audio data uložená v prezentaci?**

Ne. Ořezávání upravuje pouze hranice přehrávání. Původní audio bajty zůstávají nedotčeny a jsou přístupné přes vložené audio nebo audio kolekci prezentace.