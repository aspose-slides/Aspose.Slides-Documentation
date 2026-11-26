---
title: Personalizza le forme di presentazione in Java
linktitle: Forma personalizzata
type: docs
weight: 20
url: /it/java/custom-shape/
keywords:
- forma personalizzata
- aggiungi forma
- crea forma
- cambia forma
- geometria forma
- percorso geometrico
- punti percorso
- punti di modifica
- aggiungi punto
- rimuovi punto
- operazione di modifica
- angolo curvo
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Crea e personalizza le forme nelle presentazioni PowerPoint con Aspose.Slides per Java: percorsi geometrici, angoli curvi, forme composite."
---
## **Panoramica**

Questo articolo spiega come personalizzare le forme di presentazione in Aspose.Slides modificando la geometria della forma tramite punti di modifica e percorsi geometrico. Mostra come lavorare con [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) e [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) per modificare forme esistenti, eseguire operazioni di modifica di base del percorso, aggiungere o rimuovere punti e applicare la geometria aggiornata a una forma. Mostra inoltre come creare forme personalizzate e composite, costruire forme con angoli curvi, determinare se la geometria di una forma è chiusa, ispezionare gli elementi della forma e convertire i contorni di testo Java AWT in percorsi geometrico.

## **Modifica una Forma Utilizzando i Punti di Modifica**

In PowerPoint, è possibile utilizzare **Edit Points** per modificare un quadrato:

* Spostare un angolo verso l'interno o verso l'esterno.
* Regolare la curvatura in un punto.
* Aggiungere nuovi punti.

La modifica dei punti consente di modificare il contorno di una forma o di utilizzare una forma esistente come base per una nuova.

## **Suggerimenti per la Modifica delle Forme**

![overview_image](custom_shape_0.png)

Durante la modifica delle forme di PowerPoint, tenere a mente questi concetti:

* Una forma (oppure il suo percorso) può essere chiusa o aperta.
* Il percorso di una forma è composto da punti di ancoraggio collegati da segmenti.
* Un segmento può essere rettilineo o curvo. I punti di ancoraggio e le maniglie di controllo determinano la sua forma.
* I punti di ancoraggio esistono come punti d'angolo, punti rettilinei o punti lisci:
  * In un punto d'angolo, i segmenti adiacenti possono incontrarsi con un angolo.
  * In un punto liscio, le due maniglie di controllo sono allineate e a pari distanza dal punto di ancoraggio.
  * In un punto rettilineo, le due maniglie di controllo sono allineate ma possono trovarsi a distanze diverse dal punto di ancoraggio.
* Spostare i punti di ancoraggio o regolare le loro maniglie modifica il contorno della forma.

Per modificare le forme di PowerPoint tramite punti di modifica, **Aspose.Slides** fornisce la classe [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) e l'interfaccia [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).

* Un'istanza di [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) rappresenta un percorso geometrico dell'oggetto [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/).
* Per recuperare il [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) dall'istanza [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/), è possibile utilizzare il metodo [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--).
* Per impostare il [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) per una forma, è possibile utilizzare questi metodi: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) per forme con un singolo percorso e [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) per forme con più percorsi.
* Per aggiungere segmenti, è possibile utilizzare i metodi sotto [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).
* Utilizzando i metodi [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) e [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-), è possibile impostare l'aspetto di un percorso geometrico.
* Utilizzando il metodo [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--), è possibile recuperare il percorso geometrico di un [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) come un array di segmenti del percorso.
* Per accedere a ulteriori opzioni di personalizzazione della geometria della forma, è possibile leggere un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) tramite il suo [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) e riprodurre i segmenti su un [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/).

## **Operazioni di Modifica Semplici**

Utilizzare i seguenti metodi per modificare un percorso geometrico. Le overload che accettano un indice inseriscono un segmento in quella posizione basata su zero nell'array dei segmenti del percorso.

