---
title: "Personalizza le aree del tracciato dei grafici di presentazione in C++"
linktitle: "Area del tracciato"
type: docs
url: /it/cpp/chart-plot-area/
keywords:
- "grafico"
- "area del tracciato"
- "larghezza area del tracciato"
- "altezza area del tracciato"
- "dimensione area del tracciato"
- "modalità di layout"
- "PowerPoint"
- "presentazione"
- "C++"
- "Aspose.Slides"
description: "Scopri come personalizzare le aree dei tracciati dei grafici nelle presentazioni PowerPoint con Aspose.Slides per C++. Migliora facilmente l'aspetto delle tue diapositive."
---
## **Panoramica**

Questo articolo mostra come lavorare con l'area del tracciato di un grafico in Aspose.Slides. Spiega come ottenere la posizione e le dimensioni effettive dell'area del tracciato validando il layout del grafico e poi leggendo i valori X, Y, larghezza e altezza.

Mostra inoltre come configurare la modalità di layout dell'area del tracciato quando il layout è impostato manualmente, utilizzando `LayoutTargetType` per definire se l'area del tracciato è calcolata dalla sua regione interna o dalla regione esterna insieme a assi e etichette degli assi.

## **Ottenere larghezza e altezza di un'area del tracciato del grafico**
Aspose.Slides per C++ fornisce un'API semplice per .

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
1. Accedi alla prima diapositiva.
1. Aggiungi un grafico con dati predefiniti.
1. Chiama il metodo IChart::ValidateChartLayout() prima di ottenere i valori effettivi.
1. Ottiene la posizione X effettiva (sinistra) dell'elemento del grafico rispetto all'angolo superiore sinistro del grafico.
1. Ottiene la parte superiore effettiva dell'elemento del grafico rispetto all'angolo superiore sinistro del grafico.
1. Ottiene la larghezza effettiva dell'elemento del grafico.
1. Ottiene l'altezza effettiva dell'elemento del grafico.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Salva la presentazione con il grafico
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```

## **Impostare la modalità di layout di un'area del tracciato del grafico**
Aspose.Slides per C++ fornisce un'API semplice per impostare la modalità di layout dell'area del tracciato del grafico. La proprietà **LayoutTargetType** è stata aggiunta alle classi **ChartPlotArea** e **IChartPlotArea**. Se il layout dell'area del tracciato è definito manualmente, questa proprietà specifica se il layout dell'area del tracciato deve avvenire per l'interno (escludendo assi ed etichette degli assi) o per l'esterno (includendo assi ed etichette degli assi). Sono possibili due valori, definiti nell'enumerazione **LayoutTargetType**.

- **LayoutTargetType.Inner** - specifica che la dimensione dell'area del tracciato determina la dimensione dell'area del tracciato, escludendo le tacche e le etichette degli assi.
- **LayoutTargetType.Outer** - specifica che la dimensione dell'area del tracciato determina la dimensione dell'area del tracciato, le tacche e le etichette degli assi.

Il codice di esempio è fornito di seguito.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **FAQ**

**In quali unità sono restituiti ActualX, ActualY, ActualWidth e ActualHeight?**

In punti; 1 pollice = 72 punti. Queste sono unità di coordinate di Aspose.Slides.

**Come differisce l'area del tracciato dall'area del grafico in termini di contenuto?**

L'area del tracciato è la regione di disegno dei dati (serie, linee della griglia, linee di tendenza, ecc.); l'area del grafico comprende gli elementi circostanti (titolo, legenda, ecc.). Nei grafici 3D, l'area del tracciato include anche le pareti/pavimento e gli assi.

**Come vengono interpretati X, Y, Larghezza e Altezza dell'area del tracciato quando il layout è manuale?**

Sono frazioni (0‑1) della dimensione complessiva del grafico; in questa modalità il posizionamento automatico è disabilitato e vengono utilizzate le frazioni impostate.

**Perché la posizione dell'area del tracciato è cambiata dopo aver aggiunto/spostato la legenda?**

La legenda si trova nell'area del grafico al di fuori dell'area del tracciato ma influisce sul layout e sullo spazio disponibile, quindi l'area del tracciato può spostarsi quando è attivo il posizionamento automatico. (Questo è un comportamento standard per i grafici di PowerPoint.)