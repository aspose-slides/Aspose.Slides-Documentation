---
title: Gérer SmartArt dans les présentations PowerPoint à l'aide de Python
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/python-net/manage-smartart/
keywords:
- SmartArt
- Texte SmartArt
- type de mise en page
- propriété masquée
- organigramme
- organigramme d'image
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour Python via .NET en utilisant des exemples de code clairs qui accélèrent la conception de diapositives et l'automatisation."
---
## **Vue d'ensemble**

SmartArt est un diagramme PowerPoint composé de nœuds, de formes de nœuds et d’une disposition. Avec Aspose.Slides pour Python via .NET, vous pouvez créer des SmartArt, lire le texte de leurs nœuds, modifier leur disposition, inspecter les nœuds masqués, configurer les dispositions des organigrammes et créer des organigrammes d’image.

## **Obtenir le texte d’un objet SmartArt**

Un nœud SmartArt peut contenir une ou plusieurs formes. Pour lire le texte des formes du nœud, parcourez [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/), puis lisez le [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) renvoyé par [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/).

L’exemple nécessite une présentation contenant au moins une diapositive et un objet SmartArt en tant que première forme sur cette diapositive. Il affiche chaque cadre de texte disponible dans la console.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```

## **Modifier le type de mise en page d’un objet SmartArt**

La mise en page SmartArt détermine la façon dont les nœuds sont disposés et connectés. L’exemple suivant crée un objet SmartArt avec la valeur [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`, la modifie en `BASIC_PROCESS` et enregistre la présentation. La position et la taille transmises à [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) sont exprimées en points. Définissez [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/) pour modifier la mise en page.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Vérifier si un nœud SmartArt est masqué**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) indique si le nœud est masqué dans le modèle de données SmartArt. Les nœuds masqués peuvent exister dans la structure même lorsque la mise en page sélectionnée ne les affiche pas comme éléments visibles du diagramme.

L’exemple suivant ajoute un nœud à un objet SmartArt qui utilise la valeur [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` et vérifie l’état masqué du nœud ajouté. Il affiche un message si le nœud est masqué et enregistre le diagramme.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtenir ou définir la disposition de l’organigramme**

Pour les diagrammes SmartArt utilisant une disposition d’organigramme, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) définit la manière dont les nœuds enfants sont disposés sous un nœud parent. Par exemple, vous pouvez placer les nœuds enfants en suspension à gauche, à droite ou des deux côtés, selon le [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) sélectionné.

L’exemple suivant crée un organigramme et définit la disposition du premier nœud sur la valeur [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`. L’index basé sur zéro `0` sélectionne le premier nœud de niveau supérieur ; ses nœuds enfants utilisent la disposition sélectionnée. La présentation modifiée est ensuite enregistrée.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Créer un organigramme d’image**

Un organigramme d’image est une disposition SmartArt conçue pour les diagrammes hiérarchiques incluant des espaces réservés d’image. Utilisez la valeur [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` lors de l’ajout de l’objet SmartArt à une diapositive. Cet exemple enregistre un diagramme avec des espaces réservés d’image ; il ne remplit pas ces espaces avec des images.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Convertir les diagrammes hérités en groupes de formes**

Lors de la modernisation d’une présentation existante, il peut être nécessaire de mettre à jour un organigramme créé à l’origine dans PowerPoint 97‑2003. Aspose.Slides représente ces diagrammes hérités sous forme d’objets [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/). Utilisez [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/) pour convertir un diagramme en groupe de formes afin de pouvoir modifier les éléments visuels individuels. Consultez la [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) pour plus de détails.

La conversion ajoute un nouveau groupe à la collection de formes sans supprimer le diagramme original. Après une conversion réussie, supprimez l’original avec [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) pour éviter le contenu dupliqué. Rassemblez les diagrammes hérités dans une liste avant de les convertir afin que l’ajout et la suppression de formes ne perturbent pas l’itération.

L’exemple suivant ouvre une présentation, parcourt chaque diapositive, convertit les diagrammes en groupes de formes et enregistre la présentation mise à jour au format PPTX.

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```

La présentation enregistrée contient des groupes de formes modifiables à la place des diagrammes hérités convertis, sans diagrammes originaux restants. Ouvrez le PPTX dans PowerPoint pour modifier les éléments individuels de chaque groupe, tels que le texte, le remplissage ou la position.

## **FAQ**

**SmartArt prend‑il en charge le miroir ou l’inversion pour les langues RTL ?**

Oui. La propriété [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) inverse la direction du diagramme de gauche à droite en droite à gauche, ou inversement, lorsque la mise en page SmartArt sélectionnée prend en charge l’inversion.

**Comment copier un SmartArt dans la même diapositive ou dans une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/python-net/shape-manipulations/) avec [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) ou [cloner la diapositive entière](/slides/fr/python-net/clone-slides/) contenant le SmartArt. Les deux approches conservent la taille, la position et le formatage.

**Comment rendre un SmartArt en image raster pour un aperçu ou une exportation web ?**

[Rendez la diapositive](/slides/fr/python-net/convert-powerpoint-to-png/) ou toute la présentation en PNG ou JPEG. SmartArt est rendu comme partie de la diapositive.

**Comment trouver un objet SmartArt spécifique sur une diapositive s’il y en a plusieurs ?**

Attribuez une valeur distinctive à [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) ou à [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) sur la forme SmartArt, recherchez cette valeur dans [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/), puis vérifiez que la forme correspondante est un [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).