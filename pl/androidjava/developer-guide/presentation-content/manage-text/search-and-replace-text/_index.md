---
title: Wyszukiwanie i zamiana tekstu w prezentacjach PowerPoint na Androidzie
linktitle: Wyszukiwanie i zamiana tekstu
type: docs
weight: 55
url: /pl/androidjava/search-and-replace-text/
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
- Android
- Java
- Aspose.Slides
description: "Wyszukuj, podświetlaj i zamieniaj tekst w prezentacjach PowerPoint, zbierając każde dopasowanie przy użyciu Aspose.Slides for Android via Java."
---
## **Przegląd**

Aspose.Slides for Android via Java może wyszukiwać, podświetlać i zamieniać tekst w pojedynczej ramce tekstowej lub w całej prezentacji. Każda operacja może także powiadomić aplikację o każdym dopasowaniu za pośrednictwem wywołania zwrotnego z wynikiem. Dzięki temu można aktualizować prezentację i jednocześnie budować ścieżkę audytu zawierającą dopasowany tekst, jego kontekst, pozycję, ramkę tekstową oraz numer slajdu.

Te możliwości są przydatne przy przeglądzie, redakcji, sprawdzaniu terminologii, czyszczeniu szablonów i automatyzacji raportowania.

W pierwszych przykładach poniżej używamy pliku o nazwie **"sample.pptx"**, który zawiera jedną ramkę tekstową na pierwszym slajdzie z następującym tekstem:

![Sample text](sample_text.png)

## **Wybierz zakres wyszukiwania**

Użyj metod z [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/), aby ograniczyć operację do jednej ramki tekstowej. Użyj metod z [IPresentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/), aby przetworzyć cały tekst w prezentacji.

| Operacja | Jedna ramka tekstowa | Cała prezentacja |
|---|---|---|
| Podświetlanie dosłownego tekstu | [ITextFrame.highlightText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Podświetlanie dopasowań wyrażenia regularnego | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Zastąpienie dosłownego tekstu | [ITextFrame.replaceText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Zastąpienie dopasowań wyrażenia regularnego | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Skonfiguruj dopasowywanie tekstu**

Dla operacji na dosłownym tekście użyj [TextSearchOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textsearchoptions/), aby kontrolować dopasowywanie:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) ogranicza dopasowania do pełnych słów.  
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) kontroluje, czy ma być uwzględniona wielkość znaków.  
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) uwzględnia notatki slajdów w operacjach wyszukiwania, zamiany i podświetlania na poziomie prezentacji.

Operacje oparte na wyrażeniach regularnych używają klasy Java `Pattern`, więc reguły dopasowywania, takie jak wrażliwość na wielkość liter i granice słów, są definiowane w samym wyrażeniu i jego flagach.

## **Zbierz informacje o dopasowaniach przy użyciu wywołania zwrotnego**

Zaimplementuj [IFindResultCallback](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifindresultcallback/), aby otrzymywać powiadomienie o każdym dopasowaniu. Jego metoda [IFindResultCallback.foundResult](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) dostarcza powiązaną ramkę tekstową, źródłowy tekst, dopasowany tekst oraz pozycję dopasowania.

Wywołanie zwrotne nie otrzymuje bezpośrednio numeru slajdu. Implementacja poniżej wyprowadza go z rodzica slajdu oraz obsługuje tekst znaleziony w notatkach slajdu. Nullable `Integer` pozwala używać tego samego modelu wyniku dla tekstu powiązanego z innymi typami slajdów.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

final class TextMatch {
    private final ITextFrame textFrame;
    private final String sourceText;
    private final String foundText;
    private final int textPosition;
    private final Integer slideNumber;

    TextMatch(ITextFrame textFrame, String sourceText, String foundText, int textPosition, Integer slideNumber) {
        this.textFrame = textFrame;
        this.sourceText = sourceText;
        this.foundText = foundText;
        this.textPosition = textPosition;
        this.slideNumber = slideNumber;
    }

    ITextFrame getTextFrame() {
        return textFrame;
    }

    String getSourceText() {
        return sourceText;
    }

    String getFoundText() {
        return foundText;
    }

    int getTextPosition() {
        return textPosition;
    }

    Integer getSlideNumber() {
        return slideNumber;
    }
}

