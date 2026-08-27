---
title: Zoeken en vervangen van tekst in PowerPoint-presentaties op Android
linktitle: Zoeken en vervangen tekst
type: docs
weight: 55
url: /nl/androidjava/search-and-replace-text/
keywords:
- tekst zoeken
- tekst markeren
- tekst vervangen
- reguliere expressie
- resultaat callback
- tekstkader
- auditrapport
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Zoek, markeer en vervang tekst in PowerPoint-presentaties en verzamel elke overeenkomst met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Aspose.Slides for Android via Java kan tekst zoeken, markeren en vervangen in een enkel tekstkader of in de gehele presentatie. Elke bewerking kan ook een applicatie op de hoogte stellen van elke overeenkomst via een resultcallback. Hierdoor is het mogelijk om een presentatie bij te werken en tegelijkertijd een audittrail op te bouwen met de gevonden tekst, de context, positie, het tekstkader en het dia‑nummer.

Deze mogelijkheden zijn nuttig voor review, redactie, terminologiewaarden, sjabloonopschoning en geautomatiseerde rapportage‑workflows.

In de eerste voorbeelden hieronder gebruiken we een bestand genaamd "sample.pptx", dat een enkel tekstvak op de eerste dia bevat met de volgende tekst:

![Sample text](sample_text.png)

## **Kies het zoekbereik**

Gebruik methoden op [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) om een bewerking te beperken tot één tekstkader. Gebruik methoden op [IPresentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/) om alle toepasselijke tekst in de presentatie te verwerken.

| Bewerking | Eén tekstkader | Gehele presentatie |
|---|---|---|
| Markeer letterlijke tekst | [ITextFrame.highlightText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Markeer reguliere‑expressie‑overeenkomsten | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Vervang letterlijke tekst | [ITextFrame.replaceText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Vervang reguliere‑expressie‑overeenkomsten | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Tekstmatching configureren**

Voor bewerkingen met letterlijke tekst, gebruik [TextSearchOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textsearchoptions/) om het overeenkomen te regelen:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) beperkt overeenkomsten tot volledige woorden.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) bepaalt of hoofdlettergebruik moet overeenkomen.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) neemt dia‑notities op in zoek-, vervang- en markeerbewerkingen op presentatieniveau.

Reguliere‑expressie‑bewerkingen gebruiken een Java `Pattern`, waardoor overeenkomstruulen zoals hoofdlettergevoeligheid en woordgrenzen worden bepaald door de expressie en de bijbehorende vlaggen.

## **Identificeer de eigenaar van een tekstkader**

