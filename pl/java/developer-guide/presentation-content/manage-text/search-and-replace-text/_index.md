---
title: Wyszukiwanie i zamiana tekstu w prezentacjach PowerPoint w Javie
linktitle: Wyszukiwanie i zamiana tekstu
type: docs
weight: 55
url: /pl/java/search-and-replace-text/
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
- Java
- Aspose.Slides
description: "Wyszukuj, podświetlaj i zamieniaj tekst w prezentacjach PowerPoint, jednocześnie zbierając każde dopasowanie za pomocą Aspose.Slides dla Javy."
---
## **Przegląd**

Aspose.Slides for Java może wyszukiwać, podświetlać i zamieniać tekst w pojedynczej ramce tekstowej lub w całej prezentacji. Każda operacja może również powiadomić aplikację o każdym dopasowaniu za pomocą zwrotnego wywołania wyniku. Dzięki temu możliwe jest zaktualizowanie prezentacji i jednoczesne tworzenie ścieżki audytu zawierającej dopasowany tekst, jego kontekst, pozycję, ramkę tekstową i numer slajdu.

Te możliwości są przydatne przy przeglądzie, cenzurowaniu, sprawdzaniu terminologii, czyszczeniu szablonów oraz automatycznych przepływach raportowania.

W pierwszych przykładach poniżej używamy pliku o nazwie "sample.pptx", który zawiera jedną ramkę tekstową na pierwszym slajdzie z następującym tekstem:

![Sample text](sample_text.png)

## **Wybierz zakres wyszukiwania**

Użyj metod na [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) aby ograniczyć operację do jednej ramki tekstowej. Użyj metod na [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) aby przetworzyć cały tekst w prezentacji.

| Operacja | Jedna ramka tekstowa | Cała prezentacja |
|---|---|---|
| Podświetl dosłowny tekst | [ITextFrame.highlightText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Podświetl dopasowania wyrażeń regularnych | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Zamień dosłowny tekst | [ITextFrame.replaceText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Zamień dopasowania wyrażeń regularnych | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Skonfiguruj dopasowywanie tekstu**

W operacjach na tekście dosłownym użyj [TextSearchOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textsearchoptions/) do kontrolowania dopasowania:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) ogranicza dopasowania do pełnych słów.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) określa, czy wielkość znaków musi się zgadzać.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) uwzględnia notatki slajdów w operacjach wyszukiwania, zamiany i podświetlania na poziomie prezentacji.

Operacje przy użyciu wyrażeń regularnych wykorzystują klasę Java `Pattern`, więc zasady dopasowywania, takie jak rozróżnianie wielkości liter i granice wyrazów, są definiowane przez wyrażenie i jego flagi.

## **Zidentyfikuj właściciela ramki tekstowej**

