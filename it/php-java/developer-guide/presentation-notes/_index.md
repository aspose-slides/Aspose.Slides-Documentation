---
title: Gestisci le note della presentazione in PHP
linktitle: Note della presentazione
type: docs
weight: 110
url: /it/php-java/presentation-notes/
keywords:
- note
- diapositiva note
- aggiungi note
- rimuovi note
- stile note
- note master
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Personalizza le note della presentazione con Aspose.Slides per PHP tramite Java. Lavora senza soluzione di continuità con le note di PowerPoint e OpenDocument per aumentare la tua produttività."
---
## **Panoramica**

Aspose.Slides supporta la rimozione delle diapositive con note da una presentazione. In questo argomento presenteremo questa funzionalità, includendo come rimuovere le note e come applicare uno stile alle diapositive delle note in una presentazione. Aspose.Slides permette di rimuovere le note da qualsiasi diapositiva e di applicare uno stile alle note esistenti. Gli sviluppatori possono rimuovere le note nei seguenti modi:

- Rimuovere le note da una diapositiva specifica in una presentazione.
- Rimuovere le note da tutte le diapositive in una presentazione.

## **Rimuovere le note da una diapositiva**
Le note di una diapositiva specifica possono essere rimosse come mostrato nell'esempio seguente:

```php
  # Istanziare un oggetto Presentation che rappresenta un file di presentazione
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Rimuovere le note della prima diapositiva
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # Salvataggio della presentazione su disco
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Rimuovere le note da una presentazione**
Le note di tutte le diapositive di una presentazione possono essere rimosse come mostrato nell'esempio seguente:

```php
  # Istanziare un oggetto Presentation che rappresenta un file di presentazione
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Rimuovere le note di tutte le diapositive
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # Salvataggio della presentazione su disco
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aggiungere uno stile alle note**
Il metodo [getNotesStyle](https://reference.aspose.com/slides/it/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) è stato aggiunto alla classe [MasterNotesSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/MasterNotesSlide) rispettivamente. Questa proprietà specifica lo stile del testo delle note. L'implementazione è mostrata nell'esempio seguente.

```php
  # Istanziare un oggetto Presentation che rappresenta un file di presentazione
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Ottieni lo stile del testo della MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # Imposta il simbolo per i paragrafi di primo livello
      $paragraphFormat = $notesStyle->getLevel(0);
      $paragraphFormat::getBullet()->setType(BulletType::Symbol);
    }
    $pres->save("NotesSlideWithNotesStyle.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Quale entità dell'API fornisce l'accesso alle note di una diapositiva specifica?**

Le note sono accessibili tramite il gestore delle note della diapositiva: la diapositiva dispone di un [NotesSlideManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/notesslidemanager/) e di un [method](https://reference.aspose.com/slides/it/php-java/aspose.slides/notesslidemanager/getnotesslide/) che restituisce l'oggetto note, o `null` se non ci sono note.

**Ci sono differenze nel supporto delle note tra le versioni di PowerPoint con cui la libreria funziona?**

La libreria supporta un'ampia gamma di formati Microsoft PowerPoint (97‑versioni successive) e ODP; le note sono supportate all'interno di questi formati senza dipendere da una copia installata di PowerPoint.