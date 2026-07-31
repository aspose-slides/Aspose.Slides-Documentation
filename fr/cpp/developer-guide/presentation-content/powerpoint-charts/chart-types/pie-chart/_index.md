---
title: Personnaliser les graphiques circulaires dans les présentations avec C++
linktitle: Graphique circulaire
type: docs
url: /fr/cpp/pie-chart/
keywords:
- graphique circulaire
- gérer le graphique
- personnaliser le graphique
- options du graphique
- paramètres du graphique
- options de tracé
- couleur de tranche
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à créer et personnaliser des graphiques circulaires en C++ avec Aspose.Slides, exportables vers PowerPoint, boostant votre narration de données en quelques secondes."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les graphiques circulaires dans Aspose.Slides. Il montre comment configurer les options de tracé secondaire pour les graphiques « Pie of Pie » et « Bar of Pie », et comment activer la coloration automatique des tranches pour un graphique circulaire standard.

Les exemples se concentrent sur des étapes pratiques de personnalisation des graphiques, comme l'ajout d'un graphique à une diapositive, l'ajustement des paramètres de séries et d'étiquettes, le remplacement des données de graphique par défaut par des catégories et des valeurs personnalisées, et l'enregistrement de la présentation mise à jour.

## **Options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie**

Aspose.Slides pour C++ prend désormais en charge les options de tracé secondaire pour les graphiques Pie of Pie ou Bar of Pie. Dans ce sujet, nous verrons avec un exemple comment spécifier ces options à l'aide d'Aspose.Slides. Pour spécifier les propriétés, veuillez suivre les étapes ci-dessous :

1. Instancier l'objet de classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
2. Ajouter un graphique sur la diapositive.
3. Spécifier les options de tracé secondaire du graphique.
4. Enregistrer la présentation sur le disque.

Dans l'exemple ci-dessous, nous avons défini différentes propriétés du graphique Pie of Pie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **Définir les couleurs automatiques des tranches du graphique circulaire**

Aspose.Slides pour C++ fournit une API simple pour définir les couleurs automatiques des tranches d'un graphique circulaire. Le code d'exemple applique les paramètres mentionnés ci-dessus.

1. Créer une instance de la classe Presentation.
2. Accéder à la première diapositive.
3. Ajouter un graphique avec les données par défaut.
4. Définir le titre du graphique.
5. Configurer la première série pour afficher les valeurs.
6. Définir l'index de la feuille de données du graphique.
7. Obtenir la feuille de calcul des données du graphique.
8. Supprimer les séries et catégories générées par défaut.
9. Ajouter de nouvelles catégories.
10. Ajouter une nouvelle série.

Enregistrer la présentation modifiée dans un fichier PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**Les variantes 'Pie of Pie' et 'Bar of Pie' sont‑elles prises en charge ?**

Oui, la bibliothèque [prend en charge](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/charttype/) un tracé secondaire pour les graphiques circulaires, y compris les types 'Pie of Pie' et 'Bar of Pie'.

**Puis‑je exporter uniquement le graphique en tant qu'image (par exemple, PNG) ?**

Oui, vous pouvez [exporter le graphique lui‑même en tant qu'image](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shape/getimage/) (comme PNG) sans la présentation complète.