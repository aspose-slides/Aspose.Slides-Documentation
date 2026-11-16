---
title: Recupera e aggiorna le proprietà di visualizzazione della presentazione su Android
linktitle: Proprietà visualizzazione
type: docs
weight: 80
url: /it/androidjava/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- visualizzazione normale
- contenuto del contorno
- icone del contorno
- aggancio del divisore verticale
- visualizzazione singola
- stato della barra
- dimensione
- regolazione automatica
- zoom predefinito
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Utilizza Aspose.Slides per Android tramite Java per configurare il layout della visualizzazione normale, lo zoom delle diapositive e delle note, la spaziatura della griglia e la visibilità dei commenti nelle presentazioni PowerPoint."
---
## **Introduzione**

Nella visualizzazione normale di PowerPoint, la diapositiva appare tra un riquadro laterale per miniature o un contorno e un riquadro note nella parte inferiore. Aspose.Slides per Android via Java espone le preferenze di modifica salvate della presentazione tramite [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--). Queste includono la disposizione dei riquadri, i livelli di zoom, la spaziatura della griglia e la visibilità dei commenti.

## **Informazioni su INormalViewProperties**

Usa [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) per accedere all'interfaccia [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) controlla se le icone appaiono accanto ai titoli delle diapositive nella visualizzazione contorno. [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) consente al riquadro laterale di agganciarsi al suo stato ridotto quando l'utente lo restringe. [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) indica una preferenza per la visualizzazione di un unico riquadro nella finestra intera.

[setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) controlla il divisore tra il riquadro laterale e la diapositiva. [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) controlla il divisore sopra il riquadro note. Entrambi accettano un valore [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) di `Minimized`, `Maximized` o `Restored`.

## **Informazioni sul ripristino di INormalViewProperties**

Quando un divisore viene ripristinato, [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) fornisce la dimensione salvata del riquadro laterale e [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) fornisce la dimensione salvata dell'area superiore della diapositiva. Entrambi espongono [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/). Il suo metodo [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) accetta una percentuale da 0 a 100, e [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) controlla se l'editor regola la dimensione quando la finestra viene ridimensionata.

Questo esempio aggiorna una presentazione esistente. Ripristina il divisore orizzontale, imposta la dimensione restituita da [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) all'80% con l'adattamento automatico abilitato, e massimizza il divisore verticale. Chiama anche [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) per visualizzare le icone nella vista contorno.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta il valore di zoom predefinito**

[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) e [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) memorizzano impostazioni di zoom indipendenti per l'editor. Queste impostazioni non influenzano le dimensioni delle diapositive, la riproduzione della presentazione o la risoluzione di esportazione delle immagini.

Questo esempio apre una presentazione esistente e chiama [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) per adattare la diapositiva alla finestra di modifica. Per la pagina delle note, disabilita la scala automatica e chiama [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) per impostare uno zoom fisso dell'80%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta la spaziatura della griglia**

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) imposta la distanza tra le linee della griglia di modifica in tutta la presentazione. Accetta un valore positivo in punti, con 72 punti per pollice. Questo esempio stampa la spaziatura corrente in una presentazione esistente e salva una griglia di un quarto di pollice impostando l'intervallo a 18 punti.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La griglia si ripete a intervalli fissi. [Drawing guides](/slides/it/androidjava/drawing-guides/) segnano posizioni orizzontali o verticali individuali. Entrambi sono ausili per la modifica e appaiono solo negli editor che li mostrano. Le presentazioni e le esportazioni in PDF, immagini o SVG li omettono.

## **Mostra o nascondi i commenti all'apertura di una presentazione**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) memorizza una preferenza che gli editor compatibili usano all'apertura della presentazione. Per una presentazione esistente con commenti, questo esempio stampa l'impostazione corrente e salva una copia con i commenti nascosti. Chiama anche [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) con [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView) in modo che la copia si apra in visualizzazione diapositiva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nascondere i commenti ne conserva il testo, gli autori, le posizioni, le risposte e gli stati. Per modificare i commenti stessi, vedere [Presentation Comments](/slides/it/androidjava/presentation-comments/). Le impostazioni di esportazione controllano se i commenti compaiono in PDF, HTML, immagini, note o dispense.

## **FAQ**

**Perché la griglia è nascosta quando riapro la presentazione?**

La presentazione memorizza l'intervallo della griglia. Per visualizzare la griglia, attiva la visibilità della griglia nell'editor.

**La cancellazione delle guide di disegno modifica la spaziatura della griglia?**

No. Aggiungere, spostare o cancellare una guida lascia l'intervallo della griglia invariato.

**Sezioni diverse di una presentazione possono avere impostazioni di visualizzazione diverse?**

No. [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) si applica all'intera presentazione.

**Posso salvare impostazioni di visualizzazione diverse per utenti diversi?**

Il file memorizza un unico set di proprietà di visualizzazione per tutti. Un editor può anche applicare le preferenze locali dell'utente.

**Posso salvare le impostazioni di visualizzazione in un modello?**

Sì. Le presentazioni create dal modello ereditano le sue impostazioni di visualizzazione salvate.