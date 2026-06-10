---
title: PowerPoint diákok klónozása Pythonban
linktitle: Dia klónozása
type: docs
weight: 40
url: /hu/python-net/clone-slides/
keywords:
- dia klónozása
- dia másolása
- dia mentése
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Az Aspose.Slides for Python via .NET segítségével gyorsan klónozhat vagy megkettőzhet PowerPoint diákat. Kövesse a világos kódrészleteket és tippeket, hogy másodpercek alatt automatizálja a PPT létrehozását, növelje a termelékenységet, és megszüntesse a manuális munkát."
---
## **Bevezetés**

A klónozás egy pontos másolat vagy replikáció készítésének folyamata. Az Aspose.Slides lehetővé teszi, hogy bármely diát másoljon (klónozza), majd a klónozott diát beillesztse az aktuális prezentációba vagy bármely más nyitott prezentációba. A dia klónozása egy új diát hoz létre, amelyet a fejlesztők módosíthatnak anélkül, hogy az eredeti diát befolyásolnák. Többféle módon lehet klónozni egy diát:

- Klónozás a prezentáció végén.
- Klónozás egy másik pozícióban a prezentáción belül.
- Klónozás egy másik prezentáció végén.
- Klónozás egy másik pozícióban egy másik prezentációban.
- Klónozás egy adott pozícióban egy másik prezentációban.

