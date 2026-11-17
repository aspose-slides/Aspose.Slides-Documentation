---
title: Képek transzformációs hatásainak kezelése prezentációkban JavaScript-tel
linktitle: Képtranszformációs hatások
type: docs
weight: 11
url: /hu/nodejs-java/image-transform-effects/
keywords:
- kép transzformáció
- kép hatás
- fényerő
- kontraszt
- szürkeárnyalat
- duotone
- színárnyalat
- HSL
- színhelyettesítés
- elmosás
- átlátszóság
- alfa hatás
- hatáslánc
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Alkalmazza, láncolja, ellenőrizze, távolítsa el, és hitelesítse a képek transzformációs hatásait képkereteknél az Aspose.Slides for Node.js segítségével JavaScript-en keresztül."
---
## **Áttekintés**

Aspose.Slides a képek beállításait rendezett gyűjteményként kép‑transzformációs műveletek formájában képviseli. Egy képkeret esetén kezdje a keret [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) elemével, és érje el a [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). A visszakapott [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) lehetővé teszi, hogy műveleteket fűzzön hozzá, sorolja fel, vizsgálja, eltávolítsa és törölje a hatásokat anélkül, hogy az eredeti képadatokat újraírná.

Ez a cikk bemutat egy teljes munkafolyamatot a fényerő és kontraszt, színátalakítások, elmosás, átlátszóság, rendezett hatákláncok, hatékony értékek, eltávolítás és PPTX körkörös ellenőrzés demonstrálására.

## **Értse meg a hatás tulajdonjogát és a kép újrafelhasználását**

Képforrás és a megjelenítő kép külön objektumok:

- [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) tárolja vagy hivatkozik a prezentáció által birtokolt forráskép adataira.
- [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) egy képkitöltéshez tartozik, és egy képforrásra hivatkozik, miközben a kép‑transzformációs gyűjteményt tárolja.
- [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) a dia alakzat, amely a megfelelő képkitöltést, geometriát, vágási beállításokat és egyéb keretszintű formázást birtokolja.

Ezért a kép‑transzformációs műveletek nem módosítják a [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) bájtjait. Amikor ugyanazt a [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) elemet többször adjuk a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) metódusnak, minden új képkeret saját [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) és saját transzformációs gyűjtemény kap. A szürkeárnyalatos átalakítás egy keretnél nem teszi a többi keretet szürkeárnyalatosra, még akkor sem, ha mindegyik ugyanazt a beágyazott képforrást használja.

Ugyanezt a [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) modellt más képkitöltések, például alakzat vagy diaháttér is használja. Az alábbi példák a képkeretekre összpontosítanak.

## **Használjon érvényes paramétertartományokat és egységeket**

A bemutatott metódusok a következő szemantikai tartományokat és egységeket használják. Tartsa a értékeket ezen tartományokban, még ha egy adott könyvtárverzió nem is utasítja el azonnal a hatótalan értékeket; a céles prezentációformátum normalizálhat, elhagyhat vagy elutasíthat érvénytelen adatot mentéskor vagy a PowerPoint megnyitásakor.

