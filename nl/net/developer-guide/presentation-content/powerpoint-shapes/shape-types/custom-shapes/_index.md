---
title: Aangepaste presentatievormen in .NET
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
- geometriepad
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
description: "Maak en pas vormen aan in PowerPoint‑presentaties met Aspose.Slides voor .NET: geometrie‑paden, afgeronde hoeken, samengestelde vormen."
---
## **Overzicht**

Dit artikel legt uit hoe je presentatie‑vormen in Aspose.Slides kunt aanpassen door de geometrie van een vorm te bewerken via bewerkingspunten en geometrie‑paden. Het laat zien hoe je werkt met [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) en [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) om bestaande vormen te wijzigen, basisbewerkingsbewerkingen uit te voeren, punten toe te voegen of te verwijderen, en de bijgewerkte geometrie terug toe te passen op een vorm.

Het toont ook hoe je aangepaste en samengestelde vormen maakt, vormen met afgeronde hoeken bouwt, bepaalt of een vormgeometrie gesloten is, en de legacy‑conversie tussen [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) en [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) gebruikt voor extra scenario’s voor geometrie‑aanpassing.

## **Een vorm wijzigen met bewerkingspunten**

In PowerPoint kun je **bewerkingspunten** gebruiken om een vierkant te wijzigen:

* Een hoek naar binnen of buiten verplaatsen.
* De kromming op een punt aanpassen.
* Nieuwe punten toevoegen.

Bewerkingspunten laten je de omtrek van een vorm aanpassen of een bestaande vorm als basis gebruiken voor een nieuwe.

## **Tips voor vormbewerking**

![overzicht_afbeelding](custom_shape_0.png)

Houd bij het bewerken van PowerPoint‑vormen de volgende concepten in gedachten:

* Een vorm (of het pad ervan) kan gesloten of open zijn.
* Het pad van een vorm bestaat uit ankerpunten die door segmenten met elkaar verbonden zijn.
* Een segment kan recht of gekromd zijn. Ankerpunten en controlehandvatten bepalen de vorm ervan.
* Ankerpunten bestaan als hoekpunten, rechte punten of vloeiende punten:
  * Bij een hoekpunt kunnen aangrenzende segmenten onder een hoek samenkomen.
  * Bij een vloeiend punt zijn de twee controlehandvatten uitgelijnd en op gelijke afstand van het ankerpunt.
  * Bij een recht punt zijn de twee controlehandvatten uitgelijnd maar kunnen ze verschillende afstanden tot het ankerpunt hebben.
* Het verplaatsen van ankerpunten of het aanpassen van hun handvatten verandert de omtrek van de vorm.

