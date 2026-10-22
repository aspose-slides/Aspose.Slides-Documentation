---
title: Prezentációs alakzatok testreszabása .NET-ben
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
description: "Alakzatok létrehozása és testreszabása PowerPoint-prezentációkban az Aspose.Slides for .NET segítségével: geometriai útvonalak, ívelt sarkok, összetett alakzatok."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testre szabni a prezentáció alakzatokat az Aspose.Slides-ben a forma geometria szerkesztésével a szerkesztési pontok és a geometriai útvonalak használatával. Megmutatja, hogyan lehet a [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) és a [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) osztályokkal dolgozni meglévő alakzatok módosításához, alapvető út-szerkesztési műveletek végrehajtásához, pontok hozzáadásához vagy eltávolításához, illetve a frissített geometria visszaállításához egy alakzatra.

Az is bemutatja, hogyan lehet egyedi és összetett alakzatokat létrehozni, görbe sarkokkal rendelkező alakzatokat építeni, meghatározni, hogy egy alakzat geometriája zárt‑e, és a régi átalakítást a [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) és a [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) között használni további geometriai testreszabási forgatókönyvekhez.

## **Alakzat módosítása szerkesztési pontokkal**

PowerPointban a **Szerkesztési pontok** segítségével módosíthat egy négyzetet:

* Egy sarkot befelé vagy kifelé mozgatni.
* A görbületet egy pontnál állítani.
* Új pontok hozzáadása.

A pontok szerkesztése lehetővé teszi az alakzat körvonalának módosítását, vagy egy meglévő alakzat felhasználását új alapként.

## **Alakzat szerkesztési tippek**

![áttekintő_kép](custom_shape_0.png)

PowerPoint alakzatok szerkesztésekor tartsa szem előtt ezeket a fogalmakat:

* Egy alakzat (vagy annak útvonala) lehet zárt vagy nyitott.
* Az alakzat útvonala tartalmazó horgonypontokból áll, amelyeket szegmensek kötnek össze.
* Egy szegmens lehet egyenes vagy görbe. A horgonypontok és a vezérlő fogantyúk (control handles) határozzák meg alakját.
* A horgonypontok lehetnek sarokpontok, egyenes pontok vagy sima pontok:
  * Sarokpont esetén a szomszédos szegmensek egy szögnél találkozhatnak.
  * Sima pontnál a két vezérlő fogantyú egy vonalban van és egyenlő távolságra helyezkedik el a horgonyponttól.
  * Egyenes pontnál a két vezérlő fogantyú egy vonalban van, de különböző távolságra lehet a horgonyponttól.
* A horgonypontok mozgatása vagy fogantyúik állítása megváltoztatja az alakzat körvonalát.

PowerPoint alakzatok szerkesztéséhez **Aspose.Slides** biztosítja a [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) osztályt és a [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) interfészt.

* A [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) példány egy geometriai útvonalat képvisel a [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) objektumban.
* A [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) lekéréséhez a [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) példányból használható a [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) metódus.
* Egy alakzathoz a [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) beállításához használhatók a következő metódusok: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) egyetlen útvonallal rendelkező alakzatokhoz és [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) több útvonallal rendelkező alakzatokhoz.
* Szegmensek hozzáadásához használhatók a [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) alatti metódusok.
* A [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) és a [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) tulajdonságok használatával beállítható a geometriai útvonal megjelenése.
* A [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) tulajdonság segítségével a [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) útvonalát lehet tömbként lekérni, amely szegmens elemeket tartalmaz.
* Régi verziókban, amelyek támogatják az alábbi konverziós metódusokat, a [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) átalakítható a [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) formátumba.
* Használja a [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) és a [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) metódusokat (a [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/) osztályból) a [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) és a [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) közötti átalakításhoz.

## **Egyszerű szerkesztési műveletek**

A geometriai útvonal szerkesztéséhez használja az alábbi metódusokat. Az indexet elfogadó túlterhelések egy szegmenst illesztenek a megadott nulla‑alapú pozícióba az útvonal szegmens tömbjében.

| Művelet | Metódus |
| --- | --- |
| Egyenes vonal hozzáadása vagy beszúrása. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Körbös Bézier‑görbe hozzáadása vagy beszúrása két vezérlőponttal és egy végponttal. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Másodfokú Bézier‑görbe hozzáadása vagy beszúrása egy vezérlőponttal és egy végponttal. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Elliptikus ív hozzáadása a megadott méretekkel és fokokban kifejezett szögekkel. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Az aktuális alakzat zárása a végpont és a kiinduló pont összekapcsolásával. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Az alakzat kiinduló pontjának beállítása. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Szegmens eltávolítása a nulla‑alapú indexnél. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Egyedi pontok hozzáadása egy alakzathoz**

