---
title: "Personalizza le Forme delle Presentazioni in .NET"
linktitle: "Forma Personalizzata"
type: docs
weight: 20
url: /it/net/custom-shape/
keywords:
- forma personalizzata
- aggiungere forma
- creare forma
- modificare forma
- geometria forma
- percorso geometria
- punti percorso
- punti di modifica
- aggiungere punto
- rimuovere punto
- operazione di modifica
- angolo curvo
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Crea e personalizza forme nelle presentazioni PowerPoint con Aspose.Slides per .NET: percorsi geometrici, angoli curvi, forme composite."
---
## **Panoramica**

Questo articolo spiega come personalizzare le forme delle presentazioni in Aspose.Slides modificando la geometria delle forme tramite punti di modifica e percorsi geometrici. Mostra come lavorare con `GeometryPath` e `IGeometryPath` per modificare forme esistenti, eseguire operazioni di base di modifica del percorso, aggiungere o rimuovere punti e applicare la geometria aggiornata a una forma.

Dimostra inoltre come creare forme personalizzate e composite, costruire forme con angoli curve, determinare se la geometria di una forma è chiusa e convertire tra `GeometryPath` e `GraphicsPath` per ulteriori scenari di personalizzazione della geometria.

## **Modifica una Forma Utilizzando i Punti di Modifica**

Considera un quadrato. In PowerPoint, usando **punti di modifica**, puoi 

* spostare l'angolo del quadrato verso l'interno o l'esterno
* specificare la curvatura per un angolo o un punto
* aggiungere nuovi punti al quadrato
* manipolare i punti sul quadrato, ecc. 

Essenzialmente, puoi eseguire le operazioni descritte su qualsiasi forma. Utilizzando i punti di modifica, puoi modificare una forma o crearne una nuova a partire da una forma esistente. 

## **Suggerimenti per la Modifica delle Forme**

![panoramica](custom_shape_0.png)

Prima di iniziare a modificare le forme di PowerPoint tramite i punti di modifica, potresti voler considerare i seguenti aspetti delle forme:

* Una forma (o il suo percorso) può essere chiusa oppure aperta.
* Tutte le forme sono composte da almeno 2 punti di ancoraggio collegati tra loro da linee.
* Una linea è rettilinea o curva. I punti di ancoraggio determinano la natura della linea. 
* I punti di ancoraggio esistono come punti d'angolo, punti lineari o punti lisci:
  * Un punto d'angolo è un punto in cui 2 linee rette si uniscono formando un angolo. 
  * Un punto liscio è un punto in cui 2 maniglie esistono in una linea retta e i segmenti della linea si uniscono in una curva fluida. In questo caso, tutte le maniglie sono separate dal punto di ancoraggio di una distanza uguale. 
  * Un punto lineare è un punto in cui 2 maniglie esistono in una linea retta e i segmenti di quella linea si uniscono in una curva fluida. In questo caso, le maniglie non devono essere separate dal punto di ancoraggio di una distanza uguale. 
