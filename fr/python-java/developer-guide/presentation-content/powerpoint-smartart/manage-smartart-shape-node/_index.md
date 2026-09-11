---
title: Gérer les nœuds de forme SmartArt dans les présentations avec Python
linktitle: Nœud de forme SmartArt
type: docs
weight: 30
url: /fr/python-java/manage-smartart-shape-node/
keywords:
- nœud SmartArt
- nœud enfant
- ajouter un nœud
- position du nœud
- accéder au nœud
- supprimer un nœud
- position personnalisée
- nœud assistant
- format de remplissage
- rendre le nœud
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Gérez les nœuds de forme SmartArt dans PPT et PPTX avec Aspose.Slides for Python via Java. Obtenez des exemples de code clairs et des astuces pour optimiser vos présentations."
---
## **Vue d'ensemble**

Les graphiques SmartArt dans les présentations PowerPoint sont organisés à travers des nœuds contenant du texte et définissant la structure du diagramme. Aspose.Slides vous permet de travailler avec ces nœuds SmartArt de manière programmatique : ajouter de nouveaux nœuds et nœuds enfants, insérer des nœuds enfants à une position spécifique, accéder aux nœuds existants et lire leur texte, leur niveau et leur position.

Cet article explique comment gérer les nœuds de forme SmartArt. Il montre comment supprimer des nœuds, travailler avec des nœuds enfants par indice ou par position, transformer un nœud assistant en nœud normal, ajuster la position, la taille et la rotation des formes de nœuds SmartArt, définir les formats de remplissage des nœuds et générer une image miniature pour un nœud enfant SmartArt.

