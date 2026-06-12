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
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea e personalizza forme nelle presentazioni PowerPoint con JavaScript e Aspose.Slides per Node.js: percorsi geometrici, angoli curvi, forme composite."
---
## **Panoramica**

Questo articolo spiega come personalizzare le forme di presentazione in Aspose.Slides modificando la geometria della forma mediante punti di modifica e percorsi geometrici. Mostra come lavorare con `GeometryPath` per modificare forme esistenti, eseguire operazioni di modifica di base del percorso, aggiungere o rimuovere punti e applicare la geometria aggiornata a una forma.

Dimostra anche come creare forme personalizzate e composite, costruire forme con angoli curvi, determinare se la geometria di una forma è chiusa e convertire tra `GeometryPath` e `java.awt.Shape` per scenari aggiuntivi di personalizzazione geometrica.

## **Modifica una forma usando punti di modifica**

Considera un quadrato. In PowerPoint, usando **edit points**, puoi  

* spostare l'angolo del quadrato verso l'interno o l'esterno  
* specificare la curvatura per un angolo o un punto  
* aggiungere nuovi punti al quadrato  
* manipolare i punti sul quadrato, ecc.  

In sostanza, puoi eseguire le operazioni descritte su qualsiasi forma. Usando i punti di modifica, puoi cambiare una forma o crearne una nuova a partire da una forma esistente. 

## **Suggerimenti per la modifica della forma**

![overview_image](custom_shape_0.png)

Prima di iniziare a modificare le forme di PowerPoint tramite i punti di modifica, potresti considerare questi aspetti sulle forme:

* Una forma (o il suo percorso) può essere chiusa o aperta.  
* Quando una forma è chiusa, non ha un punto di inizio o di fine. Quando è aperta, ha un inizio e una fine.  
* Tutte le forme sono composte da almeno 2 punti di ancoraggio collegati tra loro da linee  
* Una linea è dritta o curva. I punti di ancoraggio determinano la natura della linea.  
* I punti di ancoraggio esistono come punti d'angolo, punti dritti o punti lisci:  
  * Un punto d'angolo è un punto dove due linee rette si incontrano formando un angolo.  
  * Un punto liscio è un punto dove due maniglie esistono su una linea retta e i segmenti della linea si uniscono in una curva fluida. In questo caso, tutte le maniglie sono distanti dal punto di ancoraggio di una distanza uguale.  
  * Un punto dritto è un punto dove due maniglie esistono su una linea retta e i segmenti di quella linea si uniscono in una curva fluida. In questo caso, le maniglie non devono essere distanti dal punto di ancoraggio di una distanza uguale.  
* Muovendo o modificando i punti di ancoraggio (che cambiano l'angolo delle linee), è possibile modificare l'aspetto di una forma.  

Per modificare le forme di PowerPoint tramite i punti di modifica, **Aspose.Slides** fornisce la classe [**GeometryPath**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryPath) e la classe [**GeometryPath**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryPath).

* Un [GeometryPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryPath) rappresenta un percorso geometrico dell'oggetto [GeometryShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryShape).  
* Per recuperare il `GeometryPath` dall'istanza `GeometryShape`, puoi usare il metodo [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--).  
* Per impostare il `GeometryPath` per una forma, puoi usare questi metodi: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) per *forme solide* e [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-) per *forme composite*.  
* Per aggiungere segmenti, puoi usare i metodi nella classe [GeometryPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryPath).  
* Usando i metodi [GeometryPath.setStroke](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) e [GeometryPath.setFillMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-), puoi impostare l'aspetto di un percorso geometrico.  
* Con il metodo [GeometryPath.getPathData](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryPath#getPathData--) puoi recuperare il percorso geometrico di un `GeometryShape` come array di segmenti di percorso.  
* Per accedere a ulteriori opzioni di personalizzazione della geometria della forma, puoi convertire [GeometryPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryPath) in [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).  
* Usa i metodi [geometryPathToGraphicsPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) e [graphicsPathToGeometryPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (dalla classe [ShapeUtil](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeUtil)) per convertire [GeometryPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryPath) in [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) e viceversa.

## **Operazioni di modifica semplici**

Questo codice JavaScript mostra come  

**Aggiungi una linea** alla fine di un percorso  

```javascript
lineTo(point);
lineTo(x, y);
```
**Aggiungi una linea** a una posizione specificata su un percorso:  

```javascript
lineTo(point, index);
lineTo(x, y, index);
```
**Aggiungi una curva cubica Bézier** alla fine di un percorso:  

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Aggiungi una curva cubica Bézier** alla posizione specificata su un percorso:  

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Aggiungi una curva quadratica Bézier** alla fine di un percorso:  

```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```
**Aggiungi una curva quadratica Bézier** a una posizione specificata su un percorso:  

```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```
**Aggiungi un arco specificato** a un percorso:  

```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```
**Chiudi la figura corrente** di un percorso:  

```javascript
closeFigure();
```
**Imposta la posizione per il punto successivo**:  

```javascript
moveTo(point);
moveTo(x, y);
```
**Rimuovi il segmento del percorso** a un indice specificato:  

```javascript
removeAt(index);
```

## **Aggiungi punti personalizzati alla forma**
1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryShape) e imposta il tipo [ShapeType.Rectangle](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeType).  
2. Ottieni un'istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryPath) dalla forma.  
3. Aggiungi un nuovo punto tra i due punti superiori del percorso.  
4. Aggiungi un nuovo punto tra i due punti inferiori del percorso.  
5. Applica il percorso alla forma.  

Questo codice JavaScript mostra come aggiungere punti personalizzati a una forma:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example1_image](custom_shape_1.png)

## **Rimuovi punti dalla forma**

