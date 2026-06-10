---
title: Prezentáció hátterek kezelése Java-ban
linktitle: Dia háttér
type: docs
weight: 20
url: /hu/java/presentation-background/
keywords:
- prezentáció háttere
- dia háttere
- egységes szín
- színátmenet
- kép háttere
- háttér átlátszóság
- háttér tulajdonságok
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan állíthat be dinamikus háttereket PowerPoint és OpenDocument fájlokban az Aspose.Slides for Java használatával, kódtippekkel, amelyek felpezsdítik prezentációit."
---
## **Bevezetés**

Az egyszínű színek, a színátmenetek és a képek gyakran használatosak a diák háttereként. Beállíthatja a hátteret egy **normál diára** (egyetlen diára) vagy egy **mesterdiára** (egyszerre több diára vonatkozik).

![PowerPoint háttér](powerpoint-background.png)

## **Egyszínű háttér beállítása normál diára**

Az Aspose.Slides lehetővé teszi, hogy egy egységes színt állítson be háttérként egy adott diára a prezentációban – még akkor is, ha a prezentáció mesterdiát használ. A módosítás csak a kiválasztott diára vonatkozik.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Solid`-ra.
4. Használja a [getSolidFillColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/#getSolidFillColor--) metódust a [FillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/) osztályon, hogy megadja az egységes háttérszínt.
5. Mentse a módosított prezentációt.

A következő Java példa bemutatja, hogyan állíthat be kék egységes színt háttérként egy normál diára:

```java
// Hozzon létre egy példányt a Presentation osztályból.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Állítsa be a dia háttérszínét kékre.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Mentse a prezentációt a lemezre.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Egyszínű háttér beállítása mesterdiára**

Az Aspose.Slides lehetővé teszi, hogy egy egységes színt állítson be háttérként a mesterdia számára a prezentációban. A mesterdia sablonként működik, amely az összes dia formázását irányítja, ezért amikor egy egységes színt választ a mesterdia háttérnek, az minden diára érvényes.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Állítsa be a mesterdia [BackgroundType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/backgroundtype/)-ját (`getMasters` használatával) `OwnBackground`-ra.
3. Állítsa be a mesterdia háttér [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Solid`-ra.
4. Használja a [getSolidFillColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/#getSolidFillColor--) metódust a solid háttérszín megadásához.
5. Mentse a módosított prezentációt.

A következő Java példa bemutatja, hogyan állíthat be egy (zöld) egységes színt háttérként egy mesterdiára:

```java
// Hozzon létre egy példányt a Presentation osztályból.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Állítsa be a mesterdia háttérszínét erdőzöldre.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Mentse a prezentációt a lemezre.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Színátmenetes háttér beállítása diára**

A színátmenet egy grafikus hatás, amely fokozatos színváltozással jön létre. Diaként háttérként használva a színátmenetek művészibbé és professzionálisabbá tehetik a prezentációkat. Az Aspose.Slides lehetővé teszi, hogy színátmenetes színt állítson be háttérként a diákhoz.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Gradient`-ra.
4. Használja a [getGradientFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/#getGradientFormat--) metódust a [FillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/) osztályon, hogy beállítsa a kívánt színátmenet beállításokat.
5. Mentse a módosított prezentációt.

A következő Java példa bemutatja, hogyan állíthat be egy színátmenetes színt háttérként egy diára:

```java
// Hozzon létre egy példányt a Presentation osztályból.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Alkalmazzon egy színátmenet hatást a háttérre.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // Mentse a prezentációt a lemezre.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kép beállítása diák háttérként**

A szilárd és színátmenetes kitöltések mellett az Aspose.Slides lehetővé teszi képek használatát diák háttérként.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Picture`-ra.
4. Töltse be a képet, amelyet a dia háttérként szeretne használni.
5. Adja hozzá a képet a prezentáció képgyűjteményéhez.
6. Használja a [getPictureFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/#getPictureFillFormat--) metódust a [FillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/) osztályon, hogy a képet háttérként hozzárendelje.
7. Mentse a módosított prezentációt.

A következő Java példa bemutatja, hogyan állíthat be egy képet háttérként egy diára:

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
    // Adja hozzá a képet a prezentáció képgyűjteményéhez.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Mentse a prezentációt a lemezre.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

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

    // Állítsa be a kép kitöltési módot Tile-re, és módosítsa a csempe tulajdonságait.
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
Olvasson tovább: [**Kép csempézése textúraként**](/slides/hu/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **A háttérkép átlátszóságának módosítása**

Előfordulhat, hogy a dia háttérképének átlátszóságát szeretné módosítani, hogy a dia tartalma kiemelkedjen. A következő Java kód bemutatja, hogyan változtathatja meg egy dia háttérképének átlátszóságát:

```java
int transparencyValue = 30; // Például.

// A kép transzformációs műveletek gyűjteményének lekérése.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Keressen egy meglévő fix százalékos átlátszósági hatást.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// Állítsa be az új átlátszósági értéket.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **A dia háttérértékének lekérdezése**

Az Aspose.Slides biztosítja az [IBackgroundEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibackgroundeffectivedata/) interfészt a dia hatékony háttérértékeinek lekérdezéséhez. Ez az interfész a hatékony [FillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) és [EffectFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) lekérdezését teszi lehetővé.

A [BaseSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseslide/) osztály `getBackground` metódusát használva lekérheti egy dia hatékony háttérét.

A következő Java példa bemutatja, hogyan lehet lekérni egy dia hatékony háttérértékét:

```java
// Hozzon létre egy példányt a Presentation osztályból.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Szerezze be a hatékony hátteret, figyelembe véve a mestert, elrendezést és témát.
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

**Visszaállíthatom a testreszabott hátteret, és helyreállíthatom a téma/elrendezés hátterét?**

Igen. Távolítsa el a dia egyéni kitöltését, és a háttér újra az adott [layout](/slides/hu/java/slide-layout/)/[master](/slides/hu/java/slide-master/) diáról lesz örökölve (azaz a [téma háttér](/slides/hu/java/presentation-theme/)).

**Mi történik a háttérrel, ha később megváltoztatom a prezentáció témáját?**

Ha egy diának saját kitöltése van, az változatlan marad. Ha a háttér a [layout](/slides/hu/java/slide-layout/)/[master](/slides/hu/java/slide-master/) diáról van örökölve, akkor az [új téma](/slides/hu/java/presentation-theme/) szerint frissül.