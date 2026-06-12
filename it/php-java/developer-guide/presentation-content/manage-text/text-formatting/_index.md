---
title: Formattare il testo della presentazione in PHP
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/php-java/text-formatting/
keywords:
- evidenziare il testo
- espressione regolare
- allineare il paragrafo
- stile del testo
- sfondo del testo
- trasparenza del testo
- spaziatura dei caratteri
- proprietà del font
- famiglia di font
- rotazione del testo
- angolo di rotazione
- frame di testo
- interlinea
- proprietà di adattamento automatico
- ancora del frame di testo
- tabulazione del testo
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Formatta e stila il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per PHP via Java. Personalizza i font, i colori, l'allineamento e altro ancora."
---
## **Panoramica**

Questo articolo mostra come formattare il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per PHP via Java. Copre evidenziazione, colori di sfondo, trasparenza, spaziatura dei caratteri, proprietà dei font, rotazione, spaziatura dei paragrafi, comportamento di autofit, ancoraggio del testo, tabulazioni e impostazioni della lingua.

Negli esempi seguenti, utilizzeremo un file denominato "sample.pptx", che contiene una singola casella di testo nella prima diapositiva con il seguente contenuto:

![Testo di esempio](sample_text.png)

## **Evidenziare il testo**

Usa il metodo [TextFrame]::highlightText quando è necessario evidenziare il testo che corrisponde a un campione specifico all'interno di un frame di testo. Il metodo applica un colore di evidenziazione ai frammenti di testo corrispondenti e può essere usato con [TextHighlightingOptions] per controllare come viene eseguita la ricerca, ad esempio per corrispondere solo a parole intere.

Il codice di esempio qui sotto evidenzia tutte le occorrenze dei caratteri **"try"** e poi evidenzia solo la parola intera **"to"**.

