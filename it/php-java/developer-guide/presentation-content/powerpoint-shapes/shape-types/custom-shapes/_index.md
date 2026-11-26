---
title: Personalizza le forme delle presentazioni in PHP
linktitle: Forma personalizzata
type: docs
weight: 20
url: /it/php-java/custom-shape/
keywords:
- forma personalizzata
- aggiungi forma
- crea forma
- modifica forma
- geometria forma
- percorso geometrico
- punti percorso
- modifica punti
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

Questo articolo spiega come personalizzare le forme di presentazione in Aspose.Slides modificando la geometria della forma tramite i punti di modifica e i percorsi geometrici. Mostra come lavorare con [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) per modificare forme esistenti, eseguire operazioni di modifica di base del percorso, aggiungere o rimuovere punti e applicare la geometria aggiornata a una forma.

Dimostra inoltre come creare forme personalizzate e composite, costruire forme con angoli curvi, determinare se la geometria di una forma è chiusa, ispezionare gli elementi della forma e convertire i contorni di testo Java AWT in percorsi geometrici.

## **Modifica una Forma con i Punti di Modifica**

In PowerPoint, è possibile utilizzare **Edit Points** per modificare un quadrato:

* Spostare un angolo verso l’interno o verso l’esterno.
* Regolare la curvatura in un punto.
* Aggiungere nuovi punti.

Modificare i punti consente di cambiare il contorno di una forma o di utilizzare una forma esistente come base per una nuova.

## **Suggerimenti per la Modifica delle Forme**

![overview_image](custom_shape_0.png)

Quando si modificano le forme di PowerPoint, tenere presente questi concetti:

* Una forma (o il suo percorso) può essere chiusa o aperta.
* Il percorso di una forma è costituito da punti di ancoraggio collegati da segmenti.
* Un segmento può essere lineare o curvo. I punti di ancoraggio e le maniglie di controllo determinano la sua forma.
* I punti di ancoraggio esistono come punti d’angolo, punti lineari o punti lisci:
  * In un punto d’angolo, i segmenti adiacenti possono incontrarsi con un angolo.
  * In un punto liscio, le due maniglie di controllo sono allineate e alla stessa distanza dal punto di ancoraggio.
  * In un punto lineare, le due maniglie di controllo sono allineate ma possono trovarsi a distanze diverse dal punto di ancoraggio.
* Spostare i punti di ancoraggio o regolare le loro maniglie cambia il contorno della forma.

Per modificare le forme di PowerPoint tramite i punti di modifica, **Aspose.Slides** fornisce la classe [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

* Un’istanza di [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) rappresenta il percorso geometrico dell’oggetto [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/).
* Per ottenere il [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) da un’istanza di [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/), è possibile utilizzare il metodo [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* Per impostare il [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) per una forma, è possibile usare questi metodi: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) per forme con un singolo percorso e [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) per forme con percorsi multipli.
* Per aggiungere segmenti, è possibile usare i metodi sotto [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).
* Utilizzando i metodi [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) e [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode), è possibile impostare l’aspetto di un percorso geometrico.
* Con il metodo [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) è possibile recuperare il percorso geometrico di un [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) come un array di segmenti del percorso.
* Per accedere a ulteriori opzioni di personalizzazione della geometria della forma, è possibile leggere un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) tramite il suo [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) e riprodurre i segmenti su un [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

## **Operazioni di Modifica Semplici**

Utilizzare i seguenti metodi per modificare un percorso geometrico. Le sovraccarichi che accettano un indice inseriscono un segmento in quella posizione zero‑based nell’array dei segmenti del percorso.

| Operazione | Metodo |
| --- | --- |
| Aggiungere o inserire una linea retta. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| Aggiungere o inserire una curva Bézier cubica con due punti di controllo e un punto finale. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Aggiungere o inserire una curva Bézier quadratica con un punto di controllo e un punto finale. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Aggiungere un arco ellittico con le dimensioni e gli angoli specificati in gradi. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Chiudere la figura corrente collegando il suo punto finale al punto di partenza. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Impostare il punto di partenza di una figura. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Rimuovere un segmento in una posizione zero‑based. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Aggiungere Punti Personalizzati a una Forma**

Questo esempio inserisce due punti in una forma rettangolare usando [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) e applica il percorso modificato con [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath). Le coordinate sono locali alla forma: entrambi i nuovi punti sono al suo centro, a 100 punti dal lato sinistro e 50 punti dall’alto. Gli indici dei segmenti 1 e 4 li posizionano sui bordi superiore e inferiore, tirando quei bordi verso l’interno.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);

    $shape->setGeometryPath($geometryPath);
} finally {
    $presentation->dispose();
}
```

![example1_image](custom_shape_1.png)

## **Rimuovere Punti da una Forma**

Questo esempio modifica il contorno a forma di cuore rimuovendo il segmento all’indice zero‑based 2 con [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt). Applicare il percorso modificato con [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) aggiorna il profilo della forma.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);

    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);

    $shape->setGeometryPath($path);
} finally {
    $presentation->dispose();
}
```
![example2_image](custom_shape_2.png)

