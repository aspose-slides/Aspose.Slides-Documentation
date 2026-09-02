---
title: Wyszukiwanie i zamiana tekstu w prezentacjach PowerPoint w JavaScript
linktitle: Wyszukiwanie i zamiana tekstu
type: docs
weight: 55
url: /pl/nodejs-java/search-and-replace-text/
keywords:
- wyszukiwanie tekstu
- podświetlanie tekstu
- zastępowanie tekstu
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

Aspose.Slides for Node.js via Java może wyszukiwać, podświetlać i zastępować tekst w pojedynczej ramce tekstowej lub w całej prezentacji. Każda operacja może także powiadomić aplikację o każdym dopasowaniu za pomocą wywołania zwrotnego wyniku. Dzięki temu można aktualizować prezentację i jednocześnie budować ścieżkę audytu zawierającą dopasowany tekst, jego kontekst, pozycję, ramkę tekstową oraz numer slajdu.

Te możliwości są przydatne przy przeglądzie, redagowaniu, sprawdzaniu terminologii, czyszczeniu szablonów oraz automatyzacji raportowania.

W poniższych pierwszych przykładach używamy pliku o nazwie „sample.pptx”, który zawiera jedną ramkę tekstową na pierwszym slajdzie z następującym tekstem:

![Przykładowy tekst](sample_text.png)

## **Wybierz zakres wyszukiwania**

Użyj metod na [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/), aby ograniczyć operację do jednej ramki tekstowej. Użyj metod na [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/), aby przetworzyć cały tekst w prezentacji.

| Operacja | Jedna ramka tekstowa | Cała prezentacja |
|---|---|---|
| Podświetl dosłowny tekst | [TextFrame.highlightText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Podświetl dopasowania wyrażenia regularnego | [TextFrame.highlightRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Zastąp dosłowny tekst | [TextFrame.replaceText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Zastąp dopasowania wyrażenia regularnego | [TextFrame.replaceRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Skonfiguruj dopasowanie tekstu**

Dla operacji na tekście dosłownym użyj [TextSearchOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textsearchoptions/), aby kontrolować dopasowanie:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) ogranicza dopasowania do pełnych słów.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) kontroluje, czy wielkość znaków musi się zgadzać.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) uwzględnia notatki slajdów w operacjach wyszukiwania, zamiany i podświetlania na poziomie prezentacji.

Operacje wyrażeń regularnych używają klasy Java `Pattern`, więc reguły dopasowania, takie jak wrażliwość na wielkość liter i granice słów, są definiowane w wyrażeniu i jego flagach.

## **Zbierz informacje o dopasowaniach przy użyciu wywołania zwrotnego**

Utwórz proxy Java dla wywołania zwrotnego wyniku, aby otrzymywać powiadomienie o każdym dopasowaniu. Funkcja proxy otrzymuje powiązaną ramkę tekstową, tekst źródłowy, dopasowany tekst oraz pozycję dopasowania.

Wywołanie zwrotne nie otrzymuje numeru slajdu bezpośrednio. Implementacja poniżej wyprowadza go poprzez [TextFrame.getSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#getSlide--), [Slide.getSlideNumber](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#getSlideNumber--), oraz [NotesSlide.getParentSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notesslide/#getParentSlide--). Obsługuje również tekst znaleziony w notatkach slajdu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

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

W operacjach zamiany `foundText` zawiera oryginalny dopasowany tekst, więc wywołanie zwrotne może dokładnie zapisać, które terminy zostały zastąpione.

## **Podświetl tekst**

Użyj metody [TextFrame.highlightText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), aby podświetlić dopasowania tekstu dosłownego w ramce tekstowej. Przekaż [TextSearchOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textsearchoptions/), aby kontrolować wyszukiwanie.

Poniższy kod podświetla wszystkie wystąpienia znaków **"try"**, a następnie podświetla tylko pełne słowo **"to"**.

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

    // Podświetl tylko pełne słowo "to".
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

Metoda [TextFrame.highlightRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) podświetla dopasowania tekstu znalezione przy pomocy wyrażenia regularnego w ramce tekstowej.

Poniższy kod podświetla wszystkie słowa zawierające co najmniej siedem znaków:

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

Użyj [Presentation.highlightText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) oraz [Presentation.highlightRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), aby przeszukać wszystkie odpowiednie ramki tekstowe w prezentacji. Poniższy przykład podświetla dosłowny termin oraz wszystkie adresy e‑mail:

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

## **Zastąp tekst w ramce tekstowej**

Użyj [TextFrame.replaceText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) dla tekstu dosłownego i [TextFrame.replaceRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) dla zamiany opartej na wzorcu. Te metody aktualizują dopasowany tekst w istniejącej ramce tekstowej, zachowując formatowanie otaczających fragmentów zamiast budować nową ramkę z czystego łańcucha.

Poniższy przykład standaryzuje wariant pisowni, a następnie zastępuje etykiety wersji:

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

Jeśli jedno dopasowanie obejmuje fragmenty o różnym formatowaniu, sprawdź wynik, aby potwierdzić, które formatowanie powinno zostać zastosowane do tekstu zastępczego.

## **Zastąp tekst w całej prezentacji**

Użyj [Presentation.replaceText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) i [Presentation.replaceRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-), aby zastosować te same operacje w całej prezentacji. Jest to przydatne przy czyszczeniu szablonów, aktualizacjach terminologii i redagowaniu.

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
    const parentSlide = textFrame.getSlide();

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

Pobierz ramkę tekstową kształtu i wywołaj [TextFrame.highlightText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), lub [TextFrame.replaceRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) na tej ramce. Metody na poziomie prezentacji przetwarzają wszystkie odpowiednie ramki tekstowe.

**Jak dopasować pełne słowa z uwzględnieniem wielkości liter?**

Ustaw [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) oraz [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) na `true` i przekaż opcje do metody podświetlania lub zamiany tekstu dosłownego. Dla wyrażeń regularnych zdefiniuj granice słów i wrażliwość na wielkość liter bezpośrednio w klasie Java `Pattern`.

**Czy wyszukiwanie i zamiana mogą obejmować tekst w notatkach slajdów?**

Tak. Ustaw [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) na `true` przy użyciu operacji tekstu dosłownego na poziomie prezentacji. Implementacja wywołania zwrotnego przedstawiona wyżej mapuje dopasowanie w notatce na numer slajdu nadrzędnego.

**Jak stworzyć raport bez ponownego skanowania prezentacji?**

Przekaż proxy wywołania zwrotnego wyniku Java do operacji podświetlania lub zamiany. Wywołanie zwrotne otrzymuje każde dopasowanie w trakcie trwania operacji, więc aplikacja może zapisać tekst źródłowy, dopasowany tekst, pozycję, ramkę tekstową oraz wyprowadzony numer slajdu do późniejszego grupowania lub eksportu.

**Czy zamiana tekstu zachowuje jego formatowanie?**

[TextFrame.replaceText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) i [TextFrame.replaceRegex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modyfikują dopasowany tekst w istniejącej ramce tekstowej i zachowują formatowanie otaczających fragmentów. Jeśli dopasowanie obejmuje fragmenty o różnym formatowaniu, należy przeanalizować wynik, aby upewnić się, że zamiana używa pożądanego stylu.