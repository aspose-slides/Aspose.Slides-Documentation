---
title: Testreszabott prezentáció alakzatok .NET-ben
linktitle: Egyedi alakzat
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
- útvonal pontok
- szerkesztési pontok
- pont hozzáadása
- pont eltávolítása
- szerkesztési művelet
- ívelt sarok
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Alakzatok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for .NET segítségével: geometriai útvonalak, ívelt sarkok, kompozit alakzatok."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan testreszabhatók a prezentáció alakzatok az Aspose.Slides‑ben úgy, hogy szerkeszti az alakzat geometriáját szerkesztési pontok és geometriai útvonalak használatával. Megmutatja, hogyan dolgozhat a [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) és a [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) segítségével a meglévő alakzatok módosításához, alapvető útvonal‑szerkesztési műveletek végrehajtásához, pontok hozzáadásához vagy eltávolításához, és a frissített geometria alkalmazásához egy alakzatra.

Bemutatja továbbá, hogyan hozhat létre egyéni és kompozit alakzatokat, alakzatokat ívelt sarkokkal, hogyan határozható meg, hogy egy alakzat geometriája zárt‑e, valamint hogyan használható a régi konverzió a [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) és a [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) között további geometriai testreszabási forgatókönyvekhez.

## **Alakzat módosítása szerkesztési pontokkal**

* Mozgassa a sarkot befelé vagy kifelé.
* Állítsa be a görbületet egy pontnál.
* Adjon új pontokat.

A szerkesztési pontok használatával módosíthatja egy alakzat körvonalát, vagy egy meglévő alakzatot használhat kiindulópontként egy újhoz.

## **Alakzat szerkesztési tippek**

![overview_image](custom_shape_0.png)

PowerPoint alakzatok szerkesztésekor tartsa szem előtt a következő fogalmakat:

* Az alakzat (vagy annak útvonala) lehet zárt vagy nyitott.
* Az alakzat útvonala horgonypontokból áll, amelyeket szegmensek kapcsolnak össze.
* A szegmens lehet egyenes vagy íves. A horgonypontok és a vezérlőmarkerek határozzák meg annak formáját.
* A horgonypontok lehetnek sarokpontok, egyenes pontok vagy sima pontok:
  * Sarokpontnál a szomszédos szegmensek szöggel találkozhatnak.
  * Sima pontnál a két vezérlőmarkert egyvonalúak és egyenlő távolságra vannak a horgonyponttól.
  * Egyenes pontnál a két vezérlőmarkert egyvonalúak, de eltérő távolságra lehetnek a horgonyponttól.
* A horgonypontok mozgatása vagy a markerek módosítása megváltoztatja az alakzat körvonalát.

PowerPoint alakzatok szerkesztéséhez szerkesztési pontokkal az **Aspose.Slides** a [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) osztályt és a [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) interfészt biztosítja.

* A [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) példány a [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) objektum geometriai útvonalát képviseli.
* A [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) lekéréséhez a [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) példányból a [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) metódust használhatja.
* Egy alakzat [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) beállításához használja a [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) metódust egyszeres útvonalú alakzatoknál, illetve a [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) metódust többszörös útvonalú alakzatoknál.
* Szegmensek hozzáadásához a [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) alatti metódusokat használhatja.
* A [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) és a [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) tulajdonságok segítségével beállíthatja egy geometriai útvonal megjelenését.
* A [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) tulajdonság segítségével a [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) geometriai útvonalát szegmens tömbként kérheti le.
* Régi verziókban, amelyek támogatják az alábbi konverziós metódusokat, a [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) átalakítható [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath)-ra.
* Használja a [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) és a [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) metódusokat (a [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/) osztályból) a [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) és a [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) közötti átalakításhoz.

## **Egyszerű szerkesztési műveletek**

Az alábbi metódusokkal szerkesztheti a geometriai útvonalat. Az indexet elfogadó túlterhelések egy szegmenst szúrnak be a nullával induló pozícióba a szegmens tömbben.

| Operation | Method |
| --- | --- |
| Egyenes vonal hozzáadása vagy beillesztése. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Kubikus Bézier görbe hozzáadása vagy beillesztése két vezérlőponttal és egy végponttal. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Kvadratikus Bézier görbe hozzáadása vagy beillesztése egy vezérlőponttal és egy végponttal. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Elliptikus ív hozzáadása a megadott méretekkel és fokokban megadott szögekkel. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| A jelenlegi alakzat lezárása az úgy, hogy a végpontot összekapcsolja a kezdőponttal. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Az alakzat kezdeti pontjának beállítása. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Szegmens eltávolítása egy nullánal kezdődő indexnél. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Alakzathoz egyedi pontok hozzáadása**

