---
title: Gestire le porzioni di testo nelle presentazioni con Java
linktitle: Porzione di testo
type: docs
weight: 70
url: /it/java/portion/
keywords:
- porzione di testo
- parte di testo
- coordinate del testo
- posizione del testo
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come gestire le porzioni di testo nelle presentazioni PowerPoint usando Aspose.Slides per Java, migliorando le prestazioni e la personalizzazione."
---
## **Panoramica**

Una porzione di testo rappresenta un frammento specifico di testo all'interno di un paragrafo e consente di lavorare con quel frammento in modo indipendente dal contenuto circostante. In Aspose.Slides, le porzioni possono essere utilizzate quando è necessario recuperare la posizione di un frammento di testo, applicare formattazione solo a una parte di un paragrafo o controllare il comportamento del testo a un livello più dettagliato.

Questo articolo mostra come ottenere le coordinate dell'inizio di una porzione utilizzando il metodo `getCoordinates()`. Evidenzia inoltre scenari comuni legati alle porzioni, come l'applicazione di un collegamento ipertestuale a un singolo frammento di testo, la comprensione di come la formattazione venga risolta attraverso l'ereditarietà di porzione, paragrafo, text frame e tema, e la gestione dei casi in cui un font specificato non è disponibile. Inoltre, segnala che il riempimento del testo, il colore e la trasparenza possono essere impostati in modo diverso per singole porzioni all'interno dello stesso paragrafo.

## **Ottieni le coordinate di una porzione di testo**
Il metodo [**getCoordinates()**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPortion#getCoordinates--) è stato aggiunto alle classi [IPortion](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/) e [Portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/portion/), che consente di recuperare le coordinate dell'inizio della porzione.

```java
// Istanziare la classe Presentation che rappresenta il PPTX
Presentation pres = new Presentation();
try {
    // Rimodellare il contesto della presentazione
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso applicare un collegamento ipertestuale solo a una parte del testo all'interno di un singolo paragrafo?**

Sì, è possibile [assegnare un collegamento ipertestuale](/slides/it/java/manage-hyperlinks/) a una singola porzione; solo quel frammento sarà cliccabile, non l'intero paragrafo.

**Come funziona l'ereditarietà degli stili: cosa sovrascrive una Portion e cosa viene ereditato da Paragraph/TextFrame?**

Le proprietà a livello di Portion hanno la precedenza più alta. Se una proprietà non è impostata sulla [Portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/portion/), il motore la prende dal [Paragraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraph/); se non è impostata neanche lì, dal [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframe/) o dallo stile del [theme](https://reference.aspose.com/slides/it/java/com.aspose.slides/theme/).

**Cosa succede se il font specificato per una Portion è assente sulla macchina/server di destinazione?**

Si applicano le [regole di sostituzione dei font](/slides/it/java/font-selection-sequence/). Il testo potrebbe riformattarsi: metriche, sillabazione e larghezza possono cambiare, il che è importante per un posizionamento preciso.

**Posso impostare la trasparenza o il gradiente di riempimento del testo a livello di Portion indipendentemente dal resto del paragrafo?**

Sì, colore del testo, riempimento e trasparenza a livello di [Portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/portion/) possono differire dai frammenti vicini.