---
title: "Hantera anslutningar i presentationer i .NET"
linktitle: "Anslutning"
type: docs
weight: 10
url: /sv/net/connector/
keywords:
- anslutning
- anslutningstyp
- anslutningspunkt
- anslutningslinje
- anslutningsvinkel
- anslutningsplats
- justeringspunkt
- anslut former
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du lägger till, fäster, omruttar, justerar och granskar raka, böjda och krökta PowerPoint-anslutningar med Aspose.Slides för .NET."
---
## **Översikt**

En anslutning är en linje som kan förbli fäst vid två former när någon av formerna flyttas. Dess ändar fästs vid anslutningsplatser, som visas av gröna prickar i PowerPoint. Vissa böjda och krökta anslutningar visar också justeringspunkter, som visas av orange prickar, som styr positionen för enskilda anslutningssegment.

Aspose.Slides representerar anslutningar via gränssnittet [IConnector](https://reference.aspose.com/slides/sv/net/aspose.slides/iconnector/). Du kan skapa dem, fästa deras ändar vid former, välja anslutningsplatser, omrutta dem och ändra geometrin för anslutningar som har justeringspunkter.

## **Anslutningstyper**

Enumeringen [ShapeType](https://reference.aspose.com/slides/sv/net/aspose.slides/shapetype/) innehåller raka, böjda och krökta anslutningsförinställningar. Tabellen nedan visar tillgängliga anslutningsgeometrier och antalet justeringspunkter som definieras av varje förinställning.

| Anslutning | Bild | Antal justeringspunkter |
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

Antalet och betydelsen av justeringspunkterna är en del av den valda anslutningsförinställningen. Anta inte att två olika anslutningstyper visar samma samlingslayout.

## **Anslut två former**

Använd [IShapeCollection.AddConnector](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addconnector/) för att lägga till en anslutning och tilldela dess egenskaper [StartShapeConnectedTo](https://reference.aspose.com/slides/sv/net/aspose.slides/connector/startshapeconnectedto/) och [EndShapeConnectedTo](https://reference.aspose.com/slides/sv/net/aspose.slides/connector/endshapeconnectedto/). När båda ändarna är fästa väljer [IConnector.Reroute](https://reference.aspose.com/slides/sv/net/aspose.slides/iconnector/reroute/) en kort väg mellan formerna.

Följande exempel ansluter en ellips och en rektangel med en böjd anslutning:

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

Att anropa `Reroute` kan ändra värdena [StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/sv/net/aspose.slides/connector/startshapeconnectionsiteindex/) och [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/sv/net/aspose.slides/connector/endshapeconnectionsiteindex/). Tilldela specifika anslutningsplatser efter omruttning om dessa platser måste förbli fasta.

{{% /alert %}}

## **Välj en anslutningsplats**

Varje form som kan anslutas rapporterar sitt antal platser via [ConnectionSiteCount](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/connectionsitecount/). Validera ett föredraget nollbaserat platsindex innan du tilldelar det till en anslutningsände; antalet platser varierar beroende på formens geometri.

Detta exempel fäster anslutningen på en viss plats på ellipsen när den platsen finns:

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

## **Justera en anslutningspunkt**

Anslutningar med justeringspunkter visar dem via [IGeometryShape.Adjustments](https://reference.aspose.com/slides/sv/net/aspose.slides/igeometryshape/adjustments/). Inspektera varje [IAdjustValue](https://reference.aspose.com/slides/sv/net/aspose.slides/iadjustvalue/) och kontrollera dess [Type](https://reference.aspose.com/slides/sv/net/aspose.slides/adjustvalue/type/) innan du ändrar dess [RawValue](https://reference.aspose.com/slides/sv/net/aspose.slides/adjustvalue/rawvalue/). De allmänna reglerna för att identifiera förinställda formjusteringar beskrivs i [Shape Manipulation](/slides/sv/net/shape-manipulations/).

Antalet, ordningen, betydelsen och det giltiga värdeomfånget för anslutningsjusteringar beror på anslutningsförinställningen. Egenskapen `Type` är skrivskyddad, medan justeringsvärdet är skrivbart. Den skrivskyddade egenskapen [Name](https://reference.aspose.com/slides/sv/net/aspose.slides/adjustvalue/name/) ger ytterligare identifiering när en anslutning innehåller mer än en justering av samma semantiska typ.

### **Rut runt ett hinder**

I följande layout passerar en `BentConnector5` mellan två former genom en tredje form:

![connector-obstruction](connector-obstruction.png)

Denna kod skapar den blockerade anslutningen:

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

Att flytta den vertikala böjen ändrar vägen så att anslutningen går förbi hindret:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Istället för att anta att samlingsindex `1` alltid representerar den vertikala böjen söker detta exempel efter `ConnectorBendPositionY` och ändrar den endast när den förväntade semantiska typen finns:

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

En `BentConnector5` har två `ConnectorBendPositionX`-justeringar och en `ConnectorBendPositionY`-justering. Om den typ du behöver förekommer mer än en gång, inspektera `Name` och den kända geometrin för den förinställningen innan du väljer en. Om en justering rapporterar `ShapeAdjustmentType.Custom`, behandla dess betydelse och intervall som förinställningsspecifika och ändra den inte förrän kontraktet är känt.

## **Relatera anpassningsvärden till anslutningsgeometri**

För böjda anslutningar kan justeringsvärden användas för att uppskatta positionerna för enskilda segment. Dessa beräkningar är specifika för anslutningsförinställningen:

- `BentConnector4` visar normalt en `ConnectorBendPositionX` och en `ConnectorBendPositionY`-justering.
- För dessa böjpositioner ger `RawValue / 100000f` bråkdelen av anslutningsramens bredd eller höjd som används i exemplen nedan.
- En anslutningsram kan roteras eller speglas, så ramkoordinater måste transformeras innan de jämförs med bildens koordinater.

Följande exempel använder `Type` för att först identifiera justeringarna. De behandlar inte samlingsindex som portabla identifierare.

### **Oroterad anslutning**

Den ursprungliga layouten innehåller två textformer anslutna med en `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Detta exempel inspekterar anslutningen och hämtar dess horisontella och vertikala böjjusteringar:

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

För att ändra båda böjarna, lokalisera varje förväntad typ och modifiera värdena först när båda har hittats:

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

Resultatet blir en anslutning vars horisontella och vertikala segment har förflyttats:

![connector-adjusted-1](connector-adjusted-1.png)

När de semantiska typerna är kända kan deras värden konverteras till anslutningsramens koordinater. Detta exempel ritar en tunn rektangel över det vertikala segmentet som styrs av de två böjjusteringarna:

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

Guideformen markerar det beräknade segmentet:

![connector-adjusted-2](connector-adjusted-2.png)

### **Roterad eller speglad anslutning**

När samma anslutningsgeometri är orienterad vertikalt påverkar dess [Frame](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/frame/), [FlipH](https://reference.aspose.com/slides/sv/net/aspose.slides/shapeframe/fliph/), och [FlipV](https://reference.aspose.com/slides/sv/net/aspose.slides/shapeframe/flipv/) värden konverteringen från anslutningsramens koordinater till bildens koordinater.

Detta exempel skapar och justerar den vertikalt orienterade anslutningen:

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

Den justerade anslutningen visas vertikalt mellan formerna:

![connector-adjusted-3](connector-adjusted-3.png)

För en godtycklig rotationsvinkel `alpha`, rotera en punkt i anslutningsramen `(x, y)` kring ramcentrum `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Följande kod hanterar den 90‑graders orientering som används i detta exempel och ritar en röd guide över motsvarande anslutningssegment:

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

Den röda guiden markerar det beräknade segmentet efter koordinattransformationen:

![connector-adjusted-4](connector-adjusted-4.png)

Dessa formler beskriver de förinställningar som används i exemplen, inte en universell anslutningsmodell. Validera justeringstyper, ramorientering och värdeintervall innan du tillämpar samma beräkning på en annan förinställning.

## **Hitta en anslutningsriktningens vinkel**

Riktningen för en rak anslutning kan beräknas från dess bredd och höjd, med horisontella och vertikala speglingar tillämpade. Följande exempel rapporterar den medurs vinkel från den positiva horisontella axeln i bildkoordinater:

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

## **FAQ**

**Hur kan jag avgöra om en anslutning kan fästas vid en form?**

Kontrollera formens `ConnectionSiteCount`. Ett positivt antal betyder att formen exponerar anslutningsplatser. Validera det valda platsindexet innan du tilldelar det till någon av anslutningens ändar.

**Kan jag identifiera en anslutningsjustering via dess samlingsindex?**

Ett index är meningsfullt endast för en känd anslutningsförinställning och samlingslayout. Kontrollera `IAdjustValue.Type` innan du ändrar ett värde, och använd `IAdjustValue.Name` som ytterligare information när samma semantiska typ förekommer mer än en gång.

**Vad händer när en ansluten form tas bort?**

Den motsvarande anslutningsänden blir frikopplad. Anslutningen förblir på bilden och kan tas bort, placeras som en fri linje eller fästas till en annan form.

**Behålls anslutningsbindningar när en bild kopieras?**

Bindningarna bevaras i regel när de anslutna formerna kopieras med bilden. Om en anslutning kopieras utan någon av sina målblade former måste den drabbade änden fästas igen.