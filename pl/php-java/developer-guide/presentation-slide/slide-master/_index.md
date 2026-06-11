---
title: Zarządzanie mistrzami slajdów prezentacji w PHP
linktitle: Mistrz slajdu
type: docs
weight: 70
url: /pl/php-java/slide-master/
keywords:
- mistrz slajdu
- mistrz slajdu
- mistrz slajdu PPT
- wiele mistrzów slajdów
- porównywanie mistrzów slajdów
- tło
- placeholder
- klonuj mistrza slajdu
- kopiuj mistrza slajdu
- duplikuj mistrza slajdu
- nieużywany mistrz slajdu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Zarządzaj mistrzami slajdów w Aspose.Slides dla PHP przy użyciu Java: uzyskuj dostęp, edytuj, klonuj, porównuj i usuwaj mistrze slajdów w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

**Mistrz slajdu** definiuje wspólne ustawienia projektowe dla grupy slajdów. Może zawierać wspólne kształty, loga, tła, style tekstu, ustawienia motywu oraz stopki. W programie PowerPoint edycja mistrza slajdu jest typowym sposobem utrzymania spójności prezentacji bez powtarzania tego samego formatowania na każdym slajdzie.

Aspose.Slides for PHP via Java obsługuje ten sam model. Prezentacja może zawierać jeden lub więcej mistrzów slajdów, a każdy mistrz slajdu może zawierać kilka slajdów układu. Normalne slajdy zwykle nie odwołują się bezpośrednio do mistrza slajdu. Zamiast tego normalny slajd używa slajdu układu, a ten slajd układu należy do mistrza slajdu.

Hierarchia wygląda następująco:

1. **Mistrz slajdu** – definiuje wspólny projekt i motyw.  
1. **Slajd układu** – definiuje konkretny układ placeholderów i formatowanie na poziomie układu.  
1. **Normalny slajd** – zawiera rzeczywistą treść prezentacji i używa jednego slajdu układu.

![Hierarchia mistrzów slajdów, slajdów układu i normalnych slajdów](slide-master_2.jpg)

W Aspose.Slides mistrz slajdu jest reprezentowany przez klasę [MasterSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslide/). Wszystkie mistrze slajdów w prezentacji są dostępne poprzez metodę [Presentation.getMasters](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getMasters), która zwraca obiekt [MasterSlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}

Gdy to samo właściwość jest zdefiniowane na więcej niż jednym poziomie, zwycięża poziom bardziej szczegółowy. Na przykład, jeśli mistrz slajdu i slajd układu oba definiują tło, slajdy oparte na tym układzie używają tła układu. Aby uzyskać więcej informacji o slajdach układu, zobacz [Apply or Change Slide Layouts](/slides/pl/php-java/slide-layout/).

{{% /alert %}}

## **Dostęp do mistrzów slajdów**

W programie PowerPoint możesz otworzyć widok Mistrza slajdu z **View** > **Slide Master**.

![Polecenie Slide Master na karcie PowerPoint View](slide-master_3.jpg)

W Aspose.Slides użyj metody `getMasters`, aby uzyskać dostęp do mistrzów slajdów:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Możesz także uzyskać mistrza slajdu używanego przez normalny slajd poprzez jego układ:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Co zawiera mistrz slajdu**

Mistrz slajdu jest obiektem podobnym do slajdu. Rozszerza [BaseSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslide/), więc udostępnia wiele tych samych właściwości slajdu używanych przez normalne i układowe slajdy. Członkowie specyficzni dla mistrza są wymienieni na stronie API [MasterSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslide/).

Często używane członki mistrza slajdu obejmują:

| Member | Purpose |
| --- | --- |
| `getBackground` | Ustawia tło slajdu na poziomie mistrza. |
| `getShapes` | Przechowuje kształty umieszczone na mistrzu, takie jak loga, ramki obrazu i współdzielony tekst. |
| `getLayoutSlides` | Przechowuje slajdy układu, które należą do mistrza. |
| `getThemeManager` | Udostępnia dostęp do API motywu mistrza. |
| `getHeaderFooterManager` | Kontroluje nagłówki, stopki, daty i numery slajdów dla mistrza i jego układów potomnych. |
| `getDependingSlides` | Zwraca normalne slajdy zależne od mistrza poprzez ich układy. |

## **Dodawanie obrazu do mistrza slajdu**

Po dodaniu obrazu do mistrza slajdu pojawia się on na slajdach korzystających z układów tego mistrza. Jest to przydatne dla logotypów, znaków wodnych, dekoracyjnych pasów i innych powtarzalnych elementów wizualnych.

Poniższy przykład dodaje logo do pierwszego mistrza slajdu:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Aby uzyskać więcej informacji o ramach obrazu, zobacz [Picture Frame](/slides/pl/php-java/picture-frame/).

## **Praca z placeholderami**

Placeholdery są zwykle definiowane na slajdach układu. Mistrz slajdu zapewnia wspólny styl i motyw, które te układy dziedziczą, a każdy układ decyduje, które placeholdery są dostępne i gdzie są umieszczone.

