---
title: PowerPoint diák klónozása Pythonban
linktitle: Diák klónozása
type: docs
weight: 40
url: /hu/python-net/clone-slides/
keywords:
- dia klónozása
- dia másolása
- dia mentése
- PowerPoint
- bemutató
- Python
- Aspose.Slides
description: "Az Aspose.Slides for Python via .NET segítségével gyorsan klónozhat vagy megkettőzhet PowerPoint diákat. Kövesse világos kódrészleteinket és tippjeinket a PPT létrehozásának másodpercek alatt történő automatizálásához, a termelékenység növeléséhez és a manuális munka megszüntetéséhez."
---
## **Bevezetés**

A klónozás egy olyan folyamat, amely során pontos másolat vagy replikát készítünk valamiről. Az Aspose.Slides lehetővé teszi, hogy bármely diát másoljon (klónozzon), majd a klónozott diát beillessze az aktuális prezentációba vagy bármely más nyitott prezentációba. A dia klónozása új diát hoz létre, amelyet a fejlesztők módosíthatnak anélkül, hogy az eredeti diát érintenék. A dia klónozásának több módja is létezik:

- Klónozás a prezentáció végén.
- Klónozás a prezentáció más pozíciójában.
- Klónozás egy másik prezentáció végén.
- Klónozás egy másik prezentáció más pozíciójában.
- Klónozás egy másik prezentáció meghatározott pozíciójában.

Az Aspose.Slides for Python via .NET-ben a [dia gyűjtemény](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/) a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektum által elérhető, amely biztosítja az `add_clone` és `insert_clone` metódusokat ezeknek a dia klónozási módoknak a végrehajtásához.

## **Telepítés**

```bash
pip install aspose.slides
```

## **Telepítés**

Ha ugyanabban a prezentációban szeretne egy diát klónozni, és a meglévő diák végére szeretné hozzáadni, használja az `add_clone` metódust. Kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezze be a dia gyűjteményt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumtól.
3. Hívja meg az `add_clone` metódust a [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/), átadva a klónozandó diát.
4. Mentse el a módosított prezentációt.

Az alábbi példában az első dia (index 0) klónozva van, és a prezentáció végére kerül.

```py
import aspose.slides as slides

# Az Presentation osztály példányosítása a prezentációfájl reprezentálásához.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # A kívánt dia klónozása a dia gyűjtemény végére ugyanabban a prezentációban.
    presentation.slides.add_clone(presentation.slides[0])
    # A módosított prezentáció mentése lemezre.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klónozás meghatározott pozícióba ugyanabban a prezentációban**

Ha ugyanabban a prezentációban szeretne egy diát klónozni, és egy másik pozícióba helyezni, használja az `insert_clone` metódust:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezze be a dia gyűjteményt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumtól.
3. Hívja meg az `insert_clone` metódust a [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/), átadva a klónozandó diát és a cél indexet az új pozícióhoz.
4. Mentse el a módosított prezentációt.

Az alábbi példában az 1-es indexű dia (2. pozíció) klónozva van a 2-es indexre (3. pozíció) ugyanabban a prezentációban.

```py
import aspose.slides as slides

# Az Presentation osztály példányosítása a prezentációfájl reprezentálásához.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # A kívánt dia klónozása a megadott pozícióba (index) ugyanabban a prezentációban.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # A módosított prezentáció mentése lemezre.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klónozás egy másik bemutató végén**

Ha egy prezentációból szeretne egy diát klónozni, és egy másik prezentáció végére hozzáadni:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból a forrás prezentációhoz (amelyik a diát tartalmazza).
2. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból a cél prezentációhoz (ahová a diát hozzáadja).
3. Szerezze be a dia gyűjteményt a cél prezentációból.
4. Hívja meg az `add_clone` metódust a cél [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/), átadva a forrás prezentáció diáját.
5. Mentse el a módosított cél prezentációt.

Az alábbi példában a forrás prezentáció 0‑ás indexű diája a cél prezentáció végére kerül klónozva.

```py
import aspose.slides as slides

# Az Presentation osztály példányosítása a forrás prezentáció fájl reprezentálásához.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Az Presentation osztály példányosítása a cél PPTX-hez (ahová a diát klónozzák).
    with slides.Presentation() as target_presentation:
        # A kívánt dia klónozása a forrás prezentációból a cél prezentáció dia gyűjteményének végére.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # A cél prezentáció mentése lemezre.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klónozás egy meghatározott pozícióba egy másik prezentációban**

Ha egy prezentációból szeretne egy diát klónozni, és egy másik prezentáció meghatározott pozíciójába beilleszteni:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból a forrás prezentációhoz (amelyik a diát tartalmazza).
2. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból a cél prezentációhoz (ahová a diát hozzáadja).
3. Szerezze be a dia gyűjteményt a cél prezentációból.
4. Hívja meg az `insert_clone` metódust a cél [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/), átadva a forrás prezentáció diáját és a kívánt cél indexet.
5. Mentse el a módosított cél prezentációt.

Az alábbi példában a forrás prezentáció 0‑ás indexű diája a cél prezentáció 2‑es indexére (3. pozíció) kerül klónozva.

```py
import aspose.slides as slides

