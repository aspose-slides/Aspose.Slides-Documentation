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
description: "Wyszukuj, podświetlaj i zamieniaj tekst w prezentacjach PowerPoint, jednocześnie zbierając każde dopasowanie przy użyciu Aspose.Slides for PHP via Java."
---
## **Przegląd**

Aspose.Slides for PHP via Java może wyszukiwać, podświetlać i zamieniać tekst w pojedynczej ramce tekstowej lub w całej prezentacji. Każda operacja może także powiadamiać aplikację o każdym dopasowaniu za pomocą wywołania zwrotnego. Dzięki temu można aktualizować prezentację i jednocześnie tworzyć ścieżkę audytu zawierającą dopasowany tekst, jego kontekst, pozycję, ramkę tekstową oraz numer slajdu.

Narzędzia te są przydatne przy przeglądzie, redakcji, weryfikacji terminologii, czyszczeniu szablonów oraz zautomatyzowanych procesach raportowania.

W pierwszych przykładach poniżej używamy pliku o nazwie "sample.pptx", który zawiera pojedyncze pole tekstowe na pierwszym slajdzie z następującym tekstem:

![Przykładowy tekst](sample_text.png)

## **Wybierz zakres wyszukiwania**

Użyj metod z klasy [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) aby ograniczyć operację do jednej ramki tekstowej. Użyj metod z klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) aby przetworzyć cały odpowiedni tekst w prezentacji.

