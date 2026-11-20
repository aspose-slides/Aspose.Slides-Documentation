---
title: "Videókeretek kezelése bemutatókban Pythonban"
linktitle: "Videókeret"
type: docs
weight: 10
url: /hu/python-net/video-frame/
keywords:
- "videó hozzáadása"
- "videó létrehozása"
- "videó beágyazása"
- "videó kinyerése"
- "videó lekérése"
- "videókeret"
- "webes forrás"
- "PowerPoint"
- "OpenDocument"
- "bemutató"
- "Python"
- "Aspose.Slides"
description: "Tanulja meg programozott módon videókeretek hozzáadását és kinyerését PowerPoint és OpenDocument diákban az Aspose.Slides for Python via .NET segítségével. Gyors útmutató."
---
## **Bevezetés**

A videók segíthetnek az ötletek megmagyarázásában és a közönség bevonásában. Az Aspose.Slides for Python via .NET lehetővé teszi, hogy videókereteket adjunk a diákhoz, beállítsuk a lejátszási beállításokat, kezeljük a feliratokat, és kinyerjük a beágyazott videóadatokat.

A PowerPoint támogatja a helyi videókat és az online videókra mutató hivatkozásokat, például a YouTube videókat.

Az Aspose.Slides a videóadatok és videókeretek ábrázolásához a [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) osztályt, a [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) osztályt és egyéb releváns típusokat biztosít.

## **Beágyazott videókeret létrehozása**

Ha a diára felvenni kívánt videofájl helyileg van tárolva, létrehozhatsz egy videókeretet a videó bemutatóba való beágyazásához.

Ez a példa egy helyi videót ágyaz be a meglévő bemutató első diájára, majd elmenti az eredményt. A keret koordinátái és méretei pontban vannak megadva. A folyam (stream) nyitva marad a mentés befejezéséig, mert a [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) zárolva tartja, amíg a bemutató használja.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

A helyi videó elérési útját közvetlenül is átadhatod a [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/) metódusnak. Ez a példa a videót egy új bemutató első diájára ágyazza be. A videónak a mentés befejezéséig elérhetőnek kell maradnia.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Videókeret létrehozása webes forrásból származó videóval**

A Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) támogatja az online videókat a bemutatókban. Létrehozhatsz egy videókeretet, amely egy online videóra, például egy YouTube videóra hivatkozik.

Ez a példa egy YouTube videóhivatkozást és miniatűr képet ad az első diához. A videóazonosítót cserélve más videót használhatsz. A [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) beállítás automatikus lejátszást kér. A miniatűr letöltése és a videó lejátszása internetkapcsolatot igényel. A bemutató megjelenítőnek is támogatnia kell az online videó lejátszást.

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

Egy képzési bemutatóban a szoftverdemonstrációt teljes képernyő módban játszhatod le, így a közönség láthatja a részleteket. Állítsd a [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) értékét `True`-ra, hogy ez a viselkedés a lejátszás során engedélyezve legyen.

Ez a példa megnyit egy bemutatót, megtalálja az első [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) elemet az első dián, és engedélyezi a teljes képernyős lejátszást. A bemeneti bemutatónak legalább egy diát kell tartalmaznia, amelyen az első dián már létezik videókeret.

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

A teljes képernyős lejátszás szabályozza, hogyan jelenik meg a videó. Különállóan a [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) határozza meg, automatikusan vagy kattintásra indul-e, a [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) pedig, hogy ismétlődik-e. A kezdési viselkedés kiválasztásához állítsd a lejátszási módot a [VideoPlayModePreset.AUTO vagy VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) értékre. A példa megőrzi a meglévő kezdési és ismétlési beállításokat.

## **Videó visszatekerése lejátszás után**

Egy képzési bemutatóban a demonstrációs videó elejére visszaállítása lehetővé teszi, hogy az előadó újra lejátszhassa. Állítsd a [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) értékét `True`-ra, hogy a lejátszás befejeződése után a videó a kezdetébe térjen vissza.

Ez a példa megnyit egy bemutatót, megtalálja az első [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) elemet az első dián, és engedélyezi a visszatekerést. Kikapcsolja az ismétlést, hogy a lejátszás befejeződhessen, és a lejátszást kattintásra állítja be. A bemeneti bemutatónak legalább egy diát kell tartalmaznia, amelyen az első dián már létezik videókeret.

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

A visszatekerés a videót a kezdetére állítja anélkül, hogy újraindulna. Ezzel szemben a [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) engedélyezése automatikusan ismétli a lejátszást. Kapcsold ki az ismétlést, ha azt szeretnéd, hogy a videó befejeződjön és készen álljon a újra lejátszásra. A [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) önállóan szabályozza az automatikus vagy kattintásos indítást; ez a példa a [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) értéket használja, így az előadó dönt a lejátszás kezdetéről. Állítsd be a lejátszási módot az ismétlési beállítás után, ahogyan a példában látható. A visszatekerés független a [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) beállítástól.

## **Videókeret vágása**

Használd a [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) és a [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) metódusokat a videó elejének vagy végének egy részének átugrásához lejátszáskor. Mindkét érték ezredmásodpercben van megadva. A vágás módosítja a lejátszási beállításokat anélkül, hogy a beágyazott videóadatokat megváltoztatná.

