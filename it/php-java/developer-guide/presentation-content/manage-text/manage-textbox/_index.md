---
title: Gestire le caselle di testo nelle presentazioni usando PHP
linktitle: Gestisci casella di testo
type: docs
weight: 20
url: /it/php-java/manage-textbox/
keywords:
- casella di testo
- frame di testo
- aggiungere testo
- aggiornare testo
- creare casella di testo
- verificare casella di testo
- aggiungere colonna di testo
- aggiungere collegamento ipertestuale
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Aspose.Slides per PHP semplifica la creazione, la modifica e la clonazione delle caselle di testo in file PowerPoint e OpenDocument, migliorando l'automazione delle tue presentazioni."
---
## **Introduzione**

I testi nelle diapositive esistono tipicamente in caselle di testo o forme. Pertanto, per aggiungere del testo a una diapositiva, è necessario aggiungere una casella di testo e poi inserire del testo all'interno della casella. Aspose.Slides per PHP via Java fornisce la classe [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) che consente di aggiungere una forma contenente del testo.

{{% alert title="Info" color="info" %}}
Aspose.Slides fornisce anche la classe [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/) che consente di aggiungere forme alle diapositive. Tuttavia, non tutte le forme aggiunte tramite la classe `Shape` possono contenere testo. Ma le forme aggiunte tramite la classe [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) possono contenere testo.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Pertanto, quando si lavora con una forma a cui si desidera aggiungere testo, potrebbe essere necessario verificare e confermare che sia stata convertita tramite la classe `AutoShape`. Solo in questo modo sarà possibile utilizzare [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/), che è una proprietà di `AutoShape`. Vedi la sezione [Update Text](/slides/it/php-java/manage-textbox/#update-text) in questa pagina.
{{% /alert %}}

## **Creare una casella di testo su una diapositiva**

Per creare una casella di testo su una diapositiva, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni un riferimento alla prima diapositiva nella presentazione appena creata. 
3. Aggiungi un oggetto [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) con il tipo di forma impostato su [Rectangle](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapetype/#Rectangle) in una posizione specificata sulla diapositiva e ottieni il riferimento per il nuovo oggetto `AutoShape`.
4. Aggiungi un `TextFrame` all'oggetto `AutoShape` che conterrà del testo. Nell'esempio seguente, abbiamo aggiunto questo testo: *Aspose TextBox*
5. Infine, scrivi il file PPTX tramite l'oggetto `Presentation`. 

Questo codice PHP—un'implementazione dei passaggi precedenti—mostra come aggiungere testo a una diapositiva:

```php
  # Istanzia la presentazione
  $pres = new Presentation();
  try {
    # Ottiene la prima diapositiva nella presentazione
    $sld = $pres->getSlides()->get_Item(0);
    # Aggiunge un AutoShape con tipo impostato su Rettangolo
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Aggiunge TextFrame al Rettangolo
    $ashp->addTextFrame(" ");
    # Accede al frame di testo
    $txtFrame = $ashp->getTextFrame();
    # Crea l'oggetto Paragraph per il frame di testo
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Crea un oggetto Portion per il paragrafo
    $portion = $para->getPortions()->get_Item(0);
    # Imposta il testo
    $portion->setText("Aspose TextBox");
    # Salva la presentazione su disco
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Verificare una forma di casella di testo**

Aspose.Slides fornisce il metodo [isTextBox](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/istextbox/) della classe [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/), consentendo di esaminare le forme e identificare le caselle di testo.

![Casella di testo e forma](istextbox.png)

Questo codice PHP mostra come verificare se una forma è stata creata come casella di testo:

```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Nota che se si aggiunge semplicemente un autoshape utilizzando il metodo `addAutoShape` della classe [ShapeCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/), il metodo `isTextBox` dell'autoshape restituirà `false`. Tuttavia, dopo aver aggiunto testo all'autoshape usando il metodo `addTextFrame` o il metodo `setText`, la proprietà `isTextBox` restituisce `true`.

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() restituisce false
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() restituisce true

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() restituisce false
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() restituisce true

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() restituisce false
$shape3->addTextFrame("");
// shape3->isTextBox() restituisce false

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() restituisce false
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() restituisce false
```

## **Aggiungere colonne a una casella di testo**

Aspose.Slides fornisce i metodi [setColumnCount](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/setcolumncount/) e [setColumnSpacing](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/setcolumnspacing/) della classe [TextFrameFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/) che consentono di aggiungere colonne alle caselle di testo. È possibile specificare il numero di colonne in una casella di testo e impostare la spaziatura in punti tra le colonne.

Questo codice dimostra l'operazione descritta:

```php
  $pres = new Presentation();
  try {
    # Recupera la prima diapositiva nella presentazione
    $slide = $pres->getSlides()->get_Item(0);
    # Aggiunge un AutoShape con tipo impostato su Rettangolo
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Aggiunge TextFrame al Rettangolo
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Recupera il formato del testo del TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Specifica il numero di colonne nel TextFrame
    $format->setColumnCount(3);
    # Specifica la spaziatura tra le colonne
    $format->setColumnSpacing(10);
    # Salva la presentazione
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aggiungere colonne a un Text Frame**

Aspose.Slides per PHP via Java fornisce il metodo [setColumnCount](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/setcolumncount/) della classe [TextFrameFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/) che consente di aggiungere colonne nei frame di testo. Attraverso questa proprietà, è possibile specificare il numero preferito di colonne in un frame di testo.

Questo codice PHP mostra come aggiungere una colonna all'interno di un frame di testo:

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aggiornare il testo**

Aspose.Slides consente di modificare o aggiornare il testo contenuto in una casella di testo o tutti i testi contenuti in una presentazione. 

Questo codice PHP dimostra un'operazione in cui tutti i testi di una presentazione vengono aggiornati o modificati:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Verifica se la forma supporta il frame di testo (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Scorre i paragrafi nel frame di testo
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Scorre ogni porzione nel paragrafo
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Modifica il testo

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Modifica la formattazione

            }
          }
        }
      }
    }
    # Salva la presentazione modificata
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aggiungere una casella di testo con un collegamento ipertestuale** 

