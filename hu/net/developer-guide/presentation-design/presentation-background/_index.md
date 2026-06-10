---
title: Prezentáció háttereinek kezelése .NET-ben
linktitle: Dia háttér
type: docs
weight: 20
url: /hu/net/presentation-background/
keywords:
- prezentáció háttér
- dia háttér
- egyszinű szín
- gradiens szín
- kép háttér
- háttér átlátszóság
- háttér tulajdonságok
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan állíthat be dinamikus háttereket PowerPoint és OpenDocument fájlokban az Aspose.Slides for .NET használatával, kódtippekkel a prezentációk fejlesztéséhez."
---
## **Bevezetés**

Az egyszínű háttér, a fokozatok és a képek gyakran használatosak diák háttérként. Beállíthatja a háttérképet egy **normál dia** (egyetlen dia) vagy egy **mester dia** (több dia egyszerre) számára.

![PowerPoint háttér](powerpoint-background.png)

## **Egyszínű háttér beállítása normál diára**

Az Aspose.Slides lehetővé teszi, hogy egy konkrét diában egyszínű hátteret állítson be a bemutatóban – még akkor is, ha a bemutató mester diát használ. A módosítás csak a kiválasztott diára vonatkozik.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/net/aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) értékét `Solid`-ra.
4. Használja a [SolidFillColor](https://reference.aspose.com/slides/hu/net/aspose.slides/fillformat/solidfillcolor/) tulajdonságot a [FillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/fillformat/) objektumon a szilárd háttérszín megadásához.
5. Mentse a módosított bemutatót.

Az alábbi C# példa bemutatja, hogyan állíthat be kék egyszínű hátteret egy normál diára:

```cs
// Hozzon létre egy példányt a Presentation osztályból.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Állítsa be a dia háttérszínét kékre.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Mentse a bemutatót a lemezre.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **Egyszínű háttér beállítása mester diára**

Az Aspose.Slides lehetővé teszi, hogy a bemutató mester diájának háttérként egyszínű színt állítson be. A mester dia sablonként működik, amely az összes dia formázását irányítja, így amikor egy egyszínű színt választ a mester dia háttérhez, az az összes diára érvényes lesz.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
2. Állítsa be a mester dia [BackgroundType](https://reference.aspose.com/slides/hu/net/aspose.slides/backgroundtype/) (a `masters` használatával) értékét `OwnBackground`-ra.
3. Állítsa be a mester dia háttér [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) értékét `Solid`-ra.
4. Használja a [SolidFillColor](https://reference.aspose.com/slides/hu/net/aspose.slides/fillformat/solidfillcolor/) tulajdonságot a szilárd háttérszín megadásához.
5. Mentse a módosított bemutatót.

Az alábbi C# példa bemutatja, hogyan állíthat be egy szilárd színt (erdőzöld) a mester dia háttérként:

```cs
// Hozzon létre egy példányt a Presentation osztályból.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Állítsa be a mester dia háttérszínét erdőzöldre.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Mentse a bemutatót a lemezre.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Gradiens háttér beállítása diára**

A gradiens egy grafikai effekt, amely szín fokozatos változásából jön létre. Diák háttérként használva a gradiensek művészibbé és professzionálisabbá tehetik a bemutatókat. Az Aspose.Slides lehetővé teszi, hogy gradienst állítson be diák háttérként.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/net/aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) értékét `Gradient`-ra.
4. Használja a [GradientFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/fillformat/gradientformat/) tulajdonságot a [FillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/fillformat/) objektumon a kívánt gradiens beállítások konfigurálásához.
5. Mentse a módosított bemutatót.

Az alábbi C# példa bemutatja, hogyan állíthat be gradienst a dia háttérként:

