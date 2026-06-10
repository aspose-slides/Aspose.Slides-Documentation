---
title: PowerPoint prezentációk konvertálása HTML-re Pythonban
linktitle: PowerPoint HTML-re
type: docs
weight: 30
url: /hu/python-net/convert-powerpoint-to-html/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint HTML-re
- prezentáció HTML-re
- dia HTML-re
- PPT HTML-re
- PPTX HTML-re
- PowerPoint mentése HTML-ként
- prezentáció mentése HTML-ként
- dia mentése HTML-ként
- PPT mentése HTML-ként
- PPTX mentése HTML-ként
- PPT exportálása HTML-re
- PPTX exportálása HTML-re
- Python
- Aspose.Slides
description: "PowerPoint prezentációk konvertálása HTML-re Pythonban. Használja az Aspose.Slides-t PPT és PPTX fájlok, kiválasztott diák, jegyzetek, betűtípusok, képek, SVG és média exportálásához."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET képes a PowerPoint prezentációkat HTML‑ként menteni a Microsoft PowerPoint nélkül. Az alap konverzió egyetlen [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) betöltésből és egy `save` hívásból áll a [SaveFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/saveformat/). Használja a [HtmlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/htmloptions/)‑t, ha szabályozni szeretné az exportált elrendezést, betűtípusokat, képeket, jegyzeteket, megjegyzéseket, SVG kimenetet vagy a hivatkozott erőforrásokat.

Ez az útmutató a gyakorlati HTML export szcenáriókra összpontosít:

- Exportáljon egy teljes prezentációt vagy kiválasztott diát.
- Készítsen fix elrendezésű, reszponzív vagy SVG‑alapú HTML‑t.
- Vegye bele a prezentátori jegyzeteket és a megjegyzéseket.
- Szabályozza a képminőséget és a levágott képadatokat.
- Ágyazza be a betűtípusokat vagy mentse a betűtípusfájlokat külön.
- Válassza ki, hogyan íródnak és hivatkoznak a külső erőforrások és médiafájlok.

Alapértelmezésben a HTML export egy önmagában álló HTML dokumentumot hoz létre, ahol a legtöbb erőforrás be van ágyazva. Ez kényelmes egyetlen fájl megosztásához, de növelheti a kimenet méretét. Webes közzététel esetén fontolja meg a külső erőforrások használatát, az alacsonyabb kép‑DPI-t, valamint csak azoknak a betűtípusoknak a beágyazását, amelyek nem biztos, hogy elérhetők a célkörnyezetben.

## **Prezentáció konvertálása HTML‑re**

A prezentáció HTML‑re exportálásához töltse be a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/)‑nel, majd mentse a [SaveFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/saveformat/)-dal.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

Ez a példa egy HTML fájlt ír ki. A `with` utasítás a prezentáció objektumot felszabadítja, valamint a fájl‑kezelőket és a renderelési erőforrásokat az export után.

## **HtmlOptions használata**

A [HtmlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/htmloptions/) a fő konfigurációs osztály a HTML exporthoz. Gyakori beállítások:

- `slides_layout_options`: jegyzeteket, megjegyzéseket, anyagokat vagy egyéb elrendezési információkat ad hozzá.
- `html_formatter`: megváltoztatja a HTML dokumentum szerkezetét vagy formázást delegál egy vezérlőnek.
- `slide_image_format`: módosítja, hogyan jelennek meg a diák, például SVG‑ként.
- `pictures_compression`: szabályozza a kép DPI‑jét és a kimeneti méretet.
- `delete_pictures_cropped_areas`: megtartja vagy eltávolítja a levágott képadatokat.
- `svg_responsive_layout`: az exportált SVG tartalmat a tárolóhoz igazítja.
- `show_hidden_slides`: szükség esetén belefoglalja a rejtett diákat.

Az alábbi szakaszok a leggyakoribb lehetőségeket mutatják külön-külön, hogy csak a munkafolyamatához szükségeseket kombinálhassa.

## **Kiválasztott diák konvertálása HTML‑re**

A `save` túltöltés, amely diaszámokat fogad, 1‑bázisú diapozíciókat használ. Az alábbi ciklus minden diát külön HTML fájlba ment.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

Használja ezt a mintát, ha egy webhelynek vagy alkalmazásnak minden diára egy HTML oldalra van szüksége. Ha minden diának azonos elrendezésre van szüksége, hozzon létre egy [HtmlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/htmloptions/) példányt, és adja át minden `save` hívásnak.

## **Reszponzív HTML létrehozása**

[ResponsiveHtmlController](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/responsivehtmlcontroller/) reszponzív HTML kimenetet biztosít a [HtmlFormatter](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/htmlformatter/)‑en keresztül. Használja, ha az exportált oldal jobban kell, hogy alkalmazkodjon a böngésző szélességéhez.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

SVG‑alapú reszponzív elrendezéshez állítsa be a `svg_responsive_layout`‑t a [HtmlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/htmloptions/)-n. Ez akkor hasznos, ha a diáktartalom skálázható SVG jelölésként kerül exportálásra.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **Prezentátori jegyzetek és megjegyzések belefoglalása**

