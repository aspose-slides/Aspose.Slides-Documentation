---
title: Prezentációs alakzatok kezelése Pythonban
linktitle: Alakzatkezelés
type: docs
weight: 40
url: /hu/python-net/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentációs alakzat
- dia alakzat
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat ID lekérése
- alakzat alternatív szöveg
- alakzat elrendezési formátumok
- alakzat SVG-ként
- alakzat SVG-be
- alakzat igazítása
- alakzat tükrözése
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan azonosíthat, klónozhat, eltávolíthat, elrejthet, átrendezhet, exportálhat, igazíthat és tükrözhet prezentációs alakzatokat az Aspose.Slides for Python via .NET segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET a dián lévő alakzatokat rendezett [ShapeCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/) gyűjteményként ábrázolja. A gyűjtemény egyszerre az a hely, ahol az alakzatokat megtalálja és módosítja, valamint a rétegzési sorrend forrása: a `0` indexű alakzat a leghátruló, míg az utolsó index a legelöl lévő alakzat.

Ez a cikk ezt a modellt követi. Először bemutatja, hogyan azonosítható egy alakzat megbízhatóan, majd megmutatja, hogyan lehet klónozni, eltávolítani, elrejteni és átrendezni az alakzatokat. Az utolsó szakaszok a layout szintű formázást, az SVG exportot, az igazítást és a tükrözési beállításokat fedik le. Minden példa önálló, ezért csak azokat a műveleteket használhatja, amelyekre a munkafolyamatnak szüksége van.

## **Alakzatok azonosítása és keresése**

A gyűjtemény indexei kényelmesek egy ismert fájl feldolgozásakor, de nem stabil azonosítók. Egy alakzat hozzáadása, eltávolítása vagy átrendezése megváltoztathatja az indexét. Válasszon azonosítót a bemutató szerződésének és karbantartásának módja alapján:

- [Shape.name](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/name/) hasznos fejlesztő által vezérelt sablonokhoz, és könnyen megtekinthető a PowerPoint Kijelölés ablaktáblájában. A nevek szerkeszthetők, és nem garantált, hogy egyediek, ezért alakítson ki egy névadási konvenciót, ha a kód függ tőlük.
- [Shape.alternative_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/alternative_text/) akkor hasznos, ha egy akadálymentesítési leírás vagy egy szerző által megadott címke már azonosítja az alakzatot. A felhasználók számára látható, lokalizálható vagy átírható a hozzáférhetőség érdekében, és nem garantált, hogy egyedi. Ne használja csendben jelentős akadálymentesítési szöveget adatbáziskulcsként.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/office_interop_shape_id/) egy csak olvasható azonosító, amely egy dián belül egyedi, és a PowerPoint interop által használt alakzat-azonosítónak felel meg. Használja, ha PowerPointtal integrál, vagy ha egyértelmű hivatkozásra van szükség egy alakzat élettartama során. Egy klónozott vagy újjáépített alakzat másik alakzat, és saját azonosítót kap.

A kapcsolódó [Shape.unique_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/unique_id/) tulajdonság prezentációszintű, de kiegészítőkhöz szánt és újra hozzárendelhető. Nem kell állandó külső kulcsként kezelni. Ha a hosszú távú azonosítás kulcsfontosságú, tartsa a leképezést alkalmazásadatokban, és ellenőrizze, hogy a várt alakzat még létezik-e.

A következő példa a `name` alapján pontos összehasonlítással keres, és a diához tartozó interop ID-t adja vissza. Ha a sablon nem tartalmazza a várt alakzatot, a kód ezt az eredményt jelenti, ahelyett, hogy a rossz objektummal folytatná.

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

Amikor egy művelet alakzat típusra specifikus, ellenőrizze a típust, mielőtt típus-specifikus tagokat használna. Ez a példa csak akkor frissíti a szöveget és a alternatív szöveget, ha a megnevezett objektum egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/).

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

## **Az alakzatgyűjtemény módosítása**

