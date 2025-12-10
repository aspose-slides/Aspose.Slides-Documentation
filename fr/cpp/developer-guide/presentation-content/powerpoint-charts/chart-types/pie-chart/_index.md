---
title: Personnaliser les graphiques circulaires dans les présentations en C++
linktitle: Diagramme circulaire
type: docs
url: /fr/cpp/pie-chart/
keywords:
- diagramme circulaire
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
description: "Apprenez à créer et personnaliser des diagrammes circulaires en C++ avec Aspose.Slides, exportables vers PowerPoint, pour améliorer votre narration de données en quelques secondes."
---

## **Options de deuxième tracé pour les graphiques Pie of Pie et Bar of Pie**
Aspose.Slides for C++ prend désormais en charge les options de deuxième tracé pour les graphiques Pie of Pie ou Bar of Pie. Dans ce sujet, nous verrons avec un exemple comment spécifier ces options à l'aide d'Aspose.Slides. Pour spécifier les propriétés, veuillez suivre les étapes ci‑dessous :

1. Instancier l'objet de classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Ajouter un graphique sur la diapositive.
1. Spécifier les options de deuxième tracé du graphique.
1. Enregistrer la présentation sur le disque.

Dans l'exemple ci‑dessous, nous avons défini différentes propriétés du graphique Pie of Pie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **Définir les couleurs automatiques des tranches du graphique Pie**
Aspose.Slides for C++ fournit une API simple permettant de définir automatiquement les couleurs des tranches du graphique Pie. Le code d'exemple applique la configuration des propriétés sus‑mentionnées.

1. Créer une instance de la classe Presentation.
1. Accéder à la première diapositive.
1. Ajouter un graphique avec les données par défaut.
1. Définir le titre du graphique.
1. Définir la première série pour afficher les valeurs.
1. Définir l'index de la feuille de données du graphique.
1. Obtenir la feuille de calcul des données du graphique.
1. Supprimer les séries et catégories générées par défaut.
1. Ajouter de nouvelles catégories.
1. Ajouter une nouvelle série.

Enregistrer la présentation modifiée dans un fichier PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**Les variantes 'Pie of Pie' et 'Bar of Pie' sont‑elles prises en charge ?**

Oui, la bibliothèque [prend en charge](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) un tracé secondaire pour les graphiques en secteur, y compris les types 'Pie of Pie' et 'Bar of Pie'.

**Puis‑je exporter uniquement le graphique sous forme d'image (par exemple, PNG) ?**

Oui, vous pouvez [exporter le graphique lui‑même en tant qu'image](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) (par exemple PNG) sans toute la présentation.