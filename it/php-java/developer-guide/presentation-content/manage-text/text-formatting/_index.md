---
title: Formattare il testo della presentazione in PHP
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/php-java/text-formatting/
keywords:
- allineamento paragrafo
- stile del testo
- sfondo del testo
- trasparenza del testo
- spaziatura dei caratteri
- proprietà del carattere
- famiglia di caratteri
- rotazione del testo
- angolo di rotazione
- cornice del testo
- interlinea
- proprietà di adattamento automatico
- ancora della cornice di testo
- tabulazione del testo
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Formatta e stila il testo in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per PHP tramite Java. Personalizza caratteri, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per PHP tramite Java. Copre i colori di sfondo, la trasparenza, la spaziatura dei caratteri, le proprietà dei caratteri, la rotazione, la spaziatura dei paragrafi, il comportamento di adattamento automatico, l'ancoraggio del testo, le tabulazioni e le impostazioni della lingua.

Se non specificato diversamente, gli esempi usano [sample.pptx](sample.pptx). La prima forma nella sua prima diapositiva è una casella di testo, e il suo primo paragrafo contiene il testo mostrato sotto. Sia gli indici delle diapositive che delle forme sono basati su zero. Gli esempi che selezionano porzioni in grassetto usano la formattazione effettiva, inclusa la formattazione in grassetto ereditata:

![Testo di esempio](sample_text.png)

Per trovare e evidenziare testo letterale o corrispondenze di espressioni regolari, vedere [Cerca e sostituisci testo](/slides/it/php-java/search-and-replace-text/).

## **Imposta colore di sfondo del testo**

Usa [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) per impostare il colore di evidenziazione predefinito per un paragrafo, o usa [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getHighlightColor) per singole porzioni di testo.

Il seguente esempio imposta un'evidenziazione grigio chiaro come predefinita per il primo paragrafo. I colori di evidenziazione espliciti sulle singole porzioni hanno la precedenza su questo valore predefinito:

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

L'esempio di codice seguente dimostra come impostare il colore di sfondo per **porzioni di testo con un carattere in grassetto**:

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

Usa [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) per impostare l'allineamento del paragrafo all'interno di un riquadro di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato, ecc.

Il seguente esempio di codice mostra come allineare il paragrafo al **centro**:

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

## **Allinea i caratteri all'interno di una riga**

Usa [ParagraphFormat::setFontAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setFontAlignment) per allineare verticalmente le porzioni di testo di diverse dimensioni di carattere all'interno di una riga. Questa impostazione si applica all'intero paragrafo e controlla l'allineamento all'interno di ciascuna delle sue righe.

Il seguente esempio autonomo crea quattro caselle di testo etichettate in una diapositiva. Ogni paragrafo contiene lo stesso testo a 18, 36 e 54 punti, con un diverso allineamento del carattere. Usa Arial, disabilita l'adattamento automatico e l'andare a capo, e mantiene i riquadri di testo sufficientemente grandi per una singola riga.

