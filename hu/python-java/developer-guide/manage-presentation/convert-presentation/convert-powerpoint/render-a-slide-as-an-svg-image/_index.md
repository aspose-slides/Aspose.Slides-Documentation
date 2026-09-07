---
title: Prezentációs diák SVG képekként történő renderelése Pythonban Java-n keresztül
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
description: "Exportálja a PowerPoint diákat SVG képekként Pythonban Java használatával, és szabályozza a betűtípusokat, szöveget, képeket, azonosítókat és eseményeket az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy skálázható XML-alapú képfájlformátum, amely jól működik webes közzétételhez, előadásnézőkhöz, akadálymentesítési munkafolyamatokhoz és automatizált utófeldolgozáshoz. Az Aspose.Slides minden diákat külön SVG-fájlba exportálja, és lehetővé teszi a szöveg, betűtípusok, képek és SVG-elemek írásának szabályozását.

Használja a [SVGOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgoptions/) elemet, ha az exportált SVG-nek kompaktnak, böngészők között kiszámíthatónak vagy interaktív felhasználásra készen kell lennie.

## **Dia exportálása SVG‑ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektumot, válasszon ki egy diát, és írja ki egy adatfolyamba a [Slide.writeAsSvg](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/) metódussal. A példák egy meglévő `presentation.pptx` fájlt igényelnek. Minden példa szükség esetén elindítja a JVM-et és lezárja a kimeneti adatfolyamokat. Az alábbi példa a prezentáció minden diáját külön SVG-fájlként exportálja.

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

A fájlnevet a [Slide.getSlideNumber](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getSlideNumber) metódus adja, nem a ciklus indexe. Egyéni alakzatot is exportálhat a [Shape.writeAsSvg](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) metódussal, ha egy dianézőnek vagy weboldalnak csak az az alakzat szükséges.

## **SVG kimenet konfigurálása**

Az [SVGOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgoptions/) szabályozza az SVG renderelését. Szövegkeretek esetén a [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgoptions/#setUseFrameSize) a szövegkeretet a renderelési területbe vonja be, és a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgoptions/#setUseFrameRotation) meghatározza, hogy a keret forgatása alkalmazásra kerül-e. Állítsa a [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) értékét `True`-ra, ha a szöveget ligatúrák nélkül kell renderelni.

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

## **Szöveg és betűtípusok vezérlése**

### **Minden szöveg vektorizálása**

Állítsa a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgoptions/#setVectorizeText) értékét `True`-ra, hogy a diák teljes szövege vektorgrafikaként kerüljön kiírásra. Ez megszünteti a betűtípus-függőségeket, és a megjelenés vizuálisan egységesebb lesz a böngészők között, de a szöveg már nem lesz kijelölhető vagy kereshető SVG-szövegként.

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

### **Válassza ki, hogyan kezelje a külső betűtípusokat**

A [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgexternalfontshandling/) értéket használ a külsőleg betöltött betűtípusokhoz. Válassza a `AddLinksToFontFiles` lehetőséget, ha külön betűtípusfájlokra szeretne hivatkozni, a `Embed` opciót, ha a betűtípus adatokat az SVG-be ágyazza, vagy a `Vectorize` lehetőséget, ha csak a külső betűtípusokat használó szöveget szeretné grafikaként renderelni. Ellenőrizze a betűtípus licencelését, mielőtt beágyazná őket.

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

Használja a [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgoptions/#setPicturesCompression) metódust a beágyazott képek felbontásának csökkentéséhez, a [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) metódust a levágott forrásterületek elhagyásához, valamint a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgoptions/#setJpegQuality) metódust a JPEG kódolás minőségének szabályozásához. Ezek a beállítások a fájlméretet csökkentik, de a kép részletességét vagy a megőrzött képadatot érinthetik.

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

## **Stabil azonosítók hozzárendelése alakzatokhoz és szöveghez**

Használjon egy, a `jpype.JProxy`-n keresztül regisztrált Python formázó vezérlőt, hogy a [SvgShape.setId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgshape/#setId) értékeket alakzatokhoz, valamint a [SvgTSpan.setId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgtspan/#setId) értékeket a szöveg `tspan` elemeihez rendelje. A proxyt a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgoptions/#setShapeFormattingController) segítségével állítsa be.

Az alábbi vezérlő a [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getOfficeInteropShapeId) metódust használja, amely az alakzat élettartama alatt stabil, valamint egy ismételhető számlálót a szövegspánkokhoz. Ez a generált azonosítókat alkalmasá teszi egy változatlan prezentáció utófeldolgozásához.

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

Egy Python formázó vezérlőben hívja meg a [SvgShape.setEventHandler](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgshape/#setEventHandler) metódust egy [SvgEvent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgevent/) értékkel, hogy JavaScript eseménykezelőt adjunk egy exportált alakzathoz. Regisztrálja a vezérlőt a `jpype.JProxy` segítségével, és állítsa be a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgoptions/#setShapeFormattingController) metódussal. Definiálja a JavaScript függvényt az oldalban vagy az SVG-dokumentumban, amely a kimenetet tartalmazza.

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

A gazda oldal definiálhatja a kezelő által hivatkozott JavaScript függvényt. Az azonosítók és eseménykezelők hozzárendelése lehetővé teszi a dianézők, akadálymentesítési bővítmények és egyéb interaktív SVG munkafolyamatok használatát.

## **GYIK**

**Mikor kell a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgoptions/#setVectorizeText) metódust használni a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) helyett?**

Használja a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgoptions/#setVectorizeText) metódust, ha minden szövegnek függetlennek kell lennie a betűtípusoktól. Használja a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) metódust, ha csak a külső betűtípusokat használó szöveget kell grafikává konvertálni.

**Mi a leghatékonyabb módja egy SVG méretének csökkentésére?**

Kezdje a beágyazott képek tömörítésével, a levágott képterületek törlésével, és a hivatkozott betűtípusfájlok választásával, ha a célkörnyezet képes azokat kiszolgálni. Tesztelje az eredményt, mivel az alacsonyabb képfelbontás, alacsonyabb JPEG minőség és a vektorizált szöveg mind különböző minőség‑ és méret‑kompromisszumokkal jár.

**Módosíthatok exportált SVG elemeket az export után?**

Igen. Azonosítókat rendeljen egy formázó vezérlőn keresztül, majd válassza ki a megfelelő SVG elemeket az utófeldolgozó eszközében vagy böngésző‑szkriptjében.