---
title: "Personalizza i punti dati nei grafici Treemap e Sunburst in Python"
linktitle: "Punti dati nei grafici Treemap e Sunburst"
type: docs
url: /it/python-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- grafico treemap
- grafico sunburst
- grafico gerarchico
- punto dati
- etichetta dati
- colore ramificazione
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come creare dati gerarchici e personalizzare livelli, etichette e colori nei grafici Treemap e Sunburst con Aspose.Slides per Python via Java."
---
## **Panoramica**

I grafici Treemap e Sunburst visualizzano lo stesso tipo di dati gerarchici, ma utilizzano layout differenti. Una Treemap disegna la gerarchia come rettangoli nidificati le cui aree rappresentano i valori delle foglie. Un Sunburst la rappresenta come anelli concentrici: i gruppi di primo livello sono vicino al centro, e le categorie foglia sono sull’anello esterno.

In Aspose.Slides per Python via Java, ogni valore numerico è un [ChartDataPoint](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdatapoint/). Il suo metodo [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) fornisce l’accesso alla foglia e ai gruppi genitore. Questo articolo spiega tale mappatura e mostra come creare e formattare entrambi i tipi di grafico a partire dagli stessi dati di esempio.

![Un grafico Treemap con le ramificazioni Consumer e Business](treemap-hierarchy.png)

![Un grafico Sunburst con la stessa gerarchia Consumer e Business](sunburst-hierarchy.png)

## **Comprendere categorie, punti dati e livelli**

L’esempio utilizzato di seguito ha tre livelli di categoria e una serie numerica:

| Ramificazione | Ramo | Foglia | Ricavi |
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

Gli indici restituiti da [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) partono dalla foglia verso l’alto:

| Indice `getDataPointLevels()` | Livello logico | Rappresentazione Treemap | Rappresentazione Sunburst |
| ---: | --- | --- | --- |
| `0` | Foglia | Rettangolo del valore | Segmento dell’anello esterno |
| `1` | Ramo | Rettangolo o intestazione genitore | Segmento dell’anello intermedio |
| `2` | Ramificazione | Rettangolo o intestazione di primo livello | Segmento dell’anello interno |

Questo ordine è lo stesso per entrambi i tipi di grafico, sebbene i loro layout visivi differiscano. Un segmento genitore è condiviso da diverse foglie. Per formattarlo, utilizzare il livello corrispondente del primo punto dati del gruppo. Per esempio, la ramificazione `Consumer` inizia con il punto `Laptops`, mentre il ramo `Software` inizia con il punto `Licenses`. Conservare riferimenti a quei punti è più chiaro e sicuro rispetto all’uso di espressioni non spiegate come `data_points.get_Item(0)` o `data_points.get_Item(6)`.

## **Creare e personalizzare entrambi i tipi di grafico**

Il seguente esempio completo crea una Treemap nella prima diapositiva e un Sunburst nella seconda diapositiva. Costruisce la gerarchia, mostra il valore per `Tablets`, applica colori fissi ai livelli selezionati, formatta l’etichetta di una ramificazione e salva la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # Aggiungi le categorie foglia. Un elemento di raggruppamento viene impostato solo quando inizia un nuovo gruppo;
        # le categorie successive rimangono in quel gruppo finché non viene impostato un altro elemento.
        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # Mostra la categoria e il valore sulla foglia Tablets.
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # Formatta il ramo Consumer attraverso la prima foglia di quel ramo.
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # Formatta il ramo Software attraverso la prima foglia di quel ramo.
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # ParentLabelLayout influisce sulle etichette genitore della Treemap; Sunburst utilizza segmenti ad anello.
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le celle di categoria e le celle di valore utilizzano la stessa riga del foglio di lavoro, quindi le loro posizioni nella raccolta rimangono allineate. Quando si lavora con un grafico esistente anziché crearne uno, ispezionare prima le righe di categoria e memorizzare riferimenti denominati ai punti dati e ai livelli che si intende formattare.

## **Comportamento e considerazioni pratiche**

### **Differenze tra Treemap e Sunburst**