```php
use aspose\slides\FillType;
use aspose\slides\FontAlignment;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $alignments = [FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom];
    $alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    $fontSizes = [18, 36, 54];
    $font = new FontData("Arial");
    $gray = java("java.awt.Color")->GRAY;
    $black = java("java.awt.Color")->BLACK;

    for ($i = 0; $i < count($alignments); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20 + $i * 130, 660, 120);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);

        $label = $textFrame->getParagraphs()->get_Item(0);
        $label->setText($alignmentNames[$i]);
        $label->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($gray);

        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setFontAlignment($alignments[$i]);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

        foreach ($fontSizes as $fontSize) {
            $portion = new Portion("Ag ");
            $portion->getPortionFormat()->setFontHeight($fontSize);
            $paragraph->getPortions()->add($portion);
        }

        $textFrame->getParagraphs()->add($paragraph);
    }

    $presentation->save("font_alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Confronto di allineamento del carattere alla linea di base, superiore, centrale e inferiore con dimensioni di carattere miste](font_alignment.png)

L'allineamento dei caratteri utilizza le metriche dei caratteri, quindi i bordi visibili delle singole lettere non si allineano necessariamente esattamente. L'esempio include sia una lettera maiuscola che un discendente per mostrare la differenza tra l'allineamento alla linea di base e quello inferiore. La disponibilità e la sostituzione dei caratteri, i caratteri usati e la differenza nelle dimensioni dei caratteri influenzano il risultato. Le dimensioni del riquadro, i margini, la spaziatura delle righe, l'andare a capo e l'adattamento automatico influenzano anche il layout; usare gli stessi caratteri e impostazioni di layout quando si confrontano le modalità.

Questa impostazione differisce da [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment), che controlla l'allineamento orizzontale del paragrafo, e da [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType), che posiziona il blocco di testo verticalmente all'interno della forma. La formattazione apice e pedice tramite [BasePortionFormat::setEscapement](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) sposta le singole porzioni rispetto alla linea di base invece di impostare l'allineamento dei caratteri per le righe del paragrafo.

## **Imposta trasparenza per il testo**

La trasparenza del testo è controllata tramite il componente alfa del colore assegnato a [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). Negli esempi seguenti, `alpha = 50` è un valore di canale alfa ARGB su scala 0–255, non una percentuale di trasparenza.

L'esempio di codice seguente mostra come applicare la trasparenza all'**intero paragrafo**:

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

Il seguente esempio di codice mostra come applicare la trasparenza a **porzioni di testo con un carattere in grassetto**:

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

Usa [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setSpacing) per espandere o comprimere la spaziatura tra i caratteri in una casella di testo. Gli esempi aggiungono 3 punti di spaziatura; valori negativi comprimono il testo.

Il seguente codice PHP mostra come espandere la spaziatura dei caratteri nel **intero paragrafo**:

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

L'esempio di codice sotto mostra come espandere la spaziatura dei caratteri in **porzioni di testo con un carattere in grassetto**:

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

Per avvicinare il risultato renderizzato a PowerPoint in tali casi, è possibile disabilitare il kerning per le porzioni di testo che usano il carattere interessato. Imposta [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) a un valore maggiore della dimensione effettiva del carattere. Questo esempio richiede “presentation.pptx” con una casella di testo come prima forma sulla prima diapositiva. Controlla i nomi dei caratteri effettivi, inclusi i caratteri ereditati, e imposta una soglia di 100 punti per le porzioni che usano Roboto. Questo disabilita il kerning per le porzioni corrispondenti con una dimensione del carattere inferiore a 100 punti:

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

Per il testo corrispondente al di sotto della soglia, questa impostazione impedisce il kerning e può aiutare ad avvicinare il rendering di Aspose.Slides all'output visivo di PowerPoint per i caratteri affetti da questo comportamento specifico di PowerPoint.

## **Gestisci proprietà del carattere del testo**

Le proprietà del carattere possono essere impostate a livello di paragrafo tramite [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) o su singole porzioni tramite [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/).

Il seguente esempio imposta il carattere predefinito del primo paragrafo a Times New Roman 12 pt con grassetto, corsivo e sottolineatura punteggiata. La formattazione esplicita su singole porzioni ha la precedenza su questi valori predefiniti:

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

Il seguente esempio applica Times New Roman 13 pt, formattazione corsiva e una sottolineatura punteggiata alle porzioni il cui formattazione effettiva è in grassetto:

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

## **Controlla normalizzazione altezza testo**

Usa [BasePortionFormat::setNormaliseHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setNormaliseHeight) quando si riproduce la tipografia di un modello o si indagano differenze nell'altezza dei caratteri. In PowerPoint, abilitare la normalizzazione estende o comprime verticalmente i singoli caratteri per dare loro un’altezza visibile uniforme all’interno della porzione di testo. Non garantisce altezze uguali tra caratteri diversi.

Imposta la proprietà su [NullableBool::True or False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) per abilitare o disabilitare esplicitamente la normalizzazione. `NullableBool::NotDefined` lascia l’impostazione locale non impostata così che la porzione erediti il valore, ad esempio dal [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) del paragrafo. Non equivale a `False`. Usa [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) e leggi `getNormaliseHeight` sui dati di formattazione effettiva restituiti per ottenere il valore booleano risolto.

L'esempio autonomo seguente richiede **Arial** installato. Crea due blocchi di testo contenenti le stesse lettere maiuscole, minuscole, discendenti e caratteri accentati a 54 pt. Entrambi i paragrafi abilitano la normalizzazione per impostazione predefinita. La porzione superiore la disabilita esplicitamente; la porzione inferiore la eredita. Le dimensioni del riquadro, i margini e la spaziatura dei paragrafi sono identici, con wrapping e autofit disabilitati per mantenere il confronto coerente. L’esempio stampa `False: false` e `NotDefined: true`, quindi salva “text_height_normalization.pptx”.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $settings = [NullableBool::False, NullableBool::NotDefined];
    $settingNames = ["False", "NotDefined"];

    for ($i = 0; $i < count($settings); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 60 + $i * 200, 660, 150);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->setText("Hxgjpq ÅÉ 0123");
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setMarginTop(0);
        $textFrame->getTextFrameFormat()->setMarginLeft(0);

        $paragraph = $textFrame->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $paragraph->getParagraphFormat()->setSpaceWithin(100);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setNormaliseHeight(NullableBool::True);

        $portion = $paragraph->getPortions()->get_Item(0);
        $font = new FontData("Arial");
        $portion->getPortionFormat()->setLatinFont($font);
        $portion->getPortionFormat()->setFontHeight(54);
        $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $portion->getPortionFormat()->setNormaliseHeight($settings[$i]);

        $normaliseHeight = java_values($portion->getPortionFormat()->getEffective()->getNormaliseHeight());
        echo $settingNames[$i], ": ", $normaliseHeight ? "true" : "false", PHP_EOL;
    }

    $presentation->save("text_height_normalization.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il confronto sotto è stato esportato dalla presentazione salvata. La riga superiore ha la normalizzazione disabilitata (`False`); la riga inferiore eredita l’impostazione abilitata (`NotDefined` → `True`). Mantieni Arial installato per riprodurre quest’aspetto.

![Testo Arial a 54 punti con normalizzazione disabilitata sopra e normalizzazione ereditata abilitata sotto](text_height_normalization.png)

La normalizzazione modifica l’altezza dei caratteri senza cambiare il valore assegnato a [getFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFontHeight), che specifica la dimensione del carattere in punti. La [setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) del paragrafo controlla la spaziatura delle righe, mentre la [setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) del riquadro di testo controlla come il testo o il suo contenitore si adattano. Queste impostazioni hanno scopi diversi e possono influenzare il layout complessivo in modo indipendente. Per ulteriori informazioni sulla formattazione dei paragrafi e l’ereditarietà, vedere [Gestisci paragrafo](/slides/it/php-java/manage-paragraph/).

## **Applica e rimuovi il barrato**

Usa [BasePortionFormat::setStrikethroughType](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setStrikethroughType) su una porzione di testo per visualizzare correzioni, termini annullati o prezzi precedenti senza cancellare il testo originale. Impostalo su [TextStrikethroughType::Single or Double](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/) per una o due linee attraverso il testo.

Per rimuovere il barrato, passa [TextStrikethroughType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#None). Questo disabilita esplicitamente l’effetto, anche se la formattazione circostante specifica il barrato. Al contrario, [TextStrikethroughType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#NotDefined) lascia l’impostazione locale non definita, consentendo alla porzione di ereditare la formattazione, ad esempio dal paragrafo. Non garantisce che il barrato sia rimosso. Usa [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) per leggere la formattazione risultante, inclusi i valori ereditati.

Il seguente esempio autonomo crea tre confronti di prezzi. Ogni paragrafo ha porzioni separate per l’etichetta, il prezzo precedente e il prezzo attuale, così solo il prezzo precedente è interessato. La prima riga applica e poi rimuove il barrato; le altre righe mantengono rispettivamente il barrato singolo e doppio. Modificando questa impostazione si preserva il testo e le altre formattazioni, incluso il prezzo precedente in grassetto.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextStrikethroughType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $labels = [ "None: ", "Single: ", "Double: " ];

    foreach ($labels as $label) {
        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceAfter(20);

        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $format->setFontHeight(28);
        $font = new FontData("Arial");
        $format->setLatinFont($font);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $blackColor = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($blackColor);

        $labelPortion = new Portion($label);
        $paragraph->getPortions()->add($labelPortion);

        $previousPrice = new Portion("$100");
        $previousPrice->getPortionFormat()->setFontBold(NullableBool::True);
        $paragraph->getPortions()->add($previousPrice);
        $currentPrice = new Portion(" → $80");
        $paragraph->getPortions()->add($currentPrice);

        $shape->getTextFrame()->getParagraphs()->add($paragraph);
    }

    $paragraphs = $shape->getTextFrame()->getParagraphs();

    // Applica il barrato, quindi rimuovilo esplicitamente dal primo prezzo precedente.
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::None);

    $paragraphs->get_Item(1)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(2)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Double);

    $presentation->save("strikethrough.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato, dall’alto verso il basso: nessun barrato, barrato singolo e barrato doppio.

![Prezzi precedenti senza barrato, con barrato singolo e con barrato doppio](strikethrough.png)

## **Imposta rotazione del testo**

Usa [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType) per impostare un’orientazione del testo predefinita all’interno di una forma.

Il seguente esempio di codice imposta l’orientamento del testo nella forma su [TextVerticalType::Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/), che ruota il testo **90 gradi in senso antiorario**:

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

## **Visualizza cifre affiancate nel testo verticale**

Per mantenere un numero a due cifre unito in un’etichetta giapponese verticale, metti entrambe le cifre in una sola porzione di testo e chiama [BasePortionFormat::setKumimoji](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKumimoji) su quella porzione. L’esempio usa [TextVerticalType::EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#EastAsianVertical) e MS Gothic a 40 pt per entrambe le etichette. Solo il valore [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) passato alla porzione numerica differisce.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 120;

    foreach ([NullableBool::True, NullableBool::False] as $kumimoji) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 48, 120, 420);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $frame = $label->addTextFrame("");
        $frame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::EastAsianVertical);

        $paragraph = $frame->getParagraphs()->get_Item(0);
        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $font = new FontData("MS Gothic");
        $format->setLatinFont($font);
        $format->setEastAsianFont($font);
        $format->setFontHeight(40);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($black);

        $digits = new Portion("12");
        $digits->getPortionFormat()->setKumimoji($kumimoji);

        $portions = $paragraph->getPortions();
        $portions->clear();
        $portions->add(new Portion("令和"));
        $portions->add($digits);
        $portions->add(new Portion("年"));

        $x += 240;
    }
    $presentation->save("vertical_date.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

In PowerPoint, l’etichetta sinistra (`True`) mostra le cifre in verticale e affiancate tra 和 e 年. Nell’etichetta destra (`False`), la coppia è ruotata di 90 gradi in senso orario. I caratteri giapponesi circostanti rimangono verticali in entrambe le etichette.

![Confronto PowerPoint di etichette di data verticali con cifre verticali a sinistra e cifre ruotate a destra](vertical_date.png)

## **Imposta rotazione personalizzata per i riquadri di testo**

Usa [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) per impostare un angolo di rotazione personalizzato per un [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).

Il codice esempio sotto ruota il riquadro di testo di 3 gradi in senso orario all’interno della forma:

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

## **Imposta spaziatura delle righe dei paragrafi**

Aspose.Slides fornisce [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) e [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) per controllare la spaziatura dei paragrafi. Queste proprietà si usano così:

* Usa un valore positivo per specificare la spaziatura delle righe come percentuale dell’altezza della riga.
* Usa un valore negativo per specificare la spaziatura delle righe in punti.

Il seguente esempio imposta la spaziatura all’interno del primo paragrafo al 200 % dell’altezza della riga (doppia spaziatura):

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

![La spaziatura delle righe all'interno del paragrafo](line_spacing.png)

## **Controlla interruzione di riga**

Le regole di interruzione di riga dei paragrafi sono utili in blocchi di testo stretti e presentazioni che mescolano testo latino e asiatico orientale. I seguenti metodi appartengono a [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/), quindi si applicano all’intero paragrafo:

- [setLatinLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) controlla le regole di interruzione di riga per il latino. In testo misto, modificarlo può anche cambiare dove il testo e la punteggiatura asiatici orientali adiacenti vanno a capo.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) controlla le regole di interruzione di riga per l’asia orientale, includendo restrizioni sui caratteri all’inizio e alla fine di una riga.

Queste regole non sostituiscono [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText), che abilita il wrapping automatico all’interno di un riquadro di testo. Influenzano il layout quando il wrapping avviene; non inseriscono caratteri di interruzione di riga. Un’interruzione di riga esplicita forza una nuova riga all’interno del paragrafo indipendentemente dalla larghezza disponibile.

Il seguente esempio autonomo crea un blocco di testo stretto contenente testo cinese e latino. Imposta esplicitamente entrambe le opzioni di interruzione di riga e salva “line_breaking.pptx”. Per sperimentare con una delle regole, modifica il valore corrispondente mantenendo fisse le altre impostazioni. L’esempio usa Arial 24 pt e SimSun con una larghezza del riquadro di 160 pt e margini orizzontali del riquadro di testo pari a zero. [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) è chiamato con [TextAutofitType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/) così che la dimensione del testo e del riquadro rimangano fisse.

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

## **Controlla punteggiatura sospesa**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) consente alla punteggiatura idonea di estendersi oltre il bordo destro della riga di testo invece di occupare la riga successiva. Si applica all’intero paragrafo ed è diverso da un rientro sospeso.

Il seguente esempio autonomo abilita la punteggiatura sospesa in un riquadro di testo largo 100 pt e salva “hanging_punctuation.pptx”. Con Arial 24 pt e margini orizzontali zero, il punto finale rimane dopo “sentence” e si estende oltre il bordo destro del testo. Imposta la proprietà su [NullableBool::False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) per confrontare: con queste impostazioni, il punto occupa una riga separata. Il wrapping è abilitato e l’autofit è disabilitato per mantenere la larghezza disponibile fissa.

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

Non tutti i segni di punteggiatura possono sospendersi. Le [condizioni di carattere e layout descritte sopra](#control-line-breaking) si applicano anche a questo confronto: modificare il carattere, la larghezza disponibile, i margini o le impostazioni di autofit può rimuovere la differenza visibile.

## **Imposta tipo di adattamento automatico per i riquadri di testo**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) determina come il testo si comporta quando supera i limiti del contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma. Il seguente esempio configura la forma per ridimensionarsi in modo da adattare il testo e salva il risultato in “autofit_type.pptx”.

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

Per contare le righe dopo il wrapping automatico e vedere come cambiano le dimensioni del testo o della forma, vedere [Conta linee renderizzate](/slides/it/php-java/manage-paragraph/). Il numero di righe da solo non indica se il testo trabocca dal contenitore.

## **Imposta ancoraggio dei riquadri di testo**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) definisce come il testo è posizionato verticalmente all’interno di una forma, ad esempio in alto, al centro o in basso. Il seguente esempio ancora il testo in basso nella prima forma e salva il risultato in “text_anchor.pptx”.

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

Usa [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) e [ParagraphFormat::getTabs](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getTabs) per configurare le tabulazioni in un paragrafo. Il seguente esempio imposta l’intervallo di tabulazione predefinito a 100 pt e aggiunge una tabulazione allineata a sinistra a 30 pt. Queste impostazioni influiscono sul testo contenente caratteri di tabulazione.

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

![Le tabulazioni del paragrafo](paragraph_tabs.png)

## **Imposta lingua di revisione**

Aspose.Slides fornisce [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId), che permette di impostare la lingua di revisione per una porzione di testo. La lingua di revisione determina la lingua usata per il controllo ortografico e grammaticale in PowerPoint.

Il seguente esempio richiede “presentation.pptx” con una casella di testo come prima forma sulla prima diapositiva e almeno un paragrafo. Sostituisce il contenuto del primo paragrafo con “1。”, imposta SimSun come carattere e assegna la lingua di revisione cinese semplificato (`zh-CN`). Salva il risultato in “proofing_language.pptx”:

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

    // Imposta l'Id di una lingua di revisione.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Copia metadati della lingua**

Quando si copia testo multilingue da un modello, preserva sia [BasePortionFormat::getLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getLanguageId) sia [BasePortionFormat::getAlternativeLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). Il seguente esempio autonomo crea una porzione di origine con l’inglese US come lingua e il francese come lingua alternativa, e copia il testo e gli identificatori in una porzione di una nuova presentazione.

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$source = new Portion("Hello! Bonjour!");
$source->getPortionFormat()->setLanguageId("en-US");
$source->getPortionFormat()->setAlternativeLanguageId("fr-FR");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $destination = new Portion();
    $destination->setText($source->getText());
    $destination->getPortionFormat()->setLanguageId($source->getPortionFormat()->getLanguageId());
    // Se la sorgente non ha una lingua alternativa, null cancella il valore di destinazione.
    $destination->getPortionFormat()->setAlternativeLanguageId($source->getPortionFormat()->getAlternativeLanguageId());
    $paragraph->getPortions()->add($destination);

    $presentation->save("copied_language_metadata.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Per provare una fonte senza lingua alternativa, ometti l’assegnazione di `"fr-FR"`. L’identificatore alternativo sarà quindi `null`, e la stessa istruzione di copia preserva la sua assenza senza introdurre un valore predefinito, anche se la destinazione aveva precedentemente una lingua alternativa assegnata.

Questi identificatori sono metadati linguistici. Preservarli non stabilisce quale dizionario PowerPoint seleziona per il controllo ortografico o grammaticale.

## **Imposta lingua predefinita**

Usa [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione. Il seguente esempio crea una presentazione con l’inglese US come lingua di testo predefinita, aggiunge una casella di testo e stampa `en-US` per la sua prima porzione di testo.

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

Per applicare la formattazione di testo predefinita a livello di presentazione, usa [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDefaultTextStyle).

Il seguente esempio imposta un carattere grassetto a 14 pt come predefinito per i paragrafi di livello superiore in una nuova presentazione e lo salva in “default_text_style.pptx”. Il testo può ereditare questi valori predefiniti a meno che una formattazione più specifica non li sovrascriva.

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

## **Estrai testo con l'effetto tutto maiuscolo**

In PowerPoint, applicare l’effetto **All Caps** al carattere fa apparire il testo in maiuscolo sulla diapositiva anche se è stato digitato originariamente in minuscolo. Quando recuperi tale porzione di testo con Aspose.Slides, la libreria restituisce il testo esattamente come è stato inserito. Per corrispondere al testo visualizzato, controlla [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) e converti la stringa restituita in maiuscolo quando il valore è `All`.

Questo esempio richiede “sample2.pptx” con una casella di testo come prima forma sulla prima diapositiva. Il suo primo paragrafo‑prima porzione contiene “Hello, Aspose!” con l’effetto All Caps applicato, come mostrato sotto.

![L'effetto Tutto maiuscolo](all_caps_effect.png)

Il codice esempio sotto mostra come estrarre il testo con l’effetto **All Caps** applicato:

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

Per modificare il testo in una tabella su una diapositiva, usa [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Itera attraverso le celle e aggiorna ciascuna cella tramite [Cell::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/#getTextFrame) e la formattazione del paragrafo tramite [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Come applico un colore sfumato al testo su una diapositiva PowerPoint?**

Per applicare un colore sfumato al testo, usa [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). Imposta [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) su [FillType::Gradient](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) e configura le fermate di gradiente, la direzione e la trasparenza.