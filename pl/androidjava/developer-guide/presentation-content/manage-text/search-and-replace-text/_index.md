---
title: Wyszukiwanie i zamiana tekstu w prezentacjach PowerPoint na Androidzie
linktitle: Wyszukiwanie i zamiana tekstu
type: docs
weight: 55
url: /pl/androidjava/search-and-replace-text/
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
- Android
- Java
- Aspose.Slides
description: "Wyszukuj, podświetlaj i zamieniaj tekst w prezentacjach PowerPoint, jednocześnie zbierając każde dopasowanie za pomocą Aspose.Slides for Android via Java."
---
## **Przegląd**

Aspose.Slides for Android via Java może wyszukiwać, podświetlać i zamieniać tekst w pojedynczej ramce tekstowej lub w całej prezentacji. Każda operacja może także powiadomić aplikację o każdym dopasowaniu za pomocą wywołania zwrotnego (callback). Dzięki temu możliwe jest jednoczesne aktualizowanie prezentacji i budowanie ścieżki audytu zawierającej dopasowany tekst, jego kontekst, pozycję, ramkę tekstową oraz numer slajdu.

Te możliwości są przydatne przy przeglądzie, redakcji, kontroli terminologii, czyszczeniu szablonów oraz zautomatyzowanych przepływach raportowania.

W poniższych pierwszych przykładach używamy pliku o nazwie **„sample.pptx”**, który zawiera pojedyncze pole tekstowe na pierwszym slajdzie z następującym tekstem:

![Przykładowy tekst](sample_text.png)

## **Wybierz zakres wyszukiwania**

Użyj metod z interfejsu [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/), aby ograniczyć operację do jednej ramki tekstowej. Użyj metod z interfejsu [IPresentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/), aby przetworzyć cały tekst w prezentacji.

| Operacja | Jedna ramka tekstowa | Cała prezentacja |
|---|---|---|
| Podświetl dosłowny tekst | [ITextFrame.highlightText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Podświetl dopasowania wyrażenia regularnego | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Zamień dosłowny tekst | [ITextFrame.replaceText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Zamień dopasowania wyrażenia regularnego | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Skonfiguruj dopasowywanie tekstu**

W przypadku operacji na dosłownym tekście użyj [TextSearchOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textsearchoptions/), aby kontrolować dopasowywanie:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) ogranicza dopasowania do pełnych słów.  
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) określa, czy ma być uwzględniana wielkość liter.  
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) włącza notatki slajdów w operacjach wyszukiwania, zamiany i podświetlania na poziomie prezentacji.

Operacje oparte na wyrażeniach regularnych używają klasy Java `Pattern`, więc reguły dopasowywania, takie jak uwzględnianie wielkości liter i granice słów, definiowane są w samym wyrażeniu i jego flagach.

## **Zidentyfikuj właściciela ramki tekstowej**