## **Creare una Forma Personalizzata**

Questo esempio costruisce una stella a cinque punte con [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/). Raggi esterni e interni alternati di 100 e 50 punti definiscono le punte e le rientranze; un passo di 72 gradi distribuisce uniformemente le cinque punte. Il percorso è chiuso con [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) e applicato a una forma rettangolare usando [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), sostituendo il suo contorno.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$points = [];
$outerRadius = 100;
$innerRadius = 50;
$angleStep = 72;
for ($angle = -90; $angle < 270; $angle += $angleStep) {
    $radians = deg2rad($angle);
    $points[] = [$outerRadius * cos($radians) + $outerRadius, $outerRadius * sin($radians) + $outerRadius];
    $radians = deg2rad($angle + $angleStep / 2);
    $points[] = [$innerRadius * cos($radians) + $outerRadius, $innerRadius * sin($radians) + $outerRadius];
}

$starPath = new GeometryPath();
$starPath->moveTo($points[0][0], $points[0][1]);
for ($i = 1; $i < count($points); $i++) {
    $starPath->lineTo($points[$i][0], $points[$i][1]);
}
$starPath->closeFigure();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $outerRadius * 2, $outerRadius * 2);
    $shape->setGeometryPath($starPath);
} finally {
    $presentation->dispose();
}
```
![example3_image](custom_shape_3.png)

## **Creare una Forma Personalizzata Compostea**

Questo esempio definisce due [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) chiusi per il terzo superiore e inferiore di una forma. Applicare entrambi i percorsi con [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) crea una singola forma composita con uno spazio nel terzo centrale.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $topPath = new GeometryPath();
    $topPath->moveTo(0, 0);
    $topPath->lineTo(java_values($shape->getWidth()), 0);
    $topPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3);
    $topPath->lineTo(0, java_values($shape->getHeight()) / 3);
    $topPath->closeFigure();

    $bottomPath = new GeometryPath();
    $bottomPath->moveTo(0, java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()));
    $bottomPath->lineTo(0, java_values($shape->getHeight()));
    $bottomPath->closeFigure();

    $shape->setGeometryPaths([$topPath, $bottomPath]);
} finally {
    $presentation->dispose();
}
```
![example4_image](custom_shape_4.png)

## **Creare una Forma Personalizzata con Angoli Curvi**

Questo esempio combina segmenti lineari con [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) per creare una forma con angoli curvi verso l’interno. Ogni dimensione dell’angolo imposta la larghezza e l’altezza dell’arco in punti, e la sweep di –90 gradi disegna un quarto di ellisse in senso antiorario. Il percorso completato è applicato con [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), e la presentazione è salvata in formato PPTX.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$shapeX = 20;
$shapeY = 20;
$shapeWidth = 300;
$shapeHeight = 200;

