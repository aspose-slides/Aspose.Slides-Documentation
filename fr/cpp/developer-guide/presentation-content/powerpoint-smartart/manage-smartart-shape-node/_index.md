---
title: Gérer les nœuds de forme SmartArt dans les présentations en C++
linktitle: Nœud de forme SmartArt
type: docs
weight: 30
url: /fr/cpp/manage-smartart-shape-node/
keywords:
- nœud SmartArt
- nœud enfant
- ajouter un nœud
- position du nœud
- accéder au nœud
- supprimer le nœud
- position personnalisée
- nœud assistant
- format de remplissage
- rendu du nœud
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Gérez les nœuds de forme SmartArt dans PPT et PPTX avec Aspose.Slides pour C++. Obtenez des exemples de code clairs et des astuces pour optimiser vos présentations."
---

## **Ajouter un nœud SmartArt**
Aspose.Slides for C++ a fourni l'API la plus simple pour gérer les formes SmartArt de la manière la plus facile. Le code d'exemple suivant vous aidera à ajouter un nœud et un nœud enfant dans une forme SmartArt.

- Créez une instance de [Présentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) classe et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son Index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez (typecast) la forme sélectionnée en SmartArt si c'est le cas.
- Ajoutez un nouveau nœud dans la collection NodeCollection de la forme SmartArt et définissez le texte dans le TextFrame.
- Maintenant, ajoutez un nœud enfant dans le nœud SmartArt nouvellement ajouté et définissez le texte dans le TextFrame.
- Enregistrez la Présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **Ajouter un nœud SmartArt à une position spécifique**
Dans le code d'exemple suivant, nous avons expliqué comment ajouter les nœuds enfants appartenant aux nœuds respectifs d'une forme SmartArt à une position particulière.

- Créez une instance de la classe `Presentation`.
- Obtenez la référence de la première diapositive en utilisant son Index.
- Ajoutez une forme SmartArt de type StackedList dans la diapositive accédée.
- Accédez au premier nœud de la forme SmartArt ajoutée.
- Maintenant, ajoutez le nœud enfant pour le nœud sélectionné à la position 2 et définissez son texte.
- Enregistrez la Présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **Accéder à un nœud SmartArt**
Le code d'exemple suivant vous aidera à accéder aux nœuds dans une forme SmartArt. Veuillez noter que vous ne pouvez pas modifier le LayoutType du SmartArt car il est en lecture seule et n'est défini que lors de l'ajout de la forme SmartArt.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son Index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez (typecast) la forme sélectionnée en SmartArt si c'est le cas.
- Parcourez tous les nœuds à l'intérieur de la forme SmartArt.
- Accédez et affichez des informations telles que la position du nœud SmartArt, son niveau et le texte.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **Accéder à un nœud enfant SmartArt**
Le code d'exemple suivant vous aidera à accéder aux nœuds enfants appartenant aux nœuds respectifs d'une forme SmartArt.

- Créez une instance de la classe PresentationEx et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son Index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez (typecast) la forme sélectionnée en SmartArtEx si c'est le cas.
- Parcourez tous les nœuds à l'intérieur de la forme SmartArt.
- Pour chaque nœud de forme SmartArt sélectionné, parcourez tous les nœuds enfants à l'intérieur du nœud particulier.
- Accédez et affichez des informations telles que la position du nœud enfant, son niveau et le texte.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **Accéder à un nœud enfant SmartArt à une position spécifique**
Dans cet exemple, nous apprendrons à accéder aux nœuds enfants à une position particulière appartenant aux nœuds respectifs d'une forme SmartArt.

