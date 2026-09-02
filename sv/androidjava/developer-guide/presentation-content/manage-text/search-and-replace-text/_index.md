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
- resultat‑callback
- textruta
- revisionsrapport
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Sök, markera och ersätt text i PowerPoint-presentationer medan du samlar varje matchning med Aspose.Slides för Android via Java."
---
## **Översikt**

Aspose.Slides för Android via Java kan söka, markera och ersätta text i en enskild textruta eller i hela presentationen. Varje operation kan även meddela en applikation om varje träff via ett resultat‑callback. Detta gör det möjligt att uppdatera en presentation och samtidigt bygga ett revisionsspår som innehåller den matchade texten, dess sammanhang, position, textramar och bildnummer.

Dessa funktioner är användbara för granskning, redigering, terminologikontroller, mallrengöring och automatiserade rapporteringsarbetsflöden.

I de första exemplen nedan använder vi en fil som heter "sample.pptx", vilken innehåller en enda textruta på den första bilden med följande text:

![Exempeltext](sample_text.png)

## **Välj sökomfattning**

Använd metoder på [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/) för att begränsa en operation till en textruta. Använd metoder på [IPresentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/) för att bearbeta all tillämplig text i presentationen.

| Operation | En textruta | Hela presentationen |
|---|---|---|
| Markera exakt text | [ITextFrame.highlightText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Markera reguljära‑uttrycks‑träffar | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Ersätt exakt text | [ITextFrame.replaceText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Ersätt reguljära‑uttrycks‑träffar | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Konfigurera textmatchning**

För exakta‑textoperationer, använd [TextSearchOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textsearchoptions/) för att styra matchning:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) begränsar träffar till hela ord.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) styr om teckenens skiftläge måste matcha.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) inkluderar bildanteckningar i sök‑, ersättnings‑ och markeringsoperationer på presentationsnivå.

Reguljära‑uttrycks‑operationer använder ett Java `Pattern`, så matchningsregler såsom skiftlägeskänslighet och ordgränser definieras av själva uttrycket och dess flaggor.

## **Identifiera ägaren till en textruta**

