---
title: Zarządzanie efektami przekształcenia obrazu w prezentacjach za pomocą PHP
linktitle: Efekty przekształcenia obrazu
type: docs
weight: 11
url: /pl/php-java/image-transform-effects/
keywords:
- przekształcenie obrazu
- efekt obrazu
- jasność
- kontrast
- skala szarości
- duoton
- odcień
- HSL
- zastąpienie koloru
- rozmycie
- przezroczystość
- efekt alfa
- łańcuch efektów
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Stosuj, łącz, przeglądaj, usuwaj i weryfikuj efekty przekształcenia obrazu dla ramek obrazu przy użyciu Aspose.Slides dla PHP poprzez Javę."
---
## **Przegląd**

Aspose.Slides przedstawia regulacje obrazu jako uporządkowaną kolekcję operacji przekształcenia obrazu. Dla ramki obrazu rozpocznij od [Picture](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picture/) ramki i uzyskaj dostęp do [Picture::getImageTransform](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picture/getimagetransform/). Zwrócona [ImageTransformOperationCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/) pozwala dodawać, wyliczać, przeglądać, usuwać i wyczyścić efekty bez przepisania oryginalnych bajtów obrazu.

Ten artykuł demonstruje kompletny przepływ pracy dla jasności i kontrastu, przekształceń kolorów, rozmycia, przezroczystości, uporządkowanych łańcuchów efektów, wartości efektywnych, usuwania oraz weryfikacji round‑trip PPTX.

## **Zrozumienie własności efektu i ponownego użycia obrazu**

Zasób obrazu i obraz wyświetlający go to różne obiekty:

- [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) przechowuje lub odwołuje się do danych źródłowego obrazu będących własnością prezentacji.
- [Picture](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picture/) należy do wypełnienia obrazu i odwołuje się do zasobu obrazu, jednocześnie przechowując kolekcję przekształceń obrazu.
- [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/) jest kształtem slajdu, który posiada odpowiednie wypełnienie obrazu, geometrię, ustawienia przycięcia i inne formatowanie na poziomie ramki.

Dlatego operacje przekształcenia obrazu nie modyfikują bajtów w [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/). Gdy ten sam `PPImage` zostanie przekazany do [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addpictureframe/) więcej niż raz, każda nowa ramka obrazu otrzymuje własny `Picture` i własną kolekcję przekształceń. Zastosowanie szarości do jednej ramki nie powoduje, że inne ramki stają się szare, mimo że wszystkie korzystają z tego samego wbudowanego zasobu obrazu.

Ten sam model `Picture::getImageTransform` jest również używany przez inne wypełnienia obrazów, takie jak kształt lub tło slajdu. Poniższe przykłady koncentrują się na ramach obrazu.

## **Używanie prawidłowych zakresów parametrów i jednostek**

