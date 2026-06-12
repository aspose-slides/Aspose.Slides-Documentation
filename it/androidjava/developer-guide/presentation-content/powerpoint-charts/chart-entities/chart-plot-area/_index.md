---
title: Personalizza le aree del tracciato dei grafici di presentazione su Android
linktitle: Area del tracciato
type: docs
url: /it/androidjava/chart-plot-area/
keywords:
- grafico
- area del tracciato
- larghezza area del tracciato
- altezza area del tracciato
- dimensione area del tracciato
- modalità di layout
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come personalizzare le aree del tracciato dei grafici nelle presentazioni PowerPoint con Aspose.Slides per Android via Java. Migliora facilmente l'aspetto delle tue diapositive."
---
## **Panoramica**

Questo articolo mostra come lavorare con l'area del tracciato di un grafico in Aspose.Slides. Spiega come ottenere la posizione e le dimensioni effettive dell'area del tracciato validando il layout del grafico e quindi leggendo i valori di X, Y, larghezza e altezza.

Mostra inoltre come configurare la modalità di layout dell'area del tracciato quando il layout è impostato manualmente, usando `LayoutTargetType` per definire se l'area del tracciato è calcolata dalla sua regione interna o dalla regione esterna insieme a assi ed etichette degli assi.

## **Ottieni larghezza e altezza di un'area del tracciato del grafico**
Aspose.Slides for Android via Java fornisce un'API semplice per . 

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Accedi alla prima diapositiva.
3. Aggiungi un grafico con dati predefiniti.
4. Chiama il metodo [IChart.validateChartLayout()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChart#validateChartLayout--) prima di ottenere i valori effettivi.
5. Restituisce la posizione X reale (sinistra) dell'elemento del grafico relativo all'angolo in alto a sinistra del grafico.
6. Restituisce la parte superiore reale dell'elemento del grafico relativa all'angolo in alto a sinistra del grafico.
7. Restituisce la larghezza reale dell'elemento del grafico.
8. Restituisce l'altezza reale dell'elemento del grafico.

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

## **Imposta la modalità di layout di un'area del tracciato del grafico**
Aspose.Slides for Android via Java fornisce un'API semplice per impostare la modalità di layout dell'area del tracciato del grafico. I metodi [**setLayoutTargetType**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) e [**getLayoutTargetType**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) sono stati aggiunti alla classe [**ChartPlotArea**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ChartPlotArea) e all'interfaccia [**IChartPlotArea**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartPlotArea). Se il layout dell'area del tracciato è definito manualmente, questa proprietà specifica se disporre l'area del tracciato per l'interno (escludendo assi ed etichette degli assi) o per l'esterno (includendo assi ed etichette). Sono possibili due valori, definiti nell'enumerazione [**LayoutTargetType**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/LayoutTargetType) .

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/LayoutTargetType#Inner) - specifica che la dimensione dell'area del tracciato determina la dimensione dell'area del tracciato, senza includere i segni di tacche e le etichette degli assi.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/LayoutTargetType#Outer) - specifica che la dimensione dell'area del tracciato determina la dimensione dell'area del tracciato, i segni di tacche e le etichette degli assi.

Il codice di esempio è fornito di seguito.

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

**In quali unità vengono restituiti x reale, y reale, larghezza reale e altezza reale?**

In punti; 1 pollice = 72 punti. Queste sono le unità di coordinate di Aspose.Slides.

**In cosa differisce l'area del tracciato dall'area del grafico in termini di contenuto?**

L'area del tracciato è la regione di disegno dei dati (serie, linee della griglia, linee di tendenza, ecc.); l'area del grafico include gli elementi circostanti (titolo, legenda, ecc.). Nei grafici 3D, l'area del tracciato comprende anche le pareti/pavimento e gli assi.

**Come vengono interpretati x, y, larghezza e altezza dell'area del tracciato quando il layout è manuale?**

Sono frazioni (0–1) della dimensione complessiva del grafico; in questa modalità il posizionamento automatico è disabilitato e vengono usate le frazioni impostate.

**Perché la posizione dell'area del tracciato è cambiata dopo aver aggiunto/spostato la legenda?**

La legenda si trova nell'area del grafico al di fuori dell'area del tracciato, ma influenza il layout e lo spazio disponibile, quindi l'area del tracciato può spostarsi quando è attivo il posizionamento automatico. (Questo è il comportamento standard per i grafici PowerPoint.)