Ez a példa két pontot szúr be egy téglalap alakzatba a [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) segítségével, majd a szerkesztett útvonalat alkalmazza a [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) használatával. A koordináták az alakzathoz viszonyítva helyi értékek: mindkét új pont a középpontban helyezkedik el, 100 pont távolságra a bal szélről és 50 pont a felső szélről. Az 1‑es és 4‑es szegmensindexek a pontokat a felső és alsó élre helyezik, ezáltal ezeket az éleket befelé húzzák.

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

![példa1_kép](custom_shape_1.png)

## **Pontok eltávolítása egy alakzatról**

Ez a példa egy szív alakú körvonalat módosít azzal, hogy a [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) metódussal eltávolítja a 2‑es (nulla‑alapú) indexű szegmenst. A módosított útvonal alkalmazása a [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) segítségével frissíti az alakzat kontúrját.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![példa2_kép](custom_shape_2.png)

## **Egyedi alakzat létrehozása**

Ez a példa egy ötágú csillagot épít a [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) használatával. Az egymást váltakozó külső és belső sugarak (100 és 50 pont) határozzák meg a csúcsokat és a bemetszéseket; egy 72‑fokos lépés egyenletesen osztja el az öt csúcsot. Az útvonalat a [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) zárja le, majd a [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) alkalmazásával egy téglalap alakzatra helyezi, felülírva annak körvonalát.

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
![példa3_kép](custom_shape_3.png)

## **Összetett egyedi alakzat létrehozása**

Ez a példa két zárt [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) objektumot definiál az alakzat felső és alsó harmadához. Mindkét útvonal alkalmazásával a [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) egyetlen összetett alakzat jön létre, amelynek középső harmadában egy rés van.

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
![példa4_kép](custom_shape_4.png)

## **Egyedi alakzat létrehozása görbe sarkokkal**

Ez a példa egyenes szegmenseket kombinál a [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) használatával, hogy egy befelé görbülő sarkokkal rendelkező alakzatot kapjon. Minden sarokméret meghatározza az ív szélességét és magasságát pontokban, a -90‑fokos ív pedig egy óramutatóval ellentétes negyedellipszist rajzol. A kész útvonalat a [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) alkalmazza, és a prezentációt PPTX formátumban menti.

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

## **Megállapítás, hogy egy alakzat geometriája zárt‑e**

Az alábbi segédfüggvény ellenőrzi, hogy minden nem üres geometriai útvonal záró szegmensen végződik‑e. Olvassa a [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) értéket, és összehasonlítja az utolsó szegmens [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) értékét a [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/) típussal. Ha nincs nem üres útvonal, hamisat ad vissza. Ez csak az egyes útvonalak végleges parancsát vizsgálja, nem elemzi minden alalakzatot a útvonalon belül. A példa egy téglalap esetén `True`‑t ír ki.

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

## **Alakzat elemek kinyerése és ellenőrzése**

Használja a [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) metódust a meglévő alakzat elemeinek megtekintéséhez, amelyek tartalmazzák az útvonal pontjait és ponttípusait. Az egyes visszaadott [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) objektumot alakítsa [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) típusra, hogy elérje a [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) és a [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/) tömböket. Ez a reprezentáció hasznos a kontúr elemzéséhez vagy a geometria egyedi rajzeszközökhöz való átadásához.

A példa egy prezentációt nyit meg, megtalálja az első geometriai alakzatot az első diáron, és kiírja az útvonal szegmenseit. Használjon olyan prezentációt, amely tartalmaz egy alakzatot egyenes és görbe szegmensekkel, hogy mindkét típust lássa. Nem keres csoportok belsejében.

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
        var pointType = types[i] & 0x07; // Tartsa meg a szegmens típusát, a flag-ek kizárásával.
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
                i += 2; // Fogyassza el mindkét vezérlőpontot és a végpontot.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

A tömbök index alapján egyeznek: a `points[i]` egy pont, a `types[i]` leírja a szerepét. A `0` típus egy ábra kezdetét jelzi, az `1` típus a korábbi ponttól a jelenlegi pontig egy vonalat rajzol. A köbös Bézier‑szegmens a korábbi végpontból indul, és három egymást követő `3` típusú bejegyzést használ: két vezérlőpontot, majd az új végpontot. A ciklus ezen három bejegyzést egyszerre dolgozza fel, és a végpontot ellenőrzi a zárás szempontjából.

