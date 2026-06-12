---
title: Personalizza le aree di tracciato dei grafici di presentazione in Python
linktitle: Area di tracciato
type: docs
url: /it/python-net/chart-plot-area/
keywords:
- grafico
- area di tracciato
- larghezza area di tracciato
- altezza area di tracciato
- dimensione area di tracciato
- modalità di layout
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come personalizzare le aree di tracciato dei grafici in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python via .NET. Migliora l'aspetto delle tue diapositive senza sforzo."
---
## **Panoramica**

Questo articolo mostra come lavorare con l'area del tracciato di un grafico in Aspose.Slides. Spiega come ottenere la posizione e le dimensioni effettive dell'area del tracciato convalidando il layout del grafico e quindi leggendo i valori X, Y, larghezza e altezza.

Mostra inoltre come configurare la modalità di layout dell'area del tracciato quando il layout è impostato manualmente, usando `LayoutTargetType` per definire se l'area del tracciato è calcolata dalla sua regione interna o dalla sua regione esterna insieme agli assi e alle etichette degli assi.

## **Ottieni larghezza e altezza dell'area del tracciato del grafico**
Aspose.Slides per Python via .NET fornisce una semplice API per .

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Aggiungi un grafico con dati predefiniti.
4. Chiama il metodo IChart.ValidateChartLayout() prima di ottenere i valori effettivi.
5. Ottiene la posizione X effettiva (sinistra) dell'elemento del grafico relativa all'angolo superiore sinistro del grafico.
6. Ottiene la quota superiore effettiva dell'elemento del grafico relativa all'angolo superiore sinistro del grafico.
7. Ottiene la larghezza effettiva dell'elemento del grafico.
8. Ottiene l'altezza effettiva dell'elemento del grafico.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# Salva la presentazione con il grafico
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta la modalità di layout dell'area del tracciato del grafico**
Aspose.Slides per Python via .NET fornisce una semplice API per impostare la modalità di layout dell'area del tracciato del grafico. La proprietà **LayoutTargetType** è stata aggiunta alle classi **ChartPlotArea** e **IChartPlotArea**. Se il layout dell'area del tracciato è definito manualmente, questa proprietà specifica se il layout dell'area del tracciato deve essere basato sul suo interno (escludendo gli assi e le etichette degli assi) o sull'esterno (includendo assi e etichette degli assi). Sono possibili due valori, definiti nell'enumerazione **LayoutTargetType**.

- **LayoutTargetType.Inner** - specifica che le dimensioni dell'area del tracciato determinano le dimensioni dell'area del tracciato, escludendo i segni di graduazione e le etichette degli assi.
- **LayoutTargetType.Outer** - specifica che le dimensioni dell'area del tracciato determinano le dimensioni dell'area del tracciato, i segni di graduazione e le etichette degli assi.

Il codice di esempio è fornito di seguito.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**In quali unità vengono restituiti actual_x, actual_y, actual_width e actual_height?**

In punti; 1 pollice = 72 punti. Queste sono le unità di coordinate di Aspose.Slides.

**In che modo l'Area del Tracciato differisce dall'Area del Grafico in termini di contenuto?**

L'Area del Tracciato è la regione di disegno dei dati (serie, linee della griglia, linee di tendenza, ecc.); l'Area del Grafico include gli elementi circostanti (titolo, legenda, ecc.). Nei grafici 3D, l'Area del Tracciato include anche le pareti/pavimento e gli assi.

**Come vengono interpretati X, Y, Larghezza e Altezza dell'Area del Tracciato quando il layout è manuale?**

Sono frazioni (0–1) delle dimensioni complessive del grafico; in questa modalità, il posizionamento automatico è disattivato e vengono utilizzate le frazioni impostate.

**Perché la posizione dell'Area del Tracciato è cambiata dopo aver aggiunto/spostato la legenda?**

La legenda si trova nell'area del grafico al di fuori dell'Area del Tracciato, ma influenza il layout e lo spazio disponibile, quindi l'Area del Tracciato può spostarsi quando il posizionamento automatico è attivo. (Questo è il comportamento standard per i grafici di PowerPoint.)