---
title: Přidání videí do prezentací v Pythonu
linktitle: Video Rámec
type: docs
weight: 10
url: /cs/python-net/video-frame/
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
description: "Naučte se programově přidávat a extrahovat video rámečky v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro Python přes .NET. Rychlý návod jak postupovat."
---
## **Úvod**

Dobře umístěné video v prezentaci může učinit vaše sdělení přesvědčivějším a zvýšit úroveň zapojení publika. 

PowerPoint vám umožňuje přidávat videa do snímku v prezentaci dvěma způsoby:

* Přidejte nebo vložte místní video (uložené ve vašem počítači)
* Přidejte online video (z webového zdroje, například YouTube).

Aby bylo možné přidávat videa (video objekty) do prezentace, Aspose.Slides poskytuje třídu [Video](https://reference.aspose.com/slides/cs/python-net/aspose.slides/video/) , třídu [VideoFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/) a další související typy. 

## **Vytvoření vloženého video rámce**

Pokud je video soubor, který chcete přidat do snímku, uložen lokálně, můžete vytvořit video rámec pro vložení videa do vaší prezentace. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Přidejte objekt [Video](https://reference.aspose.com/slides/cs/python-net/aspose.slides/video/) a předávejte cestu k video souboru pro vložení videa do prezentace. 
4. Přidejte objekt [VideoFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/) pro vytvoření rámce pro video.  
5. Uložte upravenou prezentaci. 

Tento Python kód ukazuje, jak přidat video uložené lokálně do prezentace:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Získá první snímek a přidá video rámec
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Uloží prezentaci na disk
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Alternativně můžete přidat video předáním jeho cesty k souboru přímo do metody `add_video_frame(x, y, width, height, fname)`:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **Vytvoření video rámce s videem z webového zdroje**

Microsoft [PowerPoint 2013 a novější](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) podporuje videa z YouTube v prezentacích. Pokud je video, které chcete použít, dostupné online (např. na YouTube), můžete jej přidat do prezentace pomocí jeho webového odkazu. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) 
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Přidejte objekt [Video](https://reference.aspose.com/slides/cs/python-net/aspose.slides/video/) a předávejte odkaz na video.
4. Nastavte náhled pro video rámec. 
5. Uložte prezentaci. 

Tento Python kód ukazuje, jak přidat video z webu do snímku v PowerPoint prezentaci:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Přidá video rámec
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

## **Správa titulků videa**

Aspose.Slides vám umožňuje spravovat uzavřené titulky pro video rámce v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou dostupné prostřednictvím vlastnosti [VideoFrame.caption_tracks](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/caption_tracks/) .

**Přidání titulků do video rámce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
2. Přidejte video do prezentace.
3. Přidejte objekt [VideoFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/) na snímek.
4. Použijte [CaptionsCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/captionscollection/) , která je vrácena metodou [caption_tracks](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/caption_tracks/) , k přidání WebVTT stopy titulků.
5. Uložte upravenou prezentaci.

Následující kód ukazuje, jak přidat titulky do video rámce:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Přidá novou stopu titulků z WebVTT souboru.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

Třída [CaptionsCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/captionscollection/) také poskytuje přetížení, které vám umožní přidávat titulky ze streamu.

**Extrahování titulků z video rámce**

1. Načtěte prezentaci, která obsahuje video.
2. Najděte cílový objekt [VideoFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/) .
3. Projděte kolekci [caption_tracks](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/caption_tracks/) .
4. Uložte každou stopu titulků do souboru `.vtt` .

Následující kód ukazuje, jak extrahovat titulky z video rámce:

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

Každý objekt [Captions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/captions/) zveřejňuje identifikátor titulků, popisek, binární data a text titulků jako řetězec UTF-8.

**Odstranění titulků z video rámce**

1. Načtěte prezentaci, která obsahuje video.
2. Získejte cílový objekt [VideoFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/) .
3. Odstraňte stopy titulků z [CaptionsCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/captionscollection/) .
4. Uložte upravenou prezentaci.

Následující kód ukazuje, jak odstranit všechny titulky z video rámce:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # typ: slides.VideoFrame

    # Odstraní všechny titulky z video rámce.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Pokud potřebujete odstranit pouze jednu stopu titulků, použijte metody [remove](https://reference.aspose.com/slides/cs/python-net/aspose.slides/captionscollection/remove/) nebo [remove_at](https://reference.aspose.com/slides/cs/python-net/aspose.slides/captionscollection/remove_at/) místo [clear](https://reference.aspose.com/slides/cs/python-net/aspose.slides/captionscollection/clear/) .

## **Extrahování videa ze snímku**

Kromě přidávání videí do snímků vám Aspose.Slides umožňuje extrahovat videa vložená v prezentacích.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) , abyste načetli prezentaci obsahující video. 
2. Projděte všechny objekty [Slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/) .
3. Projděte všechny objekty [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/) , abyste našli [VideoFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/) . 
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

## **Často kladené otázky**

**Které parametry přehrávání videa lze změnit pro VideoFrame?**

Můžete řídit [režim přehrávání](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/play_mode/) (automaticky nebo na kliknutí) a [opakování](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/play_loop_mode/) . Tyto možnosti jsou dostupné prostřednictvím vlastností objektu [VideoFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/) .

**Ovlivňuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte místní video, binární data jsou zahrnuta do dokumentu, takže velikost prezentace roste úměrně velikosti souboru. Když přidáte online video, vloží se odkaz a náhled, takže nárůst velikosti je menší.

**Mohu nahradit video v existujícím VideoFrame, aniž bych změnil jeho pozici a velikost?**

Ano. Můžete vyměnit [obsah videa](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/embedded_video/) v rámci rámce při zachování geometrie tvaru; to je běžný scénář pro aktualizaci média v existujícím rozložení.

**Lze určit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [typ obsahu](https://reference.aspose.com/slides/cs/python-net/aspose.slides/video/content_type/) , který můžete přečíst a použít, například při ukládání na disk.