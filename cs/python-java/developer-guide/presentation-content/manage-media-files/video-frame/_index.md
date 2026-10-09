---
title: Spravovat video snímky v prezentacích pomocí Pythonu
linktitle: Video snímek
type: docs
weight: 10
url: /cs/python-java/video-frame/
keywords:
- přidat video
- vytvořit video
- vložit video
- extrahovat video
- získat video
- video snímek
- webový zdroj
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se programově přidávat a extrahovat video snímky v PowerPoint a OpenDocument slidech pomocí Aspose.Slides pro Python přes Java. Rychlý praktický návod."
---
## **Úvod**

Videa mohou pomoci vysvětlit nápady a zapojit publikum. Aspose.Slides pro Python přes Java vám umožňuje přidávat video snímky do slidů, upravovat nastavení přehrávání, spravovat titulky a extrahovat vložená video data.

PowerPoint podporuje místní videa i odkazy na online videa, například videa z YouTube.

Pro reprezentaci video dat a video snímků poskytuje Aspose.Slides třídu [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) , třídu [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) a další relevantní typy.

## **Vytvořit vložený video snímek**

Pokud je video soubor, který chcete přidat do svého slidu, uložen lokálně, můžete vytvořit video snímek k vložení videa do vaší prezentace.

Tento příklad vloží místní video na první slid existující prezentace a uloží výsledek. Souřadnice a rozměry snímku jsou v bodech. Python načte video bajty z disku a JPype je převádí na Java pole bajtů předtím, než je video přidáno do prezentace.

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

Můžete také předat cestu k místnímu videu přímo metodě [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). Tento příklad vloží video na první slid nové prezentace. Video musí zůstat přístupné, dokud není prezentace uložena.

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

## **Vytvořit video snímek s videem z webového zdroje**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) podporuje online videa v prezentacích. Můžete vytvořit video snímek, který odkazuje na online video, například video z YouTube.

Tento příklad přidá odkaz na YouTube video a miniaturu na první slid. Nahraďte identifikátor videa, abyste použili jiné video. Metoda [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) požaduje automatické přehrávání. Stahování miniatury a přehrávání videa vyžaduje přístup k internetu. Prohlížeč prezentace také musí podporovat přehrávání online videí.

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

V tréninkové prezentaci můžete přehrát ukázku softwaru v režimu celé obrazovky, aby publikum vidělo detaily. Zavolejte [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) s `True` pro povolení tohoto chování během přehrávání.

Tento příklad otevře prezentaci, najde první [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) na prvním slidu a povolí přehrávání na celou obrazovku. Vstupní prezentace musí obsahovat alespoň jeden slid s existujícím video snímkem na prvním slidu.

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

Přehrávání na celé obrazovce řídí, jak je video zobrazeno. Samostatně metoda [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) určuje, zda se spustí automaticky nebo po kliknutí, a metoda [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) určuje, zda se opakuje. Pro výběr chování spuštění nastavte režim přehrávání na [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). Příklad zachovává existující nastavení startu a opakování.

## **Přetočit video po přehrání**

V tréninkové prezentaci vrácení demonstračního videa na začátek jej připraví pro opětovné přehrání. Zavolejte [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) s `True`, aby se video po ukončení přehrávání vrátilo na začátek.

Tento příklad otevře prezentaci, najde první [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) na prvním slidu a povolí přetočení. Vypne opakování, aby přehrávání mohlo skončit, a nastaví start na kliknutí. Vstupní prezentace musí obsahovat alespoň jeden slid s existujícím video snímkem na prvním slidu.

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

Přetočení vrací video na jeho začátek, aniž by ho spouštělo znovu. Naopak volání [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) s `True` automaticky opakuje přehrávání. Udržujte opakování zakázáno, pokud chcete, aby video skončilo a zůstalo připraveno k opětovnému přehrání. Metoda [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) samostatně řídí automatické nebo klikací spuštění; tento příklad používá [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/), takže prezentující kontroluje, kdy přehrávání začne. Nastavte režim přehrávání po nastavení opakování, jak je ukázáno v příkladu. Přetočení funguje nezávisle na [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Oříznout video snímek**

Použijte [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) a [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) k přeskočení části začátku nebo konce videa během přehrávání. Obě hodnoty jsou v milisekundách. Ořezávání mění nastavení přehrávání bez úpravy vložených video dat.

**Nastavit ořezání**

Tento příklad vloží místní video a během přehrávání přeskočí první 2,5 s a poslední sekundu. Použijte video delší než 3,5 s, aby zůstala přehratelná část.

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

**Načíst nastavení ořezu**

Tento příklad vypíše hodnoty ořezu prvního video snímku na prvním slidu v milisekundách. Prezentace musí obsahovat alespoň jeden slid. Pokud tento slid nemá video snímek, nic se nevypíše. Předchozí příklad produkuje hodnoty 2500 a 1000.

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

Aspose.Slides vám umožňuje spravovat uzavřené titulky pro video snímky v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou přístupné přes metodu [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks).

**Přidat titulky do video snímku**

Tento příklad vloží místní video a přidá stopu WebVTT titulků označenou jako English. Časové značky titulků by měly odpovídat videu. Uložená prezentace obsahuje jak video, tak jeho titulky.

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

    # Přidat novou stopu titulků ze souboru WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Třída [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) také poskytuje přetížení, které vám umožní přidat titulky ze streamu.

**Extrahovat titulky z video snímku**

Tento příklad uloží všechny stopy titulků z video snímků na prvním slidu jako samostatné soubory WebVTT. Postupná čísla udržují výstupní soubory odlišné. Konzole vypíše počet extrahovaných stop. Prezentace musí obsahovat alespoň jeden slid.

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

Každý objekt [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) vystavuje identifikátor titulků, popisek, binární data a text titulků jako řetězec UTF‑8.

**Odstranit titulky z video snímku**

Tento příklad odstraní všechny titulky z video snímku na první pozici tvaru na prvním slidu a výsledek uloží. Předpokládá, že slid a tvar existují a že tvar je video snímek.

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
        # Odstranit všechny titulky z video snímku.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Pokud potřebujete odstranit jen jednu stopu titulků, použijte metody [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) nebo [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) místo [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

## **Extrahovat video ze slidu**

Kromě přidávání videí do slidů umožňuje Aspose.Slides extrahovat videa vložená v prezentacích.

Tento příklad extrahuje vložená videa ze všech slidů do samostatných, očíslovaných binárních souborů. Propojená videa jsou přeskočena, protože neobsahují vložená data. Konzole vypíše MIME typ každého videa a celkový počet. Výstup používá obecnou příponu `.bin`; změňte ji podle hlášeného typu média, pokud je to potřeba.

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

**Které parametry přehrávání videa lze u video snímku změnit?**

Můžete ovládat [režim přehrávání](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (auto nebo po kliknutí) a [opakování](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode). Tyto možnosti jsou dostupné prostřednictvím metod objektu [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/).

**Zvyšuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte místní video, binární data jsou zahrnuta do dokumentu, takže velikost prezentace roste úměrně velikosti souboru. Když odkazujete na online video a přidáte miniaturu, prezentace uloží jen odkaz a náhledový obrázek místo video dat, takže nárůst velikosti je obvykle menší.

**Mohu nahradit video v existujícím video snímku bez změny jeho polohy a rozměrů?**

Ano. Můžete vyměnit [video content](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) uvnitř snímku a přitom zachovat geometrii tvaru; toto je běžný scénář při aktualizaci médií v existujícím rozvržení.

**Lze určit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [content type](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType), který můžete přečíst a použít, například při ukládání na disk.