È possibile inserire un collegamento all'interno di una casella di testo. Quando la casella di testo viene cliccata, gli utenti vengono indirizzati ad aprire il collegamento. 

Per aggiungere una casella di testo contenente un collegamento, segui questi passaggi:

1. Crea un'istanza della classe `Presentation`. 
2. Ottieni un riferimento alla prima diapositiva nella presentazione appena creata. 
3. Aggiungi un oggetto `AutoShape` con `ShapeType` impostato su `Rectangle` in una posizione specificata sulla diapositiva e ottieni un riferimento al nuovo oggetto AutoShape aggiunto.
4. Aggiungi un `TextFrame` all'oggetto `AutoShape` che contiene *Aspose TextBox* come testo predefinito. 
5. Istanzia la classe `HyperlinkManager`. 
6. Assegna un collegamento ipertestuale usando il metodo [setExternalHyperlinkClick](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) associato alla porzione desiderata del `TextFrame`.
7. Infine, scrivi il file PPTX tramite l'oggetto `Presentation`. 

Questo codice PHP—un'implementazione dei passaggi sopra—mostra come aggiungere una casella di testo con un collegamento ipertestuale a una diapositiva:

```php
  # Istanzia una classe Presentation che rappresenta un PPTX
  $pres = new Presentation();
  try {
    # Ottiene la prima diapositiva nella presentazione
    $slide = $pres->getSlides()->get_Item(0);
    # Aggiunge un oggetto AutoShape con tipo impostato su Rettangolo
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Effettua il cast della forma a AutoShape
    $pptxAutoShape = $shape;
    # Accede alla proprietà ITextFrame associata all'AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Aggiunge del testo al frame
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Imposta il collegamento ipertestuale per il testo della porzione
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Salva la presentazione PPTX
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Qual è la differenza tra una casella di testo e un segnaposto di testo quando si lavora con le diapositive master?**

Un [placeholder](/slides/it/php-java/manage-placeholder/) eredita stile/posizione dal [master](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslide/) e può essere sovrascritto nei [layout](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslide/), mentre una casella di testo normale è un oggetto indipendente su una diapositiva specifica e non cambia quando si cambiano i layout.

**Come posso eseguire una sostituzione massiva del testo in tutta la presentazione senza modificare il testo all'interno di grafici, tabelle e SmartArt?**

Limita l'iterazione alle auto-shape che hanno frame di testo ed escludi gli oggetti incorporati ([charts](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/it/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/)) attraversando le loro collezioni separatamente o saltando quei tipi di oggetti.