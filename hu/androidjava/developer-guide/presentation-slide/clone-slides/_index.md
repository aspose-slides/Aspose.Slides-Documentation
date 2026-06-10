---
title: "Prezentációs diák klónozása Androidon"
linktitle: "Diák klónozása"
type: docs
weight: 35
url: /hu/androidjava/clone-slides/
keywords:
  - "diák klónozása"
  - "diák másolása"
  - "diák mentése"
  - "PowerPoint"
  - "OpenDocument"
  - "prezentáció"
  - "Android"
  - "Java"
  - "Aspose.Slides"
description: "PowerPoint diákat duplikál az Aspose.Slides for Android segítségével. Kövesse világos Java kódpéldéinket, hogy másodpercek alatt automatizálja a PPT létrehozását, és megszüntesse a kézi munkát."
---
## **Bevezetés**

A klónozás az a folyamat, amely egy pontos másolat vagy replikát készít valamelyik dologból. Az Aspose.Slides for Android via Java lehetővé teszi, hogy bármely dia másolatát vagy klónját létrehozzuk, majd azt a klónozott diát beillesszük az aktuális vagy bármely más megnyitott prezentációba. A dia klónozása egy új diát hoz létre, amelyet a fejlesztők módosíthatnak anélkül, hogy az eredeti diát megváltoztatnák. Számos lehetséges módja van egy dia klónozásának:

- Klónozás a prezentáció végén.
- Klónozás egy másik pozícióba a prezentáción belül.
- Klónozás egy másik prezentáció végén.
- Klónozás egy másik pozícióba egy másik prezentációban.
- Klónozás egy meghatározott pozícióba egy másik prezentációban.

Az Aspose.Slides for Android via Java, (a [ISlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlide) objektumok gyűjteménye) amelyet a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) objektum biztosít, a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) és [insertClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metódusokat kínálja a fenti dia klónozási típusok végrehajtásához.

## **Dia klónozása a prezentáció végén**
Ha klónozni szeretne egy diát, majd ugyanabban a prezentációs fájlban a meglévő diák végén szeretné használni, használja a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metódust az alábbi lépések szerint:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
1. Hozzon létre egy példányt a [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) osztályból a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) objektum által szolgáltatott Slides gyűjtemény hivatkozásával.
1. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metódust a [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) objektumnál, és adja meg a klónozandó diát paraméterként a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metódusnak.
1. Írja ki a módosított prezentációs fájlt.

Az alább bemutatott példában a prezentáció első pozíciójában (nulla index) található diát klónoztuk a prezentáció végére.

```java
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Klónozza a kívánt diát a ugyanabban a prezentációban lévő diákkollekció végére
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Írja ki a módosított prezentációt a lemezre
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Dia klónozása egy másik pozícióba a prezentáción belül**
Ha klónozni szeretne egy diát, majd ugyanabban a prezentációs fájlban, de egy másik pozícióban szeretné használni, használja a [insertClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metódust:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
1. Hozzon létre egy példányt a [**Slides**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) gyűjtemény hivatkozásával, amelyet a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) objektum szolgáltat.
1. Hívja meg a [insertClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metódust a [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) objektumnál, és adja meg a klónozandó diát a kívánt új pozíció indexével együtt paraméterként a [insertClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metódusnak.
1. Írja ki a módosított prezentációt PPTX fájlként.

Az alább bemutatott példában a prezentáció nulla indexén (pozíció 1) található diát klónoztuk az 1‑es indexre – pozíció 2 – a prezentációban.

```java
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Klónozza a kívánt diát a ugyanabban a prezentációban lévő diákkollekció végére
    ISlideCollection slds = pres.getSlides();

    // Klónozza a kívánt diát a ugyanabban a prezentációban megadott indexre
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Írja ki a módosított prezentációt a lemezre
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Dia klónozása egy másik prezentáció végén**
Ha egy diát egy prezentációból kell klónozni, és egy másik prezentációs fájlban, a meglévő diák végén szeretné használni:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból, amely tartalmazza a forrás prezentációt, ahonnan a dia klónozva lesz.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból, amely a cél prezentációt tartalmazza, ahová a dia hozzá lesz adva.
1. Hozzon létre egy példányt a [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection) osztályból a cél prezentáció [**Slides**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) gyűjteményének hivatkozásával.
1. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metódust a [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) objektumnál, és adja meg a forrás prezentáció diáját paraméterként a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metódusnak.
1. Írja ki a módosított célprezentációs fájlt.

Az alább bemutatott példában a forrás prezentáció első indexén lévő diát klónoztuk a célprezentáció végére.

