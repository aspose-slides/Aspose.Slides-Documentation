---
title: Prezentációs diák klónozása Pythonban
linktitle: Diák klónozása
type: docs
weight: 35
url: /hu/python-java/clone-slides/
keywords:
- dia klónozása
- dia másolása
- dia mentése
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Gyorsan duplikálja a PowerPoint diákat az Aspose.Slides for Python via Java segítségével. Kövesse egyértelmű kódpéldáinkat, hogy másodpercek alatt automatizálja a PPT létrehozását és megszüntesse a manuális munkát."
---
## **Bevezetés**

Klónozás az a folyamat, amelynek során egy pontos másolat vagy replikát készítünk valamiről. Az Aspose.Slides for Python via Java lehetővé teszi, hogy bármely diát lemásoljunk vagy klónozzunk, majd a klónozott diát beillesszük a jelenlegi prezentációba vagy egy másik nyitott prezentációba. A diaklónozás folyamata egy új diát hoz létre, amelyet a fejlesztők módosíthatnak az eredeti dia megváltoztatása nélkül. Számos lehetséges módja van egy dia klónozásának:

- Klónozás a prezentáció végén.
- Klónozás egy másik pozícióban a prezentáción belül.
- Klónozás a végén egy másik prezentációban.
- Klónozás egy másik pozícióban egy másik prezentációban.
- Klónozás a saját fődiájával együtt egy másik prezentációba.

