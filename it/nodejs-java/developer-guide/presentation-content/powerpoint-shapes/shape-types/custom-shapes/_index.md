---
title: Personalizza le forme di presentazione in JavaScript
linktitle: Forma personalizzata
type: docs
weight: 20
url: /it/nodejs-java/custom-shape/
keywords:
- forma personalizzata
- aggiungi forma
- crea forma
- cambia forma
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea e personalizza le forme nelle presentazioni PowerPoint con JavaScript e Aspose.Slides per Node.js: percorsi geometrici, angoli curvi, forme composite."
---
## **Panoramica**

Questo articolo spiega come personalizzare le forme di presentazione in Aspose.Slides modificando la geometria della forma tramite punti di modifica e percorsi geometrici. Mostra come lavorare con [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) per modificare forme esistenti, eseguire operazioni di modifica di percorso di base, aggiungere o rimuovere punti e applicare la geometria aggiornata a una forma.

Dimostra anche come creare forme personalizzate e composite, costruire forme con angoli curvi, determinare se una geometria di forma è chiusa, ispezionare gli elementi della forma e convertire i contorni di testo Java AWT in percorsi geometrici.

## **Modifica una Forma Usando Punti di Modifica**

* Sposta un angolo verso l'interno o l'esterno.
* Regola la curvatura in un punto.
* Aggiungi nuovi punti.

Modificando i punti è possibile modificare il contorno di una forma o utilizzare una forma esistente come base per una nuova.

## **Suggerimenti per la Modifica delle Forme**

![overview_image](custom_shape_0.png)

Quando si modificano le forme di PowerPoint, tenere presenti questi concetti:

* Una forma (o il suo percorso) può essere chiusa o aperta.
* Il percorso di una forma è costituito da punti di ancoraggio collegati da segmenti.
* Un segmento può essere dritto o curvo. I punti di ancoraggio e le maniglie di controllo determinano la sua forma.
* I punti di ancoraggio esistono come punti d'angolo, punti dritti o punti uniformi:
  * In un punto d'angolo, i segmenti adiacenti possono incontrarsi con un angolo.
  * In un punto uniforme, le due maniglie di controllo sono allineate e alla stessa distanza dal punto di ancoraggio.
  * In un punto dritto, le due maniglie di controllo sono allineate ma possono trovarsi a distanze differenti dal punto di ancoraggio.
* Spostare i punti di ancoraggio o regolare le loro maniglie modifica il contorno della forma.

