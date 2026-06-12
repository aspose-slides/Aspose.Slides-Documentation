---
title: Incorpora caratteri nelle presentazioni usando PHP
linktitle: Incorporamento carattere
type: docs
weight: 40
url: /it/php-java/embedded-font/
keywords:
- aggiungi carattere
- incorpora carattere
- incorporamento di caratteri
- ottieni carattere incorporato
- aggiungi carattere incorporato
- rimuovi carattere incorporato
- comprimi carattere incorporato
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Incorpora caratteri TrueType nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per PHP via Java, garantendo una resa accurata su tutte le piattaforme."
---
## **Introduzione**

**I caratteri incorporati in PowerPoint** sono utili quando si desidera che la presentazione appaia correttamente su qualsiasi sistema o dispositivo. Se hai utilizzato un carattere di terze parti o non standard perché sei stato creativo con il tuo lavoro, allora hai ancora più motivi per incorporare il carattere. Altrimenti (senza caratteri incorporati), i testi o i numeri nelle diapositive, il layout, lo stile, ecc. possono cambiare o trasformarsi in rettangoli confusi. 

Le classi [FontsManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/FontsManager), [FontData](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontdata/) e [Compress](https://reference.aspose.com/slides/it/php-java/aspose.slides/compress/) contengono la maggior parte dei metodi di cui hai bisogno per lavorare con i caratteri incorporati nelle presentazioni PowerPoint.

## **Ottieni e rimuovi i caratteri incorporati**

Aspose.Slides fornisce il metodo [getEmbeddedFonts](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) (esposto dalla classe [FontsManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/FontsManager)) per consentire di ottenere (o scoprire) i caratteri incorporati in una presentazione. Per rimuovere i caratteri, viene utilizzato il metodo [removeEmbeddedFont](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) (esposto dalla stessa classe).

Questo codice PHP mostra come ottenere e rimuovere i caratteri incorporati da una presentazione:

```php
  # Istanzia un oggetto Presentation che rappresenta un file di presentazione
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Renderizza una diapositiva contenente un frame di testo che utilizza il carattere incorporato "FunSized"
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Salva l'immagine su disco in formato JPEG
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # Ottiene tutti i caratteri incorporati
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # Trova il carattere "Calibri"
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # Rimuove il carattere "Calibri"
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # Renderizza la presentazione; il carattere "Calibri" viene sostituito con uno esistente
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Salva l'immagine su disco in formato JPEG
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Salva la presentazione senza il carattere "Calibri" incorporato su disco
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aggiungi caratteri incorporati**

Utilizzando la classe [EmbedFontCharacters](https://reference.aspose.com/slides/it/php-java/aspose.slides/embedfontcharacters/) e due overload del metodo [addEmbeddedFont](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/#addEmbeddedFont), è possibile selezionare la regola di incorporamento preferita per incorporare i caratteri in una presentazione. Questo codice PHP mostra come incorporare e aggiungere i caratteri a una presentazione:

```php
  # Carica la presentazione
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # Salva la presentazione su disco
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Comprimi i caratteri incorporati**

Per consentire di comprimere i caratteri incorporati in una presentazione e ridurne le dimensioni, Aspose.Slides fornisce il metodo [compressEmbeddedFonts](https://reference.aspose.com/slides/it/php-java/aspose.slides/compress/#compressEmbeddedFonts) (esposto dalla classe [Compress](https://reference.aspose.com/slides/it/php-java/aspose.slides/compress/)).

Questo codice PHP mostra come comprimere i caratteri PowerPoint incorporati:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Come posso capire se un carattere specifico nella presentazione sarà comunque sostituito durante il rendering nonostante l'incorporamento?**

Controlla le [informazioni di sostituzione](/slides/it/php-java/font-substitution/) nel gestore dei caratteri e le [regole di fallback/sostituzione](/slides/it/php-java/fallback-font/): se il carattere non è disponibile o è limitato, verrà utilizzato un fallback.

**Vale la pena incorporare i caratteri "di sistema" come Arial/Calibri?**

Di solito no—sono quasi sempre disponibili. Tuttavia, per una piena portabilità in ambienti "leggeri" (Docker, un server Linux senza caratteri preinstallati), l'incorporamento dei caratteri di sistema può eliminare il rischio di sostituzioni inaspettate.