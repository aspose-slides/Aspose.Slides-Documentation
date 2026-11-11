---
title: Prezentációs diákat SVG képekként exportálni Pythonban Java-n keresztül
linktitle: Dia SVG-re
type: docs
weight: 50
url: /hu/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint SVG-re
- prezentáció SVG-re
- dia SVG-re
- PPT SVG-re
- PPTX SVG-re
- SVG exportálási beállítások
- interaktív SVG
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Exportálja a PowerPoint diákat SVG képekként Pythonban Java segítségével, és szabályozza a betűkészleteket, szöveget, képeket, azonosítókat és eseményeket az Aspose.Slides használatával."
---
## **Áttekintés**

Az SVG egy skálázható, XML-alapú képformátum, amely jól működik webes kiadványok, diavetítők, hozzáférhetőségi munkafolyamatok és automatikus utófeldolgozás esetén. Az Aspose.Slides minden diát külön SVG fájlba exportál, és lehetővé teszi a szöveg, betűkészletek, képek és SVG elemek írásának vezérlését.

Használja a [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) elemet, ha az exportált SVG‑nek kompaktnak, böngészők között előre láthatónak vagy interaktív használatra készen kell állnia.

## **Dia exportálása SVG‑ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) objektumot, válasszon ki egy diát, és írja ki egy áramba a [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) metódussal. A példák egy meglévő `presentation.pptx` fájlt feltételeznek. Minden példa elindítja a JVM‑et, ha szükséges, és lezárja a kimeneti áramokat. Az alábbi példa a prezentáció minden diáját külön SVG fájlként exportálja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

A fájlnév a [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) metódust használja a ciklusindex helyett. Egyetlen alakzatot is exportálhat a [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) metódussal, amikor egy diavetítő vagy weboldal csak azt az alakzatot igényli.

## **SVG kimenet konfigurálása**

A [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) vezérli az SVG renderelését. Szövegdobozok esetén a [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) a szövegdobozt is belefoglalja a renderelési területbe, a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) pedig meghatározza, hogy a doboz forgatása alkalmazásra kerül-e. Állítsa a [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) értékét `True`‑ra, ha a szöveget ligatúrák nélkül kell renderelni.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Vonalvégi levágás szabályozása nyilfejeknél**

Az SVG 1.1 nem tartalmaz marker‑inset beállítást, amely megadná, hol álljon meg egy vonal a nyílfej alatt. Alapértelmezés szerint az Aspose.Slides rövidíti az exportált vonalat, hogy a vonal vastagsága ne lógjon ki a markerből. Hívja a [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) metódust `True`‑val, hogy a vonal teljesen a eredeti végpontjáig legyen rajzolva. Ez a beállítás csak az SVG kimenetet befolyásolja. A vonal pozíciója és hossza a dián változatlan marad.

A példa háromszög‑ és rombusz‑nyilfejeket rajzol 2‑ és 10‑pont széles vonalakon. Kétszer exportálja ugyanazt a diát, csak a levágási beállítást változtatva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, Presentation, ShapeType, SVGOptions
from java.awt import Color
from java.io import FileOutputStream

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    y = 40

    for style in [LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond]:
        for width in [2, 10]:
            line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0)
            line_format = line.getLineFormat()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
            line_format.setWidth(width)
            line_format.setEndArrowheadStyle(style)
            y += 50

    svg_options = SVGOptions()
    for disable_cropping, output_file_name in [(False, "cropped.svg"), (True, "uncropped.svg")]:
        svg_options.setDisableLineEndCropping(disable_cropping)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Az összehasonlítás a 10‑pontos vonalon a háromszög‑nyilfejet mutatja. Levágás engedélyezésekor a csúcs éles. Levágás letiltása esetén a vonal a marker ferde oldalain keresztül kiugrik, és lapos végződést hagy.

![Nagyított 10‑pontos háromszög éles hegyével, amikor a levágás engedélyezett, és lapos végével, amikor a levágás le van tiltva](line-end-cropping.png)

A példában szereplő többi vonalon a kiugró vonal kevésbé látható a 2‑pontos háromszögnél. A kitöltött rombusz mindkét szélességnél lefedi a vonal végét.

## **Szöveg és betűkészletek szabályozása**

SVG‑k exportálásakor szabályozhatja, hogy a szöveg szövegként marad‑e, vagy vektorgrafikává alakuljon, illetve hogyan kerülnek be vagy hivatkoznak a külső betűkészletek. A következő beállítások segítenek egyensúlyt teremteni a vizuális konzisztencia, a szövegkijelölés és a betűkészlet‑függőségek között az exportált SVG‑ben.

### **Minden szöveg vektorizálása**

Állítsa a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) értékét `True`‑ra, hogy a dia összes szövegét vektorgrafikaként írja ki. Ez megszünteti a betűkészlet‑függőségeket és a vizuális eredményt egységesebbé teszi a böngészők között, de a szöveg már nem lesz kijelölhető vagy kereshető SVG‑szövegként.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **Külső betűkészletek kezelési módjának kiválasztása**

