---
title: Gestisci i segnaposto delle presentazioni in PHP
linktitle: Gestisci segnaposti
type: docs
weight: 10
url: /it/php-java/manage-placeholder/
keywords:
- segnaposto
- segnaposto di testo
- segnaposto immagine
- segnaposto grafico
- testo di prompt
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Gestisci facilmente i segnaposto in Aspose.Slides per PHP via Java: sostituisci il testo, personalizza i prompt e imposta la trasparenza dell'immagine in PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di gestire i segnaposto delle presentazioni in modo programmatico. Questo articolo spiega come trovare i segnaposto nelle diapositive e modificarne il testo, impostare testi di prompt personalizzati per i layout dei segnaposto e regolare la trasparenza di un'immagine utilizzata come sfondo del segnaposto. Include anche una breve FAQ che chiarisce la differenza tra segnaposto di base e forme locali, spiega come le modifiche ai segnaposto possano essere applicate tramite layout o master e indica la gestione dei segnaposto di intestazione e piè di pagina.

## **Modifica testo in un segnaposto**
Utilizzando [Aspose.Slides per PHP via Java](/slides/it/php-java/), è possibile trovare e modificare i segnaposto nelle diapositive delle presentazioni. Aspose.Slides consente di apportare modifiche al testo di un segnaposto.

**Prerequisito**: è necessaria una presentazione che contenga un segnaposto. È possibile creare una tale presentazione nell'app Microsoft PowerPoint standard.

Questo è il modo in cui si utilizza Aspose.Slides per sostituire il testo nel segnaposto di quella presentazione:

1. Istanziare la classe [`Presentation`](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) e passare la presentazione come argomento.
2. Ottenere un riferimento alla diapositiva tramite il suo indice.
3. Iterare tra le forme per trovare il segnaposto.
4. Convertire la forma del segnaposto in un [`AutoShape`](https://reference.aspose.com/slides/it/php-java/aspose.slides/AutoShape) e modificare il testo utilizzando il [`TextFrame`](https://reference.aspose.com/slides/it/php-java/aspose.slides/TextFrame) associato al [`AutoShape`](https://reference.aspose.com/slides/it/php-java/aspose.slides/AutoShape).
5. Salvare la presentazione modificata.

Questo codice PHP mostra come modificare il testo in un segnaposto:

```php
  # Istanzia una classe Presentation
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # Accede alla prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Itera tra le forme per trovare il segnaposto
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # Modifica il testo in ogni segnaposto
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # Salva la presentazione su disco
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Imposta testo di prompt in un segnaposto**
I layout standard e predefiniti contengono testi di prompt per i segnaposto come ***Fai clic per aggiungere un titolo*** o ***Fai clic per aggiungere un sottotitolo***. Utilizzando Aspose.Slides, è possibile inserire i propri testi di prompt preferiti nei layout dei segnaposto.

Questo codice PHP mostra come impostare il testo di prompt in un segnaposto:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Itera attraverso la diapositiva
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint visualizza "Fai clic per aggiungere un titolo"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // Aggiunge il sottotitolo
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Imposta trasparenza immagine del segnaposto**

Aspose.Slides consente di impostare la trasparenza dell'immagine di sfondo in un segnaposto di testo. Regolando la trasparenza dell'immagine in tale riquadro, è possibile far risaltare il testo o l'immagine (a seconda dei colori del testo e dell'immagine).

Questo codice PHP mostra come impostare la trasparenza per lo sfondo di un'immagine (all'interno di una forma):

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Che cos'è un segnaposto di base e in che modo differisce da una forma locale in una diapositiva?**

Un segnaposto di base è la forma originale in un layout o master da cui la forma della diapositiva eredita—tipo, posizione e parte della formattazione provengono da esso. Una forma locale è indipendente; se non esiste un segnaposto di base, l'ereditarietà non si applica.

**Come posso aggiornare tutti i titoli o le didascalie in un'intera presentazione senza iterare su ogni diapositiva?**

Modificare il segnaposto corrispondente sul layout o sul master. Le diapositive basate su quei layout/master erediteranno automaticamente la modifica.

**Come posso gestire i segnaposto standard di intestazione/piè di pagina—data e ora, numero diapositiva e testo del piè di pagina?**

Utilizzare i gestori HeaderFooter nell'ambito appropriato (diapositive normali, layout, master, note/dispense) per attivare o disattivare tali segnaposto e impostare il loro contenuto.