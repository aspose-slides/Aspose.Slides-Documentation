---
title: Recupera e aggiorna le proprietà di visualizzazione della presentazione in PHP
linktitle: Proprietà di visualizzazione
type: docs
weight: 80
url: /it/php-java/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- visualizzazione normale
- contenuto della struttura
- icone della struttura
- aggancia divisore verticale
- visualizzazione singola
- stato barra
- dimensione
- regolazione automatica
- zoom predefinito
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Utilizza Aspose.Slides per PHP tramite Java per configurare il layout della visualizzazione normale, lo zoom delle diapositive e delle note, la spaziatura della griglia e la visibilità dei commenti nelle presentazioni PowerPoint."
---
## **Introduzione**

Nella visualizzazione normale di PowerPoint, la diapositiva appare tra un riquadro laterale per le miniature o per la struttura e un riquadro note nella parte inferiore. Aspose.Slides per PHP tramite Java espone le preferenze di modifica salvate della presentazione tramite [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/). Queste includono la disposizione dei riquadri, i livelli di zoom, la spaziatura della griglia e la visibilità dei commenti.

## **Informazioni su NormalViewProperties**

Usa [getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) per accedere alla classe [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) controlla se le icone appaiono accanto ai titoli delle diapositive nella struttura. [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) consente al riquadro laterale di ridursi allo stato minimizzato quando l'utente lo restringe. [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) indica una preferenza per mostrare un unico riquadro nella finestra completa.

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) controlla il divisore tra il riquadro laterale e la diapositiva. [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) controlla il divisore sopra il riquadro note. Entrambi accettano un valore di [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` o `Restored`.

## **Informazioni sul ripristino di NormalViewProperties**

Quando un divisore viene ripristinato, [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) fornisce la dimensione salvata del riquadro laterale e [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) fornisce la dimensione salvata dell'area superiore della diapositiva. Entrambi espongono [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/). Il suo metodo [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) accetta una percentuale da 0 a 100, e [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) controlla se l'editor adegua la dimensione quando la finestra viene ridimensionata.

Questo esempio aggiorna una presentazione esistente. Ripristina il divisore orizzontale, imposta la dimensione restituita da [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) all'80% con l'ajustamento automatico abilitato, e massimizza il divisore verticale. Chiama anche [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) per visualizzare le icone nella visualizzazione struttura.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Imposta il valore di zoom predefinito**

[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) e [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) memorizzano impostazioni di zoom indipendenti per l'editor. Queste impostazioni non influenzano le dimensioni della diapositiva, la riproduzione della presentazione o la risoluzione dell'esportazione delle immagini.

Questo esempio apre una presentazione esistente e chiama [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/) per adattare la diapositiva alla finestra di modifica. Per la pagina delle note, disattiva il ridimensionamento automatico e chiama [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/) per impostare uno zoom fisso dell'80%.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Imposta la spaziatura della griglia**

Il metodo `setGridSpacing` di [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) imposta la distanza tra le linee della griglia di modifica in tutta la presentazione. Accetta un valore positivo in punti, con 72 punti per pollice. Questo esempio stampa la spaziatura corrente in una presentazione esistente e salva una griglia di un quarto di pollice impostando l'intervallo a 18 punti.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La griglia si ripete a intervalli fissi. [Guide di disegno](/slides/it/php-java/drawing-guides/) segnano posizioni orizzontali o verticali individuali. Entrambi sono strumenti di modifica e compaiono solo negli editor che li visualizzano. Le presentazioni e le esportazioni in PDF, immagini o SVG li omettono.

## **Mostra o nascondi i commenti all'apertura di una presentazione**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) memorizza una preferenza che gli editor compatibili utilizzano all'apertura della presentazione. Per una presentazione esistente con commenti, questo esempio stampa l'impostazione corrente e salva una copia con i commenti nascosti. Chiama anche [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) con [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView) in modo che la copia si apra nella visualizzazione diapositiva.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Nascondere i commenti ne preserva il testo, gli autori, le posizioni, le risposte e gli stati. Per modificare i commenti stessi, consulta [Commenti della presentazione](/slides/it/php-java/presentation-comments/). Le impostazioni di esportazione controllano se i commenti compaiono in PDF, HTML, immagini, note o dispense.

## **FAQ**

**Perché la griglia è nascosta quando riapro la presentazione?**

La presentazione memorizza l'intervallo della griglia. Per vedere la griglia, abilita la visibilità della griglia nell'editor.

**La cancellazione delle guide di disegno modifica la spaziatura della griglia?**

No. Aggiungere, spostare o cancellare una guida non modifica l'intervallo della griglia.

**Sezioni diverse di una presentazione possono avere impostazioni di visualizzazione diverse?**

No. [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) si applica all'intera presentazione.

**Posso salvare impostazioni di visualizzazione diverse per utenti diversi?**

Il file memorizza un unico set di proprietà di visualizzazione per tutti. Un editor può anche applicare le preferenze locali dell'utente.

**Posso salvare le impostazioni di visualizzazione in un modello?**

Sì. Le presentazioni create dal modello ereditano le sue impostazioni di visualizzazione salvate.