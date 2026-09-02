---
title: PowerPoint diák klónozása Pythonban
linktitle: Dia klónozása
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
description: "Klónozzon vagy duplikáljon gyorsan PowerPoint diákat az Aspose.Slides for Python via .NET segítségével. Kövesse világos kódpéldáinkat és tippjeinket, hogy néhány másodperc alatt automatizálja a PPT készítést, növelje a termelékenységet és megszüntesse a manuális munkát."
---
## **Bevezetés**

A klónozás egy pontos másolat vagy replikáció létrehozásának folyamata. Az Aspose.Slides lehetővé teszi, hogy bármely diát másoljon (klónozzon), majd a klónozott diát beillessze az aktuális bemutatóba vagy bármely más nyitott bemutatóba. A diaklónozás egy új diát hoz létre, amelyet a fejlesztők módosíthatnak anélkül, hogy az eredeti diát befolyásolnák. Többféle módja van egy dia klónozásának:

- Klónozás a bemutató végén.
- Klónozás a bemutatón belüli másik pozícióban.
- Klónozás egy másik bemutató végén.
- Klónozás egy másik bemutatóban egy másik pozícióban.
- Klónozás egy másik bemutatóban egy meghatározott pozícióban.

Az Aspose.Slides for Python via .NET-ben a [slide collection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/) amelyet a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektum exponál, biztosítja a `add_clone` és `insert_clone` metódusokat az ilyen típusú diaklónozáshoz.

## **Telepítés**

```bash
pip install aspose.slides
```

## **Klónozás a végén ugyanabban a bemutatóban**

Ha egy diát ugyanabban a bemutatóban szeretne klónozni, és a meglévő diák végéhez szeretné hozzáadni, használja a `add_clone` metódust. Kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezze meg a slide gyűjteményt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumból.
3. Hívja meg a `add_clone` metódust a [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/) objektumon, megadva a klónozandó diát.
4. Mentse a módosított bemutatót.

Az alábbi példában az első dia (index 0) kerül klónozásra, és a bemutató végéhez lesz hozzáadva.

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt a bemutató fájl reprezentálásához.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Klónozza a kívánt diát a diagyűjtemény végére ugyanabban a bemutatóban.
    presentation.slides.add_clone(presentation.slides[0])
    # Mentse a módosított bemutatót a lemezre.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klónozás egy meghatározott pozícióba ugyanabban a bemutatóban**

Ha egy diát ugyanabban a bemutatóban szeretne klónozni, és másik pozícióba helyezni, használja a `insert_clone` metódust:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezze meg a slide gyűjteményt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumból.
3. Hívja meg a `insert_clone` metódust a [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/) objektumon, megadva a klónozandó diát és a célt indexet az új pozícióhoz.
4. Mentse a módosított bemutatót.

Az alábbi példában az 1-es indexű dia (2. pozíció) klónozva van a 2-es indexre (3. pozíció) ugyanabban a bemutatóban.

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt a bemutató fájl reprezentálásához.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Klónozza a kívánt diát a megadott pozícióra (indexre) ugyanabban a bemutatóban.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Mentse a módosított bemutatót a lemezre.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klónozás egy másik bemutató végén**

Ha egy diát egy bemutatóból kell klónozni, és egy másik bemutató végéhez hozzáadni:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból a forrás bemutató számára (az, amely a klónozandó diát tartalmazza).
2. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból a cél bemutató számára (ahová a dia hozzá lesz adva).
3. Szerezze meg a slide gyűjteményt a cél bemutatóból.
4. Hívja meg a `add_clone` metódust a cél [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/) objektumon, megadva a forrás bemutató diát.
5. Mentse a módosított cél bemutatót.

Az alábbi példában a forrás bemutató 0-s indexű diáját a cél bemutató végére klónozzák.

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt a forrás bemutató fájl reprezentálásához.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Példányosítsa a Presentation osztályt a cél PPTX-hez (ahová a dia klónozva lesz).
    with slides.Presentation() as target_presentation:
        # Klónozza a kívánt diát a forrás bemutatóból a cél bemutató slide gyűjteményének végére.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Mentse a cél bemutatót a lemezre.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klónozás egy meghatározott pozícióba egy másik bemutatóban**

Ha egy diát egy bemutatóból kell klónozni, és egy másik bemutatóban egy meghatározott pozícióba beilleszteni:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból a forrás bemutató számára (amely a klónozandó diát tartalmazza).
2. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból a cél bemutató számára (ahová a dia hozzá lesz adva).
3. Szerezze meg a slide gyűjteményt a cél bemutatóból.
4. Hívja meg a `insert_clone` metódust a cél [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/) objektumon, megadva a forrás diát és a kívánt cél indexet.
5. Mentse a módosított cél bemutatót.

Az alábbi példában a forrás bemutató 0-s indexű diáját a cél bemutató 2-es indexére (3. pozíció) klónozzák.

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt a forrás bemutató fájl reprezentálásához.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Példányosítsa a Presentation osztályt a cél PPTX-hez (ahová a dia klónozandó).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Illessze be a forrás első diája klónját a cél bemutató 2. indexére.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Mentse a cél bemutatót a lemezre.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Dia és annak masterslajd klónozása egy másik bemutatóba**

