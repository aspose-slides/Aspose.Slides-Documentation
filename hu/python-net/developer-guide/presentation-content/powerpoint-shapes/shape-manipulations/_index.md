---
title: Prezentációs alakzatok kezelése Pythonban
linktitle: Alakzatmanipuláció
type: docs
weight: 40
url: /hu/python-net/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentációs alakzat
- alakzat a dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat ID lekérése
- alakzat alternatív szövege
- alakzat korrekciós pontja
- előre definiált alakzat korrekció
- alakzat geometriája
- alakzat elrendezés formátumok
- alakzat SVG-ként
- alakzat SVG-be
- alakzat igazítása
- alakzat tükrözése
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan azonosíthatja, módosíthatja, klónozhatja, eltávolíthatja, elrejtheti, újrarendezheti, exportálhatja, igazíthatja és tükrözheti a prezentációs alakzatokat az Aspose.Slides for Python via .NET segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET a dia alakjait egy rendezett [ShapeCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/)‑ként ábrázolja. A gyűjtemény egyben az a hely, ahol alakzatokat találunk és módosítunk, valamint a rétegezési sorrend forrása: a `0`‑s index a leghátrább alakzat, míg az utolsó index a legelülső alakzat.

Ez a cikk ezt a modellt követi. Először bemutatja, hogyan azonosítsunk megbízhatóan egy alakzatot és módosítsuk az előre beállított alakzat‑korrekciós pontokat, majd megmutatja a klónozást, eltávolítást, elrejtést és az újrarendezést. Az utolsó szakaszok a layout‑szintű formázást, az SVG‑exportáltást, az igazítást és a tükrözési beállításokat fedik le. Minden példa önálló, így csak a saját munkafolyamatához szükséges műveleteket használhatja.

## **Alakzatok azonosítása és keresése**

A gyűjtemény indexei kényelmesek egy ismert fájl feldolgozásakor, de nem stabil azonosítók. Egy alakzat hozzáadása, eltávolítása vagy átrendezése megváltoztathatja a indexét. Válasszon azonosítót a prezentáció elkészítésének és karbantartásának módja szerint:

- [Shape.name](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/name/) hasznos fejlesztő‑vezérelt sablonoknál, és könnyen megtekinthető a PowerPoint Kiválasztási paneljén. A neveket szerkeszthető, és nem garantált a egyediség, ezért alakítsunk ki névadási konvenciót, ha a kód rájuk támaszkodik.
- [Shape.alternative_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/alternative_text/) akkor hasznos, ha egy akadálymentesítési leírás vagy a szerző által megadott címke már azonosítja az alakzatot. A felhasználók számára látható, lokalizálható vagy átírható a hozzáférhetőség érdekében, és szintén nem garantált az egyediség. Ne használjunk csendben jelentős akadálymentesítési szöveget adatbáziskulcsként.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/office_interop_shape_id/) egy csak‑olvasású azonosító, amely a dián belül egyedi, és a PowerPoint interop által használt alakzat‑azonosítóval egyezik. Használja, ha PowerPointhoz integrál, vagy ha egy alakzat élettartama alatt egyértelmű hivatkozásra van szükség. Egy klónozott vagy újból létrehozott alakzat másik alakzat, és saját ID‑t kap.

A kapcsolódó [Shape.unique_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/unique_id/) tulajdonság prezentáció‑szintű, de kiegészítők számára készült, és újra hozzárendelhető. Nem tekinthető állandó külső kulcsnak. Ha hosszú távú azonosítás szükséges, tartsa a leképezést alkalmazás‑adatokban, és ellenőrizze, hogy a várt alakzat még létezik‑e.

Az alábbi példa a `name`‑et pontos összehasonlítással keresi, és a diához kötött interop ID‑t jelenti. Ha a sablon nem tartalmazza a várt alakzatot, a kód azt az eredményt jelzi ahelyett, hogy a rossz objektummal folytatná.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

Amikor egy művelet alakzat‑típus‑specifikus, ellenőrizze a típust, mielőtt típus‑specifikus tagokat használna. Ez a példa csak akkor frissíti a szöveget és az alternatív szöveget, ha a név szerint az objektum egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **Alakzatok előre definiált korrekcióinak azonosítása és módosítása**

