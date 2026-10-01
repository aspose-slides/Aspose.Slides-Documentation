---
title: Gestire le note della presentazione in PHP
linktitle: Note della presentazione
type: docs
weight: 110
url: /it/php-java/presentation-notes/
keywords:
- note
- diapositiva delle note
- aggiungere note
- rimuovere note
- stile delle note
- note master
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Personalizza le note della presentazione con Aspose.Slides per PHP via Java. Lavora senza problemi con le note di PowerPoint e OpenDocument per aumentare la tua produttività."
---
## **Panoramica**

Aspose.Slides supporta la rimozione delle diapositive delle note da una presentazione. In questo argomento introdurremo questa funzionalità, compreso come rimuovere le note e come applicare uno stile alle diapositive delle note in una presentazione. Aspose.Slides consente di rimuovere le note da qualsiasi diapositiva e anche di applicare uno stile alle note esistenti. Gli sviluppatori possono rimuovere le note nei seguenti modi:

- Rimuovere le note da una diapositiva specifica in una presentazione.
- Rimuovere le note da tutte le diapositive in una presentazione.

Per leggere o modificare le dimensioni della pagina delle note, cambiare orientamento e verificare il comportamento di esportazione, vedere [Notes Page Size](/slides/it/php-java/notes-size/).

## **Rimuovere le note da una diapositiva**
Le note da una diapositiva specifica possono essere rimosse come mostrato nell’esempio seguente:

```php
  # Istanziare un oggetto Presentation che rappresenta un file di presentazione
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Rimuovere le note della prima diapositiva
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # Salvare la presentazione su disco
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Rimuovere le note da una presentazione**
Le note da tutte le diapositive in una presentazione possono essere rimosse come mostrato nell’esempio seguente:

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
    # Salvare la presentazione su disco
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aggiungere uno stile alle note**
Il metodo [getNotesStyle](https://reference.aspose.com/slides/it/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) della classe [MasterNotesSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/MasterNotesSlide) fornisce l’accesso allo stile del testo delle note. L’implementazione è dimostrata nell’esempio seguente.

```php
  # Instanziare un oggetto Presentation che rappresenta un file di presentazione
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Ottenere lo stile del testo di MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # Impostare il simbolo di elenco per i paragrafi di primo livello
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

**Quale entità API fornisce l’accesso alle note di una diapositiva specifica?**

Le note sono accessibili tramite il gestore delle note della diapositiva: la diapositiva ha un [NotesSlideManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/notesslidemanager/) e un [method](https://reference.aspose.com/slides/it/php-java/aspose.slides/notesslidemanager/getnotesslide/) che restituisce l’oggetto note, o `null` se non ci sono note.

**Esistono differenze nel supporto delle note tra le versioni di PowerPoint con cui la libreria funziona?**

La libreria è destinata a un’ampia gamma di formati Microsoft PowerPoint (97‑e versioni successive) e ODP; le note sono supportate in questi formati senza dipendere da una copia installata di PowerPoint.