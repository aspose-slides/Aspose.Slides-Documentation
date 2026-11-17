---
title: Zarządzaj efektami transformacji obrazu w prezentacjach przy użyciu PHP
linktitle: Efekty transformacji obrazu
type: docs
weight: 11
url: /pl/php-java/image-transform-effects/
keywords:
- transformacja obrazu
- efekt obrazu
- jasność
- kontrast
- odcienie szarości
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
- PHP
- Aspose.Slides
description: "Zastosuj, łącz, sprawdzaj, usuwaj i weryfikuj efekty transformacji obrazu dla ramek obrazu przy użyciu Aspose.Slides dla PHP poprzez Java."
---
## **Przegląd**

Aspose.Slides reprezentuje korekty obrazu jako uporządkowaną kolekcję operacji transformacji obrazu. Dla ramki obrazu rozpocznij od ramki [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) i uzyskaj dostęp do [Picture::getImageTransform](https://reference.aspose.com/slides/php-java/aspose.slides/picture/getimagetransform/). Zwrócona [ImageTransformOperationCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/) umożliwia dodawanie, enumerowanie, inspekcję, usuwanie i czyszczenie efektów bez przepisania oryginalnych bajtów obrazu.

Ten artykuł demonstruje kompletny przepływ pracy dla jasności i kontrastu, transformacji kolorów, rozmycia, przezroczystości, uporządkowanych łańcuchów efektów, wartości efektywnych, usuwania oraz weryfikacji pełnego cyklu PPTX.

## **Zrozumienie własności efektu i ponowne użycie obrazu**

Zasób obrazu i obraz wyświetlający go to różne obiekty:

- [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) przechowuje lub odwołuje się do danych źródłowego obrazu będących własnością prezentacji.
- [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) należy do wypełnienia obrazu i odnosi się do zasobu obrazu, jednocześnie przechowując kolekcję transformacji obrazu.
- [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) jest kształtem slajdu, który posiada odpowiednie wypełnienie obrazu, geometrię, ustawienia przycięcia i inne formatowanie na poziomie ramki.

Dlatego operacje transformacji obrazu nie modyfikują bajtów w [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/). Gdy ten sam `PPImage` zostanie przekazany do [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) więcej niż raz, każda nowa ramka obrazu otrzymuje własny `Picture` i własną kolekcję transformacji. Zastosowanie odcieni szarości do jednej ramki nie powoduje, że pozostałe ramki również będą w odcieniach szarości, mimo że wszystkie używają tego samego wbudowanego zasobu obrazu.

Ten sam model `Picture::getImageTransform` jest również używany przez inne wypełnienia obrazu, takie jak kształt lub tło slajdu. Poniższe przykłady koncentrują się na ramach obrazu.

## **Używaj prawidłowych zakresów parametrów i jednostek**

Demonstrowane metody używają następujących semantycznych zakresów i jednostek. Trzymaj się tych zakresów, nawet jeśli konkretna wersja biblioteki nie odrzuca od razu każdego nieprawidłowego wartości; docelowy format prezentacji może normalizować, pomijać lub odrzucać nieprawidłowe dane podczas zapisu lub otwierania pliku w PowerPoint.

| Operacja | Parametry | Prawidłowy zakres i jednostka |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` przez `100`, procent; `0` pozostawia komponent niezmieniony. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | None | Brak parametrów numerycznych. Alfa pozostaje niezmieniona. |
| [addDuotoneEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Dwa kolory dla ciemnych i jasnych pikseli. Kanały RGB i alfa w `java.awt.Color` używają wartości od `0` do `255`. |
| [addTintEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Odcień (`hue`) od `0` (włącznie) do `360` (wyłącznie) stopni; natężenie (`amount`) od `-100` do `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Odcień od `0` (włącznie) do `360` (wyłącznie) stopni; nasycenie i luminancja od `-100` do `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | Zastępujący kolor używa wartości kanałów od `0` do `255`. Istniejące wartości alfa pozostają niezmienione. |
| [addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Promień jest nieujemny i wyrażany w punktach; `grow` jest wartością logiczną określającą, czy rozmyta zawartość może wyjść poza pierwotne granice. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nieujemny procent. Użyj wartości od `0` do `100` dla zwykłego skalowania nieprzezroczystości: `0` to całkowita przezroczystość, `100` zachowuje istniejącą alfę. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` przez `100`, procent nieprzezroczystości. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` przez `100`, procentowy próg alfa. Wartości poniżej progu stają się przezroczyste; wartości równe lub powyżej progu stają się nieprzezroczyste. |

Dla stałej modulacji alfa, przezroczystość i nieprzezroczystość są komplementarne. Na przykład 35 % przezroczystości odpowiada wartości modulacji alfa 65 %.

## **Zastosuj jasność i kontrast**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) zwraca operację [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/). Jej skalarne ustawienia są podawane podczas tworzenia operacji. [Luminance::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/geteffective/) zwraca obliczone wartości tylko do odczytu, które można sprawdzić lub zalogować.

Poniższy przykład zwiększa jasność o 15 % i kontrast o 20 %, a następnie renderuje podgląd bez modyfikacji wbudowanego obrazu:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $luminance = $imageTransform->addLuminanceEffect(15, 20);

    $effectiveValues = $luminance->getEffective();
    echo "Brightness: " . java_values($effectiveValues->getBrightness()) . "%" . PHP_EOL;
    echo "Contrast: " . java_values($effectiveValues->getContrast()) . "%" . PHP_EOL;

    $preview = $slide->getImage();
    try {
        $preview->save("brightness-contrast-preview.png", ImageFormat::Png);
    } finally {
        if (!java_is_null($preview)) {
            $preview->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

`Luminance` jest standardowym efektem jasności i kontrastu DrawingML. Gdy te ustawienia muszą pozostać edytowalne po pełnym cyklu PPTX, otwórz ponownie zapisany plik prezentacji i zweryfikuj zarówno typ operacji, jak i jej wartości efektywne.

## **Zastosuj transformacje kolorów**

Efekty kolorów mogą być stosowane niezależnie do różnych ramek obrazu, które używają tego samego zasobu obrazu. Poniższy przykład tworzy pięć ramek i stosuje odcienie szarości, duoton, tint, regulację HSL oraz zamianę koloru.

[Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) zawiera dwa niezależnie edytowalne parametry koloru: `color1` mapuje ciemne piksele, a `color2` jasne piksele. To czyni go przydatnym przykładem efektu, którego ustawienia są bardziej złożone niż pojedyncza wartość skalarna.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $grayFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 180, 120, $image);
    $grayFrame->getPictureFormat()->getPicture()->getImageTransform()->addGrayScaleEffect();

    $duotoneFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 180, 120, $image);
    $duotone = $duotoneFrame->getPictureFormat()->getPicture()->getImageTransform()->addDuotoneEffect();
    $duotone->getColor1()->setColor(new Java("java.awt.Color", 0, 0, 128));
    $duotone->getColor2()->setColor(new Java("java.awt.Color", 255, 215, 0));

    $tintFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 420, 20, 180, 120, $image);
    $tintFrame->getPictureFormat()->getPicture()->getImageTransform()->addTintEffect(210, 35);

    $hslFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 120, 170, 180, 120, $image);
    $hslFrame->getPictureFormat()->getPicture()->getImageTransform()->addHSLEffect(30, 20, -10);

    $replacementFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 320, 170, 180, 120, $image);
    $colorReplacement = $replacementFrame->getPictureFormat()->getPicture()->getImageTransform()->addColorReplaceEffect();
    $colorReplacement->getColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $presentation->save("color-transformations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) zamienia każdy piksel na jeden stały kolor, zachowując alfę. Różni się od [addColorChangeEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), które mapuje jeden kolor źródłowy na inny i udostępnia formaty zarówno koloru źródłowego, jak i docelowego.

### **Zastosuj próg luminancji**

Próg luminancji może ułatwić odróżnienie słabych znaków na zeskanowanej stronie od tła. [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) zachowuje pośrednie odcienie szarości. [addBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addbileveleffect/) mapuje luminancję na czarny lub biały, podczas gdy [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) stosuje próg do nieprzezroczystości.

Próg luminancji mieści się w przedziale od 0 % do 100 %, włącznie. Piksele poniżej progu stają się czarne. Piksele równe lub powyżej progu stają się białe. Podniesienie progu powoduje, że więcej odcieni staje się czarnych, ponieważ więcej z nich spada poniżej limitu.

Pobierz [grayscale-swatches.png](grayscale-swatches.png) do katalogu zawierającego skrypt PHP. Każda etykieta podaje oryginalny poziom szarości w skali od 0 do 255. Przykład umieszcza oryginał obok dwóch kopii i zapisuje próg każdej kopii w prezentacji.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 150, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $sourceImage = Images::fromFile(__DIR__ . "/grayscale-swatches.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $captions = ["Original", "Threshold 20%", "Threshold 60%"];
    $frames = [];
    foreach ($captions as $index => $caption) {
        $x = 12 + 240 * $index;
        $label = $shapes->addAutoShape(ShapeType::Rectangle, $x, 12, 216, 36);
        $label->getTextFrame()->setText($caption);
        $frames[] = $shapes->addPictureFrame(ShapeType::Rectangle, $x, 60, 216, 72, $image);
    }

    $frames[1]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(20);
    $frames[2]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(60);

    $presentation->save(__DIR__ . "/luminance-threshold.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Otwórz wynikową prezentację w PowerPoint, aby porównać trzy ramki. Próbka oznaczona 96 ma około 38 % luminancji (96 z 255). Staje się biała przy progu 20 % i czarna przy progu 60 %.

![Oryginalne próbki szarości obok wyników czarno‑białych przy progach luminancji 20 % i 60 %](luminance-threshold.png)

## **Dodaj rozmycie, przezroczystość i efekty alfa**

[addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) wpływa na wszystkie kanały kolorów, w tym alfa. Ustaw `grow` na `true`, gdy rozmyta krawędź może wyjść poza pierwotne granice obrazu.

Aby uzyskać jednolitą przezroczystość, użyj [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Mnoży on każdą istniejącą wartość alfa, więc częściowo przezroczyste piksele zachowują proporcjonalne różnice. [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) natomiast przypisuje jedną wartość alfa wszystkim pikselom. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) konwertuje alfre na dwa poziomy na podstawie progu.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $blurredFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 140, $image);
    $blur = $blurredFrame->getPictureFormat()->getPicture()->getImageTransform()->addBlurEffect(4.5, true);
    $blur->setRadius(5);

    $transparentFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 20, 200, 140, $image);
    $alphaModulate = $transparentFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaModulateFixedEffect(65);
    $alphaModulate->setAmount(60);

    $uniformAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 180, 200, 140, $image);
    $uniformAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaReplaceEffect(55);

    $binaryAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 180, 200, 140, $image);
    $alphaBiLevel = $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaBiLevelEffect(50);
    $alphaBiLevel->setThreshold(45);
    $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaInverseEffect();

    $presentation->save("blur-and-alpha-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Inne operacje alfa nie wymagające parametrów to [addAlphaCeilingEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), które sprawia, że każda niezerowa alfa staje się w pełni nieprzezroczysta; [addAlphaFloorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), które czyni każdą alfę poniżej 100 % całkowicie przezroczystą; oraz [addAlphaInverseEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), które zmienia alfę na `100% - alpha`.

## **Zbuduj uporządkowany łańcuch efektów**

Każda metoda `add...Effect` dopisuje nową operację na koniec kolekcji. Renderer używa kolekcji jako uporządkowanego potoku: wynik operacji 0 staje się wejściem operacji 1 i tak dalej. W konsekwencji te same operacje w innej kolejności mogą dać inny obraz.

Na przykład odcienie szarości, a następnie tint najpierw usuwają informację chromatyczną, a potem recolorują wynik luminancji. Tint przed odcieniami szarości usuwa tint ponownie. Podobnie, zamiana alfa może nadpisać wartości alfa obliczone przez wcześniejsze operacje, podczas gdy modulacja alfa zachowuje ich względne różnice.

Poniższy przykład buduje łańcuch czterech operacji, zapisuje go jako PPTX, ponownie otwiera prezentację, sprawdza zarówno typy operacji, jak i ich kolejność, a następnie renderuje ponownie otwarty wynik:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransform->addGrayScaleEffect();
    $imageTransform->addTintEffect(220, 25);
    $imageTransform->addBlurEffect(2.5, false);
    $imageTransform->addAlphaModulateFixedEffect(80);

    $presentation->save("image-transform-chain.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($reopenedShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $reopenedTransform = $reopenedShape->getPictureFormat()->getPicture()->getImageTransform();
        $orderIsPreserved = java_values($reopenedTransform->size()) === 4 && 
            java_instanceof($reopenedTransform->get_Item(0), new JavaClass("com.aspose.slides.GrayScale")) && 
            java_instanceof($reopenedTransform->get_Item(1), new JavaClass("com.aspose.slides.Tint")) && 
            java_instanceof($reopenedTransform->get_Item(2), new JavaClass("com.aspose.slides.Blur")) && 
            java_instanceof($reopenedTransform->get_Item(3), new JavaClass("com.aspose.slides.AlphaModulateFixed"));
        echo $orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.";

        $renderedSlide = $reopenedPresentation->getSlides()->get_Item(0)->getImage();
        try {
            $renderedSlide->save("reopened-effect-chain.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($renderedSlide)) {
                $renderedSlide->dispose();
            }
        }
    } else {
        echo "The reopened shape is not a picture frame.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

Kolekcja nie narzuca macierzy kompatybilności, która ogranicza operacje koloru, alfa i rozmycia do osobnych łańcuchów. Mogą być one łączone, ale nie zawsze jest to użyteczne. Stała zamiana koloru usuwa wariacje RGB wytworzone przez wcześniejsze efekty kolorystyczne; odcienie szarości po duotonie usuwają dwa wybrane kolory; a operacje alfa typu ceiling, floor, replacement lub bi‑level mogą odrzucić szczegóły alfa stworzone wcześniej. Buduj łańcuch zgodnie z pożądaną kolejnością przetwarzania pikseli, a nie traktuj jego elementów jako nieuporządkowane flagi formatowania.


<!-- visual-explanation:image-transform-effects:start -->
[![Ten sam obraz przechodzi najpierw przez odcienie szarości, a potem tint, oraz tint przed odcieniami szarości. Dwa końcowe obrazy w odcieniach szarości mają różne tonacje.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*W tym ilustracyjnym renderze Aspose.Slides dla .NET 26.11, tint o 220° przy 25% nie zmienia obrazu w odcieniach szarości. Zastosowanie tego samego tintu przed odcieniami szarości powoduje różne tonacje.*
<!-- visual-explanation:image-transform-effects:end -->

## **Sprawdź edytowalne i efektywne wartości**

Edytowalna operacja to obiekt przechowywany w `Picture::getImageTransform`. W zależności od efektu, może ona bezpośrednio udostępniać zapisywalne członki. Na przykład, [Blur](https://reference.aspose.com/slides/php-java/aspose.slides/blur/) udostępnia zapisywalne wartości `radius` i `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/php-java/aspose.slides/alphamodulatefixed/) udostępnia zapisywalny `amount`, a [AlphaBiLevel](https://reference.aspose.com/slides/php-java/aspose.slides/alphabilevel/) udostępnia zapisywalny `threshold`. Efekty kolorystyczne takie jak [Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) udostępniają mutowalne obiekty [ColorFormat](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/).

Niektóre operacje, w tym [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/php-java/aspose.slides/tint/), i [AlphaReplace](https://reference.aspose.com/slides/php-java/aspose.slides/alphareplace/), nie udostępniają swoich skalarów tworzenia jako zapisywalnych właściwości. Aby zmienić te ustawienia, usuń operację i dodaj zamiennik w wymaganej pozycji.

Dane efektywne zwracane przez `getEffective()` są obliczane i tylko do odczytu. Są przydatne do rozwiązywania zależności od motywu oraz odczytywania znormalizowanych wartości używanych przez renderer, ale nie stanowią dodatkowej powierzchni edycji. Poniższy przykład wylicza łańcuch i inspekcjonuje wartości efektywne tam, gdzie odpowiednie API je udostępnia:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $operation = $imageTransform->get_Item($index);
            echo $index . ": " . java_values($operation->getClass()->getSimpleName()) . PHP_EOL;

            if (java_instanceof($operation, new JavaClass("com.aspose.slides.Luminance"))) {
                $data = $operation->getEffective();
                echo "  Brightness: " . java_values($data->getBrightness()) . PHP_EOL;
                echo "  Contrast: " . java_values($data->getContrast()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Duotone"))) {
                $data = $operation->getEffective();
                echo "  Dark color: " . java_values($data->getColor1()->toString()) . PHP_EOL;
                echo "  Light color: " . java_values($data->getColor2()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.ColorReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement color: " . java_values($data->getColor()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.HSL"))) {
                $data = $operation->getEffective();
                echo "  HSL: " . java_values($data->getHue()) . ", " . java_values($data->getSaturation()) . ", " . java_values($data->getLuminance()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Tint"))) {
                $data = $operation->getEffective();
                echo "  Tint: " . java_values($data->getHue()) . ", " . java_values($data->getAmount()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Blur"))) {
                $data = $operation->getEffective();
                echo "  Blur radius: " . java_values($data->getRadius()) . " pt" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $data = $operation->getEffective();
                echo "  Alpha amount: " . java_values($data->getAmount()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement alpha: " . java_values($data->getAlpha()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaBiLevel"))) {
                $data = $operation->getEffective();
                echo "  Alpha threshold: " . java_values($data->getThreshold()) . "%" . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Operacje bez parametrów, takie jak odcienie szarości, alfa ceiling i alfa inverse, nadal mają obiekt danych efektywnych, ale nie mają skalarnych ustawień do wydrukowania. Ich obecność i pozycja w kolekcji są istotnymi informacjami.

## **Usuń lub wyczyść transformacje obrazu**

Użyj [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/removeat/), aby usunąć jedną operację po indeksie. Ponieważ indeksy zmieniają się po usunięciu, najpierw znajdź cel, a następnie usuń go po enumeracji. Użyj [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/clear/), aby usunąć cały łańcuch.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());
        $blurIndex = -1;

        for ($index = 0; $index < $effectCount; $index++) {
            if (java_instanceof($imageTransform->get_Item($index), new JavaClass("com.aspose.slides.Blur"))) {
                $blurIndex = $index;
                break;
            }
        }

        if ($blurIndex >= 0) {
            $imageTransform->removeAt($blurIndex);
            echo "The blur operation was removed." . PHP_EOL;
        }

        $imageTransform->clear();
        echo "Remaining operations: " . java_values($imageTransform->size()) . PHP_EOL;
        $presentation->save("image-transforms-cleared.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Usuwanie lub czyszczenie transformacji zmienia tylko formatowanie obrazu. Nie usuwa, nie rekompresuje ani nie zmienia w żaden sposób ponownie używanego zasobu [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/).

## **Rozważ formaty prezentacji i cele eksportu**

Transformacje obrazu pochodzą z DrawingML, więc PPTX jest preferowanym formatem edytowalnym dla łańcuchów efektów. Nawet przy PPTX nie każda operacja ma identyczną przenośność:

- Standardowe operacje DrawingML, takie jak luminancja, odcienie szarości, duoton, tint, HSL, rozmycie i typowe operacje alfa, mają największe szanse przetrwania pełnego cyklu PPTX. Zawsze otwieraj wygenerowany plik i sprawdzaj kolekcję, gdy zachowanie jest wymogiem.
- Binarny format PPT jest starszy niż pełny model efektów DrawingML. Zapis do PPT może pominąć nieobsługiwane operacje, zredukować łańcuch do obsługiwanego podzbioru lub przybliżyć wygląd. Nie używaj PPT jako formatu weryfikacji dla złożonego, edytowalnego łańcucha.
- Renderowanie do PNG, JPEG, TIFF, PDF, SVG, HTML lub innego wyjścia wizualnego stosuje obsługiwany łańcuch do renderowanego wyglądu. Te wyjścia nie zawierają edytowalnej `ImageTransformOperationCollection`; formaty rastrowe spłaszczają wynik do pikseli, a eksporty dokumentów lub wektorów przechowują własną reprezentację renderowania.
- Efekty nie czynią połączonego obrazu samowystarczalnym. Renderowanie połączonego obrazu nadal zależy od dostępności połączonego zasobu w momencie ładowania prezentacji.

Różni konsumenci prezentacji mogą renderować przypadki brzegowe inaczej, zwłaszcza gdy połączone są operacje alfa lub kwantyzacji kolorów. Dla krytycznych rezultatów przetestuj zarówno edytowalny pełny cykl, jak i ostateczny format eksportu przy użyciu tej samej wersji Aspose.Slides, co w produkcji.

## **FAQ**

**Czy efekty transformacji obrazu modyfikują wbudowane dane obrazu?**

Nie. Operacje należą do `Picture` używanego przez wypełnienie obrazu. Bajty leżącego pod spodem `PPImage` pozostają niezmienione.

**Czy dwie ramki obrazu, które używają tego samego obrazu, dzielą swoje efekty?**

Nie. Ponowne użycie `PPImage` eliminuje duplikację danych obrazu, ale każda ramka obrazu zazwyczaj ma osobny `Picture` i osobną kolekcję transformacji obrazu.

**Czy efekty koloru, rozmycia i alfa mogą być łączone?**

Tak. Kolekcja akceptuje je w jednym uporządkowanym łańcuchu. Rozważ, co każda operacja robi z wynikiem poprzedniej, ponieważ operacje zamiany i progowe mogą odrzucać wcześniejsze szczegóły koloru lub alfa.

**Dlaczego wartości efektywne są tylko do odczytu?**

Dane efektywne reprezentują obliczone wartości używane do renderowania, w tym rozwiązywane kolory. Edytuj operację przechowywaną w kolekcji transformacji, gdzie istnieją zapisywalne członki; w przeciwnym razie usuń ją i dodaj zamiennik z nowymi parametrami tworzenia.

**Jaki format powinienem używać, aby zachować łańcuch transformacji?**

Używaj PPTX i zweryfikuj plik, otwierając go ponownie. Starszy format PPT nie może przedstawić pełnego modelu efektów DrawingML, a formaty eksportu renderują jedynie wygląd, a nie edytowalne operacje transformacji.