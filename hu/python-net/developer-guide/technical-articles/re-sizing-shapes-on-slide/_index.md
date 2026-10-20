---
title: Alakzatok átméretezése a bemutató diákon Pythonban
type: docs
weight: 130
url: /hu/python-net/resizing-shapes-on-slide/
aliases:
  - /python-net/alakzatok-átméretezése-dián/
  - /hu/python-net/re-sizing-shapes-on-slide/
keywords:
  - alakzat átméretezése
  - alakzat méretének módosítása
  - PowerPoint
  - OpenDocument
  - bemutató
  - Python
  - Aspose.Slides
description: "Könnyedén átméretezheti az alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for Python via .NET segítségével—automatizálja a diákelrendezés módosítását és növelje a termelékenységet."
---
## **Áttekintés**

Amikor módosítja egy bemutató diák méretét, előfordulhat, hogy át kell méretezni és újra kell helyezni az alakzatokat, hogy illeszkedjenek az új méretekhez. Ez a cikk bemutatja, hogyan kell kézzel átméretezni az alakzatokat, valamint hogyan kell kezelni a táblákat a diákon, a mestereken és az elrendezéseken.

## **Alakzatok átméretezése**

Az egyes alakzatok relatív pozíciójának és méretének megőrzéséhez szorozza meg a vízszintes koordinátákat és a szélességet az új diaszélesség és az eredeti szélesség arányával. Alkalmazza a megfelelő magasságarányt a függőleges koordinátákra és a magasságra.

Az első példa betölti egy olyan bemutatót, amely diáiban nincsenek táblák, A4-re változtatja a diaméretet, és elmenti az eredményt. A [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) metódust a [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) értékkel használja, hogy a későbbi ciklus vezérelje a méretezést. Az arányok dimenzió nélküli értékek; az alakzat pozíciói és méretei pontokban vannak megadva. A különböző szélesség- és magasságarányok torzíthatják az alakzatokat, és az alakzat méretének módosítása nem méretezi át a betűméreteket.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Számítsa ki a független vízszintes és függőleges méretezési tényezőket.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
A tábláknak külön kezelése szükséges: skálázza oszlopuk szélességét és soruk magasságát ahelyett, hogy a táblázat teljes szélességét és magasságát állítaná be. A sormagasságok nagyobbak lehetnek a kért értéknél, ha a cella tartalma több helyet igényel.
{{% /alert %}}

A második példa támogatja a táblákat, és a mestereken, elrendezéseken, valamint az egyes diákon lévő alakzatokat is feldolgozza, mielőtt elmenti az átméretezett bemutatót. Segítője minden [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) úgy kezeli, hogy skálázza a [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) és a [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) értékeket. Ezután a táblázat pozícióját méretezi át, anélkül, hogy külön skálázná annak összméreteit.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # A táblázat méreteit az oszlopszélességek és a sormagasságok szabályozzák.
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # Számítsa ki a független vízszintes és függőleges méretezési tényezőket.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # Átméretezze a mester- és elrendezésdiákokon, valamint az egyes diákon definiált alakzatokat.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Miért torzulnak vagy vágódnak le az alakzatok a dia átméretezése után?**  
Ha a diaméretet az alakzatok méretezése nélkül módosítja, azok megtartják eredeti pozíciójukat és méretüket, és a dián kívülre is nyúlhatnak. A szélesség és magasság különböző arányokkal való skálázása szintén torzíthatja az alakzatokat.

**Működik a megadott kód minden alakzattípusra?**  
Az első példa közvetlenül módosítja az alakzat határait, és táblázat nélküli diákra szánt. A második példa külön kezeli a táblákat. Ellenőrizze a kapott elrendezést, különösen a szöveget és a táblákat, mivel ezek a példák nem méretezik át a betűméreteket, és a táblázat tartalma korlátozhatja a sormagasságokat.

**Hogyan méretezem át a táblákat a dia átméretezésekor?**  
Skálázza az oszlopszélességeket a szélességi arány szerint, a minimális sormagasságokat a magassági arány szerint, majd a táblázat pozícióját méretezze át, ahogyan a második példában is látható.

**Ez az átméretezés működik-e a mesterdiákon és az elrendezésdiákon?**  
Igen. A második példa végigiterál a [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) és minden mester [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) elemein, és ugyanazt az átméretezési logikát alkalmazza az alakzataikra.

**Meg tudom-e változtatni egy dia tájolását (álló/fekvő) az átméretezés során?**  
Igen. Állítsa be a [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) értékét a diaméret módosítása után és a célméretek beolvasása előtt, hogy a méretezési tényezők a végső tájolást tükrözzék.

**Van korlátja a beállítható diaméretnek?**  
Egyéni diaméreteket adhat meg a [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) segítségével. A támogatott méretek a bemutató formátumától és a fájlt megnyitó alkalmazástól is függnek.

**Hogyan akadályozhatom meg, hogy a fix képarányú alakzatok torzuljanak?**  
Használja ugyanazt a méretezési tényezőt a szélességhez és a magassághoz. Az eredeti elrendezés az új diaméretekbe való illesztéséhez használja a szélességi és magassági arányok közül a kisebbet mindkét dimenzióra és pozícióra. Ez megőrzi az arányokat, de egy oldal mentén üres hely maradhat.