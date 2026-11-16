---
title: Recuperare e aggiornare le proprietà di visualizzazione della presentazione in Python
linktitle: Proprietà di visualizzazione
type: docs
weight: 80
url: /it/python-net/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- visualizzazione normale
- contenuto della struttura
- icone della struttura
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
- Aspose.Slides
description: "Utilizza Aspose.Slides per Python via .NET per configurare il layout della visualizzazione normale, lo zoom di diapositive e note, la spaziatura della griglia e la visibilità dei commenti nelle presentazioni PowerPoint."
---
## **Introduzione**

In PowerPoint nella visualizzazione normale, la diapositiva appare tra un riquadro laterale per le miniature o una struttura e un riquadro note sotto. Aspose.Slides per Python via .NET espone le preferenze di modifica salvate della presentazione tramite [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/). Queste includono il layout del riquadro, i livelli di zoom, la spaziatura della griglia e la visibilità dei commenti.

## **Informazioni su NormalViewProperties**

Usa [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) per accedere all'oggetto [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/). [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) controlla se le icone appaiono accanto ai titoli delle diapositive nella struttura. [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) consente al riquadro laterale di agganciarsi allo stato minimizzato quando l'utente lo riduce. [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) indica una preferenza per la visualizzazione di un unico riquadro nella finestra completa.

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) controlla il divisore tra il riquadro laterale e la diapositiva. [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) controlla il divisore sopra il riquadro note. Entrambi accettano un valore [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) di `MINIMIZED`, `MAXIMIZED` o `RESTORED`.

<!-- visual-explanation:presentation-view-properties:start -->
[![Un editor concettuale separa un pannello laterale, l'area diapositiva e l'area inferiore con divisori verticali e orizzontali etichettati.](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*Nel visualizzazione normale, il divisore verticale controlla la larghezza del riquadro laterale. Il divisore orizzontale controlla lo spazio sopra il riquadro note.*
<!-- visual-explanation:presentation-view-properties:end -->

## **Informazioni sul ripristino di NormalViewProperties**

Quando un divisore viene ripristinato, [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) fornisce la dimensione salvata del riquadro laterale e [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) fornisce la dimensione salvata dell'area superiore della diapositiva. Entrambi espongono [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/). La sua proprietà [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) accetta una percentuale da 0 a 100, e [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) controlla se l'editor regola la dimensione quando la finestra viene ridimensionata.

Questo esempio aggiorna una presentazione esistente. Ripristina il divisore orizzontale, imposta [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) all'80% con regolazione automatica abilitata e massimizza il divisore verticale. Abilita inoltre [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) per la visualizzazione della struttura.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta il valore di zoom predefinito**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) e [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) memorizzano impostazioni di zoom indipendenti per l'editor. Queste impostazioni non influenzano le dimensioni delle diapositive, la riproduzione della presentazione o la risoluzione di esportazione delle immagini.

Questo esempio apre una presentazione esistente e abilita [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) per adattare la diapositiva alla finestra di modifica. Per la pagina note, disabilita la scala automatica e imposta [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) a un zoom fisso dell'80%.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta la spaziatura della griglia**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) imposta la distanza tra le linee della griglia di modifica in tutta la presentazione. Accetta un valore positivo in punti, con 72 punti per pollice. Questo esempio stampa la spaziatura corrente in una presentazione esistente e salva una griglia di un quarto di pollice impostando l'intervallo a 18 punti.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

La griglia si ripete a intervalli fissi. [Guide di disegno](/slides/it/python-net/drawing-guides/) contrassegna posizioni orizzontali o verticali individuali. Entrambi sono strumenti di modifica e appaiono solo negli editor che li visualizzano. Le presentazioni e le esportazioni in PDF, immagini o SVG li omettono.

## **Mostra o nascondi i commenti all'apertura di una presentazione**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) memorizza una preferenza che gli editor compatibili usano quando aprono la presentazione. Per una presentazione esistente con commenti, questo esempio stampa l'impostazione corrente e salva una copia con i commenti nascosti. Imposta anche [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) su [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) in modo che la copia si apra nella visualizzazione diapositiva.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Nascondere i commenti ne preserva il testo, gli autori, le posizioni, le risposte e gli stati. Per modificare i commenti stessi, vedere [Commenti della presentazione](/slides/it/python-net/presentation-comments/). Le impostazioni di esportazione controllano se i commenti appaiono in PDF, HTML, immagini, note o dispense.

## **FAQ**

**Perché la griglia è nascosta quando riapro la presentazione?**

La presentazione memorizza l'intervallo della griglia. Per vedere la griglia, abilita la visibilità della griglia nell'editor.

**La cancellazione delle guide di disegno cambia la spaziatura della griglia?**

No. Aggiungere, spostare o cancellare una guida lascia l'intervallo della griglia invariato.

**Sezioni diverse di una presentazione possono avere impostazioni di visualizzazione diverse?**

No. [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) si applica all'intera presentazione.

**Posso salvare impostazioni di visualizzazione diverse per utenti diversi?**

Il file memorizza un unico set di proprietà di visualizzazione per tutti. Un editor può anche applicare le preferenze locali dell'utente.

**Posso salvare impostazioni di visualizzazione in un modello?**

Sì. Le presentazioni create dal modello ereditano le impostazioni di visualizzazione salvate.