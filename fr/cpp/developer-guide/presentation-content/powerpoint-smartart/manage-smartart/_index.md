---
title: Gérer SmartArt dans les présentations PowerPoint avec C++
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/cpp/manage-smartart/
keywords:
- SmartArt
- texte SmartArt
- type de mise en page
- propriété masquée
- organigramme
- organigramme illustré
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour C++ grâce à des exemples de code clairs qui accélèrent la conception de diapositives et l'automatisation."
---
## **Aperçu**

SmartArt est un diagramme PowerPoint composé de nœuds, de formes de nœuds et d’une mise en page. Avec Aspose.Slides for C++, vous pouvez créer des SmartArt, lire le texte de leurs nœuds, modifier leur mise en page, inspecter les nœuds masqués, configurer les mises en page d’organigramme et créer des organigrammes illustrés.

## **Obtenir le texte d'un objet SmartArt**

Un nœud SmartArt peut contenir une ou plusieurs formes. Pour lire le texte visible, parcourez [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/fr/cpp/aspose.slides.smartart/smartart/get_allnodes/), puis lisez le [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) retourné par [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides.smartart/smartartshape/get_textframe/).

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (System::ObjectExt::Is<ISmartArt>(shape))
{
    auto smartArt = System::ExplicitCast<ISmartArt>(shape);

    for (int nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
    {
        auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);

        for (int shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
        {
            auto nodeShape = node->get_Shape(shapeIndex);

            if (nodeShape->get_TextFrame() != nullptr)
            {
                System::Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
            }
        }
    }
}

presentation->Dispose();
```

## **Modifier le type de mise en page d'un objet SmartArt**

La mise en page SmartArt contrôle la façon dont les nœuds sont disposés et connectés. L'exemple suivant crée un objet SmartArt avec la valeur [SmartArtLayoutType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, la change en `BasicProcess` et enregistre la présentation.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Vérifier si un nœud SmartArt est masqué**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/fr/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) indique si le nœud est masqué dans le modèle de données SmartArt. Les nœuds masqués peuvent exister dans la structure même lorsque la mise en page sélectionnée ne les affiche pas comme éléments de diagramme visibles.

L'exemple suivant ajoute un nœud à un objet SmartArt qui utilise la valeur [SmartArtLayoutType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` et vérifie l’état masqué du nœud.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Obtenir ou définir la mise en page de l'organigramme**

Pour les diagrammes SmartArt qui utilisent une mise en page d’organigramme, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/fr/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) et [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/fr/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) définissent comment les nœuds enfants sont disposés sous un nœud parent. Par exemple, vous pouvez faire suspendre les nœuds enfants à gauche, à droite ou des deux côtés, selon le [OrganizationChartLayoutType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.smartart/organizationchartlayouttype/) sélectionné.

L'exemple suivant crée un organigramme et définit la mise en page du premier nœud sur la valeur [OrganizationChartLayoutType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Créer un organigramme illustré**

Un organigramme illustré est une mise en page SmartArt conçue pour les diagrammes hiérarchiques incluant des espaces réservés d’image. Utilisez la valeur [SmartArtLayoutType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` lors de l’ajout de l’objet SmartArt à une diapositive.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**SmartArt prend‑il en charge le miroir ou l’inversion pour les langues RTL ?**

Oui. La méthode [SmartArt::set_IsReversed](https://reference.aspose.com/slides/fr/cpp/aspose.slides.smartart/smartart/set_isreversed/) inverse la direction du diagramme de gauche‑à‑droite à droite‑à‑gauche, ou l’inverse, lorsque la mise en page SmartArt sélectionnée prend en charge l’inversion.

**Comment copier un SmartArt sur la même diapositive ou dans une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/cpp/shape-manipulations/) avec [ShapeCollection::AddClone](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shapecollection/addclone/) ou [cloner la diapositive entière](/slides/fr/cpp/clone-slides/) qui contient le SmartArt. Les deux approches conservent la taille, la position et le formatage.

**Comment rendre un SmartArt en image raster pour un aperçu ou une exportation Web ?**

[Renderisez la diapositive](/slides/fr/cpp/convert-powerpoint-to-png/) ou la présentation complète en PNG ou JPEG. SmartArt est rendu comme partie de la diapositive.

**Comment trouver un objet SmartArt spécifique sur une diapositive s’il y en a plusieurs ?**

Attribuez une valeur distinctive à [Shape::set_AlternativeText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shape/set_alternativetext/) ou [Shape::set_Name](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shape/set_name/) sur la forme SmartArt, recherchez cette valeur dans [BaseSlide::get_Shapes](https://reference.aspose.com/slides/fr/cpp/aspose.slides/baseslide/get_shapes/), puis vérifiez que la forme correspondante est un [ISmartArt](https://reference.aspose.com/slides/fr/cpp/aspose.slides.smartart/ismartart/).