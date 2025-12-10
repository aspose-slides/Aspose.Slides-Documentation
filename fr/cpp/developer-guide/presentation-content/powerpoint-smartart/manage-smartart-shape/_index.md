---
title: Gérer les graphiques SmartArt dans les présentations avec C++
linktitle: Graphiques SmartArt
type: docs
weight: 20
url: /fr/cpp/manage-smartart-shape/
keywords:
- objet SmartArt
- graphique SmartArt
- style SmartArt
- couleur SmartArt
- créer SmartArt
- ajouter SmartArt
- modifier SmartArt
- changer SmartArt
- accéder à SmartArt
- type de mise en page SmartArt
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Automatisez la création, la modification et le style des SmartArt PowerPoint en C++ avec Aspose.Slides, en proposant des exemples de code concis et des conseils axés sur les performances."
---

## **Créer une forme SmartArt**
Aspose.Slides for C++ permet désormais d’ajouter des formes SmartArt personnalisées dans leurs diapositives à partir de zéro. Aspose.Slides for C++ fournit l’API la plus simple pour créer des formes SmartArt de la manière la plus facile. Pour créer une forme SmartArt dans une diapositive, suivez les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenir la référence d’une diapositive en utilisant son index.
- Ajouter une forme SmartArt en définissant son LayoutType.
- Enregistrer la présentation modifiée au format PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}

## **Accéder à une forme SmartArt sur une diapositive**
Le code suivant permet d’accéder aux formes SmartArt ajoutées dans la diapositive de la présentation. Dans l’exemple, nous parcourons chaque forme de la diapositive et vérifions si elle est de type SmartArt. Si c’est le cas, nous la convertissons en instance SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **Accéder à une forme SmartArt avec un type de disposition particulier**
Le code d’exemple suivant permet d’accéder à la forme SmartArt avec un LayoutType particulier. Notez que le LayoutType du SmartArt ne peut pas être modifié car il est en lecture seule et ne peut être défini que lors de l’ajout de la forme SmartArt.

- Créer une instance de la classe `Presentation` et charger la présentation contenant la forme SmartArt.
- Obtenir la référence de la première diapositive en utilisant son index.
- Parcourir chaque forme de la première diapositive.
- Vérifier si la forme est de type SmartArt et la convertir en SmartArt si c’est le cas.
- Vérifier la forme SmartArt avec le LayoutType souhaité et exécuter les actions nécessaires.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}

## **Modifier le style d’une forme SmartArt**
Le code d’exemple suivant permet d’accéder à la forme SmartArt avec un LayoutType particulier.

- Créer une instance de la classe `Presentation` et charger la présentation contenant la forme SmartArt.
- Obtenir la référence de la première diapositive en utilisant son index.
- Parcourir chaque forme de la première diapositive.
- Vérifier si la forme est de type SmartArt et la convertir en SmartArt si c’est le cas.
- Trouver la forme SmartArt avec le style souhaité.
- Définir le nouveau style pour la forme SmartArt.
- Enregistrer la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}

## **Modifier le style de couleur d’une forme SmartArt**
Dans cet exemple, nous apprendrons à modifier le style de couleur d’une forme SmartArt. Le code d’exemple suivant accède à la forme SmartArt avec un style de couleur particulier et en modifie le style.

- Créer une instance de la classe `Presentation` et charger la présentation contenant la forme SmartArt.
- Obtenir la référence de la première diapositive en utilisant son index.
- Parcourir chaque forme de la première diapositive.
- Vérifier si la forme est de type SmartArt et la convertir en SmartArt si c’est le cas.
- Trouver la forme SmartArt avec le style de couleur souhaité.
- Définir le nouveau style de couleur pour la forme SmartArt.
- Enregistrer la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **FAQ**

**Puis‑je animer un SmartArt en tant qu’objet unique ?**

Oui. SmartArt est une forme, vous pouvez donc appliquer les [animations standard](/slides/fr/cpp/powerpoint-animation/) via l’API d’animations (entrée, sortie, mise en valeur, trajectoires) comme pour les autres formes.

**Comment trouver un SmartArt spécifique sur une diapositive si je ne connais pas son ID interne ?**

Définissez et utilisez le texte alternatif (AltText) et recherchez la forme par cette valeur — c’est la méthode recommandée pour localiser la forme cible.

**Puis‑je regrouper un SmartArt avec d’autres formes ?**

Oui. Vous pouvez regrouper SmartArt avec d’autres formes (images, tableaux, etc.) puis [manipuler le groupe](/slides/fr/cpp/group/).

**Comment obtenir une image d’un SmartArt spécifique (par exemple pour un aperçu ou un rapport) ?**

Exportez une vignette/image de la forme ; la bibliothèque peut [rendre des formes individuelles](/slides/fr/cpp/create-shape-thumbnails/) en fichiers raster (PNG/JPG/TIFF).

**L’apparence du SmartArt sera‑t‑elle conservée lors de la conversion de toute la présentation en PDF ?**

Oui. Le moteur de rendu vise une haute fidélité pour l’[export PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/), avec diverses options de qualité et de compatibilité.