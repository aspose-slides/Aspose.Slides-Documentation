---
title: "Diák masterek kezelése a prezentációkban JavaScript-ben"
linktitle: "Dia Master"
type: docs
weight: 70
url: /hu/nodejs-java/slide-master/
keywords:
- "dia master"
- "master dia"
- "PPT master dia"
- "több master dia"
- "master diák összehasonlítása"
- "háttér"
- "helyőrző"
- "master dia klónozása"
- "master dia másolása"
- "master dia duplikálása"
- "nem használt master dia"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Diák masterek kezelése az Aspose.Slides for Node.js via Java-ban: hozzáférés, szerkesztés, klónozás, összehasonlítás és a master diák eltávolítása PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

A **slide master** közös tervezési beállításokat határoz meg egy diacsoport számára. Tartalmazhat általános alakzatokat, logókat, háttérképeket, szövegstílusokat, téma beállításokat és lábléc beállításokat. PowerPointban a slide master szerkesztése a szokásos módja annak, hogy a prezentáció egységes maradjon anélkül, hogy minden dián megismételné a formázást.

Az Aspose.Slides for Node.js via Java ugyanazt a modellt támogatja. Egy prezentáció egy vagy több master diát tartalmazhat, és minden master dia több layout diát tartalmazhat. A normál diák általában nem hivatkoznak közvetlenül egy master diára. Ehelyett egy normál dia egy layout diát használ, és ez a layout dia egy master diához tartozik.

A hierarchia a következő:

1. **Slide master** – meghatározza a közös tervezést és a témát.
1. **Layout slide** – meghatározza a helyőrzők és a layout-szintű formázás konkrét elrendezését.
1. **Normal slide** – tartalmazza a tényleges prezentáció tartalmát és egy layout diát használ.

![A master diák, layout diák és normál diák hierarchiája](slide-master_2.jpg)

Az Aspose.Slides-ban egy slide master a [MasterSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/) osztállyal van ábrázolva. A prezentáció összes master diája a `Presentation.getMasters()` gyűjteményen keresztül érhető el.

{{% alert color="info" title="Inheritance" %}}
Amikor ugyanaz a tulajdonság több szinten is meghatározásra kerül, a specifikusabb szint nyeri el a hatást. Például, ha egy master dia és egy layout dia is definiál egy háttérszínt, a layoutra épülő diák a layout háttérét használják. A layout diákhoz kapcsolódó további információkért lásd a [Diakialakítás alkalmazása vagy módosítása](/nodejs-java/slide-layout/) oldalt.
{{% /alert %}}

## **Master diákok elérése**

PowerPointban a **View** > **Slide Master** menüből nyithatod meg a Slide Master nézetet.

![A Slide Master parancs a PowerPoint Nézet fülön](slide-master_3.jpg)

Az Aspose.Slides-ban használd a `getMasters()` gyűjteményt a master diák eléréséhez:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

A normál dia által használt master diát a layoutján keresztül is lekérheted:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **A slide master tartalma**

A master dia egy diához hasonló objektum. Örökli a közös dia viselkedést a [BaseSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslide/) osztálytól, ezért sok olyan dia tulajdonságot tesz elérhetővé, amelyet a normál és layout diák is használnak. A master-specifikus tagok a [MasterSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/) API oldalon vannak felsorolva.

A gyakran használt master dia tagok a következők:

| Tag | Cél |
| --- | --- |
| `getBackground()` | Beállítja a master szintű dia háttérét. |
| `getShapes()` | A masterre elhelyezett alakzatokat tárolja, például logókat, képkockákat és közös szöveget. |
| `getLayoutSlides()` | A masterhez tartozó layout diák tárolja. |
| `getThemeManager()` | Hozzáférést biztosít a master téma API-khoz. |
| `getHeaderFooterManager()` | A master és gyerek layoutjai fejléceit, lábléceit, dátumait és dia számait vezérli. |
| `getDependingSlides()` | Visszaadja azokat a normál diákat, amelyek a masterhez tartozó layoutokon keresztül függnek. |

## **Kép hozzáadása a slide masterhez**