$leftTopSize = 50;
$rightTopSize = 20;
$rightBottomSize = 40;
$leftBottomSize = 10;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);

    $topLeft = new Point2DFloat($leftTopSize, 0);
    $topRight = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $rightBottom = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $bottomLeft = new Point2DFloat($leftBottomSize, $shapeHeight);
    $leftTop = new Point2DFloat(0, $leftTopSize);

    $geometryPath = new GeometryPath();
    $geometryPath->moveTo($topLeft);
    $geometryPath->lineTo($topRight);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($rightBottom);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($bottomLeft);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($leftTop);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();

    $shape->setGeometryPath($geometryPath);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Verificare se una Geometria di Forma è Chiusa**

L’helper seguente controlla se ogni percorso geometrico non vuoto termina con un segmento di chiusura. Legge [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) e confronta il [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) finale con [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/). Restituisce false quando non ci sono percorsi non vuoti. Questo verifica il comando finale di ogni percorso; non ispeziona ogni sotto‑figura all’interno di un percorso. L’esempio stampa `true` per un rettangolo.

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function isGeometryClosed($geometryShape)
{
    $hasNonemptyPath = false;
    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $segments = java_values($geometryPath->getPathData());
        if (count($segments) === 0) {
            continue;
        }
        $hasNonemptyPath = true;
        $lastSegment = $segments[count($segments) - 1];
        if (java_values($lastSegment->getPathCommand()) !== PathCommandType::Close) {
            return false;
        }
    }
    return $hasNonemptyPath;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $closed = isGeometryClosed($shape);
    echo ($closed ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Ispezionare i Comandi del Percorso Geometrico**

Scaricare [contour.pptx](contour.pptx) e collocarlo nella directory di lavoro dell’applicazione. La prima forma nella prima diapositiva ha un bordo superiore lineare, una curva Bézier cubica e un bordo di chiusura lineare. Utilizzare [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) per leggere i percorsi della forma e [getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) per leggere i segmenti di ciascun percorso nell’ordine di disegno. Per ogni segmento, [getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) identifica il comando e determina come interpretare i valori restituiti da [getSegmentData](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getSegmentData).

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;

$presentation = new Presentation("contour.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    foreach ($shape->getGeometryPaths() as $pathIndex => $path) {
        foreach ($path->getPathData() as $segmentIndex => $segment) {
            $command = java_values($segment->getPathCommand());
            $data = java_values($segment->getSegmentData());
            switch ($command) {
                case PathCommandType::MoveTo:
                case PathCommandType::LineTo:
                    $name = $command === PathCommandType::MoveTo ? "MoveTo" : "LineTo";
                    $detail = sprintf("destination=(%s, %s)", ...$data);
                    break;
                case PathCommandType::CubicBezierTo:
                    $name = "CubicBezierTo";
                    $detail = sprintf("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", ...$data);
                    break;
                case PathCommandType::Close:
                    $name = "Close";
                    $detail = "no coordinates";
                    break;
                default:
                    $name = "Command " . $command;
                    $detail = "raw=" . json_encode($data);
            }
            printf("Path %d, segment %d: %s %s\n", $pathIndex, $segmentIndex, $name, $detail);
        }
    }
} finally {
    $presentation->dispose();
}
```

La forma si trova a (200, 100) punti sulla diapositiva. Le coordinate riportate sono locali alla forma, con (0, 0) nell’angolo in alto a sinistra, x che aumenta verso destra e y che aumenta verso il basso. Il segmento di chiusura torna al punto di partenza senza coordinate aggiuntive.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Estrarre e Ispezionare gli Elementi della Forma**

Utilizzare [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) per ispezionare una forma esistente come elementi contenenti punti del percorso e tipi di punto. Usare ogni [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) restituito per recuperare gli array di punti e tipi tramite i metodi [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) e [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes). Questa rappresentazione è utile per l’analisi del contorno o per passare la geometria a strumenti di disegno personalizzati.

L’esempio apre input.pptx, trova la prima forma geometrica direttamente nella prima diapositiva e stampa i suoi segmenti di percorso. Utilizzare una presentazione contenente una forma con segmenti lineari e curvi per vedere entrambi i tipi di output. Non ricerca all’interno dei gruppi.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = null;
    $shapes = $slide->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $candidate = $shapes->get_Item($shapeIndex);
        if (java_instanceof($candidate, java("com.aspose.slides.GeometryShape"))) {
            $shape = $candidate;
            break;
        }
    }

    if ($shape === null) {
        echo "No geometry shape found on the first slide." . PHP_EOL;
    } else {
        foreach ($shape->createShapeElements() as $element) {
            $points = java_values($element->getPathPoints());
            $types = array_values(unpack("C*", java_values($element->getPathTypes())));
            echo "Shape element:" . PHP_EOL;
            for ($i = 0; $i < count($points); $i++) {
                $pointType = $types[$i] & 0x07; // Mantieni il tipo di segmento, escludendo i flag.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Consuma entrambi i punti di controllo e il punto finale.
                        break;
                }
                if (($types[$i] & 0x80) !== 0) {
                    echo "Close subpath back to its starting point." . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Gli array corrispondono per indice: `$points[$i]` è un punto e `$types[$i]` descrive il suo ruolo. Il tipo `0` avvia una figura, e il tipo `1` traccia una linea dal punto precedente al punto corrente. Un segmento Bézier cubico inizia dal punto finale precedente e utilizza tre voci consecutive di tipo `3`: due punti di controllo seguiti dal nuovo punto finale. Il ciclo consuma queste tre voci insieme e verifica il punto finale per la chiusura.

I tipi di punto contengono anche flag. Mascherare con `0x07` per identificare il tipo di segmento, e testare `0x80` separatamente per rilevare un sotto‑percorso chiuso. Ad esempio, `129` (`0x81`) indica un punto finale di linea che chiude un sotto‑percorso, e `131` (`0x83`) indica un punto finale Bézier che chiude uno. Il bridge PHP/Java restituisce l’array di byte come stringa binaria; unpacking con "C*" produce valori di byte senza segno. La mascheratura preserva i valori di bit desiderati. Confrontare il valore grezzo solo con `1` o `3` farebbe perdere questi casi. Altri flag, come dash (`0x10`) e marker (`0x20`), non modificano il tipo base del segmento.

**Coordinate e trasformazioni.** I punti sono misurati in punti (1/72 di pollice), con X che aumenta verso destra e Y verso il basso. Per una forma non raggruppata, le coordinate estratte includono già la posizione restituita da [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) e [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) e riflettono la sua larghezza e altezza corrente. Ad esempio, un rettangolo non ruotato a `(100, 200)` con dimensioni `120 × 80` ha i limiti del contorno `(100, 200)`–`(220, 280)`. Non aggiungere nuovamente la posizione della forma. Sottrarre X e Y per ottenere coordinate relative al suo riquadro non ruotato.

I punti estratti non applicano la rotazione della forma, restituita da [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation), né i ribaltamenti orizzontale e verticale. Per riprodurre il contorno visualizzato, applicare tali trasformazioni intorno al centro della forma. Per forme raggruppate, considerare anche la mappatura delle coordinate del gruppo e le trasformazioni; non presumere che i punti estratti siano le coordinate finali sullo slide né applicare una traslazione o scala due volte se già riflessa nel riquadro del figlio.

**Ispezione vs. modifica.** Gli array estratti descrivono il contorno; modificarli non aggiorna la forma originale. Scegliere questo approccio quando la tua analisi o codice di disegno ha bisogno di array punto/tipo. Utilizzare [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) quando serve la sequenza di comandi geometrica nel sistema di coordinate locale della forma o quando si vuole modificare la sua geometria. Applicare i percorsi modificati tramite [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) o [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Convertire una Forma Java AWT in GeometryPath**

Questo esempio combina un contorno rettangolare con testo convertito in geometria. Il metodo [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) del contorno ne disabilita la riempitura. Un [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) crea il contorno del testo in un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Il suo [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) fornisce segmenti di spostamento, linea, quadratica, cubica e chiusura, che l’esempio riproduce su un [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

L’esempio utilizza un array di float Java affinché il bridge PHP/Java mantenga le coordinate scritte dall’iterator. Il testo usa un font Arial da 40 punti. Il contorno è spostato di 20 punti orizzontalmente e posizionato con il suo bordo superiore visivo 10 punti sotto il bordo superiore della forma. Il percorso del testo è riempito, mentre il rettangolo originale resta un contorno. Applicare entrambi i percorsi con [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) produce una singola forma contenente il rettangolo e il testo.

```php
use aspose\slides\GeometryPath;
use aspose\slides\PathFillModeType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);

    $fontClass = java("java.awt.Font");
    $imageClass = java("java.awt.image.BufferedImage");
    $font = new Java("java.awt.Font", "Arial", $fontClass->PLAIN, 40);
    $image = new Java("java.awt.image.BufferedImage", 100, 100, $imageClass->TYPE_INT_ARGB);
    $graphics = $image->createGraphics();
    try {
        $fontContext = $graphics->getFontRenderContext();
        $glyphVector = $font->createGlyphVector($fontContext, "Text in shape");
        $textBounds = $glyphVector->getVisualBounds();
        $baseline = -java_values($textBounds->getY()) + 10;
        $graphicsPath = $glyphVector->getOutline(20.0, $baseline);
    } finally {
        $graphics->dispose();
    }

    $textPath = new GeometryPath();
    $pathIterator = $graphicsPath->getPathIterator(null);
    $iteratorClass = java("java.awt.geom.PathIterator");
    $arrayClass = java("java.lang.reflect.Array");
    $floatClass = java("java.lang.Float");
    $coordinates = $arrayClass->newInstance($floatClass->TYPE, 6);

    while (!java_values($pathIterator->isDone())) {
        $segmentType = java_values($pathIterator->currentSegment($coordinates));
        $points = java_values($coordinates);
        switch ($segmentType) {
            case java_values($iteratorClass->SEG_MOVETO):
                $textPath->moveTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_LINETO):
                $textPath->lineTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_QUADTO):
                $textPath->quadraticBezierTo($points[0], $points[1], $points[2], $points[3]);
                break;
            case java_values($iteratorClass->SEG_CUBICTO):
                $textPath->cubicBezierTo($points[0], $points[1], $points[2], $points[3], $points[4], $points[5]);
                break;
            case java_values($iteratorClass->SEG_CLOSE):
                $textPath->closeFigure();
                break;
        }
        $pathIterator->next();
    }
    $textPath->setFillMode(PathFillModeType::Normal);
    $shape->setGeometryPaths([$originalPath, $textPath]);
} finally {
    $presentation->dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Cosa accade al riempimento e al contorno dopo aver sostituito la geometria?**

Lo stile rimane associato alla forma; solo il contorno cambia. Il riempimento e il contorno vengono applicati automaticamente alla nuova geometria.

**Come ruoto correttamente una forma personalizzata insieme alla sua geometria?**

Utilizzare il metodo della forma [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation); la geometria ruota con la forma perché è legata al sistema di coordinate della forma stessa.

**Posso convertire una forma personalizzata in un’immagine per “bloccare” il risultato?**

Sì. Esportare l’[slide](/slides/it/php-java/convert-powerpoint-to-png/) richiesto o la [shape](/slides/it/php-java/create-shape-thumbnails/) stessa in formato raster; questo semplifica il lavoro successivo con geometrie complesse.