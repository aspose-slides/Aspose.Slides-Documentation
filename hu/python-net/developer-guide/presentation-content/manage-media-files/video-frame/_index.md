---
title: Videókeretek kezelése prezentációkban Python nyelven
linktitle: Videókeret
type: docs
weight: 10
url: /hu/python-net/video-frame/
keywords:
- videó hozzáadása
- videó létrehozása
- videó beágyazása
- videó kinyerése
- videó lekérdezése
- videókeret
- webes forrás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá és nyerhet ki programozottan videókereteket PowerPoint és OpenDocument diákban az Aspose.Slides for Python via .NET használatával. Gyors útmutató."
---
## **Bevezetés**

A videók segíthetnek elképzelések magyarázatában és a közönség bevonásában. Az Aspose.Slides for Python a .NET-en keresztül lehetővé teszi, hogy videókereteket adjunk a diákhoz, állítsuk a lejátszási beállításokat, kezeljük a feliratokat, és kinyerjük a beágyazott videó adatokat.

A PowerPoint támogatja a helyi videókat és az online videókra mutató hivatkozásokat, például a YouTube videókat.

A videó adat és videó keretek ábrázolásához az Aspose.Slides a [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) osztályt, a [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) osztályt és egyéb releváns típusokat biztosít.

## **Beágyazott videókeret létrehozása**

Ha a diára hozzáadni kívánt videofájl helyileg van tárolva, létrehozhat egy videókeretet a videó prezentációba ágyazásához.

Ez a példa egy helyi videót ágyaz be egy meglévő prezentáció első diájára, majd elmenti az eredményt. A keret koordinátái és méretei pontokban vannak megadva. A folyam a mentés befejeződéséig nyitva marad, mivel a [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) zárolva tartja, amíg a prezentáció használja.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

A [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/) metódusnak közvetlenül is megadhatja a helyi videó elérési útját. Ez a példa a videót egy új prezentáció első diájára ágyazza be. A videónak elérhetőnek kell maradnia a prezentáció mentéséig.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Videókeret létrehozása webes forrásból származó videóval**

A Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) támogatja az online videókat a prezentációkban. Létrehozhat egy videókeretet, amely egy online videóra, például egy YouTube videóra mutat.

Ez a példa egy YouTube videó hivatkozást és előnézeti képet ad az első diához. Cserélje le a videó azonosítóját, ha másik videót szeretne használni. A [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) beállítás automatikus lejátszást kér. Az előnézeti kép letöltése és a videó lejátszása internetkapcsolatot igényel. A prezentáció megjelenítőnek is támogatnia kell az online videó lejátszást.

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **Videó lejátszása teljes képernyő módban**

Képzési prezentációban egy szoftverbemutató lejátszható teljes képernyő módban, hogy a közönség részleteket láthasson. A [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) beállítását `True` értékre állítva engedélyezhető ez a viselkedés lejátszás közben.

Ez a példa megnyit egy prezentációt, megkeresi az első [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) objektumot az első dián, és engedélyezi a teljes képernyős lejátszást. A bemeneti prezentációnak legalább egy diát kell tartalmaznia, amelyen az első dián már létezik videókeret.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

A teljes képernyős lejátszás szabályozza, hogy a videó hogyan jelenik meg. Függetlenül, a [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) határozza meg, hogy automatikusan vagy kattintásra indul-e a lejátszás, a [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) pedig azt, hogy ismétlődjön-e. Az indítási viselkedés kiválasztásához állítsa a lejátszási módot a [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) értékek egyikére. A példa megőrzi a meglévő indítási és loop beállításokat.

## **Videó visszatekerése a lejátszás után**

Képzési prezentációban a bemutató videójának visszatekerése a kezdeti állapotba azt teszi lehetővé, hogy a prezentáló újból elindíthassa azt. A [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) beállítását `True` értékre állítva a videó a lejátszás befejezése után visszatér a kezdethez.

Ez a példa megnyit egy prezentációt, megtalálja az első [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) objektumot az első dián, és engedélyezi a visszatekerést. Kikapcsolja a loop-ot, hogy a lejátszás befejeződhessen, és az indítást kattintásra állítja. A bemeneti prezentációnak legalább egy diát kell tartalmaznia, amelyen már létezik videókeret az első dián.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

