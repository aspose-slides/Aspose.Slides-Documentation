---
title: "Cerca e Sostituisci Testo nelle Presentazioni PowerPoint in PHP"
linktitle: "Cerca e Sostituisci Testo"
type: docs
weight: 55
url: /it/php-java/search-and-replace-text/
keywords:
- "ricerca testo"
- "evidenzia testo"
- "sostituisci testo"
- "espressione regolare"
- "callback risultato"
- "riquadro di testo"
- "rapporto di audit"
- "PowerPoint"
- "OpenDocument"
- "presentazione"
- "PHP"
- "Aspose.Slides"
description: "Cerca, evidenzia e sostituisci testo nelle presentazioni PowerPoint raccogliendo ogni corrispondenza con Aspose.Slides per PHP via Java."
---
## **Panoramica**

Aspose.Slides per PHP via Java può cercare, evidenziare e sostituire testo in un singolo riquadro di testo o in un'intera presentazione. Ogni operazione può anche notificare un'applicazione su ogni occorrenza tramite un callback di risultato. Questo consente di aggiornare una presentazione e contemporaneamente creare una traccia di audit contenente il testo corrispondente, il suo contesto, la posizione, il riquadro di testo e il numero della diapositiva.

Queste funzionalità sono utili per revisioni, redazione, verifiche di terminologia, pulizia di modelli e flussi di lavoro di generazione di report automatici.

Negli esempi seguenti, utilizziamo un file chiamato "sample.pptx", che contiene una singola casella di testo nella prima diapositiva con il seguente contenuto:

![Sample text](sample_text.png)

## **Scegliere l'Ambito di Ricerca**

Utilizzare i metodi su [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) per limitare un'operazione a un singolo riquadro di testo. Utilizzare i metodi su [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) per elaborare tutto il testo applicabile nella presentazione.

