---
title: Aggiungi forme di linea alle presentazioni in C++
linktitle: Linea
type: docs
weight: 50
url: /it/cpp/line/
keywords:
- linea
- creare linea
- aggiungere linea
- linea semplice
- configurare linea
- personalizzare linea
- stile tratteggiato
- punta della freccia
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Impara a manipolare la formattazione delle linee nelle presentazioni PowerPoint con Aspose.Slides per C++. Scopri proprietà, metodi ed esempi."
---
## **Panoramica**

Aspose.Slides consente di aggiungere forme di tipo linea alle diapositive PowerPoint in modo programmatico. Questo articolo mostra come creare una semplice linea e come personalizzarla affinché appaia come una freccia.

Imparerai come aggiungere una forma di tipo linea a una diapositiva, regolare il suo aspetto visivo e salvare la presentazione aggiornata. Gli esempi si concentrano su impostazioni pratiche di formattazione della linea, come stile, larghezza, tratteggio, opzioni di punta della freccia e colore di riempimento.

## **Crea una Linea Semplice**
Per aggiungere una semplice linea a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Crea un'istanza della[Presentation class](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
- Ottieni il riferimento a una diapositiva usando il suo indice.
- Aggiungi un'AutoShape di tipo Linea utilizzando il metodo[AddAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/addautoshape/)esposto dall'oggetto Shapes.
- Scrivi la presentazione modificata come file PPTX.

Nell'esempio riportato di seguito, abbiamo aggiunto una linea alla prima diapositiva della presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}


## **Crea una Linea a Forma di Freccia**
Aspose.Slides per C++ consente anche agli sviluppatori di configurare alcune proprietà della linea per renderla più attraente. Proviamo a configurare alcune proprietà della linea in modo che assomigli a una freccia. Segui i passaggi seguenti:

- Crea un'istanza della[Presentation class](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
- Ottieni il riferimento a una diapositiva usando il suo indice.
- Aggiungi un'AutoShape di tipo Linea utilizzando il metodo AddAutoShape esposto dall'oggetto Shapes.
- Imposta lo stile della linea su uno dei modelli offerti da Aspose.Slides per C++.
- Imposta la larghezza della linea.
- Imposta lo[Dash Style](https://reference.aspose.com/slides/it/cpp/aspose.slides/linedashstyle/)della linea su uno dei modelli offerti da Aspose.Slides per C++.
- Imposta lo[Arrow Head Style](https://reference.aspose.com/slides/it/cpp/aspose.slides/lineformat/)e la lunghezza del punto di partenza della linea.
- Imposta lo stile della punta e la lunghezza del punto finale della linea.
- Scrivi la presentazione modificata come file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **FAQ**

**Posso convertire una linea normale in un connettore in modo che "si agganci" alle forme?**

No. Una linea normale (un[AutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/autoshape/)di tipo[Line](https://reference.aspose.com/slides/it/cpp/aspose.slides/shapetype/)) non diventa automaticamente un connettore. Per farla agganciare alle forme, utilizza il tipo[Connector](https://reference.aspose.com/slides/it/cpp/aspose.slides/connector/)dedicato e le[corresponding APIs](/slides/it/cpp/connector/)per le connessioni.

**Cosa devo fare se le proprietà di una linea sono ereditate dal tema e risulta difficile determinare i valori finali?**

[Leggi le proprietà effettive](/slides/it/cpp/shape-effective-properties/)attraverso le interfacce[ILineFormatEffectiveData](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilinefillformateffectivedata/)—queste tengono già conto dell'ereditarietà e degli stili del tema.

**Posso bloccare una linea contro le modifiche (spostamento, ridimensionamento)?**

Sì. Le forme forniscono[lock objects](https://reference.aspose.com/slides/it/cpp/aspose.slides/autoshape/get_autoshapelock/)che consentono di[disallow editing operations](/slides/it/cpp/applying-protection-to-presentation/).