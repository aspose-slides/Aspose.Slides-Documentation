---
title: Connectoren beheren in presentaties in .NET
linktitle: Connector
type: docs
weight: 10
url: /nl/net/connector/
keywords:
- connector
- connector-type
- connectorpunt
- connectorlijn
- connectorhoek
- verbindingspunt
- aanpassingspunt
- vormen verbinden
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u rechte, gebogen en kromme PowerPoint-connectors kunt toevoegen, koppelen, opnieuw routeren, aanpassen en inspecteren met Aspose.Slides voor .NET."
---
## **Overzicht**

Een connector is een lijn die aan twee vormen kan blijven gekoppeld wanneer een van de vormen beweegt. De uiteinden worden gekoppeld aan verbindingspunten, weergegeven door groene stippen in PowerPoint. Sommige gebogen en kromme connectors geven ook aanpassingspunten weer, weergegeven door oranje stippen, die de positie van individuele connectorsegmenten regelen.

Aspose.Slides vertegenwoordigt connectors via de [IConnector](https://reference.aspose.com/slides/nl/net/aspose.slides/iconnector/) interface. Je kunt ze maken, hun uiteinden aan vormen koppelen, verbindingspunten kiezen, ze opnieuw routen, en de geometrie van connectors die aanpassingspunten hebben aanpassen.

## **Connector‑typen**

De [ShapeType](https://reference.aspose.com/slides/nl/net/aspose.slides/shapetype/) enumeratie bevat rechte, gebogen en kromme connector‑presets. De onderstaande tabel toont de beschikbare connector‑geometrieën en het aantal aanpassingspunten dat door elk preset wordt gedefinieerd.

| Connector | Afbeelding | Aantal aanpassingspunten |
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

Het aantal en de betekenis van aanpassingspunten maken deel uit van het geselecteerde connector‑preset. Ga niet ervan uit dat twee verschillende connector‑typen dezelfde collectie‑lay‑out blootleggen.

## **Twee vormen verbinden**

Gebruik [IShapeCollection.AddConnector](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addconnector/) om een connector toe te voegen, en wijs de eigenschappen [StartShapeConnectedTo](https://reference.aspose.com/slides/nl/net/aspose.slides/connector/startshapeconnectedto/) en [EndShapeConnectedTo](https://reference.aspose.com/slides/nl/net/aspose.slides/connector/endshapeconnectedto/) toe. Nadat beide uiteinden zijn gekoppeld, selecteert [IConnector.Reroute](https://reference.aspose.com/slides/nl/net/aspose.slides/iconnector/reroute/) een korte route tussen de vormen.

Het volgende voorbeeld verbindt een ellips en een rechthoek met een gebogen connector:

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
Het aanroepen van `Reroute` kan de waarden van [StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/nl/net/aspose.slides/connector/startshapeconnectionsiteindex/) en [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/nl/net/aspose.slides/connector/endshapeconnectionsiteindex/) wijzigen. Wijs specifieke verbindingspunten toe na het opnieuw routen als die punten vast moeten blijven.
{{% /alert %}}

## **Kies een verbindingspunt**

Elke verbindbare vorm rapporteert het aantal punten via [ConnectionSiteCount](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/connectionsitecount/). Valideer een voorkeursindex (nul‑gebaseerd) voordat je deze toewijst aan een connector‑uiteinde; het aantal punten varieert per vormgeometrie.

Dit voorbeeld koppelt de connector aan een specifiek punt op de ellips wanneer dat punt bestaat:

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

## **Aanpassen van een connectorpunt**

Connectors met aanpassingspunten exposeren deze via [IGeometryShape.Adjustments](https://reference.aspose.com/slides/nl/net/aspose.slides/igeometryshape/adjustments/). Inspecteer elke [IAdjustValue](https://reference.aspose.com/slides/nl/net/aspose.slides/iadjustvalue/) en controleer zijn [Type](https://reference.aspose.com/slides/nl/net/aspose.slides/adjustvalue/type/) voordat je de [RawValue](https://reference.aspose.com/slides/nl/net/aspose.slides/adjustvalue/rawvalue/) wijzigt. De algemene regels voor het identificeren van preset‑vormaanpassingen worden beschreven in [Shape Manipulation](/slides/nl/net/shape-manipulations/).

Het aantal, de volgorde, de betekenis en het geldige waardebereik van connector‑aanpassingen hangen af van het connector‑preset. De `Type`‑eigenschap is alleen‑lezen, terwijl de aanpassingswaarde schrijfbaar is. De alleen‑lezen eigenschap [Name](https://reference.aspose.com/slides/nl/net/aspose.slides/adjustvalue/name/) biedt extra identificatie wanneer een connector meer dan één aanpassing van hetzelfde semantische type bevat.

### **Omzeil een obstakel**

In de onderstaande opmaak gaat een `BentConnector5` connector tussen twee vormen door een derde vorm:

![connector-obstruction](connector-obstruction.png)

Deze code maakt de geblokkeerde connector:

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

Het verplaatsen van de verticale buiging wijzigt de route zodat de connector het obstakel omzeilt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

In plaats van aan te nemen dat collectie‑index `1` altijd de verticale buiging vertegenwoordigt, zoekt dit voorbeeld naar `ConnectorBendPositionY` en wijzigt deze alleen wanneer het verwachte semantische type aanwezig is:

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

Een `BentConnector5` heeft twee `ConnectorBendPositionX`‑aanpassingen en één `ConnectorBendPositionY`‑aanpassing. Als het type dat je nodig hebt meer dan één keer voorkomt, inspecteer dan `Name` en de bekende geometrie van dat preset voordat je er één selecteert. Als een aanpassing `ShapeAdjustmentType.Custom` rapporteert, behandel dan de betekenis en het bereik als preset‑specifiek en wijzig het niet totdat dat contract bekend is.

## **Relateer aanpassingswaarden aan connector‑geometrie**

Voor gebogen connectors kunnen aanpassingswaarden worden gebruikt om de posities van individuele segmenten te schatten. Deze berekeningen zijn specifiek voor het connector‑preset:

- `BentConnector4` geeft normaal één `ConnectorBendPositionX`‑ en één `ConnectorBendPositionY`‑aanpassing weer.
- Voor deze buigposities levert `RawValue / 100000f` de fractie van de connector‑framebreedte of -hoogte op die in de onderstaande voorbeelden wordt gebruikt.
- Een connector‑frame kan worden geroteerd of gedraaid, dus frame‑coördinaten moeten worden getransformeerd voordat ze worden vergeleken met dia‑coördinaten.

De onderstaande voorbeelden gebruiken eerst `Type` om de aanpassingen te identificeren. Ze behandelen collectie‑indices niet als draagbare identifiers.

### **Niet‑geroteerde connector**

De initiële opmaak bevat twee tekstvormen die zijn verbonden door een `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Dit voorbeeld inspecteert de connector en verkrijgt de horizontale en verticale buig‑aanpassingen:

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

Om beide buigingen te wijzigen, zoek elk verwacht type op en wijzig de waarden pas nadat beide zijn gevonden:

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

Het resultaat is een connector waarvan de horizontale en verticale segmenten zijn verplaatst:

![connector-adjusted-1](connector-adjusted-1.png)

Zodra de semantische types bekend zijn, kunnen hun waarden worden omgezet naar connector‑frame‑coördinaten. Dit voorbeeld tekent een dunne rechthoek over het verticale segment dat wordt bestuurd door de twee buig‑aanpassingen:

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

De hulpsvorm markeert het berekende segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Geroteerde of gedraaide connector**

Wanneer dezelfde connectorgeometrie verticaal is georiënteerd, beïnvloeden de waarden van [Frame](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/frame/), [FlipH](https://reference.aspose.com/slides/nl/net/aspose.slides/shapeframe/fliph/), en [FlipV](https://reference.aspose.com/slides/nl/net/aspose.slides/shapeframe/flipv/) de conversie van connector‑frame‑coördinaten naar dia‑coördinaten.

Dit voorbeeld maakt en past de verticaal georiënteerde connector aan:

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

De aangepaste connector verschijnt verticaal tussen de vormen:

![connector-adjusted-3](connector-adjusted-3.png)

Voor een willekeurige rotatiehoek `alpha` roteer je een connector‑frame‑punt `(x, y)` rond het frame‑centrum `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

De onderstaande code behandelt de 90‑graden orientatie die in dit voorbeeld wordt gebruikt en tekent een rode hulplijn over het overeenkomstige connectorsegment:

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

De rode hulplijn markeert het berekende segment na de coördinatentransformatie:

![connector-adjusted-4](connector-adjusted-4.png)

Deze formules beschrijven de presets die in de voorbeelden worden gebruikt, niet een universeel connector‑model. Valideer de aanpassingstypes, frame‑oriëntatie en waardebereiken voordat je dezelfde berekening toepast op een ander preset.

## **Bepaal een connector‑richtingshoek**

De richting van een rechte connector kan worden berekend vanuit zijn breedte en hoogte, met horizontale en verticale flips toegepast. Het volgende voorbeeld geeft de klokrichtinghoek ten opzichte van de positieve horizontale as in dia‑coördinaten weer:

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

**Hoe kan ik zien of een connector aan een vorm kan worden gekoppeld?**

Controleer de `ConnectionSiteCount` van de vorm. Een positieve telling betekent dat de vorm verbindingspunten blootlegt. Valideer de gekozen site‑index voordat je deze toewijst aan een van de connector‑uiteinden.

**Kan ik een connector‑aanpassing identificeren aan de hand van zijn collectie‑index?**

Een index is alleen betekenisvol voor een bekend connector‑preset en collectie‑lay‑out. Controleer `IAdjustValue.Type` voordat je een waarde wijzigt, en gebruik `IAdjustValue.Name` als extra informatie wanneer hetzelfde semantische type meer dan één keer voorkomt.

**Wat gebeurt er wanneer een gekoppelde vorm wordt verwijderd?**

Het corresponderende connector‑uiteinde wordt ontkoppeld. De connector blijft op de dia staan en kan worden verwijderd, als een vrije lijn worden gepositioneerd, of aan een andere vorm worden gekoppeld.

**Worden connector‑bindingen bewaard wanneer een dia wordt gekopieerd?**

Bindingen worden over het algemeen behouden wanneer de gekoppelde vormen met de dia worden gekopieerd. Als een connector wordt gekopieerd zonder een van de doel‑vormen, moet het betreffende uiteinde opnieuw worden gekoppeld.