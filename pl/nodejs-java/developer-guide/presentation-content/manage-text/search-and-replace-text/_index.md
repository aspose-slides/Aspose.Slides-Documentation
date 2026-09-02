---
title: Wyszukiwanie i zamiana tekstu w prezentacjach PowerPoint w JavaScript
linktitle: Wyszukiwanie i zamiana tekstu
type: docs
weight: 55
url: /pl/nodejs-java/search-and-replace-text/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Wyszukuj, podświetlaj i zamieniaj tekst w prezentacjach PowerPoint, jednocześnie zbierając każde dopasowanie przy użyciu Aspose.Slides dla Node.js via Java."
---
## **Przegląd**

Aspose.Slides for Node.js via Java może wyszukiwać, podświetlać i zamieniać tekst w pojedynczej ramce tekstowej lub w całej prezentacji. Każda operacja może również powiadomić aplikację o każdym dopasowaniu za pośrednictwem zwrotnego wywołania wyników. Umożliwia to aktualizację prezentacji i jednoczesne tworzenie ścieżki audytu zawierającej dopasowany tekst, jego kontekst, pozycję, ramkę tekstową oraz numer slajdu.

Te możliwości są przydatne przy przeglądzie, redagowaniu, weryfikacji terminologii, czyszczeniu szablonów oraz zautomatyzowanych przepływach pracy raportowania.

W pierwszych przykładach poniżej używamy pliku o nazwie "sample.pptx", który zawiera pojedyncze pole tekstowe na pierwszym slajdzie z następującym tekstem:

![Przykładowy tekst](sample_text.png)

## **Wybierz zakres wyszukiwania**

Użyj metod na [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/)…, aby ograniczyć operację do jednej ramki tekstowej. Użyj metod na [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/)…, aby przetworzyć cały odpowiedni tekst w prezentacji.

