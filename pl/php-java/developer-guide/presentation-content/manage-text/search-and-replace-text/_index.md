---
title: Wyszukiwanie i zamiana tekstu w prezentacjach PowerPoint w PHP
linktitle: Wyszukiwanie i zamiana tekstu
type: docs
weight: 55
url: /pl/php-java/search-and-replace-text/
keywords:
- wyszukiwanie tekstu
- podświetlanie tekstu
- zamiana tekstu
- wyrażenie regularne
- wywołanie zwrotne wyniku
- ramka tekstowa
- raport audytu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Wyszukuj, podświetlaj i zamieniaj tekst w prezentacjach PowerPoint, jednocześnie zbierając każde dopasowanie za pomocą Aspose.Slides for PHP via Java."
---
## **Przegląd**

Aspose.Slides for PHP via Java może wyszukiwać, podświetlać i zamieniać tekst w pojedynczej ramce tekstowej lub w całej prezentacji. Każda operacja może także powiadomić aplikację o każdym dopasowaniu za pomocą wywołania zwrotnego wyniku. Dzięki temu można zaktualizować prezentację i jednocześnie tworzyć ślad audytu zawierający dopasowany tekst, jego kontekst, pozycję, ramkę tekstową i numer slajdu.

Te możliwości są przydatne przy przeglądzie, redakcji, kontroli terminologii, czyszczeniu szablonów oraz automatycznych procesach raportowania.

W pierwszych przykładach używamy pliku o nazwie "sample.pptx", który zawiera jedną ramkę tekstową na pierwszym slajdzie z następującym tekstem:

![Sample text](sample_text.png)

## **Wybór zakresu wyszukiwania**

Użyj metod na [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) aby ograniczyć operację do jednej ramki tekstowej. Użyj metod na [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) aby przetworzyć cały tekst w prezentacji.