**Vágási beállítások beállítása**

Ez a példa egy helyi videót ágyaz be, és a lejátszás során átugorja az első 2,5 másodpercet és az utolsó másodpercet. Használj 3,5 másodpercnél hosszabb videót, hogy lejátszható szegmens maradjon.

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

Ez a példa a első dián lévő első videókeret vágási értékeit ezredmásodpercben írja ki. A bemutatónak legalább egy diát kell tartalmaznia. Ha az a dia nem tartalmaz videókeretet, semmi sem jelenik meg. Az előző példa 2500 és 1000 értékeket ad.

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

Az Aspose.Slides lehetővé teszi, hogy a PowerPoint‑bemutatók videókereteihez zárt feliratokat kezelj. A feliratok WebVTT formátumban vannak tárolva, és a [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) tulajdonsággal érhetők el.

### **Feliratok hozzáadása videókerethez**

Ez a példa egy helyi videót ágyaz be, és egy „English” nevű WebVTT feliratsp tracket ad hozzá. A felirat időbélyegzőinek meg kell egyezniük a videóval. A mentett bemutató tartalmazza mind a videót, mind a feliratokat.

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

A [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) osztály további túlterhelést is kínál, amellyel stream‑ből adhatók hozzá feliratok.

### **Feliratok kinyerése videókeretből**

Ez a példa a első dián lévő videókeretek összes feliratsp trackjét különálló WebVTT fájlokként menti. A sorozatszámok biztosítják, hogy a kimeneti fájlok egyedi névvel rendelkezzenek. A konzol jelzi a kinyert track‑ek számát. A bemutatónak legalább egy diát kell tartalmaznia.

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

Minden egyes [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) objektum a felirat azonosítóját, címkéjét, bináris adatait és a felirat szövegét UTF‑8 karakterláncként teszi elérhetővé.

### **Feliratok eltávolítása videókeretből**

Ez a példa az első dián az első alakzat pozíciójában lévő videókeret összes feliratát eltávolítja, és elmenti az eredményt. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat videókeret.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Ha csak egyetlen feliratsp tracket szeretnél eltávolítani, használd a [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) vagy a [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) metódusokat a [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) helyett.

### **Videó feliratok keresése**

A [Captions.data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) visszaadja a teljes WebVTT tracket, beleértve a fejléceket, az időzítő sorokat és a felirat szöveget. Például egy angol track a 2. dián a következő cue‑t tartalmazhatja:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Ez a példa megnyitja a `captioned_media.pptx` fájlt, és minden dián a felső szintű videókeretek [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) tulajdonságát beolvassa. Minden egyszerű szöveges cue‑nál megkeresi a `-->` karakterláncot tartalmazó idővonalat, és a következő üres sor vagy a track vége előtt gyűjti össze a felirat sorokat. A felirat szövegében a „café” szót keresik, a kis‑ és nagybetűket figyelmen kívül hagyva, majd kiírják a diaszámot, a track címkéjét, az eredeti idővonalat és a teljes feliratot minden egyezésnél.

```python
import aspose.slides as slides

with slides.Presentation("captioned_media.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.VideoFrame):
                continue

            for track in shape.caption_tracks:
                lines = iter(track.data_as_string.splitlines())
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
                        print(f"Slide {slide.slide_number} | {track.label} | {timing}")
                        print(caption)
```

A mintatrack egy egyezést eredményez. A „Café” a fejlécekben van, nem a felirat szövegében, és a kimenet megtartja az időzítési beállítást valamint mindkét felirat sort.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Videó kinyerése diáról**

A videók diákhoz való hozzáadása mellett az Aspose.Slides lehetővé teszi a bemutatókba beágyazott videók kinyerését is.

Ez a példa a beágyazott videókat minden diáról különálló, számozott bináris fájlokba menti. A hivatkozott (linked) videókat kihagyja, mivel nincs beágyazott adatuk. A konzol kiírja minden videó MIME‑típusát és a teljes darabszámot. A kimenet a generikus `.bin` kiterjesztést használja; szükség esetén cseréld le a jelentett médiatípusnak megfelelő kiterjesztésre.

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

## **GYIK**

**Mely videólejátszási paraméterek módosíthatók egy videókeretnél?**  
A [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) vezérelhető. Ezek a beállítások a [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) objektum tulajdonságain keresztül érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájlméretet?**  
Igen. Ha helyi videót ágyazol be, a bináris adatot a dokumentumba helyezi, így a bemutató mérete arányosan növekszik a fájlmérettel. Ha online videóra hivatkozol, és miniatűr képet adsz hozzá, a bemutató csak a hivatkozást és a előnézeti képet tárolja, nem a videó adatát, ezért a méretnövekedés általában kisebb.

**Lecserélhetem egy meglévő videókeret videóját a pozíció és a méret módosítása nélkül?**  
Igen. A [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) cseréjével a keret geometriája változatlan marad; ez egy gyakori módja a média frissítésének egy meglévő elrendezésben.

**Meghatározható-e egy beágyazott videó tartalom típusa (MIME)?**  
Igen. A beágyazott videó rendelkezik egy [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) tulajdonsággal, amely kiolvasható és felhasználható, például a lemezre mentéskor.