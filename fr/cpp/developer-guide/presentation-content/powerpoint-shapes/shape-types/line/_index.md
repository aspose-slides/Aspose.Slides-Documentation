---
title: Ajouter des formes de ligne aux présentations en C++
linktitle: Ligne
type: docs
weight: 50
url: /fr/cpp/line/
keywords:
- ligne
- créer une ligne
- ajouter une ligne
- ligne simple
- configurer une ligne
- personnaliser une ligne
- style de tiret
- tête de flèche
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à manipuler le formatage des lignes dans les présentations PowerPoint avec Aspose.Slides pour C++. Découvrez les propriétés, méthodes et exemples."
---

## **Créer une ligne simple**
Pour ajouter une ligne simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la [classe Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- Obtenez la référence d’une diapositive en utilisant son index.
- Ajoutez une AutoShape de type Ligne en utilisant la méthode [AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) exposée par l’objet Shapes.
- Enregistrez la présentation modifiée sous forme de fichier PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté une ligne à la première diapositive de la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **Créer une ligne en forme de flèche**
Aspose.Slides for C++ permet également aux développeurs de configurer certaines propriétés de la ligne afin de la rendre plus attrayante. Essayons de configurer quelques propriétés d’une ligne pour qu’elle ressemble à une flèche. Veuillez suivre les étapes ci‑dessous pour ce faire :

- Créez une instance de la [classe Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- Obtenez la référence d’une diapositive en utilisant son index.
- Ajoutez une AutoShape de type Ligne en utilisant la méthode AddAutoShape exposée par l’objet Shapes.
- Définissez le style de ligne sur l’un des styles proposés par Aspose.Slides for C++.
- Définissez la largeur de la ligne.
- Définissez le [Dash Style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) de la ligne sur l’un des styles proposés par Aspose.Slides for C++.
- Définissez le [Arrow Head Style](https://reference.aspose.com/slides/cpp/aspose.slides/lineformat/) et la longueur du point de départ de la ligne.
- Définissez le style et la longueur du point d’arrivée de la ligne.
- Enregistrez la présentation modifiée sous forme de fichier PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **FAQ**

**Puis-je convertir une ligne ordinaire en connecteur afin qu’elle « s’enclenche » aux formes ?**

Non. Une ligne ordinaire (une [AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/) de type [Line](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/)) ne devient pas automatiquement un connecteur. Pour qu’elle s’enclenche aux formes, utilisez le type dédié [Connector](https://reference.aspose.com/slides/cpp/aspose.slides/connector/) ainsi que les [APIs correspondantes](/slides/fr/cpp/connector/) pour les connexions.

**Que faire si les propriétés d’une ligne sont héritées du thème et qu’il est difficile de déterminer les valeurs finales ?**

Consultez les [propriétés effectives](/slides/fr/cpp/shape-effective-properties/) via les interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformateffectivedata/) — celles‑ci tiennent déjà compte de l’héritage et des styles du thème.

**Puis‑je verrouiller une ligne contre la modification (déplacement, redimensionnement) ?**

Oui. Les formes offrent des [objets de verrouillage](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/get_autoshapelock/) qui vous permettent de [interdire les opérations de modification](/slides/fr/cpp/applying-protection-to-presentation/).