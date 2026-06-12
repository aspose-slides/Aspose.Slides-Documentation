---
title: Ottieni le proprietà effettive delle forme dalle presentazioni in PHP
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
- stile di testo
- altezza del carattere
- formato di riempimento
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come Aspose.Slides per PHP tramite Java calcola e applica le proprietà effettive delle forme per una resa precisa di PowerPoint."
---
## **Panoramica**

Questo argomento spiega la differenza tra proprietà **locali** ed **effettive**. I valori locali sono valori impostati direttamente a un livello di formattazione specifico, ad esempio:

1. Proprietà della porzione su una diapositiva.  
1. Stili di testo della forma prototipo su un layout o una diapositiva master, quando la forma del riquadro di testo della porzione ne ha uno.  
1. Impostazioni di testo globali in una presentazione.

I valori locali possono essere definiti o omessi a qualsiasi livello. Quando Aspose.Slides ha bisogno della formattazione finale “come renderizzata”, risolve la catena di ereditarietà e restituisce valori **effettivi**. È possibile ottenerli chiamando il metodo `getEffective` sull’oggetto di formattazione locale.

L’esempio seguente mostra come ottenere i valori effettivi. Si presuppone che la prima forma nella prima diapositiva sia un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) con un riquadro di testo e almeno una porzione.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
I dati della formattazione effettiva rappresentano la formattazione calcolata corrente dopo l’applicazione dell’eredità. Nell’implementazione attuale, alcuni oggetti dati effettivi restituiti da metodi come [PortionFormat.getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/portionformat/geteffective/) possono essere memorizzati nella cache internamente. Richiamare nuovamente `getEffective` dopo aver modificato la formattazione padre o ereditata può aggiornare la cache e l’oggetto ottenuto in precedenza potrebbe non rappresentare più lo stato precedente. Se è necessario conservare i valori effettivi per un utilizzo futuro, copiare le proprietà richieste, ad esempio altezza del carattere, colore di riempimento, stile del carattere o allineamento, nel proprio oggetto dati.
{{% /alert %}}

## **Ottenere le proprietà effettive di una fotocamera**

Aspose.Slides consente di ottenere le proprietà effettive di una fotocamera. I dati effettivi restituiti da [ThreeDFormat.getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/geteffective/) contengono le proprietà finali della fotocamera per un [ThreeDFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/).

Il campione di codice seguente mostra come ottenere le proprietà effettive per la fotocamera. Si presuppone che la prima forma nella prima diapositiva abbia una formattazione 3D.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Ottenere le proprietà effettive di un impianto di illuminazione**

Aspose.Slides consente di ottenere le proprietà effettive di un impianto di illuminazione. I dati effettivi restituiti da [ThreeDFormat.getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/geteffective/) contengono le proprietà finali dell’impianto di illuminazione per un [ThreeDFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/).

Il campione di codice seguente mostra come ottenere le proprietà effettive per l’impianto di illuminazione. Si presuppone che la prima forma nella prima diapositiva abbia una formattazione 3D.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Ottenere le proprietà effettive di una forma smussata**

Aspose.Slides consente di ottenere le proprietà effettive di una smussatura di forma. I dati effettivi restituiti da [ThreeDFormat.getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/geteffective/) contengono le proprietà finali del rilievo per un [ThreeDFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/).

Il campione di codice seguente mostra come ottenere le proprietà effettive per la smussatura superiore di una forma. Si presuppone che la prima forma nella prima diapositiva abbia una formattazione 3D.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Ottenere le proprietà effettive di un TextFrame**

Con Aspose.Slides è possibile ottenere le proprietà effettive di un TextFrame. I dati effettivi restituiti da [TextFrameFormat.getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/geteffective/) contengono le proprietà di formattazione del TextFrame.

Il campione di codice seguente mostra come ottenere le proprietà di formattazione effettive del TextFrame. Si presuppone che la prima forma nella prima diapositiva sia un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) con un TextFrame.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Ottenere le proprietà effettive di uno TextStyle**

Con Aspose.Slides è possibile ottenere le proprietà effettive di uno TextStyle. I dati effettivi restituiti da [TextStyle.getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/textstyle/geteffective/) contengono le proprietà dello stile di testo.

