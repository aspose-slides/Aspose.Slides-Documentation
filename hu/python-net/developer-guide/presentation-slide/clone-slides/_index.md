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
description: "Gyorsan klónozz vagy másolj PowerPoint diákat az Aspose.Slides for Python via .NET segítségével. Kövesd a világos kódpéldáinkat és tippeket, hogy másodpercek alatt automatizáld a PPT létrehozását, növeld a termelékenységet, és megszüntesd a manuális munkát."
---
## **Bevezetés**

A klónozás egy pontos másolat vagy replikáció létrehozásának folyamata. Az Aspose.Slides lehetővé teszi, hogy bármely diát másolja (klónozza), majd a klónozott diát beillessze az aktuális előadásba vagy bármely más nyitott előadásba. A dia klónozása új diát hoz létre, amelyet a fejlesztők módosíthatnak anélkül, hogy az eredeti diát befolyásolnák. Számos módja van egy dia klónozásának:

- Klónozás egy előadás végén.
- Klónozás az előadás egy másik pozíciójában.
- Klónozás egy másik előadás végén.
- Klónozás egy másik előadás másik pozíciójában.
- Klónozás egy másik előadás egy meghatározott pozíciójában.

Az Aspose.Slides for Python via .NET-ben a [dia gyűjtemény](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/) a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektum által kibocsátva biztosítja a `add_clone` és `insert_clone` metódusokat e típusú dia klónozásokhoz.

## **Telepítés**

```bash
pip install aspose.slides
```

## **Klónozás a végén ugyanabban az előadásban**

Ha egy diát szeretnél klónozni ugyanabban az előadásban, és a meglévő diák végéhez hozzáadni, használd az `add_clone` metódust. Kövesd az alábbi lépéseket:

1. Hozz létre egy példányt a [Presentation] osztályból.
1. Szerezd meg a dia gyűjteményt a [Presentation] objektumtól.
1. Hívd meg az `add_clone` metódust a [SlideCollection] objektumon, átadva a klónozandó diát.
1. Mentsd el a módosított előadást.

Az alábbi példában az első dia (index 0) klónozódik és az előadás végéhez hozzáadódik.

```py
import aspose.slides as slides

# Példányosítsuk a Presentation osztályt a bemutató fájl képviseletére.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Klónozzuk a kívánt diát a diákkollekció végére ugyanabban a bemutatóban.
    presentation.slides.add_clone(presentation.slides[0])
    # Mentsük a módosított bemutatót a lemezre.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klónozás egy meghatározott pozícióba ugyanabban az előadásban**

Ha egy diát szeretnél klónozni ugyanabban az előadásban és egy másik pozícióba helyezni, használd az `insert_clone` metódust:

1. Hozz létre egy példányt a [Presentation] osztályból.
1. Szerezd meg a dia gyűjteményt a [Presentation] objektumtól.
1. Hívd meg az `insert_clone` metódust a [SlideCollection] objektumon, átadva a klónozandó diát és a cél indexet az új pozícióhoz.
1. Mentsd el a módosított előadást.

Az alábbi példában az 1-es indexű dia (2. pozíció) klónozódik a 2-es indexű (3. pozíció) helyre ugyanabban az előadásban.

```py
import aspose.slides as slides

# Példányosítsuk a Presentation osztályt a bemutató fájl képviseletére.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Klónozzuk a kívánt diát a megadott pozícióba (index) ugyanabban a bemutatóban.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Mentsük a módosított bemutatót a lemezre.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klónozás egy másik előadás végén**

Ha egy diát egy előadásból kell klónozni és egy másik előadás végéhez hozzáadni:

1. Hozz létre egy példányt a [Presentation] osztályból a forrás előadás számára (az a előadás, amelyik a diát tartalmazza).
1. Hozz létre egy példányt a [Presentation] osztályból a cél előadás számára (ahová a dia kerül).
1. Szerezd meg a dia gyűjteményt a cél előadásból.
1. Hívd meg a `add_clone` metódust a cél [SlideCollection] objektumon, átadva a forrás előadás diáját.
1. Mentsd el a módosított cél előadást.

Az alábbi példában a forrás előadás 0-s indexű diája klónozódik a cél előadás végére.

```py
import aspose.slides as slides

# Példányosítsuk a Presentation osztályt a forrás bemutató fájl képviseletére.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Példányosítsuk a Presentation osztályt a cél PPTX-hez (ahová a dia klónozva lesz).
    with slides.Presentation() as target_presentation:
        # Klónozzuk a kívánt diát a forrás bemutatóból a cél bemutató diákkollekciójának végére.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Mentsük a cél bemutatót a lemezre.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klónozás egy meghatározott pozícióba egy másik előadásban**

Ha egy diát egy előadásból kell klónozni és egy másik előadásba egy meghatározott pozícióba beilleszteni:

1. Hozz létre egy példányt a [Presentation] osztályból a forrás előadás számára (az a előadás, amelyik a diát tartalmazza).
1. Hozz létre egy példányt a [Presentation] osztályból a cél előadás számára (ahová a dia kerül).
1. Szerezd meg a dia gyűjteményt a cél előadásból.
1. Hívd meg az `insert_clone` metódust a cél [SlideCollection] objektumon, átadva a forrás előadás diáját és a kívánt cél indexet.
1. Mentsd el a módosított cél előadást.

Az alábbi példában a forrás előadás 0-s indexű diája a cél előadás 2-es indexű (3. pozíció) helyére klónozódik.

```py
import aspose.slides as slides