final class TextSearchCallback implements IFindResultCallback {
    private final List<TextMatch> results = new ArrayList<TextMatch>();

    List<TextMatch> getResults() {
        return results;
    }

    @Override
    public void foundResult(ITextFrame textFrame, String sourceText, String foundText, int textPosition) {
        Integer slideNumber = getSlideNumber(textFrame);
        TextMatch result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);
        results.add(result);
    }

    private static Integer getSlideNumber(ITextFrame textFrame) {
        if (!(textFrame instanceof TextFrame)) {
            return null;
        }

        IBaseSlide parentSlide = ((TextFrame) textFrame).getSlide();

        if (parentSlide instanceof ISlide) {
            return ((ISlide) parentSlide).getSlideNumber();
        }

        if (parentSlide instanceof INotesSlide) {
            return ((INotesSlide) parentSlide).getParentSlide().getSlideNumber();
        }

        return null;
    }
}
```

Dla operacji zamiany `foundText` zawiera oryginalny dopasowany tekst, więc wywołanie zwrotne może dokładnie zapisać, które terminy zostały zastąpione.

## **Podświetlanie tekstu**

Użyj metody [ITextFrame.highlightText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), aby podświetlić dopasowania dosłownego tekstu w ramce tekstowej. Przekaż [TextSearchOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textsearchoptions/), aby kontrolować wyszukiwanie, oraz wywołanie zwrotne, aby zebrać szczegóły dopasowań.

Poniższy przykład podświetla wszystkie wystąpienia znaków **"try"**, a następnie podświetla tylko całe słowo **"to"**. Oba wyszukiwania raportują swoje dopasowania do tego samego wywołania zwrotnego.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    int substringHighlightColor = Color.rgb(173, 216, 230);

    // Podświetl każde wystąpienie "try" w ramce tekstowej.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // Podświetl tylko całe słowo "to".
    shape.getTextFrame().highlightText("to", wholeWordHighlightColor, wholeWordSearchOptions, callback);

    for (TextMatch result : callback.getResults()) {
        System.out.println("Found '" + result.getFoundText() + "' at position " +
                result.getTextPosition() + " on slide " + result.getSlideNumber() + ".");
    }

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The highlighted text](highlighted_text.png)

## **Podświetlanie tekstu przy użyciu wyrażeń regularnych**

Metoda [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) podświetla dopasowania tekstu znalezione przez wyrażenie regularne w ramce tekstowej.

Poniższy kod podświetla wszystkie słowa zawierające siedem lub więcej znaków i zbiera każde dopasowanie:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    Pattern regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Podświetlanie tekstu w całej prezentacji**

Użyj [IPresentation.highlightText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) i [IPresentation.highlightRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) do przeszukania wszystkich odpowiednich ramek tekstowych w prezentacji. Poniższy przykład podświetla dosłowny termin oraz wszystkie adresy e‑mail, zachowując oddzielne kolekcje wyników dla obu wyszukiwań.

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    int termHighlightColor = Color.rgb(255, 165, 0);
    presentation.highlightText("confidential", termHighlightColor, searchOptions, termCallback);

    TextSearchCallback emailCallback = new TextSearchCallback();
    Pattern emailRegex = Pattern.compile(
            "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
            Pattern.CASE_INSENSITIVE);

    presentation.highlightRegex(emailRegex, Color.YELLOW, emailCallback);
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zamiana tekstu w ramce tekstowej**

Użyj [ITextFrame.replaceText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) dla dosłownego tekstu oraz [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) dla zamiany opartej na wzorcu. Metody te aktualizują dopasowany tekst w istniejącej ramce tekstowej, zachowując formatowanie otaczających fragmentów zamiast odbudowywać ramkę z zwykłego łańcucha.

Poniższy przykład ujednolicaja wariant ortograficzny, a następnie zamienia etykiety wersji. To samo wywołanie zwrotne zapisuje oryginalne terminy dopasowane przez obie operacje.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText("colour", "color", searchOptions, callback);

    Pattern versionRegex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", callback);

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jeśli jedno dopasowanie obejmuje fragmenty o różnym formatowaniu, przejrzyj wynik, aby potwierdzić, które formatowanie ma być zastosowane do tekstu zamienionego.

## **Zamiana tekstu w całej prezentacji**

Użyj [IPresentation.replaceText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) i [IPresentation.replaceRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) do zastosowania tych samych operacji w całej prezentacji. Jest to przydatne przy czyszczeniu szablonów, aktualizacji terminologii i redakcji.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText("Contoso", "Example Corp", searchOptions, callback);

    Pattern accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Grupowanie dopasowań dla raportowania**

Ponieważ każdy wynik przechowuje numer slajdu i ramkę tekstową, aplikacje mogą grupować dopasowania dla celów audytu, raportowania lub przeglądu. Poniższy przykład grupuje zebrane wyniki najpierw po slajdzie, a potem po ramce tekstowej:

```java
import com.aspose.slides.ITextFrame;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

