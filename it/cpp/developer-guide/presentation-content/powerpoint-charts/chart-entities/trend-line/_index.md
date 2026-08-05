---
title: Aggiungi linee di tendenza ai grafici delle presentazioni in C++
linktitle: Linea di tendenza
type: docs
url: /it/cpp/trend-line/
keywords:
- grafico
- linea di tendenza
- linea di tendenza esponenziale
- linea di tendenza lineare
- linea di tendenza logaritmica
- linea di tendenza media mobile
- linea di tendenza polinomiale
- linea di tendenza di potenza
- linea di tendenza personalizzata
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Aggiungi e personalizza rapidamente le linee di tendenza nei grafici PowerPoint con Aspose.Slides per C++ — una guida pratica per coinvolgere il tuo pubblico."
---
## **Panoramica**

Questo articolo spiega come aggiungere linee di tendenza ai grafici delle presentazioni utilizzando Aspose.Slides. Mostra come creare un grafico, aggiungere linee di tendenza alle serie del grafico e lavorare con diversi tipi di linee di tendenza, tra cui esponenziale, lineare, logaritmica, media mobile, polinomiale e di potenza.

Descrive inoltre come aggiungere una linea personalizzata a un grafico inserendo una forma di linea e include una breve FAQ sui valori di proiezione della linea di tendenza avanti e indietro e sul fatto se le linee di tendenza vengano conservate durante l'esportazione in PDF o SVG e quando i grafici vengono renderizzati come immagini.

## **Aggiungere una linea di tendenza**
Aspose.Slides per C++ fornisce un'API semplice per gestire diverse linee di tendenza dei grafici:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Ottieni il riferimento di una diapositiva tramite il suo indice.
3. Aggiungi un grafico con dati predefiniti insieme a uno dei tipi desiderati (questo esempio utilizza ChartType.ClusteredColumn).
4. Aggiunta della linea di tendenza esponenziale per la serie 1 del grafico.
5. Aggiunta della linea di tendenza lineare per la serie 1 del grafico.
6. Aggiunta della linea di tendenza logaritmica per la serie 2 del grafico.
7. Aggiunta della linea di tendenza della media mobile per la serie 2 del grafico.
8. Aggiunta della linea di tendenza polinomiale per la serie 3 del grafico.
9. Aggiunta della linea di tendenza di potenza per la serie 3 del grafico.
10. Scrivi la presentazione modificata in un file PPTX.

Il codice seguente è usato per creare un grafico con linee di tendenza.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Aggiungere una linea personalizzata**
Aspose.Slides per C++ fornisce un'API semplice per aggiungere linee personalizzate in un grafico. Per aggiungere una semplice linea piana a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe Presentation
- Ottieni il riferimento di una diapositiva usando il suo indice
- Crea un nuovo grafico utilizzando il metodo AddChart esposto dall'oggetto Shapes
- Aggiungi un AutoShape di tipo Linea utilizzando il metodo AddAutoShape esposto dall'oggetto Shapes
- Imposta il colore delle linee della forma.
- Scrivi la presentazione modificata come file PPTX

Il codice seguente è usato per creare un grafico con linee personalizzate.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**Cosa significano 'forward' e 'backward' per una linea di tendenza?**

Sono le lunghezze della linea di tendenza proiettata in avanti/indietro: per i grafici a dispersione (XY) — in unità dell'asse; per i grafici non a dispersione — in numero di categorie. Sono consentiti solo valori non negativi.

**La linea di tendenza sarà conservata durante l'esportazione della presentazione in PDF o SVG, o quando si renderizza una diapositiva in un'immagine?**

Sì. Aspose.Slides converte le presentazioni in [PDF](/slides/it/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/it/cpp/render-a-slide-as-an-svg-image/) e renderizza i grafici in immagini; le linee di tendenza, come parte del grafico, vengono conservate durante queste operazioni. È disponibile anche un metodo per [esportare un'immagine del grafico](/slides/it/cpp/create-shape-thumbnails/) stesso.