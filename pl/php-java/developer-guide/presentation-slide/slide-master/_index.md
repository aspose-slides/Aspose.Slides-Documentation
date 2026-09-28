---
title: Zarządzanie masterami slajdów prezentacji w PHP
linktitle: Master slajdu
type: docs
weight: 70
url: /pl/php-java/slide-master/
keywords:
- master slajd
- master slajd
- master slajd PPT
- wiele masterów slajdów
- porównywanie master slajdów
- tło
- pole zastępcze
- klonowanie master slajdu
- kopiowanie master slajdu
- duplikowanie master slajdu
- nieużywany master slajd
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Zarządzaj masterami slajdów w Aspose.Slides dla PHP poprzez Java: uzyskaj dostęp, edytuj, klonuj, porównuj i usuwaj master slajdy w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

A **master slajdu** definiuje wspólne ustawienia projektowe dla grupy slajdów. Może zawierać wspólne kształty, loga, tła, style tekstu, ustawienia motywu i stopki. W programie PowerPoint edycja mastera slajdu jest typowym sposobem zapewnienia spójności prezentacji bez powtarzania tego samego formatowania na każdym slajdzie.

Aspose.Slides for PHP via Java obsługuje ten sam model. Prezentacja może zawierać jeden lub więcej masterów slajdów, a każdy master slajdu może zawierać kilka slajdów układu. Normalne slajdy zazwyczaj nie odwołują się bezpośrednio do mastera slajdu. Zamiast tego normalny slajd używa slajdu układu, a ten slajd układu należy do mastera slajdu.

Hierarchia wygląda następująco:

1. **Master slajdu** – definiuje współdzielony projekt i motyw.  
1. **Slajd układu** – definiuje konkretne rozmieszczenie pól zastępczych i formatowanie na poziomie układu.  
1. **Normalny slajd** – zawiera rzeczywistą treść prezentacji i używa jednego slajdu układu.

![Hierarchia masterów slajdów, slajdów układu i normalnych slajdów](slide-master_2.jpg)

