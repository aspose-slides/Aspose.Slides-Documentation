---
title: Képi transzformációs hatások kezelése prezentációkban JavaScript-tel
linktitle: Képi transzformációs hatások
type: docs
weight: 11
url: /hu/nodejs-java/image-transform-effects/
keywords:
- kép transzformáció
- kép effektus
- fényerő
- kontraszt
- szürkeárnyalat
- duotone
- színárnyalat
- HSL
- színcsere
- elmosás
- átlátszóság
- alfa hatás
- hatáslánc
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Az Aspose.Slides for Node.js segítségével Java-n keresztül alkalmazza, láncolja, vizsgálja, távolítsa el és ellenőrizze a képi transzformációs hatásokat képkeretekhez."
---
## **Áttekintés**

Az Aspose.Slides a képi módosításokat egy rendezett **ImageTransformOperationCollection**‑ben tárolja. Egy képkockához a [Picture](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picture/) objektummal kezdjünk, majd hívd meg a [Picture.getImageTransform](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picture/) metódust. A visszakapott [ImageTransformOperationCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) lehetővé teszi hatások hozzáfűzését, felsorolását, vizsgálatát, eltávolítását és törlését anélkül, hogy az eredeti kép bájtjait újraírnánk.

Ez a cikk bemutat egy teljes munkafolyamatot a fényerő és kontraszt, színátalakítások, elmosás, átlátszóság, rendezett hatásláncok, hatékony értékek, eltávolítás és PPTX kerekút‑ellenőrzés használatával.

## **A hatások tulajdonjogának és a kép újrahasznosításának megértése**

A képadatforrás és a megjelenítő kép két külön objektum:

- A [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) tárolja vagy hivatkozik a prezentáció által birtokolt forrás képadatokra.
- A [Picture](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picture/) egy képkitöltéshez tartozik, hivatkozik egy képadatra, és tárolja a kép‑transformációs gyűjteményt.
- A [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) a dián lévő alakzat, amely birtokolja a megfelelő képkitöltést, geometriát, vágási beállításokat és egyéb keret‑szintű formázásokat.

Ezért a kép‑transformációs műveletek **nem** módosítják a [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) bájtjait. Ha ugyanazt a [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) objektumot többször adjuk át a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/) metódusnak, minden új képkocka saját [Picture](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picture/) objektummal és saját transformációs gyűjteménnyel kapja meg. Egy keretre alkalmazott szürkeskála hatás **nem** teszi szürkésre a többi keretet, bár mindegyik ugyanazt a beágyazott képadatforrást használja.

Ugyanez a [Picture.getImageTransform](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picture/) modell más képkitöltéseknél is elérhető, például egy alakzat vagy dia háttérnél. Az alábbi példák a képkockákra koncentrálnak.

## **Érvényes paramétertartományok és mértékegységek használata**

