---
title: Diák renderelése SVG képekként Pythonban
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
description: "Exportálja a PowerPoint diákat SVG képekként Pythonban, és vezérelje a betűtípusokat, szöveget és képeket az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy skálázható XML-alapú képformátum, amely jól működik webes közzétételhez, diavetítőkben, akadálymentesítési munkafolyamatokban és automatizált utófeldolgozáshoz. Az Aspose.Slides minden diát külön SVG-fájlba exportál, és lehetővé teszi, hogy szabályozza, hogyan kerülnek kiírásra a szöveg, betűtípusok, képek és SVG-elemek.

Használja a [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) akkor, amikor az exportált SVG-nek kompakt, böngészők között kiszámítható vagy interaktív használatra készen kell állnia.

## **Dia exportálása SVG formátumba**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) objektumot, válasszon ki egy diát, és írja ki egy adatfolyamba. Az alábbi példa a prezentáció minden diaját külön SVG-fájlba exportálja.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Az állományneve a [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) értékét használja a ciklusindex helyett. Egy adott alakzatot is exportálhat a [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) segítségével, ha a diavetítő vagy weboldal csak azt az alakzatot igényli.

## **SVG kimenet konfigurálása**

Az [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) vezérli az SVG renderelést. Szöveges kereteknél a [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) a szövegdobozt belevonja a renderelési területbe, és a [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) határozza meg, hogy a keret forgatása alkalmazásra kerül-e. Állítsa a [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) értékét `True`-ra, ha a szöveget ligatúrák nélkül kell megjeleníteni.

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

## **Vonalvég levágásának szabályozása nyilvégeknél**

Az SVG 1.1 nem rendelkezik jelzőbekezdés-beállítással, amely meghatározza, hol álljon le a vonal a nyilvége alatt. Alapértelmezés szerint az Aspose.Slides lerövidíti az exportált vonalat, hogy a vonalvastagság ne lógjon ki a jelzőből. Állítsa a [SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) értékét `True`-ra, hogy a vonalvastagság egészen a vonal eredeti végpontjáig legyen rajzolva. Ez a beállítás csak az SVG kimenetet érinti. A vonal pozíciója és hossza a dián változatlan marad.

A példa háromszög és gyémánt nyilvégeket rajzol 2 és 10 pont széles vonalakon. Kétszer exportálja ugyanazt a diát, csak a levágás beállítását módosítva.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    y = 40

    for style in (slides.LineArrowheadStyle.TRIANGLE, slides.LineArrowheadStyle.DIAMOND):
        for width in (2, 10):
            line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 40, y, 200, 0)
            line_format = line.line_format
            line_format.fill_format.fill_type = slides.FillType.SOLID
            line_format.fill_format.solid_fill_color.color = drawing.Color.dark_blue
            line_format.width = width
            line_format.end_arrowhead_style = style
            y += 50

    options = slides.export.SVGOptions()
    options.disable_line_end_cropping = False
    with open("cropped.svg", "wb") as cropped:
        slide.write_as_svg(cropped, options)

    options.disable_line_end_cropping = True
    with open("uncropped.svg", "wb") as uncropped:
        slide.write_as_svg(uncropped, options)