Per modificare le forme di PowerPoint tramite i punti di modifica, **Aspose.Slides** fornisce la classe [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

* Un'istanza di [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) rappresenta un percorso geometrico dell'oggetto [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/).
* Per recuperare il [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) da un'istanza di [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/), è possibile utilizzare il metodo [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths).
* Per impostare il [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) per una forma, è possibile utilizzare questi metodi: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) per forme con un singolo percorso e [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) per forme con percorsi multipli.
* Per aggiungere segmenti, è possibile utilizzare i metodi della classe [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).
* Utilizzando i metodi [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) e [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode), è possibile impostare l'aspetto di un percorso geometrico.
* Utilizzando il metodo [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData), è possibile recuperare il percorso geometrico di un [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) come un array di segmenti di percorso.
* Per accedere a ulteriori opzioni di personalizzazione della geometria della forma, è possibile leggere un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) tramite il suo [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) e riprodurre i segmenti su un [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

## **Operazioni di Modifica Semplici**

Utilizzare i seguenti metodi per modificare un percorso geometrico. Le sovraccariche che accettano un indice inseriscono un segmento in quella posizione a base zero nell'array dei segmenti del percorso.

| Operazione | Metodo |
| --- | --- |
| Aggiungi o inserisci una linea retta. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| Aggiungi o inserisci una curva Bézier cubica con due punti di controllo e un punto finale. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Aggiungi o inserisci una curva Bézier quadratica con un punto di controllo e un punto finale. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Aggiungi un arco ellittico con le dimensioni e gli angoli specificati in gradi. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| Chiudi la figura corrente collegando il suo punto finale al punto di partenza. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| Imposta il punto di partenza di una figura. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| Rimuovi un segmento in un indice base zero. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **Aggiungi Punti Personalizzati a una Forma**

Questo esempio inserisce due punti in una forma rettangolare usando [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) e applica il percorso modificato con [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath). Le coordinate sono locali alla forma: entrambi i nuovi punti sono al centro, a 100 punti dal lato sinistro e 50 punti dall'alto. Gli indici di segmento 1 e 4 li posizionano rispettivamente sui bordi superiore e inferiore, tirando quei bordi verso l'interno.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Rimuovi Punti da una Forma**

Questo esempio modifica il contorno di una forma a forma di cuore rimuovendo il segmento all'indice base zero 2 con [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt). Applicando il percorso modificato con [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) si aggiorna il contorno della forma.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Heart, 100, 100, 300, 300);

    const path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Crea una Forma Personalizzata**

Questo esempio costruisce una stella a cinque punte con [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/). Raggi esterni e interni alternati di 100 e 50 punti definiscono le punte e le rientranze; un passo di 72 gradi distribuisce uniformemente le cinque punte. Il percorso viene chiuso con [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) e applicato a una forma rettangolare usando [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), sostituendone il contorno.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const points = [];
const outerRadius = 100;
const innerRadius = 50;
const angleStep = 72;

for (let angle = -90; angle < 270; angle += angleStep) {
    let radians = angle * Math.PI / 180;
    points.push({ x: outerRadius * Math.cos(radians) + outerRadius, y: outerRadius * Math.sin(radians) + outerRadius });
    radians = (angle + angleStep / 2) * Math.PI / 180;
    points.push({ x: innerRadius * Math.cos(radians) + outerRadius, y: innerRadius * Math.sin(radians) + outerRadius });
}

const starPath = new slides.GeometryPath();
starPath.moveTo(java.newFloat(points[0].x), java.newFloat(points[0].y));
for (let i = 1; i < points.length; i++) {
    starPath.lineTo(java.newFloat(points[i].x), java.newFloat(points[i].y));
}
starPath.closeFigure();

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Crea una Forma Personalizzata Composita**

Questo esempio definisce due oggetti [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) chiusi per il terzo superiore e inferiore di una forma. Applicando entrambi i percorsi con [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) si crea un'unica forma composita con uno spazio al centro del terzo.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const topPath = new slides.GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3));
    topPath.lineTo(0, java.newFloat(shape.getHeight() / 3));
    topPath.closeFigure();

    const bottomPath = new slides.GeometryPath();
    bottomPath.moveTo(0, java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    const paths = java.newArray("com.aspose.slides.GeometryPath", [topPath, bottomPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Crea una Forma Personalizzata con Angoli Curvi**

Questo esempio combina segmenti dritti con [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) per creare una forma con angoli curvi verso l'interno. La dimensione di ogni angolo imposta larghezza e altezza dell'arco in punti, e la rotazione di -90 gradi disegna un quarto d'ellisse in senso antiorario. Il percorso completo viene applicato con [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), e la presentazione viene salvata in formato PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const shapeX = 20;
const shapeY = 20;
const shapeWidth = 300;
const shapeHeight = 200;

const leftTopSize = 50;
const rightTopSize = 20;
const rightBottomSize = 40;
const leftBottomSize = 10;

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    const geometryPath = new slides.GeometryPath();
    geometryPath.moveTo(leftTopSize, 0);
    geometryPath.lineTo(shapeWidth - rightTopSize, 0);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(shapeWidth, shapeHeight - rightBottomSize);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(leftBottomSize, shapeHeight);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(0, leftTopSize);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Scopri se una Geometria di Forma è Chiusa**

Il seguente helper verifica se ogni percorso geometrico non vuoto termina con un segmento di chiusura. Legge [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) e confronta il [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) finale con [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/). Restituisce false quando non ci sono percorsi non vuoti. Controlla il comando finale di ciascun percorso; non ispeziona ogni sottofigura all'interno di un percorso. L'esempio stampa `true` per un rettangolo.

```javascript
const slides = require("aspose.slides.via.java");

function isGeometryClosed(geometryShape) {
    let hasNonemptyPath = false;
    for (const geometryPath of geometryShape.getGeometryPaths()) {
        const segments = geometryPath.getPathData();
        if (segments.length === 0) {
            continue;
        }
        hasNonemptyPath = true;
        const lastSegment = segments[segments.length - 1];
        if (lastSegment.getPathCommand() !== slides.PathCommandType.Close) {
            return false;
        }
    }
    return hasNonemptyPath;
}

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const closed = isGeometryClosed(shape);
    console.log(closed);
} finally {
    presentation.dispose();
}
```

## **Ispeziona i Comandi del Percorso Geometrico**

Scarica [contour.pptx](contour.pptx) e posizionalo nella directory di lavoro dell'applicazione. La prima forma nella prima diapositiva ha un bordo superiore dritto, una curva Bézier cubica e un bordo di chiusura dritto. Usa [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) per leggere i percorsi della forma e [getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) per leggere i segmenti di ogni percorso in ordine di disegno. Per ciascun segmento, [getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) identifica il comando e determina come interpretare i valori restituiti da [getSegmentData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getSegmentData).

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("contour.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paths = shape.getGeometryPaths();
    for (const [i, path] of paths.entries()) {
        const segments = path.getPathData();
        for (const [j, segment] of segments.entries()) {
            const command = segment.getPathCommand();
            const data = segment.getSegmentData();
            let detail;
            switch (command) {
                case slides.PathCommandType.MoveTo:
                case slides.PathCommandType.LineTo:
                    const name = command === slides.PathCommandType.MoveTo ? "MoveTo" : "LineTo";
                    detail = `${name} destination=(${data[0]}, ${data[1]})`;
                    break;
                case slides.PathCommandType.CubicBezierTo:
                    detail = `CubicBezierTo control1=(${data[0]}, ${data[1]}) control2=(${data[2]}, ${data[3]}) end=(${data[4]}, ${data[5]})`;
                    break;
                case slides.PathCommandType.Close:
                    detail = "Close no coordinates";
                    break;
                default:
                    detail = `command=${command} raw=[${data.join(", ")}]`;
            }
            console.log(`Path ${i}, segment ${j}: ${detail}`);
        }
    }
} finally {
    presentation.dispose();
}
```

La forma si trova a (200, 100) punti sulla diapositiva. Le coordinate riportate sono locali alla forma, con (0, 0) nell'angolo in alto a sinistra, x crescente verso destra e y crescente verso il basso. Il segmento di chiusura ritorna al punto di partenza senza coordinate aggiuntive.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![Forma PowerPoint con bordo superiore dritto, bordo curvo dall'angolo in alto a destra a quello in basso a sinistra e bordo sinistro dritto](contour.png)

## **Estrai e Ispeziona gli Elementi della Forma**

Usa [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) per ispezionare una forma esistente come elementi contenenti punti del percorso e tipi di punto. Usa ciascun [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) restituito per recuperare gli array di punti e tipi tramite i metodi [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) e [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes). Questa rappresentazione è utile per l'analisi del contorno o per passare la geometria a strumenti di disegno personalizzati.

L'esempio apre input.pptx, trova la prima forma geometrica direttamente nella prima diapositiva e stampa i suoi segmenti di percorso. Usa una presentazione contenente una forma con segmenti dritti e curvi per vedere entrambi i tipi di output. Non ricerca all'interno dei gruppi.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let shape = null;
    for (let index = 0; index < slide.getShapes().size(); index++) {
        const candidate = slide.getShapes().get_Item(index);
        if (java.instanceOf(candidate, "com.aspose.slides.GeometryShape")) {
            shape = candidate;
            break;
        }
    }

    if (shape == null) {
        console.log("No geometry shape found on the first slide.");
    } else {
        for (const shapeElement of shape.createShapeElements()) {
            const points = shapeElement.getPathPoints();
            const types = shapeElement.getPathTypes();
            console.log("Shape element:");

            for (let i = 0; i < points.length; i++) {
                const pointType = types[i] & 0x07; // Mantieni il tipo di segmento, escludendo i flag.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consuma entrambi i punti di controllo e il punto finale.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    console.log("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Gli array corrispondono per indice: `points[i]` è un punto e `types[i]` descrive il suo ruolo. Il tipo `0` avvia una figura, e il tipo `1` traccia una linea dal punto precedente al punto corrente. Un segmento Bézier cubico inizia dal punto finale precedente e utilizza tre voci consecutive di tipo `3`: due punti di controllo seguiti dal nuovo punto finale. Il ciclo consuma queste tre voci insieme e controlla il punto finale per la chiusura.

I tipi di punto contengono anche flag. Mascherare con `0x07` per identificare il tipo di segmento, e testare `0x80` separatamente per rilevare un sottopercorso chiuso. Per esempio, `129` (`0x81`) indica un punto finale di linea che chiude un sottopercorso, e `131` (`0x83`) indica un punto finale Bézier che ne chiude uno. Java memorizza questi flag in byte con segno; la mascheratura preserva i valori dei bit desiderati. Confrontare il valore grezzo solo con `1` o `3` perderebbe questi casi. Altri flag, come il tratteggio (`0x10`) e il marcatore (`0x20`), non cambiano il tipo di segmento di base.

**Coordinate e trasformazioni.** I punti sono misurati in punti (1/72 di pollice), con X crescente verso destra e Y crescente verso il basso. Per una forma non raggruppata, le coordinate estratte includono già la posizione restituita da [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) e [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) e riflettono la sua larghezza e altezza attuali. Per esempio, un rettangolo non ruotato in `(100, 200)` con dimensioni `120 × 80` ha i limiti del contorno `(100, 200)`–`(220, 280)`. Non aggiungere nuovamente la posizione della forma. Sottrai X e Y per ottenere coordinate relative al suo riquadro non ruotato.

I punti estratti non applicano la rotazione della forma, restituita da [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation), né le inversioni orizzontali e verticali. Per riprodurre il contorno visualizzato, applica quelle trasformazioni intorno al centro della forma. Per forme raggruppate, considera anche la mappatura delle coordinate del gruppo e le trasformazioni; non assumere che i punti estratti siano le coordinate finali visualizzate nella diapositiva o applicare una traslazione o scala due volte se è già presente nel riquadro del figlio.

**Ispezione vs modifica.** Gli array estratti descrivono il contorno; modificarli non aggiorna la forma originale. Scegli questo approccio quando la tua analisi o codice di disegno ha bisogno di array punto/tipo. Usa [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) quando ti servono i comandi geometrici nel sistema di coordinate locale della forma o quando vuoi modificare la sua geometria. Applica i percorsi modificati tramite [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) o [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Converti una Forma Java AWT in GeometryPath**

Questo esempio combina un contorno rettangolare con testo convertito in geometria. Il metodo [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) del contorno ne disabilita il riempimento. Un [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) crea il contorno del testo in un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Il suo [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) fornisce segmenti di movimento, linea, quadratico, cubico e chiusura, che l'esempio riproduce su un [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

Il bridge Java utilizza valori float e byte espliciti per i parametri Java corrispondenti. L'iterator scrive le coordinate in un array float Java; il riflesso legge i valori aggiornati dal JavaScript. Il testo usa un font Arial da 40 punti. Il contorno è spostato di 20 punti orizzontalmente e posizionato con il suo bordo superiore visivo 10 punti sotto il bordo superiore della forma. Il percorso del testo è riempito, mentre il rettangolo originale rimane solo un contorno. Applicando entrambi i percorsi con [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) si ottiene una singola forma contenente il rettangolo e il testo.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 300, 100);
    
    const originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(java.newByte(slides.PathFillModeType.None));

    const font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    const image = java.newInstanceSync("java.awt.image.BufferedImage", 100, 100, java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
    const graphics = image.createGraphics();
    let graphicsPath;
    try {
        const fontContext = graphics.getFontRenderContext();
        const glyphVector = font.createGlyphVector(fontContext, "Text in shape");
        const textBounds = glyphVector.getVisualBounds();
        const baseline = java.newFloat(-textBounds.getY() + 10);
        graphicsPath = glyphVector.getOutline(java.newFloat(20), baseline);
    } finally {
        graphics.dispose();
    }

    const textPath = new slides.GeometryPath();
    const pathIterator = graphicsPath.getPathIterator(null);
    const coordinates = java.newArray("float", [0, 0, 0, 0, 0, 0]);

    while (!pathIterator.isDone()) {
        const segmentType = pathIterator.currentSegment(coordinates);
        const points = [];
        for (let i = 0; i < 6; i++) {
            const coordinate = java.callStaticMethodSync("java.lang.reflect.Array", "getFloat", coordinates, i);
            points.push(java.newFloat(coordinate));
        }
        switch (segmentType) {
            case 0: // Muovi a.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // Linea a.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // Curva Bézier quadratica.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // Curva Bézier cubica.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // Chiudi figura.
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }
    textPath.setFillMode(java.newByte(slides.PathFillModeType.Normal));
    const paths = java.newArray("com.aspose.slides.GeometryPath", [originalPath, textPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Cosa accadrà al riempimento e al contorno dopo aver sostituito la geometria?**

Lo stile rimane associato alla forma; solo il contorno cambia. Il riempimento e il contorno vengono applicati automaticamente alla nuova geometria.

**Come ruoto correttamente una forma personalizzata insieme alla sua geometria?**

Usa il metodo [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) della forma; la geometria ruota con la forma perché è legata al proprio sistema di coordinate.

**Posso convertire una forma personalizzata in un'immagine per "bloccare" il risultato?**

Sì. Esporta l'area della [presentazione](/slides/it/nodejs-java/convert-powerpoint-to-png/) o la [forma](/slides/it/nodejs-java/create-shape-thumbnails/) stessa in formato raster; questo semplifica ulteriori operazioni con geometrie complesse.