---
title: Gérer SmartArt dans les présentations PowerPoint avec Python
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/python-java/manage-smartart/
keywords:
- SmartArt
- texte SmartArt
- type de mise en page
- propriété masquée
- organigramme
- organigramme avec image
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour Python via Java en utilisant des exemples de code clairs qui accélèrent la conception de diapositives et l'automatisation."
---
## **Vue d'ensemble**

SmartArt est un diagramme PowerPoint composé de nœuds, de formes de nœuds et d’une mise en page. Avec Aspose.Slides for Python via Java, vous pouvez créer des SmartArt, lire le texte de leurs nœuds, modifier leur mise en page, inspecter les nœuds masqués, configurer les mises en page de diagrammes d’organisation et créer des diagrammes d’organisation avec images.

## **Obtenir le texte d’un objet SmartArt**

Un nœud SmartArt peut contenir une ou plusieurs formes. Pour lire le texte des formes du nœud, parcourez [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes), puis lisez le [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) renvoyé par [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame).

L’exemple nécessite une présentation contenant au moins une diapositive et un objet SmartArt comme première forme de cette diapositive. Il affiche chaque cadre de texte disponible dans la console.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape
        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **Modifier le type de mise en page d’un objet SmartArt**

La mise en page SmartArt détermine comment les nœuds sont disposés et connectés. L’exemple suivant crée un objet SmartArt avec le type de mise en page [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, le change en `BasicProcess` et enregistre la présentation. La position et la taille passées à [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt) sont exprimées en points. Utilisez [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout) pour modifier la mise en page.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vérifier si un nœud SmartArt est masqué**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) indique si le nœud est masqué dans le modèle de données SmartArt. Les nœuds masqués peuvent exister dans la structure même lorsque la mise en page sélectionnée ne les affiche pas comme éléments visibles du diagramme.

L’exemple suivant ajoute un nœud à un objet SmartArt qui utilise le type de mise en page [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` et vérifie l’état masqué du nœud ajouté. Il affiche un message si le nœud est masqué et enregistre le diagramme.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)
    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obtenir ou définir la mise en page du diagramme d’organisation**

Pour les diagrammes SmartArt utilisant une mise en page de diagramme d’organisation, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) et [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) définissent comment les nœuds enfants sont disposés sous un nœud parent. Par exemple, vous pouvez faire pendre les nœuds enfants à gauche, à droite ou des deux côtés, selon le type de mise en page [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) sélectionné.

L’exemple suivant crée un diagramme d’organisation et définit la mise en page du premier nœud sur le type [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. L’indice de base zéro `0` sélectionne le premier nœud de niveau supérieur ; ses nœuds enfants utilisent l’arrangement sélectionné. La présentation modifiée est ensuite enregistrée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)
    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Créer un diagramme d’organisation avec image**

Un diagramme d’organisation avec image est une mise en page SmartArt conçue pour les diagrammes hiérarchiques incluant des espaces réservés d’image. Utilisez le type de mise en page [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` lors de l’ajout de l’objet SmartArt à une diapositive. Cet exemple enregistre un diagramme avec des espaces réservés d’image ; il ne les remplit pas avec des images.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Convertir les diagrammes hérités en groupes de formes**

Lorsque vous modernisez une présentation existante, il peut être nécessaire de mettre à jour un diagramme d’organisation créé à l’origine dans PowerPoint 97–2003. Aspose.Slides représente ces diagrammes hérités comme des objets [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/). Utilisez [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape) pour convertir un diagramme en groupe de formes afin de pouvoir modifier les éléments visuels individuels. Consultez la [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) pour plus de détails.

La conversion ajoute un nouveau groupe à la collection de formes sans supprimer le diagramme original. Après une conversion réussie, supprimez l’original avec [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) pour éviter le contenu dupliqué. Rassemblez les diagrammes hérités dans une liste avant de les convertir afin que l’ajout et la suppression de formes ne perturbent pas l’itération.

L’exemple suivant ouvre une présentation, parcourt chaque diapositive, convertit les diagrammes en groupes de formes et enregistre la présentation mise à jour au format PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LegacyDiagram, Presentation, SaveFormat

presentation = Presentation("legacy-diagrams.ppt")
try:
    for slide in presentation.getSlides():
        legacy_diagrams = []
        for shape in slide.getShapes():
            if isinstance(shape, LegacyDiagram):
                legacy_diagrams.append(shape)

        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convertToGroupShape()

            if group_shape is not None:
                slide.getShapes().remove(legacy_diagram)

    presentation.save("modernized.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La présentation enregistrée contient des groupes de formes modifiables à la place des diagrammes hérités convertis, aucun diagramme original n’est laissé à leurs côtés. Ouvrez le PPTX dans PowerPoint pour modifier les éléments individuels de chaque groupe, tels que le texte, le remplissage ou la position.

## **FAQ**

**Le SmartArt prend‑t‑il en charge le miroir ou l’inversion pour les langues RTL ?**

Oui. La méthode [SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) bascule la direction du diagramme de gauche à droite à droite à gauche, ou inversement, lorsque la mise en page SmartArt sélectionnée prend en charge l’inversion.

**Comment copier le SmartArt sur la même diapositive ou vers une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/python-java/shape-manipulations/) avec [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) ou [cloner la diapositive entière](/slides/fr/python-java/clone-slides/) qui contient le SmartArt. Les deux approches conservent la taille, la position et le formatage.

**Comment rendre le SmartArt en image raster pour un aperçu ou une exportation Web ?**

[Render the slide](/slides/fr/python-java/convert-powerpoint-to-png/) ou la présentation complète en PNG ou JPEG. Le SmartArt est rendu comme partie de la diapositive.

**Comment trouver un objet SmartArt spécifique sur une diapositive s’il y en a plusieurs ?**

Utilisez [Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) ou [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName) pour attribuer un texte alternatif ou un nom distinctif à la forme SmartArt, recherchez cette valeur avec [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes), puis vérifiez que la forme correspondante est un [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/).