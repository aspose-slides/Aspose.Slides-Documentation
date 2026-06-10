---
title: Prezentáció hátterek kezelése JavaScriptben
linktitle: Dia háttér
type: docs
weight: 20
url: /hu/nodejs-java/presentation-background/
keywords:
- prezentáció háttér
- dia háttér
- szilárd szín
- színátmenet
- kép háttér
- háttér átlátszóság
- háttér tulajdonságok
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan állíthat be dinamikus háttereket PowerPoint és OpenDocument fájlokban az Aspose.Slides for Node.js használatával, kódtippekkel a prezentációk fejlesztéséhez."
---
## **Bevezetés**

Szilárd színek, színátmenetek és képek gyakran használtak diaháttérként. Beállíthatja a háttért egy **normál diára** (egyetlen diára) vagy egy **mester diára** (egyszerre több diára vonatkozik).

![PowerPoint háttér](powerpoint-background.png)

## **Szilárd színű háttér beállítása normál diára**

Aspose.Slides lehetővé teszi, hogy szilárd színt állítson be egy adott dia háttérként egy prezentációban – még ha a prezentáció mester diát is használ. A változás csak a kiválasztott diára vonatkozik.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) értékét `Solid`-ra.
4. Használja a [getSolidFillColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) metódust a [FillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/) osztályon a szilárd háttérszín megadásához.
5. Mentse el a módosított prezentációt.

Az alábbi JavaScript példa azt mutatja, hogyan állíthat be kék szilárd színt háttérként egy normál diára:

```js
// Hozzon létre egy példányt a Presentation osztályból.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Állítsa be a dia háttérszínét kékre.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // Mentse el a prezentációt a lemezre.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Szilárd színű háttér beállítása a mester diára**

Aspose.Slides lehetővé teszi, hogy szilárd színt állítson be a prezentáció mester diájának háttérként. A mester dia sablonként működik, amely az összes dia formázását szabályozza, így ha szilárd színt választ a mester dia háttérhez, az minden diára érvényes lesz.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Állítsa be a mester dia [BackgroundType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/backgroundtype/) értékét (a `getMasters` segítségével) `OwnBackground`-ra.
3. Állítsa be a mester dia háttér [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) értékét `Solid`-ra.
4. Használja a [getSolidFillColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) metódust a szilárd háttérszín megadásához.
5. Mentse el a módosított prezentációt.

Az alábbi JavaScript példa azt mutatja, hogyan állíthat be zöld szilárd színt háttérként egy mester diára:

```js
// Hozzon létre egy példányt a Presentation osztályból.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // Állítsa be a Master dia háttérszínét erdei zöldre.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // Mentse el a prezentációt a lemezre.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gradient háttér beállítása diára**

A gradient egy grafikai hatás, amely fokozatos színváltozással jön létre. Diák háttérként használva a gradientek művészibbé és professzionálisabbá tehetik a prezentációkat. Aspose.Slides lehetővé teszi, hogy gradient színt állítson be a diák háttérként.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) értékét `Gradient`-ra.
4. Használja a [getGradientFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/#getGradientFormat) metódust a [FillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/) osztályon a kívánt gradient beállítások konfigurálásához.
5. Mentse el a módosított prezentációt.

Az alábbi JavaScript példa azt mutatja, hogyan állíthat be gradient színt háttérként egy diára:

```js
// Hozzon létre egy példányt a Presentation osztályból.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Alkalmazzon gradient hatást a háttérre.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Mentse el a prezentációt a lemezre.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kép beállítása diaháttérként**

A szilárd és gradient kitöltések mellett az Aspose.Slides lehetővé teszi, hogy képeket használjon diaháttérként.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) értékét `Picture`-ra.
4. Töltse be a képet, amelyet a dia háttérként kíván használni.
5. Adja hozzá a képet a prezentáció képgyűjteményéhez.
6. Használja a [getPictureFillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) metódust a [FillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/) osztályon a kép háttérként történő hozzárendeléséhez.
7. Mentse el a módosított prezentációt.

Az alábbi JavaScript példa azt mutatja, hogyan állíthat be egy képet a dia háttérként:

```js
// Hozzon létre egy példányt a Presentation osztályból.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Állítsa be a háttérkép tulajdonságait.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // Töltse be a képet.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // Adja hozzá a képet a prezentáció képgyűjteményéhez.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Mentse el a prezentációt a lemezre.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az alábbi kódrészlet azt mutatja, hogyan állítható a háttér kitöltés típusa csempézett képre, és hogyan módosíthatók a csempézési tulajdonságok:

```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Állítsa be a háttérkitöltéshez használt képet.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Állítsa be a kép kitöltési módot Csempe-re, és módosítsa a csempetulajdonságokat.
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Bővebben: [**Kép csempézés textúraként**](/slides/hu/nodejs-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **A háttérkép átlátszóságának módosítása**

Lehet, hogy szeretné módosítani egy dia háttérképének átlátszóságát, hogy a dia tartalma jobban kirajzolódjon. Az alábbi JavaScript kód megmutatja, hogyan változtatható meg a dia háttérkép átlátszósága:

```js
var transparencyValue = 30; // Például.

// Szerezze meg a kép transzformációs műveletek gyűjteményét.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Keressen egy meglévő fix százalékos átlátszósági hatást.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// Állítsa be az új átlátszósági értéket.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **A dia háttérértékének lekérése**

Az Aspose.Slides biztosítja a `BackgroundEffectiveData` osztályt a dia hatékony háttérértékeinek lekéréséhez. Ez az osztály a hatékony [FillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/) és [EffectFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effectformat/) értékeket teszi elérhetővé.

A [BaseSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslide/) osztály `getBackground` metódusával lekérhető a dia hatékony háttere.

Az alábbi JavaScript példa azt mutatja, hogyan kérhető le egy dia hatékony háttérértéke:

```js
// Hozzon létre egy példányt a Presentation osztályból.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // Hozza vissza a hatékony hátteret, figyelembe véve a mester, elrendezés és téma.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **Gyakran Ismételt Kérdések**

**Vissza tudom állítani az egyéni háttér beállítását, és visszakapni a téma/layout háttérét?**

Igen. Távolítsa el a dia egyéni kitöltését, és a háttér újra öröklődik a megfelelő [layout](/slides/hu/nodejs-java/slide-layout/)/[master](/slides/hu/nodejs-java/slide-master/) diától (azaz a [theme background](/slides/hu/nodejs-java/presentation-theme/)).

**Mi történik a háttérrel, ha később megváltoztatom a prezentáció témáját?**

Ha egy diának saját kitöltése van, az változatlan marad. Ha a háttér a [layout](/slides/hu/nodejs-java/slide-layout/)/[master](/slides/hu/nodejs-java/slide-master/) diától van örökölve, akkor frissül az [új téma](/slides/hu/nodejs-java/presentation-theme/) szerint.