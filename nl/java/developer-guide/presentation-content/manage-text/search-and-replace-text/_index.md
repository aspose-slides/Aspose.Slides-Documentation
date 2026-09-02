---
title: Zoeken en vervangen van tekst in PowerPoint-presentaties in Java
linktitle: Zoeken en vervangen van tekst
type: docs
weight: 55
url: /nl/java/search-and-replace-text/
keywords:
- tekst zoeken
- tekst markeren
- tekst vervangen
- reguliere expressie
- resultaat-callback
- tekstframe
- auditrapport
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Zoeken, markeren en vervangen van tekst in PowerPoint-presentaties terwijl elke overeenkomst wordt verzameld met Aspose.Slides for Java."
---
## **Overzicht**

Aspose.Slides for Java kan zoeken, markeren en tekst vervangen in één tekstframe of in een volledige presentatie. Elke bewerking kan bovendien een toepassing op de hoogte stellen van elke overeenkomst via een result‑callback. Daardoor kan een presentatie worden bijgewerkt en tegelijk een controlelogboek worden opgebouwd met de overeenkomstige tekst, de context, positie, tekstframe en slide‑nummer.

Deze mogelijkheden zijn nuttig voor beoordeling, redacties, terminologiecontroles, sjabloonopschoning en geautomatiseerde rapportage‑workflows.

In de eerste voorbeelden hieronder gebruiken we een bestand genaamd “sample.pptx”, dat een enkele tekstvak op de eerste slide bevat met de volgende tekst:

![Voorbeeldtekst](sample_text.png)

## **Kies de zoekscope**

Gebruik methoden op [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) om een bewerking te beperken tot één tekstframe. Gebruik methoden op [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) om alle toepasselijke teksten in de presentatie te verwerken.

| Operatie | Één tekstframe | Volledige presentatie |
|---|---|---|
| Markeer letterlijke tekst | [ITextFrame.highlightText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Markeer overeenkomsten van reguliere expressies | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Vervang letterlijke tekst | [ITextFrame.replaceText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Vervang overeenkomsten van reguliere expressies | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configureer tekstmatching**

Voor letterlijke‑tekstbewerkingen gebruik je [TextSearchOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textsearchoptions/) om het zoeken te sturen:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) beperkt overeenkomsten tot volledige woorden.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) bepaalt of hoofdlettergebruik moet overeenkomen.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) neemt slide‑notities op in zoek‑, vervang‑ en markeerbewerkingen op presentatieniveau.

Reguliere‑expressie‑bewerkingen gebruiken een Java `Pattern`, dus regels zoals hoofdlettergevoeligheid en woordgrenzen worden door de expressie en zijn vlaggen gedefinieerd.

## **Verzamel matchinformatie met een callback**

Implementeer [IFindResultCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifindresultcallback/) om een melding te krijgen voor elke overeenkomst. De methode [IFindResultCallback.foundResult](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) levert het bijbehorende tekstframe, de brontekst, de gevonden tekst en de positie van de match.

De callback ontvangt niet rechtstreeks een slide‑nummer. De implementatie hieronder haalt het nummer uit de bovenliggende slide en verwerkt ook tekst die in slide‑notities wordt gevonden. Een nullable `Integer` maakt het mogelijk hetzelfde resultaatsmodel te gebruiken voor tekst die bij andere slidetypes hoort.

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

Voor vervangbewerkingen bevat `foundText` de oorspronkelijke gevonden tekst, zodat de callback exact kan registreren welke termen zijn vervangen.

## **Markeer tekst**

Gebruik de methode [ITextFrame.highlightText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) om letterlijke‑tekstmatches in een tekstframe te markeren. Geef [TextSearchOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textsearchoptions/) door om het zoeken te sturen en een callback om matchdetails te verzamelen.

Het code‑voorbeeld hieronder markeert alle voorkomens van de tekens **"try"** en daarna alleen het volledige woord **"to"**. Beide zoekacties rapporteren hun matches aan dezelfde callback.

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

    // Markeer elk voorkomen van "try" in het tekstframe.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // Markeer alleen het volledige woord "to".
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

