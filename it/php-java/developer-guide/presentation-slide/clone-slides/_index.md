---
title: Clona le diapositive della presentazione in PHP
linktitle: Clona Diapositive
type: docs
weight: 35
url: /it/php-java/clone-slides/
keywords:
- clona diapositiva
- copia diapositiva
- salva diapositiva
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Duplica rapidamente le diapositive PowerPoint con Aspose.Slides per PHP. Segui i nostri chiari esempi di codice per automatizzare la creazione di PPT in pochi secondi ed eliminare il lavoro manuale."
---
## **Introduzione**

Il clonaggio è il processo di creare una copia esatta o replica di qualcosa. Aspose.Slides per PHP via Java consente anche di creare una copia o un clone di qualsiasi diapositiva e quindi inserire quella diapositiva clonata nella presentazione corrente o in qualsiasi altra presentazione aperta. Il processo di clonazione diapositive crea una nuova diapositiva che può essere modificata dagli sviluppatori senza modificare la diapositiva originale. Esistono diversi modi per clonare una diapositiva:

- Clona alla fine all'interno di una presentazione.
- Clona in un'altra posizione all'interno della presentazione.
- Clona alla fine in un'altra presentazione.
- Clona in un'altra posizione in un'altra presentazione.
- Clona in una posizione specifica in un'altra presentazione.

