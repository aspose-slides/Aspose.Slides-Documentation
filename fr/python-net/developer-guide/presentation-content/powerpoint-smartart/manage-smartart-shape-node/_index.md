---
title: Gérer le nœud de forme SmartArt
type: docs
weight: 30
url: /python-net/manage-smartart-shape-node/
keywords: "nœud SmartArt, nœud enfant SmartArt, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Nœud intelligent et nœud enfant dans les présentations PowerPoint en Python"
---


## **Ajouter un nœud SmartArt**
Aspose.Slides pour Python via .NET a fourni l'API la plus simple pour gérer les formes SmartArt de la manière la plus facile. Le code d'exemple suivant vous aidera à ajouter un nœud et un nœud enfant à l'intérieur de la forme SmartArt.

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et effectuez un typage de la forme sélectionnée en SmartArt si c'est du SmartArt.
- Ajoutez un nouveau nœud dans la collection NodeCollection de la forme SmartArt et définissez le texte dans le TextFrame.
- Maintenant, ajoutez un nœud enfant dans le nœud SmartArt nouvellement ajouté et définissez le texte dans le TextFrame.
- Enregistrez la présentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Charger la présentation désirée
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Parcourez chaque forme à l'intérieur de la première diapositive
    for shape in pres.slides[0].shapes:

        # Vérifiez si la forme est de type SmartArt
        if type(shape) is art.SmartArt:
            # Ajout d'un nouveau nœud SmartArt
            node1 = shape.all_nodes.add_node()
            # Ajout de texte
            node1.text_frame.text = "Test"

            # Ajout d'un nouveau nœud enfant dans le nœud parent. Il sera ajouté à la fin de la collection
            new_node = node1.child_nodes.add_node()

            # Ajout de texte
            new_node.text_frame.text = "Nouveau nœud ajouté"

    # Enregistrement de la présentation
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Ajouter un nœud SmartArt à une position spécifique**
Dans le code d'exemple suivant, nous avons expliqué comment ajouter les nœuds enfants appartenant aux nœuds respectifs de la forme SmartArt à une position particulière.

