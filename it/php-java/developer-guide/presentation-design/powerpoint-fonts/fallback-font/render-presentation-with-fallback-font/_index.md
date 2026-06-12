---
title: Renderizzare presentazioni con font di fallback in PHP
linktitle: Renderizzare presentazioni
type: docs
weight: 30
url: /it/php-java/render-presentation-with-fallback-font/
keywords:
- font di fallback
- renderizzare PowerPoint
- renderizzare presentazione
- renderizzare diapositiva
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Renderizza le presentazioni con font di fallback in Aspose.Slides per PHP tramite Java - mantieni il testo coerente tra PPT, PPTX e ODP con esempi di codice passo passo."
---
## **Panoramica**

Aspose.Slides permette di rendere le presentazioni usando regole di fallback dei font. Questo articolo mostra come creare una raccolta di regole di fallback dei font, modificare le regole rimuovendo o aggiungendo font di fallback, e assegnare la raccolta al metodo `FontsManager::setFontFallBackRulesCollection`.

Una volta assegnata la raccolta di regole di fallback al `FontsManager` della presentazione, le regole vengono applicate durante operazioni come salvataggio, rendering e conversione della presentazione. L'esempio dimostra come usare le regole configurate quando si rende una miniatura di una diapositiva e la si salva come immagine PNG.

## **Renderizzare una diapositiva usando regole di fallback dei font**

Il seguente esempio include questi passaggi:

1. [Creiamo la raccolta di regole di fallback dei font](/slides/it/php-java/create-fallback-fonts-collection/).
1. [Rimuovi](https://reference.aspose.com/slides/it/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) a fallback font rule and [addFallBackFonts](https://reference.aspose.com/slides/it/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) to another rule.
1. Imposta la raccolta di regole su [getFontsManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) metodo.
1. Con il metodo [Presentation.save](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation#save-java.lang.String-int-) possiamo salvare la presentazione nello stesso formato, oppure salvarla in un altro. Dopo che la raccolta di regole di fallback dei font è impostata su [FontsManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/FontsManager), queste regole vengono applicate durante qualsiasi operazione sulla presentazione: salvataggio, rendering, conversione, ecc.

```php
  # Crea una nuova istanza di una raccolta di regole
  $rulesList = new FontFallBackRulesCollection();
  # crea un certo numero di regole
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # Tentativo di rimuovere il font di fallback "Tahoma" dalle regole caricate
    $fallBackRule->remove("Tahoma");
    # E aggiornare le regole per l'intervallo specificato
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # Possiamo anche rimuovere qualsiasi regola esistente dall'elenco
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # Assegnazione di un elenco di regole preparato per l'uso
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # Rendering della miniatura utilizzando la raccolta di regole inizializzata e salvataggio in JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Salva l'immagine su disco in formato JPEG
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
Leggi di più su come [Convertire PPT e PPTX in JPG in PHP](/slides/it/php-java/convert-powerpoint-to-jpg/).
{{% /alert %}}