---
title: Zarządzanie efektami transformacji obrazu w prezentacjach w .NET
linktitle: Efekty Transformacji Obrazu
type: docs
weight: 11
url: /pl/net/image-transform-effects/
keywords:
- transformacja obrazu
- efekt obrazu
- jasność
- kontrast
- skala szarości
- duoton
- odcień
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
description: "Zastosuj, łącz, przeglądaj, usuwaj i weryfikuj efekty transformacji obrazu dla ramek obrazów przy użyciu Aspose.Slides for .NET."
---
## **Przegląd**

Aspose.Slides reprezentuje korekty obrazu jako uporządkowaną kolekcję operacji transformacji obrazu. Dla ramki obrazu rozpocznij od [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) ramki i uzyskaj dostęp do [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/imagetransform/). Zwrócona [IImageTransformOperationCollection](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/) umożliwia dołączanie, wyliczanie, przeglądanie, usuwanie i czyszczenie efektów bez przepisania pierwotnych bajtów obrazu.

Ten artykuł demonstruje kompletny przepływ pracy dla jasności i kontrastu, transformacji kolorów, rozmycia, przezroczystości, uporządkowanych łańcuchów efektów, wartości efektywnych, usuwania oraz weryfikacji pełnego cyklu PPTX.

## **Zrozum własność efektów i ponowne wykorzystanie obrazu**

- [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) przechowuje lub odwołuje się do danych źródłowego obrazu będących własnością prezentacji.
- [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) należy do wypełnienia obrazu i odnosi się do zasobu obrazu, jednocześnie przechowując kolekcję transformacji obrazu.
- [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) jest kształtem slajdu, który posiada odpowiednie wypełnienie obrazu, geometrię, ustawienia przycięcia i inne formatowanie na poziomie ramki.

Dlatego operacje transformacji obrazu nie modyfikują bajtów w [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/). Gdy ten sam `IPPImage` zostanie przekazany do [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) więcej niż raz, każda nowa ramka obrazu otrzymuje własny `ISlidesPicture` i własną kolekcję transformacji. Zastosowanie skali szarości do jednej ramki nie powoduje, że pozostałe ramki również stają się odcieniami szarości, mimo że wszystkie ponownie używają tego samego osadzonego zasobu obrazu.

Ten sam model `ISlidesPicture.ImageTransform` jest również używany przez inne wypełnienia obrazu, takie jak kształt lub tło slajdu. Poniższe przykłady koncentrują się na ramach obrazu.

## **Używaj prawidłowych zakresów parametrów i jednostek**

Demonstracyjne metody używają następujących semantycznych zakresów i jednostek. Trzymaj się tych zakresów, nawet jeśli konkretna wersja biblioteki nie odrzuca od razu każdej wartości poza zakresem; docelowy format prezentacji może normalizować, pomijać lub odrzucać nieprawidłowe dane podczas zapisu lub otwierania pliku w PowerPoint.

