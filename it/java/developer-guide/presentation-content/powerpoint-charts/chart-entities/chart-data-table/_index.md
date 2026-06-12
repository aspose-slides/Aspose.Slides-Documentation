---
title: Personalizza le tabelle dei dati dei grafici nelle presentazioni usando Java
linktitle: Tabella dati
type: docs
url: /it/java/chart-data-table/
keywords:
- dati del grafico
- tabella dati
- proprietà del carattere
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Personalizza le tabelle dei dati dei grafici in Java per PPT e PPTX con Aspose.Slides per aumentare efficienza e attrattiva nelle presentazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con le tabelle dei dati dei grafici in Aspose.Slides. Mostra come visualizzare una tabella dei dati per un grafico e personalizzarne la formattazione del testo impostando proprietà del carattere come lo stile grassetto e l’altezza del carattere. L’esempio dimostra come caricare una presentazione, aggiungere un grafico, abilitare la tabella dei dati del grafico, applicare le impostazioni del carattere e salvare la presentazione aggiornata.

Include anche brevi risposte alle domande comuni su come mostrare le chiavi della leggenda in una tabella dei dati del grafico, conservare la tabella dei dati durante l’esportazione, lavorare con grafici caricati da presentazioni o modelli esistenti e identificare i grafici in cui la tabella dei dati è abilitata.

## **Imposta le proprietà del carattere per una tabella dei dati del grafico**
Aspose.Slides per Java offre il supporto per modificare il colore delle categorie in un colore di serie.  

1. Istanziare l’oggetto classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Aggiungere un grafico alla diapositiva.
1. impostare la tabella del grafico.
1. Impostare l’altezza del carattere.
1. Salvare la presentazione modificata.

Di seguito è riportato un esempio di codice.  

```java
// Creazione di una presentazione vuota
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso mostrare piccole chiavi della leggenda accanto ai valori nella tabella dei dati del grafico?**

Sì. La tabella dei dati supporta le [chiavi della leggenda](https://reference.aspose.com/slides/it/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-), ed è possibile attivarle o disattivarle.

**La tabella dei dati verrà conservata durante l’esportazione della presentazione in PDF, HTML o immagini?**

Sì. Aspose.Slides rende il grafico come parte della diapositiva, quindi il [PDF](/slides/it/java/convert-powerpoint-to-pdf/)/[HTML](/slides/it/java/convert-powerpoint-to-html/)/[immagine](/slides/it/java/convert-powerpoint-to-png/) esportato include il grafico con la sua tabella dei dati.

**Le tabelle dei dati sono supportate per i grafici provenienti da un file modello?**

Sì. Per qualsiasi grafico caricato da una presentazione o da un modello esistente, è possibile verificare e modificare se una tabella dei dati [è mostrata](https://reference.aspose.com/slides/it/java/com.aspose.slides/chart/#hasDataTable--) usando le proprietà del grafico.

**Come posso trovare rapidamente quali grafici in un file hanno la tabella dei dati abilitata?**

Esaminare la proprietà di ciascun grafico che indica se la tabella dei dati [è mostrata](https://reference.aspose.com/slides/it/java/com.aspose.slides/chart/#hasDataTable--) e iterare le diapositive per identificare i grafici in cui è abilitata.