Aspose.Slides for Python via Java esetén a dia gyűjtemény (a [Slide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/) objektumok gyűjteménye), amelyet a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektum tesz elérhetővé, tartalmazza a [addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addClone) és a [insertClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#insertClone) metódusokat a fenti diaklónozási típusok végrehajtásához.

## **Dia klónozása a prezentáció végén**

Ha egy diát szeretne klónozni, és azt ugyanabban a prezentációfájlban a meglévő diák végén használni, használja a [addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addClone) metódust az alábbi lépések szerint:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Szerezze be a [SlideCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/) objektumot a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektum által biztosított Slides gyűjtemény hivatkozásával.
3. Hívja meg a [SlideCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/) objektum által biztosított [addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addClone) metódust, és adja meg a klónozandó diát paraméterként a [addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addClone) metódusnak.
4. Írja ki a módosított prezentációfájlt.

A lenti példában egy diát (ami a prezentáció első pozíciójában – nulla indexen – helyezkedik) klónoztunk a prezentáció végére.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # A kívánt dia klónozása a ugyanabban a prezentációban a diák gyűjteményének végére
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # A módosított prezentáció írása lemezre
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dia klónozása egy másik pozícióba a prezentáción belül**

Ha egy diát szeretne klónozni, és ugyanabban a prezentációfájlban, de egy másik pozícióban használni, használja a [insertClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#insertClone) metódust:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Kapjon hivatkozást a [getSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSlides) által visszaadott diagyűjteményre a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektumon.
3. Hívja meg a [SlideCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/) objektum által biztosított [insertClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#insertClone) metódust, és adja át a klónozandó diát a kívánt új pozíció indexével együtt paraméterként a [insertClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#insertClone) metódusnak.
4. Írja ki a módosított prezentációt PPTX fájlként.

A lenti példában egy diát (ami az index 1 – pozíció 2 – helyen van a prezentációban) klónoztunk az index 2 – pozíció 3 – helyre a prezentációban.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt reprezentál
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # Szerezze meg a prezentáció diáinak gyűjteményét
    slides = presentation.getSlides()

    # Klónozza a kívánt diát a megadott indexre ugyanabban a prezentációban
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # Írja a módosított prezentációt a lemezre
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dia klónozása egy másik prezentáció végén**

Ha egy diát egy prezentációból kell klónozni, és egy másik prezentációfájlban, a meglévő diák végén használni:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt, amely tartalmazza azt a prezentációt, amelyből a dia klónozva lesz.
2. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt, amely tartalmazza a célprezentációt, amelyhez a diát hozzá kell adni.
3. Szerezze be a [SlideCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/) objektumot a célprezentáció [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektumán a [getSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSlides) által visszaadott diagyűjtemény hivatkozásával.
4. Hívja meg a [SlideCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/) objektum által biztosított [addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addClone) metódust, és adja át a forrásprezentációból származó diát paraméterként a [addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addClone) metódusnak.
5. Írja ki a módosított célprezentáció fájlt.

Az alábbi példában egy diát (a forrásprezentáció 0. indexéről) klónoztunk a célprezentáció végére.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# A Presentation osztály példányosítása a forrás prezentációs fájl betöltéséhez
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # A Presentation osztály példányosítása a cél PPTX-hez (ahová a diát klónozni kell)
    destination_presentation = Presentation()
    try:
        # A kívánt dia klónozása a forrás prezentációból a célprezentáció diagyűjteményének végére
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # A célprezentáció írása lemezre
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Dia klónozása egy másik pozícióba egy másik prezentációban**

Ha egy diát egy prezentációból kell klónozni, és egy másik prezentációfájlban, egy meghatározott pozícióban használni:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt, amely tartalmazza a forrásprezentációt, amelyből a dia klónozva lesz.
2. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt, amely tartalmazza azt a prezentációt, amelyhez a diát hozzá kell adni.
3. Szerezze be a [SlideCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/) objektumot a célprezentáció [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektumának a Slides gyűjteményére hivatkozva.
4. Hívja meg a [SlideCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/) objektum által biztosított [insertClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#insertClone) metódust, és adja át a forrásprezentációból származó diát a kívánt pozícióval együtt paraméterként az [insertClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#insertClone) metódusnak.
5. Írja ki a módosított célprezentáció fájlt.

A lenti példában egy diát (a forrásprezentáció nulla indexéről) klónoztunk az index 1 (pozíció 2) helyre a célprezentációban.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# A Presentation osztály példányosítása a forrás prezentációs fájl betöltéséhez
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # A Presentation osztály példányosítása a cél PPTX-hez (ahová a diát klónozni kell)
    destination_presentation = Presentation()
    try:
        # Klónozza a kívánt diát a forrás prezentációból a célprezentáció megadott indexére
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # A célprezentáció írása lemezre
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Dia és annak fődiájának klónozása egy másik prezentációba**

Ha egy diát a hozzá tartozó fődiájával kell klónozni egy prezentációból, és egy másik prezentációban használni, először a kívánt fődiát kell klónozni a forrásprezentációból a célprezentációba. Ezután a klónozott fődiát használja a dia klónozásakor. A [addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addClone) metódus a célprezentáció fődiáját várja, nem a forrásprezentációét. A dia fődiával való klónozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt, amely tartalmazza a forrásprezentációt, amelyből a dia klónozva lesz.
2. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt, amely tartalmazza a célprezentációt, amelyhez a diát klónozni kell.
3. Férjen hozzá a klónozandó diához és annak fődiájához.
4. Szerezze be a [MasterSlideCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslidecollection/) objektumot a célprezentáció [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektumának a Masters gyűjteményére hivatkozva.
5. Hívja meg a [MasterSlideCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslidecollection/) objektum által biztosított [addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslidecollection/#addClone) metódust, és adja át a forrás PPTX-ből származó klónozandó fődiát paraméterként a [addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslidecollection/#addClone) metódusnak.
6. Szerezze be a [SlideCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/) objektumot a célprezentáció [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektumának a Slides gyűjteményére hivatkozva.
7. Hívja meg a [SlideCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/) objektum által biztosított [addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addClone) metódust, és adja át a forrásprezentációból származó klónozandó diát és a fődiát paraméterként a [addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addClone) metódusnak.
8. Írja ki a módosított célprezentáció fájlt.

A lenti példában egy diát a saját fődiájával (a forrásprezentáció nulla indexén) klónoztunk a célprezentáció végére a forrásdia fődiájának használatával.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Példányosítsa a Presentation osztályt a forrás prezentációs fájl betöltéséhez
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # Példányosítsa a Presentation osztályt a célprezentációhoz (ahová a diát klónozni kell)
    destination_presentation = Presentation()
    try:
        # Példányosítsa a diát a forrás prezentáció diagyűjteményéből, valamint
        # Fődia
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # Klónozza a kívánt fődiát a forrás prezentációból a
        # Célprezentáció master-gyűjteményébe
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # Klónozza a kívánt diát a forrás prezentációból a kívánt fődiával a
        # célprezentáció diagyűjteményének végére
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # Mentse a célprezentációt a lemezre
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Dia klónozása egy meghatározott szekció végén**

Ha egy diát szeretne klónozni, és ugyanabban a prezentációfájlban, de egy másik szekcióban használni, akkor használja a [**addClone**](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addClone) metódust, amelyet a [**SlideCollection**](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/) osztály biztosít. Az Aspose.Slides for Python via Java lehetővé teszi egy dia klónozását az első szekcióból, majd a klónozott dia beillesztését a ugyanazon prezentáció második szekciójába.

Az alábbi kódrészlet megmutatja, hogyan klónozzon egy diát, és helyezze be a klónozott diát egy meghatározott szekcióba.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # Mentse a célprezentációt a lemezre
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Győződjön meg a dia méretének egyezéséről**

Dia klónozása során egy másik prezentációba győződjön meg arról, hogy a célprezentáció dia mérete megegyezik a forráséval. Ha a dia méretek eltérnek, az Aspose.Slides nem méretezi át automatikusan a klónozott alakzatokat – az eredeti koordináták és méretek megmaradnak, ami azt eredményezheti, hogy a tartalom eltolódik vagy a dia határain kívülre nyúlik.

A célprezentáció dia méretét a klónozás előtt beállíthatja, hogy megegyezzen a forráséval, a fődia és a dia klónozása előtt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

Ezt a fődia és a dia klónozása előtt tegye meg.

## **GYIK**

**A hangjegyzetek és a recenziós megjegyzések is klónozódnak?**  
Igen. A jegyzetoldal és a recenziós megjegyzések benne vannak a klónban. Ha nem kívánja őket, [távolítsa el őket](/slides/hu/python-java/presentation-notes/) a beillesztés után.

**Hogyan kezelik a diagramokat és azok adatforrásait?**  
A diagram objektuma, formázása és beágyazott adatai másolásra kerülnek. Ha a diagram egy külső forráshoz (például egy OLE-beágyazott munkafüzethez) volt kapcsolva, ez a kapcsolat [OLE objektumként](/slides/hu/python-java/manage-ole/) megmarad. Fájlok közti áthelyezés után ellenőrizze az adatok elérhetőségét és a frissítési viselkedést.

**Szabályozhatom a klón beszúrási pozícióját és szekcióit?**  
Igen. A klón beszúrható egy adott dia indexnél, és elhelyezhető egy kiválasztott [szekcióba](/slides/hu/python-java/slide-section/). Ha a cél szekció nem létezik, előbb hozza létre, majd helyezze át a diát oda.