| Operacja | Jedna ramka tekstowa | Cała prezentacja |
|---|---|---|
| Podświetlanie dosłownego tekstu | [TextFrame::highlightText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#highlightText) |
| Podświetlanie dopasowań wyrażeniem regularnym | [TextFrame::highlightRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#highlightRegex) |
| Zamiana dosłownego tekstu | [TextFrame::replaceText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#replaceText) |
| Zamiana dopasowań wyrażeniem regularnym | [TextFrame::replaceRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#replaceRegex) |

## **Konfigurowanie dopasowywania tekstu**

Dla operacji na tekście dosłownym użyj [TextSearchOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textsearchoptions/) aby kontrolować dopasowanie:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) ogranicza dopasowania do pełnych słów.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) określa, czy musi być zachowana wielkość znaków.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) uwzględnia notatki slajdów w operacjach wyszukiwania, zamiany i podświetlania na poziomie prezentacji.

Operacje przy użyciu wyrażeń regularnych korzystają z klasy Java `Pattern`, więc reguły dopasowania takie jak wrażliwość na wielkość znaków i granice słów są definiowane w wyrażeniu i jego flagach.

## **Zbieranie informacji o dopasowaniach przy pomocy wywołania zwrotnego**

Przekaż proxy wywołania zwrotnego Java do metody podświetlania lub zamiany, aby otrzymać powiadomienie o każdym dopasowaniu. Metoda wywołania zwrotnego otrzymuje powiązaną ramkę tekstową, źródłowy tekst, dopasowany tekst oraz pozycję dopasowania.

Wywołanie zwrotne nie otrzymuje numeru slajdu bezpośrednio. Implementacja poniżej wyprowadza go z rodzica slajdu i obsługuje również tekst znaleziony w notatkach slajdu. Tablica wyników używa `null`, gdy tekst jest powiązany z innym typem slajdu.

```php
class TextSearchCallback {
    private $results = [];

    public function getResults() {
        return $this->results;
    }

    public function foundResult($textFrame, $sourceText, $foundText, $textPosition) {
        $slideNumber = $this->getSlideNumber($textFrame);
        $this->results[] = [
            "textFrame" => $textFrame,
            "sourceText" => java_values($sourceText),
            "foundText" => java_values($foundText),
            "textPosition" => java_values($textPosition),
            "slideNumber" => $slideNumber
        ];
    }

    private function getSlideNumber($textFrame) {
        $parentSlide = $textFrame->getSlide();
        if (java_is_null($parentSlide)) {
            return null;
        }

        $parentSlideClass = $parentSlide->getClass();
        $classNameValue = $parentSlideClass->getName();
        $className = java_values($classNameValue);

        if ($className === "com.aspose.slides.Slide") {
            $slideNumber = $parentSlide->getSlideNumber();
            return java_values($slideNumber);
        }

        if ($className === "com.aspose.slides.NotesSlide") {
            $slide = $parentSlide->getParentSlide();
            $slideNumber = $slide->getSlideNumber();
            return java_values($slideNumber);
        }

        return null;
    }
}
```

Utwórz proxy dla tego obiektu PHP przed przekazaniem go do operacji:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

W operacjach zamiany `foundText` zawiera oryginalny dopasowany tekst, więc wywołanie zwrotne może dokładnie zarejestrować, które wyrażenia zostały zamienione.

## **Podświetlanie tekstu**

Użyj metody [TextFrame::highlightText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#highlightText), aby podświetlić dosłowne dopasowania tekstu w ramce tekstowej. Przekaż [TextSearchOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textsearchoptions/) aby kontrolować wyszukiwanie.

Przykład kodu poniżej podświetla wszystkie wystąpienia ciągu **"try"**, a następnie podświetla tylko całe słowo **"to"**.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $callbackHandler = new TextSearchCallback();
    $callbackInterface = java("com.aspose.slides.IFindResultCallback");
    $callback = java_closure(
        $callbackHandler,
        null,
        $callbackInterface
    );

    $substringSearchOptions = new TextSearchOptions();
    $substringSearchOptions->setCaseSensitive(false);
    $substringHighlightColor = new Java("java.awt.Color", 173, 216, 230);

    // Podświetl każde wystąpienie "try" w ramce tekstowej.
    $shape->getTextFrame()->highlightText(
        "try",
        $substringHighlightColor,
        $substringSearchOptions,
        $callback
    );

    $wholeWordSearchOptions = new TextSearchOptions();
    $wholeWordSearchOptions->setWholeWordsOnly(true);
    $wholeWordSearchOptions->setCaseSensitive(false);
    $wholeWordHighlightColor = new Java("java.awt.Color", 238, 130, 238);

    // Podświetl tylko całe słowo "to".
    $shape->getTextFrame()->highlightText(
        "to",
        $wholeWordHighlightColor,
        $wholeWordSearchOptions,
        $callback
    );

    foreach ($callbackHandler->getResults() as $result) {
        echo(
            "Found '" . $result["foundText"] . "' at position " .
            $result["textPosition"] . " on slide " .
            $result["slideNumber"] . ".\n"
        );
    }

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Wynik:

![The highlighted text](highlighted_text.png)

## **Podświetlanie tekstu przy użyciu wyrażeń regularnych**

Metoda [TextFrame::highlightRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#highlightRegex) podświetla dopasowania znalezione przez wyrażenie regularne w ramce tekstowej.

Poniższy kod podświetla wszystkie słowa zawierające siedem lub więcej znaków:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $regex = java("java.util.regex.Pattern")->compile("\\b[^\\s]{7,}\\b");
    $highlightColor = java("java.awt.Color")->YELLOW;

    $shape->getTextFrame()->highlightRegex($regex, $highlightColor, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Wynik:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Podświetlanie tekstu w całej prezentacji**

Użyj [Presentation::highlightText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#highlightText) oraz [Presentation::highlightRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#highlightRegex), aby przeszukać wszystkie odpowiednie ramki tekstowe w prezentacji. Poniższy przykład podświetla dosłowne wyrażenie oraz wszystkie adresy e‑mail:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);
    $termHighlightColor = java("java.awt.Color")->ORANGE;

    $presentation->highlightText(
        "confidential",
        $termHighlightColor,
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $emailPattern = "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b";
    $emailRegex = $patternClass->compile(
        $emailPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $emailHighlightColor = java("java.awt.Color")->YELLOW;

    $presentation->highlightRegex($emailRegex, $emailHighlightColor, null);
    $presentation->save("highlighted_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Zamiana tekstu w ramce tekstowej**

Użyj [TextFrame::replaceText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#replaceText) dla tekstu dosłownego i [TextFrame::replaceRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#replaceRegex) dla zamiany opartej na wzorcu. Metody te aktualizują dopasowany tekst wewnątrz istniejącej ramki, zachowując formatowanie otaczających fragmentów zamiast odtwarzać ramkę z czystego ciągu znaków.

Poniższy przykład ujednolica wariant pisowni, a następnie zamienia etykiety wersji:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);

    $shape->getTextFrame()->replaceText(
        "colour",
        "color",
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $versionPattern = "\\bv\\d+(?:\\.\\d+)*\\b";
    $versionRegex = $patternClass->compile(
        $versionPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $shape->getTextFrame()->replaceRegex(
        $versionRegex,
        "current version",
        null
    );

    $presentation->save("updated_text_frame.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Jeśli jedno dopasowanie obejmuje fragmenty o różnym formatowaniu, sprawdź wynik, aby potwierdzić, które formatowanie powinno zostać zastosowane do tekstu zamiany.

## **Zamiana tekstu w całej prezentacji**

Użyj [Presentation::replaceText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#replaceText) i [Presentation::replaceRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#replaceRegex), aby zastosować te same operacje w całej prezentacji. Jest to przydatne przy czyszczeniu szablonów, aktualizacji terminologii i redakcji.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);

    $presentation->replaceText(
        "Contoso",
        "Example Corp",
        $searchOptions,
        null
    );

    $accountNumberRegex = java("java.util.regex.Pattern")->compile(
        "\\bACCT-\\d{6}\\b"
    );
    $presentation->replaceRegex(
        $accountNumberRegex,
        "ACCT-REDACTED",
        null
    );

    $presentation->save("updated_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Grupowanie dopasowań do raportowania**

Ponieważ każdy wynik przechowuje numer slajdu i ramkę tekstową, aplikacje mogą grupować dopasowania w celu audytu, raportowania lub przeglądu. Poniższy przykład grupuje zebrane wyniki najpierw według slajdu, a potem według ramki tekstowej:

```php
$matchesBySlide = [];
$systemClass = java("java.lang.System");

foreach ($callbackHandler->getResults() as $result) {
    $slideNumber = $result["slideNumber"];
    $slideLabel = $slideNumber === null ? "Other" : (string) $slideNumber;
    $textFrame = $result["textFrame"];
    $textFrameHash = $systemClass->identityHashCode($textFrame);
    $textFrameKey = (string) java_values($textFrameHash);

    if (!isset($matchesBySlide[$slideLabel])) {
        $matchesBySlide[$slideLabel] = [];
    }

    if (!isset($matchesBySlide[$slideLabel][$textFrameKey])) {
        $matchesBySlide[$slideLabel][$textFrameKey] = [
            "textFrame" => $textFrame,
            "matches" => []
        ];
    }

    $matchesBySlide[$slideLabel][$textFrameKey]["matches"][] = $result;
}

foreach ($matchesBySlide as $slideLabel => $textFrameGroups) {
    echo("Slide: " . $slideLabel . "\n");

    foreach ($textFrameGroups as $textFrameGroup) {
        $textFrame = $textFrameGroup["textFrame"];
        echo("  Text frame: " . $textFrame->getText() . "\n");

        foreach ($textFrameGroup["matches"] as $result) {
            echo(
                "    '" . $result["foundText"] . "' at position " .
                $result["textPosition"] . "; context: '" .
                $result["sourceText"] . "'\n"
            );
        }
    }
}
```

## **FAQ**

**Jak mogę przeszukać tylko jedną ramkę tekstową zamiast całej prezentacji?**

Pobierz ramkę tekstową kształtu i wywołaj [TextFrame::highlightText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#replaceText) lub [TextFrame::replaceRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#replaceRegex) na tej ramce. Metody na poziomie prezentacji przetwarzają wszystkie odpowiednie ramki tekstowe.

**Jak dopasować pełne słowa z zachowaniem prawidłowej wielkości liter?**

Ustaw [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) i [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) na `true` i przekaż opcje do metody podświetlania lub zamiany tekstu dosłownego. Dla wyrażeń regularnych określ granice słów i wrażliwość na wielkość liter bezpośrednio w klasie Java `Pattern`.

**Czy wyszukiwanie i zamiana mogą obejmować tekst w notatkach slajdu?**

Tak. Ustaw [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) na `true` przy używaniu operacji dosłownego tekstu na poziomie prezentacji.

**Jak stworzyć raport bez ponownego skanowania prezentacji?**

Przekaż wywołanie zwrotne proxy Java do operacji podświetlania lub zamiany. Otrzyma ono każde dopasowanie w trakcie wykonywania operacji, dzięki czemu aplikacja może zapisać źródłowy tekst, dopasowany tekst, pozycję, ramkę tekstową oraz wyprowadzony numer slajdu do późniejszego grupowania lub eksportu.

**Czy zamiana tekstu zachowuje jego formatowanie?**

[TextFrame::replaceText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#replaceText) i [TextFrame::replaceRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#replaceRegex) modyfikują dopasowany tekst wewnątrz istniejącej ramki i zachowują formatowanie otaczających fragmentów. Jeśli dopasowanie obejmuje fragmenty o różnym formatowaniu, należy sprawdzić wynik, aby upewnić się, że zamiana używa pożądanego stylu.