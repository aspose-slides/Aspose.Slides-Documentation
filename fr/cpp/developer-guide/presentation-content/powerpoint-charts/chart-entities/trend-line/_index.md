---
title: Ajouter des lignes de tendance aux graphiques de présentation en C++
linktitle: Ligne de tendance
type: docs
url: /fr/cpp/trend-line/
keywords:
- graphique
- ligne de tendance
- ligne de tendance exponentielle
- ligne de tendance linéaire
- ligne de tendance logarithmique
- ligne de tendance moyenne mobile
- ligne de tendance polynomiale
- ligne de tendance puissance
- ligne de tendance personnalisée
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Ajoutez rapidement et personnalisez les lignes de tendance dans les graphiques PowerPoint avec Aspose.Slides pour C++ — un guide pratique pour captiver votre audience."
---
## **Vue d'ensemble**

Cet article explique comment ajouter des lignes de tendance aux graphiques de présentation en utilisant Aspose.Slides. Il montre comment créer un graphique, ajouter des lignes de tendance aux séries du graphique et travailler avec plusieurs types de lignes de tendance, notamment exponentielle, linéaire, logarithmique, moyenne mobile, polynomiale et puissance.

Il décrit également comment ajouter une ligne personnalisée à un graphique en insérant une forme de ligne, et comprend une courte FAQ sur les valeurs de projection avant et arrière des lignes de tendance ainsi que sur la conservation des lignes de tendance lors de l'exportation en PDF ou SVG et lors du rendu des graphiques sous forme d'images.

## **Ajouter une ligne de tendance**
Aspose.Slides for C++ fournit une API simple pour gérer différentes lignes de tendance de graphique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Obtenez la référence d'une diapositive par son index.
3. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (cet exemple utilise ChartType.ClusteredColumn).
4. Ajout de la ligne de tendance exponentielle pour la série 1 du graphique.
5. Ajout d'une ligne de tendance linéaire pour la série 1 du graphique.
6. Ajout d'une ligne de tendance logarithmique pour la série 2 du graphique.
7. Ajout d'une ligne de tendance moyenne mobile pour la série 2 du graphique.
8. Ajout d'une ligne de tendance polynomiale pour la série 3 du graphique.
9. Ajout d'une ligne de tendance puissance pour la série 3 du graphique.
10. Enregistrez la présentation modifiée dans un fichier PPTX.

Le code suivant est utilisé pour créer un graphique avec des lignes de tendance.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Ajouter une ligne personnalisée**
Aspose.Slides for C++ fournit une API simple pour ajouter des lignes personnalisées dans un graphique. Pour ajouter une simple ligne droite à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci‑dessous :

- Créez une instance de la classe Presentation
- Obtenez la référence d'une diapositive en utilisant son Index
- Créez un nouveau graphique en utilisant la méthode AddChart exposée par l'objet Shapes
- Ajoutez une AutoShape de type Ligne en utilisant la méthode AddAutoShape exposée par l'objet Shapes
- Définissez la couleur des lignes de la forme.
- Enregistrez la présentation modifiée sous forme de fichier PPTX

Le code suivant est utilisé pour créer un graphique avec des lignes personnalisées.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**Que signifient 'forward' et 'backward' pour une ligne de tendance ?**

Ce sont les longueurs de la ligne de tendance projetées vers l'avant/vers l'arrière : pour les graphiques de dispersion (XY) – en unités d'axe ; pour les graphiques non‑dispersion – en nombre de catégories. Seules les valeurs non négatives sont autorisées.

**La ligne de tendance sera‑t‑elle conservée lors de l'exportation de la présentation en PDF ou SVG, ou lors du rendu d'une diapositive en image ?**

Oui. Aspose.Slides convertit les présentations en [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/fr/cpp/render-a-slide-as-an-svg-image/) et rend les graphiques en images ; les lignes de tendance, en tant que partie du graphique, sont conservées pendant ces opérations. Une méthode est également disponible pour [exporter une image du graphique](/slides/fr/cpp/create-shape-thumbnails/).