---
title: Prezentációs Diákok Klónozása Java-ban
linktitle: Diákok Klónozása
type: docs
weight: 35
url: /hu/java/clone-slides/
keywords:
- dia klónozása
- dia másolása
- dia mentése
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Java segítségével gyorsan másolja meg a PowerPoint diákat. Kövesse áttekinthető kódpéldáinkat, hogy másodpercek alatt automatizálja a PPT létrehozását és megszüntesse a kézi munkát."
---
## **Bevezetés**

A klónozás egy adott dolog pontos másolatának vagy replikájának létrehozása. Az Aspose.Slides for Java lehetővé teszi bármely dia másolását vagy klónozását, majd ennek a klónozott diának a beszúrását az aktuális vagy bármely más megnyitott bemutatóba. A diáklónozási folyamat egy új diát hoz létre, amelyet a fejlesztők módosíthatnak anélkül, hogy az eredeti diát megváltoztatnák. Többféle módja van egy dia klónozásának:

- Klónozás a bemutató végén.
- Klónozás a bemutató másik pozíciójában.
- Klónozás egy másik bemutató végén.
- Klónozás egy másik bemutató másik pozíciójában.
- Klónozás egy meghatározott pozícióban egy másik bemutatóban.

Az Aspose.Slides for Java-ban a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) objektum által biztosított (az [ISlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlide) objektumok gyűjteménye) a [addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) és a [insertClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides/ISSlide-) metódusokat kínálja a fenti típusú diáklónozások végrehajtásához

