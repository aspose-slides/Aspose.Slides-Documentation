---
title: Ottimizza i calcoli dei grafici per le presentazioni in JavaScript
linktitle: Calcoli dei grafici
type: docs
weight: 50
url: /it/nodejs-java/chart-calculations/
keywords:
- calcoli dei grafici
- elementi del grafico
- posizione dell'elemento
- posizione reale
- elemento figlio
- elemento genitore
- valori del grafico
- valore reale
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Comprendi i calcoli dei grafici, gli aggiornamenti dei dati e il controllo della precisione in Aspose.Slides per Node.js per PPT e PPTX, con esempi pratici di codice JavaScript."
---
## **Panoramica**

Aspose.Slides fornisce API per lavorare con i calcoli dei grafici e i dati di layout nelle presentazioni. Questo articolo mostra come recuperare i valori effettivi degli elementi del grafico, includendo la posizione reale e le dimensioni degli elementi e i valori effettivi degli assi del grafico. Spiega inoltre che questi valori sono popolati dopo la convalida del layout del grafico.

In aggiunta, l’articolo dimostra come ottenere la posizione effettiva degli elementi genitori del grafico e come nascondere componenti del grafico come il titolo, gli assi, la legenda e le linee della griglia. Insieme, questi esempi ti aiutano a ispezionare le informazioni di layout del grafico e a controllare la visibilità degli elementi del grafico nelle presentazioni PowerPoint in modo programmatico.

## **Calcolare i valori effettivi degli elementi del grafico**

Aspose.Slides for Node.js via Java fornisce un’API semplice per ottenere queste proprietà. Le proprietà della classe [Axis](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Axis) forniscono informazioni sulla posizione effettiva dell’elemento asse del grafico ([Axis.getActualMaxValue](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--) ). È necessario chiamare il metodo [Chart.validateChartLayout()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Chart#validateChartLayout--) in precedenza per riempire le proprietà con i valori effettivi.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Calcolare la posizione effettiva degli elementi genitori del grafico**

Aspose.Slides for Node.js via Java fornisce un’API semplice per ottenere queste proprietà. Le proprietà della classe `ActualLayout` forniscono informazioni sulla posizione effettiva dell’elemento genitore del grafico `ActualLayout.getActualX`, `ActualLayout.getActualY`, `ActualLayout.getActualWidth`, `ActualLayout.getActualHeight`. È necessario chiamare il metodo [Chart.validateChartLayout()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Chart#validateChartLayout--) in precedenza per riempire le proprietà con i valori effettivi.

```javascript
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

## **Nascondere le informazioni dal grafico**

Questo argomento ti aiuta a capire come nascondere le informazioni dal grafico. Utilizzando Aspose.Slides for Node.js via Java puoi nascondere **Titolo, Asse verticale, Asse orizzontale** e **Linee della griglia** dal grafico. Il seguente esempio di codice mostra come utilizzare queste proprietà.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // Nascondi il titolo del grafico
    chart.setTitle(false);
    // /Nascondi asse dei valori
    chart.getAxes().getVerticalAxis().setVisible(false);
    // Visibilità asse di categoria
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // Nascondi legenda
    chart.setLegend(false);
    // Nascondi linee della griglia principale
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // Impostazione colore della linea della serie
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**I cartelle di lavoro Excel esterne funzionano come origine dati e come influiscono sul ricalcolo?**

Sì. Un grafico può fare riferimento a una cartella di lavoro esterna: quando colleghi o aggiorni la fonte esterna, formule e valori vengono prelevati da quella cartella e il grafico riflette gli aggiornamenti durante le operazioni di apertura/modifica. L’API consente di [specificare il percorso della cartella di lavoro esterna](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) e di gestire i dati collegati.

**Posso calcolare e visualizzare le linee di tendenza senza implementare io stesso la regressione?**

Sì. Le [Trendlines](/slides/it/nodejs-java/trend-line/) (lineari, esponenziali e altre) sono aggiunte e aggiornate da Aspose.Slides; i loro parametri vengono ricalcolati automaticamente dai dati delle serie, quindi non è necessario implementare calcoli propri.

**Se una presentazione contiene più grafici con collegamenti esterni, posso controllare quale cartella di lavoro utilizza ciascun grafico per i valori calcolati?**

Sì. Ogni grafico può puntare a una propria [external workbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/setexternalworkbook/), oppure è possibile creare/sostituire una cartella di lavoro esterna per ogni grafico in modo indipendente dalle altre.