Map<Integer, Map<ITextFrame, List<TextMatch>>> matchesBySlide =
        new LinkedHashMap<Integer, Map<ITextFrame, List<TextMatch>>>();

for (TextMatch result : callback.getResults()) {
    Integer slideNumber = result.getSlideNumber();
    Map<ITextFrame, List<TextMatch>> matchesByTextFrame = matchesBySlide.get(slideNumber);

    if (matchesByTextFrame == null) {
        matchesByTextFrame = new LinkedHashMap<ITextFrame, List<TextMatch>>();
        matchesBySlide.put(slideNumber, matchesByTextFrame);
    }

    ITextFrame textFrame = result.getTextFrame();
    List<TextMatch> textFrameMatches = matchesByTextFrame.get(textFrame);

    if (textFrameMatches == null) {
        textFrameMatches = new java.util.ArrayList<TextMatch>();
        matchesByTextFrame.put(textFrame, textFrameMatches);
    }

    textFrameMatches.add(result);
}

for (Map.Entry<Integer, Map<ITextFrame, List<TextMatch>>> slideEntry : matchesBySlide.entrySet()) {
    String slideLabel = slideEntry.getKey() == null ? "Other" : slideEntry.getKey().toString();
    System.out.println("Slide: " + slideLabel);

    for (Map.Entry<ITextFrame, List<TextMatch>> textFrameEntry : slideEntry.getValue().entrySet()) {
        System.out.println("  Text frame: " + textFrameEntry.getKey().getText());

        for (TextMatch result : textFrameEntry.getValue()) {
            System.out.println("    '" + result.getFoundText() + "' at position " +
                    result.getTextPosition() + "; context: '" + result.getSourceText() + "'");
        }
    }
}
```

## **FAQ**

**Jak mogę przeszukiwać tylko jedną ramkę tekstową zamiast całej prezentacji?**

Pobierz ramkę tekstową kształtu i wywołaj [ITextFrame.highlightText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), lub [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) na tej ramce tekstowej. Metody na poziomie prezentacji przetwarzają wszystkie odpowiednie ramki tekstowe.

**Jak dopasować całe słowa z właściwą kapitalizacją?**

Ustaw [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) i [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) na `true` i przekaż opcje do metody podświetlania lub zamiany tekstu dosłownego. Dla wyrażeń regularnych zdefiniuj granice słów i wrażliwość na wielkość liter bezpośrednio w obiekcie `Pattern`.

**Czy wyszukiwanie i zamiana mogą obejmować tekst w notatkach slajdów?**

Tak. Ustaw [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) na `true` przy używaniu operacji na poziomie prezentacji dla dosłownego tekstu. Powyższa implementacja wywołania zwrotnego mapuje dopasowanie w notatce slajdu na numer jego slajdu macierzystego.

**Jak stworzyć raport bez ponownego skanowania prezentacji?**

Przekaż implementację [IFindResultCallback](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifindresultcallback/) do operacji podświetlania lub zamiany. Wywołanie zwrotne otrzymuje każde dopasowanie w trakcie trwania operacji, dzięki czemu aplikacja może zapisać źródłowy tekst, dopasowany tekst, pozycję, ramkę tekstową i wyliczony numer slajdu do późniejszego grupowania lub eksportu.

**Czy zamiana tekstu zachowuje jego formatowanie?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) i [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modyfikują dopasowany tekst w istniejącej ramce i zachowują formatowanie otaczających fragmentów. Jeśli dopasowanie obejmuje fragmenty o różnym formatowaniu, sprawdź wynik, aby upewnić się, że zamiana używa pożądanego stylu.