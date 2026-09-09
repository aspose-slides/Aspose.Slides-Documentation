---
title: Videókeretek kezelése prezentációkban Python használatával
linktitle: Videókeret
type: docs
weight: 10
url: /hu/python-java/video-frame/
keywords:
  - videó hozzáadása
  - videó létrehozása
  - videó beágyazása
  - videó kinyerése
  - videó lekérése
  - videókeret
  - webes forrás
  - PowerPoint
  - OpenDocument
  - prezentáció
  - Python
  - Aspose.Slides
description: "Tanulja meg programozott módon videókeretek hozzáadását és kinyerését PowerPoint és OpenDocument diákban az Aspose.Slides for Python via Java használatával. Gyors útmutató."
---
## **Bevezetés**

Egy jól elhelyezett videó a prezentációban meggyőzőbbé teheti az üzenetedet, és növelheti a közönség elköteleződését.

A PowerPoint lehetővé teszi, hogy videókat adj hozzá egy diára a prezentációban két módon:

* Helyi videó hozzáadása vagy beágyazása (a gépeden tárolt)
* Online videó hozzáadása (webes forrásból, például a YouTube‑ról).

Ahhoz, hogy videókat (videoobjektumokat) adhass a prezentációhoz, az Aspose.Slides biztosítja a [Video](https://reference.aspose.com/slides/hu/python-java/aspose.slides/video/) osztályt, a [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) osztályt és a többi kapcsolódó típust.

## **Beágyazott videókeretek létrehozása**

Ha a diára felvenni kívánt videófájl helyileg van tárolva, létrehozhatsz egy videókeretet a videó prezentációba való beágyazásához.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezz referenciát egy diára az indexe alapján.
1. Adj hozzá egy [Video](https://reference.aspose.com/slides/hu/python-java/aspose.slides/video/) objektumot, és add át a videófájl adatát a videó prezentációba való beágyazásához.
1. Adj hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) objektumot a videó keretének létrehozásához.
1. Mentsd el a módosított prezentációt.

Ez a Python kód megmutatja, hogyan adhatsz hozzá egy helyileg tárolt videót a prezentációhoz:

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

Alternatívaként egy videót is hozzáadhatsz úgy, hogy a fájl útvonalát közvetlenül az [addVideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addVideoFrame) metódusnak adod át:

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

## **Videókeretek létrehozása webes forrásból származó videóval**

A Microsoft [PowerPoint 2013 és újabb](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) támogatja a YouTube‑videókat a prezentációkban. Ha a felhasználandó videó online érhető el (például a YouTube‑on), a webes hivatkozásával adhatod hozzá a prezentációhoz.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezz referenciát egy diára az indexe alapján.
1. Adj hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) objektumot, és add meg a videó hivatkozását.
1. Állíts be egy bélyegképet a videókerethez.
1. Mentsd el a prezentációt.

Ez a Python kód megmutatja, hogyan adhatsz hozzá egy webes videót egy PowerPoint diasorhoz:

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

    # Betölti a bélyegképet.
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

## **Videókeret vágása**

