---
title: Forme Personnalisée
type: docs
weight: 20
url: /fr/net/custom-shape/
keywords: 
- forme
- forme personnalisée
- créer forme
- géométrie
- géométrie de forme
- chemin de géométrie
- points de chemin
- points d'édition
- PowerPoint
- présentation
- C#
- Aspose.Slides pour .NET
description: "Ajoutez une forme personnalisée à une présentation PowerPoint en .NET"
---

## Modifier une Forme en Utilisant des Points d'Édition

Considérez un carré. Dans PowerPoint, en utilisant **les points d'édition**, vous pouvez 

* déplacer le coin du carré vers l'intérieur ou l'extérieur
* spécifier la courbure pour un coin ou un point
* ajouter de nouveaux points au carré
* manipuler les points sur le carré, etc.

En gros, vous pouvez effectuer les tâches décrites sur n'importe quelle forme. Grâce aux points d'édition, vous pouvez modifier une forme ou créer une nouvelle forme à partir d'une forme existante.

## **Astuces d'Édition de Forme**

![overview_image](custom_shape_0.png)

Avant de commencer à éditer les formes PowerPoint à travers les points d'édition, vous voudrez peut-être considérer ces points concernant les formes :

* Une forme (ou son chemin) peut être fermée ou ouverte.
* Toutes les formes se composent d'au moins 2 points d'ancrage liés entre eux par des lignes.
* Une ligne est soit droite soit courbée. Les points d'ancrage déterminent la nature de la ligne.
* Les points d'ancrage se présentent sous la forme de points d'angle, de points droits ou de points lisses :
  * Un point d'angle est un point où 2 lignes droites se rejoignent à un angle.
  * Un point lisse est un point où 2 poignées existent en ligne droite et où les segments de la ligne se rejoignent dans une courbe lisse. Dans ce cas, toutes les poignées sont séparées du point d'ancrage par une distance égale.
  * Un point droit est un point où 2 poignées existent en ligne droite et où les segments de ligne se rejoignent dans une courbe lisse. Dans ce cas, les poignées ne doivent pas nécessairement être séparées du point d'ancrage par une distance égale.
* En déplaçant ou en modifiant les points d'ancrage (ce qui change l'angle des lignes), vous pouvez changer l'apparence d'une forme.

Pour éditer les formes PowerPoint à travers les points d'édition, **Aspose.Slides** fournit la classe [**GeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) et l'interface [**IGeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath).

* Une instance de [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) représente un chemin de géométrie de l'objet [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape).
* Pour récupérer le `GeometryPath` de l'instance `IGeometryShape`, vous pouvez utiliser la méthode [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/getgeometrypaths).
* Pour définir le `GeometryPath` pour une forme, vous pouvez utiliser ces méthodes : [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypath) pour *les formes solides* et [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypaths) pour *les formes composites*.
* Pour ajouter des segments, vous pouvez utiliser les méthodes sous [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath).
* En utilisant les propriétés [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/stroke) et [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/fillmode), vous pouvez définir l'apparence d'un chemin de géométrie.
* En utilisant la propriété [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/pathdata), vous pouvez récupérer le chemin de géométrie d'une `GeometryShape` comme un tableau de segments de chemin.
* Pour accéder à des options supplémentaires de personnalisation de la géométrie de la forme, vous pouvez convertir [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) en [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0)
* Utilisez les méthodes [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) et [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (de la classe [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil)) pour convertir [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) en [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) et vice versa.

## **Opérations d'Édition Simples**

Ce code C# vous montre comment

**Ajouter une ligne** à la fin d'un chemin

```csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Ajouter une ligne** à une position spécifiée sur un chemin :

```csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**Ajouter une courbe de Bézier cubique** à la fin d'un chemin :

```csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Ajouter une courbe de Bézier cubique** à la position spécifiée sur un chemin :

```csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**Ajouter une courbe de Bézier quadratique** à la fin d'un chemin :

```csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Ajouter une courbe de Bézier quadratique** à une position spécifiée sur un chemin :

```csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**Ajouter un arc donné** à un chemin :

```csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Fermer la figure actuelle** d'un chemin :

```csharp
void CloseFigure();
```
**Définir la position pour le prochain point** :

```csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Supprimer le segment de chemin** à un index donné :

```csharp
void RemoveAt(int index);
```

## **Ajouter des Points Personnalisés à une Forme**

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) et définissez le type [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype).
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) à partir de la forme.
3. Ajoutez un nouveau point entre les deux points supérieurs sur le chemin.
4. Ajoutez un nouveau point entre les deux points inférieurs sur le chemin.
5. Appliquez le chemin à la forme.

Ce code C# vous montre comment ajouter des points personnalisés à une forme :

```csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;
    IGeometryPath geometryPath = shape.GetGeometryPaths()[0];

    geometryPath.LineTo(100, 50, 1);
    geometryPath.LineTo(100, 50, 4);
    shape.SetGeometryPath(geometryPath);
}
```