Generiska textbearbetnings‑arbetsflöden får ofta en [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/) när de söker, ersätter, validerar eller exporterar text. Använd [ITextFrame.getParentShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#getParentShape--) och [ITextFrame.getParentCell](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#getParentCell--) för att avgöra vilket presentationsobjekt som äger textrutan.

De förväntade värdena beror på ägaren:

| Ägare av textruta | `getParentShape` | `getParentCell` |
|---|---|---|
| En AutoShape eller en annan text‑innehållande form | Den ägande [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/) | `null` |
| En tabellcell | `null` | Den ägande [ICell](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icell/) |

Båda metoderna ger skrivskyddad navigation. Att anropa dem flyttar inte textrutan eller ändrar dess ägare. Generisk kod bör kontrollera båda värdena för `null` och hantera möjligheten att ingen ägare är tillgänglig.

Följande exempel använder [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) för att iterera genom textramarna i en presentation. För former rapporteras formens namn, Java‑körningstyp och innehållande bild. För tabellceller rapporteras de noll‑baserade kolumn‑ och rad‑koordinaterna samt den innehållande bilden.

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

För SmartArt‑innehåll, iterera genom formerna i [ISmartArtNode.getShapes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ismartartnode/#getShapes--) och nå varje [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--). Textrutan kan spåras till sin associerade form via [ITextFrame.getParentShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#getParentShape--), medan [ITextFrame.getParentCell](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#getParentCell--) returnerar `null`. Därför hanterar formgrenen i exemplet även text från SmartArt‑noder.

## **Samla matchningsinformation med en återuppringning**

Implementera [IFindResultCallback](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifindresultcallback/) för att få en avisering för varje matchning. Dess metod [IFindResultCallback.foundResult](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) tillhandahåller den relaterade textramen, källtexten, den matchade texten och matchningspositionen.

Återuppringningen får inte ett bildnummer direkt. Implementeringen nedan härleder det från den överordnade bilden och hanterar även text som hittas i bildanteckningar. En nullable `Integer` gör det möjligt att använda samma resultatsmodell för text som är kopplad till andra bildtyper.

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

För ersättningsoperationer innehåller `foundText` den ursprungliga matchade texten, så återuppringningen kan registrera exakt vilka termer som ersattes.

## **Markera text**

Använd metoden [ITextFrame.highlightText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) för att markera exakta‑text‑träffar i en textruta. Skicka in ett [TextSearchOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textsearchoptions/) för att styra sökningen och ett callback för att samla matchningsdetaljer.

Kodexemplet nedan markerar alla förekomster av tecknen **"try"** och markerar sedan endast hela ordet **"to"**. Båda sökningarna rapporterar sina träffar till samma callback.

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

Metoden [ITextFrame.highlightRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) markerar textträffar som hittats av ett reguljärt uttryck i en textruta.

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

![Den markerade texten med reguljära uttrycket](highlighted_text_using_regex.png)

## **Markera text i hela presentationen**

Använd [IPresentation.highlightText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) och [IPresentation.highlightRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) för att söka i alla tillämpliga textramar i en presentation. Följande exempel markerar ett exakt uttryck och alla e‑postadresser samtidigt som separata resultat‑samlingar hålls för de två sökningarna.

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

## **Ersätt text i en textruta**

Använd [ITextFrame.replaceText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) för exakt text och [ITextFrame.replaceRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) för mönster‑baserad ersättning. Dessa metoder uppdaterar matchad text inom den befintliga textramen, vilket bevarar formateringen i de omgivande delarna istället för att bygga om textramen från en ren sträng.

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

Om en matchning sträcker sig över delar med olika formatering, granska resultatet för att bekräfta vilken formatering som ska tillämpas på den ersatta texten.

## **Ersätt text i hela presentationen**

Använd [IPresentation.replaceText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) och [IPresentation.replaceRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) för att utföra samma operationer i hela presentationen. Detta är användbart för mallrengöring, terminologiska uppdateringar och redigering.

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

Eftersom varje resultat lagrar sitt bildnummer och sin textruta kan program gruppera matchningar för revision, rapportering eller granskningsarbetsflöden. Följande exempel grupperar de insamlade resultaten först efter bild och sedan efter textruta:

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

**Hur kan jag söka bara i en textruta istället för i hela presentationen?**

Hämta formens textruta och anropa [ITextFrame.highlightText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), eller [ITextFrame.replaceRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) på den textrutan. Metoder på presentationsnivå bearbetar alla tillämpliga textramar istället.

**Hur kan jag matcha hela ord med korrekt stora/små bokstäver?**

Sätt [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) och [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) till `true` och skicka alternativen till en exakt‑text‑markerings‑ eller ersättningsmetod. För reguljära uttryck definierar du ordgränser och skiftlägeskänslighet i själva Java `Pattern`.

**Kan sökning och ersättning inkludera text i bildanteckningar?**

Ja. Sätt [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) till `true` när du använder en presentations‑nivå operation för exakt text. Callback‑implementationen ovan kartlägger en matchning i en anteckningsbild tillbaka till dess överordnade bildnummer.

**Hur kan jag skapa en rapport utan att skanna presentationen en andra gång?**

Skicka en [IFindResultCallback](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifindresultcallback/)‑implementation till markerings‑ eller ersättningsoperationen. Callback‑metoden får varje matchning medan operationen kör, så applikationen kan lagra källtext, matchad text, position, textruta och härledd bildnummer för senare gruppering eller export.

**Behåller ersatt text sin formatering?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) och [ITextFrame.replaceRegex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modifierar den matchade texten inom den befintliga textramen och behåller formateringen i de omgivande delarna. Om en matchning sträcker sig över delar med olika formatering, inspektera resultatet för att säkerställa att ersättningen använder önskad stil.