Het resultaat:

![De gemarkeerde tekst](highlighted_text.png)

## **Markeer tekst met reguliere expressies**

De methode [ITextFrame.highlightRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) markeert tekstmatches die zijn gevonden met een reguliere expressie in een tekstframe.

De onderstaande code markeert alle woorden met zeven of meer tekens en verzamelt elke match:

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

Het resultaat:

![De gemarkeerde tekst met behulp van de reguliere expressie](highlighted_text_using_regex.png)

## **Markeer tekst in een hele presentatie**

Gebruik [Presentation.highlightText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) en [Presentation.highlightRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) om alle toepasselijke tekstframes in een presentatie te doorzoeken. Het volgende voorbeeld markeert een letterlijke term en alle e‑mailadressen, met gescheiden resultaatsverzamelingen voor de twee zoekacties.

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

## **Vervang tekst in een tekstframe**

Gebruik [ITextFrame.replaceText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) voor letterlijke tekst en [ITextFrame.replaceRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) voor op patronen gebaseerde vervanging. Deze methoden werken de gevonden tekst bij binnen het bestaande tekstframe, waardoor de opmaak van de omliggende delen behouden blijft in plaats van het tekstframe opnieuw op te bouwen uit een platte string.

Het volgende voorbeeld normaliseert een spellingvariant en vervangt daarna versielabels. Dezelfde callback registreert de originele termen die door beide bewerkingen zijn gematcht.

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

Als één match zich uitstrekt over delen met verschillende opmaak, controleer dan de output om te bevestigen welke opmaak op de vervangende tekst moet worden toegepast.

## **Vervang tekst in een hele presentatie**

Gebruik [Presentation.replaceText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) en [Presentation.replaceRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) om dezelfde bewerkingen over de volledige presentatie toe te passen. Dit is nuttig voor sjabloonopschoning, terminologie‑updates en redactie.

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

## **Groepeer matches voor rapportage**

Omdat elk resultaat zijn slide‑nummer en tekstframe opslaat, kunnen toepassingen matches groeperen voor audit, rapportage of beoordelings‑workflows. Het volgende voorbeeld groepeert de verzamelde resultaten eerst per slide en daarna per tekstframe:

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

**Hoe kan ik alleen één tekstvak doorzoeken in plaats van de volledige presentatie?**

Haal het tekstframe van de vorm op en roep [ITextFrame.highlightText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), of [ITextFrame.replaceRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) op dat tekstframe. Methoden op presentatieniveau verwerken alle toepasselijke tekstframes.

**Hoe kan ik volledige woorden matchen met de juiste hoofdlettergebruik?**

Stel [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) en [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) in op `true` en geef de opties door aan een letterlijke‑tekst‑markeer‑ of -vervang‑methode. Voor reguliere expressies definieer je woordgrenzen en hoofdlettergevoeligheid in de Java‑`Pattern` zelf.

**Kunnen zoeken en vervangen ook tekst in slide‑notities omvatten?**

Ja. Stel [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) in op `true` wanneer je een letterlijke‑tekstbewerking op presentatieniveau uitvoert. De callback‑implementatie hierboven koppelt een match in een notitieslide terug aan het bijbehorende slide‑nummer.

**Hoe kan ik een rapport maken zonder de presentatie een tweede keer te scannen?**

Geef een implementatie van [IFindResultCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifindresultcallback/) door aan de markeer‑ of vervangbewerking. De callback ontvangt elke match terwijl de bewerking wordt uitgevoerd, zodat de toepassing de brontekst, de gevonden tekst, positie, tekstframe en afgeleide slide‑nummer kan opslaan voor later groeperen of exporteren.

**Behoudt het vervangen van tekst de opmaak?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) en [ITextFrame.replaceRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) wijzigen de gevonden tekst binnen het bestaande tekstframe en behouden de opmaak van de omliggende delen. Als een match zich uitstrekt over delen met verschillende opmaak, controleer dan het resultaat om zeker te zijn dat de vervanging de gewenste stijl gebruikt.