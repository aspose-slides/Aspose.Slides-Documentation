---
title: Zarządzanie tłem prezentacji w .NET
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
description: "Dowiedz się, jak ustawić dynamiczne tła w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET, z wskazówkami kodu, które podniosą jakość twoich prezentacji."
---
## **Wprowadzenie**

Jednolite kolory, gradienty i obrazy są powszechnie używane jako tła slajdów. Możesz ustawić tło dla **normalnego slajdu** (pojedynczego slajdu) lub **slajdu wzorcowego** (obowiązuje dla wielu slajdów jednocześnie).

![PowerPoint background](powerpoint-background.png)

## **Ustaw jednolite tło koloru dla normalnego slajdu**

Aspose.Slides pozwala ustawić jednolity kolor jako tło konkretnego slajdu w prezentacji — nawet jeśli prezentacja używa slajdu wzorcowego. Zmiana dotyczy tylko wybranego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/net/aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/net/aspose.slides/filltype/) tła slajdu na `Solid`.
4. Użyj właściwości [SolidFillColor](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/solidfillcolor/) w [FillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/), aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w C# pokazuje, jak ustawić niebieski jednolity kolor jako tło normalnego slajdu:

```cs
// Utwórz instancję klasy Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ustaw kolor tła slajdu na niebieski.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Zapisz prezentację na dysk.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **Ustaw jednolite tło koloru dla slajdu wzorcowego**

Aspose.Slides pozwala ustawić jednolity kolor jako tło slajdu wzorcowego w prezentacji. Slajd wzorcowy działa jako szablon kontrolujący formatowanie wszystkich slajdów, więc gdy wybierzesz jednolity kolor tła slajdu wzorcowego, zostanie on zastosowany do każdego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/net/aspose.slides/backgroundtype/) slajdu wzorcowego (przez `masters`) na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/net/aspose.slides/filltype/) tła slajdu wzorcowego na `Solid`.
4. Użyj [SolidFillColor](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/solidfillcolor/) do określenia jednolitego koloru tła.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w C# pokazuje, jak ustawić jednolity kolor (zieleń lasu) jako tło slajdu wzorcowego:

```cs
// Utwórz instancję klasy Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Ustaw kolor tła slajdu Master na Zielony leśny.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Zapisz prezentację na dysk.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Ustaw gradientowe tło dla slajdu**

Gradient to efekt graficzny uzyskany poprzez płynne przejście kolorów. Używany jako tło slajdu, gradient może sprawić, że prezentacje wyglądają bardziej artystycznie i profesjonalnie. Aspose.Slides pozwala ustawić gradientowy kolor jako tło slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/net/aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/net/aspose.slides/filltype/) tła slajdu na `Gradient`.
4. Użyj właściwości [GradientFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/gradientformat/) w [FillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/), aby skonfigurować preferowane ustawienia gradientu.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w C# pokazuje, jak ustawić gradientowy kolor jako tło slajdu:

```cs
// Utwórz instancję klasy Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Zastosuj efekt gradientu do tła.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Zapisz prezentację na dysk.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **Ustaw obraz jako tło slajdu**

Oprócz wypełnień jednolitych i gradientowych, Aspose.Slides pozwala używać obrazów jako tła slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/net/aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/net/aspose.slides/filltype/) tła slajdu na `Picture`.
4. Załaduj obraz, którego chcesz użyć jako tło slajdu.
5. Dodaj obraz do kolekcji obrazów prezentacji.
6. Użyj właściwości [PictureFillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/picturefillformat/) w [FillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/fillformat/), aby przypisać obraz jako tło.
7. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w C# pokazuje, jak ustawić obraz jako tło slajdu:

```c#
// Utwórz instancję klasy Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ustaw właściwości obrazu tła.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Załaduj obraz.
    IImage image = Images.FromFile("Tulips.jpg");
    // Dodaj obraz do kolekcji obrazów prezentacji.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Zapisz prezentację na dysk.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

Poniższy przykład kodu pokazuje, jak ustawić typ wypełnienia tła na obraz kafelkowany i zmodyfikować właściwości tilingu:

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

    // Ustaw obraz używany do wypełnienia tła.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Ustaw tryb wypełnienia obrazu na Tile i dostosuj właściwości kafelków.
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
Zobacz więcej: [**Tile Picture As Texture**](/slides/pl/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Zmień przezroczystość obrazu tła**

Możesz chcieć dostosować przezroczystość obrazu tła slajdu, aby podkreślić zawartość slajdu. Poniższy kod w C# pokazuje, jak zmienić przezroczystość obrazu tła slajdu:

```cs
var transparencyValue = 30; // Na przykład.

// Pobierz kolekcję operacji transformacji obrazu.
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Znajdź istniejący efekt przezroczystości o stałym procencie.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Ustaw nową wartość przezroczystości.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```

## **Pobierz wartość tła slajdu**

Aspose.Slides udostępnia interfejs [IBackgroundEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ibackgroundeffectivedata/) do pobierania efektywnych wartości tła slajdu. Interfejs ten eksponuje skuteczne [FillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ibackgroundeffectivedata/fillformat/) i [EffectFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ibackgroundeffectivedata/effectformat/).

Korzystając z właściwości `background` klasy [BaseSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/baseslide/), możesz uzyskać efektywne tło slajdu.

Poniższy przykład w C# pokazuje, jak pobrać efektywną wartość tła slajdu:

```cs
// Utwórz instancję klasy Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Pobierz efektywne tło, uwzględniając master, layout i temat.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **FAQ**

**Czy mogę zresetować niestandardowe tło i przywrócić tło tematu/układu?**

Tak. Usuń niestandardowe wypełnienie slajdu, a tło zostanie ponownie odziedziczone z odpowiedniego slajdu [layout](/slides/pl/net/slide-layout/)/[master](/slides/pl/net/slide-master/) (czyli z [tła tematu](/slides/pl/net/presentation-theme/)).

**Co się stanie z tłem, jeśli później zmienię temat prezentacji?**

Jeśli slajd ma własne wypełnienie, pozostanie ono niezmienione. Jeśli tło jest dziedziczone z [layout](/slides/pl/net/slide-layout/)/[master](/slides/pl/net/slide-master/), zostanie zaktualizowane, aby pasować do [nowego tematu](/slides/pl/net/presentation-theme/).