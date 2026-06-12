---
title: Personalizza i grafici a torta nelle presentazioni usando JavaScript
linktitle: Grafico a torta
type: docs
url: /it/nodejs-java/pie-chart/
keywords:
- grafico a torta
- gestire il grafico
- personalizzare il grafico
- opzioni del grafico
- impostazioni del grafico
- opzioni di tracciato
- colore della fetta
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come creare e personalizzare grafici a torta in JavaScript con Aspose.Slides per Node.js, esportabili in PowerPoint, migliorando la narrazione dei tuoi dati in pochi secondi."
---
## **Panoramica**

Questo articolo spiega come lavorare con i grafici a torta in Aspose.Slides. Mostra come configurare le opzioni di tracciato secondario per i grafici Pie of Pie e Bar of Pie, e come abilitare la colorazione automatica delle fette per un grafico a torta standard.

Gli esempi si concentrano su passaggi pratici di personalizzazione dei grafici, come aggiungere un grafico a una diapositiva, regolare le impostazioni delle serie e delle etichette, sostituire i dati predefiniti del grafico con categorie e valori personalizzati e salvare la presentazione aggiornata.

## **Opzioni di Tracciato Secondario per i Grafici Pie of Pie e Bar of Pie**

Aspose.Slides per Node.js via Java ora supporta le opzioni di tracciato secondario per i grafici Pie of Pie o Bar of Pie. In questo argomento, ti mostreremo come specificare tali opzioni usando Aspose.Slides. Per specificare le proprietà, esegui quanto segue:

1. Istanzia un oggetto della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Aggiungi un grafico alla diapositiva.
3. Specifica le opzioni di tracciato secondario del grafico.
4. Scrivi la presentazione su disco.

Nell'esempio riportato di seguito, abbiamo impostato diverse proprietà del grafico Pie of Pie.

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Aggiungi il grafico alla diapositiva
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // Imposta diverse proprietà
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // Scrivi la presentazione su disco
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Imposta i Colori Automatici delle Fette del Grafico a Torta**

Aspose.Slides per Node.js via Java fornisce un'API semplice per impostare i colori automatici delle fette del grafico a torta. Il codice di esempio applica l'impostazione delle suddette proprietà.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Accedi alla prima diapositiva.
3. Aggiungi un grafico con i dati predefiniti.
4. Imposta il titolo del grafico.
5. Imposta la prima serie per mostrare i valori.
6. Imposta l'indice del foglio dati del grafico.
7. Recupera il foglio di lavoro dei dati del grafico.
8. Elimina le serie e le categorie generate automaticamente.
9. Aggiungi nuove categorie.
10. Aggiungi nuove serie.

Scrivi la presentazione modificata in un file PPTX.

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Aggiungi un grafico con dati predefiniti
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Impostazione del titolo del grafico
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Imposta la prima serie per mostrare i valori
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Impostazione dell'indice del foglio dati del grafico
    var defaultWorksheetIndex = 0;
    // Ottenimento del foglio di lavoro dei dati del grafico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Elimina le serie e le categorie generate di default
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Aggiunta di nuove categorie
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Aggiunta di una nuova serie
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Ora popolamento dei dati della serie
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Le varianti 'Pie of Pie' e 'Bar of Pie' sono supportate?**

Sì, la libreria [supporta](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/) un tracciato secondario per i grafici a torta, comprese le tipologie 'Pie of Pie' e 'Bar of Pie'.

**Posso esportare solo il grafico come immagine (ad esempio, PNG)?**

Sì, puoi [esportare il grafico stesso come immagine](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getImage) (ad esempio PNG) senza l'intera presentazione.