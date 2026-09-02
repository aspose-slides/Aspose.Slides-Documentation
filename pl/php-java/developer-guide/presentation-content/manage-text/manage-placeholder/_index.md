---
title: Zarządzanie placeholderami prezentacji w PHP
linktitle: Zarządzaj placeholderami
type: docs
weight: 10
url: /pl/php-java/manage-placeholder/
keywords:
- symbol zastępczy
- placeholder tekstowy
- placeholder obrazu
- placeholder wykresu
- placeholder treści
- tekst podpowiedzi
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak przeglądać i edytować placeholdery tekstowe, obrazkowe, wykresu i treści oraz zrozumieć dziedziczenie placeholderów przy użyciu Aspose.Slides dla PHP za pośrednictwem Javy."
---
## **Przegląd**

Placeholder to kształt, który rezerwuje pozycję dla określonego rodzaju treści w szablonie prezentacji. Typowe przykłady to tytuł, treść, obraz, wykres i ogólne placeholdery treści. W przeciwieństwie do zwykłego kształtu, placeholder może dziedziczyć swoją pozycję, rozmiar, formatowanie i inne ustawienia z slajdu układu lub slajdu głównego.

Aspose.Slides udostępnia informacje o placeholderach za pośrednictwem metody [Shape::getPlaceholder](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getplaceholder/). Metoda zwraca obiekt [Placeholder](https://reference.aspose.com/slides/pl/php-java/aspose.slides/placeholder/) lub `null` dla zwykłego kształtu. Użyj [Placeholder::getType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/placeholder/gettype/), aby określić, co placeholder ma zawierać.

Klasa kształtu nadal ma znaczenie po poznaniu typu placeholdera:

- Pusty placeholder tekstowy, obrazkowy, wykresu lub treści jest zazwyczaj reprezentowany przez [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/).
- Wypełniony placeholder obrazu może być reprezentowany przez [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/).
- Wypełniony placeholder wykresu może być reprezentowany przez [Chart](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/).
- Placeholder treści może zawierać kilka rodzajów treści. Sprawdź zarówno [Placeholder::getType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/placeholder/gettype/), jak i klasę kształtu w czasie wykonywania, zamiast zakładać, że każdy placeholder jest [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Ostrzeżenie" %}}
[Placeholder::getType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/placeholder/gettype/) opisuje rolę placeholdera; nie gwarantuje klasy kształtu w czasie wykonywania. Zawsze używaj sprawdzania typu przed dostępem do członków specyficznych dla tekstu, obrazu, wykresu, tabeli lub mediów.
{{% /alert %}}

## **Zrozumienie dziedziczenia placeholderów**

Placeholdery tworzą hierarchię:

1. Slajd główny definiuje style wielokrotnego użytku i w niektórych przypadkach placeholdery na poziomie mastera.
2. Slajd układu definiuje rozmieszczenie używane przez jeden lub więcej zwykłych slajdów i może dziedziczyć z mastera.
3. Zwykły slajd zawiera placeholdery dla tego slajdu i może dziedziczyć z jego układu.

Wywołaj [Shape::getBasePlaceholder](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getbaseplaceholder/), aby przejść o poziom wyżej w tej hierarchii. Placeholder slajdu zazwyczaj zwraca swój placeholder układu; placeholder układu może zwrócić swój placeholder mastera. Metoda zwraca `null`, gdy kształt nie ma bazowego placeholdera.

Poniższy przykład wyświetla placeholdery na pierwszym slajdzie i podaje ich bazowe placeholdery:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Edycja placeholdera na zwykłym slajdzie tworzy lub zmienia lokalne nadpisanie dla tego slajdu. Edycja powiązanego układu lub mastera może wpłynąć na wszystkie slajdy, które nadal dziedziczą to ustawienie. Lokalny zwykły kształt nie ma bazowego placeholdera i nie zaczyna dziedziczyć jedynie dlatego, że zajmuje te same współrzędne.

## **Zmienianie tekstu w placeholderze**

Placeholdery tytułu, wyśrodkowanego tytułu, podtytułu, treści i tekstu zazwyczaj obsługują tekst. Sprawdź, czy jest to [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/), zanim użyjesz jego metody [getTextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/gettextframe/).

Ten przykład aktualizuje pierwszy placeholder tytułu na pierwszym slajdzie i zapisuje wynik:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ten wzorzec unika traktowania placeholderów obrazu, wykresu, tabeli lub mediów jako obiektów [AutoShape]. Identyfikuje również placeholder po przeznaczeniu, zamiast polegać na kruchym indeksie kształtu.

## **Ustawianie tekstu podpowiedzi na układzie**

Tekst podpowiedzi to instrukcja wyświetlana w trybie projektowania w pustym placeholderze, np. *Kliknij, aby dodać tytuł*. Ustaw własny tekst podpowiedzi na placeholderze układu, zamiast próbować go uzyskać przez kolekcję kształtów zwykłego slajdu. Uzyskaj układ poprzez [Slide::getLayoutSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#getLayoutSlide) i iteruj po kolekcji zwróconej przez [BaseSlide::getShapes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslide/#getShapes).

Poniższy przykład zmienia podpowiedzi tytułu i podtytułu w układzie używanym przez pierwszy slajd:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Tekst podpowiedzi nie jest normalną treścią slajdu. Jest przeznaczony dla pustych placeholderów w aplikacjach edytujących, takich jak PowerPoint. Gdy użytkownik lub program dostarczy prawdziwą treść, podpowiedź przestaje być wyświetlana. Zmiana podpowiedzi nie zastępuje istniejącego tekstu na slajdach korzystających z tego układu.

## **Aktualizacja placeholdera obrazu**

Są dwa przypadki do obsłużenia:

- Jeśli placeholder obrazu jest już wypełniony i reprezentowany przez [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/), zamień obraz przy użyciu [PictureFillFormat::getPicture](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/getpicture/) oraz [SlidesPicture::setImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidespicture/setimage/).
- Jeśli jest to nadal pusty placeholder, dodaj ramkę obrazu w współrzędnych placeholdera za pomocą [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addpictureframe/) i usuń pusty placeholder.

Następny przykład obsługuje oba przypadki i zapisuje prezentację:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Zastępstwo utworzone dla pustego placeholdera jest lokalną ramką obrazu, nie nowym placeholderem, ponieważ [Shape::getPlaceholder](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getplaceholder/) nie udostępnia setteru. Zachowuje zarezerwowaną pozycję, ale nie dziedziczy już zachowań specyficznych dla placeholdera. Jeśli zachowanie relacji placeholdera jest kluczowe, przygotuj i wypełnij placeholder w PowerPoint najpierw, a następnie zaktualizuj powstały [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/) przy użyciu Aspose.Slides.

W kwestii przeźroczystości obrazu, kadrowania i innych efektów specyficznych dla obrazu, zobacz [Manage Picture Frames](/slides/pl/php-java/picture-frame/). Te operacje należą do ramki obrazu lub wypełnienia obrazu, a nie do metadanych placeholdera.

## **Praca z placeholderami wykresów i treści**

Wypełniony placeholder wykresu może być reprezentowany przez [Chart](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/). Ten przykład znajduje taki wykres zarówno po typie placeholdera, jak i klasie w czasie wykonywania, zmienia jego tytuł i zapisuje plik:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ogólny placeholder treści zazwyczaj ma [PlaceholderType::Object](https://reference.aspose.com/slides/pl/php-java/aspose.slides/placeholdertype/). W PowerPoint działa jako uruchamiacz dla kilku typów treści, w tym wykresów, tabel, diagramów, obrazów i mediów. Po wypełnieniu, sprawdź rzeczywistą klasę kształtu, aby dowiedzieć się, co zawiera. Specjalistyczne układy mogą także udostępniać [PlaceholderType::Chart](https://reference.aspose.com/slides/pl/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/pl/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/pl/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/pl/php-java/aspose.slides/placeholdertype/), lub [PlaceholderType::Diagram](https://reference.aspose.com/slides/pl/php-java/aspose.slides/placeholdertype/).

Aspose.Slides nie konwertuje pustego placeholdera [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) na [Chart] jedynie poprzez zmianę [Placeholder::getType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/placeholder/gettype/); typu nie można zmienić przez klasę. Aby programowo wypełnić pusty obszar wykresu lub treści, dodaj wymagany obiekt w współrzędnych placeholdera, a następnie usuń pusty placeholder. Poniższy przykład robi to dla wykresu:

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dodany wykres jest zwykłym lokalnym wykresem. Zajmuje obszar placeholdera, ale nie dziedziczy z placeholdera układu. Skorzystaj z dedykowanych [chart management articles](/slides/pl/php-java/powerpoint-charts/), gdy potrzebujesz zastąpić jego kategorie, serie lub dane skoroszytu.

## **Pełny przykład: aktualizacja tekstu lub obrazu**

Poniższy przykład end‑to‑end otwiera szablon, przeszukuje pierwszy slajd pod kątem placeholdera tytułu lub obrazu, sprawdza typy placeholdera i kształtu, aktualizuje odpowiednią treść i zapisuje wynik. Przykład celowo unika przyjmowania indeksu kształtu lub traktowania każdego placeholdera jako tej samej klasy.

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Czym jest bazowy placeholder?**

Bazowy placeholder to odpowiadający mu kształt na układzie lub masterze, z którego inny placeholder dziedziczy. Użyj [Shape::getBasePlaceholder](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getbaseplaceholder/), aby go pobrać. Zwykły lokalny kształt zwraca `null`, ponieważ nie jest częścią hierarchii placeholderów.

**Czy mogę zmienić wszystkie tytuły slajdów, edytując placeholder w układzie?**

Możesz zmienić dziedziczone formatowanie lub tekst podpowiedzi poprzez układ, ale istniejąca treść tytułu jest przechowywana na normalnych slajdach. Aby zastąpić rzeczywisty tekst tytułu w całej prezentacji, iteruj po slajdach i zaktualizuj każdy placeholder tytułu.

**Jak zarządzać placeholderami daty, numeru slajdu, nagłówka i stopki?**

Użyj menedżerów nagłówka i stopki w odpowiednim zakresie: slajd, układ, master, notatki lub materiały rozdawnicze. Zobacz [Manage Presentation Header and Footer](/slides/pl/php-java/presentation-header-and-footer/) po pełne przykłady.