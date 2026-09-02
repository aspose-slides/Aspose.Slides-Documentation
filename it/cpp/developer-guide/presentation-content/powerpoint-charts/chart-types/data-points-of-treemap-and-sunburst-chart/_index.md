---
title: Personalizza i punti dati nei grafici Treemap e Sunburst in C++
linktitle: Punti dati nei grafici Treemap e Sunburst
type: docs
url: /it/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- grafico treemap
- grafico sunburst
- grafico gerarchico
- punto dati
- etichetta dati
- colore ramo
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come creare dati gerarchici e personalizzare livelli, etichette e colori nei grafici Treemap e Sunburst con Aspose.Slides per C++."
---
## **Panoramica**

I grafici Treemap e Sunburst mostrano lo stesso tipo di dati gerarchici, ma utilizzano layout diversi. Un Treemap rappresenta la gerarchia con rettangoli annidati le cui aree rappresentano i valori delle foglie. Un Sunburst la rappresenta con anelli concentrici: i gruppi di primo livello sono vicini al centro e le categorie foglia sono sull'anello esterno.

In Aspose.Slides per C++, ogni valore numerico è un [IChartDataPoint](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatapoint/). Il suo metodo [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) fornisce l'accesso alla foglia e ai gruppi genitore. Questo articolo spiega tale mapping e mostra come creare e formattare entrambi i tipi di grafico a partire dagli stessi dati di esempio.

![Un grafico Treemap con i rami Consumer e Business](treemap-hierarchy.png)

![Un grafico Sunburst con la stessa gerarchia Consumer e Business](sunburst-hierarchy.png)

## **Comprendere Categorie, Punti Dati e Livelli**

Il campione utilizzato di seguito ha tre livelli di categoria e una serie numerica:

| Filiale | Stelo | Foglia | Ricavi |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Ogni riga crea una categoria foglia e un punto dati. I livelli di raggruppamento delle categorie descrivono il percorso dalla foglia ai suoi genitori. Per la prima riga, il percorso è `Consumer > Computers > Laptops`.

Gli indici restituiti da [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) partono dalla foglia verso l'alto:

| Indice `get_DataPointLevels()` | Livello logico | Rappresentazione Treemap | Rappresentazione Sunburst |
| ---: | --- | --- | --- |
| `0` | Foglia | Rettangolo valore | Segmento anello esterno |
| `1` | Stelo | Rettangolo o intestazione genitore | Segmento anello medio |
| `2` | Filiale | Rettangolo o intestazione di primo livello | Segmento anello interno |

Questo ordine è lo stesso per entrambi i tipi di grafico, anche se i loro layout visivi differiscono. Un segmento genitore è condiviso da più foglie. Per formattarlo, utilizzare il livello corrispondente del primo punto dati di quel gruppo. Per esempio, il ramo `Consumer` inizia con il punto `Laptops`, mentre lo stelo `Software` inizia con il punto `Licenses`. Tenere riferimenti a quei punti è più chiaro e sicuro rispetto a usare espressioni inspiegabili come `dataPoints->idx_get(0)` o `dataPoints->idx_get(6)`.

## **Creare e Personalizzare Entrambi i Tipi di Grafico**

Il seguente esempio completo crea un Treemap nella prima diapositiva e un Sunburst nella seconda diapositiva. Costruisce la gerarchia, visualizza il valore per `Tablets`, applica colori fissi ai livelli selezionati, formatta un’etichetta di ramo e salva la presentazione.

