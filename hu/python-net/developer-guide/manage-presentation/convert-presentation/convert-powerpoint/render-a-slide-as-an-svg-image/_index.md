---
title: Prezentációs diák SVG képekként Pythonban
linktitle: Dia SVG-re
type: docs
weight: 50
url: /hu/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint SVG-re
- prezentáció SVG-re
- dia SVG-re
- PPT SVG-re
- PPTX SVG-re
- SVG exportálási beállítások
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Exportálja a PowerPoint diákat SVG képekként Pythonban, és szabályozza a betűtípusokat, szöveget és képeket az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy skálázható, XML-alapú képfájl-formátum, amely jól működik webes publikálás, diamegjelenítők, hozzáférhetőségi munkafolyamatok és automatizált utófeldolgozás esetén. Az Aspose.Slides minden diát külön SVG fájlba exportál, és lehetővé teszi, hogy szabályozza, hogyan kerülnek kiírásra a szövegek, betűtípusok, képek és SVG elemek.

Használja a [SVGOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/svgoptions/) akkor, amikor az exportált SVG-nek kompaktnek, böngészők között kiszámíthatónak vagy interaktív használatra készen kell állnia.

## **Dia exportálása SVG-ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/), válasszon ki egy diát, és írja ki egy stream-be. Az alábbi példában a prezentáció minden diáját külön SVG fájlba exportálja.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

A fájlnév a [Slide.slide_number](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/slide_number/) értékét használja a ciklusindex helyett. Egyéni alakzatot is exportálhat a [Shape.write_as_svg](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/write_as_svg/) segítségével, ha egy diamegjelenítő vagy weboldal csak azt az alakzatot igényli.

## **SVG kimenet konfigurálása**

A [SVGOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/svgoptions/) vezérli az SVG renderelését. Szövegkeretek esetén a [SVGOptions.use_frame_size](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/svgoptions/use_frame_size/) a szövegkeretet is belefoglalja a megjelenítési területbe, míg a [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) meghatározza, hogy a keret forgatása alkalmazásra kerülj‑e. Állítsa a [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) értékét `True`‑ra, ha a szöveget ligatúrák nélkül kell renderelni.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **Szöveg és betűtípusok ellenőrzése**

### **Minden szöveg vektorizálása**

Állítsa a [SVGOptions.vectorize_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/svgoptions/vectorize_text/) értékét `True`‑ra, hogy a dia összes szövegét vektorgrafikaként írja ki. Ez megszünteti a betűtípus-függőségeket, és a vizuális eredményt egységesebbé teszi a böngészők között, de a szöveg már nem lesz kijelölhető vagy kereshető SVG‑szövegként.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Válassza ki, hogyan kezelje a külső betűtípusokat**

A [SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/svgexternalfontshandling/) értéket használ a külsőként betöltött betűtípusokhoz. Válassza a `ADD_LINKS_TO_FONT_FILES`‑t, ha külön betűtípus‑fájlokra szeretne hivatkozni, az `EMBED`‑et, ha a betűtípus‑adatokat beágyazza az SVG‑be, vagy a `VECTORIZE`‑t, ha csak a külső betűtípust használó szövegeket kívánja grafikaként renderelni. Ellenőrizze a betűtípus‑licencet a beágyazás előtt.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **Beágyazott képek méretének csökkentése**

Használja a [SVGOptions.pictures_compression](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/svgoptions/pictures_compression/)‑t a beágyazott képek felbontásának csökkentéséhez, a [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/)‑t a levágott forrásterületek kihagyásához, valamint a [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/svgoptions/jpeg_quality/)‑t a JPEG kódolás minőségének szabályozásához. Ezek a beállítások a fájlméretet csökkentik a kép pontosságának vagy a megőrzött képadatnak a kárára.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **FAQ**

**Mikor kell a [SVGOptions.vectorize_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/svgoptions/vectorize_text/) használni a [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/svgexternalfontshandling/) helyett?**

Használja a [SVGOptions.vectorize_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/svgoptions/vectorize_text/)‑t, ha minden szövegnek függetlennek kell lennie a betűtípusoktól. Használja a [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/svgexternalfontshandling/)‑t, ha csak a külső betűtípust használó szövegeket szeretné grafikává konvertálni.

**Mi a legjobb módja egy SVG méretének csökkentésére?**

Kezdje a beágyazott képek tömörítésével, a levágott képrészletek törlésével, és a hivatkozott betűtípus‑fájlok kiválasztásával, ha a célkörnyezet képes azokat kiszolgálni. Tesztelje az eredményt, mivel alacsonyabb képfelbontás, alacsonyabb JPEG‑minőség és a vektorizált szöveg mind különböző minőség‑ és méret‑kompromisszummal jár.