- Créez une instance de la classe `Presentation`.
- Obtenez la référence de la première diapositive en utilisant son index.
- Ajoutez une forme SmartArt de type StackedList dans la diapositive accédée.
- Accédez au premier nœud dans la forme SmartArt ajoutée.
- Maintenant, ajoutez le nœud enfant pour le nœud sélectionné à la position 2 et définissez son texte.
- Enregistrez la présentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Création d'une instance de présentation
with slides.Presentation() as pres:
    # Accéder à la diapositive de présentation
    slide = pres.slides[0]

    # Ajouter une forme SmartArt IShape
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # Accéder au premier nœud dans la forme SmartArt ajoutée
    node = smart.all_nodes[0]

    # Ajout d'un nouveau nœud enfant à la position 2 dans le nœud parent
    chNode = node.child_nodes.add_node_by_position(2)

    # Ajouter du texte
    chNode.text_frame.text = "Texte d'exemple ajouté"

    # Enregistrer la présentation
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Accéder au nœud SmartArt**
Le code d'exemple suivant vous aidera à accéder aux nœuds à l'intérieur de la forme SmartArt. Veuillez noter que vous ne pouvez pas changer le LayoutType du SmartArt car il est en lecture seule et est défini uniquement lorsque la forme SmartArt est ajoutée.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et effectuez un typage de la forme sélectionnée en SmartArt si c'est du SmartArt.
- Parcourez tous les nœuds à l'intérieur de la forme SmartArt.
- Accédez et affichez des informations telles que la position du nœud SmartArt, le niveau et le texte.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Charger la présentation désirée
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Parcourez chaque forme à l'intérieur de la première diapositive
    for shape in pres.slides[0].shapes:
        # Vérifiez si la forme est de type SmartArt
        if type(shape) is art.SmartArt:
            # Parcourez tous les nœuds à l'intérieur de SmartArt
            for i in range(len(shape.all_nodes)):
                # Accéder au nœud SmartArt à l'index i
                node = shape.all_nodes[i]

                # Imprimer les paramètres du nœud SmartArt
                print("i = {0}, texte = {1},  niveau = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
  ```

  


## **Accéder aux nœuds enfants SmartArt**
Le code d'exemple suivant vous aidera à accéder aux nœuds enfants appartenant aux nœuds respectifs de la forme SmartArt.

- Créez une instance de la classe PresentationEx et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et effectuez un typage de la forme sélectionnée en SmartArtEx si c'est du SmartArt.
- Parcourez tous les nœuds à l'intérieur de la forme SmartArt.
- Pour chaque nœud de forme SmartArt sélectionné, parcourez tous les nœuds enfants à l'intérieur du nœud particulier.
- Accédez et affichez des informations telles que la position du nœud enfant, le niveau et le texte.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Charger la présentation désirée
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Parcourez chaque forme à l'intérieur de la première diapositive
    for shape in pres.slides[0].shapes:
        # Vérifiez si la forme est de type SmartArt
        if type(shape) is art.SmartArt:
            # Parcourez tous les nœuds à l'intérieur de SmartArt
            for node0 in shape.all_nodes:
                # Parcours des nœuds enfants
                for j in range(len(node0.child_nodes)):
                    # Accéder au nœud enfant dans le nœud SmartArt
                    node = node0.child_nodes[j]

                    # Imprimer les paramètres du nœud enfant SmartArt
                    print("j = {0}, texte = {1},  niveau = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))

```



## **Accéder au nœud enfant SmartArt à une position spécifique**
Dans cet exemple, nous allons apprendre à accéder aux nœuds enfants à une position particulière appartenant aux nœuds respectifs de la forme SmartArt.

- Créez une instance de la classe `Presentation`.
- Obtenez la référence de la première diapositive en utilisant son index.
- Ajoutez une forme SmartArt de type StackedList.
- Accédez à la forme SmartArt ajoutée.
- Accédez au nœud à l'index 0 pour la forme SmartArt accédée.
- Maintenant, accédez au nœud enfant à la position 1 pour le nœud SmartArt accédé en utilisant la méthode GetNodeByPosition().
- Accédez et affichez des informations telles que la position du nœud enfant, le niveau et le texte.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Instancier la présentation
with slides.Presentation() as pres:
    # Accéder à la première diapositive
    slide = pres.slides[0]
    # Ajouter la forme SmartArt dans la première diapositive
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # Accéder au nœud SmartArt à l'index 0
    node = smart.all_nodes[0]
    # Accéder au nœud enfant à la position 1 dans le nœud parent
    position = 1
    chNode = node.child_nodes[position] 
    # Imprimer les paramètres du nœud enfant SmartArt
    print("j = {0}, texte = {1},  niveau = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```



## **Supprimer un nœud SmartArt**
Dans cet exemple, nous allons apprendre à supprimer les nœuds à l'intérieur de la forme SmartArt.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et effectuez un typage de la forme sélectionnée en SmartArt si c'est du SmartArt.
- Vérifiez si le SmartArt a plus de 0 nœuds.
- Sélectionnez le nœud SmartArt à supprimer.
- Maintenant, supprimez le nœud sélectionné en utilisant la méthode RemoveNode() et enregistrez la présentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Charger la présentation désirée
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Parcourez chaque forme à l'intérieur de la première diapositive
    for shape in pres.slides[0].shapes:
        # Vérifiez si la forme est de type SmartArt
        if type(shape) is art.SmartArt:
            # Typecast la forme en SmartArtEx
            if len(shape.all_nodes) > 0:
                # Accéder au nœud SmartArt à l'index 0
                node = shape.all_nodes[0]

                # Supprimer le nœud sélectionné
                shape.all_nodes.remove_node(node)

    # Enregistrer la présentation
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Supprimer un nœud SmartArt à une position spécifique**
Dans cet exemple, nous allons apprendre à supprimer les nœuds à l'intérieur de la forme SmartArt à une position particulière.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et effectuez un typage de la forme sélectionnée en SmartArt si c'est du SmartArt.
- Sélectionnez le nœud de forme SmartArt à l'index 0.
- Maintenant, vérifiez si le nœud SmartArt sélectionné a plus de 2 nœuds enfants.
- Maintenant, supprimez le nœud à la position 1 en utilisant la méthode RemoveNodeByPosition().
- Enregistrez la présentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Charger la présentation désirée
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # Parcourez chaque forme à l'intérieur de la première diapositive
    for shape in pres.slides[0].shapes:
        # Vérifiez si la forme est de type SmartArt
        if type(shape) is art.SmartArt:
            # Typecast la forme en SmartArt
            if len(shape.all_nodes) > 0:
                # Accéder au nœud SmartArt à l'index 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Supprimer le nœud enfant à la position 1
                    node.child_nodes.remove_node(1)

    # Enregistrer la présentation
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Définir une position personnalisée pour un nœud enfant dans SmartArt**
Maintenant, Aspose.Slides pour Python via .NET prend en charge la définition des propriétés X et Y de SmartArtShape. Le code ci-dessous montre comment définir la position, la taille et la rotation de SmartArtShape, et veuillez noter que l'ajout de nouveaux nœuds entraîne un recalcul des positions et des tailles de tous les nœuds.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Charger la présentation désirée
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
    smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

    # Déplacer la forme SmartArt à une nouvelle position
    node = smart.all_nodes[1]
    shape = node.shapes[1]
    shape.x += (shape.width * 2)
    shape.y -= (shape.height / 2)

    # Changer les largeurs de la forme SmartArt
    node = smart.all_nodes[2]
    shape = node.shapes[1]
    shape.width += (shape.width / 2)

    # Changer la hauteur de la forme SmartArt
    node = smart.all_nodes[3]
    shape = node.shapes[1]
    shape.height += (shape.height / 2)

    # Changer la rotation de la forme SmartArt
    node = smart.all_nodes[4]
    shape = node.shapes[1]
    shape.rotation = 90

    pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```



## **Vérifier le nœud assistant**
Dans le code d'exemple suivant, nous allons enquêter sur la façon d'identifier les nœuds assistants dans la collection de nœuds SmartArt et de les modifier.

- Créez une instance de la classe PresentationEx et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la seconde diapositive en utilisant son index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et effectuez un typage de la forme sélectionnée en SmartArtEx si c'est du SmartArt.
- Parcourez tous les nœuds à l'intérieur de la forme SmartArt et vérifiez s'ils sont des nœuds assistants.
- Changez le statut du nœud assistant en nœud normal.
- Enregistrez la présentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Création d'une instance de présentation
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Parcourez chaque forme à l'intérieur de la première diapositive
    for shape in pres.slides[0].shapes:
        # Vérifiez si la forme est de type SmartArt
        if type(shape) is art.SmartArt:
            # Parcourir tous les nœuds de la forme SmartArt
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Vérifiez si le nœud est un nœud assistant
                if node.is_assistant:
                    # Définir le nœud assistant sur false et le rendre nœud normal
                    node.is_assistant = False
    # Enregistrer la présentation
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Définir le format de remplissage d'un nœud**
Aspose.Slides pour Python via .NET permet d'ajouter des formes SmartArt personnalisées et de définir leurs formats de remplissage. Cet article explique comment créer et accéder aux formes SmartArt et définir leur format de remplissage à l'aide d'Aspose.Slides pour Python via .NET.

Veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe `Presentation`.
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez une forme SmartArt en définissant son LayoutType.
- Définissez le format de remplissage pour les nœuds de la forme SmartArt.
- Écrivez la présentation modifiée sous forme de fichier PPTX.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # Accéder à la diapositive
    slide = presentation.slides[0]

    # Ajouter une forme SmartArt et des nœuds
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Du texte"

    # Définir la couleur de remplissage du nœud
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Enregistrement de la présentation
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Générer une miniature du nœud enfant SmartArt**
Les développeurs peuvent générer une miniature du nœud enfant d'un SmartArt en suivant les étapes ci-dessous :

1. Instanciez la classe `Presentation` qui représente le fichier PPTX.
1. Ajoutez du SmartArt.
1. Obtenez la référence d'un nœud en utilisant son index.
1. Obtenez l'image miniature.
1. Enregistrez l'image miniature dans le format d'image souhaité.

L'exemple ci-dessous génère une miniature du nœud enfant SmartArt.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Instancier la classe Presentation qui représente le fichier PPTX 
with slides.Presentation() as presentation: 
    # Ajouter du SmartArt 
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Obtenez la référence d'un nœud en utilisant son index  
    node = smart.nodes[1]

    # Obtenir la miniature
    with node.shapes[0].get_image() as bmp:
        # enregistrer la miniature
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```