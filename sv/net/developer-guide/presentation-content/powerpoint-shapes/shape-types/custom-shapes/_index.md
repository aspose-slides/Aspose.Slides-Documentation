---
title: Använda presentationsformer i .NET
linktitle: Anpassad form
type: docs
weight: 20
url: /sv/net/custom-shape/
keywords:
- anpassad form
- lägga till form
- skapa form
- ändra form
- formgeometri
- geometribana
- banpunkter
- redigera punkter
- lägga till punkt
- ta bort punkt
- redigeringsoperation
- kurvat hörn
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa och anpassa former i PowerPoint-presentationer med Aspose.Slides för .NET: geometribanor, kurvade hörn, sammansatta former."
---
## **Översikt**

Denna artikel förklarar hur du anpassar presentationsformer i Aspose.Slides genom att redigera formgeometri med hjälp av redigeringspunkter och geometriska banor. Den visar hur du arbetar med [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) och [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) för att ändra befintliga former, utföra grundläggande redigeringsoperationer, lägga till eller ta bort punkter och applicera den uppdaterade geometrin på en form.

Den demonstrerar också hur du skapar anpassade och sammansatta former, bygger former med rundade hörn, avgör om en formgeometri är sluten och använder den äldre konverteringen mellan [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) och [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) för ytterligare anpassningsscenarier.

## **Ändra en form med redigeringspunkter**

I PowerPoint kan du använda **Redigeringspunkter** för att modifiera en kvadrat:

* Flytta ett hörn inåt eller utåt.
* Justera kurvaturen vid en punkt.
* Lägg till nya punkter.

Redigering av punkter låter dig förändra en forms kontur eller använda en befintlig form som grund för en ny.

## **Tips för formredigering**

![översiktsbild](custom_shape_0.png)

När du redigerar PowerPoint‑former, håll dessa begrepp i åtanke:

* En form (eller dess bana) kan vara antingen sluten eller öppen.
* En forms bana består av ankarnpunkter som är förenade med segment.
* Ett segment kan vara rakt eller kurvat. Ankarnpunkter och kontrollhandtag bestämmer dess form.
* Ankarnpunkter finns som hörnpunkter, raka punkter eller släta punkter:
  * På en hörnpunkt kan intilliggande segment mötas i en vinkel.
  * På en slät punkt är de två kontrollhandtagen i linje och lika långt från ankarnpunkten.
  * På en rak punkt är de två kontrollhandtagen i linje men kan ha olika avstånd från ankarnpunkten.
* Att flytta ankarnpunkter eller justera deras handtag förändrar formens kontur.

