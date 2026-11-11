---
title: Dia előadás renderelése SVG képeként Pythonban
linktitle: Dia SVG-be
type: docs
weight: 50
url: /hu/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint SVG-be
- prezentáció SVG-be
- dia SVG-be
- PPT SVG-be
- PPTX SVG-be
- SVG exportálási beállítások
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Exportálja a PowerPoint diákat SVG képeként Pythonban, és szabályozza a betűkészleteket, a szöveget és a képeket az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy méretezhető XML-alapú képfájlformátum, amely jól használható webes közzétételhez, diavetítőknek, akadálymentesítési munkafolyamatokhoz és automatizált utófeldolgozáshoz. Az Aspose.Slides minden diát külön SVG fájlba exportál, és lehetővé teszi a szöveg, betűkészletek, képek és SVG elemek írásának szabályozását.

Használja a [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) beállítást, ha az exportált SVG-nek kompakt, böngészők között kiszámítható vagy interaktív felhasználásra késznek kell lennie.

## **Dia exportálása SVG formátumban**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-t, válasszon ki egy diát, és írja azt egy adatfolyamba. A következő példa egy bemutató minden diáját külön SVG fájlként exportálja.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

A fájlnév a [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) értékét használja a ciklusindex helyett. Egy adott alakzatot is exportálhat a [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) metódussal, ha egy diavetítő vagy weboldal csak azt az alakzatot igényli.

## **SVG kimenet konfigurálása**

A [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) szabályozza az SVG renderelését. Szövegkeretek esetén a [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) a szövegkeretet is beleszámítja a renderelési területbe, a [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) pedig meghatározza, hogy a keret forgatása alkalmazásra kerül-e. Állítsa a [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) értékét **True**-ra, ha a szöveget ligatúrák nélkül kell renderelni.

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

## **Szöveg és betűkészletek vezérlése**

SVG-be exportáláskor szabályozhatja, hogy a szöveg megmarad-e szövegként vagy vektorgrafikává alakul, valamint hogy a külső betűkészletek hogyan legyenek beleértve vagy hivatkozva. A következő beállítások segítenek egyensúlyt teremteni a vizuális konzisztencia, a szövegkijelölhetőség és a betűkészlet-függőségek között az exportált SVG-ben.

### **Minden szöveg vektorizálása**

Állítsa a [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) értékét **True**‑ra, hogy a diák összes szövege vektorgrafikaként kerüljön kiírásra. Ez megszünteti a betűkészlet-függőségeket, és a vizuális eredményt konzisztensbben jeleníti meg a böngészők között, de a szöveg már nem lesz kijelölhető vagy kereshető SVG szövegként.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Külső betűkészletek kezelési módjának kiválasztása**

A [SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) értéket használ a külsőleg betöltött betűkészletekhez. Válassza a `ADD_LINKS_TO_FONT_FILES` értéket a különálló betűkészlet-fájlokra való hivatkozáshoz, az `EMBED` értéket a betűkészlet adatainak SVG-be beágyazásához, vagy a `VECTORIZE` értéket ahhoz, hogy a külső betűkészleteket használó szöveg csak grafikaként kerüljön renderelésre. Minden esetben ellenőrizze a betűkészlet-licencelést a beágyazás előtt.

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

Használja a [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) beállítást a beágyazott képek felbontásának csökkentéséhez, a [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) beállítást a levágott forrásrészletek kihagyásához, valamint a [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) beállítást a JPEG kódolás minőségének szabályozásához. Ezek a beállítások csökkentik a fájlméretet a kép pontosságának vagy a megőrzött képadatok mennyiségének árán.

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

## **Metafájl rasterizációs felbontásának vezérlése**

A [SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) meghatározza az alacsonyabb felbontási határt a metafájlok rasterizálásához az SVG exportálás során. Ezt használja a részletgazdagság és a fájlméret közti egyensúlyhoz, amikor egy EMF vagy WMF kép rasterizálásra kerül. Nem definiál globális DPI‑t a SVG számára, és nem kényszeríti minden objektum rasterképpé alakítását a dián.

Töltse le a [metafile-rasterization.pptx](metafile-rasterization.pptx) fájlt, amely egy EMF képet tartalmaz szorosan elhelyezkedő átlós vonalakkal. Az alábbi példa az első diát három rasterizációs felbontásban exportálja a [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/) metódus segítségével. A többi exportbeállítás azonos marad, így az eredmények összehasonlíthatók.

```py
import aspose.slides as slides

with slides.Presentation("metafile-rasterization.pptx") as presentation:
    for dpi in (72, 150, 300):
        svg_options = slides.export.SVGOptions()
        svg_options.metafile_rasterization_dpi = dpi
        svg_options.pictures_compression = slides.export.PicturesCompression.DPI330
        svg_options.jpeg_quality = 90

        with open("slide-{}.svg".format(dpi), "wb") as svg_stream:
            presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

A kimenetben az EMF minden SVG‑ben egy beágyazott PNG‑vé változott. Az alábbi mérések a mellékelt bemutatóhoz tartoznak; nem általános képletet adnak a DPI‑t pixelméretekre konvertáláshoz.

| Metafájl rasterizáció DPI | Beágyazott PNG méretek | SVG fájlméret (bájt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Az alábbi összehasonlítás ugyanazt a beágyazott raster területet mutatja azonos nagyított megjelenítési mérettel. A 72 DPI‑nél látható a pixelesedés, míg a magasabb felbontásoknál a vonalak simábbak, ugyanakkor az SVG‑fájl is növekszik. A felbontás növelése nem feltétlenül javít minden részletet vagy változtat minden exportált képet.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

A [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) szabályozza a képfelbontás csökkentését, és elrejtheti a metafájl rasterizációs felbontás változtatásának hatását. A [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) a JPEG kódolás minőségét, nem pedig a metafájl rasterizációs felbontását állítja.

## **GYIK**

**Mikor érdemes a [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) beállítást használni a [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) helyett?**

Használja a [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) beállítást, ha minden szöveget függetleníteni kell a betűkészletektől. Használja a [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) beállítást, ha csak a külső betűkészleteket használó szövegeket kell grafikává alakítani.

**Mi a legjobb módja egy SVG fájl méretének csökkentésére?**

Kezdje a beágyazott képek tömörítésével, a levágott képterületek törlésével, és a hivatkozott betűkészlet-fájlok választásával, ha a célkörnyezet képes azokat kiszolgálni. Tesztelje az eredményt, mivel az alacsonyabb képfelbontás, a gyengébb JPEG minőség és a vektorizált szöveg mind különböző minőség‑ és méret‑kompromisszumokat jelentenek.