---
title: Formák átméretezése prezentációs diáikon Python használatával Java-on keresztül
type: docs
weight: 110
url: /hu/python-java/resizing-shapes-on-slide/
aliases:
  - /hu/python-java/re-sizing-shapes-on-slide/
  /python-java/forma-ujramereteles-diakon/
keywords:
- forma átméretezése
- forma méretének módosítása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Könnyedén átméretezheti a formákat PowerPoint és OpenDocument diáikon az Aspose.Slides for Python via Java segítségével – automatizálja a diasablon beállításait és növelje a hatékonyságot."
---
## **Áttekintés**

Ha megváltoztatja egy bemutató diavetületének méretét, előfordulhat, hogy a formákat is át kell méretezni és áthelyezni, hogy illeszkedjenek az új méretekhez. Ez a cikk bemutatja, hogyan lehet manuálisan méretezni a formákat, és hogyan kell kezelni a táblázatokat a diákon, a mester‑ és elrendezési diákon.

## **Formák átméretezése**

Az egyes formák relatív pozíciójának és méretének megőrzéséhez szorozza a vízszintes koordinátákat és a szélességet az új diaszélesség és az eredeti szélesség arányával. Az ennek megfelelő magasságarányt alkalmazza a függőleges koordinátákra és a magasságra.

Az első példa betölt egy olyan bemutatót, amelynek diái nem tartalmaznak táblázatot, A4‑re változtatja a diaméretet, és elmenti az eredményt. A [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) metódust a [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) értékkel használja, hogy a későbbi ciklus szabályozza a méretezést. Az arányok mértékegység nélküli értékek; a formák pozíciói és méretei pontokban vannak megadva. A különböző szélesség‑ és magasságarányok torzíthatják a formákat, és a forma méretének módosítása nem méretezi át a betűméreteket.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # Számolja ki a független vízszintes és függőleges méretezési tényezőket.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
A táblázatokat külön kell kezelni: a táblázat teljes szélességét és magasságát nem kell beállítani, hanem az oszlopszélességeket és sormagasságokat kell méretezni. A sormagasságok nagyobbak lehetnek a kért értéknél, ha a cella tartalma több helyet igényel.
{{% /alert %}}

A második példa támogatja a táblázatokat, és a mester‑ és elrendezési diákon, valamint az egyes diákon lévő formákat is feldolgozza, mielőtt elmenti a méretezett bemutatót. A segédprogram minden [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) elemet úgy kezel, hogy az oszlopszélességeket a [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) metódussal, a minimális sormagasságokat pedig a [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) metódussal méretezi. Ezután a táblázat pozícióját méretezi, anélkül hogy külön méretezné a teljes méreteket.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # A táblázat méretei az oszlopszélességek és a sormagasságok által vannak szabályozva.
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # Számítsa ki a független vízszintes és függőleges méretezési tényezőket.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # Átméretezze a mesterekben és elrendezésekben, valamint az egyes diákon definiált formákat.
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Miért torzulnak vagy vágódnak le a formák a dia átméretezése után?**

Ha a diaméretet átméretezés nélkül módosítja, a formák megtartják eredeti pozícióikat és méreteiket, és a dia szélén túl is kinyúlhatnak. A szélesség és magasság különböző arányokkal való méretezése szintén torzíthatja a formákat.

**Működik a megadott kód minden forma típusra?**

Az első példa közvetlenül módosítja a forma korlátait, és olyan diákra vonatkozik, amelyek nem tartalmaznak táblázatot. A második példa külön kezeli a táblázatokat. Ellenőrizze az eredő elrendezést, különösen a szöveget és a táblázatokat, mivel ezek a példák nem méretezik át a betűméreteket, és a táblázattartalom korlátozhatja a sormagasságokat.

**Hogyan méretezem át a táblázatokat egy dia átméretezésekor?**

Mérje át az oszlopszélességeket a szélesség arányával, a minimális sormagasságokat a magasság arányával, majd méretezze a táblázat pozícióját, ahogyan a második példában látható.

**Ez az átméretezés működik mester‑diaikon és elrendezési diákon is?**

Igen. A második példa végigiterál a [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) metóduson és minden mester [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) metódusán, és azonos átméretezési logikát alkalmaz a formáikra.

**Megváltoztathatom egy dia tájolását (álló/ fekvő) az átméretezés mellett?**

Igen. Hívja meg a [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) metódust a diaméret megváltoztatása után és a célméretek lekérése előtt, hogy a méretezési tényezők a végső tájolást tükrözzék.

**Van korlátja a beállítható diaméretnek?**

Egyéni diaméreteket adhat meg a [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) metódussal. A támogatott méretek a bemutató formátumától és a fájlt megnyitó alkalmazástól is függnek.

**Hogyan akadályozhatom meg, hogy a rögzített képarányú formák torzuljanak?**

Használjon azonos méretezési tényezőt a szélességhez és a magassághoz. Az eredeti elrendezés új diaméretekhez való igazításához a szélesség‑ és magasságarányok közül a kisebbet alkalmazza mind a méretekre, mind a pozíciókra. Ez megőrzi az arányokat, de előfordulhat, hogy egy oldal mentén üres hely marad.