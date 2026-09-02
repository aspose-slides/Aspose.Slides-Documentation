---
title: Zoeken en vervangen van tekst in PowerPoint‑presentaties op Android
linktitle: Zoeken en vervangen van tekst
type: docs
weight: 55
url: /nl/androidjava/search-and-replace-text/
keywords:
- tekst zoeken
- tekst markeren
- tekst vervangen
- reguliere expressie
- resultaatcallback
- tekstframe
- auditrapport
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Zoeken, markeren en vervangen van tekst in PowerPoint‑presentaties terwijl elke overeenkomst wordt verzameld met Aspose.Slides for Android via Java."
---
## **Overzicht**

Aspose.Slides for Android via Java kan tekst zoeken, markeren en vervangen in een enkel tekstframe of in een volledige presentatie. Elke bewerking kan ook een applicatie op de hoogte stellen van elke overeenkomst via een result-callback. Hierdoor is het mogelijk een presentatie bij te werken en tegelijk een auditspoor op te bouwen met de overeenkomstige tekst, de context, positie, het tekstframe en het slide‑nummer.

Deze mogelijkheden zijn nuttig voor beoordeling, redactie, terminologiecontroles, het opschonen van sjablonen en geautomatiseerde rapportage‑workflows.

In de eerste voorbeelden hieronder gebruiken we een bestand met de naam "sample.pptx", dat één tekstvak bevat op de eerste slide met de volgende tekst:

![Voorbeeldtekst](sample_text.png)

## **Kies de zoekreikwijdte**

Gebruik methoden op [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) om een bewerking te beperken tot één tekstframe. Gebruik methoden op [IPresentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/) om alle toepasbare tekst in de presentatie te verwerken.

| Bewerking | Eén tekstframe | Gehele presentatie |
|---|---|---|
| Markeer letterlijke tekst | [ITextFrame.highlightText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Markeer reguliere‑expressie‑overeenkomsten | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Vervang letterlijke tekst | [ITextFrame.replaceText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Vervang reguliere‑expressie‑overeenkomsten | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configureer tekstmatching**

Voor operaties met letterlijke tekst, gebruik [TextSearchOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textsearchoptions/) om het zoeken te beheersen:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) beperkt overeenkomsten tot complete woorden.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) bepaalt of hoofdlettergevoeligheid vereist is.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) neemt slidennotities op in zoeken, vervangen en markeren op presentatieniveau.

Operaties met reguliere expressies gebruiken een Java `Pattern`, dus overeenkomstre­gels zoals hoofdlettergevoeligheid en woordgrenzen worden bepaald door de expressie en de bijbehorende vlaggen.

## **Verzamel overeenkomst‑informatie met een callback**

Implementeer [IFindResultCallback](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifindresultcallback/) om een melding te ontvangen voor elke overeenkomst. Zijn [IFindResultCallback.foundResult](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-)‑methode geeft het gerelateerde tekstframe, de brontekst, de gevonden tekst en de positie van de overeenkomst.

De callback ontvangt niet rechtstreeks een slide‑nummer. De implementatie hieronder haalt het af van de bovenliggende slide en verwerkt ook tekst gevonden in slidennotities. Een nullable `Integer` maakt het mogelijk hetzelfde result‑model te gebruiken voor tekst die aan andere slide‑typen is gekoppeld.

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

Voor vervang‑operaties bevat `foundText` de oorspronkelijke gevonden tekst, zodat de callback precies kan registreren welke termen zijn vervangen.

## **Markeer tekst**

Gebruik de [ITextFrame.highlightText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)‑methode om letterlijke‑tekst‑overeenkomsten in een tekstframe te markeren. Geef [TextSearchOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textsearchoptions/) door om het zoeken te sturen en een callback om de details van de overeenkomsten te verzamelen.

De code‑voorbeeld hieronder markeert alle voorkomens van de tekens **"try"** en vervolgens alleen het volledige woord **"to"**. Beide zoekacties melden hun overeenkomsten aan dezelfde callback.

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

    // Markeer elke verschijning van "try" in het tekstframe.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

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

## **Tekst markeren met reguliere expressies**

De [ITextFrame.highlightRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-)‑methode markeert tekstovereenkomsten die door een reguliere expressie worden gevonden in een tekstframe.

De volgende code markeert alle woorden met zeven of meer tekens en verzamelt elke overeenkomst:

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

Het resultaat:

![De met reguliere expressie gemarkeerde tekst](highlighted_text_using_regex.png)

## **Tekst markeren over een presentatie**

Gebruik [IPresentation.highlightText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) en [IPresentation.highlightRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) om alle toepasselijke tekstframes in een presentatie te doorzoeken. Het volgende voorbeeld markeert een letterlijke term en alle e‑mailadressen, met afzonderlijke resultaatsverzamelingen voor de twee zoekacties.

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

## **Tekst vervangen in een tekstframe**

Gebruik [ITextFrame.replaceText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) voor letterlijke tekst en [ITextFrame.replaceRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) voor op patroon gebaseerde vervanging. Deze methoden werken de gevonden tekst bij binnen het bestaande tekstframe, waardoor de omliggende formattering behouden blijft i.p.v. het tekstframe opnieuw op te bouwen van een platte string.

Het volgende voorbeeld uniformiseert een spellingvariant en vervangt vervolgens versie‑labels. Dezelfde callback registreert de oorspronkelijke termen die door beide operaties zijn gevonden.

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

Als één overeenkomst delen van verschillende opmaak omvat, controleer dan de output om te bevestigen welke opmaak moet worden toegepast op de vervangende tekst.

## **Tekst vervangen over een presentatie**

Gebruik [IPresentation.replaceText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) en [IPresentation.replaceRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) om dezelfde bewerkingen toe te passen op de volledige presentatie. Dit is nuttig voor het opschonen van sjablonen, terminologie‑updates en redactie.

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

## **Groepeer overeenkomsten voor rapportage**

Omdat elk resultaat het slide‑nummer en het tekstframe opslaat, kunnen applicaties overeenkomsten groeperen voor audit, rapportage of beoordelings‑workflows. Het volgende voorbeeld groepeert de verzamelde resultaten eerst per slide en daarna per tekstframe:

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

**Hoe kan ik slechts één tekstvak doorzoeken in plaats van de volledige presentatie?**

Haal het tekstframe van de vorm op en roep [ITextFrame.highlightText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), of [ITextFrame.replaceRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) op dat tekstframe. Methoden op presentatieniveau verwerken alle toepasselijke tekstframes.

**Hoe kan ik volledige woorden met de juiste hoofdletters vinden?**

Stel [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) en [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) in op `true` en geef de opties door aan een letterlijke‑tekst‑markeer‑ of vervang‑methode. Voor reguliere expressies definieer je woordgrenzen en hoofdlettergevoeligheid in de Java `Pattern` zelf.

**Kunnen zoeken en vervangen tekst in slidennotities omvatten?**

Ja. Stel [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) in op `true` bij een presentatieniveau‑operatie met letterlijke tekst. De callback‑implementatie hierboven koppelt een overeenkomst in een notitieslide terug aan het bovenliggende slide‑nummer.

**Hoe kan ik een rapport maken zonder de presentatie een tweede keer te scannen?**

Geef een [IFindResultCallback](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifindresultcallback/)‑implementatie door aan de markeer‑ of vervang‑operatie. De callback ontvangt elke overeenkomst terwijl de bewerking loopt, zodat de applicatie brontekst, gevonden tekst, positie, tekstframe en afgeleid slide‑nummer kan opslaan voor latere groepering of export.

**Behoudt het vervangen van tekst de opmaak?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) en [ITextFrame.replaceRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) wijzigen de gevonden tekst binnen het bestaande tekstframe en behouden de omliggende opmaak. Als een overeenkomst delen met verschillende opmaak beslaat, controleer dan het resultaat om te verzekeren dat de vervanging de gewenste stijl gebruikt.