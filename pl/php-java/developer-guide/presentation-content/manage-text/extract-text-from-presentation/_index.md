---
title: Zaawansowane wyodrębnianie tekstu z prezentacji w PHP
linktitle: Wyodrębnij tekst
type: docs
weight: 90
url: /pl/php-java/extract-text-from-presentation/
keywords:
- wyodrębnić tekst
- wyodrębnić tekst ze slajdu
- wyodrębnić tekst z prezentacji
- wyodrębnić tekst z PowerPointa
- wyodrębnić tekst z OpenDocument
- wyodrębnić tekst z PPT
- wyodrębnić tekst z PPTX
- wyodrębnić tekst z ODP
- pobrać tekst
- pobrać tekst ze slajdu
- pobrać tekst z prezentacji
- pobrać tekst z PowerPointa
- pobrać tekst z OpenDocument
- pobrać tekst z PPT
- pobrać tekst z PPTX
- pobrać tekst z ODP
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Szybko wyodrębnij tekst z prezentacji PowerPoint i OpenDocument za pomocą Aspose.Slides for PHP via Java. Postępuj zgodnie z naszym prostym, krok po kroku przewodnikiem, aby zaoszczędzić czas."
---
## **Przegląd**

Wyodrębnianie tekstu z prezentacji jest powszechnym, a jednocześnie istotnym zadaniem dla programistów pracujących z zawartością slajdów. Niezależnie od tego, czy masz do czynienia z plikami Microsoft PowerPoint w formacie PPT lub PPTX, czy z prezentacjami OpenDocument (ODP), dostęp i pobieranie danych tekstowych może być kluczowe dla analizy, automatyzacji, indeksowania lub migracji treści.

Ten artykuł zawiera kompleksowy przewodnik, jak efektywnie wyodrębniać tekst z różnych formatów prezentacji, w tym PPT, PPTX i ODP, przy użyciu Aspose.Slides for PHP via Java. Dowiesz się, jak systematycznie iterować przez elementy prezentacji, aby dokładnie pobrać potrzebną treść tekstową.

## **Wyodrębnianie tekstu ze slajdu**

Aspose.Slides for PHP via Java udostępnia klasę [SlideUtil](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideutil/). Klasa ta udostępnia kilka przeciążonych metod statycznych do wyodrębniania całego tekstu z prezentacji lub slajdu. Aby wyodrębnić tekst ze slajdu w prezentacji, użyj metody [getAllTextBoxes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideutil/#getAllTextBoxes). Metoda ta przyjmuje obiekt typu [BaseSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslide/) jako parametr. Po wykonaniu metoda skanuje cały slajd w poszukiwaniu tekstu i zwraca tablicę obiektów typu [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/), zachowując formatowanie tekstu.

Poniższy fragment kodu wyodrębnia cały tekst z pierwszego slajdu prezentacji:

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Wyodrębnianie tekstu z prezentacji**

Aby przeszukać tekst w całej prezentacji, użyj statycznej metody [getAllTextFrames](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideutil/#getAllTextFrames) udostępnionej przez klasę [SlideUtil](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideutil/). Metoda przyjmuje dwa parametry:

1. Najpierw obiekt [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/), reprezentujący prezentację PowerPoint lub OpenDocument, z której zostanie wyodrębniony tekst.  
2. Następnie wartość `boolean` wskazującą, czy slajdy nadrzędne (master) powinny być uwzględnione przy skanowaniu tekstu w prezentacji.

Metoda zwraca tablicę obiektów typu [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/), zawierającą informacje o formatowaniu tekstu. Poniższy kod skanuje tekst i szczegóły formatowania z prezentacji, włączając slajdy nadrzędne.

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Kategoryzowane i szybkie wyodrębnianie tekstu**

Klasa [PresentationFactory](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationfactory/) również udostępnia metody do wyodrębniania całego tekstu z prezentacji:

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

Argument wyliczenia [TextExtractionArrangingMode](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textextractionarrangingmode/) wskazuje tryb organizacji wyniku wyodrębniania tekstu i może przyjąć następujące wartości:
- `Unarranged` – surowy tekst bez uwzględnienia jego pozycji na slajdzie.  
- `Arranged` – tekst ułożony w takiej samej kolejności, jak na slajdzie.

Tryb nieuporządkowany (`Unarranged`) może być używany, gdy kluczowa jest szybkość; jest szybszy niż tryb uporządkowany (`Arranged`).

[PresentationText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationtext/) reprezentuje surowy tekst wyodrębniony z prezentacji. Jego metoda `getSlidesText` zwraca tablicę obiektów, gdzie każdy obiekt reprezentuje tekst na odpowiednim slajdzie. Każdy zwrócony obiekt posiada następujące metody:

- `getText` – tekst w kształtach slajdu.  
- `getMasterText` – tekst w kształtach slajdu nadrzędnego (master) powiązanym z tym slajdem.  
- `getLayoutText` – tekst w kształtach slajdu układu (layout) powiązanym z tym slajdem.  
- `getNotesText` – tekst w kształtach notatek slajdu powiązanych z tym slajdem.  
- `getCommentsText` – tekst w komentarzach powiązanych z tym slajdem.

```php
$presentationPath = "presentation.ppt";
$arrangingMode = TextExtractionArrangingMode::Unarranged;
$presentationText = PresentationFactory::getInstance()->getPresentationText($presentationPath, $arrangingMode);
$slidesText = $presentationText->getSlidesText();
$firstSlideText = $slidesText[0];

echo($firstSlideText->getText());
echo($firstSlideText->getLayoutText());
echo($firstSlideText->getMasterText());
echo($firstSlideText->getNotesText());
echo($firstSlideText->getCommentsText());
```

## **FAQ**

**Jak szybko Aspose.Slides przetwarza duże prezentacje podczas wyodrębniania tekstu?**

Aspose.Slides jest zoptymalizowane pod kątem wysokiej wydajności i może przetwarzać nawet [duże prezentacje](/slides/pl/php-java/open-presentation/), co czyni je odpowiednim do scenariuszy przetwarzania w czasie rzeczywistym lub masowego.

**Czy Aspose.Slides może wyodrębniać tekst z tabel i wykresów w prezentacjach?**

Tak. Aspose.Slides może wyodrębniać tekst z wielu elementów slajdu, w tym z tabel i obiektów związanych z wykresami, co pozwala na dostęp i analizę treści tekstowej w typowych strukturach prezentacji.

**Czy potrzebuję specjalnej licencji Aspose.Slides, aby wyodrębnić tekst z prezentacji?**

Możesz wyodrębniać tekst przy użyciu bezpłatnej wersji próbnej Aspose.Slides, choć będzie ona mieć [pewne ograniczenia](/slides/pl/php-java/licensing/), takie jak przetwarzanie tylko ograniczonej liczby slajdów. Dla nieograniczonego użycia i obsługi większych prezentacji zaleca się zakup pełnej licencji.