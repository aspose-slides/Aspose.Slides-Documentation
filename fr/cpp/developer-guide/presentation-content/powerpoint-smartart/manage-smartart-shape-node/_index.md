---
title: Gérer le nœud de forme SmartArt
type: docs
weight: 30
url: /cpp/manage-smartart-shape-node/
keywords:
- SmartArt
- nœud SmartArt
- nœud enfant SmartArt
- PowerPoint
- présentation
- C++
- Aspose.Slides pour C++
description: "Gérer les nœuds SmartArt et les nœuds enfants dans les présentations PowerPoint en C++"
---



## **Ajouter un nœud SmartArt**
Aspose.Slides pour C++ a fourni l'API la plus simple pour gérer les formes SmartArt de la manière la plus facile. Le code d'exemple suivant aidera à ajouter un nœud et un nœud enfant à l'intérieur de la forme SmartArt.

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son Index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez la forme sélectionnée en SmartArt si c'est un SmartArt.
- Ajoutez un nouveau nœud dans la collection de nœuds de la forme SmartArt et définissez le texte dans le TextFrame.
- Maintenant, ajoutez un nœud enfant au nouveau nœud SmartArt nouvellement ajouté et définissez le texte dans le TextFrame.
- Enregistrez la Présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **Ajouter un nœud SmartArt à une position spécifique**
Dans le code d'exemple suivant, nous avons expliqué comment ajouter les nœuds enfants appartenant aux nœuds respectifs de la forme SmartArt à une position particulière.

- Créez une instance de la classe `Presentation`.
- Obtenez la référence de la première diapositive en utilisant son Index.
- Ajoutez une forme SmartArt de type StackedList dans la diapositive accessible.
- Accédez au premier nœud dans la forme SmartArt ajoutée.
- Maintenant, ajoutez le nœud enfant pour le nœud sélectionné à la position 2 et définissez son texte.
- Enregistrez la Présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}


## **Accéder au nœud SmartArt**
Le code d'exemple suivant aidera à accéder aux nœuds à l'intérieur de la forme SmartArt. Veuillez noter que vous ne pouvez pas changer le LayoutType du SmartArt car il est en lecture seule et est défini uniquement lorsque la forme SmartArt est ajoutée.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son Index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez la forme sélectionnée en SmartArt si c'est un SmartArt.
- Parcourez tous les nœuds à l'intérieur de la forme SmartArt.
- Accédez et affichez des informations comme la position du nœud SmartArt, le niveau et le texte.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **Accéder au nœud enfant SmartArt**
Le code d'exemple suivant aidera à accéder aux nœuds enfants appartenant aux nœuds respectifs de la forme SmartArt.

- Créez une instance de la classe PresentationEx et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son Index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez la forme sélectionnée en SmartArtEx si c'est un SmartArt.
- Parcourez tous les nœuds à l'intérieur de la forme SmartArt.
- Pour chaque nœud SmartArt sélectionné, parcourez tous les nœuds enfants à l'intérieur du nœud particulier.
- Accédez et affichez des informations comme la position du nœud enfant, le niveau et le texte.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **Accéder au nœud enfant SmartArt à une position spécifique**
Dans cet exemple, nous allons apprendre à accéder aux nœuds enfants à une position particulière appartenant aux nœuds respectifs de la forme SmartArt.

- Créez une instance de la classe `Presentation`.
- Obtenez la référence de la première diapositive en utilisant son Index.
- Ajoutez une forme SmartArt de type StackedList.
- Accédez à la forme SmartArt ajoutée.
- Accédez au nœud à l'index 0 pour la forme SmartArt accessible.
- Maintenant, accédez au nœud enfant à la position 1 pour le nœud SmartArt accessible en utilisant la méthode GetNodeByPosition().
- Accédez et affichez des informations comme la position du nœud enfant, le niveau et le texte.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **Supprimer un nœud SmartArt**
Dans cet exemple, nous allons apprendre à supprimer les nœuds à l'intérieur de la forme SmartArt.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son Index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez la forme sélectionnée en SmartArt si c'est un SmartArt.
- Vérifiez si le SmartArt a plus de 0 nœuds.
- Sélectionnez le nœud SmartArt à supprimer.
- Maintenant, supprimez le nœud sélectionné en utilisant la méthode RemoveNode() * Enregistrez la Présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **Supprimer un nœud SmartArt à une position spécifique**
Dans cet exemple, nous allons apprendre à supprimer les nœuds à l'intérieur de la forme SmartArt à une position particulière.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son Index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez la forme sélectionnée en SmartArt si c'est un SmartArt.
- Sélectionnez le nœud de forme SmartArt à l'index 0.
- Maintenant, vérifiez si le nœud SmartArt sélectionné a plus de 2 nœuds enfants.
- Maintenant, supprimez le nœud à la position 1 en utilisant la méthode RemoveNodeByPosition().
- Enregistrez la Présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}


## **Définir une position personnalisée pour le nœud enfant SmartArt**
Maintenant, Aspose.Slides pour .NET prend en charge la définition des propriétés X et Y de SmartArtShape. Le snippet de code ci-dessous montre comment définir la position, la taille et la rotation de SmartArtShape personnalisées. Veuillez également noter que l'ajout de nouveaux nœuds entraîne un recalcul des positions et des tailles de tous les nœuds.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}


## **Vérifier le nœud assistant**
Dans le code d'exemple suivant, nous allons enquêter sur la façon d'identifier les nœuds assistants dans la collection de nœuds SmartArt et de les modifier.

- Créez une instance de la classe PresentationEx et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la deuxième diapositive en utilisant son Index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez la forme sélectionnée en SmartArtEx si c'est un SmartArt.
- Parcourez tous les nœuds à l'intérieur de la forme SmartArt et vérifiez s'ils sont des nœuds assistants.
- Changez le statut du nœud assistant en nœud normal.
- Enregistrez la Présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **Définir le format de remplissage du nœud**
Aspose.Slides pour C++ permet d'ajouter des formes SmartArt personnalisées et de définir leurs formats de remplissage. Cet article explique comment créer et accéder aux formes SmartArt et définir leur format de remplissage en utilisant Aspose.Slides pour C++.

Veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe `Presentation`.
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez une forme SmartArt en définissant son LayoutType.
- Définissez le FillFormat pour les nœuds de la forme SmartArt.
- Écrivez la présentation modifiée sous forme de fichier PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}


## **Générer une miniature du nœud enfant SmartArt**
Les développeurs peuvent générer une miniature d'un nœud enfant d'un SmartArt en suivant les étapes ci-dessous :

1. Instancier la classe `Presentation` qui représente le fichier PPTX.
1. Ajouter SmartArt.
1. Obtenez la référence d'un nœud en utilisant son Index.
1. Obtenez l'image de miniature.
1. Enregistrez l'image de miniature dans le format d'image souhaité.

L'exemple ci-dessous génère une miniature du nœud enfant SmartArt.

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