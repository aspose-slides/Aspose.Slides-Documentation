---
title: Personnaliser les formes de présentation en .NET
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

## **Modifier une forme à l’aide des points d'édition**

Considérez un carré. Dans PowerPoint, en utilisant **points d'édition**, vous pouvez

* déplacer le coin du carré vers l’intérieur ou l’extérieur
* spécifier la courbure d’un coin ou d’un point
* ajouter de nouveaux points au carré
* manipuler les points du carré, etc.

Essentiellement, vous pouvez effectuer les tâches décrites sur n’importe quelle forme. Grâce aux points d'édition, vous pouvez modifier une forme ou créer une nouvelle forme à partir d’une forme existante.

## **Conseils de modification de forme**

![overview_image](custom_shape_0.png)

Avant de commencer à modifier les formes PowerPoint via les points d'édition, vous pouvez prendre en compte les points suivants concernant les formes :

* Une forme (ou son tracé) peut être fermée ou ouverte.
* Toutes les formes sont composées d’au moins 2 points d’ancrage reliés entre eux par des lignes.
* Une ligne est soit droite, soit courbe. Les points d’ancrage déterminent la nature de la ligne. 
* Les points d’ancrage existent sous forme de points de coin, points droits ou points lisses :
  * Un point de coin est un point où 2 lignes droites se rejoignent à un angle. 
  * Un point lisse est un point où 2 poignées existent sur une ligne droite et les segments de ligne se rejoignent en une courbe fluide. Dans ce cas, toutes les poignées sont séparées du point d’ancrage par une distance égale. 
  * Un point droit est un point où 2 poignées existent sur une ligne droite et les segments de ligne se rejoignent en une courbe fluide. Dans ce cas, les poignées n’ont pas besoin d’être séparées du point d’ancrage par une distance égale. 
* En déplaçant ou en modifiant les points d’ancrage (ce qui change l’angle des lignes), vous pouvez modifier l’aspect d’une forme. 

Pour modifier les formes PowerPoint via les points d'édition, **Aspose.Slides** fournit la classe [**GeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) et l’interface [**IGeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath).

* Une instance de [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) représente le tracé géométrique de l’objet [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape). 
* Pour récupérer le `GeometryPath` à partir de l’instance `IGeometryShape`, vous pouvez utiliser la méthode [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/getgeometrypaths). 
* Pour définir le `GeometryPath` d’une forme, utilisez ces méthodes : [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypath) pour les *formes pleines* et [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypaths) pour les *formes composites*.
* Pour ajouter des segments, utilisez les méthodes de [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath). 
* En utilisant les propriétés [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/stroke) et [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/fillmode), vous pouvez définir l’apparence d’un tracé géométrique.
* En utilisant la propriété [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/pathdata), vous pouvez récupérer le tracé géométrique d’un `GeometryShape` sous forme de tableau de segments de tracé. 
* Pour accéder à des options supplémentaires de personnalisation de la géométrie de forme, vous pouvez convertir [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) en [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
* Utilisez les méthodes [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) et [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (de la classe [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil)) pour convertir [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) en [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) et inversement. 

## **Opérations d'édition simples**

Ce code C# montre comment

**Ajouter une ligne** à la fin d’un tracé
``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```

**Ajouter une ligne** à une position spécifiée sur un tracé :
``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```

**Ajouter une courbe de Bézier cubique** à la fin d’un tracé :
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```

**Ajouter une courbe de Bézier cubique** à la position spécifiée sur un tracé :
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```

**Ajouter une courbe de Bézier quadratique** à la fin d’un tracé :
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```

**Ajouter une courbe de Bézier quadratique** à la position spécifiée sur un tracé :
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```

**Ajouter un arc donné** à un tracé :
``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```

**Fermer la figure courante** d’un tracé :
``` csharp
void CloseFigure();
```

**Définir la position pour le prochain point** :
``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```

**Supprimer le segment de tracé** à un indice donné :
``` csharp
void RemoveAt(int index);
```


## **Ajouter des points personnalisés à une forme**

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) et définissez le type [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype).  
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) à partir de la forme.  
3. Ajoutez un nouveau point entre les deux points supérieurs du tracé.  
4. Ajoutez un nouveau point entre les deux points inférieurs du tracé.  
5. Appliquez le tracé à la forme.

