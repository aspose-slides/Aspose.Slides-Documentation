---
title: Personalizza i punti dati nei grafici Treemap e Sunburst in PHP
linktitle: Punti dati nei grafici Treemap e Sunburst
type: docs
url: /it/php-java/data-points-of-treemap-and-sunburst-chart/
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
- PHP
- Aspose.Slides
description: "Scopri come creare dati gerarchici e personalizzare livelli, etichette e colori nei grafici Treemap e Sunburst con Aspose.Slides per PHP via Java."
---
## **Panoramica**

I grafici Treemap e Sunburst visualizzano lo stesso tipo di dati gerarchici, ma utilizzano layout diversi. Un Treemap disegna la gerarchia come rettangoli annidati le cui aree rappresentano i valori delle foglie. Un Sunburst la rappresenta come anelli concentrici: i gruppi di livello superiore sono vicino al centro, e le categorie foglia sono sull'anello esterno.

In Aspose.Slides per PHP via Java, ogni valore numerico è un [ChartDataPoint](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapoint/). Il suo metodo [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) fornisce l'accesso alla foglia e ai gruppi genitori. Questo articolo spiega tale mappatura e mostra come creare e formattare entrambi i tipi di grafico a partire dagli stessi dati di esempio.

![Un grafico Treemap con rami Consumer e Business](treemap-hierarchy.png)

![Un grafico Sunburst con la stessa gerarchia Consumer e Business](sunburst-hierarchy.png)

## **Comprendere Categorie, Punti Dati e Livelli**

Il campione usato di seguito ha tre livelli di categoria e una serie numerica:

| Branch | Stem | Leaf | Revenue |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Ogni riga crea una categoria foglia e un punto dati. I livelli di raggruppamento della categoria descrivono il percorso da quella foglia ai suoi genitori. Per la prima riga, il percorso è `Consumer > Computers > Laptops`.

Gli indici restituiti da [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) partono dalla foglia verso l'alto:

| `getDataPointLevels()` index | Logical level | Rappresentazione Treemap | Rappresentazione Sunburst |
| ---: | --- | --- | --- |
| `0` | Foglia | Rettangolo valore | Segmento anello esterno |
| `1` | Stem | Rettangolo genitore o intestazione | Segmento anello intermedio |
| `2` | Branch | Rettangolo livello superiore o intestazione | Segmento anello interno |

Questo ordine è lo stesso per entrambi i tipi di grafico anche se i layout visivi differiscono. Un segmento genitore è condiviso da più foglie. Per formattarlo, usare il livello corrispondente del primo punto dati in quel gruppo. Ad esempio, il ramo `Consumer` inizia con il punto `Laptops`, mentre lo stem `Software` inizia con il punto `Licenses`. Tenere riferimenti a questi punti è più chiaro e sicuro rispetto all'uso di espressioni inspiegabili come `$dataPoints->get_Item(0)` o `$dataPoints->get_Item(6)`.

## **Creare e Personalizzare Entrambi i Tipi di Grafico**

Il seguente esempio completo crea un Treemap nella prima diapositiva e un Sunburst nella seconda diapositiva. Costruisce la gerarchia, visualizza il valore per `Tablets`, applica colori fissi ai livelli selezionati, formatta un'etichetta di ramo e salva la presentazione.