- Créez une instance de la classe `Presentation`.
- Obtenez la référence de la première diapositive en utilisant son Index.
- Ajoutez une forme SmartArt de type StackedList.
- Accédez à la forme SmartArt ajoutée.
- Accédez au nœud à l'index 0 pour la forme SmartArt accédée.
- Maintenant, accédez au nœud enfant à la position 1 pour le nœud SmartArt accédé en utilisant la méthode GetNodeByPosition().
- Accédez et affichez des informations telles que la position du nœud enfant, son niveau et le texte.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **Supprimer un nœud SmartArt**
Dans cet exemple, nous apprendrons à supprimer les nœuds à l'intérieur d'une forme SmartArt.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son Index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez (typecast) la forme sélectionnée en SmartArt si c'est le cas.
- Vérifiez si le SmartArt possède plus de 0 nœud.
- Sélectionnez le nœud SmartArt à supprimer.
- Maintenant, supprimez le nœud sélectionné en utilisant la méthode RemoveNode() et enregistrez la Présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **Supprimer un nœud SmartArt à une position spécifique**
Dans cet exemple, nous apprendrons à supprimer les nœuds d'une forme SmartArt à une position particulière.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son Index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez (typecast) la forme sélectionnée en SmartArt si c'est le cas.
- Sélectionnez le nœud de forme SmartArt à l'index 0.
- Maintenant, vérifiez si le nœud SmartArt sélectionné possède plus de 2 nœuds enfants.
- Maintenant, supprimez le nœud à la Position 1 en utilisant la méthode RemoveNodeByPosition().
- Enregistrez la Présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **Définir une position personnalisée pour un nœud enfant SmartArt**
Aspose.Slides prend désormais en charge la définition des propriétés X et Y de SmartArtShape. Le extrait de code ci-dessous montre comment définir une position, une taille et une rotation personnalisées pour SmartArtShape ; veuillez également noter que l'ajout de nouveaux nœuds entraîne un recalcul des positions et des tailles de tous les nœuds.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **Vérifier un nœud Assistant**
Dans le code d'exemple suivant, nous étudierons comment identifier les nœuds Assistant dans la collection de nœuds SmartArt et les modifier.

- Créez une instance de la classe PresentationEx et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la deuxième diapositive en utilisant son Index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez (typecast) la forme sélectionnée en SmartArtEx si c'est le cas.
- Parcourez tous les nœuds de la forme SmartArt.
- Changez le statut du nœud Assistant en nœud normal.
- Enregistrez la Présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **Définir le format de remplissage d'un nœud**
Aspose.Slides pour C++ permet d'ajouter des formes SmartArt personnalisées et de définir leurs formats de remplissage. Cet article explique comment créer et accéder aux formes SmartArt et définir leur format de remplissage en utilisant Aspose.Slides pour C++.

- Créez une instance de la classe `Presentation`.
- Obtenez la référence d’une diapositive en utilisant son index.
- Ajoutez une forme SmartArt en définissant son LayoutType.
- Définissez le FillFormat pour les nœuds de la forme SmartArt.
- Enregistrez la présentation modifiée en tant que fichier PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **Générer une miniature d'un nœud enfant SmartArt**
Les développeurs peuvent générer une miniature d'un nœud enfant d'un SmartArt en suivant les étapes ci-dessous :

1. Instanciez la classe `Presentation` qui représente le fichier PPTX.
2. Ajoutez SmartArt.
3. Obtenez la référence d’un nœud en utilisant son Index
4. Obtenez l'image miniature.
5. Enregistrez l'image miniature dans le format d'image souhaité.

L'exemple ci-dessous génère une miniature d'un nœud enfant SmartArt
```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **FAQ**

**L'animation SmartArt est-elle prise en charge ?**

Oui. SmartArt est traité comme une forme ordinaire, vous pouvez donc [appliquer des animations standard](/slides/fr/cpp/shape-animation/) (entrée, sortie, mise en évidence, trajectoires de mouvement) et ajuster le timing. Vous pouvez également animer les formes à l'intérieur des nœuds SmartArt si nécessaire.

**Comment puis-je localiser de manière fiable un SmartArt spécifique sur une diapositive si son identifiant interne est inconnu ?**

Attribuez et recherchez par [texte alternatif](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/). Définir un AltText distinctif sur le SmartArt vous permet de le trouver programmatique sans dépendre des identifiants internes.

**L'apparence du SmartArt sera-t-elle conservée lors de la conversion de la présentation en PDF ?**

Oui. Aspose.Slides rend le SmartArt avec une haute fidélité visuelle lors de l'[export PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/), préservant la disposition, les couleurs et les effets.

**Puis-je extraire une image de l'ensemble du SmartArt (pour des aperçus ou des rapports) ?**

Oui. Vous pouvez rendre une forme SmartArt en [formats raster](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) ou en [SVG](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) pour une sortie vectorielle évolutive, ce qui la rend adaptée aux miniatures, aux rapports ou à une utilisation web.