1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryShape) e imposta il tipo [ShapeType.Heart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeType).  
2. Ottieni un'istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryPath) dalla forma.  
3. Rimuovi il segmento del percorso.  
4. Applica il percorso alla forma.  

Questo codice JavaScript mostra come rimuovere punti da una forma:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Heart, 100, 100, 300, 300);
    var path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example2_image](custom_shape_2.png)

## **Crea forma personalizzata**

1. Calcola i punti per la forma.  
2. Crea un'istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryPath).  
3. Riempi il percorso con i punti.  
4. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryShape).  
5. Applica il percorso alla forma.  

Questo JavaScript mostra come creare una forma personalizzata:  

```javascript
var points = java.newInstanceSync("java.util.ArrayList");
var R = 100;
var r = 50;
var step = 72;
for (var angle = -90; angle < 270; angle += step) {
    var radians = angle * (java.getStaticFieldValue("java.lang.Math", "PI") / 180.0);
    var x = R * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    var y = R * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
    radians = (java.getStaticFieldValue("java.lang.Math", "PI") * (angle + (step / 2))) / 180.0;
    x = r * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    y = r * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
}
var starPath = new aspose.slides.GeometryPath();
starPath.moveTo(points.get(0));
for (var i = 1; i < points.size(); i++) {
    starPath.lineTo(points.get(i));
}
starPath.closeFigure();
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, R * 2, R * 2);
    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example3_image](custom_shape_3.png)


## **Crea forma personalizzata composita**

1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryShape).  
2. Crea una prima istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryPath).  
3. Crea una seconda istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryPath).  
4. Applica i percorsi alla forma.  

Questo codice JavaScript mostra come creare una forma personalizzata composita:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath0 = new aspose.slides.GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight() / 3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();
    var geometryPath1 = new aspose.slides.GeometryPath();
    geometryPath1.moveTo(0, (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();
    shape.setGeometryPaths(java.newArray("com.aspose.slides.GeometryPath",[geometryPath0, geometryPath1]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example4_image](custom_shape_4.png)

## **Crea forma personalizzata con angoli curvi**

Questo codice JavaScript mostra come creare una forma personalizzata con angoli curvi (verso l'interno);  

```javascript
var shapeX = 20.0;
var shapeY = 20.0;
var shapeWidth = 300.0;
var shapeHeight = 200.0;
var leftTopSize = 50.0;
var rightTopSize = 20.0;
var rightBottomSize = 40.0;
var leftBottomSize = 10.0;
var pres = new aspose.slides.Presentation();
try {
    var childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
    var geometryPath = new aspose.slides.GeometryPath();
    var point1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftTopSize, 0);
    var point2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth - rightTopSize, 0);
    var point3 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth, shapeHeight - rightBottomSize);
    var point4 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftBottomSize, shapeHeight);
    var point5 = java.newInstanceSync("com.aspose.slides.Point2DFloat", 0, leftTopSize);
    geometryPath.moveTo(point1);
    geometryPath.lineTo(point2);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(point3);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(point4);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(point5);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();
    childShape.setGeometryPath(geometryPath);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Scopri se la geometria di una forma è chiusa**

Una forma chiusa è definita come una in cui tutti i lati si collegano, formando un unico contorno senza buchi. Tale forma può essere una semplice figura geometrica o un contorno personalizzato complesso. L'esempio di codice seguente mostra come verificare se la geometria di una forma è chiusa:  

```java
function isGeometryClosed(geometryShape) 
{
    let isClosed = null;

    geometryShape.getGeometryPaths().forEach(geometryPath => {
        const pathData = geometryPath.getPathData();
        const dataLength = pathData.length;

        if (dataLength === 0) return;

        const lastSegment = pathData[dataLength - 1];
        isClosed = lastSegment.getPathCommand() === aspose.slides.PathCommandType.Close;

        if (!isClosed) return false;
    });

    return isClosed === true;
}
```

## **Converti GeometryPath in java.awt.Shape** 

1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryShape).  
2. Crea un'istanza della classe [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).  
3. Converti l'istanza [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) in un'istanza [GeometryPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryPath) usando [ShapeUtil](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeUtil).  
4. Applica i percorsi alla forma.  

Questo codice JavaScript—un'implementazione dei passaggi sopra—dimostra il processo di conversione da **GeometryPath** a **GraphicsPath**:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Crea una nuova forma
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // Ottieni il percorso geometrico della forma
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // Crea un nuovo percorso grafico con testo
    var graphicsPath;
    var font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    var text = "Text in shape";
    var img = java.newInstanceSync("BufferedImage", 100, 100, java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
    var g2 = img.createGraphics();
    try {
        var glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20.0, -glyphVector.getVisualBounds().getY() + 10);
    } finally {
        g2.dispose();
    }
    // Converte il percorso grafico in percorso geometrico
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // Imposta la combinazione del nuovo percorso geometrico e del percorso geometrico originale sulla forma
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Cosa succederà al riempimento e al contorno dopo aver sostituito la geometria?**

Lo stile rimane associato alla forma; cambia solo il contorno. Il riempimento e il contorno vengono applicati automaticamente alla nuova geometria.

**Come ruoto correttamente una forma personalizzata insieme alla sua geometria?**

Usa il metodo [setRotation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/setrotation/) della forma; la geometria ruota con la forma perché è legata al sistema di coordinate proprio della forma.

**Posso convertire una forma personalizzata in un'immagine per “bloccare” il risultato?**

Sì. Esporta l'area della [slide](/slides/it/nodejs-java/convert-powerpoint-to-png/) richiesta o la [shape](/slides/it/nodejs-java/create-shape-thumbnails/) stessa in un formato raster; questo semplifica il lavoro successivo con geometrie complesse.