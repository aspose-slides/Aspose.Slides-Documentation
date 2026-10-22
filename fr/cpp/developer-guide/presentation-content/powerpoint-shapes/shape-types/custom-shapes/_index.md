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
- chemin de géométrie
- points de chemin
- points d'édition
- ajouter point
- supprimer point
- opération d'édition
- coin arrondi
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Créer et personnaliser des formes dans les présentations PowerPoint avec Aspose.Slides pour C++: chemins de géométrie, coins arrondis, formes composites."
---
## **Vue d'ensemble**

Cet article explique comment personnaliser les formes d'une présentation dans Aspose.Slides en modifiant la géométrie des formes à l'aide de points d'édition et de chemins géométriques. Il montre comment travailler avec [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) et [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) pour modifier des formes existantes, effectuer des opérations de base d'édition de chemin, ajouter ou supprimer des points, et appliquer la géométrie mise à jour à une forme.

Il montre également comment créer des formes personnalisées et composites, construire des formes avec des coins arrondis, et déterminer si la géométrie d’une forme est fermée.

## **Modifier une forme à l’aide de points d’édition**

Dans PowerPoint, vous pouvez utiliser **Edit Points** pour modifier un carré :

* Déplacer un coin vers l’intérieur ou vers l’extérieur.
* Ajuster la courbure en un point.
* Ajouter de nouveaux points.

La modification des points vous permet de modifier le contour d’une forme ou d’utiliser une forme existante comme base pour une nouvelle.

## **Conseils de modification de forme**

![overview_image](custom_shape_0.png)

Lors de la modification de formes PowerPoint, gardez à l’esprit les concepts suivants :

* Une forme (ou son chemin) peut être fermée ou ouverte.
* Le chemin d’une forme se compose de points d’ancrage reliés par des segments.
* Un segment peut être droit ou courbé. Les points d’ancrage et les poignées de contrôle déterminent sa forme.
* Les points d’ancrage existent sous forme de points d’angle, points droits ou points lisses :
  * À un point d’angle, les segments adjacents peuvent se rencontrer sous un angle.
  * À un point lisse, les deux poignées de contrôle sont alignées et à égale distance du point d’ancrage.
  * À un point droit, les deux poignées de contrôle sont alignées mais peuvent être à des distances différentes du point d’ancrage.
* Déplacer les points d’ancrage ou ajuster leurs poignées modifie le contour de la forme.

Pour modifier les formes PowerPoint à l’aide de points d’édition, **Aspose.Slides** fournit la classe [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) et l’interface [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).

* Une instance de [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) représente un chemin géométrique de l’objet [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/).
* Pour récupérer le [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) depuis l’instance [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/), vous pouvez utiliser la méthode [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/).
* Pour définir le [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) d’une forme, vous pouvez utiliser ces méthodes : [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) pour les formes à chemin unique et [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) pour les formes à chemins multiples.
* Pour ajouter des segments, vous pouvez utiliser les méthodes sous [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).
* En utilisant les méthodes [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) et [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/), vous pouvez définir l’apparence d’un chemin géométrique.
* En utilisant la méthode [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/), vous pouvez récupérer le chemin géométrique d’une [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) sous forme de tableau de segments de chemin.

## **Opérations d’édition simples**

Utilisez les méthodes suivantes pour modifier un chemin géométrique. Les surcharges qui acceptent un indice insèrent un segment à cette position zero‑based dans le tableau de segments du chemin.

| Opération | Méthode |
| --- | --- |
| Ajouter ou insérer une ligne droite. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| Ajouter ou insérer une courbe cubique Bézier avec deux points de contrôle et un point final. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Ajouter ou insérer une courbe quadratique Bézier avec un point de contrôle et un point final. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Ajouter un arc elliptique avec les dimensions et angles spécifiés en degrés. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Fermer la figure courante en reliant son point final à son point de départ. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Définir le point de départ d’une figure. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Supprimer un segment à un indice basé sur zéro. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Ajouter des points personnalisés à une forme**

Cet exemple insère deux points dans une forme rectangulaire à l’aide de [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) et applique le chemin modifié avec [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/). Les coordonnées sont locales à la forme : les deux nouveaux points se trouvent à son centre, à 100 points du bord gauche et 50 points du bord supérieur. Les indices de segment 1 et 4 les placent sur les bords supérieur et inférieur, tirant ces bords vers l’intérieur.

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

## **Supprimer des points d’une forme**

Cet exemple modifie le contour d’une forme en forme de cœur en supprimant le segment à l’indice basé sur zéro 2 avec [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/). Appliquer le chemin modifié avec [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) met à jour le contour de la forme.

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

Cet exemple construit une étoile à cinq branches avec [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/). Des rayons extérieurs et intérieurs alternés de 100 et 50 points définissent les pointes et les enfoncements ; un pas de 72 degrés espace uniformément les cinq pointes. Le chemin est fermé avec [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) et appliqué à une forme rectangulaire à l’aide de [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), remplaçant son contour.

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

Cet exemple définit deux objets [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) fermés pour le tiers supérieur et le tiers inférieur d’une forme. Appliquer les deux chemins avec [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) crée une forme composite unique avec un espace couvrant son tiers central.

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
bottomPath->MoveTo(0.0f, shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height());
bottomPath->LineTo(0.0f, shape->get_Height());
bottomPath->CloseFigure();

auto paths = System::MakeArray<SharedPtr<IGeometryPath>>({ topPath, bottomPath });

