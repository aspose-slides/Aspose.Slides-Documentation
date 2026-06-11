---
title: Anpassa presentationsformer i .NET
linktitle: Anpassad form
type: docs
weight: 20
url: /sv/net/custom-shape/
keywords: 
- anpassad form
- lägg till form
- skapa form
- ändra form
- formgeometri
- geometribana
- banpunkter
- redigera punkter
- lägg till punkt
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

Den här artikeln förklarar hur du anpassar presentationsformer i Aspose.Slides genom att redigera formgeometri via redigeringspunkter och geometriska banor. Den visar hur du arbetar med `GeometryPath` och `IGeometryPath` för att ändra befintliga former, utföra grundläggande bana‑redigeringsoperationer, lägga till eller ta bort punkter och applicera uppdaterad geometri på en form.

Den demonstrerar också hur du skapar anpassade och sammansatta former, bygger former med kurvade hörn, avgör om en formgeometri är sluten, samt konverterar mellan `GeometryPath` och `GraphicsPath` för ytterligare scenarier med geometrisk anpassning.

## **Ändra en form med redigeringspunkter**

Tänk dig en kvadrat. I PowerPoint kan du med **redigeringspunkter** 

* flytta kvadratens hörn inåt eller utåt  
* ange krökningen för ett hörn eller en punkt  
* lägga till nya punkter i kvadraten  
* manipulera punkter på kvadraten osv.  

I princip kan du utföra dessa uppgifter på vilken form som helst. Med redigeringspunkter kan du ändra en form eller skapa en ny form från en befintlig.

## **Tips för formredigering**

![overview_image](custom_shape_0.png)

Innan du börjar redigera PowerPoint‑former via redigeringspunkter kan du tänka på följande om former:

* En form (eller dess bana) kan antingen vara sluten eller öppen.  
* Alla former består av minst två ankarnpunkter som är länkade till varandra med linjer.  
* En linje är antingen rak eller kurvig. Ankarnpunkter bestämmer linjens natur.  
* Ankarnpunkter finns som hörnpunkter, raka punkter eller släta punkter:  
  * En hörnpunkt är en punkt där två raka linjer möts i en vinkel.  
  * En slät punkt är en punkt där två handtag ligger i en rak linje och linjesegmenten möts i en mjuk kurva. I detta fall är alla handtag separerade från ankarnpunkten med lika avstånd.  
  * En rak punkt är en punkt där två handtag ligger i en rak linje och linjesegmenten möts i en mjuk kurva. I detta fall behöver handtagen inte vara separerade från ankarnpunkten med lika avstånd.  
* Genom att flytta eller redigera ankarnpunkter (vilket ändrar vinkeln på linjerna) kan du förändra hur en form ser ut.  

