---
title: Gestire i callout nei grafici delle presentazioni usando C++
linktitle: Callout
type: docs
url: /it/cpp/callout/
keywords:
- callout grafico
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

Questo articolo spiega come gestire i callout per le etichette dei dati dei grafici in Aspose.Slides. Mostra come utilizzare il metodo `set_ShowLabelAsDataCallout` per visualizzare le etichette come callout, come configurare le impostazioni delle etichette relative ai callout per un grafico a ciambella e osserva che i callout e il loro aspetto vengono conservati quando le presentazioni vengono esportate in PDF, HTML5, SVG e formati di immagine raster.

## **Utilizzo dei Callout**
È stata aggiunta la nuova proprietà **ShowLabelAsDataCallout** alla classe **DataLabelFormat** e all'interfaccia **IDataLabelFormat**, che determina se l'etichetta dei dati di un grafico specificato verrà visualizzata come callout o come etichetta normale. Nell'esempio riportato di seguito, abbiamo impostato i Callout.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Imposta un Callout per un grafico Doughnut**
Aspose.Slides per C++ fornisce il supporto per impostare la forma del callout dell'etichetta dei dati di una serie per un grafico Doughnut. Di seguito è riportato un esempio.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**I callout vengono conservati quando si converte una presentazione in PDF, HTML5, SVG o immagini?**

Sì. I callout fanno parte del rendering del grafico, quindi quando si esporta in [PDF](/slides/it/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/it/cpp/export-to-html5/), [SVG](/slides/it/cpp/render-a-slide-as-an-svg-image/), o [immagini raster](/slides/it/cpp/convert-powerpoint-to-png/), vengono conservati insieme alla formattazione della diapositiva.

**I font personalizzati funzionano nei callout e il loro aspetto può essere conservato durante l'esportazione?**

Sì. Aspose.Slides supporta [l'incorporamento dei font](/slides/it/cpp/embedded-font/) nella presentazione e controlla l'incorporamento dei font durante esportazioni come [PDF](/slides/it/cpp/convert-powerpoint-to-pdf/), garantendo che i callout mantengano lo stesso aspetto su sistemi diversi.