shape->SetGeometryPaths(paths);
```
![example4_image](custom_shape_4.png)

## **Créer une forme personnalisée avec des coins arrondis**

Cet exemple combine des segments droits avec [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) pour créer une forme avec des coins courbés vers l’intérieur. Chaque taille de coin définit la largeur et la hauteur de l’arc en points, et le balayage de -90 degrés trace un quart d’ellipse dans le sens antihoraire. Le chemin complet est appliqué avec [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), et la présentation est enregistrée au format PPTX.

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

L’assistant suivant vérifie si chaque chemin géométrique non vide se termine par un segment de fermeture. Il lit [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) et compare la commande du segment final [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) avec [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). Il renvoie false lorsqu’il n’y a aucun chemin non vide. Cette vérification porte sur la commande finale de chaque chemin ; elle n’inspecte pas chaque sous‑figure à l’intérieur d’un chemin. L’exemple affiche `True` pour un rectangle.

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

## **Extraire et inspecter les éléments de forme**

Utilisez [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) pour inspecter une forme existante sous forme d’éléments contenant les points de chemin et les types de points. Convertissez chaque [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) renvoyé en [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) afin de lire les tableaux renvoyés par [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) et [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/). Cette représentation est utile pour l’analyse des contours ou la transmission de la géométrie à des outils de dessin personnalisés.

L’exemple ouvre une présentation, trouve la première forme géométrique directement sur la première diapositive, et affiche ses segments de chemin. Utilisez une présentation contenant une forme avec des segments droits et courbes pour voir les deux types de sortie. Il ne recherche pas à l’intérieur des groupes.

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
                i += 2; // Consommer les deux points de contrôle et le point final.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

Les tableaux correspondent par indice : `points[i]` est un point et `types[i]` décrit son rôle. Le type `0` démarre une figure, et le type `1` trace une ligne du point précédent au point actuel. Un segment Bézier cubique commence au point d’extrémité précédent et utilise trois entrées consécutives de type `3` : deux points de contrôle suivis du nouveau point d’extrémité. La boucle consomme ces trois entrées ensemble et vérifie la fermeture du point d’extrémité.

Les types de points contiennent également des indicateurs. Masquez avec `0x07` pour identifier le type de segment, et testez séparément `0x80` pour détecter un sous‑chemin fermé. Par exemple, `129` (`0x81`) signifie un point d’extrémité de ligne qui ferme un sous‑chemin, et `131` (`0x83`) signifie un point d’extrémité Bézier qui en ferme un. Comparer la valeur brute uniquement avec `1` ou `3` manquerait ces cas. D’autres indicateurs, comme le tiret (`0x10`) et le marqueur (`0x20`), ne modifient pas le type de segment de base.

**Coordonnées et transformations.** Les points sont mesurés en points (1/72 pouce), X augmente vers la droite et Y augmente vers le bas. Pour une forme non groupée, les coordonnées extraites incluent déjà la position renvoyée par [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) et [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) et reflètent sa largeur et hauteur actuelles. Par exemple, un rectangle non tourné à `(100, 200)` de taille `120 × 80` a des limites de contour `(100, 200)`–`(220, 280)`. N’ajoutez pas à nouveau la position de la forme. Soustrayez son X et Y pour obtenir des coordonnées relatives à son cadre non tourné.

Les points extraits n’appliquent pas la rotation définie via [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) ni les inversions horizontales et verticales. Pour reproduire le contour affiché, appliquez ces transformations autour du centre de la forme. Pour les formes groupées, tenez également compte du mappage des coordonnées du groupe et des transformations ; ne supposez pas que les points extraits sont les coordonnées finales rendues sur la diapositive ou n’appliquez pas une translation ou un redimensionnement deux fois s’il est déjà reflété dans le cadre de l’enfant.

**Inspection vs édition.** Les tableaux extraits décrivent le contour ; les modifier ne met pas à jour la forme originale. Choisissez cette approche lorsque votre analyse ou votre code de dessin a besoin de tableaux point/type. Utilisez [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) lorsque vous avez besoin des commandes de géométrie dans le système de coordonnées locales de la forme ou que vous souhaitez modifier sa géométrie. Appliquez les chemins modifiés via [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) ou [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/).

## **Convertir GeometryPath en GraphicsPath**

L’API publique actuelle d’Aspose.Slides pour C++ n’expose pas de conversion entre les chemins géométriques et les chemins graphiques. Pour inspecter un contour, utilisez les éléments de forme comme décrit ci‑dessus. Pour modifier une forme, utilisez les chemins géométriques et appliquez les chemins mis à jour à la forme.

## **FAQ**

**Que se passe-t-il pour le remplissage et le contour après le remplacement de la géométrie ?**  
Le style reste attaché à la forme ; seul le contour change. Le remplissage et le contour sont automatiquement appliqués à la nouvelle géométrie.

**Comment faire pivoter correctement une forme personnalisée avec sa géométrie ?**  
Utilisez la méthode [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) de la forme ; la géométrie pivote avec la forme car elle est liée au système de coordonnées propre de la forme.

**Puis‑je convertir une forme personnalisée en image pour « verrouiller » le résultat ?**  
Oui. Exportez la zone de [diapositive](/slides/fr/cpp/convert-powerpoint-to-png/) requise ou la [forme](/slides/fr/cpp/shape-thumbnails/) elle‑même vers un format raster ; cela simplifie le travail ultérieur avec des géométries complexes.