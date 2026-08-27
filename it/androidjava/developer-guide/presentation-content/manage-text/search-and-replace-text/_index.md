---
title: Cerca e sostituisci testo nelle presentazioni PowerPoint su Android
linktitle: Cerca e sostituisci testo
type: docs
weight: 55
url: /it/androidjava/search-and-replace-text/
keywords:
- ricerca testo
- evidenzia testo
- sostituisci testo
- espressione regolare
- callback risultato
- frame di testo
- rapporto di audit
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Cerca, evidenzia e sostituisci testo nelle presentazioni PowerPoint raccogliendo ogni corrispondenza con Aspose.Slides per Android via Java."
---
## **Panoramica**

Aspose.Slides for Android via Java può cercare, evidenziare e sostituire testo in un singolo frame di testo o in tutta la presentazione. Ogni operazione può anche notificare un’applicazione per ogni occorrenza tramite un callback di risultato. Questo consente di aggiornare una presentazione e contemporaneamente creare una traccia di audit contenente il testo trovato, il suo contesto, la posizione, il frame di testo e il numero della diapositiva.

Queste funzionalità sono utili per revisioni, redazioni, controlli di terminologia, pulizia di template e flussi di lavoro di reportistica automatizzata.

Nei primi esempi seguenti, utilizziamo un file denominato **“sample.pptx”**, che contiene una singola casella di testo nella prima diapositiva con il seguente contenuto:

![Sample text](sample_text.png)

## **Scegli l’ambito di ricerca**

Usa i metodi su [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) per limitare un’operazione a un singolo frame di testo. Usa i metodi su [IPresentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentation/) per elaborare tutto il testo applicabile nella presentazione.

| Operazione | Un frame di testo | Intera presentazione |
|---|---|---|
| Evidenzia testo letterale | [ITextFrame.highlightText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Evidenzia corrispondenze di espressione regolare | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Sostituisci testo letterale | [ITextFrame.replaceText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Sostituisci corrispondenze di espressione regolare | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configura la corrispondenza del testo**

Per le operazioni su testo letterale, usa [TextSearchOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textsearchoptions/) per controllare la corrispondenza:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) limita le corrispondenze a parole intere.  
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) controlla se il caso dei caratteri deve corrispondere.  
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) include le note delle diapositive nelle operazioni di ricerca, sostituzione ed evidenziazione a livello di presentazione.

Le operazioni con espressioni regolari utilizzano un `Pattern` Java, quindi regole come la sensibilità al maiuscolo/minuscolo e i confini di parola sono definite dall’espressione e dai suoi flag.

## **Identifica il proprietario di un frame di testo**

