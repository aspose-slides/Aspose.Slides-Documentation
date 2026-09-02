---
title: Kapcsolók kezelése prezentációkban .NET-ben
linktitle: Kapcsoló
type: docs
weight: 10
url: /hu/net/connector/
keywords:
- kapcsolat
- kapcsolat típus
- kapcsolat pont
- kapcsolat vonal
- kapcsolat szög
- kapcsolási hely
- állítási pont
- alakzatok összekapcsolása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá, csatlakoztathat, újraúthozhat, állíthat és vizsgálhat egyenes, hajlított és görbe PowerPoint kapcsolókat az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

A csatlakozó egy vonal, amely a két alakzat mozgatása közben is csatlakoztatva maradhat mindkét alakzathoz. Végei kapcsolódási helyekhez (connection sites) csatlakoznak, amelyeket a PowerPoint zöld pontokkal jelöl. Egyes hajlított és görbe csatlakozók narancssárga pontokkal jelölt állítási pontokat is tartalmaznak, amelyek az egyes csatlakozó szegmensek pozícióját szabályozzák.

Az Aspose.Slides a csatlakozókat az [IConnector](https://reference.aspose.com/slides/hu/net/aspose.slides/iconnector/) felületen keresztül képviseli. Létrehozhatja őket, a végeket alakzatokhoz csatlakoztathatja, kiválaszthatja a kapcsolódási helyeket, újraútvonalazhatja őket, és módosíthatja a csatlakozók geometriáját, ha állítási pontokkal rendelkeznek.

## **Csatlakozó típusok**

A [ShapeType](https://reference.aspose.com/slides/hu/net/aspose.slides/shapetype/) felsorolt típusok közé tartoznak a egyenes, hajlított és görbe csatlakozó előbeállítások. Az alábbi táblázat a rendelkezésre álló csatlakozó geometriákat és az egyes előbeállítások által definiált állítási pontok számát mutatja.

| Csatlakozó | Kép | Állítási pontok száma |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Az állítási pontok száma és jelentése az adott csatlakozó előbeállítástól függ. Ne feltételezze, hogy két különböző csatlakozó típus ugyanazt a gyűjtemény elrendezést kínálja.

## **Két alakzat összekapcsolása**

Használja az [IShapeCollection.AddConnector](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addconnector/) metódust egy csatlakozó hozzáadásához, és állítsa be a [StartShapeConnectedTo](https://reference.aspose.com/slides/hu/net/aspose.slides/connector/startshapeconnectedto/) és [EndShapeConnectedTo](https://reference.aspose.com/slides/hu/net/aspose.slides/connector/endshapeconnectedto/) tulajdonságokat. Miután mindkét vég csatlakoztatva van, a [IConnector.Reroute](https://reference.aspose.com/slides/hu/net/aspose.slides/iconnector/reroute/) rövid útvonalat választ a alakzatok között.

Az alábbi példa egy ellipszist és egy téglalapot köt össze egy hajlított csatlakozóval:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;
connector.Reroute();

presentation.Save("connected-shapes.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Warning" %}}
A `Reroute` hívás megváltoztathatja a [StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/hu/net/aspose.slides/connector/startshapeconnectionsiteindex/) és [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/hu/net/aspose.slides/connector/endshapeconnectionsiteindex/) értékeket. Ha ezeknek a helyeknek rögzítve kell maradniuk, állítson be konkrét kapcsolódási helyeket az újratervezés után.
{{% /alert %}}

## **Kapcsolódási hely kiválasztása**

Minden csatlakoztatható alakzat a [ConnectionSiteCount](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/connectionsitecount/) segítségével adja meg a helyek számát. Érvényesítse a kívánt, nulláról induló hely indexet, mielőtt a csatlakozó végéhez rendeli; a helyek száma alakzat geometriától függ.

Ez a példa egy adott helyhez csatlakoztatja a csatlakozót az ellipszisen, ha az a hely létezik:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;

uint preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse.ConnectionSiteCount)
{
    connector.StartShapeConnectionSiteIndex = preferredSiteIndex;
}
else
{
    Console.WriteLine($"The ellipse has only {ellipse.ConnectionSiteCount} connection sites.");
}

presentation.Save("specific-connection-site.pptx", SaveFormat.Pptx);
```

## **Csatlakozó pont állítása**

Az állítási pontokkal rendelkező csatlakozók ezeket a [IGeometryShape.Adjustments](https://reference.aspose.com/slides/hu/net/aspose.slides/igeometryshape/adjustments/) tulajdonságon keresztül teszik elérhetővé. Vizsgálja meg minden [IAdjustValue](https://reference.aspose.com/slides/hu/net/aspose.slides/iadjustvalue/) elemet, és ellenőrizze a [Type](https://reference.aspose.com/slides/hu/net/aspose.slides/adjustvalue/type/) tulajdonságot, mielőtt módosítaná a [RawValue](https://reference.aspose.com/slides/hu/net/aspose.slides/adjustvalue/rawvalue/) értéket. A preset alakzatállítások azonosításának általános szabályait a [Shape Manipulation](/slides/hu/net/shape-manipulations/) dokumentumban találja.

Az állítások száma, sorrendje, jelentése és a megengedett értéktartomány a csatlakozó presettől függ. A `Type` tulajdonság csak olvasható, míg az állítási érték írható. A csak olvasható [Name](https://reference.aspose.com/slides/hu/net/aspose.slides/adjustvalue/name/) tulajdonság további azonosítást nyújt, ha a csatlakozó több, ugyanazon szemantikai típusú állítást tartalmaz.

### **Útvonal akadály körül**

Az alábbi elrendezésben egy `BentConnector5` csatlakozó két alakzat között egy harmadik alakzaton keresztül halad:

![connector-obstruction](connector-obstruction.png)

Ez a kód hozza létre a blokkolt csatlakozót:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

presentation.Save("connector-obstruction.pptx", SaveFormat.Pptx);
```

A függőleges hajlítás mozgatásával megváltozik az útvonal, és a csatlakozó megkerüli az akadályt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Ahelyett, hogy feltételezné, hogy az `1` index mindig a függőleges hajlítást jelenti, ez a példa a `ConnectorBendPositionY` keresését végzi, és csak akkor módosítja, ha a várt szemantikai típus jelen van:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend is null)
{
    Console.WriteLine("The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend.RawValue = 60000;
    presentation.Save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
}
```

Egy `BentConnector5` két `ConnectorBendPositionX` és egy `ConnectorBendPositionY` állítással rendelkezik. Ha a szükséges típus többször is előfordul, vizsgálja meg a `Name` értéket és az adott preset ismert geometriáját, mielőtt kiválasztana egyet. Ha egy állítás `ShapeAdjustmentType.Custom` értéket ad vissza, tekintse jelentését és tartományát az adott presethez köthetőnek, és csak akkor módosítsa, ha ez a szerződés ismert.

## **Az állítási értékek összekapcsolása a csatlakozó geometriával**

Hajlított csatlakozók esetén az állítási értékek felhasználhatók az egyes szegmensek pozíciójának becslésére. Ezek a számítások a csatlakozó presetjétől függenek:

- A `BentConnector4` általában egy `ConnectorBendPositionX` és egy `ConnectorBendPositionY` állítást tesz elérhetővé.
- Ezekhez a hajlítási pozíciókhoz a `RawValue / 100000f` a csatlakozó keret szélességének vagy magasságának arányát adja meg az alábbi példákban.
- A csatlakozó keret elforgatható vagy tükrözhető, ezért a keret koordinátákat át kell alakítani, mielőtt összehasonlítaná őket a dia koordinátáival.

Az alábbi példák először a `Type` alapján azonosítják az állításokat, és nem tekintik a gyűjtemény indexeket hordozható azonosítóknak.

### **Nem forgatott csatlakozó**

A kiindulási elrendezés két szöveges alakzatot kapcsol össze egy `BentConnector4`-gyel:

![connector-shape-complex](connector-shape-complex.png)

Ez a példa megvizsgálja a csatlakozót, és lekéri a vízszintes és függőleges hajlítási állításokat:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
targetShape.TextFrame.Text = "To";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
}
```

A két hajlítás módosításához keresse meg a várt típusokat, és csak akkor változtassa meg az értékeket, amikor mindkettőt megtalálta:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;
    presentation.Save("connector-adjusted.pptx", SaveFormat.Pptx);
}
```

Az eredmény egy olyan csatlakozó, amelynek vízszintes és függőleges szegmensei elmozdultak:

![connector-adjusted-1](connector-adjusted-1.png)

Miután a szemantikai típusok ismertté váltak, értékeiket átalakíthatja csatlakozó-keret koordinátákká. Ez a példa egy vékony téglalapot rajzol a két hajlítás által vezérelt függőleges szegmens fölé:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    var x = connector.X + connector.Width * horizontalBend.RawValue / 100000f;
    var y = connector.Y;
    var height = connector.Height * verticalBend.RawValue / 100000f;
    slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 1, height);
    presentation.Save("connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

Az útmutató alakzat jelöli a kiszámított szegmenst:

![connector-adjusted-2](connector-adjusted-2.png)

### **Forgatott vagy tükrözött csatlakozó**

Amikor ugyanaz a csatlakozó geometria függőlegesen van orientálva, a [Frame](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/frame/), [FlipH](https://reference.aspose.com/slides/hu/net/aspose.slides/shapeframe/fliph/), és [FlipV](https://reference.aspose.com/slides/hu/net/aspose.slides/shapeframe/flipv/) értékek befolyásolják a csatlakozó-keret koordináták slide koordinátákká konvertálását.

Ez a példa létrehozza és beállítja a függőlegesen orientált csatlakozót:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
targetShape.TextFrame.Text = "To 1";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        adjustment.RawValue += 20000;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        adjustment.RawValue += 200000;
    }
}

presentation.Save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
```

