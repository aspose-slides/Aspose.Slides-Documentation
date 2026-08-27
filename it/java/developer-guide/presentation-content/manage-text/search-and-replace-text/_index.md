---
title: Cerca e sostituisci testo nelle presentazioni PowerPoint in Java
linktitle: Cerca e sostituisci testo
type: docs
weight: 55
url: /it/java/search-and-replace-text/
keywords:
- cerca testo
- evidenzia testo
- sostituisci testo
- espressione regolare
- callback di risultato
- riquadro di testo
- rapporto di audit
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Cerca, evidenzia e sostituisci testo nelle presentazioni PowerPoint raccogliendo ogni corrispondenza con Aspose.Slides per Java."
---
## **Panoramica**

Aspose.Slides per Java può cercare, evidenziare e sostituire testo in un singolo riquadro di testo o in tutta la presentazione. Ogni operazione può anche notificare l’applicazione per ogni corrispondenza tramite un callback di risultato. Ciò consente di aggiornare una presentazione e allo stesso tempo generare una traccia di audit contenente il testo corrispondente, il suo contesto, la posizione, il riquadro di testo e il numero della diapositiva.

Queste funzionalità sono utili per revisioni, redazioni, controlli di terminologia, pulizia di modelli e flussi di lavoro di reportistica automatizzata.

Negli esempi seguenti, utilizziamo un file chiamato **"sample.pptx"**, che contiene una singola casella di testo nella prima diapositiva con il seguente contenuto:

![Sample text](sample_text.png)

## **Scegli l'ambito di ricerca**

Utilizza i metodi su [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) per limitare un’operazione a un singolo riquadro di testo. Utilizza i metodi su [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) per elaborare tutti i testi applicabili nella presentazione.

| Operazione | Un riquadro di testo | Intera presentazione |
|---|---|---|
| Evidenzia testo letterale | [ITextFrame.highlightText](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Evidenzia corrispondenze di espressione regolare | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Sostituisci testo letterale | [ITextFrame.replaceText](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Sostituisci corrispondenze di espressione regolare | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configura il criterio di ricerca del testo**

Per le operazioni su testo letterale, utilizza [TextSearchOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/textsearchoptions/) per controllare il confronto:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/it/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) limita le corrispondenze a parole intere.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/it/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) controlla se il caso dei caratteri deve corrispondere.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/it/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) include le note della diapositiva nelle operazioni di ricerca, sostituzione e evidenziazione a livello di presentazione.

Le operazioni con espressioni regolari usano un `Pattern` Java, quindi regole come la sensibilità al caso e i confini di parola sono definiti dall’espressione e dai suoi flag.

## **Identifica il proprietario di un riquadro di testo**

