---
title: Gestire le porzioni di testo nelle presentazioni su Android
linktitle: Porzione di testo
type: docs
weight: 70
url: /it/androidjava/portion/
keywords:
- porzione di testo
- parte di testo
- coordinate del testo
- posizione del testo
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come gestire le porzioni di testo nelle presentazioni PowerPoint usando Aspose.Slides per Android via Java, migliorando le prestazioni e la personalizzazione."
---
## **Introduzione**

Una porzione di testo rappresenta un frammento specifico di testo all'interno di un paragrafo e consente di lavorare con quel frammento in modo indipendente dal contenuto circostante. In Aspose.Slides, le porzioni possono essere utilizzate quando è necessario recuperare la posizione di un frammento di testo, applicare la formattazione solo a una parte di un paragrafo o controllare il comportamento del testo a un livello più dettagliato.

## **Ottieni le coordinate di una porzione di testo**
[**getCoordinates()**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPortion#getCoordinates--) metodo è stato aggiunto alle classi [IPortion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/) e [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portion/) che consente di recuperare le coordinate dell'inizio della porzione.

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

Sì, è possibile [assegnare un collegamento ipertestuale](/slides/it/androidjava/manage-hyperlinks/) a una singola porzione; solo quel frammento sarà cliccabile, non l'intero paragrafo.

**Come funziona l'ereditarietà degli stili: cosa sovrascrive una Porzione e cosa viene preso dal Paragrafo/TextFrame?**

Le proprietà a livello di Porzione hanno la precedenza più alta. Se una proprietà non è impostata sulla [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portion/), il motore la recupera dal [Paragraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/paragraph/); se non è impostata nemmeno lì, la prende dal [TextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textframe/) o dallo stile del [theme](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/theme/).

**Cosa succede se il font specificato per una Porzione è assente sulla macchina/server di destinazione?**

Si applicano le [regole di sostituzione dei font](/slides/it/androidjava/font-selection-sequence/). Il testo potrebbe riorganizzarsi: le metriche, la sillabazione e la larghezza possono cambiare, il che è importante per un posizionamento preciso.

**Posso impostare una trasparenza o un gradiente di riempimento del testo specifici per una Porzione, indipendente dal resto del paragrafo?**

Sì, colore del testo, riempimento e trasparenza a livello di [Portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portion/) possono differire dai frammenti vicini.