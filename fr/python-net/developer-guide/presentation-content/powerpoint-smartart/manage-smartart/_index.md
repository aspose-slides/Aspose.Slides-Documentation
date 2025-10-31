---
title: Gérer les SmartArt dans les présentations PowerPoint avec Python
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/python-net/manage-smartart/
keywords:
- SmartArt
- texte de SmartArt
- type de disposition
- propriété cachée
- organigramme
- organigramme illustré
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour Python via .NET en utilisant des exemples de code clairs qui accélèrent la conception de diapositives et l'automatisation."
---

## **Vue d’ensemble**

Ce guide montre comment créer et manipuler des SmartArt dans Aspose.Slides pour Python. Vous apprendrez à extraire le texte des SmartArt (y compris le contenu du [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) à l'intérieur des formes de nœuds), à ajouter des SmartArt aux diapositives et à changer leur disposition, à détecter et gérer les nœuds cachés, à configurer les dispositions d’organigramme, et à créer des organigrammes illustrés — le tout avec des exemples Python concis et copiables qui ouvrent une [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), travaillent avec les diapositives et les nœuds SmartArt, et enregistrent les résultats au format PPTX.

## **Obtenir le texte d’un SmartArt**

La propriété `text_frame` du [SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) vous permet de récupérer tout le texte d’une forme SmartArt — pas seulement le texte contenu dans ses nœuds. Le code d’exemple suivant montre comment obtenir le texte d’un nœud SmartArt.

```py
import aspose.slides as slides

with slides.Presentation("SmartArt.pptx") as presentation:
    slide = presentation.slides[0]
    smart_art = slide.shapes[0]

    for smart_art_node in smart_art.all_nodes:
        for node_shape in smart_art_node.shapes:
            if node_shape.text_frame is not None:
                print(node_shape.text_frame.text)
```

## **Modifier le type de disposition du SmartArt**

Pour modifier le type de disposition du SmartArt, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenir une référence à une diapositive par son indice.
3. Ajouter une forme SmartArt avec la disposition `BASIC_BLOCK_LIST`.
4. Modifier sa disposition en `BASIC_PROCESS`.
5. Enregistrer la présentation au format PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ajouter une forme SmartArt avec la disposition BASIC_BLOCK_LIST.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # Modifier le type de disposition en BASIC_PROCESS.
    smart.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    # Enregistrer la présentation.
    presentation.save("ChangedSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Vérifier la propriété cachée du SmartArt**

La propriété `SmartArtNode.is_hidden` renvoie `True` si le nœud est masqué dans le modèle de données. Pour vérifier si un nœud SmartArt est caché, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Ajouter une forme SmartArt avec la disposition `RADIAL_CYCLE`.
3. Ajouter un nœud au SmartArt.
4. Vérifier la propriété `is_hidden`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ajouter une forme SmartArt avec la disposition RADIAL_CYCLE.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    # Ajouter un nœud au SmartArt.
    node = smart.all_nodes.add_node()

    # Vérifier la propriété is_hidden.
    if node.is_hidden:
        print("The node is hidden.")
```

## **Obtenir ou définir le type d’organigramme**

La propriété `SmartArtNode.organization_chart_layout` obtient ou définit le type d’organigramme associé au nœud actuel. Pour obtenir ou définir le type d’organigramme, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Ajouter une forme SmartArt avec la disposition `ORGANIZATION_CHART`.
3. Définir le type d’organigramme.
4. Enregistrer la présentation au format PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ajouter une forme SmartArt avec la disposition ORGANIZATION_CHART.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    # Définir le type d’organigramme.
    smart.nodes[0].organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    # Enregistrer la présentation.
    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Créer un organigramme illustré**

Aspose.Slides pour Python fournit une API simple pour créer facilement des organigrammes illustrés. Pour créer un organigramme sur une diapositive :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenir une référence à la diapositive par son indice.
3. Ajouter un organigramme avec les données par défaut du type souhaité.
4. Enregistrer la présentation modifiée au format PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    
    presentation.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Le SmartArt prend-il en charge le miroir/l’inversion pour les langues RTL ?**

Oui. La propriété [is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) inverse la direction du diagramme (LTR/RTL) si le type de SmartArt sélectionné prend en charge l’inversion.

**Comment copier un SmartArt sur la même diapositive ou dans une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/python-net/shape-manipulations/) via la collection de formes ([ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/)) ou [cloner la diapositive entière](/slides/fr/python-net/clone-slides/) contenant cette forme. Les deux approches conservent la taille, la position et le style.

**Comment rendre le SmartArt en image raster pour un aperçu ou une exportation web ?**

Vous pouvez [rendre la diapositive](/slides/fr/python-net/convert-powerpoint-to-png/) (ou l’ensemble de la présentation) en PNG/JPEG via l’API qui convertit les diapositives/présentations en images — le SmartArt sera dessiné comme partie de la diapositive.

**Comment sélectionner programmétiquement un SmartArt spécifique sur une diapositive s’il y en a plusieurs ?**

Une pratique courante consiste à utiliser le [texte alternatif](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/) (Alt Text) ou un [nom](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/name/) et rechercher la forme par cet attribut dans [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/). Puis vérifier le type pour confirmer qu’il s’agit d’un [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/). La documentation décrit les techniques typiques pour trouver et travailler avec les formes.