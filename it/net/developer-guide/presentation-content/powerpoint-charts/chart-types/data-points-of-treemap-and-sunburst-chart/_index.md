---
title: "Personalizza i punti dati in grafici Treemap e Sunburst in .NET"
linktitle: "Punti dati in grafici Treemap e Sunburst"
type: docs
url: /it/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- grafico Treemap
- grafico Sunburst
- grafico gerarchico
- punto dati
- etichetta dati
- colore ramo
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come creare dati gerarchici e personalizzare livelli, etichette e colori nei grafici Treemap e Sunburst con Aspose.Slides per .NET."
---
## **Panoramica**

I grafici Treemap e Sunburst visualizzano lo stesso tipo di dati gerarchici, ma utilizzano layout diversi. Un Treemap disegna la gerarchia come rettangoli annidati i cui aree rappresentano i valori delle foglie. Un Sunburst la rappresenta come anelli concentrici: i gruppi di livello superiore sono vicini al centro, e le categorie foglia sono sull'anello esterno.

In Aspose.Slides per .NET, ogni valore numerico è un [IChartDataPoint](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatapoint/). La sua collezione [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) fornisce l'accesso alla foglia e ai gruppi genitore. Questo articolo spiega tale mappatura e mostra come creare e formattare entrambi i tipi di grafico dallo stesso set di dati di esempio.

![Un grafico Treemap con le branche Consumer e Business](treemap-hierarchy.png)

![Un grafico Sunburst con la stessa gerarchia Consumer e Business](sunburst-hierarchy.png)

## **Comprendere Categorie, Punti dati e Livelli**

Il campione utilizzato di seguito ha tre livelli di categoria e una serie numerica:

| Filiale | Ramo | Foglia | Ricavi |
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

Gli indici in [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) partono dalla foglia verso l'alto:

| Indice `DataPointLevels` | Livello logico | Rappresentazione Treemap | Rappresentazione Sunburst |
| ---: | --- | --- | --- |
| `0` | Foglia | Rettangolo valore | Segmento anello esterno |
| `1` | Ramo | Rettangolo genitore o intestazione | Segmento anello medio |
| `2` | Filiale | Rettangolo livello superiore o intestazione | Segmento anello interno |

Quest'ordine è lo stesso per entrambi i tipi di grafico anche se i loro layout visivi differiscono. Un segmento genitore è condiviso da diverse foglie. Per formattarlo, usa il livello corrispondente del primo punto dati in quel gruppo. Ad esempio, il ramo `Consumer` inizia con il punto `Laptops`, mentre il ramo `Software` inizia con il punto `Licenses`. Tenere riferimenti a quei punti è più chiaro e sicuro rispetto all'uso di espressioni non spiegate come `dataPoints[0]` o `dataPoints[6]`.

## **Creare e Personalizzare Entrambi i Tipi di Grafico**

Il seguente esempio completo crea un Treemap nella prima diapositiva e un Sunburst nella seconda diapositiva. Costruisce la gerarchia, visualizza il valore per `Tablets`, applica colori fissi a livelli selezionati, formatta un'etichetta di ramo e salva la presentazione.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var treemapSlide = presentation.Slides[0];
AddHierarchyChart(treemapSlide, ChartType.Treemap);

var layoutSlide = presentation.LayoutSlides[0];
var sunburstSlide = presentation.Slides.AddEmptySlide(layoutSlide);
AddHierarchyChart(sunburstSlide, ChartType.Sunburst);

presentation.Save("hierarchical-charts.pptx", SaveFormat.Pptx);

