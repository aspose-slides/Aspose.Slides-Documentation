---
title: Spravovat video rámečky v prezentacích pomocí Pythonu
linktitle: Video rámeček
type: docs
weight: 10
url: /cs/python-java/video-frame/
keywords:
- přidat video
- vytvořit video
- vložit video
- extrahovat video
- získat video
- video rámeček
- webový zdroj
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se programově přidávat a extrahovat video rámečky v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro Python přes Java. Rychlý průvodce jak na to."
---
## **Úvod**

Videa mohou pomoci vysvětlit myšlenky a zaujmout publikum. Aspose.Slides pro Python přes Java vám umožňuje přidávat video rámečky do snímků, upravovat nastavení přehrávání, spravovat titulky a extrahovat vložená video data.

PowerPoint podporuje místní videa i odkazy na online videa, jako jsou videa na YouTube.

Pro reprezentaci video dat a video rámečků poskytuje Aspose.Slides třídu [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) , třídu [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) a další relevantní typy.

## **Vytvořit vložený video rámec**

Pokud je video soubor, který chcete do snímku přidat, uložen lokálně, můžete vytvořit video rámec pro vložení videa do vaší prezentace.

Tento příklad vloží místní video do prvního snímku existující prezentace a uloží výsledek. Souřadnice a rozměry rámečku jsou v bodech. Python načte video bajty z disku a JPype je převede na Java pole bajtů před tím, než je video přidáno do prezentace.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video)

    presentation.save("embedded_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Můžete také předat cestu k místnímu videu přímo metodě [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). Tento příklad vloží video do prvního snímku nové prezentace. Video musí zůstat přístupné až do uložení prezentace.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vytvořit video rámec s videem z webového zdroje**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) podporuje online videa v prezentacích. Můžete vytvořit video rámec, který odkazuje na online video, například na video z YouTube.

Tento příklad přidá odkaz na YouTube video a miniaturu do prvního snímku. Nahraďte identifikátor videa, pokud chcete použít jiné video. Metoda [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) požaduje automatické přehrávání. Stažení miniatury a přehrání videa vyžaduje připojení k internetu. Prohlížeč prezentací také musí podporovat přehrávání online videí.

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_id = "aqz-KE-bpKQ"
    video_url = "https://www.youtube.com/embed/" + video_id
    video_frame = slide.getShapes().addVideoFrame(10, 10, 427, 240, video_url)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    thumbnail_url = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
    thumbnail = presentation.getImages().addImage(java_thumbnail_data)
    video_frame.getPictureFormat().getPicture().setImage(thumbnail)

    presentation.save("online_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Přehrát video v režimu celé obrazovky**

V tréninkové prezentaci můžete přehrávat ukázku softwaru v režimu celé obrazovky, aby publikum vidělo detaily. Zavolejte [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) s hodnotou `True`, abyste během přehrávání povolili toto chování.

Tento příklad otevře prezentaci, najde první [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) na prvním snímku a povolí přehrávání na celou obrazovku. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video rámcem na prvním snímku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setFullScreenMode(True)
            break

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Přehrávání na celou obrazovku řídí, jak je video zobrazeno. Samostatně [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) určuje, zda se spustí automaticky nebo po kliknutí, a [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) určuje, zda se opakuje. Pro výběr chování při spuštění nastavte režim přehrávání na [VideoPlayModePreset.Auto nebo VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). Příklad zachovává stávající nastavení spuštění a smyčky.

## **Přetočit video po přehrání**

V tréninkové prezentaci vrácení demonstračního videa na začátek jej připraví pro opětovné přehrání prezentátorem. Zavolejte [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) s hodnotou `True`, aby se video po ukončení přehrávání vrátilo na začátek.

Tento příklad otevře prezentaci, najde první [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) na prvním snímku a povolí přetočení. Vypne smyčkování, aby přehrávání mohlo skončit, a nastaví přehrávání tak, aby se spouštělo po kliknutí. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video rámcem na prvním snímku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame, VideoPlayModePreset

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setRewindVideo(True)
            shape.setPlayLoopMode(False)
            shape.setPlayMode(VideoPlayModePreset.OnClick)
            break

    presentation.save("rewind_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Přetočení vrátí video na začátek, aniž by jej znovu spustilo. Naopak volání [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) s hodnotou `True` opakuje přehrávání automaticky. Vypněte smyčkování, pokud chcete, aby video skončilo a zůstalo připraveno k opětovnému přehrání. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) samostatně řídí automatické nebo na‑kliknutí spuštění; tento příklad používá [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) , takže prezentátor řídí, kdy se přehrávání spustí. Nastavte režim přehrávání po nastavení smyčky, jak je ukázáno v příkladu. Přetočení funguje nezávisle na [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Oříznout video rámec**

Použijte [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) a [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) k přeskočení části začátku nebo konce videa během přehrávání. Obě hodnoty jsou v milisekundách. Oříznutí mění nastavení přehrávání, aniž by měnilo vložená video data.

**Nastavit nastavení oříznutí**

Tento příklad vloží místní video a během přehrávání přeskočí první 2,5 sekundy a poslední sekundu. Použijte video delší než 3,5 sekundy, aby zůstalo přehratelné segment.

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

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Přečíst nastavení oříznutí**

Tento příklad vypíše hodnoty oříznutí prvního video rámce na prvním snímku v milisekundách. Prezentace musí obsahovat alespoň jeden snímek. Pokud tento snímek nemá video rámec, nic se nevyptí. Předchozí příklad produkuje hodnoty 2500 a 1000.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **Spravovat titulky videa**

Aspose.Slides vám umožňuje spravovat skryté titulky pro video rámečky v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou dostupné prostřednictvím metody [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks).

### **Přidat titulky do video rámce**

Tento příklad vloží místní video a přidá stopu WebVTT titulků označenou English. Časové značky titulků by měly odpovídat videu. Uložená prezentace obsahuje jak video, tak jeho titulky.

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

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Přidejte novou stopu titulků ze souboru WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Třída [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) také poskytuje přetížení, které umožňuje přidat titulky ze streamu.

### **Extrahovat titulky z video rámce**

Tento příklad uloží všechny stopy titulků z video rámců na prvním snímku jako samostatné soubory WebVTT. Pořadová čísla udržují výstupní soubory odlišné. Konzole hlásí počet extrahovaných stop. Prezentace musí obsahovat alespoň jeden snímek.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    track_count = 0
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                track_count += 1
                output_path = Path(f"captions_{track_count}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                output_path.write_bytes(caption_data)

    print(f"Caption tracks extracted: {track_count}")
finally:
    presentation.dispose()
```

Každý objekt [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) odhaluje identifikátor titulků, popisek, binární data a text titulků jako řetězec UTF‑8.

### **Odstranit titulky z video rámce**

Tento příklad odstraní všechny titulky z video rámce na první pozici tvaru na prvním snímku a uloží výsledek. Předpokládá se, že snímek a tvar existují a že tvar je video rámec.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # Odstraňte všechny titulky z video rámce.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Pokud potřebujete odstranit pouze jednu stopu titulků, použijte metody [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) nebo [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) místo [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

### **Vyhledat titulky videa**

[Captions.getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) vrací kompletní stopu WebVTT, včetně hlavičky, časových řádků a textu titulků. Můžete prohledávat titulky v paměti a najít frázi a její časové razítko. Například anglická stopa na snímku 2 může obsahovat následující text.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Tento příklad otevírá `captioned_media.pptx` a používá [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) k načtení stop každého hlavního video rámce na každém snímku. V prostém textovém cue časová řádka obsahuje `-->` a prázdný řádek ukončuje cue. Pro každý titulek obsahující „café“ v libovolném písmu, příklad vypíše číslo snímku, popisek stopy, originální časovou řádku a celý titulek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("captioned_media.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, VideoFrame):
                continue
            for track in shape.getCaptionTracks():
                track_text = str(track.getDataAsString())
                lines = iter(track_text.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue
                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)
                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.getSlideNumber()} | {track.getLabel()} | {timing}")
                        print(caption)
finally:
    presentation.dispose()
```

Vyhledávání „café“ produkuje jeden výsledek pro ukázkovou stopu. Vyhledávání vylučuje hlavičku stopy a zachovává časové nastavení a zalomení řádků ve výstupu.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extrahovat video ze snímku**

Kromě přidávání videí do snímků umožňuje Aspose.Slides extrahovat videa vložená v prezentacích.

Tento příklad extrahuje vložená videa ze všech snímků do samostatných, číslovaných binárních souborů. Propojená videa jsou přeskočena, protože nemají vložená data. Konzole vypíše MIME typ každého videa a celkový počet. Výstup používá obecnou příponu `.bin`; v případě potřeby ji změňte tak, aby odpovídala hlášenému typu média.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("presentation_with_videos.pptx")
try:
    video_count = 0
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = Path(f"extracted_video_{video_count}.bin")
                video_data = bytes(video.getBinaryData())
                output_path.write_bytes(video_data)
                print(f"Video {video_count}: {video.getContentType()}")

    print(f"Embedded videos extracted: {video_count}")
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Jaké parametry přehrávání videa lze změnit pro video rámec?**

Můžete řídit [režim přehrávání](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (auto nebo po kliknutí) a [opakování](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode). Tyto možnosti jsou dostupné prostřednictvím metod objektu [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) .

**Zvyšuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte místní video, binární data jsou zahrnuta do dokumentu, takže velikost prezentace roste úměrně velikosti souboru. Když odkazujete na online video a přidáte miniaturu, prezentace uloží odkaz a náhledový obrázek místo video dat, takže nárůst velikosti je obvykle menší.

**Mohu nahradit video v existujícím video rámci bez změny jeho polohy a velikosti?**

Ano. Můžete vyměnit [video obsah](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) v rámci při zachování geometrie tvaru; jedná se o běžný scénář pro aktualizaci médií v existujícím rozložení.

**Lze určit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [typ obsahu](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType), který můžete přečíst a použít, například při ukládání na disk.