Az Aspose.Slides lehetővé teszi, hogy a videó lejátszott részét úgy szabályozd, hogy a trim-from-start és trim-from-end értékeket állítsd be a [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#setTrimFromStart) és a [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#setTrimFromEnd) segítségével. Mindkét érték ezredmásodpercben van megadva, és meghatározza, mennyi időt hagy ki a videó elejéről és végéről. Ezek a beállítások a videó lejátszási beállításait módosítják a prezentációban; nem vágják vagy módosítják a beágyazott videó bináris adatát.

**Trim beállítások beállítása**

Videókeret létrehozásához és a trim beállításainak megadásához:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Adj hozzá egy [Video](https://reference.aspose.com/slides/hu/python-java/aspose.slides/video/) objektumot a prezentációhoz.
1. Adj hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) objektumot egy diára.
1. Állítsd be a trim-from-start és trim-from-end értékeket a [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#setTrimFromStart) és a [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#setTrimFromEnd) segítségével.
1. Mentsd el a módosított prezentációt.

A következő kódrészlet kihagyja a beágyazott videó első 2,5 másodpercét és az utolsó másodpercét a lejátszás során:

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

**Trim beállítások beolvasása**

A meglévő trim beállítások ellenőrzéséhez tölts be egy prezentációt, keresd meg a [VideoFrame] objektumot az első dia alakzatai között, és olvasd ki az értékeket a [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#getTrimFromStart) és a [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#getTrimFromEnd) segítségével.

A következő kódrészlet megtalálja az első videókeretet az első dián, és millimásodpercben jelzi a trim beállításait:

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

## **Videó feliratok kezelése**

Az Aspose.Slides lehetővé teszi a videókeretek zárt feliratainak kezelését a PowerPoint prezentációkban. A feliratok WebVTT formátumban tárolódnak, és a [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#getCaptionTracks) metóduson keresztül érhetők el.

**Feliratok hozzáadása videókerethez**

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Adj hozzá egy videót a prezentációhoz.
1. Adj hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) objektumot egy diára.
1. Használd a [CaptionsCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/) gyűjteményt, amelyet a [getCaptionTracks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#getCaptionTracks) visszaad, egy WebVTT feliratnyomtatás hozzáadásához.
1. Mentsd el a módosított prezentációt.

A következő kód megmutatja, hogyan adj feliratokat egy videókerethez:

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

    # Új feliratnyomtatás hozzáadása egy WebVTT fájlból.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A [CaptionsCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/) osztály további overloaddal is rendelkezik, amely lehetővé teszi feliratok hozzáadását egy adatfolyamból.

**Feliratok kinyerése videókeretből**

1. Töltsd be a videót tartalmazó prezentációt.
1. Találd meg a cél [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) objektumot.
1. Iterálj végig a [CaptionsCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/) feliratnyomtatásain.
1. Mentsd el minden feliratnyomtatást egy `.vtt` fájlba.

A következő kód megmutatja, hogyan nyerheted ki a feliratokat egy videókeretből:

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
                # Mentse a feliratnyomtatást egy WebVTT fájlba.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

Minden [Captions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captions/) objektum megjeleníti a felirat azonosítóját, címkéjét, bináris adatát és a felirat szövegét UTF‑8 karakterláncként.

**Feliratok eltávolítása videókeretből**

1. Töltsd be a videót tartalmazó prezentációt.
1. Szerezd meg a cél [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) objektumot.
1. Távolítsd el a feliratnyomtatásokat a [CaptionsCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/) gyűjteményből.
1. Mentsd el a módosított prezentációt.

A következő kód megmutatja, hogyan távolíthatók el az összes felirat egy videókeretből:

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
        # Az összes felirat eltávolítása a videókeretről.
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Ha csak egy feliratrakárt szeretnél eltávolítani, használd a [remove](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/#remove) vagy a [removeAt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/#removeAt) metódust a [clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/#clear) helyett.

## **Videó kinyerése diákból**

A videók diákhoz való hozzáadása mellett az Aspose.Slides lehetővé teszi a prezentációkban beágyazott videók kinyerését.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból a videót tartalmazó prezentáció betöltéséhez.
2. Iterálj végig az összes [Slide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/) objektumon.
3. Iterálj végig az összes [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) objektumon, hogy megtaláld a [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) elemet.
4. Mentsd el a videót a lemezen.

Ez a Python kód megmutatja, hogyan nyerheted ki a videót egy prezentációs diáról:

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

## **FAQ**

**Mely videólejátszási paraméterek módosíthatók egy VideoFrame esetén?**

A [playback mode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#setPlayMode) (automata vagy kattintásra) és a [looping](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#setPlayLoopMode) beállításait szabályozhatod. Ezek az opciók a [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) objektum tulajdonságain keresztül érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájl méretét?**

Igen. Ha helyi videót ágyazol be, a bináris adat a dokumentumba kerül, így a prezentáció mérete arányosan nő a fájlmérettel. Online videó hozzáadásakor egy hivatkozás és egy bélyegkép kerül beágyazásra, ezért a méretnövekedés kisebb.

**Lecserélhetem egy meglévő VideoFrame videóját anélkül, hogy megváltoztatnám a pozícióját és méretét?**

Igen. A [video content](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#setEmbeddedVideo) cseréjével a keretben megőrizheted az alakzat geometriáját; ez gyakori forgatókönyv a meglévő elrendezés média frissítéséhez.

**Megállapítható a beágyazott videó tartalomtípusa (MIME)?**

Igen. A beágyazott videó rendelkezik egy [content type](https://reference.aspose.com/slides/hu/python-java/aspose.slides/video/#getContentType) értékkel, amelyet kiolvashatsz és felhasználhatsz, például a lemezre mentéskor.