```cs
// Hozzon létre egy példányt a Presentation osztályból.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Alkalmazzon gradiens hatást a háttérre.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Mentse a bemutatót a lemezre.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **Kép beállítása dia háttérként**

A szilárd és gradiens kitöltéseken kívül az Aspose.Slides lehetővé teszi képek használatát dia háttérként.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/net/aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) értékét `Picture`-ra.
4. Töltse be a képet, amelyet a dia háttérként szeretne használni.
5. Adja hozzá a képet a bemutató képgyűjteményéhez.
6. Használja a [PictureFillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/fillformat/picturefillformat/) tulajdonságot a [FillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/fillformat/) objektumon a kép hátérként történő hozzárendeléséhez.
7. Mentse a módosított bemutatót.

Az alábbi C# példa bemutatja, hogyan állíthat be egy képet a dia háttérként:

```c#
// Hozzon létre egy példányt a Presentation osztályból.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Állítsa be a háttérkép tulajdonságait.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Töltse be a képet.
    IImage image = Images.FromFile("Tulips.jpg");
    // Adja hozzá a képet a bemutató képgyűjteményéhez.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Mentse a bemutatót a lemezre.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttér kitöltési típusa csempeképre, és hogyan módosíthatók a csempézés beállításai:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // Állítsa be a háttér kitöltéséhez használt képet.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Állítsa be a kép kitöltési módot Csempére, és módosítsa a csempe tulajdonságait.
    backPictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    backPictureFillFormat.TileOffsetX = 15f;
    backPictureFillFormat.TileOffsetY = 15f;
    backPictureFillFormat.TileScaleX = 46f;
    backPictureFillFormat.TileScaleY = 87f;
    backPictureFillFormat.TileAlignment = RectangleAlignment.Center;
    backPictureFillFormat.TileFlip = TileFlip.FlipY;

    presentation.Save("TileBackground.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Olvasd tovább: [**Csempézett kép textúraként**](/slides/hu/net/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **A háttérkép átlátszóságának módosítása**

Előfordulhat, hogy a dia háttérkép átlátszóságát szeretné módosítani, hogy a dia tartalma kiemelkedjen. Az alábbi C# kód bemutatja, hogyan változtatható meg egy dia háttérkép átlátszósága:

```cs
var transparencyValue = 30; // Például.

// Szerezze meg a képtranszformációs műveletek gyűjteményét.
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Keressen egy meglévő fix százalékos átlátszósági hatást.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Állítsa be az új átlátszósági értéket.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```

## **A dia háttérértékének lekérdezése**

Az Aspose.Slides biztosítja az [IBackgroundEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ibackgroundeffectivedata/) interfészt a dia tényleges háttérértékeinek lekérdezéséhez. Ez az interfész a tényleges [FillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ibackgroundeffectivedata/fillformat/) és [EffectFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ibackgroundeffectivedata/effectformat/) adatokat teszi elérhetővé.

A [BaseSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/baseslide/) osztály `background` tulajdonságának használatával lekérheti egy dia tényleges hátterét.

Az alábbi C# példa bemutatja, hogyan lehet megszerezni egy dia tényleges háttérértékét:

```cs
// Hozzon létre egy példányt a Presentation osztályból.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Szerezze meg a hatékony háttérét, figyelembe véve a mestert, elrendezést és a témát.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **GYIK**

**Visszaállíthatom a saját hátteret, és visszanyerhetem a téma/elrendezés hátterét?**

Igen. Távolítsa el a dia egyéni kitöltését, és a háttér újra az adott [elrendezés](/slides/hu/net/slide-layout/)/[mester](/slides/hu/net/slide-master/) diáról fog öröklődni (azaz a [theme background](/slides/hu/net/presentation-theme/) lesz).

**Mi történik a háttérrel, ha később megváltoztatom a bemutató témáját?**

Ha egy diához saját kitöltés van rendelve, az változatlan marad. Ha a háttér az [elrendezés](/slides/hu/net/slide-layout/)/[mester](/slides/hu/net/slide-master/) diáról öröklődik, akkor frissül, hogy a [új téma](/slides/hu/net/presentation-theme/) szerint legyen.