Om PowerPoint‑vormen via bewerkingspunten te bewerken, biedt **Aspose.Slides** de klasse [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) en de interface [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* Een [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)‑instantie vertegenwoordigt een geometriepad van het object [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* Om het [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) van een [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/)‑instantie op te halen, kun je de methode [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) gebruiken.
* Om het [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) voor een vorm in te stellen, kun je deze methoden gebruiken: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) voor vormen met één pad en [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) voor vormen met meerdere paden.
* Om segmenten toe te voegen, kun je de methoden onder [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) gebruiken.
* Met de eigenschappen [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) en [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) kun je het uiterlijk van een geometriepad instellen.
* Met de eigenschap [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) kun je het geometriepad van een [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) ophalen als een matrix van padsegmenten.
* In legacy‑versies die de onderstaande conversiemethoden ondersteunen, kun je [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) omzetten naar [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* Gebruik de methoden [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) en [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (van de klasse [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) om te converteren tussen [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) en [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **Eenvoudige bewerkingsbewerkingen**

Gebruik de volgende methoden om een geometriepad te bewerken. Overloads die een index accepteren, voegen een segment in op die nul‑gebaseerde positie in de segmentmatrix van het pad.

| Bewerking | Methode |
| --- | --- |
| Een rechte lijn toevoegen of invoegen. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Een kubieke Bézier‑curve met twee controlepunten en een eindpunt toevoegen of invoegen. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Een kwadratische Bézier‑curve met één controlepunt en een eindpunt toevoegen of invoegen. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Een elliptische boog toevoegen met de opgegeven afmetingen en hoeken in graden. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| De huidige figuur sluiten door het eindpunt met het startpunt te verbinden. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Het startpunt van een figuur instellen. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Een segment op een nul‑gebaseerde index verwijderen. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Aangepaste punten toevoegen aan een vorm**

Dit voorbeeld voegt twee punten toe aan een rechthoekige vorm met behulp van [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) en past het bewerkte pad toe met [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). De coördinaten zijn lokaal ten opzichte van de vorm: beide nieuwe punten bevinden zich in het midden, 100 punten van de linkerkant en 50 punten van de bovenkant. Segment‑indices 1 en 4 plaatsen ze respectievelijk op de boven‑ en onderrand, waardoor die randen naar binnen worden getrokken.

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

![voorbeeld1_afbeelding](custom_shape_1.png)

## **Punten verwijderen uit een vorm**

Dit voorbeeld wijzigt de omtrek van een hartvorm door het segment op nul‑gebaseerde index 2 te verwijderen met [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). Het toepassen van het gewijzigde pad met [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) werkt de contour van de vorm bij.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![voorbeeld2_afbeelding](custom_shape_2.png)

## **Aangepaste vorm maken**

Dit voorbeeld bouwt een vijfpuntige ster met [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). Afwisselend buiten‑ en binnenstraal van respectievelijk 100 en 50 punten definiëren de punten en inkepingen; een stap van 72 graden verdeelt de vijf punten gelijkmatig. Het pad wordt gesloten met [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) en toegepast op een rechthoekige vorm met [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), waardoor de oorspronkelijke omtrek wordt vervangen.

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
![voorbeeld3_afbeelding](custom_shape_3.png)

## **Samengestelde aangepaste vorm maken**

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
![voorbeeld4_afbeelding](custom_shape_4.png)

## **Aangepaste vorm maken met afgeronde hoeken**

Dit voorbeeld combineert rechte segmenten met [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) om een vorm met naar binnen geronde hoeken te creëren. De grootte van elke hoek bepaalt de breedte en hoogte van de boog in punten, en de sweep van –90 graden tekent een tegen de klok in draaiende kwart‑ellips. Het volledige pad wordt toegepast met [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), en de presentatie wordt opgeslagen in PPTX‑formaat.

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

## **Nagaan of een vormgeometrie gesloten is**

De volgende helper controleert of elke niet‑lege geometriepad eindigt met een sluitingssegment. Hij leest [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) en vergelijkt het laatste segment‑commando met [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) tegen [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Hij retourneert false wanneer er geen niet‑lege paden zijn. Deze controle kijkt alleen naar het laatste commando van elk pad; hij inspecteert niet elk sub‑figure binnen een pad. Het voorbeeld schrijft `True` voor een rechthoek.

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

## **Vormelementen extraheren en inspecteren**

Gebruik [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) om een bestaande vorm te inspecteren als elementen die padpunten en punt‑types bevatten. Cast elk geretourneerd [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) naar [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) om zijn [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) en [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/) matrices te lezen. Deze representatie is nuttig voor contouranalyse of om geometrie door te geven aan aangepaste tekengereedschappen.

Het voorbeeld opent een presentatie, vindt de eerste geometrische vorm direct op de eerste dia, en drukt de padsegmenten af. Gebruik een presentatie met een vorm die rechte en gekromde segmenten bevat om beide soorten output te zien. Er wordt niet gezocht binnen groepen.

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
        var pointType = types[i] & 0x07; // Houd het segmenttype, exclusief vlaggen.
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
                i += 2; // Consume both control points and the endpoint.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

De matrices corresponderen per index: `points[i]` is een punt en `types[i]` beschrijft de rol ervan. Type `0` start een figure, en type `1` tekent een lijn van het vorige punt naar het huidige punt. Een kubisch Bézier‑segment start bij het vorige eindpunt en gebruikt drie opeenvolgende type‑`3` items: twee controlepunten gevolgd door het nieuwe eindpunt. De lus verwerkt deze drie items samen en controleert of het eindpunt gesloten is.

Punt‑types bevatten ook vlaggen. Maskeer met `0x07` om het segmenttype te identificeren, en test `0x80` apart om een gesloten sub‑pad te detecteren. Bijvoorbeeld, `129` (`0x81`) betekent een lijn‑eindpunt dat een sub‑pad sluit, en `131` (`0x83`) betekent een Bézier‑eindpunt dat een sub‑pad sluit. Alleen vergelijken met `1` of `3` zou deze gevallen missen. Andere vlaggen, zoals dash (`0x10`) en marker (`0x20`), wijzigen het basis‑segmenttype niet.

**Coördinaten en transformaties.** Punten worden gemeten in points (1/72 inch), waarbij X naar rechts toeneemt en Y naar beneden. Voor een niet‑gegroepeerde vorm omvatten de geëxtraheerde coördinaten al diens [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/)‑ en [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/)‑positie en weerspiegelen ze de huidige breedte en hoogte. Bijvoorbeeld, een niet‑gedraaide rechthoek op `(100, 200)` met afmeting `120 × 80` heeft contourgrenzen `(100, 200)`–`(220, 280)`. Voeg de positie van de vorm niet nogmaals toe. Trek X en Y af om coördinaten relatief tot het ongeroteerde frame te krijgen.

De geëxtraheerde punten passen de [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) of horizontale en verticale flips van de vorm niet toe. Om de weergegeven contour te reproduceren, pas die transformaties toe rond het middelpunt van de vorm. Voor gegroepeerde vormen moet ook rekening worden gehouden met de coördinaten‑mapping en transformaties van de groep; ga er niet van uit dat de geëxtraheerde punten de definitieve slide‑coördinaten zijn of dat je een translatie of schaal twee keer toepast als dat al in het child‑frame is verwerkt.

**Inspectie versus bewerking.** Geëxtraheerde matrices beschrijven de contour; veranderen ervan werkt het origineel niet bij. Kies deze aanpak wanneer je analyse‑ of tekengereedschap punt‑/type‑arrays nodig heeft. Gebruik [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) als je geometrie‑commando’s in het lokale coördinatensysteem van de vorm wilt of de geometrie wilt bewerken. Pas bijgewerkte paden toe via [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) of [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **GeometryPath omzetten naar GraphicsPath (System.Drawing.Drawing2D)**

Het volgende voorbeeld vereist een legacy‑assembly van Aspose.Slides for .NET die [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) ondersteunt, zoals versie 25.10, en een Windows‑omgeving met `System.Drawing.Common`. De conversiemethoden werden verwijderd in [versie 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

Dit voorbeeld combineert een rechthoekige omtrek met tekst die is omgezet naar geometrie. De [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) van de omtrek wordt ingesteld op uitschakelen van de vulling. Een [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) slaat de tekstomtrek op, die [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) omzet naar een gevulde geometriepad. Het toepassen van beide paden met [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) levert één vorm op die zowel de rechthoek als de tekst bevat. Voor conversie in de tegenovergestelde richting gebruik je [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

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
![voorbeeld5_afbeelding](custom_shape_5.png)

## **Veelgestelde vragen**

**Wat gebeurt er met de vulling en de omtrek na het vervangen van de geometrie?**

De stijl blijft gekoppeld aan de vorm; alleen de contour verandert. Vulling en omtrek worden automatisch toegepast op de nieuwe geometrie.

**Hoe roteer ik een aangepaste vorm correct samen met zijn geometrie?**

Gebruik de eigenschap [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) van de vorm; de geometrie roteert mee omdat deze gebonden is aan het eigen coördinatensysteem van de vorm.

**Kan ik een aangepaste vorm omzetten naar een afbeelding om het resultaat „vast te leggen“?**

Ja. Exporteer het gewenste [slide](/slides/nl/net/convert-powerpoint-to-png/)-gebied of de [shape](/slides/nl/net/create-shape-thumbnails/) zelf naar een rasterformaat; dat vereenvoudigt verdere bewerkingen met complexe geometrieën.