---
title: Personalizza le forme delle presentazioni su Android
linktitle: Forma personalizzata
type: docs
weight: 20
url: /it/androidjava/custom-shape/
keywords:
- forma personalizzata
- aggiungi forma
- crea forma
- cambia forma
- geometria della forma
- percorso geometrico
- punti del percorso
- modifica punti
- aggiungi punto
- rimuovi punto
- operazione di modifica
- angolo curvo
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Crea e personalizza forme nelle presentazioni PowerPoint con Aspose.Slides per Android tramite Java: percorsi geometrici, angoli curvi, forme composite."
---
## **Panoramica**

Questo articolo spiega come personalizzare le forme delle presentazioni in Aspose.Slides modificando la geometria delle forme tramite punti di modifica e percorsi geometrici. Mostra come lavorare con [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) e [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) per modificare le forme esistenti, eseguire operazioni di modifica di percorso di base, aggiungere o rimuovere punti e applicare la geometria aggiornata a una forma.

Dimostra inoltre come creare forme personalizzate e composite, costruire forme con angoli curvi, determinare se una geometria di forma è chiusa e ispezionare gli elementi della forma utilizzando array di punti Android.

## **Modifica una forma utilizzando i punti di modifica**

* Sposta un angolo verso l'interno o verso l'esterno.
* Regola la curvatura in un punto.
* Aggiungi nuovi punti.

Modificare i punti ti consente di modificare il contorno di una forma o di utilizzare una forma esistente come base per una nuova.

## **Suggerimenti per la modifica delle forme**

![overview_image](custom_shape_0.png)

Quando modifichi le forme di PowerPoint, tieni presente questi concetti:

* Una forma (o il suo percorso) può essere chiusa o aperta.
* Il percorso di una forma è costituito da punti di ancoraggio collegati da segmenti.
* Un segmento può essere dritto o curvo. I punti di ancoraggio e le maniglie di controllo determinano la sua forma.
* I punti di ancoraggio esistono come punti d'angolo, punti dritti o punti lisci:
  * In un punto d'angolo, i segmenti adiacenti possono incontrarsi ad un angolo.
  * In un punto liscio, le due maniglie di controllo sono allineate e a uguale distanza dal punto di ancoraggio.
  * In un punto dritto, le due maniglie di controllo sono allineate ma possono trovarsi a distanze diverse dal punto di ancoraggio.
* Spostare i punti di ancoraggio o regolare le loro maniglie cambia il contorno della forma.

Per modificare le forme di PowerPoint tramite i punti di modifica, **Aspose.Slides** fornisce la classe [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) e l'interfaccia [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).

* Un'istanza di [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) rappresenta un percorso geometrico dell'oggetto [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/).
* Per recuperare il [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) dall'istanza [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/), è possibile utilizzare il metodo [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) .
* Per impostare il [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) per una forma, è possibile utilizzare questi metodi: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) per forme con un singolo percorso e [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) per forme con percorsi multipli.
* Per aggiungere segmenti, è possibile utilizzare i metodi sotto [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).
* Utilizzando i metodi [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) e [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-), è possibile impostare l'aspetto di un percorso geometrico.
* Utilizzando il metodo [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) , è possibile recuperare il percorso geometrico di un [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) come un array di segmenti di percorso.

## **Operazioni di modifica semplici**

Usa i seguenti metodi per modificare un percorso geometrico. Le overload che accettano un indice inseriscono un segmento in quella posizione basata su zero nell'array di segmenti del percorso.

| Operazione | Metodo |
| --- | --- |
| Aggiungi o inserisci una linea retta. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Aggiungi o inserisci una curva Bézier cubica con due punti di controllo e un punto finale. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Aggiungi o inserisci una curva Bézier quadratica con un punto di controllo e un punto finale. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Aggiungi un arco ellittico con le dimensioni e gli angoli specificati in gradi. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Chiudi la figura corrente collegando il suo punto finale al punto iniziale. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Imposta il punto di inizio di una figura. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Rimuovi un segmento a un indice basato su zero. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Aggiungi punti personalizzati a una forma**

