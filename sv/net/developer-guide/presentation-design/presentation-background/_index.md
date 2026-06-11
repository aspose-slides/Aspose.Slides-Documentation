---
title: Hantera presentationens bakgrunder i .NET
linktitle: Bildbakgrund
type: docs
weight: 20
url: /sv/net/presentation-background/
keywords:
- presentationsbakgrund
- bildbakgrund
- solid färg
- gradientfärg
- bildbakgrund
- bakgrundstransparens
- bakgrundsegenskaper
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du ställer in dynamiska bakgrunder i PowerPoint- och OpenDocument-filer med Aspose.Slides för .NET, med kodtips för att förbättra dina presentationer."
---
## **Introduktion**

Solida färger, gradienter och bilder används ofta som bildbakgrunder. Du kan ange bakgrunden för en **normal bild** (en enskild bild) eller en **masterbild** (gäller för flera bilder samtidigt).

![PowerPoint-bakgrund](powerpoint-background.png)

## **Ange en solid färg som bakgrund för en normal bild**

Aspose.Slides låter dig ange en solid färg som bakgrund för en specifik bild i en presentation—även om presentationen använder en masterbild. Ändringen gäller endast den valda bilden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
2. Ställ in bildens [BackgroundType](https://reference.aspose.com/slides/sv/net/aspose.slides/backgroundtype/) till `OwnBackground`.
3. Ställ in bildbakgrundens [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) till `Solid`.
4. Använd egenskapen [SolidFillColor](https://reference.aspose.com/slides/sv/net/aspose.slides/fillformat/solidfillcolor/) på [FillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/fillformat/) för att ange den solida bakgrundsfärgen.
5. Spara den modifierade presentationen.

Följande C#-exempel visar hur du anger en blå solid färg som bakgrund för en normal bild:

```cs
// Skapa en instans av Presentation-klassen.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ställ in bakgrundsfärgen för bilden till blå.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Spara presentationen till disk.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **Ange en solid färg som bakgrund för en masterbild**

Aspose.Slides låter dig ange en solid färg som bakgrund för masterbilden i en presentation. Masterbilden fungerar som en mall som styr formatering för alla bilder, så när du väljer en solid färg för masterbildens bakgrund gäller den för varje bild.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
2. Ställ in masterbildens [BackgroundType](https://reference.aspose.com/slides/sv/net/aspose.slides/backgroundtype/) (via `masters`) till `OwnBackground`.
3. Ställ in masterbildens bakgrund [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) till `Solid`.
4. Använd [SolidFillColor](https://reference.aspose.com/slides/sv/net/aspose.slides/fillformat/solidfillcolor/) för att ange den solida bakgrundsfärgen.
5. Spara den modifierade presentationen.

Följande C#-exempel visar hur du anger en solid färg (skoggrön) som bakgrund för en masterbild:

```cs
// Skapa en instans av Presentation-klassen.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Ställ in bakgrundsfärgen för Master-bilden till Skogsgrön.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Spara presentationen till disk.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Ange en gradientbakgrund för en bild**

En gradient är en grafisk effekt som skapats genom en gradvis färgförändring. När den används som bildbakgrund kan gradienter göra presentationer mer konstnärliga och professionella. Aspose.Slides låter dig ange en gradientfärg som bakgrund för bilder.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
2. Ställ in bildens [BackgroundType](https://reference.aspose.com/slides/sv/net/aspose.slides/backgroundtype/) till `OwnBackground`.
3. Ställ in bildbakgrundens [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) till `Gradient`.
4. Använd egenskapen [GradientFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/fillformat/gradientformat/) på [FillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/fillformat/) för att konfigurera dina föredragna gradientinställningar.
5. Spara den modifierade presentationen.

Följande C#-exempel visar hur du anger en gradientfärg som bakgrund för en bild:

```cs
// Skapa en instans av Presentation-klassen.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Applicera en gradienteffekt på bakgrunden.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Spara presentationen till disk.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **Ange en bild som bildbakgrund**

Förutom solida och gradientfyllningar låter Aspose.Slides dig använda bilder som bildbakgrunder.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
2. Ställ in bildens [BackgroundType](https://reference.aspose.com/slides/sv/net/aspose.slides/backgroundtype/) till `OwnBackground`.
3. Ställ in bildbakgrundens [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) till `Picture`.
4. Ladda bilden du vill använda som bildbakgrund.
5. Lägg till bilden i presentationens bildsamling.
6. Använd egenskapen [PictureFillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/fillformat/picturefillformat/) på [FillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/fillformat/) för att tilldela bilden som bakgrund.
7. Spara den modifierade presentationen.

Följande C#-exempel visar hur du anger en bild som bakgrund för en bild:

```c#
    // Skapa en instans av Presentation-klassen.
    using (Presentation presentation = new Presentation())
    {
        ISlide slide = presentation.Slides[0];

        // Ställ in bakgrundsbildens egenskaper.
        slide.Background.Type = BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = FillType.Picture;
        slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

        // Ladda bilden.
        IImage image = Images.FromFile("Tulips.jpg");
        // Lägg till bilden i presentationens bildsamling.
        IPPImage ppImage = presentation.Images.AddImage(image);
        image.Dispose();

        slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

        // Spara presentationen till disk.
        presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
    }
```

Följande kodexempel visar hur du ställer in bakgrundsfyllningstypen till en tiled picture och ändrar tiling-egenskaperna:

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

    // Använd bilden som bakgrundsfyllning.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Ställ in bildfyllningsläget till Tile och justera tile-egenskaperna.
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
Läs mer: [**Tile Picture As Texture**](/slides/sv/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Ändra bildbakgrundens transparens**

Du kanske vill justera transparensen för en bilds bakgrundsbild för att få bildens innehåll att sticka ut. Följande C#-kod visar hur du ändrar transparensen för en bildbakgrundsbild:

```cs
var transparencyValue = 30; // Till exempel.

var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Hämta samlingen av bildtransformationsoperationer.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Hitta en befintlig transparenseffekt med fast procentandel.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}

// Ställ in det nya transparensvärdet.
```

## **Hämta bildens bakgrundsvärde**

Aspose.Slides tillhandahåller gränssnittet [IBackgroundEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ibackgroundeffectivedata/) för att hämta en bilds effektiva bakgrundsvärden. Detta gränssnitt exponerar den effektiva [FillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ibackgroundeffectivedata/fillformat/) och [EffectFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ibackgroundeffectivedata/effectformat/).

Genom att använda [BaseSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/baseslide/) klassens `background`-egenskap kan du hämta den effektiva bakgrunden för en bild.

Följande C#-exempel visar hur du hämtar en bilds effektiva bakgrundsvärde:

```cs
// Skapa en instans av Presentation-klassen.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Hämta den effektiva bakgrunden med hänsyn till master, layout och tema.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **FAQ**

**Kan jag återställa en anpassad bakgrund och återställa tema-/layoutbakgrunden?**

Ja. Ta bort bildens anpassade fyllning så ärver bakgrunden igen från den motsvarande [layout](/slides/sv/net/slide-layout/)/[master](/slides/sv/net/slide-master/) bilden (dvs. [tema bakgrund](/slides/sv/net/presentation-theme/)).

**Vad händer med bakgrunden om jag ändrar presentationens tema senare?**

Om en bild har sin egen fyllning förblir den oförändrad. Om bakgrunden ärvdes från [layout](/slides/sv/net/slide-layout/)/[master](/slides/sv/net/slide-master/) uppdateras den för att matcha det [nya temat](/slides/sv/net/presentation-theme/).