| Operacja | Parametry | Prawidłowy zakres i jednostka |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` do `100`, procent; `0` pozostawia komponent niezmieniony. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Brak | Brak parametrów liczbowych. Alfa pozostaje niezmieniona. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Dwa kolory dla ciemnych i jasnych pikseli. Kanały RGB i alfa w `System.Drawing.Color` używają wartości od `0` do `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Odcień (`hue`) wynosi od `0` (włącznie) do `360` (wyłącznie) stopni; wartość (`amount`) od `-100` do `100` procent. |
| [AddHSLEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Odcień (`hue`) od `0` (włącznie) do `360` (wyłącznie) stopni; nasycenie i luminancja od `-100` do `100` procent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Zastępujący kolor używa wartości kanałów od `0` do `255`. Istniejące wartości alfa pozostają niezmienione. |
| [AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Promień jest nieujemny i mierzony w punktach; `grow` jest wartością logiczną określającą, czy rozmyta treść może wykraczać poza oryginalne granice. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nieujemny procent. Użyj `0` do `100` do zwykłego skalowania przezroczystości: `0` to całkowicie przezroczyste, a `100` zachowuje istniejącą alfę. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` do `100`, procent przezroczystości. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` do `100`, procentowy próg alfa. Wartości poniżej progu stają się przezroczyste; wartości równe lub powyżej progu stają się nieprzezroczyste. |

Dla stałej modulacji alfa, przezroczystość i nieprzezroczystość są komplementarne. Na przykład 35% przezroczystości odpowiada modulacji alfa wynoszącej 65%.

## **Zastosuj jasność i kontrast**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) zwraca operację [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/). Jej ustawienia skalarne są podawane w momencie tworzenia operacji. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/geteffective/) zwraca obliczone wartości tylko do odczytu, które można przeglądać lub logować.

Poniższy przykład zwiększa jasność o 15% i kontrast o 20%, a następnie renderuje podgląd bez modyfikacji osadzonego obrazu:

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

[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) jest rozszerzeniem efektu obrazu Office 2010 i jest mniej przenośny niż standardowy efekt luminancji DrawingML. Gdy jasność i kontrast muszą pozostać edytowalne po pełnym cyklu PPTX, użyj [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) i zweryfikuj wynik po ponownym otwarciu pliku. Sekcja ograniczeń formatu wyjaśnia tę różnicę bardziej szczegółowo.

## **Zastosuj transformacje kolorów**

Efekty kolorystyczne mogą być stosowane niezależnie do różnych ramek obrazu, które ponownie używają jednego zasobu obrazu. Poniższy przykład tworzy pięć ramek i stosuje skalę szarości, duoton, odcień, regulację HSL oraz zamianę koloru.

[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) zawiera dwa niezależnie edytowalne parametry koloru: `Color1` mapuje ciemne piksele, natomiast `Color2` mapuje jasne piksele. Jest to przydatny przykład efektu, którego ustawienia są bardziej złożone niż pojedyncza wartość skalarna.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) zamienia każdy piksel na jeden stały kolor, zachowując alfa. Jest to inne niż [AddColorChangeEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), który mapuje jeden kolor źródłowy na inny i udostępnia oba formaty koloru źródłowego i docelowego.

### **Zastosuj próg luminancji**

Próg luminancji może ułatwić rozróżnienie słabych znaków na zeskanowanej stronie od tła. [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) zachowuje pośrednie odcienie szarości. [AddBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) mapuje luminancję na czarny lub biały, podczas gdy [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) stosuje próg do przezroczystości.

Próg luminancji mieści się w przedziale od 0% do 100%, włącznie. Piksele poniżej progu stają się czarne. Piksele równe lub powyżej progu stają się białe. Podniesienie progu przekształca więcej odcieni w czarne, ponieważ więcej z nich spada poniżej granicy.

Pobierz [grayscale-swatches.png](grayscale-swatches.png) do katalogu roboczego. Każda etykieta podaje pierwotny poziom szarości w skali od 0 do 255. Przykład umieszcza oryginał obok dwóch kopii i zapisuje próg każdej kopii w prezentacji.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 150, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var imageData = File.ReadAllBytes("grayscale-swatches.png");
var image = presentation.Images.AddImage(imageData);

IPictureFrame AddFrame(float x, string caption)
{
    shapes.AddAutoShape(ShapeType.Rectangle, x, 12, 216, 36).TextFrame.Text = caption;
    return shapes.AddPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
}

AddFrame(12, "Original");

var lowThreshold = AddFrame(252, "Threshold 20%");
lowThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(20f);

var highThreshold = AddFrame(492, "Threshold 60%");
highThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(60f);

presentation.Save("luminance-threshold.pptx", SaveFormat.Pptx);
```

Otwórz wynikową prezentację w PowerPoint, aby porównać trzy ramki. Próbka oznaczona jako 96 ma około 38% luminancji (96 z 255). Staje się biała przy progu 20% i czarna przy progu 60%.

![Oryginalne próbki w skali szarości obok wyników czarno-białych przy progach luminancji 20% i 60%](luminance-threshold.png)

## **Dodaj rozmycie, przezroczystość i efekty alfa**

[AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) wpływa na wszystkie kanały kolorów, w tym alfa. Ustaw `grow` na `true`, gdy rozmyta krawędź może wykraczać poza oryginalne granice obrazu.

Aby uzyskać jednolitą przezroczystość, użyj [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Mnoży on każdą istniejącą wartość alfa, więc częściowo przezroczyste piksele pozostają proporcjonalnie różne. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) zamiast tego przypisuje jedną wartość alfa wszystkim pikselom. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) konwertuje alfę na dwa poziomy na podstawie progu.

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

Inne operacje alfa bez parametrów to m.in. [AddAlphaCeilingEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), który sprawia, że każda niezerowa alfa staje się w pełni nieprzezroczysta; [AddAlphaFloorEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), który sprawia, że każda alfa poniżej 100% staje się w pełni przezroczysta; oraz [AddAlphaInverseEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), który zmienia alfę na `100% - alpha`.

## **Zbuduj uporządkowany łańcuch efektów**

Każda metoda `Add...Effect` dołącza nową operację na koniec kolekcji. Renderer używa kolekcji jako uporządkowanego potoku: wyjście operacji 0 staje się wejściem operacji 1 i tak dalej. W konsekwencji te same operacje w innej kolejności mogą dawać inny obraz.

Na przykład skala szarości, a następnie odcień najpierw usuwa informacje chromatyczne, a potem recoloruje wynik luminancji. Odcień, a potem skala szarości usuwa odcień ponownie. Podobnie zamiana alfa może nadpisać wartości alfa obliczone przez wcześniejsze operacje, podczas gdy modulacja alfa zachowuje ich względne różnice.

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

Kolekcja nie narzuca macierzy kompatybilności, która ogranicza operacje koloru, alfa i rozmycia do oddzielnych łańcuchów. Mogą być łączone, ale nie zawsze są użyteczne. Stała zamiana koloru usuwa wariację RGB wygenerowaną przez wcześniejsze efekty koloru; skala szarości po duotonie usuwa dwa wybrane kolory; a operacje alfa typu ceiling, floor, replacement lub bi-level mogą odrzucić szczegóły alfa stworzone wcześniej. Buduj łańcuch zgodnie z pożądaną kolejnością przetwarzania pikseli, a nie traktuj jego elementów jako nieuporządkowane flagi formatowania.

<!-- visual-explanation:image-transform-effects:start -->
[![Ten sam obraz przechodzi najpierw przez skalę szarości, potem odcień, oraz odcień, potem skalę szarości. Dwa końcowe obrazy w skali szarości mają różne tony.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)
*W tej ilustracyjnej wizualizacji Aspose.Slides for .NET 26.11, odcień 220° przy 25% pozostawia obraz w skali szarości niezmieniony. Zastosowanie tego samego odcienia przed skalą szarości daje inne tony.*
<!-- visual-explanation:image-transform-effects:end -->

## **Sprawdź edytowalne i efektywne wartości**

Edytowalna operacja to obiekt przechowywany w `ISlidesPicture.ImageTransform`. W zależności od efektu może bezpośrednio udostępniać zapisywalne członki. Na przykład [IBlur](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/) udostępnia zapisywalne `Radius` i `Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphamodulatefixed/) udostępnia zapisywalne `Amount`, a [IAlphaBiLevel](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphabilevel/) udostępnia zapisywalny `Threshold`. Efekty kolorystyczne takie jak [IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) udostępniają zmienne obiekty [IColorFormat](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/).

