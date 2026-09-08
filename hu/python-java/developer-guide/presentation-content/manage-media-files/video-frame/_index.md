---
title: Videókeretek kezelése előadásokban Python segítségével
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
description: "Tanulja meg, hogyan adhat hozzá és nyerhet ki programozott módon videókereteket PowerPoint és OpenDocument diákban az Aspose.Slides for Python via Java segítségével. Gyors útmutató."
---
## **Bevezetés**

Egy megfelelően elhelyezett videó egy előadásban megragadhatóbbá teheti az üzenetet, és növelheti a közönség bevonódását.

A PowerPoint két módon teszi lehetővé a videók hozzáadását egy diára az előadásban:
* Helyi videó hozzáadása vagy beágyazása (a gépén tárolt)
* Online videó hozzáadása (webes forrásból, például a YouTube-ról).

A videók (video objektumok) előadáshoz való hozzáadásához az Aspose.Slides biztosítja a [Video](https://reference.aspose.com/slides/hu/python-java/aspose.slides/video/) osztályt, a [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) osztályt, és egyéb kapcsolódó típusokat.

## **Beágyazott videókeretek létrehozása**

Ha a diára felvenni kívánt videofájl helyileg van tárolva, létrehozhat egy videókeretet a videó előadáshoz ágyazásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg a dia referenciaját az indexe alapján.
3. Adjon hozzá egy [Video](https://reference.aspose.com/slides/hu/python-java/aspose.slides/video/) objektumot, és adja át a videofájl adatát a videó előadáshoz való beágyazásához.
4. Adjon hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) objektumot a videó keretének létrehozásához.
5. Mentse el a módosított előadást.

Ez a Python kód bemutatja, hogyan adjon hozzá egy helyileg tárolt videót egy előadáshoz:

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

Alternatívaként egy videót a fájl útvonalának közvetlen átadásával is hozzáadhat a [addVideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addVideoFrame) metódusnak:

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

A Microsoft [PowerPoint 2013 és újabb](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) támogatja a YouTube videókat az előadásokban. Ha a használni kívánt videó online elérhető (például a YouTube-on), hozzáadhatja az előadáshoz a webes hivatkozásán keresztül.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból
2. Szerezze meg a dia referenciaját az indexe alapján.
3. Adjon hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) objektumot, és adja át a videó hivatkozását.
4. Állítson be egy előképet a videókerethez.
5. Mentse el az előadást.

Ez a Python kód bemutatja, hogyan adjon hozzá egy webes videót egy diára a PowerPoint előadásban:

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

    # A bélyegkép betöltése.
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

