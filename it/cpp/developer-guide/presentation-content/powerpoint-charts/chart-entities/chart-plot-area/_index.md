---
title: Personalizza le aree del tracciato dei grafici nelle presentazioni C++
linktitle: Area del tracciato
type: docs
url: /it/cpp/chart-plot-area/
keywords:
- grafico
- area del tracciato
- larghezza area del tracciato
- altezza area del tracciato
- dimensione area del tracciato
- modalità di layout
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come personalizzare le aree del tracciato dei grafici nelle presentazioni PowerPoint con Aspose.Slides per C++. Migliora l'aspetto delle tue diapositive senza sforzo."
---
## **Panoramica**

Questo articolo mostra come lavorare con l'area del tracciato di un grafico in Aspose.Slides. Spiega come ottenere la posizione e le dimensioni effettive dell'area del tracciato convalidando il layout del grafico e quindi leggendo i valori di X, Y, larghezza e altezza.

Mostra anche come configurare la modalità di layout dell'area del tracciato quando il layout è impostato manualmente, usando `LayoutTargetType` per definire se l'area del tracciato è calcolata dalla sua regione interna o dalla sua regione esterna insieme a assi ed etichette degli assi.

## **Ottenere Larghezza e Altezza di un'Area del Tracciato di un Grafico**
Aspose.Slides per C++ fornisce un'API semplice per .

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
2. Accedi alla prima diapositiva.
3. Aggiungi un grafico con dati predefiniti.
4. Chiama il metodo IChart::ValidateChartLayout() prima per ottenere i valori effettivi.
5. Recupera la posizione X reale (sinistra) dell'elemento del grafico rispetto all'angolo superiore sinistro del grafico.
6. Recupera la posizione Y reale (alto) dell'elemento del grafico rispetto all'angolo superiore sinistro del grafico.
7. Recupera la larghezza reale dell'elemento del grafico.
8. Recupera l'altezza reale dell'elemento del grafico.

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

## **Impostare la Modalità di Layout di un'Area del Tracciato di un Grafico**
Aspose.Slides per C++ fornisce un'API semplice per impostare la modalità di layout dell'area del tracciato del grafico. La proprietà **LayoutTargetType** è stata aggiunta alle classi **ChartPlotArea** e **IChartPlotArea**. Se il layout dell'area del tracciato è definito manualmente, questa proprietà specifica se il layout dell'area del tracciato deve avvenire tramite l'interno (escludendo assi ed etichette degli assi) o tramite l'esterno (includendo assi ed etichette degli assi). Sono disponibili due valori possibili definiti nell'enumerazione **LayoutTargetType**.

- **LayoutTargetType.Inner** - specifica che le dimensioni dell'area del tracciato determinano le dimensioni dell'area del tracciato, escludendo i segni di graduazione e le etichette degli assi.
- **LayoutTargetType.Outer** - specifica che le dimensioni dell'area del tracciato determinano le dimensioni dell'area del tracciato, i segni di graduazione e le etichette degli assi.

Il codice di esempio è fornito di seguito.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **Domande frequenti**

**In quali unità vengono restituiti ActualX, ActualY, ActualWidth e ActualHeight?**

In punti; 1 pollice = 72 punti. Queste sono unità di coordinate di Aspose.Slides.

**Come differisce l'Area del Tracciato dall'Area del Grafico in termini di contenuto?**

L'Area del Tracciato è la zona di disegno dei dati (serie, linee della griglia, linee di tendenza, ecc.); l'Area del Grafico comprende gli elementi circostanti (titolo, legenda, ecc.). Nei grafici 3D, l'Area del Tracciato include anche i piani/pareti e gli assi.

**Come vengono interpretati X, Y, Larghezza e Altezza dell'Area del Tracciato quando il layout è manuale?**

Sono frazioni (0‑1) delle dimensioni complessive del grafico; in questa modalità il posizionamento automatico è disabilitato e le frazioni impostate vengono utilizzate.

**Perché la posizione dell'Area del Tracciato è cambiata dopo aver aggiunto/spostato la legenda?**

La legenda si trova nell'area del grafico al di fuori dell'Area del Tracciato, ma influisce sul layout e sullo spazio disponibile, quindi l'Area del Tracciato può spostarsi quando è attivo il posizionamento automatico. (Questo è il comportamento standard dei grafici di PowerPoint.)