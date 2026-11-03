---
title: Prezentációs helyőrzők kezelése JavaScript-ben
linktitle: Helyőrzők kezelése
type: docs
weight: 10
url: /hu/nodejs-java/manage-placeholder/
keywords:
- helyőrző
- szöveg helyőrző
- kép helyőrző
- diagram helyőrző
- tartalom helyőrző
- prompt szöveg
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan ellenőrizheti és szerkesztheti a szöveg, kép, diagram és tartalom helyőrzőket, valamint hogyan értheti meg a helyőrző öröklődést az Aspose.Slides for Node.js segítségével Java-n keresztül."
---
## **Áttekintés**

A placeholder egy alakzat, amely egy adott típusú tartalom számára helyet foglal előre egy prezentációs sablonban. Gyakori példák a cím, törzs, kép, diagram és általános tartalom placeholder-ek. A szokásos alakzattól eltérően a placeholder örökölheti a pozícióját, méretét, formázását és egyéb beállításait az elrendezési dia vagy a mesterdia által.

Az Aspose.Slides a placeholder információkat a [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) metóduson keresztül teszi elérhetővé. A metódus egy [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) objektumot vagy `null`-t ad vissza egy normál alakzat esetén. Használja a [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) metódust annak meghatározásához, hogy a placeholder milyen tartalomra van szánva.

Az alakzat osztálya továbbra is fontos, miután ismeri a placeholder típusát:

- Egy üres szöveg, kép, diagram vagy tartalom placeholder-t általában egy [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) képviseli.
- Egy kitöltött kép placeholder-t egy [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) képviselheti.
- Egy kitöltött diagram placeholder-t egy [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) képviselheti.
- Egy tartalom placeholder többféle tartalmat is tartalmazhat. Ellenőrizze a [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) és a futásidejű alakzat osztályát is, ahelyett, hogy azt feltételezné, hogy minden placeholder egy [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) leírja egy placeholder szerepét; nem garantálja az alakzat futásidejű típusát. Mindig végezzen típusellenőrzést, mielőtt szöveghez, képhez, diagramhoz, táblázathoz vagy médiaspecifikus tagokhoz férne hozzá.
{{% /alert %}}

## **A placeholder öröklődésének megértése**

A placeholder-ek hierarchiát alkotnak:

1. A mesterdia újrahasználható stílusokat definiál, és egyes esetekben mester szintű placeholder-eket is.
2. Az elrendezési dia meghatározza a egy vagy több normál dia által használt elrendezést, és örökölhet a mestertől.
3. A normál dia tartalmazza az adott dia placeholder-eit, és örökölhet az elrendezésétől.

Hívja a [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) metódust, hogy egy szinttel feljebb lépjen ebben a hierarchiában. Egy dia placeholder általában a hozzá tartozó elrendezési placeholder-t adja vissza; egy elrendezési placeholder visszaadhatja a mester placeholder-t. A metódus `null`-t ad vissza, ha az alakzatnak nincs alap placeholder-e.

A következő példa felsorolja az első dián lévő placeholder-eket, és jelentéseket készít az alap placeholder-eikről:

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

Egy placeholder szerkesztése egy normál dián helyi felülbírálást hoz létre vagy módosít az adott diára vonatkozóan. A kapcsolódó elrendezés vagy mester szerkesztése hatással lehet minden olyan diára, amely még örökli ezt a beállítást. Egy helyi, szokásos alakzatnak nincs alap placeholder-e, és nem kezd el örökölni csak azért, mert ugyanazokat a koordinátákat foglalja el.

## **Placeholder állapotának eltávolítása**

