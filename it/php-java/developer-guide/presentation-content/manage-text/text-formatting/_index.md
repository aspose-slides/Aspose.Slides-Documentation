---
title: Formattazione del testo della presentazione in PHP
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/php-java/text-formatting/
keywords:
- allineare il paragrafo
- stile del testo
- sfondo del testo
- trasparenza del testo
- spaziatura dei caratteri
- proprietà del carattere
- famiglia del carattere
- rotazione del testo
- angolo di rotazione
- riquadro di testo
- interlinea
- proprietà autofit
- ancoraggio del riquadro di testo
- tabulazione del testo
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Formatta e stile il testo in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per PHP tramite Java. Personalizza caratteri, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per PHP tramite Java. Copre i colori di sfondo, la trasparenza, la spaziatura dei caratteri, le proprietà dei caratteri, la rotazione, la spaziatura dei paragrafi, il comportamento di autofit, l'ancoraggio del testo, i tabulatori e le impostazioni della lingua.

Salvo indicazione contraria, gli esempi utilizzano [sample.pptx](sample.pptx). La prima forma nella prima diapositiva è una casella di testo, e il suo primo paragrafo contiene il testo mostrato di seguito. Sia gli indici delle diapositive sia quelli delle forme sono basati su zero. Gli esempi che selezionano porzioni in grassetto usano la formattazione efficace, inclusa la formattazione in grassetto ereditata:

![Testo di esempio](sample_text.png)

Per trovare e evidenziare testo letterale o corrispondenze di espressioni regolari, vedi [Search and Replace Text](/slides/it/php-java/search-and-replace-text/).

## **Imposta colore di sfondo del testo**

Usa [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) per impostare il colore di evidenziazione predefinito per un paragrafo, oppure usa [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#getHighlightColor) per porzioni di testo individuali.

L'esempio seguente imposta un'evidenziazione grigia chiara come predefinita per il primo paragrafo. I colori di evidenziazione espliciti sulle porzioni individuali hanno precedenza su questo valore predefinito:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // Imposta il colore di evidenziazione per l'intero paragrafo.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Il paragrafo grigio](gray_paragraph.png)

L'esempio di codice qui sotto dimostra come impostare il colore di sfondo per **porzioni di testo con carattere in grassetto**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Imposta il colore di evidenziazione per la porzione di testo.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Le porzioni di testo grigie](gray_text_portions.png)

## **Allinea paragrafi di testo**

Usa [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setAlignment) per impostare l'allineamento del paragrafo all'interno di una casella di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato, ecc.

L'esempio di codice seguente mostra come allineare il paragrafo al **centro**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Imposta l'allineamento del paragrafo al centro.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Il paragrafo allineato](aligned_paragraph.png)

## **Imposta trasparenza per il testo**

La trasparenza del testo è controllata attraverso la componente alfa del colore assegnato a [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#getFillFormat). Negli esempi sotto, `alpha = 50` è un valore alfa ARGB sulla scala 0–255, non una percentuale di trasparenza.

L'esempio di codice sotto mostra come applicare la trasparenza al **paragrafo intero**:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Imposta il colore di riempimento del testo a un colore trasparente.
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Il paragrafo trasparente](transparent_paragraph.png)

L'esempio di codice seguente mostra come applicare la trasparenza a **porzioni di testo con carattere in grassetto**:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Imposta la trasparenza della porzione di testo.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor($transparentColor);
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Le porzioni di testo trasparenti](transparent_text_portions.png)

## **Imposta spaziatura dei caratteri per il testo**

Usa [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setSpacing) per espandere o comprimere la spaziatura tra i caratteri in una casella di testo. Gli esempi aggiungono 3 punti di spaziatura; valori negativi comprimono il testo.

Il codice PHP seguente mostra come espandere la spaziatura dei caratteri nel **paragrafo intero**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Nota: usa valori negativi per comprimere la spaziatura dei caratteri.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Espandi la spaziatura dei caratteri.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![La spaziatura dei caratteri nel paragrafo](character_spacing_in_paragraph.png)

