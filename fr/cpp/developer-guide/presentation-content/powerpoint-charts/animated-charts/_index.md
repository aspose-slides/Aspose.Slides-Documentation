---
title: Animer les graphiques PowerPoint en C++
linktitle: Graphiques animés
type: docs
weight: 80
url: /fr/cpp/animated-charts/
keywords:
- graphique
- graphique animé
- animation de graphique
- série de graphique
- catégorie de graphique
- élément de série
- élément de catégorie
- ajouter un effet
- type d'effet
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Créez des graphiques animés époustouflants en C++ avec Aspose.Slides. Dynamisez vos présentations avec des visuels dynamiques dans les fichiers PPT et PPTX — commencez dès maintenant."
---

## **Animation de séries de graphiques**
Si vous souhaitez animer une série de graphique, écrivez le code selon les étapes indiquées ci-dessous :

1. Charger une présentation.
1. Obtenir la référence de l’objet du graphique.
1. Animer la série.
1. Enregistrer le fichier de présentation sur le disque.

Dans l'exemple ci-dessous, nous avons animé des séries de graphiques.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animation d'un élément de série**
Si vous souhaitez animer des éléments de série, écrivez le code selon les étapes indiquées ci-dessous :

1. Charger une présentation.
1. Obtenir la référence de l’objet du graphique.
1. Animer les éléments de la série.
1. Enregistrer le fichier de présentation sur le disque.

Dans l'exemple ci-dessous, nous avons animé les éléments de la série.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeriesElements-AnimatingSeriesElements.cpp" >}}

## **Animation de la catégorie de graphique**
Si vous souhaitez animer une catégorie de graphique, écrivez le code selon les étapes indiquées ci-dessous :

1. Charger une présentation.
1. Obtenir la référence de l’objet du graphique.
1. Animer la catégorie.
1. Enregistrer le fichier de présentation sur le disque.

Dans l'exemple ci-dessous, nous avons animé la catégorie du graphique.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animation d'un élément de catégorie**
Si vous souhaitez animer des éléments de catégories, écrivez le code selon les étapes indiquées ci-dessous :

1. Charger une présentation.
1. Obtenir la référence de l’objet du graphique.
1. Animer les éléments de catégories.
1. Enregistrer le fichier de présentation sur le disque.

Dans l'exemple ci-dessous, nous avons animé les éléments de catégories.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingCategoriesElements-AnimatingCategoriesElements.cpp" >}}

## **FAQ**

**Différents types d'effets (par ex., entrée, mise en valeur, sortie) sont-ils pris en charge pour les graphiques comme pour les formes normales ?**

Oui. Un graphique est considéré comme une forme, il prend donc en charge les types d'effets d'animation standards, y compris entrée, mise en valeur et sortie, avec un contrôle complet via la chronologie de la diapositive et les séquences d'animation.

**Puis-je combiner l'animation de graphique avec les transitions de diapositive ?**

Oui. [Transitions](/slides/fr/cpp/slide-transition/) s'appliquent à la diapositive, tandis que les effets d'animation s'appliquent aux objets de la diapositive. Vous pouvez les utiliser tous les deux dans la même présentation et les contrôler indépendamment.

**Les animations de graphiques sont-elles conservées lors de l'enregistrement au format PPTX ?**

Oui. Lorsque vous [enregistrez au format PPTX](/slides/fr/cpp/save-presentation/), tous les effets d'animation et leur ordre sont conservés car ils font partie du modèle d'animation natif de la présentation.

**Puis-je lire les animations de graphiques existantes d’une présentation et les modifier ?**

Oui. L'[API](https://reference.aspose.com/slides/cpp/aspose.slides.animation/) donne accès à la chronologie des diapositives, aux séquences et aux effets, vous permettant d'examiner les animations de graphiques existantes et de les ajuster sans tout recréer à partir de zéro.

**Puis-je créer une vidéo incluant les animations de graphiques avec Aspose.Slides ?**

Oui. Vous pouvez [exporter une présentation en vidéo](/slides/fr/cpp/convert-powerpoint-to-video/) tout en conservant les animations, en configurant les durées et les autres paramètres d'exportation afin que le clip résultant reflète la lecture animée.