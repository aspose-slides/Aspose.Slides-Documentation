---
title: Gérer les connecteurs dans les présentations en .NET
linktitle: Connecteur
type: docs
weight: 10
url: /fr/net/connector/
keywords:
- connecteur
- type de connecteur
- point de connecteur
- ligne de connecteur
- angle de connecteur
- site de connexion
- point d'ajustement
- connecter les formes
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez comment ajouter, attacher, rerouter, ajuster et inspecter les connecteurs PowerPoint droits, coudés et courbés avec Aspose.Slides pour .NET."
---
## **Vue d'ensemble**

Un connecteur est une ligne qui peut rester attachée à deux formes lorsque l’une ou l’autre se déplace. Ses extrémités sont reliées à des sites de connexion, représentés par des points verts dans PowerPoint. Certains connecteurs coudés et courbés exposent également des points d’ajustement, représentés par des points orange, qui contrôlent la position des segments individuels du connecteur.

Aspose.Slides représente les connecteurs via l’interface [IConnector](https://reference.aspose.com/slides/fr/net/aspose.slides/iconnector/). Vous pouvez les créer, attacher leurs extrémités aux formes, choisir des sites de connexion, les refaire acheminer et modifier la géométrie des connecteurs qui possèdent des points d’ajustement.

## **Types de connecteur**

L’énumération [ShapeType](https://reference.aspose.com/slides/fr/net/aspose.slides/shapetype/) comprend des présélections de connecteurs droits, coudés et courbés. Le tableau suivant montre les géométries de connecteur disponibles et le nombre de points d’ajustement définis par chaque présélection.

| Connecteur | Image | Nombre de points d'ajustement |
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

Le nombre et la signification des points d’ajustement font partie de la présélection de connecteur choisie. Ne supposez pas que deux types de connecteur différents exposent la même organisation de collection.

## **Connecter deux formes**

Utilisez [IShapeCollection.AddConnector](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/addconnector/) pour ajouter un connecteur, et attribuez ses propriétés [StartShapeConnectedTo](https://reference.aspose.com/slides/fr/net/aspose.slides/connector/startshapeconnectedto/) et [EndShapeConnectedTo](https://reference.aspose.com/slides/fr/net/aspose.slides/connector/endshapeconnectedto/). Après que les deux extrémités soient attachées, [IConnector.Reroute](https://reference.aspose.com/slides/fr/net/aspose.slides/iconnector/reroute/) sélectionne un itinéraire court entre les formes.

L’exemple suivant connecte une ellipse et un rectangle avec un connecteur coudé :

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

Appeler `Reroute` peut modifier les valeurs [StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/fr/net/aspose.slides/connector/startshapeconnectionsiteindex/) et [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/fr/net/aspose.slides/connector/endshapeconnectionsiteindex/). Assignez des sites de connexion spécifiques après le réacheminement si ces sites doivent rester fixes.

{{% /alert %}}

## **Choisir un site de connexion**

Chaque forme connectable indique son nombre de sites via [ConnectionSiteCount](https://reference.aspose.com/slides/fr/net/aspose.slides/shape/connectionsitecount/). Validez un indice de site zéro‑based préféré avant de l’attribuer à une extrémité du connecteur ; le nombre de sites varie selon la géométrie de la forme.

Cet exemple attache le connecteur à un site particulier sur l’ellipse lorsqu’il existe :

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

## **Ajuster un point de connecteur**

Les connecteurs avec points d’ajustement les exposent via [IGeometryShape.Adjustments](https://reference.aspose.com/slides/fr/net/aspose.slides/igeometryshape/adjustments/). Inspectez chaque [IAdjustValue](https://reference.aspose.com/slides/fr/net/aspose.slides/iadjustvalue/) et vérifiez son [Type](https://reference.aspose.com/slides/fr/net/aspose.slides/adjustvalue/type/) avant de changer sa [RawValue](https://reference.aspose.com/slides/fr/net/aspose.slides/adjustvalue/rawvalue/). Les règles générales pour identifier les ajustements de forme présélectionnés sont décrites dans [Shape Manipulation](/slides/fr/net/shape-manipulations/).

Le nombre, l’ordre, la signification et l’intervalle de valeurs valides des ajustements de connecteur dépendent de la présélection du connecteur. La propriété `Type` est en lecture seule, tandis que la valeur d’ajustement est modifiable. La propriété en lecture seule [Name](https://reference.aspose.com/slides/fr/net/aspose.slides/adjustvalue/name/) fournit une identification supplémentaire lorsqu’un connecteur contient plusieurs ajustements du même type sémantique.

### **Contourner un obstacle**

Dans la disposition suivante, un connecteur `BentConnector5` entre deux formes passe à travers une troisième forme :

![connector-obstruction](connector-obstruction.png)

Ce code crée le connecteur obstrué :

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

Déplacer la courbure verticale change l’itinéraire de façon que le connecteur évite l’obstacle :

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Au lieu de supposer que l’index de collection `1` représente toujours la courbure verticale, cet exemple recherche `ConnectorBendPositionY` et ne le modifie que lorsque le type sémantique attendu est présent :

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

Un `BentConnector5` possède deux ajustements `ConnectorBendPositionX` et un ajustement `ConnectorBendPositionY`. Si le type dont vous avez besoin apparaît plusieurs fois, inspectez `Name` et la géométrie connue de cette présélection avant d’en choisir un. Si un ajustement rapporte `ShapeAdjustmentType.Custom`, considérez sa signification et son intervalle comme spécifiques à la présélection et ne le modifiez pas tant que le contrat n’est pas connu.

## **Relier les valeurs d'ajustement à la géométrie du connecteur**

Pour les connecteurs coudés, les valeurs d’ajustement peuvent être utilisées pour estimer les positions des segments individuels. Ces calculs sont spécifiques à la présélection du connecteur :

- `BentConnector4` expose généralement un ajustement `ConnectorBendPositionX` et un ajustement `ConnectorBendPositionY`.
- Pour ces positions de courbure, `RawValue / 100000f` produit la fraction de la largeur ou de la hauteur du cadre du connecteur utilisée dans les exemples ci‑dessous.
- Un cadre de connecteur peut être pivoté ou retourné, de sorte que les coordonnées du cadre doivent être transformées avant d’être comparées aux coordonnées de la diapositive.

Les exemples suivants utilisent `Type` pour identifier d’abord les ajustements. Ils ne traitent pas les index de collection comme des identifiants portables.

#### **Connecteur non pivoté**

La disposition initiale contient deux formes de texte reliées par un `BentConnector4` :

![connector-shape-complex](connector-shape-complex.png)

Cet exemple inspecte le connecteur et obtient ses ajustements de courbure horizontale et verticale :

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

Pour modifier les deux courbures, localisez chaque type attendu et modifiez les valeurs uniquement après les avoir toutes deux trouvées :

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

Le résultat est un connecteur dont les segments horizontaux et verticaux ont été déplacés :

![connector-adjusted-1](connector-adjusted-1.png)

Une fois les types sémantiques connus, leurs valeurs peuvent être converties en coordonnées du cadre du connecteur. Cet exemple dessine un rectangle fin sur le segment vertical contrôlé par les deux ajustements de courbure :

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

La forme guide indique le segment calculé :

![connector-adjusted-2](connector-adjusted-2.png)

#### **Connecteur tourné ou retourné**

Lorsque la même géométrie de connecteur est orientée verticalement, ses valeurs [Frame](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/frame/), [FlipH](https://reference.aspose.com/slides/fr/net/aspose.slides/shapeframe/fliph/) et [FlipV](https://reference.aspose.com/slides/fr/net/aspose.slides/shapeframe/flipv/) influencent la conversion des coordonnées du cadre du connecteur vers les coordonnées de la diapositive.

Cet exemple crée et ajuste le connecteur orienté verticalement :

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

Le connecteur ajusté apparaît verticalement entre les formes :

![connector-adjusted-3](connector-adjusted-3.png)

Pour un angle de rotation arbitraire `alpha`, faites pivoter un point du cadre du connecteur `(x, y)` autour du centre du cadre `(x0, y0)` :

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Le code suivant gère l’orientation à 90 degrés utilisée dans cet exemple et dessine un guide rouge sur le segment correspondant du connecteur :

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

Le guide rouge indique le segment calculé après la transformation des coordonnées :

![connector-adjusted-4](connector-adjusted-4.png)

Ces formules décrivent les présélections utilisées dans les exemples, pas un modèle universel de connecteur. Validez les types d’ajustement, l’orientation du cadre et les intervalles de valeurs avant d’appliquer le même calcul à une présélection différente.

## **Trouver l'angle de direction d'un connecteur**

La direction d’un connecteur droit peut être calculée à partir de sa largeur et de sa hauteur, en tenant compte des retournements horizontaux et verticaux. L’exemple suivant indique l’angle horaire à partir de l’axe horizontal positif dans les coordonnées de la diapositive :

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

**Comment savoir si un connecteur peut être attaché à une forme ?**

Vérifiez la propriété `ConnectionSiteCount` de la forme. Un compte positif signifie que la forme expose des sites de connexion. Validez l’indice de site sélectionné avant de l’attribuer à l’une ou l’autre extrémité du connecteur.

**Puis‑je identifier un ajustement de connecteur par son index de collection ?**

Un index n’est significatif que pour une présélection de connecteur connue et une organisation de collection donnée. Vérifiez `IAdjustValue.Type` avant de modifier une valeur, et utilisez `IAdjustValue.Name` comme information supplémentaire lorsqu’un même type sémantique apparaît plusieurs fois.

**Que se passe‑t‑il lorsqu’une forme connectée est supprimée ?**

L’extrémité du connecteur correspondante se détache. Le connecteur reste sur la diapositive et peut être supprimé, positionné comme une ligne libre, ou attaché à une autre forme.

**Les liaisons de connecteur sont‑elles conservées lorsqu’une diapositive est copiée ?**

Les liaisons sont généralement conservées lorsque les formes connectées sont copiées avec la diapositive. Si un connecteur est copié sans l’une de ses formes cibles, l’extrémité concernée doit être de nouveau attachée.