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
description: "Tanulja meg, hogyan adhat hozzá és nyerhet ki programozottan videókereteket a PowerPoint és OpenDocument diákban az Aspose.Slides for Python via Java használatával. Gyors útmutató."
---
## **Bevezetés**

A videók segíthetnek az ötletek megmagyarázásában és a közönség bevonásában. Az Aspose.Slides for Python via Java lehetővé teszi videókeretek hozzáadását a diákhoz, a lejátszási beállítások módosítását, a feliratok kezelését és a beágyazott videóadatok kinyerését.

A PowerPoint támogatja a helyi videókat és az online videókra mutató hivatkozásokat, például a YouTube‑videókat.

A videóadatok és videókeretek ábrázolásához az Aspose.Slides a [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) osztályt, a [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) osztályt és más releváns típusokat biztosít.

## **Beágyazott videókeret létrehozása**

Ha a diához hozzáadni kívánt videófájl helyileg van tárolva, létrehozhat egy videókeretet a videó prezentációba ágyazásához.

Ez a példa egy helyi videót ágyaz be a meglévő prezentáció első diájára, és menti az eredményt. A keret koordinátái és méretei pontban vannak megadva. A Python a videó bájtjait lemezről olvassa, a JPype pedig Java‑bájt tömbbé konvertálja, mielőtt a videó a prezentációhoz kerülne.

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

A helyi videó útvonalát közvetlenül is átadhatja az [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame) metódusnak. Ez a példa a videót egy új prezentáció első diájára ágyazza be. A videónak elérhetőnek kell maradnia a prezentáció mentése előtt.

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

A Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) támogatja az online videókat a prezentációkban. Létrehozhat egy videókeretet, amely egy online videóra, például egy YouTube‑videóra mutat.

Ez a példa hozzáad egy YouTube‑videó hivatkozást és bélyegképet az első diához. Cserélje ki a videóazonosítót, ha másik videót akar használni. A [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) metódus automatikus lejátszást kér. A bélyegkép letöltése és a videó lejátszása internetkapcsolatot igényel. A prezentáció megjelenítőnek szintén támogatnia kell az online videó lejátszását.

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

## **Videó lejátszása teljes képernyő módjában**

Egy képzési prezentációban lejátszhat egy szoftverbemutatót teljes képernyő módban, hogy a közönség lássa a részleteket. Hívja meg a [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) metódust `True` értékkel, hogy ezt a viselkedést a lejátszás során engedélyezze.

Ez a példa megnyit egy prezentációt, megkeresi az első [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) elemet az első dián, és engedélyezi a teljes képernyős lejátszást. A bemeneti prezentációnak legalább egy diát kell tartalmaznia, amelyen az első dián már létezik videókeret.

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

A teljes képernyős lejátszás szabályozza, hogyan jelenik meg a videó. Függetlenül, a [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) határozza meg, hogy automatikusan vagy kattintásra indul-e, a [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) pedig azt, hogy ismétlődik‑e. A kezdési viselkedés kiválasztásához állítsa a lejátszási módot a [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) értékre. A példa megőrzi a meglévő kezdési és ismétlési beállításokat.

## **Videó visszatekerése lejátszás után**

Egy képzési prezentációban a bemutatóvideó visszaállítása az elejére készen áll a bemutató számára, hogy újra lejátszhassa. Hívja meg a [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) metódust `True` értékkel, hogy a lejátszás befejezése után a videó a kezdethez térjen vissza.

Ez a példa megnyit egy prezentációt, megkeresi az első [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) elemet az első dián, és engedélyezi a visszatekerést. Letiltja az ismétlést, hogy a lejátszás befejeződhessen, és beállítja, hogy kattintásra induljon. A bemeneti prezentációnak legalább egy diát kell tartalmaznia, ahol az első dián már létezik videókeret.

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

A visszatekerés a videót a kezdetére viszi anélkül, hogy újraindítaná. Ezzel ellentétben a [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) `True` értékkel történő hívása automatikusan ismétli a lejátszást. Tartsa letiltva az ismétlést, ha azt akarja, hogy a videó befejeződjön és készen álljon a újbóli lejátszásra. A [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) önállóan szabályozza az automatikus vagy kattintásra indított indítást; ez a példa a [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) értéket használja, így a bemutató vezérli, mikor indul a lejátszás. Állítsa be a lejátszási módot a ciklus beállítása után, ahogy a példában látható. A visszatekerés független a [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) működésétől.

## **Videókeret vágása**

Használja a [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) és a [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) metódusokat a videó elejének vagy végének egy részének kihagyásához a lejátszás során. Mindkét érték ezredmásodpercben van megadva. A vágás módosítja a lejátszási beállításokat anélkül, hogy a beágyazott videó adatot megváltoztatná.

**Vágási beállítások beállítása**

