---
title: Ligne de Tendance
type: docs
url: /fr/cpp/trend-line/
---

## **Ajouter une Ligne de Tendance**
Aspose.Slides pour C++ fournit une API simple pour gérer différentes lignes de tendance de graphique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (cet exemple utilise ChartType.ClusteredColumn).
1. Ajoutez la ligne de tendance exponentielle pour la série de graphique 1.
1. Ajoutez une ligne de tendance linéaire pour la série de graphique 1.
1. Ajoutez une ligne de tendance logarithmique pour la série de graphique 2.
1. Ajoutez une ligne de tendance moyenne mobile pour la série de graphique 2.
1. Ajoutez une ligne de tendance polynomiale pour la série de graphique 3.
1. Ajoutez une ligne de tendance de puissance pour la série de graphique 3.
1. Écrivez la présentation modifiée dans un fichier PPTX.

Le code suivant est utilisé pour créer un graphique avec des lignes de tendance.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Ajouter une Ligne Personnalisée**
Aspose.Slides pour C++ fournit une API simple pour ajouter des lignes personnalisées dans un graphique. Pour ajouter une ligne simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe Presentation
- Obtenez la référence d'une diapositive en utilisant son index
- Créez un nouveau graphique en utilisant la méthode AddChart exposée par l'objet Shapes
- Ajoutez une forme AutoShape de type ligne en utilisant la méthode AddAutoShape exposée par l'objet Shapes
- Définissez la couleur des lignes de la forme.
- Écrivez la présentation modifiée en tant que fichier PPTX

Le code suivant est utilisé pour créer un graphique avec des lignes personnalisées.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}