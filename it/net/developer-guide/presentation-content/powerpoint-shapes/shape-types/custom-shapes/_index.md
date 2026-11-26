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
description: "Crea e personalizza forme nelle presentazioni PowerPoint con Aspose.Slides per .NET: percorsi geometrici, angoli curvi, forme composite."
---
## **Panoramica**

Questo articolo spiega come personalizzare le forme di presentazione in Aspose.Slides modificando la geometria della forma tramite punti di modifica e percorsi geometrici. Mostra come utilizzare [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) e [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) per modificare forme esistenti, eseguire operazioni di modifica di base del percorso, aggiungere o rimuovere punti e applicare la geometria aggiornata a una forma.

Dimostra inoltre come creare forme personalizzate e composite, costruire forme con angoli curvi, determinare se la geometria di una forma è chiusa e utilizzare la conversione legacy tra [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) e [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) per scenari aggiuntivi di personalizzazione della geometria.

## **Modifica una Forma Usando i Punti di Modifica**

In PowerPoint, puoi utilizzare **Edit Points** per modificare un quadrato:

* Spostare un angolo verso l’interno o verso l’esterno.
* Regolare la curvatura in un punto.
* Aggiungere nuovi punti.

Modificare i punti consente di cambiare il contorno di una forma o di utilizzare una forma esistente come base per una nuova.

## **Suggerimenti per la Modifica delle Forme**

![overview_image](custom_shape_0.png)

Durante la modifica delle forme in PowerPoint, tieni presenti questi concetti:

* Una forma (o il suo percorso) può essere chiusa o aperta.
* Il percorso di una forma è costituito da punti di ancoraggio collegati da segmenti.
* Un segmento può essere lineare o curvo. I punti di ancoraggio e le maniglie di controllo determinano la sua forma.
* I punti di ancoraggio esistono come punti angolo, punti lineari o punti lisci:
  * In un punto angolo, i segmenti adiacenti possono incontrarsi con un angolo.
  * In un punto liscio, le due maniglie di controllo sono allineate e alla stessa distanza dal punto di ancoraggio.
  * In un punto lineare, le due maniglie di controllo sono allineate ma possono essere a distanze diverse dal punto di ancoraggio.
* Spostare i punti di ancoraggio o regolare le loro maniglie modifica il contorno della forma.

