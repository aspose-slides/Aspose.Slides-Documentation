---
title: Ajouter des ellipses aux présentations en C++
linktitle: Ellipse
type: docs
weight: 30
url: /fr/cpp/ellipse/
keywords:
- ellipse
- forme
- ajouter ellipse
- créer ellipse
- dessiner ellipse
- ellipse formatée
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à créer, formater et manipuler des formes d'ellipse dans Aspose.Slides pour C++ sur des présentations PPT et PPTX — exemples de code C++ inclus."
---

## **Créer une ellipse**
Dans ce sujet, nous présenterons aux développeurs comment ajouter des formes d'ellipse à leurs diapositives à l'aide d'Aspose.Slides for C++. Aspose.Slides for C++ fournit un ensemble d'API plus simples pour dessiner différents types de formes en quelques lignes de code seulement. Pour ajouter une ellipse simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

1. Créer une instance de [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)
2. Obtenir la référence d'une diapositive en utilisant son Index
3. Ajouter un AutoShape de type Ellipse en utilisant la méthode AddAutoShape exposée par l'objet IShapes
4. Enregistrer la présentation modifiée au format PPTX

Dans l'exemple ci-dessous, nous avons ajouté une ellipse à la première diapositive.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}

## **Créer une ellipse formatée**
Pour ajouter une ellipse mieux formatée à une diapositive, veuillez suivre les étapes ci-dessous :

1. Créer une instance de [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenir la référence d'une diapositive en utilisant son Index.
3. Ajouter un AutoShape de type Ellipse en utilisant la méthode AddAutoShape exposée par l'objet IShapes.
4. Définir le type de remplissage de l'ellipse sur Solid.
5. Définir la couleur de l'ellipse en utilisant la propriété SolidFillColor.Color exposée par l'objet FillFormat associé à l'objet IShape.
6. Définir la couleur des lignes de l'ellipse.
7. Définir la largeur des lignes de l'ellipse.
8. Enregistrer la présentation modifiée au format PPTX.

Dans l'exemple ci-dessous, nous avons ajouté une ellipse formatée à la première diapositive de la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}

## **FAQ**

**Comment définir la position exacte et la taille d'une ellipse par rapport aux unités de la diapositive ?**

Les coordonnées et les tailles sont généralement spécifiées **en points**. Pour des résultats prévisibles, basez vos calculs sur la taille de la diapositive et convertissez les millimètres ou pouces requis en points avant d'attribuer les valeurs.

**Comment placer une ellipse au-dessus ou en dessous d'autres objets (contrôler l'ordre d'empilement) ?**

Ajustez l'ordre de dessin de l'objet en le portant à l'avant ou en l'envoyant à l'arrière. Cela permet à l'ellipse de chevaucher d'autres objets ou de révéler ceux qui se trouvent en dessous.

**Comment animer l'apparition ou l'emphase d'une ellipse ?**

Appliquer des effets d'entrée, d'emphase ou de sortie à la forme en utilisant [Apply](/slides/fr/cpp/shape-animation/), et configurer les déclencheurs et le timing pour orchestrer quand et comment l'animation se joue.