```

A összehasonlítás a 10 pontos vonalon lévő háromszög nyilvéget mutatja. Levágás engedélyezése esetén a hegy hegyes, levágás tiltása esetén a vonalvastagság kiemelkedik a jelző ferde oldalain, és lapos véget eredményez.

![10 pontos nagyított háromszög éles hegyéllel, amikor a levágás engedélyezett, és lapos végel, amikor a levágás tiltott](line-end-cropping.png)

A példában szereplő többi vonalon a kiemelkedő vonalvastagság kevésbé látható a 2 pontos háromszögön. A kitöltött gyémánt mindkét szélességnél lefedi a vonalvastagság végét.

## **Szöveg és betűtípusok vezérlése**

Diák SVG formátumba exportálásakor szabályozhatja, hogy a szöveg megmaradjon szövegként vagy vektorgrafikává alakuljon, valamint hogy a külső betűtípusok hogyan legyenek beágyazva vagy hivatkozva. A következő beállítások segítenek egyensúlyt teremteni a vizuális konzisztencia, a szövegkiválaszthatóság és a betűtípus-függőségek között az exportált SVG-ben.

### **Minden szöveg vektorizálása**

Állítsa a [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) értékét `True`-ra, hogy a dia összes szövege vektorgrafikaként kerüljön kiírásra. Ez megszünteti a betűtípus-függőségeket, és a vizuális eredményt böngészők között konzisztensebbé teszi, de a szöveg már nem lesz kiválasztható vagy kereshető SVG-szövegként.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Válassza ki, hogyan kezelje a külső betűtípusokat**

Az [SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) értéket használ a külső betöltésű betűtípusokhoz. Válassza az `ADD_LINKS_TO_FONT_FILES` lehetőséget a különálló betűtípusfájlokra való hivatkozáshoz, az `EMBED` lehetőséget a betűtípusadatok SVG-be ágyazásához, vagy a `VECTORIZE` lehetőséget, hogy a külső betűtípusokat használó szöveget grafikai formában jelenítse meg. Győződjön meg a betűtípusok licenceléséről, mielőtt beágyazná őket.

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

## **Beágyazott kép méretének csökkentése**

Használja a [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/)‑t a beágyazott képek felbontásának csökkentésére, a [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/)‑t a levágott forrásterületek kihagyására, és a [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/)‑t a JPEG kódolási minőség szabályozására. Ezek a beállítások a fájlméretet csökkentik a kép pontosságának vagy a megőrzött képadatok költségén.

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

## **Metafájl rasterizálási felbontásának szabályozása**

A [SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) meghatározza a metafájlok SVG export során történő rasterizálásának alsó felbontási határát. Használja részletesség és fájlméret egyensúlyozására, amikor EMF vagy WMF képet rasterizál. Nem definiál globális DPI-t az SVG-hez, és nem kényszeríti minden dián lévő objektum rasterképpé alakítását.

Töltse le a [metafile-rasterization.pptx](metafile-rasterization.pptx) fájlt, amely egy szorosan elrendezett átlós vonalakat tartalmazó EMF képet tartalmaz. Az alábbi példa a diák első diáját három rasterizálási felbontásban exportálja a [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/) használatával. Minden egyéb exportbeállítás változatlan marad, hogy az eredmények összehasonlíthatók legyenek.

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

A kimenetben az EMF minden SVG-ben egy beágyazott PNG-fájllá vált. A következő mérések a mellékelt prezentációra vonatkoznak; nem általános képlet a DPI pixelméretre való átváltásához.

| Metafájl rasterizálás DPI | Beágyazott PNG méretek | SVG fájlméret (bájt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Az alábbi összehasonlítás ugyanazt a beágyazott rasztert mutatja ugyanakkora nagyított megjelenítési mérettel. A diagonális vonalak látható pixelálást mutatnak 72 DPI-n, magasabb felbontásnál simább éleket, miközben az SVG-fájl mérete nő. A felbontás növelése nem feltétlenül javít minden részletet vagy változtat minden exportált képet.

![Nagyított átlós vonal részlet 72, 150 és 300 DPI-n](metafile-rasterization-comparison.png)

Az [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) szabályozza a kép felbontáscsökkentést, és elfedheti a metafájl rasterizálási felbontás változtatásának hatását. Az [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) a JPEG kódolási minőséget szabályozza, nem a metafájl rasterizálási felbontást.

## **GYIK**

**Mikor kell használni az [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/)‑t a [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) helyett?**

Használja az [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/)‑t, amikor az összes szövegnek függetlennek kell lennie a betűtípusoktól. Használja a [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)‑t, amikor csak a külső betűtípusokat használó szöveget kell grafikává konvertálni.

**Mi a legjobb módja egy SVG kisebbé tételének?**

Kezdje a beágyazott képek tömörítésével, a levágott képrészletek törlésével, és ha a céleszköz képes kiszolgálni, a hivatkozott betűtípusfájlok kiválasztásával. Tesztelje az eredményt, mivel az alacsonyabb képfelbontás, a csökkent JPEG‑minőség és a vektorizált szöveg mind különböző minőség‑ és méret‑kompromisszumokkal jár.