---
title: Personalizza i punti dati nei grafici Treemap e Sunburst con JavaScript
linktitle: Punti dati nei grafici Treemap e Sunburst
type: docs
url: /it/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- grafico treemap
- grafico sunburst
- grafico gerarchico
- punto dati
- etichetta dati
- colore ramo
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come creare dati gerarchici e personalizzare livelli, etichette e colori nei grafici Treemap e Sunburst con Aspose.Slides per Node.js via Java."
---
## **Panoramica**

I grafici Treemap e Sunburst visualizzano lo stesso tipo di dati gerarchici, ma utilizzano layout diversi. Un Treemap disegna la gerarchia come rettangoli annidati le cui aree rappresentano i valori delle foglie. Un Sunburst la rappresenta con anelli concentrici: i gruppi di primo livello sono vicini al centro e le categorie foglia si trovano sull’anello esterno.

In Aspose.Slides per Node.js via Java, ogni valore numerico è un [ChartDataPoint](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapoint/). Il suo metodo [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) fornisce l’accesso alla foglia e ai gruppi genitori. Questo articolo spiega tale mappatura e mostra come creare e formattare entrambi i tipi di grafico a partire dagli stessi dati di esempio.

![Un grafico Treemap con rami Consumer e Business](treemap-hierarchy.png)

![Un grafico Sunburst con la stessa gerarchia Consumer e Business](sunburst-hierarchy.png)

## **Comprendere Categorie, Punti Dati e Livelli**

L’esempio usato di seguito ha tre livelli di categoria e una serie numerica:

| Ramo | Stelo | Foglia | Ricavi |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Ogni riga crea una categoria foglia e un punto dati. I livelli di raggruppamento delle categorie descrivono il percorso da quella foglia ai suoi genitori. Per la prima riga, il percorso è `Consumer > Computers > Laptops`.

Gli indici restituiti da [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) partono dalla foglia verso l’alto:

| indice `getDataPointLevels()` | Livello logico | Rappresentazione Treemap | Rappresentazione Sunburst |
| ---: | --- | --- | --- |
| `0` | Foglia | Rettangolo valore | Segmento anello esterno |
| `1` | Stelo | Rettangolo genitore o intestazione | Segmento anello medio |
| `2` | Ramo | Rettangolo di primo livello o intestazione | Segmento anello interno |

Quest’ordine è lo stesso per entrambi i tipi di grafico anche se i loro layout visivi differiscono. Un segmento genitore è condiviso da più foglie. Per formattarlo, usa il livello corrispondente del primo punto dati nel gruppo. Per esempio, il ramo `Consumer` inizia con il punto `Laptops`, mentre lo stelo `Software` inizia con il punto `Licenses`. Tenere riferimenti a quei punti è più chiaro e sicuro rispetto a usare espressioni non spiegate come `dataPoints.get_Item(0)` o `dataPoints.get_Item(6)`.

## **Creare e Personalizzare Entrambi i Tipi di Grafico**

Il seguente esempio completo crea un Treemap nella prima diapositiva e un Sunburst nella seconda diapositiva. Costruisce la gerarchia, visualizza il valore per `Tablets`, applica colori fissi a livelli selezionati, formatta un’etichetta di ramo e salva la presentazione.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Aggiungi le categorie foglia. Un elemento di raggruppamento viene impostato solo quando inizia un nuovo gruppo;
        // le categorie successive rimangono in quel gruppo fino a quando non viene impostato un altro elemento.
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // Mostra la categoria e il valore sulla foglia Tablets.
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Formatta il ramo Consumer tramite la prima foglia di quel ramo.
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // Formatta lo stelo Software tramite la prima foglia di quello stelo.
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout influisce sulle etichette genitore del Treemap; Sunburst utilizza segmenti di anello.
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le celle di categoria e le celle di valore usano la stessa riga del foglio di lavoro, quindi le loro posizioni di raccolta rimangono allineate. Quando lavori con un grafico esistente anziché crearne uno, ispeziona prima le righe di categoria e memorizza riferimenti nominati ai punti dati e ai livelli che intendi formattare.

## **Comportamento e Considerazioni Pratiche**

### **Differenze tra Treemap e Sunburst**

