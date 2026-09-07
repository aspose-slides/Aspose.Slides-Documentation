---
title: PowerPoint bemutatók konvertálása HTML-re Pythonon keresztül Java-val
linktitle: PowerPoint HTML-re
type: docs
weight: 30
url: /hu/python-java/convert-powerpoint-to-html/
keywords:
- PowerPoint konvertálása
- bemutató konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint HTML-re
- bemutató HTML-re
- dia HTML-re
- PPT HTML-re
- PPTX HTML-re
- PowerPoint mentése HTML-ként
- bemutató mentése HTML-ként
- dia mentése HTML-ként
- PPT mentése HTML-ként
- PPTX mentése HTML-ként
- PPT exportálása HTML-re
- PPTX exportálása HTML-re
- Python
- Java
- Aspose.Slides
description: "PowerPoint bemutatók konvertálása HTML-re Pythonon keresztül Java-val. Használja az Aspose.Slides-t PPT és PPTX fájlok, kiválasztott diák, jegyzetek, betűtípusok, képek, SVG és média exportálásához."
---
## **Áttekintés**

Aspose.Slides for Python via Java képes PowerPoint bemutatókat HTML formátumban menteni a Microsoft PowerPoint nélkül. Az alapvető konverzió egyetlen [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) betöltésből és egy [save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) hívásból áll a [SaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/) használatával. Használja a [HtmlOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/) lehetőséget, ha szabályozni szeretné az exportált elrendezést, betűtípusokat, képeket, jegyzeteket, kommentárokat, SVG kimenetet vagy a hivatkozott erőforrásokat.

Ez az útmutató a gyakorlati HTML export szcenáriókra összpontosít:

- Exportáljon egy teljes bemutatót vagy kiválasztott diákat.
- Generáljon rögzített elrendezésű, reszponzív vagy SVG-alapú HTML-t.
- Vegye fel a jegyzetelő beszélői megjegyzéseket és kommentárokat.
- Szabályozza a képminőséget és a levágott képadatokat.
- Ágyazzon be betűtípusokat vagy mentse a betűtípus fájlokat külön.
- Válassza ki, hogyan íródnak és hivatkoznak a külső erőforrásokra és médiafájlokra.

Alapértelmezés szerint a HTML export egy önálló HTML dokumentumot hoz létre, ahol a legtöbb erőforrás be van ágyazva. Ez kényelmes egy fájl megosztásához, de növelheti a kimeneti méretet. Webes közzététel esetén fontolja meg a külső erőforrásokat, az alacsonyabb kép DPI értéket, és csak azokat a betűtípusokat ágyazza be, amelyek nem állnak megbízhatóan rendelkezésre a célkörnyezetben.

## **Bemutató konvertálása HTML-re**

A bemutató HTML-re exportálásához töltse be a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) segítségével, és mentse a [SaveFormat.Html](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Html) használatával.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Minden példa a `presentation.pptx` fájlt tölti be a jelenlegi munkakönyvtárból. Telepítse az Aspose.Slides for Python via Java-t és egy kompatibilis Java futtatókörnyezetet a futtatás előtt. A JVM egyszer indul minden Python folyamatnál.

Ez a példa egy HTML fájlt ír. A bemutató objektumot a `finally` blokkban rendeli le, amely a fájlkezelőket és a renderelési erőforrásokat szabadítja fel az exportálás után.

## **HTML export beállítása**

[HtmlOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/) a fő konfigurációs osztály a HTML exporthoz. A gyakori beállítások a következők:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): hozzáadja a jegyzeteket, kommentárokat, anyagokat vagy más elrendezési információkat.
- [setHtmlFormatter](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/#setHtmlFormatter): módosítja a HTML dokumentum szerkezetét vagy a formázást egy vezérlőnek delegálja.
- [setSlideImageFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/#setSlideImageFormat): megváltoztatja, hogyan jelennek meg a diák, például SVGként.
- [setPicturesCompression](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/#setPicturesCompression): szabályozza a kép DPI-t és a kimeneti méretet.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): megtartja vagy eltávolítja a levágott kép adatokat.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): a exportált SVG tartalmat a tárolóhoz igazítja.
- [setShowHiddenSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): szükség esetén belefoglalja a rejtett diákat.

Az alábbi szekciók külön mutatják be a leggyakoribb beállításokat, hogy csak azokat kombinálhassa, amelyekre a munkafolyamata szüksége van.

## **Kiválasztott diák konvertálása HTML-re**

A [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) túlterhelés, amely diaszámokat fogad, 1-alapú diapozíciókat használ. Az alábbi ciklus minden diát külön HTML fájlba ment.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

Használja ezt a mintát, amikor egy weboldal vagy alkalmazás minden diához egy HTML oldalt igényel. Ha minden diának azonos elrendezésűnek kell lennie, hozzon létre egy [HtmlOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/) példányt, és adja át minden [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) hívásnak.

## **Reszponzív HTML létrehozása**

[ResponsiveHtmlController](https://reference.aspose.com/slides/hu/python-java/aspose.slides/responsivehtmlcontroller/) reszponzív HTML kimenetet biztosít a [HtmlFormatter](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmlformatter/) segítségével. Használja, ha az exportált oldalnak jobban kell alkalmazkodnia a böngésző szélességéhez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

SVG-alapú reszponzív elrendezéshez hívja meg a [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) metódust `True` értékkel. Ez akkor hasznos, ha a diak tartalma skálázható SVG jelölőnyelvként kerül exportálásra.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Beszélői jegyzetek és kommentárok belefoglalása**

Használja a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/) lehetőséget a [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) révén, hogy beszélői jegyzeteket vagy kommentárokat vegyen fel. A jegyzetek és kommentárok alapértelmezés szerint rejtve vannak, hacsak nem választja ki a pozíciójukat.

Tegyük fel, hogy a forrás bemutató tartalmaz beszélői jegyzeteket:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Az alábbi kód a diá tartalmat a beszélői jegyzetekkel a dia alatt exportálja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

![HTML output with the slide and speaker notes](HTML_with_notes.png)

A kommentárok exportálásához hívja meg a [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) metódust, például a [CommentsPositions.Right](https://reference.aspose.com/slides/hu/python-java/aspose.slides/commentspositions/#Right) vagy [CommentsPositions.Bottom](https://reference.aspose.com/slides/hu/python-java/aspose.slides/commentspositions/#Bottom) értékkel. Ha csak kommentárokra van szüksége, hagyja ki a [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) hívást. Ha mind jegyzetekre, mind kommentárokra szüksége van, hívja meg mindkét metódust.

## **Képminőség és levágott területek szabályozása**

A HTML export képes tömöríteni a diaképeket a kimeneti méret csökkentése érdekében. Adjon át egy értéket a [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/#setPicturesCompression) metódusnak a [PicturesCompression](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturescompression/) osztályból, ha magasabb képminőségre van szükség.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Alapértelmezés szerint a képek levágott területei eltávolíthatók az exportált kimenetből. Tartsa meg a levágott adatokat csak akkor, ha a felhasználóknak vissza kell tudni szerezni vagy meg kell vizsgálni a rejtett képrészeket. Ennek megtartása növelheti a HTML méretét.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **CSS hozzáadása**

Egyszerű stílusozáshoz adjon át egy CSS karakterláncot a [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmlformatter/#createDocumentFormatter) metódusnak. Ez megváltoztatja a környező HTML dokumentumot, miközben az Aspose.Slides továbbra is rendereli a diák tartalmát.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Egy egyedi dokumentumfejléc, egy csatolt CSS fájl vagy egyéni jelölőnyelv a diák és alakzatok körül esetén használjon egy egyedi formázási vezérlőt a JPype interfész proxy-n keresztül, és adja át a [HtmlFormatter](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmlformatter/) számára a [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmlformatter/#createCustomFormatter) metódussal.

## **Betűtípusok beágyazása**

Ha a célkörnyezetben nincs telepítve a bemutató betűtípusa, ágyazza be a betűtípusokat a HTML-be a [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hu/python-java/aspose.slides/embedallfontshtmlcontroller/) segítségével. A beágyazás javítja a vizuális hűséget, de növeli a kimeneti méretet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Csak akkor zárja ki a betűtípusokat, ha biztos abban, hogy a célböngészők vagy rendszerek már rendelkeznek velük. Márkabetűtípusok vagy ritkábban használt betűtípusok esetén a beágyazás általában biztonságosabb.

## **Erőforrások külső mentése**

Az önálló HTML könnyen mozog, de a beágyazott Base64 erőforrások nagy fájlt eredményezhetnek. Ha alkalmazásának külső képfájlokra van szüksége, valósítson meg egy erőforrás-kapcsoló vezérlőt a JPype interfész proxy-n keresztül, és adja át a [HtmlOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/) konstruktorának.

Erőforrások külsővé tételekor gondosan válasszon két útvonalat:

- A fájlrendszer kimeneti útvonal, ahol az alkalmazás generált képeket, betűtípusokat, hangot vagy videót ír.
- Az URL útvonal, amit a böngésző a HTML dokumentumból használ az ezek a fájlok betöltéséhez.

## **Médiafájlok exportálása**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoplayerhtmlcontroller/) videó- és hangfájlokat exportál, és HTML-t ír, amely képes lejátszani őket a böngészőben. A konstruktor a következőket veszi:

- `path`: a könyvtár, ahová a generált médiafájlok írásra kerülnek.
- `fileName`: a generált HTML fájl neve.
- `baseUri`: a médiafájlokra mutató HTML linkekben használt abszolút URI előtag.

Az alábbi példa exportálja a már `presentation.pptx`-ben beágyazott médiát. A generált HTML csak a fájlnév alapján hivatkozik a médiafájlokra, a HTML dokumentumhoz relatívan, ezért a `path`-nak azt a könyvtárat kell megadnia, amelyik a HTML fájlt is megkapja. A `baseUri`-nak abszolút URI-nak kell lennie: helyi előnézethez építsen egy `file:///` URI-t a kimeneti könyvtárból; egy telepített alkalmazáshoz használja a közzétett könyvtár abszolút URL-jét.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Használjon kimeneti könyvtárakat, amelyek minden exportfeladatra egyediek, különösen szerveralkalmazásokban. A megosztott kimeneti útvonalak miatt a különböző konverziók fájljai felülírhatják egymást.

## **Teljesítmény és erőforrás-kezelés**

A HTML konverzió egy renderelési művelet, így a feldolgozási idő és a memóriahasználat a diák száma, a kép felbontása, a betűtípusok, effektusok, diagramok és a beágyazott média függvénye. A [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/#setPicturesCompression) számára átadott magasabb kép DPI értékek, beágyazott betűtípusok, SVG kimenet és a megtartott levágott kép területek javíthatják a hűséget, de általában növelik a kimeneti méretet.

Kötegelt konverzió esetén:

- Szabadítsa fel minden [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt haladéktalanul.
- Használjon külön kimeneti könyvtárakat a külön feladatokhoz.
- Kerülje a gyakori betűtípusok beágyazását, kivéve ha a hűség megköveteli.
- Csökkentse a kép DPI-t, ha a HTML előnézet vagy miniatűr céljára szolgál.
- Tartsa a forrás bemutatót, a generált HTML-t és a külső erőforrásokat együttesen, amíg a telepítési útvonalak véglegesek.

## **FAQ**

**Megmaradnak a hiperhivatkozások a HTML kimenetben?**

Igen. A bemutató hiperhivatkozásai exportálásra kerülnek a HTML-be, és kattinthatóak maradnak, ha a cél URL érvényes.

**Konvertálhatok bemutatókat HTML-re párhuzamosan?**

Igen, de ne osszon meg egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt szálak között. Különálló fájlokat dolgozzon fel külön bemutató példányokkal, külön adatfolyamokkal és külön kimeneti könyvtárakkal. A részletekért lásd a [multithreading guidance](/slides/hu/python-java/multithreading/) útmutatót.

**A bemutató objektum szálbiztos?**

Nem. Egyetlen [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt egy szálon kell betölteni, módosítani, menteni és feloldani. Párhuzamos munkához hozzon létre egy független példányt szálanként vagy folyamatanként.

**Miért nagy a generált HTML fájl?**

Az alapértelmezett export beágyazhat erőforrásokat közvetlenül a HTML-be. A beágyazott betűtípusok, magas DPI-s képek, média, SVG tartalom és a megtartott levágott kép területek is növelik a méretet. Használjon külső erőforrásokat, zárja ki a gyakori betűtípusok beágyazását, és adjon át alacsonyabb DPI értéket a [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/#setPicturesCompression) metódusnak, ha a kisebb kimenet fontosabb a maximális hűségnél.

**Miért eltérhetnek a HTML-ben szereplő betűméretek a PowerPoint értékaktól?**

Az exportált oldal használhat SVG koordináta rendszereket és méretezési transzformációkat. Egy nyers CSS vagy SVG betűméret érték önmagában nem írja le a végleges megjelenített méretet. Hasonlítsa össze a renderelt diát a kívánt nagyítási szinten, és ellenőrizze a betűtípus elérhetőségét, ha a szöveg másnak tűnik.

**Hogyan válasszam a baseUri értéket a média exportáláshoz?**

Válassza a `baseUri` értéket a böngésző nézőpontjából, és adja át abszolút URI-ként. Helyi előnézethez származtathatja a kimeneti könyvtárból a `output_directory.as_uri() + "/"` kifejezéssel. Telepítéskor használja a közzétett könyvtár abszolút URL-jét. A fájlrendszer `path` és a böngésző `baseUri` nem kell, hogy ugyanaz a karakterlánc legyen, de ugyanazt a helyet kell leírniuk, és ennek a helynek a generált HTML fájlt tartalmazó könyvtárnak kell lennie, mivel a média hivatkozások ehhez viszonyítva kerülnek írásra.

**Be tudok-e vonni rejtett diákat?**

Igen. Hívja meg a [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) metódust `True` értékkel, ha a rejtett diákat exportálni kell.