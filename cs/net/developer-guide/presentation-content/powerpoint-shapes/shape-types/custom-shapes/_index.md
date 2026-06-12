---
title: Přizpůsobení tvarů prezentací v .NET
linktitle: Vlastní tvar
type: docs
weight: 20
url: /cs/net/custom-shape/
keywords:
- vlastní tvar
- přidat tvar
- vytvořit tvar
- změnit tvar
- geometrie tvaru
- cesta geometrie
- body cesty
- upravit body
- přidat bod
- odebrat bod
- operace úpravy
- zakřivený roh
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte tvary v prezentacích PowerPoint pomocí Aspose.Slides pro .NET: geometrické cesty, zakřivené rohy, kompozitní tvary."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit tvary v prezentaci v Aspose.Slides úpravou geometrie tvaru pomocí editačních bodů a geometrických cest. Ukazuje, jak pracovat s `GeometryPath` a `IGeometryPath` k úpravě existujících tvarů, provádění základních operací úpravy cest, přidávání nebo odstraňování bodů a aplikaci aktualizované geometrie zpět na tvar.

Také demonstruje, jak vytvářet vlastní a kompozitní tvary, vytvářet tvary se zakřivenými rohy, zjistit, zda je geometrie tvaru uzavřená, a převádět mezi `GeometryPath` a `GraphicsPath` pro další scénáře přizpůsobení geometrie.

## **Změna tvaru pomocí editačních bodů**

Zvažte čtverec. V PowerPointu, pomocí **edit points**, můžete

* přesunout roh čtverce dovnitř nebo ven
* specifikovat zakřivení rohu nebo bodu
* přidat nové body do čtverce
* manipulovat body na čtverci atd.

V podstatě můžete provádět popsané úkoly na libovolném tvaru. Používáním edit points můžete změnit tvar nebo vytvořit nový tvar z existujícího tvaru.

## **Tipy pro úpravu tvarů**

![prehled_obrazek](custom_shape_0.png)

Než začnete upravovat tvary v PowerPointu pomocí edit points, můžete zvážit následující body o tvarech:

* Tvar (nebo jeho cesta) může být buď uzavřený, nebo otevřený.
* Všechny tvary se skládají alespoň ze 2 ukotvovacích bodů spojených čarami
* Čára je buď rovná, nebo zakřivená. Ukotvovací body určují charakter čáry. 
* Ukotvovací body existují jako rohové body, rovné body nebo hladké body:
  * Rohový bod je bod, kde se dva rovné segmenty setkávají pod úhlem. 
  * Hladký bod je bod, kde jsou dva ovládací výběry (handle) na jedné přímce a segmenty čáry se spojují plynulou křivkou. V tomto případě jsou všechny ovládací výběry od ukotvovacího bodu vzdáleny stejně. 
  * Rovný bod je bod, kde jsou dva ovládací výběry na jedné přímce a segmenty čáry se spojují plynulou křivkou. V tomto případě nemusí být ovládací výběry od ukotvovacího bodu vzdáleny stejně. 
* Přesunem nebo úpravou ukotvovacích bodů (což mění úhel čar) můžete změnit vzhled tvaru. 

