---
title: ".NET-ben a prezentáció alakzatainak testreszabása"
linktitle: "Egyedi alakzat"
type: docs
weight: 20
url: /hu/net/custom-shape/
keywords:
- egyedi alakzat
- alakzat hozzáadása
- alakzat létrehozása
- alakzat módosítása
- alakzat geometria
- geometriai útvonal
- útvonalpontok
- szerkesztő pontok
- pont hozzáadása
- pont eltávolítása
- szerkesztési művelet
- ívelt sarok
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Alakzatok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for .NET segítségével: geometriai útvonalak, ívelt sarkok, összetett alakzatok."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet testreszabni a prezentáció alakzatokat az Aspose.Slides-ban a alakzateg geometria szerkesztésével a szerkesztő pontok és geometriai útvonalak használatával. Megmutatja, hogyan lehet a `GeometryPath` és az `IGeometryPath` segítségével módosítani a meglévő alakzatokat, alapvető útvonal-szerkesztési műveleteket végezni, pontokat hozzáadni vagy eltávolítani, és a frissített geometriát visszaalkalmazni egy alakzatra.

Az is bemutatja, hogyan hozhatunk létre egyedi és összetett alakzatokat, hogyan építhetünk görbületű sarkokkal rendelkező alakzatokat, hogyan határozhatjuk meg, hogy egy alakzateg geometria zárt-e, és hogyan konvertálhatjuk a `GeometryPath`-t és a `GraphicsPath`-t további geometriai testreszabási forgatókönyvekhez.

## **Alakzat módosítása szerkesztő pontokkal**

Vegyünk egy négyzetet. A PowerPointban, a **szerkesztő pontok** használatával a következőket tehetjük

* a négyzet sarkát be- vagy kifelé mozdíthatjuk
* megadhatjuk egy sarok vagy pont görbületét
* új pontokat adhatunk hozzá a négyzethez
* a négyzet pontjait manipulálhatjuk, stb.

Lényegében ezeket a feladatokat bármely alakzaton elvégezhetjük. A szerkesztő pontok használatával módosíthatunk egy alakzatot, vagy új alakzatot hozhatunk létre egy meglévőből.

## **Alakzat szerkesztési tippek**

![overview_image](custom_shape_0.png)

Mielőtt elkezdené a PowerPoint alakzatok szerkesztését szerkesztő pontok segítségével, érdemes ezeket a szempontokat figyelembe venni az alakzatokkal kapcsolatban:

* Egy alakzat (vagy az útvonala) lehet zárt vagy nyitott.
* Minden alakzat legalább 2 rögzítési pontból áll, amelyek vonalakkal vannak összekötve.
* Egy vonal lehet egyenes vagy görbe. A rögzítési pontok határozzák meg a vonal jellegét.
* A rögzítési pontok létezhetnek sarokpontként, egyenes pontként vagy sima pontként:
  * Egy sarokpont olyan pont, ahol 2 egyenes vonal találkozik egy szögnél.
  * Egy sima pont olyan pont, ahol 2 fogantyú egy egyenes vonalon helyezkedik el, és a vonal szegmensek sima ívben kapcsolódnak össze. Ebben az esetben minden fogantyú egyenlő távolságra van a rögzítési ponttól.
  * Egy egyenes pont olyan pont, ahol 2 fogantyú egy egyenes vonalon helyezkedik el, és a vonal szegmensek egy sima ívben csatlakoznak. Ebben az esetben a fogantyúknek nem kell egyenlő távolságra lenniük a rögzítési ponttól.
* A rögzítési pontok mozgásával vagy szerkesztésével (amely megváltoztatja a vonalak szögét) módosítható az alakzat megjelenése.

