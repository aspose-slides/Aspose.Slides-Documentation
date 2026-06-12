---
title: Gestisci forme della presentazione in PHP
linktitle: Manipolazione delle forme
type: docs
weight: 40
url: /it/php-java/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma della presentazione
- Forma sulla diapositiva
- Trova forma
- Clona forma
- Rimuovi forma
- Nascondi forma
- Cambia ordine della forma
- Ottieni ID Interop della forma
- Testo alternativo della forma
- Formati di layout della forma
- Forma come SVG
- Forma in SVG
- Allinea forma
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Impara a creare, modificare e ottimizzare le forme in Aspose.Slides per PHP via Java e a fornire presentazioni PowerPoint ad alte prestazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con le forme nelle presentazioni usando Aspose.Slides. Mostra come trovare una forma su una diapositiva, clonarla, rimuoverla, nasconderla, cambiare il suo ordine, ottenere il suo ID Interop, e impostare il testo alternativo per l’identificazione e l’elaborazione successiva.

Copre anche come accedere ai formati di layout per le forme, esportare una forma come SVG, allineare le forme su una diapositiva e utilizzare le proprietà di flip per il mirroring orizzontale e verticale. Inoltre, l’articolo include una breve FAQ su combinazione di forme, ordine di impilamento e blocco delle forme.

## **Trova una forma su una diapositiva**
Questo argomento descriverà una tecnica semplice per facilitare gli sviluppatori nel trovare una forma specifica su una diapositiva senza usare il suo Id interno. È importante sapere che i file di presentazione PowerPoint non hanno alcun modo per identificare le forme su una diapositiva se non tramite un Id interno univoco. Risulta difficile per gli sviluppatori trovare una forma usando il suo Id interno univoco. Tutte le forme aggiunte alle diapositive hanno un Testo Alternativo. Suggeriamo agli sviluppatori di usare il testo alternativo per trovare una forma specifica. È possibile usare MS PowerPoint per definire il testo alternativo per gli oggetti che si prevede di modificare in futuro.

Dopo aver impostato il testo alternativo della forma desiderata, è possibile aprire quella presentazione usando Aspose.Slides for PHP via Java e iterare attraverso tutte le forme aggiunte a una diapositiva. Durante ogni iterazione si può controllare il testo alternativo della forma e la forma con il testo alternativo corrispondente sarà quella richiesta. Per dimostrare meglio questa tecnica, abbiamo creato un metodo, [findShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) che fa il trucco per trovare una forma specifica in una diapositiva e restituisce semplicemente quella forma.

```php
  # Istanzia una classe Presentation che rappresenta il file di presentazione
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Testo alternativo della forma da trovare
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Clona una forma**
Per clonare una forma su una diapositiva usando Aspose.Slides for PHP via Java:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Ottieni il riferimento di una diapositiva usando il suo indice.
1. Accedi alla raccolta di forme della diapositiva di origine.
1. Aggiungi una nuova diapositiva alla presentazione.
1. Clona le forme dalla raccolta di forme della diapositiva di origine alla nuova diapositiva.
1. Salva la presentazione modificata come file PPTX.

L’esempio sotto aggiunge una forma gruppo a una diapositiva.

```php
  # Istanzia la classe Presentation
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # Scrivi il file PPTX su disco
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Rimuovi una forma**
Aspose.Slides for PHP via Java consente agli sviluppatori di rimuovere qualsiasi forma. Per rimuovere la forma da una diapositiva, segui i passaggi seguenti:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Accedi alla prima diapositiva.
1. Trova la forma con il TestoAlternativo specifico.
1. Rimuovi la forma.
1. Salva il file su disco.