| Operazione | Metodo |
| --- | --- |
| Aggiungere o inserire una linea retta. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Aggiungere o inserire una curva Bézier cubica con due punti di controllo e un punto finale. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Aggiungere o inserire una curva Bézier quadratica con un punto di controllo e un punto finale. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Aggiungere un arco ellittico con le dimensioni e gli angoli specificati in gradi. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Chiudere la figura corrente collegando il suo punto finale al punto di partenza. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| Impostare il punto di partenza di una figura. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Rimuovere un segmento a un indice basato su zero. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Aggiungi Punti Personalizzati a una Forma**

Questo esempio inserisce due punti in una forma rettangolare utilizzando [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) e applica il percorso modificato con [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Le coordinate sono locali alla forma: entrambi i nuovi punti si trovano al suo centro, a 100 punti dal lato sinistro e a 50 punti dall'alto. Gli indici dei segmenti 1 e 4 li posizionano sui bordi superiore e inferiore, tirando quei bordi verso l'interno.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Rimuovi Punti da una Forma**

Questo esempio modifica il contorno a forma di cuore rimuovendo il segmento all'indice basato su zero 2 con [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-). Applicando il percorso modificato con [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) si aggiorna il contorno della forma.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Crea una Forma Personalizzata**

Questo esempio crea una stella a cinque punte con [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/). I raggi esterno e interno alternati di 100 e 50 punti definiscono le punte e le rientranze; un passo di 72 gradi distribuisce uniformemente le cinque punte. Il percorso è chiuso con [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) e applicato a una forma rettangolare usando [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), sostituendo il suo contorno.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.List;

List<Point2D.Float> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    Point2D.Float point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Crea una Forma Personalizzata Composita**

Questo esempio definisce due oggetti [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) chiusi per il terzo superiore e inferiore di una forma. Applicando entrambi i percorsi con [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) si crea una singola forma composita con uno spazio nella sua terza parte centrale.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Crea una Forma Personalizzata con Angoli Curvi**

Questo esempio combina segmenti rettilinei con [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) per creare una forma con angoli curvi verso l'interno. Ogni dimensione dell'angolo imposta la larghezza e l'altezza dell'arco in punti, e l'arco di -90 gradi disegna un quarto di ellisse in senso antiorario. Il percorso completato è applicato con [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), e la presentazione viene salvata nel formato PPTX.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    Point2D.Float topLeft = new Point2D.Float(leftTopSize, 0);
    Point2D.Float topRight = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float rightBottom = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float bottomLeft = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float leftTop = new Point2D.Float(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Scopri se la Geometria di una Forma è Chiusa**

Il seguente helper verifica se ogni percorso geometrico non vuoto termina con un segmento di chiusura. Legge [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) e confronta il comando dell'ultimo segmento [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) con [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/). Restituisce false quando non ci sono percorsi non vuoti. Questa verifica il comando finale di ciascun percorso; non ispeziona ogni sottofigura all'interno di un percorso. L'esempio stampa `true` per un rettangolo.

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **Ispeziona i Comandi del Percorso Geometrico**

Scaricare [contour.pptx](contour.pptx) e posizionarlo nella directory di lavoro dell'applicazione. La prima forma nella prima diapositiva ha un bordo superiore rettilineo, una curva Bézier cubica e un bordo di chiusura rettilineo. Utilizzare [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) per leggere i percorsi della forma e [getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) per leggere i segmenti di ogni percorso nell'ordine di disegno. Per ogni segmento, [getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) identifica il comando e determina come interpretare i valori restituiti da [getSegmentData](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getSegmentData--).

```java
import com.aspose.slides.*;
import java.util.Arrays;

Presentation presentation = new Presentation("contour.pptx");
try {
    IGeometryShape shape = (IGeometryShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IGeometryPath[] paths = shape.getGeometryPaths();

    for (int i = 0; i < paths.length; i++) {
        IPathSegment[] segments = paths[i].getPathData();
        for (int j = 0; j < segments.length; j++) {
            byte command = segments[j].getPathCommand();
            float[] data = segments[j].getSegmentData();
            String detail;
            switch (command) {
                case PathCommandType.MoveTo:
                case PathCommandType.LineTo:
                    detail = String.format("destination=(%s, %s)", data[0], data[1]);
                    break;
                case PathCommandType.CubicBezierTo:
                    detail = String.format("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", data[0], data[1], data[2], data[3], data[4], data[5]);
                    break;
                case PathCommandType.Close:
                    detail = "no coordinates";
                    break;
                default:
                    detail = "raw=" + Arrays.toString(data);
            }
            String name = PathCommandType.getName(PathCommandType.class, command);
            System.out.printf("Path %d, segment %d: %s %s%n", i, j, name, detail);
        }
    }
} finally {
    presentation.dispose();
}
```

La forma si trova a (200, 100) punti sulla diapositiva. Le coordinate riportate sono locali alla forma, con (0, 0) nell'angolo in alto a sinistra, x crescente verso destra e y crescente verso il basso. Il segmento di chiusura ritorna al punto iniziale senza coordinate aggiuntive.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```
![Forma PowerPoint con un bordo superiore rettilineo, un bordo curvo dall'angolo superiore destro all'angolo inferiore sinistro e un bordo sinistro rettilineo](contour.png)

## **Estrai e Ispeziona gli Elementi della Forma**

Utilizzare [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) per ispezionare una forma esistente come elementi contenenti punti del percorso e tipi di punto. Convertire ciascun [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) restituito in [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) per recuperare gli array di punti e tipi tramite i metodi [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) e [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--). Questa rappresentazione è utile per l'analisi del contorno o per passare la geometria a strumenti di disegno personalizzati.

L'esempio apre input.pptx, trova la prima forma geometrica direttamente nella prima diapositiva e stampa i suoi segmenti del percorso. Utilizzare una presentazione contenente una forma con segmenti rettilinei e curvi per vedere entrambi i tipi di output. Non ricerca all'interno dei gruppi.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            Point2D.Float[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Conserva il tipo di segmento, escludendo i flag.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Gli array corrispondono per indice: `points[i]` è un punto e `types[i]` ne descrive il ruolo. Il tipo `0` avvia una figura, e il tipo `1` traccia una linea dal punto precedente al punto corrente. Un segmento Bézier cubico inizia dal punto finale precedente e utilizza tre voci consecutive di tipo `3`: due punti di controllo seguiti dal nuovo punto finale. Il ciclo consuma queste tre voci insieme e verifica la chiusura del punto finale.

I tipi di punto contengono anche flag. Mascherare con `0x07` per identificare il tipo di segmento e testare `0x80` separatamente per rilevare un sotto-percorso chiuso. Per esempio, `129` (`0x81`) indica un punto finale di linea che chiude un sotto-percorso, e `131` (`0x83`) indica un punto finale Bézier che ne chiude uno. Java memorizza questi flag in byte con segno; la mascheratura preserva i valori bit desiderati. Confrontare il valore grezzo solo con `1` o `3` farebbe perdere questi casi. Altri flag, come dash (`0x10`) e marker (`0x20`), non modificano il tipo base del segmento.

**Coordinate e trasformazioni.** I punti sono misurati in punti (1/72 di pollice), con X crescente verso destra e Y crescente verso il basso. Per una forma non raggruppata, le coordinate estratte includono già la posizione restituita da [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) e [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) e riflettono la sua larghezza e altezza attuali. Per esempio, un rettangolo non ruotato a `(100, 200)` con dimensioni `120 × 80` ha i limiti del contorno `(100, 200)`–`(220, 280)`. Non aggiungere nuovamente la posizione della forma. Sottrarre il suo X e Y per ottenere coordinate relative al suo frame non ruotato.

I punti estratti non includono la rotazione della forma, restituita da [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--), né i ribaltamenti orizzontali e verticali. Per ricreare il contorno visualizzato, applicare tali trasformazioni attorno al centro della forma. Per forme raggruppate, considerare anche la mappatura delle coordinate del gruppo e le trasformazioni; non presumere che i punti estratti siano le coordinate finali renderizzate della diapositiva o applicare una traslazione o scala due volte se già riflessa nel frame del figlio.

**Ispezione vs modifica.** Gli array estratti descrivono il contorno; modificarli non aggiorna la forma originale. Scegliere questo approccio quando la propria analisi o il codice di disegno necessita di array di punti/tipi. Utilizzare [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) quando servono comandi di geometria nel sistema di coordinate locale della forma o si desidera modificare la sua geometria. Applicare i percorsi modificati tramite [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) o [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **Converti una Forma Java AWT in GeometryPath**

Questo esempio combina un contorno rettangolare con testo convertito in geometria. Il metodo [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) del contorno disabilita il riempimento. Un [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) crea il contorno del testo in un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Il suo [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) fornisce segmenti di spostamento, linea, quadratica, cubica e di chiusura, che l'esempio riproduce su un [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/). Il testo utilizza un carattere Arial da 40 punti. Il contorno è spostato di 20 punti orizzontalmente e posizionato con la sua parte superiore visuale 10 punti sotto il bordo superiore della forma. Il percorso del testo è riempito, mentre il rettangolo originale rimane un contorno. Applicando entrambi i percorsi con [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) si produce una singola forma contenente il rettangolo e il testo.

```java
import com.aspose.slides.*;
import java.awt.Font;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.font.GlyphVector;
import java.awt.font.FontRenderContext;
import java.awt.geom.Rectangle2D;
import java.awt.geom.PathIterator;
import java.awt.image.BufferedImage;

Presentation presentation = new Presentation();
try {
    // Crea una nuova forma
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Ottieni il percorso geometrico della forma
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Crea un nuovo percorso grafico con testo
    Shape graphicsPath;
    Font font = new Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage image = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D graphics = image.createGraphics();

    try
    {
        FontRenderContext fontContext = graphics.getFontRenderContext();
        GlyphVector glyphVector = font.createGlyphVector(fontContext, text);
        Rectangle2D textBounds = glyphVector.getVisualBounds();
        float baseline = (float) -textBounds.getY() + 10;
        graphicsPath = glyphVector.getOutline(20f, baseline);
    }
    finally {
        graphics.dispose();
    }

    // Converti il percorso grafico in percorso geometrico
    IGeometryPath textPath = new GeometryPath();
    PathIterator pathIterator = graphicsPath.getPathIterator(null);
    float[] points = new float[6];

    while (!pathIterator.isDone())
    {
        int segmentType = pathIterator.currentSegment(points);
        switch (segmentType)
        {
            case PathIterator.SEG_MOVETO:
                textPath.moveTo(points[0], points[1]);
                break;
            case PathIterator.SEG_LINETO:
                textPath.lineTo(points[0], points[1]);
                break;
            case PathIterator.SEG_QUADTO:
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case PathIterator.SEG_CUBICTO:
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case PathIterator.SEG_CLOSE:
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }

    textPath.setFillMode(PathFillModeType.Normal);

    // Imposta la combinazione del nuovo percorso geometrico e del percorso geometrico originale alla forma
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Cosa succederà al riempimento e al contorno dopo aver sostituito la geometria?**

Lo stile rimane associato alla forma; solo il contorno cambia. Il riempimento e il contorno sono applicati automaticamente alla nuova geometria.

**Come ruoto correttamente una forma personalizzata insieme alla sua geometria?**

Utilizzare il metodo [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) della forma; la geometria ruota con la forma perché è legata al proprio sistema di coordinate.

**Posso convertire una forma personalizzata in un'immagine per "bloccare" il risultato?**

Sì. Esportare l'area della [diapositiva](/slides/it/java/convert-powerpoint-to-png/) necessaria o la [forma](/slides/it/java/create-shape-thumbnails/) stessa in un formato raster; ciò semplifica il lavoro successivo con geometrie complesse.