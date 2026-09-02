---
title: Ottieni le proprietà effettive della forma dalle presentazioni in PHP
linktitle: Proprietà effettive
type: docs
weight: 50
url: /it/php-java/shape-effective-properties/
keywords:
- proprietà della forma
- proprietà della fotocamera
- impianto di illuminazione
- forma smussata
- riquadro di testo
- stile del testo
- altezza del carattere
- formato di riempimento
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come utilizzare Aspose.Slides per PHP via Java per distinguere la formattazione locale, ereditata ed effettiva delle forme nelle presentazioni PowerPoint."
---
## **Comprendere le proprietà locali, ereditate ed effettive**

Il formato di PowerPoint può provenire da più fonti. Il valore memorizzato direttamente su un oggetto è il suo **valore locale**. Se quel valore non è impostato, PowerPoint controlla le fonti di formattazione dei genitori, come il valore predefinito di un paragrafo, uno stile di testo, un layout o una diapositiva master, un tema o i valori predefiniti a livello di presentazione. Quei valori sono **valori ereditati**. Il valore che rimane dopo che l’intera gerarchia è stata risolta è il **valore effettivo**—il valore usato per rendere l’oggetto.

Ad esempio, una porzione di testo potrebbe non definire la propria altezza del carattere. Il suo valore locale [getFontHeight](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/) è allora `NAN`, che significa “non impostato qui”. La porzione può ereditare un’altezza dal suo paragrafo, dallo stile di testo predefinito della presentazione o da un’altra fonte applicabile. Chiamare [getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/portionformat/geteffective/) sul formato della porzione restituisce l’altezza finale risolta.

Utilizza i due tipi di dati di formattazione per scopi diversi:

- Leggi o modifica un oggetto di formato locale, come [PortionFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/portionformat/), quando devi controllare dove è definito un valore.
- Leggi un oggetto di dati effettivi, come i [dati restituiti da PortionFormat.getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/portionformat/geteffective/), quando ti serve il risultato finale renderizzato. I dati effettivi sono di sola lettura.

Prima di eseguire gli esempi, [install Aspose.Slides for PHP via Java](/slides/it/php-java/installation/).

## **Confrontare valori locali, ereditati ed effettivi**

Il seguente esempio completo crea una forma e applica altezze di carattere a livello di presentazione, paragrafo e porzione. Ogni passaggio stampa i valori definiti a quei livelli e il valore effettivo risultante per la stessa porzione di testo. Dimostra inoltre perché i dati effettivi devono essere letti nuovamente dopo modifiche di formattazione.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // Leggi i dati effettivi dopo le modifiche precedenti.
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // Definisci i valori ereditati a due livelli differenti.
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // Un valore locale sulla porzione sovrascrive entrambi i valori ereditati.
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // Modificare un valore ereditato non sovrascrive un valore locale esistente.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // Cancella il valore locale. La porzione ora eredita nuovamente dal paragrafo.
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // Cancella il valore del paragrafo. Il valore predefinito della presentazione fornisce ora il risultato.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La priorità in questo esempio è la formattazione locale della porzione, poi quella del paragrafo e infine il valore predefinito della presentazione. Altri oggetti possono avere catene di ereditarietà diverse, ma il principio è lo stesso: vince un valore esplicito più specifico, e [getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/portionformat/geteffective/) restituisce il risultato finale.

## **Ottenere le proprietà di testo effettive**

La formattazione del testo è suddivisa tra diversi oggetti:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/geteffective/) risolve le proprietà del frame di testo come margini, ancoraggio, adattamento automatico e direzione verticale del testo.
- [TextStyle.getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/textstyle/geteffective/) risolve la formattazione dei paragrafi per ogni livello di stile di testo.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/geteffective/) risolve le proprietà del paragrafo come allineamento, rientro e elenchi puntati.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/portionformat/geteffective/) risolve le proprietà dei caratteri come altezza del carattere, tipo di carattere, colore, grassetto e corsivo.