In Aspose.Slides per PHP via Java, (una raccolta di [Slide](https://reference.aspose.com/slides/it/php-java/aspose.slides/Slide) objects) esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) fornisce i metodi [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#addClone) e [insertClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#insertClone) per eseguire i tipi di clonazione descritti sopra.

## **Clona una diapositiva alla fine di una presentazione**
Se desideri clonare una diapositiva e poi usarla nello stesso file di presentazione alla fine delle diapositive esistenti, utilizza il metodo [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#addClone) secondo i passaggi elencati di seguito:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Ottieni l'oggetto [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation/#getSlides) facendo riferimento alla raccolta di diapositive esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#addClone) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation/#getSlides) e passa come parametro la diapositiva da clonare.
1. Scrivi il file della presentazione modificata.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (situata nella prima posizione – indice zero – della presentazione) alla fine della presentazione.

```php
  # Istanziare la classe Presentation che rappresenta un file di presentazione
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Clonare la diapositiva desiderata alla fine della raccolta di diapositive nella stessa presentazione
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Scrivere la presentazione modificata su disco
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Clona una diapositiva in un'altra posizione all'interno di una presentazione**
Se desideri clonare una diapositiva e poi usarla nello stesso file di presentazione ma in una posizione diversa, utilizza il metodo [insertClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#insertClone):

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Ottieni l'oggetto [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection) facendo riferimento alla raccolta **[Slides](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation/#getSlides)** esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Chiama il metodo [insertClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#insertClone) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation/#getSlides) e passa la diapositiva da clonare insieme all'indice per la nuova posizione come parametri al metodo [insertClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#insertClone).
1. Scrivi la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (situata all'indice zero – posizione 1 – della presentazione) all'indice 1 – Posizione 2 – della presentazione.

```php
  # Istanziare la classe Presentation che rappresenta un file di presentazione
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Clonare la diapositiva desiderata alla fine della raccolta di diapositive nella stessa presentazione
    $slds = $pres->getSlides();
    # Clonare la diapositiva desiderata all'indice specificato nella stessa presentazione
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Scrivere la presentazione modificata su disco
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Clona una diapositiva alla fine di un'altra presentazione**
Se devi clonare una diapositiva da una presentazione e usarla in un'altra presentazione, alla fine delle diapositive esistenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) contenente la presentazione da cui la diapositiva sarà clonata.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) contenente la presentazione di destinazione a cui la diapositiva sarà aggiunta.
1. Ottieni l'oggetto [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection) facendo riferimento alla raccolta **[Slides](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation/#getSlides)** esposta dall'oggetto Presentation della presentazione di destinazione.
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#addClone) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation/#getSlides) e passa la diapositiva dalla presentazione di origine come parametro al metodo [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#addClone).
1. Scrivi il file della presentazione di destinazione modificata.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (dal primo indice della presentazione di origine) alla fine della presentazione di destinazione.

```php
  # Istanziare la classe Presentation per caricare il file della presentazione sorgente
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Istanziare la classe Presentation per il PPTX di destinazione (dove la diapositiva sarà clonata)
    $destPres = new Presentation();
    try {
      # Clonare la diapositiva desiderata dalla presentazione sorgente alla fine della raccolta di diapositive nella presentazione di destinazione
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Scrivere la presentazione di destinazione su disco
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Clona una diapositiva in un'altra posizione in un'altra presentazione**
Se devi clonare una diapositiva da una presentazione e usarla in un'altra presentazione, in una posizione specifica:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) contenente la presentazione di origine da cui la diapositiva sarà clonata.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) contenente la presentazione a cui la diapositiva sarà aggiunta.
1. Ottieni la classe [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation/#getSlides) facendo riferimento alla raccolta Slides esposta dall'oggetto Presentation della presentazione di destinazione.
1. Chiama il metodo [insertClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#insertClone) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation/#getSlides) e passa la diapositiva dalla presentazione di origine insieme alla posizione desiderata come parametri al metodo [insertClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#insertClone).
1. Scrivi il file della presentazione di destinazione modificata.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (dall'indice zero della presentazione di origine) all'indice 1 (posizione 2) della presentazione di destinazione.

```php
  # Istanziare la classe Presentation per caricare il file della presentazione sorgente
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Istanziare la classe Presentation per il PPTX di destinazione (dove la diapositiva deve essere clonata)
    $destPres = new Presentation();
    try {
      # Clonare la diapositiva desiderata dalla presentazione sorgente alla fine della raccolta di diapositive nella presentazione di destinazione
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Scrivere la presentazione di destinazione su disco
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Clona una diapositiva in una posizione specifica in un'altra presentazione**
Se devi clonare una diapositiva con un master slide da una presentazione e usarla in un'altra presentazione, devi prima clonare il master slide desiderato dalla presentazione di origine a quella di destinazione. Successivamente, utilizza quel master slide per clonare la diapositiva con master. Il metodo [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/) richiede un master slide dalla presentazione di destinazione anziché da quella di origine. Per clonare la diapositiva con un master, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) contenente la presentazione di origine da cui la diapositiva sarà clonata.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) contenente la presentazione di destinazione a cui la diapositiva sarà clonata.
1. Accedi alla diapositiva da clonare insieme al master slide.
1. Istanzia la classe [MasterSlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/MasterSlideCollection) facendo riferimento alla raccolta Masters esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) della presentazione di destinazione.
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#addClone) esposto dall'oggetto [MasterSlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/MasterSlideCollection) e passa come parametro il master dalla presentazione PPTX di origine da clonare.
1. Istanzia la classe [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation/#getSlides) impostando il riferimento alla raccolta Slides esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) della presentazione di destinazione.
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#addClone) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation/#getSlides) e passa come parametri la diapositiva dalla presentazione di origine da clonare e il master slide.
1. Scrivi il file della presentazione di destinazione modificato.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva con master (situata all'indice zero della presentazione di origine) alla fine della presentazione di destinazione utilizzando un master dalla diapositiva di origine.

```php
  # Istanziare la classe Presentation per caricare il file della presentazione sorgente
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Istanziare la classe Presentation per la presentazione di destinazione (dove la diapositiva deve essere clonata)
    $destPres = new Presentation();
    try {
      # Istanziare ISlide dalla raccolta di diapositive nella presentazione sorgente insieme a
      # diapositiva master
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Clonare la master slide desiderata dalla presentazione sorgente nella raccolta di master nella
      # presentazione di destinazione
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Clonare la master slide desiderata dalla presentazione sorgente nella raccolta di master nella
      # presentazione di destinazione
      $iSlide = $masters->addClone($SourceMaster);
      # Clonare la diapositiva desiderata dalla presentazione sorgente con il master desiderato alla fine della
      # raccolta di diapositive nella presentazione di destinazione
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Salvare la presentazione di destinazione su disco
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Clona una diapositiva alla fine di una sezione specificata**
Se desideri clonare una diapositiva e poi usarla nello stesso file di presentazione ma in una sezione diversa, utilizza il metodo [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#addClone) esposto dalla classe [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection). Aspose.Slides per PHP via Java consente di clonare una diapositiva dalla prima sezione e quindi inserire quella diapositiva clonata nella seconda sezione della stessa presentazione.

Il frammento di codice seguente mostra come clonare una diapositiva e inserire la diapositiva clonata in una sezione specificata.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Salva la presentazione di destinazione su disco
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Assicurare la corrispondenza delle dimensioni della diapositiva**

Quando cloni diapositive in un'altra presentazione, assicurati che la presentazione di destinazione abbia le stesse dimensioni della diapositiva di origine. Se le dimensioni differiscono, Aspose.Slides non ridimensiona automaticamente le forme clonate: le coordinate e le dimensioni originali vengono preservate, il che può far apparire il contenuto disallineato o estendersi oltre i bordi della diapositiva.

Puoi impostare le dimensioni della diapositiva della presentazione di destinazione per farle corrispondere a quelle di origine prima di clonare il master e la diapositiva:

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

Esegui questa operazione prima di clonare il master e la diapositiva.

## **FAQ**

**Le note del relatore e i commenti dei revisori vengono clonati?**

Sì. La pagina delle note e i commenti di revisione sono inclusi nel clone. Se non li desideri, [rimuovili](/slides/it/php-java/presentation-notes/) dopo l'inserimento.

**Come vengono gestiti i grafici e le loro fonti dati?**

L'oggetto grafico, la formattazione e i dati incorporati vengono copiati. Se il grafico era collegato a una fonte esterna (ad es., una cartella di lavoro OLE incorporata), quel collegamento viene conservato come un [oggetto OLE](/slides/it/php-java/manage-ole/). Dopo lo spostamento tra file, verifica la disponibilità dei dati e il comportamento di aggiornamento.

**Posso controllare la posizione di inserimento e le sezioni per il clone?**

Sì. Puoi inserire il clone in un indice di diapositiva specifico e posizionarlo in una [sezione](/slides/it/php-java/slide-section/) scelta. Se la sezione di destinazione non esiste, creala prima e poi sposta la diapositiva al suo interno.