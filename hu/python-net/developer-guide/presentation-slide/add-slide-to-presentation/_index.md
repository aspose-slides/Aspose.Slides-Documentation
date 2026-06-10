---
title: Diák hozzáadása prezentációkhoz Pythonban
linktitle: Dia hozzáadása
type: docs
weight: 10
url: /hu/python-net/add-slide-to-presentation/
keywords:
- dia hozzáadása
- dia létrehozása
- üres dia
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Könnyedén adjon hozzá diákat PowerPoint és OpenDocument prezentációihoz az Aspose.Slides for Python via .NET segítségével – zökkenőmentes, hatékony diabeillesztés másodpercek alatt."
---
## **Áttekintés**

Mielőtt diákat adna hozzá egy bemutatóhoz, hasznos megérteni, hogyan szervezi azokat a PowerPoint. Minden bemutató egy mesterdiát, opcionális elrendezésdíákat és egy vagy több normál diát tartalmaz. Minden diához egy egyedi azonosító tartozik, és a normál diákat nullától kezdődő index szerint rendezzük. Ez a cikk bemutatja, hogyan használja az Aspose.Slides for Python könyvtárat diák létrehozásához és a megfelelő elrendezések kiválasztásához.

## **Diák hozzáadása a bemutatókhoz**

Az Aspose.Slides lehetővé teszi új diák hozzáfűzését a meglévő elrendezésdíák alapján. Az alábbi példa végigiterál a bemutató minden elrendezésén, hozzáad egy olyan diát, amely ezt az elrendezést használja, majd elmenti a fájlt.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Hozzáférés a [SlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/) osztályhoz.
1. Az `presentation.layout_slides` minden elemére hívja a `add_empty_slide` metódust, hogy hozzáfűzzön egy olyan diát, amely ezt az elrendezést használja.
1. Opcionálisan módosíthatja az újonnan hozzáadott diát.
1. Mentse a bemutatót PPTX fájlként.

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt.
with slides.Presentation() as presentation:
    # Hozzáférés a dia gyűjteményéhez.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Üres dia hozzáadása a dia gyűjteményéhez.
        slides.add_empty_slide(layout_slide)

    # Végezzen némi munkát az újonnan hozzáadott diákon.

    # Mentse a prezentációt a lemezre.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Beszúrhatok egy új diát egy adott pozícióba, nem csak a végére?**  
Igen. A könyvtár támogatja a diakollekciókat és a [insert](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/insert_clone/) műveleteket, így a diát a kívánt indexen adhatja hozzá, nem csak a végén.

**Megmaradnak a téma/stílusok, ha egy elrendezés alapján adunk hozzá egy diát?**  
Igen. Az elrendezés örökli a formázást a mesterétől, és az új dia a kiválasztott elrendezéstől és annak kapcsolódó mesterétől örököl.

**Melyik dia található egy új „üres” bemutatóban a diák hozzáadása előtt?**  
Egy újonnan létrehozott bemutató már tartalmaz egy üres dia a 0-s indexszel. Ez fontos szem előtt tartani a beszúrási indexek számításakor.

**Hogyan válasszam ki a „megfelelő” elrendezést egy új diához, ha a mesternek sok lehetősége van?**  
Általában válassza ki a [LayoutSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/) elemet, amely megfelel a szükséges struktúrának ([Title and Content, Two Content, stb.](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidelayouttype/)). Ha ez az elrendezés hiányzik, hozzáadhatja a mesterhez a [hozzáadni a mesterhez](/slides/hu/python-net/slide-layout/) lehetőséggel, majd használhatja.