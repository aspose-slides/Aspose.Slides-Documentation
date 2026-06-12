---
title: Gestire intestazioni e piè di pagina della presentazione in PHP
linktitle: Intestazione e piè di pagina
type: docs
weight: 140
url: /it/php-java/presentation-header-and-footer/
keywords:
  - intestazione
  - testo dell'intestazione
  - piè di pagina
  - testo del piè di pagina
  - impostare intestazione
  - impostare piè di pagina
  - opuscolo
  - note
  - PowerPoint
  - OpenDocument
  - presentazione
  - PHP
  - Aspose.Slides
description: "Usa Aspose.Slides per PHP via Java per aggiungere e personalizzare intestazioni e piè di pagina in presentazioni PowerPoint e OpenDocument per un aspetto professionale."
---
## **Panoramica**

Aspose.Slides permette di gestire le impostazioni di intestazione e piè di pagina nelle presentazioni PowerPoint. Le intestazioni e i piè di pagina sono gestiti a livello del master della presentazione, e l'API fornisce metodi per impostare il testo del piè di pagina, modificare la visibilità del piè di pagina e aggiornare il testo dell'intestazione nei master delle diapositive delle note.

Puoi anche gestire intestazioni e piè di pagina per le diapositive di opuscolo e le diapositive delle note. Ciò include la modifica della visibilità e del testo dei segnaposto di intestazione, piè di pagina, numero di diapositiva e data/ora per il master delle note, tutte le diapositive figlie delle note o una singola diapositiva delle note.

## **Gestire intestazioni e piè di pagina in una presentazione**

Le note di una diapositiva specifica possono essere rimosse come mostrato nell'esempio seguente:

```php
  # Carica presentazione
  $pres = new Presentation("headerTest.pptx");
  try {
    # Impostazione piè di pagina
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # Accesso e aggiornamento intestazione
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # Salva presentazione
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Gestire intestazioni e piè di pagina su diapositive di opuscolo e note**
Aspose.Slides per PHP via Java supporta intestazione e piè di pagina su diapositive di opuscolo e note. Segui i passaggi seguenti:

- Carica una [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) contenente un video.
- Modifica le impostazioni di intestazione e piè di pagina per il master delle note e tutte le diapositive delle note.
- Imposta il master delle note e tutti i segnaposto di piè di pagina figlio come visibili.
- Imposta il master delle note e tutti i segnaposto di data e ora figlio come visibili.
- Modifica le impostazioni di intestazione e piè di pagina solo per la prima diapositiva delle note.
- Imposta il segnaposto di intestazione della diapositiva delle note come visibile.
- Imposta il testo del segnaposto di intestazione della diapositiva delle note.
- Imposta il testo del segnaposto data/ora della diapositiva delle note.
- Scrivi il file della presentazione modificata.

Snippet di codice fornito nell'esempio seguente.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # Modifica le impostazioni di intestazione e piè di pagina per il master delle note e tutte le diapositive delle note
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// rendi visibile la diapositiva master delle note e tutti i segnaposto Piè di pagina figli

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// rendi visibile la diapositiva master delle note e tutti i segnaposto Intestazione figli

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// rendi visibile la diapositiva master delle note e tutti i segnaposto Numero diapositiva figli

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// rendi visibile la diapositiva master delle note e tutti i segnaposto Data e ora figli

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// imposta il testo sulla diapositiva master delle note e tutti i segnaposto Intestazione figli

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// imposta il testo sulla diapositiva master delle note e tutti i segnaposto Piè di pagina figli

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// imposta il testo sulla diapositiva master delle note e tutti i segnaposto Data e ora figli

    }
    # Modifica le impostazioni di intestazione e piè di pagina solo per la prima diapositiva delle note
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// rendi visibile il segnaposto Intestazione di questa diapositiva delle note

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// rendi visibile il segnaposto Piè di pagina di questa diapositiva delle note

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// rendi visibile il segnaposto Numero diapositiva di questa diapositiva delle note

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// rendi visibile il segnaposto Data-ora di questa diapositiva delle note

      $headerFooterManager->setHeaderText("New header text");// imposta il testo sul segnaposto Intestazione della diapositiva delle note

      $headerFooterManager->setFooterText("New footer text");// imposta il testo sul segnaposto Piè di pagina della diapositiva delle note

      $headerFooterManager->setDateTimeText("New date and time text");// imposta il testo sul segnaposto Data-ora della diapositiva delle note

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso aggiungere un "intestazione" alle diapositive normali?**

In PowerPoint, "Header" esiste solo per le note e gli opuscoli; su diapositive normali, gli elementi supportati sono il piè di pagina, la data/ora e il numero di diapositiva. In Aspose.Slides questo corrisponde alle stesse limitazioni: intestazione solo per Note/Handout e su diapositive—Footer/DateTime/SlideNumber.

**Se il layout non contiene un'area di piè di pagina, posso "attivare" la sua visibilità?**

Sì. Verifica la visibilità tramite il gestore intestazione/piè di pagina e abilitala se necessario. Questi indicatori e metodi dell'API sono progettati per i casi in cui il segnaposto è mancante o nascosto.

**Come fare in modo che il numero di diapositiva inizi da un valore diverso da 1?**

Imposta il [first slide number](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/setfirstslidenumber/) della presentazione; dopo di ciò, tutta la numerazione viene ricalcolata. Ad esempio, puoi iniziare da 0 o 10 e nascondere il numero sulla diapositiva del titolo.

**Cosa succede a intestazioni/piè di pagina durante l'esportazione in PDF/immagini/HTML?**

Vengono renderizzati come normali elementi di testo della presentazione. Cioè, se gli elementi sono visibili su diapositive/pagine delle note, appariranno anche nel formato di output insieme al resto del contenuto.