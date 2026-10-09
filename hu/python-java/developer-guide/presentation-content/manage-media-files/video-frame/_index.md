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
description: "Tanulja meg programozottan videókeretek hozzáadását és kinyerését PowerPoint és OpenDocument diákon az Aspose.Slides for Python via Java használatával. Gyors útmutató."
---
## **Bevezetés**

A videók segíthetnek a gondolatok magyarázatában és a közönség bevonásában. Az Aspose.Slides for Python via Java lehetővé teszi videókeretek hozzáadását a diákhoz, a lejátszási beállítások módosítását, feliratok kezelését és a beágyazott videóadatok kinyerését.

A PowerPoint támogatja a helyi videókat és az online videókra mutató hivatkozásokat, például a YouTube videókat.

A videóadatok és videókeretek ábrázolásához az Aspose.Slides a [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) osztályt, a [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) osztályt és egyéb releváns típusokat biztosít.

## **Beágyazott videókeret létrehozása**

Ha a diára felvenni kívánt videófájl helyileg van tárolva, létrehozhat egy videókeretet a videó prezentációba ágyazásához.

Ez a példa egy helyi videót ágyaz be egy meglévő prezentáció első diájára, majd elmenti az eredményt. A keret koordinátái és méretei pontban vannak megadva. A Python a videó bájtjait a lemezről olvassa, a JPype ezeket Java byte tömbbé alakítja, mielőtt a videó a prezentációba kerül.

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

A helyi videó útvonalát közvetlenül átadhatja a [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame) metódusnak is. Ez a példa a videót egy új prezentáció első diájára ágyazza be. A videónak elérhetőnek kell maradnia, amíg a prezentáció mentésre kerül.

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

## **Videókeret létrehozása webes forrásból származó videóval**

A Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) támogatja az online videókat a prezentációkban. Létrehozhat egy videókeretet, amely egy online videóra, például egy YouTube videóra hivatkozik.

Ez a példa egy YouTube videó hivatkozást és előnézeti képet ad az első diához. Cserélje le a videóazonosítót egy másik videó használatához. A [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) metódus automatikus lejátszást kér. Az előnézeti kép letöltése és a videó lejátszása internetkapcsolatot igényel. A prezentáció megjelenítőnek szintén támogatnia kell az online videó lejátszást.

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

## **Videó lejátszása teljes képernyős módban**

Képzési prezentációban szoftverdemonstrációt játszhat le teljes képernyős módban, hogy a közönség lássa a részleteket. Hívja meg a [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) metódust `True` értékkel a lejátszás során e viselkedés engedélyezéséhez.

Ez a példa megnyit egy prezentációt, megtalálja az első [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) elemet az első dián, és engedélyezi a teljes képernyős lejátszást. A bemeneti prezentációnak legalább egy olyan diát kell tartalmaznia, amelyen az első dián egy meglévő videókeret található.

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

A teljes képernyős lejátszás szabályozza, hogy a videó hogyan jelenik meg. Függetlenül, a [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) határozza meg, automatikusan vagy kattintásra indul-e, a [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) pedig azt, hogy ismétlődik-e. A kezdési viselkedés kiválasztásához állítsa a lejátszási módot a [VideoPlayModePreset.Auto vagy VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). A példa megőrzi a meglévő indítási és ismétlődési beállításokat.

## **Videó visszatekerése lejátszás után**

Képzési prezentációban a demonstrációs videó elejére való visszatekerése lehetővé teszi, hogy az előadó újra lejátszhassa. Hívja meg a [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) metódust `True` értékkel, hogy a lejátszás befejezése után a videó visszatérjen a kezdethez.

Ez a példa megnyit egy prezentációt, megtalálja az első [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) elemet az első dián, és engedélyezi a visszatekerést. Letiltja az ismétlést, hogy a lejátszás befejeződhessen, és beállítja, hogy kattintásra kezdődjön. A bemeneti prezentációnak legalább egy olyan diát kell tartalmaznia, amelyen az első dián egy meglévő videókeret található.

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

A visszatekerés visszaállítja a videót a kezdetére anélkül, hogy újra elindulna. Ezzel szemben a [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) `True` értékkel való meghívása automatikusan ismétli a lejátszást. Tartsa letiltva az ismétlést, ha azt szeretné, hogy a videó befejeződjön, és készen álljon az újrajátszásra. A [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) függetlenül szabályozza az automatikus vagy kattintásra történő indítást; ez a példa a [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) értéket használja, így az előadó szabályozza a lejátszás kezdődését. Állítsa be a lejátszási módot az ismétlődési beállítás után, ahogy a példában látható. A visszatekerés független a [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) beállítástól.