I flussi di lavoro generici di elaborazione del testo spesso ricevono un [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) durante la ricerca, sostituzione, validazione o esportazione del testo. Usa [ITextFrame.getParentShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#getParentShape--) e [ITextFrame.getParentCell](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#getParentCell--) per determinare quale oggetto della presentazione possiede il riquadro di testo.

I valori attesi dipendono dal proprietario:

| Proprietario del riquadro di testo | `getParentShape` | `getParentCell` |
|---|---|---|
| Un’AutoShape o un’altra forma contenente testo | La [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/) proprietaria | `null` |
| Una cella di tabella | `null` | La [ICell](https://reference.aspose.com/slides/it/java/com.aspose.slides/icell/) proprietaria |

Entrambi i metodi forniscono una navigazione in sola lettura. La loro chiamata non sposta il riquadro di testo né ne cambia il proprietario. Il codice generico dovrebbe controllare entrambi i valori per `null` e gestire la possibilità che nessuno dei due sia disponibile.

L’esempio seguente utilizza [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/it/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) per iterare sui riquadri di testo in una presentazione. Per le forme, segnala il nome della forma, il tipo di runtime Java e la diapositiva contenente. Per le celle di tabella, segnala le coordinate di colonna e riga (indice zero) e la diapositiva contenente.

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

Per i contenuti SmartArt, itera sulle forme in [ISmartArtNode.getShapes](https://reference.aspose.com/slides/it/java/com.aspose.slides/ismartartnode/#getShapes--) e accedi a ciascuna [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ismartartshape/#getTextFrame--). Il riquadro di testo può essere ricondotto alla sua forma associata tramite [ITextFrame.getParentShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#getParentShape--), mentre [ITextFrame.getParentCell](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#getParentCell--) restituisce `null`. Pertanto, il ramo delle forme nell’esempio gestisce anche il testo dei nodi SmartArt.

## **Raccogli le informazioni sulla corrispondenza con un callback**

Implementa [IFindResultCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifindresultcallback/) per ricevere una notifica per ogni corrispondenza. Il suo metodo [IFindResultCallback.foundResult](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) fornisce il riquadro di testo relativo, il testo sorgente, il testo corrispondente e la posizione della corrispondenza.

Il callback non riceve direttamente il numero della diapositiva. L’implementazione mostrata di seguito lo ricava dalla diapositiva padre e gestisce anche il testo trovato nelle note della diapositiva. Un `Integer` nullable consente al medesimo modello di risultato di rappresentare testo associato ad altri tipi di diapositiva.

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

Utilizza il metodo [ITextFrame.highlightText](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) per evidenziare le corrispondenze di testo letterale in un riquadro di testo. Passa un oggetto [TextSearchOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/textsearchoptions/) per controllare la ricerca e un callback per raccogliere i dettagli della corrispondenza.

Il codice di esempio qui sotto evidenzia tutte le occorrenze della stringa **"try"** e poi evidenzia solo la parola intera **"to"**. Entrambe le ricerche riportano le proprie corrispondenze allo stesso callback.

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

    // Evidenzia ogni occorrenza di "try" nel riquadro di testo.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // Evidenzia solo la parola intera "to".
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

![The highlighted text](highlighted_text.png)

## **Evidenzia testo usando espressioni regolari**

Il metodo [ITextFrame.highlightRegex](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) evidenzia le corrispondenze trovate da un’espressione regolare in un riquadro di testo.

Il codice seguente evidenzia tutte le parole contenenti sette o più caratteri e raccoglie ciascuna corrispondenza:

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

Il risultato:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Evidenzia testo su tutta la presentazione**

Usa [Presentation.highlightText](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [Presentation.highlightRegex](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) per cercare tutti i riquadri di testo applicabili in una presentazione. L’esempio seguente evidenzia un termine letterale e tutti gli indirizzi e‑mail mantenendo collezioni di risultati separate per le due ricerche.

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

## **Sostituisci testo in un riquadro di testo**

Usa [ITextFrame.replaceText](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) per testo letterale e [ITextFrame.replaceRegex](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) per sostituzioni basate su pattern. Questi metodi aggiornano il testo corrispondente all’interno del riquadro di testo esistente, mantenendo la formattazione delle parti circostanti anziché ricostruire il riquadro da una stringa semplice.

L’esempio seguente standardizza una variante ortografica e poi sostituisce le etichette di versione. Lo stesso callback registra i termini originali corrispondenti a entrambe le operazioni.

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

Usa [Presentation.replaceText](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [Presentation.replaceRegex](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) per applicare le stesse operazioni a tutta la presentazione. Questa funzionalità è utile per la pulizia di modelli, aggiornamenti di terminologia e redazioni.

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

## **Raggruppa le corrispondenze per reportistica**

Poiché ogni risultato memorizza il numero della diapositiva e il riquadro di testo, le applicazioni possono raggruppare le corrispondenze per audit, reportistica o flussi di revisione. L’esempio seguente raggruppa i risultati raccolti prima per diapositiva e poi per riquadro di testo:

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

**Come posso cercare solo una casella di testo invece dell’intera presentazione?**

Ottieni il riquadro di testo della forma e chiama [ITextFrame.highlightText](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) o [ITextFrame.replaceRegex](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) su quel riquadro di testo. I metodi a livello di presentazione elaborano tutti i riquadri di testo applicabili.

**Come posso fare in modo che la ricerca corrisponda a parole intere con la corretta capitalizzazione?**

Imposta [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/it/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) e [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/it/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) su `true` e passa le opzioni a un metodo di evidenziazione o sostituzione di testo letterale. Per le espressioni regolari, definisci i confini di parola e la sensibilità al caso direttamente nel `Pattern` Java.

**La ricerca e la sostituzione possono includere il testo nelle note delle diapositive?**

Sì. Imposta [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/it/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) su `true` quando utilizzi un’operazione di testo letterale a livello di presentazione. L’implementazione del callback mostrata sopra mappa una corrispondenza in una diapositiva note al suo numero di diapositiva padre.

**Come posso creare un report senza dover scansionare nuovamente la presentazione?**

Passa un’implementazione di [IFindResultCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifindresultcallback/) all’operazione di evidenziazione o sostituzione. Il callback riceve ogni corrispondenza durante l’esecuzione dell’operazione, così l’applicazione può memorizzare il testo sorgente, il testo corrispondente, la posizione, il riquadro di testo e il numero di diapositiva derivato per successivi raggruppamenti o esportazioni.

**La sostituzione del testo mantiene la formattazione?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [ITextFrame.replaceRegex](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modificano il testo corrispondente all’interno del riquadro di testo esistente e mantengono la formattazione delle parti circostanti. Se una corrispondenza attraversa parti con formattazioni diverse, ispeziona il risultato per assicurarti che la sostituzione utilizzi lo stile desiderato.