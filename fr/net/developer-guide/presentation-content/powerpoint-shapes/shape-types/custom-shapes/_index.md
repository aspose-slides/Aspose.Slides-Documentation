---
title: Personnaliser les formes de présentation dans .NET
linktitle: Forme personnalisée
type: docs
weight: 20
url: /fr/net/custom-shape/
keywords:
- forme personnalisée
- ajouter forme
- créer forme
- modifier forme
- géométrie de forme
- chemin géométrique
- points du chemin
- éditer les points
- ajouter point
- supprimer point
- opération d'édition
- coin arrondi
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créer et personnaliser des formes dans les présentations PowerPoint avec Aspose.Slides pour .NET : chemins géométriques, coins arrondis, formes composites."
---
## **Vue d'ensemble**

Cet article explique comment personnaliser les formes de présentation dans Aspose.Slides en modifiant la géométrie des formes à l'aide de points d'édition et de chemins géométriques. Il montre comment travailler avec [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) et [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) pour modifier des formes existantes, effectuer des opérations d'édition de chemin de base, ajouter ou supprimer des points, et appliquer la géométrie mise à jour à une forme.

Il montre également comment créer des formes personnalisées et composites, construire des formes avec des coins incurvés, déterminer si la géométrie d’une forme est fermée, et utiliser la conversion héritée entre [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) et [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) pour des scénarios supplémentaires de personnalisation de la géométrie.

## **Modifier une forme à l'aide de points d'édition**

Dans PowerPoint, vous pouvez utiliser **Edit Points** pour modifier un carré :

* Déplacer un coin vers l’intérieur ou vers l’extérieur.
* Ajuster la courbure d’un point.
* Ajouter de nouveaux points.

La modification des points vous permet de modifier le contour d’une forme ou d’utiliser une forme existante comme base pour une nouvelle.

## **Conseils d’édition de forme**

![overview_image](custom_shape_0.png)

Lors de l’édition des formes PowerPoint, gardez à l’esprit les concepts suivants :

* Une forme (ou son chemin) peut être fermée ou ouverte.
* Le chemin d’une forme est constitué de points d’ancrage reliés par des segments.
* Un segment peut être droit ou courbe. Les points d’ancrage et les poignées de contrôle déterminent sa forme.
* Les points d’ancrage existent comme points de coin, points droits ou points lisses :
  - Dans un point de coin, les segments adjacents peuvent se rencontrer à un angle.
  - Dans un point lisse, les deux poignées de contrôle sont alignées et à égale distance du point d’ancrage.
  - Dans un point droit, les deux poignées de contrôle sont alignées mais peuvent être à des distances différentes du point d’ancrage.
* Déplacer les points d’ancrage ou ajuster leurs poignées modifie le contour de la forme.