```java
// A Presentation osztály példányosítása a forrás prezentációs fájl betöltéséhez
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // A Presentation osztály példányosítása a cél PPTX-hez (ahová a dia klónozva lesz)
    Presentation destPres = new Presentation();
    try {
        // Klónozza a kívánt diát a forrás prezentációból a cél prezentáció diákkollekciójának végére
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Írja ki a cél prezentációt a lemezre
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Dia klónozása egy másik pozícióba egy másik prezentációban**
Ha egy diát egy prezentációból kell klónozni, és egy másik prezentációs fájlban, egy meghatározott pozícióban szeretné használni:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból, amely a forrás prezentációt tartalmazza, ahonnan a dia klónozva lesz.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból, amely a cél prezentációt tartalmazza, ahová a dia hozzá lesz adva.
1. Hozzon létre egy példányt a [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) osztályból a cél prezentáció Slides gyűjteményének hivatkozásával.
1. Hívja meg a [insertClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metódust a [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) objektumnál, és adja meg a forrás prezentáció diáját a kívánt pozícióval együtt paraméterként a [insertClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metódusnak.
1. Írja ki a módosított célprezentációs fájlt.

Az alább bemutatott példában a forrás prezentáció nulla indexén lévő diát klónoztuk az 1‑es indexre (pozíció 2) a célprezentációban.

```java
// A Presentation osztály példányosítása a forrás prezentációs fájl betöltéséhez
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // A Presentation osztály példányosítása a cél PPTX-hez (ahová a dia klónozva lesz)
    Presentation destPres = new Presentation();
    try {
        // Klónozza a kívánt diát a forrás prezentációból a cél prezentáció diákkollekciójának végére
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Írja ki a cél prezentációt a lemezre
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Dia klónozása egy meghatározott pozícióban egy másik prezentációban**
Ha egy diát egy mester diával együtt kell klónozni egy forrás prezentációból, és egy másik prezentációban használni, először a kívánt mester diákat kell klónozni a forrás prezentációból a cél prezentációba. Ezután ezt a mester diát kell használni a mester diával rendelkező dia klónozásához. A [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) egy célprezentációból származó mester diát vár, nem a forrás prezentációból. A dia mesterrel történő klónozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból, amely a forrás prezentációt tartalmazza, ahonnan a dia klónozva lesz.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból, amely a célprezentációt tartalmazza, ahová a dia klónozva lesz.
1. Hozzáférés a klónozandó diához és a hozzá tartozó mester diához.
1. Hozzon létre egy példányt az [IMasterSlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IMasterSlideCollection) osztályból a célprezentáció [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) objektumának Masters gyűjteményével.
1. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metódust az [IMasterSlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IMasterSlideCollection) objektumnál, és adja meg a forrás PPTX‑ből származó mester diát klónozandóként paraméterként a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metódusnak.
1. Hozzon létre egy példányt az [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) osztályból a célprezentáció [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) objektuma által szolgáltatott Slides gyűjteményre mutatva.
1. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metódust az [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) objektumnál, és adja meg a forrás prezentációból származó diát és a mester diát paraméterként a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metódusnak.
1. Írja ki a módosított célprezentációs fájlt.

Az alább bemutatott példában egy mesterrel rendelkező diát (a forrás prezentáció nulla indexén) klónoztunk a célprezentáció végére a forrás diához tartozó mester használatával.

```java
// A Presentation osztály példányosítása a forrás prezentációs fájl betöltéséhez
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // A Presentation osztály példányosítása a cél prezentációhoz (ahová a dia klónozva lesz)
    Presentation destPres = new Presentation();
    try {
        // ISlide példányosítása a forrás prezentáció diákkollekciójából, együtt
        // mester diával
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // A kívánt mester dia klónozása a forrás prezentációból a cél prezentáció
        // mester-gyűjteményébe
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // A kívánt mester dia klónozása a forrás prezentációból a cél prezentáció
        // mester-gyűjteményébe
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Klónozza a kívánt diát a forrás prezentációból a kívánt masterrel a cél
        // prezentáció diákkollekciójának végére
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
Ha egy diát klónozni szeretne, majd ugyanabban a prezentációs fájlban, de egy másik szekcióban szeretné használni, használja a [**addClone**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) metódust, amelyet a [**ISlideCollection**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection) interfész biztosít. Az Aspose.Slides for Android via Java lehetővé teszi, hogy egy diát az első szekcióból klónozzunk, majd a klónozott diát a második szekcióba illesszük ugyanabban a prezentációban.

Az alábbi kódrészlet megmutatja, hogyan lehet egy diát klónozni, és a klónozott diát egy meghatározott szekcióba beszúrni.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Mentse a célprezentációt a lemezre
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Gyakran Ismételt Kérdések**

**Megjelennek-e a jegyzetek és a felülvizsgálati megjegyzések a klónban?**

Igen. A jegyzetoldal és a felülvizsgálati megjegyzések benne vannak a klónban. Ha nem szeretné őket, [távolítsa el őket](/slides/hu/androidjava/presentation-notes/) a beillesztés után.

**Hogyan kezelik a diagramokat és azok adatforrásait?**

A diagram objektum, a formázás és a beágyazott adatok másolásra kerülnek. Ha a diagram egy külső forráshoz (például egy OLE‑beágyazott munkafüzethez) volt csatolva, ez a kapcsolat [OLE objektum](/slides/hu/androidjava/manage-ole/) formájában megmarad. A fájlok közti áthelyezés után ellenőrizze az adatok elérhetőségét és a frissítési viselkedést.

**Szabályozhatom-e a beillesztés helyét és a szekciókat a klón számára?**

Igen. A klón beilleszthető egy adott dia indexre, és elhelyezhető egy kiválasztott [szekció](/slides/hu/androidjava/slide-section/)ba. Ha a cél szekció nem létezik, először hozza létre, majd mozgassa a diát oda.