Il campione di codice seguente mostra come ottenere le proprietà effettive di uno TextStyle. Si presuppone che la prima forma nella prima diapositiva sia un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) con un TextFrame.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Ottenere il valore effettivo dell’altezza del carattere**

Con Aspose.Slides è possibile ottenere l’altezza del carattere effettiva. Il codice seguente dimostra come l’altezza del carattere effettiva di una porzione cambi dopo che sono stati impostati valori locali di altezza del carattere a diversi livelli della struttura della presentazione.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ottenere il formato di riempimento effettivo per una Tabella**

Con Aspose.Slides è possibile ottenere la formattazione di riempimento effettiva per parti diverse di una tabella. I dati effettivi restituiti dagli oggetti di formattazione contengono le proprietà di [FillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/fillformat/). La formattazione della cella ha priorità più alta rispetto a quella della riga, la formattazione della riga ha priorità più alta rispetto a quella della colonna e la formattazione della colonna ha priorità più alta rispetto a quella dell’intera tabella.

Di conseguenza, le proprietà effettive di [CellFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/cellformat/) sono utilizzate per disegnare la cella della tabella. Il campione di codice seguente mostra come ottenere la formattazione di riempimento effettiva per le diverse parti della tabella. Si presuppone che la prima forma nella prima diapositiva sia una [Table](https://reference.aspose.com/slides/it/php-java/aspose.slides/table/).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**`getEffective` restituisce uno snapshot?**

Non sempre. I dati effettivi rappresentano la formattazione calcolata dopo l’applicazione dell’eredità, ma alcuni oggetti dati effettivi possono essere memorizzati nella cache internamente. Una chiamata successiva a `getEffective` può ricalcolare la formattazione e aggiornare la cache, quindi l’oggetto ottenuto in precedenza non dovrebbe essere considerato uno snapshot permanente.

**Quando dovrei rileggere le proprietà effettive?**

Richiamare `getEffective` di nuovo dopo aver modificato la formattazione locale, gli stili padre, la formattazione del layout, la formattazione master o le impostazioni predefinite a livello di presentazione. La chiamata successiva rivaluta la gerarchia di formattazione e restituisce il risultato effettivo corrente.

**La modifica o la rimozione di un layout/master influisce sulle proprietà effettive già recuperate?**

Sì, ma la modifica si riflette nella chiamata successiva a `getEffective`. Se una fonte di formattazione padre viene cambiata o rimossa, i dati effettivi ottenuti in precedenza possono diventare obsoleti. Una volta richiamato nuovamente `getEffective`, Aspose.Slides rivaluta l’albero di formattazione e i caratteri, i colori, le dimensioni o gli altri valori risultanti possono cambiare.

**Posso modificare i valori tramite gli oggetti dati effettivi?**

No. Gli oggetti dati effettivi espongono solo i valori calcolati. Apportare le modifiche negli oggetti di formattazione locale e quindi ottenere nuovamente i valori effettivi.

** Cosa succede se una proprietà non è impostata a livello di forma, né nel layout/master, né nelle impostazioni globali?**

Il valore effettivo è determinato dal meccanismo predefinito, che include le impostazioni predefinite di PowerPoint e di Aspose.Slides. Quel valore risolto diventa parte dei dati effettivi correnti.

**Da un valore di carattere effettivo, posso capire a quale livello è stata fornita la dimensione o il tipo di carattere?**

Non direttamente. I dati effettivi restituiscono il valore finale. Per individuare la fonte, controllare i valori locali nella porzione, nel paragrafo, nel TextFrame e negli stili di testo a livello di layout, master e presentazione per vedere dove appare la prima definizione esplicita.

**Perché a volte i valori effettivi sembrano identici a quelli locali?**

Perché il valore locale è risultato finale (non è stata necessaria alcuna eredità a un livello superiore). In questi casi il valore effettivo corrisponde a quello locale.

**Quando dovrei usare le proprietà effettive e quando dovrei lavorare solo con quelle locali?**

Utilizzare i dati effettivi quando è necessario il risultato “come renderizzato” dopo l’applicazione di tutta l’eredità, ad esempio per allineare colori, rientri o dimensioni. Se è necessario conservare tali valori indipendentemente da futuri cambiamenti di formattazione, copiare le proprietà richieste nel proprio oggetto. Se è necessario modificare la formattazione a un livello specifico, modificare le proprietà locali e, se necessario, rileggere i dati effettivi per verificare il risultato.