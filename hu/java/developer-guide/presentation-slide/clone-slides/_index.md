---
title: Dia klónozása Java-ban
linktitle: Dia klónozása
type: docs
weight: 35
url: /hu/java/clone-slides/
keywords:
- dia klónozása
- dia másolása
- dia mentése
- PowerPoint
- OpenDocument
- bemutató
- Java
- Aspose.Slides
description: "Gyorsan duplikálja a PowerPoint diákat az Aspose.Slides for Java segítségével. Kövesse a világos kódpéldáinkat, hogy másodpercek alatt automatizálja a PPT létrehozását és megszüntesse a kézi munkát."
---
## **Bevezetés**

A klónozás egy pontos másolat vagy replikáció létrehozásának folyamata. Az Aspose.Slides for Java lehetővé teszi, hogy bármely dia másolatát vagy klónját elkészítsük, majd azt beillesszük az aktuális vagy bármely más megnyitott bemutatóba. A dia klónozása során egy új dia jön létre, amelyet a fejlesztők módosíthatnak anélkül, hogy az eredeti diát érintenék. A dia klónozásának több lehetséges módja van:

- Klónozás a bemutató végén.
- Klónozás egy másik pozícióba a bemutatón belül.
- Klónozás egy másik bemutató végén.
- Klónozás egy másik pozícióba egy másik bemutatóban.
- Klónozás a mesterdiával együtt egy másik bemutatóba.

