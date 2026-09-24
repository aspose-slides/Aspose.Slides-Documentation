---
title: Personalizza le tabelle dei dati dei grafici nelle presentazioni in Python
linktitle: Tabella Dati
type: docs
url: /it/python-net/chart-data-table/
keywords:
- dati del grafico
- tabella dati
- proprietà del font
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Personalizza i font, i bordi e le chiavi della legenda delle tabelle dei dati dei grafici nelle presentazioni PowerPoint usando Aspose.Slides per Python via .NET."
---
## **Panoramica**

Aspose.Slides per Python via .NET consente di visualizzare la tabella dei dati di un grafico e di personalizzare la formattazione del testo, i bordi e le chiavi della legenda. Questo articolo spiega come abilitare la tabella, formattare il testo, controllare ciascun tipo di bordo e mostrare o nascondere le chiavi della legenda. Gli esempi salvano i grafici configurati in file PPTX.

## **Impostare le proprietà del font**

Per visualizzare la tabella dei dati di un grafico, impostare [has_data_table](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/has_data_table/) a `True`. Usare [chart_data_table](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/chart_data_table/) per accedere alla tabella e configurare la formattazione del testo.

1. Caricare la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Aggiungere un grafico a colonne raggruppate alla prima diapositiva.
1. Abilitare la tabella dei dati del grafico.
1. Abilitare il testo in grassetto con [font_bold](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/font_bold/) e impostare [font_height](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/font_height/) a `20` per testo da 20 punti.
1. Salvare la presentazione modificata.

L'esempio seguente richiede `test.pptx` nella directory di lavoro con almeno una diapositiva. Aggiunge un grafico con dati predefiniti nella posizione (50, 50), con una larghezza di 600 punti e un'altezza di 400 punti. Il file `output.pptx` salvato contiene il grafico con la tabella dei dati abilitata e le impostazioni del font specificate applicate.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Personalizzare i bordi della tabella dei dati**

Abilitare la tabella con [Chart.has_data_table](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/has_data_table/) e accedervi tramite [Chart.chart_data_table](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/chart_data_table/). È possibile controllare tre tipi di bordi in modo indipendente:

- [has_border_horizontal](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datatable/has_border_horizontal/) controlla i bordi orizzontali delle celle.
- [has_border_vertical](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datatable/has_border_vertical/) controlla i bordi verticali delle celle.
- [has_border_outline](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datatable/has_border_outline/) controlla il bordo esterno della tabella.

Impostare ogni proprietà a `True` per visualizzare i relativi bordi o a `False` per nasconderli. L'esempio seguente crea un grafico a colonne raggruppate con dati predefiniti, visualizza i bordi orizzontali e il bordo esterno, e nasconde i bordi verticali. Non richiede alcun file di input. La posizione e le dimensioni del grafico sono specificate in punti.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

Il confronto sotto utilizza gli stessi dati del grafico e l'impostazione della chiave della legenda in tutti e quattro i casi. Partendo da tutti i bordi abilitati, ogni variante rimanente disabilita una sola proprietà del bordo. La variante in basso a sinistra corrisponde alle impostazioni dei bordi nell'esempio.

![Tabelle dei dati del grafico con tutti i bordi abilitati, senza bordi orizzontali, senza bordi verticali e senza bordo esterno](data-table-borders.png)

## **Mostrare o nascondere le chiavi della legenda**

Le chiavi della legenda sono piccoli marcatori colorati accanto ai nomi delle serie nella tabella dei dati. Aiutano i lettori a correlare ogni riga della tabella a una serie del grafico. Impostare [show_legend_key](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datatable/show_legend_key/) a `True` per mostrare questi marcatori o a `False` per nasconderli.

La legenda separata del grafico è controllata da [Chart.has_legend](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/has_legend/). Queste impostazioni sono indipendenti: nascondere la legenda separata non nasconde le chiavi all'interno della tabella dei dati, e nascondere le chiavi della tabella non nasconde la legenda separata.

L'esempio seguente crea un grafico con dati predefiniti, abilita la sua tabella dei dati e mostra le chiavi della legenda al suo interno nascondendo la legenda separata. Tutti i bordi della tabella sono esplicitamente abilitati. Non è necessaria alcuna presentazione di input. Per nascondere solo le chiavi della tabella, modificare `data_table.show_legend_key` a `False`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

Il confronto sotto mostra la stessa tabella con le chiavi della legenda abilitate e disabilitate. Tutti i bordi rimangono abilitati, e la legenda separata del grafico è nascosta in entrambi i casi.

![Tabelle dei dati del grafico con chiavi della legenda mostrate a sinistra e nascoste a destra](data-table-legend-keys.png)

## **FAQ**

**Posso mostrare le chiavi della legenda nella tabella dei dati di un grafico?**

Sì. Impostare [show_legend_key](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datatable/show_legend_key/) a `True` per visualizzare le chiavi della legenda o a `False` per nasconderle.

**La tabella dei dati verrà conservata durante l'esportazione della presentazione in PDF, HTML o immagini?**

Sì. Aspose.Slides renderizza il grafico e la sua tabella dei dati visualizzata come parte della diapositiva durante l'esportazione in [PDF](/slides/it/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/it/python-net/convert-powerpoint-to-html/), o [immagini](/slides/it/python-net/convert-powerpoint-to-png/).

**Posso lavorare con le tabelle dei dati nei grafici caricati da un modello?**

Sì. Per un grafico caricato da una presentazione o modello esistente, utilizzare [has_data_table](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/has_data_table/) per verificare o modificare se la sua tabella dei dati è visualizzata.

**Come posso trovare i grafici che hanno la tabella dei dati abilitata?**

Iterare attraverso le forme di ogni diapositiva, identificare i grafici e verificare la loro proprietà [has_data_table](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/has_data_table/). Un valore `True` indica che la tabella dei dati è abilitata.