---
title: Recuperare e aggiornare le proprietà di visualizzazione della presentazione in .NET
linktitle: Proprietà di visualizzazione
type: docs
weight: 80
url: /it/net/presentation-view-properties/
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
- .NET
- C#
- Aspose.Slides
description: "Utilizza Aspose.Slides per .NET per configurare il layout della visualizzazione normale, lo zoom delle diapositive e delle note, la spaziatura della griglia e la visibilità dei commenti nelle presentazioni PowerPoint."
---
## **Introduzione**

Nella visualizzazione normale di PowerPoint, la diapositiva appare tra un riquadro laterale per le miniature o per la struttura e un riquadro delle note in basso. Aspose.Slides per .NET espone le preferenze di modifica salvate della presentazione tramite [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/). Queste includono la disposizione dei riquadri, i livelli di zoom, la spaziatura della griglia e la visibilità dei commenti.

## **Informazioni su INormalViewProperties**

Utilizza [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) per accedere all'interfaccia [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/). [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) controlla se le icone appaiono accanto ai titoli delle diapositive nella struttura. [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) consente al riquadro laterale di agganciarsi allo stato ridotto quando l'utente lo restringe. [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) indica una preferenza per la visualizzazione di un unico riquadro nella finestra intera.

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) controlla il divisore tra il riquadro laterale e la diapositiva. [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) controlla il divisore sopra il riquadro delle note. Entrambi accettano un valore [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) di `Minimized`, `Maximized` o `Restored`.

## **Informazioni sul ripristino di INormalViewProperties**

Quando un divisore viene ripristinato, [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) fornisce la dimensione salvata del riquadro laterale e [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) fornisce la dimensione salvata dell'area superiore della diapositiva. Entrambi espongono [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/). La sua proprietà [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) accetta una percentuale da 0 a 100, e [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) controlla se l'editor regola la dimensione quando la finestra viene ridimensionata.

Questo esempio aggiorna una presentazione esistente. Ripristina il divisore orizzontale, imposta [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) all'80% con la regolazione automatica abilitata, e massimizza il divisore verticale. Attiva anche [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) per la visualizzazione della struttura.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **Imposta il valore di zoom predefinito**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) e [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) memorizzano impostazioni di zoom indipendenti per l'editor. Queste impostazioni non influiscono sulle dimensioni delle diapositive, sulla riproduzione della presentazione o sulla risoluzione di esportazione delle immagini.

Questo esempio apre una presentazione esistente e abilita [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) per adattare la diapositiva alla finestra di modifica. Per la pagina delle note, disabilita la scalatura automatica e imposta [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) a uno zoom fisso dell'80%.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **Imposta la spaziatura della griglia**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) imposta la distanza tra le linee della griglia di modifica in tutta la presentazione. Accetta un valore positivo in punti, con 72 punti per pollice. Questo esempio stampa la spaziatura corrente in una presentazione esistente e salva una griglia di un quarter-inches impostando l'intervallo a 18 punti.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

La griglia si ripete a intervalli fissi. [Drawing guides](/slides/it/net/drawing-guides/) segnano posizioni orizzontali o verticali individuali. Entrambi sono strumenti di modifica e appaiono solo negli editor che li mostrano. Le presentazioni e le esportazioni in PDF, immagini o SVG li omettono.

## **Mostra o Nascondi i commenti all'apertura di una presentazione**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) memorizza una preferenza che gli editor compatibili usano all'apertura della presentazione. Per una presentazione esistente con commenti, questo esempio stampa l'impostazione attuale e salva una copia con i commenti nascosti. Imposta anche [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) su [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) in modo che la copia si apra nella visualizzazione diapositiva.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Nascondere i commenti ne preserva il testo, gli autori, le posizioni, le risposte e gli stati. Per modificare i commenti stessi, consulta [Presentation Comments](/slides/it/net/presentation-comments/). Le impostazioni di esportazione controllano se i commenti appaiono in PDF, HTML, immagini, note o dispense.

## **FAQ**

**Perché la griglia è nascosta quando riapro la presentazione?**

La presentazione memorizza l'intervallo della griglia. Per vedere la griglia, abilita la visibilità della griglia nell'editor.

**La cancellazione delle guide di disegno cambia la spaziatura della griglia?**

No. Aggiungere, spostare o cancellare una guida lascia l'intervallo della griglia invariato.

**Le diverse sezioni di una presentazione possono avere impostazioni di visualizzazione differenti?**

No. [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) si applica all'intera presentazione.

**Posso salvare impostazioni di visualizzazione diverse per utenti diversi?**

Il file memorizza un unico set di proprietà di visualizzazione per tutti. Un editor può anche applicare le preferenze locali dell'utente.

**Posso salvare le impostazioni di visualizzazione in un modello?**

Sì. Le presentazioni create dal modello ereditano le sue impostazioni di visualizzazione salvate.