Typowe przepływy przetwarzania tekstu często otrzymują obiekt [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/) podczas wyszukiwania, zamiany, walidacji lub eksportu tekstu. Użyj [ITextFrame.getParentShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#getParentShape--) oraz [ITextFrame.getParentCell](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#getParentCell--) aby określić, który obiekt prezentacji jest właścicielem ramki tekstowej.

Oczekiwane wartości zależą od właściciela:

| Właściciel ramki tekstowej | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape lub inny kształt zawierający tekst | Właścielski [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/) | `null` |
| Komórka tabeli | `null` | Właścielski [ICell](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icell/) |

Obie metody zapewniają nawigację tylko‑do‑odczytu. Wywołanie ich nie przemieszcza ramki tekstowej ani nie zmienia jej właściciela. Kod ogólny powinien sprawdzać oba wyniki pod kątem `null` i obsługiwać sytuację, w której żaden właściciel nie jest dostępny.

Poniższy przykład używa [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-), aby przejść przez wszystkie ramki tekstowe w prezentacji. Dla kształtów wypisuje nazwę kształtu, typ w czasie wykonania w Javie oraz slajd, na którym się znajduje. Dla komórek tabeli wypisuje współrzędne kolumny i wiersza (indeksowane od zera) oraz slajd zawierający komórkę.

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

Dla treści SmartArt iteruj po kształtach zwróconych przez [ISmartArtNode.getShapes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ismartartnode/#getShapes--) i uzyskaj [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--). Ramka tekstowa może być powiązana z jej kształtem przy pomocy [ITextFrame.getParentShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#getParentShape--), natomiast [ITextFrame.getParentCell](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#getParentCell--) zwraca `null`. Dlatego gałąź obsługująca kształty w przykładzie obsługuje również tekst z węzłów SmartArt.

## **Zbierz informacje o dopasowaniach za pomocą wywołania zwrotnego**

Zaimplementuj [IFindResultCallback](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifindresultcallback/), aby otrzymywać powiadomienie o każdym dopasowaniu. Jego metoda [IFindResultCallback.foundResult](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) dostarcza powiązaną ramkę tekstową, tekst źródłowy, dopasowany tekst oraz pozycję dopasowania.

Wywołanie zwrotne nie otrzymuje numeru slajdu bezpośrednio. Poniższa implementacja wyprowadza go z slajdu nadrzędnego i dodatkowo obsługuje tekst znaleziony w notatkach slajdu. Nullable `Integer` pozwala temu samemu modelowi wyniku reprezentować tekst powiązany z innymi typami slajdów.

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

W operacjach zamiany zmienna `foundText` zawiera oryginalny dopasowany tekst, więc wywołanie zwrotne może zapisać dokładnie, które terminy zostały zastąpione.

## **Podświetl tekst**

Użyj metody [ITextFrame.highlightText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), aby podświetlić dopasowania dosłownego tekstu w ramce tekstowej. Przekaż obiekt [TextSearchOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textsearchoptions/), aby kontrolować wyszukiwanie, oraz wywołanie zwrotne do zebrania szczegółów dopasowań.

Poniższy przykład podświetla wszystkie wystąpienia znaków **„try”**, a następnie podświetla wyłącznie całe słowo **„to”**. Oba wyszukiwania raportują swoje dopasowania do tego samego wywołania zwrotnego.

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

Rezultat:

![Podświetlony tekst](highlighted_text.png)

## **Podświetl tekst przy użyciu wyrażeń regularnych**

Metoda [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) podświetla dopasowania tekstu znalezione przez wyrażenie regularne w ramce tekstowej.

Poniższy kod podświetla wszystkie słowa zawierające co najmniej siedem znaków i zbiera każde dopasowanie:

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

Rezultat:

![Podświetlony tekst przy użyciu wyrażenia regularnego](highlighted_text_using_regex.png)

## **Podświetl tekst w całej prezentacji**

Użyj metod [IPresentation.highlightText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) i [IPresentation.highlightRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) aby przeszukać wszystkie odpowiednie ramki tekstowe w prezentacji. Poniższy przykład podświetla dosłowne wyrażenie oraz wszystkie adresy e‑mail, przy czym wyniki obu wyszukiwań są przechowywane osobno.

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

## **Zastąp tekst w ramce tekstowej**

Użyj [ITextFrame.replaceText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) dla tekstu dosłownego oraz [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) dla zamiany opartej na wyrażeniu regularnym. Metody te aktualizują dopasowany tekst w istniejącej ramce tekstowej, zachowując formatowanie otaczających fragmentów zamiast odtwarzania całej ramki z czystego łańcucha znaków.

Poniższy przykład standaryzuje wariant pisowni, a następnie zastępuje etykiety wersji. To samo wywołanie zwrotne rejestruje oryginalne terminy dopasowane w obu operacjach.

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

Jeśli jedno dopasowanie obejmuje fragmenty o różnym formatowaniu, sprawdź wynik, aby potwierdzić, które formatowanie powinno zostać zastosowane do tekstu zamienionego.

## **Zastąp tekst w całej prezentacji**

Użyj [IPresentation.replaceText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) i [IPresentation.replaceRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) aby zastosować te same operacje w całej prezentacji. Jest to przydatne przy czyszczeniu szablonów, aktualizacji terminologii oraz redakcji.

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

## **Grupuj dopasowania dla raportowania**

Ponieważ każdy wynik przechowuje numer slajdu oraz ramkę tekstową, aplikacje mogą grupować dopasowania w celu audytu, raportowania lub przeglądu. Poniższy przykład grupuje zebrane wyniki najpierw według slajdu, a potem według ramki tekstowej:

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

Uzyskaj ramkę tekstową kształtu i wywołaj [ITextFrame.highlightText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), lub [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) na tej ramce. Metody na poziomie prezentacji przetwarzają wszystkie odpowiednie ramki tekstowe.

**Jak dopasować pełne słowa z zachowaniem wielkości liter?**

Ustaw [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) i [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) na `true`, a następnie przekaż opcje do metody podświetlania lub zamiany tekstu dosłownego. W przypadku wyrażeń regularnych zdefiniuj granice słów oraz uwzględnianie wielkości liter bezpośrednio w obiekcie Java `Pattern`.

**Czy wyszukiwanie i zamiana mogą obejmować tekst w notatkach slajdów?**

Tak. Ustaw [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) na `true` podczas korzystania z operacji na poziomie prezentacji dotyczącej tekstu dosłownego. Implementacja wywołania zwrotnego przedstawiona powyżej mapuje dopasowanie w notatce na numer slajdu nadrzędnego.

**Jak stworzyć raport bez drugiego skanowania prezentacji?**

Przekaż implementację [IFindResultCallback](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifindresultcallback/) do operacji podświetlania lub zamiany. Wywołanie zwrotne otrzymuje każde dopasowanie w trakcie działania operacji, więc aplikacja może zapisać tekst źródłowy, dopasowany tekst, pozycję, ramkę tekstową oraz wyliczony numer slajdu do późniejszego grupowania lub eksportu.

**Czy zamiana tekstu zachowuje jego formatowanie?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) i [ITextFrame.replaceRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modyfikują dopasowany tekst w istniejącej ramce tekstowej i zachowują formatowanie otaczających fragmentów. Jeśli dopasowanie obejmuje fragmenty o różnym formatowaniu, sprawdź wynik, aby upewnić się, że zamiana używa pożądanego stylu.