| Operacja | Jedna ramka tekstowa | Cała prezentacja |
|---|---|---|
| Podświetl tekst dosłowny | [TextFrame::highlightText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#highlightText) |
| Podświetl dopasowania wyrażenia regularnego | [TextFrame::highlightRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#highlightRegex) |
| Zamień tekst dosłowny | [TextFrame::replaceText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#replaceText) |
| Zamień dopasowania wyrażenia regularnego | [TextFrame::replaceRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#replaceRegex) |

## **Skonfiguruj dopasowywanie tekstu**

Dla operacji na tekście dosłownym użyj [TextSearchOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textsearchoptions/) aby kontrolować dopasowanie:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) ogranicza dopasowania do pełnych słów.  
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) kontroluje, czy wielkość znaków musi się zgadzać.  
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) uwzględnia notatki slajdów w wyszukiwaniu, zamianie i podświetlaniu na poziomie prezentacji.

Operacje z wyrażeniami regularnymi używają obiektu Java `Pattern`, więc reguły dopasowania takie jak rozróżnianie wielkości znaków i granice słów są definiowane w wyrażeniu i jego flagach.

## **Zidentyfikuj właściciela ramki tekstowej**

Typowe przepływy przetwarzania tekstu często otrzymują obiekt [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) podczas wyszukiwania, zamiany, walidacji lub eksportu tekstu. Użyj [TextFrame::getParentShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#getParentShape) i [TextFrame::getParentCell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#getParentCell), aby określić, który obiekt prezentacji jest właścicielem ramki tekstowej.

Oczekiwane wartości zależą od właściciela:

| Właściciel ramki tekstowej | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape lub inny kształt zawierający tekst | Właścielski [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/) | `null` |
| Komórka tabeli | `null` | Właścielski [Cell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cell/) |

Obie metody zapewniają nawigację tylko do odczytu. Wywołanie ich nie przenosi ramki tekstowej ani nie zmienia jej właściciela. Kod ogólny powinien sprawdzać obie wartości przy pomocy `java_is_null` i obsługiwać możliwość, że żaden właściciel nie jest dostępny.

Poniższy przykład używa [SlideUtil::getAllTextFrames](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideutil/#getAllTextFrames) do iteracji po ramach tekstowych w prezentacji. Dla kształtów wypisuje nazwę kształtu, typ Java oraz slajd, na którym się znajduje. Dla komórek tabeli wypisuje współrzędne kolumny i wiersza (liczone od zera) oraz slajd.

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$presentation = new Presentation("presentation.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $textFrames = SlideUtil::getAllTextFrames($presentation, false);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        $textFrame = $textFrames[$textFrameIndex];
        $ownerShape = $textFrame->getParentShape();
        if (!java_is_null($ownerShape)) {
            $shapeName = java_values($ownerShape->getName());
            $shapeName = $shapeName === "" ? "(unnamed)" : $shapeName;
            $shapeType = java_values($ownerShape->getClass()->getSimpleName());
            $baseSlide = $ownerShape->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Shape: " . $shapeName . "; type: " . $shapeType . "; " . $slideLabel . "\n");
            continue;
        }

        $ownerCell = $textFrame->getParentCell();
        if (!java_is_null($ownerCell)) {
            $baseSlide = $ownerCell->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Table cell: column " . java_values($ownerCell->getFirstColumnIndex()) . ", row " . java_values($ownerCell->getFirstRowIndex()) . "; " . $slideLabel . "\n");
            continue;
        }

        echo("The text frame owner is not available as a shape or table cell.\n");
    }
} finally {
    $presentation->dispose();
}
```

Dla treści SmartArt iteruj po kształtach zwróconych przez [SmartArtNode::getShapes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartartnode/#getShapes) i uzyskaj każdą [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartartshape/#getTextFrame). Ramka tekstowa może być powiązana z odpowiednim kształtem za pomocą [TextFrame::getParentShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#getParentShape), natomiast [TextFrame::getParentCell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#getParentCell) zwraca `null`. Dlatego gałąź dotycząca kształtów w przykładzie obsługuje również tekst z węzłów SmartArt.

## **Zbierz informacje o dopasowaniach przy użyciu wywołania zwrotnego**

Przekaż wywołanie zwrotne proxy Java do metody podświetlającej lub zamieniającej, aby otrzymać powiadomienie o każdym dopasowaniu. Metoda wywołania zwrotnego otrzymuje powiązaną ramkę tekstową, tekst źródłowy, dopasowany tekst oraz pozycję dopasowania.

Wywołanie zwrotne nie otrzymuje numeru slajdu bezpośrednio. Implementacja poniżej wyprowadza go z rodzica slajdu i obsługuje także tekst znaleziony w notatkach slajdów. Tablica wynikowa używa `null`, gdy tekst jest powiązany z innym typem slajdu.

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
        $parentShape = $textFrame->getParentShape();
        $parentCell = $textFrame->getParentCell();

        if (!java_is_null($parentShape)) {
            $parentSlide = $parentShape->getSlide();
        } elseif (!java_is_null($parentCell)) {
            $parentSlide = $parentCell->getSlide();
        } else {
            $parentSlide = $textFrame->getSlide();
        }

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

Dla operacji zamiany `foundText` zawiera pierwotny dopasowany tekst, więc wywołanie zwrotne może dokładnie zapisać, które terminy zostały zamienione.

## **Podświetl tekst**

Użyj metody [TextFrame::highlightText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#highlightText), aby podświetlić dopasowania tekstu dosłownego w ramce tekstowej. Przekaż [TextSearchOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textsearchoptions/), aby kontrolować wyszukiwanie.

Poniższy przykład podświetla wszystkie wystąpienia znaków **"try"**, a następnie podświetla tylko pełne słowo **"to"**.

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

    // Podświetl tylko pełne słowo "to".
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

![Podświetlony tekst](highlighted_text.png)

## **Podświetl tekst przy użyciu wyrażeń regularnych**

Metoda [TextFrame::highlightRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#highlightRegex) podświetla dopasowania tekstu znalezione przy pomocy wyrażenia regularnego w ramce tekstowej.

Poniższy kod podświetla wszystkie słowa zawierające co najmniej siedem znaków:

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

![Podświetlony tekst przy użyciu wyrażenia regularnego](highlighted_text_using_regex.png)

## **Podświetl tekst w całej prezentacji**

Użyj metod [Presentation::highlightText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#highlightText) i [Presentation::highlightRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#highlightRegex), aby przeszukać wszystkie odpowiednie ramki tekstowe w prezentacji. Poniższy przykład podświetla dosłowne wyrażenie oraz wszystkie adresy e‑mail:

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

## **Zamień tekst w ramce tekstowej**

Użyj [TextFrame::replaceText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#replaceText) dla tekstu dosłownego i [TextFrame::replaceRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#replaceRegex) dla zamiany opartej na wzorcu. Metody te aktualizują dopasowany tekst wewnątrz istniejącej ramki, zachowując formatowanie otaczających fragmentów zamiast przebudowywać ramkę z czystego łańcucha.

Poniższy przykład standaryzuje wariant pisowni, a następnie zamienia etykiety wersji:

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

## **Zamień tekst w całej prezentacji**

Użyj metod [Presentation::replaceText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#replaceText) i [Presentation::replaceRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#replaceRegex), aby zastosować te same operacje w całej prezentacji. Jest to przydatne przy czyszczeniu szablonów, aktualizacji terminologii i redakcji.

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

## **Grupuj dopasowania w raportach**

Ponieważ każdy wynik przechowuje numer slajdu i ramkę tekstową, aplikacje mogą grupować dopasowania w celach audytu, raportowania lub przeglądu. Poniższy przykład grupuje zebrane wyniki najpierw według slajdu, a potem według ramki tekstowej:

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

Uzyskaj ramkę tekstową kształtu i wywołaj [TextFrame::highlightText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#replaceText) lub [TextFrame::replaceRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#replaceRegex) na tej ramce. Metody na poziomie prezentacji przetwarzają wszystkie odpowiednie ramki tekstowe zamiast tego.

**Jak dopasować pełne słowa z zachowaniem prawidłowej wielkości liter?**

Ustaw [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) i [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) na `true` i przekaż opcje do metody podświetlającej lub zamieniającej tekst dosłowny. W przypadku wyrażeń regularnych określ granice słów i rozróżnianie wielkości znaków bezpośrednio w obiekcie Java `Pattern`.

**Czy wyszukiwanie i zamiana mogą obejmować tekst w notatkach slajdów?**

Tak. Ustaw [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) na `true` przy używaniu operacji na poziomie prezentacji dotyczącej tekstu dosłownego.

**Jak stworzyć raport bez ponownego skanowania prezentacji?**

Przekaż wywołanie zwrotne proxy Java do operacji podświetlania lub zamiany. Otrzymuje ono każde dopasowanie w trakcie działania operacji, dzięki czemu aplikacja może zapisać tekst źródłowy, dopasowany tekst, pozycję, ramkę tekstową oraz wyliczony numer slajdu do późniejszego grupowania lub eksportu.

**Czy zamiana tekstu zachowuje jego formatowanie?**

[TextFrame::replaceText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#replaceText) i [TextFrame::replaceRegex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#replaceRegex) modyfikują dopasowany tekst wewnątrz istniejącej ramki i zachowują formatowanie otaczających fragmentów. Jeśli dopasowanie obejmuje fragmenty o różnym formatowaniu, należy sprawdzić wynik, aby upewnić się, że zamiana używa pożądanego stylu.