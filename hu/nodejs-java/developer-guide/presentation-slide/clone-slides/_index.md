---
title: Prezentációs diák klónozása JavaScriptben
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
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Az Aspose.Slides for Node.js segítségével gyorsan másolhat PowerPoint diákat. Kövesse kódpéldáinkat, hogy másodpercek alatt automatizálja a PPT készítést és megszabaduljon a manuális munkától."
---
## **Bevezetés**

A klónozás az a folyamat, amikor pontos másolatot vagy replikát készít valamerről. Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy bármely diát másolatot vagy klónt készítsünk, majd azt a klónozott diát a jelenlegi vagy bármely más nyitott prezentációba illesszük. A dia klónozási folyamat új diát hoz létre, amelyet a fejlesztők módosíthatnak anélkül, hogy az eredeti diát megváltoztatnák. Többféle módon lehet diát klónozni:

- Klónálás a végén egy prezentáción belül.
- Klónálás másik pozícióban egy prezentáción belül.
- Klónálás a végén egy másik prezentációban.
- Klónálás másik pozícióban egy másik prezentációban.
- Klónálás egy meghatározott pozícióban egy másik prezentációban.

Az Aspose.Slides for Node.js via Java-ban a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) objektum által biztosított (a [Slide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Slide) objektumok gyűjteménye) tartalmazza az [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) és az [insertClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) metódusokat, amelyekkel a fenti diaklónozási típusok elvégezhetők.

## **Klónálás a végén egy prezentáción belül**
Ha egy diát szeretne klónozni, majd ugyanabban a prezentációs fájlban a meglévő diák végén használni, a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódust használja az alábbi lépések szerint:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
1. Hozza létre a [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) példányát a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) objektum által biztosított Slides gyűjteményre hivatkozva.
1. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódust a [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) objektumon, és adja át a klónozandó diát paraméterként a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódusnak.
1. Írja ki a módosított prezentációs fájlt.

Az alábbi példában egy diát (ami a prezentáció első pozíciójában – nulla index – található) klónoztunk a prezentáció végére.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

//    Instantiate Presentation class that represents a presentation file
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    //    Clone the desired slide to the end of the collection of slides in the same presentation
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    //    Write the modified presentation to disk
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klónálás másik pozícióban egy prezentáción belül**
Ha egy diát szeretne klónozni, majd ugyanabban a prezentációs fájlban egy másik pozícióban használni, a [insertClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) metódust használja:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
1. Hozza létre a [Slides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) gyűjteményt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) objektum által biztosított hivatkozással.
1. Hívja meg a [insertClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) metódust a [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) objektumon, és adja át a klónozandó diát valamint az új pozíció indexét paraméterként a [insertClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) metódusnak.
1. Írja ki a módosított prezentációt PPTX formátumban.

Az alábbi példában egy diát (ami az index 1 – 2. pozíció – helyen van a prezentációban) klónoztunk az index 2 – 3. pozíció – helyre a prezentációban.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Klónozza a kívánt diát a ugyanabban a prezentációban lévő diák gyűjteményének végére
    var slds = pres.getSlides();
    // Klónozza a kívánt diát a megadott indexre ugyanabban a prezentációban
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Írja a módosított prezentációt lemezre
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klónálás a végén egy másik prezentációban**
Ha egy diát egy prezentációból szeretne klónozni, és egy másik prezentáció végéhez hozzáadni:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból, amely tartalmazza a forrás prezentációt, ahonnan a diát klónozni fogja.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból, amely a cél prezentációt tartalmazza, ahová a diát hozzáadja.
1. Hozza létre a [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection) osztályt a cél prezentáció [**Slides**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) gyűjteményére hivatkozva.
1. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódust a [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) objektumon, és adja át a forrás prezentációból származó diát paraméterként a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódusnak.
1. Írja ki a módosított cél prezentációs fájlt.

