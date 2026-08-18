---
title: Prezentációs diák klónozása Androidon
linktitle: Diák klónozása
type: docs
weight: 35
url: /hu/androidjava/clone-slides/
keywords:
- dia klónozása
- dia másolása
- dia mentése
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Másolja a PowerPoint diákat az Aspose.Slides for Android segítségével. Kövesse egyszerű Java kódpéldáinkat a PPT készítés automatizálásához másodpercek alatt, és szabaduljon meg a manuális munkától."
---
## **Bevezetés**

A klónozás egy adott dolog pontos másolatának vagy replikájának elkészítése. Az Aspose.Slides for Android via Java lehetővé teszi, hogy bármely diát lemásoljon vagy klónozzon, majd ezt a klónozott diát beillessze az aktuális vagy bármely más megnyitott prezentációba. A dia klónozási folyamata új diát hoz létre, amelyet a fejlesztők módosíthatnak az eredeti dia megváltoztatása nélkül. A dia klónozásának több lehetséges módja van:

- Klón a prezentáció végén.
- Klón egy másik pozícióban a prezentáción belül.
- Klón a végén egy másik prezentációban.
- Klón egy másik pozícióban egy másik prezentációban.
- Klón egy meghatározott pozícióban egy másik prezentációban.

Az Aspose.Slides for Android via Java (az [ISlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlide) objektumok gyűjteménye) a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) objektum által biztosítja a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) és [insertClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metódusokat a fentiek szerinti dia klónozásához.

## **Dia klónozása a prezentáció végén**
Ha egy diát klónozni szeretne, és azt ugyanabban a prezentációs fájlban a meglévő diák végére szeretné elhelyezni, használja a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metódust a lenti lépések szerint:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
1. Példányosítsa az [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) osztályt a [Presentation] objektum által kiadott Slides gyűjtemény hivatkozásával.
1. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metódust az [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) objektumon, és adja át a klónozandó diát a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metódus paramétereként.
1. Írja ki a módosított prezentációfájlt.

Az alábbi példában a prezentáció első pozíciójában (nulla index) lévő diát klónoztuk a prezentáció végére.

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Klónozza a kívánt diát a ugyanabban a prezentációban lévő diák gyűjteményének végére
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Írja a módosított prezentációt a lemezre
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Dia klónozása egy másik pozícióba a prezentáción belül**
Ha egy diát klónozni szeretne, és ugyanabban a prezentációs fájlban, de más pozícióban szeretné használni, használja a [insertClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metódust:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
1. Példányosítsa az osztályt a [**Slides**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) gyűjteményre hivatkozva, amelyet a [Presentation] objektum biztosít.
1. Hívja meg a [insertClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metódust az [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) objektumon, és adja át a klónozandó diát a kívánt új pozíció indexével együtt a [insertClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metódus paramétereként.
1. Írja ki a módosított prezentációt PPTX fájlként.

Az alábbi példában a prezentáció második pozíciójában (index 1) lévő diát klónoztuk a harmadik pozícióba (index 2).

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Szerezze meg a diák gyűjteményét ugyanabban a prezentációban
    ISlideCollection slds = pres.getSlides();

    // Klónozza a kívánt diát a megadott indexre ugyanabban a prezentációban
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Írja a módosított prezentációt a lemezre
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Dia klónozása egy másik prezentáció végén**
Ha egy diát egy prezentációból kell klónozni, és egy másik prezentáció fájlba a meglévő diák végére szeretné elhelyezni:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból, amely a forrás prezentációt tartalmazza.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból, amely a cél prezentációt tartalmazza, ahová a diát fel kell venni.
1. Példányosítsa az [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection) osztályt a cél prezentáció [**Slides**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) gyűjteményére hivatkozva.
1. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metódust az [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) objektumon, és adja át a forrás prezentációból származó diát a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metódus paramétereként.
1. Írja ki a módosított cél prezentációfájlt.

Az alábbi példában a forrás prezentáció első indexében lévő diát klónoztuk a cél prezentáció végére.

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt a forrás prezentációs fájl betöltéséhez
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Példányosítsa a Presentation osztályt a cél PPTX-hez (ahová a dia klónozva lesz)
    Presentation destPres = new Presentation();
    try {
        // Klónozza a kívánt diát a forrás prezentációból a cél prezentáció diagyűjteményének végére
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Írja a cél prezentációt a lemezre
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Dia klónozása egy másik pozícióba egy másik prezentációban**
Ha egy diát egy prezentációból kell klónozni, és azt egy másik prezentáció fájlba egy meghatározott pozícióban szeretné elhelyezni:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból, amely a forrás prezentációt tartalmazza.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból, amely a cél prezentációt tartalmazza.
1. Példányosítsa az [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) osztályt a cél prezentáció Slides gyűjteményére hivatkozva.
1. Hívja meg a [insertClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metódust az [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) objektumon, és adja át a forrás prezentációból származó diát a kívánt pozícióval együtt a [insertClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metódus paramétereként.
1. Írja ki a módosított cél prezentációfájlt.

Az alábbi példában a forrás prezentáció nulla indexében lévő diát klónoztuk a cél prezentáció második pozíciójába (index 1).

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt a forrás prezentációs fájl betöltéséhez
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Példányosítsa a Presentation osztályt a cél PPTX-hez (ahová a diát klónozni kell)
    Presentation destPres = new Presentation();
    try {
        // Klónozza a kívánt diát a forrás prezentációból a cél prezentációban megadott indexre
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Írja a cél prezentációt a lemezre
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Dia klónozása egy meghatározott pozícióban egy másik prezentációban**
Ha egy diát master diapozícióval szeretne klónozni egy prezentációból egy másikba, először a kívánt masterdiát kell klónozni a forrás prezentációból a cél prezentációba. Ezután ezt a masterdiát kell használni a masterrel rendelkező dia klónozásához. A [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) metódus a cél prezentációból származó masterdiát várja, nem a forrásból. A masterrel rendelkező dia klónozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból, amely a forrás prezentációt tartalmazza.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból, amely a cél prezentációt tartalmazza.
1. Hozzáférés a klónozandó diához és a hozzá tartozó masterdiához.
1. Példányosítsa az [IMasterSlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IMasterSlideCollection) osztályt a cél prezentáció [Presentation] objektuma által kiadott Masters gyűjteményre hivatkozva.
1. Hívja meg az [IMasterSlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IMasterSlideCollection) objektumon a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metódust, és adja át a forrás PPTX-ből származó masterdiát a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metódus paramétereként.
1. Példányosítsa az [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) osztályt a cél prezentáció [Presentation] objektuma által kiadott Slides gyűjteményre mutatva.
1. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metódust az [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) objektumon, és adja át a forrás prezentációból származó diát és a masterdiát a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metódus paramétereként.
1. Írja ki a módosított cél prezentációfájlt.

Az alábbi példában a forrás prezentáció nulla indexében lévő masterrel rendelkező diát klónoztuk a cél prezentáció végére a forrás diából származó masterrel.

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt a forrás prezentáció betöltéséhez
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Példányosítsa a Presentation osztályt a cél prezentációhoz (ahová a diát klónozni kell)
    Presentation destPres = new Presentation();
    try {
        // Példányosítson ISlide‑t a forrás prezentáció diagyűjteményéből
        // Master diával együtt
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klónozza a kívánt masterdiát a forrás prezentációból a mastergyűjteménybe a
        // Cél prezentációban
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Klónozza a kívánt diát a forrás prezentációból a kívánt masterrel a végére a
        // Cél prezentáció diagyűjteményének
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Mentse a cél prezentációt a lemezre
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Dia klónozása egy meghatározott szekció végén**
Ha egy diát klónozni szeretne, majd azt ugyanabban a prezentációs fájlban egy másik szekcióban szeretné elhelyezni, használja a [**addClone**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) metódust az [**ISlideCollection**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection) interfészen keresztül. Az Aspose.Slides for Android via Java lehetővé teszi, hogy egy diát az első szekcióból klónozzunk, majd ezt a klónozott diát a második szekcióba illesszük be ugyanabban a prezentációban.

Az alábbi kódrészlet megmutatja, hogyan klónozhat egy diát, és illesztheti a klónozott diát egy meghatározott szekcióba.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
    // Mentse a cél prezentációt a lemezre
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Biztosítsa a megfelelő dia méretet**

Dia klónozása másik prezentációba történő áthelyezésekor ellenőrizze, hogy a cél prezentáció dia mérete megegyezik-e a forráséval. Ha a dia méretek eltérnek, az Aspose.Slides nem méretezi át automatikusan a klónozott alakzatokat – az eredeti koordináták és méretek megmaradnak, ami azt eredményezheti, hogy a tartalom eltolódik vagy a dia határain kívül jelenik meg.

A master és a dia klónozása előtt állítsa be a cél prezentáció dia méretét, hogy megfeleljen a forráséval:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Ezt a master és a dia klónozása előtt tegye meg.

## **GYIK**

**A felhasználói jegyzetek és a recenziós megjegyzések klónozódnak?**

Igen. A jegyzetoldal és a recenziós megjegyzések részei a klónnak. Ha nem szeretné őket, [távolítsa el őket](/slides/hu/androidjava/presentation-notes/) a beillesztés után.

**Hogyan kezelik a diagramokat és azok adatforrásait?**

A diagramobjektum, a formázás és a beágyazott adatok másolásra kerülnek. Ha a diagram külső forrásra (például egy OLE-beágyazott munkafüzetre) hivatkozott, ez a kapcsolat OLE‑objektumként ([OLE object](/slides/hu/androidjava/manage-ole/)) marad meg. A fájlok közötti áthelyezés után ellenőrizze az adatok elérhetőségét és a frissítési viselkedést.

**Ellenőrizhetem a klón beillesztési pozícióját és szekcióit?**

Igen. A klónt egy adott diaindexhez illesztheti, és egy kiválasztott [szekcióba](/slides/hu/androidjava/slide-section/) helyezheti. Ha a cél szekció nem létezik, először hozza létre, majd mozgassa a diát bele.