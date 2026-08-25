---
title: Správa efektů transformace obrázku v prezentacích pomocí JavaScriptu
linktitle: Efekty transformace obrázku
type: docs
weight: 11
url: /cs/nodejs-java/image-transform-effects/
keywords:
- transformace obrázku
- efekt obrázku
- jas
- kontrast
- odstín šedé
- duotón
- tónování
- HSL
- náhrada barvy
- rozostření
- průhlednost
- efekt alfa
- řetězec efektů
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Použijte, řetězte, kontrolujte, odstraňujte a ověřujte efekty transformace obrázku pro rámečky obrázků pomocí Aspose.Slides pro Node.js prostřednictvím Java."
---
## **Přehled**

Aspose.Slides představuje úpravy obrázků jako uspořádanou kolekci operací transformace obrázku. Pro rámeček obrázku začněte s [Picture](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picture/) a přistupte k [Picture.getImageTransform](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picture/). Vrácená [ImageTransformOperationCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) vám umožní přidávat, procházet, kontrolovat, odstraňovat a vymazávat efekty, aniž byste přepisovali původní bajty obrázku.

Tento článek demonstruje kompletní postup pro jas a kontrast, barevné transformace, rozostření, průhlednost, řazené řetězce efektů, efektivní hodnoty, odstraňování a ověření PPTX round‑trip.

## **Porozumění vlastnictví efektů a opětovnému použití obrázku**

Zdrojový obrázek a obrázek, který jej zobrazuje, jsou odlišné objekty:

- [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) ukládá nebo odkazuje na zdrojová data obrázku vlastněná prezentací.
- [Picture](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picture/) patří k výplni obrázku a odkazuje na zdrojový obrázek, zároveň uchovává kolekci transformací obrázku.
- [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) je tvar snímku, který vlastní odpovídající výplň obrázku, geometrii, ořez a další formátování na úrovni rámce.

Proto operace transformace obrázku nemění bajty v [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/). Když je stejný [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) předán metodě [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/) více než jednou, každý nový rámeček získá vlastní [Picture](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picture/) a vlastní kolekci transformací. Aplikace odstínu šedé na jeden rámeček neovlivní ostatní rámečky, i když všechny používají stejný vložený obrázkový zdroj.

Stejný model [Picture.getImageTransform](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picture/) používají také jiné výplně obrázku, například tvar nebo pozadí snímku. Níže uvedené příklady se soustředí na rámečky obrázku.

## **Používejte platné rozsahy parametrů a jednotky**

Ukázané metody používají následující sémantické rozsahy a jednotky. Dodržujte hodnoty v těchto rozsazích, i když konkrétní verze knihovny neodmítá každou mimo‑rozsahovou hodnotu okamžitě; cílový formát prezentace může během uložení nebo při otevření souboru v PowerPointu normalizovat, vynechat nebo odmítnout neplatná data.

