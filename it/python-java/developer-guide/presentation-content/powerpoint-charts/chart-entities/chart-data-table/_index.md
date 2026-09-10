---
title: Personalizza le tabelle dati dei grafici nelle presentazioni usando Python
linktitle: Tabella dati
type: docs
url: /it/python-java/chart-data-table/
keywords:
- dati del grafico
- tabella dati
- proprietà del carattere
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Personalizza le tabelle dati dei grafici in Python per PPT e PPTX con Aspose.Slides per Python via Java per aumentare efficienza e attrattiva nelle presentazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con le tabelle dati dei grafici in Aspose.Slides. Mostra come visualizzare una tabella dati per un grafico e personalizzare la formattazione del testo impostando proprietà del carattere come lo stile grassetto e l'altezza del carattere. L'esempio dimostra la creazione di una presentazione, l'aggiunta di un grafico, l'abilitazione della tabella dati del grafico, l'applicazione delle impostazioni del carattere e il salvataggio della presentazione aggiornata.

Include anche brevi risposte a domande comuni su come mostrare le chiavi della legenda in una tabella dati del grafico, conservare la tabella dati durante l'esportazione, lavorare con grafici caricati da presentazioni o modelli esistenti e identificare i grafici in cui la tabella dati è abilitata.

## **Imposta le proprietà del carattere per una tabella dati del grafico**

Aspose.Slides per Python via Java consente di visualizzare la tabella dati di un grafico e modificare le proprietà del carattere del suo testo.

1. Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Aggiungi un grafico alla diapositiva.
1. Mostra la tabella dati del grafico.
1. Imposta lo stile grassetto e l'altezza del carattere del testo della tabella dati.
1. Salva la presentazione modificata.

Il seguente esempio dimostra questi passaggi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Crea una presentazione vuota.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso mostrare piccole chiavi della legenda accanto ai valori nella tabella dati del grafico?**

Sì. La tabella dati supporta le [legend keys](https://reference.aspose.com/slides/it/python-java/aspose.slides/datatable/#setShowLegendKey), e puoi attivarle o disattivarle.

**La tabella dati verrà conservata durante l'esportazione della presentazione in PDF, HTML o immagini?**

Sì. Aspose.Slides rende il grafico come parte della diapositiva, quindi il [PDF](/slides/it/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/it/python-java/convert-powerpoint-to-html/)/[image](/slides/it/python-java/convert-powerpoint-to-png/) esportato include il grafico con la sua tabella dati.

**Le tabelle dati sono supportate per i grafici provenienti da un file modello?**

Sì. Per qualsiasi grafico caricato da una presentazione o modello esistente, è possibile verificare e modificare se una tabella dati [is shown](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#hasDataTable), utilizzando le proprietà del grafico.

**Come posso trovare rapidamente quali grafici in un file hanno la tabella dati abilitata?**

Esamina la proprietà di ciascun grafico che indica se la tabella dati [is shown](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#hasDataTable), e passa in rassegna le diapositive per identificare i grafici in cui è abilitata.