A hozzáadás, klónozás, eltávolítás és átrendezés módszerei azonnal a gyűjteményen működnek. Ha egy művelet módosítja az alakzatok számát vagy sorrendjét, ne támaszkodjon tovább a művelet előtt rögzített indexekre.

### **Alakzat klónozása**

A [ShapeCollection.add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/add_clone/) egy független másolatot hoz létre, és a célgyűjtemény végére fűzi. A [ShapeCollection.insert_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/insert_clone/) szintén másolatot készít, de egy megadott z-rend indexre helyezi. A koordinátákat elfogadó túlterhelések a klónt méretváltoztatás nélkül mozgatják; a szélességet és magasságot megadó túlterhelések átméretezhetik is.

A példa egy cél diát hoz létre, egy címkével ellátott téglalapot klónoz a frontra, majd egy második klónt szúr be a hátulra. Az egyik klón módosítása nem érinti a forrás alakzatot.

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

A klónozás másolja az alakzat tartalmát és formázását, beleértve a nevet és az alternatív szöveget is. Adjunk új logikai azonosítókat a klónnak, ha ezeknek egyedinek kell lenniük. Az összetett alakzatok által használt erőforrásokat a prezentáció kezeli, de a klón egy új gyűjteményelem új alakzat-azonosítóval.

### **Alakzatok eltávolítása**

A [ShapeCollection.remove](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/remove/) egy adott alakzatot töröl a saját gyűjteményéből. Több egyező elem eltávolításakor indexelt iteráció során haladjon végig a végéről, hogy a megmaradt indexek érvényesek maradjanak.

Ez a példa minden megadott névvel rendelkező alakzatot eltávolít. A `slide.shapes[index]` értéket olvassa, nem egy rögzített gyűjteményelemet, és nem kényszeríti feleslegesen a típuskonverziót.

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

Eltávolítás után a alakzatok száma és a későbbi alakzatok indexei megváltoznak. A nem érintett alakzatok hivatkozásai megbízhatóbbak, mint a korábban elmentett indexek. Vegye figyelembe a vonalakat, animációkat és egyéb prezentációs elemeket is, amelyek az eltávolított objektumra hivatkozhatnak; egy látható alakzat eltávolítása több, mint a dia megjelenését változtathatja meg.

### **Alakzat elrejtése**

A [Shape.hidden](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/hidden/) `True` értékre állítása az alakzatot a gyűjteményben hagyja, de megakadályozza, hogy a normál diavetítésben megjelenjen. Indexe, formázása és tartalma továbbra is elérhető a kód számára, ezért a rejtés megfelelő opcionális elemek esetén, amelyek később visszaállíthatók.

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

A rejtés nem törlés vagy biztonság. Az objektum továbbra is felfedezhető és felhasználó vagy kód által visszakerülhető, és része marad a prezentációs fájlnak.

### **Z-sorrend módosítása**

Az átfedő alakzatok a gyűjtemény sorrendjében kerülnek megrajzolásra. A [ShapeCollection.reorder](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/reorder/) egy már létező alakzatot egy célindexre mozgat klónozás nélkül. A `0` index a hátul, a `len(slide.shapes) - 1` a front.

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

A téglalap először jön létre, és eleinte a kör alatti helyen van. A végső indexre mozgatása előre helyezi. A z-sorrendet állítsa be az összes kapcsolódó alakzat hozzáadása vagy klónozása után, mert ezek a műveletek új elemeket fűznek a gyűjteményhez vagy szúrnak be, és megváltoztathatják a kívánt rétegezést.

## **Alakzatok ellenőrzése elrendezési diákon**

A normál diák, elrendezési diák és mester diák külön alakzatgyűjteménnyel rendelkeznek. Egy elrendezési gyűjteményben lévő alakzat nem ugyanaz az objektum, mint egy hasonlóan elhelyezkedő alakzat egy normál dián. Ellenőrizze az elrendezési alakzatokat, amikor a layout által biztosított formázást kell megérteni vagy módosítani.