## **Dia klónozása a bemutató végén**
Ha egy diát szeretne klónozni, és azt ugyanabban a bemutatófájlban a meglévő diák végén használni, használja az [addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metódust az alább felsorolt lépések szerint:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
2. Példányosítsa az [ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) osztályt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) objektum által biztosított Slides gyűjteményre hivatkozva.
3. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metódust az [ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) objektumon, és adja át a klónozandó diát paraméterként a [addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metódusnak.
4. Írja ki a módosított bemutatófájlt.

Az alább bemutatott példában egy diát (amely a bemutató első pozíciójában – 0 index – helyezkedik el) klónoztunk a bemutató végére.

```java
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Klónozza a kívánt diát a ugyanabban a prezentációban lévő diakollekció végére
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Írja a módosított prezentációt a lemezre
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Dia klónozása egy másik pozícióba ugyanabban a bemutatóban**
Ha egy diát szeretne klónozni, és ugyanabban a bemutatófájlban, de más pozícióban használni, használja az [insertClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides/ISSlide-) metódust:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
2. Példányosítsa az osztályt a [**Slides**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) gyűjteményre hivatkozva, amelyet a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) objektum biztosít.
3. Hívja meg az [insertClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides/ISSlide-) metódust az [ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) objektumon, és adja át a klónozandó diát valamint az új pozíció indexét paraméterként az [insertClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides/ISSlide-) metódusnak.
4. Írja ki a módosított bemutatót PPTX fájlként.

Az alább bemutatott példában egy diát (amely a nulla indexen – 1. pozíció – helyezkedik el a bemutatóban) klónoztunk az 1-es indexre – 2. pozícióra – a bemutatóban.

```java
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Klónozza a kívánt diát a ugyanabban a prezentációban lévő diakollekció végére
    ISlideCollection slds = pres.getSlides();

    // Klónozza a kívánt diát a megadott indexre ugyanabban a prezentációban
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Írja a módosított prezentációt a lemezre
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Dia klónozása egy másik bemutató végén**
Ha egy diát egy bemutatóból kell klónozni és egy másik bemutatófájlban, a meglévő diák végén használni:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból, amely a forrás bemutatót tartalmazza, ahonnan a diát klónozni kell.
2. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból, amely a célnak szánt bemutatót tartalmazza, amelyhez a diát hozzá kell adni.
3. Példányosítsa az [ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection) osztályt a célnak szánt bemutató Presentation objektumának [**Slides**] (https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) gyűjteményére hivatkozva.
4. Hívja meg az [addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metódust az [ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) objektumon, és adja át a forrás bemutatóból származó diát paraméterként az [addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metódusnak.
5. Írja ki a módosított célnak szánt bemutatófájlt.

Az alább bemutatott példában egy diát (a forrás bemutató első indexéről) klónoztunk a célnak szánt bemutató végére.

```java
// Példányosítsa a Presentation osztályt a forrás prezentációs fájl betöltéséhez
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Példányosítsa a Presentation osztályt a cél PPTX-hez (ahová a dia klónozva lesz)
    Presentation destPres = new Presentation();
    try {
        // Klónozza a kívánt diát a forrás prezentációból a cél prezentáció diakollekciójának végére
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

## **Dia klónozása egy másik pozícióba egy másik bemutatóban**
Ha egy diát egy bemutatóból kell klónozni és egy másik bemutatófájlban, egy meghatározott pozícióban használni:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból, amely a forrás bemutatót tartalmazza, ahonnan a diát klónozni kell.
2. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból, amely a célnak szánt bemutatót tartalmazza, amelyhez a diát hozzá kell adni.
3. Példányosítsa az [ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) osztályt a célnak szánt bemutató Presentation objektumának Slides gyűjteményére hivatkozva.
4. Hívja meg az [insertClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides/ISSlide-) metódust az [ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) objektumon, és adja át a forrás bemutatóból származó diát valamint a kívánt pozíciót paraméterként az [insertClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides/ISSlide-) metódusnak.
5. Írja ki a módosított célnak szánt bemutatófájlt.

Az alább bemutatott példában egy diát (a forrás bemutató nulla indexéről) klónoztunk az 1-es indexre (2. pozíció) a célnak szánt bemutatóban.

```java
// Példányosítsa a Presentation osztályt a forrás prezentációs fájl betöltéséhez
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Példányosítsa a Presentation osztályt a cél PPTX-hez (ahová a dia klónozva lesz)
    Presentation destPres = new Presentation();
    try {
        // Klónozza a kívánt diát a forrás prezentációból a cél prezentáció diakollekciójának végére
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Írja a cél prezentációt a lemezre
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Dia klónozása egy meghatározott pozícióban egy másik bemutatóban**
Ha egy diát egy mester diával egy bemutatóból kell klónozni és egy másik bemutatóban használni, először a kívánt mester diát kell a forrás bemutatóból a célnak szánt bemutatóba klónozni. Ezután ezt a mester diát kell felhasználni a mesterrel rendelkező dia klónozásához. A [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) metódus egy a célnak szánt bemutatóból származó mester diát vár, nem a forrásból. A dia mesterrel való klónozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból, amely a forrás bemutatót tartalmazza, ahonnan a diát klónozni kell.
2. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból, amely a célnak szánt bemutatót tartalmazza, amelyhez a diát klónozni kell.
3. Szerezze meg a klónozandó diát a kapcsolódó mester diával együtt.
4. Példányosítsa az [IMasterSlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IMasterSlideCollection) osztályt a célnak szánt bemutató Presentation objektumának Masters gyűjteményére hivatkozva.
5. Hívja meg az [addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metódust az [IMasterSlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IMasterSlideCollection) objektumon, és adja át a forrás PPTX-ből származó mester diát paraméterként az [addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metódusnak.
6. Példányosítsa az [ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) osztályt a célnak szánt bemutató Presentation objektumának Slides gyűjteményére hivatkozva.
7. Hívja meg az [addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metódust az [ISlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) objektumon, és adja át a forrás bemutatóból származó klónozandó diát valamint a mester diát paraméterként az [addClone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metódusnak.
8. Írja ki a módosított célnak szánt bemutatófájlt.

Az alább bemutatott példában egy mester diával rendelkező diát (amely a forrás bemutató nulla indexén helyezkedik el) a célnak szánt bemutató végére klónoztunk a forrás diából származó master felhasználásával.

```java
// Példányosítsa a Presentation osztályt a forrás prezentációs fájl betöltéséhez
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Példányosítsa a Presentation osztályt a cél prezentációhoz (ahová a dia klónozva lesz)
    Presentation destPres = new Presentation();
    try {
        // Példányosítson egy ISlidet a forrás prezentáció diakollekciójából, valamint
        // a mester diát
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klónozza a kívánt mester diát a forrás prezentációból a mesterek gyűjteményébe a
        // cél prezentációban
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klónozza a kívánt mester diát a forrás prezentációból a mesterek gyűjteményébe a
        // cél prezentációban
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Klónozza a kívánt diát a forrás prezentációból a kívánt mesterrel a
        // cél prezentáció diakollekciójának végére
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

## **Dia klónozása egy megadott szekció végén**
Ha egy diát szeretne klónozni, és ugyanabban a bemutatófájlban, de egy másik szekcióban használni, akkor használja az [**addClone**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) metódust, amelyet az [**ISlideCollection**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlideCollection) interfész biztosít. Az Aspose.Slides for Java lehetővé teszi, hogy egy diát az első szekcióból klónozzon, majd a klónozott diát a második szekcióba szúrja be ugyanabban a bemutatóban.

A következő kódrészlet megmutatja, hogyan lehet egy diát klónozni és a klónozott diát egy megadott szekcióba beszúrni.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Mentse a cél prezentációt a lemezre
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **GYIK**

**Klónozódnak a beszélőjegyzetek és a felülvizsgálói megjegyzések?**

Igen. A jegyzetoldal és a felülvizsgálati megjegyzések a klónba kerülnek. Ha nem kívánja őket, a beszúrás után [távolítsa el őket](/slides/hu/java/presentation-notes/).

**Hogyan kezelik a diagramokat és azok adatforrásait?**

A diagram objektuma, formázása és a beágyazott adatok másolásra kerülnek. Ha a diagram külső forráshoz (például OLE-beágyazott munkafüzethez) volt kapcsolva, ez a kapcsolat [OLE objektumként](/slides/hu/java/manage-ole/) megmarad. Fájlok között történő áthelyezés után ellenőrizze az adatok elérhetőségét és a frissítési viselkedést.

**Szabályozhatom a klón beszúrási helyét és a szekciókat?**

Igen. A klónt egy meghatározott dia indexre szúrhatja be, és egy kiválasztott [szekcióba](/slides/hu/java/slide-section/) helyezheti. Ha a cél szekció nem létezik, először hozza létre, majd mozgassa a diát bele.