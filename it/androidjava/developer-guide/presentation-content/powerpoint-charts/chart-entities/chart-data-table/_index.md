---
title: Personalizza le tabelle dati dei grafici nelle presentazioni su Android
linktitle: Tabella dati
type: docs
url: /it/androidjava/chart-data-table/
keywords:
- dati del grafico
- tabella dati
- proprietà del carattere
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Personalizza le tabelle dati dei grafici in Java per PPT e PPTX con Aspose.Slides per Android per aumentare l'efficienza e l'appeal nelle presentazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con le tabelle dati dei grafici in Aspose.Slides. Mostra come visualizzare una tabella dati per un grafico e personalizzare la formattazione del testo impostando proprietà del carattere come lo stile grassetto e l'altezza del carattere. L'esempio dimostra il caricamento di una presentazione, l'aggiunta di un grafico, l'abilitazione della tabella dati del grafico, l'applicazione delle impostazioni del carattere e il salvataggio della presentazione aggiornata.

## **Imposta le proprietà del carattere per una tabella dati del grafico**
Aspose.Slides for Android via Java offre il supporto per modificare il colore delle categorie in un colore di serie.  

1. Istanzia l'oggetto della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
1. Aggiungi un grafico nella diapositiva.
1. Imposta la tabella del grafico.
1. Imposta l'altezza del carattere.
1. Salva la presentazione modificata.

Di seguito è riportato un esempio.  

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

## **Domande frequenti**

**Posso mostrare piccole chiavi della legenda accanto ai valori nella tabella dati del grafico?**

Sì. La tabella dati supporta le [chiavi della legenda](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-), e puoi attivarle o disattivarle.

**La tabella dati verrà conservata durante l'esportazione della presentazione in PDF, HTML o immagini?**

Sì. Aspose.Slides rende il grafico come parte della diapositiva, quindi il [PDF](/slides/it/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/it/androidjava/convert-powerpoint-to-html/)/[immagine](/slides/it/androidjava/convert-powerpoint-to-png/) esportato includono il grafico con la sua tabella dati.

**Le tabelle dati sono supportate per i grafici provenienti da un file modello?**

Sì. Per qualsiasi grafico caricato da una presentazione o modello esistente, puoi verificare e modificare se una tabella dati [è visualizzata](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chart/#hasDataTable--) usando le proprietà del grafico.

**Come posso trovare rapidamente quali grafici in un file hanno la tabella dati abilitata?**

Esamina la proprietà di ciascun grafico che indica se la tabella dati [è visualizzata](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chart/#hasDataTable--) e itera le diapositive per identificare i grafici in cui è abilitata.