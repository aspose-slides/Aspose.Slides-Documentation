---
title: Správa video rámců v prezentacích pomocí Pythonu
linktitle: Video rámec
type: docs
weight: 10
url: /cs/python-java/video-frame/
keywords:
- přidat video
- vytvořit video
- vložit video
- extrahovat video
- získat video
- video rámec
- webový zdroj
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se programově přidávat a extrahovat video rámy v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro Python přes Java. Rychlý návod."
---
## **Úvod**

Dobře umístěné video v prezentaci může učinit vaši zprávu přesvědčivější a zvýšit úroveň zapojení publika.

PowerPoint umožňuje přidávat videa do snímku v prezentaci dvěma způsoby:

* Přidat nebo vložit místní video (uložené ve vašem počítači)
* Přidat online video (z webového zdroje, například YouTube).

Pro umožnění přidání videí (videoobjektů) do prezentace Aspose.Slides poskytuje třídu [Video](https://reference.aspose.com/slides/cs/python-java/aspose.slides/video/) , třídu [VideoFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/) a další související typy.

## **Vytvoření vložených video rámců**

Pokud je video soubor, který chcete přidat do snímku, uložen lokálně, můžete vytvořit video rámec pro vložení videa do vaší prezentace.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte objekt [Video](https://reference.aspose.com/slides/cs/python-java/aspose.slides/video/) a předávejte data video souboru k vložení videa do prezentace.
4. Přidejte objekt [VideoFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/) pro vytvoření rámce videa.
5. Uložte upravenou prezentaci.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Alternativně můžete přidat video předáním jeho cesty k souboru přímo metodě [addVideoFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addVideoFrame):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```

## **Vytvoření video rámců s videem z webových zdrojů**

Microsoft [PowerPoint 2013 a novější](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) podporují videa z YouTube v prezentacích. Pokud je video, které chcete použít, dostupné online (např. na YouTube), můžete jej přidat do prezentace pomocí jeho webového odkazu.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte objekt [VideoFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/) a předávejte odkaz na video.
4. Nastavte náhled pro video rámec.
5. Uložte prezentaci.

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # Načíst miniaturu.
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Oříznutí video rámce**

Aspose.Slides umožňuje řídit, která část videa se přehrává, nastavením hodnot trim-from-start a trim-from-end prostřednictvím [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/#setTrimFromStart) a [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/#setTrimFromEnd). Obě hodnoty jsou zadány v milisekundách a určují, kolik času se přeskočí na začátku a konci videa. Tato nastavení mění nastavení přehrávání videa v prezentaci; neřezají ani jinak nemodifikují binární data vloženého videa.

**Nastavení ořezu**

Pro vytvoření video rámce a nastavení jeho ořezu:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Přidejte objekt [Video](https://reference.aspose.com/slides/cs/python-java/aspose.slides/video/) do prezentace.
3. Přidejte objekt [VideoFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/) na snímek.
4. Nastavte hodnoty trim-from-start a trim-from-end pomocí [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/#setTrimFromStart) a [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/#setTrimFromEnd).
5. Uložte upravenou prezentaci.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Čtení nastavení ořezu**

Pro kontrolu existujících nastavení ořezu načtěte prezentaci, najděte objekt [VideoFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/) mezi tvary na prvním snímku a přečtěte hodnoty pomocí [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/#getTrimFromStart) a [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/#getTrimFromEnd).

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

## **Správa titulků videa**

Aspose.Slides umožňuje spravovat uzavřené titulky pro video rámce v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou přístupné přes metodu [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/#getCaptionTracks).

**Přidání titulků do video rámce**

Pro přidání titulků do video rámce:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Přidejte video do prezentace.
3. Přidejte objekt [VideoFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/) na snímek.
4. Použijte [CaptionsCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/captionscollection/) vrácený metodou [getCaptionTracks](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/#getCaptionTracks) k přidání WebVTT titulkové stopy.
5. Uložte upravenou prezentaci.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Přidejte novou stopu titulků z WebVTT souboru.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Třída [CaptionsCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/captionscollection/) také poskytuje přetížení, které umožňuje přidat titulky ze streamu.

**Extrahování titulků z video rámce**

Pro extrahování titulků z video rámce:

1. Načtěte prezentaci, která obsahuje video.
2. Najděte cílový objekt [VideoFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/).
3. Iterujte přes titulkové stopy v [CaptionsCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/captionscollection/).
4. Uložte každou titulkovou stopu do souboru `.vtt`.

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
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # Uložit stopu titulků do souboru WebVTT.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

Každý objekt [Captions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/captions/) expose identifikátor titulu, štítek, binární data a text titulu jako řetězec UTF-8.

**Odstranění titulků z video rámce**

Pro odstranění titulků z video rámce:

1. Načtěte prezentaci, která obsahuje video.
2. Získejte cílový objekt [VideoFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/).
3. Odstraňte titulkové stopy z [CaptionsCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/captionscollection/).
4. Uložte upravenou prezentaci.

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
        # Odstranit všechny titulky z video rámce.
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Pokud potřebujete odstranit jen jednu titulkovou stopu, použijte metody [remove](https://reference.aspose.com/slides/cs/python-java/aspose.slides/captionscollection/#remove) nebo [removeAt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/captionscollection/#removeAt) místo [clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/captionscollection/#clear).

## **Extrahování videa ze snímků**

Kromě přidávání videí do snímků Aspose.Slides umožňuje extrahovat videa vložená v prezentacích.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/), aby se načetla prezentace obsahující video.
2. Iterujte přes všechny objekty [Slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/).
3. Iterujte přes všechny objekty [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/), abyste našli [VideoFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/).
4. Uložte video na disk.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Které parametry přehrávání videa lze změnit pro VideoFrame?**

Můžete řídit [playback mode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/#setPlayMode) (automaticky nebo po kliknutí) a [looping](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/#setPlayLoopMode). Tyto možnosti jsou dostupné přes vlastnosti objektu [VideoFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/).

**Ovlivňuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte místní video, binární data jsou zahrnuta do dokumentu, takže velikost prezentace roste úměrně velikosti souboru. Když přidáte online video, vloží se odkaz a náhled, takže nárůst velikosti je menší.

**Mohu nahradit video v existujícím VideoFrame bez změny jeho pozice a velikosti?**

Ano. Můžete vyměnit [video content](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/#setEmbeddedVideo) uvnitř rámce při zachování geometrie tvaru; toto je běžný scénář pro aktualizaci médií v existujícím rozvržení.

**Lze určit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [content type](https://reference.aspose.com/slides/cs/python-java/aspose.slides/video/#getContentType), který lze přečíst a použít, například při ukládání na disk.