Typowe przepływy przetwarzania tekstu często otrzymują obiekt [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) podczas wyszukiwania, zamiany, walidacji lub eksportu tekstu. Użyj [ITextFrame.getParentShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#getParentShape--) i [ITextFrame.getParentCell](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#getParentCell--) aby określić, który obiekt prezentacji jest właścicielem ramki tekstowej.

Oczekiwane wartości zależą od właściciela:

| Właściciel ramki tekstowej | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape lub inny kształt zawierający tekst | The owning [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/) | `null` |
| Komórka tabeli | `null` | The owning [ICell](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icell/) |

Obie metody zapewniają nawigację tylko do odczytu. Wywołanie ich nie przemieszcza ramki tekstowej ani nie zmienia jej właściciela. Kod ogólny powinien sprawdzić oba wyniki pod kątem `null` i obsłużyć sytuację, w której żaden właściciel nie jest dostępny.

Poniższy przykład używa [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) do iteracji po ramkach tekstowych w prezentacji. Dla kształtów raportuje nazwę kształtu, typ w czasie wykonywania Javy oraz zawierający slajd. Dla komórek tabeli raportuje współrzędne kolumny i wiersza liczone od zera oraz zawierający slajd.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, false);

    for (ITextFrame textFrame : textFrames) {
        IShape ownerShape = textFrame.getParentShape();
        if (ownerShape != null) {
            String shapeName = ownerShape.getName().isEmpty() ? "(unnamed)" : ownerShape.getName();
            String shapeType = ownerShape.getClass().getSimpleName();
            IBaseSlide baseSlide = ownerShape.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        ICell ownerCell = textFrame.getParentCell();
        if (ownerCell != null) {
            IBaseSlide baseSlide = ownerCell.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        System.out.println("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

Dla treści SmartArt iteruj po kształtach w [ISmartArtNode.getShapes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ismartartnode/#getShapes--) i uzyskaj dostęp do każdego [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ismartartshape/#getTextFrame--). Ramka tekstowa może być powiązana ze swoim kształtem poprzez [ITextFrame.getParentShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#getParentShape--), natomiast [ITextFrame.getParentCell](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#getParentCell--) zwraca `null`. Dlatego gałąź dotycząca kształtów w przykładzie obsługuje również tekst z węzłów SmartArt.

## **Zbierz informacje o dopasowaniach przy użyciu wywołania zwrotnego**

Zaimplementuj [IFindResultCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifindresultcallback/) aby otrzymywać powiadomienie o każdym dopasowaniu. Jego metoda [IFindResultCallback.foundResult](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) dostarcza powiązaną ramkę tekstową, tekst źródłowy, dopasowany tekst oraz pozycję dopasowania.

Wywołanie zwrotne nie otrzymuje numeru slajdu bezpośrednio. Poniższa implementacja wyprowadza go z slajdu rodzica i obsługuje także tekst znaleziony w notatkach slajdu. Nullable `Integer` pozwala używać tego samego modelu wyniku do reprezentacji tekstu powiązanego z innymi typami slajdów.

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

    private Integer getSlideNumber(ITextFrame textFrame) {
        IShape parentShape = textFrame.getParentShape();
        ICell parentCell = textFrame.getParentCell();
        IBaseSlide parentSlide = parentShape != null ? parentShape.getSlide() : parentCell != null ? parentCell.getSlide() : textFrame.getSlide();

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

Dla operacji zamiany, `foundText` zawiera pierwotny dopasowany tekst, więc wywołanie zwrotne może zapisać dokładnie, które terminy zostały zamienione.

## **Podświetl tekst**

Użyj metody [ITextFrame.highlightText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) aby podświetlić dopasowania dosłownego tekstu w ramce tekstowej. Przekaż [TextSearchOptions] aby kontrolować wyszukiwanie oraz wywołanie zwrotne do zbierania szczegółów dopasowań.

Poniższy przykład podświetla wszystkie wystąpienia znaków **"try"**, a następnie podświetla tylko pełne słowo **"to"**. Oba wyszukiwania raportują dopasowania do tego samego wywołania zwrotnego.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    Color substringHighlightColor = new Color(173, 216, 230);

    // Podświetl każde wystąpienie "try" w ramce tekstowej.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // Podświetl tylko pełne słowo "to".
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

## **Podświetl tekst przy użyciu wyrażeń regularnych**

Metoda [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) podświetla dopasowania tekstu znalezione przez wyrażenie regularne w ramce tekstowej.

Poniższy kod podświetla wszystkie wyrazy zawierające siedem lub więcej znaków i zbiera każde dopasowanie:

```java
import com.aspose.slides.*;
import java.awt.Color;
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

## **Podświetl tekst w całej prezentacji**

Użyj [Presentation.highlightText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) i [Presentation.highlightRegex](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) aby przeszukać wszystkie odpowiednie ramki tekstowe w prezentacji. Poniższy przykład podświetla dosłowne wyrażenie oraz wszystkie adresy e‑mail, zachowując oddzielne kolekcje wyników dla obu wyszukiwań.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    presentation.highlightText("confidential", Color.ORANGE, searchOptions, termCallback);

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

## **Zamień tekst w ramce tekstowej**

Użyj [ITextFrame.replaceText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) dla tekstu dosłownego i [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) dla zamiany opartej na wzorcu. Metody te aktualizują dopasowany tekst w istniejącej ramce tekstowej, zachowując formatowanie otaczających fragmentów zamiast odtwarzania ramki z łańcucha znaków.

Poniższy przykład standaryzuje wariant pisowni, a następnie zamienia etykiety wersji. To samo wywołanie zwrotne zapisuje pierwotne terminy dopasowane przez obie operacje.

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

Jeśli jedno dopasowanie obejmuje fragmenty o różnym formatowaniu, sprawdź wynik, aby potwierdzić, które formatowanie powinno być zastosowane do tekstu zastępczego.

## **Zamień tekst w całej prezentacji**

Użyj [Presentation.replaceText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) i [Presentation.replaceRegex](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) aby zastosować te same operacje w całej prezentacji. Jest to przydatne przy czyszczeniu szablonów, aktualizacji terminologii i cenzurowaniu.

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

## **Grupuj dopasowania do raportowania**

Ponieważ każdy wynik przechowuje numer slajdu i ramkę tekstową, aplikacje mogą grupować dopasowania dla audytu, raportowania lub przeglądania. Poniższy przykład grupuje zebrane wyniki najpierw według slajdu, a potem według ramki tekstowej:

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

**Jak mogę przeszukać tylko jedną ramkę tekstową zamiast całej prezentacji?**

Uzyskaj ramkę tekstową kształtu i wywołaj [ITextFrame.highlightText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), lub [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) na tej ramce tekstowej. Metody na poziomie prezentacji przetwarzają wszystkie odpowiednie ramki tekstowe.

**Jak mogę dopasować całe wyrazy z odpowiednią wielkością liter?**

Ustaw [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) i [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) na `true` i przekaż opcje do metody podświetlania lub zamiany tekstu dosłownego. W przypadku wyrażeń regularnych określ granice wyrazów oraz rozróżnianie wielkości liter w samym wzorcu Java `Pattern`.

**Czy wyszukiwanie i zamiana mogą obejmować tekst w notatkach slajdu?**

Tak. Ustaw [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) na `true` przy użyciu operacji tekstu dosłownego na poziomie prezentacji. Implementacja wywołania zwrotnego pokazana powyżej mapuje dopasowanie w notatkach slajdu z powrotem do numeru slajdu nadrzędnego.

**Jak mogę utworzyć raport bez ponownego skanowania prezentacji?**

Przekaż implementację [IFindResultCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifindresultcallback/) do operacji podświetlania lub zamiany. Wywołanie zwrotne otrzymuje każde dopasowanie podczas wykonywania operacji, więc aplikacja może przechowywać tekst źródłowy, dopasowany tekst, pozycję, ramkę tekstową i wyliczony numer slajdu do późniejszego grupowania lub eksportu.

**Czy zamiana tekstu zachowuje jego formatowanie?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) i [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modyfikują dopasowany tekst w istniejącej ramce tekstowej i zachowują formatowanie otaczających fragmentów. Jeśli dopasowanie obejmuje fragmenty o różnym formatowaniu, sprawdź wynik, aby upewnić się, że zamiana używa pożądanego stylu.