Per l’esempio successivo, `text-formatting.pptx` deve contenere almeno una diapositiva e una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) con un frame di testo non vuoto. L’AutoShape può trovarsi in qualsiasi posizione della raccolta di forme; il codice cerca un oggetto appropriato e lo valida prima dell’uso.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Ottenere le proprietà 3D effettive**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/geteffective/) restituisce un unico oggetto di dati effettivi che raggruppa tutte le impostazioni 3D risolte. I suoi metodi [getCamera](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/geteffective/), [getLightRig](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/geteffective/), [getBevelTop](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/geteffective/) e [getBevelBottom](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/geteffective/) espongono i corrispondenti dati effettivi. Leggere queste impostazioni correlate insieme facilita la comprensione dell’aspetto 3D finale di una forma.

Per questo esempio, `shape-3d.pptx` deve contenere almeno una forma nella sua prima diapositiva. Applica una telecamera 3D, illuminazione o impostazioni di smusso a quella forma se desideri che l’output contenga valori diversi da quelli predefiniti.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Ottenere la formattazione della tabella effettiva**

La formattazione della tabella può derivare dallo stile della tabella e dai formati applicati all’intera tabella, a una colonna, a una riga o a una singola cella. In caso di conflitti tra riempimenti definiti esplicitamente, la priorità è cella, riga, colonna e infine tutta la tabella. Il formato effettivo di una cella è il formato finale usato per disegnare quella cella.

Per questo esempio, `table-formatting.pptx` deve contenere almeno una tabella nella sua prima diapositiva. La tabella deve avere almeno una riga e una colonna. Il codice ricerca una [Table](https://reference.aspose.com/slides/it/php-java/aspose.slides/table/) invece di presumere che `getShapes()->get_Item(0)` sia una tabella.

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Se ti serve il colore anziché solo il tipo di riempimento, controlla prima il valore effettivo di [getFillType](https://reference.aspose.com/slides/it/php-java/aspose.slides/fillformat/geteffective/) e poi leggi il metodo corrispondente a quel tipo—ad esempio, [getSolidFillColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/fillformat/geteffective/) per un riempimento solido.

## **Rileggere i dati effettivi dopo le modifiche**

I dati effettivi descrivono la gerarchia di formattazione al momento della risoluzione. Chiama nuovamente `getEffective` dopo aver modificato qualsiasi elemento che può partecipare a quella gerarchia, inclusi:

- la formattazione locale dell’oggetto;
- i valori predefiniti di paragrafo o di frame di testo;
- lo stile della tabella, la tabella, la colonna, la riga o il formato della cella;
- la formattazione di layout o di diapositiva master;
- i dati del tema o i valori predefiniti a livello di presentazione;
- il layout o il master assegnato a una diapositiva.

Non conservare un oggetto di dati effettivi come snapshot permanente. Aspose.Slides può memorizzare nella cache alcuni dati effettivi internamente, e una successiva chiamata a `getEffective` può aggiornare quei dati. Se devi confrontare i valori prima e dopo una modifica, copia i valori scalari di cui hai bisogno—come altezza del carattere, colore, allineamento o larghezza dello smusso—nelle tue variabili prima di effettuare la modifica.

Per modificare un valore, aggiorna l’oggetto di formato locale appropriato e poi chiama `getEffective` per verificare il risultato. Gli oggetti di dati effettivi sono di sola lettura.

## **FAQ**

**Come posso capire quale livello ha fornito un valore effettivo?**

I dati effettivi contengono il valore finale, non la sua origine. Esamina gli oggetti locali applicabili dal livello più specifico verso l’esterno. Per il testo, questo può includere porzione, paragrafo, frame di testo, layout, master, tema e valori predefiniti della presentazione. Valori non definiti come `NAN` o `null` indicano che la ricerca continua a un livello superiore.

**Cosa succede quando nessun livello definisce una proprietà?**

Aspose.Slides risolve il valore predefinito appropriato di PowerPoint o della libreria. Quel valore risolto appare nei dati effettivi anche se nessun oggetto locale lo definisce esplicitamente.

**Perché un valore effettivo a volte è uguale al valore locale?**

Il valore locale ha vinto il calcolo di ereditarietà. Questo è previsto quando la proprietà è impostata esplicitamente sull’oggetto e nessuna regola più specifica la sovrascrive.

**Quando devo usare i dati locali invece dei dati effettivi?**

Usa i dati locali per ispezionare o modificare un livello di formattazione specifico. Usa i dati effettivi quando ti serve l’aspetto finale dopo l’eredità, le regole del tema e gli stili applicabili. L’[esempio completo di confronto](#compare-local-inherited-and-effective-values) dimostra entrambi nello stesso flusso di lavoro.