Az előre definiált geometriai alakzatok korrigálási pontokat fedhetnek fel, amelyek például a sarkok méretét, a nyíl arányait vagy az ívhömdök értékét szabályozzák. Ezekhez a csak‑olvasású [GeometryShape.adjustments](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometryshape/adjustments/) gyűjteményen keresztül férhet hozzá. A gyűjteményt maga az alakzat biztosítja, de minden [AdjustValue](https://reference.aspose.com/slides/hu/python-net/aspose.slides/adjustvalue/) tartalmaz egy módosítható értéket.

Ne csak egy fix gyűjtemény‑indexre támaszkodjon. Iteráljon a korrekciók között, és vizsgálja meg a csak‑olvasású [AdjustValue.type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/adjustvalue/type/) tulajdonságot, amelynek a [ShapeAdjustmentType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapeadjustmenttype/) értéke leírja, mit szabályoz a korrekció. A csak‑olvasású [AdjustValue.name](https://reference.aspose.com/slides/hu/python-net/aspose.slides/adjustvalue/name/) további azonosító információt nyújt, és különösen hasznos, ha egy előre beállított alakzat több azonos szemantikai típusú korrekciót tartalmaz.

Használja azt az érték‑tulajdonságot, amely a korrekció jelentésének megfelelő:

| Korrekció típusa | Cél | Módosítandó érték |
|---|---|---|
| `CORNER_SIZE` | Lekerekített sarkok mérete | [raw_value](https://reference.aspose.com/slides/hu/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | Nyíl farok vastagsága | `raw_value` |
| `ARROWHEAD_LENGTH` | Nyílfej hossza | `raw_value` |
| `ARROWHEAD_WIDTH` | Nyílfej szélessége | `raw_value` |
| `START_ANGLE` | Körív vagy ív kezdőszöge | [angle_value](https://reference.aspose.com/slides/hu/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | Körív vagy ív végszöge | `angle_value` |

A `type` és a `name` nem módosítható. A `raw_value` egy olvas‑írás integer az előre beállított natív geometriai egységekben, míg az `angle_value` fokban kifejezett olvas‑írás szög. A korrekciók száma, sorrendje, jelentése és érvényes tartománya az adott [GeometryShape.shape_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometryshape/shape_type/)‑tól függ. Egy előre definiált alakzathoz érvényes érték egy másiknál érvénytelen vagy más hatást eredményezhet.

Amikor a `type` értéke `ShapeAdjustmentType.CUSTOM`, az API nem ismeri fel a szabványos szemantikai jelentést. Vizsgálja meg a `name`‑et, az előre beállított típust és a meglévő értéket, és csak akkor hagyja változatlanul a korrekciót, ha a várt jelentés és tartomány ismert. Még a felismert típusok esetén is ellenőrizze, hogy ugyanaz a típus többször is előfordul‑e, mielőtt értéket választana. A [Connector](/slides/hu/python-net/connector/) cikk bemutatja a helyzetet a connector‑görbületi korrekciókkal.

Az alábbi komplett példa három előre definiált alakzat alap‑ és módosított változatait hozza létre. Iterál minden korrekción, jelzi a `name`‑et és a `type`‑ot, a mérettel kapcsolatos értékeket a `raw_value`‑val módosítja, a szögeket az `angle_value`‑val, majd elmenti az eredményt. A bal oszlop az alap geometriai formát tartja; a jobb oszlop a módosított lekerekített téglalapot, a négyleves nyilat és a körívet mutatja.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Adjunk fejléceket az alapértelmezett és a módosított alakzat oszlopokhoz.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

A szemantikai típus ellenőrzése érték módosítása előtt egyértelművé teszi a kód szándékát, és elkerüli annak feltételezését, hogy egy adott gyűjtemény‑index ugyanazt a jelentést hordozza különböző előre definiált alakzatoknál.

## **Alakzatgyűjtemény módosítása**

A hozzáadás, klónozás, eltávolítás és átrendezés metódusai azonnal a gyűjteményen hatnak. Ha egy művelet megváltoztatja az alakzatok számát vagy sorrendjét, ne támaszkodjon tovább a korábban rögzített indexekre.

### **Alakzat klónozása**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/add_clone/) egy független másolatot hoz létre, és a célgyűjtemény végéhez fűzi. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/insert_clone/) szintén másolatot készít, de egy megadott Z‑rend indexnél helyezi el. A koordinátákat elfogadó túlterhelések a méretet nem változtatják; a szélességet és magasságot megadó túlterhelések átméretezhetik is.

A példa egy céldiát hoz létre, egy címkézett téglalapot klónoz a frontra, és egy második klónt szúr be a háttérbe. Az egyik vagy másik klón módosítása nem befolyásolja a forrás alakzatot.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

A klónozás lemásolja az alakzat tartalmát és formázását, beleértve a nevet és az alternatív szöveget is. Ha ezeknek az értékeknek egyedinek kell maradniuk, új logikai azonosítókat kell hozzárendelni a klónhoz. Az összetett alakzatok által használt erőforrásokat a prezentáció kezeli, de a klón egy új gyűjtemény‑elemként új alakzat‑identitással jelenik meg.

### **Alakzatok eltávolítása**

[ShapeCollection.remove](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/remove/) egy adott alakzatot töröl a gyűjteményéből. Több egyező elem eltávolítása során indexelt iteráció esetén járjon végig a végéről, hogy a fennmaradó indexek érvényben maradjanak.

Ez a példa minden megnevezett nevet viselő alakzatot eltávolít. A `slide.shapes[index]`‑et használja, nem egy fix gyűjtemény‑elemet, és nincs felesleges típuskonverzió.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Eltávolítás után az alakzatok száma és a későbbi elemek indexei változnak. A nem érintett alakzatokra mutató hivatkozások megbízhatóbbak, mint a mentett indexek. Vegye figyelembe a connector‑okat, animációkat és egyéb prezentációs elemeket is, amelyek az eltávolított objektumra hivatkozhatnak; egy látható alakzat eltávolítása több mint csak a dia megjelenését változtathatja meg.

### **Alakzat elrejtése**

A [Shape.hidden](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/hidden/) `True`‑ra állítása megtartja az alakzatot a gyűjteményben, de megakadályozza, hogy a normál diavetítésben megjelenjen. Indexe, formázása és tartalma továbbra is elérhető a kódból, ezért az elrejtés alkalmas opcionális elemekre, amelyeket később vissza lehet állítani.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

Az elrejtés nem törlés vagy biztonsági intézkedés. Az objektum továbbra is felfedezhető és visszavonható felhasználó vagy kód által, és része marad a prezentációs fájlnak.

### **Z‑rend módosítása**

Átfedő alakzatok a gyűjtemény sorrendjében kerülnek kirajzolásra. A [ShapeCollection.reorder](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/reorder/) egy már meglévő alakzatot egy cél‑indexre helyez anélkül, hogy klónozná. A `0`‑s index a hátul, a `len(slide.shapes) - 1` az elöl.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

A téglalap előbb kerül létrehozásra, és eleinte a kör mögött helyezkedik el. A végső indexre helyezése előre hozza. A Z‑rendet a kapcsolódó alakzatok hozzáadása vagy klónozása után állítsa be, mivel ezek a műveletek új elem(ek)et fűznek a gyűjteményhez, és megváltoztathatják a kívánt rétegsorrendet.

## **Layout diákon lévő alakzatok ellenőrzése**

A normál diák, layout‑diákok és master‑diák különböző alakzatgyűjteményekkel rendelkeznek. Egy layout‑gyűjteményben lévő alakzat nem ugyanaz az objektum, mint egy hasonlóan elhelyezett alakzat egy normál dián. Layout‑alakzatokat akkor ellenőrizze, amikor a layout által biztosított formázást akarja megérteni vagy módosítani.

Az alábbi példa minden layout‑alakzat [Shape.fill_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/fill_format/) és [Shape.line_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/line_format/) tulajdonságát olvassa, anélkül, hogy feltételezné, hogy minden alakzat `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

A layout szerkesztése több, az adott layoutot használó diára is hatással lehet. Mielőtt layout‑alakzatot módosítana, határozza meg, hogy egy normál dia örökli‑e az objektumot vagy helyi felülírást tartalmaz‑e, és tesztelje az összes, az adott layoutot használó diát.

## **Alakzat exportálása SVG‑be**

A [Shape.write_as_svg](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/write_as_svg/) egy alakzat renderelt tartalmát egy adatfolyamba írja. Az eredmény csak az alakzatot tartalmazza, nem a teljes dia háttérét vagy a szomszédos alakzatokat.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

Tartsa nyitva a prezentációt a renderelés során. A kimenet az alakzat formázásától, valamint a betűtípusok és képekhez hasonló erőforrásoktól függ. Ha a teljes kompozícióra van szükség, exportálja a diát, ne csak az egyes alakzatot. A hívó birtokolja az adatfolyamot, és köteles azt lezárni.

## **Alakzatok igazítása**

A [SlideUtil.align_shapes](https://reference.aspose.com/slides/hu/python-net/aspose.slides.util/slideutil/align_shapes/) túlterhelései vagy az összes alakzatot, vagy a kijelölt gyűjtemény‑indexeket igazítják. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapesalignmenttype/) megadja a szél, középvonal vagy elosztási módot. Az `align_to_slide` `True`‑ra állítása a dia széleit használja; `False` esetén a kijelölt alakzatok egymáshoz viszonyított igazítása történik.

Ez a példa három alakzatot a dia felső széléhez igazít. Az aktuális indexek az igazítás előtt azonnal feloldódnak.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Az igazítás pozíciókat változtat, nem a Z‑rendet. Relatív igazítás általában legalább két alakzatot igényel, míg a vízszintes vagy függőleges elosztás elegendő alakzatot igényel a távolság meghatározásához. Ha a gyűjteményt módosítja a metódus hívása előtt, számolja újra az indexeket.

## **Alakzat tükrözése**

A [ShapeFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapeframe/) osztály tárolja a pozíciót, méretet, a vízszintes és függőleges tükrözés beállításait, valamint a forgást. `flip_h` és `flip_v` értékei a [NullableBool](https://reference.aspose.com/slides/hu/python-net/aspose.slides/nullablebool/) típusúak: `TRUE` engedélyezi a tükrözést, `FALSE` letiltja, a `NOT_DEFINED` pedig az nincs meghatározott vagy alapértelmezett állapotot őrzi meg.

Az alábbi bemeneti prezentáció egy nem tükrözött alakzatot tartalmaz.

![A kép a tükrözés előtt](shape_to_be_flipped.png)

A példa minden egyéb keretértéket megőriz, és csak a két tükrözési beállítást cseréli le. Ez azért fontos, mert egy új [Shape.frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/frame/) hozzárendelése a teljes keretet felülírja.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

A mentett alakzat vízszintesen és függőlegesen tükrözött, miközben a pozíciója, mérete és forgása változatlan marad.

![A kép a tükrözés után](flipped_shape.png)

## **GYIK**

**Használhatok-e gyűjtemény‑indexet alakzat azonosítóként?**

Csak rövid életű feldolgozáskor, amikor a gyűjtemény nem változik az index használata előtt. Előnyben részesítsen egy ellenőrzött `name` vagy `alternative_text` konvenciót a szerzői sablonoknál, vagy `office_interop_shape_id`‑t a dia‑szintű interop munkához.

**Eltávolítja‑e egy rejtett alakzat a Z‑rendet?**

Nem. Egy rejtett alakzat a gyűjteményben marad ugyanazon az indexen. Megtalálható, átrendezhető, szerkeszthető vagy újra láthatóvá tehető.

**Miért jelent meg egy klónozott alakzat egy másik előtt?**

Az `add_clone` a klónt a gyűjtemény végére illeszti, ami a Z‑rend elölje. Használja az `insert_clone`‑t a kezdő index kiválasztásához, vagy a `reorder`‑t minden alakzat hozzáadása után.

**Használhatok‑e fix indexet egy előre definiált alakzatkorrekció azonosításához?**

Csak a pontos előre beállított és gyűjtemény‑elrendezés ellenőrzése után. Inkább iteráljon a `GeometryShape.adjustments`‑on, és ellenőrizze a `AdjustValue.type`‑ot; ha ugyanaz a szemantikai típus többször is előfordul, használja a `AdjustValue.name`‑t további információként.