A módosított csatlakozó függőlegesen jelenik meg az alakzatok között:

![connector-adjusted-3](connector-adjusted-3.png)

Tetszőleges forgatási szög `alpha` esetén egy csatlakozó-keret pont `(x, y)` elforgatása a keret középpontja `(x0, y0)` körül:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Az alábbi kód kezeli a példában használt 90 fokos orientációt, és piros útmutatót rajzol a megfelelő csatlakozó szegmens fölé:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;

    var x = connector.X;
    var y = connector.Y;
    if (connector.Frame.FlipH == NullableBool.True)
    {
        x += connector.Width;
    }
    if (connector.Frame.FlipV == NullableBool.True)
    {
        y += connector.Height;
    }

    x += connector.Width * horizontalBend.RawValue / 100000f;
    var rotatedX = connector.Frame.CenterX - y + connector.Frame.CenterY;
    var rotatedY = x - connector.Frame.CenterX + connector.Frame.CenterY;
    var segmentWidth = connector.Height * verticalBend.RawValue / 100000f;
    var guide = slide.Shapes.AddAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    guide.LineFormat.FillFormat.FillType = FillType.Solid;
    guide.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

A piros útmutató a koordináta-transzformáció után a kiszámított szegmenst jelöli:

![connector-adjusted-4](connector-adjusted-4.png)

