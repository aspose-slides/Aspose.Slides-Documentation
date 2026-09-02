---
title: Alakzat tényleges tulajdonságainak lekérése Pythonban a prezentációkból
linktitle: Hatékony tulajdonságok
type: docs
weight: 50
url: /hu/python-net/shape-effective-properties/
keywords:
- alakzat tulajdonságai
- kamera tulajdonságok
- világítási rig
- ferde alakzat
- szövegkeret
- szövegstílus
- betűmagasság
- kitöltési formátum
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan használhatja az Aspose.Slides for Python .NET segítségével a helyi, örökölt és tényleges alakzatformázást a PowerPoint prezentációkban."
---
## **Értse meg a helyi, örökölt és tényleges tulajdonságokat**

A PowerPoint formázás több helyről származhat. Az objektumon közvetlenül tárolt érték a **helyi érték**. Ha ez az érték nincs beállítva, a PowerPoint a szülő formázási forrásokat vizsgálja, például a bekezdés alapértelmezését, egy szövegstílust, egy elrendezést vagy mesterdiát, egy témát vagy az előadás szintű alapértelmezéseket. Ezek az értékek **örökölt értékek**. Az az érték, amely a teljes hierarchia feloldása után megmarad, a **tényleges érték**, amelyet az objektum megjelenítéséhez használnak.

Például egy szövegrészlet nem határozhatja meg saját betűmagasságát. A helyi [font_height](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ibaseportionformat/font_height/) értéke ekkor `float("nan")`, ami azt jelenti, hogy "itt nincs beállítva". A részlet örökölhet magasságot a bekezdéséből, az előadás alapértelmezett szövegstílusából vagy egy másik alkalmazható forrásból. A [get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iportionformat/get_effective/) hívása a részletformázáson a végleges feloldott magasságot adja vissza.

Használja a kétféle formázási adatot különböző célokra:

- Olvassa vagy módosítsa a helyi formátumobjektumot, például a [IPortionFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iportionformat/), ha kontrollálni szeretné, hogy hol van meghatározva az érték.
- Olvassa a tényleges adatobjektumot, például az [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iportionformateffectivedata/), ha a végleges, megjelenített eredményre van szüksége. A tényleges adatok csak olvashatóak.

## **Helyi, örökölt és tényleges értékek összehasonlítása**

Az alábbi teljes példa létrehoz egy alakzatot, és a prezentáció, a bekezdés és a részlet szintjén alkalmaz betűmagasságokat. Minden lépés kiírja az azokon a szinteken meghatározott értékeket, valamint az ugyanarra a szövegrészletre vonatkozó eredményül kapott tényleges értéket. Emellett bemutatja, miért kell a formázás módosítása után újra beolvasni a tényleges adatokat.

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # Olvasd be a tényleges adatot a korábbi módosítások után.
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # Határozz meg örökölt értékeket két különböző szinten.
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # A részlet helyi értéke felülírja mindkét örökölt értéket.
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Az örökölt érték módosítása nem felülírja a már meglévő helyi értéket.
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Töröld a helyi értéket. A részlet most újra a bekezdésből örököl.
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Töröld a bekezdés értékét. A prezentáció alapértelmezése most adja az eredményt.
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

Az ebben a példában a prioritás a részlet helyi formázása, majd a bekezdés formázása, végül a prezentáció alapértelmezése. Más objektumoknak eltérő öröklődési láncaik lehetnek, de az elv ugyanaz: egy specifikusabb, kifejezett érték nyer, és a [get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iportionformat/get_effective/) visszaadja a végső eredményt.

## **Tényleges szövegtulajdonságok lekérdezése**

A szöveg formázása több objektum között van elosztva:

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/hu/python-net/aspose.slides/itextframeformat/get_effective/) megoldja a szövegkeret tulajdonságait, mint a margók, rögzítés, automatikus méretezés és a függőleges szövegirány.
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/hu/python-net/aspose.slides/itextstyle/get_effective/) megoldja a bekezdés formázását minden szövegstílus szinthez.
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iparagraphformat/get_effective/) megoldja a bekezdés tulajdonságait, mint az igazítás, behúzás és felsorolásjel.
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iportionformat/get_effective/) megoldja a karakter tulajdonságait, mint a betűmagasság, betűtípus, szín, félkövér és dőlt.

A következő példához a `text-formatting.pptx` fájlnak legalább egy diát és egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) nem üres szövegkerettel kell tartalmaznia. Az AutoShape a alakzatelőállítás bármely pozíciójában megjelenhet; a kód megfelelő objektumot keres, és használat előtt ellenőrzi azt.

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **Tényleges 3D tulajdonságok lekérdezése**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ithreedformat/get_effective/) egy [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ithreedformateffectivedata/) objektumot ad vissza, amely összegyűjti az összes feloldott 3D beállítást. A [camera](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ithreedformateffectivedata/camera/), [light_rig](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ithreedformateffectivedata/light_rig/), [bevel_top](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/) és [bevel_bottom](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) tulajdonságok a megfelelő tényleges adatokat exponálják. Ezeknek a kapcsolódó beállításoknak a közös olvasása megkönnyíti egy alakzat végső 3D megjelenésének megértését.

