---
title: Personalizza le tabelle dei dati dei grafici nelle presentazioni usando C++
linktitle: Tabella dati
type: docs
url: /it/cpp/chart-data-table/
keywords:
- dati del grafico
- tabella dei dati
- proprietà del carattere
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Personalizza le tabelle dei dati dei grafici in C++ per PPT e PPTX con Aspose.Slides per aumentare l'efficienza e l'attrattiva nelle presentazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con le tabelle dei dati dei grafici in Aspose.Slides. Mostra come visualizzare una tabella dei dati per un grafico e personalizzare la formattazione del testo impostando proprietà del carattere come lo stile grassetto e l'altezza del carattere. L'esempio dimostra come caricare una presentazione, aggiungere un grafico, abilitare la tabella dei dati del grafico, applicare le impostazioni del carattere e salvare la presentazione aggiornata.

## **Imposta le proprietà del carattere per una tabella dei dati del grafico**
Aspose.Slides per C++ consente di modificare le proprietà del carattere per una tabella dei dati di un grafico.  

1. Istanziare l'oggetto della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
1. Aggiungere un grafico nella diapositiva.
1. Impostare la tabella del grafico.
1. Impostare l'altezza del carattere.
1. Salvare la presentazione modificata.

Di seguito è riportato un esempio di codice.  

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso mostrare piccole chiavi di legenda accanto ai valori nella tabella dei dati del grafico?**

Sì. La tabella dei dati supporta le [chiavi della legenda](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/datatable/set_showlegendkey/), e puoi attivarle o disattivarle.

**La tabella dei dati verrà conservata durante l'esportazione della presentazione in PDF, HTML o immagini?**

Sì. Aspose.Slides rende il grafico come parte della diapositiva, quindi il [PDF](/slides/it/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/it/cpp/convert-powerpoint-to-html/)/[image](/slides/it/cpp/convert-powerpoint-to-png/) esportato include il grafico con la sua tabella dei dati.

**Le tabelle dei dati sono supportate per i grafici provenienti da un file modello?**

Sì. Per qualsiasi grafico caricato da una presentazione o modello esistente, è possibile verificare e modificare se una tabella dei dati [è visualizzata](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chart/set_hasdatatable/) utilizzando le proprietà del grafico.

**Come posso trovare rapidamente quali grafici in un file hanno la tabella dei dati abilitata?**

Ispeziona la proprietà di ogni grafico che indica se la tabella dei dati [è visualizzata](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chart/get_hasdatatable/) e attraversa le diapositive per identificare i grafici in cui è abilitata.