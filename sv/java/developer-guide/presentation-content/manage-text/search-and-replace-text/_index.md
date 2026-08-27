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
- resultatåteranrop
- textram
- revisionsrapport
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Sök, markera och ersätt text i PowerPoint-presentationer samtidigt som du samlar varje matchning med Aspose.Slides för Java."
---
## **Översikt**

Aspose.Slides for Java kan söka, markera och ersätta text i en enskild textram eller i hela en presentation. Varje operation kan också meddela en applikation om varje matchning via ett resultatrückanrop. Detta gör det möjligt att uppdatera en presentation och samtidigt bygga ett revisionsspår som innehåller den matchade texten, dess sammanhang, position, textram och bildnummer.

Dessa funktioner är användbara för granskning, redigering, terminologikontroller, rensning av mallar och automatiserade rapporteringsarbetsflöden.

I de första exemplen nedan använder vi en fil med namnet "sample.pptx", som innehåller en enda textruta på den första bilden med följande text:

![Sample text](sample_text.png)

## **Välj sökomfång**

Använd metoder på [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/) för att begränsa en operation till en textram. Använd metoder på [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) för att bearbeta all tillämplig text i presentationen.

| Operation | En textram | Hela presentationen |
|---|---|---|
| Highlight literal text | [ITextFrame.highlightText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular-expression matches | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [ITextFrame.replaceText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular-expression matches | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Konfigurera textmatchning**

För operationer med bokstavlig text, använd [TextSearchOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textsearchoptions/) för att styra matchning:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) begränsar matchningar till hela ord.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) styr om teckenens versal-/gemener måste matcha.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) inkluderar bildanteckningar i sök, ersättning och markeringsoperationer på presentationsnivå.

Operationer med reguljära uttryck använder en Java `Pattern`, så regler som skiftlägeskänslighet och ordgränser definieras av uttrycket och dess flaggor.

## **Identifiera ägaren till en textram**