Ehhez a példához a `shape-3d.pptx` fájlnak az első diáján legalább egy alakzatot kell tartalmaznia. Alkalmazzon 3D kamerát, világítást vagy ív beállításokat az alakzatra, ha azt szeretné, hogy a kimenet az alapértelmezett értékeken kívül más értékeket tartalmazzon.

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **Tényleges táblázat formázás lekérdezése**

A táblázat formázása származhat a táblázat stílusából, valamint a teljes táblázatra, egy oszlopra, egy sorra vagy egy egyedi cellára alkalmazott formátumokból. Az explicit módon meghatározott kitöltések közötti ütközések esetén a prioritás a cella, sor, oszlop, majd a teljes táblázat. Egy cella tényleges formátuma a végső formátum, amely a cella rajzolásához használatos.

Ehhez a példához a `table-formatting.pptx` fájlnak az első diáján legalább egy táblázatot kell tartalmaznia. A táblázatnak legalább egy sort és egy oszlopot kell tartalmaznia. A kód egy [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/) objektumot keres, ahelyett, hogy feltételezné, hogy a `shapes[0]` egy táblázat.

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

Ha a színre van szüksége a kitöltés típusának helyett, először ellenőrizze a tényleges [fill_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ifillformateffectivedata/fill_type/), majd olvassa el a típusra vonatkozó tulajdonságot, például a [solid_fill_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) egy szilárd kitöltés esetén.

## **Tényleges adatok újraolvasása módosítások után**

A tényleges adatok leírják a formázási hierarchiát a feloldás időpontjában. Hívja meg újra a `get_effective` metódust, miután megváltozott bármi, ami részt vehet ebben a hierarchiában, többek között:

- az objektum helyi formázása;
- bekezdés vagy szövegkeret alapértelmezései;
- egy táblázat stílus, táblázat, oszlop, sor vagy cella formátuma;
- elrendezés vagy mesterdia formázása;
- téma adatok vagy prezentáció szintű alapértelmezések;
- a diára hozzárendelt elrendezés vagy mester.

Ne tartson egy tényleges adatobjektumot állandó pillanatképnek. Az Aspose.Slides tárolhat néhány tényleges adatot a memóriában, és egy későbbi `get_effective` hívás frissítheti ezeket az adatokat. Ha a módosítás előtti és utáni értékeket szeretné összehasonlítani, másolja a szükséges skaláris értékeket, például betűmagasságot, színt, igazítást vagy ívhézagot, saját változóiba a módosítás előtt.

Érték módosításához frissítse a megfelelő helyi formátumobjektumot, majd hívja meg a `get_effective` metódust az eredmény ellenőrzéséhez. A tényleges adatobjektumok maguk csak olvashatóak.

## **GYIK**

**Hogyan tudom megállapítani, melyik szint adott egy tényleges értéket?**

A tényleges adatok csak a végső értéket tartalmazzák, nem annak forrását. Vizsgálja meg a vonatkozó helyi objektumokat a legspecifikusabb szintről kifelé. Szöveg esetén ez magában foglalhatja a részletet, a bekezdést, a szövegkeretet, az elrendezést, a mestert, a témát és a prezentáció alapértelmezéseit. A `float("nan")` vagy `None` értékek azt jelzik, hogy a keresés egy másik szintre folytatódik.

**Mi történik, ha egyik szint sem határoz meg egy tulajdonságot?**

Az Aspose.Slides a megfelelő PowerPoint vagy könyvtár alapértelmezést oldja fel. Ez a feloldott érték megjelenik a tényleges adatokban, még akkor is, ha egy helyi objektum sem definiálja kifejezetten.

**Miért egyezik néha a tényleges érték a helyi értékkel?**

A helyi érték nyerte az öröklődési számítást. Ez akkor várható, amikor a tulajdonság kifejezetten be van állítva az objektumon, és nincs specifikusabb szabály, amely felülírná.

**Mikor használjak helyi adatot a tényleges adat helyett?**

Használja a helyi adatot egy adott formázási szint ellenőrzéséhez vagy szerkesztéséhez. Használjon tényleges adatot, ha a végső megjelenésre van szüksége az öröklődés, a témarendszerek és a vonatkozó stílusok feloldása után. A [teljes összehasonlító példa](#compare-local-inherited-and-effective-values) mindkettőt bemutatja egy munkafolyamatban.