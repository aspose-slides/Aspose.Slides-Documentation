---
title: Gérer les nœuds de forme SmartArt dans les présentations avec Python
linktitle: Nœud de forme SmartArt
type: docs
weight: 30
url: /fr/python-net/manage-smartart-shape-node/
keywords:
- Nœud SmartArt
- Nœud enfant
- Ajouter un nœud
- Position du nœud
- Accéder au nœud
- Supprimer le nœud
- Position personnalisée
- Nœud assistant
- Format de remplissage
- Rendu du nœud
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Gérez les nœuds de forme SmartArt dans PPT, PPTX et ODP avec Aspose.Slides pour Python via .NET. Obtenez des exemples de code clairs et des astuces pour rationaliser vos présentations."
---

## **Ajouter un nœud SmartArt**
Aspose.Slides for Python via .NET a fourni l’API la plus simple pour gérer les formes SmartArt de la façon la plus facile. Le code d’exemple ci‑ci vous aidera à ajouter un nœud et un nœud enfant dans une forme SmartArt.

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation contenant une forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son indice.
- Parcourez chaque forme de la première diapositive.
- Vérifiez si la forme est de type SmartArt et casterez la forme sélectionnée en SmartArt si c’est le cas.
- Ajoutez un nouveau nœud dans la NodeCollection de la forme SmartArt et définissez le texte dans le TextFrame.
- Ensuite, ajoutez un nœud enfant au nœud SmartArt nouvellement ajouté et définissez le texte dans le TextFrame.
- Enregistrez la présentation.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Charger la présentation souhaitée
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Parcourir chaque forme de la première diapositive
    for shape in pres.slides[0].shapes:

        # Vérifier si la forme est de type SmartArt
        if type(shape) is art.SmartArt:
            # Ajouter un nouveau nœud SmartArt
            node1 = shape.all_nodes.add_node()
            # Ajouter du texte
            node1.text_frame.text = "Test"

            # Ajouter un nouveau nœud enfant dans le nœud parent. Il sera ajouté à la fin de la collection
            new_node = node1.child_nodes.add_node()

            # Ajouter du texte
            new_node.text_frame.text = "New Node Added"

    # Enregistrer la présentation
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Ajouter un nœud SmartArt à une position spécifique**
Dans le code d’exemple suivant, nous expliquons comment ajouter les nœuds enfants appartenant aux nœuds respectifs d’une forme SmartArt à une position particulière.

- Créez une instance de la classe `Presentation`.
- Obtenez la référence de la première diapositive en utilisant son indice.
- Ajoutez une forme SmartArt de type StackedList sur la diapositive sélectionnée.
- Accédez au premier nœud de la forme SmartArt ajoutée.
- Ensuite, ajoutez le nœud enfant du nœud sélectionné à la position 2 et définissez son texte.
- Enregistrez la présentation.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Créer une instance de présentation
with slides.Presentation() as pres:
    # Accéder à la diapositive de la présentation
    slide = pres.slides[0]

    # Ajouter une forme Smart Art IShape
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # Accéder au nœud SmartArt à l'index 0
    node = smart.all_nodes[0]

    # Ajouter un nouveau nœud enfant à la position 2 dans le nœud parent
    chNode = node.child_nodes.add_node_by_position(2)

    # Ajouter du texte
    chNode.text_frame.text = "Sample text Added"

    # Enregistrer la présentation
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Accéder au nœud SmartArt**
Le code d’exemple ci‑ci vous aidera à accéder aux nœuds d’une forme SmartArt. Veuillez noter que vous ne pouvez pas modifier le LayoutType du SmartArt car il est en lecture seule et n’est défini que lors de l’ajout de la forme SmartArt.

