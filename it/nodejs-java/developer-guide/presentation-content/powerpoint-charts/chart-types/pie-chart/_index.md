---
title: Personalizza i grafici a torta nelle presentazioni con JavaScript
linktitle: Grafico a torta
type: docs
url: /it/nodejs-java/pie-chart/
keywords:
- grafico a torta
- gestione grafico
- personalizzazione grafico
- opzioni grafico
- impostazioni grafico
- opzioni tracciato
- colore fetta
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea e personalizza grafici a torta in JavaScript con Aspose.Slides per Node.js via Java. Configura tracciati secondari, visualizza etichette dei dati e applica colori automatici alle fette in PowerPoint."
---
## **Panoramica**

Questo articolo spiega come lavorare con i grafici a torta in Aspose.Slides. Mostra come configurare le opzioni di tracciato secondario per i grafici Pie of Pie e Bar of Pie, e come abilitare la colorazione automatica delle fette per un grafico a torta standard.

Gli esempi si concentrano su attività di personalizzazione dei grafici, come aggiungere un grafico a una diapositiva, regolare le impostazioni delle serie e delle etichette, sostituire i dati di default del grafico con categorie e valori personalizzati, e salvare la presentazione aggiornata.

## **Opzioni del Tracciato Secondario per i Grafici Pie of Pie e Bar of Pie**

Aspose.Slides per Node.js via Java supporta le opzioni di tracciato secondario per i grafici Pie of Pie e Bar of Pie. Queste opzioni controllano la dimensione del tracciato secondario e come i punti dati vengono suddivisi tra i due tracciati.

Il seguente esempio crea un grafico Pie of Pie in una nuova presentazione e visualizza i valori dei punti dati come etichette. Il metodo [setSecondPieSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setSecondPieSize) imposta la dimensione del tracciato secondario al 149% del tracciato principale. [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) seleziona la suddivisione basata sulla percentuale, e [setPieSplitPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) imposta la soglia al 53%.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    const series = chart.getChartData().getSeries().get_Item(0);

    // Visualizza i valori e configura il tracciato secondario.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Selezionare le Categorie per il Tracciato Secondario**

Utilizza la suddivisione personalizzata quando desideri raggruppare categorie specifiche nel tracciato secondario indipendentemente dai loro valori percentuali. Per esempio, un rapporto di vendite potrebbe mostrare Online ed Eventi insieme così i lettori possono confrontare questi due canali, anche se rappresentano il 35% e il 10% delle vendite totali.

Chiama [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) con [PieSplitType.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplittype/#Custom) e seleziona i punti tramite [getPieSplitCustomPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Il metodo [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#add) della collezione accetta un indice basato su zero nella serie; usa [addItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#addItem) per aggiungere un oggetto punto dati. In questo esempio, l'indice 1 seleziona Online, e il punto all'indice 3 seleziona Eventi. Partners viene anche aggiunto temporaneamente, poi escluso usando [removeItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 200);

    // Sostituisci i dati predefiniti con le vendite per canale.
    const workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    const values = [ 40, 35, 15, 10 ];
    const seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Seleziona Online in base al suo indice zero-based e Events tramite il suo oggetto punto dati.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Escludi Partners dalla selezione senza eliminare i dati di origine.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) ed Eventi (10) compaiono come fette separate nel tracciato secondario. Nel tracciato principale, sono rappresentati da una singola fetta combinata con valore 45, insieme a Retail (40) e Partners (15). Rimuovere Partners dalla selezione personalizzata lo mantiene nel tracciato principale; non rimuove la categoria o il suo valore dai dati di origine del grafico.

L'immagine seguente mostra la presentazione salvata in PowerPoint:

![Grafico Pie of Pie con Online ed Eventi nel tracciato secondario e il loro valore combinato di 45 nel tracciato principale](pie_of_pie_custom.png)

## **Impostare i Colori Automatici delle Fette del Grafico a Torta**

Aspose.Slides per Node.js via Java può assegnare automaticamente colori diversi alle fette del grafico a torta. Il seguente esempio crea un grafico a torta con un titolo centrato e sostituisce i dati di default con tre categorie trimestrali e i loro valori. Il metodo [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) visualizza i valori 20, 50 e 30 come etichette, mentre [setColorVaried](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setColorVaried) abilita un colore distinto per ogni fetta.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);

    // Aggiungi un titolo del grafico centrato.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Sostituisci i dati predefiniti usando il primo foglio di lavoro.
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    const values = [ 20, 50, 30 ];
    const seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Mostra i valori e assegna colori diversi alle fette.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Le varianti Pie of Pie e Bar of Pie sono supportate?**

Sì, la libreria [supporta](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) un tracciato secondario per i grafici a torta, inclusi i tipi Pie of Pie e Bar of Pie.

**Posso esportare solo il grafico come immagine (ad esempio, PNG)?**

Sì, è possibile [esportare il grafico stesso come immagine](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (ad esempio PNG) senza esportare l'intera presentazione.