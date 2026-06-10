---
title: "Prezentáció háttér kezelése PHP-ben"
linktitle: "Dia háttér"
type: docs
weight: 20
url: /hu/php-java/presentation-background/
keywords:
- "prezentáció háttér"
- "dia háttér"
- "egyszínű szín"
- "színátmenet"
- "képes háttér"
- "háttér átlátszóság"
- "háttér tulajdonságok"
- PowerPoint
- OpenDocument
- "prezentáció"
- PHP
- Aspose.Slides
description: "Tanulja meg, hogyan állíthat be dinamikus háttereket PowerPoint és OpenDocument fájlokban az Aspose.Slides for PHP via Java használatával, kódtippekkel, amelyek javítják prezentációit."
---
## **Bevezetés**

Az egyszínű, fokozatos és képes háttér gyakran használt a diák háttereként. A háttér beállítható egy **normál dia** (egyetlen dia) vagy egy **műsorlevéldia** (több diára egyszerre vonatkozó) számára.

![PowerPoint háttér](powerpoint-background.png)

## **Egyszínű háttér beállítása normál diára**

Aspose.Slides lehetővé teszi, hogy egy adott dia háttérként egyszínű színt állítson be – még akkor is, ha a bemutató egy mesterdiát használ. A módosítás csak a kiválasztott diára vonatkozik.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/backgroundtype/) értékét `OwnBackground`‑ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) értékét `Solid`‑ra.
4. Használja a [getSolidFillColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/#getSolidFillColor) metódust a [FillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/) osztályon, hogy megadja az egyszínű háttérszínt.
5. Mentse a módosított bemutatót.

Az alábbi PHP példa azt mutatja be, hogyan állíthat be kék egyszínű hátteret egy normál diára:

```php
// Hozzon létre egy példányt a Presentation osztályból.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Állítsa be a dia háttérszínét kékre.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // Mentse a prezentációt a lemezre.
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Egyszínű háttér beállítása mesterdiára**

Aspose.Slides lehetővé teszi, hogy egyszínű színt állítson be a bemutató mesterdiájának háttérként. A mesterdia sablonként működik, amely az összes dia formázását irányítja, így amikor egyszínű színt választ a mesterdia háttérhez, az minden diára alkalmazásra kerül.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Állítsa be a mesterdia [BackgroundType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/backgroundtype/) értékét (a `getMasters` segítségével) `OwnBackground`‑ra.
3. Állítsa be a mesterdia háttér [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) értékét `Solid`‑ra.
4. Használja a [getSolidFillColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/#getSolidFillColor) metódust a háttér színének meghatározásához.
5. Mentse a módosított bemutatót.

Az alábbi PHP példa azt mutatja be, hogyan állíthat be zöld egyszínű hátteret egy mesterdiára:

```php
// Hozzon létre egy példányt a Presentation osztályból.
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // Állítsa be a Master dia háttérszínét erdei zöldre.
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // Mentse a prezentációt a lemezre.
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Fokozatos színű háttér beállítása diára**

A fokozat egy grafikai effektus, amely fokozatos színváltozással jön létre. Diák háttérként használva a fokozatok művészibbé és professzionálisabbá tehetik a bemutatókat. Az Aspose.Slides lehetővé teszi, hogy fokozat színt állítson be a diák háttérként.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/backgroundtype/) értékét `OwnBackground`‑ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) értékét `Gradient`‑ra.
4. Használja a [getGradientFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/#getGradientFormat) metódust a [FillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/) osztályon, hogy konfigurálja a kívánt fokozatbeállításokat.
5. Mentse a módosított bemutatót.

Az alábbi PHP példa azt mutatja be, hogyan állíthat be fokozat színt a dia háttérként:

```php
// Hozzon létre egy példányt a Presentation osztályból.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Alkalmazzon fokozat hatást a háttérre.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // Mentse a prezentációt a lemezre.
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kép beállítása diák háttérként**

Az egyszínű és fokozatú kitöltések mellett az Aspose.Slides lehetővé teszi, hogy képeket használjon diák háttérként.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/backgroundtype/) értékét `OwnBackground`‑ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) értékét `Picture`‑ra.
4. Töltse be a kívánt képet, amelyet a dia háttérként szeretne használni.
5. Adja hozzá a képet a bemutató képgyűjteményéhez.
6. Használja a [getPictureFillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/#getPictureFillFormat) metódust a [FillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/) osztályon, hogy a képet háttérként rendelje hozzá.
7. Mentse a módosított bemutatót.

Az alábbi PHP példa azt mutatja be, hogyan állíthat be képet a dia háttérként:

```php
// Hozzon létre egy példányt a Presentation osztályból.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Állítsa be a háttérkép tulajdonságait.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // Töltse be a képet.
    $image = Images::fromFile("Tulips.jpg");
    // Adja hozzá a képet a prezentáció képgyűjteményéhez.
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // Mentse a prezentációt a lemezre.
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az alábbi kódminta azt mutatja be, hogyan állítható be a háttér kitöltési típusa csempézett képre, és hogyan módosítható a csempézés tulajdonsága:

```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // Állítsa be a háttér kitöltéséhez használt képet.
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // Állítsa be a képkitöltés módját Csempére, és módosítsa a csempe tulajdonságait.
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
További információ: [**Tile Picture As Texture**](/slides/hu/php-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **A háttérkép átlátszóságának módosítása**

Lehet, hogy szeretné módosítani egy dia háttérképének átlátszóságát, hogy a dia tartalma jobban kiemelkedjen. Az alábbi PHP kód megmutatja, hogyan változtatható a dia háttérkép átlátszósága:

```php
$transparencyValue = 30; // Például.

// Szerezze meg a képtranszformációs műveletek gyűjteményét.
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// Keressen egy meglévő rögzített százalékos átlátszósági hatást.
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// Állítsa be az új átlátszósági értéket.
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```

## **Dia háttérértékének lekérdezése**

Az Aspose.Slides biztosítja a `BackgroundEffectiveData` osztályt a dia hatékony háttérértékeinek lekérdezéséhez. Ez az osztály a hatékony [FillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/) és [EffectFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effectformat/) elemeket teszi elérhetővé.

A [BaseSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslide/) osztály `getBackground` metódusával megkaphatja egy dia hatékony háttérét.

Az alábbi PHP példa azt mutatja be, hogyan kérhető le egy dia hatékony háttérértéke:

```php
// Hozzon létre egy példányt a Presentation osztályból.
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Szerezze be a hatékony hátteret, figyelembe véve a mestert, az elrendezést és a témát.
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```

## **GYIK**

**Vissza tudom állítani a saját háttér beállítását, és visszakapni a téma/oldalelrendezés hátterét?**

Igen. Távolítsa el a dia egyedi kitöltését, és a háttér újra örökölődik a megfelelő [layout](/slides/hu/php-java/slide-layout/)/[master](/slides/hu/php-java/slide-master/) diáról (azaz a [téma háttér](/slides/hu/php-java/presentation-theme/) esetén).

**Mi történik a háttérrel, ha később módosítom a bemutató témáját?**

Ha egy diának saját kitöltése van, az változatlan marad. Ha a háttér egy [layout](/slides/hu/php-java/slide-layout/)/[master](/slides/hu/php-java/slide-master/) diától öröklődik, az frissül az [új téma](/slides/hu/php-java/presentation-theme/) szerint.