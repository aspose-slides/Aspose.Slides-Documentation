---
title: Diavetítés slide masterek kezelése JavaScriptben
linktitle: Dia master
type: docs
weight: 70
url: /hu/nodejs-java/slide-master/
keywords:
- dia master
- master dia
- PPT master dia
- több master dia
- master diák összehasonlítása
- háttér
- helyőrző
- master dia klónozása
- master dia másolása
- master dia duplikálása
- használaton kívül lévő master dia
- PowerPoint
- OpenDocument
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Slide masterek kezelése az Aspose.Slides for Node.js via Java segítségével: master diák elérése, szerkesztése, klónozása, összehasonlítása és eltávolítása PowerPoint és OpenDocument bemutatókban."
---
## **Áttekintés**

A **slide master** meghatározza a közös tervezési beállításokat egy diacsoport számára. Tartalmazhat közös alakzatokat, logókat, háttereket, szövegstílusokat, témabeállításokat és láblécbeállításokat. PowerPointban a slide master szerkesztése általános módja annak, hogy a bemutató egységes legyen anélkül, hogy minden diához újból meg kellene ismételni a formázást.

Az Aspose.Slides for Node.js via Java ugyanezt a modellt támogatja. Egy bemutató egy vagy több master diát tartalmazhat, és minden master dia több layout diát tartalmazhat. A normál diák általában nem hivatkoznak közvetlenül egy master diára. Ehelyett egy normál dia egy layout diát használ, amely egy master dia része.

A hierarchia:

1. **Slide master** – meghatározza a közös tervezést és a témát.
1. **Layout slide** – meghatározza a helyőrzők és a elrendezés szintű formázás konkrét elrendezését.
1. **Normal slide** – tartalmazza a tényleges bemutató tartalmát, és egy elrendezés diát használ.

![A master diák, layout diák és normál diák hierarchiája](slide-master_2.jpg)

Az Aspose.Slides-ben a slide master a [MasterSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/) osztállyal van reprezentálva. Egy bemutató összes master diája a `Presentation.getMasters()` gyűjteményen keresztül érhető el.