Az Aspose.Slides for Python via .NET esetén a [dia gyűjtemény](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/) a [Prezentáció](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektum által biztosított `add_clone` és `insert_clone` metódusokat kínálja ezen dia klónozási típusok elvégzéséhez.

## **Klónozás a végén ugyanabban a prezentációban**

Ha egy diát szeretne klónozni ugyanabban a prezentációban, és a meglévő diák végére szeretné hozzáfűzni, használja az `add_clone` metódust. Kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezze be a dia gyűjteményt a [Prezentáció](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumból.
1. Hívja meg a `add_clone` metódust a [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/), a klónozandó diát átadva.
1. Mentse a módosított prezentációt.

Az alábbi példában az első dia (0. index) klónozva van, és a prezentáció végéhez fűzve.

```py
import aspose.slides as slides

# Példányosítja a Presentation osztályt a prezentációfájl reprezentálásához.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Klónozza a kívánt diát a dia gyűjtemény végére ugyanabban a prezentációban.
    presentation.slides.add_clone(presentation.slides[0])
    # Mentse a módosított prezentációt lemezre.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klónozás egy adott pozícióba ugyanabban a prezentációban**

Ha egy diát szeretne klónozni ugyanabban a prezentációban, és egy másik pozícióba helyezni, használja az `insert_clone` metódust:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezze be a dia gyűjteményt a [Prezentáció](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumból.
1. Hívja meg az `insert_clone` metódust a [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/), a klónozandó diát és a kívánt célt indexet az új pozícióhoz átadva.
1. Mentse a módosított prezentációt.

Az alábbi példában a 0. indexű dia (1. pozíció) klónozva van az 1. indexre (2. pozíció) ugyanabban a prezentációban.

```py
import aspose.slides as slides

# Példányosítja a Presentation osztályt a prezentációfájl képviseletére.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Klónozza a kívánt diát a megadott pozícióba (index) ugyanabban a prezentációban.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Mentse a módosított prezentációt lemezre.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klónozás egy másik prezentáció végén**

Ha egy diát szeretne klónozni egy prezentációból, és a másik prezentáció végére szeretné hozzáfűzni:

1. Hozzon létre egy [Prezentáció](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt a forrásprezentációhoz (az a prezentáció, amelyik a klónozandó diát tartalmazza).
1. Hozzon létre egy [Prezentáció](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt a célprezentációhoz (ahova a dia hozzáadódik).
1. Szerezze be a dia gyűjteményt a célprezentációból.
1. Hívja meg az `add_clone` metódust a cél [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/), a forrás prezentáció diáját átadva.
1. Mentse a módosított célprezentációt.

Az alábbi példában a forrás prezentáció 0. indexű diája klónozva van a célprezentáció végére.

```py
import aspose.slides as slides

# Példányosítja a Presentation osztályt a forrás prezentációfájl képviseletére.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Példányosítja a Presentation osztályt a cél PPTX-hez (ahová a dia klónozva lesz).
    with slides.Presentation() as target_presentation:
        # Klónozza a kívánt diát a forrás prezentációból a cél prezentáció dia gyűjteményének végére.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Mentse a cél prezentációt lemezre.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klónozás egy adott pozícióba egy másik prezentációban**

Ha egy diát szeretne klónozni egy prezentációból, és egy másik prezentációban egy adott pozícióba beszúrni:

1. Hozzon létre egy [Prezentáció](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt a forrásprezentációhoz (a dia, amit klónozni kívánja, tartalmazó prezentáció).
1. Hozzon létre egy [Prezentáció](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt a célprezentációhoz (ahova a dia hozzáadódik).
1. Szerezze be a dia gyűjteményt a célprezentációból.
1. Hívja meg az `insert_clone` metódust a cél [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/), a forrás diát és a kívánt célt indexet átadva.
1. Mentse a módosított célprezentációt.

Az alábbi példában a forrás prezentáció 0. indexű diája klónozva van az 1. indexre (2. pozíció) a célprezentációban.

```py
import aspose.slides as slides

# Példányosítja a Presentation osztályt a forrás prezentációfájl képviseletére.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Példányosítja a Presentation osztályt a cél PPTX-hez (ahová a dia klónozva lesz).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Beszúrja a forrás első diájának klónját a cél prezentáció 2. indexére.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Mentse a cél prezentációt lemezre.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Dia klónozása a mesterdiaival együtt egy másik prezentációba**

Ha egy diát **a mesterdiaival együtt** kell klónozni egy prezentációból, és egy másikban használni, először klónozza a szükséges mesterdiát a forrásprezentációból a célprezentációba. Ezután használja ezt a célmesterdiát a dia klónozásakor. Az `add_clone(Slide, MasterSlide)` metódus **a célprezentáció mesterdiáját** várja, nem a forrásét.

A dia mesterdiával együtt történő klónozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy [Prezentáció](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt a forrásprezentációhoz (a dia, amit klónozni kívánja, tartalmazó prezentáció).
2. Hozzon létre egy [Prezentáció](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt a célprezentációhoz.
3. Hozzáférés a forrás diashoz, amelyet klónozni kell, és annak mesterdiájához.
4. Szerezze be a [MasterSlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslidecollection/) a célprezentáció mestergyűjteményéből.
5. Hívja meg az `add_clone` metódust a cél [MasterSlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslidecollection/), a forrás mesterdiát átmásolva a célba.
6. Szerezze be a [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/) a célprezentáció dia gyűjteményéből.
7. Hívja meg az `add_clone` metódust a cél [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/), a forrás diát és a klónozott célmestert átadva.
8. Mentse a módosított célprezentációt.

Az alábbi példában a forrás prezentáció 0. indexű diája klónozva van a célprezentáció végére a forrásból klónozott mesterrel.

```py
import aspose.slides as slides

# Példányosítja a Presentation osztályt a forrás prezentációfájl képviseletére.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Példányosítja a Presentation osztályt a cél prezentációhoz, ahová a dia klónozva lesz.
    with slides.Presentation() as target_presentation:
        # Lekéri az első diát a forrás prezentációból.
        source_slide = source_presentation.slides[0]
        # Lekéri az első dia által használt mester diát.
        source_master = source_slide.layout_slide.master_slide
        # Klónozza a mester diát a cél prezentáció mestergyűjteményébe.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Klónozza a diát a forrás prezentációból a cél prezentáció végére a klónozott mesterrel.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Mentse a cél prezentációt lemezre.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klónozás a végén egy megadott szekcióban**

Az Aspose.Slides for Python via .NET segítségével egy diát klónozhat egy prezentáció egyik szekciójából, és egy másik szekcióba helyezhet ugyanabban a prezentációban. Ehhez használja a `add_clone(Slide, Section)` metódust a [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/) osztályon.

Az alábbi Python példa bemutatja, hogyan lehet egy diát klónozni, és a klónt egy megadott szekcióba beszúrni:

```py
import aspose.slides as slides

# Hozzon létre egy új üres prezentációt.
with slides.Presentation() as presentation:
    # Üres diát ad hozzá az első dia elrendezése alapján.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Ellipszis alakzatot ad hozzá az új diához; ez a dia később klónozva lesz.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Egy másik üres diát ad hozzá az első dia elrendezése alapján.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Létrehoz egy "Section2" nevű szekciót, amely a slide2-nél kezdődik.
    section = presentation.sections.add_section("Section2", slide2)
    # Klónozza a korábban létrehozott diát a "Section2" szekcióba.
    presentation.slides.add_clone(slide, section)
    # Mentse a prezentációt PPTX fájlként.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**A beszélői jegyzetek és értékelői megjegyzések klónozódnak?**

Igen. A jegyzetoldal és az értékelői megjegyzések a klón részei. Ha ezeket nem szeretné, [távolítsa el őket](/slides/hu/python-net/presentation-notes/) a beszúrás után.

**Hogyan kezelik a diagramokat és azok adatforrásait?**

A diagram objektuma, formázása és a beágyazott adatok másolásra kerülnek. Ha a diagram külső forráshoz volt kapcsolva (például OLE-beágyazott munkafüzethez), ez a kapcsolat [OLE objektumként](/slides/hu/python-net/manage-ole/) marad meg. Fájlok között történő áthelyezés után ellenőrizze az adatok elérhetőségét és a frissítési viselkedést.

**Szabályozhatom a klón beszúrási pozícióját és szekcióit?**

Igen. A klónt egy megadott dia indexen szúrhatja be, és egy kiválasztott [szekcióba](/slides/hu/python-net/slide-section/) helyezheti. Ha a cél szekció nem létezik, előbb hozza létre, majd mozgassa a diát bele.