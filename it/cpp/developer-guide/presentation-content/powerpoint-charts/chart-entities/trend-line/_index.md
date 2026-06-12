---
title: Aggiungere linee di tendenza ai grafici di presentazione in С++
linktitle: Linea di tendenza
type: docs
url: /it/cpp/trend-line/
keywords:
- grafico
- linea di tendenza
- linea di tendenza esponenziale
- linea di tendenza lineare
- linea di tendenza logaritmica
- linea di tendenza a media mobile
- linea di tendenza polinomiale
- linea di tendenza di potenza
- linea di tendenza personalizzata
- PowerPoint
- presentazione
- С++
- Aspose.Slides
description: "Aggiungi e personalizza rapidamente le linee di tendenza nei grafici PowerPoint con Aspose.Slides per С++ — una guida pratica per coinvolgere il tuo pubblico."
---
## **Panoramica**

Questo articolo spiega come aggiungere linee di tendenza ai grafici di presentazione utilizzando Aspose.Slides. Mostra come creare un grafico, aggiungere linee di tendenza alle serie del grafico e lavorare con diversi tipi di linee di tendenza, tra cui esponenziale, lineare, logaritmica, media mobile, polinomiale e potenza.

Descrive inoltre come aggiungere una linea personalizzata a un grafico inserendo una forma linea e include una breve FAQ su cosa significano i valori di proiezione “forward” e “backward” di una linea di tendenza e se le linee di tendenza sono conservate durante l’esportazione in PDF o SVG e durante il rendering dei grafici come immagini.

## **Aggiungere una linea di tendenza**
Aspose.Slides per C++ fornisce un’API semplice per gestire le diverse Linee di Tendenza dei grafici:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Ottenere il riferimento di una diapositiva mediante il suo indice.
3. Aggiungere un grafico con dati predefiniti insieme a qualsiasi tipo desiderato (in questo esempio viene usato ChartType.ClusteredColumn).
4. Aggiungere la linea di tendenza esponenziale per la serie 1 del grafico.
5. Aggiungere una linea di tendenza lineare per la serie 1 del grafico.
6. Aggiungere una linea di tendenza logaritmica per la serie 2 del grafico.
7. Aggiungere una linea di tendenza a media mobile per la serie 2 del grafico.
8. Aggiungere una linea di tendenza polinomiale per la serie 3 del grafico.
9. Aggiungere una linea di tendenza di potenza per la serie 3 del grafico.
10. Scrivere la presentazione modificata in un file PPTX.

Il codice seguente è usato per creare un grafico con linee di tendenza.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Aggiungere una linea personalizzata**
Aspose.Slides per C++ fornisce un’API semplice per aggiungere linee personalizzate in un grafico. Per aggiungere una semplice linea piana a una diapositiva selezionata della presentazione, seguire i passaggi seguenti:

- Creare un'istanza della classe Presentation
- Ottenere il riferimento di una diapositiva utilizzando il suo indice
- Creare un nuovo grafico utilizzando il metodo AddChart esposto dall'oggetto Shapes
- Aggiungere un AutoShape di tipo Linea usando il metodo AddAutoShape esposto dall'oggetto Shapes
- Impostare il colore delle linee della forma.
- Scrivere la presentazione modificata come file PPTX

Il codice seguente è usato per creare un grafico con linee personalizzate.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**Cosa significano 'forward' e 'backward' per una linea di tendenza?**

Sono le lunghezze della linea di tendenza proiettata avanti/indietro: per i grafici a dispersione (XY) — in unità dell'asse; per i grafici non a dispersione — in numero di categorie. Sono consentiti solo valori non negativi.

**La linea di tendenza verrà preservata durante l'esportazione della presentazione in PDF o SVG, o durante il rendering di una diapositiva in un'immagine?**

Sì. Aspose.Slides converte le presentazioni in [PDF](/slides/it/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/it/cpp/render-a-slide-as-an-svg-image/) e rende i grafici in immagini; le linee di tendenza, come parte del grafico, vengono preservate durante queste operazioni. È disponibile anche un metodo per [esportare un'immagine del grafico](/slides/it/cpp/create-shape-thumbnails/) stesso.