Sablon módosításakor használja a [Shape.removePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#removePlaceholder) metódust, hogy egy meglévő objektumot szokásos alakzattá alakítson. A [getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) metódusa `null`-t ad vissza, de az alakzat továbbra is a dia gyűjteményében marad. Ezzel szemben a [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#remove) törli az alakzatot a gyűjteményből.

A következő példa `template.pptx` fájlt igényel, amely legalább egy diát és egy nem üres szöveg placeholder-t tartalmaz az első dián. Használjon egy placeholder-t, amely formázást örököl az elrendezéséből vagy a mesteréből, hogy lássa a kapcsolat eltávolításának hatását. A példa ellenőrzi, hogy ugyanaz az alakzat megmarad, újból meghívja a metódust a most már szokásos alakzaton, és menti az eredményt.

{{% alert color="warning" title="Warning" %}}
A placeholder állapotának eltávolítása nem őrzi meg automatikusan az örökölt megjelenési beállításokat. Az alábbi példa szándékosan változatlanul hagyja ezeket a beállításokat, ezért a kimenet másként nézhet ki. Egy alakzat, amelynek pozíciója és mérete teljesen örökölt, a hívás után null koordinátákat és méreteket kaphat, és láthatatlanná válhat, még akkor is, ha a gyűjteményben marad.
{{% /alert %}}

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapes = slide.getShapes();
    let found = false;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || textFrame == null) {
            continue;
        }

        const text = textFrame.getText();
        if (text == null || text.length === 0) {
            continue;
        }

        const shapeCount = shapes.size();
        shape.removePlaceholder();

        console.log("Placeholder removed: " + (shape.getPlaceholder() == null));
        const retainedShape = shapes.get_Item(index);
        console.log("Same shape retained: " + shape.equals(retainedShape));
        console.log("Shape count unchanged: " + (shapes.size() === shapeCount));

        // A módszer hívása egy szokásos alakzaton nincs hatással.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Egyező placeholder esetén mindhárom ellenőrzés `true`-t ír ki. A szöveg megmarad, de az örökölt pozíció, méret, forgatás, betűtípus, bekezdésigazítás, szövegkeret margók, függőleges rögzítés, kitöltés és vonal beállítások változhatnak, amikor a placeholder kapcsolatot eltávolítják. Például az örökölt címformázás visszatérhet a szokásos szövegformázáshoz. További információkért lásd a [Slide Layout](/slides/hu/nodejs-java/slide-layout/) oldalt.

Az elvárt megjelenés megőrzéséhez a hívás előtt rögzítse a kiszámított pozíciót, méretet és forgatást, majd másolja a szükséges hatékony formázási értékeket külön változókba. Ezeket az értékeket a [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getEffective) és [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective) metódusokkal szerezze be. Ne csak a hatékony formátum objektumokra hagyatkozzon, mivel a szövegformázási értékek a kapcsolat eltávolítása után megváltozhatnak. Alkalmazza kifejezetten a rögzített értékeket a szokásos alakzatra később, beleértve a betűcsaládot, méretet, stílust, színt, bekezdés beállításokat, szövegkeret beállításokat, kitöltést és vonalat, amelyet a sablon használ.