A bemutatott metódusok a következő szemantikus tartományokkal és mértékegységekkel dolgoznak. Tartsd be ezeket a tartományokat még akkor is, ha egy adott könyvtárverzió nem utasítja el azonnal a határon kívül eső értékeket; a célprezentáció formátuma normalizálhat, elhagyhat vagy visszautasíthat érvénytelen adatokat mentéskor vagy PowerPoint megnyitásakor.

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100`‑tól `100`‑ig, százalék; `0` változatlanul hagyja az összetevőt. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) | None | Nincs numerikus paraméter. Az alfa változatlan. |
| [addDuotoneEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Két szín a sötét és a világos pixelekhez. Az `java.awt.Color` RGB és alfa csatornái `0`‑tól `255`‑ig terjednek. |
| [addTintEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | A színárnyalat `0`‑tól `360`‑ig (exkluzív) fokban; az erősség `-100`‑tól `100`‑ig, százalék. |
| [addHSLEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | A színárnyalat `0`‑tól `360`‑ig fokban; a telítettség és a fényesség `-100`‑tól `100`‑ig, százalék. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | A helyettesítő szín csatornaértékei `0`‑tól `255`‑ig terjednek. A meglévő alfa értékek változatlanok. |
| [addBlurEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | A sugár nemnegatív és pontban van megadva; a `grow` logikai érték, amely azt szabályozza, hogy az elmosott tartalom kiterjedhet‑e az eredeti határokon kívülre. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Nemnegatív százalék. Használj `0`‑tól `100`‑ig a szokásos átlátszatlanság‑skálázáshoz: `0` teljesen átlátszó, `100` megőrzi a meglévő alfat. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0`‑tól `100`‑ig, százalékos átlátszatlanság. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0`‑tól `100`‑ig, százalékos alfa küszöb. Az alatta lévő értékek átlátszóvá válnak; a küszöbnél nagyobb vagy egyenlő értékek átlátszatlanok. |

Az állandó alfa‑moduláció esetén az átlátszóság és az átlátszatlanság egymás kiegészítői. Például a 35 % átlátszóság 65 % alfa‑modulációs értéknek felel meg.

## **Fényerő és kontraszt alkalmazása**

Az [ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) egy [BrightnessContrast](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/brightnesscontrast/) műveletet ad vissza. A skalár beállítások a művelet létrehozásakor kerülnek megadásra. A [BrightnessContrast.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/brightnesscontrast/) számított, csak‑olvasásra szánt értékeket ad, amelyek ellenőrizhetők vagy naplózhatók.

Az alábbi példa 15 %‑kal növeli a fényerőt és 20 %‑kal a kontrasztot, majd előnézetet jelenít meg anélkül, hogy a beágyazott képet módosítaná:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

A [BrightnessContrast](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/brightnesscontrast/) egy Office 2010‑es kép‑effekt kiterjesztés, amely kevésbé hordozható, mint a szabványos DrawingML‑fényerő effektus. Ha a fényerő‑kontraszt beállításoknak PPTX kerekúton is szerkeszthetőnek kell maradniuk, használd a [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) metódust, és ellenőrizd az eredményt a fájl újbóli megnyitásakor. A formátum‑korlátozások szakasz részletesebben kifejti ezt a különbséget.

## **Színátalakítások alkalmazása**

A szín‑effektusok függetlenül alkalmazhatók különböző képkockákon, amelyek ugyanazt a képadatforrást használják. Az alábbi példa öt keretet hoz létre, és szürkeárnyalatos, duotone, színárnyalat (tint), HSL‑korrekció és színcsere hatásokat alkalmaz rájuk.

A [Duotone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/duotone/) két önállóan szerkeszthető színparamétert tartalmaz: a `color1` a sötét pixeleket, a `color2` a világos pixeleket szabályozza. Ez egy olyan példa, amelynek beállításai összetettebbek egy egyszerű skalár értéknél.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az [addColorReplaceEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) minden pixel színét egy rögzített színre cseréli, miközben megőrzi az alfat. Ez különbözik az [addColorChangeEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/)‑től, amely egy forrás‑színt egy másikra map‑el, és mind a forrás, mind a cél színformátumot kiírja.

## **Elmosás, átlátszóság és alfa‑effektusok hozzáadása**

Az [addBlurEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) minden színcsatornát, beleértve az alfát is, érinti. Állítsd a `grow` értékét `true`‑ra, ha az elmosott szélek túlnyúlhatnak az eredeti kép határain.

Az egyenletes átlátszósághoz használd az [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) metódust. Ez minden meglévő alfa‑értéket megszoroz, így a részben átlátszó pixelek relatív arányban maradnak. Az [addAlphaReplaceEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) ehelyett egyetlen alfa‑értéket rendel minden pixelhez. Az [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) a küszöb alapján két szintre képezi le az alfat.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Más, paraméter‑szabad alfa‑műveletek közé tartozik az [addAlphaCeilingEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/), amely minden nem nulla alfat teljesen átlátszatlanná teszi; az [addAlphaFloorEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/), amely minden 100 % alatti alfat teljesen átlátszóvá alakít; valamint az [addAlphaInverseEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/), amely az alfat `100 % - alfa`‑ra változtatja.

## **Rendezett hatáslánc építése**

Minden `add...Effect` metódus egy új műveletet fűz a gyűjtemény végéhez. A renderelő a gyűjteményt egy rendezett csővezetéként használja: az 0‑ás művelet kimenete az 1‑es bemenete lesz, és így tovább. Ezért a műveletek sorrendje meghatározza a végeredményt.

Például a szürkeárnyalat‑után‑színárnyalat (tint) először eltávolítja a kromatikus információt, majd a luminancia‑eredményt színezi újra. A színárnyalat‑után‑szürkeárnyalat viszont visszafordítja a színárnyalatot. Hasonlóképpen az alfa‑helyettesítés felülírhatja a korábbi műveletek által számított alfa‑értékeket, míg az alfa‑moduláció megőrzi azok relatív különbségét.

Az alábbi példa egy négyművelet‑láncot épít, PPTX‑ként ment, újra megnyitja a prezentációt, ellenőrzi a művelettípusokat és sorrendet, majd rendereli a újból megnyitott eredményt:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

A gyűjtemény nem kényszerít komptabilitási mátrixot, amely szín‑, alfa‑ és elmosás‑műveleteket külön láncokra korlátozna. Kombinálhatók, de a kombinációk nem mindig hasznosak. Egy rögzített színcsere eltávolítja az előző szín‑effektusok által létrehozott RGB‑variációt; a szürkeárnyalat duotone után eltávolítja a kiválasztott két színt; az alfa‑ceiling, floor, replace vagy bi‑level műveletek eldobhatják a korábban létrehozott alfa‑részleteket. Építsd a láncot a kívánt pixel‑feldolgozási sorrend szerint, ne pedig rendezetlen formázási jelzők halmazaként.

## **Szerkeszthető és hatékony értékek vizsgálata**

A szerkeszthető művelet az objektum, amely a [Picture.getImageTransform](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picture/)‑ben tárolódik. A hatástól függően közvetlenül elérhetőek írható tagok. Például a [Blur](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/blur/) a `radius` és `grow` értékeket teszi írhatóvá, az [AlphaModulateFixed](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/alphamodulatefixed/) az `amount`‑ot, az [AlphaBiLevel](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/alphabilevel/) a `threshold`‑ot. A [Duotone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/duotone/) például módosítható [ColorFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/colorformat/) objektumokat ad.

Néhány művelet – például a [BrightnessContrast](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/brightnesscontrast/), a [HSL](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/hsl/), a [Tint](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tint/) és az [AlphaReplace](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/alphareplace/) – nem teszi írhatóvá a létrehozáskor megadott skalár‑értékeket. Ilyen beállítások módosításához távolítsd el a műveletet, és adj hozzá egy újat a kívánt pozícióban.

A `getEffective()` által visszaadott hatékony adatok számítottak és csak‑olvasásra szántak. Használhatók témától függő színek feloldására és a renderelő által használt normalizált értékek kiolvasására, de nem jelentenek szerkeszthető réteget. Az alábbi példa felsorolja a láncot, és megvizsgálja a hatékony értékeket, ahol az API biztosítja azokat:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

A paraméter‑szabad hatások, például a szürkeárnyalat, alfa‑ceiling vagy alfa‑inverse, szintén rendelkeznek hatékony‑adat objektummal, de nincs kiírható skalár‑beállításuk. Jelenlétük és pozíciójuk a gyűjteményben a fontos információ.

## **Kép‑transformációk eltávolítása vagy törlése**

Használd a [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) metódust egy művelet index szerinti eltávolításához. Mivel az indexek az eltávolítás után eltolódnak, előbb keresd meg a kívánt elemet, majd a felsorolás után távolítsd el. A [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) a teljes lánc eltávolítására szolgál.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

A transformációk eltávolítása vagy törlése csak a kép formázását változtatja meg. Nem törli, tömöríti újra vagy módosítja a újrahasznált [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) forrást.

## **Prezentációs formátumok és exportcélok figyelembe vétele**

A kép‑transformációk a DrawingML‑ből származnak, ezért a PPTX a leginkább szerkeszthető formátum a hatásláncok számára. Még PPTX‑nél sem minden művelet rendelkezik azonos hordozhatósággal:

- A szabványos DrawingML‑műveletek, mint a luminancia, szürkeárnyalat, duotone, tint, HSL, elmosás és a gyakori alfa‑műveletek a legnagyobb eséllyel maradnak meg egy PPTX‑kerekúton. Mindig nyisd meg a generált fájlt újra, és ellenőrizd a gyűjteményt, ha a megőrzés elvárás.
- A [BrightnessContrast](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/brightnesscontrast/) egy Office 2010‑es kiterjesztés, nem a szabványos DrawingML luminancia művelet. Használható memória‑beli rendereléshez, de nem garantált, hogy szerkeszthető [BrightnessContrast](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/brightnesscontrast/) művelet marad a PPTX mentése és újbóli megnyitása után. Inkább használd az [addLuminanceEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/)‑et a tartós fényerő‑kontraszt beállításokhoz.
- A régi PPT bináris formátum megelőzi a teljes DrawingML‑effektus modellt. PPT‑ként mentés elhagyhat nem támogatott műveleteket, csökkentheti a láncot egy támogatott részhalmazra, vagy közelítő megjelenést hozhat létre. Ne használj PPT‑t ellenőrzési formátumként összetett szerkeszthető láncokhoz.
- PNG, JPEG, TIFF, PDF, SVG, HTML vagy más vizuális kimenet a támogatott láncot alkalmazza a megjelenített eredményre. Ezek a kimenetek nem tartalmaznak szerkeszthető [ImageTransformOperationCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagetransformoperationcollection/) objektumot; a raszteres formátumok lapítják a végeredményt pixel‑szinten, a dokumentum/vektor exportok saját renderelési reprezentációt tárolnak.
- Az effektek nem teszik önállóvá a hivatkozott képet. Egy linkelt kép renderelése továbbra is a hivatkozott erőforrás elérhetőségétől függ, amikor a prezentáció betöltődik.

A különböző prezentációs fogyasztók eltérően kezelhetik a szél‑eseteket, különösen több alfa‑ vagy szín‑kvantálási művelet kombinálásakor. Kritikus kimeneteknél teszteld mind a szerkeszthető kerekútot, mind a végső export formátumot ugyanazzal az Aspose.Slides verzióval, amelyet a termelésben használsz.

## **GYIK**

**Módosítják a képtároló hatások a beágyazott képadataikat?**

Nem. A műveletek a [Picture](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picture/) objektumhoz tartoznak, amely a képkitöltést használja. A mögöttes [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) bájtjai változatlanok maradnak.

**Két képkocka, amely ugyanazt a képet használja, megosztja a hatásokat?**

Nem. A [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) újrafelhasználása elkerüli a képadat duplikálását, de minden képkocka általában saját [Picture](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picture/) és saját kép‑transformációs gyűjteménnyel rendelkezik.

**Kombinálhatók a szín‑, elmosás‑ és alfa‑effektek?**

Igen. A gyűjtemény egy rendezett láncban fogadja őket. Vedd figyelembe, hogy az egyes műveletek hogyan befolyásolják az előző kimenetét, mivel a helyettesítő és küszöb‑műveletek eldobhatják a korábbi szín‑ vagy alfa‑részleteket.

**Miért csak‑olvasásúak a hatékony értékek?**

A hatékony adatok a rendereléshez használt számított értékeket tartalmazzák, beleértve a feloldott színeket is. Szerkeszd a transformációs gyűjteményben tárolt műveletet, ahol vannak írható tagok; egyébként távolítsd el, és adj hozzá egy újat az új létrehozási paraméterekkel.

**Melyik formátumot válasszam a transformációs lánc megőrzéséhez?**

Használd a PPTX‑et, és ellenőrizd a fájlt újbóli megnyitással. A régi PPT nem képes a teljes DrawingML‑effektus modellt reprezentálni, míg a renderelt export formátumok csak a megjelenést őrzik meg, nem pedig a szerkeszthető transformációs műveleteket.