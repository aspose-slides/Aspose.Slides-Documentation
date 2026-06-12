---
title: Gestire i nodi di forma SmartArt nelle presentazioni usando PHP
linktitle: Nodo forma SmartArt
type: docs
weight: 30
url: /it/php-java/manage-smartart-shape-node/
keywords:
- nodo SmartArt
- nodo figlio
- aggiungi nodo
- posizione nodo
- accedi nodo
- rimuovi nodo
- posizione personalizzata
- nodo assistente
- formato riempimento
- renderizza nodo
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Gestisci i nodi di forma SmartArt in PPT e PPTX con Aspose.Slides per PHP via Java. Ottieni esempi di codice chiari e suggerimenti per ottimizzare le tue presentazioni."
---
## **Panoramica**

Le grafiche SmartArt nelle presentazioni PowerPoint sono organizzate tramite nodi che contengono testo e definiscono la struttura del diagramma. Aspose.Slides consente di lavorare con questi nodi SmartArt in modo programmatico: aggiungere nuovi nodi e nodi figlio, inserire nodi figlio in una posizione specifica, accedere ai nodi esistenti e leggere il loro testo, livello e posizione.

Questo articolo spiega come gestire i nodi di forma SmartArt. Mostra come rimuovere i nodi, lavorare con i nodi figlio per indice o posizione, trasformare un nodo assistente in un nodo normale, regolare la posizione, le dimensioni e la rotazione delle forme dei nodi SmartArt, impostare i formati di riempimento dei nodi e generare un’immagine di anteprima per un nodo figlio SmartArt.

