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
- odstíny šedé
- duotón
- tónování
- HSL
- náhrada barvy
- rozostření
- průhlednost
- alfa efekt
- řetězec efektů
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Použijte, řaďte, kontrolujte, odstraňujte a ověřujte efekty transformace obrázku pro rámečky obrázků s Aspose.Slides pro Node.js pomocí Java."
---
## **Přehled**

Aspose.Slides představuje úpravy obrázků jako uspořádanou kolekci operací transformace obrazu. Pro rámeček obrázku začněte s rámcem [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) a přistupte k [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). Vrácená [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) vám umožní přidávat, procházet, zkoumat, odstraňovat a vymazávat efekty, aniž byste přepisovali původní bajty obrázku.

Tento článek ukazuje kompletní pracovní postup pro jas a kontrast, barevné transformace, rozostření, průhlednost, řazené řetězce efektů, efektivní hodnoty, odstraňování a ověření zpětného průchodu PPTX.

## **Pochopení vlastnictví efektů a opětovného použití obrázků**

Zdrojem obrázku a obrázkem, který jej zobrazuje, jsou různé objekty:

- [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) ukládá nebo odkazuje na zdrojová data obrázku vlastněná prezentací.
- [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) patří k výplni obrázku a odkazuje na zdroj obrázku, přičemž ukládá kolekci transformací obrázku.
- [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) je objekt snímku, který vlastní příslušnou výplň obrázku, geometrii, nastavení ořezu a další formátování na úrovni rámce.

Proto operace transformace obrazu nemodifikují bajty v [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/). Když je stejný [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) předán metodě [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) více než jednou, každý nový rámeček obrázku získá vlastní [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) a vlastní kolekci transformací. Použití odstínů šedé na jednom rámečku neovlivní ostatní rámečky, i když všechny znovu používají stejný vložený zdroj obrázku.

Stejný model [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) je také používán jinými výplněmi obrázku, jako je tvar nebo pozadí snímku. Níže uvedené příklady se zaměřují na rámečky obrázku.

## **Používejte platné rozsahy parametrů a jednotky**

Ukázané metody používají následující sémantické rozsahy a jednotky. Dodržujte hodnoty v těchto rozsazích, i když konkrétní verze knihovny neodmítne každou mimo rozsah hodnotu okamžitě; cílový formát prezentace může během uložení nebo při otevření souboru v PowerPointu normalizovat, vynechat nebo odmítnout neplatná data.

