---
title: Gérer les formes de présentation en C++
linktitle: Manipulation de formes
type: docs
weight: 40
url: /fr/cpp/shape-manipulations/
keywords:
- forme PowerPoint
- forme de présentation
- forme sur diapositive
- rechercher une forme
- cloner forme
- supprimer forme
- masquer forme
- modifier l'ordre des formes
- obtenir l'ID de forme interop
- texte alternatif de forme
- point d'ajustement de forme
- ajustement de forme prédéfini
- géométrie de forme
- formats de disposition de forme
- forme en SVG
- forme vers SVG
- aligner forme
- retourner forme
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez comment identifier, ajuster, cloner, supprimer, masquer, réordonner, exporter, aligner et retourner les formes de présentation avec Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Aspose.Slides for C++ représente les formes d’une diapositive comme une [IShapeCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/) ordonnée. La collection est à la fois l’endroit où vous trouvez et modifiez les formes et la source de leur ordre d’empilement : l’index `0` correspond à la forme la plus à l’arrière, tandis que le dernier index correspond à la forme la plus à l’avant.

Cet article suit ce modèle. Il explique d’abord comment identifier une forme de façon fiable et modifier les points d’ajustement prédéfinis, puis montre comment cloner, supprimer, masquer et réordonner les formes. Les sections finales couvrent le formatage au niveau de la disposition, l’export SVG, l’alignement et les paramètres de retournement. Chaque exemple est indépendant, vous pouvez donc n’utiliser que les opérations dont votre flux de travail a besoin.

## **Identifier et trouver les formes**

Les index de collection sont pratiques lors du traitement d’un fichier connu, mais ils ne sont pas des identifiants stables. Ajouter, supprimer ou réordonner une forme peut changer son index. Choisissez un identifiant en fonction de la façon dont la présentation est créée et maintenue :

- [Name](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/get_name/) est utile pour les modèles contrôlés par les développeurs et facile à inspecter dans le volet de sélection de PowerPoint. Les noms peuvent être modifiés et ne sont pas garantis uniques, donc établissez une convention de nommage si le code en dépend.
- [AlternativeText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/get_alternativetext/) est utile lorsqu’une description d’accessibilité ou une balise fournie par l’auteur identifie déjà la forme. Elle est visible aux utilisateurs, peut être localisée ou réécrite pour l’accessibilité, et n’est pas garantie unique. Ne réutilisez pas silencieusement un texte d’accessibilité signifiant comme clé de base de données.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/get_officeinteropshapeid/) est un identifiant en lecture seule qui est unique au sein d’une diapositive et correspond à l’ID de forme utilisé par l’interop PowerPoint. Utilisez‑le lors de l’intégration avec PowerPoint ou quand vous avez besoin d’une référence non ambiguë pendant la durée de vie d’une forme. Une forme clonée ou recréée est une forme différente et reçoit son propre ID.

La propriété [UniqueId](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/get_uniqueid/) associée a une portée de présentation, mais elle est destinée aux add‑ins et peut être réaffectée. Elle ne doit pas être traitée comme une clé externe permanente. Si une identité à long terme est essentielle, conservez la correspondance dans les données de l’application et validez que la forme attendue existe toujours.

Pour un exemple pratique de lecture et mise à jour du titre et de la description du texte alternatif, voir [Manage Alternative Text Titles and Descriptions](/slides/fr/cpp/presentation-accessibility/). Utilisez le texte alternatif pour expliquer la signification visuelle aux lecteurs, et gardez‑le séparé des noms de forme utilisés par le code pour les rechercher.

L’exemple suivant recherche par `Name` et indique l’ID d’interop au niveau de la diapositive. Lorsque le modèle ne contient pas la forme attendue, le code signale ce résultat au lieu de continuer avec le mauvais objet.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

