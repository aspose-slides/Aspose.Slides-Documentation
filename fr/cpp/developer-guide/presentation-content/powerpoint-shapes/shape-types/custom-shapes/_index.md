---
title: Personnaliser les formes de présentation en C++
linktitle: Forme personnalisée
type: docs
weight: 20
url: /fr/cpp/custom-shape/
keywords:
- forme personnalisée
- ajouter forme
- créer forme
- modifier forme
- géométrie de forme
- chemin géométrique
- points de chemin
- points d'édition
- ajouter point
- supprimer point
- opération d'édition
- coin incurvé
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Créer et personnaliser des formes dans les présentations PowerPoint avec Aspose.Slides pour C++ : chemins géométriques, coins incurvés, formes composites."
---
## **Vue d'ensemble**

Cet article explique comment personnaliser les formes de présentation dans Aspose.Slides en modifiant la géométrie des formes via les points d'édition et les tracés géométriques. Il montre comment travailler avec [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) et [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) pour modifier des formes existantes, effectuer des opérations basiques d'édition de tracé, ajouter ou supprimer des points, et appliquer la géométrie mise à jour à une forme.

Il montre également comment créer des formes personnalisées et composites, construire des formes avec des coins incurvés, et déterminer si la géométrie d'une forme est fermée.

## **Modifier une forme à l'aide de points d'édition**

Dans PowerPoint, vous pouvez utiliser les **Points d'édition** pour modifier un carré :

* Déplacer un coin vers l'intérieur ou vers l'extérieur.
* Ajuster la courbure à un point.
* Ajouter de nouveaux points.

La modification des points vous permet de modifier le contour d'une forme ou d'utiliser une forme existante comme base pour une nouvelle.

## **Conseils pour l'édition de formes**

![overview_image](custom_shape_0.png)

Lors de l'édition des formes PowerPoint, gardez ces concepts à l'esprit :

* Une forme (ou son tracé) peut être soit fermée, soit ouverte.
* Le tracé d'une forme est composé de points d'ancrage reliés par des segments.
* Un segment peut être droit ou courbe. Les points d'ancrage et les poignées de contrôle déterminent sa forme.
* Les points d'ancrage existent en tant que points d'angle, points droits ou points lisses :
  * Dans un point d'angle, les segments adjacents peuvent se joindre à un angle.
  * Dans un point lisse, les deux poignées de contrôle sont alignées et à égale distance du point d'ancrage.
  * Dans un point droit, les deux poignées de contrôle sont alignées mais peuvent être à des distances différentes du point d'ancrage.
* Déplacer les points d'ancrage ou ajuster leurs poignées modifie le contour de la forme.

Pour modifier les formes PowerPoint via les points d'édition, **Aspose.Slides** fournit la classe [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) et l'interface [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).

* Une instance de [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) représente le tracé géométrique de l'objet [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/).
* Pour récupérer le [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) à partir de l'instance [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/), vous pouvez utiliser la méthode [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/).
* Pour définir le [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) d'une forme, vous pouvez utiliser ces méthodes : [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) pour les formes avec un seul tracé et [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) pour les formes avec plusieurs tracés.
* Pour ajouter des segments, vous pouvez utiliser les méthodes sous [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).
* En utilisant les méthodes [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) et [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/), vous pouvez définir l'apparence d'un tracé géométrique.
* En utilisant la méthode [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/), vous pouvez récupérer le tracé géométrique d'une [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) sous forme de tableau de segments de tracé.

## **Opérations d'édition simples**

Utilisez les méthodes suivantes pour éditer un tracé géométrique. Les surcharges qui acceptent un indice insèrent un segment à cette position zéro‑basée dans le tableau de segments du tracé.

| Operation | Method |
| --- | --- |
| Ajouter ou insérer une ligne droite. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| Ajouter ou insérer une courbe Bézier cubique avec deux points de contrôle et un point final. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Ajouter ou insérer une courbe Bézier quadratique avec un point de contrôle et un point final. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Ajouter un arc elliptique avec les dimensions et angles spécifiés en degrés. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Fermer la figure courante en reliant son point final à son point de départ. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Définir le point de départ d'une figure. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Supprimer un segment à un indice zéro‑basé. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Ajouter des points personnalisés à une forme**

