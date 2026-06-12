---
title: Personalizza le aree di tracciamento dei grafici di presentazione in Java
linktitle: Area di tracciamento
type: docs
url: /it/java/chart-plot-area/
keywords:
- grafico
- area di tracciamento
- larghezza area di tracciamento
- altezza area di tracciamento
- dimensione area di tracciamento
- modalità di layout
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come personalizzare le aree di tracciamento dei grafici nelle presentazioni PowerPoint con Aspose.Slides per Java. Migliora facilmente l'aspetto delle tue diapositive."
---
## **Panoramica**

Questo articolo mostra come lavorare con l'area di tracciamento di un grafico in Aspose.Slides. Spiega come ottenere la posizione e le dimensioni effettive dell'area di tracciamento convalidando il layout del grafico e quindi leggendo i valori X, Y, larghezza e altezza.

Dimostra inoltre come configurare la modalità di layout dell'area di tracciamento quando il layout è impostato manualmente, utilizzando `LayoutTargetType` per definire se l'area di tracciamento è calcolata dalla sua regione interna o dalla sua regione esterna insieme a assi ed etichette degli assi.

## **Ottenere larghezza e altezza di un'area di tracciamento del grafico**
Aspose.Slides per Java fornisce un'API semplice per .

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2. Accedi alla prima diapositiva.
3. Aggiungi un grafico con dati predefiniti.
4. Chiama il metodo [IChart.validateChartLayout()](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChart#validateChartLayout--) prima di ottenere i valori effettivi.
5. Ottiene la posizione X effettiva (sinistra) dell'elemento del grafico rispetto all'angolo superiore sinistro del grafico.
6. Ottiene la posizione Y effettiva (alto) dell'elemento del grafico rispetto all'angolo superiore sinistro del grafico.
7. Ottiene la larghezza effettiva dell'elemento del grafico.
8. Ottiene l'altezza effettiva dell'elemento del grafico.

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Impostare la modalità di layout di un'area di tracciamento del grafico**
Aspose.Slides per Java fornisce un'API semplice per impostare la modalità di layout dell'area di tracciamento del grafico. I metodi [**setLayoutTargetType**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) e [**getLayoutTargetType**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) sono stati aggiunti alla classe [**ChartPlotArea**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ChartPlotArea) e all'interfaccia [**IChartPlotArea**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartPlotArea). Se il layout dell'area di tracciamento è definito manualmente, questa proprietà specifica se il layout deve avvenire usando l'interno (escludendo gli assi e le loro etichette) o l'esterno (includendo assi ed etichette). Sono possibili due valori definiti nell'enumerazione [**LayoutTargetType**](https://reference.aspose.com/slides/it/java/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/it/java/com.aspose.slides/LayoutTargetType#Inner) – indica che la dimensione dell'area di tracciamento deve determinare la dimensione dell'area di tracciamento, senza includere le tacche e le etichette degli assi.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/it/java/com.aspose.slides/LayoutTargetType#Outer) – indica che la dimensione dell'area di tracciamento deve determinare la dimensione dell'area di tracciamento, le tacche e le etichette degli assi.

Di seguito è riportato un esempio di codice.

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**In quali unità vengono restituiti x effettivo, y effettivo, larghezza effettiva e altezza effettiva?**

In punti; 1 pollice = 72 punti. Queste sono le unità di coordinata di Aspose.Slides.

**In che modo l'area di tracciamento differisce dall'area del grafico per contenuto?**

L'area di tracciamento è la regione di disegno dei dati (serie, linee della griglia, linee di tendenza, ecc.); l'area del grafico include gli elementi circostanti (titolo, legenda, ecc.). Nei grafici 3D, l'area di tracciamento comprende anche pareti/pavimento e gli assi.

**Come vengono interpretati x, y, larghezza e altezza dell'area di tracciamento quando il layout è manuale?**

Sono frazioni (0–1) della dimensione complessiva del grafico; in questa modalità il posizionamento automatico è disattivato e le frazioni impostate vengono utilizzate.

**Perché la posizione dell'area di tracciamento è cambiata dopo aver aggiunto/spostato la legenda?**

La legenda si trova nell'area del grafico al di fuori dell'area di tracciamento ma influisce sul layout e sullo spazio disponibile, quindi l'area di tracciamento può spostarsi quando è attivo il posizionamento automatico. (Questo è il comportamento standard per i grafici di PowerPoint.)