Ez a példa két pontot szúr be egy téglalap alakzatba a [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) segítségével, majd a szerkesztett útvonalat a [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) alkalmazásával állítja be. A koordináták az alakzatra lokálisak: mindkét új pont a közepén helyezkedik el, 100 pontbalra a bal szélről és 50 pontbalra a tetejéről. Az 1‑es és 4‑es szegmensindexek a pontokat a felső és alsó élre helyezik, ezek behúzva a széleket.

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

## **Pontok eltávolítása egy alakzatból**

Ez a példa egy szív alakú körvonalat módosít úgy, hogy a [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) segítségével eltávolítja a nullával induló 2‑es indexű szegmenst. A módosított útvonal alkalmazása a [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) segítségével frissíti az alakzat kontúrját.

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

## **Egy egyéni alakzat létrehozása**

Ez a példa egy ötágú csillagot épít a [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) használatával. A 100‑es és 50‑es pontbeli váltakozó külső‑ és belső sugár határozza meg a csúcsokat és a benyomásokat; a 72‑fokos lépés egyenletesen elosztja az öt csúcsot. Az útvonalat a [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) zárja le, majd a [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) alkalmazásával egy téglalap alakzatra illeszti, felülírva annak körvonalát.

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

## **Kompozit egyéni alakzat létrehozása**

Ez a példa két zárt [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) objektumot definiál az alakzat felső és alsó harmadához. A [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) használatával mindkét útvonalat alkalmazva egyetlen kompozit alakzat jön létre, amelynek középső harmadában rés van.

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

## **Egyedi alakzat ívelt sarkokkal**

Ez a példa egyenes szegmenseket kombinál a [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) segítségével, hogy egy ívelt sarkokkal rendelkező alakzatot hozza létre. Minden sarokméret a ív szélességét és magasságát határozza meg pontban, a -90‑fokos ív pedig egy ellenóra járó negyed‑ellipszist rajzol. A kész útvonalat a [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) alkalmazásával állítja be, a prezentációt PPTX formátumban menti el.

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

## **Határozza meg, hogy egy alakzat geometriája zárt‑e**

Az alábbi segédfüggvény ellenőrzi, hogy minden nem üres geometriai útvonal záró szegmenst tartalmaz‑e. A [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) beolvasása után az utolsó szegmens [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) értékét a [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/) értékével hasonlítja össze. Ha nincs nem üres útvonal, hamis értékkel tér vissza. Ez az egyes útvonalak utolsó parancsát ellenőrzi; nem vizsgálja meg minden alalakzatot az útvonalon belül. A példa a `True` értéket írja ki egy téglalap esetén.

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

## **Geometriai útvonalparancsok ellenőrzése**

Töltse le a [contour.pptx](contour.pptx) fájlt, és tegye az alkalmazás munkakönyvtárába. Az első dia egy olyan alakzatot tartalmaz, amelynek felső él egyenes, egy kubikus Bézier görbe, majd egy egyenes lezáró él található. A [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) segítségével olvassa be az útvonalakat. Minden útvonal a szegmenseket rajzolási sorrendben listázza a [PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) alapján. Minden szegmens [PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) határozza meg, hogy hogyan kell olvasni a [SegmentData](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/segmentdata/)‑t.

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

Az alakzat a dia (200, 100) pontján helyezkedik el. A jelentett pontok az alakzatra lokálisak, ahol a (0, 0) a bal‑felső sarok, az x jobbra, az y lefele növekszik. A záró szegmens a kezdőpontra tér vissza további koordináták megadása nélkül.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint alakzat egy egyenes felső éllel, egy ívelt éllel a jobb felső saroktól a bal alsó sarokig, és egy egyenes bal éllel](contour.png)

## **Alakzatelemek kinyerése és ellenőrzése**

Használja a [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) metódust egy meglévő alakzat elemeinek ellenőrzéséhez, ahol az elemek útvonallpontokat és ponttípusokat tartalmaznak. Minden visszaadott [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) átkonvertálható [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) típusra, hogy elolvassa a [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) és a [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/) tömböket. Ez a reprezentáció hasznos a kontúr elemzéséhez vagy a geometria átadásához egyedi rajzolóeszközöknek.

A példa megnyit egy prezentációt, megtalálja az első geometriai alakzatot közvetlenül az első diáron, és kiírja annak szegmenslistáját. Használjon olyan prezentációt, amelynek alakzata egyenes és ívelt szegmenseket is tartalmaz, hogy mindkét típusú kimenetet lássa. Nem keres csoportosított elemekben.

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
        var pointType = types[i] & 0x07; // Megtartja a szegmens típust, a flag-eket kizárva.
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

