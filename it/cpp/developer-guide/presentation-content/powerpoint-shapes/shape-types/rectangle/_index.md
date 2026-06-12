---
title: Aggiungi rettangoli alle presentazioni in C++
linktitle: Rettangolo
type: docs
weight: 80
url: /it/cpp/rectangle/
keywords:
- aggiungere rettangolo
- creare rettangolo
- forma rettangolo
- rettangolo semplice
- rettangolo formattato
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Migliora le tue presentazioni PowerPoint aggiungendo rettangoli con Aspose.Slides per C++ — progetta e modifica facilmente le forme in modo programmatico."
---
## **Panoramica**

Questo articolo mostra come aggiungere forme rettangolari alle diapositive PowerPoint utilizzando Aspose.Slides. Copre la creazione di un rettangolo semplice, la creazione di un rettangolo formattato e il salvataggio della presentazione aggiornata come file PPTX.

## **Crea un rettangolo semplice**
Come nei temi precedenti, anche questo riguarda l'aggiunta di una forma e questa volta la forma di cui parleremo è Rettangolo. In questo argomento abbiamo descritto come gli sviluppatori possano aggiungere rettangoli semplici o formattati alle loro diapositive utilizzando Aspose.Slides per C++. Per aggiungere un rettangolo semplice a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation class](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni il riferimento di una diapositiva utilizzando il suo indice.
1. Aggiungi un IAutoShape di tipo Rectangle usando il metodo AddAutoShape esposto dall'oggetto IShapes.
1. Scrivi la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo aggiunto un rettangolo semplice alla prima diapositiva della presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **Crea un rettangolo formattato**
Per aggiungere un rettangolo formattato a una diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation class](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni il riferimento di una diapositiva utilizzando il suo indice.
1. Aggiungi un IAutoShape di tipo Rectangle usando il metodo AddAutoShape esposto dall'oggetto IShapes.
1. Imposta il tipo di riempimento del rettangolo su Solido.
1. Imposta il colore del rettangolo utilizzando la proprietà SolidFillColor.Color esposta dall'oggetto FillFormat associato all'oggetto IShape.
1. Imposta il colore delle linee del rettangolo.
1. Imposta lo spessore delle linee del rettangolo.
1. Scrivi la presentazione modificata come file PPTX.
   I passaggi sopra indicati sono implementati nell'esempio mostrato di seguito.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **FAQ**

**Come aggiungo un rettangolo con angoli arrotondati?**

Utilizza il [tipo di forma](https://reference.aspose.com/slides/it/cpp/aspose.slides/shapetype/) con angoli arrotondati e regola il raggio degli angoli nelle proprietà della forma; l'arrotondamento può essere applicato anche per singolo angolo tramite le regolazioni geometriche.

**Come riempio un rettangolo con un'immagine (texture)?**

Seleziona il [tipo di riempimento](https://reference.aspose.com/slides/it/cpp/aspose.slides/filltype/) immagine, fornisci la sorgente dell'immagine e configura le [modalità di stretching/tiling](https://reference.aspose.com/slides/it/cpp/aspose.slides/picturefillmode/).

**Un rettangolo può avere ombra e bagliore?**

Sì. Sono disponibili [ombreggiature esterne/interne, bagliore ed edging morbido](/slides/it/cpp/shape-effect/) con parametri regolabili.

**Posso trasformare un rettangolo in un pulsante con un collegamento ipertestuale?**

Sì. [Assegna un collegamento ipertestuale](/slides/it/cpp/manage-hyperlinks/) al click della forma (salto a una diapositiva, file, indirizzo web o e‑mail).

**Come posso proteggere un rettangolo da spostamenti e modifiche?**

[Utilizza i blocchi della forma](/slides/it/cpp/applying-protection-to-presentation/): è possibile vietare lo spostamento, il ridimensionamento, la selezione o la modifica del testo per preservare il layout.

**Posso convertire un rettangolo in un'immagine raster o SVG?**

Sì. Puoi [renderizzare la forma](http://reference.aspose.com/slides/it/cpp/aspose.slides/shape/getimage/) in un'immagine con dimensione/scala specificata oppure [esportarla come SVG](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/writeassvg/) per utilizzo vettoriale.

**Come ottengo rapidamente le proprietà effettive di un rettangolo considerando tema ed ereditarietà?**

[Utilizza le proprietà effettive della forma](/slides/it/cpp/shape-effective-properties/): l'API restituisce i valori calcolati che tengono conto degli stili del tema, del layout e delle impostazioni locali, semplificando l'analisi della formattazione.