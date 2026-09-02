---
title: Verwalten von Verbindern in Präsentationen in .NET
linktitle: Verbinder
type: docs
weight: 10
url: /de/net/connector/
keywords:
- Verbinder
- Verbinder-Typ
- Verbinderpunkt
- Verbinderlinie
- Verbinderwinkel
- Verbindungsstelle
- Einstellpunkt
- Formen verbinden
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie gerade, gebogene und gekrümmte PowerPoint‑Verbinder mit Aspose.Slides für .NET hinzufügen, anfügen, neu routen, anpassen und untersuchen."
---
## **Übersicht**

Ein Verbinder ist eine Linie, die an zwei Formen befestigt bleiben kann, wenn sich eine der Formen bewegt. Seine Enden verbinden sich mit Verbindungsstellen, die in PowerPoint durch grüne Punkte dargestellt werden. Einige gebogene und gekrümmte Verbinder zeigen zudem Einstellungspunkte, dargestellt durch orange Punkte, die die Position einzelner Verbindersegmente steuern.

Aspose.Slides stellt Verbinder über das Interface [IConnector](https://reference.aspose.com/slides/de/net/aspose.slides/iconnector/) dar. Sie können sie erstellen, ihre Enden an Formen anbringen, Verbindungsstellen auswählen, sie neu routen und die Geometrie von Verbindern, die Einstellungspunkte besitzen, ändern.

## **Verbinderarten**

Die Aufzählung [ShapeType](https://reference.aspose.com/slides/de/net/aspose.slides/shapetype/) enthält gerade, gebogene und gekrümmte Verbinder‑Voreinstellungen. Die folgende Tabelle zeigt die verfügbaren Verbindergeometrien und die Anzahl der Einstellungspunkte, die für jede Voreinstellung definiert sind.

| Verbinder | Bild | Anzahl der Einstellungspunkte |
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

Die Anzahl und Bedeutung der Einstellungspunkte gehören zur ausgewählten Verbinder‑Voreinstellung. Gehen Sie nicht davon aus, dass zwei verschiedene Verbinderarten dieselbe Sammlungsstruktur bereitstellen.

## **Zwei Formen verbinden**

Verwenden Sie [IShapeCollection.AddConnector](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/addconnector/), um einen Verbinder hinzuzufügen, und setzen Sie dessen Eigenschaften [StartShapeConnectedTo](https://reference.aspose.com/slides/de/net/aspose.slides/connector/startshapeconnectedto/) und [EndShapeConnectedTo](https://reference.aspose.com/slides/de/net/aspose.slides/connector/endshapeconnectedto/). Nachdem beide Enden befestigt sind, wählt [IConnector.Reroute](https://reference.aspose.com/slides/de/net/aspose.slides/iconnector/reroute/) eine kurze Route zwischen den Formen.

The following example connects an ellipse and a rectangle with a bent connector:

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
Calling `Reroute` can change the [StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/de/net/aspose.slides/connector/startshapeconnectionsiteindex/) and [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/de/net/aspose.slides/connector/endshapeconnectionsiteindex/) values. Assign specific connection sites after rerouting if those sites must remain fixed.
{{% /alert %}}

## **Verbindungsstelle auswählen**

Jede verbindbare Form gibt ihre Anzahl an Stellen über [ConnectionSiteCount](https://reference.aspose.com/slides/de/net/aspose.slides/shape/connectionsitecount/) zurück. Validieren Sie einen bevorzugten nullbasierten Stellenindex, bevor Sie ihn einem Verbinderende zuweisen; die Stellenanzahl variiert je nach Formgeometrie.

This example attaches the connector to a particular site on the ellipse when that site exists:

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

## **Verbinderpunkt anpassen**

Verbinder mit Einstellungspunkten stellen diese über [IGeometryShape.Adjustments](https://reference.aspose.com/slides/de/net/aspose.slides/igeometryshape/adjustments/) bereit. Untersuchen Sie jedes [IAdjustValue](https://reference.aspose.com/slides/de/net/aspose.slides/iadjustvalue/) und prüfen Sie dessen [Type](https://reference.aspose.com/slides/de/net/aspose.slides/adjustvalue/type/), bevor Sie dessen [RawValue](https://reference.aspose.com/slides/de/net/aspose.slides/adjustvalue/rawvalue/) ändern. Die allgemeinen Regeln zur Identifizierung von Voreinstellungs‑Formeinstellungen werden in [Shape Manipulation](/slides/de/net/shape-manipulations/) beschrieben.

Die Anzahl, Reihenfolge, Bedeutung und der gültige Wertebereich von Verbinder‑Einstellungen hängen von der Verbinder‑Voreinstellung ab. Die Eigenschaft `Type` ist schreibgeschützt, während der Einstellungswert schreibbar ist. Die schreibgeschützte Eigenschaft [Name](https://reference.aspose.com/slides/de/net/aspose.slides/adjustvalue/name/) liefert zusätzliche Identifizierung, wenn ein Verbinder mehr als eine Einstellung desselben semantischen Typs enthält.

### **Um ein Hindernis herum routen**

Im folgenden Layout führt ein `BentConnector5`‑Verbinder zwischen zwei Formen durch eine dritte Form:

![connector-obstruction](connector-obstruction.png)

This code creates the obstructed connector:

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

Das Verschieben der vertikalen Biegung ändert die Route, sodass der Verbinder das Hindernis umgeht:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Anstatt anzunehmen, dass der Sammlungsindex `1` immer die vertikale Biegung darstellt, sucht dieses Beispiel nach `ConnectorBendPositionY` und ändert ihn nur, wenn der erwartete semantische Typ vorhanden ist:

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

Ein `BentConnector5` verfügt über zwei `ConnectorBendPositionX`‑Einstellungen und eine `ConnectorBendPositionY`‑Einstellung. Wenn der benötigte Typ mehrmals vorkommt, prüfen Sie `Name` und die bekannte Geometrie dieser Voreinstellung, bevor Sie einen auswählen. Gibt eine Einstellung `ShapeAdjustmentType.Custom` zurück, behandeln Sie deren Bedeutung und Wertebereich als presetspezifisch und ändern Sie sie nicht, bis dieser Vertrag bekannt ist.

## **Beziehung von Einstellungswerten zur Verbindergeometrie**

Für gebogene Verbinder können Einstellungswerte verwendet werden, um die Positionen einzelner Segmente abzuschätzen. Diese Berechnungen sind spezifisch für die Verbinder‑Voreinstellung:

- `BentConnector4` stellt normalerweise eine `ConnectorBendPositionX`‑ und eine `ConnectorBendPositionY`‑Einstellung bereit.
- Für diese Biegungspositionen liefert `RawValue / 100000f` den Bruchteil der Verbinder‑Rahmenbreite bzw. -höhe, der in den nachstehenden Beispielen verwendet wird.
- Ein Verbinderrahmen kann rotiert oder gespiegelt werden, daher müssen Rahmenkoordinaten transformiert werden, bevor sie mit Folienkoordinaten verglichen werden.

Die folgenden Beispiele nutzen zunächst `Type`, um die Einstellungen zu identifizieren. Sie behandeln Sammlungsindizes nicht als portable Bezeichner.

### **Unrotierten Verbinder**

Das anfängliche Layout enthält zwei Textformen, die durch einen `BentConnector4` verbunden sind:

![connector-shape-complex](connector-shape-complex.png)

This example inspects the connector and obtains its horizontal and vertical bend adjustments:

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

To change both bends, locate each expected type and modify the values only after both have been found:

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

Das Ergebnis ist ein Verbinder, dessen horizontale und vertikale Segmente verschoben wurden:

![connector-adjusted-1](connector-adjusted-1.png)

Sobald die semantischen Typen bekannt sind, können deren Werte in Verbinder‑Rahmenkoordinaten umgerechnet werden. Dieses Beispiel zeichnet ein dünnes Rechteck über das vertikale Segment, das von den beiden Biegeeinstellungen gesteuert wird:

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

Die Hilfsform markiert das berechnete Segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Rotierter oder gespiegelter Verbinder**

Wenn dieselbe Verbindergeometrie vertikal ausgerichtet ist, beeinflussen ihre Werte [Frame](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/frame/), [FlipH](https://reference.aspose.com/slides/de/net/aspose.slides/shapeframe/fliph/), und [FlipV](https://reference.aspose.com/slides/de/net/aspose.slides/shapeframe/flipv/), die Umwandlung von Verbinder‑Rahmenkoordinaten in Folienkoordinaten.

This example creates and adjusts the vertically oriented connector:

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

Der angepasste Verbinder erscheint vertikal zwischen den Formen:

![connector-adjusted-3](connector-adjusted-3.png)

Für einen beliebigen Rotationswinkel `alpha` drehen Sie einen Verbinder‑Rahmenpunkt `(x, y)` um das Rahmenezentrums `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Der folgende Code verarbeitet die in diesem Beispiel verwendete 90‑Grad‑Orientierung und zeichnet eine rote Hilfslinie über das entsprechende Verbindersegment:

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

Die rote Hilfslinie markiert das berechnete Segment nach der Koordinatentransformation:

![connector-adjusted-4](connector-adjusted-4.png)

Diese Formeln beschreiben die in den Beispielen verwendeten Voreinstellungen, nicht ein universelles Verbinder‑Modell. Validieren Sie die Einstellungstypen, Rahmenorientierung und Wertebereiche, bevor Sie dieselbe Berechnung auf eine andere Voreinstellung anwenden.

## **Winkel der Verbinderichtung finden**

Die Richtung eines geraden Verbinders kann aus seiner Breite und Höhe berechnet werden, wobei horizontale und vertikale Spiegelungen berücksichtigt werden. Das folgende Beispiel gibt den im Uhrzeigersinn gemessenen Winkel zur positiven horizontalen Achse in Folienkoordinaten aus:

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

**How can I tell whether a connector can attach to a shape?**

Prüfen Sie den `ConnectionSiteCount` der Form. Ein positiver Wert bedeutet, dass die Form Verbindungsstellen bereitstellt. Validieren Sie den gewählten Stellenindex, bevor Sie ihn einem Verbinderende zuweisen.

**Can I identify a connector adjustment by its collection index?**

Ein Index ist nur für eine bekannte Verbinder‑Voreinstellung und Sammlungsstruktur sinnvoll. Prüfen Sie `IAdjustValue.Type`, bevor Sie einen Wert ändern, und verwenden Sie `IAdjustValue.Name` als zusätzliche Information, wenn derselbe semantische Typ mehrmals vorkommt.

**What happens when a connected shape is deleted?**

Das entsprechende Verbinderende wird gelöst. Der Verbinder verbleibt auf der Folie und kann gelöscht, als freie Linie positioniert oder an einer anderen Form befestigt werden.

**Are connector bindings preserved when a slide is copied?**

Verknüpfungen bleiben in der Regel erhalten, wenn die verbundenen Formen mit der Folie kopiert werden. Wird ein Verbinder ohne eine seiner Zielformen kopiert, muss das betroffene Ende erneut befestigt werden.