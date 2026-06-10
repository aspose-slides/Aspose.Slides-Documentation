---
title: Androidon bemutatók hátterének kezelése
linktitle: Dia háttér
type: docs
weight: 20
url: /hu/androidjava/presentation-background/
keywords:
- bemutató háttér
- dia háttér
- egyszínű szín
- színátmenetes szín
- kép háttér
- háttér átlátszóság
- háttér tulajdonságok
- PowerPoint
- OpenDocument
- bemutató
- Android
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan állíthat be dinamikus háttereket PowerPoint és OpenDocument fájlokban az Aspose.Slides for Android segítségével Java nyelven, kódtippekkel, amelyek javítják bemutatóit."
---
## **Bevezetés**

Az egyszínű színek, a színátmenetek és a képek gyakran használatosak a diák háttérként. Beállíthatja a háttérképet egy **normál dia** (egyetlen diára) vagy egy **mesterdia** (több diára egyszerre) számára.

![PowerPoint background](powerpoint-background.png)

## **Egyszínű háttér beállítása normál diára**

Az Aspose.Slides lehetővé teszi, hogy egy konkrét diára egyszínű színt állítson be háttérnek – még akkor is, ha a bemutató egy mesterdiát használ. A változás csak a kiválasztott diára vonatkozik.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Solid`-ra.
4. Használja a [getSolidFillColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) metódust a [FillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/) osztályon a szilárd háttérszín megadásához.
5. Mentse el a módosított bemutatót.

A következő Java példa bemutatja, hogyan állíthat be kék egyszínű színt háttérként egy normál diára:

```java
// Hozzon létre egy példányt a Presentation osztályból.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Állítsa be a dia háttérszínét kékre.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Mentse el a bemutatót a lemezen.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Egyszínű háttér beállítása mesterdiára**

Az Aspose.Slides lehetővé teszi, hogy egyszínű színt állítson be a bemutató mesterdiájának háttérként. A mesterdia sablonként működik, amely az összes dia formázását szabályozza, így ha egyszínű színt választ a mesterdia háttérnek, az minden diára érvényes lesz.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Állítsa be a mesterdia [BackgroundType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/backgroundtype/) (a `getMasters` segítségével) értékét `OwnBackground`-ra.
3. Állítsa be a mesterdia háttér [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Solid`-ra.
4. Használja a [getSolidFillColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) metódust a szilárd háttérszín megadásához.
5. Mentse el a módosított bemutatót.

A következő Java példa bemutatja, hogyan állíthat be egy szilárd színt (zöld) háttérként a mesterdia számára:

```java
// Hozzon létre egy példányt a Presentation osztályból.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Állítsa be a Mester dia háttérszínét erdőzöldre.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Mentse el a bemutatót a lemezen.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Színátmenetes háttér beállítása diára**

A színátmenet egy olyan grafikai hatás, amely fokozatos színváltozással jön létre. Diák háttérként használva a színátmenetek művészibbé és professzionálisabbá tehetik a bemutatókat. Az Aspose.Slides lehetővé teszi, hogy színátmenetes színű hátteret állítson be diákhoz.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Gradient`-ra.
4. Használja a [getGradientFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) metódust a [FillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/) osztályon a kívánt színátmenet beállítások konfigurálásához.
5. Mentse el a módosított bemutatót.

A következő Java példa bemutatja, hogyan állíthat be színátmenetes színt háttérként egy diára:

```java
// Hozzon létre egy példányt a Presentation osztályból.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Alkalmazzon egy színátmenet hatást a háttérre.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // Mentse el a bemutatót a lemezen.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kép beállítása diák háttérként**

Az egyszínű és színátmenetes kitöltések mellett az Aspose.Slides lehetővé teszi képek használatát diák háttérként.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Picture`-ra.
4. Töltse be a képet, amelyet diák háttérként szeretne használni.
5. Adja hozzá a képet a bemutató képgyűjteményéhez.
6. Használja a [getPictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) metódust a [FillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/) osztályon a kép háttérként való hozzárendeléséhez.
7. Mentse el a módosított bemutatót.

A következő Java példa bemutatja, hogyan állíthat be képet háttérként egy diára:

```java
// Hozzon létre egy példányt a Presentation osztályból.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Állítsa be a háttérkép tulajdonságait.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // Töltse be a képet.
    IImage image = Images.fromFile("Tulips.jpg");
    // Add the image to the presentation's image collection.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Mentse el a bemutatót a lemezen.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A következő kódrészlet bemutatja, hogyan állíthatja be a háttér kitöltését csempeképre, és módosíthatja a csempebeállításokat:

```java
Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Állítsa be a háttérkitöltéshez használt képet.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Állítsa be a képkitöltési módot Csempe-re, és módosítsa a csempe tulajdonságait.
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Olvassa el tovább: [**Tile Picture As Texture**](/slides/hu/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **A háttérkép átlátszóságának módosítása**

Előfordulhat, hogy a dia háttérképének átlátszóságát szeretné módosítani, hogy a dia tartalma kiemelkedjen. A következő Java kód bemutatja, hogyan változtathatja meg egy dia háttérképének átlátszóságát:

```java
int transparencyValue = 30; // Például.

// Get the collection of picture transform operations.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Diák háttérérték lekérése**

Az Aspose.Slides biztosítja a [IBackgroundEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibackgroundeffectivedata/) interfészt a dia tényleges háttérértékeinek lekérdezéséhez. Ez az interfész a tényleges [FillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) és [EffectFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) adatait teszi elérhetővé.

A [BaseSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseslide/) osztály `getBackground` metódusával lekérheti egy dia tényleges háttérét.

A következő Java példa bemutatja, hogyan lehet lekérni egy dia tényleges háttérértékét:

```java
// Hozzon létre egy példányt a Presentation osztályból.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Szerezze be a tényleges hátteret, figyelembe véve a mestert, elrendezést és a témát.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Visszaállíthatom-e az egyéni hátteret és helyreállíthatom a téma/layout hátteret?**

Igen. Távolítsa el a dia egyéni kitöltését, és a háttér újra az adott [elrendezés](/slides/hu/androidjava/slide-layout/)/[mester](/slides/hu/androidjava/slide-master/) diáról lesz örökölve (azaz a [theme background](/slides/hu/androidjava/presentation-theme/) lesz).

**Mi történik a háttérrel, ha később megváltoztatom a bemutató témáját?**

Ha egy diának saját kitöltése van, az változatlan marad. Ha a háttér az [elrendezés](/slides/hu/androidjava/slide-layout/)/[mester](/slides/hu/androidjava/slide-master/) diától van örökölve, akkor frissül, hogy az [új téma](/slides/hu/androidjava/presentation-theme/) témához igazodjon.