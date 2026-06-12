---
title: Personalizza le tabelle dei dati del grafico in Python
linktitle: Tabella dati
type: docs
url: /it/python-net/chart-data-table/
keywords:
- dati del grafico
- tabella dei dati
- proprietà del carattere
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Personalizza le tabelle dei dati del grafico in Python per PPT, PPTX e ODP con Aspose.Slides per aumentare efficienza e attrattiva nelle presentazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con le tabelle dei dati dei grafici in Aspose.Slides. Mostra come visualizzare una tabella dei dati per un grafico e personalizzare la formattazione del testo impostando le proprietà del carattere, come lo stile grassetto e l'altezza del carattere. L'esempio dimostra come caricare una presentazione, aggiungere un grafico, abilitare la tabella dei dati del grafico, applicare le impostazioni del carattere e salvare la presentazione aggiornata.

Include anche brevi risposte a domande comuni su come mostrare le chiavi di legenda in una tabella dei dati del grafico, preservare la tabella dei dati durante l'esportazione, lavorare con grafici caricati da presentazioni o modelli esistenti e identificare i grafici in cui la tabella dei dati è abilitata.

## **Imposta le proprietà del carattere per la tabella dei dati del grafico**
Aspose.Slides per Python via .NET offre supporto per cambiare il colore delle categorie in una serie di colori. 

1. Istanziare l'oggetto della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Aggiungere un grafico alla diapositiva.
3. impostare la tabella del grafico.
4. Impostare l'altezza del carattere.
5. Salvare la presentazione modificata.

Di seguito è riportato un esempio. 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso mostrare piccole chiavi di legenda accanto ai valori nella tabella dei dati del grafico?**

Sì. La tabella dei dati supporta le [chiavi di legenda](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datatable/show_legend_key/), e puoi attivarle o disattivarle.

**La tabella dei dati verrà preservata durante l'esportazione della presentazione in PDF, HTML o immagini?**

Sì. Aspose.Slides rende il grafico come parte della diapositiva, quindi il [PDF](/slides/it/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/it/python-net/convert-powerpoint-to-html/)/[image](/slides/it/python-net/convert-powerpoint-to-png/) esportato include il grafico con la sua tabella dei dati.

**Le tabelle dei dati sono supportate per i grafici provenienti da un file modello?**

Sì. Per qualsiasi grafico caricato da una presentazione o modello esistente, è possibile verificare e modificare se una tabella dei dati [è visualizzata](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/has_data_table/) usando le proprietà del grafico.

**Come posso trovare rapidamente quali grafici in un file hanno la tabella dei dati abilitata?**

Ispeziona la proprietà di ciascun grafico che indica se la tabella dei dati [è visualizzata](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/has_data_table/) e scorre le diapositive per identificare i grafici in cui è abilitata.