W programie PowerPoint polecenia placeholderów są dostępne w widoku Mistrza slajdu.

![Polecenie Insert Placeholder w widoku Mistrza slajdu PowerPoint](slide-master_5.png)

Aby dodać nowe placeholdery w Aspose.Slides, pracuj ze slajdem układu należącym do mistrza:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Możesz także formatować kształty placeholderów, które już istnieją na mistrzu slajdu. Poniższy przykład znajduje placeholder tytułu i stosuje liniowy gradient wypełnienia:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![Sformatowany placeholder tytułu dziedziczony przez normalne slajdy](slide-master_8.png)

Aby uzyskać więcej opcji formatowania placeholderów i tekstu, zobacz [Set Prompt Text in Placeholder](/slides/pl/php-java/manage-placeholder/) oraz [Text Formatting](/slides/pl/php-java/text-formatting/).

## **Zmiana tła mistrza slajdu**

Tło mistrza jest dziedziczone przez układy i slajdy, które go nie nadpisują. Poniższy przykład ustawia jednolite tło koloru dla pierwszego mistrza slajdu:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Powiązane tematy: [Presentation Background](/slides/pl/php-java/presentation-background/) i [Presentation Theme](/slides/pl/php-java/presentation-theme/).

## **Klony mistrza slajdu w innej prezentacji**

Użyj `addClone` z [MasterSlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslidecollection/), aby skopiować mistrza slajdu do innej prezentacji. Skopiowany mistrz może być następnie używany przez układy i slajdy w docelowej prezentacji.

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

Jeśli potrzebujesz sklonować normalne slajdy wraz z ich mistrzem, zobacz [Clone Slides](/slides/pl/php-java/clone-slides/).

## **Dodawanie wielu mistrzów slajdów**

Prezentacja może zawierać wiele mistrzów slajdów. Jest to przydatne, gdy różne sekcje wymagają innego brandingu, struktury stron lub ustawień motywu.

![Polecenia PowerPoint do wstawiania i zarządzania mistrzami slajdów](slide-master_9.jpg)

Poniższy przykład klonuje domyślnego mistrza, nadaje klonowi inne tło, tworzy układ pod tym klonowanym mistrzem i dodaje nowy slajd oparty na tym układzie:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Porównywanie mistrzów slajdów**

Mistrze slajdów można porównać metodą `equals` odziedziczoną po [BaseSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslide/). Porównanie sprawdza strukturę i statyczną zawartość, taką jak kształty, tekst, formatowanie, animacje i inne ustawienia slajdu. Nie porównuje unikalnych identyfikatorów, takich jak ID slajdu, ani dynamicznych wartości placeholderów, takich jak bieżąca data.

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

Aby uzyskać więcej informacji, zobacz [Compare Presentation Slides](/slides/pl/php-java/compare-slides/).

## **Ustawienie widoku Mistrza slajdu jako domyślnego widoku**

Użyj metody `setLastView` na [ViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewproperties/), aby kontrolować widok, który PowerPoint otwiera jako pierwszy. Poniższy przykład otwiera prezentację w widoku Mistrza slajdu:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Aby uzyskać więcej ustawień widoku, zobacz [Save Presentation](/slides/pl/php-java/save-presentation/).

## **Usuwanie nieużywanych mistrzów slajdów**

Prezentacje czasami zawierają mistrze slajdów, które nie są już używane przez żadne normalne slajdy. Usunięcie nieużywanych mistrzów może zmniejszyć rozmiar pliku i uprościć utrzymanie szablonu.

Użyj `removeUnused` z [MasterSlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslidecollection/), aby usunąć nieużywane mistrze ze zbioru `getMasters`:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Możesz także użyć niskokodowej metody `removeUnusedMasterSlides` z klasy [Compress](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Jaka jest różnica między mistrzem slajdu a slajdem układu?**

Mistrz slajdu definiuje wspólne ustawienia projektowe, takie jak motyw, tło, wspólne kształty i style tekstu. Slajd układu należy do mistrza slajdu i definiuje konkretny układ placeholderów. Normalny slajd używa slajdu układu, więc dziedziczy zarówno po układzie, jak i po mistrzu.

**Czy jedna prezentacja może zawierać kilka mistrzów slajdów?**

Tak. Prezentacja może zawierać wiele mistrzów slajdów. Używaj wielu mistrzów, gdy różne sekcje wymagają odmiennych systemów wizualnych lub brandingu.

**Czy powinienem dodawać placeholdery do mistrza slajdu czy do slajdu układu?**

W większości przypadków dodawaj placeholdery do slajdów układu. Umieść wspólne elementy wizualne i wspólne formatowanie na mistrzu slajdu, a placeholdery treści na układach, które będą używane przez normalne slajdy.

**Czy mogę usunąć mistrza slajdu, który jest nadal używany?**

Nie. Mistrz slajdu, który ma zależne slajdy, nie może być bezpiecznie usunięty bezpośrednio. Najpierw przenieś te slajdy do układów pod innym mistrzem lub użyj metody czyszczenia nieużywanych mistrzów, która usuwa tylko mistrze nie wykorzystywane.