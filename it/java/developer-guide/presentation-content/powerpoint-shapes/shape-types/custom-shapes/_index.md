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

Questo articolo spiega come personalizzare le forme di presentazione in Aspose.Slides modificando la geometria della forma tramite punti di modifica e percorsi di geometria. Mostra come lavorare con `GeometryPath` e `IGeometryPath` per modificare forme esistenti, eseguire operazioni di modifica di base del percorso, aggiungere o rimuovere punti e applicare la geometria aggiornata a una forma.

Dimostra anche come creare forme personalizzate e composite, costruire forme con angoli curvi, determinare se la geometria di una forma è chiusa e convertire tra `GeometryPath` e `java.awt.Shape` per scenari aggiuntivi di personalizzazione della geometria.

## **Modifica una forma usando i punti di modifica**

Considera un quadrato. In PowerPoint, usando **edit points**, puoi

* spostare l'angolo del quadrato verso l'interno o l'esterno
* specificare la curvatura per un angolo o punto
* aggiungere nuovi punti al quadrato
* manipolare i punti sul quadrato, ecc.

Essenzialmente, puoi eseguire le attività descritte su qualsiasi forma. Usando i punti di modifica, puoi modificare una forma o crearne una nuova da una forma esistente. 

## **Suggerimenti per la modifica delle forme**

![overview_image](custom_shape_0.png)

Prima di iniziare a modificare le forme di PowerPoint tramite i punti di modifica, potresti voler considerare questi aspetti delle forme:

* Una forma (o il suo percorso) può essere chiusa o aperta.
* Quando una forma è chiusa, non ha un punto di inizio o di fine. Quando una forma è aperta, ha un inizio e una fine. 
* Tutte le forme sono composte da almeno 2 punti di ancoraggio collegati tra loro da linee
* Una linea è rettilinea o curva. I punti di ancoraggio determinano la natura della linea. 
* I punti di ancoraggio possono essere punti d'angolo, punti retti o punti lisci:
  * Un punto d'angolo è un punto in cui 2 linee rette si uniscono formando un angolo. 
  * Un punto liscio è un punto in cui 2 maniglie si trovano su una linea retta e i segmenti della linea si uniscono in una curva fluida. In questo caso, tutte le maniglie sono distanziate dal punto di ancoraggio di pari distanza. 
  * Un punto retto è un punto in cui 2 maniglie si trovano su una linea retta e i segmenti della linea si uniscono in una curva fluida. In questo caso, le maniglie non devono essere distanziate dal punto di ancoraggio di pari distanza. 