```php
  # Crea oggetto Presentation
  $pres = new Presentation();
  try {
    # Ottieni la prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Aggiungi autoshape di tipo rettangolo
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # Salva la presentazione su disco
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nascondi una forma**
Aspose.Slides for PHP via Java consente agli sviluppatori di nascondere qualsiasi forma. Per nascondere la forma da una diapositiva, segui i passaggi seguenti:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Accedi alla prima diapositiva.
1. Trova la forma con il TestoAlternativo specifico.
1. Nascondi la forma.
1. Salva il file su disco.

```php
  # Istanzia la classe Presentation che rappresenta il file PPTX
  $pres = new Presentation();
  try {
    # Ottieni la prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Aggiungi autoshape di tipo rettangolo
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # Salva la presentazione su disco
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Cambia l’ordine della forma**
Aspose.Slides for PHP via Java consente agli sviluppatori di riordinare le forme. Riordinare la forma specifica quale forma è in primo piano o sullo sfondo. Per riordinare la forma da una diapositiva, segui i passaggi seguenti:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Accedi alla prima diapositiva.
1. Aggiungi una forma.
1. Aggiungi del testo nel frame di testo della forma.
1. Aggiungi un’altra forma con le stesse coordinate.
1. Riordina le forme.
1. Salva il file su disco.

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ottieni l’ID Interop della forma**
Aspose.Slides for PHP via Java consente agli sviluppatori di ottenere un identificatore univoco della forma nel contesto della diapositiva, in contrasto con il metodo [getUniqueId](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getuniqueid/) che fornisce un identificatore univoco a livello di presentazione. Il metodo [getOfficeInteropShapeId](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getofficeinteropshapeid/) è stato aggiunto alla classe [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/). Il valore restituito da [getOfficeInteropShapeId](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getofficeinteropshapeid/) corrisponde al valore dell’Id dell’oggetto Microsoft.Office.Interop.PowerPoint.Shape. Di seguito è riportato un esempio di codice.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Ottenere l'identificatore univoco della forma nell'ambito della diapositiva
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Imposta il Testo Alternativo per una forma**
Aspose.Slides for PHP via Java consente agli sviluppatori di impostare l’AlternateText di qualsiasi forma. Le forme in una presentazione possono essere distinte dal `Testo Alternativo` o dal metodo [Shape Name](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/setname/). I metodi [setAlternativeText](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/setalternativetext/) e [getAlternativeText](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getalternativetext/) possono essere letti o impostati sia con Aspose.Slides sia con Microsoft PowerPoint. Utilizzando questo metodo, è possibile etichettare una forma e eseguire operazioni diverse come rimuovere una forma, nascondere una forma o riordinare le forme su una diapositiva. Per impostare l’AlternateText di una forma, segui i passaggi seguenti:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Accedi alla prima diapositiva.
1. Aggiungi qualsiasi forma alla diapositiva.
1. Esegui alcune operazioni con la forma appena aggiunta.
1. Scorri le forme per trovare una forma.
1. Imposta il TestoAlternativo.
1. Salva il file su disco.

```php
  # Instanzia la classe Presentation che rappresenta il PPTX
  $pres = new Presentation();
  try {
    # Ottieni la prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Aggiungi autoshape di tipo rettangolo
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # Salva la presentazione su disco
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Accedi ai Formati di Layout per una forma**
Aspose.Slides for PHP via Java fornisce un’API semplice per accedere ai formati di layout di una forma. Questo articolo dimostra come è possibile accedere ai formati di layout.

Di seguito è riportato il codice di esempio.

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Esporta una forma come SVG**
Ora Aspose.Slides for PHP via Java supporta l’esportazione di una forma come SVG. Il metodo [writeAsSvg](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/writeassvg/) (e le sue overload) è stato aggiunto alla classe [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/). Questo metodo consente di salvare il contenuto della forma come file SVG. Lo snippet di codice sotto mostra come esportare la forma di una diapositiva in un file SVG.

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Allinea una forma**
Aspose.Slides consente di allineare le forme sia rispetto ai margini della diapositiva sia rispetto a loro stesse. A tal fine, è stato aggiunto il metodo sovraccaricato [SlidesUtil::alignShapes](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideutil/alignshapes/). L’enumerazione [ShapesAlignmentType](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapesalignmenttype/) definisce le possibili opzioni di allineamento.

**Esempio 1**

Il codice sorgente qui sotto allinea le forme con indici 1, 2 e 4 lungo il bordo superiore della diapositiva.

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Esempio 2**

L’esempio qui sotto mostra come allineare l’intera raccolta di forme rispetto alla forma più bassa della raccolta.

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Proprietà di Flip**

In Aspose.Slides, la classe [ShapeFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapeframe/) fornisce il controllo sul mirroring orizzontale e verticale delle forme tramite le sue proprietà `flipH` e `flipV`. Entrambe le proprietà sono di tipo [NullableBool](https://reference.aspose.com/slides/it/php-java/aspose.slides/nullablebool/), consentendo i valori `True` per indicare un flip, `False` per nessun flip, o `NotDefined` per usare il comportamento predefinito. Questi valori sono accessibili dal [Frame](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getFrame) di una forma.

Per modificare le impostazioni di flip, viene costruita una nuova istanza di [ShapeFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapeframe/) con la posizione e le dimensioni correnti della forma, i valori desiderati per `flipH` e `flipV`, e l’angolo di rotazione. Assegnando questa istanza al [Frame](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getFrame) della forma e salvando la presentazione, si applicano le trasformazioni di mirror e si registrano nel file di output.

Supponiamo di avere un file sample.pptx in cui la prima diapositiva contiene una singola forma con impostazioni di flip predefinite, come mostrato sotto.

![The shape to be flipped](shape_to_be_flipped.png)

Il seguente esempio di codice recupera le proprietà di flip correnti della forma e le inverte sia orizzontalmente sia verticalmente.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // Recupera la proprietà di flip orizzontale della forma.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // Recupera la proprietà di flip verticale della forma.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // Capovolgi orizzontalmente.
    $flipV = NullableBool::True; // Capovolgi orizzontalmente.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Posso combinare le forme (unione/intersezione/sottrazione) su una diapositiva come in un editor desktop?**

Non esiste un’API di operazioni booleane integrata. È possibile avvicinarsi costruendo manualmente il contorno desiderato—ad esempio calcolando la geometria risultante (tramite [GeometryPath](https://reference.aspose.com/slides/it/php-java/aspose.slides/geometrypath/)) e creando una nuova forma con quel contorno, rimuovendo eventualmente le originali.

**Come posso controllare l’ordine di impilamento (z-order) affinché una forma rimanga sempre “in cima”?**

Modifica l’ordine di inserimento/spostamento all’interno della collezione di [shapes](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslide/#getShapes) della diapositiva. Per risultati prevedibili, finalizza lo z-order dopo tutte le altre modifiche della diapositiva.

**Posso “bloccare” una forma per impedire agli utenti di modificarla in PowerPoint?**

Sì. Imposta i flag di protezione a livello di forma (ad esempio blocco selezione, spostamento, ridimensionamento, modifiche al testo). Se necessario, applica restrizioni analoghe al master o al layout. Nota che si tratta di protezione a livello UI, non di una funzionalità di sicurezza; per una protezione più forte, combina con restrizioni a livello di file come [raccomandazioni di sola lettura o password](/slides/it/php-java/password-protected-presentation/).