A PowerPoint alakzatok szerkesztő pontokkal történő szerkesztéséhez a **Aspose.Slides** a [**GeometryPath**](https://reference.aspose.com/slides/hu/net/aspose.slides/geometrypath) osztályt és a [**IGeometryPath**](https://reference.aspose.com/slides/hu/net/aspose.slides/igeometrypath) interfészt biztosítja.

* A [GeometryPath](https://reference.aspose.com/slides/hu/net/aspose.slides/geometrypath) példány egy geometriai útvonalat képvisel a [IGeometryShape](https://reference.aspose.com/slides/hu/net/aspose.slides/igeometryshape) objektum számára.
* A `GeometryPath` lekéréséhez az `IGeometryShape` példányból használhatja a [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/hu/net/aspose.slides/igeometryshape/methods/getgeometrypaths) metódust.
* A `GeometryPath` beállításához egy alakzathoz használhatja ezeket a metódusokat: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/hu/net/aspose.slides/igeometryshape/methods/setgeometrypath) *egyszerű alakzatok* esetén, és [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/hu/net/aspose.slides/igeometryshape/methods/setgeometrypaths) *összetett alakzatok* esetén.
* Szegmensek hozzáadásához használhatja a [IGeometryPath](https://reference.aspose.com/slides/hu/net/aspose.slides/igeometrypath) alatti metódusokat.
* A [IGeometryPath.Stroke](https://reference.aspose.com/slides/hu/net/aspose.slides/igeometrypath/properties/stroke) és a [IGeometryPath.FillMode](https://reference.aspose.com/slides/hu/net/aspose.slides/igeometrypath/properties/fillmode) tulajdonságok használatával beállíthatja egy geometriai útvonal megjelenését.
* A [IGeometryPath.PathData](https://reference.aspose.com/slides/hu/net/aspose.slides/igeometrypath/properties/pathdata) tulajdonság használatával lekérheti egy `GeometryShape` geometriai útvonalát útvonal-szegmensek tömbjeként.
* További alakzatgeometria testreszabási lehetőségek eléréséhez konvertálhatja a [GeometryPath](https://reference.aspose.com/slides/hu/net/aspose.slides/geometrypath)-t a [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0)-ra.
* Használja a [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/hu/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) és a [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/hu/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) metódusokat (a [ShapeUtil](https://reference.aspose.com/slides/hu/net/aspose.slides.util/shapeutil) osztályból) a [GeometryPath](https://reference.aspose.com/slides/hu/net/aspose.slides/geometrypath)-t a [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0)-ra és vissza való konvertáláshoz.

## **Egyszerű szerkesztési műveletek**

Ez a C# kód megmutatja, hogyan

**Vonal hozzáadása** az útvonal végéhez
``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Vonal hozzáadása** egy megadott pozícióba az útvonalon:
``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**Köbös Bézier-görbe hozzáadása** az útvonal végén:
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Köbös Bézier-görbe hozzáadása** a megadott pozícióba az útvonalon:
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**Kvadratikus Bézier-görbe hozzáadása** az útvonal végén:
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Kvadratikus Bézier-görbe hozzáadása** a megadott pozícióba az útvonalon:
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**Adott ív hozzáfűzése** egy útvonalhoz:
``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Az aktuális alakzat lezárása** egy útvonalnál:
``` csharp
void CloseFigure();
```
**A következő pont pozíciójának beállítása**:
``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Az útvonal szegmens eltávolítása** egy adott indexnél:
``` csharp
void RemoveAt(int index);
```

## **Egyedi pontok hozzáadása egy alakzathoz**

1. Hozzon létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/net/aspose.slides/geometryshape) osztályból, és állítsa be a [ShapeType.Rectangle](https://reference.aspose.com/slides/hu/net/aspose.slides/shapetype) típust.
2. Szerezzen be egy példányt a [GeometryPath](https://reference.aspose.com/slides/hu/net/aspose.slides/geometrypath) osztályból az alakzatról.
3. Adjon hozzá egy új pontot a két felső pont között az útvonalon.
4. Adjon hozzá egy új pontot a két alsó pont között az útvonalon.
5. Alkalmazza az útvonalat az alakzatra.

Ez a C# kód megmutatja, hogyan adhatunk egyedi pontokat egy alakzathoz:
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

##  **Pontok eltávolítása egy alakzatból**

1. Hozzon létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/net/aspose.slides/geometryshape) osztályból, és állítsa be a [ShapeType.Heart](https://reference.aspose.com/slides/hu/net/aspose.slides/shapetype) típust.
2. Szerezzen be egy példányt a [GeometryPath](https://reference.aspose.com/slides/hu/net/aspose.slides/geometrypath) osztályból az alakzatról.
3. Távolítsa el az útvonal szegmensét.
4. Alkalmazza az útvonalat az alakzatra.

Ez a C# kód megmutatja, hogyan távolíthatunk el pontokat egy alakzatból:
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

##  **Egyedi alakzat létrehozása**

1. Számolja ki az alakzat pontjait.
2. Hozzon létre egy példányt a [GeometryPath](https://reference.aspose.com/slides/hu/net/aspose.slides/geometrypath) osztályból.
3. Töltse fel az útvonalat a pontokkal.
4. Hozzon létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/net/aspose.slides/geometryshape) osztályból.
5. Alkalmazza az útvonalat az alakzatra.

Ez a C# bemutatja, hogyan hozhatunk létre egy egyedi alakzatot:
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

## **Összetett egyedi alakzat létrehozása**

1. Hozzon létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/net/aspose.slides/geometryshape) osztályból.
2. Hozzon létre egy első példányt a [GeometryPath](https://reference.aspose.com/slides/hu/net/aspose.slides/geometrypath) osztályból.
3. Hozzon létre egy második példányt a [GeometryPath](https://reference.aspose.com/slides/hu/net/aspose.slides/geometrypath) osztályból.
4. Alkalmazza az útvonalakat az alakzatra.

Ez a C# kód megmutatja, hogyan hozhatunk létre egy összetett egyedi alakzatot:
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

## **Egyedi alakzat létrehozása görbületű sarkokkal**

Ez a C# kód megmutatja, hogyan hozhatunk létre egy egyedi alakzatot görbületű (belülre ívelt) sarkokkal;
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

## **Megállapítás, hogy egy alakzat geometriája zárt-e**

Az zárt alakzat olyan, amelynek minden oldalát összekapcsolják, egyetlen szegélyt alkotva hézagok nélkül. Egy ilyen alakzat lehet egyszerű geometriai forma vagy összetett egyedi körvonal. A következő kódrészlet bemutatja, hogyan ellenőrizhető, hogy egy alakzat geometriája zárt-e:
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

## **GeometryPath konvertálása GraphicsPath-re (System.Drawing.Drawing2D)**

1. Hozzon létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/net/aspose.slides/geometryshape) osztályból.
2. Hozzon létre egy példányt a [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) osztályból a [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) névtérből.
3. Konvertálja a [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) példányt a [GeometryPath](https://reference.aspose.com/slides/hu/net/aspose.slides/geometrypath) példányra a [ShapeUtil](https://reference.aspose.com/slides/hu/net/aspose.slides.util/shapeutil) használatával.
4. Alkalmazza az útvonalakat az alakzatra.

Ez a C# kód – a fenti lépések megvalósítása – bemutatja a **GeometryPath** és **GraphicsPath** közötti konverziós folyamatot:
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

## **GYIK**

**Mi történik a kitöltéssel és a körvonallal, miután lecserélik a geometriát?**

A stílus megmarad az alakzaton; csak a kontúr változik. A kitöltés és a körvonal automatikusan alkalmazásra kerül az új geometriára.

**Hogyan forgatom helyesen egy egyedi alakzatot a geometriájával együtt?**

Használja az alakzat [rotation](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/rotation/) tulajdonságát; a geometria az alakzattal együtt forog, mivel az alakzat saját koordináta-rendszeréhez van kötve.

**Átkonvertálhatok egy egyedi alakzatot képpé, hogy „lezárom” az eredményt?**

Igen. Exportálja a szükséges [slide](/slides/hu/net/convert-powerpoint-to-png/) területet vagy a [shape](/slides/hu/net/create-shape-thumbnails/) maga képre raszteres formátumban; ez megkönnyíti a nehéz geometriákkal való további munkát.