Használja a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/notescommentslayoutingoptions/)‑t a `html_options.slides_layout_options`‑on keresztül a prezentátori jegyzetek vagy megjegyzések beágyazásához. A jegyzetek és megjegyzések alapértelmezésben rejtve vannak, hacsak nem választja ki a pozíciójukat.

Tegyük fel, hogy a forrás prezentáció tartalmaz prezentátori jegyzeteket:

![Diát prezentátori jegyzetekkel a PowerPointban](slide_with_notes.png)

Az alábbi kód a diát tartalmat a diára vonatkozó jegyzetekkel exportálja.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

Az exportált HTML tartalmazza a jegyzetek területét:

![HTML kimenet a diával és a prezentátori jegyzetekkel](HTML_with_notes.png)

A megjegyzések exportálásához állítsa be a `comments_position`‑t, például `CommentsPositions.RIGHT` vagy `CommentsPositions.BOTTOM`. Ha csak megjegyzésekre van szüksége, hagyja ki a `notes_position`‑t. Ha mindkettőre, állítsa be mindkét tulajdonságot.

## **Képminőség és levágott területek szabályozása**

A HTML export képes a diákképeket tömöríteni a kimeneti méret csökkentése érdekében. Állítsa be a `pictures_compression`‑t a [PicturesCompression](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/picturescompression/) egyik értékére, ha magasabb képminőségre van szüksége.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

Alapértelmezésben a képek levágott területei eltávolíthatók az exportált kimenetből. Tartsa meg a levágott adatokat csak akkor, ha a felhasználóknak vissza kell tudniuk állítani vagy ellenőrizni ezeket a rejtett kép‑részleteket. A megtartás növelheti a HTML méretét.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **CSS hozzáadása**

Egyszerű stílusoláshoz adjon át egy CSS karakterláncot a [HtmlFormatter](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/htmlformatter/)-nek. Ez megváltoztatja a környező HTML dokumentumot, miközben az Aspose.Slides továbbra is rendereli a diáktartalmat.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

Egy egyedi dokumentumfejléc, egy csatolt CSS fájl vagy egyedi jelölőnyelv a diák és alakzatok körül egy egyedi formázóvezérlő használatával és a `create_custom_formatter`‑rel a [HtmlFormatter](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/htmlformatter/)-nek adható át.

## **Betűtípusok beágyazása**

Ha a célkörnyezetben nem biztos, hogy a prezentáció betűtípusai telepítve vannak, ágyazza be a betűtípusokat a HTML‑be a [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/embedallfontshtmlcontroller/)‑rel. A beágyazás javítja a vizuális pontosságot, de növeli a kimenet méretét.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

Egy betűtípust csak akkor hagyjon ki, ha biztos abban, hogy a célböngészők vagy rendszerek már rendelkeznek vele. Márkabetűtípusok vagy ritkább betűtípusok esetén a beágyazás általában biztonságosabb.

## **Betűtípusfájlok hivatkozása beágyazás helyett**

A HTML fájl méretének csökkentéséhez a betűtípusadatokat külön WOFF fájlokba írhatja, és `@font-face` szabályokat adhat a HTML‑hez. Ehhez egy olyan vezérlőre van szükség, amely testreszabja, hogyan íródnak a betűtípusadatok exportáláskor. Python‑on keresztül .NET‑ben ezt a vezérlőt egy kis .NET segédösszeállításban valósítsa meg, töltse be Pythonban, és adja át a segédobjektumot a [HtmlFormatter](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/htmlformatter/)-nek a `create_custom_formatter`‑rel.

Amikor a betűtípusokat externalizálja, szándékosan válasszon ki két útvonalat:

- A fájlrendszer kimeneti könyvtára, ahova a generált WOFF fájlok írásra kerülnek.
- Az URL útvonal, amely megjelenik a HTML dokumentumban, és amelyet a böngésző a betűtípusfájlok betöltéséhez használ.

Tartsa a HTML fájlt és a generált betűtípusfájlokat együtt, amíg a telepítési útvonalak véglegesek. Ha a fájlok más helyre kerülnek telepítésre, a URL előtagot igazítsa a telepített URL útvonalhoz.

## **Erőforrások mentése külsőleg**

Az önmagában álló HTML könnyen mozgatható, de a beágyazott Base64 erőforrások nagy méretűvé tehetik a fájlt. Ha alkalmazásának külső képfájlokra, betűtípusokra, hang‑ vagy videófájlokra van szüksége, használjon egy egyedi link‑/beágyazás‑vezérlőt, és adja át a [HtmlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/htmloptions/) konstruktorának.

Amikor az erőforrásokat externalizálja, szándékosan válasszon ki két útvonalat:

- A fájlrendszer kimeneti útvonala, ahova az alkalmazás a generált képeket, betűtípusokat, hang‑ vagy videófájlokat írja.
- Az URL útvonal, amelyet a böngésző a HTML dokumentumból a fájlok betöltéséhez használ.

A teljes kép‑linkelési témáért lásd a [Export Presentations to HTML with Externally Linked Images](/slides/hu/python-net/exporting-presentations-to-html-with-externally-linked-images/) cikket.

