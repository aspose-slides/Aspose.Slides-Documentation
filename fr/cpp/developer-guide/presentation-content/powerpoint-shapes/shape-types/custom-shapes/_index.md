---
title: Personnaliser les formes de présentation en C++
linktitle: Forme personnalisée
type: docs
weight: 20
url: /fr/cpp/custom-shape/
keywords:
- forme personnalisée
- ajouter une forme
- créer une forme
- modifier une forme
- géométrie de forme
- chemin géométrique
- points du chemin
- points d'édition
- ajouter un point
- supprimer un point
- opération d'édition
- coin arrondi
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Créer et personnaliser des formes dans les présentations PowerPoint avec Aspose.Slides pour C++: chemins géométriques, coins arrondis, formes composites."
---

## **Modifier une forme à l'aide des points d'édition**
Considérez un carré. Dans PowerPoint, en utilisant **points d'édition**, vous pouvez 

* déplacer le coin du carré vers l'intérieur ou l'extérieur
* spécifier la courbure d'un coin ou d'un point
* ajouter de nouveaux points au carré
* manipuler les points du carré, etc. 

Essentiellement, vous pouvez effectuer ces tâches sur n'importe quelle forme. Avec les points d'édition, vous pouvez modifier une forme ou créer une nouvelle forme à partir d'une forme existante. 

## **Conseils pour l'édition de formes**

![overview_image](custom_shape_0.png)

Avant de commencer à modifier les formes PowerPoint à l'aide des points d'édition, vous voudrez peut‑être prendre en compte les points suivants concernant les formes :

* Une forme (ou son tracé) peut être fermée ou ouverte.
* Lorsqu'une forme est fermée, elle n'a pas de point de départ ou d'arrivée. Lorsqu'une forme est ouverte, elle possède un début et une fin. 
* Toutes les formes comportent au moins 2 points d'ancrage reliés entre eux par des lignes
* Une ligne est soit droite, soit courbe. Les points d'ancrage déterminent la nature de la ligne. 
* Les points d'ancrage existent sous forme de points d'angle, de points droits ou de points lisses :
  * Un point d'angle est un point où 2 lignes droites se rejoignent sous un angle. 
  * Un point lisse est un point où 2 poignées existent sur une ligne droite et les segments de la ligne se rejoignent en une courbe fluide. Dans ce cas, toutes les poignées sont séparées du point d'ancrage par une distance égale. 
  * Un point droit est un point où 2 poignées existent sur une ligne droite et les segments de cette ligne se rejoignent en une courbe fluide. Dans ce cas, les poignées n'ont pas besoin d'être séparées du point d'ancrage par une distance égale. 
* En déplaçant ou en modifiant les points d'ancrage (ce qui change l'angle des lignes), vous pouvez modifier l'apparence d'une forme. 

Pour modifier les formes PowerPoint via les points d'édition, **Aspose.Slides** fournit la classe [**GeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) et l'interface [**IGeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path). 

* Une instance de [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) représente un chemin géométrique de l'objet [IGeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape). 
* Pour récupérer le`GeometryPath` de l'instance `IGeometryShape`, vous pouvez utiliser la méthode [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1). 
* Pour définir le `GeometryPath` d'une forme, vous pouvez utiliser ces méthodes : [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) pour les *formes pleines* et [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) pour les *formes composites*.
* Pour ajouter des segments, vous pouvez utiliser les méthodes de [IGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path). 
* En utilisant les méthodes [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) et [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7), vous pouvez définir l'apparence d'un chemin géométrique.
* En utilisant la méthode [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca), vous pouvez récupérer le chemin géométrique d'un `GeometryShape` sous forme de tableau de segments de chemin. 
* Pour accéder à des options supplémentaires de personnalisation de la géométrie des formes, vous pouvez convertir [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) en [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path)
* Utilisez les méthodes [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) et [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) (de la classe [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util)) pour convertir [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) en [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) et inversement. 

## **Opérations d'édition simples**

Ce code C++ vous montre comment

**Ajouter une ligne** à la fin d'un chemin
``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```

**Ajouter une ligne** à une position spécifiée sur un chemin :
``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```

**Ajouter une courbe de Bézier cubique** à la fin d'un chemin :
``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```

**Ajouter une courbe de Bézier cubique** à la position spécifiée sur un chemin :
``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```

**Ajouter une courbe de Bézier quadratique** à la fin d'un chemin :
``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```

**Ajouter une courbe de Bézier quadratique** à la position spécifiée sur un chemin :
``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```

**Ajouter un arc donné** à un chemin :
``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```

**Fermer la figure courante** d'un chemin :
``` cpp
void CloseFigure();
```

**Définir la position du point suivant** :
``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```

**Supprimer le segment de chemin** à un indice donné :
``` cpp
void RemoveAt(int32_t index);
```


## **Ajouter des points personnalisés à une forme**

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) et définissez le type [ShapeType.Rectangle](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) à partir de la forme.
3. Ajoutez un nouveau point entre les deux points supérieurs du chemin.
4. Ajoutez un nouveau point entre les deux points inférieurs du chemin.
5. Appliquez le chemin à la forme.

Ce code C++ vous montre comment ajouter des points personnalisés à une forme :
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath = shape->GetGeometryPaths()->idx_get(0);

geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);
shape->SetGeometryPath(geometryPath);
```


![example1_image](custom_shape_1.png)

## **Supprimer des points d'une forme**

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) et définissez le type [ShapeType.Heart](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5). 
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) à partir de la forme.
3. Supprimez le segment du chemin.
4. Appliquez le chemin à la forme.

Ce code C++ vous montre comment supprimer des points d'une forme :
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```

![example2_image](custom_shape_2.png)

## **Créer une forme personnalisée**

