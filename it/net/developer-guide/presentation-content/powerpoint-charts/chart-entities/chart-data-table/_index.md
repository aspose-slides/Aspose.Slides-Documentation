---
title: Personalizza le tabelle dati dei grafici nelle presentazioni in .NET
linktitle: Tabella dati
type: docs
url: /it/net/chart-data-table/
keywords:
- dati del grafico
- tabella dati
- proprietà del carattere
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Personalizza le tabelle dati dei grafici in .NET per PPT e PPTX con Aspose.Slides per aumentare efficienza e attrattiva nelle presentazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con le tabelle dati dei grafici in Aspose.Slides. Mostra come visualizzare una tabella dati per un grafico e personalizzare la formattazione del testo impostando le proprietà del carattere, come lo stile grassetto e l’altezza del carattere. L’esempio dimostra il caricamento di una presentazione, l’aggiunta di un grafico, l’abilitazione della tabella dati del grafico, l’applicazione delle impostazioni del carattere e il salvataggio della presentazione aggiornata.

Include anche risposte brevi a domande comuni sulla visualizzazione delle chiavi della legenda in una tabella dati del grafico, sulla conservazione della tabella dati durante l’esportazione, sul lavoro con i grafici caricati da presentazioni o modelli esistenti e sull’identificazione dei grafici in cui la tabella dati è abilitata.

## **Imposta le proprietà del carattere per una tabella dati del grafico**
Aspose.Slides per .NET fornisce il supporto per modificare il colore delle categorie in un colore di serie. 

1. Instanziare l’oggetto classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
1. Aggiungere un grafico alla diapositiva.
1. impostare la tabella del grafico.
1. Impostare l’altezza del carattere.
1. Salvare la presentazione modificata.

 Di seguito è riportato un esempio di codice. 

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Posso mostrare piccole chiavi della legenda accanto ai valori nella tabella dati del grafico?**

Sì. La tabella dati supporta le [legend keys](https://reference.aspose.com/slides/it/net/aspose.slides.charts/datatable/showlegendkey/), e puoi attivarle o disattivarle.

**La tabella dati verrà conservata quando si esporta la presentazione in PDF, HTML o immagini?**

Sì. Aspose.Slides rende il grafico come parte della diapositiva, quindi il [PDF](/slides/it/net/convert-powerpoint-to-pdf/)/[HTML](/slides/it/net/convert-powerpoint-to-html/)/[image](/slides/it/net/convert-powerpoint-to-png/) esportato include il grafico con la sua tabella dati.

**Le tabelle dati sono supportate per i grafici provenienti da un file modello?**

Sì. Per qualsiasi grafico caricato da una presentazione o modello esistente, puoi verificare e modificare se una tabella dati [is shown](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chart/hasdatatable/) utilizzando le proprietà del grafico.

**Come posso trovare rapidamente quali grafici in un file hanno la tabella dati abilitata?**

Ispeziona la proprietà di ciascun grafico che indica se la tabella dati [is shown](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chart/hasdatatable/) ed esegui l’iterazione attraverso le diapositive per identificare i grafici in cui è abilitata.