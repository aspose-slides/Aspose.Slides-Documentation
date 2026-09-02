---
title: Gestire le Serie di Dati dei Grafici nelle Presentazioni Utilizzando JavaScript
linktitle: Serie di Dati
type: docs
url: /it/nodejs-java/chart-series/
keywords:
- serie di grafico
- sovrapposizione della serie
- colore della serie
- nome della serie
- punto dati
- cella della cartella di lavoro
- intervallo della serie
- valore negativo
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come gestire le serie di grafico, i punti dati, le celle della cartella di lavoro, la formattazione, la sovrapposizione, la larghezza dello spazio e i valori negativi nelle presentazioni con JavaScript."
---
## **Panoramica**

Un grafico memorizza i dati tracciati in una cartella di lavoro dei dati del grafico. Un [ChartSeries](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/) rappresenta un insieme di valori correlati, e ogni [ChartDataPoint](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapoint/) nella serie si riferisce a una o più celle della cartella di lavoro. Gli oggetti [ChartCategory](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartcategory/) forniscono le etichette o i valori di raggruppamento condivisi dalla serie. Il nome della serie, le categorie e i valori dei punti sono quindi collegati a oggetti [ChartDataCell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatacell/) anziché essere memorizzati solo come testo visualizzato.

Per un grafico a categorie tipico, la cartella di lavoro predefinita utilizza la riga 0 per i nomi delle serie, la colonna 0 per i nomi delle categorie e le celle rimanenti per i valori delle serie. Gli indici di foglio, riga e colonna passati a [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdataworkbook/#getCell) sono basati su zero. Questo layout è utile quando si crea un grafico con dati predefiniti, ma non si deve presumere che tutti i grafici esistenti lo usino. Per una presentazione caricata, ispeziona le celle referenziate da serie, categorie e punti dati prima di modificare i valori della cartella di lavoro.

Le impostazioni del grafico hanno tre ambiti diversi:

- Impostazioni a livello di serie, come [ChartSeries.getFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#getFormat), forniscono l’aspetto predefinito per tutti i punti di una serie.
- Impostazioni a livello di punto dati, come [ChartDataPoint.getFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapoint/#getFormat), sovrascrivono l’aspetto della serie per un singolo punto.
- Impostazioni di gruppo si applicano a serie compatibili che appartengono allo stesso [ChartSeriesGroup](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseriesgroup/). Accedi al gruppo tramite [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) quando è necessario impostare opzioni come la sovrapposizione o la larghezza dello spazio.

Quando non è impostata una riempimento esplicito per punto o serie, lo stile del grafico e il tema determinano l’aspetto automatico. Quando sono presenti sia formattazioni di serie che di punto, la formattazione del punto ha la precedenza per quel punto.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Impostare la Sovrapposizione delle Serie del Grafico**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#getOverlap) indica quanto barre o colonne si sovrappongono in un grafico 2D, da -100 a 100 percento. È una proiezione in sola lettura dell’impostazione sul gruppo di serie padre. Usa [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) per aggiornare tutte le serie compatibili in quel gruppo. Questa opzione si applica ai tipi di grafico che visualizzano barre o colonne raggruppate; non influisce sui gruppi di serie non correlati in un grafico combinato.

L’esempio seguente imposta la sovrapposizione per il gruppo che contiene la prima serie:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Il nuovo grafico contiene serie, categorie e valori di esempio.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![The series overlap](series_overlap.png)

## **Modificare il Colore di Riempimento della Serie**

Usa [ChartSeries.getFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#getFormat) per impostare il riempimento predefinito per un’intera serie. Se un punto ha già un riempimento esplicito, la sua impostazione [ChartDataPoint.getFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapoint/#getFormat) sovrascrive il riempimento della serie per quel punto.

L’esempio seguente applica un riempimento solido blu alla prima serie:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![The color of the series](series_color.png)

## **Modificare il Nome della Serie**

Il nome di una serie è memorizzato nella cartella di lavoro dei dati del grafico e normalmente viene visualizzato nella legenda. Nella cartella di lavoro predefinita creata per un grafico a colonne raggruppate, la cella B1 si trova alla riga 0, colonna 1 e contiene il nome della prima serie. Le costanti nominate nell’esempio seguente rendono esplicita questa struttura:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Puoi anche aggiornare la cella già referenziata da [ChartSeries.getName](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#getName). Questo approccio evita di presumere una riga e colonna specifiche in un grafico esistente:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![The series name](series_name.png)

## **Ottenere il Colore di Riempimento Automatico della Serie**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) restituisce il colore calcolato in base all’indice della serie e allo stile del grafico. Questo è il colore usato quando il riempimento della serie non è stato definito esplicitamente. Chiamare il metodo legge il colore calcolato; non assegna un nuovo riempimento.

L’esempio seguente stampa il colore automatico di ciascuna serie predefinita:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

Output di esempio per lo stile di grafico predefinito:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

I colori esatti dipendono dallo stile e dal tema del grafico.

## **Impostare il Riempimento Invertito per una Serie del Grafico**

Per serie a barre, colonne e bolle, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) può visualizzare i valori negativi con un riempimento diverso. Imposta il riempimento regolare della serie su solido, abilita l’inversione e assegna il colore per i valori negativi tramite [ChartSeries.getInvertedSolidFillColor](httpshttps://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). I numeri negativi rimangono invariati nella cartella di lavoro; cambia solo il colore di visualizzazione.

L’esempio seguente sostituisce i dati del grafico predefiniti con una singola serie. La riga 0 del foglio contiene il nome della serie, la colonna 0 contiene i nomi delle categorie e la colonna 1 contiene i valori:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![The inverted solid fill color](inverted_solid_fill_color.png)

Puoi abilitare l’inversione per un singolo punto tramite [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Nell’esempio seguente l’inversione è disabilitata per la serie e abilitata solo per il punto selezionato. Al punto è anche assegnato un valore negativo affinché l’effetto sia visibile:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Cancellare il Valore di un Punto Dato Specifico**

Per rendere vuoto un punto senza rimuovere gli altri, imposta la cella di supporto nella cartella di lavoro a `null`. Per un grafico a colonne, il valore tracciato è disponibile tramite [ChartDataPoint.getValue](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapoint/#getValue). Il punto dati resta nella stessa posizione di categoria, ma il grafico tratta il suo valore come vuoto secondo le impostazioni di valori vuoti del grafico.

L’esempio seguente cancella solo il secondo punto nella prima serie:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

I grafici a dispersione usano celle X e Y separate, e i grafici a bolle usano anche una cella di dimensione. Cancella solo la cella che rappresenta il valore che intendi rimuovere. Non chiamare [ChartDataPointCollection.clear](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapointcollection/#clear) quando vuoi mantenere gli altri punti, poiché quel metodo rimuove tutti i punti dati dalla collezione.

## **Impostare la Larghezza dello Spazio Tra le Serie**

La larghezza dello spazio è lo spazio tra gruppi adiacenti di barre o colonne, espresso in percentuale della larghezza della barra o della colonna. Come la sovrapposizione, appartiene al gruppo di serie padre piuttosto che a una singola serie. Chiama [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) una volta per il gruppo. Un valore più grande crea più spazio tra i gruppi; un valore più piccolo li rende più densi.

L’esempio seguente modifica la larghezza dello spazio e salva solo la presentazione finale:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![The gap width](gap_width.png)

## **FAQ**

**Quali tipi di grafico supportano le serie di dati?**

Tutti i tipi di grafico rappresentati dall’enumerazione [ChartType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/) usano dati del grafico, ma le loro serie non hanno tutte la stessa struttura di valori o impostazioni. Ad esempio, i grafici a categorie usano categorie e valori, i grafici a dispersione usano valori X e Y, e i grafici a bolle aggiungono le dimensioni delle bolle. Usa il metodo di creazione del punto dati che corrisponde al tipo di serie. Opzioni come sovrapposizione e larghezza dello spazio si applicano solo a gruppi di barre o colonne compatibili.

**Che cos’è un gruppo di serie del grafico?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseriesgroup/) contiene serie compatibili che condividono impostazioni di tracciamento a livello di gruppo. Un grafico combinato può contenere più di un gruppo, quindi la modifica del gruppo raggiunta attraverso una serie non modifica necessariamente tutte le serie nel grafico.

**Un grafico appena creato contiene dati predefiniti?**

Sì. Per impostazione predefinita, [ShapeCollection.addChart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/#addChart) crea serie, categorie e valori di esempio. Puoi modificare quelle celle o cancellare sia le collezioni di serie sia di categorie prima di aggiungere un set di dati completamente personalizzato. Un overload può anche creare un grafico senza dati predefiniti.

**Come sono collegati gli oggetti del grafico alle celle della cartella di lavoro?**

I nomi delle serie, le etichette delle categorie e i valori dei punti dati referenziano celle in un [ChartDataWorkbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdataworkbook/). Modificare una cella referenziata aggiorna l’elemento corrispondente del grafico. Quando costruisci dati personalizzati, mantieni allineate le righe di categorie e le righe dei valori delle serie in modo che ogni punto sia tracciato nella categoria prevista.

**Come si cancella un punto invece dell’intera serie?**

Imposta la cella del valore pertinente a `null` per mantenere la posizione di categoria del punto come punto vuoto. Usa [ChartDataPointCollection.clear](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapointcollection/#clear) solo quando intendi rimuovere tutti i punti da quella serie. Se rimuovi anche le categorie, aggiorna ogni serie affinché i valori rimangano allineati con la collezione delle categorie.

**Come vengono visualizzati i punti vuoti?**

Il risultato dipende dal tipo di grafico e dal valore configurato tramite [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs). I grafici supportati possono visualizzare i vuoti come spazi, come valori zero o collegando i punti vicini. Scegli l’impostazione che corrisponde al significato dei dati mancanti nella tua presentazione.

**Come vengono formattati i valori negativi?**

Per le serie a barre, colonne e bolle supportate, chiama [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) e imposta il colore restituito da [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Puoi sovrascrivere il comportamento per un punto individuale con [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Questi metodi influenzano la formattazione, non i valori numerici memorizzati.

**Quale formattazione prevale quando sia una serie sia un punto sono formattati?**

La formattazione esplicita del punto dati ha la precedenza per quel punto. Gli altri punti continuano a utilizzare la formattazione esplicita della serie o, quando la formattazione della serie non è definita, lo stile e il tema automatici del grafico. Le impostazioni di gruppo come sovrapposizione e larghezza dello spazio controllano il layout e non sono sovrascritture di formattazione a livello di punto.

**Esiste un limite al numero di serie che un grafico può contenere?**

Aspose.Slides non impone un limite fisso separato per il numero di serie. In pratica, i vincoli del file di presentazione, la memoria disponibile, il tempo di rendering e la leggibilità del grafico determinano un limite pratico.

**Cosa devo modificare quando le colonne sono troppo vicine o troppo distanti?**

Chiama [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) sul gruppo di serie padre appropriato. Aumenta il valore per ampliare lo spazio tra i gruppi o diminuiscilo per avvicinare i gruppi.