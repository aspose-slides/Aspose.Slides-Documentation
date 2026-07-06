---
title: Recuperare i confini delle porzioni di testo dalle presentazioni in PHP
linktitle: Confini della Porzione
type: docs
weight: 47
url: /it/php-java/portion-bounds/
keywords:
- confini della porzione di testo
- porzione di testo
- parte di testo
- coordinate del testo
- posizione del testo
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come recuperare i confini delle porzioni di testo nelle presentazioni PowerPoint utilizzando Aspose.Slides per PHP tramite Java."
---
## **Panoramica**

Una porzione di testo rappresenta un frammento specifico di testo all'interno di un paragrafo e consente di lavorare con quel frammento in modo indipendente dal contenuto circostante. In Aspose.Slides, le porzioni possono essere usate quando è necessario recuperare i confini di un frammento di testo, applicare formattazione solo a una parte di un paragrafo o controllare il comportamento del testo a un livello più dettagliato.

Questo articolo mostra come ottenere il rettangolo di delimitazione di una porzione utilizzando [Portion::getRect](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/getrect/). Mostra inoltre come ottenere le coordinate dell'inizio di una porzione usando [Portion::getCoordinates](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/getcoordinates/). Inoltre, evidenzia scenari comuni relativi alle porzioni, come l'applicazione di un collegamento ipertestuale a un singolo frammento di testo, la comprensione di come la formattazione venga risolta attraverso eredità di porzione, paragrafo, riquadro di testo e tema, e la gestione dei casi in cui un carattere specificato non è disponibile.

## **Ottenere i confini di una porzione di testo**

Usa [Portion::getRect](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/getrect/) per recuperare il rettangolo di delimitazione di una porzione di testo:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Ottenere le coordinate di una porzione di testo**

Usa [Portion::getCoordinates](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/getcoordinates/) per recuperare le coordinate dell'inizio di una porzione di testo:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Posso applicare un collegamento ipertestuale solo a una parte del testo all'interno di un singolo paragrafo?**

Sì, puoi [assegnare un collegamento ipertestuale](/slides/it/php-java/manage-hyperlinks/) a una singola porzione; solo quel frammento sarà cliccabile, non l'intero paragrafo.

**Come funziona l'ereditarietà di stile: cosa sovrascrive una porzione e cosa viene preso da un paragrafo o da un riquadro di testo?**

Le proprietà a livello di porzione hanno la precedenza più alta. Se una proprietà non è impostata sulla [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/), Aspose.Slides la prende dal [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/). Se non è impostata neanche lì, Aspose.Slides utilizza lo stile del [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) o del [theme](https://reference.aspose.com/slides/it/php-java/aspose.slides/theme/).

**Cosa succede se il carattere specificato per una porzione è mancante sulla macchina o sul server di destinazione?**

Vengono applicate le [Regole di sostituzione dei caratteri](/slides/it/php-java/font-selection-sequence/). Il testo potrebbe subire una riformattazione: metriche, sillabazione e larghezza possono cambiare, il che è importante per un posizionamento preciso.

**Posso impostare la trasparenza o un gradiente di riempimento del testo specifico per una porzione in modo indipendente dal resto del paragrafo?**

Sì, colore del testo, riempimento e trasparenza a livello di [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/) possono differire dai frammenti adiacenti.