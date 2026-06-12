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
- gebogen hoek
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Vormen maken en aanpassen in PowerPoint-presentaties met Aspose.Slides voor .NET: geometrie-paden, gebogen hoeken, samengestelde vormen."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatievormen in Aspose.Slides kunt aanpassen door de vormgeometrie te bewerken via bewerkingspunten en geometrie‑paden. Het laat zien hoe u met `GeometryPath` en `IGeometryPath` kunt werken om bestaande vormen te wijzigen, basisbewerkingsbewerkingen op paden uit te voeren, punten toe te voegen of te verwijderen, en de bijgewerkte geometrie terug toe te passen op een vorm.

Daarnaast wordt getoond hoe u aangepaste en samengestelde vormen kunt maken, vormen met gebogen hoeken kunt opbouwen, kunt bepalen of een vormgeometrie gesloten is, en hoe u tussen `GeometryPath` en `GraphicsPath` kunt converteren voor extra scenario’s voor geometrie‑aanpassing.

## **Een vorm aanpassen met bewerkingspunten**

Beschouw een vierkant. In PowerPoint kunt u met **bewerkingspunten**  

* de hoek van het vierkant naar binnen of naar buiten verplaatsen  
* de kromming van een hoek of punt specificeren  
* nieuwe punten aan het vierkant toevoegen  
* punten op het vierkant manipuleren, enzovoort.  

In feite kunt u de beschreven taken uitvoeren op elke vorm. Met bewerkingspunten kunt u een vorm wijzigen of een nieuwe vorm maken op basis van een bestaande vorm.

## **Tips voor vormbewerking**

![overview_image](custom_shape_0.png)

Voordat u begint met het bewerken van PowerPoint‑vormen via bewerkingspunten, kunt u rekening houden met de volgende punten over vormen:

* Een vorm (of het pad ervan) kan gesloten of open zijn.  
* Alle vormen bestaan uit minimaal 2 ankerpunten die met elkaar verbonden zijn door lijnen.  
* Een lijn is recht of gebogen. Ankerpunten bepalen de aard van de lijn.  
* Ankerpunten bestaan als hoekpunten, rechte punten of vloeiende punten:  
  * Een hoekpunt is een punt waar 2 rechte lijnen onder een hoek samenkomen.  
  * Een vloeiend punt is een punt waar 2 handvatten in een rechte lijn liggen en de segmenten van de lijn in een vloeiende curve samenkomen. In dit geval staan alle handvatten op gelijke afstand van het ankerpunt.  
  * Een recht punt is een punt waar 2 handvatten in een rechte lijn liggen en de segmenten van die lijn in een vloeiende curve samenkomen. In dit geval hoeven de handvatten niet op gelijke afstand van het ankerpunt te staan.  
* Door ankerpunten te verplaatsen of te bewerken (wat de hoek van de lijnen verandert), kunt u de vorm van de vorm wijzigen.  