## **Add a SmartArt Node**
Aspose.Slides for PHP via Java ha fornito l'API più semplice per gestire le forme SmartArt nel modo più facile. Il codice di esempio seguente aiuterà ad aggiungere un nodo e un nodo figlio all'interno di una forma SmartArt.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) e carica la presentazione con la forma SmartArt.  
1. Ottieni il riferimento della prima diapositiva usando il suo indice.  
1. Scorri tutte le forme all'interno della prima diapositiva.  
1. Verifica se la forma è del tipo [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/) e, se lo è, esegui il cast del tipo selezionato a [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/).  
1. [Add a new Node](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartnodecollection/#addNode) in SmartArt shape [**NodeCollection**](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/#getAllNodes) and set the text in TextFrame.  
1. Now, [Add](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartnodecollection/#addNode) a [**Child Node**](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartnode/#getChildNodes) in newly added [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/) Node and set the text in TextFrame  
1. Salva la presentazione.

```php
  # Carica la presentazione desiderata
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Scorri tutte le forme all'interno della prima diapositiva
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Verifica se la forma è di tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Esegui il cast della forma a SmartArt
        $smart = $shape;
        # Aggiunta di un nuovo nodo SmartArt
        $TemNode = $smart->getAllNodes()->addNode();
        # Aggiunta testo
        $TemNode->getTextFrame()->setText("Test");
        # Aggiunta di un nuovo nodo figlio nel nodo genitore. Verrà aggiunto alla fine della raccolta
        $newNode = $TemNode->getChildNodes()->addNode();
        # Aggiunta testo
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # Salvataggio della presentazione
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Add a SmartArt Node at a Specific Position**
Nel codice di esempio seguente spieghiamo come aggiungere i nodi figlio appartenenti ai rispettivi nodi della forma SmartArt in una posizione particolare.

1. Crea un'istanza della classe Presentation.  
1. Ottieni il riferimento della prima diapositiva usando il suo indice.  
1. Aggiungi una forma [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/SmartArt) di tipo [**StackedList**](https://reference.aspose.com/slides/it/php-java/aspose.slides/SmartArtLayoutType#StackedList) nella diapositiva ottenuta.  
1. Accedi al primo nodo nella forma SmartArt aggiunta.  
1. Ora, aggiungi il [**Child Node**](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartnode/#getChildNodes) per il [**Node**](https://reference.aspose.com/slides/it/php-java/aspose.slides/SmartArtNode) selezionato alla posizione 2 e imposta il suo testo.  
1. Salva la presentazione

```php
  # Creazione di un'istanza di presentazione
  $pres = new Presentation();
  try {
    # Accedi alla diapositiva della presentazione
    $slide = $pres->getSlides()->get_Item(0);
    # Aggiungi Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Accesso al nodo SmartArt all'indice 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Aggiunta di un nuovo nodo figlio alla posizione 2 nel nodo genitore
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # Aggiungi testo
    $chNode->getTextFrame()->setText("Sample Text Added");
    # Salva la presentazione
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Access a SmartArt Node**
Il codice di esempio seguente aiuterà ad accedere ai nodi all'interno della forma SmartArt. Si noti che non è possibile modificare il LayoutType dello SmartArt perché è di sola lettura e viene impostato solo quando la forma SmartArt viene aggiunta.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation) e carica la presentazione con la forma SmartArt.  
1. Ottieni il riferimento della prima diapositiva usando il suo indice.  
1. Scorri tutte le forme all'interno della prima diapositiva.  
1. Verifica se la forma è del tipo [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/) e, se lo è, esegui il cast del tipo selezionato a [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/).  
1. Scorri tutti i [**Nodes**](https://reference.aspose.com/slides/it/php-java/aspose.slides/SmartArt#getAllNodes--) all'interno della forma SmartArt.  
1. Accedi e visualizza informazioni come la posizione, il livello e il testo del nodo SmartArt.

```php
  # Istanziare la classe Presentation
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Ottieni la prima diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Scorri tutte le forme all'interno della prima diapositiva
    foreach($slide->getShapes() as $shape) {
      # Verifica se la forma è di tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Esegui il cast della forma a SmartArt
        $smart = $shape;
        # Scorri tutti i nodi all'interno di SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Accesso al nodo SmartArt all'indice i
          $node = $smart->getAllNodes()->get_Item($i);
          # Stampa i parametri del nodo SmartArt
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Access a SmartArt Child Node**
Il codice di esempio seguente aiuterà ad accedere ai nodi figlio appartenenti ai rispettivi nodi della forma SmartArt.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation) e carica la presentazione con la forma SmartArt.  
1. Ottieni il riferimento della prima diapositiva usando il suo indice.  
1. Scorri tutte le forme all'interno della prima diapositiva.  
1. Verifica se la forma è del tipo [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/) e, se lo è, esegui il cast del tipo selezionato a [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/).  
1. Scorri tutti i [**Nodes**](https://reference.aspose.com/slides/it/php-java/aspose.slides/SmartArt#getAllNodes--) all'interno della forma SmartArt.  
1. Per ogni [**Node**](https://reference.aspose.com/slides/it/php-java/aspose.slides/SmartArtNode) della forma SmartArt selezionata, scorri tutti i [**Child Nodes**](https://reference.aspose.com/slides/it/php-java/aspose.slides/SmartArtNode#getChildNodes--) all'interno del nodo particolare.  
1. Accedi e visualizza informazioni come la posizione, il livello e il testo del [**Child Node**](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartnode/#getChildNodes).

```php
  # Istanziare la classe Presentation
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Ottieni la prima diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Scorri tutte le forme all'interno della prima diapositiva
    foreach($slide->getShapes() as $shape) {
      # Verifica se la forma è di tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Esegui il cast della forma a SmartArt
        $smart = $shape;
        # Scorri tutti i nodi all'interno di SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Accesso al nodo SmartArt all'indice i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Scorrendo i nodi figlio nel nodo SmartArt all'indice i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Accesso al nodo figlio nel nodo SmartArt
            $node = $node0->getChildNodes()->get_Item($j);
            # Stampa i parametri del nodo figlio SmartArt
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Access a SmartArt Child Node at a Specific Position**
In questo esempio impareremo a accedere ai nodi figlio in una posizione specifica appartenenti ai rispettivi nodi della forma SmartArt.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).  
1. Ottieni il riferimento della prima diapositiva usando il suo indice.  
1. Aggiungi una forma SmartArt di tipo [**StackedList**](https://reference.aspose.com/slides/it/php-java/aspose.slides/SmartArtLayoutType#StackedList).  
1. Accedi alla forma SmartArt aggiunta.  
1. Accedi al nodo all'indice 0 della forma SmartArt ottenuta.  
1. Ora, accedi al [**Child Node**](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartnode/#getChildNodes) alla posizione 1 per il nodo SmartArt utilizzando il metodo **get_Item()**.  
1. Accedi e visualizza informazioni come la posizione, il livello e il testo del [**Child Node**](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartnode/#getChildNodes).

```php
  # Istanziare la presentazione
  $pres = new Presentation();
  try {
    # Accesso alla prima diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Aggiunta della forma SmartArt nella prima diapositiva
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Accesso al nodo SmartArt all'indice 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Accesso al nodo figlio alla posizione 1 nel nodo genitore
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # Stampa i parametri del nodo figlio SmartArt
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Remove a SmartArt Node**
In questo esempio impareremo a rimuovere i nodi all'interno della forma SmartArt.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation) e carica la presentazione con la forma SmartArt.  
1. Ottieni il riferimento della prima diapositiva usando il suo indice.  
1. Scorri tutte le forme all'interno della prima diapositiva.  
1. Verifica se la forma è del tipo [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/) e, se lo è, esegui il cast del tipo selezionato a [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/).  
1. Verifica se lo [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/) ha più di 0 nodi.  
1. Seleziona il nodo SmartArt da eliminare.  
1. Ora, rimuovi il nodo selezionato usando il metodo [**removeNode**](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartnodecollection/#removeNode).  
1. Salva la presentazione.

```php
  # Carica la presentazione desiderata
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Scorri tutte le forme all'interno della prima diapositiva
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Verifica se la forma è di tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Esegui il cast della forma a SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Accesso al nodo SmartArt all'indice 0
          $node = $smart->getAllNodes()->get_Item(0);
          # Rimozione del nodo selezionato
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # Salva la presentazione
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Remove a SmartArt Node from a Specific Position**
In questo esempio impareremo a rimuovere i nodi all'interno della forma SmartArt in una posizione particolare.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation) e carica la presentazione con la forma SmartArt.  
1. Ottieni il riferimento della prima diapositiva usando il suo indice.  
1. Scorri tutte le forme all'interno della prima diapositiva.  
1. Verifica se la forma è del tipo [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/) e, se lo è, esegui il cast del tipo selezionato a [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/).  
1. Seleziona il nodo della forma SmartArt all'indice 0.  
1. Ora, verifica se il nodo SmartArt selezionato ha più di 2 nodi figlio.  
1. Ora, rimuovi il nodo alla **Position 1** usando il metodo [**removeNode**](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartnodecollection/#removeNode).  
1. Salva la presentazione.

```php
  # Carica la presentazione desiderata
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Scorri tutte le forme all'interno della prima diapositiva
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Verifica se la forma è di tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Esegui il cast della forma a SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Accesso al nodo SmartArt all'indice 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # Rimozione del nodo figlio alla posizione 1
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # Salva la presentazione
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Set a Custom Position for a Child Node in a SmartArt Object**
Aspose.Slides for PHP via Java supporta l'impostazione delle proprietà [SmartArtShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#setX) e [Y](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#setY). Il frammento di codice qui sotto mostra come impostare la posizione personalizzata, le dimensioni e la rotazione di SmartArtShape; si noti inoltre che l'aggiunta di nuovi nodi provoca un ricalcolo delle posizioni e delle dimensioni di tutti i nodi. Con le impostazioni di posizione personalizzata l'utente può definire i nodi secondo le proprie esigenze.

```php
  # Istanziare la classe Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # Sposta la forma SmartArt in una nuova posizione
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # Modifica le larghezze della forma SmartArt
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # Modifica l'altezza della forma SmartArt
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # Modifica la rotazione della forma SmartArt
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Check an Assistant Node**
{{% alert color="primary" %}} 

In questo articolo esamineremo più in dettaglio le funzionalità delle forme SmartArt aggiunte alle diapositive della presentazione in modo programmatico usando Aspose.Slides for PHP via Java.

{{% /alert %}} 

Useremo la seguente forma SmartArt di origine per le indagini nelle diverse sezioni di questo articolo.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figura: Forma SmartArt di origine nella diapositiva**|

Nel codice di esempio seguente indagheremo come identificare i **Assistant Nodes** nella collezione di nodi SmartArt e modificarli.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation) e carica la presentazione con la forma SmartArt.  
1. Ottieni il riferimento della seconda diapositiva usando il suo indice.  
1. Scorri tutte le forme all'interno della prima diapositiva.  
1. Verifica se la forma è del tipo [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/) e, se lo è, esegui il cast del tipo selezionato a [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/).  
1. Scorri tutti i nodi all'interno della forma SmartArt e verifica se sono [**Assistant Nodes**](https://reference.aspose.com/slides/it/php-java/aspose.slides/SmartArtNode#isAssistant--).  
1. Cambia lo stato del nodo assistente in nodo normale.  
1. Salva la presentazione.

```php
  # Creazione di un'istanza di presentazione
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Scorri tutte le forme all'interno della prima diapositiva
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Verifica se la forma è di tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Esegui il cast della forma a SmartArt
        $smart = $shape;
        # Scorri tutti i nodi della forma SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Verifica se il nodo è un nodo assistente
          if ($node->isAssistant()) {
            # Impostare il nodo assistente su false e renderlo un nodo normale
            $node->isAssistant();
          }
        }
      }
    }
    # Salva la presentazione
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figura: Nodi assistenti modificati nella forma SmartArt nella diapositiva**|

## **Set a Node's Fill Format**
Aspose.Slides for PHP via Java rende possibile aggiungere forme SmartArt personalizzate e impostarne il formato di riempimento. Questo articolo spiega come creare e accedere alle forme SmartArt e impostare il loro formato di riempimento usando Aspose.Slides for PHP via Java.

Segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).  
1. Ottieni il riferimento di una diapositiva usando il suo indice.  
1. Aggiungi una forma [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/) impostando il suo [**LayoutType**](https://reference.aspose.com/slides/it/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).  
1. Imposta il [**Fill Format**](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getFillFormat) per i nodi della forma SmartArt.  
1. Scrivi la presentazione modificata come file PPTX.

```php
  # Istanziare la presentazione
  $pres = new Presentation();
  try {
    # Accesso alla diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Aggiunta della forma SmartArt e dei nodi
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # Impostazione del colore di riempimento del nodo
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # Salva la presentazione
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Generate a Thumbnail of a SmartArt Child Node**
Gli sviluppatori possono generare una miniatura del nodo figlio di uno SmartArt seguendo i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).  
1. [Add SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartnodecollection/#addNode).  
1. Ottieni il riferimento di un nodo usando il suo indice.  
1. Ottieni l'immagine della miniatura.  
1. Salva l'immagine della miniatura in qualsiasi formato immagine desiderato.

```php
  # Istanziare la classe Presentation che rappresenta il file PPTX
  $pres = new Presentation();
  try {
    # Aggiungi SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Ottieni il riferimento di un nodo usando il suo indice
    $node = $smart->getNodes()->get_Item(1);
    # Ottieni l'anteprima
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # Salva l'anteprima
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
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

## **FAQ**

**L'animazione SmartArt è supportata?**

Sì. SmartArt è trattato come una forma normale, quindi puoi [applicare animazioni standard](/slides/it/php-java/shape-animation/) (entrata, uscita, enfasi, percorsi di movimento) e regolare i tempi. Puoi anche animare le forme all'interno dei nodi SmartArt quando necessario.

**Come posso individuare in modo affidabile uno SmartArt specifico su una diapositiva se il suo ID interno è sconosciuto?**

Assegna e cerca tramite [testo alternativo](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getalternativetext/). Impostare un AltText distintivo sullo SmartArt consente di trovarlo programmaticamente senza dipendere da identificatori interni.

**L'aspetto di SmartArt verrà conservato durante la conversione della presentazione in PDF?**

Sì. Aspose.Slides rende SmartArt con alta fedeltà visiva durante l'[esportazione in PDF](/slides/it/php-java/convert-powerpoint-to-pdf/), preservando layout, colori ed effetti.

**Posso estrarre un'immagine dell'intero SmartArt (per anteprime o report)?**

Sì. Puoi renderizzare una forma SmartArt in [formati raster](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getImage) o in [SVG](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/writeassvg/) per un output vettoriale scalabile, rendendolo adatto a miniature, report o utilizzo web.