För att redigera PowerPoint‑former med redigeringspunkter tillhandahåller **Aspose.Slides** klassen [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) och gränssnittet [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* En [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)‑instans representerar en geometribana för objektet [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* För att hämta [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) från en [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/)-instans kan du använda metoden [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).
* För att sätta [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) för en form kan du använda metoderna: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) för former med en enda bana och [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) för former med flera banor.
* För att lägga till segment kan du använda metoderna under [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* Genom att använda egenskaperna [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) och [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) kan du ange utseendet för en geometribana.
* Genom att använda egenskapen [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) kan du hämta geometribanan för en [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) som en matris av segment.
* I äldre versioner som stöder konverteringsmetoderna nedan kan du konvertera [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) till [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* Använd metoderna [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) och [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (från klassen [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) för att konvertera mellan [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) och [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **Enkla redigeringsoperationer**

Använd följande metoder för att redigera en geometribana. Överlagringar som tar ett index infogar ett segment på den nollbaserade positionen i banans segmentmatris.

| Operation | Metod |
| --- | --- |
| Lägg till eller infoga en rak linje. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Lägg till eller infoga en kubisk Bézier‑kurva med två kontrollpunkter och ett slutpunkt. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Lägg till eller infoga en kvadratisk Bézier‑kurva med en kontrollpunkt och ett slutpunkt. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Lägg till en elliptisk båge med angivna dimensioner och vinklar i grader. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Stäng den aktuella figuren genom att ansluta dess slutpunkt till startpunkten. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Ställ in startpunkten för en figur. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Ta bort ett segment på ett nollbaserat index. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Lägg till anpassade punkter till en form**

Detta exempel infogar två punkter i en rektangulär form med hjälp av [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) och tillämpar den redigerade banan med [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). Koordinaterna är lokala för formen: båda nya punkterna ligger i dess centrum, 100 punkter från vänsterkanten och 50 punkter från toppen. Segmentindex 1 och 4 placerar dem på ovansidan respektive undersidan, vilket drar in de kanterna.

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

![exempel1_bild](custom_shape_1.png)

## **Ta bort punkter från en form**

Detta exempel ändrar konturen på ett hjärtformat genom att ta bort segmentet på nollbaserat index 2 med [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). Genom att applicera den modifierade banan med [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) uppdateras formens kontur.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![exempel2_bild](custom_shape_2.png)

## **Skapa en anpassad form**

Detta exempel bygger en femspetsig stjärna med [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). Växlande yttre och inre radier på 100 respektive 50 punkter definierar spetsarna och urgröningarna; ett steg på 72 grader placerar de fem spetsarna jämnt. Banan stängs med [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) och appliceras på en rektangulär form med [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), vilket ersätter dess kontur.

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
![exempel3_bild](custom_shape_3.png)

## **Skapa en sammansatt anpassad form**

Detta exempel definierar två slutna [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)‑objekt för den övre respektive nedre tredjedelen av en form. Genom att applicera båda banorna med [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) skapas en enda sammansatt form med ett tomrum över dess mittersta tredjedel.

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
![exempel4_bild](custom_shape_4.png)

## **Skapa en anpassad form med böjda hörn**

Detta exempel kombinerar raka segment med [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) för att skapa en form med inåtböjda hörn. Varje hörnstorlek anger bågens bredd och höjd i punkter, och den -90‑graders svepningen ritar en motsols kvartsellips. Den färdiga banan appliceras med [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), och presentationen sparas i PPTX‑format.

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

## **Ta reda på om en formgeometri är sluten**

Följande hjälpfunktion kontrollerar om varje icke‑tom geometribana avslutas med ett stängningssegment. Den läser [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) och jämför det sista segmentets [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) med [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Den returnerar false när inga icke‑tomma banor finns. Detta kontrollerar det sista kommandot för varje bana; den inspekterar inte varje underfigur i en bana. Exemplet skriver ut `True` för en rektangel.

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

## **Extrahera och inspektera formelement**

Använd [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) för att undersöka en befintlig form som element som innehåller bana‑punkter och punkttyper. Casta varje returnerad [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) till [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) för att läsa dess [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) och [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/)‑arrayer. Denna representation är användbar för kontur‑analys eller för att vidarebefordra geometrin till egna ritverktyg.

Exemplet öppnar en presentation, hittar den första geometriska formen på den första bilden och skriver ut dess bansegment. Använd en presentation som innehåller en form med både raka och kurvade segment för att se båda typerna av resultat. Den söker inte i grupper.

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
        var pointType = types[i] & 0x07; // Behåll segmenttypen, exklusive flaggor.
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

Arrayerna motsvarar varandra per index: `points[i]` är en punkt och `types[i]` beskriver dess roll. Typ `0` startar en figur, och typ `1` drar en linje från föregående punkt till den nuvarande. Ett kubiskt Bézier‑segment startar vid föregående slutpunkt och använder tre på varandra följande typ‑`3`‑poster: två kontrollpunkter följt av den nya slutpunkten. Loopen konsumerar dessa tre poster tillsammans och kontrollerar slutpunkten för slutenhet.

Punkt‑typer innehåller även flaggor. Maskera med `0x07` för att identifiera segmenttypen och testa `0x80` separat för att upptäcka en sluten underbana. Till exempel betyder `129` (`0x81`) en linjeslutpunkt som stänger en underbana, och `131` (`0x83`) betyder en Bézier‑slutpunkt som gör det. Att bara jämföra råvärdet med `1` eller `3` skulle missa dessa fall. Andra flaggor, som streck (`0x10`) och markör (`0x20`), ändrar inte bassegmenttypen.

**Koordinater och transformationer.** Punkter mäts i punkter (1/72 tum), med X ökad åt höger och Y ökad nedåt. För en icke‑grupperad form innehåller de extraherade koordinaterna redan dess [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/)‑ och [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/)‑position och avspeglar dess aktuella bredd och höjd. Till exempel har en icke‑roterad rektangel på `(100, 200)` med storleken `120 × 80` konturboundar `(100, 200)`–`(220, 280)`. Lägg inte till formens position igen. Subtrahera dess X och Y för att få koordinater relativt till dess icke‑roterade ram.

De extraherade punkterna tillämpas inte på formens [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) eller horisontella och vertikala speglingar. För att återge den visade konturen, applicera dessa transformationer kring formens centrum. För grupperade former, ta även hänsyn till gruppens koordinatmappning och transformationer; anta inte att de extraherade punkterna är de slutgiltiga renderade bild‑koordinaterna eller att du ska tillämpa en översättning eller skala två gånger om den redan reflekteras i barnets ram.

**Inspektion kontra redigering.** Extraherade arrayer beskriver konturen; att ändra dem uppdaterar inte den ursprungliga formen. Välj detta tillvägagångssätt när din analys‑ eller ritkod behöver punkt‑/typ‑arrayer. Använd [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) när du behöver geometrikommandon i formens lokala koordinatsystem eller vill redigera dess geometri. Applicera redigerade banor via [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) eller [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **Konvertera GeometryPath till GraphicsPath (System.Drawing.Drawing2D)**

Följande exempel kräver ett äldre Aspose.Slides for .NET‑assembly som stöder [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/), exempelvis version 25.10, samt en Windows‑miljö med `System.Drawing.Common`. Konverteringsmetoderna togs bort i [version 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

Exemplet kombinerar en rektangulär kontur med text som konverterats till geometri. Konturens [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) är satt till att inaktivera fyllning. En [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) lagrar textens kontur, vilket [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) konverterar till en fylld geometribana. Genom att applicera båda banorna med [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) skapas en enda form som innehåller både rektangeln och texten. För konvertering åt andra hållet, använd [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

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
![exempel5_bild](custom_shape_5.png)

## **FAQ**

**Vad händer med fyllning och kontur efter att geometrin har ersatts?**

Stilen förblir knuten till formen; endast konturen ändras. Fyllning och kontur appliceras automatiskt på den nya geometrin.

**Hur roterar jag en anpassad form korrekt tillsammans med dess geometri?**

Använd formens [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/)‑egenskap; geometrin roterar med formen eftersom den är bunden till formens eget koordinatsystem.

**Kan jag konvertera en anpassad form till en bild för att ”låsa” resultatet?**

Ja. Exportera den önskade [bild](/slides/sv/net/convert-powerpoint-to-png/)‑området eller själva [formen](/slides/sv/net/create-shape-thumbnails/) till ett rasterformat; detta förenklar vidare arbete med komplexa geometrier.