| Operace | Parametry | Platný rozsah a jednotka |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` až `100`, procent; `0` ponechává komponentu beze změny. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | Žádné | Žádné číselné parametry. Alfa zůstává nezměněna. |
| [addDuotoneEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Dvě barvy pro tmavé a světlé pixely. Kanály RGB a alfa v `java.awt.Color` používají hodnoty od `0` do `255`. |
| [addTintEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Hue je od `0` (včetně) do `360` (exkluzivně) ve stupních; amount je od `-100` do `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Hue je od `0` (včetně) do `360` (exkluzivně) ve stupních; saturation a luminance jsou od `-100` do `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | Náhradní barva používá hodnoty kanálů od `0` do `255`. Existující alfa hodnoty zůstávají nezměněny. |
| [addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Radius je nezáporný a měří se v bodech; `grow` je logická hodnota určující, zda rozostřený obsah může přesahovat původní hranice. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Nezáporné procento. Použijte `0` až `100` pro běžné škálování neprůhlednosti: `0` je plně průhledná a `100` zachovává existující alfa. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` až `100`, procento neprůhlednosti. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` až `100`, procento alfa prahu. Hodnoty pod prahovou hodnotou se stávají průhlednými; hodnoty na prahu nebo nad ním se stávají neprůhlednými. |

Pro pevnou modulaci alfa jsou průhlednost a neprůhlednost komplementární. Například 35 % průhlednost odpovídá modulaci alfa ve výši 65 %.

## **Použití jasu a kontrastu**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) vrací operaci [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/). Jeho skalární nastavení jsou zadána při vytvoření operace. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) vrací vypočítané pouze‑ke‑čtení hodnoty, které lze zkontrolovat nebo zaznamenat.

Následující příklad zvýší jas o 15 % a kontrast o 20 %, poté zobrazí náhled, aniž by modifikoval vložený obrázek:

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

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) je rozšíření Office 2010 pro efekt obrázku a není tak přenositelné jako standardní efekt luminance DrawingML. Když je potřeba, aby jas a kontrast zůstaly po průchodu PPTX editovatelné, použijte [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) a ověřte výsledek po opětovném otevření souboru. Část o omezeních formátu podrobněji vysvětluje tento rozdíl.

## **Použití barevných transformací**

Barevné efekty lze aplikovat nezávisle na různých rámečcích obrázku, které znovu používají jeden zdroj obrázku. Následující příklad vytvoří pět rámečků a aplikuje odstíny šedé, duotón, tónování, úpravu HSL a nahrazení barvy.

[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) obsahuje dva nezávisle editovatelné barevné parametry: `color1` mapuje tmavé pixely, zatímco `color2` mapuje světlé pixely. To je užitečný příklad efektu, jehož nastavení jsou složitější než jediná skalární hodnota.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) nahrazuje barvu každého pixelu jednou pevnou barvou při zachování alfa kanálu. Je odlišný od [addColorChangeEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), který mapuje jednu zdrojovou barvu na jinou a vystavuje oba formáty barvy – zdrojovou i cílovou.

### **Použití prahu jasu**

Prahování jasu může usnadnit rozlišení slabých značek na naskenované stránce od pozadí. [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) zachovává mezilehlé odstíny šedé. [addBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) mapuje luminanci na černou nebo bílou, zatímco [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) aplikuje práh na neprůhlednost.

Prahová hodnota jasu se pohybuje od 0 % do 100 %, včetně. Pixely pod prahem se stávají černými. Pixely na prahu nebo nad ním se stávají bílými. Zvýšení prahu přemění více odstínů na černou, protože více z nich spadá pod limit.

Stáhněte soubor [grayscale-swatches.png](grayscale-swatches.png) do pracovního adresáře. Každý popisek udává původní úroveň šedé na stupnici od 0 do 255. Příklad umístí originál vedle dvou kopií a uloží prahovou hodnotu každé kopie v prezentaci.

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

Otevřete výstupní prezentaci v PowerPointu a porovnejte tři rámečky. Swatch označený 96 má přibližně 38 % luminance (96 z 255). Při prahu 20 % se změní na bílou a při prahu 60 % na černou.

![Původní odstíny šedé vedle černobílých výsledků při prahových hodnotách jasu 20% a 60%](luminance-threshold.png)

## **Přidání rozostření, průhlednosti a alfa efektů**

[addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) ovlivňuje všechny barevné kanály, včetně alfa. Nastavte `grow` na `true`, když rozostřený okraj může přesahovat původní hranice obrázku.

Pro jednotnou průhlednost použijte [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/). Násobí každou existující alfa hodnotu, takže částečně průhledné pixely zůstávají úměrně odlišné. [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) místo toho přiřadí jednu alfa hodnotu všem pixelům. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) převádí alfa na dvě úrovně na základě prahu.

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

Mezi operace alfa bez parametrů patří [addAlphaCeilingEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), který všechny nenulové alfa hodnoty nastaví na plně neprůhledné; [addAlphaFloorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), který všechny alfa hodnoty pod 100 % nastaví na plně průhledné; a [addAlphaInverseEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), který mění alfa na `100% - alfa`.

## **Vytvoření uspořádaného řetězce efektů**

Každá metoda `add...Effect` přidá novou operaci na konec kolekce. Vykreslovač používá kolekci jako uspořádanou pipeline: výstup operace 0 se stane vstupem operace 1 a tak dále. V důsledku toho může stejné operace v jiném pořadí vytvořit odlišný obrázek.

Například odstíny šedé následované tónováním nejprve odstraní chromatické informace a pak přebarevní výsledek luminance. Tónování následované odstíny šedými znovu odstraní tónování. Podobně může náhrada alfa přepsat alfa hodnoty vypočtené dřívějšími operacemi, zatímco modulace alfa zachová jejich relativní rozdíly.

Následující příklad vytvoří řetězec se čtyřmi operacemi, uloží jej jako PPTX, znovu otevře prezentaci, zkontroluje typy operací i jejich pořadí a vykreslí znovu otevřený výsledek:

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

Kolekce neukládá kompatibilní matici, která by omezovala barevné, alfa a rozostřovací operace na samostatné řetězce. Mohou být kombinovány, ale kombinace nejsou vždy užitečné. Pevná náhrada barvy odstraňuje RGB variaci vytvořenou předchozími barevnými efekty; odstíny šedé po duotónu odstraňují dvě vybrané barvy; a operace alfa ceiling, floor, replacement nebo bi-level mohou zahodit alfa detail vytvořený dříve. Sestavte řetězec podle požadovaného pořadí zpracování pixelů, místo aby byly položky vnímány jako neuspořádané formátovací příznaky.


<!-- visual-explanation:image-transform-effects:start -->
[![Stejný obrázek prochází nejprve převodem na odstíny šedé a poté tónováním, a naopak tónováním a poté převodem na odstíny šedé. Dvě konečné obrázky v odstínech šedé mají různé tóny.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **Prohlížení editovatelných a efektivních hodnot**

Editovatelná operace je objekt uložený v [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). V závislosti na efektu může přímo vystavovat zapisovatelné členy. Například [Blur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/) vystavuje zapisovatelné hodnoty `radius` a `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphamodulatefixed/) vystavuje zapisovatelný `amount` a [AlphaBiLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphabilevel/) vystavuje zapisovatelný `threshold`. Barevné efekty jako [Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) vystavují měnitelné objekty [ColorFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/).