* Spostando o modificando i punti di ancoraggio (che cambiano l'angolo delle linee), puoi alterare l'aspetto di una forma. 

Per modificare le forme di PowerPoint tramite i punti di modifica, **Aspose.Slides** fornisce la classe [**GeometryPath**](https://reference.aspose.com/slides/it/net/aspose.slides/geometrypath) e l'interfaccia [**IGeometryPath**](https://reference.aspose.com/slides/it/net/aspose.slides/igeometrypath).

* Un'istanza di [GeometryPath](https://reference.aspose.com/slides/it/net/aspose.slides/geometrypath) rappresenta un percorso geometrico dell'oggetto [IGeometryShape](https://reference.aspose.com/slides/it/net/aspose.slides/igeometryshape).
* Per recuperare il `GeometryPath` dall'istanza `IGeometryShape`, puoi usare il metodo [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/it/net/aspose.slides/igeometryshape/methods/getgeometrypaths).
* Per impostare il `GeometryPath` per una forma, puoi utilizzare questi metodi: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/it/net/aspose.slides/igeometryshape/methods/setgeometrypath) per *forme solide* e [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/it/net/aspose.slides/igeometryshape/methods/setgeometrypaths) per *forme composite*.
* Per aggiungere segmenti, puoi utilizzare i metodi sotto [IGeometryPath](https://reference.aspose.com/slides/it/net/aspose.slides/igeometrypath). 
* Utilizzando le proprietà [IGeometryPath.Stroke](https://reference.aspose.com/slides/it/net/aspose.slides/igeometrypath/properties/stroke) e [IGeometryPath.FillMode](https://reference.aspose.com/slides/it/net/aspose.slides/igeometrypath/properties/fillmode), puoi impostare l'aspetto di un percorso geometrico.
* Utilizzando la proprietà [IGeometryPath.PathData](https://reference.aspose.com/slides/it/net/aspose.slides/igeometrypath/properties/pathdata), puoi recuperare il percorso geometrico di un `GeometryShape` come un array di segmenti di percorso. 
* Per accedere a ulteriori opzioni di personalizzazione della geometria delle forme, puoi convertire [GeometryPath](https://reference.aspose.com/slides/it/net/aspose.slides/geometrypath) in [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0)
* Usa i metodi [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/it/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) e [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/it/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (dalla classe [ShapeUtil](https://reference.aspose.com/slides/it/net/aspose.slides.util/shapeutil)) per convertire [GeometryPath](https://reference.aspose.com/slides/it/net/aspose.slides/geometrypath) in [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) e viceversa. 

## **Operazioni di Modifica Semplici**

Questo codice C# ti mostra come

**Aggiungere una linea** alla fine di un percorso

``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Aggiungere una linea** a una posizione specifica su un percorso:

``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**Aggiungere una curva Bézier cubica** alla fine di un percorso:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Aggiungere una curva Bézier cubica** alla posizione specificata su un percorso:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**Aggiungere una curva Bézier quadratica** alla fine di un percorso:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Aggiungere una curva Bézier quadratica** a una posizione specificata su un percorso:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**Aggiungere un arco specifico** a un percorso:

``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Chiudere la figura corrente** di un percorso:

``` csharp
void CloseFigure();
```
**Impostare la posizione per il punto successivo**:

``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Rimuovere il segmento del percorso** a un indice dato:

``` csharp
void RemoveAt(int index);
```

## **Aggiungere Punti Personalizzati a una Forma**

1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/net/aspose.slides/geometryshape) e imposta il tipo [ShapeType.Rectangle](https://reference.aspose.com/slides/it/net/aspose.slides/shapetype).
2. Ottieni un'istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/net/aspose.slides/geometrypath) dalla forma.
3. Aggiungi un nuovo punto tra i due punti superiori del percorso.
4. Aggiungi un nuovo punto tra i due punti inferiori del percorso.
5. Applica il percorso alla forma.

Questo codice C# ti mostra come aggiungere punti personalizzati a una forma:

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;
    IGeometryPath geometryPath = shape.GetGeometryPaths()[0];

    geometryPath.LineTo(100, 50, 1);
    geometryPath.LineTo(100, 50, 4);
    shape.SetGeometryPath(geometryPath);
}
```

![esempio1](custom_shape_1.png)

## **Rimuovere Punti da una Forma**

1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/net/aspose.slides/geometryshape) e imposta il tipo [ShapeType.Heart](https://reference.aspose.com/slides/it/net/aspose.slides/shapetype). 
2. Ottieni un'istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/net/aspose.slides/geometrypath) dalla forma.
3. Rimuovi il segmento del percorso.
4. Applica il percorso alla forma.

Questo codice C# ti mostra come rimuovere punti da una forma:

``` csharp
using (Presentation pres = new Presentation())
{
	GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

	IGeometryPath path = shape.GetGeometryPaths()[0];
	path.RemoveAt(2);
	shape.SetGeometryPath(path);
}
```
![esempio2](custom_shape_2.png)

## **Creare una Forma Personalizzata**

1. Calcola i punti per la forma.
2. Crea un'istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/net/aspose.slides/geometrypath). 
3. Riempisci il percorso con i punti.
4. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/net/aspose.slides/geometryshape). 
5. Applica il percorso alla forma.

Questo codice C# ti mostra come creare una forma personalizzata:

``` csharp
List<PointF> points = new List<PointF>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.Cos(radians);
    double y = R * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.Cos(radians);
    y = r * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (int i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2) as GeometryShape;

    shape.SetGeometryPath(starPath);
}
```
![esempio3](custom_shape_3.png)

## **Creare una Forma Personalizzata Composita**

1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/net/aspose.slides/geometryshape).
2. Crea una prima istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/net/aspose.slides/geometrypath).
3. Crea una seconda istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/net/aspose.slides/geometrypath).
4. Applica i percorsi alla forma.

Questo codice C# ti mostra come creare una forma personalizzata composita:

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.MoveTo(0, 0);
    geometryPath0.LineTo(shape.Width, 0);
    geometryPath0.LineTo(shape.Width, shape.Height/3);
    geometryPath0.LineTo(0, shape.Height / 3);
    geometryPath0.CloseFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.MoveTo(0, shape.Height/3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height / 3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height);
    geometryPath1.LineTo(0, shape.Height);
    geometryPath1.CloseFigure();

    shape.SetGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
}
```
![esempio4](custom_shape_4.png)

## **Creare una Forma Personalizzata con Angoli Curvi**

Questo codice C# ti mostra come creare una forma personalizzata con angoli curvi (verso l'interno);

```c#
var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using (var presentation = new Presentation())
{
    var childShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    var geometryPath = new GeometryPath();

    var point1 = new PointF(leftTopSize, 0);
    var point2 = new PointF(shapeWidth - rightTopSize, 0);
    var point3 = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    var point4 = new PointF(leftBottomSize, shapeHeight);
    var point5 = new PointF(0, leftTopSize);

    geometryPath.MoveTo(point1);
    geometryPath.LineTo(point2);
    geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.LineTo(point3);
    geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.LineTo(point4);
    geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.LineTo(point5);
    geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.CloseFigure();

    childShape.SetGeometryPath(geometryPath);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Scoprire se una Geometria di Forma è Chiusa**

Una forma chiusa è definita come quella i cui lati si connettono tutti, formando un unico contorno senza spazi. Tale forma può essere una semplice figura geometrica o un contorno personalizzato complesso. Il seguente esempio di codice mostra come verificare se la geometria di una forma è chiusa:

```cs
bool IsGeometryClosed(IGeometryShape geometryShape)
{
    bool? isClosed = null;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var dataLength = geometryPath.PathData.Length;
        if (dataLength == 0)
            continue;

        var lastSegment = geometryPath.PathData[dataLength - 1];
        isClosed = lastSegment.PathCommand == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }
    
    return isClosed == true;
}
```

## **Convertire GeometryPath in GraphicsPath (System.Drawing.Drawing2D)** 

1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/net/aspose.slides/geometryshape).
2. Crea un'istanza della classe [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) del namespace [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
3. Converte l'istanza [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) nell'istanza [GeometryPath](https://reference.aspose.com/slides/it/net/aspose.slides/geometrypath) utilizzando [ShapeUtil](https://reference.aspose.com/slides/it/net/aspose.slides.util/shapeutil).
4. Applica i percorsi alla forma.

Questo codice C# — un'implementazione dei passaggi sopra — dimostra il processo di conversione da **GeometryPath** a **GraphicsPath**:

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("Text in shape", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```
![esempio5](custom_shape_5.png)

## **FAQ**

**Cosa succederà al riempimento e al contorno dopo aver sostituito la geometria?**

Lo stile rimane associato alla forma; solo il contorno cambia. Il riempimento e il contorno vengono applicati automaticamente alla nuova geometria.

**Come ruoto correttamente una forma personalizzata insieme alla sua geometria?**

Usa la proprietà [rotation](https://reference.aspose.com/slides/it/net/aspose.slides/shape/rotation/) della forma; la geometria ruota con la forma perché è legata al sistema di coordinate della stessa forma.

**Posso convertire una forma personalizzata in un'immagine per "bloccare" il risultato?**

Sì. Esporta l'area della [slide](/slides/it/net/convert-powerpoint-to-png/) o la [forma](/slides/it/net/create-shape-thumbnails/) stessa in un formato raster; questo semplifica ulteriori operazioni con geometrie complesse.