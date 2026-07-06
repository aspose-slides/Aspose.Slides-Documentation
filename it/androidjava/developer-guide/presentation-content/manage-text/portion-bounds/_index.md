---
title: Ottieni i limiti della porzione di testo da presentazioni su Android
linktitle: Limiti della porzione
type: docs
weight: 47
url: /it/androidjava/portion-bounds/
keywords:
- limiti della porzione di testo
- porzione di testo
- parte di testo
- coordinate del testo
- posizione del testo
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come recuperare i limiti delle porzioni di testo nelle presentazioni PowerPoint usando Aspose.Slides per Android tramite Java."
---
## **Panoramica**

Una porzione di testo rappresenta un frammento specifico di testo all'interno di un paragrafo e consente di lavorare con quel frammento in modo indipendente dal contenuto circostante. In Aspose.Slides, le porzioni possono essere utilizzate quando è necessario recuperare i limiti di un frammento di testo, applicare formattazione solo a una parte di un paragrafo o controllare il comportamento del testo a un livello più dettagliato.

Questo articolo mostra come ottenere il rettangolo delimitante di una porzione utilizzando [IPortion.getRect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPortion#getRect--). Mostra anche come ottenere le coordinate dell'inizio di una porzione utilizzando [IPortion.getCoordinates](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPortion#getCoordinates--). Inoltre, evidenzia scenari comuni relativi alle porzioni, come l'applicazione di un collegamento ipertestuale a un singolo frammento di testo, la comprensione di come la formattazione viene risolta attraverso porzione, paragrafo, frame di testo e tema, e la gestione dei casi in cui un carattere specificato non è disponibile.

## **Ottenere i limiti di una porzione di testo**

Utilizza [IPortion.getRect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPortion#getRect--) per recuperare il rettangolo delimitante di una porzione di testo:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ottenere le coordinate di una porzione di testo**

Utilizza [IPortion.getCoordinates](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPortion#getCoordinates--) per recuperare le coordinate dell'inizio di una porzione di testo:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso applicare un collegamento ipertestuale solo a una parte del testo all'interno di un singolo paragrafo?**

Sì, è possibile [assegnare un collegamento ipertestuale](/slides/it/androidjava/manage-hyperlinks/) a una singola porzione; solo quel frammento sarà cliccabile, non l'intero paragrafo.

**Come funziona l'ereditarietà degli stili: cosa sovrascrive una porzione e cosa viene ereditato da un paragrafo o da un frame di testo?**

Le proprietà a livello di porzione hanno la massima precedenza. Se una proprietà non è impostata sulla [IPortion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/), Aspose.Slides la prende dalla [IParagraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraph/). Se non è impostata nemmeno lì, Aspose.Slides utilizza lo stile della [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) o del [theme](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/theme/).

**Cosa succede se il carattere specificato per una porzione è assente sulla macchina o sul server di destinazione?**

Vengono applicate le [regole di sostituzione dei caratteri](/slides/it/androidjava/font-selection-sequence/). Il testo potrebbe rifluire: metriche, sillabazione e larghezza possono cambiare, il che è importante per un posizionamento preciso.

**Posso impostare la trasparenza del riempimento del testo o un gradiente specifici per una porzione indipendentemente dal resto del paragrafo?**

Sì, colore del testo, riempimento e trasparenza a livello di [IPortion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/) possono differire dai frammenti adiacenti.