---
title: Ottimizza i calcoli dei grafici per le presentazioni su Android
linktitle: Calcoli dei grafici
type: docs
weight: 50
url: /it/androidjava/chart-calculations/
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
- Android
- Java
- Aspose.Slides
description: "Comprendi i calcoli dei grafici, gli aggiornamenti dei dati e il controllo della precisione in Aspose.Slides per Android per PPT e PPTX, con esempi pratici di codice Java."
---
## **Panoramica**

Aspose.Slides fornisce API per lavorare con i calcoli dei grafici e i dati di layout nelle presentazioni. Questo articolo mostra come recuperare i valori effettivi degli elementi del grafico, inclusa la posizione reale e le dimensioni degli elementi che implementano `IActualLayout` e i valori effettivi degli assi del grafico. Spiega inoltre che questi valori vengono popolati dopo la convalida del layout del grafico.

Inoltre, l'articolo dimostra come ottenere la posizione reale degli elementi genitore del grafico e come nascondere componenti del grafico come il titolo, gli assi, la legenda e le linee della griglia. Insieme, questi esempi ti aiutano a ispezionare le informazioni di layout del grafico e a controllare la visibilità degli elementi del grafico nelle presentazioni PowerPoint in modo programmatico.

## **Calcolare i valori effettivi degli elementi del grafico**
Aspose.Slides for Android via Java fornisce una semplice API per ottenere queste proprietà. Le proprietà dell'interfaccia [IAxis](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAxis) forniscono informazioni sulla posizione reale dell'elemento asse del grafico ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAxis#getActualMinorUnitScale--)). È necessario chiamare il metodo [IChart.validateChartLayout()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChart#validateChartLayout--) in precedenza per popolare le proprietà con i valori effettivi.

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

## **Calcolare la posizione reale degli elementi genitore del grafico**
Aspose.Slides for Android via Java fornisce una semplice API per ottenere queste proprietà. Le proprietà dell'interfaccia [IActualLayout](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IActualLayout) forniscono informazioni sulla posizione reale dell'elemento genitore del grafico ([IActualLayout.getActualX](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IActualLayout#getActualHeight--)). È necessario chiamare il metodo [IChart.validateChartLayout()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChart#validateChartLayout--) in precedenza per popolare le proprietà con i valori effettivi.

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
Questo argomento ti aiuta a capire come nascondere informazioni dal grafico. Utilizzando Aspose.Slides per Android via Java è possibile nascondere **Titolo, Asse verticale, Asse orizzontale** e **Linee della griglia** dal grafico. Il seguente esempio di codice mostra come utilizzare queste proprietà.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Nascondere il titolo del grafico
    chart.setTitle(false);

    ///Nascondere l'asse dei valori
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Visibilità dell'asse delle categorie
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Nascondere la legenda
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

**I cartelle di lavoro Excel esterne possono essere utilizzate come fonte dati e come influiscono sul ricalcolo?**

Sì. Un grafico può fare riferimento a una cartella di lavoro esterna: quando si collega o si aggiorna la fonte esterna, le formule e i valori vengono prelevati da quella cartella di lavoro e il grafico riflette gli aggiornamenti durante le operazioni di apertura/modifica. L'API consente di [specificare il percorso della cartella di lavoro esterna](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) e di gestire i dati collegati.

**Posso calcolare e visualizzare le linee di tendenza senza implementare io stesso la regressione?**

Sì. Le [linee di tendenza](/slides/it/androidjava/trend-line/) (lineare, esponenziale e altre) sono aggiunte e aggiornate da Aspose.Slides; i loro parametri vengono ricalcolati automaticamente dai dati della serie, quindi non è necessario implementare i propri calcoli.

**Se una presentazione contiene più grafici con collegamenti esterni, posso controllare quale cartella di lavoro utilizza ciascun grafico per i valori calcolati?**

Sì. Ogni grafico può puntare alla propria [cartella di lavoro esterna](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-), oppure è possibile creare/sostituire una cartella di lavoro esterna per grafico in modo indipendente dalle altre.