Pour modifier les formes PowerPoint via les points d’édition, **Aspose.Slides** fournit la classe [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) et l’interface [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* Une instance [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) représente un chemin géométrique de l’objet [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* Pour récupérer le [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) à partir de l’instance [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/), vous pouvez utiliser la méthode [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).
* Pour définir le [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) d’une forme, vous pouvez utiliser ces méthodes : [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) pour les formes à chemin unique et [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) pour les formes à chemins multiples.
* Pour ajouter des segments, vous pouvez utiliser les méthodes sous [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* En utilisant les propriétés [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) et [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/), vous pouvez définir l’apparence d’un chemin géométrique.
* En utilisant la propriété [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/), vous pouvez récupérer le chemin géométrique d’un [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) sous forme de tableau de segments de chemin.
* Dans les versions héritées qui prennent en charge les méthodes de conversion ci‑dessous, vous pouvez convertir [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) en [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* Utilisez les méthodes [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) et [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (de la classe [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) pour convertir entre [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) et [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **Opérations d’édition simples**

Utilisez les méthodes suivantes pour éditer un chemin géométrique. Les surcharges qui acceptent un indice insèrent un segment à cette position indexée à zéro dans le tableau de segments du chemin.

| Opération | Méthode |
| --- | --- |
| Ajouter ou insérer une ligne droite. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Ajouter ou insérer une courbe de Bézier cubique avec deux points de contrôle et un point final. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Ajouter ou insérer une courbe de Bézier quadratique avec un point de contrôle et un point final. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Ajouter un arc elliptique avec les dimensions et angles spécifiés en degrés. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Fermer la figure courante en reliant son point final à son point de départ. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Définir le point de départ d’une figure. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Supprimer un segment à un indice basé sur zéro. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Ajouter des points personnalisés à une forme**

Cet exemple insère deux points dans une forme rectangulaire en utilisant [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) et applique le chemin édité avec [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). Les coordonnées sont locales à la forme : les deux nouveaux points sont au centre, à 100 points du bord gauche et 50 points du haut. Les indices de segment 1 et 4 les placent sur les bords supérieur et inférieur, tirant ces bords vers l’intérieur.

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

## **Supprimer des points d’une forme**

Cet exemple modifie le contour d’une forme en forme de cœur en supprimant le segment à l’indice 2 (indexé à zéro) avec [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). Appliquer le chemin modifié avec [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) met à jour le contour de la forme.

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

## **Créer une forme personnalisée**

Cet exemple crée une étoile à cinq points avec [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). Des rayons extérieurs et intérieurs alternés de 100 et 50 points définissent les pointes et les indentations ; un pas de 72 degrés espace uniformément les cinq pointes. Le chemin est fermé avec [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) et appliqué à une forme rectangulaire à l’aide de [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), remplaçant son contour.

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

## **Créer une forme personnalisée composite**

Cet exemple définit deux objets [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) fermés pour le tiers supérieur et inférieur d’une forme. Appliquer les deux chemins avec [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) crée une forme composite unique avec un espace traversant le tiers central.

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

## **Créer une forme personnalisée avec des coins courbés**

Cet exemple combine des segments droits avec [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) pour créer une forme aux coins incurvés vers l’intérieur. La taille de chaque coin définit la largeur et la hauteur de l’arc en points, et la rotation de -90 degrés trace un quart d’ellipse dans le sens inverse des aiguilles d’une montre. Le chemin terminé est appliqué avec [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), et la présentation est enregistrée au format PPTX.

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

## **Déterminer si la géométrie d’une forme est fermée**

L’assistant suivant vérifie si chaque chemin géométrique non vide se termine par un segment de clôture. Il lit [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) et compare la commande du segment final [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) avec [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Il renvoie false lorsqu’il n’y a aucun chemin non vide. Cette vérification porte sur la commande finale de chaque chemin ; elle n’inspecte pas chaque sous‑figure au sein d’un chemin. L’exemple affiche `True` pour un rectangle.

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

## **Extraire et inspecter les éléments de forme**

Utilisez [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) pour inspecter une forme existante sous forme d’éléments contenant des points de chemin et des types de points. Convertissez chaque [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) renvoyé en [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) pour lire ses tableaux [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) et [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/). Cette représentation est utile pour l’analyse de contours ou le passage de la géométrie à des outils de dessin personnalisés.

L’exemple ouvre une présentation, trouve la première forme géométrique directement sur la première diapositive, et affiche ses segments de chemin. Utilisez une présentation contenant une forme avec des segments droits et courbés pour voir les deux types de sortie. Il ne recherche pas à l’intérieur des groupes.

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
        var pointType = types[i] & 0x07; // Conserver le type de segment, en excluant les indicateurs.
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

Les tableaux correspondent par indice : `points[i]` est un point et `types[i]` décrit son rôle. Le type `0` démarre une figure, et le type `1` trace une ligne du point précédent au point actuel. Un segment de Bézier cubique commence au point final précédent et utilise trois entrées consécutives de type `3` : deux points de contrôle suivis du nouveau point final. La boucle consomme ces trois entrées ensemble et vérifie la fermeture du point final.

Les types de points contiennent également des indicateurs. Masquez avec `0x07` pour identifier le type de segment, et testez `0x80` séparément pour détecter un sous‑chemin fermé. Par exemple, `129` (`0x81`) signifie un point final de ligne qui ferme un sous‑chemin, et `131` (`0x83`) signifie un point final de Bézier qui le ferme. Comparer la valeur brute uniquement avec `1` ou `3` manquerait ces cas. D’autres indicateurs, comme le tiret (`0x10`) et le marqueur (`0x20`), ne modifient pas le type de segment de base.

**Coordonnées et transformations.** Les points sont mesurés en points (1/72 pouce), X augmente vers la droite et Y augmente vers le bas. Pour une forme non groupée, les coordonnées extraites incluent déjà sa position [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) et [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) et reflètent sa largeur et hauteur actuelles. Par exemple, un rectangle non tourné à `(100, 200)` avec une taille de `120 × 80` a des limites de contour `(100, 200)`–`(220, 280)`. N’ajoutez pas de nouveau la position de la forme. Soustrayez son X et Y pour obtenir des coordonnées relatives à son cadre non tourné.

Les points extraits n’appliquent pas la [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) de la forme ni les retournements horizontaux et verticaux. Pour reproduire le contour affiché, appliquez ces transformations autour du centre de la forme. Pour les formes groupées, tenez également compte du mappage des coordonnées du groupe et des transformations ; ne supposez pas que les points extraits sont les coordonnées finales rendues sur la diapositive ou n’appliquez pas une translation ou une mise à l’échelle deux fois si elle est déjà reflétée dans le cadre de l’enfant.

**Inspection versus édition.** Les tableaux extraits décrivent le contour ; les modifier ne met pas à jour la forme originale. Choisissez cette approche lorsque votre analyse ou votre code de dessin a besoin de tableaux point/type. Utilisez [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) lorsque vous avez besoin des commandes de géométrie dans le système de coordonnées local de la forme ou que vous souhaitez éditer sa géométrie. Appliquez les chemins édités via [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) ou [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **Convertir GeometryPath en GraphicsPath (System.Drawing.Drawing2D)**

L’exemple suivant nécessite une version héritée de l’assembly Aspose.Slides for .NET qui prend en charge [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/), comme la version 25.10, et un environnement Windows avec `System.Drawing.Common`. Les méthodes de conversion ont été supprimées dans la [version 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

Cet exemple combine un contour rectangulaire avec du texte converti en géométrie. Le [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) du contour est défini pour désactiver son remplissage. Un [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) stocke le contour du texte, que [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) convertit en un chemin géométrique rempli. Appliquer les deux chemins avec [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) produit une forme unique contenant le rectangle et le texte. Pour la conversion dans le sens inverse, utilisez [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

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

## **FAQ**

**Que se passe-t-il du remplissage et du contour après le remplacement de la géométrie ?**

Le style reste avec la forme ; seul le contour change. Le remplissage et le contour sont appliqués automatiquement à la nouvelle géométrie.

**Comment faire pivoter correctement une forme personnalisée avec sa géométrie ?**

Utilisez la propriété [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) de la forme ; la géométrie tourne avec la forme car elle est liée au système de coordonnées propre de la forme.

**Puis-je convertir une forme personnalisée en image pour « verrouiller » le résultat ?**

Oui. Exportez la zone [slide](/slides/fr/net/convert-powerpoint-to-png/) requise ou la [shape](/slides/fr/net/create-shape-thumbnails/) elle‑même vers un format raster ; cela simplifie le travail ultérieur avec des géométries complexes.