- Créez une instance de la classe `Presentation` et chargez la présentation contenant une forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son indice.
- Parcourez chaque forme de la première diapositive.
- Vérifiez si la forme est de type SmartArt et casterez la forme sélectionnée en SmartArt si c’est le cas.
- Parcourez tous les nœuds à l’intérieur de la forme SmartArt.
- Accédez et affichez des informations telles que la position du nœud SmartArt, le niveau et le texte.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Charger la présentation souhaitée
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Parcourir chaque forme de la première diapositive
    for shape in pres.slides[0].shapes:
        # Vérifier si la forme est de type SmartArt
        if type(shape) is art.SmartArt:
            # Parcourir tous les nœuds du SmartArt
            for i in range(len(shape.all_nodes)):
                # Accéder au nœud SmartArt à l'index i
                node = shape.all_nodes[i]

                # Afficher les paramètres du nœud SmartArt
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```


## **Accéder au nœud enfant SmartArt**
Le code d’exemple ci‑ci vous aidera à accéder aux nœuds enfants appartenant aux nœuds respectifs d’une forme SmartArt.

- Créez une instance de la classe PresentationEx et chargez la présentation contenant une forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son indice.
- Parcourez chaque forme de la première diapositive.
- Vérifiez si la forme est de type SmartArt et casterez la forme sélectionnée en SmartArtEx si c’est le cas.
- Parcourez tous les nœuds à l’intérieur de la forme SmartArt.
- Pour chaque nœud de forme SmartArt sélectionné, parcourez tous les nœuds enfants à l’intérieur du nœud particulier.
- Accédez et affichez des informations telles que la position du nœud enfant, le niveau et le texte.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Charger la présentation souhaitée
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Parcourir chaque forme de la première diapositive
    for shape in pres.slides[0].shapes:
        # Vérifier si la forme est de type SmartArt
        if type(shape) is art.SmartArt:
            # Parcourir tous les nœuds du SmartArt
            for node0 in shape.all_nodes:
                # Parcourir les nœuds enfants
                for j in range(len(node0.child_nodes)):
                    # Accéder au nœud enfant du nœud SmartArt
                    node = node0.child_nodes[j]

                    # Afficher les paramètres du nœud enfant SmartArt
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))
```


## **Accéder au nœud enfant SmartArt à une position spécifique**
Dans cet exemple, nous apprendrons à accéder aux nœuds enfants à une position particulière appartenant aux nœuds respectifs d’une forme SmartArt.

- Créez une instance de la classe `Presentation`.
- Obtenez la référence de la première diapositive en utilisant son indice.
- Ajoutez une forme SmartArt de type StackedList.
- Accédez à la forme SmartArt ajoutée.
- Accédez au nœud d’index 0 de la forme SmartArt sélectionnée.
- Ensuite, accédez au nœud enfant à la position 1 du nœud SmartArt sélectionné en utilisant la méthode GetNodeByPosition().
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
        # Afficher les paramètres du nœud enfant SmartArt
        print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))
```


## **Supprimer un nœud SmartArt**
Dans cet exemple, nous apprendrons à supprimer les nœuds à l’intérieur d’une forme SmartArt.

- Créez une instance de la classe `Presentation` et chargez la présentation contenant une forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son indice.
- Parcourez chaque forme de la première diapositive.
- Vérifiez si la forme est de type SmartArt et casterez la forme sélectionnée en SmartArt si c’est le cas.
- Vérifiez si le SmartArt possède plus de 0 nœud.
- Sélectionnez le nœud SmartArt à supprimer.
- Ensuite, supprimez le nœud sélectionné en utilisant la méthode RemoveNode() * Enregistrez la présentation.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Charger la présentation souhaitée
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Parcourir chaque forme de la première diapositive
    for shape in pres.slides[0].shapes:
        # Vérifier si la forme est de type SmartArt
        if type(shape) is art.SmartArt:
            # Caster la forme en SmartArtEx
            if len(shape.all_nodes) > 0:
                # Accéder au nœud SmartArt à l'index 0
                node = shape.all_nodes[0]

                # Supprimer le nœud sélectionné
                shape.all_nodes.remove_node(node)

    # Enregistrer la présentation
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Supprimer un nœud SmartArt à une position spécifique**
Dans cet exemple, nous apprendrons à supprimer les nœuds à l’intérieur d’une forme SmartArt à une position particulière.

- Créez une instance de la classe `Presentation` et chargez la présentation contenant une forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son indice.
- Parcourez chaque forme de la première diapositive.
- Vérifiez si la forme est de type SmartArt et casterez la forme sélectionnée en SmartArt si c’est le cas.
- Sélectionnez le nœud de forme SmartArt d’index 0.
- Ensuite, vérifiez si le nœud SmartArt sélectionné possède plus de 2 nœuds enfants.
- Ensuite, supprimez le nœud à la position 1 en utilisant la méthode RemoveNodeByPosition().
- Enregistrez la présentation.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Charger la présentation souhaitée
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # Parcourir chaque forme de la première diapositive
    for shape in pres.slides[0].shapes:
        # Vérifier si la forme est de type SmartArt
        if type(shape) is art.SmartArt:
            # Caster la forme en SmartArt
            if len(shape.all_nodes) > 0:
                # Accéder au nœud SmartArt à l'index 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Supprimer le nœud enfant à la position 1
                    node.child_nodes.remove_node(1)

    # Enregistrer la présentation
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir une position personnalisée pour le nœud enfant dans SmartArt**
Aspose.Slides for Python via .NET prend désormais en charge la définition des propriétés X et Y de SmartArtShape. Le fragment de code ci‑dessous montre comment définir la position, la taille et la rotation personnalisées de SmartArtShape ; veuillez noter que l’ajout de nouveaux nœuds entraîne un recalcul des positions et des tailles de tous les nœuds.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Charger la présentation souhaitée
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# Déplacer la forme SmartArt vers une nouvelle position
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# Modifier la largeur de la forme SmartArt
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# Modifier la hauteur de la forme SmartArt
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# Modifier la rotation de la forme SmartArt
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```


