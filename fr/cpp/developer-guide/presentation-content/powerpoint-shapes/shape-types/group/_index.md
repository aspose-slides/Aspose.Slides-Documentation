---
title: Formes de groupe de présentation en C++
linktitle: Groupe de formes
type: docs
weight: 40
url: /fr/cpp/group/
keywords:
- forme groupée
- groupe de formes
- ajouter un groupe
- texte alternatif
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à grouper et dégrouper des formes dans les présentations PowerPoint avec Aspose.Slides pour C++ — guide rapide, étape par étape, avec du code C++ gratuit."
---

## **Ajouter une forme groupée**
Aspose.Slides prend en charge le travail avec les formes groupées sur les diapositives. Cette fonctionnalité aide les développeurs à créer des présentations plus riches. Aspose.Slides for C++ prend en charge l’ajout ou l’accès aux formes groupées. Il est possible d’ajouter des formes à une forme groupée ajoutée pour la remplir ou d’accéder à toute propriété de la forme groupée. Pour ajouter une forme groupée à une diapositive avec Aspose.Slides for C++ :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. Obtenez la référence d’une diapositive en utilisant son Index
1. Ajoutez une forme groupée à la diapositive.
1. Ajoutez les formes à la forme groupée ajoutée.
1. Enregistrez la présentation modifiée en tant que fichier PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **Accéder à la propriété AltText**
Ce sujet présente des étapes simples, avec des exemples de code, pour ajouter une forme groupée et accéder à la propriété AltText des formes groupées sur les diapositives. Pour accéder à l'AltText d'une forme groupée dans une diapositive avec Aspose.Slides for C++ :

1. Instanciez la classe `Presentation` qui représente un fichier PPTX.
1. Obtenez la référence d’une diapositive en utilisant son Index.
1. Accédez à la collection de formes des diapositives.
1. Accédez à la forme groupée.
1. Accédez à la propriété AltText.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **FAQ**

**Le groupement imbriqué (un groupe à l'intérieur d'un autre groupe) est-il pris en charge ?**

Oui. [GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/) possède une méthode [get_ParentGroup](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_parentgroup/) qui indique directement la prise en charge de la hiérarchie (un groupe peut être un enfant d'un autre groupe).

**Comment contrôler l'ordre Z d'un groupe par rapport aux autres objets de la diapositive ?**

Utilisez la [Z-Order position](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_zorderposition/) du [GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/) pour inspecter sa position dans la pile d'affichage.

**Puis-je empêcher le déplacement/la modification/le dégroupage ?**

Oui. La section de verrouillage du groupe est exposée via [get_GroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/get_groupshapelock/) , ce qui vous permet de restreindre les opérations sur l'objet.