## **Ajouter un nœud SmartArt**
Aspose.Slides for Python via Java fournit une API pour gérer les formes SmartArt. L’exemple suivant ajoute un nœud et un nœud enfant à une forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et chargez la présentation contenant une forme SmartArt.  
1. Obtenez la première diapositive par son indice.  
1. Parcourez chaque forme de la première diapositive.  
1. Vérifiez si la forme est une instance [SmartArt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/).  
1. [Ajoutez un nouveau nœud](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartnodecollection/#addNode) à la [collection de nœuds](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/#getAllNodes) de la forme SmartArt et définissez son texte via [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/).  
1. [Ajoutez](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartnodecollection/#addNode) un [nœud enfant](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartnode/#getChildNodes) au nouveau nœud et définissez son texte via [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/).  
1. Enregistrez la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ajouter un nœud SmartArt à une position spécifique**
L’exemple suivant ajoute un nœud enfant à une position précise dans un nœud SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).  
1. Obtenez la première diapositive par son indice.  
1. Ajoutez une forme [SmartArt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/) avec la disposition [StackedList](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartlayouttype/#StackedList) à la diapositive.  
1. Accédez au premier nœud de la forme SmartArt ajoutée.  
1. Ajoutez un nœud enfant au nœud sélectionné à la position 2 en utilisant [addNodeByPosition](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) et définissez son texte.  
1. Enregistrez la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Accéder à un nœud SmartArt**
L’exemple suivant accède aux nœuds d’une forme SmartArt. La disposition renvoyée par [getLayout](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/#getLayout) est en lecture seule et est définie lors de l’ajout de la forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et chargez la présentation contenant une forme SmartArt.  
1. Obtenez la première diapositive par son indice.  
1. Parcourez chaque forme de la première diapositive.  
1. Vérifiez si la forme est une instance [SmartArt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/).  
1. Parcourez tous les [nœuds](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/#getAllNodes) de la forme SmartArt.  
1. Lisez et affichez la position, le niveau et le texte de chaque nœud SmartArt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```

## **Accéder à un nœud enfant SmartArt**
L’exemple suivant accède aux nœuds enfants de chaque nœud d’une forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et chargez la présentation contenant une forme SmartArt.  
1. Obtenez la première diapositive par son indice.  
1. Parcourez chaque forme de la première diapositive.  
1. Vérifiez si la forme est une instance [SmartArt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/).  
1. Parcourez tous les [nœuds](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/#getAllNodes) de la forme SmartArt.  
1. Pour chaque nœud, parcourez ses [nœuds enfants](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartnode/#getChildNodes).  
1. Lisez et affichez la position, le niveau et le texte du [nœud enfant](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartnode/#getChildNodes).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **Accéder à un nœud enfant SmartArt à une position spécifique**
L’exemple suivant accède à un nœud enfant à un indice précis dans la collection du nœud parent.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).  
1. Obtenez la première diapositive par son indice.  
1. Ajoutez une forme SmartArt avec la disposition [StackedList](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartlayouttype/#StackedList).  
1. Accédez à la forme SmartArt ajoutée.  
1. Accédez au nœud d’indice 0 dans la forme SmartArt.  
1. Accédez au nœud enfant d’indice 1 en utilisant [get_Item](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartnodecollection/#get_Item).  
1. Lisez et affichez la position, le niveau et le texte du [nœud enfant](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartnode/#getChildNodes).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **Supprimer un nœud SmartArt**
L’exemple suivant supprime un nœud d’une forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et chargez la présentation contenant une forme SmartArt.  
1. Obtenez la première diapositive par son indice.  
1. Parcourez chaque forme de la première diapositive.  
1. Vérifiez si la forme est une instance [SmartArt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/).  
1. Vérifiez que la forme [SmartArt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/) contient au moins un nœud.  
1. Sélectionnez le nœud SmartArt à supprimer.  
1. Supprimez le nœud sélectionné en utilisant [removeNode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartnodecollection/#removeNode).  
1. Enregistrez la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Supprimer un nœud SmartArt d'une position spécifique**
L’exemple suivant supprime un nœud enfant à un indice précis dans la collection d’un nœud SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et chargez la présentation contenant une forme SmartArt.  
1. Obtenez la première diapositive par son indice.  
1. Parcourez chaque forme de la première diapositive.  
1. Vérifiez si la forme est une instance [SmartArt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/).  
1. Accédez au nœud SmartArt d’indice 0 s’il existe.  
1. Vérifiez que le nœud SmartArt sélectionné possède au moins deux nœuds enfants.  
1. Supprimez le nœud enfant d’indice 1 en utilisant [removeNode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartnodecollection/#removeNode).  
1. Enregistrez la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir une position personnalisée pour un nœud enfant dans un objet SmartArt**
Aspose.Slides for Python via Java prend en charge le positionnement d’un [SmartArtShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartshape/) à l’aide de [setX](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#setX) et [setY](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#setY). L’exemple suivant définit une position, une taille et une rotation personnalisées pour les formes de nœuds SmartArt. L’ajout de nouveaux nœuds recalcule les positions et tailles de tous les nœuds. Le positionnement personnalisé vous permet d’organiser les nœuds comme vous le souhaitez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vérifier un nœud assistant**
{{% alert color="info" title="Note" %}} 

Cette section explore les formes SmartArt ajoutées aux diapositives de présentation de manière programmatique à l'aide d'Aspose.Slides pour Python via Java.

{{% /alert %}} 

La forme SmartArt source utilisée dans cet exemple est la suivante.

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figure : forme SmartArt source sur une diapositive**|

L’exemple suivant identifie les nœuds assistants dans une collection de nœuds SmartArt et les transforme en nœuds normaux.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et chargez la présentation contenant une forme SmartArt.  
1. Obtenez la première diapositive par son indice.  
1. Parcourez chaque forme de la première diapositive.  
1. Vérifiez si la forme est une instance [SmartArt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/).  
1. Parcourez tous les nœuds de la forme SmartArt et vérifiez s’ils sont des [Assistant Nodes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartnode/#isAssistant).  
1. Transformez chaque nœud assistant en nœud normal.  
1. Enregistrez la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figure : nœuds assistants modifiés dans une forme SmartArt sur une diapositive**|

## **Définir le format de remplissage d'un nœud**
Aspose.Slides for Python via Java rend possible l’ajout de formes SmartArt personnalisées et la définition de leur format de remplissage. Cet article explique comment créer et accéder aux formes SmartArt et définir leur format de remplissage à l’aide d’Aspose.Slides for Python via Java.

Veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).  
1. Obtenez une diapositive par son indice.  
1. Ajoutez une forme [SmartArt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/) avec la disposition [ClosedChevronProcess](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess).  
1. Définissez le [FillFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getFillFormat) pour les nœuds de la forme SmartArt.  
1. Écrivez la présentation modifiée au format PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Générer une miniature d'un nœud enfant SmartArt**
Pour générer une miniature d’un nœud enfant SmartArt, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).  
1. [Ajoutez une forme SmartArt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addSmartArt).  
1. Obtenez un nœud par son indice.  
1. Récupérez l’image miniature.  
1. Enregistrez l’image miniature dans le format d’image souhaité.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**L'animation SmartArt est‑elle prise en charge ?**

Oui. SmartArt est traité comme une forme ordinaire, vous pouvez donc [appliquer des animations standard](/slides/fr/python-java/shape-animation/) (entrée, sortie, mise en valeur, trajectoires) et ajuster le timing. Vous pouvez également animer les formes contenues dans les nœuds SmartArt lorsque c’est nécessaire.

**Comment puis‑je localiser de manière fiable un SmartArt spécifique sur une diapositive si son ID interne est inconnu ?**

Attribuez et recherchez par [alternative text](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getAlternativeText). La définition d’un texte alternatif distinctif sur le SmartArt vous permet de le trouver programmatiquement sans vous reposer sur les identifiants internes.

**L'apparence du SmartArt sera‑t‑elle conservée lors de la conversion de la présentation en PDF ?**

Oui. Aspose.Slides rend le SmartArt avec une grande fidélité visuelle pendant l’[export PDF](/slides/fr/python-java/convert-powerpoint-to-pdf/), préservant la mise en page, les couleurs et les effets.

**Puis‑je extraire une image du SmartArt complet (pour les aperçus ou les rapports) ?**

Oui. Vous pouvez rendre une forme SmartArt en [formats raster](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getImage) ou en [SVG](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#writeAsSvgToBytes) pour une sortie vectorielle évolutive, ce qui convient aux miniatures, aux rapports ou à une utilisation web.