Questo esempio inserisce due punti in una forma rettangolare usando [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) e applica il percorso modificato con [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Le coordinate sono locali alla forma: entrambi i nuovi punti si trovano al suo centro, 100 punti dal lato sinistro e 50 punti dall'alto. Gli indici dei segmenti 1 e 4 li posizionano sui bordi superiore e inferiore, tirando quei bordi verso l'interno.

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

## **Rimuovi punti da una forma**

Questo esempio modifica un contorno a forma di cuore rimuovendo il segmento all'indice basato su zero 2 con [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-). Applicare il percorso modificato con [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) aggiorna il contorno della forma.

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

## **Crea una forma personalizzata**

Questo esempio costruisce una stella a cinque punte con [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/). Raggi esterni e interni alternati di 100 e 50 punti definiscono le punte e le indentazioni; un passo di 72 gradi distribuisce uniformemente le cinque punte. Il percorso è chiuso con [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) e applicato a una forma rettangolare usando [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), sostituendo il suo contorno.

```java
import com.aspose.slides.*;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.List;

List<PointF> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    PointF point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new PointF((float)x + outerRadius, (float)y + outerRadius);
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

## **Crea una forma personalizzata composita**

Questo esempio definisce due oggetti [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) chiusi per il terzo superiore e inferiore di una forma. Applicare entrambi i percorsi con [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) crea una singola forma composita con uno spazio attraverso il suo terzo centrale.

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

## **Crea una forma personalizzata con angoli curvi**

Questo esempio combina segmenti dritti con [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) per creare una forma con angoli curvi verso l'interno. La dimensione di ciascun angolo imposta la larghezza e l'altezza dell'arco in punti, e la rotazione di -90 gradi disegna un quarto d'elisse in senso antiorario. Il percorso completato è applicato con [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), e la presentazione viene salvata in formato PPTX.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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

    PointF topLeft = new PointF(leftTopSize, 0);
    PointF topRight = new PointF(shapeWidth - rightTopSize, 0);
    PointF rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    PointF bottomLeft = new PointF(leftBottomSize, shapeHeight);
    PointF leftTop = new PointF(0, leftTopSize);

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

## **Scopri se la geometria di una forma è chiusa**

Il seguente helper verifica se ogni percorso geometrico non vuoto termina con un segmento di chiusura. Legge [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) e confronta il comando [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) del segmento finale con [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/). Restituisce false quando non ci sono percorsi non vuoti. Questo controlla il comando finale di ogni percorso; non ispeziona ogni sottogruppo all'interno di un percorso. L'esempio stampa `true` per un rettangolo.

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

## **Estrai e ispeziona gli elementi della forma**

Usa [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) per ispezionare una forma esistente come elementi contenenti punti di percorso e tipi di punto. Converte ogni [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) restituito in [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) per recuperare gli array di punti e tipi tramite i metodi [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) e [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) . Questa rappresentazione è utile per l'analisi del contorno o per passare la geometria a strumenti di disegno personalizzati.

L'esempio apre input.pptx, trova la prima forma geometrica direttamente nella prima diapositiva e stampa i suoi segmenti di percorso. Usa una presentazione contenente una forma con segmenti dritti e curvi per vedere entrambi i tipi di output. Non ricerca all'interno dei gruppi.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
            PointF[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Mantieni il tipo di segmento, escludendo i flag.
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

Gli array corrispondono per indice: `points[i]` è un punto e `types[i]` descrive il suo ruolo. Il tipo `0` avvia una figura, e il tipo `1` disegna una linea dal punto precedente al punto corrente. Un segmento Bézier cubico inizia dal punto finale precedente e utilizza tre voci consecutive di tipo `3`: due punti di controllo seguiti dal nuovo punto finale. Il ciclo consuma queste tre voci insieme e controlla il punto finale per la chiusura.

I tipi di punto contengono anche flag. Mascherare con `0x07` identifica il tipo di segmento, e testare `0x80` separatamente rileva un sotto‑percorso chiuso. Per esempio, `129` (`0x81`) indica un punto finale di linea che chiude un sotto‑percorso, e `131` (`0x83`) indica un punto finale Bézier che ne chiude uno. Java memorizza questi flag in byte con segno; la mascheratura preserva i valori bit desiderati. Confrontare il valore grezzo solo con `1` o `3` perderebbe questi casi. Altri flag, come dash (`0x10`) e marker (`0x20`), non modificano il tipo di segmento di base.

**Coordinate e trasformazioni.**  
I punti sono misurati in punti (1/72 di pollice), con X che aumenta verso destra e Y che aumenta verso il basso. Per una forma non raggruppata, le coordinate estratte includono già la posizione restituita da [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) e [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) e riflettono la larghezza e l'altezza correnti. Per esempio, un rettangolo non ruotato a `(100, 200)` con dimensioni `120 × 80` ha limiti di contorno `(100, 200)`–`(220, 280)`. Non aggiungere nuovamente la posizione della forma. Sottrai il suo X e Y per ottenere coordinate relative al suo riquadro non ruotato.

I punti estratti non applicano la rotazione della forma, restituita da [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--), né i ribaltamenti orizzontali e verticali. Per ricreare il contorno visualizzato, applica quelle trasformazioni attorno al centro della forma. Per forme raggruppate, considera anche la mappatura e le trasformazioni delle coordinate del gruppo; non presumere che i punti estratti siano le coordinate finali renderizzate della diapositiva o applicare una traslazione o scala due volte se è già riflessa nel riquadro del figlio.

**Ispezione vs modifica.**  
Gli array estratti descrivono il contorno; modificarli non aggiorna la forma originale. Scegli questo approccio quando la tua analisi o il tuo codice di disegno ha bisogno di array punto/tipo. Usa [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) quando hai bisogno di comandi geometrici nel sistema di coordinate locale della forma o desideri modificare la sua geometria. Applica i percorsi modificati tramite [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) o [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **FAQ**

**Cosa succederà al riempimento e al contorno dopo aver sostituito la geometria?**  
Lo stile rimane associato alla forma; solo il contorno cambia. Il riempimento e il contorno vengono applicati automaticamente alla nuova geometria.

**Come ruoto correttamente una forma personalizzata insieme alla sua geometria?**  
Usa il metodo [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) della forma; la geometria ruota con la forma perché è legata al sistema di coordinate della forma.

**Posso convertire una forma personalizzata in un'immagine per "bloccare" il risultato?**  
Sì. Esporta l'area della [diapositiva](/slides/it/androidjava/convert-powerpoint-to-png/) richiesta o la [forma](/slides/it/androidjava/create-shape-thumbnails/) stessa in un formato raster; ciò semplifica ulteriori lavori con geometrie complesse.