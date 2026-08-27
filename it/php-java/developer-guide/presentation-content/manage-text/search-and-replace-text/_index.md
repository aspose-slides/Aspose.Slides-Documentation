---
title: Cerca e sostituisci testo nelle presentazioni PowerPoint in PHP
linktitle: Cerca e sostituisci testo
type: docs
weight: 55
url: /it/php-java/search-and-replace-text/
keywords:
- cerca testo
- evidenzia testo
- sostituisci testo
- espressione regolare
- callback risultato
- frame di testo
- rapporto di audit
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Cerca, evidenzia e sostituisci testo nelle presentazioni PowerPoint raccogliendo ogni corrispondenza con Aspose.Slides per PHP via Java."
---
## **Panoramica**

Aspose.Slides per PHP via Java può cercare, evidenziare e sostituire testo in un singolo frame di testo o nell’intera presentazione. Ogni operazione può anche notificare l’applicazione per ogni corrispondenza tramite un callback di risultato. Questo rende possibile aggiornare una presentazione e contemporaneamente costruire una traccia di audit contenente il testo corrispondente, il suo contesto, la posizione, il frame di testo e il numero della diapositiva.

Queste funzionalità sono utili per revisioni, redazioni, controlli terminologici, pulizia di modelli e flussi di lavoro di reporting automatizzati.

Nei primi esempi sottostanti, utilizziamo un file denominato **"sample.pptx"**, che contiene una singola casella di testo nella prima diapositiva con il seguente contenuto:

![Testo di esempio](sample_text.png)

## **Scegli l'ambito di ricerca**

Usa i metodi su [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) per limitare un’operazione a un singolo frame di testo. Usa i metodi su [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) per elaborare tutto il testo applicabile nella presentazione.

