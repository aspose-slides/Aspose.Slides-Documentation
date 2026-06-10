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
description: "Tanulja meg programozottan videókeretek hozzáadását és kinyerését PowerPoint és OpenDocument diákban az Aspose.Slides for Python via .NET segítségével. Gyors útmutató."
---
## **Bevezetés**

A jól elhelyezett videó egy prezentációban hatékonyabbá teheti az üzenetet, és növelheti a közönség elköteleződését.  

A PowerPoint két módon teszi lehetővé, hogy videókat adjunk hozzá egy diára a prezentációban:

* Helyi videó hozzáadása vagy beágyazása (a gépeden tárolt)
* Online videó hozzáadása (webes forrásból, például a YouTube-ról).

A videók (video objektumok) prezentációba való hozzáadásához az Aspose.Slides a [Video](https://reference.aspose.com/slides/hu/python-net/aspose.slides/video/) osztályt, a [VideoFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/) osztályt és egyéb releváns típusokat biztosít.  

## **Beágyazott videókeret létrehozása**

Ha a diára felvenni kívánt videófájl helyileg van tárolva, létrehozhatsz egy videókeretet, hogy beágyazd a videót a prezentációba.  

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
1. Szerezz meg egy diára hivatkozást az indexe alapján.  
1. Adj hozzá egy [Video](https://reference.aspose.com/slides/hu/python-net/aspose.slides/video/) objektumot, és add meg a videófájl útvonalát a videó prezentációba való beágyazásához.  
1. Adj hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/) objektumot a videó keret létrehozásához.  
1. Mentsd el a módosított prezentációt.  

Ez a Python kód bemutatja, hogyan adj hozzá egy helyileg tárolt videót a prezentációhoz:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Megkapja az első diát és hozzáad egy videókeretet
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # A prezentáció mentése a lemezre
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Alternatívaként a videót közvetlenül a `add_video_frame(x, y, width, height, fname)` metódusnak átadott fájlútvonal megadásával is hozzáadhatod:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Videókeret létrehozása webes forrásból származó videóval**

Microsoft a [PowerPoint 2013 és újabb](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) verziók támogatják a YouTube videókat a prezentációkban. Ha a használni kívánt videó online elérhető (például a YouTube-on), hozzáadhatod a prezentációhoz a webes hivatkozásán keresztül.  

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból  
1. Szerezz meg egy diára hivatkozást az indexe alapján.  
1. Adj hozzá egy [Video](https://reference.aspose.com/slides/hu/python-net/aspose.slides/video/) objektumot, és add meg a videó hivatkozását.  
1. Állíts be egy bélyegképet a videókerethez.  
1. Mentsd el a prezentációt.  

Ez a Python kód bemutatja, hogyan adj hozzá egy videót a webről egy diához egy PowerPoint prezentációban:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Videókeretet ad hozzá
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Bélyegképet tölt be
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Videó feliratok kezelése**

Az Aspose.Slides lehetővé teszi a videókeretekhez tartozó zárt feliratok kezelését a PowerPoint prezentációkban. A feliratok WebVTT formátumban tárolódnak, és a [VideoFrame.caption_tracks](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/caption_tracks/) tulajdonságon keresztül érhetők el.  

**Feliratok hozzáadása egy videókerethez**

A feliratok videókerethez való hozzáadásához:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
1. Adj hozzá egy videót a prezentációhoz.  
1. Adj egy [VideoFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/) objektumot egy diára.  
1. Használd a [caption_tracks](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/caption_tracks/) által visszaadott [CaptionsCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/captionscollection/) objektumot egy WebVTT feliratsáv hozzáadásához.  
1. Mentsd el a módosított prezentációt.  

A következő kód bemutatja, hogyan adj hozzá feliratokat egy videókerethez:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Új feliratszakaszt ad hozzá egy WebVTT fájlból.
    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

A [CaptionsCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/captionscollection/) osztály további overloadot is kínál, amely lehetővé teszi feliratok hozzáadását egy adatfolyamból.  

**Feliratok kinyerése egy videókeretből**

A feliratok egy videókeretből történő kinyeréséhez:

1. Töltsd be a videót tartalmazó prezentációt.  
1. Keresd meg a cél [VideoFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/) objektumot.  
1. Iterálj a [caption_tracks](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/caption_tracks/) gyűjteményen.  
1. Mentsd el minden feliratsávot egy `.vtt` fájlba.  

A következő kód bemutatja, hogyan nyerj ki feliratokat egy videókeretből:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # A feliratszakaszt egy WebVTT fájlba menti.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

Minden [Captions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/captions/) objektum a felirat azonosítóját, címkéjét, bináris adatait és a feliratszöveget UTF-8 karakterláncként teszi elérhetővé.  

**Feliratok eltávolítása egy videókeretből**

A feliratok egy videókeretből való eltávolításához:

1. Töltsd be a videót tartalmazó prezentációt.  
1. Szerezd meg a cél [VideoFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/) objektumot.  
1. Távolítsd el a feliratsávokat a [CaptionsCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/captionscollection/) objektumból.  
1. Mentsd el a módosított prezentációt.  

A következő kód bemutatja, hogyan távolíts el minden feliratot egy videókeretből:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # típus: slides.VideoFrame

    # A videókeret összes feliratát eltávolítja.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Ha csak egy feliratsávot szeretnél eltávolítani, használd a [remove](https://reference.aspose.com/slides/hu/python-net/aspose.slides/captionscollection/remove/) vagy a [remove_at](https://reference.aspose.com/slides/hu/python-net/aspose.slides/captionscollection/remove_at/) metódust a [clear](https://reference.aspose.com/slides/hu/python-net/aspose.slides/captionscollection/clear/) helyett.  

## **Videó kinyerése diáról**

A videók diákhoz való hozzáadása mellett az Aspose.Slides lehetővé teszi a prezentációkba beágyazott videók kinyerését is.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból a videót tartalmazó prezentáció betöltéséhez.  
2. Iterálj végig az összes [Slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/) objektumon.  
3. Iterálj végig az összes [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) objektumon, hogy megtaláld a [VideoFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/) elemet.  
4. Mentsd el a videót a lemezre.  

Ez a Python kód bemutatja, hogyan nyerj ki egy videót egy prezentációs diáról:

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

**Mely videolejátszási paraméterek módosíthatók egy VideoFrame esetén?**  
A [playback mode](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/play_mode/) (automatikus vagy kattintásra) és a [play_loop_mode](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/play_loop_mode/) beállítások irányíthatók. Ezek a lehetőségek a [VideoFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/) objektum tulajdonságain keresztül érhetők el.  

**Milyen mértékben befolyásolja a videó hozzáadása a PPTX fájl méretét?**  
Igen. Ha helyi videót ágyazol be, a bináris adat a dokumentumba kerül, így a prezentáció mérete arányosan nő a fájl méretével. Online videó esetén egy hivatkozás és egy bélyegkép kerül beágyazásra, ezért a méretnövekedés kisebb.  

**Lecserélhetem-e a videót egy meglévő VideoFrame-ben anélkül, hogy megváltoztatnám a pozícióját és méretét?**  
Igen. A [video content](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/embedded_video/) cseréjével a keretben megőrizheted a forma geometriai tulajdonságait; ez gyakori megoldás a média frissítésére egy meglévő elrendezésben.  

**Meg lehet határozni egy beágyazott videó tartalomtípusát (MIME)?**  
Igen. Egy beágyazott videó rendelkezik [content type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/video/content_type/) információval, amelyet kiolvashatsz és felhasználhatsz, például a lemezre mentéskor.