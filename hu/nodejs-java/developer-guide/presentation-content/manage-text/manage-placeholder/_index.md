---
title: Prezentációhelyőrzők kezelése JavaScriptben
linktitle: Helyőrzők kezelése
type: docs
weight: 10
url: /hu/nodejs-java/manage-placeholder/
keywords:
- helyőrző
- szöveghelyőrző
- képhelyőrző
- diagramhelyőrző
- tartalomhelyőrző
- prompt szöveg
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Tanulja meg, hogyan ellenőrizheti és szerkesztheti a szöveg-, kép-, diagram- és tartalomhelyőrzőket, valamint megértheti a helyőrzők öröklődését az Aspose.Slides for Node.js segítségével Java-n keresztül."
---
## **Áttekintés**

A helyőrző egy alakzat, amely helyet tart fenn egy adott típusú tartalom számára egy prezentációs sablonban. Gyakori példák a cím, a törzs, a kép, a diagram és az általános célú tartalomhelyőrzők. A hagyományos alakzattal ellentétben a helyőrző örökölheti a pozícióját, méretét, formázását és egyéb beállításait egy elrendezési vagy fő diából.

Aspose.Slides a helyőrző információt a [Shape.getPlaceholder](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getPlaceholder) metódussal teszi elérhetővé. A metódus egy [Placeholder](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/placeholder/) objektumot ad vissza, vagy `null`‑t egy normál alakzat esetén. Használja a [Placeholder.getType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/placeholder/#getType) metódust annak meghatározásához, hogy a helyőrző milyen tartalmat szolgál ki.

Az alakzat osztálya továbbra is fontos, miután ismerjük a helyőrző típusát:

- Egy üres szöveg, kép, diagram vagy tartalomhelyőrző általában egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/)-ként van ábrázolva.
- Egy kitöltött képhelyőrző egy [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/)-ként jelenhet meg.
- Egy kitöltött diagramhelyőrző egy [Chart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/)-ként jelenhet meg.
- Egy tartalomhelyőrző különböző típusú tartalmakat is tartalmazhat. Ellenőrizze mind a [Placeholder.getType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/placeholder/#getType) értékét, mind a futás‑időbeni alakzat osztályát, ahelyett hogy azt feltételezné, hogy minden helyőrző egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/placeholder/#getType) leírja a helyőrző szerepét; nem garantálja az alakzat futás‑időbeni típusát. Mindig végezzen típusellenőrzést, mielőtt szövegszöveget, képet, diagramot, táblát vagy médiára vonatkozó tagot érne el.
{{% /alert %}}

## **A helyőrző öröklődés megértése**

A helyőrzők hierarchiát alkotnak:

1. A fő dia definiálja az újrahasználható stílusokat, és bizonyos esetekben fő‑szintű helyőrzőket is.
2. Az elrendezési dia határozza meg az elrendezést, amelyet egy vagy több normál dia használ, és örökölhet a fő diáktól.
3. Egy normál dia tartalmazza saját helyőrzőit, és örökölhet az elrendezésétől.

Hívja meg a [Shape.getBasePlaceholder](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getBasePlaceholder) metódust a hierarchia egy szinttel feljebb történő lépéshez. Egy diára vonatkozó helyőrző általában visszaadja az elrendezési helyőrzőt; egy elrendezési helyőrző visszaadhatja a fő helyőrzőt. A metódus `null`‑t ad vissza, ha az alakzatnak nincs alap‑helyőrzője.

A következő példa felsorolja az első dián található helyőrzőket és jelentést ad azok alap‑helyőrzőiről:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Egy helyőrző szerkesztése egy normál dián helyi felülírást hoz létre vagy módosít azon a dián. A kapcsolódó elrendezés vagy fő szerkesztése minden olyan diára hatással lehet, amely még örökli ezt a beállítást. Egy helyi, egyszerű alakzatnak nincs alap‑helyőrzője, és nem kezd el öröklődni csak azért, mert ugyanazokat a koordinátákat foglalja el.

## **Szöveg módosítása egy helyőrzőben**

Cím, középre helyezett cím, alcím, törzs és szöveghelyőrzők általában támogatják a szöveget. Ellenőrizze, hogy az alakzat [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/)-e, mielőtt a [getTextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/#getTextFrame) metódust használja.

Ez a példa frissíti az első dián található első címhelyőrzőt, majd elmenti az eredményt:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ez a minta elkerüli, hogy a kép, diagram, táblázat vagy média helyőrzőket [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumként kezelje. Emellett a helyőrzőt a célja szerint azonosítja, a sérülékeny alakzatindex helyett.

## **Prompt szöveg beállítása egy elrendezésen**

A prompt szöveg a tervezési időben megjelenő útmutatás egy üres helyőrzőben, például *Kattintson a cím hozzáadásához*. Állítson be egyedi prompt szöveget az elrendezési helyőrzőn, ahelyett hogy a normál dia alakzatgyűjteményén keresztül próbálná elérni. Az elrendezéshez a [Slide.getLayoutSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#getLayoutSlide) segítségével férhet hozzá, és iteráljon a [BaseSlide.getShapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslide/#getShapes) által visszaadott gyűjteményen.

A következő példa módosítja az első dián használt elrendezés cím és alcím promptjait:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A prompt szöveg nem normál dia tartalom. Üres helyőrzők szerkesztő alkalmazásokban, például a PowerPointban jelenik meg. Amint a felhasználó vagy a program valódi tartalmat ad meg, a prompt már nem jelenik meg. A prompt módosítása nem írja felül a már létező szöveget azon diákon, amelyek a layoutot használják.

## **Képhelyőrző frissítése**

Két esetet kell kezelni:

- Ha a képhelyőrző már kitöltött és egy [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) képviseli, cserélje ki a képet a [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), a [PictureFillFormat.getPicture](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#getPicture) és a [Picture.setImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picture/#setImage) metódusokkal.
- Ha még üres helyőrző, adjon egy képkeretet a helyőrző koordinátáiban a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) használatával, majd távolítsa el az üres helyőrzőt.

A következő példa mindkét esetet támogatja, és elmenti a bemutatót:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az üres helyőrzőre létrehozott csere egy helyi képkeret, nem egy új helyőrző, mivel a [Shape.getPlaceholder](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getPlaceholder) nem biztosít beállítót. Megtartja a lefoglalt pozíciót, de már nem örököl helyőrző‑specifikus viselkedést. Ha a helyőrzőkapcsolat megőrzése lényeges, először a PowerPointban hozza létre és töltse fel a helyőrzőt, majd frissítse a kapott [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) objektumot az Aspose.Slides‑kel.

Képátlátszóságért, vágáshoz és egyéb kép‑specifikus hatásokért lásd a [Manage Picture Frames](/slides/hu/nodejs-java/picture-frame/) cikket. Ezek a műveletek a képkerethez vagy képkitöltéshez tartoznak, nem a helyőrző metaadataihoz.

## **Diagram és tartalomhelyőrzőkkel való munka**

Egy kitöltött diagramhelyőrző egy [Chart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/) objektummal ábrázolható. Ez a példa a helyőrző típusa és a futás‑időbeni osztály alapján keresi meg a diagramot, módosítja a címét, majd elmenti a fájlt:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Egy általános tartalomhelyőrző általában a [PlaceholderType.Object](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/placeholdertype/#Object) értékkel rendelkezik. A PowerPointban ez egy indítóként működik több tartalomtípushoz, köztük diagramokhoz, táblázatokhoz, diagramokhoz, képekhez és médiához. Kitöltés után ellenőrizze a tényleges alakzat osztályát, hogy megtudja, mi van benne. Specializált elrendezések a [PlaceholderType.Chart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/placeholdertype/#Media) vagy [PlaceholderType.Diagram](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/placeholdertype/#Diagram) típusokat is felfedhetnek.

Az Aspose.Slides nem alakít át egy üres [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) helyőrzőt [Chart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/) objektummá pusztán a [Placeholder.getType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/placeholder/#getType) módosításával; a típust nem lehet az objektumon keresztül megváltoztatni. Üres diagram vagy tartalom terület programozott feltöltéséhez adja hozzá a szükséges objektumot a helyőrző koordinátáiban, majd távolítsa el az üres helyőrzőt. A következő példa ezt diagramra alkalmazza:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A hozzáadott diagram egy egyszerű helyi diagram. Elfoglalja a helyőrző területét, de nem örököl az elrendezési helyőrzőtől. Használja a dedikált [chart management articles](/slides/hu/nodejs-java/powerpoint-charts/) cikkeket, ha a diagram kategóriáit, sorozatait vagy munkafüzetadatait kell cserélni.

## **Teljes példa: Szöveg vagy kép tartalom frissítése**

Az alábbi vég‑végi példa megnyit egy sablont, az első dián keres egy cím‑ vagy képhelyőrzőt, ellenőrzi a helyőrző és az alakzat típusát, frissíti a megfelelő tartalmat, és elmenti a kimenetet. A példa szándékosan kerül el egy alakzatindex feltételezését vagy minden helyőrző egyforma osztályként való kezelést.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Mi az alap helyőrző?**

Az alap helyőrző a layout vagy master megfelelő alakzata, amelyből egy másik helyőrző örököl. Az [Shape.getBasePlaceholder](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getBasePlaceholder) metódussal kérhető le. Egy egyszerű helyi alakzat `null`‑t ad vissza, mivel nem része a helyőrző hierarchiának.

**Módosíthatom-e az összes diacímeket egy elrendezés helyőrzőjének szerkesztésével?**

Az örökölt formázást vagy a prompt szöveget egy elrendezésen keresztül módosíthatja, de a meglévő cím tartalom a normál diákon van tárolva. A címek tényleges szövegének cseréjéhez iteráljon a diákon, és frissítse minden egyes címhelyőrzőt.

**Hogyan kezelem a dátum, dia szám, fejléc és lábléc helyőrzőket?**

Használja a fejléc‑ és lábléckezelőket a megfelelő dián, layouton, főn, jegyzeten vagy kiosztási környezetben. Lásd a [Manage Presentation Header and Footer](/slides/hu/nodejs-java/presentation-header-and-footer/) cikket a teljes példákért.