# A Presentation osztály példányosítása a forrás prezentáció fájl reprezentálásához.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # A Presentation osztály példányosítása a cél PPTX-hez (ahová a diát klónozni kell).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # A forrás első diájának klónjának beszúrása a cél prezentációban a 2-es indexre.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # A cél prezentáció mentése lemezre.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Dia klónozása a mesterdiával egy másik prezentációba**

Ha egy diát **a mesterdiával együtt** szeretne klónozni egy másik prezentációba, először klónozza a szükséges mesterdiát a forrás prezentációból a cél prezentációba. Ezután használja a cél mesterdiát a dia klónozásához. Az `add_clone(Slide, MasterSlide)` metódus **a cél prezentációból származó mesterdiát** várja, nem a forrásból.

A dia mesterdiával történő klónozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból a forrás prezentációhoz (amelyik a diát tartalmazza).
2. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból a cél prezentációhoz.
3. Szerezze be a forrás diát, amelyet klónozni szeretne, és annak mesterdiáját.
4. Szerezze be a [MasterSlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslidecollection/)‑t a cél prezentáció mestergyűjteményéből.
5. Hívja meg az `add_clone` metódust a cél [MasterSlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslidecollection/), átadva a forrás mastert, hogy azt a célba klónozza.
6. Szerezze be a [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/)‑t a cél prezentáció dia gyűjteményéből.
7. Hívja meg az `add_clone` metódust a cél [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/), átadva a forrás diát és a klónozott cél mastert.
8. Mentse el a módosított cél prezentációt.

Az alábbi példában a forrás prezentáció 0‑ás indexű diája a cél prezentáció végére kerül klónozva, a forrásból klónozott master használatával.

```py
import aspose.slides as slides

# A Presentation osztály példányosítása a forrás prezentáció fájl reprezentálásához.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # A Presentation osztály példányosítása a cél prezentációhoz, ahol a diát klónozni fogják.
    with slides.Presentation() as target_presentation:
        # A forrás prezentáció első diájának lekérése.
        source_slide = source_presentation.slides[0]
        # Az első dia által használt mesterdia lekérése.
        source_master = source_slide.layout_slide.master_slide
        # A mesterdia klónozása a cél prezentáció mestergyűjteményébe.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # A dia klónozása a forrás prezentációból a cél prezentáció végére a klónozott master használatával.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # A cél prezentáció mentése lemezre.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klónozás a végén egy meghatározott szekcióban**

Az Aspose.Slides for Python via .NET segítségével egy prezentáció egy szekciójából klónozhat egy diát, és egy másik szekcióba illesztheti be ugyanabban a prezentációban. Ehhez használja a `add_clone(Slide, Section)` metódust a [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/) osztályból.

Az alábbi Python példa bemutatja, hogyan klónozzon egy diát, és illessze be a klónt egy megadott szekcióba:

```py
import aspose.slides as slides

# Hozzon létre egy új üres bemutatót.
with slides.Presentation() as presentation:
    # Üres diát ad hozzá az első dia elrendezésére alapozva.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Adjon hozzá egy ellipszis alakzatot az új diához; ez a dia később klónozva lesz.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Egy másik üres diát ad hozzá az első dia elrendezésére alapozva.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Hozzon létre egy "Section2" nevű szekciót, amely a slide2-nél kezdődik.
    section = presentation.sections.add_section("Section2", slide2)
    # A korábban létrehozott diát a "Section2" szekcióba klónozza.
    presentation.slides.add_clone(slide, section)
    # A prezentáció mentése PPTX fájlként.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Biztosítsa a megfelelő diaméretet**

Dia klónozása során egy másik prezentációba fontos, hogy a cél prezentáció diamérete megegyezzen a forrásével. Ha a diaméretek eltérnek, az Aspose.Slides nem méretezi át automatikusan a klónozott alakzatokat – azok eredeti koordinátái és méretei megmaradnak, ami azt eredményezheti, hogy a tartalom eltolódik vagy a dia határain kívülre nyúlik.

A mester és a dia klónozása előtt állítsa be a cél prezentáció diaméretét a forráséval egyezőre:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Ezt a mester és a dia klónozása előtt végezze el.

## **GYIK**

### A hangjegyzetek és a lektorálási megjegyzések klónozódnak?

Igen. A jegyzetoldal és a lektorálási megjegyzések benne vannak a klónban. Ha nem szeretné őket, akkor [távolítsa el őket](/slides/hu/python-net/presentation-notes/) a beszúrás után.

### Hogyan kezelik a diagramokat és adatforrásaikat?

A diagramobjektum, a formázás és a beágyazott adatok másolva vannak. Ha a diagram egy külső forráshoz volt kapcsolva (például OLE‑beágyazott munkafüzethez), ez a kapcsolat megmarad [OLE objektumként](/slides/hu/python-net/manage-ole/). Fájlok közti áthelyezés után ellenőrizze az adatok elérhetőségét és a frissítési viselkedést.

### Beállíthatom a beszúrási pozíciót és a szekciókat a klón esetében?

Igen. A klónt beszúrhatja egy adott dia indexre, és egy kiválasztott [szekcióba](/slides/hu/python-net/slide-section/). Ha a cél szekció nem létezik, először hozza létre, majd mozgassa a diát abba.