{{% alert color="info" title="Inheritance" %}}
Ha ugyanaz a tulajdonság több szinten is definiálva van, a specifikusabb szint nyer. Például, ha egy master dia és egy layout dia is meghatároz egy hátteret, akkor az arra alapuló diák a layout háttérét használják. További információért az elrendezés diákról lásd a [Alkalmazás vagy elrendezés módosítása](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Slide Masterok elérése**

PowerPointban a **View** > **Slide Master** menüpontból nyithatja meg a Slide Master nézetet.

![A Slide Master parancs a PowerPoint Nézet fülön](slide-master_3.jpg)

Az Aspose.Slides-ben, használja a `getMasters()` gyűjteményt a master diák eléréséhez:

```javascript
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

A normál dia által használt master diát a saját elrendezésén keresztül is lekérdezheti:

```javascript
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

## **Mi található egy Slide Masterban**

A master dia egy diához hasonló objektum. A [BaseSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslide/) közös diabehaviort örököl, így ugyanazokat a diatulajdonságokat teszi elérhetővé, mint a normál és layout diák. A master-specifikus tagok a [MasterSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/) API oldalon vannak felsorolva.

A gyakran használt master dia tagok a következők:

| Tag | Cél |
| --- | --- |
| `getBackground()` | Beállítja a master szintű dia hátterét. |
| `getShapes()` | Tárolja a masterre helyezett alakzatokat, például logókat, képkereteket és megosztott szöveget. |
| `getLayoutSlides()` | Tárolja a masterhez tartozó layout diákat. |
| `getThemeManager()` | Hozzáférést biztosít a master téma API-khoz. |
| `getHeaderFooterManager()` | A fejléceket, lábléceket, dátumokat és dia számozást kezeli a master és alárendelt elrendezései számára. |
| `getDependingSlides()` | Visszaadja azokat a normál diákat, amelyek elrendezéseiken keresztül a masterre támaszkodnak. |

## **Kép hozzáadása egy Slide Masterhoz**

Amikor képet ad hozzá egy master diához, az megjelenik azokon a diákon, amelyek azt az elrendezést használják. Ez hasznos logók, vízjelek, díszszalagok és egyéb ismétlődő vizuális elemek esetén.

A következő példa egy logót ad az első master diához:

```javascript
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

További információért a képkeretekről lásd a [Képkeret](/nodejs-java/picture-frame/).

## **Munkavégzés helyőrzőkkel**

A helyőrzőket általában a layout diákon definiálják. A master dia biztosítja a közös stílust és témát, amelyet az elrendezések örökölnek, míg minden elrendezés eldönti, mely helyőrzők állnak rendelkezésre és hol helyezkednek el.

PowerPointban a helyőrző parancsok a Slide Master nézetben érhetők el.

![A Helyőrző beszúrása parancs a PowerPoint Slide Master nézetben](slide-master_5.png)

Új helyőrzők hozzáadásához az Aspose.Slides segítségével dolgozzon a masterhez tartozó layout diával:

```javascript
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

Formázhatja a már meglévő helyőrző alakzatokat is a master dián. A következő példa megtalálja a cím helyőrzőt és lineáris színátmenetes kitöltést alkalmaz:

```javascript
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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formázott cím helyőrző, amelyet a normál diák örökölnek](slide-master_8.png)

További helyőrző és szövegformázási lehetőségekért lásd a [Helyőrzőbe beírandó szöveg beállítása](/nodejs-java/manage-placeholder/) és a [Szövegformázás](/nodejs-java/text-formatting/) oldalakat.

## **Slide Master háttér módosítása**

A master háttér az elrendezések és diák által öröklődik, amelyek nem írják felül. A következő példa szilárd háttérszínt állít be az első master diához:

```javascript
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

Kapcsolódó témákért lásd a [Bemutató háttér](/nodejs-java/presentation-background/) és a [Bemutató téma](/nodejs-java/presentation-theme/) oldalakat.

## **Slide Master klónozása egy másik bemutatóba**

`MasterSlideCollection.addClone` használatával másolhat egy master diát egy másik bemutatóba. A másolt master ezután felhasználható az elrendezések és diák számára a célbemutatóban.

```javascript
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

Ha a normál diákot a masterrel együtt kell klónozni, lásd a [Diák klónozása](/nodejs-java/clone-slides/) oldalt.

## **Több Slide Master hozzáadása**

Egy bemutató több master diát is tartalmazhat. Ez akkor hasznos, ha a különböző szakaszok különböző márkaépítést, oldalstruktúrát vagy témabeállításokat igényelnek.

![PowerPoint parancsok master diák beszúrásához és kezeléséhez](slide-master_9.jpg)

A következő példa a alapértelmezett mastert klónozza, a klónnak más háttérszínt ad, létrehoz egy elrendezést a klónozott master alatt, és hozzáad egy új diát, amely ezen elrendezésen alapul:

```javascript
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

## **Slide Masterok összehasonlítása**

A master diák összehasonlíthatók az [BaseSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslide/) osztálytól örökölt `equals` metódussal. Az összehasonlítás ellenőrzi a struktúrát és a statikus tartalmat, például alakzatokat, szöveget, formázást, animációkat és egyéb dia beállításokat. Nem hasonlítja össze az egyedi azonosítókat, mint a dia ID-k, vagy a dinamikus helyőrző értékeket, például az aktuális dátumot.

```javascript
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

További információért lásd a [Bemutató diák összehasonlítása](/nodejs-java/compare-slides/) oldalt.

## **Slide Master nézet beállítása alapértelmezett nézetként**

A `setLastView` metódus használatával a [ViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/) osztályon szabályozható, hogy a PowerPoint melyik nézetet nyissa meg először. A következő példa a bemutatót Slide Master nézetben nyitja meg:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

További nézetbeállításokért lásd a [Bemutató mentése](/nodejs-java/save-presentation/) oldalt.

## **Felhasználatlan master diák eltávolítása**

A bemutatók néha olyan master diákat tartalmaznak, amelyeket már egyetlen normál dia sem használ. A felhasználatlan masterok eltávolítása csökkentheti a fájlméretet és egyszerűsítheti a sablonkarbantartást.

`removeUnused` használatával eltávolíthatja a felhasználatlan masterokat a `getMasters()` gyűjteményből:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Alacsony kódolású `Compress.removeUnusedMasterSlides` metódust is használhat:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Mi a különbség a slide master és a layout slide között?**

A slide master meghatározza a közös tervezési beállításokat, mint a téma, háttér, közös alakzatok és szövegstílusok. A layout slide egy master slide-hez tartozik, és egy konkrét helyőrző elrendezést definiál. Egy normál dia egy layout slide-ot használ, így mind a layout, mind a master tulajdonságait örökli.

**Tartalmazhat egy bemutató több slide mastert?**

Igen. Egy bemutató több slide mastert is tartalmazhat. Több master használata akkor ajánlott, ha a különböző szakaszok különböző vizuális rendszereket vagy márkázást igényelnek.

**Helyőrzőket a master slide-hoz vagy a layout slide-hoz kellene hozzáadni?**

A legtöbb esetben a helyőrzőket a layout diákhoz kell hozzáadni. A közös vizuális elemeket és formázást a master slide-on helyezze el, majd a tartalmi helyőrzőket a olyan layout diákra helyezze, amelyeket a normál diák használnak.

**Törölhetek olyan master diát, amely még használatban van?**

Nem. Egy olyan master slide, amelynek függő diái vannak, nem távolítható el közvetlenül. Először helyezze át ezeket a diát egy másik master alá tartozó layoutokra, vagy használja a felhasználatlan masterok tisztítására szolgáló módszert, amely csak a nem használt masterokat távolítja el.