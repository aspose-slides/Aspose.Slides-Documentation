---
title: Gérer SmartArt dans les présentations PowerPoint à l'aide de Python
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
- organigramme illustré
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour Python via Java en utilisant des exemples de code clairs qui accélèrent la conception et l'automatisation des diapositives."
---
## **Overview**

SmartArt est un diagramme PowerPoint composé de nœuds, de formes de nœuds et d’une mise en page. Avec Aspose.Slides pour Python via Java, vous pouvez créer des SmartArt, lire le texte de leurs nœuds, modifier leur mise en page, inspecter les nœuds masqués, configurer les mises en page d’organigramme et créer des organigrammes illustrés.

## **Get Text from a SmartArt Object**

Un nœud SmartArt peut contenir une ou plusieurs formes. Pour lire le texte visible, parcourez [SmartArt.getAllNodes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/#getAllNodes), puis lisez le [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) renvoyé par [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartshape/#getTextFrame).

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

## **Change the Layout Type of a SmartArt Object**

La mise en page SmartArt contrôle la façon dont les nœuds sont disposés et connectés. L’exemple suivant crée un objet SmartArt avec la valeur `BasicBlockList` du [SmartArtLayoutType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartlayouttype/), la change en valeur `BasicProcess` et enregistre la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Check Whether a SmartArt Node Is Hidden**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartnode/#isHidden) indique si le nœud est masqué dans le modèle de données SmartArt. Les nœuds masqués peuvent exister dans la structure même lorsque la mise en page sélectionnée ne les affiche pas comme des éléments visibles du diagramme.

L’exemple suivant ajoute un nœud à un objet SmartArt qui utilise la valeur `RadialCycle` du [SmartArtLayoutType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartlayouttype/) et vérifie l’état masqué du nœud.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Get or Set the Organization Chart Layout**

Pour les diagrammes SmartArt qui utilisent une mise en page d’organigramme, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) et [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) définissent comment les nœuds enfants sont disposés sous un nœud parent. Par exemple, vous pouvez faire suspendre les nœuds enfants à gauche, à droite ou aux deux côtés, selon le [OrganizationChartLayoutType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/organizationchartlayouttype/) sélectionné.

L’exemple suivant crée un organigramme et définit la mise en page du premier nœud sur la valeur `LeftHanging` du [OrganizationChartLayoutType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/organizationchartlayouttype/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Create a Picture Organization Chart**

Un organigramme illustré est une mise en page SmartArt conçue pour les diagrammes hiérarchiques incluant des espaces réservés d’images. Utilisez la valeur `PictureOrganizationChart` du [SmartArtLayoutType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartlayouttype/) lors de l’ajout de l’objet SmartArt à une diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Does SmartArt support mirroring or reversing for RTL languages?**

Oui. La méthode [SmartArt.setReversed](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/#setReversed) inverse le sens du diagramme de gauche à droite à droite à gauche, ou inversement, lorsque la mise en page SmartArt sélectionnée prend en charge l’inversion.

**How can I copy SmartArt to the same slide or to another presentation while preserving formatting?**

Vous pouvez [clone the SmartArt shape](/slides/fr/python-java/shape-manipulations/) avec [ShapeCollection.addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addClone) ou [clone the whole slide](/slides/fr/python-java/clone-slides/) qui contient le SmartArt. Les deux approches conservent la taille, la position et le formatage.

**How do I render SmartArt to a raster image for preview or web export?**

[Rend the slide](/slides/fr/python-java/convert-powerpoint-to-png/) ou toute la présentation en PNG ou JPEG. Le SmartArt est rendu comme partie de la diapositive.

**How can I find a specific SmartArt object on a slide if there are several?**

Définissez une valeur distinctive pour [Shape.getAlternativeText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getAlternativeText) ou [Shape.getName](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getName) sur la forme SmartArt, recherchez cette valeur dans [BaseSlide.getShapes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/#getShapes), puis vérifiez que la forme correspondante est un [SmartArt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/).