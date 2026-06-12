---
title: Personalizza grafici a torta nelle presentazioni usando Java
linktitle: Grafico a torta
type: docs
url: /it/java/pie-chart/
keywords:
- grafico a torta
- gestire grafico
- personalizzare grafico
- opzioni del grafico
- impostazioni del grafico
- opzioni di tracciato
- colore della fetta
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come creare e personalizzare grafici a torta in Java con Aspose.Slides, esportabili in PowerPoint, migliorando la narrazione dei tuoi dati in pochi secondi."
---
## **Panoramica**

Questo articolo spiega come lavorare con i grafici a torta in Aspose.Slides. Mostra come configurare le opzioni di secondo tracciato per i grafici Pie of Pie e Bar of Pie e come abilitare la colorazione automatica delle fette per un grafico a torta standard.

Gli esempi si concentrano su passaggi pratici di personalizzazione del grafico, come aggiungere un grafico a una diapositiva, regolare le impostazioni delle serie e delle etichette, sostituire i dati predefiniti del grafico con categorie e valori personalizzati e salvare la presentazione aggiornata.

## **Opzioni di secondo tracciato per i grafici Pie of Pie e Bar of Pie**
Aspose.Slides per Java ora supporta le opzioni di secondo tracciato per i grafici Pie of Pie o Bar of Pie. In questo argomento ti mostreremo come specificare tali opzioni usando Aspose.Slides. Per specificare le proprietà, procedi così:

1. Istanzia un oggetto della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Aggiungi un grafico alla diapositiva.
1. Specifica le opzioni di secondo tracciato del grafico.
1. Scrivi la presentazione su disco.

 Nell'esempio riportato di seguito, abbiamo impostato diverse proprietà del grafico Pie of Pie.

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    // Aggiungi un grafico alla diapositiva
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Imposta diverse proprietà
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Scrivi la presentazione su disco
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Imposta colori automatici per le fette del grafico a torta**
Aspose.Slides per Java fornisce un'API semplice per impostare automaticamente i colori delle fette del grafico a torta. Il codice di esempio applica le impostazioni delle proprietà sopra descritte.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Accedi alla prima diapositiva.
1. Aggiungi un grafico con dati predefiniti.
1. Imposta il titolo del grafico.
1. Imposta la prima serie per mostrare i valori.
1. Imposta l'indice del foglio dati del grafico.
1. Ottieni il foglio di lavoro dei dati del grafico.
1. Elimina le serie e le categorie generate per impostazione predefinita.
1. Aggiungi nuove categorie.
1. Aggiungi nuove serie.

Scrivi la presentazione modificata in un file PPTX.

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    // Aggiungi un grafico con dati predefiniti
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Impostazione del titolo del grafico
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Imposta la prima serie per mostrare i valori
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Impostazione dell'indice del foglio dati del grafico
    int defaultWorksheetIndex = 0;

    // Recupero del foglio di lavoro dei dati del grafico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Elimina le serie e le categorie generate per impostazione predefinita
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Aggiunta di nuove categorie
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Aggiunta di una nuova serie
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Ora popolamento dei dati della serie
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Le varianti 'Pie of Pie' e 'Bar of Pie' sono supportate?**

Sì, la libreria [supporta](https://reference.aspose.com/slides/it/java/com.aspose.slides/charttype/) un tracciato secondario per i grafici a torta, inclusi i tipi 'Pie of Pie' e 'Bar of Pie'.

**Posso esportare solo il grafico come immagine (ad esempio PNG)?**

Sì, puoi [esportare il grafico stesso come immagine](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#getImage-int-float-float-) (ad esempio PNG) senza l'intera presentazione.