A visszatekerés a videót a kezdeti állapotba helyezi anélkül, hogy újra elindulna. Ezzel szemben a [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) engedélyezése automatikusan ismétli a lejátszást. Tartsa letiltva a loop-ot, ha azt szeretné, hogy a videó befejeződjön, és készen álljon a újbóli lejátszásra. A [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) önállóan szabályozza az automatikus vagy kattintásra történő indítást; ez a példa a [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) beállítást használja, hogy a prezentáló döntse el, mikor indul a lejátszás. Állítsa be a lejátszási módot a loop beállítása után, ahogyan a példában látható. A visszatekerés független a [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) beállítástól.

## **Videókeret vágása**

A [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) és a [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) segítségével kihagyhatja a videó elejének vagy végének egy részét a lejátszás során. Mindkét érték ezredmásodpercben van megadva. A vágás megváltoztatja a lejátszási beállításokat anélkül, hogy a beágyazott videó adatát módosítaná.

**Vágási beállítások beállítása**

Ez a példa egy helyi videót ágyaz be, és a lejátszás közben kihagyja az első 2,5 másodpercet és az utolsó egy másodpercet. Használjon legalább 3,5 másodperc hosszú videót, hogy maradjon lejátszható szegmens.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Vágási beállítások olvasása**

Ez a példa kiírja az első videókeret vágási értékeit az első dián ezredmásodpercben. A prezentációnak legalább egy diát kell tartalmaznia. Ha az adott diához nem tartozik videókeret, semmi nem kerül kiírásra. Az előző példa 2500 és 1000 értékeket ad.

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **Videó feliratok kezelése**

Az Aspose.Slides lehetővé teszi a videókeretekhez tartozó zárt feliratok kezelését PowerPoint prezentációkban. A feliratok WebVTT formátumban tárolódnak, és a [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) tulajdonságon keresztül érhetők el.

**Feliratok hozzáadása videókerethez**

Ez a példa egy helyi videót ágyaz be, és egy „English” címkéjű WebVTT feliratspTrack-et ad hozzá. A felirat időbélyegeinek egyezniük kell a videóval. A mentett prezentáció tartalmazza mind a videót, mind annak feliratait.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

A [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) osztály további túlterhelést is biztosít, amely lehetővé teszi feliratok hozzáadását egy folyamról.

**Feliratok kinyerése videókeretből**

Ez a példa az első dián lévő videókeretek összes feliratsávját különálló WebVTT fájlokként menti. A sorozatszámok biztosítják, hogy a kimeneti fájlok egyediek legyenek. A konzol jelzi a kinyert sávok számát. A prezentációnak legalább egy diát kell tartalmaznia.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

Minden [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) objektum kiállítja a felirat azonosítóját, címkéjét, bináris adatait és a felirat szövegét UTF‑8 karakterláncként.

**Feliratok eltávolítása videókeretből**

Ez a példa minden feliratot eltávolít a videókeretből, amely az első alakzat pozíciójában található az első dián, majd elmenti az eredményt. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat egy videókeret.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Ha csak egy feliratsávot szeretne eltávolítani, használja a [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) vagy a [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) metódust a [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) helyett.

## **Videó kinyerése diáról**

A videók diákhoz való hozzáadása mellett az Aspose.Slides lehetővé teszi a prezentációkba beágyazott videók kinyerését is.

Ez a példa minden diáról kinyeri a beágyazott videókat, és különálló, számozott bináris fájlokba menti őket. A hivatkozott videók ki lesznek hagyva, mivel nincs beágyazott adatuk. A konzol kiírja minden videó MIME‑típusát és a teljes darabszámot. A kimenet a generikus `.bin` kiterjesztést használja; szükség esetén módosítsa a fájlkiterjesztést a jelentett média típusnak megfelelően.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **FAQ**

**Mely videolejátszási paraméterek módosíthatók egy videókeretnél?**

A [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) szabályozható. Ezek a lehetőségek a [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) objektum tulajdonságain keresztül érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájl méretét?**

Igen. Ha helyi videót ágyaz be, a bináris adat a dokumentumba kerül, így a prezentáció mérete arányosan nő a fájlmérettel. Ha online videóra hivatkozik, és csak egy előnézeti képet ad hozzá, a prezentáció a linket és a képet tárolja, nem pedig a videó adatát, így a méretnövekedés általában kisebb.

**Lecserélhetem a videót egy meglévő videókeretben anélkül, hogy megváltoztatnám a pozícióját és méretét?**

Igen. A [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) cseréjével a keretben megőrizheti az alakzat geometriai méreteit; ez gyakori módszer a média frissítésére egy meglévő elrendezésben.

**Meghatározható-e egy beágyazott videó tartalomtípusa (MIME)?**

Igen. Egy beágyazott videó rendelkezik [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) tulajdonsággal, amely kiolvasható és felhasználható, például lemezre mentéskor.