* Spostando o modificando i punti di ancoraggio (che cambia l'angolo delle linee), è possibile alterare l'aspetto di una forma. 

Per modificare le forme di PowerPoint tramite i punti di modifica, **Aspose.Slides** fornisce la [**GeometryPath**](https://reference.aspose.com/slides/it/java/com.aspose.slides/GeometryPath) e l'interfaccia [**IGeometryPath**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IGeometryPath). 

* Un [GeometryPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/GeometryPath) rappresenta il percorso geometrico dell'oggetto [IGeometryShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IGeometryShape). 
* Per recuperare il `GeometryPath` dall'istanza `IGeometryShape`, è possibile utilizzare il metodo [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/it/java/com.aspose.slides/IGeometryShape#getGeometryPaths--). 
* Per impostare il `GeometryPath` di una forma, è possibile usare questi metodi: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) per *forme solide* e [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/it/java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) per *forme composite*.
* Per aggiungere segmenti, è possibile utilizzare i metodi sotto [IGeometryPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/IGeometryPath). 
* Utilizzando i metodi [IGeometryPath.setStroke](https://reference.aspose.com/slides/it/java/com.aspose.slides/IGeometryPath#setStroke-boolean-) e [IGeometryPath.setFillMode](https://reference.aspose.com/slides/it/java/com.aspose.slides/IGeometryPath#setFillMode-byte-), è possibile definire l'aspetto di un percorso geometrico.
* Con il metodo [IGeometryPath.getPathData](https://reference.aspose.com/slides/it/java/com.aspose.slides/IGeometryPath#getPathData--) è possibile ottenere il percorso geometrico di un `GeometryShape` come array di segmenti di percorso. 
* Per accedere a ulteriori opzioni di personalizzazione della geometria della forma, è possibile convertire [GeometryPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/GeometryPath) in [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Utilizza i metodi [geometryPathToGraphicsPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) e [graphicsPathToGeometryPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (dalla classe [ShapeUtil](https://reference.aspose.com/slides/it/java/com.aspose.slides/ShapeUtil)) per convertire [GeometryPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/GeometryPath) in [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) e viceversa. 

## **Operazioni di modifica semplici**

Questo codice Java mostra come

**Aggiungere una linea** alla fine di un percorso

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Aggiungere una linea** in una posizione specifica su un percorso:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Aggiungere una curva di Bezier cubica** alla fine di un percorso:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Aggiungere una curva di Bezier cubica** nella posizione specificata su un percorso:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Aggiungere una curva di Bezier quadratica** alla fine di un percorso:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Aggiungere una curva di Bezier quadratica** in una posizione specifica su un percorso:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Aggiungere un arco specificato** a un percorso:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Chiudere la figura corrente** di un percorso:

``` java
public void closeFigure();
```
**Impostare la posizione per il punto successivo**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Rimuovere il segmento del percorso** all'indice indicato:

``` java
public void removeAt(int index);
```

## **Aggiungere punti personalizzati a una forma**
1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/GeometryShape) e imposta il tipo [ShapeType.Rectangle](https://reference.aspose.com/slides/it/java/com.aspose.slides/ShapeType).
2. Ottieni un'istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/GeometryPath) dalla forma.
3. Aggiungi un nuovo punto tra i due punti superiori del percorso.
4. Aggiungi un nuovo punto tra i due punti inferiori del percorso.
5. Applica il percorso alla forma.

Questo codice Java mostra come aggiungere punti personalizzati a una forma:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    IGeometryPath geometryPath = shape.getGeometryPaths()[0];

    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) pres.dispose();
}
```
![example1_image](custom_shape_1.png)

## **Rimuovere punti da una forma**

1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/GeometryShape) e imposta il tipo [ShapeType.Heart](https://reference.aspose.com/slides/it/java/com.aspose.slides/ShapeType).
2. Ottieni un'istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/GeometryPath) dalla forma.
3. Rimuovi il segmento del percorso.
4. Applica il percorso alla forma.

Questo codice Java mostra come rimuovere punti da una forma:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) pres.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Creare una forma personalizzata**

1. Calcola i punti per la forma.
2. Crea un'istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/GeometryPath). 
3. Riempie il percorso con i punti.
4. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/GeometryShape). 
5. Applica il percorso alla forma.

Questo esempio Java mostra come creare una forma personalizzata:

``` java
List<Point2D.Float> points = new ArrayList<Point2D.Float>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.cos(radians);
    double y = R * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.cos(radians);
    y = r * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2);

    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) pres.dispose();
}
```
![example3_image](custom_shape_3.png)


## **Creare una forma composita personalizzata**

1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/GeometryShape).
2. Crea una prima istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/GeometryPath).
3. Crea una seconda istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/GeometryPath).
4. Applica i percorsi alla forma.

Questo codice Java mostra come creare una forma composita personalizzata:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight()/3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.moveTo(0, shape.getHeight()/3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
} finally {
    if (pres != null) pres.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Creare una forma personalizzata con angoli curvi**

Questo codice Java mostra come creare una forma personalizzata con angoli curvi (verso l'interno);

```java
float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation pres = new Presentation();
try {
    IAutoShape childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(
            ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    GeometryPath geometryPath = new GeometryPath();

    Point2D.Float point1 = new Point2D.Float(leftTopSize, 0);
    Point2D.Float point2 = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float point3 = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float point4 = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float point5 = new Point2D.Float(0, leftTopSize);

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

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres!= null) pres.dispose();
}
```

## **Verificare se la geometria di una forma è chiusa**

Una forma chiusa è definita come una forma i cui lati si connettono tutti, formando un unico contorno senza spazi. Tale forma può essere una semplice figura geometrica o un contorno personalizzato complesso. L'esempio di codice seguente mostra come verificare se la geometria di una forma è chiusa:

```java
boolean isGeometryClosed(IGeometryShape geometryShape)
{
    Boolean isClosed = null;

    for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
        int dataLength = geometryPath.getPathData().length;
        if (dataLength == 0)
            continue;

        IPathSegment lastSegment = geometryPath.getPathData()[dataLength - 1];
        isClosed = lastSegment.getPathCommand() == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }

    return isClosed == true;
}
```

## **Convertire GeometryPath in java.awt.Shape** 

1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/GeometryShape).
2. Crea un'istanza della classe [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Converti l'istanza [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) nell'istanza [GeometryPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/GeometryPath) utilizzando [ShapeUtil](https://reference.aspose.com/slides/it/java/com.aspose.slides/ShapeUtil).
4. Applica i percorsi alla forma.

Questo codice Java—un'implementazione dei passaggi sopra—dimostra il processo di conversione da **GeometryPath** a **GraphicsPath**:

``` java
Presentation pres = new Presentation();
try {
    // Crea una nuova forma
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Ottieni il percorso geometrico della forma
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Crea un nuovo percorso grafico con testo
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage img = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D g2 = img.createGraphics();

    try
    {
        GlyphVector glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20f, ((float) -glyphVector.getVisualBounds().getY()) + 10);
    }
    finally {
        g2.dispose();
    }

    // Converti il percorso grafico in percorso geometrico
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Imposta la combinazione del nuovo percorso geometrico e del percorso geometrico originale sulla forma
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Cosa accade al riempimento e al contorno dopo aver sostituito la geometria?**

Lo stile rimane associato alla forma; cambia solo il contorno. Il riempimento e il contorno vengono applicati automaticamente alla nuova geometria.

**Come ruoto correttamente una forma personalizzata insieme alla sua geometria?**

Usa il metodo [setRotation](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#setRotation-float-) della forma; la geometria ruota con la forma perché è legata al sistema di coordinate della forma stessa.

**Posso convertire una forma personalizzata in un'immagine per "bloccarne" il risultato?**

Sì. Esporta l'[slide](/slides/it/java/convert-powerpoint-to-png/) o la [shape](/slides/it/java/create-shape-thumbnails/) desiderata in formato raster; ciò semplifica il lavoro successivo con geometrie complesse.