---
title: Alakzatok átméretezése a bemutató diákon Pythonon keresztül Java-val
type: docs
weight: 110
url: /hu/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/re-sizing-shapes-on-slide/
  - /hu/python-java/re-sizing-shapes-on-slide/
keywords:
  - alakzat átméretezése
  - alakzat méretének módosítása
  - PowerPoint
  - OpenDocument
  - bemutató
  - Python
  - Java
  - Aspose.Slides
description: "Könnyedén átméretezheted az alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for Python via Java segítségével – automatizáld a diaelrendezés módosítását és növeld a hatékonyságot."
---
## **Áttekintés**

Amikor megváltoztatod egy bemutató diavetületének méretét, előfordulhat, hogy át kell méretezni és újra kell helyezni a benne lévő alakzatokat, hogy illeszkedjenek az új méretekhez. Ez a cikk bemutatja, hogyan skálázhatók manuálisan az alakzatok, és hogyan kell kezelni a táblázatokat a diákon, a mesterdiákon és az elrendezéseken.

## **Alakzatok átméretezése**

Az egyes alakzatok relatív helyzetének és méretének megőrzéséhez szorozd meg a vízszintes koordinátáit és szélességét az új dia szélességének és az eredeti szélességnek arányával. A megfelelő magasságarányt alkalmazd a függőleges koordinátákra és a magasságra.

Az első példa betölt egy bemutatót, amely diáiban nincsenek táblázatok, A4-re változtatja a dia méretét, és elmenti az eredményt. A [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) függvényt a [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) beállítással használja, hogy az ezt követő ciklus szabályozza a skálázást. Az arányok egység nélküli értékek; az alakzatok pozíciói és méretei pontokban vannak megadva. A különböző szélesség- és magasságarányok torzíthatják az alakzatokat, és egy alakzat méretének megváltoztatása nem méretezi át a betűméreteket.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # Számítsa ki a független vízszintes és függőleges skálázási tényezőket.
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
A táblázatok külön kezelést igényelnek: a táblázat oszlopszélességét és sormagasságát kell skálázni a teljes táblázat szélességének és magasságának megadása helyett. A sormagasságok nagyobbak lehetnek a kért méretnél, ha a cella tartalma több helyet igényel.
{{% /alert %}}

A második példa támogatja a táblázatokat, és a mesterek és elrendezések, valamint az egyes diák alakzatait is feldolgozza, mielőtt elmentené az átméretezett bemutatót. A segédprogram a [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) minden egyes példányát a [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) segítségével skálázza az oszlopszélességekkel, és a [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) segítségével a minimális sormagasságokkal. Ezután a táblázat pozícióját méretezi, anélkül, hogy külön méretezné a teljes dimenzióit.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # A táblázat méreteit az oszlopszélességek és a sormagasságok szabályozzák.
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
    # Számítsa ki a független vízszintes és függőleges skálázási tényezőket.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # Átméretezze a mestereken és elrendezéseken, valamint az egyes diákon definiált alakzatokat.
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

**Miért torzulnak vagy vágódnak le az alakzatok egy dia átméretezése után?**

Ha a dia méretét skálázás nélkül változtatod, az alakzatok megtartják eredeti pozíciójukat és méretüket, és kikerülhetnek a diából. A szélesség és magasság különböző arányokkal való skálázása szintén torzíthatja az alakzatokat.

**A megadott kód minden alakzattípusra működik?**

Az első példa közvetlenül módosítja az alakzat határait, és táblázat nélküli diákra van szánva. A második példa külön kezeli a táblázatokat. Ellenőrizd a kapott elrendezést, különösen a szöveget és a táblázatokat, mivel ezek a példák nem méretezik át a betűméreteket, és a táblázat tartalma korlátozhatja a sormagasságokat.

**Hogyan méretezzem át a táblázatokat egy dia átméretezésekor?**

Skálázd az oszlopszélességeket a szélesség arányával, a minimális sormagasságokat a magasság arányával, majd a táblázat pozícióját, ahogyan a második példában is látható.

**Ez az átméretezés működik a mesterdiákon és az elrendezési diákon is?**

Igen. A második példa végigiterál a [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) és minden mester [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) elemein, és ugyanazt az átméretezési logikát alkalmazza az alakzataikra.

**Módosíthatom a dia tájolását (álló/fekvő) az átméretezés során?**

Igen. Hívd meg a [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) függvényt a dia méretének módosítása után, és még a célméretek lekérdezése előtt, hogy a skála tényezők a végső tájolást tükrözzék.

**Van korlátozás a beállítható dia méretre?**

Egyéni dia méreteket adhat meg a [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) segítségével. A támogatott méretek a bemutató formátumától és a fájlt megnyitó alkalmazástól is függenek.

**Hogyan akadályozhatom meg, hogy a rögzített képarányú alakzatok torzuljanak?**

Használd ugyanazt a skála tényezőt a szélesség és magasság esetén. Az eredeti elrendezés az új dia méreteihez való igazításához használd a szélességi és magassági arányok közül a kisebbet mindkét dimenzióra és pozícióra. Ez megőrzi az arányokat, de előfordulhat, hogy egy szélén üres hely marad.