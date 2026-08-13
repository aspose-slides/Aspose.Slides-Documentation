---
title: Prezentáció háttér kezelése Java-ban
linktitle: Dia háttér
type: docs
weight: 20
url: /hu/java/presentation-background/
keywords:
- prezentáció háttér
- dia háttér
- egyszínű szín
- átmenetes szín
- kép háttér
- háttér átlátszóság
- háttér tulajdonságok
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan állíthat be dinamikus háttereket PowerPoint és OpenDocument fájlokban az Aspose.Slides for Java használatával, kódtippekkel, amelyek feljavítják prezentációit."
---
## **Bevezetés**

Az egyszínű színek, a színátmenetek és a képek gyakran használatosak a dia hátterekhez. Beállíthatja a hátteret egy **normál diára** (egyetlen dia) vagy egy **mesterdiára** (több diára egyszerre vonatkozik).

![PowerPoint background](powerpoint-background.png)

## **Egyszínű háttér beállítása normál diára**

Az Aspose.Slides lehetővé teszi, hogy egy egyszínű színt állítson be háttérként egy adott diára a prezentációban – még akkor is, ha a prezentáció mesterdiát használ. A módosítás csak a kiválasztott diára vonatkozik.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Solid`-ra.
4. Használja a [getSolidFillColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/#getSolidFillColor--) metódust a [FillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/) osztályon a háttér színének meghatározásához.
5. Mentse el a módosított prezentációt.

Az alábbi Java példa bemutatja, hogyan állíthat be kék egyszínű hátteret egy normál diára:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Hozzon létre egy példányt a Presentation osztályból.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Állítsa be a dia háttérszínét kékre.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Mentse el a prezentációt a lemezen.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Egyszínű háttér beállítása mesterdiára**

Az Aspose.Slides lehetővé teszi, hogy egyszínű színt állítson be háttérként a prezentáció mesterdiájára. A mesterdia sablonként működik, amely az összes dia formázását szabályozza, így amikor egyszínű színt választ a mesterdia háttérhez, az minden diára alkalmazásra kerül.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Állítsa be a mesterdia [BackgroundType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/backgroundtype/) (a `getMasters` segítségével) értékét `OwnBackground`-ra.
3. Állítsa be a mesterdia háttér [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Solid`-ra.
4. Használja a [getSolidFillColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/#getSolidFillColor--) metódust a háttér színének meghatározásához.
5. Mentse el a módosított prezentációt.

Az alábbi Java példa bemutatja, hogyan állíthat be egyszínű (zöld) hátteret egy mesterdiára:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Hozzon létre egy példányt a Presentation osztályból.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Állítsa be a mesterdia háttérszínét zöldre.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Mentse el a prezentációt a lemezen.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Átmenetes háttér beállítása egy diára**

Az átmenet egy grafikus hatás, amely fokozatos színváltozással jön létre. Diák háttérként használva az átmenetek művészibbé és professzionálisabbá tehetik a prezentációkat. Az Aspose.Slides lehetővé teszi, hogy átmenetes színt állítson be háttérként a diák számára.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Gradient`-ra.
4. Használja a [getGradientFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/#getGradientFormat--) metódust a [FillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/) osztályon, hogy beállítsa a kívánt átmenet‑beállításokat.
5. Mentse el a módosított prezentációt.

Az alábbi Java példa bemutatja, hogyan állíthat be egy átmenetes színt háttérként egy diára:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Hozzon létre egy példányt a Presentation osztályból.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Alkalmazzon színátmenet hatást a háttérre.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // Adja hozzá a színátmenet színeit. Gradient stopok nélkül a háttér visszatér az alapértelmezett fekete-fehér skálához.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Mentse el a prezentációt a lemezen.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kép beállítása dia háttérként**

Az egyszínű és átmenetes kitöltéseken túl az Aspose.Slides lehetővé teszi, hogy képeket használjon dia háttérként.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Picture`-ra.
4. Töltsük be a használni kívánt képet a dia háttérhez.
5. Adja hozzá a képet a prezentáció képgyűjteményéhez.
6. Használja a [getPictureFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/#getPictureFillFormat--) metódust a [FillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/) osztályon, hogy a képet háttérként rendelje hozzá.
7. Mentse el a módosított prezentációt.

Az alábbi Java példa bemutatja, hogyan állíthat be egy képet háttérként egy diára:

```java
import com.aspose.slides.*;

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
    
    // Mentse el a prezentációt a lemezen.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az alábbi kódmintát mutatja be, hogyan állítható be a háttér kitöltési típusa csempézett képre, és hogyan módosíthatók a csempézés tulajdonságai:

```java
import com.aspose.slides.*;

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

    // Állítsa be a képkitöltés módját Csempére és módosítsa a csempe tulajdonságait.
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

{{% alert color="info" %}}
Olvasson tovább: [**Tile Picture As Texture**](/slides/hu/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **A háttérkép átlátszóságának módosítása**

Lehet, hogy szeretné módosítani egy dia háttérképének átlátszóságát, hogy a dia tartalma kiemelkedjen. Az alábbi Java kód megmutatja, hogyan változtatható meg a dia háttérképének átlátszósága:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Például.

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Szerezze be a képtranszformációs műveletek gyűjteményét.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // Keresse meg a meglévő fix százalékos átlátszósági hatást.
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

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A dia háttérértékének lekérése**

Aspose.Slides biztosítja az [IBackgroundEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibackgroundeffectivedata/) interfészt a dia hatékony háttérértékeinek lekéréséhez. Ez az interfész hozzáférést biztosít a hatékony [FillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) és [EffectFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) értékekhez.

A [BaseSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseslide/) osztály `getBackground` metódusával lekérheti egy dia hatékony háttérét.

Az alábbi Java példa bemutatja, hogyan kapja meg egy dia hatékony háttérértékét:

```java
import com.aspose.slides.*;

// Hozzon létre egy példányt a Presentation osztályból.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Szerezze be a hatékony hátteret, figyelembe véve a mestert, a layoutot és a témát.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Visszaállíthatom a saját háttér beállítást és visszaállíthatom a téma/layout háttér?

Igen. Távolítsa el a dia egyéni kitöltését, és a háttér újra öröklődik a megfelelő [layout](/slides/hu/java/slide-layout/)/[master](/slides/hu/java/slide-master/) diáktól (azaz a [theme background](/slides/hu/java/presentation-theme/)).

### Mi történik a háttérrel, ha később megváltoztatom a prezentáció témáját?

Ha egy diának saját kitöltése van, az változatlan marad. Ha a háttér a [layout](/slides/hu/java/slide-layout/)/[master](/slides/hu/java/slide-master/) diáktól öröklődik, akkor frissül, hogy megfeleljen az [új témának](/slides/hu/java/presentation-theme/).