Om PowerPoint‑vormen via bewerkingspunten te bewerken, biedt **Aspose.Slides** de [**GeometryPath**](https://reference.aspose.com/slides/nl/net/aspose.slides/geometrypath)‑klasse en de [**IGeometryPath**](https://reference.aspose.com/slides/nl/net/aspose.slides/igeometrypath)‑interface.

* Een [GeometryPath](https://reference.aspose.com/slides/nl/net/aspose.slides/geometrypath)‑instantie stelt een geometriepad van het [IGeometryShape](https://reference.aspose.com/slides/nl/net/aspose.slides/igeometryshape)‑object voor.  
* Om de `GeometryPath` van de `IGeometryShape`‑instantie op te halen, kunt u de [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/nl/net/aspose.slides/igeometryshape/methods/getgeometrypaths)‑methode gebruiken.  
* Om de `GeometryPath` voor een vorm in te stellen, kunt u deze methoden gebruiken: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/nl/net/aspose.slides/igeometryshape/methods/setgeometrypath) voor *solide vormen* en [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/nl/net/aspose.slides/igeometryshape/methods/setgeometrypaths) voor *samengestelde vormen*.  
* Om segmenten toe te voegen, kunt u de methoden onder [IGeometryPath](https://reference.aspose.com/slides/nl/net/aspose.slides/igeometrypath) gebruiken.  
* Met de [IGeometryPath.Stroke](https://reference.aspose.com/slides/nl/net/aspose.slides/igeometrypath/properties/stroke)‑ en [IGeometryPath.FillMode](https://reference.aspose.com/slides/nl/net/aspose.slides/igeometrypath/properties/fillmode)‑eigenschappen kunt u het uiterlijk van een geometriepad instellen.  
* Met de [IGeometryPath.PathData](https://reference.aspose.com/slides/nl/net/aspose.slides/igeometrypath/properties/pathdata)‑eigenschap kunt u het geometriepad van een `GeometryShape` als een array van pad‑segmenten ophalen.  
* Voor extra opties voor geometrie‑aanpassing van vormen kunt u [GeometryPath](https://reference.aspose.com/slides/nl/net/aspose.slides/geometrypath) converteren naar [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).  
* Gebruik de methoden [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/nl/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) en [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/nl/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (van de [ShapeUtil](https://reference.aspose.com/slides/nl/net/aspose.slides.util/shapeutil)‑klasse) om [GeometryPath](https://reference.aspose.com/slides/nl/net/aspose.slides/geometrypath) en [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) heen en terug te converteren.

## **Eenvoudige bewerkingsbewerkingen**

Deze C#‑code laat zien hoe u

**Een lijn toevoegen** aan het einde van een pad

``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Een lijn toevoegen** op een gespecificeerde positie in een pad:

``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**Een kubieke Bézier‑curve toevoegen** aan het einde van een pad:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Een kubieke Bézier‑curve toevoegen** op een gespecificeerde positie in een pad:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**Een kwadratische Bézier‑curve toevoegen** aan het einde van een pad:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Een kwadratische Bézier‑curve toevoegen** op een gespecificeerde positie in een pad:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**Een opgegeven boog toevoegen** aan een pad:

``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**De huidige figuur sluiten** van een pad:

``` csharp
void CloseFigure();
```
**De positie voor het volgende punt instellen**:

``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Het pad‑segment verwijderen** op een opgegeven index:

``` csharp
void RemoveAt(int index);
```

## **Aangepaste punten aan een vorm toevoegen**

1. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/net/aspose.slides/geometryshape)‑klasse en stel het type [ShapeType.Rectangle](https://reference.aspose.com/slides/nl/net/aspose.slides/shapetype) in.  
2. Haal een instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/net/aspose.slides/geometrypath)‑klasse op uit de vorm.  
3. Voeg een nieuw punt toe tussen de twee bovenste punten op het pad.  
4. Voeg een nieuw punt toe tussen de twee onderste punten op het pad.  
5. Pas het pad toe op de vorm.

Deze C#‑code laat zien hoe u aangepaste punten aan een vorm toevoegt:

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

## **Punten uit een vorm verwijderen**

1. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/net/aspose.slides/geometryshape)‑klasse en stel het type [ShapeType.Heart](https://reference.aspose.com/slides/nl/net/aspose.slides/shapetype) in.  
2. Haal een instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/net/aspose.slides/geometrypath)‑klasse op uit de vorm.  
3. Verwijder het segment van het pad.  
4. Pas het pad toe op de vorm.

Deze C#‑code laat zien hoe u punten uit een vorm verwijdert:

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

## **Een aangepaste vorm maken**

1. Bereken de punten voor de vorm.  
2. Maak een instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/net/aspose.slides/geometrypath)‑klasse.  
3. Vul het pad met de punten.  
4. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/net/aspose.slides/geometryshape)‑klasse.  
5. Pas het pad toe op de vorm.

Deze C#‑code laat zien hoe u een aangepaste vorm maakt:

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

## **Een samengestelde aangepaste vorm maken**

1. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/net/aspose.slides/geometryshape)‑klasse.  
2. Maak een eerste instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/net/aspose.slides/geometrypath)‑klasse.  
3. Maak een tweede instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/net/aspose.slides/geometrypath)‑klasse.  
4. Pas de paden toe op de vorm.

Deze C#‑code laat zien hoe u een samengestelde aangepaste vorm maakt:

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

## **Een aangepaste vorm met gebogen hoeken maken**

Deze C#‑code laat zien hoe u een aangepaste vorm met gebogen hoeken (naar binnen) maakt:

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

## **Nagaan of een vormgeometrie gesloten is**

Een gesloten vorm wordt gedefinieerd als een vorm waarvan alle zijden met elkaar verbonden zijn, waardoor één enkele rand ontstaat zonder gaten. Zo’n vorm kan een eenvoudige geometrische vorm of een complexe aangepaste omtrek zijn. De volgende code‑voorbeeld laat zien hoe u controleert of een vormgeometrie gesloten is:

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

## **GeometryPath naar GraphicsPath (System.Drawing.Drawing2D) converteren**

1. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/net/aspose.slides/geometryshape)‑klasse.  
2. Maak een instantie van de [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0)‑klasse van de [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0)‑namespace.  
3. Converteer de [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0)‑instantie naar de [GeometryPath](https://reference.aspose.com/slides/nl/net/aspose.slides/geometrypath)‑instantie met behulp van [ShapeUtil](https://reference.aspose.com/slides/nl/net/aspose.slides.util/shapeutil).  
4. Pas de paden toe op de vorm.

Deze C#‑code—een implementatie van de bovenstaande stappen—demonstrereert het conversie‑proces van **GeometryPath** naar **GraphicsPath**:

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

**Wat gebeurt er met de vulling en de contour nadat de geometrie is vervangen?**

De stijl blijft bij de vorm; alleen de contour verandert. De vulling en de contour worden automatisch op de nieuwe geometrie toegepast.

**Hoe roteer ik een aangepaste vorm correct samen met de geometrie?**

Gebruik de [rotation](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/rotation/)‑eigenschap van de vorm; de geometrie draait mee omdat deze is gekoppeld aan het eigen coördinatensysteem van de vorm.

**Kan ik een aangepaste vorm omzetten naar een afbeelding om het resultaat te “vergrendelen”?**

Ja. Exporteer het gewenste [slide](/slides/nl/net/convert-powerpoint-to-png/)‑gebied of de [shape](/slides/nl/net/create-shape-thumbnails/) zelf naar een rasterformaat; dit vereenvoudigt verder werk met complexe geometrieën.