| Operazione | Un frame di testo | Presentazione intera |
|---|---|---|
| Evidenzia testo letterale | [TextFrame::highlightText](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#highlightText) |
| Evidenzia corrispondenze di espressione regolare | [TextFrame::highlightRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#highlightRegex) |
| Sostituisci testo letterale | [TextFrame::replaceText](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#replaceText) |
| Sostituisci corrispondenze di espressione regolare | [TextFrame::replaceRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#replaceRegex) |

## **Configura la corrispondenza del testo**

Per le operazioni su testo letterale, utilizza [TextSearchOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/textsearchoptions/) per controllare la corrispondenza:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/it/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) limita le corrispondenze a parole intere.  
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/it/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) controlla se il caso dei caratteri deve coincidere.  
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/it/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) include le note della diapositiva nelle operazioni di ricerca, sostituzione ed evidenziazione a livello di presentazione.

Le operazioni basate su espressioni regolari usano un `Pattern` Java, quindi le regole di corrispondenza come la sensibilità al caso e i confini di parola sono definite dall’espressione e dalle sue opzioni.

## **Identifica il proprietario di un frame di testo**

I flussi di lavoro di elaborazione testo generici spesso ricevono un [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) durante la ricerca, la sostituzione, la convalida o l’esportazione del testo. Usa [TextFrame::getParentShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#getParentShape) e [TextFrame::getParentCell](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#getParentCell) per determinare quale oggetto della presentazione possiede il frame di testo.

I valori attesi dipendono dal proprietario:

| Proprietario del frame di testo | `getParentShape` | `getParentCell` |
|---|---|---|
| Una AutoShape o un'altra forma contenente testo | La [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/) proprietaria | `null` |
| Una cella di tabella | `null` | La [Cell](https://reference.aspose.com/slides/it/php-java/aspose.slides/cell/) proprietaria |

Entrambi i metodi forniscono navigazione in sola lettura. Chiamarli non sposta il frame di testo né ne cambia il proprietario. Il codice generico dovrebbe verificare entrambi i valori con `java_is_null` e gestire la possibilità che nessun proprietario sia disponibile.

L’esempio seguente utilizza [SlideUtil::getAllTextFrames](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideutil/#getAllTextFrames) per iterare sui frame di testo in una presentazione. Per le forme, viene riportato il nome della forma, il tipo di runtime Java e la diapositiva contenente. Per le celle di tabella, vengono riportate le coordinate di colonna e riga (indice zero) e la diapositiva contenente.

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$presentation = new Presentation("presentation.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $textFrames = SlideUtil::getAllTextFrames($presentation, false);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        $textFrame = $textFrames[$textFrameIndex];
        $ownerShape = $textFrame->getParentShape();
        if (!java_is_null($ownerShape)) {
            $shapeName = java_values($ownerShape->getName());
            $shapeName = $shapeName === "" ? "(unnamed)" : $shapeName;
            $shapeType = java_values($ownerShape->getClass()->getSimpleName());
            $baseSlide = $ownerShape->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Shape: " . $shapeName . "; type: " . $shapeType . "; " . $slideLabel . "\n");
            continue;
        }

        $ownerCell = $textFrame->getParentCell();
        if (!java_is_null($ownerCell)) {
            $baseSlide = $ownerCell->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Table cell: column " . java_values($ownerCell->getFirstColumnIndex()) . ", row " . java_values($ownerCell->getFirstRowIndex()) . "; " . $slideLabel . "\n");
            continue;
        }

        echo("The text frame owner is not available as a shape or table cell.\n");
    }
} finally {
    $presentation->dispose();
}
```

Per i contenuti SmartArt, itera sulle forme in [SmartArtNode::getShapes](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartnode/#getShapes) e accedi a ciascuna [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartshape/#getTextFrame). Il frame di testo può essere ricondotto alla forma associata tramite [TextFrame::getParentShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#getParentShape), mentre [TextFrame::getParentCell](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#getParentCell) restituisce `null`. Pertanto, il ramo delle forme nell’esempio gestisce anche il testo proveniente da nodi SmartArt.

## **Raccogli le informazioni sulla corrispondenza con un callback**

Passa un callback proxy Java a un metodo di evidenziazione o sostituzione per ricevere una notifica per ogni corrispondenza. Il metodo di callback riceve il frame di testo relativo, il testo di origine, il testo corrispondente e la posizione della corrispondenza.

Il callback non riceve direttamente il numero della diapositiva. L’implementazione qui sotto lo ricava dalla diapositiva padre e gestisce anche il testo trovato nelle note della diapositiva. L’array risultato utilizza `null` quando il testo è associato a un altro tipo di diapositiva.

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
        $parentShape = $textFrame->getParentShape();
        $parentCell = $textFrame->getParentCell();

        if (!java_is_null($parentShape)) {
            $parentSlide = $parentShape->getSlide();
        } elseif (!java_is_null($parentCell)) {
            $parentSlide = $parentCell->getSlide();
        } else {
            $parentSlide = $textFrame->getSlide();
        }

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

Crea un proxy per questo oggetto PHP prima di passarlo a un’operazione:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

Per le operazioni di sostituzione, `foundText` contiene il testo originale corrispondente, così il callback può registrare esattamente quali termini sono stati sostituiti.

## **Evidenzia il testo**

Usa il metodo [TextFrame::highlightText](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#highlightText) per evidenziare le corrispondenze di testo letterale in un frame di testo. Passa [TextSearchOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/textsearchoptions/) per controllare la ricerca.

L’esempio di codice qui sotto evidenzia tutte le occorrenze della stringa **"try"** e poi evidenzia solo la parola intera **"to"**.

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

    // Evidenzia ogni occorrenza di "try" nel frame di testo.
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

    // Evidenzia solo la parola intera "to".
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

![Il testo evidenziato](highlighted_text.png)

## **Evidenzia il testo usando espressioni regolari**

Il metodo [TextFrame::highlightRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#highlightRegex) evidenzia le corrispondenze di testo trovate da un’espressione regolare in un frame di testo.

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

![Il testo evidenziato usando l'espressione regolare](highlighted_text_using_regex.png)

## **Evidenzia il testo nell’intera presentazione**

Usa [Presentation::highlightText](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#highlightText) e [Presentation::highlightRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#highlightRegex) per cercare tutti i frame di testo applicabili nella presentazione. L’esempio seguente evidenzia un termine letterale e tutti gli indirizzi email:

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

## **Sostituisci il testo in un frame di testo**

Usa [TextFrame::replaceText](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#replaceText) per testo letterale e [TextFrame::replaceRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#replaceRegex) per sostituzioni basate su pattern. Questi metodi aggiornano il testo corrispondente all’interno del frame di testo esistente, mantenendo la formattazione delle parti circostanti anziché ricostruire il frame da una stringa grezza.

L’esempio seguente standardizza una variante ortografica e poi sostituisce le etichette di versione:

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

Se una corrispondenza attraversa parti con formattazioni diverse, verifica l’output per confermare quale formattazione deve essere applicata al testo sostituito.

## **Sostituisci il testo nell’intera presentazione**

Usa [Presentation::replaceText](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#replaceText) e [Presentation::replaceRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#replaceRegex) per applicare le stesse operazioni a tutta la presentazione. Questo è utile per la pulizia di modelli, aggiornamenti terminologici e redazioni.

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

## **Raggruppa le corrispondenze per il reporting**

Poiché ogni risultato memorizza il numero della diapositiva e il frame di testo, le applicazioni possono raggruppare le corrispondenze per audit, reporting o flussi di lavoro di revisione. L’esempio seguente raggruppa i risultati raccolti prima per diapositiva e poi per frame di testo:

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

**Come posso cercare solo una casella di testo invece dell’intera presentazione?**

Ottieni il frame di testo della forma e chiama [TextFrame::highlightText](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#replaceText) o [TextFrame::replaceRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#replaceRegex) su quel frame di testo. I metodi a livello di presentazione elaborano tutti i frame di testo applicabili.

**Come posso far corrispondere parole intere con la capitalizzazione corretta?**

Imposta [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/it/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) e [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/it/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) su `true`, e passa le opzioni a un metodo di evidenziazione o sostituzione di testo letterale. Per le espressioni regolari, definisci i confini di parola e la sensibilità al caso direttamente nel `Pattern` Java.

**La ricerca e la sostituzione possono includere il testo nelle note della diapositiva?**

Sì. Imposta [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/it/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) su `true` quando utilizzi un’operazione di testo letterale a livello di presentazione.

**Come posso creare un report senza scansionare nuovamente la presentazione?**

Passa un callback proxy Java all’operazione di evidenziazione o sostituzione. Riceve ogni corrispondenza durante l’esecuzione dell’operazione, così l’applicazione può memorizzare il testo di origine, il testo corrispondente, la posizione, il frame di testo e il numero di diapositiva derivato per successivi raggruppamenti o esportazioni.

**La sostituzione del testo preserva la sua formattazione?**

[TextFrame::replaceText](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#replaceText) e [TextFrame::replaceRegex](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#replaceRegex) modificano il testo corrispondente all’interno del frame di testo esistente e mantengono la formattazione delle parti circostanti. Se una corrispondenza attraversa parti con formattazioni diverse, esamina il risultato per assicurarti che la sostituzione utilizzi lo stile desiderato.