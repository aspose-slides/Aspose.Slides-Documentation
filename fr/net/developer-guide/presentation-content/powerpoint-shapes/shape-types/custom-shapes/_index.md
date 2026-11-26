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
- chemin de géométrie
- points du chemin
- points d'édition
- ajouter point
- supprimer point
- opération d'édition
- coin arrondi
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créer et personnaliser des formes dans les présentations PowerPoint avec Aspose.Slides pour .NET : chemins de géométrie, coins arrondis, formes composites."
---
## **Aperçu**

Cet article explique comment personnaliser les formes de présentation dans Aspose.Slides en modifiant la géométrie des formes à l'aide de points d'édition et de chemins géométriques. Il montre comment travailler avec [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) et [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) pour modifier des formes existantes, effectuer des opérations de base d'édition de chemin, ajouter ou supprimer des points, et appliquer la géométrie mise à jour à une forme.

Il montre également comment créer des formes personnalisées et composites, construire des formes avec des coins arrondis, déterminer si la géométrie d'une forme est fermée, et utiliser la conversion historique entre [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) et [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) pour des scénarios supplémentaires de personnalisation de la géométrie.

## **Modifier une forme à l'aide de points d'édition**

Dans PowerPoint, vous pouvez utiliser **Edit Points** pour modifier un carré :

* Deplacer un coin vers l'intérieur ou l'extérieur.
* Ajuster la courbure en un point.
* Ajouter de nouveaux points.

La modification des points vous permet de modifier le contour d'une forme ou d'utiliser une forme existante comme base pour une nouvelle.

## **Conseils pour l'édition de formes**

![overview_image](custom_shape_0.png)

Lorsque vous éditez des formes PowerPoint, gardez ces concepts a l'esprit :

* Une forme (ou son chemin) peut être ferme ou ouverte.
* Le chemin d'une forme se compose de points d'ancrage relies par des segments.
* Un segment peut etre droit ou courbe. Les points d'ancrage et les poignées de controle determinent sa forme.
* Les points d'ancrage existent sous forme de points d'angle, points droits ou points lisses :
  * En un point d'angle, les segments adjacents peuvent se rejoindre a un angle.
  * En un point lisse, les deux poignes de controle sont alignees et a egale distance du point d'ancrage.
  * En un point droit, les deux poignes de controle sont alignees mais peuvent etre a des distances differentes du point d'ancrage.
* Deplacer les points d'ancrage ou ajuster leurs poignes modifie le contour de la forme.

