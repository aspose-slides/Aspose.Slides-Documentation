---
title: Správa spojnic v prezentacích v .NET
linktitle: Spojnice
type: docs
weight: 10
url: /cs/net/connector/
keywords:
- spojnice
- typ spojnice
- bod spojnice
- čára spojnice
- úhel spojnice
- napojovací místo
- upravovací bod
- propojit tvary
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se přidávat, připojovat, přepočítávat, upravovat a zkoumat rovné, ohnuté a zakřivené spojnice PowerPointu s Aspose.Slides pro .NET."
---
## **Přehled**

Spojnice je čára, která může zůstat připojena ke dvěma tvarem, když se kterýkoliv z tvarů pohybuje. Její konce se připojují k napojovacím místům, která jsou v PowerPointu zobrazena zelenými body. Některé ohnuté a zakřivené spoje také vystavují úpravové body, zobrazené oranžovými body, které řídí polohu jednotlivých segmentů spoje.

Aspose.Slides představuje spoje prostřednictvím rozhraní [IConnector](https://reference.aspose.com/slides/cs/net/aspose.slides/iconnector/). Můžete je vytvářet, připojovat jejich konce k tvarům, vybírat napojovací místa, přepočítávat je a měnit geometrii spojnic, které mají úpravové body.

## **Typy spojnic**

Výčtová hodnota [ShapeType](https://reference.aspose.com/slides/cs/net/aspose.slides/shapetype/) zahrnuje přednastavené rovné, ohnuté a zakřivené spoje. Následující tabulka zobrazuje dostupné geometrie spojnic a počet úpravových bodů definovaný každým přednastavením.

| Spojnice | Obrázek | Počet úpravových bodů |
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

Počet a význam úpravových bodů jsou součástí vybraného přednastavení spoje. Nepředpokládejte, že dva různé typy spojnic mají stejný rozložení kolekce.

## **Propojení dvou tvarů**

Použijte [IShapeCollection.AddConnector](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addconnector/) k přidání spoje a přiřaďte jeho vlastnosti [StartShapeConnectedTo](https://reference.aspose.com/slides/cs/net/aspose.slides/connector/startshapeconnectedto/) a [EndShapeConnectedTo](https://reference.aspose.com/slides/cs/net/aspose.slides/connector/endshapeconnectedto/). Po připojení obou konců [IConnector.Reroute](https://reference.aspose.com/slides/cs/net/aspose.slides/iconnector/reroute/) vybere krátkou cestu mezi tvary.

Následující příklad spojuje elipsu a obdélník ohnutou spojnicí:

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

{{% alert color="warning" title="Varování" %}}
Volání `Reroute` může změnit hodnoty [StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/cs/net/aspose.slides/connector/startshapeconnectionsiteindex/) a [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/cs/net/aspose.slides/connector/endshapeconnectionsiteindex/). Připojte konkrétní napojovací místa po přepočítání, pokud musí zůstat pevná.
{{% /alert %}}

## **Výběr napojovacího místa**

Každý připojitelný tvar udává počet svých míst pomocí [ConnectionSiteCount](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/connectionsitecount/). Ověřte preferovaný nulový index místa před jeho přiřazením ke konci spoje; počet míst se liší podle geometrie tvaru.

Tento příklad připojuje spojnici ke konkrétnímu místu na elipse, pokud toto místo existuje:

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

## **Úprava bodu spoje**

Spojnice s úpravovými body je vystavuje prostřednictvím [IGeometryShape.Adjustments](https://reference.aspose.com/slides/cs/net/aspose.slides/igeometryshape/adjustments/). Prozkoumejte každou [IAdjustValue](https://reference.aspose.com/slides/cs/net/aspose.slides/iadjustvalue/) a před změnou zkontrolujte její [Type](https://reference.aspose.com/slides/cs/net/aspose.slides/adjustvalue/type/). Všeobecná pravidla pro identifikaci úprav přednastavených tvarů jsou popsána v článku [Shape Manipulation](/slides/cs/net/shape-manipulations/).

Počet, pořadí, význam a platný rozsah hodnot úprav spoje závisí na přednastavení spoje. Vlastnost `Type` je pouze ke čtení, zatímco hodnota úpravy je zapisovatelná. Vlastnost pouze ke čtení [Name](https://reference.aspose.com/slides/cs/net/aspose.slides/adjustvalue/name/) poskytuje další identifikaci, pokud spojnice obsahuje více úprav se stejným sémantickým typem.

### **Obejití překážky**

V následujícím uspořádání prochází spoje `BentConnector5` mezi dvěma tvary třetím tvarem:

![connector-obstruction](connector-obstruction.png)

Tento kód vytváří blokovanou spojnici:

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

Posunutí vertikálního ohybu změní cestu tak, aby spojnice obešla překážku:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Místo předpokladu, že index kolekce `1` vždy představuje vertikální ohyb, tento příklad hledá `ConnectorBendPositionY` a mění jej pouze tehdy, když je přítomen očekávaný sémantický typ:

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

`BentConnector5` má dva úpravy `ConnectorBendPositionX` a jednu úpravu `ConnectorBendPositionY`. Pokud se požadovaný typ vyskytuje více než jednou, prozkoumejte `Name` a známou geometrii přednastavení před výběrem. Pokud úprava vrací `ShapeAdjustmentType.Custom`, považujte její význam a rozsah za specifické pro přednastavení a neměňte ji, dokud není tato smlouva známá.

## **Vazba hodnot úprav na geometrii spoje**

U ohnutých spojnic lze hodnoty úprav použít k odhadu poloh jednotlivých segmentů. Tyto výpočty jsou specifické pro konkrétní přednastavení spoje:

- `BentConnector4` obvykle vystavuje jednu úpravu `ConnectorBendPositionX` a jednu `ConnectorBendPositionY`.
- Pro tyto pozice ohybu `RawValue / 100000f` poskytuje zlomek šířky nebo výšky rámce spoje použitý v níže uvedených příkladech.
- Rámec spoje může být otočen nebo převrácen, takže souřadnice rámce je nutné transformovat před jejich porovnáním se souřadnicemi snímku.

Následující příklady nejprve používají `Type` k identifikaci úprav. Nepoužívají indexy kolekce jako přenositelné identifikátory.

### **Neroztočená spojnice**

Počáteční uspořádání obsahuje dva textové tvary spojené `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Tento příklad prozkoumá spojnici a získá její horizontální a vertikální úpravy ohybu:

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

Pro změnu obou ohybů najděte každý očekávaný typ a upravte hodnoty až po jejich nalezení:

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

Výsledkem je spojnice, jejíž horizontální a vertikální segmenty se posunuly:

![connector-adjusted-1](connector-adjusted-1.png)

Jakmile jsou sémantické typy známy, lze jejich hodnoty převést na souřadnice rámce spoje. Tento příklad vykreslí tenký obdélník přes vertikální segment řízený dvěma úpravami ohybu:

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

Výukový tvar označuje vypočítaný segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Otočená nebo převrácená spojnice**

Když je stejná geometrie spoje orientována svisle, hodnoty [Frame](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/frame/), [FlipH](https://reference.aspose.com/slides/cs/net/aspose.slides/shapeframe/fliph/), a [FlipV](https://reference.aspose.com/slides/cs/net/aspose.slides/shapeframe/flipv/) ovlivňují převod souřadnic rámce spoje na souřadnice snímku.

Tento příklad vytváří a upravuje svisle orientovanou spojnici:

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

Upravená spojnice se zobrazuje svisle mezi tvary:

![connector-adjusted-3](connector-adjusted-3.png)

Pro libovolný úhel otočení `alpha` otočte bod rámce spoje `(x, y)` kolem středu rámce `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Následující kód řeší orientaci 90 stupňů použitou v tomto příkladu a vykreslí červený vodicí prvek nad odpovídajícím segmentem spoje:

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

Červený vodicí prvek označuje vypočítaný segment po transformaci souřadnic:

![connector-adjusted-4](connector-adjusted-4.png)

Tyto vzorce popisují přednastavení použité v příkladech, nikoli univerzální model spoje. Ověřte typy úprav, orientaci rámce a rozsahy hodnot před aplikací stejného výpočtu na jiné přednastavení.

## **Zjištění úhlu směru spoje**

Směr rovné spoje lze vypočítat z její šířky a výšky, se započtením horizontálního a vertikálního převrácení. Následující příklad vrací úhel ve směru hodinových ručiček od kladné horizontální osy ve souřadnicích snímku:

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

## **Často kladené otázky**

**Jak zjistit, zda se spoje může připojit k tvaru?**

Zkontrolujte `ConnectionSiteCount` tvaru. Kladný počet znamená, že tvar vystavuje napojovací místa. Ověřte vybraný index místa před jeho přiřazením ke kterémukoli konci spoje.

**Mohu identifikovat úpravu spoje podle indexu v kolekci?**

Index má smysl pouze pro známé přednastavení spoje a rozložení kolekce. Před úpravou hodnoty zkontrolujte `IAdjustValue.Type` a použijte `IAdjustValue.Name` jako doplňující informaci, pokud se stejný sémantický typ vyskytuje vícekrát.

**Co se stane, když je připojený tvar smazán?**

Příslušný konec spoje se odpojí. Spojnice zůstane na snímku a může být smazána, umístěna jako volná čára nebo připojena k jinému tvaru.

**Zůstávají vazby spojnic zachovány při kopírování snímku?**

Vazby jsou obecně zachovány, když jsou připojené tvary kopírovány společně se snímkem. Pokud je spoje zkopírována bez jednoho ze svých cílových tvarů, musí být dotčený konec připojen znovu.