För att redigera PowerPoint‑former via redigeringspunkter erbjuder **Aspose.Slides** klassen [**GeometryPath**](https://reference.aspose.com/slides/sv/net/aspose.slides/geometrypath) och gränssnittet [**IGeometryPath**](https://reference.aspose.com/slides/sv/net/aspose.slides/igeometrypath).

* En [GeometryPath](https://reference.aspose.com/slides/sv/net/aspose.slides/geometrypath)‑instans representerar en geometribana för objektet [IGeometryShape](https://reference.aspose.com/slides/sv/net/aspose.slides/igeometryshape).  
* För att hämta `GeometryPath` från `IGeometryShape`‑instansen kan du använda metoden [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/sv/net/aspose.slides/igeometryshape/methods/getgeometrypaths).  
* För att sätta `GeometryPath` för en form kan du använda dessa metoder: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/sv/net/aspose.slides/igeometryshape/methods/setgeometrypath) för *solid shapes* och [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/sv/net/aspose.slides/igeometryshape/methods/setgeometrypaths) för *composite shapes*.  
* För att lägga till segment kan du använda metoderna under [IGeometryPath](https://reference.aspose.com/slides/sv/net/aspose.slides/igeometrypath).  
* Genom att använda egenskaperna [IGeometryPath.Stroke](https://reference.aspose.com/slides/sv/net/aspose.slides/igeometrypath/properties/stroke) och [IGeometryPath.FillMode](https://reference.aspose.com/slides/sv/net/aspose.slides/igeometrypath/properties/fillmode) kan du ange utseendet för en geometribana.  
* Genom att använda egenskapen [IGeometryPath.PathData](https://reference.aspose.com/slides/sv/net/aspose.slides/igeometrypath/properties/pathdata) kan du hämta geometribanan för en `GeometryShape` som en array av bansegment.  
* För att få tillgång till ytterligare anpassningsalternativ för formgeometri kan du konvertera [GeometryPath](https://reference.aspose.com/slides/sv/net/aspose.slides/geometrypath) till [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).  
* Använd metoderna [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/sv/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) och [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/sv/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (från klassen [ShapeUtil](https://reference.aspose.com/slides/sv/net/aspose.slides.util/shapeutil)) för att konvertera [GeometryPath](https://reference.aspose.com/slides/sv/net/aspose.slides/geometrypath) till [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) fram och tillbaka.

## **Enkla redigeringsoperationer**

Denna C#‑kod visar hur du

**Lägger till en linje** i slutet av en bana

``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Lägger till en linje** på en angiven position i en bana:

``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**Lägger till en kubisk Bézier‑kurva** i slutet av en bana:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Lägger till en kubisk Bézier‑kurva** på en angiven position i en bana:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**Lägger till en kvadratisk Bézier‑kurva** i slutet av en bana:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Lägger till en kvadratisk Bézier‑kurva** på en angiven position i en bana:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**Lägger till en given båge** till en bana:

``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Stänger den aktuella figuren** i en bana:

``` csharp
void CloseFigure();
```
**Anger positionen för nästa punkt**:

``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Tar bort bansegmentet** på ett givet index:

``` csharp
void RemoveAt(int index);
```

## **Lägg till anpassade punkter i en form**

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/net/aspose.slides/geometryshape) och sätt typen [ShapeType.Rectangle](https://reference.aspose.com/slides/sv/net/aspose.slides/shapetype).  
2. Hämta en instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/net/aspose.slides/geometrypath) från formen.  
3. Lägg till en ny punkt mellan de två övre punkterna i banan.  
4. Lägg till en ny punkt mellan de två nedre punkterna i banan.  
5. Applicera banan på formen.

Denna C#‑kod visar hur du lägger till anpassade punkter i en form:

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

![example1_image](custom_shape_1.png)

## **Ta bort punkter från en form**

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/net/aspose.slides/geometryshape) och sätt typen [ShapeType.Heart](https://reference.aspose.com/slides/sv/net/aspose.slides/shapetype).  
2. Hämta en instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/net/aspose.slides/geometrypath) från formen.  
3. Ta bort segmentet för banan.  
4. Applicera banan på formen.

Denna C#‑kod visar hur du tar bort punkter från en form:

``` csharp
using (Presentation pres = new Presentation())
{
	GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

	IGeometryPath path = shape.GetGeometryPaths()[0];
	path.RemoveAt(2);
	shape.SetGeometryPath(path);
}
```
![example2_image](custom_shape_2.png)

## **Skapa en anpassad form**

1. Beräkna punkterna för formen.  
2. Skapa en instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/net/aspose.slides/geometrypath).  
3. Fyll banan med punkterna.  
4. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/net/aspose.slides/geometryshape).  
5. Applicera banan på formen.

Denna C#‑kod visar hur du skapar en anpassad form:

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
![example3_image](custom_shape_3.png)

## **Skapa en sammansatt anpassad form**

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/net/aspose.slides/geometryshape).  
2. Skapa en första instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/net/aspose.slides/geometrypath).  
3. Skapa en andra instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/net/aspose.slides/geometrypath).  
4. Applicera banorna på formen.

Denna C#‑kod visar hur du skapar en sammansatt anpassad form:

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
![example4_image](custom_shape_4.png)

## **Skapa en anpassad form med kurvade hörn**

Denna C#‑kod visar hur du skapar en anpassad form med kurvade hörn (inåtriktade);

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

## **Ta reda på om en formgeometri är sluten**

En sluten form definieras som en där alla sidor är sammankopplade och bildar en enda omkrets utan hål. En sådan form kan vara en enkel geometrisk figur eller en komplex anpassad kontur. Följande kodexempel visar hur du kontrollerar om en formgeometri är sluten:

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

## **Konvertera GeometryPath till GraphicsPath (System.Drawing.Drawing2D)**

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/net/aspose.slides/geometryshape).  
2. Skapa en instans av klassen [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) från namnrymden [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).  
3. Konvertera [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0)-instansen till en [GeometryPath](https://reference.aspose.com/slides/sv/net/aspose.slides/geometrypath)-instans med hjälp av [ShapeUtil](https://reference.aspose.com/slides/sv/net/aspose.slides.util/shapeutil).  
4. Applicera banorna på formen.

Denna C#‑kod – en implementering av stegen ovan – demonstrerar konverteringsprocessen från **GeometryPath** till **GraphicsPath**:

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
![example5_image](custom_shape_5.png)

## **FAQ**

**Vad händer med fyllning och kontur efter att geometri har ersatts?**

Stilen förblir på formen; endast konturen ändras. Fyllning och kontur appliceras automatiskt på den nya geometrin.

**Hur roterar jag en anpassad form korrekt tillsammans med dess geometri?**

Använd formens [rotation](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/rotation/)‑egenskap; geometrin roterar med formen eftersom den är bunden till formens eget koordinatsystem.

**Kan jag konvertera en anpassad form till en bild för att ”låsa” resultatet?**

Ja. Exportera det önskade [slide](/slides/sv/net/convert-powerpoint-to-png/)-området eller själva [shape](/slides/sv/net/create-shape-thumbnails/) till ett rasterformat; det förenklar vidare arbete med tunga geometrier.