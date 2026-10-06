---
title: Gérer SmartArt dans les présentations PowerPoint avec C++
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/cpp/manage-smartart/
keywords:
- SmartArt
- texte SmartArt
- type de disposition
- propriété masquée
- organigramme
- organigramme illustré
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour C++ grâce à des exemples de code clairs qui accélèrent la conception de diapositives et l'automatisation."
---
## **Vue d'ensemble**

SmartArt est un diagramme PowerPoint composé de nœuds, de formes de nœuds et d’une disposition. Avec Aspose.Slides pour C++, vous pouvez créer des SmartArt, lire le texte de leurs nœuds, modifier leur disposition, inspecter les nœuds masqués, configurer les dispositions de graphiques d’organisation et créer des graphiques d’organisation illustrés.

## **Obtenir le texte d’un objet SmartArt**

Un nœud SmartArt peut contenir une ou plusieurs formes. Pour lire le texte des formes du nœud, parcourez [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/get_allnodes/), puis lisez le [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) renvoyé par [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/).

L’exemple nécessite une présentation contenant au moins une diapositive et un objet SmartArt comme première forme de cette diapositive. Il affiche chaque trame de texte disponible dans la console.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/ISmartArtShape.h>
#include <DOM/SmartArt/ISmartArtShapeCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto smartArt = ExplicitCast<ISmartArt>(slide->get_Shape(0));
for (auto nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
{
    auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);
    for (auto shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto nodeShape = node->get_Shape(shapeIndex);
        if (nodeShape->get_TextFrame() != nullptr)
        {
            Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
        }
    }
}

presentation->Dispose();
```

## **Modifier le type de disposition d’un objet SmartArt**

La disposition SmartArt détermine comment les nœuds sont organisés et reliés. L’exemple suivant crée un objet SmartArt avec la valeur `BasicBlockList` de [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) , la change en valeur `BasicProcess`, puis enregistre la présentation. La position et la taille passées à [IShapeCollection::AddSmartArt](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsmartart/) sont exprimées en points. Utilisez [ISmartArt::set_Layout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/set_layout/) pour modifier la disposition.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);
smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Vérifier si un nœud SmartArt est masqué**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_ishidden/) indique si le nœud est masqué dans le modèle de données SmartArt. Les nœuds masqués peuvent exister dans la structure même lorsque la disposition sélectionnée ne les affiche pas comme éléments visibles du diagramme.

L’exemple suivant ajoute un nœud à un objet SmartArt qui utilise la valeur `RadialCycle` de [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) , puis vérifie l’état masqué du nœud ajouté. Il affiche un message si le nœud est masqué et enregistre le diagramme.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);
auto node = smartArt->get_AllNodes()->AddNode();
auto isHidden = node->get_IsHidden();

if (isHidden)
{
    Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Obtenir ou définir la disposition du graphique d’organisation**

Pour les diagrammes SmartArt qui utilisent une disposition de graphique d’organisation, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_organizationchartlayout/) et [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/set_organizationchartlayout/) définissent comment les nœuds enfants sont disposés sous un nœud parent. Par exemple, vous pouvez faire pendre les nœuds enfants à gauche, à droite ou des deux côtés, selon le [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) sélectionné.

L’exemple suivant crée un graphique d’organisation et définit la disposition du premier nœud sur la valeur `LeftHanging` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) . L’index basé sur zéro `0` sélectionne le premier nœud de niveau supérieur ; ses nœuds enfants utilisent l’arrangement choisi. La présentation modifiée est ensuite enregistrée.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/OrganizationChartLayoutType.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);
auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Créer un graphique d’organisation illustré**

Un graphique d’organisation illustré est une disposition SmartArt conçue pour les diagrammes hiérarchiques incluant des espaces réservés d’image. Utilisez la valeur `PictureOrganizationChart` de [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) lors de l’ajout de l’objet SmartArt à une diapositive. Cet exemple enregistre un diagramme avec des espaces réservés d’image ; il ne remplit pas les espaces réservés avec des images.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Convertir les diagrammes hérités en groupes de formes**

Lors de la modernisation d’une présentation existante, il peut être nécessaire de mettre à jour un graphique d’organisation créé à l’origine dans PowerPoint 97–2003. Aspose.Slides représente ces diagrammes hérités comme des objets [ILegacyDiagram](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/) . Utilisez [ILegacyDiagram::ConvertToGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/converttogroupshape/) pour convertir un diagramme en un groupe de formes afin de pouvoir modifier les éléments visuels individuels. Consultez la [LegacyDiagram API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/legacydiagram/) pour plus de détails.

La conversion ajoute un nouveau groupe à la collection de formes sans supprimer le diagramme original. Après une conversion réussie, supprimez l’original avec [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) pour éviter le contenu dupliqué. Regroupez les diagrammes hérités dans un vecteur avant de les convertir afin que l’ajout et la suppression de formes n’interrompent pas l’itération.

L’exemple suivant ouvre une présentation, parcourt chaque diapositive, convertit les diagrammes en groupes de formes et enregistre la présentation mise à jour au format PPTX.

```cpp
#include <DOM/ILegacyDiagram.h>
#include <DOM/IGroupShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"legacy-diagrams.ppt");

for (auto slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    std::vector<SharedPtr<ILegacyDiagram>> legacyDiagrams;

    for (auto shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<ILegacyDiagram>(shape))
        {
            auto legacyDiagram = ExplicitCast<ILegacyDiagram>(shape);
            legacyDiagrams.push_back(legacyDiagram);
        }
    }

    for (auto legacyDiagram : legacyDiagrams)
    {
        auto groupShape = legacyDiagram->ConvertToGroupShape();

        if (groupShape != nullptr)
        {
            slide->get_Shapes()->Remove(legacyDiagram);
        }
    }
}

presentation->Save(u"modernized.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La présentation enregistrée contient des groupes de formes modifiables à la place des diagrammes hérités convertis, sans aucun diagramme original restant à côté. Ouvrez le PPTX dans PowerPoint pour modifier les éléments individuels de chaque groupe, comme le texte, le remplissage ou la position.

## **FAQ**

**SmartArt prend‑il en charge le miroir ou l’inversion pour les langues RTL ?**

Oui. La méthode [SmartArt::set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) inverse la direction du diagramme de gauche à droite à droite à gauche, ou inversement, lorsque la disposition SmartArt sélectionnée prend en charge l’inversion.

**Comment copier un SmartArt vers la même diapositive ou vers une autre présentation tout en conservant la mise en forme ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/cpp/shape-manipulations/) avec [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/) ou [cloner toute la diapositive](/slides/fr/cpp/clone-slides/) qui contient le SmartArt. Les deux approches conservent la taille, la position et la mise en forme.

**Comment rendre le SmartArt en image matricielle pour l’aperçu ou l’exportation web ?**

[Rendre la diapositive](/slides/fr/cpp/convert-powerpoint-to-png/) ou l’ensemble de la présentation en PNG ou JPEG. Le SmartArt est rendu comme partie de la diapositive.

**Comment trouver un objet SmartArt spécifique sur une diapositive s’il y en a plusieurs ?**

Attribuez une valeur distinctive à [Shape::set_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) ou à [Shape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) sur la forme SmartArt, recherchez cette valeur dans [BaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) , puis vérifiez que la forme correspondante est un [ISmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/).