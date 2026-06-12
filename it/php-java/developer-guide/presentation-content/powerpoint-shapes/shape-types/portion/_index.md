---
title: Gestire le porzioni di testo nelle presentazioni usando PHP
linktitle: Porzione di testo
type: docs
weight: 70
url: /it/php-java/portion/
keywords:
- porzione di testo
- parte di testo
- coordinate del testo
- posizione del testo
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Impara come gestire le porzioni di testo nelle presentazioni PowerPoint usando Aspose.Slides per PHP tramite Java, migliorando le prestazioni e la personalizzazione."
---
## **Introduzione**

Una porzione di testo rappresenta un frammento specifico di testo all'interno di un paragrafo e consente di lavorare con quel frammento in modo indipendente dal contenuto circostante. In Aspose.Slides, le porzioni possono essere utilizzate quando è necessario recuperare la posizione di un frammento di testo, applicare formattazione solo a una parte di un paragrafo o controllare il comportamento del testo a un livello più dettagliato.

## **Ottenere le coordinate di una porzione di testo**
Il metodo [**getCoordinates()**](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/getcoordinates/) è stato aggiunto alla classe [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/) che consente di recuperare le coordinate dell'inizio della porzione.

```php
  # Instanzia la classe Presentation che rappresenta il PPTX
  $pres = new Presentation();
  try {
    # Rimodellare il contesto della presentazione
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso applicare un collegamento ipertestuale solo a una parte del testo all'interno di un singolo paragrafo?**

Sì, è possibile [assegnare un collegamento ipertestuale](/slides/it/php-java/manage-hyperlinks/) a una singola porzione; solo quel frammento sarà cliccabile, non l'intero paragrafo.

**Come funziona l'ereditarietà degli stili: cosa sovrascrive una Porzione e cosa viene preso dal Paragrafo/TextFrame?**

Le proprietà a livello di Porzione hanno la precedenza più alta. Se una proprietà non è impostata sulla [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/), il motore la prende dal [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/); se non è impostata neanche lì, dal [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) o dallo stile del [theme](https://reference.aspose.com/slides/it/php-java/aspose.slides/theme/).

**Cosa succede se il carattere specificato per una Porzione è assente sulla macchina/server di destinazione?**

Si applicano le [regole di sostituzione dei caratteri](/slides/it/php-java/font-selection-sequence/). Il testo potrebbe subire un reflow: metriche, sillabazione e larghezza possono cambiare, il che è importante per un posizionamento preciso.

**Posso impostare la trasparenza o il gradiente di riempimento del testo per una Porzione specifica indipendente dal resto del paragrafo?**

Sì, il colore del testo, il riempimento e la trasparenza a livello di [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/) possono differire dai frammenti vicini.