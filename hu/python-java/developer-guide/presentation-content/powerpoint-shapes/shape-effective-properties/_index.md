---
title: "Alakzat hatékony tulajdonságainak lekérése a prezentációkból Pythonban Java-n keresztül"
linktitle: "Hatékony tulajdonságok"
type: docs
weight: 50
url: /hu/python-java/shape-effective-properties/
keywords:
- "alakzat tulajdonságok"
- "kamera tulajdonságok"
- "világítás"
- "ferde alakzat"
- "szövegkeret"
- "szövegstílus"
- "betűmagasság"
- "kitöltés formátum"
- "PowerPoint"
- "prezentáció"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Ismerje meg, hogyan használhatja az Aspose.Slides for Python via Java könyvtárat a helyi, örökölt és hatékony alakzatformázás megkülönböztetéséhez a PowerPoint prezentációkban."
---
## **A helyi, örökölt és hatékony tulajdonságok megértése**

A PowerPoint formázás több helyről származhat. Az objektumra közvetlenül tárolt érték az **helyi érték**. Ha ez az érték nincs beállítva, a PowerPoint a szülő formázási forrásokat vizsgálja, például a bekezdés alapértelmezett beállítását, egy szövegstílust, egy elrendezést vagy mesterdiát, egy témát vagy a prezentáció szintű alapértelmezéseket. Ezek az értékek **örökölt értékek**. Az az érték, amely a teljes hierarchia feloldása után megmarad, a **hatékony érték** – a objektum megjelenítéséhez használt érték.

