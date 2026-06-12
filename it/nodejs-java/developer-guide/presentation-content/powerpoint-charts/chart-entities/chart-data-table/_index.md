---
title: Personalizza le tabelle dei dati dei grafici nelle presentazioni usando JavaScript
linktitle: Tabella dati
type: docs
url: /it/nodejs-java/chart-data-table/
keywords:
- dati del grafico
- tabella dati
- proprietà del carattere
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Personalizza le tabelle dei dati dei grafici in JavaScript per PPT e PPTX con Aspose.Slides per Node.js via Java per aumentare efficienza e attrattiva nelle presentazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con le tabelle dei dati dei grafici in Aspose.Slides. Mostra come visualizzare una tabella dei dati per un grafico e personalizzare la formattazione del testo impostando le proprietà del font, come lo stile grassetto e l'altezza del carattere. L'esempio dimostra come caricare una presentazione, aggiungere un grafico, abilitare la tabella dei dati del grafico, applicare le impostazioni del font e salvare la presentazione aggiornata.

Include anche brevi risposte a domande comuni su come mostrare le chiavi della legenda in una tabella dei dati del grafico, preservare la tabella dei dati durante l'esportazione, lavorare con grafici caricati da presentazioni o modelli esistenti e identificare i grafici in cui la tabella dei dati è abilitata.

## **Imposta le proprietà del font per la tabella dei dati del grafico**

Aspose.Slides per Node.js via Java fornisce il supporto per cambiare il colore delle categorie in una serie di colori. 

1. Istanziare l'oggetto della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) .
1. Aggiungere un grafico nella diapositiva.
1. Impostare la tabella del grafico.
1. Impostare l'altezza del font.
1. Salvare la presentazione modificata.

Di seguito è fornito un esempio. 

```javascript
// Creazione di una presentazione vuota
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso mostrare piccole chiavi della legenda accanto ai valori nella tabella dei dati del grafico?**

Sì. La tabella dei dati supporta le [chiavi della legenda](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/datatable/setshowlegendkey/) e puoi attivarle o disattivarle.

**La tabella dei dati verrà preservata durante l'esportazione della presentazione in PDF, HTML o immagini?**

Sì. Aspose.Slides rende il grafico come parte della diapositiva, quindi il [PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/it/nodejs-java/convert-powerpoint-to-html/)/[immagine](/slides/it/nodejs-java/convert-powerpoint-to-png/) esportato include il grafico con la sua tabella dei dati.

**Le tabelle dei dati sono supportate per i grafici provenienti da un file modello?**

Sì. Per qualsiasi grafico caricato da una presentazione o modello esistente, è possibile verificare e modificare se una tabella dei dati [è visualizzata](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/hasdatatable/) utilizzando le proprietà del grafico.

**Come posso trovare rapidamente quali grafici in un file hanno la tabella dei dati abilitata?**

Esaminare la proprietà di ciascun grafico che indica se la tabella dei dati [è visualizzata](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/hasdatatable/) e scorrere le diapositive per identificare i grafici in cui è abilitata.