Pour editer les formes PowerPoint via les points d'edition, **Aspose.Slides** fournit la classe [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) et l'interface [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* Une instance de [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) représente un chemin geometrique de l'objet [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* Pour recuperer le [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) depuis l'instance [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/), vous pouvez utiliser la methode [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).
* Pour definir le [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) d'une forme, vous pouvez utiliser ces methodes: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) pour les formes a chemin unique et [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) pour les formes a chemins multiples.
* Pour ajouter des segments, vous pouvez utiliser les methodes de [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* En utilisant les proprietes [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) et [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/), vous pouvez definir l'apparence d'un chemin geometrique.
* En utilisant la propriete [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/), vous pouvez recuperer le chemin geometrique d'un [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) sous forme de tableau de segments de chemin.
* Dans les versions heritees qui supportent les methodes de conversion ci-dessous, vous pouvez convertir [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) en [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* Utilisez les methodes [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) et [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (de la classe [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) pour convertir entre [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) et [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **Opérations d'edition simples**

Utilisez les methodes suivantes pour editer un chemin geometrique. Les surcharges qui acceptent un indice inserent un segment a cette position basee sur zero dans le tableau des segments du chemin.

| Operation | Method |
| --- | --- |
| Ajouter ou inserer une ligne droite. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Ajouter ou inserer une courbe de Bezier cubique avec deux points de controle et un point final. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Ajouter ou inserer une courbe de Bezier quadratique avec un point de controle et un point final. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Ajouter un arc elliptique avec les dimensions et angles specifies en degres. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Fermer la figure en cours en connectant son point final a son point de depart. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Definir le point de depart d'une figure. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Supprimer un segment a un indice base sur zero. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Ajouter des points personnalises a une forme**

Cet exemple insere deux points dans une forme rectangulaire en utilisant [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) et applique le chemin edite avec [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). Les coordonnees sont locales a la forme: les deux nouveaux points sont a son centre, a 100 points du bord gauche et 50 points du haut. Les indices de segment 1 et 4 les placent respectivement sur les bords superieur et inferieur, tirant ces bords vers l'interieur.

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

## **Supprimer des points d'une forme**

Cet exemple modifie le contour d'une forme en forme de coeur en supprimant le segment a l'indice zero-based 2 avec [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). L'application du chemin modifie avec [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) met a jour le contour de la forme.

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

## **Creer une forme personnalisee**

Cet exemple cree une etoile a cinq branches avec [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). Des rayons exterieurs et interieurs alternant de 100 et 50 points definissent les pointes et les encoches; un pas de 72 degres espace uniformement les cinq pointes. Le chemin est ferme avec [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) et applique a une forme rectangulaire a l'aide de [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), remplaçant son contour.

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

## **Creer une forme composite personalisee**

Cet exemple definit deux objets [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) fermes pour le tiers superieur et inferieur d'une forme. L'application des deux chemins avec [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) cree une forme composite unique avec un espace au tiers central.

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

## **Creer une forme personalisee avec des coins arrondis**

Cet exemple combine des segments droits avec [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) pour creer une forme aux coins courbes vers l'interieur. Chaque taille de coin definit la largeur et la hauteur de l'arc en points, et le balayage de -90 degres dessine un quart d'ellipse dans le sens anti-horaire. Le chemin final est applique avec [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), et la presentation est enregistree au format PPTX.

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

## **Determiner si la geometrie d'une forme est fermee**

L'assistant suivant verifie si chaque chemin geometrique non vide se termine par un segment de fermeture. Il lit [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) et compare la commande du segment final [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) avec [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Il renvoie false lorsqu'il n'y a aucun chemin non vide. Cette verification porte sur la commande finale de chaque chemin; elle n'inspecte pas chaque sous-figure d'un chemin. L'exemple affiche `True` pour un rectangle.

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

## **Inspecter les commandes du chemin geometrique**

Telechargez [contour.pptx](contour.pptx) et placez-le dans le repertoire de travail de l'application. La premiere diapositive contient une forme avec un bord superieur droit, une courbe de Bezier cubique, et un bord de fermeture droit. Utilisez [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) pour lire ses chemins. Chaque chemin recense ses segments dans l'ordre de dessin dans [PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/). La [PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) de chaque segment determine comment lire son [SegmentData](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/segmentdata/).

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

La forme se trouve a (200, 100) points sur la diapositive. Les points rapportes sont locaux a la forme, avec (0, 0) dans son coin superieur gauche, x augmentant vers la droite et y augmentant vers le bas. Le segment de fermeture revient au point de depart sans coordonnees supplementaires.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![Forme PowerPoint avec un bord superieur droit, un bord courbe du coin superieur droit au coin inferieur gauche, et un bord gauche droit](contour.png)

## **Extraire et inspecter les elements de forme**

Utilisez [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) pour inspector une forme existante sous forme d'elements contenant des points de chemin et des types de points. Convertissez chaque [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) retourne en [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) pour lire ses tableaux [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) et [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/). Cette representation est utile pour l'analyse de contours ou le passage de la geometrie a des outils de dessin personnalises.

L'exemple ouvre une presentation, trouve la premiere forme geometrique directement sur la premiere diapositive, et affiche ses segments de chemin. Utilisez une presentation contenant une forme avec des segments droits et courbes pour voir les deux types de sortie. Il ne recherche pas a l'interieur des groupes.

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
                i += 2; // Consommer les deux points de contrôle ainsi que le point final.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

Les tableaux correspondent par indice: `points[i]` est un point et `types[i]` décrit son role. Le type `0` demarre une figure, et le type `1` trace une ligne du point precedent au point actuel. Un segment de Bezier cubique demarre a l'extremite precedente et utilise trois entrees consecutives de type `3`: deux points de controle follows du nouveau point final. La boucle consomme ces trois entrees ensemble et verifie la cloture du point final.

Les types de points contiennent egalement des indicateurs. Masquez avec `0x07` pour identifier le type de segment, et testez `0x80` separament pour detecter un sous-chemin ferme. Par exemple, `129` (`0x81`) signifie un point final de ligne qui ferme un sous-chemin, et `131` (`0x83`) signifie un point final de Bezier qui en ferme un. Comparer la valeur brute uniquement avec `1` ou `3` manquerait ces cas. D'autres indicateurs, comme le tiret (`0x10`) et le marqueur (`0x20`), ne modifient pas le type de segment de base.

**Coordonnees et transformations.** Les points sont mesures en points (1/72 pouce), X augmentant vers la droite et Y vers le bas. Pour une forme non groupée, les coordonnees extraites incluent deja sa position [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) et [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) et reflechent sa largeur et hauteur actuelles. Par exemple, un rectangle non tourne a `(100, 200)` avec une taille de `120 × 80` a des limites de contour `(100, 200)`-(`220, 280`). N'ajoutez pas a nouveau la position de la forme. Soustrayez son X et Y pour obtenir des coordonnees relatives a son cadre non tourne.

Les points extraits n'appliquent pas la [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) de la forme ni les retournements horizontaux et verticaux. Pour reproduire le contour affiche, appliquez ces transformations autour du centre de la forme. Pour les formes groupees, tenez egalement compte du mapping des coordonnees du groupe et des transformations; ne supposez pas que les points extraits sont les coordonnees finales rendues sur la diapositive ou que vous devez appliquer une translation ou une mise a l'echelle deux fois si elle est deja prise en compte dans le cadre de l'enfant.

**Inspection vs edition.** Les tableaux extraits describent le contour; les modifier ne met pas a jour la forme originale. Choisissez cette approche lorsque votre analyse ou votre code de dessin a besoin de tableaux point/type. Utilisez [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) lorsque vous avez besoin des commandes geometriques dans le systeme de coordonnees local de la forme ou souhaitez editer sa geometrie. Appliquez les chemins modifies via [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) ou [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **Convertir GeometryPath en GraphicsPath (System.Drawing.Drawing2D)**

L'exemple suivant necessite une version heritee de l'assembly Aspose.Slides for .NET qui supporte [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/), comme la version 25.10, ainsi qu'un environnement Windows avec `System.Drawing.Common`. Les methodes de conversion ont ete supprimees dans [version 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

Cet exemple combine un contour rectangulaire avec du texte converti en geometrie. Le [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) du contour est defini pour desactiver son remplissage. Un [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) stocke le contour du texte, que [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) convertit en un chemin geometrique rempli. L'application des deux chemins avec [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) produit une forme unique contenant le rectangle et le texte. Pour la conversion dans le sens inverse, utilisez [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

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

**Que se passera-t-il pour le remplissage et le contour apres avoir remplace la geometrie ?**

Le style reste associe a la forme ; seul le contour change. Le remplissage et le contour sont appliques automatiquement a la nouvelle geometrie.

**Comment faire pivoter correctement une forme personalisee avec sa geometrie ?**

Utilisez la propriete [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) de la forme ; la geometrie pivote avec la forme car elle est liee au systeme de coordonnees propre de la forme.

**Puis-je convertir une forme personnalisee en image pour « verrouiller » le resultat ?**

Oui. Exportez la zone de [slide](/slides/fr/net/convert-powerpoint-to-png/) requise ou la [shape](/slides/fr/net/create-shape-thumbnails/) elle-meme vers un format raster ; cela simplifie le travail ulterior avec des geometries complexes.