Például egy szöveg részlet nem határozhatja meg saját betűmagasságát. A helyi [getFontHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#getFontHeight) értéke ilyenkor `float("nan")`, ami azt jelenti, hogy „itt nincs beállítva”. A részlet örökölhet magasságot a bekezdéséből, a prezentáció alapértelmezett szövegstílusából vagy egy másik alkalmazható forrásból. A [getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/#getEffective) hívása a részlet formátumán a végleges feloldott magasságot adja vissza.

Használja a kétféle formázási adatot különböző célokra:

- Olvassa vagy módosítsa a helyi formátumobjektumot, például a [PortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/) esetén, amikor szabályozni kell, hogy hol van definiálva egy érték.
- Olvasson egy hatékony adatobjektumot, például a `PortionFormatEffectiveData`-t, amikor a végső, megjelenített eredményre van szükség. A hatékony adatok csak olvashatók.

## **A helyi, örökölt és hatékony értékek összehasonlítása**

Az alábbi teljes példa egy alakzatot hoz létre, és betűmagasságokat alkalmaz a prezentáció, a bekezdés és a részlet szintjén. Minden lépés kiírja az adott szinteken definiált értékeket és a ugyanarra a szöveg részletre vonatkozó hatékony értéket. Emellett bemutatja, miért kell a hatékony adatot újra olvasni a formázási változtatások után.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpade.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # Olvassa be a hatékony adatot a korábbi módosítások után.
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # Határozza meg az örökölt értékeket két különböző szinten.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # A részlet helyi értéke felülírja mindkét örökölt értéket.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Az örökölt érték módosítása nem felülírja a meglévő helyi értéket.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Törölje a helyi értéket. A részlet most újra a bekezdésből örököl.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Törölje a bekezdés értékét. A prezentáció alapértelmezése most adja meg az eredményt.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az ebben a példában a prioritás a részlet helyi formázása, majd a bekezdés formázása, végül a prezentáció alapértelmezése. Más objektumok más öröklődési lánccal rendelkezhetnek, de az elv ugyanaz: egy specifikusabb, explicit érték nyer, és a [getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/#getEffective) a végleges eredményt adja vissza.

## **A hatékony szövegtulajdonságok lekérése**

A szöveg formázása több objektum között oszlik meg:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#getEffective) feloldja a szövegkeret tulajdonságait, például a margókat, a rögzítést, az automatikus méretezést és a függőleges szövegirányt.
- [TextStyle.getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textstyle/#getEffective) feloldja a bekezdés formázását minden szövegstílus szinten.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#getEffective) feloldja a bekezdés tulajdonságait, például a igazítást, a behúzást és a felsorolásjeleket.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/#getEffective) feloldja a karakter tulajdonságait, például a betűmagasságot, a betűtípust, a színt, a félkövér és dőlt stílust.

A következő példához a `text-formatting.pptx` fájlnak legalább egy diát és egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet kell tartalmaznia nem üres szövegkerettel. Az AutoShape megjelenhet a shape collection bármelyik pozíciójában; a kód keres egy megfelelő objektumot, és használat előtt ellenőrzi azt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **A hatékony 3D tulajdonságok lekérése**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getEffective) egy `ThreeDFormatEffectiveData` objektumot ad vissza, amely az összes feloldott 3D beállítást csoportosítja. A `getCamera`, `getLightRig`, `getBevelTop` és `getBevelBottom` metódusok a megfelelő hatékony adatot teszik láthatóvá. Ezeknek a kapcsolódó beállításoknak az együttes olvasása megkönnyíti a forma végső 3D megjelenésének megértését.

Ehhez a példához a `shape-3d.pptx` fájlnak legalább egy alakzatot kell tartalmaznia az első dián. Alkalmazzon 3D kamerát, megvilágítást vagy rézsút beállításokat az alakzatra, ha szeretné, hogy a kimenet az alapértelmezett értékeken kívül más értékeket is tartalmazzon.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **A hatékony táblázat formázás lekérése**

A táblázat formázása származhat a táblastílusból, valamint a teljes táblára, egy oszlopra, egy sorra vagy egyetlen cellára alkalmazott formátumokból. Az explicit módon definiált kitöltések közötti ütközések esetén a prioritás: cella, sor, oszlop, majd a teljes tábla. Egy cella hatékony formátuma a végső formátum, amelyet a cella megjelenítéséhez használnak.

Ehhez a példához a `table-formatting.pptx` fájlnak legalább egy táblázatot kell tartalmaznia az első dián. A táblázatnak legalább egy sorral és egy oszloppal kell rendelkeznie. A kód egy [Table](https://reference.aspose.com/slides/hu/python-java/aspose.slides/table/) elemet keres, ahelyett, hogy feltételezné, hogy a `getShapes().get_Item(0)` egy táblázat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

Ha a színre van szüksége a kitöltés típusa helyett, először ellenőrizze a hatékony `getFillType` értéket, majd olvassa be a típusnak megfelelő metódust – például a `getSolidFillColor`-t egy szilárd kitöltés esetén.

## **Hatékony adatok újraolvasása változtatások után**

A hatékony adatok a feloldás időpontjában leírják a formázási hierarchiát. Hívja meg újra a [getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/#getEffective) metódust, miután bármely, a hierarchiában részt vehető elemet módosított, többek között:

- az objektum helyi formázása;
- bekezdés vagy szövegkeret alapértelmezései;
- táblastílus, tábla, oszlop, sor vagy cella formátuma;
- elrendezés vagy mesterdia formázása;
- témaadatok vagy a prezentáció szintű alapértelmezések;
- a diára rendelt elrendezés vagy mester.

Ne tartson egy hatékony adatobjektumot állandó pillanatképként. Az Aspose.Slides bizonyos hatékony adatokat belsőleg cache-elhet, és egy későbbi [getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/#getEffective) hívás frissítheti az adatot. Ha össze kell hasonlítania az értékeket változtatás előtt és után, másolja a szükséges skalár értékeket – például betűmagasság, szín, igazítás vagy rézsút szélesség – saját változóiba, mielőtt a módosítást elvégzi.

Egy érték módosításához frissítse a megfelelő helyi formátumobjektumot, majd hívja meg a [getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/#getEffective) metódust az eredmény ellenőrzéséhez. A hatékony adatobjektumok maguk is csak olvashatók.

## **FAQ**

**Hogyan tudom megállapítani, melyik szint biztosította a hatékony értéket?**

A hatékony adatok csak a végső értéket tartalmazzák, nem a forrást. Vizsgálja meg a releváns helyi objektumokat a legspecifikusabb szintről kifelé. Szöveg esetén ez magában foglalhatja a részt, bekezdést, szövegkeretet, elrendezést, mestert, témát és a prezentáció alapértelmezéseit. A `float("nan")` vagy `None` értékek azt jelzik, hogy a keresés tovább folytatódik egy magasabb szinten.

**Mi történik, ha egy szinten sem definiálódik egy tulajdonság?**

Az Aspose.Slides a megfelelő PowerPoint vagy könyvtári alapértelmezést alkalmazza. Ez a feloldott érték megjelenik a hatékony adatokban, még akkor is, ha egy helyi objektum nem definiálta explicit módon.

**Miért egyezik néha a hatékony érték a helyi értékkel?**

A helyi érték nyerte meg az öröklődési számítást. Ez akkor fordul elő, ha a tulajdonság explicit módon be van állítva az objektumon, és nincs specifikusabb szabály, amely felülírná.

**Mikor kell helyi adatot használni a hatékony adat helyett?**

Használjon helyi adatot egy adott formázási szint megtekintéséhez vagy szerkesztéséhez. Használjon hatékony adatot, ha a végső megjelenésre van szüksége az öröklődés, a téma szabályai és az alkalmazott stílusok feloldása után. A **[teljes összehasonlítási példa](#compare-local-inherited-and-effective-values)** mindkettőt bemutatja egyetlen munkafolyamatban.