Ha egy diát **a masterével** kell klónozni egy bemutatóból, és egy másikban használni, először klónozza a szükséges master diaslajt a forrás bemutatóból a cél bemutatóba. Ezután használja a cél mastert a dia klónozásakor. A `add_clone(Slide, MasterSlide)` metódus **a cél bemutató master diaslajdját** várja, nem a forrásét.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból a forrás bemutató számára (amely a klónozandó diát tartalmazza).
2. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból a cél bemutató számára.
3. Hozzáférhet a forrás diához, amelyet klónozni kell, és annak master diaslajdjához.
4. Szerezze meg a [MasterSlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslidecollection/) objektumot a cél bemutató master gyűjteményéből.
5. Hívja meg a `add_clone` metódust a cél [MasterSlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslidecollection/) objektumon, megadva a forrás mastert a célba való klónozáshoz.
6. Szerezze meg a [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/) objektumot a cél bemutató slide gyűjteményéből.
7. Hívja meg a `add_clone` metódust a cél [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/) objektumon, megadva a forrás diát és a klónozott cél mastert.
8. Mentse a módosított cél bemutatót.

Az alábbi példában a forrás bemutató 0-s indexű diáját a cél bemutató végére klónozzák a forrásból klónozott masterrel.

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt a forrás bemutató fájl reprezentálásához.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Példányosítsa a Presentation osztályt a cél bemutatóhoz, ahová a dia klónozva lesz.
    with slides.Presentation() as target_presentation:
        # Szerezze meg az első diát a forrás bemutatóból.
        source_slide = source_presentation.slides[0]
        # Szerezze meg az első dia által használt master diát.
        source_master = source_slide.layout_slide.master_slide
        # Klónozza a master diát a cél bemutató master gyűjteményébe.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Klónozza a diát a forrás bemutatóból a cél bemutató végére a klónozott masterrel.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Mentse a cél bemutatót a lemezre.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klónozás a végén egy meghatározott szekcióban**

Az Aspose.Slides for Python via .NET segítségével egy diát egy bemutató szekciójából klónozhat, és egy másik szekcióba illesztheti ugyanabban a bemutatóban. Ehhez használja a `add_clone(Slide, Section)` metódust a [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/) osztályban.

Az alábbi Python példa bemutatja, hogyan lehet egy diát klónozni és a klónt egy meghatározott szekcióba beszúrni:

```py
import aspose.slides as slides

# Hozzon létre egy új üres bemutatót.
with slides.Presentation() as presentation:
    # Adjon hozzá egy üres diát az első dia elrendezése alapján.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Adjon hozzá egy ellipszis alakzatot az új diához; ez a dia később klónozva lesz.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Adjon hozzá egy újabb üres diát az első dia elrendezése alapján.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Hozzon létre egy "Section2" nevű szekciót, amely a slide2-nél kezdődik.
    section = presentation.sections.add_section("Section2", slide2)
    # Klónozzuk az előzőleg létrehozott diát a "Section2" szekcióba.
    presentation.slides.add_clone(slide, section)
    # Mentse a bemutatót PPTX fájlként.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **A diaméret egyezésének biztosítása**

Diák másik bemutatóba történő klónozásakor győződjön meg arról, hogy a cél bemutató diamérete megegyezik a forrással. Ha a diaméretek eltérnek, az Aspose.Slides nem méretezi át automatikusan a klónozott alakzatokat – az eredeti koordinátáik és méreteik megmaradnak, ami a tartalom elcsúszásához vagy a dián kívülre nyúlásához vezethet.

Beállíthatja a cél bemutató diaméretét, hogy megegyezzen a forrással a master és a dia klónozása előtt:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Ezt a master és a dia klónozása előtt tegye meg.

## **GYIK**

**A beszédjegyzetek és a felülvizsgálati megjegyzések klónozódnak?**

Igen. A jegyzetoldal és a felülvizsgálati megjegyzések a klónba kerülnek. Ha nem kívánja őket, [távolítsa el őket](/slides/hu/python-net/presentation-notes/) a beillesztés után.

### Hogyan kezelik a diagramok és azok adatforrásait?

A diagram objektuma, formázása és a beágyazott adatok másolásra kerülnek. Ha a diagram külső forráshoz (például OLE-beágyazott munkafüzethez) volt csatolva, ez a kapcsolat egy [OLE objektum](/slides/hu/python-net/manage-ole/) formájában marad meg. Fájlok közti áthelyezés után ellenőrizze az adatok elérhetőségét és a frissítési viselkedést.

**Szabályozhatom a klón beszúrási pozícióját és szekcióját?**

Igen. A klón beilleszthető egy adott diaindexre, és elhelyezhető egy kiválasztott [szekcióban](/slides/hu/python-net/slide-section/). Ha a cél szekció nem létezik, először hozza létre, majd helyezze át a diát.