A következő példa minden elrendezési alakzat [Shape.fill_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/fill_format/) és [Shape.line_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/line_format/) értékét olvassa, anélkül, hogy feltételezné, hogy minden alakzat `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Egy elrendezés szerkesztése több diára is hatással lehet, amelyik használja azt. Mielőtt egy elrendezési alakzatot módosítana, határozza meg, hogy egy normál dia örökli-e az objektumot vagy helyi felülírást tartalmaz, és tesztelje az összes diát, amely az elrendezést használja.

## **Alakzat exportálása SVG-be**

A [Shape.write_as_svg](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/write_as_svg/) egy alakzat renderelt tartalmát írja egy streambe. Az eredmény csak az alakzatot tartalmazza, nem a teljes dia háttérjét vagy a szomszédos alakzatokat.

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

Tartsa nyitva a prezentációt a renderelés időtartama alatt. A kimenet az alakzat formázásától és olyan erőforrásoktól (például betűtípusok, képek) függ. Ha a teljes kompozícióra van szükség, exportálja a diát, nem egyetlen alakzatot. A hívó birtokolja a streamet, és meg kell azt zárnia.

## **Alakzatok igazítása**

A [SlideUtil.align_shapes](https://reference.aspose.com/slides/hu/python-net/aspose.slides.util/slideutil/align_shapes/) túlterhelései igazíthatják az összes alakzatot vagy a kiválasztott gyűjtemény indexeit. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapesalignmenttype/) megadja a szél, középvonal vagy elosztási módot. Állítsa `align_to_slide` értékét `True`‑ra, ha a dia széleihez szeretne igazítani; `False` esetén a kiválasztott alakzatok egymáshoz viszonyított igazítását használja.

Ez a példa három alakzatot igazít a dia felső széléhez. Az aktuális indexek a igazítás előtt kerülnek feloldásra.

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

Az igazítás a pozíciókat, nem a z-sorrendet változtatja. Relatív igazítás általában legalább két alakzatot igényel, míg a vízszintes vagy függőleges elosztáshoz elegendő alakzat kell a távolság meghatározásához. Számolja újra az indexeket, ha a metódus hívása előtt módosította a gyűjteményt.

## **Alakzat tükrözése**

A [ShapeFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapeframe/) osztály tárolja a pozíciót, méretet, a vízszintes és függőleges tükrözés beállításait, valamint a forgatást. A `flip_h` és `flip_v` értékek a [NullableBool](https://reference.aspose.com/slides/hu/python-net/aspose.slides/nullablebool/) típusúak: `TRUE` engedélyezi a tükrözést, `FALSE` letiltja, a `NOT_DEFINED` pedig megőrzi a nem meghatározott vagy alapértelmezett állapotot.

Az alábbi bemeneti prezentáció egy nem tükrözött alakzatot tartalmaz.

![Az alakzat a tükrözés előtt](shape_to_be_flipped.png)

A példa minden egyéb keretértéket megőriz, és csak a két tükrözési beállítást cseréli le. Ez fontos, mert egy új [Shape.frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/frame/) hozzárendelése a teljes keretet felülírja.

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

A mentett alakzat vízszintesen és függőlegesen is tükröződik, miközben megtartja a pozícióját, méretét és forgását.

![Az alakzat a tükrözés után](flipped_shape.png)

## **GYIK**

**Használhatok gyűjtemény indexet alakzat azonosítóként?**

Csak rövid életű feldolgozásoknál, amikor a gyűjtemény nem változik az index használata előtt. Előnyben részesítsen egy ellenőrzött `name` vagy `alternative_text` konvenciót a szerkesztett sablonoknál, vagy `office_interop_shape_id`‑t, ha diához kötött interop munkát végez.

**Eltávolítja-e egy rejtett alakzat a Z-sorrendből?**

Nem. A rejtett alakzat a gyűjteményben marad ugyanazon az indexen. Megtalálható, átrendezhető, szerkeszthető vagy újra láthatóvá tehető.

**Miért jelent meg egy klónozott alakzat egy másik alakzat előtt?**

Az `add_clone` a klónt a gyűjtemény végére fűzi, ami a Z-sorrend eleje. Használja az `insert_clone`‑t a kezdeti index megadásához, vagy a `reorder`‑t az összes alakzat hozzáadása után.