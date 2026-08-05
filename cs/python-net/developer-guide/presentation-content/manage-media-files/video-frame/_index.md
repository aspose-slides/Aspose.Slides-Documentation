---
title: Přidání videí do prezentací v Pythonu
linktitle: Rámeček videa
type: docs
weight: 10
url: /cs/python-net/video-frame/
keywords:
- přidat video
- vytvořit video
- vložit video
- extrahovat video
- získat video
- video rámeček
- webový zdroj
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se programově přidávat a extrahovat video rámečky v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro Python přes .NET. Rychlý průvodce jak na to."
---
## **Introduction**

Dobře umístěné video v prezentaci může učinit vaši zprávu přesvědčivější a zvýšit úroveň zapojení publika.

PowerPoint umožňuje přidávat videa na snímek v prezentaci dvěma způsoby:

* Přidat nebo vložit místní video (uložené na vašem počítači)
* Přidat online video (z webového zdroje, např. YouTube).

Aby bylo možné přidávat videa (video objekty) do prezentace, Aspose.Slides poskytuje třídu [Video](https://reference.aspose.com/slides/cs/python-net/aspose.slides/video/) , třídu [VideoFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/) a další relevantní typy.

## **Create Embedded Video Frame**

Pokud je video soubor, který chcete přidat na snímek, uložen lokálně, můžete vytvořit rámeček videa a vložit video do své prezentace.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Přidejte objekt [Video](https://reference.aspose.com/slides/cs/python-net/aspose.slides/video/) a předávejte cestu k video souboru pro vložení videa do prezentace. 
4. Přidejte objekt [VideoFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/) pro vytvoření rámečku pro video.  
5. Uložte upravenou prezentaci. 

Tento Python kód ukazuje, jak přidat video uložené lokálně do prezentace:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Získá první snímek a přidá video rámeček
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Uloží prezentaci na disk
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Alternativně můžete video přidat předáním jeho cesty přímo metodě `add_video_frame(x, y, width, height, fname)` :

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Create Video Frame with Video from Web Source**

Novější verze Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) podporují online videa v prezentacích. Pokud je požadované video dostupné online (např. na YouTube), můžete jej přidat do prezentace pomocí jeho webového odkazu.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Přidejte objekt [Video](https://reference.aspose.com/slides/cs/python-net/aspose.slides/video/) a předávejte odkaz na video.
4. Nastavte miniaturu pro rámec videa. 
5. Uložte prezentaci. 

Tento Python kód ukazuje, jak přidat video z webu na snímek v PowerPoint prezentaci:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Přidá videoFrame
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Načte miniaturu
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Trim a Video Frame**

Aspose.Slides umožňuje řídit, která část videa se přehrává, nastavením hodnot trim_from_start a trim_from_end pomocí [VideoFrame.trim_from_start](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/trim_from_start/) a [VideoFrame.trim_from_end](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/trim_from_end/). Obě hodnoty jsou zadány v milisekundách a určují, kolik času se přeskočí od začátku a konce videa. Tato nastavení mění způsob přehrávání videa v prezentaci; neprovádějí řez nebo jinou úpravu binárních dat vloženého videa.

**Set Trim Settings**

Pro vytvoření rámečku videa a nastavení jeho ořezových hodnot:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
2. Přidejte objekt [Video](https://reference.aspose.com/slides/cs/python-net/aspose.slides/video/) do prezentace.
3. Přidejte objekt [VideoFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/) na snímek.
4. Nastavte hodnoty trim_from_start a trim_from_end pomocí [VideoFrame.trim_from_start](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/trim_from_start/) a [VideoFrame.trim_from_end](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/trim_from_end/) .
5. Uložte upravenou prezentaci.

Následující ukázka kódu přeskočí prvních 2,5 sekundy a poslední sekundu vloženého videa během přehrávání:

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

**Read Trim Settings**

Pro zkontrolování existujících ořezových nastavení načtěte prezentaci, najděte objekt [VideoFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/) mezi tvary na prvním snímku a přečtěte hodnoty pomocí [VideoFrame.trim_from_start](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/trim_from_start/) a [VideoFrame.trim_from_end](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/trim_from_end/) .

Následující ukázka kódu najde první rámeček videa na prvním snímku a vypíše jeho ořezová nastavení v milisekundách:

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

## **Manage Video Captions**

Aspose.Slides umožňuje spravovat uzavřené titulky pro rámečky videa v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou přístupné prostřednictvím vlastnosti [VideoFrame.caption_tracks](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/caption_tracks/) .

**Add Captions to a Video Frame**

Pro přidání titulků do rámečku videa:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
2. Přidejte video do prezentace.
3. Přidejte objekt [VideoFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/) na snímek.
4. Pomocí [CaptionsCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/captionscollection/) vrácené vlastností [caption_tracks](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/caption_tracks/) přidejte stopu WebVTT titulků.
5. Uložte upravenou prezentaci.

Následující kód ukazuje, jak přidat titulky do rámečku videa:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Přidá novou stopu titulků ze souboru WebVTT.
    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

Třída [CaptionsCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/captionscollection/) také poskytuje přetíženou metodu, která umožňuje přidat titulky ze streamu.

**Extract Captions from a Video Frame**

Pro extrahování titulků z rámečku videa:

1. Načtěte prezentaci, která obsahuje video.
2. Najděte cílový objekt [VideoFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/) .
3. Procházejte kolekci [caption_tracks](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/caption_tracks/) .
4. Uložte každou stopu titulků do souboru `.vtt` .

Následující kód ukazuje, jak extrahovat titulky z rámečku videa:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # Uloží stopu titulků do souboru WebVTT.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

Každý objekt [Captions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/captions/) vystavuje identifikátor titulků, popisek, binární data a text titulků jako řetězec UTF-8.

**Remove Captions from a Video Frame**

Pro odstranění titulků z rámečku videa:

1. Načtěte prezentaci, která obsahuje video.
2. Získejte cílový objekt [VideoFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/) .
3. Odstraňte stopy titulků z [CaptionsCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/captionscollection/) .
4. Uložte upravenou prezentaci.

Následující kód ukazuje, jak odstranit všechny titulky z rámečku videa:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # type: slides.VideoFrame

    # Odstraní všechny titulky z video rámce.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Pokud potřebujete odstranit pouze jednu stopu titulků, použijte metody [remove](https://reference.aspose.com/slides/cs/python-net/aspose.slides/captionscollection/remove/) nebo [remove_at](https://reference.aspose.com/slides/cs/python-net/aspose.slides/captionscollection/remove_at/) místo [clear](https://reference.aspose.com/slides/cs/python-net/aspose.slides/captionscollection/clear/) .

## **Extract Video From Slide**

Kromě přidávání videí na snímky umožňuje Aspose.Slides také extrahovat videa vložená v prezentacích.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) pro načtení prezentace obsahující video. 
2. Procházejte všechny objekty [Slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/) .
3. Procházejte všechny objekty [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/) a najděte [VideoFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/) . 
4. Uložte video na disk.

Tento Python kód ukazuje, jak extrahovat video ze snímku prezentace:

```python
import aspose.slides as slides

# Vytvoří objekt Presentation, který představuje soubor prezentace 
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **FAQ**

**Which video playback parameters can be changed for a VideoFrame?**

Můžete ovládat [playback mode](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/play_mode/) (automaticky nebo při kliknutí) a [looping](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/play_loop_mode/). Tyto možnosti jsou k dispozici prostřednictvím vlastností objektu [VideoFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/) .

**Does adding a video affect the PPTX file size?**

Ano. Když vložíte místní video, binární data jsou zahrnuta do dokumentu, takže velikost prezentace roste úměrně velikosti souboru. Když přidáte online video, jsou vloženy pouze odkaz a miniatura, takže nárůst velikosti je menší.

**Can I replace the video in an existing VideoFrame without changing its position and size?**

Ano. Můžete vyměnit [video content](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/embedded_video/) uvnitř rámce při zachování geometrie tvaru; je to běžný scénář pro aktualizaci médií v existujícím rozvržení.

**Can the content type (MIME) of an embedded video be determined?**

Ano. Vložené video má [content type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/video/content_type/), který můžete přečíst a použít, například při ukládání na disk.