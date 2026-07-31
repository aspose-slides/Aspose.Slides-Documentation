---
title: Gestire i Callout nei Grafici delle Presentazioni con C++
linktitle: Callout
type: docs
url: /it/cpp/callout/
keywords:
- callout del grafico
- utilizzare callout
- etichetta dati
- formato etichetta
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Crea e formatta i callout in Aspose.Slides per C++ con esempi di codice concisi, compatibili con PPT e PPTX per automatizzare i flussi di lavoro delle presentazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con i callout per le etichette dei dati del grafico in Aspose.Slides. Mostra come utilizzare il metodo `set_ShowLabelAsDataCallout` per visualizzare le etichette come callout, come configurare le impostazioni delle etichette relative ai callout per un grafico a ciambella e indica che i callout e il loro aspetto sono preservati quando le presentazioni vengono esportate in PDF, HTML5, SVG e formati di immagine raster.

## **Utilizzo dei Callout**
È stata aggiunta una nuova proprietà **ShowLabelAsDataCallout** alla classe **DataLabelFormat** e all'interfaccia **IDataLabelFormat**, che determina se l'etichetta dati del grafico specificato verrà visualizzata come callout dati o come etichetta dati. Nell'esempio riportato di seguito, abbiamo impostato i Callout.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Impostare un Callout per un Grafico a Ciambella**
Aspose.Slides per C++ fornisce il supporto per impostare la forma del callout dell'etichetta dati della serie per un grafico a ciambella. Di seguito è riportato un esempio.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**I callout vengono conservati durante la conversione di una presentazione in PDF, HTML5, SVG o immagini?**

Sì. I callout fanno parte del rendering del grafico, quindi quando si esporta in [PDF](/slides/it/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/it/cpp/export-to-html5/), [SVG](/slides/it/cpp/render-a-slide-as-an-svg-image/) o [immagini raster](/slides/it/cpp/convert-powerpoint-to-png/), vengono conservati insieme alla formattazione della diapositiva.

**I caratteri personalizzati funzionano nei callout e la loro visualizzazione può essere preservata durante l'esportazione?**

Sì. Aspose.Slides supporta [incorporamento di caratteri](/slides/it/cpp/embedded-font/) nella presentazione e gestisce l'incorporamento dei caratteri durante le esportazioni, come ad esempio in [PDF](/slides/it/cpp/convert-powerpoint-to-pdf/), garantendo che i callout abbiano lo stesso aspetto su sistemi diversi.