- Un Treemap usa l’area per comunicare il valore e rettangoli annidati per comunicare la gerarchia. Il metodo [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) controlla come le etichette dei genitori appaiono in questo tipo di grafico.
- Un Sunburst usa l’angolo per comunicare il valore e la profondità dell’anello per comunicare la gerarchia. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) non controlla le etichette degli anelli.
- Entrambi i tipi di grafico usano gli stessi livelli di raggruppamento delle categorie e lo stesso ordine foglia‑genitore restituito da [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels), quindi il codice di costruzione dei dati e di formattazione dei livelli può essere condiviso.
- I valori dei genitori sono calcolati dalle foglie discendenti. Non aggiungere punti numerici separati per rami o steli.

### **Ordinamento e Ordine dei Segmenti**

Il motore di layout del grafico determina il posizionamento finale di rettangoli e segmenti di anello. Raggruppa le righe di categoria correlate prima di aggiungerle, ma non fare affidamento su una posizione di rettangolo o su un angolo di partenza specifici. Se la sequenza ha significato, includila nelle etichette o usa un tipo di grafico con un asse di categoria esplicito.

### **Tema e Colori Fissi**

I livelli di grafico non formattati ereditano i colori dal tema della presentazione. L’esempio usa riempimenti RGB espliciti per un output prevedibile. Se il grafico deve seguire le modifiche del tema, utilizza colori di schema invece di valori RGB fissi e evita di sovrascrivere ogni livello. Controlla anche il contrasto dell’etichetta dopo aver cambiato il riempimento di un ramo o di uno stelo.

### **Etichette e Spazio Disponibile**

PowerPoint può nascondere o troncare le etichette quando un segmento è troppo piccolo. Aumentare le dimensioni del grafico, abbreviare i nomi delle categorie o mostrare meno campi di etichetta solitamente produce un risultato più chiaro. Un’etichetta può combinare nome della categoria, nome della serie e valore tramite [DataLabelFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/datalabelformat/), ma abilitare tutti i campi spesso rende difficile la lettura dei grafici gerarchici.

### **Esportazione e Rendering**

Salvare in PPTX mantiene il grafico modificabile. Quando Aspose.Slides rende la presentazione in PDF o immagine, i riempimenti e le impostazioni di etichetta supportati vengono renderizzati con il grafico. La sostituzione dei font e piccole differenze nello spazio di layout disponibile possono cambiare l’interlinea o la visibilità delle etichette, quindi installa i font richiesti e verifica i target di esportazione più importanti.

## **FAQ**

**Perché la modifica di un livello genitore influisce su più foglie?**

Un ramo o uno stelo è un segmento visivo condiviso. Il suo [ChartDataPointLevel](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatapointlevel/) è accessibile attraverso una foglia discendente, ma la formattazione appartiene al segmento genitore condiviso, non solo a quella foglia.

**Perché manca un’etichetta dati?**

Prima abilita i campi richiesti sull’oggetto [DataLabelFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/datalabelformat/) dell’etichetta. Poi verifica che il segmento abbia spazio sufficiente. Il layout delle etichette genitore del Treemap, le dimensioni del grafico, la lunghezza dell’etichetta, la dimensione del font e il numero di campi abilitati influiscono sulla visualizzazione dell’etichetta.

**Posso impostare l’ordine preciso o le coordinate dei segmenti?**

Puoi controllare l’ordine delle righe di origine e mantenere ogni gruppo contiguo, ma non puoi assegnare rettangoli Treemap o angoli Sunburst esatti. Il motore di layout calcola questi elementi dalla gerarchia, dai valori e dallo spazio disponibile.

**Perché i colori cambiano dopo la modifica del tema della presentazione?**

I riempimenti basati sul tema sono progettati per seguire la tavolozza della presentazione. Applica colori RGB espliciti ai livelli che devono rimanere fissi, oppure conserva i colori di schema quando è preferibile adattarsi a un nuovo tema.

**La formattazione personalizzata verrà preservata nelle esportazioni PDF e immagine?**

Sì, i riempimenti di grafico e le impostazioni di etichetta supportati vengono inclusi durante il rendering. Per risultati coerenti su diversi sistemi, rendi disponibili i font richiesti e verifica le dimensioni finali dell’esportazione, poiché l’adattamento delle etichette dipende dal layout.

## **Vedi anche**

- [Create Treemap charts](/slides/it/nodejs-java/create-chart/#creating-tree-map-charts)
- [Create Sunburst charts](/slides/it/nodejs-java/create-chart/#creating-sunburst-charts)
- [Export presentation charts](/slides/it/nodejs-java/export-chart/)
- [Manage presentation themes](/slides/it/nodejs-java/presentation-theme/)