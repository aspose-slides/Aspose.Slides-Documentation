---
title: Videók hozzáadása prezentációkhoz Pythonban
linktitle: Videókeret
type: docs
weight: 10
url: /hu/python-net/video-frame/
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
description: "Ismerje meg, hogyan adhat programozottan videókereteket hozzá, illetve nyerhet ki őket PowerPoint és OpenDocument diákba az Aspose.Slides for Python via .NET használatával. Gyors útmutató."
---
## **Bevezetés**

Egy jól elhelyezett videó egy prezentációban hatékonyabbá teheti az üzenetet és növelheti a közönség elköteleződését. 

A PowerPoint két módon teszi lehetővé, hogy videókat adjunk hozzá egy diát tartalmazó prezentációhoz:

* Helyi videó hozzáadása vagy beágyazása (a gépén tárolt)
* Online videó hozzáadása (webes forrásból, például a YouTube-ról).

A videók (videoobjektumok) prezentációhoz való hozzáadásához az Aspose.Slides biztosítja a [Video](https://reference.aspose.com/slides/hu/python-net/aspose.slides/video/) osztályt, a [VideoFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/) osztályt és más kapcsolódó típusokat. 

## **Beágyazott videó keret létrehozása**

Ha a diára felvenni kívánt videófájl helyileg van tárolva, létrehozhat egy videókeretet a videó prezentációba való beágyazásához. 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezze meg egy dia referenciáját az indexe alapján. 
1. Adjon hozzá egy [Video](https://reference.aspose.com/slides/hu/python-net/aspose.slides/video/) objektumot, és adja át a videó fájl útvonalát a videó prezentációba való beágyazásához. 
1. Adjon hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/) objektumot a videó keretének létrehozásához.  
1. Mentse el a módosított prezentációt. 

Ez a Python-kód bemutatja, hogyan adhat hozzá egy helyileg tárolt videót a prezentációhoz:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Megkapja az első diát és hozzáad egy videókeretet
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # A prezentációt lemezre menti
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Alternatívaként hozzáadhat egy videót a fájl útvonalát közvetlenül az `add_video_frame(x, y, width, height, fname)` metódusnak átadva:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Videókeret létrehozása webes forrásból származó videóval**

A Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) újabb verziói támogatják az online videókat a prezentációkban. Ha a használni kívánt videó online elérhető (például a YouTube-on), hozzáadhatja a prezentációhoz a webes hivatkozáson keresztül.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból
1. Szerezze meg egy dia referenciáját az indexe alapján. 
1. Adjon hozzá egy [Video](https://reference.aspose.com/slides/hu/python-net/aspose.slides/video/) objektumot, és adja át a videó hivatkozását.
1. Állítson be egy miniatűrt a videókerethez. 
1. Mentse el a prezentációt. 

Ez a Python-kód megmutatja, hogyan adhat hozzá egy webes videót a PowerPoint-prezentáció egy diájához:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Videókeretet ad hozzá
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Betölti a bélyegképet
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Videókeret levágása**

Az Aspose.Slides lehetővé teszi, hogy a videó lejátszott részét a trim-from-start és trim-from-end értékek beállításával irányítsa a [VideoFrame.trim_from_start](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/trim_from_start/) és a [VideoFrame.trim_from_end](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/trim_from_end/) segítségével. Mindkét érték ezredmásodpercben van megadva, és meghatározza, mennyi időt hagyunk ki a videó elejéről és végéről. Ezek a beállítások a prezentációban a videó lejátszási beállításait módosítják; nem vágják vagy egyébként nem módosítják a beágyazott videó bináris adatát.

**Trim beállítások beállítása**

Videókeret létrehozásához és trim beállításainak megadásához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Adjon hozzá egy [Video](https://reference.aspose.com/slides/hu/python-net/aspose.slides/video/) objektumot a prezentációhoz.
1. Adjon hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/) objektumot egy diához.
1. Állítsa be a trim-from-start és trim-from-end értékeket a [VideoFrame.trim_from_start](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/trim_from_start/) és a [VideoFrame.trim_from_end](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/trim_from_end/) segítségével.
1. Mentse el a módosított prezentációt.

Az alábbi kódrészlet kihagyja az beágyazott videó első 2,5 másodpercét és az utolsó másodpercet lejátszáskor:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)

    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Trim beállítások olvasása**

A meglévő trim beállítások megtekintéséhez töltse be a prezentációt, keresse meg az első dián lévő alakzatok között a [VideoFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/) objektumot, és olvassa ki az értékeket a [VideoFrame.trim_from_start](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/trim_from_start/) és a [VideoFrame.trim_from_end](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/trim_from_end/) segítségével.