```php
$presentation = new Presentation("sample.pptx");
try {
    // Ottieni la prima forma dalla prima diapositiva.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lightBlue = new Java("java.awt.Color", 173, 216, 230);
    $violet = new Java("java.awt.Color", 238, 130, 238);

    // Evidenzia la parola "try" nella forma.
    $shape->getTextFrame()->highlightText("try", $lightBlue);

    $searchOptions = new TextHighlightingOptions();
    $searchOptions->setWholeWordsOnly(true);

    // Evidenzia la parola "to" nella forma.
    $shape->getTextFrame()->highlightText("to", $violet, $searchOptions);

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Il testo evidenziato](highlighted_text.png)

## **Evidenziare il testo usando espressioni regolari**

Il metodo [TextFrame]::highlightRegex evidenzia le corrispondenze di testo trovate da un'espressione regolare.

Il codice di esempio qui sotto evidenzia tutte le parole che contengono **sette o più caratteri**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Evidenzia tutte le parole con sette o più caratteri.
    $shape->getTextFrame()->highlightRegex("\\b[^\\s]{7,}\\b", java("java.awt.Color")->YELLOW, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Il testo evidenziato usando l'espressione regolare](highlighted_text_using_regex.png)

## **Impostare il colore di sfondo del testo**

Usa il formato predefinito della porzione di [ParagraphFormat] per impostare il colore di evidenziazione predefinito per un paragrafo, o usa [PortionFormat] per porzioni di testo individuali.

Il seguente esempio di codice mostra come impostare il colore di sfondo per l'**intero paragrafo**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Imposta il colore di evidenziazione per l'intero paragrafo.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Il paragrafo grigio](gray_paragraph.png)

Il codice di esempio qui sotto dimostra come impostare il colore di sfondo per **porzioni di testo con carattere grassetto**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Imposta il colore di evidenziazione per la porzione di testo.
            $portion->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Le parti di testo grigie](gray_text_portions.png)

## **Allineare i paragrafi di testo**

Usa il metodo [ParagraphFormat]::setAlignment per impostare l'allineamento del paragrafo all'interno di un frame di testo. Il valore può essere centrato, allineato a sinistra, a destra, giustificato, ecc.

Il seguente esempio di codice mostra come allineare il paragrafo al **centro**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
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

## **Impostare la trasparenza del testo**

La trasparenza del testo è controllata tramite il componente alfa del colore assegnato al formato di riempimento di [PortionFormat]. Negli esempi seguenti, `alpha = 50` è un valore alfa ARGB nella scala 0‑255, non una percentuale di trasparenza.

Il codice di esempio qui sotto mostra come applicare la trasparenza all'**intero paragrafo**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Imposta il colore di riempimento del testo a un colore trasparente.
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Il paragrafo trasparente](transparent_paragraph.png)

Il seguente esempio di codice mostra come applicare la trasparenza a **porzioni di testo con carattere grassetto**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Imposta la trasparenza della porzione di testo.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Le parti di testo trasparenti](transparent_text_portions.png)

## **Impostare la spaziatura dei caratteri per il testo**

Usa il metodo [BasePortionFormat]::setSpacing per espandere o comprimere la spaziatura tra i caratteri in una casella di testo.

Il seguente codice PHP mostra come espandere la spaziatura dei caratteri nell'**intero paragrafo**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Nota: Usa valori negativi per comprimere la spaziatura dei caratteri.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Espandi la spaziatura dei caratteri.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![La spaziatura dei caratteri nel paragrafo](character_spacing_in_paragraph.png)

Il codice di esempio qui sotto mostra come espandere la spaziatura dei caratteri in **porzioni di testo con carattere grassetto**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Nota: Usa valori negativi per comprimere la spaziatura dei caratteri.
            $portion->getPortionFormat()->setSpacing(3); // Espandi la spaziatura dei caratteri.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![La spaziatura dei caratteri nelle parti di testo](character_spacing_in_text_portions.png)

### **Disabilitare il kerning per caratteri specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più stretto rispetto allo stesso testo visualizzato in PowerPoint. Ciò può accadere perché PowerPoint potrebbe ignorare i dati di kerning per determinati font, anche quando il font contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per avvicinare il risultato renderizzato a quello di PowerPoint in tali casi, è possibile disabilitare il kerning per le porzioni di testo che utilizzano il font interessato. Imposta il metodo [BasePortionFormat]::setKerningMinimalSize a un valore significativamente più grande della dimensione reale del font:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portionFormat->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Questa impostazione impedisce l'applicazione del kerning alle porzioni di testo corrispondenti e può aiutare ad allineare il rendering di Aspose.Slides a quello visivo di PowerPoint per i font interessati da questo comportamento specifico di PowerPoint.

## **Gestire le proprietà del carattere del testo**

Le proprietà del carattere possono essere impostate a livello di paragrafo tramite il formato di porzione predefinito di [ParagraphFormat] o su singole porzioni tramite [PortionFormat].

Il seguente codice imposta il font e lo stile del testo per l'intero paragrafo: applica dimensione del font, grassetto, corsivo, sottolineatura a punti e il font Times New Roman a tutte le porzioni del paragrafo.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();

    // Imposta le proprietà del font per il paragrafo.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont(new FontData("Times New Roman"));

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Le proprietà del carattere per il paragrafo](font_properties_for_paragraph.png)

Il codice di esempio qui sotto applica proprietà simili a **porzioni di testo con carattere grassetto**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Imposta le proprietà del font per la porzione di testo.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont(new FontData("Times New Roman"));
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Le proprietà del carattere per le parti di testo](font_properties_for_text_portions.png)

## **Impostare la rotazione del testo**

Usa il metodo [TextFrameFormat]::setTextVerticalType per impostare un orientamento di testo predefinito all'interno di una forma.

Il seguente esempio di codice imposta l'orientamento del testo nella forma su `Vertical270`, che ruota il testo **di 90 gradi in senso antiorario**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![La rotazione del testo](text_rotation.png)

## **Impostare la rotazione personalizzata per i fotogrammi di testo**

Usa il metodo [TextFrameFormat]::setRotationAngle per impostare un angolo di rotazione personalizzato per un [TextFrame].

Il codice di esempio qui sotto ruota il frame di testo di 3 gradi in senso orario all'interno della forma:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![La rotazione personalizzata del testo](custom_text_rotation.png)

## **Impostare l'interlinea dei paragrafi**

Aspose.Slides fornisce i metodi [ParagraphFormat]::setSpaceAfter, ParagraphFormat::setSpaceBefore e ParagraphFormat::setSpaceWithin per controllare la spaziatura dei paragrafi. Questi metodi vengono usati come segue:

* Usa un valore positivo per specificare l'interlinea come percentuale dell'altezza della riga.
* Usa un valore negativo per specificare l'interlinea in punti.

Il seguente esempio di codice mostra come specificare l'interlinea all'interno del paragrafo:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![L'interlinea nel paragrafo](line_spacing.png)

## **Impostare il tipo di adattamento automatico per i fotogrammi di testo**

Il metodo [TextFrameFormat]::setAutofitType determina come il testo si comporta quando supera i confini del suo contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Impostare l'ancora dei fotogrammi di testo**

Il metodo [TextFrameFormat]::setAnchoringType definisce come il testo viene posizionato verticalmente all'interno di una forma, ad esempio in alto, al centro o in basso.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Impostare la tabulazione del testo**

Usa il metodo [ParagraphFormat]::setDefaultTabSize e la sua collezione di tabulazioni per configurare le tabulazioni in un paragrafo.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
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

## **Impostare la lingua di verifica**

Aspose.Slides fornisce il metodo [BasePortionFormat]::setLanguageId, che consente di impostare la lingua di verifica per una porzione di testo. La lingua di verifica determina la lingua usata per il controllo ortografico e grammaticale in PowerPoint.

Il seguente esempio di codice mostra come impostare la lingua di verifica per una porzione di testo:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // Imposta l'ID di una lingua di correzione.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1.");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Impostare la lingua predefinita**

Usa il metodo [LoadOptions]::setDefaultTextLanguage per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungi una nuova forma rettangolare con testo.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Controlla la lingua della prima porzione.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Impostare lo stile di testo predefinito**

Per applicare la formattazione di testo predefinita a livello di presentazione, usa lo stile di testo predefinito di [Presentation].

Il seguente esempio di codice mostra come impostare un font grassetto di dimensione 14 pt per tutto il testo nelle diapositive di una nuova presentazione.

```php
$presentation = new Presentation();
try {
    // Recupera il formato del paragrafo di livello superiore.
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

## **Estrarre il testo con l'effetto tutto maiuscolo**

In PowerPoint, l'applicazione dell'effetto **All Caps** fa sì che il testo appaia in maiuscolo sulla diapositiva anche se originariamente è stato digitato in minuscolo. Quando si recupera una tale porzione di testo con Aspose.Slides, la libreria restituisce il testo esattamente com'è stato inserito. Per far corrispondere il testo visualizzato, controlla [TextCapType] e converti la stringa restituita in maiuscolo quando il valore è `All`.

Supponiamo di avere la seguente casella di testo sulla prima diapositiva del file sample2.pptx.

![L'effetto tutto maiuscolo](all_caps_effect.png)

Il codice di esempio qui sotto mostra come estrarre il testo con l'effetto **All Caps** applicato:

```php
$presentation = new Presentation("sample2.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($textPortion->getText());
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

**Come modificare il testo in una tabella su una diapositiva?**

Per modificare il testo in una tabella su una diapositiva, usa [Table]. Itera le celle e aggiorna ogni cella tramite il frame di testo di [Cell] e la formattazione del paragrafo tramite il formato di paragrafo di [Paragraph].

**Come applicare un colore sfumato al testo in una diapositiva PowerPoint?**

Per applicare un colore sfumato al testo, usa il formato di riempimento di [PortionFormat]. Imposta il tipo di riempimento di [FillFormat] su [FillType] `Gradient` e configura le fermate del gradiente, la direzione e la trasparenza.