## **Médiafájlok exportálása**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/videoplayerhtmlcontroller/) videó‑ és hangfájlokat exportál, és olyan HTML‑t ír, amely a böngészőben le tudja játszani őket. A konstruktor a következőket veszi:

- `path`: a könyvtár, ahova a generált médiafájlok írásra kerülnek.
- `file_name`: a generált HTML fájl neve.
- `base_uri`: a médiafájlokra mutató HTML hivatkozásokban használt abszolút URI előtag.

Ha a HTML fájl `html-output/presentation.html`, a médiafájlok pedig `html-output/media`‑ben mentődnek, a `path`‑nak a lemezen a média könyvtárra kell mutatnia, míg a `base_uri`‑nak a böngésző nézőpontjából ugyanarra a könyvtárra. Helyi előnézethez a média könyvtárból építhet `file:///` URI‑t. Telepített alkalmazáshoz használja a közzétett média könyvtár abszolút URL‑jét.

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

Használjon olyan kimeneti könyvtárakat, amelyek egyediek minden exportfeladatra, különösen szerveralkalmazásokban. A megosztott kimeneti útvonalak miatt különböző konverziók fájljai felülírhatják egymást.

## **Teljesítmény és erőforrás‑kezelés**

A HTML konverzió egy renderelési művelet, ezért a feldolgozási idő és memóriahasználat a diák számától, a kép felbontásától, a betűtípusoktól, a hatásoktól, a diagramoktól és a beágyazott médiumtól függ. A magasabb `pictures_compression` DPI‑értékek, a beágyazott betűtípusok, az SVG kimenet és a megtartott levágott képrészletek javíthatják a pontosságot, de általában növelik a kimenet méretét.

Kötegelt konverzióhoz:

- Azonnal szabadítsa fel minden [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt.
- Használjon külön kimeneti könyvtárakat külön feladatokhoz.
- Kerülje a gyakori betűtípusok beágyazását, kivéve ha a pontosság megköveteli.
- Csökkentse a kép DPI‑jét, ha a HTML előnézet vagy miniatűrök céljára készült.
- Tartsa a forrás prezentációt, a generált HTML‑t és a külső erőforrásokat együtt, amíg a telepítési útvonalak véglegesek.

## **GYIK**

**Megmaradnak a hiperhivatkozások a HTML kimenetben?**

Igen. A prezentáció hiperhivatkozásai exportálva lesznek HTML‑be és kattinthatóak maradnak, ha a cél URL érvényes.

**Konvertálhatok prezentációkat HTML‑re párhuzamosan?**

Igen, de ne osszon meg egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt szálak között. Külön fájlok feldolgozásához használjon külön prezentációs példányokat, külön folyamokat és külön kimeneti könyvtárakat. Lásd a [multithreading guidance](/slides/hu/python-net/multithreading/) cikket a részletekért.

**A Presentation objektum szálbiztos?**

Nem. Egyetlen [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt csak egy szálon kell betölteni, módosítani, menteni és felszabadítani. Párhuzamos munka esetén hozzon létre független példányt szálanként vagy folyamatanként.

**Miért nagy a generált HTML fájl?**

Az alap export beágyazhatja az erőforrásokat közvetlenül a HTML‑be. A beágyazott betűtípusok, a magas DPI‑jú képek, a média, az SVG tartalom és a megtartott levágott képterületek is növelik a méretet. Használjon külső erőforrásokat, zárja ki a gyakori betűtípusok beágyazását, és csökkentse a `pictures_compression`‑t, ha a kisebb kimenet fontosabb a maximális pontosságnál.

**Miért jelenik meg a PowerPoint 24 pt betűmérete 17,999819 pt‑ként a HTML‑ben?**

Ez azért fordulhat elő, mert a PowerPoint és a HTML külön DPI‑modelleket használ. A PowerPoint a tipográfiai pontokat 72 DPI‑n alapuló rendszerben tárolja, míg a HTML elrendezése a CSS pixelre épül, amely a 96 DPI‑s modell. Amikor az Aspose.Slides prezentációt HTML‑re exportál, a betűméret átalakul ezen rendszerek között, és a konverzió apró kerekítési különbségeket eredményezhet.

Ezek az értékek nem jelentenek valós vizuális betűméret‑változást. Csak a szövegmértékek PowerPoint és HTML közti átalakításának matematikai mellékhatásai.

**Hogyan válasszam a base_uri‑t a média exportálásához?**

Válassza a `base_uri`‑t a böngésző nézőpontjából, és adja meg abszolút URI‑ként. Helyi előnézethez a kimeneti könyvtárból származtathatja a `Path(media_directory).as_uri() + "/"`‑vel. Telepítéskor használja a közzétett média könyvtár abszolút URL‑jét. A fájlrendszer `path` és a böngésző `base_uri` nem kell, hogy ugyanaz a karakterlánc legyen, de ugyanarra az erőforrás‑helyre kell mutatniuk.

**Be tudok‑e vonni rejtett diákat?**

Igen. Állítsa be a `show_hidden_slides = True`‑t a [HtmlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/htmloptions/)‑n, ha a rejtett diákat is exportálni kell.