I flussi di lavoro generici di elaborazione testo ricevono spesso un [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) durante la ricerca, la sostituzione, la validazione o l’esportazione del testo. Usa [ITextFrame.getParentShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#getParentShape--) e [ITextFrame.getParentCell](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#getParentCell--) per determinare quale oggetto della presentazione possiede il frame di testo.

I valori attesi dipendono dal proprietario:

| Proprietario del frame di testo | `getParentShape` | `getParentCell` |
|---|---|---|
| Un AutoShape o un’altra forma contenente testo | Il [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/) proprietario | `null` |
| Una cella di tabella | `null` | Il [ICell](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icell/) proprietario |

Entrambi i metodi forniscono una navigazione in sola lettura. Chiamarli non sposta il frame di testo né ne cambia il proprietario. Il codice generico dovrebbe verificare entrambi i valori per `null` e gestire la possibilità che nessuno dei due sia disponibile.

L’esempio seguente utilizza [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) per iterare i frame di testo in una presentazione. Per le forme, riporta il nome della forma, il tipo Java di runtime e la diapositiva contenitrice. Per le celle di tabella, riporta le coordinate di colonna e riga (indice zero) e la diapositiva contenitrice.

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

Per i contenuti SmartArt, itera le forme in [ISmartArtNode.getShapes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ismartartnode/#getShapes--) e accedi a ciascuna [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--). Il frame di testo può essere ricondotto alla sua forma associata tramite [ITextFrame.getParentShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#getParentShape--), mentre [ITextFrame.getParentCell](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#getParentCell--) restituisce `null`. Pertanto, il ramo della forma nell’esempio gestisce anche il testo proveniente da nodi SmartArt.

## **Raccogli informazioni sulla corrispondenza con un callback**

Implementa [IFindResultCallback](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifindresultcallback/) per ricevere una notifica per ogni occorrenza. Il suo metodo [IFindResultCallback.foundResult](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) fornisce il frame di testo correlato, il testo sorgente, il testo corrispondente e la posizione della corrispondenza.

Il callback non riceve direttamente il numero della diapositiva. L’implementazione sottostante lo ricava dalla diapositiva madre e gestisce anche il testo trovato nelle note delle diapositive. Un `Integer` nullable consente al medesimo modello di risultato di rappresentare testi associati ad altri tipi di diapositiva.

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

Per le operazioni di sostituzione, `foundText` contiene il testo originale corrispondente, così il callback può registrare esattamente quali termini sono stati sostituiti.

## **Evidenzia testo**

Usa il metodo [ITextFrame.highlightText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) per evidenziare le corrispondenze di testo letterale in un frame di testo. Passa un’istanza di [TextSearchOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textsearchoptions/) per controllare la ricerca e un callback per raccogliere i dettagli delle corrispondenze.

L’esempio di codice sotto evidenzia tutte le occorrenze della stringa **“try”** e poi evidenzia solo la parola completa **“to”**. Entrambe le ricerche riportano le loro corrispondenze allo stesso callback.

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

    // Evidenzia ogni occorrenza di "try" nel frame di testo.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // Evidenzia solo la parola completa "to".
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

Il risultato:

![Il testo evidenziato](highlighted_text.png)

## **Evidenzia testo usando espressioni regolari**

Il metodo [ITextFrame.highlightRegex](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) evidenzia le corrispondenze trovate da un’espressione regolare in un frame di testo.

Il codice seguente evidenzia tutte le parole contenenti sette o più caratteri e raccoglie ogni occorrenza:

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

Il risultato:

![Il testo evidenziato usando l’espressione regolare](highlighted_text_using_regex.png)

## **Evidenzia testo su tutta la presentazione**

Usa [IPresentation.highlightText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [IPresentation.highlightRegex](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) per cercare tutti i frame di testo applicabili in una presentazione. L’esempio seguente evidenzia un termine letterale e tutti gli indirizzi e‑mail mantenendo raccolte di risultati separate per le due ricerche.

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

## **Sostituisci testo in un frame di testo**

Usa [ITextFrame.replaceText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) per testo letterale e [ITextFrame.replaceRegex](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) per sostituzioni basate su pattern. Questi metodi aggiornano il testo corrispondente all’interno del frame di testo esistente, mantenendo la formattazione delle parti circostanti invece di ricostruire il frame da una stringa semplice.

L’esempio seguente normalizza una variante ortografica e poi sostituisce le etichette di versione. Lo stesso callback registra i termini originali corrispondenti a entrambe le operazioni.

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

Se una corrispondenza attraversa parti con formattazioni diverse, verifica l’output per confermare quale formattazione deve essere applicata al testo sostituito.

## **Sostituisci testo su tutta la presentazione**

Usa [IPresentation.replaceText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [IPresentation.replaceRegex](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) per applicare le stesse operazioni su tutta la presentazione. Questo è utile per pulizia di template, aggiornamenti di terminologia e redazione.

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

## **Raggruppa le corrispondenze per la reportistica**

Poiché ogni risultato conserva il numero della diapositiva e il frame di testo, le applicazioni possono raggruppare le corrispondenze per audit, reportistica o flussi di lavoro di revisione. L’esempio seguente raggruppa i risultati raccolti prima per diapositiva e poi per frame di testo:

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

**Come posso cercare solo una casella di testo invece che l’intera presentazione?**

Ottieni il frame di testo della forma e chiama [ITextFrame.highlightText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), o [ITextFrame.replaceRegex](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) su quel frame di testo. I metodi a livello di presentazione elaborano tutti i frame di testo applicabili.

**Come posso corrispondere parole intere con la corretta capitalizzazione?**

Imposta [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) e [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) a `true` e passa le opzioni a un metodo di evidenziazione o sostituzione di testo letterale. Per le espressioni regolari, definisci i confini di parola e la sensibilità al caso direttamente nel `Pattern` Java.

**La ricerca e la sostituzione possono includere il testo nelle note delle diapositive?**

Sì. Imposta [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) a `true` quando utilizzi un’operazione di testo letterale a livello di presentazione. L’implementazione del callback mostrata sopra associa una corrispondenza in una diapositiva di note al numero della diapositiva madre.

**Come posso creare un report senza scansionare nuovamente la presentazione?**

Passa un’implementazione di [IFindResultCallback](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifindresultcallback/) all’operazione di evidenziazione o sostituzione. Il callback riceve ogni corrispondenza mentre l’operazione è in esecuzione, così l’applicazione può memorizzare il testo sorgente, il testo corrispondente, la posizione, il frame di testo e il numero di diapositiva derivato per successivi raggruppamenti o esportazioni.

**La sostituzione del testo preserva la formattazione?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [ITextFrame.replaceRegex](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modificano il testo corrispondente all’interno del frame di testo esistente e mantengono la formattazione delle parti circostanti. Se una corrispondenza attraversa porzioni con formattazioni diverse, esamina il risultato per assicurarti che la sostituzione utilizzi lo stile desiderato.