A [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) értéket használ a külsőleg betöltött betűkészletekhez. Válassza a `AddLinksToFontFiles`‑t a különálló betűkészlet‑fájlokra való hivatkozáshoz, az `Embed`‑et a betűkészlet‑adatok SVG‑be ágyazásához, vagy a `Vectorize`‑t, hogy csak a külső betűkészleteket használó szöveget alakítsa vektorgrafikává. Az ágyazás előtt ellenőrizze a betűkészlet licencelését.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **Beágyazott képek méretének csökkentése**

Használja a [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) metódust a beágyazott képek felbontásának csökkentéséhez, a [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) metódust a levágott forrásterületek elhagyásához, valamint a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) metódust a JPEG kódolás minőségének szabályozásához. Ezek a beállítások csökkentik a fájlméretet a kép pontosságának vagy a megőrzött képadatoknak az árán.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Metafájl rasterizációs felbontásának szabályozása**

A [SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) az SVG exportálásakor a metafájlok rasterizálásának alsó felbontási határát állítja be. Ezt a beállítást használja a részletek és a fájlméret közti egyensúly megtalálásához, amikor egy EMF vagy WMF kép rasterizálódik. Nem definiál globális DPI‑t az SVG‑hez, és nem kényszeríti, hogy a dia minden objektuma raszteres képpé alakuljon.

Töltse le a [metafile-rasterization.pptx](metafile-rasterization.pptx) fájlt, amely egy EMF képet tartalmaz szorosan elhelyezett átlós vonalakkal. A következő példa az első diát három rasterizációs felbontásban exportálja a [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) metódussal. Az összes többi exportálási beállítás változatlan marad, hogy az eredmények összehasonlíthatók legyenek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

A kimenetben az EMF minden SVG‑ben egy beágyazott PNG‑vé vált. Az alábbi mérések a mellékelt prezentációra vonatkoznak; nem általános képlet a DPI‑ról pixelméretre való átalakításhoz.

| Metafájl rasterizáció DPI | Beágyazott PNG méretek | SVG fájlméret (bájt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Az alábbi összehasonlítás ugyanazt a beágyazott raster területet mutatja azonos, nagyított megjelenítési mérettel. A 72 DPI‑nél látható pixeláció a átlós vonalakon, míg a nagyobb felbontásoknál simább élek jelennek meg, és az SVG fájl mérete nő. A felbontás növelése nem feltétlenül javít minden részletet, és nem változtat minden exportált képen.

![Nagyított átlóvonalszegmens részlete 72, 150 és 300 DPI](metafile-rasterization-comparison.png)

A [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) szabályozza a kép felbontáscsökkentést, és elrejtheti a metafájl rasterizáció felbontásának változtatásának hatását. A [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) a JPEG kódolás minőségét, nem pedig a metafájl rasterizációs felbontását szabályozza.

## **Állandó azonosítók hozzárendelése alakzatokhoz és szöveghez**

Használjon egy Python formázási vezérlőt, amelyet a `jpype.JProxy`‑on keresztül regisztrálnak, hogy a [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) értékeket rendeljen a alakzatokhoz és a [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) értékeket a szöveg `tspan` elemeihez. A vezérlőt a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) metódussal adja meg.

Az alábbi vezérlő a [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId) metódust használja, amely az alakzat élettartama alatt stabil, valamint egy ismételhető számlálót a szövegtartományokhoz. Ez a generált azonosítót alkalmassá teszi egy változatlan prezentáció utófeldolgozásához.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **SVG eseménykezelők hozzáadása**

Egy Python formázási vezérlőben hívja a [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) metódust egy [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) értékkel, hogy JavaScript eseménykezelőt adjon egy exportált alakzathoz. Regisztrálja a vezérlőt a `jpype.JProxy`‑on keresztül, és rendelje hozzá a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) metódussal. Definiálja a JavaScript függvényt az oldalban vagy az SVG dokumentumban, amely a kimenetet tartalmazza.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

A host oldal definiálhatja a kezelő által hivatkozott JavaScript függvényt. Azonosítók és eseménykezelők hozzárendelése lehetővé teszi a diavetítők, a hozzáférhetőségi fejlesztések és más interaktív SVG munkafolyamatok használatát.

## **GYIK**

**Mikor kell a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) metódust használni a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) helyett?**

Használja a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) metódust, ha minden szöveget függetlenül kell tenni a betűkészletektől. Használja a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) metódust, ha csak a külső betűkészleteket használó szövegeket kell grafikává konvertálni.

**Mi a legjobb módja egy SVG méretének csökkentésére?**

Kezdje a beágyazott képek tömörítésével, a levágott képrészek törlésével, és a linkelt betűkészlet‑fájlok választásával, ha a célkörnyezet képes azokat kiszolgálni. Tesztelje az eredményt, mivel az alacsonyabb képfelbontás, alacsonyabb JPEG minőség és a vektorizált szöveg mind különböző minőség‑ és méret‑kompromisszumokat eredményeznek.

**Módosíthatom‑e az exportált SVG elemeket az export után?**

Igen. Rendeljen azonosítókat egy formázási vezérlővel, majd válassza ki a megfelelő SVG elemeket az utófeldolgozó eszközben vagy böngésző‑szkriptben.