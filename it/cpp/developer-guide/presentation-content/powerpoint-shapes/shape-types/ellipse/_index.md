---
title: Aggiungere ellissi alle presentazioni in C++
linktitle: Ellisse
type: docs
weight: 30
url: /it/cpp/ellipse/
keywords:
- ellisse
- forma
- aggiungi ellisse
- crea ellisse
- disegna ellisse
- ellisse formattata
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Impara come creare, formattare e manipolare forme ellittiche in Aspose.Slides per C++ su presentazioni PPT e PPTX — esempi di codice C++ inclusi."
---
## **Panoramica**

Questo articolo mostra come aggiungere forme ellittiche alle diapositive PowerPoint utilizzando Aspose.Slides. Copre la creazione di un'ellisse semplice, la creazione di un'ellisse formattata e il salvataggio della presentazione aggiornata come file PPTX. Affronta anche domande correlate, come la gestione della posizione e delle dimensioni dell'ellisse, il controllo dell'ordine di sovrapposizione e l'applicazione di effetti di animazione.

## **Creare un'ellisse**
In questo argomento, introdurremo gli sviluppatori all'aggiunta di forme ellittiche alle loro diapositive utilizzando Aspose.Slides per C++. Aspose.Slides per C++ offre un insieme più semplice di API per disegnare diversi tipi di forme con poche righe di codice. Per aggiungere un'ellisse semplice a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

1. Crea un'istanza della [classe Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/)
1. Ottieni il riferimento di una diapositiva usando il suo indice
1. Aggiungi un AutoShape di tipo Ellipse usando il metodo AddAutoShape esposto dall'oggetto IShapes
1. Scrivi la presentazione modificata come file PPTX

Nell'esempio mostrato di seguito, abbiamo aggiunto un'ellisse alla prima diapositiva.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}

## **Creare un'ellisse formattata**
Per aggiungere un'ellisse meglio formattata a una diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della [classe Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni il riferimento di una diapositiva usando il suo indice.
1. Aggiungi un AutoShape di tipo Ellipse usando il metodo AddAutoShape esposto dall'oggetto IShapes.
1. Imposta il tipo di riempimento dell'ellisse su Solid.
1. Imposta il colore dell'ellisse usando la proprietà SolidFillColor.Color esposta dall'oggetto FillFormat associato all'oggetto IShape.
1. Imposta il colore delle linee dell'ellisse.
1. Imposta la larghezza delle linee dell'ellisse.
1. Scrivi la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo aggiunto un'ellisse formattata alla prima diapositiva della presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}

## **FAQ**

**Come posso impostare la posizione e le dimensioni esatte di un'ellisse rispetto alle unità della diapositiva?**

Le coordinate e le dimensioni sono tipicamente specificate **in punti**. Per ottenere risultati prevedibili, basa i calcoli sulla dimensione della diapositiva e converti i millimetri o i pollici necessari in punti prima di assegnare i valori.

**Come posso posizionare un'ellisse sopra o sotto altri oggetti (controllare l'ordine di sovrapposizione)?**

Regola l'ordine di disegno dell'oggetto portandolo in primo piano o inviandolo sullo sfondo. Ciò consente all'ellisse di sovrapporsi ad altri oggetti o di rivelare quelli sottostanti.

**Come animare l'apparizione o l'enfasi di un'ellisse?**

[Applica](/slides/it/cpp/shape-animation/) effetti di entrata, enfasi o uscita alla forma, e configura trigger e tempistiche per orchestrare quando e come l'animazione viene eseguita.