static void AddHierarchyChart(ISlide slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    var chart = slide.Shapes.AddChart(chartType, 40, 40, 640, 440);
    chart.HasTitle = false;
    chart.HasLegend = false;
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(worksheetIndex);

    // Aggiungi le categorie foglia. Un elemento di raggruppamento viene impostato solo quando inizia un nuovo gruppo;
    // le categorie successive rimangono in quel gruppo fino a quando non viene impostato un altro elemento.
    var laptopsCategory = AddCategory(1, "Laptops");
    laptopsCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Computers");
    laptopsCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Consumer");

    AddCategory(2, "Desktops");

    var phonesCategory = AddCategory(3, "Phones");
    phonesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Mobile");

    AddCategory(4, "Tablets");

    var consultingCategory = AddCategory(5, "Consulting");
    consultingCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Services");
    consultingCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Business");

    AddCategory(6, "Support");

    var licensesCategory = AddCategory(7, "Licenses");
    licensesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Software");

    AddCategory(8, "Subscriptions");

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Revenue");
    var series = chart.ChartData.Series.Add(seriesNameCell, chartType);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

    var laptopsDataPoint = AddDataPoint(1, 12);
    AddDataPoint(2, 8);
    AddDataPoint(3, 15);
    var tabletsDataPoint = AddDataPoint(4, 6);
    AddDataPoint(5, 10);
    AddDataPoint(6, 7);
    var licensesDataPoint = AddDataPoint(7, 11);
    AddDataPoint(8, 14);

    // Mostra la categoria e il valore sulla foglia Tablets.
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // Formatta il ramo Consumer attraverso la prima foglia di quel ramo.
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // Formatta il ramo intermedio Software attraverso la prima foglia di quel ramo intermedio.
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout influisce sulle etichette genitore di Treemap; Sunburst utilizza segmenti di anello.
    if (chartType == ChartType.Treemap)
    {
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
    }

    IChartCategory AddCategory(int rowIndex, string leafName)
    {
        var categoryCell = workbook.GetCell(worksheetIndex, rowIndex, 2, leafName);
        return chart.ChartData.Categories.Add(categoryCell);
    }

    IChartDataPoint AddDataPoint(int rowIndex, double value)
    {
        var valueCell = workbook.GetCell(worksheetIndex, rowIndex, 3, value);

        if (chartType == ChartType.Treemap)
        {
            return series.DataPoints.AddDataPointForTreemapSeries(valueCell);
        }

        return series.DataPoints.AddDataPointForSunburstSeries(valueCell);
    }

    static void SetSolidFill(IFillFormat fillFormat, Color color)
    {
        fillFormat.FillType = FillType.Solid;
        fillFormat.SolidFillColor.Color = color;
    }
}
```

Le celle di categoria e le celle di valore usano la stessa riga del foglio di lavoro, quindi le loro posizioni nella collezione rimangono allineate. Quando lavori con un grafico esistente anziché crearne uno nuovo, ispeziona prima le righe di categoria e memorizza riferimenti nominati ai punti dati e ai livelli che intendi formattare.

## **Comportamento e Considerazioni Pratiche**

### **Differenze tra Treemap e Sunburst**

- Un Treemap utilizza l'area per comunicare il valore e rettangoli annidati per comunicare la gerarchia. La proprietà [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseries/parentlabellayout/) controlla come le etichette genitore appaiono in questo tipo di grafico.
- Un Sunburst utilizza l'angolo per comunicare il valore e la profondità dell'anello per comunicare la gerarchia. [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseries/parentlabellayout/) non controlla le etichette degli anelli.
- Entrambi i tipi di grafico usano gli stessi livelli di raggruppamento delle categorie e lo stesso ordine foglia‑genitore in `DataPointLevels`, quindi il codice di costruzione dei dati e di formattazione dei livelli può essere condiviso.
- I valori dei genitori sono calcolati dalle foglie discendenti. Non aggiungere punti numerici separati per i rami o i rami intermedi.

### **Ordinamento e Ordine dei Segmenti**

Il motore di layout del grafico determina il posizionamento finale di rettangoli e segmenti di anello. Raggruppa le righe di categoria correlate prima di aggiungerle, ma non fare affidamento su una posizione specifica del rettangolo o su un angolo di partenza. Se la sequenza ha un significato, includila nelle etichette o utilizza un tipo di grafico con un asse di categoria esplicito.

### **Tema e Colori Fissi**

I livelli di grafico non formattati ereditano i colori dal tema della presentazione. L'esempio usa riempimenti RGB espliciti per un output prevedibile. Se il grafico deve seguire le variazioni del tema, usa colori di schema invece di valori RGB fissi ed evita di sovrascrivere tutti i livelli. Controlla anche il contrasto delle etichette dopo aver cambiato il riempimento di un ramo o di un ramo intermedio.

### **Etichette e Spazio Disponibile**

PowerPoint può nascondere o troncare le etichette quando un segmento è troppo piccolo. Aumentare le dimensioni del grafico, abbreviare i nomi delle categorie o mostrare meno campi di etichetta di solito produce un risultato più chiaro. Un'etichetta può combinare il nome della categoria, il nome della serie e il valore tramite [IDataLabelFormat](https://reference.aspose.com/slides/it/net/aspose.slides.charts/idatalabelformat/), ma abilitare tutti i campi spesso rende i grafici gerarchici difficili da leggere.

### **Esportazione e Rendering**

Salvare in PPTX mantiene il grafico modificabile. Quando Aspose.Slides rende la presentazione in PDF o immagine, i riempimenti e le impostazioni delle etichette supportati vengono renderizzati con il grafico. La sostituzione dei font e piccole differenze nello spazio di layout disponibile possono modificare l'andamento del testo o la visibilità delle etichette, quindi installa i font richiesti e verifica i target di esportazione più importanti.

## **FAQ**

**Perché la modifica di un livello genitore influisce su più foglie?**

Un ramo o un ramo intermedio è un segmento visivo condiviso. Il suo [IChartDataPointLevel](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatapointlevel/) è raggiungibile attraverso una foglia discendente, ma la formattazione appartiene al segmento genitore condiviso piuttosto che solo a quella foglia.

**Perché manca un'etichetta dati?**

Prima abilita i campi richiesti sull'oggetto [IDataLabelFormat](https://reference.aspose.com/slides/it/net/aspose.slides.charts/idatalabelformat/) dell'etichetta. Quindi verifica se il segmento ha spazio sufficiente. Il layout delle etichette genitore del Treemap, le dimensioni del grafico, la lunghezza dell'etichetta, la dimensione del carattere e il numero di campi abilitati influenzano tutti la visualizzazione dell'etichetta.

**Posso impostare l'ordine esatto o le coordinate dei segmenti?**

Puoi controllare l'ordine delle righe di origine e mantenere ogni gruppo contiguo, ma non puoi assegnare rettangoli Treemap o angoli Sunburst precisi. Il motore di layout del grafico li calcola dalla gerarchia, dai valori e dallo spazio disponibile.

**Perché i colori cambiano dopo la modifica del tema della presentazione?**

I riempimenti basati sul tema sono progettati per seguire la palette della presentazione. Applica colori RGB espliciti ai livelli che devono rimanere fissi, o mantieni i colori di schema quando è preferibile adattarsi a un nuovo tema.

**La formattazione personalizzata sarà preservata in esportazioni PDF e immagine?**

Sì, i riempimenti e le impostazioni delle etichette supportati vengono inclusi durante il rendering. Per risultati coerenti su tutti i sistemi, rendi disponibili i font richiesti e testa le dimensioni finali dell'esportazione perché l'adattamento delle etichette dipende dal layout.

## **Vedi anche**

- [Create Treemap charts](/slides/it/net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/it/net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/it/net/export-chart/)
- [Manage presentation themes](/slides/it/net/presentation-theme/)