---
title: Gérer SmartArt dans les présentations PowerPoint avec Python
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/python-net/manage-smartart/
keywords:
- SmartArt
- texte de SmartArt
- type de mise en page
- propriété masquée
- organigramme
- organigramme avec images
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour Python via .NET en utilisant des exemples de code clairs qui accélèrent la conception de diapositives et l'automatisation."
---
## **Vue d'ensemble**

SmartArt est un diagramme PowerPoint composé de nœuds, de formes de nœuds et d’une disposition. Avec Aspose.Slides pour Python via .NET, vous pouvez créer des SmartArt, lire le texte de leurs nœuds, modifier leur disposition, inspecter les nœuds masqués, configurer les dispositions de diagrammes d’organisation et créer des diagrammes d’organisation avec images.

## **Obtenir le texte d’un objet SmartArt**

Un nœud SmartArt peut contenir une ou plusieurs formes. Pour lire le texte visible, parcourez [SmartArt.all_nodes](https://reference.aspose.com/slides/fr/python-net/aspose.slides.smartart/smartart/all_nodes/), puis lisez le [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) renvoyé par [SmartArtShape.text_frame](https://reference.aspose.com/slides/fr/python-net/aspose.slides.smartart/smartartshape/text_frame/).

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```

## **Modifier le type de disposition d’un objet SmartArt**

La disposition SmartArt contrôle la façon dont les nœuds sont organisés et connectés. L’exemple suivant crée un objet SmartArt avec la valeur `BASIC_BLOCK_LIST` de [SmartArtLayoutType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.smartart/smartartlayouttype/), la change en valeur `BASIC_PROCESS`, puis enregistre la présentation.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Vérifier si un nœud SmartArt est masqué**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/fr/python-net/aspose.slides.smartart/smartartnode/is_hidden/) indique si le nœud est masqué dans le modèle de données SmartArt. Les nœuds masqués peuvent exister dans la structure même lorsque la disposition sélectionnée ne les affiche pas comme éléments visibles du diagramme.

L’exemple suivant ajoute un nœud à un objet SmartArt qui utilise la valeur `RADIAL_CYCLE` de [SmartArtLayoutType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.smartart/smartartlayouttype/), puis vérifie l’état masqué du nœud.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtenir ou définir la disposition du diagramme d’organisation**

Pour les diagrammes SmartArt qui utilisent une disposition de diagramme d’organisation, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/fr/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) définit la façon dont les nœuds enfants sont disposés sous un nœud parent. Par exemple, vous pouvez faire suspendre les nœuds enfants à gauche, à droite ou des deux côtés, selon le [OrganizationChartLayoutType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.smartart/organizationchartlayouttype/) sélectionné.

L’exemple suivant crée un diagramme d’organisation et définit la disposition du premier nœud sur la valeur `LEFT_HANGING` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.smartart/organizationchartlayouttype/).

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Créer un diagramme d’organisation avec image**

Un diagramme d’organisation avec image est une disposition SmartArt conçue pour les diagrammes hiérarchiques incluant des espaces réservés d’image. Utilisez la valeur `PICTURE_ORGANIZATION_CHART` de [SmartArtLayoutType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.smartart/smartartlayouttype/) lors de l’ajout de l’objet SmartArt à une diapositive.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**SmartArt prend‑il en charge le miroir ou l’inversion pour les langues RTL ?**

Oui. La propriété [SmartArt.is_reversed](https://reference.aspose.com/slides/fr/python-net/aspose.slides.smartart/smartart/is_reversed/) inverse la direction du diagramme de gauche à droite vers droite à gauche, ou l’inverse, lorsque la disposition SmartArt sélectionnée prend en charge l’inversion.

**Comment copier un SmartArt sur la même diapositive ou dans une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/python-net/shape-manipulations/) avec [ShapeCollection.add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/add_clone/) ou [cloner toute la diapositive](/slides/fr/python-net/clone-slides/) contenant le SmartArt. Les deux approches conservent la taille, la position et le formatage.

**Comment rendre un SmartArt en image matricielle pour un aperçu ou une exportation Web ?**

[Rendez la diapositive](/slides/fr/python-net/convert-powerpoint-to-png/) ou la présentation complète en PNG ou JPEG. Le SmartArt est rendu comme partie de la diapositive.

**Comment trouver un objet SmartArt spécifique sur une diapositive s’il y en a plusieurs ?**

Attribuez une [Shape.alternative_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/alternative_text/) ou une [Shape.name](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/name/) distinctive à la forme SmartArt, recherchez cette valeur dans [Slide.shapes](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/shapes/), puis vérifiez que la forme correspondante est un [SmartArt](https://reference.aspose.com/slides/fr/python-net/aspose.slides.smartart/smartart/).