## **Videókeret vágása**

Használja a [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) és a [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) metódusokat, hogy a lejátszás során kihagyja a videó elejének vagy végének egy részét. Mindkét érték ezredmásodpercben van megadva. A vágás módosítja a lejátszási beállításokat anélkül, hogy a beágyazott videó adatokat megváltoztatná.

**Trim beállítások beállítása**

Ez a példa beágyaz egy helyi videót, és a lejátszás során kihagyja az első 2,5 másodpercet és az utolsó egy másodpercet. Használjon 3,5 másodpercnél hosszabb videót, hogy maradjon lejátszható szegmens.

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

**Trim beállítások kiolvasása**

Ez a példa kiírja az első videókeret trim értékeit az első dián ezredmásodpercben. A prezentációnak legalább egy diát kell tartalmaznia. Ha az a dia nem tartalmaz videókeretet, semmi sem kerül kiírásra. Az előző példa 2500 és 1000 értékeket állít elő.

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

Az Aspose.Slides lehetővé teszi a videókeretekhez tartozó zárt feliratok kezelését PowerPoint prezentációkban. A feliratok WebVTT formátumban vannak tárolva, és a [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) metóduson keresztül érhetők el.

**Feliratok hozzáadása videókerethez**

Ez a példa beágyaz egy helyi videót, és hozzáad egy English (angol) címkéjű WebVTT felirat sávot. A felirat időbélyegeinek meg kell egyezniük a videóval. A mentett prezentáció tartalmazza mind a videót, mind a feliratokat.

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

    # Új feliratsáv hozzáadása WebVTT fájlból.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) osztály további túlterhelést biztosít, amely lehetővé teszi a feliratok stream‑ből történő hozzáadását.

**Feliratok kinyerése videókeretből**

Ez a példa az első dián lévő videókeretek összes feliratsávját különálló WebVTT fájlként menti. A sorozatszámok megtartják a kimeneti fájlok egyediségét. A konzol jelzi a kinyert sávok számát. A prezentációnak legalább egy diát kell tartalmaznia.

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

Minden [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) objektum megjeleníti a felirat azonosítóját, címkéjét, bináris adatát és a felirat szövegét UTF‑8 karakterláncként.

**Feliratok eltávolítása videókeretből**

Ez a példa eltávolítja az összes feliratot az első dián az első alakzat pozíciójában lévő videókeretből, és elmenti az eredményt. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat videókeret.

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
        # Távolítsa el az összes feliratot a videókeretről.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Ha csak egy feliratsávot szeretne eltávolítani, használja a [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) vagy a [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) metódust a [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) helyett.

## **Videó kinyerése diáról**

A videók diákhoz adása mellett az Aspose.Slides lehetővé teszi a prezentációkba beágyazott videók kinyerését.

Ez a példa minden diáról kinyeri a beágyazott videókat különálló, számozott bináris fájlokba. A hivatkozott videók átugrásra kerülnek, mivel nincs beágyazott adatuk. A konzol kiírja minden videó MIME‑típusát és a teljes számot. A kimenet a generikus `.bin` kiterjesztést használja; szükség esetén módosítsa a jelentett média típussal egyezőre.

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

## **GYIK**

**Mely videólejátszási paraméterek módosíthatók egy videókeret esetén?**

A [lejátszási mód](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (automatikus vagy kattintásra) és a [ismétlés](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) szabályozható. Ezek a lehetőségek a [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) objektum metódusain keresztül érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájl méretét?**

Igen. Ha helyi videót ágyaz be, a bináris adat a dokumentumba kerül, így a prezentáció mérete arányosan nő a fájl méretével. Ha online videóra hivatkozik és előnézeti képet ad hozzá, a prezentáció csak a hivatkozást és a képet tárolja, nem a videó adatot, ezért a méretnövekedés általában kisebb.

**Lecserélhetem a videót egy meglévő videókeretben anélkül, hogy megváltoztatnám a pozícióját és méretét?**

Igen. A kereten belül cserélheti a [video content](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) elemet, miközben a forma geometria megtartja; ez gyakori eset a média frissítésére egy meglévő elrendezésben.

**Megállapítható a beágyazott videó tartalom típusa (MIME)?**

Igen. Egy beágyazott videó rendelkezik a [tartalom típusa](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) értékkel, amelyet kiolvashat és felhasználhat, például a lemezre mentéskor.