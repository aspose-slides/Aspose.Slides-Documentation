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
- Java
- Aspose.Slides
description: "Crea e personalizza forme nelle presentazioni PowerPoint con Aspose.Slides per Java: percorsi geometrici, angoli curvi, forme composite."
---
## **Panoramica**

Questo articolo spiega come personalizzare le forme di presentazione in Aspose.Slides modificando la geometria della forma tramite punti di modifica e percorsi geometrici. Mostra come lavorare con [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) e [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) per modificare forme esistenti, eseguire operazioni di base di modifica del percorso, aggiungere o rimuovere punti e applicare la geometria aggiornata a una forma.

Dimostra inoltre come creare forme personalizzate e composite, costruire forme con angoli curvi, determinare se una geometria di forma è chiusa, ispezionare gli elementi della forma e convertire i contorni di testo Java AWT in percorsi geometrici.

## **Modifica di una Forma tramite Punti di Modifica**

In PowerPoint è possibile utilizzare **Punti di Modifica** per modificare un quadrato:

* Spostare un angolo verso l’interno o verso l’esterno.
* Regolare la curvatura in un punto.
* Aggiungere nuovi punti.

La modifica dei punti consente di alterare il contorno di una forma o di utilizzare una forma esistente come base per una nuova forma.

## **Suggerimenti per la Modifica delle Forme**

![overview_image](custom_shape_0.png)

Quando si modificano le forme di PowerPoint, tenere presenti questi concetti:

* Una forma (o il suo percorso) può essere chiusa o aperta.
* Il percorso di una forma è costituito da punti di ancoraggio collegati da segmenti.
* Un segmento può essere lineare o curvo. I punti di ancoraggio e le maniglie di controllo determinano la sua forma.
* I punti di ancoraggio esistono come punti d’angolo, punti lineari o punti lisci:
  * In un punto d’angolo, i segmenti adiacenti possono incontrarsi formando un angolo.
  * In un punto liscio, le due maniglie di controllo sono allineate e alla stessa distanza dal punto di ancoraggio.
  * In un punto lineare, le due maniglie di controllo sono allineate ma possono avere distanze diverse dal punto di ancoraggio.
* Spostare i punti di ancoraggio o regolare le loro maniglie cambia il contorno della forma.

Per modificare le forme di PowerPoint tramite punti di modifica, **Aspose.Slides** fornisce la classe [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) e l’interfaccia [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).

* Un’istanza di [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) rappresenta il percorso geometrico dell’oggetto [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/).
* Per ottenere il [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) da un’istanza di [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/), è possibile usare il metodo [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) .
* Per impostare il [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) di una forma, è possibile usare questi metodi: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) per forme con un unico percorso e [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) per forme con percorsi multipli.
* Per aggiungere segmenti, è possibile usare i metodi sotto [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) .
* Utilizzando i metodi [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) e [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-), è possibile impostare l’aspetto di un percorso geometrico.
* Con il metodo [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) è possibile recuperare il percorso geometrico di un [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) come array di segmenti di percorso.
* Per accedere a ulteriori opzioni di personalizzazione della geometria della forma, è possibile leggere un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) tramite il suo [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) e riprodurre i segmenti su un [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) .

## **Operazioni di Modifica Semplici**

Utilizzare i seguenti metodi per modificare un percorso geometrico. Le sovraccarichi che accettano un indice inseriscono un segmento in quella posizione a indice zero nell’array dei segmenti del percorso.

| Operazione | Metodo |
| --- | --- |
| Aggiungere o inserire una linea retta. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Aggiungere o inserire una curva Bézier cubica con due punti di controllo e un punto finale. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Aggiungere o inserire una curva Bézier quadratica con un punto di controllo e un punto finale. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Aggiungere un arco ellittico con le dimensioni e gli angoli specificati in gradi. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Chiudere la figura corrente collegando il suo punto finale al punto iniziale. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| Impostare il punto di partenza di una figura. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Rimuovere un segmento a indice zero. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Aggiungere Punti Personalizzati a una Forma**

