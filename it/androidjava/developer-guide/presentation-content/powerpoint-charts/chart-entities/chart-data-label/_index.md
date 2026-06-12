---
title: Gestisci le etichette dei dati del grafico nelle presentazioni su Android
linktitle: Etichetta dati
type: docs
url: /it/androidjava/chart-data-label/
keywords:
- grafico
- etichetta dati
- precisione dei dati
- percentuale
- distanza etichetta
- posizione etichetta
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Impara a aggiungere e formattare le etichette dei dati del grafico nelle presentazioni PowerPoint utilizzando Aspose.Slides per Android tramite Java per slide più coinvolgenti."
---
## **Introduzione**

Le etichette dei dati in un grafico mostrano dettagli sulla serie di dati del grafico o sui singoli punti dati. Consentono ai lettori di identificare rapidamente le serie di dati e rendono i grafici più facili da comprendere.

## **Imposta la precisione dei dati nelle etichette dei grafici**

Questo codice Java mostra come impostare la precisione dei dati in un'etichetta di un grafico:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");

    pres.save("output.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Visualizza le percentuali come etichette**

Aspose.Slides per Android tramite Java consente di impostare etichette percentuali sui grafici visualizzati. Questo codice Java dimostra l'operazione:

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    // Ottiene la prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);
    IChartSeries series;
    double[] total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        IChartCategory cat = chart.getChartData().getCategories().get_Item(k);
    
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + (double) (chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData());
        }
    }
    
    double dataPontPercent = 0f;
    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
    
        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (double) ((series.getDataPoints().get_Item(j).getValue().getData())) / (double) (total_for_Cat[j]) * 100;
    
            IPortion port = new Portion();
            port.setText(String.format("{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8f);
            lbl.getTextFrameForOverriding().setText("");
            IParagraph para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
    
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    
    // Salva la presentazione contenente il grafico
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Imposta il simbolo percentuale nelle etichette dei grafici**

Questo codice Java mostra come impostare il simbolo percentuale per un'etichetta di un grafico:

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    // Ottiene il riferimento a una diapositiva tramite il suo indice
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Crea il grafico PercentsStackedColumn su una diapositiva
    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    
    // Imposta NumberFormatLinkedToSource su false
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    
    chart.getChartData().getSeries().clear();
    int defaultWorksheetIndex = 0;
    
    // Ottiene il foglio di lavoro dei dati del grafico
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    
    // Aggiunge una nuova serie
    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.30));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.50));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.80));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    
    // Imposta il colore di riempimento della serie
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Imposta le proprietà di LabelFormat
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Aggiunge una nuova serie
    IChartSeries series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.70));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.50));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.20));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    
    // Imposta il tipo e il colore di riempimento
    series2.getFormat().getFill().setFillType(FillType.Solid);
    series2.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    
    // Scrive la presentazione su disco
    pres.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Imposta la distanza dell'etichetta da un asse**

Questo codice Java mostra come impostare la distanza dell'etichetta da un asse di categoria quando si lavora con un grafico tracciato da assi:

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    // Ottiene il riferimento a una diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Crea un grafico sulla diapositiva
    IChart ch = sld.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    
    // Imposta la distanza dell'etichetta da un asse
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    
    // Scrive la presentazione su disco
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Regola la posizione dell'etichetta**

Quando crei un grafico che non dipende da alcun asse, come un grafico a torta, le etichette dei dati del grafico possono risultare troppo vicine al suo bordo. In tal caso, devi regolare la posizione dell'etichetta dei dati affinché le linee guida vengano visualizzate chiaramente.

Questo codice Java mostra come regolare la posizione dell'etichetta su un grafico a torta:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.getChartData().getSeries();
    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);

    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **FAQ**

**Come posso impedire la sovrapposizione delle etichette dei dati su grafici densi?**

Combina il posizionamento automatico delle etichette, le linee guida e una dimensione del carattere ridotta; se necessario, nascondi alcuni campi (ad esempio, la categoria) o mostra le etichette solo per i punti estremi/chiave.

**Come posso disabilitare le etichette solo per valori zero, negativi o vuoti?**

Filtra i punti dati prima di abilitare le etichette e disattiva la visualizzazione per valori pari a 0, valori negativi o valori mancanti secondo una regola definita.

**Come posso garantire uno stile coerente delle etichette durante l'esportazione in PDF/immagini?**

Imposta esplicitamente i caratteri (famiglia, dimensione) e verifica che il carattere sia disponibile sul lato di rendering per evitare il fallback.