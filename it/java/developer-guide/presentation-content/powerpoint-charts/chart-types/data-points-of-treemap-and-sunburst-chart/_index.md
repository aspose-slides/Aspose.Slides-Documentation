---
title: Personalizza i punti dati nei grafici Treemap e Sunburst in Java
linktitle: Punti dati nei grafici Treemap e Sunburst
type: docs
url: /it/java/data-points-of-treemap-and-sunburst-chart/
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
- Java
- Aspose.Slides
description: "Scopri come creare dati gerarchici e personalizzare livelli, etichette e colori nei grafici Treemap e Sunburst con Aspose.Slides per Java."
---
## **Panoramica**

I grafici Treemap e Sunburst visualizzano lo stesso tipo di dati gerarchici, ma utilizzano layout diversi. Una Treemap rappresenta la gerarchia con rettangoli nidificati le cui aree corrispondono ai valori delle foglie. Una Sunburst la rappresenta con anelli concentrici: i gruppi di primo livello sono vicini al centro e le categorie foglia si trovano sull’anello esterno.

In Aspose.Slides for Java, ogni valore numerico è un [IChartDataPoint](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdatapoint/). Il suo metodo [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) fornisce l’accesso alla foglia e ai gruppi genitori. Questo articolo spiega tale mappatura e mostra come creare e formattare entrambi i tipi di grafico a partire dagli stessi dati di esempio.

![Un grafico Treemap con rami Consumer e Business](treemap-hierarchy.png)

![Un grafico Sunburst con la stessa gerarchia Consumer e Business](sunburst-hierarchy.png)

## **Comprendere categorie, punti dati e livelli**

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

Ogni riga crea una categoria foglia e un punto dati. I livelli di raggruppamento descrivono il percorso da quella foglia ai suoi genitori. Per la prima riga, il percorso è `Consumer > Computers > Laptops`.

Gli indici restituiti da [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) partono dalla foglia verso l’alto:

| Indice `getDataPointLevels()` | Livello logico | Rappresentazione Treemap | Rappresentazione Sunburst |
| ---: | --- | --- | --- |
| `0` | Foglia | Rettangolo valore | Segmento anello esterno |
| `1` | Stelo | Rettangolo genitore o intestazione | Segmento anello intermedio |
| `2` | Ramo | Rettangolo livello superiore o intestazione | Segmento anello interno |

Questo ordine è lo stesso per entrambi i tipi di grafico, anche se i loro layout visuali differiscono. Un segmento genitore è condiviso da più foglie. Per formattarlo, utilizza il livello corrispondente del primo punto dati del gruppo. Per esempio, il ramo `Consumer` inizia con il punto `Laptops`, mentre lo stelo `Software` inizia con il punto `Licenses`. Tenere riferimenti a tali punti è più chiaro e sicuro rispetto all’uso di espressioni non spiegate come `dataPoints.get_Item(0)` o `dataPoints.get_Item(6)`.

## **Creare e personalizzare entrambi i tipi di grafico**

Il seguente esempio completo crea una Treemap nella prima diapositiva e una Sunburst nella seconda diapositiva. Costruisce la gerarchia, visualizza il valore per `Tablets`, applica colori fissi ai livelli selezionati, formatta un’etichetta di ramo e salva la presentazione.

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Aggiungi le categorie foglia. Un elemento di raggruppamento viene impostato solo quando inizia un nuovo gruppo;
        // le categorie successive rimangono in quel gruppo finché non viene impostato un altro elemento.
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // Mostra la categoria e il valore sulla foglia Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Formatta il ramo Consumer tramite la prima foglia di quel ramo.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        Color consumerBranchColor = new Color(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Formatta lo stelo Software tramite la prima foglia di quello stelo.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        Color softwareStemColor = new Color(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout influisce sulle etichette genitore della Treemap; Sunburst utilizza segmenti di anello.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le celle di categoria e le celle di valore utilizzano la stessa riga del foglio di lavoro, quindi le loro posizioni nella collezione rimangono allineate. Quando lavori con un grafico esistente anziché crearne uno nuovo, ispeziona prima le righe di categoria e memorizza riferimenti nominati ai punti dati e ai livelli che intendi formattare.

## **Comportamento e considerazioni pratiche**

### **Differenze tra Treemap e Sunburst**