- Una Treemap utilizza l’area per comunicare il valore e rettangoli nidificati per comunicare la gerarchia. Il metodo [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseries/#setParentLabelLayout) controlla come le etichette dei genitori appaiono in questo tipo di grafico.
- Un Sunburst utilizza l’angolo per comunicare il valore e la profondità dell’anello per comunicare la gerarchia. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseries/#setParentLabelLayout) non controlla le etichette degli anelli.
- Entrambi i grafici usano gli stessi livelli di raggruppamento di categoria e lo stesso ordine foglia‑genitore restituito da [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdatapoint/#getDataPointLevels), quindi il codice di costruzione dei dati e di formattazione dei livelli può essere condiviso.
- I valori dei genitori vengono calcolati dalle loro foglie discendenti. Non aggiungere punti numerici separati per ramificazioni o rami.

### **Ordinamento e ordine dei segmenti**

Il motore di layout del grafico determina il posizionamento finale dei rettangoli e dei segmenti degli anelli. Raggruppare le righe di categoria correlate prima di aggiungerle, ma non fare affidamento su una posizione specifica del rettangolo o su un angolo di partenza. Se la sequenza ha significato, includerla nelle etichette o utilizzare un tipo di grafico con un asse di categoria esplicito.

### **Tema e colori fissi**

I livelli di grafico non formattati ereditano i colori dal tema della presentazione. L’esempio utilizza riempimenti RGB espliciti per un output prevedibile. Se il grafico deve seguire le variazioni di tema, usare colori dello schema anziché valori RGB fissi ed evitare di sovrascrivere ogni livello. Verificare anche il contrasto delle etichette dopo aver modificato il riempimento di una ramificazione o di un ramo.

### **Etichette e spazio disponibile**

PowerPoint può nascondere o troncate le etichette quando un segmento è troppo piccolo. Ingrandire il grafico, abbreviare i nomi delle categorie o mostrare meno campi di etichetta solitamente produce un risultato più chiaro. Un’etichetta può combinare il nome della categoria, il nome della serie e il valore tramite [DataLabelFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/datalabelformat/), ma abilitare tutti i campi rende spesso i grafici gerarchici difficili da leggere.

### **Esportazione e rendering**

Salvare in PPTX mantiene il grafico modificabile. Quando Aspose.Slides rende la presentazione in PDF o immagine, i riempimenti supportati e le impostazioni delle etichette sono renderizzati con il grafico. La sostituzione dei caratteri e piccole differenze nello spazio di layout disponibile possono cambiare la formattazione del testo o la visibilità delle etichette, quindi installare i font necessari e verificare i target di esportazione più importanti.

## **FAQ**

**Perché la modifica di un livello genitore influisce su più foglie?**

Una ramificazione o un ramo è un segmento visuale condiviso. Il suo [ChartDataPointLevel](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdatapointlevel/) può essere raggiunto attraverso una foglia discendente, ma la formattazione appartiene al segmento genitore condiviso anziché solo a quella foglia.

**Perché manca un’etichetta dati?**

Prima abilitare i campi richiesti sull’oggetto [DataLabelFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/datalabelformat/) dell’etichetta. Poi verificare che il segmento abbia spazio sufficiente. Il layout delle etichette dei genitori nella Treemap, le dimensioni del grafico, la lunghezza dell’etichetta, la dimensione del carattere e il numero di campi abilitati influenzano tutti la visualizzazione dell’etichetta.

**Posso impostare l’ordine o le coordinate esatte dei segmenti?**

È possibile controllare l’ordine delle righe di origine e mantenere ciascun gruppo contiguo, ma non si possono assegnare rettangoli Treemap o angoli Sunburst precisi. Il motore di layout del grafico li calcola a partire dalla gerarchia, dai valori e dallo spazio disponibile.

**Perché i colori cambiano dopo la modifica del tema della presentazione?**

I riempimenti basati sul tema sono progettati per seguire la tavolozza della presentazione. Applicare colori RGB espliciti ai livelli che devono rimanere fissi, o mantenere i colori dello schema quando si preferisce adattarsi a un nuovo tema.

**La formattazione personalizzata verrà conservata in PDF e immagini?**

Sì, i riempimenti del grafico e le impostazioni delle etichette supportati vengono inclusi durante il rendering. Per risultati coerenti su tutti i sistemi, rendere disponibili i font richiesti e testare la dimensione finale dell’esportazione, poiché l’adattamento delle etichette dipende dal layout.

## **Vedi anche**

- [Create Treemap charts](/slides/it/python-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/it/python-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/it/python-java/export-chart/)
- [Manage presentation themes](/slides/it/python-java/presentation-theme/)