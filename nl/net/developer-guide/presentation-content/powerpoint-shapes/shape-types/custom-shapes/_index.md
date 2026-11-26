---
title: Presentatievormen aanpassen in .NET
linktitle: Aangepaste vorm
type: docs
weight: 20
url: /nl/net/custom-shape/
keywords:
- aangepaste vorm
- vorm toevoegen
- vorm maken
- vorm wijzigen
- vormgeometrie
- geometrisch pad
- padpunten
- bewerkingspunten
- punt toevoegen
- punt verwijderen
- bewerkingsoperatie
- afgeronde hoek
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak en pas vormen aan in PowerPoint-presentaties met Aspose.Slides voor .NET: geometrische paden, afgeronde hoeken, samengestelde vormen."
---
## **Overzicht**

Dit artikel legt uit hoe je presenteervormen in Aspose.Slides kunt aanpassen door de geometrie van een vorm te bewerken via bewerkingspunten en geometrische paden. Het laat zien hoe je werkt met [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) en [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) om bestaande vormen te wijzigen, basisbewerkingsbewerkingen op paden uit te voeren, punten toe te voegen of te verwijderen, en de bijgewerkte geometrie terug op een vorm toe te passen.

Het laat ook zien hoe je aangepaste en samengestelde vormen maakt, vormen met afgeronde hoeken bouwt, bepaalt of een vormgeometrie gesloten is, en de legacy‑conversie tussen [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) en [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) gebruikt voor extra geometrie‑aanpassingsscenario's.

## **Vorm wijzigen met bewerkingspunten**

In PowerPoint kun je **Bewerkingspunten** gebruiken om een vierkant aan te passen:

* Verplaats een hoek naar binnen of naar buiten.
* Pas de kromming op een punt aan.
* Voeg nieuwe punten toe.

Door punten te bewerken kun je de omtrek van een vorm aanpassen of een bestaande vorm als basis voor een nieuwe gebruiken.

## **Tips voor het bewerken van vormen**

![overview_image](custom_shape_0.png)

Houd bij het bewerken van PowerPoint‑vormen de volgende concepten in gedachten:

* Een vorm (of het pad ervan) kan gesloten of open zijn.
* Het pad van een vorm bestaat uit ankerpunten die door segmenten verbonden zijn.
* Een segment kan recht of gebogen zijn. Ankerpunten en controlehandvatten bepalen de vorm.
* Ankerpunten bestaan als hoekpunten, rechte punten of vloeiende punten:
  * Bij een hoekpunt kunnen aangrenzende segmenten onder een hoek samenkomen.
  * Bij een vloeiend punt zijn de twee controlehandvatten uitgelijnd en op gelijke afstand van het ankerpunt.
  * Bij een recht punt zijn de twee controlehandvatten uitgelijnd, maar kunnen ze verschillende afstanden van het ankerpunt hebben.
* Het verplaatsen van ankerpunten of het aanpassen van hun handvatten verandert de omtrek van de vorm.

Om PowerPoint‑vormen te bewerken via bewerkingspunten, **Aspose.Slides** biedt de [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)‑klasse en de [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/)‑interface.