Amikor egy képet adsz hozzá egy master diához, megjelenik azokon a diákon, amelyek az aztól származó layout-okat használják. Ez hasznos logók, vízjelekkel, díszítő sávokkal és más ismétlődő vizuális elemekkel.

A következő példa egy logót ad hozzá az első master diához:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A képkockákról további információkért lásd a [Képkocka](/nodejs-java/picture-frame/) oldalt.

## **A master grafika láthatóságának vezérlése**

Használd a [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes) függvényt a örökölt master grafikák, például logók vagy díszítő alakzatok elrejtésére anélkül, hogy törölnéd őket a masterról. Add meg a `false` értéket a [Slide.setShowMasterShapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#setShowMasterShapes) metódusnak azon a dián, amelyik el akarja hagyni ezeket a grafikákat, és tartsd `true` értéken azon diákon, amelyek meg akarják jeleníteni őket.

A következő önálló példa egy kék díszítő sávot hoz létre egy masteren és két dián, amelyek ugyanazt az üres layoutot használják. A sáv látható az első dián, a másodikon rejtve van. Nem szükséges bemeneti prezentáció vagy kép.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A példa a **Blank** layoutot használja, amely egy új prezentációval érkezik, és eltávolítja az első dia saját helyőrzőit.

### **A beállítás hatókörének kiválasztása**

Egy normál dia a masterjét a [Slide.getLayoutSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#getLayoutSlide) és a [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/#getMasterSlide) segítségével használja. A tulajdonság beállítása egy egyedi dián csak arra a diára hat. A `false` érték átadása a [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) metódusnak elrejti a master grafikákat azokon a diákon, amelyek ezt a közös layoutot használják, még akkor is, ha saját beállításuk `true`. Egyetlen dia grafikájának elrejtéséhez módosítsd a dia tulajdonságát, és hagyd változatlanul a közös layoutot.

A beállítás nem támogatott láthatóságvezérlésként a master dián magán. Egy masteren a [getShowMasterShapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) mindig `false` értéket ad vissza, és a [setShowMasterShapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) `true` értékének átadása kivételt dob. Inkább egy normál dián vagy egy layouton alkalmazd.

### **Megkülönböztetés: grafika vs háttér**

| Művelet | Hatás |
| --- | --- |
| Master grafikák elrejtése | A örökölt master alakzatok láthatóságát szabályozza anélkül, hogy törölné őket vagy megváltoztatná a dia saját alakzatait. |
| Dia háttérkitöltésének módosítása | Megváltoztatja a háttér színét, színátmenetét vagy képét. A master grafikák külön alakzatok, és láthatóak maradhatnak ezen a háttéren. Lásd a [Presentation Background](/slides/hu/nodejs-java/presentation-background/) oldalt. |
| Alakzat törlése a masterról | Eltávolítja a közös forrásalakzatot, így már nem áll rendelkezésre semmilyen, a mastert használó dián. |

## **Helyőrzőkkel dolgozás**

A helyőrzőket általában a layout diákon definiálják. A master dia biztosítja a közös stílust és témát, amelyet a layoutok örökölnek, míg minden layout dönti el, mely helyőrzők érhetők el és hol helyezkednek el.

PowerPointban a helyőrző parancsok a Slide Master nézetben érhetők el.

![Az Insert Placeholder parancs a PowerPoint Slide Master nézetben](slide-master_5.png)

Az új helyőrzők hozzáadásához az Aspose.Slides-ban dolgozz a masterhez tartozó layout diával:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A master dián már meglévő helyőrző alakzatokat is formázhatod. A következő példa megtalálja a cím helyőrzőt és lineáris színátmenetes kitöltést alkalmaz rá:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formázott cím helyőrző, amelyet a normál diák örökölnek](slide-master_8.png)

A helyőrző és szövegformázási lehetőségekről további információkért lásd a [Helyőrző szöveg beállítása](/nodejs-java/manage-placeholder/) és a [Szövegformázás](/nodejs-java/text-formatting/) oldalakat.

## **Slide master háttér módosítása**

Egy master háttér öröklődik a layoutokra és azokra a diákra, amelyek nem írják felül. A következő példa egy szilárd háttérszínt állít be az első master diára:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kapcsolódó témákért lásd a [Prezentáció háttér](/nodejs-java/presentation-background/) és a [Prezentáció téma](/nodejs-java/presentation-theme/) oldalakat.

## **Slide master klónozása másik prezentációba**

Használd a `MasterSlideCollection.addClone` metódust egy master dia másik prezentációba másolásához. A másolt master aztán a cél prezentáció layoutjai és diái használhatják.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Ha a normál diákok és a master klónozására van szükséged, lásd a [Diák klónozása](/nodejs-java/clone-slides/) oldalt.

## **Több slide master hozzáadása**

Egy prezentáció több master diát is tartalmazhat. Ez hasznos, amikor különböző szakaszok különböző márkaarculatot, oldalstruktúrát vagy téma beállításokat igényelnek.

![PowerPoint parancsok master diák beszúrásához és kezeléséhez](slide-master_9.jpg)

A következő példa klónozza az alapértelmezett mastert, más háttérrel látja el a klónt, egy layoutot hoz létre a klónozott master alatt, és egy új diát ad hozzá, amely ezt a layoutot használja:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Slide master összehasonlítása**

A master diák összehasonlíthatók a [BaseSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslide/)‑től örökölt `equals` metódussal. Az összehasonlítás a szerkezetet és a statikus tartalmat ellenőrzi, például alakzatokat, szöveget, formázást, animációkat és egyéb dia beállításokat. Nem hasonlítja össze az egyedi azonosítókat, mint a dia ID‑k, vagy a helyőrzők dinamikus értékeit, például a aktuális dátumot.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

További információkért lásd a [Prezentáció diák összehasonlítása](/slides/hu/nodejs-java/compare-slides/) oldalt.

## **Slide Master nézet beállítása alapértelmezett nézetnek**

Használd a `setLastView` metódust a [ViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/) osztályon, hogy a PowerPoint által elsőként megnyitott nézetet szabályozd. A következő példa a prezentációt Slide Master nézetben nyitja meg:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

További nézetbeállításokért lásd a [Prezentáció mentése](/slides/hu/nodejs-java/save-presentation/) oldalt.

## **Nem használt master diákok eltávolítása**

A prezentációk néha olyan master diákat tartalmaznak, amelyeket már egyetlen normál dia sem használ. A nem használt masterok eltávolítása csökkentheti a fájlméretet és egyszerűsítheti a sablonkarbantartást.

Használd a `removeUnused` metódust a nem használt masterok eltávolításához a `getMasters()` gyűjteményből:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Használhatod az alacsony-kódú `Compress.removeUnusedMasterSlides` metódust is:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Mi a különbség a slide master és a layout slide között?**

A slide master közös tervezési beállításokat határoz meg, például témát, hátteret, általános alakzatokat és szövegstílusokat. Egy layout slide egy master diához tartozik, és egy adott helyőrző- és elrendezési konfigurációt definiál. Egy normál dia egy layout diát használ, így a layouttól és a mastertől egyaránt örököl.

**Egy prezentáció tartalmazhat több slide master-t?**

Igen. Egy prezentáció tartalmazhat több slide master-t. Használj több mastert, ha a különböző szakaszok különböző vizuális rendszert vagy márkaarculatot igényelnek.

**Hová érdemes helyőrzőket felvenni: a master diára vagy a layout diára?**

A legtöbb esetben a helyőrzőket a layout diákra érdemes felvenni. A közös vizuális elemeket és a közös formázásokat a master dián helyezd el, majd a tartalmi helyőrzőket a layoutokba, amelyeket a normál diák használnak.

**Törölhetek olyan master diát, amely még használatban van?**

Nem. Olyan master diát, amelyhez függő diák kapcsolódnak, nem lehet biztonságosan közvetlenül törölni. Először helyezd át ezeket a diát egy másik master alatti layoutokra, vagy használj egy nem használt masterok tisztítására szolgáló módszert, amely csak a nem használt master diákat távolítja el.