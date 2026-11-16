---
title: Recupera e Aggiorna le Proprietà di Visualizzazione della Presentazione in JavaScript
linktitle: Proprietà di visualizzazione
type: docs
weight: 80
url: /it/nodejs-java/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- visualizzazione normale
- contenuto della struttura
- icone della struttura
- aggancio separatore verticale
- visualizzazione singola
- stato barra
- dimensione
- regolazione automatica
- zoom predefinito
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Usa Aspose.Slides per Node.js tramite Java per configurare la disposizione della visualizzazione normale, lo zoom delle diapositive e delle note, la spaziatura della griglia e la visibilità dei commenti nelle presentazioni PowerPoint."
---
## **Introduzione**

Nella visualizzazione normale di PowerPoint, la diapositiva appare tra un riquadro laterale per le miniature o una struttura e un riquadro delle note sotto. Aspose.Slides per Node.js tramite Java espone le preferenze di modifica salvate della presentazione tramite [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties). Queste includono la disposizione dei riquadri, i livelli di zoom, la spaziatura della griglia e la visibilità dei commenti.

## **Informazioni su NormalViewProperties**

Usa [getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) per accedere alla classe [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) controlla se le icone appaiono accanto ai titoli delle diapositive nella struttura. [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) consente al riquadro laterale di agganciarsi al suo stato ridotto quando l'utente lo restringe. [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) indica una preferenza per la visualizzazione di un unico riquadro nella finestra intera. [setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) controlla il divisore tra il riquadro laterale e la diapositiva. [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) controlla il divisore sopra il riquadro delle note. Entrambi accettano un valore [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) di `Minimized`, `Maximized` o `Restored`.

## **Informazioni sul ripristino di NormalViewProperties**

Quando un divisore viene ripristinato, [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) fornisce la dimensione salvata del riquadro laterale e [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) fornisce la dimensione salvata dell'area superiore della diapositiva. Entrambi espongono [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/). Il suo metodo [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) accetta una percentuale da 0 a 100, e [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) controlla se l'editor regola la dimensione quando la finestra viene ridimensionata.

Questo esempio aggiorna una presentazione esistente. Ripristina il divisore orizzontale, imposta la dimensione restituita da [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) all'80% con aggiustamento automatico abilitato e massimizza il divisore verticale. Chiama anche [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) per mostrare le icone nella visualizzazione struttura.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta il valore di zoom predefinito**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) e [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) memorizzano impostazioni di zoom indipendenti per l'editor. Queste impostazioni non influiscono sulle dimensioni delle diapositive, sulla riproduzione della presentazione o sulla risoluzione di esportazione delle immagini.

Questo esempio apre una presentazione esistente e chiama [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale) per adattare la diapositiva alla finestra di modifica. Per la pagina delle note, disabilita la scalatura automatica e chiama [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) per impostare uno zoom fisso dell'80%.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta la spaziatura della griglia**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) imposta la distanza tra le linee della griglia di modifica in tutta la presentazione. Accetta un valore positivo in punti, con 72 punti per pollice. Questo esempio stampa la spaziatura corrente in una presentazione esistente e salva una griglia di un quarto di pollice impostando l'intervallo a 18 punti.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La griglia si ripete a intervalli fissi. [Drawing guides](/slides/it/nodejs-java/drawing-guides/) segnano posizioni orizzontali o verticali individuali. Entrambi sono strumenti di modifica e appaiono solo negli editor che li mostrano. Le presentazioni e le esportazioni in PDF, immagini o SVG li omettono.

## **Mostra o nascondi i commenti all'apertura di una presentazione**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) memorizza una preferenza che gli editor compatibili usano all'apertura della presentazione. Per una presentazione esistente con commenti, questo esempio stampa l'impostazione corrente e salva una copia con i commenti nascosti. Chiama inoltre [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) con [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView) affinché la copia si apra in visualizzazione diapositiva.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nascondere i commenti ne preserva il testo, gli autori, le posizioni, le risposte e gli stati. Per modificare i commenti stessi, vedere [Presentation Comments](/slides/it/nodejs-java/presentation-comments/). Le impostazioni di esportazione controllano se i commenti appaiono in PDF, HTML, immagini, note o dispense.

## **FAQ**

**Perché la griglia è nascosta quando riapro la presentazione?**

La presentazione memorizza l'intervallo della griglia. Per vedere la griglia, abilita la visibilità della griglia nell'editor.

**La cancellazione delle guide di disegno modifica la spaziatura della griglia?**

No. Aggiungere, spostare o cancellare una guida non modifica l'intervallo della griglia.

**Possono sezioni diverse di una presentazione avere impostazioni di visualizzazione differenti?**

No. [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) si applica all'intera presentazione.

**Posso salvare impostazioni di visualizzazione diverse per utenti diversi?**

Il file memorizza un unico set di proprietà di visualizzazione per tutti. Un editor può anche applicare le preferenze locali di un utente.

**Posso salvare le impostazioni di visualizzazione in un modello?**

Sì. Le presentazioni create dal modello ereditano le impostazioni di visualizzazione salvate.