Cet exemple insère deux points dans une forme rectangulaire en utilisant [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) et applique le tracé modifié avec [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/). Les coordonnées sont locales à la forme : les deux nouveaux points sont au centre, à 100 points du bord gauche et 50 points du haut. Les indices de segment 1 et 4 les placent sur les bords supérieur et inférieur, tirant ces bords vers l'intérieur.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto geometryPath = shape->GetGeometryPaths()->idx_get(0);
geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);

shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **Supprimer des points d'une forme**

Cet exemple modifie le contour d'une forme en forme de cœur en supprimant le segment à l'indice zéro‑basé 2 avec [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/). Appliquer le tracé modifié avec [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) met à jour le contour de la forme.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f);

auto path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);

shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Créer une forme personnalisée**

Cet exemple crée une étoile à cinq branches avec [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/). Des rayons extérieurs et intérieurs alternés de 100 et 50 points définissent les pointes et les indentations ; un pas de 72 degrés espace uniformément les cinq pointes. Le tracé est fermé avec [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) et appliqué à une forme rectangulaire à l'aide de [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), remplaçant son contour.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/math.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto points = System::MakeObject<List<PointF>>();

auto outerRadius = 100.0f;
auto innerRadius = 50.0f;
auto angleStep = 72;

for (auto angle = -90; angle < 270; angle += angleStep)
{
    auto radians = angle * (Math::PI / 180.f);
    auto x = outerRadius * Math::Cos(radians);
    auto y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math::Cos(radians);
    y = innerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

auto starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (auto i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, outerRadius * 2, outerRadius * 2);
shape->SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **Créer une forme personnalisée composite**

Cet exemple définit deux objets [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) fermés pour le tiers supérieur et inférieur d'une forme. Appliquer les deux tracés avec [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) crée une forme composite unique avec un espace à travers son tiers central.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto topPath = System::MakeObject<GeometryPath>();
topPath->MoveTo(0.0f, 0.0f);
topPath->LineTo(shape->get_Width(), 0.0f);
topPath->LineTo(shape->get_Width(), shape->get_Height() / 3);
topPath->LineTo(0.0f, shape->get_Height() / 3);
topPath->CloseFigure();

auto bottomPath = System::MakeObject<GeometryPath>();
bottomPath->MoveTo(shape->get_Height() / 3 * 2, shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height());
bottomPath->LineTo(0.0f, shape->get_Height());
bottomPath->CloseFigure();

auto paths = System::MakeArray<SharedPtr<IGeometryPath>>({ topPath, bottomPath });

shape->SetGeometryPaths(paths);
```
![example4_image](custom_shape_4.png)

## **Créer une forme personnalisée avec des coins incurvés**

Cet exemple combine des segments droits avec [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) pour créer une forme avec des coins incurvés vers l'intérieur. Chaque taille de coin définit la largeur et la hauteur de l'arc en points, et la rotation de -90 degrés trace un quart d'ellipse dans le sens antihoraire. Le tracé terminé est appliqué avec [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), et la présentation est enregistrée au format PPTX.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto shapeX = 20.f;
auto shapeY = 20.f;
auto shapeWidth = 300.f;
auto shapeHeight = 200.f;

auto leftTopSize = 50.f;
auto rightTopSize = 20.f;
auto rightBottomSize = 40.f;
auto leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto topLeft = PointF(leftTopSize, 0.0f);
auto topRight = PointF(shapeWidth - rightTopSize, 0.0f);
auto rightBottom = PointF(shapeWidth, shapeHeight - rightBottomSize);
auto bottomLeft = PointF(leftBottomSize, shapeHeight);
auto leftTop = PointF(0.0f, leftTopSize);

auto geometryPath = System::MakeObject<GeometryPath>();
geometryPath->MoveTo(topLeft);
geometryPath->LineTo(topRight);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(rightBottom);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(bottomLeft);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(leftTop);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);
geometryPath->CloseFigure();

shape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Déterminer si la géométrie d’une forme est fermée**

L'assistant suivant vérifie si chaque tracé géométrique non vide se termine par un segment de fermeture. Il lit [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) et compare la commande du segment final [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) avec [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). Il renvoie false lorsqu'il n'y a aucun tracé non vide. Cette vérification porte sur la commande finale de chaque tracé ; elle n'inspecte pas chaque sous‑figure à l'intérieur d'un tracé. L'exemple affiche `True` pour un rectangle.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IPathSegment.h>
#include <DOM/PathCommandType.h>

using namespace Aspose::Slides;
using namespace System;

auto isGeometryClosed = [](SharedPtr<IGeometryShape> geometryShape)
{
    auto hasNonemptyPath = false;
    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto segments = geometryPath->get_PathData();
        if (segments->get_Length() == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        auto lastSegment = segments->idx_get(segments->get_Length() - 1);
        if (lastSegment->get_PathCommand() != PathCommandType::Close)
        {
            return false;
        }
    }
    return hasNonemptyPath;
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
Console::WriteLine(isGeometryClosed(shape));
```

## **Inspecter les commandes de tracé géométrique**

Téléchargez [contour.pptx](contour.pptx) et placez‑le dans le répertoire de travail de l'application. La première forme de la première diapositive possède un bord supérieur droit, une courbe Bézier cubique et un bord de fermeture droit. Utilisez [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) pour lire ses tracés. Pour chaque tracé, [get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) renvoie les segments dans l'ordre de dessin. La commande renvoyée par [get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) détermine comment interpréter les valeurs renvoyées par [get_SegmentData](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_segmentdata/).

```cpp
#include <DOM/IGeometryPath.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IPathSegment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/PathCommandType.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"contour.pptx");

auto shape = ExplicitCast<IGeometryShape>(presentation->get_Slide(0)->get_Shape(0));
auto paths = shape->GetGeometryPaths();

for (auto i = 0; i < paths->get_Length(); ++i)
{
    auto segments = paths->idx_get(i)->get_PathData();
    for (auto j = 0; j < segments->get_Length(); ++j)
    {
        auto segment = segments->idx_get(j);
        auto command = segment->get_PathCommand();
        auto data = segment->get_SegmentData();
        String detail;
        switch (command)
        {
            case PathCommandType::MoveTo:
            case PathCommandType::LineTo:
                detail = String::Format(u"destination=({0}, {1})", data->idx_get(0), data->idx_get(1));
                break;
            case PathCommandType::CubicBezierTo:
                detail = String::Format(u"control1=({0}, {1}) control2=({2}, {3}) end=({4}, {5})", data);
                break;
            case PathCommandType::Close:
                detail = u"no coordinates";
                break;
            default:
            {
                auto values = MakeArray<String>(data->get_Length());
                for (auto k = 0; k < data->get_Length(); ++k)
                {
                    values->idx_set(k, String::Format(u"{0}", data->idx_get(k)));
                }
                detail = String::Format(u"raw=[{0}]", String::Join(u", ", values));
                break;
            }
        }
        Console::WriteLine(u"Path {0}, segment {1}: {2} {3}", i, j, Enum<PathCommandType>::GetName(command), detail);
    }
}
```

La forme se trouve à (200, 100) points sur la diapositive. Les points rapportés sont locaux à la forme, avec (0, 0) à son coin supérieur gauche, x augmentant vers la droite et y augmentant vers le bas. Le segment de fermeture revient au point de départ sans coordonnées supplémentaires.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![Forme PowerPoint avec un bord supérieur droit, un bord courbe du coin supérieur droit au coin inférieur gauche, et un bord gauche droit](contour.png)

## **Extraire et inspecter les éléments de forme**

Utilisez [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) pour inspecter une forme existante sous forme d'éléments contenant les points de tracé et les types de points. Convertissez chaque [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) retourné en [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) pour lire les tableaux renvoyés par [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) et [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/). Cette représentation est utile pour l'analyse de contour ou le passage de la géométrie à des outils de dessin personnalisés.

L'exemple ouvre une présentation, trouve la première forme géométrique directement sur la première diapositive, et affiche ses segments de tracé. Utilisez une présentation contenant une forme avec des segments droits et courbes pour voir les deux types de sortie. Il ne recherche pas à l'intérieur des groupes.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IShapeElement.h>
#include <DOM/ShapeElement.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IGeometryShape> shape;
for (auto&& candidate : slide->get_Shapes())
{
    shape = AsCast<IGeometryShape>(candidate);
    if (shape != nullptr)
    {
        break;
    }
}
if (shape == nullptr)
{
    Console::WriteLine(u"No geometry shape found on the first slide.");
    return;
}

for (auto&& element : shape->CreateShapeElements())
{
    auto shapeElement = ExplicitCast<ShapeElement>(element);
    auto points = shapeElement->get_PathPoints();
    auto types = shapeElement->get_PathTypes();
    Console::WriteLine(u"Shape element:");

    for (auto i = 0; i < points->get_Length(); i++)
    {
        auto pointType = types[i] & 0x07; // Conserver le type de segment, en excluant les drapeaux.
        switch (pointType)
        {
            case 0:
                Console::WriteLine(u"Start figure at {0}", points[i]);
                break;
            case 1:
                Console::WriteLine(u"Line to {0}", points[i]);
                break;
            case 3:
                Console::WriteLine(u"Cubic Bezier: controls {0}, {1}; end {2}", points[i], points[i + 1], points[i + 2]);
                i += 2; // Consommer les deux points de contrôle ainsi que le point final.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

Les tableaux correspondent par indice : `points[i]` est un point et `types[i]` décrit son rôle. Le type `0` démarre une figure, et le type `1` trace une ligne du point précédent au point actuel. Un segment Bézier cubique démarre au point final précédent et utilise trois entrées consécutives de type `3` : deux points de contrôle suivis du nouveau point final. La boucle consomme ces trois entrées ensemble et vérifie la fermeture du point final.

Les types de points contiennent également des drapeaux. Masquez avec `0x07` pour identifier le type de segment, et testez `0x80` séparément pour détecter un sous‑chemin fermé. Par exemple, `129` (`0x81`) signifie un point final de ligne qui ferme un sous‑chemin, et `131` (`0x83`) signifie un point final Bézier qui en ferme un. Comparer la valeur brute uniquement avec `1` ou `3` manquerait ces cas. D'autres drapeaux, comme le tiret (`0x10`) et le marqueur (`0x20`), ne modifient pas le type de segment de base.

**Coordonnées et transformations.** Les points sont mesurés en points (1/72 pouce), X augmentant vers la droite et Y augmentant vers le bas. Pour une forme non groupée, les coordonnées extraites incluent déjà la position renvoyée par [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) et [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) et reflètent sa largeur et hauteur actuelles. Par exemple, un rectangle non tourné à `(100, 200)` avec une taille de `120 × 80` a des limites de contour `(100, 200)`–`(220, 280)`. N'ajoutez pas de nouveau la position de la forme. Soustrayez son X et Y pour obtenir des coordonnées relatives à son cadre non tourné.

Les points extraits n'appliquent pas la rotation définie via [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) ni les retournements horizontaux et verticaux. Pour reproduire le contour affiché, appliquez ces transformations autour du centre de la forme. Pour les formes groupées, tenez également compte du mappage des coordonnées du groupe et des transformations ; ne supposez pas que les points extraits sont les coordonnées finales rendues de la diapositive ou n'appliquez pas deux fois une translation ou une mise à l’échelle si elle est déjà reflétée dans le cadre de l'enfant.

**Inspection vs édition.** Les tableaux extraits décrivent le contour ; les modifier ne met pas à jour la forme originale. Choisissez cette approche lorsque votre analyse ou votre code de dessin a besoin de tableaux point/type. Utilisez [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) lorsque vous avez besoin des commandes géométriques dans le système de coordonnées local de la forme ou que vous souhaitez éditer sa géométrie. Appliquez les tracés modifiés via [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) ou [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/).

## **Convertir GeometryPath en GraphicsPath**

L'API publique actuelle d'Aspose.Slides pour C++ n'expose pas de conversions entre les tracés géométriques et les tracés graphiques. Pour inspecter un contour, utilisez les éléments de forme comme décrit ci-dessus. Pour éditer une forme, utilisez des tracés géométriques et appliquez les tracés mis à jour à la forme.

## **FAQ**

**Que se passe-t-il avec le remplissage et le contour après le remplacement de la géométrie ?**

Le style reste attaché à la forme ; seul le contour change. Le remplissage et le contour sont appliqués automatiquement à la nouvelle géométrie.

**Comment faire pivoter correctement une forme personnalisée avec sa géométrie ?**

Utilisez la méthode [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) de la forme ; la géométrie pivote avec la forme car elle est liée au système de coordonnées propre de la forme.

**Puis-je convertir une forme personnalisée en image pour « verrouiller » le résultat ?**

Oui. Exportez la zone de [slide](/slides/fr/cpp/convert-powerpoint-to-png/) requise ou la [shape](/slides/fr/cpp/shape-thumbnails/) elle‑même vers un format raster ; cela simplifie le travail ultérieur avec des géométries complexes.