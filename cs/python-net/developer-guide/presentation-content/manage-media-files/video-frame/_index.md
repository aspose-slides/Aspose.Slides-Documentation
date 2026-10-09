---
title: Správa video snímků v prezentacích v Pythonu
linktitle: Video snímek
type: docs
weight: 10
url: /cs/python-net/video-frame/
keywords:
- přidat video
- vytvořit video
- vložit video
- extrahovat video
- získat video
- video snímek
- webový zdroj
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se programově přidávat a extrahovat video snímky v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides for Python via .NET. Rychlý návod."
---
## **Úvod**

Videa mohou pomoci vysvětlit nápady a zapojit publikum. Aspose.Slides for Python via .NET vám umožňuje přidávat video snímky do slidů, upravovat nastavení přehrávání, spravovat titulky a extrahovat vložená video data.

PowerPoint podporuje místní videa a odkazy na online videa, například videa z YouTube.

Pro reprezentaci video dat a video snímků poskytuje Aspose.Slides třídu [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) třídu [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) a další relevantní typy.

## **Vytvoření vloženého video snímku**

Pokud je video soubor, který chcete přidat do snímku, uložen lokálně, můžete vytvořit video snímek pro vložení videa do vaší prezentace.

Tento příklad vloží místní video na první snímek existující prezentace a uloží výsledek. Souřadnice a rozměry snímku jsou v bodech. Proud zůstává otevřený, dokud se ukládání nedokončí, protože [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) jej drží uzamčený, dokud jej prezentace používá.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

Můžete také předat cestu k místnímu videu přímo metodě [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). Tento příklad vloží video na první snímek nové prezentace. Video musí zůstat přístupné až do uložení prezentace.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Vytvoření video snímku s videem z webového zdroje**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) podporuje online videa v prezentacích. Můžete vytvořit video snímek, který odkazuje na online video, například video z YouTube.

Tento příklad přidá odkaz na YouTube video a náhledový obrázek na první snímek. Nahraďte identifikátor videa, pokud chcete použít jiné video. Nastavení [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) požaduje automatické přehrávání. Stažení náhledového obrázku a přehrání videa vyžadují připojení k internetu. Prohlížeč prezentací také musí podporovat přehrávání online videí.

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

## **Přehrát video v režimu celé obrazovky**

V tréninkové prezentaci můžete přehrát ukázku softwaru v režimu celé obrazovky, aby publikum vidělo detaily. Nastavte [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) na `True`, aby se během přehrávání tento režim aktivoval.

Tento příklad otevře prezentaci, najde první [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) na prvním snímku a povolí přehrávání v celé obrazovce. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video snímkem na prvním snímku.

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

Přehrávání v celé obrazovce určuje, jak je video zobrazováno. Samostatně [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) řídí, zda se spustí automaticky nebo po kliknutí, a [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) určuje, zda se opakuje. Pro výběr chování při spuštění nastavte režim přehrávání na [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). Příklad zachovává stávající nastavení spuštění a opakování.

## **Převíjení videa po přehrání**

V tréninkové prezentaci vrácení demonstračního videa na začátek jej připraví, aby ho přednášející mohl přehrát znovu. Nastavte [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) na `True`, aby se video po skončení přehrávání vrátilo na začátek.

Tento příklad otevře prezentaci, najde první [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) na prvním snímku a povolí převíjení. Vypne opakování, aby přehrávání mohlo skončit, a nastaví přehrávání na spuštění po kliknutí. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video snímkem na prvním snímku.

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

Převíjení vrátí video na začátek, aniž by jej spustilo znovu. Naproti tomu povolení [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) přehrávání automaticky opakuje. Ponechte opakování vypnuté, pokud chcete, aby video skončilo a bylo připravené k opětovnému přehrání. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) samostatně řídí automatické nebo kliknutím spuštění; tento příklad používá [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/), takže přednášející kontroluje, kdy se přehrávání spustí. Nastavte režim přehrávání po nastavení opakování, jak je ukázáno v příkladu. Převíjení funguje nezávisle na [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/).

## **Ořezání video snímku**

Použijte [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) a [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) k přeskočení části na začátku nebo na konci videa během přehrávání. Obě hodnoty jsou v milisekundách. Ořezávání mění nastavení přehrávání, aniž by upravovalo vložená video data.

**Nastavení ořezu**

Tento příklad vloží místní video a během přehrávání přeskočí první 2,5 sekundy a poslední sekundu. Použijte video delší než 3,5 sekundy, aby zůstala přehratelná část.

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

**Čtení nastavení ořezu**

Tento příklad vypíše hodnoty ořezu prvního video snímku na prvním snímku v milisekundách. Prezentace musí obsahovat alespoň jeden snímek. Pokud tento snímek nemá video snímek, nic není vytištěno. Předchozí příklad produkuje hodnoty 2500 a 1000.

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

## **Správa titulků videa**

Aspose.Slides vám umožňuje spravovat uzavřené titulky pro video snímky v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou přístupné přes vlastnost [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/).

**Přidání titulků do video snímku**

Tento příklad vloží místní video a přidá WebVTT stopu titulků označenou jako English. Časové razítka titulků by měla odpovídat videu. Uložená prezentace obsahuje jak video, tak jeho titulky.

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

Třída [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) také poskytuje přetížení, které umožňuje přidat titulky ze streamu.

**Extrahování titulků z video snímku**

Tento příklad uloží všechny stopy titulků z video snímků na prvním snímku jako samostatné soubory WebVTT. Pořadová čísla udržují výstupní soubory odlišné. Konzole hlásí počet extrahovaných stop. Prezentace musí obsahovat alespoň jeden snímek.

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

Každý objekt [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) vystavuje identifikátor titulku, popisek, binární data a text titulku jako řetězec UTF-8.

**Odstranění titulků z video snímku**

Tento příklad odstraní všechny titulky z video snímku na první pozici tvaru na prvním snímku a uloží výsledek. Předpokládá, že snímek a tvar existují a že tvar je video snímek.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Pokud potřebujete odstranit jen jednu stopu titulků, použijte metody [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) nebo [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/), místo [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/).

## **Extrahování videa ze snímku**

Kromě přidávání videí do snímků umožňuje Aspose.Slides extrahovat videa vložená v prezentacích.

Tento příklad extrahuje vložená videa ze všech snímků do samostatných číslovaných binárních souborů. Odkazovaná videa jsou přeskočena, protože neobsahují vložená data. Konzole vypíše MIME typ každého videa a celkový počet. Výstup používá obecnou příponu `.bin`; v případě potřeby ji změňte, aby odpovídala hlášenému mediálnímu typu.

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

## **Často kladené otázky**

**Které parametry přehrávání videa lze změnit pro video snímek?**

Můžete ovládat [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (automatické nebo po kliknutí) a [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). Tyto možnosti jsou dostupné prostřednictvím vlastností objektu [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).

**Zvyšuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte místní video, binární data jsou zahrnuta do dokumentu, takže velikost prezentace roste úměrně velikosti souboru. Když odkazujete na online video a přidáte náhledový obrázek, prezentace ukládá odkaz a náhledový obrázek místo video dat, takže nárůst velikosti je obvykle menší.

**Mohu nahradit video v existujícím video snímku bez změny jeho pozice a velikosti?**

Ano. Můžete vyměnit [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) v rámci snímku při zachování geometrie tvaru; to je běžný scénář při aktualizaci médií v existujícím rozložení.

**Lze zjistit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/), který můžete přečíst a použít, například při ukládání na disk.