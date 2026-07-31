---
title: Personalizza grafici 3D nelle presentazioni usando C++
linktitle: Grafico 3D
type: docs
url: /it/cpp/3d-chart/
keywords:
- grafico 3D
- rotazione
- profondità
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come creare e personalizzare grafici 3-D in Aspose.Slides per C++, con supporto per file PPT e PPTX—potenzia le tue presentazioni oggi."
---
## **Panoramica**

Questo articolo spiega come personalizzare un grafico 3D in Aspose.Slides configurando le impostazioni `Rotation3D` come `RotationX`, `RotationY`, `DepthPercents` e `RightAngleAxes`. Descrive la creazione di una presentazione, l'aggiunta di un grafico 3D con dati predefiniti, l'applicazione delle impostazioni di visualizzazione 3D richieste e il salvataggio della presentazione modificata come file PPTX.

## **Impostare le proprietà RotationX, RotationY e DepthPercents di un grafico 3D**
Aspose.Slides per C++ fornisce un’API semplice per impostare queste proprietà. Questo articolo ti aiuterà a impostare diverse proprietà come rotazione X, Y, **DepthPercents** ecc. Il codice di esempio applica le impostazioni delle suddette proprietà.

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Accedere alla prima diapositiva.
1. Aggiungere un grafico con dati predefiniti.
1. Impostare le proprietà Rotation3D.
1. Scrivere la presentazione modificata in un file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **FAQ**

**Quali tipi di grafico supportano la modalità 3D in Aspose.Slides?**

Aspose.Slides supporta varianti 3D dei grafici a colonne, inclusi Column 3D, Clustered Column 3D, Stacked Column 3D e 100 % Stacked Column 3D, oltre ai relativi tipi 3D esposti tramite l’enumerazione [ChartType](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/charttype/). Per un elenco preciso e aggiornato, verifica i membri di [ChartType](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/charttype/) nella documentazione API della tua versione installata.

**Posso ottenere un’immagine raster di un grafico 3D per un report o il Web?**

Sì. Puoi esportare un grafico in un’immagine tramite l’[API del grafico](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/getimage/) o [renderizzare l’intera diapositiva](/slides/it/cpp/convert-powerpoint-to-png/) in formati come PNG o JPEG. Questo è utile quando hai bisogno di un’anteprima pixel‑perfect o vuoi incorporare il grafico in documenti, dashboard o pagine Web senza richiedere PowerPoint.

**Qual è l’efficienza nella creazione e nel rendering di grandi grafici 3D?**

Le prestazioni dipendono dal volume dei dati e dalla complessità visiva. Per ottenere i migliori risultati, mantieni gli effetti 3D al minimo, evita texture pesanti su pareti e aree del grafico, limita il numero di punti dati per serie quando possibile e rendi l’output a una risoluzione e dimensioni adeguate al display o alla stampa target.