Ce code C# montre comment ajouter des points personnalisés à une forme :
``` csharp
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

## **Supprimer des points d’une forme**

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) et définissez le type [ShapeType.Heart](https://reference.aspose.com/slides/net/aspose.slides/shapetype).  
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) à partir de la forme.  
3. Supprimez le segment du tracé.  
4. Appliquez le tracé à la forme.

Ce code C# montre comment supprimer des points d’une forme :
``` csharp
using (Presentation pres = new Presentation())
{
	GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

	IGeometryPath path = shape.GetGeometryPaths()[0];
	path.RemoveAt(2);
	shape.SetGeometryPath(path);
}
```


![example2_image](custom_shape_2.png)

## **Créer une forme personnalisée**

1. Calculez les points de la forme.  
2. Créez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).  
3. Remplissez le tracé avec les points.  
4. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).  
5. Appliquez le tracé à la forme.

Ce C# montre comment créer une forme personnalisée :
``` csharp
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

## **Créer une forme composite personnalisée**

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).  
2. Créez une première instance de la classe [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).  
3. Créez une deuxième instance de la classe [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).  
4. Appliquez les tracés à la forme.

Ce code C# montre comment créer une forme composite personnalisée :
``` csharp
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

## **Créer une forme personnalisée avec des coins arrondis**

Ce code C# montre comment créer une forme personnalisée avec des coins arrondis (vers l’intérieur) :
```c#
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


## **Déterminer si la géométrie d’une forme est fermée**

Une forme fermée est définie comme une forme dont tous les côtés se connectent, formant une seule frontière sans lacunes. Une telle forme peut être une forme géométrique simple ou un contour personnalisé complexe. L’exemple de code suivant montre comment vérifier si la géométrie d’une forme est fermée :
```cs
bool IsGeometryClosed(IGeometryShape geometryShape)
{
    bool? isClosed = null;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var dataLength = geometryPath.PathData.Length;
        if (dataLength == 0)
            continue;

        var lastSegment = geometryPath.PathData[dataLength - 1];
        isClosed = lastSegment.PathCommand == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }
    
    return isClosed == true;
}
```


## **Convertir GeometryPath en GraphicsPath (System.Drawing.Drawing2D)**

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).  
2. Créez une instance de la classe [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) du namespace [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).  
3. Convertissez l’instance [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) en instance [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) à l’aide de [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil).  
4. Appliquez les tracés à la forme.

Ce code C#—une implémentation des étapes ci‑above—dé montre le processus de conversion **GeometryPath** vers **GraphicsPath** :
``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("Text in shape", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```


![example5_image](custom_shape_5.png)

## **FAQ**

**Que se passe-t-il avec le remplissage et le contour après avoir remplacé la géométrie ?**

Le style reste attaché à la forme ; seul le contour change. Le remplissage et le contour sont appliqués automatiquement à la nouvelle géométrie.

**Comment faire pivoter correctement une forme personnalisée avec sa géométrie ?**

Utilisez la propriété [rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) de la forme ; la géométrie tourne avec la forme car elle est liée au système de coordonnées propre à la forme.

**Puis‑je convertir une forme personnalisée en image pour « verrouiller » le résultat ?**

Oui. Exportez la zone de la [diapositive](/slides/fr/net/convert-powerpoint-to-png/) requise ou la [forme](/slides/fr/net/create-shape-thumbnails/) elle‑même vers un format raster ; cela simplifie le travail ultérieur avec des géométries lourdes.