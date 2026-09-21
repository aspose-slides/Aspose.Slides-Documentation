---
title: Edycja dokumentów PDF w PHP
linktitle: Edycja PDF
type: docs
weight: 65
url: /pl/php-java/edit-pdf/
keywords:
- edytuj PDF
- zastąp tekst PDF
- PDF do PPTX
- PPTX do PDF
- PHP
- Aspose.Slides
description: "Edytuj dokumenty PDF w PHP, importując je do Aspose.Slides, zastępując tekst i zapisując zmodyfikowaną prezentację z powrotem do PDF."
---
## **Przegląd**

Aspose.Slides for PHP via Java umożliwia edycję treści PDF poprzez importowanie jego stron jako slajdów, modyfikowanie prezentacji i eksportowanie jej z powrotem do PDF. Ten artykuł pokazuje proste zastąpienie tekstu. Prezentacja pozostaje w pamięci, więc zapisanie pośredniego pliku PPTX jest opcjonalne.

## **Zastąpienie tekstu w pliku PDF**

Użyj [SlideCollection::addFromPdf](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/#addFromPdf), aby zaimportować strony, [Presentation::replaceText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#replaceText), aby zaktualizować tekst, oraz [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save), aby wyeksportować wynik.

Poniższy przykład zakłada, że `input.pdf` zawiera słowo „Draft” jako edytowalny tekst po imporcie. Zastępuje to słowo na „Final” i zapisuje `edited.pdf`. Wyczyść początkowy slajd przed importem, aby zapobiec dodatkowej pustej stronie w wyniku. Wyszukiwanie dopasowuje całe słowa z zachowaniem wielkości liter; `null` oznacza, że wywołanie zwrotne wyniku nie jest potrzebne.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

Aby uzyskać więcej opcji, zobacz [Wyszukiwanie i zamiana tekstu](/slides/pl/php-java/search-and-replace-text/) i [Konwertowanie PowerPoint na PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Zastąpienie tekstu działa na zaimportowanym tekście, a nie na tekście wewnątrz zeskanowanych obrazów. Konwersja może wpływać na układ i formatowanie, dlatego warto sprawdzić wynik, szczególnie gdy zamieniany tekst jest dłuższy niż oryginalny.
{{% /alert %}}

## **FAQ**

**Czy muszę zapisać plik PPTX przed eksportowaniem do PDF?**

Nie. Możesz edytować i wyeksportować tę samą prezentację w pamięci. Zapisz kopię PPTX tylko wtedy, gdy chcesz kontynuować jej edycję w PowerPoint; zobacz [Zapisz prezentacje](/slides/pl/php-java/save-presentation/).

**Dlaczego niektóre teksty mogą pozostać niezmienione?**

Przykład dopasowuje całe słowo „Draft” z dokładnym uwzględnieniem wielkości liter. Tekst zaimportowany jako obraz lub podzielony na osobne ramki tekstowe niekoniecznie zostanie dopasowany. Sprawdź zaimportowaną treść i dostosuj wyszukiwanie do swojego dokumentu.