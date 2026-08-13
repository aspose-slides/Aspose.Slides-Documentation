---
title: Prezentáció háttérkezelése .NET-ben
linktitle: Dia háttér
type: docs
weight: 20
url: /hu/net/presentation-background/
keywords:
- prezentáció háttér
- dia háttér
- egyszínű szín
- színátmenetes szín
- kép háttér
- háttér átlátszóság
- háttér tulajdonságok
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan állíthat be dinamikus háttereket PowerPoint és OpenDocument fájlokban az Aspose.Slides for .NET segítségével, kóbtippekkel a prezentációk fokozásához."
---
## **Bevezetés**

A háttérképhez gyakran használnak egyszínű hátteret, színátmeneteket és képeket. Beállíthatja a háttért egy **normál dia** (egyes dia) vagy egy **mester dia** (egyszerre több diára alkalmazva).

![PowerPoint háttér](powerpoint-background.png)

## **Egyszínű háttér beállítása normál diára**

Az Aspose.Slides lehetővé teszi, hogy egy egyszínű színt állítson be a háttérként egy adott diához a prezentációban – még akkor is, ha a prezentáció mester diát használ. A változtatás csak a kiválasztott diára vonatkozik.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/net/aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) értékét `Solid`-ra.
4. Használja a [SolidFillColor] tulajdonságot a [FillFormat]‑on a szilárd háttérszín megadásához.
5. Mentse el a módosított prezentációt.

A következő C# példa bemutatja, hogyan állíthat be egy kék egyszínű színt a háttérként egy normál diához:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Hozzon létre egy példányt a Presentation osztályból.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Állítsa be a dia háttérszínét kékre.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Mentse a prezentációt lemezre.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **Egyszínű háttér beállítása mester diára**

Az Aspose.Slides lehetővé teszi, hogy egy egyszínű színt állítson be a mester dia háttérként egy prezentációban. A mester dia sablonként működik, amely az összes dia formázását irányítja, így amikor egyszínű színt választ a mester dia háttéréhez, az minden diára alkalmazásra kerül.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
2. Állítsa be a mester dia [BackgroundType](https://reference.aspose.com/slides/hu/net/aspose.slides/backgroundtype/) (a `masters` használatával) értékét `OwnBackground`-ra.
3. Állítsa be a mester dia háttér [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) értékét `Solid`-ra.
4. Használja a [SolidFillColor]‑t a szilárd háttérszín megadásához.
5. Mentse el a módosított prezentációt.

A következő C# példa bemutatja, hogyan állíthat be egy egyszínű (erdőzöld) színt a mester dia háttérként:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Hozzon létre egy példányt a Presentation osztályból.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Állítsa be a mester dia háttérszínét erdei zöldre.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Mentse a prezentációt lemezre.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Színátmenetes háttér beállítása diára**

A színátmenet egy grafikai hatás, amelyet a szín fokozatos változása hoz létre. Dia háttérként használva a színátmenetek művészibbé és professzionálisabbá tehetik a prezentációkat. Az Aspose.Slides lehetővé teszi, hogy színátmenetes színt állítson be a diák háttérként.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/net/aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) értékét `Gradient`-ra.
4. Használja a [GradientFormat] tulajdonságot a [FillFormat]‑on a kívánt színátmenet beállításához.
5. Mentse el a módosított prezentációt.

A következő C# példa bemutatja, hogyan állíthat be egy színátmenetes színt a dia háttérként:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Hozzon létre egy példányt a Presentation osztályból.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Alkalmazzon színátmenetes effektust a háttérre.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Mentse a prezentációt lemezre.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **Kép beállítása dia háttérként**

Az egyszínű és színátmenetes kitöltéseken kívül az Aspose.Slides lehetővé teszi, hogy képeket használjon dia háttereként.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/net/aspose.slides/backgroundtype/) értékét `OwnBackground`-ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) értékét `Picture`-ra.
4. Töltse be a képet, amelyet a dia háttérként szeretne használni.
5. Adja hozzá a képet a prezentáció képgyűjteményéhez.
6. Használja a [PictureFillFormat] tulajdonságot a [FillFormat]‑on a kép háttérként való hozzárendeléséhez.
7. Mentse el a módosított prezentációt.

A következő C# példa bemutatja, hogyan állíthat be egy képet a dia háttérként:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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
    // Adja hozzá a képet a prezentáció képgyűjteményéhez.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Mentse a prezentációt lemezre.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // Állítsa be a háttérkitöltéshez használt képet.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Állítsa be a kép kitöltési módot Csempe-re, és módosítsa a csempe tulajdonságait.
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

{{% alert color="info" %}}
További információk: [**Csempe kép textúraként**](/slides/hu/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **A háttérkép átlátszóságának módosítása**

Lehet, hogy szeretné módosítani egy dia háttérképének átlátszóságát, hogy a dia tartalma kiemelkedjen. A következő C# kód megmutatja, hogyan változtatható a dia háttérkép átlátszósága:

```cs
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

var transparencyValue = 30; // Például.

using (Presentation presentation = new Presentation("ImageAsBackground.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Szerezze be a képtranszformációs műveletek gyűjteményét.
    var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

    // Keressen egy meglévő fix százalékos átlátszósági effektust.
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

    presentation.Save("ImageBackgroundTransparency.pptx", SaveFormat.Pptx);
}
```

## **Dia háttérértékének lekérése**

Az Aspose.Slides biztosítja a [IBackgroundEffectiveData] interfészt a dia hatékony háttérértékeinek lekéréséhez. Ez az interfész elérhetővé teszi a hatékony [FillFormat] és [EffectFormat] értékeket.

A [BaseSlide] osztály `background` tulajdonságának használatával lekérhető egy dia hatékony háttere.

A következő C# példa bemutatja, hogyan lehet lekérni egy dia hatékony háttérértékét:

```cs
using Aspose.Slides;

// Hozzon létre egy példányt a Presentation osztályból.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Szerezze meg a hatékony hátteret, figyelembe véve a master, layout és téma beállításait.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **GYIK**

### Visszaállíthatom-e a saját háttért, és visszaállíthatom a téma/elrendezés háttérjét?
Igen. Távolítsa el a dia egyéni kitöltését, és a háttér újra a megfelelő [layout](/slides/hu/net/slide-layout/)/[master](/slides/hu/net/slide-master/) diáról lesz örökölve (azaz a [téma háttér](/slides/hu/net/presentation-theme/)).

### Mi történik a háttérrel, ha később megváltoztatom a prezentáció témáját?
Ha egy dia saját kitöltéssel rendelkezik, az változatlan marad. Ha a háttér az [layout](/slides/hu/net/slide-layout/)/[master](/slides/hu/net/slide-master/) diáról van örökölve, akkor a [új téma](/slides/hu/net/presentation-theme/) szerint frissül.