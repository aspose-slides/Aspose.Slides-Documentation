---
title: Personalizza le forme di presentazione in PHP
linktitle: Forma personalizzata
type: docs
weight: 20
url: /it/php-java/custom-shape/
keywords:
- forma personalizzata
- aggiungi forma
- crea forma
- modifica forma
- geometria della forma
- percorso geometrico
- punti del percorso
- punti di modifica
- aggiungi punto
- rimuovi punto
- operazione di modifica
- angolo curvo
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Crea e personalizza forme nelle presentazioni PowerPoint con Aspose.Slides per PHP via Java: percorsi geometrici, angoli curvi, forme composite."
---
## **Panoramica**

Questo articolo spiega come personalizzare le forme delle presentazioni in Aspose.Slides modificando la geometria delle forme tramite punti di modifica e percorsi geometrici. Mostra come lavorare con `GeometryPath` per modificare forme esistenti, eseguire operazioni di modifica di base sui percorsi, aggiungere o rimuovere punti e applicare la geometria aggiornata a una forma.

Dimostra inoltre come creare forme personalizzate e composite, costruire forme con angoli curvi, determinare se la geometria di una forma è chiusa e convertire tra `GeometryPath` e `java.awt.Shape` per scenari aggiuntivi di personalizzazione geometrica.

## **Modifica una forma usando i punti di modifica**
Considera un quadrato. In PowerPoint, usando **punti di modifica**, puoi

* spostare l'angolo del quadrato verso l'interno o verso l'esterno
* specificare la curvatura per un angolo o un punto
* aggiungere nuovi punti al quadrato
* manipolare i punti del quadrato, ecc.

Essenzialmente, puoi eseguire le attività descritte su qualsiasi forma. Usando i punti di modifica, puoi cambiare una forma o crearne una nuova a partire da una forma esistente.

## **Suggerimenti per la modifica delle forme**

![overview_image](custom_shape_0.png)

Prima di iniziare a modificare le forme di PowerPoint tramite punti di modifica, potresti voler considerare questi aspetti delle forme:

* Una forma (o il suo percorso) può essere chiusa o aperta.
* Quando una forma è chiusa, non ha un punto di inizio o di fine. Quando è aperta, ha un inizio e una fine. 
* Tutte le forme sono composte da almeno 2 punti di ancoraggio collegati tra loro da linee
* Una linea è dritta o curva. I punti di ancoraggio determinano la natura della linea. 
* I punti di ancoraggio possono essere punti d'angolo, punti dritti o punti levigati:
  * Un punto d'angolo è un punto in cui 2 linee rette si uniscono formando un angolo. 
  * Un punto levigato è un punto in cui 2 maniglie sono su una linea retta e i segmenti della linea si uniscono in una curva levigata. In questo caso, tutte le maniglie sono separate dal punto di ancoraggio di una distanza uguale. 
  * Un punto dritto è un punto in cui 2 maniglie sono su una linea retta e i segmenti di quella linea si uniscono in una curva levigata. In questo caso, le maniglie non devono essere separate dal punto di ancoraggio di una distanza uguale. 
