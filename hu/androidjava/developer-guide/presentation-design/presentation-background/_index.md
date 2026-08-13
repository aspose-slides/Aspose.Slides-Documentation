---
title: Prezentáció hátterek kezelése Androidon
linktitle: Dia háttér
type: docs
weight: 20
url: /hu/androidjava/presentation-background/
keywords:
- prezentáció háttér
- dia háttér
- szilárd szín
- színátmenetes szín
- kép háttér
- háttér átlátszóság
- háttér tulajdonságok
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan állíthat be dinamikus háttereket PowerPoint és OpenDocument fájlokban az Androidra fejlesztett Aspose.Slides használatával Java nyelven, kódtippekkel, amelyek felgyorsítják prezentációit."
---
## **Bevezetés**

Az egyszínű színek, a színátmenetek és a képek gyakran használatosak a diák háttereként. Beállíthatja a hátteret egy **normál dia** (egyes dia) vagy egy **master dia** (több diara egyszerre).

![PowerPoint background](powerpoint-background.png)

## **Egyszínű háttér beállítása normál diára**

Az Aspose.Slides lehetővé teszi, hogy egy konkrét diához egy egyszínű hátteret állítson be a prezentációban – még akkor is, ha a prezentáció master diát használ. A módosítás csak a kiválasztott diára vonatkozik.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Solid`-ra.
4. Használja a [getSolidFillColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) metódust a [FillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/) osztályon a szilárd háttérszín meghatározásához.
5. Mentse el a módosított prezentációt.

A következő Java példa bemutatja, hogyan állíthat be kék szilárd színt háttérként egy normál diára:

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

## **Egyszínű háttér beállítása master diára**

Az Aspose.Slides lehetővé teszi, hogy egy egyszínű hátteret állítson be a prezentáció master diájához. A master dia sablonként működik, amely a formázást minden diához szabályozza, ezért amikor egy egyszínű színt választ a master dia háttéréhez, az minden diára érvényes lesz.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Állítsa be a master dia [BackgroundType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/backgroundtype/) (a `getMasters` segítségével) értékét `OwnBackground`-ra.
3. Állítsa be a master dia háttér [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Solid`-ra.
4. Használja a [getSolidFillColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) metódust a szilárd háttérszín meghatározásához.
5. Mentse el a módosított prezentációt.

A következő Java példa bemutatja, hogyan állíthat be egy zöld szilárd színt háttérként egy master diára:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Hozzon létre egy példányt a Presentation osztályból.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Állítsa be a master dia háttérszínét zöldre.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Mentse el a prezentációt a lemezen.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Színátmenetes háttér beállítása diához**

A színátmenet egy grafikus hatás, amely fokozatos színváltással jön létre. Diák háttérként használva a színátmenetek művészibbé és professzionálisabbá tehetik a prezentációkat. Az Aspose.Slides lehetővé teszi, hogy színátmenetes színt állítson be a diák háttérként.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Gradient`-ra.
4. Használja a [getGradientFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) metódust a [FillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/) osztályon a kívánt színátmenet beállítások konfigurálásához.
5. Mentse el a módosított prezentációt.

A következő Java példa bemutatja, hogyan állíthat be színátmenetes színt háttérként egy diára:

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

    // Adja hozzá a színátmenet színeit. Gradient stopok nélkül a háttér alapértelmezett fekete-fehér színskálára visszaesik.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Mentse el a prezentációt a lemezen.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kép beállítása diák háttérként**

Az egyszínű és színátmenetes kitöltéseken kívül az Aspose.Slides lehetővé teszi képek használatát diák háttérként.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Picture`-ra.
4. Töltse be a képet, amelyet a diának háttérként szeretne használni.
5. Adja hozzá a képet a prezentáció képgyűjteményéhez.
6. Használja a [getPictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) metódust a [FillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/) osztályon a kép háttérként történő hozzárendeléséhez.
7. Mentse el a módosított prezentációt.

A következő Java példa bemutatja, hogyan állíthat be egy képet háttérként egy diára:

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

A következő kódrészlet mutatja, hogyan állítható be a háttér kitöltési típusa csempézett képre, és módosíthatók a csempézés tulajdonságai:

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

    // A háttér kitöltéséhez használt kép beállítása.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // A kép kitöltési mód beállítása Csempére és a csempézés tulajdonságainak módosítása.
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
További információ: [**Tile Picture As Texture**](/slides/hu/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **A háttérkép átlátszóságának módosítása**

Lehet, hogy a diák háttérkép átlátszóságát szeretné állítani, hogy a dia tartalma jobban kiemelkedjen. A következő Java kód bemutatja, hogyan változtathatja meg a diák háttérkép átlátszóságát:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Például.

Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // A képtömörítés műveletek gyűjteményének lekérése.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // Keressen egy meglévő fix százalékos átlátszósági effektet.
    IAlphaModulateFixed transparencyOperation = null;
    for (IImageTransformOperation operation : imageTransform) {
        if (operation instanceof IAlphaModulateFixed) {
            transparencyOperation = (IAlphaModulateFixed)operation;
            break;
        }
    }

    // Az új átlátszósági érték beállítása.
    if (transparencyOperation == null) {
        imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else {
        transparencyOperation.setAmount(100 - transparencyValue);
    }

    presentation.save("TransparentBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A dia háttérértékének lekérdezése**

Az Aspose.Slides biztosítja a [IBackgroundEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibackgroundeffectivedata/) interfészt a dia tényleges háttérértékeinek lekérdezéséhez. Ez az interfész elérhetővé teszi a tényleges [FillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) és [EffectFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) értékeket.

A [BaseSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseslide/) osztály `getBackground` metódusával lekérheti a dia tényleges hátterét.

A következő Java példa bemutatja, hogyan lehet lekérni egy dia tényleges háttérértékét:

```java
import com.aspose.slides.*;

// Létrehoz egy példányt a Presentation osztályból.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lekéri a tényleges hátteret, figyelembe véve a master, layout és téma beállításait.
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

### **Visszaállíthatom-e az egyéni hátteret és visszaállíthatom a téma/layoutháttér értékét?**
Igen. Távolítsa el a dia egyéni kitöltését, és a háttér újra az adott [layout](/slides/hu/androidjava/slide-layout/)/[master](/slides/hu/androidjava/slide-master/) diához (azaz a [téma háttérhez](/slides/hu/androidjava/presentation-theme/)) lesz örökölve.

### **Mi történik a háttérrel, ha később megváltoztatom a prezentáció témáját?**
Ha egy diához saját kitöltése van, az változatlan marad. Ha a háttér a [layout](/slides/hu/androidjava/slide-layout/)/[master](/slides/hu/androidjava/slide-master/) diáról van örökölve, akkor frissül, hogy megfeleljen az [új témának](/slides/hu/androidjava/presentation-theme/).