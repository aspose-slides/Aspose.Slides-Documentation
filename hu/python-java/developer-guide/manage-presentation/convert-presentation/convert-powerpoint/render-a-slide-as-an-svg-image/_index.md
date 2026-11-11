---
title: Dia bemutatók renderelése SVG képekként Pythonon keresztül Java használatával
linktitle: Diát SVG-re
type: docs
weight: 50
url: /hu/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint SVG-re
- bemutató SVG-re
- dia SVG-re
- PPT SVG-re
- PPTX SVG-re
- SVG exportálási beállítások
- interaktív SVG
- PowerPoint
- bemutató
- Python
- Java
- Aspose.Slides
description: "Exportálja a PowerPoint diákat SVG képekként Pythonban Java használatával, és irányítsa a betűtípusokat, szöveget, képeket, azonosítókat és eseményeket az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy skálázható XML-alapú képformátum, amely jól működik webes közzétételhez, diavetítőkhez, hozzáférhetőségi munkafolyamatokhoz és automatizált utófeldolgozáshoz. Az Aspose.Slides minden diát külön SVG‑fájlba exportál, és lehetővé teszi, hogy szabályozza, hogyan íródnak a szövegek, betűtípusok, képek és SVG‑elemek.

Használja a [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) akkor, ha az exportált SVG‑nek kompaktnak, böngészőközi előre láthatónak vagy interaktív felhasználásra késznek kell lennie.

## **Dia exportálása SVG‑ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), válasszon ki egy diát, és írja ki egy adatfolyamba a [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). A példák egy meglévő `presentation.pptx` fájlt igényelnek. Minden példa szükség esetén elindítja a JVM‑et, és bezárja a kimeneti adatfolyamokat. Az alábbi példa a bemutató minden diáját külön SVG‑fájlba exportálja.

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

A fájlnevet a [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) alapján használja, nem pedig a ciklus indexe szerint. Egyéni alakzatot is exportálhat a [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) segítségével, ha egy diavetítő vagy weboldal csak azt az alakzatot igényli.

## **SVG kimenet konfigurálása**

[A SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) szabályozza az SVG renderelését. Szövegdobozok esetén a [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) a szövegdobozt is beleveszi a renderelési területbe, a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) pedig meghatározza, hogy a doboz forgatása alkalmazásra kerüljön‑e. Állítsa a [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) értékét `True`‑ra, ha a szöveget ligatúrák nélkül kell renderelni.

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

Diák SVG‑be exportálásakor szabályozhatja, hogy a szöveg megtartja‑e a szövegformátumot vagy vektorgrafikává alakul, valamint hogy a külső betűtípusok hogyan legyenek bevonva vagy hivatkozva. A következő beállítások segítenek egyensúlyba hozni a vizuális konzisztenciát, a szöveg kijelölhetőségét és a betűtípus‑függőségeket az exportált SVG‑ben.

### **Minden szöveg vektorizálása**

Állítsa a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) értékét `True`‑ra, hogy az összes diateszxtet vektorgrafikaként írja ki. Ez megszünteti a betűtípus‑függőségeket, és a vizuális eredményt egységesebbé teszi a böngészők között, de a szöveg már nem lesz kijelölhető vagy kereshető SVG‑szövegként.

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

A [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) értéket használ a külsőleg betöltött betűtípusokhoz. Válassza az `AddLinksToFontFiles` lehetőséget, ha különálló betűtípus‑fájlokra szeretne hivatkozni, az `Embed`‑et, ha a betűtípus‑adatokat az SVG‑be beágyazza, vagy a `Vectorize`‑t, ha csak a külső betűtípusokat használó szöveget vektorgrafikaként rendereli. Ellenőrizze a betűtípus‑licencet a beágyazás előtt.

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

Használja a [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression)‑t a beágyazott képek felbontásának csökkentéséhez, a [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas)‑t a levágott forrásterületek kihagyásához, valamint a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality)‑t a JPEG kódolás minőségének szabályozásához. Ezek a beállítások a fájlméretet csökkentik a kép pontosságának vagy a megtartott képadatok költségén.

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

## **Metafájl raszterizálási felbontásának szabályozása**