Az alábbi példában egy diát (a forrás prezentáció első indexéből) klónoztunk a cél prezentáció végére.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Példányosítja a Presentation osztályt a forrás prezentációs fájl betöltéséhez
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Példányosítja a Presentation osztályt a cél PPTX-hez (ahová a dia klónozandó)
    var destPres = new aspose.slides.Presentation();
    try {
        // Klónozza a kívánt diát a forrás prezentációból a cél prezentáció diagyűjteményének végére
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Írja a cél prezentációt lemezre
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klónálás másik pozícióban egy másik prezentációban**
Ha egy diát egy prezentációból szeretne klónozni, és egy másik prezentációban egy meghatározott pozícióba illeszteni:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból, amely a forrás prezentációt tartalmazza.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból, amely a cél prezentációt tartalmazza.
1. Hozza létre a [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) osztályt a cél prezentáció Slides gyűjteményére hivatkozva.
1. Hívja meg a [insertClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) metódust a [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) objektumon, és adja át a forrás prezentációból származó diát valamint a kívánt pozíciót paraméterként a [insertClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) metódusnak.
1. Írja ki a módosított cél prezentációs fájlt.

Az alábbi példában egy diát (a forrás prezentáció nulla indexéből) klónoztunk az index 1 (2. pozíció) helyre a cél prezentációban.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Példányosítja a Presentation osztályt a forrás prezentációs fájl betöltéséhez
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Példányosítja a Presentation osztályt a cél PPTX-hez (ahová a dia klónozandó)
    var destPres = new aspose.slides.Presentation();
    try {
        // Klónozza a kívánt diát a forrás prezentációból a cél prezentáció diagyűjteményének végére
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // Írja a cél prezentációt lemezre
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klónálás egy meghatározott pozícióban egy másik prezentációban**
Ha egy diát mesterszintű diával szeretne klónozni egy forrás prezentációból, és egy másik prezentációban használni, először klónoznia kell a kívánt mesterdiát a forrás prezentációból a cél prezentációba. Ezután a klónozandó diához a mesterdiát kell használni. Az [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) egy cél prezentációból származó mesterdiát vár, nem a forrásból. A diák mesterrel való klónozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból, amely a forrás prezentációt tartalmazza.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból, amely a cél prezentációt tartalmazza.
1. Hozzáférés a klónozandó diához és a hozzá tartozó mesterdiához.
1. Hozza létre a [MasterSlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/MasterSlideCollection) osztályt a cél prezentáció [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) objektumának Masters gyűjteményére hivatkozva.
1. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódust a [MasterSlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/MasterSlideCollection) objektumon, és adja át a forrás PPTX‑ből származó mesterdiát paraméterként a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódusnak.
1. Hozza létre a [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) osztályt a cél prezentáció [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) objektumának Slides gyűjteményére hivatkozva.
1. Hívja meg a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódust a [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) objektumon, és adja át a forrás prezentációból származó diát és a mesterdiát paraméterként a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódusnak.
1. Írja ki a módosított cél prezentációs fájlt.

Az alábbi példában egy diát mesterrel (a forrás prezentáció nulla indexéből) klónoztunk a cél prezentáció végére a forrás diától származó mesterrel.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Példányosítja a Presentation osztályt a forrás prezentációs fájl betöltéséhez
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Példányosítja a Presentation osztályt a cél prezentációhoz (ahová a dia klónozandó)
    var destPres = new aspose.slides.Presentation();
    try {
        // Példányosít egy ISlide-et a forrás prezentáció diagyűjteményéből, valamint
        // Mester dia
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Klónozza a kívánt mesterdiát a forrás prezentációból a mestergyűjteménybe a
        // cél prezentációban
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // Klónozza a kívánt diát a forrás prezentációból a kívánt masterrel a
        // cél prezentáció diagyűjteményének végére
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // Mentse a cél prezentációt lemezre
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klónálás a végén egy meghatározott szakaszban**
Ha egy diát szeretne klónozni, majd ugyanabban a prezentációban, de egy másik szakaszban használni, akkor a [**addClone**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) metódust használja a [**SlideCollection**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection) osztályon. Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy egy diát az első szakaszból klónozzunk, majd a klónozott diát a második szakaszba illesszük ugyanabban a prezentációban.

Az alábbi kódrészlet megmutatja, hogyan lehet egy diát klónozni, és a klónozott diát egy meghatározott szakaszba illeszteni.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    //    A cél prezentáció mentése lemezre
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Győződjön meg a diaméret egyezéséről**

Diák másik prezentációba történő klónozása esetén győződjön meg arról, hogy a cél prezentáció diamérete megegyezik a forrással. Ha a diaméretek eltérnek, az Aspose.Slides nem méretezi át automatikusan a klónozott alakzatokat – megmaradnak az eredeti koordináták és méretek, ami a tartalom elcsúszásához vagy a dia határainak túllépéséhez vezethet.

Állítsa be a cél prezentáció diaméretét, hogy megegyezzen a forráséval, még a mester és a dia klónozása előtt:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

Ezt a mester és a dia klónozása előtt tegye meg.

## **GYIK**

**Klónozódnak a felolvasó jegyzetek és az ellenőrző megjegyzések?**

Igen. A jegyzetoldal és az ellenőrző megjegyzések is részei a klónnak. Ha ezeket nem szeretné, akkor [távolítsa el őket](/slides/hu/nodejs-java/presentation-notes/) a beillesztés után.

**Hogyan kezelik a diagramok és adatforrásaik?**

A diagramobjektum, formázása és a beágyazott adatok másolásra kerülnek. Ha a diagram egy külső forráshoz (például OLE‑beágyazott munkafüzethez) volt csatolva, a kapcsolat megmarad egy [OLE objektum](/slides/hu/nodejs-java/manage-ole/) formájában. Fájlok között mozgatás után ellenőrizze az adat elérhetőségét és a frissítési viselkedést.

**Szabályozhatom-e a klón beillesztési pozícióját és szakaszait?**

Igen. A klónt egy adott dia indexhez illesztheti, és egy kiválasztott [szakasz](/slides/hu/nodejs-java/slide-section/) belsejébe helyezheti. Ha a cél szakasz nem létezik, előbb hozza létre, majd mozgassa a diát oda.