A tömbök index szerint párosulnak: a `points[i]` egy pont, a `types[i]` leírja a szerepét. Az `0` típus egy alakzatot indít, az `1` típus egy vonalat rajzol az előző ponttól az aktuális pontig. Egy kubikus Bézier szegmens a előző végponton kezdődik, és három egymást követő `3`‑as bejegyzést használ: két vezérlőpontot, majd az új végpontot. A ciklus ezeket a három bejegyzést egyszerre fogyasztja, és ellenőrzi a végpontot a lezárásra.

A ponttípusok flag‑eket is tartalmaznak. Maszkolja a `0x07`‑es értékkel a szegmens típusát, és a `0x80`‑at külön ellenőrizze a zárt alútvonalak felismeréséhez. Például a `129` (`0x81`) egy vonalvégpont, amely lezár egy alútvonalat, a `131` (`0x83`) pedig egy Bézier‑végpont, amely lezár egyet. A nyers érték összehasonlítása csak `1`‑gyel vagy `3`‑mal lemaradna ezekről az esetekről. Egyéb flag‑ek, például a dash (`0x10`) és a marker (`0x20`), nem változtatják az alap szegmens típust.

**Koordináták és transzformációk.** A pontok pontban (1/72‑es hüvelyk) vannak mérve, az X jobbra, az Y lefele nő. Egy nem csoportosított alakzat esetén a kinyert koordináták már tartalmazzák az [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) és [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) pozíciót, és tükrözik a jelenlegi szélességet és magasságot. Például egy `(100, 200)` bal‑felső sarokkal és `120 × 80` mérettel rendelkező nem elforgatott téglalap kontúrbounds‑a `(100, 200)`‑től `(220, 280)`‑ig terjed. Ne adja hozzá újra az alakzat pozícióját. Vonja ki az X‑et és Y‑t a koordinátákból, hogy a nem elfordított kerethez viszonyított értékeket kapja.

A kinyert pontok nem alkalmazzák az alakzat [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) vagy a vízszintes‑vertikális tükrözéseit. A megjelenített kontúr reprodukálásához alkalmazza ezeket a transzformációkat az alakzat középpontja körül. Csoportosított alakzatok esetén vegye figyelembe a csoport koordináta‑leképezését és transzformációit; ne feltételezze, hogy a kinyert pontok már a végső diakoordináták, és ne alkalmazzon egyes eltolásokat vagy skálázásokat kétszer, ha már benne vannak a gyermek keretben.

**Ellenőrzés vs. szerkesztés.** A kinyert tömbök a kontúrt írják le; ezek módosítása nem frissíti az eredeti alakzatot. Válassza ezt a megközelítést, ha elemzése vagy rajzoló kódja pont/típus tömböket igényel. Használja a [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) metódust, ha a geometriai parancsokra van szüksége az alakzat lokális koordináta‑rendszerében, vagy ha a geometria szerkesztése a cél. Szerkesztett útvonalakat alkalmazzon a [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) vagy a [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) segítségével.

## **GeometryPath átalakítása GraphicsPath-re (System.Drawing.Drawing2D)**

Az alábbi példa egy régi Aspose.Slides for .NET összeállítást igényel, amely támogatja a [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) metódust, például a 25.10‑es verziót, és egy Windows környezetet a `System.Drawing.Common`‑nal. A konverziós metódusok eltávolításra kerültek a [version 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/)-ben.

Ez a példa egy téglalap körvonalát kombinálja a geometriává konvertált szöveggel. A körvonal [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) beállítása letiltja a kitöltést. Egy [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) tárolja a szöveg körvonalát, amelyet a [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) egy kitöltött geometriai útvonallá konvertál. Mindkét útvonalat a [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) alkalmazásával egyetlen alakzatba egyesíti, amely tartalmazza a téglalapot és a szöveget. A fordított irányú konverzióhoz használja a [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) metódust.

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

## **GYIK**

**Mi történik a kitöltéssel és a körvonallal, miután a geometriát lecserélik?**

A stílus az alakzaton marad; csak a kontúr változik. A kitöltés és a körvonal automatikusan az új geometriára kerülnek alkalmazásra.

**Hogyan lehet helyesen elfordítani egy egyéni alakzatot a geometriájával együtt?**

Használja az alakzat [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) tulajdonságát; a geometria az alakzathoz kapcsolódó koordináta‑rendszerben fordul, így együtt mozog.

**Átalakítható-e egy egyéni alakzat képpé, hogy „lezárja” a végeredményt?**

Igen. Exportálja a kívánt [diát](/slides/hu/net/convert-powerpoint-to-png/) vagy a [alakzatot](/slides/hu/net/create-shape-thumbnails/) magát raszteres formátumba; ez leegyszerűsíti a komplex geometriákkal való további munkát.