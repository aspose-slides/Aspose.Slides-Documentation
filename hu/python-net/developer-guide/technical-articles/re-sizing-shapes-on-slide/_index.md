---
title: Formák átméretezése a bemutató diákon Pythonban
type: docs
weight: 130
url: /hu/python-net/resizing-shapes-on-slide/
aliases:
  - /hu/python-net/re-sizing-shapes-on-slide/
  /python-net/re-sizing-shapes-on-slide/
keywords:
- forma átméretezése
- forma méretének módosítása
- PowerPoint
- OpenDocument
- bemutató
- Python
- Aspose.Slides
description: "Könnyedén átméretezheti a formákat PowerPoint és OpenDocument diákon az Aspose.Slides for Python via .NET segítségével—automatizálja a diaelrendezés állítását és növelje a hatékonyságot."
---
## **Áttekintés**

Amikor megváltoztatja a bemutató diája méretét, előfordulhat, hogy át kell méretezni és áthelyezni a formákat, hogy illeszkedjenek az új méretekhez. Ez a cikk bemutatja, hogyan lehet manuálisan nagyítani a formákat, valamint hogyan kell kezelni a táblázatokat a diákon, mesteroldalakon és elrendezéseken.

## **Formák átméretezése**

Az egyes formák relatív pozíciójának és méretének megőrzéséhez szorozza meg a vízszintes koordinátákat és a szélességet az új dia szélességének és az eredeti szélességnek az arányával. Alkalmazza a megfelelő magasságarányt a függőleges koordinátákra és a magasságra.

Az első példa betölt egy olyan bemutatót, amelynek diái nem tartalmaznak táblázatokat, A4-re változtatja a dia méretét, és elmenti az eredményt. A [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) függvényt használja a [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) opcióval, hogy a későbbi ciklus vezérelje a méretezést. Az arányok dimenziótól függetlenek; a formák pozíciói és méretei pontban vannak mérve. A szélesség és magasság különböző arányai torzíthatják a formákat, és egy forma méretének módosítása nem méretezi át a betűméreteket.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Számítsa ki a független vízszintes és függőleges skálázási tényezőket.
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
A táblázatok külön kezelést igényelnek: a oszlopszélességeket és sormagasságokat kell méretezni, ahelyett, hogy a táblázat teljes szélességét és magasságát állítaná be. A sormagasságok nagyobbak maradhatnak a kért értéknél, ha a cella tartalma több helyet igényel.
{{% /alert %}}

A második példa támogatja a táblázatokat, és a mesteroldalakon, elrendezéseken, valamint az egyes diákon lévő formákat dolgozza fel, mielőtt elmentené a átméretezett bemutatót. A segédprogram kezel minden [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) elemet azáltal, hogy méretezi a [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) és a [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) értékeket. Ezután a táblázat pozícióját méretezi, anélkül, hogy külön méretezi a teljes méreteket.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # A táblázat méreteit az oszlopszélességek és sormagasságok határozzák meg.
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
    # Számítsa ki a független vízszintes és függőleges skálázási tényezőket.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # Átméretezze a mesterekben és elrendezésekben, valamint az egyedi diákon definiált formákat.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Miért torzulnak vagy vágódnak le a formák a dia átméretezése után?**

Ha a dia méretét a formák méretezése nélkül változtatja meg, azok megtartják eredeti pozíciójukat és méretüket, és a dia szélén túl is szerepelhetnek. A szélesség és magasság különböző arányokkal történő méretezése szintén torzíthatja a formákat.

**A megadott kód minden forma típusra működik?**

Az első példa közvetlenül módosítja a forma határait, és olyan diákra vonatkozik, amelyekben nincs táblázat. A második példa külön kezeli a táblázatokat. Ellenőrizze a kapott elrendezést, különösen a szöveget és a táblázatokat, mert ezek a példák nem méreteznek át betűméreteket, és a táblázat tartalma korlátozhatja a sormagasságokat.

**Hogyan méretezzem át a táblázatokat a dia átméretezésekor?**

Méretezze az oszlopszélességeket a szélesség arányával, a minimális sormagasságokat a magasság arányával, majd a táblázat pozícióját, ahogy a második példában látható.

**Működik ez az átméretezés a mesterdiákon és az elrendezésdiasokon?**

Igen. A második példa végigiterál a [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) elemein és minden mester [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) elemén, és ugyanazt az átméretezési logikát alkalmazza a formáikra.

**Módosíthatom a dia tájolását (álló/fekvő) az átméretezés során?**

Igen. Állítsa be a [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) értéket a dia méretének megváltoztatása után, a célméretek leolvasása előtt, hogy a méretezési tényezők a végleges tájolást tükrözzék.

**Van korlátja a beállítható dia méretnek?**

Egyéni dia méreteket adhat meg a [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) használatával. A támogatott méretek a bemutató formátumától és a fájlt megnyitó alkalmazástól is függenek.

**Hogyan akadályozhatom meg, hogy a fix képarányú formák torzuljanak?**

Használjon ugyanazt a méretezési tényezőt a szélességhez és a magassághoz. Az eredeti elrendezés az új dia méreteibe való illesztéshez használja a szélesség és magasság arányának kisebbikét mindkét dimenzióhoz és pozícióhoz. Ez megőrzi az arányokat, de előfordulhat, hogy egy oldalon üres hely marad.