Az alábbi kódrészlet megtalálja az első videókeretet az első dián, és ezredmásodpercben jelzi a trim beállításait:

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            video_frame = shape
            trim_from_start = video_frame.trim_from_start
            trim_from_end = video_frame.trim_from_end

            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
```

## **Videó feliratok kezelése**

Az Aspose.Slides lehetővé teszi a zárt feliratok kezelését a PowerPoint-prezentációk videókereteihez. A feliratok WebVTT formátumban tárolódnak, és a [VideoFrame.caption_tracks] tulajdonságon keresztül érhetők el.

**Feliratok hozzáadása egy videókerethez**

Feliratok hozzáadásához egy videókerethez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Adjon hozzá egy videót a prezentációhoz.
1. Adjon hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/) objektumot egy diához.
1. Használja a [caption_tracks] által visszaadott [CaptionsCollection] típusú gyűjteményt egy WebVTT felirat sáv hozzáadásához.
1. Mentse el a módosított prezentációt.

Az alábbi kód bemutatja, hogyan adhat feliratokat egy videókerethez:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Új feliratsáv hozzáadása WebVTT fájlból.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

A [CaptionsCollection] osztály egy túlterhelést is biztosít, amely lehetővé teszi feliratok hozzáadását adatfolyamból.

**Feliratok kinyerése egy videókeretből**

Feliratok kinyeréséhez egy videókeretből:

1. Töltse be a videót tartalmazó prezentációt.
1. Keresse meg a cél [VideoFrame] objektumot.
1. Iteráljon a [caption_tracks] gyűjteményen.
1. Mentse minden feliratsávot egy `.vtt` fájlba.

Az alábbi kód bemutatja, hogyan nyerhet ki feliratokat egy videókeretből:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # A feliratsáv mentése WebVTT fájlba.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

Minden [Captions] objektum megjeleníti a felirat azonosítóját, címkéjét, bináris adatait és a feliratszöveget UTF-8 karakterláncként.

**Feliratok eltávolítása egy videókeretből**

Feliratok eltávolításához egy videókeretből:

1. Töltse be a videót tartalmazó prezentációt.
1. Szerezze meg a cél [VideoFrame] objektumot.
1. Távolítsa el a feliratsávokat a [CaptionsCollection] gyűjteményből.
1. Mentse el a módosított prezentációt.

Az alábbi kód bemutatja, hogyan távolíthatja el az összes feliratot egy videókeretből:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # típus: slides.VideoFrame

    # Eltávolítja az összes feliratot a videókeretről.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Ha csak egy feliratsávot kell eltávolítani, használja a [remove] vagy a [remove_at] metódust a [clear] helyett.

## **Videó kinyerése diáról**

A videók diákhoz való hozzáadása mellett az Aspose.Slides lehetővé teszi a prezentációkba beágyazott videók kinyerését.

1. Hozzon létre egy példányt a [Presentation] osztályból a videót tartalmazó prezentáció betöltéséhez. 
2. Iteráljon az összes [Slide] objektumon.
3. Iteráljon az összes [Shape] objektumon, hogy megtalálja a [VideoFrame] objektumot. 
4. Mentse a videót a lemezre.

Ez a Python-kód megmutatja, hogyan nyerheti ki a videót egy prezentációs diáról:

```python
import aspose.slides as slides

# Létrehozza a Presentation objektumot, amely egy prezentációs fájlt képvisel
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **GYIK**

**Milyen videólejátszási paraméterek módosíthatók egy VideoFrame esetén?**

A [playback mode] (automatikus vagy kattintásra) és a [looping] (ismétlés) vezérelhető. Ezek az opciók a [VideoFrame] objektum tulajdonságain keresztül érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájl méretét?**

Igen. Ha helyi videót ágyaz be, a bináris adat is része lesz a dokumentumnak, így a prezentáció mérete arányosan nő a fájl méretével. Ha online videót ad hozzá, csak egy hivatkozás és egy miniatűr kerül beágyazásra, ezért a méretnövekedés kisebb.

**Lecserélhetem a videót egy meglévő VideoFrame-ben anélkül, hogy megváltoztatnám a pozícióját és méretét?**

Igen. A keretben lévő [video content] cserélhető a forma geometriai adatainak megőrzése mellett; ez gyakori eset a média frissítésére egy meglévő elrendezésben.

**Megállapítható-e egy beágyazott videó tartalomtípusa (MIME)?**

Igen. Egy beágyazott videónak van [content type] (tartalomtípusa), amelyet leolvashat és felhasználhat, például a lemezre mentéskor.