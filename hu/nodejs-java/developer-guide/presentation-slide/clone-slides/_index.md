---
title: Dia másolása bemutatóban JavaScriptben
linktitle: Diák klónozása
type: docs
weight: 35
url: /hu/nodejs-java/clone-slides/
keywords:
- dia klónozása
- dia másolása
- dia mentése
- PowerPoint
- OpenDocument
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Gyorsan duplikálja a PowerPoint-diákat az Aspose.Slides for Node.js segítségével. Kövesse a kódpéldákat, hogy másodpercek alatt automatizálja a PPT létrehozását, és megszabaduljon a kézi munkától."
---
## **Bevezetés**

A klónozás egy pontos másolat vagy replika létrehozásának folyamata. Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy bármely diát lemásoljunk vagy klónozzunk, majd a klónozott diát a jelenlegi vagy bármely más megnyitott bemutatóba illesszük. A dia klónozása új diát hoz létre, amelyet a fejlesztők módosíthatnak anélkül, hogy az eredeti diát megváltoztatnák. Többféle módja is létezik egy dia klónozásának:

- Klónozás a végén egy bemutatóban.
- Klónozás más pozícióba egy bemutatóban.
- Klónozás a végén egy másik bemutatóban.
- Klónozás más pozícióba egy másik bemutatóban.
- Klónozás egy meghatározott pozícióba egy másik bemutatóban.

Az Aspose.Slides for Node.js via Java (a [Slide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Slide) objektumok gyűjteménye) által a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) objektum biztosított [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) és [insertClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) metódusok a fenti típusú dia-klónozások végrehajtásához

## **Klónozás a végén egy bemutatóban**
Ha egy diát szeretne klónozni, majd ugyanabban a bemutatófájlban a meglévő diák végére helyezni, használja a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódust az alábbi lépések szerint:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
1. Hozzon létre egy példányt a [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) osztályból, a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) objektum által kiadott Slides gyűjteményre hivatkozva.
1. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódust, amelyet a [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) objektum biztosít, és adja át a klónozandó diát paraméterként a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódusnak.
1. Írja ki a módosított bemutatófájlt.

Az alább bemutatott példában egy diát (amely a bemutató első pozíciójában – nulla index – helyezkedik el) klónoztunk a bemutató végére.

```javascript
// Létrehozza a Presentation osztályt, amely egy bemutató fájlt képvisel
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Klónozza a kívánt diát a bemutató ugyanabban a prezentációban lévő diák gyűjteményének végére
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Kiírja a módosított bemutatót a lemezre
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klónozás másik pozícióba egy bemutatóban**
Ha egy diát szeretne klónozni, majd ugyanabban a bemutatófájlban, de másik pozícióban használni, használja a [insertClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) metódust:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
1. Hozzon létre egy példányt a **Slides** gyűjteményre hivatkozva, amelyet a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) objektum biztosít.
1. Hívja meg a [insertClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) metódust, amelyet a [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) objektum biztosít, és adja át a klónozandó diát valamint az új pozíció indexét paraméterként a [insertClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) metódusnak.
1. Írja ki a módosított bemutatót PPTX fájlként.

Az alább bemutatott példában egy diát (amely a nulla index – 1. pozíció – helyén van a bemutatóban) klónoztunk az 1-es indexre – 2. pozícióra – a bemutatóban.

```javascript
// Létrehozza a Presentation osztályt, amely egy bemutató fájlt képvisel
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Klónozza a kívánt diát a bemutató ugyanabban a prezentációban lévő diák gyűjteményének végére
    var slds = pres.getSlides();
    // Klónozza a kívánt diát a bemutató ugyanabban a prezentációban a megadott indexre
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Kiírja a módosított bemutatót a lemezre
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klónozás a végén egy másik bemutatóban**
Ha egy diát egy bemutatóból kell klónozni, és egy másik bemutató fájl végére szeretné beilleszteni:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból, amely a forrásbemutatót tartalmazza.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból, amely a célbemutatót tartalmazza, ahová a dia hozzá lesz adva.
1. Hozzon létre egy [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection) példányt a **Slides** gyűjteményre hivatkozva, amelyet a célbemutató Presentation objektuma biztosít.
1. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódust, amelyet a [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) objektum biztosít, és adja át a forrásbemutató diát paraméterként a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódusnak.
1. Írja ki a módosított célbemutató fájlt.

Az alább bemutatott példában egy diát (a forrásbemutató első indexéből) klónoztunk a célbemutató végére.