| Operace | Parametry | Platný rozsah a jednotka |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` až `100`, procent; `0` ponechá komponentu beze změny. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) | None | Žádné číselné parametry. Alfa zůstává beze změny. |
| [addDuotoneEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Dvě barvy pro tmavé a světlé pixely. Kanály RGB a alfa v `java.awt.Color` používají hodnoty `0` až `255`. |
| [addTintEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Odtín je od `0` (včetně) do `360` (exkluzivně) stupňů; množství je od `-100` do `100` procent. |
| [addHSLEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Odtín je od `0` (včetně) do `360` (exkluzivně) stupňů; sytost a luminance jsou od `-100` do `100` procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | Náhradní barva používá hodnoty kanálů od `0` do `255`. Existující alfa hodnoty zůstávají beze změny. |
| [addBlurEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Poloměr je nezáporný a měří se v bodech; `grow` je Boolean, který určuje, zda rozostřený obsah může přesáhnout původní ohraničení. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Nezáporné procento. Použijte `0` až `100` pro běžné škálování průhlednosti: `0` je zcela průhledné a `100` zachovává existující alfu. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` až `100` procent neprůhlednosti. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` až `100` procent prahové hodnoty alfy. Hodnoty pod prahem se stanou průhlednými; hodnoty na prahu nebo nad ním se stanou neprůhlednými. |

Pro pevnou modulaci alfy jsou průhlednost a neprůhlednost komplementární. Například 35 % průhlednost odpovídá modulaci alfy ve výši 65 %.

## **Použijte jas a kontrast**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) vrací operaci [BrightnessContrast](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/brightnesscontrast/). Její skalární nastavení jsou předána při vytvoření operace. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/brightnesscontrast/) vrací vypočtené hodnoty jen pro čtení, které lze zkontrolovat nebo zalogovat.

Následující příklad zvýší jas o 15 % a kontrast o 20 %, poté vykreslí náhled bez úpravy vloženého obrázku:

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

[BrightnessContrast](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/brightnesscontrast/) je rozšíření efektu obrázku Office 2010 a není tak přenositelné jako standardní efekt luminance DrawingML. Když musí být jas a kontrast po PPTX round‑tripu nadále editovatelné, použijte [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) a výsledek ověřte po znovuotevření souboru. Oddíl o omezeních formátu podrobněji vysvětluje tento rozdíl.

## **Použijte barevné transformace**

Barevné efekty lze aplikovat nezávisle na různých rámečcích, které používají stejný zdroj obrázku. Následující příklad vytvoří pět rámečků a použije odstín šedé, duotón, tónování, úpravu HSL a náhradu barvy.

[Duotone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/duotone/) obsahuje dva nezávisle editovatelné barevné parametry: `color1` mapuje tmavé pixely, zatímco `color2` mapuje světlé pixely. To jej činí užitečným příkladem efektu, jehož nastavení jsou komplexnější než jednorozměrná hodnota.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) nahrazuje barvu každého pixelu jednou pevnou barvou při zachování alfy. Liší se od [addColorChangeEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/), který mapuje jednu zdrojovou barvu na jinou a vystavuje oba formáty zdrojové i cílové barvy.

## **Přidejte rozostření, průhlednost a alfa efekty**

[addBlurEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) ovlivňuje všechny barevné kanály, včetně alfy. Nastavte `grow` na `true`, když rozostřený okraj může přesáhnout původní hranice obrázku.

Pro jednotnou průhlednost použijte [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/). Násobí každou existující hodnotu alfy, takže částečně průhledné pixely zůstávají úměrně odlišné. [addAlphaReplaceEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) místo toho přiřadí jednu hodnotu alfy všem pixelům. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) převádí alfu na dvě úrovně na základě prahu.

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

Další alfa operace bez parametrů zahrnují [addAlphaCeilingEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/), který nastaví každou nenulovou alfu na plnou neprůhlednost; [addAlphaFloorEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/), který nastaví každou alfu pod 100 % na zcela průhlednou; a [addAlphaInverseEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/), který mění alfu na `100% - alpha`.

## **Vytvořte uspořádaný řetězec efektů**

Každá metoda `add...Effect` přidá novou operaci na konec kolekce. Vykreslovač používá kolekci jako uspořádaný pipeline: výstup operace 0 se stane vstupem operace 1 a tak dále. Výsledkem je, že stejné operace v jiném pořadí mohou vytvořit jiný obrázek.

Například odstín šedé následovaný tónováním nejprve odstraní chromatické informace a poté přebarví výsledek luminance. Tónování následované odstínem šedým odstraní tónování zpět. Podobně může náhrada alfy přepsat hodnoty alfy vypočtené dřívějšími operacemi, zatímco modulace alfy zachová jejich relativní rozdíly.

Následující příklad vytvoří řetězec se čtyřmi operacemi, uloží jej jako PPTX, znovu otevře prezentaci, zkontroluje typy operací i jejich pořadí a vykreslí výsledek po opětovném otevření:

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

Kolekce neudržuje kompatibilní matici, která by omezovala barvu, alfu a rozostření na oddělené řetězce. Lze je kombinovat, ale kombinace nemusí být vždy užitečné. Pevná náhrada barvy odstraní RGB variace vytvořené předchozími barevnými efekty; odstín šedý po duotónu odstraní dvě vybrané barvy; a efekty alfa strop, podlaha, náhrada nebo dvouúrovňová operace mohou zrušit alfa detail vytvořený dříve. Sestavujte řetězec podle požadovaného pořadí pixel‑zpracování, nikoli jako neuspořádané příznaky formátování.

## **Prohlédněte editovatelné a efektivní hodnoty**

Editovatelná operace je objekt uložený v [Picture.getImageTransform](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picture/). V závislosti na efektu může přímo exponovat zapisovatelné členy. Například [Blur](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/blur/) exponuje zapisovatelné hodnoty `radius` a `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/alphamodulatefixed/) exponuje zapisovatelný `amount` a [AlphaBiLevel](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/alphabilevel/) exponuje zapisovatelný `threshold`. Barevné efekty jako [Duotone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/duotone/) exponují mutovatelné objekty [ColorFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/colorformat/).

Některé operace, včetně [BrightnessContrast](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tint/) a [AlphaReplace](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/alphareplace/), neexponují své vytvořené skaláry jako zapisovatelné vlastnosti. Pro změnu těchto nastavení odstraňte operaci a přidejte náhradu na požadovanou pozici.

