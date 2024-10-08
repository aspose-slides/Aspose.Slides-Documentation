---
title: Forme Personnalisée
type: docs
weight: 20
url: /fr/cpp/custom-shape/
keywords: "forme PowerPoint, forme personnalisée, présentation PowerPoint, C++, Aspose.Slides pour C++"
description: "Ajouter une forme personnalisée dans une présentation PowerPoint en C++"
---

# Modifier une Forme à l'Aide de Points d'Édition
Considérez un carré. Dans PowerPoint, en utilisant **des points d'édition**, vous pouvez 

* déplacer le coin du carré vers l'intérieur ou vers l'extérieur
* spécifier la courbure d'un coin ou d'un point
* ajouter de nouveaux points au carré
* manipuler les points sur le carré, etc. 

Essentiellement, vous pouvez effectuer les tâches décrites sur n'importe quelle forme. En utilisant des points d'édition, vous pouvez modifier une forme ou créer une nouvelle forme à partir d'une forme existante. 

## **Conseils pour Éditer des Formes**

![overview_image](custom_shape_0.png)

Avant de commencer à éditer des formes PowerPoint via des points d'édition, vous voudrez peut-être considérer ces points concernant les formes :

* Une forme (ou son chemin) peut être fermée ou ouverte.
* Lorsqu'une forme est fermée, elle n'a pas de point de départ ou de point d'arrivée. Lorsqu'une forme est ouverte, elle a un début et une fin. 
* Toutes les formes se composent d'au moins 2 points d'ancrage reliés par des lignes.
* Une ligne est soit droite, soit courbée. Les points d'ancrage déterminent la nature de la ligne. 
* Les points d'ancrage existent sous forme de points de coin, de points droits ou de points lisses :
  * Un point de coin est un point où 2 lignes droites se rejoignent à un angle. 
  * Un point lisse est un point où 2 poignées existent en ligne droite et où les segments de la ligne se rejoignent en une courbe lisse. Dans ce cas, toutes les poignées sont séparées du point d'ancrage par une distance égale. 
  * Un point droit est un point où 2 poignées existent en ligne droite et où les segments de cette ligne se rejoignent en une courbe lisse. Dans ce cas, les poignées n'ont pas besoin d'être séparées du point d'ancrage par une distance égale. 
* En déplaçant ou en modifiant les points d'ancrage (ce qui change l'angle des lignes), vous pouvez changer l'apparence d'une forme. 

Pour éditer les formes PowerPoint via des points d'édition, **Aspose.Slides** fournit la classe [**GeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) et l'interface [**IGeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path). 

* Une instance de [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) représente un chemin géométrique de l'objet [IGeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape). 
* Pour récupérer le `GeometryPath` de l'instance `IGeometryShape`, vous pouvez utiliser la méthode [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1). 
* Pour définir le `GeometryPath` d'une forme, vous pouvez utiliser ces méthodes : [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) pour les *formes pleines* et [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) pour les *formes composées*.
* Pour ajouter des segments, vous pouvez utiliser les méthodes sous [IGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path). 
* En utilisant les méthodes [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) et [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7), vous pouvez définir l'apparence d'un chemin géométrique.
* En utilisant la méthode [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca), vous pouvez récupérer le chemin géométrique d'une `GeometryShape` sous forme de tableau de segments de chemin. 
* Pour accéder à des options de personnalisation géométrique supplémentaires, vous pouvez convertir [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) en [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path).
* Utilisez les méthodes [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) et [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) (de la classe [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util)) pour convertir [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) en [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) et vice versa. 

## **Opérations d'Édition Simples**

Ce code C++ montre comment 

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
**Ajouter une courbe de Bezier cubique** à la fin d'un chemin :

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Ajouter une courbe de Bezier cubique** à la position spécifiée sur un chemin :

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```
**Ajouter une courbe de Bezier quadratique** à la fin d'un chemin :

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Ajouter une courbe de Bezier quadratique** à une position spécifiée sur un chemin :

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```
**Ajouter un arc donné** à un chemin :

``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Fermer la figure actuelle** d'un chemin :

``` cpp
void CloseFigure();
```
**Définir la position pour le prochain point** :

``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Supprimer le segment de chemin** à un index donné :

``` cpp
void RemoveAt(int32_t index);
```
## **Ajouter des Points Personnalisés à la Forme**
1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) et définissez le type [ShapeType.Rectangle](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) à partir de la forme.
3. Ajoutez un nouveau point entre les deux points supérieurs du chemin.
4. Ajoutez un nouveau point entre les deux points inférieurs du chemin.
5. Appliquez le chemin à la forme.

Ce code C++ montre comment ajouter des points personnalisés à une forme :

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

##  Supprimer des Points de la Forme

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) et définissez le type [ShapeType.Heart](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5). 
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) à partir de la forme.
3. Supprimez le segment du chemin.
4. Appliquez le chemin à la forme.

Ce code C++ montre comment supprimer des points d'une forme :

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

##  **Créer une Forme Personnalisée**

1. Calculez les points pour la forme.
2. Créez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path). 
3. Remplissez le chemin avec les points.
4. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape). 
5. Appliquez le chemin à la forme.

Ce code C++ montre comment créer une forme personnalisée :

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


## **Créer une Forme Personnalisée Composite**

  1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).
  2. Créez une première instance de la classe [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).
  3. Créez une deuxième instance de la classe [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).
  4. Appliquez les chemins à la forme.

Ce code C++ montre comment créer une forme personnalisée composite :

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

## **Créer une Forme Personnalisée avec des Coins Arrondis**

Ce code C++ montre comment créer une forme personnalisée avec des coins arrondis (vers l'intérieur) :

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

## **Convertir GeometryPath en GraphicsPath** 

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).
2. Créez une instance de la classe [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) du namespace [System.Drawing.Drawing2D](https://reference.aspose.com/slides/cpp/namespace/system.drawing.drawing2_d).
3. Convertissez l'instance de [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) en instance de [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) à l'aide de [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util).
4. Appliquez les chemins à la forme.

Ce code C++ - une implémentation des étapes ci-dessus - démontre le processus de conversion de **GeometryPath** à **GraphicsPath** :

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 100.0f));

SharedPtr<IGeometryPath> originalPath = shape->GetGeometryPaths()->idx_get(0);
originalPath->set_FillMode(PathFillModeType::None);

SharedPtr<Drawing2D::GraphicsPath> graphicsPath = System::MakeObject<Drawing2D::GraphicsPath>();
graphicsPath->AddString(u"Texte dans la forme", System::MakeObject<FontFamily>(u"Arial"), 1, 40.0f, PointF(10.0f, 10.0f), StringFormat::get_GenericDefault());

SharedPtr<IGeometryPath> textPath = ShapeUtil::GraphicsPathToGeometryPath(graphicsPath);
textPath->set_FillMode(PathFillModeType::Normal);

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ originalPath, textPath }));
```
![example5_image](custom_shape_5.png)