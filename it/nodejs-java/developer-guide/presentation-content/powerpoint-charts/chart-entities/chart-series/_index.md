---
title: Gestire le serie di dati del grafico nelle presentazioni con JavaScript
linktitle: Serie di dati
type: docs
url: /it/nodejs-java/chart-series/
keywords:
- serie di grafico
- sovrapposizione serie
- colore serie
- nome serie
- punto dati
- cella cartella di lavoro
- spazio serie
- valore negativo
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come gestire le serie di grafico, i punti dati, le celle della cartella di lavoro, la formattazione, la sovrapposizione, la larghezza del gap e i valori negativi nelle presentazioni con JavaScript."
---
## **Panoramica**

Un grafico conserva i suoi dati tracciati in una cartella di lavoro dei dati del grafico. Un [ChartSeries](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/) rappresenta un insieme di valori correlati, e ogni [ChartDataPoint](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapoint/) nella serie fa riferimento a una o più celle della cartella di lavoro. Gli oggetti [ChartCategory](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartcategory/) forniscono le etichette o i valori di raggruppamento condivisi dalle serie. Il nome della serie, le categorie e i valori dei punti sono quindi collegati a oggetti [ChartDataCell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatacell/) anziché essere memorizzati solo come testo visualizzato.

Per un tipico grafico a categorie, la cartella di lavoro predefinita utilizza la riga 0 per i nomi delle serie, la colonna 0 per i nomi delle categorie e le celle rimanenti per i valori delle serie. Gli indici di foglio, riga e colonna passati a [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdataworkbook/#getCell) sono basati su zero. Questa disposizione è utile quando si crea un grafico con dati predefiniti, ma non si deve presumere che tutti i grafici esistenti la utilizzino. Per una presentazione caricata, ispezionare le celle a cui fanno riferimento le serie, le categorie e i punti dati prima di modificare i valori della cartella di lavoro.

Le impostazioni del grafico hanno tre ambiti diversi:

- Impostazioni a livello di serie, come [ChartSeries.getFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#getFormat), forniscono l’aspetto predefinito per tutti i punti di una serie.  
- Impostazioni dei punti dati, come [ChartDataPoint.getFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapoint/#getFormat), sovrascrivono l’aspetto della serie per un singolo punto.  
- Le impostazioni di gruppo si applicano a serie compatibili che appartengono allo stesso [ChartSeriesGroup](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseriesgroup/). Accedere al gruppo tramite [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) quando è necessario impostare opzioni come sovrapposizione o larghezza del gap.

Quando non è impostata alcuna riempimento esplicito di punto o di serie, lo stile e il tema del grafico determinano l’aspetto automatico. Quando sono presenti sia la formattazione della serie sia quella del punto, quella del punto ha la precedenza per quel punto.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Imposta la sovrapposizione della serie del grafico**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#getOverlap) indica quanto le barre o le colonne si sovrappongono in un grafico 2D, da -100 a 100 percento. È una proiezione di sola lettura dell’impostazione sul gruppo di serie padre. Utilizzare [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) per aggiornare tutte le serie compatibili in quel gruppo. Questa opzione si applica ai tipi di grafico che visualizzano barre o colonne raggruppate; non influisce sui gruppi di serie non correlati in un grafico combinato.

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

    // Il nuovo grafico contiene serie di esempio, categorie e valori.
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

## **Modifica il colore di riempimento della serie**

Utilizzare [ChartSeries.getFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#getFormat) per impostare il riempimento predefinito per un’intera serie. Se un punto ha già un riempimento esplicito, la sua impostazione [ChartDataPoint.getFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapoint/#getFormat) sovrascrive il riempimento della serie per quel punto.

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

## **Modifica il nome della serie**

Un nome di serie è memorizzato nella cartella di lavoro dei dati del grafico ed è normalmente visualizzato nella legenda. Nella cartella di lavoro predefinita creata per un grafico a colonne raggruppate, la cella B1 si trova alla riga 0, colonna 1 e contiene il nome della prima serie. Le costanti nominate nell’esempio seguente rendono esplicita tale struttura:

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

È anche possibile aggiornare la cella già referenziata da [ChartSeries.getName](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#getName). Questo approccio evita di assumere una specifica riga o colonna in un grafico esistente:

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

## **Ottieni il colore di riempimento automatico della serie**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) restituisce il colore calcolato in base all’indice della serie e allo stile del grafico. È il colore usato quando il riempimento della serie non è stato definito esplicitamente. Chiamare il metodo legge il colore calcolato; non assegna un nuovo riempimento.

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

## **Imposta il colore di riempimento invertito per una serie del grafico**

Per serie a barre, colonne e bolle, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) può visualizzare i valori negativi con un riempimento diverso. Impostare il riempimento regolare della serie su solido, abilitare l’inversione e assegnare il colore per i valori negativi tramite [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). I numeri negativi rimangono invariati nella cartella di lavoro; cambia solo il colore di visualizzazione.

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

È possibile abilitare l’inversione per un singolo punto tramite [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Nell’esempio seguente l’inversione è disabilitata per la serie e abilitata solo per il punto selezionato. Il punto è anche impostato a un valore negativo affinché l’effetto sia visibile:

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

## **Cancella il valore di un punto dati specifico**

Per rendere vuoto un punto senza rimuovere gli altri, impostare la sua cella di supporto nella cartella di lavoro su `null`. Per un grafico a colonne, il valore tracciato è disponibile tramite [ChartDataPoint.getValue](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapoint/#getValue). Il punto dati rimane nella stessa posizione di categoria, ma il grafico lo tratta come vuoto in base alle impostazioni dei valori vuoti del grafico.

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

I grafici a dispersione usano celle X e Y separate, e i grafici a bolle usano anche una cella di dimensione. Cancella solo la cella che rappresenta il valore che intendi rimuovere. Non chiamare [ChartDataPointCollection.clear](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapointcollection/#clear) quando vuoi mantenere gli altri punti, perché quel metodo rimuove tutti i punti dati dalla raccolta.

## **Controlla la visualizzazione delle celle vuote**

Le celle nascoste che contengono valori costituiscono un caso diverso dalle celle vuote. Per includere o escludere dati da righe e colonne del foglio nascoste, vedere [Include Data from Hidden Rows and Columns](/slides/it/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Una cella vuota della cartella di lavoro rappresenta dati mancanti; una cella contenente `0` rappresenta un valore numerico noto. Chiamare [ChartDataCell.setValue](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatacell/#setValue) con `null` rende la cella vuota. Uno zero numerico resta zero indipendentemente dall’impostazione delle celle vuote.

Usare [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) per scegliere come il grafico visualizza le celle vuote. Questa impostazione si applica all’intero grafico. Modifica il modo in cui i vuoti sono tracciati, senza riempire la cella vuota con zero o un valore interpolato.

L’esempio autoconclusivo seguente crea un grafico a linee con una serie, cancella il valore per il giorno 3 e salva lo stesso grafico con ciascuna modalità. Non è necessario alcun file di input. Il [ChartDataWorkbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdataworkbook/) usa il foglio 0, la colonna 0 per le etichette delle categorie e la colonna 1 per i valori; la riga 0 contiene il nome della serie. I dati finali sono `10, 20, empty, 30, 40`.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Lascia il giorno 3 realmente vuoto, mantenendo la sua categoria e il punto dati.
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Ogni file di output memorizza la modalità assegnata prima del salvataggio: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` e `empty_cells_Span.pptx`. Per salvare una sola versione, impostare la modalità desiderata e salvare la presentazione una sola volta invece di iterare sulle modalità.

Il confronto sotto mostra gli stessi dati nei tre file. Il giorno 3 è vuoto nella cartella di lavoro in tutti i casi:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

L’effetto visibile dipende dal tipo di grafico. Un grafico a linee rende facili a confrontare tutte e tre le modalità. I grafici a barre e colonne non hanno una linea da collegare attraverso una categoria mancante, quindi `Span` non può produrre il segmento di collegamento mostrato sopra; una colonna mancante e una colonna di altezza zero possono anche apparire simili. Allo stesso modo, un grafico a dispersione con soli marker non ha linea di collegamento. Non ci si deve aspettare tre risultati distinti per ogni tipo di grafico; verificare l’output per il tipo che si utilizza.

## **Imposta la larghezza del gap della serie**

La larghezza del gap è lo spazio tra cluster di barre o colonne adiacenti, espresso in percentuale della larghezza della barra o della colonna. Come la sovrapposizione, appartiene al gruppo di serie padre anziché a una singola serie. Chiamare [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) una volta per il gruppo. Un valore più grande crea più spazio tra i cluster; un valore più piccolo li rende più densi.

L’esempio seguente modifica la larghezza del gap e salva solo la presentazione finale:

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

Tutti i tipi di grafico rappresentati dall’enumerazione [ChartType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/) utilizzano dati del grafico, ma le loro serie non hanno tutte la stessa struttura di valore o le stesse impostazioni. Ad esempio, i grafici a categorie usano categorie e valori, i grafici a dispersione usano valori X e Y, e i grafici a bolle aggiungono le dimensioni delle bolle. Utilizzare il metodo di creazione del punto dati che corrisponde al tipo di serie. Opzioni come sovrapposizione e larghezza del gap si applicano solo a gruppi di barre o colonne compatibili.

**Che cos’è un gruppo di serie del grafico?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseriesgroup/) contiene serie compatibili che condividono impostazioni di tracciamento a livello di gruppo. Un grafico combinato può contenere più di un gruppo, quindi modificare il gruppo raggiunto tramite una serie non cambia necessariamente tutte le serie nel grafico.

**Un grafico appena creato contiene dati predefiniti?**

Sì. Per impostazione predefinita, [ShapeCollection.addChart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/#addChart) crea serie, categorie e valori di esempio. È possibile modificare quelle celle o cancellare sia le collezioni di serie che di categorie prima di aggiungere un set di dati completamente personalizzato. Un overload può anche creare un grafico senza dati predefiniti.

**Come sono collegati gli oggetti del grafico alle celle della cartella di lavoro?**

Nomi delle serie, etichette delle categorie e valori dei punti dati fanno riferimento a celle in un [ChartDataWorkbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdataworkbook/). Modificare una cella referenziata aggiorna l’elemento corrispondente del grafico. Quando si costruiscono dati personalizzati, mantenere allineate le righe delle categorie e le righe dei valori delle serie affinché ogni punto sia tracciato sotto la categoria prevista.

**Come posso cancellare un punto anziché l’intera serie?**

Impostare la cella del valore pertinente su `null` per mantenere la posizione di categoria del punto come punto vuoto. Utilizzare [ChartDataPointCollection.clear](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapointcollection/#clear) solo quando si intende rimuovere tutti i punti da quella serie. Se si rimuovono anche le categorie, aggiornare ogni serie in modo che i valori rimangano allineati con la collezione delle categorie.

**Come vengono visualizzati i punti vuoti?**

Il risultato dipende dal tipo di grafico e dal valore configurato tramite [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs). I grafici supportati possono visualizzare i vuoti come spazi, come valori zero o collegando i punti vicini. Scegliere l’impostazione che corrisponde al significato dei dati mancanti nella presentazione. Vedere [Controlla la visualizzazione delle celle vuote](#control-the-display-of-empty-cells) per un esempio completo e un confronto visivo.

**Come vengono formattati i valori negativi?**

Per le serie a barre, colonne e bolle supportate, chiamare [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) e impostare il colore restituito da [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). È possibile sovrascrivere il comportamento per un punto individuale con [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Questi metodi influenzano la formattazione, non i valori numerici memorizzati.

**Quale formattazione prevale quando sia la serie che il punto sono formattati?**

La formattazione esplicita del punto dati ha la precedenza per quel punto. Gli altri punti continuano a utilizzare la formattazione esplicita della serie o, se la formattazione della serie non è definita, lo stile e il tema automatici del grafico. Le impostazioni di gruppo come sovrapposizione e larghezza del gap controllano il layout e non sono sovrascritture di formattazione a livello di punto.

**Esiste un limite al numero di serie che un grafico può contenere?**

Aspose.Slides non impone un limite fisso separato al numero di serie. In pratica, le restrizioni del file di presentazione, la memoria disponibile, i tempi di rendering e la leggibilità del grafico determinano un limite pratico.

**Cosa devo modificare quando le colonne sono troppo vicine o troppo distanti?**

Chiamare [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) sul gruppo di serie padre appropriato. Aumentare il valore per ampliare lo spazio tra i cluster, o diminuirlo per avvicinare i cluster.