Az Aspose.Slides lehetővé teszi, hogy a videó lejátszott részét a trim-from-start és trim-from-end értékek beállításával szabályozza a [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#setTrimFromStart) és [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#setTrimFromEnd) metódusok segítségével. Mindkét érték ezredmásodpercben van megadva, és meghatározza, mennyi időt hagy ki a videó elejéről és végéről. Ezek a beállítások a lejátszási beállításokat módosítják az előadásban; nem vágják vagy módosítják a beágyazott videó bináris adatát.

**Trim beállítások beállítása**

Videókeret létrehozásához és a trim beállításainak megadásához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Adjon hozzá egy [Video](https://reference.aspose.com/slides/hu/python-java/aspose.slides/video/) objektumot az előadáshoz.
3. Adjon hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) objektumot egy diára.
4. Állítsa be a trim-from-start és trim-from-end értékeket a [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#setTrimFromStart) és [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#setTrimFromEnd) metódusokkal.
5. Mentse el a módosított előadást.

Az alábbi kódrészlet kihagyja az első 2,5 másodpercet és az utolsó másodpercet egy beágyazott videó lejátszása közben:

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

**Trim beállításainak olvasása**

A meglévő trim beállítások ellenőrzéséhez töltsön be egy előadást, találja meg a [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) objektumot az első dia alakzatai között, és olvassa ki az értékeket a [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#getTrimFromStart) és [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#getTrimFromEnd) metódusok segítségével.

Az alábbi kódrészlet megtalálja az első videókeretet az első dián, és milliszekundumban jelzi a trim beállításait:

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

Az Aspose.Slides lehetővé teszi a videókeretekhez tartozó zárt feliratok kezelését PowerPoint előadásokban. A feliratok WebVTT formátumban tárolódnak, és a [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#getCaptionTracks) metóduson keresztül érhetők el.

**Feliratok hozzáadása videókerethez**

Feliratok videókerethez hozzáadásához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Adjon hozzá egy videót az előadáshoz.
3. Adjon hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) objektumot egy diára.
4. Használja a [CaptionsCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/) osztályt, amelyet a [getCaptionTracks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#getCaptionTracks) visszaad, egy WebVTT felirat sáv hozzáadásához.
5. Mentse el a módosított előadást.

Az alábbi kód bemutatja, hogyan adjon feliratokat egy videókerethez:

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

    # Új felirat sáv hozzáadása egy WebVTT fájlból.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A [CaptionsCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/) osztály egy túlterhelést is biztosít, amely lehetővé teszi feliratok hozzáadását egy áramlásból.

**Feliratok kinyerése videókeretből**

Feliratok kinyeréséhez egy videókeretből:

1. Töltsön be egy előadást, amely tartalmazza a videót.
2. Keresse meg a cél [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) objektumot.
3. Iteráljon végig a [CaptionsCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/) felirat sávjain.
4. Mentse el minden felirat sávot egy `.vtt` fájlba.

Az alábbi kód bemutatja, hogyan nyerje ki a feliratokat egy videókeretből:

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
                # A felirat sáv mentése egy WebVTT fájlba.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

Minden [Captions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captions/) objektum tartalmazza a felirat azonosítóját, címkéjét, bináris adatát és a felirat szövegét UTF-8 karakterláncként.

**Feliratok eltávolítása videókeretből**

Feliratok eltávolításához egy videókeretből:

1. Töltsön be egy előadást, amely tartalmazza a videót.
2. Szerezze meg a cél [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) objektumot.
3. Távolítsa el a felirat sávokat a [CaptionsCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/) -ból.
4. Mentse el a módosított előadást.

Az alábbi kód bemutatja, hogyan távolítsa el az összes feliratot egy videókeretből:

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
        # Az összes feliratot eltávolítja a videókeretből.
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Ha csak egy felirat sávot szeretne eltávolítani, használja a [remove](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/#remove) vagy a [removeAt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/#removeAt) metódusokat a [clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/captionscollection/#clear) helyett.

## **Videó kinyerése diákból**

A videók diákhoz való hozzáadása mellett az Aspose.Slides lehetővé teszi a beágyazott videók kinyerését az előadásokból.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból a videót tartalmazó előadás betöltéséhez.
2. Iteráljon végig az összes [Slide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/) objektumon.
3. Iteráljon végig az összes [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) objektumon, hogy megtalálja a [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) objektumot.
4. Mentse el a videót a lemezre.

Ez a Python kód bemutatja, hogyan nyerje ki a videót egy előadásdiáról:

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

**Mely videolejátszási paraméterek módosíthatók egy VideoFrame esetén?**

A [playback mode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#setPlayMode) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#setPlayLoopMode) beállítások szabályozhatók. Ezek a lehetőségek a [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) objektum tulajdonságain keresztül érhetők el.

**Milyen hatással van egy videó hozzáadása a PPTX fájlméretre?**

Igen. Ha helyi videót ágyaz be, a bináris adat a dokumentumba kerül, így az előadás mérete a fájl méretével arányosan növekszik. Ha online videót ad hozzá, csak egy hivatkozás és egy előkép kerül beágyazásra, így a méretnövekedés kisebb.

**Lecserélhetem a videót egy meglévő VideoFrame-ben a pozíció és méret megváltoztatása nélkül?**

Igen. A videót a kereten belül kicserélheti a [video content](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/#setEmbeddedVideo) cseréjével, miközben megőrzi az alakzat geometriáját; ez gyakori eset a média frissítésére egy meglévő elrendezésben.

**Meghatározható egy beágyazott videó tartalomtípusa (MIME)?**

Igen. Egy beágyazott videó rendelkezik egy [content type](https://reference.aspose.com/slides/hu/python-java/aspose.slides/video/#getContentType) (tartalomtípussal), amelyet leolvashat és felhasználhat, például a lemezre mentéskor.