# Példányosítsuk a Presentation osztályt a forrás bemutató fájl képviseletére.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Példányosítsuk a Presentation osztályt a cél PPTX-hez (ahová a dia klónozandó).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Illesszük be a forrás első diájának klónját a cél bemutató 2-es indexére.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Mentsük a cél bemutatót a lemezre.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Dia klónozása a mesterével egy másik előadásba**

Ha egy diát **a mesterével** szeretnél klónozni egy előadásból és egy másikban használni, először klónozd a szükséges mester diát a forrás előadásból a cél előadásba. Ezután használd a cél mester diát a dia klónozásához. Az `add_clone(Slide, MasterSlide)` metódus **a cél előadás mester diáját** várja, nem a forrásét.

A dia mesterével való klónozásához kövesd az alábbi lépéseket:

1. Hozz létre egy példányt a [Presentation] osztályból a forrás előadás számára (az a előadás, amelyik a diát tartalmazza).
1. Hozz létre egy példányt a [Presentation] osztályból a cél előadás számára.
1. Érd el a klónozandó forrás diát és annak mester diáját.
1. Szerezd meg a [MasterSlideCollection]‑t a cél előadás mesterkollekciójából.
1. Hívd meg a `add_clone` metódust a cél [MasterSlideCollection] objektumon, átadva a forrás mestert, hogy klónozd a célba.
1. Szerezd meg a [SlideCollection]‑t a cél előadás dia gyűjteményéből.
1. Hívd meg a `add_clone` metódust a cél [SlideCollection] objektumon, átadva a forrás diát és a klónozott cél mestert.
1. Mentsd el a módosított cél előadást.

Az alábbi példában a forrás előadás 0-s indexű diája a cél előadás végéhez klónozódik a forrásból klónozott mester diával.

```py
import aspose.slides as slides

# Példányosítsuk a Presentation osztályt a forrás bemutató fájl képviseletére.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Példányosítsuk a Presentation osztályt a cél bemutató számára, ahová a dia klónozva lesz.
    with slides.Presentation() as target_presentation:
        # Szerezzük meg az első diát a forrás bemutatóból.
        source_slide = source_presentation.slides[0]
        # Szerezzük meg az első dia által használt mesterdiát.
        source_master = source_slide.layout_slide.master_slide
        # Klónozzuk a mesterdiát a cél bemutató mestergyűjteményébe.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Klónozzuk a diát a forrás bemutatóból a cél bemutató végére a klónozott mester használatával.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Mentsük a cél bemutatót a lemezre.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klónozás egy megadott szekció végén**

Az Aspose.Slides for Python via .NET segítségével egy diát egy előadás egyik szekciójából klónozhatsz és egy másik szekcióba illeszthetsz ugyanabban az előadásban. Ehhez használd az `add_clone(Slide, Section)` metódust a [SlideCollection] osztályon.

Az alábbi Python példa bemutatja, hogyan lehet egy diát klónozni és a klónt egy megadott szekcióba beilleszteni:

```py
import aspose.slides as slides

# Hozzunk létre egy új üres bemutatót.
with slides.Presentation() as presentation:
    # Adjunk hozzá egy üres diát az első dia elrendezése alapján.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Adjunk egy ellipszis alakzatot az új diához; ezt a diát később klónozni fogjuk.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Adjunk hozzá egy másik üres diát az első dia elrendezése alapján.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Hozzunk létre egy "Section2" nevű szekciót, amely a slide2-nél kezdődik.
    section = presentation.sections.add_section("Section2", slide2)
    # Klónozzuk az előzőleg létrehozott diát a "Section2" szekcióba.
    presentation.slides.add_clone(slide, section)
    # Mentsük a bemutatót PPTX fájlként.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

### A hangjegyzetek és a felülvizsgálati megjegyzések klónozódnak?

Igen. A jegyzetoldal és a felülvizsgálati megjegyzések is benne vannak a klónban. Ha nem szeretnéd őket, [távolítsd el őket](/slides/hu/python-net/presentation-notes/) a beillesztés után.

### Hogyan kezelik a diagramok és azok adatforrásait?

A diagram objektuma, formázása és a beágyazott adatok másolásra kerülnek. Ha a diagram külső forráshoz (például OLE-embedded munkafüzethez) volt kapcsolva, ez a kapcsolat egy [OLE objektum](/slides/hu/python-net/manage-ole/) formájában megmarad. Fájlok között a mozgatás után ellenőrizd az adatok elérhetőségét és a frissítési viselkedést.

### Lehet-e szabályozni a klón beillesztési pozícióját és szekcióit?

Igen. A klónt egy meghatározott dia indexre illesztheted, és egy kiválasztott [szekcióba](/slides/hu/python-net/slide-section/) helyezheted. Ha a cél szekció nem létezik, előbb hozd létre, majd mozdítsd a diát bele.