Ezek a képletek a példákban használt presetek leírására szolgálnak, nem egy általános csatlakozó modellre. Validálja az állítási típusokat, a keret orientációt és az értéktartományokat, mielőtt ugyanazt a számítást más presetre alkalmazná.

## **A csatlakozó irányszög megtalálása**

Egy egyenes csatlakozó irányát a szélesség és magasság alapján számíthatja ki, a vízszintes és függőleges tükrözéseket figyelembe véve. Az alábbi példa az óramutató járásával megegyező szöget adja meg a pozitív vízszintes tengelytől a dia koordinátákban:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

var flipH = connector.Frame.FlipH == NullableBool.True;
var flipV = connector.Frame.FlipV == NullableBool.True;
var deltaX = connector.Width * (flipH ? -1 : 1);
var deltaY = connector.Height * (flipV ? -1 : 1);
var angle = Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI;

if (angle < 0)
{
    angle += 360;
}

Console.WriteLine($"Connector direction: {angle:F2} degrees");
```

## **GYIK**

**Hogyan tudhatom meg, hogy egy csatlakozó csatlakoztatható-e egy alakzathoz?**  
Ellenőrizze az alakzat `ConnectionSiteCount` értékét. A pozitív szám azt jelenti, hogy az alakzat kapcsolódási helyeket biztosít. Érvényesítse a kiválasztott hely indexet, mielőtt a csatlakozó egyik végéhez rendeli.

**Azonosíthatok-e egy csatlakozó állítást a gyűjtemény indexe alapján?**  
Az index csak egy ismert csatlakozó preset és gyűjteményelrendezés esetén értelmezhető. Módosítás előtt ellenőrizze az `IAdjustValue.Type`-ot, és ha ugyanaz a szemantikai típus többször fordul elő, használja az `IAdjustValue.Name`-et további információként.

**Mi történik, ha egy csatlakoztatott alakzatot törölnek?**  
A megfelelő csatlakozó vég leválik. A csatlakozó a dián marad, és törölhető, szabad vonalként pozícionálható, vagy újra csatlakoztatható egy másik alakzathoz.

**Megmaradnak-e a csatlakozó kapcsolatok, amikor egy diát másolnak?**  
Általában megmaradnak, ha a csatlakoztatott alakzatokkal együtt másolják a diát. Ha egy csatlakozót másolnak anélkül, hogy a célalakzatok egyike is másolásra kerülne, az érintett véget újra csatlakoztatni kell.