## **Vérifier le nœud assistant**
Dans le code d’exemple suivant, nous examinerons comment identifier les nœuds Assistant dans la collection de nœuds SmartArt et les modifier.

- Créez une instance de la classe PresentationEx et chargez la présentation contenant une forme SmartArt.
- Obtenez la référence de la deuxième diapositive en utilisant son indice.
- Parcourez chaque forme de la première diapositive.
- Vérifiez si la forme est de type SmartArt et casterez la forme sélectionnée en SmartArtEx si c’est le cas.
- Parcourez tous les nœuds de la forme SmartArt et vérifiez s’ils sont des nœuds Assistant.
- Modifiez le statut du nœud Assistant pour le rendre nœud normal.
- Enregistrez la présentation.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Créer une instance de présentation
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Parcourir chaque forme de la première diapositive
    for shape in pres.slides[0].shapes:
        # Vérifier si la forme est de type SmartArt
        if type(shape) is art.SmartArt:
            # Parcourir tous les nœuds de la forme SmartArt
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Vérifier si le nœud est un nœud Assistant
                if node.is_assistant:
                    # Définir le nœud Assistant à false et le transformer en nœud normal
                    node.is_assistant = False
    # Enregistrer la présentation
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir le format de remplissage du nœud**
Aspose.Slides for Python via .NET permet d’ajouter des formes SmartArt personnalisées et de définir leurs formats de remplissage. Cet article explique comment créer et accéder aux formes SmartArt et définir leur format de remplissage à l’aide d’Aspose.Slides for Python via .NET.

Veuillez suivre les étapes ci‑dessous :

- Créez une instance de la classe `Presentation`.
- Obtenez la référence d’une diapositive en utilisant son indice.
- Ajoutez une forme SmartArt en définissant son LayoutType.
- Définissez le FillFormat pour les nœuds de la forme SmartArt.
- Enregistrez la présentation modifiée au format PPTX.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # Accéder à la diapositive
    slide = presentation.slides[0]

    # Ajouter la forme SmartArt et les nœuds
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # Définir la couleur de remplissage du nœud
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Enregistrer la présentation
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Générer une miniature du nœud enfant SmartArt**
Les développeurs peuvent générer une miniature du nœud enfant d’un SmartArt en suivant les étapes ci‑dessous :

1. Instanciez la classe `Presentation` qui représente le fichier PPTX.
1. Ajoutez un SmartArt.
1. Obtenez la référence d’un nœud en utilisant son indice.
1. Récupérez l’image miniature.
1. Enregistrez l’image miniature dans le format d’image souhaité.

L’exemple ci‑dessous génère une miniature du nœud enfant SmartArt.
```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Instancier la classe Presentation qui représente le fichier PPTX
with slides.Presentation() as presentation: 
    # Ajouter SmartArt
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Obtenir la référence d'un nœud en utilisant son indice
    node = smart.nodes[1]

    # Obtenir la miniature
    with node.shapes[0].get_image() as bmp:
        # enregistrer la miniature
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```


## **FAQ**

**L’animation SmartArt est‑elle prise en charge ?**

Oui. SmartArt est traité comme une forme ordinaire, vous pouvez donc [appliquer des animations standard](/slides/fr/python-net/shape-animation/) (entrée, sortie, mise en emphase, trajectoires) et ajuster le minutage. Vous pouvez également animer les formes à l’intérieur des nœuds SmartArt si nécessaire.

**Comment localiser de manière fiable un SmartArt spécifique sur une diapositive si son ID interne est inconnu ?**

Attribuez et recherchez par [texte alternatif](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/). En définissant un AltText distinctif sur le SmartArt, vous pouvez le retrouver programmatiquement sans vous fier aux identifiants internes.

**L’apparence du SmartArt sera‑t‑elle conservée lors de la conversion de la présentation en PDF ?**

Oui. Aspose.Slides rend le SmartArt avec une grande fidélité visuelle lors de l’[export PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/), en conservant la mise en page, les couleurs et les effets.

**Puis‑je extraire une image de l’ensemble du SmartArt (pour des aperçus ou rapports) ?**

Oui. Vous pouvez rendre une forme SmartArt vers des [formats raster](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/get_image/) ou vers [SVG](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/write_as_svg/) pour une sortie vectorielle évolutive, ce qui convient aux miniatures, rapports ou utilisations web.