Niektóre interfejsy operacji, w tym [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/net/aspose.slides.effects/itint/) i [IAlphaReplace](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphareplace/), nie udostępniają swoich skalarów tworzenia jako zapisywalnych właściwości. Aby zmienić te ustawienia, usuń operację i dodaj zamiennik w wymaganej pozycji.

Dane efektywne zwracane przez `GetEffective()` są obliczone i tylko do odczytu. Są przydatne do rozwiązywania kolorów zależnych od motywu i odczytywania znormalizowanych wartości używanych przez renderer, ale nie stanowią dodatkowej powierzchni edycyjnej. Poniższy przykład wylicza łańcuch i sprawdza efektywne wartości tam, gdzie odpowiednie API je udostępnia:

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

Efekty bez parametrów, takie jak skala szarości, alfa ceiling i alfa inverse, nadal mają obiekt danych efektywnych, ale nie mają skalarów do wydrukowania. Ich obecność i pozycja w kolekcji są ważną informacją.

## **Usuń lub wyczyść transformacje obrazu**

Użyj [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) aby usunąć jedną operację według indeksu. Ponieważ indeksy zmieniają się po usunięciu, najpierw znajdź docelowy element, a potem usuń go po wyliczeniu. Użyj `Clear()` aby usunąć cały łańcuch.

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