Per modificare le forme di PowerPoint tramite i punti di modifica, **Aspose.Slides** fornisce la classe [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) e l’interfaccia [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* Un’istanza di [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) rappresenta un percorso geometrico dell’oggetto [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* Per recuperare il [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) da un’istanza di [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/), puoi usare il metodo [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).
* Per impostare il [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) su una forma, puoi usare questi metodi: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) per forme con un singolo percorso e [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) per forme con percorsi multipli.
* Per aggiungere segmenti, puoi usare i metodi sotto [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* Utilizzando le proprietà [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) e [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/), puoi impostare l’aspetto di un percorso geometrico.
* Attraverso la proprietà [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/), puoi recuperare il percorso geometrico di un [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) come array di segmenti di percorso.
* Nelle versioni legacy che supportano i metodi di conversione seguenti, puoi convertire [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) in [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* Usa i metodi [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) e [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (dalla classe [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) per convertire tra [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) e [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **Operazioni di Modifica Semplici**

Utilizza i seguenti metodi per modificare un percorso geometrico. Le overload che accettano un indice inseriscono un segmento in quella posizione a base zero nell’array dei segmenti del percorso.

| Operazione | Metodo |
| --- | --- |
| Aggiungere o inserire una linea retta. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Aggiungere o inserire una curva Bézier cubica con due punti di controllo e un punto finale. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Aggiungere o inserire una curva Bézier quadratica con un punto di controllo e un punto finale. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Aggiungere un arco ellittico con le dimensioni e gli angoli specificati in gradi. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Chiudere la figura corrente collegando il punto finale a quello iniziale. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Impostare il punto di partenza di una figura. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Rimuovere un segmento in base a un indice a base zero. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Aggiungi Punti Personalizzati a una Forma**

Questo esempio inserisce due punti in una forma rettangolare usando [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) e applica il percorso modificato con [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). Le coordinate sono locali alla forma: entrambi i nuovi punti si trovano al suo centro, 100 punti da sinistra e 50 punti dall’alto. Gli indici di segmento 1 e 4 li posizionano sui bordi superiore e inferiore, tirando questi bordi verso l’interno.

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

![example1_image](custom_shape_1.png)

## **Rimuovi Punti da una Forma**

Questo esempio modifica il contorno di una forma a cuore rimuovendo il segmento all’indice zero‑based 2 con [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). L’applicazione del percorso modificato con [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) aggiorna il contorno della forma.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Crea una Forma Personalizzata**

Questo esempio costruisce una stella a cinque punte con [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). I raggi esterni e interni alternati di 100 e 50 punti definiscono le punte e le rientranze; un passo di 72 gradi distribuisce uniformemente le cinque punte. Il percorso è chiuso con [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) e applicato a una forma rettangolare usando [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), sostituendone il contorno.

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
![example3_image](custom_shape_3.png)

## **Crea una Forma Personalizzata Composita**

Questo esempio definisce due [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) chiusi per il terzo superiore e inferiore di una forma. L’applicazione di entrambi i percorsi con [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) crea una singola forma composita con un’apertura nella sua terza centrale.

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
bottomPath.MoveTo(shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![example4_image](custom_shape_4.png)

## **Crea una Forma Personalizzata con Angoli Curvi**

Questo esempio combina segmenti lineari con [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) per creare una forma con angoli curvi verso l’interno. La dimensione di ciascun angolo imposta la larghezza e l’altezza dell’arco in punti, e il sweep di –90 gradi traccia un quarto di ellisse in senso antiorario. Il percorso completato è applicato con [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), e la presentazione è salvata in formato PPTX.

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

## **Scopri Se la Geometria di una Forma è Chiusa**

Il seguente ausiliario verifica se ogni percorso geometrico non vuoto termina con un segmento di chiusura. Legge [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) e confronta il comando [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) dell’ultimo segmento con [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Restituisce false quando non ci sono percorsi non vuoti. Questo controlla il comando finale di ciascun percorso; non ispeziona ogni sotto‑figura all’interno di un percorso. L’esempio stampa `True` per un rettangolo.

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

## **Ispeziona i Comandi del Percorso Geometrico**

Scarica [contour.pptx](contour.pptx) e posizionalo nella directory di lavoro dell’applicazione. La prima diapositiva contiene una forma con un bordo superiore lineare, una curva Bézier cubica e un bordo di chiusura lineare. Usa [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) per leggere i suoi percorsi. Ogni percorso elenca i suoi segmenti nell’ordine di disegno in [PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/). Il [PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) di ciascun segmento determina come leggere il relativo [SegmentData](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/segmentdata/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("contour.pptx");

var shape = (IGeometryShape)presentation.Slides[0].Shapes[0];
var paths = shape.GetGeometryPaths();

for (int i = 0; i < paths.Length; i++)
{
    var segments = paths[i].PathData;
    for (int j = 0; j < segments.Length; j++)
    {
        var command = segments[j].PathCommand;
        var data = segments[j].SegmentData;
        var detail = command switch
        {
            PathCommandType.MoveTo or PathCommandType.LineTo => $"destination=({data[0]}, {data[1]})",
            PathCommandType.CubicBezierTo => $"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})",
            PathCommandType.Close => "no coordinates",
            _ => $"raw=[{string.Join(", ", data)}]"
        };
        Console.WriteLine($"Path {i}, segment {j}: {command} {detail}");
    }
}
```

La forma si trova a (200, 100) punti nella diapositiva. I punti riportati sono locali alla forma, con (0, 0) nell’angolo in alto a sinistra, x che cresce verso destra e y che cresce verso il basso. Il segmento di chiusura ritorna al punto iniziale senza coordinate aggiuntive.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Estrai e Ispeziona gli Elementi della Forma**

Usa [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) per ispezionare una forma esistente come elementi contenenti punti di percorso e tipi di punto. Converti ogni [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) restituito in [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) per leggere le sue matrici [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) e [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/). Questa rappresentazione è utile per l’analisi dei contorni o per passare la geometria a strumenti di disegno personalizzati.

L’esempio apre una presentazione, trova la prima forma geometrica direttamente sulla prima diapositiva e stampa i suoi segmenti di percorso. Usa una presentazione contenente una forma con segmenti lineari e curvi per vedere entrambi i tipi di output. Non ricerca all’interno dei gruppi.

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

Le matrici corrispondono per indice: `points[i]` è un punto e `types[i]` descrive il suo ruolo. Il tipo `0` avvia una figura, il tipo `1` traccia una linea dal punto precedente al punto corrente. Un segmento Bézier cubico parte dal punto finale precedente e utilizza tre voci consecutive di tipo `3`: due punti di controllo seguiti dal nuovo punto finale. Il ciclo consuma queste tre voci insieme e verifica il punto finale per la chiusura.

I tipi di punto contengono anche flag. Maschera con `0x07` per identificare il tipo di segmento e testa `0x80` separatamente per rilevare un sotto‑percorso chiuso. Per esempio, `129` (`0x81`) indica un punto finale di linea che chiude un sotto‑percorso, e `131` (`0x83`) indica un punto finale di Bézier che chiude un sotto‑percorso. Confrontare il valore grezzo solo con `1` o `3` farebbe perdere questi casi. Altri flag, come quello del tratteggio (`0x10`) e del marcatore (`0x20`), non modificano il tipo base del segmento.

**Coordinate e trasformazioni.** I punti sono misurati in punti (1/72 di pollice), con X che aumenta verso destra e Y verso il basso. Per una forma non raggruppata, le coordinate estratte includono già le sue posizioni [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) e [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) e riflettono la sua larghezza e altezza attuali. Per esempio, un rettangolo non ruotato a `(100, 200)` con dimensioni `120 × 80` ha i limiti del contorno `(100, 200)`–`(220, 280)`. Non aggiungere nuovamente la posizione della forma. Sottrai X e Y per ottenere coordinate relative al suo frame non ruotato.

I punti estratti non applicano la [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) della forma né i ribaltamenti orizzontali e verticali. Per ricreare il contorno visualizzato, applica tali trasformazioni attorno al centro della forma. Per forme raggruppate, considera anche la mappatura delle coordinate del gruppo e le relative trasformazioni; non presumere che i punti estratti siano le coordinate finali renderizzate della diapositiva o applicare una traslazione o scala due volte se è già riflessa nel frame del figlio.

**Ispezione rispetto a modifica.** Gli array estratti descrivono il contorno; modificarli non aggiorna la forma originale. Usa questo approccio quando la tua analisi o il tuo codice di disegno richiedono array di punto/tipo. Usa [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) quando ti servono i comandi di geometria nel sistema di coordinate locale della forma o desideri modificare la sua geometria. Applica i percorsi modificati tramite [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) o [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **Converti GeometryPath in GraphicsPath (System.Drawing.Drawing2D)**

Il seguente esempio richiede un’assembly legacy di Aspose.Slides for .NET che supporti [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/), ad esempio la versione 25.10, e un ambiente Windows con `System.Drawing.Common`. I metodi di conversione sono stati rimossi nella [versione 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

Questo esempio combina un contorno rettangolare con testo convertito in geometria. Il [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) del contorno è impostato per disabilitarne il riempimento. Un [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) memorizza il contorno del testo, che [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) converte in un percorso geometrico riempito. L’applicazione di entrambi i percorsi con [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) produce una singola forma contenente il rettangolo e il testo. Per la conversione nella direzione opposta, usa [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

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
![example5_image](custom_shape_5.png)

## **FAQ**

**Cosa succederà al riempimento e al contorno dopo aver sostituito la geometria?**

Lo stile rimane associato alla forma; solo il contorno cambia. Il riempimento e il contorno vengono applicati automaticamente alla nuova geometria.

**Come ruoto correttamente una forma personalizzata insieme alla sua geometria?**

Utilizza la proprietà [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) della forma; la geometria ruota con la forma perché è legata al suo sistema di coordinate.

**Posso convertire una forma personalizzata in un’immagine per “bloccare” il risultato?**

Sì. Esporta l’[slide](/slides/it/net/convert-powerpoint-to-png/) o la [shape](/slides/it/net/create-shape-thumbnails/) desiderata in formato raster; questo semplifica il lavoro successivo con geometrie complesse.