| Művelet | Paraméterek | Érvényes tartomány és egység |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100`‑tól `100`‑ig, százalék; `0` változatlanul hagyja az összetevőt. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | None | Nincs numerikus paraméter. Az alfa változatlan. |
| [addDuotoneEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Két szín a sötét és a világos képpontokhoz. Az `java.awt.Color` RGB és alfa csatornái `0`‑tól `255`‑ig terjednek. |
| [addTintEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Árnyalat `0`‑tól `360`‑ig (kizárólag), fokban; mennyiség `-100`‑tól `100`‑ig, százalék. |
| [addHSLEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Árnyalat `0`‑tól `360`‑ig, fokban; telítettség és fényerő `-100`‑tól `100`‑ig, százalék. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | A helyettesítő szín csatornaértékei `0`‑tól `255`‑ig. A meglévő alfa értékek változatlanok. |
| [addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | A sugár nemnegatív és pontban van megadva; `grow` egy logikai érték, amely azt szabályozza, hogy a elmosott tartalom kilóghat‑e az eredeti határokon kívül. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Nemnegatív százalék. Használja a `0`‑tól `100`‑ig terjedő értékeket a szokásos átlátszóság skálázásához: `0` teljesen átlátszó, `100` megőrzi a meglévő alfat. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0`‑tól `100`‑ig, százalékos átlátszóság. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0`‑tól `100`‑ig, százalékos alfa küszöb. Az alatta lévő értékek átlátszóvá válnak; a küszöbön vagy fölötte lévők átlátszatlanok. |

Az állandó alfa‑moduláció esetén az átlátszóság és az opacitás kiegészítőek. Például a 35 % átlátszóság egy 65 % alfa‑modulációs értéknek felel meg.

## **Fényerő és kontraszt alkalmazása**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) egy [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) műveletet ad vissza. Skáláris beállításait a művelet létrehozásakor adjuk meg. A [BrightnessContrast.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) számított, csak‑olvasásra szánt értékeket ad, amelyeket ellenőrizhet vagy naplózhat.

Az alábbi példa 15 %‑kal növeli a fényerőt és 20 %‑kal a kontrasztot, majd előnézetet generál anélkül, hogy módosítaná a beágyazott képet:

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

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) egy Office 2010 kép‑hatás kiegészítés, és kevésbé hordozható, mint a szabványos DrawingML fényerőhatás. Ha a fényerőt és kontrasztot PPTX körkörös után is szerkeszthetőnek kell maradnia, használja a [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) metódust, és ellenőrizze az eredményt a fájl újranyitása után. A formátumkorlátozások szakaszában részletesebben kifejtésre kerül a különbség.

## **Színátalakítások alkalmazása**

A szín‑hatásokat függetlenül lehet alkalmazni különböző képkeretekre, amelyek ugyanazt a képforrást használják. Az alábbi példa öt keretet hoz létre, és szürkeárnyalatos, duotone, színárnyalat, HSL‑korrekció, valamint színhelyettesítés hatásokat alkalmaz.

[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) két függetlenül szerkeszthető színparamétert tartalmaz: a `color1` a sötét képpontokhoz, a `color2` a világosakhoz van rendelve. Ez egy jó példa egy olyan hatásra, amelynek beállításai összetettebbek, mint egy egyszerű skáláris érték.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) minden képpont színét egy rögzített színnel helyettesíti, miközben megőrzi az alfat. Ez különbözik a [addColorChangeEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)‑tól, amely egy forrás‑színt egy másikra térképezi, és mindkét színformátumot feltárja.

### **Luminancia küszöb alkalmazása**

A luminancia‑küszöb segíthet a szkennelt oldal gyenge jelzéseit elkülöníteni a háttértől. Az [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) megtartja a köztes szürkeárnyalatokat. Az [addBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) a luminanciát fekete‑vagy‑fehérre képezi, míg az [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) egy átlátszósági küszöböt alkalmaz.

A luminancia‑küszöb 0 %‑tól 100 %-ig terjed, inkluzív. A küszöbnél alacsonyabb képpontok feketék lesznek. A küszöbön vagy fölötte lévők fehérek. A küszöb emelése több árnyalatot feketére változtat, mivel több fekete alá esik.

Töltse le a [grayscale‑swatches.png](grayscale-swatches.png) fájlt a munkakönyvtárba. Minden felirat a 0‑tól 255‑ig terjedő eredeti szürke szintet mutatja. A példa az eredetit két másolat mellé helyezi, és minden másolat küszöbét a prezentációba menti.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceImage = slides.Images.fromFile("grayscale-swatches.png");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const captions = ["Original", "Threshold 20%", "Threshold 60%"];
    const frames = [];
    for (let i = 0; i < captions.length; i++) {
        const x = 12 + 240 * i;
        const label = shapes.addAutoShape(slides.ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        const frame = shapes.addPictureFrame(slides.ShapeType.Rectangle, x, 60, 216, 72, image);
        frames.push(frame);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60);
    
    presentation.save("luminance-threshold.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nyissa meg a kimeneti prezentációt PowerPoint‑ban a három keret összehasonlításához. A 96‑os felirattal ellátott színpaletta körülbelül 38 % luminanciát (96/255) tartalmaz. 20 %‑os küszöbön fehér, 60 %‑osnál fekete lesz.

![Eredeti szürkeárnyalatos színminták a fekete‑fehér eredményekkel 20 % és 60 % luminancia‑küszöbök mellett](luminance-threshold.png)

## **Elmosás, átlátszóság és alfa‑hatások hozzáadása**

[addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) az összes színcsatornát, beleértve az alfat is, érinti. Állítsa `grow`‑t `true`‑ra, ha az elmosott él túlnyúlhat az eredeti kép határain.

Egységes átlátszósághoz használja a [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)‑t. Ez minden meglévő alfa‑értéket szorzásával működik, így a részlegesen átlátszó képpontok arányosan különbözőek maradnak. A [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) ehelyett egyetlen alfa‑értéket rendel minden képponthoz. A [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) egy küszöb alapján két alfa‑szintre konvertál.

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

Más paraméter‑nélküli alfa‑műveletek közé tartozik a [addAlphaCeilingEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), amely minden nem‑nulla alfat teljesen átlátszatlanná teszi; a [addAlphaFloorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), amely minden 100 % alatt lévő alfat teljesen átlátszóvá alakít; valamint a [addAlphaInverseEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), amely az alfat `100% - alpha`‑ra változtatja.

## **Rendezett hatáklánc felépítése**

Minden `add...Effect` metódus egy új műveletet fűz a gyűjtemény végéhez. A renderelő a gyűjteményt rendezett csővezeték‑ként használja: a 0‑s művelet kimenete lesz az 1‑es bemenete, és így tovább. Ennek következtében, ugyanazok a műveletek különböző sorrendben más képet eredményezhetnek.

Például a szürkeárnyalatos hatás tintával követve először eltávolítja a kromatikus információt, majd színezi újra a luminancia eredményt. A tintával kezdődő szürkeárnyalatos hatás pedig a tintát újra eltávolítja. Hasonlóan, az alfa‑helyettesítés felülírhatja a korábbi műveletek által kiszámított alfa‑értékeket, míg az alfa‑moduláció megőrzi azok relatív különbségét.

Az alábbi példa egy négy műveletből álló láncot épít, PPTX‑ként menti, újra megnyitja a prezentációt, ellenőrzi a művelettípusokat és azok sorrendjét, majd a megnyitott eredményt rendereli:

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

A gyűjtemény nem kényszerít kompatibilitási mátrixot, amely színeket, alfatot és elmosást külön láncokra korlátozna. Kombinálhatók, de a kombinációk nem mindig hasznosak. Egy fix színhelyettesítés eltávolítja a korábbi szín‑hatások által előállított RGB‑variációt; a duotone után alkalmazott szürkeárnyalatos hatás eltávolítja a két kiválasztott színt; és az alfa‑ceiling, floor, replace vagy bi‑level műveletek eltávolíthatják a korábban létrehozott alfa‑részleteket. A láncot a kívánt képpont‑feldolgozási sorrend szerint építse, ne pedig rendezetlen formázási jelzőként kezelje.

<!-- visual-explanation:image-transform-effects:start -->
[![Ugyanaz a kép először szürkeárnyalatos, majd színezett, illetve fordítva. A két végső szürkeárnyalatos kép különböző árnyalatú.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Ebben az Illusztrációban az Aspose.Slides for .NET 26.11 renderelés, egy 220°‑os színárnyalat 25 %‑nál a szürkeárnyalat képet változatlanul hagyja. Ugyanez a színárnyalat a szürkeárnyalatos előtt alkalmazva más árnyalatot eredményez.*
<!-- visual-explanation:image-transform-effects:end -->

## **Szerkeszthető és hatékony értékek ellenőrzése**

Egy szerkeszthető művelet az a objektum, amely a [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)‑ben van tárolva. A hatástól függően közvetlenül elérhetőek lehetnek a írható tagok. Például a [Blur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/) írható `radius` és `grow` értékeket biztosít, a [AlphaModulateFixed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphamodulatefixed/) egy írható `amount`‑ot, a [AlphaBiLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphabilevel/) egy írható `threshold`‑ot. A [Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) szerkeszthető [ColorFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) objektumokat exponál.

Néhány művelet, mint a [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tint/), és [AlphaReplace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphareplace/), nem exponálja a létrehozási skalárokat írható tulajdonságként. Ezeknek a beállításoknak a módosításához távolítsa el a műveletet, és a kívánt pozícióban adjon hozzá egy újat.

A `getEffective()`‑vel visszaadott hatékony adat kiszámított és csak‑olvasásra szánt. Hasznos a témától függő színek feloldásához és a renderelő által használt normalizált értékek olvasásához, de nem egy másik szerkesztési felület. Az alábbi példa felsorolja a láncot, és ellenőrzi a hatékony értékeket, ahol az adott API biztosítja azokat:

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

Paraméter‑nélküli hatások, mint a szürkeárnyalatos, alfa‑ceiling és alfa‑inverse, továbbra is rendelkeznek hatékony‑adat objektummal, de nincs skáláris beállításuk a kiíráshoz. A jelenlétük és pozíciójuk a gyűjteményben a fontos információ.

## **Kép‑transzformációk eltávolítása vagy törlése**

Használja a [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)‑t egy művelet index szerinti eltávolításához. Mivel az indexek eltávolítás után eltolódnak, előbb keresse meg a célt, majd a felsorolás után távolítsa el. A [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) a teljes lánc eltávolítására szolgál.

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

A transzformációk eltávolítása vagy törlése csak a képformázást változtatja meg. Nem törli, nem tömöríti újra, és nem módosítja a újrafelhasznált [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) forrást.

## **A prezentációformátumok és exportcélok figyelembevétele**

A kép‑transzformációk a DrawingML‑ből származnak, ezért a PPTX a leginkább szerkeszthető formátum a hatákláncokhoz. Még PPTX‑ben sem minden művelet rendelkezik azonos hordozhatósággal:

- A szabványos DrawingML műveletek, mint a luminancia, szürkeárnyalatos, duotone, tint, HSL, elmosás és a gyakori alfa‑műveletek a legnagyobb eséllyel maradnak meg egy PPTX körkörös után. Mindig nyissa meg a generált fájlt, és ellenőrizze a gyűjteményt, ha a megőrzés követelmény.
- A [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) egy Office 2010‑kiterjesztés, nem a szabványos DrawingML luminancia művelet. Memóriabeli rendereléshez használható, de nem garantált, hogy a mentés és újranyitás után szerkeszthető [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) művelet marad. Tartós fényerő‑kontraszt beállításhoz válassza az [addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)‑et.
- A bináris PPT formátum időrétege előzi meg a teljes DrawingML hatásmodellt. PPT‑re mentéskor a nem támogatott műveletek elhagyhatók, a lánc egy támogatott részhalmazra csökkenthető, vagy a megjelenés közelítőleg ábrázolható. Ne használja a PPT‑t ellenőrzési formátumként egy összetett szerkeszthető lánchoz.
- PNG, JPEG, TIFF, PDF, SVG, HTML vagy más vizuális kimenet esetén a támogatott lánc a renderelt megjelenésre kerül alkalmazásra. Ezek a kimenetek nem tartalmaznak szerkeszthető [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) objektumot; a raszteres formátumok a végeredményt pixelekre lapítják, a dokumentum/vektor exportok a saját renderelési reprezentációjukat tárolják.
- A hatások nem teszik önállóvá a hivatkozott képet. Egy hivatkozott kép renderelése továbbra is a hivatkozott erőforrás rendelkezésre állását igényli a prezentáció betöltésekor.

A különböző prezentációfelhasználók esetleg eltérően renderelhetik az edge‑case‑eket, különösen ha több alfa‑ vagy szín‑kvantálási művelet kombinálódik. Kritikus kimenet esetén tesztelje mind a szerkeszthető körkörös útvonalat, mind a végső export formátumot ugyanazzal az Aspose.Slides verzióval, amelyet a termelésben használ.

## **GYIK**

**Módosítják a kép‑transzformációs hatások a beágyazott kép adatát?**

Nem. A műveletek a [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)‑hez tartoznak, amelyet a képkitöltés használ. Az alap [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) bájtjai változatlanok maradnak.

**Két képkeret, amely ugyanazt a képet használja, megosztja a hatásokat?**

Nem. A [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) újrafelhasználása elkerüli a duplikált képadatot, de minden képkeret általában saját [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) és saját kép‑transzformációs gyűjteménnyel rendelkezik.

**Kombinálhatók a szín‑, elmosás‑ és alfa‑hatások?**

Igen. A gyűjtemény egyetlen rendezett láncban fogadja őket. Vegye figyelembe, hogy minden művelet mit tesz az előző kimenetén, mert a helyettesítő és küszöb‑műveletek eldobhatják a korábbi szín‑ vagy alfa‑részleteket.

**Miért csak‑olvasásra szántak a hatékony értékek?**

A hatékony adat a rendereléshez használt, kiszámított értékeket képviseli, beleértve a feloldott színeket. Szerkessze a transzformációs gyűjteményben tárolt műveletet, ahol írható tagok vannak; ellenkező esetben távolítsa el, és adjon hozzá egy újat az új létrehozási paraméterekkel.

**Melyik formátumot használjam a transzformációs lánc megőrzéséhez?**

Használja a PPTX‑et, és ellenőrizze a fájlt újranyitással. A régi PPT nem képes teljesen ábrázolni a DrawingML hatásmodellt, és a renderelt export formátumok csak a megjelenést őrzik meg, nem a szerkeszthető transzformációs műveleteket.