| Operacja | Jedna ramka tekstowa | Cała prezentacja |
|---|---|---|
| Podświetl tekst dosłowny | [TextFrame.highlightText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Podświetl dopasowania wyrażeń regularnych | [TextFrame.highlightRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Zamień tekst dosłowny | [TextFrame.replaceText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Zamień dopasowania wyrażeń regularnych | [TextFrame.replaceRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Skonfiguruj dopasowywanie tekstu**

Do operacji na tekście dosłownym użyj [TextSearchOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textsearchoptions/), aby kontrolować dopasowanie:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) ogranicza dopasowania do pełnych słów.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) kontroluje, czy musi być zachowana wielkość liter.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) uwzględnia notatki slajdów w operacjach wyszukiwania, zamiany i podświetlania na poziomie prezentacji.

Operacje z wyrażeniami regularnymi używają klasy Java `Pattern`, więc reguły dopasowania, takie jak rozróżnianie wielkości liter i granice wyrazów, są definiowane przez wyrażenie i jego flagi.

## **Zidentyfikuj właściciela ramki tekstowej**

Ogólne przepływy przetwarzania tekstu często otrzymują [TextFrame] podczas wyszukiwania, zamiany, walidacji lub eksportu tekstu. Użyj [TextFrame.getParentShape] i [TextFrame.getParentCell], aby określić, który obiekt prezentacji jest właścicielem ramki tekstowej.

Oczekiwane wartości zależą od właściciela:

| Właściciel ramki tekstowej | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape lub inny kształt zawierający tekst | Posiadający [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/) | `null` |
| Komórka tabeli | `null` | Posiadający [Cell](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/cell/) |

Obie metody zapewniają nawigację tylko do odczytu. Wywołanie ich nie przenosi ramki tekstowej ani nie zmienia jej właściciela. Kod generyczny powinien sprawdzać oba wartości pod kątem `null` i obsługiwać możliwość, że żaden właściciel nie jest dostępny.

Poniższy przykład używa [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-), aby przejść po wszystkich ramkach tekstowych w prezentacji. Dla kształtów raportuje nazwę kształtu, typ w czasie wykonywania Java oraz slajd, na którym się znajduje. Dla komórek tabeli raportuje współrzędne kolumny i wiersza (licząc od zera) oraz slajd, w którym komórka się znajduje.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideLabel(baseSlide) {
    if (java.instanceOf(baseSlide, "com.aspose.slides.Slide")) {
        return "slide " + baseSlide.getSlideNumber();
    }

    if (java.instanceOf(baseSlide, "com.aspose.slides.NotesSlide")) {
        return "notes for slide " + baseSlide.getParentSlide().getSlideNumber();
    }

    return baseSlide.getClass().getSimpleName();
}

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, false);

    for (let index = 0; index < textFrames.length; index++) {
        const textFrame = textFrames[index];
        const ownerShape = textFrame.getParentShape();
        if (ownerShape !== null) {
            const shapeName = ownerShape.getName() === "" ? "(unnamed)" : ownerShape.getName();
            const shapeType = ownerShape.getClass().getSimpleName();
            const slideLabel = getSlideLabel(ownerShape.getSlide());
            console.log("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        const ownerCell = textFrame.getParentCell();
        if (ownerCell !== null) {
            const slideLabel = getSlideLabel(ownerCell.getSlide());
            console.log("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        console.log("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

Dla zawartości SmartArt iteruj po kształtach w [SmartArtNode.getShapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/smartartnode/#getShapes--) i uzyskaj dostęp do każdego [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/smartartshape/#getTextFrame--). Ramka tekstowa może być powiązana z jej powiązanym kształtem za pomocą [TextFrame.getParentShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#getParentShape--), podczas gdy [TextFrame.getParentCell](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#getParentCell--) zwraca `null`. Dlatego gałąź kształtów w przykładzie obsługuje również tekst z węzłów SmartArt.

## **Zbierz informacje o dopasowaniach przy użyciu wywołania zwrotnego**

Utwórz proxy w Javie dla wywołania zwrotnego wyniku, aby otrzymywać powiadomienie o każdym dopasowaniu. Funkcja proxy otrzymuje powiązaną ramkę tekstową, tekst źródłowy, dopasowany tekst oraz pozycję dopasowania.

Wywołanie zwrotne nie otrzymuje bezpośrednio numeru slajdu. Poniższa implementacja wyprowadza go poprzez kształt lub komórkę tabeli będącą właścicielem ramki tekstowej, używając [TextFrame.getSlide] jako awaryjnej opcji. Obsługuje również tekst znaleziony w notatkach slajdów.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

function createTextSearchCallback(results) {
    return java.newProxy("com.aspose.slides.IFindResultCallback", {
        foundResult: function(textFrame, sourceText, foundText, textPosition) {
            results.push({
                textFrame: textFrame,
                sourceText: sourceText,
                foundText: foundText,
                textPosition: textPosition,
                slideNumber: getSlideNumber(textFrame)
            });
        }
    });
}
```

Dla operacji zamiany `foundText` zawiera oryginalny dopasowany tekst, więc wywołanie zwrotne może dokładnie zarejestrować, które terminy zostały zamienione.

## **Podświetl tekst**

Użyj metody [TextFrame.highlightText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), aby podświetlić dopasowania tekstu dosłownego w ramce tekstowej. Przekaż [TextSearchOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textsearchoptions/), aby kontrolować wyszukiwanie.

Poniższy przykład podświetla wszystkie wystąpienia znaków **"try"**, a następnie podświetla wyłącznie całe słowo **"to"**.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const substringSearchOptions = new aspose.slides.TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    const substringHighlightColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    // Podświetl każde wystąpienie "try" w ramce tekstowej.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Podświetl tylko całe słowo "to".
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Podświetlony tekst](highlighted_text.png)

## **Podświetl tekst przy użyciu wyrażeń regularnych**

Metoda [TextFrame.highlightRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) podświetla dopasowania tekstu znalezione przez wyrażenie regularne w ramce tekstowej.

Poniższy kod podświetla wszystkie słowa zawierające siedem lub więcej znaków:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    shape.getTextFrame().highlightRegex(regex, highlightColor, null);

    presentation.save(
        "highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Podświetlony tekst przy użyciu wyrażenia regularnego](highlighted_text_using_regex.png)

## **Podświetl tekst w całej prezentacji**

Użyj [Presentation.highlightText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) i [Presentation.highlightRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) do przeszukania wszystkich odpowiednich ramek tekstowych w prezentacji. Poniższy przykład podświetla termin dosłowny oraz wszystkie adresy e‑mail:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);
    const termHighlightColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");

    presentation.highlightText(
        "confidential", termHighlightColor, searchOptions, null);

    const emailRegex = Pattern.compile(
        "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
        Pattern.CASE_INSENSITIVE);
    const emailHighlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightRegex(emailRegex, emailHighlightColor, null);
    presentation.save("highlighted_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zamień tekst w ramce tekstowej**

Użyj [TextFrame.replaceText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) dla tekstu dosłownego i [TextFrame.replaceRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) dla zamiany opartej na wzorcu. Metody te aktualizują dopasowany tekst w istniejącej ramce, zachowując formatowanie otaczających fragmentów zamiast przebudowywać ramkę z czystego łańcucha.

Poniższy przykład ujednolica wariant ortograficzny, a następnie zamienia etykiety wersji:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText(
        "colour", "color", searchOptions, null);

    const versionRegex = Pattern.compile(
        "\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", null);

    presentation.save("updated_text_frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jeśli jedno dopasowanie obejmuje fragmenty o różnym formatowaniu, sprawdź wynik, aby potwierdzić, które formatowanie powinno zostać zastosowane do tekstu zamienionego.

## **Zamień tekst w całej prezentacji**

Użyj [Presentation.replaceText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) i [Presentation.replaceRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) do zastosowania tych samych operacji w całej prezentacji. Jest to przydatne przy czyszczeniu szablonów, aktualizacjach terminologii i redagowaniu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText(
        "Contoso", "Example Corp", searchOptions, null);

    const accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", null);

    presentation.save("updated_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Grupuj dopasowania do raportowania**

Ponieważ każdy zebrany wynik przechowuje numer slajdu i ramkę tekstową, aplikacje mogą grupować dopasowania w celu audytu, raportowania lub przeglądu. Poniższy przykład grupuje wyniki najpierw według slajdu, a potem według ramki tekstowej:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

const results = [];
const callback = java.newProxy("com.aspose.slides.IFindResultCallback", {
    foundResult: function(textFrame, sourceText, foundText, textPosition) {
        results.push({
            textFrame: textFrame,
            sourceText: sourceText,
            foundText: foundText,
            textPosition: textPosition,
            slideNumber: getSlideNumber(textFrame)
        });
    }
});

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setCaseSensitive(false);
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightText(
        "confidential", highlightColor, searchOptions, callback);

    const matchesBySlide = new Map();

    for (const result of results) {
        const slideLabel = result.slideNumber === null ? "Other" : result.slideNumber;

        if (!matchesBySlide.has(slideLabel)) {
            matchesBySlide.set(slideLabel, new Map());
        }

        const matchesByTextFrame = matchesBySlide.get(slideLabel);
        if (!matchesByTextFrame.has(result.textFrame)) {
            matchesByTextFrame.set(result.textFrame, []);
        }

        matchesByTextFrame.get(result.textFrame).push(result);
    }

    for (const [slideLabel, matchesByTextFrame] of matchesBySlide) {
        console.log("Slide: " + slideLabel);

        for (const [textFrame, textFrameMatches] of matchesByTextFrame) {
            console.log("  Text frame: " + textFrame.getText());

            for (const result of textFrameMatches) {
                console.log(
                    "    '" + result.foundText + "' at position " +
                    result.textPosition + "; context: '" + result.sourceText + "'");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jak mogę przeszukać tylko jedną ramkę tekstową zamiast całej prezentacji?**

Uzyskaj ramkę tekstową kształtu i wywołaj [TextFrame.highlightText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), lub [TextFrame.replaceRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) na tej ramce. Metody na poziomie prezentacji przetwarzają wszystkie odpowiednie ramki tekstowe.

**Jak mogę dopasować pełne wyrazy z prawidłową wielkością liter?**

Ustaw [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) i [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) na `true` oraz przekaż opcje do metody podświetlania lub zamiany tekstu dosłownego. Dla wyrażeń regularnych określ granice wyrazów i rozróżnianie wielkości liter bezpośrednio w klasie Java `Pattern`.

**Czy wyszukiwanie i zamiana mogą obejmować tekst w notatkach slajdów?**

Tak. Ustaw [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) na `true` przy używaniu operacji na tekście dosłownym na poziomie prezentacji. Implementacja wywołania zwrotnego przedstawiona powyżej mapuje dopasowanie w notatce na numer slajdu nadrzędnego.

**Jak mogę stworzyć raport bez ponownego skanowania prezentacji?**

Przekaż proxy wywołania zwrotnego wyniku w Javie do operacji podświetlania lub zamiany. Wywołanie zwrotne otrzymuje każde dopasowanie w trakcie wykonywania operacji, dzięki czemu aplikacja może zapisać tekst źródłowy, dopasowany tekst, pozycję, ramkę tekstową oraz wyprowadzony numer slajdu do późniejszego grupowania lub eksportu.

**Czy zamiana tekstu zachowuje jego formatowanie?**

[TextFrame.replaceText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) i [TextFrame.replaceRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modyfikują dopasowany tekst w istniejącej ramce i zachowują formatowanie otaczających fragmentów. Jeśli dopasowanie obejmuje fragmenty o różnym formatowaniu, sprawdź wynik, aby upewnić się, że zamiana używa pożądanego stylu.