Ez a példa beágyaz egy helyi videót, és a lejátszás során kihagyja az első 2,5 másodpercet és az utolsó másodpercet. Használjon 3,5 másodpercnél hosszabb videót, hogy maradjon lejátszható szegmens.

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

**Vágási beállítások olvasása**

Ez a példa kiírja az első videókeret vágási értékeit az első dián ezredmásodpercben. A prezentációnak legalább egy diát kell tartalmaznia. Ha az a dia nem tartalmaz videókeretet, nem lesz kiírva semmi. Az előző példa 2500 és 1000 értékeket eredményez.

```python
import jpade
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

Az Aspose.Slides lehetővé teszi a videókeretekhez tartozó zárt feliratok kezelését a PowerPoint prezentációkban. A feliratok WebVTT formátumban vannak tárolva, és a [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) metóduson keresztül érhetők el.

### **Feliratok hozzáadása videókerethez**

Ez a példa beágyaz egy helyi videót, és hozzáad egy WebVTT feliratsp track‑et, amelynek címkéje English. A feliratozási időbélyegeknek egyezniük kell a videóval. A mentett prezentáció tartalmazza mind a videót, mind a feliratokat.

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

    # Új feliratsp track hozzáadása egy WebVTT fájlból.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) osztály is kínál egy túlterhelést, amely lehetővé teszi a feliratok egy áramlathoz (stream) történő hozzáadását.

### **Feliratok kinyerése videókeretből**

Ez a példa az első dián lévő videókeretek összes feliratsp track‑jét különálló WebVTT fájlokba menti. A sorozatszámok biztosítják, hogy a kimeneti fájlok egyediek legyenek. A konzol kiírja a kinyert track-ek számát. A prezentációnak legalább egy diát kell tartalmaznia.

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

Minden [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) objektum exponálja a felirat azonosítóját, címkéjét, bináris adatait és a felirat szövegét UTF‑8 karakterláncként.

### **Feliratok eltávolítása videókeretből**

Ez a példa eltávolítja az összes feliratot az első dián az első alakzat pozíciójában található videókeretről, és elmenti az eredményt. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat egy videókeret.

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

Ha csak egy feliratra van szükség, használja a [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) vagy a [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) metódust a [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) helyett.

### **Videó feliratok keresése**

A [Captions.getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) visszaadja a teljes WebVTT track‑et, beleértve a fejlécet, az időzítő sorokat és a felirat szövegét. A feliratokat memóriában kereshetjük meg egy kifejezés és annak időbélyege megtalálásához. Például a 2. dián levő angol track a következő szöveget tartalmazhatja.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Ez a példa megnyitja a `captioned_media.pptx` fájlt, és a [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) metódust használja a minden dián lévő felső szintű videókeretek track-jeinek olvasásához. Egy egyszerű szöveges cue‑ban az időzítő sor tartalmazza a `-->` jelet, és egy üres sor zárja a cue‑t. Minden olyan felirat esetén, amely “café” szót tartalmaz bármilyen betűméretben, a példa kiírja a dia számát, a track címkét, az eredeti időzítő sort és a teljes feliratot.

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

A “café” keresése egy egyezést eredményez a mintatrack‑ben. A keresés kizárja a track fejlécre, és megőrzi az időzítési beállítást és a sortöréseket a kimenetben.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Videó kinyerése diáról**

A videók diákhoz adása mellett az Aspose.Slides lehetővé teszi a prezentációkba beágyazott videók kinyerését.

Ez a példa minden diáról kinyeri a beágyazott videókat különálló, számozott bináris fájlokba. A linkelt videókat kihagyja, mivel nem tartalmaznak beágyazott adatot. A konzol kiírja minden videó MIME‑típusát és a teljes számot. A kimenet a generikus `.bin` kiterjesztést használja; szükség esetén módosítsa a jelentett média típusnak megfelelően.

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

## **FAQ**

**Mely videólejátszási paraméterek módosíthatók egy videókeretnél?**

A [playback mode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) szabályozható. Ezek a lehetőségek a [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) objektum metódusain keresztül érhetők el.

**Milyen hatása van a videó hozzáadásának a PPTX fájl méretére?**

Igen. Ha beágyaz egy helyi videót, a bináris adat a dokumentumba kerül, ezért a prezentáció mérete arányosan nő a fájlmérettel. Ha online videóra hivatkozik és hozzáadja a bélyegképet, a prezentáció a hivatkozást és az előnézeti képet tárolja a videó adat helyett, így a méretnövekedés általában kisebb.

**Lecserélhetem a videót egy meglévő videókereten anélkül, hogy módosítanám a pozícióját és méretét?**

Igen. A kereten belül kicserélheti a [video content](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) elemet a forma geometriai adatait megtartva; ez gyakori eset a médiák frissítésére egy meglévő elrendezésben.

**Megállapítható-e a beágyazott videó tartalomtípusa (MIME)?**

Igen. A beágyazott videónak van [content type](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType), amelyet kiolvashat és felhasználhat, például lemezre mentéskor.