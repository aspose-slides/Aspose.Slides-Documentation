---
title: Personalizza i grafici a torta nelle presentazioni usando C++
linktitle: Grafico a torta
type: docs
url: /it/cpp/pie-chart/
keywords:
- grafico a torta
- gestire il grafico
- personalizzare il grafico
- opzioni del grafico
- impostazioni del grafico
- opzioni di tracciato
- colore della fetta
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come creare e personalizzare grafici a torta in C++ con Aspose.Slides, esportabili in PowerPoint, migliorando la narrazione dei dati in pochi secondi."
---
## **Panoramica**

Questo articolo spiega come lavorare con i grafici a torta in Aspose.Slides. Mostra come configurare le opzioni di tracciato secondario per i grafici Pie of Pie e Bar of Pie e come abilitare la colorazione automatica delle fette per un grafico a torta standard.

Gli esempi si concentrano su passaggi pratici di personalizzazione del grafico, come aggiungere un grafico a una diapositiva, regolare le impostazioni delle serie e delle etichette, sostituire i dati predefiniti del grafico con categorie e valori personalizzati e salvare la presentazione aggiornata.

## **Opzioni di Secondo Tracciato per Grafici Pie of Pie e Bar of Pie**
Aspose.Slides per C++ ora supporta le opzioni di secondo tracciato per i grafici Pie of Pie o Bar of Pie. In questo argomento vedremo, con un esempio, come specificare queste opzioni usando Aspose.Slides. Per specificare le proprietà, segui i passaggi seguenti:

1. Istanziare l'oggetto classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Aggiungere un grafico alla diapositiva.
1. Specificare le opzioni di secondo tracciato del grafico.
1. Scrivere la presentazione su disco.

Nell'esempio riportato di seguito, abbiamo impostato diverse proprietà del grafico Pie of Pie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **Imposta i Colori Automatici delle Fette del Grafico a Torta**
Aspose.Slides per C++ fornisce un'API semplice per impostare i colori automatici delle fette del grafico a torta. Il codice di esempio applica le proprietà sopra indicate.

1. Creare un'istanza della classe Presentation.
1. Accedere alla prima diapositiva.
1. Aggiungere un grafico con dati predefiniti.
1. Impostare il titolo del grafico.
1. Impostare la prima serie per mostrare i valori.
1. Impostare l'indice del foglio dati del grafico.
1. Ottenere il foglio di lavoro dei dati del grafico.
1. Eliminare le serie e le categorie generate di default.
1. Aggiungere nuove categorie.
1. Aggiungere nuove serie.

Scrivere la presentazione modificata in un file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**Le varianti 'Pie of Pie' e 'Bar of Pie' sono supportate?**

Sì, la libreria [supports](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/charttype/) un tracciato secondario per i grafici a torta, incluse le tipologie 'Pie of Pie' e 'Bar of Pie'.

**Posso esportare solo il grafico come immagine (ad esempio PNG)?**

Sì, è possibile [export the chart itself as an image](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/getimage/) (ad esempio PNG) senza l'intera presentazione.