Některé operace, včetně [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tint/), a [AlphaReplace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphareplace/), neexponují své vytvořené skaláry jako zapisovatelné vlastnosti. Pro změnu těchto nastavení odeberte operaci a přidejte náhradu na požadované místo.

Efektivní data vrácená metodou `getEffective()` jsou vypočítaná a jen‑ke‑čtení. Jsou užitečná pro řešení barev závislých na tématu a čtení normalizovaných hodnot, které vykreslovač používá, ale nejsou dalším editovatelným povrchem. Následující příklad prochází řetězec a kontroluje efektivní hodnoty tam, kde odpovídající API je poskytuje:

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

Operace bez parametrů, jako jsou odstíny šedé, alfa ceiling a alfa inverse, stále mají objekt efektivních dat, ale neexistují skalární nastavení k vytištění. Jejich přítomnost a pozice v kolekci jsou důležité informace.

## **Odstranění nebo vymazání transformací obrázku**

Použijte [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) k odebrání jedné operace podle indexu. Protože se indexy po odebrání posunou, nejprve vyhledejte cíl a poté jej odeberte po procházení. Použijte [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) k odebrání celého řetězce.

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

Odstranění nebo vymazání transformací mění pouze formátování obrázku. Nepřepisuje, nekomprimuje ani jinak nemění znovu použité zdroje [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/).

## **Zvažte formáty prezentací a cílové exporty**

Transformace obrázků pocházejí z DrawingML, takže PPTX je preferovaný editovatelný formát pro řetězce efektů. I u PPTX ne každá operace má stejnou přenositelnost:

- Standardní operace DrawingML, jako jsou luminance, odstíny šedé, duotón, tónování, HSL, rozostření a běžné alfa operace, mají nejlepší šanci přežít průchod PPTX. Vždy po vygenerování souboru jej znovu otevřete a zkontrolujte kolekci, pokud je zachování požadováno.
- [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) je rozšíření Office 2010, nikoli standardní operace luminance DrawingML. Lze jej použít pro vykreslování v paměti, ale není zaručeno, že po uložení a opětovném otevření PPTX zůstane editovatelnou operací [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/). Pro trvalé úpravy jasu a kontrastu upřednostněte [addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/).
- Binární formát PPT předchází úplnému modelu efektů DrawingML. Uložení do PPT může vynechat nepodporované operace, zredukovat řetězec na podporovaný podmnožinu nebo aproximovat vzhled. Nepoužívejte PPT jako formát pro ověření složitého editovatelného řetězce.
- Vykreslování do PNG, JPEG, TIFF, PDF, SVG, HTML nebo jiných vizuálních výstupů použije podporovaný řetězec na vykreslený vzhled. Tyto výstupy neobsahují editovatelnou [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/); rastrové formáty výsledek zploští do pixelů a dokumentové/vektorové exporty ukládají vlastní reprezentaci vykreslení.
- Efekty nečiní propojený obrázek samostatně soběstačným. Vykreslení propojeného obrázku stále závisí na tom, že propojený zdroj je dostupný při načítání prezentace.

Různí spotřebitelé prezentací mohou vykreslovat okrajové případy odlišně, zvláště když jsou kombinovány několik alfa nebo barevných kvantizačních operací. Pro kritické výstupy testujte jak editovatelný průchod, tak konečný exportní formát se stejnou verzí Aspose.Slides používanou ve výrobě.

## **Často kladené otázky**

**Modifikují efekty transformace obrázku vložená data obrázku?**

Ne. Operace patří k [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) používanému výplní obrázku. Bajty podkladového [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) zůstávají beze změny.

**Budou dva rámečky obrázku, které znovu používají stejný obrázek, sdílet své efekty?**

Ne. Opětovné použití [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) zabraňuje duplicitním datům obrázku, ale každý rámeček obrázku má obvykle vlastní [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) a kolekci transformací obrázku.

**Lze kombinovat barevné, rozostřovací a alfa efekty?**

Ano. Kolekce je přijímá v jednom uspořádaném řetězci. Zvažte, jak každá operace ovlivňuje výstup předchozí, protože operace nahrazení a prahování mohou zahodit dřívější barevné nebo alfa detaily.

**Proč jsou efektivní hodnoty jen‑ke‑čtení?**

Efektivní data představují vypočítané hodnoty používané pro vykreslení, včetně rozřešených barev. Editujte operaci uloženou v kolekci transformací tam, kde existují zapisovatelné členy; jinak ji odeberte a přidejte náhradu s novými parametry vytvoření.

**Jaký formát použít pro zachování řetězce transformací?**

Použijte PPTX a ověřte soubor jeho opětovným otevřením. Starší formát PPT nedokáže představit kompletní model efektů DrawingML a exportní formáty vizuálního výstupu zachovávají pouze vzhled, nikoli editovatelné operace transformace.