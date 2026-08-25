---
title: Zarządzaj efektami transformacji obrazu w prezentacjach przy użyciu .NET
linktitle: Efekty transformacji obrazu
type: docs
weight: 11
url: /pl/net/image-transform-effects/
keywords:
- transformacja obrazu
- efekt obrazu
- jasność
- kontrast
- odcień szarości
- duoton
- tonowanie
- HSL
- zamiana koloru
- rozmycie
- przezroczystość
- efekt alfa
- łańcuch efektów
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zastosuj, łącz, sprawdź, usuń i zweryfikuj efekty transformacji obrazu dla ramek obrazu przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Aspose.Slides reprezentuje korekty obrazu jako uporządkowaną kolekcję operacji transformacji obrazu. Dla ramki obrazu rozpocznij od [ISlidesPicture](https://reference.aspose.com/slides/pl/net/aspose.slides/islidespicture/) ramki i uzyskaj dostęp do [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/pl/net/aspose.slides/islidespicture/imagetransform/). Zwrócona [IImageTransformOperationCollection](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/) pozwala dodawać, wyliczać, sprawdzać, usuwać i wyczyścić efekty bez przepisywania oryginalnych bajtów obrazu.

Ten artykuł demonstruje kompletny przepływ pracy dla jasności i kontrastu, transformacji kolorów, rozmycia, przezroczystości, uporządkowanych łańcuchów efektów, wartości efektywnych, usuwania oraz weryfikacji obrotu PPTX.

## **Zrozum własność efektów i ponowne użycie obrazu**

Zasób obrazu i obraz wyświetlający go to różne obiekty:

- [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) przechowuje lub odwołuje się do danych źródłowego obrazu będących własnością prezentacji.
- [ISlidesPicture](https://reference.aspose.com/slides/pl/net/aspose.slides/islidespicture/) należy do wypełnienia obrazu i odwołuje się do zasobu obrazu, jednocześnie przechowując kolekcję transformacji obrazu.
- [IPictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframe/) jest kształtem slajdu, który posiada odpowiednie wypełnienie obrazu, geometrię, ustawienia przycięcia i inne formatowanie na poziomie ramki.

W związku z tym operacje transformacji obrazu nie modyfikują bajtów w [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/). Gdy ten sam `IPPImage` zostanie przekazany do [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addpictureframe/) więcej niż raz, każda nowa ramka obrazu otrzymuje własny `ISlidesPicture` i własną kolekcję transformacji. Zastosowanie odcieni szarości do jednej ramki nie powoduje, że pozostałe ramki również będą w odcieniach szarości, mimo że wszystkie używają tego samego osadzonego zasobu obrazu.

Ten sam model `ISlidesPicture.ImageTransform` jest również używany przez inne wypełnienia obrazu, takie jak kształt lub tło slajdu. Poniższe przykłady koncentrują się na ramkach obrazu.

## **Używaj prawidłowych zakresów parametrów i jednostek**

Prezentowane metody używają następujących semantycznych zakresów i jednostek. Trzymaj się tych zakresów, nawet jeśli dana wersja biblioteki nie odrzuca od razu każdego wartości spoza zakresu; docelowy format prezentacji może znormalizować, pominąć lub odrzucić nieprawidłowe dane podczas zapisu lub gdy PowerPoint otworzy plik.

| Operacja | Parametry | Prawidłowy zakres i jednostka |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` do `100`, procent; `0` pozostawia komponent niezmienionym. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Brak | Brak parametrów numerycznych. Alfa pozostaje niezmieniona. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Dwa kolory dla ciemnych i jasnych pikseli. Kanały RGB i alfa w `System.Drawing.Color` używają wartości od `0` do `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Barwa (`hue`) od `0` (włącznie) do `360` (wyłącznie) stopni; wartość (`amount`) od `-100` do `100` procent. |
| [AddHSLEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Barwa od `0` (włącznie) do `360` (wyłącznie) stopni; nasycenie i luminancja od `-100` do `100` procent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Kolor zastępczy używa wartości kanałów od `0` do `255`. Istniejące wartości alfa pozostają niezmienione. |
| [AddBlurEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Promień jest nieujemny i mierzony w punktach; `grow` jest wartością boolowską określającą, czy rozmyta zawartość może wykraczać poza pierwotne granice. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nieujemny procent. Użyj `0` do `100` dla typowego skalowania nieprzezroczystości: `0` oznacza pełną przezroczystość, a `100` zachowuje istniejącą alfę. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` do `100`, procent nieprzezroczystości. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` do `100`, procentowy próg alfa. Wartości poniżej progu stają się przezroczyste; wartości równe lub powyżej progu stają się nieprzezroczyste. |

Dla stałej modulacji alfa przezroczystość i nieprzezroczystość są komplementarne. Na przykład 35 % przezroczystości odpowiada wartości modulacji alfa 65 %.

## **Zastosuj jasność i kontrast**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) zwraca operację [IBrightnessContrast](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/ibrightnesscontrast/). Jej skalarny zestaw ustawień jest podawany w momencie tworzenia operacji. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/brightnesscontrast/geteffective/) zwraca obliczone wartości tylko do odczytu, które można sprawdzić lub zalogować.

Poniższy przykład zwiększa jasność o 15 % i kontrast o 20 %, a następnie renderuje podgląd bez modyfikacji osadzonego obrazu:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
IBrightnessContrast brightnessContrast = imageTransform.AddBrightnessContrastEffect(15f, 20f);

var effectiveValues = brightnessContrast.GetEffective();
Console.WriteLine("Brightness: " + effectiveValues.Brightness + "%");
Console.WriteLine("Contrast: " + effectiveValues.Contrast + "%");

using var preview = slide.GetImage();
preview.Save("brightness-contrast-preview.png", ImageFormat.Png);
```

[BrightnessContrast](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/brightnesscontrast/) jest rozszerzeniem efektu obrazu Office 2010 i jest mniej przenośny niż standardowy efekt luminancji DrawingML. Gdy jasność i kontrast muszą pozostać edytowalne po obiegu PPTX, użyj [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) i zweryfikuj wynik po ponownym otwarciu pliku. Sekcja ograniczeń formatu wyjaśnia tę różnicę bardziej szczegółowo.

## **Zastosuj transformacje kolorów**

Efekty kolorystyczne mogą być stosowane niezależnie do różnych ramek obrazu, które używają jednego zasobu obrazu. Poniższy przykład tworzy pięć ramek i stosuje odcienie szarości, duotone, odcień, regulację HSL oraz zamianę koloru.

[IDuotone](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iduotone/) zawiera dwa niezależnie edytowalne parametry koloru: `Color1` mapuje ciemne piksele, natomiast `Color2` mapuje jasne piksele. To sprawia, że jest to przydatny przykład efektu, którego ustawienia są bardziej złożone niż pojedyncza wartość skalarna.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var grayFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
grayFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

var duotoneFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
var duotone = duotoneFrame.PictureFormat.Picture.ImageTransform.AddDuotoneEffect();
duotone.Color1.Color = Color.Navy;
duotone.Color2.Color = Color.Gold;

var tintFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
tintFrame.PictureFormat.Picture.ImageTransform.AddTintEffect(210f, 35f);

var hslFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
hslFrame.PictureFormat.Picture.ImageTransform.AddHSLEffect(30f, 20f, -10f);

var replacementFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
var colorReplacement = replacementFrame.PictureFormat.Picture.ImageTransform.AddColorReplaceEffect();
colorReplacement.Color.Color = Color.CornflowerBlue;

presentation.Save("color-transformations.pptx", SaveFormat.Pptx);
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) zastępuje każdy piksel stałym kolorem, zachowując alfa. Różni się od [AddColorChangeEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), który mapuje jeden kolor źródłowy na inny i eksponuje oba formaty koloru źródłowego i docelowego.

## **Dodaj rozmycie, przezroczystość i efekty alfa**

[AddBlurEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) wpływa na wszystkie kanały kolorów, w tym alfa. Ustaw `grow` na `true`, gdy rozmyta krawędź może wykraczać poza pierwotne granice obrazu.

Dla jednolitej przezroczystości użyj [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Mnoży on każdą istniejącą wartość alfa, więc częściowo przezroczyste piksele pozostają proporcjonalnie różne. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) zamiast tego przypisuje jedną wartość alfa wszystkim pikselom. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) konwertuje alfa na dwa poziomy na podstawie progu.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var blurredFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
var blur = blurredFrame.PictureFormat.Picture.ImageTransform.AddBlurEffect(4.5, true);
blur.Radius = 5;

var transparentFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
var alphaModulate = transparentFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(65f);
alphaModulate.Amount = 60f;

var uniformAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
uniformAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaReplaceEffect(55f);

var binaryAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
var alphaBiLevel = binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaBiLevelEffect(50f);
alphaBiLevel.Threshold = 45f;
binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

presentation.Save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
```

Inne operacje alfa bez parametrów obejmują [AddAlphaCeilingEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), który sprawia, że każdy niezerowy alfa staje się w pełni nieprzezroczysty; [AddAlphaFloorEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), który powoduje, że każdy alfa poniżej 100 % staje się w pełni przezroczysty; oraz [AddAlphaInverseEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), który zmienia alfa na `100% - alpha`.

## **Zbuduj uporządkowany łańcuch efektów**

Każda metoda `Add...Effect` dopisuje nową operację na koniec kolekcji. Renderujący używa kolekcji jako uporządkowanego potoku: wyjście operacji 0 staje się wejściem operacji 1 i tak dalej. W konsekwencji te same operacje w innym porządku mogą dawać inny obraz.

Na przykład odcienie szarości, po których następuje odcień, najpierw usuwają informacje chromatyczne, a potem recolorują wynik luminancji. Odcień, po którym następuje odcień szarości, usuwa odcień ponownie. Podobnie zamiana alfa może nadpisać wartości alfa obliczone przez wcześniejsze operacje, podczas gdy modulacja alfa zachowuje ich względne różnice.

Poniższy przykład buduje łańcuch czterech operacji, zapisuje go jako PPTX, ponownie otwiera prezentację, sprawdza zarówno typy operacji, jak i ich kolejność oraz renderuje ponownie otwarty wynik:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
imageTransform.AddGrayScaleEffect();
imageTransform.AddTintEffect(220f, 25f);
imageTransform.AddBlurEffect(2.5, false);
imageTransform.AddAlphaModulateFixedEffect(80f);

presentation.Save("image-transform-chain.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("image-transform-chain.pptx");
var reopenedShape = reopenedPresentation.Slides[0].Shapes[0];

if (reopenedShape is IPictureFrame reopenedFrame)
{
    var reopenedTransform = reopenedFrame.PictureFormat.Picture.ImageTransform;
    var orderIsPreserved = reopenedTransform.Count == 4 && 
            reopenedTransform[0] is IGrayScale && 
            reopenedTransform[1] is ITint && 
            reopenedTransform[2] is IBlur && 
            reopenedTransform[3] is IAlphaModulateFixed;
    Console.WriteLine(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

    using var renderedSlide = reopenedPresentation.Slides[0].GetImage();
    renderedSlide.Save("reopened-effect-chain.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The reopened shape is not a picture frame.");
}
```

Kolekcja nie narzuca matrycy kompatybilności, która ograniczałaby operacje koloru, alfa i rozmycia do osobnych łańcuchów. Mogą być one łączone, ale kombinacje nie zawsze są użyteczne. Stała zamiana koloru usuwa wariację RGB spowodowaną wcześniejszymi efektami kolorów; odcienie szarości po duotone usuwają dwa wybrane kolory; a operacje alfa typu sufit, podłoga, zamiana lub dwupoziomowa mogą odrzucić szczegóły alfa utworzone wcześniej. Buduj łańcuch zgodnie z pożądaną sekwencją przetwarzania pikseli, zamiast traktować jego elementy jako nieuporządkowane flagi formatowania.

## **Sprawdź edytowalne i efektywne wartości**

Edytowalna operacja to obiekt przechowywany w `ISlidesPicture.ImageTransform`. W zależności od efektu może ona bezpośrednio eksponować zapisywalne członki. Na przykład [IBlur](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iblur/) udostępnia zapisywalne `Radius` i `Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/ialphamodulatefixed/) udostępnia zapisywalne `Amount`, a [IAlphaBiLevel](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/ialphabilevel/) udostępnia zapisywalne `Threshold`. Efekty kolorystyczne takie jak [IDuotone](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iduotone/) eksponują mutowalne obiekty [IColorFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/icolorformat/).

Niektóre interfejsy operacji, w tym [IBrightnessContrast](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/itint/) i [IAlphaReplace](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/ialphareplace/), nie eksponują swoich skalarów tworzenia jako zapisywalnych właściwości. Aby zmienić te ustawienia, usuń operację i dodaj zamiennik w wymaganej pozycji.

Dane efektywne zwracane przez `GetEffective()` są wyliczane i tylko do odczytu. Są przydatne przy rozwiązywaniu zależnych od motywu kolorów oraz odczytywaniu znormalizowanych wartości używanych przez renderer, ale nie stanowią kolejnej powierzchni edycji. Poniższy przykład wylicza łańcuch i sprawdza wartości efektywne tam, gdzie odpowiednie API je udostępnia:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        var operation = imageTransform[index];
        Console.WriteLine(index + ": " + operation.GetType().Name);

        switch (operation)
        {
            case IBrightnessContrast brightnessContrast:
                var brightnessContrastData = brightnessContrast.GetEffective();
                Console.WriteLine("  Brightness: " + brightnessContrastData.Brightness);
                Console.WriteLine("  Contrast: " + brightnessContrastData.Contrast);
                break;
            case ILuminance luminance:
                var luminanceData = luminance.GetEffective();
                Console.WriteLine("  Brightness: " + luminanceData.Brightness);
                Console.WriteLine("  Contrast: " + luminanceData.Contrast);
                break;
            case IDuotone duotone:
                var duotoneData = duotone.GetEffective();
                Console.WriteLine("  Dark color: " + duotoneData.Color1);
                Console.WriteLine("  Light color: " + duotoneData.Color2);
                break;
            case IColorReplace colorReplace:
                var colorReplaceData = colorReplace.GetEffective();
                Console.WriteLine("  Replacement color: " + colorReplaceData.Color);
                break;
            case IHSL hsl:
                var hslData = hsl.GetEffective();
                Console.WriteLine("  HSL: " + hslData.Hue + ", " + hslData.Saturation + ", " + hslData.Luminance);
                break;
            case ITint tint:
                var tintData = tint.GetEffective();
                Console.WriteLine("  Tint: " + tintData.Hue + ", " + tintData.Amount);
                break;
            case IBlur blur:
                var blurData = blur.GetEffective();
                Console.WriteLine("  Blur radius: " + blurData.Radius + " pt");
                break;
            case IAlphaModulateFixed alphaModulate:
                var alphaData = alphaModulate.GetEffective();
                Console.WriteLine("  Alpha amount: " + alphaData.Amount + "%");
                break;
            case IAlphaReplace alphaReplace:
                var alphaReplaceData = alphaReplace.GetEffective();
                Console.WriteLine("  Replacement alpha: " + alphaReplaceData.Alpha + "%");
                break;
            case IAlphaBiLevel alphaBiLevel:
                var alphaBiLevelData = alphaBiLevel.GetEffective();
                Console.WriteLine("  Alpha threshold: " + alphaBiLevelData.Threshold + "%");
                break;
        }
    }
}
```

Efekty bez parametrów, takie jak odcienie szarości, sufit alfa i odwrócenie alfa, mają nadal obiekt danych efektywnych, ale nie mają skalarnych ustawień do wydrukowania. Ich obecność i pozycja w kolekcji są istotnymi informacjami.

## **Usuń lub wyczyść transformacje obrazu**

Użyj [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) aby usunąć jedną operację według indeksu. Ponieważ indeksy zmieniają się po usunięciu, najpierw znajdź docelową pozycję, a następnie usuń ją po wyliczeniu. Użyj `Clear()` aby usunąć cały łańcuch.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    var blurIndex = -1;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        if (imageTransform[index] is IBlur)
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform.RemoveAt(blurIndex);
        Console.WriteLine("The blur operation was removed.");
    }

    imageTransform.Clear();
    Console.WriteLine("Remaining operations: " + imageTransform.Count);
    presentation.Save("image-transforms-cleared.pptx", SaveFormat.Pptx);
}
```

Usuwanie lub czyszczenie transformacji zmienia tylko formatowanie obrazu. Nie usuwa, nie rekompresuje ani nie modyfikuje ponownie używanego zasobu [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/).

## **Rozważ formaty prezentacji i cele eksportu**

Transformacje obrazu pochodzą z DrawingML, dlatego PPTX jest preferowanym edytowalnym formatem dla łańcuchów efektów. Nawet przy PPTX nie każda operacja ma identyczną przenośność:

- Standardowe operacje DrawingML, takie jak luminancja, odcienie szarości, duotone, odcień, HSL, rozmycie i typowe operacje alfa, mają największe szanse przetrwania obiegu PPTX. Zawsze ponownie otwieraj wygenerowany plik i sprawdzaj kolekcję, gdy zachowanie jest wymogiem.
- [BrightnessContrast](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/brightnesscontrast/) jest rozszerzeniem Office 2010, a nie standardową operacją luminancji DrawingML. Może być używany do renderowania w pamięci, ale nie jest gwarantowane, że pozostanie edytowalnym [IBrightnessContrast](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/ibrightnesscontrast/) po zapisaniu i ponownym otwarciu PPTX. Preferuj [AddLuminanceEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) dla trwałych korekt jasności i kontrastu.
- Format binarny PPT istnieje przed pełnym modelem efektów DrawingML. Zapis do PPT może pominąć nieobsługiwane operacje, zredukować łańcuch do obsługiwanego podzbioru lub przybliżyć wygląd. Nie używaj PPT jako formatu weryfikacji dla złożonego edytowalnego łańcucha.
- Renderowanie do PNG, JPEG, TIFF, PDF, SVG, HTML lub innych formatów wizualnych stosuje obsługiwany łańcuch do renderowanego obrazu. Te wyjścia nie zawierają edytowalnego `IImageTransformOperationCollection`; formaty rastrowe spłaszczają wynik do pikseli, a eksporty dokumentów/wektorów przechowują własną reprezentację renderowania.
- Efekty nie sprawiają, że podłączony obraz staje się samodzielny. Renderowanie podłączonego obrazu nadal zależy od dostępności podłączonego zasobu w momencie ładowania prezentacji.

Różni konsumenci prezentacji mogą renderować przypadki brzegowe inaczej, szczególnie gdy połączone są liczne operacje alfa lub kwantyzacji kolorów. Dla krytycznych wyników przetestuj zarówno edytowalny obieg, jak i ostateczny format eksportu przy użyciu tej samej wersji Aspose.Slides, którą stosujesz w produkcji.

## **FAQ**

**Czy efekty transformacji obrazu modyfikują osadzone dane obrazu?**

Nie. Operacje należą do `ISlidesPicture` używanego przez wypełnienie obrazu. Bajty podstawowego `IPPImage` pozostają niezmienione.

**Czy dwie ramki obrazu, które używają tego samego obrazu, będą współdzielić swoje efekty?**

Nie. Ponowne użycie `IPPImage` eliminuje duplikację danych obrazu, ale każda ramka obrazu zazwyczaj ma oddzielny `ISlidesPicture` i własną kolekcję transformacji obrazu.

**Czy efekty koloru, rozmycia i alfa mogą być łączone?**

Tak. Kolekcja przyjmuje je w jednym uporządkowanym łańcuchu. Rozważ, co każda operacja robi z wynikiem poprzedniej, ponieważ operacje zamiany i progowe mogą odrzucać wcześniejsze szczegóły koloru lub alfa.

**Dlaczego wartości efektywne są tylko do odczytu?**

Dane efektywne reprezentują wyliczone wartości używane do renderowania, w tym rozwiązane kolory. Edytuj operację przechowywaną w kolekcji transformacji, gdzie istnieją zapisywalne członki; w przeciwnym razie usuń ją i dodaj zamiennik z nowymi parametrami tworzenia.

**Jaki format powinienem użyć, aby zachować łańcuch transformacji?**

Używaj PPTX i zweryfikuj plik, otwierając go ponownie. Starszy format PPT nie może przedstawić pełnego modelu efektów DrawingML, a formaty eksportu renderującego zachowują jedynie wygląd, a nie edytowalne operacje transformacji.