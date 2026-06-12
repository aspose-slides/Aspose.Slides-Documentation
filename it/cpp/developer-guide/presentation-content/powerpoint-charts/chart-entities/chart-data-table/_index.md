---
title: Personalizzare le tabelle dati dei grafici nelle presentazioni usando C++
linktitle: Tabella dati
type: docs
url: /it/cpp/chart-data-table/
keywords:
- dati del grafico
- tabella dati
- proprietà del carattere
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Personalizza le tabelle dati dei grafici in C++ per PPT e PPTX con Aspose.Slides per aumentare efficienza e appeal nelle presentazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con le tabelle dati dei grafici in Aspose.Slides. Mostra come visualizzare una tabella dati per un grafico e personalizzare la formattazione del testo impostando proprietà del carattere come lo stile grassetto e l’altezza del carattere. L’esempio dimostra il caricamento di una presentazione, l’aggiunta di un grafico, l’abilitazione della tabella dati del grafico, l’applicazione delle impostazioni del carattere e il salvataggio della presentazione aggiornata.

## **Impostare le proprietà del carattere per una tabella dati del grafico**
Aspose.Slides per C++ consente di modificare le proprietà del carattere per una tabella dati del grafico.  

1. Instanziare l’oggetto della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
1. Aggiungere un grafico alla diapositiva.
1. Impostare la tabella del grafico.
1. Impostare l’altezza del carattere.
1. Salvare la presentazione modificata.

Di seguito è fornito un esempio di codice.  

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso mostrare piccole chiavi di legenda accanto ai valori nella tabella dati del grafico?**

Sì. La tabella dati supporta le [chiavi di legenda](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/datatable/set_showlegendkey/), e puoi attivarle o disattivarle.

**La tabella dati verrà preservata quando si esporta la presentazione in PDF, HTML o immagini?**

Sì. Aspose.Slides rende il grafico come parte della diapositiva, quindi il [PDF](/slides/it/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/it/cpp/convert-powerpoint-to-html/)/[immagine](/slides/it/cpp/convert-powerpoint-to-png/) esportato include il grafico con la sua tabella dati.

**Le tabelle dati sono supportate per i grafici provenienti da un file modello?**

Sì. Per qualsiasi grafico caricato da una presentazione o da un modello esistente, è possibile verificare e modificare se una tabella dati [è mostrata](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chart/set_hasdatatable/) usando le proprietà del grafico.

**Come posso trovare rapidamente quali grafici in un file hanno la tabella dati abilitata?**

Esamina la proprietà di ciascun grafico che indica se la tabella dati [è mostrata](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chart/get_hasdatatable/) e scorre le diapositive per identificare i grafici in cui è abilitata.