Az örökölt alakzat geometriáját is egyértelműen meg kell adni a [GeometryShape.setShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setShapeType) segítségével. Egy téglalap alakú szöveg placeholder esetén ez azt jelenti, hogy a [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/#Rectangle) értéket kell beállítani; csak a kitöltés és a vonal visszaállítása nem biztos, hogy visszaállítja a látható téglalapot. További effektekkel vagy összetettebb formázással rendelkező sablonok esetén ezeket a beállításokat is kezelni kell.

## **Szöveg módosítása egy placeholder-ben**

A cím, középre igazított cím, alcím, törzs és szöveg placeholder-ek általában támogatják a szöveget. Ellenőrizze, hogy [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) van-e, mielőtt a [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) metódusát használná.

Ez a példa frissíti az első dián az első cím placeholder-t, majd menti az eredményt:

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

Ez a minta elkerüli, hogy a kép, diagram, táblázat vagy média placeholder-eket [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) objektumokként kezelje. Emellett a placeholder-t a célja alapján azonosítja, ahelyett, hogy egy bizonytalan alakzat indexre támaszkodna.

## **Prompt szöveg beállítása egy elrendezésen**

A prompt szöveg a tervezési időben megjelenő utasítás egy üres placeholder-ben, például *Click to add title*. Állítson be egyedi prompt szöveget az elrendezés placeholder-én, ahelyett, hogy egy normál dia alakzatgyűjteményén keresztül próbálná elérni. Az elrendezéshez a [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getLayoutSlide) metódussal férhet hozzá, és iteráljon a [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) által visszaadott gyűjteményen.

A következő példa megváltoztatja az első dián használt elrendezés cím és alcím promptjait:

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

A prompt szöveg nem a normál dia tartalma. Üres placeholder-ek szerkesztői alkalmazásokban, például a PowerPoint-ban való használatra szolgál. Amint egy felhasználó vagy program valódi tartalmat ad meg, a prompt már nem jelenik meg. A prompt módosítása nem cseréli le a már létező szöveget azon diákon, amelyek az elrendezést használják.

## **Kép placeholder frissítése**

Két esetet kell kezelni:

- Ha a kép placeholder már ki van töltve és egy [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) által van képviselve, cserélje ki a képet a [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), a [PictureFillFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#getPicture) és a [Picture.setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage) használatával.
- Ha még üres placeholder-ről van szó, adjon hozzá egy képkeretet a placeholder koordinátáihoz a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) segítségével, és távolítsa el az üres placeholder-t.

A következő példa támogatja mindkét esetet, és menti a prezentációt:

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

Az üres placeholder-hez létrehozott csere egy helyi képkeret, nem új placeholder, mivel a [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) nem biztosít beállítót. Megőrzi a fenntartott pozíciót, de már nem örököl placeholder-specifikus viselkedést. Ha a placeholder kapcsolata megtartása lényeges, először készítse el és töltse fel a placeholder-t a PowerPoint-ban, majd frissítse a kapott [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) objektumot az Aspose.Slides segítségével.

A kép átlátszóságához, vágásához és egyéb kép-specifikus effektusokhoz lásd a [Manage Picture Frames](/slides/hu/nodejs-java/picture-frame/) cikket. Ezek a műveletek a képkerethez vagy a képkitöltéshez tartoznak, nem a placeholder metaadatokhoz.

## **Diagram és tartalom placeholder-ek kezelése**

Egy kitöltött diagram placeholder-t egy [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) képvisel. Ez a példa megtalálja egy ilyen diagramot mind placeholder típusa, mind futásidejű osztálya alapján, megváltoztatja a címét, és elmenti a fájlt:

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

Egy általános tartalom placeholder általában [PlaceholderType.Object](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Object) típussal rendelkezik. PowerPoint-ban ez többféle tartalomtípus indítójaként működik, beleértve a diagramokat, táblázatokat, diagrammákat, képeket és médiát. Miután feltöltötték, vizsgálja meg a tényleges alakzat osztályát, hogy megtudja, mi van benne. Specializált elrendezések is megjeleníthetik a [PlaceholderType.Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Media) vagy [PlaceholderType.Diagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Diagram) típusokat.

Az Aspose.Slides nem konvertál egy üres [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) placeholder-t [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) objektummá csak a [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) módosításával; a típust az objektumon keresztül nem lehet megváltoztatni. Egy üres diagram vagy tartalom terület programozott feltöltéséhez adja hozzá a szükséges objektumot a placeholder koordinátáihoz, majd távolítsa el az üres placeholder-t. A következő példa ezt teszi egy diagramra:

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

A hozzáadott diagram egy szokásos helyi diagram. Elfoglalja a placeholder területét, de nem örököl az elrendezés placeholder-étől. Használja a dedikált [chart management articles](/slides/hu/nodejs-java/powerpoint-charts/) cikkeket, amikor a kategóriákat, sorozatokat vagy munkafüzet adatokat kell cserélni.

## **Teljes példa: Szöveg vagy kép tartalom frissítése**

A következő végponttól végpontig tartó példa megnyit egy sablont, az első dián keresi a cím vagy kép placeholder-t, ellenőrzi a placeholder és az alakzat típusát, frissíti a megfelelő tartalmat, és menti a kimenetet. A példa szándékosan elkerüli a shape index feltételezését vagy annak feltételezését, hogy minden placeholder ugyanaz az osztály.

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

**Mi az az alap placeholder?**

Az alap placeholder az elrendezési vagy mester dián lévő megfelelő alakzat, amelyből egy másik placeholder örököl. Használja a [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) metódust a lekérdezéséhez. Egy szokásos helyi alakzat `null`-t ad vissza, mivel nem része a placeholder hierarchiának.

**Módosíthatom az összes dia címét egy elrendezés placeholder szerkesztésével?**

Örökölt formázást vagy prompt szöveget módosíthat egy elrendezésen keresztül, de a meglévő cím tartalom a normál diáknál van tárolva. A tényleges cím szöveg cseréjéhez egy prezentációban, iteráljon a diákon, és frissítse minden cím placeholder-t.

**Hogyan kezelem a dátum, dia-szám, fejléc és lábléc placeholder-eket?**

Használja a fejléc és lábléc kezelőket a megfelelő dia, elrendezés, mester, jegyzet vagy anyag környezetben. Lásd a [Manage Presentation Header and Footer](/slides/hu/nodejs-java/presentation-header-and-footer/) oldalt a teljes példákért.