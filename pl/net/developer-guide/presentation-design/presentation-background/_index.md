---
title: Zarządzanie tłami prezentacji w .NET
linktitle: Tło slajdu
type: docs
weight: 20
url: /pl/net/presentation-background/
keywords:
- tło prezentacji
- tło slajdu
- jednolity kolor
- gradientowy kolor
- tło obrazu
- przezroczystość tła
- właściwości tła
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak ustawiać dynamiczne tła w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET, z wskazówkami kodu zwiększającymi jakość twoich prezentacji."
---
## **Wprowadzenie**

Jednolite kolory, gradienty i obrazy są powszechnie używane jako tła slajdów. Możesz ustawić tło dla **zwykłego slajdu** (pojedynczego slajdu) lub **slajdu nadrzędnego** (stosowanego do wielu slajdów jednocześnie).

![PowerPoint background](powerpoint-background.png)

## **Ustaw jednolite tło koloru dla zwykłego slajdu**

Aspose.Slides umożliwia ustawienie jednolitego koloru jako tło dla konkretnego slajdu w prezentacji — nawet jeśli prezentacja używa slajdu nadrzędnego. Zmiana dotyczy tylko wybranego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/net/aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/net/aspose.slides/filltype/) tła slajdu na `Solid`.
4. Użyj właściwości [SolidFillColor](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/solidfillcolor/) na [FillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/), aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz instancję klasy Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ustaw kolor tła slajdu na niebieski.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Zapisz prezentację na dysku.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **Ustaw jednolite tło koloru dla slajdu nadrzędnego**

Aspose.Slides umożliwia ustawienie jednolitego koloru jako tła dla slajdu nadrzędnego w prezentacji. Slajd nadrzędny pełni rolę szablonu, który kontroluje formatowanie wszystkich slajdów, więc gdy wybierzesz jednolity kolor tła slajdu nadrzędnego, zostanie on zastosowany do każdego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/net/aspose.slides/backgroundtype/) slajdu nadrzędnego (przez `masters`) na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/net/aspose.slides/filltype/) tła slajdu nadrzędnego na `Solid`.
4. Użyj [SolidFillColor](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/solidfillcolor/), aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz instancję klasy Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Ustaw kolor tła slajdu nadrzędnego na Zielony Leśny.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Zapisz prezentację na dysku.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Ustaw gradientowe tło dla slajdu**

Gradient to efekt graficzny powstający w wyniku stopniowej zmiany koloru. Używany jako tło slajdu, gradient może sprawić, że prezentacje wyglądają bardziej artystycznie i profesjonalnie. Aspose.Slides umożliwia ustawienie koloru gradientu jako tła dla slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/net/aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/net/aspose.slides/filltype/) tła slajdu na `Gradient`.
4. Użyj właściwości [GradientFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/gradientformat/) na [FillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/), aby skonfigurować preferowane ustawienia gradientu.
5. Zapisz zmodyfikowaną prezentację.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz instancję klasy Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Zastosuj efekt gradientu do tła.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Zapisz prezentację na dysku.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **Ustaw obraz jako tło slajdu**

Oprócz jednolitych i gradientowych wypełnień, Aspose.Slides pozwala używać obrazów jako tła slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/net/aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/net/aspose.slides/filltype/) tła slajdu na `Picture`.
4. Wczytaj obraz, którego chcesz użyć jako tło slajdu.
5. Dodaj obraz do kolekcji obrazów prezentacji.
6. Użyj właściwości [PictureFillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/picturefillformat/) na [FillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/), aby przypisać obraz jako tło.
7. Zapisz zmodyfikowaną prezentację.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz instancję klasy Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ustaw właściwości obrazu tła.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Wczytaj obraz.
    IImage image = Images.FromFile("Tulips.jpg");
    // Dodaj obraz do kolekcji obrazów prezentacji.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Zapisz prezentację na dysku.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

Następny fragment kodu pokazuje, jak ustawić typ wypełnienia tła na obraz kafelkowany i zmodyfikować właściwości kafelkowania:

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

    // Ustaw obraz używany do wypełnienia tła.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Ustaw tryb wypełnienia obrazu na Kafelkowanie i dostosuj właściwości kafelków.
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

Dowiedz się więcej: [**Tile Picture As Texture**](/slides/pl/net/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Zmień przezroczystość obrazu tła**

Możesz chcieć dostosować przezroczystość obrazu tła slajdu, aby wyróżnić zawartość slajdu. Poniższy kod C# pokazuje, jak zmienić przezroczystość obrazu tła slajdu:

```cs
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

var transparencyValue = 30; // Na przykład.

using (Presentation presentation = new Presentation("ImageAsBackground.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Pobierz kolekcję operacji przekształceń obrazu.
    var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

    // Znajdź istniejący efekt przeźroczystości o stałym procencie.
    var transparencyOperation = null as IAlphaModulateFixed;
    foreach (var operation in imageTransform)
    {
        if (operation is IAlphaModulateFixed alphaModulateFixed)
        {
            transparencyOperation = alphaModulateFixed;
            break;
        }
    }

    // Ustaw nową wartość przeźroczystości.
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

## **Pobierz wartość tła slajdu**

Aspose.Slides udostępnia interfejs [IBackgroundEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ibackgroundeffectivedata/) do pobierania efektywnych wartości tła slajdu. Interfejs ten eksponuje efektywne [FillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ibackgroundeffectivedata/fillformat/) i [EffectFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ibackgroundeffectivedata/effectformat/). Korzystając z właściwości `background` klasy [BaseSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/baseslide/), możesz uzyskać efektywne tło slajdu.

```cs
using Aspose.Slides;

// Utwórz instancję klasy Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Pobierz efektywne tło, uwzględniając master, layout i motyw.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **FAQ**

### Czy mogę zresetować niestandardowe tło i przywrócić tło układu/nadrzędnego slajdu?

Tak. Usuń niestandardowe wypełnienie slajdu, a tło zostanie ponownie odziedziczone z odpowiedniego slajdu [układ](/slides/pl/net/slide-layout/)/[nadrzędny](/slides/pl/net/slide-master/) (czyli z [tło motywu](/slides/pl/net/presentation-theme/)).

### Co się stanie z tłem, jeśli później zmienię motyw prezentacji?

Jeśli slajd ma własne wypełnienie, pozostanie ono niezmienione. Jeśli tło jest dziedziczone z [układ](/slides/pl/net/slide-layout/)/[nadrzędny](/slides/pl/net/slide-master/), zostanie zaktualizowane, aby pasowało do [nowego motywu](/slides/pl/net/presentation-theme/).