L'esempio di codice sotto mostra come espandere la spaziatura dei caratteri in **porzioni di testo con carattere in grassetto**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Nota: usa valori negativi per comprimere la spaziatura dei caratteri.
            $portion->getPortionFormat()->setSpacing(3); // Espandi la spaziatura dei caratteri.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![La spaziatura dei caratteri nelle porzioni di testo](character_spacing_in_text_portions.png)

### **Disabilita il kerning per caratteri specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più stretto rispetto allo stesso testo visualizzato in PowerPoint. Ciò può accadere perché PowerPoint può ignorare i dati di kerning per alcuni caratteri, anche quando il carattere contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per rendere l'output più vicino a PowerPoint in tali situazioni, è possibile disabilitare il kerning per le porzioni di testo che utilizzano il carattere interessato. Imposta [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) a un valore superiore alla dimensione effettiva del carattere. Questo esempio richiede "presentation.pptx" con una casella di testo come prima forma nella prima diapositiva. Controlla i nomi effettivi dei caratteri, inclusi quelli ereditati, e imposta una soglia di 100 punti per le porzioni che usano Roboto. Ciò disabilita il kerning per le porzioni corrispondenti con una dimensione del carattere inferiore a 100 punti:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat()->getEffective();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portion->getPortionFormat()->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Per il testo corrispondente al di sotto della soglia, questa impostazione impedisce il kerning e può aiutare ad avvicinare il rendering di Aspose.Slides a quello visivo di PowerPoint per i caratteri soggetti a questo comportamento specifico di PowerPoint.

## **Gestisci le proprietà del carattere del testo**

Le proprietà del carattere possono essere impostate a livello di paragrafo tramite [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) o su porzioni individuali tramite [PortionFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/portionformat/).

L'esempio seguente imposta il carattere predefinito del primo paragrafo a Times New Roman 12 punti con formattazione in grassetto, corsivo e sottolineatura puntinata. La formattazione esplicita su porzioni individuali ha precedenza su questi valori predefiniti:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // Imposta le proprietà del carattere per il paragrafo.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont($font);

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Le proprietà del carattere per il paragrafo](font_properties_for_paragraph.png)

L'esempio seguente applica Times New Roman 13 punti, formattazione corsiva e sottolineatura puntinata a porzioni il cui formattazione efficace è in grassetto:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Imposta le proprietà del carattere per la porzione di testo.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont($font);
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Le proprietà del carattere per le porzioni di testo](font_properties_for_text_portions.png)

## **Imposta rotazione del testo**

