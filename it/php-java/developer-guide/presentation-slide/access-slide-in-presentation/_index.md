---
title: Accedi alle diapositive della presentazione in PHP
linktitle: Accedi alla diapositiva
type: docs
weight: 20
url: /it/php-java/access-slide-in-presentation/
keywords:
- accedere alla diapositiva
- indice diapositiva
- id diapositiva
- posizione diapositiva
- cambiare posizione
- proprietà diapositiva
- numero diapositiva
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come accedere e gestire le diapositive in presentazioni PowerPoint e OpenDocument con Aspose.Slides per PHP tramite Java. Aumenta la produttività con esempi di codice."
---
## **Panoramica**

Questo articolo spiega come accedere e gestire le diapositive in una presentazione utilizzando Aspose.Slides. Mostra come recuperare le diapositive per indice zero‑based dalla collezione di diapositive e come accedere a una diapositiva per ID univoco utilizzando il metodo `getSlideById`.

Imparerai anche come modificare la posizione di una diapositiva usando il metodo `setSlideNumber` e come definire il numero della prima diapositiva di una presentazione con il metodo `setFirstSlideNumber`. Gli esempi dimostrano il caricamento di una presentazione, l’ottenimento di riferimenti alle diapositive, l’aggiornamento dell’ordine o della numerazione e il salvataggio della presentazione modificata.

## **Accedi a una diapositiva per indice**

Tutte le diapositive di una presentazione sono disposte numericamente in base alla posizione, a partire da 0. La prima diapositiva è accessibile tramite l’indice 0; la seconda diapositiva è accessibile tramite l’indice 1; ecc.

La classe Presentation, che rappresenta un file di presentazione, espone tutte le diapositive come una collezione [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/) (collezione di oggetti [Slide](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/)). Questo codice PHP mostra come accedere a una diapositiva tramite il suo indice:

```php
  # Istanzia un oggetto Presentation che rappresenta un file di presentazione
  $pres = new Presentation("demo.pptx");
  try {
    # Accede a una diapositiva usando il suo indice di diapositiva
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

## **Accedi a una diapositiva per ID**

Ogni diapositiva in una presentazione ha un ID univoco associato. È possibile utilizzare il metodo [getSlideById](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getSlideById-long-) (esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/)) per mirare a quell’ID. Questo codice PHP mostra come fornire un ID diapositiva valido e accedere a quella diapositiva tramite il metodo [getSlideById](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getSlideById-long-):

```php
  # Istanzia un oggetto Presentation che rappresenta un file di presentazione
  $pres = new Presentation("demo.pptx");
  try {
    # Ottiene un ID diapositiva
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # Accede alla diapositiva tramite il suo ID
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```

## **Modifica la posizione della diapositiva**

Aspose.Slides consente di modificare la posizione di una diapositiva. Ad esempio, è possibile specificare che la prima diapositiva diventi la seconda.

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni il riferimento alla diapositiva (la cui posizione vuoi cambiare) tramite il suo indice
3. Imposta una nuova posizione per la diapositiva tramite il metodo [setSlideNumber](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#setSlideNumber).
4. Salva la presentazione modificata.

Questo codice PHP dimostra un’operazione in cui la diapositiva in posizione 1 viene spostata in posizione 2:

```php
  # Istanzia un oggetto Presentation che rappresenta un file di presentazione
  $pres = new Presentation("Presentation.pptx");
  try {
    # Recupera la diapositiva la cui posizione verrà cambiata
    $sld = $pres->getSlides()->get_Item(0);
    # Imposta la nuova posizione per la diapositiva
    $sld->setSlideNumber(2);
    # Salva la presentazione modificata
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

La prima diapositiva è diventata la seconda; la seconda diapositiva è diventata la prima. Quando cambi la posizione di una diapositiva, le altre diapositive vengono regolate automaticamente.

## **Imposta il numero della diapositiva**

Utilizzando il metodo [setFirstSlideNumber](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/)), è possibile specificare un nuovo numero per la prima diapositiva di una presentazione. Questa operazione fa sì che gli altri numeri di diapositiva vengano ricalcolati.

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni il numero della diapositiva.
3. Imposta il numero della diapositiva.
4. Salva la presentazione modificata.

Questo codice PHP dimostra un’operazione in cui il numero della prima diapositiva è impostato a 10:

```php
  # Istanzia un oggetto Presentation che rappresenta un file di presentazione
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # Ottiene il numero della diapositiva
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # Imposta il numero della diapositiva
    $pres->setFirstSlideNumber(10);
    # Salva la presentazione modificata
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Se preferisci saltare la prima diapositiva, puoi avviare la numerazione dalla seconda diapositiva (e nascondere la numerazione per la prima diapositiva) in questo modo:

```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # Imposta il numero della prima diapositiva della presentazione
    $presentation->setFirstSlideNumber(0);
    # Mostra i numeri di diapositiva per tutte le diapositive
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # Nasconde il numero di diapositiva per la prima diapositiva
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # Salva la presentazione modificata
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **FAQ**

**Il numero della diapositiva che l’utente vede corrisponde all’indice zero‑based della collezione?**

Il numero mostrato su una diapositiva può iniziare da un valore arbitrario (ad esempio 10) e non deve corrispondere all’indice; la relazione è controllata dall’impostazione [first slide number](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/setfirstslidenumber/) della presentazione.

**Le diapositive nascoste influenzano l’indicizzazione?**

Sì. Una diapositiva nascosta rimane nella collezione ed è conteggiata nell’indicizzazione; “nascosta” si riferisce alla visualizzazione, non alla sua posizione nella collezione.

**L’indice di una diapositiva cambia quando vengono aggiunte o rimosse altre diapositive?**

Sì. Gli indici riflettono sempre l’ordine attuale nelle diapositive e vengono ricalcolati al momento di inserimenti, eliminazioni e spostamenti.