Algemene tekstverwerkingsworkflows ontvangen vaak een [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) tijdens zoeken, vervangen, valideren of exporteren. Gebruik [ITextFrame.getParentShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#getParentShape--) en [ITextFrame.getParentCell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#getParentCell--) om te bepalen welk presentatie‑object het tekstkader bezit.

De verwachte waarden hangen af van de eigenaar:

| Eigenaar van tekstkader | `getParentShape` | `getParentCell` |
|---|---|---|
| Een AutoShape of een andere vorm die tekst bevat | De bezitende [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/) | `null` |
| Een tabelcel | `null` | De bezitende [ICell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icell/) |

Beide methoden bieden alleen‑lezen‑navigatie. Het aanroepen ervan verplaatst het tekstkader niet en wijzigt de eigenaar niet. Generieke code moet beide waarden op `null` controleren en rekening houden met de mogelijkheid dat geen van beide beschikbaar is.

Het volgende voorbeeld gebruikt [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) om door de tekstkaders in een presentatie te itereren. Voor vormen meldt het de vormnaam, Java‑runtime‑type en de bijbehorende dia. Voor tabelcellen meldt het de nul‑gebaseerde kolom‑ en rijcoördinaten en de bijbehorende dia.

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

Voor SmartArt‑inhoud itereren we door de vormen in [ISmartArtNode.getShapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ismartartnode/#getShapes--) en benaderen we elke [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--). Het tekstkader kan worden getraceerd naar de bijbehorende vorm via [ITextFrame.getParentShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#getParentShape--), terwijl [ITextFrame.getParentCell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#getParentCell--) `null` retourneert. Daarom behandelt de vorm‑tak in het voorbeeld ook tekst uit SmartArt‑knopen.

## **Verzamel overeenkomstinformatie met een callback**

Implementeer [IFindResultCallback](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifindresultcallback/) om een melding te ontvangen voor elke overeenkomst. Zijn [IFindResultCallback.foundResult](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-)‑methode levert het betreffende tekstkader, de brontekst, de gevonden tekst en de positie van de overeenkomst.

De callback ontvangt geen dia‑nummer direct. De implementatie hieronder leidt dit af van de bovenliggende dia en verwerkt ook tekst die in dia‑notities is gevonden. Een nullable `Integer` maakt het mogelijk om hetzelfde resultaatsmodel te gebruiken voor tekst die gekoppeld is aan andere dia‑typen.

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

Voor vervang‑bewerkingen bevat `foundText` de oorspronkelijke gevonden tekst, zodat de callback precies kan registreren welke termen zijn vervangen.

## **Tekst markeren**

Gebruik de [ITextFrame.highlightText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)‑methode om letterlijke‑tekst‑overeenkomsten in een tekstkader te markeren. Geef [TextSearchOptions] door om de zoekopdracht te regelen en een callback om match‑details te verzamelen.

De code‑voorbeeld hieronder markeert alle voorkomens van de tekens **"try"** en markeert daarna alleen het volledige woord **"to"**. Beide zoekopdrachten rapporteren hun matches aan dezelfde callback.

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

    // Markeer elk voorkomen van "try" in het tekstkader.
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

![The highlighted text](highlighted_text.png)

## **Tekst markeren met reguliere expressies**

De [ITextFrame.highlightRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-)‑methode markeert tekstmatches die gevonden worden door een reguliere expressie in een tekstkader.

De volgende code markeert alle woorden die zeven of meer tekens bevatten en verzamelt elke match:

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

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Tekst markeren in een presentatie**

Gebruik [IPresentation.highlightText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) en [IPresentation.highlightRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) om alle toepasselijke tekstkaders in een presentatie te doorzoeken. Het volgende voorbeeld markeert een letterlijke term en alle e‑mailadressen, terwijl het afzonderlijke resultaatsverzamelingen bijhoudt voor de twee zoekopdrachten.

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

## **Tekst vervangen in een tekstkader**

Gebruik [ITextFrame.replaceText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) voor letterlijke tekst en [ITextFrame.replaceRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) voor patroongebaseerde vervanging. Deze methoden werken de gevonden tekst bij binnen het bestaande tekstkader, waardoor de opmaak van de omringende delen behouden blijft in plaats van het tekstkader opnieuw op te bouwen vanuit een eenvoudige string.

Het volgende voorbeeld standaardiseert een spellingvariant en vervangt daarna versie‑labels. Dezelfde callback registreert de oorspronkelijke termen die door beide bewerkingen zijn gevonden.

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

Als één match delen met verschillende opmaak bestrijkt, controleer dan de output om te bevestigen welke opmaak op de vervangende tekst moet worden toegepast.

## **Tekst vervangen in een presentatie**

Gebruik [IPresentation.replaceText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) en [IPresentation.replaceRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) om dezelfde bewerkingen over de hele presentatie toe te passen. Dit is handig voor sjabloonopschoning, terminologie‑updates en redactie.

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

Omdat elk resultaat zijn dia‑nummer en tekstkader opslaat, kunnen applicaties matches groeperen voor audit, rapportage of review‑workflows. Het volgende voorbeeld groepeert de verzamelde resultaten eerst per dia en daarna per tekstkader:

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

**Hoe kan ik slechts één tekstvak doorzoeken in plaats van de hele presentatie?**

Haal het tekstkader van de vorm op en roep [ITextFrame.highlightText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), of [ITextFrame.replaceRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) op dat tekstkader. Methodes op presentatieniveau verwerken alle toepasselijke tekstkaders.

**Hoe kan ik volledige woorden matchen met de juiste hoofdlettergebruik?**

Stel [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) en [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) in op `true` en geef de opties door aan een letterlijke‑tekst‑markeer‑ of vervangingsmethode. Voor reguliere expressies definieer je woordgrenzen en hoofdlettergevoeligheid in de Java `Pattern` zelf.

**Kunnen zoek‑ en vervangbewerkingen tekst in dia‑notities omvatten?**

Ja. Stel [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) in op `true` wanneer je een letterlijke‑tekst‑bewerking op presentatieniveau uitvoert. De callback‑implementatie hierboven mappt een match in een notitiedia terug naar het bijbehorende dia‑nummer.

**Hoe kan ik een rapport maken zonder de presentatie een tweede keer te doorzoeken?**

Geef een [IFindResultCallback](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifindresultcallback/)‑implementatie mee aan de markeer‑ of vervangingsbewerking. De callback ontvangt elke match terwijl de bewerking loopt, zodat de applicatie brontekst, gevonden tekst, positie, tekstkader en afgeleid dia‑nummer kan opslaan voor later groeperen of exporteren.

**Behoudt het vervangen van tekst de opmaak?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) en [ITextFrame.replaceRegex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) wijzigen de gevonden tekst binnen het bestaande tekstkader en behouden de opmaak van de omringende delen. Als een match delen met verschillende opmaak bestrijkt, controleer dan het resultaat om te bevestigen dat de vervanging de gewenste stijl gebruikt.