A ponttípusok flag‑eket is tartalmaznak. A `0x07` maszkkal határozható meg a szegmens típusa, a `0x80` külön tesztelhető a zárt alútvonal felismerésére. Például a `129` (`0x81`) egy vonal végpont, amely zár egy alútvonalat, a `131` (`0x83`) pedig egy Bézier‑végpont, amely szintén zár. Ha csak a `1` vagy `3` értékkel hasonlítaná a nyers értéket, ezek a esetek kimaradnának. Más flag‑ek, például a szaggatott (`0x10`) vagy a marker (`0x20`) nem változtatják az alap szegmens típust.

**Koordináták és transzformációk.** A pontok pontban (1/72 hüvelyk) vannak mérve, az X jobbra, a Y lefelé növekszik. Egy nem csoportosított alakzat esetén a kinyert koordináták már tartalmazzák a [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) és [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) pozíciót, valamint a jelenlegi szélességet és magasságot. Például egy nem elforgatott téglalap `(100, 200)`‑on, `120 × 80` mérettel, a kontúrbounds `(100, 200)`‑`(220, 280)`. Ne adja hozzá újra az alakzat pozícióját. Az X‑ és Y‑t le kell vonni, hogy az elforgatás nélküli kerethez viszonyított koordinátákat kapja.

A kinyert pontok nem tartalmazzák az alakzat [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) vagy a vízszintes és függőleges tükrözés transzformációit. A megjelenített kontúr reprodukálásához alkalmazza ezeket a transzformációkat az alakzat középpontja körül. Csoportosított alakzatok esetén vegye figyelembe a csoport koordináta leképezését és transzformációkat; ne feltételezze, hogy a kinyert pontok már a végső dia koordináták, és ne alkalmazzon eltolást vagy méretezést kétszer, ha már benne vannak a gyermek keretben.

**Ellenőrzés vs. szerkesztés.** A kinyert tömbök a kontúrt írják le; azok módosítása nem frissíti az eredeti alakzatot. Ezt a megközelítést akkor válassza, ha a pont‑típus tömbökre van szüksége elemzéshez vagy rajzoláshoz. Használja a [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) metódust, ha a geometriai parancsokra van szükség az alakzat helyi koordináta‑rendszerében, vagy ha a geometriát szerkeszteni szeretné. A szerkesztett útvonalakat alkalmazza a [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) vagy a [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) segítségével.

## **GeometryPath konvertálása GraphicsPath‑re (System.Drawing.Drawing2D)**

Az alábbi példa egy régi Aspose.Slides for .NET összeállítást igényel, amely támogatja a [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) metódust, például a 25.10‑es verziót, valamint egy Windows környezetet a `System.Drawing.Common`‑nal. A konverziós metódusok eltávolításra kerültek a [version 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/) után.

Ez a példa egy téglalap körvonalat kombinál szöveggeometria átalakításával. A körvonal [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) beállításával letiltja a kitöltést. A [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) tárolja a szöveg kontúrját, amelyet a [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) egy kitöltött geometriai útvonalra konvertál. Mindkét útvonal alkalmazása a [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) segítségével egyetlen alakzatot hoz létre, amely tartalmazza a téglalapot és a szöveget. Az ellentétes irányú konverzióhoz használja a [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) metódust.

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
![példa5_kép](custom_shape_5.png)

## **GYIK**

**Mi történik a kitöltéssel és a körvonallal a geometria cseréje után?**

A stílus az alakzaton marad; csak a kontúr változik. A kitöltés és a körvonal automatikusan alkalmazásra kerül az új geometriára.

**Hogyan lehet helyesen elforgatni egy egyedi alakzatot a geometriájával együtt?**

Használja az alakzat [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) tulajdonságát; a geometria az alakzattal együtt forog, mivel az az alakzat saját koordináta‑rendszeréhez van kötve.

**Átalakítható-e egy egyedi alakzat kép‑formátumba a „lezáráshoz”?**

Igen. Exportálja a szükséges [dia](/slides/hu/net/convert-powerpoint-to-png/) területet vagy maga az [alakzat](/slides/hu/net/create-shape-thumbnails/) képet raszter formátumba; ez egyszerűsíti a komplex geometriák további kezelését.