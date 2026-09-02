---
title: Personalizza i punti dati nei grafici Treemap e Sunburst in Python
linktitle: Punti dati nei grafici Treemap e Sunburst
type: docs
url: /it/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- grafico treemap
- grafico sunburst
- grafico gerarchico
- punto dati
- etichetta dati
- colore del ramo
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come creare dati gerarchici e personalizzare livelli, etichette e colori nei grafici Treemap e Sunburst con Aspose.Slides per Python via .NET."
---
## **Panoramica**

I grafici Treemap e Sunburst visualizzano lo stesso tipo di dati gerarchici, ma utilizzano layout diversi. Un Treemap disegna la gerarchia come rettangoli nidificati le cui aree rappresentano i valori delle foglie. Un Sunburst la rappresenta con anelli concentrici: i gruppi di primo livello sono vicini al centro e le categorie foglia sono sull’anello esterno.

In Aspose.Slides per Python via .NET, ogni valore numerico è un [ChartDataPoint](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdatapoint/). La sua collezione [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) fornisce l’accesso alla foglia e ai gruppi genitori. Questo articolo spiega quella mappatura e mostra come creare e formattare entrambi i tipi di grafico dallo stesso set di dati di esempio.

![A Treemap chart with Consumer and Business branches](treemap-hierarchy.png)

![A Sunburst chart with the same Consumer and Business hierarchy](sunburst-hierarchy.png)

## **Comprendere categorie, punti dati e livelli**

Il campione usato di seguito ha tre livelli di categoria e una serie numerica:

| Ramo | Germoglio | Foglia | Entrate |
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

Gli indici in [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) partono dalla foglia verso l’alto:

| Indice `data_point_levels` | Livello logico | Rappresentazione Treemap | Rappresentazione Sunburst |
| ---: | --- | --- | --- |
| `0` | Foglia | Rettangolo del valore | Segmento dell’anello esterno |
| `1` | Germoglio | Rettangolo genitore o intestazione | Segmento dell’anello intermedio |
| `2` | Ramo | Rettangolo di primo livello o intestazione | Segmento dell’anello interno |

Questo ordine è lo stesso per entrambi i tipi di grafico, sebbene i loro layout visivi differiscano. Un segmento genitore è condiviso da più foglie. Per formattarlo, usa il livello corrispondente del primo punto dati nel gruppo. Per esempio, il ramo `Consumer` inizia con il punto `Laptops`, mentre il germoglio `Software` inizia con il punto `Licenses`. Tenere riferimenti a quei punti è più chiaro e sicuro rispetto all’uso di espressioni non spiegate come `data_points[0]` o `data_points[6]`.

## **Crea e personalizza entrambi i tipi di grafico**

Il seguente esempio completo crea un Treemap nella prima diapositiva e un Sunburst nella seconda. Costruisce la gerarchia, visualizza il valore per `Tablets`, applica colori fissi ai livelli selezionati, formatta un’etichetta di ramo e salva la presentazione.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # Aggiungi le categorie foglia. Un elemento di raggruppamento viene impostato solo quando inizia un nuovo gruppo;
    # le categorie seguenti rimangono in quel gruppo fino a quando non viene impostato un altro elemento.
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # Mostra la categoria e il valore sulla foglia Tablets.
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # Formatta il ramo Consumer attraverso la prima foglia in quel ramo.
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # Formatta il germoglio Software attraverso la prima foglia in quel germoglio.
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # parent_label_layout influisce sulle etichette genitore del Treemap; Sunburst utilizza segmenti ad anello.
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

Le celle di categoria e le celle di valore usano la stessa riga del foglio di lavoro, quindi le loro posizioni nella collezione rimangono allineate. Quando lavori con un grafico esistente anziché crearne uno, ispeziona prima le righe di categoria e memorizza riferimenti nominati ai punti dati e ai livelli che intendi formattare.

## **Comportamento e considerazioni pratiche**

### **Differenze tra Treemap e Sunburst**