Usa [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/#setTextVerticalType) per impostare un orientamento del testo predefinito all'interno di una forma.

Il codice di esempio seguente imposta l'orientamento del testo nella forma su [TextVerticalType::Vertical270](https://reference.aspose.com/slides/it/php-java/aspose.slides/textverticaltype/), che ruota il testo **di 90 gradi in senso antiorario**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![La rotazione del testo](text_rotation.png)

## **Imposta rotazione personalizzata per i riquadri di testo**

Usa [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/#setRotationAngle) per impostare un angolo di rotazione personalizzato per un [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/).

Il codice di esempio sotto ruota il riquadro di testo di 3 gradi in senso orario all'interno della forma:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![La rotazione personalizzata del testo](custom_text_rotation.png)

## **Imposta interlinea dei paragrafi**

Aspose.Slides fornisce [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setSpaceBefore) e [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setSpaceWithin) per controllare la spaziatura dei paragrafi. Queste proprietà vengono usate come segue:

* Usa un valore positivo per specificare l’interlinea come percentuale dell’altezza della riga.
* Usa un valore negativo per specificare l’interlinea in punti.

L'esempio seguente imposta la spaziatura interna del primo paragrafo al 200 % dell’altezza della riga (doppia interlinea):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![L’interlinea all'interno del paragrafo](line_spacing.png)

## **Controlla l'interruzione di riga**

Le regole di interruzione di riga dei paragrafi sono utili in blocchi di testo stretti e in presentazioni che mescolano testo latino e testi dell'Est asiatico. I seguenti metodi appartengono a [ParagraphFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/), quindi si applicano all'intero paragrafo:

- [setLatinLineBreak](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) controlla le regole di interruzione di riga latine. In testo misto, modificarlo può anche cambiare dove il testo e la punteggiatura dell'Est asiatico adiacenti vanno a capo.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) controlla le regole di interruzione di riga dell'Est asiatico, incluse le restrizioni sui caratteri all'inizio e alla fine di una riga.

Queste regole non sostituiscono [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/#setWrapText), che abilita l'adattamento automatico all'interno di un riquadro di testo. Influenzano il layout quando avviene l'adattamento; non inseriscono caratteri di interruzione di riga. Un'interruzione di riga esplicita forza una nuova linea all'interno del paragrafo indipendentemente dalla larghezza disponibile.

L'esempio autonomo seguente crea un blocco di testo stretto contenente cinese e latino. Imposta entrambe le opzioni di interruzione di riga esplicitamente e salva "line_breaking.pptx". Per sperimentare una o l'altra regola, modifica il valore corrispondente mantenendo fissi gli altri parametri. L'esempio usa Arial 24 pt e SimSun con una larghezza del riquadro di 160 pt e margini orizzontali del riquadro pari a zero. [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/#setAutofitType) è chiamato con [TextAutofitType::None](https://reference.aspose.com/slides/it/php-java/aspose.slides/textautofittype/) così che la dimensione del testo e le dimensioni del riquadro rimangano fisse.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 160, 300);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("中文排版测试，PowerPoint 中文演示。");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $eastAsianFont = new FontData("SimSun");
    $format->getDefaultPortionFormat()->setEastAsianFont($eastAsianFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setLatinLineBreak(NullableBool::False);
    $format->setEastAsianLineBreak(NullableBool::True);

    $presentation->save("line_breaking.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Controlla la punteggiatura sospesa**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) consente alla punteggiatura idonea di estendersi oltre il bordo destro della linea di testo invece di occupare la riga successiva. Si applica all'intero paragrafo ed è diverso da un rientro sospeso.

L'esempio autonomo seguente abilita la punteggiatura sospesa in un riquadro di testo largo 100 pt e salva "hanging_punctuation.pptx". Con Arial 24 pt e margini orizzontali del riquadro pari a zero, il punto finale rimane dopo "sentence" ed esce oltre il bordo destro del testo. Imposta la proprietà su [NullableBool::False](https://reference.aspose.com/slides/it/php-java/aspose.slides/nullablebool/) per confrontare: con queste impostazioni, il punto occupa una linea separata. L'adattamento è abilitato e l'autofit è disabilitato per mantenere fissa la larghezza disponibile.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 200);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("Simple text, next sentence.");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setHangingPunctuation(NullableBool::True);

    $presentation->save("hanging_punctuation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Non tutti i segni di punteggiatura possono sospendersi. Il risultato visibile dipende dalla disponibilità del carattere e dal layout: modificare il carattere, la larghezza disponibile, i margini o le impostazioni di autofit può rimuovere la differenza visibile.

## **Imposta tipo di Autofit per i riquadri di testo**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/#setAutofitType) determina come il testo si comporta quando supera i confini del suo contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma. L'esempio seguente configura la forma per ridimensionarsi in base al testo e salva il risultato in "autofit_type.pptx".

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAutofitType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Per contare le righe dopo l'adattamento automatico e vedere come cambiano testo o larghezza della forma, vedi [Count Rendered Lines](/slides/it/php-java/manage-paragraph/). Il conteggio delle righe da solo non indica se il testo trabocca dal contenitore.

## **Imposta ancoraggio dei riquadri di testo**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/#setAnchoringType) definisce come il testo è posizionato verticalmente all'interno di una forma, ad esempio in alto, al centro o in basso. L'esempio seguente ancora il testo al fondo della prima forma e salva il risultato in "text_anchor.pptx".

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Imposta tabulazione del testo**

Usa [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) e [ParagraphFormat::getTabs](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/#getTabs) per configurare i tabulatori in un paragrafo. L'esempio seguente imposta l'intervallo di tabulazione predefinito a 100 punti e aggiunge un tabulatore allineato a sinistra a 30 punti. Queste impostazioni influenzano il testo contenente caratteri di tabulazione.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TabAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![I tabulatori del paragrafo](paragraph_tabs.png)

## **Imposta lingua di correzione**

Aspose.Slides fornisce [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setLanguageId), che consente di impostare la lingua di correzione per una porzione di testo. La lingua di correzione determina la lingua usata per il controllo ortografico e grammaticale in PowerPoint.

L'esempio seguente richiede "presentation.pptx" con una casella di testo come prima forma nella prima diapositiva e almeno un paragrafo. Sostituisce il contenuto del primo paragrafo con "1。", imposta SimSun come carattere e assegna la lingua di correzione cinese semplificato (`zh-CN`). Salva il risultato in "proofing_language.pptx":

```php
use aspose\slides\FontData;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // Imposta l'Id di una lingua di correzione.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Imposta lingua predefinita**

Usa [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione. L'esempio seguente crea una presentazione con l'inglese degli Stati Uniti come lingua predefinita del testo, aggiunge una casella di testo e stampa `en-US` per la sua prima porzione di testo.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungi una nuova forma rettangolare con testo.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Verifica la lingua della prima porzione.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Imposta stile di testo predefinito**

Per applicare la formattazione di testo predefinita a livello di presentazione, usa [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getDefaultTextStyle).

L'esempio seguente imposta un carattere grassetto da 14 punti come predefinito per i paragrafi di livello superiore in una nuova presentazione e lo salva in "default_text_style.pptx". Il testo può ereditare questi valori predefiniti a meno che una formattazione più specifica non li sovrascriva.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Ottieni il formato del paragrafo di livello superiore.
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Estrai testo con l'effetto Maiuscole**

In PowerPoint, applicare l'effetto carattere **All Caps** fa apparire il testo in maiuscolo nella diapositiva anche se è stato digitato in minuscolo. Quando si recupera tale porzione di testo con Aspose.Slides, la libreria restituisce il testo esattamente come è stato inserito. Per coincidere con il testo visualizzato, controlla [TextCapType](https://reference.aspose.com/slides/it/php-java/aspose.slides/textcaptype/) e converte la stringa restituita in maiuscolo quando il valore è `All`.

Questo esempio richiede "sample2.pptx" con una casella di testo come prima forma nella prima diapositiva. La prima porzione del primo paragrafo contiene "Hello, Aspose!" con l'effetto All Caps applicato, come mostrato di seguito.

![L'effetto All Caps](all_caps_effect.png)

Il codice di esempio qui sotto mostra come estrarre il testo con l'effetto **All Caps** applicato:

```php
use aspose\slides\Presentation;
use aspose\slides\TextCapType;

$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $autoShape = $slide->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    $originalText = $textPortion->getText();
    echo "Original text: ", $originalText, "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($originalText);
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Come modifico il testo in una tabella su una diapositiva?**

Per modificare il testo in una tabella su una diapositiva, usa [Table](https://reference.aspose.com/slides/it/php-java/aspose.slides/table/). Scorri le celle e aggiorna ciascuna cella tramite [Cell::getTextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/cell/#getTextFrame) e la formattazione dei paragrafi tramite [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Come applico un colore sfumato al testo su una diapositiva PowerPoint?**

Per applicare un colore sfumato al testo, usa [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#getFillFormat). Imposta [FillFormat::setFillType](https://reference.aspose.com/slides/it/php-java/aspose.slides/fillformat/#setFillType) su [FillType::Gradient](https://reference.aspose.com/slides/it/php-java/aspose.slides/filltype/) e configura le fermate del gradiente, la direzione e la trasparenza.