```javascript
// Példányosítja a Presentation osztályt a forrás bemutató fájl betöltéséhez
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Példányosítja a Presentation osztályt a cél PPTX-hez (ahová a dia klónozandó)
    var destPres = new aspose.slides.Presentation();
    try {
        // Klónozza a kívánt diát a forrás bemutatóból a cél bemutató diagyűjteményének végére
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Kiírja a cél bemutatót a lemezre
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klónozás másik pozícióba egy másik bemutatóban**
Ha egy diát egy bemutatóból kell klónozni, és egy másik bemutató fájlban, egy meghatározott pozícióba szeretné elhelyezni:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból, amely a forrásbemutatót tartalmazza, ahonnan a dia klónozandó.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból, amely a célbemutatót tartalmazza, ahová a dia hozzá lesz adva.
1. Hozzon létre egy [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) osztályt a Slides gyűjteményre hivatkozva, amelyet a célbemutató Presentation objektuma biztosít.
1. Hívja meg a [insertClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) metódust, amelyet a [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) objektum biztosít, és adja át a forrásbemutató diát valamint a kívánt pozíciót paraméterként a [insertClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) metódusnak.
1. Írja ki a módosított célbemutató fájlt.

Az alább bemutatott példában egy diát (a forrásbemutató nulla indexéről) klónoztunk az 1-es indexre (2. pozíció) a célbemutatóban.

```javascript
// Példányosítja a Presentation osztályt a forrás bemutató fájl betöltéséhez
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Példányosítja a Presentation osztályt a cél PPTX-hez (ahová a dia klónozandó)
    var destPres = new aspose.slides.Presentation();
    try {
        // Klónozza a kívánt diát a forrás bemutatóból a cél bemutató diagyűjteményének végére
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // Kiírja a cél bemutatót a lemezre
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klónozás meghatározott pozícióba egy másik bemutatóban**
Ha egy diát fő diával (master slide) kell klónozni egy bemutatóból, és egy másik bemutatóba használni, először a kívánt fő diát kell klónozni a forrásbemutatóból a célbemutatóba. Ezután a fő diát kell használni a dia fő diával történő klónozásához. A [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) egy célbemutató fő diát vár a forrásbemutató helyett. A diát fő diával való klónozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból, amely a forrásbemutatót tartalmazza, ahonnan a dia klónozandó.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból, amely a célbemutatót tartalmazza, ahova a dia klónozandó.
1. Hozzáférés a klónozandó diához és a fő diához.
1. Hozzon létre egy [MasterSlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/MasterSlideCollection) osztályt a Masters gyűjteményre hivatkozva, amelyet a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) objektum a célbemutatóban biztosít.
1. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódust, amelyet a [MasterSlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/MasterSlideCollection) objektum biztosít, és adja át a forrás PPTX‑ből klónozandó fő diát paraméterként a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódusnak.
1. Hozzon létre egy [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) osztályt úgy, hogy a Slides gyűjteményre hivatkozik, amelyet a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) objektum a célbemutatóban biztosít.
1. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódust, amelyet a [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) objektum biztosít, és adja át a forrásbemutató diát valamint a fő diát paraméterként a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódusnak.
1. Írja ki a módosított célbemutató fájlt.

Az alábbi példában egy fő diával rendelkező diát (a forrásbemutató nulla indexén) klónoztunk a célbemutató végére a forrás dia fő diájának használatával.

```javascript
// Létrehozza a Presentation osztályt a forrás bemutató fájl betöltéséhez
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Létrehozza a Presentation osztályt a cél bemutatóhoz (ahová a dia klónozandó)
    var destPres = new aspose.slides.Presentation();
    try {
        // Létrehozza az ISlide-et a forrás bemutató diagyűjteményéből,
        // és a fő diát
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Klónozza a kívánt fő diát a forrás bemutatóból a
        // cél bemutató master-gyűjteményébe
        // Klónozza a kívánt fő diát a forrás bemutatóból a
        // cél bemutató master-gyűjteményébe
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        var iSlide = masters.addClone(SourceMaster);
        // Klónozza a kívánt diát a forrás bemutatóból a kívánt fő diával a
        // cél bemutató diagyűjteményének végére
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // Mentse a cél bemutatót a lemezre
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klónozás a végén egy megadott szakaszban**
Ha egy diát szeretne klónozni, majd ugyanabban a bemutatófájlban, de egy másik szakaszban használni, akkor használja a [**addClone**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) metódust, amelyet a [**SlideCollection**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection) osztály biztosít. Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy egy diát az első szakaszból klónozzunk, majd a klónozott diát a második szakaszba illesszük be ugyanabban a bemutatóban.

Az alábbi kódrészlet bemutatja, hogyan lehet egy diát klónozni, és a klónozott diát egy megadott szakaszba beszúrni.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Mentse a cél bemutatót a lemezre
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **GYIK**

**Klónozódnak a beszélői jegyzetek és a recenziós megjegyzések?**

Igen. A jegyzetoldal és a recenziós megjegyzések is részei a klónnak. Ha nem akarja őket, [távolítsa el őket](/slides/hu/nodejs-java/presentation-notes/) a behelyezés után.

**Hogyan kezelik a diagramokat és azok adatforrásait?**

A diagram objektuma, formázása és a beágyazott adatok másolásra kerülnek. Ha a diagram egy külső forráshoz (például OLE‑beágyazott munkafüzethez) volt csatolva, ez a kapcsolat megmarad [OLE objektum](/slides/hu/nodejs-java/manage-ole/). A fájlok közti áthelyezés után ellenőrizze az adat elérhetőségét és a frissítési viselkedést.

**Szabályozhatom a klón beszúrási pozícióját és a szakaszokat?**

Igen. A klónt beszúrhatja egy meghatározott diaindexre, és elhelyezheti egy kiválasztott [szakaszba](/slides/hu/nodejs-java/slide-section/). Ha a cél szakasz nem létezik, előbb hozza létre, majd helyezze át a diát oda.