- Una Treemap utilizza l’area per comunicare il valore e rettangoli nidificati per comunicare la gerarchia. Il metodo [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) controlla come appaiono le etichette dei genitori in questo tipo di grafico.
- Una Sunburst utilizza l’angolo per comunicare il valore e la profondità dell’anello per comunicare la gerarchia. [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) non controlla le etichette degli anelli.
- Entrambi i tipi di grafico usano gli stessi livelli di raggruppamento e lo stesso ordine foglia‑genitore restituito da [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--), quindi il codice di costruzione dei dati e di formattazione dei livelli può essere condiviso.
- I valori dei genitori sono calcolati dalle foglie discendenti. Non aggiungere punti numerici separati per rami o steli.

### **Ordinamento e ordine dei segmenti**

Il motore di layout del grafico determina il posizionamento finale di rettangoli e segmenti d’anello. Raggruppa le righe di categoria correlate prima di aggiungerle, ma non fare affidamento su una posizione di rettangolo o su un angolo di partenza specifici. Se la sequenza ha un significato, includila nelle etichette o utilizza un tipo di grafico con asse di categoria esplicito.

### **Tema e colori fissi**

I livelli di grafico non formattati ereditano i colori dal tema della presentazione. L’esempio utilizza riempimenti RGB espliciti per un output prevedibile. Se il grafico deve seguire le modifiche del tema, usa i colori dello schema anziché valori RGB fissi e evita di sovrascrivere ogni livello. Controlla anche il contrasto dell’etichetta dopo aver cambiato il riempimento di un ramo o di uno stelo.

### **Etichette e spazio disponibile**

PowerPoint può nascondere o troncate le etichette quando un segmento è troppo piccolo. Aumentare le dimensioni del grafico, abbreviare i nomi delle categorie o visualizzare meno campi etichetta di solito produce un risultato più chiaro. Un’etichetta può combinare il nome della categoria, il nome della serie e il valore tramite [IDataLabelFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/idatalabelformat/), ma abilitare tutti i campi rende spesso i grafici gerarchici difficili da leggere.

### **Esportazione e rendering**

Salvare in PPTX mantiene il grafico modificabile. Quando Aspose.Slides rende la presentazione in PDF o immagine, i riempimenti e le impostazioni delle etichette supportati vengono renderizzati con il grafico. La sostituzione dei caratteri e le piccole differenze nello spazio di layout disponibile possono modificare la formattazione del testo o la visibilità delle etichette, quindi installa i caratteri richiesti e verifica i target di esportazione più importanti.

## **FAQ**

**Perché la modifica di un livello genitore influisce su più foglie?**

Un ramo o uno stelo è un segmento visivo condiviso. Il suo [IChartDataPointLevel](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdatapointlevel/) è accessibile tramite una foglia discendente, ma la formattazione appartiene al segmento genitore condiviso, non solo a quella foglia.

**Perché manca un’etichetta dati?**

Prima abilita i campi richiesti sull’oggetto [IDataLabelFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/idatalabelformat/) dell’etichetta. Poi verifica che il segmento abbia spazio sufficiente. Il layout delle etichette dei genitori nella Treemap, le dimensioni del grafico, la lunghezza dell’etichetta, la dimensione del carattere e il numero di campi abilitati influiscono tutti sulla visualizzazione dell’etichetta.

**Posso impostare l’ordine esatto o le coordinate dei segmenti?**

Puoi controllare l’ordine delle righe di origine e mantenere ogni gruppo contiguo, ma non puoi assegnare rettangoli Treemap o angoli Sunburst precisi. Il motore di layout calcola tali valori dalla gerarchia, dai valori e dallo spazio disponibile.

**Perché i colori cambiano dopo la modifica del tema della presentazione?**

I riempimenti basati sul tema sono progettati per seguire la palette della presentazione. Applica colori RGB espliciti ai livelli che devono rimanere fissi, oppure mantieni i colori dello schema quando è preferibile adattarsi a un nuovo tema.

**La formattazione personalizzata verrà preservata in PDF e esportazioni immagine?**

Sì, i riempimenti e le impostazioni delle etichette supportati sono inclusi durante il rendering. Per risultati coerenti su tutti i sistemi, rendi disponibili i caratteri richiesti e testa la dimensione finale dell’esportazione, poiché l’adattamento delle etichette dipende dal layout.

## **Vedi anche**

- [Create Treemap charts](/slides/it/java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/it/java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/it/java/export-chart/)
- [Manage presentation themes](/slides/it/java/presentation-theme/)