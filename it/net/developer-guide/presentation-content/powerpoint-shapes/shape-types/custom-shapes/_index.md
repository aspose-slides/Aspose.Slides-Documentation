---
title: Personalizza le forme di presentazione in .NET
linktitle: Forma personalizzata
type: docs
weight: 20
url: /it/net/custom-shape/
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
- .NET
- C#
- Aspose.Slides
description: "Crea e personalizza le forme nelle presentazioni PowerPoint con Aspose.Slides per .NET: percorsi geometrici, angoli curvi, forme composite."
---
## **Panoramica**

Questo articolo spiega come personalizzare le forme delle presentazioni in Aspose.Slides modificando la geometria delle forme tramite punti di modifica e percorsi geometrici. Mostra come lavorare con [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) e [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) per modificare forme esistenti, eseguire operazioni di modifica di base del percorso, aggiungere o rimuovere punti e applicare la geometria aggiornata a una forma.

Dimostra inoltre come creare forme personalizzate e composite, costruire forme con angoli curvi, determinare se la geometria di una forma è chiusa e utilizzare la conversione legacy tra [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) e [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) per scenari aggiuntivi di personalizzazione della geometria.

## **Modifica una forma usando i punti di modifica**

In PowerPoint è possibile utilizzare **Edit Points** per modificare un quadrato:

* Spostare un angolo verso l'interno o verso l'esterno.  
* Regolare la curvatura in un punto.  
* Aggiungere nuovi punti.

La modifica dei punti consente di modificare il contorno di una forma o di utilizzare una forma esistente come base per una nuova forma.

## **Suggerimenti per la modifica delle forme**

![immagine_panoramica](custom_shape_0.png)

Quando si modificano forme in PowerPoint, tenere presenti questi concetti:

* Una forma (o il suo percorso) può essere chiusa o aperta.  
* Il percorso di una forma è costituito da punti di ancoraggio collegati da segmenti.  
* Un segmento può essere dritto o curvo. I punti di ancoraggio e le maniglie di controllo determinano la sua forma.  
* I punti di ancoraggio esistono come punti d'angolo, punti dritti o punti lisci:  
  * In un punto d'angolo, i segmenti adiacenti possono incontrarsi formando un angolo.  
  * In un punto liscio, le due maniglie di controllo sono allineate e a uguale distanza dal punto di ancoraggio.  
  * In un punto dritto, le due maniglie di controllo sono allineate ma possono trovarsi a distanze diverse dal punto di ancoraggio.  
* Spostare i punti di ancoraggio o regolare le loro maniglie cambia il contorno della forma.