Efektivní data vrácená metodou `getEffective()` jsou vypočtená a jen pro čtení. Hodí se k rozřešení barev závislých na motivu a ke čtení normalizovaných hodnot, které vykreslovač používá, ale nejsou dalším editovacím povrchem. Následující příklad prochází řetězec a kontroluje efektivní hodnoty tam, kde příslušné API poskytuje takové údaje:

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

Efekty bez parametrů, jako odstín šedý, alfa strop a alfa inverze, mají také objekt efektivních dat, ale nemají žádná skalární nastavení k vytištění. Jejich přítomnost a pozice v kolekci jsou podstatné informace.

## **Odstraňte nebo vymažte transformace obrázku**

Použijte [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) k odstranění jedné operace podle indexu. Protože se indexy po odebrání posouvají, nejprve vyhledejte cíl a až po procházení jej odstraňte. Použijte [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) k vymazání celého řetězce.

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

Odstranění nebo vymazání transformací mění pouze formátování obrázku. Neodstraňuje, nekomprimuje ani jinak nemění opakovaně použitý zdroj [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/).

## **Zvažte formáty prezentace a cíle exportu**

Transformace obrázku pocházejí z DrawingML, takže PPTX je preferovaný editovatelný formát pro řetězce efektů. I v PPTX však ne každá operace má stejnou přenositelnost:

- Standardní operace DrawingML jako luminance, odstín šedý, duotón, tónování, HSL, rozostření a běžné alfa operace mají největší šanci přežít PPTX round‑trip. Vždy po generování souboru jej znovu otevřete a prohlédněte kolekci, pokud je zachování vyžadováno.
- [BrightnessContrast](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/brightnesscontrast/) je rozšíření Office 2010, nikoli standardní operace luminance DrawingML. Lze jej použít pro vykreslení v paměti, ale není zaručeno, že po uložení a znovuotevření PPTX zůstane editovatelným operací [BrightnessContrast](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/brightnesscontrast/). Upřednostněte [addLuminanceEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/) pro trvalé úpravy jasu a kontrastu.
- Binární formát PPT předchází plnému modelu efektů DrawingML. Uložení do PPT může vynechat nepodporované operace, zredukovat řetězec na podporovanou podmnožinu nebo aproximovat vzhled. Nepoužívejte PPT jako ověřovací formát pro složitý editovatelný řetězec.
- Vykreslování do PNG, JPEG, TIFF, PDF, SVG, HTML nebo jiných vizuálních výstupů aplikuje podporovaný řetězec na vykreslený vzhled. Tyto výstupy neobsahují editovatelnou [ImageTransformOperationCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagetransformoperationcollection/); rastrové formáty výsledek zploští na pixely a exporty dokumentů/vektorů ukládají vlastní reprezentaci vykreslování.
- Efekty nečiní odkazovaný obrázek samostatným. Vykreslení odkazovaného obrázku stále závisí na tom, že odkazovaný zdroj je k dispozici při načítání prezentace.

Různí spotřebitelé prezentací mohou různé hraniční případy vykreslovat odlišně, zejména když jsou kombinovány několik alfa nebo barevných kvantizačních operací. Pro kritický výstup testujte jak editovatelný round‑trip, tak finální exportní formát se stejnou verzí Aspose.Slides, jakou používáte ve výrobě.

## **Často kladené otázky**

**Mění efekty transformace obrázku vložená data obrázku?**

Ne. Operace patří k [Picture](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picture/) používanému výplní obrázku. Underlying bajty v [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) zůstávají nezměněny.

**Budou dva rámečky obrázku, které používají stejný obrázek, sdílet své efekty?**

Ne. Opětovné použití [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) eliminuje duplikaci dat obrázku, ale každý rámeček obrázku má obvykle vlastní [Picture](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picture/) a vlastní kolekci transformací obrázku.

**Lze kombinovat barevné, rozostřovací a alfa efekty?**

Ano. Kolekce je přijímá v jednom uspořádaném řetězci. Zvažte, co každá operace dělá s výstupem předchozí, protože operace náhrady a prahu mohou zrušit dřívější barevný nebo alfa detail.

**Proč jsou efektivní hodnoty pouze pro čtení?**

Efektivní data představují vypočtené hodnoty používané při vykreslování, včetně rozřešených barev. Editujte operaci uloženou v kolekci transformací, kde existují zapisovatelné členy; jinak ji odstraňte a přidejte náhradu s novými parametry vytvoření.

**Jaký formát použít pro zachování řetězce transformací?**

Použijte PPTX a ověřte soubor jeho opětovným otevřením. Legacy PPT nedokáže reprezentovat celý model efektů DrawingML a exportní formáty zachovávají pouze vzhled, nikoli editovatelné transformace.