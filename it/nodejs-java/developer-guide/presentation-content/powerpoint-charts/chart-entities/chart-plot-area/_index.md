---
title: Personalizza le aree di tracciamento dei grafici della presentazione in JavaScript
linktitle: Area di tracciamento
type: docs
url: /it/nodejs-java/chart-plot-area/
keywords:
- grafico
- area di tracciamento
- larghezza area di tracciamento
- altezza area di tracciamento
- dimensione area di tracciamento
- modalità di layout
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come personalizzare le aree di tracciamento dei grafici nelle presentazioni PowerPoint con JavaScript e Aspose.Slides per Node.js. Migliora l'aspetto delle tue diapositive senza sforzo."
---
## **Panoramica**

Questo articolo mostra come lavorare con l'area di tracciamento di un grafico in Aspose.Slides. Spiega come ottenere la posizione e le dimensioni effettive dell'area di tracciamento convalidando il layout del grafico e leggendo i valori X, Y, larghezza e altezza.

Mostra inoltre come configurare la modalità di layout dell'area di tracciamento quando il layout è impostato manualmente, usando `LayoutTargetType` per definire se l'area di tracciamento è calcolata dalla sua regione interna o dalla regione esterna insieme a assi ed etichette degli assi.

## **Ottieni larghezza e altezza dell'area di tracciamento del grafico**

Aspose.Slides per Node.js tramite Java fornisce una semplice API per .

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Accedi alla prima diapositiva.
1. Aggiungi un grafico con dati predefiniti.
1. Chiama il metodo [Chart.validateChartLayout()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Chart#validateChartLayout--) prima di ottenere i valori effettivi.
1. Ottiene la posizione X effettiva (sinistra) dell'elemento del grafico rispetto all'angolo in alto a sinistra del grafico.
1. Ottiene la posizione Y effettiva (alto) dell'elemento del grafico rispetto all'angolo in alto a sinistra del grafico.
1. Ottiene la larghezza effettiva dell'elemento del grafico.
1. Ottiene l'altezza effettiva dell'elemento del grafico.

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Imposta la modalità di layout dell'area di tracciamento del grafico**

Aspose.Slides per Node.js tramite Java fornisce una semplice API per impostare la modalità di layout dell'area di tracciamento del grafico. I metodi [**setLayoutTargetType**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) e [**getLayoutTargetType**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) sono stati aggiunti alla classe [**ChartPlotArea**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartPlotArea). Se il layout dell'area di tracciamento è definito manualmente, questa proprietà specifica se il layout dell'area di tracciamento deve essere basato sulla parte interna (escludendo gli assi e le etichette degli assi) o sulla parte esterna (includendo assi ed etichette). Sono possibili due valori, definiti nell'enum [**LayoutTargetType**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/LayoutTargetType#Inner) - specifica che le dimensioni dell'area di tracciamento determinano le dimensioni dell'area di tracciamento, senza includere i segni di graduazione e le etichette degli assi.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/LayoutTargetType#Outer) - specifica che le dimensioni dell'area di tracciamento determinano le dimensioni dell'area di tracciamento, i segni di graduazione e le etichette degli assi.

Il codice di esempio è riportato di seguito.

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**In quali unità vengono restituiti X reale, Y reale, Larghezza reale e Altezza reale?**

In punti; 1 pollice = 72 punti. Queste sono le unità di coordinate di Aspose.Slides.

**In che cosa differisce l'area di tracciamento dall'area del grafico in termini di contenuto?**

L'area di tracciamento è la regione di disegno dei dati (serie, linee della griglia, linee di tendenza, ecc.); l'area del grafico comprende gli elementi circostanti (titolo, legenda, ecc.). Nei grafici 3D, l'area di tracciamento include anche le pareti/pavimento e gli assi.

**Come vengono interpretati X, Y, Larghezza e Altezza dell'area di tracciamento quando il layout è manuale?**

Sono frazioni (0–1) delle dimensioni complessive del grafico; in questa modalità, il posizionamento automatico è disabilitato e vengono utilizzate le frazioni impostate.

**Perché la posizione dell'area di tracciamento è cambiata dopo aver aggiunto/spostato la legenda?**

La legenda si trova nell'area del grafico al di fuori dell'area di tracciamento, ma influisce sul layout e sullo spazio disponibile, quindi l'area di tracciamento può spostarsi quando è attivo il posizionamento automatico. (Questo è il comportamento standard dei grafici PowerPoint.)