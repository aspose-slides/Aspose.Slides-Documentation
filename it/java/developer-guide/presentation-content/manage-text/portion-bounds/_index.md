---
title: Ottenere i limiti della porzione di testo dalle presentazioni in Java
linktitle: Limiti della porzione
type: docs
weight: 47
url: /it/java/portion-bounds/
keywords:
- limiti della porzione di testo
- porzione di testo
- parte di testo
- coordinate del testo
- posizione del testo
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come recuperare i limiti della porzione di testo nelle presentazioni PowerPoint utilizzando Aspose.Slides per Java."
---
## **Panoramica**

Una porzione di testo rappresenta un frammento specifico di testo all'interno di un paragrafo e consente di lavorare con quel frammento in modo indipendente dal contenuto circostante. In Aspose.Slides, le porzioni possono essere utilizzate quando è necessario recuperare i limiti di un frammento di testo, applicare formattazione solo a parte di un paragrafo o controllare il comportamento del testo a un livello più dettagliato.

Questo articolo mostra come ottenere il rettangolo di delimitazione di una porzione utilizzando [IPortion.getRect](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPortion#getRect--). Mostra inoltre come ottenere le coordinate dell'inizio di una porzione tramite [IPortion.getCoordinates](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPortion#getCoordinates--). Inoltre, evidenzia scenari comuni relativi alle porzioni, come l'applicazione di un collegamento ipertestuale a un singolo frammento di testo, la comprensione di come la formattazione venga risolta attraverso l'ereditarietà di porzione, paragrafo, cornice di testo e tema, e la gestione dei casi in cui un carattere specificato non è disponibile.

## **Ottenere i limiti di una porzione di testo**

Utilizzare [IPortion.getRect](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPortion#getRect--) per recuperare il rettangolo di delimitazione di una porzione di testo:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ottenere le coordinate di una porzione di testo**

Utilizzare [IPortion.getCoordinates](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPortion#getCoordinates--) per recuperare le coordinate dell'inizio di una porzione di testo:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso applicare un collegamento ipertestuale solo a una parte del testo all'interno di un singolo paragrafo?**

Sì, è possibile [assegnare un collegamento ipertestuale](/slides/it/java/manage-hyperlinks/) a una singola porzione; solo quel frammento sarà cliccabile, non l'intero paragrafo.

**Come funziona l'ereditarietà degli stili: cosa sovrascrive una porzione e cosa viene preso da un paragrafo o da una cornice di testo?**

Le proprietà a livello di porzione hanno la precedenza più alta. Se una proprietà non è impostata su [IPortion](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/), Aspose.Slides la prende da [IParagraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/). Se non è impostata nemmeno lì, Aspose.Slides utilizza lo stile di [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) o del [theme](https://reference.aspose.com/slides/it/java/com.aspose.slides/theme/).

**Cosa succede se il carattere specificato per una porzione è mancante sulla macchina o sul server di destinazione?**

Vengono applicate le [regole di sostituzione dei caratteri](/slides/it/java/font-selection-sequence/). Il testo potrebbe riformattarsi: metriche, sillabazione e larghezza possono cambiare, il che è importante per un posizionamento preciso.

**Posso impostare la trasparenza o un gradiente di riempimento del testo a livello di porzione in modo indipendente dal resto del paragrafo?**

Sì, colore, riempimento e trasparenza del testo a livello di [IPortion](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/) possono differire dai frammenti vicini.