A [SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) alacsonyabb felbontási határt állít be a metafájlok SVG‑export során történő raszterizálásához. Használja a részletek és a fájlméret egyensúlyozásához, amikor egy EMF vagy WMF kép raszterizálva van. Nem definiál globális DPI‑t az SVG‑hez, és nem kényszeríti minden dián lévő objektumot raszteres képpé.

Töltse le a [metafile-rasterization.pptx](metafile-rasterization.pptx) fájlt, amely egy EMF képet tartalmaz szorosan elhelyezkedő átlós vonalakkal. Az alábbi példa az első diát három raszterizálási felbontásban exportálja a [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) segítségével. A többi exportbeállítás változatlan marad, hogy az eredmények összehasonlíthatók legyenek.

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

A kimenetben az EMF minden SVG‑ben egy beágyazott PNG‑vé változott. A következő mérőszámok a mellékelt bemutatóra vonatkoznak; nem általános képlet a DPI pixelméretekre történő átváltásához.

| Metafájl raszterizálási DPI | Beágyazott PNG méretek | SVG fájlméret (bájt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Az alábbi összehasonlítás ugyanazt a beágyazott rasztert mutatja azonos nagyított megjelenítési mérettel. A 72 DPI‑nél látható pixelesedés a átlós vonalaknál, míg a magasabb felbontásnál simább élűek, eközben az SVG‑fájl növekszik. Az érték növelése nem feltétlenül javít minden részletet vagy módosít minden exportált képet.

![Nagyított átlós vonal részletek 72, 150 és 300 DPI](metafile-rasterization-comparison.png)

A [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) szabályozza a képfelbontás csökkentését, és elrejtheti a metafájl raszterizálási felbontás változtatásának hatását. A [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) a JPEG kódolás minőségét szabályozza, nem a metafájl raszterizálási felbontását.

## **Stabil azonosítók hozzárendelése alakzatokhoz és szöveghez**

Használjon egy `jpype.JProxy`‑n keresztül regisztrált Python formázóvezérlőt, hogy a [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) értékeket alakzatokhoz, a [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) értékeket pedig a szöveg `tspan` elemeihez rendelje. A proxyt a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController)‑val rendeli hozzá.

A következő vezérlő a [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId)‑t használja, amely az alakzat élettartama alatt stabil, valamint egy ismételhető számlálót a szövegtartományokhoz. Ez a generált azonosítókat alkalmasá teszi egy módosítatlan bemutató utófeldolgozásához.

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

Egy Python formázóvezérlőben hívja meg a [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler)‑t egy [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) értékkel, hogy JavaScript eseménykezelőt adjon az exportált alakzathoz. Regisztrálja a vezérlőt a `jpype.JProxy`‑val, és rendelje hozzá a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController)‑val. Definiálja a JavaScript függvényt az oldalon vagy az SVG‑dokumentumban, amely a kimenetet tartalmazza.

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

A fogadó oldal definiálhatja a kezelő által hivatkozott JavaScript függvényt. Azonosítók és eseménykezelők hozzárendelése lehetővé teszi a diavetítők, a hozzáférhetőségi fejlesztések és egyéb interaktív SVG‑munkafolyamatok használatát.

## **GYIK**

**Mikor kell a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText)‑t használni a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) helyett?**

Használja a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText)‑t, ha minden szöveget függetleníteni kell a betűtípusoktól. Használja a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)‑t, ha csak a külső betűtípusokat használó szöveget kell grafikává konvertálni.

**Mi a legjobb módja egy SVG méretének csökkentésére?**

Kezdje a beágyazott képek tömörítésével, a levágott képrészletek törlésével, valamint a hivatkozott betűtípus‑fájlok kiválasztásával, ha a célkörnyezet képes azokat szolgáltatni. Tesztelje az eredményt, mivel az alacsonyabb képfelbontás, az alacsonyabb JPEG‑minőség és a vektorizált szöveg mind különböző minőség‑ és méret‑kompromisszumokat jelent.

**Módosíthatom-e az exportált SVG elemeket az export után?**

Igen. Rendeljen azonosítókat egy formázóvezérlő segítségével, majd válassza ki a megfelelő SVG elemeket az utófeldolgozó eszközében vagy böngésző‑szkriptjében.