Generiska textbehandlingsarbetsflöden får ofta en [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/) medan de söker, ersätter, validerar eller exporterar text. Använd [ITextFrame.getParentShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#getParentShape--) och [ITextFrame.getParentCell](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#getParentCell--) för att avgöra vilket presentationsobjekt som äger textramen.

De förväntade värdena beror på ägaren:

| Ägare av textram | `getParentShape` | `getParentCell` |
|---|---|---|
| En AutoShape eller en annan textinnehållande form | Den ägande [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/) | `null` |
| En tabellcell | `null` | Den ägande [ICell](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icell/) |

Båda metoderna ger skrivskyddad navigation. Att anropa dem flyttar inte textramen eller ändrar dess ägare. Generisk kod bör kontrollera båda värdena för `null` och hantera att ingen ägare finns tillgänglig.

Följande exempel använder [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) för att iterera genom textramarna i en presentation. För former rapporteras formens namn, Javas körtidstyp och den innehållande bilden. För tabellceller rapporteras kolumn‑ och radräckning (nollbaserad) samt den innehållande bilden.

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

För SmartArt‑innehåll itereras genom formerna i [ISmartArtNode.getShapes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ismartartnode/#getShapes--) och varje [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ismartartshape/#getTextFrame--) nås. Textramen kan spåras till sin associerade form via [ITextFrame.getParentShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#getParentShape--), medan [ITextFrame.getParentCell](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#getParentCell--) returnerar `null`. Därför hanterar formgrenen i exemplet även text från SmartArt‑noder.

## **Samla matchningsinformation med ett återanrop**

Implementera [IFindResultCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifindresultcallback/) för att få en avisering för varje matchning. Dess metod [IFindResultCallback.foundResult](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) tillhandahåller den relaterade textramen, källtexten, den matchade texten och matchningspositionen.

Återanropet får inte bildnumret direkt. Implementeringen nedan hämtar det från den överordnade bilden och hanterar även text som hittas i bildanteckningar. En nullable `Integer` möjliggör att samma resultatmodell representerar text kopplad till andra bildtyper.

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

För ersättningsoperationer innehåller `foundText` den ursprungliga matchade texten, så återanropet kan exakt registrera vilka termer som ersattes.

## **Markera text**

Använd metoden [ITextFrame.highlightText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) för att markera bokstavliga matchningar i en textram. Skicka [TextSearchOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textsearchoptions/) för att styra sökningen och ett återanrop för att samla matchningsdetaljer.

Kodexemplet nedan markerar alla förekomster av tecknen **"try"** och markerar sedan endast hela ordet **"to"**. Båda sökningarna rapporterar sina matchningar till samma återanrop.

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

    // Markera varje förekomst av "try" i textramen.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

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

![The highlighted text](highlighted_text.png)

## **Markera text med reguljära uttryck**

Metoden [ITextFrame.highlightRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) markerar textmatchningar som hittas av ett reguljärt uttryck i en textram.

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

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Markera text i hela presentationen**

Använd [Presentation.highlightText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) och [Presentation.highlightRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) för att söka i alla tillämpliga textramar i en presentation. Följande exempel markerar ett bokstavligt uttryck och alla e‑postadresser samtidigt som resultatsamlingarna hålls separata för de två sökningarna.

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

## **Ersätt text i en textram**

Använd [ITextFrame.replaceText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) för bokstavlig text och [ITextFrame.replaceRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) för mönsterbaserad ersättning. Dessa metoder uppdaterar den matchade texten inom den befintliga textramen, som behåller formatering på omgivande delar istället för att bygga om textramen från en ren sträng.

Följande exempel standardiserar en stavningsvariant och ersätter sedan versionsetiketter. Samma återanrop registrerar de ursprungliga termerna som matchades av båda operationerna.

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

Om en matchning sträcker sig över delar med olika formatering, granska resultatet för att bekräfta vilken formatering som ska tillämpas på den ersatta texten.

## **Ersätt text i hela presentationen**

Använd [Presentation.replaceText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) och [Presentation.replaceRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) för att tillämpa samma operationer i hela presentationen. Detta är användbart för mallrengöring, terminologiska uppdateringar och rödigering.

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

Eftersom varje resultat lagrar bildnummer och textram kan applikationer gruppera matchningar för revision, rapportering eller granskningsarbetsflöden. Följande exempel grupperar de insamlade resultaten först per bild och sedan per textram:

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

**Hur kan jag söka i endast en textruta istället för hela presentationen?**

Hämta formens textram och anropa [ITextFrame.highlightText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), eller [ITextFrame.replaceRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) på den textramen. Metoder på presentationsnivå bearbetar alla tillämpliga textramar istället.

**Hur kan jag matcha hela ord med korrekt versalisering?**

Sätt [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) och [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) till `true` och skicka alternativen till en markerings‑ eller ersättningsmetod för bokstavlig text. För reguljära uttryck definierar du ordgränser och skiftlägeskänslighet i själva Java `Pattern`.

**Kan sökning och ersättning inkludera text i bildanteckningar?**

Ja. Sätt [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) till `true` när du använder en presentationsnivå‑operation för bokstavlig text. Återanropsimplementeringen ovan mappar en matchning i en not‑bild tillbaka till dess överordnade bildnummer.

**Hur kan jag skapa en rapport utan att skanna presentationen en andra gång?**

Skicka en [IFindResultCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifindresultcallback/)‑implementation till markerings‑ eller ersättningsoperationen. Återanropet får varje matchning medan operationen körs, så applikationen kan lagra källtext, matchad text, position, textram och härledda bildnummer för senare gruppering eller export.

**Behåller ersättning av text dess formatering?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) och [ITextFrame.replaceRegex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modifierar den matchade texten inom den befintliga textramen och behåller formatering på omgivande delar. Om en matchning sträcker sig över segment med olika formatering, inspektera resultatet för att säkerställa att ersättningen använder önskad stil.