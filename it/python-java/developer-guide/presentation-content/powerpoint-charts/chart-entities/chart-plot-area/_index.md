---
title: Personalizza le aree di tracciamento dei grafici di presentazione in Python
linktitle: Area di tracciamento
type: docs
url: /it/python-java/chart-plot-area/
keywords:
- grafico
- area di tracciamento
- larghezza area di tracciamento
- altezza area di tracciamento
- dimensione area di tracciamento
- modalità di layout
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come personalizzare le aree di tracciamento dei grafici nelle presentazioni PowerPoint con Aspose.Slides per Python tramite Java. Migliora l'aspetto delle tue diapositive senza sforzo."
---
## **Panoramica**

Questo articolo mostra come lavorare con l'area di tracciamento di un grafico in Aspose.Slides. Spiega come ottenere la posizione e le dimensioni effettive dell'area di tracciamento convalidando il layout del grafico e quindi leggendo i valori X, Y, larghezza e altezza.

Mostra inoltre come configurare la modalità di layout dell'area di tracciamento quando il layout è impostato manualmente, usando [LayoutTargetType](https://reference.aspose.com/slides/it/python-java/aspose.slides/layouttargettype/) per definire se l'area di tracciamento è calcolata dalla sua regione interna o dalla sua regione esterna insieme a assi ed etichette degli assi.

## **Ottenere larghezza e altezza di un'area di tracciamento del grafico**

Aspose.Slides for Python tramite Java fornisce un'API semplice per leggere la posizione e le dimensioni effettive dell'area di tracciamento di un grafico.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Accedi alla prima diapositiva.
1. Aggiungi un grafico con dati predefiniti.
1. Chiama il metodo [Chart.validateChartLayout](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#validateChartLayout) prima di ottenere i valori effettivi.
1. Ottieni la posizione X effettiva (sinistra) dell'elemento del grafico rispetto all'angolo superiore sinistro del grafico.
1. Ottieni la posizione Y effettiva (superiore) dell'elemento del grafico rispetto all'angolo superiore sinistro del grafico.
1. Ottieni la larghezza effettiva dell'elemento del grafico.
1. Ottieni l'altezza effettiva dell'elemento del grafico.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# Crea un'istanza della classe Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **Impostare la modalità di layout di un'area di tracciamento del grafico**

Aspose.Slides per Python tramite Java fornisce un'API semplice per impostare la modalità di layout dell'area di tracciamento del grafico. I metodi [setLayoutTargetType](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) e [getLayoutTargetType](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) sono disponibili nella classe [ChartPlotArea](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartplotarea/). Se il layout dell'area di tracciamento è definito manualmente, questa impostazione specifica se disporre l'area di tracciamento internamente (escludendo assi ed etichette degli assi) o esternamente (includendo assi ed etichette degli assi). Sono presenti due valori possibili definiti nell'enumerazione [LayoutTargetType](https://reference.aspose.com/slides/it/python-java/aspose.slides/layouttargettype/).

- [Inner](https://reference.aspose.com/slides/it/python-java/aspose.slides/layouttargettype/#Inner) specifica che la dimensione dell'area di tracciamento esclude i segni di graduazione e le etichette degli assi.
- [Outer](https://reference.aspose.com/slides/it/python-java/aspose.slides/layouttargettype/#Outer) specifica che la dimensione dell'area di tracciamento include i segni di graduazione e le etichette degli assi.

Il codice di esempio è fornito di seguito.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# Crea un'istanza della classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**In quali unità vengono restituite X reale, Y reale, larghezza reale e altezza reale?**

In punti; 1 pollice = 72 punti. Queste sono le unità di coordinate di Aspose.Slides.

**In che modo l'area di tracciamento differisce dall'area del grafico in termini di contenuto?**

L'area di tracciamento è la regione di disegno dei dati (serie, linee della griglia, linee di tendenza, ecc.); l'area del grafico comprende gli elementi circostanti (titolo, legenda, ecc.). Nei grafici 3D, l'area di tracciamento include anche le pareti/pavimento e gli assi.

**Come vengono interpretati X, Y, larghezza e altezza dell'area di tracciamento quando il layout è manuale?**

Sono frazioni (0–1) delle dimensioni complessive del grafico; in questa modalità il posizionamento automatico è disabilitato e vengono utilizzate le frazioni impostate.

**Perché la posizione dell'area di tracciamento è cambiata dopo aver aggiunto o spostato la legenda?**

La legenda si trova nell'area del grafico al di fuori dell'area di tracciamento ma influisce sul layout e sullo spazio disponibile, quindi l'area di tracciamento può spostarsi quando è attivo il posizionamento automatico. (Questo è il comportamento standard per i grafici di PowerPoint.)