Lorsqu’une opération est spécifique à un type de forme, vérifiez l’interface avant d’utiliser des membres spécifiques au type. Cet exemple met à jour le texte et le texte alternatif uniquement si l’objet nommé est un [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **Identifier et modifier les ajustements de forme prédéfinis**

Les formes de géométrie prédéfinie peuvent exposer des points d’ajustement qui contrôlent des caractéristiques telles que la taille des coins, les proportions des flèches ou les angles d’arc. Accédez‑y via la collection en lecture seule [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/fr/cpp/aspose.slides/igeometryshape/get_adjustments/). La collection elle‑même est fournie par la forme, mais chaque [IAdjustValue](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iadjustvalue/) contient une valeur modifiable.

Ne vous fiez pas uniquement à un index de collection fixe. Parcourez les ajustements et inspectez la propriété en lecture seule [IAdjustValue::get_Type](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iadjustvalue/get_type/), dont la valeur [ShapeAdjustmentType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shapeadjustmenttype/) décrit ce que contrôle l’ajustement. La propriété en lecture seule [IAdjustValue::get_Name](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iadjustvalue/get_name/) fournit des informations d’identification supplémentaires et est particulièrement utile lorsqu’un prédéfini contient plusieurs ajustements du même type sémantique.

Utilisez la propriété de valeur qui correspond à la signification de l’ajustement :

| Type d'ajustement | Objectif | Valeur à modifier |
|---|---|---|
| `CornerSize` | Taille des coins arrondis | [RawValue](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Épaisseur de la queue de flèche | `RawValue` |
| `ArrowheadLength` | Longueur de la pointe de flèche | `RawValue` |
| `ArrowheadWidth` | Largeur de la pointe de flèche | `RawValue` |
| `StartAngle` | Angle de départ d’un secteur ou d’un arc | [AngleValue](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Angle de fin d’un secteur ou d’un arc | `AngleValue` |

`Type` et `Name` ne peuvent pas être assignés. `RawValue` est un entier en lecture/écriture dans les unités natives de la géométrie du prédéfini, tandis que `AngleValue` est un angle en lecture/écriture en degrés. Le nombre, l’ordre, la signification et la plage valide des ajustements dépendent du [ShapeType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/igeometryshape/get_shapetype/) du prédéfini. Une valeur valide pour un prédéfini peut être invalide ou avoir un effet différent pour un autre.

Lorsque `Type` vaut `ShapeAdjustmentType::Custom`, l’API ne reconnaît pas de signification sémantique standard. Inspectez `Name`, le type du prédéfini et la valeur existante, et laissez l’ajustement inchangé sauf si la signification et la plage attendues sont connues. Même pour les types reconnus, vérifiez si le même type apparaît plusieurs fois avant de choisir une valeur. L’article [Connector](/slides/fr/cpp/connector/) montre cette situation avec les ajustements de pli de connecteur.

L’exemple complet suivant crée des versions par défaut et modifiées de trois formes prédéfinies. Il parcourt chaque ajustement, indique son `Name` et son `Type`, modifie les valeurs liées à la taille via `RawValue`, les angles via `AngleValue`, puis enregistre le résultat. La colonne de gauche conserve la géométrie par défaut ; la colonne de droite montre le rectangle arrondi, la flèche à quatre pointes et le secteur ajustés.

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Ajoute les en-têtes pour les colonnes de forme par défaut et ajustée.
auto defaultColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
defaultColumnLabel->get_TextFrame()->set_Text(u"Default preset geometry");
auto adjustedColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
adjustedColumnLabel->get_TextFrame()->set_Text(u"Modified adjustment values");

slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
auto modifiedRoundedRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle->set_Name(u"ModifiedRoundedRectangle");

slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
auto modifiedArrow = slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
modifiedArrow->set_Name(u"ModifiedQuadArrow");

slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 95, 330, 130, 130);
auto modifiedPie = slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 445, 330, 130, 130);
modifiedPie->set_Name(u"ModifiedPie");

auto shapesToAdjust = MakeArray<SharedPtr<IGeometryShape>>({modifiedRoundedRectangle, modifiedArrow, modifiedPie});

for (auto shape : shapesToAdjust)
{
    auto adjustments = shape->get_Adjustments();
    for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
    {
        auto adjustment = adjustments->idx_get(adjustmentIndex);
        Console::WriteLine(shape->get_Name() + u" / " + adjustment->get_Name() + u": " + ObjectExt::ToString(adjustment->get_Type()));

        switch (adjustment->get_Type())
        {
            case ShapeAdjustmentType::CornerSize:
                adjustment->set_RawValue(5000);
                break;
            case ShapeAdjustmentType::ArrowTailThickness:
                adjustment->set_RawValue(25000);
                break;
            case ShapeAdjustmentType::ArrowheadLength:
                adjustment->set_RawValue(30000);
                break;
            case ShapeAdjustmentType::ArrowheadWidth:
                adjustment->set_RawValue(40000);
                break;
            case ShapeAdjustmentType::StartAngle:
                adjustment->set_AngleValue(30);
                break;
            case ShapeAdjustmentType::EndAngle:
                adjustment->set_AngleValue(300);
                break;
            case ShapeAdjustmentType::Custom:
                Console::WriteLine(u"Custom adjustment '" + adjustment->get_Name() + u"' was not changed.");
                break;
        }
    }
}

presentation->Save(u"preset-shape-adjustments.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Vérifier le type sémantique avant de changer une valeur rend le code explicite quant à son intention et évite de supposer qu’un index de collection particulier a la même signification entre différentes formes prédéfinies.

## **Modifier la collection de formes**

Les méthodes d’ajout, de clonage, de suppression et de réordonnancement agissent immédiatement sur la collection. Si une opération modifie le nombre ou l’ordre des formes, ne continuez pas à vous appuyer sur les index capturés avant cette opération.

### **Cloner une forme**

[AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/addclone/) crée une copie indépendante et l’ajoute à la collection cible. [InsertClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/insertclone/) crée également une copie mais la place à un index d’ordre z spécifié. Les surcharges qui acceptent des coordonnées déplacent le clone sans changer sa taille ; les surcharges avec largeur et hauteur peuvent également le redimensionner.

L’exemple crée une diapositive de destination, clone un rectangle étiqueté vers l’avant, et insère un deuxième clone à l’arrière. Les modifications apportées à chaque clone n’affectent pas la forme source.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le clonage copie le contenu et le formatage de la forme, y compris son nom et son texte alternatif. Attribuez de nouveaux identifiants logiques au clone lorsque ces valeurs doivent être uniques. Les ressources utilisées par les formes complexes sont gérées par la présentation, mais un clone reste un nouvel élément de collection avec une nouvelle identité de forme.

### **Supprimer des formes**

[Remove](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/remove/) supprime un objet forme spécifique de sa collection. Lors de la suppression de plusieurs correspondances pendant une itération indexée, parcourez les éléments depuis la fin afin que chaque index restant reste valide.

Cet exemple supprime chaque forme portant un nom désigné. Il lit la forme indexée actuelle, pas un élément de collection fixe, et il ne cast pas la forme inutilement.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Après la suppression, le nombre de formes et les index des formes suivantes changent. Les références aux formes non affectées restent plus fiables que des index enregistrés. Pensez également aux connecteurs, animations et autres fonctionnalités qui peuvent référencer l’objet supprimé ; la suppression d’une forme visible peut modifier plus que l’apparence de la diapositive.

### **Masquer une forme**

Définir [Hidden](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/set_hidden/) à `true` conserve la forme dans la collection mais empêche son affichage lors du diaporama normal. Son index, son formatage et son contenu restent accessibles au code, ainsi masquer convient aux éléments optionnels pouvant être restaurés plus tard.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Masquer n’est pas une suppression ni une mesure de sécurité. L’objet peut encore être découvert et rendu visible par un utilisateur ou par le code, et il reste partie du fichier de présentation.

### **Modifier l’ordre Z**

Les formes qui se chevauchent sont peintes dans l’ordre de la collection. [Reorder](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/reorder/) déplace une forme existante vers un index cible sans la cloner. L’index `0` est l’arrière ; `Count - 1` est l’avant.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le rectangle est créé d’abord et se trouve initialement derrière l’ellipse. Le déplacer vers l’index final le place devant. Finalisez l’ordre Z après avoir ajouté ou cloné toutes les formes liées, car ces opérations ajoutent ou insèrent de nouveaux éléments de collection et peuvent modifier la pile prévue.

## **Inspecter les formes sur les diapositives de disposition**

Les diapositives normales, les diapositives de disposition et les maîtres possèdent des collections de formes distinctes. Une forme dans une collection de disposition n’est pas le même objet qu’une forme positionnée de façon similaire sur une diapositive normale. Inspectez les formes de disposition lorsque vous devez comprendre ou modifier le formatage fourni par une disposition.

L’exemple suivant lit le [FillFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/get_fillformat/) et le [LineFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/get_lineformat/) de chaque forme de disposition sans supposer que chaque forme est une `AutoShape`.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

Modifier une disposition peut affecter plusieurs diapositives qui l’utilisent. Avant de changer une forme de disposition, déterminez si une diapositive normale hérite de l’objet ou contient une surcharge locale, et testez chaque diapositive qui utilise cette disposition.

## **Exporter une forme au format SVG**

[WriteAsSvg](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/writeassvg/) écrit le contenu rendu d’une forme dans un flux. Le résultat ne contient que la forme, pas l’arrière‑plan entier de la diapositive ni les formes voisines.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

Gardez la présentation ouverte pendant le rendu. La sortie dépend du formatage de la forme et des ressources telles que les polices et les images. Si vous avez besoin de la composition complète, exportez la diapositive plutôt qu’une forme individuelle. L’appelant possède le flux et doit le fermer ou le libérer.

## **Aligner les formes**

Les surcharges [SlideUtil::AlignShapes](https://reference.aspose.com/slides/fr/cpp/aspose.slides.util/slideutil/alignshapes/) alignent soit toutes les formes, soit les index de collection sélectionnés. [ShapesAlignmentType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shapesalignmenttype/) spécifie le bord, la ligne centrale ou le mode de distribution. Définissez `alignToSlide` à `true` pour utiliser les bords de la diapositive ; à `false` pour aligner les formes sélectionnées les unes par rapport aux autres.

Cet exemple aligne trois formes sur le bord supérieur de la diapositive. Les références de forme renvoyées sont converties en leurs index actuels immédiatement avant l’alignement.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

L’alignement modifie les positions, pas l’ordre Z. L’alignement relatif nécessite normalement au moins deux formes, tandis que la distribution horizontale ou verticale nécessite suffisamment de formes pour définir l’espacement. Recalculez les index si vous modifiez la collection avant d’appeler la méthode.

## **Retournement d’une forme**

La classe [ShapeFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shapeframe/) stocke la position, la taille, les paramètres de retournement horizontal et vertical, et la rotation. Ses valeurs `FlipH` et `FlipV` utilisent [NullableBool](https://reference.aspose.com/slides/fr/cpp/aspose.slides/nullablebool/) : `True` active le retournement, `False` le désactive, et `NotDefined` préserve l’état non spécifié/par défaut.

La présentation d’entrée ci‑dessous contient une forme non retournée.

![The shape before flipping](shape_to_be_flipped.png)

L’exemple conserve toutes les autres valeurs du cadre et ne remplace que les deux paramètres de retournement. C’est important car assigner un nouveau [Frame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/set_frame/) remplace le cadre complet.

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La forme enregistrée est miroir horizontalement et verticalement tout en conservant sa position, sa taille et sa rotation.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Dois‑je utiliser un index de collection comme identifiant de forme ?**

Seulement pour un traitement de courte durée où la collection ne changera pas avant l’utilisation de l’index. Privilégiez une convention validée de `Name` ou `AlternativeText` pour les modèles créés, ou `OfficeInteropShapeId` pour le travail d’interop au niveau de la diapositive.

**Masquer une forme la retire‑t‑elle de l’ordre Z ?**

Non. Une forme masquée reste dans la collection au même index. Elle peut être trouvée, réordonnée, modifiée ou rendue visible à nouveau.

**Pourquoi une forme clonée est‑elle apparue devant une autre forme ?**

`AddClone` ajoute le clone à la fin de la collection, ce qui correspond à l’avant de l’ordre Z. Utilisez `InsertClone` pour choisir l’index initial ou `Reorder` après avoir ajouté toutes les formes.

**Puis‑je utiliser un index fixe pour identifier un ajustement de forme prédéfini ?**

Seulement après avoir validé le prédéfini exact et la disposition de la collection. Privilégiez l’itération via `IGeometryShape::get_Adjustments` et la vérification de `IAdjustValue::get_Type` ; utilisez `IAdjustValue::get_Name` comme information supplémentaire lorsque le même type sémantique apparaît plusieurs fois.