Per modificare le forme di PowerPoint tramite punti di modifica, **Aspose.Slides** fornisce la classe [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) e l'interfaccia [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* Un'istanza di [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) rappresenta il percorso geometrico dell'oggetto [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).  
* Per recuperare il [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) da un'istanza di [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/), è possibile utilizzare il metodo [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).  
* Per impostare il [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) di una forma, è possibile usare questi metodi: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) per forme con un singolo percorso e [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) per forme con percorsi multipli.  
* Per aggiungere segmenti, è possibile utilizzare i metodi sotto [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).  
* Utilizzando le proprietà [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) e [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/), è possibile impostare l'aspetto di un percorso geometrico.  
* Attraverso la proprietà [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/), è possibile recuperare il percorso geometrico di un [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) come array di segmenti di percorso.  
* Nelle versioni legacy che supportano i metodi di conversione seguenti, è possibile convertire [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) in [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).  
* Utilizzare i metodi [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) e [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (dalla classe [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) per convertire tra [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) e [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **Operazioni di modifica semplici**

Utilizzare i seguenti metodi per modificare un percorso geometrico. Le sovraccarichi che accettano un indice inseriscono un segmento in quella posizione a indice zero nell'array di segmenti del percorso.

| Operazione | Metodo |
| --- | --- |
| Aggiungere o inserire una linea retta. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Aggiungere o inserire una curva Bézier cubica con due punti di controllo e un punto finale. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Aggiungere o inserire una curva Bézier quadratica con un punto di controllo e un punto finale. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Aggiungere un arco ellittico con le dimensioni e gli angoli specificati in gradi. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Chiudere la figura corrente collegando il suo punto finale al punto iniziale. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Impostare il punto iniziale di una figura. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Rimuovere un segmento in una posizione a indice zero. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Aggiungere punti personalizzati a una forma**

Questo esempio inserisce due punti in una forma rettangolare usando [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) e applica il percorso modificato con [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). Le coordinate sono locali alla forma: entrambi i nuovi punti sono al suo centro, a 100 punti dal lato sinistro e 50 punti dalla parte superiore. Gli indici dei segmenti 1 e 4 li posizionano sui bordi superiore e inferiore, tirando quei bordi verso l'interno.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var geometryPath = shape.GetGeometryPaths()[0];
geometryPath.LineTo(100, 50, 1);
geometryPath.LineTo(100, 50, 4);

shape.SetGeometryPath(geometryPath);
```

![immagine_esempio1](custom_shape_1.png)

## **Rimuovere punti da una forma**

Questo esempio modifica il contorno di una forma a forma di cuore rimuovendo il segmento all'indice zero‑based 2 con [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). Applicare il percorso modificato con [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) aggiorna il contorno della forma.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![immagine_esempio2](custom_shape_2.png)

## **Creare una forma personalizzata**

Questo esempio costruisce una stella a cinque punte con [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). Raggi esterni e interni alternati di 100 e 50 punti definiscono le punte e le rientranze; un passo di 72 gradi distribuisce uniformemente le cinque punte. Il percorso è chiuso con [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) e applicato a una forma rettangolare usando [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), sostituendone il contorno.

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;

var points = new List<PointF>();

var outerRadius = 100f;
var innerRadius = 50f;
var angleStep = 72;

for (var angle = -90; angle < 270; angle += angleStep)
{
    var radians = angle * (Math.PI / 180f);
    var x = outerRadius * Math.Cos(radians);
    var y = outerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.Cos(radians);
    y = innerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));
}

var starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (var i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
shape.SetGeometryPath(starPath);
```
![immagine_esempio3](custom_shape_3.png)

## **Creare una forma composita personalizzata**

Questo esempio definisce due [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) chiusi per il terzo superiore e inferiore di una forma. Applicare entrambi i percorsi con [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) crea una singola forma composita con uno spazio al centro del terzo medio.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var topPath = new GeometryPath();
topPath.MoveTo(0, 0);
topPath.LineTo(shape.Width, 0);
topPath.LineTo(shape.Width, shape.Height / 3);
topPath.LineTo(0, shape.Height / 3);
topPath.CloseFigure();

var bottomPath = new GeometryPath();
bottomPath.MoveTo(shape.Height / 3 * 2, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![immagine_esempio4](custom_shape_4.png)

## **Creare una forma personalizzata con angoli curvi**

Questo esempio combina segmenti diritti con [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) per creare una forma con angoli curvi verso l'interno. Ogni dimensione dell'angolo imposta la larghezza e l'altezza dell'arco in punti, e il sweep di -90 gradi disegna un quarto di ellisse in senso antiorario. Il percorso completato è applicato con [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), e la presentazione è salvata in formato PPTX.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var topLeft = new PointF(leftTopSize, 0);
var topRight = new PointF(shapeWidth - rightTopSize, 0);
var rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
var bottomLeft = new PointF(leftBottomSize, shapeHeight);
var leftTop = new PointF(0, leftTopSize);

var geometryPath = new GeometryPath();
geometryPath.MoveTo(topLeft);
geometryPath.LineTo(topRight);
geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
geometryPath.LineTo(rightBottom);
geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
geometryPath.LineTo(bottomLeft);
geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
geometryPath.LineTo(leftTop);
geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);
geometryPath.CloseFigure();

var shape = slide.Shapes.AddAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
shape.SetGeometryPath(geometryPath);

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Verificare se la geometria di una forma è chiusa**

Il seguente helper verifica se ogni percorso geometrico non vuoto termina con un segmento di chiusura. Legge [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) e confronta il comando del segmento finale [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) con [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Restituisce false quando non ci sono percorsi non vuoti. Controlla il comando finale di ogni percorso; non esamina ogni sotto‑figura all'interno di un percorso. L'esempio stampa `True` per un rettangolo.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
Console.WriteLine(IsGeometryClosed(shape));

bool IsGeometryClosed(IGeometryShape geometryShape)
{
    var hasNonemptyPath = false;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var segments = geometryPath.PathData;
        if (segments.Length == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        var lastSegment = segments[segments.Length - 1];
        if (lastSegment.PathCommand != PathCommandType.Close)
        {
            return false;
        }
    }

    return hasNonemptyPath;
}
```

## **Estrarre e ispezionare gli elementi della forma**

Utilizzare [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) per ispezionare una forma esistente come elementi contenenti punti di percorso e tipi di punto. Convertire ogni [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) restituito in [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) per leggere le sue matrici [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) e [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/). Questa rappresentazione è utile per l'analisi del contorno o per passare la geometria a strumenti di disegno personalizzati.

L'esempio apre una presentazione, trova la prima forma geometrica nella prima diapositiva e stampa i suoi segmenti di percorso. Utilizzare una presentazione che contenga una forma con segmenti diritti e curvi per vedere entrambe le tipologie di output. Non ricerca all'interno dei gruppi.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.OfType<IGeometryShape>().FirstOrDefault();
if (shape == null)
{
    Console.WriteLine("No geometry shape found on the first slide.");
    return;
}

foreach (IShapeElement element in shape.CreateShapeElements())
{
    var shapeElement = (ShapeElement)element;
    var points = shapeElement.PathPoints;
    var types = shapeElement.PathTypes;
    Console.WriteLine("Shape element:");

    for (var i = 0; i < points.Length; i++)
    {
        var pointType = types[i] & 0x07; // Mantieni il tipo di segmento, escludendo i flag.
        switch (pointType)
        {
            case 0:
                Console.WriteLine($"Start figure at {points[i]}");
                break;
            case 1:
                Console.WriteLine($"Line to {points[i]}");
                break;
            case 3:
                Console.WriteLine($"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}");
                i += 2; // Consuma entrambi i punti di controllo e il punto finale.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

Le matrici corrispondono per indice: `points[i]` è un punto e `types[i]` descrive il suo ruolo. Il tipo `0` avvia una figura, e il tipo `1` disegna una linea dal punto precedente al punto corrente. Un segmento Bézier cubico inizia dal punto finale precedente e utilizza tre voci consecutive di tipo `3`: due punti di controllo seguiti dal nuovo punto finale. Il ciclo consuma queste tre voci insieme e verifica il punto finale per la chiusura.

I tipi di punto contengono anche flag. Applicare una maschera `0x07` per identificare il tipo di segmento e testare `0x80` separatamente per rilevare un sotto‑percorso chiuso. Ad esempio, `129` (`0x81`) indica un punto finale di linea che chiude un sotto‑percorso, e `131` (`0x83`) indica un punto finale Bézier che ne chiude uno. Confrontare il valore grezzo solo con `1` o `3` farebbe perdere questi casi. Altri flag, come quello di tratteggio (`0x10`) e quello di marcatore (`0x20`), non modificano il tipo base del segmento.

**Coordinate e trasformazioni.** I punti sono misurati in punti (1/72 di pollice), con X che aumenta verso destra e Y verso il basso. Per una forma non raggruppata, le coordinate estratte includono già la sua posizione [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) e [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) e riflettono la sua larghezza e altezza attuali. Ad esempio, un rettangolo non ruotato a `(100, 200)` con dimensioni `120 × 80` ha i limiti del contorno `(100, 200)`–`(220, 280)`. Non aggiungere nuovamente la posizione della forma. Sottrai X e Y per ottenere coordinate relative al suo riquadro non ruotato.

I punti estratti non applicano la proprietà [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) della forma né i ribaltamenti orizzontali e verticali. Per ricreare il contorno visualizzato, applicare tali trasformazioni attorno al centro della forma. Per forme raggruppate, tenere conto anche della mappatura delle coordinate del gruppo e delle trasformazioni; non presumere che i punti estratti siano le coordinate finali renderizzate della diapositiva né applicare una traslazione o scala doppia se già riflessa nel riquadro del figlio.

**Ispezione vs. modifica.** Le matrici estratte descrivono il contorno; modificarle non aggiorna la forma originale. Scegliere questo approccio quando l'analisi o il codice di disegno ha bisogno di array di punti/tipi. Utilizzare [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) quando servono i comandi di geometria nel sistema di coordinate locale della forma o quando si vuole modificare la geometria. Applicare i percorsi modificati tramite [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) o [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **Convertire GeometryPath in GraphicsPath (System.Drawing.Drawing2D)**

L'esempio seguente richiede un'assembly legacy di Aspose.Slides for .NET che supporti [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/), ad esempio la versione 25.10, e un ambiente Windows con `System.Drawing.Common`. I metodi di conversione sono stati rimossi nella [versione 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

Questo esempio combina un contorno rettangolare con testo convertito in geometria. Il [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) del contorno è impostato per disabilitare il riempimento. Un [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) memorizza il contorno del testo, che [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) converte in un percorso geometrico riempito. Applicare entrambi i percorsi con [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) produce una singola forma contenente rettangolo e testo. Per la conversione nella direzione opposta, usare [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

```csharp
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

var originalPath = shape.GetGeometryPaths()[0];
originalPath.FillMode = PathFillModeType.None;

using var graphicsPath = new GraphicsPath();
using var fontFamily = new FontFamily("Arial");
using var stringFormat = StringFormat.GenericDefault;

graphicsPath.AddString("Text in shape", fontFamily, (int)FontStyle.Bold, 40, new PointF(10, 10), stringFormat);

var textPath = ShapeUtil.GraphicsPathToGeometryPath(graphicsPath);
textPath.FillMode = PathFillModeType.Normal;

shape.SetGeometryPaths(new[] { originalPath, textPath });
```
![immagine_esempio5](custom_shape_5.png)

## **FAQ**

**Cosa accade al riempimento e al contorno dopo aver sostituito la geometria?**

Lo stile rimane associato alla forma; solo il contorno cambia. Il riempimento e il contorno vengono applicati automaticamente alla nuova geometria.

**Come ruoto correttamente una forma personalizzata insieme alla sua geometria?**

Utilizzare la proprietà [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) della forma; la geometria ruota con la forma perché è legata al sistema di coordinate della forma stessa.

**Posso convertire una forma personalizzata in un'immagine per “bloccare” il risultato?**

Sì. Esportare l'area della [slide](/slides/it/net/convert-powerpoint-to-png/) o la [forma](/slides/it/net/create-shape-thumbnails/) stessa in formato raster; ciò semplifica ulteriori lavori con geometrie complesse.