Prezentowane metody wykorzystują następujące semantyczne zakresy i jednostki. Trzymaj wartości w tych zakresach, nawet jeśli konkretna wersja biblioteki nie odrzuca od razu każdej nieprawidłowej wartości; docelowy format prezentacji może normalizować, pomijać lub odrzucać nieprawidłowe dane podczas zapisu lub otwierania pliku w PowerPoint.

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100`‑`100`, procent; `0` pozostawia komponent niezmieniony. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | None | Brak parametrów liczbowych. Alfa pozostaje niezmieniona. |
| [addDuotoneEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Dwa kolory dla ciemnych i jasnych pikseli. Kanały RGB i alfa w `java.awt.Color` używają zakresu `0`‑`255`. |
| [addTintEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Odcień `0` (włącznie)‑`360` (wyłącznie) stopni; ilość `-100`‑`100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Odcień `0`‑`360` stopni; nasycenie i luminancja `-100`‑`100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | Kolor zamienny używa wartości kanałów od `0` do `255`. Istniejące wartości alfa pozostają niezmienione. |
| [addBlurEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Promień nieujemny, mierzony w punktach; `grow` to wartość Boolean określająca, czy rozmyta treść może wyjść poza pierwotne granice. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nieujemny procent. Użyj `0`‑`100` do typowego skalowania nieprzezroczystości: `0` to w pełni przezroczyste, `100` zachowuje istniejącą alfę. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0`‑`100`, procent nieprzezroczystości. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0`‑`100`, procentowy próg alfy. Wartości poniżej progu stają się przezroczyste; wartości równe lub powyżej stają się nieprzezroczyste. |

Dla stałej modulacji alfa, przezroczystość i nieprzezroczystość są komplementarne. Na przykład 35 % przezroczystości odpowiada modulacji alfa o wartości 65 %.

## **Zastosowanie jasności i kontrastu**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) zwraca operację [Luminance](https://reference.aspose.com/slides/pl/php-java/aspose.slides/luminance/). Jej ustawienia skalarne są podawane w momencie tworzenia operacji. [Luminance::getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/luminance/geteffective/) zwraca wyliczone wartości tylko do odczytu, które można przejrzeć lub zalogować.

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

`Luminance` to standardowy efekt jasności i kontrastu w DrawingML. Gdy te ustawienia muszą pozostać edytowalne po round‑trip PPTX, otwórz ponownie zapisaną prezentację i zweryfikuj zarówno typ operacji, jak i jej wartości efektywne.

## **Zastosowanie przekształceń kolorów**

Efekty kolorystyczne można nakładać niezależnie na różne ramki obrazu, które korzystają z jednego zasobu obrazu. Poniższy przykład tworzy pięć ramek i stosuje kolejno szarość, duoton, odcień, regulację HSL i zamianę koloru.

[Duotone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/duotone/) zawiera dwa niezależnie edytowalne parametry koloru: `color1` mapuje ciemne piksele, natomiast `color2` mapuje jasne piksele. To użyteczny przykład efektu, którego ustawienia są bardziej złożone niż pojedyncza wartość skalarna.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) zastępuje kolor każdego piksela jednym stałym kolorem, zachowując alfę. Różni się od [addColorChangeEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), które mapuje jeden kolor źródłowy na inny i udostępnia zarówno formaty koloru źródłowego, jak i docelowego.

## **Dodawanie rozmycia, przezroczystości i efektów alfa**

[addBlurEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) wpływa na wszystkie kanały kolorów, w tym alfy. Ustaw `grow` na `true`, gdy rozmyta krawędź może wyjść poza pierwotne granice obrazu.

Do jednolitej przezroczystości użyj [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Mnoży ona każdą istniejącą wartość alfy, więc częściowo przezroczyste piksele pozostają proporcjonalnie różne. [addAlphaReplaceEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) natomiast przypisuje jedną wartość alfy wszystkim pikselom. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) konwertuje alfę na dwa poziomy w oparciu o podany próg.

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

Inne operacje alfa bez parametrów obejmują [addAlphaCeilingEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), które sprawia, że każda niezerowa alfa staje się w pełni nieprzezroczysta; [addAlphaFloorEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), które czyni każdą alfę poniżej 100 % w pełni przezroczystą; oraz [addAlphaInverseEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), które zmienia alfę na `100% - alpha`.

## **Budowanie uporządkowanego łańcucha efektów**

Każda metoda `add...Effect` dołącza nową operację na koniec kolekcji. Renderujący używa kolekcji jako uporządkowanego potoku: wyjście operacji 0 staje się wejściem operacji 1 i tak dalej. W konsekwencji te same operacje w innej kolejności mogą dawać inny obraz.

Na przykład szarość, a potem odcień najpierw usuwa informacje chromatyczne, a potem recoloruje wynik luminancji. Odcień, a potem szarość ponownie usuwa odcień. Podobnie zamiana alfy może nadpisać wartości alfy obliczone przez wcześniejsze operacje, podczas gdy modulacja alfy zachowuje ich względne różnice.

Poniższy przykład buduje łańcuch czterech operacji, zapisuje go jako PPTX, ponownie otwiera prezentację, sprawdza zarówno typy operacji, jak i ich kolejność, oraz renderuje ponownie otwarty wynik:

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

Kolekcja nie narzuca macierzy kompatybilności, która ogranicza operacje koloru, alfy i rozmycia do oddzielnych łańcuchów. Mogą być łączone, ale kombinacje nie zawsze są użyteczne. Stała zamiana koloru usuwa wariację RGB wytworzoną przez wcześniejsze efekty kolorystyczne; szarość po duotonie usuwa dwa wybrane kolory; a operacje alfa typu ceiling, floor, replace lub bi‑level mogą odrzucić szczegóły alfy stworzone wcześniej. Buduj łańcuch zgodnie z pożądaną sekwencją przetwarzania pikseli, a nie traktuj elementów jako nieuporządkowane flagi formatowania.

## **Inspekcja wartości edytowalnych i efektywnych**

Edytowalna operacja to obiekt przechowywany w `Picture::getImageTransform`. W zależności od efektu może ona bezpośrednio udostępniać zapisywalne pola. Na przykład [Blur](https://reference.aspose.com/slides/pl/php-java/aspose.slides/blur/) udostępnia zapisywalne `radius` i `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/pl/php-java/aspose.slides/alphamodulatefixed/) udostępnia zapisywalny `amount`, a [AlphaBiLevel](https://reference.aspose.com/slides/pl/php-java/aspose.slides/alphabilevel/) udostępnia zapisywalny `threshold`. Efekty kolorystyczne, takie jak [Duotone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/duotone/), udostępniają zmienne obiekty [ColorFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/colorformat/).

Niektóre operacje, w tym [Luminance](https://reference.aspose.com/slides/pl/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/pl/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tint/) i [AlphaReplace](https://reference.aspose.com/slides/pl/php-java/aspose.slides/alphareplace/), nie udostępniają swoich skalarów tworzenia jako zapisywalnych własności. Aby zmienić te ustawienia, usuń operację i dodaj zamiennik w wymaganej pozycji.

Dane efektywne zwracane przez `getEffective()` są wyliczone i tylko do odczytu. Są przydatne do rozwiązywania zależności od tematu i odczytywania znormalizowanych wartości używanych przez renderujący, ale nie stanowią dodatkowej powierzchni edycji. Poniższy przykład wylicza łańcuch i inspekcjonuje wartości efektywne tam, gdzie odpowiednie API je udostępnia:

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

Efekty bez parametrów, takie jak szarość, alfa ceiling i alfa inverse, nadal mają obiekt danych efektywnych, ale nie mają skalarnych ustawień do wydrukowania. Ich obecność i pozycja w kolekcji są istotną informacją.

## **Usuwanie lub czyszczenie przekształceń obrazu**

Użyj [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/removeat/), aby usunąć jedną operację według indeksu. Ponieważ indeksy zmieniają się po usunięciu, najpierw wyszukaj docelową operację, a potem usuń ją po wyliczeniu. Użyj [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagetransformoperationcollection/clear/), aby usunąć cały łańcuch.

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

Usunięcie lub wyczyszczenie przekształceń zmienia tylko formatowanie obrazu. Nie usuwa, nie kompresuje ani nie modyfikuje ponownie używanego zasobu [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/).

## **Rozważanie formatów prezentacji i docelowych formatów eksportu**

Przekształcenia obrazu pochodzą z DrawingML, więc PPTX jest preferowanym edytowalnym formatem dla łańcuchów efektów. Nawet w PPTX nie każda operacja ma identyczną przenośność:

- Standardowe operacje DrawingML, takie jak luminancja, szarość, duoton, odcień, HSL, rozmycie i typowe operacje alfa, mają największe szanse przetrwania round‑trip PPTX. Zawsze ponownie otwieraj wygenerowany plik i inspekcjonuj kolekcję, gdy zachowanie jest wymogiem.
- Binarny format PPT powstał przed pełnym modelem efektów DrawingML. Zapis do PPT może pomijać nieobsługiwane operacje, redukować łańcuch do obsługiwanego podzestawu lub przybliżać wygląd. Nie używaj PPT jako formatu weryfikacji dla złożonego edytowalnego łańcucha.
- Renderowanie do PNG, JPEG, TIFF, PDF, SVG, HTML lub innych formatów wizualnych stosuje obsługiwany łańcuch do wyglądu wynikowego. Te wyjścia nie zawierają edytowalnego `ImageTransformOperationCollection`; formaty rastrowe spłaszczają wynik do pikseli, a eksporty dokumentów lub wektorów przechowują własną reprezentację renderingu.
- Efekty nie czynią połączonego obrazu samowystarczalnym. Renderowanie połączonego obrazu nadal zależy od dostępności połączonego zasobu w momencie ładowania prezentacji.

Różni konsumenci prezentacji mogą renderować przypadki brzegowe inaczej, zwłaszcza gdy połączone są liczne operacje alfa lub kwantyzacji kolorów. Dla krytycznych wyjść przetestuj zarówno edytowalny round‑trip, jak i ostateczny format eksportu przy użyciu tej samej wersji Aspose.Slides, co w produkcji.

## **FAQ**

**Czy efekty przekształcenia obrazu modyfikują dane wbudowanego obrazu?**

Nie. Operacje należą do `Picture` używanego przez wypełnienie obrazu. Podstawowe bajty `PPImage` pozostają niezmienione.

**Czy dwa ramki obrazu, które używają tego samego obrazu, współdzielą swoje efekty?**

Nie. Ponowne użycie `PPImage` eliminuje duplikację danych obrazu, ale każda ramka obrazu zazwyczaj ma osobny `Picture` i własną kolekcję przekształceń obrazu.

**Czy efekty koloru, rozmycia i alfy mogą być łączone?**

Tak. Kolekcja przyjmuje je w jednym uporządkowanym łańcuchu. Rozważ, co każda operacja robi z wynikiem poprzedniej, ponieważ operacje zamiany i progowe mogą odrzucać wcześniejsze szczegóły koloru lub alfy.

**Dlaczego wartości efektywne są tylko do odczytu?**

Dane efektywne reprezentują wyliczone wartości używane do renderowania, w tym rozwiązywane kolory. Edytuj operację przechowywaną w kolekcji przekształceń, gdzie istnieją zapisywalne pola; w przeciwnym razie usuń ją i dodaj zamiennik z nowymi parametrami tworzenia.

**Jaki format powinienem używać, aby zachować łańcuch przekształceń?**

Używaj PPTX i weryfikuj plik ponownym otwarciem. Starszy format PPT nie może przedstawić pełnego modelu efektów DrawingML, a formaty eksportu graficznego zachowują jedynie wygląd, nie edytowalne operacje przekształcenia.