To edit PowerPoint shapes through edit points, **Aspose.Slides** provides the [**GeometryPath**](https://reference.aspose.com/slides/cs/net/aspose.slides/geometrypath) class and [**IGeometryPath**](https://reference.aspose.com/slides/cs/net/aspose.slides/igeometrypath) interface. 

* Instance třídy [GeometryPath](https://reference.aspose.com/slides/cs/net/aspose.slides/geometrypath) představuje geometrickou cestu objektu [IGeometryShape](https://reference.aspose.com/slides/cs/net/aspose.slides/igeometryshape). 
* Chcete-li získat `GeometryPath` z instance `IGeometryShape`, můžete použít metodu [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/cs/net/aspose.slides/igeometryshape/methods/getgeometrypaths). 
* Chcete-li nastavit `GeometryPath` pro tvar, můžete použít tyto metody: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/cs/net/aspose.slides/igeometryshape/methods/setgeometrypath) pro *solid shapes* a [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/cs/net/aspose.slides/igeometryshape/methods/setgeometrypaths) pro *composite shapes*.
* Pro přidání segmentů můžete použít metody pod [IGeometryPath](https://reference.aspose.com/slides/cs/net/aspose.slides/igeometrypath). 
* Pomocí vlastností [IGeometryPath.Stroke](https://reference.aspose.com/slides/cs/net/aspose.slides/igeometrypath/properties/stroke) a [IGeometryPath.FillMode](https://reference.aspose.com/slides/cs/net/aspose.slides/igeometrypath/properties/fillmode) můžete nastavit vzhled geometrické cesty.
* Pomocí vlastnosti [IGeometryPath.PathData](https://reference.aspose.com/slides/cs/net/aspose.slides/igeometrypath/properties/pathdata) můžete získat geometrickou cestu objektu `GeometryShape` jako pole segmentů cesty. 
* Pro přístup k dalším možnostem přizpůsobení geometrie tvaru můžete převést [GeometryPath](https://reference.aspose.com/slides/cs/net/aspose.slides/geometrypath) na [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0)
* Použijte metody [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/cs/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) a [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/cs/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (z třídy [ShapeUtil](https://reference.aspose.com/slides/cs/net/aspose.slides.util/shapeutil)) k převodu [GeometryPath](https://reference.aspose.com/slides/cs/net/aspose.slides/geometrypath) na [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) a zpět. 

## **Jednoduché operace úpravy**

Tento C# kód vám ukazuje, jak

**Přidat čáru** na konec cesty

``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Přidat čáru** na určenou pozici v cestě:

``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**Přidat kubickou Bézierovu křivku** na konec cesty:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Přidat kubickou Bézierovu křivku** na určenou pozici v cestě:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**Přidat kvadratickou Bézierovu křivku** na konec cesty:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Přidat kvadratickou Bézierovu křivku** na určenou pozici v cestě:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**Přidat daný oblouk** do cesty:

``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Uzavřít aktuální figuru** cesty:

``` csharp
void CloseFigure();
```
**Nastavit pozici pro další bod**:

``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Odstranit segment cesty** na daném indexu:

``` csharp
void RemoveAt(int index);
```

## **Přidání vlastních bodů do tvaru**

1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/net/aspose.slides/geometryshape) a nastavte typ [ShapeType.Rectangle](https://reference.aspose.com/slides/cs/net/aspose.slides/shapetype).
2. Získejte instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/net/aspose.slides/geometrypath) ze tvaru.
3. Přidejte nový bod mezi dva horní body na cestě.
4. Přidejte nový bod mezi dva dolní body na cestě.
5. Aplikujte cestu na tvar.

Tento C# kód vám ukazuje, jak přidat vlastní body do tvaru:

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

![priklad1_obrazek](custom_shape_1.png)

## **Odstranění bodů z tvaru**

1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/net/aspose.slides/geometryshape) a nastavte typ [ShapeType.Heart](https://reference.aspose.com/slides/cs/net/aspose.slides/shapetype).
2. Získejte instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/net/aspose.slides/geometrypath) ze tvaru.
3. Odstraňte segment cesty.
4. Aplikujte cestu na tvar.

Tento C# kód vám ukazuje, jak odstranit body z tvaru:

``` csharp
using (Presentation pres = new Presentation())
{
	GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

	IGeometryPath path = shape.GetGeometryPaths()[0];
	path.RemoveAt(2);
	shape.SetGeometryPath(path);
}
```
![priklad2_obrazek](custom_shape_2.png)

## **Vytvoření vlastního tvaru**

1. Vypočítejte body pro tvar.
2. Vytvořte instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/net/aspose.slides/geometrypath).
3. Naplněte cestu body.
4. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/net/aspose.slides/geometryshape).
5. Aplikujte cestu na tvar.

Tento C# kód vám ukazuje, jak vytvořit vlastní tvar:

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
![priklad3_obrazek](custom_shape_3.png)

## **Vytvoření kompozitního vlastního tvaru**

  1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/net/aspose.slides/geometryshape).
  2. Vytvořte první instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/net/aspose.slides/geometrypath).
  3. Vytvořte druhou instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/net/aspose.slides/geometrypath).
  4. Aplikujte cesty na tvar.

Tento C# kód vám ukazuje, jak vytvořit kompozitní vlastní tvar:

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
![priklad4_obrazek](custom_shape_4.png)

## **Vytvoření vlastního tvaru se zakřivenými rohy**

Tento C# kód vám ukazuje, jak vytvořit vlastní tvar se zakřivenými rohy (dovnitř);

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

## **Zjistit, zda je geometrie tvaru uzavřená**

Uzavřený tvar je definován jako takový, kde všechny jeho strany jsou propojeny, tvoří jeden okraj bez mezer. Takový tvar může být jednoduchý geometrický útvar nebo složitý vlastní obrys. Následující ukázka kódu ukazuje, jak zkontrolovat, zda je geometrie tvaru uzavřená:

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

## **Převod GeometryPath na GraphicsPath (System.Drawing.Drawing2D)** 

1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/net/aspose.slides/geometryshape).
2. Vytvořte instanci třídy [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) z namespace [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
3. Převěďte instanci [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) na instanci [GeometryPath](https://reference.aspose.com/slides/cs/net/aspose.slides/geometrypath) pomocí třídy [ShapeUtil](https://reference.aspose.com/slides/cs/net/aspose.slides.util/shapeutil).
4. Aplikujte cesty na tvar.

Tento C# kód — implementace výše uvedených kroků — ukazuje proces převodu **GeometryPath** na **GraphicsPath**:

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
![priklad5_obrazek](custom_shape_5.png)

## **FAQ**

**Co se stane s výplní a obrysem po nahrazení geometrie?**

Styl zůstává u tvaru; mění se pouze kontura. Výplň a obrys jsou automaticky aplikovány na novou geometrii.

**Jak správně otočit vlastní tvar spolu s jeho geometrií?**

Použijte vlastnost [rotation](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/rotation/) tvaru; geometrie se otáčí spolu s tvarem, protože je svázána se souřadnicovým systémem tvaru.

**Mohu převést vlastní tvar na obrázek, aby byl výsledek „zamčen“?**

Ano. Exportujte požadovanou oblast [slide](/slides/cs/net/convert-powerpoint-to-png/) nebo samotný [shape](/slides/cs/net/create-shape-thumbnails/) do rastrového formátu; to usnadňuje další práci s těžkými geometriemi.