W Aspose.Slides master slajdu jest reprezentowany przez klasę [MasterSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslide/). Wszystkie mastery slajdów w prezentacji są dostępne przez metodę [Presentation.getMasters](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getMasters), która zwraca obiekt [MasterSlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Kiedy ta sama właściwość jest zdefiniowana na więcej niż jednym poziomie, wygrywa poziom bardziej szczegółowy. Na przykład, jeśli master slajdu i slajd układu oba definiują tło, slajdy oparte na tym układzie używają tła układu. Więcej informacji o slajdach układu znajdziesz w [Apply or Change Slide Layouts](/slides/pl/php-java/slide-layout/).
{{% /alert %}}

## **Uzyskiwanie dostępu do masterów slajdów**

W programie PowerPoint możesz otworzyć widok Master slajdu z **Widok** > **Master slajdu**.

![Polecenie Master slajdu na karcie Widok w programie PowerPoint](slide-master_3.jpg)

W Aspose.Slides użyj metody `getMasters`, aby uzyskać dostęp do masterów slajdów:

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

Możesz także pobrać master slajdu używany przez normalny slajd poprzez jego układ:

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

## **Co zawiera master slajdu**

Master slajd jest obiektem podobnym do slajdu. Rozszerza [BaseSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslide/), więc udostępnia wiele tych samych właściwości slajdu używanych przez normalne i układowe slajdy. Specyficzne dla mastera elementy wymieniono na stronie API [MasterSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslide/).

Często używane elementy mastera slajdu:

| Członek | Zastosowanie |
| --- | --- |
| `getBackground` | Ustawia tło slajdu na poziomie mastera. |
| `getShapes` | Przechowuje kształty umieszczone na masterze, takie jak loga, ramki obrazów i wspólny tekst. |
| `getLayoutSlides` | Przechowuje slajdy układu, które należą do mastera. |
| `getThemeManager` | Zapewnia dostęp do API motywu mastera. |
| `getHeaderFooterManager` | Kontroluje nagłówki, stopki, daty i numery slajdów dla mastera oraz jego układów podrzędnych. |
| `getDependingSlides` | Zwraca normalne slajdy, które zależą od mastera poprzez ich układy. |

## **Dodaj obraz do mastera slajdu**

Kiedy dodajesz obraz do mastera slajdu, pojawia się on na slajdach korzystających z układów tego mastera. Jest to przydatne przy logo, znakach wodnych, dekoracyjnych pasach i innych powtarzalnych elementach wizualnych.

Poniższy przykład dodaje logo do pierwszego mastera slajdu:

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

Więcej informacji o ramkach obrazów znajdziesz w [Picture Frame](/slides/pl/php-java/picture-frame/).

## **Kontrola widoczności grafiki mastera**

Użyj [BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslide/#setShowMasterShapes), aby ukryć dziedziczone grafiki mastera, takie jak loga lub dekoracyjne kształty, bez ich usuwania z mastera. Przekaż `false` do [Slide::setShowMasterShapes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#setShowMasterShapes) na slajdzie, który ma pominąć te grafiki, i pozostaw `true` na slajdach, które mają je wyświetlać.

Poniższy, autonomiczny przykład tworzy niebieski dekoracyjny pasek na masterze i dwóch slajdach korzystających z tego samego pustego układu. Pasek jest widoczny na pierwszym slajdzie i ukryty na drugim. Nie wymaga żadnej wejściowej prezentacji ani obrazu.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $layoutSlide = $masterSlide->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $layoutSlide->setShowMasterShapes(true);

    $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
    $band = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 60, $slideHeight);
    $bandColor = new Java("java.awt.Color", 70, 130, 180);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor($bandColor);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $visibleSlide = $presentation->getSlides()->get_Item(0);
    $visibleSlide->setLayoutSlide($layoutSlide);
    $visibleSlide->getShapes()->clear();

    $hiddenSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $visibleSlide->setShowMasterShapes(true);
    $hiddenSlide->setShowMasterShapes(false);

    $presentation->save("master-graphics.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Przykład używa układu **Blank** dostarczonego z nową prezentacją i usuwa początkowe pola zastępcze pierwszego slajdu.

### **Wybierz zakres ustawienia**

Normalny slajd używa swojego mastera poprzez [Slide::getLayoutSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#getLayoutSlide) i [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/#getMasterSlide). Ustawienie właściwości na pojedynczym slajdzie wpływa tylko na ten slajd. Przekazanie `false` do [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/#setShowMasterShapes) ukrywa grafiki mastera dla slajdów używających tego wspólnego układu, nawet jeśli ich własne ustawienie jest `true`. Aby ukryć grafiki tylko na jednym slajdzie, zmień właściwość slajdu i pozostaw wspólny układ niezmieniony.

Ustawienie nie jest obsługiwane jako kontrola widoczności bezpośrednio na masterze slajdu. Na masterze metoda [getShowMasterShapes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslide/#getShowMasterShapes) zawsze zwraca `false`, a przekazanie `true` do [setShowMasterShapes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslide/#setShowMasterShapes) powoduje wyjątek. Zastosuj je do normalnego slajdu lub układu.

### **Rozróżnij grafikę od tła**

| Operacja | Efekt |
| --- | --- |
| Ukryj grafikę mastera | Kontroluje widoczność dziedziczonych kształtów mastera bez ich usuwania i bez zmiany własnych kształtów slajdu. |
| Zmień wypełnienie tła slajdu | Zmienia kolor, gradient lub obraz tła. Grafika mastera jest osobnym kształtem i może pozostać widoczna nad tym tłem. Zobacz [Presentation Background](/slides/pl/php-java/presentation-background/). |
| Usuń kształt z mastera | Usuwa współdzielony kształt źródłowy, więc nie jest już dostępny dla żadnego slajdu używającego tego mastera. |

## **Praca z polami zastępczymi**

Pola zastępcze są zwykle definiowane na slajdach układu. Master slajdu zapewnia wspólny styl i motyw, które te układy dziedziczą, a każdy układ decyduje, które pola zastępcze są dostępne i gdzie są rozmieszczone.

W programie PowerPoint polecenia pól zastępczych są dostępne w widoku Master slajdu.

![Polecenie Wstaw pole zastępcze w widoku Master slajdu w programie PowerPoint](slide-master_5.png)

Aby dodać nowe pola zastępcze przy użyciu Aspose.Slides, pracuj ze slajdem układu, który należy do mastera:

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

Możesz także formatować istniejące już na masterze kształty pól zastępczych. Poniższy przykład znajduje pole zastępcze tytułu i stosuje liniowe wypełnienie gradientowe:

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

![Sformatowane pole zastępcze tytułu dziedziczone przez normalne slajdy](slide-master_8.png)

Więcej opcji formatowania pól zastępczych i tekstu znajdziesz w [Set Prompt Text in Placeholder](/slides/pl/php-java/manage-placeholder/) oraz [Text Formatting](/slides/pl/php-java/text-formatting/).

## **Zmień tło mastera slajdu**

Tło mastera jest dziedziczone przez układy i slajdy, które go nie nadpisują. Poniższy przykład ustawia jednolity kolor tła dla pierwszego mastera slajdu:

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

## **Sklonuj master slajdu do innej prezentacji**

Użyj `addClone` z [MasterSlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslidecollection/), aby skopiować master slajdu do innej prezentacji. Skopiowany master może być następnie używany przez układy i slajdy w prezentacji docelowej.

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

Jeśli potrzebujesz sklonować normalne slajdy razem z ich masterem, zobacz [Clone Slides](/slides/pl/php-java/clone-slides/).

## **Dodaj wiele masterów slajdów**

Prezentacja może zawierać wiele masterów slajdów. Jest to przydatne, gdy różne sekcje wymagają odmiennych elementów marki, struktury stron lub ustawień motywu.

![Polecenia programu PowerPoint do wstawiania i zarządzania masterami slajdów](slide-master_9.jpg)

Poniższy przykład klonuje domyślny master, nadaje klonowi inne tło, tworzy układ pod tym sklonowanym masterem i dodaje nowy slajd oparty na tym układzie:

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

## **Porównaj mastery slajdów**

Mastery slajdów można porównać metodą `equals` odziedziczoną po [BaseSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslide/). Porównanie sprawdza strukturę i statyczną zawartość, taką jak kształty, tekst, formatowanie, animacje i inne ustawienia slajdu. Nie porównuje unikalnych identyfikatorów, takich jak ID slajdów, ani dynamicznych wartości pól zastępczych, takich jak bieżąca data.

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

Więcej informacji znajdziesz w [Compare Presentation Slides](/slides/pl/php-java/compare-slides/).

## **Ustaw widok mastera slajdu jako domyślny widok**

Użyj metody `setLastView` na [ViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewproperties/), aby kontrolować widok, który PowerPoint otwiera jako pierwszy. Poniższy przykład otwiera prezentację w widoku Master slajdu:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Więcej ustawień widoku znajdziesz w [Save Presentation](/slides/pl/php-java/save-presentation/).

## **Usuń nieużywane mastery slajdów**

Prezentacje czasami zawierają mastery slajdów, które nie są już używane przez żadne normalne slajdy. Usunięcie nieużywanych masterów może zmniejszyć rozmiar pliku i uprościć utrzymanie szablonu.

Użyj `removeUnused` z [MasterSlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslidecollection/), aby usunąć nieużywane mastery ze zbioru `getMasters`:

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

**Jaka jest różnica między masterem slajdu a slajdem układu?**

Master slajdu definiuje wspólne ustawienia projektowe, takie jak motyw, tło, wspólne kształty i style tekstu. Slajd układu należy do mastera i definiuje konkretny układ pól zastępczych. Normalny slajd używa slajdu układu, więc dziedziczy zarówno z układu, jak i z mastera.

**Czy jedna prezentacja może zawierać kilka masterów slajdów?**

Tak. Prezentacja może zawierać kilka masterów slajdów. Używaj wielu masterów, gdy różne sekcje wymagają odmiennych systemów wizualnych lub brandingu.

**Czy powinienem dodawać pola zastępcze do mastera slajdu czy do slajdu układu?**

W większości przypadków dodawaj pola zastępcze do slajdów układu. Umieść współdzielone elementy wizualne i formatowanie na masterze, a pola zawartości na układach, które będą wykorzystywane przez normalne slajdy.

**Czy mogę usunąć master slajdu, który jest nadal używany?**

Nie. Master slajdu, który ma zależne slajdy, nie może być bezpiecznie usunięty bezpośrednio. Najpierw przenieś te slajdy do układów pod innym masterem lub użyj metody czyszczenia nieużywanych masterów, która usuwa tylko mastery niebędące w użyciu.