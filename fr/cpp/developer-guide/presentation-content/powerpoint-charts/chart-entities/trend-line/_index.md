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
- ligne de tendance de puissance
- ligne de tendance personnalisée
- PowerPoint
- présentation
- С++
- Aspose.Slides
description: "Ajoutez et personnalisez rapidement des lignes de tendance dans les graphiques PowerPoint avec Aspose.Slides pour C++ — un guide pratique pour captiver votre audience."
---

## **Ajouter une ligne de tendance**
Aspose.Slides for C++ fournit une API simple pour gérer différentes lignes de tendance de graphique :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenir la référence d'une diapositive par son index.
1. Ajouter un graphique avec des données par défaut ainsi que le type souhaité (cet exemple utilise ChartType.ClusteredColumn).
1. Ajouter la ligne de tendance exponentielle pour la série 1 du graphique.
1. Ajouter une ligne de tendance linéaire pour la série 1 du graphique.
1. Ajouter une ligne de tendance logarithmique pour la série 2 du graphique.
1. Ajouter une ligne de tendance moyenne mobile pour la série 2 du graphique.
1. Ajouter une ligne de tendance polynomiale pour la série 3 du graphique.
1. Ajouter une ligne de tendance de puissance pour la série 3 du graphique.
1. Enregistrer la présentation modifiée dans un fichier PPTX.

Le code suivant est utilisé pour créer un graphique avec des lignes de tendance.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Ajouter une ligne personnalisée**
Aspose.Slides for C++ fournit une API simple pour ajouter des lignes personnalisées dans un graphique. Pour ajouter une simple ligne droite à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci‑dessous :

- Créer une instance de la classe Presentation.
- Obtenir la référence d'une diapositive en utilisant son Index.
- Créer un nouveau graphique en utilisant la méthode AddChart exposée par l'objet Shapes.
- Ajouter une AutoShape de type Ligne en utilisant la méthode AddAutoShape exposée par l'objet Shapes.
- Définir la couleur des lignes de la forme.
- Enregistrer la présentation modifiée sous forme de fichier PPTX.

Le code suivant est utilisé pour créer un graphique avec des lignes personnalisées.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**Que signifient 'forward' et 'backward' pour une ligne de tendance ?**

Ce sont les longueurs de la ligne de tendance projetées en avant/en arrière : pour les graphiques de dispersion (XY) – en unités d’axe ; pour les graphiques non‑dispersion – en nombre de catégories. seules les valeurs non négatives sont autorisées.

**La ligne de tendance sera‑t‑elle conservée lors de l’exportation de la présentation au format PDF ou SVG, ou lors du rendu d’une diapositive en image ?**

Oui. Aspose.Slides convertit les présentations en [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/fr/cpp/render-a-slide-as-an-svg-image/) et rend les graphiques en images ; les lignes de tendance, en tant que partie du graphique, sont conservées pendant ces opérations. Une méthode est également disponible pour [exporter une image du graphique](/slides/fr/cpp/create-shape-thumbnails/) elle‑même.