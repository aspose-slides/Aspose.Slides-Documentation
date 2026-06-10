---
title: Diák hozzáadása prezentációkhoz Androidon
linktitle: Dia hozzáadása
type: docs
weight: 10
url: /hu/androidjava/add-slide-to-presentation/
keywords:
- dia hozzáadása
- dia létrehozása
- üres dia
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Könnyedén adhat hozzá diákat PowerPoint és OpenDocument prezentációihoz az Aspose.Slides for Android via Java használatával – zökkenőmentes, hatékony diabeillesztés másodpercek alatt."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi diák programozott hozzáadását PowerPoint prezentációkhoz. Egy prezentáció tartalmaz mester-/elrendezésdiasokat és normál diákat, a normál diákat nullától kezdődő index szerint rendezik. Minden diához egy egyedi azonosító tartozik, és a diáktól mentes prezentációs fájlok nem támogatottak.

Ez a cikk bemutatja, hogyan hozhatunk létre egy `Presentation` objektumot, hogyan érhetjük el a diakollekcióját, hogyan adhatunk hozzá egy üres diát, hogyan dolgozhatunk az újból hozzáadott diával, és hogyan menthetjük el a frissített prezentációt. Emellett tárgyalja a diák meghatározott pozícióba való beszúrását, az elrendezések használatát, valamint azt, hogy mi a "blank" dia egy úszólag létrehozott prezentációban.

## **Dia hozzáadása a prezentációhoz**

Mielőtt a diák prezentációs fájlokba történő hozzáadásáról beszélnénk, tekintsük át a diákról néhány tényt. Minden PowerPoint prezentációs fájl tartalmaz **Mester / Elrendezés** diát és egyéb **Normál** diákat. Ez azt jelenti, hogy egy prezentációs fájl legalább egy vagy több diát tartalmaz. Fontos tudni, hogy a diáktól mentes fájlok nem támogatottak az Aspose.Slides for Android via Java által. Minden diához egy egyedi azonosító tartozik, és az összes normál diát a nullától kezdődő index határozza meg.

Az Aspose.Slides for Android via Java lehetővé teszi a fejlesztők számára, hogy üres diákat adjanak a prezentációjukhoz. Egy üres dia hozzáadásához a prezentációban kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
- Példányosítsa az [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection) osztályt úgy, hogy hivatkozást ad a [Slides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) (tartalmi Slide objektumok gyűjteménye) tulajdonságra, amelyet a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) objektum biztosít.
- Adjon egy üres diát a prezentáció tartalmi diagyűjteményének végéhez az [**addEmptySlide**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) metódus hívásával, amelyet az [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection) objektum biztosít.
- Végezzen el némi műveletet az újból hozzáadott üres diával.
- Végül írja ki a prezentációs fájlt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) objektummal.

```java
// Példányosítsa a Presentation osztályt, amely a prezentációs fájlt képviseli
Presentation pres = new Presentation();
try {
    // Példányosítsa a SlideCollection osztályt
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Üres diát adjon a Slides gyűjteményhez
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Végrehajt némi műveletet az újból hozzáadott dián

    // Mentse a PPTX fájlt a lemezre
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **GYIK**

**Beszúrhatok egy új diát egy adott pozícióba, nem csak a végére?**

Igen. A könyvtár támogatja a diakollekciókat és a [insert](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) műveleteket, így a diát a kívánt indexre is beillesztheti, nem csak a végére.

**Megmaradnak a téma/stílusok egy elrendezésen alapuló dia hozzáadásakor?**

Igen. Egy elrendezés örökli a formázást a mesterétől, és az új dia az adott elrendezéstől és a hozzá tartozó mesztertől örökli a formázást.

**Melyik dia szerepel egy új „üres” prezentációban a diák hozzáadása előtt?**

Egy újonnan létrehozott prezentáció már tartalmaz egy üres diát, amelynek indexe nulla. Ez fontos szempont a beszúrási indexek számításakor.

**Hogyan válasszam ki a „megfelelő” elrendezést egy új diához, ha a mesternek sok lehetősége van?**

Általában válassza ki a [LayoutSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/layoutslide/) elemet, amely megfelel a kívánt szerkezetnek ([Cím és tartalom, Két tartalom, stb.](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidelayouttype/)). Ha ilyen elrendezés hiányzik, hozzáadhatja azt a mesterhez [/slides/hu/androidjava/slide-layout/] és aztán használhatja.