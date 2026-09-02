---
title: Sök och ersätt text i PowerPoint-presentationer på Android
linktitle: Sök och ersätt text
type: docs
weight: 55
url: /sv/androidjava/search-and-replace-text/
keywords:
- sök text
- markera text
- ersätt text
- reguljärt uttryck
- resultat callback
- textram
- revisionsrapport
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Sök, markera och ersätt text i PowerPoint-presentationer samtidigt som du samlar varje matchning med Aspose.Slides för Android via Java."
---
## **Översikt**

Aspose.Slides for Android via Java kan söka, markera och ersätta text i en enskild textram eller i hela en presentation. Varje operation kan också meddela en applikation om varje träff via ett resultat‑callback. Detta gör det möjligt att uppdatera en presentation och samtidigt bygga ett revisionsspår som innehåller den matchade texten, dess sammanhang, position, textram och bildnummer.

Dessa funktioner är användbara för granskning, redigering, terminologikontroller, mallstädning och automatiserade rapporteringsarbetsflöden.

I de första exemplen nedan använder vi en fil som heter "sample.pptx", som innehåller en enda textruta på den första bilden med följande text:

![Exempeltext](sample_text.png)

## **Välj sökomfång**

Använd metoder på [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/) för att begränsa en operation till en textram. Använd metoder på [IPresentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/) för att behandla all tillämplig text i presentationen.

| Operation | En textram | Hela presentationen |
|---|---|---|
| Highlight literal text | [ITextFrame.highlightText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular-expression matches | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [ITextFrame.replaceText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular-expression matches | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Konfigurera textmatchning**

För operationer med bokstavlig text, använd [TextSearchOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textsearchoptions/) för att styra matchning:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) begränsar matchningar till hela ord.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) styr om tecknens skiftläge måste matcha.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) inkluderar bildanteckningar i sök-, ersättnings- och markeringsoperationer på presentationsnivå.

Operationer med reguljära uttryck använder ett Java `Pattern`, så matchningsregler som skiftlägeskänslighet och ordgränser definieras av uttrycket och dess flaggor.

## **Samla matchningsinformation med ett callback**

Implementera [IFindResultCallback](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifindresultcallback/) för att ta emot en notifikation för varje match. Dess metod [IFindResultCallback.foundResult](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) ger den relaterade textramen, källtexten, den matchade texten och matchningspositionen.

Callbacken får inte ett bildnummer direkt. Implementeringen nedan härleder det från den överordnade bilden och hanterar även text som finns i bildanteckningar. En nullable `Integer` gör att samma resultatsmodell kan representera text som är kopplad till andra bildtyper.

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

För ersättningsoperationer innehåller `foundText` den ursprungliga matchade texten, så callbacken kan registrera exakt vilka termer som ersattes.

## **Markera text**

Använd metoden [ITextFrame.highlightText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) för att markera bokstavliga textmatchningar i en textram. Skicka in [TextSearchOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textsearchoptions/) för att styra sökningen och ett callback för att samla matchningsdetaljer.

Kodexemplet nedan markerar alla förekomster av tecknen **"try"** och markerar sedan endast hela ordet **"to"**. Båda sökningarna rapporterar sina matchningar till samma callback.

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

    // Markera varje förekomst av "try" i textramen.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // Markera endast det kompletta ordet "to".
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

Metoden [ITextFrame.highlightRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) markerar textmatchningar som hittas med ett reguljärt uttryck i en textram.

Följande kod markerar alla ord som innehåller sju eller fler tecken och samlar varje matchning:

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

Resultatet:

![Den markerade texten med reguljärt uttryck](highlighted_text_using_regex.png)

## **Markera text i en hel presentation**

Använd [IPresentation.highlightText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) och [IPresentation.highlightRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) för att söka i alla tillämpliga textramar i en presentation. Följande exempel markerar ett bokstavligt uttryck och alla e‑postadresser samtidigt som separata resultatsamlingar hålls för de två sökningarna.

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

## **Ersätt text i en textram**

Använd [ITextFrame.replaceText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) för bokstavlig text och [ITextFrame.replaceRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) för mönsterbaserad ersättning. Dessa metoder uppdaterar den matchade texten i den befintliga textramen, vilket behåller formateringen i omgivande delar istället för att bygga om textramen från en ren sträng.

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

Om en matchning sträcker sig över delar med olika formatering, granska utdata för att bekräfta vilken formatering som ska tillämpas på den ersatta texten.

## **Ersätt text i en hel presentation**

Använd [IPresentation.replaceText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) och [IPresentation.replaceRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) för att tillämpa samma operationer i hela presentationen. Detta är användbart för mallstädning, terminologisk uppdatering och radering.

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

Eftersom varje resultat lagrar bildnumret och textramen kan applikationer gruppera matchningar för revision, rapportering eller granskningsarbetsflöden. Följande exempel grupperar de insamlade resultaten först efter bild och sedan efter textram:

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

## **Vanliga frågor**

**Hur kan jag söka i bara en textruta istället för hela presentationen?**

Hämta formens textram och anropa [ITextFrame.highlightText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), eller [ITextFrame.replaceRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) på den textramen. Metoder på presentationsnivå bearbetar alla tillämpliga textramar istället.

**Hur kan jag matcha hela ord med korrekt versal-/gemenform?**

Ställ in [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) och [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) till `true` och skicka med alternativen till en bokstavlig textmarkerings‑ eller ersättningsmetod. För reguljära uttryck definieras ordgränser och skiftlägeskänslighet i Java `Pattern`‑uttrycket självt.

**Kan sökning och ersättning inkludera text i bildanteckningar?**

Ja. Ställ in [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) till `true` när du använder en bokstavlig textoperation på presentationsnivå. Callback‑implementeringen ovan mappar en träff i en notisbilder tillbaka till dess överordnade bildnummer.

**Hur kan jag skapa en rapport utan att skanna presentationen en andra gång?**

Skicka en [IFindResultCallback](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifindresultcallback/)‑implementation till markerings‑ eller ersättningsoperationen. Callbacken får varje matchning medan operationen körs, så applikationen kan lagra källtexten, den matchade texten, positionen, textramen och härledda bildnumret för senare gruppering eller export.

**Behåller ersättning av text dess formatering?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) och [ITextFrame.replaceRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) ändrar den matchade texten i den befintliga textramen och behåller formateringen i de omgivande delarna. Om en matchning sträcker sig över delar med olika formatering, granska resultatet för att säkerställa att ersättningen använder önskad stil.