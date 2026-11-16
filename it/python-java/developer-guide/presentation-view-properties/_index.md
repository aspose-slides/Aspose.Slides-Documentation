---
title: Recupera e aggiorna le proprietà di visualizzazione della presentazione in Python via Java
linktitle: Proprietà di visualizzazione
type: docs
weight: 80
url: /it/python-java/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- visualizzazione normale
- contenuto della scaletta
- icone della scaletta
- aggancio del divisore verticale
- visualizzazione singola
- stato della barra
- dimensione
- regolazione automatica
- zoom predefinito
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Utilizza Aspose.Slides per Python via Java per configurare il layout della visualizzazione normale, lo zoom di diapositive e note, la spaziatura della griglia e la visibilità dei commenti nelle presentazioni PowerPoint."
---
## **Introduzione**

Nella visualizzazione normale di PowerPoint, la diapositiva appare tra un riquadro laterale per le miniature o la scaletta e un riquadro note sotto. Aspose.Slides per Python via Java espone le preferenze di modifica salvate della presentazione tramite [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties). Queste includono la disposizione dei riquadri, i livelli di zoom, la spaziatura della griglia e la visibilità dei commenti.

## **Informazioni su NormalViewProperties**

Usa [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) per accedere alla classe [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) controlla se le icone appaiono accanto ai titoli delle diapositive nella scaletta. [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) consente al riquadro laterale di agganciarsi allo stato ridotto quando l'utente lo restringe. [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) indica una preferenza per visualizzare un solo riquadro nella finestra intera.

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) controlla il divisore tra il riquadro laterale e la diapositiva. [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) controlla il divisore sopra il riquadro note. Entrambi accettano un valore [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) di `Minimized`, `Maximized` o `Restored`.

## **Informazioni sul ripristino di NormalViewProperties**

Quando un divisore viene ripristinato, [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) fornisce la dimensione salvata del riquadro laterale e [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) fornisce la dimensione salvata dell'area superiore della diapositiva. Entrambi restituiscono un'istanza di [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/). Il suo metodo [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) accetta una percentuale da 0 a 100, e [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) controlla se l'editor adegua la dimensione quando la finestra viene ridimensionata.

Questo esempio aggiorna una presentazione esistente. Ripristina il divisore orizzontale, imposta la dimensione restituita da [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) all'80% con l'adattamento automatico abilitato, e massimizza il divisore verticale. Chiama anche [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) per visualizzare le icone nella vista scaletta.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta il valore di zoom predefinito**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) e [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) memorizzano impostazioni di zoom indipendenti per l'editor. Queste impostazioni non influenzano le dimensioni delle diapositive, la riproduzione della presentazione o la risoluzione di esportazione delle immagini.

Questo esempio apre una presentazione esistente e chiama [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) per adattare la diapositiva alla finestra di modifica. Per la pagina delle note, disabilita la scalatura automatica e chiama [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) per impostare uno zoom fisso dell'80%.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta la spaziatura della griglia**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) imposta la distanza tra le linee della griglia di modifica in tutta la presentazione. Accetta un valore positivo in punti, con 72 punti per pollice. Questo esempio stampa la spaziatura corrente in una presentazione esistente e salva una griglia di un quarto di pollice impostando l'intervallo a 18 punti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La griglia si ripete a intervalli fissi. [Guide di disegno](/slides/it/python-java/drawing-guides/) segnano posizioni orizzontali o verticali individuali. Entrambi sono ausili di modifica e appaiono solo negli editor che li visualizzano. Le presentazioni e le esportazioni in PDF, immagini o SVG li omettono.

## **Mostra o nascondi i commenti all'apertura di una presentazione**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) memorizza una preferenza che gli editor compatibili usano all'apertura della presentazione. Per una presentazione esistente con commenti, questo esempio stampa l'impostazione corrente e salva una copia con i commenti nascosti. Chiama anche [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) con [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) in modo che la copia si apra nella vista diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nascondere i commenti ne conserva il testo, gli autori, le posizioni, le risposte e gli stati. Per modificare i commenti stessi, consulta [Commenti della presentazione](/slides/it/python-java/presentation-comments/). Le impostazioni di esportazione controllano se i commenti appaiono in PDF, HTML, immagini, note o dispense.

## **FAQ**

**Perché la griglia è nascosta quando riapro la presentazione?**  
La presentazione salva l'intervallo della griglia. Per vedere la griglia, abilita la visibilità della griglia nell'editor.

**La cancellazione delle guide di disegno modifica la spaziatura della griglia?**  
No. Aggiungere, spostare o cancellare una guida lascia l'intervallo della griglia invariato.

**Le diverse sezioni di una presentazione possono avere impostazioni di visualizzazione diverse?**  
No. [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) si applica all'intera presentazione.

**Posso salvare impostazioni di visualizzazione diverse per utenti diversi?**  
Il file memorizza un unico set di proprietà di visualizzazione per tutti. Un editor può anche applicare le preferenze locali di un utente.

**Posso salvare le impostazioni di visualizzazione in un modello?**  
Sì. Le presentazioni create dal modello ereditano le impostazioni di visualizzazione salvate.