Usuwanie lub czyszczenie transformacji zmienia tylko formatowanie obrazu. Nie usuwa, nie kompresuje ani nie modyfikuje ponownie używanego zasobu [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/).

## **Rozważ formaty prezentacji i cele eksportu**

Transformacje obrazu pochodzą z DrawingML, dlatego PPTX jest preferowanym formatem edytowalnym dla łańcuchów efektów. Nawet przy PPTX nie każda operacja ma identyczną przenośność:

- Standardowe operacje DrawingML, takie jak luminancja, skala szarości, duoton, odcień, HSL, rozmycie i typowe operacje alfa, mają największe szanse przetrwania pełnego cyklu PPTX. Zawsze ponownie otwieraj wygenerowany plik i sprawdzaj kolekcję, gdy zachowanie jest wymogiem.
- [BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) jest rozszerzeniem Office 2010, a nie standardową operacją luminancji DrawingML. Może być używany do renderowania w pamięci, ale nie ma gwarancji, że po zapisaniu i ponownym otwarciu PPTX pozostanie edytowalnym [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/). Lepiej używać [AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) dla trwałych korekt jasności i kontrastu.
- Binarny format PPT istnieje przed pełnym modelem efektów DrawingML. Zapis do PPT może pominąć nieobsługiwane operacje, zredukować łańcuch do obsługiwanego podzbioru lub przybliżyć wygląd. Nie używaj PPT jako formatu weryfikacji dla złożonego edytowalnego łańcucha.
- Renderowanie do PNG, JPEG, TIFF, PDF, SVG, HTML lub innych formatów wizualnych stosuje obsługiwany łańcuch do renderowanego wyglądu. Te wyjścia nie zawierają edytowalnego `IImageTransformOperationCollection`; formaty rastrowe spłaszczają wynik do pikseli, a eksporty dokumentów/wektorów przechowują własną reprezentację renderowania.
- Efekty nie powodują, że połączony obraz staje się samodzielny. Renderowanie połączonego obrazu nadal zależy od dostępności połączonego zasobu w momencie ładowania prezentacji.

Różni konsumenci prezentacji mogą renderować przypadki brzegowe inaczej, szczególnie gdy połączone są wielokrotne operacje alfa lub kwantyzacji kolorów. Dla krytycznych rezultatów testuj zarówno edytowalny pełny cykl, jak i ostateczny format eksportu przy użyciu tej samej wersji Aspose.Slides używanej w produkcji.

## **FAQ**

**Czy efekty transformacji obrazu modyfikują osadzone dane obrazu?**

Nie. Operacje należą do `ISlidesPicture` używanego przez wypełnienie obrazu. Bajty podstawowego `IPPImage` pozostają niezmienione.

**Czy dwie ramki obrazu, które ponownie używają tego samego obrazu, będą współdzielić swoje efekty?**

Nie. Ponowne użycie `IPPImage` unika duplikacji danych obrazu, ale każda ramka obrazu zwykle ma osobny `ISlidesPicture` i kolekcję transformacji obrazu.

**Czy efekty koloru, rozmycia i alfa mogą być łączone?**

Tak. Kolekcja przyjmuje je w jednym uporządkowanym łańcuchu. Rozważ, co każda operacja robi z wynikiem poprzedniej, ponieważ operacje zamiany i progowe mogą odrzucać wcześniejsze szczegóły koloru lub alfa.

**Dlaczego wartości efektywne są tylko do odczytu?**

Dane efektywne reprezentują obliczone wartości używane do renderowania, w tym rozwiązane kolory. Edytuj operację przechowywaną w kolekcji transformacji, gdzie istnieją zapisywalne członki; w przeciwnym razie usuń ją i dodaj zamiennik z nowymi parametrami tworzenia.

**Jakiego formatu powinienem używać, aby zachować łańcuch transformacji?**

Używaj PPTX i zweryfikuj plik, ponownie go otwierając. Starszy format PPT nie może przedstawić pełnego modelu efektów DrawingML, a formaty eksportu wizualnego zachowują jedynie wygląd, a nie edytowalne operacje transformacji.