* Een [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)‑instantie vertegenwoordigt een geometrisch pad van het [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/)‑object.
* Om de [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) uit de [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/)‑instantie op te halen, kun je de methode [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) gebruiken.
* Om de [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) voor een vorm in te stellen, kun je deze methoden gebruiken: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) voor vormen met één enkel pad en [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) voor vormen met meerdere paden.
* Om segmenten toe te voegen, kun je de methoden onder [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) gebruiken.
* Met de eigenschappen [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) en [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) kun je het uiterlijk van een geometrisch pad instellen.
* Met de eigenschap [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) kun je het geometrische pad van een [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) ophalen als een array van padsegmenten.
* In legacy‑versies die de onderstaande conversiemethoden ondersteunen, kun je [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) naar [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) converteren.
* Gebruik de methoden [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) en [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (van de [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)‑klasse) om te converteren tussen [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) en [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **Eenvoudige bewerkingsbewerkingen**

Gebruik de volgende methoden om een geometrisch pad te bewerken. Overloads die een index accepteren voegen een segment in op die nulgebaseerde positie in de segmentarray van het pad.

| Operatie | Methode |
| --- | --- |
| Voeg een rechte lijn toe of voeg deze in. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Voeg een kubieke Bézier‑curve toe of voeg deze in met twee controlepunten en een eindpunt. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Voeg een kwadratische Bézier‑curve toe of voeg deze in met één controlepunt en een eindpunt. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Voeg een elliptische boog toe met de opgegeven afmetingen en hoeken in graden. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Sluit de huidige figuur door het eindpunt met het beginpunt te verbinden. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Stel het startpunt van een figuur in. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Verwijder een segment op een nulgebaseerde index. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Aangepaste punten toevoegen aan een vorm**

Dit voorbeeld voegt twee punten toe aan een rechthoekige vorm met behulp van [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) en past het bewerkte pad toe met [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). De coördinaten zijn lokaal ten opzichte van de vorm: beide nieuwe punten bevinden zich in het midden, 100 punten van links en 50 punten van boven. Segmentindexen 1 en 4 plaatsen ze respectievelijk op de boven‑ en onderrand, waardoor die randen naar binnen worden getrokken.

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

## **Punten verwijderen uit een vorm**

Dit voorbeeld wijzigt de omtrek van een hartvorm door het segment op nulgebaseerde index 2 te verwijderen met [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). Het toepassen van het aangepaste pad met [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) werkt de contour van de vorm bij.

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

## **Een aangepaste vorm maken**

Dit voorbeeld bouwt een vijfpuntige ster met [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). Afwisselend buiten‑ en binnenstraal van respectievelijk 100 en 50 punten definiëren de punten en inkepingen; een stap van 72 graden verdeelt de vijf punten gelijkmatig. Het pad wordt afgesloten met [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) en toegepast op een rechthoekige vorm met [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), waarmee de oude omtrek wordt vervangen.

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

## **Een samengestelde aangepaste vorm maken**

Dit voorbeeld definieert twee gesloten [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)‑objecten voor respectievelijk het boven‑ en onderste derde deel van een vorm. Het toepassen van beide paden met [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) creëert één samengestelde vorm met een opening over het middelste derde deel.

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
bottomPath.MoveTo(0, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![example4_image](custom_shape_4.png)

## **Een aangepaste vorm met afgeronde hoeken maken**

Dit voorbeeld combineert rechte segmenten met [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) om een vorm met naar binnen gerichte afgeronde hoeken te maken. Elke hoekgrootte bepaalt de breedte en hoogte van de boog in punten, en de -90‑graden sweep tekent een tegen de klok in draaiende kwart‑ellips. Het voltooide pad wordt toegepast met [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), en de presentatie wordt opgeslagen in PPTX‑formaat.

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

## **Controleren of een vormgeometrie gesloten is**

De onderstaande helper controleert of elk niet‑leeg geometrisch pad eindigt met een sluitingssegment. Hij leest [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) en vergelijkt het laatste segment‑[IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) met [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Hij retourneert false wanneer er geen niet‑lege paden zijn. Deze controle kijkt alleen naar het laatste commando van elk pad; hij inspecteert niet elke subfiguur binnen een pad. Het voorbeeld print `True` voor een rechthoek.

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

## **Geometrie‑padcommando's inspecteren**

Download [contour.pptx](contour.pptx) en plaats dit in de werkmap van de toepassing. De eerste dia bevat een vorm met een rechte bovenrand, een kubieke Bézier‑curve en een rechte sluitingsrand. Gebruik [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) om de paden te lezen. Elk pad somt zijn segmenten op in tekenvolgorde in [PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/). Het [PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) van elk segment bepaalt hoe het [SegmentData](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/segmentdata/) gelezen moet worden.

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

De vorm bevindt zich op (200, 100) punten op de dia. De gerapporteerde punten zijn lokaal ten opzichte van de vorm, met (0, 0) in de linkerbovenhoek, x neemt toe naar rechts en y neemt toe naar beneden. Het sluitingssegment keert terug naar het startpunt zonder extra coördinaten.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Vormelementen extraheren en inspecteren**

Gebruik [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) om een bestaande vorm te inspecteren als elementen die padpunten en punt‑types bevatten. Cast elk teruggegeven [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) naar [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) om de [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/)‑ en [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/)‑arrays te lezen. Deze representatie is nuttig voor contouranalyse of om geometrie door te geven aan aangepaste teken‑tools.

Het voorbeeld opent een presentatie, zoekt de eerste geometrische vorm direct op de eerste dia, en print de padsegmenten. Gebruik een presentatie die een vorm met rechte en gebogen segmenten bevat om beide soorten uitvoer te zien. Het zoekt niet binnen groepen.

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
        var pointType = types[i] & 0x07; // Behoud het segmenttype, exclusief vlaggen.
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
                i += 2; // Verwerk beide controlepunten en het eindpunt.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

De arrays corresponderen per index: `points[i]` is een punt en `types[i]` beschrijft de rol ervan. Type `0` start een figuur, en type `1` tekent een lijn van het vorige punt naar het huidige punt. Een kubiek Bézier‑segment start bij het vorige eindpunt en gebruikt drie opeenvolgende type‑`3`‑waarden: twee controlepunten gevolgd door het nieuwe eindpunt. De lus verwerkt deze drie waarden gezamenlijk en controleert het eindpunt op sluiting.

Punt‑types bevatten ook vlaggen. Maskeer met `0x07` om het segmenttype te identificeren, en test `0x80` apart om een gesloten subpad te detecteren. Bijvoorbeeld, `129` (`0x81`) betekent een lijneindpunt die een subpad sluit, en `131` (`0x83`) betekent een Bézier‑eindpunt dat een subpad sluit. Alleen vergelijken met `1` of `3` zou deze gevallen missen. Andere vlaggen, zoals streep (`0x10`) en markering (`0x20`), wijzigen het basissegmenttype niet.

**Coördinaten en transformaties.** Punten worden gemeten in points (1/72 inch), waarbij X toeneemt naar rechts en Y toeneemt naar beneden. Voor een niet‑gegroepeerde vorm zijn de geëxtraheerde coördinaten al inclusief haar [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/)‑ en [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/)‑positie en weerspiegelen ze de huidige breedte en hoogte. Een ongeroteerde rechthoek op `(100, 200)` met afmeting `120 × 80` heeft contourgrenzen `(100, 200)`–`(220, 280)`. Voeg de positie van de vorm niet opnieuw toe. Trek haar X en Y af om coördinaten ten opzichte van het ongeroteerde kader te verkrijgen.

De geëxtraheerde punten houden geen rekening met de [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) van de vorm of met horizontale en verticale spiegels. Om de weergegeven contour te reproduceren, moet je die transformaties rond het middelpunt van de vorm toepassen. Voor gegroepeerde vormen moet je bovendien rekening houden met de coördinatenmapping en transformaties van de groep; ga er niet van uit dat de geëxtraheerde punten de definitieve weergave‑dia‑coördinaten zijn of dat je een translatie of schaal dubbel moet toepassen als deze al in het kind‑kader is verwerkt.

**Inspectie versus bewerking.** De geëxtraheerde arrays beschrijven de contour; het wijzigen ervan werkt de oorspronkelijke vorm niet bij. Gebruik deze aanpak wanneer je analyse‑ of teken‑code punt‑/type‑arrays nodig heeft. Gebruik [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) wanneer je geometrische commando’s in het lokale coördinatensysteem van de vorm nodig hebt of de geometrie wilt bewerken. Pas bewerkte paden toe via [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) of [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **GeometryPath omzetten naar GraphicsPath (System.Drawing.Drawing2D)**

Het volgende voorbeeld vereist een legacy‑Aspose.Slides‑for‑.NET‑assembly die [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) ondersteunt, bijvoorbeeld versie 25.10, en een Windows‑omgeving met `System.Drawing.Common`. De conversiemethoden zijn verwijderd in [version 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

Dit voorbeeld combineert een rechthoekige omtrek met tekst die naar geometrie is geconverteerd. De omtrek‑[IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) wordt ingesteld om de vulling uit te schakelen. Een [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) slaat de tekstopmaak op, die [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) converteert naar een gevulde geometrische pad. Het toepassen van beide paden met [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) produceert één vorm die zowel de rechthoek als de tekst bevat. Voor conversie in de tegenovergestelde richting, gebruik [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

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

**Wat gebeurt er met de opvulling en de omtrek na het vervangen van de geometrie?**

De stijl blijft bij de vorm; alleen de omtrek verandert. De opvulling en de omtrek worden automatisch toegepast op de nieuwe geometrie.

**Hoe roteer ik een aangepaste vorm correct samen met de geometrie?**

Gebruik de eigenschap [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) van de vorm; de geometrie roteert mee omdat deze gebonden is aan het eigen coördinatensysteem van de vorm.

**Kan ik een aangepaste vorm converteren naar een afbeelding om het resultaat te “vergrendelen”?**

Ja. Exporteer het benodigde [dia](/slides/nl/net/convert-powerpoint-to-png/)‑gebied of de [vorm](/slides/nl/net/create-shape-thumbnails/) zelf naar een rasterformaat; dit vereenvoudigt verdere bewerking met complexe geometrieën.