* Spostando o modificando i punti di ancoraggio (che cambia l'angolo delle linee), è possibile modificare l'aspetto di una forma. 

Per modificare le forme di PowerPoint tramite punti di modifica, **Aspose.Slides** fornisce la classe [**GeometryPath**](https://reference.aspose.com/slides/it/php-java/aspose.slides/GeometryPath).

* Un'istanza di [GeometryPath](https://reference.aspose.com/slides/it/php-java/aspose.slides/GeometryPath) rappresenta un percorso geometrico dell'oggetto [GeometryShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/geometryshape/).
* Per recuperare il `GeometryPath` dall'istanza `GeometryShape`, puoi usare il metodo [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/it/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* Per impostare il `GeometryPath` per una forma, puoi usare questi metodi: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/it/php-java/aspose.slides/geometryshape/#setGeometryPath) per *forme solide* e [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/it/php-java/aspose.slides/geometryshape/#setGeometryPaths) per *forme composite*.
* Per aggiungere segmenti, puoi utilizzare i metodi sotto [GeometryPath](https://reference.aspose.com/slides/it/php-java/aspose.slides/geometrypath/).
* Utilizzando i metodi [GeometryPath::setStroke](https://reference.aspose.com/slides/it/php-java/aspose.slides/geometrypath/setstroke/) e [GeometryPath::setFillMode](https://reference.aspose.com/slides/it/php-java/aspose.slides/geometrypath/setfillmode/), puoi impostare l'aspetto di un percorso geometrico.
* Usando il metodo [GeometryPath::getPathData](https://reference.aspose.com/slides/it/php-java/aspose.slides/geometrypath/getpathdata/), puoi recuperare il percorso geometrico di un `GeometryShape` come un array di segmenti di percorso.
* Per accedere ad opzioni aggiuntive di personalizzazione della geometria della forma, puoi convertire [GeometryPath](https://reference.aspose.com/slides/it/php-java/aspose.slides/geometrypath/) in [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html)
* Usa i metodi [geometryPathToGraphicsPath](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapeutil/geometrypathtographicspath/) e [graphicsPathToGeometryPath](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapeutil/graphicspathtogeometrypath/) (dalla classe [ShapeUtil](https://reference.aspose.com/slides/it/php-java/aspose.slides/ShapeUtil)) per convertire [GeometryPath](https://reference.aspose.com/slides/it/php-java/aspose.slides/geometrypath/) in [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) e viceversa.

## **Operazioni di modifica semplici**

Questo codice PHP mostra come

**Aggiungi una linea** alla fine di un percorso

```php

```
**Aggiungi una linea** a una posizione specifica su un percorso:

```php

```
**Aggiungi una curva Bézier cubica** alla fine di un percorso:

```php

```
**Aggiungi una curva Bézier cubica** alla posizione specificata su un percorso:

```php

```
**Aggiungi una curva Bézier quadratica** alla fine di un percorso:

```php

```
**Aggiungi una curva Bézier quadratica** a una posizione specifica su un percorso:

```php

```
**Aggiungi un arco specificato** a un percorso:

```php

```
**Chiudi la figura corrente** di un percorso:

```php

```
**Imposta la posizione per il punto successivo**:

```php

```
**Rimuovi il segmento di percorso** a un indice specificato:

```php

```

## **Aggiungi punti personalizzati a una forma**
1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/GeometryShape) e imposta il tipo [ShapeType::Rectangle](https://reference.aspose.com/slides/it/php-java/aspose.slides/ShapeType).
2. Ottieni un'istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/php-java/aspose.slides/GeometryPath) dalla forma.
3. Aggiungi un nuovo punto tra i due punti superiori del percorso.
4. Aggiungi un nuovo punto tra i due punti inferiori del percorso.
5. Applica il percorso alla forma.

Questo codice PHP mostra come aggiungere punti personalizzati a una forma:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);
    $shape->setGeometryPath($geometryPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example1_image](custom_shape_1.png)

## **Rimuovi punti da una forma**

1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/GeometryShape) e imposta il tipo [ShapeType::Heart](https://reference.aspose.com/slides/it/php-java/aspose.slides/ShapeType).
2. Ottieni un'istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/php-java/aspose.slides/GeometryPath) dalla forma.
3. Rimuovi il segmento del percorso.
4. Applica il percorso alla forma.

Questo codice PHP mostra come rimuovere punti da una forma:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);
    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);
    $shape->setGeometryPath($path);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example2_image](custom_shape_2.png)

## **Crea una forma personalizzata**

1. Calcola i punti per la forma.
2. Crea un'istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/php-java/aspose.slides/GeometryPath).
3. Riempisci il percorso con i punti.
4. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/GeometryShape).
5. Applica il percorso alla forma.

Questo esempio Java mostra come creare una forma personalizzata:

```php
  $points = new Java("java.util.ArrayList");
  $R = 100;
  $r = 50;
  $step = 72;
  for($angle = -90; $angle < 270; $angle += $step) {
    $radians = $angle * java("java.lang.Math")->PI / 180.0;
    $x = $R * java("java.lang.Math")->cos($radians);
    $y = $R * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
    $radians = java("java.lang.Math")->PI * $angle . $step / 2 / 180.0;
    $x = $r * java("java.lang.Math")->cos($radians);
    $y = $r * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
  }
  $starPath = new GeometryPath();
  $starPath->moveTo($points->get(0));
  for($i = 1; $i < java_values($points->size()) ; $i++) {
    $starPath->lineTo($points->get($i));
  }
  $starPath->closeFigure();
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $R * 2, $R * 2);
    $shape->setGeometryPath($starPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example3_image](custom_shape_3.png)


## **Crea una forma personalizzata composita**

1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/GeometryShape).
2. Crea una prima istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/php-java/aspose.slides/GeometryPath).
3. Crea una seconda istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/php-java/aspose.slides/GeometryPath).
4. Applica i percorsi alla forma.

Questo codice PHP mostra come creare una forma personalizzata composita:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath0 = new GeometryPath();
    $geometryPath0->moveTo(0, 0);
    $geometryPath0->lineTo($shape->getWidth(), 0);
    $geometryPath0->lineTo($shape->getWidth(), $shape->getHeight() / 3);
    $geometryPath0->lineTo(0, $shape->getHeight() / 3);
    $geometryPath0->closeFigure();
    $geometryPath1 = new GeometryPath();
    $geometryPath1->moveTo(0, $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight());
    $geometryPath1->lineTo(0, $shape->getHeight());
    $geometryPath1->closeFigure();
    $shape->setGeometryPaths(array($geometryPath0, $geometryPath1 ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example4_image](custom_shape_4.png)

## **Crea una forma personalizzata con angoli curvi**

Questo codice PHP mostra come creare una forma personalizzata con angoli curvi (verso l'interno):

```php
  $shapeX = 20.0;
  $shapeY = 20.0;
  $shapeWidth = 300.0;
  $shapeHeight = 200.0;
  $leftTopSize = 50.0;
  $rightTopSize = 20.0;
  $rightBottomSize = 40.0;
  $leftBottomSize = 10.0;
  $pres = new Presentation();
  try {
    $childShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);
    $geometryPath = new GeometryPath();
    $point1 = new Point2DFloat($leftTopSize, 0);
    $point2 = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $point3 = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $point4 = new Point2DFloat($leftBottomSize, $shapeHeight);
    $point5 = new Point2DFloat(0, $leftTopSize);
    $geometryPath->moveTo($point1);
    $geometryPath->lineTo($point2);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($point3);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($point4);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($point5);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();
    $childShape->setGeometryPath($geometryPath);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Scopri se la geometria di una forma è chiusa**

Una forma chiusa è definita come una forma le cui estremità sono tutte connesse, formando un unico contorno senza spazi. Tale forma può essere una semplice figura geometrica o un contorno personalizzato complesso. L'esempio di codice seguente mostra come verificare se la geometria di una forma è chiusa:

```php
function isGeometryClosed($geometryShape)
{
    $isClosed = null;

    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $dataLength = count(java_values($geometryPath->getPathData()));
        if ($dataLength === 0) {
            continue;
        }

        $lastSegment = java_values($geometryPath->getPathData())[$dataLength - 1];
        $isClosed = $lastSegment->getPathCommand() === PathCommandType::Close;

        if ($isClosed === false) {
            return false;
        }
    }

    return $isClosed === true;
}
```

## **Converti GeometryPath in java.awt.Shape** 

1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/GeometryShape).
2. Crea un'istanza della classe [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
3. Converte l'istanza [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) nell'istanza [GeometryPath](https://reference.aspose.com/slides/it/php-java/aspose.slides/GeometryPath) usando [ShapeUtil](https://reference.aspose.com/slides/it/php-java/aspose.slides/ShapeUtil).
4. Applica i percorsi alla forma.

Questo codice PHP—un'implementazione dei passaggi sopra—dimostra il processo di conversione da **GeometryPath** a **GraphicsPath**:

```php
  $pres = new Presentation();
  try {
    # Crea una nuova forma
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # Ottieni il percorso geometrico della forma
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # Crea un nuovo percorso grafico con testo
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "Text in shape";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # Converti il percorso grafico in percorso geometrico
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # Imposta la combinazione del nuovo percorso geometrico e del percorso geometrico originale sulla forma
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Cosa accade al riempimento e al contorno dopo aver sostituito la geometria?**

Lo stile rimane associato alla forma; solo il contorno cambia. Il riempimento e il contorno vengono applicati automaticamente alla nuova geometria.

**Come ruoto correttamente una forma personalizzata insieme alla sua geometria?**

Usa il metodo [setRotation](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/setrotation/) della forma; la geometria ruota con la forma perché è legata al sistema di coordinate della forma stessa.

**Posso convertire una forma personalizzata in un'immagine per “bloccare” il risultato?**

Sì. Esporta l'area della [slide](/slides/it/php-java/convert-powerpoint-to-png/) o la [shape](/slides/it/php-java/create-shape-thumbnails/) stessa in un formato raster; questo semplifica il lavoro successivo con geometrie complesse.