```php
$presentation = new Presentation();
try {
    $worksheetIndex = 0;
    $leafLevelIndex = 0;
    $stemLevelIndex = 1;
    $branchLevelIndex = 2;

    $branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    $stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    $leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    $revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    $dataPointCount = count($leafNames);

    $chartTypes = [ChartType::Treemap, ChartType::Sunburst];
    $chartCount = count($chartTypes);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);

    for ($chartIndex = 0; $chartIndex < $chartCount; $chartIndex++) {
        $chartType = $chartTypes[$chartIndex];

        if ($chartIndex === 0) {
            $slide = $presentation->getSlides()->get_Item(0);
        } else {
            $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
        }

        $chart = $slide->getShapes()->addChart($chartType, 40, 40, 640, 440);
        $chart->setTitle(false);
        $chart->setLegend(false);

        $chartData = $chart->getChartData();
        $chartData->getCategories()->clear();
        $chartData->getSeries()->clear();

        $workbook = $chartData->getChartDataWorkbook();
        $workbook->clear($worksheetIndex);

        // Aggiungi le categorie foglia. Un elemento di raggruppamento viene impostato solo quando inizia un nuovo gruppo;
        // le categorie successive rimangono in quel gruppo fino a quando non viene impostato un altro elemento.
        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $categoryCell = $workbook->getCell($worksheetIndex, $rowIndex, 2, $leafName);
            $category = $chartData->getCategories()->add($categoryCell);

            $stemName = $stemNames[$dataIndex];
            $startsNewStem = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousStemName = $stemNames[$dataIndex - 1];
                $startsNewStem = $stemName !== $previousStemName;
            }
            if ($startsNewStem) {
                $category->getGroupingLevels()->setGroupingItem($stemLevelIndex, $stemName);
            }

            $branchName = $branchNames[$dataIndex];
            $startsNewBranch = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousBranchName = $branchNames[$dataIndex - 1];
                $startsNewBranch = $branchName !== $previousBranchName;
            }
            if ($startsNewBranch) {
                $category->getGroupingLevels()->setGroupingItem($branchLevelIndex, $branchName);
            }
        }

        $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Revenue");
        $series = $chartData->getSeries()->add($seriesNameCell, $chartType);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);

        $laptopsDataPoint = null;
        $tabletsDataPoint = null;
        $licensesDataPoint = null;

        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $revenue = $revenues[$dataIndex];
            $valueCell = $workbook->getCell($worksheetIndex, $rowIndex, 3, $revenue);

            if ($chartType === ChartType::Treemap) {
                $dataPoint = $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
            } else {
                $dataPoint = $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
            }

            if ($leafName === "Laptops") {
                $laptopsDataPoint = $dataPoint;
            } elseif ($leafName === "Tablets") {
                $tabletsDataPoint = $dataPoint;
            } elseif ($leafName === "Licenses") {
                $licensesDataPoint = $dataPoint;
            }
        }

        // Mostra la categoria e il valore sulla foglia Tablets.
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // Formatta il ramo Consumer attraverso la prima foglia di quel ramo.
        $consumerBranchLevel = $laptopsDataPoint->getDataPointLevels()->get_Item($branchLevelIndex);
        $consumerBranchFill = $consumerBranchLevel->getFormat()->getFill();
        $consumerBranchColor = new java("java.awt.Color", 31, 78, 121);
        $consumerBranchFill->setFillType(FillType::Solid);
        $consumerBranchFill->getSolidFillColor()->setColor($consumerBranchColor);

        $consumerLabelFormat = $consumerBranchLevel->getLabel()->getDataLabelFormat();
        $consumerLabelFormat->setShowCategoryName(true);
        $consumerLabelFormat->setShowSeriesName(false);
        $consumerLabelTextFill = $consumerLabelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
        $white = java("java.awt.Color")->WHITE;
        $consumerLabelTextFill->setFillType(FillType::Solid);
        $consumerLabelTextFill->getSolidFillColor()->setColor($white);

        // Formatta lo stem Software attraverso la prima foglia di quello stem.
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout influisce sulle etichette genitore del Treemap; Sunburst utilizza segmenti ad anello.
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le celle di categoria e le celle di valore utilizzano la stessa riga del foglio di lavoro, quindi le loro posizioni nella raccolta rimangono allineate. Quando si lavora con un grafico esistente anziché crearne uno, ispezionare prima le righe di categoria e memorizzare riferimenti nominati ai punti dati e ai livelli che si intende formattare.

## **Comportamento e Considerazioni Pratiche**

### **Differenze tra Treemap e Sunburst**

- Un Treemap usa l'area per comunicare il valore e rettangoli annidati per comunicare la gerarchia. Il metodo [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#setParentLabelLayout) controlla come appaiono le etichette genitore in questo tipo di grafico.
- Un Sunburst usa l'angolo per comunicare il valore e la profondità dell'anello per comunicare la gerarchia. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#setParentLabelLayout) non controlla le etichette degli anelli.
- Entrambi i tipi di grafico usano gli stessi livelli di raggruppamento di categoria e lo stesso ordine foglia‑genitore restituito da [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapoint/#getDataPointLevels), quindi il codice di costruzione dei dati e di formattazione dei livelli può essere condiviso.
- I valori dei genitori sono calcolati dalle loro foglie discendenti. Non aggiungere punti numerici separati per rami o stem.

### **Ordinamento e Sequenza dei Segmenti**

Il motore di layout del grafico determina il posizionamento finale di rettangoli e segmenti d'anello. Raggruppare le righe di categoria correlate prima di aggiungerle, ma non fare affidamento su una posizione di rettangolo o su un angolo di partenza specifici. Se la sequenza ha un significato, includerla nelle etichette o usare un tipo di grafico con un asse di categoria esplicito.

### **Tema e Colori Fissi**

I livelli di grafico non formattati ereditano i colori dal tema della presentazione. L'esempio usa riempimenti RGB espliciti per un output prevedibile. Se il grafico deve seguire le modifiche del tema, usare colori di schema invece di valori RGB fissi ed evitare di sovrascrivere ogni livello. Controllare anche il contrasto dell'etichetta dopo aver cambiato il riempimento di un ramo o stem.

### **Etichette e Spazio Disponibile**

PowerPoint può nascondere o troncate le etichette quando un segmento è troppo piccolo. Aumentare le dimensioni del grafico, abbreviare i nomi di categoria o mostrare meno campi di etichetta di solito produce un risultato più chiaro. Un'etichetta può combinare nome della categoria, nome della serie e valore tramite [DataLabelFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/datalabelformat/), ma abilitare tutti i campi spesso rende i grafici gerarchici difficili da leggere.

### **Esportazione e Rendering**

Il salvataggio in PPTX mantiene il grafico modificabile. Quando Aspose.Slides rende la presentazione in PDF o immagine, i riempimenti supportati e le impostazioni delle etichette vengono renderizzati con il grafico. La sostituzione dei font e piccole differenze nello spazio di layout disponibile possono modificare l'andamento del testo o la visibilità delle etichette, quindi installare i font richiesti e verificare i target di esportazione più importanti.

## **FAQ**

**Perché la modifica di un livello genitore influisce su più foglie?**

Un ramo o stem è un segmento visivo condiviso. Il suo [ChartDataPointLevel](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapointlevel/) può essere raggiunto tramite una foglia discendente, ma la formattazione appartiene al segmento genitore condiviso piuttosto che solo a quella foglia.

**Perché manca un'etichetta dati?**

Prima attivare i campi richiesti sull'oggetto [DataLabelFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/datalabelformat/) dell'etichetta. Quindi verificare se il segmento ha spazio sufficiente. Il layout dell'etichetta genitore del Treemap, le dimensioni del grafico, la lunghezza dell'etichetta, la dimensione del font e il numero di campi abilitati influenzano la possibilità di visualizzare l'etichetta.

**Posso impostare l'ordine esatto o le coordinate dei segmenti?**

Si può controllare l'ordine delle righe di origine e mantenere ogni gruppo contiguo, ma non è possibile assegnare rettangoli Treemap o angoli Sunburst precisi. Il motore di layout calcola questi elementi dalla gerarchia, dai valori e dallo spazio disponibile.

**Perché i colori cambiano dopo la modifica del tema della presentazione?**

I riempimenti basati sul tema sono progettati per seguire la tavolozza della presentazione. Applicare colori RGB espliciti ai livelli che devono rimanere fissi, o mantenere i colori di schema quando si preferisce adattarsi a un nuovo tema.

**La formattazione personalizzata viene conservata nelle esportazioni PDF e immagine?**

Sì, i riempimenti di grafico e le impostazioni delle etichette supportati sono inclusi durante il rendering. Per risultati coerenti tra sistemi, rendere disponibili i font necessari e testare le dimensioni di esportazione finali, poiché l'adattamento delle etichette dipende dal layout.

## **Vedi anche**

- [Create Treemap charts](/slides/it/php-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/it/php-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/it/php-java/export-chart/)
- [Manage presentation themes](/slides/it/php-java/presentation-theme/)