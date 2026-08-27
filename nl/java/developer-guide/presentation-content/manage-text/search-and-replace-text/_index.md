---
title: Zoeken en vervangen van tekst in PowerPoint-presentaties in Java
linktitle: Zoeken en vervangen van tekst
type: docs
weight: 55
url: /nl/java/search-and-replace-text/
keywords:
- zoektekst
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
description: "Zoek, markeer en vervang tekst in PowerPoint-presentaties terwijl u elke overeenkomst verzamelt met Aspose.Slides for Java."
---
## **Overzicht**

Aspose.Slides for Java kan zoeken, markeren en tekst vervangen in een afzonderlijk tekstframe of in de hele presentatie. Elke bewerking kan een applicatie ook via een result‑callback op de hoogte stellen van elke overeenkomst. Hierdoor kan een presentatie worden bijgewerkt en tegelijkertijd een audit‑trail worden opgebouwd met de gevonden tekst, de context, positie, tekstframe en het dia‑nummer.

Deze mogelijkheden zijn bruikbaar voor beoordeling, redactie, terminologie‑controles, sjabloonopschoning en geautomatiseerde rapportage‑workflows.

In de eerste voorbeelden hieronder gebruiken we een bestand met de naam **"sample.pptx"**, dat op de eerste dia één tekstvak bevat met de volgende tekst:

![Voorbeeldtekst](sample_text.png)

## **Kies de zoekscope**

Gebruik methoden op [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) om een bewerking te beperken tot één tekstframe. Gebruik methoden op [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) om alle toepasselijke teksten in de presentatie te verwerken.

| Operatie | Eén tekstframe | Gehele presentatie |
|---|---|---|
| Letterlijke tekst markeren | [ITextFrame.highlightText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Reguliere‑expressie‑overeenkomsten markeren | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Letterlijke tekst vervangen | [ITextFrame.replaceText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Reguliere‑expressie‑overeenkomsten vervangen | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configureer tekstmatching**

Voor operaties met letterlijke tekst, gebruik [TextSearchOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textsearchoptions/) om het matching‑gedrag te sturen:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) beperkt overeenkomsten tot complete woorden.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) bepaalt of hoofdlettergevoeligheid vereist is.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) neemt dia‑notities op in zoek-, vervang‑ en markeerbewerkingen op presentatieniveau.

Bij reguliere‑expressie‑operaties wordt een Java `Pattern` gebruikt, zodat regels zoals hoofdlettergevoeligheid en woordgrenzen worden gedefinieerd door de expressie en de bijbehorende vlaggen.

## **Identificeer de eigenaar van een tekstframe**