Az Aspose.Slides for Java‑ban a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) objektum által biztosított (az [ISlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlide) objektumok gyűjteménye) [ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) osztálya a [addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) és [insertClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metódusokkal teszi lehetővé a fenti dia klónozási típusok végrehajtását.

## **Dia klónozása a bemutató végén**
Ha egy diát klónozni szeretne, majd ugyanabban a bemutató fájlban az eredeti diák vége után használni, használja a [addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metódust az alábbi lépések szerint:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
1. Hozzon létre egy példányt a [ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) osztályból a [Presentation] objektum által biztosított Slides gyűjtemény hivatkozásával.  
1. Hívja meg az [addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metódust a [ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) objektumon, és adja át a klónozandó diát paraméterként.  
1. Írja ki a módosított bemutató fájlt.

Az alább látható példában egy diát (amely az első pozícióban – nulladik indexen – helyezkedik el) klónoztunk a bemutató végére.

```java
import com.aspose.slides.*;

// Presentation osztály példányosítása, amely egy bemutató fájlt képvisel
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Az adott dia klónozása a diák gyűjteményének végére ugyanabban a bemutatóban
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Módosított bemutató mentése lemezre
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Dia klónozása egy másik pozícióba egy bemutatón belül**
Ha egy diát klónozni szeretne, majd ugyanabban a bemutató fájlban egy másik helyen használni, használja a [insertClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metódust:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
1. Hozzon létre egy példányt a [Slides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) gyűjteményre hivatkozva a [Presentation] objektumon keresztül.  
1. Hívja meg az [insertClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metódust a [ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) objektumon, és adja át a klónozandó diát valamint az új pozíció indexét paraméterként.  
1. Írja ki a módosított bemutatót PPTX fájlként.

Az alább látható példában egy diát (amely a 1‑es indexen – 2‑es pozícióban – helyezkedik el) klónoztunk a 2‑es indexre – 3‑as pozícióba – a bemutatóban.

```java
import com.aspose.slides.*;

// Presentation osztály példányosítása, amely egy bemutató fájlt képvisel
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // A bemutató diák gyűjteményének lekérése
    ISlideCollection slds = pres.getSlides();

    // A kívánt dia klónozása a megadott indexre ugyanabban a bemutatóban
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // A módosított bemutató mentése lemezre
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Dia klónozása egy másik bemutató végén**
Ha egy diát egy bemutatóból egy másik bemutatóba szeretne klónozni, a meglévő diák végére:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból, amely a forrás bemutatót tartalmazza.  
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból, amely a célbemutatót tartalmazza.  
1. Hozzon létre egy [ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection) példányt a célbemutató [Slides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) gyűjteményére hivatkozva.  
1. Hívja meg az [addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metódust az [ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) objektumon, és adja át a forrásbemutatóból származó diát paraméterként.  
1. Írja ki a módosított célbemutató fájlt.

Az alább látható példában egy diát (a forrásbemutató első indexéről) klónoztunk a célbemutató végére.

```java
import com.aspose.slides.*;

// Presentation osztály példányosítása a forrás bemutató fájl betöltéséhez
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Presentation osztály példányosítása a cél PPTX-hez (ahol a diát klónozni kell)
    Presentation destPres = new Presentation();
    try {
        // A kívánt dia klónozása a forrás bemutatóból a cél bemutató diagyűjteményének végére
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // A cél bemutató mentése lemezre
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Dia klónozása egy másik pozícióba egy másik bemutatóban**
Ha egy diát egy bemutatóból egy másik bemutatóba szeretne klónozni, egy meghatározott pozícióba:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból, amely a forrás bemutatót tartalmazza.  
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból, amely a célbemutatót tartalmazza.  
1. Hozzon létre egy [ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) példányt a célbemutató Slides gyűjteményére hivatkozva.  
1. Hívja meg az [insertClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metódust az [ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) objektumon, és adja át a forrásbemutatóból származó diát valamint a kívánt pozíció indexét paraméterként.  
1. Írja ki a módosított célbemutató fájlt.

Az alább látható példában egy diát (a forrásbemutató nulladik indexéről) klónoztunk az 1‑es indexre (2‑as pozíció) a célbemutatóban.

```java
import com.aspose.slides.*;

// Presentation osztály példányosítása a forrás bemutató fájl betöltéséhez
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Presentation osztály példányosítása a cél PPTX-hez (ahol a diát klónozni kell)
    Presentation destPres = new Presentation();
    try {
        // A kívánt dia klónozása a forrás bemutatóból a cél bemutató megadott indexére
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // A cél bemutató mentése lemezre
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Dia klónozása a saját mesterdiájával együtt egy másik bemutatóba**
Ha egy diát a saját mesterdiájával együtt szeretne klónozni egy másik bemutatóba, először a kívánt mesterdiát kell a forrásbemutatóból a célbemutatóba klónozni. Ezután ezt a mesterdiát kell használni a dia klónozásához. A [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) metódus a célbemutató mesterdiáját várja, nem a forrásét. A dia mesterdiával való klónozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból, amely a forrásbemutatót tartalmazza.  
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból, amely a célbemutatót tartalmazza.  
1. Hozzáférés a klónozandó diához és annak mesterdiájához.  
1. Hozzon létre egy [IMasterSlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IMasterSlideCollection) példányt a célbemutató [Presentation] objektum által biztosított Masters gyűjteményre hivatkozva.  
1. Hívja meg az [addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metódust az [IMasterSlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IMasterSlideCollection) objektumon, és adja át a forrás PPTX‑ből származó mesterdiát paraméterként.  
1. Hozzon létre egy [ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) példányt a célbemutató Slides gyűjteményére hivatkozva.  
1. Hívja meg az [addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metódust az [ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) objektumon, és adja át a forrásbemutatóból származó diát valamint a mesterdiát paraméterként.  
1. Írja ki a módosított célbemutató fájlt.

Az alább látható példában egy diát a mesterdiával együtt (amely a forrásbemutató nulladik indexén helyezkedik el) klónoztunk a célbemutató végére a forrásdiától származó mesterdiát használva.

```java
import com.aspose.slides.*;

// Presentation osztály példányosítása a forrás bemutató fájl betöltéséhez
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Presentation osztály példányosítása a célbemutatóhoz (ahol a diát klónozni kell)
    Presentation destPres = new Presentation();
    try {
        // ISlide példányosítása a forrás bemutató diagyűjteményéből, valamint
        // a mesterdiával
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // A kívánt mesterdia klónozása a forrás bemutatóból a mesterek gyűjteményébe a
        // célbemutatóban
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = masters.addClone(SourceMaster);

        // A kívánt dia klónozása a forrás bemutatóból a kívánt mesterrel a
        // célbemutató diagyűjteményének végére
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);

        // A célbemutató mentése lemezre
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Dia klónozása egy meghatározott szakasz végén**
Ha egy diát klónozni szeretne, majd ugyanabban a bemutató fájlban egy másik szakaszban használni, használja a **[addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)** metódust, amelyet az **[ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection)** interfész biztosít. Az Aspose.Slides for Java lehetővé teszi, hogy egy diát az első szakaszból klónozzunk, majd a klónozott diát a második szakaszba illesszük be ugyanabban a bemutatóban.

Az alábbi kódrészlet bemutatja, hogyan lehet egy diát klónozni, és a klónozott diát egy meghatározott szakaszba beilleszteni.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);

    // A célbemutató mentése lemezre
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Győződjön meg a megfelelő diaméret egyezéséről**

Dia klónozása másik bemutatóba történő átvitelénél győződjön meg arról, hogy a célbemutató diamérete megegyezik a forráséval. Ha a diaméretek eltérnek, az Aspose.Slides nem méretezi át automatikusan a klónozott alakzatokat – az eredeti koordinátáik és méreteik megmaradnak, ami eltolódott vagy a dián kívül eső tartalomhoz vezethet.

Állítsa be a célbemutató diaméretét úgy, hogy az megegyezzen a forrással a mester és a dia klónozása előtt:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Ezt a mester és a dia klónozása előtt végezze el.

## **GYIK**

**A jegyzetek és a felülvizsgálati megjegyzések klónozódnak?**

Igen. A jegyzetoldal és a felülvizsgálati megjegyzések benne vannak a klónban. Ha nem kívánja őket, a beillesztés után [távolítsa el őket](/slides/hu/java/presentation-notes/).

**Hogyan kezelik a diagramokat és azok adatforrásait?**

A diagram objektuma, formázása és a beágyazott adatok másolásra kerülnek. Ha a diagram egy külső forráshoz (például egy OLE‑beágyazott munkafüzethez) volt csatolva, ez a kapcsolat [OLE objektum](/slides/hu/java/manage-ole/) formájában megmarad. A fájlok közti áthelyezés után ellenőrizze az adatok elérhetőségét és a frissítési viselkedést.

**Szabályozhatom a beillesztés pozícióját és a szakaszokat a klón számára?**

Igen. A klón beilleszthető egy adott diaindexre, és elhelyezhető egy kiválasztott [szakasz](/slides/hu/java/slide-section/)‑ban. Ha a cél szakasz nem létezik, először hozza létre, majd mozgassa a diát oda.