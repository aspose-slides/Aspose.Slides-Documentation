---
title: Správa zvuku v prezentacích pomocí Pythonu
linktitle: Audio rámec
type: docs
weight: 10
url: /cs/python-java/audio-frame/
keywords:
- zvuk
- audio rámec
- náhled
- přidat zvuk
- vlastnosti zvuku
- možnosti zvuku
- extrahovat zvuk
- Python
- Aspose.Slides
description: "Vytvářejte a ovládejte audio rámečky v Aspose.Slides pro Python přes Java – příklady kódu pro vkládání, ořezávání, smyčkování a konfiguraci přehrávání v PPT, PPTX a ODP prezentacích."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s audio rámci v Aspose.Slides. Ukazuje, jak přidat vložený zvuk do snímků, přizpůsobit miniaturu audio rámce, nakonfigurovat možnosti přehrávání, jako je hlasitost, smyčkování, skrývání, ořezávání a dobu proslábnutí, a extrahovat zvuk použité v přechodech prezentace.

## **Vytvoření audio rámců**

Aspose.Slides pro Python přes Java umožňuje přidávat zvukové soubory do snímků. Zvukové soubory jsou vkládány do snímků jako audio rámce. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přečtěte zvukový soubor, který chcete vložit do snímku.
4. Přidejte vložený audio rámec (obsahující zvukový soubor) do snímku.
5. Použijte [setPlayMode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setPlayMode) a [setVolume](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setVolume) vystavené objektem [AudioFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/).
6. Uložte upravenou prezentaci.

Tento kód v Pythonu ukazuje, jak přidat vložený audio rámec do snímku:

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

Když do prezentace přidáte zvukový soubor, zvuk se zobrazí jako rámec se standardním výchozím obrázkem (viz obrázek v následující sekci). Můžete změnit náhledový obrázek audio rámce na obrázek dle vašeho výběru.

Tento kód v Pythonu ukazuje, jak změnit miniaturu nebo náhledový obrázek audio rámce:

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

## **Změna možností přehrávání zvuku**

Aspose.Slides pro Python přes Java umožňuje měnit možnosti, které řídí přehrávání zvuku nebo jeho vlastnosti. Například můžete upravit hlasitost zvuku, nastavit smyčkování zvuku nebo dokonce skrýt ikonu zvuku.

Panel **Audio Options** v Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**, které odpovídají vlastnostem Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/):

- **Start** rozbalovací seznam odpovídá metodě [setPlayMode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** odpovídá metodě [setVolume](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** odpovídá metodě [setPlayAcrossSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** odpovídá metodě [setPlayLoopMode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** odpovídá metodě [setHideAtShowing](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** odpovídá metodě [setRewindAudio](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setRewindAudio)

Možnosti **Editing** v PowerPointu, které odpovídají vlastnostem Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/) :

- **Fade In** odpovídá metodě [setFadeInDuration](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** odpovídá metodě [setFadeOutDuration](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** odpovídá metodě [setTrimFromStart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** hodnota se rovná délce zvuku minus hodnota nastavená metodou [setTrimFromEnd](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setTrimFromEnd) 

Ovládání **Volume** v PowerPointu na panelu pro audio odpovídá metodě [setVolumeValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setVolumeValue). Umožňuje vám změnit hlasitost zvuku v procentech.

Takto měníte možnosti přehrávání zvuku:

1. [Vytvořit](#create-audio-frames) nebo získejte audio rámec.
2. Nastavte nové hodnoty pro vlastnosti audio rámce, které chcete upravit.
3. Uložte upravený soubor PowerPoint.

Tento kód v Pythonu demonstruje operaci, při které jsou upraveny možnosti zvuku:

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
        # Přehrát po kliknutí s nízkou hlasitostí, napříč snímky, bez smyčkování.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Skrýt rámec během prezentace a přetočit po přehrání.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

Tento příklad v Pythonu ukazuje, jak přidat nový audio rámec s vloženým zvukem, oříznout jej a nastavit dobu proslábnutí:

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

Níže uvedený ukázkový kód ukazuje, jak získat audio rámec s vloženým zvukem a nastavit jeho hlasitost na 85 %:

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

## **Správa titulků zvuku**

Aspose.Slides vám umožňuje přidávat uzavřené titulky k audio rámci pomocí metody [getCaptionTracks](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#getCaptionTracks). Tato metoda vrací [CaptionsCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/captionscollection/), který vám umožňuje přidávat WebVTT stopy titulků, procházet existující stopy a odstraňovat je podle potřeby.

**Přidání titulků zvuku**

Použijte metodu [getCaptionTracks](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#getCaptionTracks), abyste připojili jednu nebo více stop titulků k audio rámci. V následujícím příkladu je zvukový soubor přidán do snímku a poté je nová stopa titulků načtena ze souboru `.vtt`.

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

**Extrahování titulků zvuku**

Můžete procházet stopy titulků přiřazené k audio rámci a uložit je jako soubory `.vtt`. Každá stopa titulků poskytuje svá binární data a jedinečný identifikátor, který lze použít při exportu titulků.

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

**Odstranění titulků zvuku**

Chcete-li odstranit titulky z audio rámce, použijte metody poskytované [CaptionsCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/captionscollection/), např. [clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/cs/python-java/aspose.slides/captionscollection/#remove), nebo [removeAt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/captionscollection/#removeAt). Následující příklad odstraňuje všechny stopy titulků z audio rámce.

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

## **Extrahování zvuku**

Aspose.Slides pro Python přes Java vám umožňuje extrahovat zvuk použitý v přechodech prezentace. Například můžete extrahovat zvuk použitý v konkrétním snímku.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte prezentaci obsahující zvuk.
2. Získejte odkaz na příslušný snímek podle jeho indexu.
3. Přistupte k [slideshow transitions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#getSlideShowTransition) pro snímek.
4. Extrahujte zvuk jako bajtová data.

Tento kód v Pythonu ukazuje, jak extrahovat zvuk použitý v snímku:

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

**Mohu znovu použít stejný zvukový zdroj na více snímcích, aniž by se zvětšila velikost souboru?**

Ano. Přidejte zvuk jednou do sdílené [audio collection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getAudios) prezentace a vytvořte další audio rámce, které odkazují na tento existující zdroj. Tím se zabrání duplikaci multimediálních dat a velikost prezentace zůstane pod kontrolou.

**Mohu nahradit zvuk v existujícím audio rámci, aniž bych znovu vytvářel tvar?**

Ano. U propojeného zvuku aktualizujte [link path](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setLinkPathLong), aby ukazoval na nový soubor. U vloženého zvuku vyměňte objekt [embedded audio](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/#setEmbeddedAudio) za jiný z [audio collection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getAudios) prezentace. Formátování rámce a většina nastavení přehrávání zůstane nedotčena.

**Mění ořezávání podkladová audio data uložená v prezentaci?**

Ne. Ořezávání upravuje pouze hranice přehrávání. Původní audio bajty zůstávají nedotčeny a jsou přístupné přes vložený zvuk nebo audio kolekci prezentace.