- Un Treemap utilizza l’area per comunicare il valore e rettangoli nidificati per comunicare la gerarchia. La proprietà [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseries/parent_label_layout/) controlla come appaiono le etichette dei genitori in questo tipo di grafico.
- Un Sunburst utilizza l’angolo per comunicare il valore e la profondità dell’anello per comunicare la gerarchia. [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseries/parent_label_layout/) non controlla le etichette degli anelli.
- Entrambi i tipi usano gli stessi livelli di raggruppamento e lo stesso ordine foglia‑genitore in `data_point_levels`, quindi il codice per la costruzione dei dati e la formattazione dei livelli può essere condiviso.
- I valori dei genitori sono calcolati dalle loro foglie discendenti. Non aggiungere punti numerici separati per rami o germogli.

### **Ordinamento e ordine dei segmenti**

Il motore di layout del grafico determina la posizione finale dei rettangoli e dei segmenti degli anelli. Raggruppa le righe di categoria correlate prima di aggiungerle, ma non fare affidamento su una posizione rettangolare o su un angolo di partenza specifici. Se la sequenza ha un significato, includila nelle etichette o utilizza un tipo di grafico con un asse di categoria esplicito.

### **Tema e colori fissi**

I livelli di grafico non formattati ereditano i colori dal tema della presentazione. L’esempio usa riempimenti RGB espliciti per un output prevedibile. Se il grafico deve seguire le variazioni del tema, usa i colori dello schema anziché valori RGB fissi e evita di sovrascrivere ogni livello. Controlla anche il contrasto delle etichette dopo aver modificato il riempimento di un ramo o di un germoglio.

### **Etichette e spazio disponibile**

PowerPoint può nascondere o troncare le etichette quando un segmento è troppo piccolo. Aumentare le dimensioni del grafico, abbreviare i nomi delle categorie o mostrare meno campi di etichetta solitamente produce un risultato più chiaro. Un’etichetta può combinare il nome della categoria, il nome della serie e il valore tramite [DataLabelFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datalabelformat/), ma abilitare tutti i campi spesso rende difficile la lettura dei grafici gerarchici.

### **Esportazione e rendering**

Salvare in PPTX mantiene il grafico modificabile. Quando Aspose.Slides rende la presentazione in PDF o in immagine, i riempimenti e le impostazioni delle etichette supportati sono renderizzati con il grafico. La sostituzione dei caratteri e le piccole differenze nello spazio di layout disponibile possono modificare l’andamento del testo o la visibilità delle etichette, quindi installa i caratteri richiesti e verifica le destinazioni di esportazione più importanti.

## **FAQ**

**Perché la modifica di un livello genitore influisce su più foglie?**

Un ramo o un germoglio è un segmento visivo condiviso. Il suo [ChartDataPointLevel](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdatapointlevel/) può essere raggiunto tramite una foglia discendente, ma la formattazione appartiene al segmento genitore condiviso, non solo a quella foglia.

**Perché manca un’etichetta dati?**

Prima abilita i campi richiesti sull’oggetto [DataLabelFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datalabelformat/) dell’etichetta. Quindi verifica che il segmento abbia spazio sufficiente. Il layout delle etichette genitore del Treemap, le dimensioni del grafico, la lunghezza dell’etichetta, la dimensione del carattere e il numero di campi abilitati influenzano la possibilità di visualizzare l’etichetta.

**Posso impostare l’esatto ordine o le coordinate dei segmenti?**

Puoi controllare l’ordine delle righe di origine e mantenere ogni gruppo contiguo, ma non è possibile assegnare rettangoli Treemap o angoli Sunburst precisi. Il motore di layout calcola questi valori dalla gerarchia, dai valori e dallo spazio disponibile.

**Perché i colori cambiano dopo la modifica del tema della presentazione?**

I riempimenti basati sul tema sono progettati per seguire la palette della presentazione. Applica colori RGB espliciti ai livelli che devono rimanere fissi, oppure mantieni i colori dello schema quando è preferibile adattarsi a un nuovo tema.

**La formattazione personalizzata viene conservata nelle esportazioni PDF e immagine?**

Sì, i riempimenti di grafico e le impostazioni delle etichette supportati sono inclusi durante il rendering. Per risultati coerenti su tutti i sistemi, rendi disponibili i caratteri richiesti e testa la dimensione finale dell’esportazione, poiché l’adattamento delle etichette dipende dal layout.

## **Vedi anche**

- [Create Treemap charts](/slides/it/python-net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/it/python-net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/it/python-net/export-chart/)
- [Manage presentation themes](/slides/it/python-net/presentation-theme/)