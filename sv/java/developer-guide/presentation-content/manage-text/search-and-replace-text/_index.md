---
title: Sök och ersätt text i PowerPoint-presentationer i Java
linktitle: Sök och ersätt text
type: docs
weight: 55
url: /sv/java/search-and-replace-text/
keywords:
- sök text
- markera text
- ersätt text
- reguljärt uttryck
- resultat-callback
- textruta
- granskningsrapport
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Sök, markera och ersätt text i PowerPoint-presentationer samtidigt som du samlar varje matchning med Aspose.Slides för Java."
---
## **Översikt**

Aspose.Slides for Java kan söka, markera och ersätta text i en enskild textruta eller i hela en presentation. Varje operation kan också meddela en applikation om varje träff via ett resultat‑callback. Detta gör det möjligt att uppdatera en presentation och samtidigt skapa en granskningsspårning som innehåller den matchade texten, dess kontext, position, textruta och bildnummer.

Dessa funktioner är användbara för granskning, redigering, terminologikontroller, mallrengöring och automatiserade rapporteringsarbetsflöden.

I de första exemplen nedan använder vi en fil med namnet "sample.pptx", som innehåller en enda textruta på den första bilden med följande text:

![Exempeltext](sample_text.png)

## **Välj sökomfång**

Använd metoder på [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/) för att begränsa en operation till en textruta. Använd metoder på [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) för att behandla all tillämplig text i presentationen.

| Operation | En textruta | Hela presentationen |
|---|---|---|
| Highlight literal text | [ITextFrame.highlightText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular-expression matches | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [ITextFrame.replaceText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular-expression matches | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Konfigurera textmatchning**

För operationer med bokstavlig text, använd [TextSearchOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textsearchoptions/) för att styra matchning:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) begränsar träffar till hela ord.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) kontrollerar om teckenens skiftläge måste matcha.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) inkluderar bildanteckningar i sök-, ersättnings- och markeringsoperationer på presentationsnivå.

Operationer med reguljära uttryck använder ett Java `Pattern`, så matchningsregler som skiftlägeskänslighet och ordgränser definieras av uttrycket och dess flaggor.

## **Samla matchningsinformation med en callback**

Implementera [IFindResultCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifindresultcallback/) för att få en notifikation för varje match. Dess [IFindResultCallback.foundResult](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-)‑metod tillhandahåller den relaterade textrutan, källtexten, den matchade texten och matchningspositionen.

Callback‑funktionen får inte ett bildnummer direkt. Implementeringen nedan härleder det från föräldrabilden och hanterar också text som hittas i bildanteckningar. En nullable `Integer` gör det möjligt för samma resultmodell att representera text kopplad till andra bildtyper.

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

För ersättningsoperationer innehåller `foundText` den ursprungliga matchade texten, så callback‑funktionen kan exakt registrera vilka termer som ersattes.

## **Markera text**

Använd metoden [ITextFrame.highlightText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) för att markera bokstavliga textmatchningar i en textruta. Skicka [TextSearchOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textsearchoptions/) för att styra sökningen och en callback för att samla in matchningsdetaljer.

Kodexemplet nedan markerar alla förekomster av tecknen **"try"** och markerar sedan endast hela ordet **"to"**. Båda sökningarna rapporterar sina träffar till samma callback.

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

    // Markera varje förekomst av "try" i textrutan.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // Markera endast hela ordet "to".
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

Resultatet:

![Den markerade texten](highlighted_text.png)

## **Markera text med reguljära uttryck**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)‑metoden markerar textmatchningar som hittas av ett reguljärt uttryck i en textruta.

Följande kod markerar alla ord som innehåller sju eller fler tecken och samlar varje matchning:

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

Resultatet:

![Den markerade texten med reguljärt uttryck](highlighted_text_using_regex.png)

## **Markera text i en hel presentation**

Använd [Presentation.highlightText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) och [Presentation.highlightRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) för att söka i alla tillämpliga textrutor i en presentation. Följande exempel markerar ett bokstavligt uttryck och alla e‑postadresser samtidigt som separata resultatsamlingar hålls för de två sökningarna.

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

## **Ersätt text i en textruta**

Använd [ITextFrame.replaceText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) för bokstavlig text och [ITextFrame.replaceRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) för mönsterbaserad ersättning. Dessa metoder uppdaterar den matchade texten i den befintliga textrutan, som behåller formateringen för den omgivande delen istället för att bygga om textrutan från en enkel sträng.

Följande exempel standardiserar en stavningsvariant och ersätter sedan versionsetiketter. Samma callback registrerar de ursprungliga termerna som matchades av båda operationerna.

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

Om en matchning sträcker sig över delar med olika formatering, granska resultatet för att bekräfta vilken formatering som ska tillämpas på ersättningstexten.

## **Ersätt text i en hel presentation**

Använd [Presentation.replaceText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) och [Presentation.replaceRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) för att tillämpa samma operationer i hela presentationen. Detta är användbart för mallrengöring, terminologiuppdateringar och redigering.

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

## **Gruppera matchningar för rapportering**

Eftersom varje resultat lagrar sitt bildnummer och sin textruta kan applikationer gruppera matchningar för granskning, rapportering eller granskningsarbetsflöden. Följande exempel grupperar de insamlade resultaten först efter bild och sedan efter textruta:

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

**Hur kan jag söka endast i en textruta istället för hela presentationen?**

Hämta forma​ns textruta och anropa [ITextFrame.highlightText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), eller [ITextFrame.replaceRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) på den textrutan. Metoder på presentationsnivå bearbetar alla tillämpliga textrutor istället.

**Hur kan jag matcha hela ord med korrekt versalisering?**

Ställ in [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) och [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) till `true` och skicka alternativen till en metod för markerings‑ eller ersättningsoperation med bokstavlig text. För reguljära uttryck definierar du ordgränser och skiftlägeskänslighet i själva Java `Pattern`.

**Kan sökning och ersättning inkludera text i bildanteckningar?**

Ja. Ställ in [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) till `true` när du använder en presentations‑nivå operation för bokstavlig text. Callback‑implementeringen ovan mappar en matchning i en notessida tillbaka till dess föräldrabildsnummer.

**Hur kan jag skapa en rapport utan att skanna presentationen en andra gång?**

Skicka en [IFindResultCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifindresultcallback/)‑implementation till markerings‑ eller ersättningsoperationen. Callback‑funktionen får varje matchning medan operationen körs, så applikationen kan lagra källtexten, den matchade texten, positionen, textrutan och det beräknade bildnumret för senare gruppering eller export.

**Behåller ersättning av text dess formatering?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) och [ITextFrame.replaceRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modifierar den matchade texten i den befintliga textrutan och behåller formateringen för de omgivande delarna. Om en matchning sträcker sig över delar med olika formatering, undersök resultatet för att säkerställa att ersättningen använder önskad stil.