Questo esempio inserisce due punti in una forma rettangolare usando [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) e applica il percorso modificato con [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Le coordinate sono locali alla forma: entrambi i nuovi punti si trovano al centro, a 100 punti dal bordo sinistro e a 50 punti dal bordo superiore. Gli indici dei segmenti 1 e 4 li collocano rispettivamente sui bordi superiore e inferiore, tirando quei bordi verso l’interno.

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

## **Rimuovere Punti da una Forma**

Questo esempio modifica il contorno di una forma a forma di cuore rimuovendo il segmento all’indice zero 2 con [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-). L’applicazione del percorso modificato con [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) aggiorna il profilo della forma.

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

## **Creare una Forma Personalizzata**

Questo esempio costruisce una stella a cinque punte con [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/). Raggi esterni e interni alternati di 100 e 50 punti definiscono le punte e le rientranze; un passo di 72 gradi distribuisce uniformemente le cinque punte. Il percorso è chiuso con [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) e applicato a una forma rettangolare tramite [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), sostituendo il suo contorno.

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

## **Creare una Forma Personalizzata Composita**

Questo esempio definisce due oggetti [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) chiusi per il terzo superiore e inferiore di una forma. L’applicazione di entrambi i percorsi con [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) crea una singola forma composita con uno spazio al centro del terzo medio.

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

## **Creare una Forma Personalizzata con Angoli Curvi**

Questo esempio combina segmenti lineari con [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) per creare una forma con angoli curvi verso l’interno. Ogni dimensione dell’angolo imposta la larghezza e l’altezza dell’arco in punti, e la rotazione di -90 gradi disegna un quarto di ellisse in senso antiorario. Il percorso completato è applicato con [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), e la presentazione viene salvata in formato PPTX.

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

## **Verificare se una Geometria di Forma è Chiusa**

Il seguente helper verifica se ogni percorso geometrico non vuoto termina con un segmento di chiusura. Legge [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) e confronta il comando del segmento finale [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) con [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/). Restituisce false quando non ci sono percorsi non vuoti. Questo controlla il comando finale di ogni percorso; non ispeziona ogni sottofigura all’interno di un percorso. L’esempio stampa `true` per un rettangolo.

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

## **Estrarre e Ispezionare gli Elementi di una Forma**

Usare [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) per ispezionare una forma esistente come elementi contenenti punti di percorso e tipi di punto. Convertire ogni [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) restituito in [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) per ottenere gli array di punti e tipi tramite i metodi [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) e [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) . Questa rappresentazione è utile per analisi del contorno o per passare la geometria a strumenti di disegno personalizzati.

L’esempio apre `input.pptx`, trova la prima forma geometrica nella prima diapositiva e stampa i segmenti del suo percorso. Usare una presentazione contenente una forma con segmenti lineari e curvi per vedere entrambi i tipi di output. Non ricerca all’interno dei gruppi.

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
                int pointType = types[i] & 0x07; // Keep the segment type, excluding flags.
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

Gli array corrispondono per indice: `points[i]` è un punto e `types[i]` descrive il suo ruolo. Il tipo `0` avvia una figura, e il tipo `1` traccia una linea dal punto precedente al punto corrente. Un segmento Bézier cubico inizia dal punto finale precedente e utilizza tre voci consecutive di tipo `3`: due punti di controllo seguiti dal nuovo punto finale. Il ciclo consuma queste tre voci insieme e verifica il punto finale per la chiusura.

I tipi di punto contengono anche flag. Mascherare con `0x07` per identificare il tipo di segmento, e testare `0x80` separatamente per rilevare un sotto‑percorso chiuso. Per esempio, `129` (`0x81`) indica un punto finale di linea che chiude un sotto‑percorso, e `131` (`0x83`) indica un punto finale Bézier che chiude un sotto‑percorso. Java memorizza questi flag in byte con segno; la mascheratura conserva i valori bit desiderati. Confrontare il valore grezzo solo con `1` o `3` farebbe perdere questi casi. Altri flag, come il tratto (`0x10`) e il marcatore (`0x20`), non modificano il tipo di segmento di base.

**Coordinate e trasformazioni.** I punti sono misurati in punti (1/72 di pollice), con X che aumenta verso destra e Y che aumenta verso il basso. Per una forma non raggruppata, le coordinate estratte includono già la posizione restituita da [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) e [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) e riflettono la sua larghezza e altezza attuali. Per esempio, un rettangolo non ruotato a `(100, 200)` con dimensioni `120 × 80` ha i limiti del contorno `(100, 200)`–`(220, 280)`. Non aggiungere nuovamente la posizione della forma. Sottrarre X e Y per ottenere coordinate relative al suo riquadro non ruotato.

I punti estratti non applicano la rotazione della forma, restituita da [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--), né i ribaltamenti orizzontali e verticali. Per riprodurre il contorno visualizzato, applicare tali trasformazioni intorno al centro della forma. Per forme raggruppate, considerare anche la mappatura delle coordinate del gruppo e le trasformazioni; non presumere che i punti estratti siano le coordinate finali visualizzate nella diapositiva né applicare una traduzione o scala due volte se già incluse nel riquadro del figlio.

**Ispezione vs. modifica.** Gli array estratti descrivono il contorno; modificarli non aggiorna la forma originale. Usare questo approccio quando l’analisi o il codice di disegno ha bisogno di array di punti/tipi. Utilizzare [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) quando servono i comandi geometrici nel sistema di coordinate locale della forma o si desidera modificare la sua geometria. Applicare i percorsi modificati tramite [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) o [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) .

## **Convertire una Forma Java AWT in GeometryPath**

Questo esempio combina un contorno rettangolare con testo convertito in geometria. Il metodo [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) del contorno ne disattiva il riempimento. Un [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) genera il contorno del testo in un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Il suo [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) fornisce segmenti di spostamento, linea, quadratica, cubica e chiusura, che l’esempio riproduce su un [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) .

Il testo utilizza un font Arial da 40 punti. Il contorno è traslato di 20 punti orizzontalmente e posizionato in modo che la sua parte superiore visiva sia 10 punti sotto il bordo superiore della forma. Il percorso del testo è riempito, mentre il rettangolo originale rimane un contorno. Applicare entrambi i percorsi con [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) produce una singola forma contenente il rettangolo e il testo.

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
    // Crea nuova forma
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Ottieni il percorso geometrico della forma
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Crea nuovo percorso grafico con testo
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

**Cosa accade al riempimento e al contorno dopo aver sostituito la geometria?**

Lo stile rimane associato alla forma; solo il contorno cambia. Il riempimento e il contorno sono applicati automaticamente alla nuova geometria.

**Come ruoto correttamente una forma personalizzata insieme alla sua geometria?**

Usare il metodo [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) della forma; la geometria ruota con la forma perché è legata al sistema di coordinate della forma stessa.

**Posso convertire una forma personalizzata in un’immagine per “bloccare” il risultato?**

Sì. Esportare l’[slide](/slides/it/java/convert-powerpoint-to-png/) o la [shape](/slides/it/java/create-shape-thumbnails/) stessa nel formato raster; questo semplifica ulteriori lavori con geometrie complesse.