1. Calculez les points de la forme.
2. Créez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path). 
3. Remplissez le chemin avec les points.
4. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape). 
5. Appliquez le chemin à la forme.

Ce code C++ vous montre comment créer une forme personnalisée :
``` cpp
SharedPtr<List<PointF>> points = System::MakeObject<List<PointF>>();

float R = 100.0f, r = 50.0f;
int32_t step = 72;

for (int32_t angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math::PI / 180.f);
    double x = outerRadius * Math::Cos(radians);
    double y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + step / 2) / 180.0;
    x = innerRadiusr * Math::Cos(radians);
    y = innerRadiusr * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

SharedPtr<GeometryPath> starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (int32_t i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, R * 2, R * 2));

shape->SetGeometryPath(starPath);
```

![example3_image](custom_shape_3.png)


## **Créer une forme personnalisée composite**

  1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).
  2. Créez une première instance de la classe [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).
  3. Créez une deuxième instance de la classe [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).
  4. Appliquez les chemins à la forme.

Ce code C++ vous montre comment créer une forme personnalisée composite :
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath0 = System::MakeObject<GeometryPath>();
geometryPath0->MoveTo(0.0f, 0.0f);
geometryPath0->LineTo(shape->get_Width(), 0.0f);
geometryPath0->LineTo(shape->get_Width(), shape->get_Height() / 3);
geometryPath0->LineTo(0.0f, shape->get_Height() / 3);
geometryPath0->CloseFigure();

SharedPtr<IGeometryPath> geometryPath1 = System::MakeObject<GeometryPath>();
geometryPath1->MoveTo(0.0f, shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height());
geometryPath1->LineTo(0.0f, shape->get_Height());
geometryPath1->CloseFigure();

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ geometryPath0, geometryPath1 }));
```

![example4_image](custom_shape_4.png)

## **Créer une forme personnalisée avec coins arrondis**

Ce code C++ vous montre comment créer une forme personnalisée avec des coins arrondis (vers l'intérieur) ;
```cpp
float shapeX = 20.f;
float shapeY = 20.f;
float shapeWidth = 300.f;
float shapeHeight = 200.f;

float leftTopSize = 50.f;
float rightTopSize = 20.f;
float rightBottomSize = 40.f;
float leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();

auto childShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto geometryPath = System::MakeObject<GeometryPath>();

PointF point1(leftTopSize, 0.0f);
PointF point2(shapeWidth - rightTopSize, 0.0f);
PointF point3(shapeWidth, shapeHeight - rightBottomSize);
PointF point4(leftBottomSize, shapeHeight);
PointF point5(0.0f, leftTopSize);

geometryPath->MoveTo(point1);
geometryPath->LineTo(point2);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(point3);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(point4);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(point5);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);

geometryPath->CloseFigure();

childShape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **Déterminer si la géométrie d'une forme est fermée**

Une forme fermée est définie comme une forme dont tous les côtés sont connectés, formant une seule frontière sans lacunes. Une telle forme peut être une forme géométrique simple ou un contour personnalisé complexe. L'exemple de code suivant montre comment vérifier si la géométrie d'une forme est fermée :
```cpp
bool IsGeometryClosed(SharedPtr<IGeometryShape> geometryShape)
{
    bool isClosed = false;

    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto dataLength = geometryPath->get_PathData()->get_Length();
        if (dataLength == 0)
            continue;

        auto lastSegment = geometryPath->get_PathData()[dataLength - 1];
        isClosed = lastSegment->get_PathCommand() == PathCommandType::Close;

        if (!isClosed)
            return false;
    }

    return isClosed;
}
```


## **Convertir GeometryPath en GraphicsPath**

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).
2. Créez une instance de la classe [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) du namespace [System.Drawing.Drawing2D](https://reference.aspose.com/slides/cpp/namespace/system.drawing.drawing2_d).
3. Convertissez l'instance [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) en instance [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) en utilisant [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util).
4. Appliquez les chemins à la forme.

Ce code C++—une implémentation des étapes ci‑dessus—dé montre le processus de conversion de **GeometryPath** en **GraphicsPath** :
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 100.0f));

SharedPtr<IGeometryPath> originalPath = shape->GetGeometryPaths()->idx_get(0);
originalPath->set_FillMode(PathFillModeType::None);

SharedPtr<Drawing2D::GraphicsPath> graphicsPath = System::MakeObject<Drawing2D::GraphicsPath>();
graphicsPath->AddString(u"Text in shape", System::MakeObject<FontFamily>(u"Arial"), 1, 40.0f, PointF(10.0f, 10.0f), StringFormat::get_GenericDefault());

SharedPtr<IGeometryPath> textPath = ShapeUtil::GraphicsPathToGeometryPath(graphicsPath);
textPath->set_FillMode(PathFillModeType::Normal);

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ originalPath, textPath }));
```

![example5_image](custom_shape_5.png)

## **FAQ**

**Que se passe-t-il du remplissage et du contour après le remplacement de la géométrie ?**

Le style reste associé à la forme ; seul le contour change. Le remplissage et le contour sont appliqués automatiquement à la nouvelle géométrie.

**Comment faire pivoter correctement une forme personnalisée avec sa géométrie ?**

Utilisez la propriété [rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) de la forme ; la géométrie pivote avec la forme car elle est liée au système de coordonnées de la forme.

**Puis‑je convertir une forme personnalisée en image pour « verrouiller » le résultat ?**

Oui. Exportez la zone de la [diapositive](/slides/fr/cpp/convert-powerpoint-to-png/) requise ou la [forme](/slides/fr/cpp/create-shape-thumbnails/) elle‑même vers un format raster ; cela simplifie le travail ultérieur avec des géométries lourdes.