```cpp
auto presentation = MakeObject<Presentation>();

auto addHierarchyChart = [](SharedPtr<ISlide> slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    auto chart = slide->get_Shapes()->AddChart(chartType, 40, 40, 640, 440);
    chart->set_HasTitle(false);
    chart->set_HasLegend(false);
    chart->get_ChartData()->get_Categories()->Clear();
    chart->get_ChartData()->get_Series()->Clear();

    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    workbook->Clear(worksheetIndex);

    auto addCategory = [&](int rowIndex, const String& leafName)
    {
        auto leafNameValue = ObjectExt::Box<String>(leafName);
        auto categoryCell = workbook->GetCell(worksheetIndex, rowIndex, 2, leafNameValue);
        return chart->get_ChartData()->get_Categories()->Add(categoryCell);
    };

    auto setGroupingItem = [](SharedPtr<IChartCategory> category, int levelIndex,
                              const String& groupName)
    {
        auto groupNameValue = ObjectExt::Box<String>(groupName);
        category->get_GroupingLevels()->SetGroupingItem(levelIndex, groupNameValue);
    };

    // Aggiungi le categorie foglia. Un elemento di raggruppamento viene impostato solo quando inizia un nuovo gruppo;
    // le categorie successive rimangono in quel gruppo finché non viene impostato un altro elemento.
    auto laptopsCategory = addCategory(1, u"Laptops");
    setGroupingItem(laptopsCategory, stemLevelIndex, u"Computers");
    setGroupingItem(laptopsCategory, branchLevelIndex, u"Consumer");

    addCategory(2, u"Desktops");

    auto phonesCategory = addCategory(3, u"Phones");
    setGroupingItem(phonesCategory, stemLevelIndex, u"Mobile");

    addCategory(4, u"Tablets");

    auto consultingCategory = addCategory(5, u"Consulting");
    setGroupingItem(consultingCategory, stemLevelIndex, u"Services");
    setGroupingItem(consultingCategory, branchLevelIndex, u"Business");

    addCategory(6, u"Support");

    auto licensesCategory = addCategory(7, u"Licenses");
    setGroupingItem(licensesCategory, stemLevelIndex, u"Software");

    addCategory(8, u"Subscriptions");

    auto seriesNameValue = ObjectExt::Box<String>(u"Revenue");
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, seriesNameValue);
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chartType);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);

    auto addDataPoint = [&](int rowIndex, double value)
    {
        auto valueObject = ObjectExt::Box<double>(value);
        auto valueCell = workbook->GetCell(worksheetIndex, rowIndex, 3, valueObject);

        if (chartType == ChartType::Treemap)
        {
            return series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
        }

        return series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
    };

    auto laptopsDataPoint = addDataPoint(1, 12);
    addDataPoint(2, 8);
    addDataPoint(3, 15);
    auto tabletsDataPoint = addDataPoint(4, 6);
    addDataPoint(5, 10);
    addDataPoint(6, 7);
    auto licensesDataPoint = addDataPoint(7, 11);
    addDataPoint(8, 14);

    auto setSolidFill = [](SharedPtr<IFillFormat> fillFormat, Color color)
    {
        fillFormat->set_FillType(FillType::Solid);
        fillFormat->get_SolidFillColor()->set_Color(color);
    };

    // Mostra la categoria e il valore sulla foglia Tablets.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // Formatta il ramo Consumer attraverso la prima foglia di quel ramo.
    auto consumerBranchLevel = laptopsDataPoint->get_DataPointLevels()->idx_get(branchLevelIndex);
    auto consumerBranchFill = consumerBranchLevel->get_Format()->get_Fill();
    auto consumerBranchColor = Color::FromArgb(31, 78, 121);
    setSolidFill(consumerBranchFill, consumerBranchColor);

    auto consumerLabelFormat = consumerBranchLevel->get_Label()->get_DataLabelFormat();
    consumerLabelFormat->set_ShowCategoryName(true);
    consumerLabelFormat->set_ShowSeriesName(false);
    auto consumerLabelTextFill = consumerLabelFormat->get_TextFormat()
        - >get_PortionFormat()->get_FillFormat();
    setSolidFill(consumerLabelTextFill, Color::get_White());

    // Formatta lo stelo Software attraverso la prima foglia di quello stelo.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout influisce sulle etichette genitore del Treemap; Sunburst utilizza segmenti di anello.
    if (chartType == ChartType::Treemap)
    {
        series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);
    }
};

auto treemapSlide = presentation->get_Slide(0);
addHierarchyChart(treemapSlide, ChartType::Treemap);

auto layoutSlide = presentation->get_LayoutSlide(0);
auto sunburstSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
addHierarchyChart(sunburstSlide, ChartType::Sunburst);

presentation->Save(u"hierarchical-charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le celle di categoria e le celle di valore usano la stessa riga del foglio di lavoro, quindi le loro posizioni nella collezione rimangono allineate. Quando si lavora con un grafico esistente anziché crearne uno nuovo, ispezionare prima le righe di categoria e memorizzare riferimenti nominati ai punti dati e ai livelli che si intende formattare.

## **Comportamento e Considerazioni Pratiche**

### **Differenze tra Treemap e Sunburst**

- Un Treemap utilizza l'area per comunicare il valore e rettangoli annidati per comunicare la gerarchia. Il metodo [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) controlla come appaiono le etichette genitore in questo tipo di grafico.
- Un Sunburst utilizza l'angolo per comunicare il valore e la profondità dell'anello per comunicare la gerarchia. [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) non controlla le etichette degli anelli.
- Entrambi i tipi di grafico usano gli stessi livelli di raggruppamento delle categorie e lo stesso ordine foglia‑genitore restituito da [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/), quindi il codice di costruzione dei dati e di formattazione dei livelli può essere condiviso.
- I valori dei genitori sono calcolati dalle loro foglie discendenti. Non aggiungere punti numerici separati per rami o steli.

### **Ordinamento e Ordine dei Segmenti**

Il motore di layout del grafico determina il posizionamento finale dei rettangoli e dei segmenti di anello. Raggruppare le righe di categoria correlate prima di aggiungerle, ma non fare affidamento su una posizione di rettangolo o su un angolo iniziale specifici. Se la sequenza ha un significato, includerla nelle etichette o utilizzare un tipo di grafico con un asse di categoria esplicito.

### **Tema e Colori Fissi**

I livelli di grafico non formattati ereditano i colori dal tema della presentazione. L'esempio usa riempimenti RGB espliciti per un output prevedibile. Se il grafico deve seguire le variazioni di tema, usare colori di schema invece di valori RGB fissi ed evitare di sovrascrivere ogni livello. Verificare anche il contrasto delle etichette dopo aver modificato il riempimento di un ramo o di uno stelo.

### **Etichette e Spazio Disponibile**

PowerPoint può nascondere o troncare le etichette quando un segmento è troppo piccolo. Aumentare le dimensioni del grafico, abbreviare i nomi delle categorie o mostrare meno campi di etichetta solitamente produce un risultato più chiaro. Un'etichetta può combinare il nome della categoria, il nome della serie e il valore tramite [IDataLabelFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/idatalabelformat/), ma abilitare tutti i campi spesso rende difficili da leggere i grafici gerarchici.

### **Esportazione e Rendering**

Salvare in PPTX mantiene il grafico modificabile. Quando Aspose.Slides rende la presentazione in PDF o immagine, i riempimenti e le impostazioni delle etichette supportati vengono renderizzati con il grafico. La sostituzione dei caratteri e le piccole differenze nello spazio di layout disponibile possono modificare l'andamento del testo o la visibilità delle etichette, quindi installare i caratteri richiesti e verificare i principali target di esportazione.

## **FAQ**

**Perché la modifica di un livello genitore influisce su più foglie?**

Un ramo o uno stelo è un segmento visivo condiviso. Il suo [IChartDataPointLevel](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatapointlevel/) è accessibile tramite una foglia discendente, ma la formattazione appartiene al segmento genitore condiviso e non solo a quella foglia.

**Perché manca un'etichetta dati?**

Innanzitutto abilitare i campi richiesti sull'oggetto [IDataLabelFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/idatalabelformat/) dell'etichetta. Quindi verificare se il segmento dispone di spazio sufficiente. Il layout delle etichette genitore di Treemap, le dimensioni del grafico, la lunghezza dell'etichetta, la dimensione del carattere e il numero di campi abilitati influiscono tutti sulla possibilità di visualizzare un'etichetta.

**Posso impostare l'ordine o le coordinate esatte dei segmenti?**

È possibile controllare l'ordine delle righe di origine e mantenere ogni gruppo contiguo, ma non è possibile assegnare rettangoli Treemap o angoli Sunburst esatti. Il motore di layout del grafico li calcola a partire dalla gerarchia, dai valori e dallo spazio disponibile.

**Perché i colori cambiano dopo la modifica del tema della presentazione?**

I riempimenti basati sul tema sono progettati per seguire la tavolozza della presentazione. Applicare colori RGB espliciti ai livelli che devono rimanere fissi, oppure mantenere i colori di schema quando è preferita l'adattabilità al nuovo tema.

**La formattazione personalizzata verrà conservata nelle esportazioni PDF e immagine?**

Sì, i riempimenti e le impostazioni delle etichette supportati dal grafico vengono inclusi durante il rendering. Per risultati coerenti su più sistemi, rendere disponibili i caratteri richiesti e testare la dimensione di esportazione finale, poiché l'adattamento delle etichette dipende dal layout.

## **Vedi anche**

- [Create Treemap charts](/slides/it/cpp/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/it/cpp/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/it/cpp/export-chart/)
- [Manage presentation themes](/slides/it/cpp/presentation-theme/)