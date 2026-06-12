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
description: "Duplica rapidamente le diapositive PowerPoint con Aspose.Slides per PHP. Segui i nostri esempi di codice chiari per automatizzare la creazione di PPT in pochi secondi ed eliminare il lavoro manuale."
---
## **Introduzione**

Il cloning è il processo di creazione di una copia esatta o replica di qualcosa. Aspose.Slides for PHP via Java consente anche di creare una copia o clone di qualsiasi diapositiva e quindi di inserire quella diapositiva clonata nella presentazione corrente o in qualsiasi altra presentazione aperta. Il processo di clonazione di una diapositiva crea una nuova diapositiva che può essere modificata dagli sviluppatori senza alterare la diapositiva originale. Esistono diverse modalità per clonare una diapositiva:

- Clone at End within a Presentation.
- Clone at Another Position within Presentation.
- Clone at End in another Presentation.
- Clone at Another Position in another Presentation.
- Clone at a specific position in another Presentation.

In Aspose.Slides for PHP via Java, (una collezione di [Slide](https://reference.aspose.com/slides/it/php-java/aspose.slides/Slide) objects) esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) fornisce i metodi [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#addClone) e [insertClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#insertClone) per eseguire i tipi di clonazione diapositive descritti sopra.

## **Clone a Slide at the End of a Presentation**
Se desideri clonare una diapositiva e poi usarla all'interno dello stesso file di presentazione alla fine delle diapositive esistenti, utilizza il metodo [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#addClone) secondo i passaggi elencati di seguito:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
2. Ottieni l'oggetto [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation/#getSlides) facendo riferimento alla collezione di diapositive esposta dall'oggetto [Presentation].
3. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#addClone) esposto dall'oggetto [SlideCollection] e passa la diapositiva da clonare come parametro al metodo [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#addClone).
4. Scrivi il file di presentazione modificato.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (situata nella prima posizione – indice zero – della presentazione) alla fine della presentazione.

```php
  # Istanza della classe Presentation che rappresenta un file di presentazione
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Clona la diapositiva desiderata alla fine della collezione di diapositive nella stessa presentazione
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Scrivi la presentazione modificata su disco
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Clone a Slide to Another Position within a Presentation**
Se desideri clonare una diapositiva e poi usarla all'interno dello stesso file di presentazione ma in una posizione diversa, utilizza il metodo [insertClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#insertClone):

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
2. Ottieni l'oggetto [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection) facendo riferimento alla collezione **Slides** esposta dall'oggetto [Presentation].
3. Chiama il metodo [insertClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#insertClone) esposto dall'oggetto [SlideCollection] e passa la diapositiva da clonare insieme all'indice per la nuova posizione come parametro al metodo [insertClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#insertClone).
4. Scrivi la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (situata all'indice zero – posizione 1 – della presentazione) all'indice 1 – Posizione 2 – della presentazione.

```php
  # Istanza della classe Presentation che rappresenta un file di presentazione
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Clona la diapositiva desiderata alla fine della collezione di diapositive nella stessa presentazione
    $slds = $pres->getSlides();
    # Clona la diapositiva desiderata all'indice specificato nella stessa presentazione
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Scrivi la presentazione modificata su disco
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Clone a Slide at the End of Another Presentation**
Se devi clonare una diapositiva da una presentazione e usarla in un'altra presentazione, alla fine delle diapositive esistenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) contenente la presentazione da cui verrà clonata la diapositiva.
2. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) contenente la presentazione di destinazione a cui la diapositiva sarà aggiunta.
3. Ottieni l'oggetto [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection) facendo riferimento alla collezione **Slides** esposta dall'oggetto Presentation della presentazione di destinazione.
4. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#addClone) esposto dall'oggetto [SlideCollection] e passa la diapositiva dalla presentazione di origine come parametro al metodo [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#addClone).
5. Scrivi il file della presentazione di destinazione modificato.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (dal primo indice della presentazione di origine) alla fine della presentazione di destinazione.

```php
  # Istanza della classe Presentation per caricare il file di presentazione di origine
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Istanza della classe Presentation per il PPTX di destinazione (dove la diapositiva deve essere clonata)
    $destPres = new Presentation();
    try {
      # Clona la diapositiva desiderata dalla presentazione di origine alla fine della collezione di diapositive nella presentazione di destinazione
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Scrivi la presentazione di destinazione su disco
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Clone a Slide to Another Position in Another Presentation**
Se devi clonare una diapositiva da una presentazione e usarla in un'altra presentazione, in una posizione specifica:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) contenente la presentazione di origine da cui la diapositiva verrà clonata.
2. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) contenente la presentazione a cui la diapositiva sarà aggiunta.
3. Ottieni la classe [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation/#getSlides) facendo riferimento alla collezione Slides esposta dall'oggetto Presentation della presentazione di destinazione.
4. Chiama il metodo [insertClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#insertClone) esposto dall'oggetto [SlideCollection] e passa la diapositiva dalla presentazione di origine insieme alla posizione desiderata come parametro al metodo [insertClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#insertClone).
5. Scrivi il file della presentazione di destinazione modificato.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (dall'indice zero della presentazione di origine) all'indice 1 (posizione 2) della presentazione di destinazione.

```php
  # Istanza della classe Presentation per caricare il file di presentazione di origine
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Istanza della classe Presentation per il PPTX di destinazione (dove la diapositiva deve essere clonata)
    $destPres = new Presentation();
    try {
      # Clona la diapositiva desiderata dalla presentazione di origine alla fine della collezione di diapositive nella presentazione di destinazione
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Scrivi la presentazione di destinazione su disco
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Clone a Slide at a Specific Position in Another Presentation**
Se devi clonare una diapositiva con master da una presentazione e usarla in un'altra presentazione, devi prima clonare il master desiderato dalla presentazione di origine a quella di destinazione. Poi utilizzi quel master per clonare la diapositiva con master. Il metodo [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/) si aspetta un master slide dalla presentazione di destinazione e non da quella di origine. Per clonare la diapositiva con master, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) contenente la presentazione di origine da cui la diapositiva sarà clonata.
2. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) contenente la presentazione di destinazione a cui la diapositiva sarà clonata.
3. Accedi alla diapositiva da clonare insieme al master slide.
4. Istanzia la classe [MasterSlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/MasterSlideCollection) facendo riferimento alla collezione Masters esposta dall'oggetto [Presentation] della presentazione di destinazione.
5. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#addClone) esposto dall'oggetto [MasterSlideCollection] e passa il master dalla PPTX di origine da clonare come parametro al metodo [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#addClone).
6. Istanzia la classe [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation/#getSlides) impostando il riferimento alla collezione Slides esposta dall'oggetto [Presentation] della presentazione di destinazione.
7. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#addClone) esposto dall'oggetto [SlideCollection] e passa la diapositiva dalla presentazione di origine da clonare e il master slide come parametri al metodo [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#addClone).
8. Scrivi il file della presentazione di destinazione modificato.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva con master (situata all'indice zero della presentazione di origine) alla fine della presentazione di destinazione utilizzando un master dalla diapositiva di origine.

```php
  # Istanza della classe Presentation per caricare il file di presentazione di origine
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Istanza della classe Presentation per la presentazione di destinazione (dove la diapositiva deve essere clonata)
    $destPres = new Presentation();
    try {
      # Istanza di ISlide dalla collezione di diapositive nella presentazione di origine insieme a
      # diapositiva master
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Clona la diapositiva master desiderata dalla presentazione di origine alla collezione di master nella
      # presentazione di destinazione
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Clona la diapositiva master desiderata dalla presentazione di origine alla collezione di master nella
      # presentazione di destinazione
      $iSlide = $masters->addClone($SourceMaster);
      # Clona la diapositiva desiderata dalla presentazione di origine con il master desiderato alla fine della
      # collezione di diapositive nella presentazione di destinazione
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Salva la presentazione di destinazione su disco
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Clone a Slide at the End of a Specified Section**
Se vuoi clonare una diapositiva e poi usarla all'interno dello stesso file di presentazione ma in una sezione diversa, utilizza il metodo [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection/#addClone) esposto dalla classe [SlideCollection]. Aspose.Slides for PHP via Java consente di clonare una diapositiva dalla prima sezione e poi inserire quella diapositiva clonata nella seconda sezione della stessa presentazione.

Il frammento di codice seguente mostra come clonare una diapositiva e inserire la diapositiva clonata in una sezione specificata.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Salva la presentazione di destinazione su disco
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **FAQ**

**Le note del relatore e i commenti dei revisori vengono clonati?**

Sì. La pagina delle note e i commenti di revisione sono inclusi nel clone. Se non li desideri, [rimuovili](/slides/it/php-java/presentation-notes/) dopo l'inserimento.

**Come vengono gestiti i grafici e le loro fonti dati?**

L'oggetto grafico, la formattazione e i dati incorporati vengono copiati. Se il grafico era collegato a una fonte esterna (ad esempio, una cartella di lavoro OLE incorporata), il collegamento viene preservato come [oggetto OLE](/slides/it/php-java/manage-ole/). Dopo lo spostamento tra file, verifica la disponibilità dei dati e il comportamento di aggiornamento.

**Posso controllare la posizione di inserimento e le sezioni per il clone?**

Sì. Puoi inserire il clone in un indice di diapositiva specifico e posizionarlo in una [sezione](/slides/it/php-java/slide-section/) scelta. Se la sezione di destinazione non esiste, creala prima e poi sposta la diapositiva al suo interno.