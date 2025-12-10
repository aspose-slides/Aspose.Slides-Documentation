---
title: Ajouter des rectangles aux présentations en C++
linktitle: Rectangle
type: docs
weight: 80
url: /fr/cpp/rectangle/
keywords:
- ajouter rectangle
- créer rectangle
- forme rectangle
- rectangle simple
- rectangle formaté
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Améliorez vos présentations PowerPoint en ajoutant des rectangles avec Aspose.Slides pour C++ — concevez et modifiez facilement des formes par programmation."
---

## **Créer un rectangle simple**
Comme les sujets précédents, celui-ci porte également sur l'ajout d'une forme et cette fois la forme que nous allons aborder est le rectangle. Dans ce sujet, nous avons expliqué comment les développeurs peuvent ajouter des rectangles simples ou formatés à leurs diapositives à l'aide d'Aspose.Slides pour C++ . Pour ajouter un rectangle simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci‑dessus :

1. Créer une instance de la [classe Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenir la référence d'une diapositive en utilisant son Index.
1. Ajouter un IAutoShape de type Rectangle en utilisant la méthode AddAutoShape exposée par l'objet IShapes.
1. Enregistrer la présentation modifiée sous forme de fichier PPTX.

Dans l'exemple ci‑dessous, nous avons ajouté un rectangle simple à la première diapositive de la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **Créer un rectangle formaté**
Pour ajouter un rectangle formaté à une diapositive, veuillez suivre les étapes ci‑dessus :

1. Créer une instance de la [classe Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenir la référence d'une diapositive en utilisant son Index.
1. Ajouter un IAutoShape de type Rectangle en utilisant la méthode AddAutoShape exposée par l'objet IShapes.
1. Définir le type de remplissage du rectangle sur Solide.
1. Définir la couleur du rectangle en utilisant la propriété SolidFillColor.Color exposée par l'objet FillFormat associé à l'objet IShape.
1. Définir la couleur des lignes du rectangle.
1. Définir la largeur des lignes du rectangle.
1. Enregistrer la présentation modifiée sous forme de fichier PPTX.
   Les étapes ci‑dessus sont implémentées dans l'exemple ci‑dessous.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **FAQ**

**Comment ajouter un rectangle avec des coins arrondis ?**

Utilisez le [type de forme] à coins arrondis (https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/) et ajustez le rayon des coins dans les propriétés de la forme ; l'arrondi peut également être appliqué à chaque coin via des ajustements géométriques.

**Comment remplir un rectangle avec une image (texture) ?**

Sélectionnez le [type de remplissage] d'image (https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), fournissez la source de l'image et configurez les [modes d'étirement/tiling](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/).

**Un rectangle peut‑il avoir une ombre et une lueur ?**

Oui. Les [ombres externes/intérieures, lueur et bords doux](/slides/fr/cpp/shape-effect/) sont disponibles avec des paramètres réglables.

**Puis‑je transformer un rectangle en bouton avec un hyperlien ?**

Oui. [Attribuez un hyperlien](/slides/fr/cpp/manage-hyperlinks/) au clic de la forme (aller à une diapositive, un fichier, une adresse web ou un e‑mail).

**Comment protéger un rectangle contre le déplacement et les modifications ?**

[Utilisez les verrous de forme](/slides/fr/cpp/applying-protection-to-presentation/) : vous pouvez interdire le déplacement, le redimensionnement, la sélection ou la modification du texte afin de préserver la mise en page.

**Puis‑je convertir un rectangle en image raster ou SVG ?**

Oui. Vous pouvez [rendre la forme](http://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) en une image avec une taille/échelle spécifiée ou [l'exporter au format SVG](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) pour une utilisation vectorielle.

**Comment obtenir rapidement les propriétés réelles (effectives) d'un rectangle en tenant compte du thème et de l'héritage ?**

[Utilisez les propriétés effectives de la forme](/slides/fr/cpp/shape-effective-properties/) : l'API renvoie les valeurs calculées qui tiennent compte des styles de thème, de la disposition et des paramètres locaux, simplifiant ainsi l'analyse du formatage.