---
title: Ottimizzare i calcoli dei grafici per le presentazioni in Java
linktitle: Calcoli dei grafici
type: docs
weight: 50
url: /it/java/chart-calculations/
keywords:
- calcoli dei grafici
- elementi del grafico
- posizione dell'elemento
- posizione effettiva
- elemento figlio
- elemento genitore
- valori del grafico
- valore effettivo
- PowerPoint
- presentazioni
- Java
- Aspose.Slides
description: "Comprendere i calcoli dei grafici, gli aggiornamenti dei dati e il controllo della precisione in Aspose.Slides per Java per PPT e PPTX, con esempi pratici di codice Java."
---
## **Panoramica**

Aspose.Slides fornisce API per lavorare con i calcoli dei grafici e i dati di layout nelle presentazioni. Questo articolo mostra come recuperare i valori effettivi degli elementi del grafico, inclusa la posizione e le dimensioni reali degli elementi che implementano `IActualLayout` e i valori effettivi degli assi del grafico. Spiega inoltre che questi valori vengono popolati dopo la convalida del layout del grafico.

Inoltre, l'articolo dimostra come ottenere la posizione effettiva degli elementi genitore del grafico e come nascondere componenti del grafico come il titolo, gli assi, la leggenda e le linee della griglia. Insieme, questi esempi ti aiutano a ispezionare le informazioni di layout del grafico e a controllare la visibilità degli elementi del grafico nelle presentazioni PowerPoint in modo programmatico.

## **Calcolare i valori effettivi degli elementi del grafico**
Aspose.Slides per Java fornisce un'API semplice per recuperare queste proprietà. Le proprietà dell'interfaccia [IAxis](https://reference.aspose.com/slides/it/java/com.aspose.slides/IAxis) forniscono informazioni sulla posizione effettiva dell'elemento asse del grafico ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/it/java/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/it/java/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/it/java/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/it/java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/it/java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/it/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)). È necessario chiamare il metodo [IChart.validateChartLayout()](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChart#validateChartLayout--) in precedenza per riempire le proprietà con i valori effettivi.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Calcolare la posizione effettiva degli elementi genitore del grafico**
Aspose.Slides per Java fornisce un'API semplice per recuperare queste proprietà. Le proprietà dell'interfaccia [IActualLayout](https://reference.aspose.com/slides/it/java/com.aspose.slides/IActualLayout) forniscono informazioni sulla posizione effettiva dell'elemento genitore del grafico ([IActualLayout.getActualX](https://reference.aspose.com/slides/it/java/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/it/java/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/it/java/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/it/java/com.aspose.slides/IActualLayout#getActualHeight--)). È necessario chiamare il metodo [IChart.validateChartLayout()](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChart#validateChartLayout--) in precedenza per riempire le proprietà con i valori effettivi.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nascondere gli elementi del grafico**
Questo argomento ti aiuta a capire come nascondere informazioni dal grafico. Utilizzando Aspose.Slides per Java è possibile nascondere **Titolo, Asse verticale, Asse orizzontale** e **Linee della griglia** dal grafico. Il seguente esempio di codice mostra come utilizzare queste proprietà.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Nascondere il titolo del grafico
    chart.setTitle(false);

    ///Nascondere l'asse dei valori
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Visibilità dell'asse di categoria
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Nascondere la leggenda
    chart.setLegend(false);

    //Nascondere le linee della griglia principale
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //Impostare il colore della linea della serie
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**I libri di lavoro Excel esterni funzionano come fonte dati e come influiscono sul ricalcolo?**

Sì. Un grafico può fare riferimento a un libro di lavoro esterno: quando colleghi o aggiorni la fonte esterna, le formule e i valori vengono prelevati da quel libro, e il grafico riflette gli aggiornamenti durante le operazioni di apertura o modifica. L'API consente di [specificare il percorso del libro di lavoro esterno](https://reference.aspose.com/slides/it/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) e gestire i dati collegati.

**Posso calcolare e visualizzare le linee di tendenza senza implementare personalmente la regressione?**

Sì. Le [linee di tendenza](/slides/it/java/trend-line/) (lineari, esponenziali e altre) vengono aggiunte e aggiornate da Aspose.Slides; i loro parametri sono ricalcolati automaticamente dai dati della serie, quindi non è necessario implementare i propri calcoli.

**Se una presentazione contiene più grafici con collegamenti esterni, posso controllare quale libro di lavoro utilizza ogni grafico per i valori calcolati?**

Sì. Ogni grafico può puntare al proprio [libro di lavoro esterno](https://reference.aspose.com/slides/it/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-), oppure è possibile creare o sostituire un libro di lavoro esterno per ciascun grafico in modo indipendente dagli altri.