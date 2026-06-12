---
title: Automatizza la localizzazione delle presentazioni in PHP
linktitle: Localizzazione della presentazione
type: docs
weight: 100
url: /it/php-java/presentation-localization/
keywords:
- cambio lingua
- controllo ortografico
- ID lingua
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Automatizza la localizzazione di diapositive PowerPoint e OpenDocument con Aspose.Slides per PHP tramite Java, utilizzando esempi di codice pratici e suggerimenti per una distribuzione globale più rapida."
---
## **Panoramica**

Questo articolo spiega come impostare `LanguageId` per il testo in una presentazione utilizzando Aspose.Slides. Mostra come aprire una presentazione, aggiungere una forma con testo, assegnare un identificatore di lingua a una porzione di testo e salvare il risultato come file PPTX.

## **Modifica della lingua per una presentazione e il testo di una forma**
- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
- Ottieni il riferimento di una diapositiva utilizzando il suo indice.
- Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) di tipo [Rectangle](https://reference.aspose.com/slides/it/php-java/aspose.slides/ShapeType#Rectangle) alla diapositiva.
- Aggiungi del testo al TextFrame.
- [Imposta Language Id](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setLanguageId) al testo.
- Scrivi la presentazione come file PPTX.

L'implementazione dei passaggi sopra è mostrata di seguito in un esempio.

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**L'ID lingua attiva la traduzione automatica del testo?**

No. [Language ID](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setLanguageId) in Aspose.Slides memorizza la lingua per il controllo ortografico e la verifica grammaticale, ma non traduce né modifica il contenuto del testo. È un metadato che PowerPoint comprende per la correzione.

**L'ID lingua influisce sull'iphenazione e sugli interruzioni di riga durante il rendering?**

In Aspose.Slides, [language ID](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setLanguageId) è per la verifica. La qualità dell'iphenazione e l'adattamento delle linee dipendono principalmente dalla disponibilità di [proper fonts](/slides/it/php-java/powerpoint-fonts/) e dalle impostazioni di layout/interruzione di riga per il sistema di scrittura. Per garantire il rendering corretto, rendi disponibili i font richiesti, configura le [font substitution rules](/slides/it/php-java/font-substitution/), e/o [embed fonts](/slides/it/php-java/embedded-font/) nella presentazione.

**Posso impostare lingue diverse all'interno di un singolo paragrafo?**

Sì. [Language ID](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setLanguageId) è applicato a livello di porzione di testo, quindi un singolo paragrafo può mescolare più lingue con impostazioni di correzione distinte.