| Operazione | Un riquadro di testo | Intera presentazione |
|---|---|---|
| Evidenziare testo letterale | [TextFrame::highlightText](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#highlightText) |
| Evidenziare corrispondenze di espressione regolare | [TextFrame::highlightRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#highlightRegex) |
| Sostituire testo letterale | [TextFrame::replaceText](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#replaceText) |
| Sostituire corrispondenze di espressione regolare | [TextFrame::replaceRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#replaceRegex) |

## **Configurare la Corrispondenza del Testo**

Per operazioni su testo letterale, utilizzare [TextSearchOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/textsearchoptions/) per controllare la corrispondenza:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/it/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) limita le corrispondenze a parole complete.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/it/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) controlla se il caso dei caratteri deve corrispondere.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/it/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) include le note delle diapositive nelle operazioni di ricerca, sostituzione ed evidenziazione a livello di presentazione.

Le operazioni con espressioni regolari utilizzano un `Pattern` Java, quindi regole come la sensibilità al caso e i confini di parola sono definiti dall'espressione e dalle sue flag.

## **Raccogliere le Informazioni di Corrispondenza con un Callback**

Passare un callback proxy Java a un metodo di evidenziazione o sostituzione per ricevere una notifica per ogni corrispondenza. Il metodo di callback riceve il riquadro di testo correlato, il testo sorgente, il testo corrispondente e la posizione della corrispondenza.

Il callback non riceve direttamente il numero della diapositiva. L'implementazione seguente lo ricava dalla diapositiva padre e gestisce anche il testo trovato nelle note della diapositiva. L'array di risultato utilizza `null` quando il testo è associato a un altro tipo di diapositiva.

```php
class TextSearchCallback {
    private $results = [];

    public function getResults() {
        return $this->results;
    }

    public function foundResult($textFrame, $sourceText, $foundText, $textPosition) {
        $slideNumber = $this->getSlideNumber($textFrame);
        $this->results[] = [
            "textFrame" => $textFrame,
            "sourceText" => java_values($sourceText),
            "foundText" => java_values($foundText),
            "textPosition" => java_values($textPosition),
            "slideNumber" => $slideNumber
        ];
    }

    private function getSlideNumber($textFrame) {
        $parentSlide = $textFrame->getSlide();
        if (java_is_null($parentSlide)) {
            return null;
        }

        $parentSlideClass = $parentSlide->getClass();
        $classNameValue = $parentSlideClass->getName();
        $className = java_values($classNameValue);

        if ($className === "com.aspose.slides.Slide") {
            $slideNumber = $parentSlide->getSlideNumber();
            return java_values($slideNumber);
        }

        if ($className === "com.aspose.slides.NotesSlide") {
            $slide = $parentSlide->getParentSlide();
            $slideNumber = $slide->getSlideNumber();
            return java_values($slideNumber);
        }

        return null;
    }
}
```

Creare un proxy per questo oggetto PHP prima di passarlo a un'operazione:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

Per le operazioni di sostituzione, `foundText` contiene il testo originale corrispondente, quindi il callback può registrare esattamente quali termini sono stati sostituiti.

## **Evidenziare Testo**

Utilizzare il metodo [TextFrame::highlightText](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#highlightText) per evidenziare le corrispondenze di testo letterale in un riquadro di testo. Passare [TextSearchOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/textsearchoptions/) per controllare la ricerca.

L'esempio di codice sotto evidenzia tutte le occorrenze della sequenza **"try"** e poi evidenzia solo la parola completa **"to"**.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $callbackHandler = new TextSearchCallback();
    $callbackInterface = java("com.aspose.slides.IFindResultCallback");
    $callback = java_closure(
        $callbackHandler,
        null,
        $callbackInterface
    );

    $substringSearchOptions = new TextSearchOptions();
    $substringSearchOptions->setCaseSensitive(false);
    $substringHighlightColor = new Java("java.awt.Color", 173, 216, 230);

    // Evidenzia ogni occorrenza di "try" nel riquadro di testo.
    $shape->getTextFrame()->highlightText(
        "try",
        $substringHighlightColor,
        $substringSearchOptions,
        $callback
    );

    $wholeWordSearchOptions = new TextSearchOptions();
    $wholeWordSearchOptions->setWholeWordsOnly(true);
    $wholeWordSearchOptions->setCaseSensitive(false);
    $wholeWordHighlightColor = new Java("java.awt.Color", 238, 130, 238);

    // Evidenzia solo la parola completa "to".
    $shape->getTextFrame()->highlightText(
        "to",
        $wholeWordHighlightColor,
        $wholeWordSearchOptions,
        $callback
    );

    foreach ($callbackHandler->getResults() as $result) {
        echo(
            "Found '" . $result["foundText"] . "' at position " .
            $result["textPosition"] . " on slide " .
            $result["slideNumber"] . ".\n"
        );
    }

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Il risultato:

![The highlighted text](highlighted_text.png)

## **Evidenziare Testo Usando Espressioni Regolari**

Il metodo [TextFrame::highlightRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#highlightRegex) evidenzia le corrispondenze di testo trovate da un'espressione regolare in un riquadro di testo.

Il codice seguente evidenzia tutte le parole contenenti sette o più caratteri:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $regex = java("java.util.regex.Pattern")->compile("\\b[^\\s]{7,}\\b");
    $highlightColor = java("java.awt.Color")->YELLOW;

    $shape->getTextFrame()->highlightRegex($regex, $highlightColor, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Il risultato:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Evidenziare Testo in un'Intera Presentazione**

Utilizzare [Presentation::highlightText](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#highlightText) e [Presentation::highlightRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#highlightRegex) per cercare tutti i riquadri di testo applicabili in una presentazione. L'esempio seguente evidenzia un termine letterale e tutti gli indirizzi email:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);
    $termHighlightColor = java("java.awt.Color")->ORANGE;

    $presentation->highlightText(
        "confidential",
        $termHighlightColor,
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $emailPattern = "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b";
    $emailRegex = $patternClass->compile(
        $emailPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $emailHighlightColor = java("java.awt.Color")->YELLOW;

    $presentation->highlightRegex($emailRegex, $emailHighlightColor, null);
    $presentation->save("highlighted_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Sostituire Testo in un Riquadro di Testo**

Utilizzare [TextFrame::replaceText](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#replaceText) per testo letterale e [TextFrame::replaceRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#replaceRegex) per sostituzione basata su modello. Questi metodi aggiornano il testo corrispondente all'interno del riquadro di testo esistente, mantenendo la formattazione della porzione circostante invece di ricostruire il riquadro da una stringa semplice.

L'esempio seguente standardizza una variante ortografica e poi sostituisce le etichette di versione:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);

    $shape->getTextFrame()->replaceText(
        "colour",
        "color",
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $versionPattern = "\\bv\\d+(?:\\.\\d+)*\\b";
    $versionRegex = $patternClass->compile(
        $versionPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $shape->getTextFrame()->replaceRegex(
        $versionRegex,
        "current version",
        null
    );

    $presentation->save("updated_text_frame.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Se una corrispondenza copre porzioni con formattazioni diverse, verificare l'output per confermare quale formattazione deve essere applicata al testo sostituito.

## **Sostituire Testo in un'Intera Presentazione**

Utilizzare [Presentation::replaceText](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#replaceText) e [Presentation::replaceRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#replaceRegex) per applicare le stesse operazioni all'intera presentazione. Questo è utile per la pulizia di modelli, aggiornamenti di terminologia e redazione.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);

    $presentation->replaceText(
        "Contoso",
        "Example Corp",
        $searchOptions,
        null
    );

    $accountNumberRegex = java("java.util.regex.Pattern")->compile(
        "\\bACCT-\\d{6}\\b"
    );
    $presentation->replaceRegex(
        $accountNumberRegex,
        "ACCT-REDACTED",
        null
    );

    $presentation->save("updated_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Raggruppare le Corrispondenze per Reporting**

Poiché ogni risultato memorizza il numero della diapositiva e il riquadro di testo, le applicazioni possono raggruppare le corrispondenze per audit, report o workflow di revisione. L'esempio seguente raggruppa i risultati raccolti prima per diapositiva e poi per riquadro di testo:

```php
$matchesBySlide = [];
$systemClass = java("java.lang.System");

foreach ($callbackHandler->getResults() as $result) {
    $slideNumber = $result["slideNumber"];
    $slideLabel = $slideNumber === null ? "Other" : (string) $slideNumber;
    $textFrame = $result["textFrame"];
    $textFrameHash = $systemClass->identityHashCode($textFrame);
    $textFrameKey = (string) java_values($textFrameHash);

    if (!isset($matchesBySlide[$slideLabel])) {
        $matchesBySlide[$slideLabel] = [];
    }

    if (!isset($matchesBySlide[$slideLabel][$textFrameKey])) {
        $matchesBySlide[$slideLabel][$textFrameKey] = [
            "textFrame" => $textFrame,
            "matches" => []
        ];
    }

    $matchesBySlide[$slideLabel][$textFrameKey]["matches"][] = $result;
}

foreach ($matchesBySlide as $slideLabel => $textFrameGroups) {
    echo("Slide: " . $slideLabel . "\n");

    foreach ($textFrameGroups as $textFrameGroup) {
        $textFrame = $textFrameGroup["textFrame"];
        echo("  Text frame: " . $textFrame->getText() . "\n");

        foreach ($textFrameGroup["matches"] as $result) {
            echo(
                "    '" . $result["foundText"] . "' at position " .
                $result["textPosition"] . "; context: '" .
                $result["sourceText"] . "'\n"
            );
        }
    }
}
```

## **FAQ**

**Come posso cercare solo una casella di testo invece che l'intera presentazione?**

Ottenere il riquadro di testo della forma e chiamare [TextFrame::highlightText](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#replaceText) o [TextFrame::replaceRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#replaceRegex) su quel riquadro. I metodi a livello di presentazione elaborano tutti i riquadri di testo applicabili.

**Come posso far corrispondere parole intere con la corretta capitalizzazione?**

Impostare [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/it/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) e [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/it/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) su `true` e passare le opzioni a un metodo di evidenziazione o sostituzione di testo letterale. Per le espressioni regolari, definire i confini di parola e la sensibilità al caso direttamente nel `Pattern` Java.

**La ricerca e la sostituzione possono includere il testo nelle note delle diapositive?**

Sì. Impostare [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/it/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) su `true` quando si utilizza un'operazione di testo letterale a livello di presentazione.

**Come posso creare un report senza scansionare nuovamente la presentazione?**

Passare un callback proxy Java all'operazione di evidenziazione o sostituzione. Riceve ogni corrispondenza durante l'esecuzione, così l'applicazione può memorizzare il testo sorgente, il testo corrispondente, la posizione, il riquadro di testo e il numero della diapositiva derivato per successivi raggruppamenti o esportazioni.

**La sostituzione del testo ne preserva la formattazione?**

[TextFrame::replaceText](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#replaceText) e [TextFrame::replaceRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#replaceRegex) modificano il testo corrispondente all'interno del riquadro di testo esistente e mantengono la formattazione della porzione circostante. Se una corrispondenza copre porzioni con formattazioni diverse, ispezionare il risultato per assicurarsi che la sostituzione utilizzi lo stile desiderato.