![example1_image](custom_shape_1.png)

##  **Supprimer des Points de la Forme**

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) et définissez le type [ShapeType.Heart](https://reference.aspose.com/slides/net/aspose.slides/shapetype).
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) à partir de la forme.
3. Supprimez le segment pour le chemin.
4. Appliquez le chemin à la forme.

Ce code C# vous montre comment supprimer des points d'une forme :

```csharp
using (Presentation pres = new Presentation())
{
	GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

	IGeometryPath path = shape.GetGeometryPaths()[0];
	path.RemoveAt(2);
	shape.SetGeometryPath(path);
}
```
![example2_image](custom_shape_2.png)

##  **Créer une Forme Personnalisée**

1. Calculez les points pour la forme.
2. Créez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).
3. Remplissez le chemin avec les points.
4. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).
5. Appliquez le chemin à la forme.

Ce code C# vous montre comment créer une forme personnalisée :

```csharp
List<PointF> points = new List<PointF>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.Cos(radians);
    double y = R * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.Cos(radians);
    y = r * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (int i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2) as GeometryShape;

    shape.SetGeometryPath(starPath);
}
```
![example3_image](custom_shape_3.png)

## **Créer une Forme Personnalisée Composite**

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).
2. Créez une première instance de la classe [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).
3. Créez une seconde instance de la classe [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).
4. Appliquez les chemins à la forme.

Ce code C# vous montre comment créer une forme personnalisée composite :

```csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.MoveTo(0, 0);
    geometryPath0.LineTo(shape.Width, 0);
    geometryPath0.LineTo(shape.Width, shape.Height/3);
    geometryPath0.LineTo(0, shape.Height / 3);
    geometryPath0.CloseFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.MoveTo(0, shape.Height/3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height / 3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height);
    geometryPath1.LineTo(0, shape.Height);
    geometryPath1.CloseFigure();

    shape.SetGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
}
```
![example4_image](custom_shape_4.png)

## **Créer une Forme Personnalisée avec des Coins Arrondis**

Ce code C# vous montre comment créer une forme personnalisée avec des coins arrondis (vers l'intérieur) :

```csharp
var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using (var presentation = new Presentation())
{
    var childShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    var geometryPath = new GeometryPath();

    var point1 = new PointF(leftTopSize, 0);
    var point2 = new PointF(shapeWidth - rightTopSize, 0);
    var point3 = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    var point4 = new PointF(leftBottomSize, shapeHeight);
    var point5 = new PointF(0, leftTopSize);

    geometryPath.MoveTo(point1);
    geometryPath.LineTo(point2);
    geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.LineTo(point3);
    geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.LineTo(point4);
    geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.LineTo(point5);
    geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.CloseFigure();

    childShape.SetGeometryPath(geometryPath);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Déterminer si la Géométrie d'une Forme est Fermée**

Vérifier si une forme dans une présentation PowerPoint est fermée peut être crucial pour l'affichage correct et l'édition des objets sur les diapositives. Une forme fermée est définie comme un ensemble où tous ses côtés se rejoignent, formant une seule limite sans lacunes. Une telle forme peut être une simple forme géométrique ou un contour personnalisé complexe.

La fermeture d'une forme est importante pour effectuer diverses opérations, telles que le remplissage de couleur ou de dégradé, l'application d'effets et de transformations, et pour assurer une interaction appropriée avec d'autres éléments de la diapositive.

Pour vérifier si la géométrie d'une forme est fermée, vous devez faire ce qui suit :
1. Obtenez l'accès à la géométrie de la forme.
2. Énumérez les chemins de géométrie dans la forme.
    2.1. Obtenez le dernier segment du chemin suivant.
    2.2. Vérifiez si le dernier segment est la commande `CLOSE`.

L'exemple de code suivant montre comment faire cela :

```csharp
if (shape is GeometryShape geometryShape)
{
    for (int i = 0; i < geometryShape.GetGeometryPaths().Length; i++)
    {
        IGeometryPath path = geometryShape.GetGeometryPaths()[i];

        if (path.PathData.Length == 0) continue;

        IPathSegment lastSegment = path.PathData[path.PathData.Length - 1];
        bool isClosed = lastSegment.PathCommand == PathCommandType.Close;
        
        Console.WriteLine($"Le chemin {i} est fermé : {isClosed}");
    }
}
```

## **Convertir GeometryPath en GraphicsPath (System.Drawing.Drawing2D)** 

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).
2. Créez une instance de la classe [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) du namespace [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
3. Convertissez l'instance [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) en instance [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) en utilisant [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil).
4. Appliquez les chemins à la forme.

Ce code C#—une implémentation des étapes ci-dessus—démontre le processus de conversion de **GeometryPath** à **GraphicsPath** :

```csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("Texte dans la forme", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```
![example5_image](custom_shape_5.png)