Generieke tekstverwerkings‑workflows ontvangen vaak een [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) tijdens zoeken, vervangen, valideren of exporteren. Gebruik [ITextFrame.getParentShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#getParentShape--) en [ITextFrame.getParentCell](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#getParentCell--) om te bepalen welk presentatie‑object eigenaar is van het tekstframe.

De verwachte waarden hangen af van de eigenaar:

| Eigenaar van tekstframe | `getParentShape` | `getParentCell` |
|---|---|---|
| Een AutoShape of een andere tekst‑behorende shape | De eigenaar‑[IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/) | `null` |
| Een tabelcel | `null` | De eigenaar‑[ICell](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icell/) |

Beide methoden bieden alleen‑lezen navigatie. Het aanroepen ervan verplaatst het tekstframe niet en verandert de eigenaar niet. Generieke code moet beide waarden op `null` controleren en rekening houden met de mogelijkheid dat geen van beide beschikbaar is.

Het volgende voorbeeld gebruikt [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) om door de tekstframes in een presentatie te itereren. Voor shapes meldt het de shapenaam, het Java‑runtime‑type en de dia waarin het zich bevindt. Voor tabelcellen meldt het de nul‑gebaseerde kolom‑ en rijcoördinaten en de bijbehorende dia.

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

Voor SmartArt‑inhoud, itereren door de shapes in [ISmartArtNode.getShapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ismartartnode/#getShapes--) en toegang krijgen tot elke [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ismartartshape/#getTextFrame--). Het tekstframe kan worden getraceerd naar de bijbehorende shape via [ITextFrame.getParentShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#getParentShape--), terwijl [ITextFrame.getParentCell](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#getParentCell--) `null` retourneert. Daarom behandelt de shape‑tak in het voorbeeld ook tekst uit SmartArt‑nodes.

## **Verzamel match‑informatie met een callback**

Implementeer [IFindResultCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifindresultcallback/) om een melding te ontvangen voor elke overeenkomst. De [IFindResultCallback.foundResult](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-)‑methode levert het gerelateerde tekstframe, de brontekst, de gevonden tekst en de positie van de match.

De callback krijgt niet rechtstreeks een dia‑nummer. De implementatie hieronder haalt het af van de bovenliggende dia en behandelt ook tekst gevonden in dia‑notities. Een nullable `Integer` maakt het mogelijk om hetzelfde resultaatmodel te gebruiken voor tekst die bij andere dia‑typen hoort.

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

Voor vervangings‑operaties bevat `foundText` de oorspronkelijke gevonden tekst, zodat de callback exact kan registreren welke termen zijn vervangen.

## **Tekst markeren**

Gebruik de [ITextFrame.highlightText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)‑methode om letterlijke‑tekst‑matches in een tekstframe te markeren. Geef een [TextSearchOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textsearchoptions/) door om de zoekopdracht te sturen en een callback om match‑details te verzamelen.

De code‑voorbeeld hieronder markeert alle voorkomen van de tekens **"try"** en daarna alleen het volledige woord **"to"**. Beide zoekopdrachten rapporteren hun matches naar dezelfde callback.

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

    // Markeer elke keer dat "try" voorkomt in het tekstframe.
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

Resultaat:

![De gemarkeerde tekst](highlighted_text.png)

## **Tekst markeren met reguliere expressies**

De [ITextFrame.highlightRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)‑methode markeert tekstmatches gevonden door een reguliere expressie in een tekstframe.

De volgende code markeert alle woorden met zeven of meer tekens en verzamelt elke match:

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

Resultaat:

![De gemarkeerde tekst met reguliere expressie](highlighted_text_using_regex.png)

## **Tekst markeren in een hele presentatie**

Gebruik [Presentation.highlightText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) en [Presentation.highlightRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) om alle toepasselijke tekstframes in een presentatie te doorzoeken. Het volgende voorbeeld markeert een letterlijk zoekterm en alle e‑mailadressen, met aparte resultaat‑collecties voor de twee zoekopdrachten.

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

## **Tekst vervangen in een tekstframe**

Gebruik [ITextFrame.replaceText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) voor letterlijke tekst en [ITextFrame.replaceRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) voor patroon‑gebaseerde vervanging. Deze methoden werken de gevonden tekst bij binnen het bestaande tekstframe, waardoor de opmaak van de omliggende delen behouden blijft in plaats van het tekstframe te herbouwen vanuit een platte string.

Het volgende voorbeeld normaliseert een spellingvariant en vervangt vervolgens versie‑labels. Dezelfde callback registreert de oorspronkelijke termen die door beide operaties zijn gematcht.

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

Als één match delen met verschillende opmaak bestrijkt, controleer dan de uitvoer om te bevestigen welke opmaak moet worden toegepast op de vervangende tekst.

## **Tekst vervangen in een hele presentatie**

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

## **Matches groeperen voor rapportage**

Omdat elk resultaat zijn dia‑nummer en tekstframe opslaat, kunnen applicaties matches groeperen voor audit‑, rapportage‑ of review‑workflows. Het volgende voorbeeld groepeert de verzamelde resultaten eerst per dia en daarna per tekstframe:

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

**Hoe kan ik zoeken in slechts één tekstvak in plaats van de hele presentatie?**

Haal het tekstframe van de shape op en roep [ITextFrame.highlightText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) of [ITextFrame.replaceRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) aan dat tekstframe aan. Methoden op presentatieniveau verwerken alle toepasselijke tekstframes.

**Hoe kan ik volledige woorden matchen met de juiste hoofdlettergebruik?**

Stel [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) en [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) in op `true` en geef de opties door aan een markeer‑ of vervang‑methode voor letterlijke tekst. Voor reguliere expressies definieer je woordgrenzen en hoofdlettergevoeligheid in de Java `Pattern` zelf.

**Kunnen zoek‑ en vervang‑bewerkingen teksten in dia‑notities omvatten?**

Ja. Stel [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) in op `true` wanneer je een presentatie‑brede bewerking voor letterlijke tekst gebruikt. De callback‑implementatie hierboven mappt een match in een notitieslide terug naar het bijbehorende dia‑nummer.

**Hoe kan ik een rapport maken zonder de presentatie een tweede keer te scannen?**

Geef een [IFindResultCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifindresultcallback/)‑implementatie mee aan de markeer‑ of vervang‑bewerking. De callback ontvangt elke match terwijl de bewerking wordt uitgevoerd, zodat de applicatie de brontekst, gevonden tekst, positie, tekstframe en afgeleid dia‑nummer kan opslaan voor latere groepering of export.

**Behoudt vervangen van tekst de opmaak?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) en [ITextFrame.replaceRegex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) wijzigen de gevonden tekst binnen het bestaande